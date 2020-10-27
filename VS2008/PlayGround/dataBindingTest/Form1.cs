using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace dataBindingTest
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            textBox1.DataBindings.Add("Text", trackBar1, "Value", false, DataSourceUpdateMode.OnPropertyChanged);
        }
    }
}
