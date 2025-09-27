
using System.Collections.Generic;

[System.Obsolete("Use MDACFBPPIHD_PresentItem", true)]
public class MDACFBPPIHD { }
public class MDACFBPPIHD_PresentItem : DIHHCBACKGG_DbSection
{
	public class GPFDNMMCPHB
	{
		public int EHOIENNDEDH_IdCrypted; // 0x8
		public int ICKOHEDLEFP_ValueCrypted; // 0xC
		public int HNJHPNPFAAN_EnabledCrypted; // 0x10
		public int GNGNIKNNCNH_MVerCrypted; // 0x14
		public int EAJCFBCHIFB_RarityCrypted; // 0x18

		public int PPFNGGCBJKC_id { get { return EHOIENNDEDH_IdCrypted ^ FBGGEFFJJHB_xor; } set { EHOIENNDEDH_IdCrypted = value ^ FBGGEFFJJHB_xor; } } //0x130E3A0 DEMEPMAEJOO 0x130DEF4 HIGKAIDMOKN
		public int JBGEEPFKIGG_val { get { return ICKOHEDLEFP_ValueCrypted ^ FBGGEFFJJHB_xor; } set { ICKOHEDLEFP_ValueCrypted = value ^ FBGGEFFJJHB_xor; } } //0x130E438 OLOCMINKGON 0x130DF90 ABAFHIBFKCE
		public int PLALNIIBLOF_en { get { return HNJHPNPFAAN_EnabledCrypted ^ FBGGEFFJJHB_xor; } set { HNJHPNPFAAN_EnabledCrypted = value ^ FBGGEFFJJHB_xor; } } //0x130E4D0 JPCJNLHHIPE 0x130E02C JJFJNEJLBDG
		public int IJEKNCDIIAE_mver { get { return GNGNIKNNCNH_MVerCrypted ^ FBGGEFFJJHB_xor; } set { GNGNIKNNCNH_MVerCrypted = value ^ FBGGEFFJJHB_xor; } } //0x130E568 KJIMMIBDCIL 0x130E0C8 DMEGNOKIKCD
		public int EKLIPGELKCL_Rarity { get { return EAJCFBCHIFB_RarityCrypted ^ FBGGEFFJJHB_xor; } set { EAJCFBCHIFB_RarityCrypted = value ^ FBGGEFFJJHB_xor; } } //0x130E600 OEEHBGECGKL 0x130E164 GHLMHLJJBIG

		//// RVA: 0x130E2EC Offset: 0x130E2EC VA: 0x130E2EC
		//public uint CAOGDCBPBAN() { }
	}

	public const int CADHDBIFKKL = 20;
	public static int FBGGEFFJJHB_xor = 0xd724f; // 0x0
	public List<GPFDNMMCPHB> CDENCMNHNGA_table = new List<GPFDNMMCPHB>(); // 0x20

	// RVA: 0x130DAE8 Offset: 0x130DAE8 VA: 0x130DAE8
	public MDACFBPPIHD_PresentItem()
	{
		JIKKNHIAEKG_BlockName = "";
		LNIMEIMBCMF = false;
		LMHMIIKCGPE = 66;
	}

	// RVA: 0x130DBE0 Offset: 0x130DBE0 VA: 0x130DBE0 Slot: 8
	protected override void KMBPACJNEOF_Reset()
	{
		CDENCMNHNGA_table.Clear();
	}

	// RVA: 0x130DC58 Offset: 0x130DC58 VA: 0x130DC58 Slot: 9
	public override bool IIEMACPEEBJ_Deserialize(byte[] _DBBGALAPFGC_bytes)
	{
		LGCNKCBKJBA parser = LGCNKCBKJBA.HEGEKFMJNCC(_DBBGALAPFGC_bytes);
		MKMPJMOODKL[] array = parser.AAAKAPGGNGL;
		for (int i = 0; i < array.Length; i++)
		{
			GPFDNMMCPHB data = new GPFDNMMCPHB();
			data.PPFNGGCBJKC_id = (int)array[i].PPFNGGCBJKC_id;
			data.JBGEEPFKIGG_val = (int)array[i].JBGEEPFKIGG_val;
			data.PLALNIIBLOF_en = (int)array[i].PLALNIIBLOF_en;
			data.IJEKNCDIIAE_mver = array[i].IJEKNCDIIAE_mver;
			data.EKLIPGELKCL_Rarity = (int)array[i].FBFLDFMFFOH_rar;
			CDENCMNHNGA_table.Add(data);
		}
		return true;
	}

	// RVA: 0x130E200 Offset: 0x130E200 VA: 0x130E200 Slot: 10
	public override bool IIEMACPEEBJ_Deserialize(EDOHBJAPLPF_JsonData OILEIIEIBHP, int _KAPMOPMDHJE_label)
	{
		return false;
	}

	// RVA: 0x130E208 Offset: 0x130E208 VA: 0x130E208 Slot: 11
	public override uint CAOGDCBPBAN()
	{
		TodoLogger.LogError(TodoLogger.DbIntegrityCheck, "MDACFBPPIHD_PresentItem.CAOGDCBPBAN");
		return 0;
	}
}
