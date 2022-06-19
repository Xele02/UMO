using System.Collections.Generic;
using System;
using UnityEngine;
using System.Collections;

public class BBGDKLLEPIB
{
	private enum GPPPPOFHAJC
	{
		FKPEAGGKNLC = 0,
		MJKPBANHCOE = 1,
		KBMHDBKJKEO = 2,
		KHLKPDFNABB = 3,
		FCIFGLGBCEO = 4,
		FFBGDIFGJJF = 5,
		PBGLLFHFFLF = 6,
		CEAKNCGBLGO = 7,
		HGLCABLHPAP = 8,
		KOKOCMNDHBB = 9,
		HIMAJCDOMFG = 10,
		OFFIEHJKEOO = 11,
		IMMACKJJDOM = 12,
		CDGFOMPKJON = 13,
		KPGBOHOHFCI = 14,
		KIIGNCNANOH = 15,
		DIPMILDNFJJ = 16,
		BBBLDKGNCLH = 17,
		KEJKHGHFBLH = 18,
		JFILOMCKGKA = 19,
		EPMDKGPMOFN = 20,
		DCECAAAFEDP = 21,
		EOELNFLLEDJ = 22,
	}
	
	private float NDEJCDBHPLB = 180.0f; // 0x8
	public static bool BELNLBKJPCO = false; // 0x4
	private string FPCIBJLJOFI = "db"; // 0xC
	public static string JNPHAJICDPN = "/db/sd.dat"; // 0xC
	public static string FNHCECHLIJI = "/db/ar_marker.dat"; // 0x10
	public static string NLOICACDGNI = "/db/ar_event.dat"; // 0x14
	private static string JCMJBMBMJAK = null; // 0x18
	public string OCOGBOHOGGE; // 0x10
	public List<long> PFMPODNDFIB = new List<long>(); // 0x14
	public long POCKENHKOBL; // 0x18
	public static bool FJDOHLADGFI = true; // 0x20
	private List<GCGNICILKLD> ICCMKHKNAMJ; // 0x28
	private static DateTime CBHCDLLOBBK = new DateTime(1970, 1, 1, 0, 0, 0, 1, 0); // 0x28
	private const int AJCPBLIKDGB = 1;
	private const int FAHBCEJNLJD = 2;
	private const int HEDNPEJAEBH = 2;
	private long DMPNAEEIANJ; // 0x30
	private int HGOIEGFBABK = 5; // 0x38
	public bool PBAHJENPLFM; // 0x3C

	public static BBGDKLLEPIB HHCJCDFCLOB { get; private set; }  // 0x0 LGMPACEDIJF // NKACBOEHELJ 0xF1723C OKPMHKNCNAL 0xF172C8
	public static string FLHOFIEOKDH { get; set; } // 0x8 PGOHBLKDJOM // ODMAEKMPAGP 0xF17358 BBPOAGDNMOJ 0xF173E4
	public static string OGCDNCDMLCA { get { 
		if(JCMJBMBMJAK == null)
		{
			string str = CJMOKHDNBNB.FIPFFELDIOG;
			if(string.IsNullOrEmpty(str))
			{
				Debug.LogError("Install.InstallPathManager.CriWare_installTargetPath is null");
			}
			JCMJBMBMJAK = str + "/mx";
		}
		return JCMJBMBMJAK;
	} } //  FHOCCNDOAPJ 0xF17474
	public static string LHJNPJFNDNA { get; private set; } // 0x1C HCGGEEMOKFN // JBIPCECPFGN 0xF1762C ONAJIIACAEB 0xF176B8
	public OMIFMMJPMDJ OEPPEGHGNNO { get; set; }  // 0x20 KPEKONPJHCL LKCDOGAFPNM 0xF17894  NPJJMDFAIII 0xF1789C
	public OBHIGCFPKJN MAIHLKPEHJN { get; set; } // 0x24 EAIFOAGPGGH KCLBNOKEPIG 0xF178A4 OCIMGEFKKLM 0xF178AC

