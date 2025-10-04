
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XeSys;

public class KEPNMGHABPI
{
    //[DefaultMemberAttribute("Item")] // RVA: 0x63D4EC Offset: 0x63D4EC VA: 0x63D4EC
    public class FKGOOHONBGI
    {
        private Dictionary<string, KEPNMGHABPI> GCOJLMHEBNJ = new Dictionary<string, KEPNMGHABPI>(); // 0x8

        // public KEPNMGHABPI INIMBLOHIEF_set_Item { get; }

        // RVA: 0x19FC68C Offset: 0x19FC68C VA: 0x19FC68C
        public KEPNMGHABPI GOAMILGNJIE(BNJJHPEGNAI.HCAJEKFFNBM PNOEDHCKCEJ)
        {
            string str = PNOEDHCKCEJ.KGICDMIJGDF_Group + PNOEDHCKCEJ.ADCMNODJBGJ_title;
            KEPNMGHABPI res = null;
            if(!GCOJLMHEBNJ.TryGetValue(str, out res))
            {
                res = new KEPNMGHABPI(PNOEDHCKCEJ);
                GCOJLMHEBNJ.Add(str, res);
            }
            return res;
        }
    }

    public class AELPHOILEBM
    {
        public const int GBBILKJEBCO = 30;
        public const int KHPDFDJOHNL = 30;
        public const int KJEEECMKAPE = 1;
        internal const int PKDODBPFHAO = 2;
        internal const int JHKAOFLAMLC = 1;
        public SakashoBbsThreadCriteria IPKCADIAAPG_Criteria; // 0x8
        public int MLPLGFLKKLI_Ipp; // 0xC
        public int IGNIIEBMFIN_Page; // 0x10
        public string ADCMNODJBGJ_title; // 0x14
        internal int DFJDDIGFGKJ_SortKey; // 0x18
        internal int MLMHPBOKJCL_SortOrder; // 0x1C

        // RVA: 0x19F42A4 Offset: 0x19F42A4 VA: 0x19F42A4
        public AELPHOILEBM(KEPNMGHABPI PAKIOKPJOBF)
        {
            KHEKNNFCAOI_Init(PAKIOKPJOBF);
        }

        // RVA: 0x19FC234 Offset: 0x19FC234 VA: 0x19FC234
        public void KHEKNNFCAOI_Init(KEPNMGHABPI PAKIOKPJOBF)
        {
			IPKCADIAAPG_Criteria = null;
			MLPLGFLKKLI_Ipp = 30;
			IGNIIEBMFIN_Page = 1;
			ADCMNODJBGJ_title = PAKIOKPJOBF.OJAGHKJAJEJ.Title;
			DFJDDIGFGKJ_SortKey = 2;
			MLMHPBOKJCL_SortOrder = 1;
		}
    }

    public class EIAMFNIAFGN
    {
        public const int GBBILKJEBCO = 30;
        public const int KHPDFDJOHNL = 30;
        public const int KJEEECMKAPE = 1;
        internal const int JHKAOFLAMLC = 0;
        public SakashoBbsCommentCriteria IPKCADIAAPG_Criteria; // 0x8
        public int MLPLGFLKKLI_Ipp; // 0xC
        public int IGNIIEBMFIN_Page; // 0x10
        internal int MLMHPBOKJCL_SortOrder; // 0x14

        // RVA: 0x19F6654 Offset: 0x19F6654 VA: 0x19F6654
        public EIAMFNIAFGN()
        {
            KHEKNNFCAOI_Init();
        }

        // RVA: 0x19FC608 Offset: 0x19FC608 VA: 0x19FC608
        public void KHEKNNFCAOI_Init()
        {
			IPKCADIAAPG_Criteria = new SakashoBbsCommentCriteria();
			MLPLGFLKKLI_Ipp = 30;
			IGNIIEBMFIN_Page = 1;
			MLMHPBOKJCL_SortOrder = 0;
		}
    }

    public class LNCLNAOPNKF
    {
        public int BOINIEAKFPL_ThreadId { get; private set; } // 0x8 IOHKLFBFEIH_bgs KLEKIGODFHI_bgs IOINKEKIMID_bgs
        public string OODOEBCLCFI_ThreadGroup { get; private set; } // 0xC CLACFNHPEBC_bgs ECOAONNEHHO_bgs HAIPBFFCCBG_bgs
        public string ECAIHFNAAOM_Title { get; private set; } // 0x10 BMBEDMGFOCA_bgs OLLOMOEMAGL_bgs INAJMAIEKDG_bgs
        public JKHBHIGMJIC CCBEKGNDDBE { get; private set; } // 0x14 HCNCKGNGIII_bgs CNEPKBEMPPI_bgs CONDCLIAOOG_bgs
        // public bool AKGODCLMDMF { get; } 0x19F56C4 KNCKLGPKAGF_bgs

        // RVA: 0x19F92A4 Offset: 0x19F92A4 VA: 0x19F92A4
        public LNCLNAOPNKF(int _BOINIEAKFPL_ThreadId, string _OODOEBCLCFI_ThreadGroup, string _ECAIHFNAAOM_Title)
        {
			BOINIEAKFPL_ThreadId = _BOINIEAKFPL_ThreadId;
			OODOEBCLCFI_ThreadGroup = _OODOEBCLCFI_ThreadGroup;
			ECAIHFNAAOM_Title = _ECAIHFNAAOM_Title;
		}

        // RVA: 0x19F7314 Offset: 0x19F7314 VA: 0x19F7314
        public LNCLNAOPNKF(JKHBHIGMJIC CCBEKGNDDBE)
		{
			BOINIEAKFPL_ThreadId = CCBEKGNDDBE.LIBHMBKLMHF_ThreadId;
			OODOEBCLCFI_ThreadGroup = CCBEKGNDDBE.BDJEICCDKHB_ThreadGroup;
			ECAIHFNAAOM_Title = CCBEKGNDDBE.ADCMNODJBGJ_title;
			this.CCBEKGNDDBE = CCBEKGNDDBE;
		}
    }

    public class CAIPMAMHNJP
    {
        public LNCLNAOPNKF MENAGBMBJFJ { get; private set; } // 0x8 AFGKFAFHPBD_bgs NCADLAEHAKK_bgs AMKFLBDACAG_bgs
        // public int BOINIEAKFPL_ThreadId { get; } 0x19F6630 KLEKIGODFHI_bgs
        // public string ECAIHFNAAOM_Title { get; } 0x19FC2F0 OLLOMOEMAGL_bgs
        public int OIPCCBHIKIA_index { get; private set; } // 0xC MPFBDIIBNBG_bgs HFCGOHDOHAP_bgs FOGFPKNLADC_bgs
        public BNAAJMBJFPG CCBEKGNDDBE { get; private set; } // 0x10 HCNCKGNGIII_bgs CNEPKBEMPPI_bgs CONDCLIAOOG_bgs
        // public bool ODIJEJPAJOG { get; } 0x19FC32C BDLBNABIFEC_bgs
        // public bool NEDCNFBIKBH { get; } 0x19FC35C BEPMIMNOMJP_bgs

        // // RVA: 0x19FC3C0 Offset: 0x19FC3C0 VA: 0x19FC3C0
        private CAIPMAMHNJP(LNCLNAOPNKF MENAGBMBJFJ, int _OIPCCBHIKIA_index)
		{
			this.MENAGBMBJFJ = MENAGBMBJFJ;
			this.OIPCCBHIKIA_index = _OIPCCBHIKIA_index;
		}

        // // RVA: 0x19F7E74 Offset: 0x19F7E74 VA: 0x19F7E74
        public CAIPMAMHNJP(LNCLNAOPNKF MENAGBMBJFJ, BNAAJMBJFPG CCBEKGNDDBE)
		{
			this.MENAGBMBJFJ = MENAGBMBJFJ;
			OIPCCBHIKIA_index = CCBEKGNDDBE.NPAHGHOHMHN_Idx;
			this.CCBEKGNDDBE = CCBEKGNDDBE;
		}

        // // RVA: 0x19FC3E8 Offset: 0x19FC3E8 VA: 0x19FC3E8
        public CAIPMAMHNJP(int _BOINIEAKFPL_ThreadId, string _KGICDMIJGDF_Group, string _ADCMNODJBGJ_title, BNAAJMBJFPG CCBEKGNDDBE)
		{
			MENAGBMBJFJ = new LNCLNAOPNKF(_BOINIEAKFPL_ThreadId, _KGICDMIJGDF_Group, _ADCMNODJBGJ_title);
			OIPCCBHIKIA_index = CCBEKGNDDBE.NPAHGHOHMHN_Idx;
			this.CCBEKGNDDBE = CCBEKGNDDBE;
		}
    }

    public delegate void DALALJLBNPL();

