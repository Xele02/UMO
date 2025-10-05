
using System.Collections.Generic;
using XeApp.Game.Common;

public class GBNDFCEDNMG
{

    public enum IPGHCHBMMII_TargetMusicType // HMOJCCPIPBP_TargetMusicType
    {
        HJNNKCMLGFL_0_None = 0,
        HIFIGCJNJDO_1_Music = 1,
        LMGPFIBKECF_2_JacketAttr = 2,
        MJOJFOFGCKJ_3_SerieAttr = 3,
        EEAMJNCBLJA_4_EventMusic = 4,
        DLPIILJLCOL_5_MusicId = 5,
        PDAILHHMPOA_6_AprilFoolMusic = 6,
    }

    public enum KCMJJNMEPDK_TargetDifficultyType // DGMIADAEGAI_TargetDifficultyType
    {
        HJNNKCMLGFL_0_None = 0,
        JHMIMFOCHJP_1_Easy = 1,
        CCAPCGPIIPF_2_Normal = 2,
        KGLPGOOBPDF_3_Hard = 3,
        NENEKKPKCCN_4_VeryHard = 4,
        KBOKNLKMGAE_5_Extreme = 5,
    }

    public enum FLFNOJCEBOI_TargetUnitType // NAPODHGLKAJ_TargetUnitType
    {
        HJNNKCMLGFL_0_None = 0,
        NAFALPHEMKB_1_LessNumScenes = 1,
        LCLMLKPGKBJ_2_MoreNumScene = 2,
        GPKIDHFPFKP_3_LessNumSceneSerie = 3,
        IAOAMNDGFCM_4_MoreNumSceneSerie = 4,
        FOCGMJJEMOJ_5_LessNumSceneEpisode = 5,
        DKDJOMMBODG_6_MoreNumSceneEpisode = 6,
        OCACGNJEGPD_7_LessNumSceneSerie = 7,
        EJMNFKNOJKN_8_MoreNumSceneSerie = 8,
        NGFNJOOOIDB_9_Diva = 9,
        CINJPAPDNGC_10_CenterSkillType = 10,
        IGBDBJHOICE_11_ActiveSkillType = 11,
        KFDCEEMPJJE_12_LiveSkillType = 12,
        MIGOEDMJFCH_13_LessSceneFrontierDeltaSeven = 13,
    }

    public enum CJDGJFINBFH_ClearType // HDAMBOOCIAA_ClearType
    {
        HJNNKCMLGFL_0_None = 0,
        JCHLONCMPAJ_1_Clear = 1,
        JKADCABEELM_2_Combo = 2,
        KHCOOPDAGOE_3_ScoreRank = 3,
        KEILBOLBDHN_4_Score = 4,
        ONBNGGDFAJK_5_Fold = 5,
        GEJCJDEMCMK_6_EventPoint = 6,
        BPGCMBDNPBE_7_DivaMode = 7,
        BMBKDNBPMAH_8_AwakenDivaMode = 8,
        OBBKKNLLLEN_9_LessNumNotes = 9,
        NKPDHENIBIA_10_MoreNumNotes = 10,
        GJPAALJHLHN_11_Life = 11,
        JPOGBMJKPIJ_12_FullCombo = 12,
        FHOEKNNOLCK = 13,
        BGMDGMELPHJ_14_EventBattleWin = 14,
        IELDCHLKEHG_15_EventBattleCountWin = 15,
        JIFAFBPHACI_16_EventBattleWinWithRank = 16,
        JEMNFEKLHOA_17_EventMissionClear = 17,
        KNPBBPNJNEM_18_NumDiva = 18,
        ADCDEIPMKJI_19_NumEventMission = 19,
        DCFBLGLFJDO_20_DailyMissionCompleted = 20,
        HKMENCLLHJB_21_DivaTouchCount = 21,
        ABHINADBMOE_22_RankCombo = 22,
        KAMDLPNNGCG_23_EventBattleWinWithRankAndClass = 23,
        HFMIOBKCKHD_24_MvMode = 24,
        NJKNOEPAELH_25_MvModeWithCostume = 25,
        POHBAGJLOLI_26_IncDivaCount = 26,
        EBCMMPMCHIK_27_RaidAttackType = 27,
        BEKIJHOCDFE_28_RaidRequestBossHelp = 28,
        APIDIDMAKHL_29_RaidAttackType = 29,
        OOGEAGAJKAG_30_MacrossCanon = 30,
        PMMOLBAAHEM_31_Vop = 31,
        JLFJCIOOABC_32_DrawGacha = 32,
        CHIIAHIJFCB_33_Deco = 33,
        DMNIOHMDJEI_34_RaidAttackType = 34,
        KMHJDFJHMEP_35_RaidEncounterBoss = 35,
        EKKMNHIKGKF_36_RaidAttackType = 36,
        PCPDPJAMPBP_37_EventSong = 37,
        FDIEEMDFMGO_38_EventSongComboRank = 38,
        ABFDKJGHHPG_39_EventSongScoreRank = 39,
        LJGBOEOMJHK_40_EventSongScore = 40,
        EKBKFCOCKPJ_41_GoDivaSoulUpgrade = 41,
        NCABFNABDFI_42_GoDivaVoiceUpgrade = 42,
        DIMCIJDJLGK_43_GoDivaCharmUpgrade = 43,
        GNNHECOPEID_44_GoDivaBonusStart = 44,
        GHLDBIHKCOK_45_EventSong = 45,
        MBOFBJKDJFA_46_EventSongComboRank = 46,
        BIJEBKHNHDP_47_EventSongScoreRank = 47,
        ICFDOFMJJND_48_EventSongScore = 48,
        JNPNFMCPJJN_49_AprilFoolClear = 49,
    }

	public static OHCAABOMEOF.KGOGMKMBCPP_EventType[] JIMACAGJJKP = new OHCAABOMEOF.KGOGMKMBCPP_EventType[2] { /*7*/OHCAABOMEOF.KGOGMKMBCPP_EventType.ENPJADLIFAB_EventSp, /*8*/OHCAABOMEOF.KGOGMKMBCPP_EventType.OCCGDMDBCHK_8_EventGacha }; // 0x0

	// // RVA: 0x16A2D88 Offset: 0x16A2D88 VA: 0x16A2D88
	public static bool LLNJFONIECK_EventSpOrGacha(OHCAABOMEOF.KGOGMKMBCPP_EventType _HIDHLFCBIDE_EventType)
	{
		for(int i = 0; i < JIMACAGJJKP.Length; i++)
		{
			if (JIMACAGJJKP[i] == _HIDHLFCBIDE_EventType)
				return true;
		}
		return false;
	}

	// // RVA: 0x16A2ED0 Offset: 0x16A2ED0 VA: 0x16A2ED0
	public static bool EIJIGDCMJLB(OKGLGHCBCJP_Database _LKMHPJKIFDN_md, BBHNACPENDM_ServerSaveData _LDEGEHAEALK_ServerData, AKIIJBEJOEP _NDFIEMPPMLF_master, JGEOBNENMAH.HAJIFNABIFF OMNOFMEBLAD, IKDICBBFBMI_EventBase LIKDEHHKFEH, bool NPFECBGCJPG)
	{
		if(OMNOFMEBLAD.GHBPLHBNMBK_FreeMusicId != 0)
		{
			if(_NDFIEMPPMLF_master.PPEGAKEIEGM_Enabled == 2)
			{
				if(DINDNEELMOD_CheckDate(_LKMHPJKIFDN_md, _LDEGEHAEALK_ServerData, _NDFIEMPPMLF_master, OMNOFMEBLAD, LIKDEHHKFEH))
				{
					if(MEAJMANDEOL_CheckTargetMusic(_LKMHPJKIFDN_md, _LDEGEHAEALK_ServerData, _NDFIEMPPMLF_master, OMNOFMEBLAD, LIKDEHHKFEH))
					{
						if(PDPGLIBBCPJ_CheckDifficulty(_NDFIEMPPMLF_master, OMNOFMEBLAD.AKNELONELJK_difficulty, NPFECBGCJPG))
						{
							if(GCFIJFKDJBE_CheckTargetUnit(_LKMHPJKIFDN_md, _LDEGEHAEALK_ServerData, _NDFIEMPPMLF_master, OMNOFMEBLAD))
							{
								if(LBOCNEHCMLB(_LKMHPJKIFDN_md, _LDEGEHAEALK_ServerData, _NDFIEMPPMLF_master, OMNOFMEBLAD, LIKDEHHKFEH, 0, OMNOFMEBLAD.NFFDIGEJHGL_ServerTime))
								{
									if(_NDFIEMPPMLF_master.OOLNFBFBONH > 0)
									{
										if (!LBOCNEHCMLB(_LKMHPJKIFDN_md, _LDEGEHAEALK_ServerData, _NDFIEMPPMLF_master, OMNOFMEBLAD, LIKDEHHKFEH, 1, OMNOFMEBLAD.NFFDIGEJHGL_ServerTime))
											return false;
									}
									if(LIKDEHHKFEH.HIDHLFCBIDE_EventType == OHCAABOMEOF.KGOGMKMBCPP_EventType.ENPJADLIFAB_EventSp)
									{
										if (LIKDEHHKFEH is KNKDBNFMAKF_EventSp)
										{
											return _NDFIEMPPMLF_master.KGICDMIJGDF_Group == (LIKDEHHKFEH as KNKDBNFMAKF_EventSp).MEDEJHKNAFG_GetCurrentMissionGroup(OMNOFMEBLAD.NFFDIGEJHGL_ServerTime);
										}
									}
									return true;
								}
							}
						}
					}
				}
			}
		}
		return false;
	}

