using System.Text.RegularExpressions;

public class LGDNAJACFHI
{
	private static Regex INIKEOCPAJH = new Regex("num(?<num>[\\d]+)"); // 0x0
	public int PPFNGGCBJKC_id; // 0x8
	public int LHENLPLKGLP_StuffId; // 0xC
	public string OPFGFINHFCE_name; // 0x10
	public string KLMPFGOCBHC_description; // 0x14
	public long EBEOPONDEKB_OpenedAt; // 0x18
	public long EMEKFFHCHMH_RewardEnd2; // 0x20
	public string PGODOPKCHBD_PlatformProductId; // 0x28
	public string EFIMCLPAEEN_ImageUrl; // 0x2C
	public int NPPGKNGIFGK_price; // 0x30
	public int GCJMGMBNBCB_BuyLimit; // 0x34
	public int AJIFADGGAAJ_BoughtQuantity; // 0x38
	public string GBOGEOPOCFJ; // 0x3C
	public bool JLGHMCBLENL_IsBeginner; // 0x40
	public bool NIIIKPNBLNP; // 0x41
	public bool IPKEFHPAMBP; // 0x42
	public bool PBELOKPKJKN; // 0x43
	public int EAHPLCJMPHD_PId; // 0x44
	public int FDGKHGFMCJJ; // 0x48
	public int KAPMOPMDHJE_label; // 0x4C
	public string NGIKLCDKAMB_FormatedPrice; // 0x50
	public string JKKNIEHJBAP; // 0x54
	public int[] BIOHCFLJDCH_BonusItemId; // 0x58
	public int[] HBHLKLGBKIJ_BonusCount; // 0x5C
	public int EEFLOOBOAGF_ViewOrder; // 0x60
	public bool CHPMJNAFPMA_HasMonthlyPassBonus; // 0x64
	public bool NLHLBKDNGFJ; // 0x65
	public int OJIMENABACH_price_amount_micros; // 0x68
	public string JMEMGIPGGIK_currency_code; // 0x6C
	public static string[] GJHJBLCPPKE_Names = new string[10] {
		JpStringLiterals.StringLiteral_12326,
		JpStringLiterals.StringLiteral_12327,
		JpStringLiterals.StringLiteral_12328,
		JpStringLiterals.StringLiteral_12329,
		JpStringLiterals.StringLiteral_12330,
		JpStringLiterals.StringLiteral_12331,
		JpStringLiterals.StringLiteral_12332,
		JpStringLiterals.StringLiteral_12333,
		JpStringLiterals.StringLiteral_12334,
		JpStringLiterals.StringLiteral_12335
	}; // 0x4
	public static int[] MKJBOPJEAHN = new int[10] {1, 2, 2, 3, 3, 3, 3, 3, 3, 3}; // 0x8

