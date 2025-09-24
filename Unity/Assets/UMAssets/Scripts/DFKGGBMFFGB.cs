using System.Collections.Generic;
using XeApp.Game.Common;
using XeSys;

public delegate bool KDMCFCBMAOI(int _AHHJLDLAPAN_DivaId, int _LGBDBBFEPGL_SceneSlotIdx, int _BCCHOBPJJKE_SceneId);
public delegate bool BLHOMPPGBMI(int _AHHJLDLAPAN_DivaId, int _LGBDBBFEPGL_SceneSlotIdx, int _BCCHOBPJJKE_SceneId);

[System.Obsolete("Use DFKGGBMFFGB_PlayerInfo", true)]
public class DFKGGBMFFGB { }
public class DFKGGBMFFGB_PlayerInfo
{
	private BBHNACPENDM_ServerSaveData LDEGEHAEALK_ServerData; // 0x8
	private OKGLGHCBCJP_Database LKMHPJKIFDN_md; // 0xC
	private bool BNFDBPPOAOE; // 0x10
	public List<FFHPBEPOMAK_DivaInfo> NBIGLBMHEDC_DivaList = new List<FFHPBEPOMAK_DivaInfo>(); // 0x14
	public List<GCIJNCFDNON_SceneInfo> OPIBAPEGCLA_Scenes = new List<GCIJNCFDNON_SceneInfo>(); // 0x18
	public List<JLKEOGLJNOD_TeamInfo> EHGGOAGEGIM_UnitsNormal; // 0x1C
	public JLKEOGLJNOD_TeamInfo NPFCMHCCDDH; // 0x20
	public List<JLKEOGLJNOD_TeamInfo> HDCBAOKMFAH_UnitsGoDiva; // 0x24
	public JLKEOGLJNOD_TeamInfo LEIGKLOGCPF_MainUnitGoDiva; // 0x28
	public IAPDFOPPGND NDOLELKAJNL_Degree; // 0x2C
	public bool JBCIDDKDJMM; // 0x30
	public int BJGOPOEAAIC_UtaRate; // 0x34
	public HighScoreRatingRank.Type AGJIIKKOKFJ_ScoreRatingRank = HighScoreRatingRank.Type.Be; // 0x38

	public BBHNACPENDM_ServerSaveData AHEFHIMGIBI_PlayerData { get { return LDEGEHAEALK_ServerData; } } // GNMGJMDJEGI 0x197E7F0
	// public int NLMELNHPIID { get; set; }//DBEFCECMFMG 0x197E8C0 ILFOOPKEKLC 0x197E90C

	public bool Unused() { return BNFDBPPOAOE; }

