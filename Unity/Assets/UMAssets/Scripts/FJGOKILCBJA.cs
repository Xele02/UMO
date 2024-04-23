
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
	public long EAPILIMHDNP_BuyLimitDate; // 0x20 // check AODFBGCCBPE.BGDCMGOPCGE when assigned
	public int EILKGEADKGH; // 0x28
	public int KAPMOPMDHJE_Label; // 0x2C
	public IGCPCHNCJCF GLHFDCKOJDN; // 0x30
	public JKNGJFOBADP JANMJPOKLFL = new JKNGJFOBADP(); // 0x34
	public int NGGNFHPOMOO; // 0x38
	public int EKAPPBELKDA; // 0x3C
	public int BOELIGECGJD; // 0x40
	public int PIMKKONMBOG; // 0x44
	public int ALJGJMBFKHE; // 0x48
	public int AIDNHPGEHPM; // 0x4C
	public int CKNFCDCKFDE; // 0x50
	public int LDLHJMBGGGJ; // 0x54
	public int PAFAKOPJLEE; // 0x58
	public int KEHENBMEFJN; // 0x5C
	public string DJPBDDBNMLN; // 0x60
	public bool EHJBMHEAADC; // 0x64

	public int JNLPLBJKGDC { get { return PAFAKOPJLEE ^ 0x74841479; } set { PAFAKOPJLEE = value ^ 0x74841479; } } //0x117FBD8 HCDEEJAKFOF 0x117FBEC OCKKBHCFOEM
	public int GJGNOFAPFJD { get { return BOELIGECGJD ^ 0x74841479; } set { BOELIGECGJD = value ^ 0x74841479; } } //0x117FC00 JAGHPMNNEPG 0x117FC14 FACIELLBLMP
	public int KIJAPOFAGPN_ItemFullId { get { return PIMKKONMBOG ^ 0x51478174; } set { PIMKKONMBOG = value ^ 0x51478174; } } //0x117FC28 GCKKKIDNACI 0x117FC3C OGBLMPODGBG
	public int JDLJPNMLFID_Count { get { return ALJGJMBFKHE ^ 0x137418ff; } set { ALJGJMBFKHE = value ^ 0x137418ff; } } //0x117FC50 BGIBDHCFJMN 0x117FC64 NDNEDCNDOGJ
	public int JPJMHLNOIAJ_ItemCostFullId { get { return NGGNFHPOMOO ^ 0x137418ff; } set { NGGNFHPOMOO = value ^ 0x137418ff; } } //0x117FC78 CFPIIDJJCHE 0x117FC8C PFKNCLBDBGH
	public int DKEPCPPCIKA_Price { get { return EKAPPBELKDA ^ 0x374147ee; } set { EKAPPBELKDA = value ^ 0x374147ee; } } //0x117FCA0 HPLCJFNDOKC 0x117FCB4 HNIDHAHIBLF
	public int ELEPHBOKIGK_BuyLimit { get { return AIDNHPGEHPM ^ 0x247ef; } set { AIDNHPGEHPM = value ^ 0x247ef; } } //0x117FCC8 IIJFLONJAFL 0x117FCDC LHNFGPIGCNE
	public int JLENMGOCHDG_Count { get { return CKNFCDCKFDE ^ 0x377247ef; } set { CKNFCDCKFDE = value ^ 0x377247ef; } } //0x117FCF0 OLJEIELPFMC 0x117FD04 JMNGGBCNLJN
	public int PBNCFGDPJKG_DecoItemSet { get { return KEHENBMEFJN ^ 0x141871f; } set { KEHENBMEFJN = value ^ 0x141871f; } } //0x117FD18 LCKOMDHNEBF 0x117FD2C LPODAPEMLEA
	public int NFBLLKHBMEK { get { return LDLHJMBGGGJ ^ 0x93a97a; } set { LDLHJMBGGGJ = value ^ 0x93a97a; } } //0x117FD40 NCBIANHKGMG 0x117FD54 OFKJMDODHLO

	//// RVA: 0x117FD68 Offset: 0x117FD68 VA: 0x117FD68
	public void KHEKNNFCAOI(int OPKDAIMPJBH, int AFKAGFOFAHM)
	{
		BKPAPCMJKHE_Shop.BOMCAJJCPME dbItem = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.IFLGCDGOLOP_Shop.MHKCPJDNJKI[AFKAGFOFAHM - 1];
		BKPAPCMJKHE_Shop.GPNPMJJKONJ dbItem2 = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.IFLGCDGOLOP_Shop.HMKKLPPEOHL[dbItem.GJGNOFAPFJD - 1];
		GBEFGAIGGHA_Shop.DPGGLKKBNBJ saveItem = CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave.IJOHDAJMBAL_Shop.ECMLOMPGMLC[AFKAGFOFAHM - 1];
		BKPAPCMJKHE_Shop.DNOENEKHGMI dbItem3 = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.IFLGCDGOLOP_Shop.CDENCMNHNGA[OPKDAIMPJBH - 1];
		this.OPKDAIMPJBH_ShopId = OPKDAIMPJBH;
		this.AFKAGFOFAHM_ProductId = AFKAGFOFAHM;
		GJGNOFAPFJD = dbItem.GJGNOFAPFJD;
		KIJAPOFAGPN_ItemFullId = dbItem2.EJHMPCJNHBP_ItemFullId;
		JDLJPNMLFID_Count = dbItem2.LBCNKLPIMHL_Count;
		JPJMHLNOIAJ_ItemCostFullId = dbItem2.LMMCMHHAGBJ_ItemCostFullId;
		DKEPCPPCIKA_Price = dbItem2.CMEIMAMOMPI_Price;
		DJPBDDBNMLN = null;
		KAPMOPMDHJE_Label = dbItem.ICKAMKNDAEB;
		NFBLLKHBMEK = 0;
		PBNCFGDPJKG_DecoItemSet = EKLNMHFCAOI.PJMJIKKJAAM_GetDecoItemSet(IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database, EKLNMHFCAOI.BKHFLDMOGBD_GetItemCategory(KIJAPOFAGPN_ItemFullId), EKLNMHFCAOI.DEACAHNLMNI_getItemId(KIJAPOFAGPN_ItemFullId));
		EKLNMHFCAOI.FKGCBLHOOCL_Category cat = EKLNMHFCAOI.BKHFLDMOGBD_GetItemCategory(JPJMHLNOIAJ_ItemCostFullId);
		if(cat == EKLNMHFCAOI.FKGCBLHOOCL_Category.IBBDMIFICCN_BonusVC)
		{
			//EKLNMHFCAOI.DEACAHNLMNI_getItemId(JPJMHLNOIAJ_ItemFullId2);
			for(int i = 0; i < IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.NBKNAAPBFFL_BonusVc.CDENCMNHNGA.Count; i++)
			{
				HHJHIFJIKAC_BonusVc.MNGJPJBCMBH bonusVc = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.NBKNAAPBFFL_BonusVc.CDENCMNHNGA[i];
				if(bonusVc.INDDJNMPONH == 1)
				{
					if(bonusVc.JBGEEPFKIGG == dbItem3.JPGALGPNJAI_VcId)
					{
						JPJMHLNOIAJ_ItemCostFullId = EKLNMHFCAOI.GJEEGMCBGGM_GetItemFullId(EKLNMHFCAOI.FKGCBLHOOCL_Category.IBBDMIFICCN_BonusVC, bonusVc.PPFNGGCBJKC_Id);
						break;
					}
				}
			}
		}
		else if(cat == EKLNMHFCAOI.FKGCBLHOOCL_Category.ADCAAALBAIF_Medal)
		{
			int id = EKLNMHFCAOI.DEACAHNLMNI_getItemId(JPJMHLNOIAJ_ItemCostFullId);
			HHFFOACILKG_Medal.HCFJGDFMHOJ dbMedal = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.ICICKEBMEFA_Medal.CDENCMNHNGA[id - 1];
			if(dbMedal.GBJFNGCDKPM == 1)
			{
				for(int i = 0; i < IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.ICICKEBMEFA_Medal.CDENCMNHNGA.Count; i++)
				{
					HHFFOACILKG_Medal.HCFJGDFMHOJ dbMedal2 = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.ICICKEBMEFA_Medal.CDENCMNHNGA[i];
					if (dbMedal2.IBAKPKKEDJM_Month == dbItem3.IBAKPKKEDJM_Month)
					{
						JPJMHLNOIAJ_ItemCostFullId = EKLNMHFCAOI.GJEEGMCBGGM_GetItemFullId(EKLNMHFCAOI.FKGCBLHOOCL_Category.ADCAAALBAIF_Medal, dbMedal2.PPFNGGCBJKC);
						break;
					}
				}
			}
		}
		ELEPHBOKIGK_BuyLimit = dbItem.JLENMGOCHDG_BuyLimit;
		JLENMGOCHDG_Count = ELEPHBOKIGK_BuyLimit > 0 ? saveItem.KMFLNILNPJD_Cnt : 0;
		FPJBMCDMAMO = dbItem.FPJBMCDMAMO;
		JIHKOPIENAC = Utility.GetLocalDateTime(dbItem.GJFPFFBAKGK);
		EAPILIMHDNP_BuyLimitDate = dbItem.GJFPFFBAKGK;
		JANMJPOKLFL.JCHLONCMPAJ();
		EILKGEADKGH = dbItem.EILKGEADKGH;
		JNLPLBJKGDC = 99;
		if(OPKDAIMPJBH > 0)
		{
			if(dbItem3.HCCEFDMGPEA == 1)
			{
				CEBFFLDKAEC_SecureInt v = new CEBFFLDKAEC_SecureInt();
				if(IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.IFLGCDGOLOP_Shop.OHJFBLFELNK.TryGetValue("buy_count_once_sphere", out v))
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
	public void CLCJHOIDENO(int DLLJMINACDN, EKLNMHFCAOI.FKGCBLHOOCL_Category HHACNFODNEF, int MHFBCINOJEE, int JBIOKDFOCOJ, int PLBOJBHAPLO)
	{
		OPKDAIMPJBH_ShopId = DLLJMINACDN;
		JNLPLBJKGDC = 99;
		AFKAGFOFAHM_ProductId = 99;
		GJGNOFAPFJD = -1; // ffffffff
		KIJAPOFAGPN_ItemFullId = EKLNMHFCAOI.GJEEGMCBGGM_GetItemFullId(HHACNFODNEF, MHFBCINOJEE);
		JDLJPNMLFID_Count = 1;
		JPJMHLNOIAJ_ItemCostFullId = EKLNMHFCAOI.GJEEGMCBGGM_GetItemFullId(EKLNMHFCAOI.FKGCBLHOOCL_Category.FMIIHMHKJDI_SpItem, 8);
		DKEPCPPCIKA_Price = PLBOJBHAPLO;
		PBNCFGDPJKG_DecoItemSet = EKLNMHFCAOI.PJMJIKKJAAM_GetDecoItemSet(IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database, HHACNFODNEF, MHFBCINOJEE);
		FPJBMCDMAMO = 0;
		ELEPHBOKIGK_BuyLimit = JBIOKDFOCOJ;
		JLENMGOCHDG_Count = EKLNMHFCAOI.ALHCGDMEMID_GetNumItems(IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database, CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave, HHACNFODNEF, MHFBCINOJEE, null);
		EHJBMHEAADC = true;
	}

	//// RVA: 0x1180BC4 Offset: 0x1180BC4 VA: 0x1180BC4
	public int DPFOJKHBBEH_GetNumCostItem()
	{
        EKLNMHFCAOI.FKGCBLHOOCL_Category cat = EKLNMHFCAOI.BKHFLDMOGBD_GetItemCategory(JPJMHLNOIAJ_ItemCostFullId);
		int id = EKLNMHFCAOI.DEACAHNLMNI_getItemId(JPJMHLNOIAJ_ItemCostFullId);
		return EKLNMHFCAOI.ALHCGDMEMID_GetNumItems(IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database, CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave, cat, id, null);
	}

	//// RVA: 0x1180D44 Offset: 0x1180D44 VA: 0x1180D44
	public int CMOPCCPOEBA()
	{
        EKLNMHFCAOI.FKGCBLHOOCL_Category cat = EKLNMHFCAOI.BKHFLDMOGBD_GetItemCategory(JPJMHLNOIAJ_ItemCostFullId);
		int id = EKLNMHFCAOI.DEACAHNLMNI_getItemId(JPJMHLNOIAJ_ItemCostFullId);
		int num = EKLNMHFCAOI.ALHCGDMEMID_GetNumItems(IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database, CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave, cat, id, null);
		if(!EHJBMHEAADC)
		{
			BKPAPCMJKHE_Shop.BOMCAJJCPME dbShop = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.IFLGCDGOLOP_Shop.MHKCPJDNJKI[AFKAGFOFAHM_ProductId - 1];
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
        EKLNMHFCAOI.FKGCBLHOOCL_Category cat = EKLNMHFCAOI.BKHFLDMOGBD_GetItemCategory(KIJAPOFAGPN_ItemFullId);
		int id = EKLNMHFCAOI.DEACAHNLMNI_getItemId(KIJAPOFAGPN_ItemFullId);
		int num = EKLNMHFCAOI.DLNFNHMPGLI_GetNumClamped(IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database, CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave, cat, id, null);
		int max = EKLNMHFCAOI.EEIFENNHAHF_GetMax(IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database, CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave, cat, id, null);
		if(cat == EKLNMHFCAOI.FKGCBLHOOCL_Category.MHKFDBLMOGF_Scene)
		{
			max = 9999;
		}
		if(!EHJBMHEAADC)
		{
			BKPAPCMJKHE_Shop.BOMCAJJCPME dbShop = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.IFLGCDGOLOP_Shop.MHKCPJDNJKI[AFKAGFOFAHM_ProductId - 1];
			BKPAPCMJKHE_Shop.GPNPMJJKONJ dbShop2 = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.IFLGCDGOLOP_Shop.HMKKLPPEOHL[dbShop.GJGNOFAPFJD - 1];
			return (max - num) / dbShop2.LBCNKLPIMHL_Count;
		}
		else
		{
			return max - num;
		}
	}

	//// RVA: 0x1181304 Offset: 0x1181304 VA: 0x1181304
	public bool EMLHKJAPACA_IsAddOverflow(int HMFFHLPNMPH)
	{
        EKLNMHFCAOI.FKGCBLHOOCL_Category cat = EKLNMHFCAOI.BKHFLDMOGBD_GetItemCategory(KIJAPOFAGPN_ItemFullId);
		int id = EKLNMHFCAOI.DEACAHNLMNI_getItemId(KIJAPOFAGPN_ItemFullId);
		int num = EKLNMHFCAOI.DLNFNHMPGLI_GetNumClamped(IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database, CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave, cat, id, null);
		int max = EKLNMHFCAOI.EEIFENNHAHF_GetMax(IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database, CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave, cat, id, null);
		if(cat == EKLNMHFCAOI.FKGCBLHOOCL_Category.MHKFDBLMOGF_Scene)
			max = 9999;
		if(cat == EKLNMHFCAOI.FKGCBLHOOCL_Category.ICJOEDJECAP_DecoSetItem)
		{
			bool b = true;
			if(num + HMFFHLPNMPH <= max)
			{
				BBLECJKKKLA_DecoSetItem.GJBPBKNHLHC_DecoSetItemInfo dbItem = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.MJALLIOHKEJ_DecoSetItem.CDENCMNHNGA[id - 1];
				int a = 0;
				for(int i = 0; i < dbItem.JJBNDDDGEAN_GetNumItems(); i++)
				{
					int subItemId = dbItem.FKNBLDPIPMC_GetItemCode(i);
					int d = dbItem.NKOHMLHLJGL(i);
                    EKLNMHFCAOI.FKGCBLHOOCL_Category cat2 = EKLNMHFCAOI.BKHFLDMOGBD_GetItemCategory(subItemId);
					int id2 = EKLNMHFCAOI.DEACAHNLMNI_getItemId(subItemId);
					int num2 = EKLNMHFCAOI.DLNFNHMPGLI_GetNumClamped(IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database, CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave, cat2, id2, null);
					int max2 = EKLNMHFCAOI.EEIFENNHAHF_GetMax(IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database, CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave, cat2, id2, null);
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
				BKPAPCMJKHE_Shop.BOMCAJJCPME dbShop = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.IFLGCDGOLOP_Shop.MHKCPJDNJKI[AFKAGFOFAHM_ProductId - 1];
				BKPAPCMJKHE_Shop.GPNPMJJKONJ dbShop2 = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.IFLGCDGOLOP_Shop.HMKKLPPEOHL[dbShop.GJGNOFAPFJD - 1];
				HMFFHLPNMPH *= dbShop2.LBCNKLPIMHL_Count;
			}
			if(max < num + HMFFHLPNMPH)
				return true;
			return false;
		}
    }

	//// RVA: 0x1181800 Offset: 0x1181800 VA: 0x1181800
	public int EAIJAAEKDAB_GetNumRemain()
	{
		if(!EHJBMHEAADC)
		{
			BKPAPCMJKHE_Shop.BOMCAJJCPME dbShop = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.IFLGCDGOLOP_Shop.MHKCPJDNJKI[AFKAGFOFAHM_ProductId - 1];
			BKPAPCMJKHE_Shop.GPNPMJJKONJ dbShop2 = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.IFLGCDGOLOP_Shop.HMKKLPPEOHL[dbShop.GJGNOFAPFJD - 1];
			GBEFGAIGGHA_Shop.DPGGLKKBNBJ saveShop = CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave.IJOHDAJMBAL_Shop.ECMLOMPGMLC[AFKAGFOFAHM_ProductId - 1];
			if(EKLNMHFCAOI.BKHFLDMOGBD_GetItemCategory(JPJMHLNOIAJ_ItemCostFullId) == EKLNMHFCAOI.FKGCBLHOOCL_Category.IBBDMIFICCN_BonusVC)
			{
				if(GLHFDCKOJDN == null)
					return 0;
				KBPDNHOKEKD_ProductId p = GLHFDCKOJDN.LBDOLHGDIEB(KAPMOPMDHJE_Label);
				if(p == null)
					return -1;
				if(p.HMFDJHEEGNN_BuyLimit < 1)
					return -1;
				return p.HMFDJHEEGNN_BuyLimit - p.GIEBJDKLCDH_BoughtQuantity;
			}
			if(dbShop.JLENMGOCHDG_BuyLimit > 0)
			{
				return dbShop.JLENMGOCHDG_BuyLimit - saveShop.KMFLNILNPJD_Cnt;
			}
		}
		else if(ELEPHBOKIGK_BuyLimit > 0)
		{
			int d = ELEPHBOKIGK_BuyLimit - EKLNMHFCAOI.ALHCGDMEMID_GetNumItems(IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database, CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave, EKLNMHFCAOI.BKHFLDMOGBD_GetItemCategory(KIJAPOFAGPN_ItemFullId), EKLNMHFCAOI.DEACAHNLMNI_getItemId(KIJAPOFAGPN_ItemFullId), null);
			if(d > 0)
				return d;
			return 0;
		}
		return -1;
	}

	//// RVA: 0x1181C34 Offset: 0x1181C34 VA: 0x1181C34
	public void PFIBEGFOBEG_Buy(int JLENMGOCHDG, IMCBBOAFION BHFHGFKBOHH, JFDNPFFOACP NIMPEHIECJH, DJBHIFLHJLK AOCANKOMKFG)
	{
		N.a.StartCoroutineWatched(EHDNGPFPOKJ_Co_Buy(JLENMGOCHDG, BHFHGFKBOHH, NIMPEHIECJH, AOCANKOMKFG));
	}

	//[IteratorStateMachineAttribute] // RVA: 0x741584 Offset: 0x741584 VA: 0x741584
	//// RVA: 0x1181CA4 Offset: 0x1181CA4 VA: 0x1181CA4
	private IEnumerator EHDNGPFPOKJ_Co_Buy(int JLENMGOCHDG_BuyCount, IMCBBOAFION BHFHGFKBOHH, JFDNPFFOACP NIMPEHIECJH, DJBHIFLHJLK AOCANKOMKFG)
	{
		EKLNMHFCAOI.FKGCBLHOOCL_Category JDGLDMPOCKH_ConsumeItemCat;

		//0x1184DE8
		CNGFKOJANNP.HHCJCDFCLOB.BNGIDMBNILP_ManualCheck();
		IMMAOANGPNK.HHCJCDFCLOB.PFAKPFKJJKA();
		if(IMMAOANGPNK.HHCJCDFCLOB.ENEBEGGOHFP != 0)
		{
			yield return N.a.StartCoroutineWatched(NLFNKKCPGNJ_Co_Falsification(AOCANKOMKFG));
		}
		else
		{
			FENCAJJBLBH f = CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave.PFAKPFKJJKA(true);
			if(f == null)
			{
				if(JLENMGOCHDG_BuyCount > 0)
				{
					OKGLGHCBCJP_Database LKMHPJKIFDN = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database;
					BBHNACPENDM_ServerSaveData LDEGEHAEALK = CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave;
					BKPAPCMJKHE_Shop.DNOENEKHGMI CDMILJLEPHK = LKMHPJKIFDN.IFLGCDGOLOP_Shop.CDENCMNHNGA[OPKDAIMPJBH_ShopId -1];
					int remain = EAIJAAEKDAB_GetNumRemain();
					string str;
					if(remain < 0 || JLENMGOCHDG_BuyCount <= remain)
					{
						if(CMOPCCPOEBA() < JLENMGOCHDG_BuyCount)
						{
							str = JpStringLiterals.StringLiteral_10339;
						}
						else
						{
							EKLNMHFCAOI.FKGCBLHOOCL_Category BMAKHHKJNEG = EKLNMHFCAOI.BKHFLDMOGBD_GetItemCategory(JPJMHLNOIAJ_ItemCostFullId);
							int HAIIKPDDABC = EKLNMHFCAOI.DEACAHNLMNI_getItemId(JPJMHLNOIAJ_ItemCostFullId);
							JDGLDMPOCKH_ConsumeItemCat = BMAKHHKJNEG;
							int DFMCFJNBNJI_ConsumeItemId = HAIIKPDDABC;
							int numConsumeItemBefore = EKLNMHFCAOI.ALHCGDMEMID_GetNumItems(LKMHPJKIFDN, LDEGEHAEALK, JDGLDMPOCKH_ConsumeItemCat, DFMCFJNBNJI_ConsumeItemId, null);
							int IFDHJKDDLIM_ConsumItemCount = 0;
							int BuyItemId = 0;
							int aa2 = 0;
							int MaxConsumeLimit = 0;
							if(!EHJBMHEAADC)
							{
								BKPAPCMJKHE_Shop.BOMCAJJCPME dbShop = LKMHPJKIFDN.IFLGCDGOLOP_Shop.MHKCPJDNJKI[AFKAGFOFAHM_ProductId - 1];
								BKPAPCMJKHE_Shop.GPNPMJJKONJ dbShop2 = LKMHPJKIFDN.IFLGCDGOLOP_Shop.HMKKLPPEOHL[dbShop.GJGNOFAPFJD - 1];
								IFDHJKDDLIM_ConsumItemCount = dbShop2.CMEIMAMOMPI_Price * JLENMGOCHDG_BuyCount;
								aa2 = dbShop2.LBCNKLPIMHL_Count;
								BuyItemId = dbShop2.EJHMPCJNHBP_ItemFullId;
								MaxConsumeLimit = dbShop.JLENMGOCHDG_BuyLimit;
							}
							else
							{
								IFDHJKDDLIM_ConsumItemCount = DKEPCPPCIKA_Price * JLENMGOCHDG_BuyCount;
								BuyItemId = KIJAPOFAGPN_ItemFullId;
								aa2 = JDLJPNMLFID_Count;
								MaxConsumeLimit = EKLNMHFCAOI.AFEONHCADEL_GetMaxAllowed(LKMHPJKIFDN, LDEGEHAEALK, BMAKHHKJNEG, DFMCFJNBNJI_ConsumeItemId, null);
							}
							if(JDGLDMPOCKH_ConsumeItemCat != EKLNMHFCAOI.FKGCBLHOOCL_Category.IBBDMIFICCN_BonusVC)
							{
								EKLNMHFCAOI.DPHGFMEPOCA_SetNumItems(LKMHPJKIFDN, LDEGEHAEALK, JDGLDMPOCKH_ConsumeItemCat, DFMCFJNBNJI_ConsumeItemId, numConsumeItemBefore - IFDHJKDDLIM_ConsumItemCount, null);
								JANMJPOKLFL.JCHLONCMPAJ();
								if(!EHJBMHEAADC)
								{
									BKPAPCMJKHE_Shop.BOMCAJJCPME dbShop = LKMHPJKIFDN.IFLGCDGOLOP_Shop.MHKCPJDNJKI[AFKAGFOFAHM_ProductId - 1];
									BKPAPCMJKHE_Shop.DNOENEKHGMI dbShop2 = LKMHPJKIFDN.IFLGCDGOLOP_Shop.CDENCMNHNGA[OPKDAIMPJBH_ShopId - 1];
									object[] obj = new object[5]
									{
										dbShop2.NEMKDKDIIDK_ShopName,
										":",
										dbShop.EFNMDPKEJIM_LineupId,
										":",
										dbShop.AFKAGFOFAHM
									};
									JANMJPOKLFL.FEGDNPIEKJC(OAGBCBBHMPF.COIIJOEKBDH.LJILBHPMPOG_15, string.Concat(obj));
								}
								else
								{
									JANMJPOKLFL.FEGDNPIEKJC(OAGBCBBHMPF.COIIJOEKBDH.ENGODNEBGJD_34, "");
								}
								JANMJPOKLFL.CPIICACGNBH(LDEGEHAEALK, BuyItemId, JLENMGOCHDG_BuyCount * aa2, null, 0);
								if(MaxConsumeLimit > 0 && !EHJBMHEAADC)
								{
									GBEFGAIGGHA_Shop.DPGGLKKBNBJ dbShop = LDEGEHAEALK.IJOHDAJMBAL_Shop.ECMLOMPGMLC[AFKAGFOFAHM_ProductId - 1];
									dbShop.KMFLNILNPJD_Cnt += JLENMGOCHDG_BuyCount;
									dbShop.BEBJKJKBOGH_Date = NKGJPJPHLIF.HHCJCDFCLOB.IBLPICFDGOF_ServerRequester.FJDBNGEPKHL.KMEFBNBFJHI_GetServerTime();
								}
								int BGHCIAOANCF_BuyItemId = KIJAPOFAGPN_ItemFullId;
								int GJNAOBBAPOF_BuyItemCount = JLENMGOCHDG_BuyCount * aa2;
								int PEKOLGMLJAL_AfterConsumeItemCount = EKLNMHFCAOI.ALHCGDMEMID_GetNumItems(LKMHPJKIFDN, LDEGEHAEALK, JDGLDMPOCKH_ConsumeItemCat, DFMCFJNBNJI_ConsumeItemId, null);
								int FFBPGKHIKGD_AfterBuyItemCount = EKLNMHFCAOI.ALHCGDMEMID_GetNumItems(LKMHPJKIFDN, LDEGEHAEALK, EKLNMHFCAOI.BKHFLDMOGBD_GetItemCategory(BGHCIAOANCF_BuyItemId), EKLNMHFCAOI.DEACAHNLMNI_getItemId(BGHCIAOANCF_BuyItemId), null);
								CIOECGOMILE.HHCJCDFCLOB.AIKJMHBDABF_SavePlayerData(() =>
								{
									//0x11844D0
									CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave.OEKEIGFAIGN_Counter.BDLNMOIOMHK_Total.AGNDGJOPIDL_AddShop(JLENMGOCHDG_BuyCount);
									if(BMAKHHKJNEG == EKLNMHFCAOI.FKGCBLHOOCL_Category.FMIIHMHKJDI_SpItem)
									{
										if(HAIIKPDDABC == 8)
										{
											CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave.OEKEIGFAIGN_Counter.BDLNMOIOMHK_Total.MFCKAGIINJL_AddDecoShop(JLENMGOCHDG_BuyCount);
										}
									}
									if(GNGMCIAIKMA.HHCJCDFCLOB != null)
									{
										GNGMCIAIKMA.HHCJCDFCLOB.GJENEJOANEL(DKFJADMCNPI.NLKCMNHOBAI.CLJMJHDGPOC_1, 0, JLENMGOCHDG_BuyCount, null);
										if(BMAKHHKJNEG == EKLNMHFCAOI.FKGCBLHOOCL_Category.ADCAAALBAIF_Medal)
										{
											if(DFMCFJNBNJI_ConsumeItemId > 0)
											{
												if(DFMCFJNBNJI_ConsumeItemId < 13)
												{
													GNGMCIAIKMA.HHCJCDFCLOB.GJENEJOANEL(DKFJADMCNPI.NLKCMNHOBAI.OBNEIGIFMFD_13, BGHCIAOANCF_BuyItemId, JLENMGOCHDG_BuyCount, null);
												}
											}
										}
										GNGMCIAIKMA.HHCJCDFCLOB.HEFIKPAHCIA_IsBingoValid(null, -1);
									}
									if(!EHJBMHEAADC)
									{
										BKPAPCMJKHE_Shop.BOMCAJJCPME dbShop = LKMHPJKIFDN.IFLGCDGOLOP_Shop.MHKCPJDNJKI[AFKAGFOFAHM_ProductId - 1];
										ILCCJNDFFOB.HHCJCDFCLOB.DBNECDJCNOI(OPKDAIMPJBH_ShopId, CDMILJLEPHK.NEMKDKDIIDK_ShopName, dbShop.EFNMDPKEJIM_LineupId, AFKAGFOFAHM_ProductId, JPJMHLNOIAJ_ItemCostFullId, IFDHJKDDLIM_ConsumItemCount, PEKOLGMLJAL_AfterConsumeItemCount, BGHCIAOANCF_BuyItemId, GJNAOBBAPOF_BuyItemCount, FFBPGKHIKGD_AfterBuyItemCount, JLENMGOCHDG_BuyCount, JLENMGOCHDG_Count, dbShop.JLENMGOCHDG_BuyLimit, EAPILIMHDNP_BuyLimitDate, 0, null);
									}
									else
									{
										ILCCJNDFFOB.HHCJCDFCLOB.FJIPPAPEBID(JPJMHLNOIAJ_ItemCostFullId, IFDHJKDDLIM_ConsumItemCount, PEKOLGMLJAL_AfterConsumeItemCount, BGHCIAOANCF_BuyItemId, GJNAOBBAPOF_BuyItemCount, FFBPGKHIKGD_AfterBuyItemCount, JLENMGOCHDG_BuyCount, JLENMGOCHDG_Count, EKLNMHFCAOI.AFEONHCADEL_GetMaxAllowed(LKMHPJKIFDN, LDEGEHAEALK, EKLNMHFCAOI.BKHFLDMOGBD_GetItemCategory(BGHCIAOANCF_BuyItemId), EKLNMHFCAOI.DEACAHNLMNI_getItemId(BGHCIAOANCF_BuyItemId), null), EAPILIMHDNP_BuyLimitDate);
									}
									BHFHGFKBOHH();
								}, () =>
								{
									//0x1183A4C
									AOCANKOMKFG();
								}, null);
								yield break;
							}
							if(GLHFDCKOJDN != null)
							{
								BKPAPCMJKHE_Shop.BOMCAJJCPME MABBBOEAPAA = LKMHPJKIFDN.IFLGCDGOLOP_Shop.MHKCPJDNJKI[AFKAGFOFAHM_ProductId - 1];
								BKPAPCMJKHE_Shop.DNOENEKHGMI dbShop2 = LKMHPJKIFDN.IFLGCDGOLOP_Shop.CDENCMNHNGA[OPKDAIMPJBH_ShopId - 1];
								JANMJPOKLFL.JCHLONCMPAJ();
								object[] obj = new object[5]
								{
									dbShop2.NEMKDKDIIDK_ShopName,
									":",
									MABBBOEAPAA.EFNMDPKEJIM_LineupId,
									":",
									MABBBOEAPAA.AFKAGFOFAHM
								};
								JANMJPOKLFL.FEGDNPIEKJC(OAGBCBBHMPF.COIIJOEKBDH.LJILBHPMPOG_15, string.Concat(obj));
								bool BEKAMBBOLBO = false;
								bool CNAIDEAFAAM = false;
								bool GIGHIFOIMNA = false;
								int FFBPGKHIKGD = 0;
								int BGHCIAOANCF = 0;
								int GJNAOBBAPOF = 0;
								List<long> AMOMNBEAHBF = new List<long>();
								GLHFDCKOJDN.GBMFNHOFGOP_Purchase(KAPMOPMDHJE_Label, JLENMGOCHDG_BuyCount, (BEAOCBFAHKF NFEAMMJIMPG, int GJJFLICJBKC, int JNBONMFLGNO, int OJPMOABFGMA) =>
								{
									//0x1183A80
									for(int i = 0; i < NFEAMMJIMPG.PJJFEAHIPGL_inventories.Count; i++)
									{
										BGHCIAOANCF = NFEAMMJIMPG.PJJFEAHIPGL_inventories[i].JJBGOIMEIPF_ItemFullId;
										GJNAOBBAPOF = NFEAMMJIMPG.PJJFEAHIPGL_inventories[i].MBJIFDBEDAC_ItemCount + GJNAOBBAPOF;
										JANMJPOKLFL.CPIICACGNBH(LDEGEHAEALK, NFEAMMJIMPG.PJJFEAHIPGL_inventories[i].NPPNDDMPFJJ_ItemCategory, NFEAMMJIMPG.PJJFEAHIPGL_inventories[i].OCNINMIMHGC_ItemValue, NFEAMMJIMPG.PJJFEAHIPGL_inventories[i].MBJIFDBEDAC_ItemCount, null, 0);
										AMOMNBEAHBF.Add(NFEAMMJIMPG.PJJFEAHIPGL_inventories[i].MDPJFPHOPCH_Id);
									}
									BEKAMBBOLBO = true;
								}, () =>
								{
									//0x1183DDC
									BEKAMBBOLBO = true;
									GIGHIFOIMNA = true;
								}, () =>
								{
									//0x1183DE8
									CNAIDEAFAAM = true;
									BEKAMBBOLBO = true;
								});
								//LAB_01184ed0
								while(!BEKAMBBOLBO)
									yield return null;
								if(CNAIDEAFAAM)
								{
									AOCANKOMKFG();
									yield break;
								}
								if(!GIGHIFOIMNA)
								{
									int PEKOLGMLJAL_AfterConsumeItemCount = EKLNMHFCAOI.ALHCGDMEMID_GetNumItems(LKMHPJKIFDN, LDEGEHAEALK, JDGLDMPOCKH_ConsumeItemCat, DFMCFJNBNJI_ConsumeItemId, null);
									FFBPGKHIKGD = EKLNMHFCAOI.ALHCGDMEMID_GetNumItems(LKMHPJKIFDN, LDEGEHAEALK, EKLNMHFCAOI.BKHFLDMOGBD_GetItemCategory(BGHCIAOANCF), EKLNMHFCAOI.DEACAHNLMNI_getItemId(BGHCIAOANCF), null);
									CIOECGOMILE.HHCJCDFCLOB.AIKJMHBDABF_SavePlayerData(() =>
									{
										//0x1183DF8
										CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave.OEKEIGFAIGN_Counter.BDLNMOIOMHK_Total.AGNDGJOPIDL_AddShop(JLENMGOCHDG_BuyCount);
										if(BMAKHHKJNEG == EKLNMHFCAOI.FKGCBLHOOCL_Category.FMIIHMHKJDI_SpItem)
										{
											if(HAIIKPDDABC == 8)
											{
												CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave.OEKEIGFAIGN_Counter.BDLNMOIOMHK_Total.MFCKAGIINJL_AddDecoShop(JLENMGOCHDG_BuyCount);
											}
										}
										if(GNGMCIAIKMA.HHCJCDFCLOB != null)
										{
											GNGMCIAIKMA.HHCJCDFCLOB.GJENEJOANEL(DKFJADMCNPI.NLKCMNHOBAI.CLJMJHDGPOC_1, 0, JLENMGOCHDG_BuyCount, null);
											if(BMAKHHKJNEG == EKLNMHFCAOI.FKGCBLHOOCL_Category.ADCAAALBAIF_Medal)
											{
												if(DFMCFJNBNJI_ConsumeItemId > 0)
												{
													if(DFMCFJNBNJI_ConsumeItemId < 13)
													{
														GNGMCIAIKMA.HHCJCDFCLOB.GJENEJOANEL(DKFJADMCNPI.NLKCMNHOBAI.OBNEIGIFMFD_13, BGHCIAOANCF, JLENMGOCHDG_BuyCount, null);
													}
												}
											}
											GNGMCIAIKMA.HHCJCDFCLOB.HEFIKPAHCIA_IsBingoValid(null, -1);
										}
										EOJNOOHFOKA(GLHFDCKOJDN);
										ILCCJNDFFOB.HHCJCDFCLOB.DBNECDJCNOI(OPKDAIMPJBH_ShopId, CDMILJLEPHK.NEMKDKDIIDK_ShopName, MABBBOEAPAA.EFNMDPKEJIM_LineupId, AFKAGFOFAHM_ProductId, JPJMHLNOIAJ_ItemCostFullId, IFDHJKDDLIM_ConsumItemCount, PEKOLGMLJAL_AfterConsumeItemCount, BGHCIAOANCF, GJNAOBBAPOF, FFBPGKHIKGD, JLENMGOCHDG_BuyCount, JLENMGOCHDG_Count, MABBBOEAPAA.JLENMGOCHDG_BuyLimit, EAPILIMHDNP_BuyLimitDate, NFBLLKHBMEK, DJPBDDBNMLN);
										BHFHGFKBOHH();
									}, () =>
									{
										//0x1183A20
										AOCANKOMKFG();
									}, AMOMNBEAHBF);
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
				yield return N.a.StartCoroutineWatched(NLFNKKCPGNJ_Co_Falsification(AOCANKOMKFG));
			}
			else
			{
				yield return N.a.StartCoroutineWatched(NLFNKKCPGNJ_Co_Falsification(AOCANKOMKFG));
			}
		}
		
	}

	//[IteratorStateMachineAttribute] // RVA: 0x7415FC Offset: 0x7415FC VA: 0x7415FC
	//// RVA: 0x1181DB8 Offset: 0x1181DB8 VA: 0x1181DB8
	private IEnumerator NLFNKKCPGNJ_Co_Falsification(DJBHIFLHJLK AOCANKOMKFG)
	{
		TodoLogger.LogError(TodoLogger.DbIntegrityCheck, "NLFNKKCPGNJ_Co_Falsification");
		yield return null;
	}

	//// RVA: 0x1181E64 Offset: 0x1181E64 VA: 0x1181E64
	public void EOJNOOHFOKA(IGCPCHNCJCF GLHFDCKOJDN)
	{
		this.GLHFDCKOJDN = GLHFDCKOJDN;
		KBPDNHOKEKD_ProductId k = GLHFDCKOJDN.LBDOLHGDIEB(KAPMOPMDHJE_Label);
		if(k != null)
		{
			JIHKOPIENAC = Utility.GetLocalDateTime(k.EGBOHDFBAPB_ClosedAt);
			ELEPHBOKIGK_BuyLimit = k.HMFDJHEEGNN_BuyLimit;
			DKEPCPPCIKA_Price = k.NPPGKNGIFGK_Price;
			JLENMGOCHDG_Count = k.GIEBJDKLCDH_BoughtQuantity;
			DJPBDDBNMLN = k.OPFGFINHFCE_Name;
			NFBLLKHBMEK = k.PPFNGGCBJKC_Id;
		}
	}

	//// RVA: 0x1181F9C Offset: 0x1181F9C VA: 0x1181F9C
	public static List<FJGOKILCBJA> OHDOAMFIBCC(int OPKDAIMPJBH, int EFNMDPKEJIM, long JHNMKKNEENE)
	{
		List<FJGOKILCBJA> res = new List<FJGOKILCBJA>();
		NDBFKHKMMCE_DecoItem dbDecoItem = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.EPAHOAKPAJJ_DecoItem;
		BKPAPCMJKHE_Shop dbShop = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.IFLGCDGOLOP_Shop;
		int masterVersion = DIHHCBACKGG_DbSection.IEFOPDOOLOK_MasterVersion;
		for(int i = 0; i  < dbDecoItem.GJLHEJPHEDA_ItemsBg.Count; i++)
		{
			NDBFKHKMMCE_DecoItem.EHLEEEBJLAM_BgItem item = dbDecoItem.GJLHEJPHEDA_ItemsBg[i];
			if (item.PLALNIIBLOF_Enabled == 2)
			{
				if(item.MLMCEBBDJOE <= masterVersion)
				{
					if(dbShop.JIFKFKJPANC(item.ODNILEDOAIP, JHNMKKNEENE))
					{
						FJGOKILCBJA data = new FJGOKILCBJA();
						data.CLCJHOIDENO(OPKDAIMPJBH, EKLNMHFCAOI.FKGCBLHOOCL_Category.GPMKJNDHDCP_DecoItemBg, item.PPFNGGCBJKC_Id, 1, item.NPPGKNGIFGK);
						res.Add(data);
					}
				}
			}
		}
		for(int i = 0; i < dbDecoItem.GHOLIPLDMPJ_ItemsObj.Count; i++)
		{
			NDBFKHKMMCE_DecoItem.NIBEBIGPKLA_ObjItem item = dbDecoItem.GHOLIPLDMPJ_ItemsObj[i];
			if (item.PLALNIIBLOF_Enabled == 2)
			{
				if (item.MLMCEBBDJOE <= masterVersion)
				{
					if (dbShop.JIFKFKJPANC(item.ODNILEDOAIP, JHNMKKNEENE))
					{
						FJGOKILCBJA data = new FJGOKILCBJA();
						data.CLCJHOIDENO(OPKDAIMPJBH, EKLNMHFCAOI.FKGCBLHOOCL_Category.OKPAJOALDCG_DecoItemObj, item.PPFNGGCBJKC_Id, item.KEJMJPHFFOJ_Max, item.NPPGKNGIFGK);
						res.Add(data);
					}
				}
			}
		}
		for (int i = 0; i < dbDecoItem.COLIEKINOPB_ItemsPoster.Count; i++)
		{
			NDBFKHKMMCE_DecoItem.IEOEMNPLANK_PosterItem item = dbDecoItem.COLIEKINOPB_ItemsPoster[i];
			if (item.PLALNIIBLOF_Enabled == 2)
			{
				if (item.MLMCEBBDJOE <= masterVersion)
				{
					if (dbShop.JIFKFKJPANC(item.ODNILEDOAIP, JHNMKKNEENE))
					{
						FJGOKILCBJA data = new FJGOKILCBJA();
						data.CLCJHOIDENO(OPKDAIMPJBH, EKLNMHFCAOI.FKGCBLHOOCL_Category.OOMMOOIIPJE_DecoItemPoster, item.PPFNGGCBJKC_Id, item.KEJMJPHFFOJ_Max, item.NPPGKNGIFGK);
						res.Add(data);
					}
				}
			}
		}
		for (int i = 0; i < dbDecoItem.KHCACDIKJLG_ItemsChara.Count; i++)
		{
			NDBFKHKMMCE_DecoItem.CCHHGIJMLBN_CharaItem item = dbDecoItem.KHCACDIKJLG_ItemsChara[i];
			if (item.PLALNIIBLOF_Enabled == 2)
			{
				if (item.MLMCEBBDJOE <= masterVersion)
				{
					if (dbShop.JIFKFKJPANC(item.ODNILEDOAIP, JHNMKKNEENE))
					{
						FJGOKILCBJA data = new FJGOKILCBJA();
						data.CLCJHOIDENO(OPKDAIMPJBH, EKLNMHFCAOI.FKGCBLHOOCL_Category.MCKHJLHKMJD_DecoItemChara, item.PPFNGGCBJKC_Id, 1, item.NPPGKNGIFGK);
						res.Add(data);
					}
				}
			}
		}
		for (int i = 0; i < IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.GAPONCJOKAC_DecoStamp.DMKMNGELNAE_Serif.Count; i++)
		{
			IHFIAFDLAAK_DecoStamp.MCBOAJEIFNP item = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.GAPONCJOKAC_DecoStamp.DMKMNGELNAE_Serif[i];
			if (item.PLALNIIBLOF_Enabled == 2)
			{
				if (item.MLMCEBBDJOE <= masterVersion)
				{
					if (dbShop.JIFKFKJPANC(item.ODNILEDOAIP, JHNMKKNEENE))
					{
						FJGOKILCBJA data = new FJGOKILCBJA();
						data.CLCJHOIDENO(OPKDAIMPJBH, EKLNMHFCAOI.FKGCBLHOOCL_Category.ICIMCGOJEMD_StampItemSerif, item.PPFNGGCBJKC, 1, item.NPPGKNGIFGK);
						res.Add(data);
					}
				}
			}
		}
		for (int i = 0; i < IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.MJALLIOHKEJ_DecoSetItem.CDENCMNHNGA.Count; i++)
		{
			BBLECJKKKLA_DecoSetItem.GJBPBKNHLHC_DecoSetItemInfo item = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.MJALLIOHKEJ_DecoSetItem.CDENCMNHNGA[i];
			if (item.PLALNIIBLOF == 2)
			{
				if (item.MLMCEBBDJOE <= masterVersion)
				{
					if (dbShop.JIFKFKJPANC(item.ODNILEDOAIP, JHNMKKNEENE))
					{
						FJGOKILCBJA data = new FJGOKILCBJA();
						data.CLCJHOIDENO(OPKDAIMPJBH, EKLNMHFCAOI.FKGCBLHOOCL_Category.ICJOEDJECAP_DecoSetItem, item.PPFNGGCBJKC_Id, item.KEJMJPHFFOJ_Max, item.NPPGKNGIFGK);
						res.Add(data);
					}
				}
			}
		}
		return res;
	}

	//// RVA: 0x11833FC Offset: 0x11833FC VA: 0x11833FC
	public static List<FJGOKILCBJA> FKDIMODKKJD(int OPKDAIMPJBH, int EFNMDPKEJIM, long JHNMKKNEENE)
	{
		BKPAPCMJKHE_Shop shop = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.IFLGCDGOLOP_Shop;
		BKPAPCMJKHE_Shop.DNOENEKHGMI dbShop = shop.CDENCMNHNGA[OPKDAIMPJBH - 1];
		if(dbShop.HCCEFDMGPEA == 5)
		{
			return OHDOAMFIBCC(OPKDAIMPJBH, EFNMDPKEJIM, JHNMKKNEENE);
		}
		List<FJGOKILCBJA> l = new List<FJGOKILCBJA>();
		for(int i = 0; i < shop.MHKCPJDNJKI.Count; i++)
		{
			if(shop.MHKCPJDNJKI[i].PPEGAKEIEGM_Enabled == 2 && shop.MHKCPJDNJKI[i].EFNMDPKEJIM_LineupId == EFNMDPKEJIM &&
				JHNMKKNEENE >= shop.MHKCPJDNJKI[i].KJBGCLPMLCG && shop.MHKCPJDNJKI[i].GJFPFFBAKGK >= JHNMKKNEENE)
			{
				FJGOKILCBJA data = new FJGOKILCBJA();
				data.KHEKNNFCAOI(OPKDAIMPJBH, shop.MHKCPJDNJKI[i].AFKAGFOFAHM);
				l.Add(data);
			}
		}

		// UMO, Remove duplicate
		l.Sort((FJGOKILCBJA HKICMNAACDA, FJGOKILCBJA BNKHBCBJBKI) =>
		{
			return HKICMNAACDA.KIJAPOFAGPN_ItemFullId.CompareTo(BNKHBCBJBKI.KIJAPOFAGPN_ItemFullId);
		});
		for(int i = 0; i < l.Count; i++)
		{
			for(int j = i + 1; j < l.Count; j++)
			{
				if(l[j].KIJAPOFAGPN_ItemFullId != l[i].KIJAPOFAGPN_ItemFullId)
					break;
				if(l[j].JPJMHLNOIAJ_ItemCostFullId == l[i].JPJMHLNOIAJ_ItemCostFullId && 
					l[j].JDLJPNMLFID_Count == l[i].JDLJPNMLFID_Count && 
					l[j].DKEPCPPCIKA_Price == l[i].DKEPCPPCIKA_Price)
				{
					l.RemoveAt(j);
					j--;
				}
			}
		}
		// End UMO

		l.Sort((FJGOKILCBJA HKICMNAACDA, FJGOKILCBJA BNKHBCBJBKI) =>
		{
			//0x11839D0
			return HKICMNAACDA.EILKGEADKGH.CompareTo(BNKHBCBJBKI.EILKGEADKGH);
		});
		return l;
	}
}
