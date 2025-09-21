
using System.Collections.Generic;
using XeSys;

public class HFDMKKIFNNP
{
	public bool EDHFIFDAJPA_IsFirstTime; // 0x8
	public int BNLIFKAGPFE_ResetHours; // 0xC
	public int CDHKHOLCGAC_DurationDays; // 0x10
	public int ACGICAHHCIG_ResetCount; // 0x14

	// RVA: 0x1748650 Offset: 0x1748650 VA: 0x1748650
	public void KHEKNNFCAOI_Init(EDOHBJAPLPF_JsonData _IDLHJIOMJBK_Data)
	{
		EDHFIFDAJPA_IsFirstTime = (bool)_IDLHJIOMJBK_Data["is_first_time"];
		BNLIFKAGPFE_ResetHours = -1;
		if(_IDLHJIOMJBK_Data.BBAJPINMOEP_Contains("reset_hours"))
		{
			if(_IDLHJIOMJBK_Data["reset_hours"] != null)
			{
				if(_IDLHJIOMJBK_Data["reset_hours"].MDDJBLEDMBJ_IsInt)
				{
					BNLIFKAGPFE_ResetHours = (int)_IDLHJIOMJBK_Data["reset_hours"];
				}
			}
		}
		CDHKHOLCGAC_DurationDays = -1;
		if(_IDLHJIOMJBK_Data.BBAJPINMOEP_Contains("duration_days"))
		{
			if(_IDLHJIOMJBK_Data["duration_days"] != null && _IDLHJIOMJBK_Data["duration_days"].MDDJBLEDMBJ_IsInt)
			{
				CDHKHOLCGAC_DurationDays = (int)_IDLHJIOMJBK_Data["duration_days"];
			}
		}
		ACGICAHHCIG_ResetCount = -1;
		if (_IDLHJIOMJBK_Data.BBAJPINMOEP_Contains("reset_count"))
		{
			if (_IDLHJIOMJBK_Data["reset_count"] != null && _IDLHJIOMJBK_Data["reset_count"].MDDJBLEDMBJ_IsInt)
			{
				ACGICAHHCIG_ResetCount = (int)_IDLHJIOMJBK_Data["reset_count"];
			}
		}
	}
}

public class PFIJNPCEOIL
{
	public bool LDBPAJKIPKD_IsNextFree; // 0x8
	public int LJPIOGBFEKA_RemainsCount; // 0xC
	public long NEMGBIEILOI_NextTimeAt; // 0x10

	// RVA: 0x16C286C Offset: 0x16C286C VA: 0x16C286C
	public void KHEKNNFCAOI_Init(EDOHBJAPLPF_JsonData _IDLHJIOMJBK_Data)
	{
		LDBPAJKIPKD_IsNextFree = (bool)_IDLHJIOMJBK_Data["is_next_free"];
		if (_IDLHJIOMJBK_Data.BBAJPINMOEP_Contains("remains_count"))
		{
			if (_IDLHJIOMJBK_Data["remains_count"] != null && _IDLHJIOMJBK_Data["remains_count"].MDDJBLEDMBJ_IsInt)
			{
				LJPIOGBFEKA_RemainsCount = (int)_IDLHJIOMJBK_Data["remains_count"];
			}
		}
		if (_IDLHJIOMJBK_Data.BBAJPINMOEP_Contains("next_time_at"))
		{
			if (_IDLHJIOMJBK_Data["next_time_at"] != null && _IDLHJIOMJBK_Data["next_time_at"].DCPEFFOMOOK_IsLong)
			{
				NEMGBIEILOI_NextTimeAt = (long)_IDLHJIOMJBK_Data["next_time_at"];
			}
		}
	}
}


[System.Obsolete("Use KBPDNHOKEKD_ProductId", true)]
public class KBPDNHOKEKD { }
public class KBPDNHOKEKD_ProductId
{
	public enum KNEKLJHNHAK
	{
		HJNNKCMLGFL_0_None = 0,
		LCLLMJGIMHC_1 = 1,
		PBEMIDKNPNH_2 = 2,
		DKIKNLEDDBK_3 = 3,
		AAPLMEGMNJA_4 = 4,
	}

