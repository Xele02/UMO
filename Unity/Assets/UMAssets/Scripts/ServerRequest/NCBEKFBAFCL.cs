
using UnityEngine;

[System.Obsolete("Use NCBEKFBAFCL_GetFacebookLinkageStatus", true)]
public class NCBEKFBAFCL { }
public class NCBEKFBAFCL_GetFacebookLinkageStatus : CACGCMBKHDI_Request
{
	public class EOOEOFIDGFC
	{
		public bool EMEGKEGFJBK_facebook_linkage; // 0x8

		// RVA: 0x17CC0A4 Offset: 0x17CC0A4 VA: 0x17CC0A4
		public void KHEKNNFCAOI_Init(EDOHBJAPLPF_JsonData _IDLHJIOMJBK_data)
		{
			EMEGKEGFJBK_facebook_linkage = (bool)_IDLHJIOMJBK_data[AFEHLCGHAEE_Strings.EMEGKEGFJBK_facebook_linkage];
		}
	}

	public EOOEOFIDGFC NFEAMMJIMPG_Result { get; private set; } // 0x7C OHEIOONIIKB LFOJDJCNOHB KMKEGMGKCBA

	// RVA: 0x17CBEE8 Offset: 0x17CBEE8 VA: 0x17CBEE8 Slot: 12
	public override void DHLDNIEELHO()
	{
		EBGACDGNCAA_CallContext = SakashoFacebookWithBrowser.GetFacebookLinkageStatus(DCKLDDCAJAP, MEOCKCJBDAD);
	}

	// RVA: 0x17CBFC4 Offset: 0x17CBFC4 VA: 0x17CBFC4 Slot: 13
	public override void MGFNKDPHFGI(MonoBehaviour _DANMJLOBLIE_mb)
	{
		NFEAMMJIMPG_Result = new EOOEOFIDGFC();
		NFEAMMJIMPG_Result.KHEKNNFCAOI_Init(IKPIMINCOPI_JsonMapper.PFAMKCGJKKL_ToObject(NGCAIEGPLKD_result));
	}
}
