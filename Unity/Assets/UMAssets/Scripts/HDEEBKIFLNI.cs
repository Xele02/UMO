
using System.Collections;
using UnityEngine;

public class HDEEBKIFLNI
{
	public enum DGNPPLKNCGH_PlatformLink
	{
		AIECBKAKOGC_Twitter = 0,
		LMODEBIKEBC_Line = 1,
		OKEAEMBLENP_Facebook = 2,
		AEFCOHJBLPO = 3,
	}

	private bool[] AMBCBJHFIDD_LinkByPlatform = new bool[3]; // 0x8
	private bool[] GJOFCDFLCGA_VersionValidByPlatform = new bool[3]; // 0xC

	public static HDEEBKIFLNI HHCJCDFCLOB { get; private set; } // 0x0 LGMPACEDIJF NKACBOEHELJ OKPMHKNCNAL

	// RVA: 0x1740C5C Offset: 0x1740C5C VA: 0x1740C5C
	public void IJBGPAENLJA(MonoBehaviour DANMJLOBLIE)
	{
		HHCJCDFCLOB = this;
		for(int i = 0; i < AMBCBJHFIDD_LinkByPlatform.Length; i++)
		{
			AMBCBJHFIDD_LinkByPlatform[i] = false;
			GJOFCDFLCGA_VersionValidByPlatform[i] = false;
		}
	}

	//// RVA: 0x1740D5C Offset: 0x1740D5C VA: 0x1740D5C
	private AILHMHMOKKA_BaseLinkage PLJLNHGJEIB(DGNPPLKNCGH_PlatformLink MKBOKLLDCFI)
	{
		if(MKBOKLLDCFI == DGNPPLKNCGH_PlatformLink.OKEAEMBLENP_Facebook/*2*/)
		{
			return new BKNLPABECOB_FacebookLinkage();
		}
		else if(MKBOKLLDCFI == DGNPPLKNCGH_PlatformLink.LMODEBIKEBC_Line/*1*/)
		{
			return new AIBFEFOFMFK_LineLinkage();
		}
		else if(MKBOKLLDCFI == DGNPPLKNCGH_PlatformLink.AIECBKAKOGC_Twitter/*0*/)
		{
			return new MBMENEIFOJC_TwitterLinkage();
		}
		return null;
	}

	//// RVA: 0x1740E30 Offset: 0x1740E30 VA: 0x1740E30
	public bool EPAKLDBFECD_IsLinked(DGNPPLKNCGH_PlatformLink MKBOKLLDCFI)
	{
		return AMBCBJHFIDD_LinkByPlatform[(int)MKBOKLLDCFI];
	}

	//// RVA: 0x1740E78 Offset: 0x1740E78 VA: 0x1740E78
	public bool FAEJJLGPAJP_HasALinkPlatform()
	{
		return AMBCBJHFIDD_LinkByPlatform[1] || AMBCBJHFIDD_LinkByPlatform[0] || AMBCBJHFIDD_LinkByPlatform[2];
	}

	//// RVA: 0x1740F38 Offset: 0x1740F38 VA: 0x1740F38
	private void KFDDEOKEBJC_SetLinked(DGNPPLKNCGH_PlatformLink MKBOKLLDCFI, bool MMOHJNEKMBF)
	{
		AMBCBJHFIDD_LinkByPlatform[(int)MKBOKLLDCFI] = MMOHJNEKMBF;
	}

	//// RVA: 0x1740F84 Offset: 0x1740F84 VA: 0x1740F84
	public bool OJOFAOEGEIP_IsVersionValid(DGNPPLKNCGH_PlatformLink MKBOKLLDCFI)
	{
		return GJOFCDFLCGA_VersionValidByPlatform[(int)MKBOKLLDCFI];
	}

	//// RVA: 0x1740FCC Offset: 0x1740FCC VA: 0x1740FCC
	private void DJPGDJFEFFI_SetVersionValid(DGNPPLKNCGH_PlatformLink MKBOKLLDCFI, bool JKDJCFEBDHC)
	{
		GJOFCDFLCGA_VersionValidByPlatform[(int)MKBOKLLDCFI] = JKDJCFEBDHC;
	}

	//// RVA: 0x1741018 Offset: 0x1741018 VA: 0x1741018
	public void NLCBOJBAJFB_GetLinkageStatuses(IMCBBOAFION BHFHGFKBOHH, JFDNPFFOACP NIMPEHIECJH, DJBHIFLHJLK AOCANKOMKFG)
	{
		N.a.StartCoroutineWatched(PMPMPFBDFLM_Coroutine_GetLinkageStatuses(BHFHGFKBOHH, NIMPEHIECJH, AOCANKOMKFG));
	}

