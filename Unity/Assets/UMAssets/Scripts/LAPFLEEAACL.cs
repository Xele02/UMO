
using System.Collections;
using System.Collections.Generic;

public class LAPFLEEAACL
{
    public enum JCHBGAEFPHA
    {
        HJNNKCMLGFL_0_None = 0,
        NCKBNMCNDLC = 1,
        EANGJBHNNHF_2_Expired = 2,
    }

	public bool PLOOEECNHFB_IsDone; // 0x8
	public bool NPNNPNAIONN_IsError; // 0x9
	private List<KBPDNHOKEKD_ProductId> MHKCPJDNJKI_products; // 0xC
	public JKNGJFOBADP JANMJPOKLFL_InventoryUtil = new JKNGJFOBADP(); // 0x10
	public int PPECNOCKNMC_FullItemId; // 0x14
	private HHJHIFJIKAC_BonusVc.IJFKAIHFJLF_BonusType AIBKGHFBFCC_BonusType = /*2*/HHJHIFJIKAC_BonusVc.IJFKAIHFJLF_BonusType.JEPMLKCJCPK_2_Bonus_4001_4002; // 0x18

	// // RVA: 0xD945C4 Offset: 0xD945C4 VA: 0xD945C4
	public LAPFLEEAACL(HHJHIFJIKAC_BonusVc.IJFKAIHFJLF_BonusType _INDDJNMPONH_type)
    {
        AIBKGHFBFCC_BonusType = _INDDJNMPONH_type;
    }

	// // RVA: 0xD94650 Offset: 0xD94650 VA: 0xD94650
	public void OFKONDFPMLJ_GetProducts()
    {
		MHKCPJDNJKI_products = null;
		PPECNOCKNMC_FullItemId = 0;
		PLOOEECNHFB_IsDone = false;
		NPNNPNAIONN_IsError = false;
		long time = NKGJPJPHLIF.HHCJCDFCLOB.IBLPICFDGOF_ServerRequester.FJDBNGEPKHL_Time.KMEFBNBFJHI_GetServerTime();
		HHJHIFJIKAC_BonusVc.MNGJPJBCMBH item = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.NBKNAAPBFFL_BonusVc.EKENMIDOHPL_GetActiveBonus(time, AIBKGHFBFCC_BonusType);
		if(item == null)
		{
			PLOOEECNHFB_IsDone = true;
			return;
		}
		NEAPMMJKOKA_GetProducts req = NKGJPJPHLIF.HHCJCDFCLOB.IBLPICFDGOF_ServerRequester.IFFNCAFNEAG_AddRequest(new NEAPMMJKOKA_GetProducts());
		req.IPKCADIAAPG_Criteria = LCKOLEDFDAL.BAKNLGCIHAN(item.CPGFOBNKKBF_CurrencyId);
		req.BHFHGFKBOHH_OnSuccess = (CACGCMBKHDI_Request JIPCHHHLOMM) =>
		{
			//0xD950AC
			MHKCPJDNJKI_products = req.NFEAMMJIMPG_Result.MHKCPJDNJKI_products;
			MHKCPJDNJKI_products.Sort((KBPDNHOKEKD_ProductId _HKICMNAACDA_a, KBPDNHOKEKD_ProductId _BNKHBCBJBKI_b) =>
			{
				//0xD95038
				return _HKICMNAACDA_a.NPPGKNGIFGK_price.CompareTo(_BNKHBCBJBKI_b.NPPGKNGIFGK_price);
			});
			PLOOEECNHFB_IsDone = true;
			NPNNPNAIONN_IsError = false;
			PPECNOCKNMC_FullItemId = EKLNMHFCAOI.GJEEGMCBGGM_GetItemFullId(EKLNMHFCAOI.FKGCBLHOOCL_Category.IBBDMIFICCN_BonusVC, item.PPFNGGCBJKC_id);
		};
		req.MOBEEPPKFLG_OnFail = (CACGCMBKHDI_Request JIPCHHHLOMM) =>
		{
			//0xD95310
			PLOOEECNHFB_IsDone = true;
			NPNNPNAIONN_IsError = true;
		};
	}

