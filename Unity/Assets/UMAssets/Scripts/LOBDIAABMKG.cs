
using System;
using System.Collections;
using System.Collections.Generic;
using XeSys;

public enum NPCHMKMAHMA
{
	HJNNKCMLGFL_0_None = 0,
	AIMPCCIHKAJ_1 = 1,
	DIHBOGEPHFI_2 = 2,
}

public class LOBDIAABMKG
{
	private const int HMDMNGHDFEC = 3600;
	private const int HNPLKNDMDIL = 10;
	public static int[] BHIHFFLOAGI = new int[20]; // 0x0
	public string OPFGFINHFCE_name; // 0x8
	public string OriginalName;
	public string EFIMCLPAEEN_imageUrl; // 0xC
	public string KLMPFGOCBHC_description; // 0x10
	public IKMBBPDBECA KACECFNECON_extra; // 0x14
	public int MJNOAMAFNHA_CostItemId; // 0x18
	public long KJBGCLPMLCG_OpenedAt; // 0x20
	public long GJFPFFBAKGK_CloseAt; // 0x28
	public long EABMLBFHJBH_CloseAt; // 0x30
	public bool KNMLPAAHAOF_IsStartGacha; // 0x38
	public GCAHJLOGMCI.KNMMOMEHDON_GachaType INDDJNMPONH_type; // 0x3C
	public int MGBDCFIKBPM_Serie; // 0x40
	public int FDEBLMKEMLF_TypeAndSeriesId; // 0x44
	public string IJADMGDHEIE; // 0x48
	public int HNKHCIDOKFF_PlateBgId; // 0x4C
	public int MFICPBJPCCJ_GachaBgId; // 0x50
	public bool MEBKAHGMING_HasNewEpisode; // 0x54
	public long EEFLOOBOAGF_ViewOrder; // 0x58
	public bool FJAOAGNFABN_HasOneDay; // 0x60
	public int ABNMIDCBENB_OneDay; // 0x64
	public bool KNMNJDKJHDM_HasDayCount; // 0x68
	private int JFDOLJDCCDJ_FreeTextureId; // 0x6C
	public string JCIBGEDBOHP_FreeBadgeMess = ""; // 0x70
	public int HHIBBHFHENH_LinkQuestId; // 0x74
	public int GPDIDIJDKAG_LinkCount; // 0x78
	public bool IMCNDJMDNJE_DisableCarousel; // 0x7C
	public bool CMCNKHLIKPP_HighRarityScene; // 0x7D
	private List<KBPDNHOKEKD_ProductId> MHKCPJDNJKI_products = new List<KBPDNHOKEKD_ProductId>(11); // 0x80
	private List<IKMBBPDBECA> LNPCOGEJGLL = new List<IKMBBPDBECA>(11); // 0x84
	private List<int> DHIACJMOEBH = new List<int>(11); // 0x88
	public Dictionary<string, HIMAFGJCECK> PECBGINLOLH = new Dictionary<string, HIMAFGJCECK>(); // 0x8C
	public bool CADENLBDAEB_IsNew; // 0x90
	public KOPCFBCDBPC NECDFDNBHFK_StepData; // 0x94
	public JBHCLFDBPKP NJLONELPNCD; // 0x98

	// public int OANKCIDLHLJ { get; }

	// // RVA: 0x10C4520 Offset: 0x10C4520 VA: 0x10C4520
	// public bool OHEBECPDIDF() { }

	// // RVA: 0x10C46C4 Offset: 0x10C46C4 VA: 0x10C46C4
	public bool MEONHEGJNEF()
	{
		long t = NKGJPJPHLIF.HHCJCDFCLOB.IBLPICFDGOF_ServerRequester.FJDBNGEPKHL_Time.KMEFBNBFJHI_GetServerTime();
		return GJFPFFBAKGK_CloseAt != 0 && GJFPFFBAKGK_CloseAt < t;
	}

	// // RVA: 0x10C47C4 Offset: 0x10C47C4 VA: 0x10C47C4
	// public int IGFFJIPFENH() { }

	// // RVA: 0x10C47E4 Offset: 0x10C47E4 VA: 0x10C47E4
	public MMNNAPPLHFM CHNFEEOJJCO(int CPNGJMKFCJI)
	{
		if(NECDFDNBHFK_StepData != null)
		{
			return NECDFDNBHFK_StepData.BMFEGOMNECF_steps.Find((MMNNAPPLHFM _GHPLINIACBB_x) =>
			{
				//0x10CB54C
				return _GHPLINIACBB_x.AGBCJMMMLON_step_index == CPNGJMKFCJI;
			});
		}
		return null;
	}

	// // RVA: 0x10C48FC Offset: 0x10C48FC VA: 0x10C48FC
	public ABPEPHGCNDA NLGPIELHAKC(int CPNGJMKFCJI, bool LNKELOHFELH)
	{
		if(NJLONELPNCD != null)
		{
			OEJEEHMMPBK d = NJLONELPNCD.BMFEGOMNECF_steps.Find((OEJEEHMMPBK _GHPLINIACBB_x) =>
			{
				//0x10CB590
				return _GHPLINIACBB_x.AGBCJMMMLON_step_index == CPNGJMKFCJI;
			});
			if(d != null)
			{
				if (LNKELOHFELH)
					return d.EFMGKHGMNKA_RareLots;
				else
					return d.GOKKEPEDLIM_NormalLots;
			}
		}
		return null;
	}

	// // RVA: 0x10C4A28 Offset: 0x10C4A28 VA: 0x10C4A28
	public KBPDNHOKEKD_ProductId DBHIEABGKII_GetSummon(GCAHJLOGMCI.NFCAJPIJFAM_SummonType _BJLONGBNPCI_SummonType)
	{
		return MHKCPJDNJKI_products[(int)_BJLONGBNPCI_SummonType];
	}

	// // RVA: 0x10C4AA8 Offset: 0x10C4AA8 VA: 0x10C4AA8
	public IKMBBPDBECA HNDLKGOMMNM(GCAHJLOGMCI.NFCAJPIJFAM_SummonType _BJLONGBNPCI_SummonType)
	{
		if (LNPCOGEJGLL[(int)_BJLONGBNPCI_SummonType] == null)
			return KACECFNECON_extra;
		return LNPCOGEJGLL[(int)_BJLONGBNPCI_SummonType];
	}

	// // RVA: 0x10C4B30 Offset: 0x10C4B30 VA: 0x10C4B30
	public int OMNAPCHLBHF_GetPurchaseCurrencyId(GCAHJLOGMCI.NFCAJPIJFAM_SummonType _BJLONGBNPCI_SummonType)
	{
		if(_BJLONGBNPCI_SummonType != GCAHJLOGMCI.NFCAJPIJFAM_SummonType.OBLEFFEJGIJ_8/*8*/)
		{
			return DHIACJMOEBH[(int)_BJLONGBNPCI_SummonType];
		}
		if (NECDFDNBHFK_StepData == null)
			return 0;
		return NECDFDNBHFK_StepData.LKPHIGAFJKD_virtual_currency.PPFNGGCBJKC_id;
	}

	// // RVA: 0x10C4BF0 Offset: 0x10C4BF0 VA: 0x10C4BF0
	public int FKKCFICCGMM(int _APHNELOFGAK_CurrencyId)
	{
		if (INDDJNMPONH_type == GCAHJLOGMCI.KNMMOMEHDON_GachaType.DLOPEFGOAPD_10_LimitedItem)
			return MJNOAMAFNHA_CostItemId;
		if(INDDJNMPONH_type == GCAHJLOGMCI.KNMMOMEHDON_GachaType.OOABDNHIEFK_9)
		{
			for(int i = 0; i < IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.NBKNAAPBFFL_BonusVc.CDENCMNHNGA_table.Count; i++)
			{
				HHJHIFJIKAC_BonusVc.MNGJPJBCMBH dbVc = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.NBKNAAPBFFL_BonusVc.CDENCMNHNGA_table[i];
				if(dbVc.CPGFOBNKKBF_CurrencyId == _APHNELOFGAK_CurrencyId)
				{
					return EKLNMHFCAOI.GJEEGMCBGGM_GetItemFullId(EKLNMHFCAOI.FKGCBLHOOCL_Category.IBBDMIFICCN_BonusVC, dbVc.PPFNGGCBJKC_id);
				}
			}
			return 0;
		}
		else if(INDDJNMPONH_type == GCAHJLOGMCI.KNMMOMEHDON_GachaType.ANFKBNLLJFN_7 || _APHNELOFGAK_CurrencyId == 1001)
		{
			return EKLNMHFCAOI.GJEEGMCBGGM_GetItemFullId(EKLNMHFCAOI.FKGCBLHOOCL_Category.PJDEOPMBGKJ_PaidVC, 1);
		}
		else
		{
			PMDCIJMMNGK_GachaTicket.EJAKHFONNGN tkt = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.GKMAHADAAFI_GachaTicket.AAJILEFHFGC(_APHNELOFGAK_CurrencyId);
			if (tkt == null)
				return 0;
			return EKLNMHFCAOI.GJEEGMCBGGM_GetItemFullId(EKLNMHFCAOI.FKGCBLHOOCL_Category.OBHECJMAEIO_GachaTicket, tkt.PPFNGGCBJKC_id);
		}
	}