	//[IteratorStateMachineAttribute] // RVA: 0x6BAB7C Offset: 0x6BAB7C VA: 0x6BAB7C
	//// RVA: 0x1741080 Offset: 0x1741080 VA: 0x1741080
	private IEnumerator PMPMPFBDFLM_Coroutine_GetLinkageStatuses(IMCBBOAFION BHFHGFKBOHH, JFDNPFFOACP NIMPEHIECJH, DJBHIFLHJLK AOCANKOMKFG)
	{
		//0x1741C58
		for(int BMBBDIAEOMP_i = 0; BMBBDIAEOMP_i <= 2; BMBBDIAEOMP_i++)
		{
			AILHMHMOKKA_BaseLinkage LIKDEHHKFEH = PLJLNHGJEIB((DGNPPLKNCGH_PlatformLink)BMBBDIAEOMP_i);
			int NMOLAEAFDNK = 0;
			LIKDEHHKFEH.EMKKJILHOOB_GetLinkageStatus(() =>
			{
				//0x1741638
				NMOLAEAFDNK = 1;
				KFDDEOKEBJC_SetLinked((DGNPPLKNCGH_PlatformLink)BMBBDIAEOMP_i, LIKDEHHKFEH.JEDJNIKPFLH_IsLinked);
				DJPGDJFEFFI_SetVersionValid((DGNPPLKNCGH_PlatformLink)BMBBDIAEOMP_i, LIKDEHHKFEH.MOJEDCPFGJJ_IsVersionOk);
			}, () =>
			{
				//0x1741734
				NMOLAEAFDNK = 2;
			}, () =>
			{
				//0x1741740
				NMOLAEAFDNK = 3;
			});
			while (NMOLAEAFDNK == 0)
				yield return null;
			if (NMOLAEAFDNK == 2)
			{
				for (int i = 0; i < 3; i++)
				{
					KFDDEOKEBJC_SetLinked((DGNPPLKNCGH_PlatformLink)i, false);
					DJPGDJFEFFI_SetVersionValid((DGNPPLKNCGH_PlatformLink)BMBBDIAEOMP_i, false);
				}
				if (NIMPEHIECJH != null)
					NIMPEHIECJH();
				yield break;
			}
			if(NMOLAEAFDNK == 3)
			{
				for (int i = 0; i < 3; i++)
				{
					KFDDEOKEBJC_SetLinked((DGNPPLKNCGH_PlatformLink)i, false);
					DJPGDJFEFFI_SetVersionValid((DGNPPLKNCGH_PlatformLink)BMBBDIAEOMP_i, false);
				}
				if (AOCANKOMKFG != null)
					AOCANKOMKFG();
			}
		}
		BHFHGFKBOHH();
	}

	//// RVA: 0x1741178 Offset: 0x1741178 VA: 0x1741178
	//public void IEIDONOJCOB(HDEEBKIFLNI.DGNPPLKNCGH MKBOKLLDCFI, IMCBBOAFION BHFHGFKBOHH, JFDNPFFOACP NIMPEHIECJH, DJBHIFLHJLK AOCANKOMKFG) { }

	//// RVA: 0x17412CC Offset: 0x17412CC VA: 0x17412CC
	//public void LEDGNMBOGJN(HDEEBKIFLNI.DGNPPLKNCGH MKBOKLLDCFI, IMCBBOAFION BHFHGFKBOHH, JFDNPFFOACP NIMPEHIECJH, DJBHIFLHJLK AOCANKOMKFG) { }

	//// RVA: 0x1741420 Offset: 0x1741420 VA: 0x1741420
	//public void AFOLPGDADKI(HDEEBKIFLNI.DGNPPLKNCGH MKBOKLLDCFI, IMCBBOAFION BHFHGFKBOHH, JFDNPFFOACP NIMPEHIECJH, DJBHIFLHJLK AOCANKOMKFG) { }

	//[IteratorStateMachineAttribute] // RVA: 0x6BABF4 Offset: 0x6BABF4 VA: 0x6BABF4
	//// RVA: 0x1741490 Offset: 0x1741490 VA: 0x1741490
	//private IEnumerator EFCCKAMIMAI(HDEEBKIFLNI.DGNPPLKNCGH MKBOKLLDCFI, IMCBBOAFION BHFHGFKBOHH, JFDNPFFOACP NIMPEHIECJH, DJBHIFLHJLK AOCANKOMKFG) { }
}