    private class GJJPNNCILLI
    {
        public LNCLNAOPNKF MENAGBMBJFJ; // 0x8
        public SakashoBbsCommentInfo HCAHCFGPJIF_Desc; // 0xC
        public DALALJLBNPL BHFHGFKBOHH_OnSuccess; // 0x10
        public DJBHIFLHJLK MOBEEPPKFLG_OnFail; // 0x14
        public DJBHIFLHJLK NKGHADCBGJO; // 0x18

        // // RVA: 0x19F7EB8 Offset: 0x19F7EB8 VA: 0x19F7EB8
        public GJJPNNCILLI(LNCLNAOPNKF MENAGBMBJFJ, SakashoBbsCommentInfo _HCAHCFGPJIF_Desc, DALALJLBNPL _BHFHGFKBOHH_OnSuccess, DJBHIFLHJLK _MOBEEPPKFLG_OnFail, DJBHIFLHJLK NKGHADCBGJO)
		{
			this.MENAGBMBJFJ = MENAGBMBJFJ;
			this.HCAHCFGPJIF_Desc = _HCAHCFGPJIF_Desc;
			this.BHFHGFKBOHH_OnSuccess = _BHFHGFKBOHH_OnSuccess;
			this.MOBEEPPKFLG_OnFail = _MOBEEPPKFLG_OnFail;
			this.NKGHADCBGJO = NKGHADCBGJO;
		}
    }

    private class DGGNPDDJNOO : IComparer<JKHBHIGMJIC>
    {
        // RVA: 0x19FC580 Offset: 0x19FC580 VA: 0x19FC580 Slot: 4
        public int Compare(JKHBHIGMJIC CIFFHLGLPMK, JKHBHIGMJIC OIKJFMGEICL)
		{
			return CIFFHLGLPMK.LIBHMBKLMHF_ThreadId - OIKJFMGEICL.LIBHMBKLMHF_ThreadId;
		}
    }

    private class ANNDCGIBEDA : IComparer<LNCLNAOPNKF>
    {
        // RVA: 0x19FC2A0 Offset: 0x19FC2A0 VA: 0x19FC2A0 Slot: 4
        public int Compare(LNCLNAOPNKF CIFFHLGLPMK, LNCLNAOPNKF OIKJFMGEICL)
        {
			return CIFFHLGLPMK.BOINIEAKFPL_ThreadId - OIKJFMGEICL.BOINIEAKFPL_ThreadId;
        }
    }

    private class HPDEJLPPKJE : IComparer<BNAAJMBJFPG>
    {
        // RVA: 0x19FC7E4 Offset: 0x19FC7E4 VA: 0x19FC7E4 Slot: 4
        public int Compare(BNAAJMBJFPG CIFFHLGLPMK, BNAAJMBJFPG OIKJFMGEICL)
		{
			return OIKJFMGEICL.NPAHGHOHMHN_Idx - CIFFHLGLPMK.NPAHGHOHMHN_Idx;
		}
    }

    // private class DIBEHLLPKAD : IComparer<BNAAJMBJFPG>
    // {
    //     // RVA: 0x19FC5C0 Offset: 0x19FC5C0 VA: 0x19FC5C0 Slot: 4
    //     public int Compare(BNAAJMBJFPG CIFFHLGLPMK, BNAAJMBJFPG OIKJFMGEICL) { }
    // }

    private class CGOJGMLAFOH : IComparer<CAIPMAMHNJP>
    {
        // RVA: 0x19FC498 Offset: 0x19FC498 VA: 0x19FC498 Slot: 4
        public int Compare(CAIPMAMHNJP CIFFHLGLPMK, CAIPMAMHNJP OIKJFMGEICL)
        {
			int res = OIKJFMGEICL.MENAGBMBJFJ.BOINIEAKFPL_ThreadId - CIFFHLGLPMK.MENAGBMBJFJ.BOINIEAKFPL_ThreadId;
			if(res == 0)
				res = OIKJFMGEICL.OIPCCBHIKIA_index - CIFFHLGLPMK.OIPCCBHIKIA_index;
			return res;
		}
    }

    private delegate void KCODNIFAICE(FPOEFNEPJDH_CreateBbsThread.OIPIPIHBJFM _NFEAMMJIMPG_Result);

    private class JKBGFAALHLL
    {
        public CAIPMAMHNJP HHJIGMPALKM; // 0x8
        public CAIPMAMHNJP CBPDHJAACAH; // 0xC
        public int FOEFBANLCIM; // 0x10
        public LNCLNAOPNKF PBLLHAMIBHA; // 0x14
        public int KIHNBLOPLNC; // 0x18
        public CAIPMAMHNJP OIMHHIFNGOI; // 0x1C

        // public bool DNJEMPANDNN { get; } 0x19F5CA4 EEHKLMFOEFK_bgs

        // // RVA: 0x19F5DAC Offset: 0x19F5DAC VA: 0x19F5DAC
        public void IPBDPLOKLLP()
		{
			KIHNBLOPLNC = 0;
			OIMHHIFNGOI = null;
			HHJIGMPALKM = null;
			CBPDHJAACAH = null;
			FOEFBANLCIM = 0;
			PBLLHAMIBHA = null;
		}
    }

	public const int KMOLPKLGFKD = 1;
	private static FKGOOHONBGI GHPCOLKAAFF; // 0x0
	private LNCLNAOPNKF LHKOLKACMPA; // 0x8
	private List<LNCLNAOPNKF> JKHNFFDFPEC; // 0xC
	private SakashoBbsThreadCriteria BIBOMJHJHMG; // 0x14
	private SakashoBbsThreadInfo OJAGHKJAJEJ; // 0x18
	private KCODNIFAICE EKKDNEFMCMO; // 0x1C
	private bool DCPNKOLMDKF; // 0x20
	private Queue<GJJPNNCILLI> HBPKDJCJELM; // 0x24
	private bool HBJNOPOKMCB; // 0x28
	private JKBGFAALHLL MLNOKNEECEO; // 0x2C
	private BNJJHPEGNAI.HCAJEKFFNBM EGJKCPAIFCM; // 0x30

	public static FKGOOHONBGI OGIFFNLIDIO { get {
        if(GHPCOLKAAFF == null)
            GHPCOLKAAFF = new FKGOOHONBGI();
        return GHPCOLKAAFF;
    } } //0x19F3BC8 IHHPMAEAFLJ_bgs
	public string OODOEBCLCFI_ThreadGroup { get; private set; } // 0x10 CLACFNHPEBC_bgs ECOAONNEHHO_bgs HAIPBFFCCBG_bgs
	private PJKLMCGEJMK CPHFEPHDJIB_ServerRequester { get { return NKGJPJPHLIF.HHCJCDFCLOB.IBLPICFDGOF_ServerRequester; } } //0x19F3D04 JPEBBKJAMCK_bgs

	// // RVA: 0x19F3DA0 Offset: 0x19F3DA0 VA: 0x19F3DA0
	internal KEPNMGHABPI(BNJJHPEGNAI.HCAJEKFFNBM MENAGBMBJFJ)
    {
        JKHNFFDFPEC = new List<LNCLNAOPNKF>();
        HBPKDJCJELM = new Queue<GJJPNNCILLI>();
        MLNOKNEECEO = new JKBGFAALHLL();
        OODOEBCLCFI_ThreadGroup = MENAGBMBJFJ.KGICDMIJGDF_Group;
        SakashoBbsThreadCriteria ctr = new SakashoBbsThreadCriteria();
        ctr.ThreadGroup = OODOEBCLCFI_ThreadGroup;
        ctr.ExcludeBlockedThreads = MENAGBMBJFJ.BDNDHFBNBLL_ExcludeBlockedThread;
        BIBOMJHJHMG = ctr;
        SakashoBbsThreadInfo inf = new SakashoBbsThreadInfo();
        inf.Title = MENAGBMBJFJ.ADCMNODJBGJ_title;
        inf.ThreadGroup = OODOEBCLCFI_ThreadGroup;
        inf.Extra = MENAGBMBJFJ.KACECFNECON_extra;
        inf.ExpireDays = MENAGBMBJFJ.EMGJJFKONHK_ExpireDays;
        inf.ApplyOwnerBlacklist = MENAGBMBJFJ.BDNDHFBNBLL_ExcludeBlockedThread ? 1 : 0;
        EGJKCPAIFCM = MENAGBMBJFJ;
        OJAGHKJAJEJ = inf;
    }

	// [ConditionalAttribute] // RVA: 0x6C2C30 Offset: 0x6C2C30 VA: 0x6C2C30
	// // RVA: 0x19F4098 Offset: 0x19F4098 VA: 0x19F4098
	// public void FKLIPCAKCCE(int _HMFFHLPNMPH_count, IMCBBOAFION _BHFHGFKBOHH_OnSuccess, DJBHIFLHJLK _MOBEEPPKFLG_OnFail) { }

