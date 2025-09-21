
using System.Collections.Generic;

[System.Obsolete("Use HLEBAINCOME_EventScore", true)]
public class HLEBAINCOME { }
public class HLEBAINCOME_EventScore : IKDICBBFBMI_EventBase
{
	private const int GHJHJDIDCFA = 3;
	private EECOJKDJIFG KBACNOCOANM_Ranking; // 0xE8

	public override OHCAABOMEOF.KGOGMKMBCPP_EventType HIDHLFCBIDE_EventType { get { return OHCAABOMEOF.KGOGMKMBCPP_EventType.KEILBOLBDHN_EventScore; } } //0x15EAAEC DKHCGLCNKCD  Slot: 4

	// // RVA: 0x15EAAF4 Offset: 0x15EAAF4 VA: 0x15EAAF4 Slot: 32
	public override EECOJKDJIFG DAKMIKNKHMF_GetRankingInfoForIndex(int LHJCOPMMIGO/* = 0*/)
	{
		return KBACNOCOANM_Ranking;
	}

	// RVA: 0x15EAAFC Offset: 0x15EAAFC VA: 0x15EAAFC
	public HLEBAINCOME_EventScore(string _OPFGFINHFCE_name) : base(_OPFGFINHFCE_name)
    {
        return;
    }

	// // RVA: 0x15EAB88 Offset: 0x15EAB88 VA: 0x15EAB88 Slot: 5
	public override string IFKKBHPMALH()
	{
		HIHJGPDLNDN_EventScore ev = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.LBDOLHGDIEB_GetDbSection(JOPOPMLFINI_QuestName) as HIHJGPDLNDN_EventScore;
		if(ev != null)
		{
			return ev.NGHKJOEDLIP_Settings.OCDMGOGMHGE_KeyPrefix;
		}
		return null;
	}

	// // RVA: 0x15EAD10 Offset: 0x15EAD10 VA: 0x15EAD10 Slot: 7
	public override List<int> HEACCHAKMFG_GetMusicsList()
	{
		HIHJGPDLNDN_EventScore ev = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.LBDOLHGDIEB_GetDbSection(JOPOPMLFINI_QuestName) as HIHJGPDLNDN_EventScore;
		if(ev != null)
		{
			return ev.NGHKJOEDLIP_Settings.CAPAPAABKDP_FreeMusic;
		}
		return null;
	}

	// // RVA: 0x15EAE94 Offset: 0x15EAE94 VA: 0x15EAE94 Slot: 28
	public override long FBGDBGKNKOD_GetCurrentPoint()
	{
		HIHJGPDLNDN_EventScore ev = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.LBDOLHGDIEB_GetDbSection(JOPOPMLFINI_QuestName) as HIHJGPDLNDN_EventScore;
		if(ev != null)
		{
			FEHINJKHDAP_EventScore.ALGDNCMJHGN save = CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_PlayerData.KOOKJBMGBIG_EventScore.FBCJICEPLED[ev.NGHKJOEDLIP_Settings.MOEKELIIDEO_SaveIdx];
			return save.DNBFMLBNAEE_Point;
		}
		return 0;
	}

	// // RVA: 0x15EB0F4 Offset: 0x15EB0F4 VA: 0x15EB0F4 Slot: 29
	public override void MJFKJHJJLMN_GetRanks(int LHJCOPMMIGO/* = 0*/, bool _FBBNPFFEJBN_Force/* = false*/)
	{
		NPNNPNAIONN_IsError = false;
		PLOOEECNHFB_IsDone = false;
		HIHJGPDLNDN_EventScore ev = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.LBDOLHGDIEB_GetDbSection(JOPOPMLFINI_QuestName) as HIHJGPDLNDN_EventScore;
		if(ev != null)
		{
			if(GPHEKCNDDIK)
			{
				long t = NKGJPJPHLIF.HHCJCDFCLOB.IBLPICFDGOF_ServerRequester.FJDBNGEPKHL_Time.KMEFBNBFJHI_GetServerTime();
				int t2 = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.GDEKCOOBLMA_System.LPJLEHAJADA("get_rank_cooling_time", 60);
				if(_FBBNPFFEJBN_Force || t - KPOMHFLKMKI_LastRankUpdateTime[LHJCOPMMIGO] >= t2)
				{
					KKLGENJKEBN.HHCJCDFCLOB.HEOKADCEAGL_GetRanks(ev.NGHKJOEDLIP_Settings.OCGFKMHNEOF_name_for_api, () =>
					{
						//0x15F03C8
						CDINKAANIAA_Rank[LHJCOPMMIGO] = (int)KKLGENJKEBN.HHCJCDFCLOB.LPPCNCMEDFA_Rank;
						KPOMHFLKMKI_LastRankUpdateTime[LHJCOPMMIGO] = NKGJPJPHLIF.HHCJCDFCLOB.IBLPICFDGOF_ServerRequester.FJDBNGEPKHL_Time.KMEFBNBFJHI_GetServerTime();
						PLOOEECNHFB_IsDone = true;
					}, () =>
					{
						//0x15F058C
						KPOMHFLKMKI_LastRankUpdateTime[LHJCOPMMIGO] = NKGJPJPHLIF.HHCJCDFCLOB.IBLPICFDGOF_ServerRequester.FJDBNGEPKHL_Time.KMEFBNBFJHI_GetServerTime();
						CDINKAANIAA_Rank[LHJCOPMMIGO] = 0;
						PLOOEECNHFB_IsDone = true;
					}, () =>
					{
						//0x15F0734
						CDINKAANIAA_Rank[LHJCOPMMIGO] = 0;
						PLOOEECNHFB_IsDone = true;
						NPNNPNAIONN_IsError = true;
					}, () =>
					{
						//0x15F07CC
						CDINKAANIAA_Rank[LHJCOPMMIGO] = 0;
						PLOOEECNHFB_IsDone = true;
						FKKDIDMGLMI_IsDroppedPlayer = true;
					});
					return;
				}
			}
		}
		CDINKAANIAA_Rank[LHJCOPMMIGO] = 0;
		PLOOEECNHFB_IsDone = true;
	}

