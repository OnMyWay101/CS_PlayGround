using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Windows.Forms;

namespace asyncAwait
{
    public partial class AsyncForm : Form
    {
        public AsyncForm()
        {
            InitializeComponent();
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            button1.Enabled = false;
            label1.Text = "Doing";

            //await Task.Delay(3000);
            await Task.Run(() => Thread.Sleep(3000));

            button1.Enabled = true;
            label1.Text = "Complete";

        }
    }
}
