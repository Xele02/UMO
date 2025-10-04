
using System.Collections.Generic;
using UnityEngine;

[System.Obsolete("Use PKIPDDGHPLM_IncrementLoginCount", true)]
public class PKIPDDGHPLM { }
public class PKIPDDGHPLM_IncrementLoginCount : CACGCMBKHDI_Request
{
    public class MNIIGPNDJOC
    {
        public List<GMHKBJLIILI> CEBOHGGJBMN_login_bonuses; // 0x8
        public long CHEAKMNHEAM_last_played_at; // 0x10

        // RVA: 0x93E510 Offset: 0x93E510 VA: 0x93E510
        public void KHEKNNFCAOI_Init(EDOHBJAPLPF_JsonData _IDLHJIOMJBK_data)
        {
            CHEAKMNHEAM_last_played_at = (int)_IDLHJIOMJBK_data[AFEHLCGHAEE_Strings.CHEAKMNHEAM_last_played_at];
            EDOHBJAPLPF_JsonData list = _IDLHJIOMJBK_data[AFEHLCGHAEE_Strings.CEBOHGGJBMN_login_bonuses];
            CEBOHGGJBMN_login_bonuses = new List<GMHKBJLIILI>(list.HNBFOAJIIAL_Count);
            for(int i = 0; i < list.HNBFOAJIIAL_Count; i++)
            {
                GMHKBJLIILI data = new GMHKBJLIILI();
                data.KHEKNNFCAOI_Init(list[i]);
                CEBOHGGJBMN_login_bonuses.Add(data);
            }
        }
    }

	public List<int> EAFEGCPEKDC_Ids; // 0x7C

	public MNIIGPNDJOC NFEAMMJIMPG_Result { get; private set; } // 0x80 OHEIOONIIKB_bgs LFOJDJCNOHB_bgs KMKEGMGKCBA_bgs

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
	public override void MGFNKDPHFGI(MonoBehaviour _DANMJLOBLIE_mb)
    {
        NFEAMMJIMPG_Result = new MNIIGPNDJOC();
        NFEAMMJIMPG_Result.KHEKNNFCAOI_Init(IKPIMINCOPI_JsonMapper.PFAMKCGJKKL_ToObject(NGCAIEGPLKD_result));
    }
}
