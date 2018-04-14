using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Runtime.Serialization.Json;
using System.Runtime.Serialization;

namespace WindowsFormsApp1
{
    [DataContract]
    public abstract class Figures
    {
        [DataMember]
        public int point_x1, point_y1;

        [DataMember]
        public int point_x2, point_y2;

        [DataMember]
        public int pen_wid { get; set; }

        [DataMember]
        public Color pcolor;

        protected const int pixels = 5;
        public abstract void draw(Pen pen, Graphics graph);
        public abstract void auto_draw(Pen pen, Graphics graph);
    }
}
