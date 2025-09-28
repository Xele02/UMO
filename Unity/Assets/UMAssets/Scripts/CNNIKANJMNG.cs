
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XeApp.Game;

public class CNNIKANJMNG
{
	public static CNNIKANJMNG HHCJCDFCLOB; // 0x0
	private string CDHPNAJNNFN; // 0x8
	private int JLIIKLHGBJH; // 0xC
	private bool EBJDDBPFNPB; // 0x10
	private List<CHPIKCFKJOA> ICJOJOPKNBK = new List<CHPIKCFKJOA>(50); // 0x14
	private int MLPLGFLKKLI_Ipp = 10; // 0x18
	private int AOPELJFAMCL_LiveSkillType = 1; // 0x1C

	// RVA: 0x175D098 Offset: 0x175D098 VA: 0x175D098
	public void IJBGPAENLJA_OnAwake(MonoBehaviour _DANMJLOBLIE_mb)
	{
		HHCJCDFCLOB = this;
	}

	//// RVA: 0x175D0FC Offset: 0x175D0FC VA: 0x175D0FC
	public void FAMFKPBPIAA_GetRankingPlayerList(string _DEPGBBJMFED_CategoryId, int _HHNFHJCAPJO_Target, bool PFFJNEFNAMI, int _CJHEHIMLGGL_Position, int LHJCOPMMIGO, LIOLBKLMMIK _KLMFJJCNBIP_OnSuccess, DJBHIFLHJLK _IDAEHNGOKAE_OnRankingError, DJBHIFLHJLK _JGKOLBLPMPG_OnFail)
	{
		ICJOJOPKNBK.Clear();
		N.a.StartCoroutineWatched(BHBKPEOMNJH_Coroutine_RankingPlayerList(_DEPGBBJMFED_CategoryId, _HHNFHJCAPJO_Target, PFFJNEFNAMI, _CJHEHIMLGGL_Position, LHJCOPMMIGO, _KLMFJJCNBIP_OnSuccess, _IDAEHNGOKAE_OnRankingError, _JGKOLBLPMPG_OnFail));
	}

