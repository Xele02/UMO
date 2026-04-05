
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XeSys;

//namespace XeApp.Game.Common.View
[System.Obsolete()]
public class FJGOKILCBJA {}
public class FJGOKILCBJA_ViewShopProductData
{
	public int OPKDAIMPJBH_ShopId; // 0x8
	public int AFKAGFOFAHM_ProductId; // 0xC
	public int FPJBMCDMAMO; // 0x10
	public DateTime JIHKOPIENAC; // 0x18
	public long EAPILIMHDNP_BuyLimitDate; // 0x20
	public int EILKGEADKGH_Order; // 0x28
	public int KAPMOPMDHJE_label; // 0x2C
	public IGCPCHNCJCF_NetShopManager GLHFDCKOJDN; // 0x30
	public JKNGJFOBADP JANMJPOKLFL_InventoryUtil = new JKNGJFOBADP(); // 0x34
	public int NGGNFHPOMOO_Crypted; // 0x38
	public int EKAPPBELKDA_Crypted; // 0x3C
	public int BOELIGECGJD_Crypted; // 0x40
	public int PIMKKONMBOG_ItemIdCrypted; // 0x44
	public int ALJGJMBFKHE_ItemCountCrypted; // 0x48
	public int AIDNHPGEHPM_MaxCountCrypted; // 0x4C
	public int CKNFCDCKFDE_CountCrypted; // 0x50
	public int LDLHJMBGGGJ_Crypted; // 0x54
	public int PAFAKOPJLEE_Crypted; // 0x58
	public int KEHENBMEFJN_Crypted; // 0x5C
	public string DJPBDDBNMLN_SakashoProductName; // 0x60
	public bool EHJBMHEAADC; // 0x64

	public int JNLPLBJKGDC { get { return PAFAKOPJLEE_Crypted ^ 0x74841479; } set { PAFAKOPJLEE_Crypted = value ^ 0x74841479; } } //0x117FBD8 HCDEEJAKFOF_bgs 0x117FBEC OCKKBHCFOEM_bgs
	public int GJGNOFAPFJD { get { return BOELIGECGJD_Crypted ^ 0x74841479; } set { BOELIGECGJD_Crypted = value ^ 0x74841479; } } //0x117FC00 JAGHPMNNEPG_bgs 0x117FC14 FACIELLBLMP_bgs
	public int KIJAPOFAGPN_ItemId { get { return PIMKKONMBOG_ItemIdCrypted ^ 0x51478174; } set { PIMKKONMBOG_ItemIdCrypted = value ^ 0x51478174; } } //0x117FC28 GCKKKIDNACI_bgs 0x117FC3C OGBLMPODGBG_bgs
	public int JDLJPNMLFID_ItemCount { get { return ALJGJMBFKHE_ItemCountCrypted ^ 0x137418ff; } set { ALJGJMBFKHE_ItemCountCrypted = value ^ 0x137418ff; } } //0x117FC50 BGIBDHCFJMN_bgs 0x117FC64 NDNEDCNDOGJ_bgs
	public int JPJMHLNOIAJ_ItemCostFullId { get { return NGGNFHPOMOO_Crypted ^ 0x137418ff; } set { NGGNFHPOMOO_Crypted = value ^ 0x137418ff; } } //0x117FC78 CFPIIDJJCHE_bgs 0x117FC8C PFKNCLBDBGH_bgs
	public int DKEPCPPCIKA_Price { get { return EKAPPBELKDA_Crypted ^ 0x374147ee; } set { EKAPPBELKDA_Crypted = value ^ 0x374147ee; } } //0x117FCA0 HPLCJFNDOKC_bgs 0x117FCB4 HNIDHAHIBLF_bgs
	public int ELEPHBOKIGK_Limit { get { return AIDNHPGEHPM_MaxCountCrypted ^ 0x247ef; } set { AIDNHPGEHPM_MaxCountCrypted = value ^ 0x247ef; } } //0x117FCC8 IIJFLONJAFL_bgs 0x117FCDC LHNFGPIGCNE_bgs
	public int JLENMGOCHDG_Count { get { return CKNFCDCKFDE_CountCrypted ^ 0x377247ef; } set { CKNFCDCKFDE_CountCrypted = value ^ 0x377247ef; } } //0x117FCF0 OLJEIELPFMC_bgs 0x117FD04 JMNGGBCNLJN_bgs
	public int PBNCFGDPJKG_DecoItemSet { get { return KEHENBMEFJN_Crypted ^ 0x141871f; } set { KEHENBMEFJN_Crypted = value ^ 0x141871f; } } //0x117FD18 LCKOMDHNEBF_bgs 0x117FD2C LPODAPEMLEA_bgs
	public int NFBLLKHBMEK_SakashoProductId { get { return LDLHJMBGGGJ_Crypted ^ 0x93a97a; } set { LDLHJMBGGGJ_Crypted = value ^ 0x93a97a; } } //0x117FD40 NCBIANHKGMG_bgs 0x117FD54 OFKJMDODHLO_bgs

