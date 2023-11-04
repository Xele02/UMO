
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XeApp.Game.Common;
using XeApp.Game.Menu;
using XeSys;

public class BEPHBEGDFFK
{
	public enum ABBPGMEDDHD
	{
		HNOJIKHAPHA_0 = 0,
		HCBFMFONIOE_1 = 1,
		KHLPAOENONH_2 = 2,
	}

	public class DMBKENKBIJD
	{
		public LOBDIAABMKG DPBDFPPMIPH_Gacha { get; set; } // 0x8 MEMIBJHJPHG HLFDKACMMPC POCCHIIKMHM
		//public GCAHJLOGMCI.KNMMOMEHDON INDDJNMPONH { get; } 0xC773E4 GHAILOLPHPF
		public GCAHJLOGMCI.NFCAJPIJFAM_SummonType BJLONGBNPCI_SummonType { get; set; } // 0xC JGCNCCFPMNF CFCGLCHKOMM PEDOGIFGENK
		public int APHNELOFGAK_CurrencyId { get; set; } // 0x10 JNPILMHHIID PHLOINCPBDJ BNGDDADJBBA
		public int KPIHBPMOGKL_LotCount { get; set; } // 0x14 ICJNODPNEIM PHINOMJKNGN JPPBNGENACJ
		public int GLBEAENLHKC_MaxLimit { get; set; } // 0x18 FAIFKIODKHE NOAKFOIOJBH PBGBHOBHBMG
		public int NCIBIAJJBFF { get; set; } // 0x1C CHDJEBBMDPL GAABCDHLDAK MHBFHKKMIKC
		public string MDEIKCBEHHC_Kakutei { get; set; } // 0x20 PNJMLBIKKNG PKENIFNAJDL BPNCHKKFDJH
		public bool JNMMPPILMBC { get; set; } // 0x24 ADCKOLKFCKI FOHFHKAOFBK JCOCMGIEKEG
		public long JHNMKKNEENE_Time { get; set; } // 0x28 ONDHIJNKPFO NBICELIKAMG IAGCKLBBEJE
		public KBPDNHOKEKD_ProductId MEANCEOIMGE_Summon { get; set; } // 0x30 CKCBLOOEBDC HAPHCPMEHDK ENENFIFJJGN

		//// RVA: 0xC79BA4 Offset: 0xC79BA4 VA: 0xC79BA4
		public int ILFAHJEJCMH_GetPrice()
		{
			if(DPBDFPPMIPH_Gacha.INDDJNMPONH_Category != GCAHJLOGMCI.KNMMOMEHDON_GachaType.OOABDNHIEFK_9)
			{
				if(DPBDFPPMIPH_Gacha.INDDJNMPONH_Category != GCAHJLOGMCI.KNMMOMEHDON_GachaType.DLOPEFGOAPD_10)
				{
					PMDCIJMMNGK_GachaTicket.EJAKHFONNGN tkt = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.GKMAHADAAFI_GachaTicket.AAJILEFHFGC(APHNELOFGAK_CurrencyId);
					if(tkt == null)
					{
						if(MEANCEOIMGE_Summon.FJICMLBOJCH() <= KBPDNHOKEKD_ProductId.KNEKLJHNHAK.AAPLMEGMNJA_4 && ((1 << (int)MEANCEOIMGE_Summon.FJICMLBOJCH()) & 0x16U) != 0) // 0001 0110
						{
							return 0;
						}
						return MEANCEOIMGE_Summon.NPPGKNGIFGK_Price;
					}
				}
			}
			return KPIHBPMOGKL_LotCount;
		}

		//// RVA: 0xC79D38 Offset: 0xC79D38 VA: 0xC79D38
		//public int BJLPJAAIMKC() { }

		//// RVA: 0xC79E14 Offset: 0xC79E14 VA: 0xC79E14
		public int CMHHHCAKPCD()
		{
			return BEPHBEGDFFK.CMHHHCAKPCD(DPBDFPPMIPH_Gacha, BJLONGBNPCI_SummonType);
		}
	}

