
using System.Collections;
using System.Collections.Generic;
using XeSys;

public class AIFIANALLPB
{
	public const int NIDDEFCBKMO = 50;
	private const long IEHMEHBPIIB = 30;
	private const int LDJKMJNAGIA = 30;
	private const int FMHAOAHOKFP = 2592000;
	private const int PLJKHEPBIPE = 100;
	private const int BPLONMOMCMC = 200;
	//public BOPPPCKONML LCMDEIAFNEP = new BOPPPCKONML(); // 0x8
	private SakashoInventoryCriteria JCHEPJKLGCF = new SakashoInventoryCriteria(); // 0xC
	private SakashoInventoryCriteria KEOGDFJLIMF = new SakashoInventoryCriteria(); // 0x10
	private List<GJDFHLBONOL> GNDBGCIECCN = new List<GJDFHLBONOL>(100); // 0x14
	private List<GJDFHLBONOL> DBMLAGIIJNI = new List<GJDFHLBONOL>(100); // 0x18
	private List<GJDFHLBONOL> AACJKHBODGM = new List<GJDFHLBONOL>(100); // 0x1C
	public List<GJDFHLBONOL> PGFCIDHBMNB = new List<GJDFHLBONOL>(100); // 0x20
	private IMCBBOAFION BHFHGFKBOHH; // 0x24
	private CACGCMBKHDI_Request.HDHIKGLMOGF MOBEEPPKFLG; // 0x28
	public long ECFNAOCFKKN_Date; // 0x30
	public static bool HELFIJPHKJM; // 0x0

	public List<GJDFHLBONOL> GIPGAICOGGL { get { return GNDBGCIECCN; } } //0xCCBFB0 LNLOKDIGNEL
	// public List<GJDFHLBONOL> LPCFCLLLAMI { get; } 0xCCBFB8 CPDLFJBFDBK
	public bool PLOOEECNHFB { get; private set; }  // 0x38 MGFBAEDOIDD JFOKBBLFMLD EDBGNGILAKA

	// // RVA: 0xCCBFD0 Offset: 0xCCBFD0 VA: 0xCCBFD0
	// public void MHMOFLCJDPH(IMCBBOAFION BHFHGFKBOHH, DJBHIFLHJLK MOBEEPPKFLG) { }

	// [IteratorStateMachineAttribute] // RVA: 0x6B7048 Offset: 0x6B7048 VA: 0x6B7048
	// // RVA: 0xCCC098 Offset: 0xCCC098 VA: 0xCCC098
	// private IEnumerator IKPIELFIIMI_FirstPresent(IMCBBOAFION BHFHGFKBOHH, DJBHIFLHJLK MOBEEPPKFLG) { }

