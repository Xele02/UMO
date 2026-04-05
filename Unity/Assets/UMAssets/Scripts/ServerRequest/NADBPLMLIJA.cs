
using UnityEngine;

[System.Obsolete("Use NADBPLMLIJA_GetToken", true)]
public class NADBPLMLIJA { }
public class NADBPLMLIJA_GetToken : CACGCMBKHDI_NetBaseAction
{
	public class ACEGDBFIDHK
	{
		public string EEDAHFGPNPH_sss_temporary_token; // 0x8
	}

	public ACEGDBFIDHK NFEAMMJIMPG_Result; // 0x7C

	// RVA: 0x17BFD88 Offset: 0x17BFD88 VA: 0x17BFD88 Slot: 12
	public override void DHLDNIEELHO()
	{
		EBGACDGNCAA_CallContext = SakashoSupportSite.GetToken(DCKLDDCAJAP, MEOCKCJBDAD);
	}

	// RVA: 0x17BFE64 Offset: 0x17BFE64 VA: 0x17BFE64 Slot: 13
	public override void MGFNKDPHFGI(MonoBehaviour _DANMJLOBLIE_mb)
	{
		EDOHBJAPLPF_JsonData data = IKPIMINCOPI_JsonMapper.PFAMKCGJKKL_ToObject(NGCAIEGPLKD_result);
		NFEAMMJIMPG_Result = new ACEGDBFIDHK();
		NFEAMMJIMPG_Result.EEDAHFGPNPH_sss_temporary_token = (string)data[AFEHLCGHAEE_Strings.EEDAHFGPNPH_sss_temporary_token];
	}
}