	// // RVA: 0x197E960 Offset: 0x197E960 VA: 0x197E960
	public void KHEKNNFCAOI_Init(BBHNACPENDM_ServerSaveData NIMOGBDCMLJ_ServerSave, bool HEHLHEKCIFF/* = false*/)
	{
		BNFDBPPOAOE = true;
		if(NIMOGBDCMLJ_ServerSave == null)
			NIMOGBDCMLJ_ServerSave = CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_PlayerData;
		LDEGEHAEALK_ServerData = NIMOGBDCMLJ_ServerSave;
		LKMHPJKIFDN_md = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database;
		NBIGLBMHEDC_DivaList.Clear();
		OPIBAPEGCLA_Scenes.Clear();
		if(LDEGEHAEALK_ServerData.PNLOINMCCKH_Scene != null)
		{
			int num = LDEGEHAEALK_ServerData.PNLOINMCCKH_Scene.OPIBAPEGCLA_Scenes.Count;
			if (LDEGEHAEALK_ServerData.PNLOINMCCKH_Scene.OPIBAPEGCLA_Scenes.Count > LKMHPJKIFDN_md.ECNHDEHADGL_Scene.CDENCMNHNGA_table.Count)
			{
				num = LKMHPJKIFDN_md.ECNHDEHADGL_Scene.CDENCMNHNGA_table.Count;
			}
			for(int i = 0; i < num; i++)
			{
				MLIBEPGADJH_Scene.KKLDOOJBJMN dbScene = LKMHPJKIFDN_md.ECNHDEHADGL_Scene.CDENCMNHNGA_table[i];
				MMPBPOIFDAF_Scene.PMKOFEIONEG saveScene = LDEGEHAEALK_ServerData.PNLOINMCCKH_Scene.OPIBAPEGCLA_Scenes[i];
				GCIJNCFDNON_SceneInfo data = new GCIJNCFDNON_SceneInfo();
				data.KHEKNNFCAOI_Init(dbScene.BCCHOBPJJKE_SceneId, saveScene.PDNIFBEGMHC_Mb, saveScene.EMOJHJGHJLN_Sb, saveScene.JPIPENJGGDD_NumBoard, saveScene.IELENGDJPHF_Ulk, saveScene.MJBODMOLOBC_luck, saveScene.LHMOAJAIJCO_is_new, saveScene.BEBJKJKBOGH_date, saveScene.DMNIMMGGJJJ_Leaf);
				OPIBAPEGCLA_Scenes.Add(data);
			}
		}
		if(LDEGEHAEALK_ServerData.DGCJCAHIAPP_Diva != null)
		{
			int sId = 1;
			for (int i = 0; i < LKMHPJKIFDN_md.MGFMPKLLGHE_Diva.CDENCMNHNGA_table.Count; i++)
			{
				if (HEHLHEKCIFF)
				{
					for (int j = 0; j < LKMHPJKIFDN_md.MGFMPKLLGHE_Diva.CDENCMNHNGA_table.Count; j++)
					{
						if(LDEGEHAEALK_ServerData.DGCJCAHIAPP_Diva.LGKFMLIOPKL_GetDivaInfo(j + 1).PIGLAEFPNEK_m_slot == 0)
						{
							LDEGEHAEALK_ServerData.DGCJCAHIAPP_Diva.LGKFMLIOPKL_GetDivaInfo(j + 1).PIGLAEFPNEK_m_slot = sId;
							if(!LDEGEHAEALK_ServerData.PNLOINMCCKH_Scene.OPIBAPEGCLA_Scenes[sId - 1].IHIAFIHAAPO_Unlocked)
							{
								LDEGEHAEALK_ServerData.PNLOINMCCKH_Scene.OPIBAPEGCLA_Scenes[sId - 1].BEBJKJKBOGH_date = Utility.GetCurrentUnixTime();
							}
							sId++;
						}
						if(i <= 2 && j <= 2)
						{
							if(LDEGEHAEALK_ServerData.PNLOINMCCKH_Scene.OPIBAPEGCLA_Scenes.Count > sId)
							{
								LDEGEHAEALK_ServerData.PNLOINMCCKH_Scene.OPIBAPEGCLA_Scenes[sId - 1].BEBJKJKBOGH_date = Utility.GetCurrentUnixTime();
								LDEGEHAEALK_ServerData.DGCJCAHIAPP_Diva.LGKFMLIOPKL_GetDivaInfo(j + 1).EBDNICPAFLB_s_slot[0] = sId;
								sId++;
							}
							if(LDEGEHAEALK_ServerData.PNLOINMCCKH_Scene.OPIBAPEGCLA_Scenes.Count > sId)
							{
								LDEGEHAEALK_ServerData.PNLOINMCCKH_Scene.OPIBAPEGCLA_Scenes[sId - 1].BEBJKJKBOGH_date = Utility.GetCurrentUnixTime();
								LDEGEHAEALK_ServerData.DGCJCAHIAPP_Diva.LGKFMLIOPKL_GetDivaInfo(j + 1).EBDNICPAFLB_s_slot[0] = sId;
								sId++;
							}
						}
					}
				}
				FFHPBEPOMAK_DivaInfo data = new FFHPBEPOMAK_DivaInfo();
				data.KHEKNNFCAOI_Init(LKMHPJKIFDN_md.MGFMPKLLGHE_Diva.CDENCMNHNGA_table[i].AHHJLDLAPAN_DivaId, LDEGEHAEALK_ServerData, false);
				NBIGLBMHEDC_DivaList.Add(data);
			}
		}
		if(LDEGEHAEALK_ServerData.MLAFAACKKBG_Unit != null)
		{
			if(NPFCMHCCDDH == null)
				NPFCMHCCDDH = new JLKEOGLJNOD_TeamInfo();
			if (EHGGOAGEGIM_UnitsNormal == null)
				EHGGOAGEGIM_UnitsNormal = new List<JLKEOGLJNOD_TeamInfo>();
			NPFCMHCCDDH.PJOOMNIEGPP(NBIGLBMHEDC_DivaList, LDEGEHAEALK_ServerData);
			EHGGOAGEGIM_UnitsNormal.Clear();
			for(int i = 1; i < 16; i++)
			{
				JLKEOGLJNOD_TeamInfo data = new JLKEOGLJNOD_TeamInfo();
				data.KHEKNNFCAOI_Init(i, OPIBAPEGCLA_Scenes, LDEGEHAEALK_ServerData);
				EHGGOAGEGIM_UnitsNormal.Add(data);
			}
		}
		if(LDEGEHAEALK_ServerData.KMBJGAHCBDI_UnitGoDiva != null)
		{
			if (LEIGKLOGCPF_MainUnitGoDiva == null)
				LEIGKLOGCPF_MainUnitGoDiva = new JLKEOGLJNOD_TeamInfo();
			if (HDCBAOKMFAH_UnitsGoDiva == null)
				HDCBAOKMFAH_UnitsGoDiva = new List<JLKEOGLJNOD_TeamInfo>();
			int centerDivaId = NPFCMHCCDDH.PDJEMLMOEPF_CenterDivaId;
			if (centerDivaId == 0)
				centerDivaId = 1;
			MANPIONIGNO_EventGoDiva evt = JEPBIIJDGEF_EventInfo.HHCJCDFCLOB.OEGDCBLNNFF(OHCAABOMEOF.KGOGMKMBCPP_EventType.BNECMLPHAGJ_EventGoDiva, KGCNCBOKCBA.GNENJEHKMHD_EventStatus.BCKENOKGLIJ_9_ResultRewardreceived) as MANPIONIGNO_EventGoDiva;
			if (evt != null)
			{
				if(evt.CLELOGKMNCE_GetEventSaveData().AFKMGCLEPGA_SelDiva > 0)
					centerDivaId = evt.CLELOGKMNCE_GetEventSaveData().AFKMGCLEPGA_SelDiva;
			}
			HMCMKKNLBII_LoadGoDivaUnit(centerDivaId);
		}
		{
			NDOLELKAJNL_Degree = new IAPDFOPPGND();
			if(LDEGEHAEALK_ServerData.MHEAEGMIKIE_PublicStatus == null)
			{
				NDOLELKAJNL_Degree.KHEKNNFCAOI_Init(1, 0);
			}
			else
			{
				NDOLELKAJNL_Degree.KHEKNNFCAOI_Init(LDEGEHAEALK_ServerData.MHEAEGMIKIE_PublicStatus.ABLOIBMGLFD_em_id, LDEGEHAEALK_ServerData.MHEAEGMIKIE_PublicStatus.FHCAFLCLGAA_em_cnt);
			}
		}
		HighScoreRating r = new HighScoreRating();
		r.CalcUtaRate(LDEGEHAEALK_ServerData.LCKMBHDMPIP_RecordMusic, true);
		BJGOPOEAAIC_UtaRate = r.GetUtaRateTotal();
		AGJIIKKOKFJ_ScoreRatingRank = r.GetUtaGrade();
		NJHBALJBFDK();
	}

