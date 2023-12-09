
using UnityEngine;

public class ANLMHAMGJHP : CACGCMBKHDI_Request
{
	public HEHLBMMFMPL_PlayerStatusInfo NFEAMMJIMPG { get; private set; } // 0x7C OHEIOONIIKB LFOJDJCNOHB KMKEGMGKCBA

	// RVA: 0xD53F24 Offset: 0xD53F24 VA: 0xD53F24 Slot: 12
	public override void DHLDNIEELHO()
	{
		EBGACDGNCAA_CallContext = SakashoUserToken.CreatePlayerFromFacebook(DCKLDDCAJAP, MEOCKCJBDAD);
	}

	// RVA: 0xD54000 Offset: 0xD54000 VA: 0xD54000 Slot: 13
	public override void MGFNKDPHFGI(MonoBehaviour DANMJLOBLIE)
	{
		NFEAMMJIMPG = new HEHLBMMFMPL_PlayerStatusInfo();
		NFEAMMJIMPG.KHEKNNFCAOI(IKPIMINCOPI_JsonMapper.PFAMKCGJKKL_ToObject(NGCAIEGPLKD_result));
	}
}
