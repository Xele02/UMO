using System;
using System.Collections.Generic;
using XeSys;
using System.Text;

namespace XeSys
{
	public class MessageBank : IDisposable
	{
		private Dictionary<string, string> msgDic { get; set; } // 0x8
		private List<string> labelList { get; set; } // 0xC
		// public int count { get; } // 0x2396E00

		// // RVA: 0x2396E80 Offset: 0x2396E80 VA: 0x2396E80
		public void Setup(byte[] bytes)
		{
			Dispose();
			if(IsBinary(bytes))
			{
				SetupFromBinary(bytes);
			}
			else
			{
				SetupFromJson(bytes);
			}
		}

		// // RVA: 0x2396F60 Offset: 0x2396F60 VA: 0x2396F60
		private bool IsBinary(byte[] bytes)
		{
			if(bytes.Length < 17)
				return false;
			for(int i = 4; i <= 14; i++)
			{
				if(bytes[i] != 0xff)
					return false;
			}
			return true;
		}

		// // RVA: 0x2396FDC Offset: 0x2396FDC VA: 0x2396FDC
		public void SetupFromBinary(byte[] bytes)
		{
			msgDic = new Dictionary<string, string>(256);
			labelList = new List<string>(256);
			int idx = 0;
			int num = Utility.GetValueInt32(bytes, ref idx);
			idx = 16;
			for(int i = 0; i < num; i++)
			{
				int offset1 = Utility.GetValueInt32(bytes, ref idx);
				int size1 = Utility.GetValueInt32(bytes, ref idx);
				int offset2 = Utility.GetValueInt32(bytes, ref idx);
				int size2 = Utility.GetValueInt32(bytes, ref idx);
				
				string value = Encoding.Unicode.GetString(bytes, offset1, size1);
				string key = Encoding.Unicode.GetString(bytes, offset2, size2);

				if(msgDic.ContainsKey(key))
				{
					throw new Exception("MessageBank.Setup : label["+key+"] is already exist");
				}
				msgDic.Add(key, value);
				labelList.Add(key);
			}
		}

		// // RVA: 0x2397340 Offset: 0x2397340 VA: 0x2397340
		public void SetupFromJson(byte[] bytes)
		{
			UnityEngine.Debug.LogError("TODO");
		}

		// RVA: 0x2396EC4 Offset: 0x2396EC4 VA: 0x2396EC4 Slot: 4
		public void Dispose()
		{
			if(msgDic != null)
				msgDic.Clear();
			if(labelList != null)
				labelList.Clear();
		}

		// // RVA: 0x23976DC Offset: 0x23976DC VA: 0x23976DC
		public string GetMessageByLabel(string label)
		{
			if(!msgDic.ContainsKey(label))
				return "!not exist ["+label+"]!";
			return msgDic[label];
		}

		// // RVA: 0x23977C4 Offset: 0x23977C4 VA: 0x23977C4
		// public string GetMessageByIndex(int index) { }

		// // RVA: 0x2397850 Offset: 0x2397850 VA: 0x2397850
		// public string GetLabel(int index) { }
	}
}
