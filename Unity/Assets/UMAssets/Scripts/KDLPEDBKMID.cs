using System;
using UnityEngine;
using System.Text;
using System.Collections.Generic;
using System.IO;
using System.Collections;
using XeSys.File;
using XeApp.Game;

public delegate bool OMIFMMJPMDJ(int INDDJNMPONH, float LNAHJANMJNM);
public delegate void OBHIGCFPKJN(string DOGDHKIEBJA, IMCBBOAFION KLMFJJCNBIP, JFDNPFFOACP NEFKBBNKNPP);

public class KDLPEDBKMID
{
    public class EMEKAOMPFNC
    {
        public string CJEKGLGBIHF; // 0x8
        public string BLHCFFOHBNF; // 0xC
        public string NOCCPNGFFPF; // 0x10
        public int LGADCGFMLLD; // 0x14
    }

    public enum PHKOILLPHGG
    {
        LACMMENCAIF = 0,
        HGACHBEOOHD = 1,
        ODFDIFNIFPC = 2,
    }

	private StringBuilder JBBHNIACMFJ = new StringBuilder(256); // 0x8
	private List<KDLPEDBKMID.EMEKAOMPFNC> JFEKDMEMKHE = new List<KDLPEDBKMID.EMEKAOMPFNC>(30); // 0xC
	public DJBHIFLHJLK FGGJNGCAFGK; // 0x18
	private Action LCIGLIDJILJ; // 0x1C
	private bool KOIGPANFBKP; // 0x20
	private bool LFPOPKJMGKA; // 0x21
	public float HANBBBBLLGP; // 0x24
	private bool PICLIFPDEOF; // 0x28
	private JEHIAIPJNJF PMDNNKAPIKJ; // 0x2C
	private float FGCMHIPPDFL; // 0x34
	private float LPHLENALMBE = 1.0f; // 0x38
	private WaitForEndOfFrame CGHFIPJFFKD = new WaitForEndOfFrame(); // 0x3C
	private static readonly string[] NFKOAFFBHOL = new string[13] {"snd/bgm/cs_bgm_tutorial.acb", 
																	"snd/bgm/cs_bgm_tutorial.awb",
																	"ct/dv/me/01/01_01.xab",
																	"ct/dv/me/01/02_01.xab",
																	"ct/dv/me/01/03_01.xab",
																	"ct/dv/me/01/04_01.xab",
																	"ct/dv/me/01/05_01.xab",
																	"ct/dv/me/01/06_01.xab",
																	"ct/dv/me/01/07_01.xab",
																	"ct/dv/me/01/10_01.xab",
																	"ly/083.xab",
																	"handmade/shader.xab",
																	"handmade/cmnparam.xab"}; // 0x4
	private static readonly string[] FJFFOIHEDID = new string[6] {"mc/{0}/bt001.xab",
																	"mc/{0}/ft.xab",
																	"mc/{0}/sc.xab",
																	"sc/{0:D4}.dat",
																	"snd/bgm/cs_w_{0:D4}.acb",
																	"snd/bgm/cs_w_{0:D4}.awb"}; // 0x8
	private static readonly string[] KJAAFBDBDOM = new string[6] {"mc/{0}/bt001.xab",
																	"mc/{0}/ft.xab",
																	"mc/{0}/sc.xab",
																	"sc/{0:D4}.dat",
																	"snd/bgm/cs_w_{0:D4}.acb",
																	"snd/bgm/cs_w_{0:D4}_d.awb"}; // 0xC
	private static readonly string MFDEFIILPGM = "st/{0:D4}.xab"; // 0x10
	private static readonly string JOLFLDNELHO = "mov/gm/dv/game_dv_{0:D4}_mv_{1}q{2:D1}.usm"; // 0x14
	private static readonly string NMFLPJMFPFN = "mc/{0}/bt002.xab"; // 0x18
	private static readonly string EMLADNPGDOG = "mov/gm/dv/game_dv_{0:D4}_mv_{1}q{2:D1}.usm"; // 0x1C
	private static readonly string[] ABNBIJGFNBA = new string[6] {"mc/{0}/dr/cc/{1:D3}.xab",
																	"mc/{0}/dr/dc/{1:D3}.xab",
																	"mc/{0}/dr/dv/{1:D3}.xab",
																	"mc/{0}/dr/li/{1:D3}.xab",
																	"mc/{0}/dr/st/{1:D3}.xab",
																	"mc/{0}/dr/sc/{1:D3}.xab"}; // 0x20
	private static readonly string[] MOMNOGAGKHP = new string[2] {"snd/vo/diva/cs_diva_{0:D3}.acb", "snd/vo/diva/cs_diva_{0:D3}.awb"}; // 0x24
	private static readonly string[] BPKOEOEOBLD = new string[3] {"dv/cs/{0:D3}_{1:D3}.xab", "dv/bs/{0:D3}_{1:D3}.xab", "ct/dv/ps/{0:D2}_{1:D2}.xab"}; // 0x28
	private static readonly string[] EALKAGJANPD = new string[3] {"ct/dv/me/01/{0:D2}_{1:D2}.xab", "ct/dv/me/02/{0:D2}_{1:D2}.xab", "ct/dv/me/03/{0:D2}_{1:D2}.xab"}; // 0x2C
	private static readonly string[] ILINMFJBKAL = new string[3] {"vl/{0:D4}.xab", "ct/vl/01/{0:D2}_01.xab", "ct/vl/02/{0:D2}_01.xab"}; // 0x30
	private static readonly string[] KPBAICAFLPC = new string[3] {"snd/vo/pilot/cs_pilot_{0:D3}.acb", "snd/vo/pilot/cs_pilot_{0:D3}.awb", "ct/pl/{0:D3}.xab"}; // 0x34

