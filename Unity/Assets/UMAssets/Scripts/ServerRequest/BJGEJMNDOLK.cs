
using System.Collections.Generic;
using UnityEngine;

public class CLHMBMLOAOE
{
	private const long BBEGLBMOBOF_xorl = 0x745922765f;//499711637087;
	private long OILIPGICBIK; // 0x8
	private long NJKMDELFJGE; // 0x10

	public long FDFGEMODIIF_StartedAt { get { return OILIPGICBIK ^ BBEGLBMOBOF_xorl; } set { OILIPGICBIK = value ^ BBEGLBMOBOF_xorl; } } //0x1083E48 CBDHPDMLJKB_bgs 0x1083E60 OPBOAMBLLDF_bgs
	public long NKMNFPMMJND_expired_at { get { return NJKMDELFJGE ^ BBEGLBMOBOF_xorl; } set { NJKMDELFJGE = value ^ BBEGLBMOBOF_xorl; } } //0x1083E7C JCDIJBHKGMA_bgs 0x1083E94 FDMBGEAJNPK_bgs

	//// RVA: 0x1083EB0 Offset: 0x1083EB0 VA: 0x1083EB0
	//public void KHEKNNFCAOI_Init(EDOHBJAPLPF_JsonData _IDLHJIOMJBK_data) { }
	//FDFGEMODIIF_StartedAt = started_at
	//NKMNFPMMJND_expired_at = expired_at
}

public class BCEHKBJAEDM
{
	public string FJGCDPLCIAK_unique_key; // 0x8
	public CLHMBMLOAOE LKCCMBEOLLA; // 0xC
	public CLHMBMLOAOE PACPEOKLGCI_Google; // 0x10
	public CLHMBMLOAOE FPIKAFLHBMO_Apple; // 0x14

	//// RVA: 0xF2E4D0 Offset: 0xF2E4D0 VA: 0xF2E4D0
	//public void KHEKNNFCAOI_Init(EDOHBJAPLPF_JsonData _IDLHJIOMJBK_data) { }
	//FJGCDPLCIAK_unique_key = unique_key
	//PACPEOKLGCI_Google = google
	//FPIKAFLHBMO_Apple = apple
}

[System.Obsolete("Use BJGEJMNDOLK_GetSubscriptionStatuses", true)]
public class BJGEJMNDOLK { }
public class BJGEJMNDOLK_GetSubscriptionStatuses : CACGCMBKHDI_NetBaseAction
{
	public class FNFDLMDKONP
	{
		public List<BCEHKBJAEDM> FCABPFLKKBC_subscription_statuses = new List<BCEHKBJAEDM>(); // 0x8

		// RVA: 0xC85A04 Offset: 0xC85A04 VA: 0xC85A04
		public void KHEKNNFCAOI_Init(EDOHBJAPLPF_JsonData _IDLHJIOMJBK_data)
		{
			if(_IDLHJIOMJBK_data.BBAJPINMOEP_Contains("subscription_statuses"))
			{
				TodoLogger.LogError(TodoLogger.MonthlyPass, "Parse Subscription status");
				//FCABPFLKKBC_subscription_statuses = subscription_statuses
			}
		}
	}
	
	public FNFDLMDKONP NFEAMMJIMPG_Result { get; private set; } // 0x7C OHEIOONIIKB_bgs LFOJDJCNOHB_bgs KMKEGMGKCBA_bgs

	// RVA: 0xC857C8 Offset: 0xC857C8 VA: 0xC857C8 Slot: 12
	public override void DHLDNIEELHO()
	{
		EBGACDGNCAA_CallContext = SakashoPlatformPayment.GetSubscriptionStatuses(DCKLDDCAJAP, MEOCKCJBDAD);
	}

	// RVA: 0xC858A4 Offset: 0xC858A4 VA: 0xC858A4 Slot: 13
	public override void MGFNKDPHFGI(MonoBehaviour _DANMJLOBLIE_mb)
	{
		NFEAMMJIMPG_Result = new FNFDLMDKONP();
		NFEAMMJIMPG_Result.KHEKNNFCAOI_Init(IKPIMINCOPI_JsonMapper.PFAMKCGJKKL_ToObject(NGCAIEGPLKD_result));
	}
}
