
using System;
using System.Collections.Generic;
using UnityEngine;
using XeApp.Game.Menu;
using XeSys;

public class HNKMEOKCNBI
{
    public static class GBBCPECFEGA
    {
        public const string BCJEBCGKEDN = "deco_present_count";
        public const string AEOBPALLHKA = "deco_visit_count_friend";
        public const string GFBPOPEPHLK = "deco_visit_count_fan";
        public const string CCGBGDHAFDK = "deco_visit_count_other";
    }

    public delegate void DFIBKEBELEC(int KIJAPOFAGPN, int HMFFHLPNMPH);

    public delegate void EOOKLDPPIDJ(int KIJAPOFAGPN, int HMFFHLPNMPH);

    public enum BEABGIOEFLG
    {
        HEEJBCDDOJJ_Friend = 0,
        HNANENNPBCO_Fan = 1,
        KJHABBHBFPD_Other = 2,
    }

    public class BNJBDAEKDJC
    {
        public bool DGNMOIBJBBJ; // 0x8
        public string PCBDMADAIEO = ""; // 0xC
        public bool HMFMOLGBHPO; // 0x10
        public bool FOKBOGCGJFP; // 0x11
    }

	private const string EFEGNNKMHPG = "deco_present_counter_key";
	private const string IDDPAMBNCBJ = "deco_visit_friend_counter_key";
	private const string FBHNEMIGJPJ = "deco_visit_fan_counter_key";
	private const string OAECMCCBLNE = "deco_visit_other_counter_key";

	private NKGJPJPHLIF ANHPHBEOBMD { get { return NKGJPJPHLIF.HHCJCDFCLOB; } } //0x15FC5B4 JCOICINMOCH
	private PJKLMCGEJMK CPHFEPHDJIB_ServerRequester { get { return ANHPHBEOBMD.IBLPICFDGOF_ServerRequester; } } //0x15FC630 JPEBBKJAMCK
	private long EOLFJGMAJAB_CurrentTime { get { return CPHFEPHDJIB_ServerRequester.FJDBNGEPKHL.KMEFBNBFJHI_GetServerTime(); } } //0x15FC660 JBGEFOKAIGN
	private FNCFHIEELGO_DecoVisit BAGELDNHJJJ_SaveDecoVisit { get { return CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave.AJOFHCPLLLC_DecoVisit; } } //0x15FC6B0 HIOBFIMHPFO

	// // RVA: 0x15FC76C Offset: 0x15FC76C VA: 0x15FC76C
	// public void GFBPMOJOPHD(List<int> CGCFENMHJIM, Action<List<HNKMEOKCNBI.BNJBDAEKDJC>> BHFHGFKBOHH, DJBHIFLHJLK MOBEEPPKFLG) { }

	// // RVA: 0x15FCA34 Offset: 0x15FCA34 VA: 0x15FCA34
	public void CHEAPBCCBBN_GetUserDecoSet(int PPFNGGCBJKC, Action<DAJBODHMLAB_DecoPublicSet> BHFHGFKBOHH, DJBHIFLHJLK MOBEEPPKFLG)
	{
		BBHNACPENDM_ServerSaveData data = new BBHNACPENDM_ServerSaveData();
		data.KHEKNNFCAOI_Init(0x10000000000);
		NJNCAHLIHNI_GetPlayerData req = NKGJPJPHLIF.HHCJCDFCLOB.IBLPICFDGOF_ServerRequester.IFFNCAFNEAG_AddRequest(new NJNCAHLIHNI_GetPlayerData());
		req.FAMHAPONILI_Ids = new List<int>();
		req.FAMHAPONILI_Ids.Add(PPFNGGCBJKC);
		req.HHIHCJKLJFF_BlockNames = data.KPIDBPEKMFD_GetBlockList();
		req.PINPBOCDKLI = (int BMBBDIAEOMP, int EHGBICNIBKE, long IFNLEKOILPM, List<string> OHNJJIMGKGK, EDOHBJAPLPF_JsonData IDLHJIOMJBK) =>
		{
			//0x15FEE48
			return data.IIEMACPEEBJ_Load(OHNJJIMGKGK, IDLHJIOMJBK);
		};
		req.BHFHGFKBOHH_OnSuccess = (CACGCMBKHDI_Request JIPCHHHLOMM) =>
		{
			//0x15FEE84
			BHFHGFKBOHH(data.PDKHANKAPCI_DecoPublicSet);
		};
		req.MOBEEPPKFLG_OnFail = (CACGCMBKHDI_Request JIPCHHHLOMM) =>
		{
			//0x15FEF24
			JNHMMBBKIIG(MOBEEPPKFLG);
		};
	}

