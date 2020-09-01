using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CellClicked
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridView dataView = (DataGridView)sender;
            try
            {
                string value = dataView.SelectedCells[0].Value.ToString();
                MessageBox.Show("CellClick! Grid Value is:" + value);
            }
            catch(NullReferenceException ex)
            {
                MessageBox.Show("CellClick! No Selected");
            }
        }

        private void dataGridView1_Click(object sender, System.EventArgs e)
        {
            //MessageBox.Show("Click");
        }
    }
}
