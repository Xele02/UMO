
using System;
using System.Collections.Generic;
using XeSys;

[System.Obsolete("Use JDDGGJCGOPA_RecordMusic", true)]
public class JDDGGJCGOPA { }
public class JDDGGJCGOPA_RecordMusic : KLFDBFMNLBL_ServerSaveBlock
{
	public class EHFMCGGNPIJ_MusicInfo
	{
		private const int FBGGEFFJJHB = 0x3481774d;
		private const long BBEGLBMOBOF = 0x7fffffff00000000;
		private const sbyte JFOFMKBJBBE_False = 26;
		private const sbyte CNECJGKECHK_True = 56;
		private List<int> EHDFACFDBNF_Score = new List<int>(5); // 0x8
		private List<int> LMALFDHLAJE_Clear = new List<int>(5); // 0xC
		private List<int> GGCFNCFLHMI_Play = new List<int>(5); // 0x10
		private List<sbyte> NIDCMBMHNJH_CbRnk = new List<sbyte>(5); // 0x14
		private List<int> JNEIFCHEFCC_Combo = new List<int>(5); // 0x18
		private List<byte> CCPAMBMMDAO_RewardClear = new List<byte>(5); // 0x1C
		private List<byte> BFIJHDIABDA_RewardScore = new List<byte>(5); // 0x20
		private List<byte> BOCKBJAEHKN_RewardCombo = new List<byte>(5); // 0x24
		private List<int> DNBHFDGIJCP_ScoreL6ByDiff = new List<int>(5); // 0x28
		private List<int> PBLKLPPGGDE_ClearL6 = new List<int>(5); // 0x2C
		private List<int> CMMHMFIFNLA_PlayL6 = new List<int>(5); // 0x30
		private List<sbyte> CGEJAJFJGIN_CbRnkL6 = new List<sbyte>(5); // 0x34
		private List<int> GCHPCDLBHKB_ComboL6 = new List<int>(5); // 0x38
		private List<byte> LHFMGNBHEIB_RewardClearL6 = new List<byte>(5); // 0x3C
		private List<byte> BMMPNMDNDDM_RewardScoreL6 = new List<byte>(5); // 0x40
		private List<byte> IGCADAEBODO_RewardComboL6 = new List<byte>(5); // 0x44
		public List<int> BKJPGJJAODB; // 0x4C
		private int OLNGPNJPAJI = FBGGEFFJJHB; // 0x50
		private long JDNKJBOIBFI_WDatCrypted = BBEGLBMOBOF; // 0x58
		private int CNJFHCGJOLL_WplyCrypted = FBGGEFFJJHB; // 0x60
		private int EEEEIINCCDO = FBGGEFFJJHB; // 0x64
		private int JDFAEOFJLAD = FBGGEFFJJHB; // 0x68
		private int LJICNLABOLM = FBGGEFFJJHB; // 0x6C
		private int NHEMFNJMDPF = FBGGEFFJJHB; // 0x70
		private int NNMIINCFHFJ = FBGGEFFJJHB; // 0x74
		private int BLIKMGFECGJ_HsrScCrypted = FBGGEFFJJHB; // 0x78
		private int JJBJGPLLBOC_HsrDfCrypted = FBGGEFFJJHB; // 0x7C
		private long OKDADPCINGA_HsrDtCrypted = BBEGLBMOBOF; // 0x80
		private int MDOLOMFNOJL_HsrL6Crypted = FBGGEFFJJHB; // 0x88
		private sbyte MEPLEIEDBGE_UlNewCrypted = JFOFMKBJBBE_False; // 0x8C
		private sbyte GFFNLJGKIEN_IsShowUnlockCrypted = JFOFMKBJBBE_False; // 0x8D

