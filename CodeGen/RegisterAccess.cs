//===================================================================
//	created:	2004/03/31   13:40
//	file base:	RegisterAccess
//	author:		DoItNow
//	
//	purpose:	
//===================================================================

using System;
using Microsoft.Win32;


/// <summary>
/// RegisterAccess 的摘要说明。
/// </summary>
public class RegisterAccess
{
	static RegisterAccess()
	{
	}

	/// <summary>
	/// 读取注册表，返回指定键的值
	/// </summary>
	/// <param name="keyName"></param>
	/// <returns></returns>
	public static string ReadKey(string keyName)
	{
		return RegistFields.instance.GetValue(keyName);
	}

	/// <summary>
	/// 向指定的键写入某个值
	/// </summary>
	/// <param name="keyName"></param>
	/// <returns></returns>
	public static bool WriteKey(string keyName,string keyValue)
	{
		RegistFields.instance.SetValue(keyName, keyValue);
		return true;
	}
}

