using System;
using System.Data;
using System.Data.SqlClient;

/// <summary>
/// 存储数据库中数据的类.
/// </summary>
/// <author>天志</author>
/// <log date="2007-09-01">创建</log>
sealed class DataMarket
{
    private DataMarket()
    {
        //
        // TODO: 在此处添加构造函数逻辑
        //
    }

    private static DataMarketMySQL mysql = null;
    private static DataMarketOracle oracle = null;

    private static DataMarketSQLServer sqlServer = null;


    private static DataMarketInterface DB
    {
        get
        {
            string dataBase = RegisterAccess.ReadKey("DBType");
            dataBase = dataBase.Trim();
            if (dataBase == "SQLSERVER2000" || dataBase == "SQLSERVER2005")
            {
                if (sqlServer == null)
                {
                    sqlServer = new DataMarketSQLServer();
                }
                return sqlServer; 
            }
            else if (dataBase == "ORACLE11G")
            {
                if (oracle == null)
                {
                    oracle = new DataMarketOracle();
                }
                return oracle; 
            }
            else
            {
                if (mysql == null)
                {
                    mysql = new DataMarketMySQL();
                }
                return mysql; 
            }
        }
    }

    public delegate void OnReConnect();

    public static OnReConnect ReConnect = null;

    /// <summary>
    /// 存储数据库信息的DataSet
    /// </summary>
    /// <author>天志</author>
    /// <log date="2007-09-01">创建</log>
    public static DataSet TableDataSet
    {
        set
        {
            DB.TableDataSet = value;
        }
        get
        {
            DataSet ds = DB.TableDataSet;
            if (ReConnect != null)
            {
                ReConnect();
            }
            return ds;
        }
    }

    public static DataView GetAllTable()
    {
        if (DB.TableDataSet.Tables == null ||
            DB.TableDataSet.Tables.Count < 1)
        {
            return null;
        }

        DataView dv = DB.TableDataSet.Tables["TableInfo"].DefaultView;

        dv.RowFilter = "tableType in ('V','U','P')";
        dv.Sort = "tableType desc";
        return dv; 
    }

    /// <summary>
    /// 清空存储数据库信息的DataSet
    /// </summary>
    /// <author>天志</author>
    /// <log date="2007-09-01">创建</log>
    public static void SetTableDataSetNull()
    {
        DB.TableDataSet = null;
    }

    /// <summary>
    /// 取得某个表的列信息
    /// </summary>
    /// <param name="tableId">数据库表ID</param>
    /// <returns>存储列信息的DataView</returns>
    /// <author>天志</author>
    /// <log date="2007-09-01">创建</log>
    public static DataView GetColumnsForTable(int tableId)
    {
        return DB.GetColumnsForTable(tableId);
    }

    public static DataView GetColumnsForUser()
    {
        return DB.GetColumnsForUser();
    }

    /// <summary>
    /// 取得某个表的列信息
    /// </summary>
    /// <param name="tableName">数据库表名称</param>
    /// <returns>存储列信息的DataView</returns>
    /// <author>天志</author>
    /// <log date="2007-09-01">创建</log>
    public static DataView GetColumnsForTable(string tableName)
    {
        return DB.GetColumnsForTable(tableName);
    }

    public static DataView GetColumnForProduce(int id)
    {
        return DB.GetColumnForProduce(id);
    }

    /// <summary>
    /// 取得用户定义表的信息
    /// </summary>
    /// <returns>存储用户定义表的DataView</returns>
    /// <author>天志</author>
    /// <log date="2007-09-01">创建</log>
    public static DataView GetUserTable()
    {
        return DB.GetUserTable();
    }

    public static DataView GetProduce()
    {
        return DB.GetProduce();
    }

    public static DataView GetView()
    {
        return DB.GetView();
    }

    /// <summary>
    /// 取得表的外键
    /// </summary>
    /// <param name="tableId">数据库表编号</param>
    /// <returns>存储外键信息的DataView</returns>
    /// <author>天志</author>
    /// <log date="2007-09-01">创建</log>
    public static DataView GetTableFK(int tableId)
    {
        return DB.GetTableFK(tableId);
    }

