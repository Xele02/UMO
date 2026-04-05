
using System.Collections.Generic;
using UnityEngine;

public class BNAAJMBJFPG
{
	public int NPAHGHOHMHN_Idx; // 0x8
	public string NLBNJIFGPJL_Content; // 0xC
	public string MNKCOFJKJJM_Nickname; // 0x10
	public int PNDINAAEGBE_WriterId; // 0x14
	public long JMDGOLBCOAJ_WrittenAt; // 0x18
	public long IFNLEKOILPM_updated_at; // 0x20
	public int LOIIMNGCHBI_reply_to; // 0x28
	public List<int> GKCNMFDNMPC_ReplyFrom; // 0x2C
	public bool GJCINKIGNPI_Sage; // 0x30
	public string KACECFNECON_extra; // 0x34

	public bool ILGKMOJFEDK { get { return NLBNJIFGPJL_Content == null; } } //0x19CA8F0 ELBMCFAOJNB_bgs

	//// RVA: 0x19CA3E0 Offset: 0x19CA3E0 VA: 0x19CA3E0
	public void KHEKNNFCAOI_Init(EDOHBJAPLPF_JsonData _IDLHJIOMJBK_data)
	{
		NPAHGHOHMHN_Idx = (int)_IDLHJIOMJBK_data["comment_index"];
		NLBNJIFGPJL_Content = CEDHHAGBIBA.BNCLNFJHEND_ReadString(_IDLHJIOMJBK_data, "content");
		MNKCOFJKJJM_Nickname = CEDHHAGBIBA.BNCLNFJHEND_ReadString(_IDLHJIOMJBK_data, "nickname");
		PNDINAAEGBE_WriterId = CEDHHAGBIBA.GNJBKANDLEE_ReadInt(_IDLHJIOMJBK_data, "comment_writer_id");
		JMDGOLBCOAJ_WrittenAt = CEDHHAGBIBA.NIKODNFGCEM_ReadLong(_IDLHJIOMJBK_data, "written_at");
		IFNLEKOILPM_updated_at = CEDHHAGBIBA.NIKODNFGCEM_ReadLong(_IDLHJIOMJBK_data, "updated_at");
		LOIIMNGCHBI_reply_to = -1;
		if (_IDLHJIOMJBK_data.BBAJPINMOEP_Contains("reply_to"))
		{
			if (_IDLHJIOMJBK_data["reply_to"] != null)
				LOIIMNGCHBI_reply_to = (int)_IDLHJIOMJBK_data["reply_to"];
		}
		GKCNMFDNMPC_ReplyFrom = new List<int>();
		if(_IDLHJIOMJBK_data.BBAJPINMOEP_Contains("reply_from"))
		{
			for(int i = 0; i < _IDLHJIOMJBK_data["reply_from"].HNBFOAJIIAL_Count; i++)
			{
				GKCNMFDNMPC_ReplyFrom.Add((int)_IDLHJIOMJBK_data["reply_from"][i]);
			}
		}
		if(_IDLHJIOMJBK_data.BBAJPINMOEP_Contains("sage"))
		{
			GJCINKIGNPI_Sage = (bool)_IDLHJIOMJBK_data["sage"];
			if(_IDLHJIOMJBK_data.BBAJPINMOEP_Contains("extra"))
			{
				KACECFNECON_extra = (string)_IDLHJIOMJBK_data["extra"];
			}
		}
	}
}

[System.Obsolete("Use NFIMGIABIOI_GetBbsThreadComments", true)]
public abstract class NFIMGIABIOI { }
public class NFIMGIABIOI_GetBbsThreadComments : CACGCMBKHDI_NetBaseAction
{
	public class CIIDLDOOKBB
	{
		public JKHBHIGMJIC OHJPNDKBFEC_Thread = new JKHBHIGMJIC(); // 0x8
		public List<BNAAJMBJFPG> GLNIHJIDABD_Comments = new List<BNAAJMBJFPG>(); // 0xC
		public int CJNNMLLEKEF_previous_page; // 0x10
		public int GPPOJHNNINK_current_page; // 0x14
		public int MDIBIIHAAPN_next_page; // 0x18

		//// RVA: 0x1AE9D9C Offset: 0x1AE9D9C VA: 0x1AE9D9C
		public void KHEKNNFCAOI_Init(EDOHBJAPLPF_JsonData _IDLHJIOMJBK_data)
		{
			OHJPNDKBFEC_Thread.KHEKNNFCAOI_Init(_IDLHJIOMJBK_data["thread"]);
			GLNIHJIDABD_Comments.Clear();
			EDOHBJAPLPF_JsonData comments = _IDLHJIOMJBK_data["comments"];
			for(int i = 0; i < comments.HNBFOAJIIAL_Count; i++)
			{
				BNAAJMBJFPG comment = new BNAAJMBJFPG();
				comment.KHEKNNFCAOI_Init(comments[i]);
				GLNIHJIDABD_Comments.Add(comment);
			}
			CJNNMLLEKEF_previous_page = (int)_IDLHJIOMJBK_data["previous_page"];
			GPPOJHNNINK_current_page = (int)_IDLHJIOMJBK_data["current_page"];
			MDIBIIHAAPN_next_page = (int)_IDLHJIOMJBK_data["next_page"];
		}
	}

	public const int GBBILKJEBCO = 30;
	public int BOINIEAKFPL_ThreadId; // 0x7C
	public SakashoBbsCommentCriteria IPKCADIAAPG_Criteria = new SakashoBbsCommentCriteria(); // 0x80
	public int MLMHPBOKJCL_SortOrder; // 0x84
	public int IGNIIEBMFIN_Page = 1; // 0x88
	public int MLPLGFLKKLI_Ipp = 30; // 0x8C
	public CIIDLDOOKBB NFEAMMJIMPG_Result; // 0x90

	// RVA: 0x1AE9B08 Offset: 0x1AE9B08 VA: 0x1AE9B08 Slot: 12
	public override void DHLDNIEELHO()
	{
		EBGACDGNCAA_CallContext = SakashoBbs.GetThreadComments(BOINIEAKFPL_ThreadId, IPKCADIAAPG_Criteria, MLMHPBOKJCL_SortOrder, IGNIIEBMFIN_Page, MLPLGFLKKLI_Ipp, DCKLDDCAJAP, MEOCKCJBDAD);
	}

	// RVA: 0x1AE9C18 Offset: 0x1AE9C18 VA: 0x1AE9C18 Slot: 13
	public override void MGFNKDPHFGI(MonoBehaviour _DANMJLOBLIE_mb)
	{
		NFEAMMJIMPG_Result = new CIIDLDOOKBB();
		NFEAMMJIMPG_Result.KHEKNNFCAOI_Init(IKPIMINCOPI_JsonMapper.PFAMKCGJKKL_ToObject(NGCAIEGPLKD_result));
	}
}
