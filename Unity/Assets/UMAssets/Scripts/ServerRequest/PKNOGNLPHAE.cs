using UnityEngine;

[System.Obsolete("Use PKNOGNLPHAE_CreatePlayer", true)]
public class PKNOGNLPHAE { }
public class PKNOGNLPHAE_CreatePlayer : CACGCMBKHDI_Request
{
	public HEHLBMMFMPL_PlayerStatusInfo NFEAMMJIMPG { get; private set; } // 0x7C OHEIOONIIKB LFOJDJCNOHB KMKEGMGKCBA

	public int AccountType;

	// RVA: 0x93FE38 Offset: 0x93FE38 VA: 0x93FE38 Slot: 12
	public override void DHLDNIEELHO()
	{
		EBGACDGNCAA_CallContext = SakashoUserToken.CreatePlayer(AccountType, DCKLDDCAJAP, MEOCKCJBDAD);
	}

	// RVA: 0x93FF14 Offset: 0x93FF14 VA: 0x93FF14 Slot: 13
	public override void MGFNKDPHFGI(MonoBehaviour DANMJLOBLIE)
	{
		NFEAMMJIMPG = new HEHLBMMFMPL_PlayerStatusInfo();
		NFEAMMJIMPG.KHEKNNFCAOI(IKPIMINCOPI_JsonMapper.PFAMKCGJKKL_ToObject(NGCAIEGPLKD_result));
	}
}
