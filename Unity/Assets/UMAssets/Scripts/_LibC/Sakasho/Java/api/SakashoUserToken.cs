
namespace ExternLib.Java_Sakasho.jp.dena.sakasho.api
{
    public class SakashoUserToken
    {
        /*public static SakashoAPICallContext getUserToken(String var0, SakashoSystem.OnSuccess var1, SakashoSystem.OnError var2)
        {
            SakashoAPICallContext var3 = new SakashoAPICallContext(0);
            if (jp.dena.sakasho.core.SakashoSystem.isDebugBuild())
            {
                db.b(var0, new c(var1, var2, 0));
            }

            return var3;
        }*/

        public static SakashoAPICallContext getPlayerStatus(SakashoSystem.OnSuccess var0, SakashoSystem.OnError var1)
        {
            int var2 = jp.dena.sakasho.core.SakashoSystem.o();
            SakashoAPICallContext var3 = new SakashoAPICallContext(var2);
            db.a(new c(var0, var1, var2));
            return var3;
        }
    }
}