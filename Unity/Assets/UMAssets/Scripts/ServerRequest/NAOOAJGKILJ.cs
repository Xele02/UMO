
using System.Collections.Generic;
using UnityEngine;

[System.Obsolete("Use NAOOAJGKILJ_GetFriends", true)]
public class NAOOAJGKILJ { }
public class NAOOAJGKILJ_GetFriends : CACGCMBKHDI_Request
{
	public class FOPJAKMNIJM
	{
		public List<CHPIKCFKJOA> HBOIBKJEIAP_Friends; // 0x8
		public int HMFFHLPNMPH_Count; // 0xC
		public int CJNNMLLEKEF_PreviousPage; // 0x10
		public int GPPOJHNNINK_CurrentPage; // 0x14
		public int MDIBIIHAAPN_NextPage; // 0x18

		// RVA: 0x17C3838 Offset: 0x17C3838 VA: 0x17C3838
		public void KHEKNNFCAOI(EDOHBJAPLPF_JsonData IDLHJIOMJBK)
		{
			EDOHBJAPLPF_JsonData b = IDLHJIOMJBK[AFEHLCGHAEE_Strings.HBOIBKJEIAP_friends];
			HBOIBKJEIAP_Friends = new List<CHPIKCFKJOA>(b.HNBFOAJIIAL_Count);
			for(int i = 0; i < b.HNBFOAJIIAL_Count; i++)
			{
				CHPIKCFKJOA data = new CHPIKCFKJOA();
				data.KHEKNNFCAOI(b[i]);
				HBOIBKJEIAP_Friends.Add(data);
			}
			HMFFHLPNMPH_Count = (int)IDLHJIOMJBK[AFEHLCGHAEE_Strings.HMFFHLPNMPH_count];
			CJNNMLLEKEF_PreviousPage = (int)IDLHJIOMJBK[AFEHLCGHAEE_Strings.CJNNMLLEKEF_previous_page];
			GPPOJHNNINK_CurrentPage = (int)IDLHJIOMJBK[AFEHLCGHAEE_Strings.GPPOJHNNINK_current_page];
			MDIBIIHAAPN_NextPage = (int)IDLHJIOMJBK[AFEHLCGHAEE_Strings.MDIBIIHAAPN_next_page];
		}
	}

	public int IGNIIEBMFIN_Page = 1; // 0x7C
	public int MLPLGFLKKLI_Ipp = CMNGPGIJAKL; // 0x80
	public const int CMNGPGIJAKL = 100;

	public FOPJAKMNIJM NFEAMMJIMPG { get; private set; } // 0x84 OHEIOONIIKB LFOJDJCNOHB KMKEGMGKCBA

	// RVA: 0x17C3660 Offset: 0x17C3660 VA: 0x17C3660 Slot: 12
	public override void DHLDNIEELHO()
	{
		EBGACDGNCAA_CallContext = SakashoFriend.GetFriends(IGNIIEBMFIN_Page, MLPLGFLKKLI_Ipp, DCKLDDCAJAP, MEOCKCJBDAD);
	}

	// RVA: 0x17C3758 Offset: 0x17C3758 VA: 0x17C3758 Slot: 13
	public override void MGFNKDPHFGI(MonoBehaviour DANMJLOBLIE)
	{
		NFEAMMJIMPG = new FOPJAKMNIJM();
		NFEAMMJIMPG.KHEKNNFCAOI(IKPIMINCOPI_JsonMapper.PFAMKCGJKKL_ToObject(NGCAIEGPLKD_result));
	}
}
