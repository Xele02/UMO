
using UnityEngine;

public class AOODABADOGG : CACGCMBKHDI_Request
{
	public HEHLBMMFMPL_PlayerStatusInfo NFEAMMJIMPG { get; private set; } // 0x7C OHEIOONIIKB LFOJDJCNOHB KMKEGMGKCBA

	// RVA: 0xD5EAA8 Offset: 0xD5EAA8 VA: 0xD5EAA8 Slot: 12
	public override void DHLDNIEELHO()
	{
		EBGACDGNCAA_CallContext = SakashoUserToken.CreatePlayerFromLine(DCKLDDCAJAP, MEOCKCJBDAD);
	}

	// RVA: 0xD5EB84 Offset: 0xD5EB84 VA: 0xD5EB84 Slot: 13
	public override void MGFNKDPHFGI(MonoBehaviour DANMJLOBLIE)
	{
		NFEAMMJIMPG = new HEHLBMMFMPL_PlayerStatusInfo();
		NFEAMMJIMPG.KHEKNNFCAOI(IKPIMINCOPI_JsonMapper.PFAMKCGJKKL_ToObject(NGCAIEGPLKD_result));
		SakashoLine.CallCreatePlayerFromLineAfterOAuth();
	}
}
