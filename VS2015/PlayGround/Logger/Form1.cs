using System;
using System.IO;
using System.Text;
using System.Windows.Forms;


namespace Logger
{
    public partial class Form1 : Form
    {
        /// <summary>
        /// 进度调的进度值，初始为0；
        /// </summary>
        private int processorPercent = 0;

        public Form1()
        {
            InitializeComponent();
            toolStripStatusLabel1.Text = "Welcome to WCJ logger!";
        }

        private void FolderChooseButton_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            if(fbd.ShowDialog() == DialogResult.OK)
            {
                string fileName = DateTime.Now.ToString("yyyy_MM_dd_hh_mm_ss") + ".txt";
                pathTextBox.Text = fbd.SelectedPath + @"\" + fileName;
            }
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            string filePath = pathTextBox.Text;
            if(File.Exists(filePath))
            {
                File.Delete(filePath);
            }
            using (FileStream fs = File.Create(filePath))
            {
                Encoding u16LE = Encoding.Unicode;
                string contentHead = "WangCJ's cool job!\n";
                fs.Write(u16LE.GetBytes(contentHead), 0, u16LE.GetByteCount(contentHead));
                fs.Write(u16LE.GetBytes(logTextBox.Text), 0, u16LE.GetByteCount(logTextBox.Text));
            }
            SaveButton.Enabled = false;

            timer1.Enabled = true;
            timer1.Interval = 500;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {

            toolStripStatusLabel1.Text = "写入进度：" + processorPercent.ToString() + "%";
            toolStripProgressBar1.Visible = true;
            toolStripProgressBar1.Value = processorPercent;

            processorPercent += 5;
            if (processorPercent >= 100)
            {
                timer1.Enabled = false;
                toolStripProgressBar1.Visible = false;
                toolStripStatusLabel1.Text = "写入成功!";
                processorPercent = 0;
            }
        }
    }
}
