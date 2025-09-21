
using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using XeApp.Game;
using XeApp.Game.Common;
using XeSys;

public class DJDJHGJHAJA
{
	public enum IOPLHHNPLGM
	{
		HJNNKCMLGFL_0_None = 0,
		LAOEGNLOJHC = 1,
		EHPECKJANLI_2 = 2,
		NHGCLAGKEOO_3 = 3,
		EBEFOHNCAJD_4 = 4,
		NCDPEOOJEKL_5 = 5,
		CNLOFIHPBMP = 6,
		OLDDILMKJND_7 = 7,
		BFIOFNKPOFB_8 = 8,
		OLCLJKOKJCD = 9,
	}
}

[System.Obsolete("Use KPJHLACKGJF_EventMission", true)]
public class KPJHLACKGJF { }
public class KPJHLACKGJF_EventMission : IKDICBBFBMI_EventBase
{
	public class OPFEKMKHEIF
	{
		public bool BCGLDMKODLC_IsClear; // 0x8
		public int FPEOGFMKMKJ_Point; // 0xC
		public int PJEFKNPJEBE_MissionBonus; // 0x10
		public int JKDICBNOGBL_MusicBonus; // 0x14
		public int ODCLHPGHDHA_EpisodeBonus; // 0x18
		public int LIPIAPOGHIP_EpisodeNum; // 0x1C
		public int JKFCHNEININ_GetPoint; // 0x20
		public int BPJEOPHAJPP_PrevTotalPoint; // 0x24
		public int AHOKAPCGJMA_TotalPoint; // 0x28
		public int FCLGIPFPIPH_DashBonus; // 0x2C
		public int GHBPLHBNMBK_FreeMusicId; // 0x30
		public int BEOKMNIPFBA_MedalItemId; // 0x34
		public int ODOOKDGCKMF_MedalNum; // 0x38
		public int AJCMCKGNFHC_Level; // 0x3C
		public bool JKPDKNPDEBC_EnemyHasSkill; // 0x40
		public int FCNIAJHHGJH_Difficulty; // 0x44
		public int NFOOOBMJINC_MissionBonusNum; // 0x48
		public string EMBGHCNOCEH_Desc; // 0x4C
		public int KAENMAEJEHL; // 0x50
		public int JHGGBBNLINH_MilitaryMedalCount; // 0x54
		public bool LFGNLKKFOCD_IsLine6; // 0x58

		// // RVA: 0xD8E8A0 Offset: 0xD8E8A0 VA: 0xD8E8A0
		// public void LHPDDGIJKNB_Reset() { }
	}

	public enum MNIIDKPECMD
	{
		HIFIGCJNJDO_0_MusicId = 0,
		LNAOAANJGDM_1_SerieAttr = 1,
		OLFDHLDEPKO_2_MusicAttr = 2,
		CEPMMEKKNGC_3_All = 3,
	}

	public struct HLMINENBCKO
	{
		public string HJAFPEBIBOP_Limit; // 0x0
		public string GJLFANGDGCL_Target; // 0x4 //Desc
		public MNIIDKPECMD CIANOCNPIFF_Type; // 0x8
		public int IIAAIPNHJFJ_Value; // 0xC
		public bool IPJMPBANBPP_Enabled; // 0x10
		public bool AAMJNIDEAHC; // 0x11
	}

	public class GBACDCAFCEB
	{
		public int ANMCFINOHFH; // 0x8
		public int FCDKJAKLGMB_TargetValue; // 0xC
	}

	private const int GHJHJDIDCFA = 3;
	private EECOJKDJIFG KBACNOCOANM_Ranking; // 0xE8
	private bool GAKPAELDIKN; // 0xF0
	public bool EGOJLOEFMOH_IsUpdateLimitedMusic; // 0xF1
	public int BCBCODAKIDN_DescType; // 0xF4
	public bool EEIKDIHGJAD_IsUpdateBonusSchedule; // 0xF8
	public int CGEAAEPEFIE_ExclusiveBonusMusic; // 0xFC
	public bool KDDBNAIJKAD_ResetDisable; // 0x100
	public bool KIBBLLADDPO; // 0x108
	private List<HLMINENBCKO> OEFLDPCOCNP = new List<HLMINENBCKO>(); // 0x10C

	public override OHCAABOMEOF.KGOGMKMBCPP_EventType HIDHLFCBIDE_EventType { get { return OHCAABOMEOF.KGOGMKMBCPP_EventType.NKDOEBONGNI_EventMission; } } //0x1133158 DKHCGLCNKCD  Slot: 4
	public OPFEKMKHEIF FHPEAPEANAI { get; set; } // 0xEC NENKPIMLLHN BFAPJDBFKEP BBDBKNDKIJL
	public int JKCBFOAHNGL_Mid { get; private set; } // 0x104 FEHKFPEICBM MPNIHHELFBI CNLLLLAALIL
	public List<HLMINENBCKO> AFOIGLCEBAE { get { return OEFLDPCOCNP; } } //0x1133180 FFPIOJEFCCL

	// // RVA: 0x1133188 Offset: 0x1133188 VA: 0x1133188 Slot: 32
	public override EECOJKDJIFG DAKMIKNKHMF_GetRankingInfoForIndex(int LHJCOPMMIGO/* = 0*/)
	{
		return KBACNOCOANM_Ranking;
	}

	// RVA: 0x1133190 Offset: 0x1133190 VA: 0x1133190
	public KPJHLACKGJF_EventMission(string _OPFGFINHFCE_name) : base(_OPFGFINHFCE_name)
    {
        return;
    }

	// // RVA: 0x1133250 Offset: 0x1133250 VA: 0x1133250 Slot: 5
	public override string IFKKBHPMALH()
	{
		ACBAHDMEFFL_EventMission ev = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.LBDOLHGDIEB_GetDbSection(JOPOPMLFINI_QuestName) as ACBAHDMEFFL_EventMission;
		if(ev != null)
		{
			return ev.NGHKJOEDLIP_Settings.OCDMGOGMHGE_RewardPrefix;
		}
		return null;
	}

	// // RVA: 0x11333D8 Offset: 0x11333D8 VA: 0x11333D8 Slot: 7
	public override List<int> HEACCHAKMFG_GetMusicsList()
	{
		List<int> res = null;
		ACBAHDMEFFL_EventMission ev = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.LBDOLHGDIEB_GetDbSection(JOPOPMLFINI_QuestName) as ACBAHDMEFFL_EventMission;
		if(ev != null)
		{
			long t = NKGJPJPHLIF.HHCJCDFCLOB.IBLPICFDGOF_ServerRequester.FJDBNGEPKHL_Time.KMEFBNBFJHI_GetServerTime();
			res = new List<int>();
			for(int i = 0; i < ev.IJJHFGOIDOK_EventMusic.Count; i++)
			{
				if((ev.IJJHFGOIDOK_EventMusic[i].PDBPFJJCADD_open_at == 0 && ev.IJJHFGOIDOK_EventMusic[i].FDBNFFNFOND_CloseAt == 0) || 
					(t >= ev.IJJHFGOIDOK_EventMusic[i].PDBPFJJCADD_open_at && t < ev.IJJHFGOIDOK_EventMusic[i].FDBNFFNFOND_CloseAt))
				{
					if(ev.IJJHFGOIDOK_EventMusic[i].MPLGPBNJDJB_FreeMusicId > 0)
					{
						if(!res.Contains(ev.IJJHFGOIDOK_EventMusic[i].MPLGPBNJDJB_FreeMusicId))
							res.Add(ev.IJJHFGOIDOK_EventMusic[i].MPLGPBNJDJB_FreeMusicId);
					}
				}
			}
		}
		return res;
	}

	// // RVA: 0x1133760 Offset: 0x1133760 VA: 0x1133760 Slot: 9
	public override long HOOBCIIOCJD_GetSongEndTime(int _GHBPLHBNMBK_FreeMusicId)
	{
		ACBAHDMEFFL_EventMission ev = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.LBDOLHGDIEB_GetDbSection(JOPOPMLFINI_QuestName) as ACBAHDMEFFL_EventMission;
		if(ev != null)
		{
			long t = NKGJPJPHLIF.HHCJCDFCLOB.IBLPICFDGOF_ServerRequester.FJDBNGEPKHL_Time.KMEFBNBFJHI_GetServerTime();
			for(int i = 0; i < ev.IJJHFGOIDOK_EventMusic.Count; i++)
			{
				if(ev.IJJHFGOIDOK_EventMusic[i].PDBPFJJCADD_open_at != 0 && 
					ev.IJJHFGOIDOK_EventMusic[i].FDBNFFNFOND_CloseAt != 0 && 
					t >= ev.IJJHFGOIDOK_EventMusic[i].PDBPFJJCADD_open_at && 
					ev.IJJHFGOIDOK_EventMusic[i].FDBNFFNFOND_CloseAt >= t && 
					ev.IJJHFGOIDOK_EventMusic[i].MPLGPBNJDJB_FreeMusicId == _GHBPLHBNMBK_FreeMusicId)
					return ev.IJJHFGOIDOK_EventMusic[i].FDBNFFNFOND_CloseAt;
			}
		}
		return 0;
	}

	// // RVA: 0x1133C24 Offset: 0x1133C24 VA: 0x1133C24 Slot: 10
	public override bool GIDDKGMPIOK_IsLimited(int _GHBPLHBNMBK_FreeMusicId)
	{
		ACBAHDMEFFL_EventMission ev = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.LBDOLHGDIEB_GetDbSection(JOPOPMLFINI_QuestName) as ACBAHDMEFFL_EventMission;
		if(ev != null)
		{
			long t = NKGJPJPHLIF.HHCJCDFCLOB.IBLPICFDGOF_ServerRequester.FJDBNGEPKHL_Time.KMEFBNBFJHI_GetServerTime();
			for(int i = 0; i < ev.IJJHFGOIDOK_EventMusic.Count; i++)
			{
				if(ev.IJJHFGOIDOK_EventMusic[i].PDBPFJJCADD_open_at != 0 && 
					ev.IJJHFGOIDOK_EventMusic[i].FDBNFFNFOND_CloseAt != 0 && 
					ev.IJJHFGOIDOK_EventMusic[i].FDBNFFNFOND_CloseAt < DPJCPDKALGI_RankingEnd && 
					t >= ev.IJJHFGOIDOK_EventMusic[i].PDBPFJJCADD_open_at && 
					ev.IJJHFGOIDOK_EventMusic[i].FDBNFFNFOND_CloseAt >= t && 
					ev.IJJHFGOIDOK_EventMusic[i].MPLGPBNJDJB_FreeMusicId == _GHBPLHBNMBK_FreeMusicId)
				{
					return true;
				}
			}
		}
		return false;
	}

	// // RVA: 0x11340F0 Offset: 0x11340F0 VA: 0x11340F0 Slot: 8
	public override int OMJHBJPCFFC_GetEventBonusPercent(int _EHDDADDKMFI_f_id)
	{
		ACBAHDMEFFL_EventMission ev = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.LBDOLHGDIEB_GetDbSection(JOPOPMLFINI_QuestName) as ACBAHDMEFFL_EventMission;
		if(ev != null)
		{
			long t = NKGJPJPHLIF.HHCJCDFCLOB.IBLPICFDGOF_ServerRequester.FJDBNGEPKHL_Time.KMEFBNBFJHI_GetServerTime();
            KEODKEGFDLD_FreeMusicInfo fMusic = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.IBPAFKKEKNK_Music.NOBCLJIAMLC_GetFreeMusicData(_EHDDADDKMFI_f_id);
            EONOEHOKBEB_Music mInfo = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.IBPAFKKEKNK_Music.IAJLOELFHKC_GetMusicInfo(fMusic.DLAEJOBELBH_MusicId);
			List<int> l = new List<int>();
			for(int i = 0; i < ev.IJJHFGOIDOK_EventMusic.Count; i++)
			{
				if(ev.IJJHFGOIDOK_EventMusic[i].PLALNIIBLOF_en == 2)
				{
					if((ev.IJJHFGOIDOK_EventMusic[i].PDBPFJJCADD_open_at == 0 && ev.IJJHFGOIDOK_EventMusic[i].FDBNFFNFOND_CloseAt == 0) ||
						(t >= ev.IJJHFGOIDOK_EventMusic[i].PDBPFJJCADD_open_at && t < ev.IJJHFGOIDOK_EventMusic[i].FDBNFFNFOND_CloseAt))
					{
						KEODKEGFDLD_FreeMusicInfo fMusic2 = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.IBPAFKKEKNK_Music.NOBCLJIAMLC_GetFreeMusicData(ev.IJJHFGOIDOK_EventMusic[i].MPLGPBNJDJB_FreeMusicId);
						if(ev.IJJHFGOIDOK_EventMusic[i].MPLGPBNJDJB_FreeMusicId == _EHDDADDKMFI_f_id || ev.IJJHFGOIDOK_EventMusic[i].CJFEGGPILMF_MusicAttr == mInfo.FKDCCLPGKDK_Ma || ev.IJJHFGOIDOK_EventMusic[i].GBJBMBEABOP_SerieAttr == mInfo.AIHCEGFANAM_SerieAttr)
						{
							//LAB_0113463c
							return ev.IJJHFGOIDOK_EventMusic[i].DKHIHHMOIKM_Bonus;
						}
						if(fMusic2 != null)
						{
							if(fMusic2.DLAEJOBELBH_MusicId == mInfo.DLAEJOBELBH_MusicId)
								return ev.IJJHFGOIDOK_EventMusic[i].DKHIHHMOIKM_Bonus;
						}
						if(ev.IJJHFGOIDOK_EventMusic[i].MPLGPBNJDJB_FreeMusicId == 0 && ev.IJJHFGOIDOK_EventMusic[i].CJFEGGPILMF_MusicAttr == 0 && ev.IJJHFGOIDOK_EventMusic[i].GBJBMBEABOP_SerieAttr == 0)
							return ev.IJJHFGOIDOK_EventMusic[i].DKHIHHMOIKM_Bonus;
					}
				}
			}
        }
		return 0;
	}

	// // RVA: 0x11346A0 Offset: 0x11346A0 VA: 0x11346A0 Slot: 27
	public override int HLOGNJNGDJO_GetHelpId(int _OIPCCBHIKIA_index/* = 0*/)
	{
		ACBAHDMEFFL_EventMission ev = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.LBDOLHGDIEB_GetDbSection(JOPOPMLFINI_QuestName) as ACBAHDMEFFL_EventMission;
		if(ev != null)
		{
			return ev.NGHKJOEDLIP_Settings.EJBGHLOOLBC_HelpIds[_OIPCCBHIKIA_index];
		}
		return 0;
	}

	// // RVA: 0x113485C Offset: 0x113485C VA: 0x113485C Slot: 67
	// public override int LBNKDKDMMOK() { }

