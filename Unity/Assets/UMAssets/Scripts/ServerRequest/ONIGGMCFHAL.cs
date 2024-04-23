
using UnityEngine;

[System.Obsolete("Use ONIGGMCFHAL_IsBlacklisted", true)]
public class ONIGGMCFHAL {}
public class ONIGGMCFHAL_IsBlacklisted : CACGCMBKHDI_Request
{
	public int MLPEHNBNOGD; // 0x7C
	public bool ELCCCJDLLAJ; // 0x80

	// RVA: 0xCAEDBC Offset: 0xCAEDBC VA: 0xCAEDBC Slot: 12
	public override void DHLDNIEELHO()
    {
        EBGACDGNCAA_CallContext = SakashoPlayerBlacklist.IsBlacklisted(MLPEHNBNOGD, DCKLDDCAJAP, MEOCKCJBDAD);
    }

	// RVA: 0xCAEEA0 Offset: 0xCAEEA0 VA: 0xCAEEA0 Slot: 13
	public override void MGFNKDPHFGI(MonoBehaviour DANMJLOBLIE)
    {
        EDOHBJAPLPF_JsonData data = IKPIMINCOPI_JsonMapper.PFAMKCGJKKL_ToObject(NGCAIEGPLKD_result);
        ELCCCJDLLAJ = (bool)data["blacklisted"];
    }
}
