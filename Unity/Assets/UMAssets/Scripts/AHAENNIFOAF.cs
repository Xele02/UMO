
using System.Text;
using XeSys;

public static class AHAENNIFOAF
{
    public enum IAOPMEAIHLH
    {
        IDGJGMNNJEF_0 = 0,
        JBMJEOBODHH_1 = 1,
        ANLJMCJAMFJ_2 = 2,
        BJNAMAANNMB_3 = 3,
        AEFCOHJBLPO = 4,
        HJNNKCMLGFL_M1_None = -1,
    }

	public const int BDAOPCMONCO = 4;
	private static string[] AMEJJEEKKLD = new string[3]
    {
        "{0}_{1}_main",
        "{0}_{1}_blog",
        "{0}_{1}_memo"
    }; // 0x0

	// // RVA: 0x15C510C Offset: 0x15C510C VA: 0x15C510C
	public static void PAMKDBAMMIE(StringBuilder _KOHNLDKIKPC_sb, int _EKANGPODCEP_EventId, int _AIBFGKBACCB_LobbyId, NKOBMDPHNGP_EventRaidLobby.FLHJEJGJJGE KLMCILEDMEL)
	{
		_KOHNLDKIKPC_sb.SetFormat(AMEJJEEKKLD[(int)KLMCILEDMEL], _EKANGPODCEP_EventId, _AIBFGKBACCB_LobbyId);
	}

	// // RVA: 0x15C5230 Offset: 0x15C5230 VA: 0x15C5230
	public static void BCJOMHAIGGJ(StringBuilder _KOHNLDKIKPC_sb, int _MLPEHNBNOGD_PlayerId)
	{
		_KOHNLDKIKPC_sb.SetFormat("{0}_deco", _MLPEHNBNOGD_PlayerId);
	}

	// // RVA: 0x15C52C4 Offset: 0x15C52C4 VA: 0x15C52C4
	public static void DNEIBFNPNIA(StringBuilder _KOHNLDKIKPC_sb, int _EKANGPODCEP_EventId, int _AIBFGKBACCB_LobbyId)
    {
        _KOHNLDKIKPC_sb.SetFormat("{0}_{1}_cm", _EKANGPODCEP_EventId, _AIBFGKBACCB_LobbyId);
    }

	// // RVA: 0x15C5378 Offset: 0x15C5378 VA: 0x15C5378
	public static void OIEHNLEPEBG(StringBuilder _KOHNLDKIKPC_sb, int _EKANGPODCEP_EventId, int _AIBFGKBACCB_LobbyId, int _IBAKPKKEDJM_month, int _BAOFEFFADPD_day)
    {
        object[] o = new object[4]
        {
            _EKANGPODCEP_EventId,
            _AIBFGKBACCB_LobbyId,
            _IBAKPKKEDJM_month,
            _BAOFEFFADPD_day
        };
        _KOHNLDKIKPC_sb.SetFormat("{0}_{1}_cm_{2:D2}{3:D2}", o);
    }

	// // RVA: 0x15C55E8 Offset: 0x15C55E8 VA: 0x15C55E8
	public static void JHJAMPNMCFA(StringBuilder _KOHNLDKIKPC_sb, int _CMEJFJFOIIJ_QuestId)
    {
        _KOHNLDKIKPC_sb.SetFormat("{0:D2}", _CMEJFJFOIIJ_QuestId);
    }

	// // RVA: 0x15C567C Offset: 0x15C567C VA: 0x15C567C
	private static void KBIOJNKNKAE(string BDJEICCDKHB, ref int _DNJLJMKKDNA_EventId, ref int _MEBHCFJCKFE_LobbyId)
	{
		string[] strs = BDJEICCDKHB.Split(new char[] { '_' });
		if (strs.Length < 3)
			return;
		int.TryParse(strs[0], out _DNJLJMKKDNA_EventId);
		int.TryParse(strs[1], out _MEBHCFJCKFE_LobbyId);
	}

	// // RVA: 0x15C579C Offset: 0x15C579C VA: 0x15C579C
	public static void IANGEPFFHHM(string BDJEICCDKHB, ref string JECLCENDGIH, ref int GFOIDCMEHGL, ref int _DNJLJMKKDNA_EventId, ref int _MEBHCFJCKFE_LobbyId)
	{
		if(BDJEICCDKHB.Contains("_main"))
		{
			JECLCENDGIH = JpStringLiterals.StringLiteral_9360;
		}
		else if(BDJEICCDKHB.Contains("_blog"))
		{
			JECLCENDGIH = JpStringLiterals.StringLiteral_9362;
		}
		else if(BDJEICCDKHB.Contains("_memo"))
		{
			JECLCENDGIH = JpStringLiterals.StringLiteral_9364;
		}
		else if(BDJEICCDKHB.Contains("_deco"))
		{
			JECLCENDGIH = JpStringLiterals.StringLiteral_9366;
			int.TryParse(BDJEICCDKHB.Replace("_deco", ""), out GFOIDCMEHGL);
			return;
		}
		else if(BDJEICCDKHB.Contains("_cm_"))
		{
			JECLCENDGIH = JpStringLiterals.StringLiteral_9368;
		}
		else if(BDJEICCDKHB.Contains("_cm"))
		{
			JECLCENDGIH = JpStringLiterals.StringLiteral_9368;
		}
		else
		{
			JECLCENDGIH = JpStringLiterals.StringLiteral_9370;
			return;
		}
		KBIOJNKNKAE(BDJEICCDKHB, ref _DNJLJMKKDNA_EventId, ref _MEBHCFJCKFE_LobbyId);
	}
}