	// // RVA: 0x15FCD80 Offset: 0x15FCD80 VA: 0x15FCD80
	public void KCKOFIIHDBJ_SendGift(int PPFNGGCBJKC, EOOKLDPPIDJ BHFHGFKBOHH, DJBHIFLHJLK GKKBFGPMJHD, DJBHIFLHJLK LNNNCIADJPC, DJBHIFLHJLK MOBEEPPKFLG)
	{
		if(OIONBFLLDIB_GetPresentCountLeftToSend() != 0)
		{
			GKKBFGPMJHD = LNNNCIADJPC;
			if(!MHGJGAPLMFO(PPFNGGCBJKC))
			{
				IHODCABGEIF_UpdatePlayerCounter req = NKGJPJPHLIF.HHCJCDFCLOB.IBLPICFDGOF_ServerRequester.IFFNCAFNEAG_AddRequest(new IHODCABGEIF_UpdatePlayerCounter());
				req.BIHCCEHLAOD.HJFNKLFIDLL_CountDelta = 1;
				req.BIHCCEHLAOD.MLPEHNBNOGD_PlayerId = PPFNGGCBJKC;
				req.BIHCCEHLAOD.IHALNOJAMLE_MasterName = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.EPAHOAKPAJJ_DecoItem.EFEGBHACJAL("deco_present_counter_key", "deco_present_count");
				int KIJAPOFAGPN = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.EPAHOAKPAJJ_DecoItem.LPJLEHAJADA("present_item_id", 0);
				int JDLJPNMLFID = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.EPAHOAKPAJJ_DecoItem.LPJLEHAJADA("present_item_count", 0);
				req.BHFHGFKBOHH_OnSuccess = (CACGCMBKHDI_Request JIPCHHHLOMM) =>
				{
					//0x15FEF50
					BAGELDNHJJJ_SaveDecoVisit.EILGNIEGDOI_PresentAcquiredAt = EOLFJGMAJAB_CurrentTime;
					BAGELDNHJJJ_SaveDecoVisit.MHPDCGNOBHH_PresentSentList.Add(new NDBFKHKMMCE_DecoItem.FKIMJLOFONM(PPFNGGCBJKC, (int)BAGELDNHJJJ_SaveDecoVisit.EILGNIEGDOI_PresentAcquiredAt ^ 0x569));
					BHFHGFKBOHH(KIJAPOFAGPN, JDLJPNMLFID);
				};
				req.MOBEEPPKFLG_OnFail = (CACGCMBKHDI_Request JIPCHHHLOMM) =>
				{
					//0x15FF578
					JNHMMBBKIIG(MOBEEPPKFLG);
				};
				return;
			}
		}
		GKKBFGPMJHD();
	}