	// // RVA: 0x10C4F48 Offset: 0x10C4F48 VA: 0x10C4F48
	// public bool HFEFJALCHMM() { }

	// // RVA: 0x10C5070 Offset: 0x10C5070 VA: 0x10C5070
	// public int HCMGHDNNJOM() { }

	// // RVA: 0x10C518C Offset: 0x10C518C VA: 0x10C518C
	// public int EDODPNCAGKN() { }

	// // RVA: 0x10C52A8 Offset: 0x10C52A8 VA: 0x10C52A8
	// public bool DIOPMDBJELP() { }

	// // RVA: 0x10C53D0 Offset: 0x10C53D0 VA: 0x10C53D0
	// public bool NIHLEOHPAFC() { }

	// // RVA: 0x10C54F8 Offset: 0x10C54F8 VA: 0x10C54F8
	public KBPDNHOKEKD_ProductId.KNEKLJHNHAK FJICMLBOJCH()
	{
		KBPDNHOKEKD_ProductId.KNEKLJHNHAK res = KBPDNHOKEKD_ProductId.KNEKLJHNHAK.HJNNKCMLGFL_0_None;
		for(int i = 0; i < MHKCPJDNJKI_products.Count; i++)
		{
			if(MHKCPJDNJKI_products[i] != null)
			{
				KBPDNHOKEKD_ProductId.KNEKLJHNHAK r = MHKCPJDNJKI_products[i].FJICMLBOJCH();
				if (r != KBPDNHOKEKD_ProductId.KNEKLJHNHAK.HJNNKCMLGFL_0_None)
					return r;
			}
		}
		return res;
	}

	// // RVA: 0x10C5618 Offset: 0x10C5618 VA: 0x10C5618
	public bool BANFOFKNKED(int _APHNELOFGAK_CurrencyId)
	{
		if(_APHNELOFGAK_CurrencyId == 1001)
		{
			if(MHKCPJDNJKI_products[2] != null)
			{
				if (MHKCPJDNJKI_products[4] != null)
					return true;
			}
		}
		return false;
	}

	// // RVA: 0x10C56F0 Offset: 0x10C56F0 VA: 0x10C56F0
	// public int BAGPMBGOCOK(int _APHNELOFGAK_CurrencyId) { }

	// // RVA: 0x10C57A4 Offset: 0x10C57A4 VA: 0x10C57A4
	public HIMAFGJCECK OHBCGMINBDP(GCAHJLOGMCI.NFCAJPIJFAM_SummonType _BJLONGBNPCI_SummonType, bool LNKELOHFELH)
	{
		KBPDNHOKEKD_ProductId k = DBHIEABGKII_GetSummon(_BJLONGBNPCI_SummonType);
		if (k == null)
			return null;
		if(!LNKELOHFELH)
		{
			for(int i = 0; i < k.GJEBPJHECIK_item_set_name_for_api.Count; i++)
			{
				if(!k.GJEBPJHECIK_item_set_name_for_api[i].Contains(AFEHLCGHAEE_Strings.PAFFIBGPOJN__rare4only))
				{
					if(PECBGINLOLH.ContainsKey(k.GJEBPJHECIK_item_set_name_for_api[i]))
					{
						return PECBGINLOLH[k.GJEBPJHECIK_item_set_name_for_api[i]];
					}
					return null;
				}
			}
			return null;
		}
		else
		{
			if (!k.PAFFIBGPOJN__rare4only)
				return null;
			for(int i = 0; i < k.GJEBPJHECIK_item_set_name_for_api.Count; i++)
			{
				if (k.GJEBPJHECIK_item_set_name_for_api[i].Contains(AFEHLCGHAEE_Strings.PAFFIBGPOJN__rare4only))
				{
					if (PECBGINLOLH.ContainsKey(k.GJEBPJHECIK_item_set_name_for_api[i]))
					{
						return PECBGINLOLH[k.GJEBPJHECIK_item_set_name_for_api[i]];
					}
					return null;
				}
			}
			return null;
		}
	}

	// // RVA: 0x10C5BD0 Offset: 0x10C5BD0 VA: 0x10C5BD0
	// private bool MIJEHENMEOE(GCAHJLOGMCI.NFCAJPIJFAM_SummonType _BJLONGBNPCI_SummonType) { }

	// // RVA: 0x10C5BF0 Offset: 0x10C5BF0 VA: 0x10C5BF0
	private bool DOMFHDPMCCO_Init(List<KBPDNHOKEKD_ProductId> NNDGIAEFMOG, GCAHJLOGMCI.NFCAJPIJFAM_SummonType _BJLONGBNPCI_SummonType, bool DDNGPDGGJBN_LoadInfo_, bool AJOAFPDICDK_NoLabelCheck_/* = false*/, NPCHMKMAHMA COMIABFPIKA/* = 0*/)
	{
		//joined_r0x010c5c94
		for(int i = NNDGIAEFMOG.Count - 1; i >= 0; i--)
		{
			GCAHJLOGMCI.NFCAJPIJFAM_SummonType summonType = GCAHJLOGMCI.HHFLDFFJICJ_GetGachaSummonType(NNDGIAEFMOG[i].KAPMOPMDHJE_label);
			if(summonType == _BJLONGBNPCI_SummonType || AJOAFPDICDK_NoLabelCheck_)
			{
				bool ok = ((1 << (int)summonType) & 0x2a) == 0; // 101010 1/3/5
				if(COMIABFPIKA == NPCHMKMAHMA.DIHBOGEPHFI_2)
				{
					if(summonType > GCAHJLOGMCI.NFCAJPIJFAM_SummonType.GOAHICNDICO_5)
						ok = true;
				}
				else
				{
					if(COMIABFPIKA != NPCHMKMAHMA.AIMPCCIHKAJ_1)
						ok = true;
					if(summonType > GCAHJLOGMCI.NFCAJPIJFAM_SummonType.GOAHICNDICO_5)
						continue;
				}
				if(ok)
				{
					if(MHKCPJDNJKI_products[(int)_BJLONGBNPCI_SummonType] != null)
					{
						int a = GCAHJLOGMCI.BDJDDKBCHKO(MHKCPJDNJKI_products[(int)_BJLONGBNPCI_SummonType].KAPMOPMDHJE_label);
						int c = GCAHJLOGMCI.BDJDDKBCHKO(NNDGIAEFMOG[i].KAPMOPMDHJE_label);
						if(c <= a)
							return true;
					}
					MHKCPJDNJKI_products[(int)_BJLONGBNPCI_SummonType] = NNDGIAEFMOG[i];
					LNPCOGEJGLL[(int)_BJLONGBNPCI_SummonType] = IKMBBPDBECA.HEGEKFMJNCC(NNDGIAEFMOG[i].KLMPFGOCBHC_description);
					if(!DDNGPDGGJBN_LoadInfo_)
						return true;
					OPFGFINHFCE_name = NNDGIAEFMOG[i].OPFGFINHFCE_name;
					OriginalName = NNDGIAEFMOG[i].OriginalName;
					EFIMCLPAEEN_imageUrl = NNDGIAEFMOG[i].EFIMCLPAEEN_imageUrl;
					KLMPFGOCBHC_description = NNDGIAEFMOG[i].KLMPFGOCBHC_description;
					GJFPFFBAKGK_CloseAt = NNDGIAEFMOG[i].EGBOHDFBAPB_closed_at;
					KJBGCLPMLCG_OpenedAt = NNDGIAEFMOG[i].KBFOIECIADN_opened_at;
					EABMLBFHJBH_CloseAt = NNDGIAEFMOG[i].EGBOHDFBAPB_closed_at;
					KNMLPAAHAOF_IsStartGacha = false;
					if(OriginalName.Contains(JpStringLiterals.StringLiteral_10431_Jp))
					{
						KNMLPAAHAOF_IsStartGacha = true;
					}
					KACECFNECON_extra = LNPCOGEJGLL[(int)_BJLONGBNPCI_SummonType];
					if(KACECFNECON_extra == null)
						return true;
					KLMPFGOCBHC_description = KACECFNECON_extra.KLMPFGOCBHC_description;
					if(KACECFNECON_extra.JOFAGCFNKIO_OpenTime != 0)
					{
						KJBGCLPMLCG_OpenedAt = KACECFNECON_extra.JOFAGCFNKIO_OpenTime;
					}
					if(!string.IsNullOrEmpty(KACECFNECON_extra.OPFGFINHFCE_name))
					{
						OPFGFINHFCE_name = KACECFNECON_extra.OPFGFINHFCE_name;
						OriginalName = KACECFNECON_extra.OriginalName;
					}
					if(!string.IsNullOrEmpty(KACECFNECON_extra.EABMLBFHJBH_CloseAt))
					{
						DateTime d;
						if(DateTime.TryParse(KACECFNECON_extra.EABMLBFHJBH_CloseAt, out d))
						{
							EABMLBFHJBH_CloseAt = Utility.GetTargetUnixTime(d.Year, d.Month, d.Day, d.Hour, d.Minute, d.Second);
						}
					}
					if(!string.IsNullOrEmpty(KACECFNECON_extra.FHHKLJCJNNC_FreeBadgeMess))
					{
						JCIBGEDBOHP_FreeBadgeMess = KACECFNECON_extra.FHHKLJCJNNC_FreeBadgeMess;
					}
					if(KACECFNECON_extra.HNKHCIDOKFF_PlateBgId < 1)
					{
						if(KACECFNECON_extra.FLADABCFDFA_Pickup.Count < 1)
						{
							if(INDDJNMPONH_type == GCAHJLOGMCI.KNMMOMEHDON_GachaType.GENEIBGNMPH_3_Debut/*3*/)
							{
								//
							}
							else if(KACECFNECON_extra.PGKIHFOKEHL_Feature.Count < 1)
							{
								//
							}
							else
								HNKHCIDOKFF_PlateBgId = KACECFNECON_extra.PGKIHFOKEHL_Feature[0].DNJEJEANJGL_Value;
						}
						else
						{
							HNKHCIDOKFF_PlateBgId = KACECFNECON_extra.FLADABCFDFA_Pickup[0].DNJEJEANJGL_Value;
						}
					}
					else
					{
						HNKHCIDOKFF_PlateBgId = KACECFNECON_extra.HNKHCIDOKFF_PlateBgId;
					}
					if(KACECFNECON_extra.MFICPBJPCCJ_GachaBgId > 0)
					{
						MFICPBJPCCJ_GachaBgId = KACECFNECON_extra.MFICPBJPCCJ_GachaBgId;
					}
					CMCNKHLIKPP_HighRarityScene = false;
					MLIBEPGADJH_Scene sceneDb = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.ECNHDEHADGL_Scene;
					foreach(var k in KACECFNECON_extra.NNDMIOEKKMM_NewEpisode)
					{
						foreach(var l in k.ADDCEJNOJLG_Scenes)
						{
							if(sceneDb.CDENCMNHNGA_table[l.DNJEJEANJGL_Value - 1].OOOPJNKBDIL_Is6OrMoreRarity())
							{
								CMCNKHLIKPP_HighRarityScene = true;
							}
						}
					}
					KACECFNECON_extra.EDCOECLMPGM(KNMLPAAHAOF_IsStartGacha);
					IMCNDJMDNJE_DisableCarousel = KACECFNECON_extra.IMCNDJMDNJE_DisableCarousel;
					MEBKAHGMING_HasNewEpisode = KACECFNECON_extra.NNDMIOEKKMM_NewEpisode.Count > 0;
					HHIBBHFHENH_LinkQuestId = KACECFNECON_extra.FPFECIDDNFA_LinkId;
					GPDIDIJDKAG_LinkCount = KACECFNECON_extra.MPHNHBBJDGP_LinkCount;
					FJAOAGNFABN_HasOneDay = KACECFNECON_extra.LEJAMOFMMPA_HasOneDay;
					ABNMIDCBENB_OneDay = KACECFNECON_extra.ABNMIDCBENB_OneDay;
					KNMNJDKJHDM_HasDayCount = KACECFNECON_extra.KNMNJDKJHDM_HasDayCount;
					MJNOAMAFNHA_CostItemId = KACECFNECON_extra.MJNOAMAFNHA_CostItemId;
					return true;
				}
			}
		}
		return false;
	}

