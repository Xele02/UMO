
using System.Collections;
using System.Collections.Generic;
using XeSys;

public class AIFIANALLPB
{
	public delegate void FCGCBNAGFKH(GJDFHLBONOL AIMLPJOGPID);

	public const int NIDDEFCBKMO = 50;
	private const long IEHMEHBPIIB = 30;
	private const int LDJKMJNAGIA = 30;
	private const int FMHAOAHOKFP = 2592000;
	private const int PLJKHEPBIPE = 100;
	private const int BPLONMOMCMC = 200;
	public BOPPPCKONML LCMDEIAFNEP = new BOPPPCKONML(); // 0x8
	private SakashoInventoryCriteria JCHEPJKLGCF = new SakashoInventoryCriteria(); // 0xC
	private SakashoInventoryCriteria KEOGDFJLIMF = new SakashoInventoryCriteria(); // 0x10
	private List<GJDFHLBONOL> GNDBGCIECCN = new List<GJDFHLBONOL>(100); // 0x14
	private List<GJDFHLBONOL> DBMLAGIIJNI = new List<GJDFHLBONOL>(100); // 0x18
	private List<GJDFHLBONOL> AACJKHBODGM = new List<GJDFHLBONOL>(100); // 0x1C
	public List<GJDFHLBONOL> PGFCIDHBMNB = new List<GJDFHLBONOL>(100); // 0x20
	private IMCBBOAFION BHFHGFKBOHH_OnSuccess; // 0x24
	private CACGCMBKHDI_Request.HDHIKGLMOGF MOBEEPPKFLG_OnFail; // 0x28
	public long ECFNAOCFKKN_LastDate; // 0x30
	public static bool HELFIJPHKJM; // 0x0

	public List<GJDFHLBONOL> GIPGAICOGGL { get { return GNDBGCIECCN; } } //0xCCBFB0 LNLOKDIGNEL
	public List<GJDFHLBONOL> LPCFCLLLAMI { get { return DBMLAGIIJNI; } } //0xCCBFB8 CPDLFJBFDBK
	public bool PLOOEECNHFB_IsDone { get; private set; }  // 0x38 MGFBAEDOIDD JFOKBBLFMLD EDBGNGILAKA

	// // RVA: 0xCCBFD0 Offset: 0xCCBFD0 VA: 0xCCBFD0
	public void MHMOFLCJDPH_FirstPresent(IMCBBOAFION _BHFHGFKBOHH_OnSuccess, DJBHIFLHJLK _MOBEEPPKFLG_OnFail)
	{
		PLOOEECNHFB_IsDone = false;
		PGFCIDHBMNB.Clear();
		N.a.StartCoroutineWatched(IKPIELFIIMI_Coroutine_FirstPresent(_BHFHGFKBOHH_OnSuccess, _MOBEEPPKFLG_OnFail));
	}

