
using UnityEngine;

[System.Obsolete("Use ONIGGMCFHAL_IsBlacklisted", true)]
public class ONIGGMCFHAL {}
public class ONIGGMCFHAL_IsBlacklisted : CACGCMBKHDI_Request
{
	public int MLPEHNBNOGD_PlayerId; // 0x7C
	public bool ELCCCJDLLAJ_Blacklisted; // 0x80

	// RVA: 0xCAEDBC Offset: 0xCAEDBC VA: 0xCAEDBC Slot: 12
	public override void DHLDNIEELHO()
    {
        EBGACDGNCAA_CallContext = SakashoPlayerBlacklist.IsBlacklisted(MLPEHNBNOGD_PlayerId, DCKLDDCAJAP, MEOCKCJBDAD);
    }

	// RVA: 0xCAEEA0 Offset: 0xCAEEA0 VA: 0xCAEEA0 Slot: 13
	public override void MGFNKDPHFGI(MonoBehaviour _DANMJLOBLIE_mb)
    {
        EDOHBJAPLPF_JsonData data = IKPIMINCOPI_JsonMapper.PFAMKCGJKKL_ToObject(NGCAIEGPLKD_result);
        ELCCCJDLLAJ_Blacklisted = (bool)data["blacklisted"];
    }
}