	//// RVA: 0x117FD68 Offset: 0x117FD68 VA: 0x117FD68
	public void KHEKNNFCAOI_Init(int _OPKDAIMPJBH_ShopId, int _AFKAGFOFAHM_ProductId)
	{
		BKPAPCMJKHE_Shop.BOMCAJJCPME dbItem = IMMAOANGPNK_NetMasterDataManager.HHCJCDFCLOB_Instance.NKEBMCIMJND_Database.IFLGCDGOLOP_Shop.MHKCPJDNJKI_products[_AFKAGFOFAHM_ProductId - 1];
		BKPAPCMJKHE_Shop.GPNPMJJKONJ dbItem2 = IMMAOANGPNK_NetMasterDataManager.HHCJCDFCLOB_Instance.NKEBMCIMJND_Database.IFLGCDGOLOP_Shop.HMKKLPPEOHL[dbItem.GJGNOFAPFJD - 1];
		GBEFGAIGGHA_Shop.DPGGLKKBNBJ saveItem = CIOECGOMILE_NetPlayerDataManager.HHCJCDFCLOB_Instance.AHEFHIMGIBI_PlayerData.IJOHDAJMBAL_Shop.ECMLOMPGMLC[_AFKAGFOFAHM_ProductId - 1];
		BKPAPCMJKHE_Shop.DNOENEKHGMI dbItem3 = IMMAOANGPNK_NetMasterDataManager.HHCJCDFCLOB_Instance.NKEBMCIMJND_Database.IFLGCDGOLOP_Shop.CDENCMNHNGA_table[_OPKDAIMPJBH_ShopId - 1];
		this.OPKDAIMPJBH_ShopId = _OPKDAIMPJBH_ShopId;
		this.AFKAGFOFAHM_ProductId = _AFKAGFOFAHM_ProductId;
		GJGNOFAPFJD = dbItem.GJGNOFAPFJD;
		KIJAPOFAGPN_ItemId = dbItem2.EJHMPCJNHBP_ItemFullId;
		JDLJPNMLFID_ItemCount = dbItem2.LBCNKLPIMHL_Count;
		JPJMHLNOIAJ_ItemCostFullId = dbItem2.LMMCMHHAGBJ_ItemCostFullId;
		DKEPCPPCIKA_Price = dbItem2.CMEIMAMOMPI_Price;
		DJPBDDBNMLN_SakashoProductName = null;
		KAPMOPMDHJE_label = dbItem.ICKAMKNDAEB_Label;
		NFBLLKHBMEK_SakashoProductId = 0;
		PBNCFGDPJKG_DecoItemSet = EKLNMHFCAOI_ItemManager.PJMJIKKJAAM_GetDecoItemSet(IMMAOANGPNK_NetMasterDataManager.HHCJCDFCLOB_Instance.NKEBMCIMJND_Database, EKLNMHFCAOI_ItemManager.BKHFLDMOGBD_GetItemCategory(KIJAPOFAGPN_ItemId), EKLNMHFCAOI_ItemManager.DEACAHNLMNI_getItemId(KIJAPOFAGPN_ItemId));
		EKLNMHFCAOI_ItemManager.FKGCBLHOOCL_Category cat = EKLNMHFCAOI_ItemManager.BKHFLDMOGBD_GetItemCategory(JPJMHLNOIAJ_ItemCostFullId);
		if(cat == EKLNMHFCAOI_ItemManager.FKGCBLHOOCL_Category.IBBDMIFICCN_BonusVC)
		{
			//EKLNMHFCAOI_ItemManager.DEACAHNLMNI_getItemId(JPJMHLNOIAJ_ItemCostFullId);
			for(int i = 0; i < IMMAOANGPNK_NetMasterDataManager.HHCJCDFCLOB_Instance.NKEBMCIMJND_Database.NBKNAAPBFFL_BonusVc.CDENCMNHNGA_table.Count; i++)
			{
				HHJHIFJIKAC_BonusVc.MNGJPJBCMBH bonusVc = IMMAOANGPNK_NetMasterDataManager.HHCJCDFCLOB_Instance.NKEBMCIMJND_Database.NBKNAAPBFFL_BonusVc.CDENCMNHNGA_table[i];
				if(bonusVc.INDDJNMPONH_type == 1)
				{
					if(bonusVc.JBGEEPFKIGG_val == dbItem3.JPGALGPNJAI_VcId)
					{
						JPJMHLNOIAJ_ItemCostFullId = EKLNMHFCAOI_ItemManager.GJEEGMCBGGM_GetItemFullId(EKLNMHFCAOI_ItemManager.FKGCBLHOOCL_Category.IBBDMIFICCN_BonusVC, bonusVc.PPFNGGCBJKC_id);
						break;
					}
				}
			}
		}
		else if(cat == EKLNMHFCAOI_ItemManager.FKGCBLHOOCL_Category.ADCAAALBAIF_Medal)
		{
			int id = EKLNMHFCAOI_ItemManager.DEACAHNLMNI_getItemId(JPJMHLNOIAJ_ItemCostFullId);
			HHFFOACILKG_Medal.HCFJGDFMHOJ dbMedal = IMMAOANGPNK_NetMasterDataManager.HHCJCDFCLOB_Instance.NKEBMCIMJND_Database.ICICKEBMEFA_Medal.CDENCMNHNGA_table[id - 1];
			if(dbMedal.GBJFNGCDKPM_typ == 1)
			{
				for(int i = 0; i < IMMAOANGPNK_NetMasterDataManager.HHCJCDFCLOB_Instance.NKEBMCIMJND_Database.ICICKEBMEFA_Medal.CDENCMNHNGA_table.Count; i++)
				{
					HHFFOACILKG_Medal.HCFJGDFMHOJ dbMedal2 = IMMAOANGPNK_NetMasterDataManager.HHCJCDFCLOB_Instance.NKEBMCIMJND_Database.ICICKEBMEFA_Medal.CDENCMNHNGA_table[i];
					if (dbMedal2.IBAKPKKEDJM_month == dbItem3.IBAKPKKEDJM_month)
					{
						JPJMHLNOIAJ_ItemCostFullId = EKLNMHFCAOI_ItemManager.GJEEGMCBGGM_GetItemFullId(EKLNMHFCAOI_ItemManager.FKGCBLHOOCL_Category.ADCAAALBAIF_Medal, dbMedal2.PPFNGGCBJKC_id);
						break;
					}
				}
			}
		}
		ELEPHBOKIGK_Limit = dbItem.JLENMGOCHDG_Count;
		JLENMGOCHDG_Count = ELEPHBOKIGK_Limit > 0 ? saveItem.KMFLNILNPJD_Cnt : 0;
		FPJBMCDMAMO = dbItem.FPJBMCDMAMO;
		JIHKOPIENAC = Utility.GetLocalDateTime(dbItem.GJFPFFBAKGK_CloseAt);
		EAPILIMHDNP_BuyLimitDate = dbItem.GJFPFFBAKGK_CloseAt;
		JANMJPOKLFL_InventoryUtil.JCHLONCMPAJ_Clear();
		EILKGEADKGH_Order = dbItem.EILKGEADKGH_Order;
		JNLPLBJKGDC = 99;
		if(_OPKDAIMPJBH_ShopId > 0)
		{
			if(dbItem3.HCCEFDMGPEA == 1)
			{
				CEBFFLDKAEC_SecureInt v = new CEBFFLDKAEC_SecureInt();
				if(IMMAOANGPNK_NetMasterDataManager.HHCJCDFCLOB_Instance.NKEBMCIMJND_Database.IFLGCDGOLOP_Shop.OHJFBLFELNK_m_intParam.TryGetValue("buy_count_once_sphere", out v))
				{
					JNLPLBJKGDC = v.DNJEJEANJGL_Value;
				}
				else
				{
					JNLPLBJKGDC = 10;
				}
			}
		}
	}

	//// RVA: 0x1180998 Offset: 0x1180998 VA: 0x1180998
	public void CLCJHOIDENO(int _DLLJMINACDN_ShopId, EKLNMHFCAOI_ItemManager.FKGCBLHOOCL_Category _HHACNFODNEF_ItemCategory, int _MHFBCINOJEE_Num, int JBIOKDFOCOJ, int PLBOJBHAPLO)
	{
		OPKDAIMPJBH_ShopId = _DLLJMINACDN_ShopId;
		JNLPLBJKGDC = 99;
		AFKAGFOFAHM_ProductId = 99;
		GJGNOFAPFJD = -1; // ffffffff
		KIJAPOFAGPN_ItemId = EKLNMHFCAOI_ItemManager.GJEEGMCBGGM_GetItemFullId(_HHACNFODNEF_ItemCategory, _MHFBCINOJEE_Num);
		JDLJPNMLFID_ItemCount = 1;
		JPJMHLNOIAJ_ItemCostFullId = EKLNMHFCAOI_ItemManager.GJEEGMCBGGM_GetItemFullId(EKLNMHFCAOI_ItemManager.FKGCBLHOOCL_Category.FMIIHMHKJDI_SpItem, 8);
		DKEPCPPCIKA_Price = PLBOJBHAPLO;
		PBNCFGDPJKG_DecoItemSet = EKLNMHFCAOI_ItemManager.PJMJIKKJAAM_GetDecoItemSet(IMMAOANGPNK_NetMasterDataManager.HHCJCDFCLOB_Instance.NKEBMCIMJND_Database, _HHACNFODNEF_ItemCategory, _MHFBCINOJEE_Num);
		FPJBMCDMAMO = 0;
		ELEPHBOKIGK_Limit = JBIOKDFOCOJ;
		JLENMGOCHDG_Count = EKLNMHFCAOI_ItemManager.ALHCGDMEMID_GetNumItems(IMMAOANGPNK_NetMasterDataManager.HHCJCDFCLOB_Instance.NKEBMCIMJND_Database, CIOECGOMILE_NetPlayerDataManager.HHCJCDFCLOB_Instance.AHEFHIMGIBI_PlayerData, _HHACNFODNEF_ItemCategory, _MHFBCINOJEE_Num, null);
		EHJBMHEAADC = true;
	}

	//// RVA: 0x1180BC4 Offset: 0x1180BC4 VA: 0x1180BC4
	public int DPFOJKHBBEH_GetNumCostItem()
	{
        EKLNMHFCAOI_ItemManager.FKGCBLHOOCL_Category cat = EKLNMHFCAOI_ItemManager.BKHFLDMOGBD_GetItemCategory(JPJMHLNOIAJ_ItemCostFullId);
		int id = EKLNMHFCAOI_ItemManager.DEACAHNLMNI_getItemId(JPJMHLNOIAJ_ItemCostFullId);
		return EKLNMHFCAOI_ItemManager.ALHCGDMEMID_GetNumItems(IMMAOANGPNK_NetMasterDataManager.HHCJCDFCLOB_Instance.NKEBMCIMJND_Database, CIOECGOMILE_NetPlayerDataManager.HHCJCDFCLOB_Instance.AHEFHIMGIBI_PlayerData, cat, id, null);
	}

