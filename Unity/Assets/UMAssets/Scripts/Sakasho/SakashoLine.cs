using SakashoSystemCallback;

public class SakashoLine : SakashoAPIBase
{
	//// RVA: 0x2BC9A74 Offset: 0x2BC9A74 VA: 0x2BC9A74
	//public static void CallCreatePlayerFromLineAfterOAuth() { }

	//// RVA: 0x2BC9B10 Offset: 0x2BC9B10 VA: 0x2BC9B10
	//public static void CallLinkWithLineAfterOAuth() { }

	//// RVA: 0x2BC9BAC Offset: 0x2BC9BAC VA: 0x2BC9BAC
	public static SakashoAPICallContext GetLineLinkageStatus(OnSuccess onSuccess, OnError onError)
	{
		return new SakashoAPICallContext(Call(SakashoLineGetLineLinkageStatus, "", onSuccess, onError));
	}

	//// RVA: 0x2BC9C90 Offset: 0x2BC9C90 VA: 0x2BC9C90
	//public static SakashoAPICallContext LinkWithLine(bool isOverwritable, OnSuccess onSuccess, OnError onError) { }

	//// RVA: 0x2BC9E20 Offset: 0x2BC9E20 VA: 0x2BC9E20
	//public static SakashoAPICallContext UnlinkLine(OnSuccess onSuccess, OnError onError) { }

	//// RVA: 0x2BC9F04 Offset: 0x2BC9F04 VA: 0x2BC9F04
	//public static void ClearCallback() { }

	//// RVA: 0x2BC9FA0 Offset: 0x2BC9FA0 VA: 0x2BC9FA0
	//public static SakashoAPICallContext GetAuthenticateUrl(bool isOverwritable, OnSuccess onSuccess, OnError onError) { }

	//// RVA: 0x2BCA130 Offset: 0x2BCA130 VA: 0x2BCA130
	//public static SakashoAPICallContext CallLinkWithLineAfterOauthWithCallback(OnSuccess onSuccess, OnError onError) { }

	//// RVA: 0x2BCA214 Offset: 0x2BCA214 VA: 0x2BCA214
	//public static SakashoAPICallContext CallCreatePlayerFromLineAfterOauthWithCallback(OnSuccess onSuccess, OnError onError) { }

	//// RVA: 0x2BCA2F8 Offset: 0x2BCA2F8 VA: 0x2BCA2F8
	//public static void CancelLinkWithLineBeforeOauth() { }

	//// RVA: 0x2BCA398 Offset: 0x2BCA398 VA: 0x2BCA398
	//private static extern int SakashoLineCallCreatePlayerFromLineAfterOAuth(int callbackId, string json) { }

	//// RVA: 0x2BCA4B8 Offset: 0x2BCA4B8 VA: 0x2BCA4B8
	//private static extern int SakashoLineCallLinkWithLineAfterOAuth(int callbackId, string json) { }

	//// RVA: 0x2BCA5D0 Offset: 0x2BCA5D0 VA: 0x2BCA5D0
	private static int SakashoLineGetLineLinkageStatus(int callbackId, string json)
	{
		return ExternLib.LibSakasho.SakashoLineGetLineLinkageStatus(callbackId, json);
	}

	//// RVA: 0x2BCA6E0 Offset: 0x2BCA6E0 VA: 0x2BCA6E0
	//private static extern int SakashoLineLinkWithLine(int callbackId, string json) { }

	//// RVA: 0x2BCA820 Offset: 0x2BCA820 VA: 0x2BCA820
	//private static extern int SakashoLineUnlinkLine(int callbackId, string json) { }

	//// RVA: 0x2BCA960 Offset: 0x2BCA960 VA: 0x2BCA960
	//private static extern int SakashoLineClearCallback(int callbackId, string json) { }

	//// RVA: 0x2BCAAA8 Offset: 0x2BCAAA8 VA: 0x2BCAAA8
	//private static extern int SakashoLineGetAuthenticateUrl(int callbackId, string json) { }

	//// RVA: 0x2BCABB8 Offset: 0x2BCABB8 VA: 0x2BCABB8
	//private static extern int SakashoLineCallLinkWithLineAfterOauthWithCallback(int callbackId, string json) { }

	//// RVA: 0x2BCACD8 Offset: 0x2BCACD8 VA: 0x2BCACD8
	//private static extern int SakashoLineCallCreatePlayerFromLineAfterOauthWithCallback(int callbackId, string json) { }

	//// RVA: 0x2BCAE00 Offset: 0x2BCAE00 VA: 0x2BCAE00
	//private static extern int SakashoLineCancelLinkWithLineBeforeOauth(int callbackId, string json) { }
}
