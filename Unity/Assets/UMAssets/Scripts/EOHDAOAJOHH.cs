using System;
using System.Collections.Generic;
using UnityEngine;
using XeApp;
using XeApp.Game;
using XeSys;

public class EOHDAOAJOHH
{
	private const int DDPKGMOPGCF = 100;
	public static bool FKOBPENIMGM; // 0x0
	private static sbyte[] AKCBIJHIOGH = new sbyte[0x18] {0x00, 0x00, 0x00, 0x00, 0x01, 0x01, 0x01, 0x01, 0x02, 0x02, 0x02, 0x02,
  0x03, 0x03, 0x03, 0x03, 0x04, 0x04, 0x04, 0x04, 0x05, 0x05, 0x05, 0x05}; // 0x4
	private OJIHOFLJOMK KGCCNEBMHMM; // 0x8
	private static string[] OBAFHIJBOJP = new string[3] {JpStringLiterals.StringLiteral_10309, JpStringLiterals.StringLiteral_10309, JpStringLiterals.StringLiteral_10310}; // 0xC
	private const long KMBNMDMFDMB = 5;

	// public static int OOLEIEJLHGJ { get; } // KCGOAPBNDPP 0xFB756C
	public static EOHDAOAJOHH HHCJCDFCLOB { get; private set; } // 0x8 LGMPACEDIJF NKACBOEHELJ OKPMHKNCNAL
	public bool BOCLJJMAHHB { get; private set; } // 0xC DMHGANHPELM  BNHJHGPMIBC MOPEPMIODKP
	public bool NCAJHMNKJJD_EnableStaminaNotif { get; private set; } // 0xD HBEKEPBPKAD MABKOJMFDCI NCMHNDFLDOC
	public bool MOEDFPOIJDM { get; private set; } // 0xE KNECAFLJOBG GNMEIHEKNDI KNFPFPAKEJB

	// // RVA: 0xFB76C4 Offset: 0xFB76C4 VA: 0xFB76C4
	public void IJBGPAENLJA(MonoBehaviour DANMJLOBLIE)
	{
		HHCJCDFCLOB = this;
		BOCLJJMAHHB = false;
		NCAJHMNKJJD_EnableStaminaNotif = false;
	}

	// // RVA: 0xFB774C Offset: 0xFB774C VA: 0xFB774C
	public void OJKIKODJJCD()
	{
		KGCCNEBMHMM = new OJIHOFLJOMK();
		KGCCNEBMHMM.KHEKNNFCAOI();
		BOCLJJMAHHB = BBDNBCHOFIP();
		NCAJHMNKJJD_EnableStaminaNotif = GameManager.Instance.localSave.EPJOACOONAC_GetSave().BOJCCICAHJK_Notification.KNOLBNCEHFB_StaminaReceive != 0;
		FOPAJBDEFCP_CancelStaminaNotif();
		PELOGBHNHIL_CancelAPNotif();
		OJIHOFLJOMK.JOAJCEDHKFP();
	}

	// // RVA: 0xFB79E8 Offset: 0xFB79E8 VA: 0xFB79E8
	public void FGDBKOCCKOE(bool CKLGHFBPFPJ)
	{
		if(!MOEDFPOIJDM)
		{
			if(!CKLGHFBPFPJ)
			{
				OJIHOFLJOMK.JOAJCEDHKFP();
				FOPAJBDEFCP_CancelStaminaNotif();
				PELOGBHNHIL_CancelAPNotif();
				APNOKHOAMCD_CancelVopNotif();
				DABJPLFAADF_CancelLimitedItemsNotif();
				return;
			}
			if(GameManager.Instance != null)
			{
				if(GameManager.Instance.localSave.EPJOACOONAC_GetSave().BOJCCICAHJK_Notification.KNOLBNCEHFB_StaminaReceive == 0)
				{
					FOPAJBDEFCP_CancelStaminaNotif();
				}
				else
				{
					APHODAFLJFB_SetStaminaNotif();
				}
				if(GameManager.Instance.localSave.EPJOACOONAC_GetSave().BOJCCICAHJK_Notification.HILOMEJEJAM_ApReceive == 0)
				{
					PELOGBHNHIL_CancelAPNotif();
				}
				else
				{
					KIMJDIFEKCE_SetApNotif();
				}
				if(GameManager.Instance.localSave.EPJOACOONAC_GetSave().BOJCCICAHJK_Notification.JAFLKPEEGIM_OfferReceive == 0)
				{
					APNOKHOAMCD_CancelVopNotif();
				}
				else
				{
					PAIHLJKFMNL_SetVOPNotif();
				}
				OPODBGPJDCJ_SetComebackNotif();
				PNAOEAFNNFA();
				HGKPAOGOMJJ();
			}
		}
	}

	// // RVA: 0xFBA08C Offset: 0xFBA08C VA: 0xFBA08C
	// public void HJHKBNNEKMI(long KPBJHHHMOJE) { }

