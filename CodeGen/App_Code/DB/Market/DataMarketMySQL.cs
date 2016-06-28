using System;
using System.Collections;
using System.Data;

using MySql.Data.MySqlClient;


sealed class DataMarketMySQL : DataMarketInterface
{
    private DBOper<MySQLCreator> db = new DBOper<MySQLCreator>();
    /// <summary>
    /// 存储数据库信息的DataSet
    /// </summary>
    /// <author>天志</author>
    /// <log date="2007-09-01">创建</log>
    private DataSet tableDataSet;

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
                    string dataBase = RegisterAccess.ReadKey("dataBase");

                    // 取得数据库中列信息，表信息，外键信息
                    string sql = RegistFields.instance.ColumnsInfoSQL + ";" + RegistFields.instance.TableSQL + ";" + RegistFields.instance.FKSQL;
                    sql = string.Format(sql, dataBase);
                    this.tableDataSet = new DataSet();
                    string[] names = { "ColumnInfo", "TableInfo", "FKInfo" };
                    this.tableDataSet = db.ExecuteDataSet(sql, names:names);

                    DataTable dt = this.tableDataSet.Tables["TableInfo"];
                    DataColumn dc = dt.Columns.Add("ID", Type.GetType("System.Int32"));
                    //dc.AllowDBNull = false;
                    int index = 1;
                    foreach (DataRow r in dt.Rows)
                    {
                        r["ID"] = index;
                        index++;
                    }
                }
                catch (System.Exception ex)
                {
                    this.tableDataSet = null;
                    string msg = ex.ToString();
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
        dv.RowFilter = "TableName = " + GetTableName(tableId);
        return dv;
    }

    private string GetTableName(int tableId)
    {

        DataTable dtTB = this.TableDataSet.Tables["TableInfo"];
        DataView dvTB = new DataView(dtTB);
        string name = "";
        dvTB.RowFilter = "id = " + tableId;
        if (dvTB.Count >= 1)
        {
            name = Convert.ToString(dvTB[0]["tableName"]);
        }
        return "'" + name + "'";
    }

    public DataView GetColumnsForUser()
    {
        DataTable dt = this.TableDataSet.Tables["ColumnInfo"];
        return new DataView(dt);
        //dv.RowFilter = "ObjectType = 'U' AND TableName<>'dtproperties'";
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
        //dv.RowFilter = "id = " + id;
        dv.RowFilter = "TableName = " + GetTableName(id);
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
        dv.RowFilter = "tableType = 'U'";
        return dv;
    }

    public DataView GetProduce()
    {
        DataTable dt = this.TableDataSet.Tables["TableInfo"];
        DataView dv = dt.DefaultView;
        dv.RowFilter = "tableType = 'P'";
        return dv;
    }

    public DataView GetView()
    {
        DataTable dt = this.TableDataSet.Tables["TableInfo"];
        DataView dv = dt.DefaultView;
        dv.RowFilter = "tableType = 'V'";
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
        dv.RowFilter = "TableName = " + GetTableName(tableId);
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
        dv.RowFilter = "ParentTableName = " + GetTableName(tableId);
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
        DataTable dt = this.TableDataSet.Tables["ColumnInfo"];
        DataView dv = new DataView(dt);
        dv.RowFilter = " TableName = '" + tableName + "' AND COLUMN_KEY='PRI'";
        return GetDataTableByView(dv);
    }

    private DataTable GetDataTableByView(DataView obDataView)
    {
        if (null == obDataView)
        {
            throw new ArgumentNullException("DataView", "Invalid DataView object specified");
        }
        DataTable obNewDt = obDataView.Table.Clone();
        int idx = 0;
        string[] strColNames = new string[obNewDt.Columns.Count];
        foreach (DataColumn col in obNewDt.Columns)
        {
            strColNames[idx++] = col.ColumnName;
        }
        IEnumerator viewEnumerator = obDataView.GetEnumerator();
        while (viewEnumerator.MoveNext())
        {
            DataRowView drv = (DataRowView)viewEnumerator.Current;
            DataRow dr = obNewDt.NewRow();
            try
            {
                foreach (string strName in strColNames)
                {
                    dr[strName] = drv[strName];
                }
            }
            catch
            {
            }
            obNewDt.Rows.Add(dr);
        }
        return obNewDt;
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
        dv.RowFilter = "TableName = " + GetTableName(tableId);
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
        dv.RowFilter = "COLUMNNAME='" + columnName + "'";
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
        if (dv.Count < 1)
        {
            return false;
        }
        return true;
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
        if (dv.Count < 1)
        {
            return null;
        }
        return dv[0];
    }

    public string GetProduce(int id)
    {
        string sql = "SELECT text FROM syscomments where id =" + id;
        return (string)db.ExecuteScaler(sql);
    }

    public string GetView(int id)
    {
        string sql = "SELECT View_Definition FROM views where table_name =" + GetTableName(id);
        return (string)db.ExecuteScaler(sql);
    }
    public void ReadColumnDT(ColumnDT dt, DataRow dv)
    {
        dt.TableName = Convert.ToString(dv["TableName"]);
        dt.ColumnName = Convert.ToString(dv["ColumnName"]);
        dt.ColumnType = Convert.ToString(dv["Data_Type"]);
        if (dv["CHARACTER_MAXIMUM_LENGTH"] != null && Convert.ToString(dv["CHARACTER_MAXIMUM_LENGTH"]) != "")
        {
            try
            {
                dt.Length = Convert.ToInt32(dv["CHARACTER_MAXIMUM_LENGTH"]);
            }
            catch 
            {
                dt.Length = Convert.ToInt64(dv["CHARACTER_MAXIMUM_LENGTH"]);
            }
        }
        else
        {
            if (dv["NUMERIC_PRECISION"] != null && !(dv["NUMERIC_PRECISION"] is System.DBNull))
            {
                dt.Length = Convert.ToInt32(dv["NUMERIC_PRECISION"]);
            }
        }
        if (dv["NUMERIC_SCALE"] != null && Convert.ToString(dv["NUMERIC_SCALE"]) != "")
        {
            dt.Decimaldigits = Convert.ToInt32(dv["NUMERIC_SCALE"]);
        }
        //dt.Decimaldigits = Convert.ToInt32(dv["decimaldigits"]);
        dt.Script = Convert.ToString(dv["Column_Comment"]);
        dt.DefaultValue = Convert.ToString(dv["Column_Default"]);
        dt.IsNullable = Convert.ToString(dv["Is_Nullable"]) != "NO";
        if (Convert.ToString(dv["extra"]) == "auto_increment")
        {
            dt.IsMarking = true;
        }
        else
        {
            dt.IsMarking = false;
        }
    }
    public void ReadFKDT(FKDT dt, DataRow drv)
    {
        dt.FKName = Convert.ToString(drv["FKName"]);
        dt.TableName = Convert.ToString(drv["TableName"]);
        dt.ColumnName = Convert.ToString(drv["ColumnName"]);
        dt.RColumnName = Convert.ToString(drv["RColumnName"]);
        dt.ParentTableName = Convert.ToString(drv["ParentTableName"]);
    }

    public void ReadPKDT(PKDT dt, DataRow dr)
    {
        dt.PKName = Convert.ToString(dr["ColumnName"]);
        dt.TableName = Convert.ToString(dr["TABLENAME"]);
        dt.ColumnName = Convert.ToString(dr["ColumnName"]);
    }

    public void ReadTableDT(TableExpandDT dt, DataRow dr)
    {
        dt.TableName = Convert.ToString(dr["tableName"]);
        dt.Id = Convert.ToInt32(dr["id"]);
        dt.TableType = Convert.ToString(dr["tableType"]);
        dt.Script = Convert.ToString(dr["script"]);
        if (dt.Script != null)
        {
            string script = dt.Script;
            int index = script.IndexOf("; InnoDB");
            if (index > 0 && index < script.Length)
            {
                dt.Script = script.Substring(0, index);
            }
        }
    }

    public string GetPVAFContent(int id)
    {
        return "";
    }
}