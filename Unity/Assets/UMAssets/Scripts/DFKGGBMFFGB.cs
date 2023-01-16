using System.Collections.Generic;
using XeApp.Game.Common;
using XeSys;

public delegate bool KDMCFCBMAOI(int AHHJLDLAPAN, int LGBDBBFEPGL, int BCCHOBPJJKE);
public delegate bool BLHOMPPGBMI(int AHHJLDLAPAN, int LGBDBBFEPGL, int BCCHOBPJJKE);
public class DFKGGBMFFGB
{
	private BBHNACPENDM_ServerSaveData LDEGEHAEALK_ServerSave; // 0x8
	private OKGLGHCBCJP_Database LKMHPJKIFDN_Database; // 0xC
	private bool BNFDBPPOAOE; // 0x10
	public List<FFHPBEPOMAK_DivaInfo> NBIGLBMHEDC = new List<FFHPBEPOMAK_DivaInfo>(); // 0x14
	public List<GCIJNCFDNON> OPIBAPEGCLA_Scenes = new List<GCIJNCFDNON>(); // 0x18
	public List<JLKEOGLJNOD> EHGGOAGEGIM_UnitsNormal; // 0x1C
	public JLKEOGLJNOD NPFCMHCCDDH; // 0x20
	public List<JLKEOGLJNOD> HDCBAOKMFAH_UnitsGoDiva; // 0x24
	public JLKEOGLJNOD LEIGKLOGCPF; // 0x28
	public IAPDFOPPGND NDOLELKAJNL; // 0x2C
	public bool JBCIDDKDJMM; // 0x30
	public int BJGOPOEAAIC; // 0x34
	public HighScoreRatingRank.Type AGJIIKKOKFJ = HighScoreRatingRank.Type.Be; // 0x38

	// public BBHNACPENDM AHEFHIMGIBI { get; } // GNMGJMDJEGI 0x197E7F0
	// public int NLMELNHPIID { get; set; }//DBEFCECMFMG 0x197E8C0 ILFOOPKEKLC 0x197E90C