	// // RVA: 0xFB7C8C Offset: 0xFB7C8C VA: 0xFB7C8C
	public void APHODAFLJFB_SetStaminaNotif()
	{
		if(KGCCNEBMHMM != null)
		{
			if(GameManager.Instance.localSave.EPJOACOONAC_GetSave().BOJCCICAHJK_Notification.KNOLBNCEHFB_StaminaReceive != 0)
			{
				if(CIOECGOMILE.HHCJCDFCLOB != null && CIOECGOMILE.HHCJCDFCLOB.LNAHEIEIBOI_Initialized && CIOECGOMILE.HHCJCDFCLOB.BPLOEAHOPFI_StaminaUpdater != null)
				{
					long t = CIOECGOMILE.HHCJCDFCLOB.BPLOEAHOPFI_StaminaUpdater.LEHHIGOOIJJ();
					if(t != 0)
					{
						long c = Utility.GetCurrentUnixTime();
						if(t >= c && t - c >= 5 && JPFDCIFKBML(t))
						{
							KGCCNEBMHMM.LKCPCCANJFB_SendNotif(EAPDJLPDHEJ.HHEEFGIDMPC, t, 1, OBAFHIJBOJP[0], OBAFHIJBOJP[2], 102, "png");
						}
					}
				}
			}
		}
	}

	// // RVA: 0xFB7FF0 Offset: 0xFB7FF0 VA: 0xFB7FF0
	public void KIMJDIFEKCE_SetApNotif()
	{
		if(KGCCNEBMHMM != null)
		{
			if(GameManager.Instance.localSave.EPJOACOONAC_GetSave().BOJCCICAHJK_Notification.HILOMEJEJAM_ApReceive != 0)
			{
				PKNOKJNLPOE_EventRaid p = JEPBIIJDGEF_EventInfo.HHCJCDFCLOB.OEGDCBLNNFF(OHCAABOMEOF.KGOGMKMBCPP_EventType.CADKONMJEDA_EventRaid, KGCNCBOKCBA.GNENJEHKMHD_EventStatus.BCKENOKGLIJ_9_ResultRewardreceived) as PKNOKJNLPOE_EventRaid;
				if(p != null)
				{
					TodoLogger.LogError(TodoLogger.EventRaid_11_13, "Event Raid");
				}
			}
		}
	}

	// // RVA: 0xFB94D0 Offset: 0xFB94D0 VA: 0xFB94D0
	public void HGKPAOGOMJJ()
	{
		if(KGCCNEBMHMM != null)
		{
			if(CIOECGOMILE.HHCJCDFCLOB != null)
			{
				if(IMMAOANGPNK.HHCJCDFCLOB != null)
				{
					if(CIOECGOMILE.HHCJCDFCLOB.LNAHEIEIBOI_Initialized)
					{
						if(IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database != null)
						{
							if(CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave != null)
							{
								if(GameManager.Instance.localSave.EPJOACOONAC_GetSave().BOJCCICAHJK_Notification.OKGKFFLMFKH_LimitedReceive != 0 && 
									IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.GDEKCOOBLMA_System != null)
								{
									string push_limited_item_send_day = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.GDEKCOOBLMA_System.EFEGBHACJAL("push_limited_item_send_day", "");
									if(push_limited_item_send_day != "")
									{
										string[] strs = push_limited_item_send_day.Split(new char[] { ',' });
										List<int> l = new List<int>();
										for(int i = 0; i < strs.Length; i++)
										{
											int v;
											if(int.TryParse(strs[i], out v))
											{
												l.Add(v);
											}
										}
										long t = NKGJPJPHLIF.HHCJCDFCLOB.IBLPICFDGOF_ServerRequester.FJDBNGEPKHL.KMEFBNBFJHI_GetServerTime();
										MessageBank bk = MessageManager.Instance.GetBank("menu");
										PDAHBODAGFO(IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database, CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave, l, t, bk.GetMessageByLabel("notification_rareup_star_limit_title"), bk.GetMessageByLabel("notification_rareup_star_limit_text"), false);
										MGEKDBAHOBM(IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database, CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave, l, t, bk.GetMessageByLabel("notification_rareup_star_limit_title"), bk.GetMessageByLabel("notification_rareup_star_limit_text"), false);
										CFOKLGOIDAL(IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database, CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave, l, t, bk.GetMessageByLabel("notification_rareup_star_limit_title"), bk.GetMessageByLabel("notification_rareup_star_limit_text"), false);
										CJJJNACJGAG(IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database, CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave, l, t, bk.GetMessageByLabel("notification_rareup_star_limit_title"), bk.GetMessageByLabel("notification_rareup_star_limit_text"), false);
										PBCMCHIPKID(IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database, CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave, l, t, bk.GetMessageByLabel("notification_rareup_star_limit_title"), bk.GetMessageByLabel("notification_rareup_star_limit_text"), false);
										GONPMCPCJKE(IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database, CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave, l, t, bk.GetMessageByLabel("notification_rareup_star_limit_title"), bk.GetMessageByLabel("notification_rareup_star_limit_text"), false);
									}
								}
							}
						}
					}
				}
			}
		}
	}

