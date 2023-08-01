
using System;

[System.Obsolete("Use KLFDBFMNLBL_ServerSaveBlock", true)]
public abstract class KLFDBFMNLBL { }
public abstract class KLFDBFMNLBL_ServerSaveBlock
{
	protected delegate void CLMHDCHPBNC(int OIPCCBHIKIA, int NANNGLGOFKH);
	protected delegate void MIOHEAMJJAK(int OIPCCBHIKIA, long NANNGLGOFKH);

	public bool LLBJFFFJEPJ_Deseralized; // 0x8
	public long FJMOAAPNCJI_SaveId = -1; // 0x10
	public bool EMBGIDLFKGM; // 0x20

	public string JIKKNHIAEKG_BlockName { get; set; } // 0x18 HIPHMHKCJOI KLGJBKFAOGN FEENLLLIMHM
	public bool MCNELPPHFKJ { get; set; } // 0x1C HBEBDLGAJNE CBGHKCGOCGG CGGHJPONCHL
	public bool KFKDMBPNLJK_BlockInvalid { get; set; } // 0x1D BLBIMNAGKOO PLCNNONHHKM CFDMFKKMOIM
	public bool FHMMFHAIPLF { get; set; } // 0x1E EPOOAPEGCBO HNONIIAOAEA FEPNEHMFJAN
	public bool EFOEPDLNLJG { get; set; } // 0x1F CPFHBAONBPP BCOKDCKGGAP DKEGLPGEFEK
	public virtual bool DMICHEJIAJL { get { return false; } } // 0x1A0BD24 NFKFOODCJJB //Slot 9

	// // RVA: 0x1A0BBE8 Offset: 0x1A0BBE8 VA: 0x1A0BBE8
	public KLFDBFMNLBL_ServerSaveBlock() 
	{
		JIKKNHIAEKG_BlockName = "";
		MCNELPPHFKJ = true;
		KFKDMBPNLJK_BlockInvalid = true;
		FHMMFHAIPLF = true;
	}

	// // RVA: 0x1A0BC70 Offset: 0x1A0BC70 VA: 0x1A0BC70
	public void LHPDDGIJKNB_Reset()
	{
		FJMOAAPNCJI_SaveId = -1;
		KFKDMBPNLJK_BlockInvalid = true;
		MCNELPPHFKJ = true;
		FHMMFHAIPLF = false;
		LLBJFFFJEPJ_Deseralized = false;
		KMBPACJNEOF();
	}

	// // RVA: -1 Offset: -1 Slot: 4
	public abstract void KMBPACJNEOF();

	// // RVA: -1 Offset: -1 Slot: 5
	public abstract void OKJPIBHMKMJ(EDOHBJAPLPF_JsonData OILEIIEIBHP, long MCKEOKFMLAH);

	// // RVA: -1 Offset: -1 Slot: 6
	public abstract bool IIEMACPEEBJ_Deserialize(EDOHBJAPLPF_JsonData OILEIIEIBHP);

	// // RVA: 0x1A0BCA4 Offset: 0x1A0BCA4 VA: 0x1A0BCA4
	public void ODDIHGPONFL_Copy(KLFDBFMNLBL_ServerSaveBlock GPBJHKLFCEP)
	{
		MCNELPPHFKJ = GPBJHKLFCEP.MCNELPPHFKJ;
		KFKDMBPNLJK_BlockInvalid = GPBJHKLFCEP.KFKDMBPNLJK_BlockInvalid;
		FHMMFHAIPLF = GPBJHKLFCEP.FHMMFHAIPLF;
		BMGGKONLFIC(GPBJHKLFCEP);
	}

	// // RVA: -1 Offset: -1 Slot: 7
	public abstract void BMGGKONLFIC(KLFDBFMNLBL_ServerSaveBlock GPBJHKLFCEP);

	// // RVA: -1 Offset: -1 Slot: 8
	public abstract bool AGBOGBEOFME(KLFDBFMNLBL_ServerSaveBlock GPBJHKLFCEP);
	
	// // RVA: 0x1A0BD2C Offset: 0x1A0BD2C VA: 0x1A0BD2C Slot: 10
	public virtual void AGHKODFKOJI(BHBONAHFKHD JBBHNIACMFJ, KLFDBFMNLBL_ServerSaveBlock GJLFANGDGCL, long MCKEOKFMLAH)
	{
		TodoLogger.LogError(0, "AGHKODFKOJI");
	}

