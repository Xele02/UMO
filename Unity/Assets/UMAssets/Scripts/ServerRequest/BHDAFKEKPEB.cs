
using System.Collections.Generic;
using UnityEngine;
using XeApp.Core.WorkerThread;

public class HBFCGCGDINM
{
	public List<KOPCFBCDBPC> JOMCOLHEBBI; // 0x8

	// RVA: 0x173F4A4 Offset: 0x173F4A4 VA: 0x173F4A4
	public void KHEKNNFCAOI(EDOHBJAPLPF_JsonData IDLHJIOMJBK)
	{
		EDOHBJAPLPF_JsonData d = IDLHJIOMJBK[AFEHLCGHAEE_Strings.JOMCOLHEBBI_step_up_lots];
		JOMCOLHEBBI = new List<KOPCFBCDBPC>(d.HNBFOAJIIAL_Count);
		for(int i = 0; i < d.HNBFOAJIIAL_Count; i++)
		{
			KOPCFBCDBPC data = new KOPCFBCDBPC();
			data.KHEKNNFCAOI(d[i]);
			JOMCOLHEBBI.Add(data);
		}
	}
}


[System.Obsolete("Use BHDAFKEKPEB_GetStepUpLotRecords", true)]
public class BHDAFKEKPEB { }
public class BHDAFKEKPEB_GetStepUpLotRecords : CACGCMBKHDI_Request
{
	public HBFCGCGDINM NFEAMMJIMPG { get; private set; } // 0x7C OHEIOONIIKB LFOJDJCNOHB KMKEGMGKCBA
	public override bool EBPLLJGPFDA_HasResult { get { return NFEAMMJIMPG != null; } } // 0xC7EF48 HGPAELCGELL

	// RVA: 0xC7EDB0 Offset: 0xC7EDB0 VA: 0xC7EDB0 Slot: 12
	public override void DHLDNIEELHO()
	{
		EBGACDGNCAA_CallContext = SakashoStepUpLot.GetStepUpLotRecords(DCKLDDCAJAP, MEOCKCJBDAD);
	}

	// RVA: 0xC7EE8C Offset: 0xC7EE8C VA: 0xC7EE8C Slot: 13
	public override void MGFNKDPHFGI(MonoBehaviour DANMJLOBLIE)
	{
		NFEAMMJIMPG = null;
		BNJPAKLNOPA_WorkerThreadQueue.Add(DIAMDBHBKBH);
	}

	//// RVA: 0xC7EF58 Offset: 0xC7EF58 VA: 0xC7EF58
	private void DIAMDBHBKBH()
	{
		HBFCGCGDINM d = new HBFCGCGDINM();
		d.KHEKNNFCAOI(IKPIMINCOPI_JsonMapper.PFAMKCGJKKL_ToObject(NGCAIEGPLKD_result));
		NFEAMMJIMPG = d;
	}
}
