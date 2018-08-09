using System.Drawing;
using System.Runtime.Serialization;

namespace WindowsFormsApp1
{
    [DataContract]
    public class Line: Figures, ISelected, IEdited
    {       
        // method for changing a size of an object
        public override void chng_size(string key_name)
        {
            if (point_x2 - point_x1 > 0)
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
            } else
            {
                switch (key_name)
                {
                    case "num_2":
                        point_y1 += change_size;
                        break;
                    case "num_4":
                        point_x1 -= change_size;
                        break;
                    case "num_6":
                        point_x1 += change_size;
                        break;
                    case "num_8":
                        point_y1 -= change_size;
                        break;
                }
            }
        }

        // method for moving an object
        public override void rewrite(int x_cord, int y_cord)
        {
            point_x2 = point_x2 - (point_x1 - x_cord);
            point_y2 = point_y2 - (point_y1 - y_cord);
            point_x1 = x_cord;
            point_y1 = y_cord;
        }

        // method for drawing an object
        public override void draw(Pen pen, Graphics graph)
        {
            graph.DrawLine(pen, point_x1, point_y1, point_x2, point_y2);
        }

        // method for automatical drawing an object
        public override void auto_draw(Pen pen, Graphics graph)
        {
            graph.DrawLine(pen, point_x1, point_y1, point_x2, point_y2);
        }

        // method for checking the coordinates of an object
        public override bool check_coords(int x_mouse, int y_mouse)
        {
            double y;
            int param_a, param_b;

            if (point_x2 - point_x1 > 0)
            {
                param_a = point_x1;
                param_b = point_x2;
            } else
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
            }       
            return false;
        }
    }
}
