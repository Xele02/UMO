
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
			using(FileStream f = new FileStream(ELLBAAFKDCH_FilePath, FileMode.Open))
			{
				using(BinaryReader r = new BinaryReader(f))
				{
					int version = r.ReadInt32();
					if(version == 1)
					{
						int cnt = r.ReadInt32();
						for(int i = 0; i < cnt; i++)
						{
							MIIIIBANPPB m = new MIIIIBANPPB();
							m.FDEBLMKEMLF = r.ReadInt32();
							m.CLDKMLONBHJ = r.ReadInt32();
							m.JDDIOOJHIHP = r.ReadInt32();
							m.INHOGJODJFJ = 0;
							m.CADENLBDAEB = false;
							m.NPDKEIIMCDI = 0;
							DHDCHLAIAMP.Add(m);
						}
					}
					else if(version == 2)
					{
						int cnt = r.ReadInt32();
						for(int i = 0; i < cnt; i++)
						{
							MIIIIBANPPB m = new MIIIIBANPPB();
							m.FDEBLMKEMLF = r.ReadInt32();
							m.CLDKMLONBHJ = 0;
							m.INHOGJODJFJ = r.ReadInt32();
							m.CADENLBDAEB = r.ReadBoolean();
							m.JDDIOOJHIHP = r.ReadInt32();
							m.NPDKEIIMCDI = 0;
							DHDCHLAIAMP.Add(m);
						}
					}
					else if(version == 3)
					{
						int cnt = r.ReadInt32();
						for(int i = 0; i < cnt; i++)
						{
							MIIIIBANPPB m = new MIIIIBANPPB();
							m.CADENLBDAEB = false;
							m.FDEBLMKEMLF = 0;
							m.CLDKMLONBHJ = 0;
							m.INHOGJODJFJ = 0;
							m.JDDIOOJHIHP = 0;
							m.NPDKEIIMCDI = r.ReadInt64();
							DHDCHLAIAMP.Add(m);
						}
					}
					r.Close();
				}
			}
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
