
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
        OCCGDMDBCHK = 8,
        DMPMKBCPHMA = 9,
        DAMDPLEBNCB = 10,
        CADKONMJEDA_EventRaid = 11,
        DIDJLIPNCKO = 12,
        MCGPGMGEPHG = 13,
        BNECMLPHAGJ_EventGoDiva = 14,
    }

	public const int NKMJHIAPPFL = 1000;

	// // RVA: 0x1DDFF1C Offset: 0x1DDFF1C VA: 0x1DDFF1C
	// public static int LDGFHMMAFOC(OHCAABOMEOF.KGOGMKMBCPP INDDJNMPONH, int PPFNGGCBJKC) { }

	// // RVA: 0x1DDFF28 Offset: 0x1DDFF28 VA: 0x1DDFF28
	public static OHCAABOMEOF.KGOGMKMBCPP_EventType BPJMGICFPBJ(int PGIIDPEGGPI)
    {
        int res = PGIIDPEGGPI / 1000;
        if(PGIIDPEGGPI - 2000 < 1000)
            res =  (int)OHCAABOMEOF.KGOGMKMBCPP_EventType.NKDOEBONGNI_EventQuest;

        return (OHCAABOMEOF.KGOGMKMBCPP_EventType)res;
    }
}
