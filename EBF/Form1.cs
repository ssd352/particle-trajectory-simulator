// Copyright (c) 2011 SS D
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Drawing2D;

namespace EBF
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        PaintEventArgs pe;
        private void Form1_Load(object sender, EventArgs e)
        {
            pictureBox1.Size = new Size(this.Width-360, this.Height);
            textBox1.Location = new Point(this.Width - 300, textBox1.Location.Y);
            textBox2.Location = new Point(this.Width - 300, textBox2.Location.Y);
            textBox3.Location = new Point(this.Width - 300, textBox3.Location.Y);
            textBox4.Location = new Point(this.Width - 300, textBox4.Location.Y);
            textBox5.Location = new Point(this.Width - 300, textBox5.Location.Y);
            textBox6.Location = new Point(this.Width - 300, textBox6.Location.Y);
            textBox7.Location = new Point(this.Width - 300, textBox7.Location.Y);
            textBox8.Location = new Point(this.Width - 300, textBox8.Location.Y);
            label1.Location = new Point(this.Width - 350, label1.Location.Y);
            label2.Location = new Point(this.Width - 350, label2.Location.Y);
            label3.Location = new Point(this.Width - 350, label3.Location.Y);
            label4.Location = new Point(this.Width - 350, label4.Location.Y);
            label5.Location = new Point(this.Width - 350, label5.Location.Y);
            label6.Location = new Point(this.Width - 350, label6.Location.Y);
            label11.Location = new Point(this.Width - 350, label11.Location.Y);
            label13.Location = new Point(this.Width - 350, label13.Location.Y);
            comboBox1.Location = new Point(this.Width - 140, comboBox1.Location.Y);
            comboBox2.Location = new Point(this.Width - 140, comboBox2.Location.Y);
            comboBox3.Location = new Point(this.Width - 140, comboBox3.Location.Y);
            comboBox4.Location = new Point(this.Width - 140, comboBox4.Location.Y);
            comboBox5.Location = new Point(this.Width - 140, comboBox5.Location.Y);
            label12.Location=new Point(this.Width - 140, label12.Location.Y);
            label14.Location = new Point(this.Width - 140, label14.Location.Y);
            label8.Location = new Point(this.Width - 140, label8.Location.Y);
            button1.Location = new Point(this.Width-250,button1.Location.Y);
            button2.Location = new Point(this.Width-190,button2.Location.Y);
            button3.Location = new Point(this.Width - 340, button3.Location.Y);
            button4.Location = new Point(this.Width - 340, button4.Location.Y);
            checkBox1.Location = new Point(this.Width-240,checkBox1.Location.Y);
            comboBox1.SelectedIndex = 0;
            comboBox2.SelectedIndex = 0;
            comboBox3.SelectedIndex = 0;
            comboBox4.SelectedIndex = 0;
            comboBox5.SelectedIndex = 0;
            c = new Color();
            c = Color.Blue;
        }
        Graphics gr;
        class ldg : Exception
        {
            ///is thrown when L or D are too great    
        }
        class v0m : Exception
        {
            ///is thrown when v0 is < 0
        }
        class ldm : Exception
        {
            ///is thrown when L or D are negative
        }
        class ni : Exception
        {
            ///is thrown when charge is not an integer multiple of e
        }
        Color c;
        double ax, ay, x0, y0,y1, x1,l,d,g,b,ef,dt,vmax,q,m,sca,v0,vx,vy;
        Bitmap sav;
        Graphics bg;
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                sav = new Bitmap(pictureBox1.Width, pictureBox1.Height-75);
                bg = Graphics.FromImage(sav);
                gr = pictureBox1.CreateGraphics();
                bg.Clear(Color.White);
                gr.Clear(pictureBox1.BackColor);
                gr.SmoothingMode = SmoothingMode.AntiAlias;
                Draw(pictureBox1.CreateGraphics());
                first = false;
            }
            catch (FormatException)
            {
                MessageBox.Show("Invalid Input(s)", "Error");
            }
            catch (ArgumentOutOfRangeException)
            {
                MessageBox.Show("Input Number too Great", "Error");
            }
            catch (OverflowException)
            {
                MessageBox.Show("Irrelevant Inputs", "Error");

            }
            catch (ldg)
            {
                MessageBox.Show("L or D too great to fit into the screen", "Error");
            }
            catch (ldm)
            {
                MessageBox.Show("L & D should be Positive", "Error");
            }
            catch (ni)
            {
                MessageBox.Show("Charge should be an integer multiple of the charge of proton", "Error");
            }
            catch (v0m)
            {
                MessageBox.Show("V0 should be Positive", "Error");
            }
        }
        private void button2_Click(object sender, EventArgs e)
        { 
            saveFileDialog1.FileName = "";
            saveFileDialog1.Filter = "JPEG Image (*.jpg)|*.jpg|Bitmap Image (*.bmp)|*.bmp|GIF Image (*.gif)|*.gif";
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    sav.Save(saveFileDialog1.FileName);
                }
                catch (NullReferenceException)
                {
                    MessageBox.Show("Nothing to save", "Error");
                }            
            }
        }
        private void Draw(Graphics gt)
        {
            v0 = Convert.ToDouble(textBox6.Text); vx = 0; vy = 0;
            if (v0 < 0)
                throw new v0m();
             ax = 0; ay = 0;
             x0 = 0; y0 = 0; x1 = 0;y1 = 0;
             l = Convert.ToDouble(textBox3.Text); d = Convert.ToDouble(textBox4.Text); g = 9.8; q = Convert.ToDouble(textBox5.Text); m = Convert.ToDouble(textBox7.Text); b = Convert.ToDouble(textBox1.Text); ef = Convert.ToDouble(textBox2.Text); sca = Convert.ToDouble(textBox8.Text);
            switch (comboBox1.SelectedIndex)
            {
                case 0:
                    q *= 1e-6;
                    break;
                case 1:
                    if ((int)(q) != q)
                        throw new ni();
                    q *= 1.6e-19;
                    break;
            }
            switch (comboBox2.SelectedIndex)
            {
                case 0:
                    m *= 1e-6;
                    break;
                case 1:
                    m *= 9.11e-31;
                    break;
                case 2:
                    m *= 1.675e-27;
                    break;
                case 3:
                    m *= 1e-3;
                    break;
                case 4:
                    m *= 1e-9;
                    break;
            }
            switch (comboBox3.SelectedIndex)
            {
                case 1:
                    b *= 1e-4;
                    break;
            }
            if (l < 0 || d < 0)
                throw new ldm();
            switch (comboBox4.SelectedIndex)
            {
                case 1:
                    l *= 1e-2;
                    break;
            }
            switch (comboBox5.SelectedIndex)
            {
                case 1:
                    d *= 1e-2;
                    break;
            }
            if (checkBox1.Checked)
                vmax = Math.Sqrt(2 * (Math.Abs(q * ef) * pictureBox1.Height /2.0/ sca + m * v0 * v0 / 2.0 + m * g * pictureBox1.Height /2.0/ sca) / m);
            else
                vmax = Math.Sqrt(2 * (Math.Abs(q * ef) * pictureBox1.Height /2.0/ sca + m * v0 * v0 / 2.0) / m);
            double amax;
            if (checkBox1.Checked)
                amax = (Math.Abs(q) * vmax * b + Math.Abs(q * ef) + m * g) / m;
            else
                amax = (Math.Abs(q) * vmax * b + Math.Abs(q * ef)) / m;
            if (amax != 0)
                dt = (Math.Sqrt(vmax * vmax + 2 * amax / sca) - vmax) / amax;
            else
                dt = 1 / sca / vmax;
            if (dt == 0)
                throw new OverflowException();
            //dt /= 10000.0;
            vx = v0;
            PointF pf1 = new PointF((float)(l * sca), 0);
            PointF pf2 = new PointF((float)(l * sca), pictureBox1.Height - 90);
            PointF pf3 = new PointF((float)((l + d) * sca), pictureBox1.Height / 2);
            Point p1 = new Point((int)(l * sca), 0);
            if ((l + d) * sca > pictureBox1.Width || l * sca > pictureBox1.Width)
                throw new ldg();
            if (l <= 0 || d <= 0)
                throw new ldm();
            gt.DrawLine(new Pen(Color.Black), (int)(l * sca), 0, (int)(l * sca), pictureBox1.Height);
            bg.DrawLine(new Pen(Color.Black), (int)(l * sca), 0, (int)(l * sca), pictureBox1.Height);
            gt.DrawString("No Field Zone", new Font("Tahoma", label1.Font.Size, FontStyle.Regular), new SolidBrush(Color.Black), pf1);
            bg.DrawString("No Field Zone", new Font("Tahoma", label1.Font.Size, FontStyle.Regular), new SolidBrush(Color.Black), pf1);
            gt.DrawLine(new Pen(Color.Black), (int)((l + d) * sca), 0, (int)((l + d) * sca), pictureBox1.Height);
            bg.DrawLine(new Pen(Color.Black), (int)((l + d) * sca), 0, (int)((l + d) * sca), pictureBox1.Height);
            gt.DrawString("No Field Zone", new Font("Tahoma", label1.Font.Size, FontStyle.Regular), new SolidBrush(Color.Black), pf2);
            bg.DrawString("No Field Zone", new Font("Tahoma", label1.Font.Size, FontStyle.Regular), new SolidBrush(Color.Black), pf2);
            gt.DrawString("Fluorescent Substance", new Font("Tahoma", label1.Font.Size, FontStyle.Regular), new SolidBrush(Color.Black), pf3);
            bg.DrawString("Fluorescent Substance", new Font("Tahoma", label1.Font.Size, FontStyle.Regular), new SolidBrush(Color.Black), pf3);
            while (x1 + vx * dt <= l && Math.Abs((y1 + vy * dt) * sca) <= pictureBox1.Height / 2 && x1 + vx * dt >= 0 && (x1 + vx * dt) * sca <= pictureBox1.Width)
            {
                x1 = vx * dt + x0;
                y1 = vy * dt + y0;
                if ((int)(x1 * sca) != (int)(x0 * sca) || (int)(pictureBox1.Height / 2 - y1 * sca) != (int)(pictureBox1.Height / 2 - y0 * sca))
                {
                    gt.DrawLine(new Pen(c), (int)(x1 * sca), (int)(pictureBox1.Height / 2 - y1 * sca), (int)(x0 * sca), (int)(pictureBox1.Height / 2 - y0 * sca));
                    bg.DrawLine(new Pen(c), (int)(x1 * sca), (int)(pictureBox1.Height / 2 - y1 * sca), (int)(x0 * sca), (int)(pictureBox1.Height / 2 - y0 * sca));
                }
                ax = -q * b * vy / m;
                if (checkBox1.Checked)
                    ay = (-q * ef + q * b * vx - m * g) / m;
                else
                    ay = (-q * ef + q * b * vx) / m;
                vx += ax * dt;
                vy += ay * dt;
                x0 = x1;
                y0 = y1;
            }
            while (x1 + vx * dt >= l && x1 + vx * dt <= l + d && Math.Abs((y1 + vy * dt) * sca) <= pictureBox1.Height / 2 && x1 + vx * dt >= 0 && (x1 + vx * dt) * sca <= pictureBox1.Width)
            {
                x1 = vx * dt + x0;
                y1 = vy * dt + y0;
                if (checkBox1.Checked)
                {
                    ay = -g;
                    vy = ay * dt + vy;
                }
                if ((int)(x1 * sca) != (int)(x0 * sca) || (int)(pictureBox1.Height / 2 - y1 * sca) != (int)(pictureBox1.Height / 2 - y0 * sca))
                {
                    gt.DrawLine(new Pen(c), (int)(x1 * sca), (int)(pictureBox1.Height / 2 - y1 * sca), (int)(x0 * sca), (int)(pictureBox1.Height / 2 - y0 * sca));
                    bg.DrawLine(new Pen(c), (int)(x1 * sca), (int)(pictureBox1.Height / 2 - y1 * sca), (int)(x0 * sca), (int)(pictureBox1.Height / 2 - y0 * sca));
                }
                x0 = x1;
                y0 = y1;
            }
            gr = gt;
        }       
        private void button3_Click(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() == DialogResult.OK)
                c = colorDialog1.Color;
        }
        private void button4_Click(object sender, EventArgs e)
        {
            Random rnd = new Random();
            c = Color.FromArgb(255, rnd.Next(255), rnd.Next(255), rnd.Next(255));
        }
        bool first = true;
        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            if (!first)
            Draw(e.Graphics);
        }
    }
}
