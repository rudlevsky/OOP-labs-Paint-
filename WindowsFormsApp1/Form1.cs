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
        Color pencolor;
        Figures figure;
        Factory factory;                              // factory of types
        List<Figures> flenta = new List<Figures>();   // stack of all objects
        Serializer serializer1 = Serializer.get();    // gets an object (singleton)

        private Type[] types = new Type[]             // types for serialization
        {
            typeof(Pens),
            typeof(Line),
            typeof(Ellipse),
            typeof(Square),
            typeof(Triangle),
            typeof(Figures)
        };

        private bool mouseDown = false, flag_xy = false;
        private int pen_width;
        private string name_tool;
        private readonly byte[] mas = { 0, 3, 5, 6, 8 };
        private int stack = 0;
        private int obj_selected = -1;
        private int count = -2;
        private string[] img_names = { "pen.png","l.png","pr.png","oval.png","Triangle.png" };

        public Form1()
        {
            InitializeComponent();
            pencolor = Color.Red;
            bmp = new Bitmap(picture.Width, picture.Height);
            radio_paint.Checked = true;
            name_tool = "pen";
        }

        // clears a bitmap
        public void clean_btmp()
        {
            Graphics graph = Graphics.FromImage(bmp);
            graph.Clear(Color.White);
            picture.Image = bmp;
            tempDraw = null;
            graph.Dispose();
        }

        private void clear_Click(object sender, EventArgs e)
        {
            clean_btmp();
            flenta[stack-1].flag_clean = true;
        }

        // choose a width for a pen
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

        // chooses a color of an object
        private void change_Click(object sender, EventArgs e)
        {
            if (radio_paint.Checked)
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
            if (radio_paint.Checked && (tempDraw != null))
            {
                if (name_tool != "pen")
                {
                    tempDraw = (Bitmap)bmp.Clone();                // copy current bitmap
                }
               
                Graphics graph = Graphics.FromImage(tempDraw);
                pen1 = new Pen(pencolor, pen_width);
                figure.draw(pen1, graph);
                e.Graphics.DrawImageUnscaled(tempDraw, 0, 0);      // paint an image     

                if (name_tool == "pen")
                {
                    figure.point_x1 = figure.point_x2;
                    figure.point_y1 = figure.point_y2;
                }
            }
        }

        private void picture_MouseUp(object sender, MouseEventArgs e)
        {
            if (radio_paint.Checked)
            {
                mouseDown = false;            
                bmp = (Bitmap)tempDraw.Clone();

                if (flag_xy)
                {
                    if (stack < flenta.Count)
                    {    
                        for (int i = flenta.Count - 1; i > stack - 1; i--)
                        {
                            flenta.RemoveAt(i);
                        }
                    }
                    flag_xy = false;
                }
                flenta.Add(figure);
                stack = flenta.Count;
            }
        }

        // just changes parameters 
        private void change_count(int i, ref bool flag)
        {
            obj_selected = i;
            clean_btns();

            flag = true;

            if (count == i)
            {
                count = -1;
            }
            else
            {
                count = i;
            }
        }

        // takes coordinates of the position
        private void picture_MouseDown(object sender, MouseEventArgs e)
        {
            if (radio_paint.Checked)
            {
                mouseDown = true;
                switch (name_tool)
                {
                    case "pen":
                        factory = new FPens();
                        figure = factory.Create();
                        break;
                    case "line":
                        factory = new FLine();
                        figure = factory.Create();
                        break;
                    case "oval":
                        factory = new FEllipse();
                        figure = factory.Create();
                        break;
                    case "square":
                        factory = new FSquare();
                        figure = factory.Create();
                        break;
                    case "triangle":
                        factory = new FTriangle();
                        figure = factory.Create();
                        break;
                }
                figure.pcolor = pencolor;
                figure.pen_wid = pen_width;
                figure.point_x1 = e.X;
                figure.point_y1 = e.Y;
                tempDraw = (Bitmap)bmp.Clone();
            }
            else
            {
                bool flag = false;

                if (count == -1)
                {
                    count = -2;
                }

                // finds a nessesary object
                for (int i = 0; i < stack; i++)
                {
                    if (typeof(ISelected).IsAssignableFrom(flenta[i].GetType()))
                    {                  
                        try
                        {
                            if (typeof(Pens) == flenta[i].GetType())
                            {
                                if ((flenta[i] as Pens).check_coords(e.X, e.Y))
                                {
                                    change_count(i, ref flag);
                                    pen.Load("pen_r.png");
                                }
                            }

                            if (typeof(Square) == flenta[i].GetType())
                            {
                                if ((flenta[i] as Square).check_coords(e.X, e.Y))
                                {
                                    change_count(i, ref flag);
                                    square.Load("pr_r.png");
                                }
                            }

                            if (typeof(Line) == flenta[i].GetType())
                            {
                                if ((flenta[i] as Line).check_coords(e.X, e.Y))
                                {
                                    change_count(i, ref flag);
                                    line.Load("l_r.png");
                                }
                            }

                            if (typeof(Triangle) == flenta[i].GetType())
                            {
                                if ((flenta[i] as Triangle).check_coords(e.X, e.Y))
                                {
                                    change_count(i, ref flag);
                                    triangle.Load("Triangle_r.png");
                                }
                            }

                            if (typeof(Ellipse) == flenta[i].GetType())
                            {
                                if ((flenta[i] as Ellipse).check_coords(e.X, e.Y))
                                {
                                    change_count(i, ref flag);
                                    oval.Load("oval_r.png");
                                }
                            }
                        }
                        catch
                        {
                            MessageBox.Show("Image was not found. Reinstall the program.");
                            Environment.Exit(0);
                        }

                    }
                }

                if (!flag)
                {
                    count = -2;
                    obj_selected = -1;
                    clean_btns();
                }
            }
        }

        // clears all buttons by default
        private void clean_btns()
        {
            try
            {
                pen.Load(img_names[0]);
                line.Load(img_names[1]);
                square.Load(img_names[2]);
                oval.Load(img_names[3]);
                triangle.Load(img_names[4]);
            }
            catch
            {
                MessageBox.Show("Image was not found. Reinstall the program.");
                Environment.Exit(0);
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
                try
                {
                    serializer1.to_Serialize(dlg.FileName, flenta, types);
                }
                catch
                {
                    MessageBox.Show("File can't be saved");
                }
                finally
                {
                    dlg.Dispose();
                }
            }
        }

        // draws all objects from stack
        private void to_write(List<Figures> flenta, int stack)
        {
            bmp.Dispose();
            bmp = new Bitmap(picture.Width, picture.Height);
            for (int i = 0; i < stack; i++)
            {
                if (i > 1)
                {
                    if (flenta[i - 1].flag_clean)
                    {
                        clean_btmp();
                    }
                }
                Graphics graph = Graphics.FromImage(bmp);
                pen1 = new Pen(flenta[i].pcolor, flenta[i].pen_wid);
                flenta[i].auto_draw(pen1,graph);
            }
            picture.Image = bmp;
            tempDraw = null;
        }

        private void btn_Deserializer_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog()
            {
                Filter = "JSON files | *.json"
            };
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                var flenta_save = new List<Figures>();
                flenta_save = flenta;
                try
                {
                    flenta = serializer1.Deserialize(dlg.FileName, types);
                }
                catch
                {
                    MessageBox.Show("File can't be read");
                    flenta = flenta_save;
                    dlg.Dispose();
                    return;
                }
                finally
                {
                    stack = flenta.Count;
                    to_write(flenta, stack);
                    dlg.Dispose();
                }
            }
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if ((e.KeyData == Keys.Z) && (radio_paint.Checked))
            {
                if (stack != 1)
                {
                    stack--;
                    to_write(flenta, stack);
                    flag_xy = true;
                }
            }

            if ((e.KeyData == Keys.Y) && (radio_paint.Checked))
            {
                if (stack != flenta.Count)
                {
                    stack++;
                    to_write(flenta, stack);
                    flag_xy = true;
                }
            }

            if (obj_selected != -1)
            {
                // changes a size of an object
                if (typeof(IEdited).IsAssignableFrom(flenta[obj_selected].GetType()))
                {
                    if ((e.KeyData == Keys.NumPad2) || (e.KeyData == Keys.NumPad4) 
                        || (e.KeyData == Keys.NumPad6) || (e.KeyData == Keys.NumPad8))
                    {
                        string key_name = "";

                        switch (e.KeyData)
                        {
                            case Keys.NumPad2:
                                key_name = "num_2";
                                break;
                            case Keys.NumPad4:
                                key_name = "num_4";
                                break;
                            case Keys.NumPad6:
                                key_name = "num_6";
                                break;
                            case Keys.NumPad8:
                                key_name = "num_8";
                                break;
                        }

                        if (typeof(Pens) == flenta[obj_selected].GetType())
                        {
                            (flenta[obj_selected] as Pens).chng_size(key_name);
                        }

                        if (typeof(Square) == flenta[obj_selected].GetType())
                        {
                            (flenta[obj_selected] as Square).chng_size(key_name);
                        }

                        if (typeof(Line) == flenta[obj_selected].GetType())
                        {
                            (flenta[obj_selected] as Line).chng_size(key_name);
                        }

                        if (typeof(Triangle) == flenta[obj_selected].GetType())
                        {
                            (flenta[obj_selected] as Triangle).chng_size(key_name);
                        }

                        if (typeof(Ellipse) == flenta[obj_selected].GetType())
                        {
                            (flenta[obj_selected] as Ellipse).chng_size(key_name);
                        }

                        to_write(flenta, stack);
                    }
                }
            }
        }

        private void radio_paint_CheckedChanged(object sender, EventArgs e)
        {
            clean_btns();
            obj_selected = -1;
            count = -2;
            clear.Enabled = true;
        }

        private void radio_choose_CheckedChanged(object sender, EventArgs e)
        {
            clear.Enabled = false;
        }

        // coordinates assign to the next position
        private void picture_MouseMove(object sender, MouseEventArgs e)
        {
            if (radio_paint.Checked && mouseDown)
            {
                figure.point_x2 = e.X;
                figure.point_y2 = e.Y;
                picture.Refresh(); 
            }
            else
            {
                if (count == -1)
                {
                    // object rewrites while moving 
                    if (typeof(IEdited).IsAssignableFrom(flenta[obj_selected].GetType()))
                    {
                        if (typeof(Pens) == flenta[obj_selected].GetType())
                        {
                            (flenta[obj_selected] as Pens).rewrite(e.X, e.Y);
                        }

                        if (typeof(Square) == flenta[obj_selected].GetType())
                        {
                            (flenta[obj_selected] as Square).rewrite(e.X, e.Y);
                        }

                        if (typeof(Line) == flenta[obj_selected].GetType())
                        {
                            (flenta[obj_selected] as Line).rewrite(e.X, e.Y);
                        }

                        if (typeof(Triangle) == flenta[obj_selected].GetType())
                        {
                            (flenta[obj_selected] as Triangle).rewrite(e.X, e.Y);
                        }

                        if (typeof(Ellipse) == flenta[obj_selected].GetType())
                        {
                            (flenta[obj_selected] as Ellipse).rewrite(e.X, e.Y);
                        }

                        to_write(flenta, stack);
                    }             
                }
            }
        }

    }
}
