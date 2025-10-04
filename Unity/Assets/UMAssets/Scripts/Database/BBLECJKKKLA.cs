using System.Collections.Generic;

[System.Obsolete("Use BBLECJKKKLA_DecoSetItem", true)]
public class BBLECJKKKLA { }
public class BBLECJKKKLA_DecoSetItem : DIHHCBACKGG_DbSection
{
	public class GJBPBKNHLHC_DecoSetItemInfo
	{
		public int EHOIENNDEDH_IdCrypted; // 0x8
		public int HNJHPNPFAAN_EnabledCrypted; // 0xC
		public int EAJCFBCHIFB_RarityCrypted; // 0x10
		public int IPAKEGGICML_SerieCrypted; // 0x14
		public int MMDBOPCEKCJ; // 0x18
		public int HJCJMAONOMH; // 0x1C
		public int HAIFEBPOPEF; // 0x20
		public int GJFLAHAGDKG; // 0x24
		public int[] OMALMJLHABC_SetContent; // 0x28

		public int PPFNGGCBJKC_id { get { return EHOIENNDEDH_IdCrypted ^ FBGGEFFJJHB_xor; } set { EHOIENNDEDH_IdCrypted = value ^ FBGGEFFJJHB_xor; } } //0xF2C094 DEMEPMAEJOO_get_id 0xF2BA2C HIGKAIDMOKN_set_id
		public int PLALNIIBLOF_en { get { return HNJHPNPFAAN_EnabledCrypted ^ FBGGEFFJJHB_xor; } set { HNJHPNPFAAN_EnabledCrypted = value ^ FBGGEFFJJHB_xor; } } //0xF2C12C JPCJNLHHIPE_get_en 0xF2BB64 JJFJNEJLBDG_set_en
		public int EKLIPGELKCL_Rarity { get { return EAJCFBCHIFB_RarityCrypted ^ FBGGEFFJJHB_xor; } set { EAJCFBCHIFB_RarityCrypted = value ^ FBGGEFFJJHB_xor; } } //0xF2C1C4 OEEHBGECGKL_get_Rarity 0xF2BAC8 GHLMHLJJBIG_set_Rarity
		public int CPKMLLNADLJ_Serie { get { return IPAKEGGICML_SerieCrypted ^ FBGGEFFJJHB_xor; } set { IPAKEGGICML_SerieCrypted = value ^ FBGGEFFJJHB_xor; } } //0xF2C25C BJPJMGHCDNO_get_Serie 0xF2BC00 BPKIOJBKNBP_set_Serie
		public int MLMCEBBDJOE { get { return MMDBOPCEKCJ ^ FBGGEFFJJHB_xor; } set { MMDBOPCEKCJ = value ^ FBGGEFFJJHB_xor; } } //0xF2C2F4 IGMHCODOFKG_get_ 0xF2BC9C IIIGDLGGEGK_set_
		public int ODNILEDOAIP { get { return HJCJMAONOMH ^ FBGGEFFJJHB_xor; } set { HJCJMAONOMH = value ^ FBGGEFFJJHB_xor; } } //0xF2C38C GNKPMBBAJHI_get_ 0xF2BD38 PPMACIMALAC_set_
		public int NPPGKNGIFGK_price { get { return HAIFEBPOPEF ^ FBGGEFFJJHB_xor; } set { HAIFEBPOPEF = value ^ FBGGEFFJJHB_xor; } } //0xF2C424 FLMDBAFHDNJ_get_price 0xF2BDD4 DIHIEJPOCOJ_set_price
		public int KEJMJPHFFOJ_Max { get { return GJFLAHAGDKG ^ FBGGEFFJJHB_xor; } set { GJFLAHAGDKG = value ^ FBGGEFFJJHB_xor; } } //0xF2C4BC FMNMLNIALNE_get_Max 0xF2BE70 GBEPCBPOGDB_set_Max

		// // RVA: 0xF2C554 Offset: 0xF2C554 VA: 0xF2C554
		public int FKNBLDPIPMC_GetItemCode(int _BMBBDIAEOMP_i)
		{
			return OMALMJLHABC_SetContent[_BMBBDIAEOMP_i * 2] ^ FBGGEFFJJHB_xor;
		}

