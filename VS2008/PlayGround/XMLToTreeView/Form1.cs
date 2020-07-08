using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Xml.Linq;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;

namespace XMLToTreeView
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            InitTreeView("hello1.xml");
        }
        private void InitTreeView(string xmlPath)
        {
            XElement xmlInfo = XElement.Load(xmlPath);
            Debug.WriteLine(xmlInfo);

            treeView1.BeginUpdate();
            XElementInitTreeNode(treeView1.Nodes, xmlInfo);
            treeView1.EndUpdate();            
        }
        private void XElementInitTreeNode(TreeNodeCollection treeNodes, XElement element)
        {
            //定义边界条件
            if (!element.HasElements)
            {
                return;
            }
            IEnumerable<XElement> elements = element.Elements();
            foreach (XElement e in elements)
            {
                var node = new TreeNode(e.Name.LocalName);
                treeNodes.Add(node);
                XElementInitTreeNode(node.Nodes, e);
            }
        }
    }
}
