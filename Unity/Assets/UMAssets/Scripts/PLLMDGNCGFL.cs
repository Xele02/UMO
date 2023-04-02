
using System.IO;

public class PLLMDGNCGFL
{
    public class OGGOJFIPCEP
    {
        public long NPDKEIIMCDI; // 0x8

        // RVA: 0xFEACCC Offset: 0xFEACCC VA: 0xFEACCC
        // public void FPEKCEGADMG(BinaryWriter OMLLGAKPMAN) { }

        // // RVA: 0xFEA74C Offset: 0xFEA74C VA: 0xFEA74C
        // public void FKGBNKPHCJL(int CEMEIPNMAAD, BinaryReader CLJIOLIEPNA) { }
    }

	public const int JNCCCCPBDIC = 1;
	public OGGOJFIPCEP KOGBMDOONFA = new OGGOJFIPCEP(); // 0x8
	private string ELLBAAFKDCH_Filename; // 0xC

	// RVA: 0xFEA1A8 Offset: 0xFEA1A8 VA: 0xFEA1A8
	public PLLMDGNCGFL()
    {
        ELLBAAFKDCH_Filename = CJMOKHDNBNB.FIPFFELDIOG_PersistentPath + "/SaveData/rb0";
    }

	// // RVA: 0xFEA27C Offset: 0xFEA27C VA: 0xFEA27C
	// public void KHEKNNFCAOI(string CJEKGLGBIHF) { }

	// // RVA: 0xFEA284 Offset: 0xFEA284 VA: 0xFEA284
	public void PCODDPDFLHK()
    {
        if(File.Exists(ELLBAAFKDCH_Filename))
        {
            FileStream fs = new FileStream(ELLBAAFKDCH_Filename, FileMode.Open);
            BinaryReader br = new BinaryReader(fs);
            br.ReadInt32();
            KOGBMDOONFA.NPDKEIIMCDI = br.ReadInt64();
            br.Close();
            br.Dispose();
            fs.Dispose();
        }
    }

	// // RVA: 0xFEA788 Offset: 0xFEA788 VA: 0xFEA788
	// public void HJMKBCFJOOH() { }

	// // RVA: 0xFEAD1C Offset: 0xFEAD1C VA: 0xFEAD1C
	// public void JCHLONCMPAJ(bool OGBEGDKPDGK) { }
}
