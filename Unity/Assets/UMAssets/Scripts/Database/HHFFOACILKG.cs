
using System.Collections.Generic;

[System.Obsolete("Use HHFFOACILKG_Medal", true)]
public class HHFFOACILKG { }
public class HHFFOACILKG_Medal : DIHHCBACKGG_DbSection
{
	public class HCFJGDFMHOJ
	{
		public int EHOIENNDEDH; // 0x8
		public int NOFECLGOLAI; // 0xC
		public int MKHGNAKFPBE; // 0x10
		public int ICKOHEDLEFP; // 0x14
		public int HNJHPNPFAAN; // 0x18
		public int GNGNIKNNCNH; // 0x1C
		public long DBKJDLJJLLI; // 0x20
		public long OJHEAICHHCI; // 0x28
		public int EAJCFBCHIFB; // 0x30

		public int PPFNGGCBJKC { get { return EHOIENNDEDH ^ FBGGEFFJJHB; } set { EHOIENNDEDH = value ^ FBGGEFFJJHB; } } //0x1757E94 DEMEPMAEJOO 0x1758FD4 HIGKAIDMOKN
		public int GBJFNGCDKPM { get { return NOFECLGOLAI ^ FBGGEFFJJHB; } set { NOFECLGOLAI = value ^ FBGGEFFJJHB; } } //0x1757CC4 CEJJMKODOGK 0x1759070 HOHCEBMMACI
		public int IBAKPKKEDJM { get { return MKHGNAKFPBE ^ FBGGEFFJJHB; } set { MKHGNAKFPBE = value ^ FBGGEFFJJHB; } } //0x1757F2C IJHAHFOOJKH 0x175910C LNKIOJGIKMB
		public int JBGEEPFKIGG { get { return ICKOHEDLEFP ^ FBGGEFFJJHB; } set { ICKOHEDLEFP = value ^ FBGGEFFJJHB; } } //0x1759730 OLOCMINKGON 0x17591A8 ABAFHIBFKCE
		public int PLALNIIBLOF { get { return HNJHPNPFAAN ^ FBGGEFFJJHB; } set { HNJHPNPFAAN = value ^ FBGGEFFJJHB; } } //0x1757C2C JPCJNLHHIPE 0x1759244 JJFJNEJLBDG
		public int IJEKNCDIIAE { get { return GNGNIKNNCNH ^ FBGGEFFJJHB; } set { GNGNIKNNCNH = value ^ FBGGEFFJJHB; } } //0x17597C8 KJIMMIBDCIL 0x17592E0 DMEGNOKIKCD
		public long AHILKBKLFJM { get { return DBKJDLJJLLI ^ FBGGEFFJJHB; } set { DBKJDLJJLLI = value ^ FBGGEFFJJHB; } } //0x1757D5C BOKMCIGOLOP 0x175937C HIFMNLCEDCB
		public long ODPMNBBBBIM { get { return OJHEAICHHCI ^ FBGGEFFJJHB; } set { OJHEAICHHCI = value ^ FBGGEFFJJHB; } } //0x1757DF8 GEEHPMGPKOJ 0x1759420 FAKGBMJFGMM
		public int EKLIPGELKCL { get { return EAJCFBCHIFB ^ FBGGEFFJJHB; } set { EAJCFBCHIFB = value ^ FBGGEFFJJHB; } } //0x1759860 OEEHBGECGKL 0x17594C4 GHLMHLJJBIG

		//// RVA: 0x175964C Offset: 0x175964C VA: 0x175964C
		//public uint CAOGDCBPBAN() { }
	}

	public const int PGCIONNCLBI = 16;
	public static int FBGGEFFJJHB = 0xb516d; // 0x0
	public List<HCFJGDFMHOJ> CDENCMNHNGA = new List<HCFJGDFMHOJ>(16); // 0x20

	//// RVA: 0x1757718 Offset: 0x1757718 VA: 0x1757718
	public int DNEKJCKEOHL(long JHNMKKNEENE)
	{
		TodoLogger.Log(0, "DNEKJCKEOHL");
		return 0;
	}

	//// RVA: 0x1757FC4 Offset: 0x1757FC4 VA: 0x1757FC4
	//public long OEMKKJBNIFA(int PPFNGGCBJKC) { }

	//// RVA: 0x17582A4 Offset: 0x17582A4 VA: 0x17582A4
	//public string LPHKLEJPKAN(string FEMMDNIELFC, int PPFNGGCBJKC) { }

	// RVA: 0x1758AD0 Offset: 0x1758AD0 VA: 0x1758AD0
	public HHFFOACILKG_Medal()
	{
		JIKKNHIAEKG_BlockName = "";
		LNIMEIMBCMF = false;
		LMHMIIKCGPE = 60;
	}

	// RVA: 0x1758BC8 Offset: 0x1758BC8 VA: 0x1758BC8 Slot: 8
	protected override void KMBPACJNEOF()
	{
		CDENCMNHNGA.Clear();
	}

	// RVA: 0x1758C40 Offset: 0x1758C40 VA: 0x1758C40 Slot: 9
	public override bool IIEMACPEEBJ(byte[] DBBGALAPFGC)
	{
		CFJBIGCPCAK parser = CFJBIGCPCAK.HEGEKFMJNCC(DBBGALAPFGC);
		LKGEMHKEBDJ[] array = parser.IKIEMCADPMB;
		for(int i = 0; i < array.Length; i++)
		{
			HCFJGDFMHOJ data = new HCFJGDFMHOJ();
			data.PPFNGGCBJKC = (int)array[i].PPFNGGCBJKC;
			data.GBJFNGCDKPM = (int)array[i].GBJFNGCDKPM;
			data.IBAKPKKEDJM = (int)array[i].IBAKPKKEDJM;
			data.JBGEEPFKIGG = (int)array[i].JBGEEPFKIGG;
			data.PLALNIIBLOF = (int)array[i].PLALNIIBLOF;
			data.IJEKNCDIIAE = array[i].IJEKNCDIIAE;
			data.AHILKBKLFJM = array[i].AHILKBKLFJM;
			data.ODPMNBBBBIM = array[i].ODPMNBBBBIM;
			data.EKLIPGELKCL = (int)array[i].FBFLDFMFFOH;
			CDENCMNHNGA.Add(data);
		}
		return true;
	}

	// RVA: 0x1759560 Offset: 0x1759560 VA: 0x1759560 Slot: 10
	public override bool IIEMACPEEBJ(EDOHBJAPLPF_JsonData OILEIIEIBHP, int KAPMOPMDHJE)
	{
		return false;
	}

	// RVA: 0x1759568 Offset: 0x1759568 VA: 0x1759568 Slot: 11
	public override uint CAOGDCBPBAN()
	{
		TodoLogger.Log(TodoLogger.DbIntegrityCheck, "HHFFOACILKG_Medal.CAOGDCBPBAN");
		return 0;
	}
}
