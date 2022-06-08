using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using XeApp.Game.Common;
using SecureLib;

public class IMMAOANGPNK
{
	public class MPFFINOMILP
	{
		public int IJEKNCDIIAE; // 0x8
		public string OPFGFINHFCE; // 0xC
		public long PDBPFJJCADD; // 0x10

		// // RVA: 0x9FD928 Offset: 0x9FD928 VA: 0x9FD928
		// public void .ctor() { }
	}

	private static bool NAANHMNAHGI; // 0x4
	public int ENEBEGGOHFP; // 0x14
	public int HMHKGLENIOP; // 0x18
	public byte[] GCELJIDIGDG; // 0x20

	public static IMMAOANGPNK HHCJCDFCLOB { get; set; }  // 0x0 LGMPACEDIJF // NKACBOEHELJ 0x9F4C94 OKPMHKNCNAL 0x9FB6B0
	public bool LNAHEIEIBOI { get; set; }  // 0x8 INBPPDMFOAD  FHEAKKHAAPF 0x9FB740 GOEIEJFPLOG 0x9FB748
	public OKGLGHCBCJP_Database NKEBMCIMJND { get; set; }  // 0xC MFOHJHBKKBA // GBGACEBEHKM 0x9F4D20 CCMBFKBIMEE 0x9FB750
	public string NDHOBEEEKEM { get; set; }  // 0x10 IKBMAEMKGMN JNAKONBIOKB 0x9FB758 PDOJAEDKBDJ 0x9FB760
	public List<GDIPLANPCEI> JOBKIDDLCPL { get; set; } // 0x1C MAFBBMCECAD AMJKGMNLEKE 0x9FB768 CMKNDEJMAIJ 0x9FB770
	public List<IMMAOANGPNK.MPFFINOMILP> MGFBEKNMJOA { get; set; } // 0x24 MGMCACBHEGK FNFJPHEBELC 0x9FB778 MNINNHABPAA 0x9FB780

	// // RVA: 0x9FB788 Offset: 0x9FB788 VA: 0x9FB788
	public void IJBGPAENLJA(MonoBehaviour DANMJLOBLIE)
	{
		HHCJCDFCLOB = this;
		LNAHEIEIBOI = false;
		NKEBMCIMJND = new OKGLGHCBCJP_Database();
		ENEBEGGOHFP = 0;
		JOBKIDDLCPL = new List<GDIPLANPCEI>();
		MGFBEKNMJOA = new List<IMMAOANGPNK.MPFFINOMILP>();
	}

	// // RVA: 0x9FB8A8 Offset: 0x9FB8A8 VA: 0x9FB8A8
	public void BAGMHFKPFIF()
	{
		return;
	}

	// // RVA: 0x9FB8AC Offset: 0x9FB8AC VA: 0x9FB8AC
	// public GDIPLANPCEI ACEFBFLFKFD(string FJMNHCBPKCJ, long JHNMKKNEENE) { }

	// // RVA: 0x9FB9FC Offset: 0x9FB9FC VA: 0x9FB9FC
	public void BAHKPIADOBI(IMCBBOAFION BHFHGFKBOHH, DJBHIFLHJLK MOBEEPPKFLG)
	{
		N.a.StartCoroutine(MHEKMICKGDM_LoadFromStorage(BHFHGFKBOHH, MOBEEPPKFLG));
	}

	// [IteratorStateMachineAttribute] // RVA: 0x6B75F8 Offset: 0x6B75F8 VA: 0x6B75F8
	// // RVA: 0x9FBB1C Offset: 0x9FBB1C VA: 0x9FBB1C
	// private IEnumerator CBIPJKFPJDH_DownloadSchedules(IMCBBOAFION BHFHGFKBOHH, DJBHIFLHJLK MOBEEPPKFLG) { }

	// [IteratorStateMachineAttribute] // RVA: 0x6B7670 Offset: 0x6B7670 VA: 0x6B7670
	// // RVA: 0x9FBBFC Offset: 0x9FBBFC VA: 0x9FBBFC
	// private IEnumerator HPGEKNMPMEA_Download(IMCBBOAFION BHFHGFKBOHH, DJBHIFLHJLK MOBEEPPKFLG) { }

