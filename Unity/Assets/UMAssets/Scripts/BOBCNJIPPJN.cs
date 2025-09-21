using System;
using System.IO.Compression;
using System.IO;

public class BOBCNJIPPJN
{
	// RVA: 0x19CC098 Offset: 0x19CC098 VA: 0x19CC098
	public static bool AGJJGJCIMKI(byte[] _DBBGALAPFGC_Data)
    {
        if(_DBBGALAPFGC_Data.Length < 16)
            return false;
        return _DBBGALAPFGC_Data[0] == 0x1f && _DBBGALAPFGC_Data[1] == 0x8B && _DBBGALAPFGC_Data[2] == 0x8;
    }

	// // RVA: 0x19CC130 Offset: 0x19CC130 VA: 0x19CC130
	public static int JAIEEHOPAFD(byte[] _DBBGALAPFGC_Data)
	{
		if(AGJJGJCIMKI(_DBBGALAPFGC_Data))
		{
			return BitConverter.ToInt32(_DBBGALAPFGC_Data, _DBBGALAPFGC_Data.Length - 4);
		}
		return _DBBGALAPFGC_Data.Length;
	}

	// // RVA: 0x19CC1E4 Offset: 0x19CC1E4 VA: 0x19CC1E4
	public static byte[] JCBCBNFPJDH(byte[] _DBBGALAPFGC_Data)
	{
		if(AGJJGJCIMKI(_DBBGALAPFGC_Data))
		{
			byte[] res = new byte[JAIEEHOPAFD(_DBBGALAPFGC_Data)];
			if(HCPBJNNFONO(_DBBGALAPFGC_Data, res) != 0)
			{
				return _DBBGALAPFGC_Data;
			}
			return res;
		}
		return _DBBGALAPFGC_Data;
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
	private static int HCPBJNNFONO(byte[] _DBBGALAPFGC_Data, byte[] _IAKPCFDLMKP_db)
	{
		return KEHJJDKPDLL(_DBBGALAPFGC_Data, _DBBGALAPFGC_Data.Length, _IAKPCFDLMKP_db, _IAKPCFDLMKP_db.Length);
	}
}
