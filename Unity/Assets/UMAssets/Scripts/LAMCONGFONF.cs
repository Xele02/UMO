
using System.Collections.Generic;
using UnityEngine;
using XeApp.Game.Menu;

public class LAMCONGFONF
{
	public class OJFOLGKMBIG
	{
		public int FJOLNJLLJEJ_rank; // 0x8
		public int DNBFMLBNAEE_point; // 0xC
		public bool BEKAMBBOLBO_Done; // 0x10
	}

	public bool PLOOEECNHFB_IsDone; // 0x8
	public bool NPNNPNAIONN_IsError; // 0x9
	public bool FKKDIDMGLMI_IsDroppedPlayer; // 0xA
	public bool FLCLIHBOHCH = true; // 0xB
	public bool DPPIBCENJJJ; // 0xC
	public List<RankingListInfo> HGGPIBNLALJ = new List<RankingListInfo>(); // 0x10
	public List<RankingListInfo> BMKBAMFBAPJ = new List<RankingListInfo>(); // 0x14
	private OJFOLGKMBIG[] KIAFBCEKMEA = new OJFOLGKMBIG[10]; // 0x18
	private OJFOLGKMBIG[] CEPDOODGDEM = new OJFOLGKMBIG[10]; // 0x1C
	private EECOJKDJIFG[] AEJCLHOIDDD = new EECOJKDJIFG[10]; // 0x20

	public static LAMCONGFONF HHCJCDFCLOB { get; private set; } // 0x0 NKACBOEHELJ OKPMHKNCNAL

	//// RVA: 0xD907F8 Offset: 0xD907F8 VA: 0xD907F8
	public void IJBGPAENLJA(MonoBehaviour _DANMJLOBLIE_mb)
	{
		HHCJCDFCLOB = this;
	}

	//// RVA: 0xD9085C Offset: 0xD9085C VA: 0xD9085C
	public bool ECKDEPDMHGP()
	{
		JPJGOECJFEE_EventGoDivaRanking dbGo = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.EFHMLHKODOD_EventGoDivaRanking;
		if(dbGo != null)
		{
			for(int i = 0; i < dbGo.NGHKJOEDLIP_Settings.MPCAGEPEJJJ_Key.Count; i++)
			{
				KIAFBCEKMEA[i] = new OJFOLGKMBIG();
				CEPDOODGDEM[i] = new OJFOLGKMBIG();
				string OCGFKMHNEOF_name_for_api = dbGo.NGHKJOEDLIP_Settings.MPCAGEPEJJJ_Key[i];
				AEJCLHOIDDD[i] = KKLGENJKEBN.HHCJCDFCLOB.JPDPFGFMKHK_rankings.Find((EECOJKDJIFG PKLPKMLGFGK) => {
					//0xD92A98
					return PKLPKMLGFGK.OCGFKMHNEOF_name_for_api == OCGFKMHNEOF_name_for_api;
				});
				if(AEJCLHOIDDD[i] == null)
					return false;
			}
			return true;
		}
		return false;
	}

	//// RVA: 0xD90CA0 Offset: 0xD90CA0 VA: 0xD90CA0
	public OJFOLGKMBIG CEPOFDBHIAC(int LHJCOPMMIGO, bool PFFJNEFNAMI/* = false*/)
	{
		if (PFFJNEFNAMI)
			return CEPDOODGDEM[LHJCOPMMIGO];
		else
			return KIAFBCEKMEA[LHJCOPMMIGO];
	}

	//// RVA: 0xD90CF4 Offset: 0xD90CF4 VA: 0xD90CF4
	public List<int> IFHPGJGLPPF()
	{
		List<int> res = new List<int>();
		if(IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.EFHMLHKODOD_EventGoDivaRanking != null)
		{
			res.AddRange(IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.EFHMLHKODOD_EventGoDivaRanking.NGHKJOEDLIP_Settings.JHPCPNJJHLI_RankingThreshold);
			res.Sort((int _HKICMNAACDA_a, int _BNKHBCBJBKI_b) =>
			{
				//0xD92A90
				return _HKICMNAACDA_a - _BNKHBCBJBKI_b;
			});
		}
		return res;
	}

