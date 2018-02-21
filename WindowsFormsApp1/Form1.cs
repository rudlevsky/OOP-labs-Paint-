using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        Bitmap bmp; 
        Graphics graph; 
        Pen pen1;
        Line line1;
        square square1;

        public Form1()
        {
            InitializeComponent();
            to_init();
        }

        private void to_init()
        {
            bmp = new Bitmap(picture.Width, picture.Height);
            graph = Graphics.FromImage(bmp);
            pen1 = new Pen(Color.Blue);
            line1 = new Line(10, 50, 150, 200);
            square1 = new square(200, 150, 200, 150);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            graph.DrawLine(pen1, line1.x1, line1.y1, line1.x2, line1.y2);
            picture.Image = bmp;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            graph.DrawRectangle(pen1, square1.x1, square1.y1, square1.x2, square1.y2);
            picture.Image = bmp;
        }
    }
}