	// // RVA: 0xCCC178 Offset: 0xCCC178 VA: 0xCCC178
	public void BDPMNDGIEGI_RequestInventories(IMCBBOAFION BHFHGFKBOHH, CACGCMBKHDI_Request.HDHIKGLMOGF MOBEEPPKFLG, bool FBBNPFFEJBN)
	{
		PLOOEECNHFB = false;
		if(!FBBNPFFEJBN)
		{
			long time = NKGJPJPHLIF.HHCJCDFCLOB.IBLPICFDGOF_ServerRequester.FJDBNGEPKHL.KMEFBNBFJHI_GetServerTime();
			if(29 >= (time - ECFNAOCFKKN_Date))
			{
				PLOOEECNHFB = true;
				if (BHFHGFKBOHH != null)
					BHFHGFKBOHH();
				return;
			}
		}
		GNDBGCIECCN.Clear();
		AACJKHBODGM.Clear();
		JCHEPJKLGCF.OnlyUnreceived = true;
		this.BHFHGFKBOHH = BHFHGFKBOHH;
		this.MOBEEPPKFLG = MOBEEPPKFLG;

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
		List<GJDFHLBONOL> items = res.NFEAMMJIMPG_ResultData.PJJFEAHIPGL;
		string firstPresentItemName = MessageManager.Instance.GetMessage("common", "first_present_item_name");
		bool stpoRequest = false;
		GJDFHLBONOL g = null;
		for (int i = 0; i < items.Count; i++)
		{
			if(EKLNMHFCAOI.KGANFNCODNG_IsValidCategory(items[i].NPPNDDMPFJJ_ItemCategory))
			{
				if (GAKDCMLCAFC_IsItemNotExpired(items[i]))
				{
					g = items[i];
				}
				else
				{
					if(GNDBGCIECCN.Count > 49)
					{
						stpoRequest = true;
						break;
					}
					g = items[i];
				}
			}
		}
		if(stpoRequest || res.NFEAMMJIMPG_ResultData.MDIBIIHAAPN_NextPage < 1)
		{
			if(AACJKHBODGM.Count < 1)
			{
				if(BHFHGFKBOHH != null)
					BHFHGFKBOHH();
				ECFNAOCFKKN_Date = res.HOHOBEOJPBK_ServerInfo.LCAINKFINEI_ServerCurrentDateTime;
				PLOOEECNHFB = true;
			}
			else
			{
				List<GJDFHLBONOL> l1 = new List<GJDFHLBONOL>();
				List<GJDFHLBONOL> l2 = new List<GJDFHLBONOL>();
				for(int i = 0; i < AACJKHBODGM.Count; i++)
				{
					if(AACJKHBODGM[i].MJBKGOJBPAD_ItemType == 1)
					{
						l1.Add(AACJKHBODGM[i]);
					}
					else if(AACJKHBODGM[i].MJBKGOJBPAD_ItemType == 0)
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
			request.IGNIIEBMFIN_Page = res.NFEAMMJIMPG_ResultData.MDIBIIHAAPN_NextPage;
			request.MLPLGFLKKLI_Ipp = 30;
			request.BHFHGFKBOHH_OnSuccess = OOGDPKGCMED;
			request.MOBEEPPKFLG_OnFail = JHHKCOCJIKH;
		}
	}

	// [IteratorStateMachineAttribute] // RVA: 0x6B70C0 Offset: 0x6B70C0 VA: 0x6B70C0
	// // RVA: 0xCCD134 Offset: 0xCCD134 VA: 0xCCD134
	private IEnumerator LLONPPGBFFN_Corutine_RemoveItems(List<GJDFHLBONOL> NCHOFJOBAOE, List<GJDFHLBONOL> CLDOJOHGBJA)
	{
		PJKLMCGEJMK OKDOIAEGADK;
		GGKHIHFPKDH_SavePlayerData AKHKGHHHJKD;
		MEBJLFMDGEH_ReceiveVirtualCurrencyFromInventory BPOJOBICBAC;

		//0xCCFE5C
		OKDOIAEGADK = NKGJPJPHLIF.HHCJCDFCLOB.IBLPICFDGOF_ServerRequester;
		if (NCHOFJOBAOE.Count > 0)
		{
			List<long> l = new List<long>();
			EDOHBJAPLPF_JsonData data = new EDOHBJAPLPF_JsonData();
			EDOHBJAPLPF_JsonData data2 = new EDOHBJAPLPF_JsonData();
			data2.LAJDIPCJCPO_SetJsonType(JFBMDLGBPEN_JsonType.BDHGEFMCJDF_Array);
			for (int i = 0; i < NCHOFJOBAOE.Count; i++)
			{
				EDOHBJAPLPF_JsonData d = new EDOHBJAPLPF_JsonData();
				d["itm"] = NCHOFJOBAOE[i].JJBGOIMEIPF_ItemFullId;
				d["cnt"] = NCHOFJOBAOE[i].MBJIFDBEDAC_ItemCount;
				d["id"] = NCHOFJOBAOE[i].MDPJFPHOPCH_Id;
				data2.Add(d);
				l.Add(NCHOFJOBAOE[i].MDPJFPHOPCH_Id);
				ILCCJNDFFOB.HHCJCDFCLOB.LCDPEMIFNKJ(NCHOFJOBAOE[i].JJBGOIMEIPF_ItemFullId, NCHOFJOBAOE[i].MBJIFDBEDAC_ItemCount);
			}
			data["remove_items"] = data2;
			AKHKGHHHJKD = OKDOIAEGADK.IFFNCAFNEAG_AddRequest(new GGKHIHFPKDH_SavePlayerData());
			AKHKGHHHJKD.HHIHCJKLJFF_Names = new List<string>();
			AKHKGHHHJKD.HHIHCJKLJFF_Names.Add("remove_items");
			AKHKGHHHJKD.CHDDDCCHJJH_Replace = true;
			AKHKGHHHJKD.AMOMNBEAHBF_InventoryIds = l;
			AKHKGHHHJKD.AHEFHIMGIBI_PlayerData = IKPIMINCOPI_JsonMapper.EJCOJCGIBNG_ToJson(data);
			while (!AKHKGHHHJKD.PLOOEECNHFB_IsDone)
				yield return null;
			if (AKHKGHHHJKD.NPNNPNAIONN_IsError)
			{
				PLOOEECNHFB = true;
				if (MOBEEPPKFLG != null)
					MOBEEPPKFLG(AKHKGHHHJKD);
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
				d["itm"] = CLDOJOHGBJA[i].JJBGOIMEIPF_ItemFullId;
				d["cnt"] = CLDOJOHGBJA[i].MBJIFDBEDAC_ItemCount;
				d["id"] = CLDOJOHGBJA[i].MDPJFPHOPCH_Id;
				data2.Add(d);
				ILCCJNDFFOB.HHCJCDFCLOB.LCDPEMIFNKJ(CLDOJOHGBJA[i].JJBGOIMEIPF_ItemFullId, CLDOJOHGBJA[i].MBJIFDBEDAC_ItemCount);
				l.Add(CLDOJOHGBJA[i].MDPJFPHOPCH_Id);
			}
			data["remove_items"] = data2;
			BPOJOBICBAC = OKDOIAEGADK.IFFNCAFNEAG_AddRequest(new MEBJLFMDGEH_ReceiveVirtualCurrencyFromInventory());
			BPOJOBICBAC.AMOMNBEAHBF_Ids = l;
			while (!BPOJOBICBAC.PLOOEECNHFB_IsDone)
				yield return null;
			if (BPOJOBICBAC.NPNNPNAIONN_IsError)
			{
				PLOOEECNHFB = true;
				if (MOBEEPPKFLG != null)
					MOBEEPPKFLG(BPOJOBICBAC);
				yield break;
			}
			CIOECGOMILE.HHCJCDFCLOB.DJICHKCLMCD_UpdateCurrencies(BPOJOBICBAC.NFEAMMJIMPG.BBEPLKNMICJ);
			BPOJOBICBAC = null;
		}
		AACJKHBODGM.Clear();
		PLOOEECNHFB = true;
		if (BHFHGFKBOHH != null)
			BHFHGFKBOHH();
		ECFNAOCFKKN_Date = NKGJPJPHLIF.HHCJCDFCLOB.IBLPICFDGOF_ServerRequester.FJDBNGEPKHL.KMEFBNBFJHI_GetServerTime();
		PLOOEECNHFB = true;
	}

	// // RVA: 0xCCD214 Offset: 0xCCD214 VA: 0xCCD214
	private void JHHKCOCJIKH(CACGCMBKHDI_Request KFBCOGJKEJP)
	{
		TodoLogger.Log(0, "TODO");
	}

	// // RVA: 0xCCD234 Offset: 0xCCD234 VA: 0xCCD234
	// public void POMPFPJOMNN(List<long> LDMMMFJCGCF) { }

	// // RVA: 0xCCD444 Offset: 0xCCD444 VA: 0xCCD444
	// public void PBBEPILMAHO(List<long> LDMMMFJCGCF, AIFIANALLPB.FCGCBNAGFKH GPFOMPOEFLM) { }

	// // RVA: 0xCCDE44 Offset: 0xCCDE44 VA: 0xCCDE44
	// public void ICEKFOCHJPI(IMCBBOAFION BHFHGFKBOHH, CACGCMBKHDI.HDHIKGLMOGF MOBEEPPKFLG) { }

	// // RVA: 0xCCDFA0 Offset: 0xCCDFA0 VA: 0xCCDFA0
	// public void EAOGDGAEJPH(IMCBBOAFION BHFHGFKBOHH, CACGCMBKHDI.HDHIKGLMOGF MOBEEPPKFLG) { }

	// // RVA: 0xCCE128 Offset: 0xCCE128 VA: 0xCCE128
	// private void KMDPGNCKNKP(CACGCMBKHDI KFBCOGJKEJP) { }

	// // RVA: 0xCCE758 Offset: 0xCCE758 VA: 0xCCE758
	// private void CBBJHOHHFEM(CACGCMBKHDI KFBCOGJKEJP) { }

	// // RVA: 0xCCE790 Offset: 0xCCE790 VA: 0xCCE790
	// public void OEJMJDNIGJD() { }

	// // RVA: 0xCCCC5C Offset: 0xCCCC5C VA: 0xCCCC5C
	private bool GAKDCMLCAFC_IsItemNotExpired(GJDFHLBONOL AIMLPJOGPID)
	{
		long time = NKGJPJPHLIF.HHCJCDFCLOB.IBLPICFDGOF_ServerRequester.FJDBNGEPKHL.KMEFBNBFJHI_GetServerTime();
		EKLNMHFCAOI.FKGCBLHOOCL_Category cat = AIMLPJOGPID.NPPNDDMPFJJ_ItemCategory;
		if(cat < EKLNMHFCAOI.FKGCBLHOOCL_Category.LLFAAOHPMIC_EventGachaTicket)
		{
			if (cat != EKLNMHFCAOI.FKGCBLHOOCL_Category.OBHECJMAEIO_GachaTicket)
			{
				if (cat != EKLNMHFCAOI.FKGCBLHOOCL_Category.IBBDMIFICCN_BonusVC)
					return false;
				HHJHIFJIKAC_BonusVc.MNGJPJBCMBH item = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.NBKNAAPBFFL_BonusVc.CDENCMNHNGA[AIMLPJOGPID.NNFNGLJOKKF_ItemId - 1];
				if ((item.INDDJNMPONH & 0xfffffffeU) != 2)
					return false;
				if(item.EGBOHDFBAPB_ClosedAt < AIMLPJOGPID.EGBOHDFBAPB_ClosedAt)
				{
					AIMLPJOGPID.EGBOHDFBAPB_ClosedAt = item.EGBOHDFBAPB_ClosedAt;
					AIMLPJOGPID.BGOJPEJJJFB_IsAvaiable = false;
				}
				return time >= AIMLPJOGPID.EGBOHDFBAPB_ClosedAt;
			}
			if(AIMLPJOGPID.NNFNGLJOKKF_ItemId < 200)
			{
				if (AIMLPJOGPID.NNFNGLJOKKF_ItemId < 100)
					return false;
				int gachaPeriod = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.GDEKCOOBLMA_System.LPJLEHAJADA("gacha_ticket_presentbox_period", 2592000);
				AIMLPJOGPID.BGOJPEJJJFB_IsAvaiable = false;
				AIMLPJOGPID.EGBOHDFBAPB_ClosedAt = AIMLPJOGPID.BIOGKIEECGN_CreatedAt + gachaPeriod;
			}
		}
		else
		{
			if(cat != EKLNMHFCAOI.FKGCBLHOOCL_Category.LLFAAOHPMIC_EventGachaTicket)
			{
				if (cat != EKLNMHFCAOI.FKGCBLHOOCL_Category.DLOPEFGOAPD_LimitedItem)
					return false;
				EGLOKAEIHCB_LimitedItem.DEOCBHAGEEH item = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.IHPFCIJKFIC_LimitedItem.CDENCMNHNGA[AIMLPJOGPID.NNFNGLJOKKF_ItemId - 1];
				if (item.KHCBANFDKBO_Duration == 0)
					return false;
				long t = AIMLPJOGPID.BIOGKIEECGN_CreatedAt + item.KHCBANFDKBO_Duration * 86400;
				if(t < AIMLPJOGPID.EGBOHDFBAPB_ClosedAt)
				{
					AIMLPJOGPID.EGBOHDFBAPB_ClosedAt = t;
					AIMLPJOGPID.BGOJPEJJJFB_IsAvaiable = false;
				}
				if (time < AIMLPJOGPID.EGBOHDFBAPB_ClosedAt)
					return false;
				return true;
			}
			JNGINLMOJKH_EventGachaTicket.JDNAAGCHCOH itm = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.NKOKFIMNCJM_EventGachaTicket.CDENCMNHNGA[AIMLPJOGPID.NNFNGLJOKKF_ItemId - 1];
			if(itm.EMIJNAFJFJO_Expir != 0)
			{
				if(itm.EMIJNAFJFJO_Expir < AIMLPJOGPID.EGBOHDFBAPB_ClosedAt)
				{
					AIMLPJOGPID.EGBOHDFBAPB_ClosedAt = itm.EMIJNAFJFJO_Expir;
					AIMLPJOGPID.BGOJPEJJJFB_IsAvaiable = false;
				}
			}
		}
		if (time < AIMLPJOGPID.EGBOHDFBAPB_ClosedAt)
			return false;
		return true;
	}
}
