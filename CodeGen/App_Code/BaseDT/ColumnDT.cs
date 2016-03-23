using System;
using System.Data;

/// <summary>
/// 数据库列信息类。
/// </summary>
/// <author>天志</author>
/// <log date="2007-09-01">创建</log>
public class ColumnDT 
{
	public ColumnDT() 
	{
	}
    public ColumnDT(DataRowView dv)
    {
        DataMarket.ReadColumnDT(this, dv.Row);
    }

    public ColumnDT(DataRowView dv, string tableCName)
    {
        this._TableCName = tableCName;
        DataMarket.ReadColumnDT(this, dv.Row);
    }

    /// <summary>
    /// 描述信息
    /// </summary>
    /// <author>天志</author>
    /// <log date="2007-09-01">创建</log>
    private string _script;

    /// <summary>
    /// 是否允许为空
    /// </summary>
    /// <author>天志</author>
    /// <log date="2007-09-01">创建</log>
    private int _isnullable;

    /// <summary>
    /// 是否标识
    /// </summary>
    private int _isMarking;

    /// <summary>
    /// 所属表名称
    /// </summary>
    /// <author>天志</author>
    /// <log date="2007-09-01">创建</log>
    public string TableName { get; set; }

    /// <summary>
    /// 所属表ID
    /// </summary>
    /// <author>天志</author>
    /// <log date="2007-09-01">创建</log>
    public int Id { get; set; }

    /// <summary>
    /// 列名
    /// </summary>
    /// <author>天志</author>
    /// <log date="2007-09-01">创建</log>
    public string ColumnName { get; set; }

    /// <summary>
    /// 列ID
    /// </summary>
    /// <author>天志</author>
    /// <log date="2007-09-01">创建</log>
    public int ColId { get; set; }

    /// <summary>
    /// 数据类型
    /// </summary>
    /// <author>天志</author>
    /// <log date="2007-09-01">创建</log>
    public string ColumnType { get; set; }

    /// <summary>
    /// 数据类型索引
    /// </summary>
    /// <author>天志</author>
    /// <log date="2007-09-01">创建</log>
    public int ColumnTypeIndex { get; set; }

    /// <summary>
    /// 字段长度
    /// </summary>
    /// <author>天志</author>
    /// <log date="2007-09-01">创建</log>
    public long Length { get; set; }

    /// <summary>
    /// 小数点位数
    /// </summary>
    /// <author>天志</author>
    /// <log date="2007-09-01">创建</log>
    public int Decimaldigits { get; set; }

    /// <summary>
    /// 描述信息
    /// </summary>
    /// <author>天志</author>
    /// <log date="2007-09-01">创建</log>
    public string Script
    {
        set
        {
            this._script = value;
        }
        get
        {
            return this._script.GetScript();
        }
    }

    /// <summary>
    /// 默认值
    /// </summary>
    /// <author>天志</author>
    /// <log date="2007-09-01">创建</log>
    public string DefaultValue { get; set; }