	//// RVA: 0xD90F38 Offset: 0xD90F38 VA: 0xD90F38
	public void FAMFKPBPIAA_GetRankingPlayerList(int LHJCOPMMIGO, bool PFFJNEFNAMI, int _CJHEHIMLGGL_Position, IMCBBOAFION _KLMFJJCNBIP_OnSuccess, DJBHIFLHJLK _IDAEHNGOKAE_OnRankingError, DJBHIFLHJLK _JGKOLBLPMPG_OnFail)
	{
		DPPIBCENJJJ = false;
		PLOOEECNHFB_IsDone = false;
		NPNNPNAIONN_IsError = false;
		EECOJKDJIFG e = DAKMIKNKHMF_GetRankingInfoForIndex(LHJCOPMMIGO);
		if(e == null)
		{
			PLOOEECNHFB_IsDone = true;
			if (_IDAEHNGOKAE_OnRankingError != null)
				_IDAEHNGOKAE_OnRankingError();
		}
		else
		{
			OJFOLGKMBIG[] ONJBNDCMMNL;
			if (PFFJNEFNAMI)
				ONJBNDCMMNL = CEPDOODGDEM;
			else
				ONJBNDCMMNL = KIAFBCEKMEA;
			KKLGENJKEBN.HHCJCDFCLOB.FAMFKPBPIAA_GetRankingPlayerList(e.OCGFKMHNEOF_name_for_api, PFFJNEFNAMI, _CJHEHIMLGGL_Position, LHJCOPMMIGO, (int NEFEFHBHFFF, List<IBIGBMDANNM> MAGKKPOFJIM) =>
			{
				//0xD92ACC
				ONJBNDCMMNL[LHJCOPMMIGO].FJOLNJLLJEJ_rank = 0;
				ONJBNDCMMNL[LHJCOPMMIGO].DNBFMLBNAEE_point = 0;
				ONJBNDCMMNL[LHJCOPMMIGO].BEKAMBBOLBO_Done = true;
				HGGPIBNLALJ.Clear();
				if(MAGKKPOFJIM != null)
				{
					int ANKHNOGKHDD = NKGJPJPHLIF.HHCJCDFCLOB.CAFHLEFMMGD_GetPlayerId();
					IBIGBMDANNM d = MAGKKPOFJIM.Find((IBIGBMDANNM _GHPLINIACBB_x) =>
					{
						//0xD93100
						return _GHPLINIACBB_x.MLPEHNBNOGD_PlayerId == ANKHNOGKHDD;
					});
					if(d != null)
					{
						ONJBNDCMMNL[LHJCOPMMIGO].FJOLNJLLJEJ_rank = d.FJOLNJLLJEJ_rank;
						ONJBNDCMMNL[LHJCOPMMIGO].DNBFMLBNAEE_point = (int)d.KNIFCANOHOC_score;
					}
					EJHFJGKPHCM(NEFEFHBHFFF, MAGKKPOFJIM, _CJHEHIMLGGL_Position);
				}
				PLOOEECNHFB_IsDone = true;
				if (_KLMFJJCNBIP_OnSuccess != null)
					_KLMFJJCNBIP_OnSuccess();
			}, () =>
			{
				//0xD92E70
				ONJBNDCMMNL[LHJCOPMMIGO].FJOLNJLLJEJ_rank = 0;
				ONJBNDCMMNL[LHJCOPMMIGO].DNBFMLBNAEE_point = 0;
				ONJBNDCMMNL[LHJCOPMMIGO].BEKAMBBOLBO_Done = false;
				PLOOEECNHFB_IsDone = true;
				if (_IDAEHNGOKAE_OnRankingError != null)
					_IDAEHNGOKAE_OnRankingError();
			}, () =>
			{
				//0xD92FAC
				ONJBNDCMMNL[LHJCOPMMIGO].FJOLNJLLJEJ_rank = 0;
				ONJBNDCMMNL[LHJCOPMMIGO].DNBFMLBNAEE_point = 0;
				ONJBNDCMMNL[LHJCOPMMIGO].BEKAMBBOLBO_Done = false;
				PLOOEECNHFB_IsDone = true;
				NPNNPNAIONN_IsError = true;
				if (_JGKOLBLPMPG_OnFail != null)
					_JGKOLBLPMPG_OnFail();
			}, true);
		}
	}