	// // RVA: 0x1A0BD30 Offset: 0x1A0BD30 VA: 0x1A0BD30
	protected int CJAENOMGPDA_ReadInt(EDOHBJAPLPF_JsonData LFFNOHMOKJA, string LJNAKDMILMC, int HDDJJLKAFIF_DefaultValue, ref bool NGJDHLGMHMH_NotValid)
	{
		if(!LFFNOHMOKJA.BBAJPINMOEP_Contains(LJNAKDMILMC))
		{
			NGJDHLGMHMH_NotValid = true;
			return HDDJJLKAFIF_DefaultValue;
		}
		if(LFFNOHMOKJA[LJNAKDMILMC].MDDJBLEDMBJ_IsInt)
		{
			return (int)LFFNOHMOKJA[LJNAKDMILMC];
		}
		else if(!LFFNOHMOKJA[LJNAKDMILMC].EPNAPDBIJJE_IsString)
		{
			return HDDJJLKAFIF_DefaultValue;
		}
		else
		{
			int val = 0;
			if (Int32.TryParse((string)LFFNOHMOKJA[LJNAKDMILMC], out val))
			{
				return val;
			}
		}
		return HDDJJLKAFIF_DefaultValue;
	}

	// // RVA: 0x1A0BF14 Offset: 0x1A0BF14 VA: 0x1A0BF14
	protected long DKMPHAPBDLH_ReadLong(EDOHBJAPLPF_JsonData LFFNOHMOKJA, string LJNAKDMILMC, long HDDJJLKAFIF_DefaultValue, ref bool NGJDHLGMHMH_NotValid)
	{
		if(!LFFNOHMOKJA.BBAJPINMOEP_Contains(LJNAKDMILMC))
		{
			NGJDHLGMHMH_NotValid = true;
			return HDDJJLKAFIF_DefaultValue;
		}
		if(LFFNOHMOKJA[LJNAKDMILMC].DCPEFFOMOOK_IsLong)
		{
			return (long)LFFNOHMOKJA[LJNAKDMILMC];
		}
		if(LFFNOHMOKJA[LJNAKDMILMC].MDDJBLEDMBJ_IsInt)
		{
			return (int)LFFNOHMOKJA[LJNAKDMILMC];
		}
		if(LFFNOHMOKJA[LJNAKDMILMC].EPNAPDBIJJE_IsString)
		{
			long val = 0;
			if(Int64.TryParse((string)LFFNOHMOKJA[LJNAKDMILMC], out val))
			{
				return val;
			}
		}
		return HDDJJLKAFIF_DefaultValue;
	}

	// // RVA: 0x1A0C1A0 Offset: 0x1A0C1A0 VA: 0x1A0C1A0
	protected string FGCNMLBACGO_ReadString(EDOHBJAPLPF_JsonData LFFNOHMOKJA, string LJNAKDMILMC, string HCGFLHLODKD_DefaultValue, ref bool NGJDHLGMHMH_IsInvalid)
	{
		if (!LFFNOHMOKJA.BBAJPINMOEP_Contains(LJNAKDMILMC))
		{
			NGJDHLGMHMH_IsInvalid = true;
			return HCGFLHLODKD_DefaultValue;
		}
		if (LFFNOHMOKJA[LJNAKDMILMC].EPNAPDBIJJE_IsString)
			return (string)LFFNOHMOKJA[LJNAKDMILMC];
		if (LFFNOHMOKJA[LJNAKDMILMC].MDDJBLEDMBJ_IsInt)
			return ""+(int)LFFNOHMOKJA[LJNAKDMILMC];
		if(LFFNOHMOKJA[LJNAKDMILMC].DCPEFFOMOOK_IsLong)
			return "" + (long)LFFNOHMOKJA[LJNAKDMILMC];
		return HCGFLHLODKD_DefaultValue;
	}

	// // RVA: 0x1A0C41C Offset: 0x1A0C41C VA: 0x1A0C41C
	protected void IBCGPBOGOGP_ReadIntArray(EDOHBJAPLPF_JsonData NICPPBGFMBI, string LJNAKDMILMC, int HCGFLHLODKD_DefaultValue, int GLBEAENLHKC_Count, CLMHDCHPBNC OCMLFNJCIDN_Callback, ref bool NGJDHLGMHMH_IsInvalid)
	{
		if(!NICPPBGFMBI.BBAJPINMOEP_Contains(LJNAKDMILMC))
		{
			NGJDHLGMHMH_IsInvalid = true;
			for(int i = 0; i < GLBEAENLHKC_Count; i++)
			{
				OCMLFNJCIDN_Callback(i, HCGFLHLODKD_DefaultValue);
			}
			return;
		}
		if(NICPPBGFMBI[LJNAKDMILMC].HNBFOAJIIAL_Count != GLBEAENLHKC_Count)
		{
			NGJDHLGMHMH_IsInvalid = true;
		}
		for(int i = 0; i < GLBEAENLHKC_Count; i++)
		{
			if(i < NICPPBGFMBI[LJNAKDMILMC].HNBFOAJIIAL_Count)
			{
				OCMLFNJCIDN_Callback(i, (int)(NICPPBGFMBI[LJNAKDMILMC][i]));
			}
			else
			{
				OCMLFNJCIDN_Callback(i, HCGFLHLODKD_DefaultValue);
			}
		}
	}

