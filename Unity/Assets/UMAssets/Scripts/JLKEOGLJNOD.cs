using System.Collections.Generic;
using XeApp.Game;
using XeApp.Game.Common;

[System.Obsolete("Use JLKEOGLJNOD_TeamInfo", true)]
public class JLKEOGLJNOD { }
public class JLKEOGLJNOD_TeamInfo
{
	private BBHNACPENDM_ServerSaveData LDEGEHAEALK_ServerData; // 0x8
	private CIFHILOJJFC NGHKJOEDLIP_ScoreTeam; // 0xC
	private bool NCCJGHMGJLL_IsUnitGoDiva; // 0x10
	
	public List<FFHPBEPOMAK_DivaInfo> BCJEAJPLGMB_MainDivas { get; private set; } // 0x14 BDPBHHMHLNI CMCEOEKKMLB PBBCDMMDBOH
	public List<FFHPBEPOMAK_DivaInfo> CMOPCCAJAAO_AddDivas { get; private set; } // 0x18 ACKJKHCBAIE EADCJJBAGPK NPNIPFDIBMK
	public PNGOLKLFFLH JOKFNBLEILN_Valkyrie { get; private set; } // 0x1C KAPPIKNNJLJ JEDNOGJBIMN OHFNALDNENG
	public StatusData JLJGCBOHJID_Status { get; private set; } // 0x20 MHGEJIKLJOP CKAOBJJCOFO MKFJBBFNFPD
	public StatusData CMCKNKKCNDK_GoDivaStatus { get; private set; } // 0x24 CLCJNFNMNBH  CNKGOPKANGF CHJGGLFGALP
	public CIFHILOJJFC DJPFJGKGOOF_ScoreTeam { get { return NGHKJOEDLIP_ScoreTeam; } } // JFBNIMDHEJO 0x14760D4
	public string BHKALCOAHHO_Name { get { return NGHKJOEDLIP_ScoreTeam.OPFGFINHFCE_Name; } set { NGHKJOEDLIP_ScoreTeam.OPFGFINHFCE_Name = value; } } // NGMLFAGNJEA 0x14760DC FCOONLGMNCI 0x1476100
	public int CDPKOIDDKIJ { get { return NGHKJOEDLIP_ScoreTeam.GIDKKHFHALL; } } // PFDFNJHFIIJ 0x1476128
	public bool EIGKIHENKNC_HasNoDivaSet { get {
			for(int i = 0; i < NGHKJOEDLIP_ScoreTeam.FDBOPFEOENF_MainDivas.Count; i++)
			{
				if (NGHKJOEDLIP_ScoreTeam.FDBOPFEOENF_MainDivas[i].DIPKCALNIII_Id != 0)
					return false;
			}
			for(int i = 0; i < NGHKJOEDLIP_ScoreTeam.KAKGHFFOAEJ_AddDivas.Count; i++)
			{
				if (NGHKJOEDLIP_ScoreTeam.KAKGHFFOAEJ_AddDivas[i].DIPKCALNIII_Id != 0)
					return false;
			}
			return true;
		} } // FHKHJHHICMD 0x147614C
	// public bool EMBFLMCNCHN { get; } // IJNCPACDJOB 0x1476310
	public int PDJEMLMOEPF_CenterDivaId { get { return NGHKJOEDLIP_ScoreTeam.FDBOPFEOENF_MainDivas[0].DIPKCALNIII_Id; } } // OICEHMGFBOG 0x147654C

	// // RVA: 0x14765F4 Offset: 0x14765F4 VA: 0x14765F4
	public JLKEOGLJNOD_TeamInfo()
	{
		JLJGCBOHJID_Status = new StatusData();
		CMCKNKKCNDK_GoDivaStatus = new StatusData();
	}

