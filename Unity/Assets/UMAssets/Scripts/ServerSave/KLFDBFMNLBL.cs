
using System;

[System.Obsolete("Use KLFDBFMNLBL_ServerSaveBlock", true)]
public abstract class KLFDBFMNLBL { }
public abstract class KLFDBFMNLBL_ServerSaveBlock
{
	protected delegate void CLMHDCHPBNC(int _OIPCCBHIKIA_index, int _NANNGLGOFKH_value);
	protected delegate void MIOHEAMJJAK(int _OIPCCBHIKIA_index, long _NANNGLGOFKH_value);

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
		KMBPACJNEOF_Reset();
	}

	// // RVA: -1 Offset: -1 Slot: 4
	public abstract void KMBPACJNEOF_Reset();

	// // RVA: -1 Offset: -1 Slot: 5
	public abstract void OKJPIBHMKMJ(EDOHBJAPLPF_JsonData OILEIIEIBHP, long _MCKEOKFMLAH_SaveId);

	// // RVA: -1 Offset: -1 Slot: 6
	public abstract bool IIEMACPEEBJ_Deserialize(EDOHBJAPLPF_JsonData OILEIIEIBHP);

	// // RVA: 0x1A0BCA4 Offset: 0x1A0BCA4 VA: 0x1A0BCA4
	public void ODDIHGPONFL_Copy(KLFDBFMNLBL_ServerSaveBlock GPBJHKLFCEP)
	{
		MCNELPPHFKJ = GPBJHKLFCEP.MCNELPPHFKJ;
		KFKDMBPNLJK_BlockInvalid = GPBJHKLFCEP.KFKDMBPNLJK_BlockInvalid;
		FHMMFHAIPLF = GPBJHKLFCEP.FHMMFHAIPLF;
		BMGGKONLFIC_Copy(GPBJHKLFCEP);
	}

	// // RVA: -1 Offset: -1 Slot: 7
	public abstract void BMGGKONLFIC_Copy(KLFDBFMNLBL_ServerSaveBlock GPBJHKLFCEP);

	// // RVA: -1 Offset: -1 Slot: 8
	public abstract bool AGBOGBEOFME(KLFDBFMNLBL_ServerSaveBlock GPBJHKLFCEP);
	
	// // RVA: 0x1A0BD2C Offset: 0x1A0BD2C VA: 0x1A0BD2C Slot: 10
	//public virtual void AGHKODFKOJI(BHBONAHFKHD JBBHNIACMFJ, KLFDBFMNLBL_ServerSaveBlock _GJLFANGDGCL_Target, long _MCKEOKFMLAH_SaveId);

	// // RVA: 0x1A0BD30 Offset: 0x1A0BD30 VA: 0x1A0BD30
	protected int CJAENOMGPDA_ReadInt(EDOHBJAPLPF_JsonData LFFNOHMOKJA, string _LJNAKDMILMC_key, int HDDJJLKAFIF_DefaultValue, ref bool _NGJDHLGMHMH_IsInvalid)
	{
		if(!LFFNOHMOKJA.BBAJPINMOEP_Contains(_LJNAKDMILMC_key))
		{
			_NGJDHLGMHMH_IsInvalid = true;
			return HDDJJLKAFIF_DefaultValue;
		}
		if(LFFNOHMOKJA[_LJNAKDMILMC_key].MDDJBLEDMBJ_IsInt)
		{
			return (int)LFFNOHMOKJA[_LJNAKDMILMC_key];
		}
		else if(!LFFNOHMOKJA[_LJNAKDMILMC_key].EPNAPDBIJJE_IsString)
		{
			return HDDJJLKAFIF_DefaultValue;
		}
		else
		{
			int val = 0;
			if (Int32.TryParse((string)LFFNOHMOKJA[_LJNAKDMILMC_key], out val))
			{
				return val;
			}
		}
		return HDDJJLKAFIF_DefaultValue;
	}

	// // RVA: 0x1A0BF14 Offset: 0x1A0BF14 VA: 0x1A0BF14
	protected long DKMPHAPBDLH_ReadLong(EDOHBJAPLPF_JsonData LFFNOHMOKJA, string _LJNAKDMILMC_key, long HDDJJLKAFIF_DefaultValue, ref bool _NGJDHLGMHMH_IsInvalid)
	{
		if(!LFFNOHMOKJA.BBAJPINMOEP_Contains(_LJNAKDMILMC_key))
		{
			_NGJDHLGMHMH_IsInvalid = true;
			return HDDJJLKAFIF_DefaultValue;
		}
		if(LFFNOHMOKJA[_LJNAKDMILMC_key].DCPEFFOMOOK_IsLong)
		{
			return (long)LFFNOHMOKJA[_LJNAKDMILMC_key];
		}
		if(LFFNOHMOKJA[_LJNAKDMILMC_key].MDDJBLEDMBJ_IsInt)
		{
			return (int)LFFNOHMOKJA[_LJNAKDMILMC_key];
		}
		if(LFFNOHMOKJA[_LJNAKDMILMC_key].EPNAPDBIJJE_IsString)
		{
			long val = 0;
			if(Int64.TryParse((string)LFFNOHMOKJA[_LJNAKDMILMC_key], out val))
			{
				return val;
			}
		}
		return HDDJJLKAFIF_DefaultValue;
	}

	// // RVA: 0x1A0C1A0 Offset: 0x1A0C1A0 VA: 0x1A0C1A0
	protected string FGCNMLBACGO_ReadString(EDOHBJAPLPF_JsonData LFFNOHMOKJA, string _LJNAKDMILMC_key, string HCGFLHLODKD_DefaultValue, ref bool _NGJDHLGMHMH_IsInvalid)
	{
		if (!LFFNOHMOKJA.BBAJPINMOEP_Contains(_LJNAKDMILMC_key))
		{
			_NGJDHLGMHMH_IsInvalid = true;
			return HCGFLHLODKD_DefaultValue;
		}
		if (LFFNOHMOKJA[_LJNAKDMILMC_key].EPNAPDBIJJE_IsString)
			return (string)LFFNOHMOKJA[_LJNAKDMILMC_key];
		if (LFFNOHMOKJA[_LJNAKDMILMC_key].MDDJBLEDMBJ_IsInt)
			return ""+(int)LFFNOHMOKJA[_LJNAKDMILMC_key];
		if(LFFNOHMOKJA[_LJNAKDMILMC_key].DCPEFFOMOOK_IsLong)
			return "" + (long)LFFNOHMOKJA[_LJNAKDMILMC_key];
		return HCGFLHLODKD_DefaultValue;
	}

	// // RVA: 0x1A0C41C Offset: 0x1A0C41C VA: 0x1A0C41C
	protected void IBCGPBOGOGP_ReadIntArray(EDOHBJAPLPF_JsonData NICPPBGFMBI, string _LJNAKDMILMC_key, int HCGFLHLODKD_DefaultValue, int _GLBEAENLHKC_Count, CLMHDCHPBNC OCMLFNJCIDN_Callback, ref bool _NGJDHLGMHMH_IsInvalid)
	{
		if(!NICPPBGFMBI.BBAJPINMOEP_Contains(_LJNAKDMILMC_key))
		{
			_NGJDHLGMHMH_IsInvalid = true;
			for(int i = 0; i < _GLBEAENLHKC_Count; i++)
			{
				OCMLFNJCIDN_Callback(i, HCGFLHLODKD_DefaultValue);
			}
			return;
		}
		if(NICPPBGFMBI[_LJNAKDMILMC_key].HNBFOAJIIAL_Count != _GLBEAENLHKC_Count)
		{
			_NGJDHLGMHMH_IsInvalid = true;
		}
		for(int i = 0; i < _GLBEAENLHKC_Count; i++)
		{
			if(i < NICPPBGFMBI[_LJNAKDMILMC_key].HNBFOAJIIAL_Count)
			{
				OCMLFNJCIDN_Callback(i, (int)(NICPPBGFMBI[_LJNAKDMILMC_key][i]));
			}
			else
			{
				OCMLFNJCIDN_Callback(i, HCGFLHLODKD_DefaultValue);
			}
		}
	}

	// // RVA: 0x1A0C634 Offset: 0x1A0C634 VA: 0x1A0C634
	protected void IEKHEAMPLDA_ReadLongArray(EDOHBJAPLPF_JsonData NICPPBGFMBI, string _LJNAKDMILMC_key, long HCGFLHLODKD, int _GLBEAENLHKC_Count, MIOHEAMJJAK OCMLFNJCIDN, ref bool _NGJDHLGMHMH_IsInvalid)
	{
		if(NICPPBGFMBI.BBAJPINMOEP_Contains(_LJNAKDMILMC_key))
		{
			EDOHBJAPLPF_JsonData b = NICPPBGFMBI[_LJNAKDMILMC_key];
			if (_GLBEAENLHKC_Count != b.HNBFOAJIIAL_Count)
				_NGJDHLGMHMH_IsInvalid = true;
			for(int i = 0; i < _GLBEAENLHKC_Count; i++)
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
			for (int i = 0; i < _GLBEAENLHKC_Count; i++)
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
	protected EDOHBJAPLPF_JsonData LGPBAKLCFHI_FindAndCheckBlock(EDOHBJAPLPF_JsonData OILEIIEIBHP, ref bool _NPNNPNAIONN_IsError, ref bool _NGJDHLGMHMH_IsInvalid, int FHKFHKLDJIE_Rev)
	{
		if(OILEIIEIBHP.BBAJPINMOEP_Contains(AFEHLCGHAEE_Strings.JCIBKDHKNFH_alldata/*alldata*/))
		{
			OILEIIEIBHP = OILEIIEIBHP[AFEHLCGHAEE_Strings.JCIBKDHKNFH_alldata];
		}
		if(!OILEIIEIBHP.BBAJPINMOEP_Contains(JIKKNHIAEKG_BlockName))
		{
			if (EMBGIDLFKGM)
				return null;
			_NPNNPNAIONN_IsError = true;
			return null;
		}
		EDOHBJAPLPF_JsonData block = OILEIIEIBHP[JIKKNHIAEKG_BlockName];
		if (EMBGIDLFKGM)
			return block;
		if(block.BBAJPINMOEP_Contains(AFEHLCGHAEE_Strings.AGPKGMFOJHC_rev/*rev*/))
		{
			if((int)block[AFEHLCGHAEE_Strings.AGPKGMFOJHC_rev] != FHKFHKLDJIE_Rev)
			{
				if(!TryUpdateVersion(block[JIKKNHIAEKG_BlockName], (int)block[AFEHLCGHAEE_Strings.AGPKGMFOJHC_rev]))
					_NGJDHLGMHMH_IsInvalid = true;
			}
		}
		else
		{
			_NGJDHLGMHMH_IsInvalid = true;
		}
		if (!block.BBAJPINMOEP_Contains(JIKKNHIAEKG_BlockName))
		{
			_NGJDHLGMHMH_IsInvalid = true;
			KFKDMBPNLJK_BlockInvalid = true;
			return null;
		}
		return block[JIKKNHIAEKG_BlockName];
	}

	protected virtual bool TryUpdateVersion(EDOHBJAPLPF_JsonData block, int readVersion)
	{
		return false;
	}
}