	//// RVA: 0x1180D44 Offset: 0x1180D44 VA: 0x1180D44
	public int CMOPCCPOEBA()
	{
        EKLNMHFCAOI_ItemManager.FKGCBLHOOCL_Category cat = EKLNMHFCAOI_ItemManager.BKHFLDMOGBD_GetItemCategory(JPJMHLNOIAJ_ItemCostFullId);
		int id = EKLNMHFCAOI_ItemManager.DEACAHNLMNI_getItemId(JPJMHLNOIAJ_ItemCostFullId);
		int num = EKLNMHFCAOI_ItemManager.ALHCGDMEMID_GetNumItems(IMMAOANGPNK_NetMasterDataManager.HHCJCDFCLOB_Instance.NKEBMCIMJND_Database, CIOECGOMILE_NetPlayerDataManager.HHCJCDFCLOB_Instance.AHEFHIMGIBI_PlayerData, cat, id, null);
		if(!EHJBMHEAADC)
		{
			BKPAPCMJKHE_Shop.BOMCAJJCPME dbShop = IMMAOANGPNK_NetMasterDataManager.HHCJCDFCLOB_Instance.NKEBMCIMJND_Database.IFLGCDGOLOP_Shop.MHKCPJDNJKI_products[AFKAGFOFAHM_ProductId - 1];
			BKPAPCMJKHE_Shop.GPNPMJJKONJ dbShop2 = IMMAOANGPNK_NetMasterDataManager.HHCJCDFCLOB_Instance.NKEBMCIMJND_Database.IFLGCDGOLOP_Shop.HMKKLPPEOHL[dbShop.GJGNOFAPFJD - 1];
			return num / dbShop2.CMEIMAMOMPI_Price;
		}
		else
		{
			return num / DKEPCPPCIKA_Price;
		}
    }

	//// RVA: 0x1181014 Offset: 0x1181014 VA: 0x1181014
	public int PHBCFNIJLJH()
	{
        EKLNMHFCAOI_ItemManager.FKGCBLHOOCL_Category cat = EKLNMHFCAOI_ItemManager.BKHFLDMOGBD_GetItemCategory(KIJAPOFAGPN_ItemId);
		int id = EKLNMHFCAOI_ItemManager.DEACAHNLMNI_getItemId(KIJAPOFAGPN_ItemId);
		int num = EKLNMHFCAOI_ItemManager.DLNFNHMPGLI_GetNumClamped(IMMAOANGPNK_NetMasterDataManager.HHCJCDFCLOB_Instance.NKEBMCIMJND_Database, CIOECGOMILE_NetPlayerDataManager.HHCJCDFCLOB_Instance.AHEFHIMGIBI_PlayerData, cat, id, null);
		int max = EKLNMHFCAOI_ItemManager.EEIFENNHAHF_GetMax(IMMAOANGPNK_NetMasterDataManager.HHCJCDFCLOB_Instance.NKEBMCIMJND_Database, CIOECGOMILE_NetPlayerDataManager.HHCJCDFCLOB_Instance.AHEFHIMGIBI_PlayerData, cat, id, null);
		if(cat == EKLNMHFCAOI_ItemManager.FKGCBLHOOCL_Category.MHKFDBLMOGF_Scene)
		{
			max = 9999;
		}
		if(!EHJBMHEAADC)
		{
			BKPAPCMJKHE_Shop.BOMCAJJCPME dbShop = IMMAOANGPNK_NetMasterDataManager.HHCJCDFCLOB_Instance.NKEBMCIMJND_Database.IFLGCDGOLOP_Shop.MHKCPJDNJKI_products[AFKAGFOFAHM_ProductId - 1];
			BKPAPCMJKHE_Shop.GPNPMJJKONJ dbShop2 = IMMAOANGPNK_NetMasterDataManager.HHCJCDFCLOB_Instance.NKEBMCIMJND_Database.IFLGCDGOLOP_Shop.HMKKLPPEOHL[dbShop.GJGNOFAPFJD - 1];
			return (max - num) / dbShop2.LBCNKLPIMHL_Count;
		}
		else
		{
			return max - num;
		}
	}

	//// RVA: 0x1181304 Offset: 0x1181304 VA: 0x1181304
	public bool EMLHKJAPACA_IsAddOverflow(int _HMFFHLPNMPH_count)
	{
        EKLNMHFCAOI_ItemManager.FKGCBLHOOCL_Category cat = EKLNMHFCAOI_ItemManager.BKHFLDMOGBD_GetItemCategory(KIJAPOFAGPN_ItemId);
		int id = EKLNMHFCAOI_ItemManager.DEACAHNLMNI_getItemId(KIJAPOFAGPN_ItemId);
		int num = EKLNMHFCAOI_ItemManager.DLNFNHMPGLI_GetNumClamped(IMMAOANGPNK_NetMasterDataManager.HHCJCDFCLOB_Instance.NKEBMCIMJND_Database, CIOECGOMILE_NetPlayerDataManager.HHCJCDFCLOB_Instance.AHEFHIMGIBI_PlayerData, cat, id, null);
		int max = EKLNMHFCAOI_ItemManager.EEIFENNHAHF_GetMax(IMMAOANGPNK_NetMasterDataManager.HHCJCDFCLOB_Instance.NKEBMCIMJND_Database, CIOECGOMILE_NetPlayerDataManager.HHCJCDFCLOB_Instance.AHEFHIMGIBI_PlayerData, cat, id, null);
		if(cat == EKLNMHFCAOI_ItemManager.FKGCBLHOOCL_Category.MHKFDBLMOGF_Scene)
			max = 9999;
		if(cat == EKLNMHFCAOI_ItemManager.FKGCBLHOOCL_Category.ICJOEDJECAP_DecoSetItem)
		{
			bool b = true;
			if(num + _HMFFHLPNMPH_count <= max)
			{
				BBLECJKKKLA_DecoSetItem.GJBPBKNHLHC_DecoSetItemInfo dbItem = IMMAOANGPNK_NetMasterDataManager.HHCJCDFCLOB_Instance.NKEBMCIMJND_Database.MJALLIOHKEJ_DecoSetItem.CDENCMNHNGA_table[id - 1];
				int a = 0;
				for(int i = 0; i < dbItem.JJBNDDDGEAN_GetNumItems(); i++)
				{
					int subItemId = dbItem.FKNBLDPIPMC_GetItemCode(i);
					int d = dbItem.NKOHMLHLJGL_GetItemCount(i);
                    EKLNMHFCAOI_ItemManager.FKGCBLHOOCL_Category cat2 = EKLNMHFCAOI_ItemManager.BKHFLDMOGBD_GetItemCategory(subItemId);
					int id2 = EKLNMHFCAOI_ItemManager.DEACAHNLMNI_getItemId(subItemId);
					int num2 = EKLNMHFCAOI_ItemManager.DLNFNHMPGLI_GetNumClamped(IMMAOANGPNK_NetMasterDataManager.HHCJCDFCLOB_Instance.NKEBMCIMJND_Database, CIOECGOMILE_NetPlayerDataManager.HHCJCDFCLOB_Instance.AHEFHIMGIBI_PlayerData, cat2, id2, null);
					int max2 = EKLNMHFCAOI_ItemManager.EEIFENNHAHF_GetMax(IMMAOANGPNK_NetMasterDataManager.HHCJCDFCLOB_Instance.NKEBMCIMJND_Database, CIOECGOMILE_NetPlayerDataManager.HHCJCDFCLOB_Instance.AHEFHIMGIBI_PlayerData, cat2, id2, null);
					if(max2 < num2 + d)
						a++;
                }
				b = dbItem.JJBNDDDGEAN_GetNumItems() <= a;
			}
			return b;
		}
		else
		{
			if(!EHJBMHEAADC)
			{
				BKPAPCMJKHE_Shop.BOMCAJJCPME dbShop = IMMAOANGPNK_NetMasterDataManager.HHCJCDFCLOB_Instance.NKEBMCIMJND_Database.IFLGCDGOLOP_Shop.MHKCPJDNJKI_products[AFKAGFOFAHM_ProductId - 1];
				BKPAPCMJKHE_Shop.GPNPMJJKONJ dbShop2 = IMMAOANGPNK_NetMasterDataManager.HHCJCDFCLOB_Instance.NKEBMCIMJND_Database.IFLGCDGOLOP_Shop.HMKKLPPEOHL[dbShop.GJGNOFAPFJD - 1];
				_HMFFHLPNMPH_count *= dbShop2.LBCNKLPIMHL_Count;
			}
			if(max < num + _HMFFHLPNMPH_count)
				return true;
			return false;
		}
    }

