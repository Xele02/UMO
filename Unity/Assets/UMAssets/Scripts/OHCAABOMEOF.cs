
public class OHCAABOMEOF
{
    public enum KGOGMKMBCPP_EventType
    {
        HJNNKCMLGFL = 0,
        AOPKACCDKPA_EventCollection = 1,
        MKKOHBGHADL = 2,
        PFKOKHODEGL_EventBattle = 3,
        KEILBOLBDHN = 4,
        ENMHPBGOOII = 5,
        NKDOEBONGNI_EventQuest = 6,
        ENPJADLIFAB = 7,
        OCCGDMDBCHK_EventGacha = 8,
        DMPMKBCPHMA = 9,
        DAMDPLEBNCB = 10,
        CADKONMJEDA_EventRaid = 11,
        DIDJLIPNCKO = 12,
        MCGPGMGEPHG_EventRaidLobby = 13,
        BNECMLPHAGJ_EventGoDiva = 14,
    }

	public const int NKMJHIAPPFL = 1000;

	// // RVA: 0x1DDFF1C Offset: 0x1DDFF1C VA: 0x1DDFF1C
	public static int LDGFHMMAFOC(KGOGMKMBCPP_EventType INDDJNMPONH, int PPFNGGCBJKC)
	{
		return (int)INDDJNMPONH * 1000 + PPFNGGCBJKC;
	}

	// // RVA: 0x1DDFF28 Offset: 0x1DDFF28 VA: 0x1DDFF28
	public static KGOGMKMBCPP_EventType BPJMGICFPBJ(int PGIIDPEGGPI)
    {
        int res = PGIIDPEGGPI / 1000;
        if(PGIIDPEGGPI - 2000 < 1000)
            res =  (int)KGOGMKMBCPP_EventType.NKDOEBONGNI_EventQuest;

        return (KGOGMKMBCPP_EventType)res;
    }
}
