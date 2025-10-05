
using System.Collections.Generic;
using UnityEngine;
using XeApp.Game.Common;

public class ILLPDLODANB
{
	public enum LOEGALDKHPL_ValueType
	{
		HJNNKCMLGFL_0_None = 0,
		APCJDBPNMLN_1_DailyClear = 1,
		JDBOFJKBJNK_2_DailyScoreRank = 2,
		OCGOGBEIHPD_3_DailyNumSkillActive = 3,
		HCKOEGLNAJH_4_DailyGacha = 4,
		FCNKHKLIIGH_5_DailySuperDivaMode = 5,
		DCFBLGLFJDO_6_DailyMissionCompleted = 6,
		NOMJEIEDKML_7_StoryCompleted = 7,
		GIEOJGGBODI_8_TotalMusicClear = 8,
		ABDCDIGADHD_9_TotalSerieClear = 9,
		LOGACAKHGBL_10_TotalDiffClear = 10,
		HPNKPGICCMK_11_TotalPerf = 11,
		OMEOCCEFCOB_12_TotalCombo = 12,
		JHEMKMOJBDO_13_TotalSS = 13,
		GCMANDIOBFN_14_PlayerLevel = 14,
		MMOGNIPPMDO_15_DivaLevel = 15,
		CHPEIDMDNFP_16_NumScene = 16,
		ECOEJFBAABC_17_NumSceneAtLevel = 17,
		DGILGEFLNCF_18_TotalUc = 18,
		ODDEKPGKLJA_19_NumMissionsDone = 19,
		GKHJKFJFAHO_20_UnlockedEpisode = 20,
		FJPCGKGPKPE_21_NumValkMode = 21,
		NKKFJIPJKAO_22_NumSuperDivaMode = 22,
		OGCMIONDMHB_23_MaxScore = 23,
		OLPLKIAHMOG_24_PlatformLinked = 24,
		LAFFLNEDNDO_25_NormalQuestDone = 25, // openquesturl
		HDJGNKOIMOH_26_MissionChangeProfilComment = 26, // profil
		OKEIMJEMKKJ_27_MissionSendFriendRequest = 27,
		NDHANBGPBBP_28_NumSns = 28,
		BHINHMNCMKC_29_TotalMk = 29,
		IDLHNACLCLG_30_TotalMedal = 30,
		DBAKKHLLCNC_31_TotalShop = 31,
		BFIIIGLDKNN_33_NumLeaf = 33,
		CJKGEAFKKFL_34_UtaRateTotal = 34,
		BDJBKMFEHHC_40_DebutMission0 = 40,
		LBKOGDGCFCM_41_DebutMission1Story = 41, // story
		MCBICLJIJMK_42_DebutMission2PlateUpgrade = 42, // sceneabilityrelease
		FMOCAEEMHFJ_43_DebutMission3Story = 43, // story
		GNLPMEDLIJJ_44_DebutMission4TeamEdit = 44, // team edit
		PEPILDAEIEL_45_DebutMission5Sns = 45, // sns
		PBKOKCHKGGL_46_DebugMission6 = 46,
		IDAIIJEMNMP_47_Gacha = 47,
		AFLMHBMBNBO_48_DebutMission7TeamEdit = 48, // team edit
		DDGKOJFPGFF_49_DebutMission8 = 49,
		NEIJFCOANMA_50_DebutMissoin9 = 50, // episode select
		NEMNEDBLJEM_51_MissionPlaySongWithNotDefaultCostume = 51,
		OECOMFPCPAI_52_DebutMissionDone = 52,
		LOKMFLKHIPG_53_TotalCosu = 53,
		NMBILGNHKFC_54_TotalVOp = 54,
		KKIEICKBEEF_55_TotalDop = 55,
		FMGMIOKOPKP_56_TotalSns = 56,
		JCHPMNHJPKG_57_NumOfferTutoDone = 57,
		AJLNMHBKMLE_58_NumCostumeTutoDone = 58, // ? offer
		BBOGLGJCAGE_59_TotalLiveSkill = 59,
		OECPMGEPMHC_60_ = 60, // eventmuiccond
		CKENLOAPCEC_61_ = 61, // home
		BHJDMGFAPLG = 62, // sceneabilityrelease
		JHMKDDGIGAA = 63,
		MEMMJNAKOHB = 64,
		HIFAMABBNIE = 65, // episode select
		CKOOMMACNKA = 66, // gakuya
		DOIFAGIGLEE = 67, // gakuya
		MLMDDOJOPFC = 68,
		ADDCIMFHNAE = 69,
		HDHEKLONOGD = 70, // costume upgrade
		LEFBLIEIELJ = 71,
		MOKJAMEPIMK = 72, // somthing music weekly
		CHANJDIDJOH = 73, // Something free music
		CFDPIBHFFPD_74_TutoDecoDone = 74,
		LANICCFBKAI_75_TotalDecoShop = 75,
		BJHMIGMHOCE_76_TotalDecoPoint = 76,
		NCOHGNCGFJC_77_TutoValkUpgradeDone = 77,
		MENBLIKPJMC_78_TotalValkUpgrade = 78,
		JAMJLBCKHHB_79_GoDivaMaxSoulLevel = 79,
		BFHKNEJHFLH_80_GoDivaMaxVoiceLevel = 80,
		HOHJCNDMDCD_81_GoDivaMaxChamLevel = 81,
		ANALBHDNGKP = 82, // gacha
		AIKOJFKHPMO = 83, // something event
		FJCFIBPGLDG = 84, // something daily mission
		DNLGEBHGKGL = 85, // somthing mission
		EMKEFFFNBGG = 86, // something event
		LHBGGMLDOHH = 87, // Shop
		LMFBIGPJMFM = 88, // gacha
		PAGIHFIMLCK = 89, // sceneabilityrelease
	}

	private static LOEGALDKHPL_ValueType NNLCKKMJPLJ; // 0x0

	//// RVA: 0x9F1AF4 Offset: 0x9F1AF4 VA: 0x9F1AF4
	public static bool HHMKDAIGMKC_IsDebutMission(LOEGALDKHPL_ValueType _INDDJNMPONH_type)
	{
		return _INDDJNMPONH_type >= LOEGALDKHPL_ValueType.BDJBKMFEHHC_40_DebutMission0/*40*/ && _INDDJNMPONH_type < LOEGALDKHPL_ValueType.LOKMFLKHIPG_53_TotalCosu/*53*/;
	}

	//// RVA: 0x9F1B08 Offset: 0x9F1B08 VA: 0x9F1B08
	public static void IHKAKFFAGPC(LOEGALDKHPL_ValueType _INDDJNMPONH_type)
	{
		NNLCKKMJPLJ = _INDDJNMPONH_type;
	}

	//// RVA: 0x9F1B98 Offset: 0x9F1B98 VA: 0x9F1B98
	public static bool DDJGDCHMCBN(LOEGALDKHPL_ValueType _INDDJNMPONH_type)
	{
		if(NNLCKKMJPLJ != LOEGALDKHPL_ValueType.HJNNKCMLGFL_0_None/*0*/)
		{
			return _INDDJNMPONH_type == NNLCKKMJPLJ;
		}
		return false;
	}

	//// RVA: 0x9F1C78 Offset: 0x9F1C78 VA: 0x9F1C78
	public static void ILOGJDALEOO()
	{
		IHKAKFFAGPC(LOEGALDKHPL_ValueType.HJNNKCMLGFL_0_None);
	}

