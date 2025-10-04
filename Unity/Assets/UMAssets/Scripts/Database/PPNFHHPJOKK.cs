
using System.Collections.Generic;

[System.Obsolete("Use PPNFHHPJOKK_SpItem", true)]
public class PPNFHHPJOKK { }
public class PPNFHHPJOKK_SpItem : DIHHCBACKGG_DbSection
{
	public class JBBIPIAABOJ
	{
		public int EHOIENNDEDH_IdCrypted; // 0x8
		public int HNNLOMMFHEN_catCrypted; // 0xC
		public int ICKOHEDLEFP_ValueCrypted; // 0x10
		public int LCGJKAGIFGO_MaxCrypted; // 0x14
		public int HNJHPNPFAAN_EnabledCrypted; // 0x18
		public int GNGNIKNNCNH_MVerCrypted; // 0x1C
		public int EAJCFBCHIFB_RarityCrypted; // 0x20
		public int HHPFFPINGAA_OrderCrypted; // 0x24

		public int PPFNGGCBJKC_id { get { return EHOIENNDEDH_IdCrypted ^ FBGGEFFJJHB_xor; } set { EHOIENNDEDH_IdCrypted = value ^ FBGGEFFJJHB_xor; } } //0xDF8948 DEMEPMAEJOO_get_id 0xDF8210 HIGKAIDMOKN_set_id
		public int DMEDKJPOLCH_cat { get { return HNNLOMMFHEN_catCrypted ^ FBGGEFFJJHB_xor; } set { HNNLOMMFHEN_catCrypted = value ^ FBGGEFFJJHB_xor; } } //0xDF89E0 IPKCKAAEEOE_get_cat 0xDF82AC JOGLLINFLJN_set_cat
		public int JBGEEPFKIGG_val { get { return ICKOHEDLEFP_ValueCrypted ^ FBGGEFFJJHB_xor; } set { ICKOHEDLEFP_ValueCrypted = value ^ FBGGEFFJJHB_xor; } } //0xDF8A78 OLOCMINKGON_get_val 0xDF8348 ABAFHIBFKCE_set_val
		public int DOOGFEGEKLG_max { get { return LCGJKAGIFGO_MaxCrypted ^ FBGGEFFJJHB_xor; } set { LCGJKAGIFGO_MaxCrypted = value ^ FBGGEFFJJHB_xor; } } //0xDF8B10 AECMFIOFFJN_get_max 0xDF83E4 NGOJJDOCIDG_set_max
		public int PLALNIIBLOF_en { get { return HNJHPNPFAAN_EnabledCrypted ^ FBGGEFFJJHB_xor; } set { HNJHPNPFAAN_EnabledCrypted = value ^ FBGGEFFJJHB_xor; } } //0xDF86F0 JPCJNLHHIPE_get_en 0xDF8480 JJFJNEJLBDG_set_en
		public int IJEKNCDIIAE_mver { get { return GNGNIKNNCNH_MVerCrypted ^ FBGGEFFJJHB_xor; } set { GNGNIKNNCNH_MVerCrypted = value ^ FBGGEFFJJHB_xor; } } //0xDF8BA8 KJIMMIBDCIL_get_mver 0xDF851C DMEGNOKIKCD_set_mver
		public int EKLIPGELKCL_Rarity { get { return EAJCFBCHIFB_RarityCrypted ^ FBGGEFFJJHB_xor; } set { EAJCFBCHIFB_RarityCrypted = value ^ FBGGEFFJJHB_xor; } } //0xDF8C40 OEEHBGECGKL_get_Rarity 0xDF85B8 GHLMHLJJBIG_set_Rarity
		public int EILKGEADKGH_Order { get { return HHPFFPINGAA_OrderCrypted ^ FBGGEFFJJHB_xor; } set { HHPFFPINGAA_OrderCrypted = value ^ FBGGEFFJJHB_xor; } } //0xDF8CD8 NPDDACIHBKD_get_Order 0xDF8654 BJJMCKHBPNH_set_Order

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
	protected override void KMBPACJNEOF_Reset()
	{
		CDENCMNHNGA_table.Clear();
	}

	// RVA: 0xDF7E48 Offset: 0xDF7E48 VA: 0xDF7E48 Slot: 9
	public override bool IIEMACPEEBJ_Deserialize(byte[] _DBBGALAPFGC_bytes)
	{
		LLENNGEBHNC parser = LLENNGEBHNC.HEGEKFMJNCC(_DBBGALAPFGC_bytes);
		IBOBDDNBCKJ[] array = parser.AHGBBPMKAJK;
		for(int i = 0; i < array.Length; i++)
		{
			JBBIPIAABOJ data = new JBBIPIAABOJ();
			data.PPFNGGCBJKC_id = (int)array[i].PPFNGGCBJKC_id;
			data.DMEDKJPOLCH_cat = (int)array[i].DMEDKJPOLCH_cat;
			data.JBGEEPFKIGG_val = (int)array[i].JBGEEPFKIGG_val;
			data.DOOGFEGEKLG_max = (int)array[i].DOOGFEGEKLG_max;
			data.PLALNIIBLOF_en = (int)array[i].PLALNIIBLOF_en;
			data.IJEKNCDIIAE_mver = array[i].IJEKNCDIIAE_mver;
			data.EKLIPGELKCL_Rarity = (int)array[i].FBFLDFMFFOH_rar;
			data.EILKGEADKGH_Order = (int)array[i].FPOMEEJFBIG_odr;
			data.PLALNIIBLOF_en = JKAECBCNHAN_IsEnabled(array[i].IJEKNCDIIAE_mver, data.PLALNIIBLOF_en, 0);
			CDENCMNHNGA_table.Add(data);
		}
		return true;
	}

	// RVA: 0xDF8788 Offset: 0xDF8788 VA: 0xDF8788 Slot: 10
	public override bool IIEMACPEEBJ_Deserialize(EDOHBJAPLPF_JsonData OILEIIEIBHP, int _KAPMOPMDHJE_label)
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