	// // RVA: 0x15FD448 Offset: 0x15FD448 VA: 0x15FD448
	public void MFMIENLDJIL(int PPFNGGCBJKC, BEABGIOEFLG INDDJNMPONH, IMCBBOAFION BHFHGFKBOHH, DJBHIFLHJLK MOBEEPPKFLG)
	{
		if(HAGBEKAHFFM(PPFNGGCBJKC))
		{
			BAGELDNHJJJ_SaveDecoVisit.KAIOEKJJAKH_VisitedAt = EOLFJGMAJAB_CurrentTime;
			BHFHGFKBOHH();
			return;
		}
		string str = "";
		string str1 = "";
		string str2 = "";
		if(INDDJNMPONH == BEABGIOEFLG.KJHABBHBFPD_Other)
		{
			str1 = "deco_visit_count_other";
			str2 = "deco_visit_other_counter_key";
		}
		else if(INDDJNMPONH == BEABGIOEFLG.HNANENNPBCO_Fan)
		{
			str1 = "deco_visit_count_fan";
			str2 = "deco_visit_fan_counter_key";
		}
		else if(INDDJNMPONH == BEABGIOEFLG.HEEJBCDDOJJ_Friend)
		{
			str1 = "deco_visit_count_friend";
			str2 = "deco_visit_friend_counter_key";
		}
		str = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.EPAHOAKPAJJ_DecoItem.EFEGBHACJAL(str2, str1);
		IHODCABGEIF_UpdatePlayerCounter req = NKGJPJPHLIF.HHCJCDFCLOB.IBLPICFDGOF_ServerRequester.IFFNCAFNEAG_AddRequest(new IHODCABGEIF_UpdatePlayerCounter());
		req.BIHCCEHLAOD.HJFNKLFIDLL_CountDelta = 1;
		req.BIHCCEHLAOD.MLPEHNBNOGD_PlayerId = PPFNGGCBJKC;
		req.BIHCCEHLAOD.IHALNOJAMLE_MasterName = str;
		req.BHFHGFKBOHH_OnSuccess = (CACGCMBKHDI_Request JIPCHHHLOMM) =>
		{
			//0x15FF5A4
			BAGELDNHJJJ_SaveDecoVisit.KAIOEKJJAKH_VisitedAt = EOLFJGMAJAB_CurrentTime;
			NDBFKHKMMCE_DecoItem.FKIMJLOFONM data = new NDBFKHKMMCE_DecoItem.FKIMJLOFONM(PPFNGGCBJKC, (int)(BAGELDNHJJJ_SaveDecoVisit.KAIOEKJJAKH_VisitedAt ^ 0x634));
			BAGELDNHJJJ_SaveDecoVisit.MPPKMEIEGFE_VisitList.Add(data);
			BHFHGFKBOHH();
		};
		req.MOBEEPPKFLG_OnFail = (CACGCMBKHDI_Request JIPCHHHLOMM) =>
		{
			//0x15FF73C
			JNHMMBBKIIG(MOBEEPPKFLG);
		};
	}

	// // RVA: 0x15FDB70 Offset: 0x15FDB70 VA: 0x15FDB70
	private void LJCKCIAMJMM_GetCounter(string FFGNHOAHELN, Action<int> BHFHGFKBOHH, DJBHIFLHJLK MOBEEPPKFLG)
	{
		DKFCEGODKFJ_GetPlayerCounters COJNCNGHIJC = CPHFEPHDJIB_ServerRequester.IFFNCAFNEAG_AddRequest(new DKFCEGODKFJ_GetPlayerCounters());
		COJNCNGHIJC.BIHCCEHLAOD.IHALNOJAMLE_CounterName = FFGNHOAHELN;
		COJNCNGHIJC.BIHCCEHLAOD.FAMHAPONILI_PlayerList = new List<int>();
		COJNCNGHIJC.BIHCCEHLAOD.FAMHAPONILI_PlayerList.Add(ANHPHBEOBMD.MDAMJIGBOLD_PlayerId);
		COJNCNGHIJC.BHFHGFKBOHH_OnSuccess = (CACGCMBKHDI_Request JIPCHHHLOMM) =>
		{
			//0x15FF768
			BHFHGFKBOHH(COJNCNGHIJC.NFEAMMJIMPG.OJCNJFLJCLA[ANHPHBEOBMD.MDAMJIGBOLD_PlayerId]);
		};
		COJNCNGHIJC.MOBEEPPKFLG_OnFail = (CACGCMBKHDI_Request JIPCHHHLOMM) =>
		{
			//0x15FF87C
			JNHMMBBKIIG(MOBEEPPKFLG);
		};
	}

	// // RVA: 0x15FD8FC Offset: 0x15FD8FC VA: 0x15FD8FC
	public bool HAGBEKAHFFM(int PPFNGGCBJKC)
	{
		DateTime d = Utility.GetLocalDateTime(BAGELDNHJJJ_SaveDecoVisit.KAIOEKJJAKH_VisitedAt);
		DateTime d2 = Utility.GetLocalDateTime(EOLFJGMAJAB_CurrentTime);
		if(d2 > d)
		{
			BAGELDNHJJJ_SaveDecoVisit.MPPKMEIEGFE_VisitList.Clear();
			return false;
		}
		else
		{
			return BAGELDNHJJJ_SaveDecoVisit.MPPKMEIEGFE_VisitList.Exists((NDBFKHKMMCE_DecoItem.FKIMJLOFONM FBKECKMBCGJ) =>
			{
				//0x15FF8A8
				return NDBFKHKMMCE_DecoItem.FKIMJLOFONM.JNEJKMKNIJJ(FBKECKMBCGJ) == PPFNGGCBJKC;
			});
		}
	}

