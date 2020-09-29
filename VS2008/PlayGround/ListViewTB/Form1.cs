using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ListViewTB
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            InitListView();
        }

        private void InitListView()
        {
            //初始化机箱的的ListView
            this.listView1.BeginUpdate();
            this.listView1.View = View.Details;
            this.listView1.GridLines = true;
            this.listView1.Columns.Add("槽位号", 100, HorizontalAlignment.Left);

            this.listView1.Columns.Add("板卡类型", 100, HorizontalAlignment.Left);
            this.listView1.Activation = ItemActivation.OneClick;
            this.listView1.EndUpdate();

            for (int i = 0; i < 10; i++)
            {
                listView1.Items.Add(new ListViewItem(i.ToString()));
                listView1.Items[i].SubItems.Add((i + 10).ToString());
            }
        }


        /// <summary>
        /// 实现一个可以编辑单个窗体值的ListView
        /// </summary>
        public class ListView_TextBox : ListView
        {
            private TextBox _textBox;
            private ListViewItem.ListViewSubItem _subItem;

            public ListView_TextBox()
            {
                _textBox = new TextBox();
                base.Controls.Add(_textBox);
                _textBox.Visible = false;
                base.FullRowSelect = true;
                SetItemHeight(40);

                //绑定事件订阅函数
                base.MouseUp += new MouseEventHandler(OnMouseUp);
                _textBox.Leave += new EventHandler(_textBox_Leave);
                _textBox.KeyDown += new KeyEventHandler(_textBox_KeyDown);
            }

            public void SetItemHeight(int h)
            {
                ImageList imageList = new ImageList();
                imageList.ImageSize = new System.Drawing.Size(1, h);
                base.SmallImageList = imageList;
            }

            //处理Enter键完成的效果
            void _textBox_KeyDown(object sender, KeyEventArgs e)
            {
                if ((int)e.KeyCode == 13)//Enter键的KeyCode是13
                {
                    _textBox_Leave(sender, e);
                }
            }

            void _textBox_Leave(object sender, EventArgs e)
            {
                _subItem.Text = _textBox.Text;
                _textBox.Visible = false;
                base.Focus();
            }

            private void OnMouseUp(object sender, MouseEventArgs me)
            {
                int columnNum = 0;//当前选择的单元格在第几列
                if (base.SelectedItems.Count == 0)
                {
                    return;
                }
                ListViewItem lvItem = base.SelectedItems[0];//默认选择第一个ListViewItem
                
                Rectangle textRect = lvItem.Bounds;
                //调整textBox的高度
                textRect.Height = base.SmallImageList.ImageSize.Height;

                foreach (ColumnHeader column in base.Columns)
                {
                    if (me.X >= textRect.X && me.X <= (textRect.X + column.Width))
                    {
                        textRect.Width = column.Width;
                        break;
                    }
                    //匹配不上列数加一，textBox的矩形框起点往后移一个列的长度
                    columnNum++;
                    textRect.X += column.Width;
                }
                _subItem = lvItem.SubItems[columnNum];
                _textBox.AutoSize = false;
                _textBox.Bounds = textRect;
                _textBox.Text = _subItem.Text;
                _textBox.Visible = true;
                _textBox.BringToFront();
                _textBox.Focus();
                return;
            }
        }
    }
}