	public int BADFIKBADNH_PickupId; // 0x30
	public bool EFCJADAPOMN; // 0x34
	private List<DMBKENKBIJD> FEMAEEHOCIJ = new List<DMBKENKBIJD>(); // 0x38
	private List<DMBKENKBIJD> COMCFOFCGJM = new List<DMBKENKBIJD>(); // 0x3C
	private DMBKENKBIJD FMKIIPBJFBB; // 0x40
	private DMBKENKBIJD LHLMIDPNGGM; // 0x44

	public HomeBannerTextureCache CEPJKBFGKEN { get; private set; } // 0x8 GFPHMEIEHCO IFOGHCILKCM NNKDJNHFDMM
	public SceneCardTextureCache LBMILLAEEBK { get; private set; } // 0xC ENOIKOGCDFP JIGCKBCKJLD OPNCLPPPKNI
	public GachaBgTextureCache MMJONIHIOFI { get; private set; } // 0x10 EAMBMEAHNMG DAONIFMJHND IMHEFBMPECP
	public LOBDIAABMKG DPBDFPPMIPH_Gacha { get; private set; } // 0x14 MEMIBJHJPHG HLFDKACMMPC POCCHIIKMHM
	public long JHNMKKNEENE_Time { get; private set; } // 0x18 ONDHIJNKPFO NBICELIKAMG IAGCKLBBEJE
	public int BGMDABJBHDM_Hour1 { get; private set; } // 0x20 AJDKMIJGILO MJAHOGAKIFN ACEHDFGCEDH
	public int NDNHABFJNDB_Hour2 { get; private set; } // 0x24 PLPEDAFOMEO NMNPPNGMBMD NNNOHPKKLOP
	public int ACDBBJBNLLG_Hour3 { get; private set; } // 0x28 MMDJFDBBJMD OGMCAHJCKOO IKCOANPHPGL
	public int IDADEHNGHPO_Hour4 { get; private set; } // 0x2C JNEODDGOEFL MGIBGJPEDHA LIGGEFLLMKB

	//// RVA: 0xC76548 Offset: 0xC76548 VA: 0xC76548
	public void KHEKNNFCAOI()
	{
		DPBDFPPMIPH_Gacha = null;
		JHNMKKNEENE_Time = 0;
		BADFIKBADNH_PickupId = 0;
		EFCJADAPOMN = true;
		FEMAEEHOCIJ.Clear();
		COMCFOFCGJM.Clear();
		CEPJKBFGKEN = new HomeBannerTextureCache();
		LBMILLAEEBK = new SceneCardTextureCache();
		IEnumerator e = LBMILLAEEBK.Initialize(false);
		e.MoveNext();
		MMJONIHIOFI = new GachaBgTextureCache();
		NAIHICDHICH();
	}

