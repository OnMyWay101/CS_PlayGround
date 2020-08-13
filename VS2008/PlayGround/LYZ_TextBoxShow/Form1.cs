using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace LYZ_TextBoxShow
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int[] info = new int[] { 1, 2, 3, 4, 5 };
            string text = String.Empty;

            foreach(int num in info)
            {
                text = text + " " + num.ToString();
            }
            textBox1.Text = String.Format("{0} \r\n New Content:{1}", textBox1.Text, text);
        }
    }
}
