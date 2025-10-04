
using XeApp.Game.Common;

public class ECEPJHGMGBJ : IBJAKJJICBC
{
	public int LPALNMHPDKK_Score { get; set; } // 0xDC CDKILGMPLCF_bgs KFHBJBLOGGO_bgs GLJHANHAFMN_bgs
	public int HKIAHOEEMLC_PrevScore { get; set; } // 0xE0 JCKPLOPNIIB_bgs PLOGONAKOPF_bgs HMAMEJKDGAA_bgs
	public Difficulty.Type AKNELONELJK_difficulty { get; set; } // 0xE4 MDCMMICBKFN_bgs BPPILHGDABB_get_difficulty PMMIIHKEGCI_set_difficulty
	public int FJOLNJLLJEJ_rank { get; set; } // 0xE8 BLIGJGPCOKP_bgs EAKAGHDPEMI_get_rank GHECCGBGCBI_set_rank
	public bool LFGNLKKFOCD_IsLine6 { get; set; } // 0xEC JPINIEEOCME_bgs PAIHMADGJKE_bgs ICADLJCGFIN_bgs

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
