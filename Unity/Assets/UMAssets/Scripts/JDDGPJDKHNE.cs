using UnityEngine;
using XeSys;
using System.Collections.Generic;

public class JDDGPJDKHNE
{
	private ILCCJNDFFOB OMLLGAKPMAN; // 0x8
	private KIJECNFNNDB_JsonWriter LAFGAPBDKML = new KIJECNFNNDB_JsonWriter(); // 0xC
	private NPAFCENJADP BBMBNCPEAHC; // 0x10
	private NPAFCENJADP LAHBCJNDGCH; // 0x14
	private bool DGKBPJBILIK; // 0x18
	private bool NKKADKPDHIL; // 0x19
	private bool PJDLAMLLCPM; // 0x1A
	private bool NNOOHDDKILN; // 0x1B
	private int GKFKKIICFME; // 0x1C
	private int KCOKHCLKFIE; // 0x20
	private int PIBMLNOFHHG; // 0x24
	private const int IFHONOONALP = 10;
	private const int ECDJLLMIMME = 64000;
	private const int CCPNJHKEAFE = 30;
	private const int LOKMGIBCFGJ = 2;
	private const int FICEFALKDCK = 180;
	private const int HOPFNIPEDKC = 10;
	private const int KOCBJPOBAGB = 65535;
	private const int HEHBMFJIKAE = 20;
	private const int NNPPLEFJDLB = 180;
	private SakashoAPICallContext AHIEGJNDNJP; // 0x28
	private SakashoAPICallContext DIGJPMJHNHG; // 0x2C
	private List<GBAMMLEAIOF> DAOEKHGKJOD = new List<GBAMMLEAIOF>(100); // 0x30
	private List<GBAMMLEAIOF> AKAFMAEJNBO = new List<GBAMMLEAIOF>(100); // 0x34
	public bool FCMCNIMEAEA; // 0x38
	public bool EGEPCEGMDOH; // 0x39
	private long ELFLFGCFPIP; // 0x40
	private long MMLMIMLGPON; // 0x48
	public EDOHBJAPLPF_JsonData FBCJICEPLED; // 0x50

	public static JDDGPJDKHNE HHCJCDFCLOB { get; set; } // 0x0 LGMPACEDIJF NKACBOEHELJ 0x1C30854 OKPMHKNCNAL 0x1C308B8

	// // RVA: 0x1C3091C Offset: 0x1C3091C VA: 0x1C3091C
	// public void CDIFNFCHDCC() { }

	// // RVA: 0x1C30950 Offset: 0x1C30950 VA: 0x1C30950
	// public void FECGDGCNGGN() { }

	// // RVA: 0x1C3095C Offset: 0x1C3095C VA: 0x1C3095C
	private string MKKOKHPMCHB()
	{
		return Application.persistentDataPath + "/40/001";
	}

	// // RVA: 0x1C309C4 Offset: 0x1C309C4 VA: 0x1C309C4
	private string AOJAEBGJMGJ()
	{
		return Application.persistentDataPath + "/40/002";
	}

	// // RVA: 0x1C30A2C Offset: 0x1C30A2C VA: 0x1C30A2C
	public void LGCNNIKLFFN(int KAPMOPMDHJE, EDOHBJAPLPF_JsonData JIBNPJCIALH)
	{
		UnityEngine.Debug.LogError("TODO");
	}

	// // RVA: 0x1C30B70 Offset: 0x1C30B70 VA: 0x1C30B70
	public void IJBGPAENLJA()
    {
		HHCJCDFCLOB = this;
		OMLLGAKPMAN = new ILCCJNDFFOB();
		OMLLGAKPMAN.IJBGPAENLJA();
		UnityEngine.Debug.Log("load hadoopSaveFile");
		BBMBNCPEAHC = new NPAFCENJADP();
		BBMBNCPEAHC.KHEKNNFCAOI_Init(MKKOKHPMCHB());
		UnityEngine.Debug.Log("load secureSaveFile");
		LAHBCJNDGCH = new NPAFCENJADP();
		LAHBCJNDGCH.KHEKNNFCAOI_Init(AOJAEBGJMGJ());
		FBCJICEPLED = new EDOHBJAPLPF_JsonData();
		FBCJICEPLED.LAJDIPCJCPO_SetJsonType(/*2*/JFBMDLGBPEN_JsonType.BDHGEFMCJDF_Array);
    }

