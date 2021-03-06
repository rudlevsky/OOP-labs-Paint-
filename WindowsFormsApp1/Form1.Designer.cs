﻿namespace WindowsFormsApp1
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.clear = new System.Windows.Forms.Button();
            this.pen = new System.Windows.Forms.PictureBox();
            this.trackBar = new System.Windows.Forms.TrackBar();
            this.square = new System.Windows.Forms.PictureBox();
            this.oval = new System.Windows.Forms.PictureBox();
            this.picture = new System.Windows.Forms.PictureBox();
            this.change = new System.Windows.Forms.Button();
            this.line = new System.Windows.Forms.PictureBox();
            this.triangle = new System.Windows.Forms.PictureBox();
            this.btn_serialize = new System.Windows.Forms.Button();
            this.saveFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.btn_Deserializer = new System.Windows.Forms.Button();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.radio_choose = new System.Windows.Forms.RadioButton();
            this.radio_paint = new System.Windows.Forms.RadioButton();
            ((System.ComponentModel.ISupportInitialize)(this.pen)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.square)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.oval)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picture)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.line)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.triangle)).BeginInit();
            this.SuspendLayout();
            // 
            // clear
            // 
            this.clear.Location = new System.Drawing.Point(732, 431);
            this.clear.Name = "clear";
            this.clear.Size = new System.Drawing.Size(109, 31);
            this.clear.TabIndex = 2;
            this.clear.Text = "Clear";
            this.clear.UseVisualStyleBackColor = true;
            this.clear.Click += new System.EventHandler(this.clear_Click);
            // 
            // pen
            // 
            this.pen.Image = ((System.Drawing.Image)(resources.GetObject("pen.Image")));
            this.pen.Location = new System.Drawing.Point(732, 175);
            this.pen.Name = "pen";
            this.pen.Size = new System.Drawing.Size(55, 47);
            this.pen.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pen.TabIndex = 7;
            this.pen.TabStop = false;
            this.pen.Click += new System.EventHandler(this.pen_Click);
            // 
            // trackBar
            // 
            this.trackBar.Location = new System.Drawing.Point(732, 113);
            this.trackBar.Maximum = 4;
            this.trackBar.Name = "trackBar";
            this.trackBar.Size = new System.Drawing.Size(109, 56);
            this.trackBar.TabIndex = 8;
            this.trackBar.Scroll += new System.EventHandler(this.trackBar_Scroll);
            // 
            // square
            // 
            this.square.Image = ((System.Drawing.Image)(resources.GetObject("square.Image")));
            this.square.Location = new System.Drawing.Point(732, 230);
            this.square.Name = "square";
            this.square.Size = new System.Drawing.Size(55, 47);
            this.square.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.square.TabIndex = 9;
            this.square.TabStop = false;
            this.square.Click += new System.EventHandler(this.square_Click);
            // 
            // oval
            // 
            this.oval.Image = ((System.Drawing.Image)(resources.GetObject("oval.Image")));
            this.oval.Location = new System.Drawing.Point(732, 283);
            this.oval.Name = "oval";
            this.oval.Size = new System.Drawing.Size(55, 47);
            this.oval.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.oval.TabIndex = 10;
            this.oval.TabStop = false;
            this.oval.Click += new System.EventHandler(this.oval_Click);
            // 
            // picture
            // 
            this.picture.BackColor = System.Drawing.Color.White;
            this.picture.Location = new System.Drawing.Point(31, 29);
            this.picture.Name = "picture";
            this.picture.Size = new System.Drawing.Size(671, 495);
            this.picture.TabIndex = 0;
            this.picture.TabStop = false;
            this.picture.Paint += new System.Windows.Forms.PaintEventHandler(this.picture_Paint);
            this.picture.MouseDown += new System.Windows.Forms.MouseEventHandler(this.picture_MouseDown);
            this.picture.MouseMove += new System.Windows.Forms.MouseEventHandler(this.picture_MouseMove);
            this.picture.MouseUp += new System.Windows.Forms.MouseEventHandler(this.picture_MouseUp);
            // 
            // change
            // 
            this.change.Location = new System.Drawing.Point(732, 392);
            this.change.Name = "change";
            this.change.Size = new System.Drawing.Size(109, 33);
            this.change.TabIndex = 11;
            this.change.Text = "Change color";
            this.change.UseVisualStyleBackColor = true;
            this.change.Click += new System.EventHandler(this.change_Click);
            // 
            // line
            // 
            this.line.Image = ((System.Drawing.Image)(resources.GetObject("line.Image")));
            this.line.Location = new System.Drawing.Point(800, 175);
            this.line.Name = "line";
            this.line.Size = new System.Drawing.Size(55, 47);
            this.line.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.line.TabIndex = 12;
            this.line.TabStop = false;
            this.line.Click += new System.EventHandler(this.line_Click);
            // 
            // triangle
            // 
            this.triangle.Image = ((System.Drawing.Image)(resources.GetObject("triangle.Image")));
            this.triangle.Location = new System.Drawing.Point(800, 230);
            this.triangle.Name = "triangle";
            this.triangle.Size = new System.Drawing.Size(55, 47);
            this.triangle.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.triangle.TabIndex = 13;
            this.triangle.TabStop = false;
            this.triangle.Click += new System.EventHandler(this.triangle_Click);
            // 
            // btn_serialize
            // 
            this.btn_serialize.Location = new System.Drawing.Point(732, 468);
            this.btn_serialize.Name = "btn_serialize";
            this.btn_serialize.Size = new System.Drawing.Size(109, 31);
            this.btn_serialize.TabIndex = 14;
            this.btn_serialize.Text = "Serialize";
            this.btn_serialize.UseVisualStyleBackColor = true;
            this.btn_serialize.Click += new System.EventHandler(this.btn_serialize_Click);
            // 
            // btn_Deserializer
            // 
            this.btn_Deserializer.Location = new System.Drawing.Point(732, 505);
            this.btn_Deserializer.Name = "btn_Deserializer";
            this.btn_Deserializer.Size = new System.Drawing.Size(109, 31);
            this.btn_Deserializer.TabIndex = 15;
            this.btn_Deserializer.Text = "Deserialize";
            this.btn_Deserializer.UseVisualStyleBackColor = true;
            this.btn_Deserializer.Click += new System.EventHandler(this.btn_Deserializer_Click);
            // 
            // openFileDialog
            // 
            this.openFileDialog.FileName = "openFileDialog1";
            // 
            // radio_choose
            // 
            this.radio_choose.AutoSize = true;
            this.radio_choose.Location = new System.Drawing.Point(732, 363);
            this.radio_choose.Name = "radio_choose";
            this.radio_choose.Size = new System.Drawing.Size(120, 21);
            this.radio_choose.TabIndex = 16;
            this.radio_choose.TabStop = true;
            this.radio_choose.Text = "Choose shape";
            this.radio_choose.UseVisualStyleBackColor = true;
            this.radio_choose.CheckedChanged += new System.EventHandler(this.radio_choose_CheckedChanged);
            // 
            // radio_paint
            // 
            this.radio_paint.AutoSize = true;
            this.radio_paint.Location = new System.Drawing.Point(732, 336);
            this.radio_paint.Name = "radio_paint";
            this.radio_paint.Size = new System.Drawing.Size(61, 21);
            this.radio_paint.TabIndex = 17;
            this.radio_paint.TabStop = true;
            this.radio_paint.Text = "Paint";
            this.radio_paint.UseVisualStyleBackColor = true;
            this.radio_paint.CheckedChanged += new System.EventHandler(this.radio_paint_CheckedChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(867, 548);
            this.Controls.Add(this.radio_paint);
            this.Controls.Add(this.radio_choose);
            this.Controls.Add(this.btn_Deserializer);
            this.Controls.Add(this.btn_serialize);
            this.Controls.Add(this.triangle);
            this.Controls.Add(this.line);
            this.Controls.Add(this.change);
            this.Controls.Add(this.oval);
            this.Controls.Add(this.square);
            this.Controls.Add(this.trackBar);
            this.Controls.Add(this.pen);
            this.Controls.Add(this.clear);
            this.Controls.Add(this.picture);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.ShowIcon = false;
            this.Text = "Drawing";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.pen)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.square)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.oval)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picture)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.line)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.triangle)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button clear;
        private System.Windows.Forms.PictureBox pen;
        private System.Windows.Forms.TrackBar trackBar;
        private System.Windows.Forms.PictureBox square;
        private System.Windows.Forms.PictureBox oval;
        private System.Windows.Forms.PictureBox picture;
        private System.Windows.Forms.Button change;
        private System.Windows.Forms.PictureBox line;
        private System.Windows.Forms.PictureBox triangle;
        private System.Windows.Forms.Button btn_serialize;
        private System.Windows.Forms.SaveFileDialog saveFileDialog;
        private System.Windows.Forms.Button btn_Deserializer;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.RadioButton radio_choose;
        private System.Windows.Forms.RadioButton radio_paint;
    }
}

