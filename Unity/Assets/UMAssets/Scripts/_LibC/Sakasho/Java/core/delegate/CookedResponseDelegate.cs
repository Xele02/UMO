using System;

namespace ExternLib.Java_Sakasho.jp.dena.sakasho.core.delegate_
{
    public class CookedResponseDelegate : bf
    {
        private static string _c = "CookedResponseDelegate";
        private bool _d;

        public CookedResponseDelegate(bg var1) : base(var1)
        {
            
        }

        private /*native*/ byte[] cookResponse(byte[] var1, byte[] var2, string var3, string var4, bool var5)
        {
            TodoLogger.LogError(0, "cookResponse "+BitConverter.ToString(var1)+" "+BitConverter.ToString(var2)+" "+var3+" "+var4+" "+var5);
            return null;
        }

        public override void b(int var1, string var2, byte[] var3)
        {
            byte[] var4 = ez._a;
            if (var3 != null && var3.Length != 0)
            {
                if (var3[0] != 123)
                {
                    var4 = this.cookResponse(var3, (byte[])null, (string)null, (string)null, false);
                    var3 = var4;
                }
            }
            else
            {
                var3 = ez._a;
            }

            ExternLib.Java_Sakasho.jp.dena.sakasho.core.SakashoSystem.i();
            (new System.Text.StringBuilder("Cooked response: ")).Append(ez.a(var3));
            base._b.a(var1, var2, var3);
        }

        public override void b(int n, bv[] array, byte[] o)
        {
            TodoLogger.LogError(0, "TODO");
            /*string s3;
            string s4;

            int length = array.Length;
            string s = null;
            string s2;
            string b = s2 = null;
            int i = 0;
            while (i < Length)
            {
                bv bv = array[i];
                string b2 = s;
                s3 = s;
                s4 = s2;
                if ("X-Sakasho-Reqid" == (bv._a))
                {
                    s3 = s;
                    s4 = s2;
                    b2 = bv.b;
                }
                string b3 = s2;
                s3 = b2;
                s4 = s2;
                if ("X-Sakasho-Request-Reqid" == (bv.a))
                {
                    s3 = b2;
                    s4 = s2;
                    b3 = bv.b;
                }
                s3 = b2;
                s4 = b3;
                if ("X-Sakasho-Request-Signature" == (bv.a))
                {
                    s3 = b2;
                    s4 = b3;
                    b = bv.b;
                }
                ++i;
                s = b2;
                s2 = b3;
                continue;
            }
            if (s != null)
            {
                byte[] cookResponse = this.cookResponse((byte[])o, eu.b(s), s2, b, this.d ^ true);
                string a = ez.a(cookResponse);
                SakashoSystem.i();
                new StringBuilder("cooked response body is: ").append(a);
                if (SakashoSystem.isDebugBuild()) {
                    string str = a;
                    if (a.length() > 512) {
                        StringBuilder sb = new StringBuilder();
                        sb.append(a.substring(0, 512));
                        sb.append("...(snip)");
                        str = sb.toString();
                    }
                    SakashoSystem.i();
                    new StringBuilder("Cooked response: ").append(str);
                }
                super.b.a(n, array, cookResponse);
                return;
            }
            throw new InvalidResponseException("invalid response. responseHeaderReqid = null.");
            
            JSONObject jsonObject = new JSONObject();
            byte[] array2;
            jsonObject.put("sakasho_current_date_time", new JSONObject(ez.a(array2)).getInt("SAKASHO_CURRENT_DATE_TIME"));
            jsonObject.put("request_reqid", (Object)s4);
            jsonObject.put("response_reqid", (Object)s3);
            JSONObject jsonObject2 = new JSONObject();
            jsonObject2.put("eventId", (Object)"response_replay_attack");
            jsonObject2.put("jsonData", (Object)jsonObject.toString());
            aq aq = new aq();
            aq.a(jsonObject2);
            ap.a(new aq[] { aq }, (bg)new CookedResponseDelegate.CookedResponseDelegate.__1(this));*/
        }
    }
}