	// // RVA: 0xFB9B8C Offset: 0xFB9B8C VA: 0xFB9B8C
	public void DABJPLFAADF_CancelLimitedItemsNotif()
	{
		if(KGCCNEBMHMM != null)
		{
			if(IMMAOANGPNK.HHCJCDFCLOB != null)
			{
				if(IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database != null && IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.GDEKCOOBLMA_System != null)
				{
					string push_limited_item_send_day = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.GDEKCOOBLMA_System.EFEGBHACJAL("push_limited_item_send_day", "");
					if(push_limited_item_send_day != "")
					{
						string[] strs = push_limited_item_send_day.Split(new char[] { ',' });
						List<int> l = new List<int>();
						for(int i = 0; i < strs.Length; i++)
						{
							int v;
							if(int.TryParse(strs[i], out v))
							{
								l.Add(v);
							}
						}
						for(int i = 0; i < l.Count; i++)
						{
							KGCCNEBMHMM.JCHLONCMPAJ_CancelNotif(l[i] + 50000);
							KGCCNEBMHMM.JCHLONCMPAJ_CancelNotif(l[i] + 60000);
							KGCCNEBMHMM.JCHLONCMPAJ_CancelNotif(l[i] + 80000);
							KGCCNEBMHMM.JCHLONCMPAJ_CancelNotif(l[i] + 70000);
							KGCCNEBMHMM.JCHLONCMPAJ_CancelNotif(l[i] + 90000);
							GIJMLPJPFHB_CancelTicketNotif(IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database, l[i]);
						}
					}
				}
			}
		}
	}

	// // RVA: 0xFBC2B8 Offset: 0xFBC2B8 VA: 0xFBC2B8
	public void GIJMLPJPFHB_CancelTicketNotif(OKGLGHCBCJP_Database LKMHPJKIFDN, int IOBIPABJHEG)
	{
		int a = IOBIPABJHEG + 100000;
		for(int i = 0; i < LKMHPJKIFDN.GKMAHADAAFI_GachaTicket.DHIACJMOEBH.Count; i++)
		{
			KGCCNEBMHMM.JCHLONCMPAJ_CancelNotif(a);
			a += 100;
		}
	}

	// // RVA: 0xFBA4A0 Offset: 0xFBA4A0 VA: 0xFBA4A0
	public void PDAHBODAGFO(OKGLGHCBCJP_Database LKMHPJKIFDN, BBHNACPENDM_ServerSaveData LDEGEHAEALK, List<int> JKFIHOHONHD, long JHNMKKNEENE, string GBBMOEGDGEM, string DPOGLCNOBCI, bool OPEBKHLLMPH = false)
	{
		if(LDEGEHAEALK.DPNKPPBEAGJ_RareUpItem.LDLCGGACHGA(JHNMKKNEENE) > 0)
		{
			long c = LDEGEHAEALK.DPNKPPBEAGJ_RareUpItem.JCJKKMECCFI(JHNMKKNEENE);
			int id = LKMHPJKIFDN.GDEKCOOBLMA_System.LPJLEHAJADA("rarity_up_item_id", 230001);
			string name = EKLNMHFCAOI.INCKKODFJAP_GetItemName(id);
			string s = string.Format(DPOGLCNOBCI, name);
			for(int i = 0; i < JKFIHOHONHD.Count; i++)
			{
				long t = LHGGKIELMAA(c, JKFIHOHONHD[i]);
				if(JPFDCIFKBML(t) && c - JHNMKKNEENE >= 5 && JHNMKKNEENE < t)
				{
					KGCCNEBMHMM.LKCPCCANJFB_SendNotif(EAPDJLPDHEJ.BCFFEECIMJG, t, JKFIHOHONHD[i] + 50000, GBBMOEGDGEM, s, 102, "png");
				}
			}
		}
	}

	// // RVA: 0xFBA830 Offset: 0xFBA830 VA: 0xFBA830
	public void MGEKDBAHOBM(OKGLGHCBCJP_Database LKMHPJKIFDN, BBHNACPENDM_ServerSaveData LDEGEHAEALK, List<int> JKFIHOHONHD, long JHNMKKNEENE, string GBBMOEGDGEM, string DPOGLCNOBCI, bool OPEBKHLLMPH = false)
	{
		List<AODFBGCCBPE> l = AODFBGCCBPE.FKDIMODKKJD(false);
		if(l != null)
		{
			l = l.FindAll((AODFBGCCBPE GHPLINIACBB) =>
			{
				//0xFBDCF0
				return GHPLINIACBB.INDDJNMPONH_Type == AODFBGCCBPE.NJMPLEENNPO.AOMIBCNBBOD_1_Vc;
			});
			if(l.Count > 0)
			{
				long t = l[0].GJFPFFBAKGK;
				int a = 0;
				for(int i = 0; i < l.Count; i++)
				{
					if(l[i].GJFPFFBAKGK < t)
					{
						t = l[i].GJFPFFBAKGK;
						a = i;
					}
				}
				HHJHIFJIKAC_BonusVc.MNGJPJBCMBH vc = LKMHPJKIFDN.NBKNAAPBFFL_BonusVc.CDENCMNHNGA[l[a].JPGALGPNJAI_VcId - 1];
				int itemId = EKLNMHFCAOI.GJEEGMCBGGM_GetItemFullId(EKLNMHFCAOI.FKGCBLHOOCL_Category.IBBDMIFICCN_BonusVC, vc.PPFNGGCBJKC_Id);
				string s = string.Format(DPOGLCNOBCI, EKLNMHFCAOI.INCKKODFJAP_GetItemName(itemId));
				int a2 = CIOECGOMILE.HHCJCDFCLOB.NOJDLFKKMDD_GetCurrencyTotal(l[a].JPGALGPNJAI_VcId);
				if (a2 > 0)
				{
					for(int i = 0; i < JKFIHOHONHD.Count; i++)
					{
						long c = LHGGKIELMAA(l[a].GJFPFFBAKGK, JKFIHOHONHD[i]);
						if(JPFDCIFKBML(c) && l[a].GJFPFFBAKGK - JHNMKKNEENE >= 5 && JHNMKKNEENE < c)
						{
							KGCCNEBMHMM.LKCPCCANJFB_SendNotif(EAPDJLPDHEJ.BCFFEECIMJG, c, JKFIHOHONHD[i] + 70000, GBBMOEGDGEM, s, 102, "png");
						}
					}
				}
			}
		}
	}

