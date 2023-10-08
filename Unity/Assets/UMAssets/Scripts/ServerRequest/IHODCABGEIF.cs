
using UnityEngine;

[System.Obsolete("Use IHODCABGEIF_UpdatePlayerCounter", true)]
public class IHODCABGEIF {}
public class IHODCABGEIF_UpdatePlayerCounter : CACGCMBKHDI_Request
{
    public class JLNPNIIEKOJ
    {
        public string IHALNOJAMLE_MasterName; // 0x8
        public int MLPEHNBNOGD_PlayerId; // 0xC
        public int HJFNKLFIDLL_CountDelta; // 0x10
    }

    public class NJJACIPIALM
    {
        public int HIJMPKMMJNA_PlayerCounter; // 0x8
        public int GADKJMMJGGE_EffectiveCountDelta; // 0xC

        // // RVA: 0x1202DE4 Offset: 0x1202DE4 VA: 0x1202DE4
        public void KHEKNNFCAOI(EDOHBJAPLPF_JsonData OBHAFLMHAKG)
        {
            HIJMPKMMJNA_PlayerCounter = (int)OBHAFLMHAKG["player_counter"];
            GADKJMMJGGE_EffectiveCountDelta = (int)OBHAFLMHAKG["effective_count_delta"];
        }
    }

	public JLNPNIIEKOJ BIHCCEHLAOD = new JLNPNIIEKOJ(); // 0x7C
	public NJJACIPIALM NFEAMMJIMPG; // 0x80

	// RVA: 0x1202BBC Offset: 0x1202BBC VA: 0x1202BBC Slot: 12
	public override void DHLDNIEELHO()
    {
        EBGACDGNCAA_CallContext = SakashoPlayerCounter.UpdatePlayerCounter(BIHCCEHLAOD.IHALNOJAMLE_MasterName, BIHCCEHLAOD.MLPEHNBNOGD_PlayerId, BIHCCEHLAOD.HJFNKLFIDLL_CountDelta, DCKLDDCAJAP, MEOCKCJBDAD);
    }

	// // RVA: 0x1202D04 Offset: 0x1202D04 VA: 0x1202D04 Slot: 13
	public override void MGFNKDPHFGI(MonoBehaviour DANMJLOBLIE)
    {
        NFEAMMJIMPG = new NJJACIPIALM();
        NFEAMMJIMPG.KHEKNNFCAOI(IKPIMINCOPI_JsonMapper.PFAMKCGJKKL_ToObject(NGCAIEGPLKD_result));
    }
}
