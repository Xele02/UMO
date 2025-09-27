
using System.Collections.Generic;

[System.Obsolete("Use IHGBPAJMJFK_Emblem", true)]
public class IHGBPAJMJFK { }
public class IHGBPAJMJFK_Emblem : DIHHCBACKGG_DbSection
{
	public class AKJPPHFGEFG_EmblemInfo
	{
		public int EHOIENNDEDH_IdCrypted; // 0x8
		public int MJMPPEKDALP_PicCrypted; // 0xC
		public int HNJHPNPFAAN_EnabledCrypted; // 0x10
		public int JDIJODDBCPK_OderCrypted; // 0x14
		public int EAJCFBCHIFB_RarityCrypted; // 0x18

		public int PPFNGGCBJKC_id { get { return EHOIENNDEDH_IdCrypted ^ FBGGEFFJJHB_xor; } set { EHOIENNDEDH_IdCrypted = value ^ FBGGEFFJJHB_xor; } } //0x11FB578 DEMEPMAEJOO 0x11FA794 HIGKAIDMOKN
		public int HANMDEBPBHG_pic { get { return MJMPPEKDALP_PicCrypted ^ FBGGEFFJJHB_xor; } set { MJMPPEKDALP_PicCrypted = value ^ FBGGEFFJJHB_xor; } } //0x11FB474 EFGGIMOPNMG 0x11FAFD8 PNGGKPFDKMA
		public int PLALNIIBLOF_en { get { return HNJHPNPFAAN_EnabledCrypted ^ FBGGEFFJJHB_xor; } set { HNJHPNPFAAN_EnabledCrypted = value ^ FBGGEFFJJHB_xor; } } //0x11FB610 JPCJNLHHIPE 0x11FB074 JJFJNEJLBDG
		// Order
		public int FPOMEEJFBIG_odr { get { return JDIJODDBCPK_OderCrypted ^ FBGGEFFJJHB_xor; } set { JDIJODDBCPK_OderCrypted = value ^ FBGGEFFJJHB_xor; } } //0x11FB6A8 OEEBAHNAPEC 0x11FB110 BEHAPLPPLNE
		public int EKLIPGELKCL_Rarity { get { return EAJCFBCHIFB_RarityCrypted ^ FBGGEFFJJHB_xor; } set { EAJCFBCHIFB_RarityCrypted = value ^ FBGGEFFJJHB_xor; } } //0x11FB740 OEEHBGECGKL 0x11FB1AC GHLMHLJJBIG

		// RVA: 0x11FB7D8 Offset: 0x11FB7D8 VA: 0x11FB7D8
		//public void KHEKNNFCAOI_Init(EDOHBJAPLPF_JsonData OBHAFLMHAKG) { }
		//PPFNGGCBJKC_id = PPFNGGCBJKC_id
		//HANMDEBPBHG_pic = HANMDEBPBHG_pic
		//PLALNIIBLOF_en = PLALNIIBLOF_en
		//FPOMEEJFBIG_odr = FPOMEEJFBIG_odr
		//EKLIPGELKCL_Rarity = FBFLDFMFFOH_rar

		// RVA: 0x11FB334 Offset: 0x11FB334 VA: 0x11FB334
		//public uint CAOGDCBPBAN() { }
	}

	public static int FBGGEFFJJHB_xor = 0xb45b5; // 0x0

	public List<AKJPPHFGEFG_EmblemInfo> CDENCMNHNGA_table { get; private set; } // 0x20 GIODFKFCBMO JDMECLDHNOF ILHOADLEJPB

	// RVA: 0x11FA5A4 Offset: 0x11FA5A4 VA: 0x11FA5A4
	public IHGBPAJMJFK_Emblem()
	{
		JIKKNHIAEKG_BlockName = "";
		LNIMEIMBCMF = false;
		LMHMIIKCGPE = 22;
		CDENCMNHNGA_table = new List<AKJPPHFGEFG_EmblemInfo>();
	}