		public int FDMENECIKEL_FreeMusicId { get; set; } = 0; // 0x48 PBOOKJCHMHD PFDAHOAMHHB NFCFELJGBNP
		private List<int> KNIFCANOHOC_Score { get { return EHDFACFDBNF_Score; } } //0x1C2FC9C EOJEPLIPOMJ
		public List<int> JNLKJCDFFMM_Clear { get { return LMALFDHLAJE_Clear; } } //0x1C2F370 JLGNODHICKN 
		public List<int> EMHFDJEFIHG_Play { get { return GGCFNCFLHMI_Play; } } //0x1C2F414 OBFCFPIDKGB
		public List<int> NLKEBAOBJCM_Combo { get { return JNEIFCHEFCC_Combo; } } //0x1C2F4B8 AECNKGBNKHH
		public List<sbyte> LAMCCNAKIOJ_CbRnk { get { return NIDCMBMHNJH_CbRnk; } } //0x1C2F748 IHEENNFAAAJ
		// private List<int> HAFFCOKJHBN { get; } 0x1C2FCA4 LAGMNAEEJGO
		public List<int> DPPCFFFNBGA_ClearL6 { get { return PBLKLPPGGDE_ClearL6; } } //0x1C2F8B4 HMOLAAMBOBJ
		public List<int> FHFKOGIPAEH_PlayL6 { get { return CMMHMFIFNLA_PlayL6; } } //0x1C2F958 MLIKAHINHNO
		public List<int> DNIGPFPHJAK_ComboL6 { get { return GCHPCDLBHKB_ComboL6; } } //0x1C2F9FC JLJFCGBAMLC
		public List<sbyte> EEECMKPLPNL_CbRnkL6 { get { return CGEJAJFJGIN_CbRnkL6; } } //0x1C2FC8C LLOKGFIBMPI
		public List<byte> HNDPLCDMOJF_RewardClear { get { return CCPAMBMMDAO_RewardClear; } } //0x1C2F55C BAKANCFDLGK
		public List<byte> JDIDBMEMKBC_RewardScore { get { return BFIJHDIABDA_RewardScore; } } //0x1C2F600 PJDDKJOCNJM
		public List<byte> AGGFHNMMGMN_RewardCombo { get { return BOCKBJAEHKN_RewardCombo; } } //0x1C2F6A4 JKNMIFJDOPC
		public List<byte> LGBKKDOLOFP_RewardClearL6 { get { return LHFMGNBHEIB_RewardClearL6; } } //0x1C2FAA0 GIDMLJIGLFN
		public List<byte> DKIIINIEKHP_RewardScoreL6 { get { return BMMPNMDNDDM_RewardScoreL6; } } //0x1C2FB44 ILMBCJFPDOA
		public List<byte> JNNIOJIDNKM_RewardComboL6 { get { return IGCADAEBODO_RewardComboL6; } } //0x1C2FBE8 BDHDINPFBGG
		public int NCDHBLHHMDA { get { return OLNGPNJPAJI ^ FBGGEFFJJHB; } set { OLNGPNJPAJI = value ^ FBGGEFFJJHB; } } //0x1C2FCAC JPCDGGKEBNB 0x1C2FCC0 LNOFGLLEGFM
		public long CAPAIICHDMH_WDat { get { return JDNKJBOIBFI_WDatCrypted ^ BBEGLBMOBOF; } set { JDNKJBOIBFI_WDatCrypted = value ^ BBEGLBMOBOF; } } //0x1C2FCD4 LCCDEIHKPIM 0x1C266EC MBKNHNFNPFF
		public int FECIGAOOFBE_Wply { get { return CNJFHCGJOLL_WplyCrypted ^ FBGGEFFJJHB; } set { CNJFHCGJOLL_WplyCrypted = value ^ FBGGEFFJJHB; } } //0x1C2FCE8 OKGBDDPLHJG 0x1C26704 HOFKGENEFJL
		public int ODEHJGPDFCL { get { return EEEEIINCCDO ^ FBGGEFFJJHB; } set { EEEEIINCCDO = value ^ FBGGEFFJJHB; } } //0x1C2FCFC JOAGIBLBFNC 0x1C2FD10 MKHAAECKMGG
		public int ECLDABOLHLM { get { return JDFAEOFJLAD ^ FBGGEFFJJHB; } set { JDFAEOFJLAD = value ^ FBGGEFFJJHB; } } //0x1C2FD24 HPPGLGDLIMM 0x1C2FD38 ELFABLKMCMK
		public int PDNJGJNGPNJ { get { return LJICNLABOLM ^ FBGGEFFJJHB; } set { LJICNLABOLM = value ^ FBGGEFFJJHB; } } //0x1C2FD4C ABODBNKBNOO 0x1C2FD60 PNKDNMIABDB
		public int ANDJNPEINGI { get { return NHEMFNJMDPF ^ FBGGEFFJJHB; } set { NHEMFNJMDPF = value ^ FBGGEFFJJHB; } } //0x1C2FD74 ADEKEIDKEPF 0x1C2FD88 MHHDNHONMDB
		public int ABFNAEKEGOB { get { return NNMIINCFHFJ ^ FBGGEFFJJHB; } set { NNMIINCFHFJ = value ^ FBGGEFFJJHB; } } //0x1C2FD9C KPBEEKDHPCO 0x1C2FDB0 KDKEKPADEBH
		public int IFNDLIGGGHP_HighScoreScore { get { return BLIKMGFECGJ_HsrScCrypted ^ FBGGEFFJJHB; } set { BLIKMGFECGJ_HsrScCrypted = value ^ FBGGEFFJJHB; } } //0x1C2FDC4 PHCJJFHEJMN 0x1C26718 EACIOLBFJNF
		public int NOCLBJAGNHD_HighScoreDiff { get { return JJBJGPLLBOC_HsrDfCrypted ^ FBGGEFFJJHB; } set { JJBJGPLLBOC_HsrDfCrypted = value ^ FBGGEFFJJHB; } } //0x1C2FDD8 IINKAMMILOA 0x1C2672C GFJFIIAEGAF
		public long NLIDBKHMBBD_HighScoreDate { get { return OKDADPCINGA_HsrDtCrypted ^ BBEGLBMOBOF; } set { OKDADPCINGA_HsrDtCrypted = value ^ BBEGLBMOBOF; } } //0x1C2FDEC ICCKFFMNFBO 0x1C26740 JDMOKADHKBA
		public int AOGEGMMBGEN_HighScoreLine6 { get { return MDOLOMFNOJL_HsrL6Crypted ^ FBGGEFFJJHB; } set { MDOLOMFNOJL_HsrL6Crypted = value ^ FBGGEFFJJHB; } } //0x1C2FE00 MJCLEIIGLHC 0x1C26758 GEMPPIJMLLP
		public bool CPBDGAGKNGH_UlNew { get { return MEPLEIEDBGE_UlNewCrypted == CNECJGKECHK_True; } set { MEPLEIEDBGE_UlNewCrypted = value ? CNECJGKECHK_True : JFOFMKBJBBE_False; } } //0x1C2FE14 KJLPFJJHJPE 0x1C2676C CLALHMCBPNF
		public bool DMANHOPOBMP_IsShowUnlock { get { return GFFNLJGKIEN_IsShowUnlockCrypted == CNECJGKECHK_True; } set { GFFNLJGKIEN_IsShowUnlockCrypted = value ? CNECJGKECHK_True : JFOFMKBJBBE_False; } } //0x1C24440 FCMKOPJKOOP 0x1C2679C ONBGMANKJKK

