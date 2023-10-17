
using UnityEngine;

[System.Obsolete("Use KOOKOIOOEAC_IsOnBlacklistOf", true)]
public abstract class KOOKOIOOEAC { }
public class KOOKOIOOEAC_IsOnBlacklistOf : CACGCMBKHDI_Request
{
	public int MLPEHNBNOGD_PlayerId; // 0x7C
	public bool ELCCCJDLLAJ_Blacklisted; // 0x80

	// RVA: 0x113214C Offset: 0x113214C VA: 0x113214C Slot: 12
	public override void DHLDNIEELHO()
	{
		EBGACDGNCAA_CallContext = SakashoPlayerBlacklist.IsOnBlacklistOf(MLPEHNBNOGD_PlayerId, DCKLDDCAJAP, MEOCKCJBDAD);
	}

	// RVA: 0x1132230 Offset: 0x1132230 VA: 0x1132230 Slot: 13
	public override void MGFNKDPHFGI(MonoBehaviour DANMJLOBLIE)
	{
		ELCCCJDLLAJ_Blacklisted = (bool)IKPIMINCOPI_JsonMapper.PFAMKCGJKKL_ToObject(NGCAIEGPLKD_result)["blacklisted"];
	}
}
