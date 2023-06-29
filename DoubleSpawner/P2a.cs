using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoubleSpawner
{
    /// <summary>
    /// pathData to angleData
    /// </summary>
    internal class P2a
    {
        // 定义hashmap
        public Hashtable Map = new Hashtable();
        /// <summary>
        /// 初始化哈希表
        /// </summary>
        public void MapSet()
        {
            Map.Add('R', 0);
            Map.Add('p', 15);
            Map.Add('j', 30);
            Map.Add('E', 45);
            Map.Add('T', 60);
            Map.Add('o', 75);
            Map.Add('U', 90);
            Map.Add('q', 105);
            Map.Add('G', 120);
            Map.Add('Q', 135);
            Map.Add('H', 150);
            Map.Add('W', 165);
            Map.Add('L', 180);
            Map.Add('x', 195);
            Map.Add('N', 210);
            Map.Add('Z', 225);
            Map.Add('F', 240);
            Map.Add('V', 255);
            Map.Add('D', 270);
            Map.Add('Y', 285);
            Map.Add('B', 300);
            Map.Add('C', 315);
            Map.Add('M', 330);
            Map.Add('A', 345);
            Map.Add('!', 999);
        }

        public char FlipPath(char path)
        {
            char r = '1';
            switch (path)
            {
                case '5':
                    r = '6';
                    break;
                case '6':
                    r = '5';
                    break;
                case '7':
                    r = '8';
                    break;
                case '8':
                    r = '7';
                    break;
                case 'A':
                    r = 'x';
                    break;
                case 'B':
                    r = 'F';
                    break;
                case 'C':
                    r = 'Z';
                    break;
                case 'D':
                    r = 'D';
                    break;
                case 'E':
                    r = 'Q';
                    break;
                case 'F':
                    r = 'B';
                    break;
                case 'G':
                    r = 'T';
                    break;
                case 'H':
                    r = 'J';
                    break;
                case 'J':
                    r = 'H';
                    break;
                case 'L':
                    r = 'R';
                    break;
                case 'M':
                    r = 'N';
                    break;
                case 'N':
                    r = 'M';
                    break;
                case 'Q':
                    r = 'E';
                    break;
                case 'R':
                    r = 'L';
                    break;
                case 'T':
                    r = 'G';
                    break;
                case 'U':
                    r = 'U';
                    break;
                case 'V':
                    r = 'Y';
                    break;
                case 'W':
                    r = 'p';
                    break;
                case 'Y':
                    r = 'V';
                    break;
                case 'Z':
                    r = 'C';
                    break;
                case 'o':
                    r = 'q';
                    break;
                case 'p':
                    r = 'W';
                    break;
                case 'q':
                    r = 'o';
                    break;
                case 'x':
                    r = 'A';
                    break;
            }
            return r;
        }
    }
}
