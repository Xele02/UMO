
using System.Collections.Generic;
using XeSys;

public class KDDNHFJFENA
{
	public string FJGCDPLCIAK; // 0x8
	public string JPBAJIPKCPG; // 0xC
}

public class FHPFLAGNCAF
{
	public string FJGCDPLCIAK; // 0x8
	public string OPFGFINHFCE; // 0xC
	public string KLMPFGOCBHC; // 0x10
	public string IPFEKNMBEBI; // 0x14
	public int NPPGKNGIFGK; // 0x18
	public string NGIKLCDKAMB; // 0x1C
	public string JMEMGIPGGIK; // 0x20
	public int OJIMENABACH; // 0x24
	public string KACECFNECON; // 0x28
	public long KBFOIECIADN; // 0x30
	public long EGBOHDFBAPB; // 0x38
	public KDDNHFJFENA IPOKMIAHMNF; // 0x40

	//// RVA: 0x14E8444 Offset: 0x14E8444 VA: 0x14E8444
	public void KHEKNNFCAOI(EDOHBJAPLPF_JsonData IDLHJIOMJBK)
	{
		TodoLogger.LogError(0, "FHPFLAGNCAF.KHEKNNFCAOI");
	}

	//// RVA: 0x14E8700 Offset: 0x14E8700 VA: 0x14E8700
	//public void DJMMLIICFBG() { }
}

public class NHPDPKHMFEP
{
	public enum CJDLIFEENBF
	{
		GDMHELGCMHC = 0,
		KPFIEBIKDFN = 1,
		GGCDANOKPMB = 2,
		EANGJBHNNHF = 3,
		HHEAABDHNAE = 4,
		NGBOABGLAMM = 5,
	}

	public enum GGNEBJEIFCP
	{
		CCAPCGPIIPF = 0,
		AJAHGGBMOJE = 1,
	}
	
	private const long HEJACPECLEH = 9223372036854775807;
	public static bool KKCKPHAFBDO = false; // 0x4
	public static string JHGKHBGAJJJ = JpStringLiterals.StringLiteral_9874; // 0x8
	public static string JKKDACNKPCP = JpStringLiterals.StringLiteral_9874; // 0xC
	public CJDLIFEENBF KCKKCNPGMDC; // 0x8
	private bool HNNAJBJCNEJ; // 0xC
	private JAILOEFCNJP.BEBLECKOAPK MKBOKLLDCFI; // 0x10
	private bool BHGMFDECGPG; // 0x14
	private long AGHHAHBJGMH; // 0x18
	public List<FHPFLAGNCAF> MHKCPJDNJKI = new List<FHPFLAGNCAF>(); // 0x20
	public JKNGJFOBADP BEJHIEGCGNE = new JKNGJFOBADP(); // 0x24
	public List<GJDFHLBONOL> LKNKNKAALJO = new List<GJDFHLBONOL>(); // 0x28
	public int DMFNALAGLHH; // 0x2C

	public static NHPDPKHMFEP HHCJCDFCLOB { get; private set; } // 0x0 LGMPACEDIJF NKACBOEHELJ OKPMHKNCNAL
	public bool DLGMLAJMLOP { 
		get
		{//JOMOJIMDBDO 0x18977BC
			if(!BHGMFDECGPG)
			{
				if(IMMAOANGPNK.HHCJCDFCLOB == null)
					return false;
				return IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.MEGJDBJCEOC_MonthlyPass.LPJLEHAJADA_GetValue("always_get_subscription", 0) != 0;
			}
			return true;
		} 
		set
		{ // LDODJDMAEHG 0x1897910
			BHGMFDECGPG = value;
		} }

	// // RVA: 0x1897918 Offset: 0x1897918 VA: 0x1897918
	public void IJBGPAENLJA()
	{
		HHCJCDFCLOB = this;
	}

	// // RVA: 0x1897998 Offset: 0x1897998 VA: 0x1897998
	private bool AIJFDCIDDLO(SakashoErrorId PPFNGGCBJKC)
	{
		TodoLogger.LogError(0, "AIJFDCIDDLO");
		return false;
	}