	//// RVA: 0x9F1CF4 Offset: 0x9F1CF4 VA: 0x9F1CF4
	public static long DCLKMNGMIKC_GetCurrentValue(CNLPPCFJEID_QuestInfo _KOGBMDOONFA_Info, OKGLGHCBCJP_Database _LKMHPJKIFDN_md, BBHNACPENDM_ServerSaveData _LDEGEHAEALK_ServerData)
	{
		int questValue = _KOGBMDOONFA_Info.CHOFDPDFPDC_ConfigValue;
		int questType = _KOGBMDOONFA_Info.INDDJNMPONH_type;
		switch(questType)
		{
			case 1:
				return _LDEGEHAEALK_ServerData.OEKEIGFAIGN_Counter.EJFAEKPGKNJ_daily.MILCBLJDADN_MusicClear;
			case 2:
				{
					long res = 0;
					for (int i = 0; i < 5; i++)
					{
						if (questValue <= i)
						{
							res += _LDEGEHAEALK_ServerData.OEKEIGFAIGN_Counter.EJFAEKPGKNJ_daily.GEIONHDKGEB_ScoreRank[i];
						}
					}
					return res;
				}
			case 3:
				return _LDEGEHAEALK_ServerData.OEKEIGFAIGN_Counter.EJFAEKPGKNJ_daily.MPHFGEPJOGL_NumSkillActive;
			case 4:
				return _LDEGEHAEALK_ServerData.OEKEIGFAIGN_Counter.EJFAEKPGKNJ_daily.NDNHHGJKJGM_Gach;
			case 5:
				return _LDEGEHAEALK_ServerData.OEKEIGFAIGN_Counter.EJFAEKPGKNJ_daily.GACBDCLPOCD_Sdv;
			case 6:
				{
					long res = 0;
					for (int i = 0; i < _LDEGEHAEALK_ServerData.GOACJBOCLHH_Quest.BEGCHDHHEKC_DailyQuests.Count; i++)
					{
						NFPHOINMHKN_QuestInfo saveQuest = _LDEGEHAEALK_ServerData.GOACJBOCLHH_Quest.BEGCHDHHEKC_DailyQuests[i];
						if (saveQuest.EALOBDHOCHP_stat != 0)
						{
							CNLPPCFJEID_QuestInfo dbQuest = _LKMHPJKIFDN_md.MHGPMMIDKMM_Quest.BEGCHDHHEKC_DailyQuests[i];
							if(dbQuest.INDDJNMPONH_type != 0)
							{
								if(dbQuest.INDDJNMPONH_type != 6)
								{
									if (saveQuest.EALOBDHOCHP_stat < 2)
									{
										if (KPEDEPGGMEC_GetDailyQuestStatus(dbQuest.PPFNGGCBJKC_id, _LKMHPJKIFDN_md, _LDEGEHAEALK_ServerData) == 2)
											res++;
									}
									else
										res++;
								}
							}
						}
					}
					return res;
				}
			case 7:
				for(int i = 0; i < _LKMHPJKIFDN_md.OHCIFMDPAPD_Story.CDENCMNHNGA_table.Count; i++)
				{
					LAEGMENIEDB_Story.ALGOILKGAAH dbStory = _LKMHPJKIFDN_md.OHCIFMDPAPD_Story.CDENCMNHNGA_table[i];
					if (dbStory.KLCIIHKFPPO_StoryMusicId == questValue)
					{
						NEKDCJKANAH_StoryRecord.HKDNILFKCFC saveStory = _LDEGEHAEALK_ServerData.LNOOKHJBENO_StoryRecord.MMKAJBFBKNH[dbStory.LFLLLOPAKCO_StoryId - 1];
						return saveStory.HALOKFOJMLA_IsCompleted ? 1 : 0;
					}
				}
				return 0;
			case 8:
				return _LDEGEHAEALK_ServerData.OEKEIGFAIGN_Counter.BDLNMOIOMHK_total.MILCBLJDADN_MusicClear;
			case 9:
				if(questValue > 0)
				{
					if (_LDEGEHAEALK_ServerData.OEKEIGFAIGN_Counter.BDLNMOIOMHK_total.LHOCOEOKFNO_SerieClear.Length < questValue)
						return 0;
					return _LDEGEHAEALK_ServerData.OEKEIGFAIGN_Counter.BDLNMOIOMHK_total.LHOCOEOKFNO_SerieClear[questValue - 1];
				}
				return 0;
			case 10:
				return _LDEGEHAEALK_ServerData.OEKEIGFAIGN_Counter.BDLNMOIOMHK_total.PHPPOGOEOAF_DiffClear[questValue - 1];
			case 11: // 0xb
				return _LDEGEHAEALK_ServerData.OEKEIGFAIGN_Counter.BDLNMOIOMHK_total.HLNOELCIBPH_Perf;
			case 12: // 0xc
				return _LDEGEHAEALK_ServerData.OEKEIGFAIGN_Counter.BDLNMOIOMHK_total.FILFPNDEINH_Combo;
			case 13: // 0xd
				return _LDEGEHAEALK_ServerData.OEKEIGFAIGN_Counter.BDLNMOIOMHK_total.KOONLNKCIJC_SS;
			case 14: // 0xe
				return _LDEGEHAEALK_ServerData.KCCLEHLLOFG_Common.KIECDDFNCAN_Level;
			case 15: // 0xf
				if (questValue < 1)
					return 0;
				if (questValue > _LDEGEHAEALK_ServerData.DGCJCAHIAPP_Diva.NBIGLBMHEDC_DivaList.Count)
					return 0;
				return _LDEGEHAEALK_ServerData.DGCJCAHIAPP_Diva.NBIGLBMHEDC_DivaList[questValue - 1].HEBKEJBDCBH_diva_lv;
			case 16: // 0x10
				return _LDEGEHAEALK_ServerData.PNLOINMCCKH_Scene.IGJAAIEAJPB_GetNumUnlockedScene();
			case 17: // 0x11
				return _LDEGEHAEALK_ServerData.PNLOINMCCKH_Scene.MPFLFKBNFEI_GetNumSceneAtLevelOrMore(_LKMHPJKIFDN_md.HNMMJINNHII_Game, _LKMHPJKIFDN_md.ECNHDEHADGL_Scene, questValue);
			case 18: // 0x12
				return _LDEGEHAEALK_ServerData.OEKEIGFAIGN_Counter.BDLNMOIOMHK_total.HOHBKPPOLLA_Uc;
			case 19: // 0x13
				return NFPHOINMHKN_QuestInfo.JGJAEKFMEPM(_LDEGEHAEALK_ServerData.GOACJBOCLHH_Quest.GPMKFMFEKLN_NormalQuests, _LKMHPJKIFDN_md.MHGPMMIDKMM_Quest);
			case 20: // 0x14
				return _LDEGEHAEALK_ServerData.NGHJPEIKLJL_Episode.GGKOLJCPNKO(_LKMHPJKIFDN_md.MOLEPBNJAGE_Episode);
			case 21: // 0x15
				return _LDEGEHAEALK_ServerData.OEKEIGFAIGN_Counter.BDLNMOIOMHK_total.IMIEPNOECFD_ValkyrieMode;
			case 22: // 0x16
				return _LDEGEHAEALK_ServerData.OEKEIGFAIGN_Counter.BDLNMOIOMHK_total.GACBDCLPOCD_Sdv;
			case 23: // 0x17
				return _LDEGEHAEALK_ServerData.OEKEIGFAIGN_Counter.BDLNMOIOMHK_total.EDLBLCGHECJ_MaxScore;
			case 24: // 0x18
				int v = _LDEGEHAEALK_ServerData.GOACJBOCLHH_Quest.GPMKFMFEKLN_NormalQuests[_KOGBMDOONFA_Info.PPFNGGCBJKC_id - 1].EALOBDHOCHP_stat;
				if (v > 1)
					return 1;
				if (questValue == 0)
				{
					if (HDEEBKIFLNI.HHCJCDFCLOB.FAEJJLGPAJP_HasALinkPlatform())
						return 1;
				}
				else
				{
					if (questValue - 1 > 2)
						return 0;
					if (HDEEBKIFLNI.HHCJCDFCLOB.EPAKLDBFECD_IsLinked((HDEEBKIFLNI.DGNPPLKNCGH_PlatformLink)questValue - 1))
						return 1;
				}
				return 0;
			case 25: // 0x19
			case 26: // 0x1a
			case 27: // 0x1b
				return _LDEGEHAEALK_ServerData.GOACJBOCLHH_Quest.GPMKFMFEKLN_NormalQuests[_KOGBMDOONFA_Info.PPFNGGCBJKC_id - 1].EALOBDHOCHP_stat > 1 ? 1 : 0;
			case 28: // 0x1c
				return BIFNGFAIEIL.HHCJCDFCLOB.CEDPKMOHANM(questValue);
			case 29: // 0x1d
				return _LDEGEHAEALK_ServerData.OEKEIGFAIGN_Counter.BDLNMOIOMHK_total.BENEAPDMALA_Mk;
			case 30: // 0x1e
				return _LDEGEHAEALK_ServerData.OEKEIGFAIGN_Counter.BDLNMOIOMHK_total.PDGJIJOMAKO_Medl;
			case 31: // 0x1f
				return _LDEGEHAEALK_ServerData.OEKEIGFAIGN_Counter.BDLNMOIOMHK_total.PFOMECFACLL_Shop;
			default:
				return 0;
			case 33: // 0x21
				{
					int res = 0;
					for (int i = 0; i < _LKMHPJKIFDN_md.ECNHDEHADGL_Scene.CDENCMNHNGA_table.Count; i++)
					{
						MLIBEPGADJH_Scene.KKLDOOJBJMN dbScene = _LKMHPJKIFDN_md.ECNHDEHADGL_Scene.CDENCMNHNGA_table[i];
						if (dbScene.PPEGAKEIEGM_Enabled == 2)
						{
							MMPBPOIFDAF_Scene.PMKOFEIONEG saveScene = _LDEGEHAEALK_ServerData.PNLOINMCCKH_Scene.OPIBAPEGCLA_Scenes[i];
							res += saveScene.DMNIMMGGJJJ_Leaf;
						}
					}
					return res;
				}
			case 34: // 0x22
				{
					HighScoreRating hs = new HighScoreRating();
					hs.CalcUtaRate(null, false);
					return hs.GetUtaRateTotal();
				}
			case 40: // 0x28
			case 41: // 0x29
			case 42: // 0x2a
			case 43: // 0x2b
			case 44: // 0x2c
			case 45: // 0x2d
			case 46: // 0x2e
			case 47: // 0x2f
			case 48: // 0x30
			case 49: // 0x31
			case 50: // 0x32
			case 51: // 0x33
				return _LDEGEHAEALK_ServerData.GOACJBOCLHH_Quest.GPMKFMFEKLN_NormalQuests[_KOGBMDOONFA_Info.PPFNGGCBJKC_id - 1].EALOBDHOCHP_stat > 1 ? 1 : 0;
			case 52: // 0x34
				{
					int res = 0;
					for (int i = 0; i < _LDEGEHAEALK_ServerData.GOACJBOCLHH_Quest.GPMKFMFEKLN_NormalQuests.Count; i++)
					{
						NFPHOINMHKN_QuestInfo dbQuest = _LDEGEHAEALK_ServerData.GOACJBOCLHH_Quest.GPMKFMFEKLN_NormalQuests[i];
						if (dbQuest.EALOBDHOCHP_stat != 0)
						{
							CNLPPCFJEID_QuestInfo saveQuest = _LKMHPJKIFDN_md.MHGPMMIDKMM_Quest.GPMKFMFEKLN_NormalQuests[i];
							if (saveQuest.INDDJNMPONH_type != 0)
							{
								if (saveQuest.INDDJNMPONH_type != 52)
								{
									res += (dbQuest.EALOBDHOCHP_stat > 2 && HHMKDAIGMKC_IsDebutMission((LOEGALDKHPL_ValueType)saveQuest.INDDJNMPONH_type)) ? 1 : 0;
								}
							}
						}
					}
					return res;
				}
			case 53: // 0x35
				return _LDEGEHAEALK_ServerData.OEKEIGFAIGN_Counter.BDLNMOIOMHK_total.KNCLIEBAPJD_Cosu;
			case 54: // 0x36
				if (questValue > 4)
					return 0;
				return _LDEGEHAEALK_ServerData.OEKEIGFAIGN_Counter.BDLNMOIOMHK_total.GKOAPFJFKEJ_VOpC[questValue];
			case 55: // 0x37
				if (questValue > 10)
					return 0;
				return _LDEGEHAEALK_ServerData.OEKEIGFAIGN_Counter.BDLNMOIOMHK_total.LOOAKNLDONN_DOpC[questValue - 1];
			case 56: // 0x38
				if(KDHGBOOECKC.HHCJCDFCLOB != null)
				{
					return BIFNGFAIEIL.HHCJCDFCLOB.EEGOJOFABAF(KDHGBOOECKC.HHCJCDFCLOB.EKODBMNLMKA(), questValue) ? 1 : 0;
				}
				return 0;
			case 57: //0x39
				return _LDEGEHAEALK_ServerData.DAEJHMCMFJD_Offer.MLBBKNLPBBD_IsTutoDone((BOPFPIHGJMD.PDLKAKEABDP_Tuto)questValue) ? 1 : 0;
			case 58: //0x3a
				return _LDEGEHAEALK_ServerData.BEKHNNCGIEL_Costume.MLBBKNLPBBD_IsTutoDone(questValue) ? 1 : 0;
			case 59: //0x3b
				return _LDEGEHAEALK_ServerData.OEKEIGFAIGN_Counter.BDLNMOIOMHK_total.BJDKMJFCOOM_LCnt;
			case 74: //0x4a
				return _LDEGEHAEALK_ServerData.KCCLEHLLOFG_Common.ADKJDHPEAJH(GPFlagConstant.ID.IsDecolture) ? 1 : 0;
			case 75: //0x4b
				return _LDEGEHAEALK_ServerData.OEKEIGFAIGN_Counter.BDLNMOIOMHK_total.DHNOLFBEHKN_Dcshp;
			case 76: //0x4c
				return _LDEGEHAEALK_ServerData.OEKEIGFAIGN_Counter.BDLNMOIOMHK_total.NALPJPKDNGH_Dp;
			case 77: //0x4d
				return _LDEGEHAEALK_ServerData.KCCLEHLLOFG_Common.ADKJDHPEAJH(GPFlagConstant.ID.IsValkyrieUpgrade) ? 1 : 0;
			case 78: //0x4e
				return _LDEGEHAEALK_ServerData.OEKEIGFAIGN_Counter.BDLNMOIOMHK_total.MJBCBJDMODC_Valu;
			case 79: //0x4f
				{
					if (questValue > 0)
					{
						if (questValue <= _LDEGEHAEALK_ServerData.DGCJCAHIAPP_Diva.NBIGLBMHEDC_DivaList.Count)
						{
							return _LDEGEHAEALK_ServerData.DGCJCAHIAPP_Diva.NBIGLBMHEDC_DivaList[questValue - 1].MMCEMJILMJI_EvSoLevel;
						}
					}
					int res = 0;
					for (int i = 0; i < _LDEGEHAEALK_ServerData.DGCJCAHIAPP_Diva.NBIGLBMHEDC_DivaList.Count; i++)
					{
						res = Mathf.Max(res, _LDEGEHAEALK_ServerData.DGCJCAHIAPP_Diva.NBIGLBMHEDC_DivaList[i].MMCEMJILMJI_EvSoLevel);
					}
					return res;
				}
			case 80: //0x50
				{
					if (questValue > 0)
					{
						if (questValue <= _LDEGEHAEALK_ServerData.DGCJCAHIAPP_Diva.NBIGLBMHEDC_DivaList.Count)
						{
							return _LDEGEHAEALK_ServerData.DGCJCAHIAPP_Diva.NBIGLBMHEDC_DivaList[questValue - 1].HDPANGMKKCP_EvVoLevel;
						}
					}
					int res = 0;
					for (int i = 0; i < _LDEGEHAEALK_ServerData.DGCJCAHIAPP_Diva.NBIGLBMHEDC_DivaList.Count; i++)
					{
						res = Mathf.Max(res, _LDEGEHAEALK_ServerData.DGCJCAHIAPP_Diva.NBIGLBMHEDC_DivaList[i].HDPANGMKKCP_EvVoLevel);
					}
					return res;
				}
			case 81: //0x51
				{
					if (questValue > 0)
					{
						if (questValue <= _LDEGEHAEALK_ServerData.DGCJCAHIAPP_Diva.NBIGLBMHEDC_DivaList.Count)
						{
							return _LDEGEHAEALK_ServerData.DGCJCAHIAPP_Diva.NBIGLBMHEDC_DivaList[questValue - 1].FFMLBEEBHDD_EvChLevel;
						}
					}
					int res = 0;
					for (int i = 0; i < _LDEGEHAEALK_ServerData.DGCJCAHIAPP_Diva.NBIGLBMHEDC_DivaList.Count; i++)
					{
						res = Mathf.Max(res, _LDEGEHAEALK_ServerData.DGCJCAHIAPP_Diva.NBIGLBMHEDC_DivaList[i].FFMLBEEBHDD_EvChLevel);
					}
					return res;
				}
		}
	}

