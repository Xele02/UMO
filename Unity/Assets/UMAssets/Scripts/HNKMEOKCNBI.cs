
using System;
using System.Collections.Generic;
using UnityEngine;
using XeApp.Game.Menu;
using XeSys;

public class HNKMEOKCNBI
{
    public static class GBBCPECFEGA
    {
        public const string BCJEBCGKEDN_deco_present_count = "deco_present_count";
        public const string AEOBPALLHKA_deco_visit_count_friend = "deco_visit_count_friend";
        public const string GFBPOPEPHLK_deco_visit_count_fan = "deco_visit_count_fan";
        public const string CCGBGDHAFDK_deco_visit_count_other = "deco_visit_count_other";
    }

    public delegate void DFIBKEBELEC(int _KIJAPOFAGPN_ItemId, int _HMFFHLPNMPH_count);

    public delegate void EOOKLDPPIDJ(int _KIJAPOFAGPN_ItemId, int _HMFFHLPNMPH_count);

    public enum BEABGIOEFLG
    {
        HEEJBCDDOJJ_Friend = 0,
        HNANENNPBCO_Fan = 1,
        KJHABBHBFPD_2_Other = 2,
    }

    public class BNJBDAEKDJC
    {
        public bool DGNMOIBJBBJ_HasEnabled; // 0x8
        public string PCBDMADAIEO_SetName = ""; // 0xC
        public bool HMFMOLGBHPO; // 0x10
        public bool FOKBOGCGJFP; // 0x11
    }

	private const string EFEGNNKMHPG = "deco_present_counter_key";
	private const string IDDPAMBNCBJ = "deco_visit_friend_counter_key";
	private const string FBHNEMIGJPJ = "deco_visit_fan_counter_key";
	private const string OAECMCCBLNE = "deco_visit_other_counter_key";

	private NKGJPJPHLIF ANHPHBEOBMD { get { return NKGJPJPHLIF.HHCJCDFCLOB; } } //0x15FC5B4 JCOICINMOCH_bgs
	private PJKLMCGEJMK CPHFEPHDJIB_ServerRequester { get { return ANHPHBEOBMD.IBLPICFDGOF_ServerRequester; } } //0x15FC630 JPEBBKJAMCK_bgs
	private long EOLFJGMAJAB_CurrentTime { get { return CPHFEPHDJIB_ServerRequester.FJDBNGEPKHL_Time.KMEFBNBFJHI_GetServerTime(); } } //0x15FC660 JBGEFOKAIGN_bgs
	private FNCFHIEELGO_DecoVisit BAGELDNHJJJ_SaveDecoVisit { get { return CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_PlayerData.AJOFHCPLLLC_DecoVisit; } } //0x15FC6B0 HIOBFIMHPFO_bgs

	// // RVA: 0x15FC76C Offset: 0x15FC76C VA: 0x15FC76C
	// public void GFBPMOJOPHD(List<int> _CGCFENMHJIM_Ids, Action<List<HNKMEOKCNBI.BNJBDAEKDJC>> _BHFHGFKBOHH_OnSuccess, DJBHIFLHJLK _MOBEEPPKFLG_OnFail) { }

	// // RVA: 0x15FCA34 Offset: 0x15FCA34 VA: 0x15FCA34
	public void CHEAPBCCBBN_GetUserDecoSet(int _PPFNGGCBJKC_id, Action<DAJBODHMLAB_DecoPublicSet> _BHFHGFKBOHH_OnSuccess, DJBHIFLHJLK _MOBEEPPKFLG_OnFail)
	{
		BBHNACPENDM_ServerSaveData data = new BBHNACPENDM_ServerSaveData();
		data.KHEKNNFCAOI_Init(0x10000000000);
		NJNCAHLIHNI_GetPlayerData req = NKGJPJPHLIF.HHCJCDFCLOB.IBLPICFDGOF_ServerRequester.IFFNCAFNEAG_AddRequest(new NJNCAHLIHNI_GetPlayerData());
		req.FAMHAPONILI_PlayerIds = new List<int>();
		req.FAMHAPONILI_PlayerIds.Add(_PPFNGGCBJKC_id);
		req.HHIHCJKLJFF_Names = data.KPIDBPEKMFD_GetNames();
		req.PINPBOCDKLI_OnPlayerCb = (int _BMBBDIAEOMP_i, int _EHGBICNIBKE_player_id, long _IFNLEKOILPM_updated_at, List<string> _OHNJJIMGKGK_Names, EDOHBJAPLPF_JsonData _IDLHJIOMJBK_data) =>
		{
			//0x15FEE48
			return data.IIEMACPEEBJ_Deserialize(_OHNJJIMGKGK_Names, _IDLHJIOMJBK_data);
		};
		req.BHFHGFKBOHH_OnSuccess = (CACGCMBKHDI_Request JIPCHHHLOMM) =>
		{
			//0x15FEE84
			_BHFHGFKBOHH_OnSuccess(data.PDKHANKAPCI_DecoPublicSet);
		};
		req.MOBEEPPKFLG_OnFail = (CACGCMBKHDI_Request JIPCHHHLOMM) =>
		{
			//0x15FEF24
			JNHMMBBKIIG(_MOBEEPPKFLG_OnFail);
		};
	}