	// // RVA: 0x10C6AD0 Offset: 0x10C6AD0 VA: 0x10C6AD0
	private bool HJLKMDHCGFP(KOPCFBCDBPC CCBEKGNDDBE, JBHCLFDBPKP BKGFCEIFMNF, GCAHJLOGMCI.NFCAJPIJFAM_SummonType _BJLONGBNPCI_SummonType)
	{
		KACECFNECON_extra = BKGFCEIFMNF.KACECFNECON_extra;
		LNPCOGEJGLL[(int)_BJLONGBNPCI_SummonType] = KACECFNECON_extra;
		OPFGFINHFCE_name = BKGFCEIFMNF.OPFGFINHFCE_name;
		OriginalName = BKGFCEIFMNF.OriginalName;
		KLMPFGOCBHC_description = BKGFCEIFMNF.KACECFNECON_extra.KLMPFGOCBHC_description;
		GJFPFFBAKGK_CloseAt = CCBEKGNDDBE.EGBOHDFBAPB_closed_at;
		EABMLBFHJBH_CloseAt = CCBEKGNDDBE.EGBOHDFBAPB_closed_at;
		KJBGCLPMLCG_OpenedAt = CCBEKGNDDBE.KBFOIECIADN_opened_at;
		INDDJNMPONH_type = GCAHJLOGMCI.KNMMOMEHDON_GachaType.BCBJMKDAAKA_8_StepUp;
		if(!string.IsNullOrEmpty(KACECFNECON_extra.OPFGFINHFCE_name))
		{
			OPFGFINHFCE_name = KACECFNECON_extra.OPFGFINHFCE_name;
			OriginalName = KACECFNECON_extra.OriginalName;
		}
		if(!string.IsNullOrEmpty(KACECFNECON_extra.FHHKLJCJNNC_FreeBadgeMess))
		{
			JCIBGEDBOHP_FreeBadgeMess = KACECFNECON_extra.FHHKLJCJNNC_FreeBadgeMess;
		}
		HNKHCIDOKFF_PlateBgId = KACECFNECON_extra.HNKHCIDOKFF_PlateBgId;
		int v;
		int.TryParse(CCBEKGNDDBE.FJGCDPLCIAK_unique_key.Substring(9, 4), out v);
		MGBDCFIKBPM_Serie = v;
		FDEBLMKEMLF_TypeAndSeriesId = (int)INDDJNMPONH_type * 10000 + v;
		IJADMGDHEIE = FDEBLMKEMLF_TypeAndSeriesId.ToString("D5");
		int stepIdx = CCBEKGNDDBE.LKHAAGIJEPG_player_status.DBNAGGGJDAB_current_step_index;
		long viewOrder = 0;
		if(KACECFNECON_extra != null)
			viewOrder = KACECFNECON_extra.EEFLOOBOAGF_ViewOrder;
		EEFLOOBOAGF_ViewOrder = GCAHJLOGMCI.PMBGPACNPIN(INDDJNMPONH_type, OriginalName, KJBGCLPMLCG_OpenedAt, viewOrder);
		NECDFDNBHFK_StepData = CCBEKGNDDBE;
		NJLONELPNCD = BKGFCEIFMNF;
		if(CCBEKGNDDBE.BMFEGOMNECF_steps[stepIdx - 1].FHBJOLPCAPN_max_count < 1)
			return true;
		return CCBEKGNDDBE.LKHAAGIJEPG_player_status.LPIKIBKFOJE_current_step_count < CCBEKGNDDBE.BMFEGOMNECF_steps[stepIdx - 1].FHBJOLPCAPN_max_count;
	}

