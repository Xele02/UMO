
using System.Collections.Generic;
using UnityEngine;

[System.Obsolete("Use MMCLJMPEFEP_GetBbsThreads", true)]
public abstract class MMCLJMPEFEP { }
public class MMCLJMPEFEP_GetBbsThreads : CACGCMBKHDI_Request
{
	public class CAMBPKCCBDO
	{
		public List<JKHBHIGMJIC> NMHGLNGACMI_Threads = new List<JKHBHIGMJIC>(); // 0x8
		public int MDIBIIHAAPN_next_page; // 0xC
		public int CJNNMLLEKEF_PreviousPage; // 0x10
		public int GPPOJHNNINK_CurrentPage; // 0x14

		//// RVA: 0x1964324 Offset: 0x1964324 VA: 0x1964324
		public void KHEKNNFCAOI_Init(EDOHBJAPLPF_JsonData _IDLHJIOMJBK_Data)
		{
			EDOHBJAPLPF_JsonData threads = _IDLHJIOMJBK_Data["threads"];
			for(int i = 0; i < threads.HNBFOAJIIAL_Count; i++)
			{
				JKHBHIGMJIC thread = new JKHBHIGMJIC();
				thread.KHEKNNFCAOI_Init(threads[i]);
				NMHGLNGACMI_Threads.Add(thread);
			}
			CJNNMLLEKEF_PreviousPage = (int)_IDLHJIOMJBK_Data["previous_page"];
			GPPOJHNNINK_CurrentPage = (int)_IDLHJIOMJBK_Data["current_page"];
			MDIBIIHAAPN_next_page = (int)_IDLHJIOMJBK_Data["next_page"];
		}
	}

	public const int GBBILKJEBCO = 30;
	public SakashoBbsThreadCriteria IPKCADIAAPG_Criteria = new SakashoBbsThreadCriteria(); // 0x7C
	public int DFJDDIGFGKJ_SortKey; // 0x80
	public int MLMHPBOKJCL_SortOrder = 1; // 0x84
	public int IGNIIEBMFIN_Page = 1; // 0x88
	public int MLPLGFLKKLI_Ipp = 30; // 0x8C
	public CAMBPKCCBDO NFEAMMJIMPG_Result; // 0x90
	
	// RVA: 0x19640B4 Offset: 0x19640B4 VA: 0x19640B4 Slot: 12
	public override void DHLDNIEELHO()
	{
		EBGACDGNCAA_CallContext = SakashoBbs.GetThreads(IPKCADIAAPG_Criteria, DFJDDIGFGKJ_SortKey, MLMHPBOKJCL_SortOrder, IGNIIEBMFIN_Page, MLPLGFLKKLI_Ipp, DCKLDDCAJAP, MEOCKCJBDAD);
	}

	// RVA: 0x19641C4 Offset: 0x19641C4 VA: 0x19641C4 Slot: 13
	public override void MGFNKDPHFGI(MonoBehaviour _DANMJLOBLIE_mb)
	{
		NFEAMMJIMPG_Result = new CAMBPKCCBDO();
		NFEAMMJIMPG_Result.KHEKNNFCAOI_Init(IKPIMINCOPI_JsonMapper.PFAMKCGJKKL_ToObject(NGCAIEGPLKD_result));
	}
}
