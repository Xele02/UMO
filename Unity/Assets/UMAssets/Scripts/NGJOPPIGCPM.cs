
using XeApp.Game.Common;

[System.Obsolete("Use NGJOPPIGCPM_ResultData", true)]
public class NGJOPPIGCPM { }
public class NGJOPPIGCPM_ResultData
{
    public enum DFJMELLLNLH
    {
        HJNNKCMLGFL_0_None = 0,
        HHLBGKEDNGH = 1,
        COHKBMDEMMN = 2,
    }

	private const int FBGGEFFJJHB_xor = 0x7daf3c5a;
	private const sbyte JFOFMKBJBBE_False = 0x13;
	private const sbyte CNECJGKECHK_True = 87;
	public int EPGOIGPKPPJ_FreeMusicIdCrypted = FBGGEFFJJHB_xor; // 0x8
	public int HKILOJEJAIH = FBGGEFFJJHB_xor; // 0xC
	public int KOPBFHIBOJJ_MusicIdCrypted = FBGGEFFJJHB_xor; // 0x10
	public int JFCJADPLBHD_RankCrypted = FBGGEFFJJHB_xor; // 0x14
	public int GDIPIJLELLF_Combo = FBGGEFFJJHB_xor; // 0x18
	public int FJBDKCEJGLN = FBGGEFFJJHB_xor; // 0x1C
	public int ABCKCDLNFNH_Crypted = FBGGEFFJJHB_xor; // 0x20
	public int HKIPKLKCPLO_LastScoreExcellentCrypted = FBGGEFFJJHB_xor; // 0x24
	public int LFGIMJKNBKD = FBGGEFFJJHB_xor; // 0x28
	public int IJNGBMCDJAF_ScoreCrypted = FBGGEFFJJHB_xor; // 0x2C
	public int MBCNGHHAIMH_Score2Crypted = FBGGEFFJJHB_xor; // 0x30
	public int NOCGJFJNADE_ComboCrypted = FBGGEFFJJHB_xor; // 0x34
	public sbyte APMFDBAODEM_IsBetterScoreCrypted = JFOFMKBJBBE_False; // 0x38
	public sbyte AOBEEDHDHOL_IsBetterComboCrypted = JFOFMKBJBBE_False; // 0x39
	public JDDGGJCGOPA_RecordMusic LCKMBHDMPIP_SaveRecordMusic; // 0x3C
	public JDDGGJCGOPA_RecordMusic OEELDFNNLKK_SaveRecordMusic2; // 0x40
	public int ABCAPIDDPID_PrevUtaRateCrypted = FBGGEFFJJHB_xor; // 0x44
	public int HKEGJMFNLFM_PrevScoreRatingRankingCrypted = FBGGEFFJJHB_xor; // 0x48
	public int DMBHMNCBJLG_UtaRateCrypted = FBGGEFFJJHB_xor; // 0x4C
	public int CHEJNODNFIF_ScoreRatingRankingCrypted = FBGGEFFJJHB_xor; // 0x50
	public sbyte CAKAPBLMPEF_IsBetterUtaRateCrypted = JFOFMKBJBBE_False;// 0x54
	public int CLPIAOJCCFF_PrevUtaRateTotalCrypted = FBGGEFFJJHB_xor; // 0x58
	public int HJEPJIMBANI_PrevScoreRatingRankingCrypted = FBGGEFFJJHB_xor; // 0x5C
	public int JEPPJHHGEHA_UtaRateTotalCrypted = FBGGEFFJJHB_xor; // 0x60
	public int IBKLLMPJNKB_ScoreRatingRankingCrypted = FBGGEFFJJHB_xor; // 0x64
	public sbyte HACHMIKKJJK_IsBetterUtarateTotalCrypted = JFOFMKBJBBE_False; // 0x68
	public sbyte GMECEJEFMGE_IsBetterScoreRatingRankingCrypted = JFOFMKBJBBE_False; // 0x69
	public DFJMELLLNLH JLBJIIBGCOE_RankState; // 0x6C
	public int LLLMAGFLKCK_RankNumCrypted = FBGGEFFJJHB_xor; // 0x70
	public int KEFEHDKEKGN_CategoryIdCrypted = FBGGEFFJJHB_xor; // 0x74
	private int BGDMOPHKPOJ_OtherMusicIdCrypted = FBGGEFFJJHB_xor; // 0x78
	private sbyte BMAAEAOHMKD_EnableLiveSkipCrypted = JFOFMKBJBBE_False; // 0x7C

