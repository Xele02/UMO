
using System.Collections.Generic;

public class GMHKBJLIILI
{
	public int PPFNGGCBJKC_id; // 0x8
	public string BPEAIOBHMFD_name_for_apis; // 0xC
	public List<long> COGMPENEPBD_InventoryIds; // 0x10
	public List<GJDFHLBONOL> PJJFEAHIPGL_inventories; // 0x14
	public int HMFFHLPNMPH_count; // 0x18
	public string OPFGFINHFCE_name; // 0x1C
	public ANPGILOLNFK.CDOGFBNLIPG CKHOBDIKJFN_Type; // 0x20

	//// RVA: 0xAB6980 Offset: 0xAB6980 VA: 0xAB6980
	public void KHEKNNFCAOI_Init(EDOHBJAPLPF_JsonData _IDLHJIOMJBK_data)
	{
		PPFNGGCBJKC_id = (int)_IDLHJIOMJBK_data[AFEHLCGHAEE_Strings.PPFNGGCBJKC_id];
		BPEAIOBHMFD_name_for_apis = (string)_IDLHJIOMJBK_data[AFEHLCGHAEE_Strings.BPEAIOBHMFD_name_for_apis];
		CKHOBDIKJFN_Type = ANPGILOLNFK.OLMFIANJBOB_GetType(BPEAIOBHMFD_name_for_apis);
		EDOHBJAPLPF_JsonData list = _IDLHJIOMJBK_data[AFEHLCGHAEE_Strings.EGPADBNAOKP_inventory_ids];
		COGMPENEPBD_InventoryIds = new List<long>(list.HNBFOAJIIAL_Count);
		for(int i = 0; i < list.HNBFOAJIIAL_Count; i++)
		{
			COGMPENEPBD_InventoryIds.Add((long)list[i]);
		}
		list = _IDLHJIOMJBK_data[AFEHLCGHAEE_Strings.PJJFEAHIPGL_inventories];
		PJJFEAHIPGL_inventories = new List<GJDFHLBONOL>(list.HNBFOAJIIAL_Count);
		for(int i = 0; i < list.HNBFOAJIIAL_Count; i++)
		{
			GJDFHLBONOL data = new GJDFHLBONOL();
			data.DPKCOKLMFMK(list[i]);
			PJJFEAHIPGL_inventories.Add(data);
		}
		HMFFHLPNMPH_count = (int)_IDLHJIOMJBK_data[AFEHLCGHAEE_Strings.HMFFHLPNMPH_count];
		OPFGFINHFCE_name = (string)_IDLHJIOMJBK_data[AFEHLCGHAEE_Strings.OPFGFINHFCE_name];
	}
}
