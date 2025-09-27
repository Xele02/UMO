
using System.Collections.Generic;
using XeSys;

[System.Obsolete("Use BKPAPCMJKHE_Shop", true)]
public class BKPAPCMJKHE { }
public class BKPAPCMJKHE_Shop : DIHHCBACKGG_DbSection
{
	public class DNOENEKHGMI
	{
		public string NEMKDKDIIDK_ShopName; // 0x8
		public long IBCNABKLHHH_StartCrypted; // 0x10
		public long MABPKDKBJAG_CloseAtCrypted; // 0x18
		public int LJBEJEFBDMJ; // 0x20
		public int JMLCKCMIKII; // 0x24
		public int BJJLBHBCENG; // 0x28
		public int MMJEPJKPHHE; // 0x2C
		public int OIFAFKDMEEJ_EnabledCrypted; // 0x30
		public int MKHGNAKFPBE; // 0x34
		public int FBGGEFFJJHB_xor; // 0x38
		public int OMMLFMMBOFC; // 0x3C
		public int HHPFFPINGAA_OrderCrypted; // 0x40
		public int LDCHDEEKMJO; // 0x44

		public long KJBGCLPMLCG_OpenedAt { get { return IBCNABKLHHH_StartCrypted ^ FBGGEFFJJHB_xor; } set { IBCNABKLHHH_StartCrypted = value ^ FBGGEFFJJHB_xor; } } //0x19B5C6C IDLJOCDJJOC 0x19B54FC ODIEKGPKOAC
		public long GJFPFFBAKGK_CloseAt { get { return MABPKDKBJAG_CloseAtCrypted ^ FBGGEFFJJHB_xor; } set { MABPKDKBJAG_CloseAtCrypted = value ^ FBGGEFFJJHB_xor; }  } //0x19B3B94 KPBMCJKFEGN 0x19B5510 IEFCDGKGICA
		public int OPKDAIMPJBH_ShopId { get { return LJBEJEFBDMJ ^ FBGGEFFJJHB_xor; } set { LJBEJEFBDMJ = value ^ FBGGEFFJJHB_xor; } } //0x19B5C80 AOCDPGPPMHN 0x19B5544 FAHCKCGKHIO
		public int PPEGAKEIEGM_Enabled { get { return OIFAFKDMEEJ_EnabledCrypted ^ FBGGEFFJJHB_xor; } set { OIFAFKDMEEJ_EnabledCrypted = value ^ FBGGEFFJJHB_xor; } } //0x19B3B64 KPOEEPIMMJP 0x19B5574 NCIEAFEDPBH
		public int EAHPLCJMPHD_PId { get { return JMLCKCMIKII ^ FBGGEFFJJHB_xor; } set { JMLCKCMIKII = value ^ FBGGEFFJJHB_xor; } } //0x19B5C90 NMDECGCDKNM 0x19B5534 PGNAAAGJOBO PayItemId
		public int HCCEFDMGPEA { get { return MMJEPJKPHHE ^ FBGGEFFJJHB_xor; } set { MMJEPJKPHHE = value ^ FBGGEFFJJHB_xor; } } //0x19B3B74 MAEOBCEBMDC 0x19B5554 BFFBMOIGFBI
		public int IBAKPKKEDJM_month { get { return MKHGNAKFPBE ^ FBGGEFFJJHB_xor; } set { MKHGNAKFPBE = value ^ FBGGEFFJJHB_xor; } } //0x19B3B84 IJHAHFOOJKH 0x19B54EC LNKIOJGIKMB
		public int FPJBMCDMAMO { get { return OMMLFMMBOFC ^ FBGGEFFJJHB_xor; } set { OMMLFMMBOFC = value ^ FBGGEFFJJHB_xor; } } //0x19B5CA0 JBJCDOHLLKK 0x19B5584 JEFGPFMEONF
		public int EFNMDPKEJIM_LineupId { get { return BJJLBHBCENG ^ FBGGEFFJJHB_xor; } set { BJJLBHBCENG = value ^ FBGGEFFJJHB_xor; } } //0x19B5CAC GDECNFAFAMM 0x19B54DC MMJDPGLLFNI
		public int EILKGEADKGH_Order { get { return HHPFFPINGAA_OrderCrypted ^ FBGGEFFJJHB_xor; } set { HHPFFPINGAA_OrderCrypted = value ^ FBGGEFFJJHB_xor; } } //0x19B5CBC NPDDACIHBKD 0x19B5524 BJJMCKHBPNH
		public int JPGALGPNJAI_VcId { get { return LDCHDEEKMJO ^ FBGGEFFJJHB_xor; } set { LDCHDEEKMJO = value ^ FBGGEFFJJHB_xor; } } //0x19B5CCC GHFHDABMBCL 0x19B5564 AGNACDEALEO

