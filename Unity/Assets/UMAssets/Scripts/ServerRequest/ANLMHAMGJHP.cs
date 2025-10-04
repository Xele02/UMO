
using UnityEngine;

public class ANLMHAMGJHP : CACGCMBKHDI_Request
{
	public HEHLBMMFMPL_PlayerStatusInfo NFEAMMJIMPG_Result { get; private set; } // 0x7C OHEIOONIIKB_bgs LFOJDJCNOHB_bgs KMKEGMGKCBA_bgs

	// RVA: 0xD53F24 Offset: 0xD53F24 VA: 0xD53F24 Slot: 12
	public override void DHLDNIEELHO()
	{
		EBGACDGNCAA_CallContext = SakashoUserToken.CreatePlayerFromFacebook(DCKLDDCAJAP, MEOCKCJBDAD);
	}

	// RVA: 0xD54000 Offset: 0xD54000 VA: 0xD54000 Slot: 13
	public override void MGFNKDPHFGI(MonoBehaviour _DANMJLOBLIE_mb)
	{
		NFEAMMJIMPG_Result = new HEHLBMMFMPL_PlayerStatusInfo();
		NFEAMMJIMPG_Result.KHEKNNFCAOI_Init(IKPIMINCOPI_JsonMapper.PFAMKCGJKKL_ToObject(NGCAIEGPLKD_result));
	}
}
