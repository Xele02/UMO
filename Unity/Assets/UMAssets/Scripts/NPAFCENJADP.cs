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
	public List<GBAMMLEAIOF> MGJKEJHEBPO_Blocks = new List<GBAMMLEAIOF>(); // 0x8
	private Rijndael KHFCJBEFJNC; // 0xC
	private string[] ELLBAAFKDCH_Filename = new string[2]; // 0x10
	private byte[] CFFBJGGICCE; // 0x14
	public bool LNHFLJBGGJB_IsRunning; // 0x18
	public long JCNNBEEHFLE_RequestId; // 0x20

	// // RVA: 0x1CAFFC0 Offset: 0x1CAFFC0 VA: 0x1CAFFC0
	public void KHEKNNFCAOI_Init(string _CJEKGLGBIHF_path)
    {
        KHFCJBEFJNC = new RijndaelManaged();
        byte[] out1 = null;
        byte[] out2 = null;
        GLHEDLJKJOO(AFEHLCGHAEE_Strings.DIGMEFPEBBC_CipherPass, AFEHLCGHAEE_Strings.ELLLLCLGECP_CipherSalt, KHFCJBEFJNC.KeySize, out out1, KHFCJBEFJNC.BlockSize, out out2);
        KHFCJBEFJNC.Key = out1;
        KHFCJBEFJNC.IV = out2;

        ELLBAAFKDCH_Filename[0] = _CJEKGLGBIHF_path+"_0";
        ELLBAAFKDCH_Filename[1] = _CJEKGLGBIHF_path+"_1";

        JCNNBEEHFLE_RequestId = 0;
        for(int i = 0; i < 2; i++)
        {
            if(PCODDPDFLHK_Load(i))
                break;
        }
    }

	// // RVA: 0x1CB0944 Offset: 0x1CB0944 VA: 0x1CB0944
	public void KLLOMGPHGLL_RemoveEvents(int _HMFFHLPNMPH_count)
	{
		for(int i = _HMFFHLPNMPH_count; i > 0; i--)
		{
			MGJKEJHEBPO_Blocks.RemoveAt(0);
		}
	}

	// // RVA: 0x1CB0560 Offset: 0x1CB0560 VA: 0x1CB0560
	public bool PCODDPDFLHK_Load(int IMJIADPJJMM)
    {
        MGJKEJHEBPO_Blocks.Clear();
        if(File.Exists(ELLBAAFKDCH_Filename[IMJIADPJJMM]))
        {
            byte[] b = File.ReadAllBytes(ELLBAAFKDCH_Filename[IMJIADPJJMM]);
            ICryptoTransform iCryptT = KHFCJBEFJNC.CreateDecryptor();
            b = iCryptT.TransformFinalBlock(b, 0, b.Length);

            if(b != null && b.Length > 0xf)
            {
                int a = BitConverter.ToInt32(b, 0); // Read header
                if(a != 0x3ac13967)
                    return false;
                BitConverter.ToInt32(b, 4);
                int a2 = BitConverter.ToInt32(b, 8); // Read count
                JCNNBEEHFLE_RequestId = BitConverter.ToInt64(b, 16); // Read long
                int readPos = 32;
                for(int i = a2; i > 0; i--)
                {
                    int b1 = BitConverter.ToInt32(b, readPos); // read offset
                    int b2 = BitConverter.ToInt32(b, readPos + 4); // read length
                    int b3 = BitConverter.ToInt32(b, readPos + 8); // read value
                    GBAMMLEAIOF g = new GBAMMLEAIOF();
                    g.KHEKNNFCAOI_Init(b3, b, b1, b2);
                    MGJKEJHEBPO_Blocks.Add(g);
                    readPos += 16;
                }
            }

            return true;
        }
        return false;
    }

	// // RVA: 0x1CB09D4 Offset: 0x1CB09D4 VA: 0x1CB09D4
	public void HJMKBCFJOOH_Save()
	{
		LNHFLJBGGJB_IsRunning = true;
		int iVar12 = 0x20;
		for(int i = 0; i < MGJKEJHEBPO_Blocks.Count; i++)
		{
			iVar12 = iVar12 + 16 + ((MGJKEJHEBPO_Blocks[i].EJJEHEHFMGO.Length + 3) / 4) * 4;
		}
		
		CFFBJGGICCE = new byte[iVar12];
		MemoryStream memStream = new MemoryStream(CFFBJGGICCE);
		BinaryWriter binWriter = new BinaryWriter(memStream);
		
		binWriter.Write(0x3ac13967); // Write header
		binWriter.Write(1);
		binWriter.Write(MGJKEJHEBPO_Blocks.Count); // Write data num
		binWriter.Write(0);
		binWriter.Write(JCNNBEEHFLE_RequestId); // write long?
		binWriter.Write((long)0);
		iVar12 = MGJKEJHEBPO_Blocks.Count * 16 + 32;
		for(int i = 0; i < MGJKEJHEBPO_Blocks.Count; i++)
		{
			binWriter.Write(iVar12); // write offset
			binWriter.Write(MGJKEJHEBPO_Blocks[i].EJJEHEHFMGO.Length); // write length
			binWriter.Write(MGJKEJHEBPO_Blocks[i].PGEDKFOIPIP_EventIdx); // write value
			binWriter.Write(0);
			iVar12 += ((MGJKEJHEBPO_Blocks[i].EJJEHEHFMGO.Length + 3) / 4) * 4;
		}
		
		for(int i = 0; i < MGJKEJHEBPO_Blocks.Count; i++)
		{
			binWriter.Write(MGJKEJHEBPO_Blocks[i].EJJEHEHFMGO); // write data
			iVar12 = ((MGJKEJHEBPO_Blocks[i].EJJEHEHFMGO.Length + 3) / 4) * 4 - MGJKEJHEBPO_Blocks[i].EJJEHEHFMGO.Length;
			for(int j = 0; j < iVar12; j++)
			{
				binWriter.Write((byte)0); // write zero fill
			}
		}
		binWriter.Close();
		
		NKGJPJPHLIF.HHCJCDFCLOB.IBLPICFDGOF_ServerRequester.BNJPAKLNOPA_WorkerThreadQueue.Add(() => {
			//0x1CB13C4
			ICryptoTransform crypt = KHFCJBEFJNC.CreateEncryptor();
			byte[] res = crypt.TransformFinalBlock(CFFBJGGICCE, 0, CFFBJGGICCE.Length);
			for(int i = 0; i < CFFBJGGICCE.Length; i++)
			{
				CFFBJGGICCE[i] = 0;
			}
			Utility.SaveToStorage(ELLBAAFKDCH_Filename[0], res, true);
			Utility.SaveToStorage(ELLBAAFKDCH_Filename[1], res, true);
			LNHFLJBGGJB_IsRunning = false;
		});
		
		binWriter.Dispose();
		memStream.Dispose();
	}

	// // RVA: 0x1CB0390 Offset: 0x1CB0390 VA: 0x1CB0390
	private static void GLHEDLJKJOO(string GMEFFNIMFIF, string CDPAMAOOHNF, int NKPAPLIBIJJ, out byte[] _LJNAKDMILMC_key, int BBALOLKMAOL, out byte[] BKJMLLELIJB)
    {
        if(CDPAMAOOHNF.Length < 8)
        {
            throw new System.Exception("CipherRijndale.GenerateKeyFromPassword : salt is less than 8byte.");
        }

        Rfc2898DeriveBytes a = new Rfc2898DeriveBytes(GMEFFNIMFIF, Encoding.UTF8.GetBytes(CDPAMAOOHNF));
        a.IterationCount = 47;
        _LJNAKDMILMC_key = a.GetBytes(NKPAPLIBIJJ / 8);
        BKJMLLELIJB = a.GetBytes(BBALOLKMAOL / 8);
    }
}