	// // RVA: 0x11349E0 Offset: 0x11349E0 VA: 0x11349E0 Slot: 28
	public override long FBGDBGKNKOD_GetCurrentPoint()
	{
		ACBAHDMEFFL_EventMission ev = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.LBDOLHGDIEB_GetDbSection(JOPOPMLFINI_QuestName) as ACBAHDMEFFL_EventMission;
		if(ev != null)
		{
			OKLMJPBJHKL_EventMission.MKIGCLOBJBI save = CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_PlayerData.MENGHOKMOIE_EventMission.FBCJICEPLED[ev.NGHKJOEDLIP_Settings.MOEKELIIDEO_SaveIdx];
			return save.DNBFMLBNAEE_Point;
		}
		return 0;
	}

	// // RVA: 0x1134C40 Offset: 0x1134C40 VA: 0x1134C40 Slot: 29
	public override void MJFKJHJJLMN_GetRanks(int LHJCOPMMIGO/* = 0*/, bool _FBBNPFFEJBN_Force/* = false*/)
	{
		NPNNPNAIONN_IsError = false;
		PLOOEECNHFB_IsDone = false;
		ACBAHDMEFFL_EventMission ev = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.LBDOLHGDIEB_GetDbSection(JOPOPMLFINI_QuestName) as ACBAHDMEFFL_EventMission;
		if(ev != null)
		{
			if(GPHEKCNDDIK)
			{
				long t = NKGJPJPHLIF.HHCJCDFCLOB.IBLPICFDGOF_ServerRequester.FJDBNGEPKHL_Time.KMEFBNBFJHI_GetServerTime();
				int get_rank_cooling_time = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.GDEKCOOBLMA_System.LPJLEHAJADA("get_rank_cooling_time", 60);
				if(_FBBNPFFEJBN_Force || t - KPOMHFLKMKI_LastRankUpdateTime[LHJCOPMMIGO] >= get_rank_cooling_time)
				{
					//LAB_01134fb0
					KKLGENJKEBN.HHCJCDFCLOB.HEOKADCEAGL_GetRanks(ev.NGHKJOEDLIP_Settings.OCGFKMHNEOF_name_for_api, () =>
					{
						//0xD8AD18
						CDINKAANIAA_Rank[LHJCOPMMIGO] = (int)KKLGENJKEBN.HHCJCDFCLOB.LPPCNCMEDFA_Rank;
						KPOMHFLKMKI_LastRankUpdateTime[LHJCOPMMIGO] = NKGJPJPHLIF.HHCJCDFCLOB.IBLPICFDGOF_ServerRequester.FJDBNGEPKHL_Time.KMEFBNBFJHI_GetServerTime();
						PLOOEECNHFB_IsDone = true;
					}, () =>
					{
						//0xD8AEDC
						KPOMHFLKMKI_LastRankUpdateTime[LHJCOPMMIGO] = NKGJPJPHLIF.HHCJCDFCLOB.IBLPICFDGOF_ServerRequester.FJDBNGEPKHL_Time.KMEFBNBFJHI_GetServerTime();
						CDINKAANIAA_Rank[LHJCOPMMIGO] = 0;
						PLOOEECNHFB_IsDone = true;
					}, () =>
					{
						//0xD8B084
						CDINKAANIAA_Rank[LHJCOPMMIGO] = 0;
						PLOOEECNHFB_IsDone = true;
						NPNNPNAIONN_IsError = true;
					}, () =>
					{
						//0xD8B11C
						CDINKAANIAA_Rank[LHJCOPMMIGO] = 0;
						PLOOEECNHFB_IsDone = true;
						FKKDIDMGLMI_IsDroppedPlayer = true;
					});
					return;
				}
				else
				{
					PLOOEECNHFB_IsDone = true;
					return;
				}
			}
		}
		CDINKAANIAA_Rank[LHJCOPMMIGO] = 0;
		PLOOEECNHFB_IsDone = true;
	}

	// // RVA: 0x1135118 Offset: 0x1135118 VA: 0x1135118 Slot: 30
	protected override bool JIHMLILFOPG_IsEventActive(long _JHNMKKNEENE_Time)
	{
		ACBAHDMEFFL_EventMission ev/*IBDNLLEGAJD*/ = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.LBDOLHGDIEB_GetDbSection(JOPOPMLFINI_QuestName) as ACBAHDMEFFL_EventMission;
		if(ev != null)
		{
			GDIPLANPCEI g = IMMAOANGPNK.HHCJCDFCLOB.ACEFBFLFKFD_GetScheduleEventData(ev.JIKKNHIAEKG_BlockName, _JHNMKKNEENE_Time);
			if(g != null)
			{
				if(_JHNMKKNEENE_Time >= ev.NGHKJOEDLIP_Settings.BONDDBOFBND_RankingStart && ev.NGHKJOEDLIP_Settings.KNLGKBBIBOH_RewardEnd2 >= _JHNMKKNEENE_Time)
				{
					if(ev.NGHKJOEDLIP_Settings.HKKNEAGCIEB_RankingSupport != 0)
					{
						if(KKLGENJKEBN.HHCJCDFCLOB.JPDPFGFMKHK_rankings.Find((EECOJKDJIFG PKLPKMLGFGK) =>
						{
							//0xD8B1BC
							return ev.NGHKJOEDLIP_Settings.OCGFKMHNEOF_name_for_api == PKLPKMLGFGK.OCGFKMHNEOF_name_for_api;
						}) != null)
						{
							return true;
						}
						else
						{
							Debug.LogError("Event can't start, ranking not found : "+ev.NGHKJOEDLIP_Settings.OCGFKMHNEOF_name_for_api);
						}
					}
					else
						return true;
				}
			}
		}
		return false;
	}

	// // RVA: 0x1135434 Offset: 0x1135434 VA: 0x1135434 Slot: 31
	protected override bool IMCMNOPNGHO(long _JHNMKKNEENE_Time)
	{
		ACBAHDMEFFL_EventMission ev = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.LBDOLHGDIEB_GetDbSection(JOPOPMLFINI_QuestName) as ACBAHDMEFFL_EventMission;
		if(ev != null)
		{
			OKLMJPBJHKL_EventMission.MKIGCLOBJBI save = CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_PlayerData.MENGHOKMOIE_EventMission.FBCJICEPLED[ev.NGHKJOEDLIP_Settings.MOEKELIIDEO_SaveIdx];
			AGLILDLEFDK_Missions = ev.NNMPGOAGEOL_quests;
			OLDFFDMPEBM_Quests = save.NNMPGOAGEOL_quests;
			if(save.MPCAGEPEJJJ_Key != ev.NGHKJOEDLIP_Settings.OCGFKMHNEOF_name_for_api || save.EGBOHDFBAPB_CloseAt == 0 || (!RuntimeSettings.CurrentSettings.UnlimitedEvent && save.EGBOHDFBAPB_CloseAt < ev.NGHKJOEDLIP_Settings.BONDDBOFBND_RankingStart))
			{
				save.LHPDDGIJKNB_Reset();
				save.MPCAGEPEJJJ_Key = ev.NGHKJOEDLIP_Settings.OCGFKMHNEOF_name_for_api;
				save.EGBOHDFBAPB_CloseAt = ev.NGHKJOEDLIP_Settings.IDDBFFBPNGI_RewardEnd;
				save.LGADCGFMLLD_step = 1;
				save.BEBJKJKBOGH_Date = _JHNMKKNEENE_Time;
				KOMAHOAEMEK(true);
			}
			KOMAHOAEMEK(false);
			return true;
		}
		return false;
	}

	// // RVA: 0x1135790 Offset: 0x1135790 VA: 0x1135790 Slot: 40
	protected override void KKFLDCBHFJA(long _JHNMKKNEENE_Time)
	{
		ACBAHDMEFFL_EventMission ev/*IBDNLLEGAJD*/ = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.LBDOLHGDIEB_GetDbSection(JOPOPMLFINI_QuestName) as ACBAHDMEFFL_EventMission;
		if(ev != null)
		{
			IBNKPMPFLGI_IsRankReward = ev.NGHKJOEDLIP_Settings.HKKNEAGCIEB_RankingSupport != 0;
			if(IBNKPMPFLGI_IsRankReward)
			{
				KBACNOCOANM_Ranking = KKLGENJKEBN.HHCJCDFCLOB.JPDPFGFMKHK_rankings.Find((EECOJKDJIFG PKLPKMLGFGK) =>
				{
					//0xD8B224
					return ev.NGHKJOEDLIP_Settings.OCGFKMHNEOF_name_for_api == PKLPKMLGFGK.OCGFKMHNEOF_name_for_api;
				});
				GPHEKCNDDIK = true;
			}
			DGCOMDILAKM_EventName = ev.NGHKJOEDLIP_Settings.OPFGFINHFCE_name;
			DOLJEDAAKNN_RankingName = ev.NGHKJOEDLIP_Settings.HEDAGCNPHGD_RankingName;
			GLIMIGNNGGB_RankingStart = ev.NGHKJOEDLIP_Settings.BONDDBOFBND_RankingStart;
			DPJCPDKALGI_RankingEnd = ev.NGHKJOEDLIP_Settings.HPNOGLIFJOP_RankingEnd;
			LOLAANGCGDO_RankingEnd2 = ev.NGHKJOEDLIP_Settings.LNFKGHNHJKE_RankingEnd2;
			JDDFILGNGFH_RewardStart = ev.NGHKJOEDLIP_Settings.JGMDAOACOJF_RewardStart;
			LJOHLEGGGMC_RewardEnd = ev.NGHKJOEDLIP_Settings.IDDBFFBPNGI_RewardEnd;
			EMEKFFHCHMH_RewardEnd2 = ev.NGHKJOEDLIP_Settings.KNLGKBBIBOH_RewardEnd2;
			PGIIDPEGGPI_EventId = ev.NGHKJOEDLIP_Settings.OBGBAOLONDD_UniqueId;
			NHGPCLGPEHH_TicketType = ev.NGHKJOEDLIP_Settings.MJBKGOJBPAD_item_type;
			FBHONHONKGD_MusicSelectDesc = ev.NGHKJOEDLIP_Settings.FEMMDNIELFC_Desc;
			HGLAFGHHFKP = ev.NGHKJOEDLIP_Settings.JHPCPNJJHLI_RankingThreshold;
			GFIBLLLHMPD_StartAdventureId = ev.NGHKJOEDLIP_Settings.HIOOGLEJBKM_StartAdventureId;
			CAKEOPLJDAF_EndAdventureId = ev.NGHKJOEDLIP_Settings.FJCADCDNPMP_EndAdventureId;
			LHAKGDAGEMM_EpBonusInfos.Clear();
			for(int i = 0; i < ev.LHAKGDAGEMM_EpBonusInfos.Count; i++)
			{
				CEGDBNNIDIG d = new CEGDBNNIDIG();
				d.KELFCMEOPPM_EpisodeId = ev.LHAKGDAGEMM_EpBonusInfos[i].KHPHAAMGMJP_EpId;
				d.MIHNKIHNBBL_BaseBonus = ev.LHAKGDAGEMM_EpBonusInfos[i].OFIAENKCJME_BaseBonus / 100.0f;
				d.MLLPMJFOKEC_GachaIds.AddRange(ev.LHAKGDAGEMM_EpBonusInfos[i].KDNMBOBEGJM_GachaIds);
				LHAKGDAGEMM_EpBonusInfos.Add(d);
			}
			PGDAMNENGDA_EpBonusBySceneRarity.Clear();
			for(int i = 0; i < ev.OGMHMAGDNAM_EpBonusBySceneRarity.Count; i++)
			{
				NJJDBBCHBNP d = new NJJDBBCHBNP();
				d.GJEADBKFAPA = ev.OGMHMAGDNAM_EpBonusBySceneRarity[i].PPFNGGCBJKC_id;
				d.IJKFFIKGLJM_BonusBefore = ev.OGMHMAGDNAM_EpBonusBySceneRarity[i].GNFBMCGMCFO_BonusBefore;
				d.DCBMFNOIENM_BonusAfter = ev.OGMHMAGDNAM_EpBonusBySceneRarity[i].BFFGFAMJAIG_BonusAfter;
				PGDAMNENGDA_EpBonusBySceneRarity.Add(d);
			}
			DHOMAEOEFMJ_EpBonuByScene.Clear();
			for(int i = 0; i < ev.GEGAEDDGNMA_Bonuses.Count; i++)
			{
				MEBJJBHPMEO d = new MEBJJBHPMEO();
				d.PPFNGGCBJKC_id = ev.GEGAEDDGNMA_Bonuses[i].PPFNGGCBJKC_id;
				d.GNFBMCGMCFO_BonusBefore = ev.GEGAEDDGNMA_Bonuses[i].GNFBMCGMCFO_BonusBefore;
				d.BFFGFAMJAIG_BonusAfter = ev.GEGAEDDGNMA_Bonuses[i].BFFGFAMJAIG_BonusAfter;
				d.CNKFPJCGNFE_SceneId = ev.GEGAEDDGNMA_Bonuses[i].CNKFPJCGNFE_SceneId;
				DHOMAEOEFMJ_EpBonuByScene.Add(d);
			}
			MBHDIJJEOFL = ev.MBHDIJJEOFL;
			LEPALMDKEOK_IsPointReward = true;
			PJLNJJIBFBN_HasExtremeDiff = ev.NGHKJOEDLIP_Settings.AHKPNPNOAMO_ExtreamOpen != 0;
			for(int i = 0; i < KPOMHFLKMKI_LastRankUpdateTime.Length; i++)
			{
				KPOMHFLKMKI_LastRankUpdateTime[i] = 0;
			}
			if(!string.IsNullOrEmpty(ev.NGHKJOEDLIP_Settings.OMCAOJJGOGG_Lb))
			{
				string[] strs = ev.NGHKJOEDLIP_Settings.OMCAOJJGOGG_Lb.Split(new char[]{','});
				MFDJIFIIPJD d = new MFDJIFIIPJD();
				d.KHEKNNFCAOI_Init(int.Parse(strs[0]), int.Parse(strs[1]));
				BHABCGJCGNO = d;
			}
			GPHEKCNDDIK = true;
		}
	}