	//// RVA: 0xD912B4 Offset: 0xD912B4 VA: 0xD912B4
	public void JPNACOLKHLB_AddRankingPlayerListSecond(int _CJHEHIMLGGL_Position, int NEFEFHBHFFF, int KKGKLNDOCFI, IMCBBOAFION _KLMFJJCNBIP_OnSuccess, DJBHIFLHJLK _IDAEHNGOKAE_OnRankingError, DJBHIFLHJLK _JGKOLBLPMPG_OnFail)
	{
		PLOOEECNHFB_IsDone = false;
		NPNNPNAIONN_IsError = false;
		KKLGENJKEBN.HHCJCDFCLOB.JPNACOLKHLB_AddRankingPlayerListSecond(_CJHEHIMLGGL_Position, NEFEFHBHFFF, (int _JGNBPFCJLKI_d, List<IBIGBMDANNM> MAGKKPOFJIM) =>
		{
			//0xD93144
			PLOOEECNHFB_IsDone = true;
			BMKBAMFBAPJ.Clear();
			if(MAGKKPOFJIM == null)
			{
				if(NEFEFHBHFFF > 0)
				{
					DPPIBCENJJJ = true;
				}
			}
			else
			{
				if(MAGKKPOFJIM.Count < 1 && NEFEFHBHFFF > 0)
				{
					DPPIBCENJJJ = true;
				}
				CBDFJFCGKNK(_JGNBPFCJLKI_d, MAGKKPOFJIM, 0);
			}
			if(_KLMFJJCNBIP_OnSuccess != null)
				_KLMFJJCNBIP_OnSuccess();
		}, () =>
		{
			//0xD932B8
			PLOOEECNHFB_IsDone = true;
			if(_IDAEHNGOKAE_OnRankingError != null)
				_IDAEHNGOKAE_OnRankingError();
		}, () =>
		{
			//0xD932F8
			PLOOEECNHFB_IsDone = true;
			NPNNPNAIONN_IsError = true;
			if(_JGKOLBLPMPG_OnFail != null)
				_JGKOLBLPMPG_OnFail();
		}, true);
	}

	//// RVA: 0xD914C0 Offset: 0xD914C0 VA: 0xD914C0
	public void HDAMBNOFGAN(int LHJCOPMMIGO, bool PFFJNEFNAMI)
	{
		if (PFFJNEFNAMI)
			CEPDOODGDEM[LHJCOPMMIGO].BEKAMBBOLBO_Done = false;
		else
			KIAFBCEKMEA[LHJCOPMMIGO].BEKAMBBOLBO_Done = false;
	}

