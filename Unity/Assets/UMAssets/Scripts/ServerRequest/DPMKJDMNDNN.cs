
using System.Collections.Generic;
using UnityEngine;
using XeSys;

public class IBBBOJEGGLE
{
	public int EHGBICNIBKE_player_id; // 0x8
	public int EAIMNLAMBFJ_CreatedAt; // 0xC
	public long BIOGKIEECGN_created_at; // 0x10
}

[System.Obsolete("Use DPMKJDMNDNN_GetBlackList", true)]
public class DPMKJDMNDNN { }
public class DPMKJDMNDNN_GetBlackList : CACGCMBKHDI_NetBaseAction
{
	public class NOFBHALLIMD
	{
		public int HMFFHLPNMPH_count; // 0x8
		public int MDIBIIHAAPN_next_page; // 0xC
		public int GPPOJHNNINK_current_page; // 0x10
		public int CJNNMLLEKEF_previous_page; // 0x14
		public List<IBBBOJEGGLE> FOCOFKEFHIO_BlackList; // 0x18

		// RVA: 0x1235684 Offset: 0x1235684 VA: 0x1235684
		public void KHEKNNFCAOI_Init(EDOHBJAPLPF_JsonData _IDLHJIOMJBK_data)
		{
			FOCOFKEFHIO_BlackList = new List<IBBBOJEGGLE>(_IDLHJIOMJBK_data["player_blacklist"].HNBFOAJIIAL_Count);
			for(int i = 0; i < _IDLHJIOMJBK_data["player_blacklist"].HNBFOAJIIAL_Count; i++)
			{
				EDOHBJAPLPF_JsonData jsonData = _IDLHJIOMJBK_data["player_blacklist"][i];
				IBBBOJEGGLE data = new IBBBOJEGGLE();
				data.EHGBICNIBKE_player_id = JsonUtil.GetInt(jsonData, "player_id", 0);
				data.EAIMNLAMBFJ_CreatedAt = JsonUtil.GetInt(jsonData, "created_at", 0);
				data.BIOGKIEECGN_created_at = JsonUtil.GetLong(jsonData, "created_by", 0);
				FOCOFKEFHIO_BlackList.Add(data);
			}
			HMFFHLPNMPH_count = JsonUtil.GetInt(_IDLHJIOMJBK_data, "count", 0);
			MDIBIIHAAPN_next_page = JsonUtil. GetInt(_IDLHJIOMJBK_data, "next_page", 0);
			GPPOJHNNINK_current_page = JsonUtil.GetInt(_IDLHJIOMJBK_data, "current_page", 0);
			CJNNMLLEKEF_previous_page = JsonUtil.GetInt(_IDLHJIOMJBK_data, "previous_page", 0);
		}
	}

	public int IGNIIEBMFIN_Page = 1; // 0x7C
	public int MLPLGFLKKLI_Ipp = 30; // 0x80
	public NOFBHALLIMD NFEAMMJIMPG_Result; // 0x84

	// RVA: 0x12354AC Offset: 0x12354AC VA: 0x12354AC Slot: 12
	public override void DHLDNIEELHO()
	{
		EBGACDGNCAA_CallContext = SakashoPlayerBlacklist.GetBlacklist(IGNIIEBMFIN_Page, MLPLGFLKKLI_Ipp, DCKLDDCAJAP, MEOCKCJBDAD);
	}

	// RVA: 0x12355A4 Offset: 0x12355A4 VA: 0x12355A4 Slot: 13
	public override void MGFNKDPHFGI(MonoBehaviour _DANMJLOBLIE_mb)
	{
		NFEAMMJIMPG_Result = new NOFBHALLIMD();
		NFEAMMJIMPG_Result.KHEKNNFCAOI_Init(IKPIMINCOPI_JsonMapper.PFAMKCGJKKL_ToObject(NGCAIEGPLKD_result));
	}
}
