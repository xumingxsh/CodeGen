using System;
using System.Data;
using System.Collections.Generic;

/// <summary>
/// 数据库表扩展信息类.
///     基本信息
/// 
///     列集合
///     主键集合
///     外键集合
///     引用外键信息
///     
///     添加语句及参数数组
///     编辑语句及参数数组
///     删除语句及参数数组
///     查询语句及参数数组
///     查询列及参数数组
///     查询表及参数数组
///     查询列扩展及参数数组
///     查询表扩展及参数数组
///     数据源SQL语句
/// 
///     主键描述字段
///     主键描述字段列信息
/// </summary>
public class TableExpandDT
{
	public TableExpandDT()
	{
	}

    public TableExpandDT(DataRowView dv)
    {
        DataMarket.ReadTableDT(this, dv.Row);
    }

    /// <summary>
    /// 数据库表名称
    /// </summary>
    /// <author>天志</author>
    /// <log date="2007-09-01">创建</log>
    private string _tableName;

    /// <summary>
    /// 数据库表描述
    /// </summary>
    /// <author>天志</author>
    /// <log date="2007-09-01">创建</log>
    private string _script;

    /// <summary>
    /// 数据库表名
    /// </summary>
    /// <author>天志</author>
    /// <log date="2007-09-01">创建</log>
    public string TableName
    {
        set
        {
            this._tableName = value;
        }
        get
        {
            return this._tableName.NoSpace();
        }
    }

    public string TableNameNoSpace
    {
        set
        {
            this._tableName = value;
        }
        get
        {
            return this._tableName.NoSpace();
        }
    }



    /// <summary>
    /// 数据库表ID
    /// </summary>
    /// <author>天志</author>
    /// <log date="2007-09-01">创建</log>
    public int Id { get; set; }

    /// <summary>
    /// 数据库表类型
    /// </summary>
    /// <author>天志</author>
    /// <log date="2007-09-01">创建</log>
    public string TableType { get; set; }

    /// <summary>
    /// 数据库表描述
    /// </summary>
    /// <author>天志</author>
    /// <log date="2007-09-01">创建</log>
    public string Script
    {
        set
        {
            this._script = value;
        }
        get
        {
            return this._script.GetScript();
        }
    }

    /// <summary>
    /// 数据库表创建日期
    /// </summary>
    /// <author>天志</author>
    /// <log date="2007-09-01">创建</log>
    public string CreateDate { get; set; }

    /// <summary>
    /// 取得首字母小写的名称。
    /// </summary>
    public string FirstCharLower
    {
        get
        {
            return this.TableNameNoSpace.ToFirstLower();
        }
    }

    /// <summary>
    /// 取得首字母大写的名称。
    /// </summary>
    public string FirstCharUpper
    {
        get
        {
            return this.TableNameNoSpace.ToFirstUper();
        }
    }

    /// <summary>
    /// 声明类时应用的名称。
    /// </summary>
    public string NameForClass
    {
        get
        {
            return this.TableNameNoSpace.GetTableClassName();
        }
    }
    public string CNName
    {
        get
        {
            if (this.Script.IsNullOrEmpty())
            {
                return this.TableName;
            }

            return this.Script;
        }
    }

    #region 数据库表列信息

    /// <summary>
    /// 存储列信息的DataView。
    /// </summary>
    public DataView ColumnsDataView
    {
        get
        {
            return DataMarket.GetColumnsForTable(this.Id);
        }
    }

    /// <summary>
    /// 数据库表列信息。
    /// </summary>
    private List<ColumnDT> columns;

    /// <summary>
    /// 数据库表列信息。
    /// </summary>
    public List<ColumnDT> Columns
    {
        get
        {
            if (columns == null)
            {
                DataView dv = this.ColumnsDataView;
                columns = new List<ColumnDT>();

                foreach (DataRowView drv in dv)
                {
                    columns.Add(new ColumnDT(drv, this.Script));
                }
            }
            return columns;
        }
    }
    #endregion

    #region 数据库表主键信息

    /// <summary>
    /// 存储主键信息的DataTable。
    /// </summary>
    public DataTable PKDataTable
    {
        get
        {
            return DataMarket.GetTablePK(this.TableName);
        }
    }

    /// <summary>
    /// 主键集合。
    /// </summary>
    private List<PKDT> pks;

    /// <summary>
    /// 主键集合。
    /// </summary>
    public List<PKDT> PKs
    {
        get
        {
            if (pks != null)
            {
                return pks;
            }

            pks = new List<PKDT>();
            DataView dv = this.PKDataTable.DefaultView;
            foreach (DataRowView drv in dv)
            {
                pks.Add(new PKDT(drv));
            }
            return pks;
        }
    }
    #endregion

    #region 数据库表外键信息

    /// <summary>
    /// 存储数据库表外键信息的DataView。
    /// </summary>
    public DataView FKDataView
    {
        get
        {
            return DataMarket.GetTableFK(this.Id);
        }
    }

    /// <summary>
    /// 外键集合.
    /// </summary>
    private List<FKDT> fks;

    /// <summary>
    /// 外键集合.
    public List<FKDT> FKs
    {
        get
        {
            if (this.fks != null)
            {
                return this.fks;
            }

            this.fks = new List<FKDT>();

            DataView dv = this.FKDataView;
            foreach (DataRowView drv in dv)
            {
                fks.Add(new FKDT(drv));
            }
            return fks;
        }
    }
    #endregion

    #region 数据库表引用外键