	// // RVA: 0x10C6E60 Offset: 0x10C6E60 VA: 0x10C6E60
	public bool KHEKNNFCAOI_Init(List<KBPDNHOKEKD_ProductId> BBKDLIPKADG, int _MGBDCFIKBPM_Serie, GCAHJLOGMCI.KNMMOMEHDON_GachaType _INDDJNMPONH_type, bool _IAHLNPMFJMH_Tutorial, int _APHNELOFGAK_CurrencyId)
	{
		MHKCPJDNJKI_products.Clear();
		LNPCOGEJGLL.Clear();
		DHIACJMOEBH.Clear();
		for(int i = 0; i < 11; i++)
		{
			MHKCPJDNJKI_products.Add(null);
			LNPCOGEJGLL.Add(null);
			DHIACJMOEBH.Add(0);
		}
		bool b1;
		switch(_INDDJNMPONH_type)
		{
			case GCAHJLOGMCI.KNMMOMEHDON_GachaType.CCAPCGPIIPF_1_Normal:
			case GCAHJLOGMCI.KNMMOMEHDON_GachaType.DLOPEFGOAPD_10_LimitedItem:
				b1 = DOMFHDPMCCO_Init(BBKDLIPKADG, GCAHJLOGMCI.NFCAJPIJFAM_SummonType.AIMPCCIHKAJ_1, true, false, 0);
				break;
			case GCAHJLOGMCI.KNMMOMEHDON_GachaType.PHABJLGFJNI_2_Regular:
				b1 = DOMFHDPMCCO_Init(BBKDLIPKADG, GCAHJLOGMCI.NFCAJPIJFAM_SummonType.AIMPCCIHKAJ_1, true, false, 0);
				b1 &= DOMFHDPMCCO_Init(BBKDLIPKADG, GCAHJLOGMCI.NFCAJPIJFAM_SummonType.DIHBOGEPHFI_2, false, false, 0);
				break;
			case GCAHJLOGMCI.KNMMOMEHDON_GachaType.GENEIBGNMPH_3_Debut:
				b1 = true;
				if(!DOMFHDPMCCO_Init(BBKDLIPKADG, GCAHJLOGMCI.NFCAJPIJFAM_SummonType.AKHEAGMMIAM_4, true, false, 0))
				{
					b1 = DOMFHDPMCCO_Init(BBKDLIPKADG, GCAHJLOGMCI.NFCAJPIJFAM_SummonType.DIHBOGEPHFI_2, true, false, 0);
				}
				break;
			case GCAHJLOGMCI.KNMMOMEHDON_GachaType.JGDEHOGIENP_4_Sphere_CostumeTicket:
				if(!_IAHLNPMFJMH_Tutorial)
				{
					b1 = true;
					int a = (_APHNELOFGAK_CurrencyId - 1000) >> 3;
					if(a >= 0 && a < 125)
					{
						b1 = DOMFHDPMCCO_Init(BBKDLIPKADG, GCAHJLOGMCI.NFCAJPIJFAM_SummonType.AIMPCCIHKAJ_1, true, false, 0);
						b1 &= DOMFHDPMCCO_Init(BBKDLIPKADG, GCAHJLOGMCI.NFCAJPIJFAM_SummonType.DIHBOGEPHFI_2, false, false, 0);
						DOMFHDPMCCO_Init(BBKDLIPKADG, GCAHJLOGMCI.NFCAJPIJFAM_SummonType.ODDGKAKAGLE_3, false, false, 0);
						DOMFHDPMCCO_Init(BBKDLIPKADG, GCAHJLOGMCI.NFCAJPIJFAM_SummonType.AKHEAGMMIAM_4, false, false, 0);
					}
					a = (_APHNELOFGAK_CurrencyId - 2000) >> 3;
					if(a >= 0 && a < 125)
					{
						a = _APHNELOFGAK_CurrencyId - 2201;
						if(a >= 0 && a < 99)
						{
							b1 |= DOMFHDPMCCO_Init(BBKDLIPKADG, GCAHJLOGMCI.NFCAJPIJFAM_SummonType.NGAHKKOBGPA_9, false, true, NPCHMKMAHMA.AIMPCCIHKAJ_1);
							b1 |= DOMFHDPMCCO_Init(BBKDLIPKADG, GCAHJLOGMCI.NFCAJPIJFAM_SummonType.BPPLDIBMPKH_10, false, true, NPCHMKMAHMA.DIHBOGEPHFI_2);
						}
						else
						{
							b1 |= DOMFHDPMCCO_Init(BBKDLIPKADG, GCAHJLOGMCI.NFCAJPIJFAM_SummonType.GOAHICNDICO_5, false, true, NPCHMKMAHMA.AIMPCCIHKAJ_1);
							b1 |= DOMFHDPMCCO_Init(BBKDLIPKADG, GCAHJLOGMCI.NFCAJPIJFAM_SummonType.LMHDFEKIDKG_6, false, true, NPCHMKMAHMA.DIHBOGEPHFI_2);
						}
					}
				}
				else
				{
					b1 = DOMFHDPMCCO_Init(BBKDLIPKADG, GCAHJLOGMCI.NFCAJPIJFAM_SummonType.AIMPCCIHKAJ_1, true, false, 0);
					b1 &= DOMFHDPMCCO_Init(BBKDLIPKADG, GCAHJLOGMCI.NFCAJPIJFAM_SummonType.DIHBOGEPHFI_2, false, false, 0);
					if(b1)
					{
						DBHIEABGKII_GetSummon(GCAHJLOGMCI.NFCAJPIJFAM_SummonType.AIMPCCIHKAJ_1);
					}
				}
				break;
			case GCAHJLOGMCI.KNMMOMEHDON_GachaType.GKDFKDLFNAJ_5_LimitedTicket1:
			case GCAHJLOGMCI.KNMMOMEHDON_GachaType.BKNHBNINDOC_6_LimitedTicket2:
				b1 = DOMFHDPMCCO_Init(BBKDLIPKADG, GCAHJLOGMCI.NFCAJPIJFAM_SummonType.GOAHICNDICO_5, true, false, 0);
				break;
			default:
				return false;
			case GCAHJLOGMCI.KNMMOMEHDON_GachaType.OOABDNHIEFK_9:
				b1 = DOMFHDPMCCO_Init(BBKDLIPKADG, GCAHJLOGMCI.NFCAJPIJFAM_SummonType.GOAHICNDICO_5, true, false, 0);
				b1 |= DOMFHDPMCCO_Init(BBKDLIPKADG, GCAHJLOGMCI.NFCAJPIJFAM_SummonType.LMHDFEKIDKG_6, true, false, 0);
				break;
		}
		if(CKGECKPFFCC())
			return false;
		if(b1)
		{
			FDEBLMKEMLF_TypeAndSeriesId = (int)_INDDJNMPONH_type * 10000 + _MGBDCFIKBPM_Serie;
			INDDJNMPONH_type = _INDDJNMPONH_type;
			IJADMGDHEIE = FDEBLMKEMLF_TypeAndSeriesId.ToString("D5");
			if(KACECFNECON_extra == null)
			{
				EEFLOOBOAGF_ViewOrder = GCAHJLOGMCI.PMBGPACNPIN(_INDDJNMPONH_type, OriginalName, KJBGCLPMLCG_OpenedAt, 0);
			}
			else
			{
				if(KACECFNECON_extra.OPKCNBFBBKP_BannerId == 0)
				{
					EEFLOOBOAGF_ViewOrder = GCAHJLOGMCI.PMBGPACNPIN(_INDDJNMPONH_type, OriginalName, KJBGCLPMLCG_OpenedAt, KACECFNECON_extra.EEFLOOBOAGF_ViewOrder);
				}
				else
				{
					IJADMGDHEIE = KACECFNECON_extra.OPKCNBFBBKP_BannerId.ToString("D5");
					EEFLOOBOAGF_ViewOrder = GCAHJLOGMCI.PMBGPACNPIN(_INDDJNMPONH_type, OriginalName, KJBGCLPMLCG_OpenedAt, KACECFNECON_extra.EEFLOOBOAGF_ViewOrder);
				}
			}
			if(GHINEFPPDMH() < 0)
				return false;
		}
		//LAB_010c73a0
		for(int i = 0; i < MHKCPJDNJKI_products.Count; i++)
		{
			if(MHKCPJDNJKI_products[i] != null)
			{
				DHIACJMOEBH[i] = _APHNELOFGAK_CurrencyId;
			}
		}
		return b1;
	}

	// // RVA: 0x10C7660 Offset: 0x10C7660 VA: 0x10C7660
	public int GHINEFPPDMH()
	{
		KBPDNHOKEKD_ProductId k = DBHIEABGKII_GetSummon(GCAHJLOGMCI.NFCAJPIJFAM_SummonType.DIHBOGEPHFI_2);
		if(k != null)
		{
			if(k.HMFDJHEEGNN_buy_limit >= 1)
			{
				if(k.GIEBJDKLCDH_bought_quantity >= k.HMFDJHEEGNN_buy_limit)
					return -1;
			}
		}
		if(FJAOAGNFABN_HasOneDay)
		{
			EGOLBAPFHHD_Common.PCHECKGDJDK d = CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_PlayerData.KCCLEHLLOFG_Common.BGDMJGDEKFJ_GetGachaDraw(FDEBLMKEMLF_TypeAndSeriesId);
			if(d !=  null)
			{
				if(d.JJKGPMFJJNE == NKGJPJPHLIF.HHCJCDFCLOB.DHMLDAGGKCD)
				{
					if(ABNMIDCBENB_OneDay <= d.HMFFHLPNMPH_count)
						return -2;
				}
			}
		}
		if(CKGECKPFFCC())
			return -3;
		return 0;
	}

	// // RVA: 0x10C7820 Offset: 0x10C7820 VA: 0x10C7820
	public bool KHEKNNFCAOI_Init(KOPCFBCDBPC CCBEKGNDDBE, JBHCLFDBPKP BKGFCEIFMNF, int _MGBDCFIKBPM_Serie, GCAHJLOGMCI.KNMMOMEHDON_GachaType _INDDJNMPONH_type, int _APHNELOFGAK_CurrencyId)
	{
		MHKCPJDNJKI_products.Clear();
		LNPCOGEJGLL.Clear();
		DHIACJMOEBH.Clear();
		for(int i = 11; i > 0; i--)
		{
			MHKCPJDNJKI_products.Add(null);
			LNPCOGEJGLL.Add(null);
			DHIACJMOEBH.Add(0);
		}
		if(_INDDJNMPONH_type == GCAHJLOGMCI.KNMMOMEHDON_GachaType.BCBJMKDAAKA_8_StepUp)
		{
			bool r = HJLKMDHCGFP(CCBEKGNDDBE, BKGFCEIFMNF, GCAHJLOGMCI.NFCAJPIJFAM_SummonType.OBLEFFEJGIJ_8);
			for(int i = 0; i < MHKCPJDNJKI_products.Count; i++)
			{
				if(MHKCPJDNJKI_products[i] != null)
				{
					DHIACJMOEBH[i] = _APHNELOFGAK_CurrencyId;
				}
			}
			return r;
		}
		return false;
	}