	// // RVA: 0x19801C4 Offset: 0x19801C4 VA: 0x19801C4
	// public bool OKDIEDCGODF(int _AHHJLDLAPAN_DivaId, int _BCCHOBPJJKE_SceneId, bool ILBBPPMLLFM, KDMCFCBMAOI BBEBHGEHMMI, BLHOMPPGBMI NGMPDMCBNJB) { }

	// // RVA: 0x19802A4 Offset: 0x19802A4 VA: 0x19802A4
	// public bool IFFMDJHENHB(int _AHHJLDLAPAN_DivaId, int IMJIADPJJMM, int _BCCHOBPJJKE_SceneId, bool ILBBPPMLLFM, KDMCFCBMAOI BBEBHGEHMMI, BLHOMPPGBMI NGMPDMCBNJB) { }

	// // RVA: 0x198038C Offset: 0x198038C VA: 0x198038C
	public bool POJLFHIAGID(int _AHHJLDLAPAN_DivaId, int _LGBDBBFEPGL_SceneSlotIdx, int _BCCHOBPJJKE_SceneId)
	{
		if(_LGBDBBFEPGL_SceneSlotIdx == 2)
		{
			NBIGLBMHEDC_DivaList[_AHHJLDLAPAN_DivaId - 1].IFFMDJHENHB(1, _BCCHOBPJJKE_SceneId, false, null, null);
		}
		else if(_LGBDBBFEPGL_SceneSlotIdx == 1)
		{
			NBIGLBMHEDC_DivaList[_AHHJLDLAPAN_DivaId - 1].IFFMDJHENHB(0, _BCCHOBPJJKE_SceneId, false, null, null);
		}
		else if(_LGBDBBFEPGL_SceneSlotIdx == 0)
		{
			NBIGLBMHEDC_DivaList[_AHHJLDLAPAN_DivaId - 1].OKDIEDCGODF(_BCCHOBPJJKE_SceneId, false, null, null);
		}
		return true;
	}

