
using System.Collections.Generic;

public class CAEDGOPBDNK
{
	public int IANDDEFHKAN_RequiredCount; // 0x8
	public string IPFEKNMBEBI_InventoryMessage; // 0xC
	public List<MFDJIFIIPJD> HBHMAKNGKFK_Items; // 0x10
	public bool AEMHPNJBFFD_IsLot; // 0x14

	public bool BAAELNFFCEA { get; }

	// // RVA: 0x18F373C Offset: 0x18F373C VA: 0x18F373C
	// public static CAEDGOPBDNK ODDIHGPONFL_Copy(CAEDGOPBDNK GPBJHKLFCEP) { }

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
	public void KHEKNNFCAOI_Init(EDOHBJAPLPF_JsonData _IDLHJIOMJBK_Data)
	{
		IANDDEFHKAN_RequiredCount = (int)_IDLHJIOMJBK_Data[AFEHLCGHAEE_Strings.IANDDEFHKAN_RequiredCount];
		if(_IDLHJIOMJBK_Data.BBAJPINMOEP_Contains(AFEHLCGHAEE_Strings.IPFEKNMBEBI_InventoryMessage) && _IDLHJIOMJBK_Data[AFEHLCGHAEE_Strings.IPFEKNMBEBI_InventoryMessage] != null)
		{
			IPFEKNMBEBI_InventoryMessage = (string)_IDLHJIOMJBK_Data[AFEHLCGHAEE_Strings.IPFEKNMBEBI_InventoryMessage];
		}
		if(_IDLHJIOMJBK_Data.BBAJPINMOEP_Contains(AFEHLCGHAEE_Strings.AEMHPNJBFFD_IsLot) && _IDLHJIOMJBK_Data[AFEHLCGHAEE_Strings.AEMHPNJBFFD_IsLot] != null)
		{
			AEMHPNJBFFD_IsLot = (bool)_IDLHJIOMJBK_Data[AFEHLCGHAEE_Strings.AEMHPNJBFFD_IsLot];
		}
		EDOHBJAPLPF_JsonData list = _IDLHJIOMJBK_Data[AFEHLCGHAEE_Strings.HBHMAKNGKFK_Items];
		HBHMAKNGKFK_Items = new List<MFDJIFIIPJD>(list.HNBFOAJIIAL_Count);
		for(int i = 0; i < list.HNBFOAJIIAL_Count; i++)
		{
			MFDJIFIIPJD data = new MFDJIFIIPJD();
			data.KHEKNNFCAOI_Init(list[i]);
			HBHMAKNGKFK_Items.Add(data);
		}
	}
}

public class EPLAAEHPCDM : MKCJNKIEADB
{
	public List<CAEDGOPBDNK> JPILDOGJLDG_login_bonus_prizes; // 0x40
	public int FHBJOLPCAPN_MaxCount; // 0x44
	public long MBJJMIIFNLL_max_period; // 0x48
	public bool OGKKJJFAFHE_repeat_with_count; // 0x50
	public bool BHLDDINNGFJ_RepeatWithPeriod; // 0x51
	public int CJNNMLLEKEF_PreviousPage; // 0x54
	public int GPPOJHNNINK_CurrentPage; // 0x58
	public int MDIBIIHAAPN_next_page; // 0x5C
	public int KNDAAAAHICA_CurrentCount; // 0x60
	public int MGANCKPFONE_CurrentCountModulo; // 0x64

	//// RVA: 0xFC0810 Offset: 0xFC0810 VA: 0xFC0810 Slot: 4
	public override void KHEKNNFCAOI_Init(EDOHBJAPLPF_JsonData _IDLHJIOMJBK_Data)
	{
		base.KHEKNNFCAOI_Init(_IDLHJIOMJBK_Data);
		KNDAAAAHICA_CurrentCount = 0;
		MGANCKPFONE_CurrentCountModulo = 0;
		FHBJOLPCAPN_MaxCount = 0;
		if(_IDLHJIOMJBK_Data.BBAJPINMOEP_Contains(AFEHLCGHAEE_Strings.FHBJOLPCAPN_MaxCount) && _IDLHJIOMJBK_Data[AFEHLCGHAEE_Strings.FHBJOLPCAPN_MaxCount] != null)
		{
			FHBJOLPCAPN_MaxCount = (int)_IDLHJIOMJBK_Data[AFEHLCGHAEE_Strings.FHBJOLPCAPN_MaxCount];
		}
		MBJJMIIFNLL_max_period = 0;
		if(_IDLHJIOMJBK_Data.BBAJPINMOEP_Contains(AFEHLCGHAEE_Strings.MBJJMIIFNLL_max_period) && _IDLHJIOMJBK_Data[AFEHLCGHAEE_Strings.MBJJMIIFNLL_max_period] != null)
		{
			MBJJMIIFNLL_max_period = (int)_IDLHJIOMJBK_Data[AFEHLCGHAEE_Strings.MBJJMIIFNLL_max_period];
		}
		OGKKJJFAFHE_repeat_with_count = (bool)_IDLHJIOMJBK_Data[AFEHLCGHAEE_Strings.OGKKJJFAFHE_repeat_with_count];
		BHLDDINNGFJ_RepeatWithPeriod = (bool)_IDLHJIOMJBK_Data[AFEHLCGHAEE_Strings.BHLDDINNGFJ_RepeatWithPeriod];
        EDOHBJAPLPF_JsonData prizes = _IDLHJIOMJBK_Data[AFEHLCGHAEE_Strings.JPILDOGJLDG_login_bonus_prizes];
        JPILDOGJLDG_login_bonus_prizes = new List<CAEDGOPBDNK>(prizes.HNBFOAJIIAL_Count);
		for(int i = 0; i < prizes.HNBFOAJIIAL_Count; i++)
		{
			CAEDGOPBDNK data = new CAEDGOPBDNK();
			data.KHEKNNFCAOI_Init(prizes[i]);
			JPILDOGJLDG_login_bonus_prizes.Add(data);
		}
		CJNNMLLEKEF_PreviousPage = (int)_IDLHJIOMJBK_Data[AFEHLCGHAEE_Strings.CJNNMLLEKEF_PreviousPage];
		GPPOJHNNINK_CurrentPage = (int)_IDLHJIOMJBK_Data[AFEHLCGHAEE_Strings.GPPOJHNNINK_CurrentPage];
		MDIBIIHAAPN_next_page = (int)_IDLHJIOMJBK_Data[AFEHLCGHAEE_Strings.MDIBIIHAAPN_next_page];
	}

	//// RVA: 0xFC0F08 Offset: 0xFC0F08 VA: 0xFC0F08
	//public bool CLCKGPEDEGF() { }
}
