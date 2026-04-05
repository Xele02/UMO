
using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

// namespace XeApp.Game.Net.Event
[System.Obsolete("Use CANAFALMGLI_NetEventPresentCampaignController", true)]
public class CANAFALMGLI { }
public class CANAFALMGLI_NetEventPresentCampaignController : IKDICBBFBMI_NetEventBaseController
{
	public static bool BIMJBABOKDN = false; // 0x0
	public static bool NNJBFKKDLBC = false; // 0x1
	public static bool EEKLHDFELLB = false; // 0x2
	public static bool LBLLNABBEPI = false; // 0x3
	public static string INBEMNCFEJP = ""; // 0x4
	public List<int> AILDCKKOLJG_Results = new List<int>(); // 0xE8

	public override OHCAABOMEOF.KGOGMKMBCPP_EventType HIDHLFCBIDE_EventType { get { return OHCAABOMEOF.KGOGMKMBCPP_EventType.DMPMKBCPHMA_9_PresentCampaign; } }// 0x18F4084 DKHCGLCNKCD_bgs  Slot: 4

	// RVA: 0x18F408C Offset: 0x18F408C VA: 0x18F408C
	public CANAFALMGLI_NetEventPresentCampaignController(string _OPFGFINHFCE_name) : base(_OPFGFINHFCE_name)
    {
        return;
    }

	// RVA: 0x18F414C Offset: 0x18F414C VA: 0x18F414C Slot: 28
	public override long FBGDBGKNKOD_GetCurrentPoint()
	{
		return 0;
	}

	// // RVA: 0x18F4158 Offset: 0x18F4158 VA: 0x18F4158
	public HIADOIECMFP_EventPresentCampaign PFNALBDHBLE()
	{
		return IMMAOANGPNK_NetMasterDataManager.HHCJCDFCLOB_Instance.NKEBMCIMJND_Database.LBDOLHGDIEB_Find(JOPOPMLFINI_QuestName) as HIADOIECMFP_EventPresentCampaign;
	}

	// // RVA: 0x18F42C8 Offset: 0x18F42C8 VA: 0x18F42C8 Slot: 30
	protected override bool JIHMLILFOPG_IsEventActive(long _JHNMKKNEENE_Time)
	{
		HIADOIECMFP_EventPresentCampaign db = IMMAOANGPNK_NetMasterDataManager.HHCJCDFCLOB_Instance.NKEBMCIMJND_Database.LBDOLHGDIEB_Find(JOPOPMLFINI_QuestName) as HIADOIECMFP_EventPresentCampaign;
		if(db != null)
		{
            GDIPLANPCEI g = IMMAOANGPNK_NetMasterDataManager.HHCJCDFCLOB_Instance.ACEFBFLFKFD_GetScheduleEventData(db.JIKKNHIAEKG_BlockName, _JHNMKKNEENE_Time);
			if(g != null)
			{
				return _JHNMKKNEENE_Time >= db.NGHKJOEDLIP_Settings.BONDDBOFBND_RankingStart && db.NGHKJOEDLIP_Settings.KNLGKBBIBOH_RewardEnd2 >= _JHNMKKNEENE_Time;
			}
        }
		return false;
	}

	// // RVA: 0x18F44D4 Offset: 0x18F44D4 VA: 0x18F44D4 Slot: 31
	protected override bool IMCMNOPNGHO(long _JHNMKKNEENE_Time)
	{
		HIADOIECMFP_EventPresentCampaign evDb = IMMAOANGPNK_NetMasterDataManager.HHCJCDFCLOB_Instance.NKEBMCIMJND_Database.LBDOLHGDIEB_Find(JOPOPMLFINI_QuestName) as HIADOIECMFP_EventPresentCampaign;
		if(evDb != null)
		{
			if(evDb.NGHKJOEDLIP_Settings.OCGFKMHNEOF_name_for_api != CIOECGOMILE_NetPlayerDataManager.HHCJCDFCLOB_Instance.AHEFHIMGIBI_PlayerData.CNCBDLFALLD_Ticket.LJNAKDMILMC_key)
			{
				CIOECGOMILE_NetPlayerDataManager.HHCJCDFCLOB_Instance.AHEFHIMGIBI_PlayerData.CNCBDLFALLD_Ticket.KMBPACJNEOF_Reset();
				CIOECGOMILE_NetPlayerDataManager.HHCJCDFCLOB_Instance.AHEFHIMGIBI_PlayerData.CNCBDLFALLD_Ticket.LJNAKDMILMC_key = evDb.NGHKJOEDLIP_Settings.OCGFKMHNEOF_name_for_api;
			}
			return true;
		}
		return false;
	}

