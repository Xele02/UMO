
using System.Collections.Generic;
using UnityEngine;

[System.Obsolete("Use DKEIKBMKKNM_GetReceivedFriendRequests", true)]
public class DKEIKBMKKNM { }
public class DKEIKBMKKNM_GetReceivedFriendRequests : CACGCMBKHDI_Request
{
	public class ENMCJFCLBPO_PlayerInfo
	{
		public int PPFNGGCBJKC_Id; // 0x8
		public long IFNLEKOILPM_UpdatedAt; // 0x10

		// RVA: 0x198F0E0 Offset: 0x198F0E0 VA: 0x198F0E0
		public void KHEKNNFCAOI(EDOHBJAPLPF_JsonData IDLHJIOMJBK)
		{
			PPFNGGCBJKC_Id = (int)IDLHJIOMJBK[AFEHLCGHAEE_Strings.PPFNGGCBJKC_Id];
			IFNLEKOILPM_UpdatedAt = (int)IDLHJIOMJBK[AFEHLCGHAEE_Strings.IFNLEKOILPM_updated_at];
		}
	}

	public class PODLAHEGOPG_RequestsInfo
	{
		public ENMCJFCLBPO_PlayerInfo NMICBJDPLOH_Player; // 0x8
		public long BIOGKIEECGN_CreatedAt; // 0x10
		public long IFNLEKOILPM_UpdatedAt; // 0x18

		// RVA: 0x198EF20 Offset: 0x198EF20 VA: 0x198EF20
		public void KHEKNNFCAOI(EDOHBJAPLPF_JsonData IDLHJIOMJBK)
		{
			NMICBJDPLOH_Player = new ENMCJFCLBPO_PlayerInfo();
			NMICBJDPLOH_Player.KHEKNNFCAOI(IDLHJIOMJBK[AFEHLCGHAEE_Strings.NMICBJDPLOH_player]);
			BIOGKIEECGN_CreatedAt = (int)IDLHJIOMJBK[AFEHLCGHAEE_Strings.BIOGKIEECGN_created_at];
			IFNLEKOILPM_UpdatedAt = (int)IDLHJIOMJBK[AFEHLCGHAEE_Strings.IFNLEKOILPM_updated_at];
		}
	}

	public class CHOAECDENAC_ResultData
	{
		public List<PODLAHEGOPG_RequestsInfo> PBHBFBNFPJI_Requests; // 0x8
		public int HMFFHLPNMPH_Count; // 0xC
		public int CJNNMLLEKEF_PreviousPage; // 0x10
		public int GPPOJHNNINK_CurrentPage; // 0x14
		public int MDIBIIHAAPN_NextPage; // 0x18

		// RVA: 0x198EB38 Offset: 0x198EB38 VA: 0x198EB38
		public void KHEKNNFCAOI(EDOHBJAPLPF_JsonData IDLHJIOMJBK)
		{
			EDOHBJAPLPF_JsonData requests = IDLHJIOMJBK[AFEHLCGHAEE_Strings.PBHBFBNFPJI_friend_requests];
			PBHBFBNFPJI_Requests = new List<PODLAHEGOPG_RequestsInfo>(requests.HNBFOAJIIAL_Count);
			for(int i = 0; i < requests.HNBFOAJIIAL_Count; i++)
			{
				PODLAHEGOPG_RequestsInfo data = new PODLAHEGOPG_RequestsInfo();
				data.KHEKNNFCAOI(requests[i]);
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

	public CHOAECDENAC_ResultData NFEAMMJIMPG_ResultData { get; private set; } // 0x84 OHEIOONIIKB LFOJDJCNOHB KMKEGMGKCBA

	// RVA: 0x198E8E0 Offset: 0x198E8E0 VA: 0x198E8E0 Slot: 12
	public override void DHLDNIEELHO()
	{
		EBGACDGNCAA_CallContext = SakashoFriend.GetReceivedRequests(IGNIIEBMFIN_Page, MLPLGFLKKLI_Ipp, DCKLDDCAJAP, MEOCKCJBDAD);
	}

	// RVA: 0x198E9D8 Offset: 0x198E9D8 VA: 0x198E9D8 Slot: 13
	public override void MGFNKDPHFGI(MonoBehaviour DANMJLOBLIE)
	{
		NFEAMMJIMPG_ResultData = new CHOAECDENAC_ResultData();
		NFEAMMJIMPG_ResultData.KHEKNNFCAOI(IKPIMINCOPI_JsonMapper.PFAMKCGJKKL_ToObject(NGCAIEGPLKD_result));
	}
}