	// // RVA: 0xF17748 Offset: 0xF17748 VA: 0xF17748
	// public bool KHJHKNLEOAB(long JHNMKKNEENE) { }

	// // RVA: 0xF178B4 Offset: 0xF178B4 VA: 0xF178B4
	public void IJBGPAENLJA(MonoBehaviour DANMJLOBLIE)
    {
        HHCJCDFCLOB = this;
    }

	// // RVA: 0xF17934 Offset: 0xF17934 VA: 0xF17934
	private void FCPBCDOKOPD(BBGDKLLEPIB.GPPPPOFHAJC PPFNGGCBJKC, string IPBHCLIHAPG)
	{
		return;
	}

	// // RVA: 0xF17938 Offset: 0xF17938 VA: 0xF17938
	public void PAHGEEOFEPM(IMCBBOAFION BHFHGFKBOHH, DJBHIFLHJLK MOBEEPPKFLG)
    {
		BBGDKLLEPIB.LHJNPJFNDNA = "";
		JCMJBMBMJAK = CJMOKHDNBNB.FIPFFELDIOG + "/mx";
		N.a.StartCoroutine(EOFJPNPFGDM_Coroutine_Install(BHFHGFKBOHH, MOBEEPPKFLG));
    }

	// [IteratorStateMachineAttribute] // RVA: 0x6BB854 Offset: 0x6BB854 VA: 0x6BB854
	// // RVA: 0xF17A70 Offset: 0xF17A70 VA: 0xF17A70
	private IEnumerator EOFJPNPFGDM_Coroutine_Install(IMCBBOAFION BHFHGFKBOHH, DJBHIFLHJLK MOBEEPPKFLG)
	{
		UnityEngine.Debug.Log("Enter EOFJPNPFGDM_Coroutine_Install");
		// private BBGDKLLEPIB.<>c__DisplayClass45_0 OPLBFCEPDCH; // 0x14
				// public BBGDKLLEPIB KIGBLACMODG; // 0x8
				// public bool KOMKKBDABJP; // 0xC
		// private BBGDKLLEPIB.<>c__DisplayClass45_1 LBLMCMHMNGC; // 0x18
				// public Dictionary<string, int> FAOOOLDDBBB; // 0x8
				// public JPAPJLIPNOK COJNCNGHIJC; // 0xC
				// public BBGDKLLEPIB.<>c__DisplayClass45_0 PGFMIBMJBHD; // 0x10
				// // RVA: 0xF1A184 Offset: 0xF1A184 VA: 0xF1A184
				// internal void IPGJJANJOMJ() { }
				// // RVA: 0xF1A2B8 Offset: 0xF1A2B8 VA: 0xF1A2B8
				// internal void EGDGJOPDNFF() { }
				// // RVA: 0xF1A318 Offset: 0xF1A318 VA: 0xF1A318
				// internal void FKJIINPOGKK(JEHIAIPJNJF.HCJPJKCIBDL JGBPLIGAILE) { }
				// // RVA: 0xF1A474 Offset: 0xF1A474 VA: 0xF1A474
				// internal void BCMEPPIPGIB() { }
		// public DJBHIFLHJLK MOBEEPPKFLG; // 0x1C
		// public IMCBBOAFION BHFHGFKBOHH; // 0x20
		// private BBGDKLLEPIB.<>c__DisplayClass45_2 PHPPCOBECCA; // 0x24
				// public int APGOAMNGFFF; // 0x8
				// // RVA: 0xF1A4DC Offset: 0xF1A4DC VA: 0xF1A4DC
				// internal void EKHEBHFBKID() { }
				// // RVA: 0xF1A4E8 Offset: 0xF1A4E8 VA: 0xF1A4E8
				// internal void OIIFKBGOJKO() { }
		// private BBGDKLLEPIB.<>c__DisplayClass45_3 OGEABHOODHB; // 0x28
				// public int APGOAMNGFFF; // 0x8
				// // RVA: 0xF1A4FC Offset: 0xF1A4FC VA: 0xF1A4FC
				// internal void NNGKGAGFFBE() { }
				// // RVA: 0xF1A508 Offset: 0xF1A508 VA: 0xF1A508
				// internal void CAPIELNEBFB() { }
		// private PJKLMCGEJMK OKDOIAEGADK; // 0x2C
		// private JEHIAIPJNJF MHHFMCPJONH; // 0x30
		//0xF1A518
		if(OEPPEGHGNNO == null)
		{
			OEPPEGHGNNO = this.ALDMHFCFECK;
		}
		if(MAIHLKPEHJN == null)
		{
			MAIHLKPEHJN = JHHBAFKMBDL.HHCJCDFCLOB.DOHNKJKOGFJ;
		}
		DMPNAEEIANJ = NKGJPJPHLIF.HHCJCDFCLOB.IBLPICFDGOF.FJDBNGEPKHL.KMEFBNBFJHI();
		LHJNPJFNDNA = null;
		Dictionary<string, int> FAOOOLDDBBB = new Dictionary<string, int>();
		//goto LAB_00f1b2e8;

		while(true)
		{
			JPAPJLIPNOK COJNCNGHIJC = NKGJPJPHLIF.HHCJCDFCLOB.IBLPICFDGOF.IFFNCAFNEAG_AddRequest<JPAPJLIPNOK>(new JPAPJLIPNOK());
			COJNCNGHIJC.FPCIBJLJOFI = FPCIBJLJOFI;
			yield return COJNCNGHIJC.GDPDELLNOBO(N.a);
			// 1
			if(COJNCNGHIJC.NPNNPNAIONN)
			{
				if(MOBEEPPKFLG != null)
					MOBEEPPKFLG();
				UnityEngine.Debug.Log("Exit Error EOFJPNPFGDM_Coroutine_Install");
				yield break;
			}

			FLHOFIEOKDH = COJNCNGHIJC.NFEAMMJIMPG.GLMGHMCOMEC;

			DMPNAEEIANJ = NKGJPJPHLIF.HHCJCDFCLOB.IBLPICFDGOF.FJDBNGEPKHL.KMEFBNBFJHI();
			if(COJNCNGHIJC.HOHOBEOJPBK.AJBPBEALBOB == LHJNPJFNDNA)
			{
				if(GBCDHECMDMC())
				{
					KEHOJEJMGLJ.AFKGMCBJBJA();
				}
				PKLPEIBEGNO();
				GC.Collect();
				//goto LAB_00f1b02c;
				if(BHFHGFKBOHH != null)
					BHFHGFKBOHH();
				UnityEngine.Debug.Log("Exit EOFJPNPFGDM_Coroutine_Install");
				yield break;
			}
			//L254
			ICCMKHKNAMJ = new List<GCGNICILKLD>();
			bool KOMKKBDABJP = false;

			NKGJPJPHLIF.HHCJCDFCLOB.IBLPICFDGOF.BNJPAKLNOPA_WorkerThreadQueue.Add(() => {
				//0xF1A184
				DIDACHONHJA(ref FAOOOLDDBBB, OGCDNCDMLCA);
				IAPEABPJPOE(COJNCNGHIJC.NFEAMMJIMPG, ref FAOOOLDDBBB);
				KOMKKBDABJP = true;
			});
			// L293
			while(!KOMKKBDABJP)
				yield return null;
			// L 698
			if(ICCMKHKNAMJ.Count == 0)
			{
				KOMKKBDABJP = false;
				NKGJPJPHLIF.HHCJCDFCLOB.IBLPICFDGOF.BNJPAKLNOPA_WorkerThreadQueue.Add(() => {
					//0xF1A2B8
					CIDPPOGCODB(FAOOOLDDBBB);
					KOMKKBDABJP = true;
				});
				//LAB_00f1b234
				while(!KOMKKBDABJP)
					yield return null;
				LHJNPJFNDNA = COJNCNGHIJC.HOHOBEOJPBK.AJBPBEALBOB;
				//LAB_00f1b2e8:
			}
			else
			{
				break;
			}
		}
		//L835
		if(OEPPEGHGNNO != null)
		{
			OEPPEGHGNNO(1, 0);
		}
		JEHIAIPJNJF MHHFMCPJONH = new JEHIAIPJNJF();
		MHHFMCPJONH.DOMFHDPMCCO(ICCMKHKNAMJ, FLHOFIEOKDH, JCMJBMBMJAK);
		MHHFMCPJONH.LBGNKOJFOFC = (JEHIAIPJNJF.HCJPJKCIBDL JGBPLIGAILE) => {
			//0xF1A318
			UnityEngine.Debug.Log("download "+JGBPLIGAILE.AJPIGKBIDDL);
			FAOOOLDDBBB[JGBPLIGAILE.LAPFOLJGJMB.OIEAICNAMNB] = 2;
		};
		MHHFMCPJONH.LAOEGNLOJHC();
		yield return null;
		//4
		MHHFMCPJONH.FBANBDCOEJL();
		//L.312
		if(MHHFMCPJONH.CMCKNKKCNDK == JEHIAIPJNJF.NKLKJEOKIFO.FEJIMBDPMKI/*2*/)
		{
			UnityEngine.Debug.LogError("TODO !!!");
		}

		UnityEngine.Debug.Log("Exit EOFJPNPFGDM_Coroutine_Install");
	}