	public static KDLPEDBKMID HHCJCDFCLOB { get; private set; } // 0x0 LGMPACEDIJF NKACBOEHELJ OKPMHKNCNAL
	public OMIFMMJPMDJ OEPPEGHGNNO { get; set; } // 0x10 KPEKONPJHCL LKCDOGAFPNM NPJJMDFAIII
	public OBHIGCFPKJN MAIHLKPEHJN { get; set; } // 0x14 EAIFOAGPGGH KCLBNOKEPIG OCIMGEFKKLM
	public bool LNHFLJBGGJB { 
		get { // KOIPHFOBLOD 0xE7D688
			if(KOIGPANFBKP)
				return true;
			return JFEKDMEMKHE.Count > 0;
		} 
	}
	public KDLPEDBKMID.PHKOILLPHGG CNDDKMJAIBG { get; set; } // 0x30 HMCLOEGDNBA HIGNHAEJKAH DFJLAMPMCMP

	// // RVA: 0xE7D730 Offset: 0xE7D730 VA: 0xE7D730
	public void OIKLOJMPBGA(int COGJONKKALB)
	{
		UnityEngine.Debug.LogError("TODO");
	}

	// // RVA: 0xE7D768 Offset: 0xE7D768 VA: 0xE7D768
	public void IJBGPAENLJA_OnAwake(MonoBehaviour DANMJLOBLIE)
	{
		HHCJCDFCLOB = this;
		LCIGLIDJILJ = this.LFKLIOKFGLP;
		CriFileRequestManager.HHCJCDFCLOB.GOEAHKDGBBH = () => {
			//0xE841D8
			return LNHFLJBGGJB;
		};
		CriFileRequestManager.HHCJCDFCLOB.JPNMBNEHBOC = this.BDOFDNICMLC;
	}

	// // RVA: 0xE7D90C Offset: 0xE7D90C VA: 0xE7D90C
	public void FFBCKMFKFME()
    {
        UnityEngine.Debug.LogError("TODO");
    }

	// // RVA: 0xE7D990 Offset: 0xE7D990 VA: 0xE7D990
	public void OFLDICKPNFD(bool CJPFICKPJPP, DJBHIFLHJLK FGGJNGCAFGK)
    {
        if(CJPFICKPJPP)
		{
			MAIHLKPEHJN = JHHBAFKMBDL.HHCJCDFCLOB.DOHNKJKOGFJ;
		}
		else
		{
			MAIHLKPEHJN = this.EEHMGCMAOAB;
		}
		this.FGGJNGCAFGK = FGGJNGCAFGK;
    }

