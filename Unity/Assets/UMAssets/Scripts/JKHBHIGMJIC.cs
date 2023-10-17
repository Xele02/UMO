
public class JKHBHIGMJIC
{
	public int LIBHMBKLMHF_Id; // 0x8
	public string ADCMNODJBGJ_Title; // 0xC
	public int OMMDEKMFBAF_CommentsCount; // 0x10
	public int MEBNLFANDLC_CurrentCommentsCount; // 0x14
	public int HNFEMPEKGMK_ThreadOwnerId; // 0x18
	public int DNLIANFPNBC_LastThreadUpdaterId; // 0x1C
	public long ECCMAJJBNLC_CreatedAt; // 0x20
	public long FPCDHCGOJLE_UpdatedAt; // 0x28
	public long FPMAIGJMMOF_LastCommentWrittenAt; // 0x30
	public long GKAHLOIDOOI_LastCommentUpdatedAt; // 0x38
	public bool OPGDKPHLNDE_CommentRotate; // 0x40
	public int IKEIDOFLDDC_MinCommentBytes; // 0x44
	public int MEHEBIGKOKD_MaxCommentBytes; // 0x48
	public int ADGNGHIJFFC_MaxComments; // 0x4C
	public int GFGJGHPKHIN_ExpireDays; // 0x50
	public int IJJOIFFHNDE_ThreadScore; // 0x54
	public string BDJEICCDKHB_ThreadGroup; // 0x58
	public bool KMDEAIGNPEC_ApplyOwnerBlackList; // 0x5C
	public string KACECFNECON_Extra; // 0x60

	//// RVA: 0x135F3AC Offset: 0x135F3AC VA: 0x135F3AC
	public void KHEKNNFCAOI(EDOHBJAPLPF_JsonData IDLHJIOMJBK)
	{
		LIBHMBKLMHF_Id = CEDHHAGBIBA.GNJBKANDLEE_ReadInt(IDLHJIOMJBK, "thread_id");
		ADCMNODJBGJ_Title = (string)IDLHJIOMJBK["title"];
		OMMDEKMFBAF_CommentsCount = CEDHHAGBIBA.GNJBKANDLEE_ReadInt(IDLHJIOMJBK, "comments_count");
		MEBNLFANDLC_CurrentCommentsCount = CEDHHAGBIBA.GNJBKANDLEE_ReadInt(IDLHJIOMJBK, "current_comments_count");
		HNFEMPEKGMK_ThreadOwnerId = CEDHHAGBIBA.GNJBKANDLEE_ReadInt(IDLHJIOMJBK, "thread_owner_id");
		DNLIANFPNBC_LastThreadUpdaterId = CEDHHAGBIBA.GNJBKANDLEE_ReadInt(IDLHJIOMJBK, "last_thread_updater_id");
		ECCMAJJBNLC_CreatedAt = CEDHHAGBIBA.NIKODNFGCEM_ReadLong(IDLHJIOMJBK, "thread_created_at");
		FPCDHCGOJLE_UpdatedAt = CEDHHAGBIBA.NIKODNFGCEM_ReadLong(IDLHJIOMJBK, "last_thread_updated_at");
		FPMAIGJMMOF_LastCommentWrittenAt = CEDHHAGBIBA.NIKODNFGCEM_ReadLong(IDLHJIOMJBK, "last_comment_written_at");
		GKAHLOIDOOI_LastCommentUpdatedAt = CEDHHAGBIBA.NIKODNFGCEM_ReadLong(IDLHJIOMJBK, "last_comment_updated_at");
		OPGDKPHLNDE_CommentRotate = (bool)IDLHJIOMJBK["comment_rotate"];
		IKEIDOFLDDC_MinCommentBytes = CEDHHAGBIBA.GNJBKANDLEE_ReadInt(IDLHJIOMJBK, "min_comment_bytes");
		MEHEBIGKOKD_MaxCommentBytes = CEDHHAGBIBA.GNJBKANDLEE_ReadInt(IDLHJIOMJBK, "max_comment_bytes");
		ADGNGHIJFFC_MaxComments = CEDHHAGBIBA.GNJBKANDLEE_ReadInt(IDLHJIOMJBK, "max_comments");
		GFGJGHPKHIN_ExpireDays = CEDHHAGBIBA.GNJBKANDLEE_ReadInt(IDLHJIOMJBK, "expire_days");
		IJJOIFFHNDE_ThreadScore = CEDHHAGBIBA.GNJBKANDLEE_ReadInt(IDLHJIOMJBK, "thread_score");
		if(IDLHJIOMJBK.BBAJPINMOEP_Contains("thread_group"))
		{
			EDOHBJAPLPF_JsonData group = IDLHJIOMJBK["thread_group"];
			if(group != null)
			{
				BDJEICCDKHB_ThreadGroup = (string)group;
			}
		}
		if(IDLHJIOMJBK.BBAJPINMOEP_Contains("apply_owner_blacklist"))
		{
			KMDEAIGNPEC_ApplyOwnerBlackList = (bool)IDLHJIOMJBK["apply_owner_blacklist"];
		}
		if(IDLHJIOMJBK.BBAJPINMOEP_Contains("extra"))
		{
			KACECFNECON_Extra = (string)IDLHJIOMJBK["extra"];
		}
	}
}
