
using UnityEngine;

public class NHNEDAOHCKA : CACGCMBKHDI_Request
{
	public HEHLBMMFMPL_PlayerStatusInfo NFEAMMJIMPG { get; private set; } // 0x7C OHEIOONIIKB LFOJDJCNOHB KMKEGMGKCBA

	// RVA: 0x189743C Offset: 0x189743C VA: 0x189743C Slot: 12
	public override void DHLDNIEELHO()
	{
		EBGACDGNCAA_CallContext = SakashoUserToken.CreatePlayerFromTwitter(DCKLDDCAJAP, MEOCKCJBDAD);
	}

	// RVA: 0x1897518 Offset: 0x1897518 VA: 0x1897518 Slot: 13
	public override void MGFNKDPHFGI(MonoBehaviour DANMJLOBLIE)
	{
		NFEAMMJIMPG = new HEHLBMMFMPL_PlayerStatusInfo();
		NFEAMMJIMPG.KHEKNNFCAOI(IKPIMINCOPI_JsonMapper.PFAMKCGJKKL_ToObject(NGCAIEGPLKD_result));
	}
}
