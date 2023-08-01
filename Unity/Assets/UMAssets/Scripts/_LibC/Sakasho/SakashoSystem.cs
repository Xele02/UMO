
using Sakasho.JSON;
using XeSys;

namespace ExternLib
{
    public static partial class LibSakasho
    {
        public static void SakashoSystemResume()
        {
            TodoLogger.LogError(TodoLogger.SakashoSystem, "LibSakasho.SakashoSystemResume");
        }

		public static void SakashoSystemCancelAPICall(int callId)
		{
			TodoLogger.LogError(TodoLogger.SakashoSystem, "LibSakasho.SakashoSystemCancelAPICall");
		}

		public static EDOHBJAPLPF_JsonData GetBaseMessage()
		{
			EDOHBJAPLPF_JsonData res = new EDOHBJAPLPF_JsonData();
			res.LAJDIPCJCPO_SetJsonType(JFBMDLGBPEN_JsonType.JKMLKAMHJIF_Object);
			res["SAKASHO_CURRENT_ASSET_REVISION"] = "20220622141305";
			res["SAKASHO_CURRENT_DATE_TIME"] = Utility.GetCurrentUnixTime();
			res["SAKASHO_CURRENT_MASTER_REVISION"] = 5;
			return res;
		}

		public static void SendMessage(int callbackId, string message)
		{
			message = MiniJSON.jsonEncode(MiniJSON.jsonDecode(message));
			UnityEngine.GameObject.Find(UnityCallbackObject).SendMessage("NotifyOnSuccess", "" + callbackId + ":" + message);
		}
		public static void SendMessage(int callbackId, EDOHBJAPLPF_JsonData data)
		{
			UnityEngine.GameObject.Find(UnityCallbackObject).SendMessage("NotifyOnSuccess", "" + callbackId + ":" + data.EJCOJCGIBNG_ToJson());
		}

	}
}
