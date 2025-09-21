
using System.Collections.Generic;
using UnityEngine;
using XeApp.Game.Common;

public class FOCPLKMMCAL
{
	public List<IELJJAAJAOE> ACNDIGLMCAA = new List<IELJJAAJAOE>(); // 0x8
	public List<IELJJAAJAOE> HHMHOAKGBHF = new List<IELJJAAJAOE>(); // 0xC
	public List<IELJJAAJAOE> DCELMKFJHPG = new List<IELJJAAJAOE>(); // 0x10
	public int NMDKKAAOIOI_BaseUnionCredit; // 0x14
	public int MJKFDDKLLFP_DropUnionCredit; // 0x18
	public int PLMBDFGGBAJ; // 0x1C
	public int MMMKNPEMBIL; // 0x20
	public int MNJGODHNPNO; // 0x24
	public int NGDDIIDJFNG; // 0x28
	public int LKGONGDLJBH; // 0x2C
	public int HGHMMDOEGEF_ExpBonus; // 0x30
	public int CBCIFACJGHI_Exp; // 0x34
	public int MKEPHNGLHDL; // 0x38
	public int HBAJPMDOMPL; // 0x3C
	public int FOIPBBCHBIB; // 0x40
	public int PMPBDEJMHOJ_Level; // 0x44
	public int FFDBCEDKMGN_PrevPoint; // 0x48
	public int MMLPAMGJEOD_NewPoint; // 0x4C
	public int PENICOGGNLF_ScoreRank; // 0x50
	public int CFNCNCBEPED; // 0x54
	public bool EDDMMPBELBM; // 0x58
	private bool DAKKOLCGFCN; // 0x59
	public int[] FFDDBFEIJKI = new int[10]; // 0x5C
	private bool HCPKKNBPHNN = true; // 0x60
	public int FCLGIPFPIPH_DashBonus = 1; // 0x64
	public int HIEBJGOKEID_ItemId; // 0x68
	public int GIPMPIMJHLE; // 0x6C
	public int ACMMDAHKCIF; // 0x70
	public bool GNAMCOJKEFE; // 0x74
	public int INKMIAAMIEO_EventRareDropDenom = 10000; // 0x78
	public int BCCJLLJMPAA_EventRareDropDenomRand; // 0x7C
	public int LFGNFNDDLJH_TicketCount = 1; // 0x80
	public static string[] PKFJIIJJMGL = new string[5] {
		"Easy", "Normal", "Hard", "VeryHard", "Extreme"
	}; // 0x0
	public static string[] LKMFBMPKEGN = new string[5] {
		"Easy+", "Normal+", "Hard+", "VeryHard+", "Extreme+"
	}; // 0x4
	public string NKGFGDGFGFM_SessionId = ""; // 0x84
	public JKNGJFOBADP JANMJPOKLFL_InventoryUtil = new JKNGJFOBADP(); // 0x88
	public AIPOFGJGPKI_CampaignDiva.KBLBMGDILAI HMMFHMHENAO; // 0x8C

	//public List<int> PPBHHLGPMBK { get; } 0x13E8850 GHMCBPAFMNO
	public List<int> IONINNDIAFO { get { return JANMJPOKLFL_InventoryUtil.IONINNDIAFO; } } //0x13E8874 IICAOCOECKE

	//// RVA: 0x13E8898 Offset: 0x13E8898 VA: 0x13E8898
	public bool MDPFLKOIJFN(JGEOBNENMAH.HAJIFNABIFF OMNOFMEBLAD, EAJCBFGKKFA_FriendInfo IPGFALGDLHN_FriendInfo)
	{
		if(IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.GDEKCOOBLMA_System.LPJLEHAJADA("disable_split_raredrop", 0) != 1)
		{
			HCPKKNBPHNN = false;
		}
		EONOEHOKBEB_Music music = JGEOBNENMAH.DLOBJHGIBJE_GetMusicInfo(OMNOFMEBLAD, true);
		if(music != null)
		{
			KLBKPANJCPL_Score k = JGEOBNENMAH.KFFCMNELJJB_GetMusicScore(music, OMNOFMEBLAD.AKNELONELJK_difficulty, OMNOFMEBLAD.LFGNLKKFOCD_IsLine6);
			if(k != null)
			{
				if(OMNOFMEBLAD.GHBPLHBNMBK_FreeMusicId < 1)
				{
					if(OMNOFMEBLAD.KLCIIHKFPPO_StoryMusicId > 0)
					{
						DJNPIGEFPMF_StoryMusicInfo storyMusicInfo = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.IBPAFKKEKNK_Music.FLMLJIKBIMJ_GetStoryMusicData(OMNOFMEBLAD.KLCIIHKFPPO_StoryMusicId);
						PENICOGGNLF_ScoreRank = storyMusicInfo.COGKJBAFBKN_ByDiff[0].DLPBHJALHCK_GetScoreRank(OMNOFMEBLAD.KNIFCANOHOC_score);
						return BEEAKFJAPOB(OMNOFMEBLAD, music, true);
					}
				}
				else
				{
					KEODKEGFDLD_FreeMusicInfo freeMusicInfo = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.IBPAFKKEKNK_Music.NOBCLJIAMLC_GetFreeMusicData(OMNOFMEBLAD.GHBPLHBNMBK_FreeMusicId);
					PENICOGGNLF_ScoreRank = freeMusicInfo.EMJCHPDJHEI(OMNOFMEBLAD.LFGNLKKFOCD_IsLine6, OMNOFMEBLAD.AKNELONELJK_difficulty).DLPBHJALHCK_GetScoreRank(OMNOFMEBLAD.KNIFCANOHOC_score);
					if(OMNOFMEBLAD.JPJMALBLKDI_Tutorial == 0)
					{
						BDKANJGDMPK_GetBaseUnionCredit(k.ANAJIAENLNB_Level, true, OMNOFMEBLAD.LFGNLKKFOCD_IsLine6);
					}
					HKEFOCFIKIL(OMNOFMEBLAD, music, true);
					LDNMDBMFIIK_UpdateHighScore(OMNOFMEBLAD, music, true);
					ILDLMKGBKIL(OMNOFMEBLAD, music, true);
					if (!BEEAKFJAPOB(OMNOFMEBLAD, music, true))
						return false;
					EMLKKEHCKMI(OMNOFMEBLAD, music, true);
					int sceneId = 0;
					int numBoard = 0;
					if(IPGFALGDLHN_FriendInfo != null && IPGFALGDLHN_FriendInfo.KHGKPKDBMOH_GetAssistScene() != null)
					{
						sceneId = IPGFALGDLHN_FriendInfo.KHGKPKDBMOH_GetAssistScene().BCCHOBPJJKE_SceneId;
						numBoard = IPGFALGDLHN_FriendInfo.KHGKPKDBMOH_GetAssistScene().JPIPENJGGDD_NumBoard;
					}
					if(OMNOFMEBLAD.MNNHHJBBICA_GameEventType == 6)
					{
						// L268
						KPJHLACKGJF_EventMission evM = JEPBIIJDGEF_EventInfo.HHCJCDFCLOB.MKBJOOAILBB_GetEventByStatus(KGCNCBOKCBA.GNENJEHKMHD_EventStatus.EMAMLLFAOJI_Counting_6, false) as KPJHLACKGJF_EventMission;
						if(evM != null)
						{
							evM.FCLGOCBGPJF(OMNOFMEBLAD, ACMMDAHKCIF, FCLGIPFPIPH_DashBonus, LFGNFNDDLJH_TicketCount, sceneId, numBoard, true);
						}
					}
					else if(OMNOFMEBLAD.MNNHHJBBICA_GameEventType == 1)
					{
						// L207
						HJNNLPIGHLM_EventCollection evColl = JEPBIIJDGEF_EventInfo.HHCJCDFCLOB.MKBJOOAILBB_GetEventByStatus(KGCNCBOKCBA.GNENJEHKMHD_EventStatus.EMAMLLFAOJI_Counting_6, false) as HJNNLPIGHLM_EventCollection;
						if(evColl != null)
						{
							evColl.NGIPMNLALAA(ENCNIGKPEFB(), FCLGIPFPIPH_DashBonus, sceneId, numBoard, OMNOFMEBLAD.AKNELONELJK_difficulty);
						}
					}
					else if (OMNOFMEBLAD.MNNHHJBBICA_GameEventType == 3)
					{
						// L237
						HAEDCCLHEMN_EventBattle evBattle = JEPBIIJDGEF_EventInfo.HHCJCDFCLOB.MKBJOOAILBB_GetEventByStatus(KGCNCBOKCBA.GNENJEHKMHD_EventStatus.EMAMLLFAOJI_Counting_6, false) as HAEDCCLHEMN_EventBattle;
						if(evBattle != null)
						{
							evBattle.FCLGOCBGPJF(OMNOFMEBLAD, FCLGIPFPIPH_DashBonus, LFGNFNDDLJH_TicketCount, sceneId, numBoard, true);
						}
					}
					else if (OMNOFMEBLAD.MNNHHJBBICA_GameEventType == 14)
					{
						MANPIONIGNO_EventGoDiva evGoDiva = JEPBIIJDGEF_EventInfo.HHCJCDFCLOB.MKBJOOAILBB_GetEventByStatus(KGCNCBOKCBA.GNENJEHKMHD_EventStatus.EMAMLLFAOJI_Counting_6, false) as MANPIONIGNO_EventGoDiva;
						if(evGoDiva != null)
						{
							evGoDiva.FCLGOCBGPJF(OMNOFMEBLAD, FCLGIPFPIPH_DashBonus, LFGNFNDDLJH_TicketCount, sceneId, numBoard, true);
						}
					}
				}
				return true;
			}
		}
		return false;
	}