	// // RVA: 0x16A7210 Offset: 0x16A7210 VA: 0x16A7210
	public static bool HANGCDOFING(OKGLGHCBCJP_Database _LKMHPJKIFDN_md, BBHNACPENDM_ServerSaveData _LDEGEHAEALK_ServerData, AKIIJBEJOEP _NDFIEMPPMLF_master, IKDICBBFBMI_EventBase LIKDEHHKFEH, CJDGJFINBFH_ClearType _HDAMBOOCIAA_ClearType/* = 0*/)
	{
		if(_NDFIEMPPMLF_master.PPEGAKEIEGM_Enabled == 2)
		{
			if(MHMCIHJIJEC(_LKMHPJKIFDN_md, _LDEGEHAEALK_ServerData, _NDFIEMPPMLF_master, null, LIKDEHHKFEH))
			{
				if (_HDAMBOOCIAA_ClearType != CJDGJFINBFH_ClearType.HJNNKCMLGFL_0_None/*0*/ && _NDFIEMPPMLF_master.HDAMBOOCIAA_ClearType != (int)_HDAMBOOCIAA_ClearType)
					return false;
				long time = NKGJPJPHLIF.HHCJCDFCLOB.IBLPICFDGOF_ServerRequester.FJDBNGEPKHL_Time.KMEFBNBFJHI_GetServerTime();
				if (LBOCNEHCMLB(_LKMHPJKIFDN_md, _LDEGEHAEALK_ServerData, _NDFIEMPPMLF_master, null, LIKDEHHKFEH, 0, time))
				{
					if(LIKDEHHKFEH.HIDHLFCBIDE_EventType == OHCAABOMEOF.KGOGMKMBCPP_EventType.ENPJADLIFAB_EventSp/*7*/)
					{
						return _NDFIEMPPMLF_master.KGICDMIJGDF_Group == (LIKDEHHKFEH as KNKDBNFMAKF_EventSp).MEDEJHKNAFG_GetCurrentMissionGroup(time);
					}
					return true;
				}
			}
		}
		return false;
	}

	// // RVA: 0x16A7670 Offset: 0x16A7670 VA: 0x16A7670
	public static bool DACHEKFEFNN(OKGLGHCBCJP_Database _LKMHPJKIFDN_md, BBHNACPENDM_ServerSaveData _LDEGEHAEALK_ServerData, AKIIJBEJOEP _NDFIEMPPMLF_master, JGEOBNENMAH.HAJIFNABIFF OMNOFMEBLAD, IKDICBBFBMI_EventBase LIKDEHHKFEH, bool NPFECBGCJPG, CJDGJFINBFH_ClearType _HDAMBOOCIAA_ClearType/* = 0*/)
	{
		if(OMNOFMEBLAD == null || OMNOFMEBLAD.GHBPLHBNMBK_FreeMusicId != 0)
		{
			if(_NDFIEMPPMLF_master.PPEGAKEIEGM_Enabled == 2)
			{
				if(MHMCIHJIJEC(_LKMHPJKIFDN_md, _LDEGEHAEALK_ServerData, _NDFIEMPPMLF_master, OMNOFMEBLAD, LIKDEHHKFEH))
				{
					if(MEAJMANDEOL_CheckTargetMusic(_LKMHPJKIFDN_md, _LDEGEHAEALK_ServerData, _NDFIEMPPMLF_master, OMNOFMEBLAD, LIKDEHHKFEH))
					{
						if(OMNOFMEBLAD != null)
						{
							if (!PDPGLIBBCPJ_CheckDifficulty(_NDFIEMPPMLF_master, OMNOFMEBLAD.AKNELONELJK_difficulty, NPFECBGCJPG))
								return false;
						}
						if(GCFIJFKDJBE_CheckTargetUnit(_LKMHPJKIFDN_md, _LDEGEHAEALK_ServerData, _NDFIEMPPMLF_master, OMNOFMEBLAD))
						{
							if (_HDAMBOOCIAA_ClearType != CJDGJFINBFH_ClearType.HJNNKCMLGFL_0_None/*0*/ && _NDFIEMPPMLF_master.HDAMBOOCIAA_ClearType != (int)_HDAMBOOCIAA_ClearType)
								return false;
							long time = NKGJPJPHLIF.HHCJCDFCLOB.IBLPICFDGOF_ServerRequester.FJDBNGEPKHL_Time.KMEFBNBFJHI_GetServerTime();
							if (LBOCNEHCMLB(_LKMHPJKIFDN_md, _LDEGEHAEALK_ServerData, _NDFIEMPPMLF_master, OMNOFMEBLAD, LIKDEHHKFEH, 0, time))
							{
								if(LIKDEHHKFEH.HIDHLFCBIDE_EventType == OHCAABOMEOF.KGOGMKMBCPP_EventType.ENPJADLIFAB_EventSp)
								{
									if(LIKDEHHKFEH is KNKDBNFMAKF_EventSp)
									{
										return (LIKDEHHKFEH as KNKDBNFMAKF_EventSp).MEDEJHKNAFG_GetCurrentMissionGroup(time) == _NDFIEMPPMLF_master.KGICDMIJGDF_Group;
									}
								}
								return true;
							}
						}
					}
				}
			}
		}
		return false;
	}

	// // RVA: 0x16A79F0 Offset: 0x16A79F0 VA: 0x16A79F0
	public static bool BBEKHCGKIAJ(AKIIJBEJOEP _NDFIEMPPMLF_master, IKCGAJKCPFN NHLBKJCPLBL, JGEOBNENMAH.HAJIFNABIFF OMNOFMEBLAD, IKDICBBFBMI_EventBase LIKDEHHKFEH)
	{
		if(NHLBKJCPLBL.EALOBDHOCHP_stat != 1)
			return false;
		int target;
		if(_NDFIEMPPMLF_master.HDAMBOOCIAA_ClearType == 13)
		{
			if(OMNOFMEBLAD != null)
			{
				NHLBKJCPLBL.HMFFHLPNMPH_count += OMNOFMEBLAD.KNIFCANOHOC_score;
			}
			target = _NDFIEMPPMLF_master.JJECMJFDEEP_ClearConditionValue;
		}
		else
		{
			if(_NDFIEMPPMLF_master.HDAMBOOCIAA_ClearType == 36)
			{
				if(LIKDEHHKFEH != null)
				{
					PKNOKJNLPOE_EventRaid d = LIKDEHHKFEH as PKNOKJNLPOE_EventRaid;
					if(d != null)
					{
						NHLBKJCPLBL.HMFFHLPNMPH_count = d.NENNACLBKJJ + NHLBKJCPLBL.HMFFHLPNMPH_count;
					}
				}
			}
			else
			{
				NHLBKJCPLBL.HMFFHLPNMPH_count += 1;
			}
			target = _NDFIEMPPMLF_master.GLDIGCJNOBO_ClearCount;
		}
		if(target <= NHLBKJCPLBL.HMFFHLPNMPH_count)
		{
			NHLBKJCPLBL.EALOBDHOCHP_stat = 2;
		}
		return true;
	}

	// // RVA: 0x16A7C78 Offset: 0x16A7C78 VA: 0x16A7C78
	public static bool MDBLPCIKHBJ(int _EKANGPODCEP_EventId, int _AIBFGKBACCB_LobbyId, AKIIJBEJOEP _NDFIEMPPMLF_master, IKCGAJKCPFN NHLBKJCPLBL)
	{
		if(NHLBKJCPLBL.EALOBDHOCHP_stat == 1)
		{
			if(_NDFIEMPPMLF_master.HDAMBOOCIAA_ClearType != 13)
			{
				PBJPACKDIIB.IFCOFHAFMON p = new PBJPACKDIIB.IFCOFHAFMON();
				p.EKANGPODCEP_EventId = _EKANGPODCEP_EventId;
				p.AIBFGKBACCB_LobbyId = _AIBFGKBACCB_LobbyId;
				p.CMEJFJFOIIJ_QuestId = _NDFIEMPPMLF_master.PPFNGGCBJKC_id;
				p.FKPEAGGKNLC_Start = _NDFIEMPPMLF_master.KJBGCLPMLCG_OpenedAt;
				p.KOMKKBDABJP_end = _NDFIEMPPMLF_master.GJFPFFBAKGK_CloseAt;
				p.CGHNCPEKOCK_IsDaily = _NDFIEMPPMLF_master.PPCFIHMDMLM;
				PBJPACKDIIB.Instance.CGJLFIGBHCG(p);
				return true;
			}
		}
		return false;
	}

