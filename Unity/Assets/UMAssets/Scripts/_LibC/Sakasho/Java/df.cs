using System.Collections.Generic;

namespace ExternLib.Java_Sakasho
{
    public class df
    {
        public static df _a;
        private Dictionary<string, Dictionary<string, de> > _b = new Dictionary<string, Dictionary<string, de> >();

        public de a(string var1, string var2)
        {
            //synchronized(this){}
            if (var2 == null)
            {
                return null;
            }
            else
            {
                bool var3 = this._b.ContainsKey(var1);

                if (!var3)
                {
                    return null;
                }

                de var4;
                Dictionary<string, de> var5 = this.b(var1);
                var4 = (de)var5[var2];

                de var26 = var4;
                if (var4 != null)
                {
                    var26 = var4;

                    if (var4._a <= (System.DateTime.Now - new System.DateTime(1970, 1, 1, 0, 0, 0, 1, 0)).TotalMilliseconds) 
                    {
                        var5.Remove(var2);

                        var26 = null;
                    }
                }

                if (var26 != null)
                {
                    byte[] var29 = var26._d;
                    byte[] var27 = new byte[var29.Length];
                    System.Buffer.BlockCopy(var29, 0, var27, 0, var29.Length);
                    var26 = new de(var26._b, var26._c, var27, var26._a);
                }
                else
                {
                    var26 = null;
                }

                return var26;
            }
        }
        private Dictionary<string, de> b(string var1)
        {
            Dictionary<string, de> var3 = this._b[var1];
            if (var3 == null)
            {
                var3 = new dd(100);
                this._b.Add(var1, var3);
            }

            return var3;
        }
    }
}