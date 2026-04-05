
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using XeApp;

public class NDABOOOOENC
{
	private static string[] JIMKNDJMCID_Keys = new string[31] {"", "CgkIt5LD99oYEAIQAQ", "CgkIt5LD99oYEAIQAg", "CgkIt5LD99oYEAIQAw", "CgkIt5LD99oYEAIQBA", "CgkIt5LD99oYEAIQBQ", 
														"CgkIt5LD99oYEAIQBg", "CgkIt5LD99oYEAIQBw", "CgkIt5LD99oYEAIQCA", "CgkIt5LD99oYEAIQCQ", "CgkIt5LD99oYEAIQCg",
														"CgkIt5LD99oYEAIQCw", "CgkIt5LD99oYEAIQDA", "CgkIt5LD99oYEAIQDQ", "CgkIt5LD99oYEAIQDg", "CgkIt5LD99oYEAIQDw",
														"CgkIt5LD99oYEAIQEA", "CgkIt5LD99oYEAIQEQ", "CgkIt5LD99oYEAIQEg", "CgkIt5LD99oYEAIQEw", "CgkIt5LD99oYEAIQFA",
														"CgkIt5LD99oYEAIQFQ", "CgkIt5LD99oYEAIQFg", "CgkIt5LD99oYEAIQFw", "CgkIt5LD99oYEAIQGA", "CgkIt5LD99oYEAIQGQ",
														"CgkIt5LD99oYEAIQGg", "CgkIt5LD99oYEAIQHA", "CgkIt5LD99oYEAIQHQ", "CgkIt5LD99oYEAIQHg", "CgkIt5LD99oYEAIQHw"}; // 0x4
	private bool GKDLPKNOGCK_Initialized; // 0x8
	private bool APEIJNFMEFG_ShowButton; // 0x9
	private int FAGBLGODELF_LoginStatus; // 0xC

	public static NDABOOOOENC HHCJCDFCLOB_Instance { get; private set; } // 0x0 LGMPACEDIJF_bgs NKACBOEHELJ_bgs OKPMHKNCNAL_bgs
	public bool LHGFPPIEKPJ { get { return APEIJNFMEFG_ShowButton; } set { return; } } // PFHHNKMGPGJ_bgs 0x1ADB760 DNPOLCNDBKH_bgs 0x1ADB768

	// // RVA: 0x1ADB76C Offset: 0x1ADB76C VA: 0x1ADB76C
	public void IJBGPAENLJA_OnAwake()
	{
		HHCJCDFCLOB_Instance = this;
	}

	// // RVA: 0x1ADB7EC Offset: 0x1ADB7EC VA: 0x1ADB7EC
	private string DMCLJKABBCJ_GetSavePath()
	{
		return Application.persistentDataPath + "/SaveData/gpgs.bin";
	}

	// // RVA: 0x1ADB854 Offset: 0x1ADB854 VA: 0x1ADB854
	private string KJEOLHCEDJI_GetSaveDirectory()
	{
		return Application.persistentDataPath + "/SaveData";
	}

	// // RVA: 0x1ADB8BC Offset: 0x1ADB8BC VA: 0x1ADB8BC
	private bool KBCANNBANIL_ReadStatusOnSavedFile()
	{
		if (!GKDLPKNOGCK_Initialized)
			return false;
		APEIJNFMEFG_ShowButton = true;
		if(File.Exists(DMCLJKABBCJ_GetSavePath()))
		{
			byte[] data = File.ReadAllBytes(DMCLJKABBCJ_GetSavePath());
			FAGBLGODELF_LoginStatus = data[0];
			if(FAGBLGODELF_LoginStatus == 2)
			{
				Debug.Log(JpStringLiterals.StringLiteral_12532);
			}
			else
			{
				Debug.Log(JpStringLiterals.StringLiteral_12533);
			}
		}
		else
		{
			Debug.Log(JpStringLiterals.StringLiteral_12534);
		}
		return true;
	}

	// // RVA: 0x1ADBA34 Offset: 0x1ADBA34 VA: 0x1ADBA34
	private void HJOPHGFDHAM_SetStatus(int MFBIAOAGPHB)
	{
		FAGBLGODELF_LoginStatus = MFBIAOAGPHB;
		if(!Directory.Exists(KJEOLHCEDJI_GetSaveDirectory()))
		{
			Directory.CreateDirectory(KJEOLHCEDJI_GetSaveDirectory());
		}
		byte[] data = new byte[1];
		data[0] = (byte)FAGBLGODELF_LoginStatus;
		File.WriteAllBytes(DMCLJKABBCJ_GetSavePath(), data);
	}

