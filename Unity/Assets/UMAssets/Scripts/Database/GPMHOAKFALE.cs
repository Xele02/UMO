
using System.Collections.Generic;


[System.Obsolete("Use GPMHOAKFALE_Adventure", true)]
public class GPMHOAKFALE { }
public class GPMHOAKFALE_Adventure : DIHHCBACKGG_DbSection
{
	public class NGDBKCKMDHE
	{
		public int FBGGEFFJJHB; // 0x8
		public int AOGEMIIMFLD; // 0xC
		public int OIFAFKDMEEJ; // 0x10
		public int INAKHLKLFOK; // 0x14

		//public int BPNKGDGBBFG { get; set; } 0x1E5F810 OPOKKOIDCLG 0x1E5F6B8 CKNHCODBIAG
		//public int KKPPFAHFOJI { get; set; } 0x1E5F820 JHDAICCKIOG 0x1E5F6D8 MCCPIGOELKB
		//public int PPEGAKEIEGM { get; set; } 0x1E5F830 KPOEEPIMMJP 0x1E5F6C8 NCIEAFEDPBH

		// RVA: 0x1E5F7EC Offset: 0x1E5F7EC VA: 0x1E5F7EC
		//public uint CAOGDCBPBAN() { }
	}

	public List<NGDBKCKMDHE> CDENCMNHNGA { get; private set; } // 0x20 GIODFKFCBMO JDMECLDHNOF ILHOADLEJPB

	//// RVA: 0x1E5F1EC Offset: 0x1E5F1EC VA: 0x1E5F1EC
	//public GPMHOAKFALE.NGDBKCKMDHE GCINIJEMHFK(int PPFNGGCBJKC) { }

	// RVA: 0x1E5F2B4 Offset: 0x1E5F2B4 VA: 0x1E5F2B4
	public GPMHOAKFALE_Adventure()
	{
		JIKKNHIAEKG_BlockName = "";
		LNIMEIMBCMF = false;
		LMHMIIKCGPE = 0;
		CDENCMNHNGA = new List<NGDBKCKMDHE>();
	}

	// RVA: 0x1E5F3AC Offset: 0x1E5F3AC VA: 0x1E5F3AC Slot: 8
	protected override void KMBPACJNEOF()
	{
		CDENCMNHNGA.Clear();
	}

	// RVA: 0x1E5F424 Offset: 0x1E5F424 VA: 0x1E5F424 Slot: 9
	public override bool IIEMACPEEBJ(byte[] DBBGALAPFGC)
	{
		TodoLogger.Log(TodoLogger.Database, "GPMHOAKFALE_Adventure.IIEMACPEEBJ");
		return true;
	}

	// RVA: 0x1E5F6A8 Offset: 0x1E5F6A8 VA: 0x1E5F6A8 Slot: 10
	public override bool IIEMACPEEBJ(EDOHBJAPLPF_JsonData OILEIIEIBHP, int KAPMOPMDHJE)
	{
		TodoLogger.Log(TodoLogger.Database, "GPMHOAKFALE_Adventure.IIEMACPEEBJ");
		return true;
	}

	//// RVA: 0x1E5F450 Offset: 0x1E5F450 VA: 0x1E5F450
	//private bool MGEJEAENEEG(NJBPFPMDKHN JMHECKKKMLK) { }

	//// RVA: 0x1E5F6E8 Offset: 0x1E5F6E8 VA: 0x1E5F6E8
	//private bool JANANCJMFPB(EDOHBJAPLPF OILEIIEIBHP, int KAPMOPMDHJE) { }

	// RVA: 0x1E5F6F0 Offset: 0x1E5F6F0 VA: 0x1E5F6F0 Slot: 11
	public override uint CAOGDCBPBAN()
	{
		TodoLogger.Log(TodoLogger.DbIntegrityCheck, "GPMHOAKFALE_Adventure.CAOGDCBPBAN");
		return 0;
	}
}

