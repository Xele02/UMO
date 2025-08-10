
using System.Collections.Generic;
using XeApp.Game.Common;
using XeApp.Game.Menu;
using XeSys;

public class IHKJLKLAMMC
{
	private int FBGGEFFJJHB; // 0x8
	private long BBEGLBMOBOF; // 0x10
	private List<OHKECKAPJJL> NBONAPKIILC_Buttons; // 0x18
	private NNJFKLBPBNK_SecureString MHPAELHGOHF = new NNJFKLBPBNK_SecureString(); // 0x1C

	private string KEFGPJBKAOD { get { return MHPAELHGOHF.DNJEJEANJGL_Value; } set { MHPAELHGOHF.DNJEJEANJGL_Value = value; } } //0x11FCAA8 MKJJKNIMMBC 0x11FCAD4 NACMHHKKBCJ

	// RVA: 0x11FCB08 Offset: 0x11FCB08 VA: 0x11FCB08
	public IHKJLKLAMMC()
    {
        FBGGEFFJJHB = LPDNKHAIOLH.CEIBAFOCNCA();
        BBEGLBMOBOF = FBGGEFFJJHB;
        KEFGPJBKAOD = "";
    }

	// // RVA: 0x11FCBE0 Offset: 0x11FCBE0 VA: 0x11FCBE0
	public int HCGPNCJNKED(long JHNMKKNEENE)
	{
		KNKDBNFMAKF_EventSp ev = JEPBIIJDGEF_EventInfo.HHCJCDFCLOB.OEGDCBLNNFF(OHCAABOMEOF.KGOGMKMBCPP_EventType.ENPJADLIFAB_EventSp, KGCNCBOKCBA.GNENJEHKMHD_EventStatus.BCKENOKGLIJ_9_ResultRewardreceived) as KNKDBNFMAKF_EventSp;
		long l1, l2;
		return ev.NJIKJJNLAPL(JHNMKKNEENE, out l1, out l2);
	}

	// // RVA: 0x11FCE00 Offset: 0x11FCE00 VA: 0x11FCE00
	public string AFMHNPCDAFI(long JHNMKKNEENE)
	{
		if(KEFGPJBKAOD == "")
		{
            IKDICBBFBMI_EventBase ev = JEPBIIJDGEF_EventInfo.HHCJCDFCLOB.OEGDCBLNNFF(OHCAABOMEOF.KGOGMKMBCPP_EventType.ENPJADLIFAB_EventSp, KGCNCBOKCBA.GNENJEHKMHD_EventStatus.BCKENOKGLIJ_9_ResultRewardreceived);
			OEIJEFBBJBD_EventSp dbEv = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.LBDOLHGDIEB_GetDbSection(ev.JOPOPMLFINI_QuestId) as OEIJEFBBJBD_EventSp;
			OEIJEFBBJBD_EventSp.AOOLGJIFOEI d = dbEv.FDGNDLBDJFH.Find((OEIJEFBBJBD_EventSp.AOOLGJIFOEI JPAEDJJFFOI) =>
			{
				//0x1202860
				return JHNMKKNEENE >= JPAEDJJFFOI.PDBPFJJCADD_OpenAt && JPAEDJJFFOI.FDBNFFNFOND_CloseAt >= JHNMKKNEENE;
			});
			KEFGPJBKAOD = ev.PGIIDPEGGPI_EventId.ToString();
			if(d != null && d.OENPCNBFPDA_BgId > 0)
			{
				KEFGPJBKAOD = string.Format("{0}{1:D2}", ev.PGIIDPEGGPI_EventId, d.OENPCNBFPDA_BgId);
			}
        }
		return KEFGPJBKAOD;
	}

	// // RVA: 0x11FD1E0 Offset: 0x11FD1E0 VA: 0x11FD1E0
	public OHKECKAPJJL EJAPIOEOPNF_GetButtonInfo(int OIPCCBHIKIA)
	{
		return NBONAPKIILC_Buttons[OIPCCBHIKIA];
	}

	// // RVA: 0x11FD260 Offset: 0x11FD260 VA: 0x11FD260
	public OHKECKAPJJL IMOGBABIDFF(OHKECKAPJJL.GPNHNIGPGCL HEFHKNNMMDD)
	{
		return NBONAPKIILC_Buttons.Find((OHKECKAPJJL GHPLINIACBB) =>
		{
			//0x12022D0
			return GHPLINIACBB.PNDEAHGLJIC_BtnType == HEFHKNNMMDD;
		});
	}

	// // RVA: 0x11FD360 Offset: 0x11FD360 VA: 0x11FD360
	public int MMPDGHKFNLE_GetButtonsCount()
	{
		return NBONAPKIILC_Buttons.Count;
	}

