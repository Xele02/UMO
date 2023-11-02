
using System;
using System.Collections;
using System.Collections.Generic;
using XeSys;

public enum NPCHMKMAHMA
{
	HJNNKCMLGFL = 0,
	AIMPCCIHKAJ_1 = 1,
	DIHBOGEPHFI_2 = 2,
}

public class LOBDIAABMKG
{
	private const int HMDMNGHDFEC = 3600;
	private const int HNPLKNDMDIL = 10;
	public static int[] BHIHFFLOAGI = new int[20]; // 0x0
	public string OPFGFINHFCE_Name; // 0x8
	public string EFIMCLPAEEN_ImageUrl; // 0xC
	public string KLMPFGOCBHC_Description; // 0x10
	public IKMBBPDBECA KACECFNECON; // 0x14
	public int MJNOAMAFNHA; // 0x18
	public long KJBGCLPMLCG_OpenedAt; // 0x20
	public long GJFPFFBAKGK_CloseAt; // 0x28
	public long EABMLBFHJBH; // 0x30
	public bool KNMLPAAHAOF_IsStartGacha; // 0x38
	public GCAHJLOGMCI.KNMMOMEHDON INDDJNMPONH_Category; // 0x3C
	public int MGBDCFIKBPM; // 0x40
	public int FDEBLMKEMLF_TypeAndSeriesId; // 0x44
	public string IJADMGDHEIE; // 0x48
	public int HNKHCIDOKFF; // 0x4C
	public int MFICPBJPCCJ; // 0x50
	public bool MEBKAHGMING; // 0x54
	public long EEFLOOBOAGF; // 0x58
	public bool FJAOAGNFABN; // 0x60
	public int ABNMIDCBENB; // 0x64
	public bool KNMNJDKJHDM; // 0x68
	private int JFDOLJDCCDJ; // 0x6C
	public string JCIBGEDBOHP = ""; // 0x70
	public int HHIBBHFHENH; // 0x74
	public int GPDIDIJDKAG; // 0x78
	public bool IMCNDJMDNJE; // 0x7C
	public bool CMCNKHLIKPP_HighRarityScene; // 0x7D
	private List<KBPDNHOKEKD_ProductId> MHKCPJDNJKI = new List<KBPDNHOKEKD_ProductId>(11); // 0x80
	private List<IKMBBPDBECA> LNPCOGEJGLL = new List<IKMBBPDBECA>(11); // 0x84
	private List<int> DHIACJMOEBH = new List<int>(11); // 0x88
	public Dictionary<string, HIMAFGJCECK> PECBGINLOLH = new Dictionary<string, HIMAFGJCECK>(); // 0x8C
	public bool CADENLBDAEB; // 0x90
	public KOPCFBCDBPC NECDFDNBHFK; // 0x94
	public JBHCLFDBPKP NJLONELPNCD; // 0x98

	// public int OANKCIDLHLJ { get; }

	// // RVA: 0x10C4520 Offset: 0x10C4520 VA: 0x10C4520
	// public bool OHEBECPDIDF() { }

	// // RVA: 0x10C46C4 Offset: 0x10C46C4 VA: 0x10C46C4
	public bool MEONHEGJNEF()
	{
		long t = NKGJPJPHLIF.HHCJCDFCLOB.IBLPICFDGOF_ServerRequester.FJDBNGEPKHL.KMEFBNBFJHI_GetServerTime();
		return GJFPFFBAKGK_CloseAt != 0 && GJFPFFBAKGK_CloseAt < t;
	}

	// // RVA: 0x10C47C4 Offset: 0x10C47C4 VA: 0x10C47C4
	// public int IGFFJIPFENH() { }

	// // RVA: 0x10C47E4 Offset: 0x10C47E4 VA: 0x10C47E4
	public MMNNAPPLHFM CHNFEEOJJCO(int CPNGJMKFCJI)
	{
		if(NECDFDNBHFK != null)
		{
			return NECDFDNBHFK.BMFEGOMNECF_Step.Find((MMNNAPPLHFM GHPLINIACBB) =>
			{
				//0x10CB54C
				return GHPLINIACBB.AGBCJMMMLON_StepIndex == CPNGJMKFCJI;
			});
		}
		return null;
	}

