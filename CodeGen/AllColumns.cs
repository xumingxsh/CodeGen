using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using CodeGen.Tool;

namespace DockPanelSample
{
    public partial class AllColumns : WeifenLuo.WinFormsUI.Docking.DockContent
    {
        public AllColumns()
        {
            InitializeComponent();
        }

        private void AllColumns_Load(object sender, EventArgs e)
        {
            try
            {
                this.BindColumns();
            }
            catch //(System.Exception ex)
            {
            	
            }
        }

        MulitColumnsForGridView4List<ColumnDT> sortTool = new MulitColumnsForGridView4List<ColumnDT>();

        public void BindColumns()
        {
            sortTool.SetSortView(this.dgvColumns);
            this.dgvColumns.AutoGenerateColumns = false;
            this.dgvColumns.DataSource = null;
            this.dgvColumns.DataSource = Template.GetAllColumns();
        }

        private void dgvColumns_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            System.Drawing.Rectangle rectangle = new System.Drawing.Rectangle(e.RowBounds.Location.X,
                    e.RowBounds.Location.Y,
                    dgvColumns.RowHeadersWidth - 4,
                    e.RowBounds.Height);
            TextRenderer.DrawText(e.Graphics, (e.RowIndex + 1).ToString(), dgvColumns.RowHeadersDefaultCellStyle.Font,
                rectangle, dgvColumns.RowHeadersDefaultCellStyle.ForeColor, TextFormatFlags.VerticalCenter | TextFormatFlags.Right);
       }
    }
}
