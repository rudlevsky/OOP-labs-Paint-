using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.Serialization.Json;
using System.Runtime.Serialization;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        Bitmap bmp, tempDraw;
        Pen pen1;
        Line line1;
        Square square1;
        Ellipse ellipse1;
        Triangle triangle1;
        Color pencolor;
        List<BitSaver> lenta;
        Serializer serializer1;
        BitSaver BitSave;

        private bool mouseDown = false;
        private int pen_width;
        private string name_tool;
        private readonly byte[] mas = {0, 3, 5, 6, 8};
        private int stack = 0;
        private byte count = 3;

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
            triangle1 = new Triangle();
            pencolor = Color.Red;
            serializer1 = new Serializer();
            lenta = new List<BitSaver>();
        }

        //Очистка поля для рисования
        private void clear_Click(object sender, EventArgs e)
        {
            bmp.Dispose();
            bmp = new Bitmap(picture.Width, picture.Height);

        }

        //Выбор ширины для рисования
        private void trackBar_Scroll(object sender, EventArgs e)
        {
           switch(trackBar.Value)
           {
                case 0:
                    pen_width = mas[0];
                    break;
                case 1:
                    pen_width = mas[1];
                    break;
                case 2:
                    pen_width = mas[2];
                    break;
                case 3:
                    pen_width = mas[3];
                    break;
                case 4:
                    pen_width = mas[4];
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

        private void triangle_Click(object sender, EventArgs e)
        {
            name_tool = "triangle";
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
                    case "triangle":
                        if (tempDraw != null)
                        {
                            tempDraw = (Bitmap)bmp.Clone();
                            Graphics graph = Graphics.FromImage(tempDraw);
                            pen1 = new Pen(pencolor, pen_width);
                            triangle1.draw(pen1, graph);
                            e.Graphics.DrawImageUnscaled(tempDraw, 0, 0);
                        }
                        break;
                }
        }

        private void picture_MouseUp(object sender, MouseEventArgs e)
        {
            mouseDown = false;
            if (count == 3)
            {
                bmp = (Bitmap)tempDraw.Clone();                       //Новое изображение сохраняется в текущее
                BitSave = new BitSaver();
                BitSave.to_set(bmp);
                lenta.Add(BitSave);
                stack = lenta.Count;
            }
            else
                count++;

            if (count == 2)
            {
                if (stack < lenta.Count)
                {
                    bmp = (Bitmap)tempDraw.Clone();                       //Новое изображение сохраняется в текущее
                    BitSave = new BitSaver();
                    BitSave.to_set(bmp);

                    for (int i = lenta.Count - 1; i > stack; i--)
                    {
                        lenta.RemoveAt(i);
                    }
                    lenta.Add(BitSave);
                }
                count++;
            }
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
                    case "triangle":
                        triangle1.point_x1 = e.X;
                        triangle1.point_y1 = e.Y;
                        break;
                }
            }
            tempDraw = (Bitmap)bmp.Clone();
        }

        private void btn_serialize_Click(object sender, EventArgs e)
        {
            SaveFileDialog dlg = new SaveFileDialog()
            {
                Filter = "JSON files | *.json",
                FileName = "file.json"
            };
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                serializer1.to_Serialize(dlg.FileName, lenta);
            }
            dlg.Dispose();
        }

        private void btn_Deserializer_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog()
            {
                Filter = "JSON files | *.json"
            };
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                lenta.Clear();
                lenta = serializer1.Deserialize(dlg.FileName);
                bmp.Dispose();
                bmp = new Bitmap(picture.Width, picture.Height);
                bmp = (Bitmap)lenta[lenta.Count-1].to_get().Clone();
                stack = lenta.Count;
            }
            dlg.Dispose();
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Z)
            {
                if (stack != 1)
                {
                    stack--;
                    bmp.Dispose();
                    bmp = new Bitmap(picture.Width, picture.Height);
                    bmp = (Bitmap)lenta[stack - 1].to_get().Clone();
                    count = 0;
                }
            }

            if (e.KeyData == Keys.Y)
            {
                if (stack != lenta.Count)
                {
                    stack++;
                    bmp.Dispose();
                    bmp = new Bitmap(picture.Width, picture.Height);
                    bmp = (Bitmap)lenta[stack - 1].to_get().Clone();
                    count = 0;
                }
            }
        }

        //Присваиваются координаты последующей позиции
        private void picture_MouseMove(object sender, MouseEventArgs e)
        {
            if (mouseDown)
            {
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
                        case "triangle":
                            triangle1.point_x2 = e.X;
                            triangle1.point_y2 = e.Y;
                            break;
                    }
                }
                picture.Refresh();
            }
        }

    }
}
