using System.Collections.Generic;

[System.Obsolete("Use KBCCGHLCFNO_MonthlyPass", true)]
public class KBCCGHLCFNO { }
public class KBCCGHLCFNO_MonthlyPass : DIHHCBACKGG_DbSection
{
	public class JKGFAIPDNDL
	{
		public int EHOIENNDEDH_IdCrypted; // 0x8
		public int NGBPOPMCNHH; // 0xC
		public int GFBIBNABAHB; // 0x10
		public int MPABLCHFALA; // 0x14
		public int ADKKKPFNBFO; // 0x18
		public int[] OMALMJLHABC_SetContent; // 0x1C
		public int[] ALDHNJDLNHG; // 0x20

		public int PPFNGGCBJKC_id { get { return EHOIENNDEDH_IdCrypted ^ FBGGEFFJJHB_xor; } set { EHOIENNDEDH_IdCrypted = value ^ FBGGEFFJJHB_xor; } } //0x101A7D0 DEMEPMAEJOO 0x1019DC4 HIGKAIDMOKN
		public int JJPDPNJFBHN_TableId { get { return NGBPOPMCNHH ^ FBGGEFFJJHB_xor; } set { NGBPOPMCNHH = value ^ FBGGEFFJJHB_xor; } } //0x101A634 OFDIOBMHMHA 0x1019E60 PLFBKOJLLEG
		public int BAOFEFFADPD_day { get { return GFBIBNABAHB ^ FBGGEFFJJHB_xor; } set { GFBIBNABAHB = value ^ FBGGEFFJJHB_xor; } } //0x101A6CC KHNONKOPIPO 0x101A034 LBJPPBMDOGE
		public int HNHOGHMLFNL { get { return MPABLCHFALA ^ FBGGEFFJJHB_xor; } set { MPABLCHFALA = value ^ FBGGEFFJJHB_xor; } } //0x101A868 BJJCCMJIGJG 0x1019EFC MCCPONEGMLB
		public int PHHBIBOJAEI { get { return ADKKKPFNBFO ^ FBGGEFFJJHB_xor; } set { ADKKKPFNBFO = value ^ FBGGEFFJJHB_xor; } } //0x101A900 KDCHICNAKGB 0x1019F98 NBOCNPBIPFD

		// RVA: 0x101A998 Offset: 0x101A998 VA: 0x101A998
		public int FKNBLDPIPMC(int _OIPCCBHIKIA_index)
		{
			return OMALMJLHABC_SetContent[_OIPCCBHIKIA_index * 2] ^ FBGGEFFJJHB_xor;
		}

		// // RVA: 0x101AA6C Offset: 0x101AA6C VA: 0x101AA6C
		public int KAINPNMMAEK(int _OIPCCBHIKIA_index)
		{
			return OMALMJLHABC_SetContent[_OIPCCBHIKIA_index * 2 + 1] ^ FBGGEFFJJHB_xor;
		}

		// // RVA: 0x101AB44 Offset: 0x101AB44 VA: 0x101AB44
		public int DMNJMOBEGLM()
		{
			return OMALMJLHABC_SetContent.Length / 2;
		}

		// // RVA: 0x101AB70 Offset: 0x101AB70 VA: 0x101AB70
		public int CNJELJGBCKC(int _OIPCCBHIKIA_index)
		{
			return ALDHNJDLNHG[_OIPCCBHIKIA_index * 2] ^ FBGGEFFJJHB_xor;
		}

		// // RVA: 0x101AC44 Offset: 0x101AC44 VA: 0x101AC44
		public int ACPIBCALPEH(int _OIPCCBHIKIA_index)
		{
			return ALDHNJDLNHG[_OIPCCBHIKIA_index * 2 + 1] ^ FBGGEFFJJHB_xor;
		}

		// // RVA: 0x101AD1C Offset: 0x101AD1C VA: 0x101AD1C
		public int EGBJFDGDMLG()
		{
			return ALDHNJDLNHG.Length / 2;
		}

		// // RVA: 0x101A430 Offset: 0x101A430 VA: 0x101A430
		// public uint CAOGDCBPBAN() { }
	}

	public class OFCDEIEAKLN
	{
		public int EHOIENNDEDH_IdCrypted; // 0x8
		public int NGBPOPMCNHH; // 0xC
		public int HNJHPNPFAAN_EnabledCrypted; // 0x10
		public int DAHHONMCAIH; // 0x14