	//// RVA: 0x9F4088 Offset: 0x9F4088 VA: 0x9F4088
	public static BKANGIKIEML.NODKLJHEAJB_ChallengeType HNHNHHCBLDE(LOEGALDKHPL_ValueType _INDDJNMPONH_type, int _CHOFDPDFPDC_ConfigValue)
	{
		switch(_INDDJNMPONH_type)
		{
			case LOEGALDKHPL_ValueType.APCJDBPNMLN_1_DailyClear/*1*/:
			case LOEGALDKHPL_ValueType.JDBOFJKBJNK_2_DailyScoreRank/*2*/:
			case LOEGALDKHPL_ValueType.OCGOGBEIHPD_3_DailyNumSkillActive/*3*/:
			case LOEGALDKHPL_ValueType.FCNKHKLIIGH_5_DailySuperDivaMode/*5*/:
			case LOEGALDKHPL_ValueType.GIEOJGGBODI_8_TotalMusicClear/*8*/:
			case LOEGALDKHPL_ValueType.LOGACAKHGBL_10_TotalDiffClear/*10*/:
			case LOEGALDKHPL_ValueType.HPNKPGICCMK_11_TotalPerf/*0xb*/:
			case LOEGALDKHPL_ValueType.OMEOCCEFCOB_12_TotalCombo/*0xc*/:
			case LOEGALDKHPL_ValueType.JHEMKMOJBDO_13_TotalSS/*0xd*/:
			case LOEGALDKHPL_ValueType.GCMANDIOBFN_14_PlayerLevel/*0xe*/:
			case LOEGALDKHPL_ValueType.MMOGNIPPMDO_15_DivaLevel/*0xf*/:
			case LOEGALDKHPL_ValueType.DGILGEFLNCF_18_TotalUc/*0x12*/:
			case LOEGALDKHPL_ValueType.FJPCGKGPKPE_21_NumValkMode/*0x15*/:
			case LOEGALDKHPL_ValueType.NKKFJIPJKAO_22_NumSuperDivaMode/*0x16*/:
			case LOEGALDKHPL_ValueType.OGCMIONDMHB_23_MaxScore/*0x17*/:
			case LOEGALDKHPL_ValueType.OKEIMJEMKKJ_27_MissionSendFriendRequest/*0x1b*/:
			case LOEGALDKHPL_ValueType.BHINHMNCMKC_29_TotalMk/*0x1d*/:
			case LOEGALDKHPL_ValueType.IDLHNACLCLG_30_TotalMedal/*0x1e*/:
			case LOEGALDKHPL_ValueType.CJKGEAFKKFL_34_UtaRateTotal/*0x22*/:
			case LOEGALDKHPL_ValueType.BDJBKMFEHHC_40_DebutMission0/*0x28*/:
			case LOEGALDKHPL_ValueType.DDGKOJFPGFF_49_DebutMission8/*0x31*/:
			case LOEGALDKHPL_ValueType.JCHPMNHJPKG_57_NumOfferTutoDone/*0x39*/:
			case LOEGALDKHPL_ValueType.JHMKDDGIGAA/*0x3f*/:
			case LOEGALDKHPL_ValueType.MEMMJNAKOHB/*0x40*/:
			case LOEGALDKHPL_ValueType.MLMDDOJOPFC/*0x44*/:
			case LOEGALDKHPL_ValueType.ADDCIMFHNAE/*0x45*/:
			case LOEGALDKHPL_ValueType.CFDPIBHFFPD_74_TutoDecoDone/*0x4a*/:
			case LOEGALDKHPL_ValueType.NCOHGNCGFJC_77_TutoValkUpgradeDone/*0x4d*/:
				return BKANGIKIEML.NODKLJHEAJB_ChallengeType.MGJDKBFHDML_5_MusicSelect/*5*/;
			case LOEGALDKHPL_ValueType.HCKOEGLNAJH_4_DailyGacha/*4*/:
			case LOEGALDKHPL_ValueType.IDAIIJEMNMP_47_Gacha/*0x2f*/:
				return BKANGIKIEML.NODKLJHEAJB_ChallengeType.DOEHLCLBCNN_1_Gacha/*1*/;
			default:
				return BKANGIKIEML.NODKLJHEAJB_ChallengeType.HJNNKCMLGFL_0_None/*0*/;
			case LOEGALDKHPL_ValueType.NOMJEIEDKML_7_StoryCompleted/*7*/:
			case LOEGALDKHPL_ValueType.LBKOGDGCFCM_41_DebutMission1Story/*0x29*/:
				return BKANGIKIEML.NODKLJHEAJB_ChallengeType.PAAIHBHJJMM_3_Story/*3*/;
			case LOEGALDKHPL_ValueType.ABDCDIGADHD_9_TotalSerieClear/*9*/:
				if (_CHOFDPDFPDC_ConfigValue == 0 || _CHOFDPDFPDC_ConfigValue - 1 > 4)
					return BKANGIKIEML.NODKLJHEAJB_ChallengeType.HJNNKCMLGFL_0_None/*0*/;
				return new BKANGIKIEML.NODKLJHEAJB_ChallengeType[5] { BKANGIKIEML.NODKLJHEAJB_ChallengeType.GONENLHJLCJ_9_MusicSelectDelta/*9*/
					, BKANGIKIEML.NODKLJHEAJB_ChallengeType.MLINGAKKDEP_8_MusiSelectFrontia/*8*/
					, BKANGIKIEML.NODKLJHEAJB_ChallengeType.OEFNIAKHGKD_7_MusicSelectSeven/*7*/
					, BKANGIKIEML.NODKLJHEAJB_ChallengeType.HBIPNFMLLBF_6_MusicSelectMacross/*6*/
					, BKANGIKIEML.NODKLJHEAJB_ChallengeType.BBAEIHMIFFI_11_MusicSelectOther/*0xb*/ }[_CHOFDPDFPDC_ConfigValue - 1];
			case LOEGALDKHPL_ValueType.CHPEIDMDNFP_16_NumScene/*0x10*/:
			case LOEGALDKHPL_ValueType.ANALBHDNGKP/*0x52*/:
			case LOEGALDKHPL_ValueType.LMFBIGPJMFM/*0x58*/:
				return BKANGIKIEML.NODKLJHEAJB_ChallengeType.DFEBFNNJMBM_32_Gacha2/*0x20*/;
			case LOEGALDKHPL_ValueType.ECOEJFBAABC_17_NumSceneAtLevel/*0x11*/:
			case LOEGALDKHPL_ValueType.BFIIIGLDKNN_33_NumLeaf/*0x21*/:
			case LOEGALDKHPL_ValueType.MCBICLJIJMK_42_DebutMission2PlateUpgrade/*0x2a*/:
			case LOEGALDKHPL_ValueType.BHJDMGFAPLG/*0x3e*/:
			case LOEGALDKHPL_ValueType.PAGIHFIMLCK/*0x59*/:
				return BKANGIKIEML.NODKLJHEAJB_ChallengeType.ADNIADMMBPM_21_SceneAbilityRelease/*0x15*/;
			case LOEGALDKHPL_ValueType.GKHJKFJFAHO_20_UnlockedEpisode/*0x14*/:
			case LOEGALDKHPL_ValueType.NEIJFCOANMA_50_DebutMissoin9/*0x32*/:
			case LOEGALDKHPL_ValueType.HIFAMABBNIE/*0x41*/:
				return BKANGIKIEML.NODKLJHEAJB_ChallengeType.EKHDECEEFFJ_4_EpisodeSeect/*4*/;
			case LOEGALDKHPL_ValueType.OLPLKIAHMOG_24_PlatformLinked/*0x18*/:
				return BKANGIKIEML.NODKLJHEAJB_ChallengeType.IJMFEGLNDFI_30_Option/*0x1e*/;
			case LOEGALDKHPL_ValueType.LAFFLNEDNDO_25_NormalQuestDone/*0x19*/:
				return BKANGIKIEML.NODKLJHEAJB_ChallengeType.KKFFEJEKFEG_29_OpenQuestURL/*0x1d*/;
			case LOEGALDKHPL_ValueType.HDJGNKOIMOH_26_MissionChangeProfilComment/*0x1a*/:
				return BKANGIKIEML.NODKLJHEAJB_ChallengeType.GFCAMHABJIC_22_Profil/*0x16*/;
			case LOEGALDKHPL_ValueType.NDHANBGPBBP_28_NumSns/*0x1c*/:
			case LOEGALDKHPL_ValueType.PEPILDAEIEL_45_DebutMission5Sns/*0x2d*/:
			case LOEGALDKHPL_ValueType.FMGMIOKOPKP_56_TotalSns/*0x38*/:
				return BKANGIKIEML.NODKLJHEAJB_ChallengeType.HGOGFPOCKFA_31_Sns/*0x1f*/;
			case LOEGALDKHPL_ValueType.DBAKKHLLCNC_31_TotalShop/*0x1f*/:
			case LOEGALDKHPL_ValueType.LANICCFBKAI_75_TotalDecoShop/*0x4b*/:
			case LOEGALDKHPL_ValueType.LHBGGMLDOHH/*0x57*/:
				return BKANGIKIEML.NODKLJHEAJB_ChallengeType.LJILBHPMPOG_34_Shop/*0x22*/;
			case LOEGALDKHPL_ValueType.FMOCAEEMHFJ_43_DebutMission3Story/*0x2b*/:
				if (CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_PlayerData.KCCLEHLLOFG_Common.KIECDDFNCAN_Level > 2)
					return BKANGIKIEML.NODKLJHEAJB_ChallengeType.PAAIHBHJJMM_3_Story/*3*/;
				return BKANGIKIEML.NODKLJHEAJB_ChallengeType.MGJDKBFHDML_5_MusicSelect/*5*/;
			case LOEGALDKHPL_ValueType.GNLPMEDLIJJ_44_DebutMission4TeamEdit/*0x2c*/:
			case LOEGALDKHPL_ValueType.AFLMHBMBNBO_48_DebutMission7TeamEdit/*0x30*/:
				return BKANGIKIEML.NODKLJHEAJB_ChallengeType.OBBOJKJAHIE_20_TeamEdit/*20*/;
			case LOEGALDKHPL_ValueType.PBKOKCHKGGL_46_DebugMission6/*0x2e*/:
				return BKANGIKIEML.NODKLJHEAJB_ChallengeType.ICAPJDDJIEA_23_Present/*0x17*/;
			case LOEGALDKHPL_ValueType.NEMNEDBLJEM_51_MissionPlaySongWithNotDefaultCostume/*0x33*/:
				DEKKMGAFJCG_Diva.MNNLOBDPCCH_DivaInfo diva = CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_PlayerData.DGCJCAHIAPP_Diva.NBIGLBMHEDC_DivaList[0];
				if (diva.CPGFPEDMDEH_have != 0)
				{
					if(diva.BEEAIAAJOHD_CostumeId != 2)
					{
						return BKANGIKIEML.NODKLJHEAJB_ChallengeType.KBHGPMNGALJ_33_Costume/*33*/;
					}
					AMCGONHBGGF unit = CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_PlayerData.MLAFAACKKBG_Unit.FJDDNKGHPHN_GetDefault().FDBOPFEOENF_diva[0];
					if (unit.DIPKCALNIII_diva_id == 1)
						return BKANGIKIEML.NODKLJHEAJB_ChallengeType.MGJDKBFHDML_5_MusicSelect/*5*/;
				}
				return BKANGIKIEML.NODKLJHEAJB_ChallengeType.OBBOJKJAHIE_20_TeamEdit/*20*/;
			case LOEGALDKHPL_ValueType.LOKMFLKHIPG_53_TotalCosu/*0x35*/:
			case LOEGALDKHPL_ValueType.HDHEKLONOGD/*0x46*/:
				return BKANGIKIEML.NODKLJHEAJB_ChallengeType.LEHHJINPFHA_37_CostumeUpgrade/*0x25*/;
			case LOEGALDKHPL_ValueType.NMBILGNHKFC_54_TotalVOp/*0x36*/:
			case LOEGALDKHPL_ValueType.KKIEICKBEEF_55_TotalDop/*0x37*/:
			case LOEGALDKHPL_ValueType.AJLNMHBKMLE_58_NumCostumeTutoDone/*0x3a*/:
				return BKANGIKIEML.NODKLJHEAJB_ChallengeType.OCNIBCBBLAA_36_Offer/*0x24*/;
			case LOEGALDKHPL_ValueType.OECPMGEPMHC_60_/*0x3c*/:
				return BKANGIKIEML.NODKLJHEAJB_ChallengeType.FNILHIFGOCE_15_GotoToEventMusicCond/*0xf*/;
			case LOEGALDKHPL_ValueType.CKENLOAPCEC_61_/*0x3d*/:
				return BKANGIKIEML.NODKLJHEAJB_ChallengeType.NHIOLMNADIO_35_Home/*0x23*/;
			case LOEGALDKHPL_ValueType.CKOOMMACNKA/*0x42*/:
			case LOEGALDKHPL_ValueType.DOIFAGIGLEE/*0x43*/:
				return BKANGIKIEML.NODKLJHEAJB_ChallengeType.HHFLHPFJMPN_39_Gakuya/*0x27*/;
			case LOEGALDKHPL_ValueType.MOKJAMEPIMK/*0x48*/:
				return BKANGIKIEML.NODKLJHEAJB_ChallengeType.OBDLOMGHHED_12_MusicSelectWeekly/*0xc*/;
			case LOEGALDKHPL_ValueType.CHANJDIDJOH/*0x49*/:
				return BKANGIKIEML.NODKLJHEAJB_ChallengeType.LINKBPIPHAK_17_GotoFreeMusic/*0x11*/;
			case LOEGALDKHPL_ValueType.MENBLIKPJMC_78_TotalValkUpgrade/*0x4e*/:
				return BKANGIKIEML.NODKLJHEAJB_ChallengeType.JDCENDOKKIE_41_ValkyrieTuneUp/*0x29*/;
			case LOEGALDKHPL_ValueType.JAMJLBCKHHB_79_GoDivaMaxSoulLevel/*0x4f*/:
			case LOEGALDKHPL_ValueType.BFHKNEJHFLH_80_GoDivaMaxVoiceLevel/*0x50*/:
			case LOEGALDKHPL_ValueType.HOHJCNDMDCD_81_GoDivaMaxChamLevel/*0x51*/:
			case LOEGALDKHPL_ValueType.AIKOJFKHPMO/*0x53*/:
			case LOEGALDKHPL_ValueType.EMKEFFFNBGG/*0x56*/:
				return BKANGIKIEML.NODKLJHEAJB_ChallengeType.AGCMIOFBFMG_10_MusicSelectEvent/*10*/;
			case LOEGALDKHPL_ValueType.FJCFIBPGLDG/*0x54*/:
				return BKANGIKIEML.NODKLJHEAJB_ChallengeType.KJAFDMGNBPO_43_DailyMission/*0x2b*/;
			case LOEGALDKHPL_ValueType.DNLGEBHGKGL/*0x55*/:
				return BKANGIKIEML.NODKLJHEAJB_ChallengeType.CLJHDIKFECG_42_Mission/*0x2a*/;
		}
	}