	// // RVA: 0x1980528 Offset: 0x1980528 VA: 0x1980528
	public bool HJBAALOOKMO(int _AHHJLDLAPAN_DivaId, int _LGBDBBFEPGL_SceneSlotIdx, int BCCHOBPJJKE)
	{
		if(_LGBDBBFEPGL_SceneSlotIdx == 2)
		{
			NBIGLBMHEDC_DivaList[_AHHJLDLAPAN_DivaId - 1].BCEJOOCGBFG(1, false);
		}
		else if(_LGBDBBFEPGL_SceneSlotIdx == 1)
		{
			NBIGLBMHEDC_DivaList[_AHHJLDLAPAN_DivaId - 1].BCEJOOCGBFG(0, false);
		}
		else if(_LGBDBBFEPGL_SceneSlotIdx == 0)
		{
			NBIGLBMHEDC_DivaList[_AHHJLDLAPAN_DivaId - 1].MNBNLONEDPF(false);
		}
		return true;
	}

	// // RVA: 0x1980698 Offset: 0x1980698 VA: 0x1980698
	public void LCCKKHFEIGH(int IMJIADPJJMM)
	{
		NPFCMHCCDDH.GHNBDOLODJK_CopyScore(EHGGOAGEGIM_UnitsNormal[IMJIADPJJMM]);
		for(int i = 0; i < NPFCMHCCDDH.BCJEAJPLGMB_MainDivas.Count; i++)
		{
			AMCGONHBGGF a = LDEGEHAEALK_ServerData.MLAFAACKKBG_Unit.FJDDNKGHPHN_GetDefault().FDBOPFEOENF_diva[i];
			if(a.DIPKCALNIII_diva_id == 0)
			{
				NPFCMHCCDDH.BCJEAJPLGMB_MainDivas[i] = null;
			}
			else
			{
				NPFCMHCCDDH.BCJEAJPLGMB_MainDivas[i] = NBIGLBMHEDC_DivaList[a.DIPKCALNIII_diva_id - 1];
				NPFCMHCCDDH.BCJEAJPLGMB_MainDivas[i].HOOJOFACOEK_SetCostume(a.BEEAIAAJOHD_CostumeId, a.AFNIOJHODAG_CostumeColorId, false, false);
				NPFCMHCCDDH.BCJEAJPLGMB_MainDivas[i].GFHOGBPOJDN(a.EBDNICPAFLB_s_slot[0], a.EBDNICPAFLB_s_slot[1], a.EBDNICPAFLB_s_slot[2], HJBAALOOKMO);
			}
		}
		for(int i = 0; i < NPFCMHCCDDH.CMOPCCAJAAO_AddDivas.Count; i++)
		{
			DKDMLOBCPFC d = LDEGEHAEALK_ServerData.MLAFAACKKBG_Unit.FJDDNKGHPHN_GetDefault().KAKGHFFOAEJ_AddDivas[i];
			if(d.DIPKCALNIII_diva_id == 0)
			{
				NPFCMHCCDDH.CMOPCCAJAAO_AddDivas[i] = null;
			}
			else
			{
				NPFCMHCCDDH.CMOPCCAJAAO_AddDivas[i] = NBIGLBMHEDC_DivaList[d.DIPKCALNIII_diva_id - 1];
				NPFCMHCCDDH.CMOPCCAJAAO_AddDivas[i].HOOJOFACOEK_SetCostume(d.BEEAIAAJOHD_CostumeId, d.AFNIOJHODAG_CostumeColorId, false, false);
			}
		}
		NPFCMHCCDDH.JOKFNBLEILN_Valkyrie.KHEKNNFCAOI_Init(EHGGOAGEGIM_UnitsNormal[IMJIADPJJMM].JOKFNBLEILN_Valkyrie.GPPEFLKGGGJ_ValkyrieId, 0, 0);
		NPFCMHCCDDH.HCDGELDHFHB();
	}