	// // RVA: 0x15FCD80 Offset: 0x15FCD80 VA: 0x15FCD80
	public void KCKOFIIHDBJ_SendGift(int _PPFNGGCBJKC_id, EOOKLDPPIDJ _BHFHGFKBOHH_OnSuccess, DJBHIFLHJLK GKKBFGPMJHD, DJBHIFLHJLK LNNNCIADJPC, DJBHIFLHJLK _MOBEEPPKFLG_OnFail)
	{
		if(OIONBFLLDIB_GetPresentCountLeftToSend() != 0)
		{
			GKKBFGPMJHD = LNNNCIADJPC;
			if(!MHGJGAPLMFO(_PPFNGGCBJKC_id))
			{
				IHODCABGEIF_UpdatePlayerCounter req = NKGJPJPHLIF.HHCJCDFCLOB.IBLPICFDGOF_ServerRequester.IFFNCAFNEAG_AddRequest(new IHODCABGEIF_UpdatePlayerCounter());
				req.BIHCCEHLAOD.HJFNKLFIDLL_CountDelta = 1;
				req.BIHCCEHLAOD.MLPEHNBNOGD_PlayerId = _PPFNGGCBJKC_id;
				req.BIHCCEHLAOD.IHALNOJAMLE_PlayerCounterMasterName = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.EPAHOAKPAJJ_DecoItem.EFEGBHACJAL_GetStringParam("deco_present_counter_key", "deco_present_count");
				int KIJAPOFAGPN_ItemId = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.EPAHOAKPAJJ_DecoItem.LPJLEHAJADA_GetIntParam("present_item_id", 0);
				int JDLJPNMLFID_ItemCount = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.EPAHOAKPAJJ_DecoItem.LPJLEHAJADA_GetIntParam("present_item_count", 0);
				req.BHFHGFKBOHH_OnSuccess = (CACGCMBKHDI_Request JIPCHHHLOMM) =>
				{
					//0x15FEF50
					BAGELDNHJJJ_SaveDecoVisit.EILGNIEGDOI_PresentAcquiredAt = EOLFJGMAJAB_CurrentTime;
					BAGELDNHJJJ_SaveDecoVisit.MHPDCGNOBHH_PresentSentList.Add(new NDBFKHKMMCE_DecoItem.FKIMJLOFONM(_PPFNGGCBJKC_id, (int)BAGELDNHJJJ_SaveDecoVisit.EILGNIEGDOI_PresentAcquiredAt ^ 0x569));
					_BHFHGFKBOHH_OnSuccess(KIJAPOFAGPN_ItemId, JDLJPNMLFID_ItemCount);
				};
				req.MOBEEPPKFLG_OnFail = (CACGCMBKHDI_Request JIPCHHHLOMM) =>
				{
					//0x15FF578
					JNHMMBBKIIG(_MOBEEPPKFLG_OnFail);
				};
				return;
			}
		}
		GKKBFGPMJHD();
	}