		// // RVA: 0x1C2FE28 Offset: 0x1C2FE28 VA: 0x1C2FE28
		public bool FKBPJCDBDAG_SetWeekEventServerDate(long LKCCMBEOLLA)
		{
			DateTime date1 = Utility.GetLocalDateTime(LKCCMBEOLLA);
			DateTime date2 = Utility.GetLocalDateTime(CAPAIICHDMH_WDat);
			if(date1.Year == date2.Year && date1.Month == date2.Month && date1.Day == date2.Day)
			{
				CAPAIICHDMH_WDat = LKCCMBEOLLA;
				FECIGAOOFBE_Wply = 0;
				return true;
			}
			return false;
		}

		// // RVA: 0x1C242CC Offset: 0x1C242CC VA: 0x1C242CC
		// public bool PDEHFBKMIHB() { }

		// // RVA: 0x1C2FFD8 Offset: 0x1C2FFD8 VA: 0x1C2FFD8
		public int BDCAICINCKK_GetScoreForDiff(int AKNELONELJK)
		{
			return EHDFACFDBNF_Score[AKNELONELJK] ^ FBGGEFFJJHB;
		}

		// // RVA: 0x1C2F244 Offset: 0x1C2F244 VA: 0x1C2F244
		public void ECKFCIHPHGJ_SetScore_ForDiff(int AKNELONELJK, int DFDDNAOMJFE)
		{
			EHDFACFDBNF_Score[AKNELONELJK] = DFDDNAOMJFE ^ FBGGEFFJJHB;
		}

		// // RVA: 0x1C30064 Offset: 0x1C30064 VA: 0x1C30064
		public int AHDKMPFDKPE_GetScoreL6_ForDiff(int AKNELONELJK)
		{
			return DNBHFDGIJCP_ScoreL6ByDiff[AKNELONELJK] ^ FBGGEFFJJHB;
		}

		// // RVA: 0x1C2F788 Offset: 0x1C2F788 VA: 0x1C2F788
		public void AAELOPLDBPF_SetScoreL6_ForDiff(int AKNELONELJK, int DFDDNAOMJFE)
		{
			DNBHFDGIJCP_ScoreL6ByDiff[AKNELONELJK] = DFDDNAOMJFE ^ FBGGEFFJJHB;
		}

		// // RVA: 0x1C300F0 Offset: 0x1C300F0 VA: 0x1C300F0
		public int CLBAFNFLMKL_GetMaxScore()
		{
			int maxScore = 0;
			for(int i = 0; i < 5; i++)
			{
				int diffScore = BDCAICINCKK_GetScoreForDiff(i);
				if (maxScore < diffScore)
					maxScore = diffScore;
			}
			return maxScore;
		}

		// // RVA: 0x1C3012C Offset: 0x1C3012C VA: 0x1C3012C
		// public int CLOOOLFEODE() { }

		// RVA: 0x1C23B10 Offset: 0x1C23B10 VA: 0x1C23B10
		public EHFMCGGNPIJ_MusicInfo()
		{
			EINIOBAIDCP();
		}

		// // RVA: 0x1C30168 Offset: 0x1C30168 VA: 0x1C30168
		// public void LHPDDGIJKNB() { }