	// // RVA: 0xE7DA9C Offset: 0xE7DA9C VA: 0xE7DA9C
	public void BAGMHFKPFIF()
    {
        LCIGLIDJILJ();
    }

	// // RVA: 0xE7DAC8 Offset: 0xE7DAC8 VA: 0xE7DAC8
	private void LFKLIOKFGLP()
	{
		if(JFEKDMEMKHE.Count > 0)
		{
			if(KEHOJEJMGLJ.JNGKCPJBMBA != null && CNDDKMJAIBG != KDLPEDBKMID.PHKOILLPHGG.HGACHBEOOHD/*1*/)
			{
				if(CNDDKMJAIBG != KDLPEDBKMID.PHKOILLPHGG.ODFDIFNIFPC/*2*/)
				{
					if(Time.realtimeSinceStartup - FGCMHIPPDFL < LPHLENALMBE)
						return;
				}
				LFPOPKJMGKA = true;
				N.a.StartCoroutine(EOFJPNPFGDM_Coroutine_Install());
				LCIGLIDJILJ = this.OCGLHHHMILH;
			}
		}
	}

	// // RVA: 0xE7DD48 Offset: 0xE7DD48 VA: 0xE7DD48
	private void OCGLHHHMILH()
	{
		if(LFPOPKJMGKA)
			return;
		LCIGLIDJILJ = this.LFKLIOKFGLP;
	}

	// // RVA: 0xE7DDDC Offset: 0xE7DDDC VA: 0xE7DDDC
	public static bool ENEFCDLNAEF(string KEIGHMAKAAC)
	{
		string path = "";
		if(KEIGHMAKAAC[0] == '/')
		{
			path = KEHOJEJMGLJ.CGAHFOBGHIM + KEIGHMAKAAC;
		}
		else
		{
			path = KEHOJEJMGLJ.CGAHFOBGHIM + AFEHLCGHAEE.FAIOPNOJIBF + KEIGHMAKAAC;
		}
		return File.Exists(path);
	}

	// // RVA: 0xE7E040 Offset: 0xE7E040 VA: 0xE7E040
	public bool BDOFDNICMLC(string KEIGHMAKAAC)
	{
		if(!ENEFCDLNAEF(KEIGHMAKAAC))
		{
			string str = KPIAEBMBBPE(KEIGHMAKAAC);
			for(int i = 0; i < JFEKDMEMKHE.Count; i++)
			{
				if(JFEKDMEMKHE[i].CJEKGLGBIHF == str)
					return false;
				
				if(PMDNNKAPIKJ != null)
				{
					if(PMDNNKAPIKJ.MNAIIMMIMIO(str))
						return false;
					EMEKAOMPFNC d = new EMEKAOMPFNC();
					d.CJEKGLGBIHF = str;
					d.BLHCFFOHBNF = FAKFFDIFAAH(str);
					d.NOCCPNGFFPF = FLBHKPMIJHP(str);
					JFEKDMEMKHE.Add(d);
					FGCMHIPPDFL = Time.realtimeSinceStartup;
					return true;
				}
			}
		}
		return false;
	}

	// // RVA: 0xE7E294 Offset: 0xE7E294 VA: 0xE7E294
	private string KPIAEBMBBPE(string KEIGHMAKAAC) // Platform path
	{
		JBBHNIACMFJ.Clear();
		JBBHNIACMFJ.Append(AFEHLCGHAEE.FAIOPNOJIBF);
		JBBHNIACMFJ.Append(KEHOJEJMGLJ.LBEPLOJBFCM);
		if(KEIGHMAKAAC[0] != '/')
		{
			JBBHNIACMFJ.Append(AFEHLCGHAEE.FAIOPNOJIBF);
		}
		JBBHNIACMFJ.Append(KEIGHMAKAAC);
		return JBBHNIACMFJ.ToString();
	}

