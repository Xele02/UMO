
using XeSys;

public class MKCJNKIEADB
{
	public int PPFNGGCBJKC_id; // 0x8
	public string BPEAIOBHMFD_NameForApis; // 0xC
	public string OPFGFINHFCE_name; // 0x10
	public string KLMPFGOCBHC_description; // 0x14
	public long MMPCPKODGKI_reset_at; // 0x18
	public long KBFOIECIADN_opened_at; // 0x20
	public long EGBOHDFBAPB_CloseAt; // 0x28
	public ANPGILOLNFK.CDOGFBNLIPG CKHOBDIKJFN_Type; // 0x30
	public int PJHKECDOALD = 100; // 0x34
	public bool DNEHFIFIHEM; // 0x38
	public int OENPCNBFPDA_bg_id; // 0x3C

	// RVA: 0x19596F0 Offset: 0x19596F0 VA: 0x19596F0 Slot: 4
	public virtual void KHEKNNFCAOI_Init(EDOHBJAPLPF_JsonData _IDLHJIOMJBK_Data)
	{
		PPFNGGCBJKC_id = (int)_IDLHJIOMJBK_Data[AFEHLCGHAEE_Strings.PPFNGGCBJKC_id];
		BPEAIOBHMFD_NameForApis = (string)_IDLHJIOMJBK_Data[AFEHLCGHAEE_Strings.BPEAIOBHMFD_NameForApis];
		OPFGFINHFCE_name = (string)_IDLHJIOMJBK_Data[AFEHLCGHAEE_Strings.OPFGFINHFCE_name];
		KLMPFGOCBHC_description = (string)_IDLHJIOMJBK_Data[AFEHLCGHAEE_Strings.KLMPFGOCBHC_description];
		MMPCPKODGKI_reset_at = JsonUtil.GetLong(_IDLHJIOMJBK_Data, AFEHLCGHAEE_Strings.MMPCPKODGKI_reset_at);
		KBFOIECIADN_opened_at = JsonUtil.GetLong(_IDLHJIOMJBK_Data, AFEHLCGHAEE_Strings.KBFOIECIADN_opened_at);
		EGBOHDFBAPB_CloseAt = JsonUtil.GetLong(_IDLHJIOMJBK_Data, AFEHLCGHAEE_Strings.EGBOHDFBAPB_CloseAt);
		CKHOBDIKJFN_Type = ANPGILOLNFK.OLMFIANJBOB_GetType(BPEAIOBHMFD_NameForApis);
		OENPCNBFPDA_bg_id = ANPGILOLNFK.AFMHNPCDAFI_GetBgId(BPEAIOBHMFD_NameForApis);
		PJHKECDOALD = ANPGILOLNFK.FENFHPPHCBE[(int)CKHOBDIKJFN_Type];
		DNEHFIFIHEM = CKHOBDIKJFN_Type == ANPGILOLNFK.CDOGFBNLIPG.PHABJLGFJNI_1_Regular || (CKHOBDIKJFN_Type >= ANPGILOLNFK.CDOGFBNLIPG.LAOEGNLOJHC_5_Start && CKHOBDIKJFN_Type < ANPGILOLNFK.CDOGFBNLIPG.MKADAMIGMPO_7_Total);
	}

	//// RVA: 0x19599DC Offset: 0x19599DC VA: 0x19599DC
	public bool ILOKENBBBAE_Available(long _BEBJKJKBOGH_Date)
	{
		if(KBFOIECIADN_opened_at == 0 || _BEBJKJKBOGH_Date >= KBFOIECIADN_opened_at)
		{
			if(EGBOHDFBAPB_CloseAt == 0 || _BEBJKJKBOGH_Date < EGBOHDFBAPB_CloseAt)
			{
				return _BEBJKJKBOGH_Date >= MMPCPKODGKI_reset_at;
			}
		}
		return false;
	}
}
