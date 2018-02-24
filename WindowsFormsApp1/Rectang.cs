using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace WindowsFormsApp1
{
    class Rectang: Figures
    {
        private int heigth, width;

        public Rectang(int point_x1, int point_y1, int point_x2, int point_y2) : base(point_x1, point_y1, point_x2, point_y2)
        {
        }

        public void draw(Pen pen, Graphics graph)
        {
            heigth = point_y2 - point_y1;
            width = point_x2 - point_x1;
            graph.DrawRectangle(pen, point_x1, point_y1, width, heigth);
        }
    }
}
