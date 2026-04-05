
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public delegate void LIOLBKLMMIK(int NEFEFHBHFFF, List<IBIGBMDANNM> EHIENOACCIL);

public class RANKINGDROPEXCEPTION : Exception
{
	// RVA: 0xDFCBD0 Offset: 0xDFCBD0 VA: 0xDFCBD0
	public RANKINGDROPEXCEPTION() : base() { }

	// RVA: 0xDFCC54 Offset: 0xDFCC54 VA: 0xDFCC54
	public RANKINGDROPEXCEPTION(string message) : base(message) { }

	// RVA: 0xDFCCE0 Offset: 0xDFCCE0 VA: 0xDFCCE0
	public RANKINGDROPEXCEPTION(string message, Exception inner) : base(message, inner) { }
}

// namespace XeApp.Game.Net.Ranking
[System.Obsolete()]
public class KKLGENJKEBN {}
public class KKLGENJKEBN_NetEventRankingManager
{
	public List<EECOJKDJIFG> JPDPFGFMKHK_rankings = new List<EECOJKDJIFG>(); // 0x8
	public long LPPCNCMEDFA_Rank; // 0x10
	public long IPNEJCOFBIB_ScoreTrunc; // 0x18
	public bool DFBALJAPHMC_DroppedPlayer; // 0x20
	public List<GJDFHLBONOL> PHOPJDPEHJA = new List<GJDFHLBONOL>(); // 0x24
	public bool LNHFLJBGGJB_IsRunning; // 0x28
	public SakashoErrorId CJMFJOMECKI_ErrorId; // 0x2C
	private int MLPLGFLKKLI_Ipp = 10; // 0x30
	private int AOPELJFAMCL_LiveSkillType = 5; // 0x34
	private int NLHAJLNAEMC = 3; // 0x38
	private List<CHPIKCFKJOA> ICJOJOPKNBK = new List<CHPIKCFKJOA>(50); // 0x3C
	private long NDBHONKHCEG; // 0x40
	private int MEMPPLMGNKN; // 0x48
	private bool EBJDDBPFNPB; // 0x4C
	public bool KCIDANFAFPP; // 0x4D

	public static KKLGENJKEBN_NetEventRankingManager HHCJCDFCLOB_Instance { get; private set; } // 0x0 LGMPACEDIJF_bgs NKACBOEHELJ_bgs OKPMHKNCNAL_bgs

	public bool Unused() { return NLHAJLNAEMC == 0; }

	//// RVA: 0x1A04BA4 Offset: 0x1A04BA4 VA: 0x1A04BA4
	//public void KMBMMCDPKDF(bool _JKDJCFEBDHC_Enabled, int _FJOLNJLLJEJ_rank) { }

	//// RVA: 0x1A04BA8 Offset: 0x1A04BA8 VA: 0x1A04BA8
	//public void PAHLEGMEKHI(int _KNIFCANOHOC_score) { }

	//// RVA: 0x1A04BAC Offset: 0x1A04BAC VA: 0x1A04BAC
	public void IJBGPAENLJA_OnAwake(MonoBehaviour _DANMJLOBLIE_mb)
	{
		HHCJCDFCLOB_Instance = this;
	}

	//// RVA: 0x1A04C10 Offset: 0x1A04C10 VA: 0x1A04C10
	public void PMJOEBCEGBP_GetRankings(IMCBBOAFION _KLMFJJCNBIP_OnSuccess, DJBHIFLHJLK _JGKOLBLPMPG_OnFail)
	{
		KNHMEGDFNBP_GetRankings req = NKGJPJPHLIF_SakashoManager.HHCJCDFCLOB_Instance.IBLPICFDGOF_ServerRequester.IFFNCAFNEAG_AddRequest(new KNHMEGDFNBP_GetRankings());
		req.BHFHGFKBOHH_OnSuccess = (CACGCMBKHDI_NetBaseAction NHECPMNKEFK) => {
			//0x1A06844
			KNHMEGDFNBP_GetRankings r = NHECPMNKEFK as KNHMEGDFNBP_GetRankings;
			if(r.NFEAMMJIMPG_Result.JPDPFGFMKHK_rankings.Count == 0)
			{
				LNHFLJBGGJB_IsRunning = false;
				_KLMFJJCNBIP_OnSuccess();
			}
			else
			{
				List<string> strs = new List<string>();
				for(int i = 0; i < r.NFEAMMJIMPG_Result.JPDPFGFMKHK_rankings.Count; i++)
				{
					strs.Add(r.NFEAMMJIMPG_Result.JPDPFGFMKHK_rankings[i].OCGFKMHNEOF_name_for_api);
				}
				FIDDMIAEFEA_GetRankingRecordsByKeys req2 = NKGJPJPHLIF_SakashoManager.HHCJCDFCLOB_Instance.IBLPICFDGOF_ServerRequester.IFFNCAFNEAG_AddRequest(new FIDDMIAEFEA_GetRankingRecordsByKeys());
				req2.JIMKNDJMCID_Keys = strs;
				CACGCMBKHDI_NetBaseAction.HDHIKGLMOGF CMJMGEFNBDK = (CACGCMBKHDI_NetBaseAction DLMLKJACBPM) => {
					//0x1A06BE8
					FIDDMIAEFEA_GetRankingRecordsByKeys r2 = DLMLKJACBPM as FIDDMIAEFEA_GetRankingRecordsByKeys;
					JPDPFGFMKHK_rankings = r2.NFEAMMJIMPG_Result.JPDPFGFMKHK_rankings;
					LNHFLJBGGJB_IsRunning = false;
					_KLMFJJCNBIP_OnSuccess();
				};
				req2.BHFHGFKBOHH_OnSuccess = CMJMGEFNBDK;
				CACGCMBKHDI_NetBaseAction.HDHIKGLMOGF DMLJLPMBLCH = (CACGCMBKHDI_NetBaseAction DLMLKJACBPM) => {
					//0x1A06D44
					CJMFJOMECKI_ErrorId = NHECPMNKEFK.CJMFJOMECKI_ErrorId;
					LNHFLJBGGJB_IsRunning = false;
					_JGKOLBLPMPG_OnFail();
				};
			}

		};
		req.MOBEEPPKFLG_OnFail = (CACGCMBKHDI_NetBaseAction NHECPMNKEFK) => {
			//0x1A06DCC
			CJMFJOMECKI_ErrorId = NHECPMNKEFK.CJMFJOMECKI_ErrorId;
			LNHFLJBGGJB_IsRunning = false;
			_JGKOLBLPMPG_OnFail();
		};
	}

