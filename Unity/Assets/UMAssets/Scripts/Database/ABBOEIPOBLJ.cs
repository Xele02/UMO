
using System.Collections.Generic;
using XeSys;

[System.Obsolete("Use ABBOEIPOBLJ_EventTicket", true)]
public class ABBOEIPOBLJ { }
public class ABBOEIPOBLJ_EventTicket : DIHHCBACKGG_DbSection
{
	public class CBDACMFFHJC
	{
		public int FBGGEFFJJHB_xor = 0x181b5; // 0x8
		public int EHOIENNDEDH_IdCrypted; // 0xC
		public int EAJCFBCHIFB_RarityCrypted; // 0x10
		public int ICKOHEDLEFP_ValueCrypted; // 0x14
		public int MKENMKMJFKP_TypeCrypted; // 0x18

		public int PPFNGGCBJKC_id { get { return EHOIENNDEDH_IdCrypted ^ FBGGEFFJJHB_xor; } set { EHOIENNDEDH_IdCrypted = value ^ FBGGEFFJJHB_xor; } } //0x15B094C DEMEPMAEJOO_get_id 0x15B0464 HIGKAIDMOKN_set_id
		public int EKLIPGELKCL_Rarity { get { return EAJCFBCHIFB_RarityCrypted ^ FBGGEFFJJHB_xor; } set { EAJCFBCHIFB_RarityCrypted = value ^ FBGGEFFJJHB_xor; } } //0x15B095C OEEHBGECGKL_get_Rarity 0x15B0474 GHLMHLJJBIG_set_Rarity
		public int JBGEEPFKIGG_val { get { return ICKOHEDLEFP_ValueCrypted ^ FBGGEFFJJHB_xor; } set { ICKOHEDLEFP_ValueCrypted = value ^ FBGGEFFJJHB_xor; } } //0x15B096C OLOCMINKGON_get_val 0x15B0484 ABAFHIBFKCE_set_val
		public int INDDJNMPONH_type { get { return MKENMKMJFKP_TypeCrypted ^ FBGGEFFJJHB_xor; } set { MKENMKMJFKP_TypeCrypted = value ^ FBGGEFFJJHB_xor; } } //0x15B097C GHAILOLPHPF_bgs 0x15B0494 BACGOKIGMBC_bgs

		//// RVA: 0x15B0920 Offset: 0x15B0920 VA: 0x15B0920
		//public uint CAOGDCBPBAN() { }
	}

	public List<CBDACMFFHJC> CDENCMNHNGA_table = new List<CBDACMFFHJC>(); // 0x20

	// RVA: 0x15B0048 Offset: 0x15B0048 VA: 0x15B0048
	public ABBOEIPOBLJ_EventTicket()
	{
		JIKKNHIAEKG_BlockName = "";
		LNIMEIMBCMF = false;
		LMHMIIKCGPE = 44;
	}

	// RVA: 0x15B013C Offset: 0x15B013C VA: 0x15B013C Slot: 8
	protected override void KMBPACJNEOF_Reset()
	{
		CDENCMNHNGA_table.Clear();
	}

	// RVA: 0x15B01B4 Offset: 0x15B01B4 VA: 0x15B01B4 Slot: 9
	public override bool IIEMACPEEBJ_Deserialize(byte[] _DBBGALAPFGC_bytes)
	{
		BELBAJBINBO parser = BELBAJBINBO.HEGEKFMJNCC(_DBBGALAPFGC_bytes);
		EIIBKGHEGFI[] array = parser.GMDKFCMGHIK;
		int k = (int)Utility.GetCurrentUnixTime();
		k *= 0x3981;
		for (int i = 0; i < array.Length; i++)
		{
			CBDACMFFHJC data = new CBDACMFFHJC();
			data.FBGGEFFJJHB_xor = k;
			data.PPFNGGCBJKC_id = (int)array[i].PPFNGGCBJKC_id;
			data.EKLIPGELKCL_Rarity = (int)array[i].FBFLDFMFFOH_rar;
			data.JBGEEPFKIGG_val = (int)array[i].JBGEEPFKIGG_val;
			data.INDDJNMPONH_type = (int)array[i].GBJFNGCDKPM_typ;
			k *= 0x6cd;
			CDENCMNHNGA_table.Add(data);
		}
		return true;
	}

	// RVA: 0x15B04A4 Offset: 0x15B04A4 VA: 0x15B04A4 Slot: 10
	public override bool IIEMACPEEBJ_Deserialize(EDOHBJAPLPF_JsonData OILEIIEIBHP, int _KAPMOPMDHJE_label)
	{
		//CDENCMNHNGA_table = COCEIPAKJKF_item
		//	PPFNGGCBJKC_id = PPFNGGCBJKC_id
		//	EKLIPGELKCL_Rarity = FBFLDFMFFOH_rar
		//	JBGEEPFKIGG_val = JBGEEPFKIGG_val
		//	INDDJNMPONH_type = GBJFNGCDKPM_typ
		TodoLogger.LogError(TodoLogger.DbJson, "ABBOEIPOBLJ_EventTicket.IIEMACPEEBJ_Deserialize");
		return true;
	}

	// RVA: 0x15B0820 Offset: 0x15B0820 VA: 0x15B0820 Slot: 11
	public override uint CAOGDCBPBAN()
	{
		TodoLogger.LogError(TodoLogger.DbIntegrityCheck, "ABBOEIPOBLJ_EventTicket.CAOGDCBPBAN");
		return 0;
	}
}
