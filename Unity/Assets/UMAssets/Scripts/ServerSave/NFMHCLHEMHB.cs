
using System.Collections.Generic;

[System.Obsolete("Use NFMHCLHEMHB_Bingo", true)]
public class NFMHCLHEMHB { }
public class NFMHCLHEMHB_Bingo : KLFDBFMNLBL_ServerSaveBlock
{
	public class CCGKCGJKADC
	{
		public int FBGGEFFJJHB; // 0x8
		public long BBEGLBMOBOF; // 0x10
		private int EHOIENNDEDH; // 0x18
		private long HMDBEHOHPGN; // 0x20
		private long OIPPKODMBFP; // 0x28
		private int COGALGDHDFE; // 0x30
		private int COELGGNMBCB; // 0x34
		public KKAJHLFMBKE AHCFGOGCJKI_St; // 0x38
		public List<OCLGCNPBNHE> AHJNPEAMCCH_Rw; // 0x3C
		public List<long> MIOBPGFAABN; // 0x40

		public int PPFNGGCBJKC_Id { get { return EHOIENNDEDH ^ FBGGEFFJJHB; } set { EHOIENNDEDH = value ^ FBGGEFFJJHB; } } //0x1AEC7E0 DEMEPMAEJOO 0x1AEE5C0 HIGKAIDMOKN
		public long KOOEOKEDJDO_Expr { get { return HMDBEHOHPGN ^ BBEGLBMOBOF; } set { HMDBEHOHPGN = value ^ BBEGLBMOBOF; } } //0x1AEC7F0 BABHKIGIOPO 0x1AEE5D0 PCOFGPBACAM
		public long EBDKHCLCOFL_Ul { get { return OIPPKODMBFP ^ BBEGLBMOBOF; } set { OIPPKODMBFP = value ^ BBEGLBMOBOF; } } //0x1AEC804 OGCBLPKOELF 0x1AEE5F0 HHKIKFCMBEB
		public int JNLKJCDFFMM_Clear { get { return COGALGDHDFE ^ FBGGEFFJJHB; } set { COGALGDHDFE = value ^ FBGGEFFJJHB; } } //0x1AEC81C JLGNODHICKN 0x1AEE604 DLEGLBAGJOI
		public int BJOHOIAKKFM_Bst { get { return COELGGNMBCB ^ FBGGEFFJJHB; } set { COELGGNMBCB = value ^ FBGGEFFJJHB; } } //0x1AEC82C HBIPFAPFKOM 0x1AEE614 GIMACKPNDBH

		//// RVA: 0x1AECABC Offset: 0x1AECABC VA: 0x1AECABC
		//public long MILJGLKJACG(int IOPHIHFOOEP) { }

		//// RVA: 0x1AF0BE0 Offset: 0x1AF0BE0 VA: 0x1AF0BE0
		//public bool IDOLNNPFDDH(int IOPHIHFOOEP, long MIKCFEHGNJB) { }

		// RVA: 0x1AEA708 Offset: 0x1AEA708 VA: 0x1AEA708
		public CCGKCGJKADC()
		{
			FBGGEFFJJHB = LPDNKHAIOLH.CEIBAFOCNCA();
			BBEGLBMOBOF = ~FBGGEFFJJHB;
		}

		//// RVA: 0x1AEA7A4 Offset: 0x1AEA7A4 VA: 0x1AEA7A4
		public void KHEKNNFCAOI(int PPFNGGCBJKC)
		{
			this.PPFNGGCBJKC_Id = PPFNGGCBJKC;
			KOOEOKEDJDO_Expr = 0;
			EBDKHCLCOFL_Ul = 0;
			JNLKJCDFFMM_Clear = 0;
			BJOHOIAKKFM_Bst = 0;
			AHCFGOGCJKI_St = new KKAJHLFMBKE();
			AHCFGOGCJKI_St.KHEKNNFCAOI(0);
			AHJNPEAMCCH_Rw = new List<OCLGCNPBNHE>();
			for(int i = 0; i < 20; i++)
			{
				OCLGCNPBNHE data = new OCLGCNPBNHE();
				data.KHEKNNFCAOI(i + 1);
				AHJNPEAMCCH_Rw.Add(data);
			}
			MIOBPGFAABN = new List<long>();
			for(int i = 0; i < 8; i++)
			{
				MIOBPGFAABN.Add(BBEGLBMOBOF);
			}
		}

		//// RVA: 0x1AF101C Offset: 0x1AF101C VA: 0x1AF101C
		//public void LHPDDGIJKNB() { }

		//// RVA: 0x1AF1024 Offset: 0x1AF1024 VA: 0x1AF1024
		//public bool CHFOOMPEABN() { }

		//// RVA: 0x1AEE974 Offset: 0x1AEE974 VA: 0x1AEE974
		public void ODDIHGPONFL(CCGKCGJKADC GPBJHKLFCEP)
		{
			PPFNGGCBJKC_Id = GPBJHKLFCEP.PPFNGGCBJKC_Id;
			KOOEOKEDJDO_Expr = GPBJHKLFCEP.KOOEOKEDJDO_Expr;
			EBDKHCLCOFL_Ul = GPBJHKLFCEP.EBDKHCLCOFL_Ul;
			JNLKJCDFFMM_Clear = GPBJHKLFCEP.JNLKJCDFFMM_Clear;
			BJOHOIAKKFM_Bst = GPBJHKLFCEP.BJOHOIAKKFM_Bst;
			AHCFGOGCJKI_St.ODDIHGPONFL(GPBJHKLFCEP.AHCFGOGCJKI_St);
		}

		//// RVA: 0x1AEED28 Offset: 0x1AEED28 VA: 0x1AEED28
		//public bool AGBOGBEOFME(NFMHCLHEMHB.CCGKCGJKADC OIKJFMGEICL) { }

		//// RVA: 0x1AEF238 Offset: 0x1AEF238 VA: 0x1AEF238
		//public void AGHKODFKOJI(BHBONAHFKHD JBBHNIACMFJ, string JIKKNHIAEKG, string MJBACHKCIHA, int OIPCCBHIKIA, NFMHCLHEMHB.CCGKCGJKADC OHMCIEMIKCE, bool EFOEPDLNLJG) { }
	}
	
	public class FLLIDKFECHC
	{
		private const int MNHALNODIPI = 99999999;
		public int FBGGEFFJJHB; // 0x8
		public long BBEGLBMOBOF; // 0x10
		public int[] DENIHAKEBCA_VOpC = new int[5]; // 0x18
		public int[] IKJLNHDBGHI_DOpC = new int[10]; // 0x1C
		public int[] NPBIKIMOKME_DOoC = new int[11]; // 0x20
		public int[] MENIJIHIBDC_Dopu = new int[11]; // 0x24
		public int[] FCAHJGHCHAL_Chgc = new int[11]; // 0x28
		public int[] EFEJCLLLEJJ_Gift = new int[11]; // 0x2C
		public int[] LGHCJFCCGFI_MedelShop = new int[9]; // 0x30
		private int PGCLFDKEICG; // 0x34
		private int BGBHLBBAPLP; // 0x38
		private int MBHOFBCAHAA; // 0x3C
		private int OBMDMPKJPPN; // 0x40
		private int IIKHMOBNJIP; // 0x44
		private int BFJMFKNHNDF; // 0x48
		private int PGLEOCMDIHO; // 0x4C
		private int DONIGIGNCEK; // 0x50

