using System.Security.Cryptography;

namespace XeSys
{
	public class CipherRijndael
	{
		private Rijndael rijndale { get; set; } // 0x8

		// // RVA: 0x193005C Offset: 0x193005C VA: 0x193005C
		public CipherRijndael(string password, string salt)
		{
			UnityEngine.Debug.LogWarning("TODO CipherRijndael()");
		}

		// // RVA: 0x1930390 Offset: 0x1930390 VA: 0x1930390
		// public string EncryptToBase64(string plainText) { }

		// // RVA: 0x19305C4 Offset: 0x19305C4 VA: 0x19305C4
		// public string EncryptToURLBase64(string plainText) { }

		// // RVA: 0x19308BC Offset: 0x19308BC VA: 0x19308BC
		public string DecryptFromBase64(string cipherText)
		{
			UnityEngine.Debug.LogError("TODO");
			return "";
		}

		// // RVA: 0x1930A60 Offset: 0x1930A60 VA: 0x1930A60
		// public string DecryptFromURLBase64(string cipherText) { }

		// // RVA: 0x19301C0 Offset: 0x19301C0 VA: 0x19301C0
		// private static void GenerateKeyFromPassword(string password, string salt, int keySize, out byte[] key, int blockSize, out byte[] iv) { }


	}
}
