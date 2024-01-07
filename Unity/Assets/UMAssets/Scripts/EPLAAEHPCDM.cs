
using System.Collections.Generic;

public class CAEDGOPBDNK
{
	public int IANDDEFHKAN_RequiredCount; // 0x8
	public string IPFEKNMBEBI_InventoryMessage; // 0xC
	public List<MFDJIFIIPJD> HBHMAKNGKFK_Items; // 0x10
	public bool AEMHPNJBFFD_IsLot; // 0x14

	public bool BAAELNFFCEA { get; }

	// // RVA: 0x18F373C Offset: 0x18F373C VA: 0x18F373C
	// public static CAEDGOPBDNK ODDIHGPONFL(CAEDGOPBDNK GPBJHKLFCEP) { }

	// // RVA: 0x18F3900 Offset: 0x18F3900 VA: 0x18F3900
	public bool CDCPAEJIJME_IsEmpty()
	{
		if(HBHMAKNGKFK_Items != null)
		{
			return HBHMAKNGKFK_Items.Count == 0;
		}
		return true;
	}

	// // RVA: 0x18F3984 Offset: 0x18F3984 VA: 0x18F3984
	public void KHEKNNFCAOI(EDOHBJAPLPF_JsonData IDLHJIOMJBK)
	{
		IANDDEFHKAN_RequiredCount = (int)IDLHJIOMJBK[AFEHLCGHAEE_Strings.IANDDEFHKAN_required_count];
		if(IDLHJIOMJBK.BBAJPINMOEP_Contains(AFEHLCGHAEE_Strings.IPFEKNMBEBI_inventory_message) && IDLHJIOMJBK[AFEHLCGHAEE_Strings.IPFEKNMBEBI_inventory_message] != null)
		{
			IPFEKNMBEBI_InventoryMessage = (string)IDLHJIOMJBK[AFEHLCGHAEE_Strings.IPFEKNMBEBI_inventory_message];
		}
		if(IDLHJIOMJBK.BBAJPINMOEP_Contains(AFEHLCGHAEE_Strings.AEMHPNJBFFD_is_lot) && IDLHJIOMJBK[AFEHLCGHAEE_Strings.AEMHPNJBFFD_is_lot] != null)
		{
			AEMHPNJBFFD_IsLot = (bool)IDLHJIOMJBK[AFEHLCGHAEE_Strings.AEMHPNJBFFD_is_lot];
		}
		EDOHBJAPLPF_JsonData list = IDLHJIOMJBK[AFEHLCGHAEE_Strings.HBHMAKNGKFK_items];
		HBHMAKNGKFK_Items = new List<MFDJIFIIPJD>(list.HNBFOAJIIAL_Count);
		for(int i = 0; i < list.HNBFOAJIIAL_Count; i++)
		{
			MFDJIFIIPJD data = new MFDJIFIIPJD();
			data.KHEKNNFCAOI(list[i]);
			HBHMAKNGKFK_Items.Add(data);
		}
	}
}

public class EPLAAEHPCDM : MKCJNKIEADB
{
	public List<CAEDGOPBDNK> JPILDOGJLDG_LoginBonusPrizes; // 0x40
	public int FHBJOLPCAPN_MaxCount; // 0x44
	public long MBJJMIIFNLL_MaxPeriod; // 0x48
	public bool OGKKJJFAFHE_RepeatWithCount; // 0x50
	public bool BHLDDINNGFJ_RepeatWithPeriod; // 0x51
	public int CJNNMLLEKEF_PreviousPage; // 0x54
	public int GPPOJHNNINK_CurrentPage; // 0x58
	public int MDIBIIHAAPN_NextPage; // 0x5C
	public int KNDAAAAHICA; // 0x60
	public int MGANCKPFONE; // 0x64

	//// RVA: 0xFC0810 Offset: 0xFC0810 VA: 0xFC0810 Slot: 4
	public override void KHEKNNFCAOI(EDOHBJAPLPF_JsonData IDLHJIOMJBK)
	{
		base.KHEKNNFCAOI(IDLHJIOMJBK);
		KNDAAAAHICA = 0;
		MGANCKPFONE = 0;
		FHBJOLPCAPN_MaxCount = 0;
		if(IDLHJIOMJBK.BBAJPINMOEP_Contains(AFEHLCGHAEE_Strings.FHBJOLPCAPN_max_count) && IDLHJIOMJBK[AFEHLCGHAEE_Strings.FHBJOLPCAPN_max_count] != null)
		{
			FHBJOLPCAPN_MaxCount = (int)IDLHJIOMJBK[AFEHLCGHAEE_Strings.FHBJOLPCAPN_max_count];
		}
		MBJJMIIFNLL_MaxPeriod = 0;
		if(IDLHJIOMJBK.BBAJPINMOEP_Contains(AFEHLCGHAEE_Strings.MBJJMIIFNLL_max_period) && IDLHJIOMJBK[AFEHLCGHAEE_Strings.MBJJMIIFNLL_max_period] != null)
		{
			MBJJMIIFNLL_MaxPeriod = (int)IDLHJIOMJBK[AFEHLCGHAEE_Strings.MBJJMIIFNLL_max_period];
		}
		OGKKJJFAFHE_RepeatWithCount = (bool)IDLHJIOMJBK[AFEHLCGHAEE_Strings.OGKKJJFAFHE_repeat_with_count];
		BHLDDINNGFJ_RepeatWithPeriod = (bool)IDLHJIOMJBK[AFEHLCGHAEE_Strings.BHLDDINNGFJ_repeat_with_period];
        EDOHBJAPLPF_JsonData prizes = IDLHJIOMJBK[AFEHLCGHAEE_Strings.JPILDOGJLDG_login_bonus_prizes];
        JPILDOGJLDG_LoginBonusPrizes = new List<CAEDGOPBDNK>(prizes.HNBFOAJIIAL_Count);
		for(int i = 0; i < prizes.HNBFOAJIIAL_Count; i++)
		{
			CAEDGOPBDNK data = new CAEDGOPBDNK();
			data.KHEKNNFCAOI(prizes[i]);
			JPILDOGJLDG_LoginBonusPrizes.Add(data);
		}
		CJNNMLLEKEF_PreviousPage = (int)IDLHJIOMJBK[AFEHLCGHAEE_Strings.CJNNMLLEKEF_previous_page];
		GPPOJHNNINK_CurrentPage = (int)IDLHJIOMJBK[AFEHLCGHAEE_Strings.GPPOJHNNINK_current_page];
		MDIBIIHAAPN_NextPage = (int)IDLHJIOMJBK[AFEHLCGHAEE_Strings.MDIBIIHAAPN_next_page];
	}

	//// RVA: 0xFC0F08 Offset: 0xFC0F08 VA: 0xFC0F08
	//public bool CLCKGPEDEGF() { }
}
