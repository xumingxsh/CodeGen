using System;


/// <summary>
/// RegistFields 的摘要说明。
/// </summary>
public class RegistFields
{
	private static ReadXML readXml = new ReadXML();

	public static RegistFields instance = new RegistFields();

	private RegistFields()
	{
		//
		// TODO: 在此处添加构造函数逻辑
		//
	}

	public void SetValue(string name, string Value)
	{
		name = name.ToLower(); 
        if (name == "userName".ToLower())
		{
			UserName = Value;
		}
		else if (name == "corpName".ToLower())
		{
			CorpName = Value;
		}
		else if (name == "email".ToLower())
		{
			Email = Value;
		}
		else if (name == "serverName".ToLower())
		{
			ServerName = Value;
		}
		else if (name == "dataBase".ToLower())
		{
			DataBase = Value;
		}
		else if (name == "userID".ToLower())
		{
			UserID = Value;
		}
		else if (name == "passWord".ToLower())
		{
			PassWord = Value;
        }
        else if (name == "dbtype".ToLower())
        {
            DBType = Value;
        }
		else
        {
            readXml.SaveValue(name, "value", Value);
            //throw new Exception("错误参数");
		}
	}

	public string GetValue(string name)
	{
		name = name.ToLower();
        if (name == "userName".ToLower())
		{
			return UserName;
		}
		else if (name == "corpName".ToLower())
		{
			return CorpName;
		}
		else if (name == "email".ToLower())
		{
			return Email;
		}
		else if (name == "serverName".ToLower())
		{
			return ServerName;
		}
		else if (name == "dataBase".ToLower())
		{
			return DataBase;
		}
		else if (name == "userID".ToLower())
		{
			return UserID;
		}
        else if (name == "passWord".ToLower())
        {
            return PassWord;
        }
        else if (name == "dbtype".ToLower())
        {
            return DBType;
        }
        else
        {
            //throw new Exception("错误参数");
            return readXml.GetConstantName(name);
        }
	}

	/// <summary>
	/// 使用人名称。
	/// </summary>
	private string UserName
	{
		set
		{
			readXml.SaveValue("userName", "value", value);
		}
		get
		{
			return readXml.GetConstantName("userName");
		}
	}

	/// <summary>
	/// 公司名称。
	/// </summary>
	private string CorpName
	{
		set
		{
			readXml.SaveValue("corpName", "value", value);
		}
		get
		{
			return readXml.GetConstantName("corpName");
		}
	}

    private string DBType
    {
        set
        {
            readXml.SaveValue("DBType", "value", value);
        }
        get
        {
            return readXml.GetConstantName("DBType");
        }
    }

	/// <summary>
	/// 使用人EMail。
	/// </summary>
	private string Email
	{
		set
		{
			readXml.SaveValue("email", "value", value);
		}
		get
		{
			return readXml.GetConstantName("email");
		}
	}

	/// <summary>
	/// ServerName。
	/// </summary>
	private string ServerName
	{
		set
		{
			readXml.SaveValue("serverName", "value", value);
		}
		get
		{
			return readXml.GetConstantName("serverName");
		}
	}

	/// <summary>
	/// DataBase。
	/// </summary>
	private string DataBase
	{
		set
		{
			readXml.SaveValue("dataBase", "value", value);
		}
		get
		{
			return readXml.GetConstantName("dataBase");
		}
	}

	/// <summary>
	/// UserID。
	/// </summary>
	private string UserID
	{
		set
		{
			readXml.SaveValue("userID", "value", value);
		}
		get
		{
			return readXml.GetConstantName("userID");
		}
	}

	/// <summary>
	/// PassWord。
	/// </summary>
	private string PassWord
	{
		set
		{
			readXml.SaveValue("passWord", "value", value);
		}
		get
		{
			return readXml.GetConstantName("passWord");
		}
	}

    public string ColumnsInfoSQL
    {
        get
        {
            if (readXml.GetConstantName("DBType").Equals("SQLSERVER2005"))
            {
                return readXml.GetConstantText("Column-Info-SQL-2005");
            }
            else if (readXml.GetConstantName("DBType").Equals("SQLSERVER2000"))
            {
                return readXml.GetConstantText("Column-Info-SQL-2000");
            }
            else if (readXml.GetConstantName("DBType").Equals("ORACLE11G"))
            {
                return readXml.GetConstantText("Column-Info-Oracle");
            }
            else
            {
                //Common.IsSqlServer = false;
                return readXml.GetConstantText("Column-Info-SQL-MYSQL");
            }
        }
    }

    public string FKSQL
    {
        get
        {
            if (readXml.GetConstantName("DBType").Equals("SQLSERVER2005"))
            {
                return readXml.GetConstantText("FK-SQL-2005");
            }
            else if (readXml.GetConstantName("DBType").Equals("SQLSERVER2000"))
            {
                return readXml.GetConstantText("FK-SQL-2000");
            }
            else if (readXml.GetConstantName("DBType").Equals("ORACLE11G"))
            {
                return readXml.GetConstantText("FK-SQL-Oracle");
            }
            else 
            {
               // Common.IsSqlServer = false;
                return readXml.GetConstantText("FK-SQL-MYSQL");
            }
        }
    }

    public string TableSQL
    {
        get
        {
            if (readXml.GetConstantName("DBType").Equals("SQLSERVER2005"))
            {
                return readXml.GetConstantText("TableSQL-2005");
            }
            else if (readXml.GetConstantName("DBType").Equals("SQLSERVER2000"))
            {
                return readXml.GetConstantText("TableSQL-2000");
            }
            else if (readXml.GetConstantName("DBType").Equals("ORACLE11G"))
            {
                return readXml.GetConstantText("TableSQL-Oracle");
            }
            else
            {
                //Common.IsSqlServer = false;
                return readXml.GetConstantText("TableSQL-MySQL");
            }
        }
    }
}