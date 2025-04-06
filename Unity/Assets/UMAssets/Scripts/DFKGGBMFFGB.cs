using System.Collections.Generic;
using XeApp.Game.Common;
using XeSys;

public delegate bool KDMCFCBMAOI(int AHHJLDLAPAN, int LGBDBBFEPGL, int BCCHOBPJJKE);
public delegate bool BLHOMPPGBMI(int AHHJLDLAPAN, int LGBDBBFEPGL, int BCCHOBPJJKE);

[System.Obsolete("Use DFKGGBMFFGB_PlayerInfo", true)]
public class DFKGGBMFFGB { }
public class DFKGGBMFFGB_PlayerInfo
{
	private BBHNACPENDM_ServerSaveData LDEGEHAEALK_ServerSave; // 0x8
	private OKGLGHCBCJP_Database LKMHPJKIFDN_Database; // 0xC
	private bool BNFDBPPOAOE; // 0x10
	public List<FFHPBEPOMAK_DivaInfo> NBIGLBMHEDC_Divas = new List<FFHPBEPOMAK_DivaInfo>(); // 0x14
	public List<GCIJNCFDNON_SceneInfo> OPIBAPEGCLA_Scenes = new List<GCIJNCFDNON_SceneInfo>(); // 0x18
	public List<JLKEOGLJNOD_TeamInfo> EHGGOAGEGIM_UnitsNormal; // 0x1C
	public JLKEOGLJNOD_TeamInfo NPFCMHCCDDH; // 0x20
	public List<JLKEOGLJNOD_TeamInfo> HDCBAOKMFAH_UnitsGoDiva; // 0x24
	public JLKEOGLJNOD_TeamInfo LEIGKLOGCPF_MainUnitGoDiva; // 0x28
	public IAPDFOPPGND NDOLELKAJNL_Degree; // 0x2C
	public bool JBCIDDKDJMM; // 0x30
	public int BJGOPOEAAIC; // 0x34
	public HighScoreRatingRank.Type AGJIIKKOKFJ_MusicRate = HighScoreRatingRank.Type.Be; // 0x38

	public BBHNACPENDM_ServerSaveData AHEFHIMGIBI_ServerSave { get { return LDEGEHAEALK_ServerSave; } } // GNMGJMDJEGI 0x197E7F0
	// public int NLMELNHPIID { get; set; }//DBEFCECMFMG 0x197E8C0 ILFOOPKEKLC 0x197E90C

