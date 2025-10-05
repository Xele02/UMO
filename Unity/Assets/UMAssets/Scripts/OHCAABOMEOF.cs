
public class OHCAABOMEOF
{
    public enum KGOGMKMBCPP_EventType
    {
        HJNNKCMLGFL_0_None = 0,
        AOPKACCDKPA_EventCollection = 1,
        MKKOHBGHADL_EventQuest_2 = 2,
        PFKOKHODEGL_EventBattle = 3,
        KEILBOLBDHN_4_Score = 4,
        ENMHPBGOOII_Week = 5,
        NKDOEBONGNI_EventMission = 6,
        ENPJADLIFAB_EventSp = 7,
        OCCGDMDBCHK_8_EventGacha = 8,
        DMPMKBCPHMA_9_PresentCampaign = 9,
        DAMDPLEBNCB_AprilFool = 10,
        CADKONMJEDA_11_EventRaid = 11,
        DIDJLIPNCKO_12_Bingo = 12,
        MCGPGMGEPHG_EventRaidLobby = 13,
        BNECMLPHAGJ_EventGoDiva = 14,
    }

	public const int NKMJHIAPPFL = 1000;

	// // RVA: 0x1DDFF1C Offset: 0x1DDFF1C VA: 0x1DDFF1C
	public static int LDGFHMMAFOC(KGOGMKMBCPP_EventType _INDDJNMPONH_type, int _PPFNGGCBJKC_id)
	{
		return (int)_INDDJNMPONH_type * 1000 + _PPFNGGCBJKC_id;
	}

	// // RVA: 0x1DDFF28 Offset: 0x1DDFF28 VA: 0x1DDFF28
	public static KGOGMKMBCPP_EventType BPJMGICFPBJ(int _PGIIDPEGGPI_EventId)
    {
        int res = _PGIIDPEGGPI_EventId / 1000;
        if(_PGIIDPEGGPI_EventId - 2000 < 1000)
            res =  (int)KGOGMKMBCPP_EventType.NKDOEBONGNI_EventMission;

        return (KGOGMKMBCPP_EventType)res;
    }
}