		// // RVA: 0x1C30178 Offset: 0x1C30178 VA: 0x1C30178
		public void EINIOBAIDCP()
		{
			EHDFACFDBNF_Score.Clear();
			LMALFDHLAJE_Clear.Clear();
			GGCFNCFLHMI_Play.Clear();
			JNEIFCHEFCC_Combo.Clear();
			CCPAMBMMDAO_RewardClear.Clear();
			BFIJHDIABDA_RewardScore.Clear();
			BOCKBJAEHKN_RewardCombo.Clear();
			NIDCMBMHNJH_CbRnk.Clear();
			DNBHFDGIJCP_ScoreL6ByDiff.Clear();
			PBLKLPPGGDE_ClearL6.Clear();
			CMMHMFIFNLA_PlayL6.Clear();
			GCHPCDLBHKB_ComboL6.Clear();
			LHFMGNBHEIB_RewardClearL6.Clear();
			BMMPNMDNDDM_RewardScoreL6.Clear();
			IGCADAEBODO_RewardComboL6.Clear();
			CGEJAJFJGIN_CbRnkL6.Clear();
			for(int i = 0; i < 5; i++)
			{
				EHDFACFDBNF_Score.Add(FBGGEFFJJHB);
				LMALFDHLAJE_Clear.Add(0);
				GGCFNCFLHMI_Play.Add(0);
				JNEIFCHEFCC_Combo.Add(0);
				BFIJHDIABDA_RewardScore.Add(0);
				BOCKBJAEHKN_RewardCombo.Add(0);
				CCPAMBMMDAO_RewardClear.Add(0);
				NIDCMBMHNJH_CbRnk.Add(0);
				DNBHFDGIJCP_ScoreL6ByDiff.Add(FBGGEFFJJHB);
				PBLKLPPGGDE_ClearL6.Add(0);
				CMMHMFIFNLA_PlayL6.Add(0);
				GCHPCDLBHKB_ComboL6.Add(0);
				BMMPNMDNDDM_RewardScoreL6.Add(0);
				IGCADAEBODO_RewardComboL6.Add(0);
				LHFMGNBHEIB_RewardClearL6.Add(0);
				CGEJAJFJGIN_CbRnkL6.Add(0);
			}
			JDNKJBOIBFI_WDatCrypted = Int64.MaxValue; // 0x7fffffffffffffff
			ABFNAEKEGOB = 0;
			CPBDGAGKNGH_UlNew = true;
			DMANHOPOBMP_IsShowUnlock = false;
			BKJPGJJAODB = null;
			NCDHBLHHMDA = 0;
			FECIGAOOFBE_Wply = 0;
			ODEHJGPDFCL = 0;
			ECLDABOLHLM = 0;
			PDNJGJNGPNJ = 0;
		}

		// // RVA: 0x1C24454 Offset: 0x1C24454 VA: 0x1C24454
		// public EDOHBJAPLPF OCINLMJHJPE() { }

		// // RVA: 0x1C275A8 Offset: 0x1C275A8 VA: 0x1C275A8
		public bool AGBOGBEOFME(EHFMCGGNPIJ_MusicInfo OIKJFMGEICL)
		{
			if(FDMENECIKEL_FreeMusicId != OIKJFMGEICL.FDMENECIKEL_FreeMusicId ||
				EHDFACFDBNF_Score.Count != OIKJFMGEICL.EHDFACFDBNF_Score.Count ||
				LMALFDHLAJE_Clear.Count != OIKJFMGEICL.LMALFDHLAJE_Clear.Count ||
				GGCFNCFLHMI_Play.Count != OIKJFMGEICL.GGCFNCFLHMI_Play.Count ||
				JNEIFCHEFCC_Combo.Count != OIKJFMGEICL.JNEIFCHEFCC_Combo.Count ||
				NIDCMBMHNJH_CbRnk.Count != OIKJFMGEICL.NIDCMBMHNJH_CbRnk.Count ||
				BFIJHDIABDA_RewardScore.Count != OIKJFMGEICL.BFIJHDIABDA_RewardScore.Count ||
				BOCKBJAEHKN_RewardCombo.Count != OIKJFMGEICL.BOCKBJAEHKN_RewardCombo.Count ||
				CCPAMBMMDAO_RewardClear.Count != OIKJFMGEICL.CCPAMBMMDAO_RewardClear.Count ||
				DNBHFDGIJCP_ScoreL6ByDiff.Count != OIKJFMGEICL.DNBHFDGIJCP_ScoreL6ByDiff.Count ||
				PBLKLPPGGDE_ClearL6.Count != OIKJFMGEICL.PBLKLPPGGDE_ClearL6.Count ||
				CMMHMFIFNLA_PlayL6.Count != OIKJFMGEICL.CMMHMFIFNLA_PlayL6.Count ||
				GCHPCDLBHKB_ComboL6.Count != OIKJFMGEICL.GCHPCDLBHKB_ComboL6.Count ||
				CGEJAJFJGIN_CbRnkL6.Count != OIKJFMGEICL.CGEJAJFJGIN_CbRnkL6.Count ||
				BMMPNMDNDDM_RewardScoreL6.Count != OIKJFMGEICL.BMMPNMDNDDM_RewardScoreL6.Count ||
				IGCADAEBODO_RewardComboL6.Count != OIKJFMGEICL.IGCADAEBODO_RewardComboL6.Count ||
				LHFMGNBHEIB_RewardClearL6.Count != OIKJFMGEICL.LHFMGNBHEIB_RewardClearL6.Count ||
				CAPAIICHDMH_WDat != OIKJFMGEICL.CAPAIICHDMH_WDat ||
				FECIGAOOFBE_Wply != OIKJFMGEICL.FECIGAOOFBE_Wply ||
				CPBDGAGKNGH_UlNew != OIKJFMGEICL.CPBDGAGKNGH_UlNew ||
				DMANHOPOBMP_IsShowUnlock != OIKJFMGEICL.DMANHOPOBMP_IsShowUnlock)
				return false;
			for(int i = 0; i < 5; i++)
			{
				if(BDCAICINCKK_GetScoreForDiff(i) != OIKJFMGEICL.BDCAICINCKK_GetScoreForDiff(i) ||
					LMALFDHLAJE_Clear[i] != OIKJFMGEICL.LMALFDHLAJE_Clear[i] ||
					GGCFNCFLHMI_Play[i] != OIKJFMGEICL.GGCFNCFLHMI_Play[i] ||
					JNEIFCHEFCC_Combo[i] != OIKJFMGEICL.JNEIFCHEFCC_Combo[i] ||
					NIDCMBMHNJH_CbRnk[i] != OIKJFMGEICL.NIDCMBMHNJH_CbRnk[i] ||
					BFIJHDIABDA_RewardScore[i] != OIKJFMGEICL.BFIJHDIABDA_RewardScore[i] ||
					BOCKBJAEHKN_RewardCombo[i] != OIKJFMGEICL.BOCKBJAEHKN_RewardCombo[i] ||
					CCPAMBMMDAO_RewardClear[i] != OIKJFMGEICL.CCPAMBMMDAO_RewardClear[i] ||
					AHDKMPFDKPE_GetScoreL6_ForDiff(i) != OIKJFMGEICL.AHDKMPFDKPE_GetScoreL6_ForDiff(i) ||
					PBLKLPPGGDE_ClearL6[i] != OIKJFMGEICL.PBLKLPPGGDE_ClearL6[i] ||
					CMMHMFIFNLA_PlayL6[i] != OIKJFMGEICL.CMMHMFIFNLA_PlayL6[i] ||
					GCHPCDLBHKB_ComboL6[i] != OIKJFMGEICL.GCHPCDLBHKB_ComboL6[i] ||
					CGEJAJFJGIN_CbRnkL6[i] != OIKJFMGEICL.CGEJAJFJGIN_CbRnkL6[i] ||
					BMMPNMDNDDM_RewardScoreL6[i] != OIKJFMGEICL.BMMPNMDNDDM_RewardScoreL6[i] ||
					IGCADAEBODO_RewardComboL6[i] != OIKJFMGEICL.IGCADAEBODO_RewardComboL6[i] ||
					LHFMGNBHEIB_RewardClearL6[i] != OIKJFMGEICL.LHFMGNBHEIB_RewardClearL6[i])
					return false;
			}
			return true;
		}

