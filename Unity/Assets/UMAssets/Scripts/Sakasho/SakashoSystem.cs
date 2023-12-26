public class SakashoSystem
{
	public enum PaymentType
	{
		MIXED = 0,
		V1 = 1,
		V2 = 2,
	}

	public enum ServerMode
	{
		SANDBOX = 0,
		PRODUCTION = 1,
	}


	private const string sdkType = "Unity";
	private const string sdkVersionNumber = "1.88.1";
	private const string sdkBuildId = "d165afc3ecc8e788f0dbc7b48d0ccc8cd0e791b9";

	// // RVA: 0x2E6B308 Offset: 0x2E6B308 VA: 0x2E6B308
	// public static int InitializeAndApp(string clientId) { }

	// // RVA: 0x2E6B310 Offset: 0x2E6B310 VA: 0x2E6B310
	// public static bool Initialize(SakashoSystem.ServerMode serverMode, string gameId, string commonKey) { }

	// // RVA: 0x2E6B32C Offset: 0x2E6B32C VA: 0x2E6B32C
	public static bool Initialize(ServerMode serverMode, string gameId, string commonKey, PaymentType paymentType)
	{
		if(UnitySakashoSystemInitialize("Unity", "1.88.1", (int)serverMode, gameId, commonKey, (int)paymentType))
		{
			UnitySetCallbackReceiverName(SakashoCallbackRegistry.GameObjectName);
			SakashoAPICallContext.Initialize((int callId) => {
				//0x2E6BEBC
				return CancelAPICall(callId);
			});
			return true;
		}
		return false;
	}

	// // RVA: 0x2E6B754 Offset: 0x2E6B754 VA: 0x2E6B754
	public static void Finish()
	{
		SakashoSystemFinish();
		SakashoAPICallContext.Finish();
	}

	// // RVA: 0x2E6B86C Offset: 0x2E6B86C VA: 0x2E6B86C
	public static void Pause()
	{
		SakashoSystemPause();
	}

	// // RVA: 0x2E6B96C Offset: 0x2E6B96C VA: 0x2E6B96C
	public static void Resume()
	{
		SakashoSystemResume();
	}

	// // RVA: 0x2E6BA6C Offset: 0x2E6BA6C VA: 0x2E6BA6C
	// public static string GetBuildId() { }

	// // RVA: 0x2E6BAC8 Offset: 0x2E6BAC8 VA: 0x2E6BAC8
	// public static void SetActiveGameId(string activeGameId) { }

	// // RVA: 0x2E6BBCC Offset: 0x2E6BBCC VA: 0x2E6BBCC
	// public static string GetConnectingGameId() { }

	// // RVA: 0x2E6BCC4 Offset: 0x2E6BCC4 VA: 0x2E6BCC4
	public static bool CancelAPICall(int callId)
	{
		if(callId > 0)
		{
			SakashoSystemCancelAPICall(callId);
			SakashoAPIBase.RemoveCallbackByCallId(callId);
			return true;
		}
		return false;
	}

	// // RVA: 0x2E6BDDC Offset: 0x2E6BDDC VA: 0x2E6BDDC
	// public static string GetSDKVersionNumber() { }

	// // RVA: 0x2E6B4E8 Offset: 0x2E6B4E8 VA: 0x2E6B4E8
	private static /*extern*/ bool UnitySakashoSystemInitialize(string sdkType, string sdkVersionNumber, int serverMode, string gameId, string commonKey, int paymentType)
	{
		return ExternLib.LibSakasho.UnitySakashoSystemInitialize(sdkType, sdkVersionNumber, serverMode, gameId, commonKey, paymentType);
	}

	// // RVA: 0x2E6B658 Offset: 0x2E6B658 VA: 0x2E6B658
	private static /*extern */void UnitySetCallbackReceiverName(string callbackReceiverName)
	{
		ExternLib.LibSakasho.UnitySetCallbackReceiverName(callbackReceiverName);
	}

	// // RVA: 0x2E6B770 Offset: 0x2E6B770 VA: 0x2E6B770
	private static void SakashoSystemFinish()
	{
		ExternLib.LibSakasho.SakashoSystemFinish();
	}

	// // RVA: 0x2E6B870 Offset: 0x2E6B870 VA: 0x2E6B870
	private static void SakashoSystemPause()
	{
		ExternLib.LibSakasho.SakashoSystemPause();
	}

	// // RVA: 0x2E6B970 Offset: 0x2E6B970 VA: 0x2E6B970
	private static /*extern*/ void SakashoSystemResume()
	{
		ExternLib.LibSakasho.SakashoSystemResume();
	}

	// // RVA: 0x2E6BAD0 Offset: 0x2E6BAD0 VA: 0x2E6BAD0
	// private static extern void SakashoSystemSetActiveGameId(string activeGameId) { }

	// // RVA: 0x2E6BBD0 Offset: 0x2E6BBD0 VA: 0x2E6BBD0
	// private static extern string SakashoSystemGetConnectingGameId() { }

	// // RVA: 0x2E6BD00 Offset: 0x2E6BD00 VA: 0x2E6BD00
	private static /*extern */void SakashoSystemCancelAPICall(int callId)
	{
		ExternLib.LibSakasho.SakashoSystemCancelAPICall(callId);
	}
}
