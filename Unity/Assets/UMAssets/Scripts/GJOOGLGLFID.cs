
public class FJIPMALKCBG
{
	public BKKMNPEEILG HIHPPOFHMNF_Player; // 0x8
	public BKKMNPEEILG EKOCEKHBHLE_Rival; // 0xC
	public bool GGOPOOLMLBA_IsPlayerWin; // 0x10

	// RVA: 0x118706C Offset: 0x118706C VA: 0x118706C
	public void KHEKNNFCAOI_Init()
    {
        HAEDCCLHEMN_EventBattle ev = JEPBIIJDGEF_EventInfo.HHCJCDFCLOB.OIKOHACJPCB_GetEventById(JGEOBNENMAH.HHCJCDFCLOB.JKEPHFPCKMD_EventId) as HAEDCCLHEMN_EventBattle;
        if(ev == null)
        {
            HIHPPOFHMNF_Player = new BKKMNPEEILG();
            HIHPPOFHMNF_Player.HNLMOCGGIGH();
            EKOCEKHBHLE_Rival = new BKKMNPEEILG();
            EKOCEKHBHLE_Rival.BPHKMLGBBAF();
        }
        else
        {
            HIHPPOFHMNF_Player = new BKKMNPEEILG();
            HIHPPOFHMNF_Player.GOCAPCKLAPI(ev, JGEOBNENMAH.HHCJCDFCLOB.PFHMFKKDMBM_FreeMusicId);
            EKOCEKHBHLE_Rival = new BKKMNPEEILG();
            EKOCEKHBHLE_Rival.KHEKNNFCAOI_Init(ev, ev.DPPODNCOMIA_GetRivalIdx());
        }
        GGOPOOLMLBA_IsPlayerWin = EKOCEKHBHLE_Rival.KNIFCANOHOC_score <= HIHPPOFHMNF_Player.KNIFCANOHOC_score;
    }
}

public class GJOOGLGLFID
{
	public const int FBGGEFFJJHB_xor = 625060239; // 0x2541a98f
	public bool DPCFADCFMOA_Win; // 0x8
	public bool FFHMPNGJCLK_NewRecord; // 0x9
	public bool LFGNLKKFOCD_IsLine6; // 0xA
	public int DGLKNBPHFJA_Crypted; // 0xC
	public int ABCKCDLNFNH_Crypted; // 0x10
	public int NKBMMDMHKGL_Crypted; // 0x14
	public int CCIMLBOMBOK_Crypted; // 0x18
	public int MADNMEJOOAO_Crypted; // 0x1C
	public int DCAOLMHFDBP_Crypted; // 0x20
	public int CPHLLEKLFFG_Crypted; // 0x24
	public int FOKECLCJLJL_Crypted; // 0x28
	public int JIBDGBEKJFE_Crypted; // 0x2C
	public int IAKOPOHILNJ_Crypted; // 0x30
	public int HJOJJCKDPPJ_Crypted; // 0x34
	public int ONJLNJKLPAK_Crypted; // 0x38
	public int EFLMNHHECAL_Crypted; // 0x3C
	public int LNJLJKKBNCC_Crypted; // 0x40
	public int KIHLOJGPFII_Crypted; // 0x44
	public int FOOIDNLAAJM_Crypted; // 0x48
	public int JMJDBIGGGLH_Crypted; // 0x4C
	public int BBJHIKDJEJL_Crypted; // 0x50
	public int JNLBGAKBBMH_Crypted; // 0x54
	public int CPCKPCJBDEL_Crypted; // 0x58
	public int LNKHGJMLBMG_Crypted; // 0x5C
	public int BCMMJJPHCGN_Crypted; // 0x60
	public int IGHCGEFMHPM_Crypted; // 0x64
	public int IPKLJCAIBGD_Crypted; // 0x68
	public int HOEBCPACGMK_Crypted; // 0x6C
	public int AGFLDOFHFFP_Crypted; // 0x70
	public int GEOGJLLKONC_Crypted; // 0x74
	public int DHPFMDOOMOH_Crypted; // 0x78