		public int PPFNGGCBJKC_id { get { return EHOIENNDEDH_IdCrypted ^ FBGGEFFJJHB_xor; } set { EHOIENNDEDH_IdCrypted = value ^ FBGGEFFJJHB_xor; } } //0x101AD48 DEMEPMAEJOO 0x101ADE0 HIGKAIDMOKN
		public int JJPDPNJFBHN_TableId { get { return NGBPOPMCNHH ^ FBGGEFFJJHB_xor; } set { NGBPOPMCNHH = value ^ FBGGEFFJJHB_xor; } } //0x101AE7C OFDIOBMHMHA 0x101A0D8 PLFBKOJLLEG
		public int PLALNIIBLOF_en { get { return HNJHPNPFAAN_EnabledCrypted ^ FBGGEFFJJHB_xor; } set { HNJHPNPFAAN_EnabledCrypted = value ^ FBGGEFFJJHB_xor; } } //0x10187E8 JPCJNLHHIPE 0x101A174 JJFJNEJLBDG
		public int HIPBLKBEPAJ { get { return DAHHONMCAIH ^ FBGGEFFJJHB_xor; } set { DAHHONMCAIH = value ^ FBGGEFFJJHB_xor; } } //0x1018750 PFCFHLFHLIA 0x101A210 BLCKIAIDGDM

		// RVA: 0x101A510 Offset: 0x101A510 VA: 0x101A510
		// public uint CAOGDCBPBAN() { }
	}

	public class BJEKBPEKCIM
	{
		public int PPFNGGCBJKC_id; // 0x8
		public int PLALNIIBLOF_en; // 0xC
		public string FJGCDPLCIAK_unique_key; // 0x10
		public string OPFGFINHFCE_name; // 0x14
		public string KLMPFGOCBHC_description; // 0x18
		public string IPFEKNMBEBI_inventory_message; // 0x1C
		public long KBFOIECIADN_opened_at; // 0x20
		public long EGBOHDFBAPB_closed_at; // 0x28
		public string LOGNDDAMGDG; // 0x30
		public string BPCCIDPLDPO; // 0x34
		public string FEDODHBDGNO; // 0x38
		public string AEKNAKBFIAF; // 0x3C
	}

	public static int FBGGEFFJJHB_xor = 0x9694bcb; // 0x0
	public List<JKGFAIPDNDL> AHJNPEAMCCH_rewards; // 0x20
	public List<OFCDEIEAKLN> JHNEKMAHOPJ; // 0x24
	public List<BJEKBPEKCIM> MHKCPJDNJKI_products; // 0x28
	public static int DMDKPBPBDKD = -1; // 0x4
	private int EHKFGCPHHJJ_MasterSwCrypted; // 0x34
	private int NLLNHNGMHGP_PurchaseSwCrypted; // 0x38
	public int IPAOPMEFJKD_StartTableId; // 0x3C
	public int JOCGBFGPBCN_RateUpItemNum; // 0x40

	public Dictionary<string, CEBFFLDKAEC_SecureInt> OHJFBLFELNK_m_intParam { get; private set; } // 0x2C KLDCHOIPJGB AEMNOGNEBOJ DGKDBOAMNBB
	public Dictionary<string, string> FJOEBCMGDMI_m_stringParam { get; private set; } // 0x30 IHKPIFIBECO GAMGELHIHHI DDDEJIJGGBJ
	public int AJHBAOCLNDF_MasterSw { get { return EHKFGCPHHJJ_MasterSwCrypted ^ 0x46c0baf; } set { EHKFGCPHHJJ_MasterSwCrypted = value ^ 0x46c0baf; } } //EHDOJGNECHA 0x1018608 DAHLKLKBJDB 0x101861C
	public int ABPFEOBAFCA_PurchaseSw { get { return NLLNHNGMHGP_PurchaseSwCrypted ^ 0x46c0baf; } set { NLLNHNGMHGP_PurchaseSwCrypted = value ^ 0x46c0baf; } } //BNDFODJBKPA 0x1018630 IOCCFBIKHAO 0x1018644

	// // RVA: 0x1018460 Offset: 0x1018460 VA: 0x1018460
	public int LPJLEHAJADA_GetIntParam(string _LJNAKDMILMC_key, int _KKMJBMKHGNH_noval)
    {
		if (!OHJFBLFELNK_m_intParam.ContainsKey(_LJNAKDMILMC_key))
			return _KKMJBMKHGNH_noval;
		return OHJFBLFELNK_m_intParam[_LJNAKDMILMC_key].DNJEJEANJGL_Value;
    }

