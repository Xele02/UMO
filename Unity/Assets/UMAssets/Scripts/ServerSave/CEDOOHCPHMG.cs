
using System.Collections.Generic;

[System.Obsolete("Use CEDOOHCPHMG_UnitGoDiva", true)]
public class CEDOOHCPHMG { }
public class CEDOOHCPHMG_UnitGoDiva : KLFDBFMNLBL_ServerSaveBlock
{
	private const int ECFEMKGFDCE = 2;
	private List<MPBEHHIAGOI> GFPFBJDPHLJ_UnitsByDiva; // 0x24
	public List<CIFHILOJJFC> PKMMBKHODDM_Saved = new List<CIFHILOJJFC>(); // 0x28

	public override bool DMICHEJIAJL { get { return true; } } // 0x12B4DD8 NFKFOODCJJB

	// // RVA: 0x12B2A3C Offset: 0x12B2A3C VA: 0x12B2A3C
	public CIFHILOJJFC ALDOJAEAMCJ(int _AHHJLDLAPAN_DivaId, int _PPFNGGCBJKC_id)
	{
		for(int i = 0; i < GFPFBJDPHLJ_UnitsByDiva.Count; i++)
		{
			if(GFPFBJDPHLJ_UnitsByDiva[i].AHHJLDLAPAN_DivaId == _AHHJLDLAPAN_DivaId)
			{
				return GFPFBJDPHLJ_UnitsByDiva[i].GCINIJEMHFK(_PPFNGGCBJKC_id);
			}
		}
		return null;
	}

	// // RVA: 0x12B2B88 Offset: 0x12B2B88 VA: 0x12B2B88
	public CIFHILOJJFC IGKLKPIEEEH(int _AHHJLDLAPAN_DivaId)
	{
		return ALDOJAEAMCJ(_AHHJLDLAPAN_DivaId, 0);
	}

	// // RVA: 0x12B2B90 Offset: 0x12B2B90 VA: 0x12B2B90
	public CEDOOHCPHMG_UnitGoDiva()
	{
		GFPFBJDPHLJ_UnitsByDiva = new List<MPBEHHIAGOI>(1);
		KMBPACJNEOF_Reset();
	}

	// // RVA: 0x12B2C68 Offset: 0x12B2C68 VA: 0x12B2C68 Slot: 4
	public override void KMBPACJNEOF_Reset()
	{
		GFPFBJDPHLJ_UnitsByDiva.Clear();
		PKMMBKHODDM_Saved.Clear();
		for(int i = 0; i < 10; i++)
		{
			MPBEHHIAGOI data = new MPBEHHIAGOI(i + 1);
			GFPFBJDPHLJ_UnitsByDiva.Add(data);
			CIFHILOJJFC data2 = new CIFHILOJJFC();
			CIFHILOJJFC c = ALDOJAEAMCJ(i + 1, 0);
			data2.ODDIHGPONFL_Copy(c, false);
			PKMMBKHODDM_Saved.Add(data2);
		}
	}

	// // RVA: 0x12B2E08 Offset: 0x12B2E08 VA: 0x12B2E08 Slot: 5
	public override void OKJPIBHMKMJ(EDOHBJAPLPF_JsonData OILEIIEIBHP, long _MCKEOKFMLAH_SaveId)
	{
		EDOHBJAPLPF_JsonData data = new EDOHBJAPLPF_JsonData();
		data.LAJDIPCJCPO_SetJsonType(JFBMDLGBPEN_JsonType.BDHGEFMCJDF_Array);
		for(int i = 0; i < GFPFBJDPHLJ_UnitsByDiva.Count; i++)
		{
			data.Add(GFPFBJDPHLJ_UnitsByDiva[i].NOJCMGAFAAC_ToJsonData());
		}
		if(!EMBGIDLFKGM)
		{
			EDOHBJAPLPF_JsonData data2 = new EDOHBJAPLPF_JsonData();
			data2[AFEHLCGHAEE_Strings.KAKFEGGEKLB_save_id] = _MCKEOKFMLAH_SaveId;
			data2[JIKKNHIAEKG_BlockName] = data;
			data2[AFEHLCGHAEE_Strings.AGPKGMFOJHC_rev] = 2;
			data = data2;
		}
		else
		{
			OILEIIEIBHP = OILEIIEIBHP[AFEHLCGHAEE_Strings.JCIBKDHKNFH_alldata];
		}
		OILEIIEIBHP[JIKKNHIAEKG_BlockName] = data;
	}