	// // RVA: 0x15EB5D4 Offset: 0x15EB5D4 VA: 0x15EB5D4 Slot: 30
	protected override bool JIHMLILFOPG_IsEventActive(long _JHNMKKNEENE_Time)
	{
		HIHJGPDLNDN_EventScore ev/*IMCFGLGOGCK*/ = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.LBDOLHGDIEB_GetDbSection(JOPOPMLFINI_QuestName) as HIHJGPDLNDN_EventScore;
		if(ev != null)
		{
			GDIPLANPCEI g = IMMAOANGPNK.HHCJCDFCLOB.ACEFBFLFKFD_GetScheduleEventData(ev.JIKKNHIAEKG_BlockName, _JHNMKKNEENE_Time);
			if(g != null)
			{
				if(_JHNMKKNEENE_Time >= ev.NGHKJOEDLIP_Settings.BONDDBOFBND_RankingStart && 
					ev.NGHKJOEDLIP_Settings.KNLGKBBIBOH_RewardEnd2 >= _JHNMKKNEENE_Time && ev.NGHKJOEDLIP_Settings.HKKNEAGCIEB_RankingSupport != 0)
				{
					if(KKLGENJKEBN.HHCJCDFCLOB.JPDPFGFMKHK_rankings.Find((EECOJKDJIFG PKLPKMLGFGK) =>
					{
						//0x15EECD0
						return ev.NGHKJOEDLIP_Settings.OCGFKMHNEOF_name_for_api == PKLPKMLGFGK.OCGFKMHNEOF_name_for_api;
					}) != null)
					{
						return true;
					}
					else
					{
						UnityEngine.Debug.LogError("Ranking not found "+ev.NGHKJOEDLIP_Settings.OCGFKMHNEOF_name_for_api);
					}
				}
			}
		}
		return false;
	}

	// // RVA: 0x15EB8F4 Offset: 0x15EB8F4 VA: 0x15EB8F4 Slot: 31
	protected override bool IMCMNOPNGHO(long _JHNMKKNEENE_Time)
	{
		HIHJGPDLNDN_EventScore ev = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.LBDOLHGDIEB_GetDbSection(JOPOPMLFINI_QuestName) as HIHJGPDLNDN_EventScore;
		if(ev != null)
		{
			FEHINJKHDAP_EventScore.ALGDNCMJHGN save = CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_PlayerData.KOOKJBMGBIG_EventScore.FBCJICEPLED[ev.NGHKJOEDLIP_Settings.MOEKELIIDEO_SaveIdx];
			if(ev.NGHKJOEDLIP_Settings.OCGFKMHNEOF_name_for_api != save.MPCAGEPEJJJ_Key || save.EGBOHDFBAPB_CloseAt == 0 || (!RuntimeSettings.CurrentSettings.UnlimitedEvent && save.EGBOHDFBAPB_CloseAt < ev.NGHKJOEDLIP_Settings.BONDDBOFBND_RankingStart))
			{
				save.LHPDDGIJKNB_Reset();
				save.MPCAGEPEJJJ_Key = ev.NGHKJOEDLIP_Settings.OCGFKMHNEOF_name_for_api;
				save.EGBOHDFBAPB_CloseAt = ev.NGHKJOEDLIP_Settings.IDDBFFBPNGI_RewardEnd;
			}
			return true;
		}
		return false;
	}

