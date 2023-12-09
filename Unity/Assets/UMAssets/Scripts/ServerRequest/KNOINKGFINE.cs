
[System.Obsolete("Use KNOINKGFINE_GetInformationURL", true)]
public class KNOINKGFINE{ }
public class KNOINKGFINE_GetInformationURL : LKFOCCGOINN_GetURL
{
	public bool GIFKEMCNIPC = true; // 0x80

	// RVA: 0x112F4F0 Offset: 0x112F4F0 VA: 0x112F4F0 Slot: 12
	public override void DHLDNIEELHO()
	{
		if (!GIFKEMCNIPC)
			EBGACDGNCAA_CallContext = SakashoSupportSite.GetInformationURL(DCKLDDCAJAP, MEOCKCJBDAD);
		else
			EBGACDGNCAA_CallContext = SakashoSupportSite.BuildUrl("/customized_information", "ja", DCKLDDCAJAP, MEOCKCJBDAD);
	}
}
