
using System.Collections.Generic;

[System.Obsolete("Use KIICLPJJBNL_EpiItem", true)]
public class KIICLPJJBNL { }
public class KIICLPJJBNL_EpiItem : DIHHCBACKGG_DbSection
{
	public class NKGPGMOHAFM
	{
		public int EHOIENNDEDH_IdCrypted; // 0x8
		public int EAJCFBCHIFB_RarityCrypted; // 0xC
		public int ICKOHEDLEFP_ValueCrypted; // 0x10

		public int PPFNGGCBJKC_id { get { return EHOIENNDEDH_IdCrypted ^ FBGGEFFJJHB_xor; } set { EHOIENNDEDH_IdCrypted = value ^ FBGGEFFJJHB_xor; } } //0x19FFF4C DEMEPMAEJOO_get_id 0x19FF8F8 HIGKAIDMOKN_set_id
		public int EKLIPGELKCL_Rarity { get { return EAJCFBCHIFB_RarityCrypted ^ FBGGEFFJJHB_xor; } set { EAJCFBCHIFB_RarityCrypted = value ^ FBGGEFFJJHB_xor; } } //0x19FFFE4 OEEHBGECGKL_get_Rarity 0x19FF994 GHLMHLJJBIG_set_Rarity
		public int JBGEEPFKIGG_val { get { return ICKOHEDLEFP_ValueCrypted ^ FBGGEFFJJHB_xor; } set { ICKOHEDLEFP_ValueCrypted = value ^ FBGGEFFJJHB_xor; } } //0x1A0007C OLOCMINKGON_get_val 0x19FFA30 ABAFHIBFKCE_set_val

		// RVA: 0x19FFEB0 Offset: 0x19FFEB0 VA: 0x19FFEB0
		//public uint CAOGDCBPBAN() { }
	}

	public const int KOAENKKAMCJ = 3;
	public static int FBGGEFFJJHB_xor = 0x181b5; // 0x0
	public List<NKGPGMOHAFM> CDENCMNHNGA_table = new List<NKGPGMOHAFM>(); // 0x20

	// RVA: 0x19FF550 Offset: 0x19FF550 VA: 0x19FF550
	public KIICLPJJBNL_EpiItem()
	{
		JIKKNHIAEKG_BlockName = "";
		LNIMEIMBCMF = false;
		LMHMIIKCGPE = 26;
	}

	// RVA: 0x19FF648 Offset: 0x19FF648 VA: 0x19FF648 Slot: 8
	protected override void KMBPACJNEOF_Reset()
	{
		CDENCMNHNGA_table.Clear();
	}

	// RVA: 0x19FF6C0 Offset: 0x19FF6C0 VA: 0x19FF6C0 Slot: 9
	public override bool IIEMACPEEBJ_Deserialize(byte[] _DBBGALAPFGC_bytes)
	{
		EHIHLFGHOEF parser = EHIHLFGHOEF.HEGEKFMJNCC(_DBBGALAPFGC_bytes);
		COBIMANANGK[] array = parser.AJJAKJEMCID;
		if(array.Length < 4)
		{
			for (int i = 0; i < array.Length; i++)
			{
				NKGPGMOHAFM data = new NKGPGMOHAFM();
				data.PPFNGGCBJKC_id = (int)array[i].PPFNGGCBJKC_id;
				data.EKLIPGELKCL_Rarity = (int)array[i].FBFLDFMFFOH_rar;
				data.JBGEEPFKIGG_val = (int)array[i].JBGEEPFKIGG_val;
				CDENCMNHNGA_table.Add(data);
			}
			return true;
		}
		return false;
	}

	// RVA: 0x19FFACC Offset: 0x19FFACC VA: 0x19FFACC Slot: 10
	public override bool IIEMACPEEBJ_Deserialize(EDOHBJAPLPF_JsonData OILEIIEIBHP, int _KAPMOPMDHJE_label)
	{
		//CDENCMNHNGA_table = uc_item
		//	PPFNGGCBJKC_id = PPFNGGCBJKC_id
		//	EKLIPGELKCL_Rarity = FBFLDFMFFOH_rar
		//	JBGEEPFKIGG_val = JBGEEPFKIGG_val
		TodoLogger.LogError(TodoLogger.DbJson, "KIICLPJJBNL_EpiItem.IIEMACPEEBJ_Deserialize");
		return true;
	}

	// RVA: 0x19FFDCC Offset: 0x19FFDCC VA: 0x19FFDCC Slot: 11
	public override uint CAOGDCBPBAN()
	{
		TodoLogger.LogError(TodoLogger.DbIntegrityCheck, "KIICLPJJBNL_EpiItem.CAOGDCBPBAN");
		return 0;
	}
}
