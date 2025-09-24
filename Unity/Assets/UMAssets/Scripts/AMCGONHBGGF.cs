
public class AMCGONHBGGF
{
	public int DIPKCALNIII_diva_id; // 0x8
	public int BEEAIAAJOHD_CostumeId; // 0xC
	public int AFNIOJHODAG_CostumeColorId; // 0x10
	public int[] EBDNICPAFLB_s_slot = new int[3]; // 0x14

	// // RVA: 0xCE0D98 Offset: 0xCE0D98 VA: 0xCE0D98
	public void LHPDDGIJKNB_Reset()
	{
		DIPKCALNIII_diva_id = 0;
		BEEAIAAJOHD_CostumeId = 0;
		AFNIOJHODAG_CostumeColorId = 0;
		for(int i = 0; i < EBDNICPAFLB_s_slot.Length; i++)
		{
			EBDNICPAFLB_s_slot[i] = 0;
		}
	}

	// // RVA: 0xCE0E1C Offset: 0xCE0E1C VA: 0xCE0E1C
	public void ODDIHGPONFL_Copy(AMCGONHBGGF GPBJHKLFCEP)
	{
		DIPKCALNIII_diva_id = GPBJHKLFCEP.DIPKCALNIII_diva_id;
		BEEAIAAJOHD_CostumeId = GPBJHKLFCEP.BEEAIAAJOHD_CostumeId;
		AFNIOJHODAG_CostumeColorId = GPBJHKLFCEP.AFNIOJHODAG_CostumeColorId;
		for(int i = 0; i < 3; i++)
		{
			EBDNICPAFLB_s_slot[i] = GPBJHKLFCEP.EBDNICPAFLB_s_slot[i];
		}
	}

	// // RVA: 0xCE0F1C Offset: 0xCE0F1C VA: 0xCE0F1C
	public bool AGBOGBEOFME(AMCGONHBGGF OIKJFMGEICL)
	{
		if(DIPKCALNIII_diva_id != OIKJFMGEICL.DIPKCALNIII_diva_id ||
			BEEAIAAJOHD_CostumeId != OIKJFMGEICL.BEEAIAAJOHD_CostumeId ||
			AFNIOJHODAG_CostumeColorId != OIKJFMGEICL.AFNIOJHODAG_CostumeColorId)
			return false;
		for(int i = 0; i < 3; i++)
		{
			if(EBDNICPAFLB_s_slot[i] != OIKJFMGEICL.EBDNICPAFLB_s_slot[i])
				return false;
		}
		return true;
	}

	// // RVA: 0xCE101C Offset: 0xCE101C VA: 0xCE101C
	public EDOHBJAPLPF_JsonData NOJCMGAFAAC_ToJsonData()
	{
		EDOHBJAPLPF_JsonData data = new EDOHBJAPLPF_JsonData();
		data[AFEHLCGHAEE_Strings.PPFNGGCBJKC_id] = DIPKCALNIII_diva_id;
		data[AFEHLCGHAEE_Strings.ODNOJKHHEOP_c_id] = BEEAIAAJOHD_CostumeId;
		data["c_col"] = AFNIOJHODAG_CostumeColorId;
		EDOHBJAPLPF_JsonData data2 = new EDOHBJAPLPF_JsonData();
		data2.LAJDIPCJCPO_SetJsonType(JFBMDLGBPEN_JsonType.BDHGEFMCJDF_Array);
		for(int i = 0; i < EBDNICPAFLB_s_slot.Length; i++)
		{
			data2.Add(EBDNICPAFLB_s_slot[i]);
		}
		data[AFEHLCGHAEE_Strings.EBDNICPAFLB_s_slot] = data2;
		return data;
	}
}