	//// RVA: 0x1181800 Offset: 0x1181800 VA: 0x1181800
	public int EAIJAAEKDAB_GetNumRemain()
	{
		if(!EHJBMHEAADC)
		{
			BKPAPCMJKHE_Shop.BOMCAJJCPME dbShop = IMMAOANGPNK_NetMasterDataManager.HHCJCDFCLOB_Instance.NKEBMCIMJND_Database.IFLGCDGOLOP_Shop.MHKCPJDNJKI_products[AFKAGFOFAHM_ProductId - 1];
			BKPAPCMJKHE_Shop.GPNPMJJKONJ dbShop2 = IMMAOANGPNK_NetMasterDataManager.HHCJCDFCLOB_Instance.NKEBMCIMJND_Database.IFLGCDGOLOP_Shop.HMKKLPPEOHL[dbShop.GJGNOFAPFJD - 1];
			GBEFGAIGGHA_Shop.DPGGLKKBNBJ saveShop = CIOECGOMILE_NetPlayerDataManager.HHCJCDFCLOB_Instance.AHEFHIMGIBI_PlayerData.IJOHDAJMBAL_Shop.ECMLOMPGMLC[AFKAGFOFAHM_ProductId - 1];
			if(EKLNMHFCAOI_ItemManager.BKHFLDMOGBD_GetItemCategory(JPJMHLNOIAJ_ItemCostFullId) == EKLNMHFCAOI_ItemManager.FKGCBLHOOCL_Category.IBBDMIFICCN_BonusVC)
			{
				if(GLHFDCKOJDN == null)
					return 0;
				KBPDNHOKEKD_ProductId p = GLHFDCKOJDN.LBDOLHGDIEB_Find(KAPMOPMDHJE_label);
				if(p == null)
					return -1;
				if(p.HMFDJHEEGNN_buy_limit < 1)
					return -1;
				return p.HMFDJHEEGNN_buy_limit - p.GIEBJDKLCDH_bought_quantity;
			}
			if(dbShop.JLENMGOCHDG_Count > 0)
			{
				return dbShop.JLENMGOCHDG_Count - saveShop.KMFLNILNPJD_Cnt;
			}
		}
		else if(ELEPHBOKIGK_Limit > 0)
		{
			int d = ELEPHBOKIGK_Limit - EKLNMHFCAOI_ItemManager.ALHCGDMEMID_GetNumItems(IMMAOANGPNK_NetMasterDataManager.HHCJCDFCLOB_Instance.NKEBMCIMJND_Database, CIOECGOMILE_NetPlayerDataManager.HHCJCDFCLOB_Instance.AHEFHIMGIBI_PlayerData, EKLNMHFCAOI_ItemManager.BKHFLDMOGBD_GetItemCategory(KIJAPOFAGPN_ItemId), EKLNMHFCAOI_ItemManager.DEACAHNLMNI_getItemId(KIJAPOFAGPN_ItemId), null);
			if(d > 0)
				return d;
			return 0;
		}
		return -1;
	}

	//// RVA: 0x1181C34 Offset: 0x1181C34 VA: 0x1181C34
	public void PFIBEGFOBEG_Buy(int _JLENMGOCHDG_Count, IMCBBOAFION _BHFHGFKBOHH_OnSuccess, JFDNPFFOACP NIMPEHIECJH, DJBHIFLHJLK _AOCANKOMKFG_OnError)
	{
		N.a.StartCoroutineWatched(EHDNGPFPOKJ_Co_Buy(_JLENMGOCHDG_Count, _BHFHGFKBOHH_OnSuccess, NIMPEHIECJH, _AOCANKOMKFG_OnError));
	}

