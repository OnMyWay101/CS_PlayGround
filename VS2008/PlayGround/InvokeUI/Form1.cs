using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;

namespace InvokeUI
{
    public partial class Form1 : Form
    {
        public delegate void MyDelegateUI();
        Thread myThread;
        MyDelegateUI myDelegateUI;

        public Form1()
        {
            InitializeComponent();

            myDelegateUI = new MyDelegateUI(RefreshUI);
        }

        private void RefreshUI()
        {

        }

        private void ThreadDoWork()
        {
            for (int i = 0; i < 1000; i++)
            {
                Thread.Sleep(1000);//1s打印一行
                this.Invoke(myDelegateUI);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            myThread = new Thread(ThreadDoWork);
            myThread.Start();
        }
    }
}