	// // RVA: 0x11FD3D8 Offset: 0x11FD3D8 VA: 0x11FD3D8
	public void KHEKNNFCAOI(List<LOBDIAABMKG> MKHCLKMFBLJ)
	{
        KNKDBNFMAKF_EventSp ev = JEPBIIJDGEF_EventInfo.HHCJCDFCLOB.OEGDCBLNNFF(OHCAABOMEOF.KGOGMKMBCPP_EventType.ENPJADLIFAB_EventSp, KGCNCBOKCBA.GNENJEHKMHD_EventStatus.BCKENOKGLIJ_9_ResultRewardreceived) as KNKDBNFMAKF_EventSp;
        NBONAPKIILC_Buttons = new List<OHKECKAPJJL>();
		OEIJEFBBJBD_EventSp dbEv = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.LBDOLHGDIEB_GetDbSection(ev.JOPOPMLFINI_QuestId) as OEIJEFBBJBD_EventSp;
		long t = NKGJPJPHLIF.HHCJCDFCLOB.IBLPICFDGOF_ServerRequester.FJDBNGEPKHL.KMEFBNBFJHI_GetServerTime();
		List<OEIJEFBBJBD_EventSp.AODDNOGBFLP> l = dbEv.DAAHEOIEJFL(t);
		for(int i = 0; i < l.Count; i++)
		{
			if(l[i].PLALNIIBLOF_Enabled == 2)
			{
				long l1 = l[i].PDBPFJJCADD_OpenAt;
				if(l1 == 0)
					l1 = dbEv.NGHKJOEDLIP.BONDDBOFBND_Start;
				long l2 = l[i].FDBNFFNFOND_CloseAt;
				if(l2 == 0)
					l2 = dbEv.NGHKJOEDLIP.HPNOGLIFJOP_End1;
				OHKECKAPJJL KECECJPFEPM = new OHKECKAPJJL();
				KECECJPFEPM.OBKGEDCKHHE(l[i].MGLJCOMOGLO_BtnId);
				KECECJPFEPM.PPFNGGCBJKC_Id = l[i].PPFNGGCBJKC_Id;
				KECECJPFEPM.MGLJCOMOGLO_BtnId = l[i].MGLJCOMOGLO_BtnId;
				KECECJPFEPM.GNOFNIOLPPC_ImgId = l[i].GNOFNIOLPPC_ImgId;
				KECECJPFEPM.BOJCOPAALNC_EventId = l[i].BOJCOPAALNC_SkdId;
				KECECJPFEPM.PNDEAHGLJIC_BtnType = (OHKECKAPJJL.GPNHNIGPGCL)l[i].PNDEAHGLJIC_BtnType;
				KECECJPFEPM.LPDLBACJKIB_TransId = l[i].LPDLBACJKIB_TransId;
				KECECJPFEPM.PDBPFJJCADD_Start = l1;
				KECECJPFEPM.FDBNFFNFOND_End = l2;
				KECECJPFEPM.LHMOAJAIJCO_IsNew = ev.IHPAMMBNOPC(l[i].PPFNGGCBJKC_Id);
				switch(l[i].PNDEAHGLJIC_BtnType)
				{
					case 1:
					case 9:
					case 12:
						NBKMNMGEELE(KECECJPFEPM, dbEv, MKHCLKMFBLJ, t);
						KECECJPFEPM.FICHDKOOOOB_Enabled = KECECJPFEPM.OAAKAAFFFLE == OHKECKAPJJL.ONKLMFNGCHJ.LAOEGNLOJHC_2 && l[i].PLALNIIBLOF_Enabled == 2;
						break;
					case 2:
						{
							long v1, v2, v3, v4;
							ev.NEMGJHBEJCP(ev.MEDEJHKNAFG_GetCurrentMissionGroup(t), t, out v1, out v2, out v3, out v4);
							if(t < v1)
							{
								KECECJPFEPM.OAAKAAFFFLE = OHKECKAPJJL.ONKLMFNGCHJ.NHICGIPPMBD_1_NotStarted;
								KECECJPFEPM.PDBPFJJCADD_Start = v1;
								KECECJPFEPM.FICHDKOOOOB_Enabled = false;
							}
							else
							{
								KECECJPFEPM.OAAKAAFFFLE = OHKECKAPJJL.ONKLMFNGCHJ.LAOEGNLOJHC_2;
								KECECJPFEPM.MMJHAMFEHCH = OHKECKAPJJL.NBADGBJMBMM.HIDGJCIFFNJ_0;
								if(v2 >= t)
								{
									KECECJPFEPM.PDBPFJJCADD_Start = v1;
									KECECJPFEPM.FDBNFFNFOND_End = v2;
									KECECJPFEPM.MMJHAMFEHCH = OHKECKAPJJL.NBADGBJMBMM.HIDGJCIFFNJ_0;
								}
								if(t >= v3)
								{
									KECECJPFEPM.PDBPFJJCADD_Start = v3;
									KECECJPFEPM.FDBNFFNFOND_End = v4;
									KECECJPFEPM.MMJHAMFEHCH = OHKECKAPJJL.NBADGBJMBMM.IIBKMHIDNPM_1;
								}
								//LAB_011ffcd8 ivar29
								KECECJPFEPM.GGHDEDJFFOM = ev.PGIIDPEGGPI_EventId;
								//LAB_011ffce0
								KECECJPFEPM.FICHDKOOOOB_Enabled = l[i].PLALNIIBLOF_Enabled == 2;
							}
							break;
						}
					case 3:
						{
							KECECJPFEPM.OAAKAAFFFLE = OHKECKAPJJL.ONKLMFNGCHJ.OLCLJKOKJCD_5_Ended;
							OEIJEFBBJBD_EventSp.LJAJKDHLGAJ d = dbEv.CDPGPHGBNOA.Find((OEIJEFBBJBD_EventSp.LJAJKDHLGAJ GHPLINIACBB) =>
							{
								//0x1202314
								return GHPLINIACBB.PPFNGGCBJKC_Id == KECECJPFEPM.BOJCOPAALNC_EventId;
							});
							if(d !=null)
							{
								KECECJPFEPM.LCCDKCPBJAK = d.OPKCNBFBBKP_BannerId;
								KECECJPFEPM.OAAKAAFFFLE = OHKECKAPJJL.ONKLMFNGCHJ.NHICGIPPMBD_1_NotStarted;
								KECECJPFEPM.PDBPFJJCADD_Start = d.PDBPFJJCADD_OpenAt;
								//LAB_011ff200 i12 = d.FDBNFFNFOND_CloseAt
								KECECJPFEPM.FDBNFFNFOND_End = d.FDBNFFNFOND_CloseAt; // ivar30
								if(t >= d.PDBPFJJCADD_OpenAt && t < d.FDBNFFNFOND_CloseAt)
								{
									KECECJPFEPM.OAAKAAFFFLE = OHKECKAPJJL.ONKLMFNGCHJ.LAOEGNLOJHC_2;
									KECECJPFEPM.FICHDKOOOOB_Enabled = l[i].PLALNIIBLOF_Enabled == 2;
								}
								else if(d.FDBNFFNFOND_CloseAt < t)
								{
									KECECJPFEPM.OAAKAAFFFLE = OHKECKAPJJL.ONKLMFNGCHJ.OLCLJKOKJCD_5_Ended;
									KECECJPFEPM.FICHDKOOOOB_Enabled = false;
								}
							}
							else
							{
								KECECJPFEPM.FICHDKOOOOB_Enabled = false;
							}
						}
						break;
					case 4:
						KECECJPFEPM.OAAKAAFFFLE = OHKECKAPJJL.ONKLMFNGCHJ.LAOEGNLOJHC_2;
						JLAMIHICOLK(KECECJPFEPM, dbEv, t);
						// LAB_011ff81c bv32 = iv18
						KECECJPFEPM.FICHDKOOOOB_Enabled = (KECECJPFEPM.IJIDIJBPGNB == OHKECKAPJJL.OHKBMOEIPEP.FELOJMIJMDD_3 || KECECJPFEPM.IJIDIJBPGNB == OHKECKAPJJL.OHKBMOEIPEP.IPPOEPJEDPP_1 ) && l[i].PLALNIIBLOF_Enabled == 2;
						break;
					case 5:
						{
							KECECJPFEPM.OAAKAAFFFLE = OHKECKAPJJL.ONKLMFNGCHJ.NHICGIPPMBD_1_NotStarted;
							OEIJEFBBJBD_EventSp.NJJEAKMBGPN d = dbEv.EOKILLGMGDL.Find((OEIJEFBBJBD_EventSp.NJJEAKMBGPN GHPLINIACBB) =>
							{
								//0x120236C
								return GHPLINIACBB.PPFNGGCBJKC_Id == KECECJPFEPM.BOJCOPAALNC_EventId && GHPLINIACBB.PLALNIIBLOF_Enabled == 2;
							});
							if(d != null)
							{
                                CHHECNJBMLA_EventBoxGacha ev2 = JEPBIIJDGEF_EventInfo.HHCJCDFCLOB.OIKOHACJPCB_GetEventById(d.BDEOMEBFDFF_GachaId) as CHHECNJBMLA_EventBoxGacha;
								if(ev2 != null)
								{
									IMDBGDNPLJA_EventBoxGacha dbEv2 = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.LBDOLHGDIEB_GetDbSection(ev2.JOPOPMLFINI_QuestId) as IMDBGDNPLJA_EventBoxGacha;
									KECECJPFEPM.CDPAEHCPPAM = false;
									KECECJPFEPM.GGHDEDJFFOM = d.BDEOMEBFDFF_GachaId;
									KECECJPFEPM.PDBPFJJCADD_Start = dbEv2.NGHKJOEDLIP.FCNKIKOOFKE;
									KECECJPFEPM.FDBNFFNFOND_End = ev2.DPJCPDKALGI_RankingEnd;
									if(t >= dbEv2.NGHKJOEDLIP.FCNKIKOOFKE)
									{
										KECECJPFEPM.OAAKAAFFFLE = OHKECKAPJJL.ONKLMFNGCHJ.LAOEGNLOJHC_2;
										KECECJPFEPM.CDPAEHCPPAM = true;
									}
									if(t < ev2.LJOHLEGGGMC_RewardEnd)
									{
										KECECJPFEPM.FICHDKOOOOB_Enabled = l[i].PLALNIIBLOF_Enabled == 2;
										break;
									}
									//o27 = KECECJPFEPM
									//b36 = true;
									//LAB_011ff2d8
									KECECJPFEPM.OAAKAAFFFLE = OHKECKAPJJL.ONKLMFNGCHJ.OLCLJKOKJCD_5_Ended;
									KECECJPFEPM.FICHDKOOOOB_Enabled = l[i].PLALNIIBLOF_Enabled == 2;
								}
								else
								{
									KECECJPFEPM.FICHDKOOOOB_Enabled = false;
								}
                            }
							else
							{
								KECECJPFEPM.FICHDKOOOOB_Enabled = false;
							}
							break;
						}
					case 6:
					case 7:
						{
							OEIJEFBBJBD_EventSp.PHIMHBPOMAD d = dbEv.ALGFDOBECLI.Find((OEIJEFBBJBD_EventSp.PHIMHBPOMAD GHPLINIACBB) =>
							{
								//0x12023D4
								return GHPLINIACBB.PPFNGGCBJKC_Id == KECECJPFEPM.BOJCOPAALNC_EventId;
							});
							if(d != null)
							{
								KECECJPFEPM.OAAKAAFFFLE = OHKECKAPJJL.ONKLMFNGCHJ.NHICGIPPMBD_1_NotStarted;
								KECECJPFEPM.PDBPFJJCADD_Start = d.PDBPFJJCADD_OpenAt;
								KECECJPFEPM.FDBNFFNFOND_End = d.FDBNFFNFOND_CloseAt;
                                IKDICBBFBMI_EventBase ev2 = JEPBIIJDGEF_EventInfo.HHCJCDFCLOB.OIKOHACJPCB_GetEventById(d.DNJLJMKKDNA_EventId);
								if(ev2 != null)
								{
									ev.HCDGELDHFHB_UpdateStatus(t);
									if(t >= ev2.GLIMIGNNGGB_RankingStart)
									{
										KECECJPFEPM.OAAKAAFFFLE = OHKECKAPJJL.ONKLMFNGCHJ.LAOEGNLOJHC_2;
									}
									if(t >= ev2.JDDFILGNGFH_RewardStart)
									{
										KECECJPFEPM.OAAKAAFFFLE = OHKECKAPJJL.ONKLMFNGCHJ.FKHAJADPBJK_4_Epilogue;
									}
									if(t >= ev2.LJOHLEGGGMC_RewardEnd)
									{
										KECECJPFEPM.OAAKAAFFFLE = OHKECKAPJJL.ONKLMFNGCHJ.OLCLJKOKJCD_5_Ended;
									}
									if(ev2.NGOFCFJHOMI_Status == KGCNCBOKCBA.GNENJEHKMHD_EventStatus.EMAMLLFAOJI_Counting_6)
									{
										KECECJPFEPM.OAAKAAFFFLE = OHKECKAPJJL.ONKLMFNGCHJ.EMAMLLFAOJI_3_Counting;
									}
									if(ev2.NGOFCFJHOMI_Status < KGCNCBOKCBA.GNENJEHKMHD_EventStatus.EMAMLLFAOJI_Counting_6)
									{
										KECECJPFEPM.FDBNFFNFOND_End = ev2.DPJCPDKALGI_RankingEnd;
									}
									else
									{
										if(l2 >= ev2.LJOHLEGGGMC_RewardEnd)
										{
											KECECJPFEPM.FDBNFFNFOND_End = ev2.LJOHLEGGGMC_RewardEnd;
										}
										else
										{
											KECECJPFEPM.FDBNFFNFOND_End = l2;
										}
									}
									KECECJPFEPM.GGHDEDJFFOM = ev2.PGIIDPEGGPI_EventId;
									//i21 = 0;
									if(t >= KECECJPFEPM.PDBPFJJCADD_Start && t < ev2.LJOHLEGGGMC_RewardEnd)
									{
										KECECJPFEPM.FICHDKOOOOB_Enabled = l[i].PLALNIIBLOF_Enabled == 2;
									}
									//LAB_011ff81c
									else
									{
										KECECJPFEPM.FICHDKOOOOB_Enabled = false;
									}
								}
								else
								{
									KECECJPFEPM.OAAKAAFFFLE = OHKECKAPJJL.ONKLMFNGCHJ.OLCLJKOKJCD_5_Ended;
									d = dbEv.ALGFDOBECLI.Find((OEIJEFBBJBD_EventSp.PHIMHBPOMAD JPAEDJJFFOI) =>
									{
										//0x12025E4
										return JPAEDJJFFOI.PLALNIIBLOF_Enabled == 2 && JPAEDJJFFOI.DNJLJMKKDNA_EventId == d.DNJLJMKKDNA_EventId;
									});
									if(d == null || t >= d.PDBPFJJCADD_OpenAt)
									{
										KECECJPFEPM.FICHDKOOOOB_Enabled = false;
									}
									//b37 = 0;
									//i21 = 1;
									//LAB_011ff2e0
									KECECJPFEPM.FICHDKOOOOB_Enabled = false;
									KECECJPFEPM.OAAKAAFFFLE = OHKECKAPJJL.ONKLMFNGCHJ.NHICGIPPMBD_1_NotStarted;
								}
                            }
							else
							{
								KECECJPFEPM.FICHDKOOOOB_Enabled = false;
							}
						}
						break;
					case 8:
						{
							KECECJPFEPM.OAAKAAFFFLE = OHKECKAPJJL.ONKLMFNGCHJ.NHICGIPPMBD_1_NotStarted;
							if(t >= l1)
							{
								KECECJPFEPM.OAAKAAFFFLE = OHKECKAPJJL.ONKLMFNGCHJ.LAOEGNLOJHC_2;
							}
							if(t >= l2)
							{
								KECECJPFEPM.OAAKAAFFFLE = OHKECKAPJJL.ONKLMFNGCHJ.OLCLJKOKJCD_5_Ended;
							}
							KECECJPFEPM.GGHDEDJFFOM = 1;
							OEIJEFBBJBD_EventSp.MFEJBIMLPGI d = dbEv.JIEIOFMJEBI.Find((OEIJEFBBJBD_EventSp.MFEJBIMLPGI GHPLINIACBB) =>
							{
								//0x120242C
								return GHPLINIACBB.PPFNGGCBJKC_Id == KECECJPFEPM.BOJCOPAALNC_EventId;
							});
							if(d.PLALNIIBLOF_Enabled == 2)
							{
								if(t >= d.PDBPFJJCADD_OpenAt)
								{
									KECECJPFEPM.GGHDEDJFFOM = d.KDGJBBFKLGI_Chapter;
								}
								KECECJPFEPM.FICHDKOOOOB_Enabled = l2 >= t && t >= l1 && l[i].PLALNIIBLOF_Enabled == 2;
							}
						}
						break;
					case 10:
						{
							KECECJPFEPM.OAAKAAFFFLE = OHKECKAPJJL.ONKLMFNGCHJ.OLCLJKOKJCD_5_Ended;
							OEIJEFBBJBD_EventSp.LFKNBOOKCCG d = dbEv.GMJFGPNMMBD.Find((OEIJEFBBJBD_EventSp.LFKNBOOKCCG GHPLINIACBB) =>
							{
								//0x1202484
								return GHPLINIACBB.PPFNGGCBJKC_Id == KECECJPFEPM.BOJCOPAALNC_EventId;
							});
							//LAB_011fe764
							if(d != null)
							{
								KECECJPFEPM.OAAKAAFFFLE = OHKECKAPJJL.ONKLMFNGCHJ.NHICGIPPMBD_1_NotStarted;
								KECECJPFEPM.PDBPFJJCADD_Start = d.PDBPFJJCADD_OpenAt;
								//LAB_011ff200
								KECECJPFEPM.FDBNFFNFOND_End = d.FDBNFFNFOND_CloseAt; // ivar30
								if(t >= d.PDBPFJJCADD_OpenAt && t < d.FDBNFFNFOND_CloseAt)
								{
									KECECJPFEPM.OAAKAAFFFLE = OHKECKAPJJL.ONKLMFNGCHJ.LAOEGNLOJHC_2;
									KECECJPFEPM.FICHDKOOOOB_Enabled = l[i].PLALNIIBLOF_Enabled == 2;
								}
								else if(d.FDBNFFNFOND_CloseAt < t)
								{
									KECECJPFEPM.OAAKAAFFFLE = OHKECKAPJJL.ONKLMFNGCHJ.OLCLJKOKJCD_5_Ended;
									KECECJPFEPM.FICHDKOOOOB_Enabled = false;
								}
							}
							else
							{
								KECECJPFEPM.FICHDKOOOOB_Enabled = false;
							}
						}
						break;
					case 11:
						{
							OEIJEFBBJBD_EventSp.HNLLDDLBJKG d = dbEv.GGEHACFPNPN.Find((OEIJEFBBJBD_EventSp.HNLLDDLBJKG GHPLINIACBB) =>
							{
								//0x12024DC
								return GHPLINIACBB.PPFNGGCBJKC_Id == KECECJPFEPM.BOJCOPAALNC_EventId;
							});
							//LAB_011fe764
							if(d != null)
							{
								KECECJPFEPM.OAAKAAFFFLE = OHKECKAPJJL.ONKLMFNGCHJ.NHICGIPPMBD_1_NotStarted;
								KECECJPFEPM.PDBPFJJCADD_Start = d.PDBPFJJCADD_OpenAt;
								//LAB_011ff200
								KECECJPFEPM.FDBNFFNFOND_End = d.FDBNFFNFOND_CloseAt; // ivar30
								if(t >= d.PDBPFJJCADD_OpenAt && t < d.FDBNFFNFOND_CloseAt)
								{
									KECECJPFEPM.OAAKAAFFFLE = OHKECKAPJJL.ONKLMFNGCHJ.LAOEGNLOJHC_2;
									KECECJPFEPM.FICHDKOOOOB_Enabled = l[i].PLALNIIBLOF_Enabled == 2;
								}
								else if(d.FDBNFFNFOND_CloseAt < t)
								{
									KECECJPFEPM.OAAKAAFFFLE = OHKECKAPJJL.ONKLMFNGCHJ.OLCLJKOKJCD_5_Ended;
									KECECJPFEPM.FICHDKOOOOB_Enabled = false;
								}
							}
							else
							{
								KECECJPFEPM.FICHDKOOOOB_Enabled = false;
							}
						}
						break;
					case 13:
						{
							OEIJEFBBJBD_EventSp.GFKDEIKPFNF d = dbEv.MEEIEAMCKFB.Find((OEIJEFBBJBD_EventSp.GFKDEIKPFNF GHPLINIACBB) =>
							{
								//0x1202534
								return GHPLINIACBB.PPFNGGCBJKC_Id == KECECJPFEPM.BOJCOPAALNC_EventId;
							});
							if(d != null)
							{
								KECECJPFEPM.OAAKAAFFFLE = OHKECKAPJJL.ONKLMFNGCHJ.NHICGIPPMBD_1_NotStarted;
								KECECJPFEPM.PDBPFJJCADD_Start = d.PDBPFJJCADD_OpenAt;
								KECECJPFEPM.FDBNFFNFOND_End = d.FDBNFFNFOND_CloseAt;
								KCGOMAFPGDD_EventAprilFool s = ICPFLMCPCMN(d.DNJLJMKKDNA_EventId) as KCGOMAFPGDD_EventAprilFool;
								if(s != null)
								{
									KECECJPFEPM.OAAKAAFFFLE = OHKECKAPJJL.ONKLMFNGCHJ.LAOEGNLOJHC_2;
									KECECJPFEPM.MMJHAMFEHCH = OHKECKAPJJL.NBADGBJMBMM.HIDGJCIFFNJ_0;
									if(s.NGHKJOEDLIP.HPNOGLIFJOP_End1 >= t)
									{
										KECECJPFEPM.MMJHAMFEHCH = OHKECKAPJJL.NBADGBJMBMM.HIDGJCIFFNJ_0;
									}
									if(t >= s.NGHKJOEDLIP.JGMDAOACOJF)
									{
										KECECJPFEPM.PDBPFJJCADD_Start = s.NGHKJOEDLIP.JGMDAOACOJF;
										KECECJPFEPM.FDBNFFNFOND_End = s.NGHKJOEDLIP.IDDBFFBPNGI;
										//LAB_011ffc68
										KECECJPFEPM.MMJHAMFEHCH = OHKECKAPJJL.NBADGBJMBMM.IIBKMHIDNPM_1;
									}
									//LAB_011ffca4
									//LAB_011ffcd8
									KECECJPFEPM.GGHDEDJFFOM = d.DNJLJMKKDNA_EventId;
									//LAB_011ffce0
									KECECJPFEPM.FICHDKOOOOB_Enabled = l[i].PLALNIIBLOF_Enabled == 2;
								}
								else
								{
									KECECJPFEPM.FICHDKOOOOB_Enabled = false;
								}
							}
							else
							{
								KECECJPFEPM.FICHDKOOOOB_Enabled = false;
							}
						}
						break;
					case 14:
					case 15:
						{
							OEIJEFBBJBD_EventSp.CKHKIMCMLAH d = dbEv.PBBAKFCFGKN.Find((OEIJEFBBJBD_EventSp.CKHKIMCMLAH GHPLINIACBB) =>
							{
								//0x120258C
								return GHPLINIACBB.PPFNGGCBJKC_Id == KECECJPFEPM.BOJCOPAALNC_EventId;
							});
							if(d != null)
							{
								KECECJPFEPM.OAAKAAFFFLE = OHKECKAPJJL.ONKLMFNGCHJ.NHICGIPPMBD_1_NotStarted;
								KECECJPFEPM.PDBPFJJCADD_Start = d.PDBPFJJCADD_OpenAt;
								KECECJPFEPM.FDBNFFNFOND_End = d.FDBNFFNFOND_CloseAt;
								KCGOMAFPGDD_EventAprilFool s = ICPFLMCPCMN(d.DNJLJMKKDNA_EventId) as KCGOMAFPGDD_EventAprilFool;
								if(s != null)
								{
									KECECJPFEPM.OAAKAAFFFLE = OHKECKAPJJL.ONKLMFNGCHJ.LAOEGNLOJHC_2;
									KECECJPFEPM.MMJHAMFEHCH = OHKECKAPJJL.NBADGBJMBMM.HIDGJCIFFNJ_0;
									if(s.NGHKJOEDLIP.HPNOGLIFJOP_End1 >= t)
									{
										KECECJPFEPM.OAAKAAFFFLE = OHKECKAPJJL.ONKLMFNGCHJ.LAOEGNLOJHC_2;
										KECECJPFEPM.MMJHAMFEHCH = OHKECKAPJJL.NBADGBJMBMM.HIDGJCIFFNJ_0;
									}
									if(t >= s.NGHKJOEDLIP.JGMDAOACOJF)
									{
										KECECJPFEPM.PDBPFJJCADD_Start = s.NGHKJOEDLIP.JGMDAOACOJF;
										KECECJPFEPM.FDBNFFNFOND_End = s.NGHKJOEDLIP.IDDBFFBPNGI;
										KECECJPFEPM.OAAKAAFFFLE = OHKECKAPJJL.ONKLMFNGCHJ.LAOEGNLOJHC_2;
										//LAB_011ffc68
										KECECJPFEPM.MMJHAMFEHCH = OHKECKAPJJL.NBADGBJMBMM.IIBKMHIDNPM_1;
									}
									//LAB_011ffca4
									//LAB_011ffcd8
									KECECJPFEPM.GGHDEDJFFOM = d.DNJLJMKKDNA_EventId;
									//LAB_011ffce0
									KECECJPFEPM.FICHDKOOOOB_Enabled = l[i].PLALNIIBLOF_Enabled == 2;
								}
							}
							else
							{
								KECECJPFEPM.FICHDKOOOOB_Enabled = false;
							}
						}
						break;
					case 18:
						KECECJPFEPM.OAAKAAFFFLE = OHKECKAPJJL.ONKLMFNGCHJ.NHICGIPPMBD_1_NotStarted;
						if(GNGMCIAIKMA.HHCJCDFCLOB != null)
						{
							JKICPBIIHNE_Bingo.HNOGDJFJGPM b = GNGMCIAIKMA.HHCJCDFCLOB.EBEDAPJFHCE_GetBingo(KECECJPFEPM.BOJCOPAALNC_EventId);
							if(b != null)
							{
								KECECJPFEPM.OAAKAAFFFLE = OHKECKAPJJL.ONKLMFNGCHJ.NHICGIPPMBD_1_NotStarted;
								KECECJPFEPM.PDBPFJJCADD_Start = b.PDBPFJJCADD_StartTime;
								KECECJPFEPM.FDBNFFNFOND_End = b.FDBNFFNFOND_EndTime;
								if(t >= b.PDBPFJJCADD_StartTime)
								{
									KECECJPFEPM.OAAKAAFFFLE = OHKECKAPJJL.ONKLMFNGCHJ.LAOEGNLOJHC_2;
								}
								if(t >= b.FDBNFFNFOND_EndTime)
								{
									KECECJPFEPM.OAAKAAFFFLE = OHKECKAPJJL.ONKLMFNGCHJ.OLCLJKOKJCD_5_Ended;
								}
								if(GNGMCIAIKMA.HHCJCDFCLOB.EAJLHMIMAPE(KECECJPFEPM.BOJCOPAALNC_EventId))
								{
									//LAB_011ff2a8
									KECECJPFEPM.OAAKAAFFFLE = OHKECKAPJJL.ONKLMFNGCHJ.OLCLJKOKJCD_5_Ended;
									KECECJPFEPM.FICHDKOOOOB_Enabled = false;
								}
								else
								{
									KECECJPFEPM.FICHDKOOOOB_Enabled = false;
								}
							}
							else
							{
								KECECJPFEPM.FICHDKOOOOB_Enabled = false;
							}
						}
						else
						{
							KECECJPFEPM.FICHDKOOOOB_Enabled = false;
						}
						break;
				}
				//KECECJPFEPM.FICHDKOOOOB = bv36 && l[i].PLALNIIBLOF_Enabled == 2;
				if(!KECECJPFEPM.FICHDKOOOOB_Enabled)
				{
					KECECJPFEPM.LHMOAJAIJCO_IsNew = false;
				}
				NBONAPKIILC_Buttons.Add(KECECJPFEPM);
			}
			//LAB_011ffe1c
		}
	}

