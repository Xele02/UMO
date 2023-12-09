using System;
using System.IO;
using UnityEngine;

namespace XeSys
{
	public class Utility
	{
		private static DateTime UNIX_EPOCH = new DateTime(1970, 1, 1, 0, 0, 0, 1, 0); // 0x0

		// // RVA: 0x23A8920 Offset: 0x23A8920 VA: 0x23A8920
		// public static int GetVersionValue(string versionString) { }

		// // RVA: 0x23A8B0C Offset: 0x23A8B0C VA: 0x23A8B0C
		// public static string GetString(byte[] bytes, int length, ref int offset) { }

		// // RVA: 0x23A8B7C Offset: 0x23A8B7C VA: 0x23A8B7C
		// public static string GetString(byte[] bytes, ref int offset) { }

		// // RVA: 0x23A8CFC Offset: 0x23A8CFC VA: 0x23A8CFC
		// public static string GetAsciiString(byte[] bytes, ref int offset, int length) { }

		// // RVA: 0x23A8DD4 Offset: 0x23A8DD4 VA: 0x23A8DD4
		// public static byte GetValueByte(byte[] bytes, ref int offset) { }

		// // RVA: 0x23A8C60 Offset: 0x23A8C60 VA: 0x23A8C60
		// public static short GetValueInt16(byte[] bytes, ref int offset) { }

		// // RVA: 0x23A8E2C Offset: 0x23A8E2C VA: 0x23A8E2C
		// public static ushort GetValueUInt16(byte[] bytes, ref int offset) { }

		// // RVA: 0x2397640 Offset: 0x2397640 VA: 0x2397640
		public static int GetValueInt32(byte[] bytes, ref int offset)
		{
			int val = BitConverter.ToInt32(bytes, offset);
			offset += 4;
			return val;
		}

		// // RVA: 0x23A8EC8 Offset: 0x23A8EC8 VA: 0x23A8EC8
		// public static uint GetValueUInt32(byte[] bytes, ref int offset) { }

		// // RVA: 0x23A8F64 Offset: 0x23A8F64 VA: 0x23A8F64
		// public static float GetValueFloat(byte[] bytes, ref int offset) { }

		// // RVA: 0x23A9000 Offset: 0x23A9000 VA: 0x23A9000
		public static DateTime GetLocalDateTime(long unixTime)
		{
			//UMO, get real timeline
			double diff = (DateTime.Now - DateTime.UtcNow).TotalSeconds;
			return /*TimeZoneInfo.ConvertTimeToUtc(*/UNIX_EPOCH.AddSeconds(unixTime + diff/* + 32400*/)/*)*/;
		}

		// // RVA: 0x23A90F8 Offset: 0x23A90F8 VA: 0x23A90F8
		public static long GetTargetUnixTime(int year, int month, int day, int hour, int minute, int second)
		{
			DateTime date = new DateTime(year, month, day, hour, minute, second, DateTimeKind.Local);
			return (long)(TimeZoneInfo.ConvertTimeToUtc(date) - UNIX_EPOCH).TotalSeconds;
		}

		// // RVA: 0x23A9268 Offset: 0x23A9268 VA: 0x23A9268
		public static long GetCurrentUnixTime()
		{
			return (long)(DateTime.UtcNow - UNIX_EPOCH).TotalSeconds;
		}

		// // RVA: 0x23A9378 Offset: 0x23A9378 VA: 0x23A9378
		public static bool IsWithinPeriod(long current, long start, long end)
		{
			if(start == 0)
			{
				return !(end < current);
			}
			if ((end == 0 || end > current) && current >= start)
				return true;
			return false;
		}

		// // RVA: 0x23A93DC Offset: 0x23A93DC VA: 0x23A93DC
		// public static string GetDayStringFromUNIXTime(long unix_time) { }

		// // RVA: 0x23A9754 Offset: 0x23A9754 VA: 0x23A9754
		// public static string GetTimeStringFromUNIXTime(long unix_time) { }

		// // RVA: 0x23A98A4 Offset: 0x23A98A4 VA: 0x23A98A4
		// public static bool IsAcrossHour(long prevUnixTime, long nextUnixTime) { }

		// // RVA: 0x23A99C8 Offset: 0x23A99C8 VA: 0x23A99C8
		// public static bool IsAcrossDay(long prevUnixTime, long nextUnixTime) { }

		// // RVA: 0x23A9AF0 Offset: 0x23A9AF0 VA: 0x23A9AF0
		public static void SaveToStorage(string path, byte[] bytes, bool overwrite)
		{
			TodoLogger.Log(TodoLogger.Filesystem, "Save to "+path);
			path = path.Replace("file://", "");
			string dir = Path.GetDirectoryName(path);
			if(!Directory.Exists(dir))
			{
				Directory.CreateDirectory(dir);
			}
			if(!overwrite)
			{
				if(System.IO.File.Exists(path))
					return;
			}
			FileStream f = new FileStream(path, FileMode.Create, FileAccess.Write);
			f.Write(bytes, 0, bytes.Length);
			f.Close();
		}

