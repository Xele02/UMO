
using UnityEngine;


[System.Obsolete("Use EDOGNHECOMI_GetStepUpLotDetail", true)]
public class EDOGNHECOMI { }
public class EDOGNHECOMI_GetStepUpLotDetail : CACGCMBKHDI_Request
{
	public int KHDLOLOPCOK = 3; // 0x7C
	public int LLPOINKCHEJ = 1; // 0x80
	public string MMEBLOIJBKE; // 0x84
	private bool ENDFGMBBBEE; // 0x88

	public JBHCLFDBPKP NFEAMMJIMPG { get; private set; } // 0x8C OHEIOONIIKB LFOJDJCNOHB KMKEGMGKCBA
	public override bool EBPLLJGPFDA_HasResult { get { return NFEAMMJIMPG != null; } } // 0x1509F00 HGPAELCGELL

	// RVA: 0x1509CAC Offset: 0x1509CAC VA: 0x1509CAC Slot: 12
	public override void DHLDNIEELHO()
	{
		TodoLogger.LogError(0, "EDOGNHECOMI_GetStepUpLotDetail.DHLDNIEELHO");
	}

	// RVA: 0x1509DA8 Offset: 0x1509DA8 VA: 0x1509DA8
	public EDOGNHECOMI_GetStepUpLotDetail(bool CMAKKCANGGD = false)
	{
		ENDFGMBBBEE = CMAKKCANGGD;
	}

	// RVA: 0x1509E44 Offset: 0x1509E44 VA: 0x1509E44 Slot: 13
	public override void MGFNKDPHFGI(MonoBehaviour DANMJLOBLIE)
	{
		TodoLogger.LogError(0, "EDOGNHECOMI_GetStepUpLotDetail.MGFNKDPHFGI");
	}

	// RVA: 0x1509F10 Offset: 0x1509F10 VA: 0x1509F10
	//private void DIAMDBHBKBH() { }
}