	// // RVA: 0xE7E4A8 Offset: 0xE7E4A8 VA: 0xE7E4A8
	private string FAKFFDIFAAH(string CJEKGLGBIHF) // Download Path
	{
		string dir = Path.GetDirectoryName(CJEKGLGBIHF);
		dir = dir.Replace('\\','/');
		string fileName = Path.GetFileNameWithoutExtension(CJEKGLGBIHF);
		string ext = Path.GetExtension(CJEKGLGBIHF);
		
		uint val = BEEINMBNKNM_Encryption.DIKDKNIKPNJ((uint)IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND.GDEKCOOBLMA.NGHKJOEDLIP.KBNGOBEAHIC, CJEKGLGBIHF);
		JBBHNIACMFJ.Clear();
		JBBHNIACMFJ.Append(KEHOJEJMGLJ.FLHOFIEOKDH);
		JBBHNIACMFJ.Append(dir);
		JBBHNIACMFJ.Append(AFEHLCGHAEE.FAIOPNOJIBF);
		JBBHNIACMFJ.Append(fileName);
		JBBHNIACMFJ.Append("!s");
		JBBHNIACMFJ.AppendFormat("{0:x8}", val);
		JBBHNIACMFJ.Append("z!");
		JBBHNIACMFJ.Append(ext);
		return JBBHNIACMFJ.ToString();
	}

	// // RVA: 0xE7E870 Offset: 0xE7E870 VA: 0xE7E870
	private string FLBHKPMIJHP(string CJEKGLGBIHF) // Install Path
	{
		JBBHNIACMFJ.Clear();
		JBBHNIACMFJ.Append(KEHOJEJMGLJ.OGCDNCDMLCA);
		JBBHNIACMFJ.Append(CJEKGLGBIHF);
		return JBBHNIACMFJ.ToString();
	}