	//[IteratorStateMachineAttribute] // RVA: 0x741584 Offset: 0x741584 VA: 0x741584
	//// RVA: 0x1181CA4 Offset: 0x1181CA4 VA: 0x1181CA4
	private IEnumerator EHDNGPFPOKJ_Co_Buy(int _JLENMGOCHDG_Count, IMCBBOAFION _BHFHGFKBOHH_OnSuccess, JFDNPFFOACP NIMPEHIECJH, DJBHIFLHJLK _AOCANKOMKFG_OnError)
	{
		EKLNMHFCAOI_ItemManager.FKGCBLHOOCL_Category JDGLDMPOCKH_ConsumeItemCat;

		//0x1184DE8
		CNGFKOJANNP.HHCJCDFCLOB_Instance.BNGIDMBNILP_ManualCheck();
		IMMAOANGPNK_NetMasterDataManager.HHCJCDFCLOB_Instance.PFAKPFKJJKA();
		if(IMMAOANGPNK_NetMasterDataManager.HHCJCDFCLOB_Instance.ENEBEGGOHFP != 0)
		{
			yield return N.a.StartCoroutineWatched(NLFNKKCPGNJ_Co_Falsification(_AOCANKOMKFG_OnError));
		}
		else
		{
			FENCAJJBLBH f = CIOECGOMILE_NetPlayerDataManager.HHCJCDFCLOB_Instance.AHEFHIMGIBI_PlayerData.PFAKPFKJJKA(true);
			if(f == null)
			{
				if(_JLENMGOCHDG_Count > 0)
				{
					OKGLGHCBCJP_Database LKMHPJKIFDN_md = IMMAOANGPNK_NetMasterDataManager.HHCJCDFCLOB_Instance.NKEBMCIMJND_Database;
					BBHNACPENDM_ServerSaveData LDEGEHAEALK_ServerData = CIOECGOMILE_NetPlayerDataManager.HHCJCDFCLOB_Instance.AHEFHIMGIBI_PlayerData;
					BKPAPCMJKHE_Shop.DNOENEKHGMI CDMILJLEPHK = LKMHPJKIFDN_md.IFLGCDGOLOP_Shop.CDENCMNHNGA_table[OPKDAIMPJBH_ShopId -1];
					int remain = EAIJAAEKDAB_GetNumRemain();
					string str;
					if(remain < 0 || _JLENMGOCHDG_Count <= remain)
					{
						if(CMOPCCPOEBA() < _JLENMGOCHDG_Count)
						{
							str = JpStringLiterals.StringLiteral_10339;
						}
						else
						{
							EKLNMHFCAOI_ItemManager.FKGCBLHOOCL_Category BMAKHHKJNEG = EKLNMHFCAOI_ItemManager.BKHFLDMOGBD_GetItemCategory(JPJMHLNOIAJ_ItemCostFullId);
							int HAIIKPDDABC = EKLNMHFCAOI_ItemManager.DEACAHNLMNI_getItemId(JPJMHLNOIAJ_ItemCostFullId);
							JDGLDMPOCKH_ConsumeItemCat = BMAKHHKJNEG;
							int DFMCFJNBNJI_ConsumeItemId = HAIIKPDDABC;
							int numConsumeItemBefore = EKLNMHFCAOI_ItemManager.ALHCGDMEMID_GetNumItems(LKMHPJKIFDN_md, LDEGEHAEALK_ServerData, JDGLDMPOCKH_ConsumeItemCat, DFMCFJNBNJI_ConsumeItemId, null);
							int IFDHJKDDLIM_ConsumItemCount = 0;
							int BuyItemId = 0;
							int aa2 = 0;
							int MaxConsumeLimit = 0;
							if(!EHJBMHEAADC)
							{
								BKPAPCMJKHE_Shop.BOMCAJJCPME dbShop = LKMHPJKIFDN_md.IFLGCDGOLOP_Shop.MHKCPJDNJKI_products[AFKAGFOFAHM_ProductId - 1];
								BKPAPCMJKHE_Shop.GPNPMJJKONJ dbShop2 = LKMHPJKIFDN_md.IFLGCDGOLOP_Shop.HMKKLPPEOHL[dbShop.GJGNOFAPFJD - 1];
								IFDHJKDDLIM_ConsumItemCount = dbShop2.CMEIMAMOMPI_Price * _JLENMGOCHDG_Count;
								aa2 = dbShop2.LBCNKLPIMHL_Count;
								BuyItemId = dbShop2.EJHMPCJNHBP_ItemFullId;
								MaxConsumeLimit = dbShop.JLENMGOCHDG_Count;
							}
							else
							{
								IFDHJKDDLIM_ConsumItemCount = DKEPCPPCIKA_Price * _JLENMGOCHDG_Count;
								BuyItemId = KIJAPOFAGPN_ItemId;
								aa2 = JDLJPNMLFID_ItemCount;
								MaxConsumeLimit = EKLNMHFCAOI_ItemManager.AFEONHCADEL_GetMaxAllowed(LKMHPJKIFDN_md, LDEGEHAEALK_ServerData, BMAKHHKJNEG, DFMCFJNBNJI_ConsumeItemId, null);
							}
							if(JDGLDMPOCKH_ConsumeItemCat != EKLNMHFCAOI_ItemManager.FKGCBLHOOCL_Category.IBBDMIFICCN_BonusVC)
							{
								EKLNMHFCAOI_ItemManager.DPHGFMEPOCA_SetNumItems(LKMHPJKIFDN_md, LDEGEHAEALK_ServerData, JDGLDMPOCKH_ConsumeItemCat, DFMCFJNBNJI_ConsumeItemId, numConsumeItemBefore - IFDHJKDDLIM_ConsumItemCount, null);
								JANMJPOKLFL_InventoryUtil.JCHLONCMPAJ_Clear();
								if(!EHJBMHEAADC)
								{
									BKPAPCMJKHE_Shop.BOMCAJJCPME dbShop = LKMHPJKIFDN_md.IFLGCDGOLOP_Shop.MHKCPJDNJKI_products[AFKAGFOFAHM_ProductId - 1];
									BKPAPCMJKHE_Shop.DNOENEKHGMI dbShop2 = LKMHPJKIFDN_md.IFLGCDGOLOP_Shop.CDENCMNHNGA_table[OPKDAIMPJBH_ShopId - 1];
									object[] obj = new object[5]
									{
										dbShop2.NEMKDKDIIDK_ShopName,
										":",
										dbShop.EFNMDPKEJIM_LineupId,
										":",
										dbShop.AFKAGFOFAHM_ProductId
									};
									JANMJPOKLFL_InventoryUtil.FEGDNPIEKJC(OAGBCBBHMPF.COIIJOEKBDH_InventoryAddType.LJILBHPMPOG_15_Shop, string.Concat(obj));
								}
								else
								{
									JANMJPOKLFL_InventoryUtil.FEGDNPIEKJC(OAGBCBBHMPF.COIIJOEKBDH_InventoryAddType.ENGODNEBGJD_34_Deco, "");
								}
								JANMJPOKLFL_InventoryUtil.CPIICACGNBH_AddItem(LDEGEHAEALK_ServerData, BuyItemId, _JLENMGOCHDG_Count * aa2, null, 0);
								if(MaxConsumeLimit > 0 && !EHJBMHEAADC)
								{
									GBEFGAIGGHA_Shop.DPGGLKKBNBJ dbShop = LDEGEHAEALK_ServerData.IJOHDAJMBAL_Shop.ECMLOMPGMLC[AFKAGFOFAHM_ProductId - 1];
									dbShop.KMFLNILNPJD_Cnt += _JLENMGOCHDG_Count;
									dbShop.BEBJKJKBOGH_date = NKGJPJPHLIF_SakashoManager.HHCJCDFCLOB_Instance.IBLPICFDGOF_ServerRequester.FJDBNGEPKHL_Time.KMEFBNBFJHI_GetServerTime();
								}
								int BGHCIAOANCF_BuyItemId = KIJAPOFAGPN_ItemId;
								int GJNAOBBAPOF_BuyItemCount = _JLENMGOCHDG_Count * aa2;
								int PEKOLGMLJAL_AfterConsumeItemCount = EKLNMHFCAOI_ItemManager.ALHCGDMEMID_GetNumItems(LKMHPJKIFDN_md, LDEGEHAEALK_ServerData, JDGLDMPOCKH_ConsumeItemCat, DFMCFJNBNJI_ConsumeItemId, null);
								int FFBPGKHIKGD_AfterBuyItemCount = EKLNMHFCAOI_ItemManager.ALHCGDMEMID_GetNumItems(LKMHPJKIFDN_md, LDEGEHAEALK_ServerData, EKLNMHFCAOI_ItemManager.BKHFLDMOGBD_GetItemCategory(BGHCIAOANCF_BuyItemId), EKLNMHFCAOI_ItemManager.DEACAHNLMNI_getItemId(BGHCIAOANCF_BuyItemId), null);
								CIOECGOMILE_NetPlayerDataManager.HHCJCDFCLOB_Instance.AIKJMHBDABF_SavePlayerData(() =>
								{
									//0x11844D0
									CIOECGOMILE_NetPlayerDataManager.HHCJCDFCLOB_Instance.AHEFHIMGIBI_PlayerData.OEKEIGFAIGN_Counter.BDLNMOIOMHK_total.AGNDGJOPIDL_AddShop(_JLENMGOCHDG_Count);
									if(BMAKHHKJNEG == EKLNMHFCAOI_ItemManager.FKGCBLHOOCL_Category.FMIIHMHKJDI_SpItem)
									{
										if(HAIIKPDDABC == 8)
										{
											CIOECGOMILE_NetPlayerDataManager.HHCJCDFCLOB_Instance.AHEFHIMGIBI_PlayerData.OEKEIGFAIGN_Counter.BDLNMOIOMHK_total.MFCKAGIINJL_AddDecoShop(_JLENMGOCHDG_Count);
										}
									}
									if(GNGMCIAIKMA.HHCJCDFCLOB_Instance != null)
									{
										GNGMCIAIKMA.HHCJCDFCLOB_Instance.GJENEJOANEL(DKFJADMCNPI.NLKCMNHOBAI_BingoMissionType.CLJMJHDGPOC_1_Shop, 0, _JLENMGOCHDG_Count, null);
										if(BMAKHHKJNEG == EKLNMHFCAOI_ItemManager.FKGCBLHOOCL_Category.ADCAAALBAIF_Medal)
										{
											if(DFMCFJNBNJI_ConsumeItemId > 0)
											{
												if(DFMCFJNBNJI_ConsumeItemId < 13)
												{
													GNGMCIAIKMA.HHCJCDFCLOB_Instance.GJENEJOANEL(DKFJADMCNPI.NLKCMNHOBAI_BingoMissionType.OBNEIGIFMFD_13_MedalShopConsume, BGHCIAOANCF_BuyItemId, _JLENMGOCHDG_Count, null);
												}
											}
										}
										GNGMCIAIKMA.HHCJCDFCLOB_Instance.HEFIKPAHCIA_UpdateMission(null, -1);
									}
									if(!EHJBMHEAADC)
									{
										BKPAPCMJKHE_Shop.BOMCAJJCPME dbShop = LKMHPJKIFDN_md.IFLGCDGOLOP_Shop.MHKCPJDNJKI_products[AFKAGFOFAHM_ProductId - 1];
										ILCCJNDFFOB.HHCJCDFCLOB_Instance.DBNECDJCNOI_ShopBuy(OPKDAIMPJBH_ShopId, CDMILJLEPHK.NEMKDKDIIDK_ShopName, dbShop.EFNMDPKEJIM_LineupId, AFKAGFOFAHM_ProductId, JPJMHLNOIAJ_ItemCostFullId, IFDHJKDDLIM_ConsumItemCount, PEKOLGMLJAL_AfterConsumeItemCount, BGHCIAOANCF_BuyItemId, GJNAOBBAPOF_BuyItemCount, FFBPGKHIKGD_AfterBuyItemCount, _JLENMGOCHDG_Count, JLENMGOCHDG_Count, dbShop.JLENMGOCHDG_Count, EAPILIMHDNP_BuyLimitDate, 0, null);
									}
									else
									{
										ILCCJNDFFOB.HHCJCDFCLOB_Instance.FJIPPAPEBID_DecoBuy(JPJMHLNOIAJ_ItemCostFullId, IFDHJKDDLIM_ConsumItemCount, PEKOLGMLJAL_AfterConsumeItemCount, BGHCIAOANCF_BuyItemId, GJNAOBBAPOF_BuyItemCount, FFBPGKHIKGD_AfterBuyItemCount, _JLENMGOCHDG_Count, JLENMGOCHDG_Count, EKLNMHFCAOI_ItemManager.AFEONHCADEL_GetMaxAllowed(LKMHPJKIFDN_md, LDEGEHAEALK_ServerData, EKLNMHFCAOI_ItemManager.BKHFLDMOGBD_GetItemCategory(BGHCIAOANCF_BuyItemId), EKLNMHFCAOI_ItemManager.DEACAHNLMNI_getItemId(BGHCIAOANCF_BuyItemId), null), EAPILIMHDNP_BuyLimitDate);
									}
									_BHFHGFKBOHH_OnSuccess();
								}, () =>
								{
									//0x1183A4C
									_AOCANKOMKFG_OnError();
								}, null);
								yield break;
							}
							if(GLHFDCKOJDN != null)
							{
								BKPAPCMJKHE_Shop.BOMCAJJCPME MABBBOEAPAA_p = LKMHPJKIFDN_md.IFLGCDGOLOP_Shop.MHKCPJDNJKI_products[AFKAGFOFAHM_ProductId - 1];
								BKPAPCMJKHE_Shop.DNOENEKHGMI dbShop2 = LKMHPJKIFDN_md.IFLGCDGOLOP_Shop.CDENCMNHNGA_table[OPKDAIMPJBH_ShopId - 1];
								JANMJPOKLFL_InventoryUtil.JCHLONCMPAJ_Clear();
								object[] obj = new object[5]
								{
									dbShop2.NEMKDKDIIDK_ShopName,
									":",
									MABBBOEAPAA_p.EFNMDPKEJIM_LineupId,
									":",
									MABBBOEAPAA_p.AFKAGFOFAHM_ProductId
								};
								JANMJPOKLFL_InventoryUtil.FEGDNPIEKJC(OAGBCBBHMPF.COIIJOEKBDH_InventoryAddType.LJILBHPMPOG_15_Shop, string.Concat(obj));
								bool BEKAMBBOLBO_Done = false;
								bool CNAIDEAFAAM_Error = false;
								bool GIGHIFOIMNA = false;
								int FFBPGKHIKGD_AfterBuyItemCount = 0;
								int BGHCIAOANCF_BuyItemId = 0;
								int GJNAOBBAPOF_BuyItemCount = 0;
								List<long> AMOMNBEAHBF_InventoryIds = new List<long>();
								GLHFDCKOJDN.GBMFNHOFGOP_Purchase(KAPMOPMDHJE_label, _JLENMGOCHDG_Count, (BEAOCBFAHKF _NFEAMMJIMPG_Result, int GJJFLICJBKC, int _JNBONMFLGNO_QuantityCrypted, int OJPMOABFGMA) =>
								{
									//0x1183A80
									for(int i = 0; i < _NFEAMMJIMPG_Result.PJJFEAHIPGL_inventories.Count; i++)
									{
										BGHCIAOANCF_BuyItemId = _NFEAMMJIMPG_Result.PJJFEAHIPGL_inventories[i].JJBGOIMEIPF_ItemId;
										GJNAOBBAPOF_BuyItemCount = _NFEAMMJIMPG_Result.PJJFEAHIPGL_inventories[i].MBJIFDBEDAC_item_count + GJNAOBBAPOF_BuyItemCount;
										JANMJPOKLFL_InventoryUtil.CPIICACGNBH_AddItem(LDEGEHAEALK_ServerData, _NFEAMMJIMPG_Result.PJJFEAHIPGL_inventories[i].NPPNDDMPFJJ_ItemCategory, _NFEAMMJIMPG_Result.PJJFEAHIPGL_inventories[i].OCNINMIMHGC_item_value, _NFEAMMJIMPG_Result.PJJFEAHIPGL_inventories[i].MBJIFDBEDAC_item_count, null, 0);
										AMOMNBEAHBF_InventoryIds.Add(_NFEAMMJIMPG_Result.PJJFEAHIPGL_inventories[i].MDPJFPHOPCH_Id);
									}
									BEKAMBBOLBO_Done = true;
								}, () =>
								{
									//0x1183DDC
									BEKAMBBOLBO_Done = true;
									GIGHIFOIMNA = true;
								}, () =>
								{
									//0x1183DE8
									CNAIDEAFAAM_Error = true;
									BEKAMBBOLBO_Done = true;
								});
								//LAB_01184ed0
								while(!BEKAMBBOLBO_Done)
									yield return null;
								if(CNAIDEAFAAM_Error)
								{
									_AOCANKOMKFG_OnError();
									yield break;
								}
								if(!GIGHIFOIMNA)
								{
									int PEKOLGMLJAL_AfterConsumeItemCount = EKLNMHFCAOI_ItemManager.ALHCGDMEMID_GetNumItems(LKMHPJKIFDN_md, LDEGEHAEALK_ServerData, JDGLDMPOCKH_ConsumeItemCat, DFMCFJNBNJI_ConsumeItemId, null);
									FFBPGKHIKGD_AfterBuyItemCount = EKLNMHFCAOI_ItemManager.ALHCGDMEMID_GetNumItems(LKMHPJKIFDN_md, LDEGEHAEALK_ServerData, EKLNMHFCAOI_ItemManager.BKHFLDMOGBD_GetItemCategory(BGHCIAOANCF_BuyItemId), EKLNMHFCAOI_ItemManager.DEACAHNLMNI_getItemId(BGHCIAOANCF_BuyItemId), null);
									CIOECGOMILE_NetPlayerDataManager.HHCJCDFCLOB_Instance.AIKJMHBDABF_SavePlayerData(() =>
									{
										//0x1183DF8
										CIOECGOMILE_NetPlayerDataManager.HHCJCDFCLOB_Instance.AHEFHIMGIBI_PlayerData.OEKEIGFAIGN_Counter.BDLNMOIOMHK_total.AGNDGJOPIDL_AddShop(_JLENMGOCHDG_Count);
										if(BMAKHHKJNEG == EKLNMHFCAOI_ItemManager.FKGCBLHOOCL_Category.FMIIHMHKJDI_SpItem)
										{
											if(HAIIKPDDABC == 8)
											{
												CIOECGOMILE_NetPlayerDataManager.HHCJCDFCLOB_Instance.AHEFHIMGIBI_PlayerData.OEKEIGFAIGN_Counter.BDLNMOIOMHK_total.MFCKAGIINJL_AddDecoShop(_JLENMGOCHDG_Count);
											}
										}
										if(GNGMCIAIKMA.HHCJCDFCLOB_Instance != null)
										{
											GNGMCIAIKMA.HHCJCDFCLOB_Instance.GJENEJOANEL(DKFJADMCNPI.NLKCMNHOBAI_BingoMissionType.CLJMJHDGPOC_1_Shop, 0, _JLENMGOCHDG_Count, null);
											if(BMAKHHKJNEG == EKLNMHFCAOI_ItemManager.FKGCBLHOOCL_Category.ADCAAALBAIF_Medal)
											{
												if(DFMCFJNBNJI_ConsumeItemId > 0)
												{
													if(DFMCFJNBNJI_ConsumeItemId < 13)
													{
														GNGMCIAIKMA.HHCJCDFCLOB_Instance.GJENEJOANEL(DKFJADMCNPI.NLKCMNHOBAI_BingoMissionType.OBNEIGIFMFD_13_MedalShopConsume, BGHCIAOANCF_BuyItemId, _JLENMGOCHDG_Count, null);
													}
												}
											}
											GNGMCIAIKMA.HHCJCDFCLOB_Instance.HEFIKPAHCIA_UpdateMission(null, -1);
										}
										EOJNOOHFOKA(GLHFDCKOJDN);
										ILCCJNDFFOB.HHCJCDFCLOB_Instance.DBNECDJCNOI_ShopBuy(OPKDAIMPJBH_ShopId, CDMILJLEPHK.NEMKDKDIIDK_ShopName, MABBBOEAPAA_p.EFNMDPKEJIM_LineupId, AFKAGFOFAHM_ProductId, JPJMHLNOIAJ_ItemCostFullId, IFDHJKDDLIM_ConsumItemCount, PEKOLGMLJAL_AfterConsumeItemCount, BGHCIAOANCF_BuyItemId, GJNAOBBAPOF_BuyItemCount, FFBPGKHIKGD_AfterBuyItemCount, _JLENMGOCHDG_Count, JLENMGOCHDG_Count, MABBBOEAPAA_p.JLENMGOCHDG_Count, EAPILIMHDNP_BuyLimitDate, NFBLLKHBMEK_SakashoProductId, DJPBDDBNMLN_SakashoProductName);
										_BHFHGFKBOHH_OnSuccess();
									}, () =>
									{
										//0x1183A20
										_AOCANKOMKFG_OnError();
									}, AMOMNBEAHBF_InventoryIds);
									yield break;
								}
								else
								{
									NIMPEHIECJH();
									yield break;
								}
							}
							str = JpStringLiterals.StringLiteral_10340;
						}
					}
					else
					{
						str = JpStringLiterals.StringLiteral_10338;
					}
					Debug.Log(str);
					NIMPEHIECJH();
					yield break;
				}
				yield return N.a.StartCoroutineWatched(NLFNKKCPGNJ_Co_Falsification(_AOCANKOMKFG_OnError));
			}
			else
			{
				yield return N.a.StartCoroutineWatched(NLFNKKCPGNJ_Co_Falsification(_AOCANKOMKFG_OnError));
			}
		}
		
	}

