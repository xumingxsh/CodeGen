using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.IO;
using System.Text;
using System.Windows.Forms;

using CodeGen.Tool;

namespace DockPanelSample
{
    public partial class Records : WeifenLuo.WinFormsUI.Docking.DockContent
    {
        private int tableId = -1;

        private string tableName = "";
        public Records()
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

        private void GetCode()
        {

            DataRowView tableView = DataMarket.GetTableInfo(this.tableId);
            TableExpandDT table = new TableExpandDT(tableView);
            tableName = table.TableName;

            string sql = "select top 100 * from [{0}]  {1}";
            List<PKDT> pks = table.PKs;
            string order = table.GetOrderStr();
            sql = string.Format(sql, table.TableName, order);

            //CodeObject obj = Template.s_CodeObjects["tableinfo"];
            this.txtInputArea.Text = sql;
            this.dgList.DataSource = null;
            // this.txtDisplayArea.Text += this.txtInputArea.Text;
            //this.txtInputArea.

            ControlUtils.SetSQLColor(this.txtInputArea);
        }

        private void btnGetCode_Click(object sender, EventArgs e)
        {

            if (this.txtInputArea.Text.Trim() == "")
            {
                return;
            }

            if (!this.txtInputArea.Text.Trim().ToLower().StartsWith("select "))
            {
                this.txtLog.Text = "search failed!is not start with \"select\"";
                return;

            }
            this.btnGetCode.Enabled = false;
            try
            {
                DataTable dt = DataMarket.ExecuteDataTable(this.txtInputArea.Text);
                if (dt == null)
                {
                    return;
                }
                this.dgList.DataSource = dt;
                this.txtLog.Text = string.Format("search success!get {0} rows from table", dt.Rows.Count);
            }
            catch (Exception ex)
            {
                this.txtLog.Text = string.Format("search failed, reason:{0}", ex.ToString());
            }
            finally
            {
                this.btnGetCode.Enabled = true;
            }
        }

        private void dgList_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            /*
            Rectangle rectangle = new Rectangle(e.RowBounds.Location.X + dgList.RowHeadersWidth + 12,
                                  e.RowBounds.Location.Y, dgList.RowHeadersWidth + 2, e.RowBounds.Height);
            TextRenderer.DrawText(e.Graphics, (e.RowIndex + 1).ToString(), dgList.RowHeadersDefaultCellStyle.Font,
                rectangle, dgList.RowHeadersDefaultCellStyle.ForeColor, TextFormatFlags.VerticalCenter | TextFormatFlags.Right);
            */
            System.Drawing.Rectangle rectangle = new System.Drawing.Rectangle(e.RowBounds.Location.X,
                    e.RowBounds.Location.Y,
                    dgList.RowHeadersWidth - 4,
                    e.RowBounds.Height);

            TextRenderer.DrawText(e.Graphics, (e.RowIndex + 1).ToString(),
                dgList.RowHeadersDefaultCellStyle.Font,
                rectangle,
                dgList.RowHeadersDefaultCellStyle.ForeColor,
                TextFormatFlags.VerticalCenter | TextFormatFlags.Right);
        }

        private void btnExecuteNoQuery_Click(object sender, EventArgs e)
        {
            if (this.txtInputArea.Text.Trim() == "")
            {
                return;
            }

            if (this.txtInputArea.Text.Trim().ToLower().StartsWith("select "))
            {
                this.txtLog.Text = "this is a seatch sql,please using search button!";
                return;

            }
            this.btnGetCode.Enabled = false;
            try
            {
                int count = DataMarket.ExecuteNoQuery(this.txtInputArea.Text);
                if (count < 0)
                {
                    return;
                }
                this.txtLog.Text = "execute sql success!";
            }
            catch (Exception ex)
            {
                this.txtLog.Text = string.Format("execute sql failed, reason:{0}", ex.ToString());
            }
            finally
            {
                this.btnGetCode.Enabled = true;
            }
        }

        string folder = "C:/";
        private void btnCSV_Click(object sender, EventArgs e)
        {

            if (this.txtInputArea.Text.Trim() == "")
            {
                return;
            }

            if (!this.txtInputArea.Text.Trim().ToLower().StartsWith("select "))
            {
                this.txtLog.Text = "export failed!is not start with \"select\"";
                return;

            }
            this.btnGetCode.Enabled = false;
            try
            {
                DataTable dt = DataMarket.ExecuteDataTable(this.txtInputArea.Text);
                if (dt == null)
                {
                    return;
                }

                //this.directoryEntry1..sho.show
                this.sfCSV.Filter = "CSV文件|*.CSV";
                this.sfCSV.InitialDirectory = folder;
                this.sfCSV.FileName = tableName + DateTime.Now.ToString("_yyyyMMddHHmmSS");
                if (this.sfCSV.ShowDialog() == DialogResult.Cancel)
                {
                    return;
                }
                else
                {
                    folder = this.sfCSV.InitialDirectory;
                    string fileName = this.sfCSV.FileName;
                    SaveCSV(dt, fileName);
                }
                this.txtLog.Text = string.Format("save success!get {0} rows from table", dt.Rows.Count);
            }
            catch (Exception ex)
            {
                this.txtLog.Text = string.Format("save failed, reason:{0}", ex.ToString());
            }
            finally
            {
                this.btnGetCode.Enabled = true;
            }
        }

        private void SaveCSV(DataTable dt, string file)
        {
            FileStream fs = new FileStream(file, System.IO.FileMode.Create, System.IO.FileAccess.Write);
            StreamWriter sw = new StreamWriter(fs, System.Text.Encoding.Default);
            string data = "";
            //写出列名称
            for (int i = 0; i < dt.Columns.Count; i++)
            {
                data += "\"" + dt.Columns[i].ColumnName.ToString() + "\"";
                if (i < dt.Columns.Count - 1)
                {
                    data += ",";
                }
            }
            sw.WriteLine(data);
            //写出各行数据
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                data = "";
                for (int j = 0; j < dt.Columns.Count; j++)
                {
                    object obj = dt.Rows[i][j];
                    if (obj is DBNull || obj == null)
                    {
                        data += "\"\"";
                    }
                    else
                    {
                        data += "\"" + Convert.ToString(obj).Replace("\r\n", " ").Replace("\"", "'") + "\"";
                    }
                    if (j < dt.Columns.Count - 1)
                    {
                        data += ",";
                    }
                }
                sw.WriteLine(data);
            }
            sw.Close();
            fs.Close();
        }

        private void txtInputArea_TextChanged(object sender, EventArgs e)
        {
            ControlUtils.SetSQLColor(this.txtInputArea);
        }
    }
}
