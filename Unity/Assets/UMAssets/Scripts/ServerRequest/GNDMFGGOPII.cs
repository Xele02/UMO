
using System.Collections.Generic;
using UnityEngine;

[System.Obsolete("Use GNDMFGGOPII_GetInventoryRecords", true)]
public class GNDMFGGOPII {}
public class GNDMFGGOPII_GetInventoryRecords : CACGCMBKHDI_Request
{
    public class MOPKBHCNLLJ
    {
        public List<GJDFHLBONOL> PJJFEAHIPGL; // 0x8

        // RVA: 0xAB8938 Offset: 0xAB8938 VA: 0xAB8938
        public void KHEKNNFCAOI(EDOHBJAPLPF_JsonData IDLHJIOMJBK)
        {
            EDOHBJAPLPF_JsonData data = IDLHJIOMJBK[AFEHLCGHAEE_Strings.PJJFEAHIPGL_inventories];
            PJJFEAHIPGL = new List<GJDFHLBONOL>(data.HNBFOAJIIAL_Count);
            for(int i = 0; i < data.HNBFOAJIIAL_Count; i++)
            {
                GJDFHLBONOL inv = new GJDFHLBONOL();
                inv.DPKCOKLMFMK(data[i]);
                PJJFEAHIPGL.Add(inv);
            }
        }
    }

	public List<long> AMOMNBEAHBF; // 0x7C

	public MOPKBHCNLLJ NFEAMMJIMPG { get; private set; } // 0x80 LFOJDJCNOHB KMKEGMGKCBA

	// RVA: 0xAB8748 Offset: 0xAB8748 VA: 0xAB8748 Slot: 12
	public override void DHLDNIEELHO()
    {
        EBGACDGNCAA_CallContext = SakashoInventory.GetInventoryRecords(AMOMNBEAHBF.ToArray(), DCKLDDCAJAP, MEOCKCJBDAD);
    }

	// RVA: 0xAB8858 Offset: 0xAB8858 VA: 0xAB8858 Slot: 13
	public override void MGFNKDPHFGI(MonoBehaviour DANMJLOBLIE)
    {
        NFEAMMJIMPG = new MOPKBHCNLLJ();
        NFEAMMJIMPG.KHEKNNFCAOI(IKPIMINCOPI_JsonMapper.PFAMKCGJKKL_ToObject(NGCAIEGPLKD_result));
    }
}
