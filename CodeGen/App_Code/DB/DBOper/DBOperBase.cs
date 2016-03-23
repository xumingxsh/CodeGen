using System;
using System.IO;
using System.Data;
using System.Text;

using System.Data.Common;


sealed class DBOperBase
{
    public DBOperBase()
    {
        //
        // TODO: 在此处添加构造函数逻辑
        //
    }
    /// <summary>
    /// 配置文件的最后改动时间。
    /// </summary>
    private static DateTime fileUpDate;

    /// <summary>
    /// 数据库连接字符串。
    /// </summary>
    /// <author>天志</author>
    /// <log date="2007-09-01">创建</log>
    private static string connectionString;

    private DBCreator creator = null;

    public DBCreator Creator
    {
        set
        {
            creator = value;
        }
    }

    private string ConnectString
    {
        get
        {            
            if (fileUpDate != File.GetLastWriteTime(ReadXML.XmlFileName) ||
                connectionString == null)
            {
                string serverName = RegisterAccess.ReadKey("serverName");
                string userID = RegisterAccess.ReadKey("userID");
                string dataBase = RegisterAccess.ReadKey("dataBase");
                string passWord = RegisterAccess.ReadKey("passWord");
                string port = RegisterAccess.ReadKey("port");

                if (creator == null)
                {
                    throw new Exception("未设置创建ADO创建对象");
                }

                connectionString = creator.CreateConnStr(serverName, port, dataBase, userID, passWord);
                fileUpDate = File.GetLastWriteTime(ReadXML.XmlFileName);
            }

            return connectionString;
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
        if (creator == null)
        {
            throw new Exception("未设置创建ADO创建对象");
        }

        DbConnection conn = creator.CreateConn(ConnectString);
        DbCommand command = creator.CreateCommand();
        command.Connection = conn;
        command.CommandText = sql;
        command.CommandType = type;
        if (parameters != null)
        {
            foreach (DbParameter parameter in parameters)
            {
                command.Parameters.Add(parameter);
            }
        }
        DbDataAdapter adapter = creator.CreateAdapter(command);
        DataTable dt = new DataTable();
        adapter.Fill(dt);
        return dt;
    }

    public object ExecuteScaler(string sql)
    {
        if (creator == null)
        {
            throw new Exception("未设置创建ADO创建对象");
        }
        DbConnection conn = creator.CreateConn(ConnectString);
        DbCommand command = creator.CreateCommand();
        command.Connection = conn;
        command.CommandText = sql;
        command.CommandType = CommandType.Text;
        try
        {
            conn.Open();
            return command.ExecuteScalar();
        }
        finally
        {
            conn.Close();
        }
    }


    public int ExecuteNoQuery(string sql)
    {
        if (creator == null)
        {
            throw new Exception("未设置创建ADO创建对象");
        }
        DbConnection conn = creator.CreateConn(ConnectString);
        DbCommand command = creator.CreateCommand();
        command.Connection = conn;
        command.CommandText = sql;
        command.CommandType = CommandType.Text;
        try
        {
            conn.Open();
            return command.ExecuteNonQuery();
        }
        finally
        {
            conn.Close();
        }
    }  

    public DataSet ExecuteDataSet(string sql, DbParameter[] parameters = null, string[] names = null)
    {
        if (creator == null)
        {
            throw new Exception("未设置创建ADO创建对象");
        }
        DbConnection conn = creator.CreateConn(ConnectString);
        conn.Open();
        DbCommand command = creator.CreateCommand();
        command.Connection = conn;
        command.CommandText = sql;
        if (parameters != null)
        {
            foreach (DbParameter parameter in parameters)
            {
                command.Parameters.Add(parameter);
            }
        }

        DbDataAdapter adapter = creator.CreateAdapter(command);

        if (names != null)
        {
            int index = 0;
            foreach (string name in names)
            {
                if (index == 0)
                {
                    DataTableMapping dtm = adapter.TableMappings.Add("Table", name);
                }
                else
                {
                    DataTableMapping dtm = adapter.TableMappings.Add("Table" + index, name);
                }
                index++;
            }
        }

        DataSet ds = new DataSet();
        adapter.Fill(ds);
        return ds;
    }
}