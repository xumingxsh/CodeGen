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
    public partial class TableMenum : WeifenLuo.WinFormsUI.Docking.DockContent
    {
        public delegate void DBInfoHandle();

        public delegate void SelectHandle(string key);

        public event DBInfoHandle evtDBInfo;
        public event DBInfoHandle evtSQLInfo;
        public event DBInfoHandle evtResourceInfo;
        public event DBInfoHandle evtResxXMLInfo;
        public event SelectHandle evtCodeSelect;
        public event SelectHandle evtConfigSelect;
        public event SelectHandle evtExportSelect;


        public event DBInfoHandle evtResxCodeInfo;

        public TableMenum()
        {
            InitializeComponent();
        }

        private void TableMenum_Load(object sender, EventArgs e)
        {

            try
            {
                BindTree();
            }
            catch //(Exception ex)
            {
                //MessageBox.Show("数据库连接失败，请重新配置数据库连接！" + ex.ToString());

                //ConnectServer server = new ConnectServer();
                //server.ShowDialog();
            }
            finally
            {
            }
        }

        public void BindTree()
        {
            this.tvTable.Nodes.Clear();

            foreach(KeyValuePair<string, List<CodeObject>> item in Template.s_CodeList)
            {
                TreeNode childNode = new TreeNode();
                childNode.Text = item.Key;
                childNode.Tag = item.Key;
                childNode.ImageIndex = 1;
                childNode.SelectedImageIndex = 1;
                childNode.ContextMenuStrip = cmFolderMenu;
                //childNode.Level = 1;

                foreach (CodeObject it in item.Value)
                {
                    TreeNode cn = new TreeNode();
                    cn.Text = it.script;
                    cn.Tag = it.name;
                    cn.ImageIndex = 0;
                    cn.SelectedImageIndex = 5;
                    cn.ContextMenuStrip = cmMenu;
                    //cn.Level = 2;
                    childNode.Nodes.Add(cn);
                }
                this.tvTable.Nodes.Add(childNode);
                this.tvTable.ExpandAll();
            }
        }

        private void btnTBInfo_Click(object sender, EventArgs e)
        {
            this.evtDBInfo();
        }

        private void btnSQL_Click(object sender, EventArgs e)
        {
            this.evtSQLInfo();
        }

        private void btnCongig_Click(object sender, EventArgs e)
        {
            this.evtResourceInfo();
        }

        private void btnResxXML_Click(object sender, EventArgs e)
        {
            this.evtResxXMLInfo();
        }

        private void btnResxCode_Click(object sender, EventArgs e)
        {
            this.evtResxCodeInfo();
        }

        TreeNode preNode = null;
        private void tvTable_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (preNode != null)
            {
                preNode.ForeColor = this.tvTable.SelectedNode.ForeColor;
                preNode.BackColor = this.tvTable.SelectedNode.BackColor;
            }

            this.tvTable.SelectedNode.ForeColor = Color.Red;
            preNode = this.tvTable.SelectedNode;

            if (this.tvTable.SelectedNode != null && this.tvTable.SelectedNode.Level == 1)
            {
                this.evtCodeSelect(this.tvTable.SelectedNode.Tag.ToString());
            }
        }

        private void exPortToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (rightNode == null || rightNode.Level != 1)
            {
                MessageBox.Show("未选中合适的节点");
                return;
            }

            this.evtExportSelect(rightNode.Tag.ToString());   
        }
        TreeNode rightNode = null;
        private void tvTable_MouseDown(object sender, MouseEventArgs e)
        {
            rightNode = tvTable.GetNodeAt(e.X, e.Y);
        }

        private void ex2MenuItem_Click(object sender, EventArgs e)
        {
            this.evtExportSelect("All");   
        }

        private void expGroupMenu_Click(object sender, EventArgs e)
        {
            if (rightNode == null || rightNode.Level != 0)
            {
                MessageBox.Show("未选中合适的节点");
                return;
            }

            this.evtExportSelect("|" + rightNode.Tag.ToString());   
        }
    }
}