	// // RVA: 0x16A7E48 Offset: 0x16A7E48 VA: 0x16A7E48
	public static bool KMFPHOPBFEA(AKIIJBEJOEP _NDFIEMPPMLF_master, IKCGAJKCPFN NHLBKJCPLBL, int _HMFFHLPNMPH_count)
	{
		if(NHLBKJCPLBL.EALOBDHOCHP_stat == 1)
		{
			if(_NDFIEMPPMLF_master.HDAMBOOCIAA_ClearType != 13)
			{
				NHLBKJCPLBL.HMFFHLPNMPH_count = _HMFFHLPNMPH_count;
				if(_NDFIEMPPMLF_master.GLDIGCJNOBO_ClearCount <= NHLBKJCPLBL.HMFFHLPNMPH_count)
				{
					NHLBKJCPLBL.EALOBDHOCHP_stat = 2;
				}
				return true;
			}
		}
		return false;
	}

	// // RVA: 0x16A7F3C Offset: 0x16A7F3C VA: 0x16A7F3C
	public static bool GLDHKNMLEIG(AKIIJBEJOEP _NDFIEMPPMLF_master, OFNLIBDEIFA_EventQuest.AGFEALDEJOL NHLBKJCPLBL, JGEOBNENMAH.HAJIFNABIFF OMNOFMEBLAD)
	{
		if(_NDFIEMPPMLF_master.HDAMBOOCIAA_ClearType == 13)
		{
			return _NDFIEMPPMLF_master.JJECMJFDEEP_ClearConditionValue <= NHLBKJCPLBL.OLDAGCNLJOI_progress;
		}
		return _NDFIEMPPMLF_master.GLDIGCJNOBO_ClearCount <= _NDFIEMPPMLF_master.JJECMJFDEEP_ClearConditionValue + 1;
	}

	// // RVA: 0x16A8018 Offset: 0x16A8018 VA: 0x16A8018
	public static void BBEKHCGKIAJ(AKIIJBEJOEP _NDFIEMPPMLF_master, OFNLIBDEIFA_EventQuest.AGFEALDEJOL NHLBKJCPLBL, JGEOBNENMAH.HAJIFNABIFF OMNOFMEBLAD)
	{
		if(_NDFIEMPPMLF_master.HDAMBOOCIAA_ClearType == 13)
		{
			NHLBKJCPLBL.OLDAGCNLJOI_progress += OMNOFMEBLAD.KNIFCANOHOC_score;
		}
		else
		{
			NHLBKJCPLBL.OLDAGCNLJOI_progress ++;
		}
	}

	// // RVA: 0x16A80C4 Offset: 0x16A80C4 VA: 0x16A80C4
	public static int NKGDIBMNLNO(AKIIJBEJOEP _NDFIEMPPMLF_master)
	{
		return _NDFIEMPPMLF_master.HDAMBOOCIAA_ClearType == 13 ? 1 : 0;
	}

	// // RVA: 0x16A8100 Offset: 0x16A8100 VA: 0x16A8100
	public static bool EGKODECGHNM(AKIIJBEJOEP _NDFIEMPPMLF_master, OFNLIBDEIFA_EventQuest.AGFEALDEJOL NHLBKJCPLBL)
	{
		if(_NDFIEMPPMLF_master.HDAMBOOCIAA_ClearType == 13)
		{
			return NHLBKJCPLBL.OLDAGCNLJOI_progress >= _NDFIEMPPMLF_master.JJECMJFDEEP_ClearConditionValue;
		}
		else
		{
			return NHLBKJCPLBL.OLDAGCNLJOI_progress >= _NDFIEMPPMLF_master.GLDIGCJNOBO_ClearCount;
		}
	}

	// // RVA: 0x16A81D0 Offset: 0x16A81D0 VA: 0x16A81D0
	// private static bool PKNNAFJGBGD(long _KJBGCLPMLCG_OpenedAt, long _GJFPFFBAKGK_CloseAt, long LPEKHFOMCAH) { }

	// // RVA: 0x16A7480 Offset: 0x16A7480 VA: 0x16A7480
	private static bool MHMCIHJIJEC(OKGLGHCBCJP_Database _LKMHPJKIFDN_md, BBHNACPENDM_ServerSaveData _LDEGEHAEALK_ServerData, AKIIJBEJOEP _NDFIEMPPMLF_master, JGEOBNENMAH.HAJIFNABIFF OMNOFMEBLAD, IKDICBBFBMI_EventBase LIKDEHHKFEH)
	{
		if(LIKDEHHKFEH != null)
		{
			long time = NKGJPJPHLIF.HHCJCDFCLOB.IBLPICFDGOF_ServerRequester.FJDBNGEPKHL_Time.KMEFBNBFJHI_GetServerTime();
			LIKDEHHKFEH.HCDGELDHFHB_UpdateStatus(time);
			if(LIKDEHHKFEH.NGOFCFJHOMI_Status < KGCNCBOKCBA.GNENJEHKMHD_EventStatus.EIFKDKFAHPH_7/*7*/)
			{
				if(_NDFIEMPPMLF_master.KJBGCLPMLCG_OpenedAt != 0 || _NDFIEMPPMLF_master.GJFPFFBAKGK_CloseAt != 0)
				{
					return time >= _NDFIEMPPMLF_master.KJBGCLPMLCG_OpenedAt && time < _NDFIEMPPMLF_master.GJFPFFBAKGK_CloseAt;
				}
				return true;
			}
		}
		return false;
	}

	// // RVA: 0x16A3224 Offset: 0x16A3224 VA: 0x16A3224
	private static bool DINDNEELMOD_CheckDate(OKGLGHCBCJP_Database _LKMHPJKIFDN_md, BBHNACPENDM_ServerSaveData _LDEGEHAEALK_ServerData, AKIIJBEJOEP _NDFIEMPPMLF_master, JGEOBNENMAH.HAJIFNABIFF OMNOFMEBLAD, IKDICBBFBMI_EventBase LIKDEHHKFEH)
	{
		if(LIKDEHHKFEH != null)
		{
			if(LIKDEHHKFEH.LOLAANGCGDO_RankingEnd2 >= OMNOFMEBLAD.NFFDIGEJHGL_ServerTime)
			{
				if(_NDFIEMPPMLF_master.KJBGCLPMLCG_OpenedAt != 0 || _NDFIEMPPMLF_master.GJFPFFBAKGK_CloseAt != 0)
				{
					return OMNOFMEBLAD.NFFDIGEJHGL_ServerTime >= _NDFIEMPPMLF_master.KJBGCLPMLCG_OpenedAt && OMNOFMEBLAD.NFFDIGEJHGL_ServerTime < _NDFIEMPPMLF_master.GJFPFFBAKGK_CloseAt;
				}
				return true;
			}
		}
		return false;
	}

