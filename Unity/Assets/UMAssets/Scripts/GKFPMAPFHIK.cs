using System;
using System.Collections.Generic;
using UnityEngine;
using XeApp.Game;

[Obsolete("Use GKFPMAPFHIK_ViewEventAprilFoolMiniGameData", true)]
public class GKFPMAPFHIK { }

[AddComponentMenu("XeApp/Common/Database/View/ViewEventAprilFoolMiniGameData")] // RVA: 0x64FDA8 Offset: 0x64FDA8 VA: 0x64FDA8
public class GKFPMAPFHIK_ViewEventAprilFoolMiniGameData
{
	private const int ICAELHBJFFO = 1;
	private const sbyte JFOFMKBJBBE_False = 19;
	private const sbyte CNECJGKECHK_True = 87;
	private sbyte ALPDMEILILP_ClearCrypted; // 0x8

	public bool BCGLDMKODLC_IsClear { get { return ALPDMEILILP_ClearCrypted == CNECJGKECHK_True; } set { PNBAPMLNDLN_SetClear(value); } } //0xAB254C NNGALFPBDNA 0xAB2560 JJBMOHCMALD
	public int LGDLEHHOIEL_HighScore { get { return OOBJBHJCLON_LocalSaveShooting.LJKLECGFIEN_GetHighScore(); } set
		{
			BIEBAEDGDIA_SetHighScore(value);
		}
	} //0xAB26C0 OMFCCEBAODD 0xAB27D8 JGIJCMFGKEP
	private ILDKBCLAFPB.AKKDKBOBKGH_AprilFool.OEAIOIHGMIH OOBJBHJCLON_LocalSaveShooting { get
		{
			return GameManager.Instance.localSave.EPJOACOONAC_GetSave().ICFDECCGKIL_AprilFool.MNKOCOODFKH_MiniGameShooting;
		}
	} //0xAB26F0 EFCMMCPAPOH

	//// RVA: 0xAB28C4 Offset: 0xAB28C4 VA: 0xAB28C4
	public bool KHEKNNFCAOI()
	{
		long time = NKGJPJPHLIF.HHCJCDFCLOB.IBLPICFDGOF_ServerRequester.FJDBNGEPKHL.KMEFBNBFJHI_GetServerTime();
		AMLGMLNGMFB_EventAprilFool ev = OEGDCBLNNFF(time, KGCNCBOKCBA.GNENJEHKMHD_EventStatus.MINDIGBAJFG_3/*3*/);
		if(ev != null)
		{
			PNBAPMLNDLN_SetClear(ev.NDNDIAFEBFJ().KBAHNBKMFDL_IsMinigameClear);
			EKKFCEJECFK(ev.PGIIDPEGGPI_EventId);
			return true;
		}
		return false;
	}

	//// RVA: 0xAB2A18 Offset: 0xAB2A18 VA: 0xAB2A18
	public AMLGMLNGMFB_EventAprilFool OEGDCBLNNFF(long JHNMKKNEENE, KGCNCBOKCBA.GNENJEHKMHD_EventStatus BELFNAHNMDL = KGCNCBOKCBA.GNENJEHKMHD_EventStatus.BCKENOKGLIJ_9_ResultRewardreceived/*9*/)
	{
		List<IKDICBBFBMI_EventBase>  l = JEPBIIJDGEF_EventInfo.HHCJCDFCLOB.MPEOOINCGEN.FindAll((IKDICBBFBMI_EventBase JPAEDJJFFOI) =>
		{
			//0xAB2E5C
			return JPAEDJJFFOI.HIDHLFCBIDE_EventType == OHCAABOMEOF.KGOGMKMBCPP_EventType.DAMDPLEBNCB_AprilFool;
		});
		for (int i = 0; i < l.Count; i++)
		{
			l[i].HCDGELDHFHB_UpdateStatus(JHNMKKNEENE);
			if(l[i].NGOFCFJHOMI_Status > KGCNCBOKCBA.GNENJEHKMHD_EventStatus.FFLKPBPBPEP_1/*1*/ && l[i].NGOFCFJHOMI_Status <= BELFNAHNMDL)
			{
				if((l[i] as AMLGMLNGMFB_EventAprilFool).NDIILFIFCDL_GetMinigameId() == 1)
					return l[i] as AMLGMLNGMFB_EventAprilFool;
			}
		}
		return null;
	}

	//// RVA: 0xAB2564 Offset: 0xAB2564 VA: 0xAB2564
	private void PNBAPMLNDLN_SetClear(bool BCGLDMKODLC)
	{
		long time = NKGJPJPHLIF.HHCJCDFCLOB.IBLPICFDGOF_ServerRequester.FJDBNGEPKHL.KMEFBNBFJHI_GetServerTime();
		AMLGMLNGMFB_EventAprilFool ev = OEGDCBLNNFF(time, KGCNCBOKCBA.GNENJEHKMHD_EventStatus.BCKENOKGLIJ_9_ResultRewardreceived/*9*/);
		if (ev == null)
			return;
		ALPDMEILILP_ClearCrypted = BCGLDMKODLC ? CNECJGKECHK_True : JFOFMKBJBBE_False;
		ev.NDNDIAFEBFJ().KBAHNBKMFDL_IsMinigameClear = BCGLDMKODLC;
	}

	//// RVA: 0xAB2CE8 Offset: 0xAB2CE8 VA: 0xAB2CE8
	private void EKKFCEJECFK(int EKANGPODCEP)
	{
		if (!OOBJBHJCLON_LocalSaveShooting.FKEJBAHCMGC(EKANGPODCEP))
			return;
		GameManager.Instance.localSave.HJMKBCFJOOH_TrySave();
	}

	//// RVA: 0xAB27DC Offset: 0xAB27DC VA: 0xAB27DC
	private void BIEBAEDGDIA_SetHighScore(int LGDLEHHOIEL)
	{
		OOBJBHJCLON_LocalSaveShooting.BIEBAEDGDIA_SetHighScore(LGDLEHHOIEL);
		GameManager.Instance.localSave.HJMKBCFJOOH_TrySave();
	}
}
