using System.Collections.Generic;

public class EEMGHIINEHN
{
	public enum LMPEOKPFKCA
	{
		HONJMAFKFMA = 0,
		EKKJBJDFHFN = 1,
		DEPNDHEKPNC = 2,
		KMBLOGHDEMI = 3,
		AEFCOHJBLPO = 4,
	}

	public class OPANFJDIEGH
	{
		public GCIJNCFDNON_SceneInfo[] JOHLGBDOLNO_AssistScenes = new GCIJNCFDNON_SceneInfo[4]; // 0x8
		public string JCJNKBKMJFK_Name; // 0xC

		// RVA: 0x1C4A128 Offset: 0x1C4A128 VA: 0x1C4A128
		public OPANFJDIEGH()
		{
			for(int i = 0; i < JOHLGBDOLNO_AssistScenes.Length; i++)
			{
				JOHLGBDOLNO_AssistScenes[i] = new GCIJNCFDNON_SceneInfo();
			}
		}

		// RVA: 0x1C4B364 Offset: 0x1C4B364 VA: 0x1C4B364
		public void LDHHJFHGGMA(BBHNACPENDM_ServerSaveData LDEGEHAEALK)
		{
			JNMFKOHFAFB_PublicStatus.ONCMONJIPCD assist = LDEGEHAEALK.MHEAEGMIKIE_PublicStatus.MGMFOJPNDGA_AssistData;
			for(int i = 0; i < JOHLGBDOLNO_AssistScenes.Length; i++)
			{
				if(assist.JOHLGBDOLNO_DataList[i].PPFNGGCBJKC_Id > 0)
				{
					JOHLGBDOLNO_AssistScenes[i].KHEKNNFCAOI(assist.JOHLGBDOLNO_DataList[i].PPFNGGCBJKC_Id,
						assist.JOHLGBDOLNO_DataList[i].PDNIFBEGMHC_Mb,
						assist.JOHLGBDOLNO_DataList[i].EMOJHJGHJLN_Sb,
						assist.JOHLGBDOLNO_DataList[i].JPIPENJGGDD_Mlt, 1,
						assist.JOHLGBDOLNO_DataList[i].MJBODMOLOBC_Luck, false, 0, 
						assist.JOHLGBDOLNO_DataList[i].DMNIMMGGJJJ_Leaf);
				}
			}
			JCJNKBKMJFK_Name = assist.JCJNKBKMJFK_Name;
		}
	}

	private List<OPANFJDIEGH> NPDOIBMDEGK = new List<OPANFJDIEGH>(); // 0x8

	//// RVA: 0x1C49D40 Offset: 0x1C49D40 VA: 0x1C49D40
	//private void AODCGBBHKDJ(BBHNACPENDM LDEGEHAEALK, int IGNIIEBMFIN = 0) { }

	//// RVA: 0x1C4A250 Offset: 0x1C4A250 VA: 0x1C4A250
	//public void KHEKNNFCAOI() { }

	//// RVA: 0x1C4A348 Offset: 0x1C4A348 VA: 0x1C4A348
	//public void CLFGOPNDGNL(GCIJNCFDNON IFGEJDMMAHE, int IGNIIEBMFIN, int IMJIADPJJMM) { }

	//// RVA: 0x1C4A6FC Offset: 0x1C4A6FC VA: 0x1C4A6FC
	//public void IONKIJLHJDP() { }

	//// RVA: 0x1C4AC78 Offset: 0x1C4AC78 VA: 0x1C4AC78
	//public void NODLMHKAGFD(int IGNIIEBMFIN, int IMJIADPJJMM) { }

	//// RVA: 0x1C4AEB8 Offset: 0x1C4AEB8 VA: 0x1C4AEB8
	//public void EGENJDLKEJP(int IGNIIEBMFIN, string JAOODKBNALI) { }

	//// RVA: 0x1C4AAF4 Offset: 0x1C4AAF4 VA: 0x1C4AAF4
	//public void AIMMBGFMFOD(int IGNIIEBMFIN) { }

	//// RVA: 0x1C4AFCC Offset: 0x1C4AFCC VA: 0x1C4AFCC
	//public void CEIOGBFIDKI(int IGNIIEBMFIN) { }

	//// RVA: 0x1C4B0A0 Offset: 0x1C4B0A0 VA: 0x1C4B0A0
	//public EEMGHIINEHN.OPANFJDIEGH IOKHHOCMNKA(int IGNIIEBMFIN) { }

	//// RVA: 0x1C4B120 Offset: 0x1C4B120 VA: 0x1C4B120
	//public EEMGHIINEHN.OPANFJDIEGH IOKHHOCMNKA() { }

	//// RVA: 0x1C4B204 Offset: 0x1C4B204 VA: 0x1C4B204
	public GCIJNCFDNON_SceneInfo ELBLMMPEKPH(int IGNIIEBMFIN, int IMJIADPJJMM)
	{
		return NPDOIBMDEGK[IGNIIEBMFIN].JOHLGBDOLNO_AssistScenes[IMJIADPJJMM];
	}

	//// RVA: 0x1C4AA20 Offset: 0x1C4AA20 VA: 0x1C4AA20
	//public int ILHBCOMKHOO() { }
}
