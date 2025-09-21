
using System.Collections.Generic;

[System.Obsolete("Use GJAEGCMKMEK_MvTicket", true)]
public class GJAEGCMKMEK { }
public class GJAEGCMKMEK_MvTicket : DIHHCBACKGG_DbSection
{
	public class MBCLELGHPJF
	{
		public int EHOIENNDEDH_IdCrypted; // 0x8
		public int ICKOHEDLEFP_ValueCrypted; // 0xC
		public int HNJHPNPFAAN_EnabledCrypted; // 0x10
		public int GNGNIKNNCNH_MVerCrypted; // 0x14
		public int EAJCFBCHIFB_RarityCrypted; // 0x18

		public int PPFNGGCBJKC_id { get { return EHOIENNDEDH_IdCrypted ^ FBGGEFFJJHB_xor; } set { EHOIENNDEDH_IdCrypted = value ^ FBGGEFFJJHB_xor; } } //0xAA8994 DEMEPMAEJOO 0xAA84E8 HIGKAIDMOKN
		public int JBGEEPFKIGG_Value { get { return ICKOHEDLEFP_ValueCrypted ^ FBGGEFFJJHB_xor; } set { ICKOHEDLEFP_ValueCrypted = value ^ FBGGEFFJJHB_xor; } } //0xAA8A2C OLOCMINKGON 0xAA8584 ABAFHIBFKCE
		public int PLALNIIBLOF_en { get { return HNJHPNPFAAN_EnabledCrypted ^ FBGGEFFJJHB_xor; } set { HNJHPNPFAAN_EnabledCrypted = value ^ FBGGEFFJJHB_xor; } } //0xAA8AC4 JPCJNLHHIPE 0xAA8620 JJFJNEJLBDG
		public int IJEKNCDIIAE_MVer { get { return GNGNIKNNCNH_MVerCrypted ^ FBGGEFFJJHB_xor; } set { GNGNIKNNCNH_MVerCrypted = value ^ FBGGEFFJJHB_xor; } } //0xAA8B5C KJIMMIBDCIL 0xAA86BC DMEGNOKIKCD
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
	protected override void KMBPACJNEOF_Reset()
	{
		CDENCMNHNGA_table.Clear();
	}

	// RVA: 0xAA824C Offset: 0xAA824C VA: 0xAA824C Slot: 9
	public override bool IIEMACPEEBJ_Deserialize(byte[] _DBBGALAPFGC_Data)
	{
		INAAHCCMEGE parser = INAAHCCMEGE.HEGEKFMJNCC(_DBBGALAPFGC_Data);
		CACJOBCOKLG[] array = parser.BMMFEIFJOHD;
		for(int i = 0; i < array.Length; i++)
		{
			MBCLELGHPJF data = new MBCLELGHPJF();
			data.PPFNGGCBJKC_id = (int)array[i].PPFNGGCBJKC;
			data.JBGEEPFKIGG_Value = (int)array[i].JBGEEPFKIGG;
			data.PLALNIIBLOF_en = (int)array[i].PLALNIIBLOF;
			data.IJEKNCDIIAE_MVer = array[i].IJEKNCDIIAE;
			data.EKLIPGELKCL_Rarity = (int)array[i].FBFLDFMFFOH;
			CDENCMNHNGA_table.Add(data);
		}
		return true;
	}

	// RVA: 0xAA87F4 Offset: 0xAA87F4 VA: 0xAA87F4 Slot: 10
	public override bool IIEMACPEEBJ_Deserialize(EDOHBJAPLPF_JsonData OILEIIEIBHP, int _KAPMOPMDHJE_label)
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
