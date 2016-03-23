using System;
using System.Data;

/// <summary>
/// 外键信息类。
/// </summary>
public class FKDT 
{
	public FKDT() 
	{
	}

    public FKDT(DataRowView drv)
    {
        DataMarket.ReadFKDT(this, drv.Row);
    }

    public FKDT(DataRow dr)
    {
        DataMarket.ReadFKDT(this, dr);
    }

    /// <summary>
    /// 外键名称。
    /// </summary>
    public string FKName{get;set;}

    /// <summary>
    /// 外键名称。
    /// </summary>
    public int FKId { get; set; }

    /// <summary>
    /// 外键名称。
    /// </summary>
    public string TableName { get; set; }


    /// <summary>
    /// 外键名称。
    /// </summary>
    public int TableId { get; set; }

    /// <summary>
    /// 外键名称。
    /// </summary>
    public string ColumnName { get; set; }

    /// <summary>
    /// 外键名称。
    /// </summary>
    public string RColumnName { get; set; }

    /// <summary>
    /// 外键名称。
    /// </summary>
    public string ParentTableName { get; set; }

    /// <summary>
    /// 外键名称。
    /// </summary>
    public int ParentTableId { get; set; }

    public string ColumnScript
    {
        get
        {
            return "";
        }
    }

    public string RColumnScript
    {
        get
        {
            return "";
        }
    }

    public string TableScript
    {
        get
        {
            return "";
        }
    }

    public string ParentTableScript
    {
        get
        {
            return "";
        }
    }

    /// <summary>
    /// 外键列信息。
    /// </summary>
    public ColumnDT FKColumn
    {
        get
        {
            DataRowView drv = DataMarket.GetColumn(this.TableName, this.ColumnName);
            return new ColumnDT(drv);
        }
    }

    /// <summary>
    /// 主表列信息。
    /// </summary>
    public ColumnDT PKColumn
    {
        get
        {
            DataRowView drv = DataMarket.GetColumn(this.ParentTableName, this.RColumnName);
            return new ColumnDT(drv);
        }
    }

    /// <summary>
    /// 主表信息。
    /// </summary>
    public TableExpandDT ParentTableInfo
    {
        get
        {
            DataRowView drv = DataMarket.GetTableInfo(this.ParentTableName);
            return new TableExpandDT(drv);
        }
    }
}
