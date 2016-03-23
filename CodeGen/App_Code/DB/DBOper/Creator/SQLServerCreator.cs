using System;
using System.Data.Common;
using System.Data.SqlClient;

sealed class SQLServerCreator : DBCreator
{
    public override string CreateConnStr(string ip, string port, string dataBase, string user, string pwd)
    {
        /*
        return string.Format("Server={0};port={1};Database=information_schema;Uid={2};Pwd={3};",
            ip, port, user, pwd);*/
        return string.Format("Data Source ={0};Initial Catalog = {1};User Id = {2};Password = {3};",
            ip, dataBase, user, pwd);
    }
    public override DbConnection CreateConn(string conn)
    {
        return new SqlConnection(conn);
    }
    public override DbCommand CreateCommand()
    {
        return new SqlCommand();
    }
    public override DbDataAdapter CreateAdapter(DbCommand command)
    {
        SqlCommand cmd = command as SqlCommand;
        return new SqlDataAdapter(cmd);
    }
}
