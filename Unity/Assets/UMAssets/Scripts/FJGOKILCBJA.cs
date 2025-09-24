
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XeSys;

public class FJGOKILCBJA
{
	public int OPKDAIMPJBH_ShopId; // 0x8
	public int AFKAGFOFAHM_ProductId; // 0xC
	public int FPJBMCDMAMO; // 0x10
	public DateTime JIHKOPIENAC; // 0x18
	public long EAPILIMHDNP_BuyLimitDate; // 0x20
	public int EILKGEADKGH_Order; // 0x28
	public int KAPMOPMDHJE_label; // 0x2C
	public IGCPCHNCJCF GLHFDCKOJDN; // 0x30
	public JKNGJFOBADP JANMJPOKLFL_InventoryUtil = new JKNGJFOBADP(); // 0x34
	public int NGGNFHPOMOO_Crypted; // 0x38
	public int EKAPPBELKDA_Crypted; // 0x3C
	public int BOELIGECGJD_Crypted; // 0x40
	public int PIMKKONMBOG_ItemIdCrypted; // 0x44
	public int ALJGJMBFKHE_ItemCountCrypted; // 0x48
	public int AIDNHPGEHPM_MaxCountCrypted; // 0x4C
	public int CKNFCDCKFDE_Crypted; // 0x50
	public int LDLHJMBGGGJ_Crypted; // 0x54
	public int PAFAKOPJLEE_Crypted; // 0x58
	public int KEHENBMEFJN_Crypted; // 0x5C
	public string DJPBDDBNMLN_SakashoProductName; // 0x60
	public bool EHJBMHEAADC; // 0x64

	public int JNLPLBJKGDC { get { return PAFAKOPJLEE_Crypted ^ 0x74841479; } set { PAFAKOPJLEE_Crypted = value ^ 0x74841479; } } //0x117FBD8 HCDEEJAKFOF 0x117FBEC OCKKBHCFOEM
	public int GJGNOFAPFJD { get { return BOELIGECGJD_Crypted ^ 0x74841479; } set { BOELIGECGJD_Crypted = value ^ 0x74841479; } } //0x117FC00 JAGHPMNNEPG 0x117FC14 FACIELLBLMP
	public int KIJAPOFAGPN_ItemId { get { return PIMKKONMBOG_ItemIdCrypted ^ 0x51478174; } set { PIMKKONMBOG_ItemIdCrypted = value ^ 0x51478174; } } //0x117FC28 GCKKKIDNACI 0x117FC3C OGBLMPODGBG
	public int JDLJPNMLFID_ItemCount { get { return ALJGJMBFKHE_ItemCountCrypted ^ 0x137418ff; } set { ALJGJMBFKHE_ItemCountCrypted = value ^ 0x137418ff; } } //0x117FC50 BGIBDHCFJMN 0x117FC64 NDNEDCNDOGJ
	public int JPJMHLNOIAJ_ItemCostFullId { get { return NGGNFHPOMOO_Crypted ^ 0x137418ff; } set { NGGNFHPOMOO_Crypted = value ^ 0x137418ff; } } //0x117FC78 CFPIIDJJCHE 0x117FC8C PFKNCLBDBGH
	public int DKEPCPPCIKA_Price { get { return EKAPPBELKDA_Crypted ^ 0x374147ee; } set { EKAPPBELKDA_Crypted = value ^ 0x374147ee; } } //0x117FCA0 HPLCJFNDOKC 0x117FCB4 HNIDHAHIBLF
	public int ELEPHBOKIGK_Limit { get { return AIDNHPGEHPM_MaxCountCrypted ^ 0x247ef; } set { AIDNHPGEHPM_MaxCountCrypted = value ^ 0x247ef; } } //0x117FCC8 IIJFLONJAFL 0x117FCDC LHNFGPIGCNE
	public int JLENMGOCHDG_Count { get { return CKNFCDCKFDE_Crypted ^ 0x377247ef; } set { CKNFCDCKFDE_Crypted = value ^ 0x377247ef; } } //0x117FCF0 OLJEIELPFMC 0x117FD04 JMNGGBCNLJN
	public int PBNCFGDPJKG_DecoItemSet { get { return KEHENBMEFJN_Crypted ^ 0x141871f; } set { KEHENBMEFJN_Crypted = value ^ 0x141871f; } } //0x117FD18 LCKOMDHNEBF 0x117FD2C LPODAPEMLEA
	public int NFBLLKHBMEK { get { return LDLHJMBGGGJ_Crypted ^ 0x93a97a; } set { LDLHJMBGGGJ_Crypted = value ^ 0x93a97a; } } //0x117FD40 NCBIANHKGMG 0x117FD54 OFKJMDODHLO