	//// RVA: 0xC768D8 Offset: 0xC768D8 VA: 0xC768D8
	public void DOMFHDPMCCO(LOBDIAABMKG NDNHHGJKJGM, int IMKLJJIBHCN, long EOLFJGMAJAB_Time_)
	{
		JHNMKKNEENE_Time = EOLFJGMAJAB_Time_;
		DPBDFPPMIPH_Gacha = NDNHHGJKJGM;
		BADFIKBADNH_PickupId = IMKLJJIBHCN;
		FEMAEEHOCIJ.Clear();
		COMCFOFCGJM.Clear();
		for(int i = 10; i >= 0; i--)
		{
			KBPDNHOKEKD_ProductId p = DPBDFPPMIPH_Gacha.DBHIEABGKII_GetSummon((GCAHJLOGMCI.NFCAJPIJFAM_SummonType)(i));
			if(p != null)
			{
				DMBKENKBIJD data = new DMBKENKBIJD();
				data.MEANCEOIMGE_Summon = p;
				data.DPBDFPPMIPH_Gacha = DPBDFPPMIPH_Gacha;
				data.BJLONGBNPCI_SummonType = (GCAHJLOGMCI.NFCAJPIJFAM_SummonType)(i);
				data.JHNMKKNEENE_Time = JHNMKKNEENE_Time;
				data.KPIHBPMOGKL_LotCount = p.JHAIOJELFHI_GetNumLot;
				data.MDEIKCBEHHC_Kakutei = DPBDFPPMIPH_Gacha.KKODAOIJHMC_GetKakuteiText(data.BJLONGBNPCI_SummonType);
				if(DPBDFPPMIPH_Gacha.INDDJNMPONH_Category == GCAHJLOGMCI.KNMMOMEHDON_GachaType.DLOPEFGOAPD_10)
				{
					data.KPIHBPMOGKL_LotCount = Mathf.Clamp(CMHHHCAKPCD(DPBDFPPMIPH_Gacha, data.BJLONGBNPCI_SummonType), 1, 10);
				}
				if(data.BJLONGBNPCI_SummonType <= GCAHJLOGMCI.NFCAJPIJFAM_SummonType.BPPLDIBMPKH_10)
				{
					if(data.BJLONGBNPCI_SummonType == GCAHJLOGMCI.NFCAJPIJFAM_SummonType.OBLEFFEJGIJ_8)
					{
						data.APHNELOFGAK_CurrencyId = DPBDFPPMIPH_Gacha.OMNAPCHLBHF(data.BJLONGBNPCI_SummonType);
						data.JNMMPPILMBC = false;
					}
					else
					{
						if(((1 << (int)data.BJLONGBNPCI_SummonType) & 0x22AU) == 0) // 010 0010 1010
						{
							if(((1 << (int)data.BJLONGBNPCI_SummonType) & 0x454U) == 0) // 100 0101 0100
							{
								continue;
							}
							else // 2/4/6/10
							{
								data.APHNELOFGAK_CurrencyId = DPBDFPPMIPH_Gacha.OMNAPCHLBHF(data.BJLONGBNPCI_SummonType);
								data.JNMMPPILMBC = DPBDFPPMIPH_Gacha.BANFOFKNKED(data.APHNELOFGAK_CurrencyId);
								if (!DPBDFPPMIPH_Gacha.FJAOAGNFABN_HasOneDay)
								{
									data.NCIBIAJJBFF = 0;
									data.GLBEAENLHKC_MaxLimit = DPBDFPPMIPH_Gacha.IBNBABPKLAA_GetMaxLimit();
									if (!data.JNMMPPILMBC)
									{
										data.NCIBIAJJBFF = data.GLBEAENLHKC_MaxLimit - DPBDFPPMIPH_Gacha.GECLFOEDJEI_GetOwnedQuantity();
									}
								}
								else
								{
									data.GLBEAENLHKC_MaxLimit = DPBDFPPMIPH_Gacha.ABNMIDCBENB_OneDay;
									EGOLBAPFHHD_Common.PCHECKGDJDK l = CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave.KCCLEHLLOFG_Common.BGDMJGDEKFJ_GetGachaDraw(DPBDFPPMIPH_Gacha.FDEBLMKEMLF_TypeAndSeriesId);
									data.NCIBIAJJBFF = DPBDFPPMIPH_Gacha.ABNMIDCBENB_OneDay;
									if(l != null)
									{
										data.NCIBIAJJBFF -= l.HMFFHLPNMPH;
									}
								}
								COMCFOFCGJM.Add(data);
							}
						}
						else //1/3/5/9
						{
							data.APHNELOFGAK_CurrencyId = DPBDFPPMIPH_Gacha.OMNAPCHLBHF(data.BJLONGBNPCI_SummonType);
							data.JNMMPPILMBC = false;
							data.GLBEAENLHKC_MaxLimit = DPBDFPPMIPH_Gacha.GBAMENANDAN_GetMaxLimit();
							data.NCIBIAJJBFF = 0;
							if(!data.JNMMPPILMBC)
							{
								data.NCIBIAJJBFF = data.GLBEAENLHKC_MaxLimit - DPBDFPPMIPH_Gacha.IEEHJPABKMP_GetOwnedQuantity();
							}
							FEMAEEHOCIJ.Add(data);
						}
					}
				}
			}
		}
	}

