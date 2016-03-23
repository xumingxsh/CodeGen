using System;

public static class CommonUtil
{
    public static string ToFirstUper(this string text)
    {
        if (text == null)
        {
            return "";
        }
        return text.Substring(0, 1).ToUpper() + text.Substring(1);
    }
    public static string ToFirstLower(this string text)
    {
        if (text == null)
        {
            return "";
        }
        return text.Substring(0, 1).ToLower() + text.Substring(1);
    }

    public static bool IsNullOrEmpty(this string text)
    {
        return string.IsNullOrEmpty(text);
    }

    public static string NoSpace(this string val)
    {
        if (val == null)
        {
            return val;
        }
        return val.Replace(" ", "");
    }

    public static string GetTableClassName(this string text)
    {
        return text.ToLower().ToFirstUper().Replace("_", "");
    }
}