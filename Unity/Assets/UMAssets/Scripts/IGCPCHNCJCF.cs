
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public delegate void FEFLFHNKFCN(BEAOCBFAHKF NFEAMMJIMPG, int KAPMOPMDHJE, int _BPNPBJALGHM_Quantity, int _CPGFOBNKKBF_CurrencyId);

public class IGCPCHNCJCF
{
	public List<KBPDNHOKEKD_ProductId> MHKCPJDNJKI = new List<KBPDNHOKEKD_ProductId>(); // 0x8
	public int KAPMOPMDHJE; // 0xC
	public int APHNELOFGAK_CurrencyId; // 0x10

	// // RVA: 0x11F2D2C Offset: 0x11F2D2C VA: 0x11F2D2C
	public void COAIAEOOELG(int _APHNELOFGAK_CurrencyId, IMCBBOAFION _BHFHGFKBOHH_OnSuccess, DJBHIFLHJLK _AOCANKOMKFG_OnError)
	{
		MHKCPJDNJKI.Clear();
		this.APHNELOFGAK_CurrencyId = _APHNELOFGAK_CurrencyId;
		NEAPMMJKOKA_GetProducts req = NKGJPJPHLIF.HHCJCDFCLOB.IBLPICFDGOF_ServerRequester.IFFNCAFNEAG_AddRequest(new NEAPMMJKOKA_GetProducts());
		req.IPKCADIAAPG_Criteria = LCKOLEDFDAL.BAKNLGCIHAN(_APHNELOFGAK_CurrencyId);
		req.BHFHGFKBOHH_OnSuccess = (CACGCMBKHDI_Request JIPCHHHLOMM) =>
		{
			//0x11F32C8
			NEAPMMJKOKA_GetProducts r = JIPCHHHLOMM as NEAPMMJKOKA_GetProducts;
			for(int i = 0; i < r.NFEAMMJIMPG.MHKCPJDNJKI_Products.Count; i++)
			{
				MHKCPJDNJKI.Add(r.NFEAMMJIMPG.MHKCPJDNJKI_Products[i]);
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
	public KBPDNHOKEKD_ProductId LBDOLHGDIEB(int KAPMOPMDHJE)
    {
        return MHKCPJDNJKI.Find((KBPDNHOKEKD_ProductId _GHPLINIACBB_x) =>
        {
            //0x11F356C
            return _GHPLINIACBB_x.KAPMOPMDHJE_Label == KAPMOPMDHJE;
        });
    }

	// // RVA: 0x11F3098 Offset: 0x11F3098 VA: 0x11F3098
	public void GBMFNHOFGOP_Purchase(int KAPMOPMDHJE, int _BPNPBJALGHM_Quantity, FEFLFHNKFCN _BHFHGFKBOHH_OnSuccess, JFDNPFFOACP NIMPEHIECJH, DJBHIFLHJLK _AOCANKOMKFG_OnError)
	{
		N.a.StartCoroutineWatched(DMIHMJHAAAF_Co_Purchase(KAPMOPMDHJE, _BPNPBJALGHM_Quantity, _BHFHGFKBOHH_OnSuccess, NIMPEHIECJH, _AOCANKOMKFG_OnError));
	}

	// [IteratorStateMachineAttribute] // RVA: 0x6B9DD0 Offset: 0x6B9DD0 VA: 0x6B9DD0
	// // RVA: 0x11F310C Offset: 0x11F310C VA: 0x11F310C
	private IEnumerator DMIHMJHAAAF_Co_Purchase(int KAPMOPMDHJE, int _BPNPBJALGHM_Quantity, FEFLFHNKFCN _BHFHGFKBOHH_OnSuccess, JFDNPFFOACP NIMPEHIECJH, DJBHIFLHJLK _AOCANKOMKFG_OnError)
	{
		KBPDNHOKEKD_ProductId PPMJJBAGPOG;
		DOLDMCAMEOD_RequestRemainingForCurrencyIds PMNKDBLBFHM;
		CBMFOOHOAOE_Purchase NIEBENJFJDI;
		DOLDMCAMEOD_RequestRemainingForCurrencyIds AKAAHOAKKDF;

		//0x11F35E8
		object[] arg = new object[4]
		{
			JpStringLiterals.StringLiteral_11086, KAPMOPMDHJE, ", quantity=", _BPNPBJALGHM_Quantity
		};
		Debug.Log(string.Concat(arg));
		PPMJJBAGPOG = MHKCPJDNJKI.Find((KBPDNHOKEKD_ProductId _GHPLINIACBB_x) =>
		{
			//0x11F35AC
			return _GHPLINIACBB_x.KAPMOPMDHJE_Label == KAPMOPMDHJE;
		});
		if(PPMJJBAGPOG == null)
		{
			Debug.LogError(JpStringLiterals.StringLiteral_11088 + KAPMOPMDHJE+" Currency : "+APHNELOFGAK_CurrencyId);
			NIMPEHIECJH();
			yield break;
		}
		long time = NKGJPJPHLIF.HHCJCDFCLOB.IBLPICFDGOF_ServerRequester.FJDBNGEPKHL_Time.KMEFBNBFJHI_GetServerTime();
		if(time >= PPMJJBAGPOG.KBFOIECIADN_OpenedAt)
		{
			if(PPMJJBAGPOG.EGBOHDFBAPB_ClosedAt >= time)
			{
				PMNKDBLBFHM = NKGJPJPHLIF.HHCJCDFCLOB.IBLPICFDGOF_ServerRequester.IFFNCAFNEAG_AddRequest(new DOLDMCAMEOD_RequestRemainingForCurrencyIds());
				PMNKDBLBFHM.CGCFENMHJIM_Ids = new List<int>();
				PMNKDBLBFHM.CGCFENMHJIM_Ids.Add(APHNELOFGAK_CurrencyId);
				//LAB_011f3a8c
				while(!PMNKDBLBFHM.PLOOEECNHFB_IsDone)
					yield return null;
				if(PMNKDBLBFHM.NPNNPNAIONN_IsError)
				{
					Debug.LogError(JpStringLiterals.StringLiteral_11090 + KAPMOPMDHJE);
					_AOCANKOMKFG_OnError();
					yield break;
				}
				NIEBENJFJDI = NKGJPJPHLIF.HHCJCDFCLOB.IBLPICFDGOF_ServerRequester.IFFNCAFNEAG_AddRequest(new CBMFOOHOAOE_Purchase());
				NIEBENJFJDI.AFKAGFOFAHM_ProductId = PPMJJBAGPOG.PPFNGGCBJKC_Id;
				NIEBENJFJDI.BPNPBJALGHM_Quantity = _BPNPBJALGHM_Quantity;
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
						CIOECGOMILE.HHCJCDFCLOB.DJICHKCLMCD_UpdateCurrencies(AKAAHOAKKDF.NFEAMMJIMPG.BBEPLKNMICJ_Balances);
						if(PPMJJBAGPOG.HMFDJHEEGNN_BuyLimit > 0)
						{
							PPMJJBAGPOG.GIEBJDKLCDH_BoughtQuantity += _BPNPBJALGHM_Quantity;
						}
						_BHFHGFKBOHH_OnSuccess(NIEBENJFJDI.NFEAMMJIMPG, KAPMOPMDHJE, _BPNPBJALGHM_Quantity, APHNELOFGAK_CurrencyId);
						yield break;
					}
				}
				_AOCANKOMKFG_OnError();
				yield break;
			}
		}
		Debug.LogError(JpStringLiterals.StringLiteral_11089 + KAPMOPMDHJE);
		NIMPEHIECJH();
	}
}
