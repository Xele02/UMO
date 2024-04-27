
using System.Collections.Generic;

public class GMHKBJLIILI
{
	public int PPFNGGCBJKC_Id; // 0x8
	public string BPEAIOBHMFD_NameForApis; // 0xC
	public List<long> COGMPENEPBD_InventoryIds; // 0x10
	public List<GJDFHLBONOL> PJJFEAHIPGL_Inventories; // 0x14
	public int HMFFHLPNMPH_Count; // 0x18
	public string OPFGFINHFCE_Name; // 0x1C
	public ANPGILOLNFK.CDOGFBNLIPG CKHOBDIKJFN_Type; // 0x20

	//// RVA: 0xAB6980 Offset: 0xAB6980 VA: 0xAB6980
	public void KHEKNNFCAOI(EDOHBJAPLPF_JsonData IDLHJIOMJBK)
	{
		PPFNGGCBJKC_Id = (int)IDLHJIOMJBK[AFEHLCGHAEE_Strings.PPFNGGCBJKC_Id];
		BPEAIOBHMFD_NameForApis = (string)IDLHJIOMJBK[AFEHLCGHAEE_Strings.BPEAIOBHMFD_name_for_apis];
		CKHOBDIKJFN_Type = ANPGILOLNFK.OLMFIANJBOB_GetType(BPEAIOBHMFD_NameForApis);
		EDOHBJAPLPF_JsonData list = IDLHJIOMJBK[AFEHLCGHAEE_Strings.EGPADBNAOKP_inventory_ids];
		COGMPENEPBD_InventoryIds = new List<long>(list.HNBFOAJIIAL_Count);
		for(int i = 0; i < list.HNBFOAJIIAL_Count; i++)
		{
			COGMPENEPBD_InventoryIds.Add((long)list[i]);
		}
		list = IDLHJIOMJBK[AFEHLCGHAEE_Strings.PJJFEAHIPGL_inventories];
		PJJFEAHIPGL_Inventories = new List<GJDFHLBONOL>(list.HNBFOAJIIAL_Count);
		for(int i = 0; i < list.HNBFOAJIIAL_Count; i++)
		{
			GJDFHLBONOL data = new GJDFHLBONOL();
			data.DPKCOKLMFMK(list[i]);
			PJJFEAHIPGL_Inventories.Add(data);
		}
		HMFFHLPNMPH_Count = (int)IDLHJIOMJBK[AFEHLCGHAEE_Strings.HMFFHLPNMPH_count];
		OPFGFINHFCE_Name = (string)IDLHJIOMJBK[AFEHLCGHAEE_Strings.OPFGFINHFCE_name];
	}
}
