using System;
using System.Data;
using System.Data.SqlClient;

sealed class DataMarketSQLServer : DataMarketInterface
{
    private DBOper<SQLServerCreator> db = new DBOper<SQLServerCreator>();

    /// <summary>
    /// 存储数据库信息的DataSet
    /// </summary>
    /// <author>天志</author>
    /// <log date="2007-09-01">创建</log>
    private DataSet tableDataSet;

    DataTable tableNames;

    /// <summary>
    /// 存储数据库信息的DataSet
    /// </summary>
    /// <author>天志</author>
    /// <log date="2007-09-01">创建</log>
    public DataSet TableDataSet
    {
        set
        {
            this.tableDataSet = value;
        }
        get
        {
            if (this.tableDataSet == null)
            {
                try
                {
                    // 取得数据库中列信息，表信息，外键信息
                    string sql = RegistFields.instance.ColumnsInfoSQL + ";" + RegistFields.instance.TableSQL + ";" + RegistFields.instance.FKSQL;
                    this.tableDataSet = new DataSet();
                    string[] names = { "ColumnInfo", "TableInfo", "FKInfo" };
                    this.tableDataSet = db.ExecuteDataSet(sql, names:names);

                    sql = "select ep.[Value] from sys.extended_properties ep";
                    tableNames = db.ExecuteDataTable(sql, null);

                    DataTable dt = this.TableDataSet.Tables["TableInfo"];
                    for (int i = 0; i < dt.Rows.Count; i++ )
                    {
                        string type = Convert.ToString(dt.Rows[i]["tableType"]).Trim();
                        if (type != "U" && type != "V")
                        {
                            continue;
                        }
                        string script = Convert.ToString(dt.Rows[i]["Script"]);
                        string name = Convert.ToString(dt.Rows[i]["TableName"]);
                        string id = Convert.ToString(dt.Rows[i]["id"]);
                        if (script != name)
                        {
                            continue;
                        }

                        if (type == "U")
                        {
                            sql = "select [Value] from sys.extended_properties where minor_id = 0 and major_id = " + id;
                            object val = db.ExecuteScaler(sql);
                            if (val != null && !(val is DBNull))
                            {
                                dt.Rows[i]["Script"] = Convert.ToString(val);
                            }
                        }

                        if (type == "V")
                        {
                            sql = "select [Value] from sys.extended_properties where minor_id = 0 and name='MS_Description' and major_id = " + id;
                            object val = db.ExecuteScaler(sql);
                            if (val != null && !(val is DBNull))
                            {
                                string name2 = Convert.ToString(val);
                                if (!name2.Contains("["))
                                {
                                    dt.Rows[i]["Script"] = Convert.ToString(val);
                                }
                            }
                        }
                    }
                }
                catch (System.Exception ex)
                {
                    this.tableDataSet = null;
                    throw ex;
                }
            }
            return this.tableDataSet;
        }
    }

    public DataTable ExecuteDataTable(string sql)
    {
        return db.ExecuteDataTable(sql, null, CommandType.Text);
    }

    public int ExecuteNoQuery(string sql)
    {
        return db.ExecuteNoQuery(sql);
    }

    /// <summary>
    /// 清空存储数据库信息的DataSet
    /// </summary>
    /// <author>天志</author>
    /// <log date="2007-09-01">创建</log>
    public void SetTableDataSetNull()
    {
        tableDataSet = null;
    }

    /// <summary>
    /// 取得某个表的列信息
    /// </summary>
    /// <param name="tableId">数据库表ID</param>
    /// <returns>存储列信息的DataView</returns>
    /// <author>天志</author>
    /// <log date="2007-09-01">创建</log>
    public DataView GetColumnsForTable(int tableId)
    {
        DataTable dt = this.TableDataSet.Tables["ColumnInfo"];
        DataView dv = new DataView(dt);
        dv.RowFilter = "id = " + tableId;
        return dv;
    }

    public DataView GetColumnsForUser()
    {
        DataTable dt = this.TableDataSet.Tables["ColumnInfo"];
        DataView dv = new DataView(dt);
        dv.RowFilter = "ObjectType = 'U' AND TableName<>'dtproperties'";
        return dv;
    }

    /// <summary>
    /// 取得某个表的列信息
    /// </summary>
    /// <param name="tableName">数据库表名称</param>
    /// <returns>存储列信息的DataView</returns>
    /// <author>天志</author>
    /// <log date="2007-09-01">创建</log>
    public DataView GetColumnsForTable(string tableName)
    {
        DataTable dt = this.TableDataSet.Tables["ColumnInfo"];
        DataView dv = new DataView(dt);
        dv.RowFilter = "TableName = '" + tableName + "'";
        return dv;
    }

