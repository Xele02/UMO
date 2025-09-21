
using System.Collections.Generic;
using UnityEngine;

[System.Obsolete("Use GNDMFGGOPII_GetInventoryRecords", true)]
public class GNDMFGGOPII {}
public class GNDMFGGOPII_GetInventoryRecords : CACGCMBKHDI_Request
{
    public class MOPKBHCNLLJ
    {
        public List<GJDFHLBONOL> PJJFEAHIPGL_inventories; // 0x8

        // RVA: 0xAB8938 Offset: 0xAB8938 VA: 0xAB8938
        public void KHEKNNFCAOI_Init(EDOHBJAPLPF_JsonData _IDLHJIOMJBK_Data)
        {
            EDOHBJAPLPF_JsonData data = _IDLHJIOMJBK_Data[AFEHLCGHAEE_Strings.PJJFEAHIPGL_inventories];
            PJJFEAHIPGL_inventories = new List<GJDFHLBONOL>(data.HNBFOAJIIAL_Count);
            for(int i = 0; i < data.HNBFOAJIIAL_Count; i++)
            {
                GJDFHLBONOL inv = new GJDFHLBONOL();
                inv.DPKCOKLMFMK(data[i]);
                PJJFEAHIPGL_inventories.Add(inv);
            }
        }
    }

	public List<long> AMOMNBEAHBF_InventoryIds; // 0x7C

	public MOPKBHCNLLJ NFEAMMJIMPG_Result { get; private set; } // 0x80 LFOJDJCNOHB KMKEGMGKCBA

	// RVA: 0xAB8748 Offset: 0xAB8748 VA: 0xAB8748 Slot: 12
	public override void DHLDNIEELHO()
    {
        EBGACDGNCAA_CallContext = SakashoInventory.GetInventoryRecords(AMOMNBEAHBF_InventoryIds.ToArray(), DCKLDDCAJAP, MEOCKCJBDAD);
    }

	// RVA: 0xAB8858 Offset: 0xAB8858 VA: 0xAB8858 Slot: 13
	public override void MGFNKDPHFGI(MonoBehaviour _DANMJLOBLIE_mb)
    {
        NFEAMMJIMPG_Result = new MOPKBHCNLLJ();
        NFEAMMJIMPG_Result.KHEKNNFCAOI_Init(IKPIMINCOPI_JsonMapper.PFAMKCGJKKL_ToObject(NGCAIEGPLKD_result));
    }
}
