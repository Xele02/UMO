
[System.Obsolete("Use EKNLDDKJBEL_UpdateThreadComment", true)]
public class EKNLDDKJBEL {}
public class EKNLDDKJBEL_UpdateThreadComment : CACGCMBKHDI_Request
{
	public int BOINIEAKFPL_ThreadId; // 0x7C
	public int OJBGACKBOCA_CommentIdx; // 0x80
	public SakashoBbsCommentInfo KOGBMDOONFA_Info; // 0x84

	// RVA: 0x1303C30 Offset: 0x1303C30 VA: 0x1303C30 Slot: 12
	public override void DHLDNIEELHO()
    {
        EBGACDGNCAA_CallContext = SakashoBbs.UpdateThreadComment(BOINIEAKFPL_ThreadId, OJBGACKBOCA_CommentIdx, KOGBMDOONFA_Info, DCKLDDCAJAP, MEOCKCJBDAD);
    }
}
