
using System.Collections.Generic;
using UnityEngine;

[System.Obsolete("Use IDLAIOHLFDI_GetLoginBonuses", true)]
public class IDLAIOHLFDI { }
public class IDLAIOHLFDI_GetLoginBonuses : CACGCMBKHDI_Request
{
	public class GMCAMBDHIGJ
	{
		public List<MKCJNKIEADB> CEBOHGGJBMN = new List<MKCJNKIEADB>(); // 0x8
		public int CJNNMLLEKEF_PreviousPage; // 0xC
		public int GPPOJHNNINK_CurrentPage; // 0x10
		public int MDIBIIHAAPN_NextPage; // 0x14

		//// RVA: 0x11EBE90 Offset: 0x11EBE90 VA: 0x11EBE90
		public void KHEKNNFCAOI(EDOHBJAPLPF_JsonData IDLHJIOMJBK)
		{
			EDOHBJAPLPF_JsonData b = IDLHJIOMJBK[AFEHLCGHAEE_Strings.CEBOHGGJBMN_login_bonuses];
			CEBOHGGJBMN = new List<MKCJNKIEADB>(b.HNBFOAJIIAL_Count);
			for(int i = 0; i < b.HNBFOAJIIAL_Count; i++)
			{
				MKCJNKIEADB data = new MKCJNKIEADB();
				data.KHEKNNFCAOI(b[i]);
				CEBOHGGJBMN.Add(data);
			}
			CJNNMLLEKEF_PreviousPage = (int)IDLHJIOMJBK[AFEHLCGHAEE_Strings.CJNNMLLEKEF_previous_page];
			GPPOJHNNINK_CurrentPage = (int)IDLHJIOMJBK[AFEHLCGHAEE_Strings.GPPOJHNNINK_current_page];
			MDIBIIHAAPN_NextPage = (int)IDLHJIOMJBK[AFEHLCGHAEE_Strings.MDIBIIHAAPN_next_page];
		}
	}

	public int IGNIIEBMFIN_Page = 1; // 0x7C
	public int MLPLGFLKKLI_Ipp = 30; // 0x80

	public GMCAMBDHIGJ NFEAMMJIMPG { get; private set; } // 0x84 OHEIOONIIKB LFOJDJCNOHB KMKEGMGKCBA
	//public override bool EBPLLJGPFDA { get; }

	// RVA: 0x11EBB6C Offset: 0x11EBB6C VA: 0x11EBB6C Slot: 12
	public override void DHLDNIEELHO()
	{
		EBGACDGNCAA_CallContext = SakashoLoginBonus.GetLoginBonuses(IGNIIEBMFIN_Page, MLPLGFLKKLI_Ipp, DCKLDDCAJAP, MEOCKCJBDAD);
	}

	// RVA: 0x11EBC64 Offset: 0x11EBC64 VA: 0x11EBC64 Slot: 13
	public override void MGFNKDPHFGI(MonoBehaviour DANMJLOBLIE)
	{
		NFEAMMJIMPG = null;
		BNJPAKLNOPA_WorkerThreadQueue.Add(DIAMDBHBKBH);
	}

	// RVA: 0x11EBD20 Offset: 0x11EBD20 VA: 0x11EBD20 Slot: 14
	//public override bool HGPAELCGELL() { }

	//// RVA: 0x11EBD30 Offset: 0x11EBD30 VA: 0x11EBD30
	private void DIAMDBHBKBH()
	{
		NFEAMMJIMPG = new GMCAMBDHIGJ();
		NFEAMMJIMPG.KHEKNNFCAOI(IKPIMINCOPI_JsonMapper.PFAMKCGJKKL_ToObject(NGCAIEGPLKD_result));
	}
}