	// // RVA: 0x1ADBB08 Offset: 0x1ADBB08 VA: 0x1ADBB08
	public void NCDLCIPGPNC_Login()
    {
		if(!GKDLPKNOGCK_Initialized)
		{
			if(!AppEnv.IsCBT())
			{
				TodoLogger.LogError(TodoLogger.Playgames, "NDABOOOOENC.NCDLCIPGPNC_Login (playgames)");
				Debug.Log("call PlayGamesPlatform.Activate");
				GKDLPKNOGCK_Initialized = true;
				KBCANNBANIL_ReadStatusOnSavedFile();
				if(FAGBLGODELF_LoginStatus == 1)
				{
					Debug.Log("auto Authenticate");
					OHFNPFMHMMJ_TryLogin(() =>
					{
						//0x1ADDD7C
						return;
					}, false);
				}
			}
		}
    }

	// // RVA: 0x1ADBDC0 Offset: 0x1ADBDC0 VA: 0x1ADBDC0
	public void OHFNPFMHMMJ_TryLogin(IMCBBOAFION _CNJANCCFBIL_Cb, bool HCEMFKINGPE_Force)
	{
		if(GKDLPKNOGCK_Initialized)
		{
			if(!MLHPNINMOJO_IsAuth())
			{
				KBCANNBANIL_ReadStatusOnSavedFile();
				if(FAGBLGODELF_LoginStatus == 1 || HCEMFKINGPE_Force)
				{
					Social.localUser.Authenticate((bool _FHANAFNKIFC_success) =>
					{
						//0x1ADDD84
						if(_FHANAFNKIFC_success)
						{
							HJOPHGFDHAM_SetStatus(1);
							Debug.Log(JpStringLiterals.StringLiteral_12573);
							if(HCEMFKINGPE_Force)
							{
								NHDNHAONHBK_ShowAchievements();
							}
						}
						else
						{
							HJOPHGFDHAM_SetStatus(2);
						}
						_CNJANCCFBIL_Cb();
					});
					return;
				}
			}
			else if(HCEMFKINGPE_Force)
			{
				NHDNHAONHBK_ShowAchievements();
			} 
		}
		_CNJANCCFBIL_Cb();
	}

	// // RVA: 0x1ADBFEC Offset: 0x1ADBFEC VA: 0x1ADBFEC
	public bool MLHPNINMOJO_IsAuth()
	{
		if(!GKDLPKNOGCK_Initialized)
			return false;
		return Social.localUser.authenticated;
	}

	// // RVA: 0x1ADC2EC Offset: 0x1ADC2EC VA: 0x1ADC2EC
	// public void ACIACICNEJI() { }

	// // RVA: 0x1ADC0E0 Offset: 0x1ADC0E0 VA: 0x1ADC0E0
	public void NHDNHAONHBK_ShowAchievements()
	{
		if(!GKDLPKNOGCK_Initialized)
			return;
		if (AppEnv.IsCBT())
			return;
		Debug.Log("call ShowAchievementsUI");
		Social.ShowAchievementsUI();
		Debug.Log("end ShowAchievementsUI");
		if(Social.localUser.authenticated)
		{
			Debug.Log(JpStringLiterals.StringLiteral_12540);
		}
		else
		{
			Debug.Log(JpStringLiterals.StringLiteral_12541);
		}
	}

	// // RVA: 0x1ADC3E8 Offset: 0x1ADC3E8 VA: 0x1ADC3E8
	public void GLHANCMGNDM_Unlock(int _PPFNGGCBJKC_id, double _JBGEEPFKIGG_val/* = 100*/)
	{
		if(!AppEnv.IsCBT() && GKDLPKNOGCK_Initialized)
		{
			if(_PPFNGGCBJKC_id < JIMKNDJMCID_Keys.Length)
			{
				string achId = JIMKNDJMCID_Keys[_PPFNGGCBJKC_id];
				if(_PPFNGGCBJKC_id >= 27 && _PPFNGGCBJKC_id < 31)
				{
					string str = IMMAOANGPNK_NetMasterDataManager.HHCJCDFCLOB_Instance.NKEBMCIMJND_Database.GDEKCOOBLMA_System.EFEGBHACJAL_GetStringParam("gpgs_key_" + _PPFNGGCBJKC_id, "");
					if (!string.IsNullOrEmpty(str))
						achId = str;
				}
				Social.ReportProgress(achId, 100, (bool _FHANAFNKIFC_success) =>
				{
					//0x1ADDD80
					return;
				});
			}
		}
	}

