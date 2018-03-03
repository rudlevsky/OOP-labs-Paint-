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
        Bitmap bmp, tempDraw;
        Graphics graph;
        Pen pen1;
        Line line1;
        Square square1;
        Ellipse ellipse1;
        Color pencolor;

        bool mouseDown = false;
        private int pen_width;
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
            line1 = new Line();
            square1 = new Square();
            ellipse1 = new Ellipse();
            pencolor = Color.Red;
        }

        //Очистка поля для рисования
        private void clear_Click(object sender, EventArgs e)
        {
            bmp = new Bitmap(picture.Width, picture.Height);
        }

        //Выбор ширины для рисования
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
            name_tool = "pen";
        }

        private void line_Click(object sender, EventArgs e)
        {
            name_tool = "line";
        }

        //Выбор цвета элементов
        private void change_Click(object sender, EventArgs e)
        {
            ColorDialog clr = new ColorDialog();
            if (clr.ShowDialog() == DialogResult.OK)
                pencolor = clr.Color;
        }

        private void picture_Paint(object sender, PaintEventArgs e)
        {
                switch (name_tool)
                {
                    case "line":
                        if (tempDraw != null)
                        {
                            tempDraw = (Bitmap)bmp.Clone();                    //Копирует текущее изображение
                            Graphics graph = Graphics.FromImage(tempDraw);
                            pen1 = new Pen(pencolor, pen_width);
                            line1.draw(pen1, graph);
                            e.Graphics.DrawImageUnscaled(tempDraw, 0, 0);      //Рисует изображение
                        }
                        break;
                    case "pen":
                        if (tempDraw != null)
                        {
                            Graphics graph = Graphics.FromImage(tempDraw);
                            pen1 = new Pen(pencolor, pen_width);
                            line1.draw(pen1, graph);
                            e.Graphics.DrawImageUnscaled(tempDraw, 0, 0);
                            line1.point_x1 = line1.point_x2;
                            line1.point_y1 = line1.point_y2;
                        }
                        break;
                    case "oval":
                        if (tempDraw != null)
                        {
                            tempDraw = (Bitmap)bmp.Clone();
                            Graphics graph = Graphics.FromImage(tempDraw);
                            pen1 = new Pen(pencolor, pen_width);
                            ellipse1.draw(pen1, graph);
                            e.Graphics.DrawImageUnscaled(tempDraw, 0, 0);
                        }
                        break;
                    case "square":
                        if (tempDraw != null)
                        {
                            tempDraw = (Bitmap)bmp.Clone();
                            Graphics graph = Graphics.FromImage(tempDraw);
                            pen1 = new Pen(pencolor, pen_width);
                            square1.draw(pen1, graph);
                            e.Graphics.DrawImageUnscaled(tempDraw, 0, 0);
                        }
                        break;
                }
            
        }

        private void picture_MouseUp(object sender, MouseEventArgs e)
        {
            mouseDown = false;
            bmp = (Bitmap)tempDraw.Clone();                       //Новое изображение сохраняется в текущее
        }

        //Присваиваются координаты текущей позиции 
        private void picture_MouseDown(object sender, MouseEventArgs e)
        {
            mouseDown = true;

            if ((name_tool == "line") || (name_tool == "pen")) {
                line1.point_x1 = e.X;
                line1.point_y1 = e.Y;
            }
            else
            {
                switch (name_tool)
                {
                    case "oval":
                        ellipse1.point_x1 = e.X;
                        ellipse1.point_y1 = e.Y;
                        break;
                    case "square":
                        square1.point_x1 = e.X;
                        square1.point_y1 = e.Y;
                        break;
                }
            }
            tempDraw = (Bitmap)bmp.Clone();
        }
        
        //Присваиваются координаты последующей позиции
        private void picture_MouseMove(object sender, MouseEventArgs e)
        {
            if (mouseDown) {

                if ((name_tool == "line") || (name_tool =="pen")) {
                    line1.point_x2 = e.X;
                    line1.point_y2 = e.Y;
                }
                else
                {
                    switch (name_tool)
                    {
                         case "oval":
                            ellipse1.point_x2 = e.X; 
                            ellipse1.point_y2 = e.Y; 
                            break;
                        case "square":
                            square1.point_x2 = e.X;
                            square1.point_y2 = e.Y;
                            break;
                    }
                }
                picture.Refresh();
            }
        }

    }
}
