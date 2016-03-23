using System;
using System.Data;
using System.IO;
using System.Text;
using System.Collections.Generic;
using System.Xml;

/// <summary>
/// Summary description for Template
/// </summary>
public class Template
{
    /// <summary>
    /// 导出所有的类。
    /// </summary>
    public static string PrinterAllClass()
    {
        DataView dv = DataMarket.GetUserTable();
        List<TemplateDT> list = new List<TemplateDT>();

        foreach (DataRowView drv in dv)
        {
            list.Add(TemplateDT.CreateTemplateDT(drv));
            //Template.PrinterClassForTable(drv);
        }

        foreach (TemplateDT detail in list)
        {
            //Template.PrinterClassForTable(detail);
            foreach (CodeObject obj in s_CodeObjects.Values)
            {
                obj.PrintCode(detail);
            }
        }
        return "../../Code/Tables";
    }

    /// <summary>
    /// 打印文件。
    /// </summary>
    /// <param name="content"></param>
    /// <param name="url"></param>
    public static void WriteText(string url, string content)
    {
        if (File.Exists(url))
        {
            File.Delete(url);
        }
        DirectoryInfo di = Directory.CreateDirectory(url);
        di.Delete();

        StreamWriter sw = new StreamWriter(url, false, Encoding.UTF8);
        sw.Write(content);
        sw.Close();
        content = null;
    }

    private static string GetAllCode(string key)
    {
        DataView dv = DataMarket.GetUserTable();
        List<TableExpandDT> list = new List<TableExpandDT>();

        foreach (DataRowView drv in dv)
        {
            list.Add(new TableExpandDT(drv));
        }

        StringBuilder sb = new StringBuilder();
        CodeObject obj = s_CodeObjects[key];
        if (obj == null)
        {
            return "";
        }
        foreach (TableExpandDT detail in list)
        {
            sb.Append(obj.GetCode(detail.Id));
        }
        return sb.ToString();
    }
    public static string GetSQLConfigText()
    {
        DataView dv = DataMarket.GetUserTable();
        List<TableExpandDT> list = new List<TableExpandDT>();

        foreach (DataRowView drv in dv)
        {
            list.Add(new TableExpandDT(drv));
        }

        StringBuilder sb = new StringBuilder();
        sb.Append("<?xml version=\"1.0\"?>" + "\r\n");
        sb.Append("<SQL-List>" + "\r\n");
        sb.Append(GetAllCode("SQLXML"));
        sb.Append("</SQL-List>" + "\r\n");
        return sb.ToString();
    }   

    public static string GetResourceConfig()
    {
        DataView dv = DataMarket.GetUserTable();
        List<TableExpandDT> list = new List<TableExpandDT>();

        foreach (DataRowView drv in dv)
        {
            list.Add(new TableExpandDT(drv));
        }

        StringBuilder sb = new StringBuilder();
        sb.Append("<?xml version=\"1.0\"?>" + "\r\n");
        sb.Append("<root>" + "\r\n");
        sb.Append(GetAllCode("Resource"));
        sb.Append("</root>" + "\r\n");
        return sb.ToString();
    }


    public static string GetResxXML()
    {
        return GetAllCode("MonorailResxXML");
    }


    public static string GetResxCode()
    {
        return GetAllCode("MonorailResxCode");
    }

    public static DataTable GetPKTable()
    {
        DataView dv = DataMarket.GetUserTable();
        List<TableExpandDT> list = new List<TableExpandDT>();

        foreach (DataRowView drv in dv)
        {
            list.Add(new TableExpandDT(drv));
        }

        DataTable dt = new DataTable();
        DataTable dt2;
        foreach (TableExpandDT detail in list)
        {
            dt2 = detail.PKDataTable;
            if (dt2 != null)
            {
                dt.Merge(dt2);
            }
        }

        return dt;
    }

    public static List<ColumnDT> GetAllColumns()
    {
        DataView dv = DataMarket.GetUserTable();
        List<ColumnDT> list = new List<ColumnDT>();

        foreach (DataRowView drv in dv)
        {
            list.AddRange((new TableExpandDT(drv)).Columns);
        }
        return list;
    }

    public static IDictionary<string, CodeObject> s_CodeObjects = new Dictionary<string, CodeObject>();

    public static IDictionary<string, List<CodeObject>> s_CodeList = new Dictionary<string, List<CodeObject>>();

    public static void InitCodeObjects()
    {
        XmlDocument doc = new XmlDocument();
        doc.Load("Code.xml");
        XmlNode node = doc.SelectSingleNode("root");

        foreach (XmlNode child in node.ChildNodes)
        {
            if (!child.Name.ToUpper().Equals("CODETYPE"))
            {
                continue;
            }

            List<CodeObject> list = new List<CodeObject>();

            foreach (XmlNode code in child.ChildNodes)
            {
                try
                {
                    CodeObject obj = new CodeObject(code); 
                    if (!s_CodeObjects.ContainsKey(obj.name))
                    {
                        s_CodeObjects.Add(obj.name, obj);
                        list.Add(obj); ;
                    }
                }
                catch (System.Exception ex)
                {
                    ex.ToString();
                }
            }

            if (list.Count > 0)
            {
                string name = child.Attributes["name"].Value;
                if (!s_CodeList.ContainsKey(name))
                {
                    s_CodeList.Add(name, list);
                }
            }
        }
    }
}