	// // RVA: 0x18979DC Offset: 0x18979DC VA: 0x18979DC
	public void OFKONDFPMLJ_GetProducts(IMCBBOAFION BHFHGFKBOHH, DJBHIFLHJLK AOCANKOMKFG)
	{
		MHKCPJDNJKI.Clear();
		if(IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.MEGJDBJCEOC_MonthlyPass.AJHBAOCLNDF_MasterSw == 0)
		{
			BHFHGFKBOHH();
			return;
		}
		AHOBHNDOEBO req = NKGJPJPHLIF.HHCJCDFCLOB.IBLPICFDGOF_ServerRequester.IFFNCAFNEAG_AddRequest(new AHOBHNDOEBO());
		req.NBFDEFGFLPJ = AIJFDCIDDLO;
		req.BHFHGFKBOHH_OnSuccess = (CACGCMBKHDI_Request JIPCHHHLOMM) =>
		{
			//0x189BF54
			for(int i = 0; i < req.NFEAMMJIMPG.MHKCPJDNJKI.Count; i++)
			{
				MHKCPJDNJKI.Add(req.NFEAMMJIMPG.MHKCPJDNJKI[i]);
			}
			BHFHGFKBOHH();
		};
		req.MOBEEPPKFLG_OnFail = (CACGCMBKHDI_Request JIPCHHHLOMM) =>
		{
			//0x189C0D0
			TodoLogger.LogError(0, "MOBEEPPKFLG_OnFail");
		};
	}

	// // RVA: 0x1897D38 Offset: 0x1897D38 VA: 0x1897D38
	public void NDAIOIOMPGG(IMCBBOAFION BHFHGFKBOHH, DJBHIFLHJLK AOCANKOMKFG)
	{
		int CMCKNKKCNDK = 0;
		if (IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.MEGJDBJCEOC_MonthlyPass.AJHBAOCLNDF_MasterSw != 0)
		{
			if(CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave.JHFIPCIHJNL_Base.IJHBIMNKOMC_TutorialEnd == 2)
			{
				long EOLFJGMAJAB = NKGJPJPHLIF.HHCJCDFCLOB.IBLPICFDGOF_ServerRequester.FJDBNGEPKHL.KMEFBNBFJHI_GetServerTime();
				if(!DLGMLAJMLOP)
				{
					int mpass_update_duration = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.MEGJDBJCEOC_MonthlyPass.LPJLEHAJADA_GetValue("mpass_update_duration", 10800);
					if((EOLFJGMAJAB - AGHHAHBJGMH) < mpass_update_duration)
					{
						BHFHGFKBOHH();
					}
					HNNAJBJCNEJ = false;
					LGIDLHLBFFJ_MonthlyPass PJJEOFOFDCO = CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave.HMMNDKHKEBC_MonthlyPass;
					string KHACGAGBDHN = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.MEGJDBJCEOC_MonthlyPass.EFEGBHACJAL("topplan_unique_key", "");
					int GAFIOALKHIM = 0;
					if(PJJEOFOFDCO.KJBOIGIDKIF_Platform == 0)
					{
						PJJEOFOFDCO.KJBOIGIDKIF_Platform = 1;
					}
					string EEMFGMEEBDC = "";
					string NJFKGJKINAG = "google";
					EEMFGMEEBDC = PJJEOFOFDCO.KJBOIGIDKIF_Platform == 1 ? "google" : "apple";
					int OCHIFBIBEOK = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.MEGJDBJCEOC_MonthlyPass.LPJLEHAJADA_GetValue("hotfix_3_4_1_android", 0);
					long BMHKJPHNCIJ = PJJEOFOFDCO.FMPLMFLMJNE_Last[0].FDFGEMODIIF_StartedAt;
					long KMJCPOGCJDG = PJJEOFOFDCO.FMPLMFLMJNE_Last[0].NKMNFPMMJND_ExpiredAt;
					if(KMJCPOGCJDG != 0)
					{
						KMJCPOGCJDG = Utility.RoundDownDayUnixTime(KMJCPOGCJDG, 86399);
					}
					BCEHKBJAEDM NPALHBGHNKN = null;
					BJGEJMNDOLK_GetSubscriptionStatuses COJNCNGHIJC = NKGJPJPHLIF.HHCJCDFCLOB.IBLPICFDGOF_ServerRequester.IFFNCAFNEAG_AddRequest(new BJGEJMNDOLK_GetSubscriptionStatuses());
					COJNCNGHIJC.NBFDEFGFLPJ = AIJFDCIDDLO;
					COJNCNGHIJC.BHFHGFKBOHH_OnSuccess = (CACGCMBKHDI_Request JIPCHHHLOMM) =>
					{
						//0x189C188
						if(COJNCNGHIJC.NFEAMMJIMPG.FCABPFLKKBC.Count < 1)
						{
							JHGKHBGAJJJ = "no data";
							JKKDACNKPCP = "no data";
						}
						else
						{
							TodoLogger.LogError(0, "Todo subscription satus");
						}
						if(NPALHBGHNKN != null && !string.IsNullOrEmpty(NPALHBGHNKN.FJGCDPLCIAK))
						{
							TodoLogger.LogError(0, "Todo subscription satus");
						}
						string str = "";
						if(!JAILOEFCNJP.GEOMLGKCCNI(PJJEOFOFDCO, COJNCNGHIJC.NFEAMMJIMPG.FCABPFLKKBC, EOLFJGMAJAB, out str, out MKBOKLLDCFI))
						{
							TodoLogger.LogError(0, "Todo subscription satus");
						}
						else
						{
							if(str == KHACGAGBDHN)
							{
								HNNAJBJCNEJ = true;
								PJJEOFOFDCO.AFGLHGNKOFC();
							}
							CIOECGOMILE.HHCJCDFCLOB.AIKJMHBDABF_SavePlayerData(() =>
							{
								//0x189D73C
								TodoLogger.LogError(0, "TODO");
								BHFHGFKBOHH();
							}, AOCANKOMKFG, null);
						}
					};
					COJNCNGHIJC.MOBEEPPKFLG_OnFail = (CACGCMBKHDI_Request JIPCHHHLOMM) =>
					{
						//0x189D20C
						TodoLogger.LogError(0, "Onfail");
					};
					return;
				}
			}
		}
		BHFHGFKBOHH();
	}