	// // RVA: 0x10C7A70 Offset: 0x10C7A70 VA: 0x10C7A70
	public bool EJGLNKNKLFC(int PHIGDFMDJBO, GCAHJLOGMCI.KNMMOMEHDON_GachaType _INDDJNMPONH_type)
	{
		MHKCPJDNJKI_products.Clear();
		LNPCOGEJGLL.Clear();
		DHIACJMOEBH.Clear();
		for(int i = 0; i < 11; i++)
		{
			MHKCPJDNJKI_products.Add(null);
			LNPCOGEJGLL.Add(null);
			DHIACJMOEBH.Add(0);
		}
		KBPDNHOKEKD_ProductId data = new KBPDNHOKEKD_ProductId();
		data.OCBHANFFLOO_SetTutoGachaProduct(1);
		KBPDNHOKEKD_ProductId data2 = new KBPDNHOKEKD_ProductId();
		data2.OCBHANFFLOO_SetTutoGachaProduct(10);
		List<KBPDNHOKEKD_ProductId> l = new List<KBPDNHOKEKD_ProductId>();
		l.Add(data);
		l.Add(data2);
		bool b = DOMFHDPMCCO_Init(l, GCAHJLOGMCI.NFCAJPIJFAM_SummonType.AIMPCCIHKAJ_1/*1*/, true, false, 0);
		bool b2 = DOMFHDPMCCO_Init(l, GCAHJLOGMCI.NFCAJPIJFAM_SummonType.DIHBOGEPHFI_2/*2*/, false, false, 0);
		if(b && b2)
		{
			this.INDDJNMPONH_type = _INDDJNMPONH_type;
			MGBDCFIKBPM_Serie = PHIGDFMDJBO;
			IJADMGDHEIE = ((int)_INDDJNMPONH_type * 10000 + PHIGDFMDJBO).ToString("D5");
			EEFLOOBOAGF_ViewOrder = GCAHJLOGMCI.PMBGPACNPIN(_INDDJNMPONH_type, JpStringLiterals.StringLiteral_11117_Jp, 0, 0);
		}
		return b && b2;
	}

	// // RVA: 0x10C7DCC Offset: 0x10C7DCC VA: 0x10C7DCC
	public bool KIAIFPFBGJC(GCAHJLOGMCI.NFCAJPIJFAM_SummonType _BJLONGBNPCI_SummonType, CACGCMBKHDI_Request.HDHIKGLMOGF _BHFHGFKBOHH_OnSuccess, DJBHIFLHJLK HDFGHFOCHKE, DJBHIFLHJLK _JGKOLBLPMPG_OnFail)
	{
		PJKLMCGEJMK CPHFEPHDJIB_ServerRequester = NKGJPJPHLIF.HHCJCDFCLOB.IBLPICFDGOF_ServerRequester;
		if(_BJLONGBNPCI_SummonType == GCAHJLOGMCI.NFCAJPIJFAM_SummonType.OBLEFFEJGIJ_8)
		{
			if (NECDFDNBHFK_StepData == null)
				return false;
			DOLDMCAMEOD_RequestRemainingForCurrencyIds HFPHHNDMLKE = CPHFEPHDJIB_ServerRequester.IFFNCAFNEAG_AddRequest(new DOLDMCAMEOD_RequestRemainingForCurrencyIds());
			HFPHHNDMLKE.CGCFENMHJIM_Ids = new List<int>();
			HFPHHNDMLKE.CGCFENMHJIM_Ids.Add(1001);
			HFPHHNDMLKE.MOBEEPPKFLG_OnFail = (CACGCMBKHDI_Request JIPCHHHLOMM) =>
			{
				//0x10CB5D4
				_JGKOLBLPMPG_OnFail();
			};
			HFPHHNDMLKE.BHFHGFKBOHH_OnSuccess = (CACGCMBKHDI_Request JPDFGNJPGHL) =>
			{
				//0x10CB834
				CIOECGOMILE.HHCJCDFCLOB.DJICHKCLMCD_UpdateCurrencies(HFPHHNDMLKE.NFEAMMJIMPG_Result.BBEPLKNMICJ_balances);
				IHJEDAFEJHH_StepUpLotPurchase req = CPHFEPHDJIB_ServerRequester.IFFNCAFNEAG_AddRequest(new IHJEDAFEJHH_StepUpLotPurchase());
				req.APHNELOFGAK_CurrencyId = 1001;
				req.LGEKLPJFJEI_TotalCurrency = CIOECGOMILE.HHCJCDFCLOB.DEAPMEIDCGC_GetTotalPaidCurrency();
				req.MMEBLOIJBKE_UniqueKey = NECDFDNBHFK_StepData.FJGCDPLCIAK_unique_key;
				req.NNEGBDKOAHN_Hash = NECDFDNBHFK_StepData.LKHAAGIJEPG_player_status.ENJCKADOFBD_next_purchase_hash;
				req.BHFHGFKBOHH_OnSuccess = (CACGCMBKHDI_Request NBGOAPNONNA) =>
				{
					//0x10CB600
					IHJEDAFEJHH_StepUpLotPurchase r = NBGOAPNONNA as IHJEDAFEJHH_StepUpLotPurchase;
					NECDFDNBHFK_StepData.LKHAAGIJEPG_player_status.ODDIHGPONFL_Copy(r.NFEAMMJIMPG_Result.LKHAAGIJEPG_player_status);
					_BHFHGFKBOHH_OnSuccess(NBGOAPNONNA);
				};
				req.MOBEEPPKFLG_OnFail = (CACGCMBKHDI_Request JIPCHHHLOMM) =>
				{
					_JGKOLBLPMPG_OnFail();
				};
			};
		}
		else
		{
			KBPDNHOKEKD_ProductId k = DBHIEABGKII_GetSummon(_BJLONGBNPCI_SummonType);
			DOLDMCAMEOD_RequestRemainingForCurrencyIds PDHHLMOCEDK = CPHFEPHDJIB_ServerRequester.IFFNCAFNEAG_AddRequest(new DOLDMCAMEOD_RequestRemainingForCurrencyIds());
			if(_BJLONGBNPCI_SummonType == GCAHJLOGMCI.NFCAJPIJFAM_SummonType.GOAHICNDICO_5 ||
				_BJLONGBNPCI_SummonType == GCAHJLOGMCI.NFCAJPIJFAM_SummonType.LMHDFEKIDKG_6 ||
				_BJLONGBNPCI_SummonType == GCAHJLOGMCI.NFCAJPIJFAM_SummonType.NGAHKKOBGPA_9 ||
				_BJLONGBNPCI_SummonType == GCAHJLOGMCI.NFCAJPIJFAM_SummonType.BPPLDIBMPKH_10)
			{
				PDHHLMOCEDK.CGCFENMHJIM_Ids = new List<int>(IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.GKMAHADAAFI_GachaTicket.DHIACJMOEBH);
			}
			else
			{
				PDHHLMOCEDK.CGCFENMHJIM_Ids = new List<int>();
				PDHHLMOCEDK.CGCFENMHJIM_Ids.Add(1001);
			}
			PDHHLMOCEDK.MOBEEPPKFLG_OnFail = (CACGCMBKHDI_Request JPCBBHOLPGI) =>
			{
				//0x10CB7DC
				_JGKOLBLPMPG_OnFail();
			};
			PDHHLMOCEDK.BHFHGFKBOHH_OnSuccess = (CACGCMBKHDI_Request JPCBBHOLPGI) =>
			{
				//0x10CBB58
				CIOECGOMILE.HHCJCDFCLOB.DJICHKCLMCD_UpdateCurrencies(PDHHLMOCEDK.NFEAMMJIMPG_Result.BBEPLKNMICJ_balances);
				CBMFOOHOAOE_Purchase req = CPHFEPHDJIB_ServerRequester.IFFNCAFNEAG_AddRequest(new CBMFOOHOAOE_Purchase());
				req.ICDEFIIADDO_Timeout = 3600;
				req.AFKAGFOFAHM_ProductId = k.PPFNGGCBJKC_id;
				req.BPNPBJALGHM_quantity = 1;
				if (_BJLONGBNPCI_SummonType == GCAHJLOGMCI.NFCAJPIJFAM_SummonType.LMHDFEKIDKG_6)
				{
					if (IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.GKMAHADAAFI_GachaTicket.DHIACJMOEBH.Contains(OMNAPCHLBHF_GetPurchaseCurrencyId(_BJLONGBNPCI_SummonType)))
					{
						req.BPNPBJALGHM_quantity = CIOECGOMILE.HHCJCDFCLOB.NBJOCMAJLPK_GetTotalCurrency(OMNAPCHLBHF_GetPurchaseCurrencyId(_BJLONGBNPCI_SummonType));
						if (req.BPNPBJALGHM_quantity > 9)
							req.BPNPBJALGHM_quantity = 10;
					}
				}
				if(_BJLONGBNPCI_SummonType != GCAHJLOGMCI.NFCAJPIJFAM_SummonType.GOAHICNDICO_5 &&
					_BJLONGBNPCI_SummonType != GCAHJLOGMCI.NFCAJPIJFAM_SummonType.LMHDFEKIDKG_6 &&
					_BJLONGBNPCI_SummonType != GCAHJLOGMCI.NFCAJPIJFAM_SummonType.NGAHKKOBGPA_9 &&
					_BJLONGBNPCI_SummonType != GCAHJLOGMCI.NFCAJPIJFAM_SummonType.BPPLDIBMPKH_10)
				{
					req.APHNELOFGAK_CurrencyId = 1001;
					req.LGEKLPJFJEI_TotalCurrency = CIOECGOMILE.HHCJCDFCLOB.DEAPMEIDCGC_GetTotalPaidCurrency();
				}
				else
				{
					req.APHNELOFGAK_CurrencyId = OMNAPCHLBHF_GetPurchaseCurrencyId(_BJLONGBNPCI_SummonType);
					req.LGEKLPJFJEI_TotalCurrency = CIOECGOMILE.HHCJCDFCLOB.NBJOCMAJLPK_GetTotalCurrency(req.APHNELOFGAK_CurrencyId);
				}
				req.JJHCNJKPAOK = false;
				req.ICKAMKNDAEB_Label = k.KAPMOPMDHJE_label;
				req.LHMIIJEALCA_Type = 2;
				if(k.JENBPPBNAHP_PlayerNormalLotFreeState != null)
				{
					req.JJHCNJKPAOK = k.JENBPPBNAHP_PlayerNormalLotFreeState.LDBPAJKIPKD_IsNextFree;
				}
				req.BHFHGFKBOHH_OnSuccess = (CACGCMBKHDI_Request GCAKIEEGMDD) =>
				{
					//0x10CC1A4
					if(INDDJNMPONH_type == GCAHJLOGMCI.KNMMOMEHDON_GachaType.GENEIBGNMPH_3_Debut)
					{
						if(KNMLPAAHAOF_IsStartGacha)
						{
							CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_PlayerData.KCCLEHLLOFG_Common.BKCJPIPJCCM_sta_lot_done = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.GDEKCOOBLMA_System.NCEMAEDMJLO_GetBeginnerGachaVersion(NKGJPJPHLIF.HHCJCDFCLOB.IBLPICFDGOF_ServerRequester.FJDBNGEPKHL_Time.KMEFBNBFJHI_GetServerTime());
						}
					}
					if(FJAOAGNFABN_HasOneDay)
					{
						NKGJPJPHLIF.HHCJCDFCLOB.FPNBCFJHENI.DLNKOBKDOIB(FDEBLMKEMLF_TypeAndSeriesId, NKGJPJPHLIF.HHCJCDFCLOB.DHMLDAGGKCD);
						CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_PlayerData.KCCLEHLLOFG_Common.NIFJAPKCPOK_SetGachaValue(FDEBLMKEMLF_TypeAndSeriesId, NKGJPJPHLIF.HHCJCDFCLOB.DHMLDAGGKCD);
					}
					if(GCAKIEEGMDD is CBMFOOHOAOE_Purchase)
					{
						CBMFOOHOAOE_Purchase r = GCAKIEEGMDD as CBMFOOHOAOE_Purchase;
						if(k.JENBPPBNAHP_PlayerNormalLotFreeState != null)
						{
							if(r.NFEAMMJIMPG_Result.JENBPPBNAHP_PlayerNormalLotFreeState != null)
							{
								k.JENBPPBNAHP_PlayerNormalLotFreeState.LDBPAJKIPKD_IsNextFree = r.NFEAMMJIMPG_Result.JENBPPBNAHP_PlayerNormalLotFreeState.LDBPAJKIPKD_IsNextFree;
								k.JENBPPBNAHP_PlayerNormalLotFreeState.LJPIOGBFEKA_RemainsCount = r.NFEAMMJIMPG_Result.JENBPPBNAHP_PlayerNormalLotFreeState.LJPIOGBFEKA_RemainsCount;
								k.JENBPPBNAHP_PlayerNormalLotFreeState.NEMGBIEILOI_NextTimeAt = r.NFEAMMJIMPG_Result.JENBPPBNAHP_PlayerNormalLotFreeState.NEMGBIEILOI_NextTimeAt;
							}
						}
					}
					_BHFHGFKBOHH_OnSuccess(GCAKIEEGMDD);
				};
				req.MOBEEPPKFLG_OnFail = (CACGCMBKHDI_Request GCAKIEEGMDD) =>
				{
					//0x10CB808
					_JGKOLBLPMPG_OnFail();
				};
			};
		}
		return true;
	}

