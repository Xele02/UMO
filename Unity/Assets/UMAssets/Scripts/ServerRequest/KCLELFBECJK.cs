
using System.Collections.Generic;
using UnityEngine;

[System.Obsolete("Use KCLELFBECJK_GetSentFriendRequests", true)]
public class KCLELFBECJK { }
public class KCLELFBECJK_GetSentFriendRequests : CACGCMBKHDI_Request
{
	public class CLGDMAEAFJB
	{
		public int PPFNGGCBJKC_Id; // 0x8
		public long IFNLEKOILPM_UpdatedAt; // 0x10

		// RVA: 0x1022748 Offset: 0x1022748 VA: 0x1022748
		public void KHEKNNFCAOI(EDOHBJAPLPF_JsonData IDLHJIOMJBK)
		{
			PPFNGGCBJKC_Id = (int)IDLHJIOMJBK[AFEHLCGHAEE_Strings.PPFNGGCBJKC_Id];
			IFNLEKOILPM_UpdatedAt = (int)IDLHJIOMJBK[AFEHLCGHAEE_Strings.IFNLEKOILPM_updated_at];
		}
	}

	public class OOOBEMOGJAC
	{
		public CLGDMAEAFJB NMICBJDPLOH_Player; // 0x8
		public long BIOGKIEECGN_CreatedAt; // 0x10
		public long IFNLEKOILPM_UpdatedAt; // 0x18

		// RVA: 0x1022894 Offset: 0x1022894 VA: 0x1022894
		public void KHEKNNFCAOI(EDOHBJAPLPF_JsonData IDLHJIOMJBK)
		{
			NMICBJDPLOH_Player = new CLGDMAEAFJB();
			NMICBJDPLOH_Player.KHEKNNFCAOI(IDLHJIOMJBK[AFEHLCGHAEE_Strings.NMICBJDPLOH_player]);
			BIOGKIEECGN_CreatedAt = (int)IDLHJIOMJBK[AFEHLCGHAEE_Strings.BIOGKIEECGN_created_at];
			IFNLEKOILPM_UpdatedAt = (int)IDLHJIOMJBK[AFEHLCGHAEE_Strings.IFNLEKOILPM_updated_at];
		}
	}

	public class LHNDNPMGKDJ
	{
		public List<OOOBEMOGJAC> PBHBFBNFPJI_Requests; // 0x8
		public int HMFFHLPNMPH_Count; // 0xC
		public int CJNNMLLEKEF_PreviousPage; // 0x10
		public int GPPOJHNNINK_CurrentPage; // 0x14
		public int MDIBIIHAAPN_NextPage; // 0x18

		// RVA: 0x1022368 Offset: 0x1022368 VA: 0x1022368
		public void KHEKNNFCAOI(EDOHBJAPLPF_JsonData IDLHJIOMJBK)
		{
			EDOHBJAPLPF_JsonData f = IDLHJIOMJBK[AFEHLCGHAEE_Strings.PBHBFBNFPJI_friend_requests];
			PBHBFBNFPJI_Requests = new List<OOOBEMOGJAC>(f.HNBFOAJIIAL_Count);
			for(int i = 0; i < f.HNBFOAJIIAL_Count; i++)
			{
				OOOBEMOGJAC data = new OOOBEMOGJAC();
				data.KHEKNNFCAOI(f[i]);
				PBHBFBNFPJI_Requests.Add(data);
			}
			HMFFHLPNMPH_Count = (int)IDLHJIOMJBK[AFEHLCGHAEE_Strings.HMFFHLPNMPH_count];
			CJNNMLLEKEF_PreviousPage = (int)IDLHJIOMJBK[AFEHLCGHAEE_Strings.CJNNMLLEKEF_previous_page];
			GPPOJHNNINK_CurrentPage = (int)IDLHJIOMJBK[AFEHLCGHAEE_Strings.GPPOJHNNINK_current_page];
			MDIBIIHAAPN_NextPage = (int)IDLHJIOMJBK[AFEHLCGHAEE_Strings.MDIBIIHAAPN_next_page];
		}
	}

	public int IGNIIEBMFIN_Page = 1; // 0x7C
	public int MLPLGFLKKLI_Ipp = 30; // 0x80

	public LHNDNPMGKDJ NFEAMMJIMPG { get; private set; } // 0x84 OHEIOONIIKB LFOJDJCNOHB KMKEGMGKCBA

	// RVA: 0x1022190 Offset: 0x1022190 VA: 0x1022190 Slot: 12
	public override void DHLDNIEELHO()
	{
		EBGACDGNCAA_CallContext = SakashoFriend.GetSentRequests(IGNIIEBMFIN_Page, MLPLGFLKKLI_Ipp, DCKLDDCAJAP, MEOCKCJBDAD);
	}

	// RVA: 0x1022288 Offset: 0x1022288 VA: 0x1022288 Slot: 13
	public override void MGFNKDPHFGI(MonoBehaviour DANMJLOBLIE)
	{
		NFEAMMJIMPG = new LHNDNPMGKDJ();
		NFEAMMJIMPG.KHEKNNFCAOI(IKPIMINCOPI_JsonMapper.PFAMKCGJKKL_ToObject(NGCAIEGPLKD_result));
	}
}
