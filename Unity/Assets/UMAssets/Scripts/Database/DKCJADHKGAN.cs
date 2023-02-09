
using System.Collections.Generic;

public class DKCJADHKGAN { }
public class DKCJADHKGAN_EventWeekDay : DIHHCBACKGG_DbSection
{
	public class JFFPEKOEINE
	{
		public long KINJOEIAHFK; // 0x8
		public long PCCFAKEOBIC; // 0x10
		public int JCADAMLIOKK; // 0x18
		public sbyte PPEGAKEIEGM; // 0x1C
		public int AIDNHPGEHPM; // 0x20
		public int DJCHKGLCLPD; // 0x24
		public string CIOJJBOHEEJ; // 0x28
		public List<List<int>> BEPAMEEBPGI = new List<List<int>>(); // 0x2C

		//public int ELEPHBOKIGK { get; set; } 0x198E5A0 IIJFLONJAFL 0x198E160 LHNFGPIGCNE
		//public int AEHCKNNGAKF { get; set; } 0x198E5B4 KKNJPEMGEBF 0x198E174 NPDLLBHCIJP

		//// RVA: 0x198E5C8 Offset: 0x198E5C8 VA: 0x198E5C8
		//public List<int> OPCBHOLFCHO(int IAPNPKAGEGH) { }

		//// RVA: 0x198DA90 Offset: 0x198DA90 VA: 0x198DA90
		//public bool FLPDCNBLOKL(int IAPNPKAGEGH, int GHBPLHBNMBK) { }

		//// RVA: 0x198E414 Offset: 0x198E414 VA: 0x198E414
		//public uint CAOGDCBPBAN() { }
	}

	private List<JFFPEKOEINE> MPCJGPEBCCD = new List<JFFPEKOEINE>(); // 0x20

	//// RVA: 0x198D87C Offset: 0x198D87C VA: 0x198D87C
	//public DKCJADHKGAN.JFFPEKOEINE PPIBJECKCEF(long FJLBOKEKFKA) { }

	//// RVA: 0x198D990 Offset: 0x198D990 VA: 0x198D990
	//public bool FLPDCNBLOKL(long JHNMKKNEENE, int GHBPLHBNMBK) { }

	// RVA: 0x198DBA0 Offset: 0x198DBA0 VA: 0x198DBA0
	public DKCJADHKGAN_EventWeekDay()
	{
		JIKKNHIAEKG_BlockName = "";
		LNIMEIMBCMF = false;
		LMHMIIKCGPE = 45;
	}

	// RVA: 0x198DC88 Offset: 0x198DC88 VA: 0x198DC88 Slot: 8
	protected override void KMBPACJNEOF()
	{
		MPCJGPEBCCD.Clear();
	}

	// RVA: 0x198DD00 Offset: 0x198DD00 VA: 0x198DD00 Slot: 9
	public override bool IIEMACPEEBJ(byte[] DBBGALAPFGC)
	{
		TodoLogger.Log(TodoLogger.Database, "DKCJADHKGAN_EventWeekDay.IIEMACPEEBJ");
		return true;
	}

	// RVA: 0x198E324 Offset: 0x198E324 VA: 0x198E324 Slot: 10
	public override bool IIEMACPEEBJ(EDOHBJAPLPF_JsonData OILEIIEIBHP, int KAPMOPMDHJE)
	{
		TodoLogger.Log(TodoLogger.Database, "DKCJADHKGAN_EventWeekDay.IIEMACPEEBJ");
		return true;
	}

	//// RVA: 0x198E188 Offset: 0x198E188 VA: 0x198E188
	//private static List<int> JCAGLPANMFC(string IBDJFHFIIHN) { }

	// RVA: 0x198E32C Offset: 0x198E32C VA: 0x198E32C Slot: 11
	public override uint CAOGDCBPBAN()
	{
		TodoLogger.Log(TodoLogger.DbIntegrityCheck, "DKCJADHKGAN_EventWeekDay.CAOGDCBPBAN");
		return 0;
	}
}
