using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CarGuide
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
            LocalInit2();
            listView1.ItemSelectionChanged += new ListViewItemSelectionChangedEventHandler((o, e) =>
            {
                ShowCarInfo(_cars[e.ItemIndex]);
            });
        }

        private List<Car> _cars = new List<Car>();
        /// <summary>
        /// 官方初始化示例
        /// </summary>
        private void LocalInit()
        {
            listView1.View = View.Details;
            listView1.AllowColumnReorder = true;
            listView1.CheckBoxes = true;
            listView1.FullRowSelect = true;
            listView1.GridLines = true;

            ListViewItem item1 = new ListViewItem("item1", 0);
            item1.Checked = true;
            item1.SubItems.Add("1");
            item1.SubItems.Add("2");
            item1.SubItems.Add("3");
            ListViewItem item2 = new ListViewItem("item2", 1);
            item2.SubItems.Add("4");
            item2.SubItems.Add("5");
            item2.SubItems.Add("6");
            ListViewItem item3 = new ListViewItem("item3", 0);
            item3.Checked = true;
            item3.SubItems.Add("7");
            item3.SubItems.Add("8");
            item3.SubItems.Add("9");

            listView1.Columns.Add("Item Column", -2, HorizontalAlignment.Left);
            listView1.Columns.Add("Column 2", -2, HorizontalAlignment.Left);
            listView1.Columns.Add("Column 3", -2, HorizontalAlignment.Left);
            listView1.Columns.Add("Column 4", -2, HorizontalAlignment.Center);

            //Add the items to the ListView.
            listView1.Items.AddRange(new ListViewItem[] { item1, item2, item3 });

            // Create two ImageList objects.
            ImageList imageListSmall = new ImageList();
            ImageList imageListLarge = new ImageList();

            // Initialize the ImageList objects with bitmaps.
            imageListSmall.Images.Add(Bitmap.FromFile(@"G:\study\Github\self\CS_PlayGround\VS2019\PalyGround\CarGuide\Resources\Image\Aventador.png"));
            imageListSmall.Images.Add(Bitmap.FromFile(@"G:\study\Github\self\CS_PlayGround\VS2019\PalyGround\CarGuide\Resources\Image\Gallardo.png"));
            imageListLarge.Images.Add(Bitmap.FromFile(@"G:\study\Github\self\CS_PlayGround\VS2019\PalyGround\CarGuide\Resources\Image\Reventon.png"));
            imageListLarge.Images.Add(Bitmap.FromFile(@"G:\study\Github\self\CS_PlayGround\VS2019\PalyGround\CarGuide\Resources\Image\Urus.png"));

            //Assign the ImageList objects to the ListView.
            listView1.LargeImageList = imageListLarge;
            listView1.SmallImageList = imageListSmall;
        }

        private void LocalInit2()
        {
            InitCars();
            listView1.View = View.LargeIcon;

            foreach(var car in _cars)
            {
                listView1.Items.Add(new ListViewItem($"{car.Name}:{car.Year}", 0));
            }

            ImageList imageListLarge = new ImageList();
            imageListLarge.ImageSize = new Size(100, 100);
            imageListLarge.Images.Add(Bitmap.FromFile(@"..\..\Resources\Logo\Lamborghini.png"));
            listView1.LargeImageList = imageListLarge;

            ShowCarInfo(_cars[0]);
        }

        private void InitCars()
        {
            _cars.Add(new Car("Aventador") 
            {
                Type = "Sport",
                Consumption = "18L",
                Price = "700W$",
                Year="2011"
            });
            _cars.Add(new Car("Urus")
            {
                Type = "SUV",
                Consumption = "12.7L",
                Price = "300W$",
                Year = "2012"
            });
            _cars.Add(new Car("Gallardo")
            {
                Type = "Sport",
                Consumption = "15L",
                Price = "400W$",
                Year = "2004"
            });
            _cars.Add(new Car("Reventon")
            {
                Type = "Sport",
                Consumption = "4L",
                Price = "1500W$",
                Year = "2008"
            });
        }

        private void ShowCarInfo(Car car)
        {
            _nameLb.Text = car.Name;
            TypeLb.Text = car.Type;
            ConsumptionLb.Text = car.Consumption;
            PriceLb.Text = car.Price;

            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.Image = (Image)(new Bitmap(car.PicturePath));
        }
    }
}
