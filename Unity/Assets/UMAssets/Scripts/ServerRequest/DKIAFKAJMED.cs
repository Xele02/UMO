
using UnityEngine;

[System.Obsolete("Use DKIAFKAJMED_GetTwitterLinkageStatus", true)]
public class DKIAFKAJMED { }
public class DKIAFKAJMED_GetTwitterLinkageStatus : CACGCMBKHDI_Request
{
	public class BLECILEFEEE
	{
		public bool MKHDOLLACEF_TwitterLinkage; // 0x8

		// RVA: 0x198F944 Offset: 0x198F944 VA: 0x198F944
		public void KHEKNNFCAOI_Init(EDOHBJAPLPF_JsonData _IDLHJIOMJBK_Data)
		{
			MKHDOLLACEF_TwitterLinkage = (bool)_IDLHJIOMJBK_Data["twitter_linkage"];
		}
	}

	public BLECILEFEEE NFEAMMJIMPG_Result { get; private set; } // 0x7C OHEIOONIIKB LFOJDJCNOHB KMKEGMGKCBA

	// RVA: 0x198F788 Offset: 0x198F788 VA: 0x198F788 Slot: 12
	public override void DHLDNIEELHO()
	{
		EBGACDGNCAA_CallContext = SakashoTwitter.GetTwitterLinkageStatus(DCKLDDCAJAP, MEOCKCJBDAD);
	}

	// RVA: 0x198F864 Offset: 0x198F864 VA: 0x198F864 Slot: 13
	public override void MGFNKDPHFGI(MonoBehaviour _DANMJLOBLIE_mb)
	{
		NFEAMMJIMPG_Result = new BLECILEFEEE();
		NFEAMMJIMPG_Result.KHEKNNFCAOI_Init(IKPIMINCOPI_JsonMapper.PFAMKCGJKKL_ToObject(NGCAIEGPLKD_result));
	}
}
