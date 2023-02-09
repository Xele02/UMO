
using System.Collections.Generic;

[System.Obsolete("Use JKDKODAPGBJ_EnergyItem", true)]
public class JKDKODAPGBJ { }
public class JKDKODAPGBJ_EnergyItem : DIHHCBACKGG_DbSection
{
	public class GFGCCICHBHK
	{
		public int EHOIENNDEDH; // 0x8
		public int JEDNBJLMBKE; // 0xC
		public int HNJHPNPFAAN; // 0x10
		public int LCGJKAGIFGO; // 0x14
		public int ICKOHEDLEFP; // 0x18
		public int JDIJODDBCPK; // 0x1C
		public int EAJCFBCHIFB; // 0x20

		//public int PPFNGGCBJKC { get; set; } 0x135D158 DEMEPMAEJOO 0x135CBF8 HIGKAIDMOKN
		//public int PPEGAKEIEGM { get; set; } 0x135D1F0 KPOEEPIMMJP 0x135CB5C NCIEAFEDPBH
		//public int HJAFPEBIBOP { get; set; } 0x135D288 GNDLHNBPMHN 0x135CD30 HPFNBOKBEDD
		//public int DOOGFEGEKLG { get; set; } 0x135D320 AECMFIOFFJN 0x135CDCC NGOJJDOCIDG
		//public int JBGEEPFKIGG { get; set; } 0x135D3B8 OLOCMINKGON 0x135CC94 ABAFHIBFKCE
		//public int FPOMEEJFBIG { get; set; } 0x135D450 OEEBAHNAPEC 0x135CE68 BEHAPLPPLNE
		//public int EKLIPGELKCL { get; set; } 0x135D4E8 OEEHBGECGKL 0x135CF04 GHLMHLJJBIG

		// RVA: 0x135D08C Offset: 0x135D08C VA: 0x135D08C
		//public uint CAOGDCBPBAN() { }
	}

	public const int LFHKGBGHEEM = 5;
	public static int FBGGEFFJJHB = 0xb516d; // 0x0
	public List<GFGCCICHBHK> CDENCMNHNGA = new List<GFGCCICHBHK>(); // 0x20

	// RVA: 0x135C650 Offset: 0x135C650 VA: 0x135C650
	public JKDKODAPGBJ_EnergyItem()
	{
		JIKKNHIAEKG_BlockName = "";
		LNIMEIMBCMF = false;
		LMHMIIKCGPE = 24;
	}

	// RVA: 0x135C748 Offset: 0x135C748 VA: 0x135C748 Slot: 8
	protected override void KMBPACJNEOF()
	{
		CDENCMNHNGA.Clear();
	}

	// RVA: 0x135C7C0 Offset: 0x135C7C0 VA: 0x135C7C0 Slot: 9
	public override bool IIEMACPEEBJ(byte[] DBBGALAPFGC)
	{
		TodoLogger.Log(TodoLogger.Database, "JKDKODAPGBJ_EnergyItem.IIEMACPEEBJ");
		return true;
	}

	// RVA: 0x135CFA0 Offset: 0x135CFA0 VA: 0x135CFA0 Slot: 10
	public override bool IIEMACPEEBJ(EDOHBJAPLPF_JsonData OILEIIEIBHP, int KAPMOPMDHJE)
	{
		TodoLogger.Log(TodoLogger.Database, "JKDKODAPGBJ_EnergyItem.IIEMACPEEBJ");
		return true;
	}

	// RVA: 0x135CFA8 Offset: 0x135CFA8 VA: 0x135CFA8 Slot: 11
	public override uint CAOGDCBPBAN()
	{
		TodoLogger.Log(TodoLogger.DbIntegrityCheck, "JKDKODAPGBJ_EnergyItem.CAOGDCBPBAN");
		return 0;
	}
}