	// // RVA: 0x18F471C Offset: 0x18F471C VA: 0x18F471C Slot: 40
	protected override void KKFLDCBHFJA(long _JHNMKKNEENE_Time)
	{
		HIADOIECMFP_EventPresentCampaign evDb = IMMAOANGPNK_NetMasterDataManager.HHCJCDFCLOB_Instance.NKEBMCIMJND_Database.LBDOLHGDIEB_Find(JOPOPMLFINI_QuestName) as HIADOIECMFP_EventPresentCampaign;
		if(evDb != null)
		{
			IBNKPMPFLGI_IsRankReward = false;
			DGCOMDILAKM_EventName = evDb.NGHKJOEDLIP_Settings.OPFGFINHFCE_name;
			DOLJEDAAKNN_RankingName = "";
			GLIMIGNNGGB_RankingStart = evDb.NGHKJOEDLIP_Settings.BONDDBOFBND_RankingStart;
			DPJCPDKALGI_RankingEnd = evDb.NGHKJOEDLIP_Settings.HPNOGLIFJOP_RankingEnd;
			LOLAANGCGDO_RankingEnd2 = evDb.NGHKJOEDLIP_Settings.LNFKGHNHJKE_RankingEnd2;
			JDDFILGNGFH_RewardStart = evDb.NGHKJOEDLIP_Settings.JGMDAOACOJF_RewardStart;
			LJOHLEGGGMC_RewardEnd = evDb.NGHKJOEDLIP_Settings.IDDBFFBPNGI_RewardEnd;
			EMEKFFHCHMH_RewardEnd2 = evDb.NGHKJOEDLIP_Settings.KNLGKBBIBOH_RewardEnd2;
			PGIIDPEGGPI_EventId = evDb.NGHKJOEDLIP_Settings.OBGBAOLONDD_UniqueId;
			PBHNFNIHDJJ = evDb.NGHKJOEDLIP_Settings.HFNIHKOAMGC;
			NHGPCLGPEHH_TicketType = evDb.NGHKJOEDLIP_Settings.MJBKGOJBPAD_item_type;
			GFIBLLLHMPD_StartAdventureId = evDb.NGHKJOEDLIP_Settings.HIOOGLEJBKM_StartAdventureId;
			LEPALMDKEOK_IsPointReward = true;
			CAKEOPLJDAF_EndAdventureId = evDb.NGHKJOEDLIP_Settings.FJCADCDNPMP_EndAdventureId;
			for(int i = 0; i < KPOMHFLKMKI_LastRankUpdateTime.Length; i++)
				KPOMHFLKMKI_LastRankUpdateTime[i] = 0;
			GPHEKCNDDIK = false;
		}
	}

