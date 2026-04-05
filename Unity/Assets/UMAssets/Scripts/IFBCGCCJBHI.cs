using System.Text;
using XeApp.Game.Common;

public class IFBCGCCJBHI
{
	private MCGNOFMAPBJ BPLOEAHOPFI_stamina; // 0x8
	private JKNNIKNKMNJ IOCLFHJLHLE_IntimacyUpdater; // 0xC
	private StringBuilder KOHNLDKIKPC_sb = new StringBuilder(80); // 0x10
	private EGOLBAPFHHD_Common KCCLEHLLOFG_Common; // 0x14
	private long KLDBCKIJACO_StaminaTimeLeft = -1; // 0x18
	private long NFKMOHGLPAO_IntamacyTimeLeft = -1; // 0x20
	public int EGJCFJLAKMO_TotalUtaRate = -1; // 0x34

	public int EPNALMONMHB_CurrentStamina { get { return BPLOEAHOPFI_stamina.DCLKMNGMIKC_GetCurrentValue(); } } //0x11ED670 NCLHIDDMLCO_bgs
	public int POKDILOKODG_MaxEnergy { get { return BPLOEAHOPFI_stamina.DCBENCMNOGO_MaxCount; } } //0x11ED6A4 EDFHEIAMNLE_bgs
	public int CMCHABFEOHH_RemainTime { get { return (int)KLDBCKIJACO_StaminaTimeLeft; } } //0x11ED6D0 NFIBFCPHEPN_bgs
	public string FPLEADMHLKN_StaminaStr { get; private set; } // 0x28 LAOBMPGBJBI_bgs KFJLNKOMGJB_bgs ENMDNIKAKEI_bgs
	// public int MMFBIBDIAFB { get; } 0x11ED6E8 ADHCNLCKOFG_bgs
	// public int BMDLIIHCONC { get; } 0x11ED718 GDCCGGPFNIC_bgs
	// public int IBKIJLOAGOP { get; } 0x11ED744 ONGGKCJNDDJ_bgs
	public string KOENBEGADHP_IntimacyStr { get; private set; } // 0x2C GDKGMEDOGJL_bgs FJOICJOJJEB_bgs JJNFELKEKHO_bgs
	public int FNCPAEFEECO_CurrencyPaid { get { return CIOECGOMILE_NetPlayerDataManager.HHCJCDFCLOB_Instance.DEAPMEIDCGC_GetTotalPaidCurrency(); } } //0x11ED75C OEELJMCDCDC_bgs
	public int OIOFGIBDOPI_CurrencyNonPaid { get { return KCCLEHLLOFG_Common != null ? KCCLEHLLOFG_Common.NFHLDFJIBKI_have_uc : 0; } } //0x11ED7F8 IHIBMMDPBEC_bgs
	public int OPBHNBECFII_CurExp { get { return KCCLEHLLOFG_Common != null ? KCCLEHLLOFG_Common.EOHDMCMHBKJ_Exp : 0; } } //0x11ED810 CFGDKOPPMAE_bgs
	public int PBGFIOONCMB_LevelMaxExp { get { return (IMMAOANGPNK_NetMasterDataManager.HHCJCDFCLOB_Instance.NKEBMCIMJND_Database.FMPEMFPLPDA_Exp != null && KCCLEHLLOFG_Common != null && !NMCICIHMOCM_PlayerLevelLimit) ? IMMAOANGPNK_NetMasterDataManager.HHCJCDFCLOB_Instance.NKEBMCIMJND_Database.FMPEMFPLPDA_Exp.NDFGMMKGBAA_GetExpForPlayerLevel(KCCLEHLLOFG_Common == null ? 1 : KCCLEHLLOFG_Common.KIECDDFNCAN_Level) : 0; } } //0x11ED828 EHJKNBNPNKN_bgs
	public int DMBFOMLCGBG_Level { get { return KCCLEHLLOFG_Common != null ? KCCLEHLLOFG_Common.KIECDDFNCAN_Level : 0; } } //0x11EDAE8 FEMNAJGJKJH_bgs
	public bool NMCICIHMOCM_PlayerLevelLimit { get
		{
			if (IMMAOANGPNK_NetMasterDataManager.HHCJCDFCLOB_Instance.NKEBMCIMJND_Database.FMPEMFPLPDA_Exp == null || KCCLEHLLOFG_Common == null)
				return false;
			return KCCLEHLLOFG_Common.KIECDDFNCAN_Level == IMMAOANGPNK_NetMasterDataManager.HHCJCDFCLOB_Instance.NKEBMCIMJND_Database.GDEKCOOBLMA_System.NGHKJOEDLIP_Settings.PIAMMJNADJH_PlayerMaxLevel;
		}
	} //0x11ED940 FDKFKNCGHIO_bgs
	public int GBIKGLELKEO_MedalValue { get
		{
			long time = NKGJPJPHLIF_SakashoManager.HHCJCDFCLOB_Instance.IBLPICFDGOF_ServerRequester.FJDBNGEPKHL_Time.KMEFBNBFJHI_GetServerTime();
			int id = EKLNMHFCAOI_ItemManager.DEACAHNLMNI_getItemId(IMMAOANGPNK_NetMasterDataManager.HHCJCDFCLOB_Instance.NKEBMCIMJND_Database.ICICKEBMEFA_Medal.DNEKJCKEOHL_GetMonthlyItemFullId(time));
			return CIOECGOMILE_NetPlayerDataManager.HHCJCDFCLOB_Instance.AHEFHIMGIBI_PlayerData.KCCLEHLLOFG_Common.MHKJEBNOPIM_Medal[id - 1].BFINGCJHOHI_cnt;
		}
	}  //0x11EDB00 IFLPJENEMIN_bgs
	public int AHHGKGOPGDE_MedalMonth { get {
			long time = NKGJPJPHLIF_SakashoManager.HHCJCDFCLOB_Instance.IBLPICFDGOF_ServerRequester.FJDBNGEPKHL_Time.KMEFBNBFJHI_GetServerTime();
			int id = EKLNMHFCAOI_ItemManager.DEACAHNLMNI_getItemId(IMMAOANGPNK_NetMasterDataManager.HHCJCDFCLOB_Instance.NKEBMCIMJND_Database.ICICKEBMEFA_Medal.DNEKJCKEOHL_GetMonthlyItemFullId(time));
			return IMMAOANGPNK_NetMasterDataManager.HHCJCDFCLOB_Instance.NKEBMCIMJND_Database.ICICKEBMEFA_Medal.CDENCMNHNGA_table[id - 1].IBAKPKKEDJM_month;
		} } //0x11EDE9C CDDLHFNCGLH_bgs
	// public int HMGGGAFFKAE { get; } 0x11EE110 HFKFEFGLEJF_bgs
	// public int BOABFDIJBLF { get; } 0x11EE394 KGLOKLFLJIJ_bgs
	public int AAODIMMEFBI_SaveTotalUtaRate { get; private set; } // 0x30 GPADNICDEGE_bgs IHMBMOACINF_bgs OJLEJOKHKFP_bgs
	public int JHKAEJBNGKE_RateLeftToNext { get; private set; } // 0x38 IJMECHNGGLC_bgs IIDDKFAKIDO_bgs KHMAEPICIAN_bgs
	public HighScoreRatingRank.Type ILELGGCCGMJ_UtaGrade { get; private set; } // 0x3C NNBOAJNHMOA_bgs LADENPJCBJM_bgs JNAAPMEFGMG_bgs
	public int HDBFOIAGPJK_UtaRank { get; private set; } // 0x40 COBAJIOMLPK_bgs GPMNNNFLBIH_bgs KEAAJBCNGDM_bgs
	public int DOMEGAEKENF_ItemId { get; private set; } // 0x44 OKGKAFNFIAP_bgs KFDJNOODCHM_bgs LGAHJNJDOHD_bgs