		//// RVA: 0x19B5A38 Offset: 0x19B5A38 VA: 0x19B5A38
		//public uint CAOGDCBPBAN() { }
	}

	public class BOMCAJJCPME
	{
		public int ICKAMKNDAEB_Label; // 0x8
		public long IBCNABKLHHH_StartCrypted; // 0x10
		public long MABPKDKBJAG_CloseAtCrypted; // 0x18
		public int NBGGOMCCMPJ; // 0x20
		public int KGJMFDPKIPE; // 0x24
		public int OMMLFMMBOFC; // 0x28
		public int CKNFCDCKFDE_CountCrypted; // 0x2C
		public int OIFAFKDMEEJ_EnabledCrypted; // 0x30
		public int FBGGEFFJJHB_xor; // 0x34
		public int BOELIGECGJD_Crypted; // 0x38
		public int HHPFFPINGAA_OrderCrypted; // 0x3C

		public long KJBGCLPMLCG_OpenedAt { get { return IBCNABKLHHH_StartCrypted ^ FBGGEFFJJHB_xor; } set { IBCNABKLHHH_StartCrypted = value ^ FBGGEFFJJHB_xor; } } //0x19B5BD8 IDLJOCDJJOC 0x19B55EC ODIEKGPKOAC
		public long GJFPFFBAKGK_CloseAt { get { return MABPKDKBJAG_CloseAtCrypted ^ FBGGEFFJJHB_xor; } set { MABPKDKBJAG_CloseAtCrypted = value ^ FBGGEFFJJHB_xor; } } //0x19B5BEC KPBMCJKFEGN 0x19B5600 IEFCDGKGICA
		public int AFKAGFOFAHM_ProductId { get { return NBGGOMCCMPJ ^ FBGGEFFJJHB_xor; } set { NBGGOMCCMPJ = value ^ FBGGEFFJJHB_xor; } } //0x19B5C00 IGKEDHAIDGK 0x19B55DC JPIJBPNFMLN
		public int PPEGAKEIEGM_Enabled { get { return OIFAFKDMEEJ_EnabledCrypted ^ FBGGEFFJJHB_xor; } set { OIFAFKDMEEJ_EnabledCrypted = value ^ FBGGEFFJJHB_xor; } } //0x19B5C10 KPOEEPIMMJP 0x19B5614 NCIEAFEDPBH
		public int EFNMDPKEJIM_LineupId { get { return KGJMFDPKIPE ^ FBGGEFFJJHB_xor; } set { KGJMFDPKIPE = value ^ FBGGEFFJJHB_xor; } } //0x19B5C1C GDECNFAFAMM 0x19B55BC MMJDPGLLFNI
		// BuyLimit
		public int JLENMGOCHDG_Count { get { return CKNFCDCKFDE_CountCrypted ^ FBGGEFFJJHB_xor; } set { CKNFCDCKFDE_CountCrypted = value ^ FBGGEFFJJHB_xor; } } //0x19B5C2C OLJEIELPFMC 0x19B559C JMNGGBCNLJN
		public int EILKGEADKGH_Order { get { return HHPFFPINGAA_OrderCrypted ^ FBGGEFFJJHB_xor; } set { HHPFFPINGAA_OrderCrypted = value ^ FBGGEFFJJHB_xor; } } //0x19B5C3C NPDDACIHBKD 0x19B55CC BJJMCKHBPNH
		public int GJGNOFAPFJD { get { return BOELIGECGJD_Crypted ^ FBGGEFFJJHB_xor; } set { BOELIGECGJD_Crypted = value ^ FBGGEFFJJHB_xor; } } //0x19B5C4C JAGHPMNNEPG 0x19B55AC FACIELLBLMP
		public int FPJBMCDMAMO { get { return OMMLFMMBOFC ^ FBGGEFFJJHB_xor; } set { OMMLFMMBOFC = value ^ FBGGEFFJJHB_xor; } } //0x19B5C5C JBJCDOHLLKK 0x19B5624 JEFGPFMEONF