	// // RVA: 0x1A0C634 Offset: 0x1A0C634 VA: 0x1A0C634
	protected void IEKHEAMPLDA_ReadLongArray(EDOHBJAPLPF_JsonData NICPPBGFMBI, string LJNAKDMILMC, long HCGFLHLODKD, int GLBEAENLHKC, MIOHEAMJJAK OCMLFNJCIDN, ref bool NGJDHLGMHMH)
	{
		if(NICPPBGFMBI.BBAJPINMOEP_Contains(LJNAKDMILMC))
		{
			EDOHBJAPLPF_JsonData b = NICPPBGFMBI[LJNAKDMILMC];
			if (GLBEAENLHKC != b.HNBFOAJIIAL_Count)
				NGJDHLGMHMH = true;
			for(int i = 0; i < GLBEAENLHKC; i++)
			{
				if(i < b.HNBFOAJIIAL_Count)
				{
					if(b[i].MDDJBLEDMBJ_IsInt)
					{
						OCMLFNJCIDN(i, (int)b[i]);
					}
					else if(b[i].DCPEFFOMOOK_IsLong)
					{
						OCMLFNJCIDN(i, (long)b[i]);
					}
					else
					{
						OCMLFNJCIDN(i, HCGFLHLODKD);
					}
				}
				else
				{
					OCMLFNJCIDN(i, HCGFLHLODKD);
				}
			}
		}
		else
		{
			for (int i = 0; i < GLBEAENLHKC; i++)
			{
				OCMLFNJCIDN(i, HCGFLHLODKD);
			}
		}
	}

	// // RVA: 0x1A0CA48 Offset: 0x1A0CA48 VA: 0x1A0CA48 Slot: 11
	public virtual FENCAJJBLBH PFAKPFKJJKA()
	{
		TodoLogger.LogError(TodoLogger.DbIntegrityCheck, "TODO");
		return null;
	}

	// // RVA: 0x1A0CA50 Offset: 0x1A0CA50 VA: 0x1A0CA50
	protected EDOHBJAPLPF_JsonData LGPBAKLCFHI_FindAndCheckBlock(EDOHBJAPLPF_JsonData OILEIIEIBHP, ref bool NPNNPNAIONN_BlockMissing, ref bool NGJDHLGMHMH_NotValid, int FHKFHKLDJIE_Rev)
	{
		if(OILEIIEIBHP.BBAJPINMOEP_Contains(AFEHLCGHAEE_Strings.JCIBKDHKNFH_alldata/*alldata*/))
		{
			OILEIIEIBHP = OILEIIEIBHP[AFEHLCGHAEE_Strings.JCIBKDHKNFH_alldata];
		}
		if(!OILEIIEIBHP.BBAJPINMOEP_Contains(JIKKNHIAEKG_BlockName))
		{
			if (EMBGIDLFKGM)
				return null;
			NPNNPNAIONN_BlockMissing = true;
			return null;
		}
		EDOHBJAPLPF_JsonData block = OILEIIEIBHP[JIKKNHIAEKG_BlockName];
		if (EMBGIDLFKGM)
			return block;
		if(block.BBAJPINMOEP_Contains(AFEHLCGHAEE_Strings.AGPKGMFOJHC_rev/*rev*/))
		{
			if((int)block[AFEHLCGHAEE_Strings.AGPKGMFOJHC_rev] != FHKFHKLDJIE_Rev)
			{
				NGJDHLGMHMH_NotValid = true;
			}
		}
		else
		{
			NGJDHLGMHMH_NotValid = true;
		}
		if (!block.BBAJPINMOEP_Contains(JIKKNHIAEKG_BlockName))
		{
			NGJDHLGMHMH_NotValid = true;
			KFKDMBPNLJK_BlockInvalid = true;
			return null;
		}
		return block[JIKKNHIAEKG_BlockName];
	}
}