	//// RVA: 0x13EF978 Offset: 0x13EF978 VA: 0x13EF978
	public bool HNNPBABEPBP(JGEOBNENMAH.HAJIFNABIFF OMNOFMEBLAD, EAJCBFGKKFA_FriendInfo IPGFALGDLHN_FriendInfo)
	{
		EONOEHOKBEB_Music mData = JGEOBNENMAH.DLOBJHGIBJE_GetMusicInfo(OMNOFMEBLAD, true);
		if (mData == null)
			return false;
		KLBKPANJCPL_Score score = JGEOBNENMAH.KFFCMNELJJB_GetMusicScore(mData, OMNOFMEBLAD.AKNELONELJK_difficulty, OMNOFMEBLAD.LFGNLKKFOCD_IsLine6);
		if (score == null)
			return false;
		JANMJPOKLFL_InventoryUtil.JCHLONCMPAJ();
		if(OMNOFMEBLAD.GHBPLHBNMBK_FreeMusicId < 1)
		{
			if (OMNOFMEBLAD.KLCIIHKFPPO_StoryMusicId < 1)
				return true;
			if (OMNOFMEBLAD.JPJMALBLKDI_Tutorial == 0)
			{
				ILLPDLODANB.MOFIPNGNNPA(ILLPDLODANB.LOEGALDKHPL.LBKOGDGCFCM/*41*/, 2, false);
			}
			KJAFCPAFDBK(OMNOFMEBLAD, mData);
			int prevUc = CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_PlayerData.KCCLEHLLOFG_Common.NFHLDFJIBKI_have_uc;
			if (!BEEAKFJAPOB(OMNOFMEBLAD, mData, false))
				return false;
			MJKFDDKLLFP_DropUnionCredit = CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_PlayerData.KCCLEHLLOFG_Common.NFHLDFJIBKI_have_uc - prevUc;
			return true;
		}
		if (OMNOFMEBLAD.JPJMALBLKDI_Tutorial == 0)
		{
			ILLPDLODANB.MOFIPNGNNPA(ILLPDLODANB.LOEGALDKHPL.BDJBKMFEHHC/*40*/, 2, false);
		}
		if(HMJONPNKLFA(OMNOFMEBLAD))
		{
			ILLPDLODANB.MOFIPNGNNPA(ILLPDLODANB.LOEGALDKHPL.NEMNEDBLJEM/*51*/, 2, false);
		}
		if(OMNOFMEBLAD.JPJMALBLKDI_Tutorial == 0)
		{
			BDKANJGDMPK_GetBaseUnionCredit(score.ANAJIAENLNB_Level, false, OMNOFMEBLAD.LFGNLKKFOCD_IsLine6);
		}
		HKEFOCFIKIL(OMNOFMEBLAD, mData, false);
		LDNMDBMFIIK_UpdateHighScore(OMNOFMEBLAD, mData, false);
		ILDLMKGBKIL(OMNOFMEBLAD, mData, false);
		{
			int prevUc = CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_PlayerData.KCCLEHLLOFG_Common.NFHLDFJIBKI_have_uc;
			if (!BEEAKFJAPOB(OMNOFMEBLAD, mData, false))
				return false;
			MJKFDDKLLFP_DropUnionCredit = CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_PlayerData.KCCLEHLLOFG_Common.NFHLDFJIBKI_have_uc - prevUc;
		}
		EMLKKEHCKMI(OMNOFMEBLAD, mData, false);
		int fsceneId = 0;
		int c = 0;
		if(IPGFALGDLHN_FriendInfo != null)
		{
			if(IPGFALGDLHN_FriendInfo.KHGKPKDBMOH_GetAssistScene() != null)
			{
				fsceneId = IPGFALGDLHN_FriendInfo.KHGKPKDBMOH_GetAssistScene().BCCHOBPJJKE_SceneId;
				c = IPGFALGDLHN_FriendInfo.KHGKPKDBMOH_GetAssistScene().JPIPENJGGDD_NumBoard;
			}
		}
		switch(OMNOFMEBLAD.MNNHHJBBICA_GameEventType)
		{
			case 4:
			case 5:
				break;
			case 1:
				{
					HJNNLPIGHLM_EventCollection evColl = JEPBIIJDGEF_EventInfo.HHCJCDFCLOB.MKBJOOAILBB_GetEventByStatus(KGCNCBOKCBA.GNENJEHKMHD_EventStatus.EMAMLLFAOJI_Counting_6, false) as HJNNLPIGHLM_EventCollection;
					if(evColl != null)
					{
						FFDBCEDKMGN_PrevPoint = (int)evColl.FBGDBGKNKOD_GetCurrentPoint();
						evColl.FCLGOCBGPJF(OMNOFMEBLAD, JANMJPOKLFL_InventoryUtil, FCLGIPFPIPH_DashBonus, fsceneId, c);
					}
				}
				break;
			case 2:
				{
					MHAPMOLCPKM_EventQuest ev = JEPBIIJDGEF_EventInfo.HHCJCDFCLOB.MKBJOOAILBB_GetEventByStatus(KGCNCBOKCBA.GNENJEHKMHD_EventStatus.EMAMLLFAOJI_Counting_6, false) as MHAPMOLCPKM_EventQuest;
					if(ev != null)
					{
						ev.OAIBHKLKFKB(OMNOFMEBLAD, FCLGIPFPIPH_DashBonus, LFGNFNDDLJH_TicketCount, fsceneId, c);
					}
				}
				break;
			case 3:
				{
					HAEDCCLHEMN_EventBattle ev = JEPBIIJDGEF_EventInfo.HHCJCDFCLOB.MKBJOOAILBB_GetEventByStatus(KGCNCBOKCBA.GNENJEHKMHD_EventStatus.EMAMLLFAOJI_Counting_6, false) as HAEDCCLHEMN_EventBattle;
					if(ev != null)
					{
						FFDBCEDKMGN_PrevPoint = (int)ev.FBGDBGKNKOD_GetCurrentPoint();
						ev.FCLGOCBGPJF(OMNOFMEBLAD, FCLGIPFPIPH_DashBonus, LFGNFNDDLJH_TicketCount, fsceneId, c, false);
						MMLPAMGJEOD_NewPoint = (int)ev.FBGDBGKNKOD_GetCurrentPoint();
					}
				}
				break;
			case 6:
				{
					KPJHLACKGJF_EventMission ev = JEPBIIJDGEF_EventInfo.HHCJCDFCLOB.MKBJOOAILBB_GetEventByStatus(KGCNCBOKCBA.GNENJEHKMHD_EventStatus.EMAMLLFAOJI_Counting_6, false) as KPJHLACKGJF_EventMission;
					if(ev != null)
					{
						FFDBCEDKMGN_PrevPoint = (int)ev.FBGDBGKNKOD_GetCurrentPoint();
						ev.FCLGOCBGPJF(OMNOFMEBLAD, ACMMDAHKCIF, FCLGIPFPIPH_DashBonus, LFGNFNDDLJH_TicketCount, fsceneId, c, false);
						MMLPAMGJEOD_NewPoint = ev.FHPEAPEANAI.AHOKAPCGJMA_TotalPoint;
					}
				}
				break;
			case 14:
				{
					MANPIONIGNO_EventGoDiva ev = JEPBIIJDGEF_EventInfo.HHCJCDFCLOB.MKBJOOAILBB_GetEventByStatus(KGCNCBOKCBA.GNENJEHKMHD_EventStatus.EMAMLLFAOJI_Counting_6, false) as MANPIONIGNO_EventGoDiva;
					FFDBCEDKMGN_PrevPoint = (int)ev.FBGDBGKNKOD_GetCurrentPoint();
					ev.FCLGOCBGPJF(OMNOFMEBLAD, FCLGIPFPIPH_DashBonus, LFGNFNDDLJH_TicketCount, fsceneId, c, false);
					MMLPAMGJEOD_NewPoint = (int)ev.FBGDBGKNKOD_GetCurrentPoint();
				}
				break;
			default:
				break;
		}
		GDIKFPFDJKH(OMNOFMEBLAD, mData);
		LKDINNAPACD(OMNOFMEBLAD, mData);
		if(CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_PlayerData != null && CIOECGOMILE.HHCJCDFCLOB.MNJHBCIIHED_PrevServerData != null)
		{
			CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_PlayerData.KCCLEHLLOFG_Common.PACHOCGKCDB_ResetClSt();
			CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_PlayerData.KCCLEHLLOFG_Common.MKIKFKBMIPE(OMNOFMEBLAD.GHBPLHBNMBK_FreeMusicId, OMNOFMEBLAD.AKNELONELJK_difficulty);
			JDDGGJCGOPA_RecordMusic.EHFMCGGNPIJ_MusicInfo prevMusic = CIOECGOMILE.HHCJCDFCLOB.MNJHBCIIHED_PrevServerData.LCKMBHDMPIP_RecordMusic.FAMANJGJANN_FreeMusicInfo[OMNOFMEBLAD.GHBPLHBNMBK_FreeMusicId - 1];
			JDDGGJCGOPA_RecordMusic.EHFMCGGNPIJ_MusicInfo newMusic = CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_PlayerData.LCKMBHDMPIP_RecordMusic.FAMANJGJANN_FreeMusicInfo[OMNOFMEBLAD.GHBPLHBNMBK_FreeMusicId - 1];
			if(OMNOFMEBLAD.MNNHHJBBICA_GameEventType == 6 || OMNOFMEBLAD.MNNHHJBBICA_GameEventType == 0)
			{
				if(prevMusic.JNLKJCDFFMM_clear[OMNOFMEBLAD.AKNELONELJK_difficulty] == 0)
				{
					if(newMusic.JNLKJCDFFMM_clear[OMNOFMEBLAD.AKNELONELJK_difficulty] == 1)
					{
						CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_PlayerData.KCCLEHLLOFG_Common.GHKOOOHLHDC(LastGameUnlockStatus.TypeBit.LN_First_4);
					}
				}
				if (prevMusic.DPPCFFFNBGA_ClearL6[OMNOFMEBLAD.AKNELONELJK_difficulty] == 0)
				{
					if (newMusic.DPPCFFFNBGA_ClearL6[OMNOFMEBLAD.AKNELONELJK_difficulty] == 1)
					{
						CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_PlayerData.KCCLEHLLOFG_Common.GHKOOOHLHDC(LastGameUnlockStatus.TypeBit.LN_First_6);
					}
				}
				if(prevMusic.JNLKJCDFFMM_clear[1] > 0)
				{
					CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_PlayerData.KCCLEHLLOFG_Common.GHKOOOHLHDC(LastGameUnlockStatus.TypeBit.DF_NORMAL_4);
				}
				if (prevMusic.JNLKJCDFFMM_clear[2] > 0)
				{
					CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_PlayerData.KCCLEHLLOFG_Common.GHKOOOHLHDC(LastGameUnlockStatus.TypeBit.DF_HARD_4);
				}
				if (prevMusic.JNLKJCDFFMM_clear[3] > 0)
				{
					CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_PlayerData.KCCLEHLLOFG_Common.GHKOOOHLHDC(LastGameUnlockStatus.TypeBit.DF_VERY_HARD_4);
				}
				if (prevMusic.DPPCFFFNBGA_ClearL6[2] > 0)
				{
					CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_PlayerData.KCCLEHLLOFG_Common.GHKOOOHLHDC(LastGameUnlockStatus.TypeBit.DF_HARD_6);
				}
				if (prevMusic.DPPCFFFNBGA_ClearL6[3] > 0)
				{
					CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_PlayerData.KCCLEHLLOFG_Common.GHKOOOHLHDC(LastGameUnlockStatus.TypeBit.DF_VERY_HARD_6);
				}
				if (prevMusic.JNLKJCDFFMM_clear[4] > 0)
				{
					CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_PlayerData.KCCLEHLLOFG_Common.GHKOOOHLHDC(LastGameUnlockStatus.TypeBit.DF_EXTREME_4);
				}
				HighScoreRating r = new HighScoreRating();
				r.CalcUtaRate(CIOECGOMILE.HHCJCDFCLOB.MNJHBCIIHED_PrevServerData.MHEAEGMIKIE_PublicStatus.AEIADFODLMC_HsRating);
				if(IBJAKJJICBC.KGJJCAKCMLO(r.rateTotal))
				{
					CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_PlayerData.KCCLEHLLOFG_Common.GHKOOOHLHDC(LastGameUnlockStatus.TypeBit.UL_LINE_6);
				}
			}
			if(!OMNOFMEBLAD.PMCGHPOGLGM_IsSkip)
			{
				KEODKEGFDLD_FreeMusicInfo fData = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.IBPAFKKEKNK_Music.NOBCLJIAMLC_GetFreeMusicData(OMNOFMEBLAD.GHBPLHBNMBK_FreeMusicId);
				int prevScore = OMNOFMEBLAD.LFGNLKKFOCD_IsLine6 ? prevMusic.AHDKMPFDKPE_GetScoreL6_ForDiff(OMNOFMEBLAD.AKNELONELJK_difficulty) : prevMusic.BDCAICINCKK_GetScoreForDiff(OMNOFMEBLAD.AKNELONELJK_difficulty);
				ADDHLABEFKH d = fData.EMJCHPDJHEI(OMNOFMEBLAD.LFGNLKKFOCD_IsLine6, OMNOFMEBLAD.AKNELONELJK_difficulty);
				if (d.DLPBHJALHCK_GetScoreRank(prevScore) < 4 && d.DLPBHJALHCK_GetScoreRank(newMusic.ODEHJGPDFCL_Score) == 4)
				{
					CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_PlayerData.KCCLEHLLOFG_Common.GHKOOOHLHDC(OMNOFMEBLAD.LFGNLKKFOCD_IsLine6 ? LastGameUnlockStatus.TypeBit.LIVE_SKIP_First_6 : LastGameUnlockStatus.TypeBit.LIVE_SKIP_First_4);
				}
			}
		}
		return true;
	}

	//// RVA: 0x13E9200 Offset: 0x13E9200 VA: 0x13E9200
	private void BDKANJGDMPK_GetBaseUnionCredit(int _ANAJIAENLNB_Level, bool JCCBGECHIEI, bool _GIKLNODJKFK_IsLine6)
	{
		NMDKKAAOIOI_BaseUnionCredit = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.HNMMJINNHII_Game.GFODAIJMBAH_GetUc(_ANAJIAENLNB_Level, _GIKLNODJKFK_IsLine6);
		if (JCCBGECHIEI)
			return;
		CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_PlayerData.KCCLEHLLOFG_Common.ENEMPFLFEHP_AddUc(NMDKKAAOIOI_BaseUnionCredit);
		CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_PlayerData.OEKEIGFAIGN_Counter.BDLNMOIOMHK_Total.EJJAPFPJLHP_AddUc(NMDKKAAOIOI_BaseUnionCredit);
	}