	// // RVA: 0x18F4AE0 Offset: 0x18F4AE0 VA: 0x18F4AE0 Slot: 46
	protected override void PJDGDNJNCNM_UpdateStatusImpl(long _JHNMKKNEENE_Time)
	{
		KGCNCBOKCBA.GNENJEHKMHD_EventStatus st = KGCNCBOKCBA.GNENJEHKMHD_EventStatus.HJNNKCMLGFL_0_None;
		HIADOIECMFP_EventPresentCampaign evDb = IMMAOANGPNK_NetMasterDataManager.HHCJCDFCLOB_Instance.NKEBMCIMJND_Database.LBDOLHGDIEB_Find(JOPOPMLFINI_QuestName) as HIADOIECMFP_EventPresentCampaign;
		if(evDb != null)
		{
			st = KGCNCBOKCBA.GNENJEHKMHD_EventStatus.FFLKPBPBPEP_1_NotStarted;
			if(_JHNMKKNEENE_Time >= evDb.NGHKJOEDLIP_Settings.BONDDBOFBND_RankingStart)
			{
				st = KGCNCBOKCBA.GNENJEHKMHD_EventStatus.NCJFJLPJMLI_2_CanEntry;
				if(evDb.NGHKJOEDLIP_Settings.HPNOGLIFJOP_RankingEnd < _JHNMKKNEENE_Time)
				{
					st = KGCNCBOKCBA.GNENJEHKMHD_EventStatus.EMAMLLFAOJI_6_Counting;
					if(evDb.NGHKJOEDLIP_Settings.JGMDAOACOJF_RewardStart < _JHNMKKNEENE_Time)
					{
						if(evDb.NGHKJOEDLIP_Settings.IDDBFFBPNGI_RewardEnd < _JHNMKKNEENE_Time)
						{
							return;
						}
						st = KGCNCBOKCBA.GNENJEHKMHD_EventStatus.BCKENOKGLIJ_9_ResultRewardreceived;
						if(CIOECGOMILE_NetPlayerDataManager.HHCJCDFCLOB_Instance.AHEFHIMGIBI_PlayerData.CNCBDLFALLD_Ticket.LNACKEBEMOB_Received == 0)
							st = KGCNCBOKCBA.GNENJEHKMHD_EventStatus.DDEODFNANDO_8_ResultRewardToReceive;
					}
				}
			}
		}
		NGOFCFJHOMI_Status = st;
	}

	// // RVA: 0x18F4D50 Offset: 0x18F4D50 VA: 0x18F4D50 Slot: 71
	public override int BAEPGOAMBDK(string _LJNAKDMILMC_key, int MNCOAGOKNAO)
	{
		HIADOIECMFP_EventPresentCampaign evDb = IMMAOANGPNK_NetMasterDataManager.HHCJCDFCLOB_Instance.NKEBMCIMJND_Database.LBDOLHGDIEB_Find(JOPOPMLFINI_QuestName) as HIADOIECMFP_EventPresentCampaign;
		if(evDb != null)
		{
			return evDb.LPJLEHAJADA_GetIntParam(_LJNAKDMILMC_key, MNCOAGOKNAO);
		}
		return MNCOAGOKNAO;
	}

	// // RVA: 0x18F4ED0 Offset: 0x18F4ED0 VA: 0x18F4ED0 Slot: 72
	public override string MAICAKMIBEM(string _LJNAKDMILMC_key, string MNCOAGOKNAO)
	{
		HIADOIECMFP_EventPresentCampaign evDb = IMMAOANGPNK_NetMasterDataManager.HHCJCDFCLOB_Instance.NKEBMCIMJND_Database.LBDOLHGDIEB_Find(JOPOPMLFINI_QuestName) as HIADOIECMFP_EventPresentCampaign;
		if(evDb != null)
		{
			return evDb.EFEGBHACJAL_GetStringParam(_LJNAKDMILMC_key, MNCOAGOKNAO);
		}
		return MNCOAGOKNAO;
	}

