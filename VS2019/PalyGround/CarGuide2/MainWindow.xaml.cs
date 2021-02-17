using System;
using System.Collections.Generic;
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

namespace CarGuide2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            InitialCarList();
        }

        public void InitialCarList()
        {
            List<Car> carList = new List<Car>()
            {
                new Car(){Name = "Aventador", Consumption = "18L", Price = "700W$", Type = "Sport", Year = "2011"},
                new Car(){Name = "Urus", Consumption = "12.7L", Price = "300W$", Type = "SUV", Year = "2012"},
                new Car(){Name = "Gallardo", Consumption = "15L", Price = "400W$", Type = "Sport", Year = "2004"},
                new Car(){Name = "Reventon", Consumption = "4L", Price = "1500W$", Type = "Sport", Year = "2008"}
            };

            foreach(Car car in carList)
            {
                CarListItemView view = new CarListItemView();
                view.Car = car;
                this.lsitBoxCars.Items.Add(view);
            }
        }

        private void lsitBoxCars_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            CarListItemView view = e.AddedItems[0] as CarListItemView;
            if(view != null)
            {
                this.detailView.Car = view.Car;
            }
        }
    }
}
