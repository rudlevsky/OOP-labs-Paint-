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

        // method for changing a size of an object
        public void chng_size(string key_name)
        {
            switch (key_name)
            {
                case "num_2":
                    point_y2 += change_size;
                    break;
                case "num_4":
                    point_x2 -= change_size;
                    break;
                case "num_6":
                    point_x2 += change_size;
                    break;
                case "num_8":
                    point_y2 -= change_size;
                    break;
            }
            heigth = point_y2 - point_y1;
            width = point_x2 - point_x1;
        }

        // method for moving an object
        public void rewrite(int x_cord, int y_cord)
        {
            point_x2 = point_x2 - (point_x1 - x_cord);
            point_y2 = point_y2 - (point_y1 - y_cord);
            point_x1 = x_cord;
            point_y1 = y_cord;
            heigth = point_y2 - point_y1;
            width = point_x2 - point_x1;
        }

        // method for drawing an object
        public override void draw(Pen pen, Graphics graph)
        {
            heigth = point_y2 - point_y1;
            width = point_x2 - point_x1;
            graph.DrawEllipse(pen, point_x1, point_y1, width, heigth);
            pen.Dispose();
            graph.Dispose();
        }

        // method for automatical drawing an object
        public override void auto_draw(Pen pen, Graphics graph)
        {
            graph.DrawEllipse(pen, point_x1, point_y1, width, heigth);
            pen.Dispose();
            graph.Dispose();
        }

        // method for checking the coordinates of an object
        public bool check_coords(int x_mouse, int y_mouse)
        {
            int x_cord = 0, y_cord = 0;
            int square_count = 4;

            for (int i = 0; i < square_count; i++)
            {
                switch (i)
                {
                    case 0:
                        x_cord = point_x1 + width / 2;
                        y_cord = point_y1;
                        break;
                    case 1:
                        x_cord = point_x1;
                        y_cord = point_y1 + heigth/2;
                        break;
                    case 2:
                        x_cord = point_x1 + width;
                        y_cord = point_y1 + heigth/2;
                        break;
                    case 3:
                        x_cord = point_x1 + width / 2;
                        y_cord = point_y1 + heigth;
                        break;
                }

                if ((x_mouse <= (x_cord + pixels)) && (x_mouse >= (x_cord - pixels)) &&
                (y_mouse <= (y_cord + pixels)) && (y_mouse >= (y_cord - pixels)))
                {
                    return true;
                }
            }
            return false;
        }
    }
}
