using UnityEngine;

[System.Obsolete("Use IHKOJFIFPKB_RequestInquiryResponsesNumber", true)]
public class IHKOJFIFPKB { }
public class IHKOJFIFPKB_RequestInquiryResponsesNumber : CACGCMBKHDI_Request
{
    public class HBFOPNJHBCK
    {
        public int PNAAOBECMPA_num_replies; // 0x8
    }
    
	public string ELBFGEBOPLI; // 0x7C

	public HBFOPNJHBCK NFEAMMJIMPG_Result { get; private set; } // 0x80 OHEIOONIIKB LFOJDJCNOHB KMKEGMGKCBA

	// RVA: 0x12028C4 Offset: 0x12028C4 VA: 0x12028C4 Slot: 12
	public override void DHLDNIEELHO()
    {
        EBGACDGNCAA_CallContext = SakashoInquiry.GetInquiryResponsesNumber(ELBFGEBOPLI, this.DCKLDDCAJAP, this.MEOCKCJBDAD);
    }

	// RVA: 0x12029A8 Offset: 0x12029A8 VA: 0x12029A8 Slot: 13
	public override void MGFNKDPHFGI(MonoBehaviour _DANMJLOBLIE_mb)
    {
        EDOHBJAPLPF_JsonData json = IKPIMINCOPI_JsonMapper.PFAMKCGJKKL_ToObject(NGCAIEGPLKD_result);
        NFEAMMJIMPG_Result = new IHKOJFIFPKB_RequestInquiryResponsesNumber.HBFOPNJHBCK();
        NFEAMMJIMPG_Result.PNAAOBECMPA_num_replies = (int)json[AFEHLCGHAEE_Strings.PNAAOBECMPA_num_replies/*num_replies*/];
    }
}