	// [IteratorStateMachineAttribute] // RVA: 0x6BB384 Offset: 0x6BB384 VA: 0x6BB384
	// // RVA: 0xE7DCBC Offset: 0xE7DCBC VA: 0xE7DCBC
	private IEnumerator EOFJPNPFGDM_Coroutine_Install()
	{
        UnityEngine.Debug.Log("Enter EOFJPNPFGDM_Coroutine_Install");
		// private KDLPEDBKMID.<>c__DisplayClass44_0 OPLBFCEPDCH; // 0x14			
			// public KDLPEDBKMID KIGBLACMODG; // 0x8
			// public PJKLMCGEJMK CPHFEPHDJIB; // 0xC
			// RVA: 0xE84268 Offset: 0xE84268 VA: 0xE84268
			// internal void EGDGJOPDNFF(JEHIAIPJNJF.HCJPJKCIBDL JGBPLIGAILE) { }
		// private KDLPEDBKMID.<>c__DisplayClass44_1 LBLMCMHMNGC; // 0x18
			// public int APGOAMNGFFF; // 0x8
			// RVA: 0xE849D8 Offset: 0xE849D8 VA: 0xE849D8
			//internal void FKJIINPOGKK() { }
			// RVA: 0xE849E4 Offset: 0xE849E4 VA: 0xE849E4
			//internal void BCMEPPIPGIB() { }
		// private KDLPEDBKMID.<>c__DisplayClass44_2 PHPPCOBECCA; // 0x1C
			//public int APGOAMNGFFF; // 0x8
			// RVA: 0xE849F8 Offset: 0xE849F8 VA: 0xE849F8
			//internal void EKHEBHFBKID() { }
			// RVA: 0xE84A04 Offset: 0xE84A04 VA: 0xE84A04
			//internal void OIIFKBGOJKO() { }
		// 0xE84A14
		int APGOAMNGFFF = 0;
		if(OEPPEGHGNNO == null)
		{
			OEPPEGHGNNO = (int INDDJNMPONH, float LNAHJANMJNM) => 
			{
				//0xE84258
				return true;
			};
		}
		if(MAIHLKPEHJN == null)
		{
			MAIHLKPEHJN = this.EEHMGCMAOAB;
		}
		GameManager.Instance.SetNeverSleep(true);
		OEPPEGHGNNO(1, 0.0f);
		while(!OEPPEGHGNNO(4, 0.0f))
		{
			yield return null;
		}
		PJKLMCGEJMK CPHFEPHDJIB = NKGJPJPHLIF.HHCJCDFCLOB.IBLPICFDGOF;
		KOIGPANFBKP = true;
		HANBBBBLLGP = 0.0f;
		//LAB_00e84df8:
		while(true)
		{
			if(JFEKDMEMKHE.Count == 0)
			{
				KOIGPANFBKP = false;
				KEHOJEJMGLJ.HHCJCDFCLOB.KLIJFOBEKBE.HJMKBCFJOOH();
				OEPPEGHGNNO(2, 100);
				GameManager.Instance.SetNeverSleep(false);
				LFPOPKJMGKA = false;
        		UnityEngine.Debug.LogError("Exit EOFJPNPFGDM_Coroutine_Install");
				yield break;
			}
			PMDNNKAPIKJ = new JEHIAIPJNJF(3);
			PMDNNKAPIKJ.DOMFHDPMCCO(JFEKDMEMKHE);
			JFEKDMEMKHE.Clear();
			PMDNNKAPIKJ.LBGNKOJFOFC = (JEHIAIPJNJF.HCJPJKCIBDL JGBPLIGAILE) => {
				//0xE84268
				GCGNICILKLD fileinfo = DHBFAKEGDOG(JGBPLIGAILE.AJPIGKBIDDL);
				if(fileinfo != null)
				{
					KEHOJEJMGLJ.GFOMKMANCPP(JGBPLIGAILE.ADHHKEMDOIK, fileinfo.CALJIGKCAAH, fileinfo.HHPEMFKDHLK, true);
					KEHOJEJMGLJ.HHCJCDFCLOB.KLIJFOBEKBE.OJCJPCHFPGO(JGBPLIGAILE.AJPIGKBIDDL);
					PKKHIEAEDPC a = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND.IELDDHJMFKN.NBHDIKJMLEN(JGBPLIGAILE.AJPIGKBIDDL);
					if(a != null)
					{
						if(a.NKGJOAEDCPH.PAAPNEMBHGN > 0)
						{
							FECDBKKBAHO.FHOPNIJCFKA b = KEHOJEJMGLJ.HHCJCDFCLOB.KLIJFOBEKBE.ANIJHEBLMGB(JGBPLIGAILE.AJPIGKBIDDL, CPHFEPHDJIB.FJDBNGEPKHL.KMEFBNBFJHI(), a.KKPAHLMJKIH);
							b.FNALNKKMKDC = CPHFEPHDJIB.FJDBNGEPKHL.KMEFBNBFJHI() + a.NKGJOAEDCPH.PAAPNEMBHGN * 0x15180;
							b.GEJJEDDEPMI = a.NKGJOAEDCPH.PEOIMDCECDL;
						}
					}
				}
			};
			//LAB_00e85548:
			PMDNNKAPIKJ.LAOEGNLOJHC();
			while(true)
			{
				yield return null;
				//2
				PMDNNKAPIKJ.FBANBDCOEJL();
				if(PMDNNKAPIKJ.CMCKNKKCNDK == /*2*/JEHIAIPJNJF.NKLKJEOKIFO.FEJIMBDPMKI)
				{
					HANBBBBLLGP = 100.0f;
					OEPPEGHGNNO(3, 100);
					PMDNNKAPIKJ.Dispose();
					PMDNNKAPIKJ = null;
					// goto LAB_00e84df8
					break;
				}
				else
				{
					if(PMDNNKAPIKJ.CMCKNKKCNDK == /*4*/JEHIAIPJNJF.NKLKJEOKIFO.LPLEIJIFOKN)
					{
						string errorStr = "network";
						if(PMDNNKAPIKJ.BHICPONFJKM)
							errorStr = "storage";
						if(StorageSupport.GetAvailableStorageSizeMB() > -1 && StorageSupport.GetAvailableStorageSizeMB() < 50)
							errorStr = "storage";
						APGOAMNGFFF = 0;
						MAIHLKPEHJN(errorStr, () => {
							//0xE849D8
							APGOAMNGFFF = 1;
						}, () => {
							//0xE849E4
							APGOAMNGFFF = -1;
						});
						//goto LAB_00e84f0c; // To 3
						//3
						//LAB_00e84f0c
						while(APGOAMNGFFF == 0)
						{
							yield return null;
						}
						// L 267
						PMDNNKAPIKJ.PBIMGBKLDPP();
						if(APGOAMNGFFF != 1)
						{
							//goto LAB_00e85514;
							KOIGPANFBKP = false;
							UnityEngine.Debug.Log("Exit Error EOFJPNPFGDM_Coroutine_Install");
							yield break;
						}
						//goto LAB_00e84f9c;
						//4
						//LAB_00e84f9c;
						while(PMDNNKAPIKJ.CMCKNKKCNDK != 0)
						{
							yield return null;
						}
						//goto LAB_00e85548;
						continue;
					}
					HANBBBBLLGP = PMDNNKAPIKJ.HCAJCKCOCHC();
					OEPPEGHGNNO(3, PMDNNKAPIKJ.HCAJCKCOCHC());
					if(PMDNNKAPIKJ.MNFGKBAEFFL() || PMDNNKAPIKJ.KAMPHNKAHAB)
					{
						//LAB_00e85288:
						PMDNNKAPIKJ.PBIMGBKLDPP();
						//goto LAB_00e852c8;
						// To 5
						//5
						while(PMDNNKAPIKJ.CMCKNKKCNDK != 0)
						{
							yield return null;
						}
						APGOAMNGFFF = 0;
						string errorStr = "network";
						if(!PMDNNKAPIKJ.KAMPHNKAHAB)
							errorStr = "storage";
						int avaiableSpace = StorageSupport.GetAvailableStorageSizeMB();
						if(avaiableSpace >= 0 && avaiableSpace < 50)
							errorStr = "storage";
						
						MAIHLKPEHJN(errorStr, () => {
							//0xE849F8
							APGOAMNGFFF = 1;
						}, () => {
							//0xE84A04
							APGOAMNGFFF = -1;
						});
						//goto LAB_00e85468;
						//6
						while(APGOAMNGFFF == 0)
							yield return null;
						PMDNNKAPIKJ.PBIMGBKLDPP();
						if(APGOAMNGFFF != 1)
						{
							//LAB_00e85514:
							KOIGPANFBKP = false;
							UnityEngine.Debug.Log("Exit Error EOFJPNPFGDM_Coroutine_Install");
							yield break;
						}
						while(PMDNNKAPIKJ.CMCKNKKCNDK != 0)
						{
							PMDNNKAPIKJ.FBANBDCOEJL();
							yield return null;
							// goto 7
							//7
							//goto LAB_00e854dc;
						}
						//goto LAB_00e85548;
						PMDNNKAPIKJ.LAOEGNLOJHC();
						continue;
					}
					else
					{
						//goto LAB_00e85550;
						// to 2
						continue;
					}
				}
			}
		}
		
    	UnityEngine.Debug.Log("Exit EOFJPNPFGDM_Coroutine_Install");
	}

