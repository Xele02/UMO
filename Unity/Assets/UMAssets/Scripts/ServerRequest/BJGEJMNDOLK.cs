
using System.Collections.Generic;
using UnityEngine;

public class CLHMBMLOAOE
{
	private const long BBEGLBMOBOF = 499711637087;
	private long OILIPGICBIK; // 0x8
	private long NJKMDELFJGE; // 0x10

	//public long FDFGEMODIIF { get; set; } 0x1083E48 CBDHPDMLJKB 0x1083E60 OPBOAMBLLDF
	//public long NKMNFPMMJND { get; set; } 0x1083E7C JCDIJBHKGMA 0x1083E94 FDMBGEAJNPK

	//// RVA: 0x1083EB0 Offset: 0x1083EB0 VA: 0x1083EB0
	//public void KHEKNNFCAOI(EDOHBJAPLPF IDLHJIOMJBK) { }
}

public class BCEHKBJAEDM
{
	public string FJGCDPLCIAK; // 0x8
	public CLHMBMLOAOE LKCCMBEOLLA; // 0xC
	public CLHMBMLOAOE PACPEOKLGCI; // 0x10
	public CLHMBMLOAOE FPIKAFLHBMO; // 0x14

	//// RVA: 0xF2E4D0 Offset: 0xF2E4D0 VA: 0xF2E4D0
	//public void KHEKNNFCAOI(EDOHBJAPLPF IDLHJIOMJBK) { }
}

[System.Obsolete("Use BJGEJMNDOLK_GetSubscriptionStatuses", true)]
public class BJGEJMNDOLK { }
public class BJGEJMNDOLK_GetSubscriptionStatuses : CACGCMBKHDI_Request
{
	public class FNFDLMDKONP
	{
		public List<BCEHKBJAEDM> FCABPFLKKBC = new List<BCEHKBJAEDM>(); // 0x8

		// RVA: 0xC85A04 Offset: 0xC85A04 VA: 0xC85A04
		public void KHEKNNFCAOI(EDOHBJAPLPF_JsonData IDLHJIOMJBK)
		{
			if(IDLHJIOMJBK.BBAJPINMOEP_Contains("subscription_statuses"))
			{
				TodoLogger.Log(0, "Parse Subscription status");
			}
		}
	}
	
	public FNFDLMDKONP NFEAMMJIMPG { get; private set; } // 0x7C OHEIOONIIKB LFOJDJCNOHB KMKEGMGKCBA

	// RVA: 0xC857C8 Offset: 0xC857C8 VA: 0xC857C8 Slot: 12
	public override void DHLDNIEELHO()
	{
		EBGACDGNCAA_CallContext = SakashoPlatformPayment.GetSubscriptionStatuses(DCKLDDCAJAP, MEOCKCJBDAD);
	}

	// RVA: 0xC858A4 Offset: 0xC858A4 VA: 0xC858A4 Slot: 13
	public override void MGFNKDPHFGI(MonoBehaviour DANMJLOBLIE)
	{
		NFEAMMJIMPG = new FNFDLMDKONP();
		NFEAMMJIMPG.KHEKNNFCAOI(IKPIMINCOPI_JsonMapper.PFAMKCGJKKL_ToObject(NGCAIEGPLKD_result));
	}
}
