
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
	// [CompilerGeneratedAttribute] // RVA: 0x629FA4 Offset: 0x629FA4 VA: 0x629FA4
	// private int <ResponseCode>k__BackingField; // 0x8
	// [CompilerGeneratedAttribute] // RVA: 0x629FB4 Offset: 0x629FB4 VA: 0x629FB4
	// private string <ErrorCode>k__BackingField; // 0xC
	// [CompilerGeneratedAttribute] // RVA: 0x629FC4 Offset: 0x629FC4 VA: 0x629FC4
	// private string <ErrorDetailJSON>k__BackingField; // 0x10
	// [CompilerGeneratedAttribute] // RVA: 0x629FD4 Offset: 0x629FD4 VA: 0x629FD4
	// private string <ResponseBodyJSON>k__BackingField; // 0x14

	public int ResponseCode { get; set; }
	public string ErrorCode { get; set; }
	public string ErrorDetailJSON { get; set; }
	public string ResponseBodyJSON { get; set; }

	// // RVA: 0x307A048 Offset: 0x307A048 VA: 0x307A048
	public SakashoError(int responseCode, string responseBodyJSON)
    { 
        UnityEngine.Debug.LogError("TODO");
    }

	// [CompilerGeneratedAttribute] // RVA: 0x62A704 Offset: 0x62A704 VA: 0x62A704
	// // RVA: 0x307A40C Offset: 0x307A40C VA: 0x307A40C
	// public int get_ResponseCode() { }

	// [CompilerGeneratedAttribute] // RVA: 0x62A714 Offset: 0x62A714 VA: 0x62A714
	// // RVA: 0x307A3E4 Offset: 0x307A3E4 VA: 0x307A3E4
	// private void set_ResponseCode(int value) { }

	// [CompilerGeneratedAttribute] // RVA: 0x62A724 Offset: 0x62A724 VA: 0x62A724
	// // RVA: 0x307A3FC Offset: 0x307A3FC VA: 0x307A3FC
	// public string get_ErrorCode() { }

	// [CompilerGeneratedAttribute] // RVA: 0x62A734 Offset: 0x62A734 VA: 0x62A734
	// // RVA: 0x307A3F4 Offset: 0x307A3F4 VA: 0x307A3F4
	// private void set_ErrorCode(string value) { }

	// [CompilerGeneratedAttribute] // RVA: 0x62A744 Offset: 0x62A744 VA: 0x62A744
	// // RVA: 0x307A414 Offset: 0x307A414 VA: 0x307A414
	// public string get_ErrorDetailJSON() { }

	// [CompilerGeneratedAttribute] // RVA: 0x62A754 Offset: 0x62A754 VA: 0x62A754
	// // RVA: 0x307A404 Offset: 0x307A404 VA: 0x307A404
	// private void set_ErrorDetailJSON(string value) { }

	// [CompilerGeneratedAttribute] // RVA: 0x62A764 Offset: 0x62A764 VA: 0x62A764
	// // RVA: 0x307A41C Offset: 0x307A41C VA: 0x307A41C
	// public string get_ResponseBodyJSON() { }

	// [CompilerGeneratedAttribute] // RVA: 0x62A774 Offset: 0x62A774 VA: 0x62A774
	// // RVA: 0x307A3EC Offset: 0x307A3EC VA: 0x307A3EC
	// private void set_ResponseBodyJSON(string value) { }

	// // RVA: 0x307A424 Offset: 0x307A424 VA: 0x307A424
	// public SakashoErrorId getErrorId() { }
}