	// // RVA: 0xE7ECF4 Offset: 0xE7ECF4 VA: 0xE7ECF4
	private GCGNICILKLD DHBFAKEGDOG(string CJEKGLGBIHF)
	{
		for(int i = 0; i < KEHOJEJMGLJ.HHCJCDFCLOB.IDJBKGBMDAJ.KGHAJGGMPKL.Count; i++)
		{
			if(KEHOJEJMGLJ.HHCJCDFCLOB.IDJBKGBMDAJ.KGHAJGGMPKL[i].OIEAICNAMNB == CJEKGLGBIHF)
				return KEHOJEJMGLJ.HHCJCDFCLOB.IDJBKGBMDAJ.KGHAJGGMPKL[i];
		}
		return null;
	}

	// // RVA: 0xE7EEF8 Offset: 0xE7EEF8 VA: 0xE7EEF8
	// public bool EGIFDIFALKK(string KEIGHMAKAAC) { }

	// // RVA: 0xE7EF18 Offset: 0xE7EF18 VA: 0xE7EF18
	private void EEHMGCMAOAB(string DOGDHKIEBJA, IMCBBOAFION KLMFJJCNBIP, JFDNPFFOACP NEFKBBNKNPP)
	{
		UnityEngine.Debug.LogError("TODO");
	}

