
using System.Collections.Generic;
using UnityEngine;

[System.Obsolete("Use NAOOAJGKILJ_GetFriends", true)]
public class NAOOAJGKILJ { }
public class NAOOAJGKILJ_GetFriends : CACGCMBKHDI_Request
{
	public class FOPJAKMNIJM
	{
		public List<CHPIKCFKJOA> HBOIBKJEIAP_friends; // 0x8
		public int HMFFHLPNMPH_count; // 0xC
		public int CJNNMLLEKEF_previous_page; // 0x10
		public int GPPOJHNNINK_current_page; // 0x14
		public int MDIBIIHAAPN_next_page; // 0x18

		// RVA: 0x17C3838 Offset: 0x17C3838 VA: 0x17C3838
		public void KHEKNNFCAOI_Init(EDOHBJAPLPF_JsonData _IDLHJIOMJBK_data)
		{
			EDOHBJAPLPF_JsonData b = _IDLHJIOMJBK_data[AFEHLCGHAEE_Strings.HBOIBKJEIAP_friends];
			HBOIBKJEIAP_friends = new List<CHPIKCFKJOA>(b.HNBFOAJIIAL_Count);
			for(int i = 0; i < b.HNBFOAJIIAL_Count; i++)
			{
				CHPIKCFKJOA data = new CHPIKCFKJOA();
				data.KHEKNNFCAOI_Init(b[i]);
				HBOIBKJEIAP_friends.Add(data);
			}
			HMFFHLPNMPH_count = (int)_IDLHJIOMJBK_data[AFEHLCGHAEE_Strings.HMFFHLPNMPH_count];
			CJNNMLLEKEF_previous_page = (int)_IDLHJIOMJBK_data[AFEHLCGHAEE_Strings.CJNNMLLEKEF_previous_page];
			GPPOJHNNINK_current_page = (int)_IDLHJIOMJBK_data[AFEHLCGHAEE_Strings.GPPOJHNNINK_current_page];
			MDIBIIHAAPN_next_page = (int)_IDLHJIOMJBK_data[AFEHLCGHAEE_Strings.MDIBIIHAAPN_next_page];
		}
	}

	public int IGNIIEBMFIN_Page = 1; // 0x7C
	public int MLPLGFLKKLI_Ipp = CMNGPGIJAKL; // 0x80
	public const int CMNGPGIJAKL = 100;

	public FOPJAKMNIJM NFEAMMJIMPG_Result { get; private set; } // 0x84 OHEIOONIIKB_bgs LFOJDJCNOHB_bgs KMKEGMGKCBA_bgs

	// RVA: 0x17C3660 Offset: 0x17C3660 VA: 0x17C3660 Slot: 12
	public override void DHLDNIEELHO()
	{
		EBGACDGNCAA_CallContext = SakashoFriend.GetFriends(IGNIIEBMFIN_Page, MLPLGFLKKLI_Ipp, DCKLDDCAJAP, MEOCKCJBDAD);
	}

	// RVA: 0x17C3758 Offset: 0x17C3758 VA: 0x17C3758 Slot: 13
	public override void MGFNKDPHFGI(MonoBehaviour _DANMJLOBLIE_mb)
	{
		NFEAMMJIMPG_Result = new FOPJAKMNIJM();
		NFEAMMJIMPG_Result.KHEKNNFCAOI_Init(IKPIMINCOPI_JsonMapper.PFAMKCGJKKL_ToObject(NGCAIEGPLKD_result));
	}
}
