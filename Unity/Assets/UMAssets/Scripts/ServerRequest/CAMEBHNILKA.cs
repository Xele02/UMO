
using System.Collections.Generic;

[System.Obsolete("Use CAMEBHNILKA_AddToBlacklist", true)]
public class CAMEBHNILKA {}
public class CAMEBHNILKA_AddToBlacklist : CACGCMBKHDI_Request
{
	public List<int> FAMHAPONILI; // 0x7C

	// RVA: 0x18F3EDC Offset: 0x18F3EDC VA: 0x18F3EDC Slot: 12
	public override void DHLDNIEELHO()
    {
        EBGACDGNCAA_CallContext = SakashoPlayerBlacklist.AddToBlacklist(FAMHAPONILI.ToArray(), DCKLDDCAJAP, MEOCKCJBDAD);
    }
}
