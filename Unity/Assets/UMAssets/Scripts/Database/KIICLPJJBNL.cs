
using System.Collections.Generic;

[System.Obsolete("Use KIICLPJJBNL_EpiItem", true)]
public class KIICLPJJBNL { }
public class KIICLPJJBNL_EpiItem : DIHHCBACKGG_DbSection
{
	public class NKGPGMOHAFM
	{
		public int EHOIENNDEDH; // 0x8
		public int EAJCFBCHIFB; // 0xC
		public int ICKOHEDLEFP; // 0x10

		//public int PPFNGGCBJKC { get; set; } 0x19FFF4C DEMEPMAEJOO 0x19FF8F8 HIGKAIDMOKN
		//public int EKLIPGELKCL { get; set; } 0x19FFFE4 OEEHBGECGKL 0x19FF994 GHLMHLJJBIG
		//public int JBGEEPFKIGG { get; set; } 0x1A0007C OLOCMINKGON 0x19FFA30 ABAFHIBFKCE

		// RVA: 0x19FFEB0 Offset: 0x19FFEB0 VA: 0x19FFEB0
		//public uint CAOGDCBPBAN() { }
	}

	public const int KOAENKKAMCJ = 3;
	public static int FBGGEFFJJHB = 0x181b5; // 0x0
	public List<NKGPGMOHAFM> CDENCMNHNGA = new List<NKGPGMOHAFM>(); // 0x20

	// RVA: 0x19FF550 Offset: 0x19FF550 VA: 0x19FF550
	public KIICLPJJBNL_EpiItem()
	{
		JIKKNHIAEKG_BlockName = "";
		LNIMEIMBCMF = false;
		LMHMIIKCGPE = 26;
	}

	// RVA: 0x19FF648 Offset: 0x19FF648 VA: 0x19FF648 Slot: 8
	protected override void KMBPACJNEOF()
	{
		CDENCMNHNGA.Clear();
	}

	// RVA: 0x19FF6C0 Offset: 0x19FF6C0 VA: 0x19FF6C0 Slot: 9
	public override bool IIEMACPEEBJ(byte[] DBBGALAPFGC)
	{
		TodoLogger.Log(TodoLogger.Database, "KIICLPJJBNL_EpiItem.IIEMACPEEBJ");
		return true;
	}

	// RVA: 0x19FFACC Offset: 0x19FFACC VA: 0x19FFACC Slot: 10
	public override bool IIEMACPEEBJ(EDOHBJAPLPF_JsonData OILEIIEIBHP, int KAPMOPMDHJE)
	{
		TodoLogger.Log(TodoLogger.Database, "KIICLPJJBNL_EpiItem.IIEMACPEEBJ");
		return true;
	}

	// RVA: 0x19FFDCC Offset: 0x19FFDCC VA: 0x19FFDCC Slot: 11
	public override uint CAOGDCBPBAN()
	{
		TodoLogger.Log(TodoLogger.DbIntegrityCheck, "KIICLPJJBNL_EpiItem.CAOGDCBPBAN");
		return 0;
	}
}