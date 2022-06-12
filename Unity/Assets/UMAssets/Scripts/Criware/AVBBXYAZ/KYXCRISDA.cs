using System.Text;

namespace AVBBXYAZ
{
    public class KYXCRISDA
    {
        // RVA: 0x2879660 Offset: 0x2879660 VA: 0x2879660
        public static void POISZES(out string K, out string P)
        {
            byte[] buffer = new byte[RYUSYZAX.YXAXYVZX.Length/2];
            int var7 = 0x57;
            for(int i = 0; i < buffer.Length; i++)
            {
                byte var1 = RYUSYZAX.YXAXYVZX[i*2];
                buffer[i] = (byte)(var7 ^ var1);
                var7 = (byte)((((var7 * 0x17) % 0x100) * 0x17) % 0x100);
            }
            string str = Encoding.UTF8.GetString(buffer);
            K = str.Substring(0, 18);
            P = str.Substring(18, 13);
        }
    }
}