	// // RVA: 0x19F409C Offset: 0x19F409C VA: 0x19F409C
    public void OMEFFONNMBC(int _KPNKPGLPDHI_Op, Action<LNCLNAOPNKF> _BHFHGFKBOHH_OnSuccess, DJBHIFLHJLK _MOBEEPPKFLG_OnFail, SakashoBbsThreadCriteria _IPKCADIAAPG_Criteria)
    {
		AELPHOILEBM data = new AELPHOILEBM(this);
		if (_IPKCADIAAPG_Criteria == null)
			_IPKCADIAAPG_Criteria = BIBOMJHJHMG;
		data.IPKCADIAAPG_Criteria = _IPKCADIAAPG_Criteria;
		data.MLPLGFLKKLI_Ipp = 1;
		data.IGNIIEBMFIN_Page = 1;
		data.MLMHPBOKJCL_SortOrder = 0;
		data.ADCMNODJBGJ_title = OJAGHKJAJEJ.Title;
		HJCEIODJLOJ(_KPNKPGLPDHI_Op, data, (List<LNCLNAOPNKF> _NMHGLNGACMI_Threads) =>
		{
			//0x19F8498
			data.MLPLGFLKKLI_Ipp = 30;
			if(_NMHGLNGACMI_Threads.IsEmpty())
			{
				Predicate<LNCLNAOPNKF> BAHANNNJCGC = (LNCLNAOPNKF _OHMCIEMIKCE_t) =>
				{
					//0x19F8808
					return _OHMCIEMIKCE_t.ECAIHFNAAOM_Title == data.ADCMNODJBGJ_title;
				};
				Action<LNCLNAOPNKF> CMJMGEFNBDK = (LNCLNAOPNKF _OHMCIEMIKCE_t) =>
				{
					//0x19F885C
					if(_OHMCIEMIKCE_t != null)
					{
						if(_OHMCIEMIKCE_t.CCBEKGNDDBE.OMMDEKMFBAF_CommentsCount != _OHMCIEMIKCE_t.CCBEKGNDDBE.ADGNGHIJFFC_MaxComments)
						{
							LHKOLKACMPA = _OHMCIEMIKCE_t;
							_BHFHGFKBOHH_OnSuccess(_OHMCIEMIKCE_t);
							return;
						}
					}
					HJCEIODJLOJ(_KPNKPGLPDHI_Op, data, (List<LNCLNAOPNKF> _JHOONHIHJNJ_MatchKey) =>
					{
						//0x19F89E0
						_BHFHGFKBOHH_OnSuccess(OMEFFONNMBC(_KPNKPGLPDHI_Op, _JHOONHIHJNJ_MatchKey, true));
					}, _MOBEEPPKFLG_OnFail, false);
				};
				GBKJNMFNOJO(_KPNKPGLPDHI_Op, data, BAHANNNJCGC, CMJMGEFNBDK, _MOBEEPPKFLG_OnFail);
				return;
			}
			else
			{
				LNCLNAOPNKF d = OMEFFONNMBC(_KPNKPGLPDHI_Op, _NMHGLNGACMI_Threads, true);
				if(d.CCBEKGNDDBE.OMMDEKMFBAF_CommentsCount == d.CCBEKGNDDBE.ADGNGHIJFFC_MaxComments)
				{
					Action<List<LNCLNAOPNKF>> DMLJLPMBLCH = (List<LNCLNAOPNKF> _JHOONHIHJNJ_MatchKey) =>
					{
						//0x19F8758
						_BHFHGFKBOHH_OnSuccess(OMEFFONNMBC(_KPNKPGLPDHI_Op, _JHOONHIHJNJ_MatchKey, true));
					};
					HJCEIODJLOJ(_KPNKPGLPDHI_Op, data, DMLJLPMBLCH, _MOBEEPPKFLG_OnFail, false);
					return;
				}
				_BHFHGFKBOHH_OnSuccess(d);
			}
		}, _MOBEEPPKFLG_OnFail, true);
	}

	// // RVA: 0x19F4470 Offset: 0x19F4470 VA: 0x19F4470
	public void FNKJBKJIKPC(int _KPNKPGLPDHI_Op, bool PAEAHCEJLKG, Action<List<LNCLNAOPNKF>> _BHFHGFKBOHH_OnSuccess, DJBHIFLHJLK _MOBEEPPKFLG_OnFail, KEPNMGHABPI.AELPHOILEBM _NGHKJOEDLIP_Settings, SakashoBbsThreadCriteria _IPKCADIAAPG_Criteria)
	{
		if(_NGHKJOEDLIP_Settings == null)
		{
			_NGHKJOEDLIP_Settings = new AELPHOILEBM(this);
			if (_IPKCADIAAPG_Criteria == null)
				_IPKCADIAAPG_Criteria = BIBOMJHJHMG;
			_NGHKJOEDLIP_Settings.IPKCADIAAPG_Criteria = _IPKCADIAAPG_Criteria;
			_NGHKJOEDLIP_Settings.ADCMNODJBGJ_title = OJAGHKJAJEJ.Title;
		}
		OMBENJEDFLJ_GetThreads(_KPNKPGLPDHI_Op, _NGHKJOEDLIP_Settings, new List<List<LNCLNAOPNKF>>(), _BHFHGFKBOHH_OnSuccess, _MOBEEPPKFLG_OnFail, PAEAHCEJLKG);
	}

	// // RVA: 0x19F4758 Offset: 0x19F4758 VA: 0x19F4758
	public void FNKJBKJIKPC(int _KPNKPGLPDHI_Op, Action<List<LNCLNAOPNKF>> _BHFHGFKBOHH_OnSuccess, DJBHIFLHJLK _MOBEEPPKFLG_OnFail, bool DJHLDMOPCOL)
	{
		AELPHOILEBM a = new AELPHOILEBM(this);
		a.IPKCADIAAPG_Criteria = BIBOMJHJHMG;
		a.ADCMNODJBGJ_title = null;
		if(!DJHLDMOPCOL)
		{
			a.ADCMNODJBGJ_title = OJAGHKJAJEJ.Title;
		}
		FNKJBKJIKPC(_KPNKPGLPDHI_Op, false, _BHFHGFKBOHH_OnSuccess, _MOBEEPPKFLG_OnFail, a, null);
	}

	// // RVA: 0x19F42CC Offset: 0x19F42CC VA: 0x19F42CC
	public void HJCEIODJLOJ(int _KPNKPGLPDHI_Op, AELPHOILEBM _NGHKJOEDLIP_Settings, Action<List<LNCLNAOPNKF>> _BHFHGFKBOHH_OnSuccess, DJBHIFLHJLK _MOBEEPPKFLG_OnFail, bool CBNPNMPLJPP/* = false*/)
	{
		OMBENJEDFLJ_GetThreads(_KPNKPGLPDHI_Op, _NGHKJOEDLIP_Settings, (MMCLJMPEFEP_GetBbsThreads.CAMBPKCCBDO CHCEIJOJDHL) =>
		{
			//0x19F8A90
			ALNCDMPMEHP(_KPNKPGLPDHI_Op, LFAJKNNALBJ(), _NGHKJOEDLIP_Settings, CHCEIJOJDHL.NMHGLNGACMI_Threads, _BHFHGFKBOHH_OnSuccess, _MOBEEPPKFLG_OnFail, CBNPNMPLJPP);
		}, _MOBEEPPKFLG_OnFail);
	}

	// // RVA: 0x19F4D08 Offset: 0x19F4D08 VA: 0x19F4D08
	// public void PCBGOOBFCPG(int _BOINIEAKFPL_ThreadId, SakashoBbsThreadInfo _KOGBMDOONFA_Info, IMCBBOAFION _BHFHGFKBOHH_OnSuccess, DJBHIFLHJLK _MOBEEPPKFLG_OnFail) { }

	// // RVA: 0x19F4EE8 Offset: 0x19F4EE8 VA: 0x19F4EE8
	// public void EBMBDKCCPOG(int _BOINIEAKFPL_ThreadId, int _EMGJJFKONHK_ExpireDays, IMCBBOAFION _BHFHGFKBOHH_OnSuccess, DJBHIFLHJLK _MOBEEPPKFLG_OnFail) { }

	// // RVA: 0x19F5260 Offset: 0x19F5260 VA: 0x19F5260
	// public void POFAKDOBFFN(int _KPNKPGLPDHI_Op, int _BOINIEAKFPL_ThreadId, IMCBBOAFION _BHFHGFKBOHH_OnSuccess, DJBHIFLHJLK _MOBEEPPKFLG_OnFail) { }

