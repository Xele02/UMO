using XeSys;

namespace ExternLib
{
    public static partial class LibSakasho
    {
        public static int SakashoHadoopLogSendLogToHadoop(int callbackId, string json)
        {
            UnityEngine.Debug.Log("SakashoHadoopLogSendLogToHadoop "+json);
            
            // Hack directly send response
            string message =
@"{
    ""SAKASHO_CURRENT_ASSET_REVISION"": ""20220613222105"",
    ""SAKASHO_CURRENT_DATE_TIME"": "+Utility.GetCurrentUnixTime()+@",
    ""SAKASHO_CURRENT_MASTER_REVISION"": 5
}";
            UnityEngine.GameObject.Find(UnityCallbackObject).SendMessage("NotifyOnSuccess", ""+callbackId+":"+message);
            // end hack

            return 0;
        }
    }
}