using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoubleSpawner
{
    // pathData to angleData
    class p2a
    {
        // 定义hashmap
        public Hashtable Map = new Hashtable();
        /// <summary>
        /// 初始化哈希表
        /// </summary>
        public void MapSet()
        {
            /*
             // 获取angledata的上两位(即双押之前的angle) 
                    // 由于不存在谱面第一个格子是中旋的情况，所以不做判断
                    int TempAngle = (int)angleData[angleData.Count - 3];
                    angleData.Remove(angleData[angleData.Count - 3]);
                    angleData.Remove(angleData[angleData.Count - 2]);
                    angleData.Remove(angleData[angleData.Count - 1]);
                    angleData.Add(TempAngle - 5);
                    angleData.Add(999);
                    angleData.Add(TempAngle - 10);
                    angleData.Add(999);
                    continue;
             
             */
            Map.Add("R",0);
            Map.Add("p", 15);
            Map.Add("j", 30);
            Map.Add("E", 45);
            Map.Add("T", 60);
            Map.Add("o", 75);
            Map.Add("U", 90);
            Map.Add("q", 105);
            Map.Add("G", 120);
            Map.Add("Q", 135);
            Map.Add("H", 150);
            Map.Add("W", 165);
            Map.Add("L", 180);
            Map.Add("x", 195);
            Map.Add("N", 210);
            Map.Add("Z", 225);
            Map.Add("F", 240);
            Map.Add("V", 255);
            Map.Add("D", 270);
            Map.Add("Y", 285);
            Map.Add("B", 300);
            Map.Add("C", 315);
            Map.Add("M", 330);
            Map.Add("A", 345);
            Map.Add("!", 999);
        }
    }
}
