
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XeApp.Game;
using XeApp.Game.Common;
using XeSys;

[System.Obsolete("Use AMLGMLNGMFB_EventAprilFool", true)]
public class AMLGMLNGMFB { }
public class AMLGMLNGMFB_EventAprilFool : IKDICBBFBMI_EventBase
{
	private enum IGIPPPLKDJP
	{
		HJNNKCMLGFL_0_None = 0,
		KEBIIAMNKAJ_1_Return = 1,
	}

	private enum HODGPGLCPKM
	{
		HJNNKCMLGFL_0_None = 0,
		EBKLKECECIF = 1,
	}

	public enum MMKMPKEBLBF
	{
		HJNNKCMLGFL_0_None = 0,
		DMPOKMFNPKP = 1,
	}

	public enum ANFKADJMHPO
	{
		LOFOEPLBMID = 0,
		LGMPDPNEPGD = 1,
		BPJBNFNKGOJ = 2,
	}

	public class FOFMLBPMIIC
	{
		public int JJJNKGBCFMI_CurrentStep = 0; // 0x8
		public int AGKIABJHDDG_NextStep = 0; // 0xC
		public string FEMMDNIELFC_Desc = ""; // 0x10
		public int JNCPEGJGHOG_JacketId = 0; // 0x14
		public string NEDBBJDAFBH_MusicName = ""; // 0x18
	}

	public class OLDLIIKHDKD
	{
		public int CMJEGIEJNMD { get; private set; } // 0x8 IDFDLCAMDJH_bgs AGEDDPBMIKH_bgs LOLNKOKFIIE_bgs
		public MMKMPKEBLBF GODBCGAFMBE { get; private set; } // 0xC JLPCLKOHCAH_bgs GJHPPLPNIIF_bgs BLONDJKOIOG_bgs
		public int DDIOHHEGANL { get; private set; } // 0x10 GHPIIFOKMPM_bgs IIFKOIEJFKF_bgs DGIPAMDIKPD_bgs
		public int ELIFBFLFAFC { get; private set; } // 0x14 IGMJIGLNICF_bgs FIIPNJGPEFL_bgs EAPCKJIHFEA_bgs

		// RVA: 0xCE6E2C Offset: 0xCE6E2C VA: 0xCE6E2C
		public OLDLIIKHDKD(int IGHPMLOFGMO, int AGEGAHMDMPH, int KKFMFGPBHKM, int LGCKAMEEDGC)
		{
			CMJEGIEJNMD = IGHPMLOFGMO;
			GODBCGAFMBE = (MMKMPKEBLBF)AGEGAHMDMPH;
			DDIOHHEGANL = LGCKAMEEDGC;
			ELIFBFLFAFC = KKFMFGPBHKM;
		}
	}

	public class JPGMKBANFGF
	{
		private int FBGGEFFJJHB_xor = 0x13c7dd4; // 0x8
		private sbyte ALPDMEILILP_IsClearCrypted; // 0xC
		private int NBOLDNMPJFG_scoreCrypted; // 0x10
		private sbyte JAFNIDLINKN_IssecrenCommandCrypted; // 0x14

		public bool BCGLDMKODLC_IsClear { get { return ALPDMEILILP_IsClearCrypted == 115; } set { ALPDMEILILP_IsClearCrypted = (sbyte)(value ? 115 : 54); } } //0xCE7DC8 NNGALFPBDNA_bgs 0xCE8E40 JJBMOHCMALD_bgs
		public int KNIFCANOHOC_score { get { return NBOLDNMPJFG_scoreCrypted ^ FBGGEFFJJHB_xor; } set { NBOLDNMPJFG_scoreCrypted = value ^ FBGGEFFJJHB_xor; } } //0xCE7D00 EOJEPLIPOMJ_get_score 0xCE8E70 AEEMBPAEAAI_set_score
		public bool CHPIFIEEEEC_IsSecretCommand { get { return JAFNIDLINKN_IssecrenCommandCrypted == 115; } set { JAFNIDLINKN_IssecrenCommandCrypted = (sbyte)(value ? 115 : 54); } }// 0xCE7D20 FLHPOBEBLBH_bgs 0xCE8E80 LIJEMJDBNPD_bgs
	}

	public class IMFNPKNPDDP
	{
		private int FBGGEFFJJHB_xor; // 0x8
		private sbyte ALPDMEILILP_IsClearCrypted; // 0xC
		private int NBOLDNMPJFG_scoreCrypted; // 0x10
		private sbyte NLKIOJKEKNM_IsUseCommandScoreCrypted; // 0x14
		private int KGNDGJAOFJG_HighScoreCrypted; // 0x18
		private sbyte MNOIODAMMCC_IsUseCommandHighScoreCrypted; // 0x1C

		public bool BCGLDMKODLC_IsClear { get { return ALPDMEILILP_IsClearCrypted == 89; } set { ALPDMEILILP_IsClearCrypted = (sbyte)(value ? 89 : 51); } } //0xCE7E0C NNGALFPBDNA_bgs 0xCE7DDC JJBMOHCMALD_bgs
		public int KNIFCANOHOC_score { get { return NBOLDNMPJFG_scoreCrypted ^ FBGGEFFJJHB_xor; } set { NBOLDNMPJFG_scoreCrypted = value ^ FBGGEFFJJHB_xor; } } // 0xCE8DE4 EOJEPLIPOMJ_get_score 0xCE7D10 AEEMBPAEAAI_set_score
		public bool PIBCFBBLHBB_IsUseCommandScore { get { return NLKIOJKEKNM_IsUseCommandScoreCrypted == 89; } set { NLKIOJKEKNM_IsUseCommandScoreCrypted = (sbyte)(value ? 89 : 51); } } //0xCE8DF4 BLHCJKNODGF_bgs 0xCE7D34 ILCPMIBDKPB_bgs
		public int LGDLEHHOIEL_HighScore { get { return KGNDGJAOFJG_HighScoreCrypted ^ FBGGEFFJJHB_xor; } set { KGNDGJAOFJG_HighScoreCrypted = value ^ FBGGEFFJJHB_xor; } } //0xCE7DA4 OMFCCEBAODD_bgs 0xCE7D64 JGIJCMFGKEP_bgs
		public bool LNDLJBINJDE_IsUseCommandHighScore { get { return MNOIODAMMCC_IsUseCommandHighScoreCrypted == 89; } set { MNOIODAMMCC_IsUseCommandHighScoreCrypted = (sbyte)(value ? 89 : 51); } } //0xCE7DB4 HHNJLPDNDPN_bgs 0xCE7D74 CCOMADGCMEG_bgs

		// RVA: 0xCE1F20 Offset: 0xCE1F20 VA: 0xCE1F20
		public IMFNPKNPDDP()
		{
			FBGGEFFJJHB_xor = (int)(Utility.GetCurrentUnixTime() ^ 0x346293);
			KNIFCANOHOC_score = 0;
			BCGLDMKODLC_IsClear = false;
			LGDLEHHOIEL_HighScore = 0;
		}

		// RVA: 0xCE8E08 Offset: 0xCE8E08 VA: 0xCE8E08
		//private void KHEKNNFCAOI_Init(int KNEFBLHBDBG) { }
	}

	private const int GHJHJDIDCFA = 3;
	private List<KCGOMAFPGDD_EventAprilFool.EIEGCBJHGCP> NFMDLCBJOIB_SongCacheList = new List<KCGOMAFPGDD_EventAprilFool.EIEGCBJHGCP>(); // 0xE8
	private EECOJKDJIFG KBACNOCOANM_Ranking; // 0xEC
	public IMFNPKNPDDP MMICFFPMHIC = new IMFNPKNPDDP(); // 0xF0

