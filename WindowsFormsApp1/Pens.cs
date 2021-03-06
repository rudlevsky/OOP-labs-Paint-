﻿using System.Collections.Generic;
using System.Drawing;
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

        private int wid = 0;
        private int hei = 0;

        private void find_hei()
        {
            for (int i = 0; i < points_y1.Count; i++)
            {
                if (points_y1[i] > hei)
                {
                    hei = points_y1[i];
                }
            }
        }

        private void find_wid()
        {
            for (int i = 0; i < points_x1.Count; i++)
            {
                if (points_x1[i] > wid)
                {
                    wid = points_x1[i];
                }
            }
        }

        public override void chng_size(string key_name)
        {
            if (wid == 0)
            {
                find_wid();
            }

            if (hei == 0)
            {
                find_hei();
            }

            switch (key_name)
            {
                case "num_2":
                    for (int i = 0; i < points_x1.Count; i++)
                    {
                        points_y1[i] = points_y1[i] * hei / (points_y1[i] + change_size);
                        points_y2[i] = points_y2[i] * hei / (points_y2[i] + change_size);
                    }
                    break;
                case "num_4":
                    for (int i = 0; i < points_x1.Count; i++)
                    {
                        points_x1[i] = points_x1[i] * wid / (points_x1[i] + change_size);
                        points_x2[i] = points_x2[i] * wid / (points_x2[i] + change_size);
                    }
                    break;
                case "num_6":
                    for (int i = 0; i < points_x1.Count; i++)
                    {
                        points_x1[i] = points_x1[i] * (points_x1[i] + change_size) / wid;
                        points_x2[i] = points_x2[i] * (points_x2[i] + change_size) / wid;
                    }
                    break;
                case "num_8":
                    for (int i = 0; i < points_x1.Count; i++)
                    {
                        points_y1[i] = points_y1[i] * (points_y1[i] + change_size) / hei;
                        points_y2[i] = points_y2[i] * (points_y2[i] + change_size) / hei;
                    }
                    break;
            }
        }

        // method for moving an object
        public override void rewrite(int x_cord, int y_cord)
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
            point_x1 = point_x2;
            point_y1 = point_y2;
        }

        // method for automatical drawing an object
        public override void auto_draw(Pen pen, Graphics graph)
        {
            for (int i = 0; i < points_x1.Count; i++)
            {
                graph.DrawLine(pen, points_x1[i], points_y1[i], points_x2[i], points_y2[i]);
            }
        }

        // method for checking the coordinates of an object
        public override bool check_coords(int x_mouse, int y_mouse)
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
