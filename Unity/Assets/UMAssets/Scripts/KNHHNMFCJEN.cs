
using XeApp;

internal class KNHHNMFCJEN
{
	private const int OGIFJCLDDPO = 86400;
	private const int CNOJKFMMEDA = 259200;
	private const int KKMICHCLNPM = 518400;
	private const int MLOHEDOGPDI = 777600;
	private const int NKKPDKDPADB = 1;
	private const int GIOPLOCMAJA = 2;

	// // RVA: 0x11213B0 Offset: 0x11213B0 VA: 0x11213B0
	private static bool EALAEJFNMGK()
    {
        int ver = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.GDEKCOOBLMA_System.LPJLEHAJADA("review_ver", 1);
        if(CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave.KCCLEHLLOFG_Common.JOKHEHFGDOP_RvStep == 0)
        {
            int review_player_level = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.GDEKCOOBLMA_System.LPJLEHAJADA("review_player_level", 8);
            if(CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave.KCCLEHLLOFG_Common.KIECDDFNCAN_Level < review_player_level)
                return false;
        }
        else
        {
            if(CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave.KCCLEHLLOFG_Common.JOKHEHFGDOP_RvStep == ver)
                return false;
            if(CIOECGOMILE.HHCJCDFCLOB.MNJHBCIIHED_PrevServerData.KCCLEHLLOFG_Common.KIECDDFNCAN_Level == CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave.KCCLEHLLOFG_Common.KIECDDFNCAN_Level)
                return false;
        }
        int review_combo_rank = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.GDEKCOOBLMA_System.LPJLEHAJADA("review_combo_rank", 1);
        int review_score_rank = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.GDEKCOOBLMA_System.LPJLEHAJADA("review_score_rank", 3);
        if(JGEOBNENMAH.HHCJCDFCLOB.CODDMAKLBDO_LastComboRank < review_combo_rank)
        {
            if(review_score_rank <= JGEOBNENMAH.HHCJCDFCLOB.PENICOGGNLF)
                return true;
            return false;
        }
        return true;
    }

	// RVA: 0x11219E8 Offset: 0x11219E8 VA: 0x11219E8
	public static bool AIGMIEKPPAD()
    {
        if(!AppEnv.IsPresentation())
        {
            if(!AppEnv.IsCBT())
            {
                if(CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave.JHFIPCIHJNL_Base.IJHBIMNKOMC_TutorialEnd != 0)
                {
                    if((IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.GDEKCOOBLMA_System.LPJLEHAJADA("review_show", 0) & 1) != 0)
                    {
                        int ver = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.GDEKCOOBLMA_System.LPJLEHAJADA("review_ver", 1);
                        if(CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave.KCCLEHLLOFG_Common.JOKHEHFGDOP_RvStep != ver)
                        {
                            return EALAEJFNMGK();
                        }
                    }
                }
            }
        }
        return false;
    }

	// // RVA: 0x1121CE8 Offset: 0x1121CE8 VA: 0x1121CE8
	// public static void KIHKHADPMID() { }

	// // RVA: 0x11221C0 Offset: 0x11221C0 VA: 0x11221C0
	// public static void GPLFCIJAEEF(int LKKHOBBFHIB = 3) { }

	// // RVA: 0x11223AC Offset: 0x11223AC VA: 0x11223AC
	// public static void FEGAJAICLID(int LKKHOBBFHIB = 3) { }

	// // RVA: 0x1122598 Offset: 0x1122598 VA: 0x1122598
	// public static void CJCKOGKHEAO(int LKKHOBBFHIB = 3) { }
}
