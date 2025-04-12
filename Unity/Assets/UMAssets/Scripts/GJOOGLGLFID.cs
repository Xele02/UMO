
public class FJIPMALKCBG
{
	public BKKMNPEEILG HIHPPOFHMNF_Player; // 0x8
	public BKKMNPEEILG EKOCEKHBHLE_Rival; // 0xC
	public bool GGOPOOLMLBA_IsPlayerWin; // 0x10

	// RVA: 0x118706C Offset: 0x118706C VA: 0x118706C
	public void KHEKNNFCAOI()
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
            EKOCEKHBHLE_Rival.KHEKNNFCAOI(ev, ev.DPPODNCOMIA_GetRivalIdx());
        }
        GGOPOOLMLBA_IsPlayerWin = EKOCEKHBHLE_Rival.KNIFCANOHOC_ScorePoint <= HIHPPOFHMNF_Player.KNIFCANOHOC_ScorePoint;
    }
}

public class GJOOGLGLFID
{
	public const int FBGGEFFJJHB = 625060239; // 0x2541a98f
	public bool DPCFADCFMOA_RewardWin; // 0x8
	public bool FFHMPNGJCLK; // 0x9
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

	public int EJDJIBPKKNO_Point { get { return DGLKNBPHFJA_Crypted ^ FBGGEFFJJHB; } set { DGLKNBPHFJA_Crypted = value ^ FBGGEFFJJHB; } } //0xAADFAC HDENOKICDAI 0xAADFC0 IOMAGMBLBOE
	public int GCAPLLEIAAI_Score { get { return ABCKCDLNFNH_Crypted ^ FBGGEFFJJHB; } set { ABCKCDLNFNH_Crypted = value ^ FBGGEFFJJHB; } } //0xAADFD4 BKGFGIGDJHB 0xAADFE8 DELDFNOMADE
	public int GBLHPHCAPLG_ScoreBonus { get { return NKBMMDMHKGL_Crypted ^ FBGGEFFJJHB; } set { NKBMMDMHKGL_Crypted = value ^ FBGGEFFJJHB; } } //0xAADFFC ILLLOMLHELP 0xAAE010 GKIBOMGBNIA
	public int FFEBMCAKOHK { get { return CCIMLBOMBOK_Crypted ^ FBGGEFFJJHB; } set { CCIMLBOMBOK_Crypted = value ^ FBGGEFFJJHB; } } //0xAAE024 ANJEGECIEFI 0xAAE038 KEHBBLEJOJL
	public int EDOJBIJKBMB_CWin { get { return MADNMEJOOAO_Crypted ^ FBGGEFFJJHB; } set { MADNMEJOOAO_Crypted = value ^ FBGGEFFJJHB; } } //0xAAE04C EKHKKACMLBK 0xAAE060 FPPHFOLLLID
	public int BNOLJMKCPJC { get { return DCAOLMHFDBP_Crypted ^ FBGGEFFJJHB; } set { DCAOLMHFDBP_Crypted = value ^ FBGGEFFJJHB; } } //0xAAE074 GKAFCGAIOBO 0xAAE088 GAONBELLDJC
	public int FOFJCOHAFCG_EpisodeCnt { get { return CPHLLEKLFFG_Crypted ^ FBGGEFFJJHB; } set { CPHLLEKLFFG_Crypted = value ^ FBGGEFFJJHB; } } //0xAAE09C MLACLHMAMKE 0xAAE0B0 JIJCJGDAJOL
	public int CLEFJPKPOGB_EpBonusCnt { get { return FOKECLCJLJL_Crypted ^ FBGGEFFJJHB; } set { FOKECLCJLJL_Crypted = value ^ FBGGEFFJJHB; } } //0xAAE0C4 PLBDHPIJHFI 0xAAE0D8 OENPAHPKEGE
	public int PHPANNCGOKC_PointDiff { get { return JIBDGBEKJFE_Crypted ^ FBGGEFFJJHB; } set { JIBDGBEKJFE_Crypted = value ^ FBGGEFFJJHB; } } //0xAAE0EC CFKJCBPGOGG 0xAAE100 LLFBDHKOCFC
	public int HNNAJJNMCKE_PrevPoint { get { return IAKOPOHILNJ_Crypted ^ FBGGEFFJJHB; } set { IAKOPOHILNJ_Crypted = value ^ FBGGEFFJJHB; } } //0xAAE114 CIBDKNPBJGF 0xAAE128 JJOBNIILJNK
	public int AHOKAPCGJMA_NewPoint { get { return HJOJJCKDPPJ_Crypted ^ FBGGEFFJJHB; } set { HJOJJCKDPPJ_Crypted = value ^ FBGGEFFJJHB; } } //0xAAE13C GKLPFHEELGM 0xAAE150 EJPEPBGDDJM
	public int BJJGECFMNIP_Rank { get { return ONJLNJKLPAK_Crypted ^ FBGGEFFJJHB; } set { ONJLNJKLPAK_Crypted = value ^ FBGGEFFJJHB; } } //0xAAE164 PIIBCAGODGL 0xAAE178 FMOEJPCLILL
	public int EKOEECDHABK_ExRanking { get { return EFLMNHHECAL_Crypted ^ FBGGEFFJJHB; } set { EFLMNHHECAL_Crypted = value ^ FBGGEFFJJHB; } } //0xAAE18C HEPNLKNODBJ 0xAAE1A0 EGKDCMFANCH
	public int IDBJPDBLIIG_ScoreResultRank { get { return LNJLJKKBNCC_Crypted ^ FBGGEFFJJHB; } set { LNJLJKKBNCC_Crypted = value ^ FBGGEFFJJHB; } } //0xAAE1B4 IPEDFNIDNFB 0xAAE1C8 CBOMMDJKJCE
	public int FCLGIPFPIPH_DashBonus { get { return KIHLOJGPFII_Crypted ^ FBGGEFFJJHB; } set { KIHLOJGPFII_Crypted = value ^ FBGGEFFJJHB; } } //0xAAE1DC GHFOOLBCDBM 0xAAE1F0 EFACKLMPIOD
	public int BEOKMNIPFBA_MedalId { get { return FOOIDNLAAJM_Crypted ^ FBGGEFFJJHB; } set { FOOIDNLAAJM_Crypted = value ^ FBGGEFFJJHB; } } //0xAAE204 AGLAALJHLBC 0xAAE218 PFDPANDECID
	public int ODOOKDGCKMF_MedalNum { get { return JMJDBIGGGLH_Crypted ^ FBGGEFFJJHB; } set { JMJDBIGGGLH_Crypted = value ^ FBGGEFFJJHB; } } //0xAAE22C DGFGDHAPJPJ 0xAAE240 GOIMAJACHOF
	public int BGJDHCEOIDB_BattleClass { get { return BBJHIKDJEJL_Crypted ^ FBGGEFFJJHB; } set { BBJHIKDJEJL_Crypted = value ^ FBGGEFFJJHB; } } //0xAAE254 OCKGMLNANOK 0xAAE268 NINDNKAPBLB
	public int IOOBNLAHLEJ_Point2 { get { return JNLBGAKBBMH_Crypted ^ FBGGEFFJJHB; } set { JNLBGAKBBMH_Crypted = value ^ FBGGEFFJJHB; } } //0xAAE27C PILACCFMMMP 0xAAE290 LDNPPCPAFEO
	public int AKNELONELJK_Difficulty { get { return CPCKPCJBDEL_Crypted ^ FBGGEFFJJHB; } set { CPCKPCJBDEL_Crypted = value ^ FBGGEFFJJHB; } } //0xAAE2A4 BPPILHGDABB 0xAAE2B8 PMMIIHKEGCI
	public int OHDIGACEJPM_DifficultyBonus { get { return LNKHGJMLBMG_Crypted ^ FBGGEFFJJHB; } set { LNKHGJMLBMG_Crypted = value ^ FBGGEFFJJHB; } } //0xAAE2CC AHCIDJFMLNB 0xAAE2E0 LDFJHFHIMEP
	public int GLOKIBHBNDN_PrevExPoint { get { return BCMMJJPHCGN_Crypted ^ FBGGEFFJJHB; } set { BCMMJJPHCGN_Crypted = value ^ FBGGEFFJJHB; } } //0xAAE2F4 OBDKENDNFNO 0xAAE308 DEIGANPJMKF
	public int IBNOJFPGLHI_NextExPoint { get { return IGHCGEFMHPM_Crypted ^ FBGGEFFJJHB; } set { IGHCGEFMHPM_Crypted = value ^ FBGGEFFJJHB; } } //0xAAE31C PLJPEGBFNFH 0xAAE330 KCGMKKNCAGL
	public int LENOCEEGFLD_GetExGauge { get { return IPKLJCAIBGD_Crypted ^ FBGGEFFJJHB; } set { IPKLJCAIBGD_Crypted = value ^ FBGGEFFJJHB; } } //0xAAE344 GNNENEFGCCH 0xAAE358 GMGIDOMFIBI
	public int JBCBPEPMAEP_ExBattleMusicScore { get { return HOEBCPACGMK_Crypted ^ FBGGEFFJJHB; } set { HOEBCPACGMK_Crypted = value ^ FBGGEFFJJHB; } } //0xAAE36C PHFFAIMOOGA 0xAAE380 NPLILLOICHN
	public int NHNEMDAFPMJ_ExBattleScoreTotalBefore { get { return AGFLDOFHFFP_Crypted ^ FBGGEFFJJHB; } set { AGFLDOFHFFP_Crypted = value ^ FBGGEFFJJHB; } } //0xAAE394 DJAEAGDLGPO 0xAAE3A8 COPNOPBOKCK
	public int IGIPKOJJIIA_ExBattleScoreTotalAfter { get { return GEOGJLLKONC_Crypted ^ FBGGEFFJJHB; } set { GEOGJLLKONC_Crypted = value ^ FBGGEFFJJHB; } } //0xAAE3BC NMEEMHPEIFG 0xAAE3D0 DOJPMEDBMGB
	public int BOLHMCFBGBP_ExRivalIdx { get { return DHPFMDOOMOH_Crypted ^ FBGGEFFJJHB; } set { DHPFMDOOMOH_Crypted = value ^ FBGGEFFJJHB; } } //0xAAE3E4 KFHLDAHFMDH 0xAAE3F8 PENFGGBBGPJ

