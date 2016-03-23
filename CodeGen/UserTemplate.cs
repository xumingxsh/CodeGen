using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using System.IO;

using NVelocity;
using NVelocity.App;

namespace DockPanelSample
{
    public partial class UserTemplate : WeifenLuo.WinFormsUI.Docking.DockContent
    {
        private int tableId = -1;
        public UserTemplate()
        {
            InitializeComponent();
        }

        public void setSource(string source)
        {
            this.txtInputArea.Text = source;
            GetCode();
        }

        public void SetTableID(int id)
        {
            this.tableId = id;
            GetCode();
        }

        private void btnGetCode_Click(object sender, EventArgs e)
        {
            if (this.txtInputArea.Text.Trim().Length < 1)
            {
                MessageBox.Show("未设置输入模板，无法生成代码，请设置");
                this.txtInputArea.Focus();
                return;
            }
            if (tableId < 1)
            {
                MessageBox.Show("未选择响应表，无法生成代码，请选择");
                return;
            }

            GetCode();
        }

        private void GetCode()
        {
            CodeObject obj = Template.s_CodeObjects["tableinfo"];
            this.txtDisplayArea.Text = obj.GetCode(tableId, this.txtInputArea.Text);
           // this.txtDisplayArea.Text += this.txtInputArea.Text;
        }
    }
}
