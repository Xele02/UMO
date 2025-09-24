
using XeApp.Game.Common;

public class ECEPJHGMGBJ : IBJAKJJICBC
{
	public int LPALNMHPDKK_Score { get; set; } // 0xDC CDKILGMPLCF KFHBJBLOGGO GLJHANHAFMN
	public int HKIAHOEEMLC_PrevScore { get; set; } // 0xE0 JCKPLOPNIIB PLOGONAKOPF HMAMEJKDGAA
	public Difficulty.Type AKNELONELJK_difficulty { get; set; } // 0xE4 MDCMMICBKFN BPPILHGDABB PMMIIHKEGCI
	public int FJOLNJLLJEJ_rank { get; set; } // 0xE8 BLIGJGPCOKP EAKAGHDPEMI GHECCGBGCBI
	public bool LFGNLKKFOCD_IsLine6 { get; set; } // 0xEC JPINIEEOCME PAIHMADGJKE ICADLJCGFIN

	//// RVA: 0x1502C90 Offset: 0x1502C90 VA: 0x1502C90
	new public void KHEKNNFCAOI_Init(int _GHBPLHBNMBK_FreeMusicId)
	{
		base.KHEKNNFCAOI_Init(_GHBPLHBNMBK_FreeMusicId, false, 0, 0, 0, false, false, false);
		LPALNMHPDKK_Score = 0;
		HKIAHOEEMLC_PrevScore = 0;
		AKNELONELJK_difficulty = Difficulty.Type.Easy;
		FJOLNJLLJEJ_rank = 0;
		LFGNLKKFOCD_IsLine6 = false;
	}
}