	// // RVA: 0x11EE64C Offset: 0x11EE64C VA: 0x11EE64C
	public void KHEKNNFCAOI_Init()
	{
		BPLOEAHOPFI_stamina = CIOECGOMILE_NetPlayerDataManager.HHCJCDFCLOB_Instance.BPLOEAHOPFI_stamina;
		IOCLFHJLHLE_IntimacyUpdater = CIOECGOMILE_NetPlayerDataManager.HHCJCDFCLOB_Instance.IOCLFHJLHLE_IntimacyUpdater;
		KCCLEHLLOFG_Common = CIOECGOMILE_NetPlayerDataManager.HHCJCDFCLOB_Instance.AHEFHIMGIBI_PlayerData.KCCLEHLLOFG_Common;
		AAODIMMEFBI_SaveTotalUtaRate = 0;
		JHKAEJBNGKE_RateLeftToNext = 0;
		HDBFOIAGPJK_UtaRank = 0;
		DOMEGAEKENF_ItemId = 0;
		FBANBDCOEJL_Update();
	}

	// // RVA: 0x11EE784 Offset: 0x11EE784 VA: 0x11EE784
	public void FBANBDCOEJL_Update()
    {
        if(KCCLEHLLOFG_Common == null)
        {
            if(CIOECGOMILE_NetPlayerDataManager.HHCJCDFCLOB_Instance.AHEFHIMGIBI_PlayerData.KCCLEHLLOFG_Common != null)
            {
                KCCLEHLLOFG_Common = CIOECGOMILE_NetPlayerDataManager.HHCJCDFCLOB_Instance.AHEFHIMGIBI_PlayerData.KCCLEHLLOFG_Common;
            }
        }
        IGHDEGMBPKI_UpdateStaminaInfo();
        FOCDOMKICKL_UpdateIntimacyInfo();
        OCEAALKNGDK();
    }

