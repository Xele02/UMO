
public class IAPIDHGIEED
{
	private const int FBGGEFFJJHB_xor = 625060239;
	public int NOFGLADFIGG = FBGGEFFJJHB_xor; // 0x8
	public int JFJJCNANPOP = FBGGEFFJJHB_xor; // 0xC
	public int BPDEBDINFAI = FBGGEFFJJHB_xor; // 0x10
	public int DFMGBHIOPJP = FBGGEFFJJHB_xor; // 0x14
	public string ENJCKADOFBD_NextPurchaseHash; // 0x18

	public int DBNAGGGJDAB_CurrentStepIndex { get { return NOFGLADFIGG ^ FBGGEFFJJHB_xor; } set { NOFGLADFIGG = value ^ FBGGEFFJJHB_xor; } } //0x120FEB4 FMOLHGECNEI 0x120FEC8 HNIOFBHDMBG
	public int LPIKIBKFOJE_current_step_count { get { return JFJJCNANPOP ^ FBGGEFFJJHB_xor; } set { JFJJCNANPOP = value ^ FBGGEFFJJHB_xor; } } //0x120FEDC EMKEFMBNDIH 0x120FEF0 DANGGHKPBMO
	public int NMNLJFIDFJE_current_step_rest_count { get { return BPDEBDINFAI ^ FBGGEFFJJHB_xor; } set { BPDEBDINFAI = value ^ FBGGEFFJJHB_xor; } } //0x120FF04 OKDFKCDCDDH 0x120FF18 JJKAMOCJCJH
	public int KHEBCAGHEIN_total_count { get { return DFMGBHIOPJP ^ FBGGEFFJJHB_xor; } set { DFMGBHIOPJP = value ^ FBGGEFFJJHB_xor; } } //0x120FF2C PIHIDIMHOCB 0x120FF40 FCBOFGEJLBM

	//// RVA: 0x120FF54 Offset: 0x120FF54 VA: 0x120FF54
	public void ODDIHGPONFL_Copy(IAPIDHGIEED GPBJHKLFCEP)
	{
		DBNAGGGJDAB_CurrentStepIndex = GPBJHKLFCEP.DBNAGGGJDAB_CurrentStepIndex;
		LPIKIBKFOJE_current_step_count = GPBJHKLFCEP.LPIKIBKFOJE_current_step_count;
		NMNLJFIDFJE_current_step_rest_count = GPBJHKLFCEP.NMNLJFIDFJE_current_step_rest_count;
		KHEBCAGHEIN_total_count = GPBJHKLFCEP.KHEBCAGHEIN_total_count;
		ENJCKADOFBD_NextPurchaseHash = GPBJHKLFCEP.ENJCKADOFBD_NextPurchaseHash;
	}

	//// RVA: 0x120FFF4 Offset: 0x120FFF4 VA: 0x120FFF4
	public void KHEKNNFCAOI_Init(EDOHBJAPLPF_JsonData _IDLHJIOMJBK_Data)
	{
		DBNAGGGJDAB_CurrentStepIndex = (int)_IDLHJIOMJBK_Data[AFEHLCGHAEE_Strings.DBNAGGGJDAB_CurrentStepIndex];
		LPIKIBKFOJE_current_step_count = (int)_IDLHJIOMJBK_Data[AFEHLCGHAEE_Strings.LPIKIBKFOJE_current_step_count];
		NMNLJFIDFJE_current_step_rest_count = -1;
		if (_IDLHJIOMJBK_Data.BBAJPINMOEP_Contains(AFEHLCGHAEE_Strings.NMNLJFIDFJE_current_step_rest_count))
		{
			if(_IDLHJIOMJBK_Data[AFEHLCGHAEE_Strings.NMNLJFIDFJE_current_step_rest_count] != null)
			{
				NMNLJFIDFJE_current_step_rest_count = (int)_IDLHJIOMJBK_Data[AFEHLCGHAEE_Strings.NMNLJFIDFJE_current_step_rest_count];
			}
		}
		KHEBCAGHEIN_total_count = (int)_IDLHJIOMJBK_Data[AFEHLCGHAEE_Strings.KHEBCAGHEIN_total_count];
		ENJCKADOFBD_NextPurchaseHash = (string)_IDLHJIOMJBK_Data[AFEHLCGHAEE_Strings.ENJCKADOFBD_NextPurchaseHash];
	}
}