	public override OHCAABOMEOF.KGOGMKMBCPP_EventType HIDHLFCBIDE_EventType { get { return OHCAABOMEOF.KGOGMKMBCPP_EventType.DAMDPLEBNCB_AprilFool;} }// 0xCE1CB0 DKHCGLCNKCD_bgs  Slot: 4

	// // RVA: 0xCE1CB8 Offset: 0xCE1CB8 VA: 0xCE1CB8 Slot: 5
	public override string IFKKBHPMALH()
	{
		DIHHCBACKGG_DbSection db = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.LBDOLHGDIEB_Find(JOPOPMLFINI_QuestName);
		if (db != null)
		{
			KCGOMAFPGDD_EventAprilFool dbAf = db as KCGOMAFPGDD_EventAprilFool;
			return dbAf.NGHKJOEDLIP_Settings.OCDMGOGMHGE_KeyPrefix;
		}
		return null;
	}

	// RVA: 0xCE1E40 Offset: 0xCE1E40 VA: 0xCE1E40
	public AMLGMLNGMFB_EventAprilFool(string _OPFGFINHFCE_name) : base(_OPFGFINHFCE_name)
    {
        return;
    }

	// // RVA: 0xCE1FE0 Offset: 0xCE1FE0 VA: 0xCE1FE0
	private List<int> DAFEPLPDCJD(long _JHNMKKNEENE_Time)
	{
		List<int> l = new List<int>();
		l.Clear();
		for(int i = 0; i < AGLILDLEFDK_Missions.Count; i++)
		{
			if(AGLILDLEFDK_Missions[i].HMOJCCPIPBP_TargetMusicType == 6)
			{
				if(AGLILDLEFDK_Missions[i].HBJJCDIMOPO_TargetMusicConditionId > 0)
				{
					l.Add(AGLILDLEFDK_Missions[i].HBJJCDIMOPO_TargetMusicConditionId);
				}
			}
		}
		List<FKMOKDCJFEN> l2 = FKMOKDCJFEN.KJHKBBBDBAL(JOPOPMLFINI_QuestName, true, -1);
		for(int i = 0; i < l2.Count; i++)
		{
			if(l2[i].DLAFBGPFEON > 0 && l2[i].CMCKNKKCNDK_status == FKMOKDCJFEN.ADCPCCNCOMD_Status.HIDGJCIFFNJ_1_Available/*1*/)
			{
				l.Remove(l2[i].DLAFBGPFEON);
			}
		}
		return l;
	}

	// // RVA: 0xCE224C Offset: 0xCE224C VA: 0xCE224C
	public int BMBELGEDKEG_GetFreeMusic(int _PPFNGGCBJKC_id)
	{
		DIHHCBACKGG_DbSection db = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.LBDOLHGDIEB_Find(JOPOPMLFINI_QuestName);
		if (db != null)
		{
			KCGOMAFPGDD_EventAprilFool dbAf = db as KCGOMAFPGDD_EventAprilFool;
			if(_PPFNGGCBJKC_id > 0)
			{
				if(_PPFNGGCBJKC_id <= dbAf.IJJHFGOIDOK_EventMusic.Count)
				{
					KCGOMAFPGDD_EventAprilFool.EIEGCBJHGCP data = dbAf.IJJHFGOIDOK_EventMusic[_PPFNGGCBJKC_id - 1];
					if(data.PLALNIIBLOF_en == 2)
					{
						return data.MPLGPBNJDJB_FreeMusicId;
					}
				}
			}
		}
		return 0;
	}

	// // RVA: 0xCE24AC Offset: 0xCE24AC VA: 0xCE24AC
	public int GOHABONFBDM(JGEOBNENMAH.HAJIFNABIFF OMNOFMEBLAD)
	{
		List<KCGOMAFPGDD_EventAprilFool.EIEGCBJHGCP> l = LEAGIGKFMPE_GenerateMusicList(false, OMNOFMEBLAD.NFFDIGEJHGL_ServerTime);
		MHDFCLCMDKO_Enemy.CJLENGHPIDH_EnemyInfo eInfo = Database.Instance.gameSetup.musicInfo.enemyInfo;
		for(int i = 0; i < l.Count; i++)
		{
			if(OMNOFMEBLAD.GHBPLHBNMBK_FreeMusicId == l[i].MPLGPBNJDJB_FreeMusicId)
			{
				if (eInfo.NJOPIPNGANO_CS == l[i].MLKFDMFDFCE_enemy_c_skill && eInfo.EDLACELKJIK_LiveSkill == l[i].DKOPDNHDLIA_enemy_l_skill)
					return l[i].PPFNGGCBJKC_id;
			}
		}
		return 0;
	}

	// // RVA: 0xCE266C Offset: 0xCE266C VA: 0xCE266C
	private List<KCGOMAFPGDD_EventAprilFool.EIEGCBJHGCP> LEAGIGKFMPE_GenerateMusicList(bool DHNFPAGENLN, long _JHNMKKNEENE_Time/* = -1*/)
	{
		DIHHCBACKGG_DbSection db = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.LBDOLHGDIEB_Find(JOPOPMLFINI_QuestName);
		if (db != null)
		{
			KCGOMAFPGDD_EventAprilFool dbAf = db as KCGOMAFPGDD_EventAprilFool;
			if (_JHNMKKNEENE_Time < 0)
				_JHNMKKNEENE_Time = NKGJPJPHLIF.HHCJCDFCLOB.IBLPICFDGOF_ServerRequester.FJDBNGEPKHL_Time.KMEFBNBFJHI_GetServerTime();
			List<int> l = null;
			if (!DHNFPAGENLN)
				l = DAFEPLPDCJD(_JHNMKKNEENE_Time);
			NFMDLCBJOIB_SongCacheList.Clear();
			for(int i = 0; i < dbAf.IJJHFGOIDOK_EventMusic.Count; i++)
			{
				KCGOMAFPGDD_EventAprilFool.EIEGCBJHGCP MABBBOEAPAA_p = dbAf.IJJHFGOIDOK_EventMusic[i];
				if (MABBBOEAPAA_p.PLALNIIBLOF_en == 2)
				{
					if (MABBBOEAPAA_p.MPLGPBNJDJB_FreeMusicId != 0)
					{
						if (l != null)
						{
							int idx = l.FindIndex((int _GHPLINIACBB_x) =>
							{
								//0xCE7E20
								return MABBBOEAPAA_p.PPFNGGCBJKC_id == _GHPLINIACBB_x;
							});
							if (idx > -1)
								continue;
						}
						if(MABBBOEAPAA_p.PDBPFJJCADD_open_at != 0 || MABBBOEAPAA_p.FDBNFFNFOND_close_at != 0)
						{
							if(_JHNMKKNEENE_Time >= MABBBOEAPAA_p.PDBPFJJCADD_open_at)
							{
								if(MABBBOEAPAA_p.FDBNFFNFOND_close_at >= _JHNMKKNEENE_Time)
									NFMDLCBJOIB_SongCacheList.Add(MABBBOEAPAA_p);
							}
						}
						else
						{
							NFMDLCBJOIB_SongCacheList.Add(MABBBOEAPAA_p);
						}
					}
				}
			}
			return NFMDLCBJOIB_SongCacheList;
		}
		return null;
	}

	// // RVA: 0xCE2BC4 Offset: 0xCE2BC4 VA: 0xCE2BC4
	public List<KCGOMAFPGDD_EventAprilFool.EIEGCBJHGCP> KOBMFPACBMB_GetCachedSongList()
	{
		if(NFMDLCBJOIB_SongCacheList.Count < 1)
		{
			return LEAGIGKFMPE_GenerateMusicList(false, -1);
		}
		return NFMDLCBJOIB_SongCacheList;
	}

