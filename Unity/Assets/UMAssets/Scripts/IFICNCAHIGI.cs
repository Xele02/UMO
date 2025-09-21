
using System.Collections.Generic;

public class IFICNCAHIGI : IBIGBMDANNM
{
	public int AGDBNNEAIIC_FanNum { get; set; } // 0x48 KIHAEDNHHAN NDEDOLKIOIE HACPPJDBEOJ
	public bool BBNAEPGAMMA_IsFavorite { get; set; } // 0x4C FEPMDHPMCJN JMPMCEFAGBB BJEPEENJLJB

	// RVA: 0x11EEFD0 Offset: 0x11EEFD0 VA: 0x11EEFD0 Slot: 5
	protected override bool NLENMNMCJCJ(int _PPFNGGCBJKC_id, long _IFNLEKOILPM_UpdatedAt, bool _MLEHCBKPNGK_IsFriend, List<string> _OHNJJIMGKGK_Names, EDOHBJAPLPF_JsonData _IDLHJIOMJBK_Data, BBHNACPENDM_ServerSaveData _AHEFHIMGIBI_PlayerData)
	{
		bool res = base.NLENMNMCJCJ(_PPFNGGCBJKC_id, _IFNLEKOILPM_UpdatedAt, _MLEHCBKPNGK_IsFriend, _OHNJJIMGKGK_Names, _IDLHJIOMJBK_Data, _AHEFHIMGIBI_PlayerData);
		if(res)
		{
			BBNAEPGAMMA_IsFavorite = CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_PlayerData.GAAOPEGIPKA_FavoritePlayer.FFKIDMKHIOE(_PPFNGGCBJKC_id);
		}
		return res;
	}
}