	//// RVA: 0xC7672C Offset: 0xC7672C VA: 0xC7672C
	public void NAIHICDHICH()
	{
		BGMDABJBHDM_Hour1 = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.GDEKCOOBLMA_System.NGHKJOEDLIP.FPBEBCIPEPI_GachaHour[0];
		NDNHABFJNDB_Hour2 = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.GDEKCOOBLMA_System.NGHKJOEDLIP.FPBEBCIPEPI_GachaHour[1];
		ACDBBJBNLLG_Hour3 = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.GDEKCOOBLMA_System.NGHKJOEDLIP.FPBEBCIPEPI_GachaHour[2];
		IDADEHNGHPO_Hour4 = BGMDABJBHDM_Hour1;
	}

	//// RVA: 0xC770DC Offset: 0xC770DC VA: 0xC770DC
	public DMBKENKBIJD EIPFDJBIOKN(bool HCFGINLICJN)
	{
		for(int i = 0; i < FEMAEEHOCIJ.Count; i++)
		{
			if(FEMAEEHOCIJ[i].BJLONGBNPCI_SummonType != GCAHJLOGMCI.NFCAJPIJFAM_SummonType.NGAHKKOBGPA_9 && !(FEMAEEHOCIJ[i].BJLONGBNPCI_SummonType == GCAHJLOGMCI.NFCAJPIJFAM_SummonType.GOAHICNDICO_5 && HCFGINLICJN))
			{
				return FEMAEEHOCIJ[i];
			}
		}
		return null;
	}

	//// RVA: 0xC771E0 Offset: 0xC771E0 VA: 0xC771E0
	public DMBKENKBIJD IIPOPGHKHBA(bool HCFGINLICJN)
	{
		for (int i = 0; i < COMCFOFCGJM.Count; i++)
		{
			if (COMCFOFCGJM[i].BJLONGBNPCI_SummonType != GCAHJLOGMCI.NFCAJPIJFAM_SummonType.BPPLDIBMPKH_10 && !(COMCFOFCGJM[i].BJLONGBNPCI_SummonType == GCAHJLOGMCI.NFCAJPIJFAM_SummonType.LMHDFEKIDKG_6 && HCFGINLICJN))
			{
				return COMCFOFCGJM[i];
			}
		}
		return null;
	}

	//// RVA: 0xC772DC Offset: 0xC772DC VA: 0xC772DC
	public DMBKENKBIJD PANFEKFCCOA()
	{
		for (int i = 0; i < FEMAEEHOCIJ.Count; i++)
		{
			if (FEMAEEHOCIJ[i].DPBDFPPMIPH_Gacha.INDDJNMPONH_Category == GCAHJLOGMCI.KNMMOMEHDON_GachaType.DLOPEFGOAPD_10)
				return FEMAEEHOCIJ[i];
			if(FEMAEEHOCIJ[i].BJLONGBNPCI_SummonType >= GCAHJLOGMCI.NFCAJPIJFAM_SummonType.GOAHICNDICO_5 && FEMAEEHOCIJ[i].BJLONGBNPCI_SummonType <= GCAHJLOGMCI.NFCAJPIJFAM_SummonType.LMHDFEKIDKG_6)
				return FEMAEEHOCIJ[i];
		}
		return null;
	}

	//// RVA: 0xC77408 Offset: 0xC77408 VA: 0xC77408
	public DMBKENKBIJD LBEHCJMJBGC()
	{
		for (int i = 0; i < COMCFOFCGJM.Count; i++)
		{
			if (COMCFOFCGJM[i].BJLONGBNPCI_SummonType >= GCAHJLOGMCI.NFCAJPIJFAM_SummonType.GOAHICNDICO_5 && COMCFOFCGJM[i].BJLONGBNPCI_SummonType <= GCAHJLOGMCI.NFCAJPIJFAM_SummonType.LMHDFEKIDKG_6)
				return COMCFOFCGJM[i];
		}
		return null;
	}

	//// RVA: 0xC774F0 Offset: 0xC774F0 VA: 0xC774F0
	public DMBKENKBIJD CLPPBCBBNIB()
	{
		for (int i = 0; i < FEMAEEHOCIJ.Count; i++)
		{
			if (FEMAEEHOCIJ[i].BJLONGBNPCI_SummonType >= GCAHJLOGMCI.NFCAJPIJFAM_SummonType.NGAHKKOBGPA_9 && FEMAEEHOCIJ[i].BJLONGBNPCI_SummonType <= GCAHJLOGMCI.NFCAJPIJFAM_SummonType.BPPLDIBMPKH_10)
				return FEMAEEHOCIJ[i];
		}
		return null;
	}