	// // RVA: 0x1200E0C Offset: 0x1200E0C VA: 0x1200E0C
	private DIHHCBACKGG_DbSection ICPFLMCPCMN(int EKANGPODCEP)
	{
        IKDICBBFBMI_EventBase ev = JEPBIIJDGEF_EventInfo.HHCJCDFCLOB.OIKOHACJPCB_GetEventById(EKANGPODCEP);
		if(ev == null)
			return null;
		return IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.LBDOLHGDIEB_GetDbSection(ev.JOPOPMLFINI_QuestId);
    }

	// // RVA: 0x1200230 Offset: 0x1200230 VA: 0x1200230
	private void NBKMNMGEELE(OHKECKAPJJL IOCGPICMPOG, OEIJEFBBJBD_EventSp NDFIEMPPMLF, List<LOBDIAABMKG> MKHCLKMFBLJ, long JHNMKKNEENE)
	{
		OEIJEFBBJBD_EventSp.NJJEAKMBGPN NDNHHGJKJGM = null;
		if(IOCGPICMPOG.PNDEAHGLJIC_BtnType == OHKECKAPJJL.GPNHNIGPGCL.LAJAJEMJBFC_12_Gacha3)
		{
			NDNHHGJKJGM = NDFIEMPPMLF.AIJIJLFKNOM.Find((OEIJEFBBJBD_EventSp.NJJEAKMBGPN GHPLINIACBB) =>
			{
				//0x12026FC
				return GHPLINIACBB.PPFNGGCBJKC_Id == IOCGPICMPOG.BOJCOPAALNC_EventId && GHPLINIACBB.PLALNIIBLOF_Enabled == 2;
			});
		}
		else if(IOCGPICMPOG.PNDEAHGLJIC_BtnType == OHKECKAPJJL.GPNHNIGPGCL.ILBPPODCPPP_9_Gacha2)
		{
			NDNHHGJKJGM = NDFIEMPPMLF.OAIHCOFBEIE.Find((OEIJEFBBJBD_EventSp.NJJEAKMBGPN GHPLINIACBB) =>
			{
				//0x1202694
				return GHPLINIACBB.PPFNGGCBJKC_Id == IOCGPICMPOG.BOJCOPAALNC_EventId && GHPLINIACBB.PLALNIIBLOF_Enabled == 2;
			});
		}
		else if(IOCGPICMPOG.PNDEAHGLJIC_BtnType == OHKECKAPJJL.GPNHNIGPGCL.PDCBCIGDPHL_1_Gacha1)
		{
			NDNHHGJKJGM = NDFIEMPPMLF.MODIJHPMHGJ.Find((OEIJEFBBJBD_EventSp.NJJEAKMBGPN GHPLINIACBB) =>
			{
				//0x120262C
				return GHPLINIACBB.PPFNGGCBJKC_Id == IOCGPICMPOG.BOJCOPAALNC_EventId && GHPLINIACBB.PLALNIIBLOF_Enabled == 2;
			});
		}
		//LAB_01200480
		if(NDNHHGJKJGM != null)
		{
			IOCGPICMPOG.GGHDEDJFFOM = NDNHHGJKJGM.PPFNGGCBJKC_Id;
			IOCGPICMPOG.PDBPFJJCADD_Start = NDNHHGJKJGM.PDBPFJJCADD_OpenAt;
			IOCGPICMPOG.FDBNFFNFOND_End = NDNHHGJKJGM.FDBNFFNFOND_CloseAt;
			IOCGPICMPOG.BDEOMEBFDFF_GachaId = NDNHHGJKJGM.BDEOMEBFDFF_GachaId;
			if(JHNMKKNEENE >= IOCGPICMPOG.PDBPFJJCADD_Start && IOCGPICMPOG.FDBNFFNFOND_End >= JHNMKKNEENE)
			{
				IOCGPICMPOG.OAAKAAFFFLE = OHKECKAPJJL.ONKLMFNGCHJ.LAOEGNLOJHC_2;
				LOBDIAABMKG d = MKHCLKMFBLJ.Find((LOBDIAABMKG GHPLINIACBB) =>
				{
					//0x1202764
					return NDNHHGJKJGM.BDEOMEBFDFF_GachaId == GHPLINIACBB.FDEBLMKEMLF_TypeAndSeriesId;
				});
				if(d != null)
				{
					if(IOCGPICMPOG.PNDEAHGLJIC_BtnType == OHKECKAPJJL.GPNHNIGPGCL.LAJAJEMJBFC_12_Gacha3)
					{
						if(!d.FJAOAGNFABN_HasOneDay)
							return;
						EGOLBAPFHHD_Common.PCHECKGDJDK d2 = CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave.KCCLEHLLOFG_Common.BGDMJGDEKFJ_GetGachaDraw(d.FDEBLMKEMLF_TypeAndSeriesId);
						if(d2 == null)
							return;
						IOCGPICMPOG.OAAKAAFFFLE = OHKECKAPJJL.ONKLMFNGCHJ.LAOEGNLOJHC_2;
						if(d2.HMFFHLPNMPH < d.ABNMIDCBENB_OneDay)
							return;
					}
					else if(IOCGPICMPOG.PNDEAHGLJIC_BtnType == OHKECKAPJJL.GPNHNIGPGCL.ILBPPODCPPP_9_Gacha2)
					{
						if(LOBDIAABMKG.GPKPIGPDFNL(MKHCLKMFBLJ, d.HHIBBHFHENH_LinkId, d.GPDIDIJDKAG_LinkCount))
							return;
					}
					else
						return;
				}
				IOCGPICMPOG.OAAKAAFFFLE = OHKECKAPJJL.ONKLMFNGCHJ.FBFBGLONIME_6;
			}
			else
			{
				IOCGPICMPOG.OAAKAAFFFLE = OHKECKAPJJL.ONKLMFNGCHJ.OLCLJKOKJCD_5_Ended;
			}
		}
		else
		{
			IOCGPICMPOG.OAAKAAFFFLE = OHKECKAPJJL.ONKLMFNGCHJ.NHICGIPPMBD_1_NotStarted;
		}
	}

