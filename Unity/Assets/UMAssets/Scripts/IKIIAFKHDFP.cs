
using System.Collections;
using System.Collections.Generic;

public class IKIIAFKHDFP
{
	private enum APMNNDGAGCD
	{
		LAIEABIEBED = 0,
		DPFCOLKJMAH = 1,
		FELILKPMLNO = 2,
		JONPKLHMOBL_3_Category = 3,
	}

	private const int MBIMMJDDOFM = 14;
	private const int EBPPBLJEKGO = 7;
	private const int OFHCCJMMPHN = 4;
	private const int DJBMOPHFJOI = 28;
	public bool PLOOEECNHFB_IsDone; // 0x8
	private long CDEDDEECBBF_LastRequestTime; // 0x18

	public List<EPLAAEHPCDM> FMAMKPJMFHJ { get; private set; } // 0xC PFENJOKJKLO EJAEHOAJPJL HGBEMHGJEFJ
	public List<GMHKBJLIILI> GAOEDFGMHFD { get; private set; } // 0x10 EDFBPEPJMGL PIOPNDADBPF MIGJCHCPNHL

	//// RVA: 0x8E47D4 Offset: 0x8E47D4 VA: 0x8E47D4
	//public EPLAAEHPCDM BPNKOBFHOFI(int _PPFNGGCBJKC_id) { }

	//// RVA: 0x8E48E4 Offset: 0x8E48E4 VA: 0x8E48E4
	//private void NFHGIBLJMNH(IKIIAFKHDFP.APMNNDGAGCD _PPFNGGCBJKC_id, string JEHFDJPOEFF) { }

	//// RVA: 0x8E48E8 Offset: 0x8E48E8 VA: 0x8E48E8
	public void HBOKJNECOPA_GetMaster(IMCBBOAFION MKECMMAJBBH, IMCBBOAFION NDLCLMAFABH, DJBHIFLHJLK _MOBEEPPKFLG_OnFail, bool _DDGFCOPPBBN_test)
	{
		FMAMKPJMFHJ = null;
		GAOEDFGMHFD = null;
		long time = NKGJPJPHLIF.HHCJCDFCLOB.IBLPICFDGOF_ServerRequester.FJDBNGEPKHL_Time.KMEFBNBFJHI_GetServerTime();
		CDEDDEECBBF_LastRequestTime = time;
		N.a.StartCoroutineWatched(GILKBAKOKLH_Coroutine_01_GetMaster(MKECMMAJBBH, NDLCLMAFABH, _MOBEEPPKFLG_OnFail));
	}

	//[IteratorStateMachineAttribute] // RVA: 0x6B7218 Offset: 0x6B7218 VA: 0x6B7218
	//// RVA: 0x8E4A44 Offset: 0x8E4A44 VA: 0x8E4A44
	private IEnumerator GILKBAKOKLH_Coroutine_01_GetMaster(IMCBBOAFION MKECMMAJBBH, IMCBBOAFION NDLCLMAFABH, DJBHIFLHJLK _MOBEEPPKFLG_OnFail)
	{
		PJKLMCGEJMK OKDOIAEGADK_Server;
		IDLAIOHLFDI_GetLoginBonuses DLOIHKKKNBB_Request;

		//0x8E68D8
		OKDOIAEGADK_Server = NKGJPJPHLIF.HHCJCDFCLOB.IBLPICFDGOF_ServerRequester;
		DLOIHKKKNBB_Request = OKDOIAEGADK_Server.IFFNCAFNEAG_AddRequest(new IDLAIOHLFDI_GetLoginBonuses());
		yield return DLOIHKKKNBB_Request.GDPDELLNOBO_WaitDone(N.a);
		if(DLOIHKKKNBB_Request.NPNNPNAIONN_IsError)
		{
			_MOBEEPPKFLG_OnFail();
			PLOOEECNHFB_IsDone = true;
		}
		else
		{
			List<int> l = new List<int>(DLOIHKKKNBB_Request.NFEAMMJIMPG_Result.CEBOHGGJBMN_LoginBonuses.Count);
			for(int i = 0; i < DLOIHKKKNBB_Request.NFEAMMJIMPG_Result.CEBOHGGJBMN_LoginBonuses.Count; i++)
			{
				MKCJNKIEADB d = DLOIHKKKNBB_Request.NFEAMMJIMPG_Result.CEBOHGGJBMN_LoginBonuses[i];
				if(d.ILOKENBBBAE_Available(CDEDDEECBBF_LastRequestTime))
				{
					l.Add(d.PPFNGGCBJKC_id);
				}
			}
			long time = OKDOIAEGADK_Server.FJDBNGEPKHL_Time.KMEFBNBFJHI_GetServerTime();
			OKDOIAEGADK_Server.LOMEEJGIAHO.JOJFKIIHMOJ(time);
			if(l.Count == 0)
			{
				NDLCLMAFABH();
				PLOOEECNHFB_IsDone = true;
			}
			else
			{
				yield return N.a.StartCoroutineWatched(GNECDBAHDBP_Coroutine_02_GetStatus(l, MKECMMAJBBH, NDLCLMAFABH, _MOBEEPPKFLG_OnFail));
			}
		}
	}