	// // RVA: 0x19F4F48 Offset: 0x19F4F48 VA: 0x19F4F48
	private SakashoBbsThreadInfo LFAJKNNALBJ()
	{
		SakashoBbsThreadInfo res = new SakashoBbsThreadInfo();
		if (!string.IsNullOrEmpty(OJAGHKJAJEJ.Title))
			res.Title = OJAGHKJAJEJ.Title;
		else
			res.Title = "none";
		res.Detail = OJAGHKJAJEJ.Detail;
		res.ThreadGroup = OJAGHKJAJEJ.ThreadGroup;
		res.MinCommentBytes = OJAGHKJAJEJ.MinCommentBytes;
		res.MaxCommentBytes = OJAGHKJAJEJ.MaxCommentBytes;
		res.MaxComments = OJAGHKJAJEJ.MaxComments;
		res.ExpireDays = OJAGHKJAJEJ.ExpireDays;
		res.Extra = OJAGHKJAJEJ.Extra;
		res.ApplyOwnerBlacklist = OJAGHKJAJEJ.ApplyOwnerBlacklist;
		return res;
	}

	// // RVA: 0x19F5424 Offset: 0x19F5424 VA: 0x19F5424
	// public SakashoBbsThreadInfo LFAJKNNALBJ(KEPNMGHABPI.LNCLNAOPNKF MENAGBMBJFJ) { }

	// // RVA: 0x19F56DC Offset: 0x19F56DC VA: 0x19F56DC
	public void HMOPLMHMNNP_GetComments(int _KPNKPGLPDHI_Op, int _BOINIEAKFPL_ThreadId, EIAMFNIAFGN _NGHKJOEDLIP_Settings, Action<NFIMGIABIOI_GetBbsThreadComments.CIIDLDOOKBB> _BHFHGFKBOHH_OnSuccess, DJBHIFLHJLK _MOBEEPPKFLG_OnFail)
	{
		if((_KPNKPGLPDHI_Op & 1) == 0)
		{
			NFIMGIABIOI_GetBbsThreadComments COJNCNGHIJC_Req = CPHFEPHDJIB_ServerRequester.IFFNCAFNEAG_AddRequest(new NFIMGIABIOI_GetBbsThreadComments());
			COJNCNGHIJC_Req.BOINIEAKFPL_ThreadId = _BOINIEAKFPL_ThreadId;
			COJNCNGHIJC_Req.IPKCADIAAPG_Criteria = _NGHKJOEDLIP_Settings.IPKCADIAAPG_Criteria;
			COJNCNGHIJC_Req.MLMHPBOKJCL_SortOrder = _NGHKJOEDLIP_Settings.MLMHPBOKJCL_SortOrder;
			COJNCNGHIJC_Req.IGNIIEBMFIN_Page = _NGHKJOEDLIP_Settings.IGNIIEBMFIN_Page;
			COJNCNGHIJC_Req.MLPLGFLKKLI_Ipp = _NGHKJOEDLIP_Settings.MLPLGFLKKLI_Ipp;
			COJNCNGHIJC_Req.BHFHGFKBOHH_OnSuccess = (CACGCMBKHDI_Request JIPCHHHLOMM) =>
			{
				//0x19F8C7C
				_BHFHGFKBOHH_OnSuccess(COJNCNGHIJC_Req.NFEAMMJIMPG_Result);
			};
			COJNCNGHIJC_Req.MOBEEPPKFLG_OnFail = (CACGCMBKHDI_Request JIPCHHHLOMM) =>
			{
				//0x19F8BC0
				if (_MOBEEPPKFLG_OnFail != null)
					_MOBEEPPKFLG_OnFail();
			};
		}
		else
		{
			NFIMGIABIOI_GetBbsThreadComments COJNCNGHIJC_Req = NKGJPJPHLIF.HHCJCDFCLOB.HKDHHMHHJOJ.IFFNCAFNEAG_AddRequest(new NFIMGIABIOI_GetBbsThreadComments());
			COJNCNGHIJC_Req.BOINIEAKFPL_ThreadId = _BOINIEAKFPL_ThreadId;
			COJNCNGHIJC_Req.IPKCADIAAPG_Criteria = _NGHKJOEDLIP_Settings.IPKCADIAAPG_Criteria;
			COJNCNGHIJC_Req.MLMHPBOKJCL_SortOrder = _NGHKJOEDLIP_Settings.MLMHPBOKJCL_SortOrder;
			COJNCNGHIJC_Req.IGNIIEBMFIN_Page = _NGHKJOEDLIP_Settings.IGNIIEBMFIN_Page;
			COJNCNGHIJC_Req.MLPLGFLKKLI_Ipp = _NGHKJOEDLIP_Settings.MLPLGFLKKLI_Ipp;
			COJNCNGHIJC_Req.BHFHGFKBOHH_OnSuccess = (CACGCMBKHDI_Request JIPCHHHLOMM) =>
			{
				//0x19F8BD4
				_BHFHGFKBOHH_OnSuccess(COJNCNGHIJC_Req.NFEAMMJIMPG_Result);
			};
			COJNCNGHIJC_Req.MOBEEPPKFLG_OnFail = (CACGCMBKHDI_Request JIPCHHHLOMM) =>
			{
				//0x19F8BAC
				if (_MOBEEPPKFLG_OnFail != null)
					_MOBEEPPKFLG_OnFail();
			};
		}
	}

	// // RVA: 0x19F5B84 Offset: 0x19F5B84 VA: 0x19F5B84
	public bool JGGFDPHHKJD()
	{
		if(MLNOKNEECEO.FOEFBANLCIM < 1 && MLNOKNEECEO.HHJIGMPALKM == null)
		{
			if (MLNOKNEECEO.PBLLHAMIBHA == null && MLNOKNEECEO.CBPDHJAACAH == null)
				return true;
		}
		if(MLNOKNEECEO.CBPDHJAACAH != null)
		{
			if(MLNOKNEECEO.KIHNBLOPLNC == PKNGBAPOFHF(JKHNFFDFPEC).BOINIEAKFPL_ThreadId)
			{
				if (MLNOKNEECEO.OIMHHIFNGOI == null)
					return false;
				return MLNOKNEECEO.OIMHHIFNGOI.OIPCCBHIKIA_index > 1;
			}
			return true;
		}
		return false;
	}

	// // RVA: 0x19F5D6C Offset: 0x19F5D6C VA: 0x19F5D6C
	public void IPBDPLOKLLP()
	{
		MLNOKNEECEO.IPBDPLOKLLP();
		LHKOLKACMPA = null;
	}

	// // RVA: 0x19F5DC8 Offset: 0x19F5DC8 VA: 0x19F5DC8
	public void EMHMAJDNEJB(int _KPNKPGLPDHI_Op, Action<List<CAIPMAMHNJP>> _BHFHGFKBOHH_OnSuccess, DJBHIFLHJLK _MOBEEPPKFLG_OnFail, int _HMFFHLPNMPH_count/* = 30*/, SakashoBbsCommentCriteria EKALCDNBHBJ/* = null*/)
	{
		int POMLAOPLMNA_offset = MLNOKNEECEO.FOEFBANLCIM;
		if(!(MLNOKNEECEO.FOEFBANLCIM < 1 && MLNOKNEECEO.HHJIGMPALKM == null && MLNOKNEECEO.PBLLHAMIBHA == null && MLNOKNEECEO.CBPDHJAACAH == null))
		{
			if (LHKOLKACMPA.BOINIEAKFPL_ThreadId != MLNOKNEECEO.PBLLHAMIBHA.BOINIEAKFPL_ThreadId)
			{
				for (int i = JKHNFFDFPEC.Count - 1; i > -1; i--)
				{
					if (JKHNFFDFPEC[i].BOINIEAKFPL_ThreadId != MLNOKNEECEO.PBLLHAMIBHA.BOINIEAKFPL_ThreadId)
					{
						if (JKHNFFDFPEC[i].BOINIEAKFPL_ThreadId != MLNOKNEECEO.HHJIGMPALKM.MENAGBMBJFJ.BOINIEAKFPL_ThreadId)
						{
							//LAB_019f6090
							if (JKHNFFDFPEC[i].CCBEKGNDDBE != null)
							{
								POMLAOPLMNA_offset -= JKHNFFDFPEC[i].CCBEKGNDDBE.OMMDEKMFBAF_CommentsCount;
							}
						}
						else
						{
							POMLAOPLMNA_offset -= MLNOKNEECEO.HHJIGMPALKM.OIPCCBHIKIA_index;
						}
						//joined_r0x019f5f7c
					}
				}
			}
			//LAB_019f60dc
		}
		{
			//LAB_019f60dc
			_HMFFHLPNMPH_count = Mathf.Clamp(_HMFFHLPNMPH_count, 1, 30);
			int page = 0;
			if (POMLAOPLMNA_offset != 0)
				page = POMLAOPLMNA_offset / _HMFFHLPNMPH_count;
			POMLAOPLMNA_offset -= _HMFFHLPNMPH_count * page;
			EIAMFNIAFGN _NGHKJOEDLIP_Settings = new EIAMFNIAFGN();
			_NGHKJOEDLIP_Settings.KHEKNNFCAOI_Init();
			if (EKALCDNBHBJ == null)
				EKALCDNBHBJ = new SakashoBbsCommentCriteria();
			_NGHKJOEDLIP_Settings.IPKCADIAAPG_Criteria = EKALCDNBHBJ;
			_NGHKJOEDLIP_Settings.MLPLGFLKKLI_Ipp = _HMFFHLPNMPH_count;
			_NGHKJOEDLIP_Settings.IGNIIEBMFIN_Page = page;
			Action<List<LNCLNAOPNKF>> CCFKOHNLBHP = (List<LNCLNAOPNKF> _NMHGLNGACMI_Threads) =>
			{
				//0x19F8D24
				OCKOIMLGLCF(_KPNKPGLPDHI_Op, new List<List<CAIPMAMHNJP>>(), POMLAOPLMNA_offset, _HMFFHLPNMPH_count, _NMHGLNGACMI_Threads, _NGHKJOEDLIP_Settings, _BHFHGFKBOHH_OnSuccess, _MOBEEPPKFLG_OnFail);
			};
			if(MLNOKNEECEO.FOEFBANLCIM < 1)
			{
				if(MLNOKNEECEO.HHJIGMPALKM == null && MLNOKNEECEO.PBLLHAMIBHA == null && MLNOKNEECEO.CBPDHJAACAH == null)
				{
					LNCLNAOPNKF FACJOMMDIPN = LHKOLKACMPA;
					OMEFFONNMBC(_KPNKPGLPDHI_Op, (LNCLNAOPNKF EOHFABJDJOH) =>
					{
						//0x19F8E00
						if(FACJOMMDIPN != null)
						{
							if(EOHFABJDJOH.BOINIEAKFPL_ThreadId == FACJOMMDIPN.BOINIEAKFPL_ThreadId)
							{
								if(!JKHNFFDFPEC.IsEmpty())
								{
									CCFKOHNLBHP(new List<LNCLNAOPNKF>(JKHNFFDFPEC));
									return;
								}
							}
						}
						FNKJBKJIKPC(_KPNKPGLPDHI_Op, true, CCFKOHNLBHP, _MOBEEPPKFLG_OnFail, null, null);
					}, _MOBEEPPKFLG_OnFail, null);
					return;
				}
			}
			List<LNCLNAOPNKF> l = new List<LNCLNAOPNKF>(JKHNFFDFPEC.Count);
			foreach(var k in JKHNFFDFPEC)
			{
				l.Add(k);
				if (MLNOKNEECEO.PBLLHAMIBHA.BOINIEAKFPL_ThreadId == k.BOINIEAKFPL_ThreadId)
					break;
			}
			CCFKOHNLBHP(l);
		}
	}