	// // RVA: 0x16A336C Offset: 0x16A336C VA: 0x16A336C
	private static bool MEAJMANDEOL_CheckTargetMusic(OKGLGHCBCJP_Database _LKMHPJKIFDN_md, BBHNACPENDM_ServerSaveData _LDEGEHAEALK_ServerData, AKIIJBEJOEP _NDFIEMPPMLF_master, JGEOBNENMAH.HAJIFNABIFF OMNOFMEBLAD, IKDICBBFBMI_EventBase LIKDEHHKFEH)
	{
		if (OMNOFMEBLAD == null)
			return false;
		KEODKEGFDLD_FreeMusicInfo fm = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.IBPAFKKEKNK_Music.NOBCLJIAMLC_GetFreeMusicData(OMNOFMEBLAD.GHBPLHBNMBK_FreeMusicId);
		EONOEHOKBEB_Music m = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.IBPAFKKEKNK_Music.IAJLOELFHKC_GetMusicInfo(fm.DLAEJOBELBH_MusicId);
		switch(_NDFIEMPPMLF_master.HMOJCCPIPBP_TargetMusicType)
		{
			case 0:
				return true;
			case 1:
				return OMNOFMEBLAD.GHBPLHBNMBK_FreeMusicId == _NDFIEMPPMLF_master.HBJJCDIMOPO_TargetMusicConditionId;
			case 2:
				return m.FKDCCLPGKDK_JacketAttr == _NDFIEMPPMLF_master.HBJJCDIMOPO_TargetMusicConditionId;
			case 3:
				return m.AIHCEGFANAM_SerieAttr == _NDFIEMPPMLF_master.HBJJCDIMOPO_TargetMusicConditionId;
			case 4:
				if (LIKDEHHKFEH == null)
					return false;
				if(LLNJFONIECK_EventSpOrGacha(LIKDEHHKFEH.HIDHLFCBIDE_EventType))
				{
					LIKDEHHKFEH = JEPBIIJDGEF_EventInfo.HHCJCDFCLOB.MKBJOOAILBB_GetEventByStatus(KGCNCBOKCBA.GNENJEHKMHD_EventStatus.BCKENOKGLIJ_9_ResultRewardreceived/*9*/, false);
					if (LIKDEHHKFEH == null)
						return false;
				}
				List<int> l = LIKDEHHKFEH.HEACCHAKMFG_GetMusicsList();
				if (l == null)
					return false;
				int idx = l.FindIndex((int _GHPLINIACBB_x) =>
				{
					//0x16A8EF4
					return OMNOFMEBLAD.GHBPLHBNMBK_FreeMusicId == _GHPLINIACBB_x;
				});
				return idx > -1;
			case 5:
				return m.DLAEJOBELBH_MusicId == _NDFIEMPPMLF_master.HBJJCDIMOPO_TargetMusicConditionId;
			case 6:
				if (LIKDEHHKFEH == null)
					return false;
				if (LIKDEHHKFEH.HIDHLFCBIDE_EventType != OHCAABOMEOF.KGOGMKMBCPP_EventType.DAMDPLEBNCB_AprilFool)
					return false;
				AMLGMLNGMFB_EventAprilFool af = LIKDEHHKFEH as AMLGMLNGMFB_EventAprilFool;
				return af.GOHABONFBDM(OMNOFMEBLAD) == _NDFIEMPPMLF_master.HBJJCDIMOPO_TargetMusicConditionId;
			default:
				return false;
		}
	}

	// // RVA: 0x16A38E0 Offset: 0x16A38E0 VA: 0x16A38E0
	private static bool PDPGLIBBCPJ_CheckDifficulty(AKIIJBEJOEP _NDFIEMPPMLF_master, int _AKNELONELJK_difficulty, bool HCBMLNNKKLN)
	{
		switch(_NDFIEMPPMLF_master.DGMIADAEGAI_TargetDifficultyType)
		{
			default:
				break;
			case 1:
				if (HCBMLNNKKLN)
					return _AKNELONELJK_difficulty == 0;
				return _AKNELONELJK_difficulty > -1;
			case 2:
				if (HCBMLNNKKLN)
					return _AKNELONELJK_difficulty == 1;
				return _AKNELONELJK_difficulty > 0;
			case 3:
				if (HCBMLNNKKLN)
					return _AKNELONELJK_difficulty == 2;
				return _AKNELONELJK_difficulty > 1;
			case 4:
				if (HCBMLNNKKLN)
					return _AKNELONELJK_difficulty == 3;
				return _AKNELONELJK_difficulty > 2;
			case 5:
				if (HCBMLNNKKLN)
					return _AKNELONELJK_difficulty == 4;
				return _AKNELONELJK_difficulty > 3;
		}
		return true;
	}

