using System;
using System.Drawing;
using System.Windows.Forms;
using System.Data;
using System.Collections.Generic;

namespace DataGridViewTest
{
    public class MyTable : System.Windows.Forms.Form
    {
        private Panel buttonPanel = new Panel();
        private DataGridView songsDataGridView = new DataGridView();
        private Button addNewRowButton = new Button();
        private Button deleteRowButton = new Button();

        public MyTable()
        {
            this.Load += new EventHandler(MyTable_Load);
        }

        private void MyTable_Load(System.Object sender, System.EventArgs e)
        {
            SetupLayout();
            SetupDataGridView();
            PopulateDataGridView();
        }

        private void addNewRowButton_Click(object sender, EventArgs e)
        {
            this.songsDataGridView.Rows.Add();
        }

        private void deleteRowButton_Click(object sender, EventArgs e)
        {
            if (this.songsDataGridView.SelectedRows.Count > 0 &&
                this.songsDataGridView.SelectedRows[0].Index !=
                this.songsDataGridView.Rows.Count - 1)
            {
                this.songsDataGridView.Rows.RemoveAt(
                    this.songsDataGridView.SelectedRows[0].Index);
            }
        }

        private void SetupLayout()
        {
            this.Size = new Size(600, 500);

            addNewRowButton.Text = "Add Row";
            addNewRowButton.Location = new Point(10, 10);
            addNewRowButton.Click += new EventHandler(addNewRowButton_Click);

            deleteRowButton.Text = "Delete Row";
            deleteRowButton.Location = new Point(100, 10);
            deleteRowButton.Click += new EventHandler(deleteRowButton_Click);

            buttonPanel.Controls.Add(addNewRowButton);
            buttonPanel.Controls.Add(deleteRowButton);
            buttonPanel.Height = 50;
            buttonPanel.Dock = DockStyle.Bottom;

            this.Controls.Add(this.buttonPanel);
        }

        private void SetupDataGridView()
        {
            this.Controls.Add(songsDataGridView);

            songsDataGridView.ColumnHeadersDefaultCellStyle.BackColor = Color.Navy;
            songsDataGridView.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            songsDataGridView.ColumnHeadersDefaultCellStyle.Font =
                new Font(songsDataGridView.Font, FontStyle.Bold);

            songsDataGridView.Name = "songsDataGridView";
            songsDataGridView.Location = new Point(8, 8);
            songsDataGridView.Size = new Size(500, 250);
            songsDataGridView.AutoSize = true;
            songsDataGridView.AutoSizeRowsMode =
                DataGridViewAutoSizeRowsMode.DisplayedCellsExceptHeaders;
            songsDataGridView.ColumnHeadersBorderStyle =
                DataGridViewHeaderBorderStyle.Single;
            songsDataGridView.CellBorderStyle = DataGridViewCellBorderStyle.Single;
            songsDataGridView.GridColor = Color.Black;
            songsDataGridView.RowHeadersVisible = false;

            songsDataGridView.SelectionMode =
                DataGridViewSelectionMode.FullRowSelect;
            songsDataGridView.MultiSelect = false;
            songsDataGridView.Dock = DockStyle.Fill;
        }

        private void PopulateDataGridView()
        {
            //生成一个dataTable,赋值给dataGridView
            var myDataTable = new DataTable("myDataTable");
            DataColumn[] cols = {
                                    new DataColumn("c0", typeof(bool)),//该列就以checkBox显示
                                    new DataColumn("c1", typeof(string)),
                                    new DataColumn("c2", typeof(string)),
                                    new DataColumn("c3", typeof(string))
                                };
            myDataTable.Columns.AddRange(cols);
            //添加row0
            DataRow row0 = myDataTable.NewRow();
            row0["c0"] = false;
            row0["c1"] = "row0_1";
            row0["c2"] = "row0_2";
            row0["c3"] = "row0_3";
            myDataTable.Rows.Add(row0);
            //添加row1
            DataRow row1 = myDataTable.NewRow();
            row1["c0"] = true;
            row1["c1"] = "row1_1";
            row1["c2"] = "row1_2";
            row1["c3"] = "row1_3";
            myDataTable.Rows.Add(row1);

            //songsDataGridView.DataSource = myDataTable;

            //把一个list当作一个dataTable
            var listEmp = ListEmp.GetListEmp();
            songsDataGridView.DataSource = listEmp;

            //创建新的comboboxColumn
            var comboColumn = new DataGridViewComboBoxColumn();
            comboColumn.Items.AddRange("cb1", "cb2","cb3","cb4");
            songsDataGridView.Columns.Add(comboColumn);
            
        }
    }

    public class ListEmp
    {
        public bool IsMarried { get; set; }
        public string Name { get; set; }

        public ListEmp(bool isMarried, string name)
        {
            IsMarried = isMarried;
            Name = name;
        }

        public static List<ListEmp> GetListEmp()
        {
            return new List<ListEmp>
            {
                new ListEmp(true, "panPeng"),
                new ListEmp(true, "liangShuang"),
                new ListEmp(false, "WangChangJie"),
                new ListEmp(false, "liLong")
            };
        }
    }
}
