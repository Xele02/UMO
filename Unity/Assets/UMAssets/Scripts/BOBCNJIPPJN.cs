using System;
using System.IO.Compression;
using System.IO;

public class BOBCNJIPPJN
{
	// RVA: 0x19CC098 Offset: 0x19CC098 VA: 0x19CC098
	public static bool AGJJGJCIMKI(byte[] DBBGALAPFGC)
    {
        if(DBBGALAPFGC.Length < 16)
            return false;
        return DBBGALAPFGC[0] == 0x1f && DBBGALAPFGC[1] == 0x8B && DBBGALAPFGC[2] == 0x8;
    }

	// // RVA: 0x19CC130 Offset: 0x19CC130 VA: 0x19CC130
	public static int JAIEEHOPAFD(byte[] DBBGALAPFGC)
	{
		if(AGJJGJCIMKI(DBBGALAPFGC))
		{
			return BitConverter.ToInt32(DBBGALAPFGC, DBBGALAPFGC.Length - 4);
		}
		return DBBGALAPFGC.Length;
	}

	// // RVA: 0x19CC1E4 Offset: 0x19CC1E4 VA: 0x19CC1E4
	public static byte[] JCBCBNFPJDH(byte[] DBBGALAPFGC)
	{
		if(AGJJGJCIMKI(DBBGALAPFGC))
		{
			byte[] res = new byte[JAIEEHOPAFD(DBBGALAPFGC)];
			if(HCPBJNNFONO(DBBGALAPFGC, res) != 0)
			{
				return DBBGALAPFGC;
			}
			return res;
		}
		return DBBGALAPFGC;
	}

	// // RVA: 0x19CC338 Offset: 0x19CC338 VA: 0x19CC338
	private static /*extern*/ int KEHJJDKPDLL(byte[]/*IntPtr*/ DBKCFHELMEP, int HDJAJHOCHBP, byte[]/*IntPtr*/ BNJOAGGFLMJ, int DFCCLFJFGED)
	{
		// call xedec_uz
		using (MemoryStream inStream = new MemoryStream(DBKCFHELMEP))
		{
			using(MemoryStream outStream = new MemoryStream())
			{
				//using(DeflateStream dstream = new DeflateStream(inStream, CompressionMode.Decompress))
				using(GZipStream dstream = new GZipStream(inStream, CompressionMode.Decompress))
				{
					dstream.CopyTo(outStream);
				}
				Buffer.BlockCopy(outStream.ToArray(), 0, BNJOAGGFLMJ, 0, outStream.ToArray().Length);
			}
		}
		return 0;
	}

	// // RVA: 0x19CC280 Offset: 0x19CC280 VA: 0x19CC280
	private static int HCPBJNNFONO(byte[] DBBGALAPFGC, byte[] IAKPCFDLMKP)
	{
		return KEHJJDKPDLL(DBBGALAPFGC, DBBGALAPFGC.Length, IAKPCFDLMKP, IAKPCFDLMKP.Length);
	}
}
