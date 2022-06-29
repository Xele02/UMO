using System;
using System.Collections.Generic;

namespace XeSys
{
	public class MessageManager : Singleton<MessageManager>, IDisposable
	{
		private Dictionary<string, MessageBank> msgBankDic { get; set; } // 0x8

		// RVA: 0x23978E0 Offset: 0x23978E0 VA: 0x23978E0
		public MessageManager()
		{
			msgBankDic = new Dictionary<string, MessageBank>(4);
		}

		// RVA: 0x239797C Offset: 0x239797C VA: 0x239797C Slot: 4
		public void Dispose()
		{
			UnityEngine.Debug.LogError("TODO");
		}

		// // RVA: 0x2397B34 Offset: 0x2397B34 VA: 0x2397B34
		// public MessageBank RegisterBank(string bankName, byte[] bytes) { }

		// // RVA: 0x2397C38 Offset: 0x2397C38 VA: 0x2397C38
		// public void ReleaseBank(string bankName) { }

		// // RVA: 0x2397D3C Offset: 0x2397D3C VA: 0x2397D3C
		public MessageBank GetBank(string bankName)
		{
			UnityEngine.Debug.LogError("TODO");
			return null;
		}

		// // RVA: 0x2397E6C Offset: 0x2397E6C VA: 0x2397E6C
		// public string GetMessage(string bankName, string labelName) { }

		// // RVA: 0x2397E98 Offset: 0x2397E98 VA: 0x2397E98
		// public bool IsExistBank(string bankName) { }
	}
}