	// [IteratorStateMachineAttribute] // RVA: 0x6B76E8 Offset: 0x6B76E8 VA: 0x6B76E8
	// // RVA: 0x9FBA5C Offset: 0x9FBA5C VA: 0x9FBA5C
	private IEnumerator MHEKMICKGDM_LoadFromStorage(IMCBBOAFION BHFHGFKBOHH, DJBHIFLHJLK MOBEEPPKFLG)
	{
		// private int GGPNEJDOELB; // 0x8
		// private object GMEFKDIEHCA; // 0xC
		// public IMMAOANGPNK KIGBLACMODG; // 0x10
		// private IMMAOANGPNK.<>c__DisplayClass35_1 OPLBFCEPDCH; // 0x14
		// public DJBHIFLHJLK MOBEEPPKFLG; // 0x18
		// private IMMAOANGPNK.<>c__DisplayClass35_0 LBLMCMHMNGC; // 0x1C
		// public IMCBBOAFION BHFHGFKBOHH; // 0x20
		// private string BLOMMALFLCM; // 0x24
		// private GNMBAOKGJDO HCNDEJCCIMA; // 0x28
		// 0x9FF020

		//lambda 1 : 0x9FE328 // lambda 2 : 0x9FE334
		bool KOMKKBDABJP = false;
		bool CNAIDEAFAAM = false;
		BBGDKLLEPIB.HHCJCDFCLOB.PAHGEEOFEPM(() => { KOMKKBDABJP = true; }, () => { KOMKKBDABJP = true; CNAIDEAFAAM = true; }); //?? 0x101
		while(!KOMKKBDABJP)
		{
			yield return null;
		}
		if(CNAIDEAFAAM)
		{
			MOBEEPPKFLG();
			yield break;
		}

		string str = BBGDKLLEPIB.OGCDNCDMLCA; // mx install dir
		if(!string.IsNullOrEmpty(str))
		{
			if(!string.IsNullOrEmpty(BBGDKLLEPIB.HHCJCDFCLOB.OCOGBOHOGGE))
			{
				bool BEKAMBBOLBO = false;
				IIEDOGCMCIE GBEGLNMFLIE = new IIEDOGCMCIE();
				GBEGLNMFLIE.MCDJJPAKBLH(str + BBGDKLLEPIB.HHCJCDFCLOB.OCOGBOHOGGE);
				while(GBEGLNMFLIE.PLOOEECNHFB == false)
				{
					yield return null;
				}
				if(GBEGLNMFLIE.NPNNPNAIONN == false)
				{
					yield return N.a.StartCoroutine(LGFPCADOCAA_ShowError());
					MOBEEPPKFLG();
					GBEGLNMFLIE = null;
					yield break;
				}
				long val = NKGJPJPHLIF.HHCJCDFCLOB.IBLPICFDGOF.FIIMIGEKDCM().KMEFBNBFJHI();
				CMFCGGAKLFN(GBEGLNMFLIE, val);
				BBHOKHCDBFI(GBEGLNMFLIE);
				List<OKGLGHCBCJP_Database.BEOKNKGHFFE> list = NKEBMCIMJND.BPCKOIDILDK(JOBKIDDLCPL, val);
				NKEBMCIMJND.LNAKMLCCEJG(list, OKGLGHCBCJP_Database.GAAEFILMAED);
				NKEBMCIMJND.KHEKNNFCAOI(list);
				bool HBODCMLFDOB = false;
				NKGJPJPHLIF.HHCJCDFCLOB.IBLPICFDGOF.BNJPAKLNOPA_WorkerThreadQueue.Add(() => {
					List<string> listStr = NKEBMCIMJND.PKOJMBICNHH();
					HBODCMLFDOB = NKEBMCIMJND.IIEMACPEEBJ(listStr, GBEGLNMFLIE);
					if(HBODCMLFDOB)
					{
						MLIBEPGADJH a = NKEBMCIMJND.ECNHDEHADGL;
						if(a != null)
						{
							KOGHKIODHPA b = NKEBMCIMJND.JEMMMJEJLNL;
							if(b != null)
							{
								a.AMACEDAPNKJ(NKEBMCIMJND.HNMMJINNHII, b);
							}
						}
						BBLECJKKKLA c = NKEBMCIMJND.MJALLIOHKEJ;
						if(c != null)
						{
							NDBFKHKMMCE d = NKEBMCIMJND.EPAHOAKPAJJ;
							if(d != null)
							{
								d.MFIAFCCJHOF(c);
							}
						}
					}
					BEKAMBBOLBO = true;
				});
				while(!BEKAMBBOLBO)
					yield return null;
				
				if(!HBODCMLFDOB)
				{
					yield return N.a.StartCoroutine(LGFPCADOCAA_ShowError());
					MOBEEPPKFLG();
					yield break;
				}
				
				if(MessageLoader.Instance != null)
				{
					UnityEngine.Debug.LogError("TODO");
				}
				
				AMAFAKNIHFO();
				NKEBMCIMJND.IDBDAPPJOND();
				KPKEOIJHIMN f = NKGJPJPHLIF.HHCJCDFCLOB.IBLPICFDGOF.JACGBOGNFKM();
				f.FFEJIGPPHOA(BBGDKLLEPIB.LHJNPJFNDNA);
				string BLOMMALFLCM = BBGDKLLEPIB.OGCDNCDMLCA;
				BLOMMALFLCM = BLOMMALFLCM + BBGDKLLEPIB.JNPHAJICDPN;
				//new XeApp.Game.Net.Security.SecureGZFile
				GNMBAOKGJDO HCNDEJCCIMA = new GNMBAOKGJDO();
				HCNDEJCCIMA.MCDJJPAKBLH(BLOMMALFLCM);
				while(!HCNDEJCCIMA.PLOOEECNHFB)
				{
					yield return null;
				}
				if(File.Exists(BLOMMALFLCM))
				{
					File.Delete(BLOMMALFLCM);
				}
				GCELJIDIGDG = HCNDEJCCIMA.IAKPCFDLMKP;
				if(!HCNDEJCCIMA.NPNNPNAIONN)
				{
					BLOMMALFLCM = null;
					HCNDEJCCIMA = null;
					bool LAB_00a0006c = false;
					if(!NAANHMNAHGI)
					{
						if(GCELJIDIGDG == null)
						{
							BEKAMBBOLBO = false;
							JHHBAFKMBDL.HHCJCDFCLOB.GKMAHMLNMEK(() => { // 0x9FE2CC
								BEKAMBBOLBO = true;
							}, "");
							while(!BEKAMBBOLBO)
							{
								yield return null;
							}
						}
						else
						{
							CNGFKOJANNP.HHCJCDFCLOB.NOIKNDALDAC(GCELJIDIGDG);
							if(GCELJIDIGDG != null)
							{
								ATELIDAVAPK a = new ATELIDAVAPK();
								if(a.Init(GCELJIDIGDG))
								{
									if(!a.CCKHESGNI())
									{
										BEKAMBBOLBO = false;
										JHHBAFKMBDL.HHCJCDFCLOB.GKMAHMLNMEK(() => {//0x9FE2D8
											BEKAMBBOLBO = true;
										}, "");
										while(!BEKAMBBOLBO)
										{
											yield return null;
										}
									}
									else if(!a.QTHZDMBR())
									{
										BEKAMBBOLBO = false;
										JHHBAFKMBDL.HHCJCDFCLOB.GKMAHMLNMEK(() => {//0x9FE2E4
											BEKAMBBOLBO = true;
										}, "");
										while(!BEKAMBBOLBO)
										{
											yield return null;
										}
									}
									else // a.QTHZDMBR()
									{
										NAANHMNAHGI = true;
										LAB_00a0006c = true;
									}
								}
								else
								{
									BEKAMBBOLBO = false;
									JHHBAFKMBDL.HHCJCDFCLOB.GKMAHMLNMEK(() => {//0x9FE2F0
										BEKAMBBOLBO = true;
									}, "");
									while(!BEKAMBBOLBO)
									{
										yield return null;
									}
								}
							}
							else
							{
								LAB_00a0006c = true;
							}
						}
					}
					else
					{
						LAB_00a0006c = true;
					}
					if(LAB_00a0006c)
					{
						if(SecureLibAPI.isDebuggerAttachedJava())
						{
							BEKAMBBOLBO = false;
							JHHBAFKMBDL.HHCJCDFCLOB.GKMAHMLNMEK(() => {//0x9FE2FC
								BEKAMBBOLBO = true;
							}, "");
							while(!BEKAMBBOLBO)
							{
								yield return null;
							}
						}
						else if(SecureLibAPI.isDebuggerAttachedNative())
						{
							BEKAMBBOLBO = false;
							JHHBAFKMBDL.HHCJCDFCLOB.GKMAHMLNMEK(() => {//0x9FE308
								BEKAMBBOLBO = true;
							}, "");
							while(!BEKAMBBOLBO)
							{
								yield return null;
							}
						}
						else 
						{
							if(!SecureLibAPI.isEmulator())
							{
								if(BHFHGFKBOHH != null)
								{
									BHFHGFKBOHH();
									LNAHEIEIBOI = true;
									yield break;
								}
							}
							BEKAMBBOLBO = false;
							JHHBAFKMBDL.HHCJCDFCLOB.GKMAHMLNMEK(() => {//0x9FE314
								BEKAMBBOLBO = true;
							}, "");
							while(!BEKAMBBOLBO)
							{
								yield return null;
							}
						}
					}
				}
				else
				{
					BEKAMBBOLBO = false;
					JHHBAFKMBDL.HHCJCDFCLOB.GKMAHMLNMEK(() => {//0x9FE2C0
						BEKAMBBOLBO = true;
					}, "");
					while(!BEKAMBBOLBO)
					{
						yield return null;
					}
				}
				MOBEEPPKFLG();
				yield break;
			}
		}
		yield return N.a.StartCoroutine(LGFPCADOCAA_ShowError());
		MOBEEPPKFLG();
	}

