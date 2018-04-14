﻿using System;
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
        List<Figures> flenta = new List<Figures>();
        Serializer serializer1 = Serializer.get();
        Pens pens;
       // private static PaintEventArgs pEventArg = null;

        private Type[] types = new Type[]
        {
            typeof(Pens),
            typeof(Line),
            typeof(Ellipse),
            typeof(Square),
            typeof(Triangle),
            typeof(Figures)
        };

        private bool mouseDown = false;
        private int pen_width;
        private string name_tool;
        private readonly byte[] mas = { 0, 3, 5, 6, 8 };
        private int stack = 0;
        private byte count = 3;
        private bool choose_btn = false;
        private int obj_selected = -1;
        private string[] img_names = { "pen.png","l.png","pr.png","oval.png","Triangle.png" };

        public Form1()
        {
            InitializeComponent();
            pencolor = Color.Red;
            bmp = new Bitmap(picture.Width, picture.Height);
        }

        //Очистка поля для рисования
        private void clear_Click(object sender, EventArgs e)
        {
            bmp.Dispose();
            bmp = new Bitmap(picture.Width, picture.Height);
            count = 1;
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
            if (!choose_btn)
            {
                ColorDialog clr = new ColorDialog();
                if (clr.ShowDialog() == DialogResult.OK)
                {
                    pencolor = clr.Color;
                }
                clr.Dispose();
            }
            else
            {
                if (obj_selected != -1)
                {
                    if (typeof(IEdited).IsAssignableFrom(flenta[obj_selected].GetType()))
                    {
                        ColorDialog clr = new ColorDialog();
                        if (clr.ShowDialog() == DialogResult.OK)
                        {
                            flenta[obj_selected].pcolor = clr.Color;
                            to_write(flenta,stack);
                        }
                        clr.Dispose();
                    }
                }
            }
        }

        private void picture_Paint(object sender, PaintEventArgs e)
        {
            if (!choose_btn)
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
                            pens.draw(pen1, graph);
                            e.Graphics.DrawImageUnscaled(tempDraw, 0, 0);
                            pens.point_x1 = pens.point_x2;
                            pens.point_y1 = pens.point_y2;
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
              //  pEventArg = e;
            }
        }

        private void to_add(string name_tool)
        {
            switch (name_tool)
            {
                case "line":
                    flenta.Add(line1);
                    break;
                case "pen":
                    flenta.Add(pens);
                    break;
                case "oval":
                    flenta.Add(ellipse1);
                    break;
                case "square":
                    flenta.Add(square1);
                    break;
                case "triangle":
                    flenta.Add(triangle1);
                    break;
            }
        }

        private void picture_MouseUp(object sender, MouseEventArgs e)
        {
            if (!choose_btn)
            {
                mouseDown = false;
                if (count == 3)
                {
                    bmp = (Bitmap)tempDraw.Clone();
                    to_add(name_tool);
                    stack = flenta.Count;
                }
                else
                    count++;

                if (count == 2)
                {
                    if (stack < flenta.Count)
                    {
                        bmp = (Bitmap)tempDraw.Clone();                       //Новое изображение сохраняется в текущее
                        for (int i = flenta.Count - 1; i > stack - 1; i--)
                        {
                            flenta.RemoveAt(i);
                        }
                        to_add(name_tool);
                    }
                    count++;
                }
            }
        }

        //Присваиваются координаты текущей позиции 
        private void picture_MouseDown(object sender, MouseEventArgs e)
        {
            if (!choose_btn)
            {
                mouseDown = true;
                switch (name_tool)
                {
                    case "pen":
                        pens = new Pens();
                        pens.pcolor = pencolor;
                        pens.pen_wid = pen_width;
                        pens.point_x1 = e.X;
                        pens.point_y1 = e.Y;
                        break;
                    case "line":
                        line1 = new Line();
                        line1.pcolor = pencolor;
                        line1.pen_wid = pen_width;
                        line1.point_x1 = e.X;
                        line1.point_y1 = e.Y;
                        break;
                    case "oval":
                        ellipse1 = new Ellipse();
                        ellipse1.pcolor = pencolor;
                        ellipse1.pen_wid = pen_width;
                        ellipse1.point_x1 = e.X;
                        ellipse1.point_y1 = e.Y;
                        break;
                    case "square":
                        square1 = new Square();
                        square1.pcolor = pencolor;
                        square1.pen_wid = pen_width;
                        square1.point_x1 = e.X;
                        square1.point_y1 = e.Y;
                        break;
                    case "triangle":
                        triangle1 = new Triangle();
                        triangle1.pcolor = pencolor;
                        triangle1.pen_wid = pen_width;
                        triangle1.point_x1 = e.X;
                        triangle1.point_y1 = e.Y;
                        break;
                }
                tempDraw = (Bitmap)bmp.Clone();
            }
            else
            {
                bool flag = false;
                for (int i = 0; i < stack; i++)
                {
                    if (typeof(ISelected).IsAssignableFrom(flenta[i].GetType()))
                    {                  
                        if (typeof(Pens) == flenta[i].GetType())
                        {
                            if((flenta[i] as Pens).check_coords(e.X, e.Y))
                            {
                                obj_selected = i;
                                clean_btns();
                                pen.Load("pen_r.png");
                                flag = true;
                            }
                        }

                        if (typeof(Square) == flenta[i].GetType())
                        {
                            if ((flenta[i] as Square).check_coords(e.X, e.Y))
                            {
                                obj_selected = i;
                                clean_btns();
                                square.Load("pr_r.png");
                                flag = true;
                            }
                        }

                        if (typeof(Line) == flenta[i].GetType())
                        {
                            if ((flenta[i] as Line).check_coords(e.X, e.Y))
                            {
                                obj_selected = i;
                                clean_btns();
                                line.Load("l_r.png");
                                flag = true;
                            }
                        }

                        if (typeof(Triangle) == flenta[i].GetType())
                        {
                            if ((flenta[i] as Triangle).check_coords(e.X, e.Y))
                            {
                                obj_selected = i;
                                clean_btns();
                                triangle.Load("Triangle_r.png");
                                flag = true;
                            }
                        }

                        if (typeof(Ellipse) == flenta[i].GetType())
                        {
                            if ((flenta[i] as Ellipse).check_coords(e.X, e.Y))
                            {
                                obj_selected = i;
                                clean_btns();
                                oval.Load("oval_r.png");
                                flag = true;
                            }
                        }
                    }
                }

                if (!flag)
                {
                    obj_selected = -1;
                    clean_btns();
                }
            }
        }

        private void clean_btns()
        {
            for (int i = 0; i < img_names.Length; i++)
            {
                switch (i)
                {
                    case 0:
                        pen.Load(img_names[i]);
                        break;
                    case 1:
                        line.Load(img_names[i]);
                        break;
                    case 2:
                        square.Load(img_names[i]);
                        break;
                    case 3:
                        oval.Load(img_names[i]);
                        break;
                    case 4:
                        triangle.Load(img_names[i]);
                        break;
                }
            }
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
                serializer1.to_Serialize(dlg.FileName, flenta, types);
            }
            dlg.Dispose();
        }

        private void to_write(List<Figures> flenta, int stack)
        {
            bmp.Dispose();
            bmp = new Bitmap(picture.Width, picture.Height);
            for (int i=0; i<stack; i++)
            {
                Graphics graph = Graphics.FromImage(bmp);
                pen1 = new Pen(flenta[i].pcolor, flenta[i].pen_wid);
                flenta[i].auto_draw(pen1,graph);
            }
          
           // picture_Paint(this, );
        }

        private void btn_Deserializer_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog()
            {
                Filter = "JSON files | *.json"
            };
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                choose_btn = false;
                flenta.Clear();
                flenta = serializer1.Deserialize(dlg.FileName, types);
                stack = flenta.Count;
                to_write(flenta, stack);
              //  picture_Paint(this, pEventArg);
                count = 1;
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
                    to_write(flenta, stack);
                    count = 0;
                }
            }

            if (e.KeyData == Keys.Y)
            {
                if (stack != flenta.Count)
                {
                    stack++;
                    to_write(flenta, stack);
                    count = 0;
                }
            }
        }

        private void Choose_btn_Click(object sender, EventArgs e)
        {
            if (!choose_btn)
            {
                choose_btn = true;
            }
            else
            {
                choose_btn = false;
                clean_btns();
                obj_selected = -1;
            }
        }

        //Присваиваются координаты последующей позиции
        private void picture_MouseMove(object sender, MouseEventArgs e)
        {
            if (!choose_btn)
            {
                if (mouseDown)
                {
                    switch (name_tool)
                    {
                        case "pen":
                            pens.point_x2 = e.X;
                            pens.point_y2 = e.Y;
                            break;
                        case "line":
                            line1.point_x2 = e.X;
                            line1.point_y2 = e.Y;
                            break;
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
                    picture.Refresh();
                }
            }
        }

    }
}
