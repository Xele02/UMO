
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public delegate void FEFLFHNKFCN(BEAOCBFAHKF _NFEAMMJIMPG_Result, int _KAPMOPMDHJE_label, int _BPNPBJALGHM_quantity, int _CPGFOBNKKBF_CurrencyId);

public class IGCPCHNCJCF
{
	public List<KBPDNHOKEKD_ProductId> MHKCPJDNJKI_products = new List<KBPDNHOKEKD_ProductId>(); // 0x8
	public int KAPMOPMDHJE_label; // 0xC
	public int APHNELOFGAK_CurrencyId; // 0x10

	// // RVA: 0x11F2D2C Offset: 0x11F2D2C VA: 0x11F2D2C
	public void COAIAEOOELG(int _APHNELOFGAK_CurrencyId, IMCBBOAFION _BHFHGFKBOHH_OnSuccess, DJBHIFLHJLK _AOCANKOMKFG_OnError)
	{
		MHKCPJDNJKI_products.Clear();
		this.APHNELOFGAK_CurrencyId = _APHNELOFGAK_CurrencyId;
		NEAPMMJKOKA_GetProducts req = NKGJPJPHLIF.HHCJCDFCLOB.IBLPICFDGOF_ServerRequester.IFFNCAFNEAG_AddRequest(new NEAPMMJKOKA_GetProducts());
		req.IPKCADIAAPG_Criteria = LCKOLEDFDAL.BAKNLGCIHAN(_APHNELOFGAK_CurrencyId);
		req.BHFHGFKBOHH_OnSuccess = (CACGCMBKHDI_Request JIPCHHHLOMM) =>
		{
			//0x11F32C8
			NEAPMMJKOKA_GetProducts r = JIPCHHHLOMM as NEAPMMJKOKA_GetProducts;
			for(int i = 0; i < r.NFEAMMJIMPG_Result.MHKCPJDNJKI_products.Count; i++)
			{
				MHKCPJDNJKI_products.Add(r.NFEAMMJIMPG_Result.MHKCPJDNJKI_products[i]);
			}
			_BHFHGFKBOHH_OnSuccess();
		};
		req.MOBEEPPKFLG_OnFail = (CACGCMBKHDI_Request JIPCHHHLOMM) =>
		{
			//0x11F3540
			_AOCANKOMKFG_OnError();
		};
	}

	// // RVA: 0x11F2F98 Offset: 0x11F2F98 VA: 0x11F2F98
	public KBPDNHOKEKD_ProductId LBDOLHGDIEB_Find(int _KAPMOPMDHJE_label)
    {
        return MHKCPJDNJKI_products.Find((KBPDNHOKEKD_ProductId _GHPLINIACBB_x) =>
        {
            //0x11F356C
            return _GHPLINIACBB_x.KAPMOPMDHJE_label == _KAPMOPMDHJE_label;
        });
    }

	// // RVA: 0x11F3098 Offset: 0x11F3098 VA: 0x11F3098
	public void GBMFNHOFGOP_Purchase(int _KAPMOPMDHJE_label, int _BPNPBJALGHM_quantity, FEFLFHNKFCN _BHFHGFKBOHH_OnSuccess, JFDNPFFOACP NIMPEHIECJH, DJBHIFLHJLK _AOCANKOMKFG_OnError)
	{
		N.a.StartCoroutineWatched(DMIHMJHAAAF_Co_Purchase(_KAPMOPMDHJE_label, _BPNPBJALGHM_quantity, _BHFHGFKBOHH_OnSuccess, NIMPEHIECJH, _AOCANKOMKFG_OnError));
	}

