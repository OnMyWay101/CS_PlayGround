using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using System.Diagnostics;

namespace RefreshUI
{
    public partial class Form1 : Form
    {
        private delegate void UIDelegate(); //定义更新UI的委托类型
        Thread _thread;
        UIDelegate _uiDelegate;

        public Form1()
        {
            InitializeComponent();
            _uiDelegate = new UIDelegate(ReFreshUI);
        }

        private void ReFreshUI()
        {
            richTextBox1.AppendText("New Line! \r\n");
        }

        private void doWork()
        {
            for (int i = 0; i < 20; i++)
            {
                Thread.Sleep(1000);
                this.Invoke(_uiDelegate);
                Debug.WriteLine("doing work!");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            _thread = new Thread(doWork);
            _thread.Start();
            //_thread.Join();//等待线程结束
            //Debug.WriteLine("done work!");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            richTextBox1.AppendText("Print New Line! \r\n");
        }

    }
}