	public int PPFNGGCBJKC_id; // 0x8
	public string GLHKICCPGKJ_PlatformProductId; // 0xC
	public string OPFGFINHFCE_name; // 0x10
	public string OriginalName;
	public string KLMPFGOCBHC_description; // 0x14
	public string EFIMCLPAEEN_ImageUrl; // 0x18
	public int NPPGKNGIFGK_price; // 0x1C
	public string JMEMGIPGGIK_currency_code; // 0x20
	public int OJIMENABACH_price_amount_micros; // 0x24
	public string NGIKLCDKAMB_FormatedPrice; // 0x28
	public int HMFDJHEEGNN_BuyLimit; // 0x2C
	public int GIEBJDKLCDH_BoughtQuantity; // 0x30
	public int KAPMOPMDHJE_label; // 0x34
	public int PANKNKOIIJE_group_key; // 0x38
	public List<string> GJEBPJHECIK_ItemSetNameForApi = new List<string>(); // 0x3C
	public long KBFOIECIADN_opened_at; // 0x40
	public long EGBOHDFBAPB_ClosedAt; // 0x48
	public string MMOIFDEPIEP_app_public_key; // 0x50
	public HFDMKKIFNNP KHEGONOKLPN_NormalLotFreeSetting; // 0x54
	public PFIJNPCEOIL JENBPPBNAHP_PlayerNormalLotFreeState; // 0x58
	public bool PAFFIBGPOJN__rare4only; // 0x5C
	public int CANACBAPKFK_ForcedCount; // 0x60

	public bool EJENFBLDAIN_IsOwnedMax { get { 
		if(HMFDJHEEGNN_BuyLimit > 0)
			return GIEBJDKLCDH_BoughtQuantity == HMFDJHEEGNN_BuyLimit;
		return false;
	 } } //0x101CE84 KNLOMFHAKEG
	public int JHAIOJELFHI_GetNumLot { get
		{
			if (CANACBAPKFK_ForcedCount > 0)
				return CANACBAPKFK_ForcedCount;
			if (GJEBPJHECIK_ItemSetNameForApi != null)
				return GJEBPJHECIK_ItemSetNameForApi.Count;
			return 0;
		}
	} //0x101CEAC DLEHIBPEDIK