	// // RVA: 0x15EBBBC Offset: 0x15EBBBC VA: 0x15EBBBC Slot: 40
	protected override void KKFLDCBHFJA(long _JHNMKKNEENE_Time)
	{
		HIHJGPDLNDN_EventScore ev = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.LBDOLHGDIEB_GetDbSection(JOPOPMLFINI_QuestName) as HIHJGPDLNDN_EventScore;
		if(ev != null)
		{
			IBNKPMPFLGI_IsRankReward = ev.NGHKJOEDLIP_Settings.HKKNEAGCIEB_RankingSupport != 0;
			KBACNOCOANM_Ranking = KKLGENJKEBN.HHCJCDFCLOB.JPDPFGFMKHK_rankings.Find((EECOJKDJIFG PKLPKMLGFGK) =>
			{
				//0x15EED30
				return ev.NGHKJOEDLIP_Settings.OCGFKMHNEOF_name_for_api == PKLPKMLGFGK.OCGFKMHNEOF_name_for_api;
			});
			if(KBACNOCOANM_Ranking != null)
			{
				DGCOMDILAKM_EventName = ev.NGHKJOEDLIP_Settings.OPFGFINHFCE_name;
				DOLJEDAAKNN_RankingName = ev.NGHKJOEDLIP_Settings.HEDAGCNPHGD_RankingName;
				GLIMIGNNGGB_RankingStart = ev.NGHKJOEDLIP_Settings.BONDDBOFBND_RankingStart;
				DPJCPDKALGI_RankingEnd = ev.NGHKJOEDLIP_Settings.HPNOGLIFJOP_RankingEnd;
				LOLAANGCGDO_RankingEnd2 = ev.NGHKJOEDLIP_Settings.LNFKGHNHJKE_RankingEnd2;
				JDDFILGNGFH_RewardStart = ev.NGHKJOEDLIP_Settings.JGMDAOACOJF_RewardStart;
				LJOHLEGGGMC_RewardEnd = ev.NGHKJOEDLIP_Settings.IDDBFFBPNGI_RewardEnd;
				EMEKFFHCHMH_RewardEnd2 = ev.NGHKJOEDLIP_Settings.KNLGKBBIBOH_RewardEnd2;
				PGIIDPEGGPI_EventId = ev.NGHKJOEDLIP_Settings.OBGBAOLONDD_UniqueId;
				FBHONHONKGD_MusicSelectDesc = "";
				HGLAFGHHFKP = ev.NGHKJOEDLIP_Settings.JHPCPNJJHLI_RankingThreshold;
				GFIBLLLHMPD_StartAdventureId = 0;
				CAKEOPLJDAF_EndAdventureId = 0;
				LHAKGDAGEMM_EpBonusInfos.Clear();
				MNDFBBMNJGN_IsUsingTicket = false;
				LEPALMDKEOK_IsPointReward = false;
				GPHEKCNDDIK = true;
				PJLNJJIBFBN_HasExtremeDiff = ev.NGHKJOEDLIP_Settings.AHKPNPNOAMO_ExtreamOpen != 0;
				for(int i = 0; i < KPOMHFLKMKI_LastRankUpdateTime.Length; i++)
				{
					KPOMHFLKMKI_LastRankUpdateTime[i] = 0;
				}
			}
			else
			{
				UnityEngine.Debug.LogError("Ranking not found "+ev.NGHKJOEDLIP_Settings.OCGFKMHNEOF_name_for_api);
			}
		}
	}

	// // RVA: 0x15EBF9C Offset: 0x15EBF9C VA: 0x15EBF9C Slot: 43
	protected override void FCHGHAAPIBH()
	{
		HIHJGPDLNDN_EventScore ev = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.LBDOLHGDIEB_GetDbSection(JOPOPMLFINI_QuestName) as HIHJGPDLNDN_EventScore;
		if(ev != null)
		{
			PIMFJALCIGK();
		}
		PLOOEECNHFB_IsDone = true;
	}

	// // RVA: 0x15EC15C Offset: 0x15EC15C VA: 0x15EC15C Slot: 46
	protected override void PJDGDNJNCNM_UpdateStatusImpl(long _JHNMKKNEENE_Time)
	{
		NGOFCFJHOMI_Status = KGCNCBOKCBA.GNENJEHKMHD_EventStatus.HJNNKCMLGFL_0_None;
		HIHJGPDLNDN_EventScore ev = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.LBDOLHGDIEB_GetDbSection(JOPOPMLFINI_QuestName) as HIHJGPDLNDN_EventScore;
		if(ev != null)
		{
			FEHINJKHDAP_EventScore.ALGDNCMJHGN save = CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_PlayerData.KOOKJBMGBIG_EventScore.FBCJICEPLED[ev.NGHKJOEDLIP_Settings.MOEKELIIDEO_SaveIdx];
			NGOFCFJHOMI_Status = KGCNCBOKCBA.GNENJEHKMHD_EventStatus.FFLKPBPBPEP_1;
			if(_JHNMKKNEENE_Time >= GLIMIGNNGGB_RankingStart)
			{
				if(DPJCPDKALGI_RankingEnd >= _JHNMKKNEENE_Time)
				{
					NGOFCFJHOMI_Status = KGCNCBOKCBA.GNENJEHKMHD_EventStatus.NCJFJLPJMLI_2;
					if(save.IMFBCJOIJKJ_Entry)
						NGOFCFJHOMI_Status = KGCNCBOKCBA.GNENJEHKMHD_EventStatus.MINDIGBAJFG_3;
				}
				else
				{
					NGOFCFJHOMI_Status = KGCNCBOKCBA.GNENJEHKMHD_EventStatus.EMAMLLFAOJI_Counting_6;
					if(_JHNMKKNEENE_Time >= ev.NGHKJOEDLIP_Settings.JGMDAOACOJF_RewardStart)
					{
						if(_JHNMKKNEENE_Time >= ev.NGHKJOEDLIP_Settings.IDDBFFBPNGI_RewardEnd)
						{
							NGOFCFJHOMI_Status = KGCNCBOKCBA.GNENJEHKMHD_EventStatus.DOAENCHBAEO_11;
							if(_JHNMKKNEENE_Time < ev.NGHKJOEDLIP_Settings.KNLGKBBIBOH_RewardEnd2)
							{
								NGOFCFJHOMI_Status = KGCNCBOKCBA.GNENJEHKMHD_EventStatus.HINPDNKNAHO_10;
							}
						}
						else
						{
							NGOFCFJHOMI_Status = KGCNCBOKCBA.GNENJEHKMHD_EventStatus.DDEODFNANDO_8_ResultRewardToReceive;
							if(save.HPLMECLKFID_RRcv)
							{
								NGOFCFJHOMI_Status = KGCNCBOKCBA.GNENJEHKMHD_EventStatus.BCKENOKGLIJ_9_ResultRewardreceived;
							}
						}
					}
				}
			}
		}
	}