	// // RVA: 0x16A39F8 Offset: 0x16A39F8 VA: 0x16A39F8
	private static bool GCFIJFKDJBE_CheckTargetUnit(OKGLGHCBCJP_Database _LKMHPJKIFDN_md, BBHNACPENDM_ServerSaveData _LDEGEHAEALK_ServerData, AKIIJBEJOEP _NDFIEMPPMLF_master, JGEOBNENMAH.HAJIFNABIFF OMNOFMEBLAD)
	{
		CIFHILOJJFC defaultUnit = _LDEGEHAEALK_ServerData.MLAFAACKKBG_Unit.FJDDNKGHPHN_GetDefault();
		List<MLIBEPGADJH_Scene.KKLDOOJBJMN> BLPGDHGACAJ = _LKMHPJKIFDN_md.ECNHDEHADGL_Scene.CDENCMNHNGA_table;
		switch(_NDFIEMPPMLF_master.NAPODHGLKAJ_TargetUnitType)
		{
			case 1:
				return _NDFIEMPPMLF_master.FAHLEOKHBGH_TargetUnitConditionValue <= defaultUnit.EIDAHHCEPPC_GetNumScenes();
			case 2:
				return defaultUnit.EIDAHHCEPPC_GetNumScenes() <= _NDFIEMPPMLF_master.FAHLEOKHBGH_TargetUnitConditionValue;
			case 3:
				return _NDFIEMPPMLF_master.FAHLEOKHBGH_TargetUnitConditionValue <= defaultUnit.CJJIHFDLNMJ_CountForEachDivaScene((int _AHHJLDLAPAN_DivaId, int _BCCHOBPJJKE_SceneId) =>
				{
					//0x16A8F28
					return (int)BLPGDHGACAJ[_BCCHOBPJJKE_SceneId - 1].AIHCEGFANAM_SerieAttr == _NDFIEMPPMLF_master.FHILEEHDDKN_TargetUnitConditionId;
				});
			case 4:
				return defaultUnit.CJJIHFDLNMJ_CountForEachDivaScene((int _AHHJLDLAPAN_DivaId, int _BCCHOBPJJKE_SceneId) =>
				{
					//0x16A8FFC
					return (int)BLPGDHGACAJ[_BCCHOBPJJKE_SceneId - 1].AIHCEGFANAM_SerieAttr == _NDFIEMPPMLF_master.FHILEEHDDKN_TargetUnitConditionId;
				}) <= _NDFIEMPPMLF_master.FAHLEOKHBGH_TargetUnitConditionValue;
			case 5:
				return _NDFIEMPPMLF_master.FAHLEOKHBGH_TargetUnitConditionValue <= defaultUnit.CJJIHFDLNMJ_CountForEachDivaScene((int _AHHJLDLAPAN_DivaId, int _BCCHOBPJJKE_SceneId) =>
				{
					//0x16A90D0
					return BLPGDHGACAJ[_BCCHOBPJJKE_SceneId - 1].KELFCMEOPPM_EpisodeId == _NDFIEMPPMLF_master.FHILEEHDDKN_TargetUnitConditionId;
				});
			case 6:
				return defaultUnit.CJJIHFDLNMJ_CountForEachDivaScene((int _AHHJLDLAPAN_DivaId, int _BCCHOBPJJKE_SceneId) =>
				{
					//0x16A91A4
					return BLPGDHGACAJ[_BCCHOBPJJKE_SceneId - 1].KELFCMEOPPM_EpisodeId == _NDFIEMPPMLF_master.FHILEEHDDKN_TargetUnitConditionId;
				}) <= _NDFIEMPPMLF_master.FAHLEOKHBGH_TargetUnitConditionValue;
			case 7:
				return _NDFIEMPPMLF_master.FAHLEOKHBGH_TargetUnitConditionValue <= defaultUnit.CJJIHFDLNMJ_CountForEachDivaScene((int _AHHJLDLAPAN_DivaId, int _BCCHOBPJJKE_SceneId) =>
				{
					//0x16A9278
					return (int)BLPGDHGACAJ[_BCCHOBPJJKE_SceneId - 1].AIHCEGFANAM_SerieAttr == _NDFIEMPPMLF_master.FHILEEHDDKN_TargetUnitConditionId;
				});
			case 8:
				return defaultUnit.CJJIHFDLNMJ_CountForEachDivaScene((int _AHHJLDLAPAN_DivaId, int _BCCHOBPJJKE_SceneId) =>
				{
					//0x16A934C
					return (int)BLPGDHGACAJ[_BCCHOBPJJKE_SceneId - 1].AIHCEGFANAM_SerieAttr == _NDFIEMPPMLF_master.FHILEEHDDKN_TargetUnitConditionId;
				}) <= _NDFIEMPPMLF_master.FAHLEOKHBGH_TargetUnitConditionValue;
			case 9:
				bool res = true;
				for(int i = 0; i < OMNOFMEBLAD.HNHCIGMKPDC_DivaIds.Count; i++)
				{
					int a = (_NDFIEMPPMLF_master.FAHLEOKHBGH_TargetUnitConditionValue >> ((i * 8) & 24)) & 0xff;
					if (a != 0)
					{
						res &= OMNOFMEBLAD.HNHCIGMKPDC_DivaIds[i] == a - 1;
					}
				}
				return res;
			case 10:
				if (defaultUnit.FDBOPFEOENF_diva[0].DIPKCALNIII_diva_id == 0)
					return false;
				if (defaultUnit.FDBOPFEOENF_diva[0].EBDNICPAFLB_s_slot[0] != 0)
				{
					MLIBEPGADJH_Scene.KKLDOOJBJMN saveScene = BLPGDHGACAJ[defaultUnit.FDBOPFEOENF_diva[0].EBDNICPAFLB_s_slot[0] - 1];
					int EMAGAIKNHDN_CS = saveScene.EMAGAIKNHDN_CS;
					MMPBPOIFDAF_Scene.PMKOFEIONEG dbScene = _LDEGEHAEALK_ServerData.PNLOINMCCKH_Scene.OPIBAPEGCLA_Scenes[defaultUnit.FDBOPFEOENF_diva[0].EBDNICPAFLB_s_slot[0] - 1];
					if(dbScene.JPIPENJGGDD_NumBoard < 2)
					{
						if (EMAGAIKNHDN_CS == 0)
							return false;
					}
					else
					{
						EMAGAIKNHDN_CS = saveScene.AEIBPIEIBFO_CS2;
						if(EMAGAIKNHDN_CS == 0)
						{
							EMAGAIKNHDN_CS = saveScene.EMAGAIKNHDN_CS;
							if (EMAGAIKNHDN_CS == 0)
								return false;
						}
					}
					HBDCPGLAPHH skill = _LKMHPJKIFDN_md.FOFADHAENKC_Skill.COLCPGFABLP_CenterSkills.Find((HBDCPGLAPHH _GHPLINIACBB_x) =>
					{
						//0x16A9628
						return _GHPLINIACBB_x.JBFLEDKDFCO_cid == EMAGAIKNHDN_CS;
					});
					if (skill == null)
						return false;
					if(skill.HEKHODDJHAO_P1 > 0)
					{
						KFCIIMBBNCD k = _LKMHPJKIFDN_md.FOFADHAENKC_Skill.PEPLECGHBFA_SceneEffectInfo[skill.HEKHODDJHAO_P1 - 1];
						if (_NDFIEMPPMLF_master.FAHLEOKHBGH_TargetUnitConditionValue == k.INDDJNMPONH_type)
							return true;
					}
					if(skill.AKGNPLBDKLN_P2 > 0)
					{
						KFCIIMBBNCD k = _LKMHPJKIFDN_md.FOFADHAENKC_Skill.PEPLECGHBFA_SceneEffectInfo[skill.AKGNPLBDKLN_P2 - 1];
						if (_NDFIEMPPMLF_master.FAHLEOKHBGH_TargetUnitConditionValue == k.INDDJNMPONH_type)
							return true;
					}
				}
				return false;
			case 11:
				if (defaultUnit.FDBOPFEOENF_diva[0].DIPKCALNIII_diva_id == 0)
					return false;
				if (defaultUnit.FDBOPFEOENF_diva[0].EBDNICPAFLB_s_slot[0] != 0)
				{
					MLIBEPGADJH_Scene.KKLDOOJBJMN saveScene = BLPGDHGACAJ[defaultUnit.FDBOPFEOENF_diva[0].EBDNICPAFLB_s_slot[0] - 1];
					int HGONFBDIBPM_ActiveSkillId = saveScene.PBEPKDEEBBK_AS;
					MMPBPOIFDAF_Scene.PMKOFEIONEG dbScene = _LDEGEHAEALK_ServerData.PNLOINMCCKH_Scene.OPIBAPEGCLA_Scenes[defaultUnit.FDBOPFEOENF_diva[0].EBDNICPAFLB_s_slot[0] - 1];
					if(dbScene.JPIPENJGGDD_NumBoard < 2)
					{
						if (HGONFBDIBPM_ActiveSkillId == 0)
							return false;
					}
					else
					{
						HGONFBDIBPM_ActiveSkillId = saveScene.ECKJJCGPOPN_AS2;
						if(HGONFBDIBPM_ActiveSkillId == 0)
						{
							HGONFBDIBPM_ActiveSkillId = saveScene.PBEPKDEEBBK_AS;
							if (HGONFBDIBPM_ActiveSkillId == 0)
								return false;
						}
					}
					CDNKOFIELMK skill = _LKMHPJKIFDN_md.FOFADHAENKC_Skill.PABCHCAAEAA_ActiveSkills.Find((CDNKOFIELMK _GHPLINIACBB_x) =>
					{
						//0x16A9660
						return _GHPLINIACBB_x.DDMENKOHCGM_aid == HGONFBDIBPM_ActiveSkillId;
					});
					if (skill == null)
						return false;
					for(int i = 0; i < skill.EGLDFPILJLG_SkillBuffEffect.Length; i++)
					{
						if (skill.EGLDFPILJLG_SkillBuffEffect[i] == _NDFIEMPPMLF_master.FHILEEHDDKN_TargetUnitConditionId)
							return true;
					}
				}
				return false;
			default:
				return true;
			case 12:
				int v = 0;
				if(OMNOFMEBLAD != null && OMNOFMEBLAD.JBCKLEMCEBD_LiveSkillActivateCount != null)
				{
					for(int i = 0; i < defaultUnit.FDBOPFEOENF_diva.Count; i++)
					{
						if(defaultUnit.FDBOPFEOENF_diva[i].DIPKCALNIII_diva_id != 0)
						{
							for(int j = 0; j < defaultUnit.FDBOPFEOENF_diva[i].EBDNICPAFLB_s_slot.Length; j++)
							{
								int a = defaultUnit.FDBOPFEOENF_diva.Count * i * j;
								if(OMNOFMEBLAD.JBCKLEMCEBD_LiveSkillActivateCount[a] > 0)
								{
									PPGHMBNIAEC skill = _LKMHPJKIFDN_md.FOFADHAENKC_Skill.PNJMFKFGIML_LiveSkills[defaultUnit.FDBOPFEOENF_diva[i].EBDNICPAFLB_s_slot[j] - 1];
									bool b = false;
									for(int k = 0; k < skill.EGLDFPILJLG_SkillBuffEffect.Length; k++)
									{
										b |= skill.EGLDFPILJLG_SkillBuffEffect[k] == _NDFIEMPPMLF_master.FHILEEHDDKN_TargetUnitConditionId;
									}
									if(b)
									{
										v += OMNOFMEBLAD.JBCKLEMCEBD_LiveSkillActivateCount[a];
									}
								}
							}
						}
					}
				}
				return _NDFIEMPPMLF_master.FHILEEHDDKN_TargetUnitConditionId <= v;
			case 13:
				{
					int v1 = defaultUnit.CJJIHFDLNMJ_CountForEachDivaScene((int _AHHJLDLAPAN_DivaId, int _BCCHOBPJJKE_SceneId) =>
					{
						//0x16A9420
						return BLPGDHGACAJ[_BCCHOBPJJKE_SceneId - 1].AIHCEGFANAM_SerieAttr == XeApp.Game.Common.SeriesAttr.Type.Delta;
					});
					int v2 = defaultUnit.CJJIHFDLNMJ_CountForEachDivaScene((int _AHHJLDLAPAN_DivaId, int _BCCHOBPJJKE_SceneId) =>
					{
						//0x16A94C8
						return BLPGDHGACAJ[_BCCHOBPJJKE_SceneId - 1].AIHCEGFANAM_SerieAttr == XeApp.Game.Common.SeriesAttr.Type.Frontia;
					});
					int v3 = defaultUnit.CJJIHFDLNMJ_CountForEachDivaScene((int _AHHJLDLAPAN_DivaId, int _BCCHOBPJJKE_SceneId) =>
					{
						//0x16A9578
						return BLPGDHGACAJ[_BCCHOBPJJKE_SceneId - 1].AIHCEGFANAM_SerieAttr == XeApp.Game.Common.SeriesAttr.Type.Seven;
					});
					if(_NDFIEMPPMLF_master.FHILEEHDDKN_TargetUnitConditionId < v1)
					{
						if(_NDFIEMPPMLF_master.FHILEEHDDKN_TargetUnitConditionId < v2)
						{
							return _NDFIEMPPMLF_master.FHILEEHDDKN_TargetUnitConditionId < v3;
						}
					}
					return false;
				}
		}
	}

