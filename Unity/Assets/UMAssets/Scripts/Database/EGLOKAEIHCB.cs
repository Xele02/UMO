
using System.Collections.Generic;

[System.Obsolete("Use EGLOKAEIHCB_LimitedItem", true)]
public class EGLOKAEIHCB { }
public class EGLOKAEIHCB_LimitedItem : DIHHCBACKGG_DbSection
{
	public class DEOCBHAGEEH
	{
		public int EHOIENNDEDH_IdCrypted; // 0x8
		public int HNNLOMMFHEN_catCrypted; // 0xC
		public int ICKOHEDLEFP_ValueCrypted; // 0x10
		public int LCGJKAGIFGO_MaxCrypted; // 0x14
		public int HNJHPNPFAAN_EnabledCrypted; // 0x18
		public int GNGNIKNNCNH_MVerCrypted; // 0x1C
		public int EAJCFBCHIFB_RarityCrypted; // 0x20
		public int HHPFFPINGAA_OrderCrypted; // 0x24
		public int LBDKPOLAELH; // 0x28
		public int CIEJPPHFCKM; // 0x2C

		public int PPFNGGCBJKC_id { get { return EHOIENNDEDH_IdCrypted ^ FBGGEFFJJHB_xor; } set { EHOIENNDEDH_IdCrypted = value ^ FBGGEFFJJHB_xor; } } //0x1C50B4C DEMEPMAEJOO 0x1C5035C HIGKAIDMOKN
		public int DMEDKJPOLCH_cat { get { return HNNLOMMFHEN_catCrypted ^ FBGGEFFJJHB_xor; } set { HNNLOMMFHEN_catCrypted = value ^ FBGGEFFJJHB_xor; } } //0x1C50BE4 IPKCKAAEEOE 0x1C503F8 JOGLLINFLJN
		public int JBGEEPFKIGG_val { get { return ICKOHEDLEFP_ValueCrypted ^ FBGGEFFJJHB_xor; } set { ICKOHEDLEFP_ValueCrypted = value ^ FBGGEFFJJHB_xor; } } //0x1C50C7C OLOCMINKGON 0x1C50494 ABAFHIBFKCE
		public int DOOGFEGEKLG_max { get { return LCGJKAGIFGO_MaxCrypted ^ FBGGEFFJJHB_xor; } set { LCGJKAGIFGO_MaxCrypted = value ^ FBGGEFFJJHB_xor; } } //0x1C50D14 AECMFIOFFJN 0x1C50530 NGOJJDOCIDG
		public int PLALNIIBLOF_en { get { return HNJHPNPFAAN_EnabledCrypted ^ FBGGEFFJJHB_xor; } set { HNJHPNPFAAN_EnabledCrypted = value ^ FBGGEFFJJHB_xor; } } //0x1C50DAC JPCJNLHHIPE 0x1C505CC JJFJNEJLBDG
		public int IJEKNCDIIAE_mver { get { return GNGNIKNNCNH_MVerCrypted ^ FBGGEFFJJHB_xor; } set { GNGNIKNNCNH_MVerCrypted = value ^ FBGGEFFJJHB_xor; } } //0x1C50E44 KJIMMIBDCIL 0x1C50668 DMEGNOKIKCD
		public int EKLIPGELKCL_Rarity { get { return EAJCFBCHIFB_RarityCrypted ^ FBGGEFFJJHB_xor; } set { EAJCFBCHIFB_RarityCrypted = value ^ FBGGEFFJJHB_xor; } } //0x1C50EDC OEEHBGECGKL 0x1C50704 GHLMHLJJBIG
		public int EILKGEADKGH_Order { get { return HHPFFPINGAA_OrderCrypted ^ FBGGEFFJJHB_xor; } set { HHPFFPINGAA_OrderCrypted = value ^ FBGGEFFJJHB_xor; } } //0x1C50F74 NPDDACIHBKD 0x1C507A0 BJJMCKHBPNH
		public int EMIJNAFJFJO_expir { get { return LBDKPOLAELH ^ FBGGEFFJJHB_xor; } set { LBDKPOLAELH = value ^ FBGGEFFJJHB_xor; } } //0x1C5100C GBGPKONOFGD 0x1C5083C KCFHLAFJJPJ
		public int KHCBANFDKBO_Duration { get { return CIEJPPHFCKM ^ FBGGEFFJJHB_xor; } set { CIEJPPHFCKM = value ^ FBGGEFFJJHB_xor; } } //0x1C510A4 MKDAJEEHBJC 0x1C508D8 ELDLDDCADHA