	// // RVA: 0xD94AA0 Offset: 0xD94AA0 VA: 0xD94AA0
	public void LAOEGNLOJHC_Start()
	{
		PLOOEECNHFB_IsDone = false;
		NPNNPNAIONN_IsError = false;
		long time = NKGJPJPHLIF.HHCJCDFCLOB.IBLPICFDGOF_ServerRequester.FJDBNGEPKHL_Time.KMEFBNBFJHI_GetServerTime();
		HHJHIFJIKAC_BonusVc.MNGJPJBCMBH item = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.NBKNAAPBFFL_BonusVc.EKENMIDOHPL_GetActiveBonus(time, AIBKGHFBFCC_BonusType);
		//UnityEngine.Debug.LogError(AIBKGHFBFCC_BonusType+" "+item);
		if (item == null)
		{
			PLOOEECNHFB_IsDone = true;
			return;
		}
		//UnityEngine.Debug.LogError(item.PPFNGGCBJKC_id+" "+item.CPGFOBNKKBF_CurrencyId+" "+CIOECGOMILE.HHCJCDFCLOB.NOJDLFKKMDD_GetCurrencyTotal(item.PPFNGGCBJKC_id)+" "+MHKCPJDNJKI_products.Count);
		if(CIOECGOMILE.HHCJCDFCLOB.NOJDLFKKMDD_GetCurrencyTotal(item.PPFNGGCBJKC_id) < 1 || MHKCPJDNJKI_products.Count == 0)
		{
			PLOOEECNHFB_IsDone = true;
			return;
		}
		if(AIBKGHFBFCC_BonusType < HHJHIFJIKAC_BonusVc.IJFKAIHFJLF_BonusType.MDIJEKDNLFC_5_SpecialTickets || AIBKGHFBFCC_BonusType > HHJHIFJIKAC_BonusVc.IJFKAIHFJLF_BonusType.PPPGDKCDACF_8_Omikuji)
		{
			if(AIBKGHFBFCC_BonusType == HHJHIFJIKAC_BonusVc.IJFKAIHFJLF_BonusType.KJBGPOMJFBE_4_MonthlyPass)
			{
				N.a.StartCoroutineWatched(CAIJJOKCOAB_ConvertMonthlyPass(item.PPFNGGCBJKC_id));
				return;
			}
			if (AIBKGHFBFCC_BonusType != HHJHIFJIKAC_BonusVc.IJFKAIHFJLF_BonusType.JEPMLKCJCPK_2_Bonus_4001_4002)
				return; // JGDEHOGIENP_1_Sphere_CostumeTicket & HCHFCCEMJED_3_Bonus_20XX
		}
		N.a.StartCoroutineWatched(BJGOKLICIDO_Coroutine_Convert(item.PPFNGGCBJKC_id));
	}

