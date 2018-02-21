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
        public Rectang (int point_x, int point_y, int wigth, int heigth): base (point_x, point_y, wigth, heigth)
        {
        }

        public void draw(Rectang obj, Pen pen, Graphics graph)
        {
            graph.DrawRectangle(pen, obj.point_x, obj.point_y, obj.wigth, obj.heigth);
        }
    }
}
