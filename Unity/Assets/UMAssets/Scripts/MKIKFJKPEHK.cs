
using System.Collections.Generic;

public class MKIKFJKPEHK
{
	public enum IMIDFBNGHCG
	{
		DCFJEBLEELJ_0 = 0,
		CNAMHABEOPF_1 = 1,
		FKLMPGJPDLL_2 = 2,
		JCOBDONNJIP_3 = 3,
	}

	public bool NMKDLINPAFM_UseTicket; // 0x8
	public List<int> BGIKOPLLDJB_Rate; // 0xC
	public List<int> KLOOIJIDKGO_Cost; // 0x10

	// // RVA: 0x1959A70 Offset: 0x1959A70 VA: 0x1959A70
	public bool DPICLLJJPAC(IBJAKJJICBC ENKGMPLGEIJ, int FCHBEILHFBC, bool GIKLNODJKFK)
	{
		if ((ENKGMPLGEIJ.MNNHHJBBICA_GameEventType > 0 && ENKGMPLGEIJ.MNNHHJBBICA_GameEventType < 4) || ENKGMPLGEIJ.MNNHHJBBICA_GameEventType == 6)
		{
            IKDICBBFBMI_EventBase ev = JEPBIIJDGEF_EventInfo.HHCJCDFCLOB.MKBJOOAILBB_GetEventByStatus(KGCNCBOKCBA.GNENJEHKMHD_EventStatus.EMAMLLFAOJI_Counting_6, false);
			if(ev != null)
			{
				if((int)ev.HIDHLFCBIDE_EventType == ENKGMPLGEIJ.MNNHHJBBICA_GameEventType)
				{
					long t = NKGJPJPHLIF.HHCJCDFCLOB.IBLPICFDGOF_ServerRequester.FJDBNGEPKHL.KMEFBNBFJHI_GetServerTime();
					if(t < ev.DPJCPDKALGI_End1 && ev.MBHDIJJEOFL != null)
					{
						int a1 = 1;
						if(ev.HIDHLFCBIDE_EventType == OHCAABOMEOF.KGOGMKMBCPP_EventType.AOPKACCDKPA_EventCollection)
						{
							a1 = 2;
							NMKDLINPAFM_UseTicket = true;
						}
						BGIKOPLLDJB_Rate = new List<int>();
						KLOOIJIDKGO_Cost = new List<int>();
						for(int i = 0; i < ev.MBHDIJJEOFL.Count; i++)
						{
							if(ev.MBHDIJJEOFL[i].INDDJNMPONH == a1)
							{
								if(ev.MBHDIJJEOFL[i].MAFAIIHJAFG <= (((int)ev.NGOFCFJHOMI_Status & 0xfffffffe) == 4 ? 1 : 0))
								{
									int a2;
									if(ev.MBHDIJJEOFL[i].INDDJNMPONH == 1)
									{
										a2 = ENKGMPLGEIJ.MGJKEJHEBPO_DiffInfos[FCHBEILHFBC].BPLOEAHOPFI_Energy;
									}
									else
									{
										a2 = ev.EAMODCHMCEL(FCHBEILHFBC, GIKLNODJKFK);
									}
									KLOOIJIDKGO_Cost.Add(ev.MBHDIJJEOFL[i].JBGEEPFKIGG * a2);
									BGIKOPLLDJB_Rate.Add(ev.MBHDIJJEOFL[i].JBGEEPFKIGG);
								}
							}
						}
						return BGIKOPLLDJB_Rate.Count != 0;
					}
				}
			}
		}
		else if(ENKGMPLGEIJ.MNNHHJBBICA_GameEventType == 0)
		{
			//ENKGMPLGEIJ.MFJKNCACBDG
		}
		return false;
	}

	// // RVA: 0x1959FB8 Offset: 0x1959FB8 VA: 0x1959FB8
	public IMIDFBNGHCG EFFBJDMGIGO(int OIACNLKAIFO)
	{
		IKDICBBFBMI_EventBase ev = JEPBIIJDGEF_EventInfo.HHCJCDFCLOB.MKBJOOAILBB_GetEventByStatus(KGCNCBOKCBA.GNENJEHKMHD_EventStatus.EMAMLLFAOJI_Counting_6/*6*/, false);
		if(ev != null)
		{
			long t = NKGJPJPHLIF.HHCJCDFCLOB.IBLPICFDGOF_ServerRequester.FJDBNGEPKHL.KMEFBNBFJHI_GetServerTime();
			if(t < ev.DPJCPDKALGI_End1)
			{
				if(!NMKDLINPAFM_UseTicket)
				{
					return CIOECGOMILE.HHCJCDFCLOB.BPLOEAHOPFI_StaminaUpdater.DCLKMNGMIKC_GetCurrent() < KLOOIJIDKGO_Cost[OIACNLKAIFO] ? IMIDFBNGHCG.CNAMHABEOPF_1 : IMIDFBNGHCG.DCFJEBLEELJ_0;
				}
				else
				{
					return ev.AELBIEDNPGB_GetTicketCount(null) < KLOOIJIDKGO_Cost[OIACNLKAIFO] ? IMIDFBNGHCG.FKLMPGJPDLL_2 : IMIDFBNGHCG.DCFJEBLEELJ_0;
				}
			}
		}
		return IMIDFBNGHCG.JCOBDONNJIP_3;
	}

	// // RVA: 0x195A240 Offset: 0x195A240 VA: 0x195A240
	public void PPCLCOPGBBK(int OIACNLKAIFO)
	{
        IKDICBBFBMI_EventBase ev = JEPBIIJDGEF_EventInfo.HHCJCDFCLOB.MKBJOOAILBB_GetEventByStatus(KGCNCBOKCBA.GNENJEHKMHD_EventStatus.EMAMLLFAOJI_Counting_6, false);
    	if(ev != null)
			return;
		ev.DOCHABECLFK(BGIKOPLLDJB_Rate[OIACNLKAIFO]);
	}

	// // RVA: 0x195A338 Offset: 0x195A338 VA: 0x195A338
	public int DCLKMNGMIKC()
	{
		if(NMKDLINPAFM_UseTicket)
		{
            IKDICBBFBMI_EventBase ev = JEPBIIJDGEF_EventInfo.HHCJCDFCLOB.MKBJOOAILBB_GetEventByStatus(KGCNCBOKCBA.GNENJEHKMHD_EventStatus.EMAMLLFAOJI_Counting_6, false);
			if(ev != null)
			{
				return ev.AELBIEDNPGB_GetTicketCount(null);
			}
			return 0;
        }
		return CIOECGOMILE.HHCJCDFCLOB.BPLOEAHOPFI_StaminaUpdater.DCLKMNGMIKC_GetCurrent();
	}
}
