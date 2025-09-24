
using System.Collections;
using System.Collections.Generic;
using System.Text;
using XeApp.Game.Common;
using XeApp.Game.Menu;

[System.Obsolete("Use HJNNLPIGHLM_EventCollection", true)]
public class HJNNLPIGHLM { }
public class HJNNLPIGHLM_EventCollection : IKDICBBFBMI_EventBase
{
	public class GFLKMKOPNED
	{
		public List<int> PPBHHLGPMBK; // 0x8
		public List<int> IONINNDIAFO; // 0xC
		public int FPEOGFMKMKJ_Point; // 0x10
		public int ANOCILKJGOJ_EpisodeCnt; // 0x14
		public int ODCLHPGHDHA_EpisodeBonus; // 0x18
		public int PIIEGNPOPJI_GetPoint; // 0x1C
		public int FCLGIPFPIPH_DashBonus; // 0x20
		public int OENBOLPDBAB_FreeMusicId; // 0x24
		public int GCAPLLEIAAI_LastScore; // 0x28
		public int IDCFOMMKGIK; // 0x2C
		public int LPGNCOFHOPK_SaveScore; // 0x30
		public bool GIIKOMPJOHA_IsHiScore; // 0x34
	}

	private const int GHJHJDIDCFA = 3;
	private List<PHBACNMCMHG_EventCollection.LLFNMNJGLNL> NFMDLCBJOIB_SongCacheList = new List<PHBACNMCMHG_EventCollection.LLFNMNJGLNL>(); // 0xE8
	private List<EECOJKDJIFG> KBACNOCOANM_Ranking = new List<EECOJKDJIFG>(); // 0xEC
	public bool KIBBLLADDPO; // 0xF0
	public GFLKMKOPNED EELENPNCGLM = new GFLKMKOPNED(); // 0xF4

	public override OHCAABOMEOF.KGOGMKMBCPP_EventType HIDHLFCBIDE_EventType { get { return OHCAABOMEOF.KGOGMKMBCPP_EventType.AOPKACCDKPA_EventCollection; } } //0x183A61C DKHCGLCNKCD  Slot: 4

	// // RVA: 0x183A624 Offset: 0x183A624 VA: 0x183A624 Slot: 32
	public override EECOJKDJIFG DAKMIKNKHMF_GetRankingInfoForIndex(int LHJCOPMMIGO)
	{
		int m = NGIHFKHOJOK_GetRankingMax(true);
		if(m > LHJCOPMMIGO)
			return KBACNOCOANM_Ranking[LHJCOPMMIGO];
		return null;
	}

	// // RVA: 0x183A6CC Offset: 0x183A6CC VA: 0x183A6CC
	public HJNNLPIGHLM_EventCollection(string _OPFGFINHFCE_name) : base(_OPFGFINHFCE_name)
    {
        return;
    }

	// // RVA: 0x183A7EC Offset: 0x183A7EC VA: 0x183A7EC Slot: 5
	public override string IFKKBHPMALH()
	{
		PHBACNMCMHG_EventCollection ev = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.LBDOLHGDIEB_GetDbSection(JOPOPMLFINI_QuestName) as PHBACNMCMHG_EventCollection;
		if(ev != null)
		{
			return ev.NGHKJOEDLIP_Settings.OCDMGOGMHGE_RewardPrefix;
		}
		return null;
	}

	// // RVA: 0x183A974 Offset: 0x183A974 VA: 0x183A974
	private List<PHBACNMCMHG_EventCollection.LLFNMNJGLNL> LEAGIGKFMPE()
	{
		PHBACNMCMHG_EventCollection ev = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.LBDOLHGDIEB_GetDbSection(JOPOPMLFINI_QuestName) as PHBACNMCMHG_EventCollection;
		if(ev != null)
		{
			long t = NKGJPJPHLIF.HHCJCDFCLOB.IBLPICFDGOF_ServerRequester.FJDBNGEPKHL_Time.KMEFBNBFJHI_GetServerTime();
			NFMDLCBJOIB_SongCacheList.Clear();
			for(int i = 0; i < ev.IJJHFGOIDOK_EventMusic.Count; i++)
			{
				if(ev.IJJHFGOIDOK_EventMusic[i].PLALNIIBLOF_en == 2)
				{
					if((ev.IJJHFGOIDOK_EventMusic[i].PDBPFJJCADD_open_at == 0 && ev.IJJHFGOIDOK_EventMusic[i].FDBNFFNFOND_close_at == 0) || 
					(t >= ev.IJJHFGOIDOK_EventMusic[i].PDBPFJJCADD_open_at && ev.IJJHFGOIDOK_EventMusic[i].FDBNFFNFOND_close_at >= t))
					{
						NFMDLCBJOIB_SongCacheList.Add(ev.IJJHFGOIDOK_EventMusic[i]);
					}
				}
			}
			return NFMDLCBJOIB_SongCacheList;
		}
		return null;
	}

	// // RVA: 0x183ACB8 Offset: 0x183ACB8 VA: 0x183ACB8
	public List<PHBACNMCMHG_EventCollection.LLFNMNJGLNL> KOBMFPACBMB()
	{
		if(NFMDLCBJOIB_SongCacheList.Count < 1)
		{
			return LEAGIGKFMPE();
		}
		return NFMDLCBJOIB_SongCacheList;
	}

	// // RVA: 0x183AD44 Offset: 0x183AD44 VA: 0x183AD44
	public void BEFJOAGGAJD()
	{
		NFMDLCBJOIB_SongCacheList.Clear();
	}

	// // RVA: 0x183ADBC Offset: 0x183ADBC VA: 0x183ADBC Slot: 7
	public override List<int> HEACCHAKMFG_GetMusicsList()
	{
		List<int> res = new List<int>();
		BEFJOAGGAJD();
		List<PHBACNMCMHG_EventCollection.LLFNMNJGLNL> l = KOBMFPACBMB();
		if(l != null)
		{
			for(int i = 0; i < l.Count; i++)
			{
				res.Add(l[i].MPLGPBNJDJB_FreeMusicId);
			}
		}
		return res;
	}

	// // RVA: 0x183AF30 Offset: 0x183AF30 VA: 0x183AF30 Slot: 9
	public override long HOOBCIIOCJD_GetSongEndTime(int _GHBPLHBNMBK_FreeMusicId)
	{
		List<PHBACNMCMHG_EventCollection.LLFNMNJGLNL> l = KOBMFPACBMB();
		if(l != null)
		{
			long t = NKGJPJPHLIF.HHCJCDFCLOB.IBLPICFDGOF_ServerRequester.FJDBNGEPKHL_Time.KMEFBNBFJHI_GetServerTime();
			if(l.Count > 0)
			{
				for(int i = 0; i < l.Count; i++)
				{
					if(l[i].PDBPFJJCADD_open_at != 0 && 
						l[i].FDBNFFNFOND_close_at != 0 && 
						t >= l[i].PDBPFJJCADD_open_at && 
						l[i].FDBNFFNFOND_close_at >= t && 
						l[i].MPLGPBNJDJB_FreeMusicId == _GHBPLHBNMBK_FreeMusicId)
							return l[i].FDBNFFNFOND_close_at;
				}
			}
		}
		return base.HOOBCIIOCJD_GetSongEndTime(_GHBPLHBNMBK_FreeMusicId);
	}

	// // RVA: 0x183B230 Offset: 0x183B230 VA: 0x183B230 Slot: 10
	public override bool GIDDKGMPIOK_IsLimited(int _GHBPLHBNMBK_FreeMusicId)
	{
		List<PHBACNMCMHG_EventCollection.LLFNMNJGLNL> l = KOBMFPACBMB();
		if(l != null)
		{
			long t = NKGJPJPHLIF.HHCJCDFCLOB.IBLPICFDGOF_ServerRequester.FJDBNGEPKHL_Time.KMEFBNBFJHI_GetServerTime();
			if(l.Count > 0)
			{
				for(int i = 0; i < l.Count; i++)
				{
					if(l[i].PDBPFJJCADD_open_at != 0 && 
						l[i].FDBNFFNFOND_close_at != 0 && 
						l[i].FDBNFFNFOND_close_at < DPJCPDKALGI_RankingEnd && 
						t >= l[i].PDBPFJJCADD_open_at && 
						l[i].FDBNFFNFOND_close_at >= t && 
						l[i].MPLGPBNJDJB_FreeMusicId == _GHBPLHBNMBK_FreeMusicId)
							return true;
				}
			}
		}
		return false;
	}

	// // RVA: 0x183B550 Offset: 0x183B550 VA: 0x183B550
	public new int OMJHBJPCFFC_GetEventBonusPercent(int _EHDDADDKMFI_f_id)
	{
		// Not used since it doesn't override. But db block don't match so it's normal I guess.
		ACBAHDMEFFL_EventMission ev = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.LBDOLHGDIEB_GetDbSection(JOPOPMLFINI_QuestName) as ACBAHDMEFFL_EventMission;
		if(ev != null)
		{
			long t = NKGJPJPHLIF.HHCJCDFCLOB.IBLPICFDGOF_ServerRequester.FJDBNGEPKHL_Time.KMEFBNBFJHI_GetServerTime();
			List<int> l = new List<int>();
			for(int i = 0; i < ev.IJJHFGOIDOK_EventMusic.Count; i++)
			{
				if(ev.IJJHFGOIDOK_EventMusic[i].PLALNIIBLOF_en == 2 && 
					((ev.IJJHFGOIDOK_EventMusic[i].PDBPFJJCADD_open_at == 0 && ev.IJJHFGOIDOK_EventMusic[i].FDBNFFNFOND_close_at == 0) || 
					(ev.IJJHFGOIDOK_EventMusic[i].PDBPFJJCADD_open_at < t && ev.IJJHFGOIDOK_EventMusic[i].FDBNFFNFOND_close_at >= t))
					&& ev.IJJHFGOIDOK_EventMusic[i].MPLGPBNJDJB_FreeMusicId == _EHDDADDKMFI_f_id)
				{
					return ev.IJJHFGOIDOK_EventMusic[i].DKHIHHMOIKM_bns;
				}
			}
		}
		return 0;
	}

	// // RVA: 0x183B864 Offset: 0x183B864 VA: 0x183B864 Slot: 27
	public override int HLOGNJNGDJO_GetHelpId(int _OIPCCBHIKIA_index/* = 0*/)
	{
		PHBACNMCMHG_EventCollection ev = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.LBDOLHGDIEB_GetDbSection(JOPOPMLFINI_QuestName) as PHBACNMCMHG_EventCollection;
		if(ev != null)
		{
			return ev.NGHKJOEDLIP_Settings.EJBGHLOOLBC_HelpIds[_OIPCCBHIKIA_index];
		}
		return 0;
	}

	// // RVA: 0x183BA20 Offset: 0x183BA20 VA: 0x183BA20 Slot: 67
	// public override int LBNKDKDMMOK() { }

	// // RVA: 0x183BBA4 Offset: 0x183BBA4 VA: 0x183BBA4 Slot: 28
	public override long FBGDBGKNKOD_GetCurrentPoint()
	{
		PHBACNMCMHG_EventCollection ev = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.LBDOLHGDIEB_GetDbSection(JOPOPMLFINI_QuestName) as PHBACNMCMHG_EventCollection;
		if(ev != null)
		{
			FJGNPNFLHPH_EventCollection.JIALCLGJPKL save = CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_PlayerData.MBAHCFLBDHN_EventCollection.FBCJICEPLED[ev.NGHKJOEDLIP_Settings.MOEKELIIDEO_SaveIdx];
			return save.DNBFMLBNAEE_point;
		}
		return 0;
	}

	// // RVA: 0x183BE04 Offset: 0x183BE04 VA: 0x183BE04
	public long AFCIIKDOMHN_GetScore()
	{
		PHBACNMCMHG_EventCollection ev = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.LBDOLHGDIEB_GetDbSection(JOPOPMLFINI_QuestName) as PHBACNMCMHG_EventCollection;
		if(ev != null)
		{
			FJGNPNFLHPH_EventCollection.JIALCLGJPKL save = CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_PlayerData.MBAHCFLBDHN_EventCollection.FBCJICEPLED[ev.NGHKJOEDLIP_Settings.MOEKELIIDEO_SaveIdx];
			return save.KNIFCANOHOC_score;
		}
		return 0;
	}

	// // RVA: 0x183C064 Offset: 0x183C064 VA: 0x183C064 Slot: 29
	public override void MJFKJHJJLMN_GetRanks(int LHJCOPMMIGO/* = 0*/, bool _FBBNPFFEJBN_Force/* = false*/)
	{
		PLOOEECNHFB_IsDone = false;
		NPNNPNAIONN_IsError = false;
		EECOJKDJIFG e = DAKMIKNKHMF_GetRankingInfoForIndex(LHJCOPMMIGO);
		if(e != null)
		{
			PHBACNMCMHG_EventCollection ev = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.LBDOLHGDIEB_GetDbSection(JOPOPMLFINI_QuestName) as PHBACNMCMHG_EventCollection;
			if(ev != null)
			{
				if(GPHEKCNDDIK)
				{
					long t = NKGJPJPHLIF.HHCJCDFCLOB.IBLPICFDGOF_ServerRequester.FJDBNGEPKHL_Time.KMEFBNBFJHI_GetServerTime();
					int get_rank_cooling_time = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.GDEKCOOBLMA_System.LPJLEHAJADA_GetIntParam("get_rank_cooling_time", 60);
					if(_FBBNPFFEJBN_Force || CDINKAANIAA_Rank[LHJCOPMMIGO] <= 0 || (t - KPOMHFLKMKI_LastRankUpdateTime[LHJCOPMMIGO] >= get_rank_cooling_time))
					{
						//LAB_0183c464
						KKLGENJKEBN.HHCJCDFCLOB.HEOKADCEAGL_GetRanks(ev.NGHKJOEDLIP_Settings.OCGFKMHNEOF_name_for_api, () =>
						{
							//0x1846F78
							CDINKAANIAA_Rank[LHJCOPMMIGO] = (int)KKLGENJKEBN.HHCJCDFCLOB.LPPCNCMEDFA_Rank;
							KPOMHFLKMKI_LastRankUpdateTime[LHJCOPMMIGO] = NKGJPJPHLIF.HHCJCDFCLOB.IBLPICFDGOF_ServerRequester.FJDBNGEPKHL_Time.KMEFBNBFJHI_GetServerTime();
							PLOOEECNHFB_IsDone = true;
						}, () =>
						{
							//0x184713C
							KPOMHFLKMKI_LastRankUpdateTime[LHJCOPMMIGO] = NKGJPJPHLIF.HHCJCDFCLOB.IBLPICFDGOF_ServerRequester.FJDBNGEPKHL_Time.KMEFBNBFJHI_GetServerTime();
							CDINKAANIAA_Rank[LHJCOPMMIGO] = 0;
							PLOOEECNHFB_IsDone = true;
						}, () =>
						{
							//0x18472E4
							CDINKAANIAA_Rank[LHJCOPMMIGO] = 0;
							PLOOEECNHFB_IsDone = true;
							NPNNPNAIONN_IsError = true;
						}, () =>
						{
							//0x184737C
							CDINKAANIAA_Rank[LHJCOPMMIGO] = 0;
							PLOOEECNHFB_IsDone = true;
							FKKDIDMGLMI_IsDroppedPlayer = true;
						});
						return;
					}
				}
			}
		}
		CDINKAANIAA_Rank[LHJCOPMMIGO] = 0;
		PLOOEECNHFB_IsDone = true;
	}

