namespace ExternLib.Java_Sakasho.jp.dena.sakasho.core
{
    public class ez
    {
        public static byte[] _a = a("{}");

        public static byte[] a(string var0)
        {
            if (var0 == null)
            {
                return null;
            }
            else
            {
                byte[] var2 = System.Text.Encoding.UTF8.GetBytes(var0);
                return var2;
            }
        }

        public static string a(byte[] var0)
        {
            if (var0 == null)
            {
                return null;
            }
            else
            {
                string var2 = System.Text.Encoding.UTF8.GetString(var0);
                return var2;
            }
        }
    }
}
