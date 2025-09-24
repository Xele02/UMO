
using System.Collections.Generic;
using UnityEngine;

[System.Obsolete("Use IDLAIOHLFDI_GetLoginBonuses", true)]
public class IDLAIOHLFDI { }
public class IDLAIOHLFDI_GetLoginBonuses : CACGCMBKHDI_Request
{
	public class GMCAMBDHIGJ
	{
		public List<MKCJNKIEADB> CEBOHGGJBMN_login_bonuses = new List<MKCJNKIEADB>(); // 0x8
		public int CJNNMLLEKEF_previous_page; // 0xC
		public int GPPOJHNNINK_current_page; // 0x10
		public int MDIBIIHAAPN_next_page; // 0x14

		//// RVA: 0x11EBE90 Offset: 0x11EBE90 VA: 0x11EBE90
		public void KHEKNNFCAOI_Init(EDOHBJAPLPF_JsonData _IDLHJIOMJBK_data)
		{
			EDOHBJAPLPF_JsonData b = _IDLHJIOMJBK_data[AFEHLCGHAEE_Strings.CEBOHGGJBMN_login_bonuses];
			CEBOHGGJBMN_login_bonuses = new List<MKCJNKIEADB>(b.HNBFOAJIIAL_Count);
			for(int i = 0; i < b.HNBFOAJIIAL_Count; i++)
			{
				MKCJNKIEADB data = new MKCJNKIEADB();
				data.KHEKNNFCAOI_Init(b[i]);
				CEBOHGGJBMN_login_bonuses.Add(data);
			}
			CJNNMLLEKEF_previous_page = (int)_IDLHJIOMJBK_data[AFEHLCGHAEE_Strings.CJNNMLLEKEF_previous_page];
			GPPOJHNNINK_current_page = (int)_IDLHJIOMJBK_data[AFEHLCGHAEE_Strings.GPPOJHNNINK_current_page];
			MDIBIIHAAPN_next_page = (int)_IDLHJIOMJBK_data[AFEHLCGHAEE_Strings.MDIBIIHAAPN_next_page];
		}
	}

	public int IGNIIEBMFIN_Page = 1; // 0x7C
	public int MLPLGFLKKLI_Ipp = 30; // 0x80

	public GMCAMBDHIGJ NFEAMMJIMPG_Result { get; private set; } // 0x84 OHEIOONIIKB LFOJDJCNOHB KMKEGMGKCBA
	public override bool EBPLLJGPFDA_HasResult { get { return NFEAMMJIMPG_Result != null; } } // 0x11EBD20 HGPAELCGELL

	// RVA: 0x11EBB6C Offset: 0x11EBB6C VA: 0x11EBB6C Slot: 12
	public override void DHLDNIEELHO()
	{
		EBGACDGNCAA_CallContext = SakashoLoginBonus.GetLoginBonuses(IGNIIEBMFIN_Page, MLPLGFLKKLI_Ipp, DCKLDDCAJAP, MEOCKCJBDAD);
	}

	// RVA: 0x11EBC64 Offset: 0x11EBC64 VA: 0x11EBC64 Slot: 13
	public override void MGFNKDPHFGI(MonoBehaviour _DANMJLOBLIE_mb)
	{
		NFEAMMJIMPG_Result = null;
		BNJPAKLNOPA_WorkerThreadQueue.Add(DIAMDBHBKBH);
	}

	//// RVA: 0x11EBD30 Offset: 0x11EBD30 VA: 0x11EBD30
	private void DIAMDBHBKBH()
	{
		GMCAMBDHIGJ res = new GMCAMBDHIGJ();
		res.KHEKNNFCAOI_Init(IKPIMINCOPI_JsonMapper.PFAMKCGJKKL_ToObject(NGCAIEGPLKD_result));
		NFEAMMJIMPG_Result = res;
	}
}
