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
    public partial class ImageForm : Form
    {
        public ImageForm(int width, int height)
        {
            InitializeComponent();
            textBox1.Text = Convert.ToString(width);
            textBox2.Text = Convert.ToString(height);
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void buttonSize_Click(object sender, EventArgs e)
        {
            this.Hide();
            MainForm.imgWidth = Convert.ToInt32(textBox1.Text);
            MainForm.imgHeight = Convert.ToInt32(textBox2.Text);
        }
    }
}
