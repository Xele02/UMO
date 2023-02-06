
using UnityEngine;

public class LKFOCCGOINN : CACGCMBKHDI_Request
{
	public class FLFKLJCAJPG_ResData
	{
		public string EEDAHFGPNPH_TempToken; // 0x8
		public string MCHAINJKMEB_UrlWithToken; // 0xC
	}

	public FLFKLJCAJPG_ResData NFEAMMJIMPG_Result; // 0x7C

	// RVA: 0x180A664 Offset: 0x180A664 VA: 0x180A664 Slot: 13
	public override void MGFNKDPHFGI(MonoBehaviour DANMJLOBLIE)
	{
		FLFKLJCAJPG_ResData res = new FLFKLJCAJPG_ResData();
		EDOHBJAPLPF_JsonData data = IKPIMINCOPI_JsonMapper.PFAMKCGJKKL_ToObject(NGCAIEGPLKD_result);
		res.EEDAHFGPNPH_TempToken = (string)data[AFEHLCGHAEE_Strings.EEDAHFGPNPH_sss_temporary_token];
		res.MCHAINJKMEB_UrlWithToken = (string)data[AFEHLCGHAEE_Strings.MCHAINJKMEB_url_with_token];
		NFEAMMJIMPG_Result = res;
	}
}
