using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.IO;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Threading;

namespace DockPanelSample
{
    public partial class MainInput : WeifenLuo.WinFormsUI.Docking.DockContent
    {
        private int tableId = -1;
        public MainInput()
        {
            InitializeComponent();
        }

        private void MainInput_Load(object sender, EventArgs e)
        {

        }
        
        public void SetTableID(int id)
        {
            this.tableId = id;

            if (m_ShowKey == "")
            {
                this.DBInfo();
            }
            else
            {
                OnShowCode(m_ShowKey);
            }
        }

        public void DBInfo()
        {
            if (this.tableId < 1)
            {
                this.SetInputText("");
                return;
            }
            string content =  this.GetTableInfo(this.tableId);
            content += "\r\n\r\n\r\n" + DataMarket.GetPVAFContent(this.tableId);
            this.SetInputText(content);            
        }



        public void SQLInfo()
        {
            this.SetInputText(Template.GetSQLConfigText());
            this.Show();
            
        }

        public void ResourceInfo()
        {
            this.SetInputText(Template.GetResourceConfig());
            this.Show();
            
        }

        public void ResxXMLInfo()
        {
            this.SetInputText(Template.GetResxXML());
            this.Show();
            
        }

        public void ResxCodeInfo()
        {
            this.SetInputText(Template.GetResxCode());
            this.Show();
            
        }

        private string m_ShowKey = "";
        public void OnShowCode(string key)
        {
            m_ShowKey = key;
            if (this.tableId < 1)
            {
                return;
            }

            if (m_ShowKey == "tableinfo")
            {
                DataRowView tableView = DataMarket.GetTableInfo(this.tableId);
                TableExpandDT table = new TableExpandDT(tableView);
                if (table.TableType.Trim().ToLower() == "v" || table.TableType.Trim().ToLower() == "p")
                {
                    DBInfo();
                    return;
                }
            }
            CodeObject obj = Template.s_CodeObjects[key];
            if (obj != null)
            {
                this.SetInputText(obj.GetCode(this.tableId));
            }
        }

        public void OnShowConfig(string key)
        {
            if (this.tableId < 1)
            {
                return;
            }
            CodeObject obj = Template.s_CodeObjects[key];
            if (obj != null)
            {
                this.SetInputText(obj.GetCode(this.tableId));
                this.Show();
            }
            return;
        }

        public void OnExportConfig(string key)
        {
            if (GetExportState())
            {
                MessageBox.Show("正在导出，不能重复设置，请等候。");
                return;
            }
            Thread thread = new Thread(ExportCode);
            thread.Start(key);
        }

        // 代理实现异步调用以设置TextBox控件text属性
        delegate void SetTextCallback(string text);

        private void SetFormText(string text)
        {
            // InvokeRequired需要比较调用线程ID和创建线程ID
            // 如果它们不相同则返回true
            if (this.InvokeRequired)
            {
                SetTextCallback d = new SetTextCallback(SetFormText);
                this.Invoke(d, new object[] { text });
            }
            else
            {
                this.Text = text;
            }
        }

        // 代理实现异步调用以设置TextBox控件text属性
        delegate void SetExportStateCallback(bool state);

        bool isExport = false;

        private void SetExportState(bool state)
        {
            // InvokeRequired需要比较调用线程ID和创建线程ID
            // 如果它们不相同则返回true
            if (this.InvokeRequired)
            {
                SetExportStateCallback d = new SetExportStateCallback(SetExportState);
                this.Invoke(d, new object[] { state });
            }
            else
            {
                this.isExport = state;
            }
        }



        delegate bool GetExportStateCallback();

        private bool GetExportState()
        {
            if (this.InvokeRequired)
            {
                GetExportStateCallback d = new GetExportStateCallback(GetExportState);
                return (bool)this.Invoke(d);
            }
            else
            {
                return this.isExport;
            }
        }

        private void ExportCode(object obj)
        {
            string title = this.Text;
            //this.SetCodeExportEnable(false);
            this.SetExportState(true);

            if (Directory.Exists("../../Code"))
            {
                try
                {
                    Directory.Delete("../../Code", true);
                }
                catch (Exception ex)
                {
                    ex.ToString();
                    MessageBox.Show("导出代码的文件夹中，可能有文件正在被使用，未确保生成的代码文件正常无冲突，请先关闭正在使用的文件");
                    this.SetFormText(title);
                    //this.SetCodeExportEnable(true);
                    this.SetExportState(false);
                    return;
                }
            }

            string codeType = Convert.ToString(obj);
            if (!codeType.Contains("|"))
            {
                this.SetFormText(string.Format("代码导出中-{0}...", codeType));
                switch (codeType)
                {
                    case "All":
                        {
                            Template.PrinterAllClass();
                            break;
                        }
                    case "Web":
                        {
                            Template.PrinterAllClass();
                            break;
                        }
                    default:
                        {
                            CodeObject obj2 = Template.s_CodeObjects[codeType];
                            if (obj2 != null)
                            {
                                obj2.PrintAll();
                            }
                            break;
                        }
                }

                MessageBox.Show("所有代码已经导出");
            }
            else
            {
                string tp = codeType.Replace("|", "");
                List<CodeObject> list = Template.s_CodeList[tp];
                if (list.Count < 1)
                {
                    MessageBox.Show("没有要导出的代码");
                }
                else
                {
                    this.SetFormText(string.Format("按组代码导出中-{0}...", codeType.Replace("|", "")));


                    foreach (CodeObject it in list)
                    {
                        it.PrintAll();
                    }
                    MessageBox.Show("所有代码已经导出");
                }
            }
            //this.Text = title;

            this.SetFormText(title);
            //this.SetCodeExportEnable(true);
            this.SetExportState(false);

            string path = Application.StartupPath;
            path = path.Replace("\\", "/");
            int index = path.LastIndexOf('/');
            path = path.Substring(0, index); index = path.LastIndexOf('/');
            path = path.Substring(0, index);
            path += "/Code";

            path = path.Replace("/", "\\");

            System.Diagnostics.Process.Start("explorer.exe", path);
        }

        private string GetTableInfo(int id)
        {
            CodeObject obj = Template.s_CodeObjects["tableinfo"];
            return obj.GetCode(id);
        }	
	
        private void SetInputText(string text)
        {
            this.txtDisplayArea.Text = text;
            CodeGen.Tool.ControlUtils.SetHTMLColor(this.txtDisplayArea);
            this.Activate();
            //CodeGen.Tool.ControlUtils.SetHTMLColor(this.txtDisplayArea);
        }
    }
}