using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace CarGuide2
{
    /// <summary>
    /// CarDetailView.xaml 的交互逻辑
    /// </summary>
    public partial class CarDetailView : UserControl
    {
        public CarDetailView()
        {
            InitializeComponent();
        }
        private Car car;
        public Car Car
        {
            get { return car; }
            set
            {
                car = value;
                this.textBlockName.Text = car.Name;
                this.textBlockType.Text = car.Type;
                this.textBlockConsumption.Text = car.Consumption;
                this.textBlockPrice.Text = car.Price;
                string uriStr = $"/Resources/Image/{car.Name}.png";
                this.imagePhoto.Source = new BitmapImage(new Uri(uriStr, UriKind.Relative));
            }
        }
    }
}