	// [IteratorStateMachineAttribute] // RVA: 0x6B7760 Offset: 0x6B7760 VA: 0x6B7760
	// // RVA: 0x9FBCFC Offset: 0x9FBCFC VA: 0x9FBCFC
	private IEnumerator LGFPCADOCAA_ShowError()
	{
		UnityEngine.Debug.LogError("TODO");
		yield break;
	}

	// // RVA: 0x9FBD90 Offset: 0x9FBD90 VA: 0x9FBD90
	// public bool HFCOEBFNJPK() { }

	// // RVA: 0x9FBEAC Offset: 0x9FBEAC VA: 0x9FBEAC
	// public void OMHKOKKAMNO(IMCBBOAFION EDIIEFHAOGP) { }

	// // RVA: 0x9FC14C Offset: 0x9FC14C VA: 0x9FC14C
	private void AMAFAKNIHFO()
	{
		UnityEngine.Debug.LogError("TODO");
	}

	// // RVA: 0x9FC460 Offset: 0x9FC460 VA: 0x9FC460
	// private void PDKNJAEGNIL() { }

	// // RVA: 0x9FC4CC Offset: 0x9FC4CC VA: 0x9FC4CC
	// public void PFAKPFKJJKA() { }

	// // RVA: 0x9FC518 Offset: 0x9FC518 VA: 0x9FC518
	private void BBHOKHCDBFI(CBBJHPBGBAJ_Archive GBEGLNMFLIE)
	{
		UnityEngine.Debug.LogError("TODO");
	}