	//[IteratorStateMachineAttribute] // RVA: 0x6B7290 Offset: 0x6B7290 VA: 0x6B7290
	//// RVA: 0x8E4B3C Offset: 0x8E4B3C VA: 0x8E4B3C
	private IEnumerator GNECDBAHDBP_Coroutine_02_GetStatus(List<int> _EAFEGCPEKDC_Ids, IMCBBOAFION MKECMMAJBBH, IMCBBOAFION NDLCLMAFABH, DJBHIFLHJLK _MOBEEPPKFLG_OnFail)
	{
		NJJGODCKNAK_GetLoginBonusStatuses PNLGHFCFPPK_Request;

		//0x8E6ED4
		PNLGHFCFPPK_Request = NKGJPJPHLIF.HHCJCDFCLOB.IBLPICFDGOF_ServerRequester.IFFNCAFNEAG_AddRequest(new NJJGODCKNAK_GetLoginBonusStatuses());
		PNLGHFCFPPK_Request.EAFEGCPEKDC_Ids = _EAFEGCPEKDC_Ids;
		yield return PNLGHFCFPPK_Request.GDPDELLNOBO_WaitDone(N.a);
		if(PNLGHFCFPPK_Request.NPNNPNAIONN_IsError)
		{
			_MOBEEPPKFLG_OnFail();
			PLOOEECNHFB_IsDone = true;
		}
		else
		{
			List<int> l = new List<int>(PNLGHFCFPPK_Request.NFEAMMJIMPG_Result.CEBOHGGJBMN_LoginBonuses.Count);
			for(int i = 0; i < PNLGHFCFPPK_Request.NFEAMMJIMPG_Result.CEBOHGGJBMN_LoginBonuses.Count; i++)
			{
				KJKDAGGGJCO data = PNLGHFCFPPK_Request.NFEAMMJIMPG_Result.CEBOHGGJBMN_LoginBonuses[i];
				if(data.ILLPEMPBDJG_CanReceiveNext)
				{
					l.Add(data.PPFNGGCBJKC_id);
				}
			}
			if(l.Count != 0)
			{
				yield return N.a.StartCoroutineWatched(PBAHIIPCGKO_Coroutine_03_GetDetail(l, PNLGHFCFPPK_Request.NFEAMMJIMPG_Result.CEBOHGGJBMN_LoginBonuses, MKECMMAJBBH, NDLCLMAFABH, _MOBEEPPKFLG_OnFail));
			}
			else
			{
				NDLCLMAFABH();
				PLOOEECNHFB_IsDone = true;
			}
		}
	}