	//// RVA: 0x101CF2C Offset: 0x101CF2C VA: 0x101CF2C
	public void KHEKNNFCAOI_Init(EDOHBJAPLPF_JsonData _IDLHJIOMJBK_Data)
	{
		PPFNGGCBJKC_id = CEDHHAGBIBA.GNJBKANDLEE_ReadInt(_IDLHJIOMJBK_Data, AFEHLCGHAEE_Strings.PPFNGGCBJKC_id);
		GLHKICCPGKJ_PlatformProductId = CEDHHAGBIBA.BNCLNFJHEND_ReadString(_IDLHJIOMJBK_Data, AFEHLCGHAEE_Strings.GLHKICCPGKJ_PlatformProductId);
		OPFGFINHFCE_name = CEDHHAGBIBA.BNCLNFJHEND_ReadString(_IDLHJIOMJBK_Data, AFEHLCGHAEE_Strings.OPFGFINHFCE_name);
		OriginalName = CEDHHAGBIBA.BNCLNFJHEND_ReadString(_IDLHJIOMJBK_Data, "original_name");
		KLMPFGOCBHC_description = CEDHHAGBIBA.BNCLNFJHEND_ReadString(_IDLHJIOMJBK_Data, AFEHLCGHAEE_Strings.KLMPFGOCBHC_description);
		EFIMCLPAEEN_ImageUrl = CEDHHAGBIBA.BNCLNFJHEND_ReadString(_IDLHJIOMJBK_Data, AFEHLCGHAEE_Strings.EFIMCLPAEEN_ImageUrl);
		NPPGKNGIFGK_price = CEDHHAGBIBA.GNJBKANDLEE_ReadInt(_IDLHJIOMJBK_Data, AFEHLCGHAEE_Strings.NPPGKNGIFGK_price);
		JMEMGIPGGIK_currency_code = CEDHHAGBIBA.BNCLNFJHEND_ReadString(_IDLHJIOMJBK_Data, AFEHLCGHAEE_Strings.JMEMGIPGGIK_currency_code);
		OJIMENABACH_price_amount_micros = CEDHHAGBIBA.GNJBKANDLEE_ReadInt(_IDLHJIOMJBK_Data, AFEHLCGHAEE_Strings.OJIMENABACH_price_amount_micros);
		HMFDJHEEGNN_BuyLimit = CEDHHAGBIBA.GNJBKANDLEE_ReadInt(_IDLHJIOMJBK_Data, AFEHLCGHAEE_Strings.HMFDJHEEGNN_BuyLimit);
		GIEBJDKLCDH_BoughtQuantity = CEDHHAGBIBA.GNJBKANDLEE_ReadInt(_IDLHJIOMJBK_Data, AFEHLCGHAEE_Strings.GIEBJDKLCDH_BoughtQuantity);
		KAPMOPMDHJE_label = CEDHHAGBIBA.GNJBKANDLEE_ReadInt(_IDLHJIOMJBK_Data, AFEHLCGHAEE_Strings.KAPMOPMDHJE_label);
		PANKNKOIIJE_group_key = CEDHHAGBIBA.GNJBKANDLEE_ReadInt(_IDLHJIOMJBK_Data, AFEHLCGHAEE_Strings.PANKNKOIIJE_group_key);
		KBFOIECIADN_opened_at = CEDHHAGBIBA.NIKODNFGCEM_ReadLong(_IDLHJIOMJBK_Data, AFEHLCGHAEE_Strings.KBFOIECIADN_opened_at);
		EGBOHDFBAPB_ClosedAt = CEDHHAGBIBA.NIKODNFGCEM_ReadLong(_IDLHJIOMJBK_Data, AFEHLCGHAEE_Strings.EGBOHDFBAPB_CloseAt);
		MMOIFDEPIEP_app_public_key = CEDHHAGBIBA.BNCLNFJHEND_ReadString(_IDLHJIOMJBK_Data, AFEHLCGHAEE_Strings.MMOIFDEPIEP_app_public_key);
		NGIKLCDKAMB_FormatedPrice = CEDHHAGBIBA.BNCLNFJHEND_ReadString(_IDLHJIOMJBK_Data, "formatted_price");
		if (EGBOHDFBAPB_ClosedAt != 0)
			EGBOHDFBAPB_ClosedAt--;
		int idx = OPFGFINHFCE_name.IndexOf(" (TEST1234");
		if (idx > -1)
		{
			OPFGFINHFCE_name = OPFGFINHFCE_name.Substring(0, idx);
		}
		idx = OPFGFINHFCE_name.IndexOf(JpStringLiterals.StringLiteral_12097_Jp);
		if(idx > -1)
		{
			OPFGFINHFCE_name = OPFGFINHFCE_name.Substring(0, idx);
		}
		GJEBPJHECIK_ItemSetNameForApi = null;
		PAFFIBGPOJN__rare4only = false;
		if(_IDLHJIOMJBK_Data.BBAJPINMOEP_Contains(AFEHLCGHAEE_Strings.GJEBPJHECIK_ItemSetNameForApi))
		{
			EDOHBJAPLPF_JsonData a = _IDLHJIOMJBK_Data[AFEHLCGHAEE_Strings.GJEBPJHECIK_ItemSetNameForApi];
			if(a != null)
			{
				GJEBPJHECIK_ItemSetNameForApi = new List<string>(a.HNBFOAJIIAL_Count);
				for (int i = 0; i < a.HNBFOAJIIAL_Count; i++)
				{
					string s = (string)a[i];
					if (s.Contains(AFEHLCGHAEE_Strings.PAFFIBGPOJN__rare4only))
					{
						PAFFIBGPOJN__rare4only = true;
					}
					GJEBPJHECIK_ItemSetNameForApi.Add(s);
				}
			}
		}
		KHEGONOKLPN_NormalLotFreeSetting = null;
		if(_IDLHJIOMJBK_Data.BBAJPINMOEP_Contains("normal_lot_free_setting"))
		{
			KHEGONOKLPN_NormalLotFreeSetting = new HFDMKKIFNNP();
			KHEGONOKLPN_NormalLotFreeSetting.KHEKNNFCAOI_Init(_IDLHJIOMJBK_Data["normal_lot_free_setting"]);
		}
		JENBPPBNAHP_PlayerNormalLotFreeState = null;
		if(_IDLHJIOMJBK_Data.BBAJPINMOEP_Contains("player_normal_lot_free_state"))
		{
			JENBPPBNAHP_PlayerNormalLotFreeState = new PFIJNPCEOIL();
			JENBPPBNAHP_PlayerNormalLotFreeState.KHEKNNFCAOI_Init(_IDLHJIOMJBK_Data["player_normal_lot_free_state"]);
		}
	}

