using ExternLib.Java_Sakasho.jp.dena.sakasho.core.network;

namespace ExternLib.Java_Sakasho
{
    public class bh : bg
    {
        private static string _a = "bh";
        private bg _b;
        private SakashoRequest _c;
        private int _d;

        public bh(bg var1, SakashoRequest var2, int var3)
        {
            this._b = var1;
            this._c = var2;
            this._d = var3;
        }
        public void a(int var1, bv[] var2, byte[] var3)
        {
            this.b(var1, var2, var3);
        }

        private static bool a(int var0)
        {
            return var0 == 401;
        }

        public void a(int var1, string var2, byte[] var3)
        {
            if (a(var1))
            {
                UnityEngine.Debug.LogError("");
                // SakashoSystem.i();
                // db.c(new bh.__1(this));
            }
            else
            {
                this._b.a(var1, var2, var3);
            }
        }
        private void b(int var1, bv[] var2, byte[] var3) {
            this._b.a(var1, var2, var3);
        }
    }   
}
