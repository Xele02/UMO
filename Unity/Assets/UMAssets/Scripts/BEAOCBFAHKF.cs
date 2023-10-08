
using System.Collections.Generic;

public class BOKJNFPGGIB // TypeDefIndex: 10380
{
	public int PPFNGGCBJKC_Id; // 0x8
	public string OPFGFINHFCE_name; // 0xC
	public string KLMPFGOCBHC_description; // 0x10
	public int BPNPBJALGHM_quantity; // 0x14

	// // RVA: 0x19CD790 Offset: 0x19CD790 VA: 0x19CD790
	public void KHEKNNFCAOI(EDOHBJAPLPF_JsonData IDLHJIOMJBK)
    {
        PPFNGGCBJKC_Id = (int)IDLHJIOMJBK[AFEHLCGHAEE_Strings.PPFNGGCBJKC_Id];
        OPFGFINHFCE_name = (string)IDLHJIOMJBK[AFEHLCGHAEE_Strings.OPFGFINHFCE_name];
        KLMPFGOCBHC_description = (string)IDLHJIOMJBK[AFEHLCGHAEE_Strings.KLMPFGOCBHC_description];
        BPNPBJALGHM_quantity = (int)IDLHJIOMJBK[AFEHLCGHAEE_Strings.BPNPBJALGHM_quantity];
    }
}

public class KPPFJJJAFFC : MCKCJMLOAFP_CurrencyInfo
{
	public List<long> JMBJMHLMGEF_inventory_ids; // 0x20

	// // RVA: 0xD8EAE0 Offset: 0xD8EAE0 VA: 0xD8EAE0
	public void KHEKNNFCAOI(EDOHBJAPLPF_JsonData IDLHJIOMJBK)
    {
        DPKCOKLMFMK(IDLHJIOMJBK);
        if(IDLHJIOMJBK.BBAJPINMOEP_Contains(AFEHLCGHAEE_Strings.EGPADBNAOKP_inventory_ids))
        {
            EDOHBJAPLPF_JsonData data = IDLHJIOMJBK[AFEHLCGHAEE_Strings.EGPADBNAOKP_inventory_ids];
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
	public void KHEKNNFCAOI(EDOHBJAPLPF_JsonData IDLHJIOMJBK)
    {
        DPKCOKLMFMK(IDLHJIOMJBK);
        NCDPBLBDOCM_item_set_name = null;
        if(IDLHJIOMJBK.BBAJPINMOEP_Contains(AFEHLCGHAEE_Strings.NCDPBLBDOCM_item_set_name))
        {
            NCDPBLBDOCM_item_set_name = (string)IDLHJIOMJBK[AFEHLCGHAEE_Strings.NCDPBLBDOCM_item_set_name];
        }
    }

	// // RVA: 0xD53F04 Offset: 0xD53F04 VA: 0xD53F04
	// public void ODDIHGPONFL(GJDFHLBONOL GPBJHKLFCEP) { }
}

public class BEAOCBFAHKF
{
	public List<ANGEDJODMKO> PJJFEAHIPGL_inventories = new List<ANGEDJODMKO>(); // 0x8
	public List<KPPFJJJAFFC> BBEPLKNMICJ_balances = new List<KPPFJJJAFFC>(); // 0xC
	public BOKJNFPGGIB EFHCKFKLJDK_purchased_virtual_currency = new BOKJNFPGGIB(); // 0x10
	public List<BOKJNFPGGIB> DPHEHNKLHEI_gained_virtual_currencies = new List<BOKJNFPGGIB>(); // 0x14
	public PFIJNPCEOIL JENBPPBNAHP_player_normal_lot_free_state = new PFIJNPCEOIL(); // 0x18

	// // RVA: 0xC718F4 Offset: 0xC718F4 VA: 0xC718F4
	public void KHEKNNFCAOI(EDOHBJAPLPF_JsonData IDLHJIOMJBK)
    { 
        if(IDLHJIOMJBK.BBAJPINMOEP_Contains(AFEHLCGHAEE_Strings.PJJFEAHIPGL_inventories))
        {
            EDOHBJAPLPF_JsonData data = IDLHJIOMJBK[AFEHLCGHAEE_Strings.PJJFEAHIPGL_inventories];
            PJJFEAHIPGL_inventories = new List<ANGEDJODMKO>(data.HNBFOAJIIAL_Count);
            for(int i = 0; i < data.HNBFOAJIIAL_Count; i++)
            {
                ANGEDJODMKO data2 = new ANGEDJODMKO();
                data2.KHEKNNFCAOI(data[i]);
                PJJFEAHIPGL_inventories.Add(data2);
            }
        }
        if(IDLHJIOMJBK.BBAJPINMOEP_Contains(AFEHLCGHAEE_Strings.BBEPLKNMICJ_balances))
        {
            EDOHBJAPLPF_JsonData data = IDLHJIOMJBK[AFEHLCGHAEE_Strings.BBEPLKNMICJ_balances];
            BBEPLKNMICJ_balances = new List<KPPFJJJAFFC>(data.HNBFOAJIIAL_Count);
            for(int i = 0; i < data.HNBFOAJIIAL_Count; i++)
            {
                KPPFJJJAFFC data2 = new KPPFJJJAFFC();
                data2.KHEKNNFCAOI(data[i]);
                BBEPLKNMICJ_balances.Add(data2);
            }
        }
        if(IDLHJIOMJBK.BBAJPINMOEP_Contains(AFEHLCGHAEE_Strings.EFHCKFKLJDK_purchased_virtual_currency))
        {
            EFHCKFKLJDK_purchased_virtual_currency = new BOKJNFPGGIB();
            EFHCKFKLJDK_purchased_virtual_currency.KHEKNNFCAOI(IDLHJIOMJBK[AFEHLCGHAEE_Strings.EFHCKFKLJDK_purchased_virtual_currency]);
        }
        else
        {
            EFHCKFKLJDK_purchased_virtual_currency = null;
        }
        if(IDLHJIOMJBK.BBAJPINMOEP_Contains(AFEHLCGHAEE_Strings.DPHEHNKLHEI_gained_virtual_currencies))
        {
            EDOHBJAPLPF_JsonData data = IDLHJIOMJBK[AFEHLCGHAEE_Strings.DPHEHNKLHEI_gained_virtual_currencies];
            DPHEHNKLHEI_gained_virtual_currencies = new List<BOKJNFPGGIB>(data.HNBFOAJIIAL_Count);
            for(int i = 0; i < data.HNBFOAJIIAL_Count; i++)
            {
                BOKJNFPGGIB data2 = new BOKJNFPGGIB();
                data2.KHEKNNFCAOI(data[i]);
                DPHEHNKLHEI_gained_virtual_currencies.Add(data2);
            }
        }
        else
        {
            DPHEHNKLHEI_gained_virtual_currencies = null;
        }
        if(IDLHJIOMJBK.BBAJPINMOEP_Contains("player_normal_lot_free_state"))
        {
            JENBPPBNAHP_player_normal_lot_free_state.KHEKNNFCAOI(IDLHJIOMJBK["player_normal_lot_free_state"]);
        }
    }
}
