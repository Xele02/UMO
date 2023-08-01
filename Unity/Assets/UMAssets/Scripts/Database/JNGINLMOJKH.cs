
using System.Collections.Generic;

[System.Obsolete("Use JNGINLMOJKH_EventGachaTicket", true)]
public class JNGINLMOJKH { }

public class JNGINLMOJKH_EventGachaTicket : DIHHCBACKGG_DbSection
{
	public class JDNAAGCHCOH
	{
		public int EHOIENNDEDH; // 0x8
		public int FCDPPFKIHEN; // 0xC
		public int IIBCIOJIODJ; // 0x10
		public int ICKOHEDLEFP; // 0x14
		public long LBDKPOLAELH; // 0x18
		public int HNJHPNPFAAN; // 0x20
		public int GNGNIKNNCNH; // 0x24
		public int LCGJKAGIFGO; // 0x28

		public int PPFNGGCBJKC_Id { get { return EHOIENNDEDH ^ FBGGEFFJJHB; } set { EHOIENNDEDH = value ^ FBGGEFFJJHB; } } //0x1B8F7D0 DEMEPMAEJOO 0x1B8EC94 HIGKAIDMOKN
		public int EJPKFBHNDGI_EvNo { get { return FCDPPFKIHEN ^ FBGGEFFJJHB; } set { FCDPPFKIHEN = value ^ FBGGEFFJJHB; } } //0x1B8F868 BDKLEOCKELL 0x1B8ED30 JILBLBACAEL
		public int GOBMACPDDCL_EvId { get { return IIBCIOJIODJ ^ FBGGEFFJJHB; } set { IIBCIOJIODJ = value ^ FBGGEFFJJHB; } } //0x1B8F900 ODBGFPGPPAC 0x1B8EDCC LIMKOCNLLPL
		public int JBGEEPFKIGG_Val { get { return ICKOHEDLEFP ^ FBGGEFFJJHB; } set { ICKOHEDLEFP = value ^ FBGGEFFJJHB; } } //0x1B8F998 OLOCMINKGON 0x1B8EE68 ABAFHIBFKCE
		public long EMIJNAFJFJO_Expir { get { return LBDKPOLAELH ^ FBGGEFFJJHB; } set { LBDKPOLAELH = value ^ FBGGEFFJJHB; } } //0x1B8FA30 GBGPKONOFGD 0x1B8EFA0 KCFHLAFJJPJ
		public int PLALNIIBLOF_En { get { return HNJHPNPFAAN ^ FBGGEFFJJHB; } set { HNJHPNPFAAN = value ^ FBGGEFFJJHB; } } //0x1B8FACC JPCJNLHHIPE 0x1B8F044 JJFJNEJLBDG
		public int IJEKNCDIIAE_MVer { get { return GNGNIKNNCNH ^ FBGGEFFJJHB; } set { GNGNIKNNCNH = value ^ FBGGEFFJJHB; } } //0x1B8FB64 KJIMMIBDCIL 0x1B8F0E0 DMEGNOKIKCD
		public int DOOGFEGEKLG_Max{ get { return LCGJKAGIFGO ^ FBGGEFFJJHB; } set { LCGJKAGIFGO = value ^ FBGGEFFJJHB; } } //0x1B8FBFC AECMFIOFFJN 0x1B8EF04 NGOJJDOCIDG

		//// RVA: 0x1B8F6F8 Offset: 0x1B8F6F8 VA: 0x1B8F6F8
		//public uint CAOGDCBPBAN() { }
	}

	public const int IMIOICNLIOE = 6;
	public static int FBGGEFFJJHB = 0xa9a45; // 0x0
	public List<JDNAAGCHCOH> CDENCMNHNGA = new List<JDNAAGCHCOH>(); // 0x20
	
	// RVA: 0x1B8E7D0 Offset: 0x1B8E7D0 VA: 0x1B8E7D0
	public JNGINLMOJKH_EventGachaTicket()
	{
		JIKKNHIAEKG_BlockName = "";
		LNIMEIMBCMF = false;
		LMHMIIKCGPE = 31;
	}

	// RVA: 0x1B8E8C8 Offset: 0x1B8E8C8 VA: 0x1B8E8C8 Slot: 8
	protected override void KMBPACJNEOF()
	{
		CDENCMNHNGA.Clear();
	}

	// RVA: 0x1B8E940 Offset: 0x1B8E940 VA: 0x1B8E940 Slot: 9
	public override bool IIEMACPEEBJ(byte[] DBBGALAPFGC)
	{
		BOLCKDHHNDB parser = BOLCKDHHNDB.HEGEKFMJNCC(DBBGALAPFGC);
		IHANOPGIKEO[] array = parser.IIHHPGHEIIN;
		for(int i = 0; i < array.Length; i++)
		{
			JDNAAGCHCOH data = new JDNAAGCHCOH();
			data.PPFNGGCBJKC_Id = (int)array[i].PPFNGGCBJKC;
			data.EJPKFBHNDGI_EvNo = (int)array[i].EJPKFBHNDGI;
			data.GOBMACPDDCL_EvId = (int)array[i].GOBMACPDDCL;
			data.JBGEEPFKIGG_Val = (int)array[i].JBGEEPFKIGG;
			data.DOOGFEGEKLG_Max = (int)array[i].DOOGFEGEKLG;
			data.EMIJNAFJFJO_Expir = array[i].EMIJNAFJFJO;
			data.PLALNIIBLOF_En = (int)array[i].PLALNIIBLOF;
			data.IJEKNCDIIAE_MVer = array[i].IJEKNCDIIAE;
			CDENCMNHNGA.Add(data);
		}
		return true;
	}

	// RVA: 0x1B8F17C Offset: 0x1B8F17C VA: 0x1B8F17C Slot: 10
	public override bool IIEMACPEEBJ(EDOHBJAPLPF_JsonData OILEIIEIBHP, int KAPMOPMDHJE)
	{
		TodoLogger.LogError(TodoLogger.Database, "JNGINLMOJKH_EventGachaTicket.IIEMACPEEBJ");
		return true;
	}

	// RVA: 0x1B8F614 Offset: 0x1B8F614 VA: 0x1B8F614 Slot: 11
	public override uint CAOGDCBPBAN()
	{
		TodoLogger.LogError(TodoLogger.DbIntegrityCheck, "JNGINLMOJKH_EventGachaTicket.CAOGDCBPBAN");
		return 0;
	}
}
