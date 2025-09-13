using XeSys;
using System.Collections.Generic;
using System.Collections;
using System;
using System.Text;

public class PBJPACKDIIB : Singleton<PBJPACKDIIB>, IDisposable
{
    public class IFCOFHAFMON
    {
        public int EKANGPODCEP_EventId; // 0x8
        public int CMEJFJFOIIJ_QuestId; // 0xC
        public int AIBFGKBACCB_LobbyId; // 0x10
        public long FKPEAGGKNLC_Start; // 0x18
        public long KOMKKBDABJP_End; // 0x20
        public bool CGHNCPEKOCK_IsDaily; // 0x28
    }

    public class JBJMNJMJFOJ
    {
        public int CMEJFJFOIIJ_QuestId; // 0x8
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
	public void KPOJEAFIGOB()
	{
		EKFEHIHJHEN.Clear();
	}

	// // RVA: 0xCBC244 Offset: 0xCBC244 VA: 0xCBC244
	public void CGJLFIGBHCG(IFCOFHAFMON AOGFMNFOBNP)
	{
		EKFEHIHJHEN.Add(AOGFMNFOBNP);
	}

	// // RVA: 0xCBC2C4 Offset: 0xCBC2C4 VA: 0xCBC2C4
	public void KNPBADBCOLO_Send(IMCBBOAFION _BHFHGFKBOHH_OnSuccess, DJBHIFLHJLK MOBEEPPKFLG)
	{
		N.a.StartCoroutineWatched(MCHIFJFALGL_Coroutine_Send(_BHFHGFKBOHH_OnSuccess, MOBEEPPKFLG));
	}

	// [IteratorStateMachineAttribute] // RVA: 0x6BA674 Offset: 0x6BA674 VA: 0x6BA674
	// // RVA: 0xCBC31C Offset: 0xCBC31C VA: 0xCBC31C
	private IEnumerator MCHIFJFALGL_Coroutine_Send(IMCBBOAFION _BHFHGFKBOHH_OnSuccess, DJBHIFLHJLK MOBEEPPKFLG)
	{
		StringBuilder ABMADBCLLHH;
		int GGJDKPHBCFC;

		//0xCBCC34
		ABMADBCLLHH = new StringBuilder(64);
		for(GGJDKPHBCFC = 0; GGJDKPHBCFC < EKFEHIHJHEN.Count; GGJDKPHBCFC++)
		{
			IFCOFHAFMON d = EKFEHIHJHEN[GGJDKPHBCFC];
			BNJJHPEGNAI.HCAJEKFFNBM data = new BNJJHPEGNAI.HCAJEKFFNBM();
			if(!d.CGHNCPEKOCK_IsDaily || RuntimeSettings.CurrentSettings.UnlimitedEvent)
			{
				data.EMGJJFKONHK_ExpireDays = TimeSpan.FromSeconds(d.KOMKKBDABJP_End - d.FKPEAGGKNLC_Start).Days + 1;
				AHAENNIFOAF.DNEIBFNPNIA(ABMADBCLLHH, d.EKANGPODCEP_EventId, d.AIBFGKBACCB_LobbyId);
			}
			else
			{
				data.EMGJJFKONHK_ExpireDays = 1;
				DateTime date = Utility.GetLocalDateTime(d.FKPEAGGKNLC_Start);
				AHAENNIFOAF.OIEHNLEPEBG(ABMADBCLLHH, d.EKANGPODCEP_EventId, d.AIBFGKBACCB_LobbyId, date.Month, date.Day);
			}
			data.KGICDMIJGDF = ABMADBCLLHH.ToString();
			AHAENNIFOAF.JHJAMPNMCFA(ABMADBCLLHH, d.CMEJFJFOIIJ_QuestId);
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
			while(!NPNNPNAIONN && !PLOOEECNHFB)
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
		_BHFHGFKBOHH_OnSuccess();
	}

	// // RVA: 0xCBC3FC Offset: 0xCBC3FC VA: 0xCBC3FC
	public static void NPIJAIOCACL(IMCBBOAFION _BHFHGFKBOHH_OnSuccess, DJBHIFLHJLK MOBEEPPKFLG)
	{
		if(PBJPACKDIIB.Instance != null)
		{
			PBJPACKDIIB.Instance.KNPBADBCOLO_Send(_BHFHGFKBOHH_OnSuccess, MOBEEPPKFLG);
		}
		else
		{
			_BHFHGFKBOHH_OnSuccess();
		}
	}

	// // RVA: 0xCBC4C0 Offset: 0xCBC4C0 VA: 0xCBC4C0
	public void HPFJOBPMNCP(int _EKANGPODCEP_EventId, int _AIBFGKBACCB_LobbyId, bool _CGHNCPEKOCK_IsDaily, long LKCCMBEOLLA, Action<List<PBJPACKDIIB.JBJMNJMJFOJ>> _BHFHGFKBOHH_OnSuccess, DJBHIFLHJLK MOBEEPPKFLG)
	{
		StringBuilder str = new StringBuilder();
		BNJJHPEGNAI.HCAJEKFFNBM b = new BNJJHPEGNAI.HCAJEKFFNBM();
		if(!_CGHNCPEKOCK_IsDaily || RuntimeSettings.CurrentSettings.UnlimitedEvent)
		{
			AHAENNIFOAF.DNEIBFNPNIA(str, _EKANGPODCEP_EventId, _AIBFGKBACCB_LobbyId);
		}
		else
		{
            DateTime Date = Utility.GetLocalDateTime(LKCCMBEOLLA);
            AHAENNIFOAF.OIEHNLEPEBG(str, _EKANGPODCEP_EventId, _AIBFGKBACCB_LobbyId, Date.Month, Date.Day);
		}
		b.KGICDMIJGDF = str.ToString();
		List<JBJMNJMJFOJ> ONIOKEOLKNK = new List<JBJMNJMJFOJ>(16);
		KEPNMGHABPI.OGIFFNLIDIO.GOAMILGNJIE(b).FNKJBKJIKPC(0, (List<KEPNMGHABPI.LNCLNAOPNKF> LGGCIHBGJJN) =>
		{
			//0xCBC8B8
			for(int i = 0; i < LGGCIHBGJJN.Count; i++)
			{
				int NIIAFJMLOED = 0;
				if(int.TryParse(LGGCIHBGJJN[i].ECAIHFNAAOM_Title, out NIIAFJMLOED))
				{
					JBJMNJMJFOJ m = ONIOKEOLKNK.Find((JBJMNJMJFOJ AOIKKLBKEBC) =>
					{
						//0xCBCBF8
						return AOIKKLBKEBC.CMEJFJFOIIJ_QuestId == NIIAFJMLOED;
					});
					if(m == null)
					{
						m = new JBJMNJMJFOJ();
						m.CMEJFJFOIIJ_QuestId = NIIAFJMLOED;
						m.HMFFHLPNMPH = LGGCIHBGJJN[i].CCBEKGNDDBE.MEBNLFANDLC_CurrentCommentsCount;
						ONIOKEOLKNK.Add(m);
					}
					else
					{
						m.HMFFHLPNMPH += LGGCIHBGJJN[i].CCBEKGNDDBE.MEBNLFANDLC_CurrentCommentsCount;
					}
				}
			}
			_BHFHGFKBOHH_OnSuccess(ONIOKEOLKNK);
		}, MOBEEPPKFLG, true);
	}

	// // RVA: 0xCBC7EC Offset: 0xCBC7EC VA: 0xCBC7EC Slot: 4
	public void Dispose()
    {
        return;
    }
}
