
using System.Collections.Generic;

[System.Obsolete("Use PPNFHHPJOKK_SpItem", true)]
public class PPNFHHPJOKK { }
public class PPNFHHPJOKK_SpItem : DIHHCBACKGG_DbSection
{
	public class JBBIPIAABOJ
	{
		public int EHOIENNDEDH; // 0x8
		public int HNNLOMMFHEN; // 0xC
		public int ICKOHEDLEFP; // 0x10
		public int LCGJKAGIFGO; // 0x14
		public int HNJHPNPFAAN; // 0x18
		public int GNGNIKNNCNH; // 0x1C
		public int EAJCFBCHIFB; // 0x20
		public int HHPFFPINGAA; // 0x24

		//public int PPFNGGCBJKC { get; set; } 0xDF8948 DEMEPMAEJOO 0xDF8210 HIGKAIDMOKN
		//public int DMEDKJPOLCH { get; set; } 0xDF89E0 IPKCKAAEEOE 0xDF82AC JOGLLINFLJN
		//public int JBGEEPFKIGG { get; set; } 0xDF8A78 OLOCMINKGON 0xDF8348 ABAFHIBFKCE
		//public int DOOGFEGEKLG { get; set; } 0xDF8B10 AECMFIOFFJN 0xDF83E4 NGOJJDOCIDG
		//public int PLALNIIBLOF { get; set; } 0xDF86F0 JPCJNLHHIPE 0xDF8480 JJFJNEJLBDG
		//public int IJEKNCDIIAE { get; set; } 0xDF8BA8 KJIMMIBDCIL 0xDF851C DMEGNOKIKCD
		//public int EKLIPGELKCL { get; set; } 0xDF8C40 OEEHBGECGKL 0xDF85B8 GHLMHLJJBIG
		//public int EILKGEADKGH { get; set; } 0xDF8CD8 NPDDACIHBKD 0xDF8654 BJJMCKHBPNH

		//// RVA: 0xDF8874 Offset: 0xDF8874 VA: 0xDF8874
		//public uint CAOGDCBPBAN() { }
	}

	public const int EGAGLFMOBEP = 16;
	public static int FBGGEFFJJHB = 0x1a63; // 0x0
	public List<JBBIPIAABOJ> CDENCMNHNGA = new List<JBBIPIAABOJ>(); // 0x20

	// RVA: 0xDF7CD8 Offset: 0xDF7CD8 VA: 0xDF7CD8
	public PPNFHHPJOKK_SpItem()
	{
		JIKKNHIAEKG_BlockName = "";
		LNIMEIMBCMF = false;
		LMHMIIKCGPE = 77;
	}

	// RVA: 0xDF7DD0 Offset: 0xDF7DD0 VA: 0xDF7DD0 Slot: 8
	protected override void KMBPACJNEOF()
	{
		TodoLogger.Log(TodoLogger.Database, "PPNFHHPJOKK_SpItem.KMBPACJNEOF");
	}

	// RVA: 0xDF7E48 Offset: 0xDF7E48 VA: 0xDF7E48 Slot: 9
	public override bool IIEMACPEEBJ(byte[] DBBGALAPFGC)
	{
		TodoLogger.Log(TodoLogger.Database, "PPNFHHPJOKK_SpItem.IIEMACPEEBJ");
		return true;
	}

	// RVA: 0xDF8788 Offset: 0xDF8788 VA: 0xDF8788 Slot: 10
	public override bool IIEMACPEEBJ(EDOHBJAPLPF_JsonData OILEIIEIBHP, int KAPMOPMDHJE)
	{
		TodoLogger.Log(TodoLogger.Database, "PPNFHHPJOKK_SpItem.IIEMACPEEBJ");
		return true;
	}

	// RVA: 0xDF8790 Offset: 0xDF8790 VA: 0xDF8790 Slot: 11
	public override uint CAOGDCBPBAN()
	{
		TodoLogger.Log(TodoLogger.DbIntegrityCheck, "PPNFHHPJOKK_SpItem.CAOGDCBPBAN");
		return 0;
	}
}