	// // RVA: 0xFBAEA0 Offset: 0xFBAEA0 VA: 0xFBAEA0
	public void CJJJNACJGAG(OKGLGHCBCJP_Database LKMHPJKIFDN, BBHNACPENDM_ServerSaveData LDEGEHAEALK, List<int> JKFIHOHONHD, long JHNMKKNEENE, string GBBMOEGDGEM, string DPOGLCNOBCI, bool OPEBKHLLMPH = false)
	{
		List<AODFBGCCBPE> l = AODFBGCCBPE.FKDIMODKKJD(false);
		if(l != null)
		{
			l = l.FindAll((AODFBGCCBPE GHPLINIACBB) =>
			{
				//0xFBDD1C
				return GHPLINIACBB.INDDJNMPONH_Type == AODFBGCCBPE.NJMPLEENNPO.BDMFENCIPEB_2_Medal;
			});
			if(l.Count > 0)
			{
				long t = l[0].GJFPFFBAKGK;
				int a = 0;
				for(int i = 0; i < l.Count; i++)
				{
					if(l[i].GJFPFFBAKGK < t)
					{
						t = l[i].GJFPFFBAKGK;
						a = i;
					}
				}
				EGOLBAPFHHD_Common.GLBBNDKGEOC mdl = CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave.KCCLEHLLOFG_Common.MHKJEBNOPIM_Medal[l[a].IBAKPKKEDJM];
				int itemId = EKLNMHFCAOI.GJEEGMCBGGM_GetItemFullId(EKLNMHFCAOI.FKGCBLHOOCL_Category.IBBDMIFICCN_BonusVC, mdl.PPFNGGCBJKC_Id);
				string s = string.Format(DPOGLCNOBCI, EKLNMHFCAOI.INCKKODFJAP_GetItemName(itemId));
				int a2 = EKLNMHFCAOI.ALHCGDMEMID_GetNumItems(LKMHPJKIFDN, LDEGEHAEALK, EKLNMHFCAOI.FKGCBLHOOCL_Category.ADCAAALBAIF_Medal, l[a].IBAKPKKEDJM, null);
				if (a2 > 0)
				{
					for(int i = 0; i < JKFIHOHONHD.Count; i++)
					{
						long c = LHGGKIELMAA(l[a].GJFPFFBAKGK, JKFIHOHONHD[i]);
						if(JPFDCIFKBML(c) && l[a].GJFPFFBAKGK - JHNMKKNEENE >= 5 && JHNMKKNEENE < c)
						{
							KGCCNEBMHMM.LKCPCCANJFB_SendNotif(EAPDJLPDHEJ.BCFFEECIMJG, c, JKFIHOHONHD[i] + 80000, GBBMOEGDGEM, s, 102, "png");
						}
					}
				}
			}
		}
	}

	// // RVA: 0xFBB524 Offset: 0xFBB524 VA: 0xFBB524
	public void CFOKLGOIDAL(OKGLGHCBCJP_Database LKMHPJKIFDN, BBHNACPENDM_ServerSaveData LDEGEHAEALK, List<int> JKFIHOHONHD, long JHNMKKNEENE, string GBBMOEGDGEM, string DPOGLCNOBCI, bool OPEBKHLLMPH = false)
	{
		int a = LDEGEHAEALK.AFHFIPLOKMN_LimitedItem.HPPKOGKNKMH(1, JHNMKKNEENE);
		if(a > 0)
		{
			long t = LDEGEHAEALK.AFHFIPLOKMN_LimitedItem.BLKPKBICPKK(1, JHNMKKNEENE);
			int itemId = EKLNMHFCAOI.GJEEGMCBGGM_GetItemFullId(EKLNMHFCAOI.FKGCBLHOOCL_Category.DLOPEFGOAPD_LimitedItem, 1);
			string s = string.Format(DPOGLCNOBCI, EKLNMHFCAOI.INCKKODFJAP_GetItemName(itemId));
			for(int i = 0; i < JKFIHOHONHD.Count; i++)
			{
				long c = LHGGKIELMAA(t, JKFIHOHONHD[i]);
				if(JPFDCIFKBML(c) && t - JHNMKKNEENE >= 5 && JHNMKKNEENE < c)
				{
					KGCCNEBMHMM.LKCPCCANJFB_SendNotif(EAPDJLPDHEJ.BCFFEECIMJG, c, JKFIHOHONHD[i] + 60000, GBBMOEGDGEM, s, 102, "png");
				}
			}
		}
	}

	// // RVA: 0xFBB86C Offset: 0xFBB86C VA: 0xFBB86C
	public void PBCMCHIPKID(OKGLGHCBCJP_Database LKMHPJKIFDN, BBHNACPENDM_ServerSaveData LDEGEHAEALK, List<int> JKFIHOHONHD, long JHNMKKNEENE, string GBBMOEGDGEM, string DPOGLCNOBCI, bool OPEBKHLLMPH = false)
	{
		if(JEPBIIJDGEF_EventInfo.HHCJCDFCLOB != null)
		{
			CHHECNJBMLA_EventBoxGacha ev = JEPBIIJDGEF_EventInfo.HHCJCDFCLOB.JNHHEMLIDGJ() as CHHECNJBMLA_EventBoxGacha;
			if(ev != null)
			{
				TodoLogger.LogError(TodoLogger.EventBoxGacha_8, "Event Gacha");
			}
		}
	}