	// // RVA: 0x1C30D88 Offset: 0x1C30D88 VA: 0x1C30D88
	public void BAGMHFKPFIF()
    {
		if(!NKGJPJPHLIF.HHCJCDFCLOB.CGMMHFHHLID)
			return;
		BJIOOOJGEPC();
		BLKLMNNOMGH();
    }

	// // RVA: 0x1C31B64 Offset: 0x1C31B64 VA: 0x1C31B64
	// public void OJIDPFKENDG(EDOHBJAPLPF_JsonData HKICMNAACDA) { }

	// // RVA: 0x1C31D24 Offset: 0x1C31D24 VA: 0x1C31D24
	public void CLHLFPDNFNM(int KAPMOPMDHJE, EDOHBJAPLPF_JsonData JIBNPJCIALH, bool FOIGCFNFPOB)
	{
		if(EGEPCEGMDOH)
		{
			LGCNNIKLFFN(KAPMOPMDHJE,JIBNPJCIALH);
			return;
		}
		GBAMMLEAIOF a = new GBAMMLEAIOF();
		a.KHEKNNFCAOI_Init(KAPMOPMDHJE,JIBNPJCIALH, LAFGAPBDKML);
		if(a.EJJEHEHFMGO.Length < 64001)
		{
			if(!FOIGCFNFPOB)
			{
				DAOEKHGKJOD.Add(a);
				return;
			}
			NFNLGGHMEAM();
			BBMBNCPEAHC.MGJKEJHEBPO.Add(a);
			DGKBPJBILIK = true;
			PJDLAMLLCPM = true;
		}
	}

	// // RVA: 0x1C32048 Offset: 0x1C32048 VA: 0x1C32048
	// public void KIPIMGCGLJG(int KAPMOPMDHJE, EDOHBJAPLPF_JsonData JIBNPJCIALH, bool FOIGCFNFPOB) { }

	// // RVA: 0x1C32148 Offset: 0x1C32148 VA: 0x1C32148
	// public void BGDOBGFECOB() { }

	// // RVA: 0x1C31ED4 Offset: 0x1C31ED4 VA: 0x1C31ED4
	public void NFNLGGHMEAM()
	{
		UnityEngine.Debug.LogError("TODO");
	}

	// // RVA: 0x1C32174 Offset: 0x1C32174 VA: 0x1C32174
	// public void FOKEGEOKGDG() { }

	// // RVA: 0x1C3142C Offset: 0x1C3142C VA: 0x1C3142C
	public void BLKLMNNOMGH()
	{
		if(NKGJPJPHLIF.HHCJCDFCLOB.IBLPICFDGOF.CMCKNKKCNDK_Status != /*1*/PJKLMCGEJMK.AHADNLCOPOL.HIHKPNBDNJC_Running)
		{
			if(!BBMBNCPEAHC.LNHFLJBGGJB)
			{
				if(!FCMCNIMEAEA && DAOEKHGKJOD.Count > 0)
				{
					for(int i = 0; i < DAOEKHGKJOD.Count; i++)
					{
						BBMBNCPEAHC.MGJKEJHEBPO.Add(DAOEKHGKJOD[i]);
					}
					DAOEKHGKJOD.Clear();
					PJDLAMLLCPM = true;
				}
				if(PJDLAMLLCPM)
				{
					BBMBNCPEAHC.HJMKBCFJOOH();
					PJDLAMLLCPM = false;
				}
				if(BBMBNCPEAHC.MGJKEJHEBPO.Count != 0)
				{
					if(NKGJPJPHLIF.HHCJCDFCLOB.CGMMHFHHLID)
					{
						if(!DGKBPJBILIK)
						{
							PIBMLNOFHHG = PIBMLNOFHHG + 1;
							if(PIBMLNOFHHG < 30)
								return;
							UnityEngine.Debug.LogWarning("Check test");
							if(Utility.GetCurrentUnixTime() - ELFLFGCFPIP < 3)
							{
								return;
							}
						}
						if(AHIEGJNDNJP == null)
						{
							PIBMLNOFHHG = 0;
							GKFKKIICFME = 10;
							if(BBMBNCPEAHC.MGJKEJHEBPO.Count < 30)
							{
								GKFKKIICFME = BBMBNCPEAHC.MGJKEJHEBPO.Count;
							}
							SakashoHadoopLogData[] datas = new SakashoHadoopLogData[GKFKKIICFME];
							for(int i = 0; i < GKFKKIICFME; i++)
							{
								datas[i] = new SakashoHadoopLogData();
								datas[i].EventId = OAGBCBBHMPF.IEPAJNPLHJI[BBMBNCPEAHC.MGJKEJHEBPO[i].PGEDKFOIPIP];
								datas[i].JsonData = BBMBNCPEAHC.MGJKEJHEBPO[i].HGJLBEBNMIP();
							}
							AHIEGJNDNJP = SakashoHadoopLog.SendLogToHadoop(datas, this.ODPBHFNKEIE, this.MGGMIOBICLP);
						}
					}
				}
			}
		}
	}