	// [IteratorStateMachineAttribute] // RVA: 0x6B7048 Offset: 0x6B7048 VA: 0x6B7048
	// // RVA: 0xCCC098 Offset: 0xCCC098 VA: 0xCCC098
	private IEnumerator IKPIELFIIMI_Coroutine_FirstPresent(IMCBBOAFION _BHFHGFKBOHH_OnSuccess, DJBHIFLHJLK _MOBEEPPKFLG_OnFail)
	{
		string FAICBFPCFML; // 0x1C
		int PMPKOBDDPBP; // 0x20
		LGJOOFGOGCD_RequestInventories BPOJOBICBAC; // 0x24

		//0xCCF4C8
		FAICBFPCFML = MessageManager.Instance.GetMessage("common", "first_present_item_name");
		PMPKOBDDPBP = 1;
		while(true)
		{
			BPOJOBICBAC = NKGJPJPHLIF.HHCJCDFCLOB.IBLPICFDGOF_ServerRequester.IFFNCAFNEAG_AddRequest(new LGJOOFGOGCD_RequestInventories());
			BPOJOBICBAC.IPKCADIAAPG_Criteria = JCHEPJKLGCF;
			BPOJOBICBAC.IGNIIEBMFIN_Page = PMPKOBDDPBP;
			BPOJOBICBAC.MLPLGFLKKLI_Ipp = 30;
			BPOJOBICBAC.BHFHGFKBOHH_OnSuccess = (CACGCMBKHDI_Request IJAOGPFKDBP) =>
			{
				//0xCCE980
				return;
			};
			BPOJOBICBAC.MOBEEPPKFLG_OnFail = (CACGCMBKHDI_Request IJAOGPFKDBP) =>
			{
				//0xCCE984
				return;
			};
			JCHEPJKLGCF.OnlyUnreceived = true;
			while(!BPOJOBICBAC.PLOOEECNHFB_IsDone)
				yield return null;
			if(BPOJOBICBAC.NPNNPNAIONN_IsError)
			{
				PLOOEECNHFB_IsDone = true;
				_MOBEEPPKFLG_OnFail();
				yield break;
			}
			for(int i = 0; i < BPOJOBICBAC.NFEAMMJIMPG_Result.PJJFEAHIPGL_inventories.Count; i++)
			{
                GJDFHLBONOL data = BPOJOBICBAC.NFEAMMJIMPG_Result.PJJFEAHIPGL_inventories[i];
				if(data.NPPNDDMPFJJ_ItemCategory == EKLNMHFCAOI.FKGCBLHOOCL_Category.MHKFDBLMOGF_Scene)
				{
					if(data.LJGOOOMOMMA_message == FAICBFPCFML)
					{
						PGFCIDHBMNB.Add(data);
					}
				}
            }
			if(BPOJOBICBAC.NFEAMMJIMPG_Result.MDIBIIHAAPN_next_page == 0)
				break;
			PMPKOBDDPBP++;
			BPOJOBICBAC = null;
		}
		for(int i = 0; i < PGFCIDHBMNB.Count; i++)
		{
			GJDFHLBONOL g = GNDBGCIECCN.Find((GJDFHLBONOL _GHPLINIACBB_x) =>
			{
				//0xCCEBAC
				return _GHPLINIACBB_x.MDPJFPHOPCH_Id == PGFCIDHBMNB[i].MDPJFPHOPCH_Id;
			});
			if(g == null)
			{
				GNDBGCIECCN.Add(PGFCIDHBMNB[i]);
			}
		}
		PLOOEECNHFB_IsDone = true;
		_BHFHGFKBOHH_OnSuccess();
	}

	// // RVA: 0xCCC178 Offset: 0xCCC178 VA: 0xCCC178
	public void BDPMNDGIEGI_RequestInventories(IMCBBOAFION _BHFHGFKBOHH_OnSuccess, CACGCMBKHDI_Request.HDHIKGLMOGF _MOBEEPPKFLG_OnFail, bool _FBBNPFFEJBN_Force)
	{
		PLOOEECNHFB_IsDone = false;
		if(!_FBBNPFFEJBN_Force)
		{
			long time = NKGJPJPHLIF.HHCJCDFCLOB.IBLPICFDGOF_ServerRequester.FJDBNGEPKHL_Time.KMEFBNBFJHI_GetServerTime();
			if(29 >= (time - ECFNAOCFKKN_LastDate))
			{
				PLOOEECNHFB_IsDone = true;
				if (_BHFHGFKBOHH_OnSuccess != null)
					_BHFHGFKBOHH_OnSuccess();
				return;
			}
		}
		GNDBGCIECCN.Clear();
		AACJKHBODGM.Clear();
		JCHEPJKLGCF.OnlyUnreceived = true;
		this.BHFHGFKBOHH_OnSuccess = _BHFHGFKBOHH_OnSuccess;
		this.MOBEEPPKFLG_OnFail = _MOBEEPPKFLG_OnFail;

		LGJOOFGOGCD_RequestInventories request = NKGJPJPHLIF.HHCJCDFCLOB.IBLPICFDGOF_ServerRequester.IFFNCAFNEAG_AddRequest<LGJOOFGOGCD_RequestInventories>(new LGJOOFGOGCD_RequestInventories());
		request.IPKCADIAAPG_Criteria = JCHEPJKLGCF;
		request.IGNIIEBMFIN_Page = 1;
		request.MLPLGFLKKLI_Ipp = 30;
		request.BHFHGFKBOHH_OnSuccess = this.OOGDPKGCMED;
		request.MOBEEPPKFLG_OnFail = this.JHHKCOCJIKH;
	}

