
public class AMCGONHBGGF
{
	public int DIPKCALNIII_Id; // 0x8
	public int BEEAIAAJOHD_CId; // 0xC
	public int AFNIOJHODAG_ColId; // 0x10
	public int[] EBDNICPAFLB_SSlot = new int[3]; // 0x14

	// // RVA: 0xCE0D98 Offset: 0xCE0D98 VA: 0xCE0D98
	public void LHPDDGIJKNB_Reset()
	{
		DIPKCALNIII_Id = 0;
		BEEAIAAJOHD_CId = 0;
		AFNIOJHODAG_ColId = 0;
		for(int i = 0; i < EBDNICPAFLB_SSlot.Length; i++)
		{
			EBDNICPAFLB_SSlot[i] = 0;
		}
	}

	// // RVA: 0xCE0E1C Offset: 0xCE0E1C VA: 0xCE0E1C
	public void ODDIHGPONFL_Copy(AMCGONHBGGF GPBJHKLFCEP)
	{
		DIPKCALNIII_Id = GPBJHKLFCEP.DIPKCALNIII_Id;
		BEEAIAAJOHD_CId = GPBJHKLFCEP.BEEAIAAJOHD_CId;
		AFNIOJHODAG_ColId = GPBJHKLFCEP.AFNIOJHODAG_ColId;
		for(int i = 0; i < 3; i++)
		{
			EBDNICPAFLB_SSlot[i] = GPBJHKLFCEP.EBDNICPAFLB_SSlot[i];
		}
	}

	// // RVA: 0xCE0F1C Offset: 0xCE0F1C VA: 0xCE0F1C
	public bool AGBOGBEOFME(AMCGONHBGGF OIKJFMGEICL)
	{
		if(DIPKCALNIII_Id != OIKJFMGEICL.DIPKCALNIII_Id ||
			BEEAIAAJOHD_CId != OIKJFMGEICL.BEEAIAAJOHD_CId ||
			AFNIOJHODAG_ColId != OIKJFMGEICL.AFNIOJHODAG_ColId)
			return false;
		for(int i = 0; i < 3; i++)
		{
			if(EBDNICPAFLB_SSlot[i] != OIKJFMGEICL.EBDNICPAFLB_SSlot[i])
				return false;
		}
		return true;
	}

	// // RVA: 0xCE101C Offset: 0xCE101C VA: 0xCE101C
	public EDOHBJAPLPF_JsonData NOJCMGAFAAC()
	{
		EDOHBJAPLPF_JsonData data = new EDOHBJAPLPF_JsonData();
		data[AFEHLCGHAEE_Strings.PPFNGGCBJKC_Id] = DIPKCALNIII_Id;
		data[AFEHLCGHAEE_Strings.ODNOJKHHEOP_c_id] = BEEAIAAJOHD_CId;
		data["c_col"] = AFNIOJHODAG_ColId;
		EDOHBJAPLPF_JsonData data2 = new EDOHBJAPLPF_JsonData();
		data2.LAJDIPCJCPO_SetJsonType(JFBMDLGBPEN_JsonType.BDHGEFMCJDF_Array);
		for(int i = 0; i < EBDNICPAFLB_SSlot.Length; i++)
		{
			data2.Add(EBDNICPAFLB_SSlot[i]);
		}
		data[AFEHLCGHAEE_Strings.EBDNICPAFLB_s_slot] = data2;
		return data;
	}
}