	// // RVA: 0xFBBCD4 Offset: 0xFBBCD4 VA: 0xFBBCD4
	public void GONPMCPCJKE(OKGLGHCBCJP_Database LKMHPJKIFDN, BBHNACPENDM_ServerSaveData LDEGEHAEALK, List<int> JKFIHOHONHD, long JHNMKKNEENE, string GBBMOEGDGEM, string DPOGLCNOBCI, bool OPEBKHLLMPH = false)
	{
		HPBDNNACBAK h = NKGJPJPHLIF.HHCJCDFCLOB.FPNBCFJHENI;
		if(h != null)
		{
			List<int> PDHNBPOMAEM = LKMHPJKIFDN.GKMAHADAAFI_GachaTicket.DHIACJMOEBH; // PGFMIBMJBHD
			for(int IIOMHMKENDF = 0; IIOMHMKENDF < PDHNBPOMAEM.Count; IIOMHMKENDF++)
			{
				HPBDNNACBAK.MBMMGKJBJGD d = h.GGKFCDDFHFP.Find((HPBDNNACBAK.MBMMGKJBJGD GHPLINIACBB) =>
				{
					//0xFBDD70
					return GHPLINIACBB.PPFNGGCBJKC_Id == PDHNBPOMAEM[IIOMHMKENDF];
				});
				if(d != null && d.HNBFOAJIIAL_Remaining > 0)
				{
					PMDCIJMMNGK_GachaTicket.EJAKHFONNGN tkt = LKMHPJKIFDN.GKMAHADAAFI_GachaTicket.AAJILEFHFGC(d.PPFNGGCBJKC_Id);
					if(tkt != null && (tkt.PPFNGGCBJKC_Id < 200 || tkt.PPFNGGCBJKC_Id > 299))
					{
						long t = d.DJJENNPDPCM_ExpireAt;
						int itemId = EKLNMHFCAOI.GJEEGMCBGGM_GetItemFullId(EKLNMHFCAOI.FKGCBLHOOCL_Category.OBHECJMAEIO_GachaTicket, tkt.PPFNGGCBJKC_Id);
						string s = string.Format(DPOGLCNOBCI, EKLNMHFCAOI.INCKKODFJAP_GetItemName(itemId));
						for(int i = 0; i < JKFIHOHONHD.Count; i++)
						{
							long c = LHGGKIELMAA(t, JKFIHOHONHD[i]);
							if(JPFDCIFKBML(c) && t - JHNMKKNEENE >= 5 && JHNMKKNEENE < c)
							{
								KGCCNEBMHMM.LKCPCCANJFB_SendNotif(EAPDJLPDHEJ.BCFFEECIMJG, c, IIOMHMKENDF * 100 + JKFIHOHONHD[i] + 100000, GBBMOEGDGEM, s, 102, "png");
							}
						}
					}
				}
			}
		}
	}

	// // RVA: 0xFBC3AC Offset: 0xFBC3AC VA: 0xFBC3AC
	public long LHGGKIELMAA(long KFDHHOFENEN, int EJJDPAHKALO)
	{
		return KFDHHOFENEN - EJJDPAHKALO * 86400;
	}

	// // RVA: 0xFB88AC Offset: 0xFB88AC VA: 0xFB88AC
	public void OPODBGPJDCJ_SetComebackNotif()
    {
		if(!AppEnv.IsCBT() && KGCCNEBMHMM != null)
		{
			if (CIOECGOMILE.HHCJCDFCLOB != null && CIOECGOMILE.HHCJCDFCLOB.LNAHEIEIBOI_Initialized)
			{
				if(GameManager.Instance.localSave.EPJOACOONAC_GetSave().BOJCCICAHJK_Notification.ILNIHDCCOEO_EventReceive == 0)
				{
					HBLOOGBLKKD_CancelComebackNotif();
				}
				else
				{
					int divaId = GameManager.Instance.localSave.EPJOACOONAC_GetSave().CNLJNGLMMHB_Options.BBIOMNCILMC_HomeDivaId;
					if (divaId == 0)
					{
						divaId = CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave.MLAFAACKKBG_Unit.FJDDNKGHPHN_GetDefault().FDBOPFEOENF_MainDivas[0].DIPKCALNIII_Id;
						if (divaId == 0)
							divaId = 1;
					}
					if(MessageManager.Instance.IsExistBank("common"))
					{
						MessageBank bk = MessageManager.Instance.GetBank("common");
						DateTime date = Utility.GetLocalDateTime(NKGJPJPHLIF.HHCJCDFCLOB.IBLPICFDGOF_ServerRequester.FJDBNGEPKHL.KMEFBNBFJHI_GetServerTime());
						long t = Utility.GetTargetUnixTime(date.Year, date.Month, date.Day, 0, 0, 0);
						long add = NKGJPJPHLIF.HHCJCDFCLOB.IBLPICFDGOF_ServerRequester.FJDBNGEPKHL.KMEFBNBFJHI_GetServerTime() + 30;
						if (!FKOBPENIMGM)
							add = 734400;
						if (JPFDCIFKBML(t + add))
						{
							KGCCNEBMHMM.LKCPCCANJFB_SendNotif(EAPDJLPDHEJ.KOGBMDOONFA, t + add, 2, bk.GetMessageByLabel("notify_comback_title"), bk.GetMessageByLabel("notify_comback_" + divaId.ToString("D2")), divaId, "png");
						}
					}
				}
			}
		}
    }