	// // RVA: 0xF17B50 Offset: 0xF17B50 VA: 0xF17B50
	private void DIDACHONHJA(ref Dictionary<string, int> FAOOOLDDBBB, string CJJJPKJHOGM)
	{
		UnityEngine.Debug.LogError("TODO !!!");
	}

	// // RVA: 0xF17D68 Offset: 0xF17D68 VA: 0xF17D68
	public void CIDPPOGCODB(Dictionary<string, int> FAOOOLDDBBB)
	{
		UnityEngine.Debug.LogError("TODO !!!");
	}

	// // RVA: 0xF180AC Offset: 0xF180AC VA: 0xF180AC
	// private static bool NHIIAHGHOMH(string KLICLHJAMMD, long KPBJHHHMOJE) { }

	// // RVA: 0xF18248 Offset: 0xF18248 VA: 0xF18248
	private void IAPEABPJPOE(IKAHKDKIGNA CBLEBKOJJDB, ref Dictionary<string, int> FAOOOLDDBBB)
	{
		UnityEngine.Debug.LogError("TODO !!!");
	}

	// // RVA: 0xF19620 Offset: 0xF19620 VA: 0xF19620
	private bool ALDMHFCFECK(int INDDJNMPONH, float LNAHJANMJNM)
	{
		UnityEngine.Debug.LogError("TODO");
		return false;
	}

