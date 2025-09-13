
using System.Collections.Generic;

[System.Obsolete("Use PPNFHHPJOKK_SpItem", true)]
public class PPNFHHPJOKK { }
public class PPNFHHPJOKK_SpItem : DIHHCBACKGG_DbSection
{
	public class JBBIPIAABOJ
	{
		public int EHOIENNDEDH_IdCrypted; // 0x8
		public int HNNLOMMFHEN; // 0xC
		public int ICKOHEDLEFP; // 0x10
		public int LCGJKAGIFGO; // 0x14
		public int HNJHPNPFAAN; // 0x18
		public int GNGNIKNNCNH_MVerCrypted; // 0x1C
		public int EAJCFBCHIFB_RarityCrypted; // 0x20
		public int HHPFFPINGAA; // 0x24

		public int PPFNGGCBJKC_Id { get { return EHOIENNDEDH_IdCrypted ^ FBGGEFFJJHB_xor; } set { EHOIENNDEDH_IdCrypted = value ^ FBGGEFFJJHB_xor; } } //0xDF8948 DEMEPMAEJOO 0xDF8210 HIGKAIDMOKN
		public int DMEDKJPOLCH_Category { get { return HNNLOMMFHEN ^ FBGGEFFJJHB_xor; } set { HNNLOMMFHEN = value ^ FBGGEFFJJHB_xor; } } //0xDF89E0 IPKCKAAEEOE 0xDF82AC JOGLLINFLJN
		public int JBGEEPFKIGG { get { return ICKOHEDLEFP ^ FBGGEFFJJHB_xor; } set { ICKOHEDLEFP = value ^ FBGGEFFJJHB_xor; } } //0xDF8A78 OLOCMINKGON 0xDF8348 ABAFHIBFKCE
		public int DOOGFEGEKLG_Max { get { return LCGJKAGIFGO ^ FBGGEFFJJHB_xor; } set { LCGJKAGIFGO = value ^ FBGGEFFJJHB_xor; } } //0xDF8B10 AECMFIOFFJN 0xDF83E4 NGOJJDOCIDG
		public int PLALNIIBLOF_Enabled { get { return HNJHPNPFAAN ^ FBGGEFFJJHB_xor; } set { HNJHPNPFAAN = value ^ FBGGEFFJJHB_xor; } } //0xDF86F0 JPCJNLHHIPE 0xDF8480 JJFJNEJLBDG
		public int IJEKNCDIIAE { get { return GNGNIKNNCNH_MVerCrypted ^ FBGGEFFJJHB_xor; } set { GNGNIKNNCNH_MVerCrypted = value ^ FBGGEFFJJHB_xor; } } //0xDF8BA8 KJIMMIBDCIL 0xDF851C DMEGNOKIKCD
		public int EKLIPGELKCL_Rarity { get { return EAJCFBCHIFB_RarityCrypted ^ FBGGEFFJJHB_xor; } set { EAJCFBCHIFB_RarityCrypted = value ^ FBGGEFFJJHB_xor; } } //0xDF8C40 OEEHBGECGKL 0xDF85B8 GHLMHLJJBIG
		public int EILKGEADKGH_Order { get { return HHPFFPINGAA ^ FBGGEFFJJHB_xor; } set { HHPFFPINGAA = value ^ FBGGEFFJJHB_xor; } } //0xDF8CD8 NPDDACIHBKD 0xDF8654 BJJMCKHBPNH

		//// RVA: 0xDF8874 Offset: 0xDF8874 VA: 0xDF8874
		//public uint CAOGDCBPBAN() { }
	}

	public const int EGAGLFMOBEP = 16;
	public static int FBGGEFFJJHB_xor = 0x1a63; // 0x0
	public List<JBBIPIAABOJ> CDENCMNHNGA_table = new List<JBBIPIAABOJ>(); // 0x20

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
		CDENCMNHNGA_table.Clear();
	}

	// RVA: 0xDF7E48 Offset: 0xDF7E48 VA: 0xDF7E48 Slot: 9
	public override bool IIEMACPEEBJ(byte[] _DBBGALAPFGC_Data)
	{
		LLENNGEBHNC parser = LLENNGEBHNC.HEGEKFMJNCC(_DBBGALAPFGC_Data);
		IBOBDDNBCKJ[] array = parser.AHGBBPMKAJK;
		for(int i = 0; i < array.Length; i++)
		{
			JBBIPIAABOJ data = new JBBIPIAABOJ();
			data.PPFNGGCBJKC_Id = (int)array[i].PPFNGGCBJKC;
			data.DMEDKJPOLCH_Category = (int)array[i].DMEDKJPOLCH;
			data.JBGEEPFKIGG = (int)array[i].JBGEEPFKIGG;
			data.DOOGFEGEKLG_Max = (int)array[i].DOOGFEGEKLG;
			data.PLALNIIBLOF_Enabled = (int)array[i].PLALNIIBLOF;
			data.IJEKNCDIIAE = array[i].IJEKNCDIIAE;
			data.EKLIPGELKCL_Rarity = (int)array[i].FBFLDFMFFOH;
			data.EILKGEADKGH_Order = (int)array[i].FPOMEEJFBIG;
			data.PLALNIIBLOF_Enabled = JKAECBCNHAN_IsEnabled(array[i].IJEKNCDIIAE, data.PLALNIIBLOF_Enabled, 0);
			CDENCMNHNGA_table.Add(data);
		}
		return true;
	}

	// RVA: 0xDF8788 Offset: 0xDF8788 VA: 0xDF8788 Slot: 10
	public override bool IIEMACPEEBJ(EDOHBJAPLPF_JsonData OILEIIEIBHP, int KAPMOPMDHJE)
	{
		return false;
	}

	// RVA: 0xDF8790 Offset: 0xDF8790 VA: 0xDF8790 Slot: 11
	public override uint CAOGDCBPBAN()
	{
		TodoLogger.LogError(TodoLogger.DbIntegrityCheck, "PPNFHHPJOKK_SpItem.CAOGDCBPBAN");
		return 0;
	}
}
