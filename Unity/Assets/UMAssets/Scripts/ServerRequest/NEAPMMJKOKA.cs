
using System.Collections.Generic;
using UnityEngine;

[System.Obsolete("Use NEAPMMJKOKA_GetProducts", true)]
public class NEAPMMJKOKA { }
public class NEAPMMJKOKA_GetProducts : CACGCMBKHDI_Request
{
	public class DCNPODMDCHP
	{
		public int EMDMJBBKMHJ_Age; // 0x8
		public int GEFHAMEJHKD_BirthYear; // 0xC
		public int BDINKMHPCPK_BirthMonth; // 0x10

		// RVA: 0x1AE5808 Offset: 0x1AE5808 VA: 0x1AE5808
		public void KHEKNNFCAOI(EDOHBJAPLPF_JsonData IDLHJIOMJBK)
		{
			EMDMJBBKMHJ_Age = (int)IDLHJIOMJBK[AFEHLCGHAEE_Strings.EMDMJBBKMHJ_age];
			GEFHAMEJHKD_BirthYear = (int)IDLHJIOMJBK[AFEHLCGHAEE_Strings.GEFHAMEJHKD_birth_year];
			BDINKMHPCPK_BirthMonth = (int)IDLHJIOMJBK[AFEHLCGHAEE_Strings.BDINKMHPCPK_birth_month];
		}
	}

	public class OAAJHKBHBDG
	{
		public List<KBPDNHOKEKD_ProductId> MHKCPJDNJKI_Products; // 0x8
		public int MDIBIIHAAPN_NextPage; // 0xC
		public int CJNNMLLEKEF_PreviousPage; // 0x10
		public int GPPOJHNNINK_CurrentPage; // 0x14
		public DCNPODMDCHP NGGGMCHJONH_PlayerBirthday; // 0x18

		// RVA: 0x1AE5380 Offset: 0x1AE5380 VA: 0x1AE5380
		public void KHEKNNFCAOI(EDOHBJAPLPF_JsonData IDLHJIOMJBK)
		{
			CJNNMLLEKEF_PreviousPage = (int)IDLHJIOMJBK[AFEHLCGHAEE_Strings.CJNNMLLEKEF_previous_page];
			MDIBIIHAAPN_NextPage = (int)IDLHJIOMJBK[AFEHLCGHAEE_Strings.MDIBIIHAAPN_next_page];
			GPPOJHNNINK_CurrentPage = (int)IDLHJIOMJBK[AFEHLCGHAEE_Strings.GPPOJHNNINK_current_page];
			EDOHBJAPLPF_JsonData p = IDLHJIOMJBK[AFEHLCGHAEE_Strings.MHKCPJDNJKI_products];
			MHKCPJDNJKI_Products = new List<KBPDNHOKEKD_ProductId>(p.HNBFOAJIIAL_Count);
			for(int i = 0; i < p.HNBFOAJIIAL_Count; i++)
			{
				KBPDNHOKEKD_ProductId data = new KBPDNHOKEKD_ProductId();
				data.KHEKNNFCAOI(p[i]);
				MHKCPJDNJKI_Products.Add(data);
			}
			if(IDLHJIOMJBK.BBAJPINMOEP_Contains(AFEHLCGHAEE_Strings.NGGGMCHJONH_player_birthday))
			{
				NGGGMCHJONH_PlayerBirthday = new DCNPODMDCHP();
				NGGGMCHJONH_PlayerBirthday.KHEKNNFCAOI(IDLHJIOMJBK[AFEHLCGHAEE_Strings.NGGGMCHJONH_player_birthday]);
			}
		}
	}

	public SakashoProductCriteria IPKCADIAAPG_Criteria; // 0x7C
	public int IGNIIEBMFIN_Page = 1; // 0x80
	public int MLPLGFLKKLI_Ipp = 30; // 0x84

	public override bool OIDCBBGLPHL { get { return true; } } //0x1AE4BE0 GINMIBJOABO
	public OAAJHKBHBDG NFEAMMJIMPG { get; private set; } // 0x88 OHEIOONIIKB LFOJDJCNOHB KMKEGMGKCBA

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
	public override void MGFNKDPHFGI(MonoBehaviour DANMJLOBLIE)
	{
		NFEAMMJIMPG = new OAAJHKBHBDG();
		NFEAMMJIMPG.KHEKNNFCAOI(IKPIMINCOPI_JsonMapper.PFAMKCGJKKL_ToObject(NGCAIEGPLKD_result));
	}
}
