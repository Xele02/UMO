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
	private sbyte ALPDMEILILP_IsClearCrypted; // 0x8

	public bool BCGLDMKODLC_IsClear { get { return ALPDMEILILP_IsClearCrypted == CNECJGKECHK_True; } set { PNBAPMLNDLN_SetClear(value); } } //0xAB254C NNGALFPBDNA_bgs 0xAB2560 JJBMOHCMALD_bgs
	public int LGDLEHHOIEL_HighScore { get { return OOBJBHJCLON_LocalSaveShooting.LJKLECGFIEN_GetHighScore(); } set
		{
			BIEBAEDGDIA_SetHighScore(value);
		}
	} //0xAB26C0 OMFCCEBAODD_bgs 0xAB27D8 JGIJCMFGKEP_bgs
	private ILDKBCLAFPB.AKKDKBOBKGH_AprilFool.OEAIOIHGMIH OOBJBHJCLON_LocalSaveShooting { get
		{
			return GameManager.Instance.localSave.EPJOACOONAC_GetSave().ICFDECCGKIL_AprilFool.MNKOCOODFKH_MiniGameShooting;
		}
	} //0xAB26F0 EFCMMCPAPOH_bgs

	//// RVA: 0xAB28C4 Offset: 0xAB28C4 VA: 0xAB28C4
	public bool KHEKNNFCAOI_Init()
	{
		long time = NKGJPJPHLIF_SakashoManager.HHCJCDFCLOB_Instance.IBLPICFDGOF_ServerRequester.FJDBNGEPKHL_Time.KMEFBNBFJHI_GetServerTime();
		AMLGMLNGMFB_NetEventAprilFoolController ev = OEGDCBLNNFF(time, KGCNCBOKCBA.GNENJEHKMHD_EventStatus.MINDIGBAJFG_3_Ranking/*3*/);
		if(ev != null)
		{
			PNBAPMLNDLN_SetClear(ev.NDNDIAFEBFJ().KBAHNBKMFDL_is_minigame_clear);
			EKKFCEJECFK(ev.PGIIDPEGGPI_EventId);
			return true;
		}
		return false;
	}

	//// RVA: 0xAB2A18 Offset: 0xAB2A18 VA: 0xAB2A18
	public AMLGMLNGMFB_NetEventAprilFoolController OEGDCBLNNFF(long _JHNMKKNEENE_Time, KGCNCBOKCBA.GNENJEHKMHD_EventStatus BELFNAHNMDL/* = KGCNCBOKCBA.GNENJEHKMHD_EventStatus.BCKENOKGLIJ_9_ResultRewardreceived*/)
	{
		List<IKDICBBFBMI_NetEventBaseController>  l = JEPBIIJDGEF_NetEventManager.HHCJCDFCLOB_Instance.MPEOOINCGEN.FindAll((IKDICBBFBMI_NetEventBaseController JPAEDJJFFOI) =>
		{
			//0xAB2E5C
			return JPAEDJJFFOI.HIDHLFCBIDE_EventType == OHCAABOMEOF.KGOGMKMBCPP_EventType.DAMDPLEBNCB_AprilFool;
		});
		for (int i = 0; i < l.Count; i++)
		{
			l[i].HCDGELDHFHB_UpdateStatus(_JHNMKKNEENE_Time);
			if(l[i].NGOFCFJHOMI_Status > KGCNCBOKCBA.GNENJEHKMHD_EventStatus.FFLKPBPBPEP_1_NotStarted/*1*/ && l[i].NGOFCFJHOMI_Status <= BELFNAHNMDL)
			{
				if((l[i] as AMLGMLNGMFB_NetEventAprilFoolController).NDIILFIFCDL_GetMinigameId() == 1)
					return l[i] as AMLGMLNGMFB_NetEventAprilFoolController;
			}
		}
		return null;
	}

	//// RVA: 0xAB2564 Offset: 0xAB2564 VA: 0xAB2564
	private void PNBAPMLNDLN_SetClear(bool _BCGLDMKODLC_IsClear)
	{
		long time = NKGJPJPHLIF_SakashoManager.HHCJCDFCLOB_Instance.IBLPICFDGOF_ServerRequester.FJDBNGEPKHL_Time.KMEFBNBFJHI_GetServerTime();
		AMLGMLNGMFB_NetEventAprilFoolController ev = OEGDCBLNNFF(time, KGCNCBOKCBA.GNENJEHKMHD_EventStatus.BCKENOKGLIJ_9_ResultRewardreceived/*9*/);
		if (ev == null)
			return;
		BCGLDMKODLC_IsClear = _BCGLDMKODLC_IsClear;
		ev.NDNDIAFEBFJ().KBAHNBKMFDL_is_minigame_clear = _BCGLDMKODLC_IsClear;
	}

	//// RVA: 0xAB2CE8 Offset: 0xAB2CE8 VA: 0xAB2CE8
	private void EKKFCEJECFK(int _EKANGPODCEP_EventId)
	{
		if (!OOBJBHJCLON_LocalSaveShooting.FKEJBAHCMGC_CheckEvent(_EKANGPODCEP_EventId))
			return;
		GameManager.Instance.localSave.HJMKBCFJOOH_Save();
	}

	//// RVA: 0xAB27DC Offset: 0xAB27DC VA: 0xAB27DC
	private void BIEBAEDGDIA_SetHighScore(int _LGDLEHHOIEL_HighScore)
	{
		OOBJBHJCLON_LocalSaveShooting.BIEBAEDGDIA_SetHighScore(_LGDLEHHOIEL_HighScore);
		GameManager.Instance.localSave.HJMKBCFJOOH_Save();
	}
}
