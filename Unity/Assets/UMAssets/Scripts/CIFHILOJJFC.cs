using System.Collections.Generic;

public class CIFHILOJJFC
{
    public delegate bool OJPDCIGOLMA(int _AHHJLDLAPAN_DivaId, int _BCCHOBPJJKE_SceneId);
    
	public int GIDKKHFHALL_unit_id; // 0x8
	public string OPFGFINHFCE_name = ""; // 0xC
	public List<AMCGONHBGGF> FDBOPFEOENF_diva; // 0x10
	public List<DKDMLOBCPFC> KAKGHFFOAEJ_AddDivas; // 0x14
	public int FODKKJIDDKN_vf_Id; // 0x18
	public int GCCNMFHELCB_Form; // 0x1C
	public static string CBELJGBFLGA = JpStringLiterals.StringLiteral_9767; // 0x0 

	// // RVA: 0xFF5340 Offset: 0xFF5340 VA: 0xFF5340
	public CIFHILOJJFC()
	{
		FDBOPFEOENF_diva = new List<AMCGONHBGGF>(3);
		for(int i = 0; i < 3; i++)
		{
			FDBOPFEOENF_diva.Add(new AMCGONHBGGF());
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
		for(int i = 0; i < FDBOPFEOENF_diva.Count; i++)
		{
			for(int j = 0; j < FDBOPFEOENF_diva[i].EBDNICPAFLB_s_slot.Length; j++)
			{
				if (FDBOPFEOENF_diva[i].EBDNICPAFLB_s_slot[j] != 0)
					res++;
			}
		}
		return res;
	}

	// // RVA: 0xFF56B4 Offset: 0xFF56B4 VA: 0xFF56B4
	public int CJJIHFDLNMJ_CountForEachDivaScene(OJPDCIGOLMA _MKANHLNEEGL_filter)
	{
		int res = 0;
		for(int i = 0; i < FDBOPFEOENF_diva.Count; i++)
		{
			for(int j = 0; j < FDBOPFEOENF_diva[i].EBDNICPAFLB_s_slot.Length; j++)
			{
				if(FDBOPFEOENF_diva[i].EBDNICPAFLB_s_slot[j] != 0)
				{
					if (_MKANHLNEEGL_filter(FDBOPFEOENF_diva[i].DIPKCALNIII_diva_id, FDBOPFEOENF_diva[i].EBDNICPAFLB_s_slot[j]))
						res++;
				}
			}
		}
		return res;
	}

	// // RVA: 0xFF5D50 Offset: 0xFF5D50 VA: 0xFF5D50
	public void LHPDDGIJKNB_Reset()
	{
		OPFGFINHFCE_name = CBELJGBFLGA;
		for(int i = 0; i < 3; i++)
		{
			FDBOPFEOENF_diva[i].LHPDDGIJKNB_Reset();
		}
		for(int i = 0; i < 2; i++)
		{
			KAKGHFFOAEJ_AddDivas[i].LHPDDGIJKNB_Reset();
		}
		GIDKKHFHALL_unit_id = 0;
		FODKKJIDDKN_vf_Id = 0;
	}

	// // RVA: 0xFF5EB0 Offset: 0xFF5EB0 VA: 0xFF5EB0
	public void ODDIHGPONFL_Copy(CIFHILOJJFC GPBJHKLFCEP, bool OIBBFBLBLMH/* = false*/)
	{
		OPFGFINHFCE_name = GPBJHKLFCEP.OPFGFINHFCE_name;
		for(int i = 0; i < 3; i++)
		{
			FDBOPFEOENF_diva[i].ODDIHGPONFL_Copy(GPBJHKLFCEP.FDBOPFEOENF_diva[i]);
		}
		for(int i = 0; i < 2; i++)
		{
			KAKGHFFOAEJ_AddDivas[i].ODDIHGPONFL_Copy(GPBJHKLFCEP.KAKGHFFOAEJ_AddDivas[i]);
		}
		FODKKJIDDKN_vf_Id = GPBJHKLFCEP.FODKKJIDDKN_vf_Id;
		if (OIBBFBLBLMH)
			GIDKKHFHALL_unit_id = GPBJHKLFCEP.GIDKKHFHALL_unit_id;
	}

	// // RVA: 0xFF6070 Offset: 0xFF6070 VA: 0xFF6070
	public bool AGBOGBEOFME(CIFHILOJJFC OIKJFMGEICL)
	{
		if(GIDKKHFHALL_unit_id != OIKJFMGEICL.GIDKKHFHALL_unit_id ||
			FODKKJIDDKN_vf_Id != OIKJFMGEICL.FODKKJIDDKN_vf_Id)
			return false;
		for(int i = 0; i < 3; i++)
		{
			if(!FDBOPFEOENF_diva[i].AGBOGBEOFME(OIKJFMGEICL.FDBOPFEOENF_diva[i]))
				return false;
		}
		for(int i = 0; i < 2; i++)
		{
			if(!KAKGHFFOAEJ_AddDivas[i].AGBOGBEOFME(OIKJFMGEICL.KAKGHFFOAEJ_AddDivas[i]))
				return false;
		}
		return OPFGFINHFCE_name == OIKJFMGEICL.OPFGFINHFCE_name;
	}

	// // RVA: 0xFF6258 Offset: 0xFF6258 VA: 0xFF6258
	// public void AGHKODFKOJI(BHBONAHFKHD JBBHNIACMFJ, string JIKKNHIAEKG, string MJBACHKCIHA, int _OIPCCBHIKIA_index, CIFHILOJJFC _OHMCIEMIKCE_t, bool EFOEPDLNLJG) { }
}