	// // RVA: 0x10C48FC Offset: 0x10C48FC VA: 0x10C48FC
	public ABPEPHGCNDA NLGPIELHAKC(int CPNGJMKFCJI, bool LNKELOHFELH)
	{
		if(NJLONELPNCD != null)
		{
			OEJEEHMMPBK d = NJLONELPNCD.BMFEGOMNECF_Steps.Find((OEJEEHMMPBK GHPLINIACBB) =>
			{
				//0x10CB590
				return GHPLINIACBB.AGBCJMMMLON_StepIdx == CPNGJMKFCJI;
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
	public KBPDNHOKEKD_ProductId DBHIEABGKII(GCAHJLOGMCI.NFCAJPIJFAM BJLONGBNPCI)
	{
		return MHKCPJDNJKI[(int)BJLONGBNPCI];
	}

	// // RVA: 0x10C4AA8 Offset: 0x10C4AA8 VA: 0x10C4AA8
	public IKMBBPDBECA HNDLKGOMMNM(GCAHJLOGMCI.NFCAJPIJFAM BJLONGBNPCI)
	{
		if (LNPCOGEJGLL[(int)BJLONGBNPCI] == null)
			return KACECFNECON;
		return LNPCOGEJGLL[(int)BJLONGBNPCI];
	}

	// // RVA: 0x10C4B30 Offset: 0x10C4B30 VA: 0x10C4B30
	public int OMNAPCHLBHF(GCAHJLOGMCI.NFCAJPIJFAM BJLONGBNPCI)
	{
		if(BJLONGBNPCI != GCAHJLOGMCI.NFCAJPIJFAM.OBLEFFEJGIJ_8/*8*/)
		{
			return DHIACJMOEBH[(int)BJLONGBNPCI];
		}
		if (NECDFDNBHFK == null)
			return 0;
		return NECDFDNBHFK.LKPHIGAFJKD_VirtualCurrency.PPFNGGCBJKC_Id;
	}

	// // RVA: 0x10C4BF0 Offset: 0x10C4BF0 VA: 0x10C4BF0
	public int FKKCFICCGMM(int APHNELOFGAK)
	{
		if (INDDJNMPONH_Category == GCAHJLOGMCI.KNMMOMEHDON.DLOPEFGOAPD_10)
			return MJNOAMAFNHA;
		if(INDDJNMPONH_Category == GCAHJLOGMCI.KNMMOMEHDON.OOABDNHIEFK_9)
		{
			for(int i = 0; i < IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.NBKNAAPBFFL_BonusVc.CDENCMNHNGA.Count; i++)
			{
				HHJHIFJIKAC_BonusVc.MNGJPJBCMBH dbVc = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.NBKNAAPBFFL_BonusVc.CDENCMNHNGA[i];
				if(dbVc.CPGFOBNKKBF == APHNELOFGAK)
				{
					return EKLNMHFCAOI.GJEEGMCBGGM_GetItemFullId(EKLNMHFCAOI.FKGCBLHOOCL_Category.IBBDMIFICCN_BonusVC, dbVc.PPFNGGCBJKC_Id);
				}
			}
			return 0;
		}
		else if(INDDJNMPONH_Category == GCAHJLOGMCI.KNMMOMEHDON.ANFKBNLLJFN_7 || APHNELOFGAK == 1001)
		{
			return EKLNMHFCAOI.GJEEGMCBGGM_GetItemFullId(EKLNMHFCAOI.FKGCBLHOOCL_Category.PJDEOPMBGKJ_PaidVC, 1);
		}
		else
		{
			PMDCIJMMNGK_GachaTicket.EJAKHFONNGN tkt = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.GKMAHADAAFI_GachaTicket.AAJILEFHFGC(APHNELOFGAK);
			if (tkt == null)
				return 0;
			return EKLNMHFCAOI.GJEEGMCBGGM_GetItemFullId(EKLNMHFCAOI.FKGCBLHOOCL_Category.OBHECJMAEIO_GachaTicket, tkt.PPFNGGCBJKC_Id);
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
		KBPDNHOKEKD_ProductId.KNEKLJHNHAK res = KBPDNHOKEKD_ProductId.KNEKLJHNHAK.HJNNKCMLGFL_0;
		for(int i = 0; i < MHKCPJDNJKI.Count; i++)
		{
			if(MHKCPJDNJKI[i] != null)
			{
				KBPDNHOKEKD_ProductId.KNEKLJHNHAK r = MHKCPJDNJKI[i].FJICMLBOJCH();
				if (r != KBPDNHOKEKD_ProductId.KNEKLJHNHAK.HJNNKCMLGFL_0)
					return r;
			}
		}
		return res;
	}

	// // RVA: 0x10C5618 Offset: 0x10C5618 VA: 0x10C5618
	public bool BANFOFKNKED(int APHNELOFGAK)
	{
		if(APHNELOFGAK == 1001)
		{
			if(MHKCPJDNJKI[2] != null)
			{
				if (MHKCPJDNJKI[4] != null)
					return true;
			}
		}
		return false;
	}

	// // RVA: 0x10C56F0 Offset: 0x10C56F0 VA: 0x10C56F0
	// public int BAGPMBGOCOK(int APHNELOFGAK) { }

	// // RVA: 0x10C57A4 Offset: 0x10C57A4 VA: 0x10C57A4
	public HIMAFGJCECK OHBCGMINBDP(GCAHJLOGMCI.NFCAJPIJFAM BJLONGBNPCI, bool LNKELOHFELH)
	{
		KBPDNHOKEKD_ProductId k = DBHIEABGKII(BJLONGBNPCI);
		if (k == null)
			return null;
		if(!LNKELOHFELH)
		{
			for(int i = 0; i < k.GJEBPJHECIK_ItemSetNameForApi.Count; i++)
			{
				if(!k.GJEBPJHECIK_ItemSetNameForApi[i].Contains(AFEHLCGHAEE_Strings.PAFFIBGPOJN__rare4only))
				{
					if(PECBGINLOLH.ContainsKey(k.GJEBPJHECIK_ItemSetNameForApi[i]))
					{
						return PECBGINLOLH[k.GJEBPJHECIK_ItemSetNameForApi[i]];
					}
					return null;
				}
			}
			return null;
		}
		else
		{
			if (!k.PAFFIBGPOJN_Rare4Only)
				return null;
			for(int i = 0; i < k.GJEBPJHECIK_ItemSetNameForApi.Count; i++)
			{
				if (k.GJEBPJHECIK_ItemSetNameForApi[i].Contains(AFEHLCGHAEE_Strings.PAFFIBGPOJN__rare4only))
				{
					if (PECBGINLOLH.ContainsKey(k.GJEBPJHECIK_ItemSetNameForApi[i]))
					{
						return PECBGINLOLH[k.GJEBPJHECIK_ItemSetNameForApi[i]];
					}
					return null;
				}
			}
			return null;
		}
	}

	// // RVA: 0x10C5BD0 Offset: 0x10C5BD0 VA: 0x10C5BD0
	// private bool MIJEHENMEOE(GCAHJLOGMCI.NFCAJPIJFAM BJLONGBNPCI) { }

	// // RVA: 0x10C5BF0 Offset: 0x10C5BF0 VA: 0x10C5BF0
	private bool DOMFHDPMCCO(List<KBPDNHOKEKD_ProductId> NNDGIAEFMOG, GCAHJLOGMCI.NFCAJPIJFAM BJLONGBNPCI, bool DDNGPDGGJBN, bool AJOAFPDICDK = false, NPCHMKMAHMA COMIABFPIKA = 0)
	{
		//joined_r0x010c5c94
		for(int i = NNDGIAEFMOG.Count - 1; i >= 0; i--)
		{
			if(NNDGIAEFMOG[i].KAPMOPMDHJE_Label == (int)BJLONGBNPCI || !AJOAFPDICDK)
			{
				GCAHJLOGMCI.NFCAJPIJFAM e = GCAHJLOGMCI.HHFLDFFJICJ(NNDGIAEFMOG[i].KAPMOPMDHJE_Label);
				
				bool ok = ((1 << (int)e) & 0x2a) == 0;
				if(COMIABFPIKA == NPCHMKMAHMA.DIHBOGEPHFI_2)
				{
					if(e > GCAHJLOGMCI.NFCAJPIJFAM.GOAHICNDICO_5)
						ok = true;
				}
				else
				{
					if(COMIABFPIKA != NPCHMKMAHMA.AIMPCCIHKAJ_1)
						ok = true;
					if(e > GCAHJLOGMCI.NFCAJPIJFAM.GOAHICNDICO_5)
						continue;
				}
				if(ok)
				{
					if(MHKCPJDNJKI[(int)BJLONGBNPCI] != null)
					{
						int a = GCAHJLOGMCI.BDJDDKBCHKO(MHKCPJDNJKI[(int)BJLONGBNPCI].KAPMOPMDHJE_Label);
						int c = GCAHJLOGMCI.BDJDDKBCHKO(NNDGIAEFMOG[i].KAPMOPMDHJE_Label);
						if(c <= a)
							return true;
					}
					MHKCPJDNJKI[(int)BJLONGBNPCI] = NNDGIAEFMOG[i];
					LNPCOGEJGLL[(int)BJLONGBNPCI] = IKMBBPDBECA.HEGEKFMJNCC(NNDGIAEFMOG[i].KLMPFGOCBHC_Description);
					if(!DDNGPDGGJBN)
						return true;
					OPFGFINHFCE_Name = NNDGIAEFMOG[i].OPFGFINHFCE_Name;
					EFIMCLPAEEN_ImageUrl = NNDGIAEFMOG[i].EFIMCLPAEEN_ImageUrl;
					KLMPFGOCBHC_Description = NNDGIAEFMOG[i].KLMPFGOCBHC_Description;
					GJFPFFBAKGK_CloseAt = NNDGIAEFMOG[i].EGBOHDFBAPB_ClosedAt;
					KJBGCLPMLCG_OpenedAt = NNDGIAEFMOG[i].KBFOIECIADN_OpenedAt;
					EABMLBFHJBH = NNDGIAEFMOG[i].EGBOHDFBAPB_ClosedAt;
					KNMLPAAHAOF_IsStartGacha = false;
					if(OPFGFINHFCE_Name.Contains(JpStringLiterals.StringLiteral_10431))
					{
						KNMLPAAHAOF_IsStartGacha = true;
					}
					KACECFNECON = LNPCOGEJGLL[(int)BJLONGBNPCI];
					if(KACECFNECON == null)
						return true;
					KLMPFGOCBHC_Description = KACECFNECON.KLMPFGOCBHC_Description;
					if(KACECFNECON.JOFAGCFNKIO_OpenTime != 0)
					{
						KJBGCLPMLCG_OpenedAt = KACECFNECON.JOFAGCFNKIO_OpenTime;
					}
					if(!string.IsNullOrEmpty(KACECFNECON.OPFGFINHFCE_Name))
					{
						OPFGFINHFCE_Name = KACECFNECON.OPFGFINHFCE_Name;
					}
					if(!string.IsNullOrEmpty(KACECFNECON.EABMLBFHJBH_CloseAtString))
					{
						DateTime d;
						if(DateTime.TryParse(KACECFNECON.EABMLBFHJBH_CloseAtString, out d))
						{
							EABMLBFHJBH = Utility.GetTargetUnixTime(d.Year, d.Month, d.Day, d.Hour, d.Minute, d.Second);
						}
					}
					if(!string.IsNullOrEmpty(KACECFNECON.FHHKLJCJNNC_FreeBadgeMess))
					{
						JCIBGEDBOHP = KACECFNECON.FHHKLJCJNNC_FreeBadgeMess;
					}
					if(KACECFNECON.HNKHCIDOKFF_PlateBgId < 1)
					{
						if(KACECFNECON.FLADABCFDFA_Pickup.Count < 1)
						{
							if(INDDJNMPONH_Category == GCAHJLOGMCI.KNMMOMEHDON.GENEIBGNMPH_3/*3*/)
							{
								//
							}
							else if(KACECFNECON.PGKIHFOKEHL_Feature.Count < 1)
							{
								//
							}
							else
								HNKHCIDOKFF = KACECFNECON.PGKIHFOKEHL_Feature[0].DNJEJEANJGL_Value;
						}
						else
						{
							HNKHCIDOKFF = KACECFNECON.FLADABCFDFA_Pickup[0].DNJEJEANJGL_Value;
						}
					}
					else
					{
						HNKHCIDOKFF = KACECFNECON.HNKHCIDOKFF_PlateBgId;
					}
					if(KACECFNECON.MFICPBJPCCJ_GachaBgId > 0)
					{
						MFICPBJPCCJ = KACECFNECON.MFICPBJPCCJ_GachaBgId;
					}
					CMCNKHLIKPP_HighRarityScene = false;
					MLIBEPGADJH_Scene sceneDb = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.ECNHDEHADGL_Scene;
					foreach(var k in KACECFNECON.NNDMIOEKKMM_NewEpisode)
					{
						foreach(var l in k.ADDCEJNOJLG_Scenes)
						{
							if(sceneDb.CDENCMNHNGA_SceneList[l.DNJEJEANJGL_Value - 1].OOOPJNKBDIL_Is6OrMoreRarity())
							{
								CMCNKHLIKPP_HighRarityScene = true;
							}
						}
					}
					KACECFNECON.EDCOECLMPGM(KNMLPAAHAOF_IsStartGacha);
					IMCNDJMDNJE = KACECFNECON.IMCNDJMDNJE_DisableCarousel;
					MEBKAHGMING = KACECFNECON.NNDMIOEKKMM_NewEpisode.Count > 0;
					HHIBBHFHENH = KACECFNECON.FPFECIDDNFA_LinkId;
					GPDIDIJDKAG = KACECFNECON.MPHNHBBJDGP_LinkCount;
					FJAOAGNFABN = KACECFNECON.LEJAMOFMMPA_HasOneDay;
					ABNMIDCBENB = KACECFNECON.ABNMIDCBENB_OneDay;
					KNMNJDKJHDM = KACECFNECON.KNMNJDKJHDM_HasDayCount;
					MJNOAMAFNHA = KACECFNECON.MJNOAMAFNHA_CostItemId;
					return true;
				}
			}
		}
		return false;
	}

	// // RVA: 0x10C6AD0 Offset: 0x10C6AD0 VA: 0x10C6AD0
	// private bool HJLKMDHCGFP(KOPCFBCDBPC CCBEKGNDDBE, JBHCLFDBPKP BKGFCEIFMNF, GCAHJLOGMCI.NFCAJPIJFAM BJLONGBNPCI) { }

	// // RVA: 0x10C6E60 Offset: 0x10C6E60 VA: 0x10C6E60
	public bool KHEKNNFCAOI_Init(List<KBPDNHOKEKD_ProductId> BBKDLIPKADG, int MGBDCFIKBPM, GCAHJLOGMCI.KNMMOMEHDON INDDJNMPONH, bool IAHLNPMFJMH, int APHNELOFGAK)
	{
		MHKCPJDNJKI.Clear();
		LNPCOGEJGLL.Clear();
		DHIACJMOEBH.Clear();
		for(int i = 0; i < 11; i++)
		{
			MHKCPJDNJKI.Add(null);
			LNPCOGEJGLL.Add(null);
			DHIACJMOEBH.Add(0);
		}
		bool b1;
		switch(INDDJNMPONH)
		{
			case GCAHJLOGMCI.KNMMOMEHDON.CCAPCGPIIPF_1:
			case GCAHJLOGMCI.KNMMOMEHDON.DLOPEFGOAPD_10:
				b1 = DOMFHDPMCCO(BBKDLIPKADG, GCAHJLOGMCI.NFCAJPIJFAM.AIMPCCIHKAJ_1, true, false, 0);
				break;
			case GCAHJLOGMCI.KNMMOMEHDON.PHABJLGFJNI_2:
				b1 = DOMFHDPMCCO(BBKDLIPKADG, GCAHJLOGMCI.NFCAJPIJFAM.AIMPCCIHKAJ_1, true, false, 0);
				b1 &= DOMFHDPMCCO(BBKDLIPKADG, GCAHJLOGMCI.NFCAJPIJFAM.DIHBOGEPHFI_2, false, false, 0);
				break;
			case GCAHJLOGMCI.KNMMOMEHDON.GENEIBGNMPH_3:
				b1 = true;
				if(!DOMFHDPMCCO(BBKDLIPKADG, GCAHJLOGMCI.NFCAJPIJFAM.AKHEAGMMIAM_4, true, false, 0))
				{
					b1 = DOMFHDPMCCO(BBKDLIPKADG, GCAHJLOGMCI.NFCAJPIJFAM.DIHBOGEPHFI_2, true, false, 0);
				}
				break;
			case GCAHJLOGMCI.KNMMOMEHDON.JGDEHOGIENP_4:
				if(!IAHLNPMFJMH)
				{
					b1 = true;
					int a = (APHNELOFGAK - 1000) >> 3;
					if(a >= 0 && a < 125)
					{
						b1 = DOMFHDPMCCO(BBKDLIPKADG, GCAHJLOGMCI.NFCAJPIJFAM.AIMPCCIHKAJ_1, true, false, 0);
						b1 &= DOMFHDPMCCO(BBKDLIPKADG, GCAHJLOGMCI.NFCAJPIJFAM.DIHBOGEPHFI_2, false, false, 0);
						DOMFHDPMCCO(BBKDLIPKADG, GCAHJLOGMCI.NFCAJPIJFAM.ODDGKAKAGLE_3, false, false, 0);
						DOMFHDPMCCO(BBKDLIPKADG, GCAHJLOGMCI.NFCAJPIJFAM.AKHEAGMMIAM_4, false, false, 0);
					}
					a = (APHNELOFGAK - 2000) >> 3;
					if(a >= 0 && a < 125)
					{
						a = APHNELOFGAK - 2201;
						if(a >= 0 && a < 99)
						{
							b1 |= DOMFHDPMCCO(BBKDLIPKADG, GCAHJLOGMCI.NFCAJPIJFAM.NGAHKKOBGPA_9, false, true, NPCHMKMAHMA.AIMPCCIHKAJ_1);
							b1 |= DOMFHDPMCCO(BBKDLIPKADG, GCAHJLOGMCI.NFCAJPIJFAM.BPPLDIBMPKH_10, false, true, NPCHMKMAHMA.DIHBOGEPHFI_2);
						}
						else
						{
							b1 |= DOMFHDPMCCO(BBKDLIPKADG, GCAHJLOGMCI.NFCAJPIJFAM.GOAHICNDICO_5, false, true, NPCHMKMAHMA.AIMPCCIHKAJ_1);
							b1 |= DOMFHDPMCCO(BBKDLIPKADG, GCAHJLOGMCI.NFCAJPIJFAM.LMHDFEKIDKG_6, false, true, NPCHMKMAHMA.DIHBOGEPHFI_2);
						}
					}
				}
				else
				{
					b1 = DOMFHDPMCCO(BBKDLIPKADG, GCAHJLOGMCI.NFCAJPIJFAM.AIMPCCIHKAJ_1, true, false, 0);
					b1 &= DOMFHDPMCCO(BBKDLIPKADG, GCAHJLOGMCI.NFCAJPIJFAM.DIHBOGEPHFI_2, false, false, 0);
					if(b1)
					{
						DBHIEABGKII(GCAHJLOGMCI.NFCAJPIJFAM.AIMPCCIHKAJ_1);
					}
				}
				break;
			case GCAHJLOGMCI.KNMMOMEHDON.GKDFKDLFNAJ_5:
			case GCAHJLOGMCI.KNMMOMEHDON.BKNHBNINDOC_6:
				b1 = DOMFHDPMCCO(BBKDLIPKADG, GCAHJLOGMCI.NFCAJPIJFAM.GOAHICNDICO_5, true, false, 0);
				break;
			default:
				return false;
			case GCAHJLOGMCI.KNMMOMEHDON.OOABDNHIEFK_9:
				b1 = DOMFHDPMCCO(BBKDLIPKADG, GCAHJLOGMCI.NFCAJPIJFAM.GOAHICNDICO_5, true, false, 0);
				b1 |= DOMFHDPMCCO(BBKDLIPKADG, GCAHJLOGMCI.NFCAJPIJFAM.LMHDFEKIDKG_6, true, false, 0);
				break;
		}
		if(CKGECKPFFCC())
			return false;
		if(b1)
		{
			FDEBLMKEMLF_TypeAndSeriesId = (int)INDDJNMPONH * 10000 + MGBDCFIKBPM;
			INDDJNMPONH_Category = INDDJNMPONH;
			IJADMGDHEIE = FDEBLMKEMLF_TypeAndSeriesId.ToString("D5");
			if(KACECFNECON == null)
			{
				EEFLOOBOAGF = GCAHJLOGMCI.PMBGPACNPIN(INDDJNMPONH, OPFGFINHFCE_Name, KJBGCLPMLCG_OpenedAt, 0);
			}
			else
			{
				if(KACECFNECON.OPKCNBFBBKP_BannerId == 0)
				{
					EEFLOOBOAGF = GCAHJLOGMCI.PMBGPACNPIN(INDDJNMPONH, OPFGFINHFCE_Name, KJBGCLPMLCG_OpenedAt, KACECFNECON.EEFLOOBOAGF_ViewOrder);
				}
				else
				{
					IJADMGDHEIE = KACECFNECON.OPKCNBFBBKP_BannerId.ToString("D5");
					EEFLOOBOAGF = GCAHJLOGMCI.PMBGPACNPIN(INDDJNMPONH, OPFGFINHFCE_Name, KJBGCLPMLCG_OpenedAt, KACECFNECON.EEFLOOBOAGF_ViewOrder);
				}
			}
			if(GHINEFPPDMH() < 0)
				return false;
		}
		//LAB_010c73a0
		for(int i = 0; i < MHKCPJDNJKI.Count; i++)
		{
			if(MHKCPJDNJKI[i] != null)
			{
				DHIACJMOEBH[i] = APHNELOFGAK;
			}
		}
		return b1;
	}

	// // RVA: 0x10C7660 Offset: 0x10C7660 VA: 0x10C7660
	public int GHINEFPPDMH()
	{
		KBPDNHOKEKD_ProductId k = DBHIEABGKII(GCAHJLOGMCI.NFCAJPIJFAM.DIHBOGEPHFI_2);
		if(k != null)
		{
			if(k.HMFDJHEEGNN_BuyLimit >= 1)
			{
				if(k.GIEBJDKLCDH_BoughtQuantity >= k.HMFDJHEEGNN_BuyLimit)
					return -1;
			}
		}
		if(FJAOAGNFABN)
		{
			EGOLBAPFHHD_Common.PCHECKGDJDK d = CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave.KCCLEHLLOFG_Common.BGDMJGDEKFJ_GetGachaDraw(FDEBLMKEMLF_TypeAndSeriesId);
			if(d !=  null)
			{
				if(d.JJKGPMFJJNE == NKGJPJPHLIF.HHCJCDFCLOB.DHMLDAGGKCD)
				{
					if(ABNMIDCBENB <= d.HMFFHLPNMPH)
						return -2;
				}
			}
		}
		if(CKGECKPFFCC())
			return -3;
		return 0;
	}

	// // RVA: 0x10C7820 Offset: 0x10C7820 VA: 0x10C7820
	// public bool KHEKNNFCAOI_Init(KOPCFBCDBPC CCBEKGNDDBE, JBHCLFDBPKP BKGFCEIFMNF, int MGBDCFIKBPM, GCAHJLOGMCI.KNMMOMEHDON INDDJNMPONH, int APHNELOFGAK) { }

	// // RVA: 0x10C7A70 Offset: 0x10C7A70 VA: 0x10C7A70
	public bool EJGLNKNKLFC(int PHIGDFMDJBO, GCAHJLOGMCI.KNMMOMEHDON INDDJNMPONH)
	{
		MHKCPJDNJKI.Clear();
		LNPCOGEJGLL.Clear();
		DHIACJMOEBH.Clear();
		for(int i = 0; i < 11; i++)
		{
			MHKCPJDNJKI.Add(null);
			LNPCOGEJGLL.Add(null);
			DHIACJMOEBH.Add(0);
		}
		KBPDNHOKEKD_ProductId data = new KBPDNHOKEKD_ProductId();
		data.OCBHANFFLOO_SetTutoGachaProduct(1);
		KBPDNHOKEKD_ProductId data2 = new KBPDNHOKEKD_ProductId();
		data.OCBHANFFLOO_SetTutoGachaProduct(10);
		List<KBPDNHOKEKD_ProductId> l = new List<KBPDNHOKEKD_ProductId>();
		l.Add(data);
		l.Add(data2);
		bool b = DOMFHDPMCCO(l, GCAHJLOGMCI.NFCAJPIJFAM.AIMPCCIHKAJ_1/*1*/, true, false, 0);
		bool b2 = DOMFHDPMCCO(l, GCAHJLOGMCI.NFCAJPIJFAM.DIHBOGEPHFI_2/*2*/, false, false, 0);
		if(b && b2)
		{
			this.INDDJNMPONH_Category = INDDJNMPONH;
			MGBDCFIKBPM = PHIGDFMDJBO;
			IJADMGDHEIE = ((int)INDDJNMPONH * 10000 + PHIGDFMDJBO).ToString("D5");
			EEFLOOBOAGF = GCAHJLOGMCI.PMBGPACNPIN(INDDJNMPONH, JpStringLiterals.StringLiteral_11117, 0, 0);
		}
		return b && b2;
	}

	// // RVA: 0x10C7DCC Offset: 0x10C7DCC VA: 0x10C7DCC
	public bool KIAIFPFBGJC(GCAHJLOGMCI.NFCAJPIJFAM BJLONGBNPCI, CACGCMBKHDI_Request.HDHIKGLMOGF BHFHGFKBOHH, DJBHIFLHJLK HDFGHFOCHKE, DJBHIFLHJLK JGKOLBLPMPG)
	{
		PJKLMCGEJMK CPHFEPHDJIB = NKGJPJPHLIF.HHCJCDFCLOB.IBLPICFDGOF_ServerRequester;
		if(BJLONGBNPCI == GCAHJLOGMCI.NFCAJPIJFAM.OBLEFFEJGIJ_8)
		{
			if (NECDFDNBHFK == null)
				return false;
			DOLDMCAMEOD_RequestRemainingForCurrencyIds HFPHHNDMLKE = CPHFEPHDJIB.IFFNCAFNEAG_AddRequest(new DOLDMCAMEOD_RequestRemainingForCurrencyIds());
			HFPHHNDMLKE.CGCFENMHJIM_Ids = new List<int>();
			HFPHHNDMLKE.CGCFENMHJIM_Ids.Add(1001);
			HFPHHNDMLKE.MOBEEPPKFLG_OnFail = (CACGCMBKHDI_Request JIPCHHHLOMM) =>
			{
				//0x10CB5D4
				JGKOLBLPMPG();
			};
			HFPHHNDMLKE.BHFHGFKBOHH_OnSuccess = (CACGCMBKHDI_Request JPDFGNJPGHL) =>
			{
				//0x10CB834
				CIOECGOMILE.HHCJCDFCLOB.DJICHKCLMCD_UpdateCurrencies(HFPHHNDMLKE.NFEAMMJIMPG.BBEPLKNMICJ_CurrenciesList);
				IHJEDAFEJHH_StepUpLotPurchase req = CPHFEPHDJIB.IFFNCAFNEAG_AddRequest(new IHJEDAFEJHH_StepUpLotPurchase());
				req.APHNELOFGAK = 1001;
				req.LGEKLPJFJEI = CIOECGOMILE.HHCJCDFCLOB.DEAPMEIDCGC_GetTotalPaidCurrency();
				req.MMEBLOIJBKE_Key = NECDFDNBHFK.FJGCDPLCIAK_UniqueKey;
				req.NNEGBDKOAHN_Hash = NECDFDNBHFK.LKHAAGIJEPG_PlayerStatus.ENJCKADOFBD_NextPurchaseHash;
				req.BHFHGFKBOHH_OnSuccess = (CACGCMBKHDI_Request NBGOAPNONNA) =>
				{
					//0x10CB600
					IHJEDAFEJHH_StepUpLotPurchase r = NBGOAPNONNA as IHJEDAFEJHH_StepUpLotPurchase;
					NECDFDNBHFK.LKHAAGIJEPG_PlayerStatus.ODDIHGPONFL(r.NFEAMMJIMPG.LKHAAGIJEPG_PlayerStatus);
					BHFHGFKBOHH(NBGOAPNONNA);
				};
				req.MOBEEPPKFLG_OnFail = (CACGCMBKHDI_Request JIPCHHHLOMM) =>
				{
					JGKOLBLPMPG();
				};
			};
		}
		else
		{
			KBPDNHOKEKD_ProductId k = DBHIEABGKII(BJLONGBNPCI);
			DOLDMCAMEOD_RequestRemainingForCurrencyIds PDHHLMOCEDK = CPHFEPHDJIB.IFFNCAFNEAG_AddRequest(new DOLDMCAMEOD_RequestRemainingForCurrencyIds());
			if(BJLONGBNPCI == GCAHJLOGMCI.NFCAJPIJFAM.GOAHICNDICO_5 ||
				BJLONGBNPCI == GCAHJLOGMCI.NFCAJPIJFAM.LMHDFEKIDKG_6 ||
				BJLONGBNPCI == GCAHJLOGMCI.NFCAJPIJFAM.NGAHKKOBGPA_9 ||
				BJLONGBNPCI == GCAHJLOGMCI.NFCAJPIJFAM.BPPLDIBMPKH_10)
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
				JGKOLBLPMPG();
			};
			PDHHLMOCEDK.BHFHGFKBOHH_OnSuccess = (CACGCMBKHDI_Request JPCBBHOLPGI) =>
			{
				//0x10CBB58
				CIOECGOMILE.HHCJCDFCLOB.DJICHKCLMCD_UpdateCurrencies(PDHHLMOCEDK.NFEAMMJIMPG.BBEPLKNMICJ_CurrenciesList);
				CBMFOOHOAOE_Purchase req = CPHFEPHDJIB.IFFNCAFNEAG_AddRequest(new CBMFOOHOAOE_Purchase());
				req.ICDEFIIADDO_Timeout = 3600;
				req.AFKAGFOFAHM_ProductId = k.PPFNGGCBJKC_Id;
				req.BPNPBJALGHM_Quantity = 1;
				if (BJLONGBNPCI == GCAHJLOGMCI.NFCAJPIJFAM.LMHDFEKIDKG_6)
				{
					if (IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.GKMAHADAAFI_GachaTicket.DHIACJMOEBH.Contains(OMNAPCHLBHF(BJLONGBNPCI)))
					{
						req.BPNPBJALGHM_Quantity = CIOECGOMILE.HHCJCDFCLOB.NBJOCMAJLPK_GetTotalCurrency(OMNAPCHLBHF(BJLONGBNPCI));
						if (req.BPNPBJALGHM_Quantity > 9)
							req.BPNPBJALGHM_Quantity = 10;
					}
				}
				if(BJLONGBNPCI != GCAHJLOGMCI.NFCAJPIJFAM.GOAHICNDICO_5 &&
					BJLONGBNPCI != GCAHJLOGMCI.NFCAJPIJFAM.LMHDFEKIDKG_6 &&
					BJLONGBNPCI != GCAHJLOGMCI.NFCAJPIJFAM.NGAHKKOBGPA_9 &&
					BJLONGBNPCI != GCAHJLOGMCI.NFCAJPIJFAM.BPPLDIBMPKH_10)
				{
					req.APHNELOFGAK_CurrencyId = 1001;
					req.LGEKLPJFJEI_TotalCurrency = CIOECGOMILE.HHCJCDFCLOB.DEAPMEIDCGC_GetTotalPaidCurrency();
				}
				else
				{
					req.APHNELOFGAK_CurrencyId = OMNAPCHLBHF(BJLONGBNPCI);
					req.LGEKLPJFJEI_TotalCurrency = CIOECGOMILE.HHCJCDFCLOB.NBJOCMAJLPK_GetTotalCurrency(req.APHNELOFGAK_CurrencyId);
				}
				req.JJHCNJKPAOK = false;
				req.ICKAMKNDAEB_Label = k.KAPMOPMDHJE_Label;
				req.LHMIIJEALCA = 2;
				if(k.JENBPPBNAHP_PlayerNormalLotFreeState != null)
				{
					req.JJHCNJKPAOK = k.JENBPPBNAHP_PlayerNormalLotFreeState.LDBPAJKIPKD_IsNextFree;
				}
				req.BHFHGFKBOHH_OnSuccess = (CACGCMBKHDI_Request GCAKIEEGMDD) =>
				{
					//0x10CC1A4
					if(INDDJNMPONH_Category == GCAHJLOGMCI.KNMMOMEHDON.GENEIBGNMPH_3)
					{
						if(KNMLPAAHAOF_IsStartGacha)
						{
							CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave.KCCLEHLLOFG_Common.BKCJPIPJCCM_StaminaLotDone = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.GDEKCOOBLMA_System.NCEMAEDMJLO(NKGJPJPHLIF.HHCJCDFCLOB.IBLPICFDGOF_ServerRequester.FJDBNGEPKHL.KMEFBNBFJHI_GetServerTime());
						}
					}
					if(FJAOAGNFABN)
					{
						NKGJPJPHLIF.HHCJCDFCLOB.FPNBCFJHENI.DLNKOBKDOIB(FDEBLMKEMLF_TypeAndSeriesId, NKGJPJPHLIF.HHCJCDFCLOB.DHMLDAGGKCD);
						CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave.KCCLEHLLOFG_Common.NIFJAPKCPOK_SetGachaValue(FDEBLMKEMLF_TypeAndSeriesId, NKGJPJPHLIF.HHCJCDFCLOB.DHMLDAGGKCD);
					}
					if(GCAKIEEGMDD is CBMFOOHOAOE_Purchase)
					{
						CBMFOOHOAOE_Purchase r = GCAKIEEGMDD as CBMFOOHOAOE_Purchase;
						if(k.JENBPPBNAHP_PlayerNormalLotFreeState != null)
						{
							if(r.NFEAMMJIMPG.JENBPPBNAHP_player_normal_lot_free_state != null)
							{
								k.JENBPPBNAHP_PlayerNormalLotFreeState.LDBPAJKIPKD_IsNextFree = r.NFEAMMJIMPG.JENBPPBNAHP_player_normal_lot_free_state.LDBPAJKIPKD_IsNextFree;
								k.JENBPPBNAHP_PlayerNormalLotFreeState.LJPIOGBFEKA_RemainsCount = r.NFEAMMJIMPG.JENBPPBNAHP_player_normal_lot_free_state.LJPIOGBFEKA_RemainsCount;
								k.JENBPPBNAHP_PlayerNormalLotFreeState.NEMGBIEILOI_NextTimeAt = r.NFEAMMJIMPG.JENBPPBNAHP_player_normal_lot_free_state.NEMGBIEILOI_NextTimeAt;
							}
						}
					}
					BHFHGFKBOHH(GCAKIEEGMDD);
				};
				req.MOBEEPPKFLG_OnFail = (CACGCMBKHDI_Request GCAKIEEGMDD) =>
				{
					//0x10CB808
					JGKOLBLPMPG();
				};
			};
		}
		return true;
	}

	// // RVA: 0x10C8500 Offset: 0x10C8500 VA: 0x10C8500
	public bool ICBNPNKJCBK(GCAHJLOGMCI.NFCAJPIJFAM BJLONGBNPCI, CDOPFBOHDEF BHFHGFKBOHH, DJBHIFLHJLK JGKOLBLPMPG, int BPNPBJALGHM = 1)
	{
		KBPDNHOKEKD_ProductId k = DBHIEABGKII(BJLONGBNPCI);
		if (BJLONGBNPCI != GCAHJLOGMCI.NFCAJPIJFAM.OBLEFFEJGIJ_8 && k != null)
		{
			AAOCPMCMPCP_GetNormalLotItems req = NKGJPJPHLIF.HHCJCDFCLOB.IBLPICFDGOF_ServerRequester.IFFNCAFNEAG_AddRequest(new AAOCPMCMPCP_GetNormalLotItems());
			req.AFKAGFOFAHM = k.PPFNGGCBJKC_Id;
			req.BPNPBJALGHM = BPNPBJALGHM;
			req.BHFHGFKBOHH_OnSuccess = (CACGCMBKHDI_Request NHECPMNKEFK) =>
			{
				//0x10CC810
				AAOCPMCMPCP_GetNormalLotItems r = NHECPMNKEFK as AAOCPMCMPCP_GetNormalLotItems;
				r.NFEAMMJIMPG.HBHMAKNGKFK_Items = r.NFEAMMJIMPG.HBHMAKNGKFK_Items;
				BHFHGFKBOHH(r.NFEAMMJIMPG.HBHMAKNGKFK_Items);
			};
			req.MOBEEPPKFLG_OnFail = (CACGCMBKHDI_Request NHECPMNKEFK) =>
			{
				//0x10CC9FC
				JGKOLBLPMPG();
			};
			return true;
		}
		return false;
	}

	// // RVA: 0x10C875C Offset: 0x10C875C VA: 0x10C875C
	public void AHOOLEAGACO_GetItemSetRecord(IMCBBOAFION BHFHGFKBOHH, DJBHIFLHJLK JGKOLBLPMPG)
	{
		N.a.StartCoroutineWatched(NINJDNIAGEN_Coroutine_GetItemSetRecord(BHFHGFKBOHH, JGKOLBLPMPG));
	}

	// [IteratorStateMachineAttribute] // RVA: 0x6B6010 Offset: 0x6B6010 VA: 0x6B6010
	// // RVA: 0x10C87B4 Offset: 0x10C87B4 VA: 0x10C87B4
	private IEnumerator NINJDNIAGEN_Coroutine_GetItemSetRecord(IMCBBOAFION BHFHGFKBOHH, DJBHIFLHJLK MOBEEPPKFLG)
	{
		int ONBPFIMAAEJ; // 0x1C
		KBPDNHOKEKD_ProductId BILEPJMCGEN; // 0x20
		int LFECMMEEMDM; // 0x24
		string CFHHCEOPHGH; // 0x28
		BLHOHLGCJHI_GetItemSetRecord DCNALBIJJGP; // 0x2C

		//0x10CCA94
		PECBGINLOLH.Clear();
		for(ONBPFIMAAEJ = 0; ONBPFIMAAEJ < MHKCPJDNJKI.Count; ONBPFIMAAEJ++)
		{
			BILEPJMCGEN = MHKCPJDNJKI[ONBPFIMAAEJ];
			if(BILEPJMCGEN != null)
			{
				for(LFECMMEEMDM = 0; LFECMMEEMDM < BILEPJMCGEN.GJEBPJHECIK_ItemSetNameForApi.Count; LFECMMEEMDM++)
				{
					CFHHCEOPHGH = BILEPJMCGEN.GJEBPJHECIK_ItemSetNameForApi[LFECMMEEMDM];
					if(!PECBGINLOLH.ContainsKey(CFHHCEOPHGH))
					{
						DCNALBIJJGP = NKGJPJPHLIF.HHCJCDFCLOB.IBLPICFDGOF_ServerRequester.IFFNCAFNEAG_AddRequest(new BLHOHLGCJHI_GetItemSetRecord());
						DCNALBIJJGP.DKBGNOMDCMK_ItemSetName = CFHHCEOPHGH;
						DCNALBIJJGP.KACECFNECON = KACECFNECON;
						while (!DCNALBIJJGP.PLOOEECNHFB_IsDone)
							yield return null;
						if (DCNALBIJJGP.NPNNPNAIONN_IsError)
						{
							PECBGINLOLH.Clear();
							MOBEEPPKFLG();
							yield break;
						}
						PECBGINLOLH.Add(CFHHCEOPHGH, DCNALBIJJGP.NFEAMMJIMPG);
					}
				}
			}
		}
		BHFHGFKBOHH();
	}

	// // RVA: 0x10C8894 Offset: 0x10C8894 VA: 0x10C8894
	public void OALDDFAJFDL_GetStepUpItemSetRecord(IMCBBOAFION BHFHGFKBOHH, DJBHIFLHJLK JGKOLBLPMPG)
	{
		N.a.StartCoroutineWatched(BAKEDPGFOLF_Coroutine_GetStepUpItemSetRecord(BHFHGFKBOHH, JGKOLBLPMPG));
	}

	// [IteratorStateMachineAttribute] // RVA: 0x6B6088 Offset: 0x6B6088 VA: 0x6B6088
	// // RVA: 0x10C88EC Offset: 0x10C88EC VA: 0x10C88EC
	private IEnumerator BAKEDPGFOLF_Coroutine_GetStepUpItemSetRecord(IMCBBOAFION BHFHGFKBOHH, DJBHIFLHJLK MOBEEPPKFLG)
	{
		EDOGNHECOMI_GetStepUpLotDetail PNLGHFCFPPK;

		//0x10CCFD8
		bool CNAIDEAFAAM = false;
		bool BEKAMBBOLBO = false;
		PNLGHFCFPPK = NKGJPJPHLIF.HHCJCDFCLOB.IBLPICFDGOF_ServerRequester.IFFNCAFNEAG_AddRequest(new EDOGNHECOMI_GetStepUpLotDetail());
		PNLGHFCFPPK.MMEBLOIJBKE = NECDFDNBHFK.FJGCDPLCIAK_UniqueKey;
		PNLGHFCFPPK.MOBEEPPKFLG_OnFail = (CACGCMBKHDI_Request JIPCHHHLOMM) =>
		{
			//0x10CCA30
			CNAIDEAFAAM = true;
			BEKAMBBOLBO = true;
		};
		PNLGHFCFPPK.BHFHGFKBOHH_OnSuccess = (CACGCMBKHDI_Request JIPCHHHLOMM) =>
		{
			//0x10CCA3C
			BEKAMBBOLBO = true;
		};
		while (!BEKAMBBOLBO)
			yield return null;
		if(!CNAIDEAFAAM)
		{
			NJLONELPNCD = PNLGHFCFPPK.NFEAMMJIMPG;
			BHFHGFKBOHH();
		}
		else
		{
			MOBEEPPKFLG();
		}
	}

	// // RVA: 0x10C89CC Offset: 0x10C89CC VA: 0x10C89CC
	public static List<ANGEDJODMKO> KECIGJBEHBG(List<ANGEDJODMKO> PJJFEAHIPGL)
	{
		if (EKLNMHFCAOI.FABCKNDLPDH_GetItemRarity(PJJFEAHIPGL[PJJFEAHIPGL.Count - 1].JJBGOIMEIPF_ItemFullId) > 4)
			return PJJFEAHIPGL;
		if(EKLNMHFCAOI.FABCKNDLPDH_GetItemRarity(PJJFEAHIPGL[0].JJBGOIMEIPF_ItemFullId) < 5)
		{
			if (EKLNMHFCAOI.FABCKNDLPDH_GetItemRarity(PJJFEAHIPGL[0].JJBGOIMEIPF_ItemFullId) > 3)
				return PJJFEAHIPGL;
			List<ANGEDJODMKO> res = new List<ANGEDJODMKO>(10);
			int idx = -1;
			for(int i = 0; i < PJJFEAHIPGL.Count; i++)
			{
				if(idx != -1 || EKLNMHFCAOI.FABCKNDLPDH_GetItemRarity(PJJFEAHIPGL[i].JJBGOIMEIPF_ItemFullId) < 4)
				{
					res.Add(PJJFEAHIPGL[i]);
				}
				else
				{
					idx = i;
				}
			}
			if (idx < 0)
				return res;
			res.Add(PJJFEAHIPGL[idx]);
			return res;
		}
		else
		{
			List<ANGEDJODMKO> res = new List<ANGEDJODMKO>();
			for(int i = 1; i < PJJFEAHIPGL.Count; i++)
			{
				res.Add(PJJFEAHIPGL[i]);
			}
			res.Add(PJJFEAHIPGL[0]);
			return res;
		}
	}

	// // RVA: 0x10C8F34 Offset: 0x10C8F34 VA: 0x10C8F34
	// public static List<MFDJIFIIPJD> ENFHLLHHJKE(List<MFDJIFIIPJD> HBHMAKNGKFK) { }

	// // RVA: 0x10C9170 Offset: 0x10C9170 VA: 0x10C9170
	public string KKODAOIJHMC(GCAHJLOGMCI.NFCAJPIJFAM BJLONGBNPCI)
	{
		IKMBBPDBECA d = HNDLKGOMMNM(BJLONGBNPCI);
		if (d == null)
			return "";
		if (BJLONGBNPCI == GCAHJLOGMCI.NFCAJPIJFAM.AIMPCCIHKAJ_1 && d is EBOCABJKMFB)
			return "";
		return d.MDEIKCBEHHC;
	}

	// // RVA: 0x10C923C Offset: 0x10C923C VA: 0x10C923C
	public int IEEHJPABKMP_GetOwnedQuantity()
	{
		if (MHKCPJDNJKI[3] == null)
		{
			if (MHKCPJDNJKI[1] == null)
				return 0;
			return MHKCPJDNJKI[1].HMFDJHEEGNN_BuyLimit;
		}
		return MHKCPJDNJKI[3].GIEBJDKLCDH_BoughtQuantity;
	}

	// // RVA: 0x10C9304 Offset: 0x10C9304 VA: 0x10C9304
	public int GBAMENANDAN_GetMaxLimit()
	{
		if(MHKCPJDNJKI[3] == null)
		{
			if (MHKCPJDNJKI[1] == null)
				return 0;
			return MHKCPJDNJKI[1].HMFDJHEEGNN_BuyLimit;
		}
		return MHKCPJDNJKI[3].HMFDJHEEGNN_BuyLimit;
	}

	// // RVA: 0x10C93CC Offset: 0x10C93CC VA: 0x10C93CC
	public int GECLFOEDJEI_GetOwnedQuantity()
	{
		if(MHKCPJDNJKI[4] == null)
		{
			if (MHKCPJDNJKI[2] == null)
				return 0;
			return MHKCPJDNJKI[2].GIEBJDKLCDH_BoughtQuantity;
		}
		return MHKCPJDNJKI[4].GIEBJDKLCDH_BoughtQuantity;
	}

	// // RVA: 0x10C9494 Offset: 0x10C9494 VA: 0x10C9494
	public int IBNBABPKLAA_GetMaxLimit()
	{
		if(MHKCPJDNJKI[4] == null)
		{
			if (MHKCPJDNJKI[2] == null)
				return 0;
			return MHKCPJDNJKI[2].HMFDJHEEGNN_BuyLimit;
		}
		return MHKCPJDNJKI[4].HMFDJHEEGNN_BuyLimit;
	}

	// // RVA: 0x10C955C Offset: 0x10C955C VA: 0x10C955C
	public bool GPKAMGNBGAB(int APHNELOFGAK)
	{
		for (int i = 0; i < IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.NBKNAAPBFFL_BonusVc.CDENCMNHNGA.Count; i++)
		{
			HHJHIFJIKAC_BonusVc.MNGJPJBCMBH dbVC = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.NBKNAAPBFFL_BonusVc.CDENCMNHNGA[i];
			if(dbVC.CPGFOBNKKBF == APHNELOFGAK)
			{
				int id = EKLNMHFCAOI.GJEEGMCBGGM_GetItemFullId(EKLNMHFCAOI.FKGCBLHOOCL_Category.IBBDMIFICCN_BonusVC, dbVC.PPFNGGCBJKC_Id);
				for(int j = 0; j < IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.KCCDBKIOLDJ_VcItem.CDENCMNHNGA.Count; j++)
				{
					DKJMDIFAKKD_VcItem.EBGPAPPHBAH dbVc2 = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.KCCDBKIOLDJ_VcItem.CDENCMNHNGA[j];
					for(int k = 0; k < dbVc2.KGOFMDMDFCJ.Length; k++)
					{
						if(dbVc2.KGOFMDMDFCJ[k] == id)
						{
							if (!GHLJANAEKFJ(dbVc2.PPFNGGCBJKC))
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
		for(int i = 0; i < EJHPIMANJFP.HHCJCDFCLOB.MHKCPJDNJKI.Count; i++)
		{
			if (EJHPIMANJFP.HHCJCDFCLOB.MHKCPJDNJKI[i].LHENLPLKGLP == ADANONKNBKE && EJHPIMANJFP.HHCJCDFCLOB.MHKCPJDNJKI[i].AJIFADGGAAJ < EJHPIMANJFP.HHCJCDFCLOB.MHKCPJDNJKI[i].GCJMGMBNBCB)
				return true;
		}
		return false;
	}

	// // RVA: 0x10C9AD8 Offset: 0x10C9AD8 VA: 0x10C9AD8
	public int HIPBEKBFNBG(int APHNELOFGAK)
	{
		for(int i = 0; i < IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.NBKNAAPBFFL_BonusVc.CDENCMNHNGA.Count; i++)
		{
			HHJHIFJIKAC_BonusVc.MNGJPJBCMBH dbVC = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.NBKNAAPBFFL_BonusVc.CDENCMNHNGA[i];
			if(dbVC.CPGFOBNKKBF == APHNELOFGAK)
			{
				return dbVC.JDANEOJCLBB;
			}
		}
		return 0;
	}

	// // RVA: 0x10C9C8C Offset: 0x10C9C8C VA: 0x10C9C8C
	public bool ALPOJNBHNDK(int APHNELOFGAK, long JHNMKKNEENE)
	{
		for(int i = 0; i < IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.NBKNAAPBFFL_BonusVc.CDENCMNHNGA.Count; i++)
		{
			HHJHIFJIKAC_BonusVc.MNGJPJBCMBH dbVC = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.NBKNAAPBFFL_BonusVc.CDENCMNHNGA[i];
			if(dbVC.CPGFOBNKKBF == APHNELOFGAK)
			{
				if (JHNMKKNEENE < dbVC.KMENGHEAIOC)
					return false;
				if (JHNMKKNEENE < dbVC.JDANEOJCLBB)
					return true;
				return false;
			}
		}
		return false;
	}

	// // RVA: 0x10C9EC4 Offset: 0x10C9EC4 VA: 0x10C9EC4
	public string KAGBOMEDOLJ(int APHNELOFGAK)
	{
		for (int i = 0; i < IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.NBKNAAPBFFL_BonusVc.CDENCMNHNGA.Count; i++)
		{
			HHJHIFJIKAC_BonusVc.MNGJPJBCMBH dbVc = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.NBKNAAPBFFL_BonusVc.CDENCMNHNGA[i];
			if(dbVc.CPGFOBNKKBF == APHNELOFGAK)
			{
				return EKLNMHFCAOI.INCKKODFJAP_GetItemName(EKLNMHFCAOI.GJEEGMCBGGM_GetItemFullId(EKLNMHFCAOI.FKGCBLHOOCL_Category.IBBDMIFICCN_BonusVC, dbVc.PPFNGGCBJKC_Id));
			}
		}
		return "";
	}

	// // RVA: 0x10CA118 Offset: 0x10CA118 VA: 0x10CA118
	// public bool IJJOGGEBBPF(int APHNELOFGAK) { }

	// // RVA: 0x10CA3E0 Offset: 0x10CA3E0 VA: 0x10CA3E0
	public int LPPJMOMKPKA(int APHNELOFGAK)
	{
		for (int i = 0; i < IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.NBKNAAPBFFL_BonusVc.CDENCMNHNGA.Count; i++)
		{
			HHJHIFJIKAC_BonusVc.MNGJPJBCMBH dbVc = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.NBKNAAPBFFL_BonusVc.CDENCMNHNGA[i];
			if(dbVc.CPGFOBNKKBF == APHNELOFGAK)
			{
				int itemId = EKLNMHFCAOI.GJEEGMCBGGM_GetItemFullId(EKLNMHFCAOI.FKGCBLHOOCL_Category.IBBDMIFICCN_BonusVC, dbVc.PPFNGGCBJKC_Id);
				for(int j = 0; j < IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.KCCDBKIOLDJ_VcItem.CDENCMNHNGA.Count; j++)
				{
					DKJMDIFAKKD_VcItem.EBGPAPPHBAH dbVc2 = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.KCCDBKIOLDJ_VcItem.CDENCMNHNGA[j];
					for(int k = 0; k < dbVc2.KGOFMDMDFCJ.Length; k++)
					{
						if(dbVc2.KGOFMDMDFCJ[k] == itemId)
						{
							return dbVc2.PPFNGGCBJKC;
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
		if(KACECFNECON != null && KACECFNECON.ANFKCPGENCM_TicketVcId != null && KACECFNECON.ANFKCPGENCM_TicketVcId.Count > 0)
		{
			List<MCKCJMLOAFP_CurrencyInfo> l1 = new List<MCKCJMLOAFP_CurrencyInfo>();
			for(int i = 0; i < KACECFNECON.ANFKCPGENCM_TicketVcId.Count; i++)
			{
				int v = KACECFNECON.ANFKCPGENCM_TicketVcId[i].DNJEJEANJGL_Value;
				MCKCJMLOAFP_CurrencyInfo c = CIOECGOMILE.HHCJCDFCLOB.BBEPLKNMICJ_Currencies.Find((MCKCJMLOAFP_CurrencyInfo GHPLINIACBB) =>
				{
					//0x10CCA48
					if (GHPLINIACBB.PPFNGGCBJKC_Id != v)
						return false;
					return GHPLINIACBB.BDLNMOIOMHK_Total > 0;
				});
				if(c != null)
				{
					l1.Add(c);
				}
			}
			if(l1.Count < 1)
			{
				return KACECFNECON.ANFKCPGENCM_TicketVcId[0].DNJEJEANJGL_Value;
			}
			return l1[0].PPFNGGCBJKC_Id;
		}
		return 0;
	}

	// // RVA: 0x10CACD0 Offset: 0x10CACD0 VA: 0x10CACD0
	public static bool GPKPIGPDFNL(List<LOBDIAABMKG> NNDGIAEFMOG, int HHIBBHFHENH, int GPDIDIJDKAG)
	{
		int a1 = 0;
		int a2 = 0;
		int a3 = 0;
		for(int i = 0; i < NNDGIAEFMOG.Count; i++)
		{
			if(NNDGIAEFMOG[i].HHIBBHFHENH > 0 && NNDGIAEFMOG[i].HHIBBHFHENH == HHIBBHFHENH)
			{
				a3++;
				foreach(var k in NNDGIAEFMOG[i].MHKCPJDNJKI)
				{
					if(k != null)
					{
						a2 += k.GIEBJDKLCDH_BoughtQuantity;
						if(a1 == 0)
							a1 = k.HMFDJHEEGNN_BuyLimit;
					}
				}
			}
		}
		return a3 == GPDIDIJDKAG && (a1 == 0 || a2 < a1);
	}

	// // RVA: 0x10C74DC Offset: 0x10C74DC VA: 0x10C74DC
	public bool CKGECKPFFCC()
	{
		DateTime d = Utility.GetLocalDateTime(KJBGCLPMLCG_OpenedAt);
		if(d.Minute == 59)
		{
			return NKGJPJPHLIF.HHCJCDFCLOB.IBLPICFDGOF_ServerRequester.FJDBNGEPKHL.KMEFBNBFJHI_GetServerTime() - KJBGCLPMLCG_OpenedAt < 60;
		}
		return false;
	}

	// // RVA: 0x10CB01C Offset: 0x10CB01C VA: 0x10CB01C
	public void EIHCALCFNEJ(LOBDIAABMKG DPBDFPPMIPH)
	{
		for(int i = 0; i < 11; i++)
		{
			if(MHKCPJDNJKI[i] == null)
			{
				if(DPBDFPPMIPH.MHKCPJDNJKI[i] != null)
				{
					MHKCPJDNJKI[i] = DPBDFPPMIPH.MHKCPJDNJKI[i];
				}
			}
			if(DHIACJMOEBH[i] == 0)
			{
				if(DPBDFPPMIPH.DHIACJMOEBH[i] != 0)
				{
					DHIACJMOEBH[i] = DPBDFPPMIPH.DHIACJMOEBH[i];
				}
			}
			if(LNPCOGEJGLL[i] == null)
			{
				if(DPBDFPPMIPH.LNPCOGEJGLL[i] != null)
				{
					LNPCOGEJGLL[i] = DPBDFPPMIPH.LNPCOGEJGLL[i];
				}
			}
		}
	}
}
