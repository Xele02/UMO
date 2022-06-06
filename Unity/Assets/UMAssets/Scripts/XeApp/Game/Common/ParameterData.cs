using UnityEngine;
using System.Text;
using System.Collections.Generic;
using System;

namespace XeApp.Game.Common
{
	public class ParameterData
	{
		protected List<List<int>> m_data_int = new List<List<int>>(); // 0x8
		protected List<string> m_data_str = new List<string>(); // 0xC
		public bool isCreate; // 0x10

		// // RVA: 0xAF4C20 Offset: 0xAF4C20 VA: 0xAF4C20
		public void Create(TextAsset a_text_asset)
		{
			UnityEngine.Debug.LogError("TO DEBUG CHECK");
			int val1 = BitConverter.ToInt32(a_text_asset.bytes, 3);
			int val2 = BitConverter.ToInt32(a_text_asset.bytes, 7);
			int val3 = BitConverter.ToInt32(a_text_asset.bytes, 11);
			int startIndex = 15;
			for(int i = 0; i < val1; i++)
			{
				m_data_int.Add(new List<int>());
				for(int j = 0; j < val3; j++)
				{
					int readVal = BitConverter.ToInt32(a_text_asset.bytes, startIndex);
					m_data_int[i].Add(readVal);
					startIndex += 4;
				}
			}
			for(int i = 0; i < val2; i++)
			{
				for(int j = 0; j < val3; j++)
				{
					int readVal = BitConverter.ToInt32(a_text_asset.bytes, startIndex);
					string readString = Encoding.UTF8.GetString(a_text_asset.bytes, startIndex + 4, readVal);
					m_data_str.Add(readString);
				}
			}

			OnCreated();
			isCreate = true;
		}

		// // RVA: 0xAF50B0 Offset: 0xAF50B0 VA: 0xAF50B0
		// public void Release() { }

		// // RVA: 0xAF515C Offset: 0xAF515C VA: 0xAF515C Slot: 4
		public virtual void OnCreated() { }

	}
}