	// // RVA: 0xCE2C68 Offset: 0xCE2C68 VA: 0xCE2C68
	public void BEFJOAGGAJD_ResetSongListCache()
	{
		NFMDLCBJOIB_SongCacheList.Clear();
	}

	// // RVA: 0xCE2CE0 Offset: 0xCE2CE0 VA: 0xCE2CE0 Slot: 7
	public override List<int> HEACCHAKMFG_GetMusicsList()
	{
		List<int> l = new List<int>();
		l.Clear();
		BEFJOAGGAJD_ResetSongListCache();
		List<KCGOMAFPGDD_EventAprilFool.EIEGCBJHGCP> l2 = KOBMFPACBMB_GetCachedSongList();
		if(l2 != null)
		{
			for(int i = 0; i < l2.Count; i++)
			{
				l.Add(l2[i].MPLGPBNJDJB_FreeMusicId);
			}
		}
		return l;
	}

	// // RVA: 0xCE2E54 Offset: 0xCE2E54 VA: 0xCE2E54 Slot: 9
	public override long HOOBCIIOCJD_GetSongEndTime(int _GHBPLHBNMBK_FreeMusicId)
	{
		List<KCGOMAFPGDD_EventAprilFool.EIEGCBJHGCP> l = KOBMFPACBMB_GetCachedSongList();
		if(l != null)
		{
			long time = NKGJPJPHLIF.HHCJCDFCLOB.IBLPICFDGOF_ServerRequester.FJDBNGEPKHL_Time.KMEFBNBFJHI_GetServerTime();
			for(int i = 0; i < l.Count; i++)
			{
				if(l[i].PDBPFJJCADD_open_at != 0 && l[i].FDBNFFNFOND_close_at != 0 && time >= l[i].PDBPFJJCADD_open_at && l[i].FDBNFFNFOND_close_at >= time)
				{
					if(l[i].MPLGPBNJDJB_FreeMusicId == _GHBPLHBNMBK_FreeMusicId)
					{
						return l[i].FDBNFFNFOND_close_at;
					}
				}
			}
		}
		return base.HOOBCIIOCJD_GetSongEndTime(_GHBPLHBNMBK_FreeMusicId);
	}

	// // RVA: 0xCE3154 Offset: 0xCE3154 VA: 0xCE3154 Slot: 10
	public override bool GIDDKGMPIOK_IsLimited(int _GHBPLHBNMBK_FreeMusicId)
	{
		List<KCGOMAFPGDD_EventAprilFool.EIEGCBJHGCP> l = KOBMFPACBMB_GetCachedSongList();
		if (l != null)
		{
			long time = NKGJPJPHLIF.HHCJCDFCLOB.IBLPICFDGOF_ServerRequester.FJDBNGEPKHL_Time.KMEFBNBFJHI_GetServerTime();
			for (int i = 0; i < l.Count; i++)
			{
				if (l[i].PDBPFJJCADD_open_at != 0 && l[i].FDBNFFNFOND_close_at != 0 && l[i].FDBNFFNFOND_close_at < DPJCPDKALGI_RankingEnd && time >= l[i].PDBPFJJCADD_open_at && l[i].FDBNFFNFOND_close_at >= time)
				{
					if (l[i].MPLGPBNJDJB_FreeMusicId == _GHBPLHBNMBK_FreeMusicId)
					{
						return true;
					}
				}
			}
		}
		return false;
	}

	// // RVA: 0xCE3474 Offset: 0xCE3474 VA: 0xCE3474 Slot: 28
	public override long FBGDBGKNKOD_GetCurrentPoint()
	{
		return 0;
	}

	// // RVA: 0xCE3480 Offset: 0xCE3480 VA: 0xCE3480 Slot: 30
	protected override bool JIHMLILFOPG_IsEventActive(long _JHNMKKNEENE_Time)
	{
		DIHHCBACKGG_DbSection db = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.LBDOLHGDIEB_Find(JOPOPMLFINI_QuestName);
		if(db != null)
		{
			KCGOMAFPGDD_EventAprilFool dbAf = db as KCGOMAFPGDD_EventAprilFool;
			GDIPLANPCEI g = IMMAOANGPNK.HHCJCDFCLOB.ACEFBFLFKFD_GetScheduleEventData(dbAf.JIKKNHIAEKG_BlockName, _JHNMKKNEENE_Time);
			if(g != null)
			{
				if(_JHNMKKNEENE_Time >= dbAf.NGHKJOEDLIP_Settings.BONDDBOFBND_RankingStart)
				{
					if (dbAf.NGHKJOEDLIP_Settings.KNLGKBBIBOH_RewardEnd2 >= _JHNMKKNEENE_Time)
						return true;
				}
			}
		}
		return false;
	}

	// // RVA: 0xCE368C Offset: 0xCE368C VA: 0xCE368C Slot: 31
	protected override bool IMCMNOPNGHO(long _JHNMKKNEENE_Time)
	{
		DIHHCBACKGG_DbSection db = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.LBDOLHGDIEB_Find(JOPOPMLFINI_QuestName);
		if (db != null)
		{
			KCGOMAFPGDD_EventAprilFool dbAf = db as KCGOMAFPGDD_EventAprilFool;
			FMFBNHLMHPL_EventAprilFool.LCFOEDLCCON save = CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_PlayerData.ILINBDKMAPM_EventAprilFool.FBCJICEPLED[dbAf.NGHKJOEDLIP_Settings.MOEKELIIDEO_SaveIdx];
			AGLILDLEFDK_Missions = dbAf.NNMPGOAGEOL_quests;
			OLDFFDMPEBM_Quests = save.NNMPGOAGEOL_quests;
			if (save.MPCAGEPEJJJ_Key != dbAf.NGHKJOEDLIP_Settings.OCGFKMHNEOF_name_for_api
				|| (!RuntimeSettings.CurrentSettings.UnlimitedEvent && save.EGBOHDFBAPB_closed_at < dbAf.NGHKJOEDLIP_Settings.BONDDBOFBND_RankingStart) // UMO : don't check date as event date are dynamically updated.
				|| (RuntimeSettings.CurrentSettings.UnlimitedEvent && (save.EGBOHDFBAPB_closed_at == 0 || save.NNMPGOAGEOL_quests.Count == 0 || save.NNMPGOAGEOL_quests[0].PPFNGGCBJKC_id == 0)) // UMO detect old save not initialized
			)
			{
				save.LHPDDGIJKNB_Reset();
				save.MPCAGEPEJJJ_Key = dbAf.NGHKJOEDLIP_Settings.OCGFKMHNEOF_name_for_api;
				save.EGBOHDFBAPB_closed_at = dbAf.NGHKJOEDLIP_Settings.IDDBFFBPNGI_RewardEnd;
				save.LGADCGFMLLD_step = 0;
				save.BEBJKJKBOGH_date = _JHNMKKNEENE_Time;
				KOMAHOAEMEK(true);
				OAFLKGCGEOA(false);
			}
			KOMAHOAEMEK(false);
			return true;
		}
		return false;
	}

