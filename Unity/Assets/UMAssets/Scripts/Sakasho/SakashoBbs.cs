using Sakasho.JSON;
using SakashoSystemCallback;
using System.Collections;

public class SakashoBbs : SakashoAPIBase
{
	public static class ThreadOrder
	{
		public const int KEY_LAST_COMMENT_WRITTEN_AT = 0;
		public const int KEY_LAST_COMMENT_UPDATED_AT = 1;
		public const int KEY_THREAD_CREATED_AT = 2;
		public const int KEY_THREAD_SCORE = 3;
		public const int ORDER_DESC = 0;
		public const int ORDER_ASC = 1;
	}

	public static class CommentOrder
	{
		public const int ORDER_DESC = 0;
		public const int ORDER_ASC = 1;
	}

	//// RVA: 0x2BB42A0 Offset: 0x2BB42A0 VA: 0x2BB42A0
	//public static SakashoAPICallContext GetThreadCommentRecord(int threadId, int commentIndex, OnSuccess onSuccess, OnError onError) { }

	//// RVA: 0x2BB448C Offset: 0x2BB448C VA: 0x2BB448C
	public static SakashoAPICallContext GetThreadComments(int threadId, SakashoBbsCommentCriteria criteria, int sortOrder, int page, int ipp, OnSuccess onSuccess, OnError onError)
	{
		Hashtable h = new Hashtable();
		h["threadId"] = threadId;
		if(criteria != null)
		{
			h["writerId"] = criteria.WriterId;
			h["excludeDeleted"] = criteria.ExcludeDeleted;
		}
		h["sortOrder"] = sortOrder;
		h["page"] = page;
		h["ipp"] = ipp;
		return new SakashoAPICallContext(Call(SakashoBbsGetThreadComments, MiniJSON.jsonEncode(h), onSuccess, onError));
	}

	//// RVA: 0x2BB4790 Offset: 0x2BB4790 VA: 0x2BB4790
	//public static SakashoAPICallContext GetThreadCommentMarks(int threadId, int commentIndex, int markType, int page, int ipp, OnSuccess onSuccess, OnError onError) { }

	//// RVA: 0x2BB4A90 Offset: 0x2BB4A90 VA: 0x2BB4A90
	public static SakashoAPICallContext GetThreads(SakashoBbsThreadCriteria criteria, int sortKey, int sortOrder, int page, int ipp, OnSuccess onSuccess, OnError onError)
	{
		Hashtable h = new Hashtable();
		if(criteria != null)
		{
			h["op"] = criteria.Op;
			h["threadOwnerId"] = criteria.ThreadOwnerId;
			h["threadGroup"] = criteria.ThreadGroup;
			h["excludeBlockedThreads"] = criteria.ExcludeBlockedThreads;
		}
		h["sortKey"] = sortKey;
		h["sortOrder"] = sortOrder;
		h["page"] = page;
		h["ipp"] = ipp;
		return new SakashoAPICallContext(Call(SakashoBbsGetThreads, MiniJSON.jsonEncode(h), onSuccess, onError));
	}

	//// RVA: 0x2BB4E8C Offset: 0x2BB4E8C VA: 0x2BB4E8C
	public static SakashoAPICallContext CreateThread(SakashoBbsThreadInfo info, OnSuccess onSuccess, OnError onError)
	{
		Hashtable h = new Hashtable();
		if(info != null)
		{
			if (info.Title != null)
				h["title"] = info.Title;
			if (info.Detail != null)
				h["detail"] = info.Detail;
			if (info.ThreadGroup != null)
				h["threadGroup"] = info.ThreadGroup;
			if (info.Extra != null)
				h["extra"] = info.Extra;
			h["minCommentBytes"] = info.MinCommentBytes;
			h["maxCommentBytes"] = info.MaxCommentBytes;
			h["maxComments"] = info.MaxComments;
			h["expireDays"] = info.ExpireDays;
			h["threadScore"] = info.ThreadScore;
			ArrayList l = null;
			if (info.WritePlayerIds != null)
			{
				l = new ArrayList();
				for(int i = 0; i < info.WritePlayerIds.Length; i++)
				{
					l.Add(info.WritePlayerIds[i]);
				}
			}
			h["writePlayerIds"] = l;
			l = null;
			if (info.UpdatePlayerIds != null)
			{
				l = new ArrayList();
				for (int i = 0; i < info.UpdatePlayerIds.Length; i++)
				{
					l.Add(info.UpdatePlayerIds[i]);
				}
			}
			h["updatePlayerIds"] = l;
			h["applyOwnerBlacklist"] = info.ApplyOwnerBlacklist;
		}
		return new SakashoAPICallContext(Call(SakashoBbsCreateThread, MiniJSON.jsonEncode(h), onSuccess, onError));
	}

	//// RVA: 0x2BB563C Offset: 0x2BB563C VA: 0x2BB563C
	public static SakashoAPICallContext CreateThreadComment(int threadId, SakashoBbsCommentInfo info, OnSuccess onSuccess, OnError onError)
	{
		Hashtable h = new Hashtable();
		h["threadId"] = threadId;
		if(info != null)
		{
			h["content"] = info.Content;
			h["nickname"] = info.Nickname;
			h["extra"] = info.Extra;
			h["replyTo"] = info.ReplyTo;
			h["sage"] = info.Sage;
		}
		return new SakashoAPICallContext(Call(SakashoBbsCreateThreadComment, MiniJSON.jsonEncode(h), onSuccess, onError));
	}

