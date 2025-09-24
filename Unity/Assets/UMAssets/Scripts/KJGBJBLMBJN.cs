
public class KJGBJBLMBJN
{
	public BLHNHKMMPAD HBODCMLFDOB_result = new BLHNHKMMPAD(); // 0x8
	public string OPFGFINHFCE_name; // 0xC
	public int BHCIFFILAKJ_Strength; // 0x10
	public int PCPKGJIMLGO_Crypted; // 0x14

	public int PBJLLAOJMAK_PId { get { return PCPKGJIMLGO_Crypted ^ 0x749f717e; } set { PCPKGJIMLGO_Crypted = value ^ 0x749f717e; } } //0x1A02F00 FOAOPKGHJGM 0x1A02F14 JGEILGLALBP

	// RVA: 0x1A02F28 Offset: 0x1A02F28 VA: 0x1A02F28
	public void LHPDDGIJKNB_Reset()
    {
        HBODCMLFDOB_result.LHPDDGIJKNB_Reset();
        OPFGFINHFCE_name = "";
        BHCIFFILAKJ_Strength = 0;
        PBJLLAOJMAK_PId = 0;
    }

	// // RVA: 0x1A02FC4 Offset: 0x1A02FC4 VA: 0x1A02FC4
	public bool AGBOGBEOFME(KJGBJBLMBJN OIKJFMGEICL)
	{
		if(!HBODCMLFDOB_result.AGBOGBEOFME(OIKJFMGEICL.HBODCMLFDOB_result))
			return false;
		if(OPFGFINHFCE_name != OIKJFMGEICL.OPFGFINHFCE_name)
			return false;
		if(PCPKGJIMLGO_Crypted != OIKJFMGEICL.PCPKGJIMLGO_Crypted)
			return false;
		if(BHCIFFILAKJ_Strength != OIKJFMGEICL.BHCIFFILAKJ_Strength)
			return false;
		return true;
	}

	// // RVA: 0x1A03064 Offset: 0x1A03064 VA: 0x1A03064
	public void ODDIHGPONFL_Copy(KJGBJBLMBJN OIKJFMGEICL)
	{
		OPFGFINHFCE_name = OIKJFMGEICL.OPFGFINHFCE_name;
		HBODCMLFDOB_result.ODDIHGPONFL_Copy(OIKJFMGEICL.HBODCMLFDOB_result);
		PCPKGJIMLGO_Crypted = OIKJFMGEICL.PCPKGJIMLGO_Crypted;
		BHCIFFILAKJ_Strength = OIKJFMGEICL.BHCIFFILAKJ_Strength;
	}

	// // RVA: 0x1A030E8 Offset: 0x1A030E8 VA: 0x1A030E8
	public EDOHBJAPLPF_JsonData OKJPIBHMKMJ()
	{
		EDOHBJAPLPF_JsonData res = HBODCMLFDOB_result.NOJCMGAFAAC_ToJsonData();
		res["pid"] = PBJLLAOJMAK_PId;
		res["name"] = OPFGFINHFCE_name;
		res["strg"] = BHCIFFILAKJ_Strength;
		return res;
	}
}