		//// RVA: 0x19B5AC0 Offset: 0x19B5AC0 VA: 0x19B5AC0
		//public uint CAOGDCBPBAN() { }
	}

	public class GPNPMJJKONJ
	{
		public int BOELIGECGJD_Crypted; // 0x8
		public int KMIKFOHJFPA; // 0xC
		public int FBGGEFFJJHB_xor; // 0x10
		public int KMGPNCCNNAK; // 0x14
		public int GINNJCGGEKM; // 0x18
		public int GBCJJADIEAD; // 0x1C

		public int GJGNOFAPFJD { get { return BOELIGECGJD_Crypted ^ FBGGEFFJJHB_xor; } set { BOELIGECGJD_Crypted = value ^ FBGGEFFJJHB_xor; } } //0x19B5CDC JAGHPMNNEPG 0x19B563C FACIELLBLMP
		public int LMMCMHHAGBJ_ItemCostFullId { get { return GINNJCGGEKM ^ FBGGEFFJJHB_xor; } set { GINNJCGGEKM = value ^ FBGGEFFJJHB_xor; } } //0x19B5CEC BKOBPJBDPFG 0x19B564C OECHFCHOPFH
		public int CMEIMAMOMPI_Price { get { return KMIKFOHJFPA ^ FBGGEFFJJHB_xor; } set { KMIKFOHJFPA = value ^ FBGGEFFJJHB_xor; } } //0x19B5CFC HELOEMEKCPD 0x19B565C DNGNBHNCMPF
		public int EJHMPCJNHBP_ItemFullId { get { return GBCJJADIEAD ^ FBGGEFFJJHB_xor; } set { GBCJJADIEAD = value ^ FBGGEFFJJHB_xor; } } //0x19B5D0C CNEFJKJDBAE 0x19B566C DJCFJNBEPJG
		public int LBCNKLPIMHL_Count { get { return KMGPNCCNNAK ^ FBGGEFFJJHB_xor; } set { KMGPNCCNNAK = value ^ FBGGEFFJJHB_xor; } } //0x19B5D1C NCHJGHNJOCO 0x19B567C EPEIFLOGFHJ

		//// RVA: 0x19B5B3C Offset: 0x19B5B3C VA: 0x19B5B3C
		//public uint CAOGDCBPBAN() { }
	}

	public class HALAHNKGPFH
	{
		public int FBGGEFFJJHB_xor; // 0x8
		public int LCHBLBDIIGE; // 0xC
		public int PLCMLMADCDD_MinCrypted; // 0x10
		public int IIHILCBMPIH; // 0x14
		public int LCGJKAGIFGO_MaxCrypted; // 0x18
		public int DFPHFMCMONM; // 0x1C

