using System;
using System.Collections.Generic;

namespace XeSys
{
	public class MessageBank : IDisposable
	{
		private Dictionary<string, string> msgDic { get; set; } // 0x8
		private List<string> labelList { get; set; } // 0xC
		// public int count { get; } // 0x2396E00

		// // RVA: 0x2396E80 Offset: 0x2396E80 VA: 0x2396E80
		// public void Setup(byte[] bytes) { }

		// // RVA: 0x2396F60 Offset: 0x2396F60 VA: 0x2396F60
		// private bool IsBinary(byte[] bytes) { }

		// // RVA: 0x2396FDC Offset: 0x2396FDC VA: 0x2396FDC
		// public void SetupFromBinary(byte[] bytes) { }

		// // RVA: 0x2397340 Offset: 0x2397340 VA: 0x2397340
		// public void SetupFromJson(byte[] bytes) { }

		// RVA: 0x2396EC4 Offset: 0x2396EC4 VA: 0x2396EC4 Slot: 4
		public void Dispose()
		{
			UnityEngine.Debug.LogError("TODO");
		}

		// // RVA: 0x23976DC Offset: 0x23976DC VA: 0x23976DC
		public string GetMessageByLabel(string label)
		{
			UnityEngine.Debug.LogError("TODO");
			return null;
		}

		// // RVA: 0x23977C4 Offset: 0x23977C4 VA: 0x23977C4
		// public string GetMessageByIndex(int index) { }

		// // RVA: 0x2397850 Offset: 0x2397850 VA: 0x2397850
		// public string GetLabel(int index) { }
	}
}