	// // RVA: 0xFB8EF0 Offset: 0xFB8EF0 VA: 0xFB8EF0
	public void PNAOEAFNNFA()
	{
		if(!AppEnv.IsCBT() && KGCCNEBMHMM != null)
		{
			if(CIOECGOMILE.HHCJCDFCLOB != null && CIOECGOMILE.HHCJCDFCLOB.LNAHEIEIBOI_Initialized)
			{
				if(GameManager.Instance.localSave.EPJOACOONAC_GetSave().BOJCCICAHJK_Notification.ILNIHDCCOEO_EventReceive == 0)
				{
					OJCABHGPCPK();
				}
				else
				{
					if(MessageManager.Instance.IsExistBank("common"))
					{
						MessageBank bk = MessageManager.Instance.GetBank("common");
						OJCABHGPCPK();
						long t = NKGJPJPHLIF.HHCJCDFCLOB.IBLPICFDGOF_ServerRequester.FJDBNGEPKHL.KMEFBNBFJHI_GetServerTime();
						DateTime date = Utility.GetLocalDateTime(t);
						long t2 = Utility.GetTargetUnixTime(date.Year, date.Month, date.Day, 0, 0, 0);
						long add = t + 40;
						if(!FKOBPENIMGM)
							add = 2548800;
						if(JPFDCIFKBML(t2 + add))
						{
							if((IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.GDEKCOOBLMA_System.KMDDIEJBNPO_CombackPushDisable & 1) == 0)
							{
								KGCCNEBMHMM.LKCPCCANJFB_SendNotif(EAPDJLPDHEJ.KOGBMDOONFA, t2 + add, 5, bk.GetMessageByLabel("notify_comback_title_2"), bk.GetMessageByLabel("notify_comback_text_2"), 103, "png");
							}
						}
					}
				}
			}
		}
	}

	// // RVA: 0xFBC4E8 Offset: 0xFBC4E8 VA: 0xFBC4E8
	public bool HKMEADILMGB(long PEJIPAFKHKM, int LJNAKDMILMC, string LJGOOOMOMMA, int EAHPLCJMPHD)
	{
		if(KGCCNEBMHMM != null)
		{
			KGCCNEBMHMM.JCHLONCMPAJ_CancelNotif(LJNAKDMILMC);
			if(GameManager.Instance.localSave.EPJOACOONAC_GetSave().BOJCCICAHJK_Notification.NDOEPNGHGPF_SnsReceive != 0 && JPFDCIFKBML(PEJIPAFKHKM))
			{
				KGCCNEBMHMM.LKCPCCANJFB_SendNotif(EAPDJLPDHEJ.MGJPMHFCHBD, PEJIPAFKHKM, LJNAKDMILMC, JpStringLiterals.StringLiteral_10294, LJGOOOMOMMA, 101, "png");
				return true;
			}
		}
		return false;
	}

	// // RVA: 0xFBC6DC Offset: 0xFBC6DC VA: 0xFBC6DC
	public bool COGJLOMPOKK(int HMFFHLPNMPH, int ABILEHIAMOO)
	{
		if(KGCCNEBMHMM != null)
		{
			if(GameManager.Instance.localSave.EPJOACOONAC_GetSave().BOJCCICAHJK_Notification.ILNIHDCCOEO_EventReceive != 0)
			{
				long t = Utility.GetCurrentUnixTime();
				if(ABILEHIAMOO < 0)
				{
					t -= ABILEHIAMOO * 3600;
				}
				else
				{
					DateTime date = Utility.GetLocalDateTime(t);
					t = Utility.GetTargetUnixTime(date.Year, date.Month, date.Day, 0, 0, 0);
					t += ABILEHIAMOO * 3600 + 86400;
				}
				if(JPFDCIFKBML(t))
				{
					MessageBank bk = MessageManager.Instance.GetBank("menu");
					if(HMFFHLPNMPH == 1)
					{
						string title = bk.GetMessageByLabel("push_notify_lb_title");
						if(title.Contains("!not exist"))
							title = JpStringLiterals.StringLiteral_10298;
						string msg = bk.GetMessageByLabel("push_notify_lb_msg_01");
						if(msg.Contains("!not exist"))
							msg = JpStringLiterals.StringLiteral_10299;
						KGCCNEBMHMM.LKCPCCANJFB_SendNotif(EAPDJLPDHEJ.KOGBMDOONFA, t, 3, title, msg, 103, "png");
						return true;
					}
				}
			}
		}
		return false;
	}

	// // RVA: 0xFBCB30 Offset: 0xFBCB30 VA: 0xFBCB30
	public void JOADGPOBFMC()
	{
		if(KGCCNEBMHMM == null)
			return;
		KGCCNEBMHMM.JCHLONCMPAJ_CancelNotif(3);
	}

