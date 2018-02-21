using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace WindowsFormsApp1
{
    class Figures
    {
        public int point_x, point_y;
        public int heigth, wigth;

        public Figures(int point_x, int point_y, int wigth, int heigth)
        {
            this.point_x = point_x;
            this.point_y = point_y;
            this.heigth = heigth;
            this.wigth = wigth;
        }

        public void draw(Rectang obj, Pen pen, Graphics graph)
        {
            graph.DrawRectangle(pen, obj.point_x, obj.point_y, obj.point_x, obj.point_y);
        }

        public void draw(square obj, Pen pen, Graphics graph)
        {
            graph.DrawRectangle(pen, obj.point_x, obj.point_y, obj.point_x, obj.point_y);
        }

    }
}