	//// RVA: 0xC775D8 Offset: 0xC775D8 VA: 0xC775D8
	public DMBKENKBIJD NILCJCEOBME()
	{
		for (int i = 0; i < COMCFOFCGJM.Count; i++)
		{
			if (COMCFOFCGJM[i].BJLONGBNPCI_SummonType >= GCAHJLOGMCI.NFCAJPIJFAM_SummonType.NGAHKKOBGPA_9 && COMCFOFCGJM[i].BJLONGBNPCI_SummonType <= GCAHJLOGMCI.NFCAJPIJFAM_SummonType.BPPLDIBMPKH_10)
				return COMCFOFCGJM[i];
		}
		return null;
	}

	//// RVA: 0xC776C0 Offset: 0xC776C0 VA: 0xC776C0
	public int BJLPJAAIMKC()
	{
		IFBCGCCJBHI data = new IFBCGCCJBHI();
		data.KHEKNNFCAOI();
		return Database.Instance.tutorialPaidVC + data.FNCPAEFEECO_CurrencyPaid;
	}

	//// RVA: 0xC7779C Offset: 0xC7779C VA: 0xC7779C
	//public int CMHHHCAKPCD(GCAHJLOGMCI.NFCAJPIJFAM BJLONGBNPCI) { }

	//// RVA: 0xC76EA0 Offset: 0xC76EA0 VA: 0xC76EA0
	public static int CMHHHCAKPCD(LOBDIAABMKG DPBDFPPMIPH, GCAHJLOGMCI.NFCAJPIJFAM_SummonType BJLONGBNPCI)
	{
		if(DPBDFPPMIPH.INDDJNMPONH_Category != GCAHJLOGMCI.KNMMOMEHDON_GachaType.DLOPEFGOAPD_10)
		{
			return CIOECGOMILE.HHCJCDFCLOB.NBJOCMAJLPK_GetTotalCurrency(DPBDFPPMIPH.OMNAPCHLBHF(BJLONGBNPCI));
		}
		return EKLNMHFCAOI.ALHCGDMEMID_GetNumItems(IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database, CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave, EKLNMHFCAOI.BKHFLDMOGBD_GetItemCategory(DPBDFPPMIPH.MJNOAMAFNHA_CostItemId), EKLNMHFCAOI.DEACAHNLMNI_getItemId(DPBDFPPMIPH.MJNOAMAFNHA_CostItemId), null);
	}

	//// RVA: 0xC777A4 Offset: 0xC777A4 VA: 0xC777A4
	public long ENDIPBKOIOL()
	{
		return ENDIPBKOIOL(DPBDFPPMIPH_Gacha, JHNMKKNEENE_Time);
	}

	//// RVA: 0xC777C8 Offset: 0xC777C8 VA: 0xC777C8
	public static long ENDIPBKOIOL(LOBDIAABMKG DPBDFPPMIPH, long JHNMKKNEENE)
	{
		List<NKFJNAANPNP.MOJLCADLMKH> l = BNGLMLIMFDM(DPBDFPPMIPH, JHNMKKNEENE);
		if(l.Count > 0)
		{
			return l[0].HNKFMAJIFJD_ExpireAt;
		}
		return 0;
	}

	//// RVA: 0xC782CC Offset: 0xC782CC VA: 0xC782CC
	//public List<NKFJNAANPNP.MOJLCADLMKH> BNGLMLIMFDM() { }

