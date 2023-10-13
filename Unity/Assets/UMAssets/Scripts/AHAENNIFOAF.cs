
using System.Text;
using XeSys;

public static class AHAENNIFOAF
{
    public enum IAOPMEAIHLH
    {
        IDGJGMNNJEF = 0,
        JBMJEOBODHH = 1,
        ANLJMCJAMFJ = 2,
        BJNAMAANNMB_3 = 3,
        AEFCOHJBLPO = 4,
        HJNNKCMLGFL_M1 = -1,
    }

	public const int BDAOPCMONCO = 4;
	private static string[] AMEJJEEKKLD = new string[3]
    {
        "{0}_{1}_main",
        "{0}_{1}_blog",
        "{0}_{1}_memo"
    }; // 0x0

	// // RVA: 0x15C510C Offset: 0x15C510C VA: 0x15C510C
	// public static void PAMKDBAMMIE(StringBuilder KOHNLDKIKPC, int EKANGPODCEP, int AIBFGKBACCB, NKOBMDPHNGP.FLHJEJGJJGE KLMCILEDMEL) { }

	// // RVA: 0x15C5230 Offset: 0x15C5230 VA: 0x15C5230
	public static void BCJOMHAIGGJ(StringBuilder KOHNLDKIKPC, int MLPEHNBNOGD)
	{
		KOHNLDKIKPC.SetFormat("{0}_deco", MLPEHNBNOGD);
	}

	// // RVA: 0x15C52C4 Offset: 0x15C52C4 VA: 0x15C52C4
	public static void DNEIBFNPNIA(StringBuilder KOHNLDKIKPC, int EKANGPODCEP, int AIBFGKBACCB)
    {
        KOHNLDKIKPC.SetFormat("{0}_{1}_cm", EKANGPODCEP, AIBFGKBACCB);
    }

	// // RVA: 0x15C5378 Offset: 0x15C5378 VA: 0x15C5378
	public static void OIEHNLEPEBG(StringBuilder KOHNLDKIKPC, int EKANGPODCEP, int AIBFGKBACCB, int IBAKPKKEDJM, int BAOFEFFADPD)
    {
        object o = new object[4]
        {
            EKANGPODCEP,
            AIBFGKBACCB,
            IBAKPKKEDJM,
            BAOFEFFADPD
        };
        KOHNLDKIKPC.SetFormat("{0}_{1}_cm_{2:D2}{3:D2}", o);
    }

	// // RVA: 0x15C55E8 Offset: 0x15C55E8 VA: 0x15C55E8
	public static void JHJAMPNMCFA(StringBuilder KOHNLDKIKPC, int CMEJFJFOIIJ)
    {
        KOHNLDKIKPC.SetFormat("{0:D2}", CMEJFJFOIIJ);
    }

	// // RVA: 0x15C567C Offset: 0x15C567C VA: 0x15C567C
	// private static void KBIOJNKNKAE(string BDJEICCDKHB, ref int DNJLJMKKDNA, ref int MEBHCFJCKFE) { }

	// // RVA: 0x15C579C Offset: 0x15C579C VA: 0x15C579C
	// public static void IANGEPFFHHM(string BDJEICCDKHB, ref string JECLCENDGIH, ref int GFOIDCMEHGL, ref int DNJLJMKKDNA, ref int MEBHCFJCKFE) { }
}