	// // RVA: 0x15EC454 Offset: 0x15EC454 VA: 0x15EC454 Slot: 47
	public override void NBMDAOFPKGK(int _DNBFMLBNAEE_Point)
	{
		HIHJGPDLNDN_EventScore ev = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.LBDOLHGDIEB_GetDbSection(JOPOPMLFINI_QuestName) as HIHJGPDLNDN_EventScore;
		if(ev != null)
		{
			FEHINJKHDAP_EventScore.ALGDNCMJHGN save = CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_PlayerData.KOOKJBMGBIG_EventScore.FBCJICEPLED[ev.NGHKJOEDLIP_Settings.MOEKELIIDEO_SaveIdx];
			save.DNBFMLBNAEE_Point += _DNBFMLBNAEE_Point;
		}
	}

	// // RVA: 0x15EC6E0 Offset: 0x15EC6E0 VA: 0x15EC6E0 Slot: 48
	public override void AMKJFGLEJGE_RequestUpdateEventPoint(int KPIILHGOGJD)
	{
		if(KBACNOCOANM_Ranking != null)
		{
			HIHJGPDLNDN_EventScore ev = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.LBDOLHGDIEB_GetDbSection(JOPOPMLFINI_QuestName) as HIHJGPDLNDN_EventScore;
			if(ev != null)
			{
				FEHINJKHDAP_EventScore.ALGDNCMJHGN save = CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_PlayerData.KOOKJBMGBIG_EventScore.FBCJICEPLED[ev.NGHKJOEDLIP_Settings.MOEKELIIDEO_SaveIdx];
				PJDGDNJNCNM_UpdateStatusImpl(NKGJPJPHLIF.HHCJCDFCLOB.IBLPICFDGOF_ServerRequester.FJDBNGEPKHL_Time.KMEFBNBFJHI_GetServerTime());
				if(NGOFCFJHOMI_Status == KGCNCBOKCBA.GNENJEHKMHD_EventStatus.NCJFJLPJMLI_2 ||
					NGOFCFJHOMI_Status == KGCNCBOKCBA.GNENJEHKMHD_EventStatus.MINDIGBAJFG_3 ||
					NGOFCFJHOMI_Status == KGCNCBOKCBA.GNENJEHKMHD_EventStatus.MEAJLPAHINL_ChallengePeriod_5 ||
					NGOFCFJHOMI_Status == KGCNCBOKCBA.GNENJEHKMHD_EventStatus.EMAMLLFAOJI_Counting_6) //0x6cU
				{
					EECOJKDJIFG e = KKLGENJKEBN.HHCJCDFCLOB.JPDPFGFMKHK_rankings.Find((EECOJKDJIFG _GHPLINIACBB_x) =>
					{
						//0x15EEC84
						return _GHPLINIACBB_x.OCGFKMHNEOF_name_for_api == KBACNOCOANM_Ranking.OCGFKMHNEOF_name_for_api;
					});
					if(e != null)
					{
						PKECIDPBEFL.DDBKLMKKCDL d = new PKECIDPBEFL.DDBKLMKKCDL();
						d.OACABIDEMGG_Score = BOAGCEOHJEO.GOAOBNBGDBJ(GLIMIGNNGGB_RankingStart, LOLAANGCGDO_RankingEnd2, save.NFIOKIBPJCJ_uptime, save.DNBFMLBNAEE_Point);
						d.BLJIJENHBPM_Id = e.PPFNGGCBJKC_id;
						d.OBGBAOLONDD_UniqueId = PGIIDPEGGPI_EventId;
						d.NOBCHBHEPNC_Idx = KPIILHGOGJD;
						JGEOBNENMAH.HHCJCDFCLOB.CBGMOGIBALL.Add(d);
						return;
					}
				}
			}
		}
		PLOOEECNHFB_IsDone = true;
	}