	//// RVA: 0x9F4608 Offset: 0x9F4608 VA: 0x9F4608
	public static BKANGIKIEML.NODKLJHEAJB_ChallengeType ODEHLBNBPPE(IKDICBBFBMI_EventBase FBFNJMKPBBA)
	{
        OHCAABOMEOF.KGOGMKMBCPP_EventType type = FBFNJMKPBBA.HIDHLFCBIDE_EventType;
        if (type >= OHCAABOMEOF.KGOGMKMBCPP_EventType.ENPJADLIFAB_EventSp && type < OHCAABOMEOF.KGOGMKMBCPP_EventType.DMPMKBCPHMA_9_PresentCampaign/*9*/)
		{
            IKDICBBFBMI_EventBase ev = JEPBIIJDGEF_EventInfo.HHCJCDFCLOB.MKBJOOAILBB_GetEventByStatus(KGCNCBOKCBA.GNENJEHKMHD_EventStatus.BCKENOKGLIJ_9_ResultRewardreceived, false);
			if(ev == null)
				return BKANGIKIEML.NODKLJHEAJB_ChallengeType.HJNNKCMLGFL_0_None;
			type = ev.HIDHLFCBIDE_EventType;
        }
		if ((int)type - 1 > 13)
			return 0;
		return new BKANGIKIEML.NODKLJHEAJB_ChallengeType[14]
		{
			BKANGIKIEML.NODKLJHEAJB_ChallengeType.KIBGKANOLLP_25_CurrentEvent2/*25*/,
			BKANGIKIEML.NODKLJHEAJB_ChallengeType.DFDKJPOHGAD_26_CurrentEvent3/*26*/,
			BKANGIKIEML.NODKLJHEAJB_ChallengeType.PHKLLDPCDBO_24_CurrentEvent/*24*/,
			BKANGIKIEML.NODKLJHEAJB_ChallengeType.HJNNKCMLGFL_0_None/*0*/,
			BKANGIKIEML.NODKLJHEAJB_ChallengeType.HJNNKCMLGFL_0_None/*0*/,
			BKANGIKIEML.NODKLJHEAJB_ChallengeType.PHKLLDPCDBO_24_CurrentEvent/*24*/,
			BKANGIKIEML.NODKLJHEAJB_ChallengeType.HJNNKCMLGFL_0_None/*0*/,
			BKANGIKIEML.NODKLJHEAJB_ChallengeType.HJNNKCMLGFL_0_None/*0*/,
			BKANGIKIEML.NODKLJHEAJB_ChallengeType.HJNNKCMLGFL_0_None/*0*/,
			BKANGIKIEML.NODKLJHEAJB_ChallengeType.FNILHIFGOCE_15_GotoToEventMusicCond/*15*/,
			BKANGIKIEML.NODKLJHEAJB_ChallengeType.JBMMAOHHEJH_27_CurrentEvent4/*27*/,
			BKANGIKIEML.NODKLJHEAJB_ChallengeType.BPNDHDHHKGE_38_Bingo/*38*/,
			BKANGIKIEML.NODKLJHEAJB_ChallengeType.HJNNKCMLGFL_0_None/*0*/,
			BKANGIKIEML.NODKLJHEAJB_ChallengeType.CJCABIKGFGG_28_CurrentEvent5/*28*/
		}[(int)type - 1];
	}

