
using System.Collections.Generic;
using UnityEngine;

[System.Obsolete("Use KCLELFBECJK_GetSentFriendRequests", true)]
public class KCLELFBECJK { }
public class KCLELFBECJK_GetSentFriendRequests : CACGCMBKHDI_Request
{
	public class CLGDMAEAFJB
	{
		public int PPFNGGCBJKC_id; // 0x8
		public long IFNLEKOILPM_updated_at; // 0x10

		// RVA: 0x1022748 Offset: 0x1022748 VA: 0x1022748
		public void KHEKNNFCAOI_Init(EDOHBJAPLPF_JsonData _IDLHJIOMJBK_data)
		{
			PPFNGGCBJKC_id = (int)_IDLHJIOMJBK_data[AFEHLCGHAEE_Strings.PPFNGGCBJKC_id];
			IFNLEKOILPM_updated_at = (int)_IDLHJIOMJBK_data[AFEHLCGHAEE_Strings.IFNLEKOILPM_updated_at];
		}
	}

	public class OOOBEMOGJAC
	{
		public CLGDMAEAFJB NMICBJDPLOH_player; // 0x8
		public long BIOGKIEECGN_created_at; // 0x10
		public long IFNLEKOILPM_updated_at; // 0x18

		// RVA: 0x1022894 Offset: 0x1022894 VA: 0x1022894
		public void KHEKNNFCAOI_Init(EDOHBJAPLPF_JsonData _IDLHJIOMJBK_data)
		{
			NMICBJDPLOH_player = new CLGDMAEAFJB();
			NMICBJDPLOH_player.KHEKNNFCAOI_Init(_IDLHJIOMJBK_data[AFEHLCGHAEE_Strings.NMICBJDPLOH_player]);
			BIOGKIEECGN_created_at = (int)_IDLHJIOMJBK_data[AFEHLCGHAEE_Strings.BIOGKIEECGN_created_at];
			IFNLEKOILPM_updated_at = (int)_IDLHJIOMJBK_data[AFEHLCGHAEE_Strings.IFNLEKOILPM_updated_at];
		}
	}

	public class LHNDNPMGKDJ
	{
		public List<OOOBEMOGJAC> PBHBFBNFPJI_friend_requests; // 0x8
		public int HMFFHLPNMPH_count; // 0xC
		public int CJNNMLLEKEF_previous_page; // 0x10
		public int GPPOJHNNINK_current_page; // 0x14
		public int MDIBIIHAAPN_next_page; // 0x18

		// RVA: 0x1022368 Offset: 0x1022368 VA: 0x1022368
		public void KHEKNNFCAOI_Init(EDOHBJAPLPF_JsonData _IDLHJIOMJBK_data)
		{
			EDOHBJAPLPF_JsonData f = _IDLHJIOMJBK_data[AFEHLCGHAEE_Strings.PBHBFBNFPJI_friend_requests];
			PBHBFBNFPJI_friend_requests = new List<OOOBEMOGJAC>(f.HNBFOAJIIAL_Count);
			for(int i = 0; i < f.HNBFOAJIIAL_Count; i++)
			{
				OOOBEMOGJAC data = new OOOBEMOGJAC();
				data.KHEKNNFCAOI_Init(f[i]);
				PBHBFBNFPJI_friend_requests.Add(data);
			}
			HMFFHLPNMPH_count = (int)_IDLHJIOMJBK_data[AFEHLCGHAEE_Strings.HMFFHLPNMPH_count];
			CJNNMLLEKEF_previous_page = (int)_IDLHJIOMJBK_data[AFEHLCGHAEE_Strings.CJNNMLLEKEF_previous_page];
			GPPOJHNNINK_current_page = (int)_IDLHJIOMJBK_data[AFEHLCGHAEE_Strings.GPPOJHNNINK_current_page];
			MDIBIIHAAPN_next_page = (int)_IDLHJIOMJBK_data[AFEHLCGHAEE_Strings.MDIBIIHAAPN_next_page];
		}
	}

	public int IGNIIEBMFIN_Page = 1; // 0x7C
	public int MLPLGFLKKLI_Ipp = 30; // 0x80

	public LHNDNPMGKDJ NFEAMMJIMPG_Result { get; private set; } // 0x84 OHEIOONIIKB_bgs LFOJDJCNOHB_bgs KMKEGMGKCBA_bgs

	// RVA: 0x1022190 Offset: 0x1022190 VA: 0x1022190 Slot: 12
	public override void DHLDNIEELHO()
	{
		EBGACDGNCAA_CallContext = SakashoFriend.GetSentRequests(IGNIIEBMFIN_Page, MLPLGFLKKLI_Ipp, DCKLDDCAJAP, MEOCKCJBDAD);
	}

	// RVA: 0x1022288 Offset: 0x1022288 VA: 0x1022288 Slot: 13
	public override void MGFNKDPHFGI(MonoBehaviour _DANMJLOBLIE_mb)
	{
		NFEAMMJIMPG_Result = new LHNDNPMGKDJ();
		NFEAMMJIMPG_Result.KHEKNNFCAOI_Init(IKPIMINCOPI_JsonMapper.PFAMKCGJKKL_ToObject(NGCAIEGPLKD_result));
	}
}