	// // RVA: 0x18F5050 Offset: 0x18F5050 VA: 0x18F5050
	public int PLDDGDNLCAA(int DCALLPABDAI)
	{
		HIADOIECMFP_EventPresentCampaign evDb = IMMAOANGPNK_NetMasterDataManager.HHCJCDFCLOB_Instance.NKEBMCIMJND_Database.LBDOLHGDIEB_Find(JOPOPMLFINI_QuestName) as HIADOIECMFP_EventPresentCampaign;
		if(evDb != null)
		{
			if(DCALLPABDAI == 0)
				return 0;
			long t = NKGJPJPHLIF_SakashoManager.HHCJCDFCLOB_Instance.IBLPICFDGOF_ServerRequester.FJDBNGEPKHL_Time.KMEFBNBFJHI_GetServerTime();
			/*int a = 0;
			for(int i = 0; i < evDb.EENHCEEKBBD.Count; i++)
			{
				a = i;
				if(t >= evDb.EENHCEEKBBD[i].FKPEAGGKNLC_Start || evDb.EENHCEEKBBD[i].KOMKKBDABJP_end >= t)
				{
					break;
				}
			}*/
			HIADOIECMFP_EventPresentCampaign.DFPGOAOKPBI BAOFEFFADPD_day = evDb.EENHCEEKBBD[DCALLPABDAI - 1];
			int c = 0;
			if(t >= BAOFEFFADPD_day.FKPEAGGKNLC_Start)
				c = 4;
			if(BAOFEFFADPD_day.KOMKKBDABJP_end < t)
				c = 8;
			//LAB_018f5450
			int idx = CIOECGOMILE_NetPlayerDataManager.HHCJCDFCLOB_Instance.AHEFHIMGIBI_PlayerData.CNCBDLFALLD_Ticket.HOFACDIBDLM().FindIndex((string _GHPLINIACBB_x) =>
			{
				//0x18F6204
				return _GHPLINIACBB_x == BAOFEFFADPD_day.LJNAKDMILMC_key;
			});
			if(idx > -1)
			{
				c |= 2;
			}
			return c;
		}
		return 0;
	}

	// // RVA: 0x18F554C Offset: 0x18F554C VA: 0x18F554C
	public bool CKFNILGAOBK(int DCALLPABDAI)
	{
		return (PLDDGDNLCAA(DCALLPABDAI) & 2) != 0;
	}

	// // RVA: 0x18F5560 Offset: 0x18F5560 VA: 0x18F5560
	public void KJLFPCHDFAD(int DCALLPABDAI)
	{
		HIADOIECMFP_EventPresentCampaign evDb = IMMAOANGPNK_NetMasterDataManager.HHCJCDFCLOB_Instance.NKEBMCIMJND_Database.LBDOLHGDIEB_Find(JOPOPMLFINI_QuestName) as HIADOIECMFP_EventPresentCampaign;
		if(evDb != null)
		{
			if(DCALLPABDAI != 0)
			{
                HIADOIECMFP_EventPresentCampaign.DFPGOAOKPBI BAOFEFFADPD_day = evDb.EENHCEEKBBD[DCALLPABDAI - 1];
                List<string> ls = CIOECGOMILE_NetPlayerDataManager.HHCJCDFCLOB_Instance.AHEFHIMGIBI_PlayerData.CNCBDLFALLD_Ticket.HOFACDIBDLM();
				int idx = ls.FindIndex((string _GHPLINIACBB_x) =>
				{
					//0x18F6238
					return _GHPLINIACBB_x == BAOFEFFADPD_day.LJNAKDMILMC_key;
				});
				if(idx < 0)
				{
					ls.Add(BAOFEFFADPD_day.LJNAKDMILMC_key);
					ls.Sort((string _HKICMNAACDA_a, string _BNKHBCBJBKI_b) =>
					{
						//0x18F61B4
						return _HKICMNAACDA_a.CompareTo(_BNKHBCBJBKI_b);
					});
					StringBuilder str = new StringBuilder();
					bool b = false;
					for(int i = 0; i < ls.Count; i++)
					{
						if(ls[i] != "")
						{
							if(b)
								str.Append(",");
							str.Append(ls[i]);
							b = true;
						}
					}
					CIOECGOMILE_NetPlayerDataManager.HHCJCDFCLOB_Instance.AHEFHIMGIBI_PlayerData.CNCBDLFALLD_Ticket.EBAMGNMELPO_EntryDate = str.ToString();
				}
			}
		}
	}

	// // RVA: 0x18F5B20 Offset: 0x18F5B20 VA: 0x18F5B20
	public void EAFPHEGFODB(IMCBBOAFION DFPIPMPJOEB, IMCBBOAFION ECOPDHBJEEK, DJBHIFLHJLK _AOCANKOMKFG_OnError) 
	{
		N.a.StartCoroutineWatched(AOAGAPFDLBJ_Co_ReceivePresent(DFPIPMPJOEB, ECOPDHBJEEK, _AOCANKOMKFG_OnError));
	}

