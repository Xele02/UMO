
using System.Collections.Generic;

[System.Obsolete("Use JHAAHJNEBOG_LimitedCompoItem", true)]
public class JHAAHJNEBOG { }
public class JHAAHJNEBOG_LimitedCompoItem : DIHHCBACKGG_DbSection
{
	public class AOBHKONKIPF
	{
		public int EHOIENNDEDH_IdCrypted; // 0x8
		public int HNNLOMMFHEN_catCrypted; // 0xC
		public int ICKOHEDLEFP_ValueCrypted; // 0x10
		public int HNJHPNPFAAN_EnabledCrypted; // 0x14
		public int GNGNIKNNCNH_MVerCrypted; // 0x18
		public int EAJCFBCHIFB_RarityCrypted; // 0x1C
		public int HHPFFPINGAA_OrderCrypted; // 0x20
		public int LBDKPOLAELH; // 0x24
		public int BFEJGHJHIOF; // 0x28

		public int PPFNGGCBJKC_id { get { return EHOIENNDEDH_IdCrypted ^ FBGGEFFJJHB_xor; } set { EHOIENNDEDH_IdCrypted = value ^ FBGGEFFJJHB_xor; } } //0xB1CF6C DEMEPMAEJOO_get_id 0xB1C42C HIGKAIDMOKN_set_id
		public int IJEKNCDIIAE_mver { get { return GNGNIKNNCNH_MVerCrypted ^ FBGGEFFJJHB_xor; } set { GNGNIKNNCNH_MVerCrypted = value ^ FBGGEFFJJHB_xor; } } //0xB1D004 KJIMMIBDCIL_get_mver 0xB1C4C8 DMEGNOKIKCD_set_mver
		public int PLALNIIBLOF_en { get { return HNJHPNPFAAN_EnabledCrypted ^ FBGGEFFJJHB_xor; } set { HNJHPNPFAAN_EnabledCrypted = value ^ FBGGEFFJJHB_xor; } } //0xB1D09C JPCJNLHHIPE_get_en 0xB1C564 JJFJNEJLBDG_set_en
		public int DMEDKJPOLCH_cat { get { return HNNLOMMFHEN_catCrypted ^ FBGGEFFJJHB_xor; } set { HNNLOMMFHEN_catCrypted = value ^ FBGGEFFJJHB_xor; } } //0xB1D134 IPKCKAAEEOE_get_cat 0xB1C600_bgs JOGLLINFLJN_set_cat
		public int EILKGEADKGH_Order { get { return HHPFFPINGAA_OrderCrypted ^ FBGGEFFJJHB_xor; } set { HHPFFPINGAA_OrderCrypted = value ^ FBGGEFFJJHB_xor; } } //0xB1D1CC NPDDACIHBKD_get_Order 0xB1C69C BJJMCKHBPNH_set_Order
		public int JBGEEPFKIGG_val { get { return ICKOHEDLEFP_ValueCrypted ^ FBGGEFFJJHB_xor; } set { ICKOHEDLEFP_ValueCrypted = value ^ FBGGEFFJJHB_xor; } } //0xB1D264 OLOCMINKGON_get_val 0xB1C7D4 ABAFHIBFKCE_set_val
		public int EKLIPGELKCL_Rarity { get { return EAJCFBCHIFB_RarityCrypted ^ FBGGEFFJJHB_xor; } set { EAJCFBCHIFB_RarityCrypted = value ^ FBGGEFFJJHB_xor; } } //0xB1D2FC OEEHBGECGKL_get_Rarity 0xB1C738 GHLMHLJJBIG_set_Rarity
		public int EMIJNAFJFJO_expir { get { return LBDKPOLAELH ^ FBGGEFFJJHB_xor; } set { LBDKPOLAELH = value ^ FBGGEFFJJHB_xor; } } //0xB1D394 GBGPKONOFGD_get_expir 0xB1C870 KCFHLAFJJPJ_set_expir
		public int PENIOLJHIPK { get { return BFEJGHJHIOF ^ FBGGEFFJJHB_xor; } set { BFEJGHJHIOF = value ^ FBGGEFFJJHB_xor; } } //0xB1C9A8 AHIONKNDHHH_get_ 0xB1C90C NEOFLJKHAKC_set_

		//// RVA: 0xB1D42C Offset: 0xB1D42C VA: 0xB1D42C
		//public uint CAOGDCBPBAN() { }
	}

