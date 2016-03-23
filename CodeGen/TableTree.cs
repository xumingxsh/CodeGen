using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using CodeGen;

namespace DockPanelSample
{
    public partial class TableTree : WeifenLuo.WinFormsUI.Docking.DockContent 
    {
        public delegate void SelectTableHandle(int id);
        public event SelectTableHandle OnSelect; 

        public TableTree()
        {
            InitializeComponent();
        }

        private void TableTree_Load(object sender, EventArgs e)
        {
            try
            {
                //this.BindTree();
            }
            catch //(Exception ex)
            {
                //this.tvTable.Enabled = false;
                //MessageBox.Show(string.Format("数据库连接失败，原因：{0}", ex.ToString()));

                //ConnectServer server = new ConnectServer();
                //server.ShowDialog();
            }
        }

        public void BindTree()
        {
            this.BindTable();
            this.tvTable.Enabled = true;
        }

        private void BindTable()
        {
            this.SetNodes();
        }

        /// <summary>
        /// 设置子节点
        /// </summary>
        /// <param name="node">父节点</param>
        /// <author>天志</author>
        /// <log date="2007-09-01">创建</log>
        private void SetNodes()
        {
            this.tvTable.Nodes.Clear();

            // 添加表
            AddTable2Tree();

            // 添加视图
            AddView2Tree();

            // 添加存储过程
            AddProduce2Tree();

            this.tvTable.ExpandAll();
        }

        TreeNode preNode = null;
        private void tvTable_AfterSelect(object sender, TreeViewEventArgs e)
        {

            this.tableName.Text = this.tvTable.SelectedNode.Text;

            if (preNode != null)
            {
                preNode.ForeColor = this.tvTable.SelectedNode.ForeColor;
                preNode.BackColor = this.tvTable.SelectedNode.BackColor;
            }

            this.tvTable.SelectedNode.ForeColor = Color.Red;
            preNode = this.tvTable.SelectedNode; 
            
            if (this.tvTable.SelectedNode != null && (string)this.tvTable.SelectedNode.Tag != "")
            {
                this.OnSelect(Convert.ToInt32(this.tvTable.SelectedNode.Tag));
            }
            else
            {
                this.OnSelect(-1);
            }
        }

        private void AddTable2Tree()
        {

            DataView dv = DataMarket.GetUserTable();
            dv.Sort = "TableName";
            List<TableExpandDT> list = new List<TableExpandDT>();
            foreach (DataRowView drv in dv)
            {
                list.Add(new TableExpandDT(drv));
            }

            TreeNode childNode = new TreeNode();
            childNode.Text = "用户表（" + list.Count + "）";
            childNode.Tag = "";
            childNode.ImageIndex = 1;
            childNode.SelectedImageIndex = 1;
            TreeNode childNode2;

            foreach (TableExpandDT dt in list)
            {
                childNode2 = new TreeNode();
                childNode2.Text = dt.TableName + "-" + dt.Script;
                childNode2.Tag = dt.Id.ToString();
                childNode2.ImageIndex = 0;
                childNode2.SelectedImageIndex = 5;
                childNode.Nodes.Add(childNode2);
            }
            childNode.ExpandAll();
            this.tvTable.Nodes.Add(childNode);
        }

        private void AddView2Tree()
        {
            TreeNode childNode = new TreeNode();
            childNode.ImageIndex = 8;
            childNode.SelectedImageIndex = 8;
            childNode.Tag = "";

            // 添加视图
            DataView dv = DataMarket.GetView();
            dv.Sort = "script";
            List<TableExpandDT> list2 = new List<TableExpandDT>();
            foreach (DataRowView drv in dv)
            {
                list2.Add(new TableExpandDT(drv));
            }
            list2.Sort(delegate(TableExpandDT a, TableExpandDT b) { return a.TableName.CompareTo(b.TableName); });
            childNode.Text = "视图（" + list2.Count + ")";
            foreach (TableExpandDT dt in list2)
            {
                TreeNode childNode2 = new TreeNode();
                childNode2.Text = dt.TableName + "-" + dt.Script;
                childNode2.Tag = dt.Id.ToString();
                childNode2.ImageIndex = 6;
                childNode2.SelectedImageIndex = 7;
                childNode.Nodes.Add(childNode2);
            }
            this.tvTable.Nodes.Add(childNode);
        }

        private void AddProduce2Tree()
        {
            TreeNode childNode = new TreeNode();
            childNode.ImageIndex = 2;
            childNode.SelectedImageIndex = 2;
            childNode.Tag = "";

            // 添加存储过程
           DataView  dv = DataMarket.GetProduce();
            dv.Sort = "script";
            List<TableExpandDT> list3 = new List<TableExpandDT>();
            foreach (DataRowView drv in dv)
            {
                list3.Add(new TableExpandDT(drv));
            }
            childNode.Text = "存储过程（" + list3.Count + ")";
            foreach (TableExpandDT dt in list3)
            {
                TreeNode childNode2 = new TreeNode();
                childNode2.Text = dt.Script;
                childNode2.Tag = dt.Id.ToString();
                childNode2.ImageIndex = 3;
                childNode2.SelectedImageIndex = 4;
                childNode.Nodes.Add(childNode2);
            }
            this.tvTable.Nodes.Add(childNode);
        }
    }
}