	// // RVA: 0xCCC498 Offset: 0xCCC498 VA: 0xCCC498
	private void OOGDPKGCMED(CACGCMBKHDI_Request KFBCOGJKEJP)
	{
		LGJOOFGOGCD_RequestInventories res = KFBCOGJKEJP as LGJOOFGOGCD_RequestInventories;
		List<GJDFHLBONOL> items = res.NFEAMMJIMPG_Result.PJJFEAHIPGL_inventories;
		string firstPresentItemName = MessageManager.Instance.GetMessage("common", "first_present_item_name");
		bool stpoRequest = false;
		for (int i = 0; i < items.Count; i++)
		{
			if(EKLNMHFCAOI.KGANFNCODNG_IsValidCategory(items[i].NPPNDDMPFJJ_ItemCategory))
			{
				if (GAKDCMLCAFC_IsItemNotExpired(items[i]))
				{
					AACJKHBODGM.Add(items[i]);
				}
				else
				{
					if(GNDBGCIECCN.Count > 49)
					{
						stpoRequest = true;
						break;
					}
					GNDBGCIECCN.Add(items[i]);
				}
			}
		}
		if(stpoRequest || res.NFEAMMJIMPG_Result.MDIBIIHAAPN_next_page < 1)
		{
			if(AACJKHBODGM.Count < 1)
			{
				if(BHFHGFKBOHH_OnSuccess != null)
					BHFHGFKBOHH_OnSuccess();
				ECFNAOCFKKN_LastDate = res.HOHOBEOJPBK_ServerInfo.LCAINKFINEI_SakashoCurrentDateTime;
				PLOOEECNHFB_IsDone = true;
			}
			else
			{
				List<GJDFHLBONOL> l1 = new List<GJDFHLBONOL>();
				List<GJDFHLBONOL> l2 = new List<GJDFHLBONOL>();
				for(int i = 0; i < AACJKHBODGM.Count; i++)
				{
					if(AACJKHBODGM[i].MJBKGOJBPAD_item_type == 1)
					{
						l1.Add(AACJKHBODGM[i]);
					}
					else if(AACJKHBODGM[i].MJBKGOJBPAD_item_type == 0)
					{
						l2.Add(AACJKHBODGM[i]);
					}
				}
				N.a.StartCoroutineWatched(LLONPPGBFFN_Corutine_RemoveItems(l1, l2));
			}
		}
		else
		{
			LGJOOFGOGCD_RequestInventories request = new LGJOOFGOGCD_RequestInventories();
			request = NKGJPJPHLIF.HHCJCDFCLOB.IBLPICFDGOF_ServerRequester.IFFNCAFNEAG_AddRequest(request);
			request.IPKCADIAAPG_Criteria = JCHEPJKLGCF;
			request.IGNIIEBMFIN_Page = res.NFEAMMJIMPG_Result.MDIBIIHAAPN_next_page;
			request.MLPLGFLKKLI_Ipp = 30;
			request.BHFHGFKBOHH_OnSuccess = OOGDPKGCMED;
			request.MOBEEPPKFLG_OnFail = JHHKCOCJIKH;
		}
	}

