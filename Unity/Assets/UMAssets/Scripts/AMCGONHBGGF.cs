
public class AMCGONHBGGF
{
	public int DIPKCALNIII_DivaId; // 0x8
	public int BEEAIAAJOHD_CostumeId; // 0xC
	public int AFNIOJHODAG_CostumeColorId; // 0x10
	public int[] EBDNICPAFLB_SSlot = new int[3]; // 0x14

	// // RVA: 0xCE0D98 Offset: 0xCE0D98 VA: 0xCE0D98
	public void LHPDDGIJKNB_Reset()
	{
		DIPKCALNIII_DivaId = 0;
		BEEAIAAJOHD_CostumeId = 0;
		AFNIOJHODAG_CostumeColorId = 0;
		for(int i = 0; i < EBDNICPAFLB_SSlot.Length; i++)
		{
			EBDNICPAFLB_SSlot[i] = 0;
		}
	}

	// // RVA: 0xCE0E1C Offset: 0xCE0E1C VA: 0xCE0E1C
	public void ODDIHGPONFL_Copy(AMCGONHBGGF GPBJHKLFCEP)
	{
		DIPKCALNIII_DivaId = GPBJHKLFCEP.DIPKCALNIII_DivaId;
		BEEAIAAJOHD_CostumeId = GPBJHKLFCEP.BEEAIAAJOHD_CostumeId;
		AFNIOJHODAG_CostumeColorId = GPBJHKLFCEP.AFNIOJHODAG_CostumeColorId;
		for(int i = 0; i < 3; i++)
		{
			EBDNICPAFLB_SSlot[i] = GPBJHKLFCEP.EBDNICPAFLB_SSlot[i];
		}
	}

	// // RVA: 0xCE0F1C Offset: 0xCE0F1C VA: 0xCE0F1C
	public bool AGBOGBEOFME(AMCGONHBGGF OIKJFMGEICL)
	{
		if(DIPKCALNIII_DivaId != OIKJFMGEICL.DIPKCALNIII_DivaId ||
			BEEAIAAJOHD_CostumeId != OIKJFMGEICL.BEEAIAAJOHD_CostumeId ||
			AFNIOJHODAG_CostumeColorId != OIKJFMGEICL.AFNIOJHODAG_CostumeColorId)
			return false;
		for(int i = 0; i < 3; i++)
		{
			if(EBDNICPAFLB_SSlot[i] != OIKJFMGEICL.EBDNICPAFLB_SSlot[i])
				return false;
		}
		return true;
	}

	// // RVA: 0xCE101C Offset: 0xCE101C VA: 0xCE101C
	public EDOHBJAPLPF_JsonData NOJCMGAFAAC_ToJsonData()
	{
		EDOHBJAPLPF_JsonData data = new EDOHBJAPLPF_JsonData();
		data[AFEHLCGHAEE_Strings.PPFNGGCBJKC_id] = DIPKCALNIII_DivaId;
		data[AFEHLCGHAEE_Strings.ODNOJKHHEOP_c_id] = BEEAIAAJOHD_CostumeId;
		data["c_col"] = AFNIOJHODAG_CostumeColorId;
		EDOHBJAPLPF_JsonData data2 = new EDOHBJAPLPF_JsonData();
		data2.LAJDIPCJCPO_SetJsonType(JFBMDLGBPEN_JsonType.BDHGEFMCJDF_Array);
		for(int i = 0; i < EBDNICPAFLB_SSlot.Length; i++)
		{
			data2.Add(EBDNICPAFLB_SSlot[i]);
		}
		data[AFEHLCGHAEE_Strings.EBDNICPAFLB_SSlot] = data2;
		return data;
	}
}