		// // RVA: 0x1C26B04 Offset: 0x1C26B04 VA: 0x1C26B04
		public void ODDIHGPONFL(EHFMCGGNPIJ_MusicInfo GPBJHKLFCEP)
		{
			FDMENECIKEL_FreeMusicId = GPBJHKLFCEP.FDMENECIKEL_FreeMusicId;
			CAPAIICHDMH_WDat = GPBJHKLFCEP.CAPAIICHDMH_WDat;
			FECIGAOOFBE_Wply = GPBJHKLFCEP.FECIGAOOFBE_Wply;
			IFNDLIGGGHP_HighScoreScore = GPBJHKLFCEP.IFNDLIGGGHP_HighScoreScore;
			NOCLBJAGNHD_HighScoreDiff = GPBJHKLFCEP.NOCLBJAGNHD_HighScoreDiff;
			NLIDBKHMBBD_HighScoreDate = GPBJHKLFCEP.NLIDBKHMBBD_HighScoreDate;
			AOGEGMMBGEN_HighScoreLine6 = GPBJHKLFCEP.AOGEGMMBGEN_HighScoreLine6;
			CPBDGAGKNGH_UlNew = GPBJHKLFCEP.CPBDGAGKNGH_UlNew;
			DMANHOPOBMP_IsShowUnlock = GPBJHKLFCEP.DMANHOPOBMP_IsShowUnlock;
			for(int i = 0; i < 5; i++)
			{
				ECKFCIHPHGJ_SetScore_ForDiff(i, GPBJHKLFCEP.BDCAICINCKK_GetScoreForDiff(i));
				LMALFDHLAJE_Clear[i] = GPBJHKLFCEP.LMALFDHLAJE_Clear[i];
				GGCFNCFLHMI_Play[i] = GPBJHKLFCEP.GGCFNCFLHMI_Play[i];
				JNEIFCHEFCC_Combo[i] = GPBJHKLFCEP.JNEIFCHEFCC_Combo[i];
				NIDCMBMHNJH_CbRnk[i] = GPBJHKLFCEP.NIDCMBMHNJH_CbRnk[i];
				BFIJHDIABDA_RewardScore[i] = GPBJHKLFCEP.BFIJHDIABDA_RewardScore[i];
				BOCKBJAEHKN_RewardCombo[i] = GPBJHKLFCEP.BOCKBJAEHKN_RewardCombo[i];
				CCPAMBMMDAO_RewardClear[i] = GPBJHKLFCEP.CCPAMBMMDAO_RewardClear[i];
				OLNGPNJPAJI = GPBJHKLFCEP.OLNGPNJPAJI;
				AAELOPLDBPF_SetScoreL6_ForDiff(i, GPBJHKLFCEP.AHDKMPFDKPE_GetScoreL6_ForDiff(i));
				PBLKLPPGGDE_ClearL6[i] = GPBJHKLFCEP.PBLKLPPGGDE_ClearL6[i];
				CMMHMFIFNLA_PlayL6[i] = GPBJHKLFCEP.CMMHMFIFNLA_PlayL6[i];
				GCHPCDLBHKB_ComboL6[i] = GPBJHKLFCEP.GCHPCDLBHKB_ComboL6[i];
				CGEJAJFJGIN_CbRnkL6[i] = GPBJHKLFCEP.CGEJAJFJGIN_CbRnkL6[i];
				BMMPNMDNDDM_RewardScoreL6[i] = GPBJHKLFCEP.BMMPNMDNDDM_RewardScoreL6[i];
				IGCADAEBODO_RewardComboL6[i] = GPBJHKLFCEP.IGCADAEBODO_RewardComboL6[i];
				LHFMGNBHEIB_RewardClearL6[i] = GPBJHKLFCEP.LHFMGNBHEIB_RewardClearL6[i];
			}
		}