	// // RVA: 0xFBCB48 Offset: 0xFBCB48 VA: 0xFBCB48
	public void NNGHCGKIIHM_SetStaminaLotNotif(bool DDGFCOPPBBN = false)
	{
		if(KGCCNEBMHMM != null)
		{
			if(GameManager.Instance.localSave.EPJOACOONAC_GetSave().BOJCCICAHJK_Notification.ILNIHDCCOEO_EventReceive != 0)
			{
				if(CIOECGOMILE.HHCJCDFCLOB.LNAHEIEIBOI_Initialized)
				{
					long time;
					if (DDGFCOPPBBN)
					{
						time = NKGJPJPHLIF.HHCJCDFCLOB.IBLPICFDGOF_ServerRequester.FJDBNGEPKHL.KMEFBNBFJHI_GetServerTime();
					}
					else
					{
						if (CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave.KCCLEHLLOFG_Common.MNLAJEDKLCI_StamineLotTime == 0)
							return;
						time = CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave.KCCLEHLLOFG_Common.MNLAJEDKLCI_StamineLotTime;
					}
					int debut_push_time_offset = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.GDEKCOOBLMA_System.LPJLEHAJADA("debut_push_time_offset", 60);
					DateTime date = Utility.GetLocalDateTime(time);
					long time2 = Utility.GetTargetUnixTime(date.Year, date.Month, date.Day, 0, 0, 0);
					time2 += debut_push_time_offset * 3600;
					long time3 = Utility.GetCurrentUnixTime();
					if(time2 >= time3 && JPFDCIFKBML(time2))
					{
						int idx = EJHPIMANJFP.HHCJCDFCLOB.MHKCPJDNJKI.FindIndex((LGDNAJACFHI GHPLINIACBB) =>
						{
							//0xFBDD4C
							return GHPLINIACBB.JLGHMCBLENL_IsBeginner;
						});
						if(idx < 0 && DDGFCOPPBBN)
						{
							MessageBank bk = MessageManager.Instance.GetBank("menu");
							string str = bk.GetMessageByLabel("push_notify_debut_vc_title");
							string str2 = bk.GetMessageByLabel("push_notify_debut_vc_msg_01");
							if (str.Contains("!not exist"))
								str = JpStringLiterals.StringLiteral_10303;
							if (str2.Contains("!not exist"))
								str2 = JpStringLiterals.StringLiteral_10304;
							Debug.Log("SendDebutSetMessage targetUnixTime=" + time2);
							KGCCNEBMHMM.LKCPCCANJFB_SendNotif(EAPDJLPDHEJ.KOGBMDOONFA, time2, 4, str, str2, 103, "png");
						}
					}
				}
			}
		}
	}

	// // RVA: 0xFBD33C Offset: 0xFBD33C VA: 0xFBD33C
	public void KCKLPAEILNH_CancelStaminaLotNotif()
	{
		if (KGCCNEBMHMM == null)
			return;
		KGCCNEBMHMM.JCHLONCMPAJ_CancelNotif(4);
	}

	// // RVA: 0xFB8374 Offset: 0xFB8374 VA: 0xFB8374
	public void PAIHLJKFMNL_SetVOPNotif()
	{
		if(KGCCNEBMHMM != null)
		{
			if(GameManager.Instance.localSave.EPJOACOONAC_GetSave().BOJCCICAHJK_Notification.JAFLKPEEGIM_OfferReceive != 0 && KDHGBOOECKC.HHCJCDFCLOB != null)
			{
				int a = KDHGBOOECKC.HHCJCDFCLOB.JGFHJPGJJHP();
				if(a > 0)
				{
					if(CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave != null && CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave.DAEJHMCMFJD_Offer != null)
					{
                        List<OCMJNBIFJNM_Offer.JPOHOLBBFGP> l = CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave.DAEJHMCMFJD_Offer.FOFLMHELILC;
						long t = NKGJPJPHLIF.HHCJCDFCLOB.IBLPICFDGOF_ServerRequester.FJDBNGEPKHL.KMEFBNBFJHI_GetServerTime();
						long c = Utility.GetCurrentUnixTime();
						for(int i = 0; i < a; i++)
						{
							int a2 = i + 1;
							OCMJNBIFJNM_Offer.JPOHOLBBFGP offer = l.Find((OCMJNBIFJNM_Offer.JPOHOLBBFGP JPAEDJJFFOI) =>
							{
								//0xFBDE38
								if(JPAEDJJFFOI.EALOBDHOCHP_Stat == 2)
									return JPAEDJJFFOI.OIOECMEEFKJ_VFp == a2;
								return false;
							});
							if(offer != null)
							{
								if(offer.NCDHKKCCGOD_Edt >= t)
								{
									if(offer.NCDHKKCCGOD_Edt - t > 4)
									{
										if(!JPFDCIFKBML(c + (offer.NCDHKKCCGOD_Edt - t)))
											return;
										KGCCNEBMHMM.LKCPCCANJFB_SendNotif(EAPDJLPDHEJ.PFHAPPEDLGC, c + (offer.NCDHKKCCGOD_Edt - t), 30000 + i, KDHGBOOECKC.HHCJCDFCLOB.IJEFGJHHELK(), KDHGBOOECKC.HHCJCDFCLOB.GOIOHEOGOFK(i + 1), 5, "png");
									}
								}
							}
						}
                    }
				}
			}
		}
	}

	// // RVA: 0xFB8838 Offset: 0xFB8838 VA: 0xFB8838
	public void APNOKHOAMCD_CancelVopNotif()
	{
		if(KGCCNEBMHMM != null && KDHGBOOECKC.HHCJCDFCLOB != null)
		{
			int a = KDHGBOOECKC.HHCJCDFCLOB.JGFHJPGJJHP();
			if(a < 1)
				return;
			for(int i = 0; a != 0; i++, a--)
			{
				KGCCNEBMHMM.JCHLONCMPAJ_CancelNotif(30000 + i);
			}
		}
	}

