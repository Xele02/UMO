
using System.Collections.Generic;

[System.Obsolete("Use IHGBPAJMJFK_Emblem", true)]
public class IHGBPAJMJFK { }
public class IHGBPAJMJFK_Emblem : DIHHCBACKGG_DbSection
{
	public class AKJPPHFGEFG_EmblemInfo
	{
		public int EHOIENNDEDH_IdCrypted; // 0x8
		public int MJMPPEKDALP_PicCrypted; // 0xC
		public int HNJHPNPFAAN_EnCrypted; // 0x10
		public int JDIJODDBCPK_OdrCrypted; // 0x14
		public int EAJCFBCHIFB_RarityCrypted; // 0x18

		public int PPFNGGCBJKC_Id { get { return EHOIENNDEDH_IdCrypted ^ FBGGEFFJJHB_xor; } set { EHOIENNDEDH_IdCrypted = value ^ FBGGEFFJJHB_xor; } } //0x11FB578 DEMEPMAEJOO 0x11FA794 HIGKAIDMOKN
		public int HANMDEBPBHG_Pic { get { return MJMPPEKDALP_PicCrypted ^ FBGGEFFJJHB_xor; } set { MJMPPEKDALP_PicCrypted = value ^ FBGGEFFJJHB_xor; } } //0x11FB474 EFGGIMOPNMG 0x11FAFD8 PNGGKPFDKMA
		public int PLALNIIBLOF_En { get { return HNJHPNPFAAN_EnCrypted ^ FBGGEFFJJHB_xor; } set { HNJHPNPFAAN_EnCrypted = value ^ FBGGEFFJJHB_xor; } } //0x11FB610 JPCJNLHHIPE 0x11FB074 JJFJNEJLBDG
		public int FPOMEEJFBIG_Order { get { return JDIJODDBCPK_OdrCrypted ^ FBGGEFFJJHB_xor; } set { JDIJODDBCPK_OdrCrypted = value ^ FBGGEFFJJHB_xor; } } //0x11FB6A8 OEEBAHNAPEC 0x11FB110 BEHAPLPPLNE
		public int EKLIPGELKCL_Rarity { get { return EAJCFBCHIFB_RarityCrypted ^ FBGGEFFJJHB_xor; } set { EAJCFBCHIFB_RarityCrypted = value ^ FBGGEFFJJHB_xor; } } //0x11FB740 OEEHBGECGKL 0x11FB1AC GHLMHLJJBIG

		// RVA: 0x11FB7D8 Offset: 0x11FB7D8 VA: 0x11FB7D8
		//public void KHEKNNFCAOI(EDOHBJAPLPF_JsonData OBHAFLMHAKG) { }

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
	protected override void KMBPACJNEOF()
	{
		CDENCMNHNGA_table.Clear();
		for(int i = 0; i < 1000; i++)
		{
			AKJPPHFGEFG_EmblemInfo data = new AKJPPHFGEFG_EmblemInfo();
			data.PPFNGGCBJKC_Id = i + 1;
			CDENCMNHNGA_table.Add(data);
		}
	}

	// RVA: 0x11FA830 Offset: 0x11FA830 VA: 0x11FA830 Slot: 9
	public override bool IIEMACPEEBJ(byte[] _DBBGALAPFGC_Data)
	{
		IMLKIIBJABA parser = IMLKIIBJABA.HEGEKFMJNCC(_DBBGALAPFGC_Data);
		return NPFMJICELDE(parser);
	}

	// RVA: 0x11FABC0 Offset: 0x11FABC0 VA: 0x11FABC0 Slot: 10
	public override bool IIEMACPEEBJ(EDOHBJAPLPF_JsonData OILEIIEIBHP, int KAPMOPMDHJE)
	{
		TodoLogger.LogError(TodoLogger.DbJson, "Emblem IIEMACPEEBJ");
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
			CDENCMNHNGA_table[i].PPFNGGCBJKC_Id = (int)array[i].PPFNGGCBJKC;
			CDENCMNHNGA_table[i].HANMDEBPBHG_Pic = (int)array[i].HANMDEBPBHG;
			CDENCMNHNGA_table[i].PLALNIIBLOF_En = (int)array[i].PLALNIIBLOF;
			CDENCMNHNGA_table[i].FPOMEEJFBIG_Order = (int)array[i].FPOMEEJFBIG;
			CDENCMNHNGA_table[i].EKLIPGELKCL_Rarity = (int)array[i].FBFLDFMFFOH;
		}
		return true;
	}

	//// RVA: 0x11FABC4 Offset: 0x11FABC4 VA: 0x11FABC4
	//private bool NPFMJICELDE(EDOHBJAPLPF OILEIIEIBHP, int KAPMOPMDHJE) { }

	// RVA: 0x11FB248 Offset: 0x11FB248 VA: 0x11FB248 Slot: 11
	public override uint CAOGDCBPBAN()
	{
		TodoLogger.LogError(TodoLogger.DbIntegrityCheck, "IHGBPAJMJFK_Emblem.CAOGDCBPBAN");
		return 0;
	}

	//// RVA: 0x11FB384 Offset: 0x11FB384 VA: 0x11FB384
	public bool MNFCLPNLFIJ_IsEmblemAvaiable(int _ABLOIBMGLFD_EmId)
	{
		if(_ABLOIBMGLFD_EmId > 0 && _ABLOIBMGLFD_EmId <= CDENCMNHNGA_table.Count)
		{
			return CDENCMNHNGA_table[_ABLOIBMGLFD_EmId - 1].HANMDEBPBHG_Pic > 0;
		}
		return false;
	}
}