	// // RVA: 0x183C5C0 Offset: 0x183C5C0 VA: 0x183C5C0 Slot: 30
	protected override bool JIHMLILFOPG_IsEventActive(long _JHNMKKNEENE_Time)
	{
		PHBACNMCMHG_EventCollection ev = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.LBDOLHGDIEB_GetDbSection(JOPOPMLFINI_QuestName) as PHBACNMCMHG_EventCollection;
		if(ev != null)
		{
			GDIPLANPCEI g = IMMAOANGPNK.HHCJCDFCLOB.ACEFBFLFKFD_GetScheduleEventData(ev.JIKKNHIAEKG_BlockName, _JHNMKKNEENE_Time);
			if(g != null)
			{
				if(_JHNMKKNEENE_Time >= ev.NGHKJOEDLIP_Settings.BONDDBOFBND_RankingStart && ev.NGHKJOEDLIP_Settings.KNLGKBBIBOH_RewardEnd2 >= _JHNMKKNEENE_Time)
				{
					if(ev.NGHKJOEDLIP_Settings.HKKNEAGCIEB_RankingSupport != 0)
					{
						List<string> PDDFOEDNFBN = new List<string>();
						PDDFOEDNFBN.Clear();
						if(ev.NGHKJOEDLIP_Settings.OCGFKMHNEOF_name_for_api != "")
						{
							PDDFOEDNFBN.Add(ev.NGHKJOEDLIP_Settings.OCGFKMHNEOF_name_for_api);
						}
						if(ev.NGHKJOEDLIP_Settings.OGMGLOFKKPA != "")
						{
							PDDFOEDNFBN.Add(ev.NGHKJOEDLIP_Settings.OGMGLOFKKPA);
						}
						for(int i = 0; i < PDDFOEDNFBN.Count; i++)
						{
							int _BMBBDIAEOMP_i = i;
                            EECOJKDJIFG e = KKLGENJKEBN.HHCJCDFCLOB.JPDPFGFMKHK_rankings.Find((EECOJKDJIFG PKLPKMLGFGK) =>
							{
								//0x1847414
								return PKLPKMLGFGK.OCGFKMHNEOF_name_for_api == PDDFOEDNFBN[_BMBBDIAEOMP_i];
							});
							if(e == null)
							{
								UnityEngine.Debug.LogError("Ranking not found : "+PDDFOEDNFBN[i]);
								return false;
							}
                        }
					}
					return true;
				}
			}
		}
		return false;
	}

	// // RVA: 0x183CB0C Offset: 0x183CB0C VA: 0x183CB0C Slot: 31
	protected override bool IMCMNOPNGHO(long _JHNMKKNEENE_Time)
	{
		PHBACNMCMHG_EventCollection ev = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.LBDOLHGDIEB_GetDbSection(JOPOPMLFINI_QuestName) as PHBACNMCMHG_EventCollection;
		if(ev != null)
		{
			FJGNPNFLHPH_EventCollection.JIALCLGJPKL save = CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_PlayerData.MBAHCFLBDHN_EventCollection.FBCJICEPLED[ev.NGHKJOEDLIP_Settings.MOEKELIIDEO_SaveIdx];
			string s = ev.NGHKJOEDLIP_Settings.OCGFKMHNEOF_name_for_api;
			if(s == "")
				s = ev.NGHKJOEDLIP_Settings.OGMGLOFKKPA;
			AGLILDLEFDK_Missions = ev.NNMPGOAGEOL_quests;
			OLDFFDMPEBM_Quests = save.NNMPGOAGEOL_quests;
			if(save.MPCAGEPEJJJ_Key != s || (!RuntimeSettings.CurrentSettings.UnlimitedEvent && save.EGBOHDFBAPB_closed_at < ev.NGHKJOEDLIP_Settings.BONDDBOFBND_RankingStart))
			{
				save.LHPDDGIJKNB_Reset();
				save.MPCAGEPEJJJ_Key = s;
				save.EGBOHDFBAPB_closed_at = ev.NGHKJOEDLIP_Settings.IDDBFFBPNGI_RewardEnd;
				KOMAHOAEMEK(true);
			}
			KOMAHOAEMEK(false);
			return true;
		}
		return false;
	}

	// // RVA: 0x183CE74 Offset: 0x183CE74 VA: 0x183CE74 Slot: 40
	protected override void KKFLDCBHFJA(long _JHNMKKNEENE_Time)
	{
		PHBACNMCMHG_EventCollection INJCPCDPGHH = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.LBDOLHGDIEB_GetDbSection(JOPOPMLFINI_QuestName) as PHBACNMCMHG_EventCollection;
		if(INJCPCDPGHH != null)
		{
			IBNKPMPFLGI_IsRankReward = INJCPCDPGHH.NGHKJOEDLIP_Settings.HKKNEAGCIEB_RankingSupport != 0;
			if(IBNKPMPFLGI_IsRankReward)
			{
				EECOJKDJIFG e = KKLGENJKEBN.HHCJCDFCLOB.JPDPFGFMKHK_rankings.Find((EECOJKDJIFG PKLPKMLGFGK) =>
				{
					//0x18474D0
					return INJCPCDPGHH.NGHKJOEDLIP_Settings.OCGFKMHNEOF_name_for_api == PKLPKMLGFGK.OCGFKMHNEOF_name_for_api;
				});
				KBACNOCOANM_Ranking.Add(e);
				e = KKLGENJKEBN.HHCJCDFCLOB.JPDPFGFMKHK_rankings.Find((EECOJKDJIFG PKLPKMLGFGK) =>
				{
					//0x1847530
					return INJCPCDPGHH.NGHKJOEDLIP_Settings.OGMGLOFKKPA == PKLPKMLGFGK.OCGFKMHNEOF_name_for_api;
				});
				KBACNOCOANM_Ranking.Add(e);
				GPHEKCNDDIK = true;
			}
			DGCOMDILAKM_EventName = INJCPCDPGHH.NGHKJOEDLIP_Settings.OPFGFINHFCE_name;
			DOLJEDAAKNN_RankingName = INJCPCDPGHH.NGHKJOEDLIP_Settings.HEDAGCNPHGD_RankingName;
			GLIMIGNNGGB_RankingStart = INJCPCDPGHH.NGHKJOEDLIP_Settings.BONDDBOFBND_RankingStart;
			DPJCPDKALGI_RankingEnd = INJCPCDPGHH.NGHKJOEDLIP_Settings.HPNOGLIFJOP_RankingEnd;
			LOLAANGCGDO_RankingEnd2 = INJCPCDPGHH.NGHKJOEDLIP_Settings.LNFKGHNHJKE_RankingEnd2;
			JDDFILGNGFH_RewardStart = INJCPCDPGHH.NGHKJOEDLIP_Settings.JGMDAOACOJF_RewardStart;
			LJOHLEGGGMC_RewardEnd = INJCPCDPGHH.NGHKJOEDLIP_Settings.IDDBFFBPNGI_RewardEnd;
			EMEKFFHCHMH_RewardEnd2 = INJCPCDPGHH.NGHKJOEDLIP_Settings.KNLGKBBIBOH_RewardEnd2;
			PGIIDPEGGPI_EventId = INJCPCDPGHH.NGHKJOEDLIP_Settings.OBGBAOLONDD_UniqueId;
			NHGPCLGPEHH_TicketType = INJCPCDPGHH.NGHKJOEDLIP_Settings.MJBKGOJBPAD_item_type;
			FBHONHONKGD_MusicSelectDesc = INJCPCDPGHH.NGHKJOEDLIP_Settings.FEMMDNIELFC_Desc;
			HGLAFGHHFKP = INJCPCDPGHH.NGHKJOEDLIP_Settings.JHPCPNJJHLI_RankingThreshold;
			GFIBLLLHMPD_StartAdventureId = INJCPCDPGHH.NGHKJOEDLIP_Settings.HIOOGLEJBKM_StartAdventureId;
			CAKEOPLJDAF_EndAdventureId = INJCPCDPGHH.NGHKJOEDLIP_Settings.FJCADCDNPMP_EndAdventureId;
			LHAKGDAGEMM_EpBonusInfos.Clear();
			for(int i = 0; i < INJCPCDPGHH.LHAKGDAGEMM_EpBonusInfo.Count; i++)
			{
				CEGDBNNIDIG d = new CEGDBNNIDIG();
				d.KELFCMEOPPM_EpisodeId = INJCPCDPGHH.LHAKGDAGEMM_EpBonusInfo[i].KHPHAAMGMJP_Id;
				d.MIHNKIHNBBL_BaseBonus = INJCPCDPGHH.LHAKGDAGEMM_EpBonusInfo[i].OFIAENKCJME_BaseBonus / 100.0f;
				d.MLLPMJFOKEC_GachaIds.AddRange(INJCPCDPGHH.LHAKGDAGEMM_EpBonusInfo[i].KDNMBOBEGJM_GachaIds);
				LHAKGDAGEMM_EpBonusInfos.Add(d);
			}
			PGDAMNENGDA_EpBonusBySceneRarity.Clear();
			for(int i = 0; i < INJCPCDPGHH.OGMHMAGDNAM_EpBonusBySceneRarity.Count; i++)
			{
				NJJDBBCHBNP d = new NJJDBBCHBNP();
				d.GJEADBKFAPA = INJCPCDPGHH.OGMHMAGDNAM_EpBonusBySceneRarity[i].PPFNGGCBJKC_id;
				d.IJKFFIKGLJM_BonusBefore = INJCPCDPGHH.OGMHMAGDNAM_EpBonusBySceneRarity[i].GNFBMCGMCFO_BonusBefore;
				d.DCBMFNOIENM_BonusAfter = INJCPCDPGHH.OGMHMAGDNAM_EpBonusBySceneRarity[i].BFFGFAMJAIG_BonusAfter;
				PGDAMNENGDA_EpBonusBySceneRarity.Add(d);
			}
			DHOMAEOEFMJ_EpBonuByScene.Clear();
			for(int i = 0; i < INJCPCDPGHH.GEGAEDDGNMA_Bonuses.Count; i++)
			{
				MEBJJBHPMEO d = new MEBJJBHPMEO();
				d.PPFNGGCBJKC_id = INJCPCDPGHH.GEGAEDDGNMA_Bonuses[i].PPFNGGCBJKC_id;
				d.GNFBMCGMCFO_BonusBefore = INJCPCDPGHH.GEGAEDDGNMA_Bonuses[i].GNFBMCGMCFO_BonusBefore;
				d.BFFGFAMJAIG_BonusAfter = INJCPCDPGHH.GEGAEDDGNMA_Bonuses[i].BFFGFAMJAIG_BonusAfter;
				d.CNKFPJCGNFE_SceneId = INJCPCDPGHH.GEGAEDDGNMA_Bonuses[i].CNKFPJCGNFE_SceneId;
				DHOMAEOEFMJ_EpBonuByScene.Add(d);
			}
			MBHDIJJEOFL = INJCPCDPGHH.MBHDIJJEOFL;
			for(int i = 0; i < KPOMHFLKMKI_LastRankUpdateTime.Length; i++)
			{
				KPOMHFLKMKI_LastRankUpdateTime[i] = 0;
			}
			if(!string.IsNullOrEmpty(INJCPCDPGHH.NGHKJOEDLIP_Settings.OMCAOJJGOGG_Lb))
			{
				string[] strs = INJCPCDPGHH.NGHKJOEDLIP_Settings.OMCAOJJGOGG_Lb.Split((new char[] {','}));
				MFDJIFIIPJD d = new MFDJIFIIPJD();
				d.KHEKNNFCAOI_Init(int.Parse(strs[0]), int.Parse(strs[1]));
				BHABCGJCGNO = d;
			}
			PJLNJJIBFBN_HasExtremeDiff = INJCPCDPGHH.NGHKJOEDLIP_Settings.AHKPNPNOAMO_ExtreamOpen != 0;
			MNDFBBMNJGN_IsUsingTicket = INJCPCDPGHH.NGHKJOEDLIP_Settings.MPKNCMEAMLO == 2;
			BHAHKCMJAJE = new List<int>();
			for(int i = 0; i < IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.DHOFNBMPBAG_EventItem.CDENCMNHNGA_table.Count; i++)
			{
				if(IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.DHOFNBMPBAG_EventItem.CDENCMNHNGA_table[i].INDDJNMPONH_type == INJCPCDPGHH.NGHKJOEDLIP_Settings.MJBKGOJBPAD_item_type)
				{
					BHAHKCMJAJE.Add(IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.DHOFNBMPBAG_EventItem.CDENCMNHNGA_table[i].PPFNGGCBJKC_id);
					if(BHAHKCMJAJE.Count == 3)
						break;
				}
			}
			JKIADEKHGLC_TicketItemId = 0;
			if(MNDFBBMNJGN_IsUsingTicket)
			{
				ABBOEIPOBLJ_EventTicket.CBDACMFFHJC ab = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.KHPOJKHKLEM_EventTicket.CDENCMNHNGA_table.Find((ABBOEIPOBLJ_EventTicket.CBDACMFFHJC _GHPLINIACBB_x) =>
				{
					//0x1847590
					return _GHPLINIACBB_x.INDDJNMPONH_type == INJCPCDPGHH.NGHKJOEDLIP_Settings.MJBKGOJBPAD_item_type;
				});
				if(ab != null)
				{
					JKIADEKHGLC_TicketItemId = EKLNMHFCAOI.GJEEGMCBGGM_GetItemFullId(EKLNMHFCAOI.FKGCBLHOOCL_Category.CLMIJKACELE_EventTicket, ab.PPFNGGCBJKC_id);
				}
			}
			LEPALMDKEOK_IsPointReward = true;
		}
	}