	// [IteratorStateMachineAttribute] // RVA: 0x6B70C0 Offset: 0x6B70C0 VA: 0x6B70C0
	// // RVA: 0xCCD134 Offset: 0xCCD134 VA: 0xCCD134
	private IEnumerator LLONPPGBFFN_Corutine_RemoveItems(List<GJDFHLBONOL> NCHOFJOBAOE, List<GJDFHLBONOL> CLDOJOHGBJA)
	{
		PJKLMCGEJMK OKDOIAEGADK_Server;
		GGKHIHFPKDH_SavePlayerData AKHKGHHHJKD;
		MEBJLFMDGEH_ReceiveVirtualCurrencyFromInventory BPOJOBICBAC;

		//0xCCFE5C
		OKDOIAEGADK_Server = NKGJPJPHLIF.HHCJCDFCLOB.IBLPICFDGOF_ServerRequester;
		if (NCHOFJOBAOE.Count > 0)
		{
			List<long> l = new List<long>();
			EDOHBJAPLPF_JsonData data = new EDOHBJAPLPF_JsonData();
			EDOHBJAPLPF_JsonData data2 = new EDOHBJAPLPF_JsonData();
			data2.LAJDIPCJCPO_SetJsonType(JFBMDLGBPEN_JsonType.BDHGEFMCJDF_Array);
			for (int i = 0; i < NCHOFJOBAOE.Count; i++)
			{
				EDOHBJAPLPF_JsonData d = new EDOHBJAPLPF_JsonData();
				d["itm"] = NCHOFJOBAOE[i].JJBGOIMEIPF_ItemId;
				d["cnt"] = NCHOFJOBAOE[i].MBJIFDBEDAC_item_count;
				d["id"] = NCHOFJOBAOE[i].MDPJFPHOPCH_Id;
				data2.Add(d);
				l.Add(NCHOFJOBAOE[i].MDPJFPHOPCH_Id);
				ILCCJNDFFOB.HHCJCDFCLOB.LCDPEMIFNKJ(NCHOFJOBAOE[i].JJBGOIMEIPF_ItemId, NCHOFJOBAOE[i].MBJIFDBEDAC_item_count);
			}
			data["remove_items"] = data2;
			AKHKGHHHJKD = OKDOIAEGADK_Server.IFFNCAFNEAG_AddRequest(new GGKHIHFPKDH_SavePlayerData());
			AKHKGHHHJKD.HHIHCJKLJFF_Names = new List<string>();
			AKHKGHHHJKD.HHIHCJKLJFF_Names.Add("remove_items");
			AKHKGHHHJKD.CHDDDCCHJJH_Replace = true;
			AKHKGHHHJKD.AMOMNBEAHBF_InventoryIds = l;
			AKHKGHHHJKD.AHEFHIMGIBI_PlayerData = IKPIMINCOPI_JsonMapper.EJCOJCGIBNG_ToJson(data);
			while (!AKHKGHHHJKD.PLOOEECNHFB_IsDone)
				yield return null;
			if (AKHKGHHHJKD.NPNNPNAIONN_IsError)
			{
				PLOOEECNHFB_IsDone = true;
				if (MOBEEPPKFLG_OnFail != null)
					MOBEEPPKFLG_OnFail(AKHKGHHHJKD);
				yield break;
			}
			AKHKGHHHJKD = null;
		}
		if(CLDOJOHGBJA.Count > 0)
		{
			List<long> l = new List<long>();
			EDOHBJAPLPF_JsonData data = new EDOHBJAPLPF_JsonData();
			EDOHBJAPLPF_JsonData data2 = new EDOHBJAPLPF_JsonData();
			data2.LAJDIPCJCPO_SetJsonType(JFBMDLGBPEN_JsonType.BDHGEFMCJDF_Array);
			for (int i = 0; i < CLDOJOHGBJA.Count; i++)
			{
				EDOHBJAPLPF_JsonData d = new EDOHBJAPLPF_JsonData();
				d["itm"] = CLDOJOHGBJA[i].JJBGOIMEIPF_ItemId;
				d["cnt"] = CLDOJOHGBJA[i].MBJIFDBEDAC_item_count;
				d["id"] = CLDOJOHGBJA[i].MDPJFPHOPCH_Id;
				data2.Add(d);
				ILCCJNDFFOB.HHCJCDFCLOB.LCDPEMIFNKJ(CLDOJOHGBJA[i].JJBGOIMEIPF_ItemId, CLDOJOHGBJA[i].MBJIFDBEDAC_item_count);
				l.Add(CLDOJOHGBJA[i].MDPJFPHOPCH_Id);
			}
			data["remove_items"] = data2;
			BPOJOBICBAC = OKDOIAEGADK_Server.IFFNCAFNEAG_AddRequest(new MEBJLFMDGEH_ReceiveVirtualCurrencyFromInventory());
			BPOJOBICBAC.AMOMNBEAHBF_InventoryIds = l;
			while (!BPOJOBICBAC.PLOOEECNHFB_IsDone)
				yield return null;
			if (BPOJOBICBAC.NPNNPNAIONN_IsError)
			{
				PLOOEECNHFB_IsDone = true;
				if (MOBEEPPKFLG_OnFail != null)
					MOBEEPPKFLG_OnFail(BPOJOBICBAC);
				yield break;
			}
			CIOECGOMILE.HHCJCDFCLOB.DJICHKCLMCD_UpdateCurrencies(BPOJOBICBAC.NFEAMMJIMPG_Result.BBEPLKNMICJ_Balances);
			BPOJOBICBAC = null;
		}
		AACJKHBODGM.Clear();
		PLOOEECNHFB_IsDone = true;
		if (BHFHGFKBOHH_OnSuccess != null)
			BHFHGFKBOHH_OnSuccess();
		ECFNAOCFKKN_LastDate = NKGJPJPHLIF.HHCJCDFCLOB.IBLPICFDGOF_ServerRequester.FJDBNGEPKHL_Time.KMEFBNBFJHI_GetServerTime();
		PLOOEECNHFB_IsDone = true;
	}