	//// RVA: 0x1A04E30 Offset: 0x1A04E30 VA: 0x1A04E30
	public void LDOBHAAIDEJ_UpdateRankingScore(string _LJNAKDMILMC_key, int LHJCOPMMIGO, double _HOCPLDLAIGL_Score, IMCBBOAFION _KLMFJJCNBIP_OnSuccess, DJBHIFLHJLK NEFKBBNKNPP, DJBHIFLHJLK _JGKOLBLPMPG_OnFail)
	{
		if(_LJNAKDMILMC_key == "*")
		{
			if(JPDPFGFMKHK_rankings.Count == 0)
			{
				NEFKBBNKNPP();
				return;
			}
			_LJNAKDMILMC_key = JPDPFGFMKHK_rankings[LHJCOPMMIGO].OCGFKMHNEOF_name_for_api;
		}

		EECOJKDJIFG IDHFDLLDCEL = JPDPFGFMKHK_rankings.Find((EECOJKDJIFG _HKICMNAACDA_a) =>
		{
			//0x1A06E54
			return _HKICMNAACDA_a.OCGFKMHNEOF_name_for_api == _LJNAKDMILMC_key;
		});
		if(IDHFDLLDCEL != null)
		{
			LNHFLJBGGJB_IsRunning = true;
			FPFPJKJNOFK_UpdateRankingScore req = NKGJPJPHLIF_SakashoManager.HHCJCDFCLOB_Instance.IBLPICFDGOF_ServerRequester.IFFNCAFNEAG_AddRequest(new FPFPJKJNOFK_UpdateRankingScore());
			req.EMPNJPMAKBF_Id = IDHFDLLDCEL.PPFNGGCBJKC_id;
			req.HOCPLDLAIGL_Score = _HOCPLDLAIGL_Score;
			req.BHFHGFKBOHH_OnSuccess = (CACGCMBKHDI_NetBaseAction NHECPMNKEFK) =>
			{
				//0x1A06E88
				FPFPJKJNOFK_UpdateRankingScore r = NHECPMNKEFK as FPFPJKJNOFK_UpdateRankingScore;
				LPPCNCMEDFA_Rank = r.NFEAMMJIMPG_Result.FJOLNJLLJEJ_rank;
				IPNEJCOFBIB_ScoreTrunc = r.NFEAMMJIMPG_Result.KNIFCANOHOC_score;
				DFBALJAPHMC_DroppedPlayer = r.NFEAMMJIMPG_Result.POOLBEALDMA_DroppedPlayer;
				if(DFBALJAPHMC_DroppedPlayer)
				{
					throw new RANKINGDROPEXCEPTION("key=" + _LJNAKDMILMC_key + ",id=" + IDHFDLLDCEL.PPFNGGCBJKC_id);
				}
				LNHFLJBGGJB_IsRunning = false;
				if (_KLMFJJCNBIP_OnSuccess != null)
					_KLMFJJCNBIP_OnSuccess();
			};
			req.MOBEEPPKFLG_OnFail = (CACGCMBKHDI_NetBaseAction NHECPMNKEFK) =>
			{
				//0x1A072B0
				CJMFJOMECKI_ErrorId = NHECPMNKEFK.CJMFJOMECKI_ErrorId;
				LNHFLJBGGJB_IsRunning = false;
				_JGKOLBLPMPG_OnFail();
			};
			return;
		}
		TodoLogger.LogWarning(TodoLogger.SakashoServer, "Ranking not found : " + _LJNAKDMILMC_key);
		NEFKBBNKNPP();
	}

