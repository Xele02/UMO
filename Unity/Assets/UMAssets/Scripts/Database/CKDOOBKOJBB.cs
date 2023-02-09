
using System.Collections.Generic;

[System.Obsolete("Use CKDOOBKOJBB_RareUpItem", true)]
public class CKDOOBKOJBB { }
public class CKDOOBKOJBB_RareUpItem : DIHHCBACKGG_DbSection
{ 
	public class FEIHMMKMGOF
	{
		public int EHOIENNDEDH; // 0x8
		public int ICKOHEDLEFP; // 0xC
		public int HNJHPNPFAAN; // 0x10
		public int EAJCFBCHIFB; // 0x14
		public int HBLLFAILJKH; // 0x18

		//public int PPFNGGCBJKC { get; set; } 0x107DB94 DEMEPMAEJOO 0x107D6E8 HIGKAIDMOKN
		//public int JBGEEPFKIGG { get; set; } 0x107DC2C OLOCMINKGON 0x107D784 ABAFHIBFKCE
		//public int PLALNIIBLOF { get; set; } 0x107DCC4 JPCJNLHHIPE 0x107D820 JJFJNEJLBDG
		//public int EKLIPGELKCL { get; set; } 0x107DD5C OEEHBGECGKL 0x107D8BC GHLMHLJJBIG
		//public int EIGNPDFHIJA { get; set; } 0x107DDF4 COAODPNEELA 0x107D958 OHOPAKFBOGL

		//// RVA: 0x107DAE0 Offset: 0x107DAE0 VA: 0x107DAE0
		//public uint CAOGDCBPBAN() { }
	}

	public const int JLBOFHIAFOM = 1;
	public static int FBGGEFFJJHB = 0x856293; // 0x0
	public List<FEIHMMKMGOF> CDENCMNHNGA = new List<FEIHMMKMGOF>(); // 0x20

	// RVA: 0x107D290 Offset: 0x107D290 VA: 0x107D290
	public CKDOOBKOJBB_RareUpItem()
	{
		JIKKNHIAEKG_BlockName = "";
		LNIMEIMBCMF = false;
		LMHMIIKCGPE = 68;
	}

	// RVA: 0x107D388 Offset: 0x107D388 VA: 0x107D388 Slot: 8
	protected override void KMBPACJNEOF()
	{
		TodoLogger.Log(TodoLogger.Database, "CKDOOBKOJBB_RareUpItem.KMBPACJNEOF");
	}

	// RVA: 0x107D400 Offset: 0x107D400 VA: 0x107D400 Slot: 9
	public override bool IIEMACPEEBJ(byte[] DBBGALAPFGC)
	{
		TodoLogger.Log(TodoLogger.Database, "CKDOOBKOJBB_RareUpItem.IIEMACPEEBJ");
		return true;
	}

	// RVA: 0x107D9F4 Offset: 0x107D9F4 VA: 0x107D9F4 Slot: 10
	public override bool IIEMACPEEBJ(EDOHBJAPLPF_JsonData OILEIIEIBHP, int KAPMOPMDHJE)
	{
		TodoLogger.Log(TodoLogger.Database, "CKDOOBKOJBB_RareUpItem.IIEMACPEEBJ");
		return true;
	}

	// RVA: 0x107D9FC Offset: 0x107D9FC VA: 0x107D9FC Slot: 11
	public override uint CAOGDCBPBAN()
	{
		TodoLogger.Log(TodoLogger.DbIntegrityCheck, "CKDOOBKOJBB_RareUpItem.CAOGDCBPBAN");
		return 0;
	}
}
