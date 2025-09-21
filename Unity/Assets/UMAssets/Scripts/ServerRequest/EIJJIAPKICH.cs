
using UnityEngine;

[System.Obsolete("Use EIJJIAPKICH_RequestToken", true)]
public class EIJJIAPKICH { } 
public class EIJJIAPKICH_RequestToken : CACGCMBKHDI_Request
{
	public override bool OIDCBBGLPHL { get { return true; } } // 0x12EB988 GINMIBJOABO

	// // RVA: 0x12EB990 Offset: 0x12EB990 VA: 0x12EB990 Slot: 12
	public override void DHLDNIEELHO()
    {
        EBGACDGNCAA_CallContext = SakashoSupportSite.GetToken((string _IDLHJIOMJBK_Data) =>
		{
			//0x12EBA6C
			DCKLDDCAJAP(_IDLHJIOMJBK_Data);
			NKGJPJPHLIF.HHCJCDFCLOB.IBLPICFDGOF_ServerRequester.FJDBNGEPKHL_Time.EAJMLOKKOOK_SetServerTime(HOHOBEOJPBK_ServerInfo.LCAINKFINEI_SakashoCurrentDateTime);
			Debug.Log("ServerTime Updated ok");
		}, (SakashoError FMEMECBIDIB) =>
		{
			//0x12EBBDC
			MEOCKCJBDAD(FMEMECBIDIB);
			Debug.Log("ServerTime Updated error");
		});
    }
}
