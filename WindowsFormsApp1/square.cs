using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace WindowsFormsApp1
{
    public class Square: Figures
    {
        private int heigth, width;

        public override void draw(Pen pen, Graphics graph)
        {
            heigth = point_y2 - point_y1;
            width = point_x2 - point_x1;
            graph.DrawRectangle(pen, point_x1, point_y1, width, heigth);
            pen.Dispose();
            graph.Dispose();
        }
    }
}