	// // RVA: 0x15FD448 Offset: 0x15FD448 VA: 0x15FD448
	public void MFMIENLDJIL(int _PPFNGGCBJKC_id, BEABGIOEFLG _INDDJNMPONH_type, IMCBBOAFION _BHFHGFKBOHH_OnSuccess, DJBHIFLHJLK _MOBEEPPKFLG_OnFail)
	{
		if(HAGBEKAHFFM(_PPFNGGCBJKC_id))
		{
			BAGELDNHJJJ_SaveDecoVisit.KAIOEKJJAKH_VisitedAt = EOLFJGMAJAB_CurrentTime;
			_BHFHGFKBOHH_OnSuccess();
			return;
		}
		string str = "";
		string str1 = "";
		string str2 = "";
		if(_INDDJNMPONH_type == BEABGIOEFLG.KJHABBHBFPD_2_Other)
		{
			str1 = "deco_visit_count_other";
			str2 = "deco_visit_other_counter_key";
		}
		else if(_INDDJNMPONH_type == BEABGIOEFLG.HNANENNPBCO_Fan)
		{
			str1 = "deco_visit_count_fan";
			str2 = "deco_visit_fan_counter_key";
		}
		else if(_INDDJNMPONH_type == BEABGIOEFLG.HEEJBCDDOJJ_Friend)
		{
			str1 = "deco_visit_count_friend";
			str2 = "deco_visit_friend_counter_key";
		}
		str = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.EPAHOAKPAJJ_DecoItem.EFEGBHACJAL_GetStringParam(str2, str1);
		IHODCABGEIF_UpdatePlayerCounter req = NKGJPJPHLIF.HHCJCDFCLOB.IBLPICFDGOF_ServerRequester.IFFNCAFNEAG_AddRequest(new IHODCABGEIF_UpdatePlayerCounter());
		req.BIHCCEHLAOD.HJFNKLFIDLL_CountDelta = 1;
		req.BIHCCEHLAOD.MLPEHNBNOGD_PlayerId = _PPFNGGCBJKC_id;
		req.BIHCCEHLAOD.IHALNOJAMLE_PlayerCounterMasterName = str;
		req.BHFHGFKBOHH_OnSuccess = (CACGCMBKHDI_Request JIPCHHHLOMM) =>
		{
			//0x15FF5A4
			BAGELDNHJJJ_SaveDecoVisit.KAIOEKJJAKH_VisitedAt = EOLFJGMAJAB_CurrentTime;
			NDBFKHKMMCE_DecoItem.FKIMJLOFONM data = new NDBFKHKMMCE_DecoItem.FKIMJLOFONM(_PPFNGGCBJKC_id, (int)(BAGELDNHJJJ_SaveDecoVisit.KAIOEKJJAKH_VisitedAt ^ 0x634));
			BAGELDNHJJJ_SaveDecoVisit.MPPKMEIEGFE_VisitList.Add(data);
			_BHFHGFKBOHH_OnSuccess();
		};
		req.MOBEEPPKFLG_OnFail = (CACGCMBKHDI_Request JIPCHHHLOMM) =>
		{
			//0x15FF73C
			JNHMMBBKIIG(_MOBEEPPKFLG_OnFail);
		};
	}

	// // RVA: 0x15FDB70 Offset: 0x15FDB70 VA: 0x15FDB70
	private void LJCKCIAMJMM_GetCounter(string FFGNHOAHELN, Action<int> _BHFHGFKBOHH_OnSuccess, DJBHIFLHJLK _MOBEEPPKFLG_OnFail)
	{
		DKFCEGODKFJ_GetPlayerCounters COJNCNGHIJC_Req = CPHFEPHDJIB_ServerRequester.IFFNCAFNEAG_AddRequest(new DKFCEGODKFJ_GetPlayerCounters());
		COJNCNGHIJC_Req.BIHCCEHLAOD.IHALNOJAMLE_PlayerCounterMasterName = FFGNHOAHELN;
		COJNCNGHIJC_Req.BIHCCEHLAOD.FAMHAPONILI_PlayerIds = new List<int>();
		COJNCNGHIJC_Req.BIHCCEHLAOD.FAMHAPONILI_PlayerIds.Add(ANHPHBEOBMD.MDAMJIGBOLD_PlayerId);
		COJNCNGHIJC_Req.BHFHGFKBOHH_OnSuccess = (CACGCMBKHDI_Request JIPCHHHLOMM) =>
		{
			//0x15FF768
			_BHFHGFKBOHH_OnSuccess(COJNCNGHIJC_Req.NFEAMMJIMPG_Result.OJCNJFLJCLA_player_counters[ANHPHBEOBMD.MDAMJIGBOLD_PlayerId]);
		};
		COJNCNGHIJC_Req.MOBEEPPKFLG_OnFail = (CACGCMBKHDI_Request JIPCHHHLOMM) =>
		{
			//0x15FF87C
			JNHMMBBKIIG(_MOBEEPPKFLG_OnFail);
		};
	}

