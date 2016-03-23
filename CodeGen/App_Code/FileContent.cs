using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.IO;
using System.Text;

/// <summary>
/// 模板对象。
/// </summary>
public class FileContent
{
	private FileContent(string path)
	{
        this.path = path;
        lastUpdateTime = File.GetLastWriteTime(path);
	}

    /// <summary>
    /// 文本内容。
    /// </summary>
    private string Content;

    /// <summary>
    /// 最后更新时间。
    /// </summary>
    private DateTime lastUpdateTime;

    /// <summary>
    /// 文件路径。
    /// </summary>
    private string path;

    /// <summary>
    /// 判断文本是否已经修改。
    /// </summary>
    private bool IsChanged
    {
        get
        {
            if (this.lastUpdateTime != File.GetLastWriteTime(this.path))
            {
                return true;
            }
            return false;
        }
    }

    /// <summary>
    /// 文本信息。
    /// </summary>
    /// <param name="path"></param>
    /// <returns></returns>
    public static FileContent GetContent(string path)
    {
        using (StreamReader reader = new StreamReader(path, Encoding.UTF8))
        {
            FileContent content = new FileContent(path);
            StringBuilder sb = new StringBuilder();
            string line = reader.ReadLine();
            while (line != null)
            {
                sb.Append(line + "\r\n");
                line = reader.ReadLine();
            }
            content.Content = sb.ToString();
            return content;
        }
    }

    /// <summary>
    /// 存储模版信息的HashTable。
    /// </summary>
    private static Hashtable templateTable = new Hashtable();

    /// <summary>
    /// 根据路径取得模版信息。
    /// </summary>
    /// <param name="path">路径</param>
    /// <returns>模板字符串</returns>
    public static string GetContentString(string path)
    {
        FileContent fileContent = templateTable[path] as FileContent;

        if (fileContent != null && !fileContent.IsChanged)
        {
            return fileContent.Content;
        }

        fileContent = FileContent.GetContent(path.Replace("~", ""));
        templateTable[path] = fileContent;
        return fileContent.Content;
    }

}