		public int BOLCACJFJGG_Shop { get { return PGCLFDKEICG ^ FBGGEFFJJHB; } set { PGCLFDKEICG = value ^ FBGGEFFJJHB; } } //0x1AEC84C MFLNPFGCJEA 0x1AEE684 HIFCFHNDGLM
		public int ODJEADMLGFB_Lgin { get { return BGBHLBBAPLP ^ FBGGEFFJJHB; } set { BGBHLBBAPLP = value ^ FBGGEFFJJHB; } } //0x1AEC85C LMCDMMNEPBB 0x1AEE694 OKLIBJNDABE
		public int FFMHGGHFNPJ_Scene { get { return MBHOFBCAHAA ^ FBGGEFFJJHB; } set { MBHOFBCAHAA = value ^ FBGGEFFJJHB; } } //0x1AEC86C HECFEOHMINM 0x1AEE6A4 LCICCKNOCDH
		public int GNNKOAILFOL_Medal { get { return OBMDMPKJPPN ^ FBGGEFFJJHB; } set { OBMDMPKJPPN = value ^ FBGGEFFJJHB; } } //0x1AEC87C FHEPJDMPLGB 0x1AEE6B4 OCHICNIKHLL
		public int NHPNPIBOHFB_Gacha { get { return IIKHMOBNJIP ^ FBGGEFFJJHB; } set { IIKHMOBNJIP = value ^ FBGGEFFJJHB; } } //0x1AEC88C FILGNOJGLKI 0x1AEE6C4 EGALFOKNCCM
		public int GCEKFPECEAI_DailyMission { get { return BFJMFKNHNDF ^ FBGGEFFJJHB; } set { BFJMFKNHNDF = value ^ FBGGEFFJJHB; } } //0x1AEC89C FPJIMCLMBIA 0x1AEE6D4 HBDLAAGDFOE
		public int HJNEMKGIBGE_EventMission { get { return PGLEOCMDIHO ^ FBGGEFFJJHB; } set { PGLEOCMDIHO = value ^ FBGGEFFJJHB; } } //0x1AEC8AC NLEACKBCHDA 0x1AEE6E4 EDLAINIBICO
		public int AIPKHFKODAH_EventPlay { get { return DONIGIGNCEK ^ FBGGEFFJJHB; } set { DONIGIGNCEK = value ^ FBGGEFFJJHB; } } //0x1AEC8BC JDCFGCHDOJE 0x1AEE6F4 FICCLMGIOLP

		// RVA: 0x1AF15F8 Offset: 0x1AF15F8 VA: 0x1AF15F8
		public FLLIDKFECHC()
		{
			FBGGEFFJJHB = LPDNKHAIOLH.CEIBAFOCNCA();
			BBEGLBMOBOF = ~FBGGEFFJJHB;
		}

		//// RVA: 0x1AF1710 Offset: 0x1AF1710 VA: 0x1AF1710
		public void KHEKNNFCAOI()
		{
			HJNEMKGIBGE_EventMission = 0;
			AIPKHFKODAH_EventPlay = 0;
			BOLCACJFJGG_Shop = 0;
			ODJEADMLGFB_Lgin = 1;
			FFMHGGHFNPJ_Scene = 0;
			GNNKOAILFOL_Medal = 0;
			NHPNPIBOHFB_Gacha = 0;
			GCEKFPECEAI_DailyMission = 0;
			for (int i = 0; i < 5; i++)
			{
				DENIHAKEBCA_VOpC[i] = FBGGEFFJJHB;
			}
			for (int i = 0; i < 10; i++)
			{
				IKJLNHDBGHI_DOpC[i] = FBGGEFFJJHB;
			}
			for (int i = 0; i < 11; i++)
			{
				NPBIKIMOKME_DOoC[i] = FBGGEFFJJHB;
				MENIJIHIBDC_Dopu[i] = FBGGEFFJJHB;
				FCAHJGHCHAL_Chgc[i] = FBGGEFFJJHB;
				EFEJCLLLEJJ_Gift[i] = FBGGEFFJJHB;
			}
			for (int i = 0; i < LGHCJFCCGFI_MedelShop.Length; i++)
			{
				LGHCJFCCGFI_MedelShop[i] = FBGGEFFJJHB;
			}
		}

		//// RVA: 0x1AF1948 Offset: 0x1AF1948 VA: 0x1AF1948
		public void ODDIHGPONFL(FLLIDKFECHC GPBJHKLFCEP)
		{
			BOLCACJFJGG_Shop = GPBJHKLFCEP.BOLCACJFJGG_Shop;
			ODJEADMLGFB_Lgin = GPBJHKLFCEP.ODJEADMLGFB_Lgin;
			FFMHGGHFNPJ_Scene = GPBJHKLFCEP.FFMHGGHFNPJ_Scene;
			GNNKOAILFOL_Medal = GPBJHKLFCEP.GNNKOAILFOL_Medal;
			NHPNPIBOHFB_Gacha = GPBJHKLFCEP.NHPNPIBOHFB_Gacha;
			GCEKFPECEAI_DailyMission = GPBJHKLFCEP.GCEKFPECEAI_DailyMission;
			HJNEMKGIBGE_EventMission = GPBJHKLFCEP.HJNEMKGIBGE_EventMission;
			AIPKHFKODAH_EventPlay = GPBJHKLFCEP.AIPKHFKODAH_EventPlay;
			for(int i = 0; i < 5; i++)
			{
				DENIHAKEBCA_VOpC[i] = GPBJHKLFCEP.DENIHAKEBCA_VOpC[i];
			}
			for(int i = 0; i < 10; i++)
			{
				IKJLNHDBGHI_DOpC[i] = GPBJHKLFCEP.IKJLNHDBGHI_DOpC[i];
			}
			for(int i = 0; i < 11; i++)
			{
				NPBIKIMOKME_DOoC[i] = GPBJHKLFCEP.NPBIKIMOKME_DOoC[i];
				MENIJIHIBDC_Dopu[i] = GPBJHKLFCEP.MENIJIHIBDC_Dopu[i];
				FCAHJGHCHAL_Chgc[i] = GPBJHKLFCEP.FCAHJGHCHAL_Chgc[i];
				EFEJCLLLEJJ_Gift[i] = GPBJHKLFCEP.EFEJCLLLEJJ_Gift[i];
			}
			for(int i = 0; i < LGHCJFCCGFI_MedelShop.Length; i++)
			{
				LGHCJFCCGFI_MedelShop[i] = GPBJHKLFCEP.LGHCJFCCGFI_MedelShop[i];
			}
		}

