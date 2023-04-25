using XeSys;
using System.Collections.Generic;
using System.Collections;
using System.Collections;
using System;
using System.Text;

public class PBJPACKDIIB : Singleton<PBJPACKDIIB>, IDisposable
{
    public class IFCOFHAFMON
    {
        public int EKANGPODCEP_EId; // 0x8
        public int CMEJFJFOIIJ_QId; // 0xC
        public int AIBFGKBACCB_LId; // 0x10
        public long FKPEAGGKNLC_Start; // 0x18
        public long KOMKKBDABJP_End; // 0x20
        public bool CGHNCPEKOCK_Dai; // 0x28
    }

    public class JBJMNJMJFOJ
    {
        public int CMEJFJFOIIJ; // 0x8
        public int HMFFHLPNMPH; // 0xC
    }
    
	private List<IFCOFHAFMON> EKFEHIHJHEN = new List<IFCOFHAFMON>(16); // 0x8

	// // RVA: 0xCBC134 Offset: 0xCBC134 VA: 0xCBC134
	public static List<IFCOFHAFMON> JAFKPMFPICA()
	{
		if(Instance != null)
		{
			return Instance.EKFEHIHJHEN;
		}
		return null;
	}

	// // RVA: 0xCBC1CC Offset: 0xCBC1CC VA: 0xCBC1CC
	// public void KPOJEAFIGOB() { }

	// // RVA: 0xCBC244 Offset: 0xCBC244 VA: 0xCBC244
	// public void CGJLFIGBHCG(PBJPACKDIIB.IFCOFHAFMON AOGFMNFOBNP) { }

	// // RVA: 0xCBC2C4 Offset: 0xCBC2C4 VA: 0xCBC2C4
	public void KNPBADBCOLO_Send(IMCBBOAFION BHFHGFKBOHH, DJBHIFLHJLK MOBEEPPKFLG)
	{
		N.a.StartCoroutineWatched(MCHIFJFALGL_Coroutine_Send(BHFHGFKBOHH, MOBEEPPKFLG));
	}

	// [IteratorStateMachineAttribute] // RVA: 0x6BA674 Offset: 0x6BA674 VA: 0x6BA674
	// // RVA: 0xCBC31C Offset: 0xCBC31C VA: 0xCBC31C
	private IEnumerator MCHIFJFALGL_Coroutine_Send(IMCBBOAFION BHFHGFKBOHH, DJBHIFLHJLK MOBEEPPKFLG)
	{
		StringBuilder ABMADBCLLHH;
		int GGJDKPHBCFC;

		//0xCBCC34
		ABMADBCLLHH = new StringBuilder(64);
		for(GGJDKPHBCFC = 0; GGJDKPHBCFC < EKFEHIHJHEN.Count; GGJDKPHBCFC++)
		{
			IFCOFHAFMON d = EKFEHIHJHEN[GGJDKPHBCFC];
			BNJJHPEGNAI.HCAJEKFFNBM data = new BNJJHPEGNAI.HCAJEKFFNBM();
			if(!d.CGHNCPEKOCK_Dai)
			{
				data.EMGJJFKONHK_ExpireDays = TimeSpan.FromSeconds(d.KOMKKBDABJP_End - d.FKPEAGGKNLC_Start).Days + 1;
				AHAENNIFOAF.DNEIBFNPNIA(ABMADBCLLHH, d.EKANGPODCEP_EId, d.AIBFGKBACCB_LId);
			}
			else
			{
				data.EMGJJFKONHK_ExpireDays = 1;
				DateTime date = Utility.GetLocalDateTime(d.FKPEAGGKNLC_Start);
				AHAENNIFOAF.OIEHNLEPEBG(ABMADBCLLHH, d.EKANGPODCEP_EId, d.AIBFGKBACCB_LId, date.Month, date.Day);
			}
			data.KGICDMIJGDF = ABMADBCLLHH.ToString();
			AHAENNIFOAF.JHJAMPNMCFA(ABMADBCLLHH, d.CMEJFJFOIIJ_QId);
			data.ADCMNODJBGJ_Title = ABMADBCLLHH.ToString();
			KEPNMGHABPI k = KEPNMGHABPI.OGIFFNLIDIO.GOAMILGNJIE(data);
			SakashoBbsCommentInfo info = new SakashoBbsCommentInfo();
			info.Nickname = "dummy";
			info.Content = "dummy";
			bool PLOOEECNHFB = false;
			bool NPNNPNAIONN = false;
			k.IFFGEIMIKHH(0, info, () =>
			{
				//0xCBC894
				PLOOEECNHFB = true;
			}, () =>
			{
				//0xCBC8A0
				NPNNPNAIONN = true;
			}, () =>
			{
				//0xCBC8AC
				NPNNPNAIONN = true;
			});
			//LAB_00cbd1fc
			while(!NPNNPNAIONN || !PLOOEECNHFB)
			{
				yield return null;
			}
			if(NPNNPNAIONN)
			{
				MOBEEPPKFLG();
				yield break;
			}
		}
		EKFEHIHJHEN.Clear();
		BHFHGFKBOHH();
	}

	// // RVA: 0xCBC3FC Offset: 0xCBC3FC VA: 0xCBC3FC
	public static void NPIJAIOCACL(IMCBBOAFION BHFHGFKBOHH, DJBHIFLHJLK MOBEEPPKFLG)
	{
		if(PBJPACKDIIB.Instance != null)
		{
			PBJPACKDIIB.Instance.KNPBADBCOLO_Send(BHFHGFKBOHH, MOBEEPPKFLG);
		}
		else
		{
			BHFHGFKBOHH();
		}
	}

	// // RVA: 0xCBC4C0 Offset: 0xCBC4C0 VA: 0xCBC4C0
	// public void HPFJOBPMNCP(int EKANGPODCEP, int AIBFGKBACCB, bool CGHNCPEKOCK, long LKCCMBEOLLA, Action<List<PBJPACKDIIB.JBJMNJMJFOJ>> BHFHGFKBOHH, DJBHIFLHJLK MOBEEPPKFLG) { }

	// // RVA: 0xCBC7EC Offset: 0xCBC7EC VA: 0xCBC7EC Slot: 4
	public void Dispose()
    {
        TodoLogger.Log(0, "TODO");
    }
}
