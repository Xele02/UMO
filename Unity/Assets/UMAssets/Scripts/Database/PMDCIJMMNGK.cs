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

		public int PPFNGGCBJKC_Id { get { return EHOIENNDEDH_IdCrypted ^ FBGGEFFJJHB; } set { EHOIENNDEDH_IdCrypted = value ^ FBGGEFFJJHB; } } //DEMEPMAEJOO 0xFED710 HIGKAIDMOKN 0xFECE08
		public int GJDNBENICPF_VcId { get { return MAOCONDFGBL_VcIdCrypted ^ FBGGEFFJJHB; } set { MAOCONDFGBL_VcIdCrypted = value ^ FBGGEFFJJHB; } } //AFNFOLBCEAH 0xFED114 NAFMLADMAGK 0xFECEA4
		public int IJEKNCDIIAE_MVer { get { return GNGNIKNNCNH_MVerCrypted ^ FBGGEFFJJHB; } set { GNGNIKNNCNH_MVerCrypted = value ^ FBGGEFFJJHB; } } //KJIMMIBDCIL 0xFED7E8 DMEGNOKIKCD 0xFECFDC
		public int PLALNIIBLOF_Enabled { get { return HNJHPNPFAAN_EnabledCrypted ^ FBGGEFFJJHB; } set { HNJHPNPFAAN_EnabledCrypted = value ^ FBGGEFFJJHB; } } //JPCJNLHHIPE 0xFED880 JJFJNEJLBDG 0xFECF40
		public int DOOGFEGEKLG_Max { get { return LCGJKAGIFGO_MaxCrypted ^ FBGGEFFJJHB; } set { LCGJKAGIFGO_MaxCrypted = value ^ FBGGEFFJJHB; } } //AECMFIOFFJN 0xFED918 NGOJJDOCIDG 0xFED078

		// RVA: 0xFED61C Offset: 0xFED61C VA: 0xFED61C
		//public uint CAOGDCBPBAN() { }
	}

	public const int ODBKCBKACNP = 13;
	public static int FBGGEFFJJHB = 0x304c2; // 0x0
	public List<EJAKHFONNGN> CDENCMNHNGA = new List<EJAKHFONNGN>(13); // 0x20
	public List<int> DHIACJMOEBH = new List<int>(); // 0x24

	// RVA: 0xFEC644 Offset: 0xFEC644 VA: 0xFEC644
	public EJAKHFONNGN ACEHGKOLBCG(int KIJAPOFAGPN)
	{
		EKLNMHFCAOI.FKGCBLHOOCL_Category itemCat = EKLNMHFCAOI.BKHFLDMOGBD_GetItemCategory(KIJAPOFAGPN);
		int itemId = EKLNMHFCAOI.DEACAHNLMNI_getItemId(KIJAPOFAGPN);
		if(itemCat == EKLNMHFCAOI.FKGCBLHOOCL_Category.OBHECJMAEIO_GachaTicket)
		{
			return CDENCMNHNGA.Find((EJAKHFONNGN GHPLINIACBB) =>
			{
				//0xFED6D0
				return GHPLINIACBB.PPFNGGCBJKC_Id == itemId;
			});
		}
		return null;
	}

	// // RVA: 0xFEC7A4 Offset: 0xFEC7A4 VA: 0xFEC7A4
	public EJAKHFONNGN AAJILEFHFGC(int GJDNBENICPF)
	{
		return CDENCMNHNGA.Find((EJAKHFONNGN GHPLINIACBB) =>
		{
			//0xFED7A8
			return GHPLINIACBB.GJDNBENICPF_VcId == GJDNBENICPF;
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
	protected override void KMBPACJNEOF()
    {
		CDENCMNHNGA.Clear();
		DHIACJMOEBH.Clear();
	}

	// RVA: 0xFECA74 Offset: 0xFECA74 VA: 0xFECA74 Slot: 9
	public override bool IIEMACPEEBJ(byte[] DBBGALAPFGC)
    {
		ONPNHODCGFB reader = ONPNHODCGFB.HEGEKFMJNCC(DBBGALAPFGC);
		HMJNEBPFCKE[] array = reader.IGBEFKKKMKJ;
		for(int i = 0; i < array.Length; i++)
		{
			EJAKHFONNGN data = new EJAKHFONNGN();
			if(array[i].IJEKNCDIIAE <= IEFOPDOOLOK_MasterVersion)
			{
				if(array[i].PLALNIIBLOF > 1)
				{
					data.PPFNGGCBJKC_Id = (int)array[i].PPFNGGCBJKC;
					data.GJDNBENICPF_VcId = (int)array[i].GJDNBENICPF;
					data.PLALNIIBLOF_Enabled = (int)array[i].PLALNIIBLOF;
					data.IJEKNCDIIAE_MVer = array[i].IJEKNCDIIAE;
					data.DOOGFEGEKLG_Max = (int)array[i].DOOGFEGEKLG;
					CDENCMNHNGA.Add(data);
					DHIACJMOEBH.Add(data.GJDNBENICPF_VcId);
				}
			}
		}
		return true;
    }

	// RVA: 0xFED1AC Offset: 0xFED1AC VA: 0xFED1AC Slot: 10
	public override bool IIEMACPEEBJ(EDOHBJAPLPF_JsonData OILEIIEIBHP, int KAPMOPMDHJE)
    {
        TodoLogger.LogError(0, "TODO");
        return true;
    }

	// RVA: 0xFED538 Offset: 0xFED538 VA: 0xFED538 Slot: 11
	public override uint CAOGDCBPBAN()
	{
		TodoLogger.LogError(TodoLogger.DbIntegrityCheck, "TODO");
		return 0;
	}
}
