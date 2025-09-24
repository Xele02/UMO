
using System.Collections.Generic;

public class CAEDGOPBDNK
{
	public int IANDDEFHKAN_required_count; // 0x8
	public string IPFEKNMBEBI_inventory_message; // 0xC
	public List<MFDJIFIIPJD> HBHMAKNGKFK_items; // 0x10
	public bool AEMHPNJBFFD_is_lot; // 0x14

	public bool BAAELNFFCEA { get; }

	// // RVA: 0x18F373C Offset: 0x18F373C VA: 0x18F373C
	// public static CAEDGOPBDNK ODDIHGPONFL_Copy(CAEDGOPBDNK GPBJHKLFCEP) { }

	// // RVA: 0x18F3900 Offset: 0x18F3900 VA: 0x18F3900
	public bool CDCPAEJIJME_IsEmpty()
	{
		if(HBHMAKNGKFK_items != null)
		{
			return HBHMAKNGKFK_items.Count == 0;
		}
		return true;
	}

	// // RVA: 0x18F3984 Offset: 0x18F3984 VA: 0x18F3984
	public void KHEKNNFCAOI_Init(EDOHBJAPLPF_JsonData _IDLHJIOMJBK_data)
	{
		IANDDEFHKAN_required_count = (int)_IDLHJIOMJBK_data[AFEHLCGHAEE_Strings.IANDDEFHKAN_required_count];
		if(_IDLHJIOMJBK_data.BBAJPINMOEP_Contains(AFEHLCGHAEE_Strings.IPFEKNMBEBI_inventory_message) && _IDLHJIOMJBK_data[AFEHLCGHAEE_Strings.IPFEKNMBEBI_inventory_message] != null)
		{
			IPFEKNMBEBI_inventory_message = (string)_IDLHJIOMJBK_data[AFEHLCGHAEE_Strings.IPFEKNMBEBI_inventory_message];
		}
		if(_IDLHJIOMJBK_data.BBAJPINMOEP_Contains(AFEHLCGHAEE_Strings.AEMHPNJBFFD_is_lot) && _IDLHJIOMJBK_data[AFEHLCGHAEE_Strings.AEMHPNJBFFD_is_lot] != null)
		{
			AEMHPNJBFFD_is_lot = (bool)_IDLHJIOMJBK_data[AFEHLCGHAEE_Strings.AEMHPNJBFFD_is_lot];
		}
		EDOHBJAPLPF_JsonData list = _IDLHJIOMJBK_data[AFEHLCGHAEE_Strings.HBHMAKNGKFK_items];
		HBHMAKNGKFK_items = new List<MFDJIFIIPJD>(list.HNBFOAJIIAL_Count);
		for(int i = 0; i < list.HNBFOAJIIAL_Count; i++)
		{
			MFDJIFIIPJD data = new MFDJIFIIPJD();
			data.KHEKNNFCAOI_Init(list[i]);
			HBHMAKNGKFK_items.Add(data);
		}
	}
}

public class EPLAAEHPCDM : MKCJNKIEADB
{
	public List<CAEDGOPBDNK> JPILDOGJLDG_login_bonus_prizes; // 0x40
	public int FHBJOLPCAPN_max_count; // 0x44
	public long MBJJMIIFNLL_max_period; // 0x48
	public bool OGKKJJFAFHE_repeat_with_count; // 0x50
	public bool BHLDDINNGFJ_repeat_with_period; // 0x51
	public int CJNNMLLEKEF_previous_page; // 0x54
	public int GPPOJHNNINK_current_page; // 0x58
	public int MDIBIIHAAPN_next_page; // 0x5C
	public int KNDAAAAHICA_CurrentCount; // 0x60
	public int MGANCKPFONE_CurrentCountModulo; // 0x64

	//// RVA: 0xFC0810 Offset: 0xFC0810 VA: 0xFC0810 Slot: 4
	public override void KHEKNNFCAOI_Init(EDOHBJAPLPF_JsonData _IDLHJIOMJBK_data)
	{
		base.KHEKNNFCAOI_Init(_IDLHJIOMJBK_data);
		KNDAAAAHICA_CurrentCount = 0;
		MGANCKPFONE_CurrentCountModulo = 0;
		FHBJOLPCAPN_max_count = 0;
		if(_IDLHJIOMJBK_data.BBAJPINMOEP_Contains(AFEHLCGHAEE_Strings.FHBJOLPCAPN_max_count) && _IDLHJIOMJBK_data[AFEHLCGHAEE_Strings.FHBJOLPCAPN_max_count] != null)
		{
			FHBJOLPCAPN_max_count = (int)_IDLHJIOMJBK_data[AFEHLCGHAEE_Strings.FHBJOLPCAPN_max_count];
		}
		MBJJMIIFNLL_max_period = 0;
		if(_IDLHJIOMJBK_data.BBAJPINMOEP_Contains(AFEHLCGHAEE_Strings.MBJJMIIFNLL_max_period) && _IDLHJIOMJBK_data[AFEHLCGHAEE_Strings.MBJJMIIFNLL_max_period] != null)
		{
			MBJJMIIFNLL_max_period = (int)_IDLHJIOMJBK_data[AFEHLCGHAEE_Strings.MBJJMIIFNLL_max_period];
		}
		OGKKJJFAFHE_repeat_with_count = (bool)_IDLHJIOMJBK_data[AFEHLCGHAEE_Strings.OGKKJJFAFHE_repeat_with_count];
		BHLDDINNGFJ_repeat_with_period = (bool)_IDLHJIOMJBK_data[AFEHLCGHAEE_Strings.BHLDDINNGFJ_repeat_with_period];
        EDOHBJAPLPF_JsonData prizes = _IDLHJIOMJBK_data[AFEHLCGHAEE_Strings.JPILDOGJLDG_login_bonus_prizes];
        JPILDOGJLDG_login_bonus_prizes = new List<CAEDGOPBDNK>(prizes.HNBFOAJIIAL_Count);
		for(int i = 0; i < prizes.HNBFOAJIIAL_Count; i++)
		{
			CAEDGOPBDNK data = new CAEDGOPBDNK();
			data.KHEKNNFCAOI_Init(prizes[i]);
			JPILDOGJLDG_login_bonus_prizes.Add(data);
		}
		CJNNMLLEKEF_previous_page = (int)_IDLHJIOMJBK_data[AFEHLCGHAEE_Strings.CJNNMLLEKEF_previous_page];
		GPPOJHNNINK_current_page = (int)_IDLHJIOMJBK_data[AFEHLCGHAEE_Strings.GPPOJHNNINK_current_page];
		MDIBIIHAAPN_next_page = (int)_IDLHJIOMJBK_data[AFEHLCGHAEE_Strings.MDIBIIHAAPN_next_page];
	}

	//// RVA: 0xFC0F08 Offset: 0xFC0F08 VA: 0xFC0F08
	//public bool CLCKGPEDEGF() { }
}
