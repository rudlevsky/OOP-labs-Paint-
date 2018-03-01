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
        Color pencolor;
        Pencil pencil1;

        private bool towrite = false;
        private int pen_width, point_x, point_y;
        string name_tool;

        public Form1()
        {
            InitializeComponent();
            to_init();
        }

        //Инициализация объектов
        private void to_init()
        {
            bmp = new Bitmap(picture.Width, picture.Height);
            graph = Graphics.FromImage(bmp);
            line1 = new Line();
            square1 = new Square();
            ellipse1 = new Ellipse();
            pencil1 = new Pencil();
            pencolor = Color.Red;
        }

        //Очистка поля для рисования
        private void clear_Click(object sender, EventArgs e)
        {
            bmp = new Bitmap(picture.Width, picture.Height);
            graph = Graphics.FromImage(bmp);
            picture.Image = null;
        }

        private void red_Click(object sender, EventArgs e)
        {
            pencolor = Color.Red;
        }

        private void green_Click(object sender, EventArgs e)
        {
            pencolor = Color.Green;
        }

        private void blue_Click(object sender, EventArgs e)
        {
            pencolor = Color.Blue;
        }

        private void yellow_Click(object sender, EventArgs e)
        {
            pencolor = Color.Yellow;
        }

        private void trackBar_Scroll(object sender, EventArgs e)
        {
           switch(trackBar.Value)
            {
                case 0:
                    pen_width = 0;
                    break;
                case 1:
                    pen_width = 3;
                    break;
                case 2:
                    pen_width = 5;
                    break;
                case 3:
                    pen_width = 6;
                    break;
                case 4:
                    pen_width = 8;
                    break;
            }
        }

        private void square_Click(object sender, EventArgs e)
        {
            name_tool = "square";
        }

        private void oval_Click(object sender, EventArgs e)
        {
            name_tool = "oval";
        }

        private void pen_Click(object sender, EventArgs e)
        {
            name_tool = "pencil";
        }

        private void picture_MouseUp(object sender, MouseEventArgs e)
        {
            towrite = false;
        }

        private void picture_MouseDown(object sender, MouseEventArgs e)
        {
            towrite = true;
            point_x = e.X;
            point_y = e.Y;
        }

        private void picture_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {


                pen1 = new Pen(pencolor, pen_width);
                switch (name_tool) {
                    case "pencil":              
                        pencil1.draw(pen1, graph, point_x, point_y, e.X, e.Y);
                        point_x = e.X;
                        point_y = e.Y;
                        break;
                    case "square":
                        
                        graph.FillRectangle(new SolidBrush(Color.Red), point_x, point_y, e.X - point_x, e.Y - point_y);
                        
                        // square1.draw(pen1, graph, point_x, point_y, e.X - point_x, e.Y - point_y);

                        
                        break;




                }
                
                picture.Image = bmp;
                pen1.Dispose();
            } else 
             if (e.Button == MouseButtons.Right)
             {
                pen1 = new Pen(Color.White, pen_width);
                pencil1.draw(pen1, graph, point_x, point_y, e.X, e.Y);
                point_x = e.X;
                point_y = e.Y;
                picture.Image = bmp;
                pen1.Dispose();
             }
            

        }

    }

}
