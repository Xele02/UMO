using System.Text;
using XeApp.Game.Common;

public class IFBCGCCJBHI
{
	private MCGNOFMAPBJ BPLOEAHOPFI_StaminaUpdater; // 0x8
	private JKNNIKNKMNJ IOCLFHJLHLE_IntimacyUpdater; // 0xC
	private StringBuilder KOHNLDKIKPC = new StringBuilder(80); // 0x10
	private EGOLBAPFHHD_Common KCCLEHLLOFG_SaveCommon; // 0x14
	private long KLDBCKIJACO_StaminaTimeLeft = -1; // 0x18
	private long NFKMOHGLPAO_IntamacyTimeLeft = -1; // 0x20
	public int EGJCFJLAKMO_TotalUtaRate = -1; // 0x34

	// public int EPNALMONMHB { get; } 0x11ED670 NCLHIDDMLCO
	// public int POKDILOKODG { get; } 0x11ED6A4 EDFHEIAMNLE
	// public int CMCHABFEOHH { get; } 0x11ED6D0 NFIBFCPHEPN
	public string FPLEADMHLKN_StaminaStr { get; private set; } // 0x28 LAOBMPGBJBI KFJLNKOMGJB ENMDNIKAKEI
	// public int MMFBIBDIAFB { get; } 0x11ED6E8 ADHCNLCKOFG
	// public int BMDLIIHCONC { get; } 0x11ED718 GDCCGGPFNIC
	// public int IBKIJLOAGOP { get; } 0x11ED744 ONGGKCJNDDJ
	public string KOENBEGADHP_IntimacyStr { get; private set; } // 0x2C GDKGMEDOGJL FJOICJOJJEB JJNFELKEKHO
	// public int FNCPAEFEECO { get; } 0x11ED75C OEELJMCDCDC
	// public int OIOFGIBDOPI { get; } 0x11ED7F8 IHIBMMDPBEC
	// public int OPBHNBECFII { get; } 0x11ED810 CFGDKOPPMAE
	// public int PBGFIOONCMB { get; } 0x11ED828 EHJKNBNPNKN
	// public int DMBFOMLCGBG { get; } 0x11EDAE8 FEMNAJGJKJH
	// public bool NMCICIHMOCM { get; } 0x11ED940 FDKFKNCGHIO
	// public int GBIKGLELKEO { get; }  0x11EDB00 IFLPJENEMIN
	// public int AHHGKGOPGDE { get; } 0x11EDE9C CDDLHFNCGLH
	// public int HMGGGAFFKAE { get; } 0x11EE110 HFKFEFGLEJF
	// public int BOABFDIJBLF { get; } 0x11EE394 KGLOKLFLJIJ
	public int AAODIMMEFBI_SaveTotalUtaRate { get; private set; } // 0x30 GPADNICDEGE IHMBMOACINF OJLEJOKHKFP
	public int JHKAEJBNGKE_RateLeftToNext { get; private set; } // 0x38 IJMECHNGGLC IIDDKFAKIDO KHMAEPICIAN
	public HighScoreRatingRank.Type ILELGGCCGMJ_UtaGrade { get; private set; } // 0x3C NNBOAJNHMOA LADENPJCBJM JNAAPMEFGMG
	public int HDBFOIAGPJK { get; private set; } // 0x40 COBAJIOMLPK GPMNNNFLBIH KEAAJBCNGDM
	public int DOMEGAEKENF_ItemId { get; private set; } // 0x44 OKGKAFNFIAP KFDJNOODCHM LGAHJNJDOHD

	// // RVA: 0x11EE64C Offset: 0x11EE64C VA: 0x11EE64C
	public void KHEKNNFCAOI()
	{
		BPLOEAHOPFI_StaminaUpdater = CIOECGOMILE.HHCJCDFCLOB.BPLOEAHOPFI_StaminaUpdater;
		IOCLFHJLHLE_IntimacyUpdater = CIOECGOMILE.HHCJCDFCLOB.IOCLFHJLHLE_IntimacyUpdater;
		KCCLEHLLOFG_SaveCommon = CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave.KCCLEHLLOFG_Common;
		AAODIMMEFBI_SaveTotalUtaRate = 0;
		JHKAEJBNGKE_RateLeftToNext = 0;
		HDBFOIAGPJK = 0;
		DOMEGAEKENF_ItemId = 0;
		FBANBDCOEJL();
	}

	// // RVA: 0x11EE784 Offset: 0x11EE784 VA: 0x11EE784
	public void FBANBDCOEJL()
    {
        if(KCCLEHLLOFG_SaveCommon == null)
        {
            if(CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave.KCCLEHLLOFG_Common != null)
            {
                KCCLEHLLOFG_SaveCommon = CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave.KCCLEHLLOFG_Common;
            }
        }
        IGHDEGMBPKI_UpdateStaminaInfo();
        FOCDOMKICKL_UpdateIntimacyInfo();
        OCEAALKNGDK();
    }

	// // RVA: 0x11EE8E8 Offset: 0x11EE8E8 VA: 0x11EE8E8
	private void IGHDEGMBPKI_UpdateStaminaInfo()
    {
		long t = BPLOEAHOPFI_StaminaUpdater.MLLGPBGFLFI_GetRemainingTime();

		if (t != KLDBCKIJACO_StaminaTimeLeft || FPLEADMHLKN_StaminaStr == null)
        {
			FPLEADMHLKN_StaminaStr = "MAX";
			if (t != 0)
			{
				KOHNLDKIKPC.Clear();
				KOHNLDKIKPC.Append(JpStringLiterals.StringLiteral_11083);
				KOHNLDKIKPC.AppendFormat("{0}", t / 60);
				KOHNLDKIKPC.Append(':');
				KOHNLDKIKPC.AppendFormat("{0:d2}", t % 60);
				FPLEADMHLKN_StaminaStr = KOHNLDKIKPC.ToString();
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
			KOENBEGADHP_IntimacyStr = "MAX";
			if(t != 0)
			{
				KOHNLDKIKPC.Clear();
				KOHNLDKIKPC.Append(JpStringLiterals.StringLiteral_11083);
				KOHNLDKIKPC.AppendFormat("{0}", t / 60);
				KOHNLDKIKPC.Append(':');
				KOHNLDKIKPC.AppendFormat("{0:d2}", t % 60);
				KOENBEGADHP_IntimacyStr = KOHNLDKIKPC.ToString();
			}
			NFKMOHGLPAO_IntamacyTimeLeft = t;
		}
	}

	// // RVA: 0x11EED70 Offset: 0x11EED70 VA: 0x11EED70
	private void OCEAALKNGDK()
    {
        if(KCCLEHLLOFG_SaveCommon != null)
		{
			AAODIMMEFBI_SaveTotalUtaRate = KCCLEHLLOFG_SaveCommon.EAHPKPADCPL_TotalUtaRate;
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
			HDBFOIAGPJK = OEGIPPCADNA.HHCJCDFCLOB.CDINKAANIAA;
		}
	}
}
