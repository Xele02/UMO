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

	// public static int OOLEIEJLHGJ { get; } // KCGOAPBNDPP 0xFB756C
	public static EOHDAOAJOHH HHCJCDFCLOB { get; private set; } // 0x8 LGMPACEDIJF NKACBOEHELJ OKPMHKNCNAL
	public bool BOCLJJMAHHB { get; private set; } // 0xC DMHGANHPELM  BNHJHGPMIBC MOPEPMIODKP
	public bool NCAJHMNKJJD { get; private set; } // 0xD HBEKEPBPKAD MABKOJMFDCI NCMHNDFLDOC
	public bool MOEDFPOIJDM { get; private set; } // 0xE KNECAFLJOBG GNMEIHEKNDI KNFPFPAKEJB

	// // RVA: 0xFB76C4 Offset: 0xFB76C4 VA: 0xFB76C4
	public void IJBGPAENLJA(MonoBehaviour DANMJLOBLIE)
	{
		HHCJCDFCLOB = this;
		BOCLJJMAHHB = false;
		NCAJHMNKJJD = false;
	}

	// // RVA: 0xFB774C Offset: 0xFB774C VA: 0xFB774C
	// public void OJKIKODJJCD() { }

	// // RVA: 0xFB79E8 Offset: 0xFB79E8 VA: 0xFB79E8
	public void FGDBKOCCKOE(bool CKLGHFBPFPJ)
	{
		if(!MOEDFPOIJDM)
		{
			if(!CKLGHFBPFPJ)
			{
				OJIHOFLJOMK.JOAJCEDHKFP();
				if(KGCCNEBMHMM != null)
				{
					KGCCNEBMHMM.JCHLONCMPAJ(1);
					if(KGCCNEBMHMM != null)
						KGCCNEBMHMM.JCHLONCMPAJ(6);
				}
				APNOKHOAMCD();
				DABJPLFAADF();
				return;
			}
			if(GameManager.Instance != null)
			{
				if(GameManager.Instance.localSave.EPJOACOONAC_GetSave().BOJCCICAHJK_Notification.KNOLBNCEHFB_StaminaReceive == 0)
				{
					if(KGCCNEBMHMM != null)
					{
						KGCCNEBMHMM.JCHLONCMPAJ(1);
					}
				}
				else
				{
					APHODAFLJFB();
				}
				if(GameManager.Instance.localSave.EPJOACOONAC_GetSave().BOJCCICAHJK_Notification.HILOMEJEJAM_ApReceive == 0)
				{
					if(KGCCNEBMHMM != null)
					{
						KGCCNEBMHMM.JCHLONCMPAJ(6);
					}
				}
				else
				{
					KIMJDIFEKCE();
				}
				if(GameManager.Instance.localSave.EPJOACOONAC_GetSave().BOJCCICAHJK_Notification.JAFLKPEEGIM_OfferReceive == 0)
				{
					APNOKHOAMCD();
				}
				else
				{
					PAIHLJKFMNL();
				}
				OPODBGPJDCJ();
				PNAOEAFNNFA();
				HGKPAOGOMJJ();
			}
		}
	}

	// // RVA: 0xFBA08C Offset: 0xFBA08C VA: 0xFBA08C
	// public void HJHKBNNEKMI(long KPBJHHHMOJE) { }

	// // RVA: 0xFB7C8C Offset: 0xFB7C8C VA: 0xFB7C8C
	public void APHODAFLJFB()
	{
		if(KGCCNEBMHMM != null)
		{
			if(GameManager.Instance.localSave.EPJOACOONAC_GetSave().BOJCCICAHJK_Notification.KNOLBNCEHFB_StaminaReceive != 0)
			{
				if(CIOECGOMILE.HHCJCDFCLOB != null &&
				CIOECGOMILE.HHCJCDFCLOB.LNAHEIEIBOI_Initialized && 
				CIOECGOMILE.HHCJCDFCLOB.BPLOEAHOPFI_StaminaUpdater != null)
				{
					long t = CIOECGOMILE.HHCJCDFCLOB.BPLOEAHOPFI_StaminaUpdater.LEHHIGOOIJJ();
					if(t != 0)
					{
						long time = Utility.GetCurrentUnixTime();
						if(t - time >= 0)
						{
							bool b = t - time < 5;
							if(b && JPFDCIFKBML(t))
							{
								KGCCNEBMHMM.LKCPCCANJFB(EAPDJLPDHEJ.HHEEFGIDMPC, t, 1, EOHDAOAJOHH.OBAFHIJBOJP[0], EOHDAOAJOHH.OBAFHIJBOJP[2], 102, "png");
							}
						}
					}
				}
			}
		}
	}

	// // RVA: 0xFB7FF0 Offset: 0xFB7FF0 VA: 0xFB7FF0
	public void KIMJDIFEKCE()
	{
		TodoLogger.LogError(0, "KIMJDIFEKCE");
	}

	// // RVA: 0xFB94D0 Offset: 0xFB94D0 VA: 0xFB94D0
	public void HGKPAOGOMJJ()
	{
		TodoLogger.LogError(0, "HGKPAOGOMJJ");
	}

	// // RVA: 0xFB9B8C Offset: 0xFB9B8C VA: 0xFB9B8C
	public void DABJPLFAADF()
	{
		if(KGCCNEBMHMM != null)
		{
			if(IMMAOANGPNK.HHCJCDFCLOB != null)
			{
				if(IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database != null &&
					IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.GDEKCOOBLMA_System != null)
				{
					string s = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.GDEKCOOBLMA_System.EFEGBHACJAL("push_limited_item_send_day", "");
					if(s != "")
					{
						string[] strs = s.Split(new char[]{','});
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
							KGCCNEBMHMM.JCHLONCMPAJ(l[i] + 50000);
							KGCCNEBMHMM.JCHLONCMPAJ(l[i] + 60000);
							KGCCNEBMHMM.JCHLONCMPAJ(l[i] + 80000);
							KGCCNEBMHMM.JCHLONCMPAJ(l[i] + 70000);
							KGCCNEBMHMM.JCHLONCMPAJ(l[i] + 90000);
							GIJMLPJPFHB(IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database, l[i]);
						}
					}
				}
			}
		}
	}

	// // RVA: 0xFBC2B8 Offset: 0xFBC2B8 VA: 0xFBC2B8
	public void GIJMLPJPFHB(OKGLGHCBCJP_Database LKMHPJKIFDN, int IOBIPABJHEG)
	{
		int a = IOBIPABJHEG + 100000;
		for(int i = 0; i < LKMHPJKIFDN.GKMAHADAAFI_GachaTicket.DHIACJMOEBH.Count; i++)
		{
			KGCCNEBMHMM.JCHLONCMPAJ(a);
			a += 100;
		}
	}

	// // RVA: 0xFBA4A0 Offset: 0xFBA4A0 VA: 0xFBA4A0
	// public void PDAHBODAGFO(OKGLGHCBCJP LKMHPJKIFDN, BBHNACPENDM LDEGEHAEALK, List<int> JKFIHOHONHD, long JHNMKKNEENE, string GBBMOEGDGEM, string DPOGLCNOBCI, bool OPEBKHLLMPH = False) { }

	// // RVA: 0xFBA830 Offset: 0xFBA830 VA: 0xFBA830
	// public void MGEKDBAHOBM(OKGLGHCBCJP LKMHPJKIFDN, BBHNACPENDM LDEGEHAEALK, List<int> JKFIHOHONHD, long JHNMKKNEENE, string GBBMOEGDGEM, string DPOGLCNOBCI, bool OPEBKHLLMPH = False) { }

	// // RVA: 0xFBAEA0 Offset: 0xFBAEA0 VA: 0xFBAEA0
	// public void CJJJNACJGAG(OKGLGHCBCJP LKMHPJKIFDN, BBHNACPENDM LDEGEHAEALK, List<int> JKFIHOHONHD, long JHNMKKNEENE, string GBBMOEGDGEM, string DPOGLCNOBCI, bool OPEBKHLLMPH = False) { }

	// // RVA: 0xFBB524 Offset: 0xFBB524 VA: 0xFBB524
	// public void CFOKLGOIDAL(OKGLGHCBCJP LKMHPJKIFDN, BBHNACPENDM LDEGEHAEALK, List<int> JKFIHOHONHD, long JHNMKKNEENE, string GBBMOEGDGEM, string DPOGLCNOBCI, bool OPEBKHLLMPH = False) { }

	// // RVA: 0xFBB86C Offset: 0xFBB86C VA: 0xFBB86C
	// public void PBCMCHIPKID(OKGLGHCBCJP LKMHPJKIFDN, BBHNACPENDM LDEGEHAEALK, List<int> JKFIHOHONHD, long JHNMKKNEENE, string GBBMOEGDGEM, string DPOGLCNOBCI, bool OPEBKHLLMPH = False) { }

	// // RVA: 0xFBBCD4 Offset: 0xFBBCD4 VA: 0xFBBCD4
	// public void GONPMCPCJKE(OKGLGHCBCJP LKMHPJKIFDN, BBHNACPENDM LDEGEHAEALK, List<int> JKFIHOHONHD, long JHNMKKNEENE, string GBBMOEGDGEM, string DPOGLCNOBCI, bool OPEBKHLLMPH = False) { }

	// // RVA: 0xFBC3AC Offset: 0xFBC3AC VA: 0xFBC3AC
	// public long LHGGKIELMAA(long KFDHHOFENEN, int EJJDPAHKALO) { }

	// // RVA: 0xFB88AC Offset: 0xFB88AC VA: 0xFB88AC
	public void OPODBGPJDCJ()
    {
		if(!AppEnv.IsCBT() && KGCCNEBMHMM != null)
		{
			TodoLogger.LogError(0, "OPODBGPJDCJ");
		}
    }

	// // RVA: 0xFB8EF0 Offset: 0xFB8EF0 VA: 0xFB8EF0
	public void PNAOEAFNNFA()
	{
		TodoLogger.LogError(0, "PNAOEAFNNFA");
	}

	// // RVA: 0xFBC4E8 Offset: 0xFBC4E8 VA: 0xFBC4E8
	public bool HKMEADILMGB(long PEJIPAFKHKM, int LJNAKDMILMC, string LJGOOOMOMMA, int EAHPLCJMPHD)
	{
		TodoLogger.LogError(0, "HKMEADILMGB");
		return false;
	}

	// // RVA: 0xFBC6DC Offset: 0xFBC6DC VA: 0xFBC6DC
	// public bool COGJLOMPOKK(int HMFFHLPNMPH, int ABILEHIAMOO) { }

	// // RVA: 0xFBCB30 Offset: 0xFBCB30 VA: 0xFBCB30
	// public void JOADGPOBFMC() { }

	// // RVA: 0xFBCB48 Offset: 0xFBCB48 VA: 0xFBCB48
	public void NNGHCGKIIHM(bool DDGFCOPPBBN = false)
	{
		if(KGCCNEBMHMM != null)
		{
			if(GameManager.Instance.localSave.EPJOACOONAC_GetSave().BOJCCICAHJK_Notification.ILNIHDCCOEO_EventReceive != 0)
			{
				if(CIOECGOMILE.HHCJCDFCLOB.LNAHEIEIBOI_Initialized)
				{
					long time;
					if (DDGFCOPPBBN)
					{
						time = NKGJPJPHLIF.HHCJCDFCLOB.IBLPICFDGOF_ServerRequester.FJDBNGEPKHL.KMEFBNBFJHI_GetServerTime();
					}
					else
					{
						if (CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave.KCCLEHLLOFG_Common.MNLAJEDKLCI_StamineLotTime == 0)
							return;
						time = CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave.KCCLEHLLOFG_Common.MNLAJEDKLCI_StamineLotTime;
					}
					int debut_push_time_offset = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.GDEKCOOBLMA_System.LPJLEHAJADA("debut_push_time_offset", 60);
					DateTime date = Utility.GetLocalDateTime(time);
					long time2 = Utility.GetTargetUnixTime(date.Year, date.Month, date.Day, 0, 0, 0);
					time2 += debut_push_time_offset * 3600;
					long time3 = Utility.GetCurrentUnixTime();
					if(time2 >= time3 && JPFDCIFKBML(time2))
					{
						int idx = EJHPIMANJFP.HHCJCDFCLOB.MHKCPJDNJKI.FindIndex((LGDNAJACFHI GHPLINIACBB) =>
						{
							//0xFBDD4C
							return GHPLINIACBB.JLGHMCBLENL;
						});
						if(idx < 0 && DDGFCOPPBBN)
						{
							MessageBank bk = MessageManager.Instance.GetBank("menu");
							string str = bk.GetMessageByLabel("push_notify_debut_vc_title");
							string str2 = bk.GetMessageByLabel("push_notify_debut_vc_msg_01");
							if (str.Contains("!not exist"))
								str = JpStringLiterals.StringLiteral_10303;
							if (str2.Contains("!not exist"))
								str2 = JpStringLiterals.StringLiteral_10304;
							Debug.Log("SendDebutSetMessage targetUnixTime=" + time2);
							KGCCNEBMHMM.LKCPCCANJFB(EAPDJLPDHEJ.KOGBMDOONFA, time2, 4, str, str2, 103, "png");
						}
					}
				}
			}
		}
	}

	// // RVA: 0xFBD33C Offset: 0xFBD33C VA: 0xFBD33C
	public void KCKLPAEILNH()
	{
		if (KGCCNEBMHMM == null)
			return;
		KGCCNEBMHMM.JCHLONCMPAJ(4);
	}

	// // RVA: 0xFB8374 Offset: 0xFB8374 VA: 0xFB8374
	public void PAIHLJKFMNL()
	{
		TodoLogger.LogError(0, "PAIHLJKFMNL");
	}

	// // RVA: 0xFB8838 Offset: 0xFB8838 VA: 0xFB8838
	public void APNOKHOAMCD()
	{
		if(KGCCNEBMHMM != null && KDHGBOOECKC.HHCJCDFCLOB != null)
		{
			int a = KDHGBOOECKC.HHCJCDFCLOB.JGFHJPGJJHP();
			if(a < 1)
				return;
			int c = 30000;
			do
			{
				KGCCNEBMHMM.JCHLONCMPAJ(c);
				a--;
				c++;
			} while(a != 0);
		}
	}

	// // RVA: 0xFBD35C Offset: 0xFBD35C VA: 0xFBD35C
	// public void GCKBFMOMFCG(NDBFKHKMMCE.ANMODBDBNPK.BIKFCCKCHHC NKCAKHIJEHF, long PEJIPAFKHKM, string ADCMNODJBGJ, string LJGOOOMOMMA, int EAHPLCJMPHD) { }

	// // RVA: 0xFBD53C Offset: 0xFBD53C VA: 0xFBD53C
	public void NINPDKEKNEG()
	{
		if (KGCCNEBMHMM == null)
			return;
		for(int i = 0; i < 2; i++)
		{
			if (KGCCNEBMHMM != null)
				KGCCNEBMHMM.JCHLONCMPAJ(i + 0x9c41);
		}
	}

	// // RVA: 0xFBD588 Offset: 0xFBD588 VA: 0xFBD588
	// public void NINPDKEKNEG(NDBFKHKMMCE.ANMODBDBNPK.BIKFCCKCHHC NKCAKHIJEHF) { }

	// // RVA: 0xFBD5A4 Offset: 0xFBD5A4 VA: 0xFBD5A4
	// public bool HJHKBNNEKMI(long PEJIPAFKHKM, int LJNAKDMILMC, string LJGOOOMOMMA, int EAHPLCJMPHD) { }

	// // RVA: 0xFB79B8 Offset: 0xFB79B8 VA: 0xFB79B8
	// public void FOPAJBDEFCP() { }

	// // RVA: 0xFB79D0 Offset: 0xFB79D0 VA: 0xFB79D0
	// public void PELOGBHNHIL() { }

	// // RVA: 0xFBC4B8 Offset: 0xFBC4B8 VA: 0xFBC4B8
	// public void HBLOOGBLKKD() { }

	// // RVA: 0xFBC4D0 Offset: 0xFBC4D0 VA: 0xFBC4D0
	// public void OJCABHGPCPK() { }

	// // RVA: 0xFB78F4 Offset: 0xFB78F4 VA: 0xFB78F4
	// public bool BBDNBCHOFIP() { }

	// // RVA: 0xFBD734 Offset: 0xFBD734 VA: 0xFBD734
	// public void LCICDJDNPNA() { }

	// // RVA: 0xFBD7F0 Offset: 0xFBD7F0 VA: 0xFBD7F0
	// public void BJOFINDMDJH() { }

	// // RVA: 0xFBD9F8 Offset: 0xFBD9F8 VA: 0xFBD9F8
	// public void HHEDACCFPGM() { }

	// // RVA: 0xFBA2B8 Offset: 0xFBA2B8 VA: 0xFBA2B8
	public bool JPFDCIFKBML(long EOLFJGMAJAB)
	{
		DateTime date = Utility.GetLocalDateTime(EOLFJGMAJAB);
		return GameManager.Instance.localSave.EPJOACOONAC_GetSave().BOJCCICAHJK_Notification.OCKFGNLLBFA(AKCBIJHIOGH[date.Hour]);
	}

	// // RVA: 0xFBDA10 Offset: 0xFBDA10 VA: 0xFBDA10
	// public void KOFIBEMHONI() { }
}
