namespace DockPanelSample
{
    partial class TableMenum
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TableMenum));
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnResxCode = new System.Windows.Forms.Button();
            this.btnResxXML = new System.Windows.Forms.Button();
            this.btnCongig = new System.Windows.Forms.Button();
            this.btnSQL = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.tvTable = new System.Windows.Forms.TreeView();
            this.imglTreeView = new System.Windows.Forms.ImageList(this.components);
            this.cmMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.exPortToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ex2MenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cmFolderMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.expGroupMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.cmMenu.SuspendLayout();
            this.cmFolderMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.AutoScroll = true;
            this.panel1.Controls.Add(this.btnResxCode);
            this.panel1.Controls.Add(this.btnResxXML);
            this.panel1.Controls.Add(this.btnCongig);
            this.panel1.Controls.Add(this.btnSQL);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 448);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(118, 123);
            this.panel1.TabIndex = 0;
            // 
            // btnResxCode
            // 
            this.btnResxCode.BackColor = System.Drawing.SystemColors.Control;
            this.btnResxCode.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnResxCode.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnResxCode.Location = new System.Drawing.Point(3, 91);
            this.btnResxCode.Name = "btnResxCode";
            this.btnResxCode.Size = new System.Drawing.Size(82, 24);
            this.btnResxCode.TabIndex = 36;
            this.btnResxCode.Text = "国际化代码整体";
            this.btnResxCode.UseVisualStyleBackColor = false;
            this.btnResxCode.Click += new System.EventHandler(this.btnResxCode_Click);
            // 
            // btnResxXML
            // 
            this.btnResxXML.BackColor = System.Drawing.SystemColors.Control;
            this.btnResxXML.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnResxXML.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnResxXML.Location = new System.Drawing.Point(3, 63);
            this.btnResxXML.Name = "btnResxXML";
            this.btnResxXML.Size = new System.Drawing.Size(82, 24);
            this.btnResxXML.TabIndex = 35;
            this.btnResxXML.Text = "国际化整体";
            this.btnResxXML.UseVisualStyleBackColor = false;
            this.btnResxXML.Click += new System.EventHandler(this.btnResxXML_Click);
            // 
            // btnCongig
            // 
            this.btnCongig.BackColor = System.Drawing.SystemColors.Control;
            this.btnCongig.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCongig.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCongig.Location = new System.Drawing.Point(3, 35);
            this.btnCongig.Name = "btnCongig";
            this.btnCongig.Size = new System.Drawing.Size(64, 24);
            this.btnCongig.TabIndex = 33;
            this.btnCongig.Text = "资源整体";
            this.btnCongig.UseVisualStyleBackColor = false;
            this.btnCongig.Click += new System.EventHandler(this.btnCongig_Click);
            // 
            // btnSQL
            // 
            this.btnSQL.BackColor = System.Drawing.SystemColors.Control;
            this.btnSQL.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSQL.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnSQL.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSQL.Location = new System.Drawing.Point(3, 6);
            this.btnSQL.Name = "btnSQL";
            this.btnSQL.Size = new System.Drawing.Size(58, 24);
            this.btnSQL.TabIndex = 32;
            this.btnSQL.Text = "SQL整体";
            this.btnSQL.UseVisualStyleBackColor = false;
            this.btnSQL.Click += new System.EventHandler(this.btnSQL_Click);
            // 
            // panel2
            // 
            this.panel2.AutoScroll = true;
            this.panel2.Controls.Add(this.tvTable);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(118, 448);
            this.panel2.TabIndex = 1;
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
            this.tvTable.Size = new System.Drawing.Size(118, 448);
            this.tvTable.TabIndex = 32;
            this.tvTable.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.tvTable_AfterSelect);
            this.tvTable.MouseDown += new System.Windows.Forms.MouseEventHandler(this.tvTable_MouseDown);
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
            // cmMenu
            // 
            this.cmMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.exPortToolStripMenuItem,
            this.ex2MenuItem});
            this.cmMenu.Name = "cmMenu";
            this.cmMenu.Size = new System.Drawing.Size(155, 48);
            // 
            // exPortToolStripMenuItem
            // 
            this.exPortToolStripMenuItem.Name = "exPortToolStripMenuItem";
            this.exPortToolStripMenuItem.Size = new System.Drawing.Size(154, 22);
            this.exPortToolStripMenuItem.Text = "导出所有表代码";
            this.exPortToolStripMenuItem.Click += new System.EventHandler(this.exPortToolStripMenuItem_Click);
            // 
            // ex2MenuItem
            // 
            this.ex2MenuItem.Name = "ex2MenuItem";
            this.ex2MenuItem.Size = new System.Drawing.Size(154, 22);
            this.ex2MenuItem.Text = "导出所有代码";
            this.ex2MenuItem.Click += new System.EventHandler(this.ex2MenuItem_Click);
            // 
            // cmFolderMenu
            // 
            this.cmFolderMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.expGroupMenu});
            this.cmFolderMenu.Name = "cmMenu";
            this.cmFolderMenu.Size = new System.Drawing.Size(143, 26);
            // 
            // expGroupMenu
            // 
            this.expGroupMenu.Name = "expGroupMenu";
            this.expGroupMenu.Size = new System.Drawing.Size(142, 22);
            this.expGroupMenu.Text = "按组导出代码";
            this.expGroupMenu.Click += new System.EventHandler(this.expGroupMenu_Click);
            // 
            // TableMenum
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(118, 571);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Name = "TableMenum";
            this.Text = "操作菜单";
            this.Load += new System.EventHandler(this.TableMenum_Load);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.cmMenu.ResumeLayout(false);
            this.cmFolderMenu.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnResxCode;
        private System.Windows.Forms.Button btnResxXML;
        private System.Windows.Forms.Button btnCongig;
        private System.Windows.Forms.Button btnSQL;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TreeView tvTable;
        private System.Windows.Forms.ImageList imglTreeView;
        private System.Windows.Forms.ContextMenuStrip cmMenu;
        private System.Windows.Forms.ToolStripMenuItem exPortToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ex2MenuItem;
        private System.Windows.Forms.ContextMenuStrip cmFolderMenu;
        private System.Windows.Forms.ToolStripMenuItem expGroupMenu;
    }
}