	// // RVA: 0x1476688 Offset: 0x1476688 VA: 0x1476688
	public void AADLCEDCNIC(List<GCIJNCFDNON_SceneInfo> OPIBAPEGCLA, AMCGONHBGGF FOOJCAGEODG, int JPIDIENBGKH, int PPKEBOEJAKH)
	{
		if(FOOJCAGEODG.DIPKCALNIII_Id == 0)
		{
			BCJEAJPLGMB_MainDivas.Add(null);
		}
		else
		{
			AMCGONHBGGF PFEPMCNHEMJ = FOOJCAGEODG;
			FFHPBEPOMAK_DivaInfo f = new FFHPBEPOMAK_DivaInfo();
			List<GCIJNCFDNON_SceneInfo> l = new List<GCIJNCFDNON_SceneInfo>();
			l.Add(null);
			l.Add(null);
			GCIJNCFDNON_SceneInfo g = null;
			if(PFEPMCNHEMJ.EBDNICPAFLB_SSlot[0] == 0)
			{
				g = null;
			}
			else if(OPIBAPEGCLA == null)
			{
				MMPBPOIFDAF_Scene.PMKOFEIONEG s = LDEGEHAEALK_ServerData.PNLOINMCCKH_Scene.OPIBAPEGCLA.Find((MMPBPOIFDAF_Scene.PMKOFEIONEG IBDJFHFIIHN) =>
				{
					//0x147B7E4
					return IBDJFHFIIHN.PPFNGGCBJKC_Id == PFEPMCNHEMJ.EBDNICPAFLB_SSlot[0];
				});
				g = new GCIJNCFDNON_SceneInfo();
				g.KHEKNNFCAOI(PFEPMCNHEMJ.EBDNICPAFLB_SSlot[0], s.PDNIFBEGMHC_Mb, s.EMOJHJGHJLN_Sb, s.JPIPENJGGDD_Mlt, s.IELENGDJPHF_Ulk, s.MJBODMOLOBC_Luck, s.LHMOAJAIJCO_New, s.BEBJKJKBOGH_Date, s.DMNIMMGGJJJ_Leaf);
			}
			else
			{
				g = OPIBAPEGCLA.Find((GCIJNCFDNON_SceneInfo AOIKKLBKEBC) =>
				{
					//0x147B86C
					return AOIKKLBKEBC.BCCHOBPJJKE_SceneId == PFEPMCNHEMJ.EBDNICPAFLB_SSlot[0];
				});
			}
			if(PFEPMCNHEMJ.EBDNICPAFLB_SSlot[1] != 0)
			{
				if(OPIBAPEGCLA == null)
				{
					MMPBPOIFDAF_Scene.PMKOFEIONEG s = LDEGEHAEALK_ServerData.PNLOINMCCKH_Scene.OPIBAPEGCLA.Find((MMPBPOIFDAF_Scene.PMKOFEIONEG IBDJFHFIIHN) =>
					{
						//0x147B8E8
						return IBDJFHFIIHN.PPFNGGCBJKC_Id == PFEPMCNHEMJ.EBDNICPAFLB_SSlot[1];
					});
					GCIJNCFDNON_SceneInfo h = new GCIJNCFDNON_SceneInfo();
					l[0] = h;
					h.KHEKNNFCAOI(PFEPMCNHEMJ.EBDNICPAFLB_SSlot[1], s.PDNIFBEGMHC_Mb, s.EMOJHJGHJLN_Sb, s.JPIPENJGGDD_Mlt, s.IELENGDJPHF_Ulk, s.MJBODMOLOBC_Luck, s.LHMOAJAIJCO_New, s.BEBJKJKBOGH_Date, s.DMNIMMGGJJJ_Leaf);
				}
				else
				{
					GCIJNCFDNON_SceneInfo h = OPIBAPEGCLA.Find((GCIJNCFDNON_SceneInfo AOIKKLBKEBC) =>
					{
						//0x147B970
						return AOIKKLBKEBC.BCCHOBPJJKE_SceneId == PFEPMCNHEMJ.EBDNICPAFLB_SSlot[1];
					});
					l[0] = h;
				}
			}
			if (PFEPMCNHEMJ.EBDNICPAFLB_SSlot[2] != 0)
			{
				if (OPIBAPEGCLA == null)
				{
					MMPBPOIFDAF_Scene.PMKOFEIONEG s = LDEGEHAEALK_ServerData.PNLOINMCCKH_Scene.OPIBAPEGCLA.Find((MMPBPOIFDAF_Scene.PMKOFEIONEG IBDJFHFIIHN) =>
					{
						//0x147B9EC
						return IBDJFHFIIHN.PPFNGGCBJKC_Id == PFEPMCNHEMJ.EBDNICPAFLB_SSlot[2];
					});
					GCIJNCFDNON_SceneInfo h = new GCIJNCFDNON_SceneInfo();
					l[1] = h;
					h.KHEKNNFCAOI(PFEPMCNHEMJ.EBDNICPAFLB_SSlot[2], s.PDNIFBEGMHC_Mb, s.EMOJHJGHJLN_Sb, s.JPIPENJGGDD_Mlt, s.IELENGDJPHF_Ulk, s.MJBODMOLOBC_Luck, s.LHMOAJAIJCO_New, s.BEBJKJKBOGH_Date, s.DMNIMMGGJJJ_Leaf);
				}
				else
				{
					GCIJNCFDNON_SceneInfo h = OPIBAPEGCLA.Find((GCIJNCFDNON_SceneInfo AOIKKLBKEBC) =>
					{
						//0x147BA74
						return AOIKKLBKEBC.BCCHOBPJJKE_SceneId == PFEPMCNHEMJ.EBDNICPAFLB_SSlot[2];
					});
					l[1] = h;
				}
			}
			f.KHEKNNFCAOI(FOOJCAGEODG.DIPKCALNIII_Id, LDEGEHAEALK_ServerData.DGCJCAHIAPP_Diva.LGKFMLIOPKL_GetDivaInfo(FOOJCAGEODG.DIPKCALNIII_Id).HEBKEJBDCBH_DivaLevel, JPIDIENBGKH, PPKEBOEJAKH, g, l, true);
			BCJEAJPLGMB_MainDivas.Add(f);
		}
	}

	// // RVA: 0x1477544 Offset: 0x1477544 VA: 0x1477544
	public void GDLBMOFJLII(DKDMLOBCPFC FOGJAIKOFDP, int JPIDIENBGKH, int PPKEBOEJAKH)
	{
		if(FOGJAIKOFDP.DIPKCALNIII_Id == 0)
		{
			CMOPCCAJAAO_AddDivas.Add(null);
		}
		else
		{
			FFHPBEPOMAK_DivaInfo f = new FFHPBEPOMAK_DivaInfo();
			f.KHEKNNFCAOI(FOGJAIKOFDP.DIPKCALNIII_Id, LDEGEHAEALK_ServerData.DGCJCAHIAPP_Diva.LGKFMLIOPKL_GetDivaInfo(FOGJAIKOFDP.DIPKCALNIII_Id).HEBKEJBDCBH_DivaLevel, JPIDIENBGKH, PPKEBOEJAKH, null, null, true);
			CMOPCCAJAAO_AddDivas.Add(f);
		}
	}

