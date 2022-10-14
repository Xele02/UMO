using System.Collections.Generic;

public class CIFHILOJJFC
{
    public delegate bool OJPDCIGOLMA(int AHHJLDLAPAN, int BCCHOBPJJKE);
    
	public int GIDKKHFHALL; // 0x8
	public string OPFGFINHFCE_Name = ""; // 0xC
	public List<AMCGONHBGGF> FDBOPFEOENF; // 0x10
	public List<DKDMLOBCPFC> KAKGHFFOAEJ; // 0x14
	public int FODKKJIDDKN_VfId; // 0x18
	public int GCCNMFHELCB; // 0x1C
	public static string CBELJGBFLGA = "StringLiteral_9767"; // 0x0 

	// // RVA: 0xFF5340 Offset: 0xFF5340 VA: 0xFF5340
	public CIFHILOJJFC()
	{
		FDBOPFEOENF = new List<AMCGONHBGGF>(3);
		for(int i = 0; i < 3; i++)
		{
			FDBOPFEOENF.Add(new AMCGONHBGGF());
		}
		KAKGHFFOAEJ = new List<DKDMLOBCPFC>();
		for(int i = 0; i < 2; i++)
		{
			KAKGHFFOAEJ.Add(new DKDMLOBCPFC());
		}
	}

	// // RVA: 0xFF54D4 Offset: 0xFF54D4 VA: 0xFF54D4
	// public bool DFIGPDCBAPB() { }

	// // RVA: 0xFF5578 Offset: 0xFF5578 VA: 0xFF5578
	// public int EIDAHHCEPPC() { }

	// // RVA: 0xFF56B4 Offset: 0xFF56B4 VA: 0xFF56B4
	// public int CJJIHFDLNMJ(CIFHILOJJFC.OJPDCIGOLMA MKANHLNEEGL) { }

	// // RVA: 0xFF5D50 Offset: 0xFF5D50 VA: 0xFF5D50
	// public void LHPDDGIJKNB_Reset() { }

	// // RVA: 0xFF5EB0 Offset: 0xFF5EB0 VA: 0xFF5EB0
	public void ODDIHGPONFL_Copy(CIFHILOJJFC GPBJHKLFCEP, bool OIBBFBLBLMH = false)
	{
		OPFGFINHFCE_Name = GPBJHKLFCEP.OPFGFINHFCE_Name;
		for(int i = 0; i < 3; i++)
		{
			FDBOPFEOENF[i].ODDIHGPONFL_Copy(GPBJHKLFCEP.FDBOPFEOENF[i]);
		}
		for(int i = 0; i < 2; i++)
		{
			KAKGHFFOAEJ[i].ODDIHGPONFL_Copy(GPBJHKLFCEP.KAKGHFFOAEJ[i]);
		}
		FODKKJIDDKN_VfId = GPBJHKLFCEP.FODKKJIDDKN_VfId;
		if (OIBBFBLBLMH)
			GIDKKHFHALL = GPBJHKLFCEP.GIDKKHFHALL;
	}

	// // RVA: 0xFF6070 Offset: 0xFF6070 VA: 0xFF6070
	// public bool AGBOGBEOFME(CIFHILOJJFC OIKJFMGEICL) { }

	// // RVA: 0xFF6258 Offset: 0xFF6258 VA: 0xFF6258
	// public void AGHKODFKOJI(BHBONAHFKHD JBBHNIACMFJ, string JIKKNHIAEKG, string MJBACHKCIHA, int OIPCCBHIKIA, CIFHILOJJFC OHMCIEMIKCE, bool EFOEPDLNLJG) { }
}