	// // RVA: 0x1980EA0 Offset: 0x1980EA0 VA: 0x1980EA0
	public void JHDADIMLHII(int _AHHJLDLAPAN_DivaId, int IMJIADPJJMM)
	{
		LEIGKLOGCPF_MainUnitGoDiva.BBKOIKGPLFM_CopyGoDivaScore(HDCBAOKMFAH_UnitsGoDiva[IMJIADPJJMM]);
		LEIGKLOGCPF_MainUnitGoDiva.HDKIBGDDCHB(OPIBAPEGCLA_Scenes);
		LEIGKLOGCPF_MainUnitGoDiva.JOKFNBLEILN_Valkyrie.KHEKNNFCAOI_Init(HDCBAOKMFAH_UnitsGoDiva[IMJIADPJJMM].JOKFNBLEILN_Valkyrie.GPPEFLKGGGJ_ValkyrieId, 0, 0);
		LEIGKLOGCPF_MainUnitGoDiva.HCDGELDHFHB();
		HOOJOFACOEK_SetCostume(_AHHJLDLAPAN_DivaId, LEIGKLOGCPF_MainUnitGoDiva.BCJEAJPLGMB_MainDivas[0].JPIDIENBGKH_CostumeId, LEIGKLOGCPF_MainUnitGoDiva.BCJEAJPLGMB_MainDivas[0].EKFONBFDAAP_ColorId);
	}

	// // RVA: 0x1981108 Offset: 0x1981108 VA: 0x1981108
	public void HOOJOFACOEK_SetCostume(int _AHHJLDLAPAN_DivaId, int _JPIDIENBGKH_CostumeId, int EKFONBFDAAP)
	{
		NBIGLBMHEDC_DivaList[_AHHJLDLAPAN_DivaId - 1].HOOJOFACOEK_SetCostume(_JPIDIENBGKH_CostumeId, EKFONBFDAAP, false, false);
		NPFCMHCCDDH.HCDGELDHFHB();
	}

	// // RVA: 0x19811EC Offset: 0x19811EC VA: 0x19811EC
	public void OPDBFHFKKJN_SetHomeCostume(int _AHHJLDLAPAN_DivaId, int _JPIDIENBGKH_CostumeId, int EKFONBFDAAP)
	{
		NBIGLBMHEDC_DivaList[_AHHJLDLAPAN_DivaId - 1].OPDBFHFKKJN(_JPIDIENBGKH_CostumeId, EKFONBFDAAP, false);
	}