    public DataView GetColumnForProduce(int id)
    {
        DataTable dt = this.TableDataSet.Tables["ColumnInfo"];
        DataView dv = new DataView(dt);
        dv.RowFilter = "id = " + id;
        return dv;
    }

    /// <summary>
    /// 取得用户定义表的信息
    /// </summary>
    /// <returns>存储用户定义表的DataView</returns>
    /// <author>天志</author>
    /// <log date="2007-09-01">创建</log>
    public DataView GetUserTable()
    {
        DataTable dt = this.TableDataSet.Tables["TableInfo"];
        DataView dv = new DataView(dt);
        dv.RowFilter = "tableType = 'U' AND TableName<>'dtproperties'";
        return dv;
    }

    public DataView GetProduce()
    {
        DataTable dt = this.TableDataSet.Tables["TableInfo"];
        DataView dv = dt.DefaultView;
        dv.RowFilter = "tableType = 'P' AND Category = 0";
        return dv;
    }

    public DataView GetView()
    {
        DataTable dt = this.TableDataSet.Tables["TableInfo"];
        DataView dv = dt.DefaultView;
        dv.RowFilter = "tableType = 'V' AND Category = 0";
        return dv;
    }

    /// <summary>
    /// 取得表的外键
    /// </summary>
    /// <param name="tableId">数据库表编号</param>
    /// <returns>存储外键信息的DataView</returns>
    /// <author>天志</author>
    /// <log date="2007-09-01">创建</log>
    public DataView GetTableFK(int tableId)
    {
        DataTable dt = this.TableDataSet.Tables["FKInfo"];
        DataView dv = new DataView(dt);
        dv.RowFilter = "TableID = " + tableId;
        return dv;
    }

    /// <summary>
    /// 取得作为主键表的信息。
    /// </summary>
    /// <param name="tableId">数据库表编号</param>
    /// <returns>存储外键信息的DataView</returns>
    /// <author>天志</author>
    /// <log date="2007-09-01">创建</log>
    public DataView GetFKFromTable(int tableId)
    {
        DataTable dt = this.TableDataSet.Tables["FKInfo"];
        DataView dv = new DataView(dt);
        dv.RowFilter = "ParentTableID = " + tableId;
        return dv;
    }

    /// <summary>
    /// 取得作为主键表的信息。
    /// </summary>
    /// <param name="tableId">数据库表名称</param>
    /// <returns>存储外键信息的DataView</returns>
    /// <author>天志</author>
    /// <log date="2007-09-01">创建</log>
    public DataView GetFKFromTable(string tableName)
    {
        DataTable dt = this.TableDataSet.Tables["FKInfo"];
        DataView dv = new DataView(dt);
        dv.RowFilter = "ParentTableName = '" + tableName + "'";
        return dv;
    }

    /// <summary>
    /// 取得数据库表的外键
    /// </summary>
    /// <param name="tableName">数据库表名</param>
    /// <returns>存储数据库表外键的DataTable</returns>
    /// <author>天志</author>
    /// <log date="2007-09-01">创建</log>
    public DataTable GetTablePK(string tableName)
    {
        SqlParameter paramer = new SqlParameter("@table_name", tableName);
        SqlParameter[] paramers = new SqlParameter[1];
        paramers[0] = paramer;
        return db.ExecuteDataTable(//SQLConst.GETTABLEPK, 
            "sp_pkeys", paramers, CommandType.StoredProcedure);
    }

    /// <summary>
    /// 取得数据库表信息.
    /// </summary>
    /// <param name="tableName">数据库表名</param>
    /// <returns>数据库表信息</returns>
    /// <author>天志</author>
    /// <log date="2007-09-02">创建</log>
    public DataRowView GetTableInfo(string tableName)
    {
        DataView dv = this.GetUserTable();
        dv.RowFilter = "TableName = '" + tableName + "'";
        return dv[0];
    }

    /// <summary>
    /// 取得数据库表信息
    /// </summary>
    /// <param name="tableId">数据库表编号</param>
    /// <returns>数据库表信息</returns>
    /// <author>天志</author>
    /// <log date="2007-09-02">创建</log>
    public DataRowView GetTableInfo(int tableId)
    {
        DataView dv = this.GetUserTable();
        dv.RowFilter = "id = " + tableId;
        return dv[0];
    }

    /// <summary>
    /// 判断数据库表中某列是否是主键。
    /// </summary>
    /// <param name="tableName">数据库表名</param>
    /// <param name="columnName">列名</param>
    /// <returns>是否主键：true：是；false：不是</returns>
    public bool IsPKForColumn(string tableName, string columnName)
    {
        DataTable dt = this.GetTablePK(tableName);
        if (dt == null || dt.Rows.Count < 1)
        {
            return false;
        }

        DataView dv = new DataView(dt);
        dv.RowFilter = "COLUMN_NAME='" + columnName + "'";
        return dv.Count > 0;
    }