	// // RVA: 0x1018544 Offset: 0x1018544 VA: 0x1018544
	public string EFEGBHACJAL_GetStringParam(string _LJNAKDMILMC_key, string _KKMJBMKHGNH_noval)
	{
		if (!FJOEBCMGDMI_m_stringParam.ContainsKey(_LJNAKDMILMC_key))
			return _KKMJBMKHGNH_noval;
		return FJOEBCMGDMI_m_stringParam[_LJNAKDMILMC_key];
	}

	// // RVA: 0x1018658 Offset: 0x1018658 VA: 0x1018658
	public int MAOBENAPFNI(int POMMEMHCDCA)
	{
		if (JHNEKMAHOPJ[JHNEKMAHOPJ[POMMEMHCDCA - 1].HIPBLKBEPAJ - 1].PLALNIIBLOF_en != 2)
			return POMMEMHCDCA;
		return JHNEKMAHOPJ[POMMEMHCDCA - 1].HIPBLKBEPAJ;
	}

	// // RVA: 0x1018880 Offset: 0x1018880 VA: 0x1018880
	public JKGFAIPDNDL DHBEKJNJOMC(int ADECCOKCCDH, int _BAOFEFFADPD_day)
	{
		return AHJNPEAMCCH_rewards.Find((JKGFAIPDNDL _GHPLINIACBB_x) =>
		{
			//0x101A5C8
			if (_GHPLINIACBB_x.JJPDPNJFBHN_TableId != ADECCOKCCDH)
				return false;
			return _GHPLINIACBB_x.BAOFEFFADPD_day == _BAOFEFFADPD_day;
		});
	}

	// // RVA: 0x101899C Offset: 0x101899C VA: 0x101899C
	// public KBCCGHLCFNO.JKGFAIPDNDL LPPKMMLKHJB(int ADECCOKCCDH, int _BAOFEFFADPD_day) { }

	// RVA: 0x1018AB8 Offset: 0x1018AB8 VA: 0x1018AB8
	public KBCCGHLCFNO_MonthlyPass()
    {
		JIKKNHIAEKG_BlockName = "";
		LNIMEIMBCMF = false;
		AHJNPEAMCCH_rewards = new List<JKGFAIPDNDL>();
		JHNEKMAHOPJ = new List<OFCDEIEAKLN>();
		MHKCPJDNJKI_products = new List<BJEKBPEKCIM>();
		OHJFBLFELNK_m_intParam = new Dictionary<string, CEBFFLDKAEC_SecureInt>();
		FJOEBCMGDMI_m_stringParam = new Dictionary<string, string>();
		LMHMIIKCGPE = 61;
    }

	// // RVA: 0x1018C7C Offset: 0x1018C7C VA: 0x1018C7C Slot: 8
	protected override void KMBPACJNEOF_Reset()
    {
		AHJNPEAMCCH_rewards.Clear();
		JHNEKMAHOPJ.Clear();
		MHKCPJDNJKI_products.Clear();
		OHJFBLFELNK_m_intParam.Clear();
		FJOEBCMGDMI_m_stringParam.Clear();
		AJHBAOCLNDF_MasterSw = 0;
		ABPFEOBAFCA_PurchaseSw = 0;
    }

