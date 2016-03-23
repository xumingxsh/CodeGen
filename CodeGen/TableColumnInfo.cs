using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace DockPanelSample
{
    public partial class TableColumnInfo : WeifenLuo.WinFormsUI.Docking.DockContent
    {

        private int tableId = -1;

        public TableColumnInfo()
        {
            InitializeComponent();
        }

        private void TableColumnInfo_Load(object sender, EventArgs e)
        {

        }

        public void SetTableID(int id)
        {
            this.tableId = id;

            if (this.tableId > 0)
            {
                // 设置数据库表列显示信息            
                DataRowView tableView = DataMarket.GetTableInfo(this.tableId);
                TableExpandDT table = new TableExpandDT(tableView);
                this.dgvColumns.AutoGenerateColumns = false;
                this.dgvColumns.DataSource = table.Columns;
            }
            else
            {
                this.dgvColumns.DataSource = null;
            }
        }
    }
}