	// // RVA: 0x14776E0 Offset: 0x14776E0 VA: 0x14776E0
	public void GFBCLEFGGIK(List<GCIJNCFDNON_SceneInfo> OPIBAPEGCLA)
	{
		if (BCJEAJPLGMB_MainDivas == null)
			BCJEAJPLGMB_MainDivas = new List<FFHPBEPOMAK_DivaInfo>(3);
		BCJEAJPLGMB_MainDivas.Clear();
		for (int i = 0; i < 3; i++)
		{
			AMCGONHBGGF a = NGHKJOEDLIP_ScoreTeam.FDBOPFEOENF_MainDivas[i];
			DEKKMGAFJCG_Diva.MNNLOBDPCCH_DivaInfo divaDb = LDEGEHAEALK_ServerData.DGCJCAHIAPP_Diva.LGKFMLIOPKL_GetDivaInfo(a.DIPKCALNIII_Id);
			AADLCEDCNIC(OPIBAPEGCLA, a, divaDb.BEEAIAAJOHD_CostumeId, divaDb.AFNIOJHODAG_CostumeColorId);
		}
		if (CMOPCCAJAAO_AddDivas == null)
			CMOPCCAJAAO_AddDivas = new List<FFHPBEPOMAK_DivaInfo>();
		CMOPCCAJAAO_AddDivas.Clear();
		for(int i = 0; i < 2; i++)
		{
			DKDMLOBCPFC d = NGHKJOEDLIP_ScoreTeam.KAKGHFFOAEJ_AddDivas[i];
			GDLBMOFJLII(d, d.BEEAIAAJOHD_CosId, d.AFNIOJHODAG_ColId);
		}
	}

	// // RVA: 0x1477AA4 Offset: 0x1477AA4 VA: 0x1477AA4
	public void HDKIBGDDCHB(List<GCIJNCFDNON_SceneInfo> OPIBAPEGCLA)
	{
		if (BCJEAJPLGMB_MainDivas == null)
			BCJEAJPLGMB_MainDivas = new List<FFHPBEPOMAK_DivaInfo>();
		BCJEAJPLGMB_MainDivas.Clear();
		for(int i = 0; i < 3; i++)
		{
			AMCGONHBGGF a = NGHKJOEDLIP_ScoreTeam.FDBOPFEOENF_MainDivas[i];
			AADLCEDCNIC(OPIBAPEGCLA, a, a.BEEAIAAJOHD_CId, a.AFNIOJHODAG_ColId);
		}
		if (CMOPCCAJAAO_AddDivas == null)
			CMOPCCAJAAO_AddDivas = new List<FFHPBEPOMAK_DivaInfo>();
		CMOPCCAJAAO_AddDivas.Clear();
		for (int i = 0; i < 2; i++)
		{
			DKDMLOBCPFC d = NGHKJOEDLIP_ScoreTeam.KAKGHFFOAEJ_AddDivas[i];
			GDLBMOFJLII(d, d.BEEAIAAJOHD_CosId, d.AFNIOJHODAG_ColId);
		}
	}

	// // RVA: 0x1477E3C Offset: 0x1477E3C VA: 0x1477E3C
	public void PJOOMNIEGPP(List<FFHPBEPOMAK_DivaInfo> NBIGLBMHEDC, BBHNACPENDM_ServerSaveData AHEFHIMGIBI)
	{
		LDEGEHAEALK_ServerData = AHEFHIMGIBI;
		NGHKJOEDLIP_ScoreTeam = AHEFHIMGIBI.MLAFAACKKBG_Unit.GCINIJEMHFK(0);
		BCJEAJPLGMB_MainDivas = new List<FFHPBEPOMAK_DivaInfo>(3);
		for(int i = 0; i < 3; i++)
		{
			AMCGONHBGGF a = NGHKJOEDLIP_ScoreTeam.FDBOPFEOENF_MainDivas[i];
			if (a.DIPKCALNIII_Id == 0)
			{
				BCJEAJPLGMB_MainDivas.Add(null);
			}
			else
			{
				BCJEAJPLGMB_MainDivas.Add(NBIGLBMHEDC[a.DIPKCALNIII_Id - 1]);
			}
		}
		CMOPCCAJAAO_AddDivas = new List<FFHPBEPOMAK_DivaInfo>(2);
		for(int i = 0; i < 2; i++)
		{
			DKDMLOBCPFC d = NGHKJOEDLIP_ScoreTeam.KAKGHFFOAEJ_AddDivas[i];
			if(d.DIPKCALNIII_Id == 0)
			{
				CMOPCCAJAAO_AddDivas.Add(null);
			}
			else
			{
				CMOPCCAJAAO_AddDivas.Add(NBIGLBMHEDC[d.DIPKCALNIII_Id - 1]);
			}
		}
		if (NGHKJOEDLIP_ScoreTeam.FODKKJIDDKN_VfId == 0)
			JOKFNBLEILN_Valkyrie = null;
		else
		{
			if (JOKFNBLEILN_Valkyrie == null)
				JOKFNBLEILN_Valkyrie = new PNGOLKLFFLH();
			JOKFNBLEILN_Valkyrie.KHEKNNFCAOI_Init(NGHKJOEDLIP_ScoreTeam.FODKKJIDDKN_VfId, NGHKJOEDLIP_ScoreTeam.GCCNMFHELCB_Form, 0);
		}
		HCDGELDHFHB();
	}

