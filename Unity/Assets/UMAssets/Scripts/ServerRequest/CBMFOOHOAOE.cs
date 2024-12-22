
using UnityEngine;

[System.Obsolete("Use CBMFOOHOAOE_Purchase", true)]
public class CBMFOOHOAOE {}
public class CBMFOOHOAOE_Purchase : CACGCMBKHDI_Request
{
	public int AFKAGFOFAHM_ProductId; // 0x7C
	public int BPNPBJALGHM_Quantity; // 0x80
	public int APHNELOFGAK_CurrencyId = 2; // 0x84
	public int LGEKLPJFJEI_TotalCurrency; // 0x88
	public int ICKAMKNDAEB_Label; // 0x8C
	public int LHMIIJEALCA_Type; // 0x90
	public bool JJHCNJKPAOK; // 0x94

	public BEAOCBFAHKF NFEAMMJIMPG { get; set; } // 0x98 OHEIOONIIKB LFOJDJCNOHB KMKEGMGKCBA

	// RVA: 0x18F88A0 Offset: 0x18F88A0 VA: 0x18F88A0 Slot: 12
	public override void DHLDNIEELHO()
    {
        EBGACDGNCAA_CallContext = SakashoPayment.Purchase(AFKAGFOFAHM_ProductId, BPNPBJALGHM_Quantity, APHNELOFGAK_CurrencyId, DCKLDDCAJAP, MEOCKCJBDAD);
    }

	// RVA: 0x18F8990 Offset: 0x18F8990 VA: 0x18F8990 Slot: 13
	public override void MGFNKDPHFGI(MonoBehaviour DANMJLOBLIE)
    {
        BEAOCBFAHKF data = new BEAOCBFAHKF();
        data.KHEKNNFCAOI(IKPIMINCOPI_JsonMapper.PFAMKCGJKKL_ToObject(NGCAIEGPLKD_result));
        NFEAMMJIMPG = data;
    }
}
