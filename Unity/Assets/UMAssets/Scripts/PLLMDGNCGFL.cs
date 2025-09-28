
using System.IO;

public class PLLMDGNCGFL
{
    public class OGGOJFIPCEP
    {
        public long NPDKEIIMCDI_LastShowtime; // 0x8

        // RVA: 0xFEACCC Offset: 0xFEACCC VA: 0xFEACCC
        // public void FPEKCEGADMG_Write(BinaryWriter _OMLLGAKPMAN_writer) { }

        // // RVA: 0xFEA74C Offset: 0xFEA74C VA: 0xFEA74C
        // public void FKGBNKPHCJL_Read(int _CEMEIPNMAAD_Version, BinaryReader _CLJIOLIEPNA_reader) { }
    }

	public const int JNCCCCPBDIC_Version = 1;
	public OGGOJFIPCEP KOGBMDOONFA_Info = new OGGOJFIPCEP(); // 0x8
	private string ELLBAAFKDCH_Filename; // 0xC

	// RVA: 0xFEA1A8 Offset: 0xFEA1A8 VA: 0xFEA1A8
	public PLLMDGNCGFL()
    {
        ELLBAAFKDCH_Filename = CJMOKHDNBNB.FIPFFELDIOG_PersistentPath + "/SaveData/rb0";
    }

	// // RVA: 0xFEA27C Offset: 0xFEA27C VA: 0xFEA27C
	// public void KHEKNNFCAOI_Init(string _CJEKGLGBIHF_path) { }

	// // RVA: 0xFEA284 Offset: 0xFEA284 VA: 0xFEA284
	public void PCODDPDFLHK_Load()
    {
        if(File.Exists(ELLBAAFKDCH_Filename))
        {
            FileStream fs = new FileStream(ELLBAAFKDCH_Filename, FileMode.Open);
            BinaryReader br = new BinaryReader(fs);
            br.ReadInt32();
            KOGBMDOONFA_Info.NPDKEIIMCDI_LastShowtime = br.ReadInt64();
            br.Close();
            br.Dispose();
            fs.Dispose();
        }
    }

	// // RVA: 0xFEA788 Offset: 0xFEA788 VA: 0xFEA788
	public void HJMKBCFJOOH_Save()
    {
        string dir = Path.GetDirectoryName(ELLBAAFKDCH_Filename);
        if(!Directory.Exists(dir))
            Directory.CreateDirectory(dir);
        using(FileStream fs = new FileStream(ELLBAAFKDCH_Filename, FileMode.Create))
        {
            using(BinaryWriter bw = new BinaryWriter(fs))
            {
                bw.Write(1);
                bw.Write(KOGBMDOONFA_Info.NPDKEIIMCDI_LastShowtime);
                bw.Flush();
                bw.Close();
            }
        }
    }

	// // RVA: 0xFEAD1C Offset: 0xFEAD1C VA: 0xFEAD1C
	// public void JCHLONCMPAJ_Clear(bool _OGBEGDKPDGK_NeedSave) { }
}