	// // RVA: 0x12009A0 Offset: 0x12009A0 VA: 0x12009A0
	private void JLAMIHICOLK(OHKECKAPJJL IOCGPICMPOG, OEIJEFBBJBD_EventSp NDFIEMPPMLF, long JHNMKKNEENE)
	{
		int idx = NDFIEMPPMLF.LMLMPLLNEDG.FindIndex((OEIJEFBBJBD_EventSp.BPNLIPDNKOH GHPLINIACBB) =>
		{
			//0x12027B0
			return GHPLINIACBB.PPFNGGCBJKC == IOCGPICMPOG.BOJCOPAALNC_EventId;
		});
		if(JHNMKKNEENE < NDFIEMPPMLF.LMLMPLLNEDG[idx].PDBPFJJCADD_OpenAt)
		{
			IOCGPICMPOG.OAAKAAFFFLE = OHKECKAPJJL.ONKLMFNGCHJ.OLCLJKOKJCD_5_Ended;
			return;
		}
		if(NDFIEMPPMLF.LMLMPLLNEDG[idx].FDBNFFNFOND_CloseAt < JHNMKKNEENE)
		{
			IOCGPICMPOG.OAAKAAFFFLE = OHKECKAPJJL.ONKLMFNGCHJ.OLCLJKOKJCD_5_Ended;
			return;
		}
		OEIJEFBBJBD_EventSp.BPNLIPDNKOH d = null;
		for(int i = 0; i < EJHPIMANJFP.HHCJCDFCLOB.MHKCPJDNJKI.Count; i++)
		{
			for(int j = 0; j < NDFIEMPPMLF.LMLMPLLNEDG[idx].ALMEBFDEGBG.Length; j++)
			{
				if(EJHPIMANJFP.HHCJCDFCLOB.MHKCPJDNJKI[i].LHENLPLKGLP_StuffId >= 0 && EJHPIMANJFP.HHCJCDFCLOB.MHKCPJDNJKI[i].LHENLPLKGLP_StuffId == NDFIEMPPMLF.LMLMPLLNEDG[idx].ALMEBFDEGBG[j])
				{
					d = NDFIEMPPMLF.LMLMPLLNEDG[idx];
					if(EJHPIMANJFP.HHCJCDFCLOB.MHKCPJDNJKI[i].AJIFADGGAAJ_BoughtQuantity < EJHPIMANJFP.HHCJCDFCLOB.MHKCPJDNJKI[i].GCJMGMBNBCB_BuyLimit)
						break;
				}
			}
		}
		if(idx == 0)
		{
			if(d == null)
			{
				IOCGPICMPOG.IJIDIJBPGNB = OHKECKAPJJL.OHKBMOEIPEP.OFBEAEHFHOG_2;
				//LAB_01200d2c
				IOCGPICMPOG.OAAKAAFFFLE = OHKECKAPJJL.ONKLMFNGCHJ.OLCLJKOKJCD_5_Ended;
			}
			else
				IOCGPICMPOG.IJIDIJBPGNB = OHKECKAPJJL.OHKBMOEIPEP.IPPOEPJEDPP_1;
		}
		else
		{
			if(d == null)
			{
				IOCGPICMPOG.IJIDIJBPGNB = OHKECKAPJJL.OHKBMOEIPEP.GPDBJKNHHGM_4;
				//LAB_01200d2c
				IOCGPICMPOG.OAAKAAFFFLE = OHKECKAPJJL.ONKLMFNGCHJ.OLCLJKOKJCD_5_Ended;
			}
			else
			{
				IOCGPICMPOG.IJIDIJBPGNB = OHKECKAPJJL.OHKBMOEIPEP.FELOJMIJMDD_3;
			}
		}
		IOCGPICMPOG.PDBPFJJCADD_Start = NDFIEMPPMLF.LMLMPLLNEDG[idx].PDBPFJJCADD_OpenAt;
		IOCGPICMPOG.FDBNFFNFOND_End = NDFIEMPPMLF.LMLMPLLNEDG[idx].FDBNFFNFOND_CloseAt;
	}

