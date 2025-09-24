
using System.Collections.Generic;

public class BOKJNFPGGIB // TypeDefIndex: 10380
{
	public int PPFNGGCBJKC_id; // 0x8
	public string OPFGFINHFCE_name; // 0xC
	public string KLMPFGOCBHC_description; // 0x10
	public int BPNPBJALGHM_quantity; // 0x14

	// // RVA: 0x19CD790 Offset: 0x19CD790 VA: 0x19CD790
	public void KHEKNNFCAOI_Init(EDOHBJAPLPF_JsonData _IDLHJIOMJBK_data)
    {
        PPFNGGCBJKC_id = (int)_IDLHJIOMJBK_data[AFEHLCGHAEE_Strings.PPFNGGCBJKC_id];
        OPFGFINHFCE_name = (string)_IDLHJIOMJBK_data[AFEHLCGHAEE_Strings.OPFGFINHFCE_name];
        KLMPFGOCBHC_description = (string)_IDLHJIOMJBK_data[AFEHLCGHAEE_Strings.KLMPFGOCBHC_description];
        BPNPBJALGHM_quantity = (int)_IDLHJIOMJBK_data[AFEHLCGHAEE_Strings.BPNPBJALGHM_quantity];
    }
}

public class KPPFJJJAFFC : MCKCJMLOAFP_CurrencyInfo
{
	public List<long> JMBJMHLMGEF_inventory_ids; // 0x20

	// // RVA: 0xD8EAE0 Offset: 0xD8EAE0 VA: 0xD8EAE0
	public void KHEKNNFCAOI_Init(EDOHBJAPLPF_JsonData _IDLHJIOMJBK_data)
    {
        DPKCOKLMFMK(_IDLHJIOMJBK_data);
        if(_IDLHJIOMJBK_data.BBAJPINMOEP_Contains(AFEHLCGHAEE_Strings.EGPADBNAOKP_inventory_ids))
        {
            EDOHBJAPLPF_JsonData data = _IDLHJIOMJBK_data[AFEHLCGHAEE_Strings.EGPADBNAOKP_inventory_ids];
            JMBJMHLMGEF_inventory_ids = new List<long>(data.HNBFOAJIIAL_Count);
            for(int i = 0; i < data.HNBFOAJIIAL_Count; i++)
            {
                JMBJMHLMGEF_inventory_ids.Add((long)data[i]);
            }
        }
        else
            JMBJMHLMGEF_inventory_ids = null;
    }
}

public class ANGEDJODMKO : GJDFHLBONOL
{
	public string NCDPBLBDOCM_item_set_name; // 0x60

	// // RVA: 0xD53D8C Offset: 0xD53D8C VA: 0xD53D8C
	public void KHEKNNFCAOI_Init(EDOHBJAPLPF_JsonData _IDLHJIOMJBK_data)
    {
        DPKCOKLMFMK(_IDLHJIOMJBK_data);
        NCDPBLBDOCM_item_set_name = null;
        if(_IDLHJIOMJBK_data.BBAJPINMOEP_Contains(AFEHLCGHAEE_Strings.NCDPBLBDOCM_item_set_name))
        {
            NCDPBLBDOCM_item_set_name = (string)_IDLHJIOMJBK_data[AFEHLCGHAEE_Strings.NCDPBLBDOCM_item_set_name];
        }
    }

	// // RVA: 0xD53F04 Offset: 0xD53F04 VA: 0xD53F04
	public new void ODDIHGPONFL_Copy(GJDFHLBONOL GPBJHKLFCEP)
	{
		base.ODDIHGPONFL_Copy(GPBJHKLFCEP);
	}
}

public class BEAOCBFAHKF
{
	public List<ANGEDJODMKO> PJJFEAHIPGL_inventories = new List<ANGEDJODMKO>(); // 0x8
	public List<KPPFJJJAFFC> BBEPLKNMICJ_balances = new List<KPPFJJJAFFC>(); // 0xC
	public BOKJNFPGGIB EFHCKFKLJDK_purchased_virtual_currency = new BOKJNFPGGIB(); // 0x10
	public List<BOKJNFPGGIB> DPHEHNKLHEI_gained_virtual_currencies = new List<BOKJNFPGGIB>(); // 0x14
	public PFIJNPCEOIL JENBPPBNAHP_PlayerNormalLotFreeState = new PFIJNPCEOIL(); // 0x18

