
using XeSys;

public class MKCJNKIEADB
{
	public int PPFNGGCBJKC_id; // 0x8
	public string BPEAIOBHMFD_name_for_apis; // 0xC
	public string OPFGFINHFCE_name; // 0x10
	public string KLMPFGOCBHC_description; // 0x14
	public long MMPCPKODGKI_reset_at; // 0x18
	public long KBFOIECIADN_opened_at; // 0x20
	public long EGBOHDFBAPB_closed_at; // 0x28
	public ANPGILOLNFK.CDOGFBNLIPG_LoginBonusType CKHOBDIKJFN_Type; // 0x30
	public int PJHKECDOALD = 100; // 0x34
	public bool DNEHFIFIHEM; // 0x38
	public int OENPCNBFPDA_bg_id; // 0x3C

	// RVA: 0x19596F0 Offset: 0x19596F0 VA: 0x19596F0 Slot: 4
	public virtual void KHEKNNFCAOI_Init(EDOHBJAPLPF_JsonData _IDLHJIOMJBK_data)
	{
		PPFNGGCBJKC_id = (int)_IDLHJIOMJBK_data[AFEHLCGHAEE_Strings.PPFNGGCBJKC_id];
		BPEAIOBHMFD_name_for_apis = (string)_IDLHJIOMJBK_data[AFEHLCGHAEE_Strings.BPEAIOBHMFD_name_for_apis];
		OPFGFINHFCE_name = (string)_IDLHJIOMJBK_data[AFEHLCGHAEE_Strings.OPFGFINHFCE_name];
		KLMPFGOCBHC_description = (string)_IDLHJIOMJBK_data[AFEHLCGHAEE_Strings.KLMPFGOCBHC_description];
		MMPCPKODGKI_reset_at = JsonUtil.GetLong(_IDLHJIOMJBK_data, AFEHLCGHAEE_Strings.MMPCPKODGKI_reset_at);
		KBFOIECIADN_opened_at = JsonUtil.GetLong(_IDLHJIOMJBK_data, AFEHLCGHAEE_Strings.KBFOIECIADN_opened_at);
		EGBOHDFBAPB_closed_at = JsonUtil.GetLong(_IDLHJIOMJBK_data, AFEHLCGHAEE_Strings.EGBOHDFBAPB_closed_at);
		CKHOBDIKJFN_Type = ANPGILOLNFK.OLMFIANJBOB_GetType(BPEAIOBHMFD_name_for_apis);
		OENPCNBFPDA_bg_id = ANPGILOLNFK.AFMHNPCDAFI_GetBgId(BPEAIOBHMFD_name_for_apis);
		PJHKECDOALD = ANPGILOLNFK.FENFHPPHCBE[(int)CKHOBDIKJFN_Type];
		DNEHFIFIHEM = CKHOBDIKJFN_Type == ANPGILOLNFK.CDOGFBNLIPG_LoginBonusType.PHABJLGFJNI_1_Regular || (CKHOBDIKJFN_Type >= ANPGILOLNFK.CDOGFBNLIPG_LoginBonusType.LAOEGNLOJHC_5_Start && CKHOBDIKJFN_Type < ANPGILOLNFK.CDOGFBNLIPG_LoginBonusType.MKADAMIGMPO_7_Total);
	}

	//// RVA: 0x19599DC Offset: 0x19599DC VA: 0x19599DC
	public bool ILOKENBBBAE_Available(long _BEBJKJKBOGH_date)
	{
		if(KBFOIECIADN_opened_at == 0 || _BEBJKJKBOGH_date >= KBFOIECIADN_opened_at)
		{
			if(EGBOHDFBAPB_closed_at == 0 || _BEBJKJKBOGH_date < EGBOHDFBAPB_closed_at)
			{
				return _BEBJKJKBOGH_date >= MMPCPKODGKI_reset_at;
			}
		}
		return false;
	}
}