	//// RVA: 0x9F474C Offset: 0x9F474C VA: 0x9F474C
	public static BKANGIKIEML.NODKLJHEAJB_ChallengeType HNHNHHCBLDE(AKIIJBEJOEP _NDFIEMPPMLF_master, IKDICBBFBMI_EventBase FBFNJMKPBBA)
	{
		if (_NDFIEMPPMLF_master == null || FBFNJMKPBBA == null)
			return 0;
		BKANGIKIEML.NODKLJHEAJB_ChallengeType res = BKANGIKIEML.NODKLJHEAJB_ChallengeType.PAAIHBHJJMM_3_Story/*3*/;
		switch (_NDFIEMPPMLF_master.HDAMBOOCIAA_ClearType)
		{
			case 6:
			case 14:
			case 15:
			case 16:
			case 17:
			case 23:
			case 27:
			case 28:
			case 29:
			case 30:
			case 34:
			case 35:
			case 36:
			case 37:
			case 41:
			case 42:
			case 43:
			case 44:
			case 45:
				return ODEHLBNBPPE(FBFNJMKPBBA);
			default:
				if (_NDFIEMPPMLF_master.HMOJCCPIPBP_TargetMusicType < 1 || _NDFIEMPPMLF_master.HMOJCCPIPBP_TargetMusicType > 6)
					return BKANGIKIEML.NODKLJHEAJB_ChallengeType.MGJDKBFHDML_5_MusicSelect/*5*/;
				res = BKANGIKIEML.NODKLJHEAJB_ChallengeType.GAPJLFLINME_16_GotoToAprilFoolMusic/*16*/;
				switch(_NDFIEMPPMLF_master.HMOJCCPIPBP_TargetMusicType)
				{
					case 1:
						if (FBFNJMKPBBA.HIDHLFCBIDE_EventType == OHCAABOMEOF.KGOGMKMBCPP_EventType.DAMDPLEBNCB_AprilFool)
							return BKANGIKIEML.NODKLJHEAJB_ChallengeType.FNILHIFGOCE_15_GotoToEventMusicCond/*15*/;
						int EHDDADDKMFI_f_id = _NDFIEMPPMLF_master.HBJJCDIMOPO_TargetMusicConditionId;
						int idx = JEPBIIJDGEF_EventInfo.HHCJCDFCLOB.HEACCHAKMFG_GetMusicsList(FBFNJMKPBBA).FindIndex((int _GHPLINIACBB_x) =>
						{
							//0x9F61A4
							return EHDDADDKMFI_f_id == _GHPLINIACBB_x;
						});
						if(idx < 0)
							return BKANGIKIEML.NODKLJHEAJB_ChallengeType.FNILHIFGOCE_15_GotoToEventMusicCond/*15*/;
						break;
					case 2:
						return BKANGIKIEML.NODKLJHEAJB_ChallengeType.ANBJBLLMHMB_18_GotoFreeMusicSerieAttr/*18*/;
					case 3:
						if (_NDFIEMPPMLF_master.HBJJCDIMOPO_TargetMusicConditionId > 0 && _NDFIEMPPMLF_master.HBJJCDIMOPO_TargetMusicConditionId < 6)
							return new BKANGIKIEML.NODKLJHEAJB_ChallengeType[5] {
								BKANGIKIEML.NODKLJHEAJB_ChallengeType.GONENLHJLCJ_9_MusicSelectDelta/*9*/,
								BKANGIKIEML.NODKLJHEAJB_ChallengeType.MLINGAKKDEP_8_MusiSelectFrontia/*8*/, 
								BKANGIKIEML.NODKLJHEAJB_ChallengeType.OEFNIAKHGKD_7_MusicSelectSeven/*7*/,
								BKANGIKIEML.NODKLJHEAJB_ChallengeType.HBIPNFMLLBF_6_MusicSelectMacross/*6*/,
								BKANGIKIEML.NODKLJHEAJB_ChallengeType.BBAEIHMIFFI_11_MusicSelectOther/*11*/
							}[_NDFIEMPPMLF_master.HBJJCDIMOPO_TargetMusicConditionId - 1];
						break;
					case 4:
						break;
					case 5:
						List<int> l = JEPBIIJDGEF_EventInfo.HHCJCDFCLOB.HEACCHAKMFG_GetMusicsList(FBFNJMKPBBA);
						for(int i = 0; i < l.Count; i++)
						{
							if(IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.IBPAFKKEKNK_Music.NOBCLJIAMLC_GetFreeMusicData(l[i]).DLAEJOBELBH_MusicId == _NDFIEMPPMLF_master.HBJJCDIMOPO_TargetMusicConditionId)
							{
								return ODEHLBNBPPE(FBFNJMKPBBA);
							}
						}
						return BKANGIKIEML.NODKLJHEAJB_ChallengeType.MGJDKBFHDML_5_MusicSelect/*5*/;
					case 6:
						return res;
				}
				return ODEHLBNBPPE(FBFNJMKPBBA);
			case 18:
				break;
			case 19:
			case 20:
				res = BKANGIKIEML.NODKLJHEAJB_ChallengeType.HJNNKCMLGFL_0_None/*0*/;
				break;
			case 21:
			case 26:
				res = BKANGIKIEML.NODKLJHEAJB_ChallengeType.NHIOLMNADIO_35_Home/*35*/;
				break;
			case 31:
				res = BKANGIKIEML.NODKLJHEAJB_ChallengeType.OCNIBCBBLAA_36_Offer;
				break;
			case 32:
				res = BKANGIKIEML.NODKLJHEAJB_ChallengeType.DFEBFNNJMBM_32_Gacha2;
				break;
			case 33:
				res = BKANGIKIEML.NODKLJHEAJB_ChallengeType.PKHEABDDHKB_40_Deco;
				break;
			case 49:
				res = BKANGIKIEML.NODKLJHEAJB_ChallengeType.GFLALMCKGAH_19_GotoMinigame/*19*/;
				break;
		}
		return res;
	}