	// // RVA: 0x183E158 Offset: 0x183E158 VA: 0x183E158 Slot: 41
	public override int DBOLCELMBJG_GetMainRankingIndex()
	{
		return BAEPGOAMBDK("main_ranking_index", 0);
	}

	// // RVA: 0x183E1CC Offset: 0x183E1CC VA: 0x183E1CC Slot: 42
	public override int DEECKJADNMJ(int LAJNCHHNLBI)
	{
		if(BAEPGOAMBDK("main_ranking_index", 0) != 0)
			return LAJNCHHNLBI == 0 ? 1 : 0;
		return LAJNCHHNLBI;
	}

	// // RVA: 0x183E264 Offset: 0x183E264 VA: 0x183E264 Slot: 43
	protected override void FCHGHAAPIBH()
	{
		PHBACNMCMHG_EventCollection NDFIEMPPMLF_master = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.LBDOLHGDIEB_GetDbSection(JOPOPMLFINI_QuestName) as PHBACNMCMHG_EventCollection;
		if(NDFIEMPPMLF_master != null)
		{
			Dictionary<string,int> DBEKEBNDMBH_SaveIdx = new Dictionary<string,int>();
			List<string> ls = new List<string>(20);
			string str = NDFIEMPPMLF_master.NGHKJOEDLIP_Settings.OCDMGOGMHGE_RewardPrefix;
			for(int i = 0; i < NDFIEMPPMLF_master.FCIPEDFHFEM_TotalRewards.Count; i++)
			{
				for(int j = 0; j < NDFIEMPPMLF_master.FCIPEDFHFEM_TotalRewards[i].AHJNPEAMCCH_rewards.Count; j++)
				{
					if(NDFIEMPPMLF_master.FCIPEDFHFEM_TotalRewards[i].AHJNPEAMCCH_rewards[j].NMKEOMCMIPP_RewardId > 0)
					{
						ls.Add(str + NDFIEMPPMLF_master.FCIPEDFHFEM_TotalRewards[i].AHJNPEAMCCH_rewards[j].NMKEOMCMIPP_RewardId);
						DBEKEBNDMBH_SaveIdx.Add(str + NDFIEMPPMLF_master.FCIPEDFHFEM_TotalRewards[i].AHJNPEAMCCH_rewards[j].NMKEOMCMIPP_RewardId, i);
					}
				}
			}
			if(ls.Count != 0)
			{
				JGMEFHJCNHP_GetAchievementRecords req = NKGJPJPHLIF.HHCJCDFCLOB.IBLPICFDGOF_ServerRequester.IFFNCAFNEAG_AddRequest(new JGMEFHJCNHP_GetAchievementRecords());
				req.KMOBDLBKAAA_Repeatable = true;
				req.MIDAMHNABAJ_Keys = ls;
				req.BHFHGFKBOHH_OnSuccess = (CACGCMBKHDI_Request NHECPMNKEFK) =>
				{
					//0x18475EC
					JGMEFHJCNHP_GetAchievementRecords r = NHECPMNKEFK as JGMEFHJCNHP_GetAchievementRecords;
					FJGNPNFLHPH_EventCollection.JIALCLGJPKL save = CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_PlayerData.MBAHCFLBDHN_EventCollection.FBCJICEPLED[NDFIEMPPMLF_master.NGHKJOEDLIP_Settings.MOEKELIIDEO_SaveIdx];
					for(int i = 0; i < r.NFEAMMJIMPG_Result.CEDLLCCONJP_achievement_prizes.Count; i++)
					{
						if(DBEKEBNDMBH_SaveIdx.ContainsKey(r.NFEAMMJIMPG_Result.CEDLLCCONJP_achievement_prizes[i].LJNAKDMILMC_key))
						{
							if(r.NFEAMMJIMPG_Result.CEDLLCCONJP_achievement_prizes[i].OOIJCMLEAJP_is_received)
							{
								save.LCDIGDMGPGO_TRcv[DBEKEBNDMBH_SaveIdx[r.NFEAMMJIMPG_Result.CEDLLCCONJP_achievement_prizes[i].LJNAKDMILMC_key]] = 1;
							}
						}
					}
					PIMFJALCIGK();
					PLOOEECNHFB_IsDone = true;
				};
				req.MOBEEPPKFLG_OnFail = (CACGCMBKHDI_Request NHECPMNKEFK) =>
				{
					//0x1847AA4
					PLOOEECNHFB_IsDone = true;
					NPNNPNAIONN_IsError = true;
				};
			}
			else
			{
				PIMFJALCIGK();
				PLOOEECNHFB_IsDone = true;
			}
			return;
		}
		PLOOEECNHFB_IsDone = true;
	}

	// [IteratorStateMachineAttribute] // RVA: 0x6BC3F4 Offset: 0x6BC3F4 VA: 0x6BC3F4
	// // RVA: 0x183E950 Offset: 0x183E950 VA: 0x183E950 Slot: 44
	protected override IEnumerator JEIJKLPOAHP_ReceivePrologueRepeatedAchievement(DJBHIFLHJLK _AOCANKOMKFG_OnError)
	{
		//0x184A460
		KGBCKPKLKHM_RewardItems.Clear();
		PHBACNMCMHG_EventCollection ev = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.LBDOLHGDIEB_GetDbSection(JOPOPMLFINI_QuestName) as PHBACNMCMHG_EventCollection;
		if(ev != null)
		{
			string event_prologue_achv_key = ev.EFEGBHACJAL_GetStringParam("event_prologue_achv_key", "");
			if(!string.IsNullOrEmpty(event_prologue_achv_key))
			{
				List<string> ls = new List<string>();
				ls.Add(event_prologue_achv_key);
				yield return Co.R(AOGIMHOLIFB_ReceiveLoguinRepetedAchivement(ls, _AOCANKOMKFG_OnError));
			}
		}
	}

	// [IteratorStateMachineAttribute] // RVA: 0x6BC46C Offset: 0x6BC46C VA: 0x6BC46C
	// // RVA: 0x183EA18 Offset: 0x183EA18 VA: 0x183EA18 Slot: 45
	protected override IEnumerator KPBNMAEHHDF_ReceiveEpilogueRepeatedAchivement(DJBHIFLHJLK _AOCANKOMKFG_OnError)
	{
		//0x184A130
		KGBCKPKLKHM_RewardItems.Clear();
		PHBACNMCMHG_EventCollection ev = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.LBDOLHGDIEB_GetDbSection(JOPOPMLFINI_QuestName) as PHBACNMCMHG_EventCollection;
		if(ev != null)
		{
			string event_epilogue_achv_key = ev.EFEGBHACJAL_GetStringParam("event_epilogue_achv_key", "");
			if(!string.IsNullOrEmpty(event_epilogue_achv_key))
			{
				List<string> ls = new List<string>();
				ls.Add(event_epilogue_achv_key);
				yield return Co.R(AOGIMHOLIFB_ReceiveLoguinRepetedAchivement(ls, _AOCANKOMKFG_OnError));
			}
		}
	}

	// // RVA: 0x183EAE0 Offset: 0x183EAE0 VA: 0x183EAE0 Slot: 46
	protected override void PJDGDNJNCNM_UpdateStatusImpl(long _JHNMKKNEENE_Time)
	{
		KIBBLLADDPO = false;
		PHBACNMCMHG_EventCollection ev = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.LBDOLHGDIEB_GetDbSection(JOPOPMLFINI_QuestName) as PHBACNMCMHG_EventCollection;
		if(ev != null)
		{
			FJGNPNFLHPH_EventCollection.JIALCLGJPKL save = CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_PlayerData.MBAHCFLBDHN_EventCollection.FBCJICEPLED[ev.NGHKJOEDLIP_Settings.MOEKELIIDEO_SaveIdx];
			IBLPKJJNNIG = false;
			BELBNINIOIE = false;
			if(_JHNMKKNEENE_Time >= GLIMIGNNGGB_RankingStart)
			{
				if(DPJCPDKALGI_RankingEnd >= _JHNMKKNEENE_Time)
				{
					if(MBHDIJJEOFL != null)
					{
						for(int i = 0; i < MBHDIJJEOFL.Count; i++)
						{
							if(MBHDIJJEOFL[i].MAFAIIHJAFG_spurt == 0)
							{
								IBLPKJJNNIG = true;
								break;
							}
						}
					}
					//LAB_0183ee48
					if(!save.IMFBCJOIJKJ_Entry)
					{
						NGOFCFJHOMI_Status = KGCNCBOKCBA.GNENJEHKMHD_EventStatus.NCJFJLPJMLI_2;
						if(_JHNMKKNEENE_Time < ev.NGHKJOEDLIP_Settings.EHHFFKAFOMC)
							return;
						KIBBLLADDPO = true;
						if(MBHDIJJEOFL != null)
						{
							for(int i = 0; i < MBHDIJJEOFL.Count; i++)
							{
								if(MBHDIJJEOFL[i].MAFAIIHJAFG_spurt == 1)
								{
									BELBNINIOIE = true;
									break;
								}
							}
						}
						return;
					}
					else if(!save.ABBJBPLHFHA_Spurt)
					{
						if(_JHNMKKNEENE_Time < ev.NGHKJOEDLIP_Settings.EHHFFKAFOMC)
						{
							NGOFCFJHOMI_Status = KGCNCBOKCBA.GNENJEHKMHD_EventStatus.MINDIGBAJFG_3;
							return;
						}
						NGOFCFJHOMI_Status = KGCNCBOKCBA.GNENJEHKMHD_EventStatus.GDOPLACICFE_4;
						KIBBLLADDPO = true;
						if(MBHDIJJEOFL != null)
						{
							for(int i = 0; i < MBHDIJJEOFL.Count; i++)
							{
								if(MBHDIJJEOFL[i].MAFAIIHJAFG_spurt == 1)
								{
									BELBNINIOIE = true;
									break;
								}
							}
						}
						return;
					}
					else
					{
						NGOFCFJHOMI_Status = KGCNCBOKCBA.GNENJEHKMHD_EventStatus.MEAJLPAHINL_ChallengePeriod_5;
						if(MBHDIJJEOFL != null)
						{
							for(int i = 0; i < MBHDIJJEOFL.Count; i++)
							{
								if(MBHDIJJEOFL[i].MAFAIIHJAFG_spurt == 1)
								{
									BELBNINIOIE = true;
									break;
								}
							}
						}
						return;
					}
				}
				if(_JHNMKKNEENE_Time >= ev.NGHKJOEDLIP_Settings.JGMDAOACOJF_RewardStart)
				{
					if(_JHNMKKNEENE_Time >= ev.NGHKJOEDLIP_Settings.IDDBFFBPNGI_RewardEnd)
					{
						if(_JHNMKKNEENE_Time >= ev.NGHKJOEDLIP_Settings.KNLGKBBIBOH_RewardEnd2)
						{
							NGOFCFJHOMI_Status = KGCNCBOKCBA.GNENJEHKMHD_EventStatus.DOAENCHBAEO_11;
						}
						else
						{
							NGOFCFJHOMI_Status = KGCNCBOKCBA.GNENJEHKMHD_EventStatus.HINPDNKNAHO_10;
						}
					}
					else
					{
						if(save.HPLMECLKFID_RRcv)
						{
							if(save.CIIBINABMPE_RRcv2)
							{
								NGOFCFJHOMI_Status = KGCNCBOKCBA.GNENJEHKMHD_EventStatus.BCKENOKGLIJ_9_ResultRewardreceived;
							}
						}
						else
						{
							NGOFCFJHOMI_Status = KGCNCBOKCBA.GNENJEHKMHD_EventStatus.DDEODFNANDO_8_ResultRewardToReceive;
						}
					}
				}
				else
				{
					NGOFCFJHOMI_Status = KGCNCBOKCBA.GNENJEHKMHD_EventStatus.EMAMLLFAOJI_Counting_6;
				}
			}
			else
			{
				NGOFCFJHOMI_Status = KGCNCBOKCBA.GNENJEHKMHD_EventStatus.FFLKPBPBPEP_1;
			}
			return;
		}
		NGOFCFJHOMI_Status = KGCNCBOKCBA.GNENJEHKMHD_EventStatus.HJNNKCMLGFL_0_None;
	}

	// // RVA: 0x183F154 Offset: 0x183F154 VA: 0x183F154 Slot: 47
	public override void NBMDAOFPKGK(int _DNBFMLBNAEE_point)
	{
		PHBACNMCMHG_EventCollection ev = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.LBDOLHGDIEB_GetDbSection(JOPOPMLFINI_QuestName) as PHBACNMCMHG_EventCollection;
		if(ev != null)
		{
			FJGNPNFLHPH_EventCollection.JIALCLGJPKL save = CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_PlayerData.MBAHCFLBDHN_EventCollection.FBCJICEPLED[ev.NGHKJOEDLIP_Settings.MOEKELIIDEO_SaveIdx];
			save.DNBFMLBNAEE_point += _DNBFMLBNAEE_point;
			save.NFIOKIBPJCJ_uptime = NKGJPJPHLIF.HHCJCDFCLOB.IBLPICFDGOF_ServerRequester.FJDBNGEPKHL_Time.KMEFBNBFJHI_GetServerTime();
		}
	}

