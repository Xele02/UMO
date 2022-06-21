using FlatBuffers;
using System.Collections.Generic;

public class BNBONBECPKB
{
	public LPMLJGGJGGK[] GMLFFMJMPCC { get; set; } // 0x8 MKAFOOHLHAC FHEIILDDCIM 0x19CA914 CBMHJMIJLHH 0x19CA91C

	// RVA: 0x19CA924 Offset: 0x19CA924 VA: 0x19CA924
	public static BNBONBECPKB HEGEKFMJNCC(byte[] NIODCJLINJN)
    {
		UnityEngine.Debug.LogError("TODO reader auto ODNNPHLAMGH");
        ByteBuffer buffer = new ByteBuffer(NIODCJLINJN);
        ODNNPHLAMGH table = ODNNPHLAMGH.GetRootAsODNNPHLAMGH(buffer);
        BNBONBECPKB b = new BNBONBECPKB();

        List<LPMLJGGJGGK> l = new List<LPMLJGGJGGK>();

        for(int i = 0; i < table.AMGOKLNCCPHLength; i++)
        {
            LPMLJGGJGGK obj = new LPMLJGGJGGK();
            obj.OPFGFINHFCE = table.GetAMGOKLNCCPH(i).IIDCFMHCPLJ;
            obj.IOIMHJAOKOO = table.GetAMGOKLNCCPH(i).PAPMBEBHHIG;
            l.Add(obj);
        }

        b.GMLFFMJMPCC = l.ToArray();
        
        return b;
    }
}