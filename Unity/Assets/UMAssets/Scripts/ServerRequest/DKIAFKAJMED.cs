
using UnityEngine;

[System.Obsolete("Use DKIAFKAJMED_GetTwitterLinkageStatus", true)]
public class DKIAFKAJMED { }
public class DKIAFKAJMED_GetTwitterLinkageStatus : CACGCMBKHDI_Request
{
	public class BLECILEFEEE
	{
		public bool MKHDOLLACEF_TwitterLinkage; // 0x8

		// RVA: 0x198F944 Offset: 0x198F944 VA: 0x198F944
		public void KHEKNNFCAOI(EDOHBJAPLPF_JsonData IDLHJIOMJBK)
		{
			MKHDOLLACEF_TwitterLinkage = (bool)IDLHJIOMJBK["twitter_linkage"];
		}
	}

	public BLECILEFEEE NFEAMMJIMPG { get; private set; } // 0x7C OHEIOONIIKB LFOJDJCNOHB KMKEGMGKCBA

	// RVA: 0x198F788 Offset: 0x198F788 VA: 0x198F788 Slot: 12
	public override void DHLDNIEELHO()
	{
		EBGACDGNCAA_CallContext = SakashoTwitter.GetTwitterLinkageStatus(DCKLDDCAJAP, MEOCKCJBDAD);
	}

	// RVA: 0x198F864 Offset: 0x198F864 VA: 0x198F864 Slot: 13
	public override void MGFNKDPHFGI(MonoBehaviour DANMJLOBLIE)
	{
		NFEAMMJIMPG = new BLECILEFEEE();
		NFEAMMJIMPG.KHEKNNFCAOI(IKPIMINCOPI_JsonMapper.PFAMKCGJKKL_ToObject(NGCAIEGPLKD_result));
	}
}