	// // RVA: 0xCCD214 Offset: 0xCCD214 VA: 0xCCD214
	private void JHHKCOCJIKH(CACGCMBKHDI_Request KFBCOGJKEJP)
	{
		PLOOEECNHFB_IsDone = true;
		MOBEEPPKFLG_OnFail(KFBCOGJKEJP);
	}

	// // RVA: 0xCCD234 Offset: 0xCCD234 VA: 0xCCD234
	public void POMPFPJOMNN(List<long> LDMMMFJCGCF)
	{
		for(int i = 0; i < LDMMMFJCGCF.Count; i++)
		{
			long id = LDMMMFJCGCF[i];
			GJDFHLBONOL d = GNDBGCIECCN.Find((GJDFHLBONOL AIMLPJOGPID) =>
			{
				//0xCCEC84
				return AIMLPJOGPID.MDPJFPHOPCH_Id == id;
			});
			if(d != null)
			{
				GNDBGCIECCN.Remove(d);
				LCMDEIAFNEP.ANIJHEBLMGB(d);
			}
		}
	}

	// // RVA: 0xCCD444 Offset: 0xCCD444 VA: 0xCCD444
	public void PBBEPILMAHO(List<long> LDMMMFJCGCF, FCGCBNAGFKH GPFOMPOEFLM)
	{
		for(int i = 0; i < LDMMMFJCGCF.Count; i++)
		{
			long id = LDMMMFJCGCF[i];
			GJDFHLBONOL data = GNDBGCIECCN.Find((GJDFHLBONOL AIMLPJOGPID) =>
			{
				//0xCCECC4
				return AIMLPJOGPID.MDPJFPHOPCH_Id == id;
			});
			if(data != null)
			{
				GPFOMPOEFLM(data);
			}
		}
	}