	// // RVA: 0x15FD8FC Offset: 0x15FD8FC VA: 0x15FD8FC
	public bool HAGBEKAHFFM(int _PPFNGGCBJKC_id)
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
				return NDBFKHKMMCE_DecoItem.FKIMJLOFONM.JNEJKMKNIJJ(FBKECKMBCGJ) == _PPFNGGCBJKC_id;
			});
		}
	}

	// // RVA: 0x15FD328 Offset: 0x15FD328 VA: 0x15FD328
	public bool MHGJGAPLMFO(int _PPFNGGCBJKC_id)
    {
        if(OPEMBPMKMLF())
            return false;
        return BAGELDNHJJJ_SaveDecoVisit.MHPDCGNOBHH_PresentSentList.Exists((NDBFKHKMMCE_DecoItem.FKIMJLOFONM PLFELECFNGI) =>
        {
            //0x15FF8DC
            return NDBFKHKMMCE_DecoItem.FKIMJLOFONM.JNEJKMKNIJJ(PLFELECFNGI) == _PPFNGGCBJKC_id;
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
	public void AEAJKEGDDIG_GetPresentCounter(Action<int> _BHFHGFKBOHH_OnSuccess, DJBHIFLHJLK _MOBEEPPKFLG_OnFail)
	{
		LJCKCIAMJMM_GetCounter(IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.EPAHOAKPAJJ_DecoItem.EFEGBHACJAL_GetStringParam("DecoPresentCounterParamKey", "deco_present_count"), (int _BFINGCJHOHI_cnt) =>
		{
			//0x15FF910
			int res = 0;
			if(0 < _BFINGCJHOHI_cnt - BAGELDNHJJJ_SaveDecoVisit.GHEBKKHAAPM_PresentPrevCnt)
				res = _BFINGCJHOHI_cnt - BAGELDNHJJJ_SaveDecoVisit.GHEBKKHAAPM_PresentPrevCnt;
			_BHFHGFKBOHH_OnSuccess(res);
		}, _MOBEEPPKFLG_OnFail);
	}

	// // RVA: 0x15FE1B4 Offset: 0x15FE1B4 VA: 0x15FE1B4
	// private int COFBAKNDKNH(int _HMFFHLPNMPH_count, int AMAODOAHHAI) { }

	// // RVA: 0x15FE1C4 Offset: 0x15FE1C4 VA: 0x15FE1C4
	public void OGPBAJHGFLK_AddPresent(int _FEOKKEPAIBB_diff)
	{
		BAGELDNHJJJ_SaveDecoVisit.GHEBKKHAAPM_PresentPrevCnt += _FEOKKEPAIBB_diff;
	}

	// // RVA: 0x15FD1E8 Offset: 0x15FD1E8 VA: 0x15FD1E8
	public int OIONBFLLDIB_GetPresentCountLeftToSend()
	{
		OPEMBPMKMLF();
		int present_max = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.EPAHOAKPAJJ_DecoItem.LPJLEHAJADA_GetIntParam("present_max", 0);
		return present_max - BAGELDNHJJJ_SaveDecoVisit.MHPDCGNOBHH_PresentSentList.Count;
	}

	// // RVA: 0x15FE228 Offset: 0x15FE228 VA: 0x15FE228
	public void MEMCHEIHDAI_GetFriendCounter(Action<int> _BHFHGFKBOHH_OnSuccess, DJBHIFLHJLK _MOBEEPPKFLG_OnFail)
	{
		LJCKCIAMJMM_GetCounter(IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.EPAHOAKPAJJ_DecoItem.EFEGBHACJAL_GetStringParam("deco_visit_friend_counter_key", "deco_visit_count_friend"), (int _BFINGCJHOHI_cnt) =>
		{
			//0x15FF9EC
			_BHFHGFKBOHH_OnSuccess(_BFINGCJHOHI_cnt - BAGELDNHJJJ_SaveDecoVisit.HFJADCMLFAN_VisitPrevCntFriend);
		}, _MOBEEPPKFLG_OnFail);
	}

	// // RVA: 0x15FE3E8 Offset: 0x15FE3E8 VA: 0x15FE3E8
	private void GELPGGODGML_AddFriend(int _FEOKKEPAIBB_diff)
	{
		BAGELDNHJJJ_SaveDecoVisit.HFJADCMLFAN_VisitPrevCntFriend += _FEOKKEPAIBB_diff;
	}

	// // RVA: 0x15FE44C Offset: 0x15FE44C VA: 0x15FE44C
	public void AHEFGHPBMBJ_GetFanCounter(Action<int> _BHFHGFKBOHH_OnSuccess, DJBHIFLHJLK _MOBEEPPKFLG_OnFail) 
	{
		LJCKCIAMJMM_GetCounter(IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.EPAHOAKPAJJ_DecoItem.EFEGBHACJAL_GetStringParam("deco_visit_fan_counter_key", "deco_visit_count_fan"), (int _BFINGCJHOHI_cnt) =>
		{
			//0x15FFAA8
			_BHFHGFKBOHH_OnSuccess(_BFINGCJHOHI_cnt - BAGELDNHJJJ_SaveDecoVisit.FBINJFGCIOI_VisitPrevCntFan);
		}, _MOBEEPPKFLG_OnFail);
	}

	// // RVA: 0x15FE60C Offset: 0x15FE60C VA: 0x15FE60C
	private void ONLLFJLHEPG_AddFan(int _FEOKKEPAIBB_diff)
	{
		BAGELDNHJJJ_SaveDecoVisit.FBINJFGCIOI_VisitPrevCntFan += _FEOKKEPAIBB_diff;
	}

	// // RVA: 0x15FE670 Offset: 0x15FE670 VA: 0x15FE670
	public void ALGLKOIKNGL_GetOtherCounter(Action<int> _BHFHGFKBOHH_OnSuccess, DJBHIFLHJLK _MOBEEPPKFLG_OnFail)
	{
		LJCKCIAMJMM_GetCounter(IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.EPAHOAKPAJJ_DecoItem.EFEGBHACJAL_GetStringParam("deco_visit_other_counter_key", "deco_visit_count_other"), (int _BFINGCJHOHI_cnt) =>
		{
			//0x15FFB64
			_BHFHGFKBOHH_OnSuccess(_BFINGCJHOHI_cnt - BAGELDNHJJJ_SaveDecoVisit.IAOOCOKEECB_VisitPrevCntOther);
		}, _MOBEEPPKFLG_OnFail);
	}

	// // RVA: 0x15FE830 Offset: 0x15FE830 VA: 0x15FE830
	private void EFMPEJGCGOG_AddOther(int _FEOKKEPAIBB_diff)
	{
		BAGELDNHJJJ_SaveDecoVisit.IAOOCOKEECB_VisitPrevCntOther += _FEOKKEPAIBB_diff;
	}

	// // RVA: 0x15FE894 Offset: 0x15FE894 VA: 0x15FE894
	public void HADBMIIBABM_UpdateCounters(DFIBKEBELEC _BHFHGFKBOHH_OnSuccess, DJBHIFLHJLK _MOBEEPPKFLG_OnFail)
	{
		MEMCHEIHDAI_GetFriendCounter((int COKKKPDGOGO) =>
		{
			//0x15FFC20
			int JPFFIBCDCNJ_friend = COKKKPDGOGO;
			AHEFGHPBMBJ_GetFanCounter((int NLKBGPMCJGO) =>
			{
				//0x15FFD3C
				int JDLHAIMDEOF = NLKBGPMCJGO;
				ALGLKOIKNGL_GetOtherCounter((int CNIKHEEEPGF) =>
				{
					//0x15FFE80
					int EAIPIMCBNJN = CNIKHEEEPGF;
					BAGELDNHJJJ_SaveDecoVisit.LIDCDBKAAFL_VisitAcquiredAt = EOLFJGMAJAB_CurrentTime;
					GELPGGODGML_AddFriend(JPFFIBCDCNJ_friend);
					ONLLFJLHEPG_AddFan(JDLHAIMDEOF);
					EFMPEJGCGOG_AddOther(EAIPIMCBNJN);
					_BHFHGFKBOHH_OnSuccess(IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.EPAHOAKPAJJ_DecoItem.LPJLEHAJADA_GetIntParam("visitors_item_id", 0), IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.EPAHOAKPAJJ_DecoItem.LPJLEHAJADA_GetIntParam("visitors_item_count", 1) * Mathf.Min(JDLHAIMDEOF + JPFFIBCDCNJ_friend + EAIPIMCBNJN, IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.EPAHOAKPAJJ_DecoItem.LPJLEHAJADA_GetIntParam("visitors_max", 0)));
				}, _MOBEEPPKFLG_OnFail);
			}, _MOBEEPPKFLG_OnFail);
		}, _MOBEEPPKFLG_OnFail);
	}

	// // RVA: 0x15FEA24 Offset: 0x15FEA24 VA: 0x15FEA24
	private void JNHMMBBKIIG(DJBHIFLHJLK _MOBEEPPKFLG_OnFail)
	{
		if(_MOBEEPPKFLG_OnFail != null)
		{
			_MOBEEPPKFLG_OnFail();
			return;
		}
		if(MenuScene.Instance.IsTransition())
			return;
		MenuScene.Instance.GotoTitle();
	}
}
