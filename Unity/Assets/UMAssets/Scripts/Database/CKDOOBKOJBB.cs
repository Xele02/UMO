
using System.Collections.Generic;

[System.Obsolete("Use CKDOOBKOJBB_RareUpItem", true)]
public class CKDOOBKOJBB { }
public class CKDOOBKOJBB_RareUpItem : DIHHCBACKGG_DbSection
{ 
	public class FEIHMMKMGOF
	{
		public int EHOIENNDEDH_IdCrypted; // 0x8
		public int ICKOHEDLEFP_ValueCrypted; // 0xC
		public int HNJHPNPFAAN_EnabledCrypted; // 0x10
		public int EAJCFBCHIFB_RarityCrypted; // 0x14
		public int HBLLFAILJKH; // 0x18

		public int PPFNGGCBJKC_id { get { return EHOIENNDEDH_IdCrypted ^ FBGGEFFJJHB_xor; } set { EHOIENNDEDH_IdCrypted = value ^ FBGGEFFJJHB_xor; } } //0x107DB94 DEMEPMAEJOO 0x107D6E8 HIGKAIDMOKN
		public int JBGEEPFKIGG_val { get { return ICKOHEDLEFP_ValueCrypted ^ FBGGEFFJJHB_xor; } set { ICKOHEDLEFP_ValueCrypted = value ^ FBGGEFFJJHB_xor; } } //0x107DC2C OLOCMINKGON 0x107D784 ABAFHIBFKCE
		public int PLALNIIBLOF_en { get { return HNJHPNPFAAN_EnabledCrypted ^ FBGGEFFJJHB_xor; } set { HNJHPNPFAAN_EnabledCrypted = value ^ FBGGEFFJJHB_xor; } } //0x107DCC4 JPCJNLHHIPE 0x107D820 JJFJNEJLBDG
		public int EKLIPGELKCL_Rarity { get { return EAJCFBCHIFB_RarityCrypted ^ FBGGEFFJJHB_xor; } set { EAJCFBCHIFB_RarityCrypted = value ^ FBGGEFFJJHB_xor; } } //0x107DD5C OEEHBGECGKL 0x107D8BC GHLMHLJJBIG
		public int EIGNPDFHIJA { get { return HBLLFAILJKH ^ FBGGEFFJJHB_xor; } set { HBLLFAILJKH = value ^ FBGGEFFJJHB_xor; } } //0x107DDF4 COAODPNEELA 0x107D958 OHOPAKFBOGL

		//// RVA: 0x107DAE0 Offset: 0x107DAE0 VA: 0x107DAE0
		//public uint CAOGDCBPBAN() { }
	}

	public const int JLBOFHIAFOM = 1;
	public static int FBGGEFFJJHB_xor = 0x856293; // 0x0
	public List<FEIHMMKMGOF> CDENCMNHNGA_table = new List<FEIHMMKMGOF>(); // 0x20

	// RVA: 0x107D290 Offset: 0x107D290 VA: 0x107D290
	public CKDOOBKOJBB_RareUpItem()
	{
		JIKKNHIAEKG_BlockName = "";
		LNIMEIMBCMF = false;
		LMHMIIKCGPE = 68;
	}

	// RVA: 0x107D388 Offset: 0x107D388 VA: 0x107D388 Slot: 8
	protected override void KMBPACJNEOF_Reset()
	{
		CDENCMNHNGA_table.Clear();
	}

	// RVA: 0x107D400 Offset: 0x107D400 VA: 0x107D400 Slot: 9
	public override bool IIEMACPEEBJ_Deserialize(byte[] _DBBGALAPFGC_bytes)
	{
		HDPPMMGCPFC parser = HDPPMMGCPFC.HEGEKFMJNCC(_DBBGALAPFGC_bytes);
		JMHHPHHACHH[] array = parser.ECFMCPJIDJN;
		for(int i = 0; i < array.Length; i++)
		{
			FEIHMMKMGOF data = new FEIHMMKMGOF();
			data.PPFNGGCBJKC_id = (int)array[i].PPFNGGCBJKC_id;
			data.JBGEEPFKIGG_val = (int)array[i].JBGEEPFKIGG_val;
			data.PLALNIIBLOF_en = JKAECBCNHAN_IsEnabled(array[i].IJEKNCDIIAE_mver, (int)array[i].PLALNIIBLOF_en, 0);
			data.EKLIPGELKCL_Rarity = (int)array[i].FBFLDFMFFOH_rar;
			data.EIGNPDFHIJA = array[i].EIGNPDFHIJA;
			CDENCMNHNGA_table.Add(data);
		}
		return true;
	}

	// RVA: 0x107D9F4 Offset: 0x107D9F4 VA: 0x107D9F4 Slot: 10
	public override bool IIEMACPEEBJ_Deserialize(EDOHBJAPLPF_JsonData OILEIIEIBHP, int _KAPMOPMDHJE_label)
	{
		return false;
	}

	// RVA: 0x107D9FC Offset: 0x107D9FC VA: 0x107D9FC Slot: 11
	public override uint CAOGDCBPBAN()
	{
		TodoLogger.LogError(TodoLogger.DbIntegrityCheck, "CKDOOBKOJBB_RareUpItem.CAOGDCBPBAN");
		return 0;
	}
}
