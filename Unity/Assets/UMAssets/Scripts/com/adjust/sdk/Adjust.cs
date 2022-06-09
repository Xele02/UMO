using UnityEngine;
using System;

namespace com.adjust.sdk
{
	public class Adjust : MonoBehaviour
	{
		private const string errorMsgEditor = "[Adjust]: SDK can not be used in Editor.";
		private const string errorMsgStart = "[Adjust]: SDK not started. Start it manually using the \'start\' method.";
		private const string errorMsgPlatform = "[Adjust]: SDK can only be used in Android, iOS, Windows Phone 8.1, Windows Store or Universal Windows apps.";
		public bool startManually; // 0xC
		public bool eventBuffering; // 0xD
		public bool sendInBackground; // 0xE
		public bool launchDeferredDeeplink; // 0xF
		public string appToken; // 0x10
		public AdjustLogLevel logLevel; // 0x14
		public AdjustEnvironment environment; // 0x18

		// // RVA: 0x274CC30 Offset: 0x274CC30 VA: 0x274CC30
		private void Awake()
		{
			UnityEngine.Debug.LogError("TODO");
		}

		// // RVA: 0x274D108 Offset: 0x274D108 VA: 0x274D108
		// private void OnApplicationPause(bool pauseStatus) { }

		// // RVA: 0x274D038 Offset: 0x274D038 VA: 0x274D038
		// public static void start(AdjustConfig adjustConfig) { }

		// // RVA: 0x274F464 Offset: 0x274F464 VA: 0x274F464
		// public static void trackEvent(AdjustEvent adjustEvent) { }

		// // RVA: 0x274FDC4 Offset: 0x274FDC4 VA: 0x274FDC4
		public static void setEnabled(bool enabled)
		{
			UnityEngine.Debug.LogError("TODO");
		}

		// // RVA: 0x274FFA8 Offset: 0x274FFA8 VA: 0x274FFA8
		// public static bool isEnabled() { }

		// // RVA: 0x2750100 Offset: 0x2750100 VA: 0x2750100
		// public static void setOfflineMode(bool enabled) { }

		// // RVA: 0x27502E4 Offset: 0x27502E4 VA: 0x27502E4
		// public static void setDeviceToken(string deviceToken) { }

		// // RVA: 0x2750508 Offset: 0x2750508 VA: 0x2750508
		// public static void gdprForgetMe() { }

		// // RVA: 0x27506D0 Offset: 0x27506D0 VA: 0x27506D0
		// public static void disableThirdPartySharing() { }

		// // RVA: 0x2750898 Offset: 0x2750898 VA: 0x2750898
		// public static void appWillOpenUrl(string url) { }

		// // RVA: 0x2750BAC Offset: 0x2750BAC VA: 0x2750BAC
		// public static void sendFirstPackages() { }

		// // RVA: 0x2750CF8 Offset: 0x2750CF8 VA: 0x2750CF8
		// public static void addSessionPartnerParameter(string key, string value) { }

		// // RVA: 0x2750FC4 Offset: 0x2750FC4 VA: 0x2750FC4
		// public static void addSessionCallbackParameter(string key, string value) { }

		// // RVA: 0x2751290 Offset: 0x2751290 VA: 0x2751290
		// public static void removeSessionPartnerParameter(string key) { }

		// // RVA: 0x2751500 Offset: 0x2751500 VA: 0x2751500
		// public static void removeSessionCallbackParameter(string key) { }

		// // RVA: 0x2751770 Offset: 0x2751770 VA: 0x2751770
		// public static void resetSessionPartnerParameters() { }

		// // RVA: 0x2751970 Offset: 0x2751970 VA: 0x2751970
		// public static void resetSessionCallbackParameters() { }

		// // RVA: 0x2751B70 Offset: 0x2751B70 VA: 0x2751B70
		// public static void trackAdRevenue(string source, string payload) { }

		// // RVA: 0x2751F00 Offset: 0x2751F00 VA: 0x2751F00
		// public static void trackAppStoreSubscription(AdjustAppStoreSubscription subscription) { }

		// // RVA: 0x2751F8C Offset: 0x2751F8C VA: 0x2751F8C
		// public static void trackPlayStoreSubscription(AdjustPlayStoreSubscription subscription) { }

		// // RVA: 0x27528E0 Offset: 0x27528E0 VA: 0x27528E0
		// public static void trackThirdPartySharing(AdjustThirdPartySharing thirdPartySharing) { }

		// // RVA: 0x27530AC Offset: 0x27530AC VA: 0x27530AC
		// public static void trackMeasurementConsent(bool measurementConsent) { }

		// // RVA: 0x2753290 Offset: 0x2753290 VA: 0x2753290
		public static void requestTrackingAuthorizationWithCompletionHandler(Action<int> statusCallback, string sceneName = "Adjust")
		{
			UnityEngine.Debug.LogError("TODO");
		}

		// // RVA: 0x275331C Offset: 0x275331C VA: 0x275331C
		// public static void updateConversionValue(int conversionValue) { }

		// // RVA: 0x27533A8 Offset: 0x27533A8 VA: 0x27533A8
		// public static int getAppTrackingAuthorizationStatus() { }

		// // RVA: 0x2753438 Offset: 0x2753438 VA: 0x2753438
		// public static string getAdid() { }

		// // RVA: 0x2753590 Offset: 0x2753590 VA: 0x2753590
		// public static AdjustAttribution getAttribution() { }

		// // RVA: 0x27542EC Offset: 0x27542EC VA: 0x27542EC
		// public static string getWinAdid() { }

		// // RVA: 0x2754390 Offset: 0x2754390 VA: 0x2754390
		// public static string getIdfa() { }

		// // RVA: 0x2754434 Offset: 0x2754434 VA: 0x2754434
		// public static string getSdkVersion() { }

		// [ObsoleteAttribute] // RVA: 0x748FA0 Offset: 0x748FA0 VA: 0x748FA0
		// // RVA: 0x27545A8 Offset: 0x27545A8 VA: 0x27545A8
		// public static void setReferrer(string referrer) { }

		// // RVA: 0x27547CC Offset: 0x27547CC VA: 0x27547CC
		// public static void getGoogleAdId(Action<string> onDeviceIdsRead) { }

		// // RVA: 0x2754A10 Offset: 0x2754A10 VA: 0x2754A10
		// public static string getAmazonAdId() { }

		// // RVA: 0x274CDE0 Offset: 0x274CDE0 VA: 0x274CDE0
		// private static bool IsEditor() { }

		// // RVA: 0x2754BE4 Offset: 0x2754BE4 VA: 0x2754BE4
		// public static void SetTestOptions(Dictionary<string, string> testOptions) { }

		// // RVA: 0x2754DF4 Offset: 0x2754DF4 VA: 0x2754DF4
		// public void .ctor() { }
	}
}
