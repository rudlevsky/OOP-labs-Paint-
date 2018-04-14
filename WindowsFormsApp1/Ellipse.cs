using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Runtime.Serialization.Json;
using System.Runtime.Serialization;

namespace WindowsFormsApp1
{
    [DataContract]
    public class Ellipse: Figures, ISelected, IEdited
    {
        [DataMember]
        private int heigth, width;

        public override void draw(Pen pen, Graphics graph)
        {
            heigth = point_y2 - point_y1;
            width = point_x2 - point_x1;
            graph.DrawEllipse(pen, point_x1, point_y1, width, heigth);
            pen.Dispose();
            graph.Dispose();
        }

        public override void auto_draw(Pen pen, Graphics graph)
        {
            graph.DrawEllipse(pen, point_x1, point_y1, width, heigth);
            pen.Dispose();
            graph.Dispose();
        }

        public bool check_coords(int x_mouse, int y_mouse)
        {
          /*  double y;
            int param_a, param_b;

            if (point_x2 - point_x1 > 0)
            {
                param_a = point_x1;
                param_b = point_x2;
            }
            else
            {
                param_a = point_x2;
                param_b = point_x1;
            }

            for (int x = param_a; x < param_b; x++)
            {
                y = (point_y2 - point_y1) * (x - point_x1) / (point_x2 - point_x1) + point_y1;

                if ((x_mouse <= (x + pixels)) && (x_mouse >= (x - pixels)) &&
                (y_mouse <= (y + pixels)) && (y_mouse >= (y - pixels)))
                {
                    return true;
                }
            }*/

            return false;
        }

    }
}