		//// RVA: 0x1AF1E38 Offset: 0x1AF1E38 VA: 0x1AF1E38
		//public bool AGBOGBEOFME(NFMHCLHEMHB.FLLIDKFECHC OIKJFMGEICL) { }

		//// RVA: 0x1AF22E8 Offset: 0x1AF22E8 VA: 0x1AF22E8
		public void AGNDGJOPIDL_AddShop(int HMFFHLPNMPH)
		{
			int val = BOLCACJFJGG_Shop + HMFFHLPNMPH;
			if (val >= 99999999)
				val = 99999999;
			BOLCACJFJGG_Shop = val;
		}

		//// RVA: 0x1AF2314 Offset: 0x1AF2314 VA: 0x1AF2314
		public void JLKOBAAEDAM_AddLogin(int HMFFHLPNMPH)
		{
			int val = ODJEADMLGFB_Lgin + HMFFHLPNMPH;
			if (val >= 99999999)
				val = 99999999;
			ODJEADMLGFB_Lgin = val;
		}

		//// RVA: 0x1AF2340 Offset: 0x1AF2340 VA: 0x1AF2340
		public void CNEMNJOLIBE_AddScene(int HMFFHLPNMPH)
		{
			int val = FFMHGGHFNPJ_Scene + HMFFHLPNMPH;
			if (val >= 99999999)
				val = 99999999;
			FFMHGGHFNPJ_Scene = val;
		}

		//// RVA: 0x1AF236C Offset: 0x1AF236C VA: 0x1AF236C
		public void EJDEINMOHOP_AddMedal(int HMFFHLPNMPH)
		{
			int val = GNNKOAILFOL_Medal + HMFFHLPNMPH;
			if (val >= 99999999)
				val = 99999999;
			GNNKOAILFOL_Medal = val;
		}

		//// RVA: 0x1AF2398 Offset: 0x1AF2398 VA: 0x1AF2398
		public void BFAJMALBALG_Gacha(int HMFFHLPNMPH)
		{
			int val = NHPNPIBOHFB_Gacha + HMFFHLPNMPH;
			if (val >= 99999999)
				val = 99999999;
			NHPNPIBOHFB_Gacha = val;
		}

		//// RVA: 0x1AF23C4 Offset: 0x1AF23C4 VA: 0x1AF23C4
		public void OAEMBFCMCHL_DailyMission(int HMFFHLPNMPH)
		{
			int val = GCEKFPECEAI_DailyMission + HMFFHLPNMPH;
			if (val >= 99999999)
				val = 99999999;
			GCEKFPECEAI_DailyMission = val;
		}

		//// RVA: 0x1AF23F0 Offset: 0x1AF23F0 VA: 0x1AF23F0
		public void HFOCJMOOMBB_EventMission(int HMFFHLPNMPH)
		{
			int val = HJNEMKGIBGE_EventMission + HMFFHLPNMPH;
			if (val >= 99999999)
				val = 99999999;
			HJNEMKGIBGE_EventMission = val;
		}

		//// RVA: 0x1AF241C Offset: 0x1AF241C VA: 0x1AF241C
		public void PJPHOMJFDEH_EventPlay(int HMFFHLPNMPH)
		{
			int val = AIPKHFKODAH_EventPlay + HMFFHLPNMPH;
			if (val >= 99999999)
				val = 99999999;
			AIPKHFKODAH_EventPlay = val;
		}

		//// RVA: 0x1AF2448 Offset: 0x1AF2448 VA: 0x1AF2448
		public int INMNHOGDFPM_GetArrayValue(ref int[] PILEIPOLBOE, int OIPCCBHIKIA)
		{
			if(OIPCCBHIKIA > -1 && OIPCCBHIKIA < PILEIPOLBOE.Length)
			{
				return PILEIPOLBOE[OIPCCBHIKIA] ^ FBGGEFFJJHB;
			}
			return 0;
		}

		//// RVA: 0x1AF24D0 Offset: 0x1AF24D0 VA: 0x1AF24D0
		public void NMKOFGHHAEA_SetArrayValue(ref int[] PILEIPOLBOE, int OIPCCBHIKIA, int HMFFHLPNMPH)
		{
			if (OIPCCBHIKIA > -1 && OIPCCBHIKIA < PILEIPOLBOE.Length)
			{
				PILEIPOLBOE[OIPCCBHIKIA] = HMFFHLPNMPH ^ FBGGEFFJJHB;
			}
		}

		//// RVA: 0x1AF2554 Offset: 0x1AF2554 VA: 0x1AF2554
		public void HNGEHGDDGAB_AddArrayValue(ref int[] PILEIPOLBOE, int OIPCCBHIKIA, int HMFFHLPNMPH)
		{
			if(OIPCCBHIKIA > -1 && OIPCCBHIKIA < PILEIPOLBOE.Length)
			{
				int val = PILEIPOLBOE[OIPCCBHIKIA] ^ FBGGEFFJJHB + HMFFHLPNMPH;
				if (val > 99999999)
					val = 99999999;
				PILEIPOLBOE[OIPCCBHIKIA] = val ^ FBGGEFFJJHB;
			}
		}

		//// RVA: 0x1AEC8CC Offset: 0x1AEC8CC VA: 0x1AEC8CC
		public int GNHALIDFACE_GetVOpCValue(int FGHGMHPNEMG)
		{
			return INMNHOGDFPM_GetArrayValue(ref DENIHAKEBCA_VOpC, FGHGMHPNEMG);
		}

		//// RVA: 0x1AF094C Offset: 0x1AF094C VA: 0x1AF094C
		//public void NADMCFKICOE(int FGHGMHPNEMG, int HMFFHLPNMPH) { }

		//// RVA: 0x1AF2628 Offset: 0x1AF2628 VA: 0x1AF2628
		public void KKHPAHICACE_AddVOpCValue(int FGHGMHPNEMG, int HMFFHLPNMPH)
		{
			HNGEHGDDGAB_AddArrayValue(ref DENIHAKEBCA_VOpC, FGHGMHPNEMG, HMFFHLPNMPH);
		}

		//// RVA: 0x1AEC8D8 Offset: 0x1AEC8D8 VA: 0x1AEC8D8
		public int EJNFMAAKCMH_GetDOpCValue(int OIPCCBHIKIA)
		{
			return INMNHOGDFPM_GetArrayValue(ref IKJLNHDBGHI_DOpC, OIPCCBHIKIA);
		}

		//// RVA: 0x1AF09B4 Offset: 0x1AF09B4 VA: 0x1AF09B4
		//public void MPEEACOJILJ(int OIPCCBHIKIA, int HMFFHLPNMPH) { }

		//// RVA: 0x1AF264C Offset: 0x1AF264C VA: 0x1AF264C
		public void NKOPNPPGPCD_AddDOpcValue(int OIPCCBHIKIA, int HMFFHLPNMPH)
		{
			HNGEHGDDGAB_AddArrayValue(ref IKJLNHDBGHI_DOpC, OIPCCBHIKIA, HMFFHLPNMPH);
		}