	// // RVA: 0x16A5134 Offset: 0x16A5134 VA: 0x16A5134
	private static bool LBOCNEHCMLB(OKGLGHCBCJP_Database _LKMHPJKIFDN_md, BBHNACPENDM_ServerSaveData _LDEGEHAEALK_ServerData, AKIIJBEJOEP _NDFIEMPPMLF_master, JGEOBNENMAH.HAJIFNABIFF OMNOFMEBLAD, IKDICBBFBMI_EventBase LIKDEHHKFEH, int _OIPCCBHIKIA_index, long LPEKHFOMCAH)
	{
		if (_LKMHPJKIFDN_md == null || _LDEGEHAEALK_ServerData == null)
			return false;
		if (_NDFIEMPPMLF_master == null || LIKDEHHKFEH == null)
			return false;
		int aa3 = _NDFIEMPPMLF_master.GHCDDKIBJGK(_OIPCCBHIKIA_index);
		int aa4 = _NDFIEMPPMLF_master.KJFKPGABANO(_OIPCCBHIKIA_index);
		switch(_NDFIEMPPMLF_master.GONJEDOAPFJ(_OIPCCBHIKIA_index))
		{
			case 18:
				{
					int cnt = 0;
					for(int i = 0; i < _LDEGEHAEALK_ServerData.DGCJCAHIAPP_Diva.NBIGLBMHEDC_DivaList.Count; i++)
					{
						if(_LDEGEHAEALK_ServerData.DGCJCAHIAPP_Diva.NBIGLBMHEDC_DivaList[i].CPGFPEDMDEH_have > 0)
							cnt++;
						if(cnt >= aa3)
							return true;
					}
				}
				return false;
			case 19:
				return aa3 <= BJHFBOMILHG(_NDFIEMPPMLF_master, LIKDEHHKFEH, LPEKHFOMCAH);
			case 20:
				{
					List<IKCGAJKCPFN> l = new List<IKCGAJKCPFN>();
					for(int i = 0; i < LIKDEHHKFEH.AGLILDLEFDK_Missions.Count; i++)
					{
						if((LIKDEHHKFEH.AGLILDLEFDK_Missions[i].KJBGCLPMLCG_OpenedAt == 0 && LIKDEHHKFEH.AGLILDLEFDK_Missions[i].GJFPFFBAKGK_CloseAt == 0) ||
						(LPEKHFOMCAH >= LIKDEHHKFEH.AGLILDLEFDK_Missions[i].KJBGCLPMLCG_OpenedAt && LPEKHFOMCAH < LIKDEHHKFEH.AGLILDLEFDK_Missions[i].GJFPFFBAKGK_CloseAt))
						{
							if(LIKDEHHKFEH.AGLILDLEFDK_Missions[i].GBJFNGCDKPM_typ == 2)
							{
								if(LIKDEHHKFEH.OLDFFDMPEBM_Quests[i].EALOBDHOCHP_stat > 0)
								{
									l.Add(LIKDEHHKFEH.OLDFFDMPEBM_Quests[i]);
								}
							}
						}
					}
					for(int i = 0; i < l.Count; i++)
					{
						if(l[i].EALOBDHOCHP_stat == 1)
						{
							if(l[i].PPFNGGCBJKC_id != _NDFIEMPPMLF_master.PPFNGGCBJKC_id)
								return false;
						}
					}
					return true;
				}
			case 21:
				if(LIKDEHHKFEH.HIDHLFCBIDE_EventType != OHCAABOMEOF.KGOGMKMBCPP_EventType.ENPJADLIFAB_EventSp)
					return false;
				{
					KNKDBNFMAKF_EventSp ev = LIKDEHHKFEH as KNKDBNFMAKF_EventSp;
					return aa3 <= ev.CAHDMMAHEJC_GetDivaTouchCount();
				}
			default:
				if(OMNOFMEBLAD == null)
					return false;
				if(_NDFIEMPPMLF_master.HMOJCCPIPBP_TargetMusicType == 4)
				{
					List<int> l = LIKDEHHKFEH.HEACCHAKMFG_GetMusicsList();
					if(l != null && l.Count > 0)
					{
						if(!LLNJFONIECK_EventSpOrGacha(LIKDEHHKFEH.HIDHLFCBIDE_EventType) && OMNOFMEBLAD.OEILJHENAHN_PlayEventType != (int)LIKDEHHKFEH.HIDHLFCBIDE_EventType)
						{
							return false;
						}
					}
				}
				//LKMHPJKIFDN_md.IBPAFKKEKNK_Music
				break;
			case 26:
				if(LIKDEHHKFEH.HIDHLFCBIDE_EventType != OHCAABOMEOF.KGOGMKMBCPP_EventType.ENPJADLIFAB_EventSp)
					return false;
				{
					KNKDBNFMAKF_EventSp ev = LIKDEHHKFEH as KNKDBNFMAKF_EventSp;
					return aa3 <= ev.ACEEBCPOEBF_GetDivaCount((JJOELIOGMKK_DivaIntimacyInfo.OPOEENHEJOC_CounterType)aa4);
				}
			case 27:
			case 28:
			case 34:
			case 36:
				if(OMNOFMEBLAD != null)
					return false;
				if(LIKDEHHKFEH.HIDHLFCBIDE_EventType != OHCAABOMEOF.KGOGMKMBCPP_EventType.CADKONMJEDA_11_EventRaid)
					return false;
				{
					PKNOKJNLPOE_EventRaid ev = LIKDEHHKFEH as PKNOKJNLPOE_EventRaid;
					if(_NDFIEMPPMLF_master.JJECMJFDEEP_ClearConditionValue == 0)
						return true;
					return _NDFIEMPPMLF_master.JJECMJFDEEP_ClearConditionValue == ev.MCEJJBANCDA.INDDJNMPONH_type;
				}
			case 30:
			case 31:
			case 32:
			case 33:
			case 35:
				return OMNOFMEBLAD == null;
			case 41:
				if(OMNOFMEBLAD != null)
					return false;
				if(LIKDEHHKFEH.HIDHLFCBIDE_EventType != OHCAABOMEOF.KGOGMKMBCPP_EventType.BNECMLPHAGJ_EventGoDiva)
					return false;
				{
					MANPIONIGNO_EventGoDiva ev = LIKDEHHKFEH as MANPIONIGNO_EventGoDiva;
					return (ev.CMCEGEKGEEP.MKMIEGPOKGG_Soul.CIEOBFIIPLD_Level - ev.CMCEGEKGEEP.MKMIEGPOKGG_Soul.KFEMFDFPCGO_Level0) > 0;
				}
			case 42:
				if(OMNOFMEBLAD != null)
					return false;
				if(LIKDEHHKFEH.HIDHLFCBIDE_EventType != OHCAABOMEOF.KGOGMKMBCPP_EventType.BNECMLPHAGJ_EventGoDiva)
					return false;
				{
					MANPIONIGNO_EventGoDiva ev = LIKDEHHKFEH as MANPIONIGNO_EventGoDiva;
					return (ev.CMCEGEKGEEP.EACDINDLGLF_Voice.CIEOBFIIPLD_Level - ev.CMCEGEKGEEP.EACDINDLGLF_Voice.KFEMFDFPCGO_Level0) > 0;
				}
			case 43:
				if(OMNOFMEBLAD != null)
					return false;
				if(LIKDEHHKFEH.HIDHLFCBIDE_EventType != OHCAABOMEOF.KGOGMKMBCPP_EventType.BNECMLPHAGJ_EventGoDiva)
					return false;
				{
					MANPIONIGNO_EventGoDiva ev = LIKDEHHKFEH as MANPIONIGNO_EventGoDiva;
					return (ev.CMCEGEKGEEP.LDLHPACIIAB_Charm.CIEOBFIIPLD_Level - ev.CMCEGEKGEEP.LDLHPACIIAB_Charm.KFEMFDFPCGO_Level0) > 0;
				}
			case 49:
				{
					if(OMNOFMEBLAD != null)
						return false;
					if(LIKDEHHKFEH.HIDHLFCBIDE_EventType != OHCAABOMEOF.KGOGMKMBCPP_EventType.DAMDPLEBNCB_AprilFool)
						return false;
					AMLGMLNGMFB_EventAprilFool evApril = LIKDEHHKFEH as AMLGMLNGMFB_EventAprilFool;
					return evApril.MMICFFPMHIC.BCGLDMKODLC_IsClear;
				}
		}
        KEODKEGFDLD_FreeMusicInfo fminfo = _LKMHPJKIFDN_md.IBPAFKKEKNK_Music.NOBCLJIAMLC_GetFreeMusicData(OMNOFMEBLAD.GHBPLHBNMBK_FreeMusicId);
        switch (_NDFIEMPPMLF_master.GONJEDOAPFJ(_OIPCCBHIKIA_index))
		{
			case 0:
			case 1:
			case 13:
				return true;
			case 2:
				if(Database.Instance.gameSetup.EnableLiveSkip)
					return false;
				return aa3 <= OMNOFMEBLAD.NLKEBAOBJCM_combo;
			case 3:
				return aa3 <= fminfo.EMJCHPDJHEI(OMNOFMEBLAD.LFGNLKKFOCD_IsLine6, OMNOFMEBLAD.AKNELONELJK_difficulty).DLPBHJALHCK_GetScoreRank(OMNOFMEBLAD.KNIFCANOHOC_score);
			case 4:
				return aa3 <= OMNOFMEBLAD.KNIFCANOHOC_score;
			case 5:
				return aa3 <= OMNOFMEBLAD.JNNDFGPMEDA_Fold;
			case 6:
				return LIKDEHHKFEH.FBGDBGKNKOD_GetCurrentPoint() >= aa3;
			case 7:
				if(OMNOFMEBLAD.HGEKDNNJAAC_AwakenDivaMode)
					return true;
				return OMNOFMEBLAD.OOOGNIPJMDE_HadDivaMode;
			case 8:
				return OMNOFMEBLAD.HGEKDNNJAAC_AwakenDivaMode;
			case 9:
				{
					if(OMNOFMEBLAD.OJFNDOIFOOE_NoteResultCount == null)
						return false;
					int v = 0;
					for(int i = 0; i < OMNOFMEBLAD.OJFNDOIFOOE_NoteResultCount.Count; i++)
					{
						if(_NDFIEMPPMLF_master.DEIEONIILLJ_ClearConditionId <= i)
						{
							v += OMNOFMEBLAD.OJFNDOIFOOE_NoteResultCount[i];
						}
					}
					return aa3 <= v;
				}
			case 10:
				{
					if(OMNOFMEBLAD.OJFNDOIFOOE_NoteResultCount == null)
						return false;
					int v = 0;
					for(int i = 0; i < OMNOFMEBLAD.OJFNDOIFOOE_NoteResultCount.Count; i++)
					{
						if(_NDFIEMPPMLF_master.DEIEONIILLJ_ClearConditionId <= i)
						{
							v += OMNOFMEBLAD.OJFNDOIFOOE_NoteResultCount[i];
						}
					}
					return v <= aa3;
				}
			case 11:
				if(OMNOFMEBLAD.IPEKDLNEOFI_para_life == 0)
					return false;
				return aa3 <= OMNOFMEBLAD.JKPPKAHPPKH_life * 100 / OMNOFMEBLAD.IPEKDLNEOFI_para_life;
			case 12:
				if(Database.Instance.gameSetup.EnableLiveSkip)
					return false;
				return OMNOFMEBLAD.LCOHGOIDMDF_ComboRank != 0;
			case 14:
				if(LIKDEHHKFEH.HIDHLFCBIDE_EventType != OHCAABOMEOF.KGOGMKMBCPP_EventType.PFKOKHODEGL_EventBattle)
					return false;
				{
					HAEDCCLHEMN_EventBattle ev = LIKDEHHKFEH as HAEDCCLHEMN_EventBattle;
					//LAB_016a6ab8
					return ev.CKCPAMDDNPF.DPCFADCFMOA_Win;
				}
			case 15:
				if(LIKDEHHKFEH.HIDHLFCBIDE_EventType == OHCAABOMEOF.KGOGMKMBCPP_EventType.PFKOKHODEGL_EventBattle)
				{
					HAEDCCLHEMN_EventBattle ev = LIKDEHHKFEH as HAEDCCLHEMN_EventBattle;
					if(aa3 <= ev.CKCPAMDDNPF.PGNECHOCIAN_CWinMax)
						return true;
				}
				break;
			case 16:
				if(LIKDEHHKFEH.HIDHLFCBIDE_EventType != OHCAABOMEOF.KGOGMKMBCPP_EventType.PFKOKHODEGL_EventBattle)
					return false;
				if(aa3 < 1)
					return false;
				{
					HAEDCCLHEMN_EventBattle ev = LIKDEHHKFEH as HAEDCCLHEMN_EventBattle;
					if(ev.CKCPAMDDNPF.JIMGIIBCABI_ScoreResultRank != aa3 - 1)
						return false;
					//LAB_016a6ab8
					return ev.CKCPAMDDNPF.DPCFADCFMOA_Win;
				}
			case 17:
				if(LIKDEHHKFEH.HIDHLFCBIDE_EventType == OHCAABOMEOF.KGOGMKMBCPP_EventType.NKDOEBONGNI_EventMission)
				{
					KPJHLACKGJF_EventMission ev = LIKDEHHKFEH as KPJHLACKGJF_EventMission;
					KPJHLACKGJF_EventMission.OPFEKMKHEIF d = ev.FHPEAPEANAI;
					if(d == null)
						return false;
					if(d.BCGLDMKODLC_IsClear)
					{
						if(aa3 == 0)
							return true;
						if(aa3 == ev.JKCBFOAHNGL_Mid)
							return true;
					}
				}
				break;
			case 22:
				if(Database.Instance.gameSetup.EnableLiveSkip)
					return false;
				return _NDFIEMPPMLF_master.JJECMJFDEEP_ClearConditionValue <= fminfo.EMJCHPDJHEI(OMNOFMEBLAD.LFGNLKKFOCD_IsLine6, OMNOFMEBLAD.AKNELONELJK_difficulty).CCFAAPPKILD_GetRankCombo(OMNOFMEBLAD.NLKEBAOBJCM_combo);
			case 23:
				if(LIKDEHHKFEH.HIDHLFCBIDE_EventType != OHCAABOMEOF.KGOGMKMBCPP_EventType.PFKOKHODEGL_EventBattle)
					return false;
				{
					HAEDCCLHEMN_EventBattle ev = LIKDEHHKFEH as HAEDCCLHEMN_EventBattle;
					if(ev.KKMFHMGIIKN_GetCls() < aa4)
					{
						return false;
					}
					if(aa3 != 0)
					{
						if(ev.CKCPAMDDNPF.JIMGIIBCABI_ScoreResultRank != aa3 - 1)
							return false;
					}
					//LAB_016a6ab8
					return ev.CKCPAMDDNPF.DPCFADCFMOA_Win;
				}
			case 24:
				if(OMNOFMEBLAD.KNIFCANOHOC_score == -1)
				{
					if(!OMNOFMEBLAD.OBOPMHBPCFE_MvMode)
						return aa4 != 1;
					else
						return aa4 != 0;
				}
				break;
			case 25:
				if(OMNOFMEBLAD.KNIFCANOHOC_score == -1)
				{
					if(!OMNOFMEBLAD.OBOPMHBPCFE_MvMode)
					{
						if(aa4 == 1)
							return false;
					}
					else
					{
						if(aa4 == 0)
							return false;
					}
					for(int i = 0; i < OMNOFMEBLAD.HNHCIGMKPDC_DivaIds.Count; i++)
					{
						if(OMNOFMEBLAD.HNHCIGMKPDC_DivaIds[i] > 0)
						{
                            DEKKMGAFJCG_Diva.MNNLOBDPCCH_DivaInfo d = _LDEGEHAEALK_ServerData.DGCJCAHIAPP_Diva.LGKFMLIOPKL_GetDivaInfo(OMNOFMEBLAD.HNHCIGMKPDC_DivaIds[i]);
                            LCLCCHLDNHJ_Costume.ILODJKFJJDO_CostumeInfo cos = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.MFPNGNMFEAL_Costume.LBDOLHGDIEB_Find(OMNOFMEBLAD.HNHCIGMKPDC_DivaIds[i], d.BEEAIAAJOHD_CostumeId);
							if(cos != null && cos.JPIDIENBGKH_CostumeId > 0 && cos.JPIDIENBGKH_CostumeId == aa3)
								return true;
                        }
					}
				}
				break;
			case 29:
				if(LIKDEHHKFEH.HIDHLFCBIDE_EventType == OHCAABOMEOF.KGOGMKMBCPP_EventType.CADKONMJEDA_11_EventRaid)
				{
					PKNOKJNLPOE_EventRaid ev = LIKDEHHKFEH as PKNOKJNLPOE_EventRaid;
					if(_NDFIEMPPMLF_master.JJECMJFDEEP_ClearConditionValue == 0)
						return true;
					return _NDFIEMPPMLF_master.JJECMJFDEEP_ClearConditionValue == (int)ev.CFLEMFADGLG_AttackType;
				}
				break;
			case 37:
				return OMNOFMEBLAD.OEILJHENAHN_PlayEventType > 0;
			case 38:
				if(Database.Instance.gameSetup.EnableLiveSkip)
					return false;
				if(OMNOFMEBLAD.OEILJHENAHN_PlayEventType < 1)
					return false;
				return OMNOFMEBLAD.LCOHGOIDMDF_ComboRank != 0;
			case 39:
				if(OMNOFMEBLAD.OEILJHENAHN_PlayEventType < 1)
					return false;
				return aa3 <= fminfo.EMJCHPDJHEI(OMNOFMEBLAD.LFGNLKKFOCD_IsLine6, OMNOFMEBLAD.AKNELONELJK_difficulty).DLPBHJALHCK_GetScoreRank(OMNOFMEBLAD.KNIFCANOHOC_score);
			case 40:
				if(OMNOFMEBLAD.OEILJHENAHN_PlayEventType < 1)
					return false;
				return aa3 <= OMNOFMEBLAD.KNIFCANOHOC_score;
			case 44:
				if(LIKDEHHKFEH.HIDHLFCBIDE_EventType != OHCAABOMEOF.KGOGMKMBCPP_EventType.BNECMLPHAGJ_EventGoDiva)
					return false;
				{
					MANPIONIGNO_EventGoDiva ev = LIKDEHHKFEH as MANPIONIGNO_EventGoDiva;
					return ev.CMCEGEKGEEP.JGBIFJLPCHM_IsBonusStart;
				}
			case 45:
				if(OMNOFMEBLAD.OEILJHENAHN_PlayEventType != (int)LIKDEHHKFEH.HIDHLFCBIDE_EventType)
					return false;
				return OMNOFMEBLAD.OEILJHENAHN_PlayEventType > 0;
			case 46:
				if(OMNOFMEBLAD.OEILJHENAHN_PlayEventType != (int)LIKDEHHKFEH.HIDHLFCBIDE_EventType)
					return false;
				if(Database.Instance.gameSetup.EnableLiveSkip)
					return false;
				if(OMNOFMEBLAD.OEILJHENAHN_PlayEventType < 1)
					return false;
				return OMNOFMEBLAD.LCOHGOIDMDF_ComboRank != 0;
			case 47:
				if(OMNOFMEBLAD.OEILJHENAHN_PlayEventType != (int)LIKDEHHKFEH.HIDHLFCBIDE_EventType)
					return false;
				if(OMNOFMEBLAD.OEILJHENAHN_PlayEventType < 1)
					return false;
				return aa3 <= fminfo.EMJCHPDJHEI(OMNOFMEBLAD.LFGNLKKFOCD_IsLine6, OMNOFMEBLAD.AKNELONELJK_difficulty).DLPBHJALHCK_GetScoreRank(OMNOFMEBLAD.KNIFCANOHOC_score);
			case 48:
				if(OMNOFMEBLAD.OEILJHENAHN_PlayEventType != (int)LIKDEHHKFEH.HIDHLFCBIDE_EventType)
					return false;
				if(OMNOFMEBLAD.OEILJHENAHN_PlayEventType < 1)
					return false;
				return aa3 <= OMNOFMEBLAD.KNIFCANOHOC_score;
		}
		return false;
	}

