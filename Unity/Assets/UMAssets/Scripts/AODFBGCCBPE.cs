
using System.Collections;
using System.Collections.Generic;
using XeApp.Game;
using XeApp.Game.Menu;

// namespace XeApp.Game.Common.View
[System.Obsolete()]
public class AODFBGCCBPE {}
public class AODFBGCCBPE_ViewShopData
{
	public enum NJMPLEENNPO_ShopType
	{
		HJNNKCMLGFL_0_None = 0,
		AOMIBCNBBOD_1_Vc = 1,
		BDMFENCIPEB_2_Medal = 2,
		FNLODOLMLML_3 = 3,
		NCFFHDNEEIF_4_Uc = 4,
		BJNAMAANNMB_5_Deco = 5,
		FNJAOJBICJD_6_SuperGalaxyMedal = 6,
		MGEGNNJLJII_7_EpisodePlate1_4 = 7,
		ACFEDNPIJKM_8_EpisodePlate5_6 = 8,
	}

	public long GJFPFFBAKGK_CloseAt; // 0x8
	public long GIOIPNIMAIG; // 0x10
	public string NEMKDKDIIDK_ShopName; // 0x18
	public int OPKDAIMPJBH_ShopId; // 0x1C
	public int IBAKPKKEDJM_month; // 0x20
	public int JPGALGPNJAI_VcId; // 0x24
	public int EAHPLCJMPHD_PId; // 0x28 PayItemId
	public NJMPLEENNPO_ShopType INDDJNMPONH_type; // 0x2C
	public bool FPJBMCDMAMO; // 0x30
	public bool HKKPNKOIOKL; // 0x31
	public int EILKGEADKGH_Order; // 0x34
	public int OCGCPJHDJEN; // 0x38
	public bool CADENLBDAEB_IsNew; // 0x3C
	public List<FJGOKILCBJA_ViewShopProductData> MHKCPJDNJKI_products; // 0x40
	public IGCPCHNCJCF_NetShopManager GLHFDCKOJDN; // 0x44

	//// RVA: 0xD57ACC Offset: 0xD57ACC VA: 0xD57ACC
	public int JJPAFPIOBCK_GetCount()
	{
		if(OCGCPJHDJEN == 0)
			return 0;
        List<EGOLBAPFHHD_Common.GLBBNDKGEOC> saveMedal = CIOECGOMILE_NetPlayerDataManager.HHCJCDFCLOB_Instance.AHEFHIMGIBI_PlayerData.KCCLEHLLOFG_Common.MHKJEBNOPIM_Medal;
        switch (INDDJNMPONH_type)
		{
			case NJMPLEENNPO_ShopType.AOMIBCNBBOD_1_Vc:
				return CIOECGOMILE_NetPlayerDataManager.HHCJCDFCLOB_Instance.NOJDLFKKMDD_GetCurrencyTotal(JPGALGPNJAI_VcId);
			case NJMPLEENNPO_ShopType.BDMFENCIPEB_2_Medal:
			{
				int index = IBAKPKKEDJM_month - 1;
				if(index < saveMedal.Count)
				{
					int fullId = EKLNMHFCAOI_ItemManager.GJEEGMCBGGM_GetItemFullId(EKLNMHFCAOI_ItemManager.FKGCBLHOOCL_Category.ADCAAALBAIF_Medal, saveMedal[index].PPFNGGCBJKC_id);
					if(fullId == OCGCPJHDJEN)
					{
						return saveMedal[index].BFINGCJHOHI_cnt;
					}
				}
				return 0;
			}
			default:
				return 0;
			case NJMPLEENNPO_ShopType.NCFFHDNEEIF_4_Uc:
				return CIOECGOMILE_NetPlayerDataManager.HHCJCDFCLOB_Instance.AHEFHIMGIBI_PlayerData.KCCLEHLLOFG_Common.NFHLDFJIBKI_have_uc;
			case NJMPLEENNPO_ShopType.BJNAMAANNMB_5_Deco:
				return EKLNMHFCAOI_ItemManager.ALHCGDMEMID_GetNumItems(null, CIOECGOMILE_NetPlayerDataManager.HHCJCDFCLOB_Instance.AHEFHIMGIBI_PlayerData, EKLNMHFCAOI_ItemManager.FKGCBLHOOCL_Category.FMIIHMHKJDI_SpItem, 8, null);
			case NJMPLEENNPO_ShopType.FNJAOJBICJD_6_SuperGalaxyMedal:
				return EKLNMHFCAOI_ItemManager.ALHCGDMEMID_GetNumItems(null, CIOECGOMILE_NetPlayerDataManager.HHCJCDFCLOB_Instance.AHEFHIMGIBI_PlayerData, EKLNMHFCAOI_ItemManager.FKGCBLHOOCL_Category.FMIIHMHKJDI_SpItem, 7, null);
			case NJMPLEENNPO_ShopType.MGEGNNJLJII_7_EpisodePlate1_4:
			case NJMPLEENNPO_ShopType.ACFEDNPIJKM_8_EpisodePlate5_6:
				return EKLNMHFCAOI_ItemManager.ALHCGDMEMID_GetNumItems(null, CIOECGOMILE_NetPlayerDataManager.HHCJCDFCLOB_Instance.AHEFHIMGIBI_PlayerData, EKLNMHFCAOI_ItemManager.FKGCBLHOOCL_Category.FMIIHMHKJDI_SpItem, 15, null);
		}
	}