	// // RVA: 0x1898678 Offset: 0x1898678 VA: 0x1898678
	public bool GBCPDBJEDHL(bool JPIGJNMFDKK = false)
	{
		if(IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.MEGJDBJCEOC_MonthlyPass.AJHBAOCLNDF_MasterSw != 0 &&
			(!JPIGJNMFDKK || KCKKCNPGMDC > CJDLIFEENBF.HHEAABDHNAE/*4*/ || KCKKCNPGMDC == CJDLIFEENBF.GGCDANOKPMB/*2*/))
		{
			long time = NKGJPJPHLIF.HHCJCDFCLOB.IBLPICFDGOF_ServerRequester.FJDBNGEPKHL.KMEFBNBFJHI_GetServerTime();
			if(CIOECGOMILE.HHCJCDFCLOB.LNAHEIEIBOI_Initialized)
			{
				long t = FOHJOELPENH(CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave.HMMNDKHKEBC_MonthlyPass.FMPLMFLMJNE_Last[0].NKMNFPMMJND_ExpiredAt);
				long t2 = CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave.HMMNDKHKEBC_MonthlyPass.FMPLMFLMJNE_Last[0].FDFGEMODIIF_StartedAt;
				return time >= t2 && t >= time;
			}
		}
		return false;
	}

	// // RVA: 0x18989E0 Offset: 0x18989E0 VA: 0x18989E0
	public static long FOHJOELPENH(long OKHMEPIOMBI)
	{ 
		return Utility.RoundDownDayUnixTime(OKHMEPIOMBI, 86399);
	}

	// // RVA: 0x1898A74 Offset: 0x1898A74 VA: 0x1898A74
	// public int JONBGADJPAF() { }

	// // RVA: 0x1898EF0 Offset: 0x1898EF0 VA: 0x1898EF0
	public int MENKMJPCELJ()
	{
		if(IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.MEGJDBJCEOC_MonthlyPass.AJHBAOCLNDF_MasterSw == 0)
			return -2;
		if(KCKKCNPGMDC == CJDLIFEENBF.HHEAABDHNAE/*4*/)
			return -3;
		if(!GBCPDBJEDHL(false))
			return NGHHJMJPEHN() ? 0 : -1;
		long t = Utility.RoundDownDayUnixTime(OLJANLKLOJH(), 86400);
		long time = NKGJPJPHLIF.HHCJCDFCLOB.IBLPICFDGOF_ServerRequester.FJDBNGEPKHL.KMEFBNBFJHI_GetServerTime();
		int diff = (int)(t - time);
		if(diff != 0)
		{
			if((diff + 86399) < 86400)
				return 1;
			return (diff + 86399) % 86400;
		}
		return 1;
	}

	// // RVA: 0x1899158 Offset: 0x1899158 VA: 0x1899158
	public bool NGHHJMJPEHN()
	{
		if(IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.MEGJDBJCEOC_MonthlyPass.ABPFEOBAFCA_PurchaseSw == 0)
			return false;
		return MHKCPJDNJKI.Count > 0;
	}