	//// RVA: 0xD9152C Offset: 0xD9152C VA: 0xD9152C
	public void HEOKADCEAGL(int LHJCOPMMIGO, bool PFFJNEFNAMI, IMCBBOAFION _KLMFJJCNBIP_OnSuccess, DJBHIFLHJLK _IDAEHNGOKAE_OnRankingError, DJBHIFLHJLK _JGKOLBLPMPG_OnFail)
	{
		PLOOEECNHFB_IsDone = false;
		NPNNPNAIONN_IsError = false;
		EECOJKDJIFG e = DAKMIKNKHMF_GetRankingInfoForIndex(LHJCOPMMIGO);
		if(e == null)
		{
			PLOOEECNHFB_IsDone = true;
			if (_IDAEHNGOKAE_OnRankingError != null)
				_IDAEHNGOKAE_OnRankingError();
		}
		else
		{
			OJFOLGKMBIG[] ONJBNDCMMNL;
			if (PFFJNEFNAMI)
				ONJBNDCMMNL = CEPDOODGDEM;
			else
				ONJBNDCMMNL = KIAFBCEKMEA;
			if(!ONJBNDCMMNL[LHJCOPMMIGO].BEKAMBBOLBO_Done)
			{
				KKLGENJKEBN.HHCJCDFCLOB.HEOKADCEAGL_GetRanks(e.OCGFKMHNEOF_name_for_api, () =>
				{
					//0xD93350
					ONJBNDCMMNL[LHJCOPMMIGO].FJOLNJLLJEJ_rank = (int)KKLGENJKEBN.HHCJCDFCLOB.LPPCNCMEDFA_Rank;
					ONJBNDCMMNL[LHJCOPMMIGO].DNBFMLBNAEE_point = (int)KKLGENJKEBN.HHCJCDFCLOB.IPNEJCOFBIB_ScoreTrunc;
					ONJBNDCMMNL[LHJCOPMMIGO].BEKAMBBOLBO_Done = true;
					PLOOEECNHFB_IsDone = true;
					if (_KLMFJJCNBIP_OnSuccess != null)
						_KLMFJJCNBIP_OnSuccess();
				}, () =>
				{
					//0xD934C0
					ONJBNDCMMNL[LHJCOPMMIGO].FJOLNJLLJEJ_rank = 0;
					ONJBNDCMMNL[LHJCOPMMIGO].DNBFMLBNAEE_point = 0;
					ONJBNDCMMNL[LHJCOPMMIGO].BEKAMBBOLBO_Done = KKLGENJKEBN.HHCJCDFCLOB.CJMFJOMECKI_ErrorId == SakashoErrorId.RANKING_PLAYER_NOT_FOUND;
					PLOOEECNHFB_IsDone = true;
					if (_IDAEHNGOKAE_OnRankingError != null)
						_IDAEHNGOKAE_OnRankingError();
				}, () =>
				{
					//0xD93624
					ONJBNDCMMNL[LHJCOPMMIGO].FJOLNJLLJEJ_rank = 0;
					ONJBNDCMMNL[LHJCOPMMIGO].DNBFMLBNAEE_point = 0;
					ONJBNDCMMNL[LHJCOPMMIGO].BEKAMBBOLBO_Done = false;
					PLOOEECNHFB_IsDone = true;
					NPNNPNAIONN_IsError = true;
					if (_JGKOLBLPMPG_OnFail != null)
						_JGKOLBLPMPG_OnFail();
				}, () =>
				{
					//0xD93778
					ONJBNDCMMNL[LHJCOPMMIGO].FJOLNJLLJEJ_rank = 0;
					ONJBNDCMMNL[LHJCOPMMIGO].DNBFMLBNAEE_point = 0;
					ONJBNDCMMNL[LHJCOPMMIGO].BEKAMBBOLBO_Done = false;
					PLOOEECNHFB_IsDone = true;
					FKKDIDMGLMI_IsDroppedPlayer = true;
				});
			}
			else
			{
				PLOOEECNHFB_IsDone = true;
				if (_KLMFJJCNBIP_OnSuccess != null)
					_KLMFJJCNBIP_OnSuccess();
			}
		}
	}

