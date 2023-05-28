using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AdofaiSaves
{
    internal class Lib
    {
        public static void Info(object info, object title)
        {
            MessageBox.Show(info.ToString(), title.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public static void Error(object info, object title)
        {
            MessageBox.Show(info.ToString(), title.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        public static void Warn(object info, object title)
        {
            MessageBox.Show(info.ToString(), title.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        public static void Info(object info)
        {
            MessageBox.Show(info.ToString(), "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public static void Error(object info)
        {
            MessageBox.Show(info.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        public static void Warn(object info)
        {
            MessageBox.Show(info.ToString(), "Warning",MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }


        /// <summary>
        /// 转换String为Json
        /// </summary>
        /// <param name="jsonText">待转换string</param>
        /// <returns>JsonObject(NewtonSoft.json)</returns>
        public static JObject AdofaiParse(string jsonText)
        {
            try
            {
                JObject jo = JObject.Parse(jsonText);
                return jo;
            }
            catch
            {
                jsonText.TrimEnd();
                jsonText = jsonText.Replace(", ,", ",");
                jsonText = jsonText.Replace("},\n\t]", "}\n\t]");
                jsonText = jsonText.Replace(", },", " },");
                jsonText = jsonText.Replace(", }", " }");
                jsonText = jsonText.Replace(",\n,", "");
                jsonText = jsonText.Replace("]\n\t", "],\n\t");
                JObject jo = JObject.Parse(jsonText);
                return jo;
            }

        }
    }
}
