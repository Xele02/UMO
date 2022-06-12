using System.Collections.Generic;
using System.Text;
using System;

public class FFGBKEEIBNL
{
	// RVA: 0x14DC6CC Offset: 0x14DC6CC VA: 0x14DC6CC
	public static string HKICMNAACDA(byte[] IDDIIHBJPEE)
    {
        List<byte> l = new List<byte>(40);
        byte var8;
        if(IDDIIHBJPEE.Length <= 1)
        {
            var8 = 0;
        }
        else
        {
            var8 = 0;
            for(int i = 0; i < IDDIIHBJPEE.Length - 1; i++)
            {
                var8 = (byte)(var8 + IDDIIHBJPEE[i]);
            }
        }
        if(IDDIIHBJPEE[IDDIIHBJPEE.Length - 1] != var8)
        {
            //UnityEngine.Debug.LogError("HKICMNAACDA failed"+BitConverter.ToString(IDDIIHBJPEE));
            return null;
        }

        if((IDDIIHBJPEE.Length - 1) > 0)
        {
            byte var10 = 212;
            int var9 = 0;
            for(int i = 0; i < IDDIIHBJPEE.Length - 1; i++)
            {
                l.Add((byte)(IDDIIHBJPEE[i] ^ var10));
                var10 = (byte)(var10 + 7);
                if((var9 & 3) == 0)
                    i++;
                var9++;
            }
        }
        //UnityEngine.Debug.LogError("HKICMNAACDA return "+Encoding.UTF8.GetString(l.ToArray()));
        return Encoding.UTF8.GetString(l.ToArray());
    }
}