	// // RVA: 0x1478230 Offset: 0x1478230 VA: 0x1478230
	public void KHEKNNFCAOI_Init(int JBKOEGJGKMC, List<GCIJNCFDNON_SceneInfo> OPIBAPEGCLA, BBHNACPENDM_ServerSaveData AHEFHIMGIBI)
	{
		if(AHEFHIMGIBI == null)
		{
			LDEGEHAEALK_ServerData = CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave;
		}
		else
		{
			LDEGEHAEALK_ServerData = AHEFHIMGIBI;
		}
		NGHKJOEDLIP_ScoreTeam = LDEGEHAEALK_ServerData.MLAFAACKKBG_Unit.GCINIJEMHFK(JBKOEGJGKMC);
		if(NGHKJOEDLIP_ScoreTeam == null)
		{
			UnityEngine.Debug.LogError("setting not found!!");
			return;
		}
		if(BCJEAJPLGMB_MainDivas == null)
		{
			BCJEAJPLGMB_MainDivas = new List<FFHPBEPOMAK_DivaInfo>();
		}
		BCJEAJPLGMB_MainDivas.Clear();
		for(int i = 0; i < 3; i++)
		{
			AMCGONHBGGF a = NGHKJOEDLIP_ScoreTeam.FDBOPFEOENF_MainDivas[i];
			if(a.DIPKCALNIII_Id == 0)
			{
				BCJEAJPLGMB_MainDivas.Add(null);
			}
			else
			{
				FFHPBEPOMAK_DivaInfo b = new FFHPBEPOMAK_DivaInfo();
				List<GCIJNCFDNON_SceneInfo> l = new List<GCIJNCFDNON_SceneInfo>();
				l.Add(null);
				l.Add(null);
				GCIJNCFDNON_SceneInfo g = null;
				if (a.EBDNICPAFLB_SSlot[0] == 0)
				{
					g = null;
				}
				else if(OPIBAPEGCLA == null)
				{
					MMPBPOIFDAF_Scene.PMKOFEIONEG m = LDEGEHAEALK_ServerData.PNLOINMCCKH_Scene.OPIBAPEGCLA.Find((MMPBPOIFDAF_Scene.PMKOFEIONEG IBDJFHFIIHN) =>
					{
						//0x147BAF0
						return IBDJFHFIIHN.PPFNGGCBJKC_Id == a.EBDNICPAFLB_SSlot[0];
					});
					g = new GCIJNCFDNON_SceneInfo();
					g.KHEKNNFCAOI(a.EBDNICPAFLB_SSlot[0], m.PDNIFBEGMHC_Mb, m.EMOJHJGHJLN_Sb, m.JPIPENJGGDD_Mlt, m.IELENGDJPHF_Ulk, m.MJBODMOLOBC_Luck, m.LHMOAJAIJCO_New, m.BEBJKJKBOGH_Date, m.DMNIMMGGJJJ_Leaf);
				}
				else
				{
					g = OPIBAPEGCLA.Find((GCIJNCFDNON_SceneInfo AOIKKLBKEBC) =>
					{
						//0x147BB78
						return AOIKKLBKEBC.BCCHOBPJJKE_SceneId == a.EBDNICPAFLB_SSlot[0];
					});
				}
				if (a.EBDNICPAFLB_SSlot[1] != 0)
				{
					if (OPIBAPEGCLA == null)
					{
						MMPBPOIFDAF_Scene.PMKOFEIONEG m = LDEGEHAEALK_ServerData.PNLOINMCCKH_Scene.OPIBAPEGCLA.Find((MMPBPOIFDAF_Scene.PMKOFEIONEG IBDJFHFIIHN) =>
						{
							//0x147BBF4
							return IBDJFHFIIHN.PPFNGGCBJKC_Id == a.EBDNICPAFLB_SSlot[1];
						});
						GCIJNCFDNON_SceneInfo h = new GCIJNCFDNON_SceneInfo();
						l[0] = h;
						h.KHEKNNFCAOI(a.EBDNICPAFLB_SSlot[1], m.PDNIFBEGMHC_Mb, m.EMOJHJGHJLN_Sb, m.JPIPENJGGDD_Mlt, m.IELENGDJPHF_Ulk, m.MJBODMOLOBC_Luck, m.LHMOAJAIJCO_New, m.BEBJKJKBOGH_Date, m.DMNIMMGGJJJ_Leaf);
					}
					else
					{
						GCIJNCFDNON_SceneInfo h = OPIBAPEGCLA.Find((GCIJNCFDNON_SceneInfo AOIKKLBKEBC) =>
						{
							//0x147BC7C
							return AOIKKLBKEBC.BCCHOBPJJKE_SceneId == a.EBDNICPAFLB_SSlot[1];
						});
						l[0] = h;
					}
				}
				if (a.EBDNICPAFLB_SSlot[2] != 0)
				{
					if (OPIBAPEGCLA == null)
					{
						MMPBPOIFDAF_Scene.PMKOFEIONEG m = LDEGEHAEALK_ServerData.PNLOINMCCKH_Scene.OPIBAPEGCLA.Find((MMPBPOIFDAF_Scene.PMKOFEIONEG IBDJFHFIIHN) =>
						{
							//0x147BCF8
							return IBDJFHFIIHN.PPFNGGCBJKC_Id == a.EBDNICPAFLB_SSlot[2];
						});
						GCIJNCFDNON_SceneInfo h = new GCIJNCFDNON_SceneInfo();
						l[1] = h;
						h.KHEKNNFCAOI(a.EBDNICPAFLB_SSlot[2], m.PDNIFBEGMHC_Mb, m.EMOJHJGHJLN_Sb, m.JPIPENJGGDD_Mlt, m.IELENGDJPHF_Ulk, m.MJBODMOLOBC_Luck, m.LHMOAJAIJCO_New, m.BEBJKJKBOGH_Date, m.DMNIMMGGJJJ_Leaf);
					}
					else
					{
						GCIJNCFDNON_SceneInfo h = OPIBAPEGCLA.Find((GCIJNCFDNON_SceneInfo AOIKKLBKEBC) =>
						{
							//0x147BD80
							return AOIKKLBKEBC.BCCHOBPJJKE_SceneId == a.EBDNICPAFLB_SSlot[2];
						});
						l[1] = h;
					}
				}
				b.KHEKNNFCAOI(a.DIPKCALNIII_Id, LDEGEHAEALK_ServerData.DGCJCAHIAPP_Diva.LGKFMLIOPKL_GetDivaInfo(a.DIPKCALNIII_Id).HEBKEJBDCBH_DivaLevel, a.BEEAIAAJOHD_CId, a.AFNIOJHODAG_ColId, g, l, true);
				BCJEAJPLGMB_MainDivas.Add(b);
			}
		}
		if(CMOPCCAJAAO_AddDivas == null)
			CMOPCCAJAAO_AddDivas = new List<FFHPBEPOMAK_DivaInfo>();
		CMOPCCAJAAO_AddDivas.Clear();
		for(int i = 0; i < 2; i++)
		{
			DKDMLOBCPFC d = NGHKJOEDLIP_ScoreTeam.KAKGHFFOAEJ_AddDivas[i];
			if(d.DIPKCALNIII_Id == 0)
			{
				CMOPCCAJAAO_AddDivas.Add(null);
			}
			else
			{
				FFHPBEPOMAK_DivaInfo f = new FFHPBEPOMAK_DivaInfo();
				f.KHEKNNFCAOI(d.DIPKCALNIII_Id, LDEGEHAEALK_ServerData.DGCJCAHIAPP_Diva.LGKFMLIOPKL_GetDivaInfo(d.DIPKCALNIII_Id).HEBKEJBDCBH_DivaLevel, d.BEEAIAAJOHD_CosId, d.AFNIOJHODAG_ColId, null, null, true);
				CMOPCCAJAAO_AddDivas.Add(f);
			}
		}
		if(NGHKJOEDLIP_ScoreTeam.FODKKJIDDKN_VfId == 0)
		{
			JOKFNBLEILN_Valkyrie = null;
		}
		else
		{
			if (JOKFNBLEILN_Valkyrie == null)
				JOKFNBLEILN_Valkyrie = new PNGOLKLFFLH();
			JOKFNBLEILN_Valkyrie.KHEKNNFCAOI_Init(NGHKJOEDLIP_ScoreTeam.FODKKJIDDKN_VfId, NGHKJOEDLIP_ScoreTeam.GCCNMFHELCB_Form, 0);
		}
		HCDGELDHFHB();
	}

