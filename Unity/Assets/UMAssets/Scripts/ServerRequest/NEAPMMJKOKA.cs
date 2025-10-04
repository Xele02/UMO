
using System.Collections.Generic;
using UnityEngine;

[System.Obsolete("Use NEAPMMJKOKA_GetProducts", true)]
public class NEAPMMJKOKA { }
public class NEAPMMJKOKA_GetProducts : CACGCMBKHDI_Request
{
	public class DCNPODMDCHP
	{
		public int EMDMJBBKMHJ_age; // 0x8
		public int GEFHAMEJHKD_birth_year; // 0xC
		public int BDINKMHPCPK_birth_month; // 0x10

		// RVA: 0x1AE5808 Offset: 0x1AE5808 VA: 0x1AE5808
		public void KHEKNNFCAOI_Init(EDOHBJAPLPF_JsonData _IDLHJIOMJBK_data)
		{
			EMDMJBBKMHJ_age = (int)_IDLHJIOMJBK_data[AFEHLCGHAEE_Strings.EMDMJBBKMHJ_age];
			GEFHAMEJHKD_birth_year = (int)_IDLHJIOMJBK_data[AFEHLCGHAEE_Strings.GEFHAMEJHKD_birth_year];
			BDINKMHPCPK_birth_month = (int)_IDLHJIOMJBK_data[AFEHLCGHAEE_Strings.BDINKMHPCPK_birth_month];
		}
	}

	public class OAAJHKBHBDG
	{
		public List<KBPDNHOKEKD_ProductId> MHKCPJDNJKI_products; // 0x8
		public int MDIBIIHAAPN_next_page; // 0xC
		public int CJNNMLLEKEF_previous_page; // 0x10
		public int GPPOJHNNINK_current_page; // 0x14
		public DCNPODMDCHP NGGGMCHJONH_player_birthday; // 0x18

		// RVA: 0x1AE5380 Offset: 0x1AE5380 VA: 0x1AE5380
		public void KHEKNNFCAOI_Init(EDOHBJAPLPF_JsonData _IDLHJIOMJBK_data)
		{
			CJNNMLLEKEF_previous_page = (int)_IDLHJIOMJBK_data[AFEHLCGHAEE_Strings.CJNNMLLEKEF_previous_page];
			MDIBIIHAAPN_next_page = (int)_IDLHJIOMJBK_data[AFEHLCGHAEE_Strings.MDIBIIHAAPN_next_page];
			GPPOJHNNINK_current_page = (int)_IDLHJIOMJBK_data[AFEHLCGHAEE_Strings.GPPOJHNNINK_current_page];
			EDOHBJAPLPF_JsonData p = _IDLHJIOMJBK_data[AFEHLCGHAEE_Strings.MHKCPJDNJKI_products];
			MHKCPJDNJKI_products = new List<KBPDNHOKEKD_ProductId>(p.HNBFOAJIIAL_Count);
			for(int i = 0; i < p.HNBFOAJIIAL_Count; i++)
			{
				KBPDNHOKEKD_ProductId data = new KBPDNHOKEKD_ProductId();
				data.KHEKNNFCAOI_Init(p[i]);
				MHKCPJDNJKI_products.Add(data);
			}
			if(_IDLHJIOMJBK_data.BBAJPINMOEP_Contains(AFEHLCGHAEE_Strings.NGGGMCHJONH_player_birthday))
			{
				NGGGMCHJONH_player_birthday = new DCNPODMDCHP();
				NGGGMCHJONH_player_birthday.KHEKNNFCAOI_Init(_IDLHJIOMJBK_data[AFEHLCGHAEE_Strings.NGGGMCHJONH_player_birthday]);
			}
		}
	}

	public SakashoProductCriteria IPKCADIAAPG_Criteria; // 0x7C
	public int IGNIIEBMFIN_Page = 1; // 0x80
	public int MLPLGFLKKLI_Ipp = 30; // 0x84

	public override bool OIDCBBGLPHL { get { return true; } } //0x1AE4BE0 GINMIBJOABO_bgs
	public OAAJHKBHBDG NFEAMMJIMPG_Result { get; private set; } // 0x88 OHEIOONIIKB_bgs LFOJDJCNOHB_bgs KMKEGMGKCBA_bgs

	// RVA: 0x1AE4BF8 Offset: 0x1AE4BF8 VA: 0x1AE4BF8 Slot: 12
	public override void DHLDNIEELHO()
	{
		object[] obj = new object[11]
		{
			"SakashoPayment.GetProducts(CurrencyId=",
			IPKCADIAAPG_Criteria.CurrencyId,
			",ProductType=",
			IPKCADIAAPG_Criteria.ProductType,
			",label=",
			IPKCADIAAPG_Criteria.Label,
			",page=",
			IGNIIEBMFIN_Page,
			",ipp=",
			MLPLGFLKKLI_Ipp,
			")"
		};
		Debug.Log(string.Concat(obj));
		EBGACDGNCAA_CallContext = SakashoPayment.GetProducts(IPKCADIAAPG_Criteria, IGNIIEBMFIN_Page, MLPLGFLKKLI_Ipp, DCKLDDCAJAP, MEOCKCJBDAD);
	}

	// RVA: 0x1AE52A0 Offset: 0x1AE52A0 VA: 0x1AE52A0 Slot: 13
	public override void MGFNKDPHFGI(MonoBehaviour _DANMJLOBLIE_mb)
	{
		NFEAMMJIMPG_Result = new OAAJHKBHBDG();
		NFEAMMJIMPG_Result.KHEKNNFCAOI_Init(IKPIMINCOPI_JsonMapper.PFAMKCGJKKL_ToObject(NGCAIEGPLKD_result));
	}
}