	//// RVA: 0xD57EC0 Offset: 0xD57EC0 VA: 0xD57EC0
	public void NBJNKFPEFGC()
	{
		GameManager.Instance.localSave.EPJOACOONAC_GetSave().PFOMECFACLL_Shop.POAFHAHACEL(OPKDAIMPJBH_ShopId, BGDCMGOPCGE_GetHash());
		GameManager.Instance.localSave.HJMKBCFJOOH_Save();
	}

	//// RVA: 0xD58134 Offset: 0xD58134 VA: 0xD58134
	public void KHEKNNFCAOI_Init(int _OPKDAIMPJBH_ShopId, long _JHNMKKNEENE_Time)
	{
		BKPAPCMJKHE_Shop.DNOENEKHGMI dbShop = IMMAOANGPNK_NetMasterDataManager.HHCJCDFCLOB_Instance.NKEBMCIMJND_Database.IFLGCDGOLOP_Shop.CDENCMNHNGA_table[_OPKDAIMPJBH_ShopId - 1];
		GJFPFFBAKGK_CloseAt = dbShop.GJFPFFBAKGK_CloseAt;
		GIOIPNIMAIG = dbShop.GJFPFFBAKGK_CloseAt;
		NEMKDKDIIDK_ShopName = dbShop.NEMKDKDIIDK_ShopName;
		this.OPKDAIMPJBH_ShopId = dbShop.OPKDAIMPJBH_ShopId;
		IBAKPKKEDJM_month = dbShop.IBAKPKKEDJM_month;
		EAHPLCJMPHD_PId = dbShop.EAHPLCJMPHD_PId;
		INDDJNMPONH_type = (NJMPLEENNPO_ShopType)dbShop.HCCEFDMGPEA;
		FPJBMCDMAMO = dbShop.FPJBMCDMAMO != 0;
		HKKPNKOIOKL = dbShop.FPJBMCDMAMO != 0;
		EILKGEADKGH_Order = dbShop.EILKGEADKGH_Order;
		JPGALGPNJAI_VcId = dbShop.JPGALGPNJAI_VcId;
		switch(INDDJNMPONH_type)
		{
			case NJMPLEENNPO_ShopType.AOMIBCNBBOD_1_Vc/*1*/:
				HHJHIFJIKAC_BonusVc.MNGJPJBCMBH h = IMMAOANGPNK_NetMasterDataManager.HHCJCDFCLOB_Instance.NKEBMCIMJND_Database.NBKNAAPBFFL_BonusVc.NPOALOFHFPN(JPGALGPNJAI_VcId);
				if (h == null)
					break;
				GIOIPNIMAIG = h.JDANEOJCLBB;
				HKKPNKOIOKL = true;
				OCGCPJHDJEN = EKLNMHFCAOI_ItemManager.GJEEGMCBGGM_GetItemFullId(EKLNMHFCAOI_ItemManager.FKGCBLHOOCL_Category.IBBDMIFICCN_BonusVC, h.PPFNGGCBJKC_id);
				break;
			case NJMPLEENNPO_ShopType.BDMFENCIPEB_2_Medal/*2*/:
				GIOIPNIMAIG = IMMAOANGPNK_NetMasterDataManager.HHCJCDFCLOB_Instance.NKEBMCIMJND_Database.ICICKEBMEFA_Medal.OEMKKJBNIFA(IBAKPKKEDJM_month);
				HKKPNKOIOKL = true;
				OCGCPJHDJEN = EKLNMHFCAOI_ItemManager.GJEEGMCBGGM_GetItemFullId(EKLNMHFCAOI_ItemManager.FKGCBLHOOCL_Category.ADCAAALBAIF_Medal, IBAKPKKEDJM_month);
				break;
			default:
				break;
			case NJMPLEENNPO_ShopType.NCFFHDNEEIF_4_Uc/*4*/:
				OCGCPJHDJEN = EKLNMHFCAOI_ItemManager.GJEEGMCBGGM_GetItemFullId(EKLNMHFCAOI_ItemManager.FKGCBLHOOCL_Category.ACGHELNGNGK_UnionCredit, 1);
				break;
			case NJMPLEENNPO_ShopType.BJNAMAANNMB_5_Deco/*5*/:
				OCGCPJHDJEN = EKLNMHFCAOI_ItemManager.GJEEGMCBGGM_GetItemFullId(EKLNMHFCAOI_ItemManager.FKGCBLHOOCL_Category.FMIIHMHKJDI_SpItem, 8);
				break;
			case NJMPLEENNPO_ShopType.FNJAOJBICJD_6_SuperGalaxyMedal/*6*/:
				OCGCPJHDJEN = EKLNMHFCAOI_ItemManager.GJEEGMCBGGM_GetItemFullId(EKLNMHFCAOI_ItemManager.FKGCBLHOOCL_Category.FMIIHMHKJDI_SpItem, 7);
				break;
			case NJMPLEENNPO_ShopType.MGEGNNJLJII_7_EpisodePlate1_4/*7*/:
			case NJMPLEENNPO_ShopType.ACFEDNPIJKM_8_EpisodePlate5_6/*8*/:
				OCGCPJHDJEN = EKLNMHFCAOI_ItemManager.GJEEGMCBGGM_GetItemFullId(EKLNMHFCAOI_ItemManager.FKGCBLHOOCL_Category.ADCAAALBAIF_Medal, IBAKPKKEDJM_month);
				break;
		}
		MHKCPJDNJKI_products = FJGOKILCBJA_ViewShopProductData.FKDIMODKKJD_GetList(dbShop.OPKDAIMPJBH_ShopId, dbShop.EFNMDPKEJIM_LineupId, _JHNMKKNEENE_Time);
		CADENLBDAEB_IsNew = false;
		if (GameManager.Instance.localSave.EPJOACOONAC_GetSave().PFOMECFACLL_Shop.BGDCMGOPCGE_GetHash(_OPKDAIMPJBH_ShopId) != BGDCMGOPCGE_GetHash())
		{
			CADENLBDAEB_IsNew = !QuestUtility.IsBeginnerQuest();
		}
	}

