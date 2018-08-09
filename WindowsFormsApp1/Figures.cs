using System.Drawing;
using System.Runtime.Serialization;

namespace WindowsFormsApp1
{
    [DataContract]
    public abstract class Figures
    {
        [DataMember]
        public int point_x1, point_y1;

        [DataMember]
        public int point_x2, point_y2;

        [DataMember]
        public int pen_wid { get; set; }

        [DataMember]
        public Color pcolor;

        [DataMember]
        public bool flag_clean = false;

        // pixels which should be added for checking points of an object
        protected const int pixels = 5;

        // pixels which should be added for changing a size of an object
        protected const int change_size = 10;

        public abstract void draw(Pen pen, Graphics graph);
        public abstract void auto_draw(Pen pen, Graphics graph);
        public abstract void chng_size(string key_name);
        public abstract void rewrite(int x_cord, int y_cord);
        public abstract bool check_coords(int x_mouse, int y_mouse);
    }
}