	// RVA: 0x11FA698 Offset: 0x11FA698 VA: 0x11FA698 Slot: 8
	protected override void KMBPACJNEOF_Reset()
	{
		CDENCMNHNGA_table.Clear();
		for(int i = 0; i < 1000; i++)
		{
			AKJPPHFGEFG_EmblemInfo data = new AKJPPHFGEFG_EmblemInfo();
			data.PPFNGGCBJKC_id = i + 1;
			CDENCMNHNGA_table.Add(data);
		}
	}

	// RVA: 0x11FA830 Offset: 0x11FA830 VA: 0x11FA830 Slot: 9
	public override bool IIEMACPEEBJ_Deserialize(byte[] _DBBGALAPFGC_bytes)
	{
		IMLKIIBJABA parser = IMLKIIBJABA.HEGEKFMJNCC(_DBBGALAPFGC_bytes);
		return NPFMJICELDE(parser);
	}

	// RVA: 0x11FABC0 Offset: 0x11FABC0 VA: 0x11FABC0 Slot: 10
	public override bool IIEMACPEEBJ_Deserialize(EDOHBJAPLPF_JsonData OILEIIEIBHP, int _KAPMOPMDHJE_label)
	{
		TodoLogger.LogError(TodoLogger.DbJson, "Emblem IIEMACPEEBJ_Deserialize");
		return false;
	}

	//// RVA: 0x11FA858 Offset: 0x11FA858 VA: 0x11FA858
	private bool NPFMJICELDE(IMLKIIBJABA NJKEENAJBHO)
	{
		HNJNEMJIBKI[] array = NJKEENAJBHO.BDDHMELPABN;
		if(array.Length > 1000)
			return false;
		for(int i = 0; i < array.Length; i++)
		{
			CDENCMNHNGA_table[i].PPFNGGCBJKC_id = (int)array[i].PPFNGGCBJKC_id;
			CDENCMNHNGA_table[i].HANMDEBPBHG_pic = (int)array[i].HANMDEBPBHG_pic;
			CDENCMNHNGA_table[i].PLALNIIBLOF_en = (int)array[i].PLALNIIBLOF_en;
			CDENCMNHNGA_table[i].FPOMEEJFBIG_odr = (int)array[i].FPOMEEJFBIG_odr;
			CDENCMNHNGA_table[i].EKLIPGELKCL_Rarity = (int)array[i].FBFLDFMFFOH_rar;
		}
		return true;
	}

	//// RVA: 0x11FABC4 Offset: 0x11FABC4 VA: 0x11FABC4
	//private bool NPFMJICELDE(EDOHBJAPLPF_JsonData OILEIIEIBHP, int _KAPMOPMDHJE_label) { }
	//PPFNGGCBJKC_id = PPFNGGCBJKC_id
	//HANMDEBPBHG_pic = HANMDEBPBHG_pic
	//PLALNIIBLOF_en = PLALNIIBLOF_en
	//FPOMEEJFBIG_odr = FPOMEEJFBIG_odr
	//EKLIPGELKCL_Rarity = FBFLDFMFFOH_rar

	// RVA: 0x11FB248 Offset: 0x11FB248 VA: 0x11FB248 Slot: 11
	public override uint CAOGDCBPBAN()
	{
		TodoLogger.LogError(TodoLogger.DbIntegrityCheck, "IHGBPAJMJFK_Emblem.CAOGDCBPBAN");
		return 0;
	}

	//// RVA: 0x11FB384 Offset: 0x11FB384 VA: 0x11FB384
	public bool MNFCLPNLFIJ_IsEmblemAvaiable(int _ABLOIBMGLFD_em_id)
	{
		if(_ABLOIBMGLFD_em_id > 0 && _ABLOIBMGLFD_em_id <= CDENCMNHNGA_table.Count)
		{
			return CDENCMNHNGA_table[_ABLOIBMGLFD_em_id - 1].HANMDEBPBHG_pic > 0;
		}
		return false;
	}
}
