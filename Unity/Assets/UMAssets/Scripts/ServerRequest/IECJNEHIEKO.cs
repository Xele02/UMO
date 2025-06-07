
using UnityEngine;

[System.Obsolete("Use IECJNEHIEKO_CreateBbsComment", true)]
public class IECJNEHIEKO { }
public class IECJNEHIEKO_CreateBbsComment : CACGCMBKHDI_Request
{
	public class KFECPHAOCMN
	{
		public int NPAHGHOHMHN_Idx; // 0x8

		//// RVA: 0x11ED20C Offset: 0x11ED20C VA: 0x11ED20C
		public void KHEKNNFCAOI(EDOHBJAPLPF_JsonData OBHAFLMHAKG)
		{
			NPAHGHOHMHN_Idx = (int)OBHAFLMHAKG["comment_index"];
		}
	}

	public string JECLCENDGIH_ThreadType; // 0x7C
	public string BDJEICCDKHB_ThreadGroup; // 0x80
	public int GFOIDCMEHGL_RoomUserId; // 0x84
	public int MEBHCFJCKFE_LobbyId; // 0x88
	public int DNJLJMKKDNA_EventId; // 0x8C
	public int BOINIEAKFPL_ThreadId; // 0x90
	public SakashoBbsCommentInfo KOGBMDOONFA_Info; // 0x94
	public KFECPHAOCMN NFEAMMJIMPG; // 0x98
	
	// RVA: 0x11ECFDC Offset: 0x11ECFDC VA: 0x11ECFDC Slot: 12
	public override void DHLDNIEELHO()
	{
		EBGACDGNCAA_CallContext = SakashoBbs.CreateThreadComment(BOINIEAKFPL_ThreadId, KOGBMDOONFA_Info, DCKLDDCAJAP, MEOCKCJBDAD);
	}

	// RVA: 0x11ED0D4 Offset: 0x11ED0D4 VA: 0x11ED0D4 Slot: 13
	public override void MGFNKDPHFGI(MonoBehaviour DANMJLOBLIE)
	{
		KFECPHAOCMN d = new KFECPHAOCMN();
		d.KHEKNNFCAOI(IKPIMINCOPI_JsonMapper.PFAMKCGJKKL_ToObject(NGCAIEGPLKD_result));
		NFEAMMJIMPG = d;
		ILCCJNDFFOB.HHCJCDFCLOB.CHMEOKEKABD(this);
	}
}