    /// <summary>
    /// 判断数据库表中某列是否是外键。
    /// </summary>
    /// <param name="tableName">数据库表名</param>
    /// <param name="columnName">列名</param>
    /// <returns>是否外键：true：是；false：不是</returns>
    public bool IsFKForColumn(string tableName, string columnName)
    {
        DataTable dt = this.TableDataSet.Tables["FKInfo"];
        DataView dv = new DataView(dt);
        dv.RowFilter = " TableName = '" + tableName + "' AND ColumnName='" + columnName + "'";
        return (dv.Count > 0);
    }

    /// <summary>
    /// 根据表名称和列名称取得字段信息。
    /// </summary>
    /// <param name="tableName"></param>
    /// <param name="columnName"></param>
    /// <returns></returns>
    public DataRowView GetColumn(string tableName, string columnName)
    {
        DataTable dt = this.TableDataSet.Tables["ColumnInfo"];
        DataView dv = new DataView(dt);
        dv.RowFilter = " TableName = '" + tableName + "' AND ColumnName='" + columnName + "'";
        return dv[0];
    }

    public string GetProduce(int id)
    {
        string sql = "SELECT text FROM syscomments where id =" + id;
        return (string)db.ExecuteScaler(sql);
    }

    public string GetView(int id)
    {
        string sql = "SELECT text FROM syscomments where id =" + id;
        return (string)db.ExecuteScaler(sql);
    }


    public void ReadColumnDT(ColumnDT dt, DataRow dv)
    {
        try
        {
            dt.TableName = Convert.ToString(dv["tableName"]);
            dt.Id = Convert.ToInt32(dv["id"]);
            dt.ColumnName = Convert.ToString(dv["columnName"]);
            dt.ColId = Convert.ToInt32(dv["colId"]);
            dt.ColumnType = Convert.ToString(dv["columnType"]);
            dt.ColumnTypeIndex = Convert.ToInt32(dv["columnTypeIndex"]);
            dt.Length = Convert.ToInt32(dv["length"]);
            dt.Decimaldigits = Convert.ToInt32(dv["decimaldigits"]);
            dt.Script = Convert.ToString(dv["script"]);
            dt.DefaultValue = Convert.ToString(dv["defaultValue"]);
            dt.IsNullable = Convert.ToInt32(dv["isnullable"]) == 1;
            dt.IsMarking = Convert.ToInt32(dv["isMarking"]) == 1;
        }
        catch //(System.Exception ex)
        {

        }
    }


    public void ReadFKDT(FKDT dt, DataRow drv)
    {
        try
        {
            dt.FKName = Convert.ToString(drv["FKName"]);
            dt.FKId = Convert.ToInt32(drv["FKID"]);
            dt.TableName = Convert.ToString(drv["TableName"]);
            dt.TableId = Convert.ToInt32(drv["TableID"]);
            dt.ColumnName = Convert.ToString(drv["ColumnName"]);
            dt.RColumnName = Convert.ToString(drv["RColumnName"]);
            dt.ParentTableName = Convert.ToString(drv["ParentTableName"]);
            dt.ParentTableId = Convert.ToInt32(drv["ParentTableID"]);
        }
        catch //(System.Exception ex)
        {

        }
    }

    public void ReadPKDT(PKDT dt, DataRow dr)
    {
        try
        {
            dt.PKName = Convert.ToString(dr["PK_NAME"]);
            dt.DataBaseName = Convert.ToString(dr["TABLE_QUALIFIER"]);
            dt.TableName = Convert.ToString(dr["TABLE_NAME"]);
            dt.TableOwner = Convert.ToString(dr["TABLE_OWNER"]);
            dt.ColumnName = Convert.ToString(dr["COLUMN_NAME"]);
            dt.KeySEQ = Convert.ToInt32(dr["KEY_SEQ"]);
        }
        catch //(System.Exception ex)
        {

        }
    }

    public void ReadTableDT(TableExpandDT dt, DataRow dr)
    {
        try
        {
            dt.TableName = Convert.ToString(dr["tableName"]);
            dt.Id = Convert.ToInt32(dr["id"]);
            dt.TableType = Convert.ToString(dr["tableType"]);
            dt.Script = Convert.ToString(dr["script"]);
            dt.CreateDate = Convert.ToString(dr["createDate"]);
        }
        catch //(System.Exception ex)
        {

        }
    }
}