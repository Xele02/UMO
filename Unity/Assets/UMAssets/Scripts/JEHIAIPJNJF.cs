using System.Collections.Generic;
using System;

public class JEHIAIPJNJF : IDisposable
{
    public enum NKLKJEOKIFO
    {
        PBIMGBKLDPP = 0,
        JGHMJIGGJHI = 1,
        FEJIMBDPMKI = 2,
        LLGCBKEOHNP = 3,
        LPLEIJIFOKN = 4,
        DNCJBLFALPA = 5,
    }

    public class HCJPJKCIBDL
    {
        public string AJPIGKBIDDL; // 0x8
        public string NFCMNIEHJML; // 0xC
        public string ADHHKEMDOIK; // 0x10
        public int OIPCCBHIKIA; // 0x14
        public double KMABBBKJFCB; // 0x18
        public bool NEDNDAKLBMJ; // 0x20
        public bool IKBKLPNADJM; // 0x21
        public GCGNICILKLD LAPFOLJGJMB; // 0x24
    }

    public class AFGDFAJEBFA
    {
        public CriFsWebInstaller.StatusInfo IOKJFDPOEFP; // 0x8
        public JEHIAIPJNJF.HCJPJKCIBDL ICKGJODOCBB; // 0x28
        public bool GGFGJEDLKNC; // 0x2C
        public float LBNOBJFOKMI; // 0x30
        public long NPKGIPPJGEI; // 0x38
        public int JBPJJGNGMFG; // 0x40
    }
 
    public delegate void FMOECHMCHPE(JEHIAIPJNJF.HCJPJKCIBDL KOGBMDOONFA);
    
	public static bool MLILLALMIPI = false; // 0x0
	public const int AEFPOPCGGJJ = 3;
	public static int GOFLMGPGMKO = 40; // 0x4
	public static float GCKDIGMAMND = 60.0f; // 0x8
	public static bool ANONIPNPMMA = false; // 0xC
	private static int GKJDDNOBIPM = 60; // 0x10
	private static List<CriFsWebInstaller> CICJCFPNCNO = new List<CriFsWebInstaller>(); // 0x14
	public JEHIAIPJNJF.NKLKJEOKIFO CMCKNKKCNDK; // 0x8
	public bool BHICPONFJKM; // 0xC // disk space error ?
	private List<JEHIAIPJNJF.HCJPJKCIBDL> JOJMBFBGMGN; // 0x10
	public JEHIAIPJNJF.FMOECHMCHPE LBGNKOJFOFC; // 0x14
	private Queue<CriFsWebInstaller> GBFHGDHNDIE; // 0x18
	private List<CriFsWebInstaller> KJIGCCPJBFK; // 0x1C
	private JEHIAIPJNJF.AFGDFAJEBFA[] JLNFKNICIFD; // 0x20
	private Dictionary<CriFsWebInstaller, JEHIAIPJNJF.AFGDFAJEBFA> PLDKOCEHDAL; // 0x24
	private bool OILIGLGDNAD; // 0x28
	private bool BIBKLAMCKGN; // 0x29
	private int EMAEFFGBFIB; // 0x2C
	public bool KAMPHNKAHAB; // 0x30
	private int OEMNJCADFLL; // 0x34

	// // RVA: 0x1C34424 Offset: 0x1C34424 VA: 0x1C34424
	public static void BNGLMLOLPEL()
	{

	}

	// // RVA: 0x1C34554 Offset: 0x1C34554 VA: 0x1C34554
	public static void IKPHNPJFNEG()
	{
		UnityEngine.Debug.LogError("TODO");
	}

	// // RVA: 0x1C34638 Offset: 0x1C34638 VA: 0x1C34638
	// private int FCPPMGNCGNO() { }

	// // RVA: 0x1C34784 Offset: 0x1C34784 VA: 0x1C34784
	// private int IOBFPLEDMOL() { }

	// // RVA: 0x1C348D0 Offset: 0x1C348D0 VA: 0x1C348D0
	public float HCAJCKCOCHC()
	{
		UnityEngine.Debug.LogError("TODO");
		return 0;
	}

	// RVA: 0x1C34A10 Offset: 0x1C34A10 VA: 0x1C34A10
	public JEHIAIPJNJF(int JAGOLJBNFMP = 3)
	{
		KAMPHNKAHAB = true;
		CMCKNKKCNDK = JEHIAIPJNJF.NKLKJEOKIFO.PBIMGBKLDPP;
		GBFHGDHNDIE = new Queue<CriFsWebInstaller>();
		KJIGCCPJBFK = new List<CriFsWebInstaller>();
		JLNFKNICIFD = new AFGDFAJEBFA[JAGOLJBNFMP];
		PLDKOCEHDAL = new Dictionary<CriFsWebInstaller, JEHIAIPJNJF.AFGDFAJEBFA>(JAGOLJBNFMP);
		for(int i = 0; i < JAGOLJBNFMP; i++)
		{
			CriFsWebInstaller wi = new CriFsWebInstaller();
			JEHIAIPJNJF.AFGDFAJEBFA a = new JEHIAIPJNJF.AFGDFAJEBFA();
			a.IOKJFDPOEFP = wi.GetStatusInfo();

			GBFHGDHNDIE.Enqueue(wi);
			JLNFKNICIFD[i] = a;
			PLDKOCEHDAL[wi] = a;
		}
	}

	// // RVA: 0x1C34CE0 Offset: 0x1C34CE0 VA: 0x1C34CE0 Slot: 1
	// protected override void Finalize() { }

	// // RVA: 0x1C34E78 Offset: 0x1C34E78 VA: 0x1C34E78 Slot: 4
	public void Dispose()
    {
        UnityEngine.Debug.LogError("TODO");
    }

