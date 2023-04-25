using UnityEngine;
using XeSys;
using System.Collections.Generic;
using System;

public class JDDGPJDKHNE
{
	private ILCCJNDFFOB OMLLGAKPMAN; // 0x8
	private KIJECNFNNDB_JsonWriter LAFGAPBDKML = new KIJECNFNNDB_JsonWriter(); // 0xC
	private NPAFCENJADP BBMBNCPEAHC_EventsToSend; // 0x10
	private NPAFCENJADP LAHBCJNDGCH; // 0x14
	private bool DGKBPJBILIK; // 0x18
	private bool NKKADKPDHIL; // 0x19
	private bool PJDLAMLLCPM; // 0x1A
	private bool NNOOHDDKILN; // 0x1B
	private int GKFKKIICFME_NumToSend; // 0x1C
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
	private List<GBAMMLEAIOF> DAOEKHGKJOD_EventToSendQueue = new List<GBAMMLEAIOF>(100); // 0x30
	private List<GBAMMLEAIOF> AKAFMAEJNBO = new List<GBAMMLEAIOF>(100); // 0x34
	public bool FCMCNIMEAEA; // 0x38
	public bool EGEPCEGMDOH; // 0x39
	private long ELFLFGCFPIP_LastSent; // 0x40
	private long MMLMIMLGPON; // 0x48
	public EDOHBJAPLPF_JsonData FBCJICEPLED; // 0x50

	public static JDDGPJDKHNE HHCJCDFCLOB { get; set; } // 0x0 LGMPACEDIJF NKACBOEHELJ 0x1C30854 OKPMHKNCNAL 0x1C308B8

	// // RVA: 0x1C3091C Offset: 0x1C3091C VA: 0x1C3091C
	public void CDIFNFCHDCC()
	{
		EGEPCEGMDOH = true;
		FBCJICEPLED.Clear();
	}