	// [IteratorStateMachineAttribute] // RVA: 0x6B8E60 Offset: 0x6B8E60 VA: 0x6B8E60
	// // RVA: 0xD94D64 Offset: 0xD94D64 VA: 0xD94D64
	private IEnumerator BJGOKLICIDO_Coroutine_Convert(int LGMBMMMAFKK)
	{
		List<ANGEDJODMKO> FELJGLKGOLF; // 0x18
		List<int> NPEMJKFEBEC; // 0x1C
		List<int> FJIMKNLKGLM; // 0x20
		List<string> FDGICCDDDIN; // 0x24
		HHJHIFJIKAC_BonusVc.MNGJPJBCMBH BPFHDJEMODM; // 0x28
		KBPDNHOKEKD_ProductId LNAMPLCBPOO; // 0x2C
		CBMFOOHOAOE_Purchase CAEAKHKDKMD; // 0x30
		
		//0xD95358
		FELJGLKGOLF = new List<ANGEDJODMKO>();
		NPEMJKFEBEC = new List<int>();
		FJIMKNLKGLM = new List<int>();
		FDGICCDDDIN = new List<string>();
		long time = NKGJPJPHLIF.HHCJCDFCLOB.IBLPICFDGOF_ServerRequester.FJDBNGEPKHL_Time.KMEFBNBFJHI_GetServerTime();
		BPFHDJEMODM = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.NBKNAAPBFFL_BonusVc.EKENMIDOHPL_GetActiveBonus(time, AIBKGHFBFCC_BonusType);
		while(true)
		{
			int cur = CIOECGOMILE.HHCJCDFCLOB.NOJDLFKKMDD_GetCurrencyTotal(LGMBMMMAFKK);
			if(cur < 1)
				break;
			LNAMPLCBPOO = null;
			for(int i = 0; i < MHKCPJDNJKI_products.Count; i++)
			{
				if(MHKCPJDNJKI_products[i].NPPGKNGIFGK_price <= cur)
				{
					LNAMPLCBPOO = MHKCPJDNJKI_products[i];
				}
			}
			if(LNAMPLCBPOO == null)
				break;
			if(LNAMPLCBPOO.EGBOHDFBAPB_closed_at <= time)
				break;
			CAEAKHKDKMD = NKGJPJPHLIF.HHCJCDFCLOB.IBLPICFDGOF_ServerRequester.IFFNCAFNEAG_AddRequest(new CBMFOOHOAOE_Purchase());
			CAEAKHKDKMD.AFKAGFOFAHM_ProductId = LNAMPLCBPOO.PPFNGGCBJKC_id;
			CAEAKHKDKMD.APHNELOFGAK_CurrencyId = BPFHDJEMODM.CPGFOBNKKBF_CurrencyId;
			CAEAKHKDKMD.BPNPBJALGHM_quantity = 1;
			while(!CAEAKHKDKMD.PLOOEECNHFB_IsDone)
				yield return null;
			if(CAEAKHKDKMD.NPNNPNAIONN_IsError)
			{
				PLOOEECNHFB_IsDone = true;
				NPNNPNAIONN_IsError = true;
				yield break;
			}
			for(int i = 0; i < CAEAKHKDKMD.NFEAMMJIMPG_Result.PJJFEAHIPGL_inventories.Count; i++)
			{
				FELJGLKGOLF.Add(CAEAKHKDKMD.NFEAMMJIMPG_Result.PJJFEAHIPGL_inventories[i]);
				FJIMKNLKGLM.Add(LNAMPLCBPOO.NPPGKNGIFGK_price);
				NPEMJKFEBEC.Add(EKLNMHFCAOI.GJEEGMCBGGM_GetItemFullId(EKLNMHFCAOI.FKGCBLHOOCL_Category.IBBDMIFICCN_BonusVC, BPFHDJEMODM.PPFNGGCBJKC_id));
				FDGICCDDDIN.Add(LNAMPLCBPOO.OPFGFINHFCE_name.Replace(":", "-"));
			}
			CIOECGOMILE.HHCJCDFCLOB.DJICHKCLMCD_UpdateCurrencies(CAEAKHKDKMD.NFEAMMJIMPG_Result.BBEPLKNMICJ_balances);
			LNAMPLCBPOO = null;
			CAEAKHKDKMD = null;
		}
		if(FELJGLKGOLF.Count == 0)
		{
			PLOOEECNHFB_IsDone = true;
		}
		else
		{
			List<long> l = new List<long>();
			JANMJPOKLFL_InventoryUtil.JCHLONCMPAJ_Clear();
			for(int i = 0; i < FELJGLKGOLF.Count; i++)
			{
				string[] strs = new string[5]
				{
					NPEMJKFEBEC[i].ToString(),
					":",
					FJIMKNLKGLM[i].ToString(),
					":",
					FDGICCDDDIN[i].ToString()
				};
				JANMJPOKLFL_InventoryUtil.FEGDNPIEKJC(OAGBCBBHMPF.COIIJOEKBDH_InventoryAddType.HJGPNANNPNM_17_BonusAchatDevise, string.Concat(strs));
				JANMJPOKLFL_InventoryUtil.CPIICACGNBH_AddItem(CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_PlayerData, FELJGLKGOLF[i].NPPNDDMPFJJ_ItemCategory, FELJGLKGOLF[i].OCNINMIMHGC_item_value, FELJGLKGOLF[i].MBJIFDBEDAC_item_count, null, 0);
				l.Add(FELJGLKGOLF[i].MDPJFPHOPCH_Id);
			}
			CIOECGOMILE.HHCJCDFCLOB.AIKJMHBDABF_SavePlayerData(() =>
			{
				//0xD94FA4
				PLOOEECNHFB_IsDone = true;
			}, () =>
			{
				//0xD94FB0
				PLOOEECNHFB_IsDone = true;
				NPNNPNAIONN_IsError = true;
			}, l);
		}
	}

	// [IteratorStateMachineAttribute] // RVA: 0x6B8ED8 Offset: 0x6B8ED8 VA: 0x6B8ED8
	// // RVA: 0xD94E0C Offset: 0xD94E0C VA: 0xD94E0C
	private IEnumerator CAIJJOKCOAB_ConvertMonthlyPass(int LGMBMMMAFKK)
	{
		TodoLogger.LogError(TodoLogger.MonthlyPass, "CAIJJOKCOAB_ConvertMonthlyPass");
		yield return null;
		PLOOEECNHFB_IsDone = true;
	}

	// // RVA: 0xD94EF4 Offset: 0xD94EF4 VA: 0xD94EF4
	// public bool ELMHHMHLFJG(GJDFHLBONOL _AIMLPJOGPID_Data) { }
}
