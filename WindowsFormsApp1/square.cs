using System.Drawing;
using System.Runtime.Serialization;

namespace WindowsFormsApp1
{
    [DataContract]
    public class Square: Figures, ISelected, IEdited
    {
        [DataMember]
        private int heigth, width;

        // method for changing a size of an object
        public override void chng_size(string key_name)
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
            heigth = point_y2 - point_y1;
            width = point_x2 - point_x1;
            graph.DrawRectangle(pen, point_x1, point_y1, width, heigth);
        }

        // method for automatical drawing an object
        public override void auto_draw(Pen pen, Graphics graph)
        {
            graph.DrawRectangle(pen, point_x1, point_y1, width, heigth);
        }

        // method for checking the coordinates of an object
        public override bool check_coords(int x_mouse, int y_mouse)
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