	//// RVA: 0x2BB5934 Offset: 0x2BB5934 VA: 0x2BB5934
	//public static SakashoAPICallContext UpdateThread(int threadId, SakashoBbsThreadInfo info, OnSuccess onSuccess, OnError onError) { }

	//// RVA: 0x2BB60D0 Offset: 0x2BB60D0 VA: 0x2BB60D0
	public static SakashoAPICallContext UpdateThreadComment(int threadId, int commentIndex, SakashoBbsCommentInfo info, OnSuccess onSuccess, OnError onError)
	{
		Hashtable h = new Hashtable();
		h["threadId"] = threadId;
		h["commentIndex"] = commentIndex;
		if(info != null)
		{
			if(info.Content != null)
				h["content"] = info.Content;
			if(info.Nickname != null)
				h["nickname"] = info.Nickname;
			if(info.Extra != null)
				h["extra"] = info.Extra;
			h["replyTo"] = info.ReplyTo;
			h["sage"] = info.Sage;
		}
		return new SakashoAPICallContext(Call(SakashoBbsUpdateThreadComment, MiniJSON.jsonEncode(h), onSuccess, onError));
	}

	//// RVA: 0x2BB6424 Offset: 0x2BB6424 VA: 0x2BB6424
	//public static SakashoAPICallContext MarkThreadComment(int threadId, int commentIndex, int markType, OnSuccess onSuccess, OnError onError) { }

	//// RVA: 0x2BB666C Offset: 0x2BB666C VA: 0x2BB666C
	//public static SakashoAPICallContext UnmarkThreadComment(int threadId, int commentIndex, int markType, OnSuccess onSuccess, OnError onError) { }

	//// RVA: 0x2BB68B4 Offset: 0x2BB68B4 VA: 0x2BB68B4
	//public static SakashoAPICallContext DeleteThread(int threadId, OnSuccess onSuccess, OnError onError) { }

	//// RVA: 0x2BB6A44 Offset: 0x2BB6A44 VA: 0x2BB6A44
	//public static SakashoAPICallContext DeleteThreadComment(int threadId, int commentIndex, OnSuccess onSuccess, OnError onError) { }

	//// RVA: 0x2BB6C30 Offset: 0x2BB6C30 VA: 0x2BB6C30
	//private static extern int SakashoBbsGetThreadCommentRecord(int callbackId, string json) { }

	//// RVA: 0x2BB6D40 Offset: 0x2BB6D40 VA: 0x2BB6D40
	private static int SakashoBbsGetThreadComments(int callbackId, string json)
	{
		return ExternLib.LibSakasho.SakashoBbsGetThreadComments(callbackId, json);
	}

	//// RVA: 0x2BB6E48 Offset: 0x2BB6E48 VA: 0x2BB6E48
	//private static extern int SakashoBbsGetThreadCommentMarks(int callbackId, string json) { }

	//// RVA: 0x2BB6F58 Offset: 0x2BB6F58 VA: 0x2BB6F58
	private static int SakashoBbsGetThreads(int callbackId, string json)
	{
		return ExternLib.LibSakasho.SakashoBbsGetThreads(callbackId, json);
	}

	//// RVA: 0x2BB7098 Offset: 0x2BB7098 VA: 0x2BB7098
	private static int SakashoBbsCreateThread(int callbackId, string json)
	{
		return ExternLib.LibSakasho.SakashoBbsCreateThread(callbackId, json);
	}

	//// RVA: 0x2BB71D8 Offset: 0x2BB71D8 VA: 0x2BB71D8
	private static int SakashoBbsCreateThreadComment(int callbackId, string json)
	{
		return ExternLib.LibSakasho.SakashoBbsCreateThreadComment(callbackId, json);
	}

	//// RVA: 0x2BB72E8 Offset: 0x2BB72E8 VA: 0x2BB72E8
	//private static extern int SakashoBbsUpdateThread(int callbackId, string json) { }

	//// RVA: 0x2BB7428 Offset: 0x2BB7428 VA: 0x2BB7428
	private static int SakashoBbsUpdateThreadComment(int callbackId, string json)
	{
		return ExternLib.LibSakasho.SakashoBbsUpdateThreadComment(callbackId, json);
	}

	//// RVA: 0x2BB7538 Offset: 0x2BB7538 VA: 0x2BB7538
	//private static extern int SakashoBbsMarkThreadComment(int callbackId, string json) { }

	//// RVA: 0x2BB7640 Offset: 0x2BB7640 VA: 0x2BB7640
	//private static extern int SakashoBbsUnmarkThreadComment(int callbackId, string json) { }

	//// RVA: 0x2BB7750 Offset: 0x2BB7750 VA: 0x2BB7750
	//private static extern int SakashoBbsDeleteThread(int callbackId, string json) { }

	//// RVA: 0x2BB7890 Offset: 0x2BB7890 VA: 0x2BB7890
	//private static extern int SakashoBbsDeleteThreadComment(int callbackId, string json) { }
}