	// // RVA: 0xCE3B0C Offset: 0xCE3B0C VA: 0xCE3B0C Slot: 40
	protected override void KKFLDCBHFJA(long _JHNMKKNEENE_Time)
	{
		DIHHCBACKGG_DbSection db = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.LBDOLHGDIEB_Find(JOPOPMLFINI_QuestName);
		if (db != null)
		{
			KCGOMAFPGDD_EventAprilFool dbAf = db as KCGOMAFPGDD_EventAprilFool;
			IBNKPMPFLGI_IsRankReward = false;
			DGCOMDILAKM_EventName = dbAf.NGHKJOEDLIP_Settings.OPFGFINHFCE_name;
			DOLJEDAAKNN_RankingName = dbAf.NGHKJOEDLIP_Settings.HEDAGCNPHGD_RankingName;
			GLIMIGNNGGB_RankingStart = dbAf.NGHKJOEDLIP_Settings.BONDDBOFBND_RankingStart;
			DPJCPDKALGI_RankingEnd = dbAf.NGHKJOEDLIP_Settings.HPNOGLIFJOP_RankingEnd;
			LOLAANGCGDO_RankingEnd2 = dbAf.NGHKJOEDLIP_Settings.LNFKGHNHJKE_RankingEnd2;
			JDDFILGNGFH_RewardStart = dbAf.NGHKJOEDLIP_Settings.JGMDAOACOJF_RewardStart;
			LJOHLEGGGMC_RewardEnd = dbAf.NGHKJOEDLIP_Settings.IDDBFFBPNGI_RewardEnd;
			EMEKFFHCHMH_RewardEnd2 = dbAf.NGHKJOEDLIP_Settings.KNLGKBBIBOH_RewardEnd2;
			PGIIDPEGGPI_EventId = dbAf.NGHKJOEDLIP_Settings.OBGBAOLONDD_UniqueId;
			FBHONHONKGD_MusicSelectDesc = MAICAKMIBEM("music_select_desc", "");
			GFIBLLLHMPD_StartAdventureId = 0;
			CAKEOPLJDAF_EndAdventureId = 0;
			LHAKGDAGEMM_EpBonusInfos.Clear();
			MNDFBBMNJGN_IsUsingTicket = false;
			LEPALMDKEOK_IsPointReward = false;
			GPHEKCNDDIK = true;
			PJLNJJIBFBN_HasExtremeDiff = dbAf.NGHKJOEDLIP_Settings.AHKPNPNOAMO_ExtreamOpen != 0;
			for(int i = 0; i < KPOMHFLKMKI_LastRankUpdateTime.Length; i++)
			{
				KPOMHFLKMKI_LastRankUpdateTime[i] = 0;
			}
		}
	}

	// // RVA: 0xCE3ED0 Offset: 0xCE3ED0 VA: 0xCE3ED0 Slot: 46
	protected override void PJDGDNJNCNM_UpdateStatusImpl(long _JHNMKKNEENE_Time)
	{
		NGOFCFJHOMI_Status = KGCNCBOKCBA.GNENJEHKMHD_EventStatus.HJNNKCMLGFL_0_None/*0*/;
		DIHHCBACKGG_DbSection db = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.LBDOLHGDIEB_Find(JOPOPMLFINI_QuestName);
		if (db != null)
		{
			KCGOMAFPGDD_EventAprilFool dbAf = db as KCGOMAFPGDD_EventAprilFool;
			NGOFCFJHOMI_Status = KGCNCBOKCBA.GNENJEHKMHD_EventStatus.FFLKPBPBPEP_1_NotStarted/*1*/;
			if (_JHNMKKNEENE_Time >= GLIMIGNNGGB_RankingStart)
			{
				NGOFCFJHOMI_Status = KGCNCBOKCBA.GNENJEHKMHD_EventStatus.MINDIGBAJFG_3_Ranking/*3*/;
				if(DPJCPDKALGI_RankingEnd < _JHNMKKNEENE_Time)
				{
					NGOFCFJHOMI_Status = KGCNCBOKCBA.GNENJEHKMHD_EventStatus.EMAMLLFAOJI_6_Counting/*6*/;
					if(_JHNMKKNEENE_Time >= dbAf.NGHKJOEDLIP_Settings.JGMDAOACOJF_RewardStart)
					{
						NGOFCFJHOMI_Status = KGCNCBOKCBA.GNENJEHKMHD_EventStatus.BCKENOKGLIJ_9_ResultRewardreceived/*9*/;
						if(_JHNMKKNEENE_Time >= dbAf.NGHKJOEDLIP_Settings.IDDBFFBPNGI_RewardEnd)
						{
							NGOFCFJHOMI_Status = KGCNCBOKCBA.GNENJEHKMHD_EventStatus.DOAENCHBAEO_11_Ended/*11*/;
							if(_JHNMKKNEENE_Time < dbAf.NGHKJOEDLIP_Settings.KNLGKBBIBOH_RewardEnd2)
								NGOFCFJHOMI_Status = KGCNCBOKCBA.GNENJEHKMHD_EventStatus.HINPDNKNAHO_10_Reward2/*10*/;
						}
					}
				}
			}
		}
	}

	// // RVA: 0xCE40BC Offset: 0xCE40BC VA: 0xCE40BC Slot: 27
	public override int HLOGNJNGDJO_GetHelpId(int _OIPCCBHIKIA_index/* = 0*/)
	{
		NGOFCFJHOMI_Status = KGCNCBOKCBA.GNENJEHKMHD_EventStatus.HJNNKCMLGFL_0_None/*0*/;
		DIHHCBACKGG_DbSection db = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.LBDOLHGDIEB_Find(JOPOPMLFINI_QuestName);
		if (db != null)
		{
			KCGOMAFPGDD_EventAprilFool dbAf = db as KCGOMAFPGDD_EventAprilFool;
			return dbAf.IHKIFGPICLG_HelpIds[_OIPCCBHIKIA_index];
		}
		return 0;
	}

	// // RVA: 0xCE4258 Offset: 0xCE4258 VA: 0xCE4258 Slot: 70
	public override void ADACMHAHHKC_PreSetupEventHome(IMCBBOAFION _BHFHGFKBOHH_OnSuccess, DJBHIFLHJLK _AOCANKOMKFG_OnError)
	{
		N.a.StartCoroutineWatched(NJIEIJJMAHK_Corotuine_PreSetupEventHome(_BHFHGFKBOHH_OnSuccess, _AOCANKOMKFG_OnError));
	}

	// [IteratorStateMachineAttribute] // RVA: 0x6BB91C Offset: 0x6BB91C VA: 0x6BB91C
	// // RVA: 0xCE42B0 Offset: 0xCE42B0 VA: 0xCE42B0
	private IEnumerator NJIEIJJMAHK_Corotuine_PreSetupEventHome(IMCBBOAFION _BHFHGFKBOHH_OnSuccess, DJBHIFLHJLK _AOCANKOMKFG_OnError)
	{
		//0xCE8904
		while (CIOECGOMILE.HHCJCDFCLOB.KONHMOLMOCI_IsSaving)
			yield return null;
		long time = NKGJPJPHLIF.HHCJCDFCLOB.IBLPICFDGOF_ServerRequester.FJDBNGEPKHL_Time.KMEFBNBFJHI_GetServerTime();
		DIHHCBACKGG_DbSection db = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.LBDOLHGDIEB_Find(JOPOPMLFINI_QuestName);
		if (db != null)
		{
			KCGOMAFPGDD_EventAprilFool dbAf = db as KCGOMAFPGDD_EventAprilFool;
			PJDGDNJNCNM_UpdateStatusImpl(time);
			FMFBNHLMHPL_EventAprilFool.LCFOEDLCCON save = CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_PlayerData.ILINBDKMAPM_EventAprilFool.FBCJICEPLED[dbAf.NGHKJOEDLIP_Settings.MOEKELIIDEO_SaveIdx];
			if(!save.IMFBCJOIJKJ_Entry)
			{
				CMPEJEHCOEI = true;
				save.IMFBCJOIJKJ_Entry = true;
			}
			_BHFHGFKBOHH_OnSuccess();
			yield return null;
		}
		else
		{
			NPNNPNAIONN_IsError = true;
			PLOOEECNHFB_IsDone = true;
			if (_AOCANKOMKFG_OnError != null)
				_AOCANKOMKFG_OnError();
		}
	}