	// // RVA: 0x183F4A4 Offset: 0x183F4A4 VA: 0x183F4A4
	public void DDIDDLEIIPM(int _KNIFCANOHOC_score)
	{
		PHBACNMCMHG_EventCollection ev = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.LBDOLHGDIEB_GetDbSection(JOPOPMLFINI_QuestName) as PHBACNMCMHG_EventCollection;
		if(ev != null)
		{
			FJGNPNFLHPH_EventCollection.JIALCLGJPKL save = CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_PlayerData.MBAHCFLBDHN_EventCollection.FBCJICEPLED[ev.NGHKJOEDLIP_Settings.MOEKELIIDEO_SaveIdx];
			if(save.KNIFCANOHOC_score < _KNIFCANOHOC_score)
			{
				save.KNIFCANOHOC_score = _KNIFCANOHOC_score;
				save.NFIOKIBPJCJ_uptime = NKGJPJPHLIF.HHCJCDFCLOB.IBLPICFDGOF_ServerRequester.FJDBNGEPKHL_Time.KMEFBNBFJHI_GetServerTime();
			}
		}
	}

	// // RVA: 0x183F7E8 Offset: 0x183F7E8 VA: 0x183F7E8 Slot: 48
	public override void AMKJFGLEJGE_RequestUpdateEventPoint(int KPIILHGOGJD)
	{
		EECOJKDJIFG e = DAKMIKNKHMF_GetRankingInfoForIndex(KPIILHGOGJD);
		if(e != null)
		{
			PHBACNMCMHG_EventCollection ev = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.LBDOLHGDIEB_GetDbSection(JOPOPMLFINI_QuestName) as PHBACNMCMHG_EventCollection;
			if(ev != null)
			{
				FJGNPNFLHPH_EventCollection.JIALCLGJPKL save = CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_PlayerData.MBAHCFLBDHN_EventCollection.FBCJICEPLED[ev.NGHKJOEDLIP_Settings.MOEKELIIDEO_SaveIdx];
				PJDGDNJNCNM_UpdateStatusImpl(NKGJPJPHLIF.HHCJCDFCLOB.IBLPICFDGOF_ServerRequester.FJDBNGEPKHL_Time.KMEFBNBFJHI_GetServerTime());
				if(NGOFCFJHOMI_Status == KGCNCBOKCBA.GNENJEHKMHD_EventStatus.NCJFJLPJMLI_2 ||
					NGOFCFJHOMI_Status == KGCNCBOKCBA.GNENJEHKMHD_EventStatus.MINDIGBAJFG_3 ||
					NGOFCFJHOMI_Status == KGCNCBOKCBA.GNENJEHKMHD_EventStatus.MEAJLPAHINL_ChallengePeriod_5 ||
					NGOFCFJHOMI_Status == KGCNCBOKCBA.GNENJEHKMHD_EventStatus.EMAMLLFAOJI_Counting_6) //0x6cU
				{
					long val = 0;
					if(KPIILHGOGJD == 1)
					{
						if(save.KNIFCANOHOC_score == 0)
						{
							PLOOEECNHFB_IsDone = true;
							return;
						}
						val = save.KNIFCANOHOC_score;
					}
					else if(KPIILHGOGJD == 0)
					{
						val = save.DNBFMLBNAEE_point;
					}
					BOAGCEOHJEO.GOAOBNBGDBJ(GLIMIGNNGGB_RankingStart, LOLAANGCGDO_RankingEnd2, save.NFIOKIBPJCJ_uptime, val);
					EECOJKDJIFG e2 = KKLGENJKEBN.HHCJCDFCLOB.JPDPFGFMKHK_rankings.Find((EECOJKDJIFG _GHPLINIACBB_x) =>
					{
						//0x1847AE8
						return e.OCGFKMHNEOF_name_for_api == _GHPLINIACBB_x.OCGFKMHNEOF_name_for_api;
					});
					if(e2 != null)
					{
						PKECIDPBEFL.DDBKLMKKCDL d = new PKECIDPBEFL.DDBKLMKKCDL();
						d.OACABIDEMGG_Score = BOAGCEOHJEO.GOAOBNBGDBJ(GLIMIGNNGGB_RankingStart, LOLAANGCGDO_RankingEnd2, save.NFIOKIBPJCJ_uptime, val);
						d.BLJIJENHBPM_Id = e2.PPFNGGCBJKC_id;
						d.OBGBAOLONDD_UniqueId = PGIIDPEGGPI_EventId;
						d.NOBCHBHEPNC_Idx = KPIILHGOGJD;
						JGEOBNENMAH.HHCJCDFCLOB.CBGMOGIBALL.Add(d);
						return;
					}
				}
			}
		}
	}

	// // RVA: 0x183FE80 Offset: 0x183FE80 VA: 0x183FE80 Slot: 49
	protected override void ODPJGHOJIOH(int LHJCOPMMIGO)
	{
		PLOOEECNHFB_IsDone = false;
		EECOJKDJIFG e = DAKMIKNKHMF_GetRankingInfoForIndex(LHJCOPMMIGO);
		if(e != null)
		{
			PHBACNMCMHG_EventCollection INJCPCDPGHH = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.LBDOLHGDIEB_GetDbSection(JOPOPMLFINI_QuestName) as PHBACNMCMHG_EventCollection;
			if(INJCPCDPGHH != null)
			{
				FJGNPNFLHPH_EventCollection.JIALCLGJPKL NHLBKJCPLBL = CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_PlayerData.MBAHCFLBDHN_EventCollection.FBCJICEPLED[INJCPCDPGHH.NGHKJOEDLIP_Settings.MOEKELIIDEO_SaveIdx];
				PJDGDNJNCNM_UpdateStatusImpl(NKGJPJPHLIF.HHCJCDFCLOB.IBLPICFDGOF_ServerRequester.FJDBNGEPKHL_Time.KMEFBNBFJHI_GetServerTime());
				if(NGOFCFJHOMI_Status == KGCNCBOKCBA.GNENJEHKMHD_EventStatus.NCJFJLPJMLI_2 ||
					NGOFCFJHOMI_Status == KGCNCBOKCBA.GNENJEHKMHD_EventStatus.MINDIGBAJFG_3 ||
					NGOFCFJHOMI_Status == KGCNCBOKCBA.GNENJEHKMHD_EventStatus.MEAJLPAHINL_ChallengePeriod_5 ||
					NGOFCFJHOMI_Status == KGCNCBOKCBA.GNENJEHKMHD_EventStatus.EMAMLLFAOJI_Counting_6) //0x6cU
				{
					long val = 0;
					if(LHJCOPMMIGO == 1)
					{
						if(NHLBKJCPLBL.KNIFCANOHOC_score == 0)
						{
							PLOOEECNHFB_IsDone = true;
							return;
						}
						val = NHLBKJCPLBL.KNIFCANOHOC_score;
					}
					else if(LHJCOPMMIGO == 0)
					{
						val = NHLBKJCPLBL.DNBFMLBNAEE_point;
					}
					KKLGENJKEBN.HHCJCDFCLOB.LDOBHAAIDEJ_UpdateRankingScore(e.OCGFKMHNEOF_name_for_api, LHJCOPMMIGO, BOAGCEOHJEO.GOAOBNBGDBJ(GLIMIGNNGGB_RankingStart, LOLAANGCGDO_RankingEnd2, NHLBKJCPLBL.NFIOKIBPJCJ_uptime, val), () =>
					{
						//0x1847B34
						CDINKAANIAA_Rank[LHJCOPMMIGO] = (int)KKLGENJKEBN.HHCJCDFCLOB.LPPCNCMEDFA_Rank;
						PLOOEECNHFB_IsDone = true;
						int ranking_point_max = INJCPCDPGHH.LPJLEHAJADA_GetIntParam("ranking_point_max", 1000000);
						if(LHJCOPMMIGO == 1)
						{
							ILCCJNDFFOB.HHCJCDFCLOB.NNFGBBCHLPC(PGIIDPEGGPI_EventId, "StringLiteral_10992", EJDJIBPKKNO_BasePoint, NHLBKJCPLBL.KNIFCANOHOC_score, ranking_point_max, KKLGENJKEBN.HHCJCDFCLOB.DFBALJAPHMC_DroppedPlayer);
						}
						else if(LHJCOPMMIGO == 0)
						{
							ILCCJNDFFOB.HHCJCDFCLOB.NNFGBBCHLPC(PGIIDPEGGPI_EventId, "StringLiteral_10929", EJDJIBPKKNO_BasePoint, NHLBKJCPLBL.DNBFMLBNAEE_point, ranking_point_max, KKLGENJKEBN.HHCJCDFCLOB.DFBALJAPHMC_DroppedPlayer);
						}
					}, () =>
					{
						//0x1847E54
						PLOOEECNHFB_IsDone = true;
					}, () =>
					{
						//0x1847E7C
						PLOOEECNHFB_IsDone = true;
						NPNNPNAIONN_IsError = true;
					});
					return;
				}
			}
		}
		PLOOEECNHFB_IsDone = true;
	}

	// // RVA: 0x18404A0 Offset: 0x18404A0 VA: 0x18404A0 Slot: 50
	protected override void MFJFBNPLFBE_OnReceieveTotalReward(bool GIPBIDFJFLL)
	{
		PHBACNMCMHG_EventCollection ev = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.LBDOLHGDIEB_GetDbSection(JOPOPMLFINI_QuestName) as PHBACNMCMHG_EventCollection;
		if(ev != null)
		{
			if(CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_PlayerData.MBAHCFLBDHN_EventCollection.PFAKPFKJJKA() == null)
			{
				FJGNPNFLHPH_EventCollection.JIALCLGJPKL save = CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_PlayerData.MBAHCFLBDHN_EventCollection.FBCJICEPLED[ev.NGHKJOEDLIP_Settings.MOEKELIIDEO_SaveIdx];
				long pt = FBGDBGKNKOD_GetCurrentPoint();
				JANMJPOKLFL_InventoryUtil.JCHLONCMPAJ();
				JOFBHHHLBBN_Rewards.Clear();
				List<string> ls = new List<string>(3);
				List<int> li = new List<int>(3);
				StringBuilder str = new StringBuilder();
				for(int i = 0; i < ev.FCIPEDFHFEM_TotalRewards.Count; i++)
				{
					if(pt >= ev.FCIPEDFHFEM_TotalRewards[i].DNBFMLBNAEE_point)
					{
						if(!save.BHIAKGKHKGD(i))
						{
							str.Length = 0;
							str.Append(PGIIDPEGGPI_EventId);
							str.Append(':');
							str.Append(i);
							str.Append(':');
							str.Append(ev.FCIPEDFHFEM_TotalRewards[i].DNBFMLBNAEE_point);
							JANMJPOKLFL_InventoryUtil.FEGDNPIEKJC(OAGBCBBHMPF.COIIJOEKBDH.MGEFPKOJKBL_9, str.ToString());
							for(int j = 0; j < ev.FCIPEDFHFEM_TotalRewards[i].AHJNPEAMCCH_rewards.Count; j++)
							{
								if(ev.FCIPEDFHFEM_TotalRewards[i].AHJNPEAMCCH_rewards[j].NMKEOMCMIPP_RewardId > 0)
								{
									ls.Add(ev.NGHKJOEDLIP_Settings.OCDMGOGMHGE_RewardPrefix + ev.FCIPEDFHFEM_TotalRewards[i].AHJNPEAMCCH_rewards[j].NMKEOMCMIPP_RewardId);
									li.Add(!ev.FCIPEDFHFEM_TotalRewards[i].AHJNPEAMCCH_rewards[j].PJPDOCNJNGJ_IsLimited ? -1 : (int)ev.NGHKJOEDLIP_Settings.JBFDHOIKAIK_InventoryEndDate);
								}
								JANMJPOKLFL_InventoryUtil.CPIICACGNBH_AddItem(CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_PlayerData, ev.FCIPEDFHFEM_TotalRewards[i].AHJNPEAMCCH_rewards[j].GLCLFMGPMAN_ItemId, ev.FCIPEDFHFEM_TotalRewards[i].AHJNPEAMCCH_rewards[j].HMFFHLPNMPH_count, null, 0);
								save.IPNLHCLFIDB(i, true);
							}
							JOFBHHHLBBN_Rewards.Add(i);
						}
					}
				}
				if(ls.Count > 0)
				{
					if(!GIPBIDFJFLL)
					{
						FLONELKGABJ_ClaimAchievementPrizes req = NKGJPJPHLIF.HHCJCDFCLOB.IBLPICFDGOF_ServerRequester.IFFNCAFNEAG_AddRequest(new FLONELKGABJ_ClaimAchievementPrizes());
						req.KMOBDLBKAAA_Repeatable = true;
						req.MIDAMHNABAJ_Keys = ls;
						req.NBFDEFGFLPJ = OHJOJKNLHOK;
						req.MEGNAIJPBFF_InventoryClosedAt = li;
						req.BHFHGFKBOHH_OnSuccess = (CACGCMBKHDI_Request NHECPMNKEFK) =>
						{
							//0x1846F08
							PLOOEECNHFB_IsDone = true;
							DENHAAGACPD(0);
						};
						req.MOBEEPPKFLG_OnFail = (CACGCMBKHDI_Request NHECPMNKEFK) =>
						{
							//0x1846F18
							if(NHECPMNKEFK.CJMFJOMECKI_ErrorId == SakashoErrorId.ACHIEVEMENT_PRIZE_ALREADY_RECEIVED)
							{
								DENHAAGACPD(0);
								PLOOEECNHFB_IsDone = true;
							}
							else
							{
								PLOOEECNHFB_IsDone = true;
								NPNNPNAIONN_IsError = true;
							}
						};
						return;
					}
					PMHLJAIGBGK = ls;
					FMEDFGOMNBK = li;
				}
				DENHAAGACPD(0);
			}
			else
			{
				NPNNPNAIONN_IsError = true;
			}
		}
		PLOOEECNHFB_IsDone = true;
	}

