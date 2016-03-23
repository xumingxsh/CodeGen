namespace DockPanelSample
{
    partial class AllTable
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dgTable = new System.Windows.Forms.DataGridView();
            this.TableName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Script = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tableType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgTable)).BeginInit();
            this.SuspendLayout();
            // 
            // dgTable
            // 
            this.dgTable.AllowUserToAddRows = false;
            this.dgTable.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.dgTable.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgTable.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.TableName,
            this.Script,
            this.tableType});
            this.dgTable.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgTable.Location = new System.Drawing.Point(0, 0);
            this.dgTable.Name = "dgTable";
            this.dgTable.RowTemplate.Height = 23;
            this.dgTable.Size = new System.Drawing.Size(284, 262);
            this.dgTable.TabIndex = 0;
            this.dgTable.RowPostPaint += new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(this.dgTable_RowPostPaint);
            // 
            // TableName
            // 
            this.TableName.DataPropertyName = "TableName";
            this.TableName.HeaderText = "名称";
            this.TableName.Name = "TableName";
            this.TableName.Width = 250;
            // 
            // Script
            // 
            this.Script.DataPropertyName = "Script";
            this.Script.HeaderText = "描述";
            this.Script.Name = "Script";
            this.Script.Width = 400;
            // 
            // tableType
            // 
            this.tableType.DataPropertyName = "TableType";
            this.tableType.HeaderText = "类型";
            this.tableType.Name = "tableType";
            // 
            // AllTable
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 262);
            this.Controls.Add(this.dgTable);
            this.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Name = "AllTable";
            this.Text = "所有表";
            this.Load += new System.EventHandler(this.AllTable_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgTable)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgTable;
        private System.Windows.Forms.DataGridViewTextBoxColumn TableName;
        private System.Windows.Forms.DataGridViewTextBoxColumn Script;
        private System.Windows.Forms.DataGridViewTextBoxColumn tableType;
    }
}