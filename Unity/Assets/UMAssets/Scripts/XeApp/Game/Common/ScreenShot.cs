using System;
using System.Collections;
using System.IO;
using UnityEngine;
using UnityEngine.Events;

namespace XeApp.Game.Common
{
	public class ScreenShot
	{
		public enum ReturnCode
		{
			NotAbailableStorage = 0,
			NotPermission = 1,
			Ok = 2,
		}

		public enum PermissionFuncResultCode
		{
			Ok = 0,
			Cancell = 1,
		}

		public delegate IEnumerator PermissionFunc(Action<PermissionFuncResultCode> result);

		private const string SnsShareImageFilePath = "/share.png";

		// [IteratorStateMachineAttribute] // RVA: 0x73A80C Offset: 0x73A80C VA: 0x73A80C
		// RVA: 0x138C7F4 Offset: 0x138C7F4 VA: 0x138C7F4
		public static IEnumerator SaveScreenShot(string fileName, byte[] saveFile, UnityAction<ReturnCode, string> callBack, PermissionFunc requestParmissionFunc)
		{
			bool permission_ok;
			string shareFilePath;

			//0x138E550
			if(!IsAvailableStoreage(saveFile.Length))
			{
				if(callBack != null)
					callBack(ReturnCode.NotAbailableStorage, "");
				yield break;
			}
			permission_ok = false;
			if(!IsAvailableStoreageAccess())
			{
				yield return Co.R(Co_RequestPermission(requestParmissionFunc));
				if(!IsAvailableStoreageAccess())
				{
					if(!permission_ok)
					{
						if(callBack != null)
							callBack(ReturnCode.NotPermission, "");
						yield break;
					}
				}
			}
			permission_ok = true;
			//LAB_0138e6bc
			shareFilePath = "";
			shareFilePath = string.Format("{0}{1}.png", GetImageSavePath(), fileName);
			yield return Co.R(Co_SaveFile(shareFilePath, saveFile));
			if(callBack != null)
				callBack(ReturnCode.Ok, shareFilePath);
			shareFilePath = null;
		}

		// RVA: 0x138C8EC Offset: 0x138C8EC VA: 0x138C8EC
		public static void Share(string shareImageFile, string teamplate)
		{
			if(string.IsNullOrEmpty(shareImageFile))
				return;
			TodoLogger.LogError(TodoLogger.Android, "Share");
			//AndroidUtils.OnShare2(shareImageFile, teamplate, StringLiteral_14411);
		}

		// // RVA: 0x138C99C Offset: 0x138C99C VA: 0x138C99C
		private static bool IsAvailableStoreage(long fileSize)
		{
			TodoLogger.LogError(TodoLogger.Android, "IsAvailableStoreage");
			return true;
		}

		// // RVA: 0x138CA34 Offset: 0x138CA34 VA: 0x138CA34
		private static bool IsAvailableStoreageAccess()
		{
			TodoLogger.LogError(TodoLogger.Android, "IsAvailableStoreageAccess");
			return true;
		}

		// [IteratorStateMachineAttribute] // RVA: 0x73A884 Offset: 0x73A884 VA: 0x73A884
		// // RVA: 0x138CAB4 Offset: 0x138CAB4 VA: 0x138CAB4
		private static IEnumerator Co_SaveFile(string fileName, byte[] bytes)
		{
			//0x138E44C
			File.WriteAllBytes(fileName, bytes);
			yield return null;
			ScanMedia(fileName);
		}

		// // RVA: 0x138CB7C Offset: 0x138CB7C VA: 0x138CB7C
		private static void ScanMedia(string path)
		{
			if(Application.platform == RuntimePlatform.Android)
			{
				TodoLogger.LogError(TodoLogger.Android, "ScanMedia");
			}
		}

		// [IteratorStateMachineAttribute] // RVA: 0x73A8FC Offset: 0x73A8FC VA: 0x73A8FC
		// // RVA: 0x138D388 Offset: 0x138D388 VA: 0x138D388
		private static IEnumerator Co_RequestPermission(ScreenShot.PermissionFunc requestParmissionFunc)
		{
			int i;

			//0x138D828
			TodoLogger.LogError(TodoLogger.Android, "Co_RequestPermission");
			yield return null;
		}

		// // RVA: 0x138D434 Offset: 0x138D434 VA: 0x138D434
		private static string GetImageSavePath()
		{
			string str = "";
			if(Application.platform == RuntimePlatform.Android)
			{
				TodoLogger.LogError(TodoLogger.Android, "GetImageSavePath");
			}
			else
			{
				str = Application.dataPath + "/../Photo/";
			}
			if(!string.IsNullOrEmpty(str))
			{
				if(!Directory.Exists(str))
					Directory.CreateDirectory(str);
			}
			return str;
		}
	}
}
