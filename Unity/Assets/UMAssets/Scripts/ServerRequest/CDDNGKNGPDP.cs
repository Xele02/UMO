
using System.Collections.Generic;

[System.Obsolete("Use CDDNGKNGPDP_NgWordsValidate", true)]
public class CDDNGKNGPDP { }
public class CDDNGKNGPDP_NgWordsValidate : CACGCMBKHDI_Request
{
	public Dictionary<string, string> LGFLNOJDHHC = new Dictionary<string, string>(); // 0x7C

	// RVA: 0x12AEC10 Offset: 0x12AEC10 VA: 0x12AEC10 Slot: 12
	public override void DHLDNIEELHO()
	{
		EBGACDGNCAA_CallContext = SakashoNgWords.Validate(LGFLNOJDHHC, DCKLDDCAJAP, MEOCKCJBDAD);
	}
}
