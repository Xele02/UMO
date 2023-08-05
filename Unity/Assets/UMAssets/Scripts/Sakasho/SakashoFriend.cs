using Sakasho.JSON;
using SakashoSystemCallback;
using System.Collections;

public class SakashoFriend : SakashoAPIBase
{
	// RVA: 0x2BBD3A8 Offset: 0x2BBD3A8 VA: 0x2BBD3A8
	public static SakashoAPICallContext GetFriends(int page, int ipp, OnSuccess onSuccess, OnError onError)
	{
		Hashtable h = new Hashtable();
		h["page"] = page;
		h["ipp"] = ipp;
		return new SakashoAPICallContext(Call(SakashoFriendGetFriends, MiniJSON.jsonEncode(h), onSuccess, onError));
	}

	//// RVA: 0x2BBD594 Offset: 0x2BBD594 VA: 0x2BBD594
	//public static SakashoAPICallContext SendFriendRequest(int id, bool autoAcception, OnSuccess onSuccess, OnError onError) { }

	//// RVA: 0x2BBD780 Offset: 0x2BBD780 VA: 0x2BBD780
	public static SakashoAPICallContext GetReceivedRequests(int page, int ipp, OnSuccess onSuccess, OnError onError)
	{
		Hashtable h = new Hashtable();
		h["page"] = page;
		h["ipp"] = ipp;
		return new SakashoAPICallContext(Call(SakashoFriendGetReceivedRequests, MiniJSON.jsonEncode(h), onSuccess, onError));
	}

	//// RVA: 0x2BBD96C Offset: 0x2BBD96C VA: 0x2BBD96C
	public static SakashoAPICallContext GetSentRequests(int page, int ipp, OnSuccess onSuccess, OnError onError)
	{
		Hashtable h = new Hashtable();
		h["page"] = page;
		h["ipp"] = ipp;
		return new SakashoAPICallContext(Call(SakashoFriendGetSentRequests, MiniJSON.jsonEncode(h), onSuccess, onError));
	}

	//// RVA: 0x2BBDB58 Offset: 0x2BBDB58 VA: 0x2BBDB58
	//public static SakashoAPICallContext AcceptFriendRequest(int id, OnSuccess onSuccess, OnError onError) { }

	//// RVA: 0x2BBDCE8 Offset: 0x2BBDCE8 VA: 0x2BBDCE8
	//public static SakashoAPICallContext RefuseFriendRequest(int id, OnSuccess onSuccess, OnError onError) { }

	//// RVA: 0x2BBDE78 Offset: 0x2BBDE78 VA: 0x2BBDE78
	//public static SakashoAPICallContext DeleteFriendRequest(int id, OnSuccess onSuccess, OnError onError) { }

	//// RVA: 0x2BBE008 Offset: 0x2BBE008 VA: 0x2BBE008
	//public static SakashoAPICallContext DeleteFriend(int id, OnSuccess onSuccess, OnError onError) { }

	//// RVA: 0x2BBE198 Offset: 0x2BBE198 VA: 0x2BBE198
	public static SakashoAPICallContext SetFriendsLimit(int friendLimit, OnSuccess onSuccess, OnError onError)
	{
		Hashtable h = new Hashtable();
		h["friendLimit"] = friendLimit;
		return new SakashoAPICallContext(Call(SakashoFriendSetFriendsLimit, MiniJSON.jsonEncode(h), onSuccess, onError));
	}

	//// RVA: 0x2BBE328 Offset: 0x2BBE328 VA: 0x2BBE328
	public static SakashoAPICallContext GetFriendsLimit(OnSuccess onSuccess, OnError onError)
	{
		return new SakashoAPICallContext(Call(SakashoFriendGetFriendsLimit, "", onSuccess, onError));
	}

	//// RVA: 0x2BBE40C Offset: 0x2BBE40C VA: 0x2BBE40C
	//public static SakashoAPICallContext SetFriendsFavoriteValue(int[] playerIds, int favorite, OnSuccess onSuccess, OnError onError) { }