		public int POFDDFCGEGP_Underscore { get { return LCHBLBDIIGE ^ FBGGEFFJJHB_xor; } set { LCHBLBDIIGE = value ^ FBGGEFFJJHB_xor; } } //0x19B5D2C IMNKDCLKMEM 0x19B5694 GKGJKCNDNLF
		public int NNDBJGDFEEM_Min { get { return PLCMLMADCDD_MinCrypted ^ FBGGEFFJJHB_xor; } set { PLCMLMADCDD_MinCrypted = value ^ FBGGEFFJJHB_xor; } } //0x19B5D3C EHNOFMPHLFC 0x19B56A4 GCANPOPEKEE
		public int DOOGFEGEKLG_max { get { return LCGJKAGIFGO_MaxCrypted ^ FBGGEFFJJHB_xor; } set { LCGJKAGIFGO_MaxCrypted = value ^ FBGGEFFJJHB_xor; } } //0x19B5D4C AECMFIOFFJN 0x19B56B4 NGOJJDOCIDG
		public int NOMCDEPGIEC { get { return IIHILCBMPIH ^ FBGGEFFJJHB_xor; } set { IIHILCBMPIH = value ^ FBGGEFFJJHB_xor; } } //0x19B5D5C JNOBFNFKMMO 0x19B56C4 MHMCCOKPFHP
		public int MMLMEAJPPJE { get { return DFPHFMCMONM ^ FBGGEFFJJHB_xor; } set { DFPHFMCMONM = value ^ FBGGEFFJJHB_xor; } } //0x19B5D6C JCHOHBPNBDB 0x19B56D4 HLOMOKGCJKK

		//// RVA: 0x19B5B88 Offset: 0x19B5B88 VA: 0x19B5B88
		//public uint CAOGDCBPBAN() { }
	}

	public class IHBIOGDPJIN
	{
		public int FBGGEFFJJHB_xor; // 0x8
		public int FPJBMCDMAMO; // 0xC
		public long IBCNABKLHHH_StartCrypted; // 0x10
		public long MABPKDKBJAG_CloseAtCrypted; // 0x18
		public int HKHLEFMLIGA; // 0x20
		public int GNGNIKNNCNH_MVerCrypted; // 0x24
		public int HNJHPNPFAAN_EnabledCrypted; // 0x28

		public long KJBGCLPMLCG_OpenedAt { get { return IBCNABKLHHH_StartCrypted ^ FBGGEFFJJHB_xor; } set { IBCNABKLHHH_StartCrypted = value ^ FBGGEFFJJHB_xor; } } //0x19B38A8 IDLJOCDJJOC 0x19B56EC ODIEKGPKOAC
		public long GJFPFFBAKGK_CloseAt { get { return MABPKDKBJAG_CloseAtCrypted ^ FBGGEFFJJHB_xor; } set { MABPKDKBJAG_CloseAtCrypted = value ^ FBGGEFFJJHB_xor; } } //0x19B38C0 KPBMCJKFEGN 0x19B5700 IEFCDGKGICA
		public int INHOGJODJFJ_GroupId { get { return HKHLEFMLIGA ^ FBGGEFFJJHB_xor; } set { HKHLEFMLIGA = value ^ FBGGEFFJJHB_xor; } } //0x19B5D7C MIHPGFMJEED 0x19B5714 NBGJAEFAENJ
		public int IJEKNCDIIAE_mver { get { return GNGNIKNNCNH_MVerCrypted ^ FBGGEFFJJHB_xor; } set { GNGNIKNNCNH_MVerCrypted = value ^ FBGGEFFJJHB_xor; } } //0x19B5D8C KJIMMIBDCIL 0x19B5724 DMEGNOKIKCD
		public int PLALNIIBLOF_en { get { return HNJHPNPFAAN_EnabledCrypted ^ FBGGEFFJJHB_xor; } set { HNJHPNPFAAN_EnabledCrypted = value ^ FBGGEFFJJHB_xor; } } //0x19B5D9C JPCJNLHHIPE 0x19B5734 JJFJNEJLBDG

		//// RVA: 0x19B5DAC Offset: 0x19B5DAC VA: 0x19B5DAC
		//public uint CAOGDCBPBAN() { }
	}

	public List<int> DJGJIMCOPHG_ItemCatTab; // 0x38
	public int IEHAJFDMGEJ_DecoTabNum; // 0x3C

