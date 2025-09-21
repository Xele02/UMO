using System.Collections.Generic;

[System.Obsolete("Use FKNOCGCODBK_Unit", true)]
public class FKNOCGCODBK { }
public class FKNOCGCODBK_Unit : KLFDBFMNLBL_ServerSaveBlock
{
	private const int ECFEMKGFDCE = 3;
	private List<CIFHILOJJFC> AHBBMJANGHE_Units; // 0x24
	public CIFHILOJJFC DBMOBFCLFOB_Saved = new CIFHILOJJFC(); // 0x28

	// public CIFHILOJJFC JKNGLJNEEPO { get; }
	public override bool DMICHEJIAJL { get { return true; } } // 0x1191F34 NFKFOODCJJB

	// // RVA: 0x118F3A8 Offset: 0x118F3A8 VA: 0x118F3A8
	public CIFHILOJJFC GCINIJEMHFK(int _PPFNGGCBJKC_id)
	{
		return AHBBMJANGHE_Units[_PPFNGGCBJKC_id];
	}

	// // RVA: 0x118F428 Offset: 0x118F428 VA: 0x118F428
	public CIFHILOJJFC FJDDNKGHPHN_GetDefault()
	{
		return AHBBMJANGHE_Units[0];
	}

	// // RVA: 0x118F4A4 Offset: 0x118F4A4 VA: 0x118F4A4
	public FKNOCGCODBK_Unit()
	{
		AHBBMJANGHE_Units = new List<CIFHILOJJFC>(16);
		KMBPACJNEOF_Reset();
	}

	// // RVA: 0x118F56C Offset: 0x118F56C VA: 0x118F56C Slot: 4
	public override void KMBPACJNEOF_Reset()
	{
		AHBBMJANGHE_Units.Clear();
		for(int i = 0; i < 16; i++)
		{
			CIFHILOJJFC data = new CIFHILOJJFC();
			data.GIDKKHFHALL_unit_id = i;
			data.OPFGFINHFCE_name = CIFHILOJJFC.CBELJGBFLGA;
			AHBBMJANGHE_Units.Add(data);
		}
	}

	// // RVA: 0x118F6B0 Offset: 0x118F6B0 VA: 0x118F6B0 Slot: 5
	public override void OKJPIBHMKMJ(EDOHBJAPLPF_JsonData OILEIIEIBHP, long _MCKEOKFMLAH_SaveId)
	{
		EDOHBJAPLPF_JsonData data = new EDOHBJAPLPF_JsonData();
		data.LAJDIPCJCPO_SetJsonType(JFBMDLGBPEN_JsonType.BDHGEFMCJDF_Array);
		for(int i = 0; i < AHBBMJANGHE_Units.Count; i++)
		{
			EDOHBJAPLPF_JsonData data2 = new EDOHBJAPLPF_JsonData();
			CIFHILOJJFC c = AHBBMJANGHE_Units[i];
			data2[AFEHLCGHAEE_Strings.GIDKKHFHALL_unit_id] = c.GIDKKHFHALL_unit_id;
			data2[AFEHLCGHAEE_Strings.FODKKJIDDKN_VfId] = c.FODKKJIDDKN_VfId;
			data2[AFEHLCGHAEE_Strings.OPFGFINHFCE_name] = c.OPFGFINHFCE_name;
			EDOHBJAPLPF_JsonData data3 = new EDOHBJAPLPF_JsonData();
			data3.LAJDIPCJCPO_SetJsonType(JFBMDLGBPEN_JsonType.BDHGEFMCJDF_Array);
			for(int j = 0; j < c.FDBOPFEOENF_Diva.Count; j++)
			{
				data3.Add(c.FDBOPFEOENF_Diva[j].NOJCMGAFAAC_ToJsonData());
			}
			EDOHBJAPLPF_JsonData data4 = new EDOHBJAPLPF_JsonData();
			data4.LAJDIPCJCPO_SetJsonType(JFBMDLGBPEN_JsonType.BDHGEFMCJDF_Array);
			for (int j = 0; j < c.KAKGHFFOAEJ_AddDivas.Count; j++)
			{
				data4.Add(c.KAKGHFFOAEJ_AddDivas[j].NOJCMGAFAAC_ToJsonData());
			}
			data2[AFEHLCGHAEE_Strings.FDBOPFEOENF_Diva] = data3;
			data2["add_" + AFEHLCGHAEE_Strings.FDBOPFEOENF_Diva] = data4;
			data.Add(data2);
		}
		if(!EMBGIDLFKGM)
		{
			EDOHBJAPLPF_JsonData data2 = new EDOHBJAPLPF_JsonData();
			data2[AFEHLCGHAEE_Strings.KAKFEGGEKLB_save_id] = _MCKEOKFMLAH_SaveId;
			data2[JIKKNHIAEKG_BlockName] = data;
			data2[AFEHLCGHAEE_Strings.AGPKGMFOJHC_rev] = 3;
			data = data2;
		}
		else
		{
			OILEIIEIBHP = OILEIIEIBHP[AFEHLCGHAEE_Strings.JCIBKDHKNFH_alldata];
		}
		OILEIIEIBHP[JIKKNHIAEKG_BlockName] = data;
	}