	//// RVA: 0x2BBE6B4 Offset: 0x2BBE6B4 VA: 0x2BBE6B4
	//public static SakashoAPICallContext RefuseFriendsRequest(int[] player_ids, OnSuccess onSuccess, OnError onError) { }

	//// RVA: 0x2BBE8F0 Offset: 0x2BBE8F0 VA: 0x2BBE8F0
	//public static SakashoAPICallContext SetFriendsLimitAndSave(string[] names, string playerData, bool replace, int limit, OnSuccess onSuccess, OnError onError) { }

	//// RVA: 0x2BBEC00 Offset: 0x2BBEC00 VA: 0x2BBEC00
	//private static extern int SakashoFriendGetFriends(int callbackId, string json) { }
	private static int SakashoFriendGetFriends(int callbackId, string json)
	{
		return ExternLib.LibSakasho.SakashoFriendGetFriends(callbackId, json);
	}

	//// RVA: 0x2BBED40 Offset: 0x2BBED40 VA: 0x2BBED40
	//private static extern int SakashoFriendSendFriendRequest(int callbackId, string json) { }

	//// RVA: 0x2BBEE50 Offset: 0x2BBEE50 VA: 0x2BBEE50
	//private static extern int SakashoFriendGetReceivedRequests(int callbackId, string json) { }
	private static int SakashoFriendGetReceivedRequests(int callbackId, string json)
	{
		return ExternLib.LibSakasho.SakashoFriendGetReceivedRequests(callbackId, json);
	}

	//// RVA: 0x2BBEF60 Offset: 0x2BBEF60 VA: 0x2BBEF60
	//private static extern int SakashoFriendGetSentRequests(int callbackId, string json) { }
	private static int SakashoFriendGetSentRequests(int callbackId, string json)
	{
		return ExternLib.LibSakasho.SakashoFriendGetSentRequests(callbackId, json);
	}

	//// RVA: 0x2BBF070 Offset: 0x2BBF070 VA: 0x2BBF070
	//private static extern int SakashoFriendAcceptFriendRequest(int callbackId, string json) { }

	//// RVA: 0x2BBF180 Offset: 0x2BBF180 VA: 0x2BBF180
	//private static extern int SakashoFriendRefuseFriendRequest(int callbackId, string json) { }

	//// RVA: 0x2BBF290 Offset: 0x2BBF290 VA: 0x2BBF290
	//private static extern int SakashoFriendDeleteFriendRequest(int callbackId, string json) { }

	//// RVA: 0x2BBF3A0 Offset: 0x2BBF3A0 VA: 0x2BBF3A0
	//private static extern int SakashoFriendDeleteFriend(int callbackId, string json) { }

	//// RVA: 0x2BBF4E8 Offset: 0x2BBF4E8 VA: 0x2BBF4E8
	//private static extern int SakashoFriendSetFriendsLimit(int callbackId, string json) { }
	private static int SakashoFriendSetFriendsLimit(int callbackId, string json)
	{
		return ExternLib.LibSakasho.SakashoFriendSetFriendsLimit(callbackId, json);
	}

	//// RVA: 0x2BBF5F8 Offset: 0x2BBF5F8 VA: 0x2BBF5F8
	//private static extern int SakashoFriendGetFriendsLimit(int callbackId, string json) { }
	private static int SakashoFriendGetFriendsLimit(int callbackId, string json)
	{
		return ExternLib.LibSakasho.SakashoFriendGetFriendsLimit(callbackId, json);
	}

	//// RVA: 0x2BBF708 Offset: 0x2BBF708 VA: 0x2BBF708
	//private static extern int SakashoFriendSetFriendsFavoriteValue(int callbackId, string json) { }

	//// RVA: 0x2BBF820 Offset: 0x2BBF820 VA: 0x2BBF820
	//private static extern int SakashoFriendRefuseFriendsRequest(int callbackId, string json) { }

	//// RVA: 0x2BBF930 Offset: 0x2BBF930 VA: 0x2BBF930
	//private static extern int SakashoFriendSetFriendsLimitAndSave(int callbackId, string json) { }
}
