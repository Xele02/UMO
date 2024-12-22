
using System.Collections.Generic;
using UnityEngine;

[System.Obsolete("Use PKIPDDGHPLM_IncrementLoginCount", true)]
public class PKIPDDGHPLM { }
public class PKIPDDGHPLM_IncrementLoginCount : CACGCMBKHDI_Request
{
    public class MNIIGPNDJOC
    {
        public List<GMHKBJLIILI> CEBOHGGJBMN_LoginBonuses; // 0x8
        public long CHEAKMNHEAM_LastPlayedAt; // 0x10

        // RVA: 0x93E510 Offset: 0x93E510 VA: 0x93E510
        public void KHEKNNFCAOI(EDOHBJAPLPF_JsonData IDLHJIOMJBK)
        {
            CHEAKMNHEAM_LastPlayedAt = (int)IDLHJIOMJBK[AFEHLCGHAEE_Strings.CHEAKMNHEAM_last_played_at];
            EDOHBJAPLPF_JsonData list = IDLHJIOMJBK[AFEHLCGHAEE_Strings.CEBOHGGJBMN_login_bonuses];
            CEBOHGGJBMN_LoginBonuses = new List<GMHKBJLIILI>(list.HNBFOAJIIAL_Count);
            for(int i = 0; i < list.HNBFOAJIIAL_Count; i++)
            {
                GMHKBJLIILI data = new GMHKBJLIILI();
                data.KHEKNNFCAOI(list[i]);
                CEBOHGGJBMN_LoginBonuses.Add(data);
            }
        }
    }

	public List<int> EAFEGCPEKDC_Ids; // 0x7C

	public MNIIGPNDJOC NFEAMMJIMPG { get; private set; } // 0x80 OHEIOONIIKB LFOJDJCNOHB KMKEGMGKCBA

	// RVA: 0x93E2A8 Offset: 0x93E2A8 VA: 0x93E2A8 Slot: 12
	public override void DHLDNIEELHO()
    {
        if(EAFEGCPEKDC_Ids == null)
        {
            EBGACDGNCAA_CallContext = SakashoLoginBonus.IncrementLoginCount(DCKLDDCAJAP, MEOCKCJBDAD);
        }
        else
        {
            EBGACDGNCAA_CallContext = SakashoLoginBonus.IncrementLoginCount(EAFEGCPEKDC_Ids.ToArray(), DCKLDDCAJAP, MEOCKCJBDAD);
        }
    }

	// RVA: 0x93E430 Offset: 0x93E430 VA: 0x93E430 Slot: 13
	public override void MGFNKDPHFGI(MonoBehaviour DANMJLOBLIE)
    {
        NFEAMMJIMPG = new MNIIGPNDJOC();
        NFEAMMJIMPG.KHEKNNFCAOI(IKPIMINCOPI_JsonMapper.PFAMKCGJKKL_ToObject(NGCAIEGPLKD_result));
    }
}