	// // RVA: 0x19F667C Offset: 0x19F667C VA: 0x19F667C
	public void IFFGEIMIKHH(int _KPNKPGLPDHI_Op, SakashoBbsCommentInfo _KOGBMDOONFA_Info, KEPNMGHABPI.DALALJLBNPL _BHFHGFKBOHH_OnSuccess, DJBHIFLHJLK _MOBEEPPKFLG_OnFail, DJBHIFLHJLK NKGHADCBGJO)
    {
        if(LHKOLKACMPA != null)
        {
            HLEABLHJPOI(_KPNKPGLPDHI_Op, LHKOLKACMPA, _KOGBMDOONFA_Info, _BHFHGFKBOHH_OnSuccess, _MOBEEPPKFLG_OnFail, NKGHADCBGJO);
        }
        else
        {
            OMEFFONNMBC(_KPNKPGLPDHI_Op, (LNCLNAOPNKF EOHFABJDJOH) =>
            {
                //0x19F9028
                HLEABLHJPOI(_KPNKPGLPDHI_Op, EOHFABJDJOH, _KOGBMDOONFA_Info, _BHFHGFKBOHH_OnSuccess, _MOBEEPPKFLG_OnFail, NKGHADCBGJO);
            }, _MOBEEPPKFLG_OnFail, null);
        }
    }

	// // RVA: 0x19F69C4 Offset: 0x19F69C4 VA: 0x19F69C4
	public void HCMMMCFFGCA_UpdateThreadComment(int _KPNKPGLPDHI_Op, int _BOINIEAKFPL_ThreadId, int _OIPCCBHIKIA_index, SakashoBbsCommentInfo _KOGBMDOONFA_Info, IMCBBOAFION _BHFHGFKBOHH_OnSuccess, DJBHIFLHJLK _MOBEEPPKFLG_OnFail)
	{
		EKNLDDKJBEL_UpdateThreadComment req = CPHFEPHDJIB_ServerRequester.IFFNCAFNEAG_AddRequest(new EKNLDDKJBEL_UpdateThreadComment());
		req.BOINIEAKFPL_ThreadId = _BOINIEAKFPL_ThreadId;
		req.OJBGACKBOCA_CommentIdx = _OIPCCBHIKIA_index;
		req.KOGBMDOONFA_Info = _KOGBMDOONFA_Info;
		req.BHFHGFKBOHH_OnSuccess = (CACGCMBKHDI_Request JIPCHHHLOMM) =>
		{
			//0x19F907C
			_BHFHGFKBOHH_OnSuccess();
		};
		req.MOBEEPPKFLG_OnFail = (CACGCMBKHDI_Request JIPCHHHLOMM) =>
		{
			//0x19F90A8
			if(_MOBEEPPKFLG_OnFail != null)	
				_MOBEEPPKFLG_OnFail();
		};
	}

	// // RVA: 0x19F6BBC Offset: 0x19F6BBC VA: 0x19F6BBC
	// public void NCLDLJLAEBK(int _KPNKPGLPDHI_Op, int _BOINIEAKFPL_ThreadId, int _OIPCCBHIKIA_index, IMCBBOAFION _BHFHGFKBOHH_OnSuccess, DJBHIFLHJLK _MOBEEPPKFLG_OnFail) { }

	// // RVA: 0x19F6D9C Offset: 0x19F6D9C VA: 0x19F6D9C
	private void ALNCDMPMEHP(int _KPNKPGLPDHI_Op, SakashoBbsThreadInfo _KOGBMDOONFA_Info, AELPHOILEBM _NGHKJOEDLIP_Settings, List<JKHBHIGMJIC> JCIBAFAILAG, Action<List<LNCLNAOPNKF>> _BHFHGFKBOHH_OnSuccess, DJBHIFLHJLK _MOBEEPPKFLG_OnFail, bool CBNPNMPLJPP/* = false*/)
	{
		if(!string.IsNullOrEmpty(_NGHKJOEDLIP_Settings.ADCMNODJBGJ_title))
		{
			JCIBAFAILAG.RemoveAll((JKHBHIGMJIC _OHMCIEMIKCE_t) =>
			{
				//0x19F90FC
				return _OHMCIEMIKCE_t.ADCMNODJBGJ_title != _NGHKJOEDLIP_Settings.ADCMNODJBGJ_title;
			});
		}
		bool needCreate = JCIBAFAILAG.IsEmpty() && !CBNPNMPLJPP;
		if (!JCIBAFAILAG.IsEmpty() && !CBNPNMPLJPP)
		{
			JCIBAFAILAG.Sort(new DGGNPDDJNOO());
			needCreate = JCIBAFAILAG[JCIBAFAILAG.Count - 1].ADGNGHIJFFC_MaxComments <= JCIBAFAILAG[JCIBAFAILAG.Count - 1].OMMDEKMFBAF_CommentsCount;
		}
		int cnt = JCIBAFAILAG.Count;
		if (needCreate)
			cnt++;
		List<LNCLNAOPNKF> l = new List<LNCLNAOPNKF>(cnt);
		foreach(var k in JCIBAFAILAG)
		{
			l.Add(new LNCLNAOPNKF(k));
		}
		if(needCreate)
		{
			CDPCNICOHEH_CreateThread(_KPNKPGLPDHI_Op, _KOGBMDOONFA_Info, (FPOEFNEPJDH_CreateBbsThread.OIPIPIHBJFM CHCEIJOJDHL) =>
			{
				//0x19F9148
				LHKOLKACMPA = new LNCLNAOPNKF(CHCEIJOJDHL.LIBHMBKLMHF_ThreadId, _KOGBMDOONFA_Info.ThreadGroup, _KOGBMDOONFA_Info.Title);
				l.Add(LHKOLKACMPA);
				_BHFHGFKBOHH_OnSuccess(l);
			}, _MOBEEPPKFLG_OnFail);
		}
		else
		{
			_BHFHGFKBOHH_OnSuccess(l);
		}
	}

	// // RVA: 0x19F7614 Offset: 0x19F7614 VA: 0x19F7614
	private LNCLNAOPNKF OMEFFONNMBC(int _KPNKPGLPDHI_Op, List<LNCLNAOPNKF> _NMHGLNGACMI_Threads, bool CILNIPJEECH/* = true*/)
    {
		if (CILNIPJEECH)
			LHKOLKACMPA = _NMHGLNGACMI_Threads[_NMHGLNGACMI_Threads.Count - 1];
		return _NMHGLNGACMI_Threads[_NMHGLNGACMI_Threads.Count - 1];
	}

