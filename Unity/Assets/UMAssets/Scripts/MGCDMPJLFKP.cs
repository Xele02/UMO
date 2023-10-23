
using System.Collections.Generic;
using System.IO;

public class MGCDMPJLFKP
{
	public class MIIIIBANPPB
	{
		public int FDEBLMKEMLF; // 0x8
		public int CLDKMLONBHJ; // 0xC
		public int JDDIOOJHIHP; // 0x10
		public int INHOGJODJFJ; // 0x14
		public bool CADENLBDAEB; // 0x18
		public long NPDKEIIMCDI; // 0x20
	}

	public const int JNCCCCPBDIC_Version = 3;
	public List<MIIIIBANPPB> DHDCHLAIAMP = new List<MIIIIBANPPB>(); // 0x8
	private string ELLBAAFKDCH_FilePath; // 0xC

	// RVA: 0x1316434 Offset: 0x1316434 VA: 0x1316434
	public MGCDMPJLFKP()
	{
		ELLBAAFKDCH_FilePath = CJMOKHDNBNB.FIPFFELDIOG_PersistentPath + "/sys/gc2";
	}

	//// RVA: 0x1316510 Offset: 0x1316510 VA: 0x1316510
	//public void KHEKNNFCAOI(string CJEKGLGBIHF) { }

	//// RVA: 0x1316518 Offset: 0x1316518 VA: 0x1316518
	public void PCODDPDFLHK()
	{
		DHDCHLAIAMP.Clear();
		if(File.Exists(ELLBAAFKDCH_FilePath))
		{
			TodoLogger.LogError(0, "PCODDPDFLHK");
		}
	}

	//// RVA: 0x1316F0C Offset: 0x1316F0C VA: 0x1316F0C
	public void HJMKBCFJOOH_Save()
	{
		string dir = Path.GetDirectoryName(ELLBAAFKDCH_FilePath);
		if (!Directory.Exists(dir))
			Directory.CreateDirectory(dir);
		using (FileStream f = new FileStream(ELLBAAFKDCH_FilePath, FileMode.Create))
		{
			using (BinaryWriter b = new BinaryWriter(f))
			{
				b.Write(JNCCCCPBDIC_Version);
				b.Write(1);
				b.Write(DHDCHLAIAMP[0].NPDKEIIMCDI);
				b.Flush();
				b.Close();
			}
		}
	}

	//// RVA: 0x13174A4 Offset: 0x13174A4 VA: 0x13174A4
	//public void JCHLONCMPAJ(bool OGBEGDKPDGK) { }
}
