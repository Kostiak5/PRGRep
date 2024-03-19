using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace CalculatorRevisited
{
    public partial class CalculatorRevisited : Form
    {
        Graphics graphics;
        Bitmap bitmap;
        int x = -1, y = -1, x2 = -1, y2 = -1, xSt = -1, ySt = -1;
        int savedXSt = 10, savedYSt = 10, savedXEnd = 10, savedYEnd = 10;
        int drawingMode = 1;
        bool move = false;
        Pen pen, eraser;
        Brush brush;
        public CalculatorRevisited()
        {
            InitializeComponent();
            this.Width = 900;
            this.Height = 900;
            bitmap = new Bitmap(box.Width, box.Height);
            graphics = Graphics.FromImage(bitmap);
            graphics.Clear(Color.White);
            box.Image = bitmap;

            graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

            pen = new Pen(Color.Black, 5);
            pen.StartCap = pen.EndCap = System.Drawing.Drawing2D.LineCap.Round;

            eraser = new Pen(Color.White, 10); //eraser is always 2x thicker than the ormal pen as it's more comfortable
            eraser.StartCap = eraser.EndCap = System.Drawing.Drawing2D.LineCap.Round;

            brush = new SolidBrush(Color.Black);
        }

        private void CalculatorRevisited_Paint(object sender, PaintEventArgs e)
        {
        }
        private void CalculatorRevisited_Load(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            PictureBox p = (PictureBox)sender;
            pen.Color = p.BackColor;
            ((SolidBrush)brush).Color = p.BackColor;
        }
        private void pictureBox2_Click(object sender, EventArgs e)
        {
            PictureBox p = (PictureBox)sender;
            pen.Color = p.BackColor;
            brush = new SolidBrush(p.BackColor);
            ((SolidBrush)brush).Color = p.BackColor;
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            PictureBox p = (PictureBox)sender;
            pen.Color = p.BackColor;
            ((SolidBrush)brush).Color = p.BackColor;
        }

        private void pictureBox10_Click(object sender, EventArgs e)
        {
            PictureBox p = (PictureBox)sender;
            pen.Color = p.BackColor;
            ((SolidBrush)brush).Color = p.BackColor;
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            PictureBox p = (PictureBox)sender;
            pen.Color = p.BackColor;
            ((SolidBrush)brush).Color = p.BackColor;
        }

        private void pictureBox8_Click(object sender, EventArgs e)
        {
            PictureBox p = (PictureBox)sender;
            pen.Color = p.BackColor;
            ((SolidBrush)brush).Color = p.BackColor;
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            PictureBox p = (PictureBox)sender;
            pen.Color = p.BackColor;
            ((SolidBrush)brush).Color = p.BackColor;
        }

        private void pictureBox9_Click(object sender, EventArgs e)
        {
            PictureBox p = (PictureBox)sender;
            pen.Color = p.BackColor;
            ((SolidBrush)brush).Color = p.BackColor;
        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            PictureBox p = (PictureBox)sender;
            pen.Color = p.BackColor;
            ((SolidBrush)brush).Color = p.BackColor;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            drawingMode = 1;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            drawingMode = 2;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            drawingMode = 3;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            drawingMode = 4;
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            pen.Width = trackBar1.Value;
            eraser.Width = trackBar1.Value * 2;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void buttonClear_Click(object sender, EventArgs e)
        {
            bitmap = new Bitmap(box.Width, box.Height);
            graphics = Graphics.FromImage(bitmap);
            graphics.Clear(Color.White);
            box.Image = bitmap;
        }

        private void buttonFill_Click(object sender, EventArgs e)
        {
            //graphics.FillRectangle(new SolidBrush(Color.Yellow), savedXSt, savedYSt, savedXEnd, savedYEnd);
            if (drawingMode == 2)
            {
                graphics.FillRectangle(new SolidBrush(Color.Yellow), savedXSt, savedYSt, savedXEnd, savedYEnd);
            }
            else if (drawingMode == 3)
            {
                graphics.FillEllipse(brush, xSt, ySt, x2, y2);
            }
            else if (drawingMode == 4)
            {
                graphics.DrawLine(pen, xSt, ySt, x, y);
            }
        }

        private void buttonBorder_Click(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            drawingMode = 5;
            
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            PictureBox p = (PictureBox)sender;
            pen.Color = p.BackColor;
        }

        private void pictureBox4_MouseDown(object sender, MouseEventArgs e)
        {
            move = true;
            x = e.X;
            y = e.Y;
            xSt = e.X;
            ySt = e.Y;
        }

        private void pictureBox4_MouseMove(object sender, MouseEventArgs e)
        {
            if (move && x != -1 && y != -1)
            {
                if (drawingMode == 1)
                {
                    graphics.DrawLine(pen, new Point(x, y), e.Location);

                } else if (drawingMode == 5)
                {
                    
                    graphics.DrawLine(eraser, new Point(x, y), e.Location);
                }

            }
            box.Refresh();

            x2 = e.X - xSt;
            y2 = e.Y - ySt;
            x = e.X;
            y = e.Y;
        }

        private void pictureBox4_MouseUp(object sender, MouseEventArgs e)
        {
            move = false;
            x2 = x - xSt;
            y2 = y - ySt;
            if (drawingMode == 2)
            {
                graphics.DrawRectangle(pen, xSt, ySt, x2, y2);
                textBox1.Text = "Edit the newly created rectangle:";
                textBox1.Text = Convert.ToString(x2);
                buttonFill.ForeColor = Color.Black;
                buttonFill.BackColor = Color.White;
                buttonBorder.BackColor = Color.White;
                buttonBorder.ForeColor = Color.Black;

                savedXSt = xSt;
                savedYSt = ySt;
                savedXEnd = x2;
                savedYEnd = y2;
            }
            else if (drawingMode == 3)
            {
                graphics.DrawEllipse(pen, xSt, ySt, x2, y2);
                textBox1.Text = "Edit the newly created ellipse:";
            }
            else if (drawingMode == 4)
            {
                graphics.DrawLine(pen, xSt, ySt, x, y);
                textBox1.Text = "Edit the newly created line:";
            }
        }

        private void box_Paint(object sender, PaintEventArgs e)
        {
            Graphics graphics = e.Graphics;
            if (move)
            {
                if (drawingMode == 2)
                {
                    graphics.DrawRectangle(pen, xSt, ySt, x2, y2);
                }
                else if (drawingMode == 3)
                {
                    graphics.DrawEllipse(pen, xSt, ySt, x2, y2);
                }
                else if (drawingMode == 4)
                {
                    graphics.DrawLine(pen, xSt, ySt, x, y);
                }
            }
        }

        /*private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            if (move && x != -1 && y != -1)
            {
                if(drawingMode == 1) {
                    graphics.DrawLine(pen, new Point(x, y), e.Location);
                    
                }
                x2 = e.X - xSt;
                y2 = e.Y - ySt;
                x = e.X;
                y = e.Y;

            }
        }

        private void panel1_MouseUp(object sender, MouseEventArgs e)
        {
            move = false;
            x2 = x - xSt;
            y2 = y - ySt;
            drawingMode = 3;
            if (drawingMode == 2)
            {
                graphics.DrawRectangle(pen, xSt, ySt, x2, y2);
            } else if (drawingMode == 3)
            {
                graphics.DrawEllipse(pen, xSt, ySt, x2, y2);
            } else if (drawingMode == 4)
            {
                graphics.DrawLine(pen, xSt, ySt, x, y);
            }

            x = -1;
            y = -1;
        }

        


        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            move = true;
            x = e.X;
            y = e.Y;
            xSt = e.X;
            ySt = e.Y;
        }


        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            Graphics graphics = e.Graphics;
            if (move)
            {
                if (drawingMode == 2)
                {
                    graphics.DrawRectangle(pen, xSt, ySt, x2, y2);
                }
                else if (drawingMode == 3)
                {
                    graphics.DrawEllipse(pen, xSt, ySt, x2, y2);
                }
                else if (drawingMode == 4)
                {
                    graphics.DrawLine(pen, xSt, ySt, x, y);
                }
            }
        }*/
    }
}