	//[IteratorStateMachineAttribute] // RVA: 0x6B7308 Offset: 0x6B7308 VA: 0x6B7308
	//// RVA: 0x8E4C50 Offset: 0x8E4C50 VA: 0x8E4C50
	private IEnumerator PBAHIIPCGKO_Coroutine_03_GetDetail(List<int> _EAFEGCPEKDC_Ids, List<KJKDAGGGJCO> LJMDGBEDJCI, IMCBBOAFION MKECMMAJBBH, IMCBBOAFION NDLCLMAFABH, DJBHIFLHJLK _MOBEEPPKFLG_OnFail)
	{
		PJKLMCGEJMK OKDOIAEGADK_Server; // 0x28
		List<EPLAAEHPCDM> KAKLGPBKBPL; // 0x2C
		//int PAPFNLGLAIP; // 0x30
		KJKDAGGGJCO HPDLPGDILBH; // 0x34
		MIILMDFOKBC_GetLoginBonusRecord DCNALBIJJGP; // 0x38
		int AOJPLMHAEMM; // 0x3C

		//0x8E7404
		OKDOIAEGADK_Server = NKGJPJPHLIF.HHCJCDFCLOB.IBLPICFDGOF_ServerRequester;
		//PAPFNLGLAIP = 0;
		KAKLGPBKBPL = new List<EPLAAEHPCDM>();
		for(int i = 0; i < LJMDGBEDJCI.Count; i++)
		{
			//LAB_008e7c2c
			HPDLPGDILBH = LJMDGBEDJCI[i];
			if(HPDLPGDILBH.ILLPEMPBDJG_CanReceiveNext)
			{
				DCNALBIJJGP = OKDOIAEGADK_Server.IFFNCAFNEAG_AddRequest(new MIILMDFOKBC_GetLoginBonusRecord());
				DCNALBIJJGP.PIDIKFIFAPG_Id = HPDLPGDILBH.PPFNGGCBJKC_id;
				DCNALBIJJGP.MLPLGFLKKLI_Ipp = 14;
				DCNALBIJJGP.IGNIIEBMFIN_Page = 1;
				DCNALBIJJGP.FNDBKPJDEDC_AllPrizes = true;
				DCNALBIJJGP.OCGFKMHNEOF_name_for_api = HPDLPGDILBH.BPEAIOBHMFD_NameForApis;
				AOJPLMHAEMM = HPDLPGDILBH.HMFFHLPNMPH_Count;
				if(HPDLPGDILBH.CKHOBDIKJFN_Type == ANPGILOLNFK.CDOGFBNLIPG.MKADAMIGMPO_7_Total)
				{
					DCNALBIJJGP.FNDBKPJDEDC_AllPrizes = false;
				}
				else if(HPDLPGDILBH.CKHOBDIKJFN_Type == ANPGILOLNFK.CDOGFBNLIPG.PHABJLGFJNI_1_Regular)
				{
					DCNALBIJJGP.MLPLGFLKKLI_Ipp = 28;
				}
				yield return DCNALBIJJGP.GDPDELLNOBO_WaitDone(N.a);
				if(!DCNALBIJJGP.NPNNPNAIONN_IsError)
				{
					if(HPDLPGDILBH.CKHOBDIKJFN_Type == ANPGILOLNFK.CDOGFBNLIPG.PHABJLGFJNI_1_Regular)
					{
						int numPrizeList;
						for(numPrizeList = 0; numPrizeList < DCNALBIJJGP.NFEAMMJIMPG_Result.JPILDOGJLDG_login_bonus_prizes.Count; numPrizeList++)
						{
							if(DCNALBIJJGP.NFEAMMJIMPG_Result.JPILDOGJLDG_login_bonus_prizes[numPrizeList].CDCPAEJIJME_IsEmpty())
								break;
						}
						List<CAEDGOPBDNK> l = new List<CAEDGOPBDNK>(14);
						//int a1 = (int)(AOJPLMHAEMM * (4.0f / 7.0f));
						/*0	0 -0x6db6db6d
						1	0
						2	1
						3	1
						4	2
						5	2
						6	3

						7	4
						8	4
						9	5
						10	5
						11	6
						12	6
						13	7

						14	8
						15	8
						16	9
						17	9
						18	10
						19	10
						20	11

						21	12*/
						for(int j = 0; j < 7; j++)
						{
							int a2 = j + AOJPLMHAEMM / 7;//(a1 / 4) * 7;
							/*
							0	0
							1	0
							2	0
							3	0
							4	7
							5	7
							6	7
							7	7
							8	14
							*/
							if(a2 < DCNALBIJJGP.NFEAMMJIMPG_Result.JPILDOGJLDG_login_bonus_prizes.Count)
							{
								DCNALBIJJGP.NFEAMMJIMPG_Result.JPILDOGJLDG_login_bonus_prizes[a2].IANDDEFHKAN_RequiredCount = j + 1;
								l.Add(DCNALBIJJGP.NFEAMMJIMPG_Result.JPILDOGJLDG_login_bonus_prizes[a2]);
							}
						}
						//int a4 = (int)(numPrizeList * (4.0f / 7.0f));
						int a5 = ((AOJPLMHAEMM / 7) + 1) % (numPrizeList / 7);
						int a6 = a5 * 7;
						for(int j = 0; j < 7; j++)
						{
							if(j + a6 < DCNALBIJJGP.NFEAMMJIMPG_Result.JPILDOGJLDG_login_bonus_prizes.Count)
							{
								DCNALBIJJGP.NFEAMMJIMPG_Result.JPILDOGJLDG_login_bonus_prizes[j + a6].IANDDEFHKAN_RequiredCount = j + 1;
								l.Add(DCNALBIJJGP.NFEAMMJIMPG_Result.JPILDOGJLDG_login_bonus_prizes[j + a6]);
							}
						}
						DCNALBIJJGP.NFEAMMJIMPG_Result.JPILDOGJLDG_login_bonus_prizes = l;
					}
					DCNALBIJJGP.NFEAMMJIMPG_Result.KNDAAAAHICA_CurrentCount = AOJPLMHAEMM;
					DCNALBIJJGP.NFEAMMJIMPG_Result.MGANCKPFONE_CurrentCountModulo = AOJPLMHAEMM;
					if(HPDLPGDILBH.CKHOBDIKJFN_Type == ANPGILOLNFK.CDOGFBNLIPG.PHABJLGFJNI_1_Regular)
					{
						DCNALBIJJGP.NFEAMMJIMPG_Result.MGANCKPFONE_CurrentCountModulo -= DCNALBIJJGP.NFEAMMJIMPG_Result.MGANCKPFONE_CurrentCountModulo / 7 * 7;
					}
					KAKLGPBKBPL.Add(DCNALBIJJGP.NFEAMMJIMPG_Result);
					HPDLPGDILBH = null;
					DCNALBIJJGP = null;
				}
				else
				{
					_MOBEEPPKFLG_OnFail();
					yield break;
				}
			}
		}
		if(KAKLGPBKBPL.Count == 0)
		{
			NDLCLMAFABH();
			PLOOEECNHFB_IsDone = true;
		}
		else
		{
			FMAMKPJMFHJ = KAKLGPBKBPL;
			FMAMKPJMFHJ.Sort((EPLAAEHPCDM HKICMNAACDA, EPLAAEHPCDM BNKHBCBJBKI) =>
			{
				//0x8E67F8
				return HKICMNAACDA.PJHKECDOALD - BNKHBCBJBKI.PJHKECDOALD;
			});
			yield return N.a.StartCoroutineWatched(EBKAAOEFIDI_Coroutine_04_Increment(_EAFEGCPEKDC_Ids, MKECMMAJBBH, NDLCLMAFABH, _MOBEEPPKFLG_OnFail));
		}
	}