    /// <summary>
    /// 是否允许为空
    /// </summary>
    /// <author>天志</author>
    /// <log date="2007-09-01">创建</log>
    public bool IsNullable
    {
        set
        {
            if (value)
            {
                this._isnullable = 1;
            }
            else
            {
                this._isnullable = 0;
            }
        }
        get
        {
            if (this._isnullable == 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }

    /// <summary>
    /// 是否标识
    /// </summary>
    /// <author>天志</author>
    /// <log date="2007-09-01">创建</log>
    public bool IsMarking
    {
        set
        {
            if (value)
            {
                this._isMarking = 1;
            }
            else
            {
                this._isMarking = 0;
            }
        }
        get
        {
            if (this._isMarking == 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }

    /// <summary>
    /// 是否主键
    /// </summary>
    public bool IsPK
    {
        get
        {
            return DataMarket.IsPKForColumn(this.TableName, this.ColumnName);
        }
    }
    /// <summary>
    /// 是否外键。
    /// </summary>
    public bool IsFK
    {
        get
        {
            return DataMarket.IsFKForColumn(this.TableName, this.ColumnName);
        }
    }

    /// <summary>
    /// 该列的数据类型
    /// </summary>
    public string CSDataType
    {
        get
        {
            return DBCommon.GetCSDataType(this.ColumnType);
        }
    }

    /// <summary>
    /// 取得首字母小写的名称。
    /// </summary>
    public string FirstCharLower
    {
        get
        {
            return this.ColumnName.ToFirstLower();
            // return Common.SetFirstCharLower(this.ColumnName);
        }
    }

    /// <summary>
    /// 取得首字母大写的名称。
    /// </summary>
    public string FirstCharUpper
    {
        get
        {
            return this.ColumnName.ToFirstUper();
            //return Common.SetFirstCharUpper(this.ColumnName);
        }
    }

    /// <summary>
    /// 中文名称。
    /// </summary>
    public string CNName
    {
        get
        {
            if (this.Script.IsNullOrEmpty())
            {
                return this.ColumnName;
            }
            return this.Script;
        }
    }

    /// <summary>
    /// 是否GUID
    /// </summary>
    public bool IsGUID
    {
        get
        {
            // 是主键，不是外键，是string类型，包含guid
            return DBCommon.IsGUID(this);
        }
    }

    /// <summary>
    /// 是否日期类型。
    /// </summary>
    public bool IsDateTime
    {
        get
        {
            if (this.ColumnType.ToLower().Equals("datetime") ||
                this.ColumnType.ToLower().Equals("smalldatetime") ||
                this.ColumnType.ToLower().Equals("timestamp"))
            {
                return true;
            }
            return false;
        }
    }

    /// <summary>
    /// 是否是字符串。
    /// </summary>
    public bool IsString
    {
        get
        {
            return this.CSDataType.Equals("string");
        }
    }

    /// <summary>
    /// 是否是短整型。
    /// </summary>
    public bool IsInt16
    {
        get
        {
            return this.CSDataType.Equals("short");
        }
    }

    /// <summary>
    /// 是否是整型。
    /// </summary>
    public bool IsInt32
    {
        get
        {
            return this.CSDataType.Equals("int");
        }
    }

    /// <summary>
    /// 是否是长整型。
    /// </summary>
    public bool IsInt64
    {
        get
        {
            return this.CSDataType.Equals("long");
        }
    }

    /// <summary>
    /// 是否是float。
    /// </summary>
    public bool IsFloat
    {
        get
        {
            return this.CSDataType.Equals("float");
        }
    }

    /// <summary>
    /// 是否是decimal。
    /// </summary>
    public bool IsDecimal
    {
        get
        {
            return this.CSDataType.Equals("decimal");
        }
    }

    /// <summary>
    /// 是否整数。
    /// </summary>
    public bool IsInt
    {
        get
        {
            if (this.IsInt16 || this.IsInt32 || this.IsInt64)
            {
                return true;
            }
            return false;
        }
    }

    /// <summary>
    /// 是否小数。
    /// </summary>
    public bool IsDecimalOrFloat
    {
        get
        {
            if (this.IsFloat || this.IsDecimal)
            {
                return true;
            }
            return false;
        }
    }

    /// <summary>
    /// 取得变量名称。
    /// </summary>
    public string FieldName
    {
        get
        {
            return "_" + this.ColumnName.ToFirstLower();
        }
    }

    public string Java_DateType
    {
        get
        {
            if (this.IsDateTime)
            {
                return "Date";
            }
            else if (this.IsString)
            {
                return "String";
            }
            else if (this.IsDecimal)
            {
                return "double";
            }
            else
            {
                return this.CSDataType;
            }
        }
    }

    /// <summary>
    /// 属性名称。
    /// </summary>
    public string PropertyName
    {
        get
        {
            return this.ColumnName.ToFirstUper();
        }
    }

    /// <summary>
    /// 页面控件名称。
    /// </summary>
    public string ControlName
    {
        get
        {
            if (this.IsFK)
            {
                return "drp" + this.ColumnName.ToFirstUper();
            }
            if (this.CSDataType.Equals("bool"))
            {
                return "drp" + this.ColumnName.ToFirstUper();
            }
            return "txt" + this.ColumnName.ToFirstUper();
        }
    }

    /// <summary>
    /// 数据转换格式。
    /// </summary>
    public string ConvertString
    {
        get
        {
            return this.ConvertString();
        }
    }

    private string _TableCName;

    public string TableCName
    {
        get
        {
            if (_TableCName == null)
            {
                return this.TableName;
            }
            return _TableCName;
        }
    }
}