		// // RVA: 0x1C288EC Offset: 0x1C288EC VA: 0x1C288EC
		// public void AGHKODFKOJI(BHBONAHFKHD JBBHNIACMFJ, string JIKKNHIAEKG, string MJBACHKCIHA, int OIPCCBHIKIA, JDDGGJCGOPA.EHFMCGGNPIJ OHMCIEMIKCE, bool EFOEPDLNLJG) { }

		// // RVA: 0x1C267CC Offset: 0x1C267CC VA: 0x1C267CC
		public void IFGGJEPHIAN()
		{
			NCDHBLHHMDA = 0;
			for(int i = 0; i < LMALFDHLAJE_Clear.Count; i++)
			{
				NCDHBLHHMDA += LMALFDHLAJE_Clear[i];
			}
			for(int i = 0; i < PBLKLPPGGDE_ClearL6.Count; i++)
			{
				NCDHBLHHMDA += PBLKLPPGGDE_ClearL6[i];
			}
		}
	}

	public const int ECFEMKGFDCE = 2;
	public static string POFDDFCGEGP = "_"; // 0x0
	private const int CIEBPOLGCBC = 2000;
	public const int KKBHHBGCNJO = 5;
	public const int ACBHDLAIIMD = 99999;

	public List<EHFMCGGNPIJ_MusicInfo> FAMANJGJANN_FreeMusicInfo { get; private set; } // 0x24 LHMENNHFMJH GHOMEFLHMMH FPFABLHNHFK
	public override bool DMICHEJIAJL { get { TodoLogger.Log(0, "DMICHEJIAJL"); return false; } } // 0x1C2F144 NFKFOODCJJB

	// // RVA: 0x1C238B4 Offset: 0x1C238B4 VA: 0x1C238B4
	// public JDDGGJCGOPA.EHFMCGGNPIJ GCINIJEMHFK(int ADHMMMEOJMK) { }

	// // RVA: 0x1C23978 Offset: 0x1C23978 VA: 0x1C23978
	public JDDGGJCGOPA_RecordMusic()
	{
		FAMANJGJANN_FreeMusicInfo = new List<EHFMCGGNPIJ_MusicInfo>(2000);
		KMBPACJNEOF();
	}

	// // RVA: 0x1C23A1C Offset: 0x1C23A1C VA: 0x1C23A1C Slot: 4
	public override void KMBPACJNEOF()
	{
		FAMANJGJANN_FreeMusicInfo.Clear();
		for(int i = 0; i < 2000; i++)
		{
			JDDGGJCGOPA_RecordMusic.EHFMCGGNPIJ_MusicInfo data = new JDDGGJCGOPA_RecordMusic.EHFMCGGNPIJ_MusicInfo();
			data.FDMENECIKEL_FreeMusicId = i;
			FAMANJGJANN_FreeMusicInfo.Add(data);
		}
	}

	// // RVA: 0x1C23DF4 Offset: 0x1C23DF4 VA: 0x1C23DF4 Slot: 5
	public override void OKJPIBHMKMJ(EDOHBJAPLPF_JsonData OILEIIEIBHP, long MCKEOKFMLAH)
	{
		TodoLogger.Log(0, "OKJPIBHMKMJ");
	}

