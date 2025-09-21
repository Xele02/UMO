
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using XeApp.Game.Menu;
using XeSys;

[System.Obsolete("Use KNKDBNFMAKF_EventSp", true)]
public class KNKDBNFMAKF { }
public class KNKDBNFMAKF_EventSp : IKDICBBFBMI_EventBase
{
	private const int GHJHJDIDCFA = 3;
	private EECOJKDJIFG KBACNOCOANM_Ranking; // 0xE8
	public bool EGOJLOEFMOH_IsUpdateLimitedMusic; // 0xEC
	public int BCBCODAKIDN_DescType; // 0xF0
	public bool KDDBNAIJKAD_ResetDisable; // 0xF4
	public bool KIBBLLADDPO; // 0xF5
	private List<int> IHKIFGPICLG_HelpIds = new List<int>(); // 0xF8
	private StringBuilder KHDPDECJHLD = new StringBuilder(); // 0xFC
	private static readonly int[] NHBMCIHGNIM = new int[2] { 1, 4 }; // 0x0
	private static readonly int[] IKMPCCPNGBP = new int[2] { 2, 8 }; // 0x4

	public override OHCAABOMEOF.KGOGMKMBCPP_EventType HIDHLFCBIDE_EventType { get { return OHCAABOMEOF.KGOGMKMBCPP_EventType.ENPJADLIFAB_EventSp; } } //0x1123014 DKHCGLCNKCD  Slot: 4

	// // RVA: 0x112301C Offset: 0x112301C VA: 0x112301C Slot: 32
	public override EECOJKDJIFG DAKMIKNKHMF_GetRankingInfoForIndex(int LHJCOPMMIGO/* = 0*/)
	{
		return KBACNOCOANM_Ranking;
	}

	// RVA: 0x1123024 Offset: 0x1123024 VA: 0x1123024
	public KNKDBNFMAKF_EventSp(string _OPFGFINHFCE_name) : base(_OPFGFINHFCE_name)
    {
        return;
    }

	// // RVA: 0x1123108 Offset: 0x1123108 VA: 0x1123108 Slot: 5
	public override string IFKKBHPMALH()
	{
		OEIJEFBBJBD_EventSp ev = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.LBDOLHGDIEB_GetDbSection(JOPOPMLFINI_QuestName) as OEIJEFBBJBD_EventSp;
		if(ev != null && GPHEKCNDDIK)
		{
			return ev.NGHKJOEDLIP_Settings.OCDMGOGMHGE;
		}
		return null;
	}

	// // RVA: 0x1123290 Offset: 0x1123290 VA: 0x1123290
	public List<int> GFPCPHOEAFG()
	{
		return IHKIFGPICLG_HelpIds;
	}

	// // RVA: 0x1123298 Offset: 0x1123298 VA: 0x1123298
	public List<int> COILOHPIAFL(long _JHNMKKNEENE_Time, long NCHKMPGONNO)
	{
		List<int> res = new List<int>();
		OEIJEFBBJBD_EventSp ev = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.LBDOLHGDIEB_GetDbSection(JOPOPMLFINI_QuestName) as OEIJEFBBJBD_EventSp;
		if(ev != null && GPHEKCNDDIK)
		{
			for(int i = 0; i < ev.ODACAJBCJHO.Count; i++)
			{
				if(ev.ODACAJBCJHO[i].PLALNIIBLOF_en > 1)
				{
					if(ev.ODACAJBCJHO[i].PDBPFJJCADD_open_at >= NCHKMPGONNO && _JHNMKKNEENE_Time >= ev.ODACAJBCJHO[i].PDBPFJJCADD_open_at && ev.ODACAJBCJHO[i].FDBNFFNFOND_CloseAt >= _JHNMKKNEENE_Time)
					{
						res.Add(ev.ODACAJBCJHO[i].EJBGHLOOLBC_HelpIds);
					}
				}
			}
		}
		return res;
	}

	// // RVA: 0x1123544 Offset: 0x1123544 VA: 0x1123544
	public int BAEEGPJJHKD_GetNumSubSp()
	{
		OEIJEFBBJBD_EventSp ev = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.LBDOLHGDIEB_GetDbSection(JOPOPMLFINI_QuestName) as OEIJEFBBJBD_EventSp;
		if(ev != null && GPHEKCNDDIK)
		{
			return ev.JHMBHHPDPKN_SubEventIds.Count;
		}
		return 0;
	}

	// // RVA: 0x11236D8 Offset: 0x11236D8 VA: 0x11236D8
	public int NBLGLKGOKOD_GetSubSpId(int _OIPCCBHIKIA_index)
	{
		OEIJEFBBJBD_EventSp ev = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.LBDOLHGDIEB_GetDbSection(JOPOPMLFINI_QuestName) as OEIJEFBBJBD_EventSp;
		if(ev != null && GPHEKCNDDIK)
		{
			return ev.JHMBHHPDPKN_SubEventIds[_OIPCCBHIKIA_index];
		}
		return 0;
	}

	// // RVA: 0x1123874 Offset: 0x1123874 VA: 0x1123874
	public List<int> OKBLKNPJPKJ_GetSubIds()
	{
		OEIJEFBBJBD_EventSp ev = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.LBDOLHGDIEB_GetDbSection(JOPOPMLFINI_QuestName) as OEIJEFBBJBD_EventSp;
		if(ev != null && GPHEKCNDDIK)
		{
			return ev.JHMBHHPDPKN_SubEventIds;
		}
		return null;
	}

	// // RVA: 0x11239E4 Offset: 0x11239E4 VA: 0x11239E4
	public int CKBANLLONPF(long _JHNMKKNEENE_Time)
	{
		OEIJEFBBJBD_EventSp ev = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.LBDOLHGDIEB_GetDbSection(JOPOPMLFINI_QuestName) as OEIJEFBBJBD_EventSp;
		if(ev != null && GPHEKCNDDIK)
		{
			List<OEIJEFBBJBD_EventSp.NJJEAKMBGPN> l = ev.EOKILLGMGDL.FindAll((OEIJEFBBJBD_EventSp.NJJEAKMBGPN _GHPLINIACBB_x) =>
			{
				//0x112CCC0
				return _JHNMKKNEENE_Time >= _GHPLINIACBB_x.PDBPFJJCADD_open_at && _GHPLINIACBB_x.FDBNFFNFOND_CloseAt >= _JHNMKKNEENE_Time;
			});
			if(l.Count > 0)
			{
				l.Sort((OEIJEFBBJBD_EventSp.NJJEAKMBGPN HKICMNAACDA, OEIJEFBBJBD_EventSp.NJJEAKMBGPN BNKHBCBJBKI) =>
				{
					//0x112CC80
					return BNKHBCBJBKI.BDEOMEBFDFF_GachaId - HKICMNAACDA.BDEOMEBFDFF_GachaId;
				});
				return l[0].BDEOMEBFDFF_GachaId;
			}
		}
		return 0;
	}

	// // RVA: 0x1123DA4 Offset: 0x1123DA4 VA: 0x1123DA4 Slot: 28
	public override long FBGDBGKNKOD_GetCurrentPoint()
	{
		OEIJEFBBJBD_EventSp ev = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.LBDOLHGDIEB_GetDbSection(JOPOPMLFINI_QuestName) as OEIJEFBBJBD_EventSp;
		if(ev != null && GPHEKCNDDIK)
		{
			NILOACEHJKJ_EventSP.MDCMFPENCEK save = CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_PlayerData.DAKCBBBMIMD_EventSP.FBCJICEPLED[ev.NGHKJOEDLIP_Settings.MOEKELIIDEO_SaveIdx];
			return save.DNBFMLBNAEE_Point;
		}
		return 0;
	}

	// // RVA: 0x1124004 Offset: 0x1124004 VA: 0x1124004 Slot: 29
	public override void MJFKJHJJLMN_GetRanks(int LHJCOPMMIGO/* = 0*/, bool _FBBNPFFEJBN_Force/* = false*/)
	{
		NPNNPNAIONN_IsError = false;
		PLOOEECNHFB_IsDone = false;
		OEIJEFBBJBD_EventSp ev/*OHGNMDOGLJM*/ = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.LBDOLHGDIEB_GetDbSection(JOPOPMLFINI_QuestName) as OEIJEFBBJBD_EventSp;
		if(ev != null && GPHEKCNDDIK)
		{
			int get_rank_cooling_time = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.GDEKCOOBLMA_System.LPJLEHAJADA("get_rank_cooling_time", 60);
			if(_FBBNPFFEJBN_Force || (NKGJPJPHLIF.HHCJCDFCLOB.IBLPICFDGOF_ServerRequester.FJDBNGEPKHL_Time.KMEFBNBFJHI_GetServerTime() - KPOMHFLKMKI_LastRankUpdateTime[LHJCOPMMIGO] >= get_rank_cooling_time))
			{
				//LAB_01124374
				KKLGENJKEBN.HHCJCDFCLOB.HEOKADCEAGL_GetRanks(ev.NGHKJOEDLIP_Settings.OCGFKMHNEOF_name_for_api, () =>
				{
					//0x112CD14
					CDINKAANIAA_Rank[LHJCOPMMIGO] = (int)KKLGENJKEBN.HHCJCDFCLOB.LPPCNCMEDFA_Rank;
					KPOMHFLKMKI_LastRankUpdateTime[LHJCOPMMIGO] = NKGJPJPHLIF.HHCJCDFCLOB.IBLPICFDGOF_ServerRequester.FJDBNGEPKHL_Time.KMEFBNBFJHI_GetServerTime();
					PLOOEECNHFB_IsDone = true;
				}, () =>
				{
					//0x112CED8
					KPOMHFLKMKI_LastRankUpdateTime[LHJCOPMMIGO] = NKGJPJPHLIF.HHCJCDFCLOB.IBLPICFDGOF_ServerRequester.FJDBNGEPKHL_Time.KMEFBNBFJHI_GetServerTime();
					CDINKAANIAA_Rank[LHJCOPMMIGO] = 0;
					PLOOEECNHFB_IsDone = true;
				}, () =>
				{
					//0x112D080
					CDINKAANIAA_Rank[LHJCOPMMIGO] = 0;
					PLOOEECNHFB_IsDone = true;
					NPNNPNAIONN_IsError = true;
				}, () =>
				{
					//0x112D118
					CDINKAANIAA_Rank[LHJCOPMMIGO] = 0;
					PLOOEECNHFB_IsDone = true;
					FKKDIDMGLMI_IsDroppedPlayer = true;
				});
				return;
			}
		}
		else
		{
			CDINKAANIAA_Rank[LHJCOPMMIGO] = 0;
		}
		PLOOEECNHFB_IsDone = true;
	}