	// // RVA: 0xCE4390 Offset: 0xCE4390 VA: 0xCE4390
	// private int APJDIPINLLK(List<int> HNLFPKNBOHE, int _PPFNGGCBJKC_id) { }

	// // RVA: 0xCE4488 Offset: 0xCE4488 VA: 0xCE4488 Slot: 33
	public override bool MPMKJNJGFEF_IsEntry()
	{
		return true;
	}

	// // RVA: 0xCE4490 Offset: 0xCE4490 VA: 0xCE4490 Slot: 69
	public override void HAAEJDGMICH(LBNLAENLPNK.JEKODBEDOMM_DetailType _INDDJNMPONH_type, IMCBBOAFION _BHFHGFKBOHH_OnSuccess, DJBHIFLHJLK _AOCANKOMKFG_OnError)
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

	// // RVA: 0xCE45B8 Offset: 0xCE45B8 VA: 0xCE45B8 Slot: 71
	public override int BAEPGOAMBDK(string _LJNAKDMILMC_key, int MNCOAGOKNAO)
	{
		NGOFCFJHOMI_Status = KGCNCBOKCBA.GNENJEHKMHD_EventStatus.HJNNKCMLGFL_0_None/*0*/;
		DIHHCBACKGG_DbSection db = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.LBDOLHGDIEB_Find(JOPOPMLFINI_QuestName);
		if (db != null)
		{
			KCGOMAFPGDD_EventAprilFool dbAf = db as KCGOMAFPGDD_EventAprilFool;
			return dbAf.LPJLEHAJADA_GetIntParam(_LJNAKDMILMC_key, MNCOAGOKNAO);
		}
		return MNCOAGOKNAO;
	}

	// // RVA: 0xCE4738 Offset: 0xCE4738 VA: 0xCE4738 Slot: 72
	public override string MAICAKMIBEM(string _LJNAKDMILMC_key, string MNCOAGOKNAO)
	{
		DIHHCBACKGG_DbSection dbBlock = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.LBDOLHGDIEB_Find(JOPOPMLFINI_QuestName);
		if(dbBlock != null)
		{
			return (dbBlock as KCGOMAFPGDD_EventAprilFool).EFEGBHACJAL_GetStringParam(_LJNAKDMILMC_key, MNCOAGOKNAO);
		}
		return MNCOAGOKNAO;
	}

	// // RVA: 0xCE48B8 Offset: 0xCE48B8 VA: 0xCE48B8 Slot: 38
	public override void EMEPJNLHJHJ(int GJEADBKFAPA, int _AKNELONELJK_difficulty, bool _GIKLNODJKFK_IsLine6, ref int APMGOLOPLFP, ref int FBBDNLAMPMH)
	{
		DIHHCBACKGG_DbSection dbBlock = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.LBDOLHGDIEB_Find(JOPOPMLFINI_QuestName);
		if (dbBlock != null)
		{
			KCGOMAFPGDD_EventAprilFool dbAf = dbBlock as KCGOMAFPGDD_EventAprilFool;
			APMGOLOPLFP = dbAf.ADPFKHEMNBL[GJEADBKFAPA + _AKNELONELJK_difficulty - 1].KFCIJBLDHOK_v1;
			FBBDNLAMPMH = dbAf.ADPFKHEMNBL[GJEADBKFAPA + _AKNELONELJK_difficulty - 1].JLEIHOEGMOP_v2;
		}
	}

	// // RVA: 0xCE4B1C Offset: 0xCE4B1C VA: 0xCE4B1C Slot: 60
	public override bool PIBDBIKJKLD_CanPickup()
	{
		DIHHCBACKGG_DbSection dbBlock = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.LBDOLHGDIEB_Find(JOPOPMLFINI_QuestName);
		if (dbBlock != null)
		{
			KCGOMAFPGDD_EventAprilFool dbAf = dbBlock as KCGOMAFPGDD_EventAprilFool;
			if (CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_PlayerData != null)
			{
				return dbAf.LPJLEHAJADA_GetIntParam("pickup_enable_rank", 6) <= CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_PlayerData.KCCLEHLLOFG_Common.KIECDDFNCAN_Level;
			}
		}
		return false;
	}

	// // RVA: 0xCE4D44 Offset: 0xCE4D44 VA: 0xCE4D44 Slot: 61
	public override bool EMNKNFNKPAD_SetIsPickup(bool _JKDJCFEBDHC_Enabled)
	{
		DIHHCBACKGG_DbSection dbBlock = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.LBDOLHGDIEB_Find(JOPOPMLFINI_QuestName);
		if (dbBlock != null)
		{
			KCGOMAFPGDD_EventAprilFool dbAf = dbBlock as KCGOMAFPGDD_EventAprilFool;
			CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_PlayerData.ILINBDKMAPM_EventAprilFool.FBCJICEPLED[dbAf.NGHKJOEDLIP_Settings.MOEKELIIDEO_SaveIdx].PPKAKKGCAOJ_IsPickup = _JKDJCFEBDHC_Enabled;
			return true;
		}
		return false;
	}

	// // RVA: 0xCE4FB0 Offset: 0xCE4FB0 VA: 0xCE4FB0 Slot: 62
	public override bool MPJIJMMOHDM_IsPickup()
	{
		DIHHCBACKGG_DbSection dbBlock = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.LBDOLHGDIEB_Find(JOPOPMLFINI_QuestName);
		if (dbBlock != null)
		{
			KCGOMAFPGDD_EventAprilFool dbAf = dbBlock as KCGOMAFPGDD_EventAprilFool;
			return CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_PlayerData.ILINBDKMAPM_EventAprilFool.FBCJICEPLED[dbAf.NGHKJOEDLIP_Settings.MOEKELIIDEO_SaveIdx].PPKAKKGCAOJ_IsPickup;
		}
		return false;
	}

	// // RVA: 0xCE520C Offset: 0xCE520C VA: 0xCE520C Slot: 64
	public override int IBFAJICMLGF_GetJacketRibbonType()
	{
		return BAEPGOAMBDK("jacket_ribbon_type", 0);
	}

	// // RVA: 0xCE5280 Offset: 0xCE5280 VA: 0xCE5280
	public int HLPEBPOPCPI_GetChangeMusicSelectUI()
	{
		return BAEPGOAMBDK("change_music_select_ui", 0);
	}

	// // RVA: 0xCE52F4 Offset: 0xCE52F4 VA: 0xCE52F4 Slot: 26
	public override bool KKFEDJNIAAG(long _JHNMKKNEENE_Time)
	{
		NGOFCFJHOMI_Status = KGCNCBOKCBA.GNENJEHKMHD_EventStatus.HJNNKCMLGFL_0_None/*0*/;
		DIHHCBACKGG_DbSection db = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.LBDOLHGDIEB_Find(JOPOPMLFINI_QuestName);
		if (db != null)
		{
			KCGOMAFPGDD_EventAprilFool dbAf = db as KCGOMAFPGDD_EventAprilFool;
			if(dbAf.NGHKJOEDLIP_Settings.OILIKPOBBGD == 1)
			{
				if (CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_PlayerData.ILINBDKMAPM_EventAprilFool.FBCJICEPLED[dbAf.NGHKJOEDLIP_Settings.MOEKELIIDEO_SaveIdx].CFKFIODHFNC_Act < 2)
					return false;
			}
		}
		return base.KKFEDJNIAAG(_JHNMKKNEENE_Time);
	}

