using XeSys;
using System.Collections.Generic;
using System;

public class PBJPACKDIIB : Singleton<PBJPACKDIIB>, IDisposable
{
    public class IFCOFHAFMON
    {
        public int EKANGPODCEP; // 0x8
        public int CMEJFJFOIIJ; // 0xC
        public int AIBFGKBACCB; // 0x10
        public long FKPEAGGKNLC; // 0x18
        public long KOMKKBDABJP; // 0x20
        public bool CGHNCPEKOCK; // 0x28
    }

    public class JBJMNJMJFOJ
    {
        public int CMEJFJFOIIJ; // 0x8
        public int HMFFHLPNMPH; // 0xC
    }
    
	private List<IFCOFHAFMON> EKFEHIHJHEN = new List<IFCOFHAFMON>(16); // 0x8

	// // RVA: 0xCBC134 Offset: 0xCBC134 VA: 0xCBC134
	public static List<IFCOFHAFMON> JAFKPMFPICA()
	{
		if(Instance != null)
		{
			return Instance.EKFEHIHJHEN;
		}
		return null;
	}

	// // RVA: 0xCBC1CC Offset: 0xCBC1CC VA: 0xCBC1CC
	// public void KPOJEAFIGOB() { }

	// // RVA: 0xCBC244 Offset: 0xCBC244 VA: 0xCBC244
	// public void CGJLFIGBHCG(PBJPACKDIIB.IFCOFHAFMON AOGFMNFOBNP) { }

	// // RVA: 0xCBC2C4 Offset: 0xCBC2C4 VA: 0xCBC2C4
	// public void KNPBADBCOLO(IMCBBOAFION BHFHGFKBOHH, DJBHIFLHJLK MOBEEPPKFLG) { }

	// [IteratorStateMachineAttribute] // RVA: 0x6BA674 Offset: 0x6BA674 VA: 0x6BA674
	// // RVA: 0xCBC31C Offset: 0xCBC31C VA: 0xCBC31C
	// private IEnumerator MCHIFJFALGL(IMCBBOAFION BHFHGFKBOHH, DJBHIFLHJLK MOBEEPPKFLG) { }

	// // RVA: 0xCBC3FC Offset: 0xCBC3FC VA: 0xCBC3FC
	// public static void NPIJAIOCACL(IMCBBOAFION BHFHGFKBOHH, DJBHIFLHJLK MOBEEPPKFLG) { }

	// // RVA: 0xCBC4C0 Offset: 0xCBC4C0 VA: 0xCBC4C0
	// public void HPFJOBPMNCP(int EKANGPODCEP, int AIBFGKBACCB, bool CGHNCPEKOCK, long LKCCMBEOLLA, Action<List<PBJPACKDIIB.JBJMNJMJFOJ>> BHFHGFKBOHH, DJBHIFLHJLK MOBEEPPKFLG) { }

	// // RVA: 0xCBC7EC Offset: 0xCBC7EC VA: 0xCBC7EC Slot: 4
	public void Dispose()
    {
        TodoLogger.Log(0, "TODO");
    }
}
