
using System.Collections.Generic;
using XeApp.Game.Common;
using XeApp.Game.Menu;
using XeSys;

public class IHKJLKLAMMC
{
	private int FBGGEFFJJHB_xor; // 0x8
	private long BBEGLBMOBOF_xorl; // 0x10
	private List<OHKECKAPJJL> NBONAPKIILC_Buttons; // 0x18
	private NNJFKLBPBNK_SecureString MHPAELHGOHF = new NNJFKLBPBNK_SecureString(); // 0x1C

	private string KEFGPJBKAOD_BgId { get { return MHPAELHGOHF.DNJEJEANJGL_Value; } set { MHPAELHGOHF.DNJEJEANJGL_Value = value; } } //0x11FCAA8 MKJJKNIMMBC_bgs 0x11FCAD4 NACMHHKKBCJ_bgs

	// RVA: 0x11FCB08 Offset: 0x11FCB08 VA: 0x11FCB08
	public IHKJLKLAMMC()
    {
        FBGGEFFJJHB_xor = LPDNKHAIOLH.CEIBAFOCNCA_Int();
        BBEGLBMOBOF_xorl = FBGGEFFJJHB_xor;
        KEFGPJBKAOD_BgId = "";
    }

	// // RVA: 0x11FCBE0 Offset: 0x11FCBE0 VA: 0x11FCBE0
	public int HCGPNCJNKED(long _JHNMKKNEENE_Time)
	{
		KNKDBNFMAKF_EventSp ev = JEPBIIJDGEF_EventInfo.HHCJCDFCLOB.OEGDCBLNNFF(OHCAABOMEOF.KGOGMKMBCPP_EventType.ENPJADLIFAB_EventSp, KGCNCBOKCBA.GNENJEHKMHD_EventStatus.BCKENOKGLIJ_9_ResultRewardreceived) as KNKDBNFMAKF_EventSp;
		long l1, l2;
		return ev.NJIKJJNLAPL(_JHNMKKNEENE_Time, out l1, out l2);
	}

	// // RVA: 0x11FCE00 Offset: 0x11FCE00 VA: 0x11FCE00
	public string AFMHNPCDAFI_GetBgId(long _JHNMKKNEENE_Time)
	{
		if(KEFGPJBKAOD_BgId == "")
		{
            IKDICBBFBMI_EventBase ev = JEPBIIJDGEF_EventInfo.HHCJCDFCLOB.OEGDCBLNNFF(OHCAABOMEOF.KGOGMKMBCPP_EventType.ENPJADLIFAB_EventSp, KGCNCBOKCBA.GNENJEHKMHD_EventStatus.BCKENOKGLIJ_9_ResultRewardreceived);
			OEIJEFBBJBD_EventSp dbEv = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.LBDOLHGDIEB_Find(ev.JOPOPMLFINI_QuestName) as OEIJEFBBJBD_EventSp;
			OEIJEFBBJBD_EventSp.AOOLGJIFOEI d = dbEv.FDGNDLBDJFH.Find((OEIJEFBBJBD_EventSp.AOOLGJIFOEI JPAEDJJFFOI) =>
			{
				//0x1202860
				return _JHNMKKNEENE_Time >= JPAEDJJFFOI.PDBPFJJCADD_open_at && JPAEDJJFFOI.FDBNFFNFOND_close_at >= _JHNMKKNEENE_Time;
			});
			KEFGPJBKAOD_BgId = ev.PGIIDPEGGPI_EventId.ToString();
			if(d != null && d.OENPCNBFPDA_bg_id > 0)
			{
				KEFGPJBKAOD_BgId = string.Format("{0}{1:D2}", ev.PGIIDPEGGPI_EventId, d.OENPCNBFPDA_bg_id);
			}
        }
		return KEFGPJBKAOD_BgId;
	}

	// // RVA: 0x11FD1E0 Offset: 0x11FD1E0 VA: 0x11FD1E0
	public OHKECKAPJJL EJAPIOEOPNF_GetButtonInfo(int _OIPCCBHIKIA_index)
	{
		return NBONAPKIILC_Buttons[_OIPCCBHIKIA_index];
	}

	// // RVA: 0x11FD260 Offset: 0x11FD260 VA: 0x11FD260
	public OHKECKAPJJL IMOGBABIDFF(OHKECKAPJJL.GPNHNIGPGCL_SpBtnType HEFHKNNMMDD)
	{
		return NBONAPKIILC_Buttons.Find((OHKECKAPJJL _GHPLINIACBB_x) =>
		{
			//0x12022D0
			return _GHPLINIACBB_x.PNDEAHGLJIC_BtnType == HEFHKNNMMDD;
		});
	}

	// // RVA: 0x11FD360 Offset: 0x11FD360 VA: 0x11FD360
	public int MMPDGHKFNLE_GetButtonsCount()
	{
		return NBONAPKIILC_Buttons.Count;
	}