	// // RVA: 0x10C8500 Offset: 0x10C8500 VA: 0x10C8500
	public bool ICBNPNKJCBK(GCAHJLOGMCI.NFCAJPIJFAM_SummonType _BJLONGBNPCI_SummonType, CDOPFBOHDEF _BHFHGFKBOHH_OnSuccess, DJBHIFLHJLK _JGKOLBLPMPG_OnFail, int _BPNPBJALGHM_quantity/* = 1*/)
	{
		KBPDNHOKEKD_ProductId k = DBHIEABGKII_GetSummon(_BJLONGBNPCI_SummonType);
		if (_BJLONGBNPCI_SummonType != GCAHJLOGMCI.NFCAJPIJFAM_SummonType.OBLEFFEJGIJ_8 && k != null)
		{
			AAOCPMCMPCP_GetNormalLotItems req = NKGJPJPHLIF.HHCJCDFCLOB.IBLPICFDGOF_ServerRequester.IFFNCAFNEAG_AddRequest(new AAOCPMCMPCP_GetNormalLotItems());
			req.AFKAGFOFAHM_ProductId = k.PPFNGGCBJKC_id;
			req.BPNPBJALGHM_quantity = _BPNPBJALGHM_quantity;
			req.BHFHGFKBOHH_OnSuccess = (CACGCMBKHDI_Request NHECPMNKEFK) =>
			{
				//0x10CC810
				AAOCPMCMPCP_GetNormalLotItems r = NHECPMNKEFK as AAOCPMCMPCP_GetNormalLotItems;
				r.NFEAMMJIMPG_Result.HBHMAKNGKFK_items = r.NFEAMMJIMPG_Result.HBHMAKNGKFK_items;
				_BHFHGFKBOHH_OnSuccess(r.NFEAMMJIMPG_Result.HBHMAKNGKFK_items);
			};
			req.MOBEEPPKFLG_OnFail = (CACGCMBKHDI_Request NHECPMNKEFK) =>
			{
				//0x10CC9FC
				_JGKOLBLPMPG_OnFail();
			};
			return true;
		}
		return false;
	}

	// // RVA: 0x10C875C Offset: 0x10C875C VA: 0x10C875C
	public void AHOOLEAGACO_GetItemSetRecord(IMCBBOAFION _BHFHGFKBOHH_OnSuccess, DJBHIFLHJLK _JGKOLBLPMPG_OnFail)
	{
		N.a.StartCoroutineWatched(NINJDNIAGEN_Coroutine_GetItemSetRecord(_BHFHGFKBOHH_OnSuccess, _JGKOLBLPMPG_OnFail));
	}

	// [IteratorStateMachineAttribute] // RVA: 0x6B6010 Offset: 0x6B6010 VA: 0x6B6010
	// // RVA: 0x10C87B4 Offset: 0x10C87B4 VA: 0x10C87B4
	private IEnumerator NINJDNIAGEN_Coroutine_GetItemSetRecord(IMCBBOAFION _BHFHGFKBOHH_OnSuccess, DJBHIFLHJLK _MOBEEPPKFLG_OnFail)
	{
		int ONBPFIMAAEJ_i; // 0x1C
		KBPDNHOKEKD_ProductId BILEPJMCGEN; // 0x20
		int LFECMMEEMDM; // 0x24
		string CFHHCEOPHGH; // 0x28
		BLHOHLGCJHI_GetItemSetRecord DCNALBIJJGP; // 0x2C

		//0x10CCA94
		PECBGINLOLH.Clear();
		for(ONBPFIMAAEJ_i = 0; ONBPFIMAAEJ_i < MHKCPJDNJKI_products.Count; ONBPFIMAAEJ_i++)
		{
			BILEPJMCGEN = MHKCPJDNJKI_products[ONBPFIMAAEJ_i];
			if(BILEPJMCGEN != null)
			{
				for(LFECMMEEMDM = 0; LFECMMEEMDM < BILEPJMCGEN.GJEBPJHECIK_item_set_name_for_api.Count; LFECMMEEMDM++)
				{
					CFHHCEOPHGH = BILEPJMCGEN.GJEBPJHECIK_item_set_name_for_api[LFECMMEEMDM];
					if(!PECBGINLOLH.ContainsKey(CFHHCEOPHGH))
					{
						DCNALBIJJGP = NKGJPJPHLIF.HHCJCDFCLOB.IBLPICFDGOF_ServerRequester.IFFNCAFNEAG_AddRequest(new BLHOHLGCJHI_GetItemSetRecord());
						DCNALBIJJGP.DKBGNOMDCMK_ItemSetName = CFHHCEOPHGH;
						DCNALBIJJGP.KACECFNECON_extra = KACECFNECON_extra;
						while (!DCNALBIJJGP.PLOOEECNHFB_IsDone)
							yield return null;
						if (DCNALBIJJGP.NPNNPNAIONN_IsError)
						{
							PECBGINLOLH.Clear();
							_MOBEEPPKFLG_OnFail();
							yield break;
						}
						PECBGINLOLH.Add(CFHHCEOPHGH, DCNALBIJJGP.NFEAMMJIMPG_Result);
					}
				}
			}
		}
		_BHFHGFKBOHH_OnSuccess();
	}

	// // RVA: 0x10C8894 Offset: 0x10C8894 VA: 0x10C8894
	public void OALDDFAJFDL_GetStepUpItemSetRecord(IMCBBOAFION _BHFHGFKBOHH_OnSuccess, DJBHIFLHJLK _JGKOLBLPMPG_OnFail)
	{
		N.a.StartCoroutineWatched(BAKEDPGFOLF_Coroutine_GetStepUpItemSetRecord(_BHFHGFKBOHH_OnSuccess, _JGKOLBLPMPG_OnFail));
	}

