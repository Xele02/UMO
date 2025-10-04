
using System.Collections.Generic;

[System.Obsolete("Use DGDIEDDPNNG_UcItem", true)]
public class DGDIEDDPNNG { }
public class DGDIEDDPNNG_UcItem : DIHHCBACKGG_DbSection
{
	public class FCPCMPLGJNP
	{
		public int EHOIENNDEDH_IdCrypted; // 0x8
		public int EAJCFBCHIFB_RarityCrypted; // 0xC
		public int ICKOHEDLEFP_ValueCrypted; // 0x10

		public int PPFNGGCBJKC_id { get { return EHOIENNDEDH_IdCrypted ^ FBGGEFFJJHB_xor; } set { EHOIENNDEDH_IdCrypted = value ^ FBGGEFFJJHB_xor; } } //0x1984F74 DEMEPMAEJOO_get_id 0x198472C HIGKAIDMOKN_set_id
		public int EKLIPGELKCL_Rarity { get { return EAJCFBCHIFB_RarityCrypted ^ FBGGEFFJJHB_xor; } set { EAJCFBCHIFB_RarityCrypted = value ^ FBGGEFFJJHB_xor; } } //0x198500C OEEHBGECGKL_get_Rarity 0x19847C8 GHLMHLJJBIG_set_Rarity
		public int JBGEEPFKIGG_val { get { return ICKOHEDLEFP_ValueCrypted ^ FBGGEFFJJHB_xor; } set { ICKOHEDLEFP_ValueCrypted = value ^ FBGGEFFJJHB_xor; } } //0x19850A4 OLOCMINKGON_get_val 0x1984864 ABAFHIBFKCE_set_val

		//// RVA: 0x1984ED8 Offset: 0x1984ED8 VA: 0x1984ED8
		//public uint CAOGDCBPBAN() { }
	}

	public const int COJKCBBIOIL = 15;
	public static int FBGGEFFJJHB_xor = 0xb516d; // 0x0
	public List<FCPCMPLGJNP> CDENCMNHNGA_table = new List<FCPCMPLGJNP>(); // 0x20

	// RVA: 0x1984318 Offset: 0x1984318 VA: 0x1984318
	public DGDIEDDPNNG_UcItem()
	{
		JIKKNHIAEKG_BlockName = "";
		LMHMIIKCGPE = 84;
		LNIMEIMBCMF = false;

	}

	// RVA: 0x1984490 Offset: 0x1984490 VA: 0x1984490 Slot: 8
	protected override void KMBPACJNEOF_Reset()
	{
		CDENCMNHNGA_table.Clear();
	}

	// RVA: 0x1984508 Offset: 0x1984508 VA: 0x1984508 Slot: 9
	public override bool IIEMACPEEBJ_Deserialize(byte[] _DBBGALAPFGC_bytes)
	{
		MMEGEEMJBDH parser = MMEGEEMJBDH.HEGEKFMJNCC(_DBBGALAPFGC_bytes);
		LPBEJIIKIDI[] array = parser.KLFCPLCMION;
		for(int i = 0; i < array.Length; i++)
		{
			FCPCMPLGJNP data = new FCPCMPLGJNP();
			data.PPFNGGCBJKC_id = (int)array[i].PPFNGGCBJKC_id;
			data.EKLIPGELKCL_Rarity = (int)array[i].FBFLDFMFFOH_rar;
			data.JBGEEPFKIGG_val = (int)array[i].JBGEEPFKIGG_val;
			CDENCMNHNGA_table.Add(data);
		}
		return true;
	}

	// RVA: 0x1984900 Offset: 0x1984900 VA: 0x1984900 Slot: 10
	public override bool IIEMACPEEBJ_Deserialize(EDOHBJAPLPF_JsonData OILEIIEIBHP, int _KAPMOPMDHJE_label)
	{
		//CDENCMNHNGA_table = uc_item
		//	PPFNGGCBJKC_id = PPFNGGCBJKC_id
		//	EKLIPGELKCL_Rarity = FBFLDFMFFOH_rar
		//	JBGEEPFKIGG_val = JBGEEPFKIGG_val
		TodoLogger.LogError(TodoLogger.DbJson, "DGDIEDDPNNG_UcItem.IIEMACPEEBJ_Deserialize");
		return true;
	}

	// RVA: 0x1984DF4 Offset: 0x1984DF4 VA: 0x1984DF4 Slot: 11
	public override uint CAOGDCBPBAN()
	{
		TodoLogger.LogError(TodoLogger.DbIntegrityCheck, "DGDIEDDPNNG_UcItem.CAOGDCBPBAN");
		return 0;
	}
}
