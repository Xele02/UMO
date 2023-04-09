using System.Collections.Generic;

[System.Obsolete("Use FKNOCGCODBK_Unit", true)]
public class FKNOCGCODBK { }
public class FKNOCGCODBK_Unit : KLFDBFMNLBL_ServerSaveBlock
{
	private const int ECFEMKGFDCE = 3;
	private List<CIFHILOJJFC> AHBBMJANGHE; // 0x24
	public CIFHILOJJFC DBMOBFCLFOB = new CIFHILOJJFC(); // 0x28

	// public CIFHILOJJFC JKNGLJNEEPO { get; }
	public override bool DMICHEJIAJL { get { TodoLogger.Log(0, "DMICHEJIAJL"); return false; } } // 0x1191F34 NFKFOODCJJB

	// // RVA: 0x118F3A8 Offset: 0x118F3A8 VA: 0x118F3A8
	public CIFHILOJJFC GCINIJEMHFK(int PPFNGGCBJKC)
	{
		return AHBBMJANGHE[PPFNGGCBJKC];
	}

	// // RVA: 0x118F428 Offset: 0x118F428 VA: 0x118F428
	public CIFHILOJJFC FJDDNKGHPHN_GetDefault()
	{
		return AHBBMJANGHE[0];
	}

	// // RVA: 0x118F4A4 Offset: 0x118F4A4 VA: 0x118F4A4
	public FKNOCGCODBK_Unit()
	{
		AHBBMJANGHE = new List<CIFHILOJJFC>(16);
		KMBPACJNEOF();
	}

	// // RVA: 0x118F56C Offset: 0x118F56C VA: 0x118F56C Slot: 4
	public override void KMBPACJNEOF()
	{
		AHBBMJANGHE.Clear();
		for(int i = 0; i < 16; i++)
		{
			CIFHILOJJFC data = new CIFHILOJJFC();
			data.GIDKKHFHALL = i;
			data.OPFGFINHFCE_Name = CIFHILOJJFC.CBELJGBFLGA;
			AHBBMJANGHE.Add(data);
		}
	}

