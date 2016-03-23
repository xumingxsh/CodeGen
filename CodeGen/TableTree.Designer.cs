namespace DockPanelSample
{
    partial class TableTree
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.TreeNode treeNode1 = new System.Windows.Forms.TreeNode("节点6");
            System.Windows.Forms.TreeNode treeNode2 = new System.Windows.Forms.TreeNode("节点7");
            System.Windows.Forms.TreeNode treeNode3 = new System.Windows.Forms.TreeNode("节点1", new System.Windows.Forms.TreeNode[] {
            treeNode1,
            treeNode2});
            System.Windows.Forms.TreeNode treeNode4 = new System.Windows.Forms.TreeNode("节点8");
            System.Windows.Forms.TreeNode treeNode5 = new System.Windows.Forms.TreeNode("节点9");
            System.Windows.Forms.TreeNode treeNode6 = new System.Windows.Forms.TreeNode("节点10");
            System.Windows.Forms.TreeNode treeNode7 = new System.Windows.Forms.TreeNode("节点2", new System.Windows.Forms.TreeNode[] {
            treeNode4,
            treeNode5,
            treeNode6});
            System.Windows.Forms.TreeNode treeNode8 = new System.Windows.Forms.TreeNode("节点11");
            System.Windows.Forms.TreeNode treeNode9 = new System.Windows.Forms.TreeNode("节点12");
            System.Windows.Forms.TreeNode treeNode10 = new System.Windows.Forms.TreeNode("节点13");
            System.Windows.Forms.TreeNode treeNode11 = new System.Windows.Forms.TreeNode("节点3", new System.Windows.Forms.TreeNode[] {
            treeNode8,
            treeNode9,
            treeNode10});
            System.Windows.Forms.TreeNode treeNode12 = new System.Windows.Forms.TreeNode("节点20");
            System.Windows.Forms.TreeNode treeNode13 = new System.Windows.Forms.TreeNode("节点21");
            System.Windows.Forms.TreeNode treeNode14 = new System.Windows.Forms.TreeNode("节点14", new System.Windows.Forms.TreeNode[] {
            treeNode12,
            treeNode13});
            System.Windows.Forms.TreeNode treeNode15 = new System.Windows.Forms.TreeNode("节点15");
            System.Windows.Forms.TreeNode treeNode16 = new System.Windows.Forms.TreeNode("节点4", new System.Windows.Forms.TreeNode[] {
            treeNode14,
            treeNode15});
            System.Windows.Forms.TreeNode treeNode17 = new System.Windows.Forms.TreeNode("节点18");
            System.Windows.Forms.TreeNode treeNode18 = new System.Windows.Forms.TreeNode("节点19");
            System.Windows.Forms.TreeNode treeNode19 = new System.Windows.Forms.TreeNode("节点16", new System.Windows.Forms.TreeNode[] {
            treeNode17,
            treeNode18});
            System.Windows.Forms.TreeNode treeNode20 = new System.Windows.Forms.TreeNode("节点17");
            System.Windows.Forms.TreeNode treeNode21 = new System.Windows.Forms.TreeNode("节点5", new System.Windows.Forms.TreeNode[] {
            treeNode19,
            treeNode20});
            System.Windows.Forms.TreeNode treeNode22 = new System.Windows.Forms.TreeNode("节点0", new System.Windows.Forms.TreeNode[] {
            treeNode3,
            treeNode7,
            treeNode11,
            treeNode16,
            treeNode21});
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TableTree));
            this.tvTable = new System.Windows.Forms.TreeView();
            this.tableName = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.imglTreeView = new System.Windows.Forms.ImageList(this.components);
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tvTable
            // 
            this.tvTable.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tvTable.ImageIndex = 0;
            this.tvTable.ImageList = this.imglTreeView;
            this.tvTable.Location = new System.Drawing.Point(0, 0);
            this.tvTable.Name = "tvTable";
            treeNode1.Name = "节点6";
            treeNode1.Text = "节点6";
            treeNode2.Name = "节点7";
            treeNode2.Text = "节点7";
            treeNode3.Name = "节点1";
            treeNode3.Text = "节点1";
            treeNode4.Name = "节点8";
            treeNode4.Text = "节点8";
            treeNode5.Name = "节点9";
            treeNode5.Text = "节点9";
            treeNode6.Name = "节点10";
            treeNode6.Text = "节点10";
            treeNode7.Name = "节点2";
            treeNode7.Text = "节点2";
            treeNode8.Name = "节点11";
            treeNode8.Text = "节点11";
            treeNode9.Name = "节点12";
            treeNode9.Text = "节点12";
            treeNode10.Name = "节点13";
            treeNode10.Text = "节点13";
            treeNode11.Name = "节点3";
            treeNode11.Text = "节点3";
            treeNode12.Name = "节点20";
            treeNode12.Text = "节点20";
            treeNode13.Name = "节点21";
            treeNode13.Text = "节点21";
            treeNode14.Name = "节点14";
            treeNode14.Text = "节点14";
            treeNode15.Name = "节点15";
            treeNode15.Text = "节点15";
            treeNode16.Name = "节点4";
            treeNode16.Text = "节点4";
            treeNode17.Name = "节点18";
            treeNode17.Text = "节点18";
            treeNode18.Name = "节点19";
            treeNode18.Text = "节点19";
            treeNode19.Name = "节点16";
            treeNode19.Text = "节点16";
            treeNode20.Name = "节点17";
            treeNode20.Text = "节点17";
            treeNode21.Name = "节点5";
            treeNode21.Text = "节点5";
            treeNode22.Name = "节点0";
            treeNode22.Text = "节点0";
            this.tvTable.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode22});
            this.tvTable.SelectedImageIndex = 0;
            this.tvTable.Size = new System.Drawing.Size(331, 359);
            this.tvTable.TabIndex = 0;
            this.tvTable.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.tvTable_AfterSelect);
            // 
            // tableName
            // 
            this.tableName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tableName.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableName.Location = new System.Drawing.Point(0, 0);
            this.tableName.Name = "tableName";
            this.tableName.ReadOnly = true;
            this.tableName.Size = new System.Drawing.Size(331, 21);
            this.tableName.TabIndex = 1;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.tvTable);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 21);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(331, 359);
            this.panel1.TabIndex = 2;
            // 
            // imglTreeView
            // 
            this.imglTreeView.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imglTreeView.ImageStream")));
            this.imglTreeView.TransparentColor = System.Drawing.Color.Transparent;
            this.imglTreeView.Images.SetKeyName(0, "table.ico");
            this.imglTreeView.Images.SetKeyName(1, "usertable.ico");
            this.imglTreeView.Images.SetKeyName(2, "ProList.ico");
            this.imglTreeView.Images.SetKeyName(3, "Pro.ico");
            this.imglTreeView.Images.SetKeyName(4, "produceSel.ico");
            this.imglTreeView.Images.SetKeyName(5, "tbSel.ICO");
            this.imglTreeView.Images.SetKeyName(6, "View.ICO");
            this.imglTreeView.Images.SetKeyName(7, "ViewSel.ico");
            this.imglTreeView.Images.SetKeyName(8, "ViewList.ico");
            // 
            // TableTree
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(331, 380);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.tableName);
            this.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Name = "TableTree";
            this.Text = "数据库表";
            this.Load += new System.EventHandler(this.TableTree_Load);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TreeView tvTable;
        private System.Windows.Forms.TextBox tableName;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ImageList imglTreeView;

    }
}