	//// RVA: 0x13E9420 Offset: 0x13E9420 VA: 0x13E9420
	private void HKEFOCFIKIL(JGEOBNENMAH.HAJIFNABIFF OMNOFMEBLAD, EONOEHOKBEB_Music EPMMNEFADAP_MusicInfo, bool JCCBGECHIEI)
	{
		PENICOGGNLF_ScoreRank = 0;
		if(OMNOFMEBLAD.GHBPLHBNMBK_FreeMusicId > 0)
		{
			KEODKEGFDLD_FreeMusicInfo mdata = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.IBPAFKKEKNK_Music.NOBCLJIAMLC_GetFreeMusicData(OMNOFMEBLAD.GHBPLHBNMBK_FreeMusicId);
			HDNKOFNBCEO_RewardInfo rinfo = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.IBPAFKKEKNK_Music.NEJKJJPIGKD_GetRewardInfo(mdata, OMNOFMEBLAD.AKNELONELJK_difficulty, OMNOFMEBLAD.LFGNLKKFOCD_IsLine6);
			JDDGGJCGOPA_RecordMusic.EHFMCGGNPIJ_MusicInfo rmusic = null;
			HLEBAINCOME_EventScore eventScore = null;
			if (OMNOFMEBLAD.MNNHHJBBICA_GameEventType == 4)
			{
				eventScore = JEPBIIJDGEF_EventInfo.HHCJCDFCLOB.AJLEDCKMFLP_GetEventScore(KGCNCBOKCBA.GNENJEHKMHD_EventStatus.EMAMLLFAOJI_Counting_6) as HLEBAINCOME_EventScore;
				rmusic = eventScore.JIPPHOKGLIH(false).KJAFPNIFPGP();
			}
			else
			{
				rmusic = CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_PlayerData.LCKMBHDMPIP_RecordMusic.FAMANJGJANN_FreeMusicInfo[OMNOFMEBLAD.GHBPLHBNMBK_FreeMusicId - 1];
			}
			rmusic.ODEHJGPDFCL_Score = OMNOFMEBLAD.KNIFCANOHOC_score;
			rmusic.ECLDABOLHLM_ExcellentScore = OMNOFMEBLAD.EACPIDGGPPO_ExcellentScore;
			rmusic.PDNJGJNGPNJ_MaxCombo = OMNOFMEBLAD.NLKEBAOBJCM_combo;
			rmusic.ANDJNPEINGI_TeamLuck = OMNOFMEBLAD.MJBODMOLOBC_luck;
			rmusic.ABFNAEKEGOB_ComboRank = OMNOFMEBLAD.LCOHGOIDMDF_ComboRank;
			if(OMNOFMEBLAD.JPJMALBLKDI_Tutorial < 1)
			{
				if(JCCBGECHIEI)
				{
					ADDHLABEFKH a = mdata.EMJCHPDJHEI(OMNOFMEBLAD.LFGNLKKFOCD_IsLine6, OMNOFMEBLAD.AKNELONELJK_difficulty);
					PENICOGGNLF_ScoreRank = a.DLPBHJALHCK_GetScoreRank(OMNOFMEBLAD.KNIFCANOHOC_score);
				}
				else
				{
					int f = 1;
					if(OMNOFMEBLAD.PMCGHPOGLGM_IsSkip)
					{
						f = OMNOFMEBLAD.KAIPAEILJHO_TicketCount;
						if (f < 2)
							f = 1;
					}
					bool b = (OMNOFMEBLAD.MNNHHJBBICA_GameEventType | 1) == 3;
					for(int i = 0; i < f; i++)
					{
						int clearCount = 0;
						if(!b)
						{
							List<int> clear;
							List<int> combo;
							List<sbyte> comboRank;
							if (!OMNOFMEBLAD.LFGNLKKFOCD_IsLine6)
							{
								clear = rmusic.JNLKJCDFFMM_clear;
								combo = rmusic.NLKEBAOBJCM_combo;
								comboRank = rmusic.LAMCCNAKIOJ_ComboRank;
								if (!OMNOFMEBLAD.PMCGHPOGLGM_IsSkip)
								{
									if (rmusic.BDCAICINCKK_GetScoreForDiff(OMNOFMEBLAD.AKNELONELJK_difficulty) < OMNOFMEBLAD.KNIFCANOHOC_score)
										rmusic.ECKFCIHPHGJ_SetScore_ForDiff(OMNOFMEBLAD.AKNELONELJK_difficulty, OMNOFMEBLAD.KNIFCANOHOC_score);
								}
							}
							else
							{
								clear = rmusic.DPPCFFFNBGA_ClearL6;
								combo = rmusic.DNIGPFPHJAK_ComboL6;
								comboRank = rmusic.EEECMKPLPNL_ComboRankL6;
								if (!OMNOFMEBLAD.PMCGHPOGLGM_IsSkip)
								{
									if (rmusic.AHDKMPFDKPE_GetScoreL6_ForDiff(OMNOFMEBLAD.AKNELONELJK_difficulty) < OMNOFMEBLAD.KNIFCANOHOC_score)
										rmusic.AAELOPLDBPF_SetScoreL6_ForDiff(OMNOFMEBLAD.AKNELONELJK_difficulty, OMNOFMEBLAD.KNIFCANOHOC_score);
								}
							}
							if(clear[OMNOFMEBLAD.AKNELONELJK_difficulty] < 99999)
								clear[OMNOFMEBLAD.AKNELONELJK_difficulty]++;
							clearCount = clear[OMNOFMEBLAD.AKNELONELJK_difficulty];
							if (combo[OMNOFMEBLAD.AKNELONELJK_difficulty] < OMNOFMEBLAD.NLKEBAOBJCM_combo)
								combo[OMNOFMEBLAD.AKNELONELJK_difficulty] = OMNOFMEBLAD.NLKEBAOBJCM_combo;
							if (comboRank[OMNOFMEBLAD.AKNELONELJK_difficulty] < OMNOFMEBLAD.LCOHGOIDMDF_ComboRank)
								comboRank[OMNOFMEBLAD.AKNELONELJK_difficulty] = (sbyte)OMNOFMEBLAD.LCOHGOIDMDF_ComboRank;
						}
						ADDHLABEFKH a = mdata.EMJCHPDJHEI(OMNOFMEBLAD.LFGNLKKFOCD_IsLine6, OMNOFMEBLAD.AKNELONELJK_difficulty);
						PENICOGGNLF_ScoreRank = a.DLPBHJALHCK_GetScoreRank(OMNOFMEBLAD.KNIFCANOHOC_score);
						clearCount = rinfo.MEBHFJPMCIF(clearCount);
						DAKKOLCGFCN = true;
						if(!b && !GNAMCOJKEFE)
						{
							List<int> l = new List<int>();
							List<byte> rScore;
							List<byte> rClear;
							List<byte> rCombo;
							string[] s;
							if (!OMNOFMEBLAD.LFGNLKKFOCD_IsLine6)
							{
								rScore = rmusic.JDIDBMEMKBC_RewardScore;
								rClear = rmusic.HNDPLCDMOJF_RewardClear;
								rCombo = rmusic.AGGFHNMMGMN_RewardCombo;
								s = PKFJIIJJMGL;
							}
							else
							{
								rScore = rmusic.DKIIINIEKHP_RewardScoreL6;
								rClear = rmusic.LGBKKDOLOFP_RewardClearL6;
								rCombo = rmusic.JNNIOJIDNKM_RewardComboL6;
								s = LKMFBMPKEGN;
							}
							string sDiff = s[OMNOFMEBLAD.AKNELONELJK_difficulty];
							for(int j = 1; j < 5; j++)
							{
								if(rScore[OMNOFMEBLAD.AKNELONELJK_difficulty] < j && j <= PENICOGGNLF_ScoreRank)
								{
									string[] s_ = new string[5];
									s_[0] = mdata.GHBPLHBNMBK_FreeMusicId.ToString();
									s_[1] = ":";
									s_[2] = sDiff;
									s_[3] = ":Score:";
									s_[4] = j.ToString();
									JANMJPOKLFL_InventoryUtil.FEGDNPIEKJC(OAGBCBBHMPF.COIIJOEKBDH.EMAFECNMGDA/*5*/, string.Concat(s_));
									if(KALFMENHPFE(OMNOFMEBLAD, 0, 0, rinfo.FKNBLDPIPMC_GetGlobalId(j + 3), rinfo.KAINPNMMAEK(j + 3)))
									{
										rScore[OMNOFMEBLAD.AKNELONELJK_difficulty] = (byte)j;
										EKLNMHFCAOI.FKGCBLHOOCL_Category cat = EKLNMHFCAOI.BKHFLDMOGBD_GetItemCategory(rinfo.FKNBLDPIPMC_GetGlobalId(j + 3));
										if(cat == EKLNMHFCAOI.FKGCBLHOOCL_Category.PJDEOPMBGKJ_PaidVC)
										{
											l.Add(JDDGGJCGOPA_RecordMusic.IEFAHENNHAH(OMNOFMEBLAD.LFGNLKKFOCD_IsLine6, OMNOFMEBLAD.AKNELONELJK_difficulty, j + 3));
										}
									}
								}
							}
							for(int j = 1; j < 5; j++)
							{
								if(rCombo[OMNOFMEBLAD.AKNELONELJK_difficulty] < j && j <= a.CCFAAPPKILD_GetRankCombo(OMNOFMEBLAD.NLKEBAOBJCM_combo))
								{
									string[] s_ = new string[5];
									s_[0] = mdata.GHBPLHBNMBK_FreeMusicId.ToString();
									s_[1] = ":";
									s_[2] = sDiff;
									s_[3] = ":Combo:";
									s_[4] = j.ToString();
									JANMJPOKLFL_InventoryUtil.FEGDNPIEKJC(OAGBCBBHMPF.COIIJOEKBDH.EMAFECNMGDA/*5*/, string.Concat(s_));
									if (KALFMENHPFE(OMNOFMEBLAD, 0, 0, rinfo.FKNBLDPIPMC_GetGlobalId(j + 7), rinfo.KAINPNMMAEK(j + 7)))
									{
										rCombo[OMNOFMEBLAD.AKNELONELJK_difficulty] = (byte)j;
										EKLNMHFCAOI.FKGCBLHOOCL_Category cat = EKLNMHFCAOI.BKHFLDMOGBD_GetItemCategory(rinfo.FKNBLDPIPMC_GetGlobalId(j + 7));
										if (cat == EKLNMHFCAOI.FKGCBLHOOCL_Category.PJDEOPMBGKJ_PaidVC)
										{
											l.Add(JDDGGJCGOPA_RecordMusic.IEFAHENNHAH(OMNOFMEBLAD.LFGNLKKFOCD_IsLine6, OMNOFMEBLAD.AKNELONELJK_difficulty, j + 7));
										}
									}
								}
							}
							for (int j = 1; j < 5; j++)
							{
								if (rClear[OMNOFMEBLAD.AKNELONELJK_difficulty] < j && j <= clearCount)
								{
									string[] s_ = new string[5];
									s_[0] = mdata.GHBPLHBNMBK_FreeMusicId.ToString();
									s_[1] = ":";
									s_[2] = sDiff;
									s_[3] = ":ClearCount:";
									s_[4] = j.ToString();
									JANMJPOKLFL_InventoryUtil.FEGDNPIEKJC(OAGBCBBHMPF.COIIJOEKBDH.EMAFECNMGDA/*5*/, string.Concat(s_));
									if (KALFMENHPFE(OMNOFMEBLAD, 0, 0, rinfo.FKNBLDPIPMC_GetGlobalId(j - 1), rinfo.KAINPNMMAEK(j - 1)))
									{
										rClear[OMNOFMEBLAD.AKNELONELJK_difficulty] = (byte)j;
										EKLNMHFCAOI.FKGCBLHOOCL_Category cat = EKLNMHFCAOI.BKHFLDMOGBD_GetItemCategory(rinfo.FKNBLDPIPMC_GetGlobalId(j - 1));
										if (cat == EKLNMHFCAOI.FKGCBLHOOCL_Category.PJDEOPMBGKJ_PaidVC)
										{
											l.Add(JDDGGJCGOPA_RecordMusic.IEFAHENNHAH(OMNOFMEBLAD.LFGNLKKFOCD_IsLine6, OMNOFMEBLAD.AKNELONELJK_difficulty, j - 1));
										}
									}
								}
							}
							if(eventScore == null)
							{
								if(!OMNOFMEBLAD.PMCGHPOGLGM_IsSkip)
								{
									int scoreMusic = CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_PlayerData.FLBPFBFKBFC_FreeScoreMax.BDCAICINCKK_GetScoreMusic(OMNOFMEBLAD.GHBPLHBNMBK_FreeMusicId);
									bool b2 = false;
									for(int j = 0; j < 5; j++)
									{
										int score = rmusic.BDCAICINCKK_GetScoreForDiff(OMNOFMEBLAD.AKNELONELJK_difficulty);
										int scoreL6 = rmusic.AHDKMPFDKPE_GetScoreL6_ForDiff(OMNOFMEBLAD.AKNELONELJK_difficulty);
										int tmpScore = scoreMusic;
										if (scoreMusic < score)
											tmpScore = score;
										b2 |= scoreMusic < score;
										scoreMusic = tmpScore;
										if (tmpScore < scoreL6)
											scoreMusic = scoreL6;
										b2 |= tmpScore < scoreL6;
									}
									if(b2)
									{
										CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_PlayerData.FLBPFBFKBFC_FreeScoreMax.POIKGADFLHF_SetPreciseScoreForMusic(OMNOFMEBLAD.GHBPLHBNMBK_FreeMusicId, scoreMusic, NKGJPJPHLIF.HHCJCDFCLOB.IBLPICFDGOF_ServerRequester.FJDBNGEPKHL_Time.KMEFBNBFJHI_GetServerTime());
									}
								}
								rmusic.IFGGJEPHIAN();
								if (l.Count > 0)
								{
									rmusic.BKJPGJJAODB = l;
									EDDMMPBELBM = true;
								}
								DAKKOLCGFCN = true;
							}
							else
							{
                                FEHINJKHDAP_EventScore.ALGDNCMJHGN d = eventScore.JIPPHOKGLIH(false);
                                d.IOONPJENLOJ(rmusic);
								int aa = 0;
								for(int j = 0; j < 5; j++)
								{
									if(aa < rmusic.BDCAICINCKK_GetScoreForDiff(i))
										aa = rmusic.BDCAICINCKK_GetScoreForDiff(i);
									if(aa < rmusic.AHDKMPFDKPE_GetScoreL6_ForDiff(i))
										aa = rmusic.AHDKMPFDKPE_GetScoreL6_ForDiff(i);
								}
								if(d.DNBFMLBNAEE_Point < aa)
								{
									d.DNBFMLBNAEE_Point = aa;
									d.NFIOKIBPJCJ_uptime = NKGJPJPHLIF.HHCJCDFCLOB.IBLPICFDGOF_ServerRequester.FJDBNGEPKHL_Time.KMEFBNBFJHI_GetServerTime();
								}
							}
						}
						else if(OMNOFMEBLAD.MNNHHJBBICA_GameEventType == 2)
						{
							MHAPMOLCPKM_EventQuest ev = JEPBIIJDGEF_EventInfo.HHCJCDFCLOB.MKBJOOAILBB_GetEventByStatus(KGCNCBOKCBA.GNENJEHKMHD_EventStatus.EMAMLLFAOJI_Counting_6, false) as MHAPMOLCPKM_EventQuest;
							OFNLIBDEIFA_EventQuest.HGCEGAAJFBC d = ev.JIPPHOKGLIH(OMNOFMEBLAD.GHBPLHBNMBK_FreeMusicId, false);
							if(d != null)
							{
								if(d.KNIFCANOHOC_score[OMNOFMEBLAD.AKNELONELJK_difficulty] < OMNOFMEBLAD.KNIFCANOHOC_score)
								{
									d.KNIFCANOHOC_score[OMNOFMEBLAD.AKNELONELJK_difficulty] = OMNOFMEBLAD.KNIFCANOHOC_score;
								}
								if(d.NLKEBAOBJCM_combo[OMNOFMEBLAD.AKNELONELJK_difficulty] < OMNOFMEBLAD.NLKEBAOBJCM_combo)
								{
									d.NLKEBAOBJCM_combo[OMNOFMEBLAD.AKNELONELJK_difficulty] = OMNOFMEBLAD.NLKEBAOBJCM_combo;
								}
								if(d.LAMCCNAKIOJ_ComboRank[OMNOFMEBLAD.AKNELONELJK_difficulty] < OMNOFMEBLAD.LCOHGOIDMDF_ComboRank)
								{
									d.LAMCCNAKIOJ_ComboRank[OMNOFMEBLAD.AKNELONELJK_difficulty] = (sbyte)OMNOFMEBLAD.LCOHGOIDMDF_ComboRank;
								}
								if(d.JNLKJCDFFMM_clear[OMNOFMEBLAD.AKNELONELJK_difficulty] < 999999999)
								{
									d.JNLKJCDFFMM_clear[OMNOFMEBLAD.AKNELONELJK_difficulty]++;
								}
								d.GOIKCKHMBDL_FreeMusicId = OMNOFMEBLAD.GHBPLHBNMBK_FreeMusicId;
							}
						}
						else if (OMNOFMEBLAD.MNNHHJBBICA_GameEventType == 3)
						{
							HAEDCCLHEMN_EventBattle ev = JEPBIIJDGEF_EventInfo.HHCJCDFCLOB.MKBJOOAILBB_GetEventByStatus(KGCNCBOKCBA.GNENJEHKMHD_EventStatus.EMAMLLFAOJI_Counting_6, false) as HAEDCCLHEMN_EventBattle;
							if(ev != null)
							{
								CCPKHBECNLH_EventBattle.AIFGBKMMJGL d = ev.JIPPHOKGLIH_GetMusicSaveData(OMNOFMEBLAD.GHBPLHBNMBK_FreeMusicId, false);
								if(!OMNOFMEBLAD.LFGNLKKFOCD_IsLine6)
								{
									if(!OMNOFMEBLAD.PMCGHPOGLGM_IsSkip)
									{
										if(d.BDCAICINCKK_GetScoreForDiff(OMNOFMEBLAD.AKNELONELJK_difficulty) < OMNOFMEBLAD.KNIFCANOHOC_score)
										{
											d.ECKFCIHPHGJ_SetScoreForDiff(OMNOFMEBLAD.AKNELONELJK_difficulty, OMNOFMEBLAD.KNIFCANOHOC_score);
										}
									}
									if(d.NLKEBAOBJCM_combo[OMNOFMEBLAD.AKNELONELJK_difficulty] < OMNOFMEBLAD.NLKEBAOBJCM_combo)
									{
										d.NLKEBAOBJCM_combo[OMNOFMEBLAD.AKNELONELJK_difficulty] = OMNOFMEBLAD.NLKEBAOBJCM_combo;
									}
									if(d.LAMCCNAKIOJ_ComboRank[OMNOFMEBLAD.AKNELONELJK_difficulty] < OMNOFMEBLAD.LCOHGOIDMDF_ComboRank)
									{
										d.LAMCCNAKIOJ_ComboRank[OMNOFMEBLAD.AKNELONELJK_difficulty] = (sbyte)OMNOFMEBLAD.LCOHGOIDMDF_ComboRank;
									}
									if(d.JNLKJCDFFMM_clear[OMNOFMEBLAD.AKNELONELJK_difficulty] < 999999999)
									{
										d.JNLKJCDFFMM_clear[OMNOFMEBLAD.AKNELONELJK_difficulty]++;
									}
								}
								else
								{
									if(!OMNOFMEBLAD.PMCGHPOGLGM_IsSkip)
									{
										if(d.AHDKMPFDKPE_GetScoreForDiffL6(OMNOFMEBLAD.AKNELONELJK_difficulty) < OMNOFMEBLAD.KNIFCANOHOC_score)
										{
											d.AAELOPLDBPF_SetScoreForDiffL6(OMNOFMEBLAD.AKNELONELJK_difficulty, OMNOFMEBLAD.KNIFCANOHOC_score);
										}
									}
									if(d.DNIGPFPHJAK_ComboL6[OMNOFMEBLAD.AKNELONELJK_difficulty] < OMNOFMEBLAD.NLKEBAOBJCM_combo)
									{
										d.DNIGPFPHJAK_ComboL6[OMNOFMEBLAD.AKNELONELJK_difficulty] = OMNOFMEBLAD.NLKEBAOBJCM_combo;
									}
									if(d.EEECMKPLPNL_ComboRankL6[OMNOFMEBLAD.AKNELONELJK_difficulty] < OMNOFMEBLAD.LCOHGOIDMDF_ComboRank)
									{
										d.EEECMKPLPNL_ComboRankL6[OMNOFMEBLAD.AKNELONELJK_difficulty] = (sbyte)OMNOFMEBLAD.LCOHGOIDMDF_ComboRank;
									}
									if(d.DPPCFFFNBGA_ClearL6[OMNOFMEBLAD.AKNELONELJK_difficulty] < 999999999)
									{
										d.DPPCFFFNBGA_ClearL6[OMNOFMEBLAD.AKNELONELJK_difficulty]++;
									}
								}
								d.GOIKCKHMBDL_FreeMusicId = OMNOFMEBLAD.GHBPLHBNMBK_FreeMusicId;
								d.OFJHABJNGOD_ExcellentScore = OMNOFMEBLAD.EACPIDGGPPO_ExcellentScore;
							}
						}
					}
				}
			}
		}
	}