		//// RVA: 0x1AEC8E4 Offset: 0x1AEC8E4 VA: 0x1AEC8E4
		public int MLBJKMLMLEG_GetDOocValue(int OIPCCBHIKIA)
		{
			return INMNHOGDFPM_GetArrayValue(ref NPBIKIMOKME_DOoC, OIPCCBHIKIA);
		}

		//// RVA: 0x1AF0A1C Offset: 0x1AF0A1C VA: 0x1AF0A1C
		//public void NDMPJNBKHPM(int OIPCCBHIKIA, int HMFFHLPNMPH) { }

		//// RVA: 0x1AF2670 Offset: 0x1AF2670 VA: 0x1AF2670
		public void APEIECMCGGH_AddDOoCValue(int OIPCCBHIKIA, int HMFFHLPNMPH)
		{
			HNGEHGDDGAB_AddArrayValue(ref NPBIKIMOKME_DOoC, OIPCCBHIKIA, HMFFHLPNMPH);
		}

		//// RVA: 0x1AEC8F0 Offset: 0x1AEC8F0 VA: 0x1AEC8F0
		public int FGGFDPFMKAF_GetDopuValue(int OIPCCBHIKIA)
		{
			return INMNHOGDFPM_GetArrayValue(ref MENIJIHIBDC_Dopu, OIPCCBHIKIA);
		}

		//// RVA: 0x1AF0A84 Offset: 0x1AF0A84 VA: 0x1AF0A84
		//public void FBJIMCNJPOB(int OIPCCBHIKIA, int HMFFHLPNMPH) { }

		//// RVA: 0x1AF2694 Offset: 0x1AF2694 VA: 0x1AF2694
		public void PDHLABPHFNB_AddDopuValue(int OIPCCBHIKIA, int HMFFHLPNMPH)
		{
			HNGEHGDDGAB_AddArrayValue(ref MENIJIHIBDC_Dopu, OIPCCBHIKIA, HMFFHLPNMPH);
		}

		//// RVA: 0x1AEC8FC Offset: 0x1AEC8FC VA: 0x1AEC8FC
		public int KGFLHCHAIGO_GetChgcValue(int OIPCCBHIKIA)
		{
			return INMNHOGDFPM_GetArrayValue(ref FCAHJGHCHAL_Chgc, OIPCCBHIKIA);
		}

		//// RVA: 0x1AF0AEC Offset: 0x1AF0AEC VA: 0x1AF0AEC
		//public void PODJFPCEDLM(int OIPCCBHIKIA, int HMFFHLPNMPH) { }

		//// RVA: 0x1AF26B8 Offset: 0x1AF26B8 VA: 0x1AF26B8
		public void PCLBKGHNJPN_AddChgcValue(int OIPCCBHIKIA, int HMFFHLPNMPH)
		{
			HNGEHGDDGAB_AddArrayValue(ref FCAHJGHCHAL_Chgc, OIPCCBHIKIA, HMFFHLPNMPH);
		}

		//// RVA: 0x1AEC908 Offset: 0x1AEC908 VA: 0x1AEC908
		public int IKKOANOJHLB_GetGiftValue(int OIPCCBHIKIA)
		{
			return INMNHOGDFPM_GetArrayValue(ref EFEJCLLLEJJ_Gift, OIPCCBHIKIA);
		}

		//// RVA: 0x1AF0B54 Offset: 0x1AF0B54 VA: 0x1AF0B54
		//public void PBEDBGMNGHB(int OIPCCBHIKIA, int HMFFHLPNMPH) { }

		//// RVA: 0x1AF26DC Offset: 0x1AF26DC VA: 0x1AF26DC
		public void CCIDPHJEONL_AddGiftValue(int OIPCCBHIKIA, int HMFFHLPNMPH)
		{
			HNGEHGDDGAB_AddArrayValue(ref EFEJCLLLEJJ_Gift, OIPCCBHIKIA, HMFFHLPNMPH);
		}

		//// RVA: 0x1AEC914 Offset: 0x1AEC914 VA: 0x1AEC914
		public int CDNJPNFGHOG_GetMedalShopValue(int OIPCCBHIKIA)
		{
			return INMNHOGDFPM_GetArrayValue(ref LGHCJFCCGFI_MedelShop, OIPCCBHIKIA);
		}

		//// RVA: 0x1AF0BBC Offset: 0x1AF0BBC VA: 0x1AF0BBC
		//public void CLOMILDLINH(int OIPCCBHIKIA, int HMFFHLPNMPH) { }

		//// RVA: 0x1AF2700 Offset: 0x1AF2700 VA: 0x1AF2700
		public void MPOEJLFDAGJ_AddMedalShopValue(int OIPCCBHIKIA, int HMFFHLPNMPH)
		{
			HNGEHGDDGAB_AddArrayValue(ref LGHCJFCCGFI_MedelShop, OIPCCBHIKIA, HMFFHLPNMPH);
		}
	}

	public class KKAJHLFMBKE
	{
		public int FBGGEFFJJHB; // 0x8
		public long BBEGLBMOBOF; // 0x10
		private int EHOIENNDEDH; // 0x18
		private int FKKHMCINELD; // 0x1C
		private int CGIGOFKGCII; // 0x20
		private int HNJNKCPDKAL; // 0x24
		private int DJENABHDIPP; // 0x28
		public FLLIDKFECHC JJKBBFEJFGO_Cnt; // 0x2C
		public List<HKMBGGGMEKA> HDMADAHNLDN_Ms; // 0x30
		public List<long> OHMBCPHFDLD_Ln; // 0x34

		public int PPFNGGCBJKC_Id { get { return EHOIENNDEDH ^ FBGGEFFJJHB; } set { EHOIENNDEDH = value ^ FBGGEFFJJHB; } } //0x1AEA3DC DEMEPMAEJOO 0x1AEE62C HIGKAIDMOKN
		public int EIHOBHDKCDB_RId { get { return FKKHMCINELD ^ FBGGEFFJJHB; } set { FKKHMCINELD = value ^ FBGGEFFJJHB; } } //0x1AEA40C EALKEGPNHGK 0x1AEE63C LNFEIPOKKNG
		public int AHHJLDLAPAN_Dv { get { return CGIGOFKGCII ^ FBGGEFFJJHB; } set { CGIGOFKGCII = value ^ FBGGEFFJJHB; } } //0x1AEA3EC IPKDLMIDMHH 0x1AEE64C IENNENMKEFO
		public int DAJGPBLEEOB_Mdl { get { return HNJNKCPDKAL ^ FBGGEFFJJHB; } set { HNJNKCPDKAL = value ^ FBGGEFFJJHB; } } //0x1AEA3FC LHPKEPPBKPF 0x1AEE65C OIOEEEDODJA
		public int JBMGFNHBECN_Sst { get { return DJENABHDIPP ^ FBGGEFFJJHB; } set { DJENABHDIPP = value ^ FBGGEFFJJHB; } } //0x1AEC83C IJMJAGAPMCF 0x1AEE66C MKNANLMEHKA

