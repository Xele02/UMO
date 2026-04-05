
using UnityEngine;

public class AOODABADOGG : CACGCMBKHDI_NetBaseAction
{
	public HEHLBMMFMPL_PlayerStatusInfo NFEAMMJIMPG_Result { get; private set; } // 0x7C OHEIOONIIKB_bgs LFOJDJCNOHB_bgs KMKEGMGKCBA_bgs

	// RVA: 0xD5EAA8 Offset: 0xD5EAA8 VA: 0xD5EAA8 Slot: 12
	public override void DHLDNIEELHO()
	{
		EBGACDGNCAA_CallContext = SakashoUserToken.CreatePlayerFromLine(DCKLDDCAJAP, MEOCKCJBDAD);
	}

	// RVA: 0xD5EB84 Offset: 0xD5EB84 VA: 0xD5EB84 Slot: 13
	public override void MGFNKDPHFGI(MonoBehaviour _DANMJLOBLIE_mb)
	{
		NFEAMMJIMPG_Result = new HEHLBMMFMPL_PlayerStatusInfo();
		NFEAMMJIMPG_Result.KHEKNNFCAOI_Init(IKPIMINCOPI_JsonMapper.PFAMKCGJKKL_ToObject(NGCAIEGPLKD_result));
		SakashoLine.CallCreatePlayerFromLineAfterOAuth();
	}
}