	//[IteratorStateMachineAttribute] // RVA: 0x7415FC Offset: 0x7415FC VA: 0x7415FC
	//// RVA: 0x1181DB8 Offset: 0x1181DB8 VA: 0x1181DB8
	private IEnumerator NLFNKKCPGNJ_Co_Falsification(DJBHIFLHJLK _AOCANKOMKFG_OnError)
	{
		TodoLogger.LogError(TodoLogger.DbIntegrityCheck, "NLFNKKCPGNJ_Co_Falsification");
		yield return null;
	}

	//// RVA: 0x1181E64 Offset: 0x1181E64 VA: 0x1181E64
	public void EOJNOOHFOKA(IGCPCHNCJCF_NetShopManager GLHFDCKOJDN)
	{
		this.GLHFDCKOJDN = GLHFDCKOJDN;
		KBPDNHOKEKD_ProductId k = GLHFDCKOJDN.LBDOLHGDIEB_Find(KAPMOPMDHJE_label);
		if(k != null)
		{
			JIHKOPIENAC = Utility.GetLocalDateTime(k.EGBOHDFBAPB_closed_at);
			ELEPHBOKIGK_Limit = k.HMFDJHEEGNN_buy_limit;
			DKEPCPPCIKA_Price = k.NPPGKNGIFGK_price;
			JLENMGOCHDG_Count = k.GIEBJDKLCDH_bought_quantity;
			DJPBDDBNMLN_SakashoProductName = k.OPFGFINHFCE_name;
			NFBLLKHBMEK_SakashoProductId = k.PPFNGGCBJKC_id;
		}
	}

