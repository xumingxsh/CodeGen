using System;

using System.Data.Common;


abstract class DBCreator
{
    public abstract string CreateConnStr(string ip, string port, string dataBase, string user, string pwd);
    public abstract DbConnection CreateConn(string conn);
    public abstract DbCommand CreateCommand();
    public abstract DbDataAdapter CreateAdapter(DbCommand command);
}