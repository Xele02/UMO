using System.Text.RegularExpressions;

public class LGDNAJACFHI
{
	private static Regex INIKEOCPAJH = new Regex("num(?<num>[\\d]+)"); // 0x0
	public int PPFNGGCBJKC_Id; // 0x8
	public int LHENLPLKGLP_StuffId; // 0xC
	public string OPFGFINHFCE_Name; // 0x10
	public string KLMPFGOCBHC; // 0x14
	public long EBEOPONDEKB_OpenedAt; // 0x18
	public long EMEKFFHCHMH_CloseAt; // 0x20
	public string PGODOPKCHBD_PlatformProductId; // 0x28
	public string EFIMCLPAEEN_ImgeUrl; // 0x2C
	public int NPPGKNGIFGK_Price; // 0x30
	public int GCJMGMBNBCB_BuyLimit; // 0x34
	public int AJIFADGGAAJ_BoughtQuantity; // 0x38
	public string GBOGEOPOCFJ; // 0x3C
	public bool JLGHMCBLENL; // 0x40
	public bool NIIIKPNBLNP; // 0x41
	public bool IPKEFHPAMBP; // 0x42
	public bool PBELOKPKJKN; // 0x43
	public int EAHPLCJMPHD; // 0x44
	public int FDGKHGFMCJJ; // 0x48
	public int KAPMOPMDHJE_Label; // 0x4C
	public string NGIKLCDKAMB_FormatedPrice; // 0x50
	public string JKKNIEHJBAP; // 0x54
	public int[] BIOHCFLJDCH_BonusItemId; // 0x58
	public int[] HBHLKLGBKIJ; // 0x5C
	public int EEFLOOBOAGF; // 0x60
	public bool CHPMJNAFPMA; // 0x64
	public bool NLHLBKDNGFJ; // 0x65
	public int OJIMENABACH_PriceAmountMicros; // 0x68
	public string JMEMGIPGGIK; // 0x6C
	public static string[] GJHJBLCPPKE = new string[10] {
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
	public bool KHEKNNFCAOI_Init(KBPDNHOKEKD_ProductId MEANCEOIMGE)
	{
		PPFNGGCBJKC_Id = MEANCEOIMGE.PPFNGGCBJKC_Id;
		OPFGFINHFCE_Name = MEANCEOIMGE.OPFGFINHFCE_Name;
		EBEOPONDEKB_OpenedAt = MEANCEOIMGE.KBFOIECIADN_OpenedAt;
		EMEKFFHCHMH_CloseAt = MEANCEOIMGE.EGBOHDFBAPB_ClosedAt;
		PGODOPKCHBD_PlatformProductId = MEANCEOIMGE.GLHKICCPGKJ_PlatformProductId;
		EFIMCLPAEEN_ImgeUrl = MEANCEOIMGE.EFIMCLPAEEN_ImageUrl;
		NPPGKNGIFGK_Price = MEANCEOIMGE.NPPGKNGIFGK_Price;
		GCJMGMBNBCB_BuyLimit = MEANCEOIMGE.HMFDJHEEGNN_BuyLimit;
		AJIFADGGAAJ_BoughtQuantity = MEANCEOIMGE.GIEBJDKLCDH_BoughtQuantity;
		JLGHMCBLENL = false;
		NIIIKPNBLNP = true;
		KAPMOPMDHJE_Label = MEANCEOIMGE.KAPMOPMDHJE_Label;
		NGIKLCDKAMB_FormatedPrice = MEANCEOIMGE.NGIKLCDKAMB_FormatedPrice;
		OJIMENABACH_PriceAmountMicros = MEANCEOIMGE.OJIMENABACH_PriceAmountMicros;
		JMEMGIPGGIK = MEANCEOIMGE.JMEMGIPGGIK_CurrencyCode;
        DKJMDIFAKKD_VcItem.EBGPAPPHBAH vcItem = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.KCCDBKIOLDJ_VcItem.ICGHMMOCJBA(PGODOPKCHBD_PlatformProductId, OPFGFINHFCE_Name, NKGJPJPHLIF.HHCJCDFCLOB.IBLPICFDGOF_ServerRequester.FJDBNGEPKHL.KMEFBNBFJHI_GetServerTime(), KAPMOPMDHJE_Label);
        LHENLPLKGLP_StuffId = vcItem.PPFNGGCBJKC;
		EAHPLCJMPHD = vcItem.HEOLEHDFLJO;
		JLGHMCBLENL = vcItem.HPGNBPIBAOM;
		NIIIKPNBLNP = vcItem.AFHPLBPHEGA;
		KLMPFGOCBHC = vcItem.KLMPFGOCBHC;
		BIOHCFLJDCH_BonusItemId = vcItem.KGOFMDMDFCJ;
		HBHLKLGBKIJ = vcItem.NNIIINKFDBG;
		EEFLOOBOAGF = vcItem.EILKGEADKGH;
		if(JLGHMCBLENL || NIIIKPNBLNP)
			IPKEFHPAMBP = true;
		CHPMJNAFPMA = false;
		for(int i = 0; i < BIOHCFLJDCH_BonusItemId.Length; i++)
		{
			if(IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.NBKNAAPBFFL_BonusVc.IIEKKOHBNLA(BIOHCFLJDCH_BonusItemId[i]))
			{
				CHPMJNAFPMA = true;
				break;
			}
		}
		FDGKHGFMCJJ = vcItem.HMFFHLPNMPH;
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
			res.AFKAGFOFAHM_ProductId = PPFNGGCBJKC_Id;
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