	// // RVA: 0x118FEC0 Offset: 0x118FEC0 VA: 0x118FEC0 Slot: 6
	public override bool IIEMACPEEBJ_Deserialize(EDOHBJAPLPF_JsonData OILEIIEIBHP)
	{
		bool blockMissing = false;
		bool notValid = false;
		EDOHBJAPLPF_JsonData block = LGPBAKLCFHI_FindAndCheckBlock(OILEIIEIBHP, ref blockMissing, ref notValid, 3);
		if(!blockMissing)
		{
			if(block == null || !block.EPNGJLOKGIF_IsArray)
			{
				notValid = true;
			}
			else
			{
				OKGLGHCBCJP_Database db = null;
				if(IMMAOANGPNK.HHCJCDFCLOB.LNAHEIEIBOI_Initialized)
				{
					db = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database;
				}
				for(int i = 0; i < block.HNBFOAJIIAL_Count; i++)
				{
					CIFHILOJJFC MEFHDDNABLM_unit = AHBBMJANGHE_Units[i];
					MEFHDDNABLM_unit.FODKKJIDDKN_VfId = CJAENOMGPDA_ReadInt(block[i], AFEHLCGHAEE_Strings.FODKKJIDDKN_VfId, 1, ref notValid);
					if(db != null)
					{
						if(!db.PEOALFEGNDH_Valkyrie.PILGJJCABME_IsValkyrieAvaiable(MEFHDDNABLM_unit.FODKKJIDDKN_VfId))
						{
							MEFHDDNABLM_unit.FODKKJIDDKN_VfId = 1;
						}
					}
					MEFHDDNABLM_unit.OPFGFINHFCE_name = FGCNMLBACGO_ReadString(block[i], AFEHLCGHAEE_Strings.OPFGFINHFCE_name, CIFHILOJJFC.CBELJGBFLGA, ref notValid);
					if(block[i].BBAJPINMOEP_Contains(AFEHLCGHAEE_Strings.FDBOPFEOENF_Diva))
					{
						EDOHBJAPLPF_JsonData divaArray = block[i][AFEHLCGHAEE_Strings.FDBOPFEOENF_Diva];
						for(int j = 0; j < divaArray.HNBFOAJIIAL_Count; j++)
						{
							int divaId = CJAENOMGPDA_ReadInt(divaArray[j], AFEHLCGHAEE_Strings.PPFNGGCBJKC_id, 0, ref notValid);
							int cosId = CJAENOMGPDA_ReadInt(divaArray[j], AFEHLCGHAEE_Strings.ODNOJKHHEOP_c_id, 0, ref notValid);
							if(divaId == 0) 
								cosId = 0;
							int colId = CJAENOMGPDA_ReadInt(divaArray[j], "c_col", 0, ref notValid);
							if(divaId == 0)
								colId = 0;
							if(divaId != 0 && db != null)
							{
								bool cosOk = db.MFPNGNMFEAL_Costume.OEMKAFGPOCE_IsCostumeAvaiable(cosId, divaId);
								if(!cosOk)
									cosId = 0;
								bool colOk = db.MFPNGNMFEAL_Costume.KPHOIIKOEOG_IsColorAvaiable(colId, cosId, divaId);
								if(!colOk)
									colId = 0;
							}
							AMCGONHBGGF a = MEFHDDNABLM_unit.FDBOPFEOENF_Diva[j];
							a.DIPKCALNIII_DivaId = divaId;
							a.BEEAIAAJOHD_CostumeId = cosId;
							a.AFNIOJHODAG_CostumeColorId = colId;

							IBCGPBOGOGP_ReadIntArray(divaArray[j], AFEHLCGHAEE_Strings.EBDNICPAFLB_SSlot, 0, 3, (int _OIPCCBHIKIA_index, int _JBGEEPFKIGG_val) => {
								//0x1191F3C
								a.EBDNICPAFLB_SSlot[_OIPCCBHIKIA_index] = _JBGEEPFKIGG_val;
							}, ref notValid);
							if(db != null)
							{
								for(int k = 0; k < 3; k++)
								{
									if(!db.ECNHDEHADGL_Scene.FGNJBMPDBLO_IsSceneValid(a.EBDNICPAFLB_SSlot[k]))
									{
										a.EBDNICPAFLB_SSlot[k] = 0;
									}
								}
								if(a.DIPKCALNIII_DivaId == 0)
								{
									a.BEEAIAAJOHD_CostumeId = 0;
									a.AFNIOJHODAG_CostumeColorId = 0;
								}
								else
								{
									if(!db.MFPNGNMFEAL_Costume.OEMKAFGPOCE_IsCostumeAvaiable(a.BEEAIAAJOHD_CostumeId, a.DIPKCALNIII_DivaId))
									{
										a.BEEAIAAJOHD_CostumeId = 0;
										a.AFNIOJHODAG_CostumeColorId = 0;
									}
								}
							}
						}
					}
					else
					{
						notValid = true;
					}
					if(block[i].BBAJPINMOEP_Contains("add_" + AFEHLCGHAEE_Strings.FDBOPFEOENF_Diva))
					{
						EDOHBJAPLPF_JsonData divaArray = block[i]["add_" + AFEHLCGHAEE_Strings.FDBOPFEOENF_Diva];
						for(int j = 0; j < divaArray.HNBFOAJIIAL_Count; j++)
						{
							int divaId = CJAENOMGPDA_ReadInt(divaArray[j], AFEHLCGHAEE_Strings.PPFNGGCBJKC_id, 0, ref notValid);
							int cosId = CJAENOMGPDA_ReadInt(divaArray[j], AFEHLCGHAEE_Strings.ODNOJKHHEOP_c_id, 0, ref notValid);
							if(divaId == 0) 
								cosId = 0;
							int colId = CJAENOMGPDA_ReadInt(divaArray[j], "c_col", 0, ref notValid);
							if(divaId == 0)
								colId = 0;
							if(divaId != 0 && db != null)
							{
								bool cosOk = db.MFPNGNMFEAL_Costume.OEMKAFGPOCE_IsCostumeAvaiable(cosId, divaId);
								if(!cosOk)
									cosId = 0;
								bool colOk = db.MFPNGNMFEAL_Costume.KPHOIIKOEOG_IsColorAvaiable(colId, cosId, divaId);
								if(!colOk)
									colId = 0;
							}
							DKDMLOBCPFC d = MEFHDDNABLM_unit.KAKGHFFOAEJ_AddDivas[j];
							d.DIPKCALNIII_DivaId = divaId;
							d.BEEAIAAJOHD_CostumeId = cosId;
							d.AFNIOJHODAG_CostumeColorId = colId;

							if(db != null)
							{
								if(d.DIPKCALNIII_DivaId == 0)
								{
									d.BEEAIAAJOHD_CostumeId = 0;
									d.AFNIOJHODAG_CostumeColorId = 0;
								}
								else
								{
									if(!db.MFPNGNMFEAL_Costume.OEMKAFGPOCE_IsCostumeAvaiable(d.BEEAIAAJOHD_CostumeId, d.DIPKCALNIII_DivaId))
									{
										d.BEEAIAAJOHD_CostumeId = 0;
										d.AFNIOJHODAG_CostumeColorId = 0;
									}
								}
							}
						}
					}
				}
			}
			DBMOBFCLFOB_Saved.ODDIHGPONFL_Copy(AHBBMJANGHE_Units[0], false);
			KFKDMBPNLJK_BlockInvalid = notValid;
			return true;
		}
		return false;
	}

