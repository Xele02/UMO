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

	public int EPNALMONMHB_CurrentStamina { get { return BPLOEAHOPFI_stamina.DCLKMNGMIKC_GetCurrentValue(); } } //0x11ED670 NCLHIDDMLCO
	public int POKDILOKODG_MaxEnergy { get { return BPLOEAHOPFI_stamina.DCBENCMNOGO_MaxStamina; } } //0x11ED6A4 EDFHEIAMNLE
	public int CMCHABFEOHH_RemainTime { get { return (int)KLDBCKIJACO_StaminaTimeLeft; } } //0x11ED6D0 NFIBFCPHEPN
	public string FPLEADMHLKN_StaminaStr { get; private set; } // 0x28 LAOBMPGBJBI KFJLNKOMGJB ENMDNIKAKEI
	// public int MMFBIBDIAFB { get; } 0x11ED6E8 ADHCNLCKOFG
	// public int BMDLIIHCONC { get; } 0x11ED718 GDCCGGPFNIC
	// public int IBKIJLOAGOP { get; } 0x11ED744 ONGGKCJNDDJ
	public string KOENBEGADHP_IntimacyStr { get; private set; } // 0x2C GDKGMEDOGJL FJOICJOJJEB JJNFELKEKHO
	public int FNCPAEFEECO_CurrencyPaid { get { return CIOECGOMILE.HHCJCDFCLOB.DEAPMEIDCGC_GetTotalPaidCurrency(); } } //0x11ED75C OEELJMCDCDC
	public int OIOFGIBDOPI_CurrencyNonPaid { get { return KCCLEHLLOFG_Common != null ? KCCLEHLLOFG_Common.NFHLDFJIBKI_have_uc : 0; } } //0x11ED7F8 IHIBMMDPBEC
	public int OPBHNBECFII_CurExp { get { return KCCLEHLLOFG_Common != null ? KCCLEHLLOFG_Common.EOHDMCMHBKJ_Exp : 0; } } //0x11ED810 CFGDKOPPMAE
	public int PBGFIOONCMB_LevelMaxExp { get { return (IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.FMPEMFPLPDA_Exp != null && KCCLEHLLOFG_Common != null && !NMCICIHMOCM_PlayerLevelLimit) ? IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.FMPEMFPLPDA_Exp.NDFGMMKGBAA_GetExpForPlayerLevel(KCCLEHLLOFG_Common == null ? 1 : KCCLEHLLOFG_Common.KIECDDFNCAN_Level) : 0; } } //0x11ED828 EHJKNBNPNKN
	public int DMBFOMLCGBG_ChangeLevelValue { get { return KCCLEHLLOFG_Common != null ? KCCLEHLLOFG_Common.KIECDDFNCAN_Level : 0; } } //0x11EDAE8 FEMNAJGJKJH
	public bool NMCICIHMOCM_PlayerLevelLimit { get
		{
			if (IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.FMPEMFPLPDA_Exp == null || KCCLEHLLOFG_Common == null)
				return false;
			return KCCLEHLLOFG_Common.KIECDDFNCAN_Level == IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.GDEKCOOBLMA_System.NGHKJOEDLIP_Settings.PIAMMJNADJH_PlayerMaxLevel;
		}
	} //0x11ED940 FDKFKNCGHIO
	public int GBIKGLELKEO_MedalValue { get
		{
			long time = NKGJPJPHLIF.HHCJCDFCLOB.IBLPICFDGOF_ServerRequester.FJDBNGEPKHL_Time.KMEFBNBFJHI_GetServerTime();
			int id = EKLNMHFCAOI.DEACAHNLMNI_getItemId(IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.ICICKEBMEFA_Medal.DNEKJCKEOHL_GetMonthlyItemFullId(time));
			return CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_PlayerData.KCCLEHLLOFG_Common.MHKJEBNOPIM_Medal[id - 1].BFINGCJHOHI_cnt;
		}
	}  //0x11EDB00 IFLPJENEMIN
	public int AHHGKGOPGDE_MedalMonth { get {
			long time = NKGJPJPHLIF.HHCJCDFCLOB.IBLPICFDGOF_ServerRequester.FJDBNGEPKHL_Time.KMEFBNBFJHI_GetServerTime();
			int id = EKLNMHFCAOI.DEACAHNLMNI_getItemId(IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.ICICKEBMEFA_Medal.DNEKJCKEOHL_GetMonthlyItemFullId(time));
			return IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.ICICKEBMEFA_Medal.CDENCMNHNGA_table[id - 1].IBAKPKKEDJM_month;
		} } //0x11EDE9C CDDLHFNCGLH
	// public int HMGGGAFFKAE { get; } 0x11EE110 HFKFEFGLEJF
	// public int BOABFDIJBLF { get; } 0x11EE394 KGLOKLFLJIJ
	public int AAODIMMEFBI_SaveTotalUtaRate { get; private set; } // 0x30 GPADNICDEGE IHMBMOACINF OJLEJOKHKFP
	public int JHKAEJBNGKE_RateLeftToNext { get; private set; } // 0x38 IJMECHNGGLC IIDDKFAKIDO KHMAEPICIAN
	public HighScoreRatingRank.Type ILELGGCCGMJ_UtaGrade { get; private set; } // 0x3C NNBOAJNHMOA LADENPJCBJM JNAAPMEFGMG
	public int HDBFOIAGPJK_UtaRank { get; private set; } // 0x40 COBAJIOMLPK GPMNNNFLBIH KEAAJBCNGDM
	public int DOMEGAEKENF_ItemId { get; private set; } // 0x44 OKGKAFNFIAP KFDJNOODCHM LGAHJNJDOHD

	// // RVA: 0x11EE64C Offset: 0x11EE64C VA: 0x11EE64C
	public void KHEKNNFCAOI_Init()
	{
		BPLOEAHOPFI_stamina = CIOECGOMILE.HHCJCDFCLOB.BPLOEAHOPFI_stamina;
		IOCLFHJLHLE_IntimacyUpdater = CIOECGOMILE.HHCJCDFCLOB.IOCLFHJLHLE_IntimacyUpdater;
		KCCLEHLLOFG_Common = CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_PlayerData.KCCLEHLLOFG_Common;
		AAODIMMEFBI_SaveTotalUtaRate = 0;
		JHKAEJBNGKE_RateLeftToNext = 0;
		HDBFOIAGPJK_UtaRank = 0;
		DOMEGAEKENF_ItemId = 0;
		FBANBDCOEJL();
	}

	// // RVA: 0x11EE784 Offset: 0x11EE784 VA: 0x11EE784
	public void FBANBDCOEJL()
    {
        if(KCCLEHLLOFG_Common == null)
        {
            if(CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_PlayerData.KCCLEHLLOFG_Common != null)
            {
                KCCLEHLLOFG_Common = CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_PlayerData.KCCLEHLLOFG_Common;
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
		if(IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.DCNNPEDOGOG_HighScoreRanking != null
			&& AAODIMMEFBI_SaveTotalUtaRate != EGJCFJLAKMO_TotalUtaRate)
		{
			EGJCFJLAKMO_TotalUtaRate = AAODIMMEFBI_SaveTotalUtaRate;
			ILELGGCCGMJ_UtaGrade = HighScoreRating.GetUtaGrade(AAODIMMEFBI_SaveTotalUtaRate);
			JHKAEJBNGKE_RateLeftToNext = HighScoreRating.GetNextUtaGradeNum(AAODIMMEFBI_SaveTotalUtaRate);
			DOMEGAEKENF_ItemId = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.DCNNPEDOGOG_HighScoreRanking.FAJFAEOCHGK_GetItemId((int)ILELGGCCGMJ_UtaGrade);
		}
		if(OEGIPPCADNA.HHCJCDFCLOB != null)
		{
			HDBFOIAGPJK_UtaRank = OEGIPPCADNA.HHCJCDFCLOB.CDINKAANIAA_Rank;
		}
	}
}
