using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ListView_CheakBox
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            //AddItems();
            //AddItems2();
            CreateMyListView();
        }

        /// <summary>
        /// items只会加在第一行
        /// </summary>
        private void AddItems()
        {
            int i = 0;
            ListViewItem item = new ListViewItem(i++.ToString());
            ListViewItem item2 = new ListViewItem(i++.ToString());
            ListViewItem item3 = new ListViewItem(i++.ToString());

            listView1.Items.Add(item);
            listView1.Items.Add(item2);
            item2.Checked = false;
            listView1.Items.Add(item3);
            item3.Checked = false;
        }

        private void AddItems2()
        {
            int i = 0;
            listView1.Columns.Add("add column " + i++.ToString(), -2, HorizontalAlignment.Left);
            listView1.Columns.Add("add column " + i++.ToString(), -2, HorizontalAlignment.Left);
            listView1.Columns.Add("add column " + i++.ToString(), -2, HorizontalAlignment.Left);
            listView1.Columns.Add("add column " + i++.ToString(), -2, HorizontalAlignment.Left);

            //i = 0;
            //foreach(var clm in listView1.Columns)
            //{
               
            //}
        }

        /// <summary>
        /// 微软官方提供的例程，做了一些小的改进
        /// </summary>
        private void CreateMyListView()
        {
            // Create a new ListView control.
            //ListView listView1 = new ListView();
            listView1.Bounds = new Rectangle(new Point(10, 10), new Size(300, 200));

            // Set the view to show details.
            listView1.View = View.Details;
            // Allow the user to edit item text.
            listView1.LabelEdit = true;
            // Allow the user to rearrange columns.
            listView1.AllowColumnReorder = true;
            // Display check boxes.
            listView1.CheckBoxes = true;
            // Select the item and subitems when selection is made.
            listView1.FullRowSelect = true;
            // Display grid lines.
            listView1.GridLines = true;
            // Sort the items in the list in ascending order.
            listView1.Sorting = SortOrder.Descending;

            // Create three items and three sets of subitems for each item.
            ListViewItem item1 = new ListViewItem("item1", 0);
            // Place a check mark next to the item.
            item1.Checked = true;
            item1.SubItems.Add("1");
            item1.SubItems.Add("2");
            item1.SubItems.Add("3");
            ListViewItem item2 = new ListViewItem("item2", 1);
            item2.SubItems.Add("4");
            item2.SubItems.Add("5");
            item2.SubItems.Add("6");
            ListViewItem item3 = new ListViewItem("item3", 0);
            // Place a check mark next to the item.
            item3.Checked = true;
            item3.SubItems.Add("7");
            item3.SubItems.Add("8");
            item3.SubItems.Add("9");

            // Create columns for the items and subitems.
            // Width of -2 indicates auto-size.
            listView1.Columns.Add("Item Column", -2, HorizontalAlignment.Left);
            listView1.Columns.Add("Column 2", -2, HorizontalAlignment.Left);
            listView1.Columns.Add("Column 3", -2, HorizontalAlignment.Left);
            listView1.Columns.Add("Column 4", -2, HorizontalAlignment.Center);

            //Add the items to the ListView.
            listView1.Items.AddRange(new ListViewItem[] { item1, item2, item3 });

            // Create two ImageList objects.
            ImageList imageListSmall = new ImageList();
            //ImageList imageListLarge = new ImageList();

            // Initialize the ImageList objects with bitmaps.
            //imageListSmall.Images.Add(Bitmap.FromFile(@"C:\Users\wangcj.SINODSP\Desktop\bitMap\lf.bmp"));
            //imageListSmall.Images.Add(Bitmap.FromFile(@"C:\Users\wangcj.SINODSP\Desktop\bitMap\nm.bmp"));
            //imageListSmall.Images.Add(Bitmap.FromFile(@"C:\Users\wangcj.SINODSP\Desktop\bitMap\sl.bmp"));
            //imageListLarge.Images.Add(Bitmap.FromFile(@"C:\Users\wangcj.SINODSP\Desktop\bitMap\sl.bmp"));
            //imageListLarge.Images.Add(Bitmap.FromFile(@"C:\Users\wangcj.SINODSP\Desktop\bitMap\wsp.bmp"));

            //Assign the ImageList objects to the ListView.
            //listView1.LargeImageList = imageListLarge;
            listView1.SmallImageList = imageListSmall;

            // Add the ListView to the control collection.
            //this.Controls.Add(listView1);
           
        }
    }
}
