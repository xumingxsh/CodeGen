using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace CodeGen
{
	/// <summary>
	/// ConnectServer 的摘要说明。
	/// </summary>
	public class ConnectServer : System.Windows.Forms.Form
	{
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.Button button2;
		private System.Windows.Forms.TextBox serverName;
		private System.Windows.Forms.TextBox dataBase;
		private System.Windows.Forms.TextBox userID;
		private System.Windows.Forms.TextBox passWord;
        private Label label5;
        private RadioButton rdbSql2000;
        private RadioButton rdbSQL2005;
        private RadioButton rdbMySQL;
        private TextBox port;
        private Label label6;
        private RadioButton rdbOracle;
		/// <summary>
		/// 必需的设计器变量。
		/// </summary>
		private System.ComponentModel.Container components = null;

		public ConnectServer()
		{
			//
			// Windows 窗体设计器支持所必需的
			//
			InitializeComponent();

			//
			// TODO: 在 InitializeComponent 调用后添加任何构造函数代码
			//
		}

		/// <summary>
		/// 清理所有正在使用的资源。
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if(components != null)
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		#region Windows 窗体设计器生成的代码
		/// <summary>
		/// 设计器支持所需的方法 - 不要使用代码编辑器修改
		/// 此方法的内容。
		/// </summary>
		private void InitializeComponent()
		{
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ConnectServer));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.port = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.rdbMySQL = new System.Windows.Forms.RadioButton();
            this.rdbSQL2005 = new System.Windows.Forms.RadioButton();
            this.rdbSql2000 = new System.Windows.Forms.RadioButton();
            this.label5 = new System.Windows.Forms.Label();
            this.passWord = new System.Windows.Forms.TextBox();
            this.userID = new System.Windows.Forms.TextBox();
            this.dataBase = new System.Windows.Forms.TextBox();
            this.serverName = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.rdbOracle = new System.Windows.Forms.RadioButton();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rdbOracle);
            this.groupBox1.Controls.Add(this.port);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.rdbMySQL);
            this.groupBox1.Controls.Add(this.rdbSQL2005);
            this.groupBox1.Controls.Add(this.rdbSql2000);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.passWord);
            this.groupBox1.Controls.Add(this.userID);
            this.groupBox1.Controls.Add(this.dataBase);
            this.groupBox1.Controls.Add(this.serverName);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.groupBox1.Location = new System.Drawing.Point(0, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(288, 290);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "服务器信息";
            // 
            // port
            // 
            this.port.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.port.Location = new System.Drawing.Point(104, 55);
            this.port.Name = "port";
            this.port.Size = new System.Drawing.Size(168, 21);
            this.port.TabIndex = 13;
            this.port.Text = "3306";
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(16, 55);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(72, 23);
            this.label6.TabIndex = 12;
            this.label6.Text = "端口：";
            // 
            // rdbMySQL
            // 
            this.rdbMySQL.AutoSize = true;
            this.rdbMySQL.Location = new System.Drawing.Point(102, 239);
            this.rdbMySQL.Name = "rdbMySQL";
            this.rdbMySQL.Size = new System.Drawing.Size(53, 16);
            this.rdbMySQL.TabIndex = 11;
            this.rdbMySQL.Text = "MySQL";
            this.rdbMySQL.UseVisualStyleBackColor = true;
            // 
            // rdbSQL2005
            // 
            this.rdbSQL2005.AutoSize = true;
            this.rdbSQL2005.Location = new System.Drawing.Point(102, 217);
            this.rdbSQL2005.Name = "rdbSQL2005";
            this.rdbSQL2005.Size = new System.Drawing.Size(101, 16);
            this.rdbSQL2005.TabIndex = 10;
            this.rdbSQL2005.Text = "SQLServer2005";
            this.rdbSQL2005.UseVisualStyleBackColor = true;
            // 
            // rdbSql2000
            // 
            this.rdbSql2000.AutoSize = true;
            this.rdbSql2000.Checked = true;
            this.rdbSql2000.Location = new System.Drawing.Point(104, 195);
            this.rdbSql2000.Name = "rdbSql2000";
            this.rdbSql2000.Size = new System.Drawing.Size(101, 16);
            this.rdbSql2000.TabIndex = 9;
            this.rdbSql2000.TabStop = true;
            this.rdbSql2000.Text = "SQLServer2000";
            this.rdbSql2000.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(16, 195);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(80, 23);
            this.label5.TabIndex = 8;
            this.label5.Text = "数据库类型：";
            // 
            // passWord
            // 
            this.passWord.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.passWord.Location = new System.Drawing.Point(104, 157);
            this.passWord.Name = "passWord";
            this.passWord.PasswordChar = '*';
            this.passWord.Size = new System.Drawing.Size(168, 21);
            this.passWord.TabIndex = 7;
            // 
            // userID
            // 
            this.userID.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.userID.Location = new System.Drawing.Point(104, 117);
            this.userID.Name = "userID";
            this.userID.Size = new System.Drawing.Size(168, 21);
            this.userID.TabIndex = 6;
            // 
            // dataBase
            // 
            this.dataBase.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.dataBase.Location = new System.Drawing.Point(104, 85);
            this.dataBase.Name = "dataBase";
            this.dataBase.Size = new System.Drawing.Size(168, 21);
            this.dataBase.TabIndex = 5;
            // 
            // serverName
            // 
            this.serverName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.serverName.Location = new System.Drawing.Point(104, 24);
            this.serverName.Name = "serverName";
            this.serverName.Size = new System.Drawing.Size(168, 21);
            this.serverName.TabIndex = 4;
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(16, 157);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(72, 23);
            this.label4.TabIndex = 3;
            this.label4.Text = "密码：";
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(16, 117);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(72, 23);
            this.label3.TabIndex = 2;
            this.label3.Text = "用户：";
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(16, 85);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(72, 23);
            this.label2.TabIndex = 1;
            this.label2.Text = "数据库：";
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(16, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(80, 23);
            this.label1.TabIndex = 0;
            this.label1.Text = "服务器：";
            // 
            // button1
            // 
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Location = new System.Drawing.Point(119, 304);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 25);
            this.button1.TabIndex = 1;
            this.button1.Text = "保存(&S)";
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Location = new System.Drawing.Point(200, 304);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 25);
            this.button2.TabIndex = 2;
            this.button2.Text = "取消(&C)";
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // rdbOracle
            // 
            this.rdbOracle.AutoSize = true;
            this.rdbOracle.Location = new System.Drawing.Point(104, 261);
            this.rdbOracle.Name = "rdbOracle";
            this.rdbOracle.Size = new System.Drawing.Size(77, 16);
            this.rdbOracle.TabIndex = 14;
            this.rdbOracle.Text = "Oracle11g";
            this.rdbOracle.UseVisualStyleBackColor = true;
            // 
            // ConnectServer
            // 
            this.AcceptButton = this.button1;
            this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
            this.ClientSize = new System.Drawing.Size(296, 336);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "ConnectServer";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "服务器信息";
            this.Load += new System.EventHandler(this.ConnectServer_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

		}
		#endregion

		private void button2_Click(object sender, System.EventArgs e)
		{
			this.Close();
		}

		private void ConnectServer_Load(object sender, System.EventArgs e)
        {
            this.serverName.Text = RegisterAccess.ReadKey("serverName");
            this.dataBase.Text = RegisterAccess.ReadKey("dataBase");
            this.userID.Text = RegisterAccess.ReadKey("userID");
            this.passWord.Text = RegisterAccess.ReadKey("passWord");
            this.port.Text = RegisterAccess.ReadKey("port");
            if (this.port.Text.Trim() == "")
            {
                this.port.Text = "3306";
            }
            if (RegisterAccess.ReadKey("DBType").Equals("SQLSERVER2005"))
            {
                rdbSQL2005.Checked = true;
                rdbSql2000.Checked = false;
                rdbMySQL.Checked = false;
                rdbOracle.Checked = false;
            }
            else if (RegisterAccess.ReadKey("DBType").Equals("SQLSERVER2000"))
            {
                rdbSQL2005.Checked = false;
                rdbSql2000.Checked = true;
                rdbMySQL.Checked = false;
                rdbOracle.Checked = false;
            }
            else if (RegisterAccess.ReadKey("DBType").Equals("MYSQL"))
            {
                rdbSQL2005.Checked = false;
                rdbSql2000.Checked = false;
                rdbMySQL.Checked = true;
                rdbOracle.Checked = false;
            }
            else if (RegisterAccess.ReadKey("DBType").Equals("ORACLE11G"))
            {
                rdbSQL2005.Checked = false;
                rdbSql2000.Checked = false;
                rdbMySQL.Checked = false;
                rdbOracle.Checked = true;
            }
		}

		private void button1_Click(object sender, System.EventArgs e)
		{
			RegisterAccess.WriteKey("serverName",this.serverName.Text);
			RegisterAccess.WriteKey("dataBase",this.dataBase.Text);
			RegisterAccess.WriteKey("userID",this.userID.Text);
            RegisterAccess.WriteKey("passWord", this.passWord.Text);
            RegisterAccess.WriteKey("port", this.port.Text);

            if (rdbSql2000.Checked)
            {
                RegisterAccess.WriteKey("DBType", "SQLSERVER2000");
            }
            else if (rdbSQL2005.Checked)
            {
                RegisterAccess.WriteKey("DBType", "SQLSERVER2005");
            }
            else if (rdbMySQL.Checked)
            {
                RegisterAccess.WriteKey("DBType", "MYSQL");
            }
            else if (rdbOracle.Checked)
            {
                RegisterAccess.WriteKey("DBType", "ORACLE11G");
            }
            DataMarket.SetTableDataSetNull();


            this.DialogResult = DialogResult.OK;
		}
	}
}
