using UnityEngine;
using System.Collections.Generic;

public delegate bool FAPJEIOBPDG(List<string> OHNJJIMGKGK, EDOHBJAPLPF_JsonData NMICBJDPLOH);

public class HDPLHCDAFHA{}
public class HDPLHCDAFHA_RequestMaster : CACGCMBKHDI_Request
{
	public List<string> DFDLAIGFDAH; // 0x7C
	private bool OGLMMENAJFL_onSuccess; // 0x84

	public FAPJEIOBPDG MKGLJLCMGIB { get; set; } // JJMNHPMPMEN 0x80 //  CJEOCNPHGNM // MGABGLAGKCL
	public override bool EBPLLJGPFDA_HasResult { get { return OGLMMENAJFL_onSuccess; } } // HGPAELCGELL 0x1743458

	// RVA: 0x174328C Offset: 0x174328C VA: 0x174328C Slot: 12
	public override void DHLDNIEELHO()
    {
		EBGACDGNCAA_CallContext = SakashoMaster.GetMasters(DFDLAIGFDAH.ToArray(), this.DCKLDDCAJAP, this.MEOCKCJBDAD);
    } // Prepare request

	// RVA: 0x174339C Offset: 0x174339C VA: 0x174339C Slot: 13
	public override void MGFNKDPHFGI(MonoBehaviour DANMJLOBLIE) 
	{
		OGLMMENAJFL_onSuccess = false;
		BNJPAKLNOPA_WorkerThreadQueue.Add(this.DIAMDBHBKBH);
	}

	// RVA: 0x1743460 Offset: 0x1743460 VA: 0x1743460 Slot: 15
	public override void NLDKLFODOJJ()
    {
		return;
    }

	// RVA: 0x1743464 Offset: 0x1743464 VA: 0x1743464
	private void DIAMDBHBKBH()
	{
		string res = NGCAIEGPLKD_result;
		EDOHBJAPLPF_JsonData jsonData = IKPIMINCOPI_JsonMapper.PFAMKCGJKKL_ToObject(res);
		if(MKGLJLCMGIB != null)
		{
			bool val = MKGLJLCMGIB.Invoke(DFDLAIGFDAH, jsonData[AFEHLCGHAEE_Strings.NDFIEMPPMLF_master]);
			DLKLLHPLANH = !val;
		}
		OGLMMENAJFL_onSuccess = true;
	}
}
