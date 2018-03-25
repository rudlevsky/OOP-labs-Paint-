using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace WindowsFormsApp1
{
    public class Line: Figures
    {
        public override void draw(Pen pen, Graphics graph)
        {
            graph.DrawLine(pen, point_x1, point_y1, point_x2, point_y2);
            pen.Dispose();
            graph.Dispose();
        }
    }
}
