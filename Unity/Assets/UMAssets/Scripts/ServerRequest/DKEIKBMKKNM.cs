
using System.Collections.Generic;
using UnityEngine;

[System.Obsolete("Use DKEIKBMKKNM_GetReceivedFriendRequests", true)]
public class DKEIKBMKKNM { }
public class DKEIKBMKKNM_GetReceivedFriendRequests : CACGCMBKHDI_Request
{
	public class ENMCJFCLBPO_PlayerInfo
	{
		public int PPFNGGCBJKC_id; // 0x8
		public long IFNLEKOILPM_UpdatedAt; // 0x10

		// RVA: 0x198F0E0 Offset: 0x198F0E0 VA: 0x198F0E0
		public void KHEKNNFCAOI_Init(EDOHBJAPLPF_JsonData _IDLHJIOMJBK_Data)
		{
			PPFNGGCBJKC_id = (int)_IDLHJIOMJBK_Data[AFEHLCGHAEE_Strings.PPFNGGCBJKC_id];
			IFNLEKOILPM_UpdatedAt = (int)_IDLHJIOMJBK_Data[AFEHLCGHAEE_Strings.IFNLEKOILPM_UpdatedAt];
		}
	}

	public class PODLAHEGOPG_RequestsInfo
	{
		public ENMCJFCLBPO_PlayerInfo NMICBJDPLOH_player; // 0x8
		public long BIOGKIEECGN_CreatedAt; // 0x10
		public long IFNLEKOILPM_UpdatedAt; // 0x18

		// RVA: 0x198EF20 Offset: 0x198EF20 VA: 0x198EF20
		public void KHEKNNFCAOI_Init(EDOHBJAPLPF_JsonData _IDLHJIOMJBK_Data)
		{
			NMICBJDPLOH_player = new ENMCJFCLBPO_PlayerInfo();
			NMICBJDPLOH_player.KHEKNNFCAOI_Init(_IDLHJIOMJBK_Data[AFEHLCGHAEE_Strings.NMICBJDPLOH_player]);
			BIOGKIEECGN_CreatedAt = (int)_IDLHJIOMJBK_Data[AFEHLCGHAEE_Strings.BIOGKIEECGN_CreatedAt];
			IFNLEKOILPM_UpdatedAt = (int)_IDLHJIOMJBK_Data[AFEHLCGHAEE_Strings.IFNLEKOILPM_UpdatedAt];
		}
	}

	public class CHOAECDENAC_ResultData
	{
		public List<PODLAHEGOPG_RequestsInfo> PBHBFBNFPJI_friend_requests; // 0x8
		public int HMFFHLPNMPH_Count; // 0xC
		public int CJNNMLLEKEF_PreviousPage; // 0x10
		public int GPPOJHNNINK_CurrentPage; // 0x14
		public int MDIBIIHAAPN_next_page; // 0x18

		// RVA: 0x198EB38 Offset: 0x198EB38 VA: 0x198EB38
		public void KHEKNNFCAOI_Init(EDOHBJAPLPF_JsonData _IDLHJIOMJBK_Data)
		{
			EDOHBJAPLPF_JsonData requests = _IDLHJIOMJBK_Data[AFEHLCGHAEE_Strings.PBHBFBNFPJI_friend_requests];
			PBHBFBNFPJI_friend_requests = new List<PODLAHEGOPG_RequestsInfo>(requests.HNBFOAJIIAL_Count);
			for(int i = 0; i < requests.HNBFOAJIIAL_Count; i++)
			{
				PODLAHEGOPG_RequestsInfo data = new PODLAHEGOPG_RequestsInfo();
				data.KHEKNNFCAOI_Init(requests[i]);
				PBHBFBNFPJI_friend_requests.Add(data);
			}
			HMFFHLPNMPH_Count = (int)_IDLHJIOMJBK_Data[AFEHLCGHAEE_Strings.HMFFHLPNMPH_Count];
			CJNNMLLEKEF_PreviousPage = (int)_IDLHJIOMJBK_Data[AFEHLCGHAEE_Strings.CJNNMLLEKEF_PreviousPage];
			GPPOJHNNINK_CurrentPage = (int)_IDLHJIOMJBK_Data[AFEHLCGHAEE_Strings.GPPOJHNNINK_CurrentPage];
			MDIBIIHAAPN_next_page = (int)_IDLHJIOMJBK_Data[AFEHLCGHAEE_Strings.MDIBIIHAAPN_next_page];
		}
	}

	public int IGNIIEBMFIN_Page = 1; // 0x7C
	public int MLPLGFLKKLI_Ipp = 30; // 0x80

	public CHOAECDENAC_ResultData NFEAMMJIMPG_Result { get; private set; } // 0x84 OHEIOONIIKB LFOJDJCNOHB KMKEGMGKCBA

	// RVA: 0x198E8E0 Offset: 0x198E8E0 VA: 0x198E8E0 Slot: 12
	public override void DHLDNIEELHO()
	{
		EBGACDGNCAA_CallContext = SakashoFriend.GetReceivedRequests(IGNIIEBMFIN_Page, MLPLGFLKKLI_Ipp, DCKLDDCAJAP, MEOCKCJBDAD);
	}

	// RVA: 0x198E9D8 Offset: 0x198E9D8 VA: 0x198E9D8 Slot: 13
	public override void MGFNKDPHFGI(MonoBehaviour _DANMJLOBLIE_mb)
	{
		NFEAMMJIMPG_Result = new CHOAECDENAC_ResultData();
		NFEAMMJIMPG_Result.KHEKNNFCAOI_Init(IKPIMINCOPI_JsonMapper.PFAMKCGJKKL_ToObject(NGCAIEGPLKD_result));
	}
}