	// // RVA: 0x1898C9C Offset: 0x1898C9C VA: 0x1898C9C
	public long OLJANLKLOJH()
	{
		long time = NKGJPJPHLIF.HHCJCDFCLOB.IBLPICFDGOF_ServerRequester.FJDBNGEPKHL.KMEFBNBFJHI_GetServerTime();
		long t = FOHJOELPENH(CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave.HMMNDKHKEBC_MonthlyPass.FMPLMFLMJNE_Last[0].NKMNFPMMJND_ExpiredAt);
		if(t < time || time < CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave.HMMNDKHKEBC_MonthlyPass.FMPLMFLMJNE_Last[0].FDFGEMODIIF_StartedAt)
			return 0;
		return t;
	}

	// // RVA: 0x1899284 Offset: 0x1899284 VA: 0x1899284
	// public long CGEEIPGEIDO() { }

	// // RVA: 0x18994E4 Offset: 0x18994E4 VA: 0x18994E4
	// private void MMGBNBPAJAL() { }

	// // RVA: 0x18994E8 Offset: 0x18994E8 VA: 0x18994E8
	// public int BAFEDCMCONG() { }

	// // RVA: 0x18995C4 Offset: 0x18995C4 VA: 0x18995C4
	// public int KPEHCDMGHJC(NHPDPKHMFEP.GGNEBJEIFCP LDKJENNJPFL) { }

	// // RVA: 0x18998DC Offset: 0x18998DC VA: 0x18998DC
	// public string MNAMCPDKFGI(NHPDPKHMFEP.GGNEBJEIFCP LDKJENNJPFL) { }

	// // RVA: 0x18999F8 Offset: 0x18999F8 VA: 0x18999F8
	// public bool GJMGKBDGMOP(IMCBBOAFION BHFHGFKBOHH, DJBHIFLHJLK AOCANKOMKFG) { }

	// // RVA: 0x189A2FC Offset: 0x189A2FC VA: 0x189A2FC
	// public int HGEJHKCHBNB() { }

	// // RVA: 0x189A3D8 Offset: 0x189A3D8 VA: 0x189A3D8
	// public int DKJFDLJCHIM(IMCBBOAFION BHFHGFKBOHH, DJBHIFLHJLK AOCANKOMKFG) { }

	// // RVA: 0x189AC08 Offset: 0x189AC08 VA: 0x189AC08
	public bool KBJJGEJAMOK()
	{
		DMFNALAGLHH = 0;
		int stamp_hosei_ver = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.MEGJDBJCEOC_MonthlyPass.LPJLEHAJADA_GetValue("stamp_hosei_ver", 1);
		if(stamp_hosei_ver != 0)
		{
			CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave.HMMNDKHKEBC_MonthlyPass.MPLPHLAHJOC_StampHosei = stamp_hosei_ver;
			if (CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave.HMMNDKHKEBC_MonthlyPass.HMAHFMHPBBC())
			{
				for(int i = 0; i < 39; i++)
				{
					BEJHIEGCGNE.JCHLONCMPAJ();
					if (CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave.HMMNDKHKEBC_MonthlyPass.BGANHMCJIIC() != null)
					{
						TodoLogger.LogError(0, "KBJJGEJAMOK");
					}
					DMFNALAGLHH++;
					if (!CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave.HMMNDKHKEBC_MonthlyPass.HMAHFMHPBBC())
						break;
				}
				return true;
			}
		}
		return false;
	}

	// // RVA: 0x189B04C Offset: 0x189B04C VA: 0x189B04C
	// public void GBMFNHOFGOP(IMCBBOAFION BHFHGFKBOHH, JFDNPFFOACP NIMPEHIECJH, DJBHIFLHJLK AOCANKOMKFG, NHPDPKHMFEP.GGNEBJEIFCP LDKJENNJPFL) { }

	// // RVA: 0x189B0C8 Offset: 0x189B0C8 VA: 0x189B0C8
	public int PIEFCAPBEAI()
	{
		if(GBCPDBJEDHL(false))
		{
			TodoLogger.LogError(0, "PIEFCAPBEAI");
		}
		return 0;
	}

	// // RVA: 0x189B218 Offset: 0x189B218 VA: 0x189B218
	public int ALNBFHJBGIG()
	{
		if(GBCPDBJEDHL(false))
		{
			if(IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database != null)
			{
				if(GBCPDBJEDHL(false) && HNNAJBJCNEJ)
				{
					return IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.MEGJDBJCEOC_MonthlyPass.LPJLEHAJADA_GetValue("diva_exp_bonus_sp_per", 50);
				}
				else
				{
					return IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.MEGJDBJCEOC_MonthlyPass.LPJLEHAJADA_GetValue("diva_exp_bonus_per", 20);
				}
			}
			return 20;
		}
		return 0;
	}

