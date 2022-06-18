
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
        UnityEngine.Debug.LogError("TODO");
    }

	// // RVA: 0x307A424 Offset: 0x307A424 VA: 0x307A424
	public SakashoErrorId getErrorId()
	{
		UnityEngine.Debug.LogError("TODO");
		return SakashoErrorId.UNKNOWN;
	}
}
