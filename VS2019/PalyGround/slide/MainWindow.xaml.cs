using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace slide
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Point _lastPoint = new Point(0, 0);
        static int Count = 0;


        public MainWindow()
        {
            InitializeComponent();
        }

        private void StackPanel_TouchMove(object sender, MouseEventArgs e)
        {
            Debug.WriteLine($"StackPanel_TouchMove:{Count++}");
            var sp = sender as StackPanel;
            if (e.LeftButton != MouseButtonState.Pressed) return;
            Debug.WriteLine("StackPanel_TouchMove:Pressed");
            if (_lastPoint.X == 0 && _lastPoint.Y == 0) _lastPoint = e.GetPosition(sp);
            var firstPoint = e.GetPosition(sp);

            var length = firstPoint.X - _lastPoint.X;
            if (length >= 0) //往左
            {
                var newlbLength = lb.Width - length;
                lb.Width = newlbLength > 0 ? newlbLength : 0;
                if (lb.Width == 0)
                    rb.Width += length;
            }
            else    //往右
            {
                var newlbLength = rb.Width - length;
                rb.Width = newlbLength > 0 ? newlbLength : 0;
                if (rb.Width == 0)
                    lb.Width += length;
            }

            if (rb.Width / sp.Width > 0.4)
            {
                MessageBox.Show("已删除");
            }
            else if (lb.Width / sp.Width > 0.4)
            {
                MessageBox.Show("已收藏");
            }
        }

        private void StackPanel_TouchLeave(object sender, MouseButtonEventArgs e)
        {
            Debug.WriteLine("StackPanel_TouchLeave");
            var sp = sender as StackPanel;
            rb.Width = 0;
            lb.Width = 0;
            element.Width = sp.Width;
        }
    }
}