	// // RVA: 0x1479958 Offset: 0x1479958 VA: 0x1479958
	public void MDMJCIAJBKG_LoadGoDivaMainUnit(int CGIGOFKGCII, int JBKOEGJGKMC, List<GCIJNCFDNON_SceneInfo> OPIBAPEGCLA, List<FFHPBEPOMAK_DivaInfo> NBIGLBMHEDC, BBHNACPENDM_ServerSaveData AHEFHIMGIBI)
	{
		NCCJGHMGJLL_IsUnitGoDiva = true;
		if(AHEFHIMGIBI == null)
		{
			AHEFHIMGIBI = CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave;
		}
		LDEGEHAEALK_ServerData = AHEFHIMGIBI;
		NGHKJOEDLIP_ScoreTeam = AHEFHIMGIBI.KMBJGAHCBDI_UnitGoDiva.ALDOJAEAMCJ(CGIGOFKGCII, JBKOEGJGKMC);
		if(NGHKJOEDLIP_ScoreTeam == null)
		{
			UnityEngine.Debug.LogError("setting not found!!");
			return;
		}
		GFBCLEFGGIK(OPIBAPEGCLA);
		if(NGHKJOEDLIP_ScoreTeam.FODKKJIDDKN_VfId == 0)
		{
			JOKFNBLEILN_Valkyrie = null;
		}
		else
		{
			if (JOKFNBLEILN_Valkyrie == null)
				JOKFNBLEILN_Valkyrie = new PNGOLKLFFLH();
			JOKFNBLEILN_Valkyrie.KHEKNNFCAOI_Init(NGHKJOEDLIP_ScoreTeam.FODKKJIDDKN_VfId, NGHKJOEDLIP_ScoreTeam.GCCNMFHELCB_Form);
		}
		HCDGELDHFHB();
	}

