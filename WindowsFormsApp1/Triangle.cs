using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace WindowsFormsApp1
{
    class Triangle: Figures
    {
        private int point_x3;

        public override void draw(Pen pen, Graphics graph)
        {
            point_x3 = point_x1 - (point_x2 - point_x1);

            Point point1 = new Point(point_x1, point_y1);
            Point point2 = new Point(point_x2, point_y2);
            Point point3 = new Point(point_x3, point_y2);

            Point[] curvePoints =
            {
                 point1,
                 point2,
                 point3,
            };

            graph.DrawPolygon(pen, curvePoints);
            pen.Dispose();
            graph.Dispose();
        }
    }
}