	public class JMJKJFKAFCJ
	{
		public int BFEJGHJHIOF; // 0x8
		public int LCGJKAGIFGO_MaxCrypted; // 0xC
		public int PLFKPDAHHBK; // 0x10
		public int CILEPBKEOHB_ConditionValueCrypted; // 0x14
		public List<AOBHKONKIPF> OCMMLAOEPIG = new List<AOBHKONKIPF>(); // 0x18

		public int PENIOLJHIPK { get { return BFEJGHJHIOF ^ FBGGEFFJJHB_xor; } set { BFEJGHJHIOF = value ^ FBGGEFFJJHB_xor; } } //0xB1D4A4 AHIONKNDHHH_get_ 0xB1C1B4 NEOFLJKHAKC_set_
		public int DOOGFEGEKLG_max { get { return LCGJKAGIFGO_MaxCrypted ^ FBGGEFFJJHB_xor; } set { LCGJKAGIFGO_MaxCrypted = value ^ FBGGEFFJJHB_xor; } } //0xB1D53C AECMFIOFFJN_get_max 0xB1C250 NGOJJDOCIDG_set_max
		public int HHGFOIMIGED { get { return PLFKPDAHHBK ^ FBGGEFFJJHB_xor; } set { PLFKPDAHHBK = value ^ FBGGEFFJJHB_xor; } } //0xB1D5D4 POJLCAFLBGA_get_ 0xB1C2EC MNDPEODCBPL_set_
		public int DODGLIDGBBC_ConditionValue { get { return CILEPBKEOHB_ConditionValueCrypted ^ FBGGEFFJJHB_xor; } set { CILEPBKEOHB_ConditionValueCrypted = value ^ FBGGEFFJJHB_xor; } } //0xB1D66C PAACNLDBGKP_get_ConditionValue 0xB1C388 AHIHPMDINHA_set_ConditionValue

		//// RVA: 0xB1CDB8 Offset: 0xB1CDB8 VA: 0xB1CDB8
		//public uint CAOGDCBPBAN() { }
	}

	public class LACKNDBIIJD
	{
		private int FDJAHLIICNO; // 0x8
		private int CCKDEMEECCJ; // 0xC
		private int POCPJBJKPOB; // 0x10
		private int FPJAOBICLDI; // 0x14

		public int LHHOODFPCEL { get { return FDJAHLIICNO ^ FBGGEFFJJHB_xor; } set { FDJAHLIICNO = value ^ FBGGEFFJJHB_xor; } } //0xB1D704 OIIOODJFKHJ_bgs 0xB1CA40 FKBIADOGCPM_bgs
		public int ALEDAGOCGGH { get { return CCKDEMEECCJ ^ FBGGEFFJJHB_xor; } set { CCKDEMEECCJ = value ^ FBGGEFFJJHB_xor; } } //0xB1D79C BAFMOENIDCC_bgs 0xB1CADC GNCKMAMFEGA_bgs
		public int JKDFMICLDJO { get { return POCPJBJKPOB ^ FBGGEFFJJHB_xor; } set { POCPJBJKPOB = value ^ FBGGEFFJJHB_xor; } }// 0xB1D834 GLLNPHGPPHH_bgs 0xB1CB78 HDBFLHONIHA_bgs
		public int EIEOBPKBJDN { get { return FPJAOBICLDI ^ FBGGEFFJJHB_xor; } set { FPJAOBICLDI = value ^ FBGGEFFJJHB_xor; } }// 0xB1D8CC JMLDPKECNKD_bgs 0xB1CC14 DFDGEGBHOFL_bgs

		//// RVA: 0xB1B924 Offset: 0xB1B924 VA: 0xB1B924
		public void KMBPACJNEOF_Reset()
		{
			LHHOODFPCEL = 0;
			ALEDAGOCGGH = 0;
			JKDFMICLDJO = 0;
			EIEOBPKBJDN = 0;
		}

		//// RVA: 0xB1CEC8 Offset: 0xB1CEC8 VA: 0xB1CEC8
		//public uint CAOGDCBPBAN() { }
	}

	public const int KHFJCOCEIBO = 1;
	public static int FBGGEFFJJHB_xor = 0x5b5a; // 0x0
	public List<JMJKJFKAFCJ> CDENCMNHNGA_table = new List<JMJKJFKAFCJ>(); // 0x20
	public List<AOBHKONKIPF> OCMMLAOEPIG = new List<AOBHKONKIPF>(); // 0x24
	public LACKNDBIIJD OEJIPANCLOP = new LACKNDBIIJD(); // 0x28
	