	//// RVA: 0xD918D8 Offset: 0xD918D8 VA: 0xD918D8
	public void AMKJFGLEJGE_RequestUpdateEventPoint(int LHJCOPMMIGO, int _ABLHIAEDJAI_CurrentValue, long _JHNMKKNEENE_Time)
	{
		EECOJKDJIFG e = DAKMIKNKHMF_GetRankingInfoForIndex(LHJCOPMMIGO);
		if(e != null)
		{
			if(IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.EFHMLHKODOD_EventGoDivaRanking != null && IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.EFHMLHKODOD_EventGoDivaRanking.NGHKJOEDLIP_Settings != null)
			{
				EECOJKDJIFG ee = KKLGENJKEBN.HHCJCDFCLOB.JPDPFGFMKHK_rankings.Find((EECOJKDJIFG _GHPLINIACBB_x) =>
				{
					//0xD938B8
					return e.OCGFKMHNEOF_name_for_api == _GHPLINIACBB_x.OCGFKMHNEOF_name_for_api;
				});
				if (ee != null)
				{
					PKECIDPBEFL.DDBKLMKKCDL data = new PKECIDPBEFL.DDBKLMKKCDL();
					data.BLJIJENHBPM_Id = ee.PPFNGGCBJKC_id;
					data.OACABIDEMGG_Score = KIAFBCEKMEA[LHJCOPMMIGO].DNBFMLBNAEE_point;
					if (data.OACABIDEMGG_Score < _ABLHIAEDJAI_CurrentValue)
						data.OACABIDEMGG_Score = _ABLHIAEDJAI_CurrentValue;
					data.OBGBAOLONDD_UniqueId = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.EFHMLHKODOD_EventGoDivaRanking.NGHKJOEDLIP_Settings.OBGBAOLONDD_UniqueId;
					data.NOBCHBHEPNC_Idx = LHJCOPMMIGO;
					JGEOBNENMAH.HHCJCDFCLOB.CBGMOGIBALL.Add(data);
					KIAFBCEKMEA[LHJCOPMMIGO].BEKAMBBOLBO_Done = false;
					CEPDOODGDEM[LHJCOPMMIGO].BEKAMBBOLBO_Done = false;
				}
			}
		}
	}

	//// RVA: 0xD91C8C Offset: 0xD91C8C VA: 0xD91C8C
	public void FGMOMBKGCNF(int LHJCOPMMIGO, int _ABLHIAEDJAI_CurrentValue/* = 0*/, IMCBBOAFION _KLMFJJCNBIP_OnSuccess/* = null*/, DJBHIFLHJLK NIMPEHIECJH/* = null*/, DJBHIFLHJLK _JGKOLBLPMPG_OnFail/* = null*/)
	{
		PLOOEECNHFB_IsDone = false;
		NPNNPNAIONN_IsError = false;
		EECOJKDJIFG e = DAKMIKNKHMF_GetRankingInfoForIndex(LHJCOPMMIGO);
		if(e == null)
		{
			PLOOEECNHFB_IsDone = true;
			return;
		}
		int a = KIAFBCEKMEA[LHJCOPMMIGO].DNBFMLBNAEE_point;
		if(a < _ABLHIAEDJAI_CurrentValue)
			a = _ABLHIAEDJAI_CurrentValue;
		KKLGENJKEBN.HHCJCDFCLOB.LDOBHAAIDEJ_UpdateRankingScore(e.OCGFKMHNEOF_name_for_api, LHJCOPMMIGO, a, () =>
		{
			//0xD93904
			KIAFBCEKMEA[LHJCOPMMIGO].FJOLNJLLJEJ_rank = (int)KKLGENJKEBN.HHCJCDFCLOB.LPPCNCMEDFA_Rank;
			KIAFBCEKMEA[LHJCOPMMIGO].DNBFMLBNAEE_point = (int)KKLGENJKEBN.HHCJCDFCLOB.IPNEJCOFBIB_ScoreTrunc;
			KIAFBCEKMEA[LHJCOPMMIGO].BEKAMBBOLBO_Done = true;
			CEPDOODGDEM[LHJCOPMMIGO].BEKAMBBOLBO_Done = false;
			PLOOEECNHFB_IsDone = true;
			if(_KLMFJJCNBIP_OnSuccess != null)
				_KLMFJJCNBIP_OnSuccess();
		}, () =>
		{
			//0xD93B1C
			PLOOEECNHFB_IsDone = true;
			if(NIMPEHIECJH != null)
				NIMPEHIECJH();
		}, () =>
		{
			//0xD93B5C
			PLOOEECNHFB_IsDone = true;
			NPNNPNAIONN_IsError = true;
			if(_JGKOLBLPMPG_OnFail != null)
				_JGKOLBLPMPG_OnFail();
		});
	}

