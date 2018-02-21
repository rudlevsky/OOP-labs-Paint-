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
        Ellipse ellipse1;
        Rectang rect1;
        Round rond1;

        public Form1()
        {
            InitializeComponent();
            to_init();
        }

        //Инициализация всех объектов
        private void to_init()   
        {
            bmp = new Bitmap(picture.Width, picture.Height);
            graph = Graphics.FromImage(bmp);
            pen1 = new Pen(Color.Blue);
            line1 = new Line(10, 50, 150, 200);
            square1 = new square(500, 50, 150, 150);
            ellipse1 = new Ellipse(250, 290, 200, 150);
            rect1 = new Rectang(200, 50, 250, 150);
            rond1 = new Round(10, 250, 200, 200);
        }

        //Запуск на рисование объектов
        private void start_Click(object sender, EventArgs e)
        {
            line1.draw(line1, pen1, graph);
            rect1.draw(rect1, pen1, graph);
            square1.draw(square1, pen1, graph);
            graph.DrawEllipse(pen1, ellipse1.point_x, ellipse1.point_y, ellipse1.wigth, ellipse1.heigth);
            graph.DrawEllipse(pen1, rond1.point_x, rond1.point_y, rond1.wigth, rond1.heigth);
            picture.Image = bmp;
        }

        //Очистка поля для рисования
        private void clear_Click(object sender, EventArgs e)
        {
            picture.Image = null;
        }
    }
}
