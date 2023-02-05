using System;
using System.Collections.Generic;

namespace XeSys
{
	[WikiPage(title:"Texts/Bank", filename : "texts/bank", templateName:"Texts/Bank")]
	public class MessageManager : Singleton<MessageManager>, IDisposable
	{
		[WikiProperty()]
		private Dictionary<string, MessageBank> msgBankDic { get; set; } // 0x8

		// RVA: 0x23978E0 Offset: 0x23978E0 VA: 0x23978E0
		public MessageManager()
		{
			msgBankDic = new Dictionary<string, MessageBank>(4);
		}

		// RVA: 0x239797C Offset: 0x239797C VA: 0x239797C Slot: 4
		public void Dispose()
		{
			TodoLogger.Log(0, "TODO");
		}

		// // RVA: 0x2397B34 Offset: 0x2397B34 VA: 0x2397B34
		public MessageBank RegisterBank(string bankName, byte[] bytes)
		{
			if(!msgBankDic.ContainsKey(bankName))
			{
				MessageBank bank = new MessageBank();
				bank.Setup(bytes);
				msgBankDic.Add(bankName, bank);
				return bank;
			}
			return null;
		}

		// // RVA: 0x2397C38 Offset: 0x2397C38 VA: 0x2397C38
		public void ReleaseBank(string bankName)
		{
			if(!msgBankDic.ContainsKey(bankName))
				return;
			msgBankDic[bankName].Dispose();
			msgBankDic.Remove(bankName);
		}

		// // RVA: 0x2397D3C Offset: 0x2397D3C VA: 0x2397D3C
		public MessageBank GetBank(string bankName)
		{
			if(!msgBankDic.ContainsKey(bankName))
			{
				throw new Exception("MessageManager.GetBank : ["+bankName+"] is not exist");
			}
			return msgBankDic[bankName];
		}

		// // RVA: 0x2397E6C Offset: 0x2397E6C VA: 0x2397E6C
		public string GetMessage(string bankName, string labelName)
		{
			MessageBank bank = GetBank(bankName);
			if(bank != null)
			{
				return bank.GetMessageByLabel(labelName);
			}
			return null;
		}

		// // RVA: 0x2397E98 Offset: 0x2397E98 VA: 0x2397E98
		// public bool IsExistBank(string bankName) { }
	}
}
