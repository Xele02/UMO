
using XeApp.Game.Common;

[System.Obsolete("Use HPODBOHGGDH_SkillInfo", true)]
public struct HPODBOHGGDH { }
public struct HPODBOHGGDH_SkillInfo
{
	public int ENMAEBJGEKL_Id; // 0x0
	public int CNLIAMIIJID_Level; // 0x4
	public SeriesAttr.Type AIHCEGFANAM_Serie; // 0x8

	// RVA: 0x7FC2D0 Offset: 0x7FC2D0 VA: 0x7FC2D0
	public void EDEDFDDIOKO_Set(int PPFNGGCBJKC_Id, int ANAJIAENLNB_Level, SeriesAttr.Type CPKMLLNADLJ_Serie)
	{
		ENMAEBJGEKL_Id = PPFNGGCBJKC_Id;
		CNLIAMIIJID_Level = ANAJIAENLNB_Level;
		AIHCEGFANAM_Serie = CPKMLLNADLJ_Serie;
	}

	// RVA: 0x7FC2DC Offset: 0x7FC2DC VA: 0x7FC2DC
	public void JCHLONCMPAJ_Reset()
	{
		ENMAEBJGEKL_Id = 0;
		CNLIAMIIJID_Level = 0;
		AIHCEGFANAM_Serie = 0;
	}
}
