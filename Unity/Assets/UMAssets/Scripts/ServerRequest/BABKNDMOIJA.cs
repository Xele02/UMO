
using System.Collections.Generic;
using UnityEngine;

public class BABKNDMOIJA : CACGCMBKHDI_Request
{
	public class IMNICDGDCBB
	{
		public int NPMIJMFMEKB_target_player_id; // 0x8
		public int NEILEPPJKIN_favorite; // 0xC
		public long IFNLEKOILPM_updated_at; // 0x10

		// RVA: 0xF13EE0 Offset: 0xF13EE0 VA: 0xF13EE0
		//public void KHEKNNFCAOI_Init(EDOHBJAPLPF_JsonData _IDLHJIOMJBK_data) { }
		//NPMIJMFMEKB_target_player_id = NPMIJMFMEKB_target_player_id
		//NEILEPPJKIN_favorite = NEILEPPJKIN_favorite
		//IFNLEKOILPM_updated_at = IFNLEKOILPM_updated_at
	}

	public class FCIINFAOJPO
	{
		public List<IMNICDGDCBB> HBOIBKJEIAP_friends; // 0x8

		// RVA: 0xF13E50 Offset: 0xF13E50 VA: 0xF13E50
		//public void KHEKNNFCAOI_Init(EDOHBJAPLPF_JsonData _IDLHJIOMJBK_data) { }
	}

	public const int HDJIHPCCJAF = 0;
	public const int NHJPNAACGLK = 1;
	public List<int> FAMHAPONILI_PlayerIds; // 0x7C
	public int NEILEPPJKIN_favorite = 1; // 0x80

	public FCIINFAOJPO NFEAMMJIMPG_Result { get; private set; } // 0x84 OHEIOONIIKB LFOJDJCNOHB KMKEGMGKCBA

	// RVA: 0xF13C5C Offset: 0xF13C5C VA: 0xF13C5C Slot: 12
	public override void DHLDNIEELHO()
	{
		EBGACDGNCAA_CallContext = SakashoFriend.SetFriendsFavoriteValue(FAMHAPONILI_PlayerIds.ToArray(), NEILEPPJKIN_favorite, DCKLDDCAJAP, MEOCKCJBDAD);
	}

	// RVA: 0xF13D80 Offset: 0xF13D80 VA: 0xF13D80 Slot: 13
	public override void MGFNKDPHFGI(MonoBehaviour _DANMJLOBLIE_mb)
	{
		NFEAMMJIMPG_Result = new FCIINFAOJPO();
	}
}