	//[IteratorStateMachineAttribute] // RVA: 0x6B7380 Offset: 0x6B7380 VA: 0x6B7380
	//// RVA: 0x8E4D80 Offset: 0x8E4D80 VA: 0x8E4D80
	private IEnumerator EBKAAOEFIDI_Coroutine_04_Increment(List<int> _EAFEGCPEKDC_Ids, IMCBBOAFION MKECMMAJBBH, IMCBBOAFION NDLCLMAFABH, DJBHIFLHJLK _MOBEEPPKFLG_OnFail)
	{
		PKIPDDGHPLM_IncrementLoginCount PNLGHFCFPPK_Request;

		//0x8E7FD4
		PNLGHFCFPPK_Request = NKGJPJPHLIF.HHCJCDFCLOB.IBLPICFDGOF_ServerRequester.IFFNCAFNEAG_AddRequest(new PKIPDDGHPLM_IncrementLoginCount());
		PNLGHFCFPPK_Request.NBFDEFGFLPJ = (SakashoErrorId KLCMLLLIANB) =>
		{
			//0x8E6838
			return KLCMLLLIANB == SakashoErrorId.LOGIN_BONUS_ALREADY_RECEIVED;
		};
		PNLGHFCFPPK_Request.EAFEGCPEKDC_Ids = _EAFEGCPEKDC_Ids;
		yield return PNLGHFCFPPK_Request.GDPDELLNOBO_WaitDone(N.a);
		if(PNLGHFCFPPK_Request.NPNNPNAIONN_IsError)
		{
			if(PNLGHFCFPPK_Request.CJMFJOMECKI_ErrorId == SakashoErrorId.LOGIN_BONUS_ALREADY_RECEIVED)
			{
				JHHBAFKMBDL.HHCJCDFCLOB.PHDFLIFNEKC(() =>
				{
					//0x8E6850
					NDLCLMAFABH();
					PLOOEECNHFB_IsDone = true;
				});
				yield break;
			}
			_MOBEEPPKFLG_OnFail();
		}
		else
		{
			GAOEDFGMHFD = PNLGHFCFPPK_Request.NFEAMMJIMPG_Result.CEBOHGGJBMN_LoginBonuses;
			FBKCFKPLMAL_AddItems();
			CLOEPIEINPM_UpdateNotif();
			FBHGHFANDEJ_MergeComeBack();
			MKECMMAJBBH();
		}
		PLOOEECNHFB_IsDone = true;
	}