	//// RVA: 0xD91F48 Offset: 0xD91F48 VA: 0xD91F48
	private void EJHFJGKPHCM(int NEFEFHBHFFF, List<IBIGBMDANNM> NNDGIAEFMOG, int KKGKLNDOCFI)
	{
		if(NNDGIAEFMOG != null)
		{
			for(int i = 0; i < NNDGIAEFMOG.Count; i++)
			{
				RankingListInfo info = HGGPIBNLALJ.Find((RankingListInfo _GHPLINIACBB_x) =>
				{
					//0xD93BB4
					return NNDGIAEFMOG[i].MLPEHNBNOGD_PlayerId == _GHPLINIACBB_x.friend.MLPEHNBNOGD_PlayerId;
				});
				if(info == null)
				{
					if(NNDGIAEFMOG[i].FJOLNJLLJEJ_rank >= KKGKLNDOCFI)
					{
						EAJCBFGKKFA_FriendInfo data = new EAJCBFGKKFA_FriendInfo();
						data.KHEKNNFCAOI_Init(NNDGIAEFMOG[i]);
						HGGPIBNLALJ.Add(new RankingListInfo(i, true, data));
					}
				}
			}
		}
	}

	//// RVA: 0xD92330 Offset: 0xD92330 VA: 0xD92330
	private void CBDFJFCGKNK(int NEFEFHBHFFF, List<IBIGBMDANNM> NNDGIAEFMOG, int KKGKLNDOCFI)
	{
		if(NNDGIAEFMOG != null)
		{
			if(NNDGIAEFMOG.Count > 0)
			{
				int PGFMIBMJBHD = NNDGIAEFMOG.Count;
				for(int i = 0; i < NNDGIAEFMOG.Count; i++)
				{
					RankingListInfo info = HGGPIBNLALJ.Find((RankingListInfo _GHPLINIACBB_x) =>
					{
						//0xD93CA4
						return _GHPLINIACBB_x.friend.MLPEHNBNOGD_PlayerId == NNDGIAEFMOG[i].MLPEHNBNOGD_PlayerId;
					});
					if(info == null)
					{
						EAJCBFGKKFA_FriendInfo finfo = new EAJCBFGKKFA_FriendInfo();
						finfo.KHEKNNFCAOI_Init(NNDGIAEFMOG[i]);
						info = new RankingListInfo(i, true, finfo);
						if(NEFEFHBHFFF < 0)
						{
							HGGPIBNLALJ.Insert(i, info);
						}
						else
						{
							HGGPIBNLALJ.Add(info);
						}
						BMKBAMFBAPJ.Add(info);
					}
				}
			}
		}
	}

	//// RVA: 0xD91244 Offset: 0xD91244 VA: 0xD91244
	private EECOJKDJIFG DAKMIKNKHMF_GetRankingInfoForIndex(int LHJCOPMMIGO)
	{
		if (AEJCLHOIDDD.Length <= LHJCOPMMIGO)
			return null;
		return AEJCLHOIDDD[LHJCOPMMIGO];
	}

	//// RVA: 0xD92718 Offset: 0xD92718 VA: 0xD92718
	//public static int BFKAHKBKBJE(int FJOLNJLLJEJ, long EAKFLINAPOG) { }
}