	// // RVA: 0x1479B98 Offset: 0x1479B98 VA: 0x1479B98
	public void ALIMIMCBKFH_LoadGoDivaUnit(int CGIGOFKGCII, int JBKOEGJGKMC, List<GCIJNCFDNON_SceneInfo> OPIBAPEGCLA, BBHNACPENDM_ServerSaveData AHEFHIMGIBI)
	{
		NCCJGHMGJLL_IsUnitGoDiva = true;
		if(AHEFHIMGIBI == null)
		{
			AHEFHIMGIBI = CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave;
		}
		LDEGEHAEALK_ServerData = AHEFHIMGIBI;
		NGHKJOEDLIP_ScoreTeam = AHEFHIMGIBI.KMBJGAHCBDI_UnitGoDiva.ALDOJAEAMCJ(CGIGOFKGCII, JBKOEGJGKMC);
		if (NGHKJOEDLIP_ScoreTeam == null)
		{
			UnityEngine.Debug.LogError("setting not found!!");
			return;
		}
		HDKIBGDDCHB(OPIBAPEGCLA);
		if(NGHKJOEDLIP_ScoreTeam.FODKKJIDDKN_VfId == 0)
		{
			JOKFNBLEILN_Valkyrie = null;
		}
		else
		{
			if(JOKFNBLEILN_Valkyrie == null)
				JOKFNBLEILN_Valkyrie = new PNGOLKLFFLH();
			JOKFNBLEILN_Valkyrie.KHEKNNFCAOI_Init(NGHKJOEDLIP_ScoreTeam.FODKKJIDDKN_VfId, NGHKJOEDLIP_ScoreTeam.GCCNMFHELCB_Form, 0);
		}
		HCDGELDHFHB();
	}

	// // RVA: 0x1479DD8 Offset: 0x1479DD8 VA: 0x1479DD8
	public void KMLFHLOBPNH(List<GCIJNCFDNON_SceneInfo> OPIBAPEGCLA)
	{
		if(NGHKJOEDLIP_ScoreTeam.GIDKKHFHALL != 0)
		{
			NGHKJOEDLIP_ScoreTeam.ODDIHGPONFL_Copy(LDEGEHAEALK_ServerData.MLAFAACKKBG_Unit.FJDDNKGHPHN_GetDefault(), false);
			KHEKNNFCAOI_Init(NGHKJOEDLIP_ScoreTeam.GIDKKHFHALL, OPIBAPEGCLA, LDEGEHAEALK_ServerData);
		}
	}

	// // RVA: 0x1479EA8 Offset: 0x1479EA8 VA: 0x1479EA8
	public void MLNLDMABAEA(int AHHJLDLAPAN, List<GCIJNCFDNON_SceneInfo> OPIBAPEGCLA)
	{
		if (NGHKJOEDLIP_ScoreTeam.GIDKKHFHALL != 0)
		{
			NGHKJOEDLIP_ScoreTeam.ODDIHGPONFL_Copy(LDEGEHAEALK_ServerData.KMBJGAHCBDI_UnitGoDiva.IGKLKPIEEEH(AHHJLDLAPAN), false);
			ALIMIMCBKFH_LoadGoDivaUnit(AHHJLDLAPAN, NGHKJOEDLIP_ScoreTeam.GIDKKHFHALL, OPIBAPEGCLA, LDEGEHAEALK_ServerData);
		}
	}

	// // RVA: 0x1479F88 Offset: 0x1479F88 VA: 0x1479F88
	public void GHNBDOLODJK_CopyScore(JLKEOGLJNOD_TeamInfo GPBJHKLFCEP)
	{
		NGHKJOEDLIP_ScoreTeam.ODDIHGPONFL_Copy(GPBJHKLFCEP.NGHKJOEDLIP_ScoreTeam, false);
	}

	// // RVA: 0x1479FD4 Offset: 0x1479FD4 VA: 0x1479FD4
	public void BBKOIKGPLFM_CopyGoDivaScore(JLKEOGLJNOD_TeamInfo GPBJHKLFCEP)
	{
		NGHKJOEDLIP_ScoreTeam.ODDIHGPONFL_Copy(GPBJHKLFCEP.NGHKJOEDLIP_ScoreTeam, false);
	}

	// // RVA: 0x147A020 Offset: 0x147A020 VA: 0x147A020
	public void LDPCJAKOKHB(int GPPEFLKGGGJ_ValkyrieId, int GCCNMFHELCB_Form = -1)
	{
		if (GPPEFLKGGGJ_ValkyrieId == 0)
		{
			JOKFNBLEILN_Valkyrie = null;
			if (NGHKJOEDLIP_ScoreTeam != null)
			{
				NGHKJOEDLIP_ScoreTeam.FODKKJIDDKN_VfId = 0;
				return;
			}
		}
		if (GCCNMFHELCB_Form < 0)
			GCCNMFHELCB_Form = NGHKJOEDLIP_ScoreTeam.GCCNMFHELCB_Form;
		else
			NGHKJOEDLIP_ScoreTeam.GCCNMFHELCB_Form = GCCNMFHELCB_Form;
		NGHKJOEDLIP_ScoreTeam.FODKKJIDDKN_VfId = GPPEFLKGGGJ_ValkyrieId;
		if(JOKFNBLEILN_Valkyrie == null)
		{
			JOKFNBLEILN_Valkyrie = new PNGOLKLFFLH();
		}
		JOKFNBLEILN_Valkyrie.KHEKNNFCAOI_Init(GPPEFLKGGGJ_ValkyrieId, GCCNMFHELCB_Form, 0);
	}

	// // RVA: 0x147A148 Offset: 0x147A148 VA: 0x147A148
	// public void ACGHDBEELGF(int GCCNMFHELCB) { }

	// // RVA: 0x147821C Offset: 0x147821C VA: 0x147821C
	public void HCDGELDHFHB()
	{
		if (NCCJGHMGJLL_IsUnitGoDiva)
			ELHBGKLLOIO();
		else
			GLGPDEHOLIJ();
	}

