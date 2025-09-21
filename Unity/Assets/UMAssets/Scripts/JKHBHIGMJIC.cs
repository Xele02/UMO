
public class JKHBHIGMJIC
{
	public int LIBHMBKLMHF_ThreadId; // 0x8
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
	public string KACECFNECON_extra; // 0x60

	//// RVA: 0x135F3AC Offset: 0x135F3AC VA: 0x135F3AC
	public void KHEKNNFCAOI_Init(EDOHBJAPLPF_JsonData _IDLHJIOMJBK_Data)
	{
		LIBHMBKLMHF_ThreadId = CEDHHAGBIBA.GNJBKANDLEE_ReadInt(_IDLHJIOMJBK_Data, "thread_id");
		ADCMNODJBGJ_Title = (string)_IDLHJIOMJBK_Data["title"];
		OMMDEKMFBAF_CommentsCount = CEDHHAGBIBA.GNJBKANDLEE_ReadInt(_IDLHJIOMJBK_Data, "comments_count");
		MEBNLFANDLC_CurrentCommentsCount = CEDHHAGBIBA.GNJBKANDLEE_ReadInt(_IDLHJIOMJBK_Data, "current_comments_count");
		HNFEMPEKGMK_ThreadOwnerId = CEDHHAGBIBA.GNJBKANDLEE_ReadInt(_IDLHJIOMJBK_Data, "thread_owner_id");
		DNLIANFPNBC_LastThreadUpdaterId = CEDHHAGBIBA.GNJBKANDLEE_ReadInt(_IDLHJIOMJBK_Data, "last_thread_updater_id");
		ECCMAJJBNLC_CreatedAt = CEDHHAGBIBA.NIKODNFGCEM_ReadLong(_IDLHJIOMJBK_Data, "thread_created_at");
		FPCDHCGOJLE_UpdatedAt = CEDHHAGBIBA.NIKODNFGCEM_ReadLong(_IDLHJIOMJBK_Data, "last_thread_updated_at");
		FPMAIGJMMOF_LastCommentWrittenAt = CEDHHAGBIBA.NIKODNFGCEM_ReadLong(_IDLHJIOMJBK_Data, "last_comment_written_at");
		GKAHLOIDOOI_LastCommentUpdatedAt = CEDHHAGBIBA.NIKODNFGCEM_ReadLong(_IDLHJIOMJBK_Data, "last_comment_updated_at");
		OPGDKPHLNDE_CommentRotate = (bool)_IDLHJIOMJBK_Data["comment_rotate"];
		IKEIDOFLDDC_MinCommentBytes = CEDHHAGBIBA.GNJBKANDLEE_ReadInt(_IDLHJIOMJBK_Data, "min_comment_bytes");
		MEHEBIGKOKD_MaxCommentBytes = CEDHHAGBIBA.GNJBKANDLEE_ReadInt(_IDLHJIOMJBK_Data, "max_comment_bytes");
		ADGNGHIJFFC_MaxComments = CEDHHAGBIBA.GNJBKANDLEE_ReadInt(_IDLHJIOMJBK_Data, "max_comments");
		GFGJGHPKHIN_ExpireDays = CEDHHAGBIBA.GNJBKANDLEE_ReadInt(_IDLHJIOMJBK_Data, "expire_days");
		IJJOIFFHNDE_ThreadScore = CEDHHAGBIBA.GNJBKANDLEE_ReadInt(_IDLHJIOMJBK_Data, "thread_score");
		if(_IDLHJIOMJBK_Data.BBAJPINMOEP_Contains("thread_group"))
		{
			EDOHBJAPLPF_JsonData group = _IDLHJIOMJBK_Data["thread_group"];
			if(group != null)
			{
				BDJEICCDKHB_ThreadGroup = (string)group;
			}
		}
		if(_IDLHJIOMJBK_Data.BBAJPINMOEP_Contains("apply_owner_blacklist"))
		{
			KMDEAIGNPEC_ApplyOwnerBlackList = (bool)_IDLHJIOMJBK_Data["apply_owner_blacklist"];
		}
		if(_IDLHJIOMJBK_Data.BBAJPINMOEP_Contains("extra"))
		{
			KACECFNECON_extra = (string)_IDLHJIOMJBK_Data["extra"];
		}
	}
}
