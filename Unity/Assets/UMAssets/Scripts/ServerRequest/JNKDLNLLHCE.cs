
using System.Collections.Generic;
using UnityEngine;

[System.Obsolete("Use JNKDLNLLHCE_ClaimSubscriptionContinuationBonus", true)]
public class JNKDLNLLHCE {}
public class JNKDLNLLHCE_ClaimSubscriptionContinuationBonus : CACGCMBKHDI_Request
{
    public class KHNBILNPGFF
    {
        public List<long> COGMPENEPBD = new List<long>(); // 0x8

        // RVA: 0x1B8FF68 Offset: 0x1B8FF68 VA: 0x1B8FF68
        public void KHEKNNFCAOI(EDOHBJAPLPF_JsonData IDLHJIOMJBK)
        {
            COGMPENEPBD.Clear();
            if(IDLHJIOMJBK.BBAJPINMOEP_Contains(AFEHLCGHAEE_Strings.GLJINGPAEDM_subscription_continuation_bonuses))
            {
                EDOHBJAPLPF_JsonData bonus = IDLHJIOMJBK[AFEHLCGHAEE_Strings.GLJINGPAEDM_subscription_continuation_bonuses];
                for(int i = 0; i < bonus.HNBFOAJIIAL_Count; i++)
                {
                    if(bonus[i].BBAJPINMOEP_Contains(AFEHLCGHAEE_Strings.EGPADBNAOKP_inventory_ids))
                    {
                        EDOHBJAPLPF_JsonData invs = bonus[i][AFEHLCGHAEE_Strings.EGPADBNAOKP_inventory_ids];
                        for(int j = 0; j < invs.HNBFOAJIIAL_Count; j++)
                        {
                            COGMPENEPBD.Add((long)invs[j]);
                        }
                    }
                }
            }
        }
    }

	public KHNBILNPGFF NFEAMMJIMPG; // 0x7C

	// RVA: 0x1B8FD2C Offset: 0x1B8FD2C VA: 0x1B8FD2C Slot: 12
	public override void DHLDNIEELHO()
    {
        EBGACDGNCAA_CallContext = SakashoPlatformPayment.ClaimSubscriptionContinuationBonus(DCKLDDCAJAP, MEOCKCJBDAD);
    }

	// RVA: 0x1B8FE08 Offset: 0x1B8FE08 VA: 0x1B8FE08 Slot: 13
	public override void MGFNKDPHFGI(MonoBehaviour DANMJLOBLIE)
    {
        NFEAMMJIMPG = new KHNBILNPGFF();
        NFEAMMJIMPG.KHEKNNFCAOI(IKPIMINCOPI_JsonMapper.PFAMKCGJKKL_ToObject(NGCAIEGPLKD_result));
    }
}
