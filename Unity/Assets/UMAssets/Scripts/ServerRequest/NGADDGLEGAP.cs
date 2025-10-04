
using UnityEngine;


[System.Obsolete("Use NGADDGLEGAP_GetFriendsLimit", true)]
public class NGADDGLEGAP { }
public class NGADDGLEGAP_GetFriendsLimit : CACGCMBKHDI_Request
{
	public class MJAEAHLDEHE
	{
		public int NHPDJADJNCL_friend_limit; // 0x8

		// RVA: 0x1AF566C Offset: 0x1AF566C VA: 0x1AF566C
		public void KHEKNNFCAOI_Init(EDOHBJAPLPF_JsonData _IDLHJIOMJBK_data)
		{
			NHPDJADJNCL_friend_limit = (int)_IDLHJIOMJBK_data[AFEHLCGHAEE_Strings.NHPDJADJNCL_friend_limit];
		}
	}

	public MJAEAHLDEHE NFEAMMJIMPG_Result { get; set; } // 0x7C OHEIOONIIKB_bgs LFOJDJCNOHB_bgs KMKEGMGKCBA_bgs

	// RVA: 0x1AF54B0 Offset: 0x1AF54B0 VA: 0x1AF54B0 Slot: 12
	public override void DHLDNIEELHO()
	{
		EBGACDGNCAA_CallContext = SakashoFriend.GetFriendsLimit(DCKLDDCAJAP, MEOCKCJBDAD);
	}

	// RVA: 0x1AF558C Offset: 0x1AF558C VA: 0x1AF558C Slot: 13
	public override void MGFNKDPHFGI(MonoBehaviour _DANMJLOBLIE_mb)
	{
		NFEAMMJIMPG_Result = new MJAEAHLDEHE();
		NFEAMMJIMPG_Result.KHEKNNFCAOI_Init(IKPIMINCOPI_JsonMapper.PFAMKCGJKKL_ToObject(NGCAIEGPLKD_result));
	}
}