	//// RVA: 0x1A0528C Offset: 0x1A0528C VA: 0x1A0528C
	public void DNJKPPCBINA(string _LJNAKDMILMC_key, IMCBBOAFION _KLMFJJCNBIP_OnSuccess, DJBHIFLHJLK PDPNECFNLNI, IMCBBOAFION FHKCKGJPFFO, DJBHIFLHJLK PPCMIJIFPGP, DJBHIFLHJLK _BFKEGJMPELF_OnError, int BLJMMMABHDA/* = 0*/, int BBLCHHIGFAE/* = -1*/)
	{
		EECOJKDJIFG IDHFDLLDCEL;
		if(_LJNAKDMILMC_key == "*")
		{
			if(JPDPFGFMKHK_rankings.Count == 0)
			{
				//LAB_01a055bc
				PPCMIJIFPGP.Invoke();
				return;
			}
			IDHFDLLDCEL = JPDPFGFMKHK_rankings[BLJMMMABHDA];
        }
		else
		{
			IDHFDLLDCEL = JPDPFGFMKHK_rankings.Find((EECOJKDJIFG _HKICMNAACDA_a) =>
			{
				//0x1A07338
				return _HKICMNAACDA_a.OCGFKMHNEOF_name_for_api == _LJNAKDMILMC_key;
			});
			if(IDHFDLLDCEL == null)
			{
				//LAB_01a055bc
				PPCMIJIFPGP.Invoke();
				return;
			}
		}
		LNHFLJBGGJB_IsRunning = true;
		LPPCNCMEDFA_Rank = 0;
		IPNEJCOFBIB_ScoreTrunc = 0;
		PHOPJDPEHJA.Clear();
        PJKLMCGEJMK_NetActionManager CPHFEPHDJIB_ServerRequester = NKGJPJPHLIF_SakashoManager.HHCJCDFCLOB_Instance.IBLPICFDGOF_ServerRequester;
        OKPEFAPPFDH_GetRanksAroundSelf req = CPHFEPHDJIB_ServerRequester.IFFNCAFNEAG_AddRequest(new OKPEFAPPFDH_GetRanksAroundSelf(false));
		req.EMPNJPMAKBF_Id = IDHFDLLDCEL.PPFNGGCBJKC_id;
		req.MJGOBEGONON_Type = 0;
		req.NHPCKCOPKAM_from = 0;
		req.PJFKNNNDMIA_to = 0;
		req.MOBEEPPKFLG_OnFail = (CACGCMBKHDI_NetBaseAction NHECPMNKEFK) =>
		{
			//0x1A0736C
			CJMFJOMECKI_ErrorId = NHECPMNKEFK.CJMFJOMECKI_ErrorId;
			DJBHIFLHJLK cb;
			if(CJMFJOMECKI_ErrorId == SakashoErrorId.RANKING_PLAYER_NOT_FOUND)
			{
				cb = PDPNECFNLNI;
			}
			else if(CJMFJOMECKI_ErrorId != SakashoErrorId.RANKING_DROPPED_PLAYER && !JGJFFKPFMDB.BDGBCCGLLAJ_IsRankingError(CJMFJOMECKI_ErrorId))
			{
				cb = _BFKEGJMPELF_OnError;
			}
			else
			{
				cb = PPCMIJIFPGP;
			}
			cb.Invoke();
			LNHFLJBGGJB_IsRunning = false;
		};
		req.BHFHGFKBOHH_OnSuccess = (CACGCMBKHDI_NetBaseAction NHECPMNKEFK) =>
		{
			//0x1A074EC
			OKPEFAPPFDH_GetRanksAroundSelf r = NHECPMNKEFK as OKPEFAPPFDH_GetRanksAroundSelf;
			LPPCNCMEDFA_Rank = r.NFEAMMJIMPG_Result.EJDEDOJFOOK_Ranks[0].FJOLNJLLJEJ_rank;
			IPNEJCOFBIB_ScoreTrunc = r.NFEAMMJIMPG_Result.EJDEDOJFOOK_Ranks[0].KNIFCANOHOC_score;
			BBIIHPDBEHP LBHGPLCOCHD_Req = CPHFEPHDJIB_ServerRequester.IFFNCAFNEAG_AddRequest(new BBIIHPDBEHP(false));
			LBHGPLCOCHD_Req.EMPNJPMAKBF_Id = IDHFDLLDCEL.PPFNGGCBJKC_id;
			CACGCMBKHDI_NetBaseAction.HDHIKGLMOGF DMLJLPMBLCH = (CACGCMBKHDI_NetBaseAction DLMLKJACBPM) =>
			{
				//0x1A078E0
				CJMFJOMECKI_ErrorId = DLMLKJACBPM.CJMFJOMECKI_ErrorId;
				LNHFLJBGGJB_IsRunning = false;
				if(CJMFJOMECKI_ErrorId == SakashoErrorId.RANKING_PLAYER_NOT_FOUND)
				{
					PDPNECFNLNI.Invoke();
				}
				else if(CJMFJOMECKI_ErrorId == SakashoErrorId.RANKING_REWARD_NOT_FOUND)
				{
					PDPNECFNLNI.Invoke();
				}
				else if(CJMFJOMECKI_ErrorId == SakashoErrorId.RANKING_REWARD_TAKEN)
				{
					FHKCKGJPFFO.Invoke();
				}
				else if(JGJFFKPFMDB.BDGBCCGLLAJ_IsRankingError(CJMFJOMECKI_ErrorId))
				{
					PPCMIJIFPGP.Invoke();
				}
				else
				{
					_BFKEGJMPELF_OnError.Invoke();
				}
			};
			LBHGPLCOCHD_Req.MOBEEPPKFLG_OnFail = DMLJLPMBLCH;
			LBHGPLCOCHD_Req.BHFHGFKBOHH_OnSuccess = (CACGCMBKHDI_NetBaseAction DLMLKJACBPM) =>
			{
				//0x1A07D64
				BBIIHPDBEHP req3 = DLMLKJACBPM as BBIIHPDBEHP;
				GNDMFGGOPII_GetInventoryRecords req2 = CPHFEPHDJIB_ServerRequester.IFFNCAFNEAG_AddRequest(new GNDMFGGOPII_GetInventoryRecords());
				if(BBLCHHIGFAE < 0)
				{
					req2.AMOMNBEAHBF_InventoryIds = req3.NFEAMMJIMPG_Result.COGMPENEPBD_InventoryIds;
				}
				else
				{
					req2.AMOMNBEAHBF_InventoryIds.Add(req3.NFEAMMJIMPG_Result.COGMPENEPBD_InventoryIds[BBLCHHIGFAE]);
				}
				CACGCMBKHDI_NetBaseAction.HDHIKGLMOGF NDBKOPGCPHJ = (CACGCMBKHDI_NetBaseAction NGHEOHLOOIH) =>
				{
					//0x1A07A9C
					GNDMFGGOPII_GetInventoryRecords req4 = NGHEOHLOOIH as GNDMFGGOPII_GetInventoryRecords;
					for(int i = 0; i < req4.NFEAMMJIMPG_Result.PJJFEAHIPGL_inventories.Count; i++)
					{
						PHOPJDPEHJA.Add(req4.NFEAMMJIMPG_Result.PJJFEAHIPGL_inventories[i]);
					}
					LNHFLJBGGJB_IsRunning = false;
					_KLMFJJCNBIP_OnSuccess();
				};
				req2.BHFHGFKBOHH_OnSuccess = NDBKOPGCPHJ;
				CACGCMBKHDI_NetBaseAction.HDHIKGLMOGF GGPPHHEFHEJ = (CACGCMBKHDI_NetBaseAction NGHEOHLOOIH) =>
				{
					//0x1A07CDC
					CJMFJOMECKI_ErrorId = NGHEOHLOOIH.CJMFJOMECKI_ErrorId;
					LNHFLJBGGJB_IsRunning = false;
					_BFKEGJMPELF_OnError();
				};
				req2.MOBEEPPKFLG_OnFail = GGPPHHEFHEJ;
			};
		};
	}

