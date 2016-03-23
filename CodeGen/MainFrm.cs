using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.IO;
using System.Windows.Forms;

using WeifenLuo.WinFormsUI.Docking;

using CodeGen;

namespace DockPanelSample
{
    public partial class MainFrm : Form
    {
        public MainFrm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Template.InitCodeObjects();
            Application.Run(new DockPanelSample.MainFrm());
        }


        /// <summary>
        /// 配置文件的最后改动时间。
        /// </summary>
        private static DateTime fileUpDate;

        private void MainFrm_Load(object sender, EventArgs e)
        {
            fileUpDate = File.GetLastWriteTime(ReadXML.XmlFileName);

            try
            {
                this.dcpMain.DockRightPortion = 0.12;
                this.dcpMain.DockLeftPortion = 0.20;

                this.fmTableColumnInfo = new TableColumnInfo();

                this.fmTableTree = new TableTree();

                this.fmTableMenum = new TableMenum();

                this.fmAllColumns = new AllColumns();

                this.fMainInput = new MainInput();

                this.userCodePanel = new UserTemplate();
                this.recordsPanel = new Records();

                this.allTablePanel = new AllTable();

                this.fmTableMenum.evtDBInfo += this.fMainInput.DBInfo;
                this.fmTableMenum.evtSQLInfo += this.fMainInput.SQLInfo;
                this.fmTableMenum.evtResourceInfo += this.fMainInput.ResourceInfo;
                this.fmTableMenum.evtResxXMLInfo += this.fMainInput.ResxXMLInfo; 
                this.fmTableMenum.evtResxCodeInfo += this.fMainInput.ResxCodeInfo; 
                this.fmTableMenum.evtCodeSelect += this.ShowInputCode;
                this.fmTableMenum.evtConfigSelect += this.fMainInput.OnShowConfig;
                this.fmTableMenum.evtExportSelect += this.fMainInput.OnExportConfig;

                this.fmTableTree.OnSelect += fmTableTree_OnSelect;

                DataMarket.ReConnect += Reconnect;

                this.fmTableColumnInfo.Show(this.dcpMain, DockState.DockBottom);
                this.fmTableTree.Show(this.dcpMain, DockState.DockLeft);
                this.fmTableMenum.Show(this.dcpMain, DockState.DockRight);
                this.fmAllColumns.Show(this.dcpMain, DockState.Document);
                this.allTablePanel.Show(this.dcpMain, DockState.Document);
                this.userCodePanel.Show(this.dcpMain, DockState.Document);
                this.recordsPanel.Show(this.dcpMain, DockState.Document);
                this.fMainInput.Show(this.dcpMain, DockState.Document);

                DataSet ds = DataMarket.TableDataSet;
            }
            catch(Exception ex)
            {
                MessageBox.Show("数据库连接失败或者读取相关信息失败，请重新配置数据库连接！" + ex.ToString());
                ConnectDB();
            }
        }

        private void ShowInputCode(string key)
        {
            this.fMainInput.OnShowCode(key);


            CodeObject obj = Template.s_CodeObjects[key];
            string content = FileContent.GetContentString(obj.temPath);
            this.userCodePanel.setSource(content);
        }

        public void Reconnect()
        {
            this.fmTableTree.BindTree();
            this.fmAllColumns.BindColumns();
            this.allTablePanel.Bind();
            this.fmTableMenum.BindTree();
        }

        private void fmTableTree_OnSelect(int id)
        {
            this.fMainInput.SetTableID(id);
            this.fmTableColumnInfo.SetTableID(id);
            this.userCodePanel.SetTableID(id);
            this.recordsPanel.SetTableID(id);
        }

        private void ConnectDB()
        {
            while (true)
            {
                ConnectServer server = new ConnectServer();

                DialogResult result = server.ShowDialog();

                if (result == DialogResult.OK)
                {
                    fileUpDate = File.GetLastWriteTime(ReadXML.XmlFileName);
                    try
                    {
                        this.Reconnect();
                        break;
                    }
                    catch(Exception ex)
                    {
                        MessageBox.Show("数据库连接失败，请重新配置数据库连接！\r\n" + ex.ToString());
                    }
                }
                else
                {
                    break;
                }
            }
        }

        private void menuItemD_Click(object sender, EventArgs e)
        {
            ConnectDB();
        }

        private void menuItemU_Click(object sender, EventArgs e)
        {
            PersonalInfo info = new PersonalInfo();
            info.ShowDialog();
        }

        private void menuItemQ_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void menuItemA_Click(object sender, EventArgs e)
        {
            About about = new About();
            about.ShowDialog();
        }
    }
}