	//// RVA: 0x13ED3D4 Offset: 0x13ED3D4 VA: 0x13ED3D4
	private bool BEEAKFJAPOB(JGEOBNENMAH.HAJIFNABIFF OMNOFMEBLAD, EONOEHOKBEB_Music EPMMNEFADAP_MusicInfo, bool JCCBGECHIEI)
	{
		if (OMNOFMEBLAD.DGMPBPMDBEC_DropItemList == null)
			return false;
		NBPHJDCOECH_Drop dbDrop = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.HGLIIPFLMFB_Drop;
		string[] txt = null;
		COOFLMBIHML data = new COOFLMBIHML();
		if (!OMNOFMEBLAD.LFGNLKKFOCD_IsLine6)
		{
			txt = PKFJIIJJMGL;
		}
		else
		{
			txt = LKMFBMPKEGN;
		}
		string difftxt = txt[OMNOFMEBLAD.AKNELONELJK_difficulty];
		FFDBCEDKMGN_PrevPoint = 0;
		int v1 = 0;
		int v2 = 0;
		int v3 = 0;
		int v4 = 0;
		int v5 = 0;
		int v6 = 0;
		int v7 = 0;
		int scoreRank = 0;
		List<int> l = new List<int>();
		if (OMNOFMEBLAD.JPJMALBLKDI_Tutorial < 1)
		{
			if(OMNOFMEBLAD.GHBPLHBNMBK_FreeMusicId < 1)
			{
				if (OMNOFMEBLAD.KLCIIHKFPPO_StoryMusicId < 1)
					return false;
				JANMJPOKLFL_InventoryUtil.FEGDNPIEKJC(OAGBCBBHMPF.COIIJOEKBDH.EDHFDPBEFKA, OMNOFMEBLAD.KLCIIHKFPPO_StoryMusicId.ToString());
				DJNPIGEFPMF_StoryMusicInfo storyMusicInfo = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.IBPAFKKEKNK_Music.FLMLJIKBIMJ_GetStoryMusicData(OMNOFMEBLAD.KLCIIHKFPPO_StoryMusicId);
				v1 = storyMusicInfo.MGLDIOILOFF;
				v5 = storyMusicInfo.KCNHKNKNGNH_NormalRateId;
				v5 += OMNOFMEBLAD.AKNELONELJK_difficulty;
				data.KHEKNNFCAOI_Init(EPMMNEFADAP_MusicInfo.FKDCCLPGKDK_Ma, IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database, false);
				v2 = 0;
				v3 = 0;
				v4 = 0;
				v6 = 0;
				v7 = 0;
				scoreRank = 0;
			}
			else
			{
				string[] strs = new string[5];
				strs[0] = OMNOFMEBLAD.GHBPLHBNMBK_FreeMusicId.ToString();
				strs[1] = ":";
				strs[2] = difftxt;
				strs[3] = ":";
				strs[4] = NKGFGDGFGFM_SessionId;
				JANMJPOKLFL_InventoryUtil.FEGDNPIEKJC(OAGBCBBHMPF.COIIJOEKBDH.IMJOELNOOMB_0, string.Concat(strs));
				bool d = false;
				IKDICBBFBMI_EventBase event_ = null;
				if(OMNOFMEBLAD.MFJKNCACBDG_OpenEventType == 0 || JEPBIIJDGEF_EventInfo.HHCJCDFCLOB.MKBJOOAILBB_GetEventByStatus(KGCNCBOKCBA.GNENJEHKMHD_EventStatus.EMAMLLFAOJI_Counting_6, false) == null)
				{
					d = false;
				}
				else
				{
					event_ = JEPBIIJDGEF_EventInfo.HHCJCDFCLOB.MKBJOOAILBB_GetEventByStatus(KGCNCBOKCBA.GNENJEHKMHD_EventStatus.EMAMLLFAOJI_Counting_6, false);
					FFDBCEDKMGN_PrevPoint = (int)event_.FBGDBGKNKOD_GetCurrentPoint();
					d = true;
				}
				KEODKEGFDLD_FreeMusicInfo freeInfo = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.IBPAFKKEKNK_Music.NOBCLJIAMLC_GetFreeMusicData(OMNOFMEBLAD.GHBPLHBNMBK_FreeMusicId);
				v1 = freeInfo.MGLDIOILOFF_NormalSetId;
				if (d)
				{
					v1 = event_.JDFHIHPPAHN_UpdateDropItemSet(v1, (OHCAABOMEOF.KGOGMKMBCPP_EventType)OMNOFMEBLAD.MNNHHJBBICA_GameEventType);
				}
				v5 = freeInfo.KDIKCKEEPDA_GetNormalRateId(OMNOFMEBLAD.LFGNLKKFOCD_IsLine6);
				if(d)
				{
					v5 = event_.NCHKBINKKBH_UpdateDropRateSet(v5, (OHCAABOMEOF.KGOGMKMBCPP_EventType)OMNOFMEBLAD.MNNHHJBBICA_GameEventType);
				}
				v7 = 0;
				v6 = freeInfo.JCDKMICANJO_RareSetId;
				if (v6 != 0)
				{
					v7 = OMNOFMEBLAD.AKNELONELJK_difficulty + freeInfo.ONLFLGPMAAN_GetRareRateId(OMNOFMEBLAD.LFGNLKKFOCD_IsLine6);
				}
				v3 = freeInfo.CCLIOBOGFHC;
				v4 = 0;
				if(d)
				{
					v3 = event_.EEMGDCPJNEG(v3, (OHCAABOMEOF.KGOGMKMBCPP_EventType)OMNOFMEBLAD.MNNHHJBBICA_GameEventType);
				}
				if(v3 != 0)
				{
					int j = freeInfo.NCCFJCDMBFO(OMNOFMEBLAD.LFGNLKKFOCD_IsLine6);
					if(d)
					{
						j = event_.DJHOMGLGAHA(j, (OHCAABOMEOF.KGOGMKMBCPP_EventType)OMNOFMEBLAD.MNNHHJBBICA_GameEventType);
					}
					v4 = OMNOFMEBLAD.AKNELONELJK_difficulty + j;
				}
				v2 = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.HNMMJINNHII_Game.NBIAKELCBLC_GetNumItems(OMNOFMEBLAD.MJBODMOLOBC_luck, OMNOFMEBLAD.JEKDIEFPEON_RareItemRandomSeed);
				if(OMNOFMEBLAD.MNNHHJBBICA_GameEventType == 0)
				{
					if(OMNOFMEBLAD.MFJKNCACBDG_OpenEventType == 1)
					{
						v2 = JEPBIIJDGEF_EventInfo.HHCJCDFCLOB.NBIAKELCBLC(OMNOFMEBLAD.MNNHHJBBICA_GameEventType,
							OMNOFMEBLAD.MFJKNCACBDG_OpenEventType, OMNOFMEBLAD.AKNELONELJK_difficulty, OMNOFMEBLAD.LFGNLKKFOCD_IsLine6,
							OMNOFMEBLAD.MJBODMOLOBC_luck, OMNOFMEBLAD.JEKDIEFPEON_RareItemRandomSeed);
					}
				}
				else
				{
					v2 = JEPBIIJDGEF_EventInfo.HHCJCDFCLOB.NBIAKELCBLC(OMNOFMEBLAD.MNNHHJBBICA_GameEventType, OMNOFMEBLAD.MFJKNCACBDG_OpenEventType, OMNOFMEBLAD.AKNELONELJK_difficulty, OMNOFMEBLAD.LFGNLKKFOCD_IsLine6, OMNOFMEBLAD.MJBODMOLOBC_luck, OMNOFMEBLAD.JEKDIEFPEON_RareItemRandomSeed);
				}

				scoreRank = freeInfo.EMJCHPDJHEI(OMNOFMEBLAD.LFGNLKKFOCD_IsLine6, OMNOFMEBLAD.AKNELONELJK_difficulty).DLPBHJALHCK_GetScoreRank(OMNOFMEBLAD.KNIFCANOHOC_score);
				v5 = OMNOFMEBLAD.AKNELONELJK_difficulty + v5;
				data.KHEKNNFCAOI_Init(EPMMNEFADAP_MusicInfo.FKDCCLPGKDK_Ma, IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database, false);
				if(d)
				{
					List<int> l2 = event_.AEGDKBNNDBC_GetDrops();
					if(l2 != null)
					{
						l = l2;
					}
				}
			}
		}
		else
		{
			// L476
			JANMJPOKLFL_InventoryUtil.FEGDNPIEKJC(OAGBCBBHMPF.COIIJOEKBDH.IMJOELNOOMB_0, string.Concat(new object[5]
			{
				OMNOFMEBLAD.GHBPLHBNMBK_FreeMusicId, ":", difftxt, ":", NKGFGDGFGFM_SessionId
			}));
            KEODKEGFDLD_FreeMusicInfo finfo = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.IBPAFKKEKNK_Music.NOBCLJIAMLC_GetFreeMusicData(OMNOFMEBLAD.GHBPLHBNMBK_FreeMusicId);
            v1 = finfo.MGLDIOILOFF_NormalSetId;
			v6 = finfo.JCDKMICANJO_RareSetId;
			v4 = 0;
			v3 = finfo.CCLIOBOGFHC;
			if(v3 != 0)
				v4 = OMNOFMEBLAD.AKNELONELJK_difficulty;
			v2 = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.HNMMJINNHII_Game.NBIAKELCBLC_GetNumItems(OMNOFMEBLAD.MJBODMOLOBC_luck, OMNOFMEBLAD.JEKDIEFPEON_RareItemRandomSeed);
			v7 = 0;
			scoreRank = finfo.EMJCHPDJHEI(false, OMNOFMEBLAD.AKNELONELJK_difficulty).DLPBHJALHCK_GetScoreRank(OMNOFMEBLAD.KNIFCANOHOC_score);
			data.KHEKNNFCAOI_Init(EPMMNEFADAP_MusicInfo.FKDCCLPGKDK_Ma, IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database, false);
			v5 = OMNOFMEBLAD.AKNELONELJK_difficulty + finfo.KDIKCKEEPDA_GetNormalRateId(OMNOFMEBLAD.LFGNLKKFOCD_IsLine6);
		}
		//LAB_013edd18
		HNJKJCDDIMG_SetInfo setInfo = dbDrop.NMGAAKPJPLB(v1);
		OPGDJANLKBM_RateInfo rateInfo = dbDrop.KPDHGNEILPO(v5);
		HNJKJCDDIMG_SetInfo setInfo3 = dbDrop.OHGDKJFDIKK_GetSet(v6);
		OPGDJANLKBM_RateInfo rateInfo3 = dbDrop.OGBNNMOIBOP_GetRate(v7);
		HNJKJCDDIMG_SetInfo setInfo2 = dbDrop.OHGDKJFDIKK_GetSet(v3);
		OPGDJANLKBM_RateInfo rateInfo2 = dbDrop.OGBNNMOIBOP_GetRate(v4);
		int f = LFGNFNDDLJH_TicketCount;
		if (OMNOFMEBLAD.OOPEJLMNIAH_EventItemCount > 0)
		{
			// L648
			int a1 = dbDrop.ENLMDHJIPLA_GameDropEvCnt[OMNOFMEBLAD.AKNELONELJK_difficulty].DNJEJEANJGL_Value;
			int a2 = dbDrop.DGCBAFGBOCL_GameDropEvBns[OMNOFMEBLAD.AKNELONELJK_difficulty].DNJEJEANJGL_Value;
			int a3 = (BCCJLLJMPAA_EventRareDropDenomRand * a2) / INKMIAAMIEO_EventRareDropDenom;
			int a4 = (a1 + a3) * LFGNFNDDLJH_TicketCount;
			int a5 = LFGNFNDDLJH_TicketCount * (a1 + a2);
			if(a4 < a1)
				a4 = a1;
			if(a5 < a4)
				a4 = a5;
			if(JCCBGECHIEI)
			{
				BDMIIPKOIKL(0, HIEBJGOKEID_ItemId, a4, true);
			}
			else
			{
				DFKOELMCDDL(0, HIEBJGOKEID_ItemId, a4, true);
			}
		}
		if(setInfo != null && rateInfo != null)
		{
			OMNOFMEBLAD.DGMPBPMDBEC_DropItemList.Sort();
			int cnt = 0;
			bool ba = false;
			for (int i = 0; i < OMNOFMEBLAD.DGMPBPMDBEC_DropItemList.Count; i++)
			{
				int item = OMNOFMEBLAD.DGMPBPMDBEC_DropItemList[i];
				if((item & 0x10000000) == 0)
				{
					if((item & 0x20000000) != 0)
					{
						if(LFGNFNDDLJH_TicketCount * v2 <= cnt)
						{
							UnityEngine.Debug.Log("RareDrop Overflow");
							ba = true;
							continue;
						}
						if(setInfo2 != null && rateInfo2 != null)
						{
							int itemIdx = (int)(item & 0xdfffffff);
							int itemId = setInfo2.FKNBLDPIPMC_GetItemId(itemIdx);
							if (itemId != 0)
							{
								if(rateInfo2.HMFFHLPNMPH_Count[itemIdx] > 0)
								{
									if (itemId == 170000)
										itemId = HIEBJGOKEID_ItemId;
									else if(itemId == 400001)
									{
										int v = 0;
										if (l.Count < 1)
										{
											v = data.NEHHNEPPIBK();
										}
										else
										{
											v = l[OMNOFMEBLAD.JEKDIEFPEON_RareItemRandomSeed % l.Count];
										}
										itemId = 40000 + v;
									}
									else if(itemId == 40000)
									{
										itemId = 40000 + data.NEHHNEPPIBK();
									}
									UnityEngine.Debug.LogError("Add item "+itemId);
									if(JCCBGECHIEI)
									{
										//LAB_013ee8e4
										BDMIIPKOIKL(item, itemId, rateInfo2.HMFFHLPNMPH_Count[itemIdx] * LFGNFNDDLJH_TicketCount, false);
									}
									else
									{
										DFKOELMCDDL(item, itemId, rateInfo2.HMFFHLPNMPH_Count[itemIdx] * LFGNFNDDLJH_TicketCount, false);
									}
								}
							}
						}
					}
					else
					{
						int itemIdx = (int)(item & 0xbfffffff);
						if(itemIdx > -1 && itemIdx < setInfo.KAINPNMMAEK_GetItemsCount() && setInfo.FKNBLDPIPMC_GetItemId(itemIdx) != 0)
						{
							if(rateInfo.HMFFHLPNMPH_Count[itemIdx] > 0)
							{
								int itemId = setInfo.FKNBLDPIPMC_GetItemId(itemIdx);
								if (itemId == 170000)
									itemId = HIEBJGOKEID_ItemId;
								else if(itemId == 40001)
								{
									int v = 0;
									if(l.Count < 1)
									{
										v = data.NEHHNEPPIBK();
									}
									else
									{
										v = l[OMNOFMEBLAD.JEKDIEFPEON_RareItemRandomSeed % l.Count];
									}
									itemId = v + 40000;
								}
								else if(itemId == 40000)
								{
									itemId = 40000 + data.NEHHNEPPIBK();
								}
								if(JCCBGECHIEI)
								{
									BDMIIPKOIKL(item, itemId, rateInfo.HMFFHLPNMPH_Count[itemIdx] * LFGNFNDDLJH_TicketCount, false);
								}
								else
								{
									DFKOELMCDDL(item, itemId, rateInfo.HMFFHLPNMPH_Count[itemIdx] * LFGNFNDDLJH_TicketCount, false);
								}
							}
						}
					}
				}
				else
				{
					if(LFGNFNDDLJH_TicketCount * v2 <= cnt)
					{
						UnityEngine.Debug.Log("RareDrop Overflow");
						ba = true;
						continue;
					}
					if(setInfo3 != null && rateInfo3 != null)
					{
						int itemIdx = (int)(item & 0xefffffff);
						int itemId = setInfo3.FKNBLDPIPMC_GetItemId(itemIdx);
						if(itemId != 0)
						{
							if(rateInfo3.HMFFHLPNMPH_Count[itemIdx] > 0)
							{
								if(itemId == 170000)
								{
									itemId = HIEBJGOKEID_ItemId;
								}
								else if (itemId == 40001)
								{
									int v = 0;
									if (l.Count < 1)
									{
										v = data.NEHHNEPPIBK();
									}
									else
									{
										v = l[OMNOFMEBLAD.JEKDIEFPEON_RareItemRandomSeed % l.Count];
									}
									itemId = v + 40000;
								}
								else if (itemId == 40000)
								{
									itemId = 40000 + data.NEHHNEPPIBK();
								}
								if (JCCBGECHIEI)
								{
									BDMIIPKOIKL(item, itemId, rateInfo3.HMFFHLPNMPH_Count[itemIdx] * LFGNFNDDLJH_TicketCount, false);
								}
								else
								{
									DFKOELMCDDL(item, itemId, rateInfo3.HMFFHLPNMPH_Count[itemIdx] * LFGNFNDDLJH_TicketCount, false);
								}
							}
						}
					}
					cnt += LFGNFNDDLJH_TicketCount;
				}
			}
			if(ba)
				return false;
		}
		HDBDNGJMCIA(scoreRank, JCCBGECHIEI);
		if (!JCCBGECHIEI)
			ACMDMANBMEN();
		return true;
	}

