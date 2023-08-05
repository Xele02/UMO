
using UnityEngine;

[System.Obsolete("Use NCBEKFBAFCL_GetFacebookLinkageStatus", true)]
public class NCBEKFBAFCL { }
public class NCBEKFBAFCL_GetFacebookLinkageStatus : CACGCMBKHDI_Request
{
	public class EOOEOFIDGFC
	{
		public bool EMEGKEGFJBK_FacebookLinkage; // 0x8

		// RVA: 0x17CC0A4 Offset: 0x17CC0A4 VA: 0x17CC0A4
		public void KHEKNNFCAOI(EDOHBJAPLPF_JsonData IDLHJIOMJBK)
		{
			EMEGKEGFJBK_FacebookLinkage = (bool)IDLHJIOMJBK[AFEHLCGHAEE_Strings.EMEGKEGFJBK_facebook_linkage];
		}
	}

	public EOOEOFIDGFC NFEAMMJIMPG { get; private set; } // 0x7C OHEIOONIIKB LFOJDJCNOHB KMKEGMGKCBA

	// RVA: 0x17CBEE8 Offset: 0x17CBEE8 VA: 0x17CBEE8 Slot: 12
	public override void DHLDNIEELHO()
	{
		EBGACDGNCAA_CallContext = SakashoFacebookWithBrowser.GetFacebookLinkageStatus(DCKLDDCAJAP, MEOCKCJBDAD);
	}

	// RVA: 0x17CBFC4 Offset: 0x17CBFC4 VA: 0x17CBFC4 Slot: 13
	public override void MGFNKDPHFGI(MonoBehaviour DANMJLOBLIE)
	{
		NFEAMMJIMPG = new EOOEOFIDGFC();
		NFEAMMJIMPG.KHEKNNFCAOI(IKPIMINCOPI_JsonMapper.PFAMKCGJKKL_ToObject(NGCAIEGPLKD_result));
	}
}