	//// RVA: 0x1A057E0 Offset: 0x1A057E0 VA: 0x1A057E0
	public void FAMFKPBPIAA_GetRankingPlayerList(string _LJNAKDMILMC_key, bool PFFJNEFNAMI, int _CJHEHIMLGGL_Position, int LHJCOPMMIGO, LIOLBKLMMIK _KLMFJJCNBIP_OnSuccess, DJBHIFLHJLK _IDAEHNGOKAE_OnRankingError, DJBHIFLHJLK _JGKOLBLPMPG_OnFail, bool EEJADLBBMLH/* = false*/)
	{
		N.a.StartCoroutineWatched(BHBKPEOMNJH_Coroutine_RankingPlayerList(_LJNAKDMILMC_key, PFFJNEFNAMI, _CJHEHIMLGGL_Position, LHJCOPMMIGO, _KLMFJJCNBIP_OnSuccess, _IDAEHNGOKAE_OnRankingError, _JGKOLBLPMPG_OnFail, false));
	}

	//[IteratorStateMachineAttribute] // RVA: 0x6BA354 Offset: 0x6BA354 VA: 0x6BA354
	//// RVA: 0x1A05860 Offset: 0x1A05860 VA: 0x1A05860
	private IEnumerator BHBKPEOMNJH_Coroutine_RankingPlayerList(string _LJNAKDMILMC_key, bool PFFJNEFNAMI, int _CJHEHIMLGGL_Position, int LHJCOPMMIGO, LIOLBKLMMIK _KLMFJJCNBIP_OnSuccess, DJBHIFLHJLK _IDAEHNGOKAE_OnRankingError, DJBHIFLHJLK _JGKOLBLPMPG_OnFail, bool EEJADLBBMLH/* = false*/)
	{
		EECOJKDJIFG FEHKCPCAKPN; // 0x38
		PJKLMCGEJMK_NetActionManager JFAIABBIPEO; // 0x3C
		NAOOAJGKILJ_GetFriends FPKPDCLFCJP; // 0x40

		//0x1A0A754
		bool b = false;
		if(_LJNAKDMILMC_key == "*")
		{
			if(JPDPFGFMKHK_rankings.Count != 0)
			{
				_LJNAKDMILMC_key = JPDPFGFMKHK_rankings[LHJCOPMMIGO].OCGFKMHNEOF_name_for_api;
				b = true;
			}
		}
		else
		{
			b = true;
		}
		if (b)
		{
			FEHKCPCAKPN = JPDPFGFMKHK_rankings.Find((EECOJKDJIFG _HKICMNAACDA_a) =>
			{
				// 0x1A08134
				return _HKICMNAACDA_a.OCGFKMHNEOF_name_for_api == _LJNAKDMILMC_key;
			});
			if (FEHKCPCAKPN != null)
			{
				MEMPPLMGNKN = FEHKCPCAKPN.PPFNGGCBJKC_id;
				EBJDDBPFNPB = PFFJNEFNAMI;
				JFAIABBIPEO = NKGJPJPHLIF_SakashoManager.HHCJCDFCLOB_Instance.IBLPICFDGOF_ServerRequester;
				FPKPDCLFCJP = null;
				//CIOECGOMILE_NetPlayerDataManager.HHCJCDFCLOB_Instance.CHNJPFCKFOI_FriendManager.JPEIBHJIHPI_FriendLimit;
				ICJOJOPKNBK.Clear();
				int a = 1;
				while (true)
				{
					//LAB_01a0acf4
					FPKPDCLFCJP = JFAIABBIPEO.IFFNCAFNEAG_AddRequest(new NAOOAJGKILJ_GetFriends());
					FPKPDCLFCJP.IGNIIEBMFIN_Page = 1;
					FPKPDCLFCJP.MLPLGFLKKLI_Ipp = 100;
					yield return FPKPDCLFCJP.GDPDELLNOBO_WaitDone(N.a);
					if (!FPKPDCLFCJP.NPNNPNAIONN_IsError)
					{
						for (int i = 0; i < FPKPDCLFCJP.NFEAMMJIMPG_Result.HBOIBKJEIAP_friends.Count; i++)
						{
							ICJOJOPKNBK.Add(FPKPDCLFCJP.NFEAMMJIMPG_Result.HBOIBKJEIAP_friends[i]);
						}
						if (FPKPDCLFCJP.NFEAMMJIMPG_Result.MDIBIIHAAPN_next_page < 1)
						{
							if (_CJHEHIMLGGL_Position != 0)
							{
								BJKCAKJHMPC_GetTopRanks(_CJHEHIMLGGL_Position, _KLMFJJCNBIP_OnSuccess, _IDAEHNGOKAE_OnRankingError, _JGKOLBLPMPG_OnFail, EEJADLBBMLH);
								yield break;
							}
							OKPEFAPPFDH_GetRanksAroundSelf req = JFAIABBIPEO.IFFNCAFNEAG_AddRequest(new OKPEFAPPFDH_GetRanksAroundSelf(false));
							req.EMPNJPMAKBF_Id = FEHKCPCAKPN.PPFNGGCBJKC_id;
							req.MJGOBEGONON_Type = PFFJNEFNAMI ? 1 : 0;
							req.NHPCKCOPKAM_from = -AOPELJFAMCL_LiveSkillType;
							req.PJFKNNNDMIA_to = AOPELJFAMCL_LiveSkillType;
							req.MOBEEPPKFLG_OnFail = (CACGCMBKHDI_NetBaseAction NHECPMNKEFK) =>
							{
								//0x1A08168
								CJMFJOMECKI_ErrorId = NHECPMNKEFK.CJMFJOMECKI_ErrorId;
								if(NHECPMNKEFK.CJMFJOMECKI_ErrorId == SakashoErrorId.RANKING_PLAYER_NOT_FOUND)
								{
									if (_KLMFJJCNBIP_OnSuccess != null)
										_KLMFJJCNBIP_OnSuccess(0, null);
								}
								else if(JGJFFKPFMDB.BDGBCCGLLAJ_IsRankingError(NHECPMNKEFK.CJMFJOMECKI_ErrorId))
								{
									if (_IDAEHNGOKAE_OnRankingError != null)
										_IDAEHNGOKAE_OnRankingError();
								}
								else
								{
									if (_JGKOLBLPMPG_OnFail != null)
										_JGKOLBLPMPG_OnFail();
								}
							};
							req.BHFHGFKBOHH_OnSuccess = (CACGCMBKHDI_NetBaseAction NHECPMNKEFK) =>
							{
								//0x1A082C0
								List<int> l = new List<int>();
								OKPEFAPPFDH_GetRanksAroundSelf r = NHECPMNKEFK as OKPEFAPPFDH_GetRanksAroundSelf;
								if(r.NFEAMMJIMPG_Result.EJDEDOJFOOK_Ranks.Count == 0)
								{
									BJKCAKJHMPC_GetTopRanks(1, _KLMFJJCNBIP_OnSuccess, _IDAEHNGOKAE_OnRankingError, _JGKOLBLPMPG_OnFail, EEJADLBBMLH);
								}
								else
								{
									for(int i = 0; i < r.NFEAMMJIMPG_Result.EJDEDOJFOOK_Ranks.Count; i++)
									{
										l.Add(r.NFEAMMJIMPG_Result.EJDEDOJFOOK_Ranks[i].EHGBICNIBKE_player_id);
									}
									FGEIGGNCGGD_GetPlayerData(l, _CJHEHIMLGGL_Position, 0, r.NFEAMMJIMPG_Result.EJDEDOJFOOK_Ranks, _KLMFJJCNBIP_OnSuccess, _IDAEHNGOKAE_OnRankingError, _JGKOLBLPMPG_OnFail, EEJADLBBMLH);
								}
							};
							yield break;
						}
						a = FPKPDCLFCJP.NFEAMMJIMPG_Result.MDIBIIHAAPN_next_page;
						continue;
					}
					else
					{
						CJMFJOMECKI_ErrorId = FPKPDCLFCJP.CJMFJOMECKI_ErrorId;
						if (_JGKOLBLPMPG_OnFail != null)
							_JGKOLBLPMPG_OnFail();
						yield break;
					}
				}
			}
		}
		if (_IDAEHNGOKAE_OnRankingError != null)
			_IDAEHNGOKAE_OnRankingError();
	}