	// // RVA: 0x16A84F8 Offset: 0x16A84F8 VA: 0x16A84F8
	// private static bool EFIBGMJACOK(JGEOBNENMAH.HAJIFNABIFF OMNOFMEBLAD) { }

	// // RVA: 0x16A8528 Offset: 0x16A8528 VA: 0x16A8528
	public static int GHAJJNPENFI(OKGLGHCBCJP_Database _LKMHPJKIFDN_md, BBHNACPENDM_ServerSaveData _LDEGEHAEALK_ServerData, AKIIJBEJOEP _NDFIEMPPMLF_master, List<int> DBEHMKDDKHM)
	{
		switch(_NDFIEMPPMLF_master.HMOJCCPIPBP_TargetMusicType)
		{
			case 0:
				if(DBEHMKDDKHM.Count == 0)
					return 0;
				return DBEHMKDDKHM[UnityEngine.Random.Range(0, DBEHMKDDKHM.Count)];
			case 1:
				if(DBEHMKDDKHM.Count == 0)
					return 0;
				if(_NDFIEMPPMLF_master.HBJJCDIMOPO_TargetMusicConditionId != 0)
				{
					//LAB_016a8cd0
					return _NDFIEMPPMLF_master.HBJJCDIMOPO_TargetMusicConditionId;
				}
				if(DBEHMKDDKHM.Count == 0)
					return 0;
				//LAB_016a8d80
				return DBEHMKDDKHM[0];
			case 2:
				{
					List<int> l = new List<int>();
					for(int i = 0; i < DBEHMKDDKHM.Count; i++)
					{
                        KEODKEGFDLD_FreeMusicInfo fInfo = _LKMHPJKIFDN_md.IBPAFKKEKNK_Music.NOBCLJIAMLC_GetFreeMusicData(DBEHMKDDKHM[i]);
                        EONOEHOKBEB_Music mInfo = _LKMHPJKIFDN_md.IBPAFKKEKNK_Music.IAJLOELFHKC_GetMusicInfo(fInfo.DLAEJOBELBH_MusicId);
						if(_NDFIEMPPMLF_master.HBJJCDIMOPO_TargetMusicConditionId == mInfo.FKDCCLPGKDK_JacketAttr)
						{
							l.Add(DBEHMKDDKHM[i]);
						}
                    }
					if(l.Count == 0)
					{
						if(_NDFIEMPPMLF_master.HBJJCDIMOPO_TargetMusicConditionId == 0)
						{
							if(DBEHMKDDKHM.Count == 0)
								return 0;
							//LAB_016a8d80
							return DBEHMKDDKHM[0];
						}
					}
					int r = UnityEngine.Random.Range(0, l.Count);
					return l[r];
				}
			case 3:
				{
					List<int> l = new List<int>();
					for(int i = 0; i < DBEHMKDDKHM.Count; i++)
					{
                        KEODKEGFDLD_FreeMusicInfo fInfo = _LKMHPJKIFDN_md.IBPAFKKEKNK_Music.NOBCLJIAMLC_GetFreeMusicData(DBEHMKDDKHM[i]);
                        EONOEHOKBEB_Music mInfo = _LKMHPJKIFDN_md.IBPAFKKEKNK_Music.IAJLOELFHKC_GetMusicInfo(fInfo.DLAEJOBELBH_MusicId);
						if(_NDFIEMPPMLF_master.HBJJCDIMOPO_TargetMusicConditionId == mInfo.AIHCEGFANAM_SerieAttr)
						{
							l.Add(DBEHMKDDKHM[i]);
						}
                    }
					if(l.Count == 0)
					{
						if(_NDFIEMPPMLF_master.HBJJCDIMOPO_TargetMusicConditionId == 0)
						{
							if(DBEHMKDDKHM.Count == 0)
								return 0;
							//LAB_016a8d80
							return DBEHMKDDKHM[0];
						}
					}
					int r = UnityEngine.Random.Range(0, l.Count);
					return l[r];
				}
			case 4:
				if(_NDFIEMPPMLF_master.HBJJCDIMOPO_TargetMusicConditionId != 0)
				{
					KEODKEGFDLD_FreeMusicInfo fInfo = _LKMHPJKIFDN_md.IBPAFKKEKNK_Music.NOBCLJIAMLC_GetFreeMusicData(_NDFIEMPPMLF_master.HBJJCDIMOPO_TargetMusicConditionId);
					if(fInfo != null && fInfo.PPEGAKEIEGM_Enabled == 2)
					{
						//LAB_016a8cd0
						return _NDFIEMPPMLF_master.HBJJCDIMOPO_TargetMusicConditionId;
					}
				}
				return 0;
			default:
				return 0;
		}
	}

