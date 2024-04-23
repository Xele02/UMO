using ExternLib.Java_Sakasho.jp.dena.sakasho.core.network;
using ExternLib.Java_Sakasho.jp.dena.sakasho.core.delegate_;

namespace ExternLib.Java_Sakasho
{
    public class db
    {
        class __b : bg 
        {
            private bg _a;
            private bool _b;

            public __b(bg var1, bool var2)
            {
                this._a = var1;
                this._b = false;
            }

            public void a(int var1, string var2, byte[] var3)
            {
                TodoLogger.LogError(TodoLogger.SakashoSystem, "TODO");
                /*if (this.a != null) {
                    String var5 = ey.a(var2, var3);
                    JSONObject var6 = ey.a(var3);
                    var2 = var5;
                    g var8;
                    if (var5.equals(g.ct.a)) {
                        String var7 = ev.a(var6, "message", (String)null);
                        g var9 = g.eh;
                        var8 = var9;
                        if (!var9.a.equals(var7)) {
                        var9 = g.P;
                        var8 = var9;
                        if (!var9.a.equals(var7)) {
                            var9 = g.cE;
                            var8 = var9;
                            if (!var9.a.equals(var7)) {
                                var8 = g.n;
                            }
                        }
                        }

                        var1 = var8.b;
                        var2 = var8.a;
                    }

                    if (!var2.equals(g.eh.a) && !var2.equals(g.P.a)) {
                        this.a.a(var1, var2, var3);
                    } else {
                        if (var2.equals(g.eh.a)) {
                        int var4 = db.f();
                        var2 = ev.a(var6, "active_game_id", (String)null);
                        if (var2 == null) {
                            bg var10 = this.a;
                            var8 = g.m;
                            StringBuilder var11 = new StringBuilder("Illegal JSON response: ");
                            var11.append(ez.a(var3));
                            ex.a(var10, var8, var11.toString());
                            return;
                        }

                        var1 = var4;
                        if (!this.b) {
                            var1 = var4;
                            if (!SakashoSystem.f(var2)) {
                                ex.a(this.a, "Unable to delete previous user's data");
                                return;
                            }
                        }
                        } else {
                        var1 = db.g();
                        }

                        this.a(var3, var1);
                    }
                }*/
            }

            public void a(int var1, bv[] var2, byte[] var3)
            {
                if (this._a != null)
                {
                    this._a.a(var1, var2, var3);
                }
            }
        }

        private static string _a = "db";
        private static int _b;
        private static int _c;

        private db() {
        }

        public static void a(bg var0)
        {
            SakashoRequest var1 = new SakashoRequest();
            var1._a = "/v1/status";
            var1.a(new CookedResponseDelegate(new db.__b(var0, false)));
        }
    }
}