	// // RVA: 0x1C32220 Offset: 0x1C32220 VA: 0x1C32220
	private void ODPBHFNKEIE(string IDLHJIOMJBK)
	{
		UnityEngine.Debug.LogError("TODO");
	}

	// // RVA: 0x1C3232C Offset: 0x1C3232C VA: 0x1C3232C
	private void MGGMIOBICLP(SakashoError DOGDHKIEBJA)
	{
		UnityEngine.Debug.LogError("TODO");
	}

	// // RVA: 0x1C30E40 Offset: 0x1C30E40 VA: 0x1C30E40
	public void BJIOOOJGEPC()
	{
		if(NKGJPJPHLIF.HHCJCDFCLOB.IBLPICFDGOF.CMCKNKKCNDK_Status != PJKLMCGEJMK.AHADNLCOPOL.HIHKPNBDNJC_Running)
		{
			if(!LAHBCJNDGCH.LNHFLJBGGJB)
			{
				if(NNOOHDDKILN)
				{
					LAHBCJNDGCH.HJMKBCFJOOH();
					NNOOHDDKILN = false;
				}
				if(LAHBCJNDGCH.MGJKEJHEBPO.Count != 0)
				{
					if(NKGJPJPHLIF.HHCJCDFCLOB.CGMMHFHHLID)
					{
						if(!NKKADKPDHIL)
						{
							if(Utility.GetCurrentUnixTime() - MMLMIMLGPON < 3)
							{
								return;
							}
						}
						if(AHIEGJNDNJP == null)
						{
							KCOKHCLKFIE = 10;
							if(LAHBCJNDGCH.MGJKEJHEBPO.Count < 10)
							{
								KCOKHCLKFIE = LAHBCJNDGCH.MGJKEJHEBPO.Count;
							}
							SakashoLogData[] datas = new SakashoLogData[KCOKHCLKFIE];
							for(int i = 0; i < KCOKHCLKFIE; i++)
							{
								datas[i] = new SakashoLogData();
								datas[i].Label = OAGBCBBHMPF.IEPAJNPLHJI[LAHBCJNDGCH.MGJKEJHEBPO[i].PGEDKFOIPIP];
								datas[i].JsonData = LAHBCJNDGCH.MGJKEJHEBPO[i].HGJLBEBNMIP();
							}
							DIGJPMJHNHG = SakashoLog.SendLog(datas, this.JGECIJGPMCB, this.HNDCPCFHKDB);
						}
					}
				}
			}
		}
	}

	// // RVA: 0x1C32458 Offset: 0x1C32458 VA: 0x1C32458
	private void JGECIJGPMCB(string IDLHJIOMJBK)
	{
		UnityEngine.Debug.LogError("TODO");
	}

	// // RVA: 0x1C32568 Offset: 0x1C32568 VA: 0x1C32568
	private void HNDCPCFHKDB(SakashoError DOGDHKIEBJA)
	{
		UnityEngine.Debug.LogError("TODO");
	}

	// // RVA: 0x1C326D4 Offset: 0x1C326D4 VA: 0x1C326D4
	public long KPKAKIIAFFB()
	{
		UnityEngine.Debug.LogWarning("Check");
		BBMBNCPEAHC.JCNNBEEHFLE = BBMBNCPEAHC.JCNNBEEHFLE + 1;
		return BBMBNCPEAHC.JCNNBEEHFLE;
	}

	// // RVA: 0x1C32724 Offset: 0x1C32724 VA: 0x1C32724
	// public long FNBFIIOCJNF() { }

	// // RVA: 0x1C32774 Offset: 0x1C32774 VA: 0x1C32774
	// public static string GPLMOKEIOLE() { }
}
