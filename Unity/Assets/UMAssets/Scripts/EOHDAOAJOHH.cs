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

	// public static int OOLEIEJLHGJ { get; } // KCGOAPBNDPP_bgs 0xFB756C
	public static EOHDAOAJOHH HHCJCDFCLOB_Instance { get; private set; } // 0x8 LGMPACEDIJF NKACBOEHELJ OKPMHKNCNAL_bgs
	public bool BOCLJJMAHHB { get; private set; } // 0xC DMHGANHPELM_bgs  BNHJHGPMIBC_bgs MOPEPMIODKP_bgs
	public bool NCAJHMNKJJD_EnableStaminaNotif { get; private set; } // 0xD HBEKEPBPKAD_bgs MABKOJMFDCI_bgs NCMHNDFLDOC_bgs
	public bool MOEDFPOIJDM { get; private set; } // 0xE KNECAFLJOBG_bgs GNMEIHEKNDI_bgs KNFPFPAKEJB_bgs

	// // RVA: 0xFB76C4 Offset: 0xFB76C4 VA: 0xFB76C4
	public void IJBGPAENLJA_OnAwake(MonoBehaviour _DANMJLOBLIE_mb)
	{
		HHCJCDFCLOB_Instance = this;
		BOCLJJMAHHB = false;
		NCAJHMNKJJD_EnableStaminaNotif = false;
	}

	// // RVA: 0xFB774C Offset: 0xFB774C VA: 0xFB774C
	public void OJKIKODJJCD()
	{
		KGCCNEBMHMM = new OJIHOFLJOMK();
		KGCCNEBMHMM.KHEKNNFCAOI_Init();
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
	// public void HJHKBNNEKMI(long _KPBJHHHMOJE_Time) { }

	// // RVA: 0xFB7C8C Offset: 0xFB7C8C VA: 0xFB7C8C
	public void APHODAFLJFB_SetStaminaNotif()
	{
		if(KGCCNEBMHMM != null)
		{
			if(GameManager.Instance.localSave.EPJOACOONAC_GetSave().BOJCCICAHJK_Notification.KNOLBNCEHFB_StaminaReceive != 0)
			{
				if(CIOECGOMILE_NetPlayerDataManager.HHCJCDFCLOB_Instance != null && CIOECGOMILE_NetPlayerDataManager.HHCJCDFCLOB_Instance.LNAHEIEIBOI_Initialized && CIOECGOMILE_NetPlayerDataManager.HHCJCDFCLOB_Instance.BPLOEAHOPFI_stamina != null)
				{
					long t = CIOECGOMILE_NetPlayerDataManager.HHCJCDFCLOB_Instance.BPLOEAHOPFI_stamina.LEHHIGOOIJJ();
					if(t != 0)
					{
						long c = Utility.GetCurrentUnixTime();
						if(t >= c && t - c >= 5 && JPFDCIFKBML(t))
						{
							KGCCNEBMHMM.LKCPCCANJFB_SendNotif(EAPDJLPDHEJ.HHEEFGIDMPC_Energy, t, 1, OBAFHIJBOJP[0], OBAFHIJBOJP[2], 102, "png");
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
				PKNOKJNLPOE_NetEventRaidController p = JEPBIIJDGEF_NetEventManager.HHCJCDFCLOB_Instance.OEGDCBLNNFF(OHCAABOMEOF.KGOGMKMBCPP_EventType.CADKONMJEDA_11_EventRaid, KGCNCBOKCBA.GNENJEHKMHD_EventStatus.BCKENOKGLIJ_9_ResultRewardreceived) as PKNOKJNLPOE_NetEventRaidController;
				if(p != null)
				{
					if(p.DBNGGBFOAPG())
					{
						long a = p.EIEDIDECECD();
						if(a != 0)
						{
							long t = Utility.GetCurrentUnixTime();
							if(a >= t && (a - t) >= 5 && JPFDCIFKBML(a))
							{
								KGCCNEBMHMM.LKCPCCANJFB_SendNotif(EAPDJLPDHEJ.JIMJHIDEHNM_ApCounter, a, 6, p.MAICAKMIBEM("ap_notification_title", JpStringLiterals.StringLiteral_10282), p.MAICAKMIBEM("ap_notification_main", JpStringLiterals.StringLiteral_10284), 102, "png");
							}
						}
					}
				}
			}
		}
	}

	// // RVA: 0xFB94D0 Offset: 0xFB94D0 VA: 0xFB94D0
	public void HGKPAOGOMJJ()
	{
		if(KGCCNEBMHMM != null)
		{
			if(CIOECGOMILE_NetPlayerDataManager.HHCJCDFCLOB_Instance != null)
			{
				if(IMMAOANGPNK_NetMasterDataManager.HHCJCDFCLOB_Instance != null)
				{
					if(CIOECGOMILE_NetPlayerDataManager.HHCJCDFCLOB_Instance.LNAHEIEIBOI_Initialized)
					{
						if(IMMAOANGPNK_NetMasterDataManager.HHCJCDFCLOB_Instance.NKEBMCIMJND_Database != null)
						{
							if(CIOECGOMILE_NetPlayerDataManager.HHCJCDFCLOB_Instance.AHEFHIMGIBI_PlayerData != null)
							{
								if(GameManager.Instance.localSave.EPJOACOONAC_GetSave().BOJCCICAHJK_Notification.OKGKFFLMFKH_LimitedReceive != 0 && 
									IMMAOANGPNK_NetMasterDataManager.HHCJCDFCLOB_Instance.NKEBMCIMJND_Database.GDEKCOOBLMA_System != null)
								{
									string push_limited_item_send_day = IMMAOANGPNK_NetMasterDataManager.HHCJCDFCLOB_Instance.NKEBMCIMJND_Database.GDEKCOOBLMA_System.EFEGBHACJAL_GetStringParam("push_limited_item_send_day", "");
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
										long t = NKGJPJPHLIF_SakashoManager.HHCJCDFCLOB_Instance.IBLPICFDGOF_ServerRequester.FJDBNGEPKHL_Time.KMEFBNBFJHI_GetServerTime();
										MessageBank bk = MessageManager.Instance.GetBank("menu");
										PDAHBODAGFO(IMMAOANGPNK_NetMasterDataManager.HHCJCDFCLOB_Instance.NKEBMCIMJND_Database, CIOECGOMILE_NetPlayerDataManager.HHCJCDFCLOB_Instance.AHEFHIMGIBI_PlayerData, l, t, bk.GetMessageByLabel("notification_rareup_star_limit_title"), bk.GetMessageByLabel("notification_rareup_star_limit_text"), false);
										MGEKDBAHOBM(IMMAOANGPNK_NetMasterDataManager.HHCJCDFCLOB_Instance.NKEBMCIMJND_Database, CIOECGOMILE_NetPlayerDataManager.HHCJCDFCLOB_Instance.AHEFHIMGIBI_PlayerData, l, t, bk.GetMessageByLabel("notification_rareup_star_limit_title"), bk.GetMessageByLabel("notification_rareup_star_limit_text"), false);
										CFOKLGOIDAL(IMMAOANGPNK_NetMasterDataManager.HHCJCDFCLOB_Instance.NKEBMCIMJND_Database, CIOECGOMILE_NetPlayerDataManager.HHCJCDFCLOB_Instance.AHEFHIMGIBI_PlayerData, l, t, bk.GetMessageByLabel("notification_rareup_star_limit_title"), bk.GetMessageByLabel("notification_rareup_star_limit_text"), false);
										CJJJNACJGAG(IMMAOANGPNK_NetMasterDataManager.HHCJCDFCLOB_Instance.NKEBMCIMJND_Database, CIOECGOMILE_NetPlayerDataManager.HHCJCDFCLOB_Instance.AHEFHIMGIBI_PlayerData, l, t, bk.GetMessageByLabel("notification_rareup_star_limit_title"), bk.GetMessageByLabel("notification_rareup_star_limit_text"), false);
										PBCMCHIPKID(IMMAOANGPNK_NetMasterDataManager.HHCJCDFCLOB_Instance.NKEBMCIMJND_Database, CIOECGOMILE_NetPlayerDataManager.HHCJCDFCLOB_Instance.AHEFHIMGIBI_PlayerData, l, t, bk.GetMessageByLabel("notification_rareup_star_limit_title"), bk.GetMessageByLabel("notification_rareup_star_limit_text"), false);
										GONPMCPCJKE(IMMAOANGPNK_NetMasterDataManager.HHCJCDFCLOB_Instance.NKEBMCIMJND_Database, CIOECGOMILE_NetPlayerDataManager.HHCJCDFCLOB_Instance.AHEFHIMGIBI_PlayerData, l, t, bk.GetMessageByLabel("notification_rareup_star_limit_title"), bk.GetMessageByLabel("notification_rareup_star_limit_text"), false);
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
			if(IMMAOANGPNK_NetMasterDataManager.HHCJCDFCLOB_Instance != null)
			{
				if(IMMAOANGPNK_NetMasterDataManager.HHCJCDFCLOB_Instance.NKEBMCIMJND_Database != null && IMMAOANGPNK_NetMasterDataManager.HHCJCDFCLOB_Instance.NKEBMCIMJND_Database.GDEKCOOBLMA_System != null)
				{
					string push_limited_item_send_day = IMMAOANGPNK_NetMasterDataManager.HHCJCDFCLOB_Instance.NKEBMCIMJND_Database.GDEKCOOBLMA_System.EFEGBHACJAL_GetStringParam("push_limited_item_send_day", "");
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
							KGCCNEBMHMM.JCHLONCMPAJ_Clear(l[i] + 50000);
							KGCCNEBMHMM.JCHLONCMPAJ_Clear(l[i] + 60000);
							KGCCNEBMHMM.JCHLONCMPAJ_Clear(l[i] + 80000);
							KGCCNEBMHMM.JCHLONCMPAJ_Clear(l[i] + 70000);
							KGCCNEBMHMM.JCHLONCMPAJ_Clear(l[i] + 90000);
							GIJMLPJPFHB_CancelTicketNotif(IMMAOANGPNK_NetMasterDataManager.HHCJCDFCLOB_Instance.NKEBMCIMJND_Database, l[i]);
						}
					}
				}
			}
		}
	}

	// // RVA: 0xFBC2B8 Offset: 0xFBC2B8 VA: 0xFBC2B8
	public void GIJMLPJPFHB_CancelTicketNotif(OKGLGHCBCJP_Database _LKMHPJKIFDN_md, int IOBIPABJHEG)
	{
		int a = IOBIPABJHEG + 100000;
		for(int i = 0; i < _LKMHPJKIFDN_md.GKMAHADAAFI_GachaTicket.DHIACJMOEBH_vcIdsList.Count; i++)
		{
			KGCCNEBMHMM.JCHLONCMPAJ_Clear(a);
			a += 100;
		}
	}

	// // RVA: 0xFBA4A0 Offset: 0xFBA4A0 VA: 0xFBA4A0
	public void PDAHBODAGFO(OKGLGHCBCJP_Database _LKMHPJKIFDN_md, BBHNACPENDM_ServerSaveData _LDEGEHAEALK_ServerData, List<int> JKFIHOHONHD, long _JHNMKKNEENE_Time, string GBBMOEGDGEM, string DPOGLCNOBCI, bool OPEBKHLLMPH/* = false*/)
	{
		if(_LDEGEHAEALK_ServerData.DPNKPPBEAGJ_RareUpItem.LDLCGGACHGA(_JHNMKKNEENE_Time) > 0)
		{
			long c = _LDEGEHAEALK_ServerData.DPNKPPBEAGJ_RareUpItem.JCJKKMECCFI(_JHNMKKNEENE_Time);
			int id = _LKMHPJKIFDN_md.GDEKCOOBLMA_System.LPJLEHAJADA_GetIntParam("rarity_up_item_id", 230001);
			string name = EKLNMHFCAOI_ItemManager.INCKKODFJAP_GetItemName(id);
			string s = string.Format(DPOGLCNOBCI, name);
			for(int i = 0; i < JKFIHOHONHD.Count; i++)
			{
				long t = LHGGKIELMAA(c, JKFIHOHONHD[i]);
				if(JPFDCIFKBML(t) && c - _JHNMKKNEENE_Time >= 5 && _JHNMKKNEENE_Time < t)
				{
					KGCCNEBMHMM.LKCPCCANJFB_SendNotif(EAPDJLPDHEJ.BCFFEECIMJG_LimitedItem, t, JKFIHOHONHD[i] + 50000, GBBMOEGDGEM, s, 102, "png");
				}
			}
		}
	}

	// // RVA: 0xFBA830 Offset: 0xFBA830 VA: 0xFBA830
	public void MGEKDBAHOBM(OKGLGHCBCJP_Database _LKMHPJKIFDN_md, BBHNACPENDM_ServerSaveData _LDEGEHAEALK_ServerData, List<int> JKFIHOHONHD, long _JHNMKKNEENE_Time, string GBBMOEGDGEM, string DPOGLCNOBCI, bool OPEBKHLLMPH/* = false*/)
	{
		List<AODFBGCCBPE_ViewShopData> l = AODFBGCCBPE_ViewShopData.FKDIMODKKJD_GetList(false);
		if(l != null)
		{
			l = l.FindAll((AODFBGCCBPE_ViewShopData _GHPLINIACBB_x) =>
			{
				//0xFBDCF0
				return _GHPLINIACBB_x.INDDJNMPONH_type == AODFBGCCBPE_ViewShopData.NJMPLEENNPO_ShopType.AOMIBCNBBOD_1_Vc;
			});
			if(l.Count > 0)
			{
				long t = l[0].GJFPFFBAKGK_CloseAt;
				int a = 0;
				for(int i = 0; i < l.Count; i++)
				{
					if(l[i].GJFPFFBAKGK_CloseAt < t)
					{
						t = l[i].GJFPFFBAKGK_CloseAt;
						a = i;
					}
				}
				HHJHIFJIKAC_BonusVc.MNGJPJBCMBH vc = _LKMHPJKIFDN_md.NBKNAAPBFFL_BonusVc.CDENCMNHNGA_table[l[a].JPGALGPNJAI_VcId - 1];
				int itemId = EKLNMHFCAOI_ItemManager.GJEEGMCBGGM_GetItemFullId(EKLNMHFCAOI_ItemManager.FKGCBLHOOCL_Category.IBBDMIFICCN_BonusVC, vc.PPFNGGCBJKC_id);
				string s = string.Format(DPOGLCNOBCI, EKLNMHFCAOI_ItemManager.INCKKODFJAP_GetItemName(itemId));
				int a2 = CIOECGOMILE_NetPlayerDataManager.HHCJCDFCLOB_Instance.NOJDLFKKMDD_GetCurrencyTotal(l[a].JPGALGPNJAI_VcId);
				if (a2 > 0)
				{
					for(int i = 0; i < JKFIHOHONHD.Count; i++)
					{
						long c = LHGGKIELMAA(l[a].GJFPFFBAKGK_CloseAt, JKFIHOHONHD[i]);
						if(JPFDCIFKBML(c) && l[a].GJFPFFBAKGK_CloseAt - _JHNMKKNEENE_Time >= 5 && _JHNMKKNEENE_Time < c)
						{
							KGCCNEBMHMM.LKCPCCANJFB_SendNotif(EAPDJLPDHEJ.BCFFEECIMJG_LimitedItem, c, JKFIHOHONHD[i] + 70000, GBBMOEGDGEM, s, 102, "png");
						}
					}
				}
			}
		}
	}

	// // RVA: 0xFBAEA0 Offset: 0xFBAEA0 VA: 0xFBAEA0
	public void CJJJNACJGAG(OKGLGHCBCJP_Database _LKMHPJKIFDN_md, BBHNACPENDM_ServerSaveData _LDEGEHAEALK_ServerData, List<int> JKFIHOHONHD, long _JHNMKKNEENE_Time, string GBBMOEGDGEM, string DPOGLCNOBCI, bool OPEBKHLLMPH/* = false*/)
	{
		List<AODFBGCCBPE_ViewShopData> l = AODFBGCCBPE_ViewShopData.FKDIMODKKJD_GetList(false);
		if(l != null)
		{
			l = l.FindAll((AODFBGCCBPE_ViewShopData _GHPLINIACBB_x) =>
			{
				//0xFBDD1C
				return _GHPLINIACBB_x.INDDJNMPONH_type == AODFBGCCBPE_ViewShopData.NJMPLEENNPO_ShopType.BDMFENCIPEB_2_Medal;
			});
			if(l.Count > 0)
			{
				long t = l[0].GJFPFFBAKGK_CloseAt;
				int a = 0;
				for(int i = 0; i < l.Count; i++)
				{
					if(l[i].GJFPFFBAKGK_CloseAt < t)
					{
						t = l[i].GJFPFFBAKGK_CloseAt;
						a = i;
					}
				}
				EGOLBAPFHHD_Common.GLBBNDKGEOC mdl = CIOECGOMILE_NetPlayerDataManager.HHCJCDFCLOB_Instance.AHEFHIMGIBI_PlayerData.KCCLEHLLOFG_Common.MHKJEBNOPIM_Medal[l[a].IBAKPKKEDJM_month];
				int itemId = EKLNMHFCAOI_ItemManager.GJEEGMCBGGM_GetItemFullId(EKLNMHFCAOI_ItemManager.FKGCBLHOOCL_Category.IBBDMIFICCN_BonusVC, mdl.PPFNGGCBJKC_id);
				string s = string.Format(DPOGLCNOBCI, EKLNMHFCAOI_ItemManager.INCKKODFJAP_GetItemName(itemId));
				int a2 = EKLNMHFCAOI_ItemManager.ALHCGDMEMID_GetNumItems(_LKMHPJKIFDN_md, _LDEGEHAEALK_ServerData, EKLNMHFCAOI_ItemManager.FKGCBLHOOCL_Category.ADCAAALBAIF_Medal, l[a].IBAKPKKEDJM_month, null);
				if (a2 > 0)
				{
					for(int i = 0; i < JKFIHOHONHD.Count; i++)
					{
						long c = LHGGKIELMAA(l[a].GJFPFFBAKGK_CloseAt, JKFIHOHONHD[i]);
						if(JPFDCIFKBML(c) && l[a].GJFPFFBAKGK_CloseAt - _JHNMKKNEENE_Time >= 5 && _JHNMKKNEENE_Time < c)
						{
							KGCCNEBMHMM.LKCPCCANJFB_SendNotif(EAPDJLPDHEJ.BCFFEECIMJG_LimitedItem, c, JKFIHOHONHD[i] + 80000, GBBMOEGDGEM, s, 102, "png");
						}
					}
				}
			}
		}
	}

	// // RVA: 0xFBB524 Offset: 0xFBB524 VA: 0xFBB524
	public void CFOKLGOIDAL(OKGLGHCBCJP_Database _LKMHPJKIFDN_md, BBHNACPENDM_ServerSaveData _LDEGEHAEALK_ServerData, List<int> JKFIHOHONHD, long _JHNMKKNEENE_Time, string GBBMOEGDGEM, string DPOGLCNOBCI, bool OPEBKHLLMPH/* = false*/)
	{
		int a = _LDEGEHAEALK_ServerData.AFHFIPLOKMN_LimitedItem.HPPKOGKNKMH(1, _JHNMKKNEENE_Time);
		if(a > 0)
		{
			long t = _LDEGEHAEALK_ServerData.AFHFIPLOKMN_LimitedItem.BLKPKBICPKK(1, _JHNMKKNEENE_Time);
			int itemId = EKLNMHFCAOI_ItemManager.GJEEGMCBGGM_GetItemFullId(EKLNMHFCAOI_ItemManager.FKGCBLHOOCL_Category.DLOPEFGOAPD_24_LimitedItem, 1);
			string s = string.Format(DPOGLCNOBCI, EKLNMHFCAOI_ItemManager.INCKKODFJAP_GetItemName(itemId));
			for(int i = 0; i < JKFIHOHONHD.Count; i++)
			{
				long c = LHGGKIELMAA(t, JKFIHOHONHD[i]);
				if(JPFDCIFKBML(c) && t - _JHNMKKNEENE_Time >= 5 && _JHNMKKNEENE_Time < c)
				{
					KGCCNEBMHMM.LKCPCCANJFB_SendNotif(EAPDJLPDHEJ.BCFFEECIMJG_LimitedItem, c, JKFIHOHONHD[i] + 60000, GBBMOEGDGEM, s, 102, "png");
				}
			}
		}
	}

	// // RVA: 0xFBB86C Offset: 0xFBB86C VA: 0xFBB86C
	public void PBCMCHIPKID(OKGLGHCBCJP_Database _LKMHPJKIFDN_md, BBHNACPENDM_ServerSaveData _LDEGEHAEALK_ServerData, List<int> JKFIHOHONHD, long _JHNMKKNEENE_Time, string GBBMOEGDGEM, string DPOGLCNOBCI, bool OPEBKHLLMPH/* = false*/)
	{
		if(JEPBIIJDGEF_NetEventManager.HHCJCDFCLOB_Instance != null)
		{
			CHHECNJBMLA_NetEventBoxGachaController ev = JEPBIIJDGEF_NetEventManager.HHCJCDFCLOB_Instance.JNHHEMLIDGJ() as CHHECNJBMLA_NetEventBoxGachaController;
			if(ev != null)
			{
				if(ev.BEDCLNJIEGF(_JHNMKKNEENE_Time) && ev.BCMFJLFDLND_GetNumUseItemForCurrentBox() > 0 && ev.BAEPGOAMBDK("boxgacha_local_notification_enable", 0) > 0)
				{
					HGFPAFPGIKG h = new HGFPAFPGIKG(ev.PGIIDPEGGPI_EventId);
					for(int i = 0; i < JKFIHOHONHD.Count; i++)
					{
						long t = LHGGKIELMAA(ev.DPJCPDKALGI_RankingEnd, JKFIHOHONHD[i]);
						if(JPFDCIFKBML(t) && ev.DPJCPDKALGI_RankingEnd - _JHNMKKNEENE_Time >= 5 && _JHNMKKNEENE_Time < t)
						{
							KGCCNEBMHMM.LKCPCCANJFB_SendNotif(EAPDJLPDHEJ.BCFFEECIMJG_LimitedItem, t, JKFIHOHONHD[i] + 90000, GBBMOEGDGEM, string.Format(DPOGLCNOBCI, EKLNMHFCAOI_ItemManager.INCKKODFJAP_GetItemName(h.JHNEFBNEAAO)), 102, "png");
						}
					}
				}
			}
		}
	}

	// // RVA: 0xFBBCD4 Offset: 0xFBBCD4 VA: 0xFBBCD4
	public void GONPMCPCJKE(OKGLGHCBCJP_Database _LKMHPJKIFDN_md, BBHNACPENDM_ServerSaveData _LDEGEHAEALK_ServerData, List<int> JKFIHOHONHD, long _JHNMKKNEENE_Time, string GBBMOEGDGEM, string DPOGLCNOBCI, bool OPEBKHLLMPH/* = false*/)
	{
		HPBDNNACBAK_NetGachaProductManager h = NKGJPJPHLIF_SakashoManager.HHCJCDFCLOB_Instance.FPNBCFJHENI;
		if(h != null)
		{
			List<int> PDHNBPOMAEM = _LKMHPJKIFDN_md.GKMAHADAAFI_GachaTicket.DHIACJMOEBH_vcIdsList; // PGFMIBMJBHD
			for(int IIOMHMKENDF = 0; IIOMHMKENDF < PDHNBPOMAEM.Count; IIOMHMKENDF++)
			{
				HPBDNNACBAK_NetGachaProductManager.MBMMGKJBJGD d = h.GGKFCDDFHFP.Find((HPBDNNACBAK_NetGachaProductManager.MBMMGKJBJGD _GHPLINIACBB_x) =>
				{
					//0xFBDD70
					return _GHPLINIACBB_x.PPFNGGCBJKC_id == PDHNBPOMAEM[IIOMHMKENDF];
				});
				if(d != null && d.HNBFOAJIIAL_Count > 0)
				{
					PMDCIJMMNGK_GachaTicket.EJAKHFONNGN tkt = _LKMHPJKIFDN_md.GKMAHADAAFI_GachaTicket.AAJILEFHFGC(d.PPFNGGCBJKC_id);
					if(tkt != null && (tkt.PPFNGGCBJKC_id < 200 || tkt.PPFNGGCBJKC_id > 299))
					{
						long t = d.DJJENNPDPCM_ExpireAt;
						int itemId = EKLNMHFCAOI_ItemManager.GJEEGMCBGGM_GetItemFullId(EKLNMHFCAOI_ItemManager.FKGCBLHOOCL_Category.OBHECJMAEIO_GachaTicket, tkt.PPFNGGCBJKC_id);
						string s = string.Format(DPOGLCNOBCI, EKLNMHFCAOI_ItemManager.INCKKODFJAP_GetItemName(itemId));
						for(int i = 0; i < JKFIHOHONHD.Count; i++)
						{
							long c = LHGGKIELMAA(t, JKFIHOHONHD[i]);
							if(JPFDCIFKBML(c) && t - _JHNMKKNEENE_Time >= 5 && _JHNMKKNEENE_Time < c)
							{
								KGCCNEBMHMM.LKCPCCANJFB_SendNotif(EAPDJLPDHEJ.BCFFEECIMJG_LimitedItem, c, IIOMHMKENDF * 100 + JKFIHOHONHD[i] + 100000, GBBMOEGDGEM, s, 102, "png");
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
			if (CIOECGOMILE_NetPlayerDataManager.HHCJCDFCLOB_Instance != null && CIOECGOMILE_NetPlayerDataManager.HHCJCDFCLOB_Instance.LNAHEIEIBOI_Initialized)
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
						divaId = CIOECGOMILE_NetPlayerDataManager.HHCJCDFCLOB_Instance.AHEFHIMGIBI_PlayerData.MLAFAACKKBG_Unit.FJDDNKGHPHN_GetDefault().FDBOPFEOENF_diva[0].DIPKCALNIII_diva_id;
						if (divaId == 0)
							divaId = 1;
					}
					if(MessageManager.Instance.IsExistBank("common"))
					{
						MessageBank bk = MessageManager.Instance.GetBank("common");
						DateTime date = Utility.GetLocalDateTime(NKGJPJPHLIF_SakashoManager.HHCJCDFCLOB_Instance.IBLPICFDGOF_ServerRequester.FJDBNGEPKHL_Time.KMEFBNBFJHI_GetServerTime());
						long t = Utility.GetTargetUnixTime(date.Year, date.Month, date.Day, 0, 0, 0);
						long add = NKGJPJPHLIF_SakashoManager.HHCJCDFCLOB_Instance.IBLPICFDGOF_ServerRequester.FJDBNGEPKHL_Time.KMEFBNBFJHI_GetServerTime() + 30;
						if (!FKOBPENIMGM)
							add = 734400;
						if (JPFDCIFKBML(t + add))
						{
							KGCCNEBMHMM.LKCPCCANJFB_SendNotif(EAPDJLPDHEJ.KOGBMDOONFA_Info, t + add, 2, bk.GetMessageByLabel("notify_comback_title"), bk.GetMessageByLabel("notify_comback_" + divaId.ToString("D2")), divaId, "png");
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
			if(CIOECGOMILE_NetPlayerDataManager.HHCJCDFCLOB_Instance != null && CIOECGOMILE_NetPlayerDataManager.HHCJCDFCLOB_Instance.LNAHEIEIBOI_Initialized)
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
						long t = NKGJPJPHLIF_SakashoManager.HHCJCDFCLOB_Instance.IBLPICFDGOF_ServerRequester.FJDBNGEPKHL_Time.KMEFBNBFJHI_GetServerTime();
						DateTime date = Utility.GetLocalDateTime(t);
						long t2 = Utility.GetTargetUnixTime(date.Year, date.Month, date.Day, 0, 0, 0);
						long add = t + 40;
						if(!FKOBPENIMGM)
							add = 2548800;
						if(JPFDCIFKBML(t2 + add))
						{
							if((IMMAOANGPNK_NetMasterDataManager.HHCJCDFCLOB_Instance.NKEBMCIMJND_Database.GDEKCOOBLMA_System.KMDDIEJBNPO_CombackPushDisable & 1) == 0)
							{
								KGCCNEBMHMM.LKCPCCANJFB_SendNotif(EAPDJLPDHEJ.KOGBMDOONFA_Info, t2 + add, 5, bk.GetMessageByLabel("notify_comback_title_2"), bk.GetMessageByLabel("notify_comback_text_2"), 103, "png");
							}
						}
					}
				}
			}
		}
	}

	// // RVA: 0xFBC4E8 Offset: 0xFBC4E8 VA: 0xFBC4E8
	public bool HKMEADILMGB(long PEJIPAFKHKM, int _LJNAKDMILMC_key, string _LJGOOOMOMMA_message, int _EAHPLCJMPHD_PId)
	{
		if(KGCCNEBMHMM != null)
		{
			KGCCNEBMHMM.JCHLONCMPAJ_Clear(_LJNAKDMILMC_key);
			if(GameManager.Instance.localSave.EPJOACOONAC_GetSave().BOJCCICAHJK_Notification.NDOEPNGHGPF_SnsReceive != 0 && JPFDCIFKBML(PEJIPAFKHKM))
			{
				KGCCNEBMHMM.LKCPCCANJFB_SendNotif(EAPDJLPDHEJ.MGJPMHFCHBD_Sns, PEJIPAFKHKM, _LJNAKDMILMC_key, JpStringLiterals.StringLiteral_10294, _LJGOOOMOMMA_message, 101, "png");
				return true;
			}
		}
		return false;
	}

	// // RVA: 0xFBC6DC Offset: 0xFBC6DC VA: 0xFBC6DC
	public bool COGJLOMPOKK(int _HMFFHLPNMPH_count, int ABILEHIAMOO)
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
					if(_HMFFHLPNMPH_count == 1)
					{
						string title = bk.GetMessageByLabel("push_notify_lb_title");
						if(title.Contains("!not exist"))
							title = JpStringLiterals.StringLiteral_10298;
						string msg = bk.GetMessageByLabel("push_notify_lb_msg_01");
						if(msg.Contains("!not exist"))
							msg = JpStringLiterals.StringLiteral_10299;
						KGCCNEBMHMM.LKCPCCANJFB_SendNotif(EAPDJLPDHEJ.KOGBMDOONFA_Info, t, 3, title, msg, 103, "png");
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
		KGCCNEBMHMM.JCHLONCMPAJ_Clear(3);
	}

	// // RVA: 0xFBCB48 Offset: 0xFBCB48 VA: 0xFBCB48
	public void NNGHCGKIIHM_SetStaminaLotNotif(bool _DDGFCOPPBBN_test/* = false*/)
	{
		if(KGCCNEBMHMM != null)
		{
			if(GameManager.Instance.localSave.EPJOACOONAC_GetSave().BOJCCICAHJK_Notification.ILNIHDCCOEO_EventReceive != 0)
			{
				if(CIOECGOMILE_NetPlayerDataManager.HHCJCDFCLOB_Instance.LNAHEIEIBOI_Initialized)
				{
					long time;
					if (_DDGFCOPPBBN_test)
					{
						time = NKGJPJPHLIF_SakashoManager.HHCJCDFCLOB_Instance.IBLPICFDGOF_ServerRequester.FJDBNGEPKHL_Time.KMEFBNBFJHI_GetServerTime();
					}
					else
					{
						if (CIOECGOMILE_NetPlayerDataManager.HHCJCDFCLOB_Instance.AHEFHIMGIBI_PlayerData.KCCLEHLLOFG_Common.MNLAJEDKLCI_sta_lot_time == 0)
							return;
						time = CIOECGOMILE_NetPlayerDataManager.HHCJCDFCLOB_Instance.AHEFHIMGIBI_PlayerData.KCCLEHLLOFG_Common.MNLAJEDKLCI_sta_lot_time;
					}
					int debut_push_time_offset = IMMAOANGPNK_NetMasterDataManager.HHCJCDFCLOB_Instance.NKEBMCIMJND_Database.GDEKCOOBLMA_System.LPJLEHAJADA_GetIntParam("debut_push_time_offset", 60);
					DateTime date = Utility.GetLocalDateTime(time);
					long time2 = Utility.GetTargetUnixTime(date.Year, date.Month, date.Day, 0, 0, 0);
					time2 += debut_push_time_offset * 3600;
					long time3 = Utility.GetCurrentUnixTime();
					if(time2 >= time3 && JPFDCIFKBML(time2))
					{
						int idx = EJHPIMANJFP_NetPaidVCProdcutManager.HHCJCDFCLOB_Instance.MHKCPJDNJKI_products.FindIndex((LGDNAJACFHI _GHPLINIACBB_x) =>
						{
							//0xFBDD4C
							return _GHPLINIACBB_x.JLGHMCBLENL_IsBeginner;
						});
						if(idx < 0 && _DDGFCOPPBBN_test)
						{
							MessageBank bk = MessageManager.Instance.GetBank("menu");
							string str = bk.GetMessageByLabel("push_notify_debut_vc_title");
							string str2 = bk.GetMessageByLabel("push_notify_debut_vc_msg_01");
							if (str.Contains("!not exist"))
								str = JpStringLiterals.StringLiteral_10303;
							if (str2.Contains("!not exist"))
								str2 = JpStringLiterals.StringLiteral_10304;
							Debug.Log("SendDebutSetMessage targetUnixTime=" + time2);
							KGCCNEBMHMM.LKCPCCANJFB_SendNotif(EAPDJLPDHEJ.KOGBMDOONFA_Info, time2, 4, str, str2, 103, "png");
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
		KGCCNEBMHMM.JCHLONCMPAJ_Clear(4);
	}

	// // RVA: 0xFB8374 Offset: 0xFB8374 VA: 0xFB8374
	public void PAIHLJKFMNL_SetVOPNotif()
	{
		if(KGCCNEBMHMM != null)
		{
			if(GameManager.Instance.localSave.EPJOACOONAC_GetSave().BOJCCICAHJK_Notification.JAFLKPEEGIM_OfferReceive != 0 && KDHGBOOECKC_NetOfferManager.HHCJCDFCLOB_Instance != null)
			{
				int a = KDHGBOOECKC_NetOfferManager.HHCJCDFCLOB_Instance.JGFHJPGJJHP();
				if(a > 0)
				{
					if(CIOECGOMILE_NetPlayerDataManager.HHCJCDFCLOB_Instance.AHEFHIMGIBI_PlayerData != null && CIOECGOMILE_NetPlayerDataManager.HHCJCDFCLOB_Instance.AHEFHIMGIBI_PlayerData.DAEJHMCMFJD_Offer != null)
					{
                        List<OCMJNBIFJNM_Offer.JPOHOLBBFGP> l = CIOECGOMILE_NetPlayerDataManager.HHCJCDFCLOB_Instance.AHEFHIMGIBI_PlayerData.DAEJHMCMFJD_Offer.FOFLMHELILC;
						long t = NKGJPJPHLIF_SakashoManager.HHCJCDFCLOB_Instance.IBLPICFDGOF_ServerRequester.FJDBNGEPKHL_Time.KMEFBNBFJHI_GetServerTime();
						long c = Utility.GetCurrentUnixTime();
						for(int i = 0; i < a; i++)
						{
							int a2 = i + 1;
							OCMJNBIFJNM_Offer.JPOHOLBBFGP offer = l.Find((OCMJNBIFJNM_Offer.JPOHOLBBFGP JPAEDJJFFOI) =>
							{
								//0xFBDE38
								if(JPAEDJJFFOI.EALOBDHOCHP_stat == 2)
									return JPAEDJJFFOI.OIOECMEEFKJ_VFp == a2;
								return false;
							});
							if(offer != null)
							{
								if(offer.NCDHKKCCGOD_edt >= t)
								{
									if(offer.NCDHKKCCGOD_edt - t > 4)
									{
										if(!JPFDCIFKBML(c + (offer.NCDHKKCCGOD_edt - t)))
											return;
										KGCCNEBMHMM.LKCPCCANJFB_SendNotif(EAPDJLPDHEJ.PFHAPPEDLGC_Vop, c + (offer.NCDHKKCCGOD_edt - t), 30000 + i, KDHGBOOECKC_NetOfferManager.HHCJCDFCLOB_Instance.IJEFGJHHELK(), KDHGBOOECKC_NetOfferManager.HHCJCDFCLOB_Instance.GOIOHEOGOFK(i + 1), 5, "png");
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
		if(KGCCNEBMHMM != null && KDHGBOOECKC_NetOfferManager.HHCJCDFCLOB_Instance != null)
		{
			int a = KDHGBOOECKC_NetOfferManager.HHCJCDFCLOB_Instance.JGFHJPGJJHP();
			if(a < 1)
				return;
			for(int i = 0; a != 0; i++, a--)
			{
				KGCCNEBMHMM.JCHLONCMPAJ_Clear(30000 + i);
			}
		}
	}

	// // RVA: 0xFBD35C Offset: 0xFBD35C VA: 0xFBD35C
	public void GCKBFMOMFCG_SetDecoNotif(NDBFKHKMMCE_DecoItem.ANMODBDBNPK.BIKFCCKCHHC_SpType NKCAKHIJEHF, long PEJIPAFKHKM, string _ADCMNODJBGJ_title, string _LJGOOOMOMMA_message, int _EAHPLCJMPHD_PId)
	{
		if(KGCCNEBMHMM != null)
		{
			if(NKCAKHIJEHF > 0 && NKCAKHIJEHF <= NDBFKHKMMCE_DecoItem.ANMODBDBNPK.BIKFCCKCHHC_SpType.JJNIMNEJPOF_3_Present && 
				GameManager.Instance.localSave.EPJOACOONAC_GetSave().BOJCCICAHJK_Notification.PIPOIELPKBP_DecoReceive != 0 && 
				JPFDCIFKBML(PEJIPAFKHKM))
			{
				KGCCNEBMHMM.LKCPCCANJFB_SendNotif(EAPDJLPDHEJ.BGCAPDNMPOK_Deco, PEJIPAFKHKM, (int)NKCAKHIJEHF + 40000, _ADCMNODJBGJ_title, _LJGOOOMOMMA_message, _EAHPLCJMPHD_PId, "png");
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
				KGCCNEBMHMM.JCHLONCMPAJ_Clear(i + 40001);
		}
	}

	// // RVA: 0xFBD588 Offset: 0xFBD588 VA: 0xFBD588
	public void NINPDKEKNEG(NDBFKHKMMCE_DecoItem.ANMODBDBNPK.BIKFCCKCHHC_SpType NKCAKHIJEHF)
	{
		if(KGCCNEBMHMM == null)
			return;
		KGCCNEBMHMM.JCHLONCMPAJ_Clear((int)NKCAKHIJEHF + 40000);
	}

	// // RVA: 0xFBD5A4 Offset: 0xFBD5A4 VA: 0xFBD5A4
	// public bool HJHKBNNEKMI(long PEJIPAFKHKM, int _LJNAKDMILMC_key, string _LJGOOOMOMMA_message, int _EAHPLCJMPHD_PId) { }

	// // RVA: 0xFB79B8 Offset: 0xFB79B8 VA: 0xFB79B8
	public void FOPAJBDEFCP_CancelStaminaNotif()
	{
		if(KGCCNEBMHMM != null)
			KGCCNEBMHMM.JCHLONCMPAJ_Clear(1);
	}

	// // RVA: 0xFB79D0 Offset: 0xFB79D0 VA: 0xFB79D0
	public void PELOGBHNHIL_CancelAPNotif()
	{
		if(KGCCNEBMHMM != null)
			KGCCNEBMHMM.JCHLONCMPAJ_Clear(6);
	}

	// // RVA: 0xFBC4B8 Offset: 0xFBC4B8 VA: 0xFBC4B8
	public void HBLOOGBLKKD_CancelComebackNotif()
	{
		if(KGCCNEBMHMM != null)
			KGCCNEBMHMM.JCHLONCMPAJ_Clear(2);
	}

	// // RVA: 0xFBC4D0 Offset: 0xFBC4D0 VA: 0xFBC4D0
	public void OJCABHGPCPK()
	{
		if(KGCCNEBMHMM != null)
			KGCCNEBMHMM.JCHLONCMPAJ_Clear(5);
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
	public bool JPFDCIFKBML(long _EOLFJGMAJAB_CurrentTime)
	{
		DateTime date = Utility.GetLocalDateTime(_EOLFJGMAJAB_CurrentTime);
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
