
namespace ExternLib
{
    public static partial class LibSakasho
    {
        public static int SakashoUserTokenGetPlayerStatus(int callbackId, string json)
        {
            //ExternLib.Java_Sakasho.jp.dena.sakasho.api.SakashoAPICallContext context = ExternLib.Java_Sakasho.jp.dena.sakasho.api.SakashoUserToken.getPlayerStatus(null, null);
    
            // Hack directly send response
            string message =
@"{
    ""SAKASHO_CURRENT_ASSET_REVISION"": ""20220602120304"",
    ""SAKASHO_CURRENT_DATE_TIME"": 1654415200,
    ""SAKASHO_CURRENT_MASTER_REVISION"": 5,
    ""is_created"": 1,
    ""player_account_status"": 0,
    ""player_id"": 123456789
}";
            UnityEngine.GameObject.Find(UnityCallbackObject).SendMessage("NotifyOnSuccess", ""+callbackId+":"+message);
            // end hack

            return 0;
        }
    }
}