	//// RVA: 0x13F2D60 Offset: 0x13F2D60 VA: 0x13F2D60
	private void DFKOELMCDDL(int _OIPCCBHIKIA_index, int KIJAPOFAGPN_ItemId, int _HMFFHLPNMPH_Count, bool OEIGPPHPPFN/* = false*/)
	{
		if (KIJAPOFAGPN_ItemId == 0)
			return;
		IELJJAAJAOE data = new IELJJAAJAOE();
		if (OEIGPPHPPFN)
		{
			data.KIJAPOFAGPN_ItemId = KIJAPOFAGPN_ItemId;
			data.OIPCCBHIKIA_index = _OIPCCBHIKIA_index;
			data.OMAJOEOOAJJ_Count0 = _HMFFHLPNMPH_Count;
			data.BAKFIPIFDLE_IsEventRareItem = true;
			HHMHOAKGBHF.Add(data);
		}
		else
		{
			if((_OIPCCBHIKIA_index & 0x30000000U) == 0 || !HCPKKNBPHNN)
			{
				IELJJAAJAOE exist = HHMHOAKGBHF.Find((IELJJAAJAOE _JGNBPFCJLKI_d) =>
				{
					//0x13F5344
					return _JGNBPFCJLKI_d.OIPCCBHIKIA_index == _OIPCCBHIKIA_index;
				});
				if(exist != null)
				{
					exist.OMAJOEOOAJJ_Count0 += _HMFFHLPNMPH_Count;
					return;
				}
				data.KIJAPOFAGPN_ItemId = KIJAPOFAGPN_ItemId;
				data.OIPCCBHIKIA_index = _OIPCCBHIKIA_index;
				data.OMAJOEOOAJJ_Count0 = _HMFFHLPNMPH_Count;
				data.PHJHJGDLPED_IsRareDrop = (_OIPCCBHIKIA_index & 0x30000000) != 0;
				HHMHOAKGBHF.Add(data);
			}
			else
			{
				data.KIJAPOFAGPN_ItemId = KIJAPOFAGPN_ItemId;
				data.OIPCCBHIKIA_index = _OIPCCBHIKIA_index;
				data.OMAJOEOOAJJ_Count0 = _HMFFHLPNMPH_Count;
				data.PHJHJGDLPED_IsRareDrop = (_OIPCCBHIKIA_index & 0x30000000) != 0;
				HHMHOAKGBHF.Add(data);
			}
		}
	}

	//// RVA: 0x13F2A20 Offset: 0x13F2A20 VA: 0x13F2A20
	private void BDMIIPKOIKL(int _OIPCCBHIKIA_index, int KIJAPOFAGPN_ItemId, int _HMFFHLPNMPH_Count, bool OEIGPPHPPFN/* = false*/)
	{
		if (KIJAPOFAGPN_ItemId == 0)
			return;
		IELJJAAJAOE data = new IELJJAAJAOE();
		if (OEIGPPHPPFN)
		{
			data.KIJAPOFAGPN_ItemId = KIJAPOFAGPN_ItemId;
			data.OIPCCBHIKIA_index = _OIPCCBHIKIA_index;
			data.OMAJOEOOAJJ_Count0 = _HMFFHLPNMPH_Count;
			data.BAKFIPIFDLE_IsEventRareItem = true;
			ACNDIGLMCAA.Add(data);
		}
		else
		{
			if ((_OIPCCBHIKIA_index & 0x30000000U) == 0 || !HCPKKNBPHNN)
			{
				IELJJAAJAOE exist = HHMHOAKGBHF.Find((IELJJAAJAOE _JGNBPFCJLKI_d) =>
				{
					//0x13F537C
					return _JGNBPFCJLKI_d.OIPCCBHIKIA_index == _OIPCCBHIKIA_index;
				});
				if (exist != null)
				{
					exist.OMAJOEOOAJJ_Count0 += _HMFFHLPNMPH_Count;
					return;
				}
				data.KIJAPOFAGPN_ItemId = KIJAPOFAGPN_ItemId;
				data.OIPCCBHIKIA_index = _OIPCCBHIKIA_index;
				data.OMAJOEOOAJJ_Count0 = _HMFFHLPNMPH_Count;
				data.PHJHJGDLPED_IsRareDrop = (_OIPCCBHIKIA_index & 0x30000000) != 0;
				ACNDIGLMCAA.Add(data);
			}
			else
			{
				data.KIJAPOFAGPN_ItemId = KIJAPOFAGPN_ItemId;
				data.OIPCCBHIKIA_index = _OIPCCBHIKIA_index;
				data.OMAJOEOOAJJ_Count0 = _HMFFHLPNMPH_Count;
				data.PHJHJGDLPED_IsRareDrop = (_OIPCCBHIKIA_index & 0x30000000) != 0;
				ACNDIGLMCAA.Add(data);
			}
		}
	}