	public List<DNOENEKHGMI> CDENCMNHNGA_table { get; private set; } // 0x20 GIODFKFCBMO JDMECLDHNOF ILHOADLEJPB
	public List<BOMCAJJCPME> MHKCPJDNJKI_products { get; private set; } // 0x24 CPMNDNELDME DFAHGPEFPOO IOMCCGAKKCP
	public List<GPNPMJJKONJ> HMKKLPPEOHL { get; private set; } // 0x28 KLGEEBCHBKP LFKCGDAOEAC NMHJKDPOEME
	public List<HALAHNKGPFH> FLPICDDOOBH { get; private set; } // 0x2C GOJFEJEGKIC BECPDMCKJIB OBKFENLIGGF
	public List<IHBIOGDPJIN> EDLJEPAFLEK { get; private set; } // 0x30 HLPMNLBOAOE KCAPDIFFLJF HPIKMODJOLD
	public Dictionary<string, CEBFFLDKAEC_SecureInt> OHJFBLFELNK_m_intParam { get; private set; } // 0x34 KLDCHOIPJGB AEMNOGNEBOJ DGKDBOAMNBB

	//// RVA: 0x19B3660 Offset: 0x19B3660 VA: 0x19B3660
	public int LPJLEHAJADA_GetIntParam(string _LJNAKDMILMC_key, int _KKMJBMKHGNH_noval)
	{
		if (!OHJFBLFELNK_m_intParam.ContainsKey(_LJNAKDMILMC_key))
			return _KKMJBMKHGNH_noval;
		return OHJFBLFELNK_m_intParam[_LJNAKDMILMC_key].DNJEJEANJGL_Value;
	}

	//// RVA: 0x19B3744 Offset: 0x19B3744 VA: 0x19B3744
	public bool JIFKFKJPANC(int ODNILEDOAIP, long _EOLFJGMAJAB_CurrentTime)
	{
		if(ODNILEDOAIP > 0)
		{
			if(ODNILEDOAIP <= EDLJEPAFLEK.Count)
			{
				if(_EOLFJGMAJAB_CurrentTime >= EDLJEPAFLEK[ODNILEDOAIP - 1].KJBGCLPMLCG_OpenedAt && EDLJEPAFLEK[ODNILEDOAIP - 1].GJFPFFBAKGK_CloseAt >= _EOLFJGMAJAB_CurrentTime)
				{
					return true;
				}
			}
		}
		return false;
	}

	//// RVA: 0x19B38D8 Offset: 0x19B38D8 VA: 0x19B38D8
	public long LELDGMBGEAO(int _IBAKPKKEDJM_month)
	{
		long res = 0;
		for(int i = 0; i < CDENCMNHNGA_table.Count; i++)
		{
			if(CDENCMNHNGA_table[i].PPEGAKEIEGM_Enabled == 2)
			{
				if(CDENCMNHNGA_table[i].HCCEFDMGPEA == 2)
				{
					if(CDENCMNHNGA_table[i].IBAKPKKEDJM_month == _IBAKPKKEDJM_month)
					{
						if(res < CDENCMNHNGA_table[i].GJFPFFBAKGK_CloseAt)
						{
							res = CDENCMNHNGA_table[i].GJFPFFBAKGK_CloseAt;
						}
					}
				}
			}
		}
		return res;
	}

	// RVA: 0x19B3BA8 Offset: 0x19B3BA8 VA: 0x19B3BA8
	public BKPAPCMJKHE_Shop()
	{
		JIKKNHIAEKG_BlockName = "";
		LNIMEIMBCMF = false;
		CDENCMNHNGA_table = new List<DNOENEKHGMI>();
		MHKCPJDNJKI_products = new List<BOMCAJJCPME>();
		HMKKLPPEOHL = new List<GPNPMJJKONJ>();
		FLPICDDOOBH = new List<HALAHNKGPFH>();
		EDLJEPAFLEK = new List<IHBIOGDPJIN>();
		OHJFBLFELNK_m_intParam = new Dictionary<string, CEBFFLDKAEC_SecureInt>();
		LMHMIIKCGPE = 74;
		DJGJIMCOPHG_ItemCatTab = new List<int>();
	}