	// // RVA: 0x12B3180 Offset: 0x12B3180 VA: 0x12B3180 Slot: 6
	public override bool IIEMACPEEBJ_Deserialize(EDOHBJAPLPF_JsonData OILEIIEIBHP)
	{
		bool blockMissing = false;
		bool notValid = false;
		EDOHBJAPLPF_JsonData block = LGPBAKLCFHI_FindAndCheckBlock(OILEIIEIBHP, ref blockMissing, ref notValid, 2);
		if(!blockMissing)
		{
			if(block == null || !block.EPNGJLOKGIF_IsArray)
			{
				notValid = true;
			}
			else
			{
				if (block.HNBFOAJIIAL_Count != 6)
					notValid = true;
				OKGLGHCBCJP_Database db = null;
				if(IMMAOANGPNK.HHCJCDFCLOB.LNAHEIEIBOI_Initialized)
				{
					db = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database;
				}
				PKMMBKHODDM_Saved.Clear();
				for(int i = 0; i < block.HNBFOAJIIAL_Count; i++)
				{
					MPBEHHIAGOI data = GFPFBJDPHLJ_UnitsByDiva[i];
					data.AHHJLDLAPAN_DivaId = CJAENOMGPDA_ReadInt(block[i], AFEHLCGHAEE_Strings.DIPKCALNIII_DivaId, 1, ref notValid);
					EDOHBJAPLPF_JsonData array = block[i][AFEHLCGHAEE_Strings.MEFHDDNABLM_unit];
					for (int j = 0; j < array.HNBFOAJIIAL_Count; j++)
					{
						CIFHILOJJFC MEFHDDNABLM_unit = ALDOJAEAMCJ(i + 1, j);
						if(MEFHDDNABLM_unit != null)
						{
							MEFHDDNABLM_unit.FODKKJIDDKN_VfId = CJAENOMGPDA_ReadInt(array[j], AFEHLCGHAEE_Strings.FODKKJIDDKN_VfId, 1, ref notValid);
							if(db != null)
							{
								if(!db.PEOALFEGNDH_Valkyrie.PILGJJCABME_IsValkyrieAvaiable(MEFHDDNABLM_unit.FODKKJIDDKN_VfId))
								{
									MEFHDDNABLM_unit.FODKKJIDDKN_VfId = 1;
								}
							}
							MEFHDDNABLM_unit.OPFGFINHFCE_name = CEDHHAGBIBA.KJFAGPBALNO(FGCNMLBACGO_ReadString(array[j], AFEHLCGHAEE_Strings.OPFGFINHFCE_name, CIFHILOJJFC.CBELJGBFLGA, ref notValid));
							if(array[j].BBAJPINMOEP_Contains(AFEHLCGHAEE_Strings.FDBOPFEOENF_Diva))
							{
								EDOHBJAPLPF_JsonData array2 = array[j][AFEHLCGHAEE_Strings.FDBOPFEOENF_Diva];
								for(int k = 0; k < array2.HNBFOAJIIAL_Count; k++)
								{
									AMCGONHBGGF a = MEFHDDNABLM_unit.FDBOPFEOENF_Diva[k];
									a.DIPKCALNIII_DivaId = CJAENOMGPDA_ReadInt(array2[k], AFEHLCGHAEE_Strings.PPFNGGCBJKC_id, 0, ref notValid);
									a.BEEAIAAJOHD_CostumeId = CJAENOMGPDA_ReadInt(array2[k], AFEHLCGHAEE_Strings.ODNOJKHHEOP_c_id, 0, ref notValid);
									a.AFNIOJHODAG_CostumeColorId = CJAENOMGPDA_ReadInt(array2[k], "c_col", 0, ref notValid);
									IBCGPBOGOGP_ReadIntArray(array2[k], AFEHLCGHAEE_Strings.EBDNICPAFLB_SSlot, 0, 3, (int _OIPCCBHIKIA_index, int _JBGEEPFKIGG_Value) =>
									{
										//0x12B4DE0
										a.EBDNICPAFLB_SSlot[_OIPCCBHIKIA_index] = _JBGEEPFKIGG_Value;
									}, ref notValid);
									if(db != null)
									{
										for(int l = 0; l < 3; l++)
										{
											if(!db.ECNHDEHADGL_Scene.FGNJBMPDBLO_IsSceneValid(a.EBDNICPAFLB_SSlot[l]))
											{
												a.EBDNICPAFLB_SSlot[l] = 0;
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
											if(!db.MFPNGNMFEAL_Costume.OEMKAFGPOCE_IsCostumeAvaiable(a.BEEAIAAJOHD_CostumeId, a.DIPKCALNIII_DivaId))
											{
												a.BEEAIAAJOHD_CostumeId = 0;
												a.AFNIOJHODAG_CostumeColorId = 0;
											}
										}
									}
								}
							}
						}
					}
					CIFHILOJJFC c = new CIFHILOJJFC();
					c.ODDIHGPONFL_Copy(ALDOJAEAMCJ(i + 1, 0), false);
					PKMMBKHODDM_Saved.Add(c);
				}
			}
			KFKDMBPNLJK_BlockInvalid = notValid;
			return true;
		}
		return false;
	}

	// // RVA: 0x12B4594 Offset: 0x12B4594 VA: 0x12B4594 Slot: 7
	public override void BMGGKONLFIC_Copy(KLFDBFMNLBL_ServerSaveBlock GPBJHKLFCEP)
	{
		CEDOOHCPHMG_UnitGoDiva u = GPBJHKLFCEP as CEDOOHCPHMG_UnitGoDiva;
		for(int i = 0; i < GFPFBJDPHLJ_UnitsByDiva.Count; i++)
		{
			GFPFBJDPHLJ_UnitsByDiva[i].ODDIHGPONFL_Copy(u.GFPFBJDPHLJ_UnitsByDiva[i]);
		}
	}

	// // RVA: 0x12B4768 Offset: 0x12B4768 VA: 0x12B4768 Slot: 8
	public override bool AGBOGBEOFME(KLFDBFMNLBL_ServerSaveBlock GPBJHKLFCEP)
	{
		CEDOOHCPHMG_UnitGoDiva other = GPBJHKLFCEP as CEDOOHCPHMG_UnitGoDiva;
		if (GFPFBJDPHLJ_UnitsByDiva.Count != other.GFPFBJDPHLJ_UnitsByDiva.Count)
			return false;
		for(int i = 0; i < GFPFBJDPHLJ_UnitsByDiva.Count; i++)
		{
			if (!GFPFBJDPHLJ_UnitsByDiva[i].AGBOGBEOFME(other.GFPFBJDPHLJ_UnitsByDiva[i]))
				return false;
		}
		return true;
	}

	// // RVA: 0x12B49C4 Offset: 0x12B49C4 VA: 0x12B49C4 Slot: 10
	//public override void AGHKODFKOJI(BHBONAHFKHD JBBHNIACMFJ, KLFDBFMNLBL_ServerSaveBlock _GJLFANGDGCL_Target, long _MCKEOKFMLAH_SaveId);
}

public class MPBEHHIAGOI
{
	public int AHHJLDLAPAN_DivaId; // 0x8
	private List<CIFHILOJJFC> AHBBMJANGHE_Units = new List<CIFHILOJJFC>(6); // 0xC

