using System.Security.Cryptography;
using System.Text;
using System.IO;
using System;
using System.Collections.Generic;
using XeSys;

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
	public void KHEKNNFCAOI_Init(string CJEKGLGBIHF)
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
                int a = BitConverter.ToInt32(b, 0); // Read header
                if(a != 0x3ac13967)
                    return false;
                BitConverter.ToInt32(b, 4);
                int a2 = BitConverter.ToInt32(b, 8); // Read count
                JCNNBEEHFLE = BitConverter.ToInt64(b, 16); // Read long
                int readPos = 32;
                for(int i = a2; i > 0; i--)
                {
                    int b1 = BitConverter.ToInt32(b, readPos); // read offset
                    int b2 = BitConverter.ToInt32(b, readPos + 4); // read length
                    int b3 = BitConverter.ToInt32(b, readPos + 8); // read value
                    GBAMMLEAIOF g = new GBAMMLEAIOF();
                    g.KHEKNNFCAOI_Init(b3, b, b1, b2);
                    MGJKEJHEBPO.Add(g);
                    readPos += 16;
                }
            }

            return true;
        }
        return false;
    }

	// // RVA: 0x1CB09D4 Offset: 0x1CB09D4 VA: 0x1CB09D4
	public void HJMKBCFJOOH()
	{
		LNHFLJBGGJB = true;
		int iVar12 = 0x20;
		for(int i = 0; i < MGJKEJHEBPO.Count; i++)
		{
			iVar12 = iVar12 + 16 + ((MGJKEJHEBPO[i].EJJEHEHFMGO.Length + 3) / 4) * 4;
		}
		
		CFFBJGGICCE = new byte[iVar12];
		MemoryStream memStream = new MemoryStream(CFFBJGGICCE);
		BinaryWriter binWriter = new BinaryWriter(memStream);
		
		binWriter.Write(0x3ac13967); // Write header
		binWriter.Write(1);
		binWriter.Write(MGJKEJHEBPO.Count); // Write data num
		binWriter.Write(0);
		binWriter.Write(JCNNBEEHFLE); // write long?
		binWriter.Write((long)0);
		iVar12 = MGJKEJHEBPO.Count * 16 + 32;
		for(int i = 0; i < MGJKEJHEBPO.Count; i++)
		{
			binWriter.Write(iVar12); // write offset
			binWriter.Write(MGJKEJHEBPO[i].EJJEHEHFMGO.Length); // write length
			binWriter.Write(MGJKEJHEBPO[i].PGEDKFOIPIP); // write value
			binWriter.Write(0);
			iVar12 += ((MGJKEJHEBPO[i].EJJEHEHFMGO.Length + 3) / 4) * 4;
		}
		
		for(int i = 0; i < MGJKEJHEBPO.Count; i++)
		{
			binWriter.Write(MGJKEJHEBPO[i].EJJEHEHFMGO); // write data
			iVar12 = ((MGJKEJHEBPO[i].EJJEHEHFMGO.Length + 3) / 4) * 4 - MGJKEJHEBPO[i].EJJEHEHFMGO.Length;
			for(int j = 0; j < iVar12; j++)
			{
				binWriter.Write((byte)0); // write zero fill
			}
		}
		binWriter.Close();
		
		NKGJPJPHLIF.HHCJCDFCLOB.IBLPICFDGOF.BNJPAKLNOPA_WorkerThreadQueue.Add(() => {
			//0x1CB13C4
			ICryptoTransform crypt = KHFCJBEFJNC.CreateEncryptor();
			byte[] res = crypt.TransformFinalBlock(CFFBJGGICCE, 0, CFFBJGGICCE.Length);
			for(int i = 0; i < CFFBJGGICCE.Length; i++)
			{
				CFFBJGGICCE[i] = 0;
			}
			Utility.SaveToStorage(ELLBAAFKDCH[0], res, true);
			Utility.SaveToStorage(ELLBAAFKDCH[1], res, true);
			LNHFLJBGGJB = false;
		});
		
		binWriter.Dispose();
		memStream.Dispose();
	}

	// // RVA: 0x1CB0390 Offset: 0x1CB0390 VA: 0x1CB0390
	private static void GLHEDLJKJOO(string GMEFFNIMFIF, string CDPAMAOOHNF, int NKPAPLIBIJJ, out byte[] LJNAKDMILMC, int BBALOLKMAOL, out byte[] BKJMLLELIJB)
    {
        if(CDPAMAOOHNF.Length < 8)
        {
            throw new System.Exception("CipherRijndale.GenerateKeyFromPassword : salt is less than 8byte.");
        }

        Rfc2898DeriveBytes a = new Rfc2898DeriveBytes(GMEFFNIMFIF, Encoding.UTF8.GetBytes(CDPAMAOOHNF));
        a.IterationCount = 47;
        LJNAKDMILMC = a.GetBytes(NKPAPLIBIJJ / 8);
        BKJMLLELIJB = a.GetBytes(BBALOLKMAOL / 8);
    }
}
