using UnityEngine;
using System.Collections.Generic;

namespace XeApp.Game.Common
{
	public class FacialNameDatabase
	{
		// Fields
		private static List<string> facialNameList; // 0x0
		public static bool isInitialized; // 0x4

		// Methods

		// // RVA: 0x1C12F70 Offset: 0x1C12F70 VA: 0x1C12F70
		// public static void Create(TextAsset textAsset) { }

		// // RVA: 0x1C131F0 Offset: 0x1C131F0 VA: 0x1C131F0
		// public static void Release() { }

		// // RVA: 0x1C132FC Offset: 0x1C132FC VA: 0x1C132FC
		public static void CreateFacialOverrideList(TextAsset facialTableAsset, int divaId, ref List<string> originalFacialNames, ref List<int> overrideFacialIds)
		{
			UnityEngine.Debug.LogError("TODO");
		}

		// // RVA: 0x1C135B4 Offset: 0x1C135B4 VA: 0x1C135B4
		public static string ToString(int id)
		{
			UnityEngine.Debug.LogError("TODO");
			return "";
		}

		// // RVA: 0x1C1372C Offset: 0x1C1372C VA: 0x1C1372C
		// public void .ctor() { }

		// // RVA: 0x1C13734 Offset: 0x1C13734 VA: 0x1C13734
		// private static void .cctor() { }
	}
}