	// // RVA: 0x118F6B0 Offset: 0x118F6B0 VA: 0x118F6B0 Slot: 5
	public override void OKJPIBHMKMJ(EDOHBJAPLPF_JsonData OILEIIEIBHP, long MCKEOKFMLAH)
	{
		TodoLogger.Log(0, "OKJPIBHMKMJ");
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
					CIFHILOJJFC MEFHDDNABLM = AHBBMJANGHE[i];
					MEFHDDNABLM.FODKKJIDDKN_VfId = CJAENOMGPDA_ReadInt(block[i], AFEHLCGHAEE_Strings.FODKKJIDDKN_vf_id, 1, ref notValid);
					if(db != null)
					{
						if(!db.PEOALFEGNDH_Valkyrie.PILGJJCABME_IsValkyrieAvaiable(MEFHDDNABLM.FODKKJIDDKN_VfId))
						{
							MEFHDDNABLM.FODKKJIDDKN_VfId = 1;
						}
					}
					MEFHDDNABLM.OPFGFINHFCE_Name = FGCNMLBACGO_ReadString(block[i], AFEHLCGHAEE_Strings.OPFGFINHFCE_name, CIFHILOJJFC.CBELJGBFLGA, ref notValid);
					if(block[i].BBAJPINMOEP_Contains(AFEHLCGHAEE_Strings.FDBOPFEOENF_diva))
					{
						EDOHBJAPLPF_JsonData divaArray = block[i][AFEHLCGHAEE_Strings.FDBOPFEOENF_diva];
						for(int j = 0; j < divaArray.HNBFOAJIIAL_Count; j++)
						{
							int divaId = CJAENOMGPDA_ReadInt(divaArray[j], AFEHLCGHAEE_Strings.PPFNGGCBJKC_Id, 0, ref notValid);
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
							AMCGONHBGGF a = MEFHDDNABLM.FDBOPFEOENF_MainDivas[j];
							a.DIPKCALNIII_Id = divaId;
							a.BEEAIAAJOHD_CId = cosId;
							a.AFNIOJHODAG_ColId = colId;

							IBCGPBOGOGP_ReadIntArray(divaArray[j], AFEHLCGHAEE_Strings.EBDNICPAFLB_s_slot, 0, 3, (int OIPCCBHIKIA, int JBGEEPFKIGG) => {
								//0x1191F3C
								a.EBDNICPAFLB_SSlot[OIPCCBHIKIA] = JBGEEPFKIGG;
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
								if(a.DIPKCALNIII_Id == 0)
								{
									a.BEEAIAAJOHD_CId = 0;
									a.AFNIOJHODAG_ColId = 0;
								}
								else
								{
									if(!db.MFPNGNMFEAL_Costume.OEMKAFGPOCE_IsCostumeAvaiable(a.DIPKCALNIII_Id, a.BEEAIAAJOHD_CId))
									{
										a.BEEAIAAJOHD_CId = 0;
										a.AFNIOJHODAG_ColId = 0;
									}
								}
							}
						}
					}
					else
					{
						notValid = true;
					}
					if(block[i].BBAJPINMOEP_Contains("add_" + AFEHLCGHAEE_Strings.FDBOPFEOENF_diva))
					{
						EDOHBJAPLPF_JsonData divaArray = block[i]["add_" + AFEHLCGHAEE_Strings.FDBOPFEOENF_diva];
						for(int j = 0; j < divaArray.HNBFOAJIIAL_Count; j++)
						{
							int divaId = CJAENOMGPDA_ReadInt(divaArray[j], AFEHLCGHAEE_Strings.PPFNGGCBJKC_Id, 0, ref notValid);
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
							DKDMLOBCPFC d = MEFHDDNABLM.KAKGHFFOAEJ_AddDivas[j];
							d.DIPKCALNIII_Id = divaId;
							d.BEEAIAAJOHD_CosId = cosId;
							d.AFNIOJHODAG_ColId = colId;

							if(db != null)
							{
								if(d.DIPKCALNIII_Id == 0)
								{
									d.BEEAIAAJOHD_CosId = 0;
									d.AFNIOJHODAG_ColId = 0;
								}
								else
								{
									if(!db.MFPNGNMFEAL_Costume.OEMKAFGPOCE_IsCostumeAvaiable(d.BEEAIAAJOHD_CosId, d.DIPKCALNIII_Id))
									{
										d.BEEAIAAJOHD_CosId = 0;
										d.AFNIOJHODAG_ColId = 0;
									}
								}
							}
						}
					}
				}
			}
			DBMOBFCLFOB.ODDIHGPONFL_Copy(AHBBMJANGHE[0], false);
			KFKDMBPNLJK_BlockInvalid = notValid;
			return true;
		}
		return false;
	}

	// // RVA: 0x11916EC Offset: 0x11916EC VA: 0x11916EC Slot: 7
	public override void BMGGKONLFIC(KLFDBFMNLBL_ServerSaveBlock GPBJHKLFCEP)
	{
		FKNOCGCODBK_Unit u = GPBJHKLFCEP as FKNOCGCODBK_Unit;
		for(int i = 0; i < AHBBMJANGHE.Count; i++)
		{
			AHBBMJANGHE[i].ODDIHGPONFL_Copy(u.AHBBMJANGHE[i]);
		}
	}

	// // RVA: 0x11918C4 Offset: 0x11918C4 VA: 0x11918C4 Slot: 8
	public override bool AGBOGBEOFME(KLFDBFMNLBL_ServerSaveBlock GPBJHKLFCEP)
	{
		TodoLogger.Log(0, "AGBOGBEOFME");
		return true;
	}

	// // RVA: 0x1191B20 Offset: 0x1191B20 VA: 0x1191B20 Slot: 10
	public override void AGHKODFKOJI(BHBONAHFKHD JBBHNIACMFJ, KLFDBFMNLBL_ServerSaveBlock GJLFANGDGCL, long MCKEOKFMLAH)
	{
		TodoLogger.Log(0, "AGHKODFKOJI");
	}
}
