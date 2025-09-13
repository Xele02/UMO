
using System.Collections.Generic;

[System.Obsolete("Use GJAEGCMKMEK_MvTicket", true)]
public class GJAEGCMKMEK { }
public class GJAEGCMKMEK_MvTicket : DIHHCBACKGG_DbSection
{
	public class MBCLELGHPJF
	{
		public int EHOIENNDEDH_IdCrypted; // 0x8
		public int ICKOHEDLEFP; // 0xC
		public int HNJHPNPFAAN; // 0x10
		public int GNGNIKNNCNH_MVerCrypted; // 0x14
		public int EAJCFBCHIFB_RarityCrypted; // 0x18

		public int PPFNGGCBJKC { get { return EHOIENNDEDH_IdCrypted ^ FBGGEFFJJHB_xor; } set { EHOIENNDEDH_IdCrypted = value ^ FBGGEFFJJHB_xor; } } //0xAA8994 DEMEPMAEJOO 0xAA84E8 HIGKAIDMOKN
		public int JBGEEPFKIGG { get { return ICKOHEDLEFP ^ FBGGEFFJJHB_xor; } set { ICKOHEDLEFP = value ^ FBGGEFFJJHB_xor; } } //0xAA8A2C OLOCMINKGON 0xAA8584 ABAFHIBFKCE
		public int PLALNIIBLOF_Enabled { get { return HNJHPNPFAAN ^ FBGGEFFJJHB_xor; } set { HNJHPNPFAAN = value ^ FBGGEFFJJHB_xor; } } //0xAA8AC4 JPCJNLHHIPE 0xAA8620 JJFJNEJLBDG
		public int IJEKNCDIIAE { get { return GNGNIKNNCNH_MVerCrypted ^ FBGGEFFJJHB_xor; } set { GNGNIKNNCNH_MVerCrypted = value ^ FBGGEFFJJHB_xor; } } //0xAA8B5C KJIMMIBDCIL 0xAA86BC DMEGNOKIKCD
		public int EKLIPGELKCL_Rarity { get { return EAJCFBCHIFB_RarityCrypted ^ FBGGEFFJJHB_xor; } set { EAJCFBCHIFB_RarityCrypted = value ^ FBGGEFFJJHB_xor; } } //0xAA8BF4 OEEHBGECGKL 0xAA8758 GHLMHLJJBIG

		//// RVA: 0xAA88E0 Offset: 0xAA88E0 VA: 0xAA88E0
		//public uint CAOGDCBPBAN() { }
	}

	public const int FKDHNFPDEBD = 1;
	public static int FBGGEFFJJHB_xor = 0xb516d; // 0x0
	public List<MBCLELGHPJF> CDENCMNHNGA_table = new List<MBCLELGHPJF>(); // 0x20

	// RVA: 0xAA80DC Offset: 0xAA80DC VA: 0xAA80DC
	public GJAEGCMKMEK_MvTicket()
	{
		JIKKNHIAEKG_BlockName = "";
		LNIMEIMBCMF = false;
		LMHMIIKCGPE = 63;
	}

	// RVA: 0xAA81D4 Offset: 0xAA81D4 VA: 0xAA81D4 Slot: 8
	protected override void KMBPACJNEOF()
	{
		CDENCMNHNGA_table.Clear();
	}

	// RVA: 0xAA824C Offset: 0xAA824C VA: 0xAA824C Slot: 9
	public override bool IIEMACPEEBJ(byte[] _DBBGALAPFGC_Data)
	{
		INAAHCCMEGE parser = INAAHCCMEGE.HEGEKFMJNCC(_DBBGALAPFGC_Data);
		CACJOBCOKLG[] array = parser.BMMFEIFJOHD;
		for(int i = 0; i < array.Length; i++)
		{
			MBCLELGHPJF data = new MBCLELGHPJF();
			data.PPFNGGCBJKC = (int)array[i].PPFNGGCBJKC;
			data.JBGEEPFKIGG = (int)array[i].JBGEEPFKIGG;
			data.PLALNIIBLOF_Enabled = (int)array[i].PLALNIIBLOF;
			data.IJEKNCDIIAE = array[i].IJEKNCDIIAE;
			data.EKLIPGELKCL_Rarity = (int)array[i].FBFLDFMFFOH;
			CDENCMNHNGA_table.Add(data);
		}
		return true;
	}

	// RVA: 0xAA87F4 Offset: 0xAA87F4 VA: 0xAA87F4 Slot: 10
	public override bool IIEMACPEEBJ(EDOHBJAPLPF_JsonData OILEIIEIBHP, int KAPMOPMDHJE)
	{
		return false;
	}

	// RVA: 0xAA87FC Offset: 0xAA87FC VA: 0xAA87FC Slot: 11
	public override uint CAOGDCBPBAN()
	{
		TodoLogger.LogError(TodoLogger.DbIntegrityCheck, "GJAEGCMKMEK_MvTicket.CAOGDCBPBAN");
		return 0;
	}
}