	// // RVA: 0x1136474 Offset: 0x1136474 VA: 0x1136474 Slot: 43
	protected override void FCHGHAAPIBH()
	{
		ACBAHDMEFFL_EventMission ev/*NDFIEMPPMLF_master*/ = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.LBDOLHGDIEB_GetDbSection(JOPOPMLFINI_QuestName) as ACBAHDMEFFL_EventMission;
		if(ev != null)
		{
			Dictionary<string,int> DBEKEBNDMBH_SaveIdx = new Dictionary<string, int>();
			string s = ev.NGHKJOEDLIP_Settings.OCDMGOGMHGE_RewardPrefix;
			List<string> ls = new List<string>();
			for(int i = 0; i < ev.FCIPEDFHFEM_TotalRewards.Count; i++)
			{
				for(int j = 0; j < ev.FCIPEDFHFEM_TotalRewards[i].AHJNPEAMCCH_Rewards.Count; j++)
				{
					if(ev.FCIPEDFHFEM_TotalRewards[i].AHJNPEAMCCH_Rewards[j].NMKEOMCMIPP_RewardId > 0)
					{
						string s1 = s + ev.FCIPEDFHFEM_TotalRewards[i].AHJNPEAMCCH_Rewards[j].NMKEOMCMIPP_RewardId.ToString();
						ls.Add(s1);
						DBEKEBNDMBH_SaveIdx.Add(s1, i);
					}
				}
			}
			if(ls.Count == 0)
			{
				PIMFJALCIGK();
			}
			else
			{
				JGMEFHJCNHP_GetAchievementRecords r = NKGJPJPHLIF.HHCJCDFCLOB.IBLPICFDGOF_ServerRequester.IFFNCAFNEAG_AddRequest(new JGMEFHJCNHP_GetAchievementRecords());
				r.KMOBDLBKAAA_Repeatable = true;
				r.MIDAMHNABAJ_Keys = ls;
				r.BHFHGFKBOHH_OnSuccess = (CACGCMBKHDI_Request NHECPMNKEFK) =>
				{
					//0xD8B28C
					JGMEFHJCNHP_GetAchievementRecords req = NHECPMNKEFK as JGMEFHJCNHP_GetAchievementRecords;
					OKLMJPBJHKL_EventMission.MKIGCLOBJBI save = CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_PlayerData.MENGHOKMOIE_EventMission.FBCJICEPLED[ev.NGHKJOEDLIP_Settings.MOEKELIIDEO_SaveIdx];
					for(int i = 0; i < req.NFEAMMJIMPG_Result.CEDLLCCONJP_AchievementPrizes.Count; i++)
					{
						if(DBEKEBNDMBH_SaveIdx.ContainsKey(req.NFEAMMJIMPG_Result.CEDLLCCONJP_AchievementPrizes[i].LJNAKDMILMC_key))
						{
							if(req.NFEAMMJIMPG_Result.CEDLLCCONJP_AchievementPrizes[i].OOIJCMLEAJP_is_received)
							{
								save.LCDIGDMGPGO_TRcv[DBEKEBNDMBH_SaveIdx[req.NFEAMMJIMPG_Result.CEDLLCCONJP_AchievementPrizes[i].LJNAKDMILMC_key]] = 1;
							}
						}
					}
					PIMFJALCIGK();
					PLOOEECNHFB_IsDone = true;
				};
				r.MOBEEPPKFLG_OnFail = (CACGCMBKHDI_Request NHECPMNKEFK) =>
				{
					//0xD8B748
					PLOOEECNHFB_IsDone = true;
					NPNNPNAIONN_IsError = true;
				};
				return;
			}
		}
		PLOOEECNHFB_IsDone = true;
	}

	// [IteratorStateMachineAttribute] // RVA: 0x6BCD6C Offset: 0x6BCD6C VA: 0x6BCD6C
	// // RVA: 0x1136B28 Offset: 0x1136B28 VA: 0x1136B28 Slot: 44
	protected override IEnumerator JEIJKLPOAHP_ReceivePrologueRepeatedAchievement(DJBHIFLHJLK _AOCANKOMKFG_OnError)
	{
		//0xD8E56C
		KGBCKPKLKHM_RewardItems.Clear();
		ACBAHDMEFFL_EventMission ev = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.LBDOLHGDIEB_GetDbSection(JOPOPMLFINI_QuestName) as ACBAHDMEFFL_EventMission;
		if(ev != null)
		{
			string s = ev.EFEGBHACJAL("event_prologue_achv_key", "");
			if(!string.IsNullOrEmpty(s))
			{
				List<string> ls = new List<string>();
				ls.Add(s);
				yield return Co.R(AOGIMHOLIFB_ReceiveLoguinRepetedAchivement(ls, _AOCANKOMKFG_OnError));
			}
		}
	}

	// [IteratorStateMachineAttribute] // RVA: 0x6BCDE4 Offset: 0x6BCDE4 VA: 0x6BCDE4
	// // RVA: 0x1136BCC Offset: 0x1136BCC VA: 0x1136BCC Slot: 45
	protected override IEnumerator KPBNMAEHHDF_ReceiveEpilogueRepeatedAchivement(DJBHIFLHJLK _AOCANKOMKFG_OnError)
	{
		//0xD8E21C
		KGBCKPKLKHM_RewardItems.Clear();
		ACBAHDMEFFL_EventMission ev = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.LBDOLHGDIEB_GetDbSection(JOPOPMLFINI_QuestName) as ACBAHDMEFFL_EventMission;
		if(ev != null)
		{
			string s = ev.EFEGBHACJAL("event_epilogue_achv_key", "");
			if(!string.IsNullOrEmpty(s))
			{
				List<string> ls = new List<string>();
				ls.Add(s);
				yield return Co.R(AOGIMHOLIFB_ReceiveLoguinRepetedAchivement(ls, _AOCANKOMKFG_OnError));
			}
		}
	}

	// // RVA: 0x1136C70 Offset: 0x1136C70 VA: 0x1136C70
	private bool GGJCIDOCOOM(long _JHNMKKNEENE_Time, int OHAFIGFCBMK, out int EAKEMMMBBKN)
	{
		EAKEMMMBBKN = 0;
		ACBAHDMEFFL_EventMission ev = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.LBDOLHGDIEB_GetDbSection(JOPOPMLFINI_QuestName) as ACBAHDMEFFL_EventMission;
		if(ev != null)
		{
			OKLMJPBJHKL_EventMission.MKIGCLOBJBI save = CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_PlayerData.MENGHOKMOIE_EventMission.FBCJICEPLED[ev.NGHKJOEDLIP_Settings.MOEKELIIDEO_SaveIdx];
			string s1 = MessageManager.Instance.GetMessage("menu", "missionevent_bonus_date_format");
			string s2 = MessageManager.Instance.GetMessage("menu", "missionevent_bonus_limit_format");
			string s3 = MessageManager.Instance.GetMessage("menu", "missionevent_bonus_target_format");
			OEFLDPCOCNP.Clear();
			bool b = false;
			bool b2 = false;
			if(OHAFIGFCBMK > 0 && save.LCBFDCAJHFG_LstBns != 0)
			{
				for(int i = 0; i < ev.IJJHFGOIDOK_EventMusic.Count; i++)
				{
					if(ev.IJJHFGOIDOK_EventMusic[i].PLALNIIBLOF_en == 2)
					{
						if(ev.IJJHFGOIDOK_EventMusic[i].PDBPFJJCADD_open_at == 0 && ev.IJJHFGOIDOK_EventMusic[i].FDBNFFNFOND_CloseAt == 0 && ev.IJJHFGOIDOK_EventMusic[i].MPLGPBNJDJB_FreeMusicId == OHAFIGFCBMK)
						{
							b = true;
							break;
						}
						if(save.LCBFDCAJHFG_LstBns >= ev.IJJHFGOIDOK_EventMusic[i].PDBPFJJCADD_open_at && 
							save.LCBFDCAJHFG_LstBns < ev.IJJHFGOIDOK_EventMusic[i].FDBNFFNFOND_CloseAt)
						{
							if(ev.IJJHFGOIDOK_EventMusic[i].MPLGPBNJDJB_FreeMusicId == 0)
							{
								if(ev.IJJHFGOIDOK_EventMusic[i].CJFEGGPILMF_MusicAttr == 0)
								{
									if(ev.IJJHFGOIDOK_EventMusic[i].GBJBMBEABOP_SerieAttr == 0)
										break;
									KEODKEGFDLD_FreeMusicInfo fInfo = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.IBPAFKKEKNK_Music.NOBCLJIAMLC_GetFreeMusicData(OHAFIGFCBMK);
									b = ev.IJJHFGOIDOK_EventMusic[i].GBJBMBEABOP_SerieAttr == IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.IBPAFKKEKNK_Music.IAJLOELFHKC_GetMusicInfo(fInfo.DLAEJOBELBH_MusicId).AIHCEGFANAM_SerieAttr;
								}
								else
								{
									KEODKEGFDLD_FreeMusicInfo fInfo = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.IBPAFKKEKNK_Music.NOBCLJIAMLC_GetFreeMusicData(OHAFIGFCBMK);
									b = ev.IJJHFGOIDOK_EventMusic[i].CJFEGGPILMF_MusicAttr == IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.IBPAFKKEKNK_Music.IAJLOELFHKC_GetMusicInfo(fInfo.DLAEJOBELBH_MusicId).FKDCCLPGKDK_Ma;
								}
							}
							else
							{
								b = ev.IJJHFGOIDOK_EventMusic[i].MPLGPBNJDJB_FreeMusicId == OHAFIGFCBMK;
							}
							break;
						}
					}
				}
				bool b3 = false;
				for(int i = 0; i < ev.IJJHFGOIDOK_EventMusic.Count; i++)
				{
					if(ev.IJJHFGOIDOK_EventMusic[i].PLALNIIBLOF_en == 2)
					{
						bool b7;
						string s;
						MNIIDKPECMD type;
						if(ev.IJJHFGOIDOK_EventMusic[i].PDBPFJJCADD_open_at == 0 && ev.IJJHFGOIDOK_EventMusic[i].FDBNFFNFOND_CloseAt == 0)
						{
							b7 = true;
						}
						else
						{
							b7 = false;
							bool b4 = _JHNMKKNEENE_Time < ev.IJJHFGOIDOK_EventMusic[i].PDBPFJJCADD_open_at || _JHNMKKNEENE_Time > ev.IJJHFGOIDOK_EventMusic[i].FDBNFFNFOND_CloseAt;
							if(b2 || save.LCBFDCAJHFG_LstBns != 0)
							{
								bool b5 = save.LCBFDCAJHFG_LstBns < ev.IJJHFGOIDOK_EventMusic[i].PDBPFJJCADD_open_at || save.LCBFDCAJHFG_LstBns > ev.IJJHFGOIDOK_EventMusic[i].FDBNFFNFOND_CloseAt;
								b2 = b4 != b5;
							}
						}
						bool b6 = _JHNMKKNEENE_Time >= ev.IJJHFGOIDOK_EventMusic[i].PDBPFJJCADD_open_at && _JHNMKKNEENE_Time < ev.IJJHFGOIDOK_EventMusic[i].FDBNFFNFOND_CloseAt;
						int v = 0;
						if(ev.IJJHFGOIDOK_EventMusic[i].MPLGPBNJDJB_FreeMusicId == 0)
						{
							if(ev.IJJHFGOIDOK_EventMusic[i].CJFEGGPILMF_MusicAttr == 0)
							{
								if(ev.IJJHFGOIDOK_EventMusic[i].GBJBMBEABOP_SerieAttr == 0)
								{
									s = MessageManager.Instance.GetMessage("menu", "missionevent_bonus_all");
									b3 |= b6 | b7;
									type = MNIIDKPECMD.CEPMMEKKNGC_3_All;
								}
								else
								{
									v = ev.IJJHFGOIDOK_EventMusic[i].GBJBMBEABOP_SerieAttr;
									s = MessageManager.Instance.GetMessage("menu", string.Format("missionevent_bonus_series_attribute{0:D3}", ev.IJJHFGOIDOK_EventMusic[i].GBJBMBEABOP_SerieAttr));
									type = MNIIDKPECMD.LNAOAANJGDM_1_SerieAttr;
									if(OHAFIGFCBMK > 0 && (b6 || b7))
									{
										KEODKEGFDLD_FreeMusicInfo fInfo = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.IBPAFKKEKNK_Music.NOBCLJIAMLC_GetFreeMusicData(OHAFIGFCBMK);
										b3 |= ev.IJJHFGOIDOK_EventMusic[i].GBJBMBEABOP_SerieAttr == IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.IBPAFKKEKNK_Music.IAJLOELFHKC_GetMusicInfo(fInfo.DLAEJOBELBH_MusicId).AIHCEGFANAM_SerieAttr;
									}
								}
							}
							else
							{
								v = ev.IJJHFGOIDOK_EventMusic[i].CJFEGGPILMF_MusicAttr;
								s = MessageManager.Instance.GetMessage("menu", string.Format("missionevent_bonus_music_attribute{0:D3}{0:D3}", ev.IJJHFGOIDOK_EventMusic[i].CJFEGGPILMF_MusicAttr));
								type = MNIIDKPECMD.OLFDHLDEPKO_2_MusicAttr;
								if(OHAFIGFCBMK > 0 && (b6 || b7))
								{
									KEODKEGFDLD_FreeMusicInfo fInfo = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.IBPAFKKEKNK_Music.NOBCLJIAMLC_GetFreeMusicData(OHAFIGFCBMK);
									b3 |= ev.IJJHFGOIDOK_EventMusic[i].CJFEGGPILMF_MusicAttr == IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.IBPAFKKEKNK_Music.IAJLOELFHKC_GetMusicInfo(fInfo.DLAEJOBELBH_MusicId).FKDCCLPGKDK_Ma;
								}
							}
						}
						else
						{
							s = "";
							type = MNIIDKPECMD.HIFIGCJNJDO_0_MusicId;
							if(b6 || b7)
							{
								b3 |= ev.IJJHFGOIDOK_EventMusic[i].MPLGPBNJDJB_FreeMusicId == OHAFIGFCBMK;
							}
						}
                        System.DateTime d1 = Utility.GetLocalDateTime(ev.IJJHFGOIDOK_EventMusic[i].PDBPFJJCADD_open_at);
                        System.DateTime d2 = Utility.GetLocalDateTime(ev.IJJHFGOIDOK_EventMusic[i].FDBNFFNFOND_CloseAt);
						OEFLDPCOCNP.Add(new HLMINENBCKO()
						{
							HJAFPEBIBOP_Limit = string.Format(s2, d1.ToString(s1), d2.ToString(s1)),
							GJLFANGDGCL_Target = string.Format(s3, s),
							CIANOCNPIFF_Type = type,
							IIAAIPNHJFJ_Value = v,
							IPJMPBANBPP_Enabled = b6 || b7,
							AAMJNIDEAHC = b7
						});
                    }
				}
				if(!(b3 | !b))
					EAKEMMMBBKN = 1;
				save.LCBFDCAJHFG_LstBns = _JHNMKKNEENE_Time;
			}
			return b2;
		}
		return false;
	}