	public CIFHILOJJFC JKNGLJNEEPO_MainUnit { get { return AHBBMJANGHE_Units[0]; } } //0x17BB12C FJDDNKGHPHN

	//// RVA: 0x17BB0AC Offset: 0x17BB0AC VA: 0x17BB0AC
	public CIFHILOJJFC GCINIJEMHFK(int _PPFNGGCBJKC_id)
	{
		return AHBBMJANGHE_Units[_PPFNGGCBJKC_id];
	}

	//// RVA: 0x17BB1A8 Offset: 0x17BB1A8 VA: 0x17BB1A8
	public MPBEHHIAGOI(int _AHHJLDLAPAN_DivaId)
	{
		KMBPACJNEOF_Reset(_AHHJLDLAPAN_DivaId);
	}

	//// RVA: 0x17BB248 Offset: 0x17BB248 VA: 0x17BB248
	public void KMBPACJNEOF_Reset(int _AHHJLDLAPAN_DivaId)
	{
		this.AHHJLDLAPAN_DivaId = _AHHJLDLAPAN_DivaId;
		AHBBMJANGHE_Units.Clear();
		for(int i = 0; i < 6; i++)
		{
			CIFHILOJJFC data = new CIFHILOJJFC();
			data.GIDKKHFHALL_unit_id = i;
			data.OPFGFINHFCE_name = CIFHILOJJFC.CBELJGBFLGA;
			AHBBMJANGHE_Units.Add(data);
		}
		FBFHJCNNPAK_InitMainForDiva(_AHHJLDLAPAN_DivaId);
	}