	//// RVA: 0x117FD68 Offset: 0x117FD68 VA: 0x117FD68
	public void KHEKNNFCAOI_Init(int _OPKDAIMPJBH_ShopId, int _AFKAGFOFAHM_ProductId)
	{
		BKPAPCMJKHE_Shop.BOMCAJJCPME dbItem = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.IFLGCDGOLOP_Shop.MHKCPJDNJKI_products[_AFKAGFOFAHM_ProductId - 1];
		BKPAPCMJKHE_Shop.GPNPMJJKONJ dbItem2 = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.IFLGCDGOLOP_Shop.HMKKLPPEOHL[dbItem.GJGNOFAPFJD - 1];
		GBEFGAIGGHA_Shop.DPGGLKKBNBJ saveItem = CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_PlayerData.IJOHDAJMBAL_Shop.ECMLOMPGMLC[_AFKAGFOFAHM_ProductId - 1];
		BKPAPCMJKHE_Shop.DNOENEKHGMI dbItem3 = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.IFLGCDGOLOP_Shop.CDENCMNHNGA_table[_OPKDAIMPJBH_ShopId - 1];
		this.OPKDAIMPJBH_ShopId = _OPKDAIMPJBH_ShopId;
		this.AFKAGFOFAHM_ProductId = _AFKAGFOFAHM_ProductId;
		GJGNOFAPFJD = dbItem.GJGNOFAPFJD;
		KIJAPOFAGPN_ItemId = dbItem2.EJHMPCJNHBP_ItemFullId;
		JDLJPNMLFID_ItemCount = dbItem2.LBCNKLPIMHL_Count;
		JPJMHLNOIAJ_ItemCostFullId = dbItem2.LMMCMHHAGBJ_ItemCostFullId;
		DKEPCPPCIKA_Price = dbItem2.CMEIMAMOMPI_Price;
		DJPBDDBNMLN_SakashoProductName = null;
		KAPMOPMDHJE_label = dbItem.ICKAMKNDAEB_Label;
		NFBLLKHBMEK = 0;
		PBNCFGDPJKG_DecoItemSet = EKLNMHFCAOI.PJMJIKKJAAM_GetDecoItemSet(IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database, EKLNMHFCAOI.BKHFLDMOGBD_GetItemCategory(KIJAPOFAGPN_ItemId), EKLNMHFCAOI.DEACAHNLMNI_getItemId(KIJAPOFAGPN_ItemId));
		EKLNMHFCAOI.FKGCBLHOOCL_Category cat = EKLNMHFCAOI.BKHFLDMOGBD_GetItemCategory(JPJMHLNOIAJ_ItemCostFullId);
		if(cat == EKLNMHFCAOI.FKGCBLHOOCL_Category.IBBDMIFICCN_BonusVC)
		{
			//EKLNMHFCAOI.DEACAHNLMNI_getItemId(JPJMHLNOIAJ_ItemFullId2);
			for(int i = 0; i < IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.NBKNAAPBFFL_BonusVc.CDENCMNHNGA_table.Count; i++)
			{
				HHJHIFJIKAC_BonusVc.MNGJPJBCMBH bonusVc = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.NBKNAAPBFFL_BonusVc.CDENCMNHNGA_table[i];
				if(bonusVc.INDDJNMPONH_type == 1)
				{
					if(bonusVc.JBGEEPFKIGG_val == dbItem3.JPGALGPNJAI_VcId)
					{
						JPJMHLNOIAJ_ItemCostFullId = EKLNMHFCAOI.GJEEGMCBGGM_GetItemFullId(EKLNMHFCAOI.FKGCBLHOOCL_Category.IBBDMIFICCN_BonusVC, bonusVc.PPFNGGCBJKC_id);
						break;
					}
				}
			}
		}
		else if(cat == EKLNMHFCAOI.FKGCBLHOOCL_Category.ADCAAALBAIF_Medal)
		{
			int id = EKLNMHFCAOI.DEACAHNLMNI_getItemId(JPJMHLNOIAJ_ItemCostFullId);
			HHFFOACILKG_Medal.HCFJGDFMHOJ dbMedal = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.ICICKEBMEFA_Medal.CDENCMNHNGA_table[id - 1];
			if(dbMedal.GBJFNGCDKPM_typ == 1)
			{
				for(int i = 0; i < IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.ICICKEBMEFA_Medal.CDENCMNHNGA_table.Count; i++)
				{
					HHFFOACILKG_Medal.HCFJGDFMHOJ dbMedal2 = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.ICICKEBMEFA_Medal.CDENCMNHNGA_table[i];
					if (dbMedal2.IBAKPKKEDJM_month == dbItem3.IBAKPKKEDJM_month)
					{
						JPJMHLNOIAJ_ItemCostFullId = EKLNMHFCAOI.GJEEGMCBGGM_GetItemFullId(EKLNMHFCAOI.FKGCBLHOOCL_Category.ADCAAALBAIF_Medal, dbMedal2.PPFNGGCBJKC_id);
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
		JANMJPOKLFL_InventoryUtil.JCHLONCMPAJ();
		EILKGEADKGH_Order = dbItem.EILKGEADKGH_Order;
		JNLPLBJKGDC = 99;
		if(_OPKDAIMPJBH_ShopId > 0)
		{
			if(dbItem3.HCCEFDMGPEA == 1)
			{
				CEBFFLDKAEC_SecureInt v = new CEBFFLDKAEC_SecureInt();
				if(IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.IFLGCDGOLOP_Shop.OHJFBLFELNK_m_intParam.TryGetValue("buy_count_once_sphere", out v))
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
	public void CLCJHOIDENO(int DLLJMINACDN, EKLNMHFCAOI.FKGCBLHOOCL_Category _HHACNFODNEF_ItemCategory, int _MHFBCINOJEE_Num, int JBIOKDFOCOJ, int PLBOJBHAPLO)
	{
		OPKDAIMPJBH_ShopId = DLLJMINACDN;
		JNLPLBJKGDC = 99;
		AFKAGFOFAHM_ProductId = 99;
		GJGNOFAPFJD = -1; // ffffffff
		KIJAPOFAGPN_ItemId = EKLNMHFCAOI.GJEEGMCBGGM_GetItemFullId(_HHACNFODNEF_ItemCategory, _MHFBCINOJEE_Num);
		JDLJPNMLFID_ItemCount = 1;
		JPJMHLNOIAJ_ItemCostFullId = EKLNMHFCAOI.GJEEGMCBGGM_GetItemFullId(EKLNMHFCAOI.FKGCBLHOOCL_Category.FMIIHMHKJDI_SpItem, 8);
		DKEPCPPCIKA_Price = PLBOJBHAPLO;
		PBNCFGDPJKG_DecoItemSet = EKLNMHFCAOI.PJMJIKKJAAM_GetDecoItemSet(IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database, _HHACNFODNEF_ItemCategory, _MHFBCINOJEE_Num);
		FPJBMCDMAMO = 0;
		ELEPHBOKIGK_Limit = JBIOKDFOCOJ;
		JLENMGOCHDG_Count = EKLNMHFCAOI.ALHCGDMEMID_GetNumItems(IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database, CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_PlayerData, _HHACNFODNEF_ItemCategory, _MHFBCINOJEE_Num, null);
		EHJBMHEAADC = true;
	}

	//// RVA: 0x1180BC4 Offset: 0x1180BC4 VA: 0x1180BC4
	public int DPFOJKHBBEH_GetNumCostItem()
	{
        EKLNMHFCAOI.FKGCBLHOOCL_Category cat = EKLNMHFCAOI.BKHFLDMOGBD_GetItemCategory(JPJMHLNOIAJ_ItemCostFullId);
		int id = EKLNMHFCAOI.DEACAHNLMNI_getItemId(JPJMHLNOIAJ_ItemCostFullId);
		return EKLNMHFCAOI.ALHCGDMEMID_GetNumItems(IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database, CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_PlayerData, cat, id, null);
	}

	//// RVA: 0x1180D44 Offset: 0x1180D44 VA: 0x1180D44
	public int CMOPCCPOEBA()
	{
        EKLNMHFCAOI.FKGCBLHOOCL_Category cat = EKLNMHFCAOI.BKHFLDMOGBD_GetItemCategory(JPJMHLNOIAJ_ItemCostFullId);
		int id = EKLNMHFCAOI.DEACAHNLMNI_getItemId(JPJMHLNOIAJ_ItemCostFullId);
		int num = EKLNMHFCAOI.ALHCGDMEMID_GetNumItems(IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database, CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_PlayerData, cat, id, null);
		if(!EHJBMHEAADC)
		{
			BKPAPCMJKHE_Shop.BOMCAJJCPME dbShop = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.IFLGCDGOLOP_Shop.MHKCPJDNJKI_products[AFKAGFOFAHM_ProductId - 1];
			BKPAPCMJKHE_Shop.GPNPMJJKONJ dbShop2 = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.IFLGCDGOLOP_Shop.HMKKLPPEOHL[dbShop.GJGNOFAPFJD - 1];
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
        EKLNMHFCAOI.FKGCBLHOOCL_Category cat = EKLNMHFCAOI.BKHFLDMOGBD_GetItemCategory(KIJAPOFAGPN_ItemId);
		int id = EKLNMHFCAOI.DEACAHNLMNI_getItemId(KIJAPOFAGPN_ItemId);
		int num = EKLNMHFCAOI.DLNFNHMPGLI_GetNumClamped(IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database, CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_PlayerData, cat, id, null);
		int max = EKLNMHFCAOI.EEIFENNHAHF_GetMax(IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database, CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_PlayerData, cat, id, null);
		if(cat == EKLNMHFCAOI.FKGCBLHOOCL_Category.MHKFDBLMOGF_Scene)
		{
			max = 9999;
		}
		if(!EHJBMHEAADC)
		{
			BKPAPCMJKHE_Shop.BOMCAJJCPME dbShop = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.IFLGCDGOLOP_Shop.MHKCPJDNJKI_products[AFKAGFOFAHM_ProductId - 1];
			BKPAPCMJKHE_Shop.GPNPMJJKONJ dbShop2 = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.IFLGCDGOLOP_Shop.HMKKLPPEOHL[dbShop.GJGNOFAPFJD - 1];
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
        EKLNMHFCAOI.FKGCBLHOOCL_Category cat = EKLNMHFCAOI.BKHFLDMOGBD_GetItemCategory(KIJAPOFAGPN_ItemId);
		int id = EKLNMHFCAOI.DEACAHNLMNI_getItemId(KIJAPOFAGPN_ItemId);
		int num = EKLNMHFCAOI.DLNFNHMPGLI_GetNumClamped(IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database, CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_PlayerData, cat, id, null);
		int max = EKLNMHFCAOI.EEIFENNHAHF_GetMax(IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database, CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_PlayerData, cat, id, null);
		if(cat == EKLNMHFCAOI.FKGCBLHOOCL_Category.MHKFDBLMOGF_Scene)
			max = 9999;
		if(cat == EKLNMHFCAOI.FKGCBLHOOCL_Category.ICJOEDJECAP_DecoSetItem)
		{
			bool b = true;
			if(num + _HMFFHLPNMPH_count <= max)
			{
				BBLECJKKKLA_DecoSetItem.GJBPBKNHLHC_DecoSetItemInfo dbItem = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.MJALLIOHKEJ_DecoSetItem.CDENCMNHNGA_table[id - 1];
				int a = 0;
				for(int i = 0; i < dbItem.JJBNDDDGEAN_GetNumItems(); i++)
				{
					int subItemId = dbItem.FKNBLDPIPMC_GetItemCode(i);
					int d = dbItem.NKOHMLHLJGL(i);
                    EKLNMHFCAOI.FKGCBLHOOCL_Category cat2 = EKLNMHFCAOI.BKHFLDMOGBD_GetItemCategory(subItemId);
					int id2 = EKLNMHFCAOI.DEACAHNLMNI_getItemId(subItemId);
					int num2 = EKLNMHFCAOI.DLNFNHMPGLI_GetNumClamped(IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database, CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_PlayerData, cat2, id2, null);
					int max2 = EKLNMHFCAOI.EEIFENNHAHF_GetMax(IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database, CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_PlayerData, cat2, id2, null);
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
				BKPAPCMJKHE_Shop.BOMCAJJCPME dbShop = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.IFLGCDGOLOP_Shop.MHKCPJDNJKI_products[AFKAGFOFAHM_ProductId - 1];
				BKPAPCMJKHE_Shop.GPNPMJJKONJ dbShop2 = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.IFLGCDGOLOP_Shop.HMKKLPPEOHL[dbShop.GJGNOFAPFJD - 1];
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
			BKPAPCMJKHE_Shop.BOMCAJJCPME dbShop = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.IFLGCDGOLOP_Shop.MHKCPJDNJKI_products[AFKAGFOFAHM_ProductId - 1];
			BKPAPCMJKHE_Shop.GPNPMJJKONJ dbShop2 = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.IFLGCDGOLOP_Shop.HMKKLPPEOHL[dbShop.GJGNOFAPFJD - 1];
			GBEFGAIGGHA_Shop.DPGGLKKBNBJ saveShop = CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_PlayerData.IJOHDAJMBAL_Shop.ECMLOMPGMLC[AFKAGFOFAHM_ProductId - 1];
			if(EKLNMHFCAOI.BKHFLDMOGBD_GetItemCategory(JPJMHLNOIAJ_ItemCostFullId) == EKLNMHFCAOI.FKGCBLHOOCL_Category.IBBDMIFICCN_BonusVC)
			{
				if(GLHFDCKOJDN == null)
					return 0;
				KBPDNHOKEKD_ProductId p = GLHFDCKOJDN.LBDOLHGDIEB(KAPMOPMDHJE_label);
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
			int d = ELEPHBOKIGK_Limit - EKLNMHFCAOI.ALHCGDMEMID_GetNumItems(IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database, CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_PlayerData, EKLNMHFCAOI.BKHFLDMOGBD_GetItemCategory(KIJAPOFAGPN_ItemId), EKLNMHFCAOI.DEACAHNLMNI_getItemId(KIJAPOFAGPN_ItemId), null);
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
		EKLNMHFCAOI.FKGCBLHOOCL_Category JDGLDMPOCKH_ConsumeItemCat;

		//0x1184DE8
		CNGFKOJANNP.HHCJCDFCLOB.BNGIDMBNILP_ManualCheck();
		IMMAOANGPNK.HHCJCDFCLOB.PFAKPFKJJKA();
		if(IMMAOANGPNK.HHCJCDFCLOB.ENEBEGGOHFP != 0)
		{
			yield return N.a.StartCoroutineWatched(NLFNKKCPGNJ_Co_Falsification(_AOCANKOMKFG_OnError));
		}
		else
		{
			FENCAJJBLBH f = CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_PlayerData.PFAKPFKJJKA(true);
			if(f == null)
			{
				if(_JLENMGOCHDG_Count > 0)
				{
					OKGLGHCBCJP_Database LKMHPJKIFDN_md = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database;
					BBHNACPENDM_ServerSaveData LDEGEHAEALK_ServerData = CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_PlayerData;
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
							EKLNMHFCAOI.FKGCBLHOOCL_Category BMAKHHKJNEG = EKLNMHFCAOI.BKHFLDMOGBD_GetItemCategory(JPJMHLNOIAJ_ItemCostFullId);
							int HAIIKPDDABC = EKLNMHFCAOI.DEACAHNLMNI_getItemId(JPJMHLNOIAJ_ItemCostFullId);
							JDGLDMPOCKH_ConsumeItemCat = BMAKHHKJNEG;
							int DFMCFJNBNJI_ConsumeItemId = HAIIKPDDABC;
							int numConsumeItemBefore = EKLNMHFCAOI.ALHCGDMEMID_GetNumItems(LKMHPJKIFDN_md, LDEGEHAEALK_ServerData, JDGLDMPOCKH_ConsumeItemCat, DFMCFJNBNJI_ConsumeItemId, null);
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
								MaxConsumeLimit = EKLNMHFCAOI.AFEONHCADEL_GetMaxAllowed(LKMHPJKIFDN_md, LDEGEHAEALK_ServerData, BMAKHHKJNEG, DFMCFJNBNJI_ConsumeItemId, null);
							}
							if(JDGLDMPOCKH_ConsumeItemCat != EKLNMHFCAOI.FKGCBLHOOCL_Category.IBBDMIFICCN_BonusVC)
							{
								EKLNMHFCAOI.DPHGFMEPOCA_SetNumItems(LKMHPJKIFDN_md, LDEGEHAEALK_ServerData, JDGLDMPOCKH_ConsumeItemCat, DFMCFJNBNJI_ConsumeItemId, numConsumeItemBefore - IFDHJKDDLIM_ConsumItemCount, null);
								JANMJPOKLFL_InventoryUtil.JCHLONCMPAJ();
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
									JANMJPOKLFL_InventoryUtil.FEGDNPIEKJC(OAGBCBBHMPF.COIIJOEKBDH.LJILBHPMPOG_15, string.Concat(obj));
								}
								else
								{
									JANMJPOKLFL_InventoryUtil.FEGDNPIEKJC(OAGBCBBHMPF.COIIJOEKBDH.ENGODNEBGJD_34, "");
								}
								JANMJPOKLFL_InventoryUtil.CPIICACGNBH_AddItem(LDEGEHAEALK_ServerData, BuyItemId, _JLENMGOCHDG_Count * aa2, null, 0);
								if(MaxConsumeLimit > 0 && !EHJBMHEAADC)
								{
									GBEFGAIGGHA_Shop.DPGGLKKBNBJ dbShop = LDEGEHAEALK_ServerData.IJOHDAJMBAL_Shop.ECMLOMPGMLC[AFKAGFOFAHM_ProductId - 1];
									dbShop.KMFLNILNPJD_Cnt += _JLENMGOCHDG_Count;
									dbShop.BEBJKJKBOGH_date = NKGJPJPHLIF.HHCJCDFCLOB.IBLPICFDGOF_ServerRequester.FJDBNGEPKHL_Time.KMEFBNBFJHI_GetServerTime();
								}
								int BGHCIAOANCF_BuyItemId = KIJAPOFAGPN_ItemId;
								int GJNAOBBAPOF_BuyItemCount = _JLENMGOCHDG_Count * aa2;
								int PEKOLGMLJAL_AfterConsumeItemCount = EKLNMHFCAOI.ALHCGDMEMID_GetNumItems(LKMHPJKIFDN_md, LDEGEHAEALK_ServerData, JDGLDMPOCKH_ConsumeItemCat, DFMCFJNBNJI_ConsumeItemId, null);
								int FFBPGKHIKGD_AfterBuyItemCount = EKLNMHFCAOI.ALHCGDMEMID_GetNumItems(LKMHPJKIFDN_md, LDEGEHAEALK_ServerData, EKLNMHFCAOI.BKHFLDMOGBD_GetItemCategory(BGHCIAOANCF_BuyItemId), EKLNMHFCAOI.DEACAHNLMNI_getItemId(BGHCIAOANCF_BuyItemId), null);
								CIOECGOMILE.HHCJCDFCLOB.AIKJMHBDABF_SavePlayerData(() =>
								{
									//0x11844D0
									CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_PlayerData.OEKEIGFAIGN_Counter.BDLNMOIOMHK_total.AGNDGJOPIDL_AddShop(_JLENMGOCHDG_Count);
									if(BMAKHHKJNEG == EKLNMHFCAOI.FKGCBLHOOCL_Category.FMIIHMHKJDI_SpItem)
									{
										if(HAIIKPDDABC == 8)
										{
											CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_PlayerData.OEKEIGFAIGN_Counter.BDLNMOIOMHK_total.MFCKAGIINJL_AddDecoShop(_JLENMGOCHDG_Count);
										}
									}
									if(GNGMCIAIKMA.HHCJCDFCLOB != null)
									{
										GNGMCIAIKMA.HHCJCDFCLOB.GJENEJOANEL(DKFJADMCNPI.NLKCMNHOBAI.CLJMJHDGPOC_1, 0, _JLENMGOCHDG_Count, null);
										if(BMAKHHKJNEG == EKLNMHFCAOI.FKGCBLHOOCL_Category.ADCAAALBAIF_Medal)
										{
											if(DFMCFJNBNJI_ConsumeItemId > 0)
											{
												if(DFMCFJNBNJI_ConsumeItemId < 13)
												{
													GNGMCIAIKMA.HHCJCDFCLOB.GJENEJOANEL(DKFJADMCNPI.NLKCMNHOBAI.OBNEIGIFMFD_13, BGHCIAOANCF_BuyItemId, _JLENMGOCHDG_Count, null);
												}
											}
										}
										GNGMCIAIKMA.HHCJCDFCLOB.HEFIKPAHCIA_UpdateMission(null, -1);
									}
									if(!EHJBMHEAADC)
									{
										BKPAPCMJKHE_Shop.BOMCAJJCPME dbShop = LKMHPJKIFDN_md.IFLGCDGOLOP_Shop.MHKCPJDNJKI_products[AFKAGFOFAHM_ProductId - 1];
										ILCCJNDFFOB.HHCJCDFCLOB.DBNECDJCNOI(OPKDAIMPJBH_ShopId, CDMILJLEPHK.NEMKDKDIIDK_ShopName, dbShop.EFNMDPKEJIM_LineupId, AFKAGFOFAHM_ProductId, JPJMHLNOIAJ_ItemCostFullId, IFDHJKDDLIM_ConsumItemCount, PEKOLGMLJAL_AfterConsumeItemCount, BGHCIAOANCF_BuyItemId, GJNAOBBAPOF_BuyItemCount, FFBPGKHIKGD_AfterBuyItemCount, _JLENMGOCHDG_Count, JLENMGOCHDG_Count, dbShop.JLENMGOCHDG_Count, EAPILIMHDNP_BuyLimitDate, 0, null);
									}
									else
									{
										ILCCJNDFFOB.HHCJCDFCLOB.FJIPPAPEBID(JPJMHLNOIAJ_ItemCostFullId, IFDHJKDDLIM_ConsumItemCount, PEKOLGMLJAL_AfterConsumeItemCount, BGHCIAOANCF_BuyItemId, GJNAOBBAPOF_BuyItemCount, FFBPGKHIKGD_AfterBuyItemCount, _JLENMGOCHDG_Count, JLENMGOCHDG_Count, EKLNMHFCAOI.AFEONHCADEL_GetMaxAllowed(LKMHPJKIFDN_md, LDEGEHAEALK_ServerData, EKLNMHFCAOI.BKHFLDMOGBD_GetItemCategory(BGHCIAOANCF_BuyItemId), EKLNMHFCAOI.DEACAHNLMNI_getItemId(BGHCIAOANCF_BuyItemId), null), EAPILIMHDNP_BuyLimitDate);
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
								JANMJPOKLFL_InventoryUtil.JCHLONCMPAJ();
								object[] obj = new object[5]
								{
									dbShop2.NEMKDKDIIDK_ShopName,
									":",
									MABBBOEAPAA_p.EFNMDPKEJIM_LineupId,
									":",
									MABBBOEAPAA_p.AFKAGFOFAHM_ProductId
								};
								JANMJPOKLFL_InventoryUtil.FEGDNPIEKJC(OAGBCBBHMPF.COIIJOEKBDH.LJILBHPMPOG_15, string.Concat(obj));
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
									int PEKOLGMLJAL_AfterConsumeItemCount = EKLNMHFCAOI.ALHCGDMEMID_GetNumItems(LKMHPJKIFDN_md, LDEGEHAEALK_ServerData, JDGLDMPOCKH_ConsumeItemCat, DFMCFJNBNJI_ConsumeItemId, null);
									FFBPGKHIKGD_AfterBuyItemCount = EKLNMHFCAOI.ALHCGDMEMID_GetNumItems(LKMHPJKIFDN_md, LDEGEHAEALK_ServerData, EKLNMHFCAOI.BKHFLDMOGBD_GetItemCategory(BGHCIAOANCF_BuyItemId), EKLNMHFCAOI.DEACAHNLMNI_getItemId(BGHCIAOANCF_BuyItemId), null);
									CIOECGOMILE.HHCJCDFCLOB.AIKJMHBDABF_SavePlayerData(() =>
									{
										//0x1183DF8
										CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_PlayerData.OEKEIGFAIGN_Counter.BDLNMOIOMHK_total.AGNDGJOPIDL_AddShop(_JLENMGOCHDG_Count);
										if(BMAKHHKJNEG == EKLNMHFCAOI.FKGCBLHOOCL_Category.FMIIHMHKJDI_SpItem)
										{
											if(HAIIKPDDABC == 8)
											{
												CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_PlayerData.OEKEIGFAIGN_Counter.BDLNMOIOMHK_total.MFCKAGIINJL_AddDecoShop(_JLENMGOCHDG_Count);
											}
										}
										if(GNGMCIAIKMA.HHCJCDFCLOB != null)
										{
											GNGMCIAIKMA.HHCJCDFCLOB.GJENEJOANEL(DKFJADMCNPI.NLKCMNHOBAI.CLJMJHDGPOC_1, 0, _JLENMGOCHDG_Count, null);
											if(BMAKHHKJNEG == EKLNMHFCAOI.FKGCBLHOOCL_Category.ADCAAALBAIF_Medal)
											{
												if(DFMCFJNBNJI_ConsumeItemId > 0)
												{
													if(DFMCFJNBNJI_ConsumeItemId < 13)
													{
														GNGMCIAIKMA.HHCJCDFCLOB.GJENEJOANEL(DKFJADMCNPI.NLKCMNHOBAI.OBNEIGIFMFD_13, BGHCIAOANCF_BuyItemId, _JLENMGOCHDG_Count, null);
													}
												}
											}
											GNGMCIAIKMA.HHCJCDFCLOB.HEFIKPAHCIA_UpdateMission(null, -1);
										}
										EOJNOOHFOKA(GLHFDCKOJDN);
										ILCCJNDFFOB.HHCJCDFCLOB.DBNECDJCNOI(OPKDAIMPJBH_ShopId, CDMILJLEPHK.NEMKDKDIIDK_ShopName, MABBBOEAPAA_p.EFNMDPKEJIM_LineupId, AFKAGFOFAHM_ProductId, JPJMHLNOIAJ_ItemCostFullId, IFDHJKDDLIM_ConsumItemCount, PEKOLGMLJAL_AfterConsumeItemCount, BGHCIAOANCF_BuyItemId, GJNAOBBAPOF_BuyItemCount, FFBPGKHIKGD_AfterBuyItemCount, _JLENMGOCHDG_Count, JLENMGOCHDG_Count, MABBBOEAPAA_p.JLENMGOCHDG_Count, EAPILIMHDNP_BuyLimitDate, NFBLLKHBMEK, DJPBDDBNMLN_SakashoProductName);
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
	public void EOJNOOHFOKA(IGCPCHNCJCF GLHFDCKOJDN)
	{
		this.GLHFDCKOJDN = GLHFDCKOJDN;
		KBPDNHOKEKD_ProductId k = GLHFDCKOJDN.LBDOLHGDIEB(KAPMOPMDHJE_label);
		if(k != null)
		{
			JIHKOPIENAC = Utility.GetLocalDateTime(k.EGBOHDFBAPB_closed_at);
			ELEPHBOKIGK_Limit = k.HMFDJHEEGNN_buy_limit;
			DKEPCPPCIKA_Price = k.NPPGKNGIFGK_price;
			JLENMGOCHDG_Count = k.GIEBJDKLCDH_bought_quantity;
			DJPBDDBNMLN_SakashoProductName = k.OPFGFINHFCE_name;
			NFBLLKHBMEK = k.PPFNGGCBJKC_id;
		}
	}

	//// RVA: 0x1181F9C Offset: 0x1181F9C VA: 0x1181F9C
	public static List<FJGOKILCBJA> OHDOAMFIBCC(int _OPKDAIMPJBH_ShopId, int EFNMDPKEJIM, long _JHNMKKNEENE_Time)
	{
		List<FJGOKILCBJA> res = new List<FJGOKILCBJA>();
		NDBFKHKMMCE_DecoItem dbDecoItem = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.EPAHOAKPAJJ_DecoItem;
		BKPAPCMJKHE_Shop dbShop = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.IFLGCDGOLOP_Shop;
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
						FJGOKILCBJA data = new FJGOKILCBJA();
						data.CLCJHOIDENO(_OPKDAIMPJBH_ShopId, EKLNMHFCAOI.FKGCBLHOOCL_Category.GPMKJNDHDCP_DecoItemBg, item.PPFNGGCBJKC_id, 1, item.NPPGKNGIFGK_price);
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
						FJGOKILCBJA data = new FJGOKILCBJA();
						data.CLCJHOIDENO(_OPKDAIMPJBH_ShopId, EKLNMHFCAOI.FKGCBLHOOCL_Category.OKPAJOALDCG_DecoItemObj, item.PPFNGGCBJKC_id, item.KEJMJPHFFOJ_Max, item.NPPGKNGIFGK_price);
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
						FJGOKILCBJA data = new FJGOKILCBJA();
						data.CLCJHOIDENO(_OPKDAIMPJBH_ShopId, EKLNMHFCAOI.FKGCBLHOOCL_Category.OOMMOOIIPJE_DecoItemPoster, item.PPFNGGCBJKC_id, item.KEJMJPHFFOJ_Max, item.NPPGKNGIFGK_price);
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
						FJGOKILCBJA data = new FJGOKILCBJA();
						data.CLCJHOIDENO(_OPKDAIMPJBH_ShopId, EKLNMHFCAOI.FKGCBLHOOCL_Category.MCKHJLHKMJD_DecoItemChara, item.PPFNGGCBJKC_id, 1, item.NPPGKNGIFGK_price);
						res.Add(data);
					}
				}
			}
		}
		for (int i = 0; i < IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.GAPONCJOKAC_DecoStamp.DMKMNGELNAE_Serif.Count; i++)
		{
			IHFIAFDLAAK_DecoStamp.MCBOAJEIFNP item = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.GAPONCJOKAC_DecoStamp.DMKMNGELNAE_Serif[i];
			if (item.PLALNIIBLOF_en == 2)
			{
				if (item.MLMCEBBDJOE <= masterVersion)
				{
					if (dbShop.JIFKFKJPANC(item.ODNILEDOAIP, _JHNMKKNEENE_Time))
					{
						FJGOKILCBJA data = new FJGOKILCBJA();
						data.CLCJHOIDENO(_OPKDAIMPJBH_ShopId, EKLNMHFCAOI.FKGCBLHOOCL_Category.ICIMCGOJEMD_StampItemSerif, item.PPFNGGCBJKC_id, 1, item.NPPGKNGIFGK_price);
						res.Add(data);
					}
				}
			}
		}
		for (int i = 0; i < IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.MJALLIOHKEJ_DecoSetItem.CDENCMNHNGA_table.Count; i++)
		{
			BBLECJKKKLA_DecoSetItem.GJBPBKNHLHC_DecoSetItemInfo item = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.MJALLIOHKEJ_DecoSetItem.CDENCMNHNGA_table[i];
			if (item.PLALNIIBLOF_en == 2)
			{
				if (item.MLMCEBBDJOE <= masterVersion)
				{
					if (dbShop.JIFKFKJPANC(item.ODNILEDOAIP, _JHNMKKNEENE_Time))
					{
						FJGOKILCBJA data = new FJGOKILCBJA();
						data.CLCJHOIDENO(_OPKDAIMPJBH_ShopId, EKLNMHFCAOI.FKGCBLHOOCL_Category.ICJOEDJECAP_DecoSetItem, item.PPFNGGCBJKC_id, item.KEJMJPHFFOJ_Max, item.NPPGKNGIFGK_price);
						res.Add(data);
					}
				}
			}
		}
		return res;
	}

	//// RVA: 0x11833FC Offset: 0x11833FC VA: 0x11833FC
	public static List<FJGOKILCBJA> FKDIMODKKJD(int _OPKDAIMPJBH_ShopId, int EFNMDPKEJIM, long _JHNMKKNEENE_Time)
	{
		BKPAPCMJKHE_Shop shop = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.IFLGCDGOLOP_Shop;
		BKPAPCMJKHE_Shop.DNOENEKHGMI dbShop = shop.CDENCMNHNGA_table[_OPKDAIMPJBH_ShopId - 1];
		if(dbShop.HCCEFDMGPEA == 5)
		{
			return OHDOAMFIBCC(_OPKDAIMPJBH_ShopId, EFNMDPKEJIM, _JHNMKKNEENE_Time);
		}
		List<FJGOKILCBJA> l = new List<FJGOKILCBJA>();
		for(int i = 0; i < shop.MHKCPJDNJKI_products.Count; i++)
		{
			if(shop.MHKCPJDNJKI_products[i].PPEGAKEIEGM_Enabled == 2 && shop.MHKCPJDNJKI_products[i].EFNMDPKEJIM_LineupId == EFNMDPKEJIM &&
				_JHNMKKNEENE_Time >= shop.MHKCPJDNJKI_products[i].KJBGCLPMLCG_OpenedAt && shop.MHKCPJDNJKI_products[i].GJFPFFBAKGK_CloseAt >= _JHNMKKNEENE_Time)
			{
				FJGOKILCBJA data = new FJGOKILCBJA();
				data.KHEKNNFCAOI_Init(_OPKDAIMPJBH_ShopId, shop.MHKCPJDNJKI_products[i].AFKAGFOFAHM_ProductId);
				l.Add(data);
			}
		}

		// UMO, Remove duplicate
		l.Sort((FJGOKILCBJA _HKICMNAACDA_a, FJGOKILCBJA _BNKHBCBJBKI_b) =>
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

		l.Sort((FJGOKILCBJA _HKICMNAACDA_a, FJGOKILCBJA _BNKHBCBJBKI_b) =>
		{
			//0x11839D0
			return _HKICMNAACDA_a.EILKGEADKGH_Order.CompareTo(_BNKHBCBJBKI_b.EILKGEADKGH_Order);
		});
		return l;
	}
}
