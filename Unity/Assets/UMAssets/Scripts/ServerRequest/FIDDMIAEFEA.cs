
using System.Collections.Generic;
using UnityEngine;

public class ONKPGLLOJDK
{
	public int JPHDGGNAKMO; // 0x8
	public int FGCAJEAIABA; // 0xC
	public string IPFEKNMBEBI; // 0x10
	public List<MFDJIFIIPJD> HBHMAKNGKFK; // 0x14

	// RVA: 0xCAF520 Offset: 0xCAF520 VA: 0xCAF520
	public void DPKCOKLMFMK(EDOHBJAPLPF_JsonData IDLHJIOMJBK)
	{
		TodoLogger.LogError(0, "ONKPGLLOJDK.DPKCOKLMFMK");
	}
}

public class EECOJKDJIFG : PGCGJPPBOOA
{
	public int KJGHLKIBGGD_UpdateType; // 0x5C
	public List<ONKPGLLOJDK> AHJNPEAMCCH; // 0x60

	// RVA: 0x1C47F74 Offset: 0x1C47F74 VA: 0x1C47F74
	public void KHEKNNFCAOI(EDOHBJAPLPF_JsonData IDLHJIOMJBK)
	{
		DPKCOKLMFMK(IDLHJIOMJBK);
		KJGHLKIBGGD_UpdateType = (int)IDLHJIOMJBK[AFEHLCGHAEE_Strings.KJGHLKIBGGD_update_type];
		AHJNPEAMCCH = new List<ONKPGLLOJDK>(IDLHJIOMJBK[AFEHLCGHAEE_Strings.AHJNPEAMCCH_rewards].HNBFOAJIIAL_Count);
		for(int i = 0; i < IDLHJIOMJBK[AFEHLCGHAEE_Strings.AHJNPEAMCCH_rewards].HNBFOAJIIAL_Count; i++)
		{
			ONKPGLLOJDK data = new ONKPGLLOJDK();
			data.DPKCOKLMFMK(IDLHJIOMJBK[AFEHLCGHAEE_Strings.AHJNPEAMCCH_rewards][i]);
			AHJNPEAMCCH.Add(data);
		}
	}
}

[System.Obsolete("Use FIDDMIAEFEA_GetRankingRecordsByKeys", true)]
public class FIDDMIAEFEA {}
public class FIDDMIAEFEA_GetRankingRecordsByKeys : CACGCMBKHDI_Request
{
    public class HHAPIDPPJJK
    {
        public List<EECOJKDJIFG> JPDPFGFMKHK; // 0x8

        // RVA: 0x14E8B58 Offset: 0x14E8B58 VA: 0x14E8B58
        public void KHEKNNFCAOI(EDOHBJAPLPF_JsonData IDLHJIOMJBK)
		{
			JPDPFGFMKHK = new List<EECOJKDJIFG>(IDLHJIOMJBK["rankings"].HNBFOAJIIAL_Count);
			for(int i = 0; i < IDLHJIOMJBK["rankings"].HNBFOAJIIAL_Count; i++)
			{
				EECOJKDJIFG data = new EECOJKDJIFG();
				data.KHEKNNFCAOI(IDLHJIOMJBK["rankings"][i]);
				JPDPFGFMKHK.Add(data);
			}
		}
    }

	public List<string> JIMKNDJMCID_Keys; // 0x7C
	public HHAPIDPPJJK NFEAMMJIMPG; // 0x80

	public override bool OIDCBBGLPHL { get { return true; } } //0x14E8960 GINMIBJOABO

	// RVA: 0x14E8968 Offset: 0x14E8968 VA: 0x14E8968 Slot: 12
	public override void DHLDNIEELHO()
    {
		EBGACDGNCAA_CallContext = SakashoRanking.GetRankingRecordsByKeys(JIMKNDJMCID_Keys.ToArray(), DCKLDDCAJAP, MEOCKCJBDAD);
	}

	// RVA: 0x14E8A78 Offset: 0x14E8A78 VA: 0x14E8A78 Slot: 13
	public override void MGFNKDPHFGI(MonoBehaviour DANMJLOBLIE)
    {
		NFEAMMJIMPG = new HHAPIDPPJJK();
		NFEAMMJIMPG.KHEKNNFCAOI(IKPIMINCOPI_JsonMapper.PFAMKCGJKKL_ToObject(NGCAIEGPLKD_result));
	}
}
