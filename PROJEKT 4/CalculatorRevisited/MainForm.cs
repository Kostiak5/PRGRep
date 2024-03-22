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
    public partial class MainForm : Form
    {
        Graphics graphics;
        Bitmap bitmap, imageBitmap;
        int x = -1, y = -1, x2 = -1, y2 = -1, xSt = -1, ySt = -1;
        public static int imgWidth = 0, imgHeight = 0;
        int drawingMode = 1;
        bool imageInsertion = false;
        bool move = false;

        Pen pen, eraser;
        Brush brush;
        Color color = Color.Black;
        public MainForm()
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
            color = p.BackColor;
            textBoxColor.ForeColor = p.BackColor;
            textBoxColor.Text = Convert.ToString(p.BackColor);
        }
        private void pictureBox2_Click(object sender, EventArgs e)
        {
            PictureBox p = (PictureBox)sender;
            pen.Color = p.BackColor;
            ((SolidBrush)brush).Color = p.BackColor;
            color = p.BackColor;
            textBoxColor.ForeColor = p.BackColor;
            textBoxColor.Text = Convert.ToString(p.BackColor);
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            PictureBox p = (PictureBox)sender;
            pen.Color = p.BackColor;
            ((SolidBrush)brush).Color = p.BackColor;
            color = p.BackColor;
            textBoxColor.ForeColor = p.BackColor;
            textBoxColor.Text = Convert.ToString(p.BackColor);
        }

        private void pictureBox10_Click(object sender, EventArgs e)
        {
            PictureBox p = (PictureBox)sender;
            pen.Color = p.BackColor;
            ((SolidBrush)brush).Color = p.BackColor;
            color = p.BackColor;
            textBoxColor.ForeColor = p.BackColor;
            textBoxColor.Text = Convert.ToString(p.BackColor);
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            PictureBox p = (PictureBox)sender;
            pen.Color = p.BackColor;
            ((SolidBrush)brush).Color = p.BackColor;
            color = p.BackColor;
            textBoxColor.ForeColor = p.BackColor;
            textBoxColor.Text = Convert.ToString(p.BackColor);
        }

        private void pictureBox8_Click(object sender, EventArgs e)
        {
            PictureBox p = (PictureBox)sender;
            pen.Color = p.BackColor;
            ((SolidBrush)brush).Color = p.BackColor;
            color = p.BackColor;
            textBoxColor.ForeColor = p.BackColor;
            textBoxColor.Text = "Color [Light Blue]"; //the system name DeepSkyBlue looks bad so I just replaced it manually
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            PictureBox p = (PictureBox)sender;
            pen.Color = p.BackColor;
            ((SolidBrush)brush).Color = p.BackColor;
            color = p.BackColor;
            textBoxColor.ForeColor = p.BackColor;
            textBoxColor.Text = Convert.ToString(p.BackColor);
        }

        private void pictureBox9_Click(object sender, EventArgs e)
        {
            PictureBox p = (PictureBox)sender;
            pen.Color = p.BackColor;
            ((SolidBrush)brush).Color = p.BackColor;
            color = p.BackColor;
            textBoxColor.ForeColor = p.BackColor;
            textBoxColor.Text = Convert.ToString(p.BackColor);
        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            PictureBox p = (PictureBox)sender;
            pen.Color = p.BackColor;
            ((SolidBrush)brush).Color = p.BackColor;
            color = p.BackColor;
            textBoxColor.ForeColor = p.BackColor;
            textBoxColor.Text = Convert.ToString(p.BackColor);
        }
        private void pictureBox3_Click(object sender, EventArgs e)
        {
            PictureBox p = (PictureBox)sender;
            pen.Color = p.BackColor;
            ((SolidBrush)brush).Color = p.BackColor;
            color = p.BackColor;
            textBoxColor.ForeColor = p.BackColor;
            textBoxColor.Text = Convert.ToString(p.BackColor);
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

        private void box_MouseClick(object sender, MouseEventArgs e)
        {
            if(imageInsertion)
            {
                graphics.DrawImage(imageBitmap, e.Location.X, e.Location.Y, imgWidth, imgHeight);
                imageInsertion = false;
            } 
            else if(drawingMode == 6)
            {
                if(!color.ToArgb().Equals(bitmap.GetPixel(e.Location.X,e.Location.Y).ToArgb()))
                    fill(bitmap, e.Location.X, e.Location.Y, color);
            }
        }

        private void buttonClear_Click(object sender, EventArgs e)
        {
            bitmap = new Bitmap(box.Width, box.Height);
            graphics = Graphics.FromImage(bitmap);
            graphics.Clear(Color.White);
            box.Image = bitmap;
        }


        public void buttonImage_Click(object sender, EventArgs e)
        {
            if(openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                imageBitmap = new Bitmap(openFileDialog1.FileName);

                ImageForm imageForm = new ImageForm(imageBitmap.Width, imageBitmap.Height);
                imageForm.ShowDialog();

                imageInsertion = true;
            }
        }

        private void box_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        static void fillingProcess(Bitmap bitmap, int xF, int yF, Color newColor, Color originalColor, Stack<Point> pointStack)
        {
            bitmap.SetPixel(xF, yF, newColor);
            pointStack.Push(new Point(xF, yF));
            return;
        }

        static void fill(Bitmap bitmap, int xF, int yF, Color newColor)
        {
            Color originalColor = bitmap.GetPixel(xF, yF);
            Stack<Point> pointStack = new Stack<Point>();
            pointStack.Push(new Point(xF, yF));
            
            bitmap.SetPixel(xF, yF, newColor);
            if(newColor == originalColor)
            {
                return;
            }

            while(pointStack.Count > 0) //basically a BFS
            {
                Point currentPoint = (Point)pointStack.Pop();
                xF = currentPoint.X;
                yF = currentPoint.Y;
                if (xF < bitmap.Width - 1 && bitmap.GetPixel(xF + 1, yF) == originalColor)
                {
                    fillingProcess(bitmap, xF + 1, yF, newColor, originalColor, pointStack);
                }
                if (xF > 0 && bitmap.GetPixel(xF - 1, yF) == originalColor)
                {
                    fillingProcess(bitmap, xF - 1, yF, newColor, originalColor, pointStack);
                }
                if (yF < bitmap.Height - 1 && bitmap.GetPixel(xF, yF + 1) == originalColor)
                {
                    fillingProcess(bitmap, xF, yF + 1, newColor, originalColor, pointStack);
                }
                if (yF > 0 && bitmap.GetPixel(xF, yF - 1) == originalColor)
                {
                    fillingProcess(bitmap, xF, yF - 1, newColor, originalColor, pointStack);
                }
            }
        }

        private void buttonFill_Click(object sender, EventArgs e)
        {
            drawingMode = 6;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            drawingMode = 5;
            
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
            //
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