	// // RVA: 0x15FD328 Offset: 0x15FD328 VA: 0x15FD328
	public bool MHGJGAPLMFO(int PPFNGGCBJKC)
    {
        if(OPEMBPMKMLF())
            return false;
        return BAGELDNHJJJ_SaveDecoVisit.MHPDCGNOBHH_PresentSentList.Exists((NDBFKHKMMCE_DecoItem.FKIMJLOFONM PLFELECFNGI) =>
        {
            //0x15FF8DC
            return NDBFKHKMMCE_DecoItem.FKIMJLOFONM.JNEJKMKNIJJ(PLFELECFNGI) == PPFNGGCBJKC;
        });
    }

	// // RVA: 0x15FDE2C Offset: 0x15FDE2C VA: 0x15FDE2C
	public bool OPEMBPMKMLF()
    {
        DateTime t1 = Utility.GetLocalDateTime(BAGELDNHJJJ_SaveDecoVisit.EILGNIEGDOI_PresentAcquiredAt);
        DateTime t2 = Utility.GetLocalDateTime(EOLFJGMAJAB_CurrentTime);
        if(t1.Date > t2.Date)
        {
            BAGELDNHJJJ_SaveDecoVisit.MHPDCGNOBHH_PresentSentList.Clear();
            return true;
        }
        return false;
    }

	// // RVA: 0x15FDFF4 Offset: 0x15FDFF4 VA: 0x15FDFF4
	public void AEAJKEGDDIG_GetPresentCounter(Action<int> BHFHGFKBOHH, DJBHIFLHJLK MOBEEPPKFLG)
	{
		LJCKCIAMJMM_GetCounter(IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.EPAHOAKPAJJ_DecoItem.EFEGBHACJAL("DecoPresentCounterParamKey", "deco_present_count"), (int BFINGCJHOHI) =>
		{
			//0x15FF910
			int res = 0;
			if(0 < BFINGCJHOHI - BAGELDNHJJJ_SaveDecoVisit.GHEBKKHAAPM_PresentPrevCnt)
				res = BFINGCJHOHI - BAGELDNHJJJ_SaveDecoVisit.GHEBKKHAAPM_PresentPrevCnt;
			BHFHGFKBOHH(res);
		}, MOBEEPPKFLG);
	}

	// // RVA: 0x15FE1B4 Offset: 0x15FE1B4 VA: 0x15FE1B4
	// private int COFBAKNDKNH(int HMFFHLPNMPH, int AMAODOAHHAI) { }

	// // RVA: 0x15FE1C4 Offset: 0x15FE1C4 VA: 0x15FE1C4
	public void OGPBAJHGFLK_AddPresent(int FEOKKEPAIBB)
	{
		BAGELDNHJJJ_SaveDecoVisit.GHEBKKHAAPM_PresentPrevCnt += FEOKKEPAIBB;
	}

	// // RVA: 0x15FD1E8 Offset: 0x15FD1E8 VA: 0x15FD1E8
	public int OIONBFLLDIB_GetPresentCountLeftToSend()
	{
		OPEMBPMKMLF();
		int present_max = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.EPAHOAKPAJJ_DecoItem.LPJLEHAJADA("present_max", 0);
		return present_max - BAGELDNHJJJ_SaveDecoVisit.MHPDCGNOBHH_PresentSentList.Count;
	}

	// // RVA: 0x15FE228 Offset: 0x15FE228 VA: 0x15FE228
	public void MEMCHEIHDAI_GetFriendCounter(Action<int> BHFHGFKBOHH, DJBHIFLHJLK MOBEEPPKFLG)
	{
		LJCKCIAMJMM_GetCounter(IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.EPAHOAKPAJJ_DecoItem.EFEGBHACJAL("deco_visit_friend_counter_key", "deco_visit_count_friend"), (int BFINGCJHOHI) =>
		{
			//0x15FF9EC
			BHFHGFKBOHH(BFINGCJHOHI - BAGELDNHJJJ_SaveDecoVisit.HFJADCMLFAN_VisitPrevCntFriend);
		}, MOBEEPPKFLG);
	}

	// // RVA: 0x15FE3E8 Offset: 0x15FE3E8 VA: 0x15FE3E8
	private void GELPGGODGML_AddFriend(int FEOKKEPAIBB)
	{
		BAGELDNHJJJ_SaveDecoVisit.HFJADCMLFAN_VisitPrevCntFriend += FEOKKEPAIBB;
	}

