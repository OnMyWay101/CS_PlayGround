using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;

namespace PanelPicture
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            LoadPicture();
        }

        private void LoadPicture()
        {
            var image = new Bitmap(@"C:\Users\wangcj.SINODSP\Desktop\杂物\bitMap\lf.bmp");
            this.pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            //pictureBox1.ClientSize = new Size(100, 100);
            this.pictureBox1.Image = image;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //if (MessageBox.Show("是否继续？") == DialogResult.Yes)
            //{
            //    label1.Text = "Welcome!";
            //}

            DialogResult ret = MessageBox.Show("是否继续？", "captoin", MessageBoxButtons.YesNo);
            //Debug.WriteLine(ret.ToString());
            if (ret == DialogResult.Yes)
            {
                label1.Text = "Welcome!";
            }
        }
    }
}