	//// RVA: 0x1A059E4 Offset: 0x1A059E4 VA: 0x1A059E4
	private void BJKCAKJHMPC_GetTopRanks(int _CJHEHIMLGGL_Position, LIOLBKLMMIK _KLMFJJCNBIP_OnSuccess, DJBHIFLHJLK _IDAEHNGOKAE_OnRankingError, DJBHIFLHJLK _JGKOLBLPMPG_OnFail, bool EEJADLBBMLH/* = false*/)
	{
		PPFGOOFFNMB_GetTopRanks req = NKGJPJPHLIF_SakashoManager.HHCJCDFCLOB_Instance.IBLPICFDGOF_ServerRequester.IFFNCAFNEAG_AddRequest(new PPFGOOFFNMB_GetTopRanks(false));
		req.EMPNJPMAKBF_Id = MEMPPLMGNKN;
		req.MJGOBEGONON_Type = EBJDDBPFNPB ? 1 : 0;
		req.IGNIIEBMFIN_Page = (_CJHEHIMLGGL_Position - 1) / MLPLGFLKKLI_Ipp;
		req.MLPLGFLKKLI_Ipp = MLPLGFLKKLI_Ipp;
		req.MOBEEPPKFLG_OnFail = (CACGCMBKHDI_NetBaseAction NHECPMNKEFK) =>
		{
			//0x1A08614
			CJMFJOMECKI_ErrorId = NHECPMNKEFK.CJMFJOMECKI_ErrorId;
			if(JGJFFKPFMDB.BDGBCCGLLAJ_IsRankingError(CJMFJOMECKI_ErrorId))
			{
				if (_IDAEHNGOKAE_OnRankingError != null)
					_IDAEHNGOKAE_OnRankingError();
			}
			else
			{
				if (_JGKOLBLPMPG_OnFail != null)
					_JGKOLBLPMPG_OnFail();
			}
		};
		req.BHFHGFKBOHH_OnSuccess = (CACGCMBKHDI_NetBaseAction NHECPMNKEFK) =>
		{
			//0x1A0871C
			PPFGOOFFNMB_GetTopRanks r = NHECPMNKEFK as PPFGOOFFNMB_GetTopRanks;
			if(r.NFEAMMJIMPG_Result.EJDEDOJFOOK_Ranks.Count == 0)
			{
				_KLMFJJCNBIP_OnSuccess(0, null);
			}
			else
			{
				List<int> res = new List<int>();
				for (int i = 0; i < r.NFEAMMJIMPG_Result.EJDEDOJFOOK_Ranks.Count; i++)
				{
					res.Add(r.NFEAMMJIMPG_Result.EJDEDOJFOOK_Ranks[i].EHGBICNIBKE_player_id);
				}
				FGEIGGNCGGD_GetPlayerData(res, _CJHEHIMLGGL_Position, 0, r.NFEAMMJIMPG_Result.EJDEDOJFOOK_Ranks, _KLMFJJCNBIP_OnSuccess, _IDAEHNGOKAE_OnRankingError, _JGKOLBLPMPG_OnFail, EEJADLBBMLH);
			}
		};
	}