	//// RVA: 0x13F30A0 Offset: 0x13F30A0 VA: 0x13F30A0
	private void HDBDNGJMCIA(int _DCBDCHPKLCN_Rank, bool JCCBGECHIEI)
	{
		CFNCNCBEPED = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.HNMMJINNHII_Game.JJBJKENKAJP_ClrRarCoef[_DCBDCHPKLCN_Rank];
		GIPMPIMJHLE = 0;
		if(!JCCBGECHIEI)
		{
			for(int i = 0; i < HHMHOAKGBHF.Count; i++)
			{
				EKLNMHFCAOI.FKGCBLHOOCL_Category itemcat = EKLNMHFCAOI.BKHFLDMOGBD_GetItemCategory(HHMHOAKGBHF[i].KIJAPOFAGPN_ItemId);
				if (!HHMHOAKGBHF[i].PHJHJGDLPED_IsRareDrop && !HHMHOAKGBHF[i].BAKFIPIFDLE_IsEventRareItem)
				{
					HHMHOAKGBHF[i].HMFFHLPNMPH_Count = ((CFNCNCBEPED * 10 * HHMHOAKGBHF[i].OMAJOEOOAJJ_Count0) / 1000 + 5) / 10;
					if (itemcat == EKLNMHFCAOI.FKGCBLHOOCL_Category.ADCAAALBAIF_Medal)
					{
						GIPMPIMJHLE += HHMHOAKGBHF[i].HMFFHLPNMPH_Count;
					}
				}
				else
				{
					HHMHOAKGBHF[i].HMFFHLPNMPH_Count = HHMHOAKGBHF[i].OMAJOEOOAJJ_Count0;
					if (itemcat == EKLNMHFCAOI.FKGCBLHOOCL_Category.ADCAAALBAIF_Medal)
					{
						GIPMPIMJHLE += HHMHOAKGBHF[i].HMFFHLPNMPH_Count;
					}
				}
			}
		}
		else
		{
			for(int i = 0; i < ACNDIGLMCAA.Count; i++)
			{
				EKLNMHFCAOI.FKGCBLHOOCL_Category itemcat = EKLNMHFCAOI.BKHFLDMOGBD_GetItemCategory(ACNDIGLMCAA[i].KIJAPOFAGPN_ItemId);
				if (!ACNDIGLMCAA[i].PHJHJGDLPED_IsRareDrop && !ACNDIGLMCAA[i].BAKFIPIFDLE_IsEventRareItem)
				{
					ACNDIGLMCAA[i].HMFFHLPNMPH_Count = ((CFNCNCBEPED * 10 * ACNDIGLMCAA[i].OMAJOEOOAJJ_Count0) / 1000 + 5) / 10;
					if (itemcat == EKLNMHFCAOI.FKGCBLHOOCL_Category.ADCAAALBAIF_Medal)
					{
						GIPMPIMJHLE += ACNDIGLMCAA[i].HMFFHLPNMPH_Count;
					}
				}
				else
				{
					ACNDIGLMCAA[i].HMFFHLPNMPH_Count = ACNDIGLMCAA[i].OMAJOEOOAJJ_Count0;
					if (itemcat == EKLNMHFCAOI.FKGCBLHOOCL_Category.ADCAAALBAIF_Medal)
					{
						GIPMPIMJHLE += ACNDIGLMCAA[i].HMFFHLPNMPH_Count;
					}
				}
			}
		}
	}

	//// RVA: 0x13EF670 Offset: 0x13EF670 VA: 0x13EF670
	public int ENCNIGKPEFB()
	{
		int res = 0;
		for(int i = 0; i < ACNDIGLMCAA.Count; i++)
		{
			if(EKLNMHFCAOI.BKHFLDMOGBD_GetItemCategory(ACNDIGLMCAA[i].KIJAPOFAGPN_ItemId) == EKLNMHFCAOI.FKGCBLHOOCL_Category.EMOLGEDEEJP_EventItem)
			{
				res += ACNDIGLMCAA[i].HMFFHLPNMPH_Count * IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.DHOFNBMPBAG_EventItem.CDENCMNHNGA_table[EKLNMHFCAOI.DEACAHNLMNI_getItemId(ACNDIGLMCAA[i].KIJAPOFAGPN_ItemId) - 1].JBGEEPFKIGG_val;
			}
		}
		return res;
	}

	//// RVA: 0x13F38C0 Offset: 0x13F38C0 VA: 0x13F38C0
	private void ACMDMANBMEN()
	{
		DCELMKFJHPG.Clear();
		for(int i = 0; i < HHMHOAKGBHF.Count; i++)
		{
			EKLNMHFCAOI.FKGCBLHOOCL_Category cat = EKLNMHFCAOI.BKHFLDMOGBD_GetItemCategory(HHMHOAKGBHF[i].KIJAPOFAGPN_ItemId);
			if(cat < EKLNMHFCAOI.FKGCBLHOOCL_Category.EMOLGEDEEJP_EventItem)
			{
				if(cat != EKLNMHFCAOI.FKGCBLHOOCL_Category.HJNNKCMLGFL_0_None)
				{
					if(cat == EKLNMHFCAOI.FKGCBLHOOCL_Category.MHKFDBLMOGF_Scene)
					{
						int itemId = EKLNMHFCAOI.DEACAHNLMNI_getItemId(HHMHOAKGBHF[i].KIJAPOFAGPN_ItemId);
						int cnt = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.ECNHDEHADGL_Scene.NGAIKCLLDBN(itemId);
						MMPBPOIFDAF_Scene.PMKOFEIONEG saveScene = CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_PlayerData.PNLOINMCCKH_Scene.OPIBAPEGCLA_Scenes[itemId - 1];
						int a = HHMHOAKGBHF[i].HMFFHLPNMPH_Count;
						while(a > 0)
						{
							if(saveScene.BEBJKJKBOGH_Date == 0)
							{
								IELJJAAJAOE data = new IELJJAAJAOE();
								data.OIPCCBHIKIA_index = HHMHOAKGBHF[i].OIPCCBHIKIA_index;
								data.KIJAPOFAGPN_ItemId = HHMHOAKGBHF[i].KIJAPOFAGPN_ItemId;
								data.OMAJOEOOAJJ_Count0 = 1;
								data.HMFFHLPNMPH_Count = 1;
								data.LHEDLDEMPPG_IsNew = true;
								data.PHJHJGDLPED_IsRareDrop = (HHMHOAKGBHF[i].OIPCCBHIKIA_index & 0x30000000) != 0;
								DCELMKFJHPG.Add(data);
								BGGHEILFEIN(EKLNMHFCAOI.FKGCBLHOOCL_Category.MHKFDBLMOGF_Scene, itemId, data.HMFFHLPNMPH_Count);
								a--;
							}
							else
							{
								IELJJAAJAOE data = new IELJJAAJAOE();
								data.OIPCCBHIKIA_index = HHMHOAKGBHF[i].OIPCCBHIKIA_index;
								data.KIJAPOFAGPN_ItemId = HHMHOAKGBHF[i].KIJAPOFAGPN_ItemId;
								data.PHJHJGDLPED_IsRareDrop = (HHMHOAKGBHF[i].OIPCCBHIKIA_index & 0x30000000) != 0;
								if (cnt <= saveScene.JPIPENJGGDD_NumBoard)
								{
									data.OMAJOEOOAJJ_Count0 = a;
									data.HMFFHLPNMPH_Count = a;
									data.ONDODHPHOOF_ConvertItemId = EKLNMHFCAOI.GJEEGMCBGGM_GetItemFullId(EKLNMHFCAOI.FKGCBLHOOCL_Category.MHKFDBLMOGF_Scene, IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.ECNHDEHADGL_Scene.BMPOAGJJNAF(itemId));
									data.ABIFFLDIAMM_ConvertItemCount = a;
									DCELMKFJHPG.Add(data);
									BGGHEILFEIN(EKLNMHFCAOI.FKGCBLHOOCL_Category.MHKFDBLMOGF_Scene, itemId, data.HMFFHLPNMPH_Count);
									break;
								}
								else
								{
									if (cnt < saveScene.JPIPENJGGDD_NumBoard + a)
									{
										data.OMAJOEOOAJJ_Count0 = cnt - saveScene.JPIPENJGGDD_NumBoard;
										data.HMFFHLPNMPH_Count = data.OMAJOEOOAJJ_Count0;
										a -= data.OMAJOEOOAJJ_Count0;
									}
									else
									{
										data.OMAJOEOOAJJ_Count0 = a;
										data.HMFFHLPNMPH_Count = data.OMAJOEOOAJJ_Count0;
										a = 0;
									}
									DCELMKFJHPG.Add(data);
									BGGHEILFEIN(EKLNMHFCAOI.FKGCBLHOOCL_Category.MHKFDBLMOGF_Scene, itemId, data.HMFFHLPNMPH_Count);
								}
							}
						}
					}
					else
					{
						//LAB_013f43a8
						DCELMKFJHPG.Add(HHMHOAKGBHF[i]);
						int itemId = EKLNMHFCAOI.DEACAHNLMNI_getItemId(HHMHOAKGBHF[i].KIJAPOFAGPN_ItemId);
						BGGHEILFEIN(cat, itemId, HHMHOAKGBHF[i].HMFFHLPNMPH_Count);
					}
				}
			}
			else
			{
				if(cat == EKLNMHFCAOI.FKGCBLHOOCL_Category.EMOLGEDEEJP_EventItem)
				{
					DCELMKFJHPG.Add(HHMHOAKGBHF[i]);
					int itemId = EKLNMHFCAOI.DEACAHNLMNI_getItemId(HHMHOAKGBHF[i].KIJAPOFAGPN_ItemId);
					BGGHEILFEIN(EKLNMHFCAOI.FKGCBLHOOCL_Category.EMOLGEDEEJP_EventItem, itemId, HHMHOAKGBHF[i].HMFFHLPNMPH_Count);
				}
				else
				{
					if(cat != EKLNMHFCAOI.FKGCBLHOOCL_Category.ADCAAALBAIF_Medal)
					{
						//LAB_013f43a8
						DCELMKFJHPG.Add(HHMHOAKGBHF[i]);
						int itemId = EKLNMHFCAOI.DEACAHNLMNI_getItemId(HHMHOAKGBHF[i].KIJAPOFAGPN_ItemId);
						BGGHEILFEIN(cat, itemId, HHMHOAKGBHF[i].HMFFHLPNMPH_Count);
					}
					else
					{
						DCELMKFJHPG.Add(HHMHOAKGBHF[i]);
						int itemId = EKLNMHFCAOI.DEACAHNLMNI_getItemId(HHMHOAKGBHF[i].KIJAPOFAGPN_ItemId);
						BGGHEILFEIN(EKLNMHFCAOI.FKGCBLHOOCL_Category.ADCAAALBAIF_Medal, itemId, HHMHOAKGBHF[i].HMFFHLPNMPH_Count * FCLGIPFPIPH_DashBonus);
					}
				}
			}
		}
	}

	//// RVA: 0x13F45AC Offset: 0x13F45AC VA: 0x13F45AC
	private void BGGHEILFEIN(EKLNMHFCAOI.FKGCBLHOOCL_Category _INDDJNMPONH_type, int _PPFNGGCBJKC_id, int _HMFFHLPNMPH_Count)
	{
		if(_INDDJNMPONH_type == EKLNMHFCAOI.FKGCBLHOOCL_Category.ACGHELNGNGK_UnionCredit)
		{
			PLMBDFGGBAJ += _HMFFHLPNMPH_Count;
		}
		JANMJPOKLFL_InventoryUtil.CPIICACGNBH_AddItem(CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_PlayerData, _INDDJNMPONH_type, _PPFNGGCBJKC_id, _HMFFHLPNMPH_Count, null, 0);
	}

	//// RVA: 0x13F46B0 Offset: 0x13F46B0 VA: 0x13F46B0
	//private bool AICDDFECEKD(byte _GJLFANGDGCL_Target, int CJHEHIMLGGL) { }

	//// RVA: 0x13F46D8 Offset: 0x13F46D8 VA: 0x13F46D8
	//private int DNGKOEDJOBB(int CJHEHIMLGGL) { }