	// // RVA: 0x19F5CE4 Offset: 0x19F5CE4 VA: 0x19F5CE4
	private LNCLNAOPNKF PKNGBAPOFHF(List<LNCLNAOPNKF> _NMHGLNGACMI_Threads)
	{
		return _NMHGLNGACMI_Threads[0];
	}

	// // RVA: 0x19F459C Offset: 0x19F459C VA: 0x19F459C
	private void OMBENJEDFLJ_GetThreads(int _KPNKPGLPDHI_Op, AELPHOILEBM _NGHKJOEDLIP_Settings, List<List<LNCLNAOPNKF>> CHGLFGOKKJG, Action<List<LNCLNAOPNKF>> _BHFHGFKBOHH_OnSuccess, DJBHIFLHJLK _MOBEEPPKFLG_OnFail, bool PAEAHCEJLKG)
	{
		OMBENJEDFLJ_GetThreads(_KPNKPGLPDHI_Op, _NGHKJOEDLIP_Settings, (MMCLJMPEFEP_GetBbsThreads.CAMBPKCCBDO CHCEIJOJDHL) =>
		{
			//0x19F92D4
			ALNCDMPMEHP(_KPNKPGLPDHI_Op, null, _NGHKJOEDLIP_Settings, CHCEIJOJDHL.NMHGLNGACMI_Threads, (List<LNCLNAOPNKF> _AIMLPJOGPID_Data) =>
			{
				//0x19F989C
				CHGLFGOKKJG.Add(_AIMLPJOGPID_Data);
				if(CHCEIJOJDHL.MDIBIIHAAPN_next_page > 0)
				{
					_NGHKJOEDLIP_Settings.IGNIIEBMFIN_Page = CHCEIJOJDHL.MDIBIIHAAPN_next_page;
					OMBENJEDFLJ_GetThreads(_KPNKPGLPDHI_Op, _NGHKJOEDLIP_Settings, CHGLFGOKKJG, _BHFHGFKBOHH_OnSuccess, _MOBEEPPKFLG_OnFail, PAEAHCEJLKG);
					return;
				}
				JKHNFFDFPEC = GAOPGAEHPEE(CHGLFGOKKJG, 1);
				JKHNFFDFPEC.Sort(new ANNDCGIBEDA());
				IMCBBOAFION CMJMGEFNBDK = () =>
				{
					//0x19F9434
					if(!JKHNFFDFPEC.IsEmpty())
					{
						LNCLNAOPNKF l = OMEFFONNMBC(_KPNKPGLPDHI_Op, JKHNFFDFPEC, false);
						if(l.CCBEKGNDDBE.OMMDEKMFBAF_CommentsCount < l.CCBEKGNDDBE.ADGNGHIJFFC_MaxComments)
						{
							_BHFHGFKBOHH_OnSuccess(new List<LNCLNAOPNKF>(JKHNFFDFPEC));
							return;
						}
					}
					if (PAEAHCEJLKG)
					{
						CDPCNICOHEH_CreateThread(_KPNKPGLPDHI_Op, LFAJKNNALBJ(), (FPOEFNEPJDH_CreateBbsThread.OIPIPIHBJFM _OHMCIEMIKCE_t) =>
						{
							//0x19F96DC
							LNCLNAOPNKF l = new LNCLNAOPNKF(_OHMCIEMIKCE_t.LIBHMBKLMHF_ThreadId, OJAGHKJAJEJ.ThreadGroup, OJAGHKJAJEJ.Title);
							JKHNFFDFPEC.Add(l);
							_BHFHGFKBOHH_OnSuccess(new List<LNCLNAOPNKF>(JKHNFFDFPEC));
						}, _MOBEEPPKFLG_OnFail);
						return;
					}
					_BHFHGFKBOHH_OnSuccess(new List<LNCLNAOPNKF>(JKHNFFDFPEC));
				};
				IEAMGJPEPMO(_KPNKPGLPDHI_Op, CMJMGEFNBDK, _MOBEEPPKFLG_OnFail);
			}, _MOBEEPPKFLG_OnFail, true);
		}, _MOBEEPPKFLG_OnFail);
	}

	// // RVA: 0x19F76EC Offset: 0x19F76EC VA: 0x19F76EC
	private void IEAMGJPEPMO(int _KPNKPGLPDHI_Op, IMCBBOAFION _BHFHGFKBOHH_OnSuccess, DJBHIFLHJLK _MOBEEPPKFLG_OnFail)
	{
		//EGJKCPAIFCM.FGGKPMCKKGJ;
		_BHFHGFKBOHH_OnSuccess();
	}

	// // RVA: 0x19F77D8 Offset: 0x19F77D8 VA: 0x19F77D8
	private void GBKJNMFNOJO(int _KPNKPGLPDHI_Op, AELPHOILEBM _NGHKJOEDLIP_Settings, Predicate<LNCLNAOPNKF> AFGNFIPIGHB, Action<LNCLNAOPNKF> _BHFHGFKBOHH_OnSuccess, DJBHIFLHJLK _MOBEEPPKFLG_OnFail)
	{
		OMBENJEDFLJ_GetThreads(_KPNKPGLPDHI_Op, _NGHKJOEDLIP_Settings, (MMCLJMPEFEP_GetBbsThreads.CAMBPKCCBDO CHCEIJOJDHL) =>
		{
			//0x19F9CC4
			ALNCDMPMEHP(_KPNKPGLPDHI_Op, null, _NGHKJOEDLIP_Settings, CHCEIJOJDHL.NMHGLNGACMI_Threads, (List<LNCLNAOPNKF> _AIMLPJOGPID_Data) =>
			{
				//0x19F9E24
				foreach(var k in _AIMLPJOGPID_Data)
				{
					if(AFGNFIPIGHB(k))
					{
						_BHFHGFKBOHH_OnSuccess(k);
						return;
					}
				}
				if (CHCEIJOJDHL.MDIBIIHAAPN_next_page < 1)
				{
					_BHFHGFKBOHH_OnSuccess(null);
					return;
				}
				if (CHCEIJOJDHL != null)
				{
					_NGHKJOEDLIP_Settings.IGNIIEBMFIN_Page = CHCEIJOJDHL.MDIBIIHAAPN_next_page;
					GBKJNMFNOJO(_KPNKPGLPDHI_Op, _NGHKJOEDLIP_Settings, AFGNFIPIGHB, _BHFHGFKBOHH_OnSuccess, _MOBEEPPKFLG_OnFail);
					return;
				}
			}, _MOBEEPPKFLG_OnFail, true);
		}, _MOBEEPPKFLG_OnFail);
	}