	//// RVA: 0xD58868 Offset: 0xD58868 VA: 0xD58868
	public static List<AODFBGCCBPE_ViewShopData> FKDIMODKKJD_GetList(bool DKLOGCOPPKJ)
	{
		long time = NKGJPJPHLIF_SakashoManager.HHCJCDFCLOB_Instance.IBLPICFDGOF_ServerRequester.FJDBNGEPKHL_Time.KMEFBNBFJHI_GetServerTime();
		List<AODFBGCCBPE_ViewShopData> res = new List<AODFBGCCBPE_ViewShopData>();
		List<BKPAPCMJKHE_Shop.DNOENEKHGMI> dbShopList = IMMAOANGPNK_NetMasterDataManager.HHCJCDFCLOB_Instance.NKEBMCIMJND_Database.IFLGCDGOLOP_Shop.CDENCMNHNGA_table;
		for(int i = 0; i < dbShopList.Count; i++)
		{
			if(dbShopList[i].PPEGAKEIEGM_Enabled == 2)
			{
				if (!DKLOGCOPPKJ)
				{
					if (time >= dbShopList[i].KJBGCLPMLCG_OpenedAt && dbShopList[i].GJFPFFBAKGK_CloseAt >= time && dbShopList[i].HCCEFDMGPEA == 1)
					{
						HHJHIFJIKAC_BonusVc.MNGJPJBCMBH bonus = IMMAOANGPNK_NetMasterDataManager.HHCJCDFCLOB_Instance.NKEBMCIMJND_Database.NBKNAAPBFFL_BonusVc.NPOALOFHFPN(EKLNMHFCAOI_ItemManager.DEACAHNLMNI_getItemId(dbShopList[i].EAHPLCJMPHD_PId));
						if (bonus == null || time < bonus.PDBPFJJCADD_open_at || bonus.EGBOHDFBAPB_closed_at < time)
							continue;
					}
				}
				//LAB_00d58ae8
				AODFBGCCBPE_ViewShopData data = new AODFBGCCBPE_ViewShopData();
				data.KHEKNNFCAOI_Init(dbShopList[i].OPKDAIMPJBH_ShopId, time);
				res.Add(data);
			}
		}
		res.Sort((AODFBGCCBPE_ViewShopData _HKICMNAACDA_a, AODFBGCCBPE_ViewShopData _BNKHBCBJBKI_b) => {
			//0xD5937C
			return _HKICMNAACDA_a.EILKGEADKGH_Order.CompareTo(_BNKHBCBJBKI_b.EILKGEADKGH_Order);
		});
		return res;
	}

