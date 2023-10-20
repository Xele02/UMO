
using System.IO;

public class MDDBFCFOKFC
{
	public class IFHIAPIJGMI
	{
		private const long BHEHGCHGBDG = 0xc962d604614f5;
		private const int GCAHAAADBEH = 54287102;
		private const int GKIDNIKODDK = 0x1fc428c;
		public long OPHCDLEFFIP; // 0x8
		public int DIFBAMPAOJI; // 0x10
		public int AMEELEFFAEC; // 0x14

		public long NPDKEIIMCDI_LastShowtime { get { return OPHCDLEFFIP ^ BHEHGCHGBDG; } set { OPHCDLEFFIP = value ^ BHEHGCHGBDG; } } //0x130F528 NEGDLLGOPKH 0x130F4E8 FEAJLAKILIO
		public bool CINLIMIKCAL_EnableBgEffect { get { return DIFBAMPAOJI == GCAHAAADBEH; } set { DIFBAMPAOJI = value ? GCAHAAADBEH : GKIDNIKODDK; } } //0x130F548 AMJHFHHKBIM 0x130F50C PCCOLLEDFMJ
		public bool HEKJKLJDHNN_EnablePosterAnim { get { return AMEELEFFAEC == GCAHAAADBEH; } set { AMEELEFFAEC = value ? GCAHAAADBEH : GKIDNIKODDK; } } //0x130F564 JGCAHFJDAKI 0x130F580 CDBCKJDGPNF

		//// RVA: 0x130ECE0 Offset: 0x130ECE0 VA: 0x130ECE0
		public void KHEKNNFCAOI()
		{
			NPDKEIIMCDI_LastShowtime = 0;
			CINLIMIKCAL_EnableBgEffect = false;
			HEKJKLJDHNN_EnablePosterAnim = true;
		}

		//// RVA: 0x130F3A0 Offset: 0x130F3A0 VA: 0x130F3A0
		public void FPEKCEGADMG(BinaryWriter OMLLGAKPMAN)
		{
			OMLLGAKPMAN.Write(NPDKEIIMCDI_LastShowtime);
			OMLLGAKPMAN.Write(CINLIMIKCAL_EnableBgEffect);
			OMLLGAKPMAN.Write(HEKJKLJDHNN_EnablePosterAnim);
		}

		//// RVA: 0x130ED14 Offset: 0x130ED14 VA: 0x130ED14
		public void FKGBNKPHCJL(int CEMEIPNMAAD, BinaryReader CLJIOLIEPNA)
		{
			if(CEMEIPNMAAD == 2)
			{
				NPDKEIIMCDI_LastShowtime = CLJIOLIEPNA.ReadInt64();
				CINLIMIKCAL_EnableBgEffect = CLJIOLIEPNA.ReadBoolean();
				HEKJKLJDHNN_EnablePosterAnim = CLJIOLIEPNA.ReadBoolean();
			}
			else if(CEMEIPNMAAD == 1)
			{
				NPDKEIIMCDI_LastShowtime = CLJIOLIEPNA.ReadInt64();
				CINLIMIKCAL_EnableBgEffect = CLJIOLIEPNA.ReadBoolean();
				HEKJKLJDHNN_EnablePosterAnim = true;
			}
		}
	}

	public const int JNCCCCPBDIC = 2;
	public IFHIAPIJGMI KOGBMDOONFA = new IFHIAPIJGMI(); // 0x8
	private string ELLBAAFKDCH_Path; // 0xC

	// RVA: 0x130E700 Offset: 0x130E700 VA: 0x130E700
	public MDDBFCFOKFC()
	{
		ELLBAAFKDCH_Path = CJMOKHDNBNB.FIPFFELDIOG_PersistentPath + "/SaveData/dc";
	}

	//// RVA: 0x130E7D4 Offset: 0x130E7D4 VA: 0x130E7D4
	//public void KHEKNNFCAOI(string CJEKGLGBIHF) { }

	// RVA: 0x130E7DC Offset: 0x130E7DC VA: 0x130E7DC
	public void PCODDPDFLHK_Load()
	{
		KOGBMDOONFA.KHEKNNFCAOI();
		if(File.Exists(ELLBAAFKDCH_Path))
		{
			using (FileStream f = new FileStream(ELLBAAFKDCH_Path, FileMode.Open))
			{
				using (BinaryReader b = new BinaryReader(f))
				{
					KOGBMDOONFA.FKGBNKPHCJL(b.ReadInt32(), b);
				}
			}
		}
	}

	// RVA: 0x130EE74 Offset: 0x130EE74 VA: 0x130EE74
	public void HJMKBCFJOOH_Save()
	{
		string dir = Path.GetDirectoryName(ELLBAAFKDCH_Path);
		if (!Directory.Exists(dir))
			Directory.CreateDirectory(dir);
		using (FileStream f = new FileStream(ELLBAAFKDCH_Path, FileMode.Create))
		{
			using (BinaryWriter b = new BinaryWriter(f))
			{
				b.Write(2);
				KOGBMDOONFA.FPEKCEGADMG(b);
				b.Flush();
				b.Close();
			}
		}
	}

	//// RVA: 0x130F47C Offset: 0x130F47C VA: 0x130F47C
	//public void JCHLONCMPAJ(bool OGBEGDKPDGK) { }
}
