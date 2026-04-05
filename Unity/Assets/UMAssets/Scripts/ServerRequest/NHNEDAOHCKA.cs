
using UnityEngine;

public class NHNEDAOHCKA : CACGCMBKHDI_NetBaseAction
{
	public HEHLBMMFMPL_PlayerStatusInfo NFEAMMJIMPG_Result { get; private set; } // 0x7C OHEIOONIIKB_bgs LFOJDJCNOHB_bgs KMKEGMGKCBA_bgs

	// RVA: 0x189743C Offset: 0x189743C VA: 0x189743C Slot: 12
	public override void DHLDNIEELHO()
	{
		EBGACDGNCAA_CallContext = SakashoUserToken.CreatePlayerFromTwitter(DCKLDDCAJAP, MEOCKCJBDAD);
	}

	// RVA: 0x1897518 Offset: 0x1897518 VA: 0x1897518 Slot: 13
	public override void MGFNKDPHFGI(MonoBehaviour _DANMJLOBLIE_mb)
	{
		NFEAMMJIMPG_Result = new HEHLBMMFMPL_PlayerStatusInfo();
		NFEAMMJIMPG_Result.KHEKNNFCAOI_Init(IKPIMINCOPI_JsonMapper.PFAMKCGJKKL_ToObject(NGCAIEGPLKD_result));
	}
}