	// // RVA: 0x15FE44C Offset: 0x15FE44C VA: 0x15FE44C
	public void AHEFGHPBMBJ_GetFanCounter(Action<int> BHFHGFKBOHH, DJBHIFLHJLK MOBEEPPKFLG) 
	{
		LJCKCIAMJMM_GetCounter(IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.EPAHOAKPAJJ_DecoItem.EFEGBHACJAL("deco_visit_fan_counter_key", "deco_visit_count_fan"), (int BFINGCJHOHI) =>
		{
			//0x15FFAA8
			BHFHGFKBOHH(BFINGCJHOHI - BAGELDNHJJJ_SaveDecoVisit.FBINJFGCIOI_VisitPrevCntFan);
		}, MOBEEPPKFLG);
	}

	// // RVA: 0x15FE60C Offset: 0x15FE60C VA: 0x15FE60C
	private void ONLLFJLHEPG_AddFan(int FEOKKEPAIBB)
	{
		BAGELDNHJJJ_SaveDecoVisit.FBINJFGCIOI_VisitPrevCntFan += FEOKKEPAIBB;
	}

	// // RVA: 0x15FE670 Offset: 0x15FE670 VA: 0x15FE670
	public void ALGLKOIKNGL_GetOtherCounter(Action<int> BHFHGFKBOHH, DJBHIFLHJLK MOBEEPPKFLG)
	{
		LJCKCIAMJMM_GetCounter(IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.EPAHOAKPAJJ_DecoItem.EFEGBHACJAL("deco_visit_other_counter_key", "deco_visit_count_other"), (int BFINGCJHOHI) =>
		{
			//0x15FFB64
			BHFHGFKBOHH(BFINGCJHOHI - BAGELDNHJJJ_SaveDecoVisit.IAOOCOKEECB_VisitPrevCntOther);
		}, MOBEEPPKFLG);
	}

	// // RVA: 0x15FE830 Offset: 0x15FE830 VA: 0x15FE830
	private void EFMPEJGCGOG_AddOther(int FEOKKEPAIBB)
	{
		BAGELDNHJJJ_SaveDecoVisit.IAOOCOKEECB_VisitPrevCntOther += FEOKKEPAIBB;
	}

	// // RVA: 0x15FE894 Offset: 0x15FE894 VA: 0x15FE894
	public void HADBMIIBABM_UpdateCounters(DFIBKEBELEC BHFHGFKBOHH, DJBHIFLHJLK MOBEEPPKFLG)
	{
		MEMCHEIHDAI_GetFriendCounter((int COKKKPDGOGO) =>
		{
			//0x15FFC20
			int JPFFIBCDCNJ = COKKKPDGOGO;
			AHEFGHPBMBJ_GetFanCounter((int NLKBGPMCJGO) =>
			{
				//0x15FFD3C
				int JDLHAIMDEOF = NLKBGPMCJGO;
				ALGLKOIKNGL_GetOtherCounter((int CNIKHEEEPGF) =>
				{
					//0x15FFE80
					int EAIPIMCBNJN = CNIKHEEEPGF;
					BAGELDNHJJJ_SaveDecoVisit.LIDCDBKAAFL_VisitAcquiredAt = EOLFJGMAJAB_CurrentTime;
					GELPGGODGML_AddFriend(JPFFIBCDCNJ);
					ONLLFJLHEPG_AddFan(JDLHAIMDEOF);
					EFMPEJGCGOG_AddOther(EAIPIMCBNJN);
					BHFHGFKBOHH(IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.EPAHOAKPAJJ_DecoItem.LPJLEHAJADA("visitors_item_id", 0), IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.EPAHOAKPAJJ_DecoItem.LPJLEHAJADA("visitors_item_count", 1) * Mathf.Min(JDLHAIMDEOF + JPFFIBCDCNJ + EAIPIMCBNJN, IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.EPAHOAKPAJJ_DecoItem.LPJLEHAJADA("visitors_max", 0)));
				}, MOBEEPPKFLG);
			}, MOBEEPPKFLG);
		}, MOBEEPPKFLG);
	}

	// // RVA: 0x15FEA24 Offset: 0x15FEA24 VA: 0x15FEA24
	private void JNHMMBBKIIG(DJBHIFLHJLK MOBEEPPKFLG)
	{
		if(MOBEEPPKFLG != null)
		{
			MOBEEPPKFLG();
			return;
		}
		if(MenuScene.Instance.IsTransition())
			return;
		MenuScene.Instance.GotoTitle();
	}
}
