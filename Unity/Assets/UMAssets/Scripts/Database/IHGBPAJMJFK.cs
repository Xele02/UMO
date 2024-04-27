
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
		public int EAJCFBCHIFB_RarCrypted; // 0x18

		public int PPFNGGCBJKC_Id { get { return EHOIENNDEDH_IdCrypted ^ FBGGEFFJJHB; } set { EHOIENNDEDH_IdCrypted = value ^ FBGGEFFJJHB; } } //0x11FB578 DEMEPMAEJOO 0x11FA794 HIGKAIDMOKN
		public int HANMDEBPBHG_Pic { get { return MJMPPEKDALP_PicCrypted ^ FBGGEFFJJHB; } set { MJMPPEKDALP_PicCrypted = value ^ FBGGEFFJJHB; } } //0x11FB474 EFGGIMOPNMG 0x11FAFD8 PNGGKPFDKMA
		public int PLALNIIBLOF_En { get { return HNJHPNPFAAN_EnCrypted ^ FBGGEFFJJHB; } set { HNJHPNPFAAN_EnCrypted = value ^ FBGGEFFJJHB; } } //0x11FB610 JPCJNLHHIPE 0x11FB074 JJFJNEJLBDG
		public int FPOMEEJFBIG_Odr { get { return JDIJODDBCPK_OdrCrypted ^ FBGGEFFJJHB; } set { JDIJODDBCPK_OdrCrypted = value ^ FBGGEFFJJHB; } } //0x11FB6A8 OEEBAHNAPEC 0x11FB110 BEHAPLPPLNE
		public int EKLIPGELKCL_Rar { get { return EAJCFBCHIFB_RarCrypted ^ FBGGEFFJJHB; } set { EAJCFBCHIFB_RarCrypted = value ^ FBGGEFFJJHB; } } //0x11FB740 OEEHBGECGKL 0x11FB1AC GHLMHLJJBIG

		// RVA: 0x11FB7D8 Offset: 0x11FB7D8 VA: 0x11FB7D8
		//public void KHEKNNFCAOI(EDOHBJAPLPF_JsonData OBHAFLMHAKG) { }

		// RVA: 0x11FB334 Offset: 0x11FB334 VA: 0x11FB334
		//public uint CAOGDCBPBAN() { }
	}

	public static int FBGGEFFJJHB = 0xb45b5; // 0x0

	public List<AKJPPHFGEFG_EmblemInfo> CDENCMNHNGA_EmblemList { get; private set; } // 0x20 GIODFKFCBMO JDMECLDHNOF ILHOADLEJPB

	// RVA: 0x11FA5A4 Offset: 0x11FA5A4 VA: 0x11FA5A4
	public IHGBPAJMJFK_Emblem()
	{
		JIKKNHIAEKG_BlockName = "";
		LNIMEIMBCMF = false;
		LMHMIIKCGPE = 22;
		CDENCMNHNGA_EmblemList = new List<AKJPPHFGEFG_EmblemInfo>();
	}

	// RVA: 0x11FA698 Offset: 0x11FA698 VA: 0x11FA698 Slot: 8
	protected override void KMBPACJNEOF()
	{
		CDENCMNHNGA_EmblemList.Clear();
		for(int i = 0; i < 1000; i++)
		{
			AKJPPHFGEFG_EmblemInfo data = new AKJPPHFGEFG_EmblemInfo();
			data.PPFNGGCBJKC_Id = i + 1;
			CDENCMNHNGA_EmblemList.Add(data);
		}
	}

	// RVA: 0x11FA830 Offset: 0x11FA830 VA: 0x11FA830 Slot: 9
	public override bool IIEMACPEEBJ(byte[] DBBGALAPFGC)
	{
		IMLKIIBJABA parser = IMLKIIBJABA.HEGEKFMJNCC(DBBGALAPFGC);
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
			CDENCMNHNGA_EmblemList[i].PPFNGGCBJKC_Id = (int)array[i].PPFNGGCBJKC;
			CDENCMNHNGA_EmblemList[i].HANMDEBPBHG_Pic = (int)array[i].HANMDEBPBHG;
			CDENCMNHNGA_EmblemList[i].PLALNIIBLOF_En = (int)array[i].PLALNIIBLOF;
			CDENCMNHNGA_EmblemList[i].FPOMEEJFBIG_Odr = (int)array[i].FPOMEEJFBIG;
			CDENCMNHNGA_EmblemList[i].EKLIPGELKCL_Rar = (int)array[i].FBFLDFMFFOH;
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
	public bool MNFCLPNLFIJ_IsEmblemAvaiable(int ABLOIBMGLFD)
	{
		if(ABLOIBMGLFD > 0 && ABLOIBMGLFD <= CDENCMNHNGA_EmblemList.Count)
		{
			return CDENCMNHNGA_EmblemList[ABLOIBMGLFD - 1].HANMDEBPBHG_Pic > 0;
		}
		return false;
	}
}
