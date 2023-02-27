
using System.Collections.Generic;

[System.Obsolete("Use EGLOKAEIHCB_LimitedItem", true)]
public class EGLOKAEIHCB { }
public class EGLOKAEIHCB_LimitedItem : DIHHCBACKGG_DbSection
{
	public class DEOCBHAGEEH
	{
		public int EHOIENNDEDH; // 0x8
		public int HNNLOMMFHEN; // 0xC
		public int ICKOHEDLEFP; // 0x10
		public int LCGJKAGIFGO; // 0x14
		public int HNJHPNPFAAN; // 0x18
		public int GNGNIKNNCNH; // 0x1C
		public int EAJCFBCHIFB; // 0x20
		public int HHPFFPINGAA; // 0x24
		public int LBDKPOLAELH; // 0x28
		public int CIEJPPHFCKM; // 0x2C

		public int PPFNGGCBJKC { get { return EHOIENNDEDH ^ FBGGEFFJJHB; } set { EHOIENNDEDH = value ^ FBGGEFFJJHB; } } //0x1C50B4C DEMEPMAEJOO 0x1C5035C HIGKAIDMOKN
		public int DMEDKJPOLCH { get { return HNNLOMMFHEN ^ FBGGEFFJJHB; } set { HNNLOMMFHEN = value ^ FBGGEFFJJHB; } } //0x1C50BE4 IPKCKAAEEOE 0x1C503F8 JOGLLINFLJN
		public int JBGEEPFKIGG { get { return ICKOHEDLEFP ^ FBGGEFFJJHB; } set { ICKOHEDLEFP = value ^ FBGGEFFJJHB; } } //0x1C50C7C OLOCMINKGON 0x1C50494 ABAFHIBFKCE
		public int DOOGFEGEKLG { get { return LCGJKAGIFGO ^ FBGGEFFJJHB; } set { LCGJKAGIFGO = value ^ FBGGEFFJJHB; } } //0x1C50D14 AECMFIOFFJN 0x1C50530 NGOJJDOCIDG
		public int PLALNIIBLOF { get { return HNJHPNPFAAN ^ FBGGEFFJJHB; } set { HNJHPNPFAAN = value ^ FBGGEFFJJHB; } } //0x1C50DAC JPCJNLHHIPE 0x1C505CC JJFJNEJLBDG
		public int IJEKNCDIIAE { get { return GNGNIKNNCNH ^ FBGGEFFJJHB; } set { GNGNIKNNCNH = value ^ FBGGEFFJJHB; } } //0x1C50E44 KJIMMIBDCIL 0x1C50668 DMEGNOKIKCD
		public int EKLIPGELKCL { get { return EAJCFBCHIFB ^ FBGGEFFJJHB; } set { EAJCFBCHIFB = value ^ FBGGEFFJJHB; } } //0x1C50EDC OEEHBGECGKL 0x1C50704 GHLMHLJJBIG
		public int EILKGEADKGH { get { return HHPFFPINGAA ^ FBGGEFFJJHB; } set { HHPFFPINGAA = value ^ FBGGEFFJJHB; } } //0x1C50F74 NPDDACIHBKD 0x1C507A0 BJJMCKHBPNH
		public int EMIJNAFJFJO { get { return LBDKPOLAELH ^ FBGGEFFJJHB; } set { LBDKPOLAELH = value ^ FBGGEFFJJHB; } } //0x1C5100C GBGPKONOFGD 0x1C5083C KCFHLAFJJPJ
		public int KHCBANFDKBO_Duration { get { return CIEJPPHFCKM ^ FBGGEFFJJHB; } set { CIEJPPHFCKM = value ^ FBGGEFFJJHB; } } //0x1C510A4 MKDAJEEHBJC 0x1C508D8 ELDLDDCADHA

		//// RVA: 0x1C50A60 Offset: 0x1C50A60 VA: 0x1C50A60
		//public uint CAOGDCBPBAN() { }
	}

	public const int ANMOJAEPNHB = 3;
	public static int FBGGEFFJJHB = 0x3b5a; // 0x0
	public List<DEOCBHAGEEH> CDENCMNHNGA = new List<DEOCBHAGEEH>(ANMOJAEPNHB); // 0x20

	// RVA: 0x1C4FE24 Offset: 0x1C4FE24 VA: 0x1C4FE24
	public EGLOKAEIHCB_LimitedItem()
	{
		JIKKNHIAEKG_BlockName = "";
		LNIMEIMBCMF = false;
		LMHMIIKCGPE = 58;
	}

	// RVA: 0x1C4FF1C Offset: 0x1C4FF1C VA: 0x1C4FF1C Slot: 8
	protected override void KMBPACJNEOF()
	{
		CDENCMNHNGA.Clear();
	}

	// RVA: 0x1C4FF94 Offset: 0x1C4FF94 VA: 0x1C4FF94 Slot: 9
	public override bool IIEMACPEEBJ(byte[] DBBGALAPFGC)
	{
		KNJFLGCKEIF parser = KNJFLGCKEIF.HEGEKFMJNCC(DBBGALAPFGC);
		GMHAHLAIOKB[] array = parser.FNKIIFGDCDM;
		for(int i = 0; i < array.Length; i++)
		{
			DEOCBHAGEEH data = new DEOCBHAGEEH();
			data.PPFNGGCBJKC = (int)array[i].PPFNGGCBJKC;
			data.DMEDKJPOLCH = (int)array[i].DMEDKJPOLCH;
			data.JBGEEPFKIGG = (int)array[i].JBGEEPFKIGG;
			data.DOOGFEGEKLG = (int)array[i].DOOGFEGEKLG;
			data.PLALNIIBLOF = (int)array[i].PLALNIIBLOF;
			data.IJEKNCDIIAE = array[i].IJEKNCDIIAE;
			data.EKLIPGELKCL = (int)array[i].FBFLDFMFFOH;
			data.EILKGEADKGH = (int)array[i].FPOMEEJFBIG;
			data.EMIJNAFJFJO = (int)array[i].EMIJNAFJFJO;
			data.KHCBANFDKBO_Duration = (int)array[i].KHCBANFDKBO;
			CDENCMNHNGA.Add(data);
		}
		return true;
	}

	// RVA: 0x1C50974 Offset: 0x1C50974 VA: 0x1C50974 Slot: 10
	public override bool IIEMACPEEBJ(EDOHBJAPLPF_JsonData OILEIIEIBHP, int KAPMOPMDHJE)
	{
		return false;
	}

	// RVA: 0x1C5097C Offset: 0x1C5097C VA: 0x1C5097C Slot: 11
	public override uint CAOGDCBPBAN()
	{
		TodoLogger.Log(TodoLogger.DbIntegrityCheck, "EGLOKAEIHCB_LimitedItem.CAOGDCBPBAN");
		return 0;
	}
}