	// // RVA: 0x1ADC758 Offset: 0x1ADC758 VA: 0x1ADC758
	public List<int> HHKNOHKGAHP()
	{
		List<int> res = new List<int>();
		if(GKDLPKNOGCK_Initialized)
		{
			if(IMMAOANGPNK_NetMasterDataManager.HHCJCDFCLOB_Instance.LNAHEIEIBOI_Initialized)
			{
				if(CIOECGOMILE_NetPlayerDataManager.HHCJCDFCLOB_Instance.LNAHEIEIBOI_Initialized)
				{
					for(int i = 0; i < IMMAOANGPNK_NetMasterDataManager.HHCJCDFCLOB_Instance.NKEBMCIMJND_Database.MHGPMMIDKMM_Quest.GPMKFMFEKLN_NormalQuests.Count; i++)
					{
						CNLPPCFJEID_QuestInfo dbquest = IMMAOANGPNK_NetMasterDataManager.HHCJCDFCLOB_Instance.NKEBMCIMJND_Database.MHGPMMIDKMM_Quest.GPMKFMFEKLN_NormalQuests[i];
						if (dbquest.INDDJNMPONH_type != 0)
						{
							if(dbquest.HDBFCIOCNPA_AchievementId != 0)
							{
								if(ILLPDLODANB.OBOJKHIJBGL_GetNormalQuestStatus(dbquest.PPFNGGCBJKC_id, IMMAOANGPNK_NetMasterDataManager.HHCJCDFCLOB_Instance.NKEBMCIMJND_Database, CIOECGOMILE_NetPlayerDataManager.HHCJCDFCLOB_Instance.AHEFHIMGIBI_PlayerData, true) > 1)
								{
									res.Add(dbquest.HDBFCIOCNPA_AchievementId);
								}
							}
						}
					}
				}
			}
		}
		return res;
	}

	// // RVA: 0x1ADCB04 Offset: 0x1ADCB04 VA: 0x1ADCB04
	public void NKFNJMEELMP_UnlockAchievements(List<int> PKDKPCOOPLL)
	{
		if(GKDLPKNOGCK_Initialized)
		{
			for(int i = 0; i < PKDKPCOOPLL.Count; i++)
			{
				GLHANCMGNDM_Unlock(PKDKPCOOPLL[i], 100);
			}
		}
	}

	// // RVA: 0x1ADCBE8 Offset: 0x1ADCBE8 VA: 0x1ADCBE8
	public void NKFNJMEELMP_UnlockAchievements()
	{
		if(GKDLPKNOGCK_Initialized)
		{
			if(IMMAOANGPNK_NetMasterDataManager.HHCJCDFCLOB_Instance.LNAHEIEIBOI_Initialized)
			{
				if(CIOECGOMILE_NetPlayerDataManager.HHCJCDFCLOB_Instance.LNAHEIEIBOI_Initialized)
				{
					for(int i = 0; i < IMMAOANGPNK_NetMasterDataManager.HHCJCDFCLOB_Instance.NKEBMCIMJND_Database.MHGPMMIDKMM_Quest.GPMKFMFEKLN_NormalQuests.Count; i++)
					{
						CNLPPCFJEID_QuestInfo dbQuest = IMMAOANGPNK_NetMasterDataManager.HHCJCDFCLOB_Instance.NKEBMCIMJND_Database.MHGPMMIDKMM_Quest.GPMKFMFEKLN_NormalQuests[i];
						if (dbQuest.INDDJNMPONH_type != 0)
						{
							if(dbQuest.HDBFCIOCNPA_AchievementId != 0)
							{
								if(ILLPDLODANB.OBOJKHIJBGL_GetNormalQuestStatus(dbQuest.PPFNGGCBJKC_id, IMMAOANGPNK_NetMasterDataManager.HHCJCDFCLOB_Instance.NKEBMCIMJND_Database, CIOECGOMILE_NetPlayerDataManager.HHCJCDFCLOB_Instance.AHEFHIMGIBI_PlayerData, true) > 1)
								{
									GLHANCMGNDM_Unlock(dbQuest.HDBFCIOCNPA_AchievementId, 100);
								}
							}
						}
					}
				}
			}
		}
	}

	// // RVA: 0x1ADCF50 Offset: 0x1ADCF50 VA: 0x1ADCF50
	// public void FBHNMIHJGCO() { }
}
