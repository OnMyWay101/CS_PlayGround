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
            ReadTreeViewToXML(treeView1, "hello1.xml");
        }
        private void InitTreeView(string xmlPath)
        {
            XElement xmlInfo = XElement.Load(xmlPath);
            treeView1.BeginUpdate();
            //添加根节点赋值
            var RootNode = new TreeNode(xmlInfo.Name.LocalName);
            treeView1.Nodes.Add(RootNode);
            XElementInitTreeNode(treeView1.Nodes[0].Nodes, xmlInfo);
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

        public bool ReadTreeViewToXML(TreeView tree, string filePath) /*通过TreeView结构生成XML文件*/
        {
            XElement xmlInfo = new XElement(tree.Nodes[0].Text);
            TreeNodeInitXElement(tree.Nodes[0].Nodes, xmlInfo);
            xmlInfo.Save(filePath);
            return true;
        }
        private void TreeNodeInitXElement(TreeNodeCollection treeNodes, XElement element)
        {
            //定义边界条件
            if (treeNodes.Count == 0)
            {
                return;
            }
            foreach (TreeNode node in treeNodes)
            {
                var childElement = new XElement(node.Text);
                element.Add(childElement);
                TreeNodeInitXElement(node.Nodes, childElement);
            }
        }
    }
}