	// // RVA: 0x1C25884 Offset: 0x1C25884 VA: 0x1C25884 Slot: 6
	public override bool IIEMACPEEBJ_Deserialize(EDOHBJAPLPF_JsonData OILEIIEIBHP)
	{
		bool blockMissing = false;
		bool isInvalid = false;
		EDOHBJAPLPF_JsonData block = LGPBAKLCFHI_FindAndCheckBlock(OILEIIEIBHP, ref blockMissing, ref isInvalid, 2);
		if(!blockMissing)
		{
			if(block == null)
				isInvalid = true;
			else
			{
				var freemusiclist = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.IBPAFKKEKNK_Music.GEAANLPDJBP_FreeMusicDatas;
				for(int i = 0; i < freemusiclist.Count; i++)
				{
					KEODKEGFDLD_FreeMusicInfo musicData = freemusiclist[i];
					string k = POFDDFCGEGP + (i + 1);
					if(OILEIIEIBHP.BBAJPINMOEP_Contains(k))
					{
						EDOHBJAPLPF_JsonData json = OILEIIEIBHP[k];
						EHFMCGGNPIJ_MusicInfo data = FAMANJGJANN_FreeMusicInfo[i];
						data.FDMENECIKEL_FreeMusicId = musicData.GHBPLHBNMBK_FreeMusicId;
						data.CAPAIICHDMH_WDat = DKMPHAPBDLH_ReadLong(json, AFEHLCGHAEE_Strings.EMBKPPHENAN_wdat, 0, ref isInvalid);
						data.FECIGAOOFBE_Wply = CJAENOMGPDA_ReadInt(json, AFEHLCGHAEE_Strings.PNBJCNGCELE_wply, 0, ref isInvalid);
						data.IFNDLIGGGHP_HighScoreScore = CJAENOMGPDA_ReadInt(json, AFEHLCGHAEE_Strings.OJOHFHPAJDI_hsr_sc, 0, ref isInvalid);
						data.NOCLBJAGNHD_HighScoreDiff = CJAENOMGPDA_ReadInt(json, AFEHLCGHAEE_Strings.NLINIIGAEFN_hsr_df, 0, ref isInvalid);
						data.NLIDBKHMBBD_HighScoreDate = DKMPHAPBDLH_ReadLong(json, AFEHLCGHAEE_Strings.NOAKONCNNPO_hsr_dt, 0, ref isInvalid);
						data.AOGEGMMBGEN_HighScoreLine6 = CJAENOMGPDA_ReadInt(json, "hsr_l6", 0, ref isInvalid);
						data.CPBDGAGKNGH_UlNew = CJAENOMGPDA_ReadInt(json, AFEHLCGHAEE_Strings.LFBOCKNGLNK_ul_new, 1, ref isInvalid) != 0;
						data.DMANHOPOBMP_IsShowUnlock = CJAENOMGPDA_ReadInt(json, AFEHLCGHAEE_Strings.BPDOLDOKJGG_is_show_unlock, 0, ref isInvalid) != 0;
						IBCGPBOGOGP_ReadIntArray(json, AFEHLCGHAEE_Strings.KNIFCANOHOC_score, 0, 5, (int OIPCCBHIKIA, int JBGEEPFKIGG) => {
							//0x1C2F20C
							data.ECKFCIHPHGJ_SetScore_ForDiff(OIPCCBHIKIA, JBGEEPFKIGG);
						}, ref isInvalid);
						IBCGPBOGOGP_ReadIntArray(json, AFEHLCGHAEE_Strings.JNLKJCDFFMM_clear, 0, 5, (int OIPCCBHIKIA, int JBGEEPFKIGG) => {
							//0x1C2F2D4
							data.JNLKJCDFFMM_Clear[OIPCCBHIKIA] = JBGEEPFKIGG;
						}, ref isInvalid);
						IBCGPBOGOGP_ReadIntArray(json, AFEHLCGHAEE_Strings.EMHFDJEFIHG_play, 0, 5, (int OIPCCBHIKIA, int JBGEEPFKIGG) => {
							//
							data.EMHFDJEFIHG_Play[OIPCCBHIKIA] = JBGEEPFKIGG;
						}, ref isInvalid);
						IBCGPBOGOGP_ReadIntArray(json, AFEHLCGHAEE_Strings.NLKEBAOBJCM_combo, 0, 5, (int OIPCCBHIKIA, int JBGEEPFKIGG) => {
							//0x1C2F41C
							data.NLKEBAOBJCM_Combo[OIPCCBHIKIA] = JBGEEPFKIGG;
						}, ref isInvalid);
						IBCGPBOGOGP_ReadIntArray(json, AFEHLCGHAEE_Strings.ACBIPLOOEKI_rwd_clr, 0, 5, (int OIPCCBHIKIA, int JBGEEPFKIGG) => {
							//0x1C2F4C0
							data.HNDPLCDMOJF_RewardClear[OIPCCBHIKIA] = (byte)JBGEEPFKIGG;
						}, ref isInvalid);
						IBCGPBOGOGP_ReadIntArray(json, AFEHLCGHAEE_Strings.LKCHLHEOHFF_rwd_sc, 0, 5, (int OIPCCBHIKIA, int JBGEEPFKIGG) => {
							//0x1C2F564
							data.JDIDBMEMKBC_RewardScore[OIPCCBHIKIA] = (byte)JBGEEPFKIGG;
						}, ref isInvalid);
						IBCGPBOGOGP_ReadIntArray(json, AFEHLCGHAEE_Strings.GNHMCCLFBLB_rwd_cb, 0, 5, (int OIPCCBHIKIA, int JBGEEPFKIGG) => {
							//0x1C2F608
							data.AGGFHNMMGMN_RewardCombo[OIPCCBHIKIA] = (byte)JBGEEPFKIGG;
						}, ref isInvalid);
						IBCGPBOGOGP_ReadIntArray(json, AFEHLCGHAEE_Strings.IMEPEOAFIIB_cbrnk, 0, 5, (int OIPCCBHIKIA, int JBGEEPFKIGG) => {
							//
							data.LAMCCNAKIOJ_CbRnk[OIPCCBHIKIA] = (sbyte)JBGEEPFKIGG;
						}, ref isInvalid);
						IBCGPBOGOGP_ReadIntArray(json, "score_l6", 0, 5, (int OIPCCBHIKIA, int JBGEEPFKIGG) => {
							//0x1C2F750
							data.AAELOPLDBPF_SetScoreL6_ForDiff(OIPCCBHIKIA,JBGEEPFKIGG);
						}, ref isInvalid);
						IBCGPBOGOGP_ReadIntArray(json, "clear_l6", 0, 5, (int OIPCCBHIKIA, int JBGEEPFKIGG) => {
							//0x1C2F818
							data.DPPCFFFNBGA_ClearL6[OIPCCBHIKIA] = JBGEEPFKIGG;
						}, ref isInvalid);
						IBCGPBOGOGP_ReadIntArray(json, "play_l6", 0, 5, (int OIPCCBHIKIA, int JBGEEPFKIGG) => {
							//0x1C2F8BC
							data.FHFKOGIPAEH_PlayL6[OIPCCBHIKIA] = JBGEEPFKIGG;
						}, ref isInvalid);
						IBCGPBOGOGP_ReadIntArray(json, "combo_l6", 0, 5, (int OIPCCBHIKIA, int JBGEEPFKIGG) => {
							//0x1C2F960
							data.DNIGPFPHJAK_ComboL6[OIPCCBHIKIA] = JBGEEPFKIGG;
						}, ref isInvalid);
						IBCGPBOGOGP_ReadIntArray(json, "rwd_clr_l6", 0, 5, (int OIPCCBHIKIA, int JBGEEPFKIGG) => {
							//0x1C2FA04
							data.LGBKKDOLOFP_RewardClearL6[OIPCCBHIKIA] = (byte)JBGEEPFKIGG;
						}, ref isInvalid);
						IBCGPBOGOGP_ReadIntArray(json, "rwd_sc_l6", 0, 5, (int OIPCCBHIKIA, int JBGEEPFKIGG) => {
							//0x1C2FAA8
							data.DKIIINIEKHP_RewardScoreL6[OIPCCBHIKIA] = (byte)JBGEEPFKIGG;
						}, ref isInvalid);
						IBCGPBOGOGP_ReadIntArray(json, "rwd_cb_l6", 0, 5, (int OIPCCBHIKIA, int JBGEEPFKIGG) => {
							//0x1C2FB4C
							data.JNNIOJIDNKM_RewardComboL6[OIPCCBHIKIA] = (byte)JBGEEPFKIGG;
						}, ref isInvalid);
						IBCGPBOGOGP_ReadIntArray(json, "cbrnk_l6", 0, 5, (int OIPCCBHIKIA, int JBGEEPFKIGG) => {
							//0x1C2FBF0
							data.EEECMKPLPNL_CbRnkL6[OIPCCBHIKIA] = (sbyte)JBGEEPFKIGG;
						}, ref isInvalid);
						data.IFGGJEPHIAN();
					}
				}
			}
			KFKDMBPNLJK_BlockInvalid = isInvalid;
			return true;
		}

		return false;
	}