	// // RVA: 0x147A7C0 Offset: 0x147A7C0 VA: 0x147A7C0
	private void GLGPDEHOLIJ()
	{
		JLJGCBOHJID_Status.Clear();
		if (BCJEAJPLGMB_MainDivas != null)
		{
			for (int i = 0; i < BCJEAJPLGMB_MainDivas.Count; i++)
			{
				AMCGONHBGGF a = NGHKJOEDLIP_ScoreTeam.FDBOPFEOENF_MainDivas[i];
				FFHPBEPOMAK_DivaInfo f = BCJEAJPLGMB_MainDivas[i];
				if(f == null)
				{
					a.DIPKCALNIII_Id = 0;
					a.BEEAIAAJOHD_CId = 0;
					a.AFNIOJHODAG_ColId = 0;
					a.EBDNICPAFLB_SSlot[0] = 0;
					a.EBDNICPAFLB_SSlot[1] = 0;
					a.EBDNICPAFLB_SSlot[2] = 0;
				}
				else
				{
					f.HCDGELDHFHB();
					JLJGCBOHJID_Status.Add(f.CMCKNKKCNDK_EquippedStatus);
					a.DIPKCALNIII_Id = f.AHHJLDLAPAN_DivaId;
					a.BEEAIAAJOHD_CId = f.JPIDIENBGKH_CostumeId;
					a.AFNIOJHODAG_ColId = f.EKFONBFDAAP_ColorId;
					a.EBDNICPAFLB_SSlot[0] = f.FGFIBOBAPIA_SceneId;
					a.EBDNICPAFLB_SSlot[1] = f.DJICAKGOGFO_SubSceneIds[0];
					a.EBDNICPAFLB_SSlot[2] = f.DJICAKGOGFO_SubSceneIds[1];
				}
			}
		}
		if (CMOPCCAJAAO_AddDivas != null)
		{
			for (int i = 0; i < CMOPCCAJAAO_AddDivas.Count; i++)
			{
				DKDMLOBCPFC d = NGHKJOEDLIP_ScoreTeam.KAKGHFFOAEJ_AddDivas[i];
				FFHPBEPOMAK_DivaInfo f = CMOPCCAJAAO_AddDivas[i];
				if (f == null)
				{
					d.DIPKCALNIII_Id = 0;
					d.BEEAIAAJOHD_CosId = 0;
					d.AFNIOJHODAG_ColId = 0;
				}
				else
				{
					d.DIPKCALNIII_Id = f.AHHJLDLAPAN_DivaId;
					d.BEEAIAAJOHD_CosId = f.JPIDIENBGKH_CostumeId;
					d.AFNIOJHODAG_ColId = f.EKFONBFDAAP_ColorId;
				}
			}
		}
		CMCKNKKCNDK_GoDivaStatus.Copy(JLJGCBOHJID_Status);
	}

	// // RVA: 0x147A1A4 Offset: 0x147A1A4 VA: 0x147A1A4
	private void ELHBGKLLOIO()
	{
		JLJGCBOHJID_Status.Clear();
		if (BCJEAJPLGMB_MainDivas != null)
		{
			for (int i = 0; i < BCJEAJPLGMB_MainDivas.Count; i++)
			{
				AMCGONHBGGF a = NGHKJOEDLIP_ScoreTeam.FDBOPFEOENF_MainDivas[i];
				FFHPBEPOMAK_DivaInfo f = BCJEAJPLGMB_MainDivas[i];
				if (f == null)
				{
					a.DIPKCALNIII_Id = 0;
					a.BEEAIAAJOHD_CId = 0;
					a.AFNIOJHODAG_ColId = 0;
					a.EBDNICPAFLB_SSlot[0] = 0;
					a.EBDNICPAFLB_SSlot[1] = 0;
					a.EBDNICPAFLB_SSlot[2] = 0;
				}
				else
				{
					if (i == 0)
						f.HCDGELDHFHB();
					else
						f.ELHBGKLLOIO();
					JLJGCBOHJID_Status.Add(f.CMCKNKKCNDK_EquippedStatus);
					a.DIPKCALNIII_Id = f.AHHJLDLAPAN_DivaId;
					a.BEEAIAAJOHD_CId = f.JPIDIENBGKH_CostumeId;
					a.AFNIOJHODAG_ColId = f.EKFONBFDAAP_ColorId;
					a.EBDNICPAFLB_SSlot[0] = f.FGFIBOBAPIA_SceneId;
					a.EBDNICPAFLB_SSlot[1] = f.DJICAKGOGFO_SubSceneIds[0];
					a.EBDNICPAFLB_SSlot[2] = f.DJICAKGOGFO_SubSceneIds[1];
				}
			}
		}
		if(CMOPCCAJAAO_AddDivas != null)
		{
			for(int i = 0; i < CMOPCCAJAAO_AddDivas.Count; i++)
			{
				DKDMLOBCPFC d = NGHKJOEDLIP_ScoreTeam.KAKGHFFOAEJ_AddDivas[i];
				FFHPBEPOMAK_DivaInfo f = CMOPCCAJAAO_AddDivas[i];
				if(f == null)
				{
					d.DIPKCALNIII_Id = 0;
					d.BEEAIAAJOHD_CosId = 0;
					d.AFNIOJHODAG_ColId = 0;
				}
				else
				{
					d.DIPKCALNIII_Id = f.AHHJLDLAPAN_DivaId;
					d.BEEAIAAJOHD_CosId = f.JPIDIENBGKH_CostumeId;
					d.AFNIOJHODAG_ColId = f.EKFONBFDAAP_ColorId;
				}
			}
			CMCKNKKCNDK_GoDivaStatus.Copy(JLJGCBOHJID_Status);
		}
	}

