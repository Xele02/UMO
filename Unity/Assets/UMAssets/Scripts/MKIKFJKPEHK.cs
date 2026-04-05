
using System.Collections.Generic;

public class MKIKFJKPEHK
{
	public enum IMIDFBNGHCG_EventMusicPlayCheck
	{
		DCFJEBLEELJ_0_Ok = 0,
		CNAMHABEOPF_1_NeedStamina = 1,
		FKLMPGJPDLL_2_NeedTicket = 2,
		JCOBDONNJIP_3_NoEvent = 3,
	}

	public bool NMKDLINPAFM_UseTicket; // 0x8
	public List<int> BGIKOPLLDJB_Rate; // 0xC
	public List<int> KLOOIJIDKGO_Cost; // 0x10

	// // RVA: 0x1959A70 Offset: 0x1959A70 VA: 0x1959A70
	public bool DPICLLJJPAC(IBJAKJJICBC ENKGMPLGEIJ, int _FCHBEILHFBC_Difficulty, bool _GIKLNODJKFK_IsLine6)
	{
		if ((ENKGMPLGEIJ.MNNHHJBBICA_GameEventType > 0 && ENKGMPLGEIJ.MNNHHJBBICA_GameEventType < 4) || ENKGMPLGEIJ.MNNHHJBBICA_GameEventType == 6)
		{
            IKDICBBFBMI_NetEventBaseController ev = JEPBIIJDGEF_NetEventManager.HHCJCDFCLOB_Instance.MKBJOOAILBB_GetEventByStatus(KGCNCBOKCBA.GNENJEHKMHD_EventStatus.EMAMLLFAOJI_6_Counting, false);
			if(ev != null)
			{
				if((int)ev.HIDHLFCBIDE_EventType == ENKGMPLGEIJ.MNNHHJBBICA_GameEventType)
				{
					long t = NKGJPJPHLIF_SakashoManager.HHCJCDFCLOB_Instance.IBLPICFDGOF_ServerRequester.FJDBNGEPKHL_Time.KMEFBNBFJHI_GetServerTime();
					if(t < ev.DPJCPDKALGI_RankingEnd && ev.MBHDIJJEOFL != null)
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
							if(ev.MBHDIJJEOFL[i].INDDJNMPONH_type == a1)
							{
								if(ev.MBHDIJJEOFL[i].MAFAIIHJAFG_spurt <= (((int)ev.NGOFCFJHOMI_Status & 0xfffffffe) == 4 ? 1 : 0))
								{
									int a2;
									if(ev.MBHDIJJEOFL[i].INDDJNMPONH_type == 1)
									{
										a2 = ENKGMPLGEIJ.MGJKEJHEBPO_Blocks[_FCHBEILHFBC_Difficulty].BPLOEAHOPFI_stamina;
									}
									else
									{
										a2 = ev.EAMODCHMCEL_GetTicketCost(_FCHBEILHFBC_Difficulty, _GIKLNODJKFK_IsLine6);
									}
									KLOOIJIDKGO_Cost.Add(ev.MBHDIJJEOFL[i].JBGEEPFKIGG_val * a2);
									BGIKOPLLDJB_Rate.Add(ev.MBHDIJJEOFL[i].JBGEEPFKIGG_val);
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
			//ENKGMPLGEIJ.MFJKNCACBDG_OpenEventType
		}
		return false;
	}

	// // RVA: 0x1959FB8 Offset: 0x1959FB8 VA: 0x1959FB8
	public IMIDFBNGHCG_EventMusicPlayCheck EFFBJDMGIGO_GetBuyPossible(int OIACNLKAIFO)
	{
		IKDICBBFBMI_NetEventBaseController ev = JEPBIIJDGEF_NetEventManager.HHCJCDFCLOB_Instance.MKBJOOAILBB_GetEventByStatus(KGCNCBOKCBA.GNENJEHKMHD_EventStatus.EMAMLLFAOJI_6_Counting/*6*/, false);
		if(ev != null)
		{
			long t = NKGJPJPHLIF_SakashoManager.HHCJCDFCLOB_Instance.IBLPICFDGOF_ServerRequester.FJDBNGEPKHL_Time.KMEFBNBFJHI_GetServerTime();
			if(t < ev.DPJCPDKALGI_RankingEnd)
			{
				if(!NMKDLINPAFM_UseTicket)
				{
					return CIOECGOMILE_NetPlayerDataManager.HHCJCDFCLOB_Instance.BPLOEAHOPFI_stamina.DCLKMNGMIKC_GetCurrentValue() < KLOOIJIDKGO_Cost[OIACNLKAIFO] ? IMIDFBNGHCG_EventMusicPlayCheck.CNAMHABEOPF_1_NeedStamina : IMIDFBNGHCG_EventMusicPlayCheck.DCFJEBLEELJ_0_Ok;
				}
				else
				{
					return ev.AELBIEDNPGB_GetTicketCount(null) < KLOOIJIDKGO_Cost[OIACNLKAIFO] ? IMIDFBNGHCG_EventMusicPlayCheck.FKLMPGJPDLL_2_NeedTicket : IMIDFBNGHCG_EventMusicPlayCheck.DCFJEBLEELJ_0_Ok;
				}
			}
		}
		return IMIDFBNGHCG_EventMusicPlayCheck.JCOBDONNJIP_3_NoEvent;
	}

	// // RVA: 0x195A240 Offset: 0x195A240 VA: 0x195A240
	public void PPCLCOPGBBK(int OIACNLKAIFO)
	{
        IKDICBBFBMI_NetEventBaseController ev = JEPBIIJDGEF_NetEventManager.HHCJCDFCLOB_Instance.MKBJOOAILBB_GetEventByStatus(KGCNCBOKCBA.GNENJEHKMHD_EventStatus.EMAMLLFAOJI_6_Counting, false);
    	if(ev == null)
			return;
		ev.DOCHABECLFK(BGIKOPLLDJB_Rate[OIACNLKAIFO]);
	}

	// // RVA: 0x195A338 Offset: 0x195A338 VA: 0x195A338
	public int DCLKMNGMIKC_GetCurrentValue()
	{
		if(NMKDLINPAFM_UseTicket)
		{
            IKDICBBFBMI_NetEventBaseController ev = JEPBIIJDGEF_NetEventManager.HHCJCDFCLOB_Instance.MKBJOOAILBB_GetEventByStatus(KGCNCBOKCBA.GNENJEHKMHD_EventStatus.EMAMLLFAOJI_6_Counting, false);
			if(ev != null)
			{
				return ev.AELBIEDNPGB_GetTicketCount(null);
			}
			return 0;
        }
		return CIOECGOMILE_NetPlayerDataManager.HHCJCDFCLOB_Instance.BPLOEAHOPFI_stamina.DCLKMNGMIKC_GetCurrentValue();
	}
}
