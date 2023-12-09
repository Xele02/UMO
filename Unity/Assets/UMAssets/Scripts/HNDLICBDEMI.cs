
public class HNDLICBDEMI
{
	//// RVA: 0x15FADAC Offset: 0x15FADAC VA: 0x15FADAC
	public static void FMLGCFKNKIA_GetDecoPlayerLevelAndEnabled(out int OCCIIDFGNEH, out bool HGNKCCAMHAM)
	{
		OCCIIDFGNEH = 5;
		HGNKCCAMHAM = false;
		if(IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database != null)
		{
			OCCIIDFGNEH = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.GDEKCOOBLMA_System.LPJLEHAJADA("deco_player_level", OCCIIDFGNEH);
		}
		if(CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave == null)
			return;
		if(OCCIIDFGNEH > 0)
		{
			if(OCCIIDFGNEH <= CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave.KCCLEHLLOFG_Common.KIECDDFNCAN_Level)
				HGNKCCAMHAM = true;
		}
	}

	//// RVA: 0x15FAF54 Offset: 0x15FAF54 VA: 0x15FAF54
	public static bool AFGKIJMPNNN_IsDecoEnabled()
	{
		int a = 0;
		bool b = false;
		FMLGCFKNKIA_GetDecoPlayerLevelAndEnabled(out a, out b);
		return b;
	}

	//// RVA: 0x15FAF84 Offset: 0x15FAF84 VA: 0x15FAF84
	public static bool AAFGGLHPPJN()
	{
		int a;
		bool b;
		FMLGCFKNKIA_GetDecoPlayerLevelAndEnabled(out a, out b);
		return a > 0;
	}
}
