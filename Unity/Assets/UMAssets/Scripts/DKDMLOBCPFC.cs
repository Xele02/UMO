
public class DKDMLOBCPFC
{
	public int DIPKCALNIII_diva_id; // 0x8
	public int BEEAIAAJOHD_CostumeId; // 0xC
	public int AFNIOJHODAG_CostumeColorId; // 0x10

	// // RVA: 0x198E648 Offset: 0x198E648 VA: 0x198E648
	public void LHPDDGIJKNB_Reset()
	{
		DIPKCALNIII_diva_id = 0;
		BEEAIAAJOHD_CostumeId = 0;
		AFNIOJHODAG_CostumeColorId = 0;
	}

	// // RVA: 0x198E65C Offset: 0x198E65C VA: 0x198E65C
	public void ODDIHGPONFL_Copy(DKDMLOBCPFC GPBJHKLFCEP)
	{
		DIPKCALNIII_diva_id = GPBJHKLFCEP.DIPKCALNIII_diva_id;
		BEEAIAAJOHD_CostumeId = GPBJHKLFCEP.BEEAIAAJOHD_CostumeId;
		AFNIOJHODAG_CostumeColorId = GPBJHKLFCEP.AFNIOJHODAG_CostumeColorId;
	}

	// // RVA: 0x198E6C4 Offset: 0x198E6C4 VA: 0x198E6C4
	public bool AGBOGBEOFME(DKDMLOBCPFC OIKJFMGEICL)
	{
		if(DIPKCALNIII_diva_id != OIKJFMGEICL.DIPKCALNIII_diva_id ||
			BEEAIAAJOHD_CostumeId != OIKJFMGEICL.BEEAIAAJOHD_CostumeId ||
			AFNIOJHODAG_CostumeColorId != OIKJFMGEICL.AFNIOJHODAG_CostumeColorId)
			return false;
		return true;
	}

	// // RVA: 0x198E724 Offset: 0x198E724 VA: 0x198E724
	public EDOHBJAPLPF_JsonData NOJCMGAFAAC_ToJsonData()
	{
		EDOHBJAPLPF_JsonData data = new EDOHBJAPLPF_JsonData();
		data[AFEHLCGHAEE_Strings.PPFNGGCBJKC_id] = DIPKCALNIII_diva_id;
		data[AFEHLCGHAEE_Strings.ODNOJKHHEOP_c_id] = BEEAIAAJOHD_CostumeId;
		data["c_col"] = AFNIOJHODAG_CostumeColorId;
		return data;
	}
}
