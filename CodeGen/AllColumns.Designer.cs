namespace DockPanelSample
{
    partial class AllColumns
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dgvColumns = new System.Windows.Forms.DataGridView();
            this.ColumnName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CNName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TableName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TableCName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IsNullable = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.Length = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Decimaldigits = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DefaultValue = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IsMarking = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvColumns)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvColumns
            // 
            this.dgvColumns.AllowUserToAddRows = false;
            this.dgvColumns.AllowUserToDeleteRows = false;
            this.dgvColumns.AllowUserToOrderColumns = true;
            this.dgvColumns.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.dgvColumns.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvColumns.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvColumns.BackgroundColor = System.Drawing.SystemColors.ButtonFace;
            this.dgvColumns.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvColumns.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColumnName,
            this.CNName,
            this.ColumnType,
            this.TableName,
            this.TableCName,
            this.IsNullable,
            this.Length,
            this.Decimaldigits,
            this.DefaultValue,
            this.IsMarking});
            this.dgvColumns.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvColumns.Location = new System.Drawing.Point(0, 0);
            this.dgvColumns.Name = "dgvColumns";
            this.dgvColumns.ReadOnly = true;
            this.dgvColumns.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvColumns.RowHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvColumns.RowHeadersWidth = 20;
            this.dgvColumns.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dgvColumns.RowTemplate.Height = 23;
            this.dgvColumns.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvColumns.Size = new System.Drawing.Size(296, 278);
            this.dgvColumns.TabIndex = 28;
            this.dgvColumns.RowPostPaint += new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(this.dgvColumns_RowPostPaint);
            // 
            // ColumnName
            // 
            this.ColumnName.DataPropertyName = "ColumnName";
            this.ColumnName.HeaderText = "列名称";
            this.ColumnName.Name = "ColumnName";
            this.ColumnName.ReadOnly = true;
            this.ColumnName.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // CNName
            // 
            this.CNName.DataPropertyName = "CNName";
            this.CNName.HeaderText = "列描述";
            this.CNName.Name = "CNName";
            this.CNName.ReadOnly = true;
            this.CNName.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            // 
            // ColumnType
            // 
            this.ColumnType.DataPropertyName = "ColumnType";
            this.ColumnType.HeaderText = "数据类型";
            this.ColumnType.Name = "ColumnType";
            this.ColumnType.ReadOnly = true;
            // 
            // TableName
            // 
            this.TableName.DataPropertyName = "TableName";
            this.TableName.HeaderText = "表名称";
            this.TableName.Name = "TableName";
            this.TableName.ReadOnly = true;
            // 
            // TableCName
            // 
            this.TableCName.DataPropertyName = "TableCName";
            this.TableCName.HeaderText = "表描述";
            this.TableCName.Name = "TableCName";
            this.TableCName.ReadOnly = true;
            // 
            // IsNullable
            // 
            this.IsNullable.DataPropertyName = "IsNullable";
            this.IsNullable.HeaderText = "可为空";
            this.IsNullable.Name = "IsNullable";
            this.IsNullable.ReadOnly = true;
            this.IsNullable.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.IsNullable.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // Length
            // 
            this.Length.DataPropertyName = "Length";
            this.Length.HeaderText = "长度";
            this.Length.Name = "Length";
            this.Length.ReadOnly = true;
            // 
            // Decimaldigits
            // 
            this.Decimaldigits.DataPropertyName = "Decimaldigits";
            this.Decimaldigits.HeaderText = "小数点位数";
            this.Decimaldigits.Name = "Decimaldigits";
            this.Decimaldigits.ReadOnly = true;
            // 
            // DefaultValue
            // 
            this.DefaultValue.DataPropertyName = "DefaultValue";
            this.DefaultValue.HeaderText = "默认值";
            this.DefaultValue.Name = "DefaultValue";
            this.DefaultValue.ReadOnly = true;
            // 
            // IsMarking
            // 
            this.IsMarking.DataPropertyName = "IsMarking";
            this.IsMarking.HeaderText = "是否自增";
            this.IsMarking.Name = "IsMarking";
            this.IsMarking.ReadOnly = true;
            this.IsMarking.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.IsMarking.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // AllColumns
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(296, 278);
            this.Controls.Add(this.dgvColumns);
            this.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Name = "AllColumns";
            this.Text = "所有列信息";
            this.Load += new System.EventHandler(this.AllColumns_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvColumns)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvColumns;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnName;
        private System.Windows.Forms.DataGridViewTextBoxColumn CNName;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnType;
        private System.Windows.Forms.DataGridViewTextBoxColumn TableName;
        private System.Windows.Forms.DataGridViewTextBoxColumn TableCName;
        private System.Windows.Forms.DataGridViewCheckBoxColumn IsNullable;
        private System.Windows.Forms.DataGridViewTextBoxColumn Length;
        private System.Windows.Forms.DataGridViewTextBoxColumn Decimaldigits;
        private System.Windows.Forms.DataGridViewTextBoxColumn DefaultValue;
        private System.Windows.Forms.DataGridViewCheckBoxColumn IsMarking;
    }
}