	// // RVA: 0x1C26934 Offset: 0x1C26934 VA: 0x1C26934 Slot: 7
	public override void BMGGKONLFIC(KLFDBFMNLBL_ServerSaveBlock GPBJHKLFCEP)
	{
		JDDGGJCGOPA_RecordMusic r = GPBJHKLFCEP as JDDGGJCGOPA_RecordMusic;
		for(int i = 0; i < FAMANJGJANN_FreeMusicInfo.Count; i++)
		{
			FAMANJGJANN_FreeMusicInfo[i].ODDIHGPONFL(r.FAMANJGJANN_FreeMusicInfo[i]);
		}
	}

	// // RVA: 0x1C27360 Offset: 0x1C27360 VA: 0x1C27360 Slot: 8
	public override bool AGBOGBEOFME(KLFDBFMNLBL_ServerSaveBlock GPBJHKLFCEP)
	{
		JDDGGJCGOPA_RecordMusic other = GPBJHKLFCEP as JDDGGJCGOPA_RecordMusic;
		if(FAMANJGJANN_FreeMusicInfo.Count != other.FAMANJGJANN_FreeMusicInfo.Count)
			return false;
		for(int i = 0; i < FAMANJGJANN_FreeMusicInfo.Count; i++)
		{
			if(!FAMANJGJANN_FreeMusicInfo[i].AGBOGBEOFME(other.FAMANJGJANN_FreeMusicInfo[i]))
				return false;
		}
		return true;
	}

	// // RVA: 0x1C284E0 Offset: 0x1C284E0 VA: 0x1C284E0 Slot: 10
	public override void AGHKODFKOJI(BHBONAHFKHD JBBHNIACMFJ, KLFDBFMNLBL_ServerSaveBlock GJLFANGDGCL, long MCKEOKFMLAH)
	{
		TodoLogger.Log(0, "AGHKODFKOJI");
	}

	// // RVA: 0x1C2F14C Offset: 0x1C2F14C VA: 0x1C2F14C
	// public static int IEFAHENNHAH(bool GIKLNODJKFK, int AKNELONELJK, int OIPCCBHIKIA) { }

	// // RVA: 0x1C2F164 Offset: 0x1C2F164 VA: 0x1C2F164
	// public static void NPGCCNCHDLF(int FAENAMBEGMD, out bool GIKLNODJKFK, out int AKNELONELJK, out int OIPCCBHIKIA) { }
}