	// // RVA: 0xCE5598 Offset: 0xCE5598 VA: 0xCE5598
	public void LEGMNFOCKGE(IMCBBOAFION _BHFHGFKBOHH_OnSuccess, DJBHIFLHJLK _AOCANKOMKFG_OnError)
	{
		N.a.StartCoroutineWatched(JCEFGGHMAGK_Co_ReceiveActivateItem(_BHFHGFKBOHH_OnSuccess, _AOCANKOMKFG_OnError));
	}

	// [IteratorStateMachineAttribute] // RVA: 0x6BB994 Offset: 0x6BB994 VA: 0x6BB994
	// // RVA: 0xCE55F0 Offset: 0xCE55F0 VA: 0xCE55F0
	private IEnumerator JCEFGGHMAGK_Co_ReceiveActivateItem(IMCBBOAFION _BHFHGFKBOHH_OnSuccess, DJBHIFLHJLK _AOCANKOMKFG_OnError)
	{
		FMFBNHLMHPL_EventAprilFool.LCFOEDLCCON NGHLIKFIIGI_SaveData; // 0x1C
		string HPHKCOMJELK; // 0x20
		int HLGAPELJDPA; // 0x24
		List<GJDFHLBONOL> CJHGIMICABA; // 0x28
		SakashoInventoryCriteria KGJIJEKKFDB; // 0x2C
		LGJOOFGOGCD_RequestInventories NMBJNEPMHOO; // 0x30

		//0xCE7F00
		DIHHCBACKGG_DbSection db = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.LBDOLHGDIEB_Find(JOPOPMLFINI_QuestName);
		if (db != null)
		{
			KCGOMAFPGDD_EventAprilFool dbAf = db as KCGOMAFPGDD_EventAprilFool;
			if(dbAf.NGHKJOEDLIP_Settings.OILIKPOBBGD == 1)
			{
				NGHLIKFIIGI_SaveData = CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_PlayerData.ILINBDKMAPM_EventAprilFool.FBCJICEPLED[dbAf.NGHKJOEDLIP_Settings.MOEKELIIDEO_SaveIdx];
				if(NGHLIKFIIGI_SaveData.CFKFIODHFNC_Act == 0)
				{
					HPHKCOMJELK = dbAf.EFEGBHACJAL_GetStringParam("activate_item_name", "");
					HLGAPELJDPA = dbAf.LPJLEHAJADA_GetIntParam("activate_item_value", 0);
					CJHGIMICABA = new List<GJDFHLBONOL>();
					KGJIJEKKFDB = new SakashoInventoryCriteria();
					KGJIJEKKFDB.OnlyUnreceived = true;
					int page = 1;
					while(true)
					{
						NMBJNEPMHOO = NKGJPJPHLIF.HHCJCDFCLOB.IBLPICFDGOF_ServerRequester.IFFNCAFNEAG_AddRequest(new LGJOOFGOGCD_RequestInventories());
						NMBJNEPMHOO.IGNIIEBMFIN_Page = page;
						NMBJNEPMHOO.MLPLGFLKKLI_Ipp = 30;
						NMBJNEPMHOO.IPKCADIAAPG_Criteria = KGJIJEKKFDB;
						while (!NMBJNEPMHOO.PLOOEECNHFB_IsDone)
							yield return null;
						if(NMBJNEPMHOO.NPNNPNAIONN_IsError)
						{
							_AOCANKOMKFG_OnError();
							yield break;
						}
						for(int i = 0; i < NMBJNEPMHOO.NFEAMMJIMPG_Result.PJJFEAHIPGL_inventories.Count; i++)
						{
							if(NMBJNEPMHOO.NFEAMMJIMPG_Result.PJJFEAHIPGL_inventories[i].HAAJGNCFNJM_item_name == HPHKCOMJELK)
							{
								if(NMBJNEPMHOO.NFEAMMJIMPG_Result.PJJFEAHIPGL_inventories[i].OCNINMIMHGC_item_value == HLGAPELJDPA)
								{
									CJHGIMICABA.Add(NMBJNEPMHOO.NFEAMMJIMPG_Result.PJJFEAHIPGL_inventories[i]);
								}
							}
						}
						if (NMBJNEPMHOO.NFEAMMJIMPG_Result.MDIBIIHAAPN_next_page == 0)
							break;
						page = NMBJNEPMHOO.NFEAMMJIMPG_Result.MDIBIIHAAPN_next_page;
					}
					if(CJHGIMICABA.Count != 0)
					{
						NGHLIKFIIGI_SaveData.CFKFIODHFNC_Act = 2;
						List<long> l = new List<long>();
						for(int i = 0; i < CJHGIMICABA.Count; i++)
						{
							l.Add(CJHGIMICABA[i].MDPJFPHOPCH_Id);
						}
						CIOECGOMILE.HHCJCDFCLOB.AIKJMHBDABF_SavePlayerData(_BHFHGFKBOHH_OnSuccess, _AOCANKOMKFG_OnError, l);
						yield break;
					}
					NGHLIKFIIGI_SaveData.CFKFIODHFNC_Act = 1;
				}
			}
		}
		_BHFHGFKBOHH_OnSuccess();
	}

	// // RVA: 0xCE56D0 Offset: 0xCE56D0 VA: 0xCE56D0
	public List<CEBFFLDKAEC_SecureInt> LANDONNJDEA()
	{
		NGOFCFJHOMI_Status = KGCNCBOKCBA.GNENJEHKMHD_EventStatus.HJNNKCMLGFL_0_None/*0*/;
		DIHHCBACKGG_DbSection db = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.LBDOLHGDIEB_Find(JOPOPMLFINI_QuestName);
		if (db != null)
		{
			KCGOMAFPGDD_EventAprilFool dbAf = db as KCGOMAFPGDD_EventAprilFool;
			return CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_PlayerData.ILINBDKMAPM_EventAprilFool.FBCJICEPLED[dbAf.NGHKJOEDLIP_Settings.MOEKELIIDEO_SaveIdx].AAJOOBMPOEP_Nsxq;
		}
		return null;
	}

	// // RVA: 0xCE5928 Offset: 0xCE5928 VA: 0xCE5928
	public void ALEPIOKNOCL()
	{
		List<CEBFFLDKAEC_SecureInt> l = LANDONNJDEA();
		l[0].DNJEJEANJGL_Value = 0;
	}

	// // RVA: 0xCE39F0 Offset: 0xCE39F0 VA: 0xCE39F0
	public void OAFLKGCGEOA(bool NLNNKIKIPBJ)
	{
		GameManager.Instance.localSave.EPJOACOONAC_GetSave().MCNEIJAOLNO_Select.AAFEFCNONGL_StepUpQuest.IAPNOPFIPAG_IsShowNextInfo = NLNNKIKIPBJ;
		GameManager.Instance.localSave.HJMKBCFJOOH_Save();
	}