	// // RVA: 0x1018DB4 Offset: 0x1018DB4 VA: 0x1018DB4 Slot: 9
	public override bool IIEMACPEEBJ_Deserialize(byte[] _DBBGALAPFGC_bytes)
    {
		OJMIALAOHDB parser = OJMIALAOHDB.HEGEKFMJNCC(_DBBGALAPFGC_bytes);
		{
			HEOGJLOJPIL[] array = parser.KBAPCGNEBJO;
			for(int i = 0; i < array.Length; i++)
			{
				JKGFAIPDNDL data = new JKGFAIPDNDL();
				data.PPFNGGCBJKC_id = array[i].PPFNGGCBJKC;
				data.JJPDPNJFBHN_TableId = array[i].JJPDPNJFBHN;
				data.HNHOGHMLFNL = array[i].HNHOGHMLFNL;
				data.PHHBIBOJAEI = array[i].PHHBIBOJAEI;
				data.BAOFEFFADPD_day = array[i].BAOFEFFADPD;
				int[] array2 = array[i].PIPDCAEIBPO;
				data.OMALMJLHABC_SetContent = new int[array2.Length];
				int[] array3 = array[i].PHEMGKGKAFB;
				data.ALDHNJDLNHG = new int[array3.Length];
				for(int j = 0; j < array2.Length; j++)
				{
					data.OMALMJLHABC_SetContent[j] = array2[j] ^ FBGGEFFJJHB_xor;
				}
				for (int j = 0; j < array3.Length; j++)
				{
					data.ALDHNJDLNHG[j] = array3[j] ^ FBGGEFFJJHB_xor;
				}
				AHJNPEAMCCH_rewards.Add(data);
			}
		}
		{
			GAEDIGFIDLL[] array = parser.KNBGFOICNHF;
			for(int i = 0; i < array.Length; i++)
			{
				OFCDEIEAKLN data = new OFCDEIEAKLN();
				data.JJPDPNJFBHN_TableId = array[i].JJPDPNJFBHN;
				data.PLALNIIBLOF_en = JKAECBCNHAN_IsEnabled(array[i].IJEKNCDIIAE, array[i].PLALNIIBLOF, 0);
				data.HIPBLKBEPAJ = array[i].HIPBLKBEPAJ;
				JHNEKMAHOPJ.Add(data);
			}
		}
		{
			FPKIOKPFHHJ[] array = parser.LLACOLKBNOH;
			for (int i = 0; i < array.Length; i++)
			{
				BJEKBPEKCIM data = new BJEKBPEKCIM();
				data.PPFNGGCBJKC_id = array[i].PPFNGGCBJKC;
				data.PLALNIIBLOF_en = JKAECBCNHAN_IsEnabled(array[i].IJEKNCDIIAE, array[i].PLALNIIBLOF, 0);
				data.FJGCDPLCIAK_unique_key = array[i].FJGCDPLCIAK;
				data.OPFGFINHFCE_name = array[i].OPFGFINHFCE;
				data.KLMPFGOCBHC_description = array[i].KLMPFGOCBHC;
				data.IPFEKNMBEBI_inventory_message = array[i].IPFEKNMBEBI;
				data.KBFOIECIADN_opened_at = array[i].KBFOIECIADN;
				data.EGBOHDFBAPB_closed_at = array[i].EGBOHDFBAPB;
				data.LOGNDDAMGDG = array[i].LOGNDDAMGDG;
				data.BPCCIDPLDPO = array[i].BPCCIDPLDPO;
				data.FEDODHBDGNO = array[i].FEDODHBDGNO;
				data.AEKNAKBFIAF = array[i].AEKNAKBFIAF;
				MHKCPJDNJKI_products.Add(data);
			}
		}
		{
			PLCJOKMDGPL[] array = parser.BHGDNGHDDAC;
			for (int i = 0; i < array.Length; i++)
			{
				CEBFFLDKAEC_SecureInt data = new CEBFFLDKAEC_SecureInt();
				data.DNJEJEANJGL_Value = array[i].JBGEEPFKIGG;
				OHJFBLFELNK_m_intParam.Add(array[i].LJNAKDMILMC, data);
			}
		}
		{
			KNEDODAEFHJ[] array = parser.MHGMDJNOLMI;
			for (int i = 0; i < array.Length; i++)
			{
				FJOEBCMGDMI_m_stringParam.Add(array[i].LJNAKDMILMC, array[i].JBGEEPFKIGG);
			}
		}
		AJHBAOCLNDF_MasterSw = LPJLEHAJADA_GetIntParam("master_sw", 1);
		ABPFEOBAFCA_PurchaseSw = LPJLEHAJADA_GetIntParam("purcahse_sw", 1);
		IPAOPMEFJKD_StartTableId = LPJLEHAJADA_GetIntParam("start_table_id", 1);
		JOCGBFGPBCN_RateUpItemNum = LPJLEHAJADA_GetIntParam("rareupitem_num", 9);
        return true;
    }

	// // RVA: 0x101A2B4 Offset: 0x101A2B4 VA: 0x101A2B4 Slot: 10
	public override bool IIEMACPEEBJ_Deserialize(EDOHBJAPLPF_JsonData OILEIIEIBHP, int _KAPMOPMDHJE_label)
	{
		return true;
	}

	// // RVA: 0x101A2BC Offset: 0x101A2BC VA: 0x101A2BC Slot: 11
	public override uint CAOGDCBPBAN()
	{
		TodoLogger.LogError(TodoLogger.DbIntegrityCheck, "KBCCGHLCFNO_MonthlyPass.CAOGDCBPBAN");
		return 0;
	}
}