	// // RVA: 0x1137D20 Offset: 0x1137D20 VA: 0x1137D20 Slot: 46
	protected override void PJDGDNJNCNM_UpdateStatusImpl(long _JHNMKKNEENE_Time)
	{
		ACBAHDMEFFL_EventMission ev = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.LBDOLHGDIEB_GetDbSection(JOPOPMLFINI_QuestName) as ACBAHDMEFFL_EventMission;
		if(ev != null)
		{
			KIBBLLADDPO = false;
			OKLMJPBJHKL_EventMission.MKIGCLOBJBI save = CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_PlayerData.MENGHOKMOIE_EventMission.FBCJICEPLED[ev.NGHKJOEDLIP_Settings.MOEKELIIDEO_SaveIdx];
			IBLPKJJNNIG = false;
			BELBNINIOIE = false;
			if(_JHNMKKNEENE_Time >= ev.NGHKJOEDLIP_Settings.BONDDBOFBND_RankingStart)
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
					//LAB_01138068
					if(!save.IMFBCJOIJKJ_Entry)
					{
						NGOFCFJHOMI_Status = KGCNCBOKCBA.GNENJEHKMHD_EventStatus.NCJFJLPJMLI_2;
						if(_JHNMKKNEENE_Time < ev.NGHKJOEDLIP_Settings.EHHFFKAFOMC)
						{
							return;
						}
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
					if(!save.ABBJBPLHFHA_Spurt)
					{
						if(_JHNMKKNEENE_Time >= ev.NGHKJOEDLIP_Settings.EHHFFKAFOMC)
						{
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
						NGOFCFJHOMI_Status = KGCNCBOKCBA.GNENJEHKMHD_EventStatus.MINDIGBAJFG_3;
					}
					else
					{
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
						NGOFCFJHOMI_Status = KGCNCBOKCBA.GNENJEHKMHD_EventStatus.MEAJLPAHINL_ChallengePeriod_5;
					}
				}
				else if(_JHNMKKNEENE_Time >= ev.NGHKJOEDLIP_Settings.JGMDAOACOJF_RewardStart)
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
							NGOFCFJHOMI_Status = KGCNCBOKCBA.GNENJEHKMHD_EventStatus.DDEODFNANDO_8_ResultRewardToReceive;
						else
							NGOFCFJHOMI_Status = KGCNCBOKCBA.GNENJEHKMHD_EventStatus.BCKENOKGLIJ_9_ResultRewardreceived;
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
		}
		else
		{
			NGOFCFJHOMI_Status = KGCNCBOKCBA.GNENJEHKMHD_EventStatus.HJNNKCMLGFL_0_None;
			KIBBLLADDPO = false;
		}
	}

	// // RVA: 0x1138374 Offset: 0x1138374 VA: 0x1138374 Slot: 47
	public override void NBMDAOFPKGK(int _DNBFMLBNAEE_Point)
	{
		ACBAHDMEFFL_EventMission ev = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.LBDOLHGDIEB_GetDbSection(JOPOPMLFINI_QuestName) as ACBAHDMEFFL_EventMission;
		if(ev != null)
		{
			OKLMJPBJHKL_EventMission.MKIGCLOBJBI save = CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_PlayerData.MENGHOKMOIE_EventMission.FBCJICEPLED[ev.NGHKJOEDLIP_Settings.MOEKELIIDEO_SaveIdx];
			save.DNBFMLBNAEE_Point += _DNBFMLBNAEE_Point;
			save.NFIOKIBPJCJ_uptime = NKGJPJPHLIF.HHCJCDFCLOB.IBLPICFDGOF_ServerRequester.FJDBNGEPKHL_Time.KMEFBNBFJHI_GetServerTime();
		}
	}

	// // RVA: 0x11386C4 Offset: 0x11386C4 VA: 0x11386C4 Slot: 48
	public override void AMKJFGLEJGE_RequestUpdateEventPoint(int KPIILHGOGJD)
	{
		return;
	}

	// // RVA: 0x11386C8 Offset: 0x11386C8 VA: 0x11386C8 Slot: 49
	protected override void ODPJGHOJIOH(int LHJCOPMMIGO)
	{
		if(KBACNOCOANM_Ranking != null)
		{
			ACBAHDMEFFL_EventMission ev/*IBDNLLEGAJD*/ = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.LBDOLHGDIEB_GetDbSection(JOPOPMLFINI_QuestName) as ACBAHDMEFFL_EventMission;
			if(ev != null)
			{
				if(ev.NGHKJOEDLIP_Settings == null)
					return;
				OKLMJPBJHKL_EventMission.MKIGCLOBJBI save/*NHLBKJCPLBL*/ = CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_PlayerData.MENGHOKMOIE_EventMission.FBCJICEPLED[ev.NGHKJOEDLIP_Settings.MOEKELIIDEO_SaveIdx];
				PJDGDNJNCNM_UpdateStatusImpl(NKGJPJPHLIF.HHCJCDFCLOB.IBLPICFDGOF_ServerRequester.FJDBNGEPKHL_Time.KMEFBNBFJHI_GetServerTime());
				if(IBNKPMPFLGI_IsRankReward || NGOFCFJHOMI_Status == KGCNCBOKCBA.GNENJEHKMHD_EventStatus.NCJFJLPJMLI_2 ||
					NGOFCFJHOMI_Status == KGCNCBOKCBA.GNENJEHKMHD_EventStatus.MINDIGBAJFG_3 ||
					NGOFCFJHOMI_Status == KGCNCBOKCBA.GNENJEHKMHD_EventStatus.MEAJLPAHINL_ChallengePeriod_5 ||
					NGOFCFJHOMI_Status == KGCNCBOKCBA.GNENJEHKMHD_EventStatus.EMAMLLFAOJI_Counting_6) //0x6cU
				{
					KKLGENJKEBN.HHCJCDFCLOB.LDOBHAAIDEJ_UpdateRankingScore(ev.NGHKJOEDLIP_Settings.OCGFKMHNEOF_name_for_api, LHJCOPMMIGO, BOAGCEOHJEO.GOAOBNBGDBJ(GLIMIGNNGGB_RankingStart, LOLAANGCGDO_RankingEnd2, save.NFIOKIBPJCJ_uptime, save.DNBFMLBNAEE_Point), () =>
					{
						//0xD8B794
						CDINKAANIAA_Rank[LHJCOPMMIGO] = (int)KKLGENJKEBN.HHCJCDFCLOB.LPPCNCMEDFA_Rank;
						PLOOEECNHFB_IsDone = true;
						int ranking_point_max = ev.LPJLEHAJADA("ranking_point_max", 1000000);
						ILCCJNDFFOB.HHCJCDFCLOB.NNFGBBCHLPC(PGIIDPEGGPI_EventId, "StringLiteral_10929", EJDJIBPKKNO_BasePoint, save.DNBFMLBNAEE_Point, ranking_point_max, KKLGENJKEBN.HHCJCDFCLOB.DFBALJAPHMC_DroppedPlayer);
					}, () =>
					{
						//0xD8B9CC
						PLOOEECNHFB_IsDone = true;
					}, () =>
					{
						//0xD8B9F4
						PLOOEECNHFB_IsDone = true;
						NPNNPNAIONN_IsError = true;
					});
					return;
				}
			}
		}
		PLOOEECNHFB_IsDone = true;
	}

	// // RVA: 0x1138BE8 Offset: 0x1138BE8 VA: 0x1138BE8 Slot: 50
	protected override void MFJFBNPLFBE_OnReceieveTotalReward(bool GIPBIDFJFLL)
	{
		ACBAHDMEFFL_EventMission ev = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.LBDOLHGDIEB_GetDbSection(JOPOPMLFINI_QuestName) as ACBAHDMEFFL_EventMission;
		if(ev != null)
		{
			if(CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_PlayerData.MENGHOKMOIE_EventMission.PFAKPFKJJKA() == null)
			{
				OKLMJPBJHKL_EventMission.MKIGCLOBJBI save = CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_PlayerData.MENGHOKMOIE_EventMission.FBCJICEPLED[ev.NGHKJOEDLIP_Settings.MOEKELIIDEO_SaveIdx];
				JANMJPOKLFL_InventoryUtil.JCHLONCMPAJ();
				JOFBHHHLBBN_Rewards.Clear();
				List<string> ls = new List<string>(3);
				List<int> li = new List<int>(3);
				StringBuilder str = new StringBuilder();
				long pt = FBGDBGKNKOD_GetCurrentPoint();
				for(int i = 0; i < ev.FCIPEDFHFEM_TotalRewards.Count; i++)
				{
					if(pt >= ev.FCIPEDFHFEM_TotalRewards[i].DNBFMLBNAEE_Point)
					{
						if(!save.BHIAKGKHKGD(i))
						{
							str.Length = 0;
							str.Append(PGIIDPEGGPI_EventId);
							str.Append(':');
							str.Append(i);
							str.Append(':');
							str.Append(ev.FCIPEDFHFEM_TotalRewards[i].DNBFMLBNAEE_Point);
							JANMJPOKLFL_InventoryUtil.FEGDNPIEKJC(OAGBCBBHMPF.COIIJOEKBDH.MGEFPKOJKBL_9, str.ToString());
							for(int j = 0; j < ev.FCIPEDFHFEM_TotalRewards[i].AHJNPEAMCCH_Rewards.Count; j++)
							{
								if(ev.FCIPEDFHFEM_TotalRewards[i].AHJNPEAMCCH_Rewards[j].NMKEOMCMIPP_RewardId > 0)
								{
									ls.Add(ev.NGHKJOEDLIP_Settings.OCDMGOGMHGE_RewardPrefix + ev.FCIPEDFHFEM_TotalRewards[i].AHJNPEAMCCH_Rewards[j].NMKEOMCMIPP_RewardId);
									li.Add((int)(ev.FCIPEDFHFEM_TotalRewards[i].AHJNPEAMCCH_Rewards[j].PJPDOCNJNGJ ? ev.NGHKJOEDLIP_Settings.JBFDHOIKAIK_InventoryEndDate : -1));
								}
								JANMJPOKLFL_InventoryUtil.CPIICACGNBH_AddItem(CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_PlayerData, ev.FCIPEDFHFEM_TotalRewards[i].AHJNPEAMCCH_Rewards[j].GLCLFMGPMAN_ItemId, ev.FCIPEDFHFEM_TotalRewards[i].AHJNPEAMCCH_Rewards[j].HMFFHLPNMPH_Count, null, 0);
								save.IPNLHCLFIDB(i, true);
							}
							JOFBHHHLBBN_Rewards.Add(i);
						}
					}
				}
				if(ls.Count > 0)
				{
					if(GIPBIDFJFLL)
					{
						FLONELKGABJ_ClaimAchievementPrizes r = NKGJPJPHLIF.HHCJCDFCLOB.IBLPICFDGOF_ServerRequester.IFFNCAFNEAG_AddRequest(new FLONELKGABJ_ClaimAchievementPrizes());
						r.KMOBDLBKAAA_Repeatable = true;
						r.NBFDEFGFLPJ = OHJOJKNLHOK;
						r.MIDAMHNABAJ_Keys = ls;
						r.MEGNAIJPBFF_InventoryClosedAt = li;
						r.BHFHGFKBOHH_OnSuccess = (CACGCMBKHDI_Request NHECPMNKEFK) =>
						{
							//0x11417FC
							PLOOEECNHFB_IsDone = true;
							DENHAAGACPD();
						};
						r.MOBEEPPKFLG_OnFail = (CACGCMBKHDI_Request NHECPMNKEFK) =>
						{
							//0x1141808
							if(NHECPMNKEFK.CJMFJOMECKI_ErrorId == SakashoErrorId.ACHIEVEMENT_PRIZE_ALREADY_RECEIVED)
							{
								DENHAAGACPD();
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
				}
				DENHAAGACPD();
			}
			else
			{
				NPNNPNAIONN_IsError = true;
			}
			PLOOEECNHFB_IsDone = true;
		}
	}

	// // RVA: 0x1139B70 Offset: 0x1139B70 VA: 0x1139B70 Slot: 52
	public override void FAMFKPBPIAA_GetRankingPlayerList(bool PFFJNEFNAMI, int CJHEHIMLGGL, int LHJCOPMMIGO, LIOLBKLMMIK _KLMFJJCNBIP_OnSuccess, DJBHIFLHJLK _IDAEHNGOKAE_OnRankingError, DJBHIFLHJLK _JGKOLBLPMPG_OnFail)
	{
		NPNNPNAIONN_IsError = false;
		PLOOEECNHFB_IsDone = false;
		ACBAHDMEFFL_EventMission ev = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.LBDOLHGDIEB_GetDbSection(JOPOPMLFINI_QuestName) as ACBAHDMEFFL_EventMission;
		if(ev != null)
		{
			if(IBNKPMPFLGI_IsRankReward)
			{
				KKLGENJKEBN.HHCJCDFCLOB.FAMFKPBPIAA_GetRankingPlayerList(KBACNOCOANM_Ranking.OCGFKMHNEOF_name_for_api, PFFJNEFNAMI, CJHEHIMLGGL, LHJCOPMMIGO, (int NEFEFHBHFFF, List<IBIGBMDANNM> MAGKKPOFJIM) =>
				{
					//0xD8BA40
					PLOOEECNHFB_IsDone = true;
					_KLMFJJCNBIP_OnSuccess(NEFEFHBHFFF, MAGKKPOFJIM);
				}, () =>
				{
					//0xD8BA9C
					PLOOEECNHFB_IsDone = true;
					_IDAEHNGOKAE_OnRankingError();
				}, () =>
				{
					//0xD8BAE8
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

	// // RVA: 0x1139EA0 Offset: 0x1139EA0 VA: 0x1139EA0 Slot: 53
	public override void JPNACOLKHLB_AddRankingPlayerListSecond(int CJHEHIMLGGL, int NEFEFHBHFFF, LIOLBKLMMIK _KLMFJJCNBIP_OnSuccess, DJBHIFLHJLK _IDAEHNGOKAE_OnRankingError, DJBHIFLHJLK _JGKOLBLPMPG_OnFail)
	{
		if(!IBNKPMPFLGI_IsRankReward)
		{
			_IDAEHNGOKAE_OnRankingError();
			PLOOEECNHFB_IsDone = true;
		}
		else
		{
			KKLGENJKEBN.HHCJCDFCLOB.JPNACOLKHLB_AddRankingPlayerListSecond(CJHEHIMLGGL, NEFEFHBHFFF, (int _JGNBPFCJLKI_d, List<IBIGBMDANNM> MAGKKPOFJIM) =>
			{
				//0xD8BB54
				PLOOEECNHFB_IsDone = true;
				_KLMFJJCNBIP_OnSuccess(_JGNBPFCJLKI_d, MAGKKPOFJIM);
			}, () =>
			{
				//0xD8BBB0
				PLOOEECNHFB_IsDone = true;
				_IDAEHNGOKAE_OnRankingError();
			}, () =>
			{
				//0xD8BBFC
				PLOOEECNHFB_IsDone = true;
				NPNNPNAIONN_IsError = true;
				_JGKOLBLPMPG_OnFail();
			}, false);
		}
	}

	// // RVA: 0x113A09C Offset: 0x113A09C VA: 0x113A09C
	// private int APJDIPINLLK(List<int> HNLFPKNBOHE, int _PPFNGGCBJKC_id) { }

	// // RVA: 0x1136AD8 Offset: 0x1136AD8 VA: 0x1136AD8
	private void PIMFJALCIGK()
	{
		int a = NGIHFKHOJOK_GetRankingMax(true);
		for(int i = 0; i < a; i++)
		{
			BJEOAOACMGG(i);
		}
	}

	// // RVA: 0x113A194 Offset: 0x113A194 VA: 0x113A194
	private void BJEOAOACMGG(int LHJCOPMMIGO)
	{
		ACBAHDMEFFL_EventMission ev = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.LBDOLHGDIEB_GetDbSection(JOPOPMLFINI_QuestName) as ACBAHDMEFFL_EventMission;
		if(ev != null)
		{
			OKLMJPBJHKL_EventMission.MKIGCLOBJBI save = CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_PlayerData.MENGHOKMOIE_EventMission.FBCJICEPLED[ev.NGHKJOEDLIP_Settings.MOEKELIIDEO_SaveIdx];
			PFPJHJJAGAG_Rewards.Clear();
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
			for(int i = 0; i < ev.FCIPEDFHFEM_TotalRewards.Count; i++)
			{
				IHAEIOAKEMG d = new IHAEIOAKEMG();
				for(int j =  0; j < ev.FCIPEDFHFEM_TotalRewards[i].AHJNPEAMCCH_Rewards.Count; j++)
				{
					MFDJIFIIPJD m = new MFDJIFIIPJD();
					m.KHEKNNFCAOI_Init(ev.FCIPEDFHFEM_TotalRewards[i].AHJNPEAMCCH_Rewards[j].GLCLFMGPMAN_ItemId, ev.FCIPEDFHFEM_TotalRewards[i].AHJNPEAMCCH_Rewards[j].HMFFHLPNMPH_Count);
					m.JOPPFEHKNFO_Pickup = ev.FCIPEDFHFEM_TotalRewards[i].JOPPFEHKNFO_Pickup;
					d.HBHMAKNGKFK_Items.Add(m);
				}
				d.HMEOAKCLKJE_IsReceived = save.BHIAKGKHKGD(i);
				d.FIOIKMOIJGK_Point = ev.FCIPEDFHFEM_TotalRewards[i].DNBFMLBNAEE_Point;
				d.OJELCGDDAOM_MissingPoint = (int)(d.FIOIKMOIJGK_Point - save.DNBFMLBNAEE_Point);
				if(d.OJELCGDDAOM_MissingPoint < 0)
					d.OJELCGDDAOM_MissingPoint = 0;
				PFPJHJJAGAG_Rewards.Add(d);
			}
		}
	}

	// // RVA: 0x1139844 Offset: 0x1139844 VA: 0x1139844
	private void DENHAAGACPD()
	{
		ACBAHDMEFFL_EventMission ev = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.LBDOLHGDIEB_GetDbSection(JOPOPMLFINI_QuestName) as ACBAHDMEFFL_EventMission;
		if(ev != null)
		{
			OKLMJPBJHKL_EventMission.MKIGCLOBJBI save = CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_PlayerData.MENGHOKMOIE_EventMission.FBCJICEPLED[ev.NGHKJOEDLIP_Settings.MOEKELIIDEO_SaveIdx];
			for(int i = 0; i < PFPJHJJAGAG_Rewards.Count; i++)
			{
				PFPJHJJAGAG_Rewards[i].HMEOAKCLKJE_IsReceived = save.BHIAKGKHKGD(i);
				PFPJHJJAGAG_Rewards[i].OJELCGDDAOM_MissingPoint = (int)(PFPJHJJAGAG_Rewards[i].FIOIKMOIJGK_Point - save.DNBFMLBNAEE_Point);
				if(PFPJHJJAGAG_Rewards[i].OJELCGDDAOM_MissingPoint < 0)
					PFPJHJJAGAG_Rewards[i].OJELCGDDAOM_MissingPoint = 0;
			}
		}
	}

	// // RVA: 0x113A9F0 Offset: 0x113A9F0 VA: 0x113A9F0 Slot: 51
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

	// // RVA: 0x113AB04 Offset: 0x113AB04 VA: 0x113AB04 Slot: 58
	protected override void LMGMELPOGMH(int LHJCOPMMIGO)
	{
		ACBAHDMEFFL_EventMission ev/*NDFIEMPPMLF_master*/ = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.LBDOLHGDIEB_GetDbSection(JOPOPMLFINI_QuestName) as ACBAHDMEFFL_EventMission;
		if(ev != null)
		{
			if(IBNKPMPFLGI_IsRankReward)
			{
				HLFHJIDHJMP = null;
				OKPEFAPPFDH_GetRanksAroundSelf r = NKGJPJPHLIF.HHCJCDFCLOB.IBLPICFDGOF_ServerRequester.IFFNCAFNEAG_AddRequest(new OKPEFAPPFDH_GetRanksAroundSelf(false));
				r.EMPNJPMAKBF_Id = KBACNOCOANM_Ranking.PPFNGGCBJKC_id;
				r.MJGOBEGONON_Type = 0;
				r.NHPCKCOPKAM_from = 0;
				r.PJFKNNNDMIA_to = 0;
				r.BHFHGFKBOHH_OnSuccess = (CACGCMBKHDI_Request KCFBGMKDIMI) =>
				{
					//0xD8BF94
					OKPEFAPPFDH_GetRanksAroundSelf req = KCFBGMKDIMI as OKPEFAPPFDH_GetRanksAroundSelf;
					if(req.NFEAMMJIMPG_Result.EJDEDOJFOOK.Count == 0)
					{
						OKLMJPBJHKL_EventMission.MKIGCLOBJBI save = CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_PlayerData.MENGHOKMOIE_EventMission.FBCJICEPLED[ev.NGHKJOEDLIP_Settings.MOEKELIIDEO_SaveIdx];
						save.HPLMECLKFID_RRcv = true;
						PJDGDNJNCNM_UpdateStatusImpl(NKGJPJPHLIF.HHCJCDFCLOB.IBLPICFDGOF_ServerRequester.FJDBNGEPKHL_Time.KMEFBNBFJHI_GetServerTime());
						PLOOEECNHFB_IsDone = true;
					}
					else
					{
						HLFHJIDHJMP = new NHGEHCMPDAI();
						HLFHJIDHJMP.DNBFMLBNAEE_Point = req.NFEAMMJIMPG_Result.EJDEDOJFOOK[0].KNIFCANOHOC_score;
						HLFHJIDHJMP.FJOLNJLLJEJ_Rank = req.NFEAMMJIMPG_Result.EJDEDOJFOOK[0].FJOLNJLLJEJ_Rank;
						KKLGENJKEBN.HHCJCDFCLOB.DNJKPPCBINA(KBACNOCOANM_Ranking.OCGFKMHNEOF_name_for_api, () =>
						{
							//0xD8C668
							for(int i = 0; i < KKLGENJKEBN.HHCJCDFCLOB.PHOPJDPEHJA.Count; i++)
							{
								MFDJIFIIPJD d = new MFDJIFIIPJD();
								d.KHEKNNFCAOI_Init(KKLGENJKEBN.HHCJCDFCLOB.PHOPJDPEHJA[i].JJBGOIMEIPF_ItemId, KKLGENJKEBN.HHCJCDFCLOB.PHOPJDPEHJA[i].MBJIFDBEDAC_item_count);
								HLFHJIDHJMP.HBHMAKNGKFK_Items.Add(d);
							}
							ILCCJNDFFOB.HHCJCDFCLOB.GIBLHFKIMDA(this);
							OKLMJPBJHKL_EventMission.MKIGCLOBJBI save = CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_PlayerData.MENGHOKMOIE_EventMission.FBCJICEPLED[ev.NGHKJOEDLIP_Settings.MOEKELIIDEO_SaveIdx];
							save.HPLMECLKFID_RRcv = true;
							PLOOEECNHFB_IsDone = true;
						}, () =>
						{
							//0xD8C9E4
							HLFHJIDHJMP = null;
							ILCCJNDFFOB.HHCJCDFCLOB.GIBLHFKIMDA(this);
							OKLMJPBJHKL_EventMission.MKIGCLOBJBI save = CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_PlayerData.MENGHOKMOIE_EventMission.FBCJICEPLED[ev.NGHKJOEDLIP_Settings.MOEKELIIDEO_SaveIdx];
							save.HPLMECLKFID_RRcv = true;
							PLOOEECNHFB_IsDone = true;
						}, () =>
						{
							//0xD8CBCC
							OKLMJPBJHKL_EventMission.MKIGCLOBJBI save = CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_PlayerData.MENGHOKMOIE_EventMission.FBCJICEPLED[ev.NGHKJOEDLIP_Settings.MOEKELIIDEO_SaveIdx];
							save.HPLMECLKFID_RRcv = true;
							PLOOEECNHFB_IsDone = true;
							HLFHJIDHJMP = null;
						}, () =>
						{
							//0xD8CD58
							PLOOEECNHFB_IsDone = true;
							HLFHJIDHJMP = null;
						}, () =>
						{
							//0xD8CDA0
							PLOOEECNHFB_IsDone = true;
							NPNNPNAIONN_IsError = true;
						}, 0, -1);
					}
				};
				r.MOBEEPPKFLG_OnFail = (CACGCMBKHDI_Request KCFBGMKDIMI) =>
				{
					//0xD8BC68
					if(JGJFFKPFMDB.BDGBCCGLLAJ_IsRankingError(KCFBGMKDIMI.CJMFJOMECKI_ErrorId))
					{
						if(KCFBGMKDIMI.CJMFJOMECKI_ErrorId == SakashoErrorId.RANKING_DROPPED_PLAYER)
						{
							FKKDIDMGLMI_IsDroppedPlayer = true;
						}
						OKLMJPBJHKL_EventMission.MKIGCLOBJBI save = CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_PlayerData.MENGHOKMOIE_EventMission.FBCJICEPLED[ev.NGHKJOEDLIP_Settings.MOEKELIIDEO_SaveIdx];
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
				return;
			}
		}
		PLOOEECNHFB_IsDone = true;
	}

	// // RVA: 0x113AE94 Offset: 0x113AE94 VA: 0x113AE94 Slot: 59
	public override List<int> AEGDKBNNDBC_GetDrops()
	{
		ACBAHDMEFFL_EventMission ev = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.LBDOLHGDIEB_GetDbSection(JOPOPMLFINI_QuestName) as ACBAHDMEFFL_EventMission;
		if(ev != null)
		{
			return ev.NGHKJOEDLIP_Settings.EEOGPJJCKHH_Drops;
		}
		return null;
	}

	// // RVA: 0x113B018 Offset: 0x113B018 VA: 0x113B018
	public DJDJHGJHAJA.IOPLHHNPLGM KCHMKLPHOEB_GetStep()
	{
		ACBAHDMEFFL_EventMission ev = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.LBDOLHGDIEB_GetDbSection(JOPOPMLFINI_QuestName) as ACBAHDMEFFL_EventMission;
		if(ev != null)
		{
			OKLMJPBJHKL_EventMission.MKIGCLOBJBI save = CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_PlayerData.MENGHOKMOIE_EventMission.FBCJICEPLED[ev.NGHKJOEDLIP_Settings.MOEKELIIDEO_SaveIdx];
			return (DJDJHGJHAJA.IOPLHHNPLGM)save.LGADCGFMLLD_step;
		}
		return 0;
	}

	// // RVA: 0x113B274 Offset: 0x113B274 VA: 0x113B274
	public void PNKKJJFBBIH_SetStep(DJDJHGJHAJA.IOPLHHNPLGM _LGADCGFMLLD_step)
	{
		ACBAHDMEFFL_EventMission ev = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.LBDOLHGDIEB_GetDbSection(JOPOPMLFINI_QuestName) as ACBAHDMEFFL_EventMission;
		if(ev != null)
		{
			OKLMJPBJHKL_EventMission.MKIGCLOBJBI save = CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_PlayerData.MENGHOKMOIE_EventMission.FBCJICEPLED[ev.NGHKJOEDLIP_Settings.MOEKELIIDEO_SaveIdx];
			save.LGADCGFMLLD_step = (int)_LGADCGFMLLD_step;
		}
	}

	// // RVA: 0x113B4D4 Offset: 0x113B4D4 VA: 0x113B4D4 Slot: 65
	protected override bool JLPDECMHLIM_CanShowStartAdventureInternal()
	{
		ACBAHDMEFFL_EventMission ev = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.LBDOLHGDIEB_GetDbSection(JOPOPMLFINI_QuestName) as ACBAHDMEFFL_EventMission;
		if(ev != null)
		{
			OKLMJPBJHKL_EventMission.MKIGCLOBJBI save = CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_PlayerData.MENGHOKMOIE_EventMission.FBCJICEPLED[ev.NGHKJOEDLIP_Settings.MOEKELIIDEO_SaveIdx];
			PJDGDNJNCNM_UpdateStatusImpl(NKGJPJPHLIF.HHCJCDFCLOB.IBLPICFDGOF_ServerRequester.FJDBNGEPKHL_Time.KMEFBNBFJHI_GetServerTime());
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

	// // RVA: 0x113B810 Offset: 0x113B810 VA: 0x113B810 Slot: 66
	public override void FGDDBFHGCGP_SetStartAdventureShown(bool _JKDJCFEBDHC_Enabled, long JHNMKKNEENE/* = 0*/)
	{
		ACBAHDMEFFL_EventMission ev = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.LBDOLHGDIEB_GetDbSection(JOPOPMLFINI_QuestName) as ACBAHDMEFFL_EventMission;
		if(ev != null)
		{
			OKLMJPBJHKL_EventMission.MKIGCLOBJBI save = CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_PlayerData.MENGHOKMOIE_EventMission.FBCJICEPLED[ev.NGHKJOEDLIP_Settings.MOEKELIIDEO_SaveIdx];
			if(NGOFCFJHOMI_Status == KGCNCBOKCBA.GNENJEHKMHD_EventStatus.NCJFJLPJMLI_2)
			{
				save.INLNJOGHLJE_Show |= 1;
			}
		}
	}

	// // RVA: 0x113BA90 Offset: 0x113BA90 VA: 0x113BA90 Slot: 70
	public override void ADACMHAHHKC_PreSetupEventHome(IMCBBOAFION _BHFHGFKBOHH_OnSuccess, DJBHIFLHJLK _AOCANKOMKFG_OnError)
	{
		N.a.StartCoroutineWatched(NJIEIJJMAHK_Corotuine_PreSetupEventHome(_BHFHGFKBOHH_OnSuccess, _AOCANKOMKFG_OnError));
	}

	// [IteratorStateMachineAttribute] // RVA: 0x6BCE5C Offset: 0x6BCE5C VA: 0x6BCE5C
	// // RVA: 0x113BAE8 Offset: 0x113BAE8 VA: 0x113BAE8
	private IEnumerator NJIEIJJMAHK_Corotuine_PreSetupEventHome(IMCBBOAFION _BHFHGFKBOHH_OnSuccess, DJBHIFLHJLK _AOCANKOMKFG_OnError)
	{
		long IBCGNDADAEE_Time; // 0x28
		ACBAHDMEFFL_EventMission KEHCNBNPJHB; // 0x30
		OKLMJPBJHKL_EventMission.MKIGCLOBJBI AIPLGDHHAJI; // 0x34
		ILDKBCLAFPB NCOGNKBGABE; // 0x38
		int CLAPHDOBEAO; // 0x3C
		int CGMGFFPAIKD; // 0x40

		//0xD8CF68
		IBCGNDADAEE_Time = NKGJPJPHLIF.HHCJCDFCLOB.IBLPICFDGOF_ServerRequester.FJDBNGEPKHL_Time.KMEFBNBFJHI_GetServerTime();
		FHPEAPEANAI = null;
		EGOJLOEFMOH_IsUpdateLimitedMusic = false;
		LPFJADHHLHG = false;
		BCBCODAKIDN_DescType = 0;
		JKCBFOAHNGL_Mid = 0;
		KEHCNBNPJHB = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.LBDOLHGDIEB_GetDbSection(JOPOPMLFINI_QuestName) as ACBAHDMEFFL_EventMission;
		if(KEHCNBNPJHB != null)
		{
			PJDGDNJNCNM_UpdateStatusImpl(IBCGNDADAEE_Time);
			MJFKJHJJLMN_GetRanks(0, false);
			while(!PLOOEECNHFB_IsDone)
				yield return null;
			if(NPNNPNAIONN_IsError)
			{
				//LAB_00d8d5bc
				if(_AOCANKOMKFG_OnError != null)
					_AOCANKOMKFG_OnError();
				yield break;
			}
           	AIPLGDHHAJI = CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_PlayerData.MENGHOKMOIE_EventMission.FBCJICEPLED[KEHCNBNPJHB.NGHKJOEDLIP_Settings.MOEKELIIDEO_SaveIdx];
			NCOGNKBGABE = GameManager.Instance.localSave;
			if(FKKDIDMGLMI_IsDroppedPlayer)
			{
				JHHBAFKMBDL.HHCJCDFCLOB.PEIONAKEPCN_ShowRankingBanPopup(_AOCANKOMKFG_OnError);
				yield break;
			}
            System.DateTime d1 = Utility.GetLocalDateTime(IBCGNDADAEE_Time);
            System.DateTime d2 = Utility.GetLocalDateTime(AIPLGDHHAJI.BEBJKJKBOGH_Date);
			if(d1.Year != d2.Year || d1.Month != d2.Month || d1.Day != d2.Day)
			{
				AIPLGDHHAJI.POENMEGPHCG_reset = 0;
				AIPLGDHHAJI.BEBJKJKBOGH_Date = IBCGNDADAEE_Time;
			}
			if(NGOFCFJHOMI_Status  == KGCNCBOKCBA.GNENJEHKMHD_EventStatus.GDOPLACICFE_4)
			{
				AIPLGDHHAJI.ABBJBPLHFHA_Spurt = true;
				LPFJADHHLHG = true;
				PJDGDNJNCNM_UpdateStatusImpl(IBCGNDADAEE_Time);
			}
			CLAPHDOBEAO = (int)NGOFCFJHOMI_Status;
			CGMGFFPAIKD = 0;
			if(MLNOLKKHBDC_IsSelectPrevSong())
			{
				CGMGFFPAIKD = IGBPFGPPJOE();
			}
			switch(AIPLGDHHAJI.LGADCGFMLLD_step)
			{
				case 0:
				case 1:
					if(CLAPHDOBEAO > 5)
					{
						//LAB_00d8dcf0
						AIPLGDHHAJI.LGADCGFMLLD_step = 9;
						break;
					}
					CMPEJEHCOEI = true;
					AIPLGDHHAJI.LGADCGFMLLD_step = 2;
					AIPLGDHHAJI.IMFBCJOIJKJ_Entry = true;
					if(KIBBLLADDPO)
					{
						AIPLGDHHAJI.ABBJBPLHFHA_Spurt = true;
						LPFJADHHLHG = true;
					}
					LNIMCKNKFHL();
					NCOGNKBGABE.EPJOACOONAC_GetSave().PPCGEFGJJIC_SortProprty.BPFEOJEAEGK_EventMission.LHPDDGIJKNB_Reset();
					DCNEHOMHOJL(HEACCHAKMFG_GetMusicsList()[0]);
					FGDDBFHGCGP_SetStartAdventureShown(true, 0);
					break;
				case 2:
				case 3:
				case 4:
				case 5:
				case 6:
					if(CLAPHDOBEAO > 5)
					{
						//LAB_00d8dcf0
						AIPLGDHHAJI.LGADCGFMLLD_step = 9;
						break;
					}
					if(AIPLGDHHAJI.LGADCGFMLLD_step > 5 && AIPLGDHHAJI.LGADCGFMLLD_step < 7)
					{
						BCBCODAKIDN_DescType = JKPDCKDMKBN();
						if(BCBCODAKIDN_DescType != 0)
						{
							DCNEHOMHOJL(HEACCHAKMFG_GetMusicsList()[0]);
							EGOJLOEFMOH_IsUpdateLimitedMusic = true;
						}
					}
					break;
				case 7:
				case 8:
					if(CLAPHDOBEAO > 5)
					{
						//LAB_00d8dcf0
						AIPLGDHHAJI.LGADCGFMLLD_step = 9;
						break;
					}
					LNIMCKNKFHL();
					AIPLGDHHAJI.MHKICPIMFEI_PlayCount++;
					//LAB_00d8dd0c
					AIPLGDHHAJI.LGADCGFMLLD_step = 2;
					break;
			}
			CGEAAEPEFIE_ExclusiveBonusMusic = 0;
			EEIKDIHGJAD_IsUpdateBonusSchedule = false;
			if(NGOFCFJHOMI_Status < KGCNCBOKCBA.GNENJEHKMHD_EventStatus.EMAMLLFAOJI_Counting_6)
			{
				if(GFIBLLLHMPD_StartAdventureId > 0)
				{
					if(CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_PlayerData.HBPPNFHOMNB_Adventure.FABEJIHKFGN_IsReleased(GFIBLLLHMPD_StartAdventureId))
					{
						if(!AIPLGDHHAJI.OKEJGGCMAAI_PlaRcv)
						{
							bool KPIGMCJMFAN = false;
							yield return Co.R(JEIJKLPOAHP_ReceivePrologueRepeatedAchievement(() =>
							{
								//0xD8CF24
								KPIGMCJMFAN = true;
							}));
							if(KPIGMCJMFAN)
							{
								//LAB_00d8d5bc
								if(_AOCANKOMKFG_OnError != null)
									_AOCANKOMKFG_OnError();
								yield break;
							}
							if(JBPPMMMFGCA_HasRewardItems())
							{
								AIPLGDHHAJI.OKEJGGCMAAI_PlaRcv = true;
							}
							//LAB_00d8d1b8
						}
					}
				}
				//LAB_00d8d1b8
				EEIKDIHGJAD_IsUpdateBonusSchedule = GGJCIDOCOOM(IBCGNDADAEE_Time, CGMGFFPAIKD, out CGEAAEPEFIE_ExclusiveBonusMusic);
			}
			else
			{
				if(NGOFCFJHOMI_Status > KGCNCBOKCBA.GNENJEHKMHD_EventStatus.EIFKDKFAHPH_7 && CAKEOPLJDAF_EndAdventureId > 0)
				{
					if(CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_PlayerData.HBPPNFHOMNB_Adventure.FABEJIHKFGN_IsReleased(CAKEOPLJDAF_EndAdventureId))
					{
						if(!AIPLGDHHAJI.CGMMMJCIDFE_EpaRcv)
						{
							bool KPIGMCJMFAN = false;
							yield return Co.R(KPBNMAEHHDF_ReceiveEpilogueRepeatedAchivement(() =>
							{
								//0xD8CF38
								KPIGMCJMFAN = true;
							}));
							if(KPIGMCJMFAN)
							{
								//LAB_00d8d5bc
								if(_AOCANKOMKFG_OnError != null)
									_AOCANKOMKFG_OnError();
								yield break;
							}
							if(JBPPMMMFGCA_HasRewardItems())
							{
								AIPLGDHHAJI.CGMMMJCIDFE_EpaRcv = true;
							}
							//LAB_00d8d460
						}
					}
				}
			}
			//LAB_00d8d460
			OIMGJLOLPHK = false;
			if(CLAPHDOBEAO < 6)
			{
				CEBFFLDKAEC_SecureInt a;
				if(KEHCNBNPJHB.OHJFBLFELNK_IntArray.TryGetValue(HOEKCEJINNA, out a))
				{
					bool b = DLHEEOIELBA(a.DNJEJEANJGL_Value);
					if(NGOFCFJHOMI_Status == KGCNCBOKCBA.GNENJEHKMHD_EventStatus.NCJFJLPJMLI_2)
					{
						if(!b)
						{
							AIPLGDHHAJI.INLNJOGHLJE_Show |= 4;
						}
					}
					else
					{
						if(b && KEHCNBNPJHB.OHJFBLFELNK_IntArray.TryGetValue(FOKNMOMNHHD, out a))
						{
							if((AIPLGDHHAJI.INLNJOGHLJE_Show & 4) != 0)
							{
								GFHKFKHBIGM = true;
								OGPMLMDPGJA = a.DNJEJEANJGL_Value;
							}
						}
					}
					OIMGJLOLPHK = b;
				}
			}
			NCOGNKBGABE.HJMKBCFJOOH_TrySave();
			CIOECGOMILE.HHCJCDFCLOB.AIKJMHBDABF_SavePlayerData(() =>
			{
				//0xD8CDEC
				ILCCJNDFFOB.HHCJCDFCLOB.DADNPOJNIBL(this);
				if(_BHFHGFKBOHH_OnSuccess != null)
					_BHFHGFKBOHH_OnSuccess();
				PLOOEECNHFB_IsDone = true;
			}, () =>
			{
				//0xD8CEC4
				if(_AOCANKOMKFG_OnError != null)
					_AOCANKOMKFG_OnError();
				PLOOEECNHFB_IsDone = true;
				NPNNPNAIONN_IsError = true;
			}, null);
        }
		else
		{
			NPNNPNAIONN_IsError = true;
			PLOOEECNHFB_IsDone = true;
			if(_AOCANKOMKFG_OnError != null)
				_AOCANKOMKFG_OnError();
		}
	}

	// // RVA: 0x113BBA0 Offset: 0x113BBA0 VA: 0x113BBA0
	// public bool EGKODECGHNM() { }

	// // RVA: 0x113BBA8 Offset: 0x113BBA8 VA: 0x113BBA8 Slot: 33
	public override bool MPMKJNJGFEF_IsEntry()
	{
		ACBAHDMEFFL_EventMission ev = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.LBDOLHGDIEB_GetDbSection(JOPOPMLFINI_QuestName) as ACBAHDMEFFL_EventMission;
		if(ev != null)
		{
           OKLMJPBJHKL_EventMission.MKIGCLOBJBI save = CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_PlayerData.MENGHOKMOIE_EventMission.FBCJICEPLED[ev.NGHKJOEDLIP_Settings.MOEKELIIDEO_SaveIdx];
		   return save.IMFBCJOIJKJ_Entry;
		}
		return false;
	}

	// // RVA: 0x113BE08 Offset: 0x113BE08 VA: 0x113BE08 Slot: 69
	public override void HAAEJDGMICH(LBNLAENLPNK.JEKODBEDOMM _INDDJNMPONH_Type, IMCBBOAFION _BHFHGFKBOHH_OnSuccess, DJBHIFLHJLK _AOCANKOMKFG_OnError)
	{
		string s = null;
		if(_INDDJNMPONH_Type == 0)
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

	// // RVA: 0x113BF30 Offset: 0x113BF30 VA: 0x113BF30 Slot: 71
	public override int BAEPGOAMBDK(string _LJNAKDMILMC_key, int MNCOAGOKNAO)
	{
		ACBAHDMEFFL_EventMission ev = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.LBDOLHGDIEB_GetDbSection(JOPOPMLFINI_QuestName) as ACBAHDMEFFL_EventMission;
		if(ev != null)
		{
			return ev.LPJLEHAJADA(_LJNAKDMILMC_key, MNCOAGOKNAO);
		}
		return 0;
	}

	// // RVA: 0x113C0B0 Offset: 0x113C0B0 VA: 0x113C0B0 Slot: 72
	public override string MAICAKMIBEM(string _LJNAKDMILMC_key, string MNCOAGOKNAO)
	{
		ACBAHDMEFFL_EventMission ev = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.LBDOLHGDIEB_GetDbSection(JOPOPMLFINI_QuestName) as ACBAHDMEFFL_EventMission;
		if(ev != null)
		{
			return ev.EFEGBHACJAL(_LJNAKDMILMC_key, MNCOAGOKNAO);
		}
		return MNCOAGOKNAO;
	}

	// // RVA: 0x113C230 Offset: 0x113C230 VA: 0x113C230 Slot: 68
	public override bool GJMGKBDGMOP(long LPEKHFOMCAH)
	{
		ACBAHDMEFFL_EventMission ev = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.LBDOLHGDIEB_GetDbSection(JOPOPMLFINI_QuestName) as ACBAHDMEFFL_EventMission;
		if(ev != null)
		{
			if(BHABCGJCGNO != null)
			{
				if(LPEKHFOMCAH < DPJCPDKALGI_RankingEnd)
				{
          			OKLMJPBJHKL_EventMission.MKIGCLOBJBI save = CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_PlayerData.MENGHOKMOIE_EventMission.FBCJICEPLED[ev.NGHKJOEDLIP_Settings.MOEKELIIDEO_SaveIdx];
					if(NKGJPJPHLIF.HHCJCDFCLOB.DHMLDAGGKCD != save.OMCAOJJGOGG_Lb)
					{
						save.OMCAOJJGOGG_Lb = NKGJPJPHLIF.HHCJCDFCLOB.DHMLDAGGKCD;
						if(EKLNMHFCAOI.BKHFLDMOGBD_GetItemCategory(BHABCGJCGNO.JJBGOIMEIPF_ItemId) == EKLNMHFCAOI.FKGCBLHOOCL_Category.DMMIIBCMCFG_EnergyItem)
						{
							EGOLBAPFHHD_Common.FKLHGOGJOHH it = CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_PlayerData.KCCLEHLLOFG_Common.KFEBOFKAHAJ_EngItem[EKLNMHFCAOI.DEACAHNLMNI_getItemId(BHABCGJCGNO.JJBGOIMEIPF_ItemId) - 1];
							it.BFINGCJHOHI_Count += BHABCGJCGNO.MBJIFDBEDAC_item_count;
							it.BEBJKJKBOGH_Date = NKGJPJPHLIF.HHCJCDFCLOB.IBLPICFDGOF_ServerRequester.FJDBNGEPKHL_Time.KMEFBNBFJHI_GetServerTime();
							ILCCJNDFFOB.HHCJCDFCLOB.JAHALBMOANH(BHABCGJCGNO.JJBGOIMEIPF_ItemId, OAGBCBBHMPF.COIIJOEKBDH.IGAJCMKNLDL_14, PGIIDPEGGPI_EventId.ToString(), BHABCGJCGNO.MBJIFDBEDAC_item_count, it.BFINGCJHOHI_Count, 1);
						}
						return true;
					}
				}
			}
		}
		return false;
	}

	// // RVA: 0x113CA18 Offset: 0x113CA18 VA: 0x113CA18 Slot: 75
	public override string FEKEBPKINIM_GetSessionId()
	{
		ACBAHDMEFFL_EventMission ev = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.LBDOLHGDIEB_GetDbSection(JOPOPMLFINI_QuestName) as ACBAHDMEFFL_EventMission;
		if(ev != null)
		{
           OKLMJPBJHKL_EventMission.MKIGCLOBJBI save = CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_PlayerData.MENGHOKMOIE_EventMission.FBCJICEPLED[ev.NGHKJOEDLIP_Settings.MOEKELIIDEO_SaveIdx];
		   return save.MDADLCOCEBN_session_id;
		}
		return "";
	}

	// // RVA: 0x113CC84 Offset: 0x113CC84 VA: 0x113CC84 Slot: 73
	public override List<string> IJCPBPFEGDM_GetResourcesFilePathList(long _JHNMKKNEENE_Time)
	{
		ACBAHDMEFFL_EventMission ev = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.LBDOLHGDIEB_GetDbSection(JOPOPMLFINI_QuestName) as ACBAHDMEFFL_EventMission;
		if(ev != null)
		{
			if(MNNNLDFNNCD(_JHNMKKNEENE_Time))
			{
            	KEODKEGFDLD_FreeMusicInfo fInfo = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.IBPAFKKEKNK_Music.NOBCLJIAMLC_GetFreeMusicData(ev.NGHKJOEDLIP_Settings.JKFPADIAKCK_Songs[0]);
                EONOEHOKBEB_Music mInfo = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.IBPAFKKEKNK_Music.IAJLOELFHKC_GetMusicInfo(fInfo.DLAEJOBELBH_MusicId);
				return SoundResource.CreateBgmFilePathList(mInfo.KKPAHLMJKIH_WavId);
            }
		}
		return null;
	}

	// // RVA: 0x113CF98 Offset: 0x113CF98 VA: 0x113CF98 Slot: 74
	public override int EDNMFMBLCGF_GetWavId()
	{
		ACBAHDMEFFL_EventMission ev = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.LBDOLHGDIEB_GetDbSection(JOPOPMLFINI_QuestName) as ACBAHDMEFFL_EventMission;
		if(ev != null)
		{
            KEODKEGFDLD_FreeMusicInfo fInfo = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.IBPAFKKEKNK_Music.NOBCLJIAMLC_GetFreeMusicData(ev.NGHKJOEDLIP_Settings.JKFPADIAKCK_Songs[0]);
			return IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.IBPAFKKEKNK_Music.IAJLOELFHKC_GetMusicInfo(fInfo.DLAEJOBELBH_MusicId).KKPAHLMJKIH_WavId;
        }
		return 0;
	}

	// // RVA: 0x113D250 Offset: 0x113D250 VA: 0x113D250 Slot: 38
	public override void EMEPJNLHJHJ(int GJEADBKFAPA, int _AKNELONELJK_Difficulty, bool _GIKLNODJKFK_IsLine6, ref int APMGOLOPLFP, ref int FBBDNLAMPMH)
	{
		APMGOLOPLFP = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.HNMMJINNHII_Game.JJIBDCAIBIO_LuckCoef0;
		FBBDNLAMPMH = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.HNMMJINNHII_Game.AMNBEMCJCHF_LuckCoef1;
	}

	// // RVA: 0x113D364 Offset: 0x113D364 VA: 0x113D364
	// public OFNLIBDEIFA.HGCEGAAJFBC JIPPHOKGLIH(int _GOIKCKHMBDL_FreeMusicId, bool HOENAFAJMGI = False) { }

	// // RVA: 0x113D36C Offset: 0x113D36C VA: 0x113D36C
	public void DCNEHOMHOJL(int _GHBPLHBNMBK_FreeMusicId)
	{
		ACBAHDMEFFL_EventMission ev = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.LBDOLHGDIEB_GetDbSection(JOPOPMLFINI_QuestName) as ACBAHDMEFFL_EventMission;
		if(ev != null)
		{
           OKLMJPBJHKL_EventMission.MKIGCLOBJBI save = CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_PlayerData.MENGHOKMOIE_EventMission.FBCJICEPLED[ev.NGHKJOEDLIP_Settings.MOEKELIIDEO_SaveIdx];
		   save.LIEKIBHAPKC_FId = _GHBPLHBNMBK_FreeMusicId;
		   ILCCJNDFFOB.HHCJCDFCLOB.FJIGNIDBFMM(this);
		}
	}

	// // RVA: 0x113D618 Offset: 0x113D618 VA: 0x113D618
	public int IGBPFGPPJOE()
	{
		ACBAHDMEFFL_EventMission ev = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.LBDOLHGDIEB_GetDbSection(JOPOPMLFINI_QuestName) as ACBAHDMEFFL_EventMission;
		if(ev != null)
		{
           OKLMJPBJHKL_EventMission.MKIGCLOBJBI save = CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_PlayerData.MENGHOKMOIE_EventMission.FBCJICEPLED[ev.NGHKJOEDLIP_Settings.MOEKELIIDEO_SaveIdx];
		   return save.LIEKIBHAPKC_FId;
		}
		return 23;
	}

	// // RVA: 0x113D86C Offset: 0x113D86C VA: 0x113D86C
	public ACBAHDMEFFL_EventMission.BIMNGKEMMJM MLLAMHMJFLP()
	{
		ACBAHDMEFFL_EventMission ev = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.LBDOLHGDIEB_GetDbSection(JOPOPMLFINI_QuestName) as ACBAHDMEFFL_EventMission;
		if(ev != null)
		{
            OKLMJPBJHKL_EventMission.MKIGCLOBJBI save = CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_PlayerData.MENGHOKMOIE_EventMission.FBCJICEPLED[ev.NGHKJOEDLIP_Settings.MOEKELIIDEO_SaveIdx];
			return ev.ABJIDJODLIM_MissionSet[save.PPHEALAJAKD_MiSet - 1];
		}
		return null;
	}

	// // RVA: 0x113DAF8 Offset: 0x113DAF8 VA: 0x113DAF8
	public ACBAHDMEFFL_EventMission.BFHPHDAPEKA KMOALEJMJKA_GetMission(int _JOMGCCBFKEF_MissionId)
	{
		ACBAHDMEFFL_EventMission ev = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.LBDOLHGDIEB_GetDbSection(JOPOPMLFINI_QuestName) as ACBAHDMEFFL_EventMission;
		if(ev != null)
		{
			return ev.GAAHOOBMDEE_Mission[_JOMGCCBFKEF_MissionId - 1];
		}
		return null;
	}

	// // RVA: 0x113DC9C Offset: 0x113DC9C VA: 0x113DC9C
	public ACBAHDMEFFL_EventMission.ONECEEIOJCP LOLJPCKNLGI(int BCMBMAILDMP)
	{
		ACBAHDMEFFL_EventMission ev = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.LBDOLHGDIEB_GetDbSection(JOPOPMLFINI_QuestName) as ACBAHDMEFFL_EventMission;
		if(ev != null)
		{
			return ev.LGODPKPFGHF[BCMBMAILDMP - 1];
		}
		return null;
	}

	// // RVA: 0x113DE40 Offset: 0x113DE40 VA: 0x113DE40
	// public ACBAHDMEFFL.BFHPHDAPEKA MELOGDCGMLG() { }

	// // RVA: 0x113E13C Offset: 0x113E13C VA: 0x113E13C
	public int LLCOKGMCNAF()
	{
		return HEACCHAKMFG_GetMusicsList()[0];
	}

	// // RVA: 0x113E1CC Offset: 0x113E1CC VA: 0x113E1CC
	private void JHLIABLHIDK(int ANMCFINOHFH)
	{
		ACBAHDMEFFL_EventMission ev = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.LBDOLHGDIEB_GetDbSection(JOPOPMLFINI_QuestName) as ACBAHDMEFFL_EventMission;
		if(ev != null)
		{
            OKLMJPBJHKL_EventMission.MKIGCLOBJBI save = CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_PlayerData.MENGHOKMOIE_EventMission.FBCJICEPLED[ev.NGHKJOEDLIP_Settings.MOEKELIIDEO_SaveIdx];
			//ev.ABJIDJODLIM_MissionSet[ANMCFINOHFH - 1];
			save.PPHEALAJAKD_MiSet = ANMCFINOHFH;
			save.MDADLCOCEBN_session_id = JDDGPJDKHNE.GPLMOKEIOLE();
			ILCCJNDFFOB.HHCJCDFCLOB.JNHOIANJAOP(this);
		}
	}

	// // RVA: 0x113E4D8 Offset: 0x113E4D8 VA: 0x113E4D8
	public void ACJFIFPCJDP()
	{
		ACBAHDMEFFL_EventMission ev = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.LBDOLHGDIEB_GetDbSection(JOPOPMLFINI_QuestName) as ACBAHDMEFFL_EventMission;
		if(ev != null)
		{
            OKLMJPBJHKL_EventMission.MKIGCLOBJBI save = CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_PlayerData.MENGHOKMOIE_EventMission.FBCJICEPLED[ev.NGHKJOEDLIP_Settings.MOEKELIIDEO_SaveIdx];
			if(save.MHKICPIMFEI_PlayCount == 0)
			{
				DCNEHOMHOJL(HEACCHAKMFG_GetMusicsList()[0]);
			}
			else
			{
				if(save.KGGPBOEPKCE_PrevSel && save.LIEKIBHAPKC_FId != 0)
				{
					BCBCODAKIDN_DescType = JKPDCKDMKBN();
					if(BCBCODAKIDN_DescType != 0)
					{
						save.LIEKIBHAPKC_FId = HEACCHAKMFG_GetMusicsList()[0];
						EGOJLOEFMOH_IsUpdateLimitedMusic = true;
					}
					DCNEHOMHOJL(save.LIEKIBHAPKC_FId);
				}
				else
				{
					DCNEHOMHOJL(IIGKKMMJONJ());
				}
			}
		}
	}

	// // RVA: 0x113F1C4 Offset: 0x113F1C4 VA: 0x113F1C4
	public void BMNPDFHNLOM_SetIsSelectPrevSong(bool _JKDJCFEBDHC_Enabled)
	{
		ACBAHDMEFFL_EventMission ev = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.LBDOLHGDIEB_GetDbSection(JOPOPMLFINI_QuestName) as ACBAHDMEFFL_EventMission;
		if(ev != null)
		{
            OKLMJPBJHKL_EventMission.MKIGCLOBJBI save = CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_PlayerData.MENGHOKMOIE_EventMission.FBCJICEPLED[ev.NGHKJOEDLIP_Settings.MOEKELIIDEO_SaveIdx];
			save.KGGPBOEPKCE_PrevSel = _JKDJCFEBDHC_Enabled;
		}
	}

	// // RVA: 0x113F414 Offset: 0x113F414 VA: 0x113F414
	public bool MLNOLKKHBDC_IsSelectPrevSong()
	{
		ACBAHDMEFFL_EventMission ev = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.LBDOLHGDIEB_GetDbSection(JOPOPMLFINI_QuestName) as ACBAHDMEFFL_EventMission;
		if(ev != null)
		{
            OKLMJPBJHKL_EventMission.MKIGCLOBJBI save = CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_PlayerData.MENGHOKMOIE_EventMission.FBCJICEPLED[ev.NGHKJOEDLIP_Settings.MOEKELIIDEO_SaveIdx];
			return save.KGGPBOEPKCE_PrevSel;
		}
		return false;
	}

	// // RVA: 0x113F674 Offset: 0x113F674 VA: 0x113F674
	public void NAJMELNNCAN_SetSelectedCardIdx(int HHJIECNECNA)
	{
		ACBAHDMEFFL_EventMission ev = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.LBDOLHGDIEB_GetDbSection(JOPOPMLFINI_QuestName) as ACBAHDMEFFL_EventMission;
		if(ev != null)
		{
            OKLMJPBJHKL_EventMission.MKIGCLOBJBI save = CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_PlayerData.MENGHOKMOIE_EventMission.FBCJICEPLED[ev.NGHKJOEDLIP_Settings.MOEKELIIDEO_SaveIdx];
			save.NKCCNNNJGJF_SelCard = HHJIECNECNA;
			ILCCJNDFFOB.HHCJCDFCLOB.HPFKEJGCDKN(this);
		}
	}

	// // RVA: 0x113DEE0 Offset: 0x113DEE0 VA: 0x113DEE0
	public int BHNEJEDEHJA_SelectedCardIdx()
	{
		ACBAHDMEFFL_EventMission ev = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.LBDOLHGDIEB_GetDbSection(JOPOPMLFINI_QuestName) as ACBAHDMEFFL_EventMission;
		if(ev != null)
		{
            OKLMJPBJHKL_EventMission.MKIGCLOBJBI save = CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_PlayerData.MENGHOKMOIE_EventMission.FBCJICEPLED[ev.NGHKJOEDLIP_Settings.MOEKELIIDEO_SaveIdx];
			return save.NKCCNNNJGJF_SelCard;
		}
		return 0;
	}

	// // RVA: 0x113F92C Offset: 0x113F92C VA: 0x113F92C
	private void LNIMCKNKFHL()
	{
		ACBAHDMEFFL_EventMission ev = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.LBDOLHGDIEB_GetDbSection(JOPOPMLFINI_QuestName) as ACBAHDMEFFL_EventMission;
		if(ev != null)
		{
            OKLMJPBJHKL_EventMission.MKIGCLOBJBI save = CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_PlayerData.MENGHOKMOIE_EventMission.FBCJICEPLED[ev.NGHKJOEDLIP_Settings.MOEKELIIDEO_SaveIdx];
			List<GBACDCAFCEB> l = new List<GBACDCAFCEB>();
			int v = 0;
			for(int i = 0; i < ev.ABJIDJODLIM_MissionSet.Count; i++)
			{
				if(ev.ABJIDJODLIM_MissionSet[i].PLALNIIBLOF_en == 2 && 
					ev.ABJIDJODLIM_MissionSet[i].MKNDAOHGOAK_weight != 0)
				{
					v += ev.ABJIDJODLIM_MissionSet[i].MKNDAOHGOAK_weight;
					GBACDCAFCEB g = new GBACDCAFCEB();
					g.ANMCFINOHFH = ev.ABJIDJODLIM_MissionSet[i].PPFNGGCBJKC_id;
					g.FCDKJAKLGMB_TargetValue = v;
					l.Add(g);
				}
			}
			int v2 = UnityEngine.Random.Range(0, v);
			int v3 = 0;
			for(int i = 0; i < l.Count; i++)
			{
				v3 = i;
				if(v2 <= l[i].FCDKJAKLGMB_TargetValue)
					break;
			}
			JHLIABLHIDK(l[v3].ANMCFINOHFH);
		}
	}

	// // RVA: 0x113FDE8 Offset: 0x113FDE8 VA: 0x113FDE8
	public int CFJAHCCFIGD_GetDecoAwardCoef(int _DNBFMLBNAEE_Point)
	{
		ACBAHDMEFFL_EventMission ev = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.LBDOLHGDIEB_GetDbSection(JOPOPMLFINI_QuestName) as ACBAHDMEFFL_EventMission;
		int v = ev.LPJLEHAJADA("decoration_award_coef", 1000);
		return Mathf.Min(9999, (_DNBFMLBNAEE_Point + v - 1) / v);
	}

	// // RVA: 0x1140028 Offset: 0x1140028 VA: 0x1140028
	public int NEBKOHHKGBA_GetDecoItemId()
	{
		ACBAHDMEFFL_EventMission ev = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.LBDOLHGDIEB_GetDbSection(JOPOPMLFINI_QuestName) as ACBAHDMEFFL_EventMission;
		if(ev != null)
		{
			return ev.LPJLEHAJADA("decoration_item_id", 0);
		}
		return 0;
	}

	// // RVA: 0x11401AC Offset: 0x11401AC VA: 0x11401AC
	public int KFGOHDKANAC_GetDecoItemCount()
	{
		if(CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_PlayerData != null && 
			IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database != null)
		{
			int id = NEBKOHHKGBA_GetDecoItemId();
			if(id > 0)
			{
				return EKLNMHFCAOI.ALHCGDMEMID_GetNumItems(IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database, 
					CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_PlayerData, EKLNMHFCAOI.BKHFLDMOGBD_GetItemCategory(id), 
					EKLNMHFCAOI.DEACAHNLMNI_getItemId(id), null);
			}
		}
		return 0;
	}

	// // RVA: 0x1140348 Offset: 0x1140348 VA: 0x1140348
	public void FCLGOCBGPJF(JGEOBNENMAH.HAJIFNABIFF OMNOFMEBLAD, int ACMMDAHKCIF, int _FCLGIPFPIPH_DashBonus, int LCCGDFGGIHI, int _ANOPDAGJIKG_FriendSceneId, int MHADLGMJKGK, bool IKGLAFOHGDO)
	{
		EBNMMCKCPKN(OMNOFMEBLAD, ACMMDAHKCIF, _FCLGIPFPIPH_DashBonus, LCCGDFGGIHI, _ANOPDAGJIKG_FriendSceneId, MHADLGMJKGK, IKGLAFOHGDO);
	}

	// // RVA: 0x1140388 Offset: 0x1140388 VA: 0x1140388
	private void EBNMMCKCPKN(JGEOBNENMAH.HAJIFNABIFF OMNOFMEBLAD, int ACMMDAHKCIF, int _FCLGIPFPIPH_DashBonus, int LCCGDFGGIHI, int _ANOPDAGJIKG_FriendSceneId, int MHADLGMJKGK, bool IKGLAFOHGDO)
	{
		ACBAHDMEFFL_EventMission ev = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.LBDOLHGDIEB_GetDbSection(JOPOPMLFINI_QuestName) as ACBAHDMEFFL_EventMission;
		if(ev != null)
		{
            OKLMJPBJHKL_EventMission.MKIGCLOBJBI save = CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_PlayerData.MENGHOKMOIE_EventMission.FBCJICEPLED[ev.NGHKJOEDLIP_Settings.MOEKELIIDEO_SaveIdx];
			int bonus = 0;
			JKCBFOAHNGL_Mid = 0;
			int idx = BHNEJEDEHJA_SelectedCardIdx();
			if(idx == 2)
			{
				JKCBFOAHNGL_Mid = MLLAMHMJFLP().CFMIPHDGCAG_Mid3;
				bonus = MLLAMHMJFLP().OPNNCHMFEBH_Bns3;
			}
			else if(idx == 1)
			{
				JKCBFOAHNGL_Mid = MLLAMHMJFLP().KEEHMNJCONJ_Mid2;
				bonus = MLLAMHMJFLP().DHDBOPKADII_Bns2;
			}
			else if(idx == 0)
			{
				JKCBFOAHNGL_Mid = MLLAMHMJFLP().BGFPMGPHGJJ_Mid1;
				bonus = MLLAMHMJFLP().JKAEKMMOJMF_Bns1;
			}
			FHPEAPEANAI = new OPFEKMKHEIF();
			FHPEAPEANAI.AJCMCKGNFHC_Level = idx + 1;
			FHPEAPEANAI.NFOOOBMJINC_MissionBonusNum = bonus;
            ACBAHDMEFFL_EventMission.ONECEEIOJCP a = LOLJPCKNLGI(JKCBFOAHNGL_Mid);
            FHPEAPEANAI.EMBGHCNOCEH_Desc = a.FEMMDNIELFC_Desc;
			FHPEAPEANAI.FCNIAJHHGJH_Difficulty = OMNOFMEBLAD.AKNELONELJK_Difficulty;
			FHPEAPEANAI.LFGNLKKFOCD_IsLine6 = OMNOFMEBLAD.LFGNLKKFOCD_IsLine6;
			FHPEAPEANAI.JKPDKNPDEBC_EnemyHasSkill = a.MLKFDMFDFCE_enemy_c_skill != 0 && a.DKOPDNHDLIA_EnemyLSkill != 0;
			if(!OMNOFMEBLAD.LFGNLKKFOCD_IsLine6)
			{
				FHPEAPEANAI.FPEOGFMKMKJ_Point = ev.FHDCGHEKJLL[OMNOFMEBLAD.AKNELONELJK_Difficulty].NANNGLGOFKH_value;
			}
			else
			{
				FHPEAPEANAI.FPEOGFMKMKJ_Point = ev.JFJJOCODMIB[OMNOFMEBLAD.AKNELONELJK_Difficulty].NANNGLGOFKH_value;
			}
			if(GBNDFCEDNMG.EIJIGDCMJLB(IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database, CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_PlayerData, KMOALEJMJKA_GetMission(a.FCBDGLEPGFJ_Mid), OMNOFMEBLAD, this, false))
			{
				FHPEAPEANAI.PJEFKNPJEBE_MissionBonus = bonus + 100;
				FHPEAPEANAI.BCGLDMKODLC_IsClear = true;
			}
			else
			{
				FHPEAPEANAI.PJEFKNPJEBE_MissionBonus = 100;
				FHPEAPEANAI.BCGLDMKODLC_IsClear = false;
			}
			FHPEAPEANAI.LIPIAPOGHIP_EpisodeNum = LEPNPBIMHGM_GetEquippedEpisodesWithBonus(_ANOPDAGJIKG_FriendSceneId).Count;
			FHPEAPEANAI.ODCLHPGHDHA_EpisodeBonus = CEICDKGEONG_GetEquippedEpisodesBonusValue(_ANOPDAGJIKG_FriendSceneId, MHADLGMJKGK);
			FHPEAPEANAI.ODCLHPGHDHA_EpisodeBonus += 100;
			FHPEAPEANAI.JKDICBNOGBL_MusicBonus = ACMMDAHKCIF;
			if(FHPEAPEANAI.JKDICBNOGBL_MusicBonus < 0)
				FHPEAPEANAI.JKDICBNOGBL_MusicBonus = 0;
			if(FHPEAPEANAI.JKDICBNOGBL_MusicBonus > 100)
				FHPEAPEANAI.JKDICBNOGBL_MusicBonus = 100;
			FHPEAPEANAI.JKDICBNOGBL_MusicBonus += 100;
			FHPEAPEANAI.FCLGIPFPIPH_DashBonus = _FCLGIPFPIPH_DashBonus;
			int v = ((FHPEAPEANAI.JKDICBNOGBL_MusicBonus * FHPEAPEANAI.FPEOGFMKMKJ_Point * FHPEAPEANAI.PJEFKNPJEBE_MissionBonus * 10 / 100 / 100) * FHPEAPEANAI.ODCLHPGHDHA_EpisodeBonus / 1000);
			FHPEAPEANAI.JKFCHNEININ_GetPoint = _FCLGIPFPIPH_DashBonus * LCCGDFGGIHI * v;
			FHPEAPEANAI.BPJEOPHAJPP_PrevTotalPoint = (int)FBGDBGKNKOD_GetCurrentPoint();
			FHPEAPEANAI.AHOKAPCGJMA_TotalPoint = FHPEAPEANAI.JKFCHNEININ_GetPoint + FHPEAPEANAI.BPJEOPHAJPP_PrevTotalPoint;
			FHPEAPEANAI.GHBPLHBNMBK_FreeMusicId = OMNOFMEBLAD.GHBPLHBNMBK_FreeMusicId;
			FHPEAPEANAI.JHGGBBNLINH_MilitaryMedalCount = CFJAHCCFIGD_GetDecoAwardCoef(v);
			FHPEAPEANAI.JHGGBBNLINH_MilitaryMedalCount *= FHPEAPEANAI.FCLGIPFPIPH_DashBonus;
			FHPEAPEANAI.JHGGBBNLINH_MilitaryMedalCount *= LCCGDFGGIHI;
			if(!IKGLAFOHGDO)
			{
				if(FHPEAPEANAI.JHGGBBNLINH_MilitaryMedalCount > 0)
				{
					int itId = NEBKOHHKGBA_GetDecoItemId();
					if(itId > 0)
					{
						JKNGJFOBADP j = new JKNGJFOBADP();
						j.JCHLONCMPAJ();
						j.FEGDNPIEKJC(OAGBCBBHMPF.COIIJOEKBDH.EAKANCJFFKF_21, "");
						j.CPIICACGNBH_AddItem(CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_PlayerData, itId, FHPEAPEANAI.JHGGBBNLINH_MilitaryMedalCount, null, 0);
					}
				}
				save.DNBFMLBNAEE_Point = FHPEAPEANAI.AHOKAPCGJMA_TotalPoint;
			}
		}
	}

	// // RVA: 0x113EBC4 Offset: 0x113EBC4 VA: 0x113EBC4
	private int IIGKKMMJONJ()
	{
		List<int> l1 = new List<int>();
		List<int> l2 = new List<int>();
		long t = NKGJPJPHLIF.HHCJCDFCLOB.IBLPICFDGOF_ServerRequester.FJDBNGEPKHL_Time.KMEFBNBFJHI_GetServerTime();
		List<DEKKMGAFJCG_Diva.MNNLOBDPCCH_DivaInfo> dList = CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_PlayerData.DGCJCAHIAPP_Diva.NBIGLBMHEDC_DivaList;
		int d = 0;
		for(int i = 0; i < dList.Count; i++)
		{
			d += dList[i].CPGFPEDMDEH_Have;
		}
		for(int i = 0; i < 6; i++)
		{
			List<IBJAKJJICBC> l3 = IBJAKJJICBC.FMHFMIMDOCM(i + 1, t, false);
			l1.Clear();
			for(int j = 0; j < l3.Count; j++)
			{
				if(!l3[j].LHONOILACFL_IsWeeklyEvent || l3[j].BELHFPMBAPJ_WeekPlay < l3[j].JOJNGDPHOKG_WeeklyMax)
				{
					if(l3[j].ICKDCAMABPD(d) && l3[j].DBJOBFIGGEE_EventBonusPercent > 0)
					{
						l1.Add(l3[j].GHBPLHBNMBK_FreeMusicId);
					}
				}
			}
			if(l1.Count > 0)
			{
				l2.Add(l1[UnityEngine.Random.Range(0, l1.Count)]);
			}
		}
		if(l2.Count == 0)
		{
			l2 = HEACCHAKMFG_GetMusicsList();
		}
		return l2[UnityEngine.Random.Range(0, l2.Count)];
	}

	// // RVA: 0x113E7F4 Offset: 0x113E7F4 VA: 0x113E7F4
	public int JKPDCKDMKBN()
	{
		ACBAHDMEFFL_EventMission ev = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.LBDOLHGDIEB_GetDbSection(JOPOPMLFINI_QuestName) as ACBAHDMEFFL_EventMission;
		if(ev != null)
		{
			long t = NKGJPJPHLIF.HHCJCDFCLOB.IBLPICFDGOF_ServerRequester.FJDBNGEPKHL_Time.KMEFBNBFJHI_GetServerTime();
			int a = 0;
			int b = 0;
			IBJAKJJICBC ib = IBJAKJJICBC.MLMMPFACEKI_FindMusicInLists(IGBPFGPPJOE(), 
				IBJAKJJICBC.FMHFMIMDOCM(1, t, false),
				IBJAKJJICBC.FMHFMIMDOCM(2, t, false),
				IBJAKJJICBC.FMHFMIMDOCM(3, t, false),
				IBJAKJJICBC.FMHFMIMDOCM(4, t, false),
				IBJAKJJICBC.FMHFMIMDOCM(5, t, false),
				IBJAKJJICBC.FMHFMIMDOCM(6, t, false),
				ref a, ref b
			);
			if(ib != null)
			{
				if(ib.LHONOILACFL_IsWeeklyEvent)
				{
					if(ib.BELHFPMBAPJ_WeekPlay < ib.JOJNGDPHOKG_WeeklyMax)
						return 0;
					return 2;
				}
				else
					return 0;
			}
			return 1;
		}
		return 0;
	}

	// // RVA: 0x1140EAC Offset: 0x1140EAC VA: 0x1140EAC Slot: 76
	public override void MMIMJPNLKBK()
	{
		if(GFHKFKHBIGM)
		{
			ACBAHDMEFFL_EventMission ev = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.LBDOLHGDIEB_GetDbSection(JOPOPMLFINI_QuestName) as ACBAHDMEFFL_EventMission;
			if(ev != null)
			{
                OKLMJPBJHKL_EventMission.MKIGCLOBJBI save = CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_PlayerData.MENGHOKMOIE_EventMission.FBCJICEPLED[ev.NGHKJOEDLIP_Settings.MOEKELIIDEO_SaveIdx];
				save.INLNJOGHLJE_Show = (int)(save.INLNJOGHLJE_Show & 0xfffffffb);
				GFHKFKHBIGM = false;
            }
		}
	}

	// // RVA: 0x1141128 Offset: 0x1141128 VA: 0x1141128
	public int NCDLFEHONME_GetGachaBoxEventId()
	{
		return BAEPGOAMBDK("gacha_box_event_id", 0);
	}

	// // RVA: 0x114119C Offset: 0x114119C VA: 0x114119C
	public CHHECNJBMLA_EventBoxGacha FPCNGEEEDFM_GetContextEvent()
	{
		CHHECNJBMLA_EventBoxGacha ev = JEPBIIJDGEF_EventInfo.HHCJCDFCLOB.OIKOHACJPCB_GetEventById(NCDLFEHONME_GetGachaBoxEventId()) as CHHECNJBMLA_EventBoxGacha;
		return ev;
	}

	// // RVA: 0x11412F4 Offset: 0x11412F4 VA: 0x11412F4 Slot: 77
	public override string DBEMCLMPCFA_GetBannerText()
	{
		ACBAHDMEFFL_EventMission ev = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.LBDOLHGDIEB_GetDbSection(JOPOPMLFINI_QuestName) as ACBAHDMEFFL_EventMission;
		if(ev != null)
		{
			long t = NKGJPJPHLIF.HHCJCDFCLOB.IBLPICFDGOF_ServerRequester.FJDBNGEPKHL_Time.KMEFBNBFJHI_GetServerTime();
			for(int i = 0; i < ev.LLCLJBEJOPM_BannerInfo.Count; i++)
			{
				if(ev.LLCLJBEJOPM_BannerInfo[i].PDBPFJJCADD_open_at <= t && ev.LLCLJBEJOPM_BannerInfo[i].FDBNFFNFOND_CloseAt > t)
					return ev.LLCLJBEJOPM_BannerInfo[i].KLMPFGOCBHC_description;
			}
		}
		return "";
	}

	// // RVA: 0x1141670 Offset: 0x1141670 VA: 0x1141670 Slot: 78
	public override long OEGAJJANHGL()
	{
		ACBAHDMEFFL_EventMission ev = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.LBDOLHGDIEB_GetDbSection(JOPOPMLFINI_QuestName) as ACBAHDMEFFL_EventMission;
		if(ev != null)
		{
			return ev.NGHKJOEDLIP_Settings.JBFDHOIKAIK_InventoryEndDate;
		}
		return 0;
	}
}