	//// RVA: 0x1A05CE4 Offset: 0x1A05CE4 VA: 0x1A05CE4
	public void JPNACOLKHLB_AddRankingPlayerListSecond(int _CJHEHIMLGGL_Position, int NEFEFHBHFFF, LIOLBKLMMIK _KLMFJJCNBIP_OnSuccess, DJBHIFLHJLK _IDAEHNGOKAE_OnRankingError, DJBHIFLHJLK _JGKOLBLPMPG_OnFail, bool EEJADLBBMLH/* = false*/)
	{
		N.a.StartCoroutineWatched(ACAJCMEIJCH_Coroutine_AddRankingPlayerListSecond(_CJHEHIMLGGL_Position, NEFEFHBHFFF, _KLMFJJCNBIP_OnSuccess, _IDAEHNGOKAE_OnRankingError, _JGKOLBLPMPG_OnFail, EEJADLBBMLH));
	}

	//[IteratorStateMachineAttribute] // RVA: 0x6BA3CC Offset: 0x6BA3CC VA: 0x6BA3CC
	//// RVA: 0x1A05D58 Offset: 0x1A05D58 VA: 0x1A05D58
	private IEnumerator ACAJCMEIJCH_Coroutine_AddRankingPlayerListSecond(int _CJHEHIMLGGL_Position, int NEFEFHBHFFF, LIOLBKLMMIK _KLMFJJCNBIP_OnSuccess, DJBHIFLHJLK _IDAEHNGOKAE_OnRankingError, DJBHIFLHJLK _JGKOLBLPMPG_OnFail, bool EEJADLBBMLH/* = false*/)
	{
		//0x1A0A328
		if(NEFEFHBHFFF == 0)
		{
			_IDAEHNGOKAE_OnRankingError();
		}
		else
		{
			PPFGOOFFNMB_GetTopRanks req = NKGJPJPHLIF_SakashoManager.HHCJCDFCLOB_Instance.IBLPICFDGOF_ServerRequester.IFFNCAFNEAG_AddRequest(new PPFGOOFFNMB_GetTopRanks(false));
			req.EMPNJPMAKBF_Id = MEMPPLMGNKN;
			req.MJGOBEGONON_Type = EBJDDBPFNPB ? 1 : 0;
			req.MLPLGFLKKLI_Ipp = MLPLGFLKKLI_Ipp;
			req.IGNIIEBMFIN_Page = (NEFEFHBHFFF == -1 ? _CJHEHIMLGGL_Position - 1 - MLPLGFLKKLI_Ipp : _CJHEHIMLGGL_Position) / MLPLGFLKKLI_Ipp + 1;
			if(req.IGNIIEBMFIN_Page < 2)
				req.IGNIIEBMFIN_Page = 1;
			req.BHFHGFKBOHH_OnSuccess = (CACGCMBKHDI_NetBaseAction NHECPMNKEFK) =>
			{
				//0x1A08B64
				List<int> l = new List<int>();
				PPFGOOFFNMB_GetTopRanks r = NHECPMNKEFK as PPFGOOFFNMB_GetTopRanks;
				if(r.NFEAMMJIMPG_Result.EJDEDOJFOOK_Ranks.Count == 0)
				{
					_KLMFJJCNBIP_OnSuccess(0, null);
				}
				else
				{
					for(int i = 0; i < r.NFEAMMJIMPG_Result.EJDEDOJFOOK_Ranks.Count; i++)
					{
						l.Add(r.NFEAMMJIMPG_Result.EJDEDOJFOOK_Ranks[i].EHGBICNIBKE_player_id);
					}
					FGEIGGNCGGD_GetPlayerData(l, _CJHEHIMLGGL_Position, NEFEFHBHFFF, r.NFEAMMJIMPG_Result.EJDEDOJFOOK_Ranks, _KLMFJJCNBIP_OnSuccess, _IDAEHNGOKAE_OnRankingError, _JGKOLBLPMPG_OnFail, EEJADLBBMLH);
				}
			};
			req.MOBEEPPKFLG_OnFail = (CACGCMBKHDI_NetBaseAction NHECPMNKEFK) =>
			{
				//0x1A08A5C
				CJMFJOMECKI_ErrorId = NHECPMNKEFK.CJMFJOMECKI_ErrorId;
				if(JGJFFKPFMDB.BDGBCCGLLAJ_IsRankingError(NHECPMNKEFK.CJMFJOMECKI_ErrorId))
					_IDAEHNGOKAE_OnRankingError();
				else
					_JGKOLBLPMPG_OnFail();
			};
		}
		yield break;
	}

