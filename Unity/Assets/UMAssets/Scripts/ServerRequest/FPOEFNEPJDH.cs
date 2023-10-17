
using UnityEngine;

[System.Obsolete("Use FPOEFNEPJDH_CreateBbsThread", true)]
public abstract class FPOEFNEPJDH { }
public class FPOEFNEPJDH_CreateBbsThread : CACGCMBKHDI_Request
{
	public class OIPIPIHBJFM
	{
		public int LIBHMBKLMHF_ThreadId; // 0x8

		//// RVA: 0x13FC104 Offset: 0x13FC104 VA: 0x13FC104
		public void KHEKNNFCAOI(EDOHBJAPLPF_JsonData OBHAFLMHAKG)
		{
			LIBHMBKLMHF_ThreadId = (int)OBHAFLMHAKG["thread_id"];
		}
	}

	public const int MOKKGEKEOIG = 60;
	public SakashoBbsThreadInfo KOGBMDOONFA; // 0x7C
	public OIPIPIHBJFM NFEAMMJIMPG; // 0x80

	// RVA: 0x13FBF40 Offset: 0x13FBF40 VA: 0x13FBF40 Slot: 12
	public override void DHLDNIEELHO()
	{
		EBGACDGNCAA_CallContext = SakashoBbs.CreateThread(KOGBMDOONFA, DCKLDDCAJAP, MEOCKCJBDAD);
	}

	// RVA: 0x13FC024 Offset: 0x13FC024 VA: 0x13FC024 Slot: 13
	public override void MGFNKDPHFGI(MonoBehaviour DANMJLOBLIE)
	{
		NFEAMMJIMPG = new OIPIPIHBJFM();
		NFEAMMJIMPG.KHEKNNFCAOI(IKPIMINCOPI_JsonMapper.PFAMKCGJKKL_ToObject(NGCAIEGPLKD_result));
	}
}