	public int EJDJIBPKKNO_BasePoint { get { return DGLKNBPHFJA_Crypted ^ FBGGEFFJJHB_xor; } set { DGLKNBPHFJA_Crypted = value ^ FBGGEFFJJHB_xor; } } //0xAADFAC HDENOKICDAI_bgs 0xAADFC0 IOMAGMBLBOE_bgs
	public int GCAPLLEIAAI_LastScore { get { return ABCKCDLNFNH_Crypted ^ FBGGEFFJJHB_xor; } set { ABCKCDLNFNH_Crypted = value ^ FBGGEFFJJHB_xor; } } //0xAADFD4 BKGFGIGDJHB_bgs 0xAADFE8 DELDFNOMADE_bgs
	public int GBLHPHCAPLG_ScoreBonus { get { return NKBMMDMHKGL_Crypted ^ FBGGEFFJJHB_xor; } set { NKBMMDMHKGL_Crypted = value ^ FBGGEFFJJHB_xor; } } //0xAADFFC ILLLOMLHELP_bgs 0xAAE010 GKIBOMGBNIA_bgs
	public int FFEBMCAKOHK { get { return CCIMLBOMBOK_Crypted ^ FBGGEFFJJHB_xor; } set { CCIMLBOMBOK_Crypted = value ^ FBGGEFFJJHB_xor; } } //0xAAE024 ANJEGECIEFI_bgs 0xAAE038 KEHBBLEJOJL_bgs
	public int EDOJBIJKBMB_CWin { get { return MADNMEJOOAO_Crypted ^ FBGGEFFJJHB_xor; } set { MADNMEJOOAO_Crypted = value ^ FBGGEFFJJHB_xor; } } //0xAAE04C EKHKKACMLBK_bgs 0xAAE060 FPPHFOLLLID_bgs
	public int BNOLJMKCPJC { get { return DCAOLMHFDBP_Crypted ^ FBGGEFFJJHB_xor; } set { DCAOLMHFDBP_Crypted = value ^ FBGGEFFJJHB_xor; } } //0xAAE074 GKAFCGAIOBO_bgs 0xAAE088 GAONBELLDJC_bgs
	public int FOFJCOHAFCG_EpisodeCnt { get { return CPHLLEKLFFG_Crypted ^ FBGGEFFJJHB_xor; } set { CPHLLEKLFFG_Crypted = value ^ FBGGEFFJJHB_xor; } } //0xAAE09C MLACLHMAMKE_bgs 0xAAE0B0 JIJCJGDAJOL_bgs
	public int CLEFJPKPOGB_EpBonusCnt { get { return FOKECLCJLJL_Crypted ^ FBGGEFFJJHB_xor; } set { FOKECLCJLJL_Crypted = value ^ FBGGEFFJJHB_xor; } } //0xAAE0C4 PLBDHPIJHFI_bgs 0xAAE0D8 OENPAHPKEGE_bgs
	public int PHPANNCGOKC_GetPoint { get { return JIBDGBEKJFE_Crypted ^ FBGGEFFJJHB_xor; } set { JIBDGBEKJFE_Crypted = value ^ FBGGEFFJJHB_xor; } } //0xAAE0EC CFKJCBPGOGG_bgs 0xAAE100 LLFBDHKOCFC_bgs
	public int HNNAJJNMCKE_PrevPoint { get { return IAKOPOHILNJ_Crypted ^ FBGGEFFJJHB_xor; } set { IAKOPOHILNJ_Crypted = value ^ FBGGEFFJJHB_xor; } } //0xAAE114 CIBDKNPBJGF_bgs 0xAAE128 JJOBNIILJNK_bgs
	public int AHOKAPCGJMA_TotalPoint { get { return HJOJJCKDPPJ_Crypted ^ FBGGEFFJJHB_xor; } set { HJOJJCKDPPJ_Crypted = value ^ FBGGEFFJJHB_xor; } } //0xAAE13C GKLPFHEELGM_bgs 0xAAE150 EJPEPBGDDJM_bgs
	public int BJJGECFMNIP_Rank { get { return ONJLNJKLPAK_Crypted ^ FBGGEFFJJHB_xor; } set { ONJLNJKLPAK_Crypted = value ^ FBGGEFFJJHB_xor; } } //0xAAE164 PIIBCAGODGL_bgs 0xAAE178 FMOEJPCLILL_bgs
	public int EKOEECDHABK_ExRanking { get { return EFLMNHHECAL_Crypted ^ FBGGEFFJJHB_xor; } set { EFLMNHHECAL_Crypted = value ^ FBGGEFFJJHB_xor; } } //0xAAE18C HEPNLKNODBJ_bgs 0xAAE1A0 EGKDCMFANCH_bgs
	public int IDBJPDBLIIG_ScoreResultRank { get { return LNJLJKKBNCC_Crypted ^ FBGGEFFJJHB_xor; } set { LNJLJKKBNCC_Crypted = value ^ FBGGEFFJJHB_xor; } } //0xAAE1B4 IPEDFNIDNFB_bgs 0xAAE1C8 CBOMMDJKJCE_bgs
	public int FCLGIPFPIPH_DashBonus { get { return KIHLOJGPFII_Crypted ^ FBGGEFFJJHB_xor; } set { KIHLOJGPFII_Crypted = value ^ FBGGEFFJJHB_xor; } } //0xAAE1DC GHFOOLBCDBM_bgs 0xAAE1F0 EFACKLMPIOD_bgs
	public int BEOKMNIPFBA_MedalItemId { get { return FOOIDNLAAJM_Crypted ^ FBGGEFFJJHB_xor; } set { FOOIDNLAAJM_Crypted = value ^ FBGGEFFJJHB_xor; } } //0xAAE204 AGLAALJHLBC_bgs 0xAAE218 PFDPANDECID_bgs
	public int ODOOKDGCKMF_MedalNum { get { return JMJDBIGGGLH_Crypted ^ FBGGEFFJJHB_xor; } set { JMJDBIGGGLH_Crypted = value ^ FBGGEFFJJHB_xor; } } //0xAAE22C DGFGDHAPJPJ_bgs 0xAAE240 GOIMAJACHOF_bgs
	public int BGJDHCEOIDB_BattleClass { get { return BBJHIKDJEJL_Crypted ^ FBGGEFFJJHB_xor; } set { BBJHIKDJEJL_Crypted = value ^ FBGGEFFJJHB_xor; } } //0xAAE254 OCKGMLNANOK_bgs 0xAAE268 NINDNKAPBLB_bgs
	public int IOOBNLAHLEJ_WinPoint { get { return JNLBGAKBBMH_Crypted ^ FBGGEFFJJHB_xor; } set { JNLBGAKBBMH_Crypted = value ^ FBGGEFFJJHB_xor; } } //0xAAE27C PILACCFMMMP_bgs 0xAAE290 LDNPPCPAFEO_bgs
	public int AKNELONELJK_difficulty { get { return CPCKPCJBDEL_Crypted ^ FBGGEFFJJHB_xor; } set { CPCKPCJBDEL_Crypted = value ^ FBGGEFFJJHB_xor; } } //0xAAE2A4 BPPILHGDABB_get_difficulty 0xAAE2B8 PMMIIHKEGCI_set_difficulty
	public int OHDIGACEJPM_DifficultyBonus { get { return LNKHGJMLBMG_Crypted ^ FBGGEFFJJHB_xor; } set { LNKHGJMLBMG_Crypted = value ^ FBGGEFFJJHB_xor; } } //0xAAE2CC AHCIDJFMLNB_bgs 0xAAE2E0 LDFJHFHIMEP_bgs
	public int GLOKIBHBNDN_PrevExPoint { get { return BCMMJJPHCGN_Crypted ^ FBGGEFFJJHB_xor; } set { BCMMJJPHCGN_Crypted = value ^ FBGGEFFJJHB_xor; } } //0xAAE2F4 OBDKENDNFNO_bgs 0xAAE308 DEIGANPJMKF_bgs
	public int IBNOJFPGLHI_NextExPoint { get { return IGHCGEFMHPM_Crypted ^ FBGGEFFJJHB_xor; } set { IGHCGEFMHPM_Crypted = value ^ FBGGEFFJJHB_xor; } } //0xAAE31C PLJPEGBFNFH_bgs 0xAAE330 KCGMKKNCAGL_bgs
	public int LENOCEEGFLD_GetExGauge { get { return IPKLJCAIBGD_Crypted ^ FBGGEFFJJHB_xor; } set { IPKLJCAIBGD_Crypted = value ^ FBGGEFFJJHB_xor; } } //0xAAE344 GNNENEFGCCH_bgs 0xAAE358 GMGIDOMFIBI_bgs
	public int JBCBPEPMAEP_ExBattleMusicScore { get { return HOEBCPACGMK_Crypted ^ FBGGEFFJJHB_xor; } set { HOEBCPACGMK_Crypted = value ^ FBGGEFFJJHB_xor; } } //0xAAE36C PHFFAIMOOGA_bgs 0xAAE380 NPLILLOICHN_bgs
	public int NHNEMDAFPMJ_ExBattleScoreTotalBefore { get { return AGFLDOFHFFP_Crypted ^ FBGGEFFJJHB_xor; } set { AGFLDOFHFFP_Crypted = value ^ FBGGEFFJJHB_xor; } } //0xAAE394 DJAEAGDLGPO_bgs 0xAAE3A8 COPNOPBOKCK_bgs
	//ExBattleScoreTotalAfter
	public int IGIPKOJJIIA_TotalScore { get { return GEOGJLLKONC_Crypted ^ FBGGEFFJJHB_xor; } set { GEOGJLLKONC_Crypted = value ^ FBGGEFFJJHB_xor; } } //0xAAE3BC NMEEMHPEIFG_bgs 0xAAE3D0 DOJPMEDBMGB_bgs
	// ExRivalIdx
	public int BOLHMCFBGBP_Idx { get { return DHPFMDOOMOH_Crypted ^ FBGGEFFJJHB_xor; } set { DHPFMDOOMOH_Crypted = value ^ FBGGEFFJJHB_xor; } } //0xAAE3E4 KFHLDAHFMDH_bgs 0xAAE3F8 PENFGGBBGPJ_bgs