	public int GHBPLHBNMBK_FreeMusicId { get { return EPGOIGPKPPJ_FreeMusicIdCrypted ^ FBGGEFFJJHB_xor; } set { EPGOIGPKPPJ_FreeMusicIdCrypted = value ^ FBGGEFFJJHB_xor; } } //0x1AF67C4 HKFCFPFPMBN 0x1AF67D8 IFMPBFAAKNN
	public int KLCIIHKFPPO_StoryMusicId { get { return HKILOJEJAIH ^ FBGGEFFJJHB_xor; } set { HKILOJEJAIH = value ^ FBGGEFFJJHB_xor; } } //0x1AF67EC CPDGCNILCII 0x1AF6800 IILKMGEKOBG
	public int DLAEJOBELBH_MusicId { get { return KOPBFHIBOJJ_MusicIdCrypted ^ FBGGEFFJJHB_xor; } set { KOPBFHIBOJJ_MusicIdCrypted = value ^ FBGGEFFJJHB_xor; } } //0x1AF6814 MPGNHBOBFBD 0x1AF6828 EPEMOAEGPLI
	public int PENICOGGNLF_ScoreRank { get { return JFCJADPLBHD_RankCrypted ^ FBGGEFFJJHB_xor; } set { JFCJADPLBHD_RankCrypted = value ^ FBGGEFFJJHB_xor; } } //0x1AF683C DLPHIGDCBBM 0x1AF6850 DELFJBKLPOM
	public int ILNBLNECEKB_RankCombo { get { return GDIPIJLELLF_Combo ^ FBGGEFFJJHB_xor; } set { GDIPIJLELLF_Combo = value ^ FBGGEFFJJHB_xor; } } //0x1AF6864 GNNEIKHCOLI 0x1AF6878 EOEGNHEFKGE
	public int DACPGGLFLJG_FullComboType { get { return FJBDKCEJGLN ^ FBGGEFFJJHB_xor; } set { FJBDKCEJGLN = value ^ FBGGEFFJJHB_xor; } } //0x1AF688C NELPFJENPDN 0x1AF68A0 IDHCAMDEBJE
	public int GCAPLLEIAAI_LastScore { get { return ABCKCDLNFNH_Crypted ^ FBGGEFFJJHB_xor; } set { ABCKCDLNFNH_Crypted = value ^ FBGGEFFJJHB_xor; } } //0x1AF68B4 BKGFGIGDJHB 0x1AF68C8 DELDFNOMADE
	public int GPMILOPNBPA_LastScoreExcellent { get { return HKIPKLKCPLO_LastScoreExcellentCrypted ^ FBGGEFFJJHB_xor; } set { HKIPKLKCPLO_LastScoreExcellentCrypted = value ^ FBGGEFFJJHB_xor; } } //0x1AF68DC AFMDAPPNMBO 0x1AF68F0 AIEBJIPABLO
	public int PBGLMBMEKAA_LastCombo { get { return LFGIMJKNBKD ^ FBGGEFFJJHB_xor; } set { LFGIMJKNBKD = value ^ FBGGEFFJJHB_xor; } } //0x1AF6904 JEPPJKNMPGN 0x1AF6918 ABGNJBDMNBG
	public int IHNCAAHAFEE_Score { get { return IJNGBMCDJAF_ScoreCrypted ^ FBGGEFFJJHB_xor; } set { IJNGBMCDJAF_ScoreCrypted = value ^ FBGGEFFJJHB_xor; } } //0x1AF692C GHMLPIHLMGB 0x1AF6940 PGLJIDDPPLH
	public int HMDHDKLDPFK_PrevScore { get { return MBCNGHHAIMH_Score2Crypted ^ FBGGEFFJJHB_xor; } set { MBCNGHHAIMH_Score2Crypted = value ^ FBGGEFFJJHB_xor; } } //0x1AF6954 KKOALCPGOMG 0x1AF6968 ABFEIIGHDEM
	public int NCMJNHJJLBC_Combo { get { return NOCGJFJNADE_ComboCrypted ^ FBGGEFFJJHB_xor; } set { NOCGJFJNADE_ComboCrypted = value ^ FBGGEFFJJHB_xor; } } //0x1AF697C DECNNMANJHL 0x1AF6990 GPNLFFOEJLG
	public bool HHPIAKKJBJD_IsBetterScore { get { return APMFDBAODEM_IsBetterScoreCrypted == CNECJGKECHK_True; } set { APMFDBAODEM_IsBetterScoreCrypted = value ? CNECJGKECHK_True : JFOFMKBJBBE_False; } } //0x1AF69A4 LDJAHNNPJDM 0x1AF69B8 DAPLIEAMBCJ
	public bool EFJFKKMAHMB_IsBetterCombo { get { return AOBEEDHDHOL_IsBetterComboCrypted == CNECJGKECHK_True; } set { AOBEEDHDHOL_IsBetterComboCrypted = value ? CNECJGKECHK_True : JFOFMKBJBBE_False; } } //0x1AF69E8 KMCEGBOJNOP 0x1AF69FC EMJBIIJCGDN
	public int IHEKLEFBAEL_PrevUtaRate { get { return ABCAPIDDPID_PrevUtaRateCrypted ^ FBGGEFFJJHB_xor; } set { ABCAPIDDPID_PrevUtaRateCrypted = value ^ FBGGEFFJJHB_xor; } } //0x1AF6A2C OEEIPCEIDBD 0x1AF6A40 POEKCPLLEEM
	public HighScoreRatingRank.Type JAFCLELELID_PrevScoreRatingRanking { get { return (HighScoreRatingRank.Type)(HKEGJMFNLFM_PrevScoreRatingRankingCrypted ^ FBGGEFFJJHB_xor); } set { HKEGJMFNLFM_PrevScoreRatingRankingCrypted = (int)value ^ FBGGEFFJJHB_xor; } } //0x1AF6A54 KPKFOHJBJCF 0x1AF6A68 NOMLNHIPBKJ
	public int BJGOPOEAAIC_UtaRate { get { return DMBHMNCBJLG_UtaRateCrypted ^ FBGGEFFJJHB_xor; } set { DMBHMNCBJLG_UtaRateCrypted = value ^ FBGGEFFJJHB_xor; } } //0x1AF6A7C GJOHFKBBJBK 0x1AF6A90 MHFAAMADHHI
	public HighScoreRatingRank.Type AGJIIKKOKFJ_ScoreRatingRank { get { return (HighScoreRatingRank.Type)(CHEJNODNFIF_ScoreRatingRankingCrypted ^ FBGGEFFJJHB_xor); } set { CHEJNODNFIF_ScoreRatingRankingCrypted = (int)value ^ FBGGEFFJJHB_xor; } } //0x1AF6AA4 DHPAFIAEADH 0x1AF6AB8 JOOHDJLMIBJ
	public bool NOPDDMJIFFO_IsBetterUtaRate { get { return CAKAPBLMPEF_IsBetterUtaRateCrypted == CNECJGKECHK_True; } set { CAKAPBLMPEF_IsBetterUtaRateCrypted = value ? CNECJGKECHK_True : JFOFMKBJBBE_False; } } //0x1AF6ACC GGKNEDNOFMC 0x1AF6AE0 HHLKPOBFODD
	public int EPHLOKIIFMH_PrevUtaRateTotal { get { return CLPIAOJCCFF_PrevUtaRateTotalCrypted ^ FBGGEFFJJHB_xor; } set { CLPIAOJCCFF_PrevUtaRateTotalCrypted = value ^ FBGGEFFJJHB_xor; } } //0x1AF6B10 BGJIFBHJGBJ 0x1AF6B24 HHINJOGOKMI
	public HighScoreRatingRank.Type CMOIBLMELHD_PrevScoreRatingRanking { get { return (HighScoreRatingRank.Type)(HJEPJIMBANI_PrevScoreRatingRankingCrypted ^ FBGGEFFJJHB_xor); } set { HJEPJIMBANI_PrevScoreRatingRankingCrypted = (int)value ^ FBGGEFFJJHB_xor; } } //0x1AF6B38 IAEPCOHEKLE 0x1AF6B4C NBIAPGDANMH
	public int NPODFKNEKOF_UtaRateTotal { get { return JEPPJHHGEHA_UtaRateTotalCrypted ^ FBGGEFFJJHB_xor; } set { JEPPJHHGEHA_UtaRateTotalCrypted = value ^ FBGGEFFJJHB_xor; } } //0x1AF6B60 NHFIFKGFFNE 0x1AF6B74 APOJNEGNNJN
	public HighScoreRatingRank.Type PFEIDJKAOLH_ScoreRatingRanking { get { return (HighScoreRatingRank.Type)(IBKLLMPJNKB_ScoreRatingRankingCrypted ^ FBGGEFFJJHB_xor); } set { IBKLLMPJNKB_ScoreRatingRankingCrypted = (int)value ^ FBGGEFFJJHB_xor; } } //0x1AF6B88 KFGOEAPMHJO 0x1AF6B9C AMMBONOGCKG
	public bool CEEKHMOMKOK_IsBetterUtaRateTotal { get { return HACHMIKKJJK_IsBetterUtarateTotalCrypted == CNECJGKECHK_True; } set { HACHMIKKJJK_IsBetterUtarateTotalCrypted = value ? CNECJGKECHK_True : JFOFMKBJBBE_False; } } //0x1AF6BB0 ILPHODLJADG 0x1AF6BC4 DALOAHEBCML
	public bool BEFGMPGFGHA_IsBetterScoreRatingRanking { get { return GMECEJEFMGE_IsBetterScoreRatingRankingCrypted == CNECJGKECHK_True; } set { GMECEJEFMGE_IsBetterScoreRatingRankingCrypted = value ? CNECJGKECHK_True : JFOFMKBJBBE_False; } } //0x1AF6BF4 LKKLPDLCKCH 0x1AF6C08 EMMENJHKIOK
	public int HIBKLIFIBKA_RankNum { get { return LLLMAGFLKCK_RankNumCrypted ^ FBGGEFFJJHB_xor; } set { LLLMAGFLKCK_RankNumCrypted = value ^ FBGGEFFJJHB_xor; } } //0x1AF6C38 FIIGNMBPLDM 0x1AF6C4C CJNINLEHILP
	public int BPGDOBCMDBP_CategoryId { get { return KEFEHDKEKGN_CategoryIdCrypted ^ FBGGEFFJJHB_xor; } set { KEFEHDKEKGN_CategoryIdCrypted = value ^ FBGGEFFJJHB_xor; } } //0x1AF6C60 NEPFNAHNNAM 0x1AF6C74 MAPCHCHMECM
	private int DHJAFJKALCA_ForcedMusicId { get { return BGDMOPHKPOJ_OtherMusicIdCrypted ^ FBGGEFFJJHB_xor; } set { BGDMOPHKPOJ_OtherMusicIdCrypted = value ^ FBGGEFFJJHB_xor; } } //0x1AF6C88 LABJBLDJION 0x1AF6C9C JLMLMANOAIM
	public int IOPCBBNHJIP_ForcedMusicId { get { return DHJAFJKALCA_ForcedMusicId < 1 ? DLAEJOBELBH_MusicId : DHJAFJKALCA_ForcedMusicId; } private set { DHJAFJKALCA_ForcedMusicId = value; } } //0x1AF6CB0 PJKILEHFBHA 0x1AF6CD4 BOBNBADBNGG
	public bool PMCGHPOGLGM_IsSkip { get { return BMAAEAOHMKD_EnableLiveSkipCrypted == CNECJGKECHK_True; } set { BMAAEAOHMKD_EnableLiveSkipCrypted = value ? CNECJGKECHK_True : JFOFMKBJBBE_False; } } //0x1AF6CE8 MANCOBIPIAG 0x1AF6CFC HIDGLBCKHOO