	// // RVA: 0xCCDE44 Offset: 0xCCDE44 VA: 0xCCDE44
	public void ICEKFOCHJPI(IMCBBOAFION _BHFHGFKBOHH_OnSuccess, CACGCMBKHDI_Request.HDHIKGLMOGF _MOBEEPPKFLG_OnFail)
	{
		PLOOEECNHFB_IsDone = false;
		LCMDEIAFNEP.HJMKBCFJOOH(() =>
		{
			//0xCCED04
			DBMLAGIIJNI.Clear();
			for(int i = 0; i < LCMDEIAFNEP.PJJFEAHIPGL_inventories.Count; i++)
			{
				if(LCMDEIAFNEP.PJJFEAHIPGL_inventories[i].EILKGEADKGH_Order != 0)
				{
					GJDFHLBONOL data = new GJDFHLBONOL();
					data.ODDIHGPONFL_Copy(LCMDEIAFNEP.PJJFEAHIPGL_inventories[i]);
					DBMLAGIIJNI.Add(data);
				}
			}
			DBMLAGIIJNI.Sort((GJDFHLBONOL HKICMNAACDA, GJDFHLBONOL BNKHBCBJBKI) =>
			{
				//0xCCE988
				int res = BNKHBCBJBKI.LNDEFMALKAN_received_at.CompareTo(HKICMNAACDA.LNDEFMALKAN_received_at);
				if(res == 0)
					return BNKHBCBJBKI.MDPJFPHOPCH_Id.CompareTo(HKICMNAACDA.MDPJFPHOPCH_Id);
				return res;
			});
			PLOOEECNHFB_IsDone = true;
			_BHFHGFKBOHH_OnSuccess();
		}, () =>
		{
			//0xCCF0B4
			PLOOEECNHFB_IsDone = true;
			_MOBEEPPKFLG_OnFail(null);
		});
	}

	// // RVA: 0xCCDFA0 Offset: 0xCCDFA0 VA: 0xCCDFA0
	public void EAOGDGAEJPH(IMCBBOAFION _BHFHGFKBOHH_OnSuccess, CACGCMBKHDI_Request.HDHIKGLMOGF _MOBEEPPKFLG_OnFail)
	{
		PLOOEECNHFB_IsDone = false;
		DBMLAGIIJNI.Clear();
		LCMDEIAFNEP.PCODDPDFLHK(() =>
		{
			//0xCCF104
			for(int i = 0; i < LCMDEIAFNEP.PJJFEAHIPGL_inventories.Count; i++)
			{
				if(LCMDEIAFNEP.PJJFEAHIPGL_inventories[i].EILKGEADKGH_Order != 0)
				{
					GJDFHLBONOL data = new GJDFHLBONOL();
					data.ODDIHGPONFL_Copy(LCMDEIAFNEP.PJJFEAHIPGL_inventories[i]);
					DBMLAGIIJNI.Add(data);
				}
			}
			DBMLAGIIJNI.Sort((GJDFHLBONOL HKICMNAACDA, GJDFHLBONOL BNKHBCBJBKI) =>
			{
				//0xCCEA3C
				int res = BNKHBCBJBKI.LNDEFMALKAN_received_at.CompareTo(HKICMNAACDA.LNDEFMALKAN_received_at);
				if (res == 0)
					res = BNKHBCBJBKI.MDPJFPHOPCH_Id.CompareTo(HKICMNAACDA.MDPJFPHOPCH_Id);
				return res;
			});
			PLOOEECNHFB_IsDone = true;
			_BHFHGFKBOHH_OnSuccess();
		}, () =>
		{
			//0xCCF474
			PLOOEECNHFB_IsDone = true;
			_MOBEEPPKFLG_OnFail(null);
		});
	}

	// // RVA: 0xCCE128 Offset: 0xCCE128 VA: 0xCCE128
	// private void KMDPGNCKNKP(CACGCMBKHDI KFBCOGJKEJP) { }

	// // RVA: 0xCCE758 Offset: 0xCCE758 VA: 0xCCE758
	// private void CBBJHOHHFEM(CACGCMBKHDI KFBCOGJKEJP) { }

	// // RVA: 0xCCE790 Offset: 0xCCE790 VA: 0xCCE790
	public void OEJMJDNIGJD()
	{
		LCMDEIAFNEP.EAKEHFCEKCF_SaveFile();
	}

