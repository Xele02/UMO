
using System.Collections.Generic;

[System.Obsolete("Use MDACFBPPIHD_PresentItem", true)]
public class MDACFBPPIHD { }
public class MDACFBPPIHD_PresentItem : DIHHCBACKGG_DbSection
{
	public class GPFDNMMCPHB
	{
		public int EHOIENNDEDH; // 0x8
		public int ICKOHEDLEFP; // 0xC
		public int HNJHPNPFAAN; // 0x10
		public int GNGNIKNNCNH; // 0x14
		public int EAJCFBCHIFB; // 0x18

		public int PPFNGGCBJKC { get { return EHOIENNDEDH ^ FBGGEFFJJHB; } set { EHOIENNDEDH = value ^ FBGGEFFJJHB; } } //0x130E3A0 DEMEPMAEJOO 0x130DEF4 HIGKAIDMOKN
		public int JBGEEPFKIGG { get { return ICKOHEDLEFP ^ FBGGEFFJJHB; } set { ICKOHEDLEFP = value ^ FBGGEFFJJHB; } } //0x130E438 OLOCMINKGON 0x130DF90 ABAFHIBFKCE
		public int PLALNIIBLOF { get { return HNJHPNPFAAN ^ FBGGEFFJJHB; } set { HNJHPNPFAAN = value ^ FBGGEFFJJHB; } } //0x130E4D0 JPCJNLHHIPE 0x130E02C JJFJNEJLBDG
		public int IJEKNCDIIAE { get { return GNGNIKNNCNH ^ FBGGEFFJJHB; } set { GNGNIKNNCNH = value ^ FBGGEFFJJHB; } } //0x130E568 KJIMMIBDCIL 0x130E0C8 DMEGNOKIKCD
		public int EKLIPGELKCL { get { return EAJCFBCHIFB ^ FBGGEFFJJHB; } set { EAJCFBCHIFB = value ^ FBGGEFFJJHB; } } //0x130E600 OEEHBGECGKL 0x130E164 GHLMHLJJBIG

		//// RVA: 0x130E2EC Offset: 0x130E2EC VA: 0x130E2EC
		//public uint CAOGDCBPBAN() { }
	}

	public const int CADHDBIFKKL = 20;
	public static int FBGGEFFJJHB = 0xd724f; // 0x0
	public List<GPFDNMMCPHB> CDENCMNHNGA = new List<GPFDNMMCPHB>(); // 0x20

	// RVA: 0x130DAE8 Offset: 0x130DAE8 VA: 0x130DAE8
	public MDACFBPPIHD_PresentItem()
	{
		JIKKNHIAEKG_BlockName = "";
		LNIMEIMBCMF = false;
		LMHMIIKCGPE = 66;
	}

	// RVA: 0x130DBE0 Offset: 0x130DBE0 VA: 0x130DBE0 Slot: 8
	protected override void KMBPACJNEOF()
	{
		CDENCMNHNGA.Clear();
	}

	// RVA: 0x130DC58 Offset: 0x130DC58 VA: 0x130DC58 Slot: 9
	public override bool IIEMACPEEBJ(byte[] DBBGALAPFGC)
	{
		LGCNKCBKJBA parser = LGCNKCBKJBA.HEGEKFMJNCC(DBBGALAPFGC);
		MKMPJMOODKL[] array = parser.AAAKAPGGNGL;
		for (int i = 0; i < array.Length; i++)
		{
			GPFDNMMCPHB data = new GPFDNMMCPHB();
			data.PPFNGGCBJKC = (int)array[i].PPFNGGCBJKC;
			data.JBGEEPFKIGG = (int)array[i].JBGEEPFKIGG;
			data.PLALNIIBLOF = (int)array[i].PLALNIIBLOF;
			data.IJEKNCDIIAE = array[i].IJEKNCDIIAE;
			data.EKLIPGELKCL = (int)array[i].FBFLDFMFFOH;
			CDENCMNHNGA.Add(data);
		}
		return true;
	}

	// RVA: 0x130E200 Offset: 0x130E200 VA: 0x130E200 Slot: 10
	public override bool IIEMACPEEBJ(EDOHBJAPLPF_JsonData OILEIIEIBHP, int KAPMOPMDHJE)
	{
		return false;
	}

	// RVA: 0x130E208 Offset: 0x130E208 VA: 0x130E208 Slot: 11
	public override uint CAOGDCBPBAN()
	{
		TodoLogger.Log(TodoLogger.DbIntegrityCheck, "MDACFBPPIHD_PresentItem.CAOGDCBPBAN");
		return 0;
	}
}