	// // RVA: 0x1C34F08 Offset: 0x1C34F08 VA: 0x1C34F08
	public void DOMFHDPMCCO(List<GCGNICILKLD> IDJBKGBMDAJ, string JCILKDKNDLE, string OGCDNCDMLCA)
	{
		StringBuilder str = new StringBuilder(256);
		BIBKLAMCKGN = false;
		
		JOJMBFBGMGN = new List<JEHIAIPJNJF.HCJPJKCIBDL>(IDJBKGBMDAJ.Count);
		for(int i = 0; i < IDJBKGBMDAJ.Count; i++)
		{
			HCJPJKCIBDL data = new HCJPJKCIBDL();
			data.AJPIGKBIDDL = IDJBKGBMDAJ[i].OIEAICNAMNB;
			str.SetLength(0);
			str.Append(JCILKDKNDLE);
			str.Append(IDJBKGBMDAJ[i].OIEAICNAMNB);
			data.NFCMNIEHJML = JCILKDKNDLE + IDJBKGBMDAJ[i].POEGMFKLFJG;
			str.SetLength(0);
			str.Append(OGCDNCDMLCA);
			str.Append(IDJBKGBMDAJ[i].OIEAICNAMNB);
			data.LAPFOLJGJMB = IDJBKGBMDAJ[i];
			data.ADHHKEMDOIK = str.ToString();
			data.OIPCCBHIKIA = i;
			JOJMBFBGMGN.Add(data);
		}
		
		CMCKNKKCNDK = JEHIAIPJNJF.NKLKJEOKIFO.PBIMGBKLDPP;
	}

	// // RVA: 0x1C352A0 Offset: 0x1C352A0 VA: 0x1C352A0
	public void DOMFHDPMCCO(List<KDLPEDBKMID.EMEKAOMPFNC> CEKHMLAEKIK)
	{
        UnityEngine.Debug.LogError("TODO");
	}

	// // RVA: 0x1C354B8 Offset: 0x1C354B8 VA: 0x1C354B8
	public bool MNAIIMMIMIO(string CJEKGLGBIHF)
	{
		for(int i = 0; i < JOJMBFBGMGN.Count; i++)
		{
			if(JOJMBFBGMGN[i].AJPIGKBIDDL == CJEKGLGBIHF)
				return true;
				
		}
		return false;
	}

	// // RVA: 0x1C355BC Offset: 0x1C355BC VA: 0x1C355BC
	public void LAOEGNLOJHC()
	{
		IMDNPMAIJFO();
		BHICPONFJKM = false;
		if(CMCKNKKCNDK != 0)
			return;
		CMCKNKKCNDK = 1;
	}

	// // RVA: 0x1C3578C Offset: 0x1C3578C VA: 0x1C3578C
	public void PBIMGBKLDPP()
	{
		if(CMCKNKKCNDK == 5)
		{
			CMCKNKKCNDK = 1;
			return;
		}
		if(CMCKNKKCNDK == 4)
		{
			return;
		}
		for(int i = 0; i < KJIGCCPJBFK.Count; i++)
		{
			CriFsWebInstaller installer = KJIGCCPJBFK[i];
			JEHIAIPJNJF.AFGDFAJEBFA info = PLDKOCEHDAL[installer];
			installer.Stop();
			if(info.ICKGJODOCBB != null)
			{
				info.KMABBBKJFCB = 0;
				info.ICKGJODOCBB.NEDNDAKLBMJ = false;
				info.ICKGJODOCBB.IKBKLPNADJM = false;
				info.ICKGJODOCBB = null;
			}
		}
		CMCKNKKCNDK = 5;
		EMAEFFGBFIB = 0;
	}

	// // RVA: 0x1C35A48 Offset: 0x1C35A48 VA: 0x1C35A48
	public void FBANBDCOEJL()
	{
		UnityEngine.Debug.LogError("TODO");
	}

	// // RVA: 0x1C34D48 Offset: 0x1C34D48 VA: 0x1C34D48
	// private void PEFNBFCMIBL(bool PGDOLHMCLIA) { }

	// // RVA: 0x1C36BC0 Offset: 0x1C36BC0 VA: 0x1C36BC0
	// public string LCKGFBCHOAJ() { }

	// // RVA: 0x1C363E4 Offset: 0x1C363E4 VA: 0x1C363E4
	// private int PKDGOJNCLBK() { }

	// // RVA: 0x1C380F0 Offset: 0x1C380F0 VA: 0x1C380F0
	public bool MNFGKBAEFFL()
	{
		UnityEngine.Debug.LogError("TODO !!!");
		return false;
	}

	// // RVA: 0x1C37140 Offset: 0x1C37140 VA: 0x1C37140
	// private void DLHJNILCAGE(JEHIAIPJNJF.AFGDFAJEBFA PHKJOMLDNOB) { }

	// // RVA: 0x1C35730 Offset: 0x1C35730 VA: 0x1C35730
	public void IMDNPMAIJFO()
	{
		int avaiableSize = StorageSupport.GetAvailableStorageSizeMB();
		if(avaiableSize < 51)
		{
			KAMPHNKAHAB = true;
			OEMNJCADFLL = -1;
		}
		else
		{
			OEMNJCADFLL = 10;
			if(avaiableSize >= 200)
				OEMNJCADFLL = 30;
			if(avaiableSize >= 500)
				OEMNJCADFLL = 120;
			if(avaiableSize >= 1000)
				OEMNJCADFLL = 240;
			KAMPHNKAHAB = false;
		}
	}

	// // RVA: 0x1C363C4 Offset: 0x1C363C4 VA: 0x1C363C4
	// private void DEOEDMFDPGP() { }

	// // RVA: 0x1C36884 Offset: 0x1C36884 VA: 0x1C36884
	// private void HNKPDKKIPOH() { }
}