	//// RVA: 0x17BB3A4 Offset: 0x17BB3A4 VA: 0x17BB3A4
	public void FBFHJCNNPAK_InitMainForDiva(int _AHHJLDLAPAN_DivaId)
	{
		CIFHILOJJFC data = JKNGLJNEEPO_MainUnit;
		data.FODKKJIDDKN_VfId = 1;
		data.OPFGFINHFCE_name = CIFHILOJJFC.CBELJGBFLGA;
		data.GCCNMFHELCB_Form = 0;
		for(int i = 0; i < data.FDBOPFEOENF_Diva.Count; i++)
		{
			data.FDBOPFEOENF_Diva[i].DIPKCALNIII_DivaId = _AHHJLDLAPAN_DivaId;
			data.FDBOPFEOENF_Diva[i].BEEAIAAJOHD_CostumeId = 0;
			data.FDBOPFEOENF_Diva[i].AFNIOJHODAG_CostumeColorId = 0;
			for(int j = 0; j < data.FDBOPFEOENF_Diva[i].EBDNICPAFLB_SSlot.Length; j++)
			{
				data.FDBOPFEOENF_Diva[i].EBDNICPAFLB_SSlot[j] = 0;
			}
		}
	}

	//// RVA: 0x17BB6C0 Offset: 0x17BB6C0 VA: 0x17BB6C0
	public EDOHBJAPLPF_JsonData NOJCMGAFAAC_ToJsonData()
	{
		EDOHBJAPLPF_JsonData data = new EDOHBJAPLPF_JsonData();
		{
			EDOHBJAPLPF_JsonData data2 = new EDOHBJAPLPF_JsonData();
			data2.LAJDIPCJCPO_SetJsonType(JFBMDLGBPEN_JsonType.BDHGEFMCJDF_Array);
			for(int i = 0; i < AHBBMJANGHE_Units.Count; i++)
			{
				EDOHBJAPLPF_JsonData data3 = new EDOHBJAPLPF_JsonData();
				data3[AFEHLCGHAEE_Strings.GIDKKHFHALL_unit_id] = AHBBMJANGHE_Units[i].GIDKKHFHALL_unit_id;
				data3[AFEHLCGHAEE_Strings.FODKKJIDDKN_VfId] = AHBBMJANGHE_Units[i].FODKKJIDDKN_VfId;
				data3[AFEHLCGHAEE_Strings.OPFGFINHFCE_name] = AHBBMJANGHE_Units[i].OPFGFINHFCE_name;
				EDOHBJAPLPF_JsonData data4 = new EDOHBJAPLPF_JsonData();
				data4.LAJDIPCJCPO_SetJsonType(JFBMDLGBPEN_JsonType.BDHGEFMCJDF_Array);
				for(int j = 0; j < AHBBMJANGHE_Units[i].FDBOPFEOENF_Diva.Count; j++)
				{
					data4.Add(AHBBMJANGHE_Units[i].FDBOPFEOENF_Diva[j].NOJCMGAFAAC_ToJsonData());
				}
				data3[AFEHLCGHAEE_Strings.FDBOPFEOENF_Diva] = data4;
				data2.Add(data3);
			}
			data[AFEHLCGHAEE_Strings.MEFHDDNABLM_unit] = data2;
		}
		data[AFEHLCGHAEE_Strings.DIPKCALNIII_DivaId] = AHHJLDLAPAN_DivaId;
		return data;
	}

	//// RVA: 0x17BBC34 Offset: 0x17BBC34 VA: 0x17BBC34
	public bool AGBOGBEOFME(MPBEHHIAGOI GPBJHKLFCEP)
	{
		if (AHBBMJANGHE_Units.Count != GPBJHKLFCEP.AHBBMJANGHE_Units.Count)
			return false;
		for(int i = 0; i < AHBBMJANGHE_Units.Count; i++)
		{
			if (!AHBBMJANGHE_Units[i].AGBOGBEOFME(GPBJHKLFCEP.AHBBMJANGHE_Units[i]))
				return false;
		}
		return true;
	}

	//// RVA: 0x17BBDF8 Offset: 0x17BBDF8 VA: 0x17BBDF8
	public void ODDIHGPONFL_Copy(MPBEHHIAGOI GPBJHKLFCEP)
	{
		for(int i = 0; i < AHBBMJANGHE_Units.Count; i++)
		{
			AHBBMJANGHE_Units[i].ODDIHGPONFL_Copy(GPBJHKLFCEP.AHBBMJANGHE_Units[i], false);
		}
	}

	//// RVA: 0x17BBF34 Offset: 0x17BBF34 VA: 0x17BBF34
	//public void AGHKODFKOJI(BHBONAHFKHD JBBHNIACMFJ, string JIKKNHIAEKG, string MJBACHKCIHA, int _OIPCCBHIKIA_index, MPBEHHIAGOI _OHMCIEMIKCE_t, bool EFOEPDLNLJG) { }
}
