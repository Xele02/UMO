using XeSys;

namespace ExternLib
{
	public static partial class LibSakasho
	{
		// To user account
		static int FriendLimit = 0;

		public static int SakashoFriendGetFriendsLimit(int callbackId, string json)
		{
			EDOHBJAPLPF_JsonData res = GetBaseMessage();
			res["friend_limit"] = FriendLimit;

			SendMessage(callbackId, res);

			return 0;
		}

		public static int SakashoFriendSetFriendsFavoriteValue(int callbackId, string json)
		{
			EDOHBJAPLPF_JsonData res = GetBaseMessage();
			SendMessage(callbackId, res);

			return 0;
		}
		
		public static int SakashoFriendSetFriendsLimit(int callbackId, string json)
		{
			EDOHBJAPLPF_JsonData jsonData = IKPIMINCOPI_JsonMapper.PFAMKCGJKKL_ToObject(json);
			EDOHBJAPLPF_JsonData friendLimit = jsonData["friendLimit"];
			FriendLimit = (int)friendLimit;

			EDOHBJAPLPF_JsonData res = GetBaseMessage();
			res["friend_limit"] = FriendLimit;
			res["updated_at"] = Utility.GetCurrentUnixTime();

			SendMessage(callbackId, res);

			return 0;
		}
		public static int SakashoFriendGetReceivedRequests(int callbackId, string json)
		{
			EDOHBJAPLPF_JsonData jsonData = IKPIMINCOPI_JsonMapper.PFAMKCGJKKL_ToObject(json);
			int page = (int)jsonData["page"];
			int ipp = (int)jsonData["ipp"];
			
			EDOHBJAPLPF_JsonData res = GetBaseMessage();
			res["count"] = 0;
			res["current_page"] = page;
			res["friend_requests"] = new EDOHBJAPLPF_JsonData();
			res["friend_requests"].LAJDIPCJCPO_SetJsonType(JFBMDLGBPEN_JsonType.BDHGEFMCJDF_Array);
			res["next_page"] = 0;
			res["previous_page"] = 0;

			SendMessage(callbackId, res);

			return 0;
		}
		public static int SakashoFriendGetSentRequests(int callbackId, string json)
		{
			EDOHBJAPLPF_JsonData jsonData = IKPIMINCOPI_JsonMapper.PFAMKCGJKKL_ToObject(json);
			int page = (int)jsonData["page"];
			int ipp = (int)jsonData["ipp"];

			EDOHBJAPLPF_JsonData res = GetBaseMessage();
			res["count"] = 0;
			res["current_page"] = page;
			res["friend_requests"] = new EDOHBJAPLPF_JsonData();
			res["friend_requests"].LAJDIPCJCPO_SetJsonType(JFBMDLGBPEN_JsonType.BDHGEFMCJDF_Array);
			res["next_page"] = 0;
			res["previous_page"] = 0;

			SendMessage(callbackId, res);

			return 0;
		}

		public static int SakashoFriendRefuseFriendRequest(int callbackId, string json)
		{
			EDOHBJAPLPF_JsonData res = GetBaseMessage();
			SendMessage(callbackId, res);

			return 0;
		}

		public static int SakashoFriendAcceptFriendRequest(int callbackId, string json)
		{
			EDOHBJAPLPF_JsonData res = GetBaseMessage();
			SendMessage(callbackId, res);

			return 0;
		}
		

		public static int SakashoFriendGetFriends(int callbackId, string json)
		{
			EDOHBJAPLPF_JsonData jsonData = IKPIMINCOPI_JsonMapper.PFAMKCGJKKL_ToObject(json);
			int page = (int)jsonData["page"];
			int ipp = (int)jsonData["ipp"];

			EDOHBJAPLPF_JsonData res = GetBaseMessage();
			res["count"] = 0;
			res["current_page"] = page;
			res["friends"] = new EDOHBJAPLPF_JsonData();
			res["friends"].LAJDIPCJCPO_SetJsonType(JFBMDLGBPEN_JsonType.BDHGEFMCJDF_Array);
			res["next_page"] = 0;
			res["previous_page"] = 0;

			SendMessage(callbackId, res);

			return 0;
		}
	}
}