	//// RVA: 0x9F3E6C Offset: 0x9F3E6C VA: 0x9F3E6C
	public static int KPEDEPGGMEC_GetDailyQuestStatus(int _CMEJFJFOIIJ_QuestId, OKGLGHCBCJP_Database _LKMHPJKIFDN_md, BBHNACPENDM_ServerSaveData _LDEGEHAEALK_ServerData)
	{
		CNLPPCFJEID_QuestInfo dbQuest = _LKMHPJKIFDN_md.MHGPMMIDKMM_Quest.BEGCHDHHEKC_DailyQuests[_CMEJFJFOIIJ_QuestId - 1];
		NFPHOINMHKN_QuestInfo saveQuest = _LDEGEHAEALK_ServerData.GOACJBOCLHH_Quest.BEGCHDHHEKC_DailyQuests[_CMEJFJFOIIJ_QuestId - 1];
		if (dbQuest.INDDJNMPONH_type == 0)
			return 0;
		if(saveQuest.EALOBDHOCHP_stat != 1)
		{
			return saveQuest.EALOBDHOCHP_stat;
		}
		long v = DCLKMNGMIKC_GetCurrentValue(dbQuest, _LKMHPJKIFDN_md, _LDEGEHAEALK_ServerData);
		return v < dbQuest.FCDKJAKLGMB_TargetValue ? 1 : 2;
	}

