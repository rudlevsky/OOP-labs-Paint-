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
    public class Pens: Figures, ISelected, IEdited
    {
        [DataMember]
        private List<int> points_x1 = new List<int>();
        [DataMember]
        private List<int> points_x2 = new List<int>();
        [DataMember]
        private List<int> points_y1 = new List<int>();
        [DataMember]
        private List<int> points_y2 = new List<int>();

        public void chng_size(string key_name) { }

        // method for moving an object
        public void rewrite(int x_cord, int y_cord)
        {
            int sm_x = points_x1[0] - x_cord;
            int sm_y = points_y1[0] - y_cord;

            for (int i = 0; i < points_x1.Count; i++)
            {
                points_x1[i] -= sm_x;
                points_y1[i] -= sm_y;
                points_x2[i] -= sm_x;
                points_y2[i] -= sm_y;
            }
        }

        // method for drawing an object
        public override void draw(Pen pen, Graphics graph)
        {
            points_x1.Add(point_x1);
            points_x2.Add(point_x2);
            points_y1.Add(point_y1);
            points_y2.Add(point_y2);
            graph.DrawLine(pen, point_x1, point_y1, point_x2, point_y2);
            pen.Dispose();
            graph.Dispose();
        }

        // method for automatical drawing an object
        public override void auto_draw(Pen pen, Graphics graph)
        {
            for (int i = 0; i < points_x1.Count; i++)
            {
                graph.DrawLine(pen, points_x1[i], points_y1[i], points_x2[i], points_y2[i]);
            }
            pen.Dispose();
            graph.Dispose();
        }

        // method for checking the coordinates of an object
        public bool check_coords(int x_mouse, int y_mouse)
        {
            for (int i = 0; i < points_x1.Count; i++)
            {
                if ((x_mouse <= (points_x1[i] + pixels)) && (x_mouse >= (points_x1[i] - pixels)) && 
                    (y_mouse <= (points_y1[i] + pixels)) && (y_mouse >= (points_y1[i] - pixels)))
                {
                    return true;
                }
            }
            return false;
        }
    }
}