		//// RVA: 0x1C50A60 Offset: 0x1C50A60 VA: 0x1C50A60
		//public uint CAOGDCBPBAN() { }
	}

	public const int ANMOJAEPNHB = 3;
	public static int FBGGEFFJJHB_xor = 0x3b5a; // 0x0
	public List<DEOCBHAGEEH> CDENCMNHNGA_table = new List<DEOCBHAGEEH>(ANMOJAEPNHB); // 0x20

	// RVA: 0x1C4FE24 Offset: 0x1C4FE24 VA: 0x1C4FE24
	public EGLOKAEIHCB_LimitedItem()
	{
		JIKKNHIAEKG_BlockName = "";
		LNIMEIMBCMF = false;
		LMHMIIKCGPE = 58;
	}

	// RVA: 0x1C4FF1C Offset: 0x1C4FF1C VA: 0x1C4FF1C Slot: 8
	protected override void KMBPACJNEOF_Reset()
	{
		CDENCMNHNGA_table.Clear();
	}

	// RVA: 0x1C4FF94 Offset: 0x1C4FF94 VA: 0x1C4FF94 Slot: 9
	public override bool IIEMACPEEBJ_Deserialize(byte[] _DBBGALAPFGC_bytes)
	{
		KNJFLGCKEIF parser = KNJFLGCKEIF.HEGEKFMJNCC(_DBBGALAPFGC_bytes);
		GMHAHLAIOKB[] array = parser.FNKIIFGDCDM;
		for(int i = 0; i < array.Length; i++)
		{
			DEOCBHAGEEH data = new DEOCBHAGEEH();
			data.PPFNGGCBJKC_id = (int)array[i].PPFNGGCBJKC_id;
			data.DMEDKJPOLCH_cat = (int)array[i].DMEDKJPOLCH_cat;
			data.JBGEEPFKIGG_val = (int)array[i].JBGEEPFKIGG_val;
			data.DOOGFEGEKLG_max = (int)array[i].DOOGFEGEKLG_max;
			data.PLALNIIBLOF_en = (int)array[i].PLALNIIBLOF_en;
			data.IJEKNCDIIAE_mver = array[i].IJEKNCDIIAE_mver;
			data.EKLIPGELKCL_Rarity = (int)array[i].FBFLDFMFFOH_rar;
			data.EILKGEADKGH_Order = (int)array[i].FPOMEEJFBIG_odr;
			data.EMIJNAFJFJO_expir = (int)array[i].EMIJNAFJFJO_expir;
			data.KHCBANFDKBO_Duration = (int)array[i].KHCBANFDKBO;
			CDENCMNHNGA_table.Add(data);
		}
		return true;
	}

	// RVA: 0x1C50974 Offset: 0x1C50974 VA: 0x1C50974 Slot: 10
	public override bool IIEMACPEEBJ_Deserialize(EDOHBJAPLPF_JsonData OILEIIEIBHP, int _KAPMOPMDHJE_label)
	{
		return false;
	}

	// RVA: 0x1C5097C Offset: 0x1C5097C VA: 0x1C5097C Slot: 11
	public override uint CAOGDCBPBAN()
	{
		TodoLogger.LogError(TodoLogger.DbIntegrityCheck, "EGLOKAEIHCB_LimitedItem.CAOGDCBPBAN");
		return 0;
	}
}
