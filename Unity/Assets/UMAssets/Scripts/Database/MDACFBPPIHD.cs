
using System.Collections.Generic;

[System.Obsolete("Use MDACFBPPIHD_PresentItem", true)]
public class MDACFBPPIHD { }
public class MDACFBPPIHD_PresentItem : DIHHCBACKGG_DbSection
{
	public class GPFDNMMCPHB
	{
		public int EHOIENNDEDH; // 0x8
		public int ICKOHEDLEFP; // 0xC
		public int HNJHPNPFAAN; // 0x10
		public int GNGNIKNNCNH; // 0x14
		public int EAJCFBCHIFB; // 0x18

		//public int PPFNGGCBJKC { get; set; } 0x130E3A0 DEMEPMAEJOO 0x130DEF4 HIGKAIDMOKN
		//public int JBGEEPFKIGG { get; set; } 0x130E438 OLOCMINKGON 0x130DF90 ABAFHIBFKCE
		//public int PLALNIIBLOF { get; set; } 0x130E4D0 JPCJNLHHIPE 0x130E02C JJFJNEJLBDG
		//public int IJEKNCDIIAE { get; set; } 0x130E568 KJIMMIBDCIL 0x130E0C8 DMEGNOKIKCD
		//public int EKLIPGELKCL { get; set; } 0x130E600 OEEHBGECGKL 0x130E164 GHLMHLJJBIG

		//// RVA: 0x130E2EC Offset: 0x130E2EC VA: 0x130E2EC
		//public uint CAOGDCBPBAN() { }
	}

	public const int CADHDBIFKKL = 20;
	public static int FBGGEFFJJHB = 0xd724f; // 0x0
	public List<GPFDNMMCPHB> CDENCMNHNGA; // 0x20

	// RVA: 0x130DAE8 Offset: 0x130DAE8 VA: 0x130DAE8
	public MDACFBPPIHD_PresentItem() { }

	// RVA: 0x130DBE0 Offset: 0x130DBE0 VA: 0x130DBE0 Slot: 8
	protected override void KMBPACJNEOF()
	{
		CDENCMNHNGA.Clear();
	}

	// RVA: 0x130DC58 Offset: 0x130DC58 VA: 0x130DC58 Slot: 9
	public override bool IIEMACPEEBJ(byte[] DBBGALAPFGC)
	{
		TodoLogger.Log(TodoLogger.Database, "MDACFBPPIHD_PresentItem.IIEMACPEEBJ");
		return true;
	}

	// RVA: 0x130E200 Offset: 0x130E200 VA: 0x130E200 Slot: 10
	public override bool IIEMACPEEBJ(EDOHBJAPLPF_JsonData OILEIIEIBHP, int KAPMOPMDHJE)
	{
		TodoLogger.Log(TodoLogger.Database, "MDACFBPPIHD_PresentItem.IIEMACPEEBJ");
		return true;
	}

	// RVA: 0x130E208 Offset: 0x130E208 VA: 0x130E208 Slot: 11
	public override uint CAOGDCBPBAN()
	{
		TodoLogger.Log(TodoLogger.DbIntegrityCheck, "MDACFBPPIHD_PresentItem.CAOGDCBPBAN");
		return 0;
	}
}