	// // RVA: 0x9FCE3C Offset: 0x9FCE3C VA: 0x9FCE3C
	// public bool JMAMHEJDNNN(long JHNMKKNEENE) { }

	// // RVA: 0x9FCF88 Offset: 0x9FCF88 VA: 0x9FCF88
	private void CMFCGGAKLFN(CBBJHPBGBAJ_Archive GBEGLNMFLIE, long JHNMKKNEENE)
	{
		
	// public static readonly IMMAOANGPNK.<>c <>9; // 0x0
	// public static Predicate<CBBJHPBGBAJ.JBCFNCNGLPM> <>9__42_0; // 0x4
	// public static Predicate<CBBJHPBGBAJ.JBCFNCNGLPM> <>9__44_0; // 0x8
	// public static Comparison<IMMAOANGPNK.MPFFINOMILP> <>9__44_1; // 0xC
		MGFBEKNMJOA.Clear();
		
		CBBJHPBGBAJ_Archive.JBCFNCNGLPM_File res = GBEGLNMFLIE.KGHAJGGMPKL_Files.Find((CBBJHPBGBAJ_Archive.JBCFNCNGLPM_File GHPLINIACBB) => { return GHPLINIACBB.OPFGFINHFCE_Name.Contains("version.bytes"); }); // 0x9FDDD8
		if(res != null)
		{
			IDEELDJLDBN a = IDEELDJLDBN.HEGEKFMJNCC(res.DBBGALAPFGC_Data);
			JGIHJPPECBB[] b = a.MLOPDBGPLFI;
			for(int i = 0; i < b.Length; i++)
			{
				int val = b[i].BEBJKJKBOGH;
				UnityEngine.Debug.LogError("TODO");
			}
		}
		
		UnityEngine.Debug.LogError("TODO");
	}

	// // RVA: 0x9FD930 Offset: 0x9FD930 VA: 0x9FD930
	// public bool MKINIELBKEK(long JHNMKKNEENE) { }
}
