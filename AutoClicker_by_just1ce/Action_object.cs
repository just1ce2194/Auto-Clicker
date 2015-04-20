using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace AutoClicker_by_just1ce
{
    class Action_object
    {
        int Pos_x, Pos_y;   // X,Y coordinates
        int time;           
        string KeyName;
        Color cur_color;
        public Action_object(double Time, string keyName,Tuple<int,int> Pos,Color color)
        {
            this.time = Convert.ToInt32(Time * 1000);
            this.KeyName = keyName;
            this.Pos_x = Pos.Item1;
            this.Pos_y = Pos.Item2;
            this.cur_color = color;
        }
        public int Get_time()
        {
            return time;
        }
        public void Set_time(double t)
        {
            time = Convert.ToInt32(t*1000);
        }
        public string Get_KeyName()
        {
            return KeyName;
        }
        public void Set_KeyName(string s)
        {
            KeyName = s;
        }
        public Tuple<int,int> Get_PosXY()
        {
            return new Tuple<int,int>(Pos_x,Pos_y);
        }
        public void Set_time(Tuple<int, int> t)
        {
            Pos_x = t.Item1;
            Pos_y = t.Item2;
        }
    }
}
