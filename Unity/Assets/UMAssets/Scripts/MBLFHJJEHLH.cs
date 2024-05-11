
using System.Collections.Generic;
using XeApp;
using XeApp.Game;

[System.Obsolete("Use MBLFHJJEHLH_AnketoMgr", true)]
public class MBLFHJJEHLH { }
public class MBLFHJJEHLH_AnketoMgr
{
	public class CGBKENNCMMC
	{
		public int PPFNGGCBJKC_Id; // 0x8
		public int EILKGEADKGH_Idx; // 0xC
		public int INDDJNMPONH_NotifId; // 0x10
		public int CEMEIPNMAAD_Version; // 0x14
		public string ADCMNODJBGJ_Question; // 0x18
		public string[] LPKAJMLOAMF_ChoiceText; // 0x1C
		public bool[] MHBBJADMHPN_ChoiceSelected; // 0x20
		public int CIMPIIJBFPE = 1; // 0x24
		public int DHEIGBMNBNK = 1; // 0x28
		public int NNDBJGDFEEM_MinAnswer; // 0x2C
		public int DOOGFEGEKLG_MaxAnswer; // 0x30

		//// RVA: 0xA2FF20 Offset: 0xA2FF20 VA: 0xA2FF20
		public bool NMEMGMMNMDK()
		{
			return INDDJNMPONH_NotifId == 1;
		}

		//// RVA: 0xA2FF30 Offset: 0xA2FF30 VA: 0xA2FF30
		public bool CPLDDCLIBAL()
		{
			return INDDJNMPONH_NotifId == 2;
		}

		//// RVA: 0xA2FF44 Offset: 0xA2FF44 VA: 0xA2FF44
		//public string MNNKOKNBJNC() { }

		//// RVA: 0xA3053C Offset: 0xA3053C VA: 0xA3053C
		//public void MNANNMDBHMP(int OIPCCBHIKIA) { }

		//// RVA: 0xA30634 Offset: 0xA30634 VA: 0xA30634
		public int LLGNLAGBHKN_GetNumChecked()
		{
			int cnt = 0;
			for(int i = 0; i < MHBBJADMHPN_ChoiceSelected.Length; i++)
			{
				cnt += MHBBJADMHPN_ChoiceSelected[i] ? 1 : 0;
			}
			return cnt;
		}

		//// RVA: 0xA2FD70 Offset: 0xA2FD70 VA: 0xA2FD70
		public bool GIEPMFIEPJD_IsValid()
		{
			if(INDDJNMPONH_NotifId == 1)
			{
				if(LLGNLAGBHKN_GetNumChecked() == 1)
				{
					return true;
				}
			}
			if(INDDJNMPONH_NotifId == 2)
			{
				return LLGNLAGBHKN_GetNumChecked() > 0;
			}
			return false;
		}
	}

	public List<CGBKENNCMMC> KICOACCACII_QData = new List<CGBKENNCMMC>(); // 0x8
	public int MCJBEJBMJMF_TotalCount; // 0xC

	// RVA: 0xA2F5A8 Offset: 0xA2F5A8 VA: 0xA2F5A8
	public bool KHEKNNFCAOI(int GJLFANGDGCL_Category, bool FBBNPFFEJBN_Force = false)
	{
		IPJBAPLFECP_Anketo dbAnketo = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.OILKBADFBOK_Anketo;
		KICOACCACII_QData.Clear();
		ILDKBCLAFPB.BKLCILHFCGB_Flags flags = GameManager.Instance.localSave.EPJOACOONAC_GetSave().LPBFPCGDOGC_Anketo.FHEJNGDFMAI_AnswerFlags;
		MCJBEJBMJMF_TotalCount = 0;
		for(int i = 0; i < dbAnketo.CDENCMNHNGA.Count; i++)
		{
			IPJBAPLFECP_Anketo.MDOMAACPHCN question = dbAnketo.CDENCMNHNGA[i];
			if (question.PLALNIIBLOF_Enabled == 2 && question.GJLFANGDGCL_Category == GJLFANGDGCL_Category)
			{
				if(!AppEnv.IsPresentation())
				{
					MCJBEJBMJMF_TotalCount++;
					if(!FBBNPFFEJBN_Force)
					{
						if (flags.ODKIHPBEOEC_IsTrue(question.PPFNGGCBJKC_Id - 1))
						{
							continue;
						}
					}
					CGBKENNCMMC data = new CGBKENNCMMC();
					data.PPFNGGCBJKC_Id = question.PPFNGGCBJKC_Id;
					data.EILKGEADKGH_Idx = question.EILKGEADKGH_Idx;
					data.INDDJNMPONH_NotifId = question.INDDJNMPONH_NotifId;
					data.ADCMNODJBGJ_Question = question.ADCMNODJBGJ_Question;
					data.LPKAJMLOAMF_ChoiceText = question.BNMCMNPPPCI_ChoiceText;
					data.MHBBJADMHPN_ChoiceSelected = new bool[data.LPKAJMLOAMF_ChoiceText.Length];
					data.CIMPIIJBFPE = question.EMNLOGDDOBC;
					data.DHEIGBMNBNK = question.IICECOLFEEL;
					data.CEMEIPNMAAD_Version = question.LLNDMKBBNIJ_Version;
					data.NNDBJGDFEEM_MinAnswer = question.NNDBJGDFEEM_MinAnswer;
					data.DOOGFEGEKLG_MaxAnswer = question.DOOGFEGEKLG_MaxAnswer;
					KICOACCACII_QData.Add(data);
				}
			}
		}
		KICOACCACII_QData.Sort((CGBKENNCMMC HKICMNAACDA, CGBKENNCMMC BNKHBCBJBKI) =>
		{
			//0xA2FED8
			return HKICMNAACDA.EILKGEADKGH_Idx.CompareTo(BNKHBCBJBKI.EILKGEADKGH_Idx);
		});
		return KICOACCACII_QData.Count > 0;
	}

	//// RVA: 0xA2FB90 Offset: 0xA2FB90 VA: 0xA2FB90
	public void HGOHIJMEIHG_UpdateResult(CGBKENNCMMC PEPCJDIECJP)
	{
		if (!PEPCJDIECJP.GIEPMFIEPJD_IsValid())
			return;
		ILCCJNDFFOB.HHCJCDFCLOB.MLNHHIIDJAO_SendAnketoResult(PEPCJDIECJP);
		GameManager.Instance.localSave.EPJOACOONAC_GetSave().LPBFPCGDOGC_Anketo.FHEJNGDFMAI_AnswerFlags.EDEDFDDIOKO_SetTrue(PEPCJDIECJP.PPFNGGCBJKC_Id - 1);
		GameManager.Instance.localSave.HJMKBCFJOOH_TrySave();
	}
}
 