	// // RVA: 0x19F4860 Offset: 0x19F4860 VA: 0x19F4860
	private void OMBENJEDFLJ_GetThreads(int _KPNKPGLPDHI_Op, AELPHOILEBM _NGHKJOEDLIP_Settings, Action<MMCLJMPEFEP_GetBbsThreads.CAMBPKCCBDO> _BHFHGFKBOHH_OnSuccess, DJBHIFLHJLK _MOBEEPPKFLG_OnFail)
	{
		if((_KPNKPGLPDHI_Op & 1) == 0)
		{
			MMCLJMPEFEP_GetBbsThreads COJNCNGHIJC_Req = CPHFEPHDJIB_ServerRequester.IFFNCAFNEAG_AddRequest(new MMCLJMPEFEP_GetBbsThreads());
			COJNCNGHIJC_Req.IPKCADIAAPG_Criteria = _NGHKJOEDLIP_Settings.IPKCADIAAPG_Criteria == null ? BIBOMJHJHMG : _NGHKJOEDLIP_Settings.IPKCADIAAPG_Criteria;
			COJNCNGHIJC_Req.MLPLGFLKKLI_Ipp = _NGHKJOEDLIP_Settings.MLPLGFLKKLI_Ipp;
			COJNCNGHIJC_Req.IGNIIEBMFIN_Page = _NGHKJOEDLIP_Settings.IGNIIEBMFIN_Page;
			COJNCNGHIJC_Req.DFJDDIGFGKJ_SortKey = _NGHKJOEDLIP_Settings.DFJDDIGFGKJ_SortKey;
			COJNCNGHIJC_Req.MLMHPBOKJCL_SortOrder = _NGHKJOEDLIP_Settings.MLMHPBOKJCL_SortOrder;
			COJNCNGHIJC_Req.BHFHGFKBOHH_OnSuccess = (CACGCMBKHDI_Request JIPCHHHLOMM) =>
			{
				//0x19FA260
				_BHFHGFKBOHH_OnSuccess(COJNCNGHIJC_Req.NFEAMMJIMPG_Result);
			};
			COJNCNGHIJC_Req.MOBEEPPKFLG_OnFail = (CACGCMBKHDI_Request JIPCHHHLOMM) =>
			{
				//0x19FA1A4
				if (_MOBEEPPKFLG_OnFail != null)
					_MOBEEPPKFLG_OnFail();
			};
		}
		else
		{
			MMCLJMPEFEP_GetBbsThreads COJNCNGHIJC_Req = NKGJPJPHLIF.HHCJCDFCLOB.HKDHHMHHJOJ.IFFNCAFNEAG_AddRequest(new MMCLJMPEFEP_GetBbsThreads());
			COJNCNGHIJC_Req.IPKCADIAAPG_Criteria = _NGHKJOEDLIP_Settings.IPKCADIAAPG_Criteria == null ? BIBOMJHJHMG : _NGHKJOEDLIP_Settings.IPKCADIAAPG_Criteria;
			COJNCNGHIJC_Req.MLPLGFLKKLI_Ipp = _NGHKJOEDLIP_Settings.MLPLGFLKKLI_Ipp;
			COJNCNGHIJC_Req.IGNIIEBMFIN_Page = _NGHKJOEDLIP_Settings.IGNIIEBMFIN_Page;
			COJNCNGHIJC_Req.DFJDDIGFGKJ_SortKey = _NGHKJOEDLIP_Settings.DFJDDIGFGKJ_SortKey;
			COJNCNGHIJC_Req.MLMHPBOKJCL_SortOrder = _NGHKJOEDLIP_Settings.MLMHPBOKJCL_SortOrder;
			COJNCNGHIJC_Req.BHFHGFKBOHH_OnSuccess = (CACGCMBKHDI_Request JIPCHHHLOMM) =>
			{
				//0x19FA1B8
				_BHFHGFKBOHH_OnSuccess(COJNCNGHIJC_Req.NFEAMMJIMPG_Result);
			};
			COJNCNGHIJC_Req.MOBEEPPKFLG_OnFail = (CACGCMBKHDI_Request JIPCHHHLOMM) =>
			{
				//0x19FA190
				if (_MOBEEPPKFLG_OnFail != null)
					_MOBEEPPKFLG_OnFail();
			};
		}
	}

	// // RVA: 0x19F7398 Offset: 0x19F7398 VA: 0x19F7398
	private void CDPCNICOHEH_CreateThread(int _KPNKPGLPDHI_Op, SakashoBbsThreadInfo _KOGBMDOONFA_Info, KCODNIFAICE _BHFHGFKBOHH_OnSuccess, DJBHIFLHJLK _MOBEEPPKFLG_OnFail)
	{
		EKKDNEFMCMO += _BHFHGFKBOHH_OnSuccess;
		if(!DCPNKOLMDKF)
		{
			DCPNKOLMDKF = true;
			FPOEFNEPJDH_CreateBbsThread COJNCNGHIJC_Req = CPHFEPHDJIB_ServerRequester.IFFNCAFNEAG_AddRequest(new FPOEFNEPJDH_CreateBbsThread());
			COJNCNGHIJC_Req.KOGBMDOONFA_Info = _KOGBMDOONFA_Info;
			COJNCNGHIJC_Req.BHFHGFKBOHH_OnSuccess = (CACGCMBKHDI_Request JIPCHHHLOMM) =>
			{
				//0x19FA308
				DCPNKOLMDKF = false;
				EKKDNEFMCMO(COJNCNGHIJC_Req.NFEAMMJIMPG_Result);
				EKKDNEFMCMO = (FPOEFNEPJDH_CreateBbsThread.OIPIPIHBJFM _OHMCIEMIKCE_t) =>
				{
					//0x19F8484
					return;
				};
			};
			COJNCNGHIJC_Req.MOBEEPPKFLG_OnFail = (CACGCMBKHDI_Request JIPCHHHLOMM) =>
			{
				//0x19FACCC
				DCPNKOLMDKF = false;
				_MOBEEPPKFLG_OnFail();
			};
		}
	}

	// // RVA: 0x19F79A0 Offset: 0x19F79A0 VA: 0x19F79A0
	private void OCKOIMLGLCF(int _KPNKPGLPDHI_Op, List<List<CAIPMAMHNJP>> GHIHLNKPKGH, int _POMLAOPLMNA_offset, int _HMFFHLPNMPH_count, List<KEPNMGHABPI.LNCLNAOPNKF> _NMHGLNGACMI_Threads, KEPNMGHABPI.EIAMFNIAFGN _NGHKJOEDLIP_Settings, Action<List<KEPNMGHABPI.CAIPMAMHNJP>> _BHFHGFKBOHH_OnSuccess, DJBHIFLHJLK _MOBEEPPKFLG_OnFail)
	{
		LNCLNAOPNKF GNAOMJEPCLO = OMEFFONNMBC(_KPNKPGLPDHI_Op, _NMHGLNGACMI_Threads, false);
		HMOPLMHMNNP_GetComments(_KPNKPGLPDHI_Op, GNAOMJEPCLO.BOINIEAKFPL_ThreadId, _NGHKJOEDLIP_Settings, (NFIMGIABIOI_GetBbsThreadComments.CIIDLDOOKBB CHCEIJOJDHL) =>
		{
			//0x19FAD18
			LNCLNAOPNKF data = new LNCLNAOPNKF(CHCEIJOJDHL.OHJPNDKBFEC_Thread);
			List<CAIPMAMHNJP> l = FNPFFILDFEI(data, CHCEIJOJDHL.GLNIHJIDABD_Comments);
			if(MLNOKNEECEO.HHJIGMPALKM == null)
			{
				if(!l.IsEmpty())
				{
					MLNOKNEECEO.HHJIGMPALKM = l[0];
				}
			}
			else
			{
				if(GNAOMJEPCLO.BOINIEAKFPL_ThreadId == MLNOKNEECEO.PBLLHAMIBHA.BOINIEAKFPL_ThreadId)
				{
					if(MLNOKNEECEO.PBLLHAMIBHA.CCBEKGNDDBE != null)
					{
						_POMLAOPLMNA_offset = CHCEIJOJDHL.OHJPNDKBFEC_Thread.OMMDEKMFBAF_CommentsCount + _POMLAOPLMNA_offset - MLNOKNEECEO.PBLLHAMIBHA.CCBEKGNDDBE.OMMDEKMFBAF_CommentsCount;
					}
				}
			}
			int cnt = Mathf.Min(_POMLAOPLMNA_offset, l.Count);
			l.RemoveRange(0, cnt);
			if(_HMFFHLPNMPH_count < l.Count)
			{
				l.RemoveRange(_HMFFHLPNMPH_count, l.Count - _HMFFHLPNMPH_count);
			}
			GHIHLNKPKGH.Add(l);
			MLNOKNEECEO.PBLLHAMIBHA = data;
			MLNOKNEECEO.KIHNBLOPLNC = data.BOINIEAKFPL_ThreadId;
			MLNOKNEECEO.FOEFBANLCIM += l.Count;
			if(!l.IsEmpty())
			{
				MLNOKNEECEO.CBPDHJAACAH = l[l.Count - 1];
				MLNOKNEECEO.OIMHHIFNGOI = l[l.Count - 1];
			}
			else
			{
				MLNOKNEECEO.OIMHHIFNGOI = null;
			}
			if(_HMFFHLPNMPH_count <= l.Count)
			{
				List<CAIPMAMHNJP> l2 = GAOPGAEHPEE<CAIPMAMHNJP>(GHIHLNKPKGH, 0);
				l2.Sort(new CGOJGMLAFOH());
				_BHFHGFKBOHH_OnSuccess(l2);
				return;
			}
			if(CHCEIJOJDHL.MDIBIIHAAPN_next_page < 1)
			{
				if(_NMHGLNGACMI_Threads.Count < 2)
				{
					List<CAIPMAMHNJP> l2 = GAOPGAEHPEE<CAIPMAMHNJP>(GHIHLNKPKGH, 0);
					l2.Sort(new CGOJGMLAFOH());
					_BHFHGFKBOHH_OnSuccess(l2);
					return;
				}
				_NMHGLNGACMI_Threads.Remove(GNAOMJEPCLO);
				_NGHKJOEDLIP_Settings.IGNIIEBMFIN_Page = 1;
			}
			else
			{
				_NGHKJOEDLIP_Settings.IGNIIEBMFIN_Page = 1 + (_NGHKJOEDLIP_Settings.IGNIIEBMFIN_Page * _NGHKJOEDLIP_Settings.MLPLGFLKKLI_Ipp + _POMLAOPLMNA_offset) / _NGHKJOEDLIP_Settings.MLPLGFLKKLI_Ipp;
			}
			_POMLAOPLMNA_offset = 0;
			OCKOIMLGLCF(_KPNKPGLPDHI_Op, GHIHLNKPKGH, 0, Mathf.Max(_HMFFHLPNMPH_count - l.Count, 0), _NMHGLNGACMI_Threads, _NGHKJOEDLIP_Settings, _BHFHGFKBOHH_OnSuccess, _MOBEEPPKFLG_OnFail);
		}, _MOBEEPPKFLG_OnFail);
	}