	//[IteratorStateMachineAttribute] // RVA: 0x6BA4E4 Offset: 0x6BA4E4 VA: 0x6BA4E4
	//// RVA: 0x175D1EC Offset: 0x175D1EC VA: 0x175D1EC
	private IEnumerator BHBKPEOMNJH_Coroutine_RankingPlayerList(string _DEPGBBJMFED_CategoryId, int _HHNFHJCAPJO_Target, bool PFFJNEFNAMI, int _CJHEHIMLGGL_Position, int LHJCOPMMIGO, LIOLBKLMMIK _KLMFJJCNBIP_OnSuccess, DJBHIFLHJLK _IDAEHNGOKAE_OnRankingError, DJBHIFLHJLK _JGKOLBLPMPG_OnFail)
	{
		PJKLMCGEJMK OKDOIAEGADK_Server;
		NAOOAJGKILJ_GetFriends GNEIHIIJMJK_FriendReq;
		List<int> MIINNCFHBCL;

		//0x1760440
		yield return null;
		CDHPNAJNNFN = _DEPGBBJMFED_CategoryId;
		JLIIKLHGBJH = _HHNFHJCAPJO_Target;
		EBJDDBPFNPB = PFFJNEFNAMI;
		OKDOIAEGADK_Server = NKGJPJPHLIF.HHCJCDFCLOB.IBLPICFDGOF_ServerRequester;
		GNEIHIIJMJK_FriendReq = null;
		//CIOECGOMILE.HHCJCDFCLOB.CHNJPFCKFOI_FriendManager.JPEIBHJIHPI_FriendLimit
		MIINNCFHBCL = new List<int>();
		ICJOJOPKNBK.Clear();
		int page = 1;
		while(true)
		{
			GNEIHIIJMJK_FriendReq = OKDOIAEGADK_Server.IFFNCAFNEAG_AddRequest(new NAOOAJGKILJ_GetFriends());
			GNEIHIIJMJK_FriendReq.IGNIIEBMFIN_Page = page;
			GNEIHIIJMJK_FriendReq.MLPLGFLKKLI_Ipp = 100;
			yield return GNEIHIIJMJK_FriendReq.GDPDELLNOBO_WaitDone(N.a);
			if(GNEIHIIJMJK_FriendReq.NPNNPNAIONN_IsError)
			{
				if (_JGKOLBLPMPG_OnFail != null)
					_JGKOLBLPMPG_OnFail();
				yield break;
			}
			for(int i = 0; i < GNEIHIIJMJK_FriendReq.NFEAMMJIMPG_Result.HBOIBKJEIAP_friends.Count; i++)
			{
				ICJOJOPKNBK.Add(GNEIHIIJMJK_FriendReq.NFEAMMJIMPG_Result.HBOIBKJEIAP_friends[i]);
				MIINNCFHBCL.Add(GNEIHIIJMJK_FriendReq.NFEAMMJIMPG_Result.HBOIBKJEIAP_friends[i].NMICBJDPLOH_player.PPFNGGCBJKC_id);
			}
			if(GNEIHIIJMJK_FriendReq.NFEAMMJIMPG_Result.MDIBIIHAAPN_next_page < 1)
			{
				if(!PFFJNEFNAMI)
				{
					if(_CJHEHIMLGGL_Position != 0)
					{
						BJKCAKJHMPC_GetTopRanks(_CJHEHIMLGGL_Position, _KLMFJJCNBIP_OnSuccess, _IDAEHNGOKAE_OnRankingError, _JGKOLBLPMPG_OnFail);
						yield break;
					}
					HNFBMAFPDLB_GetRegularRankingRanksAroundTarget req2 = OKDOIAEGADK_Server.IFFNCAFNEAG_AddRequest(new HNFBMAFPDLB_GetRegularRankingRanksAroundTarget());
					req2.DEPGBBJMFED_CategoryId = _DEPGBBJMFED_CategoryId;
					req2.HHNFHJCAPJO_Target = _HHNFHJCAPJO_Target.ToString();
					req2.NHPCKCOPKAM_from = -AOPELJFAMCL_LiveSkillType;
					req2.PJFKNNNDMIA_to = AOPELJFAMCL_LiveSkillType;
					req2.MOBEEPPKFLG_OnFail = (CACGCMBKHDI_Request NHECPMNKEFK) =>
					{
						//0x175FB80
						if(JGJFFKPFMDB.BDGBCCGLLAJ_IsRankingError(NHECPMNKEFK.CJMFJOMECKI_ErrorId))
						{
							_IDAEHNGOKAE_OnRankingError();
						}
						else
						{
							_JGKOLBLPMPG_OnFail();
						}
					};
					req2.BHFHGFKBOHH_OnSuccess = (CACGCMBKHDI_Request NHECPMNKEFK) =>
					{
						//0x175FC50
						HNFBMAFPDLB_GetRegularRankingRanksAroundTarget r = NHECPMNKEFK as HNFBMAFPDLB_GetRegularRankingRanksAroundTarget;
						if(r.NFEAMMJIMPG_Result.DHDHHHOAIKF_regular_ranking_ranks.Count == 0)
						{
							BJKCAKJHMPC_GetTopRanks(1, _KLMFJJCNBIP_OnSuccess, _IDAEHNGOKAE_OnRankingError, _JGKOLBLPMPG_OnFail);
						}
						else
						{
							List<int> l_ = new List<int>();
							for(int i_ = 0; i_ < r.NFEAMMJIMPG_Result.DHDHHHOAIKF_regular_ranking_ranks.Count; i_++)
							{
								l_.Add(r.NFEAMMJIMPG_Result.DHDHHHOAIKF_regular_ranking_ranks[i_].EHGBICNIBKE_player_id);
							}
							FGEIGGNCGGD_GetPlayerData(l_, _CJHEHIMLGGL_Position, 0, r.NFEAMMJIMPG_Result.DHDHHHOAIKF_regular_ranking_ranks, _KLMFJJCNBIP_OnSuccess, _IDAEHNGOKAE_OnRankingError, _JGKOLBLPMPG_OnFail);
						}
					};
					yield break;
				}
				if(MIINNCFHBCL.Count != 0)
				{
					FGEIGGNCGGD_GetPlayerData(MIINNCFHBCL, _CJHEHIMLGGL_Position, 2, null, (int NEFEFHBHFFF, List<IBIGBMDANNM> MAGKKPOFJIM) =>
					{
						//0x175F8A0
						IBIGBMDANNM item_ = APGCNBONNPE_GetPlayerInfo(_DEPGBBJMFED_CategoryId, _HHNFHJCAPJO_Target);
						if(item_.HMLEDBJDCAF_PreciseScore >= 0)
						{
							MAGKKPOFJIM.Add(item_);
						}
						MAGKKPOFJIM.Sort((IBIGBMDANNM _HKICMNAACDA_a, IBIGBMDANNM _BNKHBCBJBKI_b) =>
						{
							//0x175E0C8
							double diff = _BNKHBCBJBKI_b.HMLEDBJDCAF_PreciseScore - _HKICMNAACDA_a.HMLEDBJDCAF_PreciseScore;
							if(diff < 0)
								diff = -diff;
							if(diff >= 0.0001)
							{
								return _BNKHBCBJBKI_b.HMLEDBJDCAF_PreciseScore.CompareTo(_HKICMNAACDA_a.HMLEDBJDCAF_PreciseScore);
							}
							else
							{
								return _HKICMNAACDA_a.MLPEHNBNOGD_PlayerId - _BNKHBCBJBKI_b.MLPEHNBNOGD_PlayerId;
							}
						});
						for(int i = 0; i < MAGKKPOFJIM.Count; i++)
						{
							MAGKKPOFJIM[i].FJOLNJLLJEJ_rank = i + 1;
						}
						_KLMFJJCNBIP_OnSuccess(0, MAGKKPOFJIM);
					}, () =>
					{
						//0x175FB28
						_IDAEHNGOKAE_OnRankingError();
					}, () =>
					{
						//0x175FB54
						_JGKOLBLPMPG_OnFail();
					});
					yield break;
				}
				List<IBIGBMDANNM> l = new List<IBIGBMDANNM>();
				IBIGBMDANNM item = APGCNBONNPE_GetPlayerInfo(_DEPGBBJMFED_CategoryId, _HHNFHJCAPJO_Target);
				if(item.HMLEDBJDCAF_PreciseScore >= 0)
				{
					l.Add(item);
				}
				_KLMFJJCNBIP_OnSuccess(0, l);
				yield break;
			}
			page = GNEIHIIJMJK_FriendReq.NFEAMMJIMPG_Result.MDIBIIHAAPN_next_page;
		}
	}