	// [IteratorStateMachineAttribute] // RVA: 0x6BCFE4 Offset: 0x6BCFE4 VA: 0x6BCFE4
	// // RVA: 0x18F5B88 Offset: 0x18F5B88 VA: 0x18F5B88
	private IEnumerator AOAGAPFDLBJ_Co_ReceivePresent(IMCBBOAFION DFPIPMPJOEB, IMCBBOAFION ECOPDHBJEEK, DJBHIFLHJLK _AOCANKOMKFG_OnError)
	{
		HIADOIECMFP_EventPresentCampaign KHGBJCFJGMA; // 0x28
		FLONELKGABJ_ClaimAchievementPrizes DLOIHKKKNBB_Request; // 0x2C

		//0x18F6B4C
		KHGBJCFJGMA = IMMAOANGPNK_NetMasterDataManager.HHCJCDFCLOB_Instance.NKEBMCIMJND_Database.LBDOLHGDIEB_Find(JOPOPMLFINI_QuestName) as HIADOIECMFP_EventPresentCampaign;
		if(KHGBJCFJGMA != null)
		{
            GGHPEFNADEN_Ticket NHLBKJCPLBL = CIOECGOMILE_NetPlayerDataManager.HHCJCDFCLOB_Instance.AHEFHIMGIBI_PlayerData.CNCBDLFALLD_Ticket;
			if(NHLBKJCPLBL.LNACKEBEMOB_Received == 1)
			{
				Debug.Log("StringLiteral_9701");
			}
			else
			{
				long t = NKGJPJPHLIF_SakashoManager.HHCJCDFCLOB_Instance.IBLPICFDGOF_ServerRequester.FJDBNGEPKHL_Time.KMEFBNBFJHI_GetServerTime();
				if((RuntimeSettings.CurrentSettings.UnlimitedEvent && NHLBKJCPLBL.EBAMGNMELPO_EntryDate != "") || (t >= JDDFILGNGFH_RewardStart && LJOHLEGGGMC_RewardEnd >= t))
				{
					if(string.IsNullOrEmpty(NHLBKJCPLBL.OEDIICBDNKG_Pending))
					{
						int NMOLAEAFDNK = 0;
						N.a.StartCoroutineWatched(CIEMBLDFAIE_Co_ReceiveInventory(() =>
						{
							//0x18F63A0
							NMOLAEAFDNK = 1;
						}, () =>
						{
							//0x18F63AC
							NMOLAEAFDNK = 2;
						}, () =>
						{
							//0x18F63B8
							NMOLAEAFDNK = 3;
						}));
						//LAB_018f6e08
						while(NMOLAEAFDNK == 0)
						{
							yield return null;
						}
						if(NMOLAEAFDNK == 2)
						{
							ECOPDHBJEEK();
							yield break;
						}
						if(NMOLAEAFDNK == 3)
						{
							_AOCANKOMKFG_OnError();
							yield break;
						}
					}
					//LAB_018f75b8
					AILDCKKOLJG_Results = FKCNKNOEMLK(NHLBKJCPLBL.OEDIICBDNKG_Pending);
					List<int> l = new List<int>(KHGBJCFJGMA.OBPOHDENMHH.Count);
					for(int i = 0; i < KHGBJCFJGMA.OBPOHDENMHH.Count; i++)
					{
						l.Add(0);
					}
					List<string> ls = new List<string>();
					for(int i = 0; i < AILDCKKOLJG_Results.Count; i++)
					{
						if(AILDCKKOLJG_Results[i] > 0)
						{
							if(AILDCKKOLJG_Results[i] <= KHGBJCFJGMA.OBPOHDENMHH.Count)
							{
								string s = KHGBJCFJGMA.OBPOHDENMHH[AILDCKKOLJG_Results[i] - 1].MCNPILDHLEE;
								if(!string.IsNullOrEmpty(s))
								{
									ls.Add(s + l[AILDCKKOLJG_Results[i] - 1].ToString());
								}
								s = KHGBJCFJGMA.OBPOHDENMHH[AILDCKKOLJG_Results[i] - 1].OJHJLJLCKAC;
								if(!string.IsNullOrEmpty(s))
								{
									ls.Add(s + l[AILDCKKOLJG_Results[i] - 1].ToString());
								}
								l[AILDCKKOLJG_Results[i] - 1]++;
							}
						}
					}
					if(ls.Count != 0)
					{
						DLOIHKKKNBB_Request = NKGJPJPHLIF_SakashoManager.HHCJCDFCLOB_Instance.IBLPICFDGOF_ServerRequester.IFFNCAFNEAG_AddRequest(new FLONELKGABJ_ClaimAchievementPrizes());
						DLOIHKKKNBB_Request.MIDAMHNABAJ_Keys = ls;
						DLOIHKKKNBB_Request.NBFDEFGFLPJ = (SakashoErrorId LJJGBICGLLF) =>
						{
							//0x18F61E8
							return LJJGBICGLLF == SakashoErrorId.KEYS_NOT_FOUND || LJJGBICGLLF == SakashoErrorId.ACHIEVEMENT_PRIZE_ALREADY_RECEIVED;
						};
						//LAB_018f6e70
						while(!DLOIHKKKNBB_Request.PLOOEECNHFB_IsDone)
							yield return null;
						if(DLOIHKKKNBB_Request.NPNNPNAIONN_IsError)
						{
							if(DLOIHKKKNBB_Request.CJMFJOMECKI_ErrorId == SakashoErrorId.ACHIEVEMENT_PRIZE_ALREADY_RECEIVED)
							{
								NHLBKJCPLBL.LNACKEBEMOB_Received = 1;
								NHLBKJCPLBL.HBODCMLFDOB_result = NHLBKJCPLBL.OEDIICBDNKG_Pending;
								Debug.Log("StringLiteral_9704");
								CIOECGOMILE_NetPlayerDataManager.HHCJCDFCLOB_Instance.AIKJMHBDABF_SavePlayerData(DFPIPMPJOEB, _AOCANKOMKFG_OnError, null);
								yield break;
							}
						}
						if(DLOIHKKKNBB_Request.NPNNPNAIONN_IsError)
						{
							if(DLOIHKKKNBB_Request.CJMFJOMECKI_ErrorId == SakashoErrorId.KEYS_NOT_FOUND)
							{
								Debug.Log("StringLiteral_9703");
								ECOPDHBJEEK();
								yield break;
							}
						}
						if(!DLOIHKKKNBB_Request.NPNNPNAIONN_IsError)
						{
							Debug.Log("StringLiteral_9706" + NHLBKJCPLBL.OEDIICBDNKG_Pending);
							NHLBKJCPLBL.LNACKEBEMOB_Received = 1;
							NHLBKJCPLBL.HBODCMLFDOB_result = NHLBKJCPLBL.OEDIICBDNKG_Pending;
							CIOECGOMILE_NetPlayerDataManager.HHCJCDFCLOB_Instance.AIKJMHBDABF_SavePlayerData(() =>
							{
								//0x18F6274
								ILCCJNDFFOB.HHCJCDFCLOB_Instance.BLDDKDNOCFA_PresentCampaignResult(this, NHLBKJCPLBL.EBAMGNMELPO_EntryDate, NHLBKJCPLBL.HBODCMLFDOB_result);
								DFPIPMPJOEB();
							}, _AOCANKOMKFG_OnError, null);
							yield break;
						}
						Debug.Log("StringLiteral_9705");
						_AOCANKOMKFG_OnError();
						yield break;
					}
					else
						Debug.Log("StringLiteral_9703");
				}
				else
					Debug.Log("StringLiteral_9702");
			}
			//LAB_018f7c90
			ECOPDHBJEEK();
        }
	}

