
using System.Collections.Generic;
using UnityEngine;

public class ONKPGLLOJDK
{
	public int JPHDGGNAKMO_high_rank; // 0x8
	public int FGCAJEAIABA_low_rank; // 0xC
	public string IPFEKNMBEBI_inventory_message; // 0x10
	public List<MFDJIFIIPJD> HBHMAKNGKFK_items; // 0x14

	// RVA: 0xCAF520 Offset: 0xCAF520 VA: 0xCAF520
	public void DPKCOKLMFMK(EDOHBJAPLPF_JsonData _IDLHJIOMJBK_data)
	{
		JPHDGGNAKMO_high_rank = (int)_IDLHJIOMJBK_data[AFEHLCGHAEE_Strings.JPHDGGNAKMO_high_rank];
		FGCAJEAIABA_low_rank = (int)_IDLHJIOMJBK_data[AFEHLCGHAEE_Strings.FGCAJEAIABA_low_rank];
		IPFEKNMBEBI_inventory_message = (string)_IDLHJIOMJBK_data[AFEHLCGHAEE_Strings.IPFEKNMBEBI_inventory_message];
        EDOHBJAPLPF_JsonData items = _IDLHJIOMJBK_data[AFEHLCGHAEE_Strings.HBHMAKNGKFK_items];
        HBHMAKNGKFK_items = new List<MFDJIFIIPJD>(items.HNBFOAJIIAL_Count);
		for(int i = 0; i < items.HNBFOAJIIAL_Count; i++)
		{
			MFDJIFIIPJD m = new MFDJIFIIPJD();
			m.KHEKNNFCAOI_Init(items[i]);
			HBHMAKNGKFK_items.Add(m);
		}
	}
}

public class EECOJKDJIFG : PGCGJPPBOOA
{
	public int KJGHLKIBGGD_update_type; // 0x5C
	public List<ONKPGLLOJDK> AHJNPEAMCCH_rewards; // 0x60

	// RVA: 0x1C47F74 Offset: 0x1C47F74 VA: 0x1C47F74
	public void KHEKNNFCAOI_Init(EDOHBJAPLPF_JsonData _IDLHJIOMJBK_data)
	{
		DPKCOKLMFMK(_IDLHJIOMJBK_data);
		KJGHLKIBGGD_update_type = (int)_IDLHJIOMJBK_data[AFEHLCGHAEE_Strings.KJGHLKIBGGD_update_type];
		AHJNPEAMCCH_rewards = new List<ONKPGLLOJDK>(_IDLHJIOMJBK_data[AFEHLCGHAEE_Strings.AHJNPEAMCCH_rewards].HNBFOAJIIAL_Count);
		for(int i = 0; i < _IDLHJIOMJBK_data[AFEHLCGHAEE_Strings.AHJNPEAMCCH_rewards].HNBFOAJIIAL_Count; i++)
		{
			ONKPGLLOJDK data = new ONKPGLLOJDK();
			data.DPKCOKLMFMK(_IDLHJIOMJBK_data[AFEHLCGHAEE_Strings.AHJNPEAMCCH_rewards][i]);
			AHJNPEAMCCH_rewards.Add(data);
		}
	}
}

[System.Obsolete("Use FIDDMIAEFEA_GetRankingRecordsByKeys", true)]
public class FIDDMIAEFEA {}
public class FIDDMIAEFEA_GetRankingRecordsByKeys : CACGCMBKHDI_Request
{
    public class HHAPIDPPJJK
    {
        public List<EECOJKDJIFG> JPDPFGFMKHK_rankings; // 0x8

        // RVA: 0x14E8B58 Offset: 0x14E8B58 VA: 0x14E8B58
        public void KHEKNNFCAOI_Init(EDOHBJAPLPF_JsonData _IDLHJIOMJBK_data)
		{
			JPDPFGFMKHK_rankings = new List<EECOJKDJIFG>(_IDLHJIOMJBK_data["rankings"].HNBFOAJIIAL_Count);
			for(int i = 0; i < _IDLHJIOMJBK_data["rankings"].HNBFOAJIIAL_Count; i++)
			{
				EECOJKDJIFG data = new EECOJKDJIFG();
				data.KHEKNNFCAOI_Init(_IDLHJIOMJBK_data["rankings"][i]);
				JPDPFGFMKHK_rankings.Add(data);
			}
		}
    }

	public List<string> JIMKNDJMCID_Keys; // 0x7C
	public HHAPIDPPJJK NFEAMMJIMPG_Result; // 0x80

	public override bool OIDCBBGLPHL { get { return true; } } //0x14E8960 GINMIBJOABO

	// RVA: 0x14E8968 Offset: 0x14E8968 VA: 0x14E8968 Slot: 12
	public override void DHLDNIEELHO()
    {
		EBGACDGNCAA_CallContext = SakashoRanking.GetRankingRecordsByKeys(JIMKNDJMCID_Keys.ToArray(), DCKLDDCAJAP, MEOCKCJBDAD);
	}

	// RVA: 0x14E8A78 Offset: 0x14E8A78 VA: 0x14E8A78 Slot: 13
	public override void MGFNKDPHFGI(MonoBehaviour _DANMJLOBLIE_mb)
    {
		NFEAMMJIMPG_Result = new HHAPIDPPJJK();
		NFEAMMJIMPG_Result.KHEKNNFCAOI_Init(IKPIMINCOPI_JsonMapper.PFAMKCGJKKL_ToObject(NGCAIEGPLKD_result));
	}
}