	// // RVA: 0x11244E4 Offset: 0x11244E4 VA: 0x11244E4 Slot: 30
	protected override bool JIHMLILFOPG_IsEventActive(long _JHNMKKNEENE_Time)
	{
		OEIJEFBBJBD_EventSp ev/*OHGNMDOGLJM*/ = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.LBDOLHGDIEB_GetDbSection(JOPOPMLFINI_QuestName) as OEIJEFBBJBD_EventSp;
		if(ev != null)
		{
			GDIPLANPCEI g = IMMAOANGPNK.HHCJCDFCLOB.ACEFBFLFKFD_GetScheduleEventData(ev.JIKKNHIAEKG_BlockName, _JHNMKKNEENE_Time);
			if(g != null)
			{
				if(_JHNMKKNEENE_Time < ev.NGHKJOEDLIP_Settings.OHGDNJLFDFF_Start)
					return false;
				if(ev.NGHKJOEDLIP_Settings.PHKLJGNMFBL_End < _JHNMKKNEENE_Time)
					return false;
				if(ev.NGHKJOEDLIP_Settings.HKKNEAGCIEB_RankingSupport != 0)
				{
					if(KKLGENJKEBN.HHCJCDFCLOB.JPDPFGFMKHK_rankings.Find((EECOJKDJIFG PKLPKMLGFGK) =>
					{
						//0x112D1B0
						return ev.NGHKJOEDLIP_Settings.OCGFKMHNEOF_name_for_api == PKLPKMLGFGK.OCGFKMHNEOF_name_for_api;
					}) == null)
					{
						return false;
					}
					else
					{
						UnityEngine.Debug.LogError("Ranking not found : "+ev.NGHKJOEDLIP_Settings.OCGFKMHNEOF_name_for_api);
					}
				}
				return true;
			}
		}
		return false;
	}

	// // RVA: 0x1124808 Offset: 0x1124808 VA: 0x1124808 Slot: 31
	protected override bool IMCMNOPNGHO(long _JHNMKKNEENE_Time)
	{
		OEIJEFBBJBD_EventSp ev/*OHGNMDOGLJM*/ = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.LBDOLHGDIEB_GetDbSection(JOPOPMLFINI_QuestName) as OEIJEFBBJBD_EventSp;
		if(ev != null)
		{
			NILOACEHJKJ_EventSP.MDCMFPENCEK save = CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_PlayerData.DAKCBBBMIMD_EventSP.FBCJICEPLED[ev.NGHKJOEDLIP_Settings.MOEKELIIDEO_SaveIdx];
			bool b2;
			if(ev.NGHKJOEDLIP_Settings.HKKNEAGCIEB_RankingSupport == 0)
			{
				b2 = false;
			}
			else
			{
				b2 = save.MPCAGEPEJJJ_Key == ev.NGHKJOEDLIP_Settings.OCGFKMHNEOF_name_for_api;
			}
			AGLILDLEFDK_Missions = ev.NNMPGOAGEOL_quests;
			OLDFFDMPEBM_Quests = save.NNMPGOAGEOL_quests;
			if(b2 || save.EGBOHDFBAPB_CloseAt == 0 || (!RuntimeSettings.CurrentSettings.UnlimitedEvent && save.EGBOHDFBAPB_CloseAt < ev.NGHKJOEDLIP_Settings.OHGDNJLFDFF_Start))
			{
				save.LHPDDGIJKNB_Reset();
				if(ev.NGHKJOEDLIP_Settings.HKKNEAGCIEB_RankingSupport != 0)
					save.MPCAGEPEJJJ_Key = ev.NGHKJOEDLIP_Settings.OCGFKMHNEOF_name_for_api;
				save.EGBOHDFBAPB_CloseAt = ev.NGHKJOEDLIP_Settings.IDDBFFBPNGI_RewardEnd;
				save.LGADCGFMLLD_step = 1;
				save.BEBJKJKBOGH_Date = _JHNMKKNEENE_Time;
				KOMAHOAEMEK(true);
				for(int i = 0; i < IKMPCCPNGBP.Length; i++)
				{
					ALIBGNACAEA(false, i);
				}
			}
			KOMAHOAEMEK(false);
			for(int i = 0; i < NHBMCIHGNIM.Length; i++)
			{
				CFIINCJGBJB(NCGDLDGCIFM(i), i);
			}
			return true;
		}
		return false;
	}

