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
        public Line(int point_x1, int point_y1, int point_x2, int point_y2) : base(point_x1, point_y1, point_x2, point_y2)
        {
        }

        public void draw(Pen pen, Graphics graph)
        {
            graph.DrawLine(pen, point_x1, point_y1, point_x2, point_y2);
        }
    }
}
