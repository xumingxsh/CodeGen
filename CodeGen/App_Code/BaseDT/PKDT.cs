using System;
using System.Data;

/// <summary>
/// 主键信息类
/// </summary>
public class PKDT
{
	public PKDT()
	{
	}

    public PKDT(DataRowView drv)
    {
        DataMarket.ReadPKDT(this, drv.Row);
    }

    public PKDT(DataRow dr)
    {
        DataMarket.ReadPKDT(this, dr);
    }

    public string PKName { get; set; }

    /// <summary>
    /// 数据库名称。
    /// </summary>
    public string DataBaseName { get; set; }

    /// <summary>
    /// 数据库表名称。
    /// </summary>
    public string TableName { get; set; }

    /// <summary>
    /// 数据库所属人名称。
    /// </summary>
    public string TableOwner { get; set; }

    /// <summary>
    /// 主键列名称。
    /// </summary>
    public string ColumnName { get; set; }

    /// <summary>
    /// Key-SEQ
    /// </summary>
    public int KeySEQ { get; set; }

    /// <summary>
    /// 主键信息。
    /// </summary>
    public ColumnDT PKColumn
    {
        get
        {
            DataRowView drv = DataMarket.GetColumn(this.TableName, this.ColumnName);
            return new ColumnDT(drv);
        }
    }
}