	//// RVA: 0xC778C4 Offset: 0xC778C4 VA: 0xC778C4
	public static List<NKFJNAANPNP.MOJLCADLMKH> BNGLMLIMFDM(LOBDIAABMKG DPBDFPPMIPH, long JHNMKKNEENE)
	{
		List<NKFJNAANPNP.MOJLCADLMKH> res = new List<NKFJNAANPNP.MOJLCADLMKH>();
		if(DPBDFPPMIPH.INDDJNMPONH_Category == GCAHJLOGMCI.KNMMOMEHDON_GachaType.OOABDNHIEFK_9)
		{
			int a = DPBDFPPMIPH.OMNAPCHLBHF(GCAHJLOGMCI.NFCAJPIJFAM_SummonType.GOAHICNDICO_5);
			if (a == 0)
				a = DPBDFPPMIPH.OMNAPCHLBHF(GCAHJLOGMCI.NFCAJPIJFAM_SummonType.LMHDFEKIDKG_6);
			int num = CIOECGOMILE.HHCJCDFCLOB.NBJOCMAJLPK_GetTotalCurrency(a);
			NKFJNAANPNP.MOJLCADLMKH data = new NKFJNAANPNP.MOJLCADLMKH();
			data.LHPDDGIJKNB((int)(JHNMKKNEENE * 0x227));
			data.HMFFHLPNMPH_Remaining = num;
			data.HNKFMAJIFJD_ExpireAt = DPBDFPPMIPH.HIPBEKBFNBG(a);
			res.Add(data);
		}
		else if(DPBDFPPMIPH.INDDJNMPONH_Category != GCAHJLOGMCI.KNMMOMEHDON_GachaType.DLOPEFGOAPD_10)
		{
			int a = DPBDFPPMIPH.OMNAPCHLBHF(GCAHJLOGMCI.NFCAJPIJFAM_SummonType.GOAHICNDICO_5);
			if (a == 0)
				a = DPBDFPPMIPH.OMNAPCHLBHF(GCAHJLOGMCI.NFCAJPIJFAM_SummonType.LMHDFEKIDKG_6);
			List<HPBDNNACBAK.MBMMGKJBJGD> d = NKGJPJPHLIF.HHCJCDFCLOB.FPNBCFJHENI.GGKFCDDFHFP.FindAll((HPBDNNACBAK.MBMMGKJBJGD GHPLINIACBB) =>
			{
				//0xC799B8
				return a == GHPLINIACBB.PPFNGGCBJKC_Id;
			});
			if (d.Count < 1)
				return res;
			d.Sort((HPBDNNACBAK.MBMMGKJBJGD HKICMNAACDA, HPBDNNACBAK.MBMMGKJBJGD BNKHBCBJBKI) =>
			{
				//0xC79964
				return (int)(HKICMNAACDA.DJJENNPDPCM_ExpireAt - BNKHBCBJBKI.DJJENNPDPCM_ExpireAt);
			});
			for(int i = 0; i < d.Count; i++)
			{
				NKFJNAANPNP.MOJLCADLMKH data = new NKFJNAANPNP.MOJLCADLMKH();
				data.LHPDDGIJKNB((int)(JHNMKKNEENE * 0x227));
				data.HMFFHLPNMPH_Remaining = d[i].HNBFOAJIIAL_Remaining;
				data.HNKFMAJIFJD_ExpireAt = (int)d[i].DJJENNPDPCM_ExpireAt;
				res.Add(data);
			}
			return res;
		}
		EKLNMHFCAOI.FKGCBLHOOCL_Category cat = EKLNMHFCAOI.BKHFLDMOGBD_GetItemCategory(DPBDFPPMIPH.MJNOAMAFNHA_CostItemId);
		int itemId = EKLNMHFCAOI.DEACAHNLMNI_getItemId(DPBDFPPMIPH.MJNOAMAFNHA_CostItemId);
		if(cat == EKLNMHFCAOI.FKGCBLHOOCL_Category.CKCPFLDGILD_LimitedCompoItem)
		{
			res.AddRange(CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave.GJCOJBDOOJG_LimitedCompoItem.BNGLMLIMFDM(itemId, JHNMKKNEENE));
		}
		else if(cat == EKLNMHFCAOI.FKGCBLHOOCL_Category.DLOPEFGOAPD_LimitedItem)
		{
			res.AddRange(CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave.AFHFIPLOKMN_LimitedItem.BNGLMLIMFDM(itemId, JHNMKKNEENE));
		}
		else if(cat == EKLNMHFCAOI.FKGCBLHOOCL_Category.CIOGEKJNMBB_RareUpItem)
		{
			res.AddRange(CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave.DPNKPPBEAGJ_RareUpItem.MCPIBDPKBBD(JHNMKKNEENE));
		}
		else
		{
			NKFJNAANPNP.MOJLCADLMKH data = new NKFJNAANPNP.MOJLCADLMKH();
			data.LHPDDGIJKNB((int)(JHNMKKNEENE * 0x227));
			data.HMFFHLPNMPH_Remaining = EKLNMHFCAOI.ALHCGDMEMID_GetNumItems(IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database, CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave, cat, itemId, null);
			data.HNKFMAJIFJD_ExpireAt = 0;
			res.Add(data);
		}
		return res;
	}

