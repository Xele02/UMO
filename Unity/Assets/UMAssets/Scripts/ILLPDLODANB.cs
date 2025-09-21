
using System.Collections.Generic;
using UnityEngine;
using XeApp.Game.Common;

public class ILLPDLODANB
{
	public enum LOEGALDKHPL
	{
		HJNNKCMLGFL_0_None = 0,
		APCJDBPNMLN = 1,
		JDBOFJKBJNK = 2,
		OCGOGBEIHPD = 3,
		HCKOEGLNAJH = 4,
		FCNKHKLIIGH = 5,
		DCFBLGLFJDO = 6,
		NOMJEIEDKML = 7,
		GIEOJGGBODI = 8,
		ABDCDIGADHD = 9,
		LOGACAKHGBL = 10,
		HPNKPGICCMK = 11,
		OMEOCCEFCOB = 12,
		JHEMKMOJBDO = 13,
		GCMANDIOBFN = 14,
		MMOGNIPPMDO = 15,
		CHPEIDMDNFP = 16,
		ECOEJFBAABC = 17,
		DGILGEFLNCF = 18,
		ODDEKPGKLJA = 19,
		GKHJKFJFAHO = 20,
		FJPCGKGPKPE = 21,
		NKKFJIPJKAO = 22,
		OGCMIONDMHB = 23,
		OLPLKIAHMOG = 24,
		LAFFLNEDNDO = 25,
		HDJGNKOIMOH = 26,
		OKEIMJEMKKJ_27 = 27,
		NDHANBGPBBP = 28,
		BHINHMNCMKC = 29,
		IDLHNACLCLG = 30,
		DBAKKHLLCNC = 31,
		BFIIIGLDKNN = 33,
		CJKGEAFKKFL = 34,
		BDJBKMFEHHC = 40,
		LBKOGDGCFCM = 41,
		MCBICLJIJMK_42 = 42,
		FMOCAEEMHFJ = 43,
		GNLPMEDLIJJ = 44,
		PEPILDAEIEL = 45,
		PBKOKCHKGGL_46 = 46,
		IDAIIJEMNMP_47 = 47,
		AFLMHBMBNBO_48 = 48,
		DDGKOJFPGFF = 49,
		NEIJFCOANMA_50 = 50,
		NEMNEDBLJEM = 51,
		OECOMFPCPAI = 52,
		LOKMFLKHIPG = 53,
		NMBILGNHKFC = 54,
		KKIEICKBEEF = 55,
		FMGMIOKOPKP = 56,
		JCHPMNHJPKG = 57,
		AJLNMHBKMLE = 58,
		BBOGLGJCAGE = 59,
		OECPMGEPMHC = 60,
		CKENLOAPCEC = 61,
		BHJDMGFAPLG = 62,
		JHMKDDGIGAA = 63,
		MEMMJNAKOHB = 64,
		HIFAMABBNIE = 65,
		CKOOMMACNKA = 66,
		DOIFAGIGLEE = 67,
		MLMDDOJOPFC = 68,
		ADDCIMFHNAE = 69,
		HDHEKLONOGD = 70,
		LEFBLIEIELJ = 71,
		MOKJAMEPIMK = 72,
		CHANJDIDJOH = 73,
		CFDPIBHFFPD = 74,
		LANICCFBKAI = 75,
		BJHMIGMHOCE = 76,
		NCOHGNCGFJC = 77,
		MENBLIKPJMC = 78,
		JAMJLBCKHHB = 79,
		BFHKNEJHFLH = 80,
		HOHJCNDMDCD = 81,
		ANALBHDNGKP = 82,
		AIKOJFKHPMO = 83,
		FJCFIBPGLDG = 84,
		DNLGEBHGKGL = 85,
		EMKEFFFNBGG = 86,
		LHBGGMLDOHH = 87,
		LMFBIGPJMFM = 88,
		PAGIHFIMLCK = 89,
	}

	private static LOEGALDKHPL NNLCKKMJPLJ; // 0x0

	//// RVA: 0x9F1AF4 Offset: 0x9F1AF4 VA: 0x9F1AF4
	public static bool HHMKDAIGMKC_IsDebutMission(LOEGALDKHPL _INDDJNMPONH_Type)
	{
		return _INDDJNMPONH_Type >= LOEGALDKHPL.BDJBKMFEHHC/*40*/ && _INDDJNMPONH_Type < LOEGALDKHPL.LOKMFLKHIPG/*53*/;
	}

	//// RVA: 0x9F1B08 Offset: 0x9F1B08 VA: 0x9F1B08
	public static void IHKAKFFAGPC(LOEGALDKHPL _INDDJNMPONH_Type)
	{
		NNLCKKMJPLJ = _INDDJNMPONH_Type;
	}

	//// RVA: 0x9F1B98 Offset: 0x9F1B98 VA: 0x9F1B98
	public static bool DDJGDCHMCBN(LOEGALDKHPL _INDDJNMPONH_Type)
	{
		if(NNLCKKMJPLJ != LOEGALDKHPL.HJNNKCMLGFL_0_None/*0*/)
		{
			return _INDDJNMPONH_Type == NNLCKKMJPLJ;
		}
		return false;
	}

