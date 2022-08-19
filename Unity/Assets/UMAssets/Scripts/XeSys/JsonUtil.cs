using System;

namespace XeSys
{
	public class JsonUtil
	{
		// // RVA: 0x2389D1C Offset: 0x2389D1C VA: 0x2389D1C
		// public static EDOHBJAPLPF GetArray(EDOHBJAPLPF jdata, string key) { }

		// // RVA: 0x2389D78 Offset: 0x2389D78 VA: 0x2389D78
		// public static EDOHBJAPLPF GetArrayObject(EDOHBJAPLPF jdata, string key, int index) { }

		// // RVA: 0x2389DA8 Offset: 0x2389DA8 VA: 0x2389DA8
		public static EDOHBJAPLPF_JsonData GetObject(EDOHBJAPLPF_JsonData jdata, string key)
		{
			if(!jdata.BBAJPINMOEP_Contains(key))
				return null;
			if(jdata[key].LLHIGGPIILM_IsObject)
				return jdata[key];
			return null;
		}

		// // RVA: 0x2389E30 Offset: 0x2389E30 VA: 0x2389E30
		public static string GetString(EDOHBJAPLPF_JsonData jdata, string key, string notExistValue)
		{
			if(jdata.BBAJPINMOEP_Contains(key))
			{
				if(jdata[key].EPNAPDBIJJE_IsString)
				{
					return (string)jdata[key];
				}
				else if(jdata[key].MDDJBLEDMBJ_IsInt)
				{
					return "" + ((int)jdata[key]);
				}
				else if(jdata[key].DCPEFFOMOOK_IsLong)
				{
					return "" + ((long)jdata[key]);
				}
			}
			return notExistValue;
		}

		// // RVA: 0x238A09C Offset: 0x238A09C VA: 0x238A09C
		// public static string GetString(EDOHBJAPLPF jdata, string key) { }

		// // RVA: 0x238A108 Offset: 0x238A108 VA: 0x238A108
		// public static float GetFloat(EDOHBJAPLPF jdata, string key, float notExistValue) { }

		// // RVA: 0x238A308 Offset: 0x238A308 VA: 0x238A308
		// public static float GetFloat(EDOHBJAPLPF jdata, string key) { }

		// // RVA: 0x238A310 Offset: 0x238A310 VA: 0x238A310
		public static int GetInt(EDOHBJAPLPF_JsonData jdata, string key, int notExistValue)
		{
			if(!jdata.BBAJPINMOEP_Contains(key))
				return notExistValue;
			if(jdata[key].MDDJBLEDMBJ_IsInt)
			{
				return (int)jdata[key];
			}
			else
			{
				if(jdata[key].EPNAPDBIJJE_IsString)
				{
					int val;
					if(Int32.TryParse((string)jdata[key], out val))
					{
						return val;
					}
				}
			}
			return 0;
		}

		// // RVA: 0x238A4F8 Offset: 0x238A4F8 VA: 0x238A4F8
		public static int GetInt(EDOHBJAPLPF_JsonData jdata, string key)
		{
			return GetInt(jdata, key, 0);
		}

		// // RVA: 0x238A500 Offset: 0x238A500 VA: 0x238A500
		public static int GetInt(EDOHBJAPLPF_JsonData jdata)
		{
			if(jdata.MDDJBLEDMBJ_IsInt)
			{
				return (int)jdata;
			}
			else
			{
				if(jdata.EPNAPDBIJJE_IsString)
				{
					int val;
					if(Int32.TryParse((string)jdata, out val))
					{
						return val;
					}
				}
			}
			return 0;
		}

		// // RVA: 0x238A62C Offset: 0x238A62C VA: 0x238A62C
		public static long GetLong(EDOHBJAPLPF_JsonData jdata, string key, long notExistValue)
		{
			if(jdata.BBAJPINMOEP_Contains(key))
			{
				if(jdata[key].DCPEFFOMOOK_IsLong)
				{
					return (long)jdata[key];
				}
				if(jdata[key].MDDJBLEDMBJ_IsInt)
				{
					return (long)((int)jdata[key]);
				}
				if(jdata[key].EPNAPDBIJJE_IsString)
				{
					long val;
					if(Int64.TryParse((string)jdata[key], out val))
					{
						return val;
					}
				}
				return 0;
			}
			else
				return notExistValue;
		}

		// // RVA: 0x238A8D0 Offset: 0x238A8D0 VA: 0x238A8D0
		public static long GetLong(EDOHBJAPLPF_JsonData jdata, string key)
		{
			return GetLong(jdata, key, 0);
		}

		// // RVA: 0x238A8F0 Offset: 0x238A8F0 VA: 0x238A8F0
		public static long GetLong(EDOHBJAPLPF_JsonData jdata)
		{
			if(jdata != null)
			{
				if(jdata.DCPEFFOMOOK_IsLong)
				{
					return (long)jdata;
				}
				if(jdata.MDDJBLEDMBJ_IsInt)
				{
					return (long)((int)jdata);
				}
				if(jdata.EPNAPDBIJJE_IsString)
				{
					long val;
					if(Int64.TryParse((string)jdata, out val))
					{
						return val;
					}
				}
			}
			return 0;
		}

		// // RVA: 0x238AA9C Offset: 0x238AA9C VA: 0x238AA9C
		public static bool GetFlag(EDOHBJAPLPF_JsonData jdata, string key, bool notExistValue)
		{
			int val = GetInt(jdata, key, -1);
			if(val != -1)
				return val != 0;
			return notExistValue;
		}

		// // RVA: 0x238AACC Offset: 0x238AACC VA: 0x238AACC
		// public static bool GetFlag(EDOHBJAPLPF jdata, string key) { }

		// // RVA: 0x238AAF0 Offset: 0x238AAF0 VA: 0x238AAF0
		// public static bool IsExist(EDOHBJAPLPF from, string key) { }

		// // RVA: 0x238AB24 Offset: 0x238AB24 VA: 0x238AB24
		// public static void WriteValue(KIJECNFNNDB writer, string propertyName, object value) { }

		// // RVA: 0x238AD40 Offset: 0x238AD40 VA: 0x238AD40
		// public static void WriteObject(KIJECNFNNDB writer, string objectName, Dictionary<string, object> properties) { }

		// // RVA: 0x238AF4C Offset: 0x238AF4C VA: 0x238AF4C
		// public static void WriteArray(KIJECNFNNDB writer, string arrayName, List<object> objects) { }
	}
}