	// [IteratorStateMachineAttribute] // RVA: 0x6BD05C Offset: 0x6BD05C VA: 0x6BD05C
	// // RVA: 0x18F5C80 Offset: 0x18F5C80 VA: 0x18F5C80
	private IEnumerator CIEMBLDFAIE_Co_ReceiveInventory(IMCBBOAFION _BHFHGFKBOHH_OnSuccess, IMCBBOAFION ECOPDHBJEEK, DJBHIFLHJLK _AOCANKOMKFG_OnError)
	{
		GGHPEFNADEN_Ticket NGHLIKFIIGI_SaveData; // 0x20
		ELNKLCNHDEE_NetEventLotResultData NPMOILPJMMP; // 0x24

		//0x18F63C8
		NGHLIKFIIGI_SaveData = CIOECGOMILE_NetPlayerDataManager.HHCJCDFCLOB_Instance.AHEFHIMGIBI_PlayerData.CNCBDLFALLD_Ticket;
		NPMOILPJMMP = new ELNKLCNHDEE_NetEventLotResultData();
		NPMOILPJMMP.HBOKJNECOPA_GetMaster(MAICAKMIBEM("trigger_item_name", "trigger_item"));
		while(!NPMOILPJMMP.PLOOEECNHFB_IsDone)
			yield return null;
		if(NPMOILPJMMP.NPNNPNAIONN_IsError)
		{
			Debug.Log("StringLiteral_9697");
			_AOCANKOMKFG_OnError();
		}
		else
		{
			if(!NPMOILPJMMP.GBCOABCAJHG)
			{
				if(NPMOILPJMMP.AILDCKKOLJG_Results == null)
				{
					Debug.Log("StringLiteral_9700");
					//LAB_018f6a1c
					ECOPDHBJEEK();
				}
				else
				{
					StringBuilder str = new StringBuilder();
					bool b = false;
					for(int i = 0; i < NPMOILPJMMP.AILDCKKOLJG_Results.Count; i++)
					{
						if(b)
							str.Append(',');
						str.Append(NPMOILPJMMP.AILDCKKOLJG_Results[i].DNJEJEANJGL_Value);
						b = true;
					}
					NGHLIKFIIGI_SaveData.OEDIICBDNKG_Pending = str.ToString();
					CIOECGOMILE_NetPlayerDataManager.HHCJCDFCLOB_Instance.AIKJMHBDABF_SavePlayerData(_BHFHGFKBOHH_OnSuccess, _AOCANKOMKFG_OnError, NPMOILPJMMP.HBINEKIILJL);
				}
			}
			else
			{
				if(!string.IsNullOrEmpty(NGHLIKFIIGI_SaveData.EBAMGNMELPO_EntryDate))
				{
					Debug.Log("StringLiteral_9699");
					ECOPDHBJEEK();
				}
				else
				{
					NGHLIKFIIGI_SaveData.LNACKEBEMOB_Received = 1;
					NGHLIKFIIGI_SaveData.HBODCMLFDOB_result = "";
					Debug.Log("StringLiteral_9698");
					CIOECGOMILE_NetPlayerDataManager.HHCJCDFCLOB_Instance.AIKJMHBDABF_SavePlayerData(ECOPDHBJEEK, _AOCANKOMKFG_OnError, null);
				}
			}
		}
	}

	// // RVA: 0x18F5D78 Offset: 0x18F5D78 VA: 0x18F5D78
	private static List<int> FKCNKNOEMLK(string _IDLHJIOMJBK_data)
	{
		List<int> res = new List<int>();
		string[] strs = _IDLHJIOMJBK_data.Split(new char[]{','});
		for(int i = 0; i < strs.Length; i++)
		{
			int v;
			if(int.TryParse(strs[i], out v))
			{
				res.Add(v);
			}
		}
		return res;
	}

	// // RVA: 0x18F5FB4 Offset: 0x18F5FB4 VA: 0x18F5FB4
	public string JFHOMINJHJK_GetEntryDate()
	{
		return CIOECGOMILE_NetPlayerDataManager.HHCJCDFCLOB_Instance.AHEFHIMGIBI_PlayerData.CNCBDLFALLD_Ticket.EBAMGNMELPO_EntryDate;
	}
}