		// // RVA: -1 Offset: -1
		// public static void Swap<T>(ref T lhs, ref T rhs) { }
		// /* GenericInstMethod :
		// |
		// |-RVA: 0x1AB5348 Offset: 0x1AB5348 VA: 0x1AB5348
		// |-Utility.Swap<object>
		// */

		// // RVA: -1 Offset: -1
		// public static int EnumCount<T>() { }
		// /* GenericInstMethod :
		// |
		// |-RVA: 0x1C6AFCC Offset: 0x1C6AFCC VA: 0x1C6AFCC
		// |-Utility.EnumCount<object>
		// */

		// // RVA: 0x23A9CA0 Offset: 0x23A9CA0 VA: 0x23A9CA0
		// public static GameObject FindGameObject(string name) { }

		// // RVA: -1 Offset: -1
		// public static T GetGameObjectComponent<T>(string gameObjectName) { }
		// /* GenericInstMethod :
		// |
		// |-RVA: 0x20927E4 Offset: 0x20927E4 VA: 0x20927E4
		// |-Utility.GetGameObjectComponent<object>
		// */

		// // RVA: -1 Offset: -1
		// public static T GetSafeComponent<T>(GameObject go) { }
		// /* GenericInstMethod :
		// |
		// |-RVA: 0x20928F4 Offset: 0x20928F4 VA: 0x20928F4
		// |-Utility.GetSafeComponent<object>
		// */

		// // RVA: 0x23A9D3C Offset: 0x23A9D3C VA: 0x23A9D3C
		// public static void SetActiveGameObject(GameObject go, bool active) { }

		// // RVA: 0x23A9D70 Offset: 0x23A9D70 VA: 0x23A9D70
		// public static void SetActiveGameObjectRecursively(GameObject go, bool flag) { }

		// // RVA: 0x23A9DA4 Offset: 0x23A9DA4 VA: 0x23A9DA4
		// public static bool IsActiveGameObject(GameObject go) { }

		// // RVA: 0x23A9DD0 Offset: 0x23A9DD0 VA: 0x23A9DD0
		public static GameObject SearchGameObjectRecursively(string name, Transform rootTrans)
		{
			foreach(var t in rootTrans)
			{
				if ((t as Transform).gameObject.name == name)
					return (t as Transform).gameObject;
				GameObject o = SearchGameObjectRecursively(name, t as Transform);
				if (o != null)
					return o;
			}
			return null;
		}

		// // RVA: -1 Offset: -1
		// public static T SearchComponentRecursively<T>(string gameObjectName, Transform rootTform) { }
		// /* GenericInstMethod :
		// |
		// |-RVA: 0x20929AC Offset: 0x20929AC VA: 0x20929AC
		// |-Utility.SearchComponentRecursively<object>
		// */

		// // RVA: 0x23AA2AC Offset: 0x23AA2AC VA: 0x23AA2AC
		// public static int CalculateSdbmHash(byte[] bytes) { }

		// // RVA: 0x23AA334 Offset: 0x23AA334 VA: 0x23AA334
		// public static int CalculateSdbmHash(byte[] bytes, int initValue) { }

		// // RVA: 0x23AA3A0 Offset: 0x23AA3A0 VA: 0x23AA3A0
		// public static bool IsRanged(float val, float min, float max) { }

		// // RVA: 0x23AA3D0 Offset: 0x23AA3D0 VA: 0x23AA3D0
		// public static List<int> SepalateDigit(int number) { }

		// // RVA: 0x23AA484 Offset: 0x23AA484 VA: 0x23AA484
		// public static List<int> SepalateDigit(int number, List<int> inputList) { }

		// // RVA: 0x23AA62C Offset: 0x23AA62C VA: 0x23AA62C
		// public static float SqrDistance(Vector3 a, Vector3 b) { }

		// // RVA: 0x23AA70C Offset: 0x23AA70C VA: 0x23AA70C
		// public static Type GetType(string TypeName) { }

		// // RVA: 0x23AAA20 Offset: 0x23AAA20 VA: 0x23AAA20
		// public static bool TryParseFast(string s, out float result) { }

		// // RVA: 0x23AAA80 Offset: 0x23AAA80 VA: 0x23AAA80
		// public static string MakeMMSSsssTimeByMillisec(int milliSec) { }

		// // RVA: 0x23AAB14 Offset: 0x23AAB14 VA: 0x23AAB14
		// public static string MakeMMSSsssTimeBySec(float sec) { }

		// // RVA: 0x23AAC90 Offset: 0x23AAC90 VA: 0x23AAC90
		public static long RoundDownDayUnixTime(long unixtime, int offset = 0)
		{
			DateTime d = GetLocalDateTime(unixtime);
			return GetTargetUnixTime(d.Year, d.Month, d.Day, 0, 0, 0) + offset;
		}
	}
}
