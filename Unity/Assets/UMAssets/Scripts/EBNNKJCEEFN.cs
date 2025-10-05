
using System;
using System.Text;

public class EBNNKJCEEFN
{
	//// RVA: 0x14FFA04 Offset: 0x14FFA04 VA: 0x14FFA04
	//public static void NOADMFIACCH(int _KPNKPGLPDHI_Op, int _MLPEHNBNOGD_PlayerId, Action<bool> _BHFHGFKBOHH_OnSuccess, DJBHIFLHJLK _MOBEEPPKFLG_OnFail) { }

	// RVA: 0x14FFC0C Offset: 0x14FFC0C VA: 0x14FFC0C
	public static OKLFOAPMJAA LIFAAGMJFEB(int _MLPEHNBNOGD_PlayerId)
	{
		OKLFOAPMJAA res = new OKLFOAPMJAA();
		StringBuilder str = new StringBuilder(32);
		AHAENNIFOAF.BCJOMHAIGGJ(str, _MLPEHNBNOGD_PlayerId);
		res.OBKGEDCKHHE_Init(str.ToString(), 60, true, null);
		res.EEBMKLOIEMB_SetAutoUpdateInterval(IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.HNMMJINNHII_Game.LPJLEHAJADA_GetIntParam("bbs_auto_update_interval_deco", 10));
		if (_MLPEHNBNOGD_PlayerId == NKGJPJPHLIF.HHCJCDFCLOB.MDAMJIGBOLD_PlayerId)
			res.PFMOHFOOBCL(AHAENNIFOAF.IAOPMEAIHLH_BbsType.BJNAMAANNMB_3_Deco);
		return res;
	}
}