	// // RVA: 0x1841490 Offset: 0x1841490 VA: 0x1841490 Slot: 52
	public override void FAMFKPBPIAA_GetRankingPlayerList(bool PFFJNEFNAMI, int _CJHEHIMLGGL_Position, int LHJCOPMMIGO, LIOLBKLMMIK _KLMFJJCNBIP_OnSuccess, DJBHIFLHJLK _IDAEHNGOKAE_OnRankingError, DJBHIFLHJLK _JGKOLBLPMPG_OnFail)
	{
		NPNNPNAIONN_IsError = false;
		PLOOEECNHFB_IsDone = false;
		PHBACNMCMHG_EventCollection ev = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.LBDOLHGDIEB_GetDbSection(JOPOPMLFINI_QuestName) as PHBACNMCMHG_EventCollection;
		if(ev != null)
		{
			EECOJKDJIFG e = DAKMIKNKHMF_GetRankingInfoForIndex(LHJCOPMMIGO);
			if(e != null)
			{
				KKLGENJKEBN.HHCJCDFCLOB.FAMFKPBPIAA_GetRankingPlayerList(e.OCGFKMHNEOF_name_for_api, PFFJNEFNAMI, _CJHEHIMLGGL_Position, LHJCOPMMIGO, (int NEFEFHBHFFF, List<IBIGBMDANNM> MAGKKPOFJIM) =>
				{
					//0x1847EC0
					PLOOEECNHFB_IsDone = true;
					_KLMFJJCNBIP_OnSuccess(NEFEFHBHFFF, MAGKKPOFJIM);
				}, () =>
				{
					//0x1847F1C
					PLOOEECNHFB_IsDone = true;
					_IDAEHNGOKAE_OnRankingError();
				}, () =>
				{
					//0x1847F68
					PLOOEECNHFB_IsDone = true;
					NPNNPNAIONN_IsError = true;
					_JGKOLBLPMPG_OnFail();
				}, false);
				return;
			}
		}
		_IDAEHNGOKAE_OnRankingError();
		PLOOEECNHFB_IsDone = true;
	}

	// // RVA: 0x18417C8 Offset: 0x18417C8 VA: 0x18417C8 Slot: 53
	public override void JPNACOLKHLB_AddRankingPlayerListSecond(int _CJHEHIMLGGL_Position, int NEFEFHBHFFF, LIOLBKLMMIK _KLMFJJCNBIP_OnSuccess, DJBHIFLHJLK _IDAEHNGOKAE_OnRankingError, DJBHIFLHJLK _JGKOLBLPMPG_OnFail)
	{
		KKLGENJKEBN.HHCJCDFCLOB.JPNACOLKHLB_AddRankingPlayerListSecond(_CJHEHIMLGGL_Position, NEFEFHBHFFF, (int _JGNBPFCJLKI_d, List<IBIGBMDANNM> MAGKKPOFJIM) =>
		{
			//0x1847FCC
			PLOOEECNHFB_IsDone = true;
			_KLMFJJCNBIP_OnSuccess(_JGNBPFCJLKI_d, MAGKKPOFJIM);
		}, () =>
		{
			//0x1848028
			PLOOEECNHFB_IsDone = true;
			_IDAEHNGOKAE_OnRankingError();
		}, () =>
		{
			//0x1848074
			PLOOEECNHFB_IsDone = true;
			NPNNPNAIONN_IsError = true;
			_JGKOLBLPMPG_OnFail();
		}, false);
	}

	// // RVA: 0x1841984 Offset: 0x1841984 VA: 0x1841984
	private int APJDIPINLLK(List<int> HNLFPKNBOHE, int _PPFNGGCBJKC_id)
	{
		for(int i = 0; i < HNLFPKNBOHE.Count; i+= 2)
		{
			if(HNLFPKNBOHE[i] == _PPFNGGCBJKC_id)
				return HNLFPKNBOHE[i + 1];
		}
		return _PPFNGGCBJKC_id;
	}

	// // RVA: 0x1841A7C Offset: 0x1841A7C VA: 0x1841A7C Slot: 34
	public override int JDFHIHPPAHN_UpdateDropItemSet(int NHIJBNLJGDJ, OHCAABOMEOF.KGOGMKMBCPP_EventType _INDDJNMPONH_type)
	{
		if(_INDDJNMPONH_type == OHCAABOMEOF.KGOGMKMBCPP_EventType.AOPKACCDKPA_EventCollection)
		{
			PHBACNMCMHG_EventCollection ev = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.LBDOLHGDIEB_GetDbSection(JOPOPMLFINI_QuestName) as PHBACNMCMHG_EventCollection;
			if(ev != null)
			{
				return APJDIPINLLK(ev.NGHKJOEDLIP_Settings.BJHHDGCOACI, NHIJBNLJGDJ);
			}
		}
		return NHIJBNLJGDJ;
	}

	// // RVA: 0x1841C14 Offset: 0x1841C14 VA: 0x1841C14 Slot: 35
	public override int NCHKBINKKBH_UpdateDropRateSet(int _BFOLFCOBBJD_RateId, OHCAABOMEOF.KGOGMKMBCPP_EventType _INDDJNMPONH_type)
	{
		if(_INDDJNMPONH_type == OHCAABOMEOF.KGOGMKMBCPP_EventType.AOPKACCDKPA_EventCollection)
		{
			PHBACNMCMHG_EventCollection ev = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.LBDOLHGDIEB_GetDbSection(JOPOPMLFINI_QuestName) as PHBACNMCMHG_EventCollection;
			if(ev != null)
			{
				return APJDIPINLLK(ev.NGHKJOEDLIP_Settings.JDDIOIMOFDE, _BFOLFCOBBJD_RateId);
			}
		}
		return _BFOLFCOBBJD_RateId;
	}

	// // RVA: 0x1841DAC Offset: 0x1841DAC VA: 0x1841DAC Slot: 36
	public override int EEMGDCPJNEG(int JEAHDIOLGEL, OHCAABOMEOF.KGOGMKMBCPP_EventType _INDDJNMPONH_type)
	{
		if(_INDDJNMPONH_type == OHCAABOMEOF.KGOGMKMBCPP_EventType.HJNNKCMLGFL_0_None)
		{
			PHBACNMCMHG_EventCollection ev = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.LBDOLHGDIEB_GetDbSection(JOPOPMLFINI_QuestName) as PHBACNMCMHG_EventCollection;
			if(ev != null)
			{
				return APJDIPINLLK(ev.NGHKJOEDLIP_Settings.HKEAFPNNAPC, JEAHDIOLGEL);
			}
		}
		return JEAHDIOLGEL;
	}

	// // RVA: 0x1841F44 Offset: 0x1841F44 VA: 0x1841F44 Slot: 37
	public override int DJHOMGLGAHA(int PLLAIBDLKHB, OHCAABOMEOF.KGOGMKMBCPP_EventType _INDDJNMPONH_type)
	{
		if(_INDDJNMPONH_type == OHCAABOMEOF.KGOGMKMBCPP_EventType.HJNNKCMLGFL_0_None)
		{
			PHBACNMCMHG_EventCollection ev = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.LBDOLHGDIEB_GetDbSection(JOPOPMLFINI_QuestName) as PHBACNMCMHG_EventCollection;
			if(ev != null)
			{
				return APJDIPINLLK(ev.NGHKJOEDLIP_Settings.MCDPPHKEMJI, PLLAIBDLKHB);
			}
		}
		return PLLAIBDLKHB;
	}

	// // RVA: 0x183E900 Offset: 0x183E900 VA: 0x183E900
	private void PIMFJALCIGK()
	{
		int a = NGIHFKHOJOK_GetRankingMax(true);
		for(int i = 0; i < a; i++)
		{
			BJEOAOACMGG(i);
		}
	}

	// // RVA: 0x18420DC Offset: 0x18420DC VA: 0x18420DC
	private void BJEOAOACMGG(int LHJCOPMMIGO)
	{
		EECOJKDJIFG e = DAKMIKNKHMF_GetRankingInfoForIndex(LHJCOPMMIGO);
		if(e != null)
		{
			PHBACNMCMHG_EventCollection ev = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.LBDOLHGDIEB_GetDbSection(JOPOPMLFINI_QuestName) as PHBACNMCMHG_EventCollection;
			if(ev != null)
			{
				FJGNPNFLHPH_EventCollection.JIALCLGJPKL save = CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_PlayerData.MBAHCFLBDHN_EventCollection.FBCJICEPLED[ev.NGHKJOEDLIP_Settings.MOEKELIIDEO_SaveIdx];
				PFPJHJJAGAG_Rewards.Clear();
				EGIPGHCDMII_RankData[LHJCOPMMIGO].Clear();
				for(int i = 0; i < e.AHJNPEAMCCH_rewards.Count; i++)
				{
					MAOCCKFAOPC d = new MAOCCKFAOPC();
					d.JBDGBPAAAEF_HighRank = e.AHJNPEAMCCH_rewards[i].JPHDGGNAKMO_high_rank;
					d.GHANKNIBALB_LowRank = e.AHJNPEAMCCH_rewards[i].FGCAJEAIABA_low_rank;
					d.MJGAMDBOMHD_InventoryMessage = e.AHJNPEAMCCH_rewards[i].IPFEKNMBEBI_inventory_message;
					d.HBHMAKNGKFK_items = e.AHJNPEAMCCH_rewards[i].HBHMAKNGKFK_items;
					EGIPGHCDMII_RankData[LHJCOPMMIGO].Add(d);
				}
				for(int i = 0; i < ev.FCIPEDFHFEM_TotalRewards.Count; i++)
				{
					IHAEIOAKEMG d = new IHAEIOAKEMG();
					for(int j = 0; j < ev.FCIPEDFHFEM_TotalRewards[i].AHJNPEAMCCH_rewards.Count; j++)
					{
						MFDJIFIIPJD d2 = new MFDJIFIIPJD();
						d2.KHEKNNFCAOI_Init(ev.FCIPEDFHFEM_TotalRewards[i].AHJNPEAMCCH_rewards[j].GLCLFMGPMAN_ItemId, ev.FCIPEDFHFEM_TotalRewards[i].AHJNPEAMCCH_rewards[j].HMFFHLPNMPH_count);
						d2.JOPPFEHKNFO_Pickup = ev.FCIPEDFHFEM_TotalRewards[i].AHJNPEAMCCH_rewards[j].JOPPFEHKNFO_Pickup;
						d.HBHMAKNGKFK_items.Add(d2);
					}
					d.HMEOAKCLKJE_IsReceived = save.BHIAKGKHKGD(i);
					d.FIOIKMOIJGK_Point = ev.FCIPEDFHFEM_TotalRewards[i].DNBFMLBNAEE_point;
					d.OJELCGDDAOM_MissingPoint = (int)(d.FIOIKMOIJGK_Point - save.DNBFMLBNAEE_point);
					PFPJHJJAGAG_Rewards.Add(d);
				}
			}
		}
	}

	// // RVA: 0x1841140 Offset: 0x1841140 VA: 0x1841140
	private void DENHAAGACPD(int LHJCOPMMIGO)
	{
		EECOJKDJIFG e = DAKMIKNKHMF_GetRankingInfoForIndex(LHJCOPMMIGO);
		if(e != null)
		{
			PHBACNMCMHG_EventCollection ev = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.LBDOLHGDIEB_GetDbSection(JOPOPMLFINI_QuestName) as PHBACNMCMHG_EventCollection;
			if(ev != null)
			{
                FJGNPNFLHPH_EventCollection.JIALCLGJPKL save = CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_PlayerData.MBAHCFLBDHN_EventCollection.FBCJICEPLED[ev.NGHKJOEDLIP_Settings.MOEKELIIDEO_SaveIdx];
				for(int i = 0; i < PFPJHJJAGAG_Rewards.Count; i++)
				{
					PFPJHJJAGAG_Rewards[i].HMEOAKCLKJE_IsReceived = save.BHIAKGKHKGD(i);
					PFPJHJJAGAG_Rewards[i].OJELCGDDAOM_MissingPoint = PFPJHJJAGAG_Rewards[i].FIOIKMOIJGK_Point - (int)save.DNBFMLBNAEE_point;
					if(PFPJHJJAGAG_Rewards[i].OJELCGDDAOM_MissingPoint < 0)
						PFPJHJJAGAG_Rewards[i].OJELCGDDAOM_MissingPoint = 0;
				}
			}
		}
	}

	// // RVA: 0x1842978 Offset: 0x1842978 VA: 0x1842978 Slot: 51
	public override IHAEIOAKEMG ILICNKILFKJ_GetNextReward()
	{
		for(int i = 0; i < PFPJHJJAGAG_Rewards.Count; i++)
		{
			if(!PFPJHJJAGAG_Rewards[i].HMEOAKCLKJE_IsReceived)
			{
				return PFPJHJJAGAG_Rewards[i];
			}
		}
		return null;
	}

	// // RVA: 0x1842A8C Offset: 0x1842A8C VA: 0x1842A8C Slot: 12
	public override int EAMODCHMCEL_GetTicketCost(int _AKNELONELJK_difficulty, bool _GIKLNODJKFK_IsLine6)
	{
		PHBACNMCMHG_EventCollection ev = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.LBDOLHGDIEB_GetDbSection(JOPOPMLFINI_QuestName) as PHBACNMCMHG_EventCollection;
		if(ev != null)
		{
			return ev.NGHKJOEDLIP_Settings.KIGCDOJGJEP(_AKNELONELJK_difficulty, _GIKLNODJKFK_IsLine6);
		}
		return 0;
	}

