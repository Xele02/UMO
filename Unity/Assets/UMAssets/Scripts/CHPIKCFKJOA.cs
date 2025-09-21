
public class DJFNNGDEHIA
{
	public int PPFNGGCBJKC_id; // 0x8
	public long IFNLEKOILPM_UpdatedAt; // 0x10

	// RVA: 0x198CD3C Offset: 0x198CD3C VA: 0x198CD3C
	public void KHEKNNFCAOI_Init(EDOHBJAPLPF_JsonData _IDLHJIOMJBK_Data)
	{
		PPFNGGCBJKC_id = (int)_IDLHJIOMJBK_Data[AFEHLCGHAEE_Strings.PPFNGGCBJKC_id];
		IFNLEKOILPM_UpdatedAt = (int)_IDLHJIOMJBK_Data[AFEHLCGHAEE_Strings.IFNLEKOILPM_UpdatedAt];
	}
}

public class COBFLNBLJEI
{
	public int EHGBICNIBKE_PlayerId; // 0x8
	public int NEILEPPJKIN_favorite; // 0xC
	public int NPMIJMFMEKB_target_player_id; // 0x10
	public long BIOGKIEECGN_CreatedAt; // 0x18
	public long IFNLEKOILPM_UpdatedAt; // 0x20

	// RVA: 0x1761570 Offset: 0x1761570 VA: 0x1761570
	public void KHEKNNFCAOI_Init(EDOHBJAPLPF_JsonData _IDLHJIOMJBK_Data)
	{
		EHGBICNIBKE_PlayerId = (int)_IDLHJIOMJBK_Data[AFEHLCGHAEE_Strings.EHGBICNIBKE_PlayerId];
		NEILEPPJKIN_favorite = (int)_IDLHJIOMJBK_Data[AFEHLCGHAEE_Strings.NEILEPPJKIN_favorite];
		NPMIJMFMEKB_target_player_id = (int)_IDLHJIOMJBK_Data[AFEHLCGHAEE_Strings.NPMIJMFMEKB_target_player_id];
		BIOGKIEECGN_CreatedAt = (int)_IDLHJIOMJBK_Data[AFEHLCGHAEE_Strings.BIOGKIEECGN_CreatedAt];
		IFNLEKOILPM_UpdatedAt = (int)_IDLHJIOMJBK_Data[AFEHLCGHAEE_Strings.IFNLEKOILPM_UpdatedAt];
	}
}

public class CHPIKCFKJOA
{
	public COBFLNBLJEI JPFFIBCDCNJ_friend; // 0x8
	public DJFNNGDEHIA NMICBJDPLOH_player; // 0xC

	// RVA: 0xFF51BC Offset: 0xFF51BC VA: 0xFF51BC
	public void KHEKNNFCAOI_Init(EDOHBJAPLPF_JsonData _IDLHJIOMJBK_Data)
	{
		JPFFIBCDCNJ_friend = new COBFLNBLJEI();
		JPFFIBCDCNJ_friend.KHEKNNFCAOI_Init(_IDLHJIOMJBK_Data[AFEHLCGHAEE_Strings.JPFFIBCDCNJ_friend]);
		NMICBJDPLOH_player = new DJFNNGDEHIA();
		NMICBJDPLOH_player.KHEKNNFCAOI_Init(_IDLHJIOMJBK_Data[AFEHLCGHAEE_Strings.NMICBJDPLOH_player]);
	}
}