		//// RVA: 0x1AEC984 Offset: 0x1AEC984 VA: 0x1AEC984
		public long CPLKJBCBPNM(int IOPHIHFOOEP)
		{
			if(IOPHIHFOOEP < 0)
				return 0;
			if(OHMBCPHFDLD_Ln.Count <= IOPHIHFOOEP)
				return 0;
			return OHMBCPHFDLD_Ln[IOPHIHFOOEP] ^ BBEGLBMOBOF;
		}

		//// RVA: 0x1AF081C Offset: 0x1AF081C VA: 0x1AF081C
		public bool BMJGIEJPDLM(int IOPHIHFOOEP, long MIKCFEHGNJB)
		{
			if(IOPHIHFOOEP > -1 && IOPHIHFOOEP < OHMBCPHFDLD_Ln.Count)
			{
				OHMBCPHFDLD_Ln[IOPHIHFOOEP] = MIKCFEHGNJB ^ BBEGLBMOBOF;
				return true;
			}
			return false;
		}

		// RVA: 0x1AF0CCC Offset: 0x1AF0CCC VA: 0x1AF0CCC
		public KKAJHLFMBKE()
		{
			FBGGEFFJJHB = LPDNKHAIOLH.CEIBAFOCNCA();
			BBEGLBMOBOF = ~FBGGEFFJJHB;
		}

		//// RVA: 0x1AF0D68 Offset: 0x1AF0D68 VA: 0x1AF0D68
		public void KHEKNNFCAOI(int PPFNGGCBJKC)
		{
			this.PPFNGGCBJKC_Id = PPFNGGCBJKC;
			EIHOBHDKCDB_RId = 0;
			AHHJLDLAPAN_Dv = 0;
			DAJGPBLEEOB_Mdl = 0;
			JBMGFNHBECN_Sst = 0;
			JJKBBFEJFGO_Cnt = new FLLIDKFECHC();
			JJKBBFEJFGO_Cnt.KHEKNNFCAOI();
			HDMADAHNLDN_Ms = new List<HKMBGGGMEKA>(9);
			for(int i = 0; i < 9; i++)
			{
				HKMBGGGMEKA data = new HKMBGGGMEKA();
				data.KHEKNNFCAOI(i + 1);
				HDMADAHNLDN_Ms.Add(data);
			}
			OHMBCPHFDLD_Ln = new List<long>();
			for (int i = 0; i < 7; i++)
			{
				OHMBCPHFDLD_Ln.Add(BBEGLBMOBOF);
			}
		}

		//// RVA: 0x1AF109C Offset: 0x1AF109C VA: 0x1AF109C
		//public bool CHFOOMPEABN() { }

		//// RVA: 0x1AF2A10 Offset: 0x1AF2A10 VA: 0x1AF2A10
		//public bool DFIGPDCBAPB() { }

		//// RVA: 0x1AF10D0 Offset: 0x1AF10D0 VA: 0x1AF10D0
		public void ODDIHGPONFL(KKAJHLFMBKE GPBJHKLFCEP)
		{
			PPFNGGCBJKC_Id = GPBJHKLFCEP.PPFNGGCBJKC_Id;
			EIHOBHDKCDB_RId = GPBJHKLFCEP.EIHOBHDKCDB_RId;
			AHHJLDLAPAN_Dv = GPBJHKLFCEP.AHHJLDLAPAN_Dv;
			DAJGPBLEEOB_Mdl = GPBJHKLFCEP.DAJGPBLEEOB_Mdl;
			JBMGFNHBECN_Sst = GPBJHKLFCEP.JBMGFNHBECN_Sst;
			JJKBBFEJFGO_Cnt.ODDIHGPONFL(GPBJHKLFCEP.JJKBBFEJFGO_Cnt);
			for(int i = 0; i < HDMADAHNLDN_Ms.Count; i++)
			{
				HDMADAHNLDN_Ms[i].ODDIHGPONFL(GPBJHKLFCEP.HDMADAHNLDN_Ms[i]);
			}
			for(int i = 0; i < OHMBCPHFDLD_Ln.Count; i++)
			{
				BMJGIEJPDLM(i, GPBJHKLFCEP.CPLKJBCBPNM(i));
			}
		}

		//// RVA: 0x1AF1378 Offset: 0x1AF1378 VA: 0x1AF1378
		//public bool AGBOGBEOFME(NFMHCLHEMHB.KKAJHLFMBKE OIKJFMGEICL) { }

		//// RVA: 0x1AF2A48 Offset: 0x1AF2A48 VA: 0x1AF2A48
		//public void AGHKODFKOJI(BHBONAHFKHD JBBHNIACMFJ, string JIKKNHIAEKG, string MJBACHKCIHA, int OIPCCBHIKIA, NFMHCLHEMHB.KKAJHLFMBKE OHMCIEMIKCE, bool EFOEPDLNLJG) { }
	}

	public class HKMBGGGMEKA
	{
		public int FBGGEFFJJHB; // 0x8
		public long BBEGLBMOBOF; // 0x10
		private int EHOIENNDEDH; // 0x18
		private int IJLOECFBOAN; // 0x1C
		private int NLBLLLLBHOP; // 0x20
		private int HLMAFFLCCKD; // 0x24
		private long MIOBPGFAABN; // 0x28
		private int MCFFGKAOIHP; // 0x30

		public int PPFNGGCBJKC_Id { get { return EHOIENNDEDH ^ FBGGEFFJJHB; } set { EHOIENNDEDH = value ^ FBGGEFFJJHB; } } //0x1AEC920 DEMEPMAEJOO 0x1AEE704 HIGKAIDMOKN
		public int JOMGCCBFKEF_MId { get { return IJLOECFBOAN ^ FBGGEFFJJHB; } set { IJLOECFBOAN = value ^ FBGGEFFJJHB; } } //0x1AEC930 GGFGMDFOFLG 0x1AEE714 JCJBHJOOIDP
		public int CMCKNKKCNDK_Stat { get { return NLBLLLLBHOP ^ FBGGEFFJJHB; } set { NLBLLLLBHOP = value ^ FBGGEFFJJHB; } } //0x1AEC940 CNKGOPKANGF 0x1AEE724 CHJGGLFGALP
		public int HMFFHLPNMPH_Cnt { get { return HLMAFFLCCKD ^ FBGGEFFJJHB; } set { HLMAFFLCCKD = value ^ FBGGEFFJJHB; } } //0x1AEC950 NJOGDDPICKG 0x1AEE734 NBBGMMBICNA
		public long OPGPHAEMIDO_Dt { get { return MIOBPGFAABN ^ BBEGLBMOBOF; } set { MIOBPGFAABN = value ^ BBEGLBMOBOF; } } //0x1AEC960 HEBGPKBHPIB 0x1AEE744 JMKELOPNAGE
		public int CCKELABMHIO_Ac { get { return MCFFGKAOIHP ^ FBGGEFFJJHB; } set { MCFFGKAOIHP = value ^ FBGGEFFJJHB; } } //0x1AEC974 GGHKPKEGFLM 0x1AEE764 GCDJHHFGLLE

