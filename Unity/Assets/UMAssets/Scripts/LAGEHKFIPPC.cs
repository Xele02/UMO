
using System.IO;

public class LAGEHKFIPPC
{
	public class EHPHFDNBFAO
	{
		public int IDCGBCGNOLH_Day; // 0x8

		//// RVA: 0xD905C8 Offset: 0xD905C8 VA: 0xD905C8
		//public void FPEKCEGADMG(BinaryWriter _OMLLGAKPMAN_writer) { }

		//// RVA: 0xD90054 Offset: 0xD90054 VA: 0xD90054
		//public void FKGBNKPHCJL(int _CEMEIPNMAAD_Version, BinaryReader _CLJIOLIEPNA_reader) { }
	}

	public const int JNCCCCPBDIC = 1;
	public EHPHFDNBFAO KOGBMDOONFA_Info; // 0x8
	private string ELLBAAFKDCH_Filename; // 0xC
	
	// RVA: 0xD8FAB0 Offset: 0xD8FAB0 VA: 0xD8FAB0
	public LAGEHKFIPPC()
	{
		KOGBMDOONFA_Info = new EHPHFDNBFAO();
		ELLBAAFKDCH_Filename = CJMOKHDNBNB.FIPFFELDIOG_PersistentPath + "/SaveData/cbp0";
	}

	//// RVA: 0xD8FB84 Offset: 0xD8FB84 VA: 0xD8FB84
	//public void KHEKNNFCAOI_Init(string _CJEKGLGBIHF_path) { }

	//// RVA: 0xD8FB8C Offset: 0xD8FB8C VA: 0xD8FB8C
	public void PCODDPDFLHK_Load()
	{
		if(!File.Exists(ELLBAAFKDCH_Filename))
			return;
		FileStream fs = new FileStream(ELLBAAFKDCH_Filename, FileMode.Open);
		BinaryReader br = new BinaryReader(fs);
		br.ReadInt32();
		KOGBMDOONFA_Info.IDCGBCGNOLH_Day = br.ReadInt32();
		br.Close();
		br.Dispose();
		fs.Dispose();
	}

	//// RVA: 0xD90090 Offset: 0xD90090 VA: 0xD90090
	public void HJMKBCFJOOH_Save()
	{
		string dirName = Path.GetDirectoryName(ELLBAAFKDCH_Filename);
		if (!Directory.Exists(dirName))
			Directory.CreateDirectory(dirName);
		FileStream fs = new FileStream(ELLBAAFKDCH_Filename, FileMode.Create);
		BinaryWriter br = new BinaryWriter(fs);
		br.Write(JNCCCCPBDIC);
		br.Write(KOGBMDOONFA_Info.IDCGBCGNOLH_Day);
		br.Flush();
		br.Close();
		br.Dispose();
		fs.Dispose();
	}

	//// RVA: 0xD90604 Offset: 0xD90604 VA: 0xD90604
	//public void JCHLONCMPAJ(bool OGBEGDKPDGK) { }
}
