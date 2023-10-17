
using System.Collections.Generic;
using UnityEngine;

public class BNAAJMBJFPG
{
	public int NPAHGHOHMHN_Idx; // 0x8
	public string NLBNJIFGPJL_Content; // 0xC
	public string MNKCOFJKJJM_Nickname; // 0x10
	public int PNDINAAEGBE_WriterId; // 0x14
	public long JMDGOLBCOAJ_WrittenAt; // 0x18
	public long IFNLEKOILPM_UpdatedAt; // 0x20
	public int LOIIMNGCHBI_ReplyTo; // 0x28
	public List<int> GKCNMFDNMPC_ReplyFrom; // 0x2C
	public bool GJCINKIGNPI_Sage; // 0x30
	public string KACECFNECON_Extra; // 0x34

	//public bool ILGKMOJFEDK { get; } 0x19CA8F0 ELBMCFAOJNB

	//// RVA: 0x19CA3E0 Offset: 0x19CA3E0 VA: 0x19CA3E0
	//public void KHEKNNFCAOI(EDOHBJAPLPF IDLHJIOMJBK) { }
}

[System.Obsolete("Use NFIMGIABIOI_GetBbsThreadComments", true)]
public abstract class NFIMGIABIOI { }
public class NFIMGIABIOI_GetBbsThreadComments : CACGCMBKHDI_Request
{
	public class CIIDLDOOKBB
	{
		public JKHBHIGMJIC OHJPNDKBFEC_Thread = new JKHBHIGMJIC(); // 0x8
		public List<BNAAJMBJFPG> GLNIHJIDABD_Comments = new List<BNAAJMBJFPG>(); // 0xC
		public int CJNNMLLEKEF; // 0x10
		public int GPPOJHNNINK; // 0x14
		public int MDIBIIHAAPN; // 0x18

		//// RVA: 0x1AE9D9C Offset: 0x1AE9D9C VA: 0x1AE9D9C
		public void KHEKNNFCAOI(EDOHBJAPLPF_JsonData IDLHJIOMJBK)
		{
			TodoLogger.LogError(0, "KHEKNNFCAOI");
		}
	}

	public const int GBBILKJEBCO = 30;
	public int BOINIEAKFPL_ThreadId; // 0x7C
	public SakashoBbsCommentCriteria IPKCADIAAPG_Criteria = new SakashoBbsCommentCriteria(); // 0x80
	public int MLMHPBOKJCL_SortOrder; // 0x84
	public int IGNIIEBMFIN_Page = 1; // 0x88
	public int MLPLGFLKKLI_Ipp = 30; // 0x8C
	public CIIDLDOOKBB NFEAMMJIMPG; // 0x90

	// RVA: 0x1AE9B08 Offset: 0x1AE9B08 VA: 0x1AE9B08 Slot: 12
	public override void DHLDNIEELHO()
	{
		EBGACDGNCAA_CallContext = SakashoBbs.GetThreadComments(BOINIEAKFPL_ThreadId, IPKCADIAAPG_Criteria, MLMHPBOKJCL_SortOrder, IGNIIEBMFIN_Page, MLPLGFLKKLI_Ipp, DCKLDDCAJAP, MEOCKCJBDAD);
	}

	// RVA: 0x1AE9C18 Offset: 0x1AE9C18 VA: 0x1AE9C18 Slot: 13
	public override void MGFNKDPHFGI(MonoBehaviour DANMJLOBLIE)
	{
		NFEAMMJIMPG = new CIIDLDOOKBB();
		NFEAMMJIMPG.KHEKNNFCAOI(IKPIMINCOPI_JsonMapper.PFAMKCGJKKL_ToObject(NGCAIEGPLKD_result));
	}
}
