using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace CodeGen
{
	/// <summary>
	/// PersonalInfo 的摘要说明。
	/// </summary>
	public class PersonalInfo:System.Windows.Forms.Form
	{
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox corpName;
		private System.Windows.Forms.TextBox userName;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.TextBox structureName;
		private System.Windows.Forms.TextBox DALName;
		private System.Windows.Forms.TextBox BLLName;
		private System.Windows.Forms.Button save;
		private System.Windows.Forms.Button cancel;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.TextBox eMail;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.TextBox VIEWName;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.TextBox SQLName;
		/// <summary>
		/// 必需的设计器变量。
		/// </summary>
		private System.ComponentModel.Container components = null;

		public PersonalInfo()
		{
			//
			// Windows 窗体设计器支持所必需的
			//
			InitializeComponent();

			//
			// TODO:在 InitializeComponent 调用后添加任何构造函数代码
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PersonalInfo));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.eMail = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.userName = new System.Windows.Forms.TextBox();
            this.corpName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.structureName = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.VIEWName = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.SQLName = new System.Windows.Forms.TextBox();
            this.BLLName = new System.Windows.Forms.TextBox();
            this.DALName = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.save = new System.Windows.Forms.Button();
            this.cancel = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.eMail);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.userName);
            this.groupBox1.Controls.Add(this.corpName);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.groupBox1.Location = new System.Drawing.Point(8, 10);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(280, 102);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "使用者信息";
            // 
            // eMail
            // 
            this.eMail.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.eMail.Location = new System.Drawing.Point(112, 72);
            this.eMail.Name = "eMail";
            this.eMail.Size = new System.Drawing.Size(160, 21);
            this.eMail.TabIndex = 7;
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(8, 72);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(100, 23);
            this.label6.TabIndex = 6;
            this.label6.Text = "EMail：";
            // 
            // userName
            // 
            this.userName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.userName.Location = new System.Drawing.Point(112, 48);
            this.userName.Name = "userName";
            this.userName.Size = new System.Drawing.Size(160, 21);
            this.userName.TabIndex = 5;
            // 
            // corpName
            // 
            this.corpName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.corpName.Location = new System.Drawing.Point(112, 24);
            this.corpName.Name = "corpName";
            this.corpName.Size = new System.Drawing.Size(160, 21);
            this.corpName.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(8, 48);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(100, 23);
            this.label2.TabIndex = 3;
            this.label2.Text = "使用人名称：";
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(8, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 23);
            this.label1.TabIndex = 2;
            this.label1.Text = "公司名称：";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.structureName);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.VIEWName);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.SQLName);
            this.groupBox2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.groupBox2.Location = new System.Drawing.Point(8, 168);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(280, 108);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "命名空间信息";
            this.groupBox2.Visible = false;
            // 
            // structureName
            // 
            this.structureName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.structureName.Location = new System.Drawing.Point(96, 16);
            this.structureName.Name = "structureName";
            this.structureName.Size = new System.Drawing.Size(176, 21);
            this.structureName.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(10, 18);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(80, 23);
            this.label3.TabIndex = 0;
            this.label3.Text = "结构层：";
            // 
            // label7
            // 
            this.label7.Location = new System.Drawing.Point(8, 80);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(80, 23);
            this.label7.TabIndex = 2;
            this.label7.Text = "表现层：";
            // 
            // VIEWName
            // 
            this.VIEWName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.VIEWName.Location = new System.Drawing.Point(96, 80);
            this.VIEWName.Name = "VIEWName";
            this.VIEWName.Size = new System.Drawing.Size(176, 21);
            this.VIEWName.TabIndex = 5;
            // 
            // label8
            // 
            this.label8.Location = new System.Drawing.Point(8, 48);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(80, 23);
            this.label8.TabIndex = 2;
            this.label8.Text = "SQL层：";
            // 
            // SQLName
            // 
            this.SQLName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.SQLName.Location = new System.Drawing.Point(96, 48);
            this.SQLName.Name = "SQLName";
            this.SQLName.Size = new System.Drawing.Size(176, 21);
            this.SQLName.TabIndex = 5;
            // 
            // BLLName
            // 
            this.BLLName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.BLLName.Location = new System.Drawing.Point(96, 303);
            this.BLLName.Name = "BLLName";
            this.BLLName.Size = new System.Drawing.Size(176, 21);
            this.BLLName.TabIndex = 5;
            this.BLLName.Visible = false;
            // 
            // DALName
            // 
            this.DALName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.DALName.Location = new System.Drawing.Point(96, 279);
            this.DALName.Name = "DALName";
            this.DALName.Size = new System.Drawing.Size(176, 21);
            this.DALName.TabIndex = 4;
            this.DALName.Visible = false;
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(16, 303);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(80, 23);
            this.label5.TabIndex = 2;
            this.label5.Text = "逻辑层：";
            this.label5.Visible = false;
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(16, 279);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(80, 23);
            this.label4.TabIndex = 1;
            this.label4.Text = "数据访问层：";
            this.label4.Visible = false;
            // 
            // save
            // 
            this.save.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.save.Location = new System.Drawing.Point(132, 118);
            this.save.Name = "save";
            this.save.Size = new System.Drawing.Size(75, 25);
            this.save.TabIndex = 2;
            this.save.Text = "保存(&S)";
            this.save.Click += new System.EventHandler(this.save_Click);
            // 
            // cancel
            // 
            this.cancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cancel.Location = new System.Drawing.Point(213, 118);
            this.cancel.Name = "cancel";
            this.cancel.Size = new System.Drawing.Size(75, 25);
            this.cancel.TabIndex = 3;
            this.cancel.Text = "取消(&C)";
            this.cancel.Click += new System.EventHandler(this.cancel_Click);
            // 
            // PersonalInfo
            // 
            this.AcceptButton = this.save;
            this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
            this.ClientSize = new System.Drawing.Size(298, 150);
            this.Controls.Add(this.cancel);
            this.Controls.Add(this.save);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.DALName);
            this.Controls.Add(this.BLLName);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "PersonalInfo";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "使用者信息";
            this.Load += new System.EventHandler(this.PersonalInfo_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion


		private void PersonalInfo_Load(object sender, System.EventArgs e)
		{
			this.FillForm();
		}

		private void cancel_Click(object sender, System.EventArgs e)
		{
			this.Close();
		}

		/// <summary>
		/// 从注册表读取信息 天如窗口中
		/// </summary>
		private void FillForm()
		{
			this.corpName.Text= RegisterAccess.ReadKey("corpName");
			this.userName.Text= RegisterAccess.ReadKey("userName");
			this.eMail.Text= RegisterAccess.ReadKey("email");
		}

		private void save_Click(object sender, System.EventArgs e)
		{
			RegisterAccess.WriteKey("corpName",this.corpName.Text);
			RegisterAccess.WriteKey("structureName",this.structureName.Text);
			RegisterAccess.WriteKey("userName",this.userName.Text);
			RegisterAccess.WriteKey("email",this.eMail.Text);

			this.Close();
		}
	}
}
