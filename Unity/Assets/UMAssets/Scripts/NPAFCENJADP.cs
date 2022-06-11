using System.Security.Cryptography;
using System.Text;
using System.IO;
using System;
using System.Collections.Generic;

public class NPAFCENJADP
{
	private const int MPLGOGILHHF = 985741671;
	private const int DDLGLKHDGCP = 1;
	private const int DHANLEBNENL = 50;
	private const int JENGAHLEBJD = 32;
	private const int MNEEKKKIDED = 16;
	public List<GBAMMLEAIOF> MGJKEJHEBPO = new List<GBAMMLEAIOF>(); // 0x8
	private Rijndael KHFCJBEFJNC; // 0xC
	private string[] ELLBAAFKDCH = new string[2]; // 0x10
	private byte[] CFFBJGGICCE; // 0x14
	public bool LNHFLJBGGJB; // 0x18
	public long JCNNBEEHFLE; // 0x20

	// // RVA: 0x1CAFFC0 Offset: 0x1CAFFC0 VA: 0x1CAFFC0
	public void KHEKNNFCAOI(string CJEKGLGBIHF)
    {
        KHFCJBEFJNC = new RijndaelManaged();
        byte[] out1 = null;
        byte[] out2 = null;
        GLHEDLJKJOO(AFEHLCGHAEE.DIGMEFPEBBC, AFEHLCGHAEE.ELLLLCLGECP, KHFCJBEFJNC.KeySize, out out1, KHFCJBEFJNC.BlockSize, out out2);
        KHFCJBEFJNC.Key = out1;
        KHFCJBEFJNC.IV = out2;

        ELLBAAFKDCH[0] = CJEKGLGBIHF+"_0";
        ELLBAAFKDCH[1] = CJEKGLGBIHF+"_1";

        JCNNBEEHFLE = 0;
        for(int i = 0; i < 2; i++)
        {
            if(PCODDPDFLHK(i))
                break;
        }
    }

	// // RVA: 0x1CB0944 Offset: 0x1CB0944 VA: 0x1CB0944
	// public void KLLOMGPHGLL(int HMFFHLPNMPH) { }

	// // RVA: 0x1CB0560 Offset: 0x1CB0560 VA: 0x1CB0560
	public bool PCODDPDFLHK(int IMJIADPJJMM)
    {
        MGJKEJHEBPO.Clear();
        if(File.Exists(ELLBAAFKDCH[IMJIADPJJMM]))
        {
            byte[] b = File.ReadAllBytes(ELLBAAFKDCH[IMJIADPJJMM]);
            ICryptoTransform iCryptT = KHFCJBEFJNC.CreateDecryptor();
            b = iCryptT.TransformFinalBlock(b, 0, b.Length);

            if(b != null && b.Length > 0xf)
            {
                int a = BitConverter.ToInt32(b, 0);
                if(a != 0x3ac13967)
                    return false;
                BitConverter.ToInt32(b, 4);
                int a2 = BitConverter.ToInt32(b, 8);
                JCNNBEEHFLE = BitConverter.ToInt64(b, 16);
                int readPos = 32;
                for(int i = a2; i > 0; i--)
                {
                    int b1 = BitConverter.ToInt32(b, readPos);
                    int b2 = BitConverter.ToInt32(b, readPos + 4);
                    int b3 = BitConverter.ToInt32(b, readPos + 8);
                    GBAMMLEAIOF g = new GBAMMLEAIOF();
                    g.KHEKNNFCAOI(b3, b, b1, b2);
                    MGJKEJHEBPO.Add(g);
                    readPos += 16;
                }
            }

            return true;
        }
        return false;
    }

	// // RVA: 0x1CB09D4 Offset: 0x1CB09D4 VA: 0x1CB09D4
	// public void HJMKBCFJOOH() { }

	// // RVA: 0x1CB0390 Offset: 0x1CB0390 VA: 0x1CB0390
	private static void GLHEDLJKJOO(string GMEFFNIMFIF, string CDPAMAOOHNF, int NKPAPLIBIJJ, out byte[] LJNAKDMILMC, int BBALOLKMAOL, out byte[] BKJMLLELIJB)
    {
        if(CDPAMAOOHNF.Length < 8)
        {
            new System.Exception("CipherRijndale.GenerateKeyFromPassword : salt is less than 8byte.");
        }

        Rfc2898DeriveBytes a = new Rfc2898DeriveBytes(GMEFFNIMFIF, Encoding.UTF8.GetBytes(CDPAMAOOHNF));
        a.IterationCount = 47;
        LJNAKDMILMC = a.GetBytes(NKPAPLIBIJJ / 8);
        BKJMLLELIJB = a.GetBytes(BBALOLKMAOL / 8);
    }

	// [CompilerGeneratedAttribute] // RVA: 0x6B6968 Offset: 0x6B6968 VA: 0x6B6968
	// // RVA: 0x1CB13C4 Offset: 0x1CB13C4 VA: 0x1CB13C4
	// private void <Save>b__14_0() { }
}
