using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace asyncAwait
{
    public partial class Form2 : Form
    {
        private CancellationTokenSource _source;
        private CancellationToken _token;

        public Form2()
        {
            InitializeComponent();
        }

        private void progressBar1_Click(object sender, EventArgs e)
        {

        }

        private async void button1_Click(object sender, EventArgs e)
        {
            button1.Enabled = false;
            _source = new CancellationTokenSource();
            _token = _source.Token;

            var completedPercent = 0; //完成百分比
            const int time = 10; //循环次数
            const int timePercent = 100 / time; //进度条每次增加的进度值

            for(var i = 0; i < time; i++)
            {
                if(_token.IsCancellationRequested)
                {
                    break;
                }
                try
                {
                    await Task.Delay(1000, _token);
                    completedPercent = (i + 1) * timePercent;
                }
                catch (Exception)
                {
                    completedPercent = (i + 1) * timePercent;
                }
                finally
                {
                    progressBar1.Value = completedPercent;
                }
            }
            var msg = _token.IsCancellationRequested ? $"进度为：{completedPercent} % 已经被取消 " : $"已经完成";
            MessageBox.Show(msg, "信息");

            progressBar1.Value = 0;
            button1.Enabled = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (button1.Enabled) return;

            _source.Cancel();
        }
    }
}
