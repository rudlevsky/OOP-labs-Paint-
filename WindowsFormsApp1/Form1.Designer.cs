namespace WindowsFormsApp1
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
            this.picture = new System.Windows.Forms.PictureBox();
            this.clear = new System.Windows.Forms.Button();
            this.red = new System.Windows.Forms.Label();
            this.green = new System.Windows.Forms.Label();
            this.blue = new System.Windows.Forms.Label();
            this.yellow = new System.Windows.Forms.Label();
            this.pen = new System.Windows.Forms.PictureBox();
            this.trackBar = new System.Windows.Forms.TrackBar();
            this.square = new System.Windows.Forms.PictureBox();
            this.oval = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.picture)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pen)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.square)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.oval)).BeginInit();
            this.SuspendLayout();
            // 
            // picture
            // 
            this.picture.BackColor = System.Drawing.Color.White;
            this.picture.Location = new System.Drawing.Point(31, 29);
            this.picture.Name = "picture";
            this.picture.Size = new System.Drawing.Size(671, 495);
            this.picture.TabIndex = 0;
            this.picture.TabStop = false;
            this.picture.MouseDown += new System.Windows.Forms.MouseEventHandler(this.picture_MouseDown);
            this.picture.MouseMove += new System.Windows.Forms.MouseEventHandler(this.picture_MouseMove);
            this.picture.MouseUp += new System.Windows.Forms.MouseEventHandler(this.picture_MouseUp);
            // 
            // clear
            // 
            this.clear.Location = new System.Drawing.Point(732, 338);
            this.clear.Name = "clear";
            this.clear.Size = new System.Drawing.Size(109, 31);
            this.clear.TabIndex = 2;
            this.clear.Text = "Clean";
            this.clear.UseVisualStyleBackColor = true;
            this.clear.Click += new System.EventHandler(this.clear_Click);
            // 
            // red
            // 
            this.red.BackColor = System.Drawing.Color.Red;
            this.red.Location = new System.Drawing.Point(817, 175);
            this.red.Name = "red";
            this.red.Size = new System.Drawing.Size(24, 23);
            this.red.TabIndex = 3;
            this.red.Click += new System.EventHandler(this.red_Click);
            // 
            // green
            // 
            this.green.BackColor = System.Drawing.Color.Green;
            this.green.Location = new System.Drawing.Point(817, 214);
            this.green.Name = "green";
            this.green.Size = new System.Drawing.Size(24, 23);
            this.green.TabIndex = 4;
            this.green.Click += new System.EventHandler(this.green_Click);
            // 
            // blue
            // 
            this.blue.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.blue.Location = new System.Drawing.Point(817, 254);
            this.blue.Name = "blue";
            this.blue.Size = new System.Drawing.Size(24, 23);
            this.blue.TabIndex = 5;
            this.blue.Click += new System.EventHandler(this.blue_Click);
            // 
            // yellow
            // 
            this.yellow.BackColor = System.Drawing.Color.Yellow;
            this.yellow.Location = new System.Drawing.Point(817, 295);
            this.yellow.Name = "yellow";
            this.yellow.Size = new System.Drawing.Size(24, 23);
            this.yellow.TabIndex = 6;
            this.yellow.Click += new System.EventHandler(this.yellow_Click);
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
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(867, 548);
            this.Controls.Add(this.oval);
            this.Controls.Add(this.square);
            this.Controls.Add(this.trackBar);
            this.Controls.Add(this.pen);
            this.Controls.Add(this.yellow);
            this.Controls.Add(this.blue);
            this.Controls.Add(this.green);
            this.Controls.Add(this.red);
            this.Controls.Add(this.clear);
            this.Controls.Add(this.picture);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form1";
            this.ShowIcon = false;
            this.Text = "Drawing";
            ((System.ComponentModel.ISupportInitialize)(this.picture)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pen)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.square)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.oval)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox picture;
        private System.Windows.Forms.Button clear;
        private System.Windows.Forms.Label red;
        private System.Windows.Forms.Label green;
        private System.Windows.Forms.Label blue;
        private System.Windows.Forms.Label yellow;
        private System.Windows.Forms.PictureBox pen;
        private System.Windows.Forms.TrackBar trackBar;
        private System.Windows.Forms.PictureBox square;
        private System.Windows.Forms.PictureBox oval;
    }
}