	// RVA: 0xB1B738 Offset: 0xB1B738 VA: 0xB1B738
	public JHAAHJNEBOG_LimitedCompoItem()
	{
		JIKKNHIAEKG_BlockName = "";
		LNIMEIMBCMF = false;
		LMHMIIKCGPE = 58;
	}

	// RVA: 0xB1B890 Offset: 0xB1B890 VA: 0xB1B890 Slot: 8
	protected override void KMBPACJNEOF_Reset()
	{
		CDENCMNHNGA_table.Clear();
		OEJIPANCLOP.KMBPACJNEOF_Reset();
	}

	// RVA: 0xB1B960 Offset: 0xB1B960 VA: 0xB1B960 Slot: 9
	public override bool IIEMACPEEBJ_Deserialize(byte[] _DBBGALAPFGC_bytes)
	{
		MAPLLKFHCLF parser = MAPLLKFHCLF.HEGEKFMJNCC(_DBBGALAPFGC_bytes);
		{
			IMDHBHHELPP[] array = parser.LIFDACJBDBA;
			for(int i = 0; i < array.Length; i++)
			{
				JMJKJFKAFCJ data = new JMJKJFKAFCJ();
				data.PENIOLJHIPK = (int)array[i].DODGLIDGBBC_ConditionValue;//??
				data.DOOGFEGEKLG_max = (int)array[i].DOOGFEGEKLG_max;
				data.HHGFOIMIGED = (int)array[i].HHGFOIMIGED;
				data.DODGLIDGBBC_ConditionValue = (int)array[i].DODGLIDGBBC_ConditionValue;
				data.OCMMLAOEPIG.Clear();
				CDENCMNHNGA_table.Add(data);
			}
		}
		{
			BKJIHCIKGPA[] array = parser.CAHBHHIPMMO;
			for(int i = 0; i < array.Length; i++)
			{
				AOBHKONKIPF data = new AOBHKONKIPF();
				data.PPFNGGCBJKC_id = (int)array[i].PPFNGGCBJKC_id;
				data.IJEKNCDIIAE_mver = array[i].IJEKNCDIIAE_mver;
				data.PLALNIIBLOF_en = (int)array[i].PLALNIIBLOF_en;
				data.DMEDKJPOLCH_cat = array[i].DMEDKJPOLCH_cat;
				data.EILKGEADKGH_Order = array[i].FPOMEEJFBIG_odr;
				data.EKLIPGELKCL_Rarity = array[i].FBFLDFMFFOH_rar;
				data.JBGEEPFKIGG_val = array[i].JBGEEPFKIGG_val;
				data.EMIJNAFJFJO_expir = array[i].EMIJNAFJFJO_expir;
				data.PENIOLJHIPK = (int)array[i].PENIOLJHIPK;
				OCMMLAOEPIG.Add(data);
				CDENCMNHNGA_table[data.PENIOLJHIPK - 1].OCMMLAOEPIG.Add(data);
			}
		}
		{
			DGEFOEFDBNE data = parser.JOELFNNPOPK;
			OEJIPANCLOP.LHHOODFPCEL = data.KBDNDDMCCMC;
			OEJIPANCLOP.ALEDAGOCGGH = data.MALJIDIJEAO;
			OEJIPANCLOP.JKDFMICLDJO = data.HBIFNGLIMPP;
			OEJIPANCLOP.EIEOBPKBJDN = data.IBCJEHCCMFM;
		}
		return true;
	}

	// RVA: 0xB1CCB0 Offset: 0xB1CCB0 VA: 0xB1CCB0 Slot: 10
	public override bool IIEMACPEEBJ_Deserialize(EDOHBJAPLPF_JsonData OILEIIEIBHP, int _KAPMOPMDHJE_label)
	{
		return false;
	}

	// RVA: 0xB1CCB8 Offset: 0xB1CCB8 VA: 0xB1CCB8 Slot: 11
	public override uint CAOGDCBPBAN()
	{
		TodoLogger.LogError(TodoLogger.DbIntegrityCheck, "JHAAHJNEBOG_LimitedCompoItem.CAOGDCBPBAN");
		return 0;
	}
}
