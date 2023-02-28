
using UnityEngine;


[System.Obsolete("Use NGADDGLEGAP_GetFriendsLimit", true)]
public class NGADDGLEGAP { }
public class NGADDGLEGAP_GetFriendsLimit : CACGCMBKHDI_Request
{
	public class MJAEAHLDEHE
	{
		public int NHPDJADJNCL_FriendLimit; // 0x8

		// RVA: 0x1AF566C Offset: 0x1AF566C VA: 0x1AF566C
		public void KHEKNNFCAOI(EDOHBJAPLPF_JsonData IDLHJIOMJBK)
		{
			NHPDJADJNCL_FriendLimit = (int)IDLHJIOMJBK[AFEHLCGHAEE_Strings.NHPDJADJNCL_friend_limit];
		}
	}

	public MJAEAHLDEHE NFEAMMJIMPG_ResultData { get; set; } // 0x7C OHEIOONIIKB LFOJDJCNOHB KMKEGMGKCBA

	// RVA: 0x1AF54B0 Offset: 0x1AF54B0 VA: 0x1AF54B0 Slot: 12
	public override void DHLDNIEELHO()
	{
		EBGACDGNCAA_CallContext = SakashoFriend.GetFriendsLimit(DCKLDDCAJAP, MEOCKCJBDAD);
	}

	// RVA: 0x1AF558C Offset: 0x1AF558C VA: 0x1AF558C Slot: 13
	public override void MGFNKDPHFGI(MonoBehaviour DANMJLOBLIE)
	{
		NFEAMMJIMPG_ResultData = new MJAEAHLDEHE();
		NFEAMMJIMPG_ResultData.KHEKNNFCAOI(IKPIMINCOPI_JsonMapper.PFAMKCGJKKL_ToObject(NGCAIEGPLKD_result));
	}
}
