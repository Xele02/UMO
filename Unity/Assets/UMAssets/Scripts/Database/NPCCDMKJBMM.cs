
using System.Collections.Generic;

[System.Obsolete("Use NPCCDMKJBMM_HomeVoice", true)]
public class NPCCDMKJBMM { }
public class NPCCDMKJBMM_HomeVoice : DIHHCBACKGG_DbSection
{
	public class KLKLEALABPN
	{
		public int PPFNGGCBJKC; // 0x8
		public sbyte PPEGAKEIEGM; // 0xC
		public sbyte INDDJNMPONH; // 0xD
		public int NKCNHKHGJHN; // 0x10
		public int CHOFDPDFPDC; // 0x14
		public long PDBPFJJCADD; // 0x18
		public long FDBNFFNFOND; // 0x20

		// RVA: 0x1CB5F60 Offset: 0x1CB5F60 VA: 0x1CB5F60
		//public uint CAOGDCBPBAN() { }
	}

	public List<KLKLEALABPN> CDENCMNHNGA = new List<KLKLEALABPN>(); // 0x20

	// RVA: 0x1CB59F4 Offset: 0x1CB59F4 VA: 0x1CB59F4
	public NPCCDMKJBMM_HomeVoice()
	{
		JIKKNHIAEKG_BlockName = "";
		LNIMEIMBCMF = false;
		LMHMIIKCGPE = 55;
	}

	// RVA: 0x1CB5AE8 Offset: 0x1CB5AE8 VA: 0x1CB5AE8 Slot: 8
	protected override void KMBPACJNEOF()
	{
		TodoLogger.Log(TodoLogger.Database, "NPCCDMKJBMM_HomeVoice.KMBPACJNEOF");
	}

	// RVA: 0x1CB5B60 Offset: 0x1CB5B60 VA: 0x1CB5B60 Slot: 9
	public override bool IIEMACPEEBJ(byte[] DBBGALAPFGC)
	{
		TodoLogger.Log(TodoLogger.Database, "NPCCDMKJBMM_HomeVoice.IIEMACPEEBJ");
		return true;
	}

	// RVA: 0x1CB5E3C Offset: 0x1CB5E3C VA: 0x1CB5E3C Slot: 10
	public override bool IIEMACPEEBJ(EDOHBJAPLPF_JsonData OILEIIEIBHP, int KAPMOPMDHJE)
	{
		TodoLogger.Log(TodoLogger.Database, "NPCCDMKJBMM_HomeVoice.IIEMACPEEBJ");
		return true;
	}

	// RVA: 0x1CB5E44 Offset: 0x1CB5E44 VA: 0x1CB5E44 Slot: 11
	public override uint CAOGDCBPBAN()
	{
		TodoLogger.Log(TodoLogger.DbIntegrityCheck, "NPCCDMKJBMM_HomeVoice.CAOGDCBPBAN");
		return 0;
	}
}