	// // RVA: 0x15ECC48 Offset: 0x15ECC48 VA: 0x15ECC48 Slot: 49
	protected override void ODPJGHOJIOH(int LHJCOPMMIGO)
	{
		if(KBACNOCOANM_Ranking != null)
		{
			HIHJGPDLNDN_EventScore ev = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.LBDOLHGDIEB_GetDbSection(JOPOPMLFINI_QuestName) as HIHJGPDLNDN_EventScore;
			if(ev != null)
			{
				FEHINJKHDAP_EventScore.ALGDNCMJHGN save = CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_PlayerData.KOOKJBMGBIG_EventScore.FBCJICEPLED[ev.NGHKJOEDLIP_Settings.MOEKELIIDEO_SaveIdx];
				PJDGDNJNCNM_UpdateStatusImpl(NKGJPJPHLIF.HHCJCDFCLOB.IBLPICFDGOF_ServerRequester.FJDBNGEPKHL_Time.KMEFBNBFJHI_GetServerTime());
				if(NGOFCFJHOMI_Status == KGCNCBOKCBA.GNENJEHKMHD_EventStatus.NCJFJLPJMLI_2 ||
					NGOFCFJHOMI_Status == KGCNCBOKCBA.GNENJEHKMHD_EventStatus.MINDIGBAJFG_3 ||
					NGOFCFJHOMI_Status == KGCNCBOKCBA.GNENJEHKMHD_EventStatus.MEAJLPAHINL_ChallengePeriod_5 ||
					NGOFCFJHOMI_Status == KGCNCBOKCBA.GNENJEHKMHD_EventStatus.EMAMLLFAOJI_Counting_6) //0x6cU
				{
					KKLGENJKEBN.HHCJCDFCLOB.LDOBHAAIDEJ_UpdateRankingScore(KBACNOCOANM_Ranking.OCGFKMHNEOF_name_for_api, LHJCOPMMIGO, BOAGCEOHJEO.GOAOBNBGDBJ(GLIMIGNNGGB_RankingStart, LOLAANGCGDO_RankingEnd2, save.NFIOKIBPJCJ_uptime, save.DNBFMLBNAEE_Point), () =>
					{
						//0x15EED90
						CDINKAANIAA_Rank[LHJCOPMMIGO] = (int)KKLGENJKEBN.HHCJCDFCLOB.LPPCNCMEDFA_Rank;
						PLOOEECNHFB_IsDone = true;
						int ranking_point_max = ev.LPJLEHAJADA("ranking_point_max", 1000000);
						ILCCJNDFFOB.HHCJCDFCLOB.NNFGBBCHLPC(PGIIDPEGGPI_EventId, "StringLiteral_10994", EJDJIBPKKNO_BasePoint, save.DNBFMLBNAEE_Point, ranking_point_max, KKLGENJKEBN.HHCJCDFCLOB.DFBALJAPHMC_DroppedPlayer);
					}, () =>
					{
						//0x15EEFC8
						PLOOEECNHFB_IsDone = true;
					}, () =>
					{
						//0x15EEFF0
						PLOOEECNHFB_IsDone = true;
						NPNNPNAIONN_IsError = true;
					});
					return;
				}
			}
		}
		else
			PLOOEECNHFB_IsDone = true;
	}

	// // RVA: 0x15ED164 Offset: 0x15ED164 VA: 0x15ED164 Slot: 52
	public override void FAMFKPBPIAA_GetRankingPlayerList(bool PFFJNEFNAMI, int CJHEHIMLGGL, int LHJCOPMMIGO, LIOLBKLMMIK _KLMFJJCNBIP_OnSuccess, DJBHIFLHJLK _IDAEHNGOKAE_OnRankingError, DJBHIFLHJLK _JGKOLBLPMPG_OnFail)
	{
		NPNNPNAIONN_IsError = false;
		PLOOEECNHFB_IsDone = false;
		HIHJGPDLNDN_EventScore ev = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.LBDOLHGDIEB_GetDbSection(JOPOPMLFINI_QuestName) as HIHJGPDLNDN_EventScore;
		if(ev != null)
		{
			KKLGENJKEBN.HHCJCDFCLOB.FAMFKPBPIAA_GetRankingPlayerList(KBACNOCOANM_Ranking.OCGFKMHNEOF_name_for_api, PFFJNEFNAMI, CJHEHIMLGGL, LHJCOPMMIGO, (int NEFEFHBHFFF, List<IBIGBMDANNM> MAGKKPOFJIM) =>
			{
				//0x15EF034
				PLOOEECNHFB_IsDone = true;
				_KLMFJJCNBIP_OnSuccess(NEFEFHBHFFF, MAGKKPOFJIM);
			}, () =>
			{
				//0x15EF090
				PLOOEECNHFB_IsDone = true;
				_IDAEHNGOKAE_OnRankingError();
			}, () =>
			{
				//0x15EF0DC
				PLOOEECNHFB_IsDone = true;
				NPNNPNAIONN_IsError = true;
				_JGKOLBLPMPG_OnFail();
			}, false);
		}
		else
		{
			_IDAEHNGOKAE_OnRankingError();
			PLOOEECNHFB_IsDone = true;
		}
	}

