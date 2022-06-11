using SakashoSystemCallback;

public class SakashoSupportSite : SakashoAPIBase
{
	// // RVA: 0x2E68CF4 Offset: 0x2E68CF4 VA: 0x2E68CF4
	public static SakashoAPICallContext GetToken(OnSuccess onSuccess, OnError onError)
    {
        int callID = SakashoAPIBase.Call(SakashoSupportSiteGetToken, "", onSuccess, onError);
        return new SakashoAPICallContext(callID);
    }

	// // RVA: 0x2E68DD8 Offset: 0x2E68DD8 VA: 0x2E68DD8
	// public static SakashoAPICallContext GetInformationURL(OnSuccess onSuccess, OnError onError) { }

	// // RVA: 0x2E68EBC Offset: 0x2E68EBC VA: 0x2E68EBC
	// public static SakashoAPICallContext GetInquiryURL(OnSuccess onSuccess, OnError onError) { }

	// // RVA: 0x2E68FA0 Offset: 0x2E68FA0 VA: 0x2E68FA0
	// public static SakashoAPICallContext GetOpinionURL(OnSuccess onSuccess, OnError onError) { }

	// // RVA: 0x2E69084 Offset: 0x2E69084 VA: 0x2E69084
	// public static SakashoAPICallContext GetCommonTemplateURL(string name, OnSuccess onSuccess, OnError onError) { }

	// // RVA: 0x2E691FC Offset: 0x2E691FC VA: 0x2E691FC
	// public static SakashoAPICallContext GetRemainingForCurrencyIdsURL(int[] ids, OnSuccess onSuccess, OnError onError) { }

	// // RVA: 0x2E69438 Offset: 0x2E69438 VA: 0x2E69438
	// public static SakashoAPICallContext GetConstrainedPlayerDataURL(OnSuccess onSuccess, OnError onError) { }

	// // RVA: 0x2E6951C Offset: 0x2E6951C VA: 0x2E6951C
	// public static SakashoAPICallContext GetConstrainedPlayerDataEditURL(string label, OnSuccess onSuccess, OnError onError) { }

	// // RVA: 0x2E69694 Offset: 0x2E69694 VA: 0x2E69694
	// public static SakashoAPICallContext GetOriginalTemplateURL(string name, OnSuccess onSuccess, OnError onError) { }

	// // RVA: 0x2E6980C Offset: 0x2E6980C VA: 0x2E6980C
	// public static SakashoAPICallContext GetViolationReportURL(int offenderPlayerId, string offenderPlayerName, string violationContentExtra, OnSuccess onSuccess, OnError onError) { }

	// // RVA: 0x2E69A04 Offset: 0x2E69A04 VA: 0x2E69A04
	// public static SakashoAPICallContext GetGuildBbsThreadURL(OnSuccess onSuccess, OnError onError) { }

	// // RVA: 0x2E69AE8 Offset: 0x2E69AE8 VA: 0x2E69AE8
	// public static SakashoAPICallContext SetLocaleAndTimeZone(string locale, string timeZone, OnSuccess onSuccess, OnError onError) { }

	// // RVA: 0x2E69CA4 Offset: 0x2E69CA4 VA: 0x2E69CA4
	// public static SakashoAPICallContext GetLocaleAndTimeZone(OnSuccess onSuccess, OnError onError) { }

	// // RVA: 0x2E69D88 Offset: 0x2E69D88 VA: 0x2E69D88
	// public static SakashoAPICallContext GetInformationDetailURL(string keyName, OnSuccess onSuccess, OnError onError) { }

	// // RVA: 0x2E69F00 Offset: 0x2E69F00 VA: 0x2E69F00
	// public static SakashoAPICallContext GetInformationTopURL(OnSuccess onSuccess, OnError onError) { }

	// // RVA: 0x2E69FE4 Offset: 0x2E69FE4 VA: 0x2E69FE4
	// public static SakashoAPICallContext BuildUrl(string path, string lang, OnSuccess onSuccess, OnError onError) { }

	// // RVA: 0x2E6A1A0 Offset: 0x2E6A1A0 VA: 0x2E6A1A0
	private static /*extern*/ int SakashoSupportSiteGetToken(int callbackId, string json)
    {
        // call lib sakasho.SakashoSupportSiteGetToken
        UnityEngine.Debug.LogError("TODO SakashoSupportSiteGetToken");
        return 0;
    }

	// // RVA: 0x2E6A2A8 Offset: 0x2E6A2A8 VA: 0x2E6A2A8
	// private static extern int SakashoSupportSiteGetInformationURL(int callbackId, string json) { }

	// // RVA: 0x2E6A3B8 Offset: 0x2E6A3B8 VA: 0x2E6A3B8
	// private static extern int SakashoSupportSiteGetInquiryURL(int callbackId, string json) { }

	// // RVA: 0x2E6A4C8 Offset: 0x2E6A4C8 VA: 0x2E6A4C8
	// private static extern int SakashoSupportSiteGetOpinionURL(int callbackId, string json) { }

	// // RVA: 0x2E6A5D8 Offset: 0x2E6A5D8 VA: 0x2E6A5D8
	// private static extern int SakashoSupportSiteGetCommonTemplateURL(int callbackId, string json) { }

	// // RVA: 0x2E6A6F0 Offset: 0x2E6A6F0 VA: 0x2E6A6F0
	// private static extern int SakashoSupportSiteGetRemainingForCurrencyIdsURL(int callbackId, string json) { }

	// // RVA: 0x2E6A810 Offset: 0x2E6A810 VA: 0x2E6A810
	// private static extern int SakashoSupportSiteGetConstrainedPlayerDataURL(int callbackId, string json) { }

	// // RVA: 0x2E6A930 Offset: 0x2E6A930 VA: 0x2E6A930
	// private static extern int SakashoSupportSiteGetConstrainedPlayerDataEditURL(int callbackId, string json) { }

	// // RVA: 0x2E6AA50 Offset: 0x2E6AA50 VA: 0x2E6AA50
	// private static extern int SakashoSupportSiteGetOriginalTemplateURL(int callbackId, string json) { }

	// // RVA: 0x2E6AB68 Offset: 0x2E6AB68 VA: 0x2E6AB68
	// private static extern int SakashoSupportSiteGetViolationReportURL(int callbackId, string json) { }

	// // RVA: 0x2E6AC80 Offset: 0x2E6AC80 VA: 0x2E6AC80
	// private static extern int SakashoSupportSiteGetGuildBbsThreadURL(int callbackId, string json) { }

	// // RVA: 0x2E6AD98 Offset: 0x2E6AD98 VA: 0x2E6AD98
	// private static extern int SakashoSupportSiteSetLocaleAndTimeZone(int callbackId, string json) { }

	// // RVA: 0x2E6AEB0 Offset: 0x2E6AEB0 VA: 0x2E6AEB0
	// private static extern int SakashoSupportSiteGetLocaleAndTimeZone(int callbackId, string json) { }

	// // RVA: 0x2E6AFC8 Offset: 0x2E6AFC8 VA: 0x2E6AFC8
	// private static extern int SakashoSupportSiteGetInformationDetailURL(int callbackId, string json) { }

	// // RVA: 0x2E6B0E0 Offset: 0x2E6B0E0 VA: 0x2E6B0E0
	// private static extern int SakashoSupportSiteGetInformationTopURL(int callbackId, string json) { }

	// // RVA: 0x2E6B1F8 Offset: 0x2E6B1F8 VA: 0x2E6B1F8
	// private static extern int SakashoSupportSiteBuildUrl(int callbackId, string json) { }
}
