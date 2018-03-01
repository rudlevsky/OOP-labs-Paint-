using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace WindowsFormsApp1
{
    class Pencil
    {
        public void draw(Pen pen, Graphics graph, int point_x, int point_y, int point_x2, int point_y2)
        {
            graph.DrawLine(pen, point_x, point_y, point_x2, point_y2);
        }
    }
}