	// [IteratorStateMachineAttribute] // RVA: 0x6B9DD0 Offset: 0x6B9DD0 VA: 0x6B9DD0
	// // RVA: 0x11F310C Offset: 0x11F310C VA: 0x11F310C
	private IEnumerator DMIHMJHAAAF_Co_Purchase(int _KAPMOPMDHJE_label, int _BPNPBJALGHM_quantity, FEFLFHNKFCN _BHFHGFKBOHH_OnSuccess, JFDNPFFOACP NIMPEHIECJH, DJBHIFLHJLK _AOCANKOMKFG_OnError)
	{
		KBPDNHOKEKD_ProductId PPMJJBAGPOG;
		DOLDMCAMEOD_RequestRemainingForCurrencyIds PMNKDBLBFHM;
		CBMFOOHOAOE_Purchase NIEBENJFJDI;
		DOLDMCAMEOD_RequestRemainingForCurrencyIds AKAAHOAKKDF;

		//0x11F35E8
		object[] arg = new object[4]
		{
			JpStringLiterals.StringLiteral_11086, _KAPMOPMDHJE_label, ", quantity=", _BPNPBJALGHM_quantity
		};
		Debug.Log(string.Concat(arg));
		PPMJJBAGPOG = MHKCPJDNJKI_products.Find((KBPDNHOKEKD_ProductId _GHPLINIACBB_x) =>
		{
			//0x11F35AC
			return _GHPLINIACBB_x.KAPMOPMDHJE_label == _KAPMOPMDHJE_label;
		});
		if(PPMJJBAGPOG == null)
		{
			Debug.LogError(JpStringLiterals.StringLiteral_11088 + _KAPMOPMDHJE_label+" Currency : "+APHNELOFGAK_CurrencyId);
			NIMPEHIECJH();
			yield break;
		}
		long time = NKGJPJPHLIF.HHCJCDFCLOB.IBLPICFDGOF_ServerRequester.FJDBNGEPKHL_Time.KMEFBNBFJHI_GetServerTime();
		if(time >= PPMJJBAGPOG.KBFOIECIADN_opened_at)
		{
			if(PPMJJBAGPOG.EGBOHDFBAPB_closed_at >= time)
			{
				PMNKDBLBFHM = NKGJPJPHLIF.HHCJCDFCLOB.IBLPICFDGOF_ServerRequester.IFFNCAFNEAG_AddRequest(new DOLDMCAMEOD_RequestRemainingForCurrencyIds());
				PMNKDBLBFHM.CGCFENMHJIM_Ids = new List<int>();
				PMNKDBLBFHM.CGCFENMHJIM_Ids.Add(APHNELOFGAK_CurrencyId);
				//LAB_011f3a8c
				while(!PMNKDBLBFHM.PLOOEECNHFB_IsDone)
					yield return null;
				if(PMNKDBLBFHM.NPNNPNAIONN_IsError)
				{
					Debug.LogError(JpStringLiterals.StringLiteral_11090 + _KAPMOPMDHJE_label);
					_AOCANKOMKFG_OnError();
					yield break;
				}
				NIEBENJFJDI = NKGJPJPHLIF.HHCJCDFCLOB.IBLPICFDGOF_ServerRequester.IFFNCAFNEAG_AddRequest(new CBMFOOHOAOE_Purchase());
				NIEBENJFJDI.AFKAGFOFAHM_ProductId = PPMJJBAGPOG.PPFNGGCBJKC_id;
				NIEBENJFJDI.BPNPBJALGHM_quantity = _BPNPBJALGHM_quantity;
				NIEBENJFJDI.APHNELOFGAK_CurrencyId = APHNELOFGAK_CurrencyId;
				while(!NIEBENJFJDI.PLOOEECNHFB_IsDone)
					yield return null;
				if(!NIEBENJFJDI.NPNNPNAIONN_IsError)
				{
					AKAAHOAKKDF = NKGJPJPHLIF.HHCJCDFCLOB.IBLPICFDGOF_ServerRequester.IFFNCAFNEAG_AddRequest(new DOLDMCAMEOD_RequestRemainingForCurrencyIds());
					AKAAHOAKKDF.CGCFENMHJIM_Ids = CIOECGOMILE.HHCJCDFCLOB.NFGNKHONICJ();
					while(!AKAAHOAKKDF.PLOOEECNHFB_IsDone)
						yield return null;
					if(!AKAAHOAKKDF.NPNNPNAIONN_IsError)
					{
						CIOECGOMILE.HHCJCDFCLOB.DJICHKCLMCD_UpdateCurrencies(AKAAHOAKKDF.NFEAMMJIMPG_Result.BBEPLKNMICJ_balances);
						if(PPMJJBAGPOG.HMFDJHEEGNN_buy_limit > 0)
						{
							PPMJJBAGPOG.GIEBJDKLCDH_bought_quantity += _BPNPBJALGHM_quantity;
						}
						_BHFHGFKBOHH_OnSuccess(NIEBENJFJDI.NFEAMMJIMPG_Result, _KAPMOPMDHJE_label, _BPNPBJALGHM_quantity, APHNELOFGAK_CurrencyId);
						yield break;
					}
				}
				_AOCANKOMKFG_OnError();
				yield break;
			}
		}
		Debug.LogError(JpStringLiterals.StringLiteral_11089 + _KAPMOPMDHJE_label);
		NIMPEHIECJH();
	}
}
