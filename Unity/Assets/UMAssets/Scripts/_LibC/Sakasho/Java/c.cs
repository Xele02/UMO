using ExternLib.Java_Sakasho.jp.dena.sakasho.core;

namespace ExternLib.Java_Sakasho
{
    public class c : bg
    {
        class __1 : Runnable
        {
            byte[] _a;
            c _b;

            public __1(c var1, byte[] var2)
            {
                this._b = var1;
                this._a = var2;
            }

            public void run()
            {
                c.a(this._b, this._a);
            }
        }
        private static string _a = "c";
        private ExternLib.Java_Sakasho.jp.dena.sakasho.api.SakashoSystem.OnSuccess _b;
        private ExternLib.Java_Sakasho.jp.dena.sakasho.api.SakashoSystem.OnError _c;
        private int _d;

        public c(ExternLib.Java_Sakasho.jp.dena.sakasho.api.SakashoSystem.OnSuccess var1, ExternLib.Java_Sakasho.jp.dena.sakasho.api.SakashoSystem.OnError var2, int var3) {
            this._b = var1;
            this._c = var2;
            this._d = var3;
        }

        public void a(int var1, string var2, byte[] var3)
        {
            TodoLogger.LogError(TodoLogger.SakashoSystem, "TODO");
            //jp.dena.sakasho.core.SakashoSystem.a(new c.__2(this, var1, var2, var3), true);
        }
        public void a(int var1, bv[] var2, byte[] var3) {
            jp.dena.sakasho.core.SakashoSystem.a(new c.__1(this, var3), true);
        }
        static void a(c var0, byte[] var1)
        {
            string var2 = ez.a(var1);
            var0._b.onSuccess(var2);
        }
    }
}