	// [IteratorStateMachineAttribute] // RVA: 0x6B6088 Offset: 0x6B6088 VA: 0x6B6088
	// // RVA: 0x10C88EC Offset: 0x10C88EC VA: 0x10C88EC
	private IEnumerator BAKEDPGFOLF_Coroutine_GetStepUpItemSetRecord(IMCBBOAFION _BHFHGFKBOHH_OnSuccess, DJBHIFLHJLK _MOBEEPPKFLG_OnFail)
	{
		EDOGNHECOMI_GetStepUpLotDetail PNLGHFCFPPK_Request;

		//0x10CCFD8
		bool CNAIDEAFAAM_Error = false;
		bool BEKAMBBOLBO_Done = false;
		PNLGHFCFPPK_Request = NKGJPJPHLIF.HHCJCDFCLOB.IBLPICFDGOF_ServerRequester.IFFNCAFNEAG_AddRequest(new EDOGNHECOMI_GetStepUpLotDetail(true));
		PNLGHFCFPPK_Request.MMEBLOIJBKE_UniqueKey = NECDFDNBHFK_StepData.FJGCDPLCIAK_unique_key;
		PNLGHFCFPPK_Request.MOBEEPPKFLG_OnFail = (CACGCMBKHDI_Request JIPCHHHLOMM) =>
		{
			//0x10CCA30
			CNAIDEAFAAM_Error = true;
			BEKAMBBOLBO_Done = true;
		};
		PNLGHFCFPPK_Request.BHFHGFKBOHH_OnSuccess = (CACGCMBKHDI_Request JIPCHHHLOMM) =>
		{
			//0x10CCA3C
			BEKAMBBOLBO_Done = true;
		};
		while (!BEKAMBBOLBO_Done)
			yield return null;
		if(!CNAIDEAFAAM_Error)
		{
			NJLONELPNCD = PNLGHFCFPPK_Request.NFEAMMJIMPG_Result;
			_BHFHGFKBOHH_OnSuccess();
		}
		else
		{
			_MOBEEPPKFLG_OnFail();
		}
	}

	// // RVA: 0x10C89CC Offset: 0x10C89CC VA: 0x10C89CC
	public static List<ANGEDJODMKO> KECIGJBEHBG(List<ANGEDJODMKO> _PJJFEAHIPGL_inventories)
	{
		if (EKLNMHFCAOI.FABCKNDLPDH_GetItemRarity(_PJJFEAHIPGL_inventories[_PJJFEAHIPGL_inventories.Count - 1].JJBGOIMEIPF_ItemId) > 4)
			return _PJJFEAHIPGL_inventories;
		if(EKLNMHFCAOI.FABCKNDLPDH_GetItemRarity(_PJJFEAHIPGL_inventories[0].JJBGOIMEIPF_ItemId) < 5)
		{
			if (EKLNMHFCAOI.FABCKNDLPDH_GetItemRarity(_PJJFEAHIPGL_inventories[0].JJBGOIMEIPF_ItemId) > 3)
				return _PJJFEAHIPGL_inventories;
			List<ANGEDJODMKO> res = new List<ANGEDJODMKO>(10);
			int idx = -1;
			for(int i = 0; i < _PJJFEAHIPGL_inventories.Count; i++)
			{
				if(idx != -1 || EKLNMHFCAOI.FABCKNDLPDH_GetItemRarity(_PJJFEAHIPGL_inventories[i].JJBGOIMEIPF_ItemId) < 4)
				{
					res.Add(_PJJFEAHIPGL_inventories[i]);
				}
				else
				{
					idx = i;
				}
			}
			if (idx < 0)
				return res;
			res.Add(_PJJFEAHIPGL_inventories[idx]);
			return res;
		}
		else
		{
			List<ANGEDJODMKO> res = new List<ANGEDJODMKO>();
			for(int i = 1; i < _PJJFEAHIPGL_inventories.Count; i++)
			{
				res.Add(_PJJFEAHIPGL_inventories[i]);
			}
			res.Add(_PJJFEAHIPGL_inventories[0]);
			return res;
		}
	}

	// // RVA: 0x10C8F34 Offset: 0x10C8F34 VA: 0x10C8F34
	// public static List<MFDJIFIIPJD> ENFHLLHHJKE(List<MFDJIFIIPJD> _HBHMAKNGKFK_items) { }

	// // RVA: 0x10C9170 Offset: 0x10C9170 VA: 0x10C9170
	public string KKODAOIJHMC_GetKakuteiText(GCAHJLOGMCI.NFCAJPIJFAM_SummonType _BJLONGBNPCI_SummonType)
	{
		IKMBBPDBECA d = HNDLKGOMMNM(_BJLONGBNPCI_SummonType);
		if (d == null)
			return "";
		if (_BJLONGBNPCI_SummonType == GCAHJLOGMCI.NFCAJPIJFAM_SummonType.AIMPCCIHKAJ_1 && d is EBOCABJKMFB)
			return "";
		return d.MDEIKCBEHHC_Kakutei;
	}

	// // RVA: 0x10C923C Offset: 0x10C923C VA: 0x10C923C
	public int IEEHJPABKMP_GetOwnedQuantity()
	{
		if (MHKCPJDNJKI_products[3] == null)
		{
			if (MHKCPJDNJKI_products[1] == null)
				return 0;
			return MHKCPJDNJKI_products[1].HMFDJHEEGNN_buy_limit;
		}
		return MHKCPJDNJKI_products[3].GIEBJDKLCDH_bought_quantity;
	}

	// // RVA: 0x10C9304 Offset: 0x10C9304 VA: 0x10C9304
	public int GBAMENANDAN_GetMaxLimit()
	{
		if(MHKCPJDNJKI_products[3] == null)
		{
			if (MHKCPJDNJKI_products[1] == null)
				return 0;
			return MHKCPJDNJKI_products[1].HMFDJHEEGNN_buy_limit;
		}
		return MHKCPJDNJKI_products[3].HMFDJHEEGNN_buy_limit;
	}

	// // RVA: 0x10C93CC Offset: 0x10C93CC VA: 0x10C93CC
	public int GECLFOEDJEI_GetOwnedQuantity()
	{
		if(MHKCPJDNJKI_products[4] == null)
		{
			if (MHKCPJDNJKI_products[2] == null)
				return 0;
			return MHKCPJDNJKI_products[2].GIEBJDKLCDH_bought_quantity;
		}
		return MHKCPJDNJKI_products[4].GIEBJDKLCDH_bought_quantity;
	}

	// // RVA: 0x10C9494 Offset: 0x10C9494 VA: 0x10C9494
	public int IBNBABPKLAA_GetMaxLimit()
	{
		if(MHKCPJDNJKI_products[4] == null)
		{
			if (MHKCPJDNJKI_products[2] == null)
				return 0;
			return MHKCPJDNJKI_products[2].HMFDJHEEGNN_buy_limit;
		}
		return MHKCPJDNJKI_products[4].HMFDJHEEGNN_buy_limit;
	}

	// // RVA: 0x10C955C Offset: 0x10C955C VA: 0x10C955C
	public bool GPKAMGNBGAB(int _APHNELOFGAK_CurrencyId)
	{
		for (int i = 0; i < IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.NBKNAAPBFFL_BonusVc.CDENCMNHNGA_table.Count; i++)
		{
			HHJHIFJIKAC_BonusVc.MNGJPJBCMBH dbVC = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.NBKNAAPBFFL_BonusVc.CDENCMNHNGA_table[i];
			if(dbVC.CPGFOBNKKBF_CurrencyId == _APHNELOFGAK_CurrencyId)
			{
				int id = EKLNMHFCAOI.GJEEGMCBGGM_GetItemFullId(EKLNMHFCAOI.FKGCBLHOOCL_Category.IBBDMIFICCN_BonusVC, dbVC.PPFNGGCBJKC_id);
				for(int j = 0; j < IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.KCCDBKIOLDJ_VcItem.CDENCMNHNGA_table.Count; j++)
				{
					DKJMDIFAKKD_VcItem.EBGPAPPHBAH dbVc2 = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.KCCDBKIOLDJ_VcItem.CDENCMNHNGA_table[j];
					for(int k = 0; k < dbVc2.KGOFMDMDFCJ_BonusId.Length; k++)
					{
						if(dbVc2.KGOFMDMDFCJ_BonusId[k] == id)
						{
							if (!GHLJANAEKFJ(dbVc2.PPFNGGCBJKC_id))
								return true;
						}
					}
				}
			}
		}
		return false;
	}

	// // RVA: 0x10C9990 Offset: 0x10C9990 VA: 0x10C9990
	private bool GHLJANAEKFJ(int ADANONKNBKE)
	{
		for(int i = 0; i < EJHPIMANJFP.HHCJCDFCLOB.MHKCPJDNJKI_products.Count; i++)
		{
			if (EJHPIMANJFP.HHCJCDFCLOB.MHKCPJDNJKI_products[i].LHENLPLKGLP_StuffId == ADANONKNBKE && EJHPIMANJFP.HHCJCDFCLOB.MHKCPJDNJKI_products[i].AJIFADGGAAJ_BoughtQuantity < EJHPIMANJFP.HHCJCDFCLOB.MHKCPJDNJKI_products[i].GCJMGMBNBCB_BuyLimit)
				return true;
		}
		return false;
	}

	// // RVA: 0x10C9AD8 Offset: 0x10C9AD8 VA: 0x10C9AD8
	public int HIPBEKBFNBG(int _APHNELOFGAK_CurrencyId)
	{
		for(int i = 0; i < IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.NBKNAAPBFFL_BonusVc.CDENCMNHNGA_table.Count; i++)
		{
			HHJHIFJIKAC_BonusVc.MNGJPJBCMBH dbVC = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.NBKNAAPBFFL_BonusVc.CDENCMNHNGA_table[i];
			if(dbVC.CPGFOBNKKBF_CurrencyId == _APHNELOFGAK_CurrencyId)
			{
				return dbVC.JDANEOJCLBB;
			}
		}
		return 0;
	}

