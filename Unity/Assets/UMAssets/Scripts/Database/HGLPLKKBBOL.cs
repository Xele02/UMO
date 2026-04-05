
using System.Collections.Generic;
using XeSys;

[System.Obsolete("Use HGLPLKKBBOL_EventItem", true)]
public class HGLPLKKBBOL { }
[UMOClass()]
public class HGLPLKKBBOL_EventItem : DIHHCBACKGG_DbSection
{
	[UMOClass()]
	public class JMCDEDCMCJE
	{
		public int FBGGEFFJJHB_xor = 0x181b5; // 0x8
		public int EHOIENNDEDH_IdCrypted; // 0xC
		public int EAJCFBCHIFB_RarityCrypted; // 0x10
		public int ICKOHEDLEFP_ValueCrypted; // 0x14
		public int MKENMKMJFKP_TypeCrypted; // 0x18

		[UMOMember()]
		public int PPFNGGCBJKC_id { get { return EHOIENNDEDH_IdCrypted ^ FBGGEFFJJHB_xor; } set { EHOIENNDEDH_IdCrypted = value ^ FBGGEFFJJHB_xor; } } //0x1751E94 DEMEPMAEJOO_get_id 0x17519AC HIGKAIDMOKN_set_id
		[UMOMember()]
		public int EKLIPGELKCL_Rarity { get { return EAJCFBCHIFB_RarityCrypted ^ FBGGEFFJJHB_xor; } set { EAJCFBCHIFB_RarityCrypted = value ^ FBGGEFFJJHB_xor; } } //0x1751EA4 OEEHBGECGKL_get_Rarity 0x17519BC GHLMHLJJBIG_set_Rarity
		[UMOMember()]
		public int JBGEEPFKIGG_val { get { return ICKOHEDLEFP_ValueCrypted ^ FBGGEFFJJHB_xor; } set { ICKOHEDLEFP_ValueCrypted = value ^ FBGGEFFJJHB_xor; } } //0x1751EB4 OLOCMINKGON_get_val 0x17519CC ABAFHIBFKCE_set_val
		[UMOMember()]
		public int INDDJNMPONH_type { get { return MKENMKMJFKP_TypeCrypted ^ FBGGEFFJJHB_xor; } set { MKENMKMJFKP_TypeCrypted = value ^ FBGGEFFJJHB_xor; } } //0x1751EC4 GHAILOLPHPF_bgs 0x17519DC BACGOKIGMBC_bgs

		//// RVA: 0x1751E68 Offset: 0x1751E68 VA: 0x1751E68
		//public uint CAOGDCBPBAN() { }
	}

	[UMOMember()]
	public List<JMCDEDCMCJE> CDENCMNHNGA_table = new List<JMCDEDCMCJE>(); // 0x20

	// RVA: 0x1751590 Offset: 0x1751590 VA: 0x1751590
	public HGLPLKKBBOL_EventItem()
	{
		JIKKNHIAEKG_BlockName = "";
		LNIMEIMBCMF = false;
		LMHMIIKCGPE = 34;
	}

	// RVA: 0x1751684 Offset: 0x1751684 VA: 0x1751684 Slot: 8
	protected override void KMBPACJNEOF_Reset()
	{
		CDENCMNHNGA_table.Clear();
	}

	// RVA: 0x17516FC Offset: 0x17516FC VA: 0x17516FC Slot: 9
	public override bool IIEMACPEEBJ_Deserialize(byte[] _DBBGALAPFGC_bytes)
	{
		OOFJBDCPKBJ parser = OOFJBDCPKBJ.HEGEKFMJNCC(_DBBGALAPFGC_bytes);
		COGPJCIDIKA[] array = parser.LMNJDPMHNLB;
		int k = (int)Utility.GetCurrentUnixTime();
		k *= 0x181b5;
		for(int i = 0; i < array.Length; i++)
		{
			JMCDEDCMCJE data = new JMCDEDCMCJE();
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

	// RVA: 0x17519EC Offset: 0x17519EC VA: 0x17519EC Slot: 10
	public override bool IIEMACPEEBJ_Deserialize(EDOHBJAPLPF_JsonData OILEIIEIBHP, int _KAPMOPMDHJE_label)
	{
		//CDENCMNHNGA_table = COCEIPAKJKF_item
		//	PPFNGGCBJKC_id = PPFNGGCBJKC_id
		//	EKLIPGELKCL_Rarity = FBFLDFMFFOH_rar
		//	JBGEEPFKIGG_val = JBGEEPFKIGG_val
		//	INDDJNMPONH_type = GBJFNGCDKPM_typ
		TodoLogger.LogError(TodoLogger.DbJson, "HGLPLKKBBOL_EventItem.IIEMACPEEBJ_Deserialize");
		return true;
	}

	// RVA: 0x1751D68 Offset: 0x1751D68 VA: 0x1751D68 Slot: 11
	public override uint CAOGDCBPBAN()
	{
		TodoLogger.LogError(TodoLogger.DbIntegrityCheck, "HGLPLKKBBOL_EventItem.CAOGDCBPBAN");
		return 0;
	}
}
