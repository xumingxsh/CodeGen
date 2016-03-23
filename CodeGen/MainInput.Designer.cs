namespace DockPanelSample
{
    partial class MainInput
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
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.txtDisplayArea2 = new System.Windows.Forms.TextBox();
            this.txtDisplayArea = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // textBox1
            // 
            this.textBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBox1.Location = new System.Drawing.Point(0, 0);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(292, 273);
            this.textBox1.TabIndex = 0;
            // 
            // txtDisplayArea2
            // 
            this.txtDisplayArea2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtDisplayArea2.Location = new System.Drawing.Point(0, 0);
            this.txtDisplayArea2.Multiline = true;
            this.txtDisplayArea2.Name = "txtDisplayArea2";
            this.txtDisplayArea2.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtDisplayArea2.Size = new System.Drawing.Size(201, 124);
            this.txtDisplayArea2.TabIndex = 3;
            this.txtDisplayArea2.Visible = false;
            // 
            // txtDisplayArea
            // 
            this.txtDisplayArea.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtDisplayArea.Location = new System.Drawing.Point(0, 0);
            this.txtDisplayArea.Name = "txtDisplayArea";
            this.txtDisplayArea.Size = new System.Drawing.Size(292, 273);
            this.txtDisplayArea.TabIndex = 4;
            this.txtDisplayArea.Text = "";
            // 
            // MainInput
            // 
            this.ClientSize = new System.Drawing.Size(292, 273);
            this.Controls.Add(this.txtDisplayArea);
            this.Controls.Add(this.txtDisplayArea2);
            this.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Name = "MainInput";
            this.Text = "输出信息";
            this.Load += new System.EventHandler(this.MainInput_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox txtDisplayArea2;
        private System.Windows.Forms.RichTextBox txtDisplayArea;
    }
}