	// // RVA: 0x15ED490 Offset: 0x15ED490 VA: 0x15ED490 Slot: 53
	public override void JPNACOLKHLB_AddRankingPlayerListSecond(int CJHEHIMLGGL, int NEFEFHBHFFF, LIOLBKLMMIK _KLMFJJCNBIP_OnSuccess, DJBHIFLHJLK _IDAEHNGOKAE_OnRankingError, DJBHIFLHJLK _JGKOLBLPMPG_OnFail)
	{
		KKLGENJKEBN.HHCJCDFCLOB.JPNACOLKHLB_AddRankingPlayerListSecond(CJHEHIMLGGL, NEFEFHBHFFF, (int _JGNBPFCJLKI_d, List<IBIGBMDANNM> MAGKKPOFJIM) =>
		{
			//0x15EF140
			PLOOEECNHFB_IsDone = true;
			_KLMFJJCNBIP_OnSuccess(_JGNBPFCJLKI_d, MAGKKPOFJIM);
		}, () =>
		{
			//0x15EF19C
			PLOOEECNHFB_IsDone = true;
			_IDAEHNGOKAE_OnRankingError();
		}, () =>
		{
			//0x15EF1E8
			PLOOEECNHFB_IsDone = true;
			NPNNPNAIONN_IsError = true;
			_JGKOLBLPMPG_OnFail();
		}, false);
	}

	// // RVA: 0x15ED64C Offset: 0x15ED64C VA: 0x15ED64C
	// private int APJDIPINLLK(List<int> HNLFPKNBOHE, int _PPFNGGCBJKC_id) { }

	// // RVA: 0x15EC10C Offset: 0x15EC10C VA: 0x15EC10C
	private void PIMFJALCIGK()
	{
		int a = NGIHFKHOJOK_GetRankingMax(true);
		for(int i = 0; i < a; i++)
		{
			BJEOAOACMGG(a);
		}
	}

	// // RVA: 0x15ED744 Offset: 0x15ED744 VA: 0x15ED744
	private void BJEOAOACMGG(int LHJCOPMMIGO)
	{
		HIHJGPDLNDN_EventScore ev = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.LBDOLHGDIEB_GetDbSection(JOPOPMLFINI_QuestName) as HIHJGPDLNDN_EventScore;
		if(ev != null)
		{
			FEHINJKHDAP_EventScore.ALGDNCMJHGN save = CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_PlayerData.KOOKJBMGBIG_EventScore.FBCJICEPLED[ev.NGHKJOEDLIP_Settings.MOEKELIIDEO_SaveIdx];
			EGIPGHCDMII_RankData[LHJCOPMMIGO].Clear();
			if(KBACNOCOANM_Ranking != null)
			{
				for(int i = 0; i < KBACNOCOANM_Ranking.AHJNPEAMCCH_Rewards.Count; i++)
				{
					MAOCCKFAOPC m = new MAOCCKFAOPC();
					m.JBDGBPAAAEF_HighRank = KBACNOCOANM_Ranking.AHJNPEAMCCH_Rewards[i].JPHDGGNAKMO_high_rank;
					m.GHANKNIBALB_LowRank = KBACNOCOANM_Ranking.AHJNPEAMCCH_Rewards[i].FGCAJEAIABA_LowRank;
					m.MJGAMDBOMHD_InventoryMessage = KBACNOCOANM_Ranking.AHJNPEAMCCH_Rewards[i].IPFEKNMBEBI_InventoryMessage;
					m.HBHMAKNGKFK_Items = KBACNOCOANM_Ranking.AHJNPEAMCCH_Rewards[i].HBHMAKNGKFK_Items;
					EGIPGHCDMII_RankData[LHJCOPMMIGO].Add(m);
				}
			}
		}
	}

	// // RVA: 0x15EDC0C Offset: 0x15EDC0C VA: 0x15EDC0C
	// private void DENHAAGACPD() { }