	//// RVA: 0x13EC288 Offset: 0x13EC288 VA: 0x13EC288
	private bool ILDLMKGBKIL(JGEOBNENMAH.HAJIFNABIFF OMNOFMEBLAD, EONOEHOKBEB_Music EPMMNEFADAP_MusicInfo, bool JCCBGECHIEI)
	{
		if(OMNOFMEBLAD.JPJMALBLKDI_Tutorial < 1)
		{
			KEODKEGFDLD_FreeMusicInfo mdata = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.IBPAFKKEKNK_Music.NOBCLJIAMLC_GetFreeMusicData(OMNOFMEBLAD.GHBPLHBNMBK_FreeMusicId);
			ADDHLABEFKH a = mdata.EMJCHPDJHEI(OMNOFMEBLAD.LFGNLKKFOCD_IsLine6, OMNOFMEBLAD.AKNELONELJK_difficulty);
			int scoreRank = a.DLPBHJALHCK_GetScoreRank(OMNOFMEBLAD.KNIFCANOHOC_score);
			int exp = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.FMPEMFPLPDA_Exp.FIHFEGCDONI(OMNOFMEBLAD.AKNELONELJK_difficulty, scoreRank, OMNOFMEBLAD.LFGNLKKFOCD_IsLine6);
			NGDDIIDJFNG = exp;
			MKEPHNGLHDL = exp;
			if(OMNOFMEBLAD.MNNHHJBBICA_GameEventType == 14)
			{
				MANPIONIGNO_EventGoDiva ev = JEPBIIJDGEF_EventInfo.HHCJCDFCLOB.MKBJOOAILBB_GetEventByStatus(KGCNCBOKCBA.GNENJEHKMHD_EventStatus.EMAMLLFAOJI_Counting_6, false) as MANPIONIGNO_EventGoDiva;
				NGDDIIDJFNG = NGDDIIDJFNG * ev.ALNBFHJBGIG_GetDivaExpBonusRate() / 100;
				MKEPHNGLHDL = NGDDIIDJFNG;
			}
			int c = OMNOFMEBLAD.KNIFCANOHOC_score / 10000;
			int d;
			if(OMNOFMEBLAD.KNIFCANOHOC_score < 10000)
				d = MKEPHNGLHDL;
			else
			{
				if(1009999 < OMNOFMEBLAD.KNIFCANOHOC_score)
					c = 100;
				d = (c * NGDDIIDJFNG * 10 / 100 + 9) / 10 + MKEPHNGLHDL;
				MKEPHNGLHDL = d;
			}
			CBCIFACJGHI_Exp = d;
			LKGONGDLJBH = c;
			if(NHPDPKHMFEP.HHCJCDFCLOB == null)
				HGHMMDOEGEF_ExpBonus = 0;
			else
			{
				HGHMMDOEGEF_ExpBonus = NHPDPKHMFEP.HHCJCDFCLOB.ALNBFHJBGIG();
				if(HGHMMDOEGEF_ExpBonus > 0)
				{
					CBCIFACJGHI_Exp = (HGHMMDOEGEF_ExpBonus * MKEPHNGLHDL * 10 / 100 + 9) / 10 + CBCIFACJGHI_Exp;
				}
			}
			if(OMNOFMEBLAD.PMCGHPOGLGM_IsSkip && OMNOFMEBLAD.KAIPAEILJHO_TicketCount > 1)
			{
				CBCIFACJGHI_Exp = OMNOFMEBLAD.KAIPAEILJHO_TicketCount * CBCIFACJGHI_Exp;
			}
			List<KDOMGMCGHDC.HJNMIKNAMFH> l = new List<KDOMGMCGHDC.HJNMIKNAMFH>();
			for(int i = 0; i < 3; i++)
			{
				KDOMGMCGHDC.HJNMIKNAMFH item = null;
				if(OMNOFMEBLAD.HNHCIGMKPDC_DivaIds[i] != 0)
				{
					item = KDOMGMCGHDC.NEGKGKKLICK(EPMMNEFADAP_MusicInfo.DLAEJOBELBH_MusicId, OMNOFMEBLAD.HNHCIGMKPDC_DivaIds[i], CIOECGOMILE.HHCJCDFCLOB.MNJHBCIIHED_PrevServerData);
				}
				l.Add(item);
			}
			int idx = EPMMNEFADAP_MusicInfo.DLAEJOBELBH_MusicId - 1;
			for(int i = 0; i < 3; i++)
			{
				if(OMNOFMEBLAD.HNHCIGMKPDC_DivaIds[i] != 0)
				{
                    DEKKMGAFJCG_Diva.MNNLOBDPCCH_DivaInfo sdinfo = CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_PlayerData.DGCJCAHIAPP_Diva.LGKFMLIOPKL_GetDivaInfo(OMNOFMEBLAD.HNHCIGMKPDC_DivaIds[i]);
					if(sdinfo != null)
					{
						int f = CBCIFACJGHI_Exp;
						if(i == 0)
							f = (CBCIFACJGHI_Exp * 3) / 2;
						if(HMMFHMHENAO != null)
						{
							int h = HMMFHMHENAO.MPHGKGNCCEE(OMNOFMEBLAD.HNHCIGMKPDC_DivaIds[i], OMNOFMEBLAD.AKNELONELJK_difficulty);
							if(OMNOFMEBLAD.PMCGHPOGLGM_IsSkip)
							{
								int g = OMNOFMEBLAD.KAIPAEILJHO_TicketCount;
								if(g < 2)
									g = 1;
								h *= g;
							}
							f *= h;
						}
						if(IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.KDIALKDKBGE_Intimacy != null && sdinfo.JLEPLIHFPKD_IntimacySkillLevel > 0)
						{
							int k = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.KDIALKDKBGE_Intimacy.COHLJLNLBKM[sdinfo.JLEPLIHFPKD_IntimacySkillLevel - 1].JBGEEPFKIGG_val;
							f += (k * CBCIFACJGHI_Exp) / 10000;
						}
						if(l[i].PBGFIOONCMB_LevelMaxExp < sdinfo.LKIFDCEKDCK_exp[idx] + f)
						{
							sdinfo.LKIFDCEKDCK_exp[idx] = l[i].PBGFIOONCMB_LevelMaxExp;
						}
						else
						{
							sdinfo.LKIFDCEKDCK_exp[idx] = sdinfo.LKIFDCEKDCK_exp[idx] + f;
						}
					}
                }
			}
			List<int> l2 = new List<int>();
			for(int i = 0; i < 10; i++)
			{
				l2.Add(0);
			}
			for(int i = 0; i < 3; i++)
			{
				if(OMNOFMEBLAD.HNHCIGMKPDC_DivaIds[i] != 0)
				{
					DEKKMGAFJCG_Diva.MNNLOBDPCCH_DivaInfo sdinfo = CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_PlayerData.DGCJCAHIAPP_Diva.LGKFMLIOPKL_GetDivaInfo(OMNOFMEBLAD.HNHCIGMKPDC_DivaIds[i]);
					if(sdinfo != null)
					{
						int f = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.FMPEMFPLPDA_Exp.EMJCHPDJHEI(sdinfo.LKIFDCEKDCK_exp[idx]);
						if(sdinfo.ANAJIAENLNB_Level[idx] < f)
						{
							if(sdinfo.ANAJIAENLNB_Level[idx] < IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.FMPEMFPLPDA_Exp.GNIPHICJAIA_Music.Count)
							{
								l2[OMNOFMEBLAD.HNHCIGMKPDC_DivaIds[i] - 1] += IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.FMPEMFPLPDA_Exp.GNIPHICJAIA_Music[sdinfo.ANAJIAENLNB_Level[idx]].HMFFHLPNMPH_Count;
								sdinfo.ANAJIAENLNB_Level[idx]++;
							}
						}
					}
				}
			}
			for(int i = 0; i < 3; i++)
			{
				if(OMNOFMEBLAD.HNHCIGMKPDC_DivaIds[i] != 0)
				{
					DEKKMGAFJCG_Diva.MNNLOBDPCCH_DivaInfo sdinfo = CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_PlayerData.DGCJCAHIAPP_Diva.LGKFMLIOPKL_GetDivaInfo(OMNOFMEBLAD.HNHCIGMKPDC_DivaIds[i]);
					if(sdinfo != null)
					{
						int m = l2[OMNOFMEBLAD.HNHCIGMKPDC_DivaIds[i] - 1];
						if(m > 0)
						{
							sdinfo.ACABEFKBBEN_ExpFrag += m;
							int n = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.FMPEMFPLPDA_Exp.IOCHHEEDIJD(sdinfo.ACABEFKBBEN_ExpFrag);
							if(sdinfo.HEBKEJBDCBH_DivaLevel < n)
							{
								ILCCJNDFFOB.HHCJCDFCLOB.EBLJKIOEELA(OMNOFMEBLAD.HNHCIGMKPDC_DivaIds[i], n, sdinfo.ACABEFKBBEN_ExpFrag);
								sdinfo.HEBKEJBDCBH_DivaLevel = n;
							}
						}
					}
				}
			}
			if(JCCBGECHIEI)
			{
				for(int i = 0; i < 10; i++)
				{
					FFDDBFEIJKI[i] = CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_PlayerData.DGCJCAHIAPP_Diva.LGKFMLIOPKL_GetDivaInfo(i + 1).HEBKEJBDCBH_DivaLevel;
				}
				CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_PlayerData.DGCJCAHIAPP_Diva.ODDIHGPONFL_Copy(CIOECGOMILE.HHCJCDFCLOB.MNJHBCIIHED_PrevServerData.DGCJCAHIAPP_Diva);
			}
		}
		return true;
	}

	//// RVA: 0x13F2428 Offset: 0x13F2428 VA: 0x13F2428
	private void KJAFCPAFDBK(JGEOBNENMAH.HAJIFNABIFF OMNOFMEBLAD, EONOEHOKBEB_Music EPMMNEFADAP)
	{
		if(OMNOFMEBLAD.KLCIIHKFPPO_StoryMusicId > 0)
		{
			LAEGMENIEDB_Story.ALGOILKGAAH dbStory = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.OHCIFMDPAPD_Story.CDENCMNHNGA_table.Find((LAEGMENIEDB_Story.ALGOILKGAAH _GHPLINIACBB_x) =>
			{
				//0x13F53B4
				return _GHPLINIACBB_x.KLCIIHKFPPO_StoryMusicId == OMNOFMEBLAD.KLCIIHKFPPO_StoryMusicId;
			});
			if(dbStory != null)
			{
				NEKDCJKANAH_StoryRecord.HKDNILFKCFC saveStory = CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_PlayerData.LNOOKHJBENO_StoryRecord.MMKAJBFBKNH[dbStory.LFLLLOPAKCO_StoryId - 1];
				saveStory.ODEHJGPDFCL_Score = OMNOFMEBLAD.KNIFCANOHOC_score;
				saveStory.PDNJGJNGPNJ_MaxCombo = OMNOFMEBLAD.NLKEBAOBJCM_combo;
				saveStory.EALOBDHOCHP_Stat = 4;
				saveStory.ABFNAEKEGOB_ComboRank = OMNOFMEBLAD.LCOHGOIDMDF_ComboRank;
				ILCCJNDFFOB.HHCJCDFCLOB.AOPBBHMIEPB(dbStory.LFLLLOPAKCO_StoryId);
				saveStory.ICCJMCCJCBG = true;
				if(CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_PlayerData != null)
				{
					CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_PlayerData.KCCLEHLLOFG_Common.ENIPGFLGJHH_LastStory = OMNOFMEBLAD.KLCIIHKFPPO_StoryMusicId;
				}
			}
		}
	}

	//// RVA: 0x13F4C3C Offset: 0x13F4C3C VA: 0x13F4C3C
	//private bool CCAMCAEBPFI(int _OIPCCBHIKIA_index, int _KIJAPOFAGPN_ItemId, int _HMFFHLPNMPH_Count) { }

	//// RVA: 0x13F2940 Offset: 0x13F2940 VA: 0x13F2940
	private bool KALFMENHPFE(JGEOBNENMAH.HAJIFNABIFF OMNOFMEBLAD, int AKNELONELJK, int _PPFNGGCBJKC_id, int _KIJAPOFAGPN_ItemId, int _HMFFHLPNMPH_Count)
	{
		if(OMNOFMEBLAD.MNNHHJBBICA_GameEventType != 1)
		{
			BGGHEILFEIN(EKLNMHFCAOI.BKHFLDMOGBD_GetItemCategory(_KIJAPOFAGPN_ItemId), EKLNMHFCAOI.DEACAHNLMNI_getItemId(_KIJAPOFAGPN_ItemId), _HMFFHLPNMPH_Count);
			return true;
		}
		return false;
	}

	//// RVA: 0x13F4CF8 Offset: 0x13F4CF8 VA: 0x13F4CF8
	//private void LIEOONNJFBF(JGEOBNENMAH.HAJIFNABIFF OMNOFMEBLAD, EONOEHOKBEB EPMMNEFADAP) { }

	//// RVA: 0x13F4CFC Offset: 0x13F4CFC VA: 0x13F4CFC
	//private void OFFCNFDBNNB(JGEOBNENMAH.HAJIFNABIFF OMNOFMEBLAD, EONOEHOKBEB EPMMNEFADAP) { }

	//// RVA: 0x13EF0EC Offset: 0x13EF0EC VA: 0x13EF0EC
	private void EMLKKEHCKMI(JGEOBNENMAH.HAJIFNABIFF OMNOFMEBLAD, EONOEHOKBEB_Music EPMMNEFADAP_MusicInfo, bool JCCBGECHIEI)
	{
		if(OMNOFMEBLAD.JPJMALBLKDI_Tutorial < 1)
		{
			EGOLBAPFHHD_Common saveCommon = CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_PlayerData.KCCLEHLLOFG_Common;
			JJOPEDJCCJK_Exp dbExp = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.FMPEMFPLPDA_Exp;
			PEBFNABDJDI_System dbSystem = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.GDEKCOOBLMA_System;
			int v = dbExp.FAANKGOFNGE_GetExp(JGEOBNENMAH.NNDOEOOAMLO_GetMusicStamina(OMNOFMEBLAD, JGEOBNENMAH.KFFCMNELJJB_GetMusicScore(EPMMNEFADAP_MusicInfo, OMNOFMEBLAD.AKNELONELJK_difficulty, OMNOFMEBLAD.LFGNLKKFOCD_IsLine6)));
			int v2 = 0;
			if (NHPDPKHMFEP.HHCJCDFCLOB != null)
				v2 = NHPDPKHMFEP.HHCJCDFCLOB.PIEFCAPBEAI();
			HBAJPMDOMPL = v2;
			if(v2 > 0)
			{
				v = ((v * v2 * 10) / 100 + 5) / 10 + v;
			}
			if(OMNOFMEBLAD.PMCGHPOGLGM_IsSkip)
			{
				v *= (OMNOFMEBLAD.KAIPAEILJHO_TicketCount < 2 ? 1 : OMNOFMEBLAD.KAIPAEILJHO_TicketCount);
			}
			FOIPBBCHBIB = v;
			int j = saveCommon.KIECDDFNCAN_Level;
			for (int i = saveCommon.ANGGCMBPKKC_AddExp(v, dbExp, dbSystem); i > 0; i--)
			{
				j++;
				if(!JCCBGECHIEI)
				{
					CIOECGOMILE.HHCJCDFCLOB.GIFFIGPKOFE_AddStamina(dbExp.HPEOBAEGHKC_GetStaminaGainForLevel(j));
				}
			}
			PMPBDEJMHOJ_Level = saveCommon.KIECDDFNCAN_Level;
			if(JCCBGECHIEI)
			{
				saveCommon.KIECDDFNCAN_Level = CIOECGOMILE.HHCJCDFCLOB.MNJHBCIIHED_PrevServerData.KCCLEHLLOFG_Common.KIECDDFNCAN_Level;
				saveCommon.EOHDMCMHBKJ_Exp = CIOECGOMILE.HHCJCDFCLOB.MNJHBCIIHED_PrevServerData.KCCLEHLLOFG_Common.EOHDMCMHBKJ_Exp;
			}
		}
	}