	// // RVA: 0xD725A8 Offset: 0xD725A8 VA: 0xD725A8
	public bool KHEKNNFCAOI_Init(KBPDNHOKEKD_ProductId _MEANCEOIMGE_Summon)
	{
		PPFNGGCBJKC_id = _MEANCEOIMGE_Summon.PPFNGGCBJKC_id;
		OPFGFINHFCE_name = _MEANCEOIMGE_Summon.OPFGFINHFCE_name;
		EBEOPONDEKB_OpenedAt = _MEANCEOIMGE_Summon.KBFOIECIADN_opened_at;
		EMEKFFHCHMH_RewardEnd2 = _MEANCEOIMGE_Summon.EGBOHDFBAPB_ClosedAt;
		PGODOPKCHBD_PlatformProductId = _MEANCEOIMGE_Summon.GLHKICCPGKJ_PlatformProductId;
		EFIMCLPAEEN_ImageUrl = _MEANCEOIMGE_Summon.EFIMCLPAEEN_ImageUrl;
		NPPGKNGIFGK_price = _MEANCEOIMGE_Summon.NPPGKNGIFGK_price;
		GCJMGMBNBCB_BuyLimit = _MEANCEOIMGE_Summon.HMFDJHEEGNN_BuyLimit;
		AJIFADGGAAJ_BoughtQuantity = _MEANCEOIMGE_Summon.GIEBJDKLCDH_BoughtQuantity;
		JLGHMCBLENL_IsBeginner = false;
		NIIIKPNBLNP = true;
		KAPMOPMDHJE_label = _MEANCEOIMGE_Summon.KAPMOPMDHJE_label;
		NGIKLCDKAMB_FormatedPrice = _MEANCEOIMGE_Summon.NGIKLCDKAMB_FormatedPrice;
		OJIMENABACH_price_amount_micros = _MEANCEOIMGE_Summon.OJIMENABACH_price_amount_micros;
		JMEMGIPGGIK_currency_code = _MEANCEOIMGE_Summon.JMEMGIPGGIK_currency_code;
        DKJMDIFAKKD_VcItem.EBGPAPPHBAH vcItem = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.KCCDBKIOLDJ_VcItem.ICGHMMOCJBA(PGODOPKCHBD_PlatformProductId, OPFGFINHFCE_name, NKGJPJPHLIF.HHCJCDFCLOB.IBLPICFDGOF_ServerRequester.FJDBNGEPKHL_Time.KMEFBNBFJHI_GetServerTime(), KAPMOPMDHJE_label);
        LHENLPLKGLP_StuffId = vcItem.PPFNGGCBJKC_id;
		EAHPLCJMPHD_PId = vcItem.HEOLEHDFLJO_Icon;
		JLGHMCBLENL_IsBeginner = vcItem.HPGNBPIBAOM_IsBeginner;
		NIIIKPNBLNP = vcItem.AFHPLBPHEGA;
		KLMPFGOCBHC_description = vcItem.KLMPFGOCBHC_description;
		BIOHCFLJDCH_BonusItemId = vcItem.KGOFMDMDFCJ_BonusId;
		HBHLKLGBKIJ_BonusCount = vcItem.NNIIINKFDBG_BonusCount;
		EEFLOOBOAGF_ViewOrder = vcItem.EILKGEADKGH_Order;
		if(JLGHMCBLENL_IsBeginner || NIIIKPNBLNP)
			IPKEFHPAMBP = true;
		CHPMJNAFPMA_HasMonthlyPassBonus = false;
		for(int i = 0; i < BIOHCFLJDCH_BonusItemId.Length; i++)
		{
			if(IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.NBKNAAPBFFL_BonusVc.IIEKKOHBNLA_HasMonthlyPassBonus(BIOHCFLJDCH_BonusItemId[i]))
			{
				CHPMJNAFPMA_HasMonthlyPassBonus = true;
				break;
			}
		}
		FDGKHGFMCJJ = vcItem.HMFFHLPNMPH_Count;
		if(FDGKHGFMCJJ == 0)
		{
			FDGKHGFMCJJ = ACGBOGBBFFL();
		}
		JKKNIEHJBAP = vcItem.IHCLFMKAJND == 0 ? null : "paidvc_" + vcItem.IHCLFMKAJND.ToString("D4");
		return true;
	}

	// // RVA: 0xD72E08 Offset: 0xD72E08 VA: 0xD72E08
	// public void GNIKLANHDHD() { }

	// // RVA: 0xD73260 Offset: 0xD73260 VA: 0xD73260
	public CBMFOOHOAOE_Purchase DMFHKJBCFBK()
	{
		if(!PBELOKPKJKN)
		{
			CBMFOOHOAOE_Purchase res = NKGJPJPHLIF.HHCJCDFCLOB.IBLPICFDGOF_ServerRequester.IFFNCAFNEAG_AddRequest(new CBMFOOHOAOE_Purchase());
			res.ICDEFIIADDO_Timeout = 8640000;
			res.AFKAGFOFAHM_ProductId = PPFNGGCBJKC_id;
			res.BPNPBJALGHM_Quantity = 1;
			return res;
		}
		return null;
	}

	// // RVA: 0xD733C4 Offset: 0xD733C4 VA: 0xD733C4
	public void NLEKIOBIIIK()
	{
		if(GCJMGMBNBCB_BuyLimit > 0)
		{
			if(AJIFADGGAAJ_BoughtQuantity < GCJMGMBNBCB_BuyLimit)
				AJIFADGGAAJ_BoughtQuantity++;
		}
	}

	// // RVA: 0xD72BB4 Offset: 0xD72BB4 VA: 0xD72BB4
	private int ACGBOGBBFFL()
	{
        Match res = INIKEOCPAJH.Match(PGODOPKCHBD_PlatformProductId);
        if (res.Success)
		{
			if(res.Groups.Count > 0)
			{
				if(res.Groups["num"].Value != "")
				{
					int num;
					if(int.TryParse(res.Groups["num"].Value, out num))
						return num;
				}
			}
		}
		return 0;
	}
}
