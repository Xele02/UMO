
using System.Collections.Generic;
using UnityEngine;
using XeSys;

public class IBBBOJEGGLE
{
	public int EHGBICNIBKE_PlayerId; // 0x8
	public int EAIMNLAMBFJ_CreatedAt; // 0xC
	public long BIOGKIEECGN_CreatedBy; // 0x10
}

[System.Obsolete("Use DPMKJDMNDNN_GetBlackList", true)]
public class DPMKJDMNDNN { }
public class DPMKJDMNDNN_GetBlackList : CACGCMBKHDI_Request
{
	public class NOFBHALLIMD
	{
		public int HMFFHLPNMPH_Count; // 0x8
		public int MDIBIIHAAPN_NextPage; // 0xC
		public int GPPOJHNNINK_CurrentPage; // 0x10
		public int CJNNMLLEKEF_PreviousPage; // 0x14
		public List<IBBBOJEGGLE> FOCOFKEFHIO_BlackList; // 0x18

		// RVA: 0x1235684 Offset: 0x1235684 VA: 0x1235684
		public void KHEKNNFCAOI(EDOHBJAPLPF_JsonData IDLHJIOMJBK)
		{
			FOCOFKEFHIO_BlackList = new List<IBBBOJEGGLE>(IDLHJIOMJBK["player_blacklist"].HNBFOAJIIAL_Count);
			for(int i = 0; i < IDLHJIOMJBK["player_blacklist"].HNBFOAJIIAL_Count; i++)
			{
				EDOHBJAPLPF_JsonData jsonData = IDLHJIOMJBK["player_blacklist"][i];
				IBBBOJEGGLE data = new IBBBOJEGGLE();
				data.EHGBICNIBKE_PlayerId = JsonUtil.GetInt(jsonData, "player_id", 0);
				data.EAIMNLAMBFJ_CreatedAt = JsonUtil.GetInt(jsonData, "created_at", 0);
				data.BIOGKIEECGN_CreatedBy = JsonUtil.GetLong(jsonData, "created_by", 0);
				FOCOFKEFHIO_BlackList.Add(data);
			}
			HMFFHLPNMPH_Count = JsonUtil.GetInt(IDLHJIOMJBK, "count", 0);
			MDIBIIHAAPN_NextPage = JsonUtil. GetInt(IDLHJIOMJBK, "next_page", 0);
			GPPOJHNNINK_CurrentPage = JsonUtil.GetInt(IDLHJIOMJBK, "current_page", 0);
			CJNNMLLEKEF_PreviousPage = JsonUtil.GetInt(IDLHJIOMJBK, "previous_page", 0);
		}
	}

	public int IGNIIEBMFIN_Page = 1; // 0x7C
	public int MLPLGFLKKLI_Ipp = 30; // 0x80
	public NOFBHALLIMD NFEAMMJIMPG; // 0x84

	// RVA: 0x12354AC Offset: 0x12354AC VA: 0x12354AC Slot: 12
	public override void DHLDNIEELHO()
	{
		EBGACDGNCAA_CallContext = SakashoPlayerBlacklist.GetBlacklist(IGNIIEBMFIN_Page, MLPLGFLKKLI_Ipp, DCKLDDCAJAP, MEOCKCJBDAD);
	}

	// RVA: 0x12355A4 Offset: 0x12355A4 VA: 0x12355A4 Slot: 13
	public override void MGFNKDPHFGI(MonoBehaviour DANMJLOBLIE)
	{
		NFEAMMJIMPG = new NOFBHALLIMD();
		NFEAMMJIMPG.KHEKNNFCAOI(IKPIMINCOPI_JsonMapper.PFAMKCGJKKL_ToObject(NGCAIEGPLKD_result));
	}
}
