
using System.Collections.Generic;

[System.Obsolete("Use JKDKODAPGBJ_EnergyItem", true)]
public class JKDKODAPGBJ { }
public class JKDKODAPGBJ_EnergyItem : DIHHCBACKGG_DbSection
{
	public class GFGCCICHBHK
	{
		public int EHOIENNDEDH_IdCrypted; // 0x8
		public int JEDNBJLMBKE; // 0xC
		public int HNJHPNPFAAN; // 0x10
		public int LCGJKAGIFGO; // 0x14
		public int ICKOHEDLEFP; // 0x18
		public int JDIJODDBCPK; // 0x1C
		public int EAJCFBCHIFB_RarityCrypted; // 0x20

		public int PPFNGGCBJKC { get { return EHOIENNDEDH_IdCrypted ^ FBGGEFFJJHB_xor; } set { EHOIENNDEDH_IdCrypted = value ^ FBGGEFFJJHB_xor; } } //0x135D158 DEMEPMAEJOO 0x135CBF8 HIGKAIDMOKN
		public int PPEGAKEIEGM_Enabled { get { return HNJHPNPFAAN ^ FBGGEFFJJHB_xor; } set { HNJHPNPFAAN = value ^ FBGGEFFJJHB_xor; } } //0x135D1F0 KPOEEPIMMJP 0x135CB5C NCIEAFEDPBH
		public int HJAFPEBIBOP_IsLimit { get { return JEDNBJLMBKE ^ FBGGEFFJJHB_xor; } set { JEDNBJLMBKE = value ^ FBGGEFFJJHB_xor; } } //0x135D288 GNDLHNBPMHN 0x135CD30 HPFNBOKBEDD
		public int DOOGFEGEKLG_Max { get { return LCGJKAGIFGO ^ FBGGEFFJJHB_xor; } set { LCGJKAGIFGO = value ^ FBGGEFFJJHB_xor; } } //0x135D320 AECMFIOFFJN 0x135CDCC NGOJJDOCIDG
		public int JBGEEPFKIGG_HealValue { get { return ICKOHEDLEFP ^ FBGGEFFJJHB_xor; } set { ICKOHEDLEFP = value ^ FBGGEFFJJHB_xor; } } //0x135D3B8 OLOCMINKGON 0x135CC94 ABAFHIBFKCE
		public int FPOMEEJFBIG_Order { get { return JDIJODDBCPK ^ FBGGEFFJJHB_xor; } set { JDIJODDBCPK = value ^ FBGGEFFJJHB_xor; } } //0x135D450 OEEBAHNAPEC 0x135CE68 BEHAPLPPLNE
		public int EKLIPGELKCL_Rarity { get { return EAJCFBCHIFB_RarityCrypted ^ FBGGEFFJJHB_xor; } set { EAJCFBCHIFB_RarityCrypted = value ^ FBGGEFFJJHB_xor; } } //0x135D4E8 OEEHBGECGKL 0x135CF04 GHLMHLJJBIG

		// RVA: 0x135D08C Offset: 0x135D08C VA: 0x135D08C
		//public uint CAOGDCBPBAN() { }
	}

	public const int LFHKGBGHEEM = 5;
	public static int FBGGEFFJJHB_xor = 0xb516d; // 0x0
	public List<GFGCCICHBHK> CDENCMNHNGA_table = new List<GFGCCICHBHK>(); // 0x20

	// RVA: 0x135C650 Offset: 0x135C650 VA: 0x135C650
	public JKDKODAPGBJ_EnergyItem()
	{
		JIKKNHIAEKG_BlockName = "";
		LNIMEIMBCMF = false;
		LMHMIIKCGPE = 24;
	}

	// RVA: 0x135C748 Offset: 0x135C748 VA: 0x135C748 Slot: 8
	protected override void KMBPACJNEOF()
	{
		CDENCMNHNGA_table.Clear();
	}

	// RVA: 0x135C7C0 Offset: 0x135C7C0 VA: 0x135C7C0 Slot: 9
	public override bool IIEMACPEEBJ(byte[] _DBBGALAPFGC_Data)
	{
		MKLLOAPBIGJ parser = MKLLOAPBIGJ.HEGEKFMJNCC(_DBBGALAPFGC_Data);
		FHAPNNHNNCN[] array = parser.JNMKOOKNLIN;
		for(int i = 0; i < array.Length; i++)
		{
			GFGCCICHBHK data = new GFGCCICHBHK();
			data.PPEGAKEIEGM_Enabled = JKAECBCNHAN_IsEnabled(array[i].IJEKNCDIIAE, array[i].PLALNIIBLOF, 0);
			data.PPFNGGCBJKC = array[i].PPFNGGCBJKC;
			data.JBGEEPFKIGG_HealValue = array[i].JBGEEPFKIGG;
			data.HJAFPEBIBOP_IsLimit = array[i].HJAFPEBIBOP;
			data.DOOGFEGEKLG_Max = array[i].DOOGFEGEKLG;
			data.JBGEEPFKIGG_HealValue = array[i].JBGEEPFKIGG;
			data.FPOMEEJFBIG_Order = array[i].FPOMEEJFBIG;
			data.EKLIPGELKCL_Rarity = (int)array[i].FBFLDFMFFOH;
			CDENCMNHNGA_table.Add(data);
		}
		return true;
	}

	// RVA: 0x135CFA0 Offset: 0x135CFA0 VA: 0x135CFA0 Slot: 10
	public override bool IIEMACPEEBJ(EDOHBJAPLPF_JsonData OILEIIEIBHP, int KAPMOPMDHJE)
	{
		return true;
	}

	// RVA: 0x135CFA8 Offset: 0x135CFA8 VA: 0x135CFA8 Slot: 11
	public override uint CAOGDCBPBAN()
	{
		TodoLogger.LogError(TodoLogger.DbIntegrityCheck, "JKDKODAPGBJ_EnergyItem.CAOGDCBPBAN");
		return 0;
	}
}