	// RVA: 0x19B3DD4 Offset: 0x19B3DD4 VA: 0x19B3DD4 Slot: 8
	protected override void KMBPACJNEOF_Reset()
	{
		CDENCMNHNGA_table.Clear();
		MHKCPJDNJKI_products.Clear();
		HMKKLPPEOHL.Clear();
		FLPICDDOOBH.Clear();
		OHJFBLFELNK_m_intParam.Clear();
		EDLJEPAFLEK.Clear();
		DJGJIMCOPHG_ItemCatTab.Clear();
	}

	// RVA: 0x19B3F54 Offset: 0x19B3F54 VA: 0x19B3F54 Slot: 9
	public override bool IIEMACPEEBJ_Deserialize(byte[] _DBBGALAPFGC_bytes)
	{
		EBLAAOGMLIJ parser = EBLAAOGMLIJ.HEGEKFMJNCC(_DBBGALAPFGC_bytes);
		HPECBBKKMMF(parser);
		IDNCPMHNHEE(parser);
		KOBCANBABDO(parser);
		PHIMFOACHEE(parser);
		KPAIPNIAAIF(parser);
		AJKEEJDFAIH(parser);
		bool b = false;
		for(int i = 0; i < 45; i++)
		{
			string s = "item_category_tab_" + i;
			int l = -1;
			if(OHJFBLFELNK_m_intParam.ContainsKey(s))
			{
				b = true;
				l = OHJFBLFELNK_m_intParam[s].DNJEJEANJGL_Value;
			}
			DJGJIMCOPHG_ItemCatTab.Add(l);
		}
		IEHAJFDMGEJ_DecoTabNum = LPJLEHAJADA_GetIntParam("deco_tab_num", 4);
		if(!b)
		{
			DJGJIMCOPHG_ItemCatTab[28] = 0;
			DJGJIMCOPHG_ItemCatTab[29] = 1;
			DJGJIMCOPHG_ItemCatTab[27] = 2;
			DJGJIMCOPHG_ItemCatTab[39] = 3;
		}
		return true;
	}

	// RVA: 0x19B54CC Offset: 0x19B54CC VA: 0x19B54CC Slot: 10
	public override bool IIEMACPEEBJ_Deserialize(EDOHBJAPLPF_JsonData OILEIIEIBHP, int _KAPMOPMDHJE_label)
	{
		return true;
	}

	//// RVA: 0x19B4218 Offset: 0x19B4218 VA: 0x19B4218
	private bool HPECBBKKMMF(EBLAAOGMLIJ JMHECKKKMLK)
	{
		int k = (int)Utility.GetCurrentUnixTime();
		int k2 = k * 0x5e7;
		ILEKHFDFOEH[] array = JMHECKKKMLK.IGEOPMBHHAM;
		for(int i = 0; i < array.Length; i++)
		{
			DNOENEKHGMI data = new DNOENEKHGMI();
			data.FBGGEFFJJHB_xor = k2;
			data.EFNMDPKEJIM_LineupId = array[i].GHNAPCBBEHH;
			data.IBAKPKKEDJM_month = array[i].IBAKPKKEDJM_month;
			data.KJBGCLPMLCG_OpenedAt = array[i].PDBPFJJCADD_open_at;
			data.GJFPFFBAKGK_CloseAt = array[i].FDBNFFNFOND_close_at;
			//if(data.GJFPFFBAKGK_CloseAt != 0)
			//	data.GJFPFFBAKGK_CloseAt = Utility.GetCurrentUnixTime() + 24 * 3600;// UMO unlimited end date
			data.EILKGEADKGH_Order = array[i].EILKGEADKGH_Order;
			data.EAHPLCJMPHD_PId = array[i].KNHOMNONOEB_AssetId;
			data.OPKDAIMPJBH_ShopId = array[i].CIOKHGPEEKE_sid;
			data.NEMKDKDIIDK_ShopName = DatabaseTextConverter.TranslateShopName(i, array[i].IIPIPIABGDG_nam);
			data.HCCEFDMGPEA = array[i].GBJFNGCDKPM_typ;
			data.OPKDAIMPJBH_ShopId = array[i].CIOKHGPEEKE_sid;
			data.JPGALGPNJAI_VcId = array[i].JPGALGPNJAI_VcId;
			data.PPEGAKEIEGM_Enabled = JKAECBCNHAN_IsEnabled(array[i].IJEKNCDIIAE_mver, array[i].PLALNIIBLOF_en, 0);
			data.FPJBMCDMAMO = array[i].AHEFJKEICLM;
			CDENCMNHNGA_table.Add(data);
			k2 *= 0xb;
		}
		return true;
	}

