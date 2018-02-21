using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace WindowsFormsApp1
{
    class Line
    {
        public int point_x1, point_x2;
        public int point_y1, point_y2;

        public Line (int point_x1, int point_y1, int point_x2, int point_y2)
        {
            this.point_x1 = point_x1;
            this.point_y1 = point_y1;
            this.point_x2 = point_x2;
            this.point_y2 = point_y2;
        } 
      
        public void draw(Line line, Pen pen, Graphics graph)
        {
            graph.DrawLine(pen, line.point_x1, line.point_y1, line.point_x2, line.point_y2);
        }
    }
}