	// // RVA: 0x11FD3D8 Offset: 0x11FD3D8 VA: 0x11FD3D8
	public void KHEKNNFCAOI_Init(List<LOBDIAABMKG> MKHCLKMFBLJ)
	{
        KNKDBNFMAKF_EventSp ev = JEPBIIJDGEF_EventInfo.HHCJCDFCLOB.OEGDCBLNNFF(OHCAABOMEOF.KGOGMKMBCPP_EventType.ENPJADLIFAB_EventSp, KGCNCBOKCBA.GNENJEHKMHD_EventStatus.BCKENOKGLIJ_9_ResultRewardreceived) as KNKDBNFMAKF_EventSp;
        NBONAPKIILC_Buttons = new List<OHKECKAPJJL>();
		OEIJEFBBJBD_EventSp dbEv = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.LBDOLHGDIEB_Find(ev.JOPOPMLFINI_QuestName) as OEIJEFBBJBD_EventSp;
		long t = NKGJPJPHLIF.HHCJCDFCLOB.IBLPICFDGOF_ServerRequester.FJDBNGEPKHL_Time.KMEFBNBFJHI_GetServerTime();
		List<OEIJEFBBJBD_EventSp.AODDNOGBFLP> l = dbEv.DAAHEOIEJFL(t);
		for(int i = 0; i < l.Count; i++)
		{
			if(l[i].PLALNIIBLOF_en == 2)
			{
				long l1 = l[i].PDBPFJJCADD_open_at;
				if(l1 == 0)
					l1 = dbEv.NGHKJOEDLIP_Settings.BONDDBOFBND_RankingStart;
				long l2 = l[i].FDBNFFNFOND_close_at;
				if(l2 == 0)
					l2 = dbEv.NGHKJOEDLIP_Settings.HPNOGLIFJOP_RankingEnd;
				OHKECKAPJJL KECECJPFEPM = new OHKECKAPJJL();
				KECECJPFEPM.OBKGEDCKHHE_Init(l[i].MGLJCOMOGLO_BtnId);
				KECECJPFEPM.PPFNGGCBJKC_id = l[i].PPFNGGCBJKC_id;
				KECECJPFEPM.MGLJCOMOGLO_BtnId = l[i].MGLJCOMOGLO_BtnId;
				KECECJPFEPM.GNOFNIOLPPC_ImgId = l[i].GNOFNIOLPPC_ImgId;
				KECECJPFEPM.BOJCOPAALNC_EventId = l[i].BOJCOPAALNC_EventId;
				KECECJPFEPM.PNDEAHGLJIC_BtnType = (OHKECKAPJJL.GPNHNIGPGCL_SpBtnType)l[i].PNDEAHGLJIC_BtnType;
				KECECJPFEPM.LPDLBACJKIB_TransId = l[i].LPDLBACJKIB_TransId;
				KECECJPFEPM.PDBPFJJCADD_open_at = l1;
				KECECJPFEPM.FDBNFFNFOND_close_at = l2;
				KECECJPFEPM.LHMOAJAIJCO_is_new = ev.IHPAMMBNOPC(l[i].PPFNGGCBJKC_id);
				switch(l[i].PNDEAHGLJIC_BtnType)
				{
					case 1:
					case 9:
					case 12:
						NBKMNMGEELE(KECECJPFEPM, dbEv, MKHCLKMFBLJ, t);
						KECECJPFEPM.FICHDKOOOOB_Enabled = KECECJPFEPM.OAAKAAFFFLE == OHKECKAPJJL.ONKLMFNGCHJ_SpStep.LAOEGNLOJHC_2_Start && l[i].PLALNIIBLOF_en == 2;
						break;
					case 2:
						{
							long v1, v2, v3, v4;
							ev.NEMGJHBEJCP(ev.MEDEJHKNAFG_GetCurrentMissionGroup(t), t, out v1, out v2, out v3, out v4);
							if(t < v1)
							{
								KECECJPFEPM.OAAKAAFFFLE = OHKECKAPJJL.ONKLMFNGCHJ_SpStep.NHICGIPPMBD_1_NotStarted;
								KECECJPFEPM.PDBPFJJCADD_open_at = v1;
								KECECJPFEPM.FICHDKOOOOB_Enabled = false;
							}
							else
							{
								KECECJPFEPM.OAAKAAFFFLE = OHKECKAPJJL.ONKLMFNGCHJ_SpStep.LAOEGNLOJHC_2_Start;
								KECECJPFEPM.MMJHAMFEHCH = OHKECKAPJJL.NBADGBJMBMM_MissionStatus.HIDGJCIFFNJ_0_Available;
								if(v2 >= t)
								{
									KECECJPFEPM.PDBPFJJCADD_open_at = v1;
									KECECJPFEPM.FDBNFFNFOND_close_at = v2;
									KECECJPFEPM.MMJHAMFEHCH = OHKECKAPJJL.NBADGBJMBMM_MissionStatus.HIDGJCIFFNJ_0_Available;
								}
								if(t >= v3)
								{
									KECECJPFEPM.PDBPFJJCADD_open_at = v3;
									KECECJPFEPM.FDBNFFNFOND_close_at = v4;
									KECECJPFEPM.MMJHAMFEHCH = OHKECKAPJJL.NBADGBJMBMM_MissionStatus.IIBKMHIDNPM_1_Reward;
								}
								//LAB_011ffcd8 ivar29
								KECECJPFEPM.GGHDEDJFFOM = ev.PGIIDPEGGPI_EventId;
								//LAB_011ffce0
								KECECJPFEPM.FICHDKOOOOB_Enabled = l[i].PLALNIIBLOF_en == 2;
							}
							break;
						}
					case 3:
						{
							KECECJPFEPM.OAAKAAFFFLE = OHKECKAPJJL.ONKLMFNGCHJ_SpStep.OLCLJKOKJCD_5_End;
							OEIJEFBBJBD_EventSp.LJAJKDHLGAJ d = dbEv.CDPGPHGBNOA.Find((OEIJEFBBJBD_EventSp.LJAJKDHLGAJ _GHPLINIACBB_x) =>
							{
								//0x1202314
								return _GHPLINIACBB_x.PPFNGGCBJKC_id == KECECJPFEPM.BOJCOPAALNC_EventId;
							});
							if(d !=null)
							{
								KECECJPFEPM.LCCDKCPBJAK_BannerId = d.OPKCNBFBBKP_BannerId;
								KECECJPFEPM.OAAKAAFFFLE = OHKECKAPJJL.ONKLMFNGCHJ_SpStep.NHICGIPPMBD_1_NotStarted;
								KECECJPFEPM.PDBPFJJCADD_open_at = d.PDBPFJJCADD_open_at;
								//LAB_011ff200 i12 = d.FDBNFFNFOND_close_at
								KECECJPFEPM.FDBNFFNFOND_close_at = d.FDBNFFNFOND_close_at; // ivar30
								if(t >= d.PDBPFJJCADD_open_at && t < d.FDBNFFNFOND_close_at)
								{
									KECECJPFEPM.OAAKAAFFFLE = OHKECKAPJJL.ONKLMFNGCHJ_SpStep.LAOEGNLOJHC_2_Start;
									KECECJPFEPM.FICHDKOOOOB_Enabled = l[i].PLALNIIBLOF_en == 2;
								}
								else if(d.FDBNFFNFOND_close_at < t)
								{
									KECECJPFEPM.OAAKAAFFFLE = OHKECKAPJJL.ONKLMFNGCHJ_SpStep.OLCLJKOKJCD_5_End;
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
						KECECJPFEPM.OAAKAAFFFLE = OHKECKAPJJL.ONKLMFNGCHJ_SpStep.LAOEGNLOJHC_2_Start;
						JLAMIHICOLK(KECECJPFEPM, dbEv, t);
						// LAB_011ff81c bv32 = iv18
						KECECJPFEPM.FICHDKOOOOB_Enabled = (KECECJPFEPM.IJIDIJBPGNB == OHKECKAPJJL.OHKBMOEIPEP.FELOJMIJMDD_3 || KECECJPFEPM.IJIDIJBPGNB == OHKECKAPJJL.OHKBMOEIPEP.IPPOEPJEDPP_1 ) && l[i].PLALNIIBLOF_en == 2;
						break;
					case 5:
						{
							KECECJPFEPM.OAAKAAFFFLE = OHKECKAPJJL.ONKLMFNGCHJ_SpStep.NHICGIPPMBD_1_NotStarted;
							OEIJEFBBJBD_EventSp.NJJEAKMBGPN d = dbEv.EOKILLGMGDL.Find((OEIJEFBBJBD_EventSp.NJJEAKMBGPN _GHPLINIACBB_x) =>
							{
								//0x120236C
								return _GHPLINIACBB_x.PPFNGGCBJKC_id == KECECJPFEPM.BOJCOPAALNC_EventId && _GHPLINIACBB_x.PLALNIIBLOF_en == 2;
							});
							if(d != null)
							{
                                CHHECNJBMLA_EventBoxGacha ev2 = JEPBIIJDGEF_EventInfo.HHCJCDFCLOB.OIKOHACJPCB_GetEventById(d.BDEOMEBFDFF_gacha_id) as CHHECNJBMLA_EventBoxGacha;
								if(ev2 != null)
								{
									IMDBGDNPLJA_EventBoxGacha dbEv2 = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.LBDOLHGDIEB_Find(ev2.JOPOPMLFINI_QuestName) as IMDBGDNPLJA_EventBoxGacha;
									KECECJPFEPM.CDPAEHCPPAM = false;
									KECECJPFEPM.GGHDEDJFFOM = d.BDEOMEBFDFF_gacha_id;
									KECECJPFEPM.PDBPFJJCADD_open_at = dbEv2.NGHKJOEDLIP_Settings.FCNKIKOOFKE;
									KECECJPFEPM.FDBNFFNFOND_close_at = ev2.DPJCPDKALGI_RankingEnd;
									if(t >= dbEv2.NGHKJOEDLIP_Settings.FCNKIKOOFKE)
									{
										KECECJPFEPM.OAAKAAFFFLE = OHKECKAPJJL.ONKLMFNGCHJ_SpStep.LAOEGNLOJHC_2_Start;
										KECECJPFEPM.CDPAEHCPPAM = true;
									}
									if(t < ev2.LJOHLEGGGMC_RewardEnd)
									{
										KECECJPFEPM.FICHDKOOOOB_Enabled = l[i].PLALNIIBLOF_en == 2;
										break;
									}
									//o27 = KECECJPFEPM
									//b36 = true;
									//LAB_011ff2d8
									KECECJPFEPM.OAAKAAFFFLE = OHKECKAPJJL.ONKLMFNGCHJ_SpStep.OLCLJKOKJCD_5_End;
									KECECJPFEPM.FICHDKOOOOB_Enabled = l[i].PLALNIIBLOF_en == 2;
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
							OEIJEFBBJBD_EventSp.PHIMHBPOMAD d = dbEv.ALGFDOBECLI.Find((OEIJEFBBJBD_EventSp.PHIMHBPOMAD _GHPLINIACBB_x) =>
							{
								//0x12023D4
								return _GHPLINIACBB_x.PPFNGGCBJKC_id == KECECJPFEPM.BOJCOPAALNC_EventId;
							});
							if(d != null)
							{
								KECECJPFEPM.OAAKAAFFFLE = OHKECKAPJJL.ONKLMFNGCHJ_SpStep.NHICGIPPMBD_1_NotStarted;
								KECECJPFEPM.PDBPFJJCADD_open_at = d.PDBPFJJCADD_open_at;
								KECECJPFEPM.FDBNFFNFOND_close_at = d.FDBNFFNFOND_close_at;
                                IKDICBBFBMI_EventBase ev2 = JEPBIIJDGEF_EventInfo.HHCJCDFCLOB.OIKOHACJPCB_GetEventById(d.DNJLJMKKDNA_EventId);
								if(ev2 != null)
								{
									ev.HCDGELDHFHB_UpdateStatus(t);
									if(t >= ev2.GLIMIGNNGGB_RankingStart)
									{
										KECECJPFEPM.OAAKAAFFFLE = OHKECKAPJJL.ONKLMFNGCHJ_SpStep.LAOEGNLOJHC_2_Start;
									}
									if(t >= ev2.JDDFILGNGFH_RewardStart)
									{
										KECECJPFEPM.OAAKAAFFFLE = OHKECKAPJJL.ONKLMFNGCHJ_SpStep.FKHAJADPBJK_4_Epilogue;
									}
									if(t >= ev2.LJOHLEGGGMC_RewardEnd)
									{
										KECECJPFEPM.OAAKAAFFFLE = OHKECKAPJJL.ONKLMFNGCHJ_SpStep.OLCLJKOKJCD_5_End;
									}
									if(ev2.NGOFCFJHOMI_Status == KGCNCBOKCBA.GNENJEHKMHD_EventStatus.EMAMLLFAOJI_6_Counting)
									{
										KECECJPFEPM.OAAKAAFFFLE = OHKECKAPJJL.ONKLMFNGCHJ_SpStep.EMAMLLFAOJI_3_Counting;
									}
									if(ev2.NGOFCFJHOMI_Status < KGCNCBOKCBA.GNENJEHKMHD_EventStatus.EMAMLLFAOJI_6_Counting)
									{
										KECECJPFEPM.FDBNFFNFOND_close_at = ev2.DPJCPDKALGI_RankingEnd;
									}
									else
									{
										if(l2 >= ev2.LJOHLEGGGMC_RewardEnd)
										{
											KECECJPFEPM.FDBNFFNFOND_close_at = ev2.LJOHLEGGGMC_RewardEnd;
										}
										else
										{
											KECECJPFEPM.FDBNFFNFOND_close_at = l2;
										}
									}
									KECECJPFEPM.GGHDEDJFFOM = ev2.PGIIDPEGGPI_EventId;
									//i21 = 0;
									if(t >= KECECJPFEPM.PDBPFJJCADD_open_at && t < ev2.LJOHLEGGGMC_RewardEnd)
									{
										KECECJPFEPM.FICHDKOOOOB_Enabled = l[i].PLALNIIBLOF_en == 2;
									}
									//LAB_011ff81c
									else
									{
										KECECJPFEPM.FICHDKOOOOB_Enabled = false;
									}
								}
								else
								{
									KECECJPFEPM.OAAKAAFFFLE = OHKECKAPJJL.ONKLMFNGCHJ_SpStep.OLCLJKOKJCD_5_End;
									d = dbEv.ALGFDOBECLI.Find((OEIJEFBBJBD_EventSp.PHIMHBPOMAD JPAEDJJFFOI) =>
									{
										//0x12025E4
										return JPAEDJJFFOI.PLALNIIBLOF_en == 2 && JPAEDJJFFOI.DNJLJMKKDNA_EventId == d.DNJLJMKKDNA_EventId;
									});
									if(d == null || t >= d.PDBPFJJCADD_open_at)
									{
										KECECJPFEPM.FICHDKOOOOB_Enabled = false;
									}
									//b37 = 0;
									//i21 = 1;
									//LAB_011ff2e0
									KECECJPFEPM.FICHDKOOOOB_Enabled = false;
									KECECJPFEPM.OAAKAAFFFLE = OHKECKAPJJL.ONKLMFNGCHJ_SpStep.NHICGIPPMBD_1_NotStarted;
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
							KECECJPFEPM.OAAKAAFFFLE = OHKECKAPJJL.ONKLMFNGCHJ_SpStep.NHICGIPPMBD_1_NotStarted;
							if(t >= l1)
							{
								KECECJPFEPM.OAAKAAFFFLE = OHKECKAPJJL.ONKLMFNGCHJ_SpStep.LAOEGNLOJHC_2_Start;
							}
							if(t >= l2)
							{
								KECECJPFEPM.OAAKAAFFFLE = OHKECKAPJJL.ONKLMFNGCHJ_SpStep.OLCLJKOKJCD_5_End;
							}
							KECECJPFEPM.GGHDEDJFFOM = 1;
							OEIJEFBBJBD_EventSp.MFEJBIMLPGI d = dbEv.JIEIOFMJEBI.Find((OEIJEFBBJBD_EventSp.MFEJBIMLPGI _GHPLINIACBB_x) =>
							{
								//0x120242C
								return _GHPLINIACBB_x.PPFNGGCBJKC_id == KECECJPFEPM.BOJCOPAALNC_EventId;
							});
							if(d.PLALNIIBLOF_en == 2)
							{
								if(t >= d.PDBPFJJCADD_open_at)
								{
									KECECJPFEPM.GGHDEDJFFOM = d.KDGJBBFKLGI_Chapter;
								}
								KECECJPFEPM.FICHDKOOOOB_Enabled = l2 >= t && t >= l1 && l[i].PLALNIIBLOF_en == 2;
							}
						}
						break;
					case 10:
						{
							KECECJPFEPM.OAAKAAFFFLE = OHKECKAPJJL.ONKLMFNGCHJ_SpStep.OLCLJKOKJCD_5_End;
							OEIJEFBBJBD_EventSp.LFKNBOOKCCG d = dbEv.GMJFGPNMMBD.Find((OEIJEFBBJBD_EventSp.LFKNBOOKCCG _GHPLINIACBB_x) =>
							{
								//0x1202484
								return _GHPLINIACBB_x.PPFNGGCBJKC_id == KECECJPFEPM.BOJCOPAALNC_EventId;
							});
							//LAB_011fe764
							if(d != null)
							{
								KECECJPFEPM.OAAKAAFFFLE = OHKECKAPJJL.ONKLMFNGCHJ_SpStep.NHICGIPPMBD_1_NotStarted;
								KECECJPFEPM.PDBPFJJCADD_open_at = d.PDBPFJJCADD_open_at;
								//LAB_011ff200
								KECECJPFEPM.FDBNFFNFOND_close_at = d.FDBNFFNFOND_close_at; // ivar30
								if(t >= d.PDBPFJJCADD_open_at && t < d.FDBNFFNFOND_close_at)
								{
									KECECJPFEPM.OAAKAAFFFLE = OHKECKAPJJL.ONKLMFNGCHJ_SpStep.LAOEGNLOJHC_2_Start;
									KECECJPFEPM.FICHDKOOOOB_Enabled = l[i].PLALNIIBLOF_en == 2;
								}
								else if(d.FDBNFFNFOND_close_at < t)
								{
									KECECJPFEPM.OAAKAAFFFLE = OHKECKAPJJL.ONKLMFNGCHJ_SpStep.OLCLJKOKJCD_5_End;
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
							OEIJEFBBJBD_EventSp.HNLLDDLBJKG d = dbEv.GGEHACFPNPN.Find((OEIJEFBBJBD_EventSp.HNLLDDLBJKG _GHPLINIACBB_x) =>
							{
								//0x12024DC
								return _GHPLINIACBB_x.PPFNGGCBJKC_id == KECECJPFEPM.BOJCOPAALNC_EventId;
							});
							//LAB_011fe764
							if(d != null)
							{
								KECECJPFEPM.OAAKAAFFFLE = OHKECKAPJJL.ONKLMFNGCHJ_SpStep.NHICGIPPMBD_1_NotStarted;
								KECECJPFEPM.PDBPFJJCADD_open_at = d.PDBPFJJCADD_open_at;
								//LAB_011ff200
								KECECJPFEPM.FDBNFFNFOND_close_at = d.FDBNFFNFOND_close_at; // ivar30
								if(t >= d.PDBPFJJCADD_open_at && t < d.FDBNFFNFOND_close_at)
								{
									KECECJPFEPM.OAAKAAFFFLE = OHKECKAPJJL.ONKLMFNGCHJ_SpStep.LAOEGNLOJHC_2_Start;
									KECECJPFEPM.FICHDKOOOOB_Enabled = l[i].PLALNIIBLOF_en == 2;
								}
								else if(d.FDBNFFNFOND_close_at < t)
								{
									KECECJPFEPM.OAAKAAFFFLE = OHKECKAPJJL.ONKLMFNGCHJ_SpStep.OLCLJKOKJCD_5_End;
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
							OEIJEFBBJBD_EventSp.GFKDEIKPFNF d = dbEv.MEEIEAMCKFB.Find((OEIJEFBBJBD_EventSp.GFKDEIKPFNF _GHPLINIACBB_x) =>
							{
								//0x1202534
								return _GHPLINIACBB_x.PPFNGGCBJKC_id == KECECJPFEPM.BOJCOPAALNC_EventId;
							});
							if(d != null)
							{
								KECECJPFEPM.OAAKAAFFFLE = OHKECKAPJJL.ONKLMFNGCHJ_SpStep.NHICGIPPMBD_1_NotStarted;
								KECECJPFEPM.PDBPFJJCADD_open_at = d.PDBPFJJCADD_open_at;
								KECECJPFEPM.FDBNFFNFOND_close_at = d.FDBNFFNFOND_close_at;
								KCGOMAFPGDD_EventAprilFool s = ICPFLMCPCMN(d.DNJLJMKKDNA_EventId) as KCGOMAFPGDD_EventAprilFool;
								if(s != null)
								{
									KECECJPFEPM.OAAKAAFFFLE = OHKECKAPJJL.ONKLMFNGCHJ_SpStep.LAOEGNLOJHC_2_Start;
									KECECJPFEPM.MMJHAMFEHCH = OHKECKAPJJL.NBADGBJMBMM_MissionStatus.HIDGJCIFFNJ_0_Available;
									if(s.NGHKJOEDLIP_Settings.HPNOGLIFJOP_RankingEnd >= t)
									{
										KECECJPFEPM.MMJHAMFEHCH = OHKECKAPJJL.NBADGBJMBMM_MissionStatus.HIDGJCIFFNJ_0_Available;
									}
									if(t >= s.NGHKJOEDLIP_Settings.JGMDAOACOJF_RewardStart)
									{
										KECECJPFEPM.PDBPFJJCADD_open_at = s.NGHKJOEDLIP_Settings.JGMDAOACOJF_RewardStart;
										KECECJPFEPM.FDBNFFNFOND_close_at = s.NGHKJOEDLIP_Settings.IDDBFFBPNGI_RewardEnd;
										//LAB_011ffc68
										KECECJPFEPM.MMJHAMFEHCH = OHKECKAPJJL.NBADGBJMBMM_MissionStatus.IIBKMHIDNPM_1_Reward;
									}
									//LAB_011ffca4
									//LAB_011ffcd8
									KECECJPFEPM.GGHDEDJFFOM = d.DNJLJMKKDNA_EventId;
									//LAB_011ffce0
									KECECJPFEPM.FICHDKOOOOB_Enabled = l[i].PLALNIIBLOF_en == 2;
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
							OEIJEFBBJBD_EventSp.CKHKIMCMLAH d = dbEv.PBBAKFCFGKN.Find((OEIJEFBBJBD_EventSp.CKHKIMCMLAH _GHPLINIACBB_x) =>
							{
								//0x120258C
								return _GHPLINIACBB_x.PPFNGGCBJKC_id == KECECJPFEPM.BOJCOPAALNC_EventId;
							});
							if(d != null)
							{
								KECECJPFEPM.OAAKAAFFFLE = OHKECKAPJJL.ONKLMFNGCHJ_SpStep.NHICGIPPMBD_1_NotStarted;
								KECECJPFEPM.PDBPFJJCADD_open_at = d.PDBPFJJCADD_open_at;
								KECECJPFEPM.FDBNFFNFOND_close_at = d.FDBNFFNFOND_close_at;
								KCGOMAFPGDD_EventAprilFool s = ICPFLMCPCMN(d.DNJLJMKKDNA_EventId) as KCGOMAFPGDD_EventAprilFool;
								if(s != null)
								{
									KECECJPFEPM.OAAKAAFFFLE = OHKECKAPJJL.ONKLMFNGCHJ_SpStep.LAOEGNLOJHC_2_Start;
									KECECJPFEPM.MMJHAMFEHCH = OHKECKAPJJL.NBADGBJMBMM_MissionStatus.HIDGJCIFFNJ_0_Available;
									if(s.NGHKJOEDLIP_Settings.HPNOGLIFJOP_RankingEnd >= t)
									{
										KECECJPFEPM.OAAKAAFFFLE = OHKECKAPJJL.ONKLMFNGCHJ_SpStep.LAOEGNLOJHC_2_Start;
										KECECJPFEPM.MMJHAMFEHCH = OHKECKAPJJL.NBADGBJMBMM_MissionStatus.HIDGJCIFFNJ_0_Available;
									}
									if(t >= s.NGHKJOEDLIP_Settings.JGMDAOACOJF_RewardStart)
									{
										KECECJPFEPM.PDBPFJJCADD_open_at = s.NGHKJOEDLIP_Settings.JGMDAOACOJF_RewardStart;
										KECECJPFEPM.FDBNFFNFOND_close_at = s.NGHKJOEDLIP_Settings.IDDBFFBPNGI_RewardEnd;
										KECECJPFEPM.OAAKAAFFFLE = OHKECKAPJJL.ONKLMFNGCHJ_SpStep.LAOEGNLOJHC_2_Start;
										//LAB_011ffc68
										KECECJPFEPM.MMJHAMFEHCH = OHKECKAPJJL.NBADGBJMBMM_MissionStatus.IIBKMHIDNPM_1_Reward;
									}
									//LAB_011ffca4
									//LAB_011ffcd8
									KECECJPFEPM.GGHDEDJFFOM = d.DNJLJMKKDNA_EventId;
									//LAB_011ffce0
									KECECJPFEPM.FICHDKOOOOB_Enabled = l[i].PLALNIIBLOF_en == 2;
								}
							}
							else
							{
								KECECJPFEPM.FICHDKOOOOB_Enabled = false;
							}
						}
						break;
					case 18:
						KECECJPFEPM.OAAKAAFFFLE = OHKECKAPJJL.ONKLMFNGCHJ_SpStep.NHICGIPPMBD_1_NotStarted;
						if(GNGMCIAIKMA.HHCJCDFCLOB != null)
						{
							JKICPBIIHNE_Bingo.HNOGDJFJGPM b = GNGMCIAIKMA.HHCJCDFCLOB.EBEDAPJFHCE_GetBingo(KECECJPFEPM.BOJCOPAALNC_EventId);
							if(b != null)
							{
								KECECJPFEPM.OAAKAAFFFLE = OHKECKAPJJL.ONKLMFNGCHJ_SpStep.NHICGIPPMBD_1_NotStarted;
								KECECJPFEPM.PDBPFJJCADD_open_at = b.PDBPFJJCADD_open_at;
								KECECJPFEPM.FDBNFFNFOND_close_at = b.FDBNFFNFOND_close_at;
								if(t >= b.PDBPFJJCADD_open_at)
								{
									KECECJPFEPM.OAAKAAFFFLE = OHKECKAPJJL.ONKLMFNGCHJ_SpStep.LAOEGNLOJHC_2_Start;
								}
								if(t >= b.FDBNFFNFOND_close_at)
								{
									KECECJPFEPM.OAAKAAFFFLE = OHKECKAPJJL.ONKLMFNGCHJ_SpStep.OLCLJKOKJCD_5_End;
								}
								if(GNGMCIAIKMA.HHCJCDFCLOB.EAJLHMIMAPE(KECECJPFEPM.BOJCOPAALNC_EventId))
								{
									//LAB_011ff2a8
									KECECJPFEPM.OAAKAAFFFLE = OHKECKAPJJL.ONKLMFNGCHJ_SpStep.OLCLJKOKJCD_5_End;
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
				//KECECJPFEPM.FICHDKOOOOB_Enabled = bv36 && l[i].PLALNIIBLOF_en == 2;
				if(!KECECJPFEPM.FICHDKOOOOB_Enabled)
				{
					KECECJPFEPM.LHMOAJAIJCO_is_new = false;
				}
				NBONAPKIILC_Buttons.Add(KECECJPFEPM);
			}
			//LAB_011ffe1c
		}
	}

	// // RVA: 0x1200E0C Offset: 0x1200E0C VA: 0x1200E0C
	private DIHHCBACKGG_DbSection ICPFLMCPCMN(int _EKANGPODCEP_EventId)
	{
        IKDICBBFBMI_EventBase ev = JEPBIIJDGEF_EventInfo.HHCJCDFCLOB.OIKOHACJPCB_GetEventById(_EKANGPODCEP_EventId);
		if(ev == null)
			return null;
		return IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.LBDOLHGDIEB_Find(ev.JOPOPMLFINI_QuestName);
    }

	// // RVA: 0x1200230 Offset: 0x1200230 VA: 0x1200230
	private void NBKMNMGEELE(OHKECKAPJJL IOCGPICMPOG, OEIJEFBBJBD_EventSp _NDFIEMPPMLF_master, List<LOBDIAABMKG> MKHCLKMFBLJ, long _JHNMKKNEENE_Time)
	{
		OEIJEFBBJBD_EventSp.NJJEAKMBGPN NDNHHGJKJGM_Gach = null;
		if(IOCGPICMPOG.PNDEAHGLJIC_BtnType == OHKECKAPJJL.GPNHNIGPGCL_SpBtnType.LAJAJEMJBFC_12_Gacha3)
		{
			NDNHHGJKJGM_Gach = _NDFIEMPPMLF_master.AIJIJLFKNOM.Find((OEIJEFBBJBD_EventSp.NJJEAKMBGPN _GHPLINIACBB_x) =>
			{
				//0x12026FC
				return _GHPLINIACBB_x.PPFNGGCBJKC_id == IOCGPICMPOG.BOJCOPAALNC_EventId && _GHPLINIACBB_x.PLALNIIBLOF_en == 2;
			});
		}
		else if(IOCGPICMPOG.PNDEAHGLJIC_BtnType == OHKECKAPJJL.GPNHNIGPGCL_SpBtnType.ILBPPODCPPP_9_Gacha2)
		{
			NDNHHGJKJGM_Gach = _NDFIEMPPMLF_master.OAIHCOFBEIE.Find((OEIJEFBBJBD_EventSp.NJJEAKMBGPN _GHPLINIACBB_x) =>
			{
				//0x1202694
				return _GHPLINIACBB_x.PPFNGGCBJKC_id == IOCGPICMPOG.BOJCOPAALNC_EventId && _GHPLINIACBB_x.PLALNIIBLOF_en == 2;
			});
		}
		else if(IOCGPICMPOG.PNDEAHGLJIC_BtnType == OHKECKAPJJL.GPNHNIGPGCL_SpBtnType.PDCBCIGDPHL_1_Gacha1)
		{
			NDNHHGJKJGM_Gach = _NDFIEMPPMLF_master.MODIJHPMHGJ.Find((OEIJEFBBJBD_EventSp.NJJEAKMBGPN _GHPLINIACBB_x) =>
			{
				//0x120262C
				return _GHPLINIACBB_x.PPFNGGCBJKC_id == IOCGPICMPOG.BOJCOPAALNC_EventId && _GHPLINIACBB_x.PLALNIIBLOF_en == 2;
			});
		}
		//LAB_01200480
		if(NDNHHGJKJGM_Gach != null)
		{
			IOCGPICMPOG.GGHDEDJFFOM = NDNHHGJKJGM_Gach.PPFNGGCBJKC_id;
			IOCGPICMPOG.PDBPFJJCADD_open_at = NDNHHGJKJGM_Gach.PDBPFJJCADD_open_at;
			IOCGPICMPOG.FDBNFFNFOND_close_at = NDNHHGJKJGM_Gach.FDBNFFNFOND_close_at;
			IOCGPICMPOG.BDEOMEBFDFF_gacha_id = NDNHHGJKJGM_Gach.BDEOMEBFDFF_gacha_id;
			if(_JHNMKKNEENE_Time >= IOCGPICMPOG.PDBPFJJCADD_open_at && IOCGPICMPOG.FDBNFFNFOND_close_at >= _JHNMKKNEENE_Time)
			{
				IOCGPICMPOG.OAAKAAFFFLE = OHKECKAPJJL.ONKLMFNGCHJ_SpStep.LAOEGNLOJHC_2_Start;
				LOBDIAABMKG d = MKHCLKMFBLJ.Find((LOBDIAABMKG _GHPLINIACBB_x) =>
				{
					//0x1202764
					return NDNHHGJKJGM_Gach.BDEOMEBFDFF_gacha_id == _GHPLINIACBB_x.FDEBLMKEMLF_TypeAndSeriesId;
				});
				if(d != null)
				{
					if(IOCGPICMPOG.PNDEAHGLJIC_BtnType == OHKECKAPJJL.GPNHNIGPGCL_SpBtnType.LAJAJEMJBFC_12_Gacha3)
					{
						if(!d.FJAOAGNFABN_HasOneDay)
							return;
						EGOLBAPFHHD_Common.PCHECKGDJDK d2 = CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_PlayerData.KCCLEHLLOFG_Common.BGDMJGDEKFJ_GetGachaDraw(d.FDEBLMKEMLF_TypeAndSeriesId);
						if(d2 == null)
							return;
						IOCGPICMPOG.OAAKAAFFFLE = OHKECKAPJJL.ONKLMFNGCHJ_SpStep.LAOEGNLOJHC_2_Start;
						if(d2.HMFFHLPNMPH_count < d.ABNMIDCBENB_OneDay)
							return;
					}
					else if(IOCGPICMPOG.PNDEAHGLJIC_BtnType == OHKECKAPJJL.GPNHNIGPGCL_SpBtnType.ILBPPODCPPP_9_Gacha2)
					{
						if(LOBDIAABMKG.GPKPIGPDFNL(MKHCLKMFBLJ, d.HHIBBHFHENH_LinkQuestId, d.GPDIDIJDKAG_LinkCount))
							return;
					}
					else
						return;
				}
				IOCGPICMPOG.OAAKAAFFFLE = OHKECKAPJJL.ONKLMFNGCHJ_SpStep.FBFBGLONIME_6_AfterGacha;
			}
			else
			{
				IOCGPICMPOG.OAAKAAFFFLE = OHKECKAPJJL.ONKLMFNGCHJ_SpStep.OLCLJKOKJCD_5_End;
			}
		}
		else
		{
			IOCGPICMPOG.OAAKAAFFFLE = OHKECKAPJJL.ONKLMFNGCHJ_SpStep.NHICGIPPMBD_1_NotStarted;
		}
	}

	// // RVA: 0x12009A0 Offset: 0x12009A0 VA: 0x12009A0
	private void JLAMIHICOLK(OHKECKAPJJL IOCGPICMPOG, OEIJEFBBJBD_EventSp _NDFIEMPPMLF_master, long _JHNMKKNEENE_Time)
	{
		int idx = _NDFIEMPPMLF_master.LMLMPLLNEDG.FindIndex((OEIJEFBBJBD_EventSp.BPNLIPDNKOH _GHPLINIACBB_x) =>
		{
			//0x12027B0
			return _GHPLINIACBB_x.PPFNGGCBJKC_id == IOCGPICMPOG.BOJCOPAALNC_EventId;
		});
		if(_JHNMKKNEENE_Time < _NDFIEMPPMLF_master.LMLMPLLNEDG[idx].PDBPFJJCADD_open_at)
		{
			IOCGPICMPOG.OAAKAAFFFLE = OHKECKAPJJL.ONKLMFNGCHJ_SpStep.OLCLJKOKJCD_5_End;
			return;
		}
		if(_NDFIEMPPMLF_master.LMLMPLLNEDG[idx].FDBNFFNFOND_close_at < _JHNMKKNEENE_Time)
		{
			IOCGPICMPOG.OAAKAAFFFLE = OHKECKAPJJL.ONKLMFNGCHJ_SpStep.OLCLJKOKJCD_5_End;
			return;
		}
		OEIJEFBBJBD_EventSp.BPNLIPDNKOH d = null;
		for(int i = 0; i < EJHPIMANJFP.HHCJCDFCLOB.MHKCPJDNJKI_products.Count; i++)
		{
			for(int j = 0; j < _NDFIEMPPMLF_master.LMLMPLLNEDG[idx].ALMEBFDEGBG.Length; j++)
			{
				if(EJHPIMANJFP.HHCJCDFCLOB.MHKCPJDNJKI_products[i].LHENLPLKGLP_StuffId >= 0 && EJHPIMANJFP.HHCJCDFCLOB.MHKCPJDNJKI_products[i].LHENLPLKGLP_StuffId == _NDFIEMPPMLF_master.LMLMPLLNEDG[idx].ALMEBFDEGBG[j])
				{
					d = _NDFIEMPPMLF_master.LMLMPLLNEDG[idx];
					if(EJHPIMANJFP.HHCJCDFCLOB.MHKCPJDNJKI_products[i].AJIFADGGAAJ_BoughtQuantity < EJHPIMANJFP.HHCJCDFCLOB.MHKCPJDNJKI_products[i].GCJMGMBNBCB_BuyLimit)
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
				IOCGPICMPOG.OAAKAAFFFLE = OHKECKAPJJL.ONKLMFNGCHJ_SpStep.OLCLJKOKJCD_5_End;
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
				IOCGPICMPOG.OAAKAAFFFLE = OHKECKAPJJL.ONKLMFNGCHJ_SpStep.OLCLJKOKJCD_5_End;
			}
			else
			{
				IOCGPICMPOG.IJIDIJBPGNB = OHKECKAPJJL.OHKBMOEIPEP.FELOJMIJMDD_3;
			}
		}
		IOCGPICMPOG.PDBPFJJCADD_open_at = _NDFIEMPPMLF_master.LMLMPLLNEDG[idx].PDBPFJJCADD_open_at;
		IOCGPICMPOG.FDBNFFNFOND_close_at = _NDFIEMPPMLF_master.LMLMPLLNEDG[idx].FDBNFFNFOND_close_at;
	}

	// // RVA: 0x1200F50 Offset: 0x1200F50 VA: 0x1200F50
	// public List<OHKECKAPJJL> IOMJELHAFKC(long _JHNMKKNEENE_Time) { }

	// // RVA: 0x12013B4 Offset: 0x12013B4 VA: 0x12013B4
	private void IPPIDIDKAKO(OHKECKAPJJL BABOFCLOBGG)
	{
		MessageBank bk = MessageManager.Instance.GetBank("menu");
		long t = NKGJPJPHLIF.HHCJCDFCLOB.IBLPICFDGOF_ServerRequester.FJDBNGEPKHL_Time.KMEFBNBFJHI_GetServerTime();
		if(GNGMCIAIKMA.HHCJCDFCLOB.GBCPDBJEDHL(t))
		{
			QuestTopFormQuestListArgs args = new QuestTopFormQuestListArgs(QuestUtility.m_bingoViewList.Find((CGJKNOCAPII _GHPLINIACBB_x) =>
			{
				//0x1202808
				return BABOFCLOBGG.BOJCOPAALNC_EventId == _GHPLINIACBB_x.PGIIDPEGGPI_EventId;
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
				PopupWindowManager.Show(s, null, null, null, null, true, true, false, null, null, null, null, null);
			}
		}
	}

	// // RVA: 0x12019B4 Offset: 0x12019B4 VA: 0x12019B4
	public void GEOGJOBNKHG(OHKECKAPJJL BABOFCLOBGG)
	{
		switch(BABOFCLOBGG.LPDLBACJKIB_TransId)
		{
			case 1:
				MenuScene.Instance.Mount(TransitionUniqueId.GACHA2, new GachaScene.GachaArgs(BABOFCLOBGG.BDEOMEBFDFF_gacha_id, true), true, MenuScene.MenuSceneCamebackInfo.CamBackUnityScene.None);
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
				MenuScene.Instance.Mount(TransitionUniqueId.GACHA2, new GachaScene.GachaArgs(BABOFCLOBGG.BDEOMEBFDFF_gacha_id, true), true, MenuScene.MenuSceneCamebackInfo.CamBackUnityScene.None);
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