	// // RVA: 0xCCCC5C Offset: 0xCCCC5C VA: 0xCCCC5C
	private bool GAKDCMLCAFC_IsItemNotExpired(GJDFHLBONOL AIMLPJOGPID)
	{
		long time = NKGJPJPHLIF.HHCJCDFCLOB.IBLPICFDGOF_ServerRequester.FJDBNGEPKHL_Time.KMEFBNBFJHI_GetServerTime();
		EKLNMHFCAOI.FKGCBLHOOCL_Category cat = AIMLPJOGPID.NPPNDDMPFJJ_ItemCategory;
		if(cat < EKLNMHFCAOI.FKGCBLHOOCL_Category.LLFAAOHPMIC_EventGachaTicket)
		{
			if (cat != EKLNMHFCAOI.FKGCBLHOOCL_Category.OBHECJMAEIO_GachaTicket)
			{
				if (cat != EKLNMHFCAOI.FKGCBLHOOCL_Category.IBBDMIFICCN_BonusVC)
					return false;
				HHJHIFJIKAC_BonusVc.MNGJPJBCMBH item = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.NBKNAAPBFFL_BonusVc.CDENCMNHNGA_table[AIMLPJOGPID.NNFNGLJOKKF_ItemId - 1];
				if ((item.INDDJNMPONH_type & 0xfffffffeU) != 2)
					return false;
				if(item.EGBOHDFBAPB_CloseAt < AIMLPJOGPID.EGBOHDFBAPB_CloseAt)
				{
					AIMLPJOGPID.EGBOHDFBAPB_CloseAt = item.EGBOHDFBAPB_CloseAt;
					AIMLPJOGPID.BGOJPEJJJFB_IsAvaiable = false;
				}
				return time >= AIMLPJOGPID.EGBOHDFBAPB_CloseAt;
			}
			if(AIMLPJOGPID.NNFNGLJOKKF_ItemId < 200)
			{
				if (AIMLPJOGPID.NNFNGLJOKKF_ItemId < 100)
					return false;
				int gachaPeriod = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.GDEKCOOBLMA_System.LPJLEHAJADA("gacha_ticket_presentbox_period", 2592000);
				AIMLPJOGPID.BGOJPEJJJFB_IsAvaiable = false;
				AIMLPJOGPID.EGBOHDFBAPB_CloseAt = AIMLPJOGPID.BIOGKIEECGN_CreatedAt + gachaPeriod;
			}
		}
		else
		{
			if(cat != EKLNMHFCAOI.FKGCBLHOOCL_Category.LLFAAOHPMIC_EventGachaTicket)
			{
				if (cat != EKLNMHFCAOI.FKGCBLHOOCL_Category.DLOPEFGOAPD_LimitedItem)
					return false;
				EGLOKAEIHCB_LimitedItem.DEOCBHAGEEH item = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.IHPFCIJKFIC_LimitedItem.CDENCMNHNGA_table[AIMLPJOGPID.NNFNGLJOKKF_ItemId - 1];
				if (item.KHCBANFDKBO_Duration == 0)
					return false;
				long t = AIMLPJOGPID.BIOGKIEECGN_CreatedAt + item.KHCBANFDKBO_Duration * 86400;
				if(t < AIMLPJOGPID.EGBOHDFBAPB_CloseAt)
				{
					AIMLPJOGPID.EGBOHDFBAPB_CloseAt = t;
					AIMLPJOGPID.BGOJPEJJJFB_IsAvaiable = false;
				}
				if (time < AIMLPJOGPID.EGBOHDFBAPB_CloseAt)
					return false;
				return true;
			}
			JNGINLMOJKH_EventGachaTicket.JDNAAGCHCOH itm = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.NKOKFIMNCJM_EventGachaTicket.CDENCMNHNGA_table[AIMLPJOGPID.NNFNGLJOKKF_ItemId - 1];
			if(itm.EMIJNAFJFJO_Expir != 0)
			{
				if(itm.EMIJNAFJFJO_Expir < AIMLPJOGPID.EGBOHDFBAPB_CloseAt)
				{
					AIMLPJOGPID.EGBOHDFBAPB_CloseAt = itm.EMIJNAFJFJO_Expir;
					AIMLPJOGPID.BGOJPEJJJFB_IsAvaiable = false;
				}
			}
		}
		if (time < AIMLPJOGPID.EGBOHDFBAPB_CloseAt)
			return false;
		return true;
	}
}
