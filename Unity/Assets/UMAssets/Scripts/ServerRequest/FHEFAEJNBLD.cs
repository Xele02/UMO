
using System;
using UnityEngine;

public class FHEFAEJNBLD : CACGCMBKHDI_Request
{
	public class CIBLBLJDJCE
	{
		public int? LCAJFJMHHLG_friend_request_count; // 0x8
		public int? IAFEEMCLNMC_friend_count; // 0x10

		//// RVA: 0x14E7BF8 Offset: 0x14E7BF8 VA: 0x14E7BF8
		public void KHEKNNFCAOI_Init(EDOHBJAPLPF_JsonData _IDLHJIOMJBK_data)
		{
			if (_IDLHJIOMJBK_data.BBAJPINMOEP_Contains(AFEHLCGHAEE_Strings.LCAJFJMHHLG_friend_request_count))
				LCAJFJMHHLG_friend_request_count = (int)_IDLHJIOMJBK_data[AFEHLCGHAEE_Strings.LCAJFJMHHLG_friend_request_count];
			if (_IDLHJIOMJBK_data.BBAJPINMOEP_Contains(AFEHLCGHAEE_Strings.IAFEEMCLNMC_friend_count))
				IAFEEMCLNMC_friend_count = (int)_IDLHJIOMJBK_data[AFEHLCGHAEE_Strings.IAFEEMCLNMC_friend_count];
		}
	}

	public int HPFDEEDLBOA; // 0x7C

	public CIBLBLJDJCE NFEAMMJIMPG_Result { get; private set; } // 0x80 OHEIOONIIKB_bgs LFOJDJCNOHB_bgs KMKEGMGKCBA_bgs

	// RVA: 0x14E7B18 Offset: 0x14E7B18 VA: 0x14E7B18 Slot: 13
	public override void MGFNKDPHFGI(MonoBehaviour _DANMJLOBLIE_mb)
	{
		NFEAMMJIMPG_Result = new CIBLBLJDJCE();
		NFEAMMJIMPG_Result.KHEKNNFCAOI_Init(IKPIMINCOPI_JsonMapper.PFAMKCGJKKL_ToObject(NGCAIEGPLKD_result));
	}
}
