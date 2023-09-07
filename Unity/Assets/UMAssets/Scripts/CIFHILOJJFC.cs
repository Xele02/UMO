using System.Collections.Generic;

public class CIFHILOJJFC
{
    public delegate bool OJPDCIGOLMA(int AHHJLDLAPAN, int BCCHOBPJJKE);
    
	public int GIDKKHFHALL; // 0x8
	public string OPFGFINHFCE_Name = ""; // 0xC
	public List<AMCGONHBGGF> FDBOPFEOENF_MainDivas; // 0x10
	public List<DKDMLOBCPFC> KAKGHFFOAEJ_AddDivas; // 0x14
	public int FODKKJIDDKN_VfId; // 0x18
	public int GCCNMFHELCB_Form; // 0x1C
	public static string CBELJGBFLGA = JpStringLiterals.StringLiteral_9767; // 0x0 

	// // RVA: 0xFF5340 Offset: 0xFF5340 VA: 0xFF5340
	public CIFHILOJJFC()
	{
		FDBOPFEOENF_MainDivas = new List<AMCGONHBGGF>(3);
		for(int i = 0; i < 3; i++)
		{
			FDBOPFEOENF_MainDivas.Add(new AMCGONHBGGF());
		}
		KAKGHFFOAEJ_AddDivas = new List<DKDMLOBCPFC>();
		for(int i = 0; i < 2; i++)
		{
			KAKGHFFOAEJ_AddDivas.Add(new DKDMLOBCPFC());
		}
	}

	// // RVA: 0xFF54D4 Offset: 0xFF54D4 VA: 0xFF54D4
	// public bool DFIGPDCBAPB() { }

	// // RVA: 0xFF5578 Offset: 0xFF5578 VA: 0xFF5578
	public int EIDAHHCEPPC_GetNumScenes()
	{
		int res = 0;
		for(int i = 0; i < FDBOPFEOENF_MainDivas.Count; i++)
		{
			for(int j = 0; j < FDBOPFEOENF_MainDivas[i].EBDNICPAFLB_SSlot.Length; j++)
			{
				if (FDBOPFEOENF_MainDivas[i].EBDNICPAFLB_SSlot[j] != 0)
					res++;
			}
		}
		return res;
	}

	// // RVA: 0xFF56B4 Offset: 0xFF56B4 VA: 0xFF56B4
	public int CJJIHFDLNMJ_CountForEachDivaScene(OJPDCIGOLMA MKANHLNEEGL)
	{
		int res = 0;
		for(int i = 0; i < FDBOPFEOENF_MainDivas.Count; i++)
		{
			for(int j = 0; j < FDBOPFEOENF_MainDivas[i].EBDNICPAFLB_SSlot.Length; j++)
			{
				if(FDBOPFEOENF_MainDivas[i].EBDNICPAFLB_SSlot[j] != 0)
				{
					if (MKANHLNEEGL(FDBOPFEOENF_MainDivas[i].DIPKCALNIII_Id, FDBOPFEOENF_MainDivas[i].EBDNICPAFLB_SSlot[j]))
						res++;
				}
			}
		}
		return res;
	}

	// // RVA: 0xFF5D50 Offset: 0xFF5D50 VA: 0xFF5D50
	// public void LHPDDGIJKNB_Reset() { }

	// // RVA: 0xFF5EB0 Offset: 0xFF5EB0 VA: 0xFF5EB0
	public void ODDIHGPONFL_Copy(CIFHILOJJFC GPBJHKLFCEP, bool OIBBFBLBLMH = false)
	{
		OPFGFINHFCE_Name = GPBJHKLFCEP.OPFGFINHFCE_Name;
		for(int i = 0; i < 3; i++)
		{
			FDBOPFEOENF_MainDivas[i].ODDIHGPONFL_Copy(GPBJHKLFCEP.FDBOPFEOENF_MainDivas[i]);
		}
		for(int i = 0; i < 2; i++)
		{
			KAKGHFFOAEJ_AddDivas[i].ODDIHGPONFL_Copy(GPBJHKLFCEP.KAKGHFFOAEJ_AddDivas[i]);
		}
		FODKKJIDDKN_VfId = GPBJHKLFCEP.FODKKJIDDKN_VfId;
		if (OIBBFBLBLMH)
			GIDKKHFHALL = GPBJHKLFCEP.GIDKKHFHALL;
	}

	// // RVA: 0xFF6070 Offset: 0xFF6070 VA: 0xFF6070
	public bool AGBOGBEOFME(CIFHILOJJFC OIKJFMGEICL)
	{
		if(GIDKKHFHALL != OIKJFMGEICL.GIDKKHFHALL ||
			FODKKJIDDKN_VfId != OIKJFMGEICL.FODKKJIDDKN_VfId)
			return false;
		for(int i = 0; i < 3; i++)
		{
			if(!FDBOPFEOENF_MainDivas[i].AGBOGBEOFME(OIKJFMGEICL.FDBOPFEOENF_MainDivas[i]))
				return false;
		}
		for(int i = 0; i < 2; i++)
		{
			if(!KAKGHFFOAEJ_AddDivas[i].AGBOGBEOFME(OIKJFMGEICL.KAKGHFFOAEJ_AddDivas[i]))
				return false;
		}
		return OPFGFINHFCE_Name == OIKJFMGEICL.OPFGFINHFCE_Name;
	}

	// // RVA: 0xFF6258 Offset: 0xFF6258 VA: 0xFF6258
	// public void AGHKODFKOJI(BHBONAHFKHD JBBHNIACMFJ, string JIKKNHIAEKG, string MJBACHKCIHA, int OIPCCBHIKIA, CIFHILOJJFC OHMCIEMIKCE, bool EFOEPDLNLJG) { }
}