	//// RVA: 0x1A05EA4 Offset: 0x1A05EA4 VA: 0x1A05EA4
	private void FGEIGGNCGGD_GetPlayerData(List<int> HMDAFLDJLIK, int _CJHEHIMLGGL_Position, int NEFEFHBHFFF, List<OBGBKHKMDNF> NFMMAELFANG, LIOLBKLMMIK _KLMFJJCNBIP_OnSuccess, DJBHIFLHJLK IDAEHNGOKAE, DJBHIFLHJLK _JGKOLBLPMPG_OnFail, bool EEJADLBBMLH)
	{
		PJKLMCGEJMK_NetActionManager CPHFEPHDJIB_ServerRequester = NKGJPJPHLIF_SakashoManager.HHCJCDFCLOB_Instance.IBLPICFDGOF_ServerRequester;
		NJNCAHLIHNI_GetPlayerData req = CPHFEPHDJIB_ServerRequester.IFFNCAFNEAG_AddRequest(new NJNCAHLIHNI_GetPlayerData());
		req.FAMHAPONILI_PlayerIds = HMDAFLDJLIK;
		List<IBIGBMDANNM> IODPMHILFDI = new List<IBIGBMDANNM>();
		BBHNACPENDM_ServerSaveData b = new BBHNACPENDM_ServerSaveData();
		b.EBKCPELHDKN_InitWithBaseAndPublicStatus();
		req.HHIHCJKLJFF_Names = b.KPIDBPEKMFD_GetNames();
		CACGCMBKHDI_NetBaseAction.HDHIKGLMOGF PINPBOCDKLI_OnPlayerCb = (CACGCMBKHDI_NetBaseAction NHECPMNKEFK) =>
		{
			//0x1A09288
			IODPMHILFDI.Sort((IBIGBMDANNM _HKICMNAACDA_a, IBIGBMDANNM _BNKHBCBJBKI_b) =>
			{
				//0x1A06704
				return _HKICMNAACDA_a.FJOLNJLLJEJ_rank - _BNKHBCBJBKI_b.FJOLNJLLJEJ_rank;
			});
			List<IBIGBMDANNM> list = IODPMHILFDI;
			int a = 0;
			if (!EEJADLBBMLH)
			{
				if(NEFEFHBHFFF != 0)
				{
					if(NEFEFHBHFFF == 1)
					{
						IODPMHILFDI.Sort((IBIGBMDANNM _HKICMNAACDA_a, IBIGBMDANNM _BNKHBCBJBKI_b) =>
						{
							//0x1A06804
							return _HKICMNAACDA_a.FJOLNJLLJEJ_rank - _BNKHBCBJBKI_b.FJOLNJLLJEJ_rank;
						});
						List<IBIGBMDANNM> l = new List<IBIGBMDANNM>();
						for(int i = 0; i < IODPMHILFDI.Count; i++)
						{
							if(_CJHEHIMLGGL_Position < IODPMHILFDI[i].FJOLNJLLJEJ_rank)
							{
								l.Add(IODPMHILFDI[i]);
							}
						}
						list = l;
						a = 1;
					}
					else
					{
						if (NEFEFHBHFFF == -1)
							return;
						IODPMHILFDI.Sort((IBIGBMDANNM _HKICMNAACDA_a, IBIGBMDANNM _BNKHBCBJBKI_b) =>
						{
							//0x1A067C4
							return _HKICMNAACDA_a.FJOLNJLLJEJ_rank - _BNKHBCBJBKI_b.FJOLNJLLJEJ_rank;
						});
						List<IBIGBMDANNM> l = new List<IBIGBMDANNM>();
						for (int i = 0; i < IODPMHILFDI.Count; i++)
						{
							if (IODPMHILFDI[i].FJOLNJLLJEJ_rank < _CJHEHIMLGGL_Position)
							{
								l.Add(IODPMHILFDI[i]);
							}
						}
						list = l;
						a = -1;
					}
				}
			}
			else
			{
				if(NEFEFHBHFFF != 0)
				{
					if(NEFEFHBHFFF == 1)
					{
						IODPMHILFDI.Sort((IBIGBMDANNM _HKICMNAACDA_a, IBIGBMDANNM _BNKHBCBJBKI_b) =>
						{
							//0x1A06784
							return _HKICMNAACDA_a.FJOLNJLLJEJ_rank - _BNKHBCBJBKI_b.FJOLNJLLJEJ_rank;
						});
						List<IBIGBMDANNM> l = new List<IBIGBMDANNM>();
						for (int i = 0; i < IODPMHILFDI.Count; i++)
						{
							l.Add(IODPMHILFDI[i]);
						}
						list = l;
						a = 1;
					}
					else
					{
						if (NEFEFHBHFFF == -1)
							return;
						IODPMHILFDI.Sort((IBIGBMDANNM _HKICMNAACDA_a, IBIGBMDANNM _BNKHBCBJBKI_b) =>
						{
							//0x1A06744
							return _HKICMNAACDA_a.FJOLNJLLJEJ_rank - _BNKHBCBJBKI_b.FJOLNJLLJEJ_rank;
						});
						List<IBIGBMDANNM> l = new List<IBIGBMDANNM>();
						for (int i = 0; i < IODPMHILFDI.Count; i++)
						{
							l.Add(IODPMHILFDI[i]);
						}
						list = l;
						a = -1;
					}
				}
			}
			_KLMFJJCNBIP_OnSuccess(a, list);
		};
		req.BHFHGFKBOHH_OnSuccess = PINPBOCDKLI_OnPlayerCb;
		req.MOBEEPPKFLG_OnFail = (CACGCMBKHDI_NetBaseAction NHECPMNKEFK) =>
		{
			//0x1A09D08
			CJMFJOMECKI_ErrorId = NHECPMNKEFK.CJMFJOMECKI_ErrorId;
			_JGKOLBLPMPG_OnFail();
		};
	}