	// // RVA: 0x1842C24 Offset: 0x1842C24 VA: 0x1842C24 Slot: 13
	public override bool NLFIGGNLEFP(int _AKNELONELJK_difficulty, bool _GIKLNODJKFK_IsLine6, int LCCGDFGGIHI)
	{
		PHBACNMCMHG_EventCollection ev = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.LBDOLHGDIEB_GetDbSection(JOPOPMLFINI_QuestName) as PHBACNMCMHG_EventCollection;
		if(ev != null)
		{
			ABBOEIPOBLJ_EventTicket.CBDACMFFHJC tkt = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.KHPOJKHKLEM_EventTicket.CDENCMNHNGA_table.Find((ABBOEIPOBLJ_EventTicket.CBDACMFFHJC _GHPLINIACBB_x) =>
			{
				//0x18480D8
				return _GHPLINIACBB_x.INDDJNMPONH_type == ev.NGHKJOEDLIP_Settings.MJBKGOJBPAD_item_type;
			});
			if(tkt != null)
			{
                FJGNPNFLHPH_EventCollection.JIALCLGJPKL save = CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_PlayerData.MBAHCFLBDHN_EventCollection.FBCJICEPLED[ev.NGHKJOEDLIP_Settings.MOEKELIIDEO_SaveIdx];
				int cnt = ev.NGHKJOEDLIP_Settings.KIGCDOJGJEP(_AKNELONELJK_difficulty, _GIKLNODJKFK_IsLine6) * LCCGDFGGIHI * HADLPHIMBHH_BoostRatio;
				//UnityEngine.Debug.LogError(cnt+" "+ev.NGHKJOEDLIP.KIGCDOJGJEP(_AKNELONELJK_difficulty, GIKLNODJKFK_IsLine6)+" "+LCCGDFGGIHI+" "+HADLPHIMBHH_BoostRatio+" "+save.KCGJGPOFOCD_ticket);
				if(cnt - save.KCGJGPOFOCD_ticket != 0 && save.KCGJGPOFOCD_ticket <= cnt)
					return false;
                save.KCGJGPOFOCD_ticket -= cnt;
				return true;
			}
		}
		return false;
	}

	// // RVA: 0x184309C Offset: 0x184309C VA: 0x184309C Slot: 14
	public override void HPENJEOAMBK_SetTicket(int _JKIADEKHGLC_TicketItemId, int _HMFFHLPNMPH_count, BBHNACPENDM_ServerSaveData _AHEFHIMGIBI_PlayerData)
	{
		PHBACNMCMHG_EventCollection ev = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.LBDOLHGDIEB_GetDbSection(JOPOPMLFINI_QuestName) as PHBACNMCMHG_EventCollection;
		if(ev != null)
		{
			if(_AHEFHIMGIBI_PlayerData == null)
			{
				_AHEFHIMGIBI_PlayerData = CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_PlayerData;
			}
			if(MNDFBBMNJGN_IsUsingTicket)
			{
                ABBOEIPOBLJ_EventTicket.CBDACMFFHJC tkt = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.KHPOJKHKLEM_EventTicket.CDENCMNHNGA_table.Find((ABBOEIPOBLJ_EventTicket.CBDACMFFHJC _GHPLINIACBB_x) =>
				{
					//0x1848134
					return _GHPLINIACBB_x.INDDJNMPONH_type == ev.NGHKJOEDLIP_Settings.MJBKGOJBPAD_item_type;
				});
				if(tkt != null && JKIADEKHGLC_TicketItemId == _JKIADEKHGLC_TicketItemId && _HMFFHLPNMPH_count > 0)
				{
					for(int i = 0; i < _HMFFHLPNMPH_count; i++)
						_AHEFHIMGIBI_PlayerData.MBAHCFLBDHN_EventCollection.FBCJICEPLED[ev.NGHKJOEDLIP_Settings.MOEKELIIDEO_SaveIdx].KCGJGPOFOCD_ticket += tkt.JBGEEPFKIGG_val;
				}
            }
		}
	}

	// // RVA: 0x18434A8 Offset: 0x18434A8 VA: 0x18434A8 Slot: 11
	public override int AELBIEDNPGB_GetTicketCount(BBHNACPENDM_ServerSaveData _AHEFHIMGIBI_PlayerData)
	{
		PHBACNMCMHG_EventCollection ev = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.LBDOLHGDIEB_GetDbSection(JOPOPMLFINI_QuestName) as PHBACNMCMHG_EventCollection;
		if(ev != null)
		{
			if(_AHEFHIMGIBI_PlayerData == null)
			{
				_AHEFHIMGIBI_PlayerData = CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_PlayerData;
			}
			if(MNDFBBMNJGN_IsUsingTicket)
			{
                ABBOEIPOBLJ_EventTicket.CBDACMFFHJC tkt = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.KHPOJKHKLEM_EventTicket.CDENCMNHNGA_table.Find((ABBOEIPOBLJ_EventTicket.CBDACMFFHJC _GHPLINIACBB_x) =>
				{
					//0x1848190
					return _GHPLINIACBB_x.INDDJNMPONH_type == ev.NGHKJOEDLIP_Settings.MJBKGOJBPAD_item_type;
				});
				if(tkt != null)
				{
					return _AHEFHIMGIBI_PlayerData.MBAHCFLBDHN_EventCollection.FBCJICEPLED[ev.NGHKJOEDLIP_Settings.MOEKELIIDEO_SaveIdx].KCGJGPOFOCD_ticket;
				}
            }
		}
		return 0;
	}

	// // RVA: 0x1843860 Offset: 0x1843860 VA: 0x1843860 Slot: 54
	public override int NGIHFKHOJOK_GetRankingMax(bool DJHLDMOPCOL/* = true*/)
	{
		if(IBNKPMPFLGI_IsRankReward)
		{
			if(DJHLDMOPCOL)
			{
				return KBACNOCOANM_Ranking.Count;
			}
			int res = 0;
			for(int i = 0; i < KBACNOCOANM_Ranking.Count; i++)
			{
				if(KBACNOCOANM_Ranking[i] != null)
					res++;
			}
			return res;
		}
		return 0;
	}