	// // RVA: 0x15EDEC0 Offset: 0x15EDEC0 VA: 0x15EDEC0 Slot: 58
	protected override void LMGMELPOGMH(int LHJCOPMMIGO)
	{
		HIHJGPDLNDN_EventScore ev = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.LBDOLHGDIEB_GetDbSection(JOPOPMLFINI_QuestName) as HIHJGPDLNDN_EventScore;
		if(ev != null)
		{
			HLFHJIDHJMP = null;
			OKPEFAPPFDH_GetRanksAroundSelf req = NKGJPJPHLIF.HHCJCDFCLOB.IBLPICFDGOF_ServerRequester.IFFNCAFNEAG_AddRequest(new OKPEFAPPFDH_GetRanksAroundSelf(false));
			req.EMPNJPMAKBF_Id = KBACNOCOANM_Ranking.PPFNGGCBJKC_id;
			req.MJGOBEGONON_Type = 0;
			req.NHPCKCOPKAM_from = 0;
			req.PJFKNNNDMIA_to = 0;
			req.MOBEEPPKFLG_OnFail = (CACGCMBKHDI_Request KCFBGMKDIMI) =>
			{
				//0x15EF24C
				if(JGJFFKPFMDB.BDGBCCGLLAJ_IsRankingError(KCFBGMKDIMI.CJMFJOMECKI_ErrorId))
				{
					if(KCFBGMKDIMI.CJMFJOMECKI_ErrorId == SakashoErrorId.RANKING_DROPPED_PLAYER)
					{
						FKKDIDMGLMI_IsDroppedPlayer = true;
					}
					FEHINJKHDAP_EventScore.ALGDNCMJHGN save = CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_PlayerData.KOOKJBMGBIG_EventScore.FBCJICEPLED[ev.NGHKJOEDLIP_Settings.MOEKELIIDEO_SaveIdx];
					save.HPLMECLKFID_RRcv = true;
					PJDGDNJNCNM_UpdateStatusImpl(NKGJPJPHLIF.HHCJCDFCLOB.IBLPICFDGOF_ServerRequester.FJDBNGEPKHL_Time.KMEFBNBFJHI_GetServerTime());
					PLOOEECNHFB_IsDone = true;
				}
				else
				{
					PLOOEECNHFB_IsDone = true;
					NPNNPNAIONN_IsError = true;
				}
			};
			req.BHFHGFKBOHH_OnSuccess = (CACGCMBKHDI_Request KCFBGMKDIMI) =>
			{
				//0x15EF578
				OKPEFAPPFDH_GetRanksAroundSelf r = KCFBGMKDIMI as OKPEFAPPFDH_GetRanksAroundSelf;
				if(r.NFEAMMJIMPG_Result.EJDEDOJFOOK.Count == 0)
				{
					FEHINJKHDAP_EventScore.ALGDNCMJHGN save = CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_PlayerData.KOOKJBMGBIG_EventScore.FBCJICEPLED[ev.NGHKJOEDLIP_Settings.MOEKELIIDEO_SaveIdx];
					save.HPLMECLKFID_RRcv = true;
					PJDGDNJNCNM_UpdateStatusImpl(NKGJPJPHLIF.HHCJCDFCLOB.IBLPICFDGOF_ServerRequester.FJDBNGEPKHL_Time.KMEFBNBFJHI_GetServerTime());
					PLOOEECNHFB_IsDone = true;
				}
				else
				{
					HLFHJIDHJMP = new NHGEHCMPDAI();
					HLFHJIDHJMP.DNBFMLBNAEE_Point = r.NFEAMMJIMPG_Result.EJDEDOJFOOK[0].KNIFCANOHOC_score;
					HLFHJIDHJMP.FJOLNJLLJEJ_Rank = r.NFEAMMJIMPG_Result.EJDEDOJFOOK[0].FJOLNJLLJEJ_Rank;
					KKLGENJKEBN.HHCJCDFCLOB.DNJKPPCBINA(KBACNOCOANM_Ranking.OCGFKMHNEOF_name_for_api, () =>
					{
						//0x15EFC4C
						for(int i = 0; i < KKLGENJKEBN.HHCJCDFCLOB.PHOPJDPEHJA.Count; i++)
						{
							MFDJIFIIPJD m = new MFDJIFIIPJD();
							m.KHEKNNFCAOI_Init(KKLGENJKEBN.HHCJCDFCLOB.PHOPJDPEHJA[i].JJBGOIMEIPF_ItemId, KKLGENJKEBN.HHCJCDFCLOB.PHOPJDPEHJA[i].MBJIFDBEDAC_item_count);
							HLFHJIDHJMP.HBHMAKNGKFK_Items.Add(m);
						}
						ILCCJNDFFOB.HHCJCDFCLOB.GIBLHFKIMDA(this);
						FEHINJKHDAP_EventScore.ALGDNCMJHGN save = CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_PlayerData.KOOKJBMGBIG_EventScore.FBCJICEPLED[ev.NGHKJOEDLIP_Settings.MOEKELIIDEO_SaveIdx];
						save.HPLMECLKFID_RRcv = true;
						PLOOEECNHFB_IsDone = true;
					}, () =>
					{
						//0x15EFFC8
						HLFHJIDHJMP = null;
						ILCCJNDFFOB.HHCJCDFCLOB.GIBLHFKIMDA(this);
						FEHINJKHDAP_EventScore.ALGDNCMJHGN save = CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_PlayerData.KOOKJBMGBIG_EventScore.FBCJICEPLED[ev.NGHKJOEDLIP_Settings.MOEKELIIDEO_SaveIdx];
						save.HPLMECLKFID_RRcv = true;
						PLOOEECNHFB_IsDone = true;
					}, () =>
					{
						//0x15F01B0
						FEHINJKHDAP_EventScore.ALGDNCMJHGN save = CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_PlayerData.KOOKJBMGBIG_EventScore.FBCJICEPLED[ev.NGHKJOEDLIP_Settings.MOEKELIIDEO_SaveIdx];
						save.HPLMECLKFID_RRcv = true;
						PLOOEECNHFB_IsDone = true;
						HLFHJIDHJMP = null;
					}, () =>
					{
						//0x15F033C
						PLOOEECNHFB_IsDone = true;
						HLFHJIDHJMP = null;
					}, () =>
					{
						//0x15F0384
						PLOOEECNHFB_IsDone = true;
						NPNNPNAIONN_IsError = true;
					}, 0, -1);
				}
			};
		}
		else
		{
			PLOOEECNHFB_IsDone = true;
		}
	}

