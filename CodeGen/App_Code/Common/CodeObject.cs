using System;
using System.Collections.Generic;
using System.Data;
using System.Collections;
using System.Xml;

using System.IO;

using NVelocity;
using NVelocity.App;


/// <summary>
/// 生成对象信息类，该类保存要导出代码的模板位置，生成代码位置，生成代码的名称，生成文件的名字等。
/// </summary>
public class CodeObject
{
    /// <summary>
    /// 模板文件的位置。
    /// </summary>
    public string temPath;

    /// <summary>
    /// 生成文件的名称。
    /// </summary>
    public string codePath;

    /// <summary>
    /// 生成代码的名称。
    /// </summary>
    public string name;

    /// <summary>
    /// 生成代码的描述。
    /// </summary>
    public string script;

    /// <summary>
    /// 生成文件的后缀。
    /// </summary>
    public string houzhui;

    /// <summary>
    /// 是否在生成文件时，添加一个与表名相同的文件夹。
    /// </summary>
    public bool isTableFolder;

    public CodeObject(string tp, string cp, string n, string s, string hz)
    {
        temPath = tp;
        codePath = cp;
        name = n;
        script = s;
        houzhui = hz;
        isTableFolder = false;
    }

    public CodeObject(bool ist, string tp, string cp, string n, string s, string hz)
    {
        temPath = tp;
        codePath = cp;
        name = n;
        script = s;
        houzhui = hz;
        isTableFolder = ist;
    }

    public CodeObject(XmlNode node)
    {
        // 如果是注释
        if (XmlNodeType.Comment == node.NodeType)
        {
            throw new Exception("这是一个注释节点，无法转换成CodeObject");
        }
        foreach (XmlNode child in node.ChildNodes)
        {
            string name = child.Name.ToUpper();
            string value = child.InnerText.Replace("\r\n", "");
            switch (name)
            {
                case "NAME":
                    {
                        this.script = value;
                        break;
                    }
                case "KEY":
                    {
                        this.name = value;
                        break;
                    }
                case "TEMPLATE":
                    {
                        this.temPath = value;
                        break;
                    }
                case "TARGET":
                    {
                        this.codePath = value;
                        break;
                    }
                case "FILETYPE":
                    {
                        this.houzhui = value;
                        break;
                    }
                case "ISTABLEFOLDER":
                    {
                        this.isTableFolder = value.ToLower().Equals("true");
                        break;
                    }
            }
        }

    }

    public string GetCode(int id)
    {
        return GetCode(TemplateDT.CreateTemplateDT(id));
    }

    public string GetCode(TemplateDT detail)
    {
        Velocity.Init();
        VelocityContext vc = new VelocityContext();
        vc.Put("data", detail);
        try
        {
            using (StringWriter sw = new StringWriter())
            {
               Velocity.MergeTemplate(temPath, "UTF-8", vc, sw);
               return sw.GetStringBuilder().ToString();
            }
        }
        catch (System.Exception ex)
        {
            return ex.ToString();
        }
    }


    public string GetCode(int id, string source)
    {
        if (source.Trim().Length < 1)
        {
            return "未设置模板";
        }
        if (id < 1)
        {
            return "未选择数据库表";
        }
        Velocity.Init();
        VelocityContext vc = new VelocityContext();
        vc.Put("data", TemplateDT.CreateTemplateDT(id));
        try
        {
            using (StringWriter sw = new StringWriter())
            {
                string log = "";
                bool result = Velocity.Evaluate(vc, sw, log, source);
                
                return sw.GetStringBuilder().ToString();
            }
        }
        catch (System.Exception ex)
        {
            return ex.ToString();
        }
    }

    public void PrintCode(int id)
    {
        PrintCode(TemplateDT.CreateTemplateDT(id));
    }

    public void PrintCode(TemplateDT detail)
    {
        string path = codePath;
        if (isTableFolder)
        {
            path += detail.TableClassName + "/";
        }
        path = "../../Code/" + path + detail.TableClassName + houzhui;
        Template.WriteText(path, GetCode(detail));
        return;
    }

    public void PrintAll()
    {
        DataView dv = DataMarket.GetUserTable();
        List<TemplateDT> list = new List<TemplateDT>();

        foreach (DataRowView drv in dv)
        {
            list.Add(TemplateDT.CreateTemplateDT(drv));
        }

        foreach (TemplateDT detail in list)
        {
            PrintCode(detail);
        }
    }
}