	//// RVA: 0x9F4D28 Offset: 0x9F4D28 VA: 0x9F4D28
	public static int OBOJKHIJBGL_GetNormalQuestStatus(int _CMEJFJFOIIJ_QuestId, OKGLGHCBCJP_Database _LKMHPJKIFDN_md, BBHNACPENDM_ServerSaveData _LDEGEHAEALK_ServerData, bool KDEBJBCDFOL/* = false*/)
	{
		CNLPPCFJEID_QuestInfo dbQuest = _LKMHPJKIFDN_md.MHGPMMIDKMM_Quest.GPMKFMFEKLN_NormalQuests[_CMEJFJFOIIJ_QuestId - 1];
		NFPHOINMHKN_QuestInfo saveQuest = _LDEGEHAEALK_ServerData.GOACJBOCLHH_Quest.GPMKFMFEKLN_NormalQuests[_CMEJFJFOIIJ_QuestId - 1];
		int c = 0;
		if(dbQuest.INDDJNMPONH_type != 0)
		{
			int a = 0;
			if (saveQuest.EALOBDHOCHP_stat > 1)
				return saveQuest.EALOBDHOCHP_stat;
			if(!KDEBJBCDFOL)
			{
				if(dbQuest.HHIBBHFHENH_LinkQuestId != 0)
				{
					CNLPPCFJEID_QuestInfo q2 = _LKMHPJKIFDN_md.MHGPMMIDKMM_Quest.GPMKFMFEKLN_NormalQuests[dbQuest.HHIBBHFHENH_LinkQuestId - 1];
					long t = DCLKMNGMIKC_GetCurrentValue(q2, _LKMHPJKIFDN_md, _LDEGEHAEALK_ServerData);
					a = 2;
					if(t < q2.FCDKJAKLGMB_TargetValue)
					{
						NFPHOINMHKN_QuestInfo s2 = _LDEGEHAEALK_ServerData.GOACJBOCLHH_Quest.GPMKFMFEKLN_NormalQuests[dbQuest.HHIBBHFHENH_LinkQuestId - 1];
						a = s2.EALOBDHOCHP_stat;
					}
				}
			}
			c = 2;
			long t2 = DCLKMNGMIKC_GetCurrentValue(dbQuest, _LKMHPJKIFDN_md, _LDEGEHAEALK_ServerData);
			if(t2 < dbQuest.FCDKJAKLGMB_TargetValue)
			{
				if(dbQuest.EKANGPODCEP_EventId != 0)
				{
					IKDICBBFBMI_EventBase ev = JEPBIIJDGEF_EventInfo.HHCJCDFCLOB.OIKOHACJPCB_GetEventById(dbQuest.EKANGPODCEP_EventId);
					if (ev == null)
						return 0;
					if (ev.NGOFCFJHOMI_Status > KGCNCBOKCBA.GNENJEHKMHD_EventStatus.MEAJLPAHINL_5_ChallengePeriod/*5*/)
						return 0;
				}
				return (dbQuest.HHIBBHFHENH_LinkQuestId == 0 || a > 1) ? 1 : 0;
			}
		}
		return c;
	}