	// // RVA: 0x147ADCC Offset: 0x147ADCC VA: 0x147ADCC
	public DEKKMGAFJCG_Diva.IFHCNLAODKG JOGOEIEKIHP_GetDivaInfoWithScene(int BCCHOBPJJKE_SceneId)
	{
		if(BCCHOBPJJKE_SceneId != 0)
		{
			for (int i = 0; i < BCJEAJPLGMB_MainDivas.Count; i++)
			{
				FFHPBEPOMAK_DivaInfo divaInfo = BCJEAJPLGMB_MainDivas[i];
				if(divaInfo != null)
				{
					if(divaInfo.FGFIBOBAPIA_SceneId == BCCHOBPJJKE_SceneId)
					{
						DEKKMGAFJCG_Diva.IFHCNLAODKG res = new DEKKMGAFJCG_Diva.IFHCNLAODKG();
						res.LGBDBBFEPGL_SceneSlotIdx = 0;
						res.AHHJLDLAPAN_DivaId = divaInfo.AHHJLDLAPAN_DivaId;
						res.BCCHOBPJJKE_SceneId = divaInfo.FGFIBOBAPIA_SceneId;
						res.NGEADPGADLI_DivaSlot = i;
						return res;
					}
					for(int j = 0; j < divaInfo.DJICAKGOGFO_SubSceneIds.Count; j++)
					{
						if(divaInfo.DJICAKGOGFO_SubSceneIds[j] == BCCHOBPJJKE_SceneId)
						{
							DEKKMGAFJCG_Diva.IFHCNLAODKG res = new DEKKMGAFJCG_Diva.IFHCNLAODKG();
							res.LGBDBBFEPGL_SceneSlotIdx = j + 1;
							res.AHHJLDLAPAN_DivaId = divaInfo.AHHJLDLAPAN_DivaId;
							res.BCCHOBPJJKE_SceneId = divaInfo.FGFIBOBAPIA_SceneId;
							res.NGEADPGADLI_DivaSlot = i;
							return res;
						}
					}
				}
			}
		}
		return null;
	}

	// // RVA: 0x147B23C Offset: 0x147B23C VA: 0x147B23C
	public void FLFBBPLPNMO(GCIJNCFDNON_SceneInfo PNLOINMCCKH, int FGLPICCAPEH, int NGEADPGADLI)
	{
		bool b6_isUsed = false;
		int l40_divaIdx = 0;
		int l38_sceneIdx = 0;
		for(int i = 0; i < BCJEAJPLGMB_MainDivas.Count; i++)
		{
			if(BCJEAJPLGMB_MainDivas[i].FGFIBOBAPIA_SceneId == PNLOINMCCKH.BCCHOBPJJKE_SceneId)
			{
				l38_sceneIdx = 0;
				b6_isUsed = true;
				l40_divaIdx = i;
			}
			else
			{
				for(int j = 0; j < BCJEAJPLGMB_MainDivas[i].DJICAKGOGFO_SubSceneIds.Count; j++)
				{
					if(BCJEAJPLGMB_MainDivas[i].DJICAKGOGFO_SubSceneIds[j] == PNLOINMCCKH.BCCHOBPJJKE_SceneId)
					{
						b6_isUsed = true;
						l40_divaIdx = i;
						l38_sceneIdx = j + 1;
						break;
					}
				}
			}
		}
		//LAB_0147b4a4
		int i1;
		if(FGLPICCAPEH == 0)
		{
			i1 = BCJEAJPLGMB_MainDivas[NGEADPGADLI].FGFIBOBAPIA_SceneId;
			BCJEAJPLGMB_MainDivas[NGEADPGADLI].ODFBCANBLIJ(PNLOINMCCKH);
		}
		else
		{
			i1 = BCJEAJPLGMB_MainDivas[NGEADPGADLI].DJICAKGOGFO_SubSceneIds[FGLPICCAPEH - 1];
			BCJEAJPLGMB_MainDivas[NGEADPGADLI].GOEDGNGDMCN(PNLOINMCCKH, FGLPICCAPEH - 1);
		}
		if(b6_isUsed)
		{
			if(i1 > 0)
			{
				if(BCJEAJPLGMB_MainDivas[l40_divaIdx] != null)
				{
					if(l38_sceneIdx == 0)
					{
						BCJEAJPLGMB_MainDivas[l40_divaIdx].ODFBCANBLIJ(GameManager.Instance.ViewPlayerData.OPIBAPEGCLA_Scenes[i1 - 1]);
					}
					else
					{
						BCJEAJPLGMB_MainDivas[l40_divaIdx].GOEDGNGDMCN(GameManager.Instance.ViewPlayerData.OPIBAPEGCLA_Scenes[i1 - 1], l38_sceneIdx - 1);
					}
				}
			}
			else
			{
				if(l38_sceneIdx == 0)
				{
					BCJEAJPLGMB_MainDivas[l40_divaIdx].CJBBDBGDFKJ(null, true);
				}
				else
				{
					BCJEAJPLGMB_MainDivas[l40_divaIdx].GIGDKIHBDHB(null, l38_sceneIdx - 1, true);
				}
			}
		}
	}
}
