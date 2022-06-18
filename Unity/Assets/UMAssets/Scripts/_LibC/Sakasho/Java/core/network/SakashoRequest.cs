using ExternLib.Java_Sakasho;
using System.Text;
using System.Collections.Generic;

namespace ExternLib.Java_Sakasho.jp.dena.sakasho.core.network
{
    public class SakashoRequest
    {
        class __1 : Runnable
        {
            bg _a;
            SakashoRequest _b;

            public __1(SakashoRequest var1, bg var2)
            {
                this._b = var1;
                this._a = var2;
            }

            public void run()
            {
                SakashoRequest.a(this._b, new bh(this._a, this._b, SakashoRequest.e()));
            }
        }
        public class __a
        {
            public static string[] _a = new string[]{"GET", "POST", "PUT", "DELETE", "PATCH"};

            public static string a(int var0)
            {
                return var0 >= 0 && var0 < _a.Length ? _a[var0] : null;
            }
        }

        // private static string _g = "SakashoRequest";
        private static by _h;
        private static bz _i = new bu();
        // private static String _j;
        private static string _k;
        private static int _l;
        public string _a;
        public int _b = 0;
        public bz _c;
        public bool _d;
        public string _e;
        private Dictionary<string, object> _f = new Dictionary<string, object>();

        public SakashoRequest()
        {
            this._c = _i;
            this._d = false;
            this._e = "_default";
        }

        public void a(bg var1)
        {
            ExternLib.Java_Sakasho.jp.dena.sakasho.core.SakashoSystem.a(new __1(this, var1));
        }

        static int e()
        {
            return _l;
        }

        static void a(SakashoRequest var0, bg var1)
        {
            ExternLib.Java_Sakasho.jp.dena.sakasho.core.SakashoSystem.i();
            if (var0._b == 3 && var0._c.c().Length > 0)
            {
                ExternLib.Java_Sakasho.jp.dena.sakasho.core.SakashoSystem.i();
                var0._c = _i;
            }

            int var2 = ExternLib.Java_Sakasho.jp.dena.sakasho.core.SakashoSystem.k();
            StringBuilder var5 = new StringBuilder();
            var5.Append(var0._a);
            string var4;
            if (var0._a.Contains("?"))
            {
                var4 = "&";
            }
            else
            {
                var4 = "?";
            }

            var5.Append(var4);
            var5.Append("_reqid=");
            var5.Append(var2);
            string var6 = var5.ToString();
            ExternLib.Java_Sakasho.jp.dena.sakasho.core.SakashoSystem.i();
            (new StringBuilder("HttpMethod.name(httpMethod): ")).Append(jp.dena.sakasho.core.network.SakashoRequest.__a.a(var0._b));
            ExternLib.Java_Sakasho.jp.dena.sakasho.core.SakashoSystem.i();
            (new StringBuilder("actualApiPath: ")).Append(var6);
            ExternLib.Java_Sakasho.jp.dena.sakasho.core.SakashoSystem.i();
            (new StringBuilder("requestBody.getContent() asString: ")).Append(ez.a(var0._c.b()));
            var4 = var0.a(jp.dena.sakasho.core.network.SakashoRequest.__a.a(var0._b), var0._a, var0._c.c());
            if (var0._d)
            {
                de var11 = df._a.a(var0._e, var4);
                if (var11 != null)
                {
                    ExternLib.Java_Sakasho.jp.dena.sakasho.core.SakashoSystem.i();
                    bv[] var8 = var11._c;
                    List<bv> var12 = new List<bv>();
                    int var3 = var8.Length;

                    for(var2 = 0; var2 < var3; ++var2)
                    {
                        var12.Add(var8[var2]);
                    }

                    var12.Add(new bv("X-Sakasho-Cached-Response", "true"));
                    var1.a(var11._b, var12.ToArray(), var11._d);
                    return;
                }
            }

            string var13 = var0.a(jp.dena.sakasho.core.network.SakashoRequest.__a.a(var0._b), var6, var0._c.c());
            ExternLib.Java_Sakasho.jp.dena.sakasho.core.SakashoSystem.i();
            (new StringBuilder("X-Sakasho-Request-Signature: ")).Append(var13);
            var0._f.Add("X-Sakasho-Request-Signature", var13);
            string var7 = ExternLib.Java_Sakasho.jp.dena.sakasho.core.SakashoSystem.q();
            var0._f.Add("X-Sakasho-IDFA", var7);
            var7 = ExternLib.Java_Sakasho.jp.dena.sakasho.core.SakashoSystem.r();
            var0._f.Add("X-Sakasho-IDFV", var7);
            var7 = ExternLib.Java_Sakasho.jp.dena.sakasho.core.SakashoSystem.s();
            var0._f.Add("X-Sakasho-XIDFA", var7);
            StringBuilder var14 = new StringBuilder();
            var14.Append(_k);
            var14.Append(var6);
            var6 = var14.ToString();
            ca var9 = new ch(var1, var2, var13);
            if (var0._d)
            {
                var9 = new dc(var0._e, var4, (ca)var9);
            }

            ExternLib.Java_Sakasho.jp.dena.sakasho.core.SakashoSystem.i();
            (new StringBuilder("   url: ")).Append(var6);
            ExternLib.Java_Sakasho.jp.dena.sakasho.core.SakashoSystem.i();
            (new StringBuilder("method: ")).Append(jp.dena.sakasho.core.network.SakashoRequest.__a.a(var0._b));
            if (var6[4] != 's')
            {
                ExternLib.Java_Sakasho.jp.dena.sakasho.core.SakashoSystem.i();
            }
            else
            {
                switch (var0._b)
                {
                    case 0:
                        _h.a(var6, var0._f, (ca)var9);
                        return;
                    case 1:
                        _h.a(var6, var0._f, var0._c, (ca)var9);
                        return;
                    case 2:
                        _h.b(var6, var0._f, var0._c, (ca)var9);
                        return;
                    case 3:
                        _h.b(var6, var0._f, (ca)var9);
                        return;
                    case 4:
                        var0._f.Add("X-HTTP-Method-Override", jp.dena.sakasho.core.network.SakashoRequest.__a.a(4));
                        _h.a(var6, var0._f, var0._c, (ca)var9);
                        return;
                    default:
                        StringBuilder var10 = new StringBuilder("Unsupported http method: ");
                        var10.Append(var0._b);
                        throw new System.Exception(var10.ToString());
                }
            }
        }

        private string a(string var1, string var2, byte[] var3)
        {
            return eu.a(this.generateRequestSignature(var1, var2, var3));
        }

        private /*native */byte[] generateRequestSignature(string var1, string var2, byte[] var3)
        {
            UnityEngine.Debug.Log("TODO Generate signature "+var1+" "+var2+" "+System.BitConverter.ToString(var3));
            return null;
        }
    }
}