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
    public class Square: Figures, ISelected, IEdited
    {
        [DataMember]
        private int heigth, width;

        public override void draw(Pen pen, Graphics graph)
        {
            heigth = point_y2 - point_y1;
            width = point_x2 - point_x1;
            graph.DrawRectangle(pen, point_x1, point_y1, width, heigth);
            pen.Dispose();
            graph.Dispose();
        }

        public override void auto_draw(Pen pen, Graphics graph)
        {
            graph.DrawRectangle(pen, point_x1, point_y1, width, heigth);
            pen.Dispose();
            graph.Dispose();
        }

        public bool check_coords(int x_mouse, int y_mouse)
        {
            int value = point_y1;

            for (int j = 0; j < 2; j++) {
                for (int i = point_x1; i < point_x2; i++)
                {
                    if ((x_mouse <= (i + pixels)) && (x_mouse >= (i - pixels)) &&
                    (y_mouse <= (value + pixels)) && (y_mouse >= (value - pixels)))
                    {
                        return true;
                    }
                }
                value = point_y2;
            }

            value = point_x1;
            for (int j = 0; j < 2; j++)
            {
                for (int i = point_y1; i < point_y2; i++)
                {
                    if ((x_mouse <= (value + pixels)) && (x_mouse >= (value - pixels)) &&
                    (y_mouse <= (i + pixels)) && (y_mouse >= (i - pixels)))
                    {
                        return true;
                    }
                }
                value = point_x2;
            }

            return false;
        }
    }
}