	// // RVA: 0x189B368 Offset: 0x189B368 VA: 0x189B368
	public bool CJMPCGHCGJB()
	{
		if(NILNABPCKGI())
		{
			return IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database != null;
		}
		return false;
	}

	// // RVA: 0x189B5A0 Offset: 0x189B5A0 VA: 0x189B5A0
	public int ELHKIEBJHLL()
	{
		if(NILNABPCKGI())
		{
			if(IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database != null)
			{
				return IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.MBAGKLJDKMH_LimitedCompoItem.OEJIPANCLOP.ALEDAGOCGGH;
			}
		}
		return 0;
	}

	// // RVA: 0x189B694 Offset: 0x189B694 VA: 0x189B694
	public int EOBEPKGEJFE()
	{
		if(NILNABPCKGI())
		{
			if(IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database != null)
			{
				return IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.MBAGKLJDKMH_LimitedCompoItem.OEJIPANCLOP.EIEOBPKBJDN;
			}
		}
		return 0;
	}

	// // RVA: 0x189B41C Offset: 0x189B41C VA: 0x189B41C
	public bool NILNABPCKGI()
	{
		if(CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave.HMMNDKHKEBC_MonthlyPass != null)
		{
			long time = NKGJPJPHLIF.HHCJCDFCLOB.IBLPICFDGOF_ServerRequester.FJDBNGEPKHL.KMEFBNBFJHI_GetServerTime();
			return time < CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave.HMMNDKHKEBC_MonthlyPass.BKONHFNBHKL_Aextm;
		}
		return false;
	}

	// // RVA: 0x189A23C Offset: 0x189A23C VA: 0x189A23C
	public bool ENAAHAPDMCO()
	{
		return GBCPDBJEDHL(false) && HNNAJBJCNEJ;
	}

	// // RVA: 0x189B788 Offset: 0x189B788 VA: 0x189B788
	// public bool DCDDAAONHHC() { }

	// // RVA: 0x189B798 Offset: 0x189B798 VA: 0x189B798
	// public void JDCDHJPBNIC() { }

	// // RVA: 0x189B8A0 Offset: 0x189B8A0 VA: 0x189B8A0
	public int OEFMFNICHHH()
	{
		if(IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.MEGJDBJCEOC_MonthlyPass.JOCGBFGPBCN_RateUpItemNum < CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave.HMMNDKHKEBC_MonthlyPass.HGEJHKCHBNB())
			return 0;
		return CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave.HMMNDKHKEBC_MonthlyPass.HGEJHKCHBNB();
	}

	// [IteratorStateMachineAttribute] // RVA: 0x6B69B8 Offset: 0x6B69B8 VA: 0x6B69B8
	// // RVA: 0x189A270 Offset: 0x189A270 VA: 0x189A270
	// private IEnumerator BMEPLLIPBBO(DJBHIFLHJLK AOCANKOMKFG) { }

	// // RVA: 0x189BA58 Offset: 0x189BA58 VA: 0x189BA58
	// public void FADCFLIHEPB(IMCBBOAFION BHFHGFKBOHH, JFDNPFFOACP NIMPEHIECJH, JFDNPFFOACP DLBACJNODGA, DJBHIFLHJLK AOCANKOMKFG) { }

	// [IteratorStateMachineAttribute] // RVA: 0x6B6A30 Offset: 0x6B6A30 VA: 0x6B6A30
	// // RVA: 0x189BAC8 Offset: 0x189BAC8 VA: 0x189BAC8
	// private IEnumerator EJODPLCMDOH(IMCBBOAFION BHFHGFKBOHH, JFDNPFFOACP NIMPEHIECJH, JFDNPFFOACP DLBACJNODGA, DJBHIFLHJLK AOCANKOMKFG) { }

	// // RVA: 0x18996D4 Offset: 0x18996D4 VA: 0x18996D4
	// private FHPFLAGNCAF OHEIMMDOHOJ(List<FHPFLAGNCAF> MHKCPJDNJKI, NHPDPKHMFEP.GGNEBJEIFCP LDKJENNJPFL) { }

	// // RVA: 0x189BBE8 Offset: 0x189BBE8 VA: 0x189BBE8
	// public string EAHHCPGNCMF(NHPDPKHMFEP.GGNEBJEIFCP LDKJENNJPFL) { }
}