	// // RVA: 0x1125050 Offset: 0x1125050 VA: 0x1125050 Slot: 40
	protected override void KKFLDCBHFJA(long _JHNMKKNEENE_Time)
	{
		OEIJEFBBJBD_EventSp ev/*OHGNMDOGLJM*/ = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.LBDOLHGDIEB_GetDbSection(JOPOPMLFINI_QuestName) as OEIJEFBBJBD_EventSp;
		if(ev != null)
		{
			IBNKPMPFLGI_IsRankReward = ev.NGHKJOEDLIP_Settings.HKKNEAGCIEB_RankingSupport != 0;
			if(IBNKPMPFLGI_IsRankReward)
			{
				KBACNOCOANM_Ranking = KKLGENJKEBN.HHCJCDFCLOB.JPDPFGFMKHK_rankings.Find((EECOJKDJIFG PKLPKMLGFGK) =>
				{
					//0x112D210
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
			PBHNFNIHDJJ = ev.NGHKJOEDLIP_Settings.HFNIHKOAMGC;
			NHGPCLGPEHH_TicketType = ev.NGHKJOEDLIP_Settings.MJBKGOJBPAD_item_type;
			FBHONHONKGD_MusicSelectDesc = ev.NGHKJOEDLIP_Settings.FEMMDNIELFC_Desc;
			GFIBLLLHMPD_StartAdventureId = ev.NGHKJOEDLIP_Settings.HIOOGLEJBKM_StartAdventureId;
			LEPALMDKEOK_IsPointReward = true;
			CAKEOPLJDAF_EndAdventureId = ev.NGHKJOEDLIP_Settings.FJCADCDNPMP_EndAdventureId;
			for(int i = 0; i < KPOMHFLKMKI_LastRankUpdateTime.Count(); i++)
			{
				KPOMHFLKMKI_LastRankUpdateTime[i] = 0;
			}
			if(!string.IsNullOrEmpty(ev.NGHKJOEDLIP_Settings.OMCAOJJGOGG_Lb))
			{
				string[] strs = ev.NGHKJOEDLIP_Settings.OMCAOJJGOGG_Lb.Split(new char[]{','});
				MFDJIFIIPJD m = new MFDJIFIIPJD();
				m.KHEKNNFCAOI_Init(int.Parse(strs[0]), int.Parse(strs[1]));
				BHABCGJCGNO = m;
			}
			GPHEKCNDDIK = true;
		}
	}

	// // RVA: 0x1125644 Offset: 0x1125644 VA: 0x1125644 Slot: 46
	protected override void PJDGDNJNCNM_UpdateStatusImpl(long _JHNMKKNEENE_Time)
	{
		KIBBLLADDPO = false;
		KGCNCBOKCBA.GNENJEHKMHD_EventStatus s = KGCNCBOKCBA.GNENJEHKMHD_EventStatus.HJNNKCMLGFL_0_None;
		OEIJEFBBJBD_EventSp ev = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.LBDOLHGDIEB_GetDbSection(JOPOPMLFINI_QuestName) as OEIJEFBBJBD_EventSp;
		if(ev != null)
		{
			NILOACEHJKJ_EventSP.MDCMFPENCEK save = CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_PlayerData.DAKCBBBMIMD_EventSP.FBCJICEPLED[ev.NGHKJOEDLIP_Settings.MOEKELIIDEO_SaveIdx];
			s = KGCNCBOKCBA.GNENJEHKMHD_EventStatus.FFLKPBPBPEP_1;
			if(_JHNMKKNEENE_Time >= ev.NGHKJOEDLIP_Settings.OHGDNJLFDFF_Start)
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
					//LAB_0112597c
					if(!save.IMFBCJOIJKJ_Entry)
						s = KGCNCBOKCBA.GNENJEHKMHD_EventStatus.NCJFJLPJMLI_2;
					else
					{
						s = KGCNCBOKCBA.GNENJEHKMHD_EventStatus.MEAJLPAHINL_ChallengePeriod_5;
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
					}
				}
				else
				{
					s = KGCNCBOKCBA.GNENJEHKMHD_EventStatus.EMAMLLFAOJI_Counting_6;
					if(_JHNMKKNEENE_Time >= ev.NGHKJOEDLIP_Settings.JGMDAOACOJF_RewardStart)
					{
						if(_JHNMKKNEENE_Time >= ev.NGHKJOEDLIP_Settings.IDDBFFBPNGI_RewardEnd)
						{
							s = KGCNCBOKCBA.GNENJEHKMHD_EventStatus.DOAENCHBAEO_11;
							if(_JHNMKKNEENE_Time >= ev.NGHKJOEDLIP_Settings.KNLGKBBIBOH_RewardEnd2)
							{
								s = KGCNCBOKCBA.GNENJEHKMHD_EventStatus.HINPDNKNAHO_10;
							}
						}
						else
						{
							s = KGCNCBOKCBA.GNENJEHKMHD_EventStatus.DDEODFNANDO_8_ResultRewardToReceive;
							if(save.HPLMECLKFID_R_Rcv)
								s = KGCNCBOKCBA.GNENJEHKMHD_EventStatus.BCKENOKGLIJ_9_ResultRewardreceived;
						}
					}
				}
			}
		}
		NGOFCFJHOMI_Status = s;
	}

	// // RVA: 0x1125AB8 Offset: 0x1125AB8 VA: 0x1125AB8 Slot: 47
	public override void NBMDAOFPKGK(int _DNBFMLBNAEE_Point)
	{
		OEIJEFBBJBD_EventSp ev = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.LBDOLHGDIEB_GetDbSection(JOPOPMLFINI_QuestName) as OEIJEFBBJBD_EventSp;
		if(ev != null)
		{
			NILOACEHJKJ_EventSP.MDCMFPENCEK save = CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_PlayerData.DAKCBBBMIMD_EventSP.FBCJICEPLED[ev.NGHKJOEDLIP_Settings.MOEKELIIDEO_SaveIdx];
			save.DNBFMLBNAEE_Point += _DNBFMLBNAEE_Point;
			save.NFIOKIBPJCJ_uptime = NKGJPJPHLIF.HHCJCDFCLOB.IBLPICFDGOF_ServerRequester.FJDBNGEPKHL_Time.KMEFBNBFJHI_GetServerTime();
		}
	}

	// // RVA: 0x1125E08 Offset: 0x1125E08 VA: 0x1125E08 Slot: 49
	protected override void ODPJGHOJIOH(int LHJCOPMMIGO)
	{
		if(KBACNOCOANM_Ranking != null)
		{
			OEIJEFBBJBD_EventSp ev = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.LBDOLHGDIEB_GetDbSection(JOPOPMLFINI_QuestName) as OEIJEFBBJBD_EventSp;
			if(ev != null)
			{
				NILOACEHJKJ_EventSP.MDCMFPENCEK save = CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_PlayerData.DAKCBBBMIMD_EventSP.FBCJICEPLED[ev.NGHKJOEDLIP_Settings.MOEKELIIDEO_SaveIdx];
				PJDGDNJNCNM_UpdateStatusImpl(NKGJPJPHLIF.HHCJCDFCLOB.IBLPICFDGOF_ServerRequester.FJDBNGEPKHL_Time.KMEFBNBFJHI_GetServerTime());
				if(IBNKPMPFLGI_IsRankReward || NGOFCFJHOMI_Status == KGCNCBOKCBA.GNENJEHKMHD_EventStatus.NCJFJLPJMLI_2 ||
					NGOFCFJHOMI_Status == KGCNCBOKCBA.GNENJEHKMHD_EventStatus.MINDIGBAJFG_3 ||
					NGOFCFJHOMI_Status == KGCNCBOKCBA.GNENJEHKMHD_EventStatus.MEAJLPAHINL_ChallengePeriod_5 ||
					NGOFCFJHOMI_Status == KGCNCBOKCBA.GNENJEHKMHD_EventStatus.EMAMLLFAOJI_Counting_6) //0x6cU
				{
					KKLGENJKEBN.HHCJCDFCLOB.LDOBHAAIDEJ_UpdateRankingScore(KBACNOCOANM_Ranking.OCGFKMHNEOF_name_for_api, LHJCOPMMIGO, BOAGCEOHJEO.GOAOBNBGDBJ(GLIMIGNNGGB_RankingStart, LOLAANGCGDO_RankingEnd2, save.NFIOKIBPJCJ_uptime, save.DNBFMLBNAEE_Point), () =>
					{
						//0x112D270
						CDINKAANIAA_Rank[LHJCOPMMIGO] = (int)KKLGENJKEBN.HHCJCDFCLOB.LPPCNCMEDFA_Rank;
						PLOOEECNHFB_IsDone = true;
						int ranking_point_max = ev.LPJLEHAJADA("ranking_point_max", 1000000);
						ILCCJNDFFOB.HHCJCDFCLOB.NNFGBBCHLPC(PGIIDPEGGPI_EventId, "StringLiteral_10929", EJDJIBPKKNO_BasePoint, save.DNBFMLBNAEE_Point, ranking_point_max, KKLGENJKEBN.HHCJCDFCLOB.DFBALJAPHMC_DroppedPlayer);
					}, () =>
					{
						//0x112D4A8
						PLOOEECNHFB_IsDone = true;
					}, () =>
					{
						//0x112D4D0
						PLOOEECNHFB_IsDone = true;
						NPNNPNAIONN_IsError = true;
					});
					return;
				}
			}
		}
		PLOOEECNHFB_IsDone = true;
	}

	// // RVA: 0x1126330 Offset: 0x1126330 VA: 0x1126330 Slot: 50
	protected override void MFJFBNPLFBE_OnReceieveTotalReward(bool GIPBIDFJFLL)
	{
		return;
	}

	// // RVA: 0x1126334 Offset: 0x1126334 VA: 0x1126334 Slot: 52
	public override void FAMFKPBPIAA_GetRankingPlayerList(bool PFFJNEFNAMI, int CJHEHIMLGGL, int LHJCOPMMIGO, LIOLBKLMMIK _KLMFJJCNBIP_OnSuccess, DJBHIFLHJLK _IDAEHNGOKAE_OnRankingError, DJBHIFLHJLK _JGKOLBLPMPG_OnFail)
	{
		NPNNPNAIONN_IsError = false;
		PLOOEECNHFB_IsDone = false;
		OEIJEFBBJBD_EventSp ev = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.LBDOLHGDIEB_GetDbSection(JOPOPMLFINI_QuestName) as OEIJEFBBJBD_EventSp;
		if(ev != null)
		{
			if(IBNKPMPFLGI_IsRankReward)
			{
				KKLGENJKEBN.HHCJCDFCLOB.FAMFKPBPIAA_GetRankingPlayerList(KBACNOCOANM_Ranking.OCGFKMHNEOF_name_for_api, PFFJNEFNAMI, CJHEHIMLGGL, LHJCOPMMIGO, (int NEFEFHBHFFF, List<IBIGBMDANNM> MAGKKPOFJIM) =>
				{
					//0x112D514
					PLOOEECNHFB_IsDone = true;
					_KLMFJJCNBIP_OnSuccess(NEFEFHBHFFF, MAGKKPOFJIM);
				}, () =>
				{
					//0x112D570
					PLOOEECNHFB_IsDone = true;
					_IDAEHNGOKAE_OnRankingError();
				}, () =>
				{
					//0x112D5BC
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

	// // RVA: 0x112666C Offset: 0x112666C VA: 0x112666C Slot: 53
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
				//0x112D620
				PLOOEECNHFB_IsDone = true;
				_KLMFJJCNBIP_OnSuccess(_JGNBPFCJLKI_d, MAGKKPOFJIM);
			}, () =>
			{
				//0x112D67C
				PLOOEECNHFB_IsDone = true;
				_IDAEHNGOKAE_OnRankingError();
			}, () =>
			{
				//0x112D6C8
				PLOOEECNHFB_IsDone = true;
				NPNNPNAIONN_IsError = true;
				_JGKOLBLPMPG_OnFail();
			}, false);
		}
	}

	// // RVA: 0x1126870 Offset: 0x1126870 VA: 0x1126870
	// private int APJDIPINLLK(List<int> HNLFPKNBOHE, int _PPFNGGCBJKC_id) { }

	// // RVA: 0x1126968 Offset: 0x1126968 VA: 0x1126968 Slot: 51
	public override IHAEIOAKEMG ILICNKILFKJ_GetNextReward()
	{
		for(int i = 0; i < PFPJHJJAGAG_Rewards.Count; i++)
		{
			if(!PFPJHJJAGAG_Rewards[i].HMEOAKCLKJE_IsReceived)
				return PFPJHJJAGAG_Rewards[i];
		}
		return null;
	}

	// // RVA: 0x1126A7C Offset: 0x1126A7C VA: 0x1126A7C Slot: 58
	protected override void LMGMELPOGMH(int LHJCOPMMIGO)
	{
		OEIJEFBBJBD_EventSp ev = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.LBDOLHGDIEB_GetDbSection(JOPOPMLFINI_QuestName) as OEIJEFBBJBD_EventSp;
		if(ev != null)
		{
			if(IBNKPMPFLGI_IsRankReward)
			{
				OKPEFAPPFDH_GetRanksAroundSelf req = NKGJPJPHLIF.HHCJCDFCLOB.IBLPICFDGOF_ServerRequester.IFFNCAFNEAG_AddRequest(new OKPEFAPPFDH_GetRanksAroundSelf(false));
				req.EMPNJPMAKBF_Id = KBACNOCOANM_Ranking.PPFNGGCBJKC_id;
				req.MJGOBEGONON_Type = 0;
				req.NHPCKCOPKAM_from = 0;
				req.PJFKNNNDMIA_to = 0;
				req.MOBEEPPKFLG_OnFail = (CACGCMBKHDI_Request KCFBGMKDIMI) =>
				{
					//0x112D72C
					if(JGJFFKPFMDB.BDGBCCGLLAJ_IsRankingError(KCFBGMKDIMI.CJMFJOMECKI_ErrorId))
					{
						if(KCFBGMKDIMI.CJMFJOMECKI_ErrorId == SakashoErrorId.RANKING_DROPPED_PLAYER)
						{
							FKKDIDMGLMI_IsDroppedPlayer = true;
						}
						NILOACEHJKJ_EventSP.MDCMFPENCEK save = CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_PlayerData.DAKCBBBMIMD_EventSP.FBCJICEPLED[ev.NGHKJOEDLIP_Settings.MOEKELIIDEO_SaveIdx];
						save.HPLMECLKFID_R_Rcv = true;
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
					//0x112DA58
					OKPEFAPPFDH_GetRanksAroundSelf r = KCFBGMKDIMI as OKPEFAPPFDH_GetRanksAroundSelf;
					if(r.NFEAMMJIMPG_Result.EJDEDOJFOOK.Count == 0)
					{
						NILOACEHJKJ_EventSP.MDCMFPENCEK save = CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_PlayerData.DAKCBBBMIMD_EventSP.FBCJICEPLED[ev.NGHKJOEDLIP_Settings.MOEKELIIDEO_SaveIdx];
						save.HPLMECLKFID_R_Rcv = true;
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
							//0x112E12C
							for(int i = 0; i < KKLGENJKEBN.HHCJCDFCLOB.PHOPJDPEHJA.Count; i++)
							{
								MFDJIFIIPJD m = new MFDJIFIIPJD();
								m.KHEKNNFCAOI_Init(KKLGENJKEBN.HHCJCDFCLOB.PHOPJDPEHJA[i].JJBGOIMEIPF_ItemId, KKLGENJKEBN.HHCJCDFCLOB.PHOPJDPEHJA[i].MBJIFDBEDAC_item_count);
								HLFHJIDHJMP.HBHMAKNGKFK_Items.Add(m);
							}
							ILCCJNDFFOB.HHCJCDFCLOB.GIBLHFKIMDA(this);
							NILOACEHJKJ_EventSP.MDCMFPENCEK save = CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_PlayerData.DAKCBBBMIMD_EventSP.FBCJICEPLED[ev.NGHKJOEDLIP_Settings.MOEKELIIDEO_SaveIdx];
							save.HPLMECLKFID_R_Rcv = true;
							PLOOEECNHFB_IsDone = true;
						}, () =>
						{
							//0x112E4A8
							HLFHJIDHJMP = null;
							ILCCJNDFFOB.HHCJCDFCLOB.GIBLHFKIMDA(this);
							NILOACEHJKJ_EventSP.MDCMFPENCEK save = CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_PlayerData.DAKCBBBMIMD_EventSP.FBCJICEPLED[ev.NGHKJOEDLIP_Settings.MOEKELIIDEO_SaveIdx];
							save.HPLMECLKFID_R_Rcv = true;
							PLOOEECNHFB_IsDone = true;
						}, () =>
						{
							//0x112E690
							NILOACEHJKJ_EventSP.MDCMFPENCEK save = CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_PlayerData.DAKCBBBMIMD_EventSP.FBCJICEPLED[ev.NGHKJOEDLIP_Settings.MOEKELIIDEO_SaveIdx];
							save.HPLMECLKFID_R_Rcv = true;
							PLOOEECNHFB_IsDone = true;
							HLFHJIDHJMP = null;
						}, () =>
						{
							//0x112E81C
							PLOOEECNHFB_IsDone = true;
							HLFHJIDHJMP = null;
						}, () =>
						{
							//0x112E864
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

	// // RVA: 0x1126E0C Offset: 0x1126E0C VA: 0x1126E0C Slot: 59
	public override List<int> AEGDKBNNDBC_GetDrops()
	{
		return null;
	}

	// // RVA: 0x1126E14 Offset: 0x1126E14 VA: 0x1126E14 Slot: 65
	protected override bool JLPDECMHLIM_CanShowStartAdventureInternal()
	{
		long t = NKGJPJPHLIF.HHCJCDFCLOB.IBLPICFDGOF_ServerRequester.FJDBNGEPKHL_Time.KMEFBNBFJHI_GetServerTime();
		PJDGDNJNCNM_UpdateStatusImpl(t);
		OEIJEFBBJBD_EventSp ev = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.LBDOLHGDIEB_GetDbSection(JOPOPMLFINI_QuestName) as OEIJEFBBJBD_EventSp;
		if(ev != null)
		{
			NILOACEHJKJ_EventSP.MDCMFPENCEK save = CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_PlayerData.DAKCBBBMIMD_EventSP.FBCJICEPLED[ev.NGHKJOEDLIP_Settings.MOEKELIIDEO_SaveIdx];
			if(save.PIEBOKFJKKH_RTodayCount != NKGJPJPHLIF.HHCJCDFCLOB.DHMLDAGGKCD)
			{
                OEIJEFBBJBD_EventSp.MFEJBIMLPGI d = EBDAPHFECDM(t);
				if(d != null && d.KDGJBBFKLGI_Chapter > 0)
					return !EIACOAMGEPB_GetAdvShown(d.KDGJBBFKLGI_Chapter);
            }
		}
		return false;
	}

	// // RVA: 0x112745C Offset: 0x112745C VA: 0x112745C Slot: 66
	public override void FGDDBFHGCGP_SetStartAdventureShown(bool _JKDJCFEBDHC_Enabled, long _JHNMKKNEENE_Time/* = 0*/)
	{
		if(_JKDJCFEBDHC_Enabled)
		{
			OEIJEFBBJBD_EventSp ev = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.LBDOLHGDIEB_GetDbSection(JOPOPMLFINI_QuestName) as OEIJEFBBJBD_EventSp;
			if(ev != null)
			{
				NILOACEHJKJ_EventSP.MDCMFPENCEK save = CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_PlayerData.DAKCBBBMIMD_EventSP.FBCJICEPLED[ev.NGHKJOEDLIP_Settings.MOEKELIIDEO_SaveIdx];
				save.PIEBOKFJKKH_RTodayCount = NKGJPJPHLIF.HHCJCDFCLOB.DHMLDAGGKCD;
			}
            OEIJEFBBJBD_EventSp.MFEJBIMLPGI d = EBDAPHFECDM(_JHNMKKNEENE_Time);
			if(d != null && d.KDGJBBFKLGI_Chapter > 0)
			{
				KCFEGCHMHMI_SetAdvShown(d.KDGJBBFKLGI_Chapter, true);
			}
        }
	}

	// // RVA: 0x11279E4 Offset: 0x11279E4 VA: 0x11279E4 Slot: 70
	public override void ADACMHAHHKC_PreSetupEventHome(IMCBBOAFION _BHFHGFKBOHH_OnSuccess, DJBHIFLHJLK _AOCANKOMKFG_OnError)
	{
		N.a.StartCoroutineWatched(NJIEIJJMAHK_Corotuine_PreSetupEventHome(_BHFHGFKBOHH_OnSuccess, _AOCANKOMKFG_OnError));
	}

	// [IteratorStateMachineAttribute] // RVA: 0x6BE10C Offset: 0x6BE10C VA: 0x6BE10C
	// // RVA: 0x1127A3C Offset: 0x1127A3C VA: 0x1127A3C
	private IEnumerator NJIEIJJMAHK_Corotuine_PreSetupEventHome(IMCBBOAFION _BHFHGFKBOHH_OnSuccess, DJBHIFLHJLK _AOCANKOMKFG_OnError)
	{
		long IBCGNDADAEE_Time; // 0x20
		OEIJEFBBJBD_EventSp KEHCNBNPJHB; // 0x28

		//0x112EB84
		IBCGNDADAEE_Time = NKGJPJPHLIF.HHCJCDFCLOB.IBLPICFDGOF_ServerRequester.FJDBNGEPKHL_Time.KMEFBNBFJHI_GetServerTime();
		EGOJLOEFMOH_IsUpdateLimitedMusic = false;
		LPFJADHHLHG = false;
		BCBCODAKIDN_DescType = 0;
		KEHCNBNPJHB = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.LBDOLHGDIEB_GetDbSection(JOPOPMLFINI_QuestName) as OEIJEFBBJBD_EventSp;
		if(KEHCNBNPJHB != null)
		{
			PJDGDNJNCNM_UpdateStatusImpl(IBCGNDADAEE_Time);
			MJFKJHJJLMN_GetRanks(0, false);
			while(!PLOOEECNHFB_IsDone)
				yield return null;
			if(NPNNPNAIONN_IsError)
			{
				//LAB_0112eed0
				if(_AOCANKOMKFG_OnError != null)
					_AOCANKOMKFG_OnError();
			}
			else
			{
				NILOACEHJKJ_EventSP.MDCMFPENCEK save = CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_PlayerData.DAKCBBBMIMD_EventSP.FBCJICEPLED[KEHCNBNPJHB.NGHKJOEDLIP_Settings.MOEKELIIDEO_SaveIdx];
				if(FKKDIDMGLMI_IsDroppedPlayer)
				{
					JHHBAFKMBDL.HHCJCDFCLOB.PEIONAKEPCN_ShowRankingBanPopup(_AOCANKOMKFG_OnError);
				}
				else
				{
					DateTime dt = Utility.GetLocalDateTime(IBCGNDADAEE_Time);
					DateTime dt2 = Utility.GetLocalDateTime(save.BEBJKJKBOGH_Date);
					if(dt.Year != dt2.Year || dt.Month != dt2.Month || dt.Day != dt2.Day)
					{
						save.POENMEGPHCG_reset = 0;
						save.BEBJKJKBOGH_Date = IBCGNDADAEE_Time;
					}
					if(NGOFCFJHOMI_Status == KGCNCBOKCBA.GNENJEHKMHD_EventStatus.GDOPLACICFE_4)
					{
						save.ABBJBPLHFHA_Spurt = true;
						LPFJADHHLHG = true;
						PJDGDNJNCNM_UpdateStatusImpl(IBCGNDADAEE_Time);
					}
					if(save.LGADCGFMLLD_step < 2 && NGOFCFJHOMI_Status < KGCNCBOKCBA.GNENJEHKMHD_EventStatus.EMAMLLFAOJI_Counting_6)
					{
						save.LGADCGFMLLD_step = 2;
						save.IMFBCJOIJKJ_Entry = true;
						if(KIBBLLADDPO)
						{
							save.ABBJBPLHFHA_Spurt = true;
							LPFJADHHLHG = true;
						}
						//LAB_0112f248
					}
					else if(save.LGADCGFMLLD_step != 2 || NGOFCFJHOMI_Status < KGCNCBOKCBA.GNENJEHKMHD_EventStatus.EMAMLLFAOJI_Counting_6)
					{
						//LAB_0112f248
					}
					else
						save.LGADCGFMLLD_step = 3;
					//LAB_0112f248
					IHKIFGPICLG_HelpIds.Clear();
					List<int> l = COILOHPIAFL(IBCGNDADAEE_Time, save.OOBBAGJNDIH_LstHpTime);
					if(l.Count > 0)
					{
						CMPEJEHCOEI = true;
						IHKIFGPICLG_HelpIds.AddRange(l);
					}
					CIOECGOMILE.HHCJCDFCLOB.AIKJMHBDABF_SavePlayerData(() =>
					{
						//0x112E8B0
						ILCCJNDFFOB.HHCJCDFCLOB.DADNPOJNIBL(this);
						if(_BHFHGFKBOHH_OnSuccess != null)
							_BHFHGFKBOHH_OnSuccess();
						PLOOEECNHFB_IsDone = true;
					}, () =>
					{
						//0x112E988
						if(_AOCANKOMKFG_OnError != null)
							_AOCANKOMKFG_OnError();
						PLOOEECNHFB_IsDone = true;
						NPNNPNAIONN_IsError = true;
					}, null);
				}
			}
		}
		else
		{
			NPNNPNAIONN_IsError = true;
			PLOOEECNHFB_IsDone = true;
			if(_AOCANKOMKFG_OnError != null)
				_AOCANKOMKFG_OnError();
		}
	}

	// // RVA: 0x1127B18 Offset: 0x1127B18 VA: 0x1127B18 Slot: 33
	public override bool MPMKJNJGFEF_IsEntry()
	{
		OEIJEFBBJBD_EventSp ev = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.LBDOLHGDIEB_GetDbSection(JOPOPMLFINI_QuestName) as OEIJEFBBJBD_EventSp;
		if(ev != null)
		{
        	NILOACEHJKJ_EventSP.MDCMFPENCEK save = CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_PlayerData.DAKCBBBMIMD_EventSP.FBCJICEPLED[ev.NGHKJOEDLIP_Settings.MOEKELIIDEO_SaveIdx];
			return save.IMFBCJOIJKJ_Entry;
		}
		return false;
	}

	// // RVA: 0x1127D78 Offset: 0x1127D78 VA: 0x1127D78 Slot: 69
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

	// // RVA: 0x1127EA0 Offset: 0x1127EA0 VA: 0x1127EA0 Slot: 71
	public override int BAEPGOAMBDK(string _LJNAKDMILMC_key, int MNCOAGOKNAO)
	{
		OEIJEFBBJBD_EventSp ev = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.LBDOLHGDIEB_GetDbSection(JOPOPMLFINI_QuestName) as OEIJEFBBJBD_EventSp;
		if(ev != null)
		{
			return ev.LPJLEHAJADA(_LJNAKDMILMC_key, MNCOAGOKNAO);
		}
		return MNCOAGOKNAO;
	}

	// // RVA: 0x1128020 Offset: 0x1128020 VA: 0x1128020 Slot: 72
	public override string MAICAKMIBEM(string _LJNAKDMILMC_key, string MNCOAGOKNAO)
	{
		OEIJEFBBJBD_EventSp ev = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.LBDOLHGDIEB_GetDbSection(JOPOPMLFINI_QuestName) as OEIJEFBBJBD_EventSp;
		if(ev != null)
		{
			return ev.EFEGBHACJAL(_LJNAKDMILMC_key, MNCOAGOKNAO);
		}
		return MNCOAGOKNAO;
	}

	// // RVA: 0x11281A0 Offset: 0x11281A0 VA: 0x11281A0 Slot: 68
	public override bool GJMGKBDGMOP(long LPEKHFOMCAH)
	{
		OEIJEFBBJBD_EventSp ev = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.LBDOLHGDIEB_GetDbSection(JOPOPMLFINI_QuestName) as OEIJEFBBJBD_EventSp;
		if(ev != null)
		{
			if(BHABCGJCGNO != null)
			{
				if(LPEKHFOMCAH < DPJCPDKALGI_RankingEnd)
				{
            		NILOACEHJKJ_EventSP.MDCMFPENCEK save = CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_PlayerData.DAKCBBBMIMD_EventSP.FBCJICEPLED[ev.NGHKJOEDLIP_Settings.MOEKELIIDEO_SaveIdx];
					if(NKGJPJPHLIF.HHCJCDFCLOB.DHMLDAGGKCD != save.OMCAOJJGOGG_Lb)
					{
						save.OMCAOJJGOGG_Lb = NKGJPJPHLIF.HHCJCDFCLOB.DHMLDAGGKCD;
                        EKLNMHFCAOI.FKGCBLHOOCL_Category cat = EKLNMHFCAOI.BKHFLDMOGBD_GetItemCategory(BHABCGJCGNO.JJBGOIMEIPF_ItemId);
						if(cat == EKLNMHFCAOI.FKGCBLHOOCL_Category.DMMIIBCMCFG_EnergyItem)
						{
							int id = EKLNMHFCAOI.DEACAHNLMNI_getItemId(BHABCGJCGNO.JJBGOIMEIPF_ItemId);
							EGOLBAPFHHD_Common.FKLHGOGJOHH it = CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_PlayerData.KCCLEHLLOFG_Common.KFEBOFKAHAJ_EngItem[id - 1];
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

	// // RVA: 0x1128988 Offset: 0x1128988 VA: 0x1128988 Slot: 75
	public override string FEKEBPKINIM_GetSessionId()
	{
		OEIJEFBBJBD_EventSp ev = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.LBDOLHGDIEB_GetDbSection(JOPOPMLFINI_QuestName) as OEIJEFBBJBD_EventSp;
		if(ev != null)
		{
            NILOACEHJKJ_EventSP.MDCMFPENCEK save = CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_PlayerData.DAKCBBBMIMD_EventSP.FBCJICEPLED[ev.NGHKJOEDLIP_Settings.MOEKELIIDEO_SaveIdx];
			return save.MDADLCOCEBN_session_id;
		}
		return "";
	}

	// // RVA: 0x1128BF4 Offset: 0x1128BF4 VA: 0x1128BF4 Slot: 73
	public override List<string> IJCPBPFEGDM_GetResourcesFilePathList(long _JHNMKKNEENE_Time)
	{
		return null;
	}

	// // RVA: 0x1128BFC Offset: 0x1128BFC VA: 0x1128BFC Slot: 74
	public override int EDNMFMBLCGF_GetWavId()
	{
		return 0;
	}

	// // RVA: 0x1128C04 Offset: 0x1128C04 VA: 0x1128C04 Slot: 38
	public override void EMEPJNLHJHJ(int GJEADBKFAPA, int _AKNELONELJK_Difficulty, bool _GIKLNODJKFK_IsLine6, ref int APMGOLOPLFP, ref int FBBDNLAMPMH)
	{
		return;
	}

	// // RVA: 0x1128C08 Offset: 0x1128C08 VA: 0x1128C08 Slot: 79
	// public override bool GNGPNMHGDGE() { }

	// // RVA: 0x1128C10 Offset: 0x1128C10 VA: 0x1128C10
	// public OEIJEFBBJBD.AODDNOGBFLP ILJMDJCGMPA(int DFFPLNMAKKD) { }

	// // RVA: 0x1128DB4 Offset: 0x1128DB4 VA: 0x1128DB4
	public void CIHGOMNFPNJ_IncDivaTouchCount()
	{
		OEIJEFBBJBD_EventSp ev = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.LBDOLHGDIEB_GetDbSection(JOPOPMLFINI_QuestName) as OEIJEFBBJBD_EventSp;
		if(ev != null)
		{
            NILOACEHJKJ_EventSP.MDCMFPENCEK save = CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_PlayerData.DAKCBBBMIMD_EventSP.FBCJICEPLED[ev.NGHKJOEDLIP_Settings.MOEKELIIDEO_SaveIdx];
			if(save.KNOINFOHCAL_DivaTouchCount < 9999)
				save.KNOINFOHCAL_DivaTouchCount++;
		}
	}

	// // RVA: 0x1129064 Offset: 0x1129064 VA: 0x1129064
	public int CAHDMMAHEJC_GetDivaTouchCount()
	{
		OEIJEFBBJBD_EventSp ev = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.LBDOLHGDIEB_GetDbSection(JOPOPMLFINI_QuestName) as OEIJEFBBJBD_EventSp;
		if(ev != null)
		{
            NILOACEHJKJ_EventSP.MDCMFPENCEK save = CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_PlayerData.DAKCBBBMIMD_EventSP.FBCJICEPLED[ev.NGHKJOEDLIP_Settings.MOEKELIIDEO_SaveIdx];
			return save.KNOINFOHCAL_DivaTouchCount;
		}
		return 0;
	}

	// // RVA: 0x11292C0 Offset: 0x11292C0 VA: 0x11292C0
	public void POHBAGJLOLI_IncDivaCount(JJOELIOGMKK_DivaIntimacyInfo.OPOEENHEJOC _INDDJNMPONH_Type)
	{
		OEIJEFBBJBD_EventSp ev = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.LBDOLHGDIEB_GetDbSection(JOPOPMLFINI_QuestName) as OEIJEFBBJBD_EventSp;
		if(ev != null)
		{
            NILOACEHJKJ_EventSP.MDCMFPENCEK save = CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_PlayerData.DAKCBBBMIMD_EventSP.FBCJICEPLED[ev.NGHKJOEDLIP_Settings.MOEKELIIDEO_SaveIdx];
			if(_INDDJNMPONH_Type == JJOELIOGMKK_DivaIntimacyInfo.OPOEENHEJOC.EMIFDDHCOFB_1_DivaPresent)
			{
				if(save.ECABPJAIIOM_DivaPresentCount < 9999)
					save.ECABPJAIIOM_DivaPresentCount++;
			}
			else if(_INDDJNMPONH_Type == JJOELIOGMKK_DivaIntimacyInfo.OPOEENHEJOC.FNGFADPFKOD_0_DivaIntimacy)
			{
				if(save.CDAHMFBNOFA_DivaIntimacyCount < 9999)
					save.CDAHMFBNOFA_DivaIntimacyCount++;
			}
			else
				return;
			HEFIKPAHCIA_UpdateMission(GBNDFCEDNMG.CJDGJFINBFH.POHBAGJLOLI_26);
			HEFIKPAHCIA_UpdateMission(GBNDFCEDNMG.CJDGJFINBFH.DCFBLGLFJDO_20);
			HEFIKPAHCIA_UpdateMission(GBNDFCEDNMG.CJDGJFINBFH.ADCDEIPMKJI_19);
			QuestUtility.UpdateQuestData(LayoutQuestTab.eTabType.Event);
			QuestUtility.FooterMenuBadge();
		}
	}

	// // RVA: 0x1129684 Offset: 0x1129684 VA: 0x1129684
	public int ACEEBCPOEBF_GetDivaCount(JJOELIOGMKK_DivaIntimacyInfo.OPOEENHEJOC _INDDJNMPONH_Type)
	{
		OEIJEFBBJBD_EventSp ev = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.LBDOLHGDIEB_GetDbSection(JOPOPMLFINI_QuestName) as OEIJEFBBJBD_EventSp;
		if(ev != null)
		{
            NILOACEHJKJ_EventSP.MDCMFPENCEK save = CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_PlayerData.DAKCBBBMIMD_EventSP.FBCJICEPLED[ev.NGHKJOEDLIP_Settings.MOEKELIIDEO_SaveIdx];
			if(_INDDJNMPONH_Type == JJOELIOGMKK_DivaIntimacyInfo.OPOEENHEJOC.EMIFDDHCOFB_1_DivaPresent)
			{
				return save.ECABPJAIIOM_DivaPresentCount;
			}
			else if(_INDDJNMPONH_Type == JJOELIOGMKK_DivaIntimacyInfo.OPOEENHEJOC.FNGFADPFKOD_0_DivaIntimacy)
			{
				return save.CDAHMFBNOFA_DivaIntimacyCount;
			}
		}
		return 0;
	}

	// // RVA: 0x1127734 Offset: 0x1127734 VA: 0x1127734
	public void KCFEGCHMHMI_SetAdvShown(int _KDGJBBFKLGI_Chapter, bool _OAFPGJLCNFM_cond)
	{
		if(_KDGJBBFKLGI_Chapter > 0)
		{
			OEIJEFBBJBD_EventSp ev = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.LBDOLHGDIEB_GetDbSection(JOPOPMLFINI_QuestName) as OEIJEFBBJBD_EventSp;
			if(ev != null)
			{
            	NILOACEHJKJ_EventSP.MDCMFPENCEK save = CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_PlayerData.DAKCBBBMIMD_EventSP.FBCJICEPLED[ev.NGHKJOEDLIP_Settings.MOEKELIIDEO_SaveIdx];
				if(_OAFPGJLCNFM_cond)
					save.BLPJMHLJGKK_AdvIsShowBits |= 1 << (_KDGJBBFKLGI_Chapter - 1);
				else
					save.BLPJMHLJGKK_AdvIsShowBits &= ~(1 << (_KDGJBBFKLGI_Chapter - 1));
			}
		}
	}

	// // RVA: 0x11271D0 Offset: 0x11271D0 VA: 0x11271D0
	public bool EIACOAMGEPB_GetAdvShown(int _KDGJBBFKLGI_Chapter)
	{
		if(_KDGJBBFKLGI_Chapter > 0)
		{
			OEIJEFBBJBD_EventSp ev = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.LBDOLHGDIEB_GetDbSection(JOPOPMLFINI_QuestName) as OEIJEFBBJBD_EventSp;
			if(ev != null)
			{
            	NILOACEHJKJ_EventSP.MDCMFPENCEK save = CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_PlayerData.DAKCBBBMIMD_EventSP.FBCJICEPLED[ev.NGHKJOEDLIP_Settings.MOEKELIIDEO_SaveIdx];
				return (save.BLPJMHLJGKK_AdvIsShowBits & (1 << (_KDGJBBFKLGI_Chapter - 1))) != 0;
			}
		}
		return false;
	}

	// // RVA: 0x1129918 Offset: 0x1129918 VA: 0x1129918
	private OEIJEFBBJBD_EventSp.MFEJBIMLPGI EBDAPHFECDM(long _JHNMKKNEENE_Time)
	{
		OEIJEFBBJBD_EventSp ev = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.LBDOLHGDIEB_GetDbSection(JOPOPMLFINI_QuestName) as OEIJEFBBJBD_EventSp;
		if(ev != null)
		{
			for(int i = 0; i < ev.JIEIOFMJEBI.Count; i++)
			{
				if(ev.JIEIOFMJEBI[i].PLALNIIBLOF_en == 2 && ev.JIEIOFMJEBI[i].KDGJBBFKLGI_Chapter != 0 && 
					_JHNMKKNEENE_Time >= ev.JIEIOFMJEBI[i].PDBPFJJCADD_open_at && !EIACOAMGEPB_GetAdvShown(ev.JIEIOFMJEBI[i].KDGJBBFKLGI_Chapter))
				{
					return ev.JIEIOFMJEBI[i];
				}
			}
		}
		return null;
	}

	// // RVA: 0x11271AC Offset: 0x11271AC VA: 0x11271AC
	// private int ODEDADPJKBP(long _JHNMKKNEENE_Time) { }

	// // RVA: 0x1129C5C Offset: 0x1129C5C VA: 0x1129C5C
	public int HEDKLHFNLFF_GetAdvId(long _JHNMKKNEENE_Time)
	{
		OEIJEFBBJBD_EventSp.MFEJBIMLPGI d = EBDAPHFECDM(_JHNMKKNEENE_Time);
		if(d != null)
			return d.OIAAFFHGBBD_AdvId;
		return 0;
	}

	// // RVA: 0x1129C80 Offset: 0x1129C80 VA: 0x1129C80
	public bool GEFCIHNPKIG()
	{
		OEIJEFBBJBD_EventSp ev = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.LBDOLHGDIEB_GetDbSection(JOPOPMLFINI_QuestName) as OEIJEFBBJBD_EventSp;
		if(ev != null)
		{
			return ev.FDGNDLBDJFH.Count > 1;
		}
		return false;
	}

	// // RVA: 0x1129EA0 Offset: 0x1129EA0 VA: 0x1129EA0
	public int NJIKJJNLAPL(long _JHNMKKNEENE_Time, out long MGPEOHKLOEP, out long LFAFFICDFMJ_Done)
	{
		MGPEOHKLOEP = 0;
		LFAFFICDFMJ_Done = 0;
		OEIJEFBBJBD_EventSp ev = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.LBDOLHGDIEB_GetDbSection(JOPOPMLFINI_QuestName) as OEIJEFBBJBD_EventSp;
		if(ev != null)
		{
			OEIJEFBBJBD_EventSp.AOOLGJIFOEI d = ev.FDGNDLBDJFH.Find((OEIJEFBBJBD_EventSp.AOOLGJIFOEI JPAEDJJFFOI) =>
			{
				//0x112E9E0
				return _JHNMKKNEENE_Time >= JPAEDJJFFOI.PDBPFJJCADD_open_at && JPAEDJJFFOI.FDBNFFNFOND_CloseAt >= _JHNMKKNEENE_Time;
			});
			if(d != null)
			{
				MGPEOHKLOEP = d.PDBPFJJCADD_open_at;
				LFAFFICDFMJ_Done = d.FDBNFFNFOND_CloseAt;
				return d.PPFNGGCBJKC_id;
			}
		}
		return 1;
	}

	// // RVA: 0x112A18C Offset: 0x112A18C VA: 0x112A18C
	public int IIPGGJAKIEO(int MMAIKCLDLDI)
	{
		OEIJEFBBJBD_EventSp ev = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.LBDOLHGDIEB_GetDbSection(JOPOPMLFINI_QuestName) as OEIJEFBBJBD_EventSp;
		if(ev != null)
		{
			OEIJEFBBJBD_EventSp.NJJEAKMBGPN d = ev.EOKILLGMGDL.Find((OEIJEFBBJBD_EventSp.NJJEAKMBGPN JPAEDJJFFOI) =>
			{
				//0x112EA34
				return JPAEDJJFFOI.BDEOMEBFDFF_GachaId == MMAIKCLDLDI;
			});
			if(d != null)
			{
				OEIJEFBBJBD_EventSp.AOOLGJIFOEI d2 = ev.FDGNDLBDJFH.Find((OEIJEFBBJBD_EventSp.AOOLGJIFOEI JPAEDJJFFOI) =>
				{
					//0x112EA6C
					return d.PDBPFJJCADD_open_at >= JPAEDJJFFOI.PDBPFJJCADD_open_at && JPAEDJJFFOI.FDBNFFNFOND_CloseAt >= d.PDBPFJJCADD_open_at;
				});
				if(d2 != null)
					return d2.PPFNGGCBJKC_id;
			}
		}
		return 1;
	}

	// // RVA: 0x112A440 Offset: 0x112A440 VA: 0x112A440
	public bool BEDCLNJIEGF(long _JHNMKKNEENE_Time)
	{
		OEIJEFBBJBD_EventSp ev = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.LBDOLHGDIEB_GetDbSection(JOPOPMLFINI_QuestName) as OEIJEFBBJBD_EventSp;
		if(ev != null)
		{
			return ev.NGHKJOEDLIP_Settings.PHKLJGNMFBL_End >= _JHNMKKNEENE_Time && _JHNMKKNEENE_Time >= ev.NGHKJOEDLIP_Settings.OHGDNJLFDFF_Start;
		}
		return DPJCPDKALGI_RankingEnd >= _JHNMKKNEENE_Time && _JHNMKKNEENE_Time >= GLIMIGNNGGB_RankingStart;
	}

	// // RVA: 0x112A630 Offset: 0x112A630 VA: 0x112A630
	// public long ANFFEFDMOIL(long _JHNMKKNEENE_Time) { }

	// // RVA: 0x112A664 Offset: 0x112A664 VA: 0x112A664 Slot: 23
	public override void CFIINCJGBJB(bool _OAFPGJLCNFM_cond, int AHGHKCGLFBG)
	{
		OEIJEFBBJBD_EventSp ev = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.LBDOLHGDIEB_GetDbSection(JOPOPMLFINI_QuestName) as OEIJEFBBJBD_EventSp;
		if(ev != null)
		{
            NILOACEHJKJ_EventSP.MDCMFPENCEK save = CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_PlayerData.DAKCBBBMIMD_EventSP.FBCJICEPLED[ev.NGHKJOEDLIP_Settings.MOEKELIIDEO_SaveIdx];
			if(AHGHKCGLFBG < 0 || AHGHKCGLFBG >= IKMPCCPNGBP.Length)
			{
				AHGHKCGLFBG = 0;
			}
			if(_OAFPGJLCNFM_cond)
				save.JJMIEHHIKJE_RplQuest |= NHBMCIHGNIM[AHGHKCGLFBG];
			else
				save.JJMIEHHIKJE_RplQuest &= ~NHBMCIHGNIM[AHGHKCGLFBG];
			base.CFIINCJGBJB(_OAFPGJLCNFM_cond, AHGHKCGLFBG);
		}
	}

	// // RVA: 0x112AA38 Offset: 0x112AA38 VA: 0x112AA38 Slot: 24
	public override bool NCGDLDGCIFM(int AHGHKCGLFBG)
	{
		OEIJEFBBJBD_EventSp ev = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.LBDOLHGDIEB_GetDbSection(JOPOPMLFINI_QuestName) as OEIJEFBBJBD_EventSp;
		if(ev != null)
		{
            NILOACEHJKJ_EventSP.MDCMFPENCEK save = CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_PlayerData.DAKCBBBMIMD_EventSP.FBCJICEPLED[ev.NGHKJOEDLIP_Settings.MOEKELIIDEO_SaveIdx];
			if(AHGHKCGLFBG < 0 || AHGHKCGLFBG >= IKMPCCPNGBP.Length)
			{
				AHGHKCGLFBG = 0;
			}
			return (save.JJMIEHHIKJE_RplQuest & NHBMCIHGNIM[AHGHKCGLFBG]) != 0;
		}
		return false;
	}

	// // RVA: 0x1124C90 Offset: 0x1124C90 VA: 0x1124C90
	public void ALIBGNACAEA(bool _OAFPGJLCNFM_cond, int AHGHKCGLFBG)
	{
		OEIJEFBBJBD_EventSp ev = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.LBDOLHGDIEB_GetDbSection(JOPOPMLFINI_QuestName) as OEIJEFBBJBD_EventSp;
		if(ev != null)
		{
            NILOACEHJKJ_EventSP.MDCMFPENCEK save = CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_PlayerData.DAKCBBBMIMD_EventSP.FBCJICEPLED[ev.NGHKJOEDLIP_Settings.MOEKELIIDEO_SaveIdx];
			if(AHGHKCGLFBG < 0 || AHGHKCGLFBG >= IKMPCCPNGBP.Length)
			{
				AHGHKCGLFBG = 0;
			}
			if(_OAFPGJLCNFM_cond)
				save.JJMIEHHIKJE_RplQuest |= IKMPCCPNGBP[AHGHKCGLFBG];
			else
				save.JJMIEHHIKJE_RplQuest &= ~IKMPCCPNGBP[AHGHKCGLFBG];
		}
	}

	// // RVA: 0x112ADCC Offset: 0x112ADCC VA: 0x112ADCC
	public bool PNKBHEGAAKJ(int AHGHKCGLFBG)
	{
		OEIJEFBBJBD_EventSp ev = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.LBDOLHGDIEB_GetDbSection(JOPOPMLFINI_QuestName) as OEIJEFBBJBD_EventSp;
		if(ev != null)
		{
            NILOACEHJKJ_EventSP.MDCMFPENCEK save = CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_PlayerData.DAKCBBBMIMD_EventSP.FBCJICEPLED[ev.NGHKJOEDLIP_Settings.MOEKELIIDEO_SaveIdx];
			if(AHGHKCGLFBG < 0 || AHGHKCGLFBG >= IKMPCCPNGBP.Length)
			{
				AHGHKCGLFBG = 0;
			}
			return (save.JJMIEHHIKJE_RplQuest & IKMPCCPNGBP[AHGHKCGLFBG]) != 0;
		}
		return false;
	}

	// // RVA: 0x112B160 Offset: 0x112B160 VA: 0x112B160
	public bool GEPPAGIEMOK_CanShowHelp(int AHGHKCGLFBG)
	{
		if(!NCGDLDGCIFM(AHGHKCGLFBG))
			return false;
		return !PNKBHEGAAKJ(AHGHKCGLFBG);
	}

	// // RVA: 0x112B1A8 Offset: 0x112B1A8 VA: 0x112B1A8
	public int EDHFKGEIAHB_GetHelpId(int AHGHKCGLFBG)
	{
		OEIJEFBBJBD_EventSp ev = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.LBDOLHGDIEB_GetDbSection(JOPOPMLFINI_QuestName) as OEIJEFBBJBD_EventSp;
		if(ev != null)
		{
			int replace_quest_help_id = ev.LPJLEHAJADA("replace_quest_help_id", 0);
			if(AHGHKCGLFBG > 0)
			{
				KHDPDECJHLD.Clear();
				KHDPDECJHLD.AppendFormat("replace_quest_help_id_{0}", AHGHKCGLFBG);
				int v = ev.LPJLEHAJADA(KHDPDECJHLD.ToString(), 0);
				if(v > 0)
					return v;
			}
			return replace_quest_help_id;
		}
		return 0;
	}

	// // RVA: 0x112B404 Offset: 0x112B404 VA: 0x112B404
	public void FJHIHFCAHMH(long _JHNMKKNEENE_Time)
	{
		OEIJEFBBJBD_EventSp ev = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.LBDOLHGDIEB_GetDbSection(JOPOPMLFINI_QuestName) as OEIJEFBBJBD_EventSp;
		if(ev != null)
		{
            NILOACEHJKJ_EventSP.MDCMFPENCEK save = CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_PlayerData.DAKCBBBMIMD_EventSP.FBCJICEPLED[ev.NGHKJOEDLIP_Settings.MOEKELIIDEO_SaveIdx];
			save.OOBBAGJNDIH_LstHpTime = _JHNMKKNEENE_Time;
        }
	}

	// // RVA: 0x112B658 Offset: 0x112B658 VA: 0x112B658
	private NILOACEHJKJ_EventSP.MDCMFPENCEK DHKFENOKOAN()
	{
		OEIJEFBBJBD_EventSp ev = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.LBDOLHGDIEB_GetDbSection(JOPOPMLFINI_QuestName) as OEIJEFBBJBD_EventSp;
		if(ev != null)
		{
            return CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_PlayerData.DAKCBBBMIMD_EventSP.FBCJICEPLED[ev.NGHKJOEDLIP_Settings.MOEKELIIDEO_SaveIdx];
        }
		return null;
	}

	// // RVA: 0x112B89C Offset: 0x112B89C VA: 0x112B89C

	public void DHHNKEIBCOK(int _PPFNGGCBJKC_id, bool _JKDJCFEBDHC_Enabled)
	{
		NILOACEHJKJ_EventSP.MDCMFPENCEK d = DHKFENOKOAN();
		if(d != null)
			d.DHHNKEIBCOK(_PPFNGGCBJKC_id, _JKDJCFEBDHC_Enabled);
	}

	// // RVA: 0x112B8CC Offset: 0x112B8CC VA: 0x112B8CC
	public bool IHPAMMBNOPC(int _PPFNGGCBJKC_id)
	{
		NILOACEHJKJ_EventSP.MDCMFPENCEK d = DHKFENOKOAN();
		if(d != null)
			return d.IHPAMMBNOPC(_PPFNGGCBJKC_id);
		return false;
	}

	// // RVA: 0x112B8FC Offset: 0x112B8FC VA: 0x112B8FC
	public int MEDEJHKNAFG_GetCurrentMissionGroup(long LPEKHFOMCAH)
	{
		OEIJEFBBJBD_EventSp ev = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.LBDOLHGDIEB_GetDbSection(JOPOPMLFINI_QuestName) as OEIJEFBBJBD_EventSp;
		if(ev != null)
		{
			OEIJEFBBJBD_EventSp.AOOLGJIFOEI d = ev.FDGNDLBDJFH.Find((OEIJEFBBJBD_EventSp.AOOLGJIFOEI JPAEDJJFFOI) =>
			{
				//0x112EAE8
				return LPEKHFOMCAH >= JPAEDJJFFOI.PDBPFJJCADD_open_at && JPAEDJJFFOI.FDBNFFNFOND_CloseAt >= LPEKHFOMCAH && JPAEDJJFFOI.PLALNIIBLOF_en == 2;
			});
			if(d != null)
			{
				return System.Math.Max(0, d.KGICDMIJGDF_Group);
			}
		}
		return 0;
	}

	// // RVA: 0x112BB68 Offset: 0x112BB68 VA: 0x112BB68
	public int MEDEJHKNAFG_GetCurrentMissionGroup()
	{
		return MEDEJHKNAFG_GetCurrentMissionGroup(NKGJPJPHLIF.HHCJCDFCLOB.IBLPICFDGOF_ServerRequester.FJDBNGEPKHL_Time.KMEFBNBFJHI_GetServerTime());
	}

	// // RVA: 0x112BC60 Offset: 0x112BC60 VA: 0x112BC60
	public int MEDEJHKNAFG_GetCurrentMissionGroup(out long OHIELMKHFFI, out long PCAJINOKGKA, out long HIBAPCCPIFD, out long PCEIHGCEAID, out bool NKEFOIGFNDP)
	{
		NKEFOIGFNDP = false;
		int v = MEDEJHKNAFG_GetCurrentMissionGroup();
		long t = NKGJPJPHLIF.HHCJCDFCLOB.IBLPICFDGOF_ServerRequester.FJDBNGEPKHL_Time.KMEFBNBFJHI_GetServerTime();
		NEMGJHBEJCP(v, t, out OHIELMKHFFI, out PCAJINOKGKA, out HIBAPCCPIFD, out PCEIHGCEAID);
		if(t >= HIBAPCCPIFD && PCEIHGCEAID >= t)
		{
			NKEFOIGFNDP = true;
		}
		return v;
	}

	// // RVA: 0x112BDC8 Offset: 0x112BDC8 VA: 0x112BDC8
	public bool NEMGJHBEJCP(int _BCOKKAALGHC_Group, long _JHNMKKNEENE_Time, out long BFBBPOPIEEJ, out long IKBGGDNIJJH, out long HIBAPCCPIFD, out long PCEIHGCEAID)
	{
		BFBBPOPIEEJ = GLIMIGNNGGB_RankingStart;
		IKBGGDNIJJH = DPJCPDKALGI_RankingEnd;
		HIBAPCCPIFD = DPJCPDKALGI_RankingEnd + 1;
		PCEIHGCEAID = LJOHLEGGGMC_RewardEnd;
		OEIJEFBBJBD_EventSp ev = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.LBDOLHGDIEB_GetDbSection(JOPOPMLFINI_QuestName) as OEIJEFBBJBD_EventSp;
		if(ev != null)
		{
			int cnt = 0;
			foreach(var d in ev.FDGNDLBDJFH)
			{
				if(d.PLALNIIBLOF_en == 2)
					cnt++;
			}
			if(cnt < 2)
				return false;
			List<OEIJEFBBJBD_EventSp.AOOLGJIFOEI> l = ev.FDGNDLBDJFH.FindAll((OEIJEFBBJBD_EventSp.AOOLGJIFOEI JPAEDJJFFOI) =>
			{
				//0x112EB48
				return JPAEDJJFFOI.KGICDMIJGDF_Group == _BCOKKAALGHC_Group;
			});
			int v = 0;
			for(int i = 0; i < l.Count; i++)
			{
				if(_JHNMKKNEENE_Time >= l[i].PDBPFJJCADD_open_at && l[i].FDBNFFNFOND_CloseAt >= _JHNMKKNEENE_Time)
					v = i;
			}
			if(l.Count > 0)
			{
				BFBBPOPIEEJ = l[v].PDBPFJJCADD_open_at;
				PCEIHGCEAID = l[v].FDBNFFNFOND_CloseAt;
				KHDPDECJHLD.Clear();
				KHDPDECJHLD.AppendFormat("quest_challenge_end_{0}", v + 1);
				string s = MAICAKMIBEM(KHDPDECJHLD.ToString(), "");
				if(s.Length > 0)
				{
					DateTime dt = DateTime.Parse(s);
					long t = Utility.GetTargetUnixTime(dt.Year, dt.Month, dt.Day, dt.Hour, dt.Minute, dt.Second);
					IKBGGDNIJJH = t;
					HIBAPCCPIFD = t + 1;
					return true;
				}
			}
		}
		return false;
	}

	// // RVA: 0x112C504 Offset: 0x112C504 VA: 0x112C504
	public int JLLGJIIHFJO_GetTitleTextureId(int AHGHKCGLFBG)
	{
		OEIJEFBBJBD_EventSp ev = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.LBDOLHGDIEB_GetDbSection(JOPOPMLFINI_QuestName) as OEIJEFBBJBD_EventSp;
		if(ev != null)
		{
			KHDPDECJHLD.Clear();
			KHDPDECJHLD.AppendFormat("quest_title_texture_id_{0}", AHGHKCGLFBG);
			int v = ev.LPJLEHAJADA(KHDPDECJHLD.ToString(), 0);
			if(v < 1)
			{
				v = ev.LPJLEHAJADA("quest_title_texture_id_0", 0);
				if(v < 1)
					v = PGIIDPEGGPI_EventId;
			}
			return v;
		}
		return 0;
	}

	// // RVA: 0x112C7D4 Offset: 0x112C7D4 VA: 0x112C7D4
	public int CBEACDJOIBO_GetIconTextureId(int AHGHKCGLFBG)
	{
		OEIJEFBBJBD_EventSp ev = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.LBDOLHGDIEB_GetDbSection(JOPOPMLFINI_QuestName) as OEIJEFBBJBD_EventSp;
		if(ev != null)
		{
			KHDPDECJHLD.Clear();
			KHDPDECJHLD.AppendFormat("quest_icon_texture_id_{0}", AHGHKCGLFBG);
			int v = ev.LPJLEHAJADA(KHDPDECJHLD.ToString(), 0);
			if(v < 1)
			{
				v = ev.LPJLEHAJADA("quest_icon_texture_id_0", 0);
				if(v < 1)
					v = PGIIDPEGGPI_EventId;
			}
			return v;
		}
		return 0;
	}
}
