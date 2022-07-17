using UnityEngine;
using System.Collections.Generic;
using System;
using System.Text;

namespace XeApp.Game.Common
{
	public class FacialNameDatabase
	{
		private static List<string> facialNameList = new List<string>(); // 0x0
		public static bool isInitialized = false; // 0x4

		// // RVA: 0x1C12F70 Offset: 0x1C12F70 VA: 0x1C12F70
		public static void Create(TextAsset textAsset)
		{
			if(isInitialized == false)
			{
				for(int startIndex = 0; startIndex < textAsset.bytes.Length;)
				{
					int strSize = BitConverter.ToInt32(textAsset.bytes, startIndex);
					string str = Encoding.UTF8.GetString(textAsset.bytes, startIndex + 4, strSize);
					facialNameList.Add(str);
					startIndex += 4 + strSize;
				}
				isInitialized = true;
			}
		}

		// // RVA: 0x1C131F0 Offset: 0x1C131F0 VA: 0x1C131F0
		// public static void Release() { }

		// // RVA: 0x1C132FC Offset: 0x1C132FC VA: 0x1C132FC
		public static void CreateFacialOverrideList(TextAsset facialTableAsset, int divaId, ref List<string> originalFacialNames, ref List<int> overrideFacialIds)
		{
			int num = BitConverter.ToInt32(facialTableAsset.bytes, 0);
			int offsetRead = 4;
			for(int i = 0; i < num; i++)
			{
				int strSize = BitConverter.ToInt32(facialTableAsset.bytes, offsetRead);
				string txt = Encoding.UTF8.GetString(facialTableAsset.bytes, offsetRead + 4, strSize);
				offsetRead += strSize + 4;
				originalFacialNames.Add(txt);
			}
			offsetRead = (divaId-1) * 4 * num + offsetRead;
			for(int i = 0; i < num; i++)
			{
				int offset = BitConverter.ToInt32(facialTableAsset.bytes, offsetRead);
				offsetRead += 4;
				overrideFacialIds.Add(offset);
			}
		}

		// // RVA: 0x1C135B4 Offset: 0x1C135B4 VA: 0x1C135B4
		public static string ToString(int id)
		{
			if(facialNameList == null)
				return null;
			if(id < facialNameList.Count)
			{
				return facialNameList[id];
			}
			return null;
		}
	}
}