	//// RVA: 0x101D66C Offset: 0x101D66C VA: 0x101D66C
	public void OCBHANFFLOO_SetTutoGachaProduct(int _HMFFHLPNMPH_Count)
	{
		OPFGFINHFCE_name = MessageManager.Instance.GetMessage("menu", "tuto_gacha_title");
		OriginalName = "デカルガチャ";
		KLMPFGOCBHC_description = MessageManager.Instance.GetMessage("menu", "tuto_gacha_desc");
		CANACBAPKFK_ForcedCount = _HMFFHLPNMPH_Count;
		HMFDJHEEGNN_BuyLimit = 0;
		GIEBJDKLCDH_BoughtQuantity = 0;
		KAPMOPMDHJE_label = (_HMFFHLPNMPH_Count == 10) ? 7000102 : 7000101;
		NPPGKNGIFGK_price = (_HMFFHLPNMPH_Count == 10) ? 500 : 50;
		KBFOIECIADN_opened_at = Utility.GetTargetUnixTime(2010, 1, 1, 0, 0, 0);
		EGBOHDFBAPB_ClosedAt = Utility.GetTargetUnixTime(3000, 1, 1, 0, 0, 0);
	}

	//// RVA: 0x101D81C Offset: 0x101D81C VA: 0x101D81C
	//public bool HFEFJALCHMM() { }

	//// RVA: 0x101D83C Offset: 0x101D83C VA: 0x101D83C
	public int HCMGHDNNJOM()
	{
		if (JENBPPBNAHP_PlayerNormalLotFreeState == null)
			return -1;
		return JENBPPBNAHP_PlayerNormalLotFreeState.LJPIOGBFEKA_RemainsCount;
	}

	//// RVA: 0x101D850 Offset: 0x101D850 VA: 0x101D850
	//public int EDODPNCAGKN() { }

	//// RVA: 0x101D864 Offset: 0x101D864 VA: 0x101D864
	//public bool DIOPMDBJELP() { }

	//// RVA: 0x101D8A4 Offset: 0x101D8A4 VA: 0x101D8A4
	//public bool NIHLEOHPAFC() { }

	//// RVA: 0x101D8E0 Offset: 0x101D8E0 VA: 0x101D8E0
	public KNEKLJHNHAK FJICMLBOJCH()
	{
		if(JENBPPBNAHP_PlayerNormalLotFreeState == null)
		{
			if(KHEGONOKLPN_NormalLotFreeSetting == null)
				return KNEKLJHNHAK.HJNNKCMLGFL_0_None;
		}
		else
		{
			if(KHEGONOKLPN_NormalLotFreeSetting == null)
				return KNEKLJHNHAK.HJNNKCMLGFL_0_None;
			if(JENBPPBNAHP_PlayerNormalLotFreeState.LDBPAJKIPKD_IsNextFree && KHEGONOKLPN_NormalLotFreeSetting.EDHFIFDAJPA_IsFirstTime && KHEGONOKLPN_NormalLotFreeSetting.CDHKHOLCGAC_DurationDays < 0)
				return KNEKLJHNHAK.PBEMIDKNPNH_2;
			if(JENBPPBNAHP_PlayerNormalLotFreeState.LDBPAJKIPKD_IsNextFree && KHEGONOKLPN_NormalLotFreeSetting.CDHKHOLCGAC_DurationDays > 0)
				return KNEKLJHNHAK.LCLLMJGIMHC_1;
		}
		if(KHEGONOKLPN_NormalLotFreeSetting.ACGICAHHCIG_ResetCount < 1)
			return KNEKLJHNHAK.HJNNKCMLGFL_0_None;
		else
		{
			if(JENBPPBNAHP_PlayerNormalLotFreeState == null)
				return KNEKLJHNHAK.AAPLMEGMNJA_4;
			if(JENBPPBNAHP_PlayerNormalLotFreeState.LJPIOGBFEKA_RemainsCount > 0)
				return KNEKLJHNHAK.DKIKNLEDDBK_3;
			return KNEKLJHNHAK.AAPLMEGMNJA_4;
		}
	}
}
