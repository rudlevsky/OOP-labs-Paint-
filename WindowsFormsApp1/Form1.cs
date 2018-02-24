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
        Square square1;
        Ellipse ellipse1;
        Rectang rect1;
        Round rond1;
        Oval oval1;

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
            square1 = new Square(500, 50, 650, 200);
            rect1 = new Rectang(200, 50, 450, 170);
            rond1 = new Round(10, 250, 210, 450);
            ellipse1 = new Ellipse(250, 290, 500, 390);
            oval1 = new Oval(510, 270, 610, 470);
        }

        //Запуск на рисование объектов
        private void start_Click(object sender, EventArgs e)
        {
            line1.draw(pen1, graph);
            rect1.draw(pen1, graph);
            square1.draw(pen1, graph);
            ellipse1.draw(pen1, graph);
            rond1.draw(pen1, graph);
            oval1.draw(pen1, graph);
            picture.Image = bmp;
        }

        //Очистка поля для рисования
        private void clear_Click(object sender, EventArgs e)
        {
            picture.Image = null;
        }
    }
}