	//// RVA: 0x9F1C78 Offset: 0x9F1C78 VA: 0x9F1C78
	public static void ILOGJDALEOO()
	{
		IHKAKFFAGPC(LOEGALDKHPL.HJNNKCMLGFL_0_None);
	}

	//// RVA: 0x9F1CF4 Offset: 0x9F1CF4 VA: 0x9F1CF4
	public static long DCLKMNGMIKC_GetCurrentValue(CNLPPCFJEID_QuestInfo _KOGBMDOONFA_Info, OKGLGHCBCJP_Database _LKMHPJKIFDN_md, BBHNACPENDM_ServerSaveData _LDEGEHAEALK_ServerData)
	{
		int questValue = _KOGBMDOONFA_Info.CHOFDPDFPDC_ConfigValue;
		int questType = _KOGBMDOONFA_Info.INDDJNMPONH_Type;
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
						if (saveQuest.EALOBDHOCHP_Stat != 0)
						{
							CNLPPCFJEID_QuestInfo dbQuest = _LKMHPJKIFDN_md.MHGPMMIDKMM_Quest.BEGCHDHHEKC_DailyQuests[i];
							if(dbQuest.INDDJNMPONH_Type != 0)
							{
								if(dbQuest.INDDJNMPONH_Type != 6)
								{
									if (saveQuest.EALOBDHOCHP_Stat < 2)
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
				return _LDEGEHAEALK_ServerData.OEKEIGFAIGN_Counter.BDLNMOIOMHK_Total.MILCBLJDADN_MusicClear;
			case 9:
				if(questValue > 0)
				{
					if (_LDEGEHAEALK_ServerData.OEKEIGFAIGN_Counter.BDLNMOIOMHK_Total.LHOCOEOKFNO_SerieClear.Length < questValue)
						return 0;
					return _LDEGEHAEALK_ServerData.OEKEIGFAIGN_Counter.BDLNMOIOMHK_Total.LHOCOEOKFNO_SerieClear[questValue - 1];
				}
				return 0;
			case 10:
				return _LDEGEHAEALK_ServerData.OEKEIGFAIGN_Counter.BDLNMOIOMHK_Total.PHPPOGOEOAF_DiffClear[questValue - 1];
			case 11: // 0xb
				return _LDEGEHAEALK_ServerData.OEKEIGFAIGN_Counter.BDLNMOIOMHK_Total.HLNOELCIBPH_Perf;
			case 12: // 0xc
				return _LDEGEHAEALK_ServerData.OEKEIGFAIGN_Counter.BDLNMOIOMHK_Total.FILFPNDEINH_Combo;
			case 13: // 0xd
				return _LDEGEHAEALK_ServerData.OEKEIGFAIGN_Counter.BDLNMOIOMHK_Total.KOONLNKCIJC_SS;
			case 14: // 0xe
				return _LDEGEHAEALK_ServerData.KCCLEHLLOFG_Common.KIECDDFNCAN_Level;
			case 15: // 0xf
				if (questValue < 1)
					return 0;
				if (questValue > _LDEGEHAEALK_ServerData.DGCJCAHIAPP_Diva.NBIGLBMHEDC_DivaList.Count)
					return 0;
				return _LDEGEHAEALK_ServerData.DGCJCAHIAPP_Diva.NBIGLBMHEDC_DivaList[questValue - 1].HEBKEJBDCBH_DivaLevel;
			case 16: // 0x10
				return _LDEGEHAEALK_ServerData.PNLOINMCCKH_Scene.IGJAAIEAJPB_GetNumUnlockedScene();
			case 17: // 0x11
				return _LDEGEHAEALK_ServerData.PNLOINMCCKH_Scene.MPFLFKBNFEI_GetNumSceneAtLevelOrMore(_LKMHPJKIFDN_md.HNMMJINNHII_Game, _LKMHPJKIFDN_md.ECNHDEHADGL_Scene, questValue);
			case 18: // 0x12
				return _LDEGEHAEALK_ServerData.OEKEIGFAIGN_Counter.BDLNMOIOMHK_Total.HOHBKPPOLLA_Uc;
			case 19: // 0x13
				return NFPHOINMHKN_QuestInfo.JGJAEKFMEPM(_LDEGEHAEALK_ServerData.GOACJBOCLHH_Quest.GPMKFMFEKLN_NormalQuests, _LKMHPJKIFDN_md.MHGPMMIDKMM_Quest);
			case 20: // 0x14
				return _LDEGEHAEALK_ServerData.NGHJPEIKLJL_Episode.GGKOLJCPNKO(_LKMHPJKIFDN_md.MOLEPBNJAGE_Episode);
			case 21: // 0x15
				return _LDEGEHAEALK_ServerData.OEKEIGFAIGN_Counter.BDLNMOIOMHK_Total.IMIEPNOECFD_ValkyrieMode;
			case 22: // 0x16
				return _LDEGEHAEALK_ServerData.OEKEIGFAIGN_Counter.BDLNMOIOMHK_Total.GACBDCLPOCD_Sdv;
			case 23: // 0x17
				return _LDEGEHAEALK_ServerData.OEKEIGFAIGN_Counter.BDLNMOIOMHK_Total.EDLBLCGHECJ_MaxScore;
			case 24: // 0x18
				int v = _LDEGEHAEALK_ServerData.GOACJBOCLHH_Quest.GPMKFMFEKLN_NormalQuests[_KOGBMDOONFA_Info.PPFNGGCBJKC_id - 1].EALOBDHOCHP_Stat;
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
				return _LDEGEHAEALK_ServerData.GOACJBOCLHH_Quest.GPMKFMFEKLN_NormalQuests[_KOGBMDOONFA_Info.PPFNGGCBJKC_id - 1].EALOBDHOCHP_Stat > 1 ? 1 : 0;
			case 28: // 0x1c
				return BIFNGFAIEIL.HHCJCDFCLOB.CEDPKMOHANM(questValue);
			case 29: // 0x1d
				return _LDEGEHAEALK_ServerData.OEKEIGFAIGN_Counter.BDLNMOIOMHK_Total.BENEAPDMALA_Mk;
			case 30: // 0x1e
				return _LDEGEHAEALK_ServerData.OEKEIGFAIGN_Counter.BDLNMOIOMHK_Total.PDGJIJOMAKO_Medl;
			case 31: // 0x1f
				return _LDEGEHAEALK_ServerData.OEKEIGFAIGN_Counter.BDLNMOIOMHK_Total.PFOMECFACLL_Shop;
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
				return _LDEGEHAEALK_ServerData.GOACJBOCLHH_Quest.GPMKFMFEKLN_NormalQuests[_KOGBMDOONFA_Info.PPFNGGCBJKC_id - 1].EALOBDHOCHP_Stat > 1 ? 1 : 0;
			case 52: // 0x34
				{
					int res = 0;
					for (int i = 0; i < _LDEGEHAEALK_ServerData.GOACJBOCLHH_Quest.GPMKFMFEKLN_NormalQuests.Count; i++)
					{
						NFPHOINMHKN_QuestInfo dbQuest = _LDEGEHAEALK_ServerData.GOACJBOCLHH_Quest.GPMKFMFEKLN_NormalQuests[i];
						if (dbQuest.EALOBDHOCHP_Stat != 0)
						{
							CNLPPCFJEID_QuestInfo saveQuest = _LKMHPJKIFDN_md.MHGPMMIDKMM_Quest.GPMKFMFEKLN_NormalQuests[i];
							if (saveQuest.INDDJNMPONH_Type != 0)
							{
								if (saveQuest.INDDJNMPONH_Type != 52)
								{
									res += (dbQuest.EALOBDHOCHP_Stat > 2 && HHMKDAIGMKC_IsDebutMission((LOEGALDKHPL)saveQuest.INDDJNMPONH_Type)) ? 1 : 0;
								}
							}
						}
					}
					return res;
				}
			case 53: // 0x35
				return _LDEGEHAEALK_ServerData.OEKEIGFAIGN_Counter.BDLNMOIOMHK_Total.KNCLIEBAPJD_Cosu;
			case 54: // 0x36
				if (questValue > 4)
					return 0;
				return _LDEGEHAEALK_ServerData.OEKEIGFAIGN_Counter.BDLNMOIOMHK_Total.GKOAPFJFKEJ_VOpC[questValue];
			case 55: // 0x37
				if (questValue > 10)
					return 0;
				return _LDEGEHAEALK_ServerData.OEKEIGFAIGN_Counter.BDLNMOIOMHK_Total.LOOAKNLDONN_DOpC[questValue - 1];
			case 56: // 0x38
				if(KDHGBOOECKC.HHCJCDFCLOB != null)
				{
					return BIFNGFAIEIL.HHCJCDFCLOB.EEGOJOFABAF(KDHGBOOECKC.HHCJCDFCLOB.EKODBMNLMKA(), questValue) ? 1 : 0;
				}
				return 0;
			case 57: //0x39
				return _LDEGEHAEALK_ServerData.DAEJHMCMFJD_Offer.MLBBKNLPBBD_HasShowTuto((BOPFPIHGJMD.PDLKAKEABDP)questValue) ? 1 : 0;
			case 58: //0x3a
				return _LDEGEHAEALK_ServerData.BEKHNNCGIEL_Costume.MLBBKNLPBBD_IsTutoDone(questValue) ? 1 : 0;
			case 59: //0x3b
				return _LDEGEHAEALK_ServerData.OEKEIGFAIGN_Counter.BDLNMOIOMHK_Total.BJDKMJFCOOM_LCnt;
			case 74: //0x4a
				return _LDEGEHAEALK_ServerData.KCCLEHLLOFG_Common.ADKJDHPEAJH(GPFlagConstant.ID.IsDecolture) ? 1 : 0;
			case 75: //0x4b
				return _LDEGEHAEALK_ServerData.OEKEIGFAIGN_Counter.BDLNMOIOMHK_Total.DHNOLFBEHKN_Dcshp;
			case 76: //0x4c
				return _LDEGEHAEALK_ServerData.OEKEIGFAIGN_Counter.BDLNMOIOMHK_Total.NALPJPKDNGH_Dp;
			case 77: //0x4d
				return _LDEGEHAEALK_ServerData.KCCLEHLLOFG_Common.ADKJDHPEAJH(GPFlagConstant.ID.IsValkyrieUpgrade) ? 1 : 0;
			case 78: //0x4e
				return _LDEGEHAEALK_ServerData.OEKEIGFAIGN_Counter.BDLNMOIOMHK_Total.MJBCBJDMODC_Valu;
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
	public static BKANGIKIEML.NODKLJHEAJB HNHNHHCBLDE(LOEGALDKHPL _INDDJNMPONH_Type, int _CHOFDPDFPDC_ConfigValue)
	{
		switch(_INDDJNMPONH_Type)
		{
			case LOEGALDKHPL.APCJDBPNMLN/*1*/:
			case LOEGALDKHPL.JDBOFJKBJNK/*2*/:
			case LOEGALDKHPL.OCGOGBEIHPD/*3*/:
			case LOEGALDKHPL.FCNKHKLIIGH/*5*/:
			case LOEGALDKHPL.GIEOJGGBODI/*8*/:
			case LOEGALDKHPL.LOGACAKHGBL/*10*/:
			case LOEGALDKHPL.HPNKPGICCMK/*0xb*/:
			case LOEGALDKHPL.OMEOCCEFCOB/*0xc*/:
			case LOEGALDKHPL.JHEMKMOJBDO/*0xd*/:
			case LOEGALDKHPL.GCMANDIOBFN/*0xe*/:
			case LOEGALDKHPL.MMOGNIPPMDO/*0xf*/:
			case LOEGALDKHPL.DGILGEFLNCF/*0x12*/:
			case LOEGALDKHPL.FJPCGKGPKPE/*0x15*/:
			case LOEGALDKHPL.NKKFJIPJKAO/*0x16*/:
			case LOEGALDKHPL.OGCMIONDMHB/*0x17*/:
			case LOEGALDKHPL.OKEIMJEMKKJ_27/*0x1b*/:
			case LOEGALDKHPL.BHINHMNCMKC/*0x1d*/:
			case LOEGALDKHPL.IDLHNACLCLG/*0x1e*/:
			case LOEGALDKHPL.CJKGEAFKKFL/*0x22*/:
			case LOEGALDKHPL.BDJBKMFEHHC/*0x28*/:
			case LOEGALDKHPL.DDGKOJFPGFF/*0x31*/:
			case LOEGALDKHPL.JCHPMNHJPKG/*0x39*/:
			case LOEGALDKHPL.JHMKDDGIGAA/*0x3f*/:
			case LOEGALDKHPL.MEMMJNAKOHB/*0x40*/:
			case LOEGALDKHPL.MLMDDOJOPFC/*0x44*/:
			case LOEGALDKHPL.ADDCIMFHNAE/*0x45*/:
			case LOEGALDKHPL.CFDPIBHFFPD/*0x4a*/:
			case LOEGALDKHPL.NCOHGNCGFJC/*0x4d*/:
				return BKANGIKIEML.NODKLJHEAJB.MGJDKBFHDML_5/*5*/;
			case LOEGALDKHPL.HCKOEGLNAJH/*4*/:
			case LOEGALDKHPL.IDAIIJEMNMP_47/*0x2f*/:
				return BKANGIKIEML.NODKLJHEAJB.DOEHLCLBCNN_1/*1*/;
			default:
				return BKANGIKIEML.NODKLJHEAJB.HJNNKCMLGFL_0_None/*0*/;
			case LOEGALDKHPL.NOMJEIEDKML/*7*/:
			case LOEGALDKHPL.LBKOGDGCFCM/*0x29*/:
				return BKANGIKIEML.NODKLJHEAJB.PAAIHBHJJMM_3/*3*/;
			case LOEGALDKHPL.ABDCDIGADHD/*9*/:
				if (_CHOFDPDFPDC_ConfigValue == 0 || _CHOFDPDFPDC_ConfigValue - 1 > 4)
					return BKANGIKIEML.NODKLJHEAJB.HJNNKCMLGFL_0_None/*0*/;
				return new BKANGIKIEML.NODKLJHEAJB[5] { BKANGIKIEML.NODKLJHEAJB.GONENLHJLCJ_9/*9*/
					, BKANGIKIEML.NODKLJHEAJB.MLINGAKKDEP_8/*8*/
					, BKANGIKIEML.NODKLJHEAJB.OEFNIAKHGKD_7/*7*/
					, BKANGIKIEML.NODKLJHEAJB.HBIPNFMLLBF_6/*6*/
					, BKANGIKIEML.NODKLJHEAJB.BBAEIHMIFFI_11/*0xb*/ }[_CHOFDPDFPDC_ConfigValue - 1];
			case LOEGALDKHPL.CHPEIDMDNFP/*0x10*/:
			case LOEGALDKHPL.ANALBHDNGKP/*0x52*/:
			case LOEGALDKHPL.LMFBIGPJMFM/*0x58*/:
				return BKANGIKIEML.NODKLJHEAJB.DFEBFNNJMBM_32/*0x20*/;
			case LOEGALDKHPL.ECOEJFBAABC/*0x11*/:
			case LOEGALDKHPL.BFIIIGLDKNN/*0x21*/:
			case LOEGALDKHPL.MCBICLJIJMK_42/*0x2a*/:
			case LOEGALDKHPL.BHJDMGFAPLG/*0x3e*/:
			case LOEGALDKHPL.PAGIHFIMLCK/*0x59*/:
				return BKANGIKIEML.NODKLJHEAJB.ADNIADMMBPM_21/*0x15*/;
			case LOEGALDKHPL.GKHJKFJFAHO/*0x14*/:
			case LOEGALDKHPL.NEIJFCOANMA_50/*0x32*/:
			case LOEGALDKHPL.HIFAMABBNIE/*0x41*/:
				return BKANGIKIEML.NODKLJHEAJB.EKHDECEEFFJ_4/*4*/;
			case LOEGALDKHPL.OLPLKIAHMOG/*0x18*/:
				return BKANGIKIEML.NODKLJHEAJB.IJMFEGLNDFI_30/*0x1e*/;
			case LOEGALDKHPL.LAFFLNEDNDO/*0x19*/:
				return BKANGIKIEML.NODKLJHEAJB.KKFFEJEKFEG/*0x1d*/;
			case LOEGALDKHPL.HDJGNKOIMOH/*0x1a*/:
				return BKANGIKIEML.NODKLJHEAJB.GFCAMHABJIC_22/*0x16*/;
			case LOEGALDKHPL.NDHANBGPBBP/*0x1c*/:
			case LOEGALDKHPL.PEPILDAEIEL/*0x2d*/:
			case LOEGALDKHPL.FMGMIOKOPKP/*0x38*/:
				return BKANGIKIEML.NODKLJHEAJB.HGOGFPOCKFA_31/*0x1f*/;
			case LOEGALDKHPL.DBAKKHLLCNC/*0x1f*/:
			case LOEGALDKHPL.LANICCFBKAI/*0x4b*/:
			case LOEGALDKHPL.LHBGGMLDOHH/*0x57*/:
				return BKANGIKIEML.NODKLJHEAJB.LJILBHPMPOG_34/*0x22*/;
			case LOEGALDKHPL.FMOCAEEMHFJ/*0x2b*/:
				if (CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_PlayerData.KCCLEHLLOFG_Common.KIECDDFNCAN_Level > 2)
					return BKANGIKIEML.NODKLJHEAJB.PAAIHBHJJMM_3/*3*/;
				return BKANGIKIEML.NODKLJHEAJB.MGJDKBFHDML_5/*5*/;
			case LOEGALDKHPL.GNLPMEDLIJJ/*0x2c*/:
			case LOEGALDKHPL.AFLMHBMBNBO_48/*0x30*/:
				return BKANGIKIEML.NODKLJHEAJB.OBBOJKJAHIE_20/*20*/;
			case LOEGALDKHPL.PBKOKCHKGGL_46/*0x2e*/:
				return BKANGIKIEML.NODKLJHEAJB.ICAPJDDJIEA_23/*0x17*/;
			case LOEGALDKHPL.NEMNEDBLJEM/*0x33*/:
				DEKKMGAFJCG_Diva.MNNLOBDPCCH_DivaInfo diva = CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_PlayerData.DGCJCAHIAPP_Diva.NBIGLBMHEDC_DivaList[0];
				if (diva.CPGFPEDMDEH_Have != 0)
				{
					if(diva.BEEAIAAJOHD_CostumeId != 2)
					{
						return BKANGIKIEML.NODKLJHEAJB.KBHGPMNGALJ_33/*33*/;
					}
					AMCGONHBGGF unit = CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_PlayerData.MLAFAACKKBG_Unit.FJDDNKGHPHN_GetDefault().FDBOPFEOENF_Diva[0];
					if (unit.DIPKCALNIII_DivaId == 1)
						return BKANGIKIEML.NODKLJHEAJB.MGJDKBFHDML_5/*5*/;
				}
				return BKANGIKIEML.NODKLJHEAJB.OBBOJKJAHIE_20/*20*/;
			case LOEGALDKHPL.LOKMFLKHIPG/*0x35*/:
			case LOEGALDKHPL.HDHEKLONOGD/*0x46*/:
				return BKANGIKIEML.NODKLJHEAJB.LEHHJINPFHA_37/*0x25*/;
			case LOEGALDKHPL.NMBILGNHKFC/*0x36*/:
			case LOEGALDKHPL.KKIEICKBEEF/*0x37*/:
			case LOEGALDKHPL.AJLNMHBKMLE/*0x3a*/:
				return BKANGIKIEML.NODKLJHEAJB.OCNIBCBBLAA_36/*0x24*/;
			case LOEGALDKHPL.OECPMGEPMHC/*0x3c*/:
				return BKANGIKIEML.NODKLJHEAJB.FNILHIFGOCE_15/*0xf*/;
			case LOEGALDKHPL.CKENLOAPCEC/*0x3d*/:
				return BKANGIKIEML.NODKLJHEAJB.NHIOLMNADIO_35/*0x23*/;
			case LOEGALDKHPL.CKOOMMACNKA/*0x42*/:
			case LOEGALDKHPL.DOIFAGIGLEE/*0x43*/:
				return BKANGIKIEML.NODKLJHEAJB.HHFLHPFJMPN_39/*0x27*/;
			case LOEGALDKHPL.MOKJAMEPIMK/*0x48*/:
				return BKANGIKIEML.NODKLJHEAJB.OBDLOMGHHED_12/*0xc*/;
			case LOEGALDKHPL.CHANJDIDJOH/*0x49*/:
				return BKANGIKIEML.NODKLJHEAJB.LINKBPIPHAK_17/*0x11*/;
			case LOEGALDKHPL.MENBLIKPJMC/*0x4e*/:
				return BKANGIKIEML.NODKLJHEAJB.JDCENDOKKIE_41/*0x29*/;
			case LOEGALDKHPL.JAMJLBCKHHB/*0x4f*/:
			case LOEGALDKHPL.BFHKNEJHFLH/*0x50*/:
			case LOEGALDKHPL.HOHJCNDMDCD/*0x51*/:
			case LOEGALDKHPL.AIKOJFKHPMO/*0x53*/:
			case LOEGALDKHPL.EMKEFFFNBGG/*0x56*/:
				return BKANGIKIEML.NODKLJHEAJB.AGCMIOFBFMG_10/*10*/;
			case LOEGALDKHPL.FJCFIBPGLDG/*0x54*/:
				return BKANGIKIEML.NODKLJHEAJB.KJAFDMGNBPO_43/*0x2b*/;
			case LOEGALDKHPL.DNLGEBHGKGL/*0x55*/:
				return BKANGIKIEML.NODKLJHEAJB.CLJHDIKFECG_42/*0x2a*/;
		}
	}

	//// RVA: 0x9F4608 Offset: 0x9F4608 VA: 0x9F4608
	public static BKANGIKIEML.NODKLJHEAJB ODEHLBNBPPE(IKDICBBFBMI_EventBase FBFNJMKPBBA)
	{
        OHCAABOMEOF.KGOGMKMBCPP_EventType type = FBFNJMKPBBA.HIDHLFCBIDE_EventType;
        if (type >= OHCAABOMEOF.KGOGMKMBCPP_EventType.ENPJADLIFAB_EventSp && type < OHCAABOMEOF.KGOGMKMBCPP_EventType.DMPMKBCPHMA_PresentCampaign/*9*/)
		{
            IKDICBBFBMI_EventBase ev = JEPBIIJDGEF_EventInfo.HHCJCDFCLOB.MKBJOOAILBB_GetEventByStatus(KGCNCBOKCBA.GNENJEHKMHD_EventStatus.BCKENOKGLIJ_9_ResultRewardreceived, false);
			if(ev == null)
				return BKANGIKIEML.NODKLJHEAJB.HJNNKCMLGFL_0_None;
			type = ev.HIDHLFCBIDE_EventType;
        }
		if ((int)type - 1 > 13)
			return 0;
		return new BKANGIKIEML.NODKLJHEAJB[14]
		{
			BKANGIKIEML.NODKLJHEAJB.KIBGKANOLLP_25/*25*/,
			BKANGIKIEML.NODKLJHEAJB.DFDKJPOHGAD_26/*26*/,
			BKANGIKIEML.NODKLJHEAJB.PHKLLDPCDBO_24/*24*/,
			BKANGIKIEML.NODKLJHEAJB.HJNNKCMLGFL_0_None/*0*/,
			BKANGIKIEML.NODKLJHEAJB.HJNNKCMLGFL_0_None/*0*/,
			BKANGIKIEML.NODKLJHEAJB.PHKLLDPCDBO_24/*24*/,
			BKANGIKIEML.NODKLJHEAJB.HJNNKCMLGFL_0_None/*0*/,
			BKANGIKIEML.NODKLJHEAJB.HJNNKCMLGFL_0_None/*0*/,
			BKANGIKIEML.NODKLJHEAJB.HJNNKCMLGFL_0_None/*0*/,
			BKANGIKIEML.NODKLJHEAJB.FNILHIFGOCE_15/*15*/,
			BKANGIKIEML.NODKLJHEAJB.JBMMAOHHEJH_27/*27*/,
			BKANGIKIEML.NODKLJHEAJB.BPNDHDHHKGE_38/*38*/,
			BKANGIKIEML.NODKLJHEAJB.HJNNKCMLGFL_0_None/*0*/,
			BKANGIKIEML.NODKLJHEAJB.CJCABIKGFGG_28/*28*/
		}[(int)type - 1];
	}

	//// RVA: 0x9F474C Offset: 0x9F474C VA: 0x9F474C
	public static BKANGIKIEML.NODKLJHEAJB HNHNHHCBLDE(AKIIJBEJOEP _NDFIEMPPMLF_master, IKDICBBFBMI_EventBase FBFNJMKPBBA)
	{
		if (_NDFIEMPPMLF_master == null || FBFNJMKPBBA == null)
			return 0;
		BKANGIKIEML.NODKLJHEAJB res = BKANGIKIEML.NODKLJHEAJB.PAAIHBHJJMM_3/*3*/;
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
					return BKANGIKIEML.NODKLJHEAJB.MGJDKBFHDML_5/*5*/;
				res = BKANGIKIEML.NODKLJHEAJB.GAPJLFLINME_16/*16*/;
				switch(_NDFIEMPPMLF_master.HMOJCCPIPBP_TargetMusicType)
				{
					case 1:
						if (FBFNJMKPBBA.HIDHLFCBIDE_EventType == OHCAABOMEOF.KGOGMKMBCPP_EventType.DAMDPLEBNCB_AprilFool)
							return BKANGIKIEML.NODKLJHEAJB.FNILHIFGOCE_15/*15*/;
						int EHDDADDKMFI_f_id = _NDFIEMPPMLF_master.HBJJCDIMOPO_TargetMusicConditionId;
						int idx = JEPBIIJDGEF_EventInfo.HHCJCDFCLOB.HEACCHAKMFG_GetMusicsList(FBFNJMKPBBA).FindIndex((int _GHPLINIACBB_x) =>
						{
							//0x9F61A4
							return EHDDADDKMFI_f_id == _GHPLINIACBB_x;
						});
						if(idx < 0)
							return BKANGIKIEML.NODKLJHEAJB.FNILHIFGOCE_15/*15*/;
						break;
					case 2:
						return BKANGIKIEML.NODKLJHEAJB.ANBJBLLMHMB_18/*18*/;
					case 3:
						if (_NDFIEMPPMLF_master.HBJJCDIMOPO_TargetMusicConditionId > 0 && _NDFIEMPPMLF_master.HBJJCDIMOPO_TargetMusicConditionId < 6)
							return new BKANGIKIEML.NODKLJHEAJB[5] {
								BKANGIKIEML.NODKLJHEAJB.GONENLHJLCJ_9/*9*/,
								BKANGIKIEML.NODKLJHEAJB.MLINGAKKDEP_8/*8*/, 
								BKANGIKIEML.NODKLJHEAJB.OEFNIAKHGKD_7/*7*/,
								BKANGIKIEML.NODKLJHEAJB.HBIPNFMLLBF_6/*6*/,
								BKANGIKIEML.NODKLJHEAJB.BBAEIHMIFFI_11/*11*/
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
						return BKANGIKIEML.NODKLJHEAJB.MGJDKBFHDML_5/*5*/;
					case 6:
						return res;
				}
				return ODEHLBNBPPE(FBFNJMKPBBA);
			case 18:
				break;
			case 19:
			case 20:
				res = BKANGIKIEML.NODKLJHEAJB.HJNNKCMLGFL_0_None/*0*/;
				break;
			case 21:
			case 26:
				res = BKANGIKIEML.NODKLJHEAJB.NHIOLMNADIO_35/*35*/;
				break;
			case 31:
				res = BKANGIKIEML.NODKLJHEAJB.OCNIBCBBLAA_36;
				break;
			case 32:
				res = BKANGIKIEML.NODKLJHEAJB.DFEBFNNJMBM_32;
				break;
			case 33:
				res = BKANGIKIEML.NODKLJHEAJB.PKHEABDDHKB_40;
				break;
			case 49:
				res = BKANGIKIEML.NODKLJHEAJB.GFLALMCKGAH_19/*19*/;
				break;
		}
		return res;
	}

	//// RVA: 0x9F3E6C Offset: 0x9F3E6C VA: 0x9F3E6C
	public static int KPEDEPGGMEC_GetDailyQuestStatus(int _CMEJFJFOIIJ_QuestId, OKGLGHCBCJP_Database _LKMHPJKIFDN_md, BBHNACPENDM_ServerSaveData _LDEGEHAEALK_ServerData)
	{
		CNLPPCFJEID_QuestInfo dbQuest = _LKMHPJKIFDN_md.MHGPMMIDKMM_Quest.BEGCHDHHEKC_DailyQuests[_CMEJFJFOIIJ_QuestId - 1];
		NFPHOINMHKN_QuestInfo saveQuest = _LDEGEHAEALK_ServerData.GOACJBOCLHH_Quest.BEGCHDHHEKC_DailyQuests[_CMEJFJFOIIJ_QuestId - 1];
		if (dbQuest.INDDJNMPONH_Type == 0)
			return 0;
		if(saveQuest.EALOBDHOCHP_Stat != 1)
		{
			return saveQuest.EALOBDHOCHP_Stat;
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
		if(dbQuest.INDDJNMPONH_Type != 0)
		{
			int a = 0;
			if (saveQuest.EALOBDHOCHP_Stat > 1)
				return saveQuest.EALOBDHOCHP_Stat;
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
						a = s2.EALOBDHOCHP_Stat;
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
					if (ev.NGOFCFJHOMI_Status > KGCNCBOKCBA.GNENJEHKMHD_EventStatus.MEAJLPAHINL_ChallengePeriod_5/*5*/)
						return 0;
				}
				return (dbQuest.HHIBBHFHENH_LinkQuestId == 0 || a > 1) ? 1 : 0;
			}
		}
		return c;
	}

	// RVA: 0x9F5228 Offset: 0x9F5228 VA: 0x9F5228
	public static void MOFIPNGNNPA(LOEGALDKHPL _INDDJNMPONH_Type, OKGLGHCBCJP_Database _LKMHPJKIFDN_md, BBHNACPENDM_ServerSaveData _LDEGEHAEALK_ServerData, int _EALOBDHOCHP_Stat, bool _FBBNPFFEJBN_Force/* = false*/)
	{
		if((int)_INDDJNMPONH_Type > 39)
		{
			if((int)_INDDJNMPONH_Type < 53)
			{
				if(!DDJGDCHMCBN(_INDDJNMPONH_Type))
				{
					CNLPPCFJEID_QuestInfo c = _LKMHPJKIFDN_md.MHGPMMIDKMM_Quest.GPMKFMFEKLN_NormalQuests.Find((CNLPPCFJEID_QuestInfo _GHPLINIACBB_x) =>
					{
						//0x9F60D8
						return (int)_INDDJNMPONH_Type == _GHPLINIACBB_x.INDDJNMPONH_Type;
					});
					if(c != null)
					{
						NFPHOINMHKN_QuestInfo n = _LDEGEHAEALK_ServerData.GOACJBOCLHH_Quest.GPMKFMFEKLN_NormalQuests[c.PPFNGGCBJKC_id - 1];
						if(!_FBBNPFFEJBN_Force)
						{
							if (_EALOBDHOCHP_Stat <= n.EALOBDHOCHP_Stat)
								return;
						}
						n.EALOBDHOCHP_Stat = _EALOBDHOCHP_Stat;
					}
				}
			}
		}
	}

	//// RVA: 0x9F54E8 Offset: 0x9F54E8 VA: 0x9F54E8
	public static void MOFIPNGNNPA(LOEGALDKHPL _INDDJNMPONH_Type, int _EALOBDHOCHP_Stat/* = 2*/, bool _FBBNPFFEJBN_Force/* = false*/)
	{
		if(CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_PlayerData != null && IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database != null)
		{
			MOFIPNGNNPA(_INDDJNMPONH_Type, IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database, CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_PlayerData, _EALOBDHOCHP_Stat, _FBBNPFFEJBN_Force);
		}
	}

	//// RVA: 0x9F5634 Offset: 0x9F5634 VA: 0x9F5634
	public static int BFLCENAJOEN(LOEGALDKHPL _INDDJNMPONH_Type)
	{
		CNLPPCFJEID_QuestInfo c = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.MHGPMMIDKMM_Quest.GPMKFMFEKLN_NormalQuests.Find((CNLPPCFJEID_QuestInfo _GHPLINIACBB_x) =>
		{
			//0x9F611C
			return _GHPLINIACBB_x.INDDJNMPONH_Type == (int)_INDDJNMPONH_Type;
		});
		if(c != null)
		{
			return CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_PlayerData.GOACJBOCLHH_Quest.GPMKFMFEKLN_NormalQuests[c.PPFNGGCBJKC_id - 1].EALOBDHOCHP_Stat;
		}
		return 0;
	}

	//// RVA: 0x9F58BC Offset: 0x9F58BC VA: 0x9F58BC
	public static void HECOAKHIAKP(LOEGALDKHPL _INDDJNMPONH_Type, int _EALOBDHOCHP_Stat/* = 2*/, bool _FBBNPFFEJBN_Force/* = false*/)
	{
		CNLPPCFJEID_QuestInfo quest = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.MHGPMMIDKMM_Quest.GPMKFMFEKLN_NormalQuests.Find((CNLPPCFJEID_QuestInfo _GHPLINIACBB_x) =>
		{
			//0x9F6160
			return _GHPLINIACBB_x.INDDJNMPONH_Type == (int)_INDDJNMPONH_Type;
		});
		if(quest != null)
		{
			NFPHOINMHKN_QuestInfo q = CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_PlayerData.GOACJBOCLHH_Quest.GPMKFMFEKLN_NormalQuests[quest.PPFNGGCBJKC_id - 1];
			if(!_FBBNPFFEJBN_Force)
			{
				if (_EALOBDHOCHP_Stat <= q.EALOBDHOCHP_Stat)
					return;
			}
			q.EALOBDHOCHP_Stat = _EALOBDHOCHP_Stat;
		}
	}

	//// RVA: 0x9F5B78 Offset: 0x9F5B78 VA: 0x9F5B78
	public static bool FJFPHHEFMIB_IsSnsMission(CNLPPCFJEID_QuestInfo _MABBBOEAPAA_p)
	{
		if (_MABBBOEAPAA_p.INDDJNMPONH_Type != 28)
			return _MABBBOEAPAA_p.INDDJNMPONH_Type == 56;
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
					if(saveQuests[i].EALOBDHOCHP_Stat < 2)
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
	public static void CIEDCPPINCB(int _CMEJFJFOIIJ_QuestId, int _EALOBDHOCHP_Stat/* = 2*/)
	{
		CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_PlayerData.GOACJBOCLHH_Quest.GPMKFMFEKLN_NormalQuests[_CMEJFJFOIIJ_QuestId - 1].EALOBDHOCHP_Stat = _EALOBDHOCHP_Stat;
	}
}
