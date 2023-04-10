
public class AMCGONHBGGF
{
	public int DIPKCALNIII_Id; // 0x8
	public int BEEAIAAJOHD_CId; // 0xC
	public int AFNIOJHODAG_ColId; // 0x10
	public int[] EBDNICPAFLB_SSlot = new int[3]; // 0x14

	// // RVA: 0xCE0D98 Offset: 0xCE0D98 VA: 0xCE0D98
	// public void LHPDDGIJKNB_Reset() { }

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
	// public EDOHBJAPLPF_JsonData NOJCMGAFAAC() { }
}
