using System.Security.Cryptography;
using System.Text;
using System;

namespace XeSys
{
	public class CipherRijndael
	{
		private Rijndael rijndale { get; set; } // 0x8

		// // RVA: 0x193005C Offset: 0x193005C VA: 0x193005C
		public CipherRijndael(string password, string salt)
		{
			rijndale = new RijndaelManaged();
			byte[] key;
			byte[] iv;
			GenerateKeyFromPassword(password, salt, rijndale.KeySize, out key, rijndale.BlockSize, out iv);
			rijndale.Key = key;
			rijndale.IV = iv;
		}

		// // RVA: 0x1930390 Offset: 0x1930390 VA: 0x1930390
		public string EncryptToBase64(string plainText)
		{
			byte[] data = Encoding.UTF8.GetBytes(plainText);
			return Convert.ToBase64String(rijndale.CreateEncryptor().TransformFinalBlock(data, 0, data.Length));
		}

		// // RVA: 0x19305C4 Offset: 0x19305C4 VA: 0x19305C4
		// public string EncryptToURLBase64(string plainText) { }

		// // RVA: 0x19308BC Offset: 0x19308BC VA: 0x19308BC
		public string DecryptFromBase64(string cipherText)
		{
			byte[] data = Convert.FromBase64String(cipherText);
			return Encoding.UTF8.GetString(rijndale.CreateDecryptor().TransformFinalBlock(data, 0, data.Length));
		}

		// // RVA: 0x1930A60 Offset: 0x1930A60 VA: 0x1930A60
		// public string DecryptFromURLBase64(string cipherText) { }

		// // RVA: 0x19301C0 Offset: 0x19301C0 VA: 0x19301C0
		private static void GenerateKeyFromPassword(string password, string salt, int keySize, out byte[] key, int blockSize, out byte[] iv)
		{
			int len = salt.Length;
			if(len < 8)
			{
				throw new Exception("CipherRijndale.GenerateKeyFromPassword : salt is less than 8byte.");
			}
			Rfc2898DeriveBytes b = new Rfc2898DeriveBytes(password, Encoding.UTF8.GetBytes(salt));
			b.IterationCount = 1000;
			key = b.GetBytes(keySize / 8);
			iv = b.GetBytes(blockSize / 8);
		}


	}
}