	// // RVA: 0x10C9C8C Offset: 0x10C9C8C VA: 0x10C9C8C
	public bool ALPOJNBHNDK(int _APHNELOFGAK_CurrencyId, long _JHNMKKNEENE_Time)
	{
		for(int i = 0; i < IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.NBKNAAPBFFL_BonusVc.CDENCMNHNGA_table.Count; i++)
		{
			HHJHIFJIKAC_BonusVc.MNGJPJBCMBH dbVC = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.NBKNAAPBFFL_BonusVc.CDENCMNHNGA_table[i];
			if(dbVC.CPGFOBNKKBF_CurrencyId == _APHNELOFGAK_CurrencyId)
			{
				if (_JHNMKKNEENE_Time < dbVC.KMENGHEAIOC)
					return false;
				if (_JHNMKKNEENE_Time < dbVC.JDANEOJCLBB)
					return true;
				return false;
			}
		}
		return false;
	}

	// // RVA: 0x10C9EC4 Offset: 0x10C9EC4 VA: 0x10C9EC4
	public string KAGBOMEDOLJ(int _APHNELOFGAK_CurrencyId)
	{
		for (int i = 0; i < IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.NBKNAAPBFFL_BonusVc.CDENCMNHNGA_table.Count; i++)
		{
			HHJHIFJIKAC_BonusVc.MNGJPJBCMBH dbVc = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.NBKNAAPBFFL_BonusVc.CDENCMNHNGA_table[i];
			if(dbVc.CPGFOBNKKBF_CurrencyId == _APHNELOFGAK_CurrencyId)
			{
				return EKLNMHFCAOI.INCKKODFJAP_GetItemName(EKLNMHFCAOI.GJEEGMCBGGM_GetItemFullId(EKLNMHFCAOI.FKGCBLHOOCL_Category.IBBDMIFICCN_BonusVC, dbVc.PPFNGGCBJKC_id));
			}
		}
		return "";
	}

	// // RVA: 0x10CA118 Offset: 0x10CA118 VA: 0x10CA118
	public bool IJJOGGEBBPF(int _APHNELOFGAK_CurrencyId)
	{
		long time = NKGJPJPHLIF.HHCJCDFCLOB.IBLPICFDGOF_ServerRequester.FJDBNGEPKHL_Time.KMEFBNBFJHI_GetServerTime();
		for(int i = 0; i < IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.NBKNAAPBFFL_BonusVc.CDENCMNHNGA_table.Count; i++)
		{
			if(IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.NBKNAAPBFFL_BonusVc.CDENCMNHNGA_table[i].CPGFOBNKKBF_CurrencyId == _APHNELOFGAK_CurrencyId)
			{
				if(time < IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.NBKNAAPBFFL_BonusVc.CDENCMNHNGA_table[i].KMENGHEAIOC)
					return false;
				if(time >= IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.NBKNAAPBFFL_BonusVc.CDENCMNHNGA_table[i].KMENGHEAIOC)
					return false;
				return true;
			}
		}
		return false;
	}

	// // RVA: 0x10CA3E0 Offset: 0x10CA3E0 VA: 0x10CA3E0
	public int LPPJMOMKPKA(int _APHNELOFGAK_CurrencyId)
	{
		for (int i = 0; i < IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.NBKNAAPBFFL_BonusVc.CDENCMNHNGA_table.Count; i++)
		{
			HHJHIFJIKAC_BonusVc.MNGJPJBCMBH dbVc = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.NBKNAAPBFFL_BonusVc.CDENCMNHNGA_table[i];
			if(dbVc.CPGFOBNKKBF_CurrencyId == _APHNELOFGAK_CurrencyId)
			{
				int itemId = EKLNMHFCAOI.GJEEGMCBGGM_GetItemFullId(EKLNMHFCAOI.FKGCBLHOOCL_Category.IBBDMIFICCN_BonusVC, dbVc.PPFNGGCBJKC_id);
				for(int j = 0; j < IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.KCCDBKIOLDJ_VcItem.CDENCMNHNGA_table.Count; j++)
				{
					DKJMDIFAKKD_VcItem.EBGPAPPHBAH dbVc2 = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.KCCDBKIOLDJ_VcItem.CDENCMNHNGA_table[j];
					for(int k = 0; k < dbVc2.KGOFMDMDFCJ_BonusId.Length; k++)
					{
						if(dbVc2.KGOFMDMDFCJ_BonusId[k] == itemId)
						{
							return dbVc2.PPFNGGCBJKC_id;
						}
					}
				}
			}
		}
		return 0;
	}

	// // RVA: 0x10CA804 Offset: 0x10CA804 VA: 0x10CA804
	// public int LMNGEPHLMKO() { }

	// // RVA: 0x10CA954 Offset: 0x10CA954 VA: 0x10CA954
	public int EDCAFNOBCOJ()
	{
		if(KACECFNECON_extra != null && KACECFNECON_extra.ANFKCPGENCM_TicketVcId != null && KACECFNECON_extra.ANFKCPGENCM_TicketVcId.Count > 0)
		{
			List<MCKCJMLOAFP_CurrencyInfo> l1 = new List<MCKCJMLOAFP_CurrencyInfo>();
			for(int i = 0; i < KACECFNECON_extra.ANFKCPGENCM_TicketVcId.Count; i++)
			{
				int v = KACECFNECON_extra.ANFKCPGENCM_TicketVcId[i].DNJEJEANJGL_Value;
				MCKCJMLOAFP_CurrencyInfo c = CIOECGOMILE.HHCJCDFCLOB.BBEPLKNMICJ_balances.Find((MCKCJMLOAFP_CurrencyInfo _GHPLINIACBB_x) =>
				{
					//0x10CCA48
					if (_GHPLINIACBB_x.PPFNGGCBJKC_id != v)
						return false;
					return _GHPLINIACBB_x.BDLNMOIOMHK_total > 0;
				});
				if(c != null)
				{
					l1.Add(c);
				}
			}
			if(l1.Count < 1)
			{
				return KACECFNECON_extra.ANFKCPGENCM_TicketVcId[0].DNJEJEANJGL_Value;
			}
			return l1[0].PPFNGGCBJKC_id;
		}
		return 0;
	}

	// // RVA: 0x10CACD0 Offset: 0x10CACD0 VA: 0x10CACD0
	public static bool GPKPIGPDFNL(List<LOBDIAABMKG> NNDGIAEFMOG, int _HHIBBHFHENH_LinkQuestId, int _GPDIDIJDKAG_LinkCount)
	{
		int a1 = 0;
		int a2 = 0;
		int a3 = 0;
		for(int i = 0; i < NNDGIAEFMOG.Count; i++)
		{
			if(NNDGIAEFMOG[i].HHIBBHFHENH_LinkQuestId > 0 && NNDGIAEFMOG[i].HHIBBHFHENH_LinkQuestId == _HHIBBHFHENH_LinkQuestId)
			{
				a3++;
				foreach(var k in NNDGIAEFMOG[i].MHKCPJDNJKI_products)
				{
					if(k != null)
					{
						a2 += k.GIEBJDKLCDH_bought_quantity;
						if(a1 == 0)
							a1 = k.HMFDJHEEGNN_buy_limit;
					}
				}
			}
		}
		return a3 == _GPDIDIJDKAG_LinkCount && (a1 == 0 || a2 < a1);
	}

	// // RVA: 0x10C74DC Offset: 0x10C74DC VA: 0x10C74DC
	public bool CKGECKPFFCC()
	{
		DateTime d = Utility.GetLocalDateTime(KJBGCLPMLCG_OpenedAt);
		if(d.Minute == 59)
		{
			return NKGJPJPHLIF.HHCJCDFCLOB.IBLPICFDGOF_ServerRequester.FJDBNGEPKHL_Time.KMEFBNBFJHI_GetServerTime() - KJBGCLPMLCG_OpenedAt < 60;
		}
		return false;
	}

	// // RVA: 0x10CB01C Offset: 0x10CB01C VA: 0x10CB01C
	public void EIHCALCFNEJ(LOBDIAABMKG _DPBDFPPMIPH_Gacha)
	{
		for(int i = 0; i < 11; i++)
		{
			if(MHKCPJDNJKI_products[i] == null)
			{
				if(_DPBDFPPMIPH_Gacha.MHKCPJDNJKI_products[i] != null)
				{
					MHKCPJDNJKI_products[i] = _DPBDFPPMIPH_Gacha.MHKCPJDNJKI_products[i];
				}
			}
			if(DHIACJMOEBH[i] == 0)
			{
				if(_DPBDFPPMIPH_Gacha.DHIACJMOEBH[i] != 0)
				{
					DHIACJMOEBH[i] = _DPBDFPPMIPH_Gacha.DHIACJMOEBH[i];
				}
			}
			if(LNPCOGEJGLL[i] == null)
			{
				if(_DPBDFPPMIPH_Gacha.LNPCOGEJGLL[i] != null)
				{
					LNPCOGEJGLL[i] = _DPBDFPPMIPH_Gacha.LNPCOGEJGLL[i];
				}
			}
		}
	}
}
