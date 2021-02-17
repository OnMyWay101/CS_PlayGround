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

namespace CarGuide3
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            InitCarsList();


        }

        private void InitCarsList()
        {
            List<Car> cars = new List<Car>()
            {
                new Car(){AutoMaker="Lamborghini", Name = "Aventador", Consumption = "18L", Price = "700W$", Type = "Sport", Year = "2011"},
                new Car(){AutoMaker="Lamborghini", Name = "Urus", Consumption = "12.7L", Price = "300W$", Type = "SUV", Year = "2012"},
                new Car(){AutoMaker="Lamborghini", Name = "Gallardo", Consumption = "15L", Price = "400W$", Type = "Sport", Year = "2004"},
                new Car(){AutoMaker="Lamborghini", Name = "Reventon", Consumption = "4L", Price = "1500W$", Type = "Sport", Year = "2008"}
            };
            this.listBoxCars.ItemsSource = cars;

        }
    }
}
