
using XeApp.Game.Common;

[System.Obsolete("Use HPODBOHGGDH_SkillInfo", true)]
public struct HPODBOHGGDH { }
public struct HPODBOHGGDH_SkillInfo
{
	public int ENMAEBJGEKL_SkillId; // 0x0
	public int CNLIAMIIJID_AbilityLevel; // 0x4
	public SeriesAttr.Type AIHCEGFANAM_SerieAttr; // 0x8

	// RVA: 0x7FC2D0 Offset: 0x7FC2D0 VA: 0x7FC2D0
	public void EDEDFDDIOKO_Set(int PPFNGGCBJKC_Id, int ANAJIAENLNB_Level, SeriesAttr.Type CPKMLLNADLJ_Serie)
	{
		ENMAEBJGEKL_SkillId = PPFNGGCBJKC_Id;
		CNLIAMIIJID_AbilityLevel = ANAJIAENLNB_Level;
		AIHCEGFANAM_SerieAttr = CPKMLLNADLJ_Serie;
	}

	// RVA: 0x7FC2DC Offset: 0x7FC2DC VA: 0x7FC2DC
	public void JCHLONCMPAJ_Reset()
	{
		ENMAEBJGEKL_SkillId = 0;
		CNLIAMIIJID_AbilityLevel = 0;
		AIHCEGFANAM_SerieAttr = 0;
	}
}
