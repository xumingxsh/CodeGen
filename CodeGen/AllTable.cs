using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CodeGen.Tool;

namespace DockPanelSample
{
    public partial class AllTable : WeifenLuo.WinFormsUI.Docking.DockContent
    {
        public AllTable()
        {
            InitializeComponent();
        }
        MulitColumnsForGridView sortTool = new MulitColumnsForGridView();

        private void AllTable_Load(object sender, EventArgs e)
        {
            try
            {
                //sortTool.SetSortView(this.dgTable);
                this.Bind();
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        public void Bind()
        {
            this.dgTable.AutoGenerateColumns = false;
            this.dgTable.DataSource = null;
            this.dgTable.DataSource = DataMarket.GetAllTable();
        }

        private void dgTable_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {

            /*
            Rectangle rectangle = new Rectangle(e.RowBounds.Location.X + dgvColumns.RowHeadersWidth + 12,
                                  e.RowBounds.Location.Y, dgvColumns.RowHeadersWidth + 2, e.RowBounds.Height);*/

            System.Drawing.Rectangle rectangle = new System.Drawing.Rectangle(e.RowBounds.Location.X,
                    e.RowBounds.Location.Y,
                    dgTable.RowHeadersWidth - 4,
                    e.RowBounds.Height);
            TextRenderer.DrawText(e.Graphics, (e.RowIndex + 1).ToString(), dgTable.RowHeadersDefaultCellStyle.Font,
                rectangle, dgTable.RowHeadersDefaultCellStyle.ForeColor, TextFormatFlags.VerticalCenter | TextFormatFlags.Right);
        }
    }
}
