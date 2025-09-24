
using UnityEngine;

[System.Obsolete("Use IDIEAPJLNGL_SetFriendsLimit", true)]
public class IDIEAPJLNGL { }
public class IDIEAPJLNGL_SetFriendsLimit : CACGCMBKHDI_Request
{
	public class HEHEEIFJAKM
	{
		public int NHPDJADJNCL_friend_limit; // 0x8
		public long IFNLEKOILPM_updated_at; // 0x10

		// RVA: 0x11EB99C Offset: 0x11EB99C VA: 0x11EB99C
		public void KHEKNNFCAOI_Init(EDOHBJAPLPF_JsonData _IDLHJIOMJBK_data)
		{
			NHPDJADJNCL_friend_limit = (int)_IDLHJIOMJBK_data[AFEHLCGHAEE_Strings.NHPDJADJNCL_friend_limit];
			IFNLEKOILPM_updated_at = (int)_IDLHJIOMJBK_data[AFEHLCGHAEE_Strings.IFNLEKOILPM_updated_at];
		}
	}

	public int APOOBGPBNDG_FriendLimit; // 0x7C

	public HEHEEIFJAKM NFEAMMJIMPG_Result { get; set; } // 0x80 OHEIOONIIKB LFOJDJCNOHB KMKEGMGKCBA

	// RVA: 0x11EB7D8 Offset: 0x11EB7D8 VA: 0x11EB7D8 Slot: 12
	public override void DHLDNIEELHO()
	{
		EBGACDGNCAA_CallContext = SakashoFriend.SetFriendsLimit(APOOBGPBNDG_FriendLimit, DCKLDDCAJAP, MEOCKCJBDAD);
	}

	// RVA: 0x11EB8BC Offset: 0x11EB8BC VA: 0x11EB8BC Slot: 13
	public override void MGFNKDPHFGI(MonoBehaviour _DANMJLOBLIE_mb)
	{
		NFEAMMJIMPG_Result = new HEHEEIFJAKM();
		NFEAMMJIMPG_Result.KHEKNNFCAOI_Init(IKPIMINCOPI_JsonMapper.PFAMKCGJKKL_ToObject(NGCAIEGPLKD_result));
	}
}