	//// RVA: 0xD58E54 Offset: 0xD58E54 VA: 0xD58E54
	public static bool PLKKMHBFDCJ()
	{
		bool res = false;
		if(!QuestUtility.IsBeginnerQuest())
		{
			List<AODFBGCCBPE_ViewShopData> l = FKDIMODKKJD_GetList(false);
			for(int i = 0; i < l.Count; i++)
			{
				res |= l[i].CADENLBDAEB_IsNew;
			}
		}
		return res;
	}

	//// RVA: 0xD58028 Offset: 0xD58028 VA: 0xD58028
	private long BGDCMGOPCGE_GetHash()
	{
		if (MHKCPJDNJKI_products.Count < 1)
			return 0;
		long res = 0;
		for(int i = 0; i < MHKCPJDNJKI_products.Count; i++)
		{
			res += MHKCPJDNJKI_products[i].EAPILIMHDNP_BuyLimitDate ^ MHKCPJDNJKI_products.Count;
		}
		return res;
	}

	//// RVA: 0xD58F80 Offset: 0xD58F80 VA: 0xD58F80
	public void GKHAMEAMKCN(IMCBBOAFION CFHALLLJAOP, DJBHIFLHJLK _AOCANKOMKFG_OnError)
	{
		if(INDDJNMPONH_type != NJMPLEENNPO_ShopType.AOMIBCNBBOD_1_Vc)
		{
			CFHALLLJAOP();
			return;
		}
		if (GLHFDCKOJDN == null)
			GLHFDCKOJDN = new IGCPCHNCJCF_NetShopManager();
		HHJHIFJIKAC_BonusVc.MNGJPJBCMBH dbVc = IMMAOANGPNK_NetMasterDataManager.HHCJCDFCLOB_Instance.NKEBMCIMJND_Database.NBKNAAPBFFL_BonusVc.CDENCMNHNGA_table[JPGALGPNJAI_VcId - 1];
		GLHFDCKOJDN.COAIAEOOELG(dbVc.CPGFOBNKKBF_CurrencyId, () =>
		{
			//0xD593C4
			for(int i = 0; i < MHKCPJDNJKI_products.Count; i++)
			{
				MHKCPJDNJKI_products[i].EOJNOOHFOKA(GLHFDCKOJDN);
			}
			CFHALLLJAOP();
		}, () =>
		{
			//0xD59504
			_AOCANKOMKFG_OnError();
		});
	}

	//[IteratorStateMachineAttribute] // RVA: 0x7414BC Offset: 0x7414BC VA: 0x7414BC
	//// RVA: 0xD59220 Offset: 0xD59220 VA: 0xD59220
	public static IEnumerator OMBGMOFMCLD_Coroutine_UpdateViewShopList(List<AODFBGCCBPE_ViewShopData> NNDGIAEFMOG, DJBHIFLHJLK _BHFHGFKBOHH_OnSuccess, DJBHIFLHJLK _AOCANKOMKFG_OnError)
	{
		//0xD59554
		for(int i = 0; i < NNDGIAEFMOG.Count; i++)
		{
			if(NNDGIAEFMOG[i].INDDJNMPONH_type == NJMPLEENNPO_ShopType.AOMIBCNBBOD_1_Vc)
			{
				bool BEKAMBBOLBO_Done = false;
				bool CNAIDEAFAAM_Error = false;
				NNDGIAEFMOG[i].GKHAMEAMKCN(() =>
				{
					//0xD59538
					BEKAMBBOLBO_Done = true;
				}, () =>
				{
					//0xD59544
					BEKAMBBOLBO_Done = true;
					CNAIDEAFAAM_Error = true;
				});
				while (!BEKAMBBOLBO_Done)
					yield return null;
				if(CNAIDEAFAAM_Error)
				{
					_AOCANKOMKFG_OnError();
					yield break;
				}
			}
		}
		_BHFHGFKBOHH_OnSuccess();
	}
}
