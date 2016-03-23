using System;
using System.Data;
using System.Data.Common;


sealed class DBOper<C> where C : DBCreator, new()
{

    private DBOperBase dbOperObj = null;
    private DBOperBase DBOperObj
    {
        get
        {
            if (dbOperObj == null)
            {
                dbOperObj = new DBOperBase();
                dbOperObj.Creator = new C();
            }
            return dbOperObj;
        }
    }

    /// <summary>
    /// 填充DataTable
    /// </summary>
    /// <param name="sql">查询语句</param>
    /// <param name="parameters">查询参数数组</param>
    /// <param name="type">查询类型：查询语句或存储过程</param>
    /// <returns>填充后的DataTable</returns>
    /// <author>天志</author>
    /// <log date="2007-09-01">创建</log>
    public DataTable ExecuteDataTable(string sql, DbParameter[] parameters, CommandType type = CommandType.Text)
    {
        return DBOperObj.ExecuteDataTable(sql, parameters, type);
    }

    public int ExecuteNoQuery(string sql)
    {
        return DBOperObj.ExecuteNoQuery(sql);
    }

    public object ExecuteScaler(string sql)
    {
        return DBOperObj.ExecuteScaler(sql);
    }

    public DataSet ExecuteDataSet(string sql, DbParameter[] parameters = null, string[] names = null)
    {
        return DBOperObj.ExecuteDataSet(sql, parameters, names);
    }
}