	// // RVA: 0xCE59C0 Offset: 0xCE59C0 VA: 0xCE59C0 Slot: 21
	public override void CNPHACDBLMD(JGEOBNENMAH.HAJIFNABIFF OMNOFMEBLAD)
	{
		if(AGLILDLEFDK_Missions != null && OLDFFDMPEBM_Quests != null)
		{
			List<int> l = new List<int>();
			long time = NKGJPJPHLIF.HHCJCDFCLOB.IBLPICFDGOF_ServerRequester.FJDBNGEPKHL_Time.KMEFBNBFJHI_GetServerTime();
			bool b = false;
			if(time - GLIMIGNNGGB_RankingStart > 0)
			{
				if(time - DPJCPDKALGI_RankingEnd < 0)
				{
					b = true;
				}
			}
			int c = AGLILDLEFDK_Missions.Count;
			if (OLDFFDMPEBM_Quests.Count < c)
				c = OLDFFDMPEBM_Quests.Count;
			for(int i = 0; i < c; i++)
			{
				if(OLDFFDMPEBM_Quests[i].EALOBDHOCHP_stat == 1)
				{
					if(GBNDFCEDNMG.EIJIGDCMJLB(IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database, CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_PlayerData, AGLILDLEFDK_Missions[i], OMNOFMEBLAD, this, false))
					{
						BOHCAIIBPEJ(AGLILDLEFDK_Missions[i], OLDFFDMPEBM_Quests[i], OMNOFMEBLAD, this);
						if(b)
						{
							if(OLDFFDMPEBM_Quests[i].EALOBDHOCHP_stat == 2)
							{
								if(AGLILDLEFDK_Missions[i].HMOJCCPIPBP_TargetMusicType == 6)
								{
									for(int j = 0; j < c; j++)
									{
										if(AGLILDLEFDK_Missions[j].PPEGAKEIEGM_Enabled == 2)
										{
											if(AGLILDLEFDK_Missions[j].HHIBBHFHENH_LinkQuestId == AGLILDLEFDK_Missions[i].PPFNGGCBJKC_id)
											{
												l.Add(AGLILDLEFDK_Missions[j].PPFNGGCBJKC_id);
											}
										}
									}
									if (l.Count == 0)
										l.Add(-1);
								}
							}
						}
					}
				}
			}
			if(l.Count > 0)
			{
				ALEPIOKNOCL();
				List<CEBFFLDKAEC_SecureInt> l2 = LANDONNJDEA();
				if(l2 != null)
				{
					int m = Mathf.Min(l2.Count, l.Count);
					for(int i = 0; i < m; i++)
					{
						l2[i].DNJEJEANJGL_Value = l[i];
					}
				}
				OAFLKGCGEOA(true);
			}
		}
	}

	// // RVA: 0xCE6138 Offset: 0xCE6138 VA: 0xCE6138
	public List<FOFMLBPMIIC> KLJKKJLFPDF()
	{
		List<FOFMLBPMIIC> res = new List<FOFMLBPMIIC>();
		if(AGLILDLEFDK_Missions != null && OLDFFDMPEBM_Quests != null)
		{
			List<CEBFFLDKAEC_SecureInt> l = LANDONNJDEA();
            List<KCGOMAFPGDD_EventAprilFool.EIEGCBJHGCP> l2 = LEAGIGKFMPE_GenerateMusicList(true, -1);
            if (l != null && l2 != null)
			{
				for (int i = 0; i < l.Count; i++)
				{
					if(l[i].DNJEJEANJGL_Value != 0)
					{
						if(l[i].DNJEJEANJGL_Value < 0)
						{
							FOFMLBPMIIC f = new FOFMLBPMIIC();
							f.JJJNKGBCFMI_CurrentStep = -1;
							f.AGKIABJHDDG_NextStep = -1;
							f.FEMMDNIELFC_Desc = "";
							f.JNCPEGJGHOG_JacketId = 0;
							f.NEDBBJDAFBH_MusicName = "";
							res.Add(f);
							return res;
						}
						else
						{
							AKIIJBEJOEP PMPLBAOGLNC = AGLILDLEFDK_Missions[l[i].DNJEJEANJGL_Value - 1];
							IKCGAJKCPFN ik = OLDFFDMPEBM_Quests[l[i].DNJEJEANJGL_Value - 1];
							if(PMPLBAOGLNC.PPEGAKEIEGM_Enabled == 2)
							{
								if(ik.EALOBDHOCHP_stat == 1)
								{
									if(PMPLBAOGLNC.HHIBBHFHENH_LinkQuestId > 0)
									{
										if(PMPLBAOGLNC.HMOJCCPIPBP_TargetMusicType == 6)
										{
											KCGOMAFPGDD_EventAprilFool.EIEGCBJHGCP k = l2.Find((KCGOMAFPGDD_EventAprilFool.EIEGCBJHGCP JPAEDJJFFOI) =>
											{
												//0xCE7E54
												return JPAEDJJFFOI.PPFNGGCBJKC_id == PMPLBAOGLNC.HBJJCDIMOPO_TargetMusicConditionId;
											});
											if(k != null)
											{
												AKIIJBEJOEP PGDCFEEGJPE = AGLILDLEFDK_Missions[PMPLBAOGLNC.HHIBBHFHENH_LinkQuestId - 1];
												if(PGDCFEEGJPE.HMOJCCPIPBP_TargetMusicType == 6)
												{
													KCGOMAFPGDD_EventAprilFool.EIEGCBJHGCP k2 = l2.Find((KCGOMAFPGDD_EventAprilFool.EIEGCBJHGCP JPAEDJJFFOI) =>
													{
														//0xCE7EA8
														return JPAEDJJFFOI.PPFNGGCBJKC_id == PGDCFEEGJPE.HBJJCDIMOPO_TargetMusicConditionId;
													});
													if(k2 != null)
													{
														if(k2.LGADCGFMLLD_step >= 1 && k.LGADCGFMLLD_step >= 2)
														{
															FOFMLBPMIIC f = new FOFMLBPMIIC();
															IBJAKJJICBC ib = new IBJAKJJICBC();
															ib.KHEKNNFCAOI_Init(k.MPLGPBNJDJB_FreeMusicId, false, 0, 0, 0, false, false, false);
															f.JJJNKGBCFMI_CurrentStep = k2.LGADCGFMLLD_step;
															f.AGKIABJHDDG_NextStep = k.LGADCGFMLLD_step;
															f.FEMMDNIELFC_Desc = PMPLBAOGLNC.FEMMDNIELFC_Desc;
															f.JNCPEGJGHOG_JacketId = ib.JNCPEGJGHOG_JacketId;
															f.NEDBBJDAFBH_MusicName = ib.NEDBBJDAFBH_MusicName;
															res.Add(f);
														}
													}
												}
											}
										}
									}
								}
							}
						}
					}
				}
			}
		}
		return res;
	}

	// // RVA: 0xCE68E8 Offset: 0xCE68E8 VA: 0xCE68E8
	public OLDLIIKHDKD PBPJDMGEMAO(long _JHNMKKNEENE_Time)
	{
		DIHHCBACKGG_DbSection dbSection = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.LBDOLHGDIEB_Find(JOPOPMLFINI_QuestName);
		if (dbSection != null)
		{
			KCGOMAFPGDD_EventAprilFool dbAf = dbSection as KCGOMAFPGDD_EventAprilFool;
			if(dbAf.NGHKJOEDLIP_Settings.AMCPINEGNPG == 1 && AGLILDLEFDK_Missions != null)
			{
				if(_JHNMKKNEENE_Time < dbAf.NGHKJOEDLIP_Settings.HPNOGLIFJOP_RankingEnd)
				{
					FMFBNHLMHPL_EventAprilFool.LCFOEDLCCON save = CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_PlayerData.ILINBDKMAPM_EventAprilFool.FBCJICEPLED[dbAf.NGHKJOEDLIP_Settings.MOEKELIIDEO_SaveIdx];
					if(save.CFKFIODHFNC_Act > 1)
					{
						int c = AGLILDLEFDK_Missions.Count;
						if (OLDFFDMPEBM_Quests.Count < c)
							c = OLDFFDMPEBM_Quests.Count;
						int a = 0;
						for(int i = 0; i < c; i++)
						{
							if(OLDFFDMPEBM_Quests[i].EALOBDHOCHP_stat > 0)
							{
								if(AGLILDLEFDK_Missions[i].HDAMBOOCIAA_ClearType != dbAf.NGHKJOEDLIP_Settings.OFGDLGBFOOA)
								{
									a++;
									if (OLDFFDMPEBM_Quests[i].EALOBDHOCHP_stat > 2)
										c++;
								}
							}
						}
						OLDLIIKHDKD data = new OLDLIIKHDKD(dbAf.NGHKJOEDLIP_Settings.HBACKHIOIBG, dbAf.NGHKJOEDLIP_Settings.BMKDEHFGHFG, a, c);
						return data;
					}
				}
			}
		}
		return null;
	}

