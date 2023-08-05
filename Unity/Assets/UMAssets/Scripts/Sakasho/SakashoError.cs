
using Sakasho.JSON;
using System.Collections;

public class SakashoError
{
	public const string ERROR_401 = "SESSION_NOT_FOUND";
	public const string ERROR_500 = "INTERNAL_SERVER_ERROR";
	public const string ERROR_600 = "INTERNAL_CLIENT_ERROR";
	public const string ERROR_601 = "LOGIC_ERROR";
	public const string ERROR_602 = "ILLEGAL_ARGUMENT";
	public const string ERROR_603 = "NETWORK_ERROR";
	public const string ERROR_604 = "UNSUPPORTED_API_CALLED";
	public const string ERROR_605 = "PLAYER_SESSION_CLOSED";
	public const string ERROR_606 = "LOGOUT_CANCELLED";
	public const string ERROR_1001 = "PURCHASING_FAILED";
	public const string ERROR_1101 = "LOGIN_CANCELLED";

	public int ResponseCode { get; private set; } // 0x8
	public string ErrorCode { get; private set; } // 0xC
	public string ErrorDetailJSON { get; private set; } // 0x10
	public string ResponseBodyJSON { get; private set; } // 0x14

	// // RVA: 0x307A048 Offset: 0x307A048 VA: 0x307A048
	public SakashoError(int responseCode, string responseBodyJSON)
    {
		ResponseBodyJSON = responseBodyJSON;
		ResponseCode = responseCode;
		Hashtable h = MiniJSON.jsonDecode(responseBodyJSON) as Hashtable;
		bool isEmpty = false;
		if (h == null)
		{
			h = new Hashtable();
			isEmpty = true;
		}
		string errorType = "INTERNAL_SERVER_ERROR";
		if (responseCode == 401)
			errorType = "SESSION_NOT_FOUND";
		if (responseCode == 600)
			errorType = "INTERNAL_CLIENT_ERROR";
		string s = h["error_code"] as string;
		if (s != null)
			errorType = s;
		ErrorCode = errorType;
		h = h["error_detail"] as Hashtable;
		if (h != null)
		{
			ErrorDetailJSON = MiniJSON.jsonEncode(h);
			if (!isEmpty)
				return;
		}
		else if (isEmpty)
		{
			h = new Hashtable();
			h["message"] = responseBodyJSON;
			ErrorDetailJSON = MiniJSON.jsonEncode(h);
		}
		else
			return;
		Hashtable h3 = new Hashtable();
		h3["error_code"] = ErrorCode;
		h3["error_detail"] = h;
		ResponseBodyJSON = MiniJSON.jsonEncode(h3);
	}

	// // RVA: 0x307A424 Offset: 0x307A424 VA: 0x307A424
	public SakashoErrorId getErrorId()
	{
		if (ErrorCode == "RANKING_PLAYER_NOT_FOUND")
			return SakashoErrorId.RANKING_PLAYER_NOT_FOUND;
		TodoLogger.LogError(0, "getErrorId "+ErrorCode);
		return SakashoErrorId.UNKNOWN;
	}
}