	// // RVA: 0x16A8240 Offset: 0x16A8240 VA: 0x16A8240
	public static int BJHFBOMILHG(AKIIJBEJOEP _NDFIEMPPMLF_master, IKDICBBFBMI_EventBase LIKDEHHKFEH, long LPEKHFOMCAH)
	{
		int a = 0;
		if(LIKDEHHKFEH.HIDHLFCBIDE_EventType == OHCAABOMEOF.KGOGMKMBCPP_EventType.ENPJADLIFAB_EventSp)
		{
			KNKDBNFMAKF_EventSp ev = LIKDEHHKFEH as KNKDBNFMAKF_EventSp;
			if(ev != null)
				a = ev.MEDEJHKNAFG_GetCurrentMissionGroup(LPEKHFOMCAH);
		}
		int a1 = 0;
		for(int i = 0; i < LIKDEHHKFEH.OLDFFDMPEBM_Quests.Count; i++)
		{
			if(LIKDEHHKFEH.OLDFFDMPEBM_Quests[i].EALOBDHOCHP_stat > 1)
			{
				if(_NDFIEMPPMLF_master.PPFNGGCBJKC_id != LIKDEHHKFEH.OLDFFDMPEBM_Quests[i].PPFNGGCBJKC_id)
				{
					if(i < LIKDEHHKFEH.AGLILDLEFDK_Missions.Count)
					{
						if(LIKDEHHKFEH.AGLILDLEFDK_Missions[i].KGICDMIJGDF_Group != a)
							continue;
					}
					a1++;
				}
			}
		}
		return a1;
	}

}