	//// RVA: 0x19B4688 Offset: 0x19B4688 VA: 0x19B4688
	private bool IDNCPMHNHEE(EBLAAOGMLIJ JMHECKKKMLK)
	{
		int k = (int)Utility.GetCurrentUnixTime();
		k *= 0x5e7;
		JPCFDBADANB[] array = JMHECKKKMLK.LLACOLKBNOH;
		for(int i = 0; i < array.Length; i++)
		{
			BOMCAJJCPME data = new BOMCAJJCPME();
			data.FBGGEFFJJHB_xor = k;
			data.JLENMGOCHDG_Count = array[i].KMFLNILNPJD;
			if(RuntimeSettings.CurrentSettings.RemoveShopLimit)
				data.JLENMGOCHDG_Count = -1;
			data.GJGNOFAPFJD = array[i].JBFLEDKDFCO_cid;
			data.EFNMDPKEJIM_LineupId = array[i].GHNAPCBBEHH;
			data.EILKGEADKGH_Order = array[i].EILKGEADKGH_Order;
			data.AFKAGFOFAHM_ProductId = array[i].MJMPANIBFED_pid;
			data.KJBGCLPMLCG_OpenedAt = array[i].PDBPFJJCADD_open_at;
			data.GJFPFFBAKGK_CloseAt = array[i].FDBNFFNFOND_close_at;
			if(data.GJFPFFBAKGK_CloseAt != 0)
				data.GJFPFFBAKGK_CloseAt = Utility.GetTargetUnixTime(2100, 1, 1, 0, 0, 0);// UMO unlimited end date
			data.ICKAMKNDAEB_Label = array[i].DLCGAMHADEN_Label;
			data.PPEGAKEIEGM_Enabled = JKAECBCNHAN_IsEnabled(array[i].IJEKNCDIIAE_mver, array[i].PLALNIIBLOF_en, 0);
			data.FPJBMCDMAMO = array[i].AHEFJKEICLM;
			MHKCPJDNJKI_products.Add(data);
			k *= 0x13;
		}
		return true;
	}

	//// RVA: 0x19B4A78 Offset: 0x19B4A78 VA: 0x19B4A78
	private bool KOBCANBABDO(EBLAAOGMLIJ JMHECKKKMLK)
	{
		int k = (int)Utility.GetCurrentUnixTime();
		k *= 0x310;
		k |= 2;
		KCAFKJHPMBD[] array = JMHECKKKMLK.FOGEDIJHNMB;
		for(int i = 0; i < array.Length; i++)
		{
			GPNPMJJKONJ data = new GPNPMJJKONJ();
			data.FBGGEFFJJHB_xor = k;
			data.GJGNOFAPFJD = array[i].JBFLEDKDFCO_cid;
			data.LMMCMHHAGBJ_ItemCostFullId = array[i].EENKMPGFAIC;
			data.CMEIMAMOMPI_Price = array[i].NOMHGPEKHPF;
			data.EJHMPCJNHBP_ItemFullId = array[i].JKHDLPJHGBK;
			data.LBCNKLPIMHL_Count = array[i].NLIMHCILPFE;
			HMKKLPPEOHL.Add(data);
			k *= 0xb;
		}
		return true;
	}