		// RVA: 0x1AF2724 Offset: 0x1AF2724 VA: 0x1AF2724
		public HKMBGGGMEKA()
		{
			FBGGEFFJJHB = LPDNKHAIOLH.CEIBAFOCNCA();
			BBEGLBMOBOF = ~FBGGEFFJJHB;
		}

		//// RVA: 0x1AF27C0 Offset: 0x1AF27C0 VA: 0x1AF27C0
		public void KHEKNNFCAOI(int PPFNGGCBJKC)
		{
			this.PPFNGGCBJKC_Id = PPFNGGCBJKC;
			JOMGCCBFKEF_MId = 0;
			CMCKNKKCNDK_Stat = 0;
			HMFFHLPNMPH_Cnt = 0;
			OPGPHAEMIDO_Dt = 0;
			CCKELABMHIO_Ac = 0;
		}

		//// RVA: 0x1AF27F0 Offset: 0x1AF27F0 VA: 0x1AF27F0
		public void ODDIHGPONFL(HKMBGGGMEKA GPBJHKLFCEP)
		{
			JOMGCCBFKEF_MId = GPBJHKLFCEP.JOMGCCBFKEF_MId;
			CMCKNKKCNDK_Stat = GPBJHKLFCEP.CMCKNKKCNDK_Stat;
			HMFFHLPNMPH_Cnt = GPBJHKLFCEP.HMFFHLPNMPH_Cnt;
			OPGPHAEMIDO_Dt = GPBJHKLFCEP.OPGPHAEMIDO_Dt;
			CCKELABMHIO_Ac = GPBJHKLFCEP.CCKELABMHIO_Ac;
		}

		//// RVA: 0x1AF2924 Offset: 0x1AF2924 VA: 0x1AF2924
		//public bool AGBOGBEOFME(NFMHCLHEMHB.HKMBGGGMEKA OIKJFMGEICL) { }
	}

	public class OCLGCNPBNHE
	{
		public int FBGGEFFJJHB; // 0x8
		public long BBEGLBMOBOF; // 0x10
		private int EHOIENNDEDH; // 0x18
		private long EEDMPMBDGJN; // 0x20

		public int PPFNGGCBJKC_Id { get { return EHOIENNDEDH ^ FBGGEFFJJHB; } set { EHOIENNDEDH = value ^ FBGGEFFJJHB; } } //0x1AECA98 DEMEPMAEJOO 0x1AEE774 HIGKAIDMOKN
		public long MIKCFEHGNJB_Dt { get { return EEDMPMBDGJN ^ BBEGLBMOBOF; } set { EEDMPMBDGJN = value ^ BBEGLBMOBOF; } } //0x1AECAA8 PPCHCNBHAAG 0x1AEE784 DKKLANMGOIF

		// RVA: 0x1AF0F60 Offset: 0x1AF0F60 VA: 0x1AF0F60
		public OCLGCNPBNHE()
		{
			FBGGEFFJJHB = LPDNKHAIOLH.CEIBAFOCNCA();
			BBEGLBMOBOF = ~FBGGEFFJJHB;
		}

		//// RVA: 0x1AF0FFC Offset: 0x1AF0FFC VA: 0x1AF0FFC
		public void KHEKNNFCAOI(int PPFNGGCBJKC)
		{
			this.PPFNGGCBJKC_Id = PPFNGGCBJKC;
			MIKCFEHGNJB_Dt = 0;
		}

		//// RVA: 0x1AECA64 Offset: 0x1AECA64 VA: 0x1AECA64
		//public bool DFIGPDCBAPB() { }
	}

	private const int ECFEMKGFDCE = 2;
	public static string POFDDFCGEGP = "_"; // 0x0

	public List<CCGKCGJKADC> MPCJGPEBCCD { get; private set; } // 0x24 JIFCNLJLCFC IKJFFEHHGBA BBPFBLJNACB
	public override bool DMICHEJIAJL { get { TodoLogger.Log(0, "DMICHEJIAJL"); return false; } } // 0x1AF0698 NFKFOODCJJB

	// // RVA: 0x1AEA1B0 Offset: 0x1AEA1B0 VA: 0x1AEA1B0
	// public NFMHCLHEMHB.CCGKCGJKADC GCINIJEMHFK(int PPFNGGCBJKC) { }

	// // RVA: 0x1AEA23C Offset: 0x1AEA23C VA: 0x1AEA23C
	// public bool DFIGPDCBAPB(int PPFNGGCBJKC) { }

	// // RVA: 0x1AEA41C Offset: 0x1AEA41C VA: 0x1AEA41C
	public CCGKCGJKADC EACEMMDIPFD_GetEmptyBingo()
	{
		return MPCJGPEBCCD.Find((CCGKCGJKADC JPAEDJJFFOI) => {
			//0x1AF0790
			return JPAEDJJFFOI.AHCFGOGCJKI_St.PPFNGGCBJKC_Id == 0;
		});
	}

	// // RVA: 0x1AEA574 Offset: 0x1AEA574 VA: 0x1AEA574
	public NFMHCLHEMHB_Bingo()
	{
		MPCJGPEBCCD = new List<CCGKCGJKADC>(10);
		KMBPACJNEOF();
	}

	// // RVA: 0x1AEA618 Offset: 0x1AEA618 VA: 0x1AEA618 Slot: 4
	public override void KMBPACJNEOF()
	{
		MPCJGPEBCCD.Clear();
		for(int i = 0; i < 10; i++)
		{
			CCGKCGJKADC data = new CCGKCGJKADC();
			data.KHEKNNFCAOI(i + 1);
			MPCJGPEBCCD.Add(data);
		}
	}

	// // RVA: 0x1AEA9A4 Offset: 0x1AEA9A4 VA: 0x1AEA9A4 Slot: 5
	public override void OKJPIBHMKMJ(EDOHBJAPLPF_JsonData OILEIIEIBHP, long MCKEOKFMLAH)
	{
		TodoLogger.Log(0, "OKJPIBHMKMJ");
	}

