
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
		public int FPEOGFMKMKJ; // 0x10
		public int ANOCILKJGOJ; // 0x14
		public int ODCLHPGHDHA; // 0x18
		public int PIIEGNPOPJI_GetPoint; // 0x1C
		public int FCLGIPFPIPH; // 0x20
		public int OENBOLPDBAB; // 0x24
		public int GCAPLLEIAAI_NewScore; // 0x28
		public int IDCFOMMKGIK; // 0x2C
		public int LPGNCOFHOPK_SaveScore; // 0x30
		public bool GIIKOMPJOHA; // 0x34
	}

	private const int GHJHJDIDCFA = 3;
	private List<PHBACNMCMHG_EventCollection.LLFNMNJGLNL> NFMDLCBJOIB = new List<PHBACNMCMHG_EventCollection.LLFNMNJGLNL>(); // 0xE8
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
	public HJNNLPIGHLM_EventCollection(string OPFGFINHFCE) : base(OPFGFINHFCE)
    {
        return;
    }

	// // RVA: 0x183A7EC Offset: 0x183A7EC VA: 0x183A7EC Slot: 5
	public override string IFKKBHPMALH()
	{
		PHBACNMCMHG_EventCollection ev = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.LBDOLHGDIEB_GetDbSection(JOPOPMLFINI_QuestId) as PHBACNMCMHG_EventCollection;
		if(ev != null)
		{
			return ev.NGHKJOEDLIP.OCDMGOGMHGE_RewardPrefix;
		}
		return null;
	}

	// // RVA: 0x183A974 Offset: 0x183A974 VA: 0x183A974
	private List<PHBACNMCMHG_EventCollection.LLFNMNJGLNL> LEAGIGKFMPE()
	{
		PHBACNMCMHG_EventCollection ev = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.LBDOLHGDIEB_GetDbSection(JOPOPMLFINI_QuestId) as PHBACNMCMHG_EventCollection;
		if(ev != null)
		{
			long t = NKGJPJPHLIF.HHCJCDFCLOB.IBLPICFDGOF_ServerRequester.FJDBNGEPKHL.KMEFBNBFJHI_GetServerTime();
			NFMDLCBJOIB.Clear();
			for(int i = 0; i < ev.IJJHFGOIDOK_Songs.Count; i++)
			{
				if(ev.IJJHFGOIDOK_Songs[i].PLALNIIBLOF_Enabled == 2)
				{
					if((ev.IJJHFGOIDOK_Songs[i].PDBPFJJCADD_OpenAt == 0 && ev.IJJHFGOIDOK_Songs[i].FDBNFFNFOND_CloseAt == 0) || 
					(t >= ev.IJJHFGOIDOK_Songs[i].PDBPFJJCADD_OpenAt && ev.IJJHFGOIDOK_Songs[i].FDBNFFNFOND_CloseAt >= t))
					{
						NFMDLCBJOIB.Add(ev.IJJHFGOIDOK_Songs[i]);
					}
				}
			}
			return NFMDLCBJOIB;
		}
		return null;
	}

	// // RVA: 0x183ACB8 Offset: 0x183ACB8 VA: 0x183ACB8
	public List<PHBACNMCMHG_EventCollection.LLFNMNJGLNL> KOBMFPACBMB()
	{
		if(NFMDLCBJOIB.Count < 1)
		{
			return LEAGIGKFMPE();
		}
		return NFMDLCBJOIB;
	}

	// // RVA: 0x183AD44 Offset: 0x183AD44 VA: 0x183AD44
	public void BEFJOAGGAJD()
	{
		NFMDLCBJOIB.Clear();
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
				res.Add(l[i].MPLGPBNJDJB_FMusicId);
			}
		}
		return res;
	}

	// // RVA: 0x183AF30 Offset: 0x183AF30 VA: 0x183AF30 Slot: 9
	public override long HOOBCIIOCJD_GetSongEndTime(int GHBPLHBNMBK)
	{
		List<PHBACNMCMHG_EventCollection.LLFNMNJGLNL> l = KOBMFPACBMB();
		if(l != null)
		{
			long t = NKGJPJPHLIF.HHCJCDFCLOB.IBLPICFDGOF_ServerRequester.FJDBNGEPKHL.KMEFBNBFJHI_GetServerTime();
			if(l.Count > 0)
			{
				for(int i = 0; i < l.Count; i++)
				{
					if(l[i].PDBPFJJCADD_OpenAt != 0 && 
						l[i].FDBNFFNFOND_CloseAt != 0 && 
						t >= l[i].PDBPFJJCADD_OpenAt && 
						l[i].FDBNFFNFOND_CloseAt >= t && 
						l[i].MPLGPBNJDJB_FMusicId == GHBPLHBNMBK)
							return l[i].FDBNFFNFOND_CloseAt;
				}
			}
		}
		return base.HOOBCIIOCJD_GetSongEndTime(GHBPLHBNMBK);
	}

	// // RVA: 0x183B230 Offset: 0x183B230 VA: 0x183B230 Slot: 10
	public override bool GIDDKGMPIOK_IsLimited(int GHBPLHBNMBK)
	{
		List<PHBACNMCMHG_EventCollection.LLFNMNJGLNL> l = KOBMFPACBMB();
		if(l != null)
		{
			long t = NKGJPJPHLIF.HHCJCDFCLOB.IBLPICFDGOF_ServerRequester.FJDBNGEPKHL.KMEFBNBFJHI_GetServerTime();
			if(l.Count > 0)
			{
				for(int i = 0; i < l.Count; i++)
				{
					if(l[i].PDBPFJJCADD_OpenAt != 0 && 
						l[i].FDBNFFNFOND_CloseAt != 0 && 
						l[i].FDBNFFNFOND_CloseAt < DPJCPDKALGI_End1 && 
						t >= l[i].PDBPFJJCADD_OpenAt && 
						l[i].FDBNFFNFOND_CloseAt >= t && 
						l[i].MPLGPBNJDJB_FMusicId == GHBPLHBNMBK)
							return true;
				}
			}
		}
		return false;
	}

	// // RVA: 0x183B550 Offset: 0x183B550 VA: 0x183B550
	public int OMJHBJPCFFC_GetEventBonusPercent(int EHDDADDKMFI)
	{
		// Not used since it doesn't override. But db block don't match so it's normal I guess.
		ACBAHDMEFFL_EventMission ev = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.LBDOLHGDIEB_GetDbSection(JOPOPMLFINI_QuestId) as ACBAHDMEFFL_EventMission;
		if(ev != null)
		{
			long t = NKGJPJPHLIF.HHCJCDFCLOB.IBLPICFDGOF_ServerRequester.FJDBNGEPKHL.KMEFBNBFJHI_GetServerTime();
			List<int> l = new List<int>();
			for(int i = 0; i < ev.IJJHFGOIDOK.Count; i++)
			{
				if(ev.IJJHFGOIDOK[i].PLALNIIBLOF == 2 && 
					((ev.IJJHFGOIDOK[i].PDBPFJJCADD == 0 && ev.IJJHFGOIDOK[i].FDBNFFNFOND == 0) || 
					(ev.IJJHFGOIDOK[i].PDBPFJJCADD < t && ev.IJJHFGOIDOK[i].FDBNFFNFOND >= t))
					&& ev.IJJHFGOIDOK[i].MPLGPBNJDJB == EHDDADDKMFI)
				{
					return ev.IJJHFGOIDOK[i].DKHIHHMOIKM;
				}
			}
		}
		return 0;
	}

	// // RVA: 0x183B864 Offset: 0x183B864 VA: 0x183B864 Slot: 27
	public override int HLOGNJNGDJO_GetHelpId(int OIPCCBHIKIA = 0)
	{
		PHBACNMCMHG_EventCollection ev = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.LBDOLHGDIEB_GetDbSection(JOPOPMLFINI_QuestId) as PHBACNMCMHG_EventCollection;
		if(ev != null)
		{
			return ev.NGHKJOEDLIP.EJBGHLOOLBC_HelpIds[OIPCCBHIKIA];
		}
		return 0;
	}

	// // RVA: 0x183BA20 Offset: 0x183BA20 VA: 0x183BA20 Slot: 67
	// public override int LBNKDKDMMOK() { }

	// // RVA: 0x183BBA4 Offset: 0x183BBA4 VA: 0x183BBA4 Slot: 28
	public override long FBGDBGKNKOD_GetCurrentPoint()
	{
		PHBACNMCMHG_EventCollection ev = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.LBDOLHGDIEB_GetDbSection(JOPOPMLFINI_QuestId) as PHBACNMCMHG_EventCollection;
		if(ev != null)
		{
			FJGNPNFLHPH_EventCollection.JIALCLGJPKL save = CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave.MBAHCFLBDHN_EventCollection.FBCJICEPLED[ev.NGHKJOEDLIP.MOEKELIIDEO_SaveIdx];
			return save.DNBFMLBNAEE_Point;
		}
		return 0;
	}

	// // RVA: 0x183BE04 Offset: 0x183BE04 VA: 0x183BE04
	public long AFCIIKDOMHN_GetScore()
	{
		PHBACNMCMHG_EventCollection ev = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.LBDOLHGDIEB_GetDbSection(JOPOPMLFINI_QuestId) as PHBACNMCMHG_EventCollection;
		if(ev != null)
		{
			FJGNPNFLHPH_EventCollection.JIALCLGJPKL save = CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave.MBAHCFLBDHN_EventCollection.FBCJICEPLED[ev.NGHKJOEDLIP.MOEKELIIDEO_SaveIdx];
			return save.KNIFCANOHOC_Score;
		}
		return 0;
	}

	// // RVA: 0x183C064 Offset: 0x183C064 VA: 0x183C064 Slot: 29
	public override void MJFKJHJJLMN_GetRanks(int LHJCOPMMIGO = 0, bool FBBNPFFEJBN = false)
	{
		PLOOEECNHFB = false;
		NPNNPNAIONN = false;
		EECOJKDJIFG e = DAKMIKNKHMF_GetRankingInfoForIndex(LHJCOPMMIGO);
		if(e != null)
		{
			PHBACNMCMHG_EventCollection ev = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.LBDOLHGDIEB_GetDbSection(JOPOPMLFINI_QuestId) as PHBACNMCMHG_EventCollection;
			if(ev != null)
			{
				if(GPHEKCNDDIK)
				{
					long t = NKGJPJPHLIF.HHCJCDFCLOB.IBLPICFDGOF_ServerRequester.FJDBNGEPKHL.KMEFBNBFJHI_GetServerTime();
					int get_rank_cooling_time = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.GDEKCOOBLMA_System.LPJLEHAJADA("get_rank_cooling_time", 60);
					if(FBBNPFFEJBN || CDINKAANIAA_Rank[LHJCOPMMIGO] <= 0 || (t - KPOMHFLKMKI_LastRankUpdateTime[LHJCOPMMIGO] >= get_rank_cooling_time))
					{
						//LAB_0183c464
						KKLGENJKEBN.HHCJCDFCLOB.HEOKADCEAGL_GetRanks(ev.NGHKJOEDLIP.OCGFKMHNEOF, () =>
						{
							//0x1846F78
							CDINKAANIAA_Rank[LHJCOPMMIGO] = (int)KKLGENJKEBN.HHCJCDFCLOB.LPPCNCMEDFA_Rank;
							KPOMHFLKMKI_LastRankUpdateTime[LHJCOPMMIGO] = NKGJPJPHLIF.HHCJCDFCLOB.IBLPICFDGOF_ServerRequester.FJDBNGEPKHL.KMEFBNBFJHI_GetServerTime();
							PLOOEECNHFB = true;
						}, () =>
						{
							//0x184713C
							KPOMHFLKMKI_LastRankUpdateTime[LHJCOPMMIGO] = NKGJPJPHLIF.HHCJCDFCLOB.IBLPICFDGOF_ServerRequester.FJDBNGEPKHL.KMEFBNBFJHI_GetServerTime();
							CDINKAANIAA_Rank[LHJCOPMMIGO] = 0;
							PLOOEECNHFB = true;
						}, () =>
						{
							//0x18472E4
							CDINKAANIAA_Rank[LHJCOPMMIGO] = 0;
							PLOOEECNHFB = true;
							NPNNPNAIONN = true;
						}, () =>
						{
							//0x184737C
							CDINKAANIAA_Rank[LHJCOPMMIGO] = 0;
							PLOOEECNHFB = true;
							FKKDIDMGLMI = true;
						});
						return;
					}
				}
			}
		}
		CDINKAANIAA_Rank[LHJCOPMMIGO] = 0;
		PLOOEECNHFB = true;
	}

	// // RVA: 0x183C5C0 Offset: 0x183C5C0 VA: 0x183C5C0 Slot: 30
	protected override bool JIHMLILFOPG_IsEventActive(long JHNMKKNEENE)
	{
		PHBACNMCMHG_EventCollection ev = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.LBDOLHGDIEB_GetDbSection(JOPOPMLFINI_QuestId) as PHBACNMCMHG_EventCollection;
		if(ev != null)
		{
			GDIPLANPCEI g = IMMAOANGPNK.HHCJCDFCLOB.ACEFBFLFKFD_GetScheduleEventData(ev.JIKKNHIAEKG_BlockName, JHNMKKNEENE);
			if(g != null)
			{
				if(JHNMKKNEENE >= ev.NGHKJOEDLIP.BONDDBOFBND_Start && ev.NGHKJOEDLIP.KNLGKBBIBOH_End >= JHNMKKNEENE)
				{
					if(ev.NGHKJOEDLIP.HKKNEAGCIEB != 0)
					{
						List<string> PDDFOEDNFBN = new List<string>();
						PDDFOEDNFBN.Clear();
						if(ev.NGHKJOEDLIP.OCGFKMHNEOF != "")
						{
							PDDFOEDNFBN.Add(ev.NGHKJOEDLIP.OCGFKMHNEOF);
						}
						if(ev.NGHKJOEDLIP.OGMGLOFKKPA != "")
						{
							PDDFOEDNFBN.Add(ev.NGHKJOEDLIP.OGMGLOFKKPA);
						}
						for(int i = 0; i < PDDFOEDNFBN.Count; i++)
						{
							int BMBBDIAEOMP = i;
                            EECOJKDJIFG e = KKLGENJKEBN.HHCJCDFCLOB.JPDPFGFMKHK.Find((EECOJKDJIFG PKLPKMLGFGK) =>
							{
								//0x1847414
								return PKLPKMLGFGK.OCGFKMHNEOF_NameForApi == PDDFOEDNFBN[BMBBDIAEOMP];
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
	protected override bool IMCMNOPNGHO(long JHNMKKNEENE)
	{
		PHBACNMCMHG_EventCollection ev = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.LBDOLHGDIEB_GetDbSection(JOPOPMLFINI_QuestId) as PHBACNMCMHG_EventCollection;
		if(ev != null)
		{
			FJGNPNFLHPH_EventCollection.JIALCLGJPKL save = CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave.MBAHCFLBDHN_EventCollection.FBCJICEPLED[ev.NGHKJOEDLIP.MOEKELIIDEO_SaveIdx];
			string s = ev.NGHKJOEDLIP.OCGFKMHNEOF;
			if(s == "")
				s = ev.NGHKJOEDLIP.OGMGLOFKKPA;
			AGLILDLEFDK_Missions = ev.NNMPGOAGEOL_Missions;
			OLDFFDMPEBM_Quests = save.NNMPGOAGEOL_Quests;
			if(save.MPCAGEPEJJJ_Key != s || (!RuntimeSettings.CurrentSettings.UnlimitedEvent && save.EGBOHDFBAPB_End < ev.NGHKJOEDLIP.BONDDBOFBND_Start))
			{
				save.LHPDDGIJKNB();
				save.MPCAGEPEJJJ_Key = s;
				save.EGBOHDFBAPB_End = ev.NGHKJOEDLIP.IDDBFFBPNGI;
				KOMAHOAEMEK(true);
			}
			KOMAHOAEMEK(false);
			return true;
		}
		return false;
	}

	// // RVA: 0x183CE74 Offset: 0x183CE74 VA: 0x183CE74 Slot: 40
	protected override void KKFLDCBHFJA(long JHNMKKNEENE)
	{
		PHBACNMCMHG_EventCollection INJCPCDPGHH = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.LBDOLHGDIEB_GetDbSection(JOPOPMLFINI_QuestId) as PHBACNMCMHG_EventCollection;
		if(INJCPCDPGHH != null)
		{
			IBNKPMPFLGI_IsRankReward = INJCPCDPGHH.NGHKJOEDLIP.HKKNEAGCIEB != 0;
			if(IBNKPMPFLGI_IsRankReward)
			{
				EECOJKDJIFG e = KKLGENJKEBN.HHCJCDFCLOB.JPDPFGFMKHK.Find((EECOJKDJIFG PKLPKMLGFGK) =>
				{
					//0x18474D0
					return INJCPCDPGHH.NGHKJOEDLIP.OCGFKMHNEOF == PKLPKMLGFGK.OCGFKMHNEOF_NameForApi;
				});
				KBACNOCOANM_Ranking.Add(e);
				e = KKLGENJKEBN.HHCJCDFCLOB.JPDPFGFMKHK.Find((EECOJKDJIFG PKLPKMLGFGK) =>
				{
					//0x1847530
					return INJCPCDPGHH.NGHKJOEDLIP.OGMGLOFKKPA == PKLPKMLGFGK.OCGFKMHNEOF_NameForApi;
				});
				KBACNOCOANM_Ranking.Add(e);
				GPHEKCNDDIK = true;
			}
			DGCOMDILAKM_EventName = INJCPCDPGHH.NGHKJOEDLIP.OPFGFINHFCE_Name;
			DOLJEDAAKNN = INJCPCDPGHH.NGHKJOEDLIP.HEDAGCNPHGD;
			GLIMIGNNGGB_Start = INJCPCDPGHH.NGHKJOEDLIP.BONDDBOFBND_Start;
			DPJCPDKALGI_End1 = INJCPCDPGHH.NGHKJOEDLIP.HPNOGLIFJOP_End1;
			LOLAANGCGDO = INJCPCDPGHH.NGHKJOEDLIP.LNFKGHNHJKE;
			JDDFILGNGFH = INJCPCDPGHH.NGHKJOEDLIP.JGMDAOACOJF;
			LJOHLEGGGMC = INJCPCDPGHH.NGHKJOEDLIP.IDDBFFBPNGI;
			EMEKFFHCHMH_End = INJCPCDPGHH.NGHKJOEDLIP.KNLGKBBIBOH_End;
			PGIIDPEGGPI_EventId = INJCPCDPGHH.NGHKJOEDLIP.OBGBAOLONDD_EventId;
			NHGPCLGPEHH_TicketType = INJCPCDPGHH.NGHKJOEDLIP.MJBKGOJBPAD_TicketType;
			FBHONHONKGD_MusicSelectDesc = INJCPCDPGHH.NGHKJOEDLIP.FEMMDNIELFC_MusicSelectDesc;
			HGLAFGHHFKP = INJCPCDPGHH.NGHKJOEDLIP.JHPCPNJJHLI;
			GFIBLLLHMPD_StartAdventureId = INJCPCDPGHH.NGHKJOEDLIP.HIOOGLEJBKM_StartAdventureId;
			CAKEOPLJDAF_EndAdventureId = INJCPCDPGHH.NGHKJOEDLIP.FJCADCDNPMP_EndAdventureId;
			LHAKGDAGEMM_EpBonusInfos.Clear();
			for(int i = 0; i < INJCPCDPGHH.LHAKGDAGEMM_EpBonus.Count; i++)
			{
				CEGDBNNIDIG d = new CEGDBNNIDIG();
				d.KELFCMEOPPM_EpId = INJCPCDPGHH.LHAKGDAGEMM_EpBonus[i].KHPHAAMGMJP_Id;
				d.MIHNKIHNBBL_BaseBonus = INJCPCDPGHH.LHAKGDAGEMM_EpBonus[i].OFIAENKCJME_BaseBonus / 100.0f;
				d.MLLPMJFOKEC_GachaIds.AddRange(INJCPCDPGHH.LHAKGDAGEMM_EpBonus[i].KDNMBOBEGJM);
				LHAKGDAGEMM_EpBonusInfos.Add(d);
			}
			PGDAMNENGDA_EpBonusBySceneRarity.Clear();
			for(int i = 0; i < INJCPCDPGHH.OGMHMAGDNAM_EpBonusBySceneRarity.Count; i++)
			{
				NJJDBBCHBNP d = new NJJDBBCHBNP();
				d.GJEADBKFAPA = INJCPCDPGHH.OGMHMAGDNAM_EpBonusBySceneRarity[i].PPFNGGCBJKC;
				d.IJKFFIKGLJM_BonusBefore = INJCPCDPGHH.OGMHMAGDNAM_EpBonusBySceneRarity[i].GNFBMCGMCFO_BonusBefore;
				d.DCBMFNOIENM_BonusAfter = INJCPCDPGHH.OGMHMAGDNAM_EpBonusBySceneRarity[i].BFFGFAMJAIG_BonusAfter;
				PGDAMNENGDA_EpBonusBySceneRarity.Add(d);
			}
			DHOMAEOEFMJ_EpBonuByScene.Clear();
			for(int i = 0; i < INJCPCDPGHH.GEGAEDDGNMA_EpBonusByScene.Count; i++)
			{
				MEBJJBHPMEO d = new MEBJJBHPMEO();
				d.PPFNGGCBJKC = INJCPCDPGHH.GEGAEDDGNMA_EpBonusByScene[i].PPFNGGCBJKC;
				d.GNFBMCGMCFO_BonusBefore = INJCPCDPGHH.GEGAEDDGNMA_EpBonusByScene[i].GNFBMCGMCFO_BonusBefore;
				d.BFFGFAMJAIG_BonusAfter = INJCPCDPGHH.GEGAEDDGNMA_EpBonusByScene[i].BFFGFAMJAIG_BonusAfter;
				d.CNKFPJCGNFE_SceneId = INJCPCDPGHH.GEGAEDDGNMA_EpBonusByScene[i].CNKFPJCGNFE_SceneId;
				DHOMAEOEFMJ_EpBonuByScene.Add(d);
			}
			MBHDIJJEOFL = INJCPCDPGHH.MBHDIJJEOFL;
			for(int i = 0; i < KPOMHFLKMKI_LastRankUpdateTime.Length; i++)
			{
				KPOMHFLKMKI_LastRankUpdateTime[i] = 0;
			}
			if(!string.IsNullOrEmpty(INJCPCDPGHH.NGHKJOEDLIP.OMCAOJJGOGG))
			{
				string[] strs = INJCPCDPGHH.NGHKJOEDLIP.OMCAOJJGOGG.Split((new char[] {','}));
				MFDJIFIIPJD d = new MFDJIFIIPJD();
				d.KHEKNNFCAOI(int.Parse(strs[0]), int.Parse(strs[1]));
				BHABCGJCGNO = d;
			}
			PJLNJJIBFBN = INJCPCDPGHH.NGHKJOEDLIP.AHKPNPNOAMO != 0;
			MNDFBBMNJGN_IsUsingTicket = INJCPCDPGHH.NGHKJOEDLIP.MPKNCMEAMLO == 2;
			BHAHKCMJAJE = new List<int>();
			for(int i = 0; i < IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.DHOFNBMPBAG_EventItem.CDENCMNHNGA.Count; i++)
			{
				if(IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.DHOFNBMPBAG_EventItem.CDENCMNHNGA[i].INDDJNMPONH_Typ == INJCPCDPGHH.NGHKJOEDLIP.MJBKGOJBPAD_TicketType)
				{
					BHAHKCMJAJE.Add(IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.DHOFNBMPBAG_EventItem.CDENCMNHNGA[i].PPFNGGCBJKC_Id);
					if(BHAHKCMJAJE.Count == 3)
						break;
				}
			}
			JKIADEKHGLC_TicketItemId = 0;
			if(MNDFBBMNJGN_IsUsingTicket)
			{
				ABBOEIPOBLJ_EventTicket.CBDACMFFHJC ab = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.KHPOJKHKLEM_EventTicket.CDENCMNHNGA.Find((ABBOEIPOBLJ_EventTicket.CBDACMFFHJC GHPLINIACBB) =>
				{
					//0x1847590
					return GHPLINIACBB.INDDJNMPONH_Typ == INJCPCDPGHH.NGHKJOEDLIP.MJBKGOJBPAD_TicketType;
				});
				if(ab != null)
				{
					JKIADEKHGLC_TicketItemId = EKLNMHFCAOI.GJEEGMCBGGM_GetItemFullId(EKLNMHFCAOI.FKGCBLHOOCL_Category.CLMIJKACELE_EventTicket, ab.PPFNGGCBJKC_Id);
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
		PHBACNMCMHG_EventCollection NDFIEMPPMLF = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.LBDOLHGDIEB_GetDbSection(JOPOPMLFINI_QuestId) as PHBACNMCMHG_EventCollection;
		if(NDFIEMPPMLF != null)
		{
			Dictionary<string,int> DBEKEBNDMBH_SaveIdx = new Dictionary<string,int>();
			List<string> ls = new List<string>(20);
			string str = NDFIEMPPMLF.NGHKJOEDLIP.OCDMGOGMHGE_RewardPrefix;
			for(int i = 0; i < NDFIEMPPMLF.FCIPEDFHFEM_RewardStep.Count; i++)
			{
				for(int j = 0; j < NDFIEMPPMLF.FCIPEDFHFEM_RewardStep[i].AHJNPEAMCCH_Items.Count; j++)
				{
					if(NDFIEMPPMLF.FCIPEDFHFEM_RewardStep[i].AHJNPEAMCCH_Items[j].NMKEOMCMIPP_RewardId > 0)
					{
						ls.Add(str + NDFIEMPPMLF.FCIPEDFHFEM_RewardStep[i].AHJNPEAMCCH_Items[j].NMKEOMCMIPP_RewardId);
						DBEKEBNDMBH_SaveIdx.Add(str + NDFIEMPPMLF.FCIPEDFHFEM_RewardStep[i].AHJNPEAMCCH_Items[j].NMKEOMCMIPP_RewardId, i);
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
					FJGNPNFLHPH_EventCollection.JIALCLGJPKL save = CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave.MBAHCFLBDHN_EventCollection.FBCJICEPLED[NDFIEMPPMLF.NGHKJOEDLIP.MOEKELIIDEO_SaveIdx];
					for(int i = 0; i < r.NFEAMMJIMPG.CEDLLCCONJP.Count; i++)
					{
						if(DBEKEBNDMBH_SaveIdx.ContainsKey(r.NFEAMMJIMPG.CEDLLCCONJP[i].LJNAKDMILMC_Key))
						{
							if(r.NFEAMMJIMPG.CEDLLCCONJP[i].OOIJCMLEAJP_IsReceived)
							{
								save.LCDIGDMGPGO_TRcv[DBEKEBNDMBH_SaveIdx[r.NFEAMMJIMPG.CEDLLCCONJP[i].LJNAKDMILMC_Key]] = 1;
							}
						}
					}
					PIMFJALCIGK();
					PLOOEECNHFB = true;
				};
				req.MOBEEPPKFLG_OnFail = (CACGCMBKHDI_Request NHECPMNKEFK) =>
				{
					//0x1847AA4
					PLOOEECNHFB = true;
					NPNNPNAIONN = true;
				};
			}
			else
			{
				PIMFJALCIGK();
				PLOOEECNHFB = true;
			}
			return;
		}
		PLOOEECNHFB = true;
	}

	// [IteratorStateMachineAttribute] // RVA: 0x6BC3F4 Offset: 0x6BC3F4 VA: 0x6BC3F4
	// // RVA: 0x183E950 Offset: 0x183E950 VA: 0x183E950 Slot: 44
	protected override IEnumerator JEIJKLPOAHP_ReceivePrologueRepeatedAchievement(DJBHIFLHJLK AOCANKOMKFG)
	{
		//0x184A460
		KGBCKPKLKHM_RewardItems.Clear();
		PHBACNMCMHG_EventCollection ev = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.LBDOLHGDIEB_GetDbSection(JOPOPMLFINI_QuestId) as PHBACNMCMHG_EventCollection;
		if(ev != null)
		{
			string event_prologue_achv_key = ev.EFEGBHACJAL("event_prologue_achv_key", "");
			if(!string.IsNullOrEmpty(event_prologue_achv_key))
			{
				List<string> ls = new List<string>();
				ls.Add(event_prologue_achv_key);
				yield return Co.R(AOGIMHOLIFB_ReceiveLoguinRepetedAchivement(ls, AOCANKOMKFG));
			}
		}
	}

	// [IteratorStateMachineAttribute] // RVA: 0x6BC46C Offset: 0x6BC46C VA: 0x6BC46C
	// // RVA: 0x183EA18 Offset: 0x183EA18 VA: 0x183EA18 Slot: 45
	protected override IEnumerator KPBNMAEHHDF_ReceiveEpilogueRepeatedAchivement(DJBHIFLHJLK AOCANKOMKFG)
	{
		//0x184A130
		KGBCKPKLKHM_RewardItems.Clear();
		PHBACNMCMHG_EventCollection ev = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.LBDOLHGDIEB_GetDbSection(JOPOPMLFINI_QuestId) as PHBACNMCMHG_EventCollection;
		if(ev != null)
		{
			string event_epilogue_achv_key = ev.EFEGBHACJAL("event_epilogue_achv_key", "");
			if(!string.IsNullOrEmpty(event_epilogue_achv_key))
			{
				List<string> ls = new List<string>();
				ls.Add(event_epilogue_achv_key);
				yield return Co.R(AOGIMHOLIFB_ReceiveLoguinRepetedAchivement(ls, AOCANKOMKFG));
			}
		}
	}

	// // RVA: 0x183EAE0 Offset: 0x183EAE0 VA: 0x183EAE0 Slot: 46
	protected override void PJDGDNJNCNM_UpdateStatusImpl(long JHNMKKNEENE)
	{
		KIBBLLADDPO = false;
		PHBACNMCMHG_EventCollection ev = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.LBDOLHGDIEB_GetDbSection(JOPOPMLFINI_QuestId) as PHBACNMCMHG_EventCollection;
		if(ev != null)
		{
			FJGNPNFLHPH_EventCollection.JIALCLGJPKL save = CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave.MBAHCFLBDHN_EventCollection.FBCJICEPLED[ev.NGHKJOEDLIP.MOEKELIIDEO_SaveIdx];
			IBLPKJJNNIG = false;
			BELBNINIOIE = false;
			if(JHNMKKNEENE >= GLIMIGNNGGB_Start)
			{
				if(DPJCPDKALGI_End1 >= JHNMKKNEENE)
				{
					if(MBHDIJJEOFL != null)
					{
						for(int i = 0; i < MBHDIJJEOFL.Count; i++)
						{
							if(MBHDIJJEOFL[i].MAFAIIHJAFG == 0)
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
						if(JHNMKKNEENE < ev.NGHKJOEDLIP.EHHFFKAFOMC)
							return;
						KIBBLLADDPO = true;
						if(MBHDIJJEOFL != null)
						{
							for(int i = 0; i < MBHDIJJEOFL.Count; i++)
							{
								if(MBHDIJJEOFL[i].MAFAIIHJAFG == 1)
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
						if(JHNMKKNEENE < ev.NGHKJOEDLIP.EHHFFKAFOMC)
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
								if(MBHDIJJEOFL[i].MAFAIIHJAFG == 1)
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
								if(MBHDIJJEOFL[i].MAFAIIHJAFG == 1)
								{
									BELBNINIOIE = true;
									break;
								}
							}
						}
						return;
					}
				}
				if(JHNMKKNEENE >= ev.NGHKJOEDLIP.JGMDAOACOJF)
				{
					if(JHNMKKNEENE >= ev.NGHKJOEDLIP.IDDBFFBPNGI)
					{
						if(JHNMKKNEENE >= ev.NGHKJOEDLIP.KNLGKBBIBOH_End)
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
		NGOFCFJHOMI_Status = KGCNCBOKCBA.GNENJEHKMHD_EventStatus.HJNNKCMLGFL_0;
	}

	// // RVA: 0x183F154 Offset: 0x183F154 VA: 0x183F154 Slot: 47
	public override void NBMDAOFPKGK(int DNBFMLBNAEE)
	{
		PHBACNMCMHG_EventCollection ev = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.LBDOLHGDIEB_GetDbSection(JOPOPMLFINI_QuestId) as PHBACNMCMHG_EventCollection;
		if(ev != null)
		{
			FJGNPNFLHPH_EventCollection.JIALCLGJPKL save = CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave.MBAHCFLBDHN_EventCollection.FBCJICEPLED[ev.NGHKJOEDLIP.MOEKELIIDEO_SaveIdx];
			save.DNBFMLBNAEE_Point += DNBFMLBNAEE;
			save.NFIOKIBPJCJ_Uptime = NKGJPJPHLIF.HHCJCDFCLOB.IBLPICFDGOF_ServerRequester.FJDBNGEPKHL.KMEFBNBFJHI_GetServerTime();
		}
	}

	// // RVA: 0x183F4A4 Offset: 0x183F4A4 VA: 0x183F4A4
	public void DDIDDLEIIPM(int KNIFCANOHOC)
	{
		PHBACNMCMHG_EventCollection ev = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.LBDOLHGDIEB_GetDbSection(JOPOPMLFINI_QuestId) as PHBACNMCMHG_EventCollection;
		if(ev != null)
		{
			FJGNPNFLHPH_EventCollection.JIALCLGJPKL save = CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave.MBAHCFLBDHN_EventCollection.FBCJICEPLED[ev.NGHKJOEDLIP.MOEKELIIDEO_SaveIdx];
			if(save.KNIFCANOHOC_Score < KNIFCANOHOC)
			{
				save.KNIFCANOHOC_Score = KNIFCANOHOC;
				save.NFIOKIBPJCJ_Uptime = NKGJPJPHLIF.HHCJCDFCLOB.IBLPICFDGOF_ServerRequester.FJDBNGEPKHL.KMEFBNBFJHI_GetServerTime();
			}
		}
	}

	// // RVA: 0x183F7E8 Offset: 0x183F7E8 VA: 0x183F7E8 Slot: 48
	public override void AMKJFGLEJGE(int KPIILHGOGJD)
	{
		EECOJKDJIFG e = DAKMIKNKHMF_GetRankingInfoForIndex(KPIILHGOGJD);
		if(e != null)
		{
			PHBACNMCMHG_EventCollection ev = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.LBDOLHGDIEB_GetDbSection(JOPOPMLFINI_QuestId) as PHBACNMCMHG_EventCollection;
			if(ev != null)
			{
				FJGNPNFLHPH_EventCollection.JIALCLGJPKL save = CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave.MBAHCFLBDHN_EventCollection.FBCJICEPLED[ev.NGHKJOEDLIP.MOEKELIIDEO_SaveIdx];
				PJDGDNJNCNM_UpdateStatusImpl(NKGJPJPHLIF.HHCJCDFCLOB.IBLPICFDGOF_ServerRequester.FJDBNGEPKHL.KMEFBNBFJHI_GetServerTime());
				if(NGOFCFJHOMI_Status == KGCNCBOKCBA.GNENJEHKMHD_EventStatus.NCJFJLPJMLI_2 ||
					NGOFCFJHOMI_Status == KGCNCBOKCBA.GNENJEHKMHD_EventStatus.MINDIGBAJFG_3 ||
					NGOFCFJHOMI_Status == KGCNCBOKCBA.GNENJEHKMHD_EventStatus.MEAJLPAHINL_ChallengePeriod_5 ||
					NGOFCFJHOMI_Status == KGCNCBOKCBA.GNENJEHKMHD_EventStatus.EMAMLLFAOJI_Counting_6) //0x6cU
				{
					long val = 0;
					if(KPIILHGOGJD == 1)
					{
						if(save.KNIFCANOHOC_Score == 0)
						{
							PLOOEECNHFB = true;
							return;
						}
						val = save.KNIFCANOHOC_Score;
					}
					else if(KPIILHGOGJD == 0)
					{
						val = save.DNBFMLBNAEE_Point;
					}
					BOAGCEOHJEO.GOAOBNBGDBJ(GLIMIGNNGGB_Start, LOLAANGCGDO, save.NFIOKIBPJCJ_Uptime, val);
					EECOJKDJIFG e2 = KKLGENJKEBN.HHCJCDFCLOB.JPDPFGFMKHK.Find((EECOJKDJIFG GHPLINIACBB) =>
					{
						//0x1847AE8
						return e.OCGFKMHNEOF_NameForApi == GHPLINIACBB.OCGFKMHNEOF_NameForApi;
					});
					if(e2 != null)
					{
						PKECIDPBEFL.DDBKLMKKCDL d = new PKECIDPBEFL.DDBKLMKKCDL();
						d.OACABIDEMGG_Score = BOAGCEOHJEO.GOAOBNBGDBJ(GLIMIGNNGGB_Start, LOLAANGCGDO, save.NFIOKIBPJCJ_Uptime, val);
						d.BLJIJENHBPM_Id = e2.PPFNGGCBJKC_Id;
						d.OBGBAOLONDD_Unq = PGIIDPEGGPI_EventId;
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
		PLOOEECNHFB = false;
		EECOJKDJIFG e = DAKMIKNKHMF_GetRankingInfoForIndex(LHJCOPMMIGO);
		if(e != null)
		{
			PHBACNMCMHG_EventCollection INJCPCDPGHH = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.LBDOLHGDIEB_GetDbSection(JOPOPMLFINI_QuestId) as PHBACNMCMHG_EventCollection;
			if(INJCPCDPGHH != null)
			{
				FJGNPNFLHPH_EventCollection.JIALCLGJPKL NHLBKJCPLBL = CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave.MBAHCFLBDHN_EventCollection.FBCJICEPLED[INJCPCDPGHH.NGHKJOEDLIP.MOEKELIIDEO_SaveIdx];
				PJDGDNJNCNM_UpdateStatusImpl(NKGJPJPHLIF.HHCJCDFCLOB.IBLPICFDGOF_ServerRequester.FJDBNGEPKHL.KMEFBNBFJHI_GetServerTime());
				if(NGOFCFJHOMI_Status == KGCNCBOKCBA.GNENJEHKMHD_EventStatus.NCJFJLPJMLI_2 ||
					NGOFCFJHOMI_Status == KGCNCBOKCBA.GNENJEHKMHD_EventStatus.MINDIGBAJFG_3 ||
					NGOFCFJHOMI_Status == KGCNCBOKCBA.GNENJEHKMHD_EventStatus.MEAJLPAHINL_ChallengePeriod_5 ||
					NGOFCFJHOMI_Status == KGCNCBOKCBA.GNENJEHKMHD_EventStatus.EMAMLLFAOJI_Counting_6) //0x6cU
				{
					long val = 0;
					if(LHJCOPMMIGO == 1)
					{
						if(NHLBKJCPLBL.KNIFCANOHOC_Score == 0)
						{
							PLOOEECNHFB = true;
							return;
						}
						val = NHLBKJCPLBL.KNIFCANOHOC_Score;
					}
					else if(LHJCOPMMIGO == 0)
					{
						val = NHLBKJCPLBL.DNBFMLBNAEE_Point;
					}
					KKLGENJKEBN.HHCJCDFCLOB.LDOBHAAIDEJ_UpdateRankingScore(e.OCGFKMHNEOF_NameForApi, LHJCOPMMIGO, BOAGCEOHJEO.GOAOBNBGDBJ(GLIMIGNNGGB_Start, LOLAANGCGDO, NHLBKJCPLBL.NFIOKIBPJCJ_Uptime, val), () =>
					{
						//0x1847B34
						CDINKAANIAA_Rank[LHJCOPMMIGO] = (int)KKLGENJKEBN.HHCJCDFCLOB.LPPCNCMEDFA_Rank;
						PLOOEECNHFB = true;
						int ranking_point_max = INJCPCDPGHH.LPJLEHAJADA("ranking_point_max", 1000000);
						if(LHJCOPMMIGO == 1)
						{
							ILCCJNDFFOB.HHCJCDFCLOB.NNFGBBCHLPC(PGIIDPEGGPI_EventId, "StringLiteral_10992", EJDJIBPKKNO, NHLBKJCPLBL.KNIFCANOHOC_Score, ranking_point_max, KKLGENJKEBN.HHCJCDFCLOB.DFBALJAPHMC_DroppedPlayer);
						}
						else if(LHJCOPMMIGO == 0)
						{
							ILCCJNDFFOB.HHCJCDFCLOB.NNFGBBCHLPC(PGIIDPEGGPI_EventId, "StringLiteral_10929", EJDJIBPKKNO, NHLBKJCPLBL.DNBFMLBNAEE_Point, ranking_point_max, KKLGENJKEBN.HHCJCDFCLOB.DFBALJAPHMC_DroppedPlayer);
						}
					}, () =>
					{
						//0x1847E54
						PLOOEECNHFB = true;
					}, () =>
					{
						//0x1847E7C
						PLOOEECNHFB = true;
						NPNNPNAIONN = true;
					});
					return;
				}
			}
		}
		PLOOEECNHFB = true;
	}

	// // RVA: 0x18404A0 Offset: 0x18404A0 VA: 0x18404A0 Slot: 50
	protected override void MFJFBNPLFBE_OnReceieveTotalReward(bool GIPBIDFJFLL)
	{
		PHBACNMCMHG_EventCollection ev = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.LBDOLHGDIEB_GetDbSection(JOPOPMLFINI_QuestId) as PHBACNMCMHG_EventCollection;
		if(ev != null)
		{
			if(CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave.MBAHCFLBDHN_EventCollection.PFAKPFKJJKA() == null)
			{
				FJGNPNFLHPH_EventCollection.JIALCLGJPKL save = CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave.MBAHCFLBDHN_EventCollection.FBCJICEPLED[ev.NGHKJOEDLIP.MOEKELIIDEO_SaveIdx];
				long pt = FBGDBGKNKOD_GetCurrentPoint();
				JANMJPOKLFL_InventoryUtil.JCHLONCMPAJ();
				JOFBHHHLBBN_Rewards.Clear();
				List<string> ls = new List<string>(3);
				List<int> li = new List<int>(3);
				StringBuilder str = new StringBuilder();
				for(int i = 0; i < ev.FCIPEDFHFEM_RewardStep.Count; i++)
				{
					if(pt >= ev.FCIPEDFHFEM_RewardStep[i].DNBFMLBNAEE_Point)
					{
						if(!save.BHIAKGKHKGD(i))
						{
							str.Length = 0;
							str.Append(PGIIDPEGGPI_EventId);
							str.Append(':');
							str.Append(i);
							str.Append(':');
							str.Append(ev.FCIPEDFHFEM_RewardStep[i].DNBFMLBNAEE_Point);
							JANMJPOKLFL_InventoryUtil.FEGDNPIEKJC(OAGBCBBHMPF.COIIJOEKBDH.MGEFPKOJKBL_9, str.ToString());
							for(int j = 0; j < ev.FCIPEDFHFEM_RewardStep[i].AHJNPEAMCCH_Items.Count; j++)
							{
								if(ev.FCIPEDFHFEM_RewardStep[i].AHJNPEAMCCH_Items[j].NMKEOMCMIPP_RewardId > 0)
								{
									ls.Add(ev.NGHKJOEDLIP.OCDMGOGMHGE_RewardPrefix + ev.FCIPEDFHFEM_RewardStep[i].AHJNPEAMCCH_Items[j].NMKEOMCMIPP_RewardId);
									li.Add(!ev.FCIPEDFHFEM_RewardStep[i].AHJNPEAMCCH_Items[j].PJPDOCNJNGJ_IsLimited ? -1 : (int)ev.NGHKJOEDLIP.JBFDHOIKAIK_InventoryEndDate);
								}
								JANMJPOKLFL_InventoryUtil.CPIICACGNBH_AddItem(CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave, ev.FCIPEDFHFEM_RewardStep[i].AHJNPEAMCCH_Items[j].GLCLFMGPMAN_ItemId, ev.FCIPEDFHFEM_RewardStep[i].AHJNPEAMCCH_Items[j].HMFFHLPNMPH_Cnt, null, 0);
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
							PLOOEECNHFB = true;
							DENHAAGACPD(0);
						};
						req.MOBEEPPKFLG_OnFail = (CACGCMBKHDI_Request NHECPMNKEFK) =>
						{
							//0x1846F18
							if(NHECPMNKEFK.CJMFJOMECKI_ErrorId == SakashoErrorId.ACHIEVEMENT_PRIZE_ALREADY_RECEIVED)
							{
								DENHAAGACPD(0);
								PLOOEECNHFB = true;
							}
							else
							{
								PLOOEECNHFB = true;
								NPNNPNAIONN = true;
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
				NPNNPNAIONN = true;
			}
		}
		PLOOEECNHFB = true;
	}

	// // RVA: 0x1841490 Offset: 0x1841490 VA: 0x1841490 Slot: 52
	public override void FAMFKPBPIAA_GetRankingPlayerList(bool PFFJNEFNAMI, int CJHEHIMLGGL, int LHJCOPMMIGO, LIOLBKLMMIK KLMFJJCNBIP, DJBHIFLHJLK IDAEHNGOKAE, DJBHIFLHJLK JGKOLBLPMPG)
	{
		NPNNPNAIONN = false;
		PLOOEECNHFB = false;
		PHBACNMCMHG_EventCollection ev = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.LBDOLHGDIEB_GetDbSection(JOPOPMLFINI_QuestId) as PHBACNMCMHG_EventCollection;
		if(ev != null)
		{
			EECOJKDJIFG e = DAKMIKNKHMF_GetRankingInfoForIndex(LHJCOPMMIGO);
			if(e != null)
			{
				KKLGENJKEBN.HHCJCDFCLOB.FAMFKPBPIAA_GetRankingPlayerList(e.OCGFKMHNEOF_NameForApi, PFFJNEFNAMI, CJHEHIMLGGL, LHJCOPMMIGO, (int NEFEFHBHFFF, List<IBIGBMDANNM> MAGKKPOFJIM) =>
				{
					//0x1847EC0
					PLOOEECNHFB = true;
					KLMFJJCNBIP(NEFEFHBHFFF, MAGKKPOFJIM);
				}, () =>
				{
					//0x1847F1C
					PLOOEECNHFB = true;
					IDAEHNGOKAE();
				}, () =>
				{
					//0x1847F68
					PLOOEECNHFB = true;
					NPNNPNAIONN = true;
					JGKOLBLPMPG();
				}, false);
				return;
			}
		}
		IDAEHNGOKAE();
		PLOOEECNHFB = true;
	}

	// // RVA: 0x18417C8 Offset: 0x18417C8 VA: 0x18417C8 Slot: 53
	public override void JPNACOLKHLB_AddRankingPlayerListSecond(int CJHEHIMLGGL, int NEFEFHBHFFF, LIOLBKLMMIK KLMFJJCNBIP, DJBHIFLHJLK IDAEHNGOKAE, DJBHIFLHJLK JGKOLBLPMPG)
	{
		KKLGENJKEBN.HHCJCDFCLOB.JPNACOLKHLB_AddRankingPlayerListSecond(CJHEHIMLGGL, NEFEFHBHFFF, (int JGNBPFCJLKI, List<IBIGBMDANNM> MAGKKPOFJIM) =>
		{
			//0x1847FCC
			PLOOEECNHFB = true;
			KLMFJJCNBIP(JGNBPFCJLKI, MAGKKPOFJIM);
		}, () =>
		{
			//0x1848028
			PLOOEECNHFB = true;
			IDAEHNGOKAE();
		}, () =>
		{
			//0x1848074
			PLOOEECNHFB = true;
			NPNNPNAIONN = true;
			JGKOLBLPMPG();
		}, false);
	}

	// // RVA: 0x1841984 Offset: 0x1841984 VA: 0x1841984
	private int APJDIPINLLK(List<int> HNLFPKNBOHE, int PPFNGGCBJKC)
	{
		for(int i = 0; i < HNLFPKNBOHE.Count; i+= 2)
		{
			if(HNLFPKNBOHE[i] == PPFNGGCBJKC)
				return HNLFPKNBOHE[i + 1];
		}
		return PPFNGGCBJKC;
	}

	// // RVA: 0x1841A7C Offset: 0x1841A7C VA: 0x1841A7C Slot: 34
	public override int JDFHIHPPAHN_UpdateDropItemSet(int NHIJBNLJGDJ, OHCAABOMEOF.KGOGMKMBCPP_EventType INDDJNMPONH)
	{
		if(INDDJNMPONH == OHCAABOMEOF.KGOGMKMBCPP_EventType.AOPKACCDKPA_EventCollection)
		{
			PHBACNMCMHG_EventCollection ev = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.LBDOLHGDIEB_GetDbSection(JOPOPMLFINI_QuestId) as PHBACNMCMHG_EventCollection;
			if(ev != null)
			{
				return APJDIPINLLK(ev.NGHKJOEDLIP.BJHHDGCOACI, NHIJBNLJGDJ);
			}
		}
		return NHIJBNLJGDJ;
	}

	// // RVA: 0x1841C14 Offset: 0x1841C14 VA: 0x1841C14 Slot: 35
	public override int NCHKBINKKBH_UpdateDropRateSet(int BFOLFCOBBJD, OHCAABOMEOF.KGOGMKMBCPP_EventType INDDJNMPONH)
	{
		if(INDDJNMPONH == OHCAABOMEOF.KGOGMKMBCPP_EventType.AOPKACCDKPA_EventCollection)
		{
			PHBACNMCMHG_EventCollection ev = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.LBDOLHGDIEB_GetDbSection(JOPOPMLFINI_QuestId) as PHBACNMCMHG_EventCollection;
			if(ev != null)
			{
				return APJDIPINLLK(ev.NGHKJOEDLIP.JDDIOIMOFDE, BFOLFCOBBJD);
			}
		}
		return BFOLFCOBBJD;
	}

	// // RVA: 0x1841DAC Offset: 0x1841DAC VA: 0x1841DAC Slot: 36
	public override int EEMGDCPJNEG(int JEAHDIOLGEL, OHCAABOMEOF.KGOGMKMBCPP_EventType INDDJNMPONH)
	{
		if(INDDJNMPONH == OHCAABOMEOF.KGOGMKMBCPP_EventType.HJNNKCMLGFL_0)
		{
			PHBACNMCMHG_EventCollection ev = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.LBDOLHGDIEB_GetDbSection(JOPOPMLFINI_QuestId) as PHBACNMCMHG_EventCollection;
			if(ev != null)
			{
				return APJDIPINLLK(ev.NGHKJOEDLIP.HKEAFPNNAPC, JEAHDIOLGEL);
			}
		}
		return JEAHDIOLGEL;
	}

	// // RVA: 0x1841F44 Offset: 0x1841F44 VA: 0x1841F44 Slot: 37
	public override int DJHOMGLGAHA(int PLLAIBDLKHB, OHCAABOMEOF.KGOGMKMBCPP_EventType INDDJNMPONH)
	{
		if(INDDJNMPONH == OHCAABOMEOF.KGOGMKMBCPP_EventType.HJNNKCMLGFL_0)
		{
			PHBACNMCMHG_EventCollection ev = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.LBDOLHGDIEB_GetDbSection(JOPOPMLFINI_QuestId) as PHBACNMCMHG_EventCollection;
			if(ev != null)
			{
				return APJDIPINLLK(ev.NGHKJOEDLIP.MCDPPHKEMJI, PLLAIBDLKHB);
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
			PHBACNMCMHG_EventCollection ev = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.LBDOLHGDIEB_GetDbSection(JOPOPMLFINI_QuestId) as PHBACNMCMHG_EventCollection;
			if(ev != null)
			{
				FJGNPNFLHPH_EventCollection.JIALCLGJPKL save = CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave.MBAHCFLBDHN_EventCollection.FBCJICEPLED[ev.NGHKJOEDLIP.MOEKELIIDEO_SaveIdx];
				PFPJHJJAGAG_Rewards.Clear();
				EGIPGHCDMII_RankData[LHJCOPMMIGO].Clear();
				for(int i = 0; i < e.AHJNPEAMCCH_Rewards.Count; i++)
				{
					MAOCCKFAOPC d = new MAOCCKFAOPC();
					d.JBDGBPAAAEF_HighRank = e.AHJNPEAMCCH_Rewards[i].JPHDGGNAKMO_HighRank;
					d.GHANKNIBALB_LowRank = e.AHJNPEAMCCH_Rewards[i].FGCAJEAIABA_LowRank;
					d.MJGAMDBOMHD_InventoryMessage = e.AHJNPEAMCCH_Rewards[i].IPFEKNMBEBI_InventoryMessage;
					d.HBHMAKNGKFK_Items = e.AHJNPEAMCCH_Rewards[i].HBHMAKNGKFK_Items;
					EGIPGHCDMII_RankData[LHJCOPMMIGO].Add(d);
				}
				for(int i = 0; i < ev.FCIPEDFHFEM_RewardStep.Count; i++)
				{
					IHAEIOAKEMG d = new IHAEIOAKEMG();
					for(int j = 0; j < ev.FCIPEDFHFEM_RewardStep[i].AHJNPEAMCCH_Items.Count; j++)
					{
						MFDJIFIIPJD d2 = new MFDJIFIIPJD();
						d2.KHEKNNFCAOI(ev.FCIPEDFHFEM_RewardStep[i].AHJNPEAMCCH_Items[j].GLCLFMGPMAN_ItemId, ev.FCIPEDFHFEM_RewardStep[i].AHJNPEAMCCH_Items[j].HMFFHLPNMPH_Cnt);
						d2.JOPPFEHKNFO_IsGold = ev.FCIPEDFHFEM_RewardStep[i].AHJNPEAMCCH_Items[j].JOPPFEHKNFO_IsGold;
						d.HBHMAKNGKFK_Items.Add(d2);
					}
					d.HMEOAKCLKJE_IsReceived = save.BHIAKGKHKGD(i);
					d.FIOIKMOIJGK_Point = ev.FCIPEDFHFEM_RewardStep[i].DNBFMLBNAEE_Point;
					d.OJELCGDDAOM_MissingPoint = (int)(d.FIOIKMOIJGK_Point - save.DNBFMLBNAEE_Point);
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
			PHBACNMCMHG_EventCollection ev = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.LBDOLHGDIEB_GetDbSection(JOPOPMLFINI_QuestId) as PHBACNMCMHG_EventCollection;
			if(ev != null)
			{
                FJGNPNFLHPH_EventCollection.JIALCLGJPKL save = CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave.MBAHCFLBDHN_EventCollection.FBCJICEPLED[ev.NGHKJOEDLIP.MOEKELIIDEO_SaveIdx];
				for(int i = 0; i < PFPJHJJAGAG_Rewards.Count; i++)
				{
					PFPJHJJAGAG_Rewards[i].HMEOAKCLKJE_IsReceived = save.BHIAKGKHKGD(i);
					PFPJHJJAGAG_Rewards[i].OJELCGDDAOM_MissingPoint = PFPJHJJAGAG_Rewards[i].FIOIKMOIJGK_Point - (int)save.DNBFMLBNAEE_Point;
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
	public override int EAMODCHMCEL_GetTicketCost(int AKNELONELJK, bool GIKLNODJKFK)
	{
		PHBACNMCMHG_EventCollection ev = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.LBDOLHGDIEB_GetDbSection(JOPOPMLFINI_QuestId) as PHBACNMCMHG_EventCollection;
		if(ev != null)
		{
			return ev.NGHKJOEDLIP.KIGCDOJGJEP(AKNELONELJK, GIKLNODJKFK);
		}
		return 0;
	}

	// // RVA: 0x1842C24 Offset: 0x1842C24 VA: 0x1842C24 Slot: 13
	public override bool NLFIGGNLEFP(int AKNELONELJK, bool GIKLNODJKFK, int LCCGDFGGIHI)
	{
		PHBACNMCMHG_EventCollection ev = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.LBDOLHGDIEB_GetDbSection(JOPOPMLFINI_QuestId) as PHBACNMCMHG_EventCollection;
		if(ev != null)
		{
			ABBOEIPOBLJ_EventTicket.CBDACMFFHJC tkt = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.KHPOJKHKLEM_EventTicket.CDENCMNHNGA.Find((ABBOEIPOBLJ_EventTicket.CBDACMFFHJC GHPLINIACBB) =>
			{
				//0x18480D8
				return GHPLINIACBB.INDDJNMPONH_Typ == ev.NGHKJOEDLIP.MJBKGOJBPAD_TicketType;
			});
			if(tkt != null)
			{
                FJGNPNFLHPH_EventCollection.JIALCLGJPKL save = CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave.MBAHCFLBDHN_EventCollection.FBCJICEPLED[ev.NGHKJOEDLIP.MOEKELIIDEO_SaveIdx];
				int cnt = ev.NGHKJOEDLIP.KIGCDOJGJEP(AKNELONELJK, GIKLNODJKFK) * LCCGDFGGIHI * HADLPHIMBHH_BoostRatio;
				//UnityEngine.Debug.LogError(cnt+" "+ev.NGHKJOEDLIP.KIGCDOJGJEP(AKNELONELJK, GIKLNODJKFK)+" "+LCCGDFGGIHI+" "+HADLPHIMBHH_BoostRatio+" "+save.KCGJGPOFOCD_Ticket);
				if(cnt - save.KCGJGPOFOCD_Ticket != 0 && save.KCGJGPOFOCD_Ticket <= cnt)
					return false;
                save.KCGJGPOFOCD_Ticket -= cnt;
				return true;
			}
		}
		return false;
	}

	// // RVA: 0x184309C Offset: 0x184309C VA: 0x184309C Slot: 14
	public override void HPENJEOAMBK_SetTicket(int JKIADEKHGLC, int HMFFHLPNMPH, BBHNACPENDM_ServerSaveData AHEFHIMGIBI)
	{
		PHBACNMCMHG_EventCollection ev = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.LBDOLHGDIEB_GetDbSection(JOPOPMLFINI_QuestId) as PHBACNMCMHG_EventCollection;
		if(ev != null)
		{
			if(AHEFHIMGIBI == null)
			{
				AHEFHIMGIBI = CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave;
			}
			if(MNDFBBMNJGN_IsUsingTicket)
			{
                ABBOEIPOBLJ_EventTicket.CBDACMFFHJC tkt = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.KHPOJKHKLEM_EventTicket.CDENCMNHNGA.Find((ABBOEIPOBLJ_EventTicket.CBDACMFFHJC GHPLINIACBB) =>
				{
					//0x1848134
					return GHPLINIACBB.INDDJNMPONH_Typ == ev.NGHKJOEDLIP.MJBKGOJBPAD_TicketType;
				});
				if(tkt != null && JKIADEKHGLC_TicketItemId == JKIADEKHGLC && HMFFHLPNMPH > 0)
				{
					for(int i = 0; i < HMFFHLPNMPH; i++)
						AHEFHIMGIBI.MBAHCFLBDHN_EventCollection.FBCJICEPLED[ev.NGHKJOEDLIP.MOEKELIIDEO_SaveIdx].KCGJGPOFOCD_Ticket += tkt.JBGEEPFKIGG_Val;
				}
            }
		}
	}

	// // RVA: 0x18434A8 Offset: 0x18434A8 VA: 0x18434A8 Slot: 11
	public override int AELBIEDNPGB_GetTicketCount(BBHNACPENDM_ServerSaveData AHEFHIMGIBI)
	{
		PHBACNMCMHG_EventCollection ev = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.LBDOLHGDIEB_GetDbSection(JOPOPMLFINI_QuestId) as PHBACNMCMHG_EventCollection;
		if(ev != null)
		{
			if(AHEFHIMGIBI == null)
			{
				AHEFHIMGIBI = CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave;
			}
			if(MNDFBBMNJGN_IsUsingTicket)
			{
                ABBOEIPOBLJ_EventTicket.CBDACMFFHJC tkt = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.KHPOJKHKLEM_EventTicket.CDENCMNHNGA.Find((ABBOEIPOBLJ_EventTicket.CBDACMFFHJC GHPLINIACBB) =>
				{
					//0x1848190
					return GHPLINIACBB.INDDJNMPONH_Typ == ev.NGHKJOEDLIP.MJBKGOJBPAD_TicketType;
				});
				if(tkt != null)
				{
					return AHEFHIMGIBI.MBAHCFLBDHN_EventCollection.FBCJICEPLED[ev.NGHKJOEDLIP.MOEKELIIDEO_SaveIdx].KCGJGPOFOCD_Ticket;
				}
            }
		}
		return 0;
	}

	// // RVA: 0x1843860 Offset: 0x1843860 VA: 0x1843860 Slot: 54
	public override int NGIHFKHOJOK_GetRankingMax(bool DJHLDMOPCOL = true)
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
		PHBACNMCMHG_EventCollection ev = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.LBDOLHGDIEB_GetDbSection(JOPOPMLFINI_QuestId) as PHBACNMCMHG_EventCollection;
		if(ev != null)
		{
            EECOJKDJIFG e = DAKMIKNKHMF_GetRankingInfoForIndex(LHJCOPMMIGO);
			if(e != null)
			{
				HLFHJIDHJMP = null;
				OKPEFAPPFDH_GetRanksAroundSelf req = NKGJPJPHLIF.HHCJCDFCLOB.IBLPICFDGOF_ServerRequester.IFFNCAFNEAG_AddRequest(new OKPEFAPPFDH_GetRanksAroundSelf());
				req.EMPNJPMAKBF_Id = e.PPFNGGCBJKC_Id;
				req.MJGOBEGONON_Type = 0;
				req.NHPCKCOPKAM_From = 0;
				req.PJFKNNNDMIA_To = 0;
				req.MOBEEPPKFLG_OnFail = (CACGCMBKHDI_Request KCFBGMKDIMI) =>
				{
					//0x18481EC
					if(JGJFFKPFMDB.BDGBCCGLLAJ_IsRankingError(KCFBGMKDIMI.CJMFJOMECKI_ErrorId))
					{
						if(KCFBGMKDIMI.CJMFJOMECKI_ErrorId == SakashoErrorId.RANKING_DROPPED_PLAYER)
						{
							FKKDIDMGLMI = true;
						}
						FJGNPNFLHPH_EventCollection.JIALCLGJPKL save = CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave.MBAHCFLBDHN_EventCollection.FBCJICEPLED[ev.NGHKJOEDLIP.MOEKELIIDEO_SaveIdx];
						save.LHAEPPFACOB(true, LHJCOPMMIGO);
						PJDGDNJNCNM_UpdateStatusImpl(NKGJPJPHLIF.HHCJCDFCLOB.IBLPICFDGOF_ServerRequester.FJDBNGEPKHL.KMEFBNBFJHI_GetServerTime());
						PLOOEECNHFB = true;
					}
					else
					{
						PLOOEECNHFB = true;
						NPNNPNAIONN = true;
					}
				};
				req.BHFHGFKBOHH_OnSuccess = (CACGCMBKHDI_Request KCFBGMKDIMI) =>
				{
					//0x1848520
					OKPEFAPPFDH_GetRanksAroundSelf r = KCFBGMKDIMI as OKPEFAPPFDH_GetRanksAroundSelf;
					if(r.NFEAMMJIMPG.EJDEDOJFOOK.Count == 0)
					{
						FJGNPNFLHPH_EventCollection.JIALCLGJPKL save = CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave.MBAHCFLBDHN_EventCollection.FBCJICEPLED[ev.NGHKJOEDLIP.MOEKELIIDEO_SaveIdx];
						save.LHAEPPFACOB(true, LHJCOPMMIGO);
						PJDGDNJNCNM_UpdateStatusImpl(NKGJPJPHLIF.HHCJCDFCLOB.IBLPICFDGOF_ServerRequester.FJDBNGEPKHL.KMEFBNBFJHI_GetServerTime());
						PLOOEECNHFB = true;
					}
					else
					{
						HLFHJIDHJMP = new NHGEHCMPDAI();
						HLFHJIDHJMP.DNBFMLBNAEE_CurrentPoint = r.NFEAMMJIMPG.EJDEDOJFOOK[0].KNIFCANOHOC_Score;
						HLFHJIDHJMP.FJOLNJLLJEJ_Rank = r.NFEAMMJIMPG.EJDEDOJFOOK[0].FJOLNJLLJEJ_Rank;
						KKLGENJKEBN.HHCJCDFCLOB.DNJKPPCBINA(e.OCGFKMHNEOF_NameForApi, () =>
						{
							//0x1848BE4
							for(int i = 0; i < KKLGENJKEBN.HHCJCDFCLOB.PHOPJDPEHJA.Count; i++)
							{
								MFDJIFIIPJD d = new MFDJIFIIPJD();
								d.KHEKNNFCAOI(KKLGENJKEBN.HHCJCDFCLOB.PHOPJDPEHJA[i].JJBGOIMEIPF_ItemFullId, KKLGENJKEBN.HHCJCDFCLOB.PHOPJDPEHJA[i].MBJIFDBEDAC_ItemCount);
								HLFHJIDHJMP.HBHMAKNGKFK.Add(d);
							}
							ILCCJNDFFOB.HHCJCDFCLOB.GIBLHFKIMDA(this);
							FJGNPNFLHPH_EventCollection.JIALCLGJPKL save = CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave.MBAHCFLBDHN_EventCollection.FBCJICEPLED[ev.NGHKJOEDLIP.MOEKELIIDEO_SaveIdx];
							save.LHAEPPFACOB(true, LHJCOPMMIGO);
							PLOOEECNHFB = true;
						}, () =>
						{
							//0x1848F64
							HLFHJIDHJMP = null;
							ILCCJNDFFOB.HHCJCDFCLOB.GIBLHFKIMDA(this);
							FJGNPNFLHPH_EventCollection.JIALCLGJPKL save = CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave.MBAHCFLBDHN_EventCollection.FBCJICEPLED[ev.NGHKJOEDLIP.MOEKELIIDEO_SaveIdx];
							save.LHAEPPFACOB(true, LHJCOPMMIGO);
							PLOOEECNHFB = true;
						}, () =>
						{
							//0x1849154
							FJGNPNFLHPH_EventCollection.JIALCLGJPKL save = CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave.MBAHCFLBDHN_EventCollection.FBCJICEPLED[ev.NGHKJOEDLIP.MOEKELIIDEO_SaveIdx];
							save.LHAEPPFACOB(true, LHJCOPMMIGO);
							PLOOEECNHFB = true;
							HLFHJIDHJMP = null;
						}, () =>
						{
							//0x18492E8
							PLOOEECNHFB = true;
							HLFHJIDHJMP = null;
						}, () =>
						{
							//0x1849330
							PLOOEECNHFB = true;
							NPNNPNAIONN = true;
						}, 0, -1);
					}
				};
				return;
			}
        }
		PLOOEECNHFB = true;
	}

	// // RVA: 0x1843D48 Offset: 0x1843D48 VA: 0x1843D48 Slot: 59
	public override List<int> AEGDKBNNDBC_GetDrops()
	{
		PHBACNMCMHG_EventCollection ev = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.LBDOLHGDIEB_GetDbSection(JOPOPMLFINI_QuestId) as PHBACNMCMHG_EventCollection;
		if(ev != null)
		{
			return ev.NGHKJOEDLIP.EEOGPJJCKHH_Drops;
		}
		return null;
	}

	// // RVA: 0x1843ECC Offset: 0x1843ECC VA: 0x1843ECC Slot: 33
	public override bool MPMKJNJGFEF_IsEntry()
	{
		PHBACNMCMHG_EventCollection ev = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.LBDOLHGDIEB_GetDbSection(JOPOPMLFINI_QuestId) as PHBACNMCMHG_EventCollection;
		if(ev != null)
		{
			FJGNPNFLHPH_EventCollection.JIALCLGJPKL save = CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave.MBAHCFLBDHN_EventCollection.FBCJICEPLED[ev.NGHKJOEDLIP.MOEKELIIDEO_SaveIdx];
			return save.IMFBCJOIJKJ_Entry;
		}
		return false;
	}

	// // RVA: 0x184412C Offset: 0x184412C VA: 0x184412C Slot: 65
	protected override bool JLPDECMHLIM_CanShowStartAdventureInternal()
	{
		PHBACNMCMHG_EventCollection ev = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.LBDOLHGDIEB_GetDbSection(JOPOPMLFINI_QuestId) as PHBACNMCMHG_EventCollection;
		if(ev != null)
		{
			FJGNPNFLHPH_EventCollection.JIALCLGJPKL save = CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave.MBAHCFLBDHN_EventCollection.FBCJICEPLED[ev.NGHKJOEDLIP.MOEKELIIDEO_SaveIdx];
			long t = NKGJPJPHLIF.HHCJCDFCLOB.IBLPICFDGOF_ServerRequester.FJDBNGEPKHL.KMEFBNBFJHI_GetServerTime();
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
	public override void FGDDBFHGCGP_SetStartAdventureShown(bool JKDJCFEBDHC, long JHNMKKNEENE = 0)
	{
		if(JKDJCFEBDHC)
		{
			PHBACNMCMHG_EventCollection ev = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.LBDOLHGDIEB_GetDbSection(JOPOPMLFINI_QuestId) as PHBACNMCMHG_EventCollection;
			if(ev != null)
			{
				FJGNPNFLHPH_EventCollection.JIALCLGJPKL save = CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave.MBAHCFLBDHN_EventCollection.FBCJICEPLED[ev.NGHKJOEDLIP.MOEKELIIDEO_SaveIdx];
				if(NGOFCFJHOMI_Status == KGCNCBOKCBA.GNENJEHKMHD_EventStatus.NCJFJLPJMLI_2)
				{
					save.INLNJOGHLJE_Show |= 1;
				}
			}
		}
	}

	// // RVA: 0x18446E8 Offset: 0x18446E8 VA: 0x18446E8 Slot: 70
	public override void ADACMHAHHKC_PreSetupEventHome(IMCBBOAFION BHFHGFKBOHH, DJBHIFLHJLK AOCANKOMKFG)
	{
		N.a.StartCoroutineWatched(NJIEIJJMAHK_Corotuine_PreSetupEventHome(BHFHGFKBOHH, AOCANKOMKFG));
	}

	// [IteratorStateMachineAttribute] // RVA: 0x6BC4E4 Offset: 0x6BC4E4 VA: 0x6BC4E4
	// // RVA: 0x1844740 Offset: 0x1844740 VA: 0x1844740
	private IEnumerator NJIEIJJMAHK_Corotuine_PreSetupEventHome(IMCBBOAFION BHFHGFKBOHH, DJBHIFLHJLK AOCANKOMKFG)
	{
		long IBCGNDADAEE; // 0x28
		PHBACNMCMHG_EventCollection KEHCNBNPJHB; // 0x30
		BBHNACPENDM_ServerSaveData PNFNCKGAFBK; // 0x34
		FJGNPNFLHPH_EventCollection.JIALCLGJPKL FDAENOPKLKP; // 0x38

		//0x18493A0
		while(CIOECGOMILE.HHCJCDFCLOB.KONHMOLMOCI_IsSaving)
			yield return null;
		IBCGNDADAEE = NKGJPJPHLIF.HHCJCDFCLOB.IBLPICFDGOF_ServerRequester.FJDBNGEPKHL.KMEFBNBFJHI_GetServerTime();
		KEHCNBNPJHB = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.LBDOLHGDIEB_GetDbSection(JOPOPMLFINI_QuestId) as PHBACNMCMHG_EventCollection;
		if(KEHCNBNPJHB != null)
		{
			PJDGDNJNCNM_UpdateStatusImpl(IBCGNDADAEE);
			PNFNCKGAFBK = CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave;
			FDAENOPKLKP = PNFNCKGAFBK.MBAHCFLBDHN_EventCollection.FBCJICEPLED[KEHCNBNPJHB.NGHKJOEDLIP.MOEKELIIDEO_SaveIdx];
			if(FDAENOPKLKP.DNBFMLBNAEE_Point != 0)
			{
				MJFKJHJJLMN_GetRanks(0, false);
				//LAB_01849524
				while(!PLOOEECNHFB)
					yield return null;
				if(NPNNPNAIONN)
				{
					if(AOCANKOMKFG != null)
						AOCANKOMKFG();
					yield break;
				}
				if(FKKDIDMGLMI)
				{
					JHHBAFKMBDL.HHCJCDFCLOB.PEIONAKEPCN_ShowRankingBanPopup(AOCANKOMKFG);
					yield break;
				}
			}
			//_breakk
			if(NGOFCFJHOMI_Status == KGCNCBOKCBA.GNENJEHKMHD_EventStatus.GDOPLACICFE_4)
			{
				FDAENOPKLKP.ABBJBPLHFHA_Spurt = true;
				LPFJADHHLHG = true;
				PJDGDNJNCNM_UpdateStatusImpl(IBCGNDADAEE);
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
								if(AOCANKOMKFG != null)
									AOCANKOMKFG();
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
							if(AOCANKOMKFG != null)
								AOCANKOMKFG();
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
				if(KEHCNBNPJHB.OHJFBLFELNK.TryGetValue(HOEKCEJINNA, out d))
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
						if(b && KEHCNBNPJHB.OHJFBLFELNK.TryGetValue(FOKNMOMNHHD, out d))
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
			if(BHFHGFKBOHH != null)
				BHFHGFKBOHH();
		}
		else
		{
			NPNNPNAIONN = true;
			PLOOEECNHFB = true;
			if(AOCANKOMKFG != null)
				AOCANKOMKFG();
		}
	}

	// [IteratorStateMachineAttribute] // RVA: 0x6BC55C Offset: 0x6BC55C VA: 0x6BC55C
	// // RVA: 0x1844820 Offset: 0x1844820 VA: 0x1844820
	public IEnumerator INOILCGFHIC_RequestGetScoreRank(IMCBBOAFION BHFHGFKBOHH, DJBHIFLHJLK AOCANKOMKFG)
	{
		//0x184A790
		PHBACNMCMHG_EventCollection ev = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.LBDOLHGDIEB_GetDbSection(JOPOPMLFINI_QuestId) as PHBACNMCMHG_EventCollection;
		if(ev != null)
		{
			FJGNPNFLHPH_EventCollection.JIALCLGJPKL save = CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave.MBAHCFLBDHN_EventCollection.FBCJICEPLED[ev.NGHKJOEDLIP.MOEKELIIDEO_SaveIdx];
			if(save.KNIFCANOHOC_Score != 0)
			{
				MJFKJHJJLMN_GetRanks(1, false);
				while(!PLOOEECNHFB)
					yield return null;
				if(NPNNPNAIONN)
				{
					AOCANKOMKFG();
					yield break;
				}
				else
				{
					if(FKKDIDMGLMI)
					{
						JHHBAFKMBDL.HHCJCDFCLOB.PEIONAKEPCN_ShowRankingBanPopup(AOCANKOMKFG);
						yield break;
					}
				}
			}
			//LAB_0184aafc
			BHFHGFKBOHH();
		}
		else
		{
			NPNNPNAIONN = true;
			PLOOEECNHFB = true;
			if(AOCANKOMKFG != null)
				AOCANKOMKFG();
		}
	}

	// // RVA: 0x1844900 Offset: 0x1844900 VA: 0x1844900 Slot: 69
	// public override void HAAEJDGMICH(LBNLAENLPNK.JEKODBEDOMM INDDJNMPONH, IMCBBOAFION BHFHGFKBOHH, DJBHIFLHJLK AOCANKOMKFG) { }

	// // RVA: 0x1844A28 Offset: 0x1844A28 VA: 0x1844A28 Slot: 71
	public override int BAEPGOAMBDK(string LJNAKDMILMC, int MNCOAGOKNAO)
	{
		PHBACNMCMHG_EventCollection ev = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.LBDOLHGDIEB_GetDbSection(JOPOPMLFINI_QuestId) as PHBACNMCMHG_EventCollection;
		if(ev != null)
		{
			return ev.LPJLEHAJADA(LJNAKDMILMC, MNCOAGOKNAO);
		}
		return MNCOAGOKNAO;
	}

	// // RVA: 0x1844BA8 Offset: 0x1844BA8 VA: 0x1844BA8 Slot: 72
	public override string MAICAKMIBEM(string LJNAKDMILMC, string MNCOAGOKNAO)
	{
		PHBACNMCMHG_EventCollection ev = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.LBDOLHGDIEB_GetDbSection(JOPOPMLFINI_QuestId) as PHBACNMCMHG_EventCollection;
		if(ev != null)
		{
			return ev.EFEGBHACJAL(LJNAKDMILMC, MNCOAGOKNAO);
		}
		return MNCOAGOKNAO;
	}

	// // RVA: 0x1844D28 Offset: 0x1844D28 VA: 0x1844D28 Slot: 68
	public override bool GJMGKBDGMOP(long LPEKHFOMCAH)
	{
		PHBACNMCMHG_EventCollection ev = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.LBDOLHGDIEB_GetDbSection(JOPOPMLFINI_QuestId) as PHBACNMCMHG_EventCollection;
		if(ev != null)
		{
			if(BHABCGJCGNO != null)
			{
				if(LPEKHFOMCAH < DPJCPDKALGI_End1)
				{
					FJGNPNFLHPH_EventCollection.JIALCLGJPKL save = CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave.MBAHCFLBDHN_EventCollection.FBCJICEPLED[ev.NGHKJOEDLIP.MOEKELIIDEO_SaveIdx];
					if(NKGJPJPHLIF.HHCJCDFCLOB.DHMLDAGGKCD != save.OMCAOJJGOGG_Lb)
					{
						if(EKLNMHFCAOI.BKHFLDMOGBD_GetItemCategory(BHABCGJCGNO.JJBGOIMEIPF_ItemId) == EKLNMHFCAOI.FKGCBLHOOCL_Category.DMMIIBCMCFG_EnergyItem)
						{
							int id = EKLNMHFCAOI.DEACAHNLMNI_getItemId(BHABCGJCGNO.JJBGOIMEIPF_ItemId);
							EGOLBAPFHHD_Common.FKLHGOGJOHH it = CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave.KCCLEHLLOFG_Common.KFEBOFKAHAJ_EngItem[id - 1];
							it.BFINGCJHOHI_Cnt += BHABCGJCGNO.MBJIFDBEDAC_Cnt;
							it.BEBJKJKBOGH_Date = NKGJPJPHLIF.HHCJCDFCLOB.IBLPICFDGOF_ServerRequester.FJDBNGEPKHL.KMEFBNBFJHI_GetServerTime();
							ILCCJNDFFOB.HHCJCDFCLOB.JAHALBMOANH(BHABCGJCGNO.JJBGOIMEIPF_ItemId, OAGBCBBHMPF.COIIJOEKBDH.IGAJCMKNLDL_14, 
								PGIIDPEGGPI_EventId.ToString(), BHABCGJCGNO.MBJIFDBEDAC_Cnt, it.BFINGCJHOHI_Cnt, 1);
							save.OMCAOJJGOGG_Lb = NKGJPJPHLIF.HHCJCDFCLOB.DHMLDAGGKCD;
						}
						else if(EKLNMHFCAOI.BKHFLDMOGBD_GetItemCategory(BHABCGJCGNO.JJBGOIMEIPF_ItemId) == EKLNMHFCAOI.FKGCBLHOOCL_Category.CLMIJKACELE_EventTicket)
						{
							HPENJEOAMBK_SetTicket(BHABCGJCGNO.JJBGOIMEIPF_ItemId, BHABCGJCGNO.MBJIFDBEDAC_Cnt, CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave);
							save.OMCAOJJGOGG_Lb = NKGJPJPHLIF.HHCJCDFCLOB.DHMLDAGGKCD;
							ILCCJNDFFOB.HHCJCDFCLOB.JAHALBMOANH(BHABCGJCGNO.JJBGOIMEIPF_ItemId, OAGBCBBHMPF.COIIJOEKBDH.IGAJCMKNLDL_14, 
								PGIIDPEGGPI_EventId.ToString(), BHABCGJCGNO.MBJIFDBEDAC_Cnt, save.KCGJGPOFOCD_Ticket, 1);
						}
						return true;
					}
				}
			}
		}
		return false;
	}

	// // RVA: 0x18456E0 Offset: 0x18456E0 VA: 0x18456E0
	public void FCLGOCBGPJF(JGEOBNENMAH.HAJIFNABIFF OMNOFMEBLAD, JKNGJFOBADP IKCBPLIFBOJ, int FCLGIPFPIPH, int BMMPAHHEOJC, int MHADLGMJKGK)
	{
		PHBACNMCMHG_EventCollection ev = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.LBDOLHGDIEB_GetDbSection(JOPOPMLFINI_QuestId) as PHBACNMCMHG_EventCollection;
		if(ev != null)
		{
			EELENPNCGLM.PPBHHLGPMBK = IKCBPLIFBOJ.PPBHHLGPMBK;
			EELENPNCGLM.IONINNDIAFO = IKCBPLIFBOJ.IONINNDIAFO;
			EELENPNCGLM.FCLGIPFPIPH = FCLGIPFPIPH;
			EELENPNCGLM.FPEOGFMKMKJ = 0;
			for(int i = 0; i < 3; i++)
			{
				if(IKCBPLIFBOJ.PPBHHLGPMBK[i] != 0)
				{
					EELENPNCGLM.FPEOGFMKMKJ += IKCBPLIFBOJ.IONINNDIAFO[i] * IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.DHOFNBMPBAG_EventItem.CDENCMNHNGA[IKCBPLIFBOJ.PPBHHLGPMBK[i] - 1].JBGEEPFKIGG_Val;
				}
			}
			EELENPNCGLM.ANOCILKJGOJ = LEPNPBIMHGM(BMMPAHHEOJC).Count;
			EELENPNCGLM.ODCLHPGHDHA = CEICDKGEONG(BMMPAHHEOJC, MHADLGMJKGK);
			EELENPNCGLM.ODCLHPGHDHA += 100;
			EELENPNCGLM.PIIEGNPOPJI_GetPoint = EELENPNCGLM.ODCLHPGHDHA * EELENPNCGLM.FPEOGFMKMKJ / 100;
			EELENPNCGLM.PIIEGNPOPJI_GetPoint *= EELENPNCGLM.FCLGIPFPIPH;
			NBMDAOFPKGK(EELENPNCGLM.PIIEGNPOPJI_GetPoint);
			EELENPNCGLM.OENBOLPDBAB = HEACCHAKMFG_GetMusicsList()[0];
			FJGNPNFLHPH_EventCollection.JIALCLGJPKL save = CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave.MBAHCFLBDHN_EventCollection.FBCJICEPLED[ev.NGHKJOEDLIP.MOEKELIIDEO_SaveIdx];
			EELENPNCGLM.GCAPLLEIAAI_NewScore = OMNOFMEBLAD.KNIFCANOHOC_Score;
			EELENPNCGLM.IDCFOMMKGIK = EELENPNCGLM.ODCLHPGHDHA * OMNOFMEBLAD.KNIFCANOHOC_Score / 100;
			EELENPNCGLM.LPGNCOFHOPK_SaveScore = (int)save.KNIFCANOHOC_Score;
			EELENPNCGLM.GIIKOMPJOHA = false;
			if(OMNOFMEBLAD.PMCGHPOGLGM_IsSkip)
				return;
			EECOJKDJIFG e = DAKMIKNKHMF_GetRankingInfoForIndex(1);
			if(e == null)
				return;
			if(OMNOFMEBLAD.GHBPLHBNMBK_FreeMusicId != EELENPNCGLM.OENBOLPDBAB)
				return;
			if(EELENPNCGLM.IDCFOMMKGIK <= EELENPNCGLM.LPGNCOFHOPK_SaveScore)
				return;
			DDIDDLEIIPM(EELENPNCGLM.IDCFOMMKGIK);
			EELENPNCGLM.LPGNCOFHOPK_SaveScore = EELENPNCGLM.IDCFOMMKGIK;
			EELENPNCGLM.GIIKOMPJOHA = true;
		}
	}

	// // RVA: 0x1845EEC Offset: 0x1845EEC VA: 0x1845EEC
	public void NGIPMNLALAA(int EJDJIBPKKNO, int FCLGIPFPIPH, int BMMPAHHEOJC, int MHADLGMJKGK, int AKNELONELJK)
	{
		EELENPNCGLM.FCLGIPFPIPH = FCLGIPFPIPH;
		EELENPNCGLM.FPEOGFMKMKJ = EJDJIBPKKNO;
		EELENPNCGLM.ANOCILKJGOJ = LEPNPBIMHGM(BMMPAHHEOJC).Count;
		EELENPNCGLM.ODCLHPGHDHA = CEICDKGEONG(BMMPAHHEOJC, MHADLGMJKGK);
		EELENPNCGLM.ODCLHPGHDHA += 100;
		EELENPNCGLM.PIIEGNPOPJI_GetPoint = (EELENPNCGLM.ODCLHPGHDHA * EELENPNCGLM.FPEOGFMKMKJ) / 100;
		EELENPNCGLM.PIIEGNPOPJI_GetPoint *= EELENPNCGLM.FCLGIPFPIPH;
	}

	// // RVA: 0x18460BC Offset: 0x18460BC VA: 0x18460BC Slot: 73
	public override List<string> IJCPBPFEGDM_GetResourcesFilePathList(long JHNMKKNEENE)
	{
		if(!MNNNLDFNNCD(JHNMKKNEENE))
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
	public override void EMEPJNLHJHJ(int GJEADBKFAPA, int AKNELONELJK, bool GIKLNODJKFK, ref int APMGOLOPLFP, ref int FBBDNLAMPMH)
	{
		PHBACNMCMHG_EventCollection ev = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.LBDOLHGDIEB_GetDbSection(JOPOPMLFINI_QuestId) as PHBACNMCMHG_EventCollection;
		if(ev != null)
		{
			if(GIKLNODJKFK)
			{
				APMGOLOPLFP = ev.GKCBPNPEJJF[GJEADBKFAPA + AKNELONELJK - 1].KFCIJBLDHOK;
				FBBDNLAMPMH = ev.GKCBPNPEJJF[GJEADBKFAPA + AKNELONELJK - 1].JLEIHOEGMOP;
			}
			else
			{
				APMGOLOPLFP = ev.ADPFKHEMNBL[GJEADBKFAPA + AKNELONELJK - 1].KFCIJBLDHOK;
				FBBDNLAMPMH = ev.ADPFKHEMNBL[GJEADBKFAPA + AKNELONELJK - 1].JLEIHOEGMOP;
			}
		}
	}

	// // RVA: 0x1846784 Offset: 0x1846784 VA: 0x1846784 Slot: 76
	public override void MMIMJPNLKBK()
	{
		if(GFHKFKHBIGM)
		{
			PHBACNMCMHG_EventCollection ev = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.LBDOLHGDIEB_GetDbSection(JOPOPMLFINI_QuestId) as PHBACNMCMHG_EventCollection;
			if(ev != null)
			{
				FJGNPNFLHPH_EventCollection.JIALCLGJPKL save = CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave.MBAHCFLBDHN_EventCollection.FBCJICEPLED[ev.NGHKJOEDLIP.MOEKELIIDEO_SaveIdx];
				save.INLNJOGHLJE_Show = (int)(save.INLNJOGHLJE_Show & 0xfffffffb);
				GFHKFKHBIGM = false;
			}
		}
	}

	// // RVA: 0x1846A00 Offset: 0x1846A00 VA: 0x1846A00 Slot: 77
	public override string DBEMCLMPCFA_GetBannerText()
	{
		PHBACNMCMHG_EventCollection ev = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.LBDOLHGDIEB_GetDbSection(JOPOPMLFINI_QuestId) as PHBACNMCMHG_EventCollection;
		if(ev != null)
		{
			long t = NKGJPJPHLIF.HHCJCDFCLOB.IBLPICFDGOF_ServerRequester.FJDBNGEPKHL.KMEFBNBFJHI_GetServerTime();
			for(int i = 0; i < ev.LLCLJBEJOPM_BannerInfo.Count; i++)
			{
				if(t >= ev.LLCLJBEJOPM_BannerInfo[i].PDBPFJJCADD_OpenAt && 
					t < ev.LLCLJBEJOPM_BannerInfo[i].FDBNFFNFOND_CloseAt)
				{
					return ev.LLCLJBEJOPM_BannerInfo[i].KLMPFGOCBHC_BannerText;
				}
			}
		}
		return "";
	}

	// // RVA: 0x1846D7C Offset: 0x1846D7C VA: 0x1846D7C Slot: 78
	public override long OEGAJJANHGL()
	{
		PHBACNMCMHG_EventCollection ev = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.LBDOLHGDIEB_GetDbSection(JOPOPMLFINI_QuestId) as PHBACNMCMHG_EventCollection;
		if(ev != null)
		{
			return ev.NGHKJOEDLIP.JBFDHOIKAIK_InventoryEndDate;
		}
		return 0;
	}
}
