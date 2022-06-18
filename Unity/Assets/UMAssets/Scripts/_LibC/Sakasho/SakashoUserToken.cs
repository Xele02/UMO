
namespace ExternLib
{
    public static partial class LibSakasho
    {
        public static int SakashoUserTokenGetPlayerStatus(int callbackId, string json)
        {
            ExternLib.Java_Sakasho.jp.dena.sakasho.api.SakashoAPICallContext context = ExternLib.Java_Sakasho.jp.dena.sakasho.api.SakashoUserToken.getPlayerStatus(null, null);
            return 0;
        }
    }
}