	// // RVA: 0x184397C Offset: 0x184397C VA: 0x184397C Slot: 58
	protected override void LMGMELPOGMH(int LHJCOPMMIGO)
	{
		PHBACNMCMHG_EventCollection ev = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.LBDOLHGDIEB_GetDbSection(JOPOPMLFINI_QuestName) as PHBACNMCMHG_EventCollection;
		if(ev != null)
		{
            EECOJKDJIFG e = DAKMIKNKHMF_GetRankingInfoForIndex(LHJCOPMMIGO);
			if(e != null)
			{
				HLFHJIDHJMP = null;
				OKPEFAPPFDH_GetRanksAroundSelf req = NKGJPJPHLIF.HHCJCDFCLOB.IBLPICFDGOF_ServerRequester.IFFNCAFNEAG_AddRequest(new OKPEFAPPFDH_GetRanksAroundSelf(false));
				req.EMPNJPMAKBF_Id = e.PPFNGGCBJKC_id;
				req.MJGOBEGONON_Type = 0;
				req.NHPCKCOPKAM_from = 0;
				req.PJFKNNNDMIA_to = 0;
				req.MOBEEPPKFLG_OnFail = (CACGCMBKHDI_Request KCFBGMKDIMI) =>
				{
					//0x18481EC
					if(JGJFFKPFMDB.BDGBCCGLLAJ_IsRankingError(KCFBGMKDIMI.CJMFJOMECKI_ErrorId))
					{
						if(KCFBGMKDIMI.CJMFJOMECKI_ErrorId == SakashoErrorId.RANKING_DROPPED_PLAYER)
						{
							FKKDIDMGLMI_IsDroppedPlayer = true;
						}
						FJGNPNFLHPH_EventCollection.JIALCLGJPKL save = CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_PlayerData.MBAHCFLBDHN_EventCollection.FBCJICEPLED[ev.NGHKJOEDLIP_Settings.MOEKELIIDEO_SaveIdx];
						save.LHAEPPFACOB_SetRewardReceived(true, LHJCOPMMIGO);
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
					//0x1848520
					OKPEFAPPFDH_GetRanksAroundSelf r = KCFBGMKDIMI as OKPEFAPPFDH_GetRanksAroundSelf;
					if(r.NFEAMMJIMPG_Result.EJDEDOJFOOK_Ranks.Count == 0)
					{
						FJGNPNFLHPH_EventCollection.JIALCLGJPKL save = CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_PlayerData.MBAHCFLBDHN_EventCollection.FBCJICEPLED[ev.NGHKJOEDLIP_Settings.MOEKELIIDEO_SaveIdx];
						save.LHAEPPFACOB_SetRewardReceived(true, LHJCOPMMIGO);
						PJDGDNJNCNM_UpdateStatusImpl(NKGJPJPHLIF.HHCJCDFCLOB.IBLPICFDGOF_ServerRequester.FJDBNGEPKHL_Time.KMEFBNBFJHI_GetServerTime());
						PLOOEECNHFB_IsDone = true;
					}
					else
					{
						HLFHJIDHJMP = new NHGEHCMPDAI();
						HLFHJIDHJMP.DNBFMLBNAEE_point = r.NFEAMMJIMPG_Result.EJDEDOJFOOK_Ranks[0].KNIFCANOHOC_score;
						HLFHJIDHJMP.FJOLNJLLJEJ_rank = r.NFEAMMJIMPG_Result.EJDEDOJFOOK_Ranks[0].FJOLNJLLJEJ_rank;
						KKLGENJKEBN.HHCJCDFCLOB.DNJKPPCBINA(e.OCGFKMHNEOF_name_for_api, () =>
						{
							//0x1848BE4
							for(int i = 0; i < KKLGENJKEBN.HHCJCDFCLOB.PHOPJDPEHJA.Count; i++)
							{
								MFDJIFIIPJD d = new MFDJIFIIPJD();
								d.KHEKNNFCAOI_Init(KKLGENJKEBN.HHCJCDFCLOB.PHOPJDPEHJA[i].JJBGOIMEIPF_ItemId, KKLGENJKEBN.HHCJCDFCLOB.PHOPJDPEHJA[i].MBJIFDBEDAC_item_count);
								HLFHJIDHJMP.HBHMAKNGKFK_items.Add(d);
							}
							ILCCJNDFFOB.HHCJCDFCLOB.GIBLHFKIMDA(this);
							FJGNPNFLHPH_EventCollection.JIALCLGJPKL save = CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_PlayerData.MBAHCFLBDHN_EventCollection.FBCJICEPLED[ev.NGHKJOEDLIP_Settings.MOEKELIIDEO_SaveIdx];
							save.LHAEPPFACOB_SetRewardReceived(true, LHJCOPMMIGO);
							PLOOEECNHFB_IsDone = true;
						}, () =>
						{
							//0x1848F64
							HLFHJIDHJMP = null;
							ILCCJNDFFOB.HHCJCDFCLOB.GIBLHFKIMDA(this);
							FJGNPNFLHPH_EventCollection.JIALCLGJPKL save = CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_PlayerData.MBAHCFLBDHN_EventCollection.FBCJICEPLED[ev.NGHKJOEDLIP_Settings.MOEKELIIDEO_SaveIdx];
							save.LHAEPPFACOB_SetRewardReceived(true, LHJCOPMMIGO);
							PLOOEECNHFB_IsDone = true;
						}, () =>
						{
							//0x1849154
							FJGNPNFLHPH_EventCollection.JIALCLGJPKL save = CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_PlayerData.MBAHCFLBDHN_EventCollection.FBCJICEPLED[ev.NGHKJOEDLIP_Settings.MOEKELIIDEO_SaveIdx];
							save.LHAEPPFACOB_SetRewardReceived(true, LHJCOPMMIGO);
							PLOOEECNHFB_IsDone = true;
							HLFHJIDHJMP = null;
						}, () =>
						{
							//0x18492E8
							PLOOEECNHFB_IsDone = true;
							HLFHJIDHJMP = null;
						}, () =>
						{
							//0x1849330
							PLOOEECNHFB_IsDone = true;
							NPNNPNAIONN_IsError = true;
						}, 0, -1);
					}
				};
				return;
			}
        }
		PLOOEECNHFB_IsDone = true;
	}

	// // RVA: 0x1843D48 Offset: 0x1843D48 VA: 0x1843D48 Slot: 59
	public override List<int> AEGDKBNNDBC_GetDrops()
	{
		PHBACNMCMHG_EventCollection ev = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.LBDOLHGDIEB_GetDbSection(JOPOPMLFINI_QuestName) as PHBACNMCMHG_EventCollection;
		if(ev != null)
		{
			return ev.NGHKJOEDLIP_Settings.EEOGPJJCKHH_Drops;
		}
		return null;
	}

	// // RVA: 0x1843ECC Offset: 0x1843ECC VA: 0x1843ECC Slot: 33
	public override bool MPMKJNJGFEF_IsEntry()
	{
		PHBACNMCMHG_EventCollection ev = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.LBDOLHGDIEB_GetDbSection(JOPOPMLFINI_QuestName) as PHBACNMCMHG_EventCollection;
		if(ev != null)
		{
			FJGNPNFLHPH_EventCollection.JIALCLGJPKL save = CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_PlayerData.MBAHCFLBDHN_EventCollection.FBCJICEPLED[ev.NGHKJOEDLIP_Settings.MOEKELIIDEO_SaveIdx];
			return save.IMFBCJOIJKJ_Entry;
		}
		return false;
	}

	// // RVA: 0x184412C Offset: 0x184412C VA: 0x184412C Slot: 65
	protected override bool JLPDECMHLIM_CanShowStartAdventureInternal()
	{
		PHBACNMCMHG_EventCollection ev = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.LBDOLHGDIEB_GetDbSection(JOPOPMLFINI_QuestName) as PHBACNMCMHG_EventCollection;
		if(ev != null)
		{
			FJGNPNFLHPH_EventCollection.JIALCLGJPKL save = CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_PlayerData.MBAHCFLBDHN_EventCollection.FBCJICEPLED[ev.NGHKJOEDLIP_Settings.MOEKELIIDEO_SaveIdx];
			long t = NKGJPJPHLIF.HHCJCDFCLOB.IBLPICFDGOF_ServerRequester.FJDBNGEPKHL_Time.KMEFBNBFJHI_GetServerTime();
			PJDGDNJNCNM_UpdateStatusImpl(t);
			if(GFIBLLLHMPD_StartAdventureId != 0)
			{
				if(NGOFCFJHOMI_Status == KGCNCBOKCBA.GNENJEHKMHD_EventStatus.NCJFJLPJMLI_2)
				{
					return (save.INLNJOGHLJE_Show & 1) == 0;
				}
			}
		}
		return false;
	}

	// // RVA: 0x1844468 Offset: 0x1844468 VA: 0x1844468 Slot: 66
	public override void FGDDBFHGCGP_SetStartAdventureShown(bool _JKDJCFEBDHC_Enabled, long _JHNMKKNEENE_Time/* = 0*/)
	{
		if(_JKDJCFEBDHC_Enabled)
		{
			PHBACNMCMHG_EventCollection ev = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.LBDOLHGDIEB_GetDbSection(JOPOPMLFINI_QuestName) as PHBACNMCMHG_EventCollection;
			if(ev != null)
			{
				FJGNPNFLHPH_EventCollection.JIALCLGJPKL save = CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_PlayerData.MBAHCFLBDHN_EventCollection.FBCJICEPLED[ev.NGHKJOEDLIP_Settings.MOEKELIIDEO_SaveIdx];
				if(NGOFCFJHOMI_Status == KGCNCBOKCBA.GNENJEHKMHD_EventStatus.NCJFJLPJMLI_2)
				{
					save.INLNJOGHLJE_Show |= 1;
				}
			}
		}
	}

	// // RVA: 0x18446E8 Offset: 0x18446E8 VA: 0x18446E8 Slot: 70
	public override void ADACMHAHHKC_PreSetupEventHome(IMCBBOAFION _BHFHGFKBOHH_OnSuccess, DJBHIFLHJLK _AOCANKOMKFG_OnError)
	{
		N.a.StartCoroutineWatched(NJIEIJJMAHK_Corotuine_PreSetupEventHome(_BHFHGFKBOHH_OnSuccess, _AOCANKOMKFG_OnError));
	}

	// [IteratorStateMachineAttribute] // RVA: 0x6BC4E4 Offset: 0x6BC4E4 VA: 0x6BC4E4
	// // RVA: 0x1844740 Offset: 0x1844740 VA: 0x1844740
	private IEnumerator NJIEIJJMAHK_Corotuine_PreSetupEventHome(IMCBBOAFION _BHFHGFKBOHH_OnSuccess, DJBHIFLHJLK _AOCANKOMKFG_OnError)
	{
		long IBCGNDADAEE_Time; // 0x28
		PHBACNMCMHG_EventCollection KEHCNBNPJHB; // 0x30
		BBHNACPENDM_ServerSaveData PNFNCKGAFBK; // 0x34
		FJGNPNFLHPH_EventCollection.JIALCLGJPKL FDAENOPKLKP; // 0x38

		//0x18493A0
		while(CIOECGOMILE.HHCJCDFCLOB.KONHMOLMOCI_IsSaving)
			yield return null;
		IBCGNDADAEE_Time = NKGJPJPHLIF.HHCJCDFCLOB.IBLPICFDGOF_ServerRequester.FJDBNGEPKHL_Time.KMEFBNBFJHI_GetServerTime();
		KEHCNBNPJHB = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.LBDOLHGDIEB_GetDbSection(JOPOPMLFINI_QuestName) as PHBACNMCMHG_EventCollection;
		if(KEHCNBNPJHB != null)
		{
			PJDGDNJNCNM_UpdateStatusImpl(IBCGNDADAEE_Time);
			PNFNCKGAFBK = CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_PlayerData;
			FDAENOPKLKP = PNFNCKGAFBK.MBAHCFLBDHN_EventCollection.FBCJICEPLED[KEHCNBNPJHB.NGHKJOEDLIP_Settings.MOEKELIIDEO_SaveIdx];
			if(FDAENOPKLKP.DNBFMLBNAEE_point != 0)
			{
				MJFKJHJJLMN_GetRanks(0, false);
				//LAB_01849524
				while(!PLOOEECNHFB_IsDone)
					yield return null;
				if(NPNNPNAIONN_IsError)
				{
					if(_AOCANKOMKFG_OnError != null)
						_AOCANKOMKFG_OnError();
					yield break;
				}
				if(FKKDIDMGLMI_IsDroppedPlayer)
				{
					JHHBAFKMBDL.HHCJCDFCLOB.PEIONAKEPCN_ShowRankingBanPopup(_AOCANKOMKFG_OnError);
					yield break;
				}
			}
			//_breakk
			if(NGOFCFJHOMI_Status == KGCNCBOKCBA.GNENJEHKMHD_EventStatus.GDOPLACICFE_4)
			{
				FDAENOPKLKP.ABBJBPLHFHA_Spurt = true;
				LPFJADHHLHG = true;
				PJDGDNJNCNM_UpdateStatusImpl(IBCGNDADAEE_Time);
			}
			if(!FDAENOPKLKP.IMFBCJOIJKJ_Entry)
			{
				if(NGOFCFJHOMI_Status == KGCNCBOKCBA.GNENJEHKMHD_EventStatus.NCJFJLPJMLI_2)
				{
					CMPEJEHCOEI = true;
					FGDDBFHGCGP_SetStartAdventureShown(true, 0);
					FDAENOPKLKP.IMFBCJOIJKJ_Entry = true;
				}
				if(KIBBLLADDPO)
				{
					FDAENOPKLKP.ABBJBPLHFHA_Spurt = true;
					LPFJADHHLHG = true;
				}
			}
			if(NGOFCFJHOMI_Status < KGCNCBOKCBA.GNENJEHKMHD_EventStatus.EMAMLLFAOJI_Counting_6)
			{
				if(GFIBLLLHMPD_StartAdventureId > 0)
				{
					if(PNFNCKGAFBK.HBPPNFHOMNB_Adventure.FABEJIHKFGN_IsReleased(GFIBLLLHMPD_StartAdventureId))
					{
						if(!FDAENOPKLKP.OKEJGGCMAAI_PlaRcv)
						{
							bool KPIGMCJMFAN = false;
							yield return Co.R(JEIJKLPOAHP_ReceivePrologueRepeatedAchievement(() =>
							{
								//0x184937C
								KPIGMCJMFAN = true;
							}));
							if(!KPIGMCJMFAN)
							{
								if(JBPPMMMFGCA_HasRewardItems())
								{
									FDAENOPKLKP.OKEJGGCMAAI_PlaRcv = true;
								}
								//LAB_01849814
								//LAB_01849c50
							}
							else
							{
								//LAB_018495d8
								if(_AOCANKOMKFG_OnError != null)
									_AOCANKOMKFG_OnError();
								yield break;
							}
						}
					}
				}
			}
			else if(NGOFCFJHOMI_Status >= KGCNCBOKCBA.GNENJEHKMHD_EventStatus.DDEODFNANDO_8_ResultRewardToReceive && CAKEOPLJDAF_EndAdventureId > 0)
			{
				if(PNFNCKGAFBK.HBPPNFHOMNB_Adventure.FABEJIHKFGN_IsReleased(CAKEOPLJDAF_EndAdventureId))
				{
					if(!FDAENOPKLKP.CGMMMJCIDFE_EpaRcv)
					{
						bool KPIGMCJMFAN = false;
						yield return Co.R(KPBNMAEHHDF_ReceiveEpilogueRepeatedAchivement(() =>
						{
							//0x1849390
							KPIGMCJMFAN = true;
						}));
						//4
						if(!KPIGMCJMFAN)
						{
							if(JBPPMMMFGCA_HasRewardItems())
							{
								FDAENOPKLKP.CGMMMJCIDFE_EpaRcv = true;
							}
							//LAB_01849814
							//LAB_01849c50
						}
						else
						{
							//LAB_018495d8
							if(_AOCANKOMKFG_OnError != null)
								_AOCANKOMKFG_OnError();
							yield break;
						}
					}
				}
			}
			//LAB_01849c50
			OIMGJLOLPHK = false;
			if(NGOFCFJHOMI_Status < KGCNCBOKCBA.GNENJEHKMHD_EventStatus.EMAMLLFAOJI_Counting_6)
			{
				CEBFFLDKAEC_SecureInt d;
				if(KEHCNBNPJHB.OHJFBLFELNK_m_intParam.TryGetValue(HOEKCEJINNA_new_episode_mver, out d))
				{
					bool b = DLHEEOIELBA(d.DNJEJEANJGL_Value);
					if(NGOFCFJHOMI_Status == KGCNCBOKCBA.GNENJEHKMHD_EventStatus.NCJFJLPJMLI_2)
					{
						bool b2 = !b;
						b = true;
						if(b2)
						{
							FDAENOPKLKP.INLNJOGHLJE_Show |= 4;
							b = false;
						}
					}
					else
					{
						if(b && KEHCNBNPJHB.OHJFBLFELNK_m_intParam.TryGetValue(FOKNMOMNHHD_new_episode_help_pict_id, out d))
						{
							b = true;
							if((FDAENOPKLKP.INLNJOGHLJE_Show & 4) != 0)
							{
								GFHKFKHBIGM = true;
								OGPMLMDPGJA = d.DNJEJEANJGL_Value;
								b = true;
							}
						}
					}
					OIMGJLOLPHK = b;
				}
			}
			ILCCJNDFFOB.HHCJCDFCLOB.DADNPOJNIBL(this);
			if(_BHFHGFKBOHH_OnSuccess != null)
				_BHFHGFKBOHH_OnSuccess();
		}
		else
		{
			NPNNPNAIONN_IsError = true;
			PLOOEECNHFB_IsDone = true;
			if(_AOCANKOMKFG_OnError != null)
				_AOCANKOMKFG_OnError();
		}
	}

	// [IteratorStateMachineAttribute] // RVA: 0x6BC55C Offset: 0x6BC55C VA: 0x6BC55C
	// // RVA: 0x1844820 Offset: 0x1844820 VA: 0x1844820
	public IEnumerator INOILCGFHIC_RequestGetScoreRank(IMCBBOAFION _BHFHGFKBOHH_OnSuccess, DJBHIFLHJLK _AOCANKOMKFG_OnError)
	{
		//0x184A790
		PHBACNMCMHG_EventCollection ev = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.LBDOLHGDIEB_GetDbSection(JOPOPMLFINI_QuestName) as PHBACNMCMHG_EventCollection;
		if(ev != null)
		{
			FJGNPNFLHPH_EventCollection.JIALCLGJPKL save = CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_PlayerData.MBAHCFLBDHN_EventCollection.FBCJICEPLED[ev.NGHKJOEDLIP_Settings.MOEKELIIDEO_SaveIdx];
			if(save.KNIFCANOHOC_score != 0)
			{
				MJFKJHJJLMN_GetRanks(1, false);
				while(!PLOOEECNHFB_IsDone)
					yield return null;
				if(NPNNPNAIONN_IsError)
				{
					_AOCANKOMKFG_OnError();
					yield break;
				}
				else
				{
					if(FKKDIDMGLMI_IsDroppedPlayer)
					{
						JHHBAFKMBDL.HHCJCDFCLOB.PEIONAKEPCN_ShowRankingBanPopup(_AOCANKOMKFG_OnError);
						yield break;
					}
				}
			}
			//LAB_0184aafc
			_BHFHGFKBOHH_OnSuccess();
		}
		else
		{
			NPNNPNAIONN_IsError = true;
			PLOOEECNHFB_IsDone = true;
			if(_AOCANKOMKFG_OnError != null)
				_AOCANKOMKFG_OnError();
		}
	}

	// // RVA: 0x1844900 Offset: 0x1844900 VA: 0x1844900 Slot: 69
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

	// // RVA: 0x1844A28 Offset: 0x1844A28 VA: 0x1844A28 Slot: 71
	public override int BAEPGOAMBDK(string _LJNAKDMILMC_key, int MNCOAGOKNAO)
	{
		PHBACNMCMHG_EventCollection ev = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.LBDOLHGDIEB_GetDbSection(JOPOPMLFINI_QuestName) as PHBACNMCMHG_EventCollection;
		if(ev != null)
		{
			return ev.LPJLEHAJADA_GetIntParam(_LJNAKDMILMC_key, MNCOAGOKNAO);
		}
		return MNCOAGOKNAO;
	}

	// // RVA: 0x1844BA8 Offset: 0x1844BA8 VA: 0x1844BA8 Slot: 72
	public override string MAICAKMIBEM(string _LJNAKDMILMC_key, string MNCOAGOKNAO)
	{
		PHBACNMCMHG_EventCollection ev = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.LBDOLHGDIEB_GetDbSection(JOPOPMLFINI_QuestName) as PHBACNMCMHG_EventCollection;
		if(ev != null)
		{
			return ev.EFEGBHACJAL_GetStringParam(_LJNAKDMILMC_key, MNCOAGOKNAO);
		}
		return MNCOAGOKNAO;
	}

	// // RVA: 0x1844D28 Offset: 0x1844D28 VA: 0x1844D28 Slot: 68
	public override bool GJMGKBDGMOP(long LPEKHFOMCAH)
	{
		PHBACNMCMHG_EventCollection ev = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.LBDOLHGDIEB_GetDbSection(JOPOPMLFINI_QuestName) as PHBACNMCMHG_EventCollection;
		if(ev != null)
		{
			if(BHABCGJCGNO != null)
			{
				if(LPEKHFOMCAH < DPJCPDKALGI_RankingEnd)
				{
					FJGNPNFLHPH_EventCollection.JIALCLGJPKL save = CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_PlayerData.MBAHCFLBDHN_EventCollection.FBCJICEPLED[ev.NGHKJOEDLIP_Settings.MOEKELIIDEO_SaveIdx];
					if(NKGJPJPHLIF.HHCJCDFCLOB.DHMLDAGGKCD != save.OMCAOJJGOGG_Lb)
					{
						if(EKLNMHFCAOI.BKHFLDMOGBD_GetItemCategory(BHABCGJCGNO.JJBGOIMEIPF_ItemId) == EKLNMHFCAOI.FKGCBLHOOCL_Category.DMMIIBCMCFG_EnergyItem)
						{
							int id = EKLNMHFCAOI.DEACAHNLMNI_getItemId(BHABCGJCGNO.JJBGOIMEIPF_ItemId);
							EGOLBAPFHHD_Common.FKLHGOGJOHH it = CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_PlayerData.KCCLEHLLOFG_Common.KFEBOFKAHAJ_EngItem[id - 1];
							it.BFINGCJHOHI_cnt += BHABCGJCGNO.MBJIFDBEDAC_item_count;
							it.BEBJKJKBOGH_date = NKGJPJPHLIF.HHCJCDFCLOB.IBLPICFDGOF_ServerRequester.FJDBNGEPKHL_Time.KMEFBNBFJHI_GetServerTime();
							ILCCJNDFFOB.HHCJCDFCLOB.JAHALBMOANH(BHABCGJCGNO.JJBGOIMEIPF_ItemId, OAGBCBBHMPF.COIIJOEKBDH.IGAJCMKNLDL_14, 
								PGIIDPEGGPI_EventId.ToString(), BHABCGJCGNO.MBJIFDBEDAC_item_count, it.BFINGCJHOHI_cnt, 1);
							save.OMCAOJJGOGG_Lb = NKGJPJPHLIF.HHCJCDFCLOB.DHMLDAGGKCD;
						}
						else if(EKLNMHFCAOI.BKHFLDMOGBD_GetItemCategory(BHABCGJCGNO.JJBGOIMEIPF_ItemId) == EKLNMHFCAOI.FKGCBLHOOCL_Category.CLMIJKACELE_EventTicket)
						{
							HPENJEOAMBK_SetTicket(BHABCGJCGNO.JJBGOIMEIPF_ItemId, BHABCGJCGNO.MBJIFDBEDAC_item_count, CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_PlayerData);
							save.OMCAOJJGOGG_Lb = NKGJPJPHLIF.HHCJCDFCLOB.DHMLDAGGKCD;
							ILCCJNDFFOB.HHCJCDFCLOB.JAHALBMOANH(BHABCGJCGNO.JJBGOIMEIPF_ItemId, OAGBCBBHMPF.COIIJOEKBDH.IGAJCMKNLDL_14, 
								PGIIDPEGGPI_EventId.ToString(), BHABCGJCGNO.MBJIFDBEDAC_item_count, save.KCGJGPOFOCD_ticket, 1);
						}
						return true;
					}
				}
			}
		}
		return false;
	}

	// // RVA: 0x18456E0 Offset: 0x18456E0 VA: 0x18456E0
	public void FCLGOCBGPJF(JGEOBNENMAH.HAJIFNABIFF OMNOFMEBLAD, JKNGJFOBADP _IKCBPLIFBOJ_inv, int _FCLGIPFPIPH_DashBonus, int BMMPAHHEOJC, int MHADLGMJKGK)
	{
		PHBACNMCMHG_EventCollection ev = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.LBDOLHGDIEB_GetDbSection(JOPOPMLFINI_QuestName) as PHBACNMCMHG_EventCollection;
		if(ev != null)
		{
			EELENPNCGLM.PPBHHLGPMBK = _IKCBPLIFBOJ_inv.PPBHHLGPMBK;
			EELENPNCGLM.IONINNDIAFO = _IKCBPLIFBOJ_inv.IONINNDIAFO;
			EELENPNCGLM.FCLGIPFPIPH_DashBonus = _FCLGIPFPIPH_DashBonus;
			EELENPNCGLM.FPEOGFMKMKJ_Point = 0;
			for(int i = 0; i < 3; i++)
			{
				if(_IKCBPLIFBOJ_inv.PPBHHLGPMBK[i] != 0)
				{
					EELENPNCGLM.FPEOGFMKMKJ_Point += _IKCBPLIFBOJ_inv.IONINNDIAFO[i] * IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.DHOFNBMPBAG_EventItem.CDENCMNHNGA_table[_IKCBPLIFBOJ_inv.PPBHHLGPMBK[i] - 1].JBGEEPFKIGG_val;
				}
			}
			EELENPNCGLM.ANOCILKJGOJ_EpisodeCnt = LEPNPBIMHGM_GetEquippedEpisodesWithBonus(BMMPAHHEOJC).Count;
			EELENPNCGLM.ODCLHPGHDHA_EpisodeBonus = CEICDKGEONG_GetEquippedEpisodesBonusValue(BMMPAHHEOJC, MHADLGMJKGK);
			EELENPNCGLM.ODCLHPGHDHA_EpisodeBonus += 100;
			EELENPNCGLM.PIIEGNPOPJI_GetPoint = EELENPNCGLM.ODCLHPGHDHA_EpisodeBonus * EELENPNCGLM.FPEOGFMKMKJ_Point / 100;
			EELENPNCGLM.PIIEGNPOPJI_GetPoint *= EELENPNCGLM.FCLGIPFPIPH_DashBonus;
			NBMDAOFPKGK(EELENPNCGLM.PIIEGNPOPJI_GetPoint);
			EELENPNCGLM.OENBOLPDBAB_FreeMusicId = HEACCHAKMFG_GetMusicsList()[0];
			FJGNPNFLHPH_EventCollection.JIALCLGJPKL save = CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_PlayerData.MBAHCFLBDHN_EventCollection.FBCJICEPLED[ev.NGHKJOEDLIP_Settings.MOEKELIIDEO_SaveIdx];
			EELENPNCGLM.GCAPLLEIAAI_LastScore = OMNOFMEBLAD.KNIFCANOHOC_score;
			EELENPNCGLM.IDCFOMMKGIK = EELENPNCGLM.ODCLHPGHDHA_EpisodeBonus * OMNOFMEBLAD.KNIFCANOHOC_score / 100;
			EELENPNCGLM.LPGNCOFHOPK_SaveScore = (int)save.KNIFCANOHOC_score;
			EELENPNCGLM.GIIKOMPJOHA_IsHiScore = false;
			if(OMNOFMEBLAD.PMCGHPOGLGM_IsSkip)
				return;
			EECOJKDJIFG e = DAKMIKNKHMF_GetRankingInfoForIndex(1);
			if(e == null)
				return;
			if(OMNOFMEBLAD.GHBPLHBNMBK_FreeMusicId != EELENPNCGLM.OENBOLPDBAB_FreeMusicId)
				return;
			if(EELENPNCGLM.IDCFOMMKGIK <= EELENPNCGLM.LPGNCOFHOPK_SaveScore)
				return;
			DDIDDLEIIPM(EELENPNCGLM.IDCFOMMKGIK);
			EELENPNCGLM.LPGNCOFHOPK_SaveScore = EELENPNCGLM.IDCFOMMKGIK;
			EELENPNCGLM.GIIKOMPJOHA_IsHiScore = true;
		}
	}

	// // RVA: 0x1845EEC Offset: 0x1845EEC VA: 0x1845EEC
	public void NGIPMNLALAA(int _EJDJIBPKKNO_BasePoint, int _FCLGIPFPIPH_DashBonus, int BMMPAHHEOJC, int MHADLGMJKGK, int _AKNELONELJK_difficulty)
	{
		EELENPNCGLM.FCLGIPFPIPH_DashBonus = _FCLGIPFPIPH_DashBonus;
		EELENPNCGLM.FPEOGFMKMKJ_Point = _EJDJIBPKKNO_BasePoint;
		EELENPNCGLM.ANOCILKJGOJ_EpisodeCnt = LEPNPBIMHGM_GetEquippedEpisodesWithBonus(BMMPAHHEOJC).Count;
		EELENPNCGLM.ODCLHPGHDHA_EpisodeBonus = CEICDKGEONG_GetEquippedEpisodesBonusValue(BMMPAHHEOJC, MHADLGMJKGK);
		EELENPNCGLM.ODCLHPGHDHA_EpisodeBonus += 100;
		EELENPNCGLM.PIIEGNPOPJI_GetPoint = (EELENPNCGLM.ODCLHPGHDHA_EpisodeBonus * EELENPNCGLM.FPEOGFMKMKJ_Point) / 100;
		EELENPNCGLM.PIIEGNPOPJI_GetPoint *= EELENPNCGLM.FCLGIPFPIPH_DashBonus;
	}

	// // RVA: 0x18460BC Offset: 0x18460BC VA: 0x18460BC Slot: 73
	public override List<string> IJCPBPFEGDM_GetResourcesFilePathList(long _JHNMKKNEENE_Time)
	{
		if(!MNNNLDFNNCD(_JHNMKKNEENE_Time))
			return null;
		List<int> l = HEACCHAKMFG_GetMusicsList();
		if(l == null)
			return null;
		int wavId = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.IBPAFKKEKNK_Music.IAJLOELFHKC_GetMusicInfo(IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.IBPAFKKEKNK_Music.NOBCLJIAMLC_GetFreeMusicData(l[0]).DLAEJOBELBH_MusicId).KKPAHLMJKIH_WavId;
        List<string> res = SoundResource.CreateBgmFilePathList(wavId);
		for(int i = 0; i < BHAHKCMJAJE.Count; i++)
		{
			res.Add(ItemTextureCache.MakeItemIconTexturePath(EKLNMHFCAOI.GJEEGMCBGGM_GetItemFullId(EKLNMHFCAOI.FKGCBLHOOCL_Category.EMOLGEDEEJP_EventItem, BHAHKCMJAJE[i]), 0));
		}
		if(JKIADEKHGLC_TicketItemId != 0)
		{
			res.Add(ItemTextureCache.MakeItemIconTexturePath(JKIADEKHGLC_TicketItemId, 0));
		}
        return res;
	}

	// // RVA: 0x18463F4 Offset: 0x18463F4 VA: 0x18463F4 Slot: 74
	public override int EDNMFMBLCGF_GetWavId()
	{
		List<int> l = HEACCHAKMFG_GetMusicsList();
		if(l != null)
		{
			return IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.IBPAFKKEKNK_Music.IAJLOELFHKC_GetMusicInfo(IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.IBPAFKKEKNK_Music.NOBCLJIAMLC_GetFreeMusicData(l[0]).DLAEJOBELBH_MusicId).KKPAHLMJKIH_WavId;
		}
		return 0;
	}

	// // RVA: 0x1846584 Offset: 0x1846584 VA: 0x1846584 Slot: 38
	public override void EMEPJNLHJHJ(int GJEADBKFAPA, int _AKNELONELJK_difficulty, bool _GIKLNODJKFK_IsLine6, ref int APMGOLOPLFP, ref int FBBDNLAMPMH)
	{
		PHBACNMCMHG_EventCollection ev = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.LBDOLHGDIEB_GetDbSection(JOPOPMLFINI_QuestName) as PHBACNMCMHG_EventCollection;
		if(ev != null)
		{
			if(_GIKLNODJKFK_IsLine6)
			{
				APMGOLOPLFP = ev.GKCBPNPEJJF[GJEADBKFAPA + _AKNELONELJK_difficulty - 1].KFCIJBLDHOK_v1;
				FBBDNLAMPMH = ev.GKCBPNPEJJF[GJEADBKFAPA + _AKNELONELJK_difficulty - 1].JLEIHOEGMOP_v2;
			}
			else
			{
				APMGOLOPLFP = ev.ADPFKHEMNBL[GJEADBKFAPA + _AKNELONELJK_difficulty - 1].KFCIJBLDHOK_v1;
				FBBDNLAMPMH = ev.ADPFKHEMNBL[GJEADBKFAPA + _AKNELONELJK_difficulty - 1].JLEIHOEGMOP_v2;
			}
		}
	}

	// // RVA: 0x1846784 Offset: 0x1846784 VA: 0x1846784 Slot: 76
	public override void MMIMJPNLKBK()
	{
		if(GFHKFKHBIGM)
		{
			PHBACNMCMHG_EventCollection ev = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.LBDOLHGDIEB_GetDbSection(JOPOPMLFINI_QuestName) as PHBACNMCMHG_EventCollection;
			if(ev != null)
			{
				FJGNPNFLHPH_EventCollection.JIALCLGJPKL save = CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_PlayerData.MBAHCFLBDHN_EventCollection.FBCJICEPLED[ev.NGHKJOEDLIP_Settings.MOEKELIIDEO_SaveIdx];
				save.INLNJOGHLJE_Show = (int)(save.INLNJOGHLJE_Show & 0xfffffffb);
				GFHKFKHBIGM = false;
			}
		}
	}

	// // RVA: 0x1846A00 Offset: 0x1846A00 VA: 0x1846A00 Slot: 77
	public override string DBEMCLMPCFA_GetBannerText()
	{
		PHBACNMCMHG_EventCollection ev = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.LBDOLHGDIEB_GetDbSection(JOPOPMLFINI_QuestName) as PHBACNMCMHG_EventCollection;
		if(ev != null)
		{
			long t = NKGJPJPHLIF.HHCJCDFCLOB.IBLPICFDGOF_ServerRequester.FJDBNGEPKHL_Time.KMEFBNBFJHI_GetServerTime();
			for(int i = 0; i < ev.LLCLJBEJOPM_BannerInfo.Count; i++)
			{
				if(t >= ev.LLCLJBEJOPM_BannerInfo[i].PDBPFJJCADD_open_at && 
					t < ev.LLCLJBEJOPM_BannerInfo[i].FDBNFFNFOND_close_at)
				{
					return ev.LLCLJBEJOPM_BannerInfo[i].KLMPFGOCBHC_description;
				}
			}
		}
		return "";
	}

	// // RVA: 0x1846D7C Offset: 0x1846D7C VA: 0x1846D7C Slot: 78
	public override long OEGAJJANHGL()
	{
		PHBACNMCMHG_EventCollection ev = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.LBDOLHGDIEB_GetDbSection(JOPOPMLFINI_QuestName) as PHBACNMCMHG_EventCollection;
		if(ev != null)
		{
			return ev.NGHKJOEDLIP_Settings.JBFDHOIKAIK_InventoryEndDate;
		}
		return 0;
	}
}