	// // RVA: 0xCE6E64 Offset: 0xCE6E64 VA: 0xCE6E64
	public FMFBNHLMHPL_EventAprilFool.LCFOEDLCCON NDNDIAFEBFJ()
	{
		DIHHCBACKGG_DbSection dbSection = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.LBDOLHGDIEB_Find(JOPOPMLFINI_QuestName);
		if (dbSection != null)
		{
			KCGOMAFPGDD_EventAprilFool dbAf = dbSection as KCGOMAFPGDD_EventAprilFool;
			return CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_PlayerData.ILINBDKMAPM_EventAprilFool.FBCJICEPLED[dbAf.NGHKJOEDLIP_Settings.MOEKELIIDEO_SaveIdx];
		}
		return null;
	}

	// // RVA: 0xCE70A8 Offset: 0xCE70A8 VA: 0xCE70A8 Slot: 73
	public override List<string> IJCPBPFEGDM_GetResourcesFilePathList(long _JHNMKKNEENE_Time)
	{
		DIHHCBACKGG_DbSection dbSection = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.LBDOLHGDIEB_Find(JOPOPMLFINI_QuestName);
		if(dbSection != null)
		{
			KCGOMAFPGDD_EventAprilFool dbAf = dbSection as KCGOMAFPGDD_EventAprilFool;
			if(NDIILFIFCDL_GetMinigameId() > 0)
			{
				if(MNNNLDFNNCD(_JHNMKKNEENE_Time))
				{
					List<int> l = HEACCHAKMFG_GetMusicsList();
					if(l.Count > 0)
					{
						KEODKEGFDLD_FreeMusicInfo fm = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.IBPAFKKEKNK_Music.NOBCLJIAMLC_GetFreeMusicData(l[0]);
						return SoundResource.CreateBgmFilePathList(IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.IBPAFKKEKNK_Music.IAJLOELFHKC_GetMusicInfo(fm.DLAEJOBELBH_MusicId).KKPAHLMJKIH_WavId);
					}
				}
			}
		}
		return null;
	}

	// // RVA: 0xCE746C Offset: 0xCE746C VA: 0xCE746C Slot: 74
	public override int EDNMFMBLCGF_GetWavId()
	{
		List<int> l = HEACCHAKMFG_GetMusicsList();
		if (l.Count == 0)
			return 0;
		return IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.IBPAFKKEKNK_Music.IAJLOELFHKC_GetMusicInfo(IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.IBPAFKKEKNK_Music.NOBCLJIAMLC_GetFreeMusicData(l[0]).DLAEJOBELBH_MusicId).KKPAHLMJKIH_WavId;
	}

	// // RVA: 0xCE73F8 Offset: 0xCE73F8 VA: 0xCE73F8
	public int NDIILFIFCDL_GetMinigameId()
	{
		return BAEPGOAMBDK("mini_game_id", 0);
	}

	// // RVA: 0xCE7634 Offset: 0xCE7634 VA: 0xCE7634
	public void LPFLADBKPNL(JPGMKBANFGF OMNOFMEBLAD, bool _IKGLAFOHGDO_TestOnly)
	{
		DIHHCBACKGG_DbSection dbSection = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.LBDOLHGDIEB_Find(JOPOPMLFINI_QuestName);
		if (dbSection != null)
		{
			KCGOMAFPGDD_EventAprilFool dbAf = dbSection as KCGOMAFPGDD_EventAprilFool;
			FMFBNHLMHPL_EventAprilFool.LCFOEDLCCON save = CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_PlayerData.ILINBDKMAPM_EventAprilFool.FBCJICEPLED[dbAf.NGHKJOEDLIP_Settings.MOEKELIIDEO_SaveIdx];
			if(_IKGLAFOHGDO_TestOnly)
			{
				FMFBNHLMHPL_EventAprilFool.LCFOEDLCCON data = new FMFBNHLMHPL_EventAprilFool.LCFOEDLCCON();
				data.LHPDDGIJKNB_Reset();
				data.ODDIHGPONFL_Copy(save);
				save = data;
			}
			ILDKBCLAFPB.AKKDKBOBKGH_AprilFool.OEAIOIHGMIH localSave = GameManager.Instance.localSave.EPJOACOONAC_GetSave().ICFDECCGKIL_AprilFool.MNKOCOODFKH_MiniGameShooting;
			if (_IKGLAFOHGDO_TestOnly)
			{
				ILDKBCLAFPB.AKKDKBOBKGH_AprilFool.OEAIOIHGMIH data = new ILDKBCLAFPB.AKKDKBOBKGH_AprilFool.OEAIOIHGMIH();
				data.ODDIHGPONFL_Copy(localSave);
				localSave = data;
			}
			MMICFFPMHIC.KNIFCANOHOC_score = OMNOFMEBLAD.KNIFCANOHOC_score;
			MMICFFPMHIC.PIBCFBBLHBB_IsUseCommandScore = OMNOFMEBLAD.CHPIFIEEEEC_IsSecretCommand;
			if(localSave.LJKLECGFIEN_GetHighScore() < OMNOFMEBLAD.KNIFCANOHOC_score)
			{
				MMICFFPMHIC.LGDLEHHOIEL_HighScore = OMNOFMEBLAD.KNIFCANOHOC_score;
				MMICFFPMHIC.LNDLJBINJDE_IsUseCommandHighScore = OMNOFMEBLAD.CHPIFIEEEEC_IsSecretCommand;
			}
			else
			{
				MMICFFPMHIC.LGDLEHHOIEL_HighScore = localSave.LJKLECGFIEN_GetHighScore();
				MMICFFPMHIC.LNDLJBINJDE_IsUseCommandHighScore = localSave.PFBGBGLGBLA_GetIsUseCommand();
			}
			localSave.BIEBAEDGDIA_SetHighScore(MMICFFPMHIC.LGDLEHHOIEL_HighScore);
			localSave.JBCCMOKKCPA_SetIsUseCommand(MMICFFPMHIC.LNDLJBINJDE_IsUseCommandHighScore);
			MMICFFPMHIC.BCGLDMKODLC_IsClear = OMNOFMEBLAD.BCGLDMKODLC_IsClear;
			if(!save.KBAHNBKMFDL_is_minigame_clear)
			{
				save.KBAHNBKMFDL_is_minigame_clear = MMICFFPMHIC.BCGLDMKODLC_IsClear;
			}
			else
			{
				save.KBAHNBKMFDL_is_minigame_clear = true;
			}
			if(!_IKGLAFOHGDO_TestOnly)
			{
				if (MMICFFPMHIC.BCGLDMKODLC_IsClear)
					HEFIKPAHCIA_UpdateMission(GBNDFCEDNMG.CJDGJFINBFH_ClearType.JNPNFMCPJJN_49_AprilFoolClear/*49*/);
				GameManager.Instance.localSave.HJMKBCFJOOH_Save();
			}
		}
	}
}