	// // RVA: 0xC718F4 Offset: 0xC718F4 VA: 0xC718F4
	public void KHEKNNFCAOI_Init(EDOHBJAPLPF_JsonData _IDLHJIOMJBK_data)
    { 
        if(_IDLHJIOMJBK_data.BBAJPINMOEP_Contains(AFEHLCGHAEE_Strings.PJJFEAHIPGL_inventories))
        {
            EDOHBJAPLPF_JsonData data = _IDLHJIOMJBK_data[AFEHLCGHAEE_Strings.PJJFEAHIPGL_inventories];
            PJJFEAHIPGL_inventories = new List<ANGEDJODMKO>(data.HNBFOAJIIAL_Count);
            for(int i = 0; i < data.HNBFOAJIIAL_Count; i++)
            {
                ANGEDJODMKO data2 = new ANGEDJODMKO();
                data2.KHEKNNFCAOI_Init(data[i]);
                PJJFEAHIPGL_inventories.Add(data2);
            }
        }
        if(_IDLHJIOMJBK_data.BBAJPINMOEP_Contains(AFEHLCGHAEE_Strings.BBEPLKNMICJ_balances))
        {
            EDOHBJAPLPF_JsonData data = _IDLHJIOMJBK_data[AFEHLCGHAEE_Strings.BBEPLKNMICJ_balances];
            BBEPLKNMICJ_balances = new List<KPPFJJJAFFC>(data.HNBFOAJIIAL_Count);
            for(int i = 0; i < data.HNBFOAJIIAL_Count; i++)
            {
                KPPFJJJAFFC data2 = new KPPFJJJAFFC();
                data2.KHEKNNFCAOI_Init(data[i]);
                BBEPLKNMICJ_balances.Add(data2);
            }
        }
        if(_IDLHJIOMJBK_data.BBAJPINMOEP_Contains(AFEHLCGHAEE_Strings.EFHCKFKLJDK_purchased_virtual_currency))
        {
            EFHCKFKLJDK_purchased_virtual_currency = new BOKJNFPGGIB();
            EFHCKFKLJDK_purchased_virtual_currency.KHEKNNFCAOI_Init(_IDLHJIOMJBK_data[AFEHLCGHAEE_Strings.EFHCKFKLJDK_purchased_virtual_currency]);
        }
        else
        {
            EFHCKFKLJDK_purchased_virtual_currency = null;
        }
        if(_IDLHJIOMJBK_data.BBAJPINMOEP_Contains(AFEHLCGHAEE_Strings.DPHEHNKLHEI_gained_virtual_currencies))
        {
            EDOHBJAPLPF_JsonData data = _IDLHJIOMJBK_data[AFEHLCGHAEE_Strings.DPHEHNKLHEI_gained_virtual_currencies];
            DPHEHNKLHEI_gained_virtual_currencies = new List<BOKJNFPGGIB>(data.HNBFOAJIIAL_Count);
            for(int i = 0; i < data.HNBFOAJIIAL_Count; i++)
            {
                BOKJNFPGGIB data2 = new BOKJNFPGGIB();
                data2.KHEKNNFCAOI_Init(data[i]);
                DPHEHNKLHEI_gained_virtual_currencies.Add(data2);
            }
        }
        else
        {
            DPHEHNKLHEI_gained_virtual_currencies = null;
        }
        if(_IDLHJIOMJBK_data.BBAJPINMOEP_Contains("player_normal_lot_free_state"))
        {
            JENBPPBNAHP_PlayerNormalLotFreeState.KHEKNNFCAOI_Init(_IDLHJIOMJBK_data["player_normal_lot_free_state"]);
        }
    }
}