	// // RVA: 0x19F7C0C Offset: 0x19F7C0C VA: 0x19F7C0C
	private List<CAIPMAMHNJP> FNPFFILDFEI(LNCLNAOPNKF MENAGBMBJFJ, List<BNAAJMBJFPG> _GLNIHJIDABD_Comments)
	{
		List<CAIPMAMHNJP> res = new List<CAIPMAMHNJP>(_GLNIHJIDABD_Comments.Count);
		_GLNIHJIDABD_Comments.Sort(new HPDEJLPPKJE());
		foreach(var k in _GLNIHJIDABD_Comments)
		{
			res.Add(new CAIPMAMHNJP(MENAGBMBJFJ, k));
		}
		return res;
	}

	// // RVA: 0x19F68A0 Offset: 0x19F68A0 VA: 0x19F68A0
	private void HLEABLHJPOI(int _KPNKPGLPDHI_Op, LNCLNAOPNKF MENAGBMBJFJ, SakashoBbsCommentInfo _KOGBMDOONFA_Info, DALALJLBNPL _BHFHGFKBOHH_OnSuccess, DJBHIFLHJLK _MOBEEPPKFLG_OnFail, DJBHIFLHJLK NKGHADCBGJO)
    {
		GJJPNNCILLI g = new GJJPNNCILLI(MENAGBMBJFJ, _KOGBMDOONFA_Info, _BHFHGFKBOHH_OnSuccess, _MOBEEPPKFLG_OnFail, NKGHADCBGJO);
		HBPKDJCJELM.Enqueue(g);
		if (HBJNOPOKMCB)
			return;
		HBJNOPOKMCB = true;
		N.a.StartCoroutineWatched(HANCEBLBOPF_Co_DequeueComments(_KPNKPGLPDHI_Op));
	}

	// [IteratorStateMachineAttribute] // RVA: 0x6C2C64 Offset: 0x6C2C64 VA: 0x6C2C64
	// // RVA: 0x19F7EF8 Offset: 0x19F7EF8 VA: 0x19F7EF8
	private IEnumerator HANCEBLBOPF_Co_DequeueComments(int _KPNKPGLPDHI_Op)
	{
		//0x19FBE6C
		while(HBPKDJCJELM.Count > 0)
		{
			bool BEKAMBBOLBO_Done = false;
			GJJPNNCILLI CKHEDJODNIP_c = HBPKDJCJELM.Dequeue();
			if (LHKOLKACMPA != null)
			{
				CKHEDJODNIP_c.MENAGBMBJFJ = LHKOLKACMPA;
			}
			BEJLIJGIGOL(_KPNKPGLPDHI_Op, CKHEDJODNIP_c.MENAGBMBJFJ, CKHEDJODNIP_c.HCAHCFGPJIF_Desc, () =>
			{
				//0x19FB6D8
				BEKAMBBOLBO_Done = true;
				CKHEDJODNIP_c.BHFHGFKBOHH_OnSuccess();
			}, () =>
			{
				//0x19FBB58
				BEKAMBBOLBO_Done = true;
				CKHEDJODNIP_c.MOBEEPPKFLG_OnFail();
			}, () =>
			{
				//0x19FBBA0
				BEKAMBBOLBO_Done = true;
				CKHEDJODNIP_c.NKGHADCBGJO();
			});
			while (!BEKAMBBOLBO_Done)
				yield return null;
			yield return null;
		}
		HBJNOPOKMCB = false;
	}

	// // RVA: 0x19F7FC0 Offset: 0x19F7FC0 VA: 0x19F7FC0
	private void BEJLIJGIGOL(int _KPNKPGLPDHI_Op, LNCLNAOPNKF MENAGBMBJFJ, SakashoBbsCommentInfo _KOGBMDOONFA_Info, DALALJLBNPL _BHFHGFKBOHH_OnSuccess, DJBHIFLHJLK _MOBEEPPKFLG_OnFail, DJBHIFLHJLK NKGHADCBGJO)
	{
		IECJNEHIEKO_CreateBbsComment COJNCNGHIJC_Req = CPHFEPHDJIB_ServerRequester.IFFNCAFNEAG_AddRequest(new IECJNEHIEKO_CreateBbsComment());
		AHAENNIFOAF.IANGEPFFHHM(MENAGBMBJFJ.OODOEBCLCFI_ThreadGroup, ref COJNCNGHIJC_Req.JECLCENDGIH_ThreadType, ref COJNCNGHIJC_Req.GFOIDCMEHGL_RoomUserId, ref COJNCNGHIJC_Req.DNJLJMKKDNA_EventId, ref COJNCNGHIJC_Req.MEBHCFJCKFE_LobbyId);
		COJNCNGHIJC_Req.BDJEICCDKHB_ThreadGroup = MENAGBMBJFJ.OODOEBCLCFI_ThreadGroup;
		COJNCNGHIJC_Req.BOINIEAKFPL_ThreadId = MENAGBMBJFJ.BOINIEAKFPL_ThreadId;
		COJNCNGHIJC_Req.KOGBMDOONFA_Info = _KOGBMDOONFA_Info;
		COJNCNGHIJC_Req.BHFHGFKBOHH_OnSuccess = (CACGCMBKHDI_Request JIPCHHHLOMM) =>
		{
			//0x19FBBE8
			_BHFHGFKBOHH_OnSuccess();
		};
		COJNCNGHIJC_Req.NBFDEFGFLPJ = (SakashoErrorId _CNAIDEAFAAM_Error) =>
		{
			//0x19F8488
			return _CNAIDEAFAAM_Error == SakashoErrorId.MAX_COMMENTS_EXCEEDED;
		};
		COJNCNGHIJC_Req.MOBEEPPKFLG_OnFail = (CACGCMBKHDI_Request JIPCHHHLOMM) =>
		{
			//0x19FBC10
			if(COJNCNGHIJC_Req.NPNNPNAIONN_IsError)
			{
				if(COJNCNGHIJC_Req.CJMFJOMECKI_ErrorId == SakashoErrorId.MAX_COMMENTS_EXCEEDED)
				{
					OMEFFONNMBC(_KPNKPGLPDHI_Op, (LNCLNAOPNKF EOHFABJDJOH) =>
					{
						//0x19FBDFC
						BEJLIJGIGOL(_KPNKPGLPDHI_Op, EOHFABJDJOH, _KOGBMDOONFA_Info, _BHFHGFKBOHH_OnSuccess, _MOBEEPPKFLG_OnFail, NKGHADCBGJO);
					}, () =>
					{
						//0x19FBE54
						if (_MOBEEPPKFLG_OnFail != null)
							_MOBEEPPKFLG_OnFail();
					}, null);
					return;
				}
			}
			if(COJNCNGHIJC_Req.NPNNPNAIONN_IsError)
			{
				if(COJNCNGHIJC_Req.CJMFJOMECKI_ErrorId == SakashoErrorId.NG_WORD_INCLUDED)
				{
					if (NKGHADCBGJO != null)
						NKGHADCBGJO();
					return;
				}
			}
			if (_MOBEEPPKFLG_OnFail != null)
				_MOBEEPPKFLG_OnFail();
		};
	}

	// // RVA: -1 Offset: -1
	private List<T> GAOPGAEHPEE<T>(List<List<T>> EKGFBEFBLEG, int KPKBLPNEBOG/* = 0*/)
	{
		int cnt = 0;
		foreach(var d in EKGFBEFBLEG)
		{
			cnt += d.Count;
		}
		List<T> res = new List<T>(cnt + KPKBLPNEBOG);
		foreach (var d in EKGFBEFBLEG)
		{
			res.AddRange(d);
		}
		return res;
	}
	// /* GenericInstMethod :
	// |
	// |-RVA: 0x1A24BB4 Offset: 0x1A24BB4 VA: 0x1A24BB4
	// |-KEPNMGHABPI.GAOPGAEHPEE<KEPNMGHABPI.CAIPMAMHNJP>
	// |-KEPNMGHABPI.GAOPGAEHPEE<KEPNMGHABPI.LNCLNAOPNKF>
	// |-KEPNMGHABPI.GAOPGAEHPEE<object>
	// */

	// [ConditionalAttribute] // RVA: 0x6C2CDC Offset: 0x6C2CDC VA: 0x6C2CDC
	// // RVA: 0x19F8404 Offset: 0x19F8404 VA: 0x19F8404
	// private void GNGCAIPOOMC(object _IPBHCLIHAPG_Msg, string DOKKMMFKLJI_Color = "cyan") { }
}