	//// RVA: 0x175D354 Offset: 0x175D354 VA: 0x175D354
	private void BJKCAKJHMPC_GetTopRanks(int _CJHEHIMLGGL_Position, LIOLBKLMMIK _KLMFJJCNBIP_OnSuccess, DJBHIFLHJLK _IDAEHNGOKAE_OnRankingError, DJBHIFLHJLK _JGKOLBLPMPG_OnFail)
	{
		PFDPLFOGMNF_GetRegularRankingTopRank req = NKGJPJPHLIF.HHCJCDFCLOB.IBLPICFDGOF_ServerRequester.IFFNCAFNEAG_AddRequest(new PFDPLFOGMNF_GetRegularRankingTopRank());
		req.DEPGBBJMFED_CategoryId = CDHPNAJNNFN;
		req.HHNFHJCAPJO_Target = JLIIKLHGBJH.ToString();
		req.IGNIIEBMFIN_Page = ((_CJHEHIMLGGL_Position - 1) / MLPLGFLKKLI_Ipp) + 1;
		req.MLPLGFLKKLI_Ipp = MLPLGFLKKLI_Ipp;
		req.MOBEEPPKFLG_OnFail = (CACGCMBKHDI_Request NHECPMNKEFK) =>
		{
			//0x175E248
			if(JGJFFKPFMDB.BDGBCCGLLAJ_IsRankingError(NHECPMNKEFK.CJMFJOMECKI_ErrorId))
			{
				_IDAEHNGOKAE_OnRankingError();
			}
			else
			{
				_JGKOLBLPMPG_OnFail();
			}
		};
		req.BHFHGFKBOHH_OnSuccess = (CACGCMBKHDI_Request NHECPMNKEFK) =>
		{
			//0x175E318
			List<int> l = new List<int>();
			PFDPLFOGMNF_GetRegularRankingTopRank r = NHECPMNKEFK as PFDPLFOGMNF_GetRegularRankingTopRank;
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
				FGEIGGNCGGD_GetPlayerData(l, _CJHEHIMLGGL_Position, 0, r.NFEAMMJIMPG_Result.EJDEDOJFOOK_Ranks, _KLMFJJCNBIP_OnSuccess, _IDAEHNGOKAE_OnRankingError, _JGKOLBLPMPG_OnFail);
			}
		};
	}

	//// RVA: 0x175D630 Offset: 0x175D630 VA: 0x175D630
	public void JPNACOLKHLB_AddRankingPlayerListSecond(int _CJHEHIMLGGL_Position, int NEFEFHBHFFF, LIOLBKLMMIK _KLMFJJCNBIP_OnSuccess, DJBHIFLHJLK _IDAEHNGOKAE_OnRankingError, DJBHIFLHJLK _JGKOLBLPMPG_OnFail)
	{
		N.a.StartCoroutineWatched(ACAJCMEIJCH_Coroutine_AddRankingPlayerListSecond(_CJHEHIMLGGL_Position, NEFEFHBHFFF, _KLMFJJCNBIP_OnSuccess, _IDAEHNGOKAE_OnRankingError, _JGKOLBLPMPG_OnFail));
	}

	//[IteratorStateMachineAttribute] // RVA: 0x6BA55C Offset: 0x6BA55C VA: 0x6BA55C
	//// RVA: 0x175D6A4 Offset: 0x175D6A4 VA: 0x175D6A4
	private IEnumerator ACAJCMEIJCH_Coroutine_AddRankingPlayerListSecond(int _CJHEHIMLGGL_Position, int NEFEFHBHFFF, LIOLBKLMMIK _KLMFJJCNBIP_OnSuccess, DJBHIFLHJLK _IDAEHNGOKAE_OnRankingError, DJBHIFLHJLK _JGKOLBLPMPG_OnFail)
	{
		//0x175FF8C
		if(!EBJDDBPFNPB && NEFEFHBHFFF != 0)
		{
			PFDPLFOGMNF_GetRegularRankingTopRank req = NKGJPJPHLIF.HHCJCDFCLOB.IBLPICFDGOF_ServerRequester.IFFNCAFNEAG_AddRequest(new PFDPLFOGMNF_GetRegularRankingTopRank());
			req.DEPGBBJMFED_CategoryId = CDHPNAJNNFN;
			req.HHNFHJCAPJO_Target = JLIIKLHGBJH.ToString();
			req.MLPLGFLKKLI_Ipp = MLPLGFLKKLI_Ipp;
			req.NBFDEFGFLPJ = (SakashoErrorId LJJGBICGLLF) =>
			{
				//0x175E178
				return LJJGBICGLLF == SakashoErrorId.REGULAR_RANKING_NOT_GENERATED;
			};
			int v = _CJHEHIMLGGL_Position;
			if(NEFEFHBHFFF == -1)
				v = _CJHEHIMLGGL_Position - 1 - MLPLGFLKKLI_Ipp;
			req.IGNIIEBMFIN_Page = v / MLPLGFLKKLI_Ipp + 1;
			if(req.IGNIIEBMFIN_Page < 2)
				req.IGNIIEBMFIN_Page = 1;
			req.MOBEEPPKFLG_OnFail = (CACGCMBKHDI_Request NHECPMNKEFK) =>
			{
				//0x175E644
				if(NHECPMNKEFK.CJMFJOMECKI_ErrorId == SakashoErrorId.REGULAR_RANKING_NOT_GENERATED)
				{
					_KLMFJJCNBIP_OnSuccess(NEFEFHBHFFF, null);
				}
				else
				{
					if(JGJFFKPFMDB.BDGBCCGLLAJ_IsRankingError(NHECPMNKEFK.CJMFJOMECKI_ErrorId))
					{
						_IDAEHNGOKAE_OnRankingError();
					}
					else
					{
						_JGKOLBLPMPG_OnFail();
					}
				}
			};
			req.BHFHGFKBOHH_OnSuccess = (CACGCMBKHDI_Request NHECPMNKEFK) =>
			{
				//0x175E768
				List<int> l = new List<int>();
				PFDPLFOGMNF_GetRegularRankingTopRank r = NHECPMNKEFK as PFDPLFOGMNF_GetRegularRankingTopRank;
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
					FGEIGGNCGGD_GetPlayerData(l, _CJHEHIMLGGL_Position, NEFEFHBHFFF, r.NFEAMMJIMPG_Result.EJDEDOJFOOK_Ranks, _KLMFJJCNBIP_OnSuccess, _IDAEHNGOKAE_OnRankingError, _JGKOLBLPMPG_OnFail);
				}
			};
		}
		else
		{
			_IDAEHNGOKAE_OnRankingError();
		}
		yield break;
	}

	//// RVA: 0x175D7D4 Offset: 0x175D7D4 VA: 0x175D7D4
	private void FGEIGGNCGGD_GetPlayerData(List<int> HMDAFLDJLIK, int _CJHEHIMLGGL_Position, int NEFEFHBHFFF, List<OBGBKHKMDNF> NFMMAELFANG, LIOLBKLMMIK _KLMFJJCNBIP_OnSuccess, DJBHIFLHJLK _IDAEHNGOKAE_OnRankingError, DJBHIFLHJLK _JGKOLBLPMPG_OnFail)
	{
		PJKLMCGEJMK CPHFEPHDJIB_ServerRequester = NKGJPJPHLIF.HHCJCDFCLOB.IBLPICFDGOF_ServerRequester;
		List<IBIGBMDANNM> IODPMHILFDI = new List<IBIGBMDANNM>();
		BBHNACPENDM_ServerSaveData EHDDJFNOBFN = new BBHNACPENDM_ServerSaveData();
		EHDDJFNOBFN.PGPNDIHDIOD();
		CACGCMBKHDI_Request.HDHIKGLMOGF ICFBPFMLNCD = null;
		CACGCMBKHDI_Request.HDHIKGLMOGF PDGBAAFHIBP = null;
		MEIEDGPOMOO PINPBOCDKLI_OnPlayerCb = null;
		NJNCAHLIHNI_GetPlayerData LBHGPLCOCHD_Req = CPHFEPHDJIB_ServerRequester.IFFNCAFNEAG_AddRequest(new NJNCAHLIHNI_GetPlayerData());
		int GOHNHANPPEJ = Mathf.Min(HMDAFLDJLIK.Count, 50);
		LBHGPLCOCHD_Req.FAMHAPONILI_PlayerIds = HMDAFLDJLIK.GetRange(0, GOHNHANPPEJ);
		LBHGPLCOCHD_Req.HHIHCJKLJFF_Names = EHDDJFNOBFN.KPIDBPEKMFD_GetNames();
		PINPBOCDKLI_OnPlayerCb = (int _OIPCCBHIKIA_index, int PPFNGGCBJKC_id, long _IFNLEKOILPM_updated_at, List<string> _OHNJJIMGKGK_Names, EDOHBJAPLPF_JsonData _IDLHJIOMJBK_data) =>
		{
			//0x175EA94
			IBIGBMDANNM a = new IBIGBMDANNM();
			BBHNACPENDM_ServerSaveData data = new BBHNACPENDM_ServerSaveData();
			data.PGPNDIHDIOD();
			if (!data.IIEMACPEEBJ_Deserialize(_OHNJJIMGKGK_Names, _IDLHJIOMJBK_data))
				return false;
			a.MLPEHNBNOGD_PlayerId = PPFNGGCBJKC_id;
			a.AHEFHIMGIBI_PlayerData = data;
			a.LFKJNMFFCLH_LastLoginString = PIGBKEIAMPE_FriendManager.MKILKPFAOIC_GetLastLoginString(_IFNLEKOILPM_updated_at, CPHFEPHDJIB_ServerRequester.FJDBNGEPKHL_Time.KMEFBNBFJHI_GetServerTime());
			a.ONAFFLLLBHE_IsSelf = NKGJPJPHLIF.HHCJCDFCLOB.MDAMJIGBOLD_PlayerId == PPFNGGCBJKC_id;
			if(NFMMAELFANG == null)
			{
				a.KNIFCANOHOC_score = IKJBJNJLMKH(data, CDHPNAJNNFN, JLIIKLHGBJH);
				a.HMLEDBJDCAF_PreciseScore = IKJBJNJLMKH(data, CDHPNAJNNFN, JLIIKLHGBJH);
			}
			else
			{
				OBGBKHKMDNF o = NFMMAELFANG.Find((OBGBKHKMDNF _GHPLINIACBB_x) =>
				{
					//0x175F814
					return _GHPLINIACBB_x.EHGBICNIBKE_player_id == PPFNGGCBJKC_id;
				});
				if(o != null)
				{
					a.FJOLNJLLJEJ_rank = o.FJOLNJLLJEJ_rank;
					a.KNIFCANOHOC_score = o.KNIFCANOHOC_score;
					a.HMLEDBJDCAF_PreciseScore = o.HOCPLDLAIGL_Score;
				}
			}
			CHPIKCFKJOA c = ICJOJOPKNBK.Find((CHPIKCFKJOA _PMBEODGMMBB_y) =>
			{
				//0x175F84C
				return _PMBEODGMMBB_y.NMICBJDPLOH_player.PPFNGGCBJKC_id == PPFNGGCBJKC_id;
			});
			if (c != null)
				a.LHMDABPNDDH_state = IBIGBMDANNM.LJJOIIAEICI.HEEJBCDDOJJ_Friend/*1*/;
			if(!EBJDDBPFNPB)
			{
				IODPMHILFDI.Add(a);
			}
			else if(a.HMLEDBJDCAF_PreciseScore >= 0)
			{
				IODPMHILFDI.Add(a);
			}
			return true;
		};
		ICFBPFMLNCD = (CACGCMBKHDI_Request NHECPMNKEFK) =>
		{
			if(HMDAFLDJLIK.Count - GOHNHANPPEJ < 1)
			{
				switch(NEFEFHBHFFF)
				{
					case 0:
						IODPMHILFDI.Sort((IBIGBMDANNM _HKICMNAACDA_a, IBIGBMDANNM _BNKHBCBJBKI_b) =>
						{
							//0x175E188
							return _HKICMNAACDA_a.FJOLNJLLJEJ_rank - _BNKHBCBJBKI_b.FJOLNJLLJEJ_rank;
						});
						_KLMFJJCNBIP_OnSuccess(0, IODPMHILFDI);
						break;
					case 2:
						_KLMFJJCNBIP_OnSuccess(0, IODPMHILFDI);
						break;
					case 1:
						{
							IODPMHILFDI.Sort((IBIGBMDANNM _HKICMNAACDA_a, IBIGBMDANNM _BNKHBCBJBKI_b) =>
							{
								//0x175E208
								return _HKICMNAACDA_a.FJOLNJLLJEJ_rank - _BNKHBCBJBKI_b.FJOLNJLLJEJ_rank;
							});
							List<IBIGBMDANNM> l2 = new List<IBIGBMDANNM>();
							for(int i = 0; i < IODPMHILFDI.Count; i++)
							{
								if(_CJHEHIMLGGL_Position < IODPMHILFDI[i].FJOLNJLLJEJ_rank)
								{
									l2.Add(IODPMHILFDI[i]);
								}
							}
							_KLMFJJCNBIP_OnSuccess(1, l2);
						}
						break;
					default:
						return;
					case -1:
						{
							IODPMHILFDI.Sort((IBIGBMDANNM _HKICMNAACDA_a, IBIGBMDANNM _BNKHBCBJBKI_b) =>
							{
								//0x175E1C8
								return _HKICMNAACDA_a.FJOLNJLLJEJ_rank - _BNKHBCBJBKI_b.FJOLNJLLJEJ_rank;
							});
							List<IBIGBMDANNM> l2 = new List<IBIGBMDANNM>();
							for(int i = 0; i < IODPMHILFDI.Count; i++)
							{
								if(IODPMHILFDI[i].FJOLNJLLJEJ_rank < _CJHEHIMLGGL_Position)
								{
									l2.Add(IODPMHILFDI[i]);
								}
							}
							_KLMFJJCNBIP_OnSuccess(-1, l2);
						}
						break;
				}
				return;
			}
			LBHGPLCOCHD_Req = CPHFEPHDJIB_ServerRequester.IFFNCAFNEAG_AddRequest(new NJNCAHLIHNI_GetPlayerData());
			LBHGPLCOCHD_Req.FAMHAPONILI_PlayerIds = HMDAFLDJLIK.GetRange(GOHNHANPPEJ, Mathf.Min(HMDAFLDJLIK.Count - GOHNHANPPEJ, 50));
			LBHGPLCOCHD_Req.HHIHCJKLJFF_Names = EHDDJFNOBFN.KPIDBPEKMFD_GetNames();
			LBHGPLCOCHD_Req.BHFHGFKBOHH_OnSuccess = ICFBPFMLNCD;
			LBHGPLCOCHD_Req.MOBEEPPKFLG_OnFail = PDGBAAFHIBP;
			LBHGPLCOCHD_Req.PINPBOCDKLI_OnPlayerCb = PINPBOCDKLI_OnPlayerCb;
			GOHNHANPPEJ += LBHGPLCOCHD_Req.FAMHAPONILI_PlayerIds.Count;
		};
		PDGBAAFHIBP = (CACGCMBKHDI_Request NHECPMNKEFK) =>
		{
			//0x175F7E8
			_JGKOLBLPMPG_OnFail();
		};
		LBHGPLCOCHD_Req.BHFHGFKBOHH_OnSuccess = ICFBPFMLNCD;
		LBHGPLCOCHD_Req.MOBEEPPKFLG_OnFail = PDGBAAFHIBP;
		LBHGPLCOCHD_Req.PINPBOCDKLI_OnPlayerCb = PINPBOCDKLI_OnPlayerCb;
	}

	//// RVA: 0x175DC44 Offset: 0x175DC44 VA: 0x175DC44
	private IBIGBMDANNM APGCNBONNPE_GetPlayerInfo(string _DEPGBBJMFED_CategoryId, int _HHNFHJCAPJO_Target)
	{
		IBIGBMDANNM res = new IBIGBMDANNM();
		res.MLPEHNBNOGD_PlayerId = NKGJPJPHLIF.HHCJCDFCLOB.MDAMJIGBOLD_PlayerId;
		res.AHEFHIMGIBI_PlayerData = CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_PlayerData;
		res.LFKJNMFFCLH_LastLoginString = PIGBKEIAMPE_FriendManager.MKILKPFAOIC_GetLastLoginString(NKGJPJPHLIF.HHCJCDFCLOB.IBLPICFDGOF_ServerRequester.FJDBNGEPKHL_Time.KMEFBNBFJHI_GetServerTime(), NKGJPJPHLIF.HHCJCDFCLOB.IBLPICFDGOF_ServerRequester.FJDBNGEPKHL_Time.KMEFBNBFJHI_GetServerTime());
		res.FJOLNJLLJEJ_rank = 1;
		res.ONAFFLLLBHE_IsSelf = true;
		res.KNIFCANOHOC_score = IKJBJNJLMKH(res.AHEFHIMGIBI_PlayerData, _DEPGBBJMFED_CategoryId, _HHNFHJCAPJO_Target);
		res.HMLEDBJDCAF_PreciseScore = LEIMLIFCHCD(res.AHEFHIMGIBI_PlayerData, _DEPGBBJMFED_CategoryId, _HHNFHJCAPJO_Target);
		res.LHMDABPNDDH_state = IBIGBMDANNM.LJJOIIAEICI.CCAPCGPIIPF_0_Normal;
		return res;
	}

	//// RVA: 0x175DEAC Offset: 0x175DEAC VA: 0x175DEAC
	private int IKJBJNJLMKH(BBHNACPENDM_ServerSaveData _AHEFHIMGIBI_PlayerData, string _DEPGBBJMFED_CategoryId, int _HHNFHJCAPJO_Target)
	{
		string a = NGNLPIBPHJH.DEPGBBJMFED_CategoryId;
		if (a != _DEPGBBJMFED_CategoryId)
			return 0;
		return _AHEFHIMGIBI_PlayerData.FLBPFBFKBFC_FreeScoreMax.BDCAICINCKK_GetScore(_HHNFHJCAPJO_Target);
	}

	//// RVA: 0x175DF28 Offset: 0x175DF28 VA: 0x175DF28
	private double LEIMLIFCHCD(BBHNACPENDM_ServerSaveData _AHEFHIMGIBI_PlayerData, string _DEPGBBJMFED_CategoryId, int _HHNFHJCAPJO_Target)
	{
		string a = NGNLPIBPHJH.DEPGBBJMFED_CategoryId;
		if (a != _DEPGBBJMFED_CategoryId)
			return 0;
		return _AHEFHIMGIBI_PlayerData.FLBPFBFKBFC_FreeScoreMax.CJFBOEKDKNN_GetPreciseScoreMusic(_HHNFHJCAPJO_Target);
	}
}