	// // RVA: 0x1AECB9C Offset: 0x1AECB9C VA: 0x1AECB9C Slot: 6
	public override bool IIEMACPEEBJ_Deserialize(EDOHBJAPLPF_JsonData OILEIIEIBHP)
	{
		bool blockMissing = false;
		bool isInvalid = false;
		EDOHBJAPLPF_JsonData block = LGPBAKLCFHI_FindAndCheckBlock(OILEIIEIBHP, ref blockMissing, ref isInvalid, 2);
		if (!blockMissing)
		{
			if (block == null)
			{
				isInvalid = true;
			}
			else
			{
				for(int i = 0; i < 10; i++)
				{
					string str = POFDDFCGEGP + (i + 1).ToString();
					if(block.BBAJPINMOEP_Contains(str))
					{
						EDOHBJAPLPF_JsonData b = block[str];
						CCGKCGJKADC data = MPCJGPEBCCD[i];
						data.PPFNGGCBJKC_Id = i + 1;
						data.KOOEOKEDJDO_Expr = DKMPHAPBDLH_ReadLong(b, AFEHLCGHAEE_Strings.KOOEOKEDJDO_expr, 0, ref isInvalid);
						data.EBDKHCLCOFL_Ul = DKMPHAPBDLH_ReadLong(b, AFEHLCGHAEE_Strings.FGKGELOJBJK_ul, 0, ref isInvalid);
						data.JNLKJCDFFMM_Clear = CJAENOMGPDA_ReadInt(b, AFEHLCGHAEE_Strings.JNLKJCDFFMM_clear, 0, ref isInvalid);
						data.BJOHOIAKKFM_Bst = CJAENOMGPDA_ReadInt(b, "bst", 0, ref isInvalid);
						if(b.BBAJPINMOEP_Contains(AFEHLCGHAEE_Strings.FNEIADJMHHO_st))
						{
							EDOHBJAPLPF_JsonData b2 = b[AFEHLCGHAEE_Strings.FNEIADJMHHO_st];
							data.AHCFGOGCJKI_St.PPFNGGCBJKC_Id = CJAENOMGPDA_ReadInt(b2, AFEHLCGHAEE_Strings.PPFNGGCBJKC_Id, 0, ref isInvalid);
							data.AHCFGOGCJKI_St.EIHOBHDKCDB_RId = CJAENOMGPDA_ReadInt(b2, AFEHLCGHAEE_Strings.INJIPPBFMIG_r_id, 0, ref isInvalid);
							data.AHCFGOGCJKI_St.AHHJLDLAPAN_Dv = CJAENOMGPDA_ReadInt(b2, AFEHLCGHAEE_Strings.OCAMDLMPBGA_dv, 0, ref isInvalid);
							data.AHCFGOGCJKI_St.DAJGPBLEEOB_Mdl = CJAENOMGPDA_ReadInt(b2, AFEHLCGHAEE_Strings.FLNJLKKAFPB_mdl, 0, ref isInvalid);
							data.AHCFGOGCJKI_St.JBMGFNHBECN_Sst = CJAENOMGPDA_ReadInt(b2, "sst", 0, ref isInvalid);
							if(b2.BBAJPINMOEP_Contains(AFEHLCGHAEE_Strings.BFINGCJHOHI_cnt))
							{
								EDOHBJAPLPF_JsonData b3 = b2[AFEHLCGHAEE_Strings.BFINGCJHOHI_cnt];
								data.AHCFGOGCJKI_St.JJKBBFEJFGO_Cnt.BOLCACJFJGG_Shop = CJAENOMGPDA_ReadInt(b3, "shop", 0, ref isInvalid);
								data.AHCFGOGCJKI_St.JJKBBFEJFGO_Cnt.ODJEADMLGFB_Lgin = CJAENOMGPDA_ReadInt(b3, "lgin", 1, ref isInvalid);
								data.AHCFGOGCJKI_St.JJKBBFEJFGO_Cnt.FFMHGGHFNPJ_Scene = CJAENOMGPDA_ReadInt(b3, "scene", 0, ref isInvalid);
								data.AHCFGOGCJKI_St.JJKBBFEJFGO_Cnt.GNNKOAILFOL_Medal = CJAENOMGPDA_ReadInt(b3, "medal", 0, ref isInvalid);
								data.AHCFGOGCJKI_St.JJKBBFEJFGO_Cnt.NHPNPIBOHFB_Gacha = CJAENOMGPDA_ReadInt(b3, "gacha", 0, ref isInvalid);
								data.AHCFGOGCJKI_St.JJKBBFEJFGO_Cnt.GCEKFPECEAI_DailyMission = CJAENOMGPDA_ReadInt(b3, "deliy_mission", 0, ref isInvalid);
								data.AHCFGOGCJKI_St.JJKBBFEJFGO_Cnt.HJNEMKGIBGE_EventMission = CJAENOMGPDA_ReadInt(b3, "event_mission", 0, ref isInvalid);
								data.AHCFGOGCJKI_St.JJKBBFEJFGO_Cnt.AIPKHFKODAH_EventPlay = CJAENOMGPDA_ReadInt(b3, "event_play", 0, ref isInvalid);
								IBCGPBOGOGP_ReadIntArray(b3, "vopc", 0, data.AHCFGOGCJKI_St.JJKBBFEJFGO_Cnt.DENIHAKEBCA_VOpC.Length, (int OIPCCBHIKIA, int JBGEEPFKIGG) =>
								{
									//0x1AF0908
									data.AHCFGOGCJKI_St.JJKBBFEJFGO_Cnt.NMKOFGHHAEA_SetArrayValue(ref data.AHCFGOGCJKI_St.JJKBBFEJFGO_Cnt.DENIHAKEBCA_VOpC, OIPCCBHIKIA, JBGEEPFKIGG);
								}, ref isInvalid);
								IBCGPBOGOGP_ReadIntArray(b3, "dopc", 0, data.AHCFGOGCJKI_St.JJKBBFEJFGO_Cnt.IKJLNHDBGHI_DOpC.Length, (int OIPCCBHIKIA, int JBGEEPFKIGG) =>
								{
									//0x1AF0970
									data.AHCFGOGCJKI_St.JJKBBFEJFGO_Cnt.NMKOFGHHAEA_SetArrayValue(ref data.AHCFGOGCJKI_St.JJKBBFEJFGO_Cnt.IKJLNHDBGHI_DOpC, OIPCCBHIKIA, JBGEEPFKIGG);
								}, ref isInvalid);
								IBCGPBOGOGP_ReadIntArray(b3, "dooc", 0, data.AHCFGOGCJKI_St.JJKBBFEJFGO_Cnt.NPBIKIMOKME_DOoC.Length, (int OIPCCBHIKIA, int JBGEEPFKIGG) =>
								{
									//0x1AF09D8
									data.AHCFGOGCJKI_St.JJKBBFEJFGO_Cnt.NMKOFGHHAEA_SetArrayValue(ref data.AHCFGOGCJKI_St.JJKBBFEJFGO_Cnt.NPBIKIMOKME_DOoC, OIPCCBHIKIA, JBGEEPFKIGG);
								}, ref isInvalid);
								IBCGPBOGOGP_ReadIntArray(b3, "dopu", 0, data.AHCFGOGCJKI_St.JJKBBFEJFGO_Cnt.MENIJIHIBDC_Dopu.Length, (int OIPCCBHIKIA, int JBGEEPFKIGG) =>
								{
									//0x1AF0A40
									data.AHCFGOGCJKI_St.JJKBBFEJFGO_Cnt.NMKOFGHHAEA_SetArrayValue(ref data.AHCFGOGCJKI_St.JJKBBFEJFGO_Cnt.MENIJIHIBDC_Dopu, OIPCCBHIKIA, JBGEEPFKIGG);
								}, ref isInvalid);
								IBCGPBOGOGP_ReadIntArray(b3, "chgc", 0, data.AHCFGOGCJKI_St.JJKBBFEJFGO_Cnt.FCAHJGHCHAL_Chgc.Length, (int OIPCCBHIKIA, int JBGEEPFKIGG) =>
								{
									//0x1AF0AA8
									data.AHCFGOGCJKI_St.JJKBBFEJFGO_Cnt.NMKOFGHHAEA_SetArrayValue(ref data.AHCFGOGCJKI_St.JJKBBFEJFGO_Cnt.FCAHJGHCHAL_Chgc, OIPCCBHIKIA, JBGEEPFKIGG);
								}, ref isInvalid);
								IBCGPBOGOGP_ReadIntArray(b3, "gift", 0, data.AHCFGOGCJKI_St.JJKBBFEJFGO_Cnt.EFEJCLLLEJJ_Gift.Length, (int OIPCCBHIKIA, int JBGEEPFKIGG) =>
								{
									//0x1AF0B10
									data.AHCFGOGCJKI_St.JJKBBFEJFGO_Cnt.NMKOFGHHAEA_SetArrayValue(ref data.AHCFGOGCJKI_St.JJKBBFEJFGO_Cnt.EFEJCLLLEJJ_Gift, OIPCCBHIKIA, JBGEEPFKIGG);
								}, ref isInvalid);
								IBCGPBOGOGP_ReadIntArray(b3, "medel_shop", 0, data.AHCFGOGCJKI_St.JJKBBFEJFGO_Cnt.LGHCJFCCGFI_MedelShop.Length, (int OIPCCBHIKIA, int JBGEEPFKIGG) =>
								{
									//0x1AF0B78
									data.AHCFGOGCJKI_St.JJKBBFEJFGO_Cnt.NMKOFGHHAEA_SetArrayValue(ref data.AHCFGOGCJKI_St.JJKBBFEJFGO_Cnt.LGHCJFCCGFI_MedelShop, OIPCCBHIKIA, JBGEEPFKIGG);
								}, ref isInvalid);
							}
							if (b2.BBAJPINMOEP_Contains(AFEHLCGHAEE_Strings.COGJONKKALB_ms))
							{
								EDOHBJAPLPF_JsonData b3 = b2[AFEHLCGHAEE_Strings.COGJONKKALB_ms];
								int cnt = b3.HNBFOAJIIAL_Count;
								if (data.AHCFGOGCJKI_St.HDMADAHNLDN_Ms.Count < cnt)
								{
									cnt = data.AHCFGOGCJKI_St.HDMADAHNLDN_Ms.Count;
								}
								for(int j = 0; j < cnt; j++)
								{
									HKMBGGGMEKA data2 = data.AHCFGOGCJKI_St.HDMADAHNLDN_Ms[j];
									EDOHBJAPLPF_JsonData b4 = b3[j];
									data2.PPFNGGCBJKC_Id = CJAENOMGPDA_ReadInt(b4, AFEHLCGHAEE_Strings.PPFNGGCBJKC_Id, 0, ref isInvalid);
									data2.JOMGCCBFKEF_MId = CJAENOMGPDA_ReadInt(b4, AFEHLCGHAEE_Strings.KLMIFEKNBLL_m_id, 0, ref isInvalid);
									data2.CMCKNKKCNDK_Stat = CJAENOMGPDA_ReadInt(b4, AFEHLCGHAEE_Strings.EALOBDHOCHP_stat, 0, ref isInvalid);
									data2.HMFFHLPNMPH_Cnt = CJAENOMGPDA_ReadInt(b4, AFEHLCGHAEE_Strings.BFINGCJHOHI_cnt, 0, ref isInvalid);
									data2.OPGPHAEMIDO_Dt = DKMPHAPBDLH_ReadLong(b4, AFEHLCGHAEE_Strings.MIKCFEHGNJB_dt, 0, ref isInvalid);
									data2.CCKELABMHIO_Ac = CJAENOMGPDA_ReadInt(b4, AFEHLCGHAEE_Strings.ONOPACPKFPK_ac, 0, ref isInvalid);
								}
							}
							if(b2.BBAJPINMOEP_Contains(AFEHLCGHAEE_Strings.NMHGCOLMPJA_ln))
							{
								IBCGPBOGOGP_ReadIntArray(b2, AFEHLCGHAEE_Strings.NMHGCOLMPJA_ln, 0, 8, (int OIPCCBHIKIA, int JBGEEPFKIGG) =>
								{
									//0x1AF07D8
									data.AHCFGOGCJKI_St.BMJGIEJPDLM(OIPCCBHIKIA, JBGEEPFKIGG);
								}, ref isInvalid);
							}
						}
						if(b.BBAJPINMOEP_Contains(AFEHLCGHAEE_Strings.JGOHPDKCJKB_rw))
						{
							EDOHBJAPLPF_JsonData b2 = b[AFEHLCGHAEE_Strings.JGOHPDKCJKB_rw];
							int cnt = b2.HNBFOAJIIAL_Count;
							if(data.AHJNPEAMCCH_Rw.Count < cnt)
							{
								cnt = data.AHJNPEAMCCH_Rw.Count;
							}
							for(int j = 0; j < cnt; j++)
							{
								OCLGCNPBNHE data2 = data.AHJNPEAMCCH_Rw[j];
								EDOHBJAPLPF_JsonData b3 = b2[j];
								data2.PPFNGGCBJKC_Id = CJAENOMGPDA_ReadInt(b3, AFEHLCGHAEE_Strings.PPFNGGCBJKC_Id, 0, ref isInvalid);
								data2.MIKCFEHGNJB_Dt = DKMPHAPBDLH_ReadLong(b3, AFEHLCGHAEE_Strings.MIKCFEHGNJB_dt, 0, ref isInvalid);
							}
						}
					}
				}
			}
			KFKDMBPNLJK_BlockInvalid = isInvalid;
			return true;
		}
		return false;
	}