	//// RVA: 0x8E4E98 Offset: 0x8E4E98 VA: 0x8E4E98
	private void FBKCFKPLMAL_AddItems()
	{
		JKNGJFOBADP data = new JKNGJFOBADP();
		for(int i = 0; i < GAOEDFGMHFD.Count; i++)
		{
			string str = string.Concat(new object[5]
			{
				GAOEDFGMHFD[i].OPFGFINHFCE_name,
				":",
				GAOEDFGMHFD[i].BPEAIOBHMFD_NameForApis,
				":",
				GAOEDFGMHFD[i].HMFFHLPNMPH_Count
			});
			for(int j = 0; j < GAOEDFGMHFD[i].PJJFEAHIPGL_inventories.Count; j++)
			{
				data.FEGDNPIEKJC(OAGBCBBHMPF.COIIJOEKBDH.FBCINBIIABE_11, str);
                EKLNMHFCAOI.FKGCBLHOOCL_Category cat = GAOEDFGMHFD[i].PJJFEAHIPGL_inventories[j].NPPNDDMPFJJ_ItemCategory;
                int id = GAOEDFGMHFD[i].PJJFEAHIPGL_inventories[j].NNFNGLJOKKF_ItemId;
				int rar = EKLNMHFCAOI.FABCKNDLPDH_GetItemRarity(cat, id);
				int cnt = GAOEDFGMHFD[i].PJJFEAHIPGL_inventories[j].MBJIFDBEDAC_item_count;
				switch(GAOEDFGMHFD[i].PJJFEAHIPGL_inventories[j].NPPNDDMPFJJ_ItemCategory)
				{
					case EKLNMHFCAOI.FKGCBLHOOCL_Category.PJDEOPMBGKJ_PaidVC:
					case EKLNMHFCAOI.FKGCBLHOOCL_Category.OBHECJMAEIO_GachaTicket:
						data.NGEPPDAOIBN(cat, id, cnt, 0, 0);
						break;
					case EKLNMHFCAOI.FKGCBLHOOCL_Category.ACGHELNGNGK_UnionCredit:
						DGDIEDDPNNG_UcItem.FCPCMPLGJNP ucDbItem = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.NMJEDFNPIPL_UcItem.CDENCMNHNGA_table[id - 1];
						data.NGEPPDAOIBN(EKLNMHFCAOI.FKGCBLHOOCL_Category.ACGHELNGNGK_UnionCredit, id, ucDbItem.JBGEEPFKIGG_val * cnt, 0, 0);
						break;
					case EKLNMHFCAOI.FKGCBLHOOCL_Category.HLCHKCJLEGK_GrowItem:
						data.NGEPPDAOIBN(EKLNMHFCAOI.FKGCBLHOOCL_Category.HLCHKCJLEGK_GrowItem, id, cnt, 0, rar);
						break;
					case EKLNMHFCAOI.FKGCBLHOOCL_Category.MEDAKGBKIMO_EpisodeItem:
						data.NGEPPDAOIBN(EKLNMHFCAOI.FKGCBLHOOCL_Category.MEDAKGBKIMO_EpisodeItem, id, cnt, 0, rar);
						break;
					case EKLNMHFCAOI.FKGCBLHOOCL_Category.MNCJMDDAFJB_EmblemItem:
						data.NGEPPDAOIBN(EKLNMHFCAOI.FKGCBLHOOCL_Category.MNCJMDDAFJB_EmblemItem, id, cnt, 0, rar);
						break;
					case EKLNMHFCAOI.FKGCBLHOOCL_Category.GIMBFBNKPNO_CompoItem:
						HHPEMHHCKBE_Compo.MLMDKHBFOJM compoDbItem = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.ALFKMKICDPP_Compo.CDENCMNHNGA_table[id - 1];
						for(int k = 0; k < compoDbItem.JCJGGHGIKIJ(); k++)
						{
							int subId = compoDbItem.CBLLFCGEJAI(k);
							data.NGEPPDAOIBN(EKLNMHFCAOI.BKHFLDMOGBD_GetItemCategory(subId), EKLNMHFCAOI.DEACAHNLMNI_getItemId(subId), compoDbItem.HBJMCLGKLBA(k), 0, EKLNMHFCAOI.FABCKNDLPDH_GetItemRarity(subId));
						}
						break;
				}
			}
		}
	}