    /// <summary>
    /// 取得作为主键表的信息。
    /// </summary>
    /// <param name="tableId">数据库表编号</param>
    /// <returns>存储外键信息的DataView</returns>
    /// <author>天志</author>
    /// <log date="2007-09-01">创建</log>
    public static DataView GetFKFromTable(int tableId)
    {
        return DB.GetFKFromTable(tableId);
    }

    /// <summary>
    /// 取得作为主键表的信息。
    /// </summary>
    /// <param name="tableId">数据库表名称</param>
    /// <returns>存储外键信息的DataView</returns>
    /// <author>天志</author>
    /// <log date="2007-09-01">创建</log>
    public static DataView GetFKFromTable(string tableName)
    {
        return DB.GetFKFromTable(tableName);
    }

    /// <summary>
    /// 取得数据库表的外键
    /// </summary>
    /// <param name="tableName">数据库表名</param>
    /// <returns>存储数据库表外键的DataTable</returns>
    /// <author>天志</author>
    /// <log date="2007-09-01">创建</log>
    public static DataTable GetTablePK(string tableName)
    {
        return DB.GetTablePK(tableName);
    }

    /// <summary>
    /// 取得数据库表信息.
    /// </summary>
    /// <param name="tableName">数据库表名</param>
    /// <returns>数据库表信息</returns>
    /// <author>天志</author>
    /// <log date="2007-09-02">创建</log>
    public static DataRowView GetTableInfo(string tableName)
    {
        return DB.GetTableInfo(tableName);
    }

    /// <summary>
    /// 取得数据库表信息
    /// </summary>
    /// <param name="tableId">数据库表编号</param>
    /// <returns>数据库表信息</returns>
    /// <author>天志</author>
    /// <log date="2007-09-02">创建</log>
    public static DataRowView GetTableInfo(int tableId)
    {
        return DB.GetTableInfo(tableId);
    }

    /// <summary>
    /// 判断数据库表中某列是否是主键。
    /// </summary>
    /// <param name="tableName">数据库表名</param>
    /// <param name="columnName">列名</param>
    /// <returns>是否主键：true：是；false：不是</returns>
    public static bool IsPKForColumn(string tableName, string columnName)
    {
        return DB.IsPKForColumn(tableName, columnName);
    }

    /// <summary>
    /// 判断数据库表中某列是否是外键。
    /// </summary>
    /// <param name="tableName">数据库表名</param>
    /// <param name="columnName">列名</param>
    /// <returns>是否外键：true：是；false：不是</returns>
    public static bool IsFKForColumn(string tableName, string columnName)
    {
        return DB.IsFKForColumn(tableName, columnName);
    }

    public static DataTable ExecuteDataTable(string sql)
    {
        return DB.ExecuteDataTable(sql);
    }



    public static int ExecuteNoQuery(string sql)
    {
        return DB.ExecuteNoQuery(sql);
    }

    /// <summary>
    /// 根据表名称和列名称取得字段信息。
    /// </summary>
    /// <param name="tableName"></param>
    /// <param name="columnName"></param>
    /// <returns></returns>
    public static DataRowView GetColumn(string tableName, string columnName)
    {
        return DB.GetColumn(tableName, columnName);
    }

    public static string GetProduce(int id)
    {
        return DB.GetProduce(id);
    }

    public static string GetView(int id)
    {
        return DB.GetView(id);
    }

    public static string GetPVAFContent(int id)
    {
        return DB.GetPVAFContent(id);
    }

    public static void ReadColumnDT(ColumnDT dt, DataRow dv)
    {
        DB.ReadColumnDT(dt, dv);
    }

    public static void ReadFKDT(FKDT dt, DataRow drv)
    {
        DB.ReadFKDT(dt, drv);
    }

    public static void ReadPKDT(PKDT dt, DataRow dr)
    {
        DB.ReadPKDT(dt, dr);
    }

    public static void ReadTableDT(TableExpandDT dt, DataRow dr)
    {
        DB.ReadTableDT(dt, dr);
    }
}

