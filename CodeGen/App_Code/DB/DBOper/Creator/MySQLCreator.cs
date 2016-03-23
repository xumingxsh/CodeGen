using System;
using System.Data.Common;

using MySql.Data.MySqlClient;



sealed class MySQLCreator : DBCreator
{
    public override string CreateConnStr(string ip, string port, string dataBase, string user, string pwd)
    {
        return string.Format("Server={0};port={1};Database=information_schema;Uid={2};Pwd={3};",
            ip, port,user, pwd);
    }
    public override DbConnection CreateConn(string conn)
    {
        return new MySqlConnection(conn);
    }
    public override DbCommand CreateCommand()
    {
        return new MySqlCommand();
    }
    public override DbDataAdapter CreateAdapter(DbCommand command)
    {
        MySqlCommand cmd = command as MySqlCommand;
        return new MySqlDataAdapter(cmd);
    }
}