	// // RVA: 0x197E960 Offset: 0x197E960 VA: 0x197E960
	public void KHEKNNFCAOI_Init(BBHNACPENDM_ServerSaveData NIMOGBDCMLJ_ServerSave, bool HEHLHEKCIFF = false)
	{
		BNFDBPPOAOE = true;
		if(NIMOGBDCMLJ_ServerSave == null)
			NIMOGBDCMLJ_ServerSave = CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave;
		LDEGEHAEALK_ServerSave = NIMOGBDCMLJ_ServerSave;
		LKMHPJKIFDN_Database = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database;
		NBIGLBMHEDC.Clear();
		OPIBAPEGCLA_Scenes.Clear();
		if(LDEGEHAEALK_ServerSave.PNLOINMCCKH_Scene != null)
		{
			int num = LDEGEHAEALK_ServerSave.PNLOINMCCKH_Scene.OPIBAPEGCLA.Count;
			if (LDEGEHAEALK_ServerSave.PNLOINMCCKH_Scene.OPIBAPEGCLA.Count > LKMHPJKIFDN_Database.ECNHDEHADGL_Scene.CDENCMNHNGA.Count)
			{
				num = LKMHPJKIFDN_Database.ECNHDEHADGL_Scene.CDENCMNHNGA.Count;
			}
			for(int i = 0; i < num; i++)
			{
				MLIBEPGADJH_Scene.KKLDOOJBJMN dbScene = LKMHPJKIFDN_Database.ECNHDEHADGL_Scene.CDENCMNHNGA[i];
				MMPBPOIFDAF_Scene.PMKOFEIONEG saveScene = LDEGEHAEALK_ServerSave.PNLOINMCCKH_Scene.OPIBAPEGCLA[i];
				GCIJNCFDNON data = new GCIJNCFDNON();
				data.KHEKNNFCAOI(dbScene.BCCHOBPJJKE_Id, saveScene.PDNIFBEGMHC_Mb, saveScene.EMOJHJGHJLN, saveScene.JPIPENJGGDD_Mlt, saveScene.IELENGDJPHF_Ulk, saveScene.MJBODMOLOBC_Luck, saveScene.LHMOAJAIJCO_New, saveScene.BEBJKJKBOGH_Date, saveScene.DMNIMMGGJJJ_Leaf);
				OPIBAPEGCLA_Scenes.Add(data);
			}
		}
		if(LDEGEHAEALK_ServerSave.DGCJCAHIAPP_Diva != null)
		{
			int sId = 1;
			for (int i = 0; i < LKMHPJKIFDN_Database.MGFMPKLLGHE_Diva.CDENCMNHNGA.Count; i++)
			{
				if (HEHLHEKCIFF)
				{
					for (int j = 0; j < LKMHPJKIFDN_Database.MGFMPKLLGHE_Diva.CDENCMNHNGA.Count; j++)
					{
						if(LDEGEHAEALK_ServerSave.DGCJCAHIAPP_Diva.LGKFMLIOPKL_GetDivaInfo(i + 1).PIGLAEFPNEK_MSlot == 0)
						{
							LDEGEHAEALK_ServerSave.DGCJCAHIAPP_Diva.LGKFMLIOPKL_GetDivaInfo(i + 1).PIGLAEFPNEK_MSlot = sId;
							if(!LDEGEHAEALK_ServerSave.PNLOINMCCKH_Scene.OPIBAPEGCLA[sId - 1].IHIAFIHAAPO)
							{
								LDEGEHAEALK_ServerSave.PNLOINMCCKH_Scene.OPIBAPEGCLA[sId - 1].BEBJKJKBOGH_Date = Utility.GetCurrentUnixTime();
								sId++;
							}
						}
						// ?? L428
						TodoLogger.Log(0, "TODO ?? test");
						if(i < 2 && j < 2)
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
				data.KHEKNNFCAOI(LKMHPJKIFDN_Database.MGFMPKLLGHE_Diva.CDENCMNHNGA[i].AHHJLDLAPAN, LDEGEHAEALK_ServerSave, false);
				NBIGLBMHEDC.Add(data);
			}
		}
		if(LDEGEHAEALK_ServerSave.MLAFAACKKBG_Unit != null)
		{
			if(NPFCMHCCDDH == null)
				NPFCMHCCDDH = new JLKEOGLJNOD();
			if (EHGGOAGEGIM_UnitsNormal == null)
				EHGGOAGEGIM_UnitsNormal = new List<JLKEOGLJNOD>();
			NPFCMHCCDDH.PJOOMNIEGPP(NBIGLBMHEDC, LDEGEHAEALK_ServerSave);
			EHGGOAGEGIM_UnitsNormal.Clear();
			for(int i = 1; i < 16; i++)
			{
				JLKEOGLJNOD data = new JLKEOGLJNOD();
				data.KHEKNNFCAOI_Init(i, OPIBAPEGCLA_Scenes, LDEGEHAEALK_ServerSave);
				EHGGOAGEGIM_UnitsNormal.Add(data);
			}
		}
		if(LDEGEHAEALK_ServerSave.KMBJGAHCBDI_UnitGoDiva != null)
		{
			if (LEIGKLOGCPF == null)
				LEIGKLOGCPF = new JLKEOGLJNOD();
			if (HDCBAOKMFAH_UnitsGoDiva == null)
				HDCBAOKMFAH_UnitsGoDiva = new List<JLKEOGLJNOD>();
			int centerDivaId = NPFCMHCCDDH.PDJEMLMOEPF_CenterDivaId;
			if (centerDivaId == 0)
				centerDivaId = 1;
			IKDICBBFBMI_EventBase evt = JEPBIIJDGEF_EventInfo.HHCJCDFCLOB.OEGDCBLNNFF(OHCAABOMEOF.KGOGMKMBCPP_EventType.BNECMLPHAGJ_EventGoDiva, KGCNCBOKCBA.GNENJEHKMHD.BCKENOKGLIJ);
			if (evt != null)
			{
				TodoLogger.Log(0, "Finish for event");
				//??
				//if(MANPIONIGNO_EventGoDiva evt.PMHLJAIGBGK)
			}
			HMCMKKNLBII(centerDivaId);
		}
		{
			NDOLELKAJNL = new IAPDFOPPGND();
			if(LDEGEHAEALK_ServerSave.MHEAEGMIKIE_PublicStatus == null)
			{
				NDOLELKAJNL.KHEKNNFCAOI_Init(1, 0);
			}
			else
			{
				NDOLELKAJNL.KHEKNNFCAOI_Init(LDEGEHAEALK_ServerSave.MHEAEGMIKIE_PublicStatus.ABLOIBMGLFD_EmId, LDEGEHAEALK_ServerSave.MHEAEGMIKIE_PublicStatus.FHCAFLCLGAA_EmCnt);
			}
		}
		HighScoreRating r = new HighScoreRating();
		r.CalcUtaRate(LDEGEHAEALK_ServerSave.LCKMBHDMPIP_RecordMusic, true);
		BJGOPOEAAIC = r.GetUtaRateTotal();
		AGJIIKKOKFJ = r.GetUtaGrade();
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
			NBIGLBMHEDC[AHHJLDLAPAN - 1].IFFMDJHENHB(1, BCCHOBPJJKE, false, null, null);
		}
		else if(LGBDBBFEPGL == 1)
		{
			NBIGLBMHEDC[AHHJLDLAPAN - 1].IFFMDJHENHB(0, BCCHOBPJJKE, false, null, null);
		}
		else if(LGBDBBFEPGL == 0)
		{
			NBIGLBMHEDC[AHHJLDLAPAN - 1].OKDIEDCGODF(BCCHOBPJJKE, false, null, null);
		}
		return true;
	}

	// // RVA: 0x1980528 Offset: 0x1980528 VA: 0x1980528
	public bool HJBAALOOKMO(int AHHJLDLAPAN, int LGBDBBFEPGL, int BCCHOBPJJKE)
	{
		if(LGBDBBFEPGL == 2)
		{
			NBIGLBMHEDC[AHHJLDLAPAN - 1].BCEJOOCGBFG(1, false);
		}
		else if(LGBDBBFEPGL == 1)
		{
			NBIGLBMHEDC[AHHJLDLAPAN - 1].BCEJOOCGBFG(0, false);
		}
		else if(LGBDBBFEPGL == 0)
		{
			NBIGLBMHEDC[AHHJLDLAPAN - 1].MNBNLONEDPF(false);
		}
		return true;
	}

	// // RVA: 0x1980698 Offset: 0x1980698 VA: 0x1980698
	// public void LCCKKHFEIGH(int IMJIADPJJMM) { }

	// // RVA: 0x1980EA0 Offset: 0x1980EA0 VA: 0x1980EA0
	// public void JHDADIMLHII(int AHHJLDLAPAN, int IMJIADPJJMM) { }

	// // RVA: 0x1981108 Offset: 0x1981108 VA: 0x1981108
	public void HOOJOFACOEK_SetCostume(int AHHJLDLAPAN, int JPIDIENBGKH, int EKFONBFDAAP)
	{
		NBIGLBMHEDC[AHHJLDLAPAN - 1].HOOJOFACOEK_SetCostume(JPIDIENBGKH, EKFONBFDAAP, false, false);
		NPFCMHCCDDH.HCDGELDHFHB();
	}

	// // RVA: 0x19811EC Offset: 0x19811EC VA: 0x19811EC
	public void OPDBFHFKKJN_SetHomeCostume(int AHHJLDLAPAN, int JPIDIENBGKH, int EKFONBFDAAP)
	{
		NBIGLBMHEDC[AHHJLDLAPAN - 1].OPDBFHFKKJN(JPIDIENBGKH, EKFONBFDAAP, false);
	}

	// // RVA: 0x19812AC Offset: 0x19812AC VA: 0x19812AC
	// public void HPLIKGGILHF(int MDPKLNFFDBO) { }

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
	public void HMCMKKNLBII(int AHHJLDLAPAN)
	{
		LEIGKLOGCPF.MDMJCIAJBKG(AHHJLDLAPAN, 0, OPIBAPEGCLA_Scenes, NBIGLBMHEDC, LDEGEHAEALK_ServerSave);
		HDCBAOKMFAH_UnitsGoDiva.Clear();
		for(int i = 0; i < 5; i++)
		{
			JLKEOGLJNOD data = new JLKEOGLJNOD();
			data.ALIMIMCBKFH(AHHJLDLAPAN, i + 1, OPIBAPEGCLA_Scenes, LDEGEHAEALK_ServerSave);
			HDCBAOKMFAH_UnitsGoDiva.Add(data);
		}
	}

	// // RVA: 0x19814C8 Offset: 0x19814C8 VA: 0x19814C8
	public JLKEOGLJNOD DPLBHAIKPGL(bool CMEOKJMCEBH = false)
	{
		if(CMEOKJMCEBH)
			return LEIGKLOGCPF;
		return NPFCMHCCDDH;
	}

	// // RVA: 0x19814DC Offset: 0x19814DC VA: 0x19814DC
	public JLKEOGLJNOD JKIJFGGMNAN_GetUnit(int OIPCCBHIKIA, bool CMEOKJMCEBH_IsGoDiva = false)
	{
		return DDMBOKCCLBD_GetUnits(CMEOKJMCEBH_IsGoDiva)[OIPCCBHIKIA];
	}

	// // RVA: 0x198156C Offset: 0x198156C VA: 0x198156C
	public List<JLKEOGLJNOD> DDMBOKCCLBD_GetUnits(bool CMEOKJMCEBH_IsGoDiva = false)
	{
		return CMEOKJMCEBH_IsGoDiva ? HDCBAOKMFAH_UnitsGoDiva : EHGGOAGEGIM_UnitsNormal;
	}
}
