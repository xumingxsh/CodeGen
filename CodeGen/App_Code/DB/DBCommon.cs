using System;
using System.Data;


static class DBCommon
{

    public static string ConvertString(this ColumnDT dt)
    {
        if (dt.IsGUID || dt.IsString || dt.IsMarking)
        {
            return "";
        }
        if (dt.IsInt16)
        {
            return "Convert.ToInt16";
        }
        if (dt.IsInt32)
        {
            return "Convert.ToInt32";
        }
        if (dt.IsInt64)
        {
            return "Convert.ToInt64";
        }
        if (dt.IsDecimal)
        {
            return "Convert.ToDecimal";
        }
        if (dt.IsFloat)
        {
            return "Convert.ToSingle";
        }
        return "";
    }

    public static string GetScript(this string script)
    {
        if (script == null)
        {
            return "";
        }
        script = script.Replace("\r\n", "");
        if (script.Length > 40)
        {
            script = script.Substring(0, 40);
        }
        return script;
    }
    /// <summary>
    /// 根据数据库中的字段类型，取得C#中相应的数据类型。
    /// </summary>
    /// <param name="type">数据库中的字段类型</param>
    /// <returns>C#中的数据类型</returns>
    public static string GetCSDataType(string type)
    {
        type = type.Trim().ToLower();
        switch (type)
        {
            case "char":
            case "varchar":
            case "nchar":
            case "nvarchar":
            case "text":
            case "ntext":
            case "datetime":
            case "smalldatetime":
            case "timestamp":
                return "string";
            case "bigint":
                return "long";
            case "binary":
            case "image":
            case "varbinary":
                //return "byte[]";
                return "string";
            case "int":
                return "int";
            case "smallint":
                return "short";
            case "variant":
                return "Object";
            case "bit":
                //return "bool";
                return "int";
            case "decimal":
            case "money":
            case "smallmoney":
            case "double":
            case "numeric":
                return "decimal";
            case "float":
            case "real":
                return "float";
            case "tinyint":
                //return "byte";
                return "int";
            case "uniqueidentifier":
                return "System.Guid";
            default:
                return "string";
        }
    }

    /// <summary>
    /// 是否GUID
    /// </summary>
    public static bool IsGUID(ColumnDT dt)
    {
        // 是主键，不是外键，是string类型，包含guid
        if (dt.IsPK &&
            !dt.IsFK &&
            (dt.CSDataType.Equals("string") || dt.CSDataType.Equals("System.Guid")) &&
            dt.ColumnName.ToLower().Contains("guid"))
        {
            return true;
        }
        return false;
    }
}