	//// RVA: 0x1181F9C Offset: 0x1181F9C VA: 0x1181F9C
	public static List<FJGOKILCBJA_ViewShopProductData> OHDOAMFIBCC(int _OPKDAIMPJBH_ShopId, int _EFNMDPKEJIM_LineupId, long _JHNMKKNEENE_Time)
	{
		List<FJGOKILCBJA_ViewShopProductData> res = new List<FJGOKILCBJA_ViewShopProductData>();
		NDBFKHKMMCE_DecoItem dbDecoItem = IMMAOANGPNK_NetMasterDataManager.HHCJCDFCLOB_Instance.NKEBMCIMJND_Database.EPAHOAKPAJJ_DecoItem;
		BKPAPCMJKHE_Shop dbShop = IMMAOANGPNK_NetMasterDataManager.HHCJCDFCLOB_Instance.NKEBMCIMJND_Database.IFLGCDGOLOP_Shop;
		int masterVersion = DIHHCBACKGG_DbSection.IEFOPDOOLOK_MasterVersion;
		for(int i = 0; i  < dbDecoItem.GJLHEJPHEDA_ItemsBg.Count; i++)
		{
			NDBFKHKMMCE_DecoItem.EHLEEEBJLAM_BgItem item = dbDecoItem.GJLHEJPHEDA_ItemsBg[i];
			if (item.PLALNIIBLOF_en == 2)
			{
				if(item.MLMCEBBDJOE <= masterVersion)
				{
					if(dbShop.JIFKFKJPANC(item.ODNILEDOAIP, _JHNMKKNEENE_Time))
					{
						FJGOKILCBJA_ViewShopProductData data = new FJGOKILCBJA_ViewShopProductData();
						data.CLCJHOIDENO(_OPKDAIMPJBH_ShopId, EKLNMHFCAOI_ItemManager.FKGCBLHOOCL_Category.GPMKJNDHDCP_DecoItemBg, item.PPFNGGCBJKC_id, 1, item.NPPGKNGIFGK_price);
						res.Add(data);
					}
				}
			}
		}
		for(int i = 0; i < dbDecoItem.GHOLIPLDMPJ_ItemsObj.Count; i++)
		{
			NDBFKHKMMCE_DecoItem.NIBEBIGPKLA_ObjItem item = dbDecoItem.GHOLIPLDMPJ_ItemsObj[i];
			if (item.PLALNIIBLOF_en == 2)
			{
				if (item.MLMCEBBDJOE <= masterVersion)
				{
					if (dbShop.JIFKFKJPANC(item.ODNILEDOAIP, _JHNMKKNEENE_Time))
					{
						FJGOKILCBJA_ViewShopProductData data = new FJGOKILCBJA_ViewShopProductData();
						data.CLCJHOIDENO(_OPKDAIMPJBH_ShopId, EKLNMHFCAOI_ItemManager.FKGCBLHOOCL_Category.OKPAJOALDCG_DecoItemObj, item.PPFNGGCBJKC_id, item.KEJMJPHFFOJ_Max, item.NPPGKNGIFGK_price);
						res.Add(data);
					}
				}
			}
		}
		for (int i = 0; i < dbDecoItem.COLIEKINOPB_ItemsPoster.Count; i++)
		{
			NDBFKHKMMCE_DecoItem.IEOEMNPLANK_PosterItem item = dbDecoItem.COLIEKINOPB_ItemsPoster[i];
			if (item.PLALNIIBLOF_en == 2)
			{
				if (item.MLMCEBBDJOE <= masterVersion)
				{
					if (dbShop.JIFKFKJPANC(item.ODNILEDOAIP, _JHNMKKNEENE_Time))
					{
						FJGOKILCBJA_ViewShopProductData data = new FJGOKILCBJA_ViewShopProductData();
						data.CLCJHOIDENO(_OPKDAIMPJBH_ShopId, EKLNMHFCAOI_ItemManager.FKGCBLHOOCL_Category.OOMMOOIIPJE_DecoItemPoster, item.PPFNGGCBJKC_id, item.KEJMJPHFFOJ_Max, item.NPPGKNGIFGK_price);
						res.Add(data);
					}
				}
			}
		}
		for (int i = 0; i < dbDecoItem.KHCACDIKJLG_Characters.Count; i++)
		{
			NDBFKHKMMCE_DecoItem.CCHHGIJMLBN_CharaItem item = dbDecoItem.KHCACDIKJLG_Characters[i];
			if (item.PLALNIIBLOF_en == 2)
			{
				if (item.MLMCEBBDJOE <= masterVersion)
				{
					if (dbShop.JIFKFKJPANC(item.ODNILEDOAIP, _JHNMKKNEENE_Time))
					{
						FJGOKILCBJA_ViewShopProductData data = new FJGOKILCBJA_ViewShopProductData();
						data.CLCJHOIDENO(_OPKDAIMPJBH_ShopId, EKLNMHFCAOI_ItemManager.FKGCBLHOOCL_Category.MCKHJLHKMJD_DecoItemChara, item.PPFNGGCBJKC_id, 1, item.NPPGKNGIFGK_price);
						res.Add(data);
					}
				}
			}
		}
		for (int i = 0; i < IMMAOANGPNK_NetMasterDataManager.HHCJCDFCLOB_Instance.NKEBMCIMJND_Database.GAPONCJOKAC_DecoStamp.DMKMNGELNAE_Serif.Count; i++)
		{
			IHFIAFDLAAK_DecoStamp.MCBOAJEIFNP item = IMMAOANGPNK_NetMasterDataManager.HHCJCDFCLOB_Instance.NKEBMCIMJND_Database.GAPONCJOKAC_DecoStamp.DMKMNGELNAE_Serif[i];
			if (item.PLALNIIBLOF_en == 2)
			{
				if (item.MLMCEBBDJOE <= masterVersion)
				{
					if (dbShop.JIFKFKJPANC(item.ODNILEDOAIP, _JHNMKKNEENE_Time))
					{
						FJGOKILCBJA_ViewShopProductData data = new FJGOKILCBJA_ViewShopProductData();
						data.CLCJHOIDENO(_OPKDAIMPJBH_ShopId, EKLNMHFCAOI_ItemManager.FKGCBLHOOCL_Category.ICIMCGOJEMD_StampItemSerif, item.PPFNGGCBJKC_id, 1, item.NPPGKNGIFGK_price);
						res.Add(data);
					}
				}
			}
		}
		for (int i = 0; i < IMMAOANGPNK_NetMasterDataManager.HHCJCDFCLOB_Instance.NKEBMCIMJND_Database.MJALLIOHKEJ_DecoSetItem.CDENCMNHNGA_table.Count; i++)
		{
			BBLECJKKKLA_DecoSetItem.GJBPBKNHLHC_DecoSetItemInfo item = IMMAOANGPNK_NetMasterDataManager.HHCJCDFCLOB_Instance.NKEBMCIMJND_Database.MJALLIOHKEJ_DecoSetItem.CDENCMNHNGA_table[i];
			if (item.PLALNIIBLOF_en == 2)
			{
				if (item.MLMCEBBDJOE <= masterVersion)
				{
					if (dbShop.JIFKFKJPANC(item.ODNILEDOAIP, _JHNMKKNEENE_Time))
					{
						FJGOKILCBJA_ViewShopProductData data = new FJGOKILCBJA_ViewShopProductData();
						data.CLCJHOIDENO(_OPKDAIMPJBH_ShopId, EKLNMHFCAOI_ItemManager.FKGCBLHOOCL_Category.ICJOEDJECAP_DecoSetItem, item.PPFNGGCBJKC_id, item.KEJMJPHFFOJ_Max, item.NPPGKNGIFGK_price);
						res.Add(data);
					}
				}
			}
		}
		return res;
	}

