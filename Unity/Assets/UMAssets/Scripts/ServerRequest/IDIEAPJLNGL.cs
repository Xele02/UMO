
using UnityEngine;

[System.Obsolete("Use IDIEAPJLNGL_SetFriendsLimit", true)]
public class IDIEAPJLNGL { }
public class IDIEAPJLNGL_SetFriendsLimit : CACGCMBKHDI_Request
{
	public class HEHEEIFJAKM
	{
		public int NHPDJADJNCL_FriendLimit; // 0x8
		public long IFNLEKOILPM_UpdatedAt; // 0x10

		// RVA: 0x11EB99C Offset: 0x11EB99C VA: 0x11EB99C
		public void KHEKNNFCAOI(EDOHBJAPLPF_JsonData IDLHJIOMJBK)
		{
			NHPDJADJNCL_FriendLimit = (int)IDLHJIOMJBK[AFEHLCGHAEE_Strings.NHPDJADJNCL_friend_limit];
			IFNLEKOILPM_UpdatedAt = (int)IDLHJIOMJBK[AFEHLCGHAEE_Strings.IFNLEKOILPM_updated_at];
		}
	}

	public int APOOBGPBNDG_FriendLimit; // 0x7C

	public HEHEEIFJAKM NFEAMMJIMPG_ResultData { get; set; } // 0x80 OHEIOONIIKB LFOJDJCNOHB KMKEGMGKCBA

	// RVA: 0x11EB7D8 Offset: 0x11EB7D8 VA: 0x11EB7D8 Slot: 12
	public override void DHLDNIEELHO()
	{
		EBGACDGNCAA_CallContext = SakashoFriend.SetFriendsLimit(APOOBGPBNDG_FriendLimit, DCKLDDCAJAP, MEOCKCJBDAD);
	}

	// RVA: 0x11EB8BC Offset: 0x11EB8BC VA: 0x11EB8BC Slot: 13
	public override void MGFNKDPHFGI(MonoBehaviour DANMJLOBLIE)
	{
		NFEAMMJIMPG_ResultData = new HEHEEIFJAKM();
		NFEAMMJIMPG_ResultData.KHEKNNFCAOI(IKPIMINCOPI_JsonMapper.PFAMKCGJKKL_ToObject(NGCAIEGPLKD_result));
	}
}