	//// RVA: 0x19B4D20 Offset: 0x19B4D20 VA: 0x19B4D20
	private bool PHIMFOACHEE(EBLAAOGMLIJ JMHECKKKMLK)
	{
		int k = (int)Utility.GetCurrentUnixTime();
		k *= 0x2e5;
		k += 9;
		NHLGHMCNLML[] array = JMHECKKKMLK.JPDDILNAKPH;
		for(int i = 0; i < array.Length; i++)
		{
			HALAHNKGPFH data = new HALAHNKGPFH();
			data.FBGGEFFJJHB_xor = k;
			data.POFDDFCGEGP_Underscore = array[i].POFDDFCGEGP_Underscore;
			data.NNDBJGDFEEM_Min = array[i].NNDBJGDFEEM_Min;
			data.DOOGFEGEKLG_max = array[i].DOOGFEGEKLG_max;
			data.NOMCDEPGIEC = array[i].DMOPADCLBKD;
			data.MMLMEAJPPJE = array[i].GIPGIGDBFHL;
			FLPICDDOOBH.Add(data);
			k *= 0xc;
		}
		return true;
	}

	//// RVA: 0x19B4FC8 Offset: 0x19B4FC8 VA: 0x19B4FC8
	private bool KPAIPNIAAIF(EBLAAOGMLIJ JMHECKKKMLK)
	{
		int k = (int)Utility.GetCurrentUnixTime();
		OHFBGFGCHFF[] array = JMHECKKKMLK.BHGDNGHDDAC;
		for(int i = 0; i < array.Length; i++)
		{
			CEBFFLDKAEC_SecureInt data = new CEBFFLDKAEC_SecureInt();
			data.DNJEJEANJGL_Value = array[i].JBGEEPFKIGG_val;
			OHJFBLFELNK_m_intParam.Add(array[i].LJNAKDMILMC_key, data);
		}
		return true;
	}

	//// RVA: 0x19B51B8 Offset: 0x19B51B8 VA: 0x19B51B8
	private bool AJKEEJDFAIH(EBLAAOGMLIJ JMHECKKKMLK)
	{
		IPGOMEABJBG[] array = JMHECKKKMLK.HBKOMBJJBIG;
		for (int i = 0; i < array.Length; i++)
		{
			IHBIOGDPJIN data = new IHBIOGDPJIN();
			data.FBGGEFFJJHB_xor = LPDNKHAIOLH.CEIBAFOCNCA();
			data.KJBGCLPMLCG_OpenedAt = array[i].PDBPFJJCADD_open_at;
			data.GJFPFFBAKGK_CloseAt = array[i].FDBNFFNFOND_close_at;
			//if(data.GJFPFFBAKGK_CloseAt != 0)
			//	data.GJFPFFBAKGK_CloseAt = Utility.GetCurrentUnixTime() + 24 * 3600;// UMO unlimited end date
			data.INHOGJODJFJ_GroupId = array[i].FEFDGBPFKBJ_gid;
			data.IJEKNCDIIAE_mver = array[i].IJEKNCDIIAE_mver;
			data.PLALNIIBLOF_en = JKAECBCNHAN_IsEnabled(array[i].IJEKNCDIIAE_mver, array[i].PLALNIIBLOF_en, 0);
			data.FPJBMCDMAMO = array[i].AHEFJKEICLM;
			EDLJEPAFLEK.Add(data);
		}
		return true;
	}

	// RVA: 0x19B5744 Offset: 0x19B5744 VA: 0x19B5744 Slot: 11
	public override uint CAOGDCBPBAN()
	{
		TodoLogger.LogError(TodoLogger.DbIntegrityCheck, "BKPAPCMJKHE_Shop.CAOGDCBPBAN");
		return 0;
	}
}
