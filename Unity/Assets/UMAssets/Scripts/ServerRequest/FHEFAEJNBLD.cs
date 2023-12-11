
using System;
using UnityEngine;

public class FHEFAEJNBLD : CACGCMBKHDI_Request
{
	public class CIBLBLJDJCE
	{
		public int? LCAJFJMHHLG_FriendRequestCount; // 0x8
		public int? IAFEEMCLNMC_FriendCount; // 0x10

		//// RVA: 0x14E7BF8 Offset: 0x14E7BF8 VA: 0x14E7BF8
		public void KHEKNNFCAOI(EDOHBJAPLPF_JsonData IDLHJIOMJBK)
		{
			if (IDLHJIOMJBK.BBAJPINMOEP_Contains(AFEHLCGHAEE_Strings.LCAJFJMHHLG_friend_request_count))
				LCAJFJMHHLG_FriendRequestCount = (int)IDLHJIOMJBK[AFEHLCGHAEE_Strings.LCAJFJMHHLG_friend_request_count];
			if (IDLHJIOMJBK.BBAJPINMOEP_Contains(AFEHLCGHAEE_Strings.IAFEEMCLNMC_friend_count))
				IAFEEMCLNMC_FriendCount = (int)IDLHJIOMJBK[AFEHLCGHAEE_Strings.IAFEEMCLNMC_friend_count];
		}
	}

	public int HPFDEEDLBOA; // 0x7C

	public CIBLBLJDJCE NFEAMMJIMPG { get; private set; } // 0x80 OHEIOONIIKB LFOJDJCNOHB KMKEGMGKCBA

	// RVA: 0x14E7B18 Offset: 0x14E7B18 VA: 0x14E7B18 Slot: 13
	public override void MGFNKDPHFGI(MonoBehaviour DANMJLOBLIE)
	{
		NFEAMMJIMPG = new CIBLBLJDJCE();
		NFEAMMJIMPG.KHEKNNFCAOI(IKPIMINCOPI_JsonMapper.PFAMKCGJKKL_ToObject(NGCAIEGPLKD_result));
	}
}
