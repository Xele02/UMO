
using System.Collections.Generic;

[System.Obsolete("Use DGDIEDDPNNG_UcItem", true)]
public class DGDIEDDPNNG { }
public class DGDIEDDPNNG_UcItem : DIHHCBACKGG_DbSection
{
	public class FCPCMPLGJNP
	{
		public int EHOIENNDEDH; // 0x8
		public int EAJCFBCHIFB; // 0xC
		public int ICKOHEDLEFP; // 0x10

		//public int PPFNGGCBJKC { get; set; } 0x1984F74 DEMEPMAEJOO 0x198472C HIGKAIDMOKN
		//public int EKLIPGELKCL { get; set; } 0x198500C OEEHBGECGKL 0x19847C8 GHLMHLJJBIG
		//public int JBGEEPFKIGG { get; set; } 0x19850A4 OLOCMINKGON 0x1984864 ABAFHIBFKCE

		//// RVA: 0x1984ED8 Offset: 0x1984ED8 VA: 0x1984ED8
		//public uint CAOGDCBPBAN() { }
	}

	public const int COJKCBBIOIL = 15;
	public static int FBGGEFFJJHB = 0xb516d; // 0x0
	public List<FCPCMPLGJNP> CDENCMNHNGA = new List<FCPCMPLGJNP>(); // 0x20

	// RVA: 0x1984318 Offset: 0x1984318 VA: 0x1984318
	public DGDIEDDPNNG_UcItem()
	{
		JIKKNHIAEKG_BlockName = "";
		LMHMIIKCGPE = 84;
		LNIMEIMBCMF = false;

	}

	// RVA: 0x1984490 Offset: 0x1984490 VA: 0x1984490 Slot: 8
	protected override void KMBPACJNEOF()
	{
		CDENCMNHNGA.Clear();
	}

	// RVA: 0x1984508 Offset: 0x1984508 VA: 0x1984508 Slot: 9
	public override bool IIEMACPEEBJ(byte[] DBBGALAPFGC)
	{
		TodoLogger.Log(TodoLogger.Database, "DGDIEDDPNNG_UcItem.IIEMACPEEBJ");
		return true;
	}

	// RVA: 0x1984900 Offset: 0x1984900 VA: 0x1984900 Slot: 10
	public override bool IIEMACPEEBJ(EDOHBJAPLPF_JsonData OILEIIEIBHP, int KAPMOPMDHJE)
	{
		TodoLogger.Log(TodoLogger.Database, "DGDIEDDPNNG_UcItem.IIEMACPEEBJ");
		return true;
	}

	// RVA: 0x1984DF4 Offset: 0x1984DF4 VA: 0x1984DF4 Slot: 11
	public override uint CAOGDCBPBAN()
	{
		TodoLogger.Log(TodoLogger.DbIntegrityCheck, "DGDIEDDPNNG_UcItem.CAOGDCBPBAN");
		return 0;
	}
}