	// RVA: 0x1AF6D2C Offset: 0x1AF6D2C VA: 0x1AF6D2C
	public void KHEKNNFCAOI_Init(int GHBPLHBNMBK_FreeMusicId, Difficulty.Type NOAKHKMLPFK_diff, bool JIBFGLODGHN_EnableLiveSkip, bool _GIKLNODJKFK_IsLine6/* = false*/, int _MNNHHJBBICA_GameEventType/* = 0*/)
    {
		KEODKEGFDLD_FreeMusicInfo HMONFKMAFDD = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.IBPAFKKEKNK_Music.NOBCLJIAMLC_GetFreeMusicData(GHBPLHBNMBK_FreeMusicId);
		this.GHBPLHBNMBK_FreeMusicId = GHBPLHBNMBK_FreeMusicId;
		DLAEJOBELBH_MusicId = HMONFKMAFDD.DLAEJOBELBH_MusicId;
		AIPEHINPIHC_ForcedSettingInfo forcedPrism = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.IBPAFKKEKNK_Music.HBJDIFMCGAL_ForcedSettings.Find((AIPEHINPIHC_ForcedSettingInfo _GHPLINIACBB_x) =>
		{
			//0x1AF83C8
			return HMONFKMAFDD.BLDDNEJDFON_ForcePrismId == _GHPLINIACBB_x.NMNDNFFJHPJ_Id;
		});
		if(forcedPrism != null)
		{
			DHJAFJKALCA_ForcedMusicId = forcedPrism.IOPCBBNHJIP_ForcedMusicId;
		}
		LCKMBHDMPIP_SaveRecordMusic = CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_PlayerData.LCKMBHDMPIP_RecordMusic;
		OEELDFNNLKK_SaveRecordMusic2 = CIOECGOMILE.HHCJCDFCLOB.MNJHBCIIHED_PrevServerData.LCKMBHDMPIP_RecordMusic;
		JDDGGJCGOPA_RecordMusic.EHFMCGGNPIJ_MusicInfo mInfo1 = LCKMBHDMPIP_SaveRecordMusic.FAMANJGJANN_FreeMusicInfo[GHBPLHBNMBK_FreeMusicId - 1];
		JDDGGJCGOPA_RecordMusic.EHFMCGGNPIJ_MusicInfo mInfo2 = OEELDFNNLKK_SaveRecordMusic2.FAMANJGJANN_FreeMusicInfo[GHBPLHBNMBK_FreeMusicId - 1];
		int savedCombo = mInfo1.PDNJGJNGPNJ_MaxCombo;
		int savedScore = mInfo1.ODEHJGPDFCL_Score;
		int savedComboRank = mInfo1.ABFNAEKEGOB_ComboRank;
		if(_MNNHHJBBICA_GameEventType == 2)
		{
			MHAPMOLCPKM_EventQuest ev = JEPBIIJDGEF_EventInfo.HHCJCDFCLOB.MKBJOOAILBB_GetEventByStatus(KGCNCBOKCBA.GNENJEHKMHD_EventStatus.BCKENOKGLIJ_9_ResultRewardreceived, false) as MHAPMOLCPKM_EventQuest;
			OFNLIBDEIFA_EventQuest.HGCEGAAJFBC d = ev.JIPPHOKGLIH(GHBPLHBNMBK_FreeMusicId, true);
			if(d != null)
			{
				mInfo2 = new JDDGGJCGOPA_RecordMusic.EHFMCGGNPIJ_MusicInfo();
				mInfo2.ECKFCIHPHGJ_SetScore_ForDiff((int)NOAKHKMLPFK_diff, d.KNIFCANOHOC_score[(int)NOAKHKMLPFK_diff]);
				mInfo2.NLKEBAOBJCM_combo[(int)NOAKHKMLPFK_diff] = d.NLKEBAOBJCM_combo[(int)NOAKHKMLPFK_diff];
			}
			d = ev.JIPPHOKGLIH(GHBPLHBNMBK_FreeMusicId, false);
			if(d != null)
			{
				mInfo1 = new JDDGGJCGOPA_RecordMusic.EHFMCGGNPIJ_MusicInfo();
				mInfo1.ECKFCIHPHGJ_SetScore_ForDiff((int)NOAKHKMLPFK_diff, d.KNIFCANOHOC_score[(int)NOAKHKMLPFK_diff]);
				mInfo1.NLKEBAOBJCM_combo[(int)NOAKHKMLPFK_diff] = d.NLKEBAOBJCM_combo[(int)NOAKHKMLPFK_diff];
			}
		}
		else if(_MNNHHJBBICA_GameEventType == 3)
		{
			HAEDCCLHEMN_EventBattle ev = JEPBIIJDGEF_EventInfo.HHCJCDFCLOB.MKBJOOAILBB_GetEventByStatus(KGCNCBOKCBA.GNENJEHKMHD_EventStatus.BCKENOKGLIJ_9_ResultRewardreceived, false) as HAEDCCLHEMN_EventBattle;
            CCPKHBECNLH_EventBattle.AIFGBKMMJGL music = ev.JIPPHOKGLIH_GetMusicSaveData(GHBPLHBNMBK_FreeMusicId, true);
			if(music != null)
			{
				mInfo2 = new JDDGGJCGOPA_RecordMusic.EHFMCGGNPIJ_MusicInfo();
				if(!_GIKLNODJKFK_IsLine6)
				{
					mInfo2.ECKFCIHPHGJ_SetScore_ForDiff((int)NOAKHKMLPFK_diff, music.BDCAICINCKK_GetScoreForDiff((int)NOAKHKMLPFK_diff));
					mInfo2.NLKEBAOBJCM_combo[(int)NOAKHKMLPFK_diff] = music.NLKEBAOBJCM_combo[(int)NOAKHKMLPFK_diff];
				}
				else
				{
					mInfo2.AAELOPLDBPF_SetScoreL6_ForDiff((int)NOAKHKMLPFK_diff, music.AHDKMPFDKPE_GetScoreForDiffL6((int)NOAKHKMLPFK_diff));
					mInfo2.DNIGPFPHJAK_ComboL6[(int)NOAKHKMLPFK_diff] = music.DNIGPFPHJAK_ComboL6[(int)NOAKHKMLPFK_diff];
				}
				mInfo2.ECLDABOLHLM_ExcellentScore = music.OFJHABJNGOD_ExcellentScore;
			}
			music = ev.JIPPHOKGLIH_GetMusicSaveData(GHBPLHBNMBK_FreeMusicId, false);
			if(music != null)
			{
				mInfo1 = new JDDGGJCGOPA_RecordMusic.EHFMCGGNPIJ_MusicInfo();
				if(!_GIKLNODJKFK_IsLine6)
				{
					mInfo1.ECKFCIHPHGJ_SetScore_ForDiff((int)NOAKHKMLPFK_diff, music.BDCAICINCKK_GetScoreForDiff((int)NOAKHKMLPFK_diff));
					mInfo1.NLKEBAOBJCM_combo[(int)NOAKHKMLPFK_diff] = music.NLKEBAOBJCM_combo[(int)NOAKHKMLPFK_diff];
				}
				else
				{
					mInfo1.AAELOPLDBPF_SetScoreL6_ForDiff((int)NOAKHKMLPFK_diff, music.AHDKMPFDKPE_GetScoreForDiffL6((int)NOAKHKMLPFK_diff));
					mInfo1.DNIGPFPHJAK_ComboL6[(int)NOAKHKMLPFK_diff] = music.DNIGPFPHJAK_ComboL6[(int)NOAKHKMLPFK_diff];
				}
				mInfo1.ECLDABOLHLM_ExcellentScore = music.OFJHABJNGOD_ExcellentScore;
			}
			mInfo1.PDNJGJNGPNJ_MaxCombo = savedCombo;
			mInfo1.ODEHJGPDFCL_Score = savedScore;
			mInfo1.ABFNAEKEGOB_ComboRank = savedComboRank;
        }
		else if(_MNNHHJBBICA_GameEventType == 4)
		{
			HLEBAINCOME_EventScore ev = JEPBIIJDGEF_EventInfo.HHCJCDFCLOB.AJLEDCKMFLP_GetEventScore(KGCNCBOKCBA.GNENJEHKMHD_EventStatus.BCKENOKGLIJ_9_ResultRewardreceived) as HLEBAINCOME_EventScore;
			if(ev != null)
			{
				mInfo2 = ev.JIPPHOKGLIH(true).KJAFPNIFPGP();
				mInfo1 = ev.JIPPHOKGLIH(false).KJAFPNIFPGP();
			}
		}
		PBGLMBMEKAA_LastCombo = mInfo1.PDNJGJNGPNJ_MaxCombo;
		GCAPLLEIAAI_LastScore = mInfo1.ODEHJGPDFCL_Score;
		GPMILOPNBPA_LastScoreExcellent = mInfo1.ECLDABOLHLM_ExcellentScore;
		if(!_GIKLNODJKFK_IsLine6)
		{
			IHNCAAHAFEE_Score = mInfo1.BDCAICINCKK_GetScoreForDiff((int)NOAKHKMLPFK_diff);
			NCMJNHJJLBC_Combo = mInfo1.NLKEBAOBJCM_combo[(int)NOAKHKMLPFK_diff];
		}
		else
		{
			IHNCAAHAFEE_Score = mInfo1.AHDKMPFDKPE_GetScoreL6_ForDiff((int)NOAKHKMLPFK_diff);
			NCMJNHJJLBC_Combo = mInfo1.DNIGPFPHJAK_ComboL6[(int)NOAKHKMLPFK_diff];
		}
		if(!_GIKLNODJKFK_IsLine6)
		{
			HMDHDKLDPFK_PrevScore = mInfo2.BDCAICINCKK_GetScoreForDiff((int)NOAKHKMLPFK_diff);
			HHPIAKKJBJD_IsBetterScore = HMDHDKLDPFK_PrevScore < IHNCAAHAFEE_Score;
			EFJFKKMAHMB_IsBetterCombo = mInfo2.NLKEBAOBJCM_combo[(int)NOAKHKMLPFK_diff] < NCMJNHJJLBC_Combo;
		}
		else
		{
			HMDHDKLDPFK_PrevScore = mInfo2.AHDKMPFDKPE_GetScoreL6_ForDiff((int)NOAKHKMLPFK_diff);
			HHPIAKKJBJD_IsBetterScore = HMDHDKLDPFK_PrevScore < IHNCAAHAFEE_Score;
			EFJFKKMAHMB_IsBetterCombo = mInfo2.DNIGPFPHJAK_ComboL6[(int)NOAKHKMLPFK_diff] < NCMJNHJJLBC_Combo;
		}
		PENICOGGNLF_ScoreRank = HMONFKMAFDD.EMJCHPDJHEI(_GIKLNODJKFK_IsLine6, (int)NOAKHKMLPFK_diff).DLPBHJALHCK_GetScoreRank(GCAPLLEIAAI_LastScore);
		ILNBLNECEKB_RankCombo = HMONFKMAFDD.EMJCHPDJHEI(_GIKLNODJKFK_IsLine6, (int)NOAKHKMLPFK_diff).CCFAAPPKILD_GetRankCombo(PBGLMBMEKAA_LastCombo);
		DACPGGLFLJG_FullComboType = 0;
		if (!JIBFGLODGHN_EnableLiveSkip)
		{
			DACPGGLFLJG_FullComboType = mInfo1.ABFNAEKEGOB_ComboRank;
		}
		PMCGHPOGLGM_IsSkip = JIBFGLODGHN_EnableLiveSkip;
		BPGDOBCMDBP_CategoryId = HMONFKMAFDD.DEPGBBJMFED_CategoryId;
		GHLGEECLCMH data2 = new GHLGEECLCMH();
		data2.KHEKNNFCAOI_Init(GHBPLHBNMBK_FreeMusicId, LCKMBHDMPIP_SaveRecordMusic, OEELDFNNLKK_SaveRecordMusic2);
		data2.GLAHMLIFAPB(GHBPLHBNMBK_FreeMusicId, 0);
		JLBJIIBGCOE_RankState = data2.AGKAOEEFAAH_GetRankState();
		HIBKLIFIBKA_RankNum = data2.LGPGIGPHJJB_GetRankNum();
		IHEKLEFBAEL_PrevUtaRate = data2.KNLMOBHBPII_PrevUtaRate;
		JAFCLELELID_PrevScoreRatingRanking = data2.KIPEPDKGCCG_PrevScoreRatingRanking;
		BJGOPOEAAIC_UtaRate = data2.ADKDHKMPMHP_Rate;
		AGJIIKKOKFJ_ScoreRatingRank = data2.LLNHMMBFPMA_ScoreRatingRanking;
		NOPDDMJIFFO_IsBetterUtaRate = IHEKLEFBAEL_PrevUtaRate < BJGOPOEAAIC_UtaRate;
		EPHLOKIIFMH_PrevUtaRateTotal = data2.DEMOACDDPHM_PrevUtaRateTotal;
		CMOIBLMELHD_PrevScoreRatingRanking = data2.KIPEPDKGCCG_PrevScoreRatingRanking;
		NPODFKNEKOF_UtaRateTotal = data2.ECMFBEHEGEH_UtaRateTotal;
		CEEKHMOMKOK_IsBetterUtaRateTotal = EPHLOKIIFMH_PrevUtaRateTotal < NPODFKNEKOF_UtaRateTotal;
		PFEIDJKAOLH_ScoreRatingRanking = data2.LLNHMMBFPMA_ScoreRatingRanking;
		BEFGMPGFGHA_IsBetterScoreRatingRanking = CMOIBLMELHD_PrevScoreRatingRanking < PFEIDJKAOLH_ScoreRatingRanking;
	}

	// // RVA: 0x1AF82EC Offset: 0x1AF82EC VA: 0x1AF82EC
	// public string LDBPEIMINJB() { }
}
