
using XeApp.Game;

public class JKHEOEEPBMJ
{
	public static int DGGEAHIKPBB = 4; // 0x0

	// // RVA: 0x135F8A8 Offset: 0x135F8A8 VA: 0x135F8A8
	public static void NDFFOBHACPE_SetHomeSceneId(int BCCHOBPJJKE, int NCAFLPPKLPK)
	{
		CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave.KCCLEHLLOFG_Common.GPHPNEGGGBG_HomeSceneId = BCCHOBPJJKE;
		CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave.KCCLEHLLOFG_Common.MDKELFPNCDB_HomeSceneEvolveId = NCAFLPPKLPK;
	}

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
	public static bool KIIBKADPJAF_FillSceneEvoleInfo(out int BCCHOBPJJKE_SceneId, out int FJOLNJLLJEJ_SceneEvolveId)
	{
		BCCHOBPJJKE_SceneId = -1;
		FJOLNJLLJEJ_SceneEvolveId = -1;
		DFKGGBMFFGB_PlayerInfo pData = GameManager.Instance.ViewPlayerData;
		int homeSceneId = AGHGOOBIGDI_GetHomeSceneId();
		if(homeSceneId > 0)
		{
			GCIJNCFDNON_SceneInfo scene = pData.OPIBAPEGCLA_Scenes[homeSceneId - 1];
			if(scene != null)
			{
				if(DGGEAHIKPBB <= scene.JKGFBFPIMGA_Rarity)
				{
					BCCHOBPJJKE_SceneId = scene.BCCHOBPJJKE_SceneId;
					FJOLNJLLJEJ_SceneEvolveId = HDLMKFFMGEP_GetHomeSceneEvolveId();
					return true;
				}
			}
		}
		return false;
	}

	// // RVA: 0x135FF10 Offset: 0x135FF10 VA: 0x135FF10
	public static bool HDOOGKNLOGI_IsHomeSceneEvolve()
	{
		return HDLMKFFMGEP_GetHomeSceneEvolveId() != 0;
	}

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