	// // RVA: 0xAAE40C Offset: 0xAAE40C VA: 0xAAE40C
	public void KHEKNNFCAOI_Init()
    {
        HAEDCCLHEMN_EventBattle ev = JEPBIIJDGEF_EventInfo.HHCJCDFCLOB.OIKOHACJPCB_GetEventById(JGEOBNENMAH.HHCJCDFCLOB.JKEPHFPCKMD_EventId) as HAEDCCLHEMN_EventBattle;
        if(ev != null)
        {
            DPCFADCFMOA_Win = ev.CKCPAMDDNPF.BLAJKMAPEKP_CWin > 0;
            EJDJIBPKKNO_BasePoint = ev.CKCPAMDDNPF.FPEOGFMKMKJ_Point;
            IOOBNLAHLEJ_WinPoint = ev.CKCPAMDDNPF.FPEOGFMKMKJ_Point;
            GCAPLLEIAAI_LastScore = ev.CKCPAMDDNPF.GCAPLLEIAAI_LastScore;
            GBLHPHCAPLG_ScoreBonus = ev.CKCPAMDDNPF.GBLHPHCAPLG_ScoreBonus;
            FFEBMCAKOHK = ev.CKCPAMDDNPF.MACJOPBCEEL;
            EDOJBIJKBMB_CWin = ev.CKCPAMDDNPF.BLAJKMAPEKP_CWin;
            BNOLJMKCPJC = ev.CKCPAMDDNPF.BOKPPBLPKEF;
            FOFJCOHAFCG_EpisodeCnt = ev.CKCPAMDDNPF.ANOCILKJGOJ_EpisodeCnt;
            CLEFJPKPOGB_EpBonusCnt = ev.CKCPAMDDNPF.ODCLHPGHDHA_EpisodeBonus;
            IDBJPDBLIIG_ScoreResultRank = ev.CKCPAMDDNPF.JIMGIIBCABI_ScoreResultRank;
            FCLGIPFPIPH_DashBonus = ev.CKCPAMDDNPF.FCLGIPFPIPH_DashBonus;
            HNNAJJNMCKE_PrevPoint = JGEOBNENMAH.HHCJCDFCLOB.FFDBCEDKMGN_PrevPoint;
            AHOKAPCGJMA_TotalPoint = JGEOBNENMAH.HHCJCDFCLOB.MMLPAMGJEOD_NewPoint;
            PHPANNCGOKC_GetPoint = AHOKAPCGJMA_TotalPoint - HNNAJJNMCKE_PrevPoint;
            BJJGECFMNIP_Rank = JGEOBNENMAH.HHCJCDFCLOB.NEFFKLNAAJI_ScoreRankByDiva[0];
            EKOEECDHABK_ExRanking = JGEOBNENMAH.HHCJCDFCLOB.NEFFKLNAAJI_ScoreRankByDiva[1];
            BEOKMNIPFBA_MedalItemId = JGEOBNENMAH.HHCJCDFCLOB.BEOKMNIPFBA_MedalItemId;
            ODOOKDGCKMF_MedalNum = FCLGIPFPIPH_DashBonus * JGEOBNENMAH.HHCJCDFCLOB.ODOOKDGCKMF_MedalNum;
            BGJDHCEOIDB_BattleClass = ev.CKCPAMDDNPF.EIMCIBOANHE_CurrentClass;
            AKNELONELJK_difficulty = ev.CKCPAMDDNPF.LBLOIOMNEIH_Difficulty;
            OHDIGACEJPM_DifficultyBonus = ev.CKCPAMDDNPF.APEFEONDBKL_DiffBonus;
            GLOKIBHBNDN_PrevExPoint = ev.CKCPAMDDNPF.ONLIMGFHGBH_ExPt;
            IBNOJFPGLHI_NextExPoint = ev.CKCPAMDDNPF.CINCDFAOEOJ_NewExPoint;
            FFHMPNGJCLK_NewRecord = ev.CKCPAMDDNPF.FFHMPNGJCLK_NewRecord;
            LENOCEEGFLD_GetExGauge = ev.CKCPAMDDNPF.MBBPOOFCAKC_GetExGauge;
            JBCBPEPMAEP_ExBattleMusicScore = ev.CKCPAMDDNPF.OOEKGFAIFPK_ExBattleMusicScore;
            NHNEMDAFPMJ_ExBattleScoreTotalBefore = ev.CKCPAMDDNPF.NHNEMDAFPMJ_ExBattleScoreTotalBefore;
            IGIPKOJJIIA_TotalScore = ev.CKCPAMDDNPF.IGIPKOJJIIA_TotalScore;
            BOLHMCFBGBP_Idx = ev.CKCPAMDDNPF.BOLHMCFBGBP_Idx;
            LFGNLKKFOCD_IsLine6 = ev.CKCPAMDDNPF.INPNFCNLAMA_IsLine6;
        }
    }

	// // RVA: 0xAAEB10 Offset: 0xAAEB10 VA: 0xAAEB10
	// public void NFOHOGAJGHB() { }
}