	// // RVA: 0x11916EC Offset: 0x11916EC VA: 0x11916EC Slot: 7
	public override void BMGGKONLFIC_Copy(KLFDBFMNLBL_ServerSaveBlock GPBJHKLFCEP)
	{
		FKNOCGCODBK_Unit u = GPBJHKLFCEP as FKNOCGCODBK_Unit;
		for(int i = 0; i < AHBBMJANGHE_Units.Count; i++)
		{
			AHBBMJANGHE_Units[i].ODDIHGPONFL_Copy(u.AHBBMJANGHE_Units[i], false);
		}
	}

	// // RVA: 0x11918C4 Offset: 0x11918C4 VA: 0x11918C4 Slot: 8
	public override bool AGBOGBEOFME(KLFDBFMNLBL_ServerSaveBlock GPBJHKLFCEP)
	{
		FKNOCGCODBK_Unit other = GPBJHKLFCEP as FKNOCGCODBK_Unit;
		if(AHBBMJANGHE_Units.Count != other.AHBBMJANGHE_Units.Count)
			return false;
		for(int i = 0; i < AHBBMJANGHE_Units.Count; i++)
		{
			if(!AHBBMJANGHE_Units[i].AGBOGBEOFME(other.AHBBMJANGHE_Units[i]))
				return false;
		}
		return true;
	}

	// // RVA: 0x1191B20 Offset: 0x1191B20 VA: 0x1191B20 Slot: 10
	//public override void AGHKODFKOJI(BHBONAHFKHD JBBHNIACMFJ, KLFDBFMNLBL_ServerSaveBlock _GJLFANGDGCL_Target, long _MCKEOKFMLAH_SaveId);
}
