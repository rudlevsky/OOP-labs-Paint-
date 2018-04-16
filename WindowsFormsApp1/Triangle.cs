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
    public class Triangle : Figures, ISelected, IEdited
    {
        [DataMember]
        private int point_x3;

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
            point_x3 = point_x1 - (point_x2 - point_x1);
        }

        // method for moving an object
        public void rewrite(int x_cord, int y_cord)
        {
            point_x2 = point_x2 - (point_x1 - x_cord);
            point_y2 = point_y2 - (point_y1 - y_cord);
            point_x1 = x_cord;
            point_y1 = y_cord;
            point_x3 = point_x1 - (point_x2 - point_x1);
        }

        // method for drawing an object
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

        // method for automatical drawing an object
        public override void auto_draw(Pen pen, Graphics graph)
        {
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

        // method for checking the coordinates of an object
        public bool check_coords(int x_mouse, int y_mouse)
        {
            double y;

            for (int x = point_x1; x < point_x2; x++)
            {
                y = (point_y2 - point_y1) * (x - point_x1) / (point_x2 - point_x1) + point_y1;

                if ((x_mouse <= (x + pixels)) && (x_mouse >= (x - pixels)) &&
                (y_mouse <= (y + pixels)) && (y_mouse >= (y - pixels)))
                {
                    return true;
                }
            }

            for (int x = point_x3; x < point_x1; x++)
            {
                y = (point_y2 - point_y1) * (x - point_x1) / (point_x3 - point_x1) + point_y1;

                if ((x_mouse <= (x + pixels)) && (x_mouse >= (x - pixels)) &&
                (y_mouse <= (y + pixels)) && (y_mouse >= (y - pixels)))
                {
                    return true;
                }
            }

            for (int x = point_x3; x < point_x2; x++)
            {
                if ((x_mouse <= (x + pixels)) && (x_mouse >= (x - pixels)) &&
                (y_mouse <= (point_y2 + pixels)) && (y_mouse >= (point_y2 - pixels)))
                {
                    return true;
                }
            }
            return false;
        }
    }
}
