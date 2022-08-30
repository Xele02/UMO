using System;
using System.Collections.Generic;
using System.Text;

public class CEDHHAGBIBA
{
	public static uint LBLGDJJGFIO; // 0x0
	private const int PMLANIPJEFO = 3;

	// // RVA: 0x12B1884 Offset: 0x12B1884 VA: 0x12B1884
	public static string KJFAGPBALNO(string BJKEOACPMHB)
	{
		StringBuilder str = new StringBuilder();
		char[] chars = BJKEOACPMHB.ToCharArray();
		for(int i = 0; i < chars.Length; i++)
		{
			if(chars[i] == '\\')
			{
				if (chars.Length < (i + 6))
					str.Append(chars[i]);
				else if(chars[i + 1] != 'u')
					str.Append(chars[i]);
				else
				{
					char[] c = new char[4];
					for(int j = 0; j < 4; j++)
					{
						c[j] = chars[i + j + 2];
					}
					str.Append(Convert.ToInt32(c.ToString(), 16));
					i += 4;
				}
			}
			else
			{
				str.Append(chars[i]);
			}
		}
		return str.ToString();
	}

	// // RVA: 0x12B1B20 Offset: 0x12B1B20 VA: 0x12B1B20
	// public static string AMNBKLLDGKJ(byte[] IDDIIHBJPEE) { }

	// // RVA: 0x12B1D48 Offset: 0x12B1D48 VA: 0x12B1D48
	// public static int GNJBKANDLEE(EDOHBJAPLPF_JsonData IDLHJIOMJBK, string PGHEHAFKPMC) { }

	// // RVA: 0x12B1F2C Offset: 0x12B1F2C VA: 0x12B1F2C
	// public static long NIKODNFGCEM(EDOHBJAPLPF_JsonData IDLHJIOMJBK, string PGHEHAFKPMC) { }

	// // RVA: 0x12B2120 Offset: 0x12B2120 VA: 0x12B2120
	// public static string BNCLNFJHEND(EDOHBJAPLPF_JsonData IDLHJIOMJBK, string PGHEHAFKPMC) { }

	// // RVA: 0x12B226C Offset: 0x12B226C VA: 0x12B226C
	public static byte[] IHDGCICCPIG(string LJNAKDMILMC)
    {
        int len = LJNAKDMILMC.Length;
        List<byte> bytes = new List<byte>(0x20);
        byte[] strBytes = System.Text.Encoding.UTF8.GetBytes(LJNAKDMILMC);
        int idx = 0;
        uint var8 = 0xd4;
        uint var9 = (uint)(len + 100);
        while(true)
        {
            if(strBytes.Length <= idx)
            {
                int idx2 = 0;
                byte item = 0;
                while(true)
                {
                    int count = bytes.Count;
                    if(count <= idx2)
                        break;
                    byte B = bytes[idx2];
                    item += B;
                    idx2++;
                }
                bytes.Add(item);
                return bytes.ToArray();
            }
            if(bytes == null) break;
            bytes.Add((byte)((byte)var8 ^ (byte)(strBytes[idx])));
            var8 = var8 + 7 & 0xff;
            if((idx & 3) == 0)
            {
                bytes.Add((byte)var9);
                var9 = (var8 ^ var9) + 0xd;
            }
            idx++;
        }
        return null;
    }

	// // RVA: 0x12B2508 Offset: 0x12B2508 VA: 0x12B2508
	// public static string EHNMFLADJKG(byte[] IFIKNDBPOKO) { }

	// // RVA: 0x12B258C Offset: 0x12B258C VA: 0x12B258C
	public static void IFOLECIIDPO_StringToByteArray(byte[] IFIKNDBPOKO, string BJKEOACPMHB)
	{
		if(string.IsNullOrEmpty(BJKEOACPMHB))
		{
			for(int i = 0; i < IFIKNDBPOKO.Length; i++)
			{
				IFIKNDBPOKO[i] = 0;
			}
		}
		byte[] data = Convert.FromBase64String(BJKEOACPMHB);
		for(int i = 0; i < IFIKNDBPOKO.Length; i++)
		{
			if(i < data.Length)
			{
				IFIKNDBPOKO[i] = data[i];
			}
			else
			{
				IFIKNDBPOKO[i] = 0;
			}
		}
	}

	// // RVA: 0x12B28A0 Offset: 0x12B28A0 VA: 0x12B28A0
	// public static uint CAOGDCBPBAN(byte[] IFIKNDBPOKO) { }

	// // RVA: 0x12B2994 Offset: 0x12B2994 VA: 0x12B2994
	// public static int OGPFNHOKONH(byte[] IFIKNDBPOKO) { }

}
