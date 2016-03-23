using System;
using System.Data.Common;

using System.Data.OracleClient;

sealed class OracleCreator: DBCreator
{

    public override string CreateConnStr(string ip, string port, string dataBase, string user, string pwd)
    {
        return string.Format("data source=(DESCRIPTION =(ADDRESS_LIST =(ADDRESS = (PROTOCOL = TCP)(HOST = {0})(PORT = {1})))(CONNECT_DATA =(SERVICE_NAME = {2})));user={3};password={4}",
            ip, port, dataBase, user, pwd);
    }
    public override DbConnection CreateConn(string conn)
    {
        return new OracleConnection(conn);
    }
    public override DbCommand CreateCommand()
    {
        return new OracleCommand();  
    }
    public override DbDataAdapter CreateAdapter(DbCommand command)
    {
        OracleCommand cmd = command as OracleCommand;
        return new OracleDataAdapter(cmd);
    }
}