	// // RVA: 0x1200F50 Offset: 0x1200F50 VA: 0x1200F50
	// public List<OHKECKAPJJL> IOMJELHAFKC(long JHNMKKNEENE) { }

	// // RVA: 0x12013B4 Offset: 0x12013B4 VA: 0x12013B4
	private void IPPIDIDKAKO(OHKECKAPJJL BABOFCLOBGG)
	{
		MessageBank bk = MessageManager.Instance.GetBank("menu");
		long t = NKGJPJPHLIF.HHCJCDFCLOB.IBLPICFDGOF_ServerRequester.FJDBNGEPKHL.KMEFBNBFJHI_GetServerTime();
		if(GNGMCIAIKMA.HHCJCDFCLOB.GBCPDBJEDHL(t))
		{
			QuestTopFormQuestListArgs args = new QuestTopFormQuestListArgs(QuestUtility.m_bingoViewList.Find((CGJKNOCAPII GHPLINIACBB) =>
			{
				//0x1202808
				return BABOFCLOBGG.BOJCOPAALNC_EventId == GHPLINIACBB.PGIIDPEGGPI_EventId;
			}));
			GNGMCIAIKMA.HHCJCDFCLOB.DJGFICMNGGP_SetBingoId(args.viewData.PGIIDPEGGPI_EventId);
			GNGMCIAIKMA.HHCJCDFCLOB.BHFGBNNEMLI(args.viewData.PGIIDPEGGPI_EventId);
			MenuScene.Instance.Mount(TransitionUniqueId.QUEST_BINGOMISSITON, args, true, MenuScene.MenuSceneCamebackInfo.CamBackUnityScene.None);
		}
		else
		{
			if(QuestUtility.IsBeginnerQuest())
			{
				TextPopupSetting s = new TextPopupSetting();
				s.Buttons = new ButtonInfo[1]
				{
					new ButtonInfo() { Label = PopupButton.ButtonLabel.Ok, Type = PopupButton.ButtonType.Positive }
				};
				s.WindowSize = SizeType.Small;
				s.TitleText = bk.GetMessageByLabel("popup_sp_transition_bingo_error_title");
				s.Text = string.Format(bk.GetMessageByLabel("popup_sp_bingo_debutmission_notclear_text"), 1, 1);
				PopupWindowManager.Show(s, null, null, null, null, true, true, false);
			}
		}
	}

