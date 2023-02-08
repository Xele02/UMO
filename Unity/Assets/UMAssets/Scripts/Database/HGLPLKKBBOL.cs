
using System.Collections.Generic;

[System.Obsolete("Use HGLPLKKBBOL_EventItem", true)]
public class HGLPLKKBBOL { }
public class HGLPLKKBBOL_EventItem : DIHHCBACKGG_DbSection
{
	public class JMCDEDCMCJE
	{
		public int FBGGEFFJJHB = 0x181b5; // 0x8
		public int EHOIENNDEDH; // 0xC
		public int EAJCFBCHIFB; // 0x10
		public int ICKOHEDLEFP; // 0x14
		public int MKENMKMJFKP; // 0x18

		//public int PPFNGGCBJKC { get; set; } 0x1751E94 DEMEPMAEJOO 0x17519AC HIGKAIDMOKN
		//public int EKLIPGELKCL { get; set; } 0x1751EA4 OEEHBGECGKL 0x17519BC GHLMHLJJBIG
		//public int JBGEEPFKIGG { get; set; } 0x1751EB4 OLOCMINKGON 0x17519CC ABAFHIBFKCE
		//public int INDDJNMPONH { get; set; } 0x1751EC4 GHAILOLPHPF 0x17519DC BACGOKIGMBC

		//// RVA: 0x1751E68 Offset: 0x1751E68 VA: 0x1751E68
		//public uint CAOGDCBPBAN() { }
	}

	public List<JMCDEDCMCJE> CDENCMNHNGA = new List<JMCDEDCMCJE>(); // 0x20

	// RVA: 0x1751590 Offset: 0x1751590 VA: 0x1751590
	public HGLPLKKBBOL_EventItem()
	{
		JIKKNHIAEKG_BlockName = "";
		LNIMEIMBCMF = false;
		LMHMIIKCGPE = 34;
	}

	// RVA: 0x1751684 Offset: 0x1751684 VA: 0x1751684 Slot: 8
	protected override void KMBPACJNEOF()
	{
		TodoLogger.Log(TodoLogger.Database, "HGLPLKKBBOL_EventItem.KMBPACJNEOF");
	}

	// RVA: 0x17516FC Offset: 0x17516FC VA: 0x17516FC Slot: 9
	public override bool IIEMACPEEBJ(byte[] DBBGALAPFGC)
	{
		TodoLogger.Log(TodoLogger.Database, "HGLPLKKBBOL_EventItem.IIEMACPEEBJ");
		return true;
	}

	// RVA: 0x17519EC Offset: 0x17519EC VA: 0x17519EC Slot: 10
	public override bool IIEMACPEEBJ(EDOHBJAPLPF_JsonData OILEIIEIBHP, int KAPMOPMDHJE)
	{
		TodoLogger.Log(TodoLogger.Database, "HGLPLKKBBOL_EventItem.IIEMACPEEBJ");
		return true;
	}

	// RVA: 0x1751D68 Offset: 0x1751D68 VA: 0x1751D68 Slot: 11
	public override uint CAOGDCBPBAN()
	{
		TodoLogger.Log(TodoLogger.DbIntegrityCheck, "HGLPLKKBBOL_EventItem.CAOGDCBPBAN");
		return 0;
	}
}
