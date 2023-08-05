
using UnityEngine;

[System.Obsolete("Use LNBLBFPAKPP_GetLineLinkageStatus", true)]
public class LNBLBFPAKPP { }
public class LNBLBFPAKPP_GetLineLinkageStatus : CACGCMBKHDI_Request
{
	public class GKGOHBEFKEE
	{
		public bool EFKMIECABBK_LineLinkage; // 0x8
		public int OOOIPFEGKFD_Version; // 0xC

		// RVA: 0x10BC580 Offset: 0x10BC580 VA: 0x10BC580
		public void KHEKNNFCAOI(EDOHBJAPLPF_JsonData IDLHJIOMJBK)
		{
			EFKMIECABBK_LineLinkage = (bool)IDLHJIOMJBK["line_linkage"];
			OOOIPFEGKFD_Version = 0;
			if (IDLHJIOMJBK.BBAJPINMOEP_Contains("line_linkage_version"))
				OOOIPFEGKFD_Version = (int)IDLHJIOMJBK["line_linkage_version"];
		}
	}

	public static bool JKHDMLDDJLG = false; // 0x0
	public static int FOLMJCMKDFM = -1; // 0x4

	public GKGOHBEFKEE NFEAMMJIMPG { get; private set; } // 0x7C OHEIOONIIKB LFOJDJCNOHB KMKEGMGKCBA

	// RVA: 0x10BC37C Offset: 0x10BC37C VA: 0x10BC37C Slot: 12
	public override void DHLDNIEELHO()
	{
		EBGACDGNCAA_CallContext = SakashoLine.GetLineLinkageStatus(DCKLDDCAJAP, MEOCKCJBDAD);
	}

	// RVA: 0x10BC458 Offset: 0x10BC458 VA: 0x10BC458 Slot: 13
	public override void MGFNKDPHFGI(MonoBehaviour DANMJLOBLIE)
	{
		NFEAMMJIMPG = new GKGOHBEFKEE();
		NFEAMMJIMPG.KHEKNNFCAOI(IKPIMINCOPI_JsonMapper.PFAMKCGJKKL_ToObject(NGCAIEGPLKD_result));
		Debug.Log(NGCAIEGPLKD_result);
	}
}