	//// RVA: 0xC782F8 Offset: 0xC782F8 VA: 0xC782F8
	public ABBPGMEDDHD MFMBCIKGCFC()
	{
		DateTime t = Utility.GetLocalDateTime(JHNMKKNEENE_Time);
		if(t.Hour < 0 || BGMDABJBHDM_Hour1 <= t.Hour)
		{
			if(BGMDABJBHDM_Hour1 > t.Hour || t.Hour >= NDNHABFJNDB_Hour2)
			{
				if(NDNHABFJNDB_Hour2 > t.Hour)
				{
					if(t.Hour >= ACDBBJBNLLG_Hour3)
					{
						if (ACDBBJBNLLG_Hour3 > t.Hour)
							return ABBPGMEDDHD.HNOJIKHAPHA_0;
						else
						{
							if (t.Hour >= IDADEHNGHPO_Hour4)
								return ABBPGMEDDHD.HNOJIKHAPHA_0;
							else
								return ABBPGMEDDHD.KHLPAOENONH_2;
						}
					}
				}
				return ABBPGMEDDHD.HCBFMFONIOE_1;
			}
			return ABBPGMEDDHD.HNOJIKHAPHA_0;
		}
		return ABBPGMEDDHD.KHLPAOENONH_2;
	}

	//// RVA: 0xC78420 Offset: 0xC78420 VA: 0xC78420
	public string MJLAFJJOGEE()
	{
		MessageBank bk = MessageManager.Instance.GetBank("menu");
		long t = DPBDFPPMIPH_Gacha.EABMLBFHJBH_CloseAt;
		if (t != 0)
		{
			DateTime dt = Utility.GetLocalDateTime(t);
			return string.Format(bk.GetMessageByLabel(bk.GetMessageByLabel("gacha_period")), new object[4]
			{
				dt.Month, dt.Day, dt.Hour, dt.Minute
			});
		}
		else
		{
			return string.Format(bk.GetMessageByLabel(bk.GetMessageByLabel("gacha_period")), new object[4]
			{
				"--", "--", "--", "--"
			});
		}
	}

	//// RVA: 0xC7897C Offset: 0xC7897C VA: 0xC7897C
	public string IFLJEIDBBPP()
	{
		MessageBank bk = MessageManager.Instance.GetBank("menu");
		return string.Format(bk.GetMessageByLabel("gacha_main_timezone"), new object[6]
		{
			LPBKEJGPMFJ(bk.GetMessageByLabel("gacha_main_timezone_time"), BGMDABJBHDM_Hour1 * 60),
			LPBKEJGPMFJ(bk.GetMessageByLabel("gacha_main_timezone_time"), NDNHABFJNDB_Hour2 * 60 - 1),
			LPBKEJGPMFJ(bk.GetMessageByLabel("gacha_main_timezone_time"), NDNHABFJNDB_Hour2 * 60),
			LPBKEJGPMFJ(bk.GetMessageByLabel("gacha_main_timezone_time"), ACDBBJBNLLG_Hour3 * 60 - 1),
			LPBKEJGPMFJ(bk.GetMessageByLabel("gacha_main_timezone_time"), ACDBBJBNLLG_Hour3 * 60),
			LPBKEJGPMFJ(bk.GetMessageByLabel("gacha_main_timezone_time"), BGMDABJBHDM_Hour1 * 60 - 1)
		});
	}

	//// RVA: 0xC78DC0 Offset: 0xC78DC0 VA: 0xC78DC0
	private string LPBKEJGPMFJ(string BJIECJAOMDJ, int CONKAOFGIAJ)
	{
		return string.Format(BJIECJAOMDJ, CONKAOFGIAJ / 60, CONKAOFGIAJ % 60);
	}

