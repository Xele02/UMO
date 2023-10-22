
using System.Collections.Generic;
using UnityEngine;

[System.Obsolete("Use MMCLJMPEFEP_GetBbsThreads", true)]
public abstract class MMCLJMPEFEP { }
public class MMCLJMPEFEP_GetBbsThreads : CACGCMBKHDI_Request
{
	public class CAMBPKCCBDO
	{
		public List<JKHBHIGMJIC> NMHGLNGACMI_Threads = new List<JKHBHIGMJIC>(); // 0x8
		public int MDIBIIHAAPN_NextPage; // 0xC
		public int CJNNMLLEKEF_PreviousPage; // 0x10
		public int GPPOJHNNINK_CurrentPage; // 0x14

		//// RVA: 0x1964324 Offset: 0x1964324 VA: 0x1964324
		public void KHEKNNFCAOI(EDOHBJAPLPF_JsonData IDLHJIOMJBK)
		{
			EDOHBJAPLPF_JsonData threads = IDLHJIOMJBK["threads"];
			for(int i = 0; i < threads.HNBFOAJIIAL_Count; i++)
			{
				JKHBHIGMJIC thread = new JKHBHIGMJIC();
				thread.KHEKNNFCAOI(threads[i]);
				NMHGLNGACMI_Threads.Add(thread);
			}
			CJNNMLLEKEF_PreviousPage = (int)IDLHJIOMJBK["previous_page"];
			GPPOJHNNINK_CurrentPage = (int)IDLHJIOMJBK["current_page"];
			MDIBIIHAAPN_NextPage = (int)IDLHJIOMJBK["next_page"];
		}
	}

	public const int GBBILKJEBCO = 30;
	public SakashoBbsThreadCriteria IPKCADIAAPG_Criteria = new SakashoBbsThreadCriteria(); // 0x7C
	public int DFJDDIGFGKJ_SortKey; // 0x80
	public int MLMHPBOKJCL_SortOrder = 1; // 0x84
	public int IGNIIEBMFIN_Page = 1; // 0x88
	public int MLPLGFLKKLI_Ipp = 30; // 0x8C
	public CAMBPKCCBDO NFEAMMJIMPG; // 0x90
	
	// RVA: 0x19640B4 Offset: 0x19640B4 VA: 0x19640B4 Slot: 12
	public override void DHLDNIEELHO()
	{
		EBGACDGNCAA_CallContext = SakashoBbs.GetThreads(IPKCADIAAPG_Criteria, DFJDDIGFGKJ_SortKey, MLMHPBOKJCL_SortOrder, IGNIIEBMFIN_Page, MLPLGFLKKLI_Ipp, DCKLDDCAJAP, MEOCKCJBDAD);
	}

	// RVA: 0x19641C4 Offset: 0x19641C4 VA: 0x19641C4 Slot: 13
	public override void MGFNKDPHFGI(MonoBehaviour DANMJLOBLIE)
	{
		NFEAMMJIMPG = new CAMBPKCCBDO();
		NFEAMMJIMPG.KHEKNNFCAOI(IKPIMINCOPI_JsonMapper.PFAMKCGJKKL_ToObject(NGCAIEGPLKD_result));
	}
}
