
using System.Collections.Generic;
using UnityEngine;
using XeSys;

public class NFBNDLNCHMG
{
	public string KKDHGJGDCCK_PlayerCounterMasterName; // 0x8
	public int EHGBICNIBKE_PlayerId; // 0xC
	public long KKPOJIAKIII_PlayerCount; // 0x10
	public int BBAPLGHKEHP_CountDelta; // 0x18
	public int GADKJMMJGGE_EffectiveCountDelta; // 0x1C

	// RVA: 0x1AE98CC Offset: 0x1AE98CC VA: 0x1AE98CC
	public void KHEKNNFCAOI(EDOHBJAPLPF_JsonData OBHAFLMHAKG)
    {
        KKDHGJGDCCK_PlayerCounterMasterName = (string)OBHAFLMHAKG["player_counter_master_name"];
        EHGBICNIBKE_PlayerId = (int)OBHAFLMHAKG["player_id"];
        KKPOJIAKIII_PlayerCount = JsonUtil.GetLong(OBHAFLMHAKG["player_count"]);
        BBAPLGHKEHP_CountDelta = (int)OBHAFLMHAKG["count_delta"];
        GADKJMMJGGE_EffectiveCountDelta = (int)OBHAFLMHAKG["effective_count_delta"];
    }
}

public class KMHEIPCJHOB
{
	public string KKDHGJGDCCK_PlayerCounterMasterName; // 0x8
	public int EHGBICNIBKE_PlayerId; // 0xC
	public string EJJNDLJIIIF_ErrorCode; // 0x10

	// RVA: 0x111D9F0 Offset: 0x111D9F0 VA: 0x111D9F0
	public void KHEKNNFCAOI(EDOHBJAPLPF_JsonData OBHAFLMHAKG)
    {
        KKDHGJGDCCK_PlayerCounterMasterName = (string)OBHAFLMHAKG["player_counter_master_name"];
        EHGBICNIBKE_PlayerId = (int)OBHAFLMHAKG["player_id"];
        EJJNDLJIIIF_ErrorCode = (string)OBHAFLMHAKG["error_code"];
    }
}

[System.Obsolete("Use AJMCNLILIFG_UpdatePlayerCounters", true)]
public class AJMCNLILIFG {}
public class AJMCNLILIFG_UpdatePlayerCounters : CACGCMBKHDI_Request
{
    public class BAKPFHFBOND
    {
        public List<NFBNDLNCHMG> MEOGLBGCOID = new List<NFBNDLNCHMG>(); // 0x8
        public List<KMHEIPCJHOB> BFPPMMKPNHA = new List<KMHEIPCJHOB>(); // 0xC

        // RVA: 0xCD2808 Offset: 0xCD2808 VA: 0xCD2808
        public void KHEKNNFCAOI(EDOHBJAPLPF_JsonData OBHAFLMHAKG)
        {
            if(OBHAFLMHAKG.BBAJPINMOEP_Contains("counter_update_result"))
            {
                EDOHBJAPLPF_JsonData data = OBHAFLMHAKG["counter_update_result"];
                for(int i = 0; i < data.HNBFOAJIIAL_Count; i++)
                {
                    NFBNDLNCHMG d = new NFBNDLNCHMG();
                    d.KHEKNNFCAOI(data[i]);
                    MEOGLBGCOID.Add(d);
                }
            }
            if(OBHAFLMHAKG.BBAJPINMOEP_Contains("counter_update_failures"))
            {
                EDOHBJAPLPF_JsonData data = OBHAFLMHAKG["counter_update_failures"];
                for(int i = 0; i < data.HNBFOAJIIAL_Count; i++)
                {
                    KMHEIPCJHOB d = new KMHEIPCJHOB();
                    d.KHEKNNFCAOI(data[i]);
                    BFPPMMKPNHA.Add(d);
                }
            }
        }
    }

	public List<SakashoPlayerCounterInfo> KAPNGHDIGPD; // 0x7C
	public BAKPFHFBOND NFEAMMJIMPG; // 0x80

	// RVA: 0xCD2564 Offset: 0xCD2564 VA: 0xCD2564 Slot: 12
	public override void DHLDNIEELHO()
    {
        EBGACDGNCAA_CallContext = SakashoPlayerCounter.UpdatePlayerCounters(KAPNGHDIGPD.ToArray(), DCKLDDCAJAP, MEOCKCJBDAD);
    }

	// RVA: 0xCD2674 Offset: 0xCD2674 VA: 0xCD2674 Slot: 13
	public override void MGFNKDPHFGI(MonoBehaviour DANMJLOBLIE)
    {
        NFEAMMJIMPG = new BAKPFHFBOND();
        NFEAMMJIMPG.KHEKNNFCAOI(IKPIMINCOPI_JsonMapper.PFAMKCGJKKL_ToObject(NGCAIEGPLKD_result));
    }
}