	//// RVA: 0x11833FC Offset: 0x11833FC VA: 0x11833FC
	public static List<FJGOKILCBJA_ViewShopProductData> FKDIMODKKJD_GetList(int _OPKDAIMPJBH_ShopId, int _EFNMDPKEJIM_LineupId, long _JHNMKKNEENE_Time)
	{
		BKPAPCMJKHE_Shop shop = IMMAOANGPNK_NetMasterDataManager.HHCJCDFCLOB_Instance.NKEBMCIMJND_Database.IFLGCDGOLOP_Shop;
		BKPAPCMJKHE_Shop.DNOENEKHGMI dbShop = shop.CDENCMNHNGA_table[_OPKDAIMPJBH_ShopId - 1];
		if(dbShop.HCCEFDMGPEA == 5)
		{
			return OHDOAMFIBCC(_OPKDAIMPJBH_ShopId, _EFNMDPKEJIM_LineupId, _JHNMKKNEENE_Time);
		}
		List<FJGOKILCBJA_ViewShopProductData> l = new List<FJGOKILCBJA_ViewShopProductData>();
		for(int i = 0; i < shop.MHKCPJDNJKI_products.Count; i++)
		{
			if(shop.MHKCPJDNJKI_products[i].PPEGAKEIEGM_Enabled == 2 && shop.MHKCPJDNJKI_products[i].EFNMDPKEJIM_LineupId == _EFNMDPKEJIM_LineupId &&
				_JHNMKKNEENE_Time >= shop.MHKCPJDNJKI_products[i].KJBGCLPMLCG_OpenedAt && shop.MHKCPJDNJKI_products[i].GJFPFFBAKGK_CloseAt >= _JHNMKKNEENE_Time)
			{
				FJGOKILCBJA_ViewShopProductData data = new FJGOKILCBJA_ViewShopProductData();
				data.KHEKNNFCAOI_Init(_OPKDAIMPJBH_ShopId, shop.MHKCPJDNJKI_products[i].AFKAGFOFAHM_ProductId);
				l.Add(data);
			}
		}

		// UMO, Remove duplicate
		l.Sort((FJGOKILCBJA_ViewShopProductData _HKICMNAACDA_a, FJGOKILCBJA_ViewShopProductData _BNKHBCBJBKI_b) =>
		{
			return _HKICMNAACDA_a.KIJAPOFAGPN_ItemId.CompareTo(_BNKHBCBJBKI_b.KIJAPOFAGPN_ItemId);
		});
		for(int i = 0; i < l.Count; i++)
		{
			for(int j = i + 1; j < l.Count; j++)
			{
				if(l[j].KIJAPOFAGPN_ItemId != l[i].KIJAPOFAGPN_ItemId)
					break;
				if(l[j].JPJMHLNOIAJ_ItemCostFullId == l[i].JPJMHLNOIAJ_ItemCostFullId && 
					l[j].JDLJPNMLFID_ItemCount == l[i].JDLJPNMLFID_ItemCount && 
					l[j].DKEPCPPCIKA_Price == l[i].DKEPCPPCIKA_Price)
				{
					l.RemoveAt(j);
					j--;
				}
			}
		}
		// End UMO

		l.Sort((FJGOKILCBJA_ViewShopProductData _HKICMNAACDA_a, FJGOKILCBJA_ViewShopProductData _BNKHBCBJBKI_b) =>
		{
			//0x11839D0
			return _HKICMNAACDA_a.EILKGEADKGH_Order.CompareTo(_BNKHBCBJBKI_b.EILKGEADKGH_Order);
		});
		return l;
	}
}
