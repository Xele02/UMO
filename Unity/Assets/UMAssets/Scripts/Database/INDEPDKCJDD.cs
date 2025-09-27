
using System.Collections.Generic;

[System.Obsolete("Use INDEPDKCJDD_ValItem", true)]
public class INDEPDKCJDD { }
public class INDEPDKCJDD_ValItem : DIHHCBACKGG_DbSection
{
	public class NHJLDENJKBE
	{
		public int EHOIENNDEDH_IdCrypted; // 0x8
		public int EAJCFBCHIFB_RarityCrypted; // 0xC
		public int MKENMKMJFKP_TypeCrypted; // 0x10

		public int PPFNGGCBJKC_id { get { return EHOIENNDEDH_IdCrypted ^ FBGGEFFJJHB_xor; } set { EHOIENNDEDH_IdCrypted = value ^ FBGGEFFJJHB_xor; } } //0xA0161C DEMEPMAEJOO 0xA012C4 HIGKAIDMOKN
		public int EKLIPGELKCL_Rarity { get { return EAJCFBCHIFB_RarityCrypted ^ FBGGEFFJJHB_xor; } set { EAJCFBCHIFB_RarityCrypted = value ^ FBGGEFFJJHB_xor; } } //0xA016B4 OEEHBGECGKL 0xA01360 GHLMHLJJBIG
		public int INDDJNMPONH_type { get { return MKENMKMJFKP_TypeCrypted ^ FBGGEFFJJHB_xor; } set { MKENMKMJFKP_TypeCrypted = value ^ FBGGEFFJJHB_xor; } } //0xA0174C GHAILOLPHPF 0xA013FC BACGOKIGMBC

		//// RVA: 0xA01584 Offset: 0xA01584 VA: 0xA01584
		//public uint CAOGDCBPBAN() { }
	}

	public const int IEEFAIKAKPG = 5;
	public static int FBGGEFFJJHB_xor = 0x3039; // 0x0
	public List<NHJLDENJKBE> CDENCMNHNGA_table = new List<NHJLDENJKBE>(); // 0x20

	// RVA: 0xA00F00 Offset: 0xA00F00 VA: 0xA00F00
	public INDEPDKCJDD_ValItem()
	{
		JIKKNHIAEKG_BlockName = "";
		LNIMEIMBCMF = false;
		LMHMIIKCGPE = 86;
	}

	// RVA: 0xA00FF8 Offset: 0xA00FF8 VA: 0xA00FF8 Slot: 8
	protected override void KMBPACJNEOF_Reset()
	{
		if(CDENCMNHNGA_table != null)
			CDENCMNHNGA_table.Clear();
	}

	// RVA: 0xA01064 Offset: 0xA01064 VA: 0xA01064 Slot: 9
	public override bool IIEMACPEEBJ_Deserialize(byte[] _DBBGALAPFGC_bytes)
	{
		MADCJBCGGEE parser = MADCJBCGGEE.HEGEKFMJNCC(_DBBGALAPFGC_bytes);
		FLNGBOANAGE[] array = parser.GKNGIIHMBOD;
		CDENCMNHNGA_table = new List<NHJLDENJKBE>(array.Length);
		for(int i = 0; i < array.Length; i++)
		{
			NHJLDENJKBE data = new NHJLDENJKBE();
			data.PPFNGGCBJKC_id = (int)array[i].PPFNGGCBJKC_id;
			data.EKLIPGELKCL_Rarity = (int)array[i].FBFLDFMFFOH_rar;
			data.INDDJNMPONH_type = array[i].GBJFNGCDKPM_typ;
			CDENCMNHNGA_table.Add(data);
		}
		return true;
	}

	// RVA: 0xA01498 Offset: 0xA01498 VA: 0xA01498 Slot: 10
	public override bool IIEMACPEEBJ_Deserialize(EDOHBJAPLPF_JsonData OILEIIEIBHP, int _KAPMOPMDHJE_label)
	{
		return false;
	}

	// RVA: 0xA014A0 Offset: 0xA014A0 VA: 0xA014A0 Slot: 11
	public override uint CAOGDCBPBAN()
	{
		TodoLogger.LogError(TodoLogger.DbIntegrityCheck, "INDEPDKCJDD_ValItem.CAOGDCBPBAN");
		return 0;
	}
}