	// // RVA: 0xE7EF44 Offset: 0xE7EF44 VA: 0xE7EF44
	// public bool HFMOAJDHDHJ(int GHBPLHBNMBK) { }

	// // RVA: 0xE7F26C Offset: 0xE7F26C VA: 0xE7F26C
	// private static string[] JAAOIKIALFJ(int ECOIBKOIPFP) { }

	// // RVA: 0xE7F44C Offset: 0xE7F44C VA: 0xE7F44C
	// public bool OKJCGCOGDIA(int ECOIBKOIPFP, int DNHLEPCFPFC, int MOBOJNCPCGD, int HADONLEBKLD) { }

	// // RVA: 0xE7F898 Offset: 0xE7F898 VA: 0xE7F898
	// public void LIDGJKCOGFA(int ECOIBKOIPFP, int DNHLEPCFPFC, int MOBOJNCPCGD, List<string> NNDGIAEFMOG, int HADONLEBKLD) { }

	// // RVA: 0xE7FD38 Offset: 0xE7FD38 VA: 0xE7FD38
	// public bool KEILLGAJEPF(int ECOIBKOIPFP, int IMPALJEMHJJ, int DNHLEPCFPFC, List<int> KJAIAJIIOMA, List<int> DJPOMCAOKKD, List<int> KBGIODFCIGN, List<int> LMIFMHACFID, List<int> DDFCBCNPGHD, List<int> MEJEDAJBJKN, int MCFPOJBDIHP, List<int> HPDJEIFEADB, int HADONLEBKLD) { }

	// // RVA: 0xE806E8 Offset: 0xE806E8 VA: 0xE806E8
	// public void IDCJNAFJLAA(int ECOIBKOIPFP, int IMPALJEMHJJ, int DNHLEPCFPFC, List<int> KJAIAJIIOMA, List<int> DJPOMCAOKKD, List<int> KBGIODFCIGN, List<int> LMIFMHACFID, List<int> DDFCBCNPGHD, List<int> MEJEDAJBJKN, int MCFPOJBDIHP, List<int> HPDJEIFEADB, List<string> NNDGIAEFMOG, int HADONLEBKLD) { }

	// // RVA: 0xE81148 Offset: 0xE81148 VA: 0xE81148
	// public bool NMFCNFFFMAC(int AHHJLDLAPAN, int EGNLGHDHDDH, bool MMNIIDPMDNP) { }

	// // RVA: 0xE8164C Offset: 0xE8164C VA: 0xE8164C
	// public void EINPFPOEPHP(int AHHJLDLAPAN, int EGNLGHDHDDH, bool MMNIIDPMDNP, List<string> NNDGIAEFMOG) { }

	// // RVA: 0xE81BB0 Offset: 0xE81BB0 VA: 0xE81BB0
	// public bool FKIJBFJBIOC(int JBGIHPHNDKH, bool MMNIIDPMDNP) { }

	// // RVA: 0xE81D54 Offset: 0xE81D54 VA: 0xE81D54
	// public void GJPDNBOCINF(int JBGIHPHNDKH, bool MMNIIDPMDNP, List<string> NNDGIAEFMOG) { }

	// // RVA: 0xE81EF8 Offset: 0xE81EF8 VA: 0xE81EF8
	// public bool CKANBNPEIJD(int LLOBHDMHJIG, int PFGJJLGLPAC) { }

	// // RVA: 0xE82324 Offset: 0xE82324 VA: 0xE82324
	// public void MKJABJDHKNO(int LLOBHDMHJIG, int PFGJJLGLPAC, List<string> NNDGIAEFMOG) { }

	// // RVA: 0xE82798 Offset: 0xE82798 VA: 0xE82798
	// public bool OANDCKGGJIP(int JCNLIANKPAA) { }

	// // RVA: 0xE82944 Offset: 0xE82944 VA: 0xE82944
	// public void HEBLFJFCCLF(int JCNLIANKPAA, List<string> NNDGIAEFMOG) { }
}