	// // RVA: 0xFBD35C Offset: 0xFBD35C VA: 0xFBD35C
	public void GCKBFMOMFCG_SetDecoNotif(NDBFKHKMMCE_DecoItem.ANMODBDBNPK.BIKFCCKCHHC NKCAKHIJEHF, long PEJIPAFKHKM, string ADCMNODJBGJ, string LJGOOOMOMMA, int EAHPLCJMPHD)
	{
		if(KGCCNEBMHMM != null)
		{
			if(NKCAKHIJEHF > 0 && NKCAKHIJEHF <= NDBFKHKMMCE_DecoItem.ANMODBDBNPK.BIKFCCKCHHC.JJNIMNEJPOF_3 && 
				GameManager.Instance.localSave.EPJOACOONAC_GetSave().BOJCCICAHJK_Notification.PIPOIELPKBP_DecoReceive != 0 && 
				JPFDCIFKBML(PEJIPAFKHKM))
			{
				KGCCNEBMHMM.LKCPCCANJFB_SendNotif(EAPDJLPDHEJ.BGCAPDNMPOK, PEJIPAFKHKM, (int)NKCAKHIJEHF + 40000, ADCMNODJBGJ, LJGOOOMOMMA, EAHPLCJMPHD, "png");
			}
		}
	}

	// // RVA: 0xFBD53C Offset: 0xFBD53C VA: 0xFBD53C
	public void NINPDKEKNEG()
	{
		if (KGCCNEBMHMM == null)
			return;
		for(int i = 0; i < 2; i++)
		{
			if (KGCCNEBMHMM != null)
				KGCCNEBMHMM.JCHLONCMPAJ_CancelNotif(i + 40001);
		}
	}

	// // RVA: 0xFBD588 Offset: 0xFBD588 VA: 0xFBD588
	public void NINPDKEKNEG(NDBFKHKMMCE_DecoItem.ANMODBDBNPK.BIKFCCKCHHC NKCAKHIJEHF)
	{
		if(KGCCNEBMHMM == null)
			return;
		KGCCNEBMHMM.JCHLONCMPAJ_CancelNotif((int)NKCAKHIJEHF + 40000);
	}

	// // RVA: 0xFBD5A4 Offset: 0xFBD5A4 VA: 0xFBD5A4
	// public bool HJHKBNNEKMI(long PEJIPAFKHKM, int LJNAKDMILMC, string LJGOOOMOMMA, int EAHPLCJMPHD) { }

	// // RVA: 0xFB79B8 Offset: 0xFB79B8 VA: 0xFB79B8
	public void FOPAJBDEFCP_CancelStaminaNotif()
	{
		if(KGCCNEBMHMM != null)
			KGCCNEBMHMM.JCHLONCMPAJ_CancelNotif(1);
	}

	// // RVA: 0xFB79D0 Offset: 0xFB79D0 VA: 0xFB79D0
	public void PELOGBHNHIL_CancelAPNotif()
	{
		if(KGCCNEBMHMM != null)
			KGCCNEBMHMM.JCHLONCMPAJ_CancelNotif(6);
	}

	// // RVA: 0xFBC4B8 Offset: 0xFBC4B8 VA: 0xFBC4B8
	public void HBLOOGBLKKD_CancelComebackNotif()
	{
		if(KGCCNEBMHMM != null)
			KGCCNEBMHMM.JCHLONCMPAJ_CancelNotif(2);
	}

	// // RVA: 0xFBC4D0 Offset: 0xFBC4D0 VA: 0xFBC4D0
	public void OJCABHGPCPK()
	{
		if(KGCCNEBMHMM != null)
			KGCCNEBMHMM.JCHLONCMPAJ_CancelNotif(5);
	}

	// // RVA: 0xFB78F4 Offset: 0xFB78F4 VA: 0xFB78F4
	public bool BBDNBCHOFIP()
	{
		if(KGCCNEBMHMM != null)
		{
			Debug.Log("IsNotifyEnabled");
			return KGCCNEBMHMM.PLIGGNOHLJE();
		}
		return false;
	}

	// // RVA: 0xFBD734 Offset: 0xFBD734 VA: 0xFBD734
	// public void LCICDJDNPNA() { }

	// // RVA: 0xFBD7F0 Offset: 0xFBD7F0 VA: 0xFBD7F0
	// public void BJOFINDMDJH() { }

	// // RVA: 0xFBD9F8 Offset: 0xFBD9F8 VA: 0xFBD9F8
	// public void HHEDACCFPGM() { }

	// // RVA: 0xFBA2B8 Offset: 0xFBA2B8 VA: 0xFBA2B8
	public bool JPFDCIFKBML(long EOLFJGMAJAB)
	{
		DateTime date = Utility.GetLocalDateTime(EOLFJGMAJAB);
		return GameManager.Instance.localSave.EPJOACOONAC_GetSave().BOJCCICAHJK_Notification.OCKFGNLLBFA(AKCBIJHIOGH[date.Hour]);
	}

	// // RVA: 0xFBDA10 Offset: 0xFBDA10 VA: 0xFBDA10
	public void KOFIBEMHONI()
	{
		if(KGCCNEBMHMM !=null)
		{
			KGCCNEBMHMM.EMLBCNAHHLD();
			MOEDFPOIJDM = true;
		}
	}
}
