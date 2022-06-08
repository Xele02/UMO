using Cryptor;
using UnityEngine;
using System;
using System.Collections.Generic;
using System.Globalization;

public class MNNCBFONAOL
{
	// Methods

	// // RVA: 0x17B1624 Offset: 0x17B1624 VA: 0x17B1624
	public static void KHEKNNFCAOI()
    {
        byte[] HKICMNAACDA = new byte[16];
        byte[] BNKHBCBJBKI = new byte[16];
        JEJMLJPJFBH(HKICMNAACDA, BNKHBCBJBKI);
        byte[] seed3 = NLPIDMIPIIE();

        // Debug check from memory dumped data
        byte[] check_seed1 = new byte[16] {0xaf, 0x1b, 0x45, 0x2b, 0xcf, 0x14, 0x8c, 0xe5, 0x7a, 0xdc, 0x14, 0x59, 0x23, 0x24, 0x40, 0x1d};
        byte[] check_seed2 = new byte[16] {0x4c, 0xfa, 0x63, 0x40, 0xb5, 0xe1, 0x35, 0xbc, 0x31, 0x6a, 0xd0, 0x7f, 0x3f, 0x76, 0x1b, 0x77};
        byte[] check_seed3 = new byte[16] {0xC9, 0xB8, 0x54, 0xFD, 0x74, 0xF7, 0xAC, 0xD4, 0x24, 0x55, 0x6E, 0x5D, 0x23, 0x71, 0x12, 0x6C};
        for(int i = 0; i < 16; i++)
        {
            Debug.Assert(check_seed1[i] == HKICMNAACDA[i]);
            Debug.Assert(check_seed2[i] == BNKHBCBJBKI[i]);
            Debug.Assert(check_seed3[i] == seed3[i]);
        }
        // end


        if(!DsfdLoader.Initialize(HKICMNAACDA, BNKHBCBJBKI, seed3, true))
        {
            Debug.LogError("DsfdLoader.Initialize FAILED!!!!!!!!!!!");
        }
    }

	// // RVA: 0x17B1978 Offset: 0x17B1978 VA: 0x17B1978
	// public static void PDENBOEFJGE() { }

	// // RVA: 0x17B17D0 Offset: 0x17B17D0 VA: 0x17B17D0
	private static byte[] NLPIDMIPIIE()
    {
        string seed = AFEHLCGHAEE.FEIAGLJKPAI;
        char[] separator = new char[1] {'-'};
        string[] parts = seed.Split(separator);
        byte[] result = new byte[16];
        for(int i = 0; i < 16; i++)
        {
            result[i] = (byte)Int32.Parse(parts[i], NumberStyles.HexNumber);
        }
        return result;
    }

	// // RVA: 0x17B174C Offset: 0x17B174C VA: 0x17B174C
	private static void JEJMLJPJFBH(byte[] HKICMNAACDA, byte[] BNKHBCBJBKI)
    {
        GCGCDFGCNEL_xedec_k(HKICMNAACDA, BNKHBCBJBKI);
    }

	// // RVA: 0x17B19F8 Offset: 0x17B19F8 VA: 0x17B19F8
	private static /*extern */void GCGCDFGCNEL_xedec_k(/*IntPtr*/byte[] HKICMNAACDA, /*IntPtr*/byte[] BNKHBCBJBKI)
    {
        byte[] key1 = new byte[16] { 0x50, 0xe4, 0xba, 0xd4, 0x30, 0xeb, 0x73, 0x1a, 0x85, 0x23, 0xeb, 0xa6, 0xdc, 0xdb, 0xbf, 0xe2 };
        byte[] key2 = new byte[16] { 0xb3, 0x05, 0x9c, 0xbf, 0x4a, 0x1e, 0xca, 0x43, 0xce, 0x95, 0x2f, 0x80, 0xc0, 0x89, 0xe4, 0x88 };
        for(int i = 0; i < 16; i++)
        {
            HKICMNAACDA[i] = (byte)~key1[i];
            BNKHBCBJBKI[i] = (byte)~key2[i];
        }
        
    }
}
