using System.Collections.Generic;

[System.Obsolete("Use PMDCIJMMNGK_GachaTicket", true)]
public class PMDCIJMMNGK { }
public class PMDCIJMMNGK_GachaTicket : DIHHCBACKGG_DbSection
{
	public class EJAKHFONNGN
	{
		public int EHOIENNDEDH_IdCrypted; // 0x8
		public int MAOCONDFGBL_VcIdCrypted; // 0xC
		public int GNGNIKNNCNH_MVerCrypted; // 0x10
		public int HNJHPNPFAAN_EnabledCrypted; // 0x14
		public int LCGJKAGIFGO_MaxCrypted; // 0x18

		public int PPFNGGCBJKC_id { get { return EHOIENNDEDH_IdCrypted ^ FBGGEFFJJHB_xor; } set { EHOIENNDEDH_IdCrypted = value ^ FBGGEFFJJHB_xor; } } //DEMEPMAEJOO 0xFED710 HIGKAIDMOKN 0xFECE08
		public int GJDNBENICPF_vcid { get { return MAOCONDFGBL_VcIdCrypted ^ FBGGEFFJJHB_xor; } set { MAOCONDFGBL_VcIdCrypted = value ^ FBGGEFFJJHB_xor; } } //AFNFOLBCEAH 0xFED114 NAFMLADMAGK 0xFECEA4
		public int IJEKNCDIIAE_mver { get { return GNGNIKNNCNH_MVerCrypted ^ FBGGEFFJJHB_xor; } set { GNGNIKNNCNH_MVerCrypted = value ^ FBGGEFFJJHB_xor; } } //KJIMMIBDCIL 0xFED7E8 DMEGNOKIKCD 0xFECFDC
		public int PLALNIIBLOF_en { get { return HNJHPNPFAAN_EnabledCrypted ^ FBGGEFFJJHB_xor; } set { HNJHPNPFAAN_EnabledCrypted = value ^ FBGGEFFJJHB_xor; } } //JPCJNLHHIPE 0xFED880 JJFJNEJLBDG 0xFECF40
		public int DOOGFEGEKLG_max { get { return LCGJKAGIFGO_MaxCrypted ^ FBGGEFFJJHB_xor; } set { LCGJKAGIFGO_MaxCrypted = value ^ FBGGEFFJJHB_xor; } } //AECMFIOFFJN 0xFED918 NGOJJDOCIDG 0xFED078

		// RVA: 0xFED61C Offset: 0xFED61C VA: 0xFED61C
		//public uint CAOGDCBPBAN() { }
	}

	public const int ODBKCBKACNP = 13;
	public static int FBGGEFFJJHB_xor = 0x304c2; // 0x0
	public List<EJAKHFONNGN> CDENCMNHNGA_table = new List<EJAKHFONNGN>(13); // 0x20
	public List<int> DHIACJMOEBH = new List<int>(); // 0x24

	// RVA: 0xFEC644 Offset: 0xFEC644 VA: 0xFEC644
	public EJAKHFONNGN ACEHGKOLBCG(int _KIJAPOFAGPN_ItemId)
	{
		EKLNMHFCAOI.FKGCBLHOOCL_Category itemCat = EKLNMHFCAOI.BKHFLDMOGBD_GetItemCategory(_KIJAPOFAGPN_ItemId);
		int itemId = EKLNMHFCAOI.DEACAHNLMNI_getItemId(_KIJAPOFAGPN_ItemId);
		if(itemCat == EKLNMHFCAOI.FKGCBLHOOCL_Category.OBHECJMAEIO_GachaTicket)
		{
			return CDENCMNHNGA_table.Find((EJAKHFONNGN _GHPLINIACBB_x) =>
			{
				//0xFED6D0
				return _GHPLINIACBB_x.PPFNGGCBJKC_id == itemId;
			});
		}
		return null;
	}

	// // RVA: 0xFEC7A4 Offset: 0xFEC7A4 VA: 0xFEC7A4
	public EJAKHFONNGN AAJILEFHFGC(int _GJDNBENICPF_vcid)
	{
		return CDENCMNHNGA_table.Find((EJAKHFONNGN _GHPLINIACBB_x) =>
		{
			//0xFED7A8
			return _GHPLINIACBB_x.GJDNBENICPF_vcid == _GJDNBENICPF_vcid;
		});
	}

	// RVA: 0xFEC8A4 Offset: 0xFEC8A4 VA: 0xFEC8A4
	public PMDCIJMMNGK_GachaTicket()
    {
        JIKKNHIAEKG_BlockName = "";
        LNIMEIMBCMF = false;
        LMHMIIKCGPE = 48;
    }

	// RVA: 0xFEC9D0 Offset: 0xFEC9D0 VA: 0xFEC9D0 Slot: 8
	protected override void KMBPACJNEOF_Reset()
    {
		CDENCMNHNGA_table.Clear();
		DHIACJMOEBH.Clear();
	}

	// RVA: 0xFECA74 Offset: 0xFECA74 VA: 0xFECA74 Slot: 9
	public override bool IIEMACPEEBJ_Deserialize(byte[] _DBBGALAPFGC_bytes)
    {
		ONPNHODCGFB reader = ONPNHODCGFB.HEGEKFMJNCC(_DBBGALAPFGC_bytes);
		HMJNEBPFCKE[] array = reader.IGBEFKKKMKJ;
		for(int i = 0; i < array.Length; i++)
		{
			EJAKHFONNGN data = new EJAKHFONNGN();
			if(array[i].IJEKNCDIIAE_mver <= IEFOPDOOLOK_MasterVersion)
			{
				if(array[i].PLALNIIBLOF_en > 1)
				{
					data.PPFNGGCBJKC_id = (int)array[i].PPFNGGCBJKC_id;
					data.GJDNBENICPF_vcid = (int)array[i].GJDNBENICPF_vcid;
					data.PLALNIIBLOF_en = (int)array[i].PLALNIIBLOF_en;
					data.IJEKNCDIIAE_mver = array[i].IJEKNCDIIAE_mver;
					data.DOOGFEGEKLG_max = (int)array[i].DOOGFEGEKLG_max;
					CDENCMNHNGA_table.Add(data);
					DHIACJMOEBH.Add(data.GJDNBENICPF_vcid);
				}
			}
		}
		return true;
    }

	// RVA: 0xFED1AC Offset: 0xFED1AC VA: 0xFED1AC Slot: 10
	public override bool IIEMACPEEBJ_Deserialize(EDOHBJAPLPF_JsonData OILEIIEIBHP, int _KAPMOPMDHJE_label)
    {
		//CDENCMNHNGA_table = gacha_ticket
		//	PPFNGGCBJKC_id = PPFNGGCBJKC_id
		//	GJDNBENICPF_vcid = GJDNBENICPF_vcid
		//	IJEKNCDIIAE_mver = IJEKNCDIIAE_mver
		//	PLALNIIBLOF_en = PLALNIIBLOF_en
		//	DOOGFEGEKLG_max = DOOGFEGEKLG_max
        TodoLogger.LogError(TodoLogger.DbJson, "TODO");
        return true;
    }

	// RVA: 0xFED538 Offset: 0xFED538 VA: 0xFED538 Slot: 11
	public override uint CAOGDCBPBAN()
	{
		TodoLogger.LogError(TodoLogger.DbIntegrityCheck, "TODO");
		return 0;
	}
}