	// // RVA: 0x19812AC Offset: 0x19812AC VA: 0x19812AC
	public void HPLIKGGILHF(int _MDPKLNFFDBO_EmblemId)
	{
		LDEGEHAEALK_ServerData.MHEAEGMIKIE_PublicStatus.ABLOIBMGLFD_em_id = _MDPKLNFFDBO_EmblemId;
		LDEGEHAEALK_ServerData.MHEAEGMIKIE_PublicStatus.FHCAFLCLGAA_em_cnt = LDEGEHAEALK_ServerData.OFAJDLJBMEM_Emblem.MDKOHOCONKE[_MDPKLNFFDBO_EmblemId - 1].FHCAFLCLGAA_em_cnt;
		NDOLELKAJNL_Degree.KHEKNNFCAOI_Init(LDEGEHAEALK_ServerData.MHEAEGMIKIE_PublicStatus.ABLOIBMGLFD_em_id, LDEGEHAEALK_ServerData.MHEAEGMIKIE_PublicStatus.FHCAFLCLGAA_em_cnt);
	}

	// // RVA: 0x197FEF4 Offset: 0x197FEF4 VA: 0x197FEF4
	public void NJHBALJBFDK()
	{
		JBCIDDKDJMM = false;
		PIGBBNDPPJC p = new PIGBBNDPPJC();
		List<HMGPODKEFBA_EpisodeInfo> epsDb = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.MOLEPBNJAGE_Episode.BBAJKJPKOHD_EpisodeList;
		List<OCLHKHAMDHF_Episode.JEHNEEBBDBO_EpisodeInfo> epsSave = CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_PlayerData.NGHJPEIKLJL_Episode.BBAJKJPKOHD_EpisodeList;
		for(int i = 0; i < epsDb.Count; i++)
		{
			if (epsDb[i].PPEGAKEIEGM_Enabled == 2)
			{
				p.KHEKNNFCAOI_Init(i + 1);
				if (!p.JBCIDDKDJMM)
				{
					JBCIDDKDJMM = true;
					return;
				}
			}
		}
	}

	// // RVA: 0x197FD98 Offset: 0x197FD98 VA: 0x197FD98
	public void HMCMKKNLBII_LoadGoDivaUnit(int _AHHJLDLAPAN_DivaId)
	{
		LEIGKLOGCPF_MainUnitGoDiva.MDMJCIAJBKG_LoadGoDivaMainUnit(_AHHJLDLAPAN_DivaId, 0, OPIBAPEGCLA_Scenes, NBIGLBMHEDC_DivaList, LDEGEHAEALK_ServerData);
		HDCBAOKMFAH_UnitsGoDiva.Clear();
		for(int i = 0; i < 5; i++)
		{
			JLKEOGLJNOD_TeamInfo data = new JLKEOGLJNOD_TeamInfo();
			data.ALIMIMCBKFH_LoadGoDivaUnit(_AHHJLDLAPAN_DivaId, i + 1, OPIBAPEGCLA_Scenes, LDEGEHAEALK_ServerData);
			HDCBAOKMFAH_UnitsGoDiva.Add(data);
		}
	}

	// // RVA: 0x19814C8 Offset: 0x19814C8 VA: 0x19814C8
	public JLKEOGLJNOD_TeamInfo DPLBHAIKPGL_GetTeam(bool _CMEOKJMCEBH_IsGoDiva/* = false*/)
	{
		if(_CMEOKJMCEBH_IsGoDiva)
			return LEIGKLOGCPF_MainUnitGoDiva;
		return NPFCMHCCDDH;
	}

	// // RVA: 0x19814DC Offset: 0x19814DC VA: 0x19814DC
	public JLKEOGLJNOD_TeamInfo JKIJFGGMNAN_GetUnit(int _OIPCCBHIKIA_index, bool _CMEOKJMCEBH_IsGoDiva/* = false*/)
	{
		return DDMBOKCCLBD_GetUnits(_CMEOKJMCEBH_IsGoDiva)[_OIPCCBHIKIA_index];
	}

	// // RVA: 0x198156C Offset: 0x198156C VA: 0x198156C
	public List<JLKEOGLJNOD_TeamInfo> DDMBOKCCLBD_GetUnits(bool _CMEOKJMCEBH_IsGoDiva/* = false*/)
	{
		return _CMEOKJMCEBH_IsGoDiva ? HDCBAOKMFAH_UnitsGoDiva : EHGGOAGEGIM_UnitsNormal;
	}
}
