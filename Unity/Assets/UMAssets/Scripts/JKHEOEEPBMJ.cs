
using XeApp.Game;

public class JKHEOEEPBMJ
{
	public static int DGGEAHIKPBB = 4; // 0x0

	// // RVA: 0x135F8A8 Offset: 0x135F8A8 VA: 0x135F8A8
	// public static void NDFFOBHACPE(int BCCHOBPJJKE, int NCAFLPPKLPK) { }

	// // RVA: 0x135F9BC Offset: 0x135F9BC VA: 0x135F9BC
	public static int AGHGOOBIGDI_GetHomeSceneId()
	{
		return CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave.KCCLEHLLOFG_Common.GPHPNEGGGBG_HomeSceneId;
	}

	// // RVA: 0x135FA98 Offset: 0x135FA98 VA: 0x135FA98
	public static int HDLMKFFMGEP_GetHomeSceneEvolveId()
	{
		return CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave.KCCLEHLLOFG_Common.MDKELFPNCDB_HomeSceneEvolveId;
	}

	// // RVA: 0x135FB74 Offset: 0x135FB74 VA: 0x135FB74
	// public static void MLPMCLHGDFG(bool GOELFAECHGI) { }

	// // RVA: 0x135FC58 Offset: 0x135FC58 VA: 0x135FC58
	public static bool NMKPJJLAONP_GetShowHomeDiva()
    {
        return CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave.KCCLEHLLOFG_Common.HLLEEFLLFPD_HomeShowDiva == 1;
    }

	// // RVA: 0x135FD3C Offset: 0x135FD3C VA: 0x135FD3C
	// public static bool KIIBKADPJAF(out int BCCHOBPJJKE, out int FJOLNJLLJEJ) { }

	// // RVA: 0x135FF10 Offset: 0x135FF10 VA: 0x135FF10
	// public static bool HDOOGKNLOGI() { }

	// // RVA: 0x135FF90 Offset: 0x135FF90 VA: 0x135FF90
	public static GCIJNCFDNON_SceneInfo AIEDAEPONAB_GetHomeSceneInfo(DFKGGBMFFGB_PlayerInfo AHEFHIMGIBI)
	{
		int id = AGHGOOBIGDI_GetHomeSceneId();
		if(AHEFHIMGIBI == null)
		{
			AHEFHIMGIBI = GameManager.Instance.ViewPlayerData;
		}
		if(id < 1)
			return null;
		return AHEFHIMGIBI.OPIBAPEGCLA_Scenes[id - 1];
	}

	// // RVA: 0x13600C0 Offset: 0x13600C0 VA: 0x13600C0
	// public static bool AMIDJBGLJPG() { }
}