	// // RVA: 0x197E960 Offset: 0x197E960 VA: 0x197E960
	public void KHEKNNFCAOI_Init(BBHNACPENDM_ServerSaveData NIMOGBDCMLJ_ServerSave, bool HEHLHEKCIFF = false)
	{
		BNFDBPPOAOE = true;
		if(NIMOGBDCMLJ_ServerSave == null)
			NIMOGBDCMLJ_ServerSave = CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave;
		LDEGEHAEALK_ServerSave = NIMOGBDCMLJ_ServerSave;
		LKMHPJKIFDN_Database = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database;
		NBIGLBMHEDC_Divas.Clear();
		OPIBAPEGCLA_Scenes.Clear();
		if(LDEGEHAEALK_ServerSave.PNLOINMCCKH_Scene != null)
		{
			int num = LDEGEHAEALK_ServerSave.PNLOINMCCKH_Scene.OPIBAPEGCLA.Count;
			if (LDEGEHAEALK_ServerSave.PNLOINMCCKH_Scene.OPIBAPEGCLA.Count > LKMHPJKIFDN_Database.ECNHDEHADGL_Scene.CDENCMNHNGA_SceneList.Count)
			{
				num = LKMHPJKIFDN_Database.ECNHDEHADGL_Scene.CDENCMNHNGA_SceneList.Count;
			}
			for(int i = 0; i < num; i++)
			{
				MLIBEPGADJH_Scene.KKLDOOJBJMN dbScene = LKMHPJKIFDN_Database.ECNHDEHADGL_Scene.CDENCMNHNGA_SceneList[i];
				MMPBPOIFDAF_Scene.PMKOFEIONEG saveScene = LDEGEHAEALK_ServerSave.PNLOINMCCKH_Scene.OPIBAPEGCLA[i];
				GCIJNCFDNON_SceneInfo data = new GCIJNCFDNON_SceneInfo();
				data.KHEKNNFCAOI(dbScene.BCCHOBPJJKE_Id, saveScene.PDNIFBEGMHC_Mb, saveScene.EMOJHJGHJLN_Sb, saveScene.JPIPENJGGDD_Mlt, saveScene.IELENGDJPHF_Ulk, saveScene.MJBODMOLOBC_Luck, saveScene.LHMOAJAIJCO_New, saveScene.BEBJKJKBOGH_Date, saveScene.DMNIMMGGJJJ_Leaf);
				OPIBAPEGCLA_Scenes.Add(data);
			}
		}
		if(LDEGEHAEALK_ServerSave.DGCJCAHIAPP_Diva != null)
		{
			int sId = 1;
			for (int i = 0; i < LKMHPJKIFDN_Database.MGFMPKLLGHE_Diva.CDENCMNHNGA_Divas.Count; i++)
			{
				if (HEHLHEKCIFF)
				{
					for (int j = 0; j < LKMHPJKIFDN_Database.MGFMPKLLGHE_Diva.CDENCMNHNGA_Divas.Count; j++)
					{
						if(LDEGEHAEALK_ServerSave.DGCJCAHIAPP_Diva.LGKFMLIOPKL_GetDivaInfo(j + 1).PIGLAEFPNEK_MSlot == 0)
						{
							LDEGEHAEALK_ServerSave.DGCJCAHIAPP_Diva.LGKFMLIOPKL_GetDivaInfo(j + 1).PIGLAEFPNEK_MSlot = sId;
							if(!LDEGEHAEALK_ServerSave.PNLOINMCCKH_Scene.OPIBAPEGCLA[sId - 1].IHIAFIHAAPO_Unlocked)
							{
								LDEGEHAEALK_ServerSave.PNLOINMCCKH_Scene.OPIBAPEGCLA[sId - 1].BEBJKJKBOGH_Date = Utility.GetCurrentUnixTime();
							}
							sId++;
						}
						if(i <= 2 && j <= 2)
						{
							if(LDEGEHAEALK_ServerSave.PNLOINMCCKH_Scene.OPIBAPEGCLA.Count > sId)
							{
								LDEGEHAEALK_ServerSave.PNLOINMCCKH_Scene.OPIBAPEGCLA[sId - 1].BEBJKJKBOGH_Date = Utility.GetCurrentUnixTime();
								LDEGEHAEALK_ServerSave.DGCJCAHIAPP_Diva.LGKFMLIOPKL_GetDivaInfo(j + 1).EBDNICPAFLB_SSlot[0] = sId;
								sId++;
							}
							if(LDEGEHAEALK_ServerSave.PNLOINMCCKH_Scene.OPIBAPEGCLA.Count > sId)
							{
								LDEGEHAEALK_ServerSave.PNLOINMCCKH_Scene.OPIBAPEGCLA[sId - 1].BEBJKJKBOGH_Date = Utility.GetCurrentUnixTime();
								LDEGEHAEALK_ServerSave.DGCJCAHIAPP_Diva.LGKFMLIOPKL_GetDivaInfo(j + 1).EBDNICPAFLB_SSlot[0] = sId;
								sId++;
							}
						}
					}
				}
				FFHPBEPOMAK_DivaInfo data = new FFHPBEPOMAK_DivaInfo();
				data.KHEKNNFCAOI(LKMHPJKIFDN_Database.MGFMPKLLGHE_Diva.CDENCMNHNGA_Divas[i].AHHJLDLAPAN_DivaId, LDEGEHAEALK_ServerSave, false);
				NBIGLBMHEDC_Divas.Add(data);
			}
		}
		if(LDEGEHAEALK_ServerSave.MLAFAACKKBG_Unit != null)
		{
			if(NPFCMHCCDDH == null)
				NPFCMHCCDDH = new JLKEOGLJNOD_TeamInfo();
			if (EHGGOAGEGIM_UnitsNormal == null)
				EHGGOAGEGIM_UnitsNormal = new List<JLKEOGLJNOD_TeamInfo>();
			NPFCMHCCDDH.PJOOMNIEGPP(NBIGLBMHEDC_Divas, LDEGEHAEALK_ServerSave);
			EHGGOAGEGIM_UnitsNormal.Clear();
			for(int i = 1; i < 16; i++)
			{
				JLKEOGLJNOD_TeamInfo data = new JLKEOGLJNOD_TeamInfo();
				data.KHEKNNFCAOI_Init(i, OPIBAPEGCLA_Scenes, LDEGEHAEALK_ServerSave);
				EHGGOAGEGIM_UnitsNormal.Add(data);
			}
		}
		if(LDEGEHAEALK_ServerSave.KMBJGAHCBDI_UnitGoDiva != null)
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
			if(LDEGEHAEALK_ServerSave.MHEAEGMIKIE_PublicStatus == null)
			{
				NDOLELKAJNL_Degree.KHEKNNFCAOI_Init(1, 0);
			}
			else
			{
				NDOLELKAJNL_Degree.KHEKNNFCAOI_Init(LDEGEHAEALK_ServerSave.MHEAEGMIKIE_PublicStatus.ABLOIBMGLFD_EmId, LDEGEHAEALK_ServerSave.MHEAEGMIKIE_PublicStatus.FHCAFLCLGAA_EmCnt);
			}
		}
		HighScoreRating r = new HighScoreRating();
		r.CalcUtaRate(LDEGEHAEALK_ServerSave.LCKMBHDMPIP_RecordMusic, true);
		BJGOPOEAAIC = r.GetUtaRateTotal();
		AGJIIKKOKFJ_MusicRate = r.GetUtaGrade();
		NJHBALJBFDK();
	}

	// // RVA: 0x19801C4 Offset: 0x19801C4 VA: 0x19801C4
	// public bool OKDIEDCGODF(int AHHJLDLAPAN, int BCCHOBPJJKE, bool ILBBPPMLLFM, KDMCFCBMAOI BBEBHGEHMMI, BLHOMPPGBMI NGMPDMCBNJB) { }

	// // RVA: 0x19802A4 Offset: 0x19802A4 VA: 0x19802A4
	// public bool IFFMDJHENHB(int AHHJLDLAPAN, int IMJIADPJJMM, int BCCHOBPJJKE, bool ILBBPPMLLFM, KDMCFCBMAOI BBEBHGEHMMI, BLHOMPPGBMI NGMPDMCBNJB) { }

	// // RVA: 0x198038C Offset: 0x198038C VA: 0x198038C
	public bool POJLFHIAGID(int AHHJLDLAPAN, int LGBDBBFEPGL, int BCCHOBPJJKE)
	{
		if(LGBDBBFEPGL == 2)
		{
			NBIGLBMHEDC_Divas[AHHJLDLAPAN - 1].IFFMDJHENHB(1, BCCHOBPJJKE, false, null, null);
		}
		else if(LGBDBBFEPGL == 1)
		{
			NBIGLBMHEDC_Divas[AHHJLDLAPAN - 1].IFFMDJHENHB(0, BCCHOBPJJKE, false, null, null);
		}
		else if(LGBDBBFEPGL == 0)
		{
			NBIGLBMHEDC_Divas[AHHJLDLAPAN - 1].OKDIEDCGODF(BCCHOBPJJKE, false, null, null);
		}
		return true;
	}

	// // RVA: 0x1980528 Offset: 0x1980528 VA: 0x1980528
	public bool HJBAALOOKMO(int AHHJLDLAPAN, int LGBDBBFEPGL, int BCCHOBPJJKE)
	{
		if(LGBDBBFEPGL == 2)
		{
			NBIGLBMHEDC_Divas[AHHJLDLAPAN - 1].BCEJOOCGBFG(1, false);
		}
		else if(LGBDBBFEPGL == 1)
		{
			NBIGLBMHEDC_Divas[AHHJLDLAPAN - 1].BCEJOOCGBFG(0, false);
		}
		else if(LGBDBBFEPGL == 0)
		{
			NBIGLBMHEDC_Divas[AHHJLDLAPAN - 1].MNBNLONEDPF(false);
		}
		return true;
	}

	// // RVA: 0x1980698 Offset: 0x1980698 VA: 0x1980698
	public void LCCKKHFEIGH(int IMJIADPJJMM)
	{
		NPFCMHCCDDH.GHNBDOLODJK_CopyScore(EHGGOAGEGIM_UnitsNormal[IMJIADPJJMM]);
		for(int i = 0; i < NPFCMHCCDDH.BCJEAJPLGMB_MainDivas.Count; i++)
		{
			AMCGONHBGGF a = LDEGEHAEALK_ServerSave.MLAFAACKKBG_Unit.FJDDNKGHPHN_GetDefault().FDBOPFEOENF_MainDivas[i];
			if(a.DIPKCALNIII_Id == 0)
			{
				NPFCMHCCDDH.BCJEAJPLGMB_MainDivas[i] = null;
			}
			else
			{
				NPFCMHCCDDH.BCJEAJPLGMB_MainDivas[i] = NBIGLBMHEDC_Divas[a.DIPKCALNIII_Id - 1];
				NPFCMHCCDDH.BCJEAJPLGMB_MainDivas[i].HOOJOFACOEK_SetCostume(a.BEEAIAAJOHD_CId, a.AFNIOJHODAG_ColId, false, false);
				NPFCMHCCDDH.BCJEAJPLGMB_MainDivas[i].GFHOGBPOJDN(a.EBDNICPAFLB_SSlot[0], a.EBDNICPAFLB_SSlot[1], a.EBDNICPAFLB_SSlot[2], HJBAALOOKMO);
			}
		}
		for(int i = 0; i < NPFCMHCCDDH.CMOPCCAJAAO_AddDivas.Count; i++)
		{
			DKDMLOBCPFC d = LDEGEHAEALK_ServerSave.MLAFAACKKBG_Unit.FJDDNKGHPHN_GetDefault().KAKGHFFOAEJ_AddDivas[i];
			if(d.DIPKCALNIII_Id == 0)
			{
				NPFCMHCCDDH.CMOPCCAJAAO_AddDivas[i] = null;
			}
			else
			{
				NPFCMHCCDDH.CMOPCCAJAAO_AddDivas[i] = NBIGLBMHEDC_Divas[d.DIPKCALNIII_Id - 1];
				NPFCMHCCDDH.CMOPCCAJAAO_AddDivas[i].HOOJOFACOEK_SetCostume(d.BEEAIAAJOHD_CosId, d.AFNIOJHODAG_ColId, false, false);
			}
		}
		NPFCMHCCDDH.JOKFNBLEILN_Valkyrie.KHEKNNFCAOI_Init(EHGGOAGEGIM_UnitsNormal[IMJIADPJJMM].JOKFNBLEILN_Valkyrie.GPPEFLKGGGJ_ValkyrieId, 0, 0);
		NPFCMHCCDDH.HCDGELDHFHB();
	}

	// // RVA: 0x1980EA0 Offset: 0x1980EA0 VA: 0x1980EA0
	public void JHDADIMLHII(int AHHJLDLAPAN, int IMJIADPJJMM)
	{
		LEIGKLOGCPF_MainUnitGoDiva.BBKOIKGPLFM_CopyGoDivaScore(HDCBAOKMFAH_UnitsGoDiva[IMJIADPJJMM]);
		LEIGKLOGCPF_MainUnitGoDiva.HDKIBGDDCHB(OPIBAPEGCLA_Scenes);
		LEIGKLOGCPF_MainUnitGoDiva.JOKFNBLEILN_Valkyrie.KHEKNNFCAOI_Init(HDCBAOKMFAH_UnitsGoDiva[IMJIADPJJMM].JOKFNBLEILN_Valkyrie.GPPEFLKGGGJ_ValkyrieId, 0, 0);
		LEIGKLOGCPF_MainUnitGoDiva.HCDGELDHFHB();
		HOOJOFACOEK_SetCostume(AHHJLDLAPAN, LEIGKLOGCPF_MainUnitGoDiva.BCJEAJPLGMB_MainDivas[0].JPIDIENBGKH_CostumeId, LEIGKLOGCPF_MainUnitGoDiva.BCJEAJPLGMB_MainDivas[0].EKFONBFDAAP_ColorId);
	}

	// // RVA: 0x1981108 Offset: 0x1981108 VA: 0x1981108
	public void HOOJOFACOEK_SetCostume(int AHHJLDLAPAN, int JPIDIENBGKH, int EKFONBFDAAP)
	{
		NBIGLBMHEDC_Divas[AHHJLDLAPAN - 1].HOOJOFACOEK_SetCostume(JPIDIENBGKH, EKFONBFDAAP, false, false);
		NPFCMHCCDDH.HCDGELDHFHB();
	}

	// // RVA: 0x19811EC Offset: 0x19811EC VA: 0x19811EC
	public void OPDBFHFKKJN_SetHomeCostume(int AHHJLDLAPAN, int JPIDIENBGKH, int EKFONBFDAAP)
	{
		NBIGLBMHEDC_Divas[AHHJLDLAPAN - 1].OPDBFHFKKJN(JPIDIENBGKH, EKFONBFDAAP, false);
	}

	// // RVA: 0x19812AC Offset: 0x19812AC VA: 0x19812AC
	public void HPLIKGGILHF(int MDPKLNFFDBO)
	{
		LDEGEHAEALK_ServerSave.MHEAEGMIKIE_PublicStatus.ABLOIBMGLFD_EmId = MDPKLNFFDBO;
		LDEGEHAEALK_ServerSave.MHEAEGMIKIE_PublicStatus.FHCAFLCLGAA_EmCnt = LDEGEHAEALK_ServerSave.OFAJDLJBMEM_Emblem.MDKOHOCONKE[MDPKLNFFDBO - 1].FHCAFLCLGAA_Cnt;
		NDOLELKAJNL_Degree.KHEKNNFCAOI_Init(LDEGEHAEALK_ServerSave.MHEAEGMIKIE_PublicStatus.ABLOIBMGLFD_EmId, LDEGEHAEALK_ServerSave.MHEAEGMIKIE_PublicStatus.FHCAFLCLGAA_EmCnt);
	}

	// // RVA: 0x197FEF4 Offset: 0x197FEF4 VA: 0x197FEF4
	public void NJHBALJBFDK()
	{
		JBCIDDKDJMM = false;
		PIGBBNDPPJC p = new PIGBBNDPPJC();
		List<HMGPODKEFBA_EpisodeInfo> epsDb = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.MOLEPBNJAGE_Episode.BBAJKJPKOHD_EpisodeList;
		List<OCLHKHAMDHF_Episode.JEHNEEBBDBO_EpisodeInfo> epsSave = CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave.NGHJPEIKLJL_Episode.BBAJKJPKOHD_EpisodeList;
		for(int i = 0; i < epsDb.Count; i++)
		{
			if (epsDb[i].PPEGAKEIEGM == 2)
			{
				p.KHEKNNFCAOI(i + 1);
				if (!p.JBCIDDKDJMM)
				{
					JBCIDDKDJMM = true;
					return;
				}
			}
		}
	}

	// // RVA: 0x197FD98 Offset: 0x197FD98 VA: 0x197FD98
	public void HMCMKKNLBII_LoadGoDivaUnit(int AHHJLDLAPAN)
	{
		LEIGKLOGCPF_MainUnitGoDiva.MDMJCIAJBKG_LoadGoDivaMainUnit(AHHJLDLAPAN, 0, OPIBAPEGCLA_Scenes, NBIGLBMHEDC_Divas, LDEGEHAEALK_ServerSave);
		HDCBAOKMFAH_UnitsGoDiva.Clear();
		for(int i = 0; i < 5; i++)
		{
			JLKEOGLJNOD_TeamInfo data = new JLKEOGLJNOD_TeamInfo();
			data.ALIMIMCBKFH_LoadGoDivaUnit(AHHJLDLAPAN, i + 1, OPIBAPEGCLA_Scenes, LDEGEHAEALK_ServerSave);
			HDCBAOKMFAH_UnitsGoDiva.Add(data);
		}
	}

	// // RVA: 0x19814C8 Offset: 0x19814C8 VA: 0x19814C8
	public JLKEOGLJNOD_TeamInfo DPLBHAIKPGL_GetTeam(bool CMEOKJMCEBH = false)
	{
		if(CMEOKJMCEBH)
			return LEIGKLOGCPF_MainUnitGoDiva;
		return NPFCMHCCDDH;
	}

	// // RVA: 0x19814DC Offset: 0x19814DC VA: 0x19814DC
	public JLKEOGLJNOD_TeamInfo JKIJFGGMNAN_GetUnit(int OIPCCBHIKIA, bool CMEOKJMCEBH_IsGoDiva/* = false*/)
	{
		return DDMBOKCCLBD_GetUnits(CMEOKJMCEBH_IsGoDiva)[OIPCCBHIKIA];
	}

	// // RVA: 0x198156C Offset: 0x198156C VA: 0x198156C
	public List<JLKEOGLJNOD_TeamInfo> DDMBOKCCLBD_GetUnits(bool CMEOKJMCEBH_IsGoDiva = false)
	{
		return CMEOKJMCEBH_IsGoDiva ? HDCBAOKMFAH_UnitsGoDiva : EHGGOAGEGIM_UnitsNormal;
	}
}