	//// RVA: 0x8E59B0 Offset: 0x8E59B0 VA: 0x8E59B0
	private void CLOEPIEINPM_UpdateNotif()
	{
		JKNGJFOBADP data = new JKNGJFOBADP();
		for(int i = 0; i < GAOEDFGMHFD.Count; i++)
		{
			string str = string.Concat(new object[5]
			{
				GAOEDFGMHFD[i].OPFGFINHFCE_name,
				":",
				GAOEDFGMHFD[i].BPEAIOBHMFD_NameForApis,
				":",
				GAOEDFGMHFD[i].HMFFHLPNMPH_Count
			});
			if(GAOEDFGMHFD[i].BPEAIOBHMFD_NameForApis.Contains("start"))
			{
				if(GAOEDFGMHFD[i].HMFFHLPNMPH_Count == 2)
				{
					EOHDAOAJOHH.HHCJCDFCLOB.JOADGPOBFMC();
				}
				else if(GAOEDFGMHFD[i].HMFFHLPNMPH_Count == 1)
				{
					EOHDAOAJOHH.HHCJCDFCLOB.COGJLOMPOKK(1, IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.GDEKCOOBLMA_System.LPJLEHAJADA("start_dash_notify_hour", 12));
				}
			}
		}
	}

	//// RVA: 0x8E5ED0 Offset: 0x8E5ED0 VA: 0x8E5ED0
	private void FBHGHFANDEJ_MergeComeBack()
	{
		int a1 = -1;
		int a2 = -1;
		for(int i = 0; i < GAOEDFGMHFD.Count; i++)
		{
			if(GAOEDFGMHFD[i].BPEAIOBHMFD_NameForApis.Contains("comback1_"))
			{
				a2 = i;
			}
			else if(GAOEDFGMHFD[i].BPEAIOBHMFD_NameForApis.Contains("comback2_"))
			{
				a1 = i;
			}
		}
		if(a1 > -1 && a2 > -1)
		{
			GAOEDFGMHFD[a2].PJJFEAHIPGL_inventories.InsertRange(0, GAOEDFGMHFD[a1].PJJFEAHIPGL_inventories);
			for(int i = 0; i < FMAMKPJMFHJ.Count; i++)
			{
				if(FMAMKPJMFHJ[i].BPEAIOBHMFD_NameForApis.Contains("comback1_"))
				{
					for(int j = 0; j < FMAMKPJMFHJ.Count; j++)
					{
						if(FMAMKPJMFHJ[j].BPEAIOBHMFD_NameForApis.Contains("comback2_"))
						{
							if(FMAMKPJMFHJ[i].JPILDOGJLDG_login_bonus_prizes.Count == FMAMKPJMFHJ[j].JPILDOGJLDG_login_bonus_prizes.Count)
							{
								for(int k = 0; k < FMAMKPJMFHJ[i].JPILDOGJLDG_login_bonus_prizes.Count; k++)
								{
									if(FMAMKPJMFHJ[i].JPILDOGJLDG_login_bonus_prizes[k].HBHMAKNGKFK_Items != null)
									{
										if(FMAMKPJMFHJ[j].JPILDOGJLDG_login_bonus_prizes[k] != null)
										{
											FMAMKPJMFHJ[i].JPILDOGJLDG_login_bonus_prizes[k].HBHMAKNGKFK_Items.InsertRange(0, FMAMKPJMFHJ[j].JPILDOGJLDG_login_bonus_prizes[k].HBHMAKNGKFK_Items);
										}
									}
								}
							}
						}
					}
					break;
				}
			}
			//LAB_008e6504
			GAOEDFGMHFD.RemoveAt(a1);
			for(int i = 0; i < FMAMKPJMFHJ.Count; i++)
			{
				if(FMAMKPJMFHJ[i].BPEAIOBHMFD_NameForApis.Contains("comback2_"))
				{
					FMAMKPJMFHJ.RemoveAt(i);
					i--;
				}
			}
		}
		for(int i = 0; i < FMAMKPJMFHJ.Count; i++)
		{
			if(FMAMKPJMFHJ[i].CKHOBDIKJFN_Type == ANPGILOLNFK.CDOGFBNLIPG.CEIJKIOOIPE_4_Comback2)
			{
				FMAMKPJMFHJ[i].CKHOBDIKJFN_Type = ANPGILOLNFK.CDOGFBNLIPG.DHGCJEOPEIE_3_Comback1;
			}
		}
	}
}
