namespace DockPanelSample
{
    partial class Records
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.txtInputArea2 = new System.Windows.Forms.TextBox();
            this.btnGetCode = new System.Windows.Forms.Button();
            this.dgList = new System.Windows.Forms.DataGridView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel6 = new System.Windows.Forms.Panel();
            this.txtLog = new System.Windows.Forms.TextBox();
            this.panel5 = new System.Windows.Forms.Panel();
            this.btnCSV = new System.Windows.Forms.Button();
            this.btnExecuteNoQuery = new System.Windows.Forms.Button();
            this.panel4 = new System.Windows.Forms.Panel();
            this.sfCSV = new System.Windows.Forms.SaveFileDialog();
            this.txtInputArea = new System.Windows.Forms.RichTextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgList)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel6.SuspendLayout();
            this.panel5.SuspendLayout();
            this.panel4.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtInputArea2
            // 
            this.txtInputArea2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtInputArea2.Location = new System.Drawing.Point(0, 0);
            this.txtInputArea2.Multiline = true;
            this.txtInputArea2.Name = "txtInputArea2";
            this.txtInputArea2.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtInputArea2.Size = new System.Drawing.Size(356, 37);
            this.txtInputArea2.TabIndex = 7;
            this.txtInputArea2.Visible = false;
            // 
            // btnGetCode
            // 
            this.btnGetCode.Location = new System.Drawing.Point(0, 5);
            this.btnGetCode.Name = "btnGetCode";
            this.btnGetCode.Size = new System.Drawing.Size(75, 23);
            this.btnGetCode.TabIndex = 8;
            this.btnGetCode.Text = "查询";
            this.btnGetCode.UseVisualStyleBackColor = true;
            this.btnGetCode.Click += new System.EventHandler(this.btnGetCode_Click);
            // 
            // dgList
            // 
            this.dgList.AllowUserToAddRows = false;
            this.dgList.AllowUserToDeleteRows = false;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.dgList.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle3;
            this.dgList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgList.Location = new System.Drawing.Point(0, 0);
            this.dgList.Name = "dgList";
            this.dgList.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.dgList.RowTemplate.Height = 23;
            this.dgList.Size = new System.Drawing.Size(544, 237);
            this.dgList.TabIndex = 9;
            this.dgList.RowPostPaint += new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(this.dgList_RowPostPaint);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(544, 115);
            this.panel1.TabIndex = 10;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.txtInputArea);
            this.panel3.Controls.Add(this.txtInputArea2);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(544, 74);
            this.panel3.TabIndex = 10;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.panel6);
            this.panel2.Controls.Add(this.panel5);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 74);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(544, 41);
            this.panel2.TabIndex = 9;
            // 
            // panel6
            // 
            this.panel6.Controls.Add(this.txtLog);
            this.panel6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel6.Location = new System.Drawing.Point(189, 0);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(355, 41);
            this.panel6.TabIndex = 1;
            // 
            // txtLog
            // 
            this.txtLog.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtLog.Location = new System.Drawing.Point(0, 0);
            this.txtLog.Multiline = true;
            this.txtLog.Name = "txtLog";
            this.txtLog.ReadOnly = true;
            this.txtLog.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtLog.Size = new System.Drawing.Size(355, 41);
            this.txtLog.TabIndex = 9;
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.btnCSV);
            this.panel5.Controls.Add(this.btnExecuteNoQuery);
            this.panel5.Controls.Add(this.btnGetCode);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel5.Location = new System.Drawing.Point(0, 0);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(189, 41);
            this.panel5.TabIndex = 0;
            // 
            // btnCSV
            // 
            this.btnCSV.Location = new System.Drawing.Point(81, 6);
            this.btnCSV.Name = "btnCSV";
            this.btnCSV.Size = new System.Drawing.Size(75, 23);
            this.btnCSV.TabIndex = 10;
            this.btnCSV.Text = "保存csv";
            this.btnCSV.UseVisualStyleBackColor = true;
            this.btnCSV.Click += new System.EventHandler(this.btnCSV_Click);
            // 
            // btnExecuteNoQuery
            // 
            this.btnExecuteNoQuery.Location = new System.Drawing.Point(12, 15);
            this.btnExecuteNoQuery.Name = "btnExecuteNoQuery";
            this.btnExecuteNoQuery.Size = new System.Drawing.Size(75, 23);
            this.btnExecuteNoQuery.TabIndex = 9;
            this.btnExecuteNoQuery.Text = "执行";
            this.btnExecuteNoQuery.UseVisualStyleBackColor = true;
            this.btnExecuteNoQuery.Visible = false;
            this.btnExecuteNoQuery.Click += new System.EventHandler(this.btnExecuteNoQuery_Click);
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.dgList);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel4.Location = new System.Drawing.Point(0, 115);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(544, 237);
            this.panel4.TabIndex = 11;
            // 
            // txtInputArea
            // 
            this.txtInputArea.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtInputArea.Location = new System.Drawing.Point(0, 0);
            this.txtInputArea.Name = "txtInputArea";
            this.txtInputArea.Size = new System.Drawing.Size(544, 74);
            this.txtInputArea.TabIndex = 10;
            this.txtInputArea.Text = "";
            this.txtInputArea.TextChanged += new System.EventHandler(this.txtInputArea_TextChanged);
            // 
            // Records
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(544, 352);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Name = "Records";
            this.Text = "SQL查询";
            ((System.ComponentModel.ISupportInitialize)(this.dgList)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel6.ResumeLayout(false);
            this.panel6.PerformLayout();
            this.panel5.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox txtInputArea2;
        private System.Windows.Forms.Button btnGetCode;
        private System.Windows.Forms.DataGridView dgList;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.TextBox txtLog;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Button btnExecuteNoQuery;
        private System.Windows.Forms.Button btnCSV;
        private System.Windows.Forms.SaveFileDialog sfCSV;
        private System.Windows.Forms.RichTextBox txtInputArea;
    }
}