	// // RVA: 0xF19628 Offset: 0xF19628 VA: 0xF19628
	// private void EEHMGCMAOAB(string DOGDHKIEBJA, IMCBBOAFION KLMFJJCNBIP, JFDNPFFOACP NEFKBBNKNPP) { }

	// // RVA: 0xF1961C Offset: 0xF1961C VA: 0xF1961C
	// public static void GFOMKMANCPP(string CJEKGLGBIHF, long KMNPPIKCPNG) { }

	// // RVA: 0xF193D4 Offset: 0xF193D4 VA: 0xF193D4
	// private static string IFCHFDEDCGF(MD5 DMIPFEIICDP, string CJEKGLGBIHF) { }

	// // RVA: 0xF19654 Offset: 0xF19654 VA: 0xF19654
	// private static void ALKHIONADIP(string CJJJPKJHOGM) { }

	// // RVA: 0xF197AC Offset: 0xF197AC VA: 0xF197AC
	private void PKLPEIBEGNO()
	{
		UnityEngine.Debug.LogError("TODO !!!");
	}

	// // RVA: 0xF19B10 Offset: 0xF19B10 VA: 0xF19B10
	private bool GBCDHECMDMC()
	{
		UnityEngine.Debug.LogError("TODO !!!");
		return false;
	}
}
