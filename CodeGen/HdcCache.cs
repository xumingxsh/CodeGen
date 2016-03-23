using System;
using System.Data;
using System.IO;


/// <summary>
/// HdcCache 的摘要说明。
/// </summary>
public class HdcCache
{
    /// <summary>
    /// 存储数据的对象。
    /// </summary>
    /// <author>xumr</author>
    /// <log date="2005-05-15">创建</log>
    private object obj = null;

    /// <summary>
    /// 文件路径。
    /// </summary>
    /// <author>xumr</author>
    /// <log date="2005-05-15">创建</log>
    private string filePath = null;

    /// <summary>
    /// 文件的最后修改日期。
    /// </summary>
    /// <author>xumr</author>
    /// <log date="2005-05-15">创建</log>
    private DateTime fileUpdateTime;

    /// <summary>
    /// 刷新频率。
    /// </summary>
    /// <author>xumr</author>
    /// <log date="2005-05-15">创建</log>
    private int second = 0;

    /// <summary>
    /// 数据的读取日期。
    /// </summary>
    /// <author>xumr</author>
    /// <log date="2005-05-15">创建</log>
    private DateTime setTime;

    /// <summary>
    /// 默认构造函数。
    /// </summary>
    /// <author>xumr</author>
    /// <log date="2005-05-15">创建</log>
    public HdcCache()
    {
        //do nothing
    }

    /// <summary>
    /// 取得文件数据。
    /// </summary>
    /// <param name="filePath">文件路径</param>
    /// <param name="second">数据更新频率</param>
    public void Init(string filePath, int second)
    {
        this.obj = null;

        this.filePath = filePath;
        if (filePath != null)
        {
            this.fileUpdateTime = File.GetLastWriteTime(filePath);
            this.second = second;
            this.setTime = DateTime.Now;
        }
    }

    public void Init(string filePath)
    {
        this.obj = null;

        this.filePath = filePath;
        if (filePath != null)
        {
            this.fileUpdateTime = File.GetLastWriteTime(filePath);
        }
    }

    public void Init(int second)
    {
        this.obj = null;

        this.second = second;
        if (second <= 0)
        {
            this.setTime = DateTime.Now;
        }
    }

    public object Get()
    {
        if (this.obj == null)
        {
            return null;
        }

        if (this.filePath != null)
        {
            DateTime updateTime = File.GetLastWriteTime(this.filePath);
            if (!updateTime.Equals(this.fileUpdateTime))
            {
                this.obj = null;
                return null;
            }
        }

        if (this.second > 0)
        {
            TimeSpan timeSpan = DateTime.Now - this.setTime;
            if (timeSpan.TotalSeconds > this.second)
            {
                this.obj = null;
                return null;
            }
        }

        return this.obj;
    }

    public void Set(object obj)
    {
        this.obj = obj;

        if (this.second > 0)
        {
            this.setTime = DateTime.Now;
        }

        if (this.filePath != null)
        {
            this.fileUpdateTime = File.GetLastWriteTime(filePath);
        }
    }
}