	// // RVA: 0x1AEE7A4 Offset: 0x1AEE7A4 VA: 0x1AEE7A4 Slot: 7
	public override void BMGGKONLFIC(KLFDBFMNLBL_ServerSaveBlock GPBJHKLFCEP)
	{
		NFMHCLHEMHB_Bingo b = GPBJHKLFCEP as NFMHCLHEMHB_Bingo;
		for(int i = 0; i < MPCJGPEBCCD.Count; i++)
		{
			MPCJGPEBCCD[i].ODDIHGPONFL(b.MPCJGPEBCCD[i]);
		}
	}

	// // RVA: 0x1AEEAE0 Offset: 0x1AEEAE0 VA: 0x1AEEAE0 Slot: 8
	public override bool AGBOGBEOFME(KLFDBFMNLBL_ServerSaveBlock GPBJHKLFCEP)
	{
		TodoLogger.Log(0, "AGBOGBEOFME");
		return true;
	}

	// // RVA: 0x1AEEE2C Offset: 0x1AEEE2C VA: 0x1AEEE2C Slot: 10
	public override void AGHKODFKOJI(BHBONAHFKHD JBBHNIACMFJ, KLFDBFMNLBL_ServerSaveBlock GJLFANGDGCL, long MCKEOKFMLAH)
	{
		TodoLogger.Log(0, "AGHKODFKOJI");
	}
}
