using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ComboBoxTest1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            //bindCbox_List();
            //bindCbox_Dictionary();
            //bindCbox_DataTable();
            comboBox1.SelectedIndexChanged += new EventHandler(comboBox1_SelectedIndexChanged);
        }

        void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            var cbb = sender as ComboBox;
            if(cbb != null)
            {
                MessageBox.Show(cbb.SelectedValue.ToString());
            }
        }

        private void bindCbox_DataTable()
        {
            DataTable dt = new DataTable();
            DataColumn dc1 = new DataColumn("id");
            DataColumn dc2 = new DataColumn("name");
            dt.Columns.Add(dc1);
            dt.Columns.Add(dc2);

            DataRow dr1 = dt.NewRow();
            dr1["id"] = "1";
            dr1["name"] = "aaaaaa";

            DataRow dr2 = dt.NewRow();
            dr2["id"] = "2";
            dr2["name"] = "bbbbbb";

            dt.Rows.Add(dr1);
            dt.Rows.Add(dr2);

            comboBox1.DataSource = dt;
            comboBox1.ValueMember = "id";
            comboBox1.DisplayMember = "name";
            comboBox1.SelectedIndex = 0;
        }

        private void bindCbox_Dictionary()
        {
            Dictionary<int, string> kvDictonary = new Dictionary<int, string>();
            kvDictonary.Add(1, "11111");
            kvDictonary.Add(2, "22222");
            kvDictonary.Add(3, "333333");

            BindingSource bs = new BindingSource();
            bs.DataSource = kvDictonary;
            comboBox1.DataSource = bs;
            //comboBox1.ValueMember = "Key";
            comboBox1.DisplayMember = "Value";
        }

        private void bindCbox_List()
        {
            IList<Info> infoList = new List<Info>();
            Info info1 = new Info() { Id = "1", Name = "张三" };
            Info info2 = new Info() { Id = "2", Name = "李四" };
            Info info3 = new Info() { Id = "3", Name = "王五" };
            infoList.Add(info1);
            infoList.Add(info2);
            infoList.Add(info3);
            comboBox1.DataSource = infoList;
            //comboBox1.ValueMember = "Id";
            comboBox1.DisplayMember = "Id";
        }

        //仅仅bindCbox_List使用
        private class Info
        {
            public string Id { get; set; }
            public string Name { get; set; }

        }
        private class User
        {
            public string UserName { get; set; }
            public string UserId { get; set; }
        }
    }
}
