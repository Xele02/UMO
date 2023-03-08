using XeSys;

namespace ExternLib
{
	public static partial class LibSakasho
	{
		public static int SakashoFCMPushNotificationGetFCMTokens(int callbackId, string json)
		{
			UnityEngine.Debug.Log("SakashoFCMPushNotificationGetFCMTokens " + json);

			EDOHBJAPLPF_JsonData message = GetBaseMessage();
			message["fcm_tokens"] = new EDOHBJAPLPF_JsonData();
			message["fcm_tokens"].LAJDIPCJCPO_SetJsonType(JFBMDLGBPEN_JsonType.BDHGEFMCJDF_Array);
			message["fcm_tokens"].Add(new EDOHBJAPLPF_JsonData());
			message["fcm_tokens"][0]["created_at"] = 1654415099;
			message["fcm_tokens"][0]["fcm_token"] = "fsv1QPtYSk29XEGdFahQbX:APA91bE12ybizthTK7N6v35M2G6HDBtFBnvq6zuUTb6xidoAq8TPwzucNwExrCIVuDloSk1i-KoP6TBHjZ9fFfI2CBEOJNkSwFHac6F82TL5O7weJczCyu1L-M8IB7A4qsUteKcWb1Ce";
			message["fcm_tokens"][0]["updated_at"] = 1654415099;

			SendMessage(callbackId, message);

			return 0;
		}
		public static int SakashoFCMPushNotificationAcceptPushNotification(int callbackId, string json)
		{
			UnityEngine.Debug.Log("SakashoFCMPushNotificationAcceptPushNotification " + json);

			EDOHBJAPLPF_JsonData res = GetBaseMessage();
			SendMessage(callbackId, res);

			return 0;
		}

		public static int SakashoFCMPushNotificationBlockPushNotification(int callbackId, string json)
		{
			UnityEngine.Debug.Log("SakashoFCMPushNotificationBlockPushNotification " + json);

			EDOHBJAPLPF_JsonData res = GetBaseMessage();
			SendMessage(callbackId, res);

			return 0;
		}
	}
}
