
using System.Collections.Generic;

[System.Obsolete("Use PGAHJECLGBB_RemoveFromBlacklist", true)]
public class PGAHJECLGBB { }
public class PGAHJECLGBB_RemoveFromBlacklist : CACGCMBKHDI_Request
{
	public List<int> FAMHAPONILI_PlayerIds; // 0x7C

	// RVA: 0x16C88F4 Offset: 0x16C88F4 VA: 0x16C88F4 Slot: 12
	public override void DHLDNIEELHO()
	{
		EBGACDGNCAA_CallContext = SakashoPlayerBlacklist.RemoveFromBlacklist(FAMHAPONILI_PlayerIds.ToArray(), DCKLDDCAJAP, MEOCKCJBDAD);
	}
}