	//// RVA: 0x1A061F0 Offset: 0x1A061F0 VA: 0x1A061F0
	public void HEOKADCEAGL_GetRanks(string _LJNAKDMILMC_key, IMCBBOAFION KLMFJJCNBIP_OnSuccess, DJBHIFLHJLK IDAEHNGOKAE_OnRankingError, DJBHIFLHJLK _BFKEGJMPELF_OnError, DJBHIFLHJLK OPJANCPEKAB_OnDroppedPlayerError)
	{
		LPPCNCMEDFA_Rank = 0;
		IPNEJCOFBIB_ScoreTrunc = 0;
		EECOJKDJIFG data = JPDPFGFMKHK_rankings.Find((EECOJKDJIFG _HKICMNAACDA_a) =>
		{
			//0x1A09DF8
			return _HKICMNAACDA_a.OCGFKMHNEOF_name_for_api == _LJNAKDMILMC_key;
		});
		if(data == null)
		{
			IDAEHNGOKAE_OnRankingError();
			return;
		}
		MEMPPLMGNKN = data.PPFNGGCBJKC_id;
		OKPEFAPPFDH_GetRanksAroundSelf req = NKGJPJPHLIF_SakashoManager.HHCJCDFCLOB_Instance.IBLPICFDGOF_ServerRequester.IFFNCAFNEAG_AddRequest(new OKPEFAPPFDH_GetRanksAroundSelf(false));
		req.EMPNJPMAKBF_Id = data.PPFNGGCBJKC_id;
		req.MJGOBEGONON_Type = 0;
		req.NHPCKCOPKAM_from = 0;
		req.PJFKNNNDMIA_to = 0;
		req.MOBEEPPKFLG_OnFail = (CACGCMBKHDI_NetBaseAction NHECPMNKEFK) =>
		{
			//0x1A09E2C
			CJMFJOMECKI_ErrorId = NHECPMNKEFK.CJMFJOMECKI_ErrorId;
			if (NHECPMNKEFK.CJMFJOMECKI_ErrorId == SakashoErrorId.RANKING_DROPPED_PLAYER)
			{
				LPPCNCMEDFA_Rank = 0;
				IPNEJCOFBIB_ScoreTrunc = 0;
				OPJANCPEKAB_OnDroppedPlayerError();
			}
			else
			{
				LPPCNCMEDFA_Rank = 0;
				IPNEJCOFBIB_ScoreTrunc = 0;
				if(JGJFFKPFMDB.BDGBCCGLLAJ_IsRankingError(NHECPMNKEFK.CJMFJOMECKI_ErrorId))
				{
					IDAEHNGOKAE_OnRankingError();
				}
				else
				{
					_BFKEGJMPELF_OnError();
				}
			}
		};
		req.BHFHGFKBOHH_OnSuccess = (CACGCMBKHDI_NetBaseAction NHECPMNKEFK) =>
		{
			//0x1A09FE4
			OKPEFAPPFDH_GetRanksAroundSelf r = NHECPMNKEFK as OKPEFAPPFDH_GetRanksAroundSelf;
			if(r.NFEAMMJIMPG_Result.EJDEDOJFOOK_Ranks.Count == 0)
			{
				LPPCNCMEDFA_Rank = 0;
				IPNEJCOFBIB_ScoreTrunc = 0;
				IDAEHNGOKAE_OnRankingError();
			}
			else
			{
				IPNEJCOFBIB_ScoreTrunc = r.NFEAMMJIMPG_Result.EJDEDOJFOOK_Ranks[0].KNIFCANOHOC_score;
				LPPCNCMEDFA_Rank = r.NFEAMMJIMPG_Result.EJDEDOJFOOK_Ranks[0].FJOLNJLLJEJ_rank;
				KLMFJJCNBIP_OnSuccess();
			}
		};
	}
}
