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

        public void draw(Pen pen, Graphics graph, int point_x, int point_y, int point_x2, int point_y2)
        {
            //heigth = point_y2 - point_y;
            //width = point_x2 - point_x;
            graph.DrawRectangle(pen, point_x, point_y, width, heigth);
        }
    }
}