	// // RVA: 0x15EE24C Offset: 0x15EE24C VA: 0x15EE24C
	public FEHINJKHDAP_EventScore.ALGDNCMJHGN JIPPHOKGLIH(bool HOENAFAJMGI/* = false*/)
	{
		HIHJGPDLNDN_EventScore ev = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.LBDOLHGDIEB_GetDbSection(JOPOPMLFINI_QuestName) as HIHJGPDLNDN_EventScore;
		if(ev != null)
		{
			if(HOENAFAJMGI)
				return CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_PlayerData.KOOKJBMGBIG_EventScore.FBCJICEPLED[ev.NGHKJOEDLIP_Settings.MOEKELIIDEO_SaveIdx];
			else
				return CIOECGOMILE.HHCJCDFCLOB.MNJHBCIIHED_PrevServerData.KOOKJBMGBIG_EventScore.FBCJICEPLED[ev.NGHKJOEDLIP_Settings.MOEKELIIDEO_SaveIdx];
		}
		return null;
	}

	// // RVA: 0x15EE4E8 Offset: 0x15EE4E8 VA: 0x15EE4E8 Slot: 33
	public override bool MPMKJNJGFEF_IsEntry()
	{
		HIHJGPDLNDN_EventScore ev = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.LBDOLHGDIEB_GetDbSection(JOPOPMLFINI_QuestName) as HIHJGPDLNDN_EventScore;
		if(ev != null)
		{
			FEHINJKHDAP_EventScore.ALGDNCMJHGN save = CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_PlayerData.KOOKJBMGBIG_EventScore.FBCJICEPLED[ev.NGHKJOEDLIP_Settings.MOEKELIIDEO_SaveIdx];
			return save.IMFBCJOIJKJ_Entry;
		}
		return false;
	}

	// // RVA: 0x15EE748 Offset: 0x15EE748 VA: 0x15EE748 Slot: 69
	public override void HAAEJDGMICH(LBNLAENLPNK.JEKODBEDOMM _INDDJNMPONH_type, IMCBBOAFION _BHFHGFKBOHH_OnSuccess, DJBHIFLHJLK _AOCANKOMKFG_OnError)
	{
		string s = null;
		if(_INDDJNMPONH_type == 0)
		{
			s = JOPOPMLFINI_QuestName + "_rule";
		}
		if(string.IsNullOrEmpty(s))
		{
			_BHFHGFKBOHH_OnSuccess();
		}
		else
		{
			MBCPNPNMFHB.HHCJCDFCLOB.FLLLPBIECCP(s, _BHFHGFKBOHH_OnSuccess, _AOCANKOMKFG_OnError);
		}
	}

	// // RVA: 0x15EE870 Offset: 0x15EE870 VA: 0x15EE870 Slot: 71
	public override int BAEPGOAMBDK(string _LJNAKDMILMC_key, int MNCOAGOKNAO)
	{
		HIHJGPDLNDN_EventScore ev = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.LBDOLHGDIEB_GetDbSection(JOPOPMLFINI_QuestName) as HIHJGPDLNDN_EventScore;
		if(ev != null)
		{
			return ev.LPJLEHAJADA(_LJNAKDMILMC_key, MNCOAGOKNAO);
		}
		return MNCOAGOKNAO;
	}

	// // RVA: 0x15EE9F0 Offset: 0x15EE9F0 VA: 0x15EE9F0 Slot: 72
	public override string MAICAKMIBEM(string _LJNAKDMILMC_key, string MNCOAGOKNAO)
	{
		HIHJGPDLNDN_EventScore ev = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.LBDOLHGDIEB_GetDbSection(JOPOPMLFINI_QuestName) as HIHJGPDLNDN_EventScore;
		if(ev != null)
		{
			return ev.EFEGBHACJAL(_LJNAKDMILMC_key, MNCOAGOKNAO);
		}
		return MNCOAGOKNAO;
	}

	// // RVA: 0x15EEB70 Offset: 0x15EEB70 VA: 0x15EEB70 Slot: 38
	public override void EMEPJNLHJHJ(int GJEADBKFAPA, int _AKNELONELJK_difficulty, bool _GIKLNODJKFK_IsLine6, ref int APMGOLOPLFP, ref int FBBDNLAMPMH)
	{
		APMGOLOPLFP = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.HNMMJINNHII_Game.JJIBDCAIBIO_LuckCoef0;
		FBBDNLAMPMH = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.HNMMJINNHII_Game.AMNBEMCJCHF_LuckCoef1;
	}
}
