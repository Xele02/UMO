
using System.Collections.Generic;
using XeSys;

[System.Obsolete("Use HHPEMHHCKBE_Compo", true)]
public class HHPEMHHCKBE { }
[UMOClass()]
public class HHPEMHHCKBE_Compo : DIHHCBACKGG_DbSection
{
	[UMOClass()]
	public class MLMDKHBFOJM
	{
		public int FBGGEFFJJHB_xor = 0x3fb377; // 0x8
		private int EHOIENNDEDH_IdCrypted; // 0xC
		public int[] OGEBLOHMGAM_Crypted; // 0x10
		public int[] AHGCGHAAHOO_ItemIdCrypted; // 0x14
		public int EAJCFBCHIFB_RarityCrypted; // 0x18

		[UMOMember()]
		public int PPFNGGCBJKC_id { get { return EHOIENNDEDH_IdCrypted ^ FBGGEFFJJHB_xor; } set { EHOIENNDEDH_IdCrypted = value ^ FBGGEFFJJHB_xor; } } //0x18337DC DEMEPMAEJOO_get_id 0x1833654 HIGKAIDMOKN_set_id
		[UMOMember()]
		public int EKLIPGELKCL_Rarity { get { return EAJCFBCHIFB_RarityCrypted ^ FBGGEFFJJHB_xor; } set { EAJCFBCHIFB_RarityCrypted = value ^ FBGGEFFJJHB_xor; } } //0x18337EC OEEHBGECGKL_get_Rarity 0x1833664 GHLMHLJJBIG_set_Rarity

		// For doc
		[UMOMember()]
		public int[] ItemIds { get { 
			int[] Res = new int[AHGCGHAAHOO_ItemIdCrypted.Length];
			for(int i = 0; i < AHGCGHAAHOO_ItemIdCrypted.Length; i++)
				Res[i] = CBLLFCGEJAI(i);
			return Res;
		} }
		[UMOMember()]
		public int[] ItemCount { get { 
			int[] Res = new int[OGEBLOHMGAM_Crypted.Length];
			for(int i = 0; i < OGEBLOHMGAM_Crypted.Length; i++)
				Res[i] = HBJMCLGKLBA(i);
			return Res;
		} }

		//// RVA: 0x18337FC Offset: 0x18337FC VA: 0x18337FC
		public int JCJGGHGIKIJ()
		{
			if(AHGCGHAAHOO_ItemIdCrypted != null)
				return AHGCGHAAHOO_ItemIdCrypted.Length;
			return 0;
		}

		//// RVA: 0x1833810 Offset: 0x1833810 VA: 0x1833810
		public int CBLLFCGEJAI(int _OIPCCBHIKIA_index)
		{
			return AHGCGHAAHOO_ItemIdCrypted[_OIPCCBHIKIA_index] ^ FBGGEFFJJHB_xor;
		}

		//// RVA: 0x1833864 Offset: 0x1833864 VA: 0x1833864
		public int HBJMCLGKLBA(int _OIPCCBHIKIA_index)
		{
			return OGEBLOHMGAM_Crypted[_OIPCCBHIKIA_index] ^ FBGGEFFJJHB_xor;
		}

		//// RVA: 0x1833760 Offset: 0x1833760 VA: 0x1833760
		//public uint CAOGDCBPBAN() { }
	}

	[UMOMember()]
	public List<MLMDKHBFOJM> CDENCMNHNGA_table = new List<MLMDKHBFOJM>(); // 0x20

	// RVA: 0x18330C0 Offset: 0x18330C0 VA: 0x18330C0
	public HHPEMHHCKBE_Compo()
	{
		JIKKNHIAEKG_BlockName = "compo";
		LNIMEIMBCMF = false;
		LMHMIIKCGPE = 10;
	}

	// RVA: 0x18331B8 Offset: 0x18331B8 VA: 0x18331B8 Slot: 8
	protected override void KMBPACJNEOF_Reset()
	{
		CDENCMNHNGA_table.Clear();
	}

	// RVA: 0x1833230 Offset: 0x1833230 VA: 0x1833230 Slot: 9
	public override bool IIEMACPEEBJ_Deserialize(byte[] _DBBGALAPFGC_bytes)
	{
		FPDHPIEBAHD parser = FPDHPIEBAHD.HEGEKFMJNCC(_DBBGALAPFGC_bytes);
		AKJNKDNCCCC[] array = parser.LIFDACJBDBA;
		int k = (int)Utility.GetCurrentUnixTime();
		k = k * 0x761fed + 5;
		for (int i = 0; i < array.Length; i++)
		{
			MLMDKHBFOJM data = new MLMDKHBFOJM();
			data.FBGGEFFJJHB_xor = k;
			data.PPFNGGCBJKC_id = (int)array[i].PPFNGGCBJKC_id;
			data.EKLIPGELKCL_Rarity = array[i].EKLIPGELKCL_Rarity;
			int[] l1 = array[i].AIHOJKFNEEN_itm;
			uint[] l2 = array[i].BFINGCJHOHI_cnt;
			data.AHGCGHAAHOO_ItemIdCrypted = new int[l1.Length];
			data.OGEBLOHMGAM_Crypted = new int[l2.Length];
			for(int j = 0; j < l1.Length; j++)
			{
				data.AHGCGHAAHOO_ItemIdCrypted[j] = data.FBGGEFFJJHB_xor ^ l1[j];
				data.OGEBLOHMGAM_Crypted[j] = data.FBGGEFFJJHB_xor ^ (int)l2[j];
			}
			CDENCMNHNGA_table.Add(data);
		}
		return true;
	}

	// RVA: 0x1833674 Offset: 0x1833674 VA: 0x1833674 Slot: 10
	public override bool IIEMACPEEBJ_Deserialize(EDOHBJAPLPF_JsonData OILEIIEIBHP, int _KAPMOPMDHJE_label)
	{
		return false;
	}

	// RVA: 0x183367C Offset: 0x183367C VA: 0x183367C Slot: 11
	public override uint CAOGDCBPBAN()
	{
		TodoLogger.LogError(TodoLogger.DbIntegrityCheck, "HHPEMHHCKBE_Compo.IIEMACPEEBJ_Deserialize");
		return 0;
	}
}