	//// RVA: 0x13F1918 Offset: 0x13F1918 VA: 0x13F1918
	private void LKDINNAPACD(JGEOBNENMAH.HAJIFNABIFF OMNOFMEBLAD, EONOEHOKBEB_Music EPMMNEFADAP)
	{
		if(OMNOFMEBLAD.JPJMALBLKDI_Tutorial < 1)
		{
			int ticketCount = 1;
			if(OMNOFMEBLAD.PMCGHPOGLGM_IsSkip)
			{
				ticketCount = OMNOFMEBLAD.KAIPAEILJHO_TicketCount;
				if (ticketCount < 2)
					ticketCount = 1;
			}
			for(int i = 0; i < ticketCount; i++)
			{
				CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_PlayerData.OEKEIGFAIGN_Counter.EJFAEKPGKNJ_daily.FBKAPLHEACL_AddMClr();
				CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_PlayerData.OEKEIGFAIGN_Counter.EJFAEKPGKNJ_daily.DPKJNIPGGMJ_AddSRnk(PENICOGGNLF_ScoreRank);
				if(OMNOFMEBLAD.HGEKDNNJAAC_AwakenDivaMode)
				{
					CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_PlayerData.OEKEIGFAIGN_Counter.EJFAEKPGKNJ_daily.MAFAKCMFHEE_AddSdv();
				}
				CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_PlayerData.OEKEIGFAIGN_Counter.EJFAEKPGKNJ_daily.CIGILPOKMAN_AddAS(OMNOFMEBLAD.BCGBODDEFKP_NumSkillActive);
				if(OMNOFMEBLAD.JPJMALBLKDI_Tutorial == 0 && OMNOFMEBLAD.BCGBODDEFKP_NumSkillActive > 0)
				{
					ILLPDLODANB.MOFIPNGNNPA(ILLPDLODANB.LOEGALDKHPL.DDGKOJFPGFF, 2, false);
				}
				NAKMCMEPAGH n = CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_PlayerData.OEKEIGFAIGN_Counter.BDLNMOIOMHK_Total;
				if(OMNOFMEBLAD.HGEKDNNJAAC_AwakenDivaMode)
				{
					n.MAFAKCMFHEE_AddSdv();
				}
				if(OMNOFMEBLAD.KNCBNGCDMII_HadValkyrieMode)
				{
					n.MOOJGMJFOKK_AddVk();
				}
				n.FBKAPLHEACL_AddMusicClear();
				n.KGFIAHEEMDN_AddSerieClear(EPMMNEFADAP.AIHCEGFANAM_SerieAttr);
				n.HIEBCILPBGB_AddDiffClear(OMNOFMEBLAD.AKNELONELJK_difficulty, OMNOFMEBLAD.LFGNLKKFOCD_IsLine6);
				if(!OMNOFMEBLAD.PMCGHPOGLGM_IsSkip && OMNOFMEBLAD.LCOHGOIDMDF_ComboRank != 0)
				{
					n.PFLCOFBJOED_AddFcb();
				}
				if(PENICOGGNLF_ScoreRank == 4)
				{
					n.OLEDHOJJIOH_AddSS();
				}
				if(!OMNOFMEBLAD.PMCGHPOGLGM_IsSkip)
				{
					n.DHECAFOELPF_SetHighScore(OMNOFMEBLAD.KNIFCANOHOC_score);
				}
				if(!OMNOFMEBLAD.CEPCBJHNMJA_IsNotUpdateProfile)
				{
					CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_PlayerData.OEKEIGFAIGN_Counter.BEJONIOEGCI(EPMMNEFADAP.DLAEJOBELBH_MusicId, OMNOFMEBLAD.AKNELONELJK_difficulty, true, OMNOFMEBLAD.LCOHGOIDMDF_ComboRank != 0, OMNOFMEBLAD.OJFNDOIFOOE_NoteResultCount, OMNOFMEBLAD.PMCGHPOGLGM_IsSkip, OMNOFMEBLAD.LFGNLKKFOCD_IsLine6);
				}
				if(!OMNOFMEBLAD.LFGNLKKFOCD_IsLine6)
				{
					for(int j = 0; j < 5; j++)
					{
						CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_PlayerData.MHEAEGMIKIE_PublicStatus.BAHLFHCOEHO(j, CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_PlayerData.OEKEIGFAIGN_Counter.MOEJDCPHJOH_GetTotalMClr(j));
						CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_PlayerData.MHEAEGMIKIE_PublicStatus.CECEAOLLLNG(j, CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_PlayerData.OEKEIGFAIGN_Counter.AMIPHDGAMLI_GetTotalFcb(j));
					}
				}
				else
				{
					for (int j = 0; j < 5; j++)
					{
						CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_PlayerData.MHEAEGMIKIE_PublicStatus.PCBEBNAHCDH(j, CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_PlayerData.OEKEIGFAIGN_Counter.DGKBOGGIAKD_GetTotalMClr16(j));
						CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_PlayerData.MHEAEGMIKIE_PublicStatus.KLAALDBEAJM(j, CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_PlayerData.OEKEIGFAIGN_Counter.CEPBENFKMFF_GetTotalMFcb16(j));
					}
				}
			}
			if(!OMNOFMEBLAD.PMCGHPOGLGM_IsSkip)
			{
				if(CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_PlayerData.MHEAEGMIKIE_PublicStatus.AEBENOJEGOJ_MaxScore < OMNOFMEBLAD.KNIFCANOHOC_score)
				{
					CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_PlayerData.MHEAEGMIKIE_PublicStatus.AEBENOJEGOJ_MaxScore = OMNOFMEBLAD.KNIFCANOHOC_score;
					CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_PlayerData.MHEAEGMIKIE_PublicStatus.JEENEHPOCFN_MaxDf = OMNOFMEBLAD.AKNELONELJK_difficulty;
					CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_PlayerData.MHEAEGMIKIE_PublicStatus.JHOIMONJKLG_MaxId = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.IBPAFKKEKNK_Music.CIKALPJDGMF_ResolveMusicId(OMNOFMEBLAD.GHBPLHBNMBK_FreeMusicId, EPMMNEFADAP.DLAEJOBELBH_MusicId);
					CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_PlayerData.MHEAEGMIKIE_PublicStatus.NADEAGFJDLL_MaxL6 = OMNOFMEBLAD.LFGNLKKFOCD_IsLine6 ? 1 : 0;
					Debug.Log(JpStringLiterals.StringLiteral_10416 + OMNOFMEBLAD.KNIFCANOHOC_score + "</color>");
				}
				HighScoreRating r = new HighScoreRating();
				r.Init();
				r.CalcUtaRate(CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_PlayerData.LCKMBHDMPIP_RecordMusic, true);
				CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_PlayerData.KCCLEHLLOFG_Common.CCNGJHIBPMP_UpdateUtaRate();
			}
		}
	}

	//// RVA: 0x13F102C Offset: 0x13F102C VA: 0x13F102C
	private void GDIKFPFDJKH(JGEOBNENMAH.HAJIFNABIFF OMNOFMEBLAD, EONOEHOKBEB_Music EPMMNEFADAP)
	{
		if (OMNOFMEBLAD.JPJMALBLKDI_Tutorial > 0)
			return;
		List<NEKDCJKANAH_StoryRecord.HKDNILFKCFC> a = CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_PlayerData.LNOOKHJBENO_StoryRecord.MMKAJBFBKNH;
		List<int> l = new List<int>();
		for(int i = 0; i < IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.OHCIFMDPAPD_Story.CDENCMNHNGA_table.Count; i++)
		{
			LAEGMENIEDB_Story.ALGOILKGAAH dbStory = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.OHCIFMDPAPD_Story.CDENCMNHNGA_table[i];
			if(dbStory.PPEGAKEIEGM_Enabled == 2)
			{
				NEKDCJKANAH_StoryRecord.HKDNILFKCFC sStory = a[i];
				if(sStory.EALOBDHOCHP_Stat == 1)
				{
					l.Add(i);
				}
			}
		}
		l.Sort((int HKICMNAACDA, int BNKHBCBJBKI) =>
		{
			//0x13F5410
			return a[HKICMNAACDA].NDFOAINJPIN_pos.CompareTo(a[BNKHBCBJBKI].NDFOAINJPIN_pos);
		});
		if (l.Count < 1)
			return;
		LAEGMENIEDB_Story.ALGOILKGAAH ds = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.OHCIFMDPAPD_Story.CDENCMNHNGA_table[l[0]];
		NEKDCJKANAH_StoryRecord.HKDNILFKCFC ss = a[l[0]];
		bool g2 = true;
		if(ds.JIHMAJENMDO_MinLevel > 0)
		{
			g2 = ds.JIHMAJENMDO_MinLevel <= CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_PlayerData.KCCLEHLLOFG_Common.KIECDDFNCAN_Level;
		}
		bool g = true;
		if(ds.ICKPLIABPKC_FreeMusicId != 0)
		{
			if(ss.EJKHAFIALGK_MClr == 0)
			{
				if (!DAKKOLCGFCN)
					g = false;
				else
				{
					KEODKEGFDLD_FreeMusicInfo fData = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.IBPAFKKEKNK_Music.NOBCLJIAMLC_GetFreeMusicData(ds.ICKPLIABPKC_FreeMusicId);
					bool b = true;
					if (OMNOFMEBLAD.GHBPLHBNMBK_FreeMusicId == ds.ICKPLIABPKC_FreeMusicId)
					{
						g = false;
						if (OMNOFMEBLAD.AKNELONELJK_difficulty < ds.JOPNDOKOIHI_Difficulty)
							b = false;
					}
					else
					{
						g = false;
						if (EPMMNEFADAP.DLAEJOBELBH_MusicId != fData.DLAEJOBELBH_MusicId)
							b = false;
						if (OMNOFMEBLAD.AKNELONELJK_difficulty < ds.JOPNDOKOIHI_Difficulty)
							b = false;
					}
					if (b)
					{
						g = ds.GGOCFLLMHPH_Rank <= fData.EMJCHPDJHEI(OMNOFMEBLAD.LFGNLKKFOCD_IsLine6, OMNOFMEBLAD.AKNELONELJK_difficulty).DLPBHJALHCK_GetScoreRank(OMNOFMEBLAD.KNIFCANOHOC_score);
						if (g)
						{
							ss.EJKHAFIALGK_MClr = 1;
						}
					}
				}
			}
		}
		//LAB_013f158c
		if(ds.EPBBNFDFLLD_or == 0)
		{
			if(g && g2)
			{
				ss.EALOBDHOCHP_Stat = 2;
			}
		}
		else
		{
			if(g || g2)
			{
				ss.EALOBDHOCHP_Stat = 2;
			}
		}
	}

	//// RVA: 0x13F0ECC Offset: 0x13F0ECC VA: 0x13F0ECC
	private bool HMJONPNKLFA(JGEOBNENMAH.HAJIFNABIFF OMNOFMEBLAD)
	{
		return OMNOFMEBLAD.HNHCIGMKPDC_DivaIds[0] == 1 && CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_PlayerData.DGCJCAHIAPP_Diva.LGKFMLIOPKL_GetDivaInfo(OMNOFMEBLAD.HNHCIGMKPDC_DivaIds[0]).BEEAIAAJOHD_CostumeId == 2;
	}

	//// RVA: 0x13EBEB0 Offset: 0x13EBEB0 VA: 0x13EBEB0
	private void LDNMDBMFIIK_UpdateHighScore(JGEOBNENMAH.HAJIFNABIFF OMNOFMEBLAD, EONOEHOKBEB_Music EPMMNEFADAP_MusicInfo, bool IKGLAFOHGDO_DoNotSave)
	{
		if(!OMNOFMEBLAD.PMCGHPOGLGM_IsSkip)
		{
			KEODKEGFDLD_FreeMusicInfo freeInfo = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.IBPAFKKEKNK_Music.NOBCLJIAMLC_GetFreeMusicData(OMNOFMEBLAD.GHBPLHBNMBK_FreeMusicId);
			if(freeInfo.PPEGAKEIEGM_Enabled == 2)
			{
				if(freeInfo.DEPGBBJMFED_CategoryId != 5)
				{
					JDDGGJCGOPA_RecordMusic.EHFMCGGNPIJ_MusicInfo recordMusic = CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_PlayerData.LCKMBHDMPIP_RecordMusic.FAMANJGJANN_FreeMusicInfo[OMNOFMEBLAD.GHBPLHBNMBK_FreeMusicId - 1];
					long date = recordMusic.NLIDBKHMBBD_HighScoreDate;
					bool saveScore = false;
					if(date == 0)
					{
						saveScore = true;
					}
					else
					{
						saveScore = recordMusic.IFNDLIGGGHP_HighScoreScore < OMNOFMEBLAD.KNIFCANOHOC_score;
					}
					if(saveScore && !IKGLAFOHGDO_DoNotSave)
					{
						recordMusic.IFNDLIGGGHP_HighScoreScore = OMNOFMEBLAD.KNIFCANOHOC_score;
						recordMusic.NOCLBJAGNHD_HighScoreDiff = OMNOFMEBLAD.AKNELONELJK_difficulty;
						recordMusic.NLIDBKHMBBD_HighScoreDate = NKGJPJPHLIF.HHCJCDFCLOB.IBLPICFDGOF_ServerRequester.FJDBNGEPKHL_Time.KMEFBNBFJHI_GetServerTime();
						recordMusic.AOGEGMMBGEN_HighScoreLine6 = OMNOFMEBLAD.LFGNLKKFOCD_IsLine6 ? 1 : 0;
					}
				}
			}
		}
	}
}
