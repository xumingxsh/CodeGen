using System;
using System.Data;

using CodeGen;

/// <summary>
/// 添加页面模板业务对象。
/// </summary>
public class TemplateDT
{
    private TableExpandDT baseDetail;

    public TableExpandDT BaseDetail
    {
        get
        {
            return baseDetail;
        }
    }

    /// <summary>
    /// 生成TemplateDT对象。
    /// </summary>
    /// <param name="tableId"></param>
    /// <returns></returns>
    public static TemplateDT CreateTemplateDT(int tableId)
    {
        DataRowView tableView = DataMarket.GetTableInfo(tableId);
        TableExpandDT table = new TableExpandDT(tableView);
        return new TemplateDT(table);
    }
    /// <summary>
    /// 生成TemplateDT对象。
    /// </summary>
    /// <param name="drv"></param>
    /// <returns></returns>
    public static TemplateDT CreateTemplateDT(DataRowView drv)
    {
        TableExpandDT table = new TableExpandDT(drv);
        return new TemplateDT(table);
    }   

    public TemplateDT(TableExpandDT detail)
    {
        baseDetail = detail;
    }    

    /// <summary>
    /// 取得命名时的名称。
    /// </summary>
    public string TableClassName
    {
        get
        {
            return baseDetail.NameForClass;
        }
    }

    /// <summary>
    /// 表的中文名称。
    /// </summary>
    public string TableCNName
    {
        get
        {
            return baseDetail.CNName.Replace("\r\n", "\t");
        }
    }

    #region 基本信息

    /// <summary>
    /// 公司信息。
    /// </summary>
    public string CorpName
    {
        get
        {
            return RegisterAccess.ReadKey("corpName") +"1980--" + System.DateTime.Now.Year;
        }
    }

    /// <summary>
    /// 用户信息。
    /// </summary>
    public string UserName
    {
        get
        {
            return RegisterAccess.ReadKey("userName");
        }
    }

    /// <summary>
    /// Email。
    /// </summary>
    public string EMail
    {
        get
        {
            return RegisterAccess.ReadKey("email");
        }
    }

    /// <summary>
    /// 当前日期。
    /// </summary>
    public string Today
    {
        get
        {
            DateTime dt = System.DateTime.Now;
            string month = dt.Month.ToString();
            string day = dt.Day.ToString();
            if (dt.Month < 10)
            {
                month = "0" + month;
            }
            if (dt.Day < 10)
            {
                day = "0" + day;
            }
            return dt.Year + "-" + month + "-" + day;
        }
    }
    #endregion        
}
