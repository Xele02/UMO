using System.Collections.Generic;
using System;
using System.Text;
using XeSys;
using UnityEngine;
using System.Threading;
using System.IO;

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
        public double KMABBBKJFCB; // 0x18 // percent
        public bool NEDNDAKLBMJ; // 0x20
        public bool IKBKLPNADJM; // 0x21
        public GCGNICILKLD LAPFOLJGJMB; // 0x24
    }

    public class AFGDFAJEBFA
    {
        public CriFsWebInstaller.StatusInfo IOKJFDPOEFP; // 0x8
        public JEHIAIPJNJF.HCJPJKCIBDL ICKGJODOCBB; // 0x28
        public bool GGFGJEDLKNC; // 0x2C
        public float LBNOBJFOKMI; // 0x30 // timeout detector
        public long NPKGIPPJGEI; // 0x38 // current size received
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
		UnityEngine.Debug.LogWarning("TODO BNGLMLOLPEL");
	}

	// // RVA: 0x1C34554 Offset: 0x1C34554 VA: 0x1C34554
	public static void IKPHNPJFNEG()
	{
		UnityEngine.Debug.LogError("TODO");
	}

	// // RVA: 0x1C34638 Offset: 0x1C34638 VA: 0x1C34638
	private int FCPPMGNCGNO()
	{
		int res = 0;
		for(int i = 0; i < JOJMBFBGMGN.Count; i++)
		{
			if(!JOJMBFBGMGN[i].IKBKLPNADJM)
			{
				if(JOJMBFBGMGN[i].NEDNDAKLBMJ)
				{
					res = res + 1;
				}
			}
			else
			{
				res = res + 1;
			}
		}
		
		return JOJMBFBGMGN.Count - res;
	}

	// // RVA: 0x1C34784 Offset: 0x1C34784 VA: 0x1C34784
	private int IOBFPLEDMOL()
	{
		for(int i = 0; i < JOJMBFBGMGN.Count; i++)
		{
			if(!JOJMBFBGMGN[i].IKBKLPNADJM)
			{
				if(!JOJMBFBGMGN[i].NEDNDAKLBMJ)
				{
					return i;
				}
			}
		}
		return -1;
	}

	// // RVA: 0x1C348D0 Offset: 0x1C348D0 VA: 0x1C348D0
	public float HCAJCKCOCHC()
	{
		double res = 0.0f;
		if(CMCKNKKCNDK != JEHIAIPJNJF.NKLKJEOKIFO.FEJIMBDPMKI && JOJMBFBGMGN != null)
		{
			for(int i = 0; i < JOJMBFBGMGN.Count; i++)
			{
				res += JOJMBFBGMGN[i].KMABBBKJFCB;
			}
			res = res * 100.0f / JOJMBFBGMGN.Count;
		}
		return (float)res;
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
		PEFNBFCMIBL(false);
		GC.SuppressFinalize(this);
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
			str.Set(JCILKDKNDLE);
			str.Append(IDJBKGBMDAJ[i].OIEAICNAMNB);
			data.NFCMNIEHJML = JCILKDKNDLE + IDJBKGBMDAJ[i].MFBMBPJAADA;
			str.Set(OGCDNCDMLCA);
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
		if(CMCKNKKCNDK != JEHIAIPJNJF.NKLKJEOKIFO.PBIMGBKLDPP/*0*/)
			return;
		CMCKNKKCNDK = JEHIAIPJNJF.NKLKJEOKIFO.JGHMJIGGJHI/*1*/;
	}

	// // RVA: 0x1C3578C Offset: 0x1C3578C VA: 0x1C3578C
	public void PBIMGBKLDPP()
	{
		if(CMCKNKKCNDK == JEHIAIPJNJF.NKLKJEOKIFO.DNCJBLFALPA/*5*/)
		{
			CMCKNKKCNDK = JEHIAIPJNJF.NKLKJEOKIFO.JGHMJIGGJHI/*1*/;
			return;
		}
		if(CMCKNKKCNDK == JEHIAIPJNJF.NKLKJEOKIFO.LPLEIJIFOKN/*4*/)
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
				info.ICKGJODOCBB.KMABBBKJFCB = 0;
				info.ICKGJODOCBB.NEDNDAKLBMJ = false;
				info.ICKGJODOCBB.IKBKLPNADJM = false;
				info.ICKGJODOCBB = null;
			}
		}
		CMCKNKKCNDK = JEHIAIPJNJF.NKLKJEOKIFO.DNCJBLFALPA/*5*/;
		EMAEFFGBFIB = 0;
	}

	// // RVA: 0x1C35A48 Offset: 0x1C35A48 VA: 0x1C35A48
	public void FBANBDCOEJL()
	{
		if(OEMNJCADFLL > -1)
		{
			OEMNJCADFLL = OEMNJCADFLL - 1;
			if(OEMNJCADFLL == 0)
			{
				IMDNPMAIJFO();
			}
		}
		if(CMCKNKKCNDK != JEHIAIPJNJF.NKLKJEOKIFO.JGHMJIGGJHI)
		{
			if(CMCKNKKCNDK == JEHIAIPJNJF.NKLKJEOKIFO.DNCJBLFALPA)
			{
				CriFsWebInstaller.ExecuteMain();
				PKDGOJNCLBK();
				string logTxt = "";
				if(KJIGCCPJBFK.Count == 0)
				{
					//logTxt = "StringLiteral_11859";
				}
				else
				{
					//logTxt = "StringLiteral_11860" + EMAEFFGBFIB;
					EMAEFFGBFIB = EMAEFFGBFIB + 1;
					if(EMAEFFGBFIB < GKJDDNOBIPM)
						return;
					// log StringLiteral_11861
					// log StringLiteral_11862
					int numInstaller = KJIGCCPJBFK.Count;
					while(KJIGCCPJBFK.Count > 0)
					{
						CriFsWebInstaller wi = KJIGCCPJBFK[0];
						JEHIAIPJNJF.AFGDFAJEBFA info = PLDKOCEHDAL[wi];
						KJIGCCPJBFK.RemoveAt(0);
						PLDKOCEHDAL.Remove(wi);
						if(info.ICKGJODOCBB != null)
						{
							info.ICKGJODOCBB.NEDNDAKLBMJ = false;
							info.ICKGJODOCBB.KMABBBKJFCB = 0;
						}
						CICJCFPNCNO.Add(wi);
					}
					//log StringLiteral_11863
					for(int i = 0; i < numInstaller; i++)
					{
						CriFsWebInstaller installer = new CriFsWebInstaller();
						JEHIAIPJNJF.AFGDFAJEBFA info = new JEHIAIPJNJF.AFGDFAJEBFA();
						info.IOKJFDPOEFP = installer.GetStatusInfo();
						GBFHGDHNDIE.Enqueue(installer);
						JLNFKNICIFD[i] = info;
						PLDKOCEHDAL.Add(installer, info);
					}
				}
				CMCKNKKCNDK = 0;
				EMAEFFGBFIB = 0;
				return;
			}
			if(CMCKNKKCNDK != JEHIAIPJNJF.NKLKJEOKIFO.LLGCBKEOHNP)
				return;
		}
		CriFsWebInstaller.ExecuteMain();
		int a = PKDGOJNCLBK();
		if(a < 1)
		{
			if(FCPPMGNCGNO() != 0)
			{
				HNKPDKKIPOH();
				return;
			}
			if(KJIGCCPJBFK.Count != 0)
				return;
			CMCKNKKCNDK = JEHIAIPJNJF.NKLKJEOKIFO.FEJIMBDPMKI;
		}
		else
		{
			if(KJIGCCPJBFK.Count == a)
			{
				CMCKNKKCNDK = JEHIAIPJNJF.NKLKJEOKIFO.LPLEIJIFOKN;
			}
			else
			{
				CMCKNKKCNDK = JEHIAIPJNJF.NKLKJEOKIFO.LLGCBKEOHNP;
			}
		}
	}

	// // RVA: 0x1C34D48 Offset: 0x1C34D48 VA: 0x1C34D48
	private void PEFNBFCMIBL(bool PGDOLHMCLIA)
	{
		if(OILIGLGDNAD)
			return;
		if(CMCKNKKCNDK != 0)
		{
			PBIMGBKLDPP();
			while(CMCKNKKCNDK != 0)
			{
				FBANBDCOEJL();
				Thread.Sleep(1);
			}
		}
		while(GBFHGDHNDIE.Count != 0)
		{
			CriFsWebInstaller installer = GBFHGDHNDIE.Dequeue();	
			installer.Dispose();
		}
		JOJMBFBGMGN = null;
		GBFHGDHNDIE = null;
		JLNFKNICIFD = null;
	}

	// // RVA: 0x1C36BC0 Offset: 0x1C36BC0 VA: 0x1C36BC0
	// public string LCKGFBCHOAJ() { }

	// // RVA: 0x1C363E4 Offset: 0x1C363E4 VA: 0x1C363E4
	private int PKDGOJNCLBK()
	{
		int index = 0;
		int res = 0;
		CriFsWebInstaller.Status status;
		JEHIAIPJNJF.AFGDFAJEBFA info = null;
		CriFsWebInstaller installer = null;
		while(true)
		{
			while(true)
			{
				while(true)
				{
					if(index >= KJIGCCPJBFK.Count)
						return res;
					installer = KJIGCCPJBFK[index];
					info = PLDKOCEHDAL[installer];
					info.IOKJFDPOEFP = installer.GetStatusInfo();
					status = info.IOKJFDPOEFP.status;
					if(info.IOKJFDPOEFP.status != CriFsWebInstaller.Status.Stop)
						break;
					if(info.ICKGJODOCBB != null)
					{
						info.ICKGJODOCBB.IKBKLPNADJM = false;
						info.ICKGJODOCBB.NEDNDAKLBMJ = false;
						info.ICKGJODOCBB.KMABBBKJFCB = 0;
					}
					KJIGCCPJBFK.RemoveAt(index);
					GBFHGDHNDIE.Enqueue(installer);
				}
				if(status == CriFsWebInstaller.Status.Complete)
					break;
				if(status == CriFsWebInstaller.Status.Error)
				{
					DLHJNILCAGE(info);
					index = index + 1;
					CMCKNKKCNDK = JEHIAIPJNJF.NKLKJEOKIFO.LLGCBKEOHNP;
					res = res + 1;
				}
				else
				{
					if(info.IOKJFDPOEFP.contentsSize > 0)
					{
						if(info.ICKGJODOCBB != null)
						{
							info.ICKGJODOCBB.KMABBBKJFCB = 1.0f * info.IOKJFDPOEFP.receivedSize / info.IOKJFDPOEFP.contentsSize;
						}
						float f = 0.0f;
						if(info.IOKJFDPOEFP.receivedSize == info.NPKGIPPJGEI)
						{
							f = info.LBNOBJFOKMI + Time.deltaTime;
						}
						info.LBNOBJFOKMI = f;
						info.NPKGIPPJGEI = info.IOKJFDPOEFP.receivedSize;
					}
					else
					{
						info.LBNOBJFOKMI = info.LBNOBJFOKMI + Time.deltaTime;
					}
					index = index + 1;
				}
			}
			if(LBGNKOJFOFC != null)
				LBGNKOJFOFC(info.ICKGJODOCBB);
			info.ICKGJODOCBB.KMABBBKJFCB = 1.0;
			info.ICKGJODOCBB.IKBKLPNADJM = false;
			info.ICKGJODOCBB.NEDNDAKLBMJ = true;
			installer.Stop();
			KJIGCCPJBFK.RemoveAt(index);
			GBFHGDHNDIE.Enqueue(installer);
			info.IOKJFDPOEFP = installer.GetStatusInfo();
			info.ICKGJODOCBB = null;
		}
		return 0;
	}

	// // RVA: 0x1C380F0 Offset: 0x1C380F0 VA: 0x1C380F0
	public bool MNFGKBAEFFL()
	{
		for(int i = 0; i < KJIGCCPJBFK.Count; i++)
		{
			JEHIAIPJNJF.AFGDFAJEBFA info = PLDKOCEHDAL[KJIGCCPJBFK[i]];
			info.IOKJFDPOEFP = KJIGCCPJBFK[i].GetStatusInfo();
			if(GCKDIGMAMND <= info.LBNOBJFOKMI)
				return true;
		}
		return false;
	}

	// // RVA: 0x1C37140 Offset: 0x1C37140 VA: 0x1C37140
	private void DLHJNILCAGE(JEHIAIPJNJF.AFGDFAJEBFA PHKJOMLDNOB)
	{
		UnityEngine.Debug.LogError("TODO");
	}

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
	private void HNKPDKKIPOH()
	{
		while(true)
		{ 
			if(GBFHGDHNDIE.Count == 0)
				return;
			int num = IOBFPLEDMOL();
			if(num < 0 || KAMPHNKAHAB)
			{
				return;
			}
			CriFsWebInstaller installer = GBFHGDHNDIE.Dequeue();
			JEHIAIPJNJF.HCJPJKCIBDL info = JOJMBFBGMGN[num];
			JEHIAIPJNJF.AFGDFAJEBFA info2 = PLDKOCEHDAL[installer];
			string dirName = Path.GetDirectoryName(info.ADHHKEMDOIK);
			if(!Directory.Exists(dirName))
			{
				Directory.CreateDirectory(dirName);
			}
			if(File.Exists(info.ADHHKEMDOIK))
			{
				UnityEngine.Debug.Log("Delete File "+info.ADHHKEMDOIK);
				File.Delete(info.ADHHKEMDOIK);
			}
			installer.Copy(info.NFCMNIEHJML, info.ADHHKEMDOIK);
			info.KMABBBKJFCB = 0;
			info.NEDNDAKLBMJ = false;
			info.IKBKLPNADJM = true;
			KJIGCCPJBFK.Add(installer);
			info2.ICKGJODOCBB = info;
			info2.GGFGJEDLKNC = false;
			info2.IOKJFDPOEFP = installer.GetStatusInfo();
			info2.LBNOBJFOKMI = 0.0f;
		}
	}
}