	//// RVA: 0xC78E78 Offset: 0xC78E78 VA: 0xC78E78
	public bool GPKAMGNBGAB()
	{
		int a = DPBDFPPMIPH_Gacha.OMNAPCHLBHF(GCAHJLOGMCI.NFCAJPIJFAM_SummonType.GOAHICNDICO_5);
		if (a == 0)
		{
			a = DPBDFPPMIPH_Gacha.OMNAPCHLBHF(GCAHJLOGMCI.NFCAJPIJFAM_SummonType.LMHDFEKIDKG_6);
		}
		return DPBDFPPMIPH_Gacha.GPKAMGNBGAB(a);
	}

	//// RVA: 0xC78F04 Offset: 0xC78F04 VA: 0xC78F04
	public bool ALPOJNBHNDK()
	{
		int a = DPBDFPPMIPH_Gacha.OMNAPCHLBHF(GCAHJLOGMCI.NFCAJPIJFAM_SummonType.GOAHICNDICO_5);
		if (a == 0)
		{
			a = DPBDFPPMIPH_Gacha.OMNAPCHLBHF(GCAHJLOGMCI.NFCAJPIJFAM_SummonType.LMHDFEKIDKG_6);
		}
		return DPBDFPPMIPH_Gacha.ALPOJNBHNDK(a, JHNMKKNEENE_Time);
	}

	//// RVA: 0xC78FAC Offset: 0xC78FAC VA: 0xC78FAC
	public List<HGBOODNMNFM> BMJOENJMFEL(int BCCHOBPJJKE)
	{
		return DPBDFPPMIPH_Gacha.KACECFNECON.NNDMIOEKKMM_NewEpisode.FindAll((HGBOODNMNFM FELIFAHDLON) =>
		{
			//0xC799FC
			return FELIFAHDLON.ADDCEJNOJLG_Scenes.Find((CEBFFLDKAEC_SecureInt PPFNGGCBJKC) =>
			{
				//0xC79AE8
				return PPFNGGCBJKC.DNJEJEANJGL_Value == BCCHOBPJJKE;
			}) != null;
		});
	}

	//// RVA: 0xC790D4 Offset: 0xC790D4 VA: 0xC790D4
	public bool NLFPCMJMAEM()
	{
		if(DPBDFPPMIPH_Gacha.KACECFNECON != null)
		{
			if(DPBDFPPMIPH_Gacha.KACECFNECON.PGKIHFOKEHL_Feature != null)
			{
				for(int i = 0; i < DPBDFPPMIPH_Gacha.KACECFNECON.PGKIHFOKEHL_Feature.Count; i++)
				{
					MLIBEPGADJH_Scene.KKLDOOJBJMN scene = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.ECNHDEHADGL_Scene.CDENCMNHNGA_SceneList[DPBDFPPMIPH_Gacha.KACECFNECON.PGKIHFOKEHL_Feature[i].DNJEJEANJGL_Value - 1];
					if (scene.OOOPJNKBDIL_Is6OrMoreRarity())
						return true;
				}
			}
		}
		return false;
	}

	//// RVA: 0xC7930C Offset: 0xC7930C VA: 0xC7930C
	//public int MNDAKJNHNIB() { }

	//// RVA: 0xC796C4 Offset: 0xC796C4 VA: 0xC796C4
	public void FBANBDCOEJL_Update()
	{
		CEPJKBFGKEN.Update();
		LBMILLAEEBK.Update();
		MMJONIHIOFI.Update();
	}

	//// RVA: 0xC79734 Offset: 0xC79734 VA: 0xC79734
	public void FFCMGLOBPAJ_Release()
	{
		CEPJKBFGKEN.Terminated();
		LBMILLAEEBK.Terminated();
		MMJONIHIOFI.Terminated();
	}

	//// RVA: 0xC797BC Offset: 0xC797BC VA: 0xC797BC
	public bool CJOOOBKFMGJ_IsLoading()
	{
		return CEPJKBFGKEN.IsLoading() || LBMILLAEEBK.IsLoading() || MMJONIHIOFI.IsLoading();
	}
}
