using System;
using System.IO;
using System.Data;
using System.Collections;
using System.Xml;
using System.Linq;


	/// <summary>
	/// ReadXML 的摘要说明。
	/// </summary>
public class ReadXML
{

    public static string XmlFileName = @"CharXml.xml";

    public static HdcCache cache = new HdcCache();

    public ReadXML()
    {
        //
        // TODO:在此处添加构造函数逻辑
        //

        if (!File.Exists(XmlFileName))
        {
            throw new Exception("配置文件不存在!");
        }

        GetXMLDoc();
    }

    public XmlDocument GetXMLDoc()
    {
        XmlDocument xmlDoc = null;

        xmlDoc = (XmlDocument)cache.Get();

        if (xmlDoc == null)
        {
            lock (typeof(ReadXML))
            {
                xmlDoc = (XmlDocument)cache.Get();
                if (xmlDoc == null)
                {
                    xmlDoc = new XmlDocument();
                    xmlDoc.Load(XmlFileName);
                    cache.Init(XmlFileName);
                    cache.Set(xmlDoc);
                }
            }
        }

        return xmlDoc;
    }

    public string GetConstantValue(string itemName, string defName)
    {
        XmlNodeList scrNodes = GetXMLDoc().SelectNodes("//define[@itemname='" + defName + "' AND @defname='" + defName + "']]");
        string retValue = "";
        foreach (XmlNode nd in scrNodes)
        {
            retValue = nd.Attributes.GetNamedItem("value").Value;
        }

        return retValue;
    }

    public string GetConstantName(string itemName, string defValue)
    {
        XmlNodeList scrNodes = GetXMLDoc().SelectNodes("//define[@itemname='" + itemName + "' and @value='" + defValue + "']");
        string retValue = "";
        foreach (XmlNode nd in scrNodes)
        {
            retValue = nd.Attributes.GetNamedItem("defnme").Value;
        }

        return retValue;
    }

    public string GetConstantText(string itemNam)
    {
        XmlNodeList scrNodes = GetXMLDoc().SelectNodes("//" + itemNam);
        string retValue = "";
        foreach (XmlNode nd in scrNodes)
        {
            retValue = nd.InnerText.Replace("\r\n", "").Replace("\t", " ").Replace("  ", " ").Trim(); ;
        }

        return retValue;
    }

    public string GetConstantName(string itemName)
    {
        XmlNodeList scrNodes = GetXMLDoc().SelectNodes("//define[@itemname='" + itemName + "']");
        string retValue = "";
        foreach (XmlNode nd in scrNodes)
        {
            retValue = nd.Attributes.GetNamedItem("value").Value;
        }

        return retValue;
    }

    public DataTable GetConstantTable(string itemName)
    {
        DataTable retValue = new DataTable();
        retValue.Columns.Add("column1", typeof(string));
        retValue.Columns.Add("column2", typeof(string));

        XmlNodeList scrNodes = GetXMLDoc().SelectNodes("//define[@itemname='" + itemName + "']");
        foreach (XmlNode nd in scrNodes)
        {
            DataRow addRow = retValue.NewRow();
            addRow["column1"] = nd.Attributes.GetNamedItem("value").Value;
            addRow["column2"] = nd.Attributes.GetNamedItem("defname").Value;
            retValue.Rows.Add(addRow);
        }

        return retValue;
    }

    public Hashtable GetConstantHashtable(string itemName)
    {
        Hashtable retValue = new Hashtable();
        XmlNodeList scrNodes = GetXMLDoc().SelectNodes("//define[@itemname='" + itemName + "']");
        foreach (XmlNode nd in scrNodes)
        {
            retValue[nd.Attributes.GetNamedItem("defname").Value] = nd.Attributes.GetNamedItem("value").Value;
        }

        return retValue;
    }

    public void SaveValue(string key, string attribute, string Value)
    {
        XmlDocument xmlDoc = new XmlDocument();

        xmlDoc.Load(XmlFileName);

        XmlNodeList scrNodes = xmlDoc.SelectNodes("//define[@itemname='" + key + "']");

        foreach (XmlNode nd in scrNodes)
        {
            nd.Attributes[attribute].Value = Value;
        }

        xmlDoc.Save(XmlFileName);
    }
}