	// // RVA: 0x12019B4 Offset: 0x12019B4 VA: 0x12019B4
	public void GEOGJOBNKHG(OHKECKAPJJL BABOFCLOBGG)
	{
		switch(BABOFCLOBGG.LPDLBACJKIB_TransId)
		{
			case 1:
				MenuScene.Instance.Mount(TransitionUniqueId.GACHA2, new GachaScene.GachaArgs(BABOFCLOBGG.BDEOMEBFDFF_GachaId, true), true, MenuScene.MenuSceneCamebackInfo.CamBackUnityScene.None);
				break;
			case 2:
				{
                    IKDICBBFBMI_EventBase ev = JEPBIIJDGEF_EventInfo.HHCJCDFCLOB.OIKOHACJPCB_GetEventById(BABOFCLOBGG.GGHDEDJFFOM);
					if(ev != null)
					{
						CGJKNOCAPII c = new CGJKNOCAPII();
						MenuScene.Instance.Call(TransitionList.Type.QUEST_SELECT, new QuestTopFormQuestListArgs(c.BJKJLDPDEFA(ev, true)), true);
						break;
					}
					MenuScene.Instance.Mount(TransitionUniqueId.HOME, null, true, MenuScene.MenuSceneCamebackInfo.CamBackUnityScene.None);
					break;
                }
			case 3:
				MenuScene.Instance.Mount(TransitionUniqueId.MUSICSELECT, null, true, MenuScene.MenuSceneCamebackInfo.CamBackUnityScene.None);
				break;
			case 4:
				{
					KNKDBNFMAKF_EventSp ev = JEPBIIJDGEF_EventInfo.HHCJCDFCLOB.OEGDCBLNNFF(OHCAABOMEOF.KGOGMKMBCPP_EventType.ENPJADLIFAB_EventSp, KGCNCBOKCBA.GNENJEHKMHD_EventStatus.BCKENOKGLIJ_9_ResultRewardreceived) as KNKDBNFMAKF_EventSp;
					HGFPAFPGIKG h = new HGFPAFPGIKG(BABOFCLOBGG.GGHDEDJFFOM);
					GachaBoxScene.GachaBoxArgs args = new GachaBoxScene.GachaBoxArgs(BABOFCLOBGG.GGHDEDJFFOM);
					args.seasonType = h.ENJLGHMEKEL_Type;
					args.halfTimeId = ev.IIPGGJAKIEO(BABOFCLOBGG.GGHDEDJFFOM);
					MenuScene.Instance.Mount(TransitionUniqueId.HOME_NEWYEAREVENT_GACHABOX, args, true, MenuScene.MenuSceneCamebackInfo.CamBackUnityScene.None);
					break;
				}
			case 5:
				MenuScene.Instance.Mount(TransitionUniqueId.EVENTMUSICSELECT, new EventMusicSelectSceneArgs(BABOFCLOBGG.GGHDEDJFFOM, false, false), true, MenuScene.MenuSceneCamebackInfo.CamBackUnityScene.None);
				break;
			default:
				break;
			case 7:
				{
					KNKDBNFMAKF_EventSp ev = JEPBIIJDGEF_EventInfo.HHCJCDFCLOB.OEGDCBLNNFF(OHCAABOMEOF.KGOGMKMBCPP_EventType.ENPJADLIFAB_EventSp, KGCNCBOKCBA.GNENJEHKMHD_EventStatus.BCKENOKGLIJ_9_ResultRewardreceived) as KNKDBNFMAKF_EventSp;
					if(ev != null)
					{
						CCAAJNJGNDO c = new CCAAJNJGNDO();
						c.MFCPHGNMMFA(ev);
						MenuScene.Instance.Call(TransitionList.Type.NEW_YEAR_EVENT_STORY, new EventStoryArgs(c), true);
					}
					break;
				}
			case 8:
				MenuScene.Instance.Mount(TransitionUniqueId.GACHA2, new GachaScene.GachaArgs(BABOFCLOBGG.BDEOMEBFDFF_GachaId, true), true, MenuScene.MenuSceneCamebackInfo.CamBackUnityScene.None);
				break;
			case 9:
				MenuScene.Instance.Mount(TransitionUniqueId.OFFERSELECT, null, true, MenuScene.MenuSceneCamebackInfo.CamBackUnityScene.None);
				break;
			case 10:
				{
					MusicSelectArgs args = new MusicSelectArgs();
					args.SetSelection(FreeCategoryId.Type.Event);
					MenuScene.Instance.Mount(TransitionUniqueId.MUSICSELECT, args, true, MenuScene.MenuSceneCamebackInfo.CamBackUnityScene.None);
				}
				break;
			case 11:
				IPPIDIDKAKO(BABOFCLOBGG);
				break;
		}
	}
}