	// // RVA: 0x11EE8E8 Offset: 0x11EE8E8 VA: 0x11EE8E8
	private void IGHDEGMBPKI_UpdateStaminaInfo()
    {
		long t = BPLOEAHOPFI_stamina.MLLGPBGFLFI_GetRemainingTime();

		if (t != KLDBCKIJACO_StaminaTimeLeft || FPLEADMHLKN_StaminaStr == null)
        {
			FPLEADMHLKN_StaminaStr = JpStringLiterals.StringLiteral_11085;
			if (t != 0)
			{
				KOHNLDKIKPC_sb.Clear();
				KOHNLDKIKPC_sb.Append(JpStringLiterals.StringLiteral_11083);
				KOHNLDKIKPC_sb.AppendFormat("{0}", t / 60);
				KOHNLDKIKPC_sb.Append(':');
				KOHNLDKIKPC_sb.AppendFormat("{0:d2}", t % 60);
				FPLEADMHLKN_StaminaStr = KOHNLDKIKPC_sb.ToString();
			}
			KLDBCKIJACO_StaminaTimeLeft = t;
		}
    }

	// // RVA: 0x11EEB30 Offset: 0x11EEB30 VA: 0x11EEB30
	private void FOCDOMKICKL_UpdateIntimacyInfo()
    {
		long t = IOCLFHJLHLE_IntimacyUpdater.CKEJFCLAOHP_GetRemainingTime();
		if(t != NFKMOHGLPAO_IntamacyTimeLeft || KOENBEGADHP_IntimacyStr == null)
		{
			KOENBEGADHP_IntimacyStr = JpStringLiterals.StringLiteral_11085;
			if(t != 0)
			{
				KOHNLDKIKPC_sb.Clear();
				KOHNLDKIKPC_sb.Append(JpStringLiterals.StringLiteral_11083);
				KOHNLDKIKPC_sb.AppendFormat("{0}", t / 60);
				KOHNLDKIKPC_sb.Append(':');
				KOHNLDKIKPC_sb.AppendFormat("{0:d2}", t % 60);
				KOENBEGADHP_IntimacyStr = KOHNLDKIKPC_sb.ToString();
			}
			NFKMOHGLPAO_IntamacyTimeLeft = t;
		}
	}

	// // RVA: 0x11EED70 Offset: 0x11EED70 VA: 0x11EED70
	private void OCEAALKNGDK()
    {
        if(KCCLEHLLOFG_Common != null)
		{
			AAODIMMEFBI_SaveTotalUtaRate = KCCLEHLLOFG_Common.EAHPKPADCPL_total_uta_rate;
		}
		if(IMMAOANGPNK_NetMasterDataManager.HHCJCDFCLOB_Instance.NKEBMCIMJND_Database.DCNNPEDOGOG_HighScoreRanking != null
			&& AAODIMMEFBI_SaveTotalUtaRate != EGJCFJLAKMO_TotalUtaRate)
		{
			EGJCFJLAKMO_TotalUtaRate = AAODIMMEFBI_SaveTotalUtaRate;
			ILELGGCCGMJ_UtaGrade = HighScoreRating.GetUtaGrade(AAODIMMEFBI_SaveTotalUtaRate);
			JHKAEJBNGKE_RateLeftToNext = HighScoreRating.GetNextUtaGradeNum(AAODIMMEFBI_SaveTotalUtaRate);
			DOMEGAEKENF_ItemId = IMMAOANGPNK_NetMasterDataManager.HHCJCDFCLOB_Instance.NKEBMCIMJND_Database.DCNNPEDOGOG_HighScoreRanking.FAJFAEOCHGK_GetItemId((int)ILELGGCCGMJ_UtaGrade);
		}
		if(OEGIPPCADNA_NetEventUtarateManager.HHCJCDFCLOB_Instance != null)
		{
			HDBFOIAGPJK_UtaRank = OEGIPPCADNA_NetEventUtarateManager.HHCJCDFCLOB_Instance.CDINKAANIAA_Rank;
		}
	}
}