	// // RVA: 0x1C30950 Offset: 0x1C30950 VA: 0x1C30950
	public void FECGDGCNGGN()
	{
		EGEPCEGMDOH = false;
	}

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
		EDOHBJAPLPF_JsonData data = new EDOHBJAPLPF_JsonData();
		data["id"] = KAPMOPMDHJE;
		data["b"] = JIBNPJCIALH;
		FBCJICEPLED.Add(data);
	}

	// // RVA: 0x1C30B70 Offset: 0x1C30B70 VA: 0x1C30B70
	public void IJBGPAENLJA()
    {
		HHCJCDFCLOB = this;
		OMLLGAKPMAN = new ILCCJNDFFOB();
		OMLLGAKPMAN.IJBGPAENLJA();
		UnityEngine.Debug.Log("load hadoopSaveFile");
		BBMBNCPEAHC_EventsToSend = new NPAFCENJADP();
		BBMBNCPEAHC_EventsToSend.KHEKNNFCAOI_Init(MKKOKHPMCHB());
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
	public void OJIDPFKENDG(EDOHBJAPLPF_JsonData HKICMNAACDA)
	{
		for(int i = 0; i < HKICMNAACDA.HNBFOAJIIAL_Count; i++)
		{
			CLHLFPDNFNM((int)HKICMNAACDA[i]["id"], HKICMNAACDA[i]["b"], HKICMNAACDA.HNBFOAJIIAL_Count - 1 == HKICMNAACDA.HNBFOAJIIAL_Count/*?? bug*/);
		}
	}

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
				DAOEKHGKJOD_EventToSendQueue.Add(a);
				return;
			}
			NFNLGGHMEAM();
			BBMBNCPEAHC_EventsToSend.MGJKEJHEBPO_Event.Add(a);
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
		if(DAOEKHGKJOD_EventToSendQueue.Count > 0)
		{
			for(int i = 0; i < DAOEKHGKJOD_EventToSendQueue.Count; i++)
			{
				BBMBNCPEAHC_EventsToSend.MGJKEJHEBPO_Event.Add(DAOEKHGKJOD_EventToSendQueue[i]);
			}
			DAOEKHGKJOD_EventToSendQueue.Clear();
			PJDLAMLLCPM = true;
		}
	}

	// // RVA: 0x1C32174 Offset: 0x1C32174 VA: 0x1C32174
	public void FOKEGEOKGDG()
	{
		TodoLogger.Log(0, "FOKEGEOKGDG");
	}

	// // RVA: 0x1C3142C Offset: 0x1C3142C VA: 0x1C3142C
	public void BLKLMNNOMGH()
	{
		if(NKGJPJPHLIF.HHCJCDFCLOB.IBLPICFDGOF_ServerRequester.CMCKNKKCNDK_Status != /*1*/PJKLMCGEJMK.AHADNLCOPOL.HIHKPNBDNJC_Running)
		{
			if(!BBMBNCPEAHC_EventsToSend.LNHFLJBGGJB)
			{
				if(!FCMCNIMEAEA && DAOEKHGKJOD_EventToSendQueue.Count > 0)
				{
					for(int i = 0; i < DAOEKHGKJOD_EventToSendQueue.Count; i++)
					{
						BBMBNCPEAHC_EventsToSend.MGJKEJHEBPO_Event.Add(DAOEKHGKJOD_EventToSendQueue[i]);
					}
					DAOEKHGKJOD_EventToSendQueue.Clear();
					PJDLAMLLCPM = true;
				}
				if(PJDLAMLLCPM)
				{
					BBMBNCPEAHC_EventsToSend.HJMKBCFJOOH();
					PJDLAMLLCPM = false;
				}
				if(BBMBNCPEAHC_EventsToSend.MGJKEJHEBPO_Event.Count != 0)
				{
					if(NKGJPJPHLIF.HHCJCDFCLOB.CGMMHFHHLID)
					{
						if(!DGKBPJBILIK)
						{
							PIBMLNOFHHG = PIBMLNOFHHG + 1;
							if(PIBMLNOFHHG < 30)
								return;
							if(Utility.GetCurrentUnixTime() - ELFLFGCFPIP_LastSent < 3)
							{
								return;
							}
						}
						if(AHIEGJNDNJP == null)
						{
							PIBMLNOFHHG = 0;
							GKFKKIICFME_NumToSend = 10;
							if(BBMBNCPEAHC_EventsToSend.MGJKEJHEBPO_Event.Count < 30)
							{
								GKFKKIICFME_NumToSend = BBMBNCPEAHC_EventsToSend.MGJKEJHEBPO_Event.Count;
							}
							SakashoHadoopLogData[] datas = new SakashoHadoopLogData[GKFKKIICFME_NumToSend];
							for(int i = 0; i < GKFKKIICFME_NumToSend; i++)
							{
								datas[i] = new SakashoHadoopLogData();
								datas[i].EventId = OAGBCBBHMPF.IEPAJNPLHJI_EventId[BBMBNCPEAHC_EventsToSend.MGJKEJHEBPO_Event[i].PGEDKFOIPIP_EventIdx];
								datas[i].JsonData = BBMBNCPEAHC_EventsToSend.MGJKEJHEBPO_Event[i].HGJLBEBNMIP_LogData();
							}
							AHIEGJNDNJP = SakashoHadoopLog.SendLogToHadoop(datas, ODPBHFNKEIE_OnLogSuccess, MGGMIOBICLP_OnLogFail);
						}
					}
				}
			}
		}
	}

	// // RVA: 0x1C32220 Offset: 0x1C32220 VA: 0x1C32220
	private void ODPBHFNKEIE_OnLogSuccess(string IDLHJIOMJBK)
	{
		BBMBNCPEAHC_EventsToSend.KLLOMGPHGLL_RemoveEvents(GKFKKIICFME_NumToSend);
		PJDLAMLLCPM = true;
		if(LAHBCJNDGCH.MGJKEJHEBPO_Event.Count == 0)
		{
			DGKBPJBILIK = false;
		}
		AHIEGJNDNJP = null;
		GKFKKIICFME_NumToSend = 0;
		ELFLFGCFPIP_LastSent = Utility.GetCurrentUnixTime();
	}

	// // RVA: 0x1C3232C Offset: 0x1C3232C VA: 0x1C3232C
	private void MGGMIOBICLP_OnLogFail(SakashoError DOGDHKIEBJA)
	{
		TodoLogger.Log(TodoLogger.Errors, "JDDGPJDKHNE.MGGMIOBICLP_OnLogFail");
	}

	// // RVA: 0x1C30E40 Offset: 0x1C30E40 VA: 0x1C30E40
	public void BJIOOOJGEPC()
	{
		if(NKGJPJPHLIF.HHCJCDFCLOB.IBLPICFDGOF_ServerRequester.CMCKNKKCNDK_Status != PJKLMCGEJMK.AHADNLCOPOL.HIHKPNBDNJC_Running)
		{
			if(!LAHBCJNDGCH.LNHFLJBGGJB)
			{
				if(NNOOHDDKILN)
				{
					LAHBCJNDGCH.HJMKBCFJOOH();
					NNOOHDDKILN = false;
				}
				if(LAHBCJNDGCH.MGJKEJHEBPO_Event.Count != 0)
				{
					if(NKGJPJPHLIF.HHCJCDFCLOB.CGMMHFHHLID)
					{
						if(!NKKADKPDHIL)
						{
							if(Utility.GetCurrentUnixTime() - MMLMIMLGPON < 21)
							{
								return;
							}
						}
						if(AHIEGJNDNJP == null)
						{
							KCOKHCLKFIE = 10;
							if(LAHBCJNDGCH.MGJKEJHEBPO_Event.Count < 10)
							{
								KCOKHCLKFIE = LAHBCJNDGCH.MGJKEJHEBPO_Event.Count;
							}
							SakashoLogData[] datas = new SakashoLogData[KCOKHCLKFIE];
							for(int i = 0; i < KCOKHCLKFIE; i++)
							{
								datas[i] = new SakashoLogData();
								datas[i].Label = OAGBCBBHMPF.IEPAJNPLHJI_EventId[LAHBCJNDGCH.MGJKEJHEBPO_Event[i].PGEDKFOIPIP_EventIdx];
								datas[i].JsonData = LAHBCJNDGCH.MGJKEJHEBPO_Event[i].HGJLBEBNMIP_LogData();
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
		TodoLogger.Log(0, "TODO");
	}

	// // RVA: 0x1C32568 Offset: 0x1C32568 VA: 0x1C32568
	private void HNDCPCFHKDB(SakashoError DOGDHKIEBJA)
	{
		TodoLogger.Log(0, "TODO");
	}

	// // RVA: 0x1C326D4 Offset: 0x1C326D4 VA: 0x1C326D4
	public long KPKAKIIAFFB_GetNextRequestId()
	{
		BBMBNCPEAHC_EventsToSend.JCNNBEEHFLE = BBMBNCPEAHC_EventsToSend.JCNNBEEHFLE + 1;
		return BBMBNCPEAHC_EventsToSend.JCNNBEEHFLE;
	}

	// // RVA: 0x1C32724 Offset: 0x1C32724 VA: 0x1C32724
	// public long FNBFIIOCJNF() { }

	// // RVA: 0x1C32774 Offset: 0x1C32774 VA: 0x1C32774
	public static string GPLMOKEIOLE()
	{
		int gameId = 0;
		byte[] bt = new byte[8];
		int.TryParse(NKGJPJPHLIF.HHCJCDFCLOB.MLKOPOKGHHH_SakashoGameId, out gameId);
		long time = NKGJPJPHLIF.HHCJCDFCLOB.IBLPICFDGOF_ServerRequester.FJDBNGEPKHL.KMEFBNBFJHI_GetServerTime();
		int playerId = NKGJPJPHLIF.HHCJCDFCLOB.MDAMJIGBOLD_PlayerId;
		byte[] btTime = BitConverter.GetBytes((int)time);
		bt[0] = btTime[0];
		bt[3] = btTime[1];
		bt[6] = btTime[2];
		bt[7] = btTime[3];
		byte[] btPlayer = BitConverter.GetBytes((int)playerId);
		bt[1] = btPlayer[0];
		bt[5] = btPlayer[1];
		bt[2] = btPlayer[2];
		bt[4] = btPlayer[3];
		return Convert.ToBase64String(bt);
	}
}
