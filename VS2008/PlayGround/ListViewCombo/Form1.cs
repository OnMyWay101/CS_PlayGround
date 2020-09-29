using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ListViewCombo
{
    public partial class Form1 : Form
    {
        private ListViewItem lvItem;

        public Form1()
        {
            InitializeComponent();
            this.Load += new EventHandler(Form1_Load);
            this.cbListViewCombo.SelectedValueChanged += new EventHandler(cbListViewCombo_SelectedValueChanged);
            this.cbListViewCombo.Leave += new EventHandler(cbListViewCombo_Leave);
            this.cbListViewCombo.KeyPress += new KeyPressEventHandler(cbListViewCombo_KeyPress);
            this.myListView1.MouseUp += new MouseEventHandler(myListView1_MouseUp);
        }

        void myListView1_MouseUp(object sender, MouseEventArgs e)
        {
            // Get the item on the row that is clicked.
            lvItem = this.myListView1.GetItemAt(e.X, e.Y);

            // Make sure that an item is clicked.
            if (lvItem != null)
            {
                // Get the bounds of the item that is clicked.
                Rectangle ClickedItem = lvItem.Bounds;

                // Verify that the column is completely scrolled off to the left.
                if ((ClickedItem.Left + this.myListView1.Columns[0].Width) < 0)
                {
                    // If the cell is out of view to the left, do nothing.
                    return;
                }

                // Verify that the column is partially scrolled off to the left.
                else if (ClickedItem.Left < 0)
                {
                    // Determine if column extends beyond right side of ListView.
                    if ((ClickedItem.Left + this.myListView1.Columns[0].Width) > this.myListView1.Width)
                    {
                        // Set width of column to match width of ListView.
                        ClickedItem.Width = this.myListView1.Width;
                        ClickedItem.X = 0;
                    }
                    else
                    {
                        // Right side of cell is in view.
                        ClickedItem.Width = this.myListView1.Columns[0].Width + ClickedItem.Left;
                        ClickedItem.X = 2;
                    }
                }
                else if (this.myListView1.Columns[0].Width > this.myListView1.Width)
                {
                    ClickedItem.Width = this.myListView1.Width;
                }
                else
                {
                    ClickedItem.Width = this.myListView1.Columns[0].Width;
                    ClickedItem.X = 2;
                }

                // Adjust the top to account for the location of the ListView.
                ClickedItem.Y += this.myListView1.Top;
                ClickedItem.X += this.myListView1.Left;

                // Assign calculated bounds to the ComboBox.
                this.cbListViewCombo.Bounds = ClickedItem;

                // Set default text for ComboBox to match the item that is clicked.
                this.cbListViewCombo.Text = lvItem.Text;

                // Display the ComboBox, and make sure that it is on top with focus.
                this.cbListViewCombo.Visible = true;
                this.cbListViewCombo.BringToFront();
                this.cbListViewCombo.Focus();
            }
        }

        void cbListViewCombo_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Verify that the user presses ESC.
            switch (e.KeyChar)
            {
                case (char)(int)Keys.Escape:
                    {
                        // Reset the original text value, and then hide the ComboBox.
                        this.cbListViewCombo.Text = lvItem.Text;
                        this.cbListViewCombo.Visible = false;
                        break;
                    }

                case (char)(int)Keys.Enter:
                    {
                        // Hide the ComboBox.
                        this.cbListViewCombo.Visible = false;
                        break;
                    }
            }
        }

        void cbListViewCombo_Leave(object sender, EventArgs e)
        {
            // Set text of ListView item to match the ComboBox.
            lvItem.Text = this.cbListViewCombo.Text;

            // Hide the ComboBox.
            this.cbListViewCombo.Visible = false;
        }

        void cbListViewCombo_SelectedValueChanged(object sender, EventArgs e)
        {
            // Set text of ListView item to match the ComboBox.
            lvItem.Text = this.cbListViewCombo.Text;

            // Hide the ComboBox.
            this.cbListViewCombo.Visible = false;
        }

        void Form1_Load(object sender, EventArgs e)
        {
            // Add a few items to the combo box list.
            this.cbListViewCombo.Items.Add("NC");
            this.cbListViewCombo.Items.Add("WA");

            // Set view of ListView to Details.
            this.myListView1.View = View.Details;

            // Turn on full row select.
            this.myListView1.FullRowSelect = true;

            // Add data to the ListView.
            ColumnHeader columnheader;
            ListViewItem listviewitem;

            // Create sample ListView data.
            listviewitem = new ListViewItem("NC");
            listviewitem.SubItems.Add("North Carolina");
            this.myListView1.Items.Add(listviewitem);

            listviewitem = new ListViewItem("WA");
            listviewitem.SubItems.Add("Washington");
            this.myListView1.Items.Add(listviewitem);

            // Create column headers for the data.
            columnheader = new ColumnHeader();
            columnheader.Text = "State Abbr.";
            this.myListView1.Columns.Add(columnheader);

            columnheader = new ColumnHeader();
            columnheader.Text = "State";
            this.myListView1.Columns.Add(columnheader);

            // Loop through and size each column header to fit the column header text.
            foreach (ColumnHeader ch in this.myListView1.Columns)
            {
                ch.Width = -2;
            }
        }

        
    }
}
