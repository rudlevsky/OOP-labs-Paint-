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
    public class Line: Figures
    {
        public override void draw(Pen pen, Graphics graph)
        {
            graph.DrawLine(pen, point_x1, point_y1, point_x2, point_y2);
            pen.Dispose();
            graph.Dispose();
        }

        public override void auto_draw(Pen pen, Graphics graph)
        {
            graph.DrawLine(pen, point_x1, point_y1, point_x2, point_y2);
            pen.Dispose();
            graph.Dispose();
        }
    }
}
