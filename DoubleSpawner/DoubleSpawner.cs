using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace DoubleSpawner
{
    public partial class DoubleSpawner : Form
    {
        // global var
        Thread maint;
        // 是否正在进行转换
        bool isModeRunning = false;
        // 文件目录
        string AdofaiSpectralFile = "";
        // 关卡里floor总数
        int MapNum = 0;
        // Adofai Json
        JObject Adofai;
        

        public DoubleSpawner()
        {
            CheckForIllegalCrossThreadCalls = false;
            InitializeComponent();
        }
        public string OpenFile()
        {
            string strFileName = "";
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Adofai谱面文件(*.adofai)|*.adofai";
            ofd.ValidateNames = true; // 验证用户输入是否是一个有效的Windows文件名
            ofd.CheckFileExists = true; // 验证路径的有效性
            ofd.CheckPathExists = true;// 验证路径的有效性
            if (ofd.ShowDialog() == DialogResult.OK) // 用户点击确认按钮，发送确认消息
            {
                strFileName = ofd.FileName;// 获取在文件对话框中选定的路径或者字符串
            }
            return strFileName;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // 打开文件
            AdofaiSpectralFile = OpenFile();
            if (AdofaiSpectralFile == "")
            {
                Lib.Error("打开文件失败！");
                return;
            }
            MapLoader();
            if (MapNum != 0)
            {
                maint = new Thread(MainThreard);
                select.Enabled = false;
                maint.Start();
            }
            
        }

        // 主线程
        private void MainThreard()
        {
            isModeRunning = true;
            // 创建数组，存放新的angleData
            JArray angleData = new JArray();
            // 创建actions数组，读取original_actions
            JArray actions = Adofai["actions"] as JArray;
            // 创建actions分数组，用来写新的actions
            // 感谢ChatGPT和Jiang_Tie
            JArray actionTemp = (JArray)actions.DeepClone();
            // 要处理第几号floor
            int FloorNum = 0;
            // 旋转特色 第一下上转，第二下下转， 对应true & false
            bool isUpTwirl = true;
            // 读取angleData数据
            foreach (int a in Adofai["angleData"].Select(v => (int)v))
            {
                // 现在处理的是第几号floor
                FloorNum++;
                // 显示状态
                status.Text = "处理进度: " + FloorNum + " / " + MapNum;
                angleData.Add(a);
                // 如果下次是上转
                // 添加双押信息
                if (isUpTwirl)
                {
                    // 判断角度
                    if (a + 165 > 365)
                    {
                        angleData.Add(a + 165 - 365);
                    }
                    else
                    {
                        angleData.Add(a + 165);
                    }
                    angleData.Add(999);
                    // 判断旋转
                    if (actions.Count > 0)
                    {
                        for (int f = 0; f < actions.Count; f++)
                        {
                            // 判断floor + Twirl
                            if ((int)actions[f]["floor"] == FloorNum && (string)actions[f]["eventType"] == "Twirl")
                            {
                                actionTemp[f]["floor"].Replace(FloorNum * 3);
                                // 下次就是下转
                                isUpTwirl = false;
                            }
                        }
                    }

                }
                // 如果下转
                else
                {
                    // 判断角度
                    // 有90°旋转
                    if (actions.Count > 0)
                    {
                        for (int f = 0; f < actions.Count; f++)
                        {
                            // 判断floor + Twirl
                            if ((int)actions[f]["floor"] == FloorNum && (string)actions[f]["eventType"] == "Twirl")
                            {
                                actionTemp[f]["floor"].Replace(FloorNum * 3 - 2);
                                angleData.Add(a - 195);
                                angleData.Add(999);
                                // 下次就是上转
                                isUpTwirl = true;
                            }
                        }
                    }
                    // 正常情况
                    if (!isUpTwirl)
                    {
                        if (a + 195 > 365)
                        {
                            angleData.Add(a + 195 - 365);
                        }
                        else
                        {
                            angleData.Add(a + 195);
                        }
                        angleData.Add(999);
                    } 
                }
            }
            // Merge
            Adofai.Remove("actions");
            Adofai.Add("actions", actionTemp);
            Adofai.Remove("angleData");
            Adofai.Add("angleData", angleData);

            File.WriteAllText(AdofaiSpectralFile, JsonConvert.SerializeObject(Adofai, Formatting.Indented)
                .Replace("\\r\\n", "\r\n")
                .Replace("\\\"", "\""));
            // status.Text = "已处理完成";
            select.Enabled = true;
            isModeRunning = false;
        }

        private void MapLoader()
        {
            string adofaiDirectoryName = Path.GetDirectoryName(AdofaiSpectralFile);
            string adofaiMapName = Path.GetFileName(AdofaiSpectralFile);
            status.Text = "已获取谱面文件" + adofaiMapName;
            StreamReader file = File.OpenText(AdofaiSpectralFile);
            // String2Json
            try
            {
                Adofai = Lib.AdofaiParse(file.ReadToEnd());
                file.Close();
                if (!File.Exists(adofaiDirectoryName + @"\original_" + adofaiMapName))
                {
                    status.Text = "正在备份谱面文件到" + adofaiDirectoryName + @"\original_" + adofaiMapName;
                    File.Copy(AdofaiSpectralFile, adofaiDirectoryName + @"\original_" + adofaiMapName);
                }
                if (Adofai.ContainsKey("angleData"))
                {
                    MapNum = Adofai["angleData"].Count();
                }
                else
                {
                    status.Text = "此谱面使用的是pathData,请按照UP视频里的方式转化为angleData";
                    return;
                }
                status.Text = "已成功获取谱面信息";
                return;
            }
            catch (Exception e)
            {
                file.Close();
                status.Text = "发生了意料之外的错误，可能是您的谱面文件格式有误\n" +
                    "请打开json.cn网站并且将谱面文件内容复制进去进行检验";
                MessageBox.Show(e.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        private void DoubleSpawner_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (isModeRunning)
            {
                Lib.Warn("尚未将谱面转化完成，请等待完成后再退出程序。");
                e.Cancel = true;
            }
            else
            {
                Environment.Exit(0);
            }
        }
    }
}
