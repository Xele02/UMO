
using System.Collections.Generic;

[System.Obsolete("Use JNGINLMOJKH_EventGachaTicket", true)]
public class JNGINLMOJKH { }

public class JNGINLMOJKH_EventGachaTicket : DIHHCBACKGG_DbSection
{
	public class JDNAAGCHCOH
	{
		public int EHOIENNDEDH_IdCrypted; // 0x8
		public int FCDPPFKIHEN; // 0xC
		public int IIBCIOJIODJ; // 0x10
		public int ICKOHEDLEFP_ValueCrypted; // 0x14
		public long LBDKPOLAELH; // 0x18
		public int HNJHPNPFAAN_EnabledCrypted; // 0x20
		public int GNGNIKNNCNH_MVerCrypted; // 0x24
		public int LCGJKAGIFGO_MaxCrypted; // 0x28

		public int PPFNGGCBJKC_id { get { return EHOIENNDEDH_IdCrypted ^ FBGGEFFJJHB_xor; } set { EHOIENNDEDH_IdCrypted = value ^ FBGGEFFJJHB_xor; } } //0x1B8F7D0 DEMEPMAEJOO 0x1B8EC94 HIGKAIDMOKN
		public int EJPKFBHNDGI_EvNo { get { return FCDPPFKIHEN ^ FBGGEFFJJHB_xor; } set { FCDPPFKIHEN = value ^ FBGGEFFJJHB_xor; } } //0x1B8F868 BDKLEOCKELL 0x1B8ED30 JILBLBACAEL
		public int GOBMACPDDCL_EvId { get { return IIBCIOJIODJ ^ FBGGEFFJJHB_xor; } set { IIBCIOJIODJ = value ^ FBGGEFFJJHB_xor; } } //0x1B8F900 ODBGFPGPPAC 0x1B8EDCC LIMKOCNLLPL
		public int JBGEEPFKIGG_val { get { return ICKOHEDLEFP_ValueCrypted ^ FBGGEFFJJHB_xor; } set { ICKOHEDLEFP_ValueCrypted = value ^ FBGGEFFJJHB_xor; } } //0x1B8F998 OLOCMINKGON 0x1B8EE68 ABAFHIBFKCE
		public long EMIJNAFJFJO_Expir { get { return LBDKPOLAELH ^ FBGGEFFJJHB_xor; } set { LBDKPOLAELH = value ^ FBGGEFFJJHB_xor; } } //0x1B8FA30 GBGPKONOFGD 0x1B8EFA0 KCFHLAFJJPJ
		public int PLALNIIBLOF_en { get { return HNJHPNPFAAN_EnabledCrypted ^ FBGGEFFJJHB_xor; } set { HNJHPNPFAAN_EnabledCrypted = value ^ FBGGEFFJJHB_xor; } } //0x1B8FACC JPCJNLHHIPE 0x1B8F044 JJFJNEJLBDG
		public int IJEKNCDIIAE_MVer { get { return GNGNIKNNCNH_MVerCrypted ^ FBGGEFFJJHB_xor; } set { GNGNIKNNCNH_MVerCrypted = value ^ FBGGEFFJJHB_xor; } } //0x1B8FB64 KJIMMIBDCIL 0x1B8F0E0 DMEGNOKIKCD
		public int DOOGFEGEKLG_Max{ get { return LCGJKAGIFGO_MaxCrypted ^ FBGGEFFJJHB_xor; } set { LCGJKAGIFGO_MaxCrypted = value ^ FBGGEFFJJHB_xor; } } //0x1B8FBFC AECMFIOFFJN 0x1B8EF04 NGOJJDOCIDG

		//// RVA: 0x1B8F6F8 Offset: 0x1B8F6F8 VA: 0x1B8F6F8
		//public uint CAOGDCBPBAN() { }
	}

	public const int IMIOICNLIOE = 6;
	public static int FBGGEFFJJHB_xor = 0xa9a45; // 0x0
	public List<JDNAAGCHCOH> CDENCMNHNGA_table = new List<JDNAAGCHCOH>(); // 0x20
	
	// RVA: 0x1B8E7D0 Offset: 0x1B8E7D0 VA: 0x1B8E7D0
	public JNGINLMOJKH_EventGachaTicket()
	{
		JIKKNHIAEKG_BlockName = "";
		LNIMEIMBCMF = false;
		LMHMIIKCGPE = 31;
	}

	// RVA: 0x1B8E8C8 Offset: 0x1B8E8C8 VA: 0x1B8E8C8 Slot: 8
	protected override void KMBPACJNEOF_Reset()
	{
		CDENCMNHNGA_table.Clear();
	}

	// RVA: 0x1B8E940 Offset: 0x1B8E940 VA: 0x1B8E940 Slot: 9
	public override bool IIEMACPEEBJ_Deserialize(byte[] _DBBGALAPFGC_Data)
	{
		BOLCKDHHNDB parser = BOLCKDHHNDB.HEGEKFMJNCC(_DBBGALAPFGC_Data);
		IHANOPGIKEO[] array = parser.IIHHPGHEIIN;
		for(int i = 0; i < array.Length; i++)
		{
			JDNAAGCHCOH data = new JDNAAGCHCOH();
			data.PPFNGGCBJKC_id = (int)array[i].PPFNGGCBJKC;
			data.EJPKFBHNDGI_EvNo = (int)array[i].EJPKFBHNDGI;
			data.GOBMACPDDCL_EvId = (int)array[i].GOBMACPDDCL;
			data.JBGEEPFKIGG_val = (int)array[i].JBGEEPFKIGG;
			data.DOOGFEGEKLG_Max = (int)array[i].DOOGFEGEKLG;
			data.EMIJNAFJFJO_Expir = array[i].EMIJNAFJFJO;
			data.PLALNIIBLOF_en = (int)array[i].PLALNIIBLOF;
			data.IJEKNCDIIAE_MVer = array[i].IJEKNCDIIAE;
			CDENCMNHNGA_table.Add(data);
		}
		return true;
	}

	// RVA: 0x1B8F17C Offset: 0x1B8F17C VA: 0x1B8F17C Slot: 10
	public override bool IIEMACPEEBJ_Deserialize(EDOHBJAPLPF_JsonData OILEIIEIBHP, int _KAPMOPMDHJE_label)
	{
		TodoLogger.LogError(TodoLogger.DbJson, "JNGINLMOJKH_EventGachaTicket.IIEMACPEEBJ");
		return true;
	}

	// RVA: 0x1B8F614 Offset: 0x1B8F614 VA: 0x1B8F614 Slot: 11
	public override uint CAOGDCBPBAN()
	{
		TodoLogger.LogError(TodoLogger.DbIntegrityCheck, "JNGINLMOJKH_EventGachaTicket.CAOGDCBPBAN");
		return 0;
	}
}