	// // RVA: 0xAAE40C Offset: 0xAAE40C VA: 0xAAE40C
	public void KHEKNNFCAOI()
    {
        HAEDCCLHEMN_EventBattle ev = JEPBIIJDGEF_EventInfo.HHCJCDFCLOB.OIKOHACJPCB_GetEventById(JGEOBNENMAH.HHCJCDFCLOB.JKEPHFPCKMD_EventId) as HAEDCCLHEMN_EventBattle;
        if(ev != null)
        {
            DPCFADCFMOA_RewardWin = ev.CKCPAMDDNPF.BLAJKMAPEKP_CWin > 0;
            EJDJIBPKKNO_Point = ev.CKCPAMDDNPF.FPEOGFMKMKJ_Point;
            IOOBNLAHLEJ_Point2 = ev.CKCPAMDDNPF.FPEOGFMKMKJ_Point;
            GCAPLLEIAAI_Score = ev.CKCPAMDDNPF.GCAPLLEIAAI_Score;
            GBLHPHCAPLG_ScoreBonus = ev.CKCPAMDDNPF.GBLHPHCAPLG_ScoreBonus;
            FFEBMCAKOHK = ev.CKCPAMDDNPF.MACJOPBCEEL;
            EDOJBIJKBMB_CWin = ev.CKCPAMDDNPF.BLAJKMAPEKP_CWin;
            BNOLJMKCPJC = ev.CKCPAMDDNPF.BOKPPBLPKEF;
            FOFJCOHAFCG_EpisodeCnt = ev.CKCPAMDDNPF.ANOCILKJGOJ_EpisodeCnt;
            CLEFJPKPOGB_EpBonusCnt = ev.CKCPAMDDNPF.ODCLHPGHDHA_EpisodeCntBns;
            IDBJPDBLIIG_ScoreResultRank = ev.CKCPAMDDNPF.JIMGIIBCABI_ScoreResultRank;
            FCLGIPFPIPH_DashBonus = ev.CKCPAMDDNPF.FCLGIPFPIPH;
            HNNAJJNMCKE_PrevPoint = JGEOBNENMAH.HHCJCDFCLOB.FFDBCEDKMGN_PrevPoint;
            AHOKAPCGJMA_NewPoint = JGEOBNENMAH.HHCJCDFCLOB.MMLPAMGJEOD_NewPoint;
            PHPANNCGOKC_PointDiff = AHOKAPCGJMA_NewPoint - HNNAJJNMCKE_PrevPoint;
            BJJGECFMNIP_Rank = JGEOBNENMAH.HHCJCDFCLOB.NEFFKLNAAJI_ScoreRankByDiva[0];
            EKOEECDHABK_ExRanking = JGEOBNENMAH.HHCJCDFCLOB.NEFFKLNAAJI_ScoreRankByDiva[1];
            BEOKMNIPFBA_MedalId = JGEOBNENMAH.HHCJCDFCLOB.BEOKMNIPFBA_MedalItemId;
            ODOOKDGCKMF_MedalNum = FCLGIPFPIPH_DashBonus * JGEOBNENMAH.HHCJCDFCLOB.ODOOKDGCKMF_MedalNum;
            BGJDHCEOIDB_BattleClass = ev.CKCPAMDDNPF.EIMCIBOANHE_CurrentClass;
            AKNELONELJK_Difficulty = ev.CKCPAMDDNPF.LBLOIOMNEIH_Diff;
            OHDIGACEJPM_DifficultyBonus = ev.CKCPAMDDNPF.APEFEONDBKL_DiffBonus;
            GLOKIBHBNDN_PrevExPoint = ev.CKCPAMDDNPF.ONLIMGFHGBH_ExPt;
            IBNOJFPGLHI_NextExPoint = ev.CKCPAMDDNPF.CINCDFAOEOJ_NewExPoint;
            FFHMPNGJCLK = ev.CKCPAMDDNPF.FFHMPNGJCLK;
            LENOCEEGFLD_GetExGauge = ev.CKCPAMDDNPF.MBBPOOFCAKC_GetExGauge;
            JBCBPEPMAEP_ExBattleMusicScore = ev.CKCPAMDDNPF.OOEKGFAIFPK_ExBattleMusicScore;
            NHNEMDAFPMJ_ExBattleScoreTotalBefore = ev.CKCPAMDDNPF.NHNEMDAFPMJ_ExBattleScoreTotalBefore;
            IGIPKOJJIIA_ExBattleScoreTotalAfter = ev.CKCPAMDDNPF.IGIPKOJJIIA_ExBattleScoreTotalAfter;
            BOLHMCFBGBP_ExRivalIdx = ev.CKCPAMDDNPF.BOLHMCFBGBP_SongIdx;
            LFGNLKKFOCD_IsLine6 = ev.CKCPAMDDNPF.INPNFCNLAMA_IsLine6;
        }
    }

	// // RVA: 0xAAEB10 Offset: 0xAAEB10 VA: 0xAAEB10
	// public void NFOHOGAJGHB() { }
}