		// // RVA: 0xF2C628 Offset: 0xF2C628 VA: 0xF2C628
		public int NKOHMLHLJGL_GetItemCount(int _BMBBDIAEOMP_i)
		{
			return OMALMJLHABC_SetContent[_BMBBDIAEOMP_i * 2 + 1] ^ FBGGEFFJJHB_xor;
		}

		// // RVA: 0xF2C700 Offset: 0xF2C700 VA: 0xF2C700
		public int JJBNDDDGEAN_GetNumItems()
		{
			return OMALMJLHABC_SetContent.Length / 2;
		}

		// // RVA: 0xF2BFF8 Offset: 0xF2BFF8 VA: 0xF2BFF8
		// public uint CAOGDCBPBAN() { }
	}

	public const int ICGIBJBALLH = 300;
	public static int FBGGEFFJJHB_xor = 0x181b5; // 0x0
	public List<GJBPBKNHLHC_DecoSetItemInfo> CDENCMNHNGA_table = new List<GJBPBKNHLHC_DecoSetItemInfo>(300); // 0x20

	// // RVA: 0xF2B3A0 Offset: 0xF2B3A0 VA: 0xF2B3A0
	public BBLECJKKKLA_DecoSetItem()
    {
		JIKKNHIAEKG_BlockName = "";
		LNIMEIMBCMF = false;
		LMHMIIKCGPE = 16;
    }

	// // RVA: 0xF2B498 Offset: 0xF2B498 VA: 0xF2B498 Slot: 8
	protected override void KMBPACJNEOF_Reset()
    {
		CDENCMNHNGA_table.Clear();
    }

	// // RVA: 0xF2B510 Offset: 0xF2B510 VA: 0xF2B510 Slot: 9
	public override bool IIEMACPEEBJ_Deserialize(byte[] _DBBGALAPFGC_bytes)
    {
		MDMEBHPAKIH parser = MDMEBHPAKIH.HEGEKFMJNCC(_DBBGALAPFGC_bytes);
		DDHCKMFAKFA[] array = parser.NFBMFDPFHCL;
		for(int i = 0; i < array.Length; i++)
		{
			GJBPBKNHLHC_DecoSetItemInfo data = new GJBPBKNHLHC_DecoSetItemInfo();
			data.PPFNGGCBJKC_id = array[i].PPFNGGCBJKC_id;
			data.EKLIPGELKCL_Rarity = array[i].FBFLDFMFFOH_rar;
			data.PLALNIIBLOF_en = JKAECBCNHAN_IsEnabled(array[i].IJEKNCDIIAE_mver, array[i].PLALNIIBLOF_en, 0);
			data.CPKMLLNADLJ_Serie = array[i].CPKMLLNADLJ_Serie;
			data.MLMCEBBDJOE = array[i].MLMCEBBDJOE;
			data.ODNILEDOAIP = array[i].ODNILEDOAIP;
			data.NPPGKNGIFGK_price = array[i].NPPGKNGIFGK_price;
			int[] array2 = array[i].PIPDCAEIBPO;
			data.OMALMJLHABC_SetContent = new int[array2.Length];
			for(int j = 0; j < array2.Length; j++)
			{
				data.OMALMJLHABC_SetContent[j] = array2[j] ^ FBGGEFFJJHB_xor;
			}
			data.KEJMJPHFFOJ_Max = array[i].KEJMJPHFFOJ_Max;
			CDENCMNHNGA_table.Add(data);
		}
		return true;
    }

	// // RVA: 0xF2BF0C Offset: 0xF2BF0C VA: 0xF2BF0C Slot: 10
	public override bool IIEMACPEEBJ_Deserialize(EDOHBJAPLPF_JsonData OILEIIEIBHP, int _KAPMOPMDHJE_label)
	{
		return false;
	}

	// // RVA: 0xF2BF14 Offset: 0xF2BF14 VA: 0xF2BF14 Slot: 11
	public override uint CAOGDCBPBAN()
	{
		TodoLogger.LogError(TodoLogger.DbIntegrityCheck, "BBLECJKKKLA_DecoSetItem.CAOGDCBPBAN");
		return 0;
	}
}