	// RVA: 0x9F5228 Offset: 0x9F5228 VA: 0x9F5228
	public static void MOFIPNGNNPA(LOEGALDKHPL_ValueType _INDDJNMPONH_type, OKGLGHCBCJP_Database _LKMHPJKIFDN_md, BBHNACPENDM_ServerSaveData _LDEGEHAEALK_ServerData, int _EALOBDHOCHP_stat, bool _FBBNPFFEJBN_Force/* = false*/)
	{
		if((int)_INDDJNMPONH_type > 39)
		{
			if((int)_INDDJNMPONH_type < 53)
			{
				if(!DDJGDCHMCBN(_INDDJNMPONH_type))
				{
					CNLPPCFJEID_QuestInfo c = _LKMHPJKIFDN_md.MHGPMMIDKMM_Quest.GPMKFMFEKLN_NormalQuests.Find((CNLPPCFJEID_QuestInfo _GHPLINIACBB_x) =>
					{
						//0x9F60D8
						return (int)_INDDJNMPONH_type == _GHPLINIACBB_x.INDDJNMPONH_type;
					});
					if(c != null)
					{
						NFPHOINMHKN_QuestInfo n = _LDEGEHAEALK_ServerData.GOACJBOCLHH_Quest.GPMKFMFEKLN_NormalQuests[c.PPFNGGCBJKC_id - 1];
						if(!_FBBNPFFEJBN_Force)
						{
							if (_EALOBDHOCHP_stat <= n.EALOBDHOCHP_stat)
								return;
						}
						n.EALOBDHOCHP_stat = _EALOBDHOCHP_stat;
					}
				}
			}
		}
	}

	//// RVA: 0x9F54E8 Offset: 0x9F54E8 VA: 0x9F54E8
	public static void MOFIPNGNNPA(LOEGALDKHPL_ValueType _INDDJNMPONH_type, int _EALOBDHOCHP_stat/* = 2*/, bool _FBBNPFFEJBN_Force/* = false*/)
	{
		if(CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_PlayerData != null && IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database != null)
		{
			MOFIPNGNNPA(_INDDJNMPONH_type, IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database, CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_PlayerData, _EALOBDHOCHP_stat, _FBBNPFFEJBN_Force);
		}
	}

	//// RVA: 0x9F5634 Offset: 0x9F5634 VA: 0x9F5634
	public static int BFLCENAJOEN(LOEGALDKHPL_ValueType _INDDJNMPONH_type)
	{
		CNLPPCFJEID_QuestInfo c = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.MHGPMMIDKMM_Quest.GPMKFMFEKLN_NormalQuests.Find((CNLPPCFJEID_QuestInfo _GHPLINIACBB_x) =>
		{
			//0x9F611C
			return _GHPLINIACBB_x.INDDJNMPONH_type == (int)_INDDJNMPONH_type;
		});
		if(c != null)
		{
			return CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_PlayerData.GOACJBOCLHH_Quest.GPMKFMFEKLN_NormalQuests[c.PPFNGGCBJKC_id - 1].EALOBDHOCHP_stat;
		}
		return 0;
	}

	//// RVA: 0x9F58BC Offset: 0x9F58BC VA: 0x9F58BC
	public static void HECOAKHIAKP(LOEGALDKHPL_ValueType _INDDJNMPONH_type, int _EALOBDHOCHP_stat/* = 2*/, bool _FBBNPFFEJBN_Force/* = false*/)
	{
		CNLPPCFJEID_QuestInfo quest = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.MHGPMMIDKMM_Quest.GPMKFMFEKLN_NormalQuests.Find((CNLPPCFJEID_QuestInfo _GHPLINIACBB_x) =>
		{
			//0x9F6160
			return _GHPLINIACBB_x.INDDJNMPONH_type == (int)_INDDJNMPONH_type;
		});
		if(quest != null)
		{
			NFPHOINMHKN_QuestInfo q = CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_PlayerData.GOACJBOCLHH_Quest.GPMKFMFEKLN_NormalQuests[quest.PPFNGGCBJKC_id - 1];
			if(!_FBBNPFFEJBN_Force)
			{
				if (_EALOBDHOCHP_stat <= q.EALOBDHOCHP_stat)
					return;
			}
			q.EALOBDHOCHP_stat = _EALOBDHOCHP_stat;
		}
	}

	//// RVA: 0x9F5B78 Offset: 0x9F5B78 VA: 0x9F5B78
	public static bool FJFPHHEFMIB_IsSnsMission(CNLPPCFJEID_QuestInfo _MABBBOEAPAA_p)
	{
		if (_MABBBOEAPAA_p.INDDJNMPONH_type != 28)
			return _MABBBOEAPAA_p.INDDJNMPONH_type == 56;
		return true;
	}

	//// RVA: 0x9F5BC0 Offset: 0x9F5BC0 VA: 0x9F5BC0
	public static bool OHFOAIDPDEM(int _MALFHCHNEFN_RoomId, out int _CMEJFJFOIIJ_QuestId)
	{
		int a = BIFNGFAIEIL.HHCJCDFCLOB.CEDPKMOHANM(_MALFHCHNEFN_RoomId);
		List<CNLPPCFJEID_QuestInfo> dbQuests = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.MHGPMMIDKMM_Quest.GPMKFMFEKLN_NormalQuests;
		List<NFPHOINMHKN_QuestInfo> saveQuests = CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_PlayerData.GOACJBOCLHH_Quest.GPMKFMFEKLN_NormalQuests;
		for(int i = 0; i < dbQuests.Count; i++)
		{
			if(FJFPHHEFMIB_IsSnsMission(dbQuests[i]))
			{
				if(dbQuests[i].CHOFDPDFPDC_ConfigValue == _MALFHCHNEFN_RoomId)
				{
					if(saveQuests[i].EALOBDHOCHP_stat < 2)
					{
						if (dbQuests[i].FCDKJAKLGMB_TargetValue <= a)
						{
							_CMEJFJFOIIJ_QuestId = i + 1;
							return true;
						}
						_CMEJFJFOIIJ_QuestId = 0;
						return false;
					}
				}
			}
		}
		_CMEJFJFOIIJ_QuestId = 0;
		return false;
	}

	//// RVA: 0x9F5F10 Offset: 0x9F5F10 VA: 0x9F5F10
	public static void CIEDCPPINCB(int _CMEJFJFOIIJ_QuestId, int _EALOBDHOCHP_stat/* = 2*/)
	{
		CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_PlayerData.GOACJBOCLHH_Quest.GPMKFMFEKLN_NormalQuests[_CMEJFJFOIIJ_QuestId - 1].EALOBDHOCHP_stat = _EALOBDHOCHP_stat;
	}
}