    /// <summary>
    /// 存储数据库表引用外键信息的DataView。
    /// </summary>
    public DataView FKFromTableDataView
    {
        get
        {
            return DataMarket.GetFKFromTable(this.Id);
        }
    }

    /// <summary>
    /// 数据库表引用外键集合。
    /// </summary>
    private List<FKDT> fromTableFKs;

    /// <summary>
    /// 数据库表引用外键集合。
    /// </summary>
    public List<FKDT> FromTableFKs
    {
        get
        {
            if (this.fromTableFKs != null)
            {
                return this.fromTableFKs;
            }

            DataView dv = this.FKFromTableDataView;
            this.fromTableFKs = new List<FKDT>();
            foreach (DataRowView drv in dv)
            {
                this.fromTableFKs.Add(new FKDT(drv));
            }

            return this.fromTableFKs;
        }
    }
    #endregion

    #region 数据库表特殊字段

    /// <summary>
    /// 标识字段。
    /// </summary>
    public string MarkingColumn
    {
        get
        {
            foreach (ColumnDT column in this.Columns)
            {
                if (column.IsMarking)
                {
                    return column.ColumnName;
                }
            }
            return "";
        }
    }

    /// <summary>
    /// 标识字段。
    /// </summary>
    public ColumnDT MarkingColumnDT
    {
        get
        {
            foreach (ColumnDT column in this.Columns)
            {
                if (column.IsMarking)
                {
                    return column;
                }
            }
            return null;
        }
    }

    /// <summary>
    /// 主键字段。
    /// </summary>
    private List<string> pkColumns;

    /// <summary>
    /// 主键字段。
    public List<string> PKColumnNames
    {
        get
        {
            if (pkColumns != null)
            {
                return pkColumns;
            }

            pkColumns = new List<string>();
            foreach (PKDT dt in PKs)
            {
                pkColumns.Add(dt.ColumnName);
            }
            return pkColumns;
        }
    }
    #endregion
    
    #region SQL中的查询语句
    /// <summary>
    /// 取得主键查询。
    /// </summary>
    /// <returns></returns>
    private string GetPKQuery()
    {
        if (this.PKColumnNames.Count < 1)
        {
            return "";
        }

        string query = "";
        foreach (string name in this.PKColumnNames)
        {
            if (query != "")
            {
                query += " AND ";
            }
            query += name + " = @" + name;
        }
        return query;
    }

    public string GetOrderStr()
    {
        string order = "";
        foreach (var it in pks)
        {
            if (order != "")
            {
                order += ",";
            }
            order += it.ColumnName;
        }

        if (order != "")
        {
            order = "order by " + order + " desc";
        } 
        return order;
    }

    public string GetSearchColumns(bool has_pre = false)
    {
        string pre = "";
        if (has_pre)
        {
            pre = this.TableName + ".";
        }
        string cols_fields = "";
        foreach (var it in this.Columns)
        {
            if (cols_fields != "")
            {
                cols_fields += ",";
            }


            cols_fields += pre + it.ColumnName;
        }
        return cols_fields;
    }

    /// <summary>
    /// 取得查询语句。
    /// </summary>
    /// <returns></returns>
    public string GetQuery()
    {
        string markingColumn = this.MarkingColumn;
        if (markingColumn != "")
        {
            return markingColumn + " = @" + markingColumn;
        }

        string query = this.GetPKQuery();
        if (query != "")
        {
            return query;
        }

        return Columns[0].ColumnName + " = @" + Columns[0].ColumnName;
    }
    #endregion

    #region SQL语句

    /// <summary>
    /// 取得查询表名称。
    /// </summary>
    public string DBTable
    {
        get
        {
            return this.TableName;
        }
    }
    #endregion
    
    #region 取得外键信息

    /// <summary>
    /// 取得作为外键的字段。
    /// </summary>
    /// <returns>作为外键的字段</returns>
    public string GetFKColumn()
    {
        string fkColumn = "";

        // 是否有引用外键指定的相关外键
        if (this.FromTableFKs.Count > 0)
        {
            fkColumn = this.FromTableFKs[0].RColumnName;
        }

        // 是否有主键
        if (fkColumn == "" && this.PKColumnNames.Count > 0)
        {
            fkColumn = this.PKColumnNames[0];
        }

        if (fkColumn == "")
        {
            fkColumn = this.Columns[0].ColumnName;
        }

        return fkColumn;
    }

    /// <summary>
    /// 取得外键描述字段。
    /// </summary>
    /// <returns>外键描述字段</returns>
    public string GetFKTextColumn(string fkColumn)
    {
        foreach (ColumnDT dt in this.Columns)
        {
            if (dt.IsString &&
                !dt.IsGUID &&
                !dt.IsNullable)
            {
                return dt.ColumnName;
            }
        }

        return fkColumn;
    }

    /// <summary>
    /// 取得外键描述字段。
    /// </summary>
    /// <param name="fkColumn"></param>
    /// <returns></returns>
    public ColumnDT GetFKTEXTColumnInfo(string fkColumn)
    {
        string name = this.GetFKTextColumn(fkColumn);
        DataRowView drv = DataMarket.GetColumn(this.TableName, name);
        return new ColumnDT(drv);
    }
    #endregion

    /// <summary>
    /// 第一列。
    /// </summary>
    public ColumnDT FirstColumn
    {
        get
        {
            return Columns[0];
        }
    }

    /// <summary>
    /// 第一列。
    /// </summary>
    public ColumnDT FirstStrColumn
    {
        get
        {
            foreach (ColumnDT cl in columns)
            {
                if (cl.IsString)
                {
                    return cl;
                }
            }
            return Columns[0];
        }
    }
}
