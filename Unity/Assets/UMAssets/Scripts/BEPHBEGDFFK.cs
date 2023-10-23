
using System;
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
		public LOBDIAABMKG DPBDFPPMIPH { get; set; } // 0x8 MEMIBJHJPHG HLFDKACMMPC POCCHIIKMHM
		//public GCAHJLOGMCI.KNMMOMEHDON INDDJNMPONH { get; } 0xC773E4 GHAILOLPHPF
		public GCAHJLOGMCI.NFCAJPIJFAM BJLONGBNPCI { get; set; } // 0xC JGCNCCFPMNF CFCGLCHKOMM PEDOGIFGENK
		public int APHNELOFGAK { get; set; } // 0x10 JNPILMHHIID PHLOINCPBDJ BNGDDADJBBA
		public int KPIHBPMOGKL { get; set; } // 0x14 ICJNODPNEIM PHINOMJKNGN JPPBNGENACJ
		public int GLBEAENLHKC_MaxLimit { get; set; } // 0x18 FAIFKIODKHE NOAKFOIOJBH PBGBHOBHBMG
		public int NCIBIAJJBFF { get; set; } // 0x1C CHDJEBBMDPL GAABCDHLDAK MHBFHKKMIKC
		public string MDEIKCBEHHC { get; set; } // 0x20 PNJMLBIKKNG PKENIFNAJDL BPNCHKKFDJH
		public bool JNMMPPILMBC { get; set; } // 0x24 ADCKOLKFCKI FOHFHKAOFBK JCOCMGIEKEG
		public long JHNMKKNEENE { get; set; } // 0x28 ONDHIJNKPFO NBICELIKAMG IAGCKLBBEJE
		public KBPDNHOKEKD_ProductId MEANCEOIMGE { get; set; } // 0x30 CKCBLOOEBDC HAPHCPMEHDK ENENFIFJJGN

		//// RVA: 0xC79BA4 Offset: 0xC79BA4 VA: 0xC79BA4
		//public int ILFAHJEJCMH() { }

		//// RVA: 0xC79D38 Offset: 0xC79D38 VA: 0xC79D38
		//public int BJLPJAAIMKC() { }

		//// RVA: 0xC79E14 Offset: 0xC79E14 VA: 0xC79E14
		//public int CMHHHCAKPCD() { }
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
	public LOBDIAABMKG DPBDFPPMIPH { get; private set; } // 0x14 MEMIBJHJPHG HLFDKACMMPC POCCHIIKMHM
	public long JHNMKKNEENE { get; private set; } // 0x18 ONDHIJNKPFO NBICELIKAMG IAGCKLBBEJE
	public int BGMDABJBHDM_Hour1 { get; private set; } // 0x20 AJDKMIJGILO MJAHOGAKIFN ACEHDFGCEDH
	public int NDNHABFJNDB_Hour2 { get; private set; } // 0x24 PLPEDAFOMEO NMNPPNGMBMD NNNOHPKKLOP
	public int ACDBBJBNLLG_Hour3 { get; private set; } // 0x28 MMDJFDBBJMD OGMCAHJCKOO IKCOANPHPGL
	public int IDADEHNGHPO_Hour4 { get; private set; } // 0x2C JNEODDGOEFL MGIBGJPEDHA LIGGEFLLMKB

	//// RVA: 0xC76548 Offset: 0xC76548 VA: 0xC76548
	//public void KHEKNNFCAOI() { }

	//// RVA: 0xC768D8 Offset: 0xC768D8 VA: 0xC768D8
	public void DOMFHDPMCCO(LOBDIAABMKG NDNHHGJKJGM, int IMKLJJIBHCN, long EOLFJGMAJAB)
	{
		JHNMKKNEENE = EOLFJGMAJAB;
		DPBDFPPMIPH = NDNHHGJKJGM;
		BADFIKBADNH_PickupId = IMKLJJIBHCN;
		FEMAEEHOCIJ.Clear();
		COMCFOFCGJM.Clear();
		for(int i = 10; i >= 0; i--)
		{
			KBPDNHOKEKD_ProductId p = DPBDFPPMIPH.DBHIEABGKII((GCAHJLOGMCI.NFCAJPIJFAM)(i + 1));
			if(p != null)
			{
				DMBKENKBIJD data = new DMBKENKBIJD();
				data.MEANCEOIMGE = p;
				data.DPBDFPPMIPH = DPBDFPPMIPH;
				data.BJLONGBNPCI = (GCAHJLOGMCI.NFCAJPIJFAM)(i + 1);
				data.JHNMKKNEENE = JHNMKKNEENE;
				data.KPIHBPMOGKL = p.JHAIOJELFHI;
				data.MDEIKCBEHHC = DPBDFPPMIPH.KKODAOIJHMC(data.BJLONGBNPCI);
				if(DPBDFPPMIPH.INDDJNMPONH_Category == GCAHJLOGMCI.KNMMOMEHDON.DLOPEFGOAPD_10)
				{
					data.KPIHBPMOGKL = Mathf.Clamp(CMHHHCAKPCD(DPBDFPPMIPH, data.BJLONGBNPCI), 1, 10);
				}
				if(data.BJLONGBNPCI <= GCAHJLOGMCI.NFCAJPIJFAM.AEFCOHJBLPO_11)
				{
					if(data.BJLONGBNPCI == GCAHJLOGMCI.NFCAJPIJFAM.NGAHKKOBGPA_9)
					{
						data.APHNELOFGAK = DPBDFPPMIPH.OMNAPCHLBHF(data.BJLONGBNPCI);
						data.JNMMPPILMBC = false;
					}
					else
					{
						if(((1 << (int)data.BJLONGBNPCI) & 0x454U) == 0) // 0100 0101 0100
						{
							if(((1 << (int)data.BJLONGBNPCI) & 0x8a8U) == 0) // 1000 1010 1000{
							{
								continue;
							}
							else
							{
								data.APHNELOFGAK = DPBDFPPMIPH.OMNAPCHLBHF(data.BJLONGBNPCI);
								data.JNMMPPILMBC = DPBDFPPMIPH.BANFOFKNKED(data.APHNELOFGAK);
								if (!DPBDFPPMIPH.FJAOAGNFABN)
								{
									data.NCIBIAJJBFF = 0;
									data.GLBEAENLHKC_MaxLimit = DPBDFPPMIPH.IBNBABPKLAA_GetMaxLimit();
									if (!data.JNMMPPILMBC)
									{
										data.NCIBIAJJBFF = data.GLBEAENLHKC_MaxLimit - DPBDFPPMIPH.GECLFOEDJEI_GetOwnedQuantity();
									}
								}
								else
								{
									data.GLBEAENLHKC_MaxLimit = DPBDFPPMIPH.ABNMIDCBENB;
									EGOLBAPFHHD_Common.PCHECKGDJDK l = CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave.KCCLEHLLOFG_Common.BGDMJGDEKFJ_GetGachaDraw(DPBDFPPMIPH.FDEBLMKEMLF_TypeAndSeriesId);
									data.NCIBIAJJBFF = DPBDFPPMIPH.ABNMIDCBENB;
									if(l != null)
									{
										data.NCIBIAJJBFF -= l.HMFFHLPNMPH;
									}
								}
								COMCFOFCGJM.Add(data);
							}
						}
						else
						{
							data.APHNELOFGAK = DPBDFPPMIPH.OMNAPCHLBHF(data.BJLONGBNPCI);
							data.JNMMPPILMBC = false;
							data.GLBEAENLHKC_MaxLimit = DPBDFPPMIPH.GBAMENANDAN_GetMaxLimit();
							data.NCIBIAJJBFF = 0;
							if(!data.JNMMPPILMBC)
							{
								data.NCIBIAJJBFF = data.GLBEAENLHKC_MaxLimit - DPBDFPPMIPH.IEEHJPABKMP_GetOwnedQuantity();
							}
							FEMAEEHOCIJ.Add(data);
						}
					}
				}
			}
		}
	}

	//// RVA: 0xC7672C Offset: 0xC7672C VA: 0xC7672C
	//public void NAIHICDHICH() { }

	//// RVA: 0xC770DC Offset: 0xC770DC VA: 0xC770DC
	//public BEPHBEGDFFK.DMBKENKBIJD EIPFDJBIOKN(bool HCFGINLICJN) { }

	//// RVA: 0xC771E0 Offset: 0xC771E0 VA: 0xC771E0
	//public BEPHBEGDFFK.DMBKENKBIJD IIPOPGHKHBA(bool HCFGINLICJN) { }

	//// RVA: 0xC772DC Offset: 0xC772DC VA: 0xC772DC
	//public BEPHBEGDFFK.DMBKENKBIJD PANFEKFCCOA() { }

	//// RVA: 0xC77408 Offset: 0xC77408 VA: 0xC77408
	//public BEPHBEGDFFK.DMBKENKBIJD LBEHCJMJBGC() { }

	//// RVA: 0xC774F0 Offset: 0xC774F0 VA: 0xC774F0
	//public BEPHBEGDFFK.DMBKENKBIJD CLPPBCBBNIB() { }

	//// RVA: 0xC775D8 Offset: 0xC775D8 VA: 0xC775D8
	//public BEPHBEGDFFK.DMBKENKBIJD NILCJCEOBME() { }

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
	public static int CMHHHCAKPCD(LOBDIAABMKG DPBDFPPMIPH, GCAHJLOGMCI.NFCAJPIJFAM BJLONGBNPCI)
	{
		if(DPBDFPPMIPH.INDDJNMPONH_Category != GCAHJLOGMCI.KNMMOMEHDON.DLOPEFGOAPD_10)
		{
			return CIOECGOMILE.HHCJCDFCLOB.NBJOCMAJLPK_GetTotalCurrency(DPBDFPPMIPH.OMNAPCHLBHF(BJLONGBNPCI));
		}
		return EKLNMHFCAOI.ALHCGDMEMID_GetNumItems(IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database, CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave, EKLNMHFCAOI.BKHFLDMOGBD_GetItemCategory(DPBDFPPMIPH.MJNOAMAFNHA), EKLNMHFCAOI.DEACAHNLMNI_getItemId(DPBDFPPMIPH.MJNOAMAFNHA), null);
	}

	//// RVA: 0xC777A4 Offset: 0xC777A4 VA: 0xC777A4
	//public long ENDIPBKOIOL() { }

	//// RVA: 0xC777C8 Offset: 0xC777C8 VA: 0xC777C8
	//public static long ENDIPBKOIOL(LOBDIAABMKG DPBDFPPMIPH, long JHNMKKNEENE) { }

	//// RVA: 0xC782CC Offset: 0xC782CC VA: 0xC782CC
	//public List<NKFJNAANPNP.MOJLCADLMKH> BNGLMLIMFDM() { }

	//// RVA: 0xC778C4 Offset: 0xC778C4 VA: 0xC778C4
	//public static List<NKFJNAANPNP.MOJLCADLMKH> BNGLMLIMFDM(LOBDIAABMKG DPBDFPPMIPH, long JHNMKKNEENE) { }

	//// RVA: 0xC782F8 Offset: 0xC782F8 VA: 0xC782F8
	public ABBPGMEDDHD MFMBCIKGCFC()
	{
		DateTime t = Utility.GetLocalDateTime(JHNMKKNEENE);
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
		long t = DPBDFPPMIPH.EABMLBFHJBH;
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
	//public bool GPKAMGNBGAB() { }

	//// RVA: 0xC78F04 Offset: 0xC78F04 VA: 0xC78F04
	//public bool ALPOJNBHNDK() { }

	//// RVA: 0xC78FAC Offset: 0xC78FAC VA: 0xC78FAC
	public List<HGBOODNMNFM> BMJOENJMFEL(int BCCHOBPJJKE)
	{
		return DPBDFPPMIPH.KACECFNECON.NNDMIOEKKMM.FindAll((HGBOODNMNFM FELIFAHDLON) =>
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
	//public bool NLFPCMJMAEM() { }

	//// RVA: 0xC7930C Offset: 0xC7930C VA: 0xC7930C
	//public int MNDAKJNHNIB() { }

	//// RVA: 0xC796C4 Offset: 0xC796C4 VA: 0xC796C4
	//public void FBANBDCOEJL() { }

	//// RVA: 0xC79734 Offset: 0xC79734 VA: 0xC79734
	//public void FFCMGLOBPAJ() { }

	//// RVA: 0xC797BC Offset: 0xC797BC VA: 0xC797BC
	//public bool CJOOOBKFMGJ() { }
}
