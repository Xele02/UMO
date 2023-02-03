using XeSys;

namespace ExternLib
{
	public static partial class LibSakasho
	{
		public static int SakashoFCMPushNotificationGetFCMTokens(int callbackId, string json)
		{
			UnityEngine.Debug.Log("SakashoFCMPushNotificationGetFCMTokens " + json);

			string message = @"
{
    ""SAKASHO_CURRENT_ASSET_REVISION"": ""20220602120304"",
    ""SAKASHO_CURRENT_DATE_TIME"": "+Utility.GetCurrentUnixTime()+ @",
    ""SAKASHO_CURRENT_MASTER_REVISION"": 5,
    ""fcm_tokens"": [
        {
            ""created_at"": 1654415099,
            ""fcm_token"": ""fsv1QPtYSk29XEGdFahQbX:APA91bE12ybizthTK7N6v35M2G6HDBtFBnvq6zuUTb6xidoAq8TPwzucNwExrCIVuDloSk1i-KoP6TBHjZ9fFfI2CBEOJNkSwFHac6F82TL5O7weJczCyu1L-M8IB7A4qsUteKcWb1Ce"",
            ""updated_at"": 1654415099
        }
    ]
}
";

			UnityEngine.GameObject.Find(UnityCallbackObject).SendMessage("NotifyOnSuccess", "" + callbackId + ":" + message);

			return 0;
		}
		public static int SakashoFCMPushNotificationAcceptPushNotification(int callbackId, string json)
		{
			UnityEngine.Debug.Log("SakashoFCMPushNotificationAcceptPushNotification " + json);

			string message = "";

			UnityEngine.GameObject.Find(UnityCallbackObject).SendMessage("NotifyOnSuccess", "" + callbackId + ":" + message);

			return 0;
		}

		public static int SakashoFCMPushNotificationBlockPushNotification(int callbackId, string json)
		{
			UnityEngine.Debug.Log("SakashoFCMPushNotificationBlockPushNotification " + json);

			string message = "";

			UnityEngine.GameObject.Find(UnityCallbackObject).SendMessage("NotifyOnSuccess", "" + callbackId + ":" + message);

			return 0;
		}
	}
}
