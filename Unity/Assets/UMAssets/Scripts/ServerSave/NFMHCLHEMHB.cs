
using System.Collections.Generic;

[System.Obsolete("Use NFMHCLHEMHB_Bingo", true)]
public class NFMHCLHEMHB { }
public class NFMHCLHEMHB_Bingo : KLFDBFMNLBL_ServerSaveBlock
{
	public class CCGKCGJKADC
	{
		public int FBGGEFFJJHB_xor; // 0x8
		public long BBEGLBMOBOF_xorl; // 0x10
		private int EHOIENNDEDH_IdCrypted; // 0x18
		private long HMDBEHOHPGN; // 0x20
		private long OIPPKODMBFP; // 0x28
		private int COGALGDHDFE_ClearCrypted; // 0x30
		private int COELGGNMBCB; // 0x34
		public KKAJHLFMBKE AHCFGOGCJKI_St; // 0x38
		public List<OCLGCNPBNHE> AHJNPEAMCCH_rewards; // 0x3C
		public List<long> MIOBPGFAABN; // 0x40

		public int PPFNGGCBJKC_id { get { return EHOIENNDEDH_IdCrypted ^ FBGGEFFJJHB_xor; } set { EHOIENNDEDH_IdCrypted = value ^ FBGGEFFJJHB_xor; } } //0x1AEC7E0 DEMEPMAEJOO 0x1AEE5C0 HIGKAIDMOKN
		public long KOOEOKEDJDO_expr { get { return HMDBEHOHPGN ^ BBEGLBMOBOF_xorl; } set { HMDBEHOHPGN = value ^ BBEGLBMOBOF_xorl; } } //0x1AEC7F0 BABHKIGIOPO 0x1AEE5D0 PCOFGPBACAM
		public long EBDKHCLCOFL_Ul { get { return OIPPKODMBFP ^ BBEGLBMOBOF_xorl; } set { OIPPKODMBFP = value ^ BBEGLBMOBOF_xorl; } } //0x1AEC804 OGCBLPKOELF 0x1AEE5F0 HHKIKFCMBEB
		public int JNLKJCDFFMM_clear { get { return COGALGDHDFE_ClearCrypted ^ FBGGEFFJJHB_xor; } set { COGALGDHDFE_ClearCrypted = value ^ FBGGEFFJJHB_xor; } } //0x1AEC81C JLGNODHICKN 0x1AEE604 DLEGLBAGJOI
		public int BJOHOIAKKFM_Bst { get { return COELGGNMBCB ^ FBGGEFFJJHB_xor; } set { COELGGNMBCB = value ^ FBGGEFFJJHB_xor; } } //0x1AEC82C HBIPFAPFKOM 0x1AEE614 GIMACKPNDBH

		//// RVA: 0x1AECABC Offset: 0x1AECABC VA: 0x1AECABC
		public long MILJGLKJACG(int IOPHIHFOOEP)
		{
			if (IOPHIHFOOEP < 0)
				return 0;
			if (MIOBPGFAABN.Count <= IOPHIHFOOEP)
				return 0;
			return MIOBPGFAABN[IOPHIHFOOEP] ^ BBEGLBMOBOF_xorl;
		}

		//// RVA: 0x1AF0BE0 Offset: 0x1AF0BE0 VA: 0x1AF0BE0
		//public bool IDOLNNPFDDH(int IOPHIHFOOEP, long _MIKCFEHGNJB_dt) { }

		// RVA: 0x1AEA708 Offset: 0x1AEA708 VA: 0x1AEA708
		public CCGKCGJKADC()
		{
			FBGGEFFJJHB_xor = LPDNKHAIOLH.CEIBAFOCNCA();
			BBEGLBMOBOF_xorl = ~FBGGEFFJJHB_xor;
		}

		//// RVA: 0x1AEA7A4 Offset: 0x1AEA7A4 VA: 0x1AEA7A4
		public void KHEKNNFCAOI_Init(int _PPFNGGCBJKC_id)
		{
			this.PPFNGGCBJKC_id = _PPFNGGCBJKC_id;
			KOOEOKEDJDO_expr = 0;
			EBDKHCLCOFL_Ul = 0;
			JNLKJCDFFMM_clear = 0;
			BJOHOIAKKFM_Bst = 0;
			AHCFGOGCJKI_St = new KKAJHLFMBKE();
			AHCFGOGCJKI_St.KHEKNNFCAOI_Init(0);
			AHJNPEAMCCH_rewards = new List<OCLGCNPBNHE>();
			for(int i = 0; i < 20; i++)
			{
				OCLGCNPBNHE data = new OCLGCNPBNHE();
				data.KHEKNNFCAOI_Init(i + 1);
				AHJNPEAMCCH_rewards.Add(data);
			}
			MIOBPGFAABN = new List<long>();
			for(int i = 0; i < 8; i++)
			{
				MIOBPGFAABN.Add(BBEGLBMOBOF_xorl);
			}
		}

		//// RVA: 0x1AF101C Offset: 0x1AF101C VA: 0x1AF101C
		//public void LHPDDGIJKNB_Reset() { }

		//// RVA: 0x1AF1024 Offset: 0x1AF1024 VA: 0x1AF1024
		//public bool CHFOOMPEABN() { }

		//// RVA: 0x1AEE974 Offset: 0x1AEE974 VA: 0x1AEE974
		public void ODDIHGPONFL_Copy(CCGKCGJKADC GPBJHKLFCEP)
		{
			PPFNGGCBJKC_id = GPBJHKLFCEP.PPFNGGCBJKC_id;
			KOOEOKEDJDO_expr = GPBJHKLFCEP.KOOEOKEDJDO_expr;
			EBDKHCLCOFL_Ul = GPBJHKLFCEP.EBDKHCLCOFL_Ul;
			JNLKJCDFFMM_clear = GPBJHKLFCEP.JNLKJCDFFMM_clear;
			BJOHOIAKKFM_Bst = GPBJHKLFCEP.BJOHOIAKKFM_Bst;
			AHCFGOGCJKI_St.ODDIHGPONFL_Copy(GPBJHKLFCEP.AHCFGOGCJKI_St);
		}

		//// RVA: 0x1AEED28 Offset: 0x1AEED28 VA: 0x1AEED28
		public bool AGBOGBEOFME(CCGKCGJKADC OIKJFMGEICL)
		{
			if(PPFNGGCBJKC_id != OIKJFMGEICL.PPFNGGCBJKC_id ||
				KOOEOKEDJDO_expr != OIKJFMGEICL.KOOEOKEDJDO_expr ||
				EBDKHCLCOFL_Ul != OIKJFMGEICL.EBDKHCLCOFL_Ul ||
				JNLKJCDFFMM_clear != OIKJFMGEICL.JNLKJCDFFMM_clear ||
				BJOHOIAKKFM_Bst != OIKJFMGEICL.BJOHOIAKKFM_Bst ||
				!AHCFGOGCJKI_St.AGBOGBEOFME(OIKJFMGEICL.AHCFGOGCJKI_St))
				return false;
			return true;
		}

		//// RVA: 0x1AEF238 Offset: 0x1AEF238 VA: 0x1AEF238
		//public void AGHKODFKOJI(BHBONAHFKHD JBBHNIACMFJ, string JIKKNHIAEKG, string MJBACHKCIHA, int _OIPCCBHIKIA_index, NFMHCLHEMHB_Bingo.CCGKCGJKADC _OHMCIEMIKCE_t, bool EFOEPDLNLJG) { }
	}
	
	public class FLLIDKFECHC
	{
		private const int MNHALNODIPI = 99999999;
		public int FBGGEFFJJHB_xor; // 0x8
		public long BBEGLBMOBOF_xorl; // 0x10
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

		public int BOLCACJFJGG_Shop { get { return PGCLFDKEICG ^ FBGGEFFJJHB_xor; } set { PGCLFDKEICG = value ^ FBGGEFFJJHB_xor; } } //0x1AEC84C MFLNPFGCJEA 0x1AEE684 HIFCFHNDGLM
		public int ODJEADMLGFB_Lgin { get { return BGBHLBBAPLP ^ FBGGEFFJJHB_xor; } set { BGBHLBBAPLP = value ^ FBGGEFFJJHB_xor; } } //0x1AEC85C LMCDMMNEPBB 0x1AEE694 OKLIBJNDABE
		public int FFMHGGHFNPJ_Scene { get { return MBHOFBCAHAA ^ FBGGEFFJJHB_xor; } set { MBHOFBCAHAA = value ^ FBGGEFFJJHB_xor; } } //0x1AEC86C HECFEOHMINM 0x1AEE6A4 LCICCKNOCDH
		public int GNNKOAILFOL_Medal { get { return OBMDMPKJPPN ^ FBGGEFFJJHB_xor; } set { OBMDMPKJPPN = value ^ FBGGEFFJJHB_xor; } } //0x1AEC87C FHEPJDMPLGB 0x1AEE6B4 OCHICNIKHLL
		public int NHPNPIBOHFB_Gacha { get { return IIKHMOBNJIP ^ FBGGEFFJJHB_xor; } set { IIKHMOBNJIP = value ^ FBGGEFFJJHB_xor; } } //0x1AEC88C FILGNOJGLKI 0x1AEE6C4 EGALFOKNCCM
		public int GCEKFPECEAI_DailyMission { get { return BFJMFKNHNDF ^ FBGGEFFJJHB_xor; } set { BFJMFKNHNDF = value ^ FBGGEFFJJHB_xor; } } //0x1AEC89C FPJIMCLMBIA 0x1AEE6D4 HBDLAAGDFOE
		public int HJNEMKGIBGE_EventMission { get { return PGLEOCMDIHO ^ FBGGEFFJJHB_xor; } set { PGLEOCMDIHO = value ^ FBGGEFFJJHB_xor; } } //0x1AEC8AC NLEACKBCHDA 0x1AEE6E4 EDLAINIBICO
		public int AIPKHFKODAH_EventPlay { get { return DONIGIGNCEK ^ FBGGEFFJJHB_xor; } set { DONIGIGNCEK = value ^ FBGGEFFJJHB_xor; } } //0x1AEC8BC JDCFGCHDOJE 0x1AEE6F4 FICCLMGIOLP

		// RVA: 0x1AF15F8 Offset: 0x1AF15F8 VA: 0x1AF15F8
		public FLLIDKFECHC()
		{
			FBGGEFFJJHB_xor = LPDNKHAIOLH.CEIBAFOCNCA();
			BBEGLBMOBOF_xorl = ~FBGGEFFJJHB_xor;
		}

		//// RVA: 0x1AF1710 Offset: 0x1AF1710 VA: 0x1AF1710
		public void KHEKNNFCAOI_Init()
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
				DENIHAKEBCA_VOpC[i] = FBGGEFFJJHB_xor;
			}
			for (int i = 0; i < 10; i++)
			{
				IKJLNHDBGHI_DOpC[i] = FBGGEFFJJHB_xor;
			}
			for (int i = 0; i < 11; i++)
			{
				NPBIKIMOKME_DOoC[i] = FBGGEFFJJHB_xor;
				MENIJIHIBDC_Dopu[i] = FBGGEFFJJHB_xor;
				FCAHJGHCHAL_Chgc[i] = FBGGEFFJJHB_xor;
				EFEJCLLLEJJ_Gift[i] = FBGGEFFJJHB_xor;
			}
			for (int i = 0; i < LGHCJFCCGFI_MedelShop.Length; i++)
			{
				LGHCJFCCGFI_MedelShop[i] = FBGGEFFJJHB_xor;
			}
		}

		//// RVA: 0x1AF1948 Offset: 0x1AF1948 VA: 0x1AF1948
		public void ODDIHGPONFL_Copy(FLLIDKFECHC GPBJHKLFCEP)
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
		public bool AGBOGBEOFME(FLLIDKFECHC OIKJFMGEICL)
		{
			if(BOLCACJFJGG_Shop != OIKJFMGEICL.BOLCACJFJGG_Shop ||
				ODJEADMLGFB_Lgin != OIKJFMGEICL.ODJEADMLGFB_Lgin ||
				FFMHGGHFNPJ_Scene != OIKJFMGEICL.FFMHGGHFNPJ_Scene ||
				GNNKOAILFOL_Medal != OIKJFMGEICL.GNNKOAILFOL_Medal ||
				NHPNPIBOHFB_Gacha != OIKJFMGEICL.NHPNPIBOHFB_Gacha ||
				GCEKFPECEAI_DailyMission != OIKJFMGEICL.GCEKFPECEAI_DailyMission ||
				HJNEMKGIBGE_EventMission != OIKJFMGEICL.HJNEMKGIBGE_EventMission ||
				AIPKHFKODAH_EventPlay != OIKJFMGEICL.AIPKHFKODAH_EventPlay)
				return false;
			for(int i = 0; i < 5; i++)
			{
				if(DENIHAKEBCA_VOpC[i] != OIKJFMGEICL.DENIHAKEBCA_VOpC[i])
					return false;
			}
			for(int i = 0; i < 10; i++)
			{
				if(IKJLNHDBGHI_DOpC[i] != OIKJFMGEICL.IKJLNHDBGHI_DOpC[i])
					return false;
			}
			for(int i = 0; i < 11; i++)
			{
				if(NPBIKIMOKME_DOoC[i] != OIKJFMGEICL.NPBIKIMOKME_DOoC[i])
					return false;
				if(MENIJIHIBDC_Dopu[i] != OIKJFMGEICL.MENIJIHIBDC_Dopu[i])
					return false;
				if(FCAHJGHCHAL_Chgc[i] != OIKJFMGEICL.FCAHJGHCHAL_Chgc[i])
					return false;
				if(EFEJCLLLEJJ_Gift[i] != OIKJFMGEICL.EFEJCLLLEJJ_Gift[i])
					return false;
			}
			for(int i = 0; i < LGHCJFCCGFI_MedelShop.Length; i++)
			{
				if(LGHCJFCCGFI_MedelShop[i] != OIKJFMGEICL.LGHCJFCCGFI_MedelShop[i])
					return false;
			}
			return true;
		}

		//// RVA: 0x1AF22E8 Offset: 0x1AF22E8 VA: 0x1AF22E8
		public void AGNDGJOPIDL_AddShop(int _HMFFHLPNMPH_count)
		{
			int val = BOLCACJFJGG_Shop + _HMFFHLPNMPH_count;
			if (val >= 99999999)
				val = 99999999;
			BOLCACJFJGG_Shop = val;
		}

		//// RVA: 0x1AF2314 Offset: 0x1AF2314 VA: 0x1AF2314
		public void JLKOBAAEDAM_AddLogin(int _HMFFHLPNMPH_count)
		{
			int val = ODJEADMLGFB_Lgin + _HMFFHLPNMPH_count;
			if (val >= 99999999)
				val = 99999999;
			ODJEADMLGFB_Lgin = val;
		}

		//// RVA: 0x1AF2340 Offset: 0x1AF2340 VA: 0x1AF2340
		public void CNEMNJOLIBE_AddScene(int _HMFFHLPNMPH_count)
		{
			int val = FFMHGGHFNPJ_Scene + _HMFFHLPNMPH_count;
			if (val >= 99999999)
				val = 99999999;
			FFMHGGHFNPJ_Scene = val;
		}

		//// RVA: 0x1AF236C Offset: 0x1AF236C VA: 0x1AF236C
		public void EJDEINMOHOP_AddMedal(int _HMFFHLPNMPH_count)
		{
			int val = GNNKOAILFOL_Medal + _HMFFHLPNMPH_count;
			if (val >= 99999999)
				val = 99999999;
			GNNKOAILFOL_Medal = val;
		}

		//// RVA: 0x1AF2398 Offset: 0x1AF2398 VA: 0x1AF2398
		public void BFAJMALBALG_Gacha(int _HMFFHLPNMPH_count)
		{
			int val = NHPNPIBOHFB_Gacha + _HMFFHLPNMPH_count;
			if (val >= 99999999)
				val = 99999999;
			NHPNPIBOHFB_Gacha = val;
		}

		//// RVA: 0x1AF23C4 Offset: 0x1AF23C4 VA: 0x1AF23C4
		public void OAEMBFCMCHL_DailyMission(int _HMFFHLPNMPH_count)
		{
			int val = GCEKFPECEAI_DailyMission + _HMFFHLPNMPH_count;
			if (val >= 99999999)
				val = 99999999;
			GCEKFPECEAI_DailyMission = val;
		}

		//// RVA: 0x1AF23F0 Offset: 0x1AF23F0 VA: 0x1AF23F0
		public void HFOCJMOOMBB_EventMission(int _HMFFHLPNMPH_count)
		{
			int val = HJNEMKGIBGE_EventMission + _HMFFHLPNMPH_count;
			if (val >= 99999999)
				val = 99999999;
			HJNEMKGIBGE_EventMission = val;
		}

		//// RVA: 0x1AF241C Offset: 0x1AF241C VA: 0x1AF241C
		public void PJPHOMJFDEH_EventPlay(int _HMFFHLPNMPH_count)
		{
			int val = AIPKHFKODAH_EventPlay + _HMFFHLPNMPH_count;
			if (val >= 99999999)
				val = 99999999;
			AIPKHFKODAH_EventPlay = val;
		}

		//// RVA: 0x1AF2448 Offset: 0x1AF2448 VA: 0x1AF2448
		public int INMNHOGDFPM_GetArrayValue(ref int[] PILEIPOLBOE, int _OIPCCBHIKIA_index)
		{
			if(_OIPCCBHIKIA_index > -1 && _OIPCCBHIKIA_index < PILEIPOLBOE.Length)
			{
				return PILEIPOLBOE[_OIPCCBHIKIA_index] ^ FBGGEFFJJHB_xor;
			}
			return 0;
		}

		//// RVA: 0x1AF24D0 Offset: 0x1AF24D0 VA: 0x1AF24D0
		public void NMKOFGHHAEA_SetArrayValue(ref int[] PILEIPOLBOE, int _OIPCCBHIKIA_index, int _HMFFHLPNMPH_count)
		{
			if (_OIPCCBHIKIA_index > -1 && _OIPCCBHIKIA_index < PILEIPOLBOE.Length)
			{
				PILEIPOLBOE[_OIPCCBHIKIA_index] = _HMFFHLPNMPH_count ^ FBGGEFFJJHB_xor;
			}
		}

		//// RVA: 0x1AF2554 Offset: 0x1AF2554 VA: 0x1AF2554
		public void HNGEHGDDGAB_AddArrayValue(ref int[] PILEIPOLBOE, int _OIPCCBHIKIA_index, int _HMFFHLPNMPH_count)
		{
			if(_OIPCCBHIKIA_index > -1 && _OIPCCBHIKIA_index < PILEIPOLBOE.Length)
			{
				int val = (PILEIPOLBOE[_OIPCCBHIKIA_index] ^ FBGGEFFJJHB_xor) + _HMFFHLPNMPH_count;
				if (val > 99999999)
					val = 99999999;
				PILEIPOLBOE[_OIPCCBHIKIA_index] = val ^ FBGGEFFJJHB_xor;
			}
		}

		//// RVA: 0x1AEC8CC Offset: 0x1AEC8CC VA: 0x1AEC8CC
		public int GNHALIDFACE_GetVOpCValue(int _FGHGMHPNEMG_Type)
		{
			return INMNHOGDFPM_GetArrayValue(ref DENIHAKEBCA_VOpC, _FGHGMHPNEMG_Type);
		}

		//// RVA: 0x1AF094C Offset: 0x1AF094C VA: 0x1AF094C
		public void NADMCFKICOE_SetVOpCValue(int _FGHGMHPNEMG_Type, int _HMFFHLPNMPH_count)
		{
			NMKOFGHHAEA_SetArrayValue(ref DENIHAKEBCA_VOpC, _FGHGMHPNEMG_Type, _HMFFHLPNMPH_count);
		}

		//// RVA: 0x1AF2628 Offset: 0x1AF2628 VA: 0x1AF2628
		public void KKHPAHICACE_AddVOpCValue(int _FGHGMHPNEMG_Type, int _HMFFHLPNMPH_count)
		{
			HNGEHGDDGAB_AddArrayValue(ref DENIHAKEBCA_VOpC, _FGHGMHPNEMG_Type, _HMFFHLPNMPH_count);
		}

		//// RVA: 0x1AEC8D8 Offset: 0x1AEC8D8 VA: 0x1AEC8D8
		public int EJNFMAAKCMH_GetDOpCValue(int _OIPCCBHIKIA_index)
		{
			return INMNHOGDFPM_GetArrayValue(ref IKJLNHDBGHI_DOpC, _OIPCCBHIKIA_index);
		}

		//// RVA: 0x1AF09B4 Offset: 0x1AF09B4 VA: 0x1AF09B4
		public void MPEEACOJILJ_SetDOpCValue(int _OIPCCBHIKIA_index, int _HMFFHLPNMPH_count)
		{
			NMKOFGHHAEA_SetArrayValue(ref IKJLNHDBGHI_DOpC, _OIPCCBHIKIA_index, _HMFFHLPNMPH_count);
		}

		//// RVA: 0x1AF264C Offset: 0x1AF264C VA: 0x1AF264C
		public void NKOPNPPGPCD_AddDOpcValue(int _OIPCCBHIKIA_index, int _HMFFHLPNMPH_count)
		{
			HNGEHGDDGAB_AddArrayValue(ref IKJLNHDBGHI_DOpC, _OIPCCBHIKIA_index, _HMFFHLPNMPH_count);
		}

		//// RVA: 0x1AEC8E4 Offset: 0x1AEC8E4 VA: 0x1AEC8E4
		public int MLBJKMLMLEG_GetDOocValue(int _OIPCCBHIKIA_index)
		{
			return INMNHOGDFPM_GetArrayValue(ref NPBIKIMOKME_DOoC, _OIPCCBHIKIA_index);
		}

		//// RVA: 0x1AF0A1C Offset: 0x1AF0A1C VA: 0x1AF0A1C
		public void NDMPJNBKHPM_SetDOocValue(int _OIPCCBHIKIA_index, int _HMFFHLPNMPH_count)
		{
			NMKOFGHHAEA_SetArrayValue(ref NPBIKIMOKME_DOoC, _OIPCCBHIKIA_index, _HMFFHLPNMPH_count);
		}

		//// RVA: 0x1AF2670 Offset: 0x1AF2670 VA: 0x1AF2670
		public void APEIECMCGGH_AddDOoCValue(int _OIPCCBHIKIA_index, int _HMFFHLPNMPH_count)
		{
			HNGEHGDDGAB_AddArrayValue(ref NPBIKIMOKME_DOoC, _OIPCCBHIKIA_index, _HMFFHLPNMPH_count);
		}

		//// RVA: 0x1AEC8F0 Offset: 0x1AEC8F0 VA: 0x1AEC8F0
		public int FGGFDPFMKAF_GetDopuValue(int _OIPCCBHIKIA_index)
		{
			return INMNHOGDFPM_GetArrayValue(ref MENIJIHIBDC_Dopu, _OIPCCBHIKIA_index);
		}

		//// RVA: 0x1AF0A84 Offset: 0x1AF0A84 VA: 0x1AF0A84
		public void FBJIMCNJPOB_SetDopuValue(int _OIPCCBHIKIA_index, int _HMFFHLPNMPH_count)
		{
			NMKOFGHHAEA_SetArrayValue(ref MENIJIHIBDC_Dopu, _OIPCCBHIKIA_index, _HMFFHLPNMPH_count);
		}

		//// RVA: 0x1AF2694 Offset: 0x1AF2694 VA: 0x1AF2694
		public void PDHLABPHFNB_AddDopuValue(int _OIPCCBHIKIA_index, int _HMFFHLPNMPH_count)
		{
			HNGEHGDDGAB_AddArrayValue(ref MENIJIHIBDC_Dopu, _OIPCCBHIKIA_index, _HMFFHLPNMPH_count);
		}

		//// RVA: 0x1AEC8FC Offset: 0x1AEC8FC VA: 0x1AEC8FC
		public int KGFLHCHAIGO_GetChgcValue(int _OIPCCBHIKIA_index)
		{
			return INMNHOGDFPM_GetArrayValue(ref FCAHJGHCHAL_Chgc, _OIPCCBHIKIA_index);
		}

		//// RVA: 0x1AF0AEC Offset: 0x1AF0AEC VA: 0x1AF0AEC
		public void PODJFPCEDLM_SetChgcValue(int _OIPCCBHIKIA_index, int _HMFFHLPNMPH_count)
		{
			NMKOFGHHAEA_SetArrayValue(ref FCAHJGHCHAL_Chgc, _OIPCCBHIKIA_index, _HMFFHLPNMPH_count);
		}

		//// RVA: 0x1AF26B8 Offset: 0x1AF26B8 VA: 0x1AF26B8
		public void PCLBKGHNJPN_AddChgcValue(int _OIPCCBHIKIA_index, int _HMFFHLPNMPH_count)
		{
			HNGEHGDDGAB_AddArrayValue(ref FCAHJGHCHAL_Chgc, _OIPCCBHIKIA_index, _HMFFHLPNMPH_count);
		}

		//// RVA: 0x1AEC908 Offset: 0x1AEC908 VA: 0x1AEC908
		public int IKKOANOJHLB_GetGiftValue(int _OIPCCBHIKIA_index)
		{
			return INMNHOGDFPM_GetArrayValue(ref EFEJCLLLEJJ_Gift, _OIPCCBHIKIA_index);
		}

		//// RVA: 0x1AF0B54 Offset: 0x1AF0B54 VA: 0x1AF0B54
		public void PBEDBGMNGHB_SetGiftValue(int _OIPCCBHIKIA_index, int _HMFFHLPNMPH_count)
		{
			NMKOFGHHAEA_SetArrayValue(ref EFEJCLLLEJJ_Gift, _OIPCCBHIKIA_index, _HMFFHLPNMPH_count);
		}

		//// RVA: 0x1AF26DC Offset: 0x1AF26DC VA: 0x1AF26DC
		public void CCIDPHJEONL_AddGiftValue(int _OIPCCBHIKIA_index, int _HMFFHLPNMPH_count)
		{
			HNGEHGDDGAB_AddArrayValue(ref EFEJCLLLEJJ_Gift, _OIPCCBHIKIA_index, _HMFFHLPNMPH_count);
		}

		//// RVA: 0x1AEC914 Offset: 0x1AEC914 VA: 0x1AEC914
		public int CDNJPNFGHOG_GetMedalShopValue(int _OIPCCBHIKIA_index)
		{
			return INMNHOGDFPM_GetArrayValue(ref LGHCJFCCGFI_MedelShop, _OIPCCBHIKIA_index);
		}

		//// RVA: 0x1AF0BBC Offset: 0x1AF0BBC VA: 0x1AF0BBC
		public void CLOMILDLINH_SetMedalShopValue(int _OIPCCBHIKIA_index, int _HMFFHLPNMPH_count)
		{
			NMKOFGHHAEA_SetArrayValue(ref LGHCJFCCGFI_MedelShop, _OIPCCBHIKIA_index, _HMFFHLPNMPH_count);
		}

		//// RVA: 0x1AF2700 Offset: 0x1AF2700 VA: 0x1AF2700
		public void MPOEJLFDAGJ_AddMedalShopValue(int _OIPCCBHIKIA_index, int _HMFFHLPNMPH_count)
		{
			HNGEHGDDGAB_AddArrayValue(ref LGHCJFCCGFI_MedelShop, _OIPCCBHIKIA_index, _HMFFHLPNMPH_count);
		}
	}

	public class KKAJHLFMBKE
	{
		public int FBGGEFFJJHB_xor; // 0x8
		public long BBEGLBMOBOF_xorl; // 0x10
		private int EHOIENNDEDH_IdCrypted; // 0x18
		private int FKKHMCINELD; // 0x1C
		private int CGIGOFKGCII_CryptedDivaId; // 0x20
		private int HNJNKCPDKAL_CryptedModelId; // 0x24
		private int DJENABHDIPP; // 0x28
		public FLLIDKFECHC JJKBBFEJFGO_Cnt; // 0x2C
		public List<HKMBGGGMEKA> HDMADAHNLDN_Missions; // 0x30
		public List<long> OHMBCPHFDLD_Ln; // 0x34

		public int PPFNGGCBJKC_id { get { return EHOIENNDEDH_IdCrypted ^ FBGGEFFJJHB_xor; } set { EHOIENNDEDH_IdCrypted = value ^ FBGGEFFJJHB_xor; } } //0x1AEA3DC DEMEPMAEJOO 0x1AEE62C HIGKAIDMOKN
		public int EIHOBHDKCDB_RewardId { get { return FKKHMCINELD ^ FBGGEFFJJHB_xor; } set { FKKHMCINELD = value ^ FBGGEFFJJHB_xor; } } //0x1AEA40C EALKEGPNHGK 0x1AEE63C LNFEIPOKKNG
		public int AHHJLDLAPAN_DivaId { get { return CGIGOFKGCII_CryptedDivaId ^ FBGGEFFJJHB_xor; } set { CGIGOFKGCII_CryptedDivaId = value ^ FBGGEFFJJHB_xor; } } //0x1AEA3EC IPKDLMIDMHH 0x1AEE64C IENNENMKEFO
		public int DAJGPBLEEOB_ModelId { get { return HNJNKCPDKAL_CryptedModelId ^ FBGGEFFJJHB_xor; } set { HNJNKCPDKAL_CryptedModelId = value ^ FBGGEFFJJHB_xor; } } //0x1AEA3FC LHPKEPPBKPF 0x1AEE65C OIOEEEDODJA
		public int JBMGFNHBECN_Sst { get { return DJENABHDIPP ^ FBGGEFFJJHB_xor; } set { DJENABHDIPP = value ^ FBGGEFFJJHB_xor; } } //0x1AEC83C IJMJAGAPMCF 0x1AEE66C MKNANLMEHKA

		//// RVA: 0x1AEC984 Offset: 0x1AEC984 VA: 0x1AEC984
		public long CPLKJBCBPNM(int IOPHIHFOOEP)
		{
			if(IOPHIHFOOEP < 0)
				return 0;
			if(OHMBCPHFDLD_Ln.Count <= IOPHIHFOOEP)
				return 0;
			return OHMBCPHFDLD_Ln[IOPHIHFOOEP] ^ BBEGLBMOBOF_xorl;
		}

		//// RVA: 0x1AF081C Offset: 0x1AF081C VA: 0x1AF081C
		public bool BMJGIEJPDLM(int IOPHIHFOOEP, long _MIKCFEHGNJB_dt)
		{
			if(IOPHIHFOOEP > -1 && IOPHIHFOOEP < OHMBCPHFDLD_Ln.Count)
			{
				OHMBCPHFDLD_Ln[IOPHIHFOOEP] = _MIKCFEHGNJB_dt ^ BBEGLBMOBOF_xorl;
				return true;
			}
			return false;
		}

		// RVA: 0x1AF0CCC Offset: 0x1AF0CCC VA: 0x1AF0CCC
		public KKAJHLFMBKE()
		{
			FBGGEFFJJHB_xor = LPDNKHAIOLH.CEIBAFOCNCA();
			BBEGLBMOBOF_xorl = ~FBGGEFFJJHB_xor;
		}

		//// RVA: 0x1AF0D68 Offset: 0x1AF0D68 VA: 0x1AF0D68
		public void KHEKNNFCAOI_Init(int _PPFNGGCBJKC_id)
		{
			this.PPFNGGCBJKC_id = _PPFNGGCBJKC_id;
			EIHOBHDKCDB_RewardId = 0;
			AHHJLDLAPAN_DivaId = 0;
			DAJGPBLEEOB_ModelId = 0;
			JBMGFNHBECN_Sst = 0;
			JJKBBFEJFGO_Cnt = new FLLIDKFECHC();
			JJKBBFEJFGO_Cnt.KHEKNNFCAOI_Init();
			HDMADAHNLDN_Missions = new List<HKMBGGGMEKA>(9);
			for(int i = 0; i < 9; i++)
			{
				HKMBGGGMEKA data = new HKMBGGGMEKA();
				data.KHEKNNFCAOI_Init(i + 1);
				HDMADAHNLDN_Missions.Add(data);
			}
			OHMBCPHFDLD_Ln = new List<long>();
			for (int i = 0; i < 8; i++)
			{
				OHMBCPHFDLD_Ln.Add(BBEGLBMOBOF_xorl);
			}
		}

		//// RVA: 0x1AF109C Offset: 0x1AF109C VA: 0x1AF109C
		//public bool CHFOOMPEABN() { }

		//// RVA: 0x1AF2A10 Offset: 0x1AF2A10 VA: 0x1AF2A10
		//public bool DFIGPDCBAPB() { }

		//// RVA: 0x1AF10D0 Offset: 0x1AF10D0 VA: 0x1AF10D0
		public void ODDIHGPONFL_Copy(KKAJHLFMBKE GPBJHKLFCEP)
		{
			PPFNGGCBJKC_id = GPBJHKLFCEP.PPFNGGCBJKC_id;
			EIHOBHDKCDB_RewardId = GPBJHKLFCEP.EIHOBHDKCDB_RewardId;
			AHHJLDLAPAN_DivaId = GPBJHKLFCEP.AHHJLDLAPAN_DivaId;
			DAJGPBLEEOB_ModelId = GPBJHKLFCEP.DAJGPBLEEOB_ModelId;
			JBMGFNHBECN_Sst = GPBJHKLFCEP.JBMGFNHBECN_Sst;
			JJKBBFEJFGO_Cnt.ODDIHGPONFL_Copy(GPBJHKLFCEP.JJKBBFEJFGO_Cnt);
			for(int i = 0; i < HDMADAHNLDN_Missions.Count; i++)
			{
				HDMADAHNLDN_Missions[i].ODDIHGPONFL_Copy(GPBJHKLFCEP.HDMADAHNLDN_Missions[i]);
			}
			for(int i = 0; i < OHMBCPHFDLD_Ln.Count; i++)
			{
				BMJGIEJPDLM(i, GPBJHKLFCEP.CPLKJBCBPNM(i));
			}
		}

		//// RVA: 0x1AF1378 Offset: 0x1AF1378 VA: 0x1AF1378
		public bool AGBOGBEOFME(KKAJHLFMBKE OIKJFMGEICL)
		{
			if(PPFNGGCBJKC_id != OIKJFMGEICL.PPFNGGCBJKC_id ||
				EIHOBHDKCDB_RewardId != OIKJFMGEICL.EIHOBHDKCDB_RewardId ||
				AHHJLDLAPAN_DivaId != OIKJFMGEICL.AHHJLDLAPAN_DivaId ||
				DAJGPBLEEOB_ModelId != OIKJFMGEICL.DAJGPBLEEOB_ModelId ||
				JBMGFNHBECN_Sst != OIKJFMGEICL.JBMGFNHBECN_Sst ||
				!JJKBBFEJFGO_Cnt.AGBOGBEOFME(OIKJFMGEICL.JJKBBFEJFGO_Cnt))
				return false;
			for(int i = 0; i < HDMADAHNLDN_Missions.Count; i++)
			{
				if(!HDMADAHNLDN_Missions[i].AGBOGBEOFME(OIKJFMGEICL.HDMADAHNLDN_Missions[i]))
					return false;
			}
			for(int i = 0; i < OHMBCPHFDLD_Ln.Count; i++)
			{
				if(CPLKJBCBPNM(i) != OIKJFMGEICL.CPLKJBCBPNM(i))
					return false;
			}
			return true;
		}

		//// RVA: 0x1AF2A48 Offset: 0x1AF2A48 VA: 0x1AF2A48
		//public void AGHKODFKOJI(BHBONAHFKHD JBBHNIACMFJ, string JIKKNHIAEKG, string MJBACHKCIHA, int _OIPCCBHIKIA_index, NFMHCLHEMHB_Bingo.KKAJHLFMBKE _OHMCIEMIKCE_t, bool EFOEPDLNLJG) { }
	}

	public class HKMBGGGMEKA
	{
		public int FBGGEFFJJHB_xor; // 0x8
		public long BBEGLBMOBOF_xorl; // 0x10
		private int EHOIENNDEDH_IdCrypted; // 0x18
		private int IJLOECFBOAN; // 0x1C
		private int NLBLLLLBHOP_StatusCrypted; // 0x20
		private int HLMAFFLCCKD_CountCrypted; // 0x24
		private long MIOBPGFAABN; // 0x28
		private int MCFFGKAOIHP; // 0x30

		public int PPFNGGCBJKC_id { get { return EHOIENNDEDH_IdCrypted ^ FBGGEFFJJHB_xor; } set { EHOIENNDEDH_IdCrypted = value ^ FBGGEFFJJHB_xor; } } //0x1AEC920 DEMEPMAEJOO 0x1AEE704 HIGKAIDMOKN
		public int JOMGCCBFKEF_MissionId { get { return IJLOECFBOAN ^ FBGGEFFJJHB_xor; } set { IJLOECFBOAN = value ^ FBGGEFFJJHB_xor; } } //0x1AEC930 GGFGMDFOFLG 0x1AEE714 JCJBHJOOIDP
		public int CMCKNKKCNDK_status { get { return NLBLLLLBHOP_StatusCrypted ^ FBGGEFFJJHB_xor; } set { NLBLLLLBHOP_StatusCrypted = value ^ FBGGEFFJJHB_xor; } } //0x1AEC940 CNKGOPKANGF 0x1AEE724 CHJGGLFGALP
		public int HMFFHLPNMPH_count { get { return HLMAFFLCCKD_CountCrypted ^ FBGGEFFJJHB_xor; } set { HLMAFFLCCKD_CountCrypted = value ^ FBGGEFFJJHB_xor; } } //0x1AEC950 NJOGDDPICKG 0x1AEE734 NBBGMMBICNA
		public long OPGPHAEMIDO_Dt { get { return MIOBPGFAABN ^ BBEGLBMOBOF_xorl; } set { MIOBPGFAABN = value ^ BBEGLBMOBOF_xorl; } } //0x1AEC960 HEBGPKBHPIB 0x1AEE744 JMKELOPNAGE
		public int CCKELABMHIO_Ac { get { return MCFFGKAOIHP ^ FBGGEFFJJHB_xor; } set { MCFFGKAOIHP = value ^ FBGGEFFJJHB_xor; } } //0x1AEC974 GGHKPKEGFLM 0x1AEE764 GCDJHHFGLLE

		// RVA: 0x1AF2724 Offset: 0x1AF2724 VA: 0x1AF2724
		public HKMBGGGMEKA()
		{
			FBGGEFFJJHB_xor = LPDNKHAIOLH.CEIBAFOCNCA();
			BBEGLBMOBOF_xorl = ~FBGGEFFJJHB_xor;
		}

		//// RVA: 0x1AF27C0 Offset: 0x1AF27C0 VA: 0x1AF27C0
		public void KHEKNNFCAOI_Init(int _PPFNGGCBJKC_id)
		{
			this.PPFNGGCBJKC_id = _PPFNGGCBJKC_id;
			JOMGCCBFKEF_MissionId = 0;
			CMCKNKKCNDK_status = 0;
			HMFFHLPNMPH_count = 0;
			OPGPHAEMIDO_Dt = 0;
			CCKELABMHIO_Ac = 0;
		}

		//// RVA: 0x1AF27F0 Offset: 0x1AF27F0 VA: 0x1AF27F0
		public void ODDIHGPONFL_Copy(HKMBGGGMEKA GPBJHKLFCEP)
		{
			JOMGCCBFKEF_MissionId = GPBJHKLFCEP.JOMGCCBFKEF_MissionId;
			CMCKNKKCNDK_status = GPBJHKLFCEP.CMCKNKKCNDK_status;
			HMFFHLPNMPH_count = GPBJHKLFCEP.HMFFHLPNMPH_count;
			OPGPHAEMIDO_Dt = GPBJHKLFCEP.OPGPHAEMIDO_Dt;
			CCKELABMHIO_Ac = GPBJHKLFCEP.CCKELABMHIO_Ac;
		}

		//// RVA: 0x1AF2924 Offset: 0x1AF2924 VA: 0x1AF2924
		public bool AGBOGBEOFME(HKMBGGGMEKA OIKJFMGEICL)
		{
			if(PPFNGGCBJKC_id != OIKJFMGEICL.PPFNGGCBJKC_id ||
				JOMGCCBFKEF_MissionId != OIKJFMGEICL.JOMGCCBFKEF_MissionId ||
				CMCKNKKCNDK_status != OIKJFMGEICL.CMCKNKKCNDK_status ||
				HMFFHLPNMPH_count != OIKJFMGEICL.HMFFHLPNMPH_count ||
				OPGPHAEMIDO_Dt != OIKJFMGEICL.OPGPHAEMIDO_Dt ||
				CCKELABMHIO_Ac != OIKJFMGEICL.CCKELABMHIO_Ac)
				return false;
			return true;
		}
	}

	public class OCLGCNPBNHE
	{
		public int FBGGEFFJJHB_xor; // 0x8
		public long BBEGLBMOBOF_xorl; // 0x10
		private int EHOIENNDEDH_IdCrypted; // 0x18
		private long EEDMPMBDGJN; // 0x20

		public int PPFNGGCBJKC_id { get { return EHOIENNDEDH_IdCrypted ^ FBGGEFFJJHB_xor; } set { EHOIENNDEDH_IdCrypted = value ^ FBGGEFFJJHB_xor; } } //0x1AECA98 DEMEPMAEJOO 0x1AEE774 HIGKAIDMOKN
		public long MIKCFEHGNJB_dt { get { return EEDMPMBDGJN ^ BBEGLBMOBOF_xorl; } set { EEDMPMBDGJN = value ^ BBEGLBMOBOF_xorl; } } //0x1AECAA8 PPCHCNBHAAG 0x1AEE784 DKKLANMGOIF

		// RVA: 0x1AF0F60 Offset: 0x1AF0F60 VA: 0x1AF0F60
		public OCLGCNPBNHE()
		{
			FBGGEFFJJHB_xor = LPDNKHAIOLH.CEIBAFOCNCA();
			BBEGLBMOBOF_xorl = ~FBGGEFFJJHB_xor;
		}

		//// RVA: 0x1AF0FFC Offset: 0x1AF0FFC VA: 0x1AF0FFC
		public void KHEKNNFCAOI_Init(int _PPFNGGCBJKC_id)
		{
			this.PPFNGGCBJKC_id = _PPFNGGCBJKC_id;
			MIKCFEHGNJB_dt = 0;
		}

		//// RVA: 0x1AECA64 Offset: 0x1AECA64 VA: 0x1AECA64
		//public bool DFIGPDCBAPB() { }
	}

	// Version 3 : Fix array value wrongly saved after the ^ bug
	private const int ECFEMKGFDCE_CurrentVersion = 3;
	public static string POFDDFCGEGP_Underscore = "_"; // 0x0

	public List<CCGKCGJKADC> MPCJGPEBCCD { get; private set; } // 0x24 JIFCNLJLCFC IKJFFEHHGBA BBPFBLJNACB
	public override bool DMICHEJIAJL { get { return false; } } // 0x1AF0698 NFKFOODCJJB

	private int ReadVersion = -1;

	// // RVA: 0x1AEA1B0 Offset: 0x1AEA1B0 VA: 0x1AEA1B0
	// public NFMHCLHEMHB.CCGKCGJKADC GCINIJEMHFK(int _PPFNGGCBJKC_id) { }

	// // RVA: 0x1AEA23C Offset: 0x1AEA23C VA: 0x1AEA23C
	public bool DFIGPDCBAPB(int _PPFNGGCBJKC_id)
	{
		if (_PPFNGGCBJKC_id > 0 && _PPFNGGCBJKC_id <= MPCJGPEBCCD.Count)
		{
			return MPCJGPEBCCD[_PPFNGGCBJKC_id - 1].AHCFGOGCJKI_St.AHHJLDLAPAN_DivaId == 0 &&
				MPCJGPEBCCD[_PPFNGGCBJKC_id - 1].AHCFGOGCJKI_St.PPFNGGCBJKC_id == 0 &&
				MPCJGPEBCCD[_PPFNGGCBJKC_id - 1].AHCFGOGCJKI_St.DAJGPBLEEOB_ModelId == 0 &&
				MPCJGPEBCCD[_PPFNGGCBJKC_id - 1].AHCFGOGCJKI_St.EIHOBHDKCDB_RewardId == 0;
		}
		return false;
	}

	// // RVA: 0x1AEA41C Offset: 0x1AEA41C VA: 0x1AEA41C
	public CCGKCGJKADC EACEMMDIPFD_GetEmptyBingo()
	{
		return MPCJGPEBCCD.Find((CCGKCGJKADC JPAEDJJFFOI) => {
			//0x1AF0790
			return JPAEDJJFFOI.AHCFGOGCJKI_St.PPFNGGCBJKC_id == 0;
		});
	}

	// // RVA: 0x1AEA574 Offset: 0x1AEA574 VA: 0x1AEA574
	public NFMHCLHEMHB_Bingo()
	{
		MPCJGPEBCCD = new List<CCGKCGJKADC>(10);
		KMBPACJNEOF_Reset();
	}

	// // RVA: 0x1AEA618 Offset: 0x1AEA618 VA: 0x1AEA618 Slot: 4
	public override void KMBPACJNEOF_Reset()
	{
		MPCJGPEBCCD.Clear();
		for(int i = 0; i < 10; i++)
		{
			CCGKCGJKADC data = new CCGKCGJKADC();
			data.KHEKNNFCAOI_Init(i + 1);
			MPCJGPEBCCD.Add(data);
		}
	}

	// // RVA: 0x1AEA9A4 Offset: 0x1AEA9A4 VA: 0x1AEA9A4 Slot: 5
	public override void OKJPIBHMKMJ(EDOHBJAPLPF_JsonData OILEIIEIBHP, long _MCKEOKFMLAH_SaveId)
	{
		EDOHBJAPLPF_JsonData data = new EDOHBJAPLPF_JsonData();
		data[POFDDFCGEGP_Underscore] = "";
		for(int i = 0; i < MPCJGPEBCCD.Count; i++)
		{
			if(!DFIGPDCBAPB(i + 1))
			{
				EDOHBJAPLPF_JsonData data2 = new EDOHBJAPLPF_JsonData();
				data2[AFEHLCGHAEE_Strings.PPFNGGCBJKC_id] = MPCJGPEBCCD[i].PPFNGGCBJKC_id;
				data2[AFEHLCGHAEE_Strings.KOOEOKEDJDO_expr] = MPCJGPEBCCD[i].KOOEOKEDJDO_expr;
				data2[AFEHLCGHAEE_Strings.FGKGELOJBJK_ul] = MPCJGPEBCCD[i].EBDKHCLCOFL_Ul;
				data2[AFEHLCGHAEE_Strings.JNLKJCDFFMM_clear] = MPCJGPEBCCD[i].JNLKJCDFFMM_clear;
				data2["bst"] = MPCJGPEBCCD[i].BJOHOIAKKFM_Bst;
				EDOHBJAPLPF_JsonData data3 = new EDOHBJAPLPF_JsonData();
				data3[AFEHLCGHAEE_Strings.PPFNGGCBJKC_id] = MPCJGPEBCCD[i].AHCFGOGCJKI_St.PPFNGGCBJKC_id;
				data3[AFEHLCGHAEE_Strings.INJIPPBFMIG_r_id] = MPCJGPEBCCD[i].AHCFGOGCJKI_St.EIHOBHDKCDB_RewardId;
				data3[AFEHLCGHAEE_Strings.OCAMDLMPBGA_dv] = MPCJGPEBCCD[i].AHCFGOGCJKI_St.AHHJLDLAPAN_DivaId;
				data3[AFEHLCGHAEE_Strings.FLNJLKKAFPB_mdl] = MPCJGPEBCCD[i].AHCFGOGCJKI_St.DAJGPBLEEOB_ModelId;
				data3["sst"] = MPCJGPEBCCD[i].AHCFGOGCJKI_St.JBMGFNHBECN_Sst;
				EDOHBJAPLPF_JsonData data4 = new EDOHBJAPLPF_JsonData();
				data4["shop"] = MPCJGPEBCCD[i].AHCFGOGCJKI_St.JJKBBFEJFGO_Cnt.BOLCACJFJGG_Shop;
				data4["lgin"] = MPCJGPEBCCD[i].AHCFGOGCJKI_St.JJKBBFEJFGO_Cnt.ODJEADMLGFB_Lgin;
				data4["scene"] = MPCJGPEBCCD[i].AHCFGOGCJKI_St.JJKBBFEJFGO_Cnt.FFMHGGHFNPJ_Scene;
				data4["medal"] = MPCJGPEBCCD[i].AHCFGOGCJKI_St.JJKBBFEJFGO_Cnt.GNNKOAILFOL_Medal;
				data4["gacha"] = MPCJGPEBCCD[i].AHCFGOGCJKI_St.JJKBBFEJFGO_Cnt.NHPNPIBOHFB_Gacha;
				data4["deliy_mission"] = MPCJGPEBCCD[i].AHCFGOGCJKI_St.JJKBBFEJFGO_Cnt.GCEKFPECEAI_DailyMission;
				data4["event_mission"] = MPCJGPEBCCD[i].AHCFGOGCJKI_St.JJKBBFEJFGO_Cnt.HJNEMKGIBGE_EventMission;
				data4["event_play"] = MPCJGPEBCCD[i].AHCFGOGCJKI_St.JJKBBFEJFGO_Cnt.AIPKHFKODAH_EventPlay;
				{
					EDOHBJAPLPF_JsonData data5 = new EDOHBJAPLPF_JsonData();
					data5.LAJDIPCJCPO_SetJsonType(JFBMDLGBPEN_JsonType.BDHGEFMCJDF_Array);
					for (int j = 0; j < MPCJGPEBCCD[i].AHCFGOGCJKI_St.JJKBBFEJFGO_Cnt.DENIHAKEBCA_VOpC.Length; j++)
					{
						data5.Add(MPCJGPEBCCD[i].AHCFGOGCJKI_St.JJKBBFEJFGO_Cnt.INMNHOGDFPM_GetArrayValue(ref MPCJGPEBCCD[i].AHCFGOGCJKI_St.JJKBBFEJFGO_Cnt.DENIHAKEBCA_VOpC, j));
					}
					data4["vopc"] = data5;
				}
				{
					EDOHBJAPLPF_JsonData data5 = new EDOHBJAPLPF_JsonData();
					data5.LAJDIPCJCPO_SetJsonType(JFBMDLGBPEN_JsonType.BDHGEFMCJDF_Array);
					for (int j = 0; j < MPCJGPEBCCD[i].AHCFGOGCJKI_St.JJKBBFEJFGO_Cnt.IKJLNHDBGHI_DOpC.Length; j++)
					{
						data5.Add(MPCJGPEBCCD[i].AHCFGOGCJKI_St.JJKBBFEJFGO_Cnt.INMNHOGDFPM_GetArrayValue(ref MPCJGPEBCCD[i].AHCFGOGCJKI_St.JJKBBFEJFGO_Cnt.IKJLNHDBGHI_DOpC, j));
					}
					data4["dopc"] = data5;
				}
				{
					EDOHBJAPLPF_JsonData data5 = new EDOHBJAPLPF_JsonData();
					data5.LAJDIPCJCPO_SetJsonType(JFBMDLGBPEN_JsonType.BDHGEFMCJDF_Array);
					for (int j = 0; j < MPCJGPEBCCD[i].AHCFGOGCJKI_St.JJKBBFEJFGO_Cnt.NPBIKIMOKME_DOoC.Length; j++)
					{
						data5.Add(MPCJGPEBCCD[i].AHCFGOGCJKI_St.JJKBBFEJFGO_Cnt.INMNHOGDFPM_GetArrayValue(ref MPCJGPEBCCD[i].AHCFGOGCJKI_St.JJKBBFEJFGO_Cnt.NPBIKIMOKME_DOoC, j));
					}
					data4["dooc"] = data5;
				}
				{
					EDOHBJAPLPF_JsonData data5 = new EDOHBJAPLPF_JsonData();
					data5.LAJDIPCJCPO_SetJsonType(JFBMDLGBPEN_JsonType.BDHGEFMCJDF_Array);
					for (int j = 0; j < MPCJGPEBCCD[i].AHCFGOGCJKI_St.JJKBBFEJFGO_Cnt.MENIJIHIBDC_Dopu.Length; j++)
					{
						data5.Add(MPCJGPEBCCD[i].AHCFGOGCJKI_St.JJKBBFEJFGO_Cnt.INMNHOGDFPM_GetArrayValue(ref MPCJGPEBCCD[i].AHCFGOGCJKI_St.JJKBBFEJFGO_Cnt.MENIJIHIBDC_Dopu, j));
					}
					data4["dopu"] = data5;
				}
				{
					EDOHBJAPLPF_JsonData data5 = new EDOHBJAPLPF_JsonData();
					data5.LAJDIPCJCPO_SetJsonType(JFBMDLGBPEN_JsonType.BDHGEFMCJDF_Array);
					for (int j = 0; j < MPCJGPEBCCD[i].AHCFGOGCJKI_St.JJKBBFEJFGO_Cnt.FCAHJGHCHAL_Chgc.Length; j++)
					{
						data5.Add(MPCJGPEBCCD[i].AHCFGOGCJKI_St.JJKBBFEJFGO_Cnt.INMNHOGDFPM_GetArrayValue(ref MPCJGPEBCCD[i].AHCFGOGCJKI_St.JJKBBFEJFGO_Cnt.FCAHJGHCHAL_Chgc, j));
					}
					data4["chgc"] = data5;
				}
				{
					EDOHBJAPLPF_JsonData data5 = new EDOHBJAPLPF_JsonData();
					data5.LAJDIPCJCPO_SetJsonType(JFBMDLGBPEN_JsonType.BDHGEFMCJDF_Array);
					for (int j = 0; j < MPCJGPEBCCD[i].AHCFGOGCJKI_St.JJKBBFEJFGO_Cnt.EFEJCLLLEJJ_Gift.Length; j++)
					{
						data5.Add(MPCJGPEBCCD[i].AHCFGOGCJKI_St.JJKBBFEJFGO_Cnt.INMNHOGDFPM_GetArrayValue(ref MPCJGPEBCCD[i].AHCFGOGCJKI_St.JJKBBFEJFGO_Cnt.EFEJCLLLEJJ_Gift, j));
					}
					data4["gift"] = data5;
				}
				{
					EDOHBJAPLPF_JsonData data5 = new EDOHBJAPLPF_JsonData();
					data5.LAJDIPCJCPO_SetJsonType(JFBMDLGBPEN_JsonType.BDHGEFMCJDF_Array);
					for (int j = 0; j < MPCJGPEBCCD[i].AHCFGOGCJKI_St.JJKBBFEJFGO_Cnt.LGHCJFCCGFI_MedelShop.Length; j++)
					{
						data5.Add(MPCJGPEBCCD[i].AHCFGOGCJKI_St.JJKBBFEJFGO_Cnt.INMNHOGDFPM_GetArrayValue(ref MPCJGPEBCCD[i].AHCFGOGCJKI_St.JJKBBFEJFGO_Cnt.LGHCJFCCGFI_MedelShop, j));
					}
					data4["gift"] = data5;
				}
				data3[AFEHLCGHAEE_Strings.BFINGCJHOHI_cnt] = data4;
				{
					EDOHBJAPLPF_JsonData data5 = new EDOHBJAPLPF_JsonData();
					data5.LAJDIPCJCPO_SetJsonType(JFBMDLGBPEN_JsonType.BDHGEFMCJDF_Array);
					for (int j = 0; j < MPCJGPEBCCD[i].AHCFGOGCJKI_St.HDMADAHNLDN_Missions.Count; j++)
					{
						EDOHBJAPLPF_JsonData data6 = new EDOHBJAPLPF_JsonData();
						data6[AFEHLCGHAEE_Strings.PPFNGGCBJKC_id] = MPCJGPEBCCD[i].AHCFGOGCJKI_St.HDMADAHNLDN_Missions[j].PPFNGGCBJKC_id;
						data6[AFEHLCGHAEE_Strings.KLMIFEKNBLL_m_id] = MPCJGPEBCCD[i].AHCFGOGCJKI_St.HDMADAHNLDN_Missions[j].JOMGCCBFKEF_MissionId;
						data6[AFEHLCGHAEE_Strings.EALOBDHOCHP_stat] = MPCJGPEBCCD[i].AHCFGOGCJKI_St.HDMADAHNLDN_Missions[j].CMCKNKKCNDK_status;
						data6[AFEHLCGHAEE_Strings.BFINGCJHOHI_cnt] = MPCJGPEBCCD[i].AHCFGOGCJKI_St.HDMADAHNLDN_Missions[j].HMFFHLPNMPH_count;
						data6[AFEHLCGHAEE_Strings.MIKCFEHGNJB_dt] = MPCJGPEBCCD[i].AHCFGOGCJKI_St.HDMADAHNLDN_Missions[j].OPGPHAEMIDO_Dt;
						data6[AFEHLCGHAEE_Strings.ONOPACPKFPK_ac] = MPCJGPEBCCD[i].AHCFGOGCJKI_St.HDMADAHNLDN_Missions[j].CCKELABMHIO_Ac;
						data5.Add(data6);
					}
					data3[AFEHLCGHAEE_Strings.COGJONKKALB_ms] = data5;
				}
				{
					EDOHBJAPLPF_JsonData data5 = new EDOHBJAPLPF_JsonData();
					for(int j = 0; j < 8; j++)
					{
						data5.Add((int)MPCJGPEBCCD[i].AHCFGOGCJKI_St.CPLKJBCBPNM(j));
					}
					data3[AFEHLCGHAEE_Strings.NMHGCOLMPJA_ln] = data5;
				}
				data2[AFEHLCGHAEE_Strings.FNEIADJMHHO_st] = data3;
				{
					EDOHBJAPLPF_JsonData data5 = new EDOHBJAPLPF_JsonData();
					data5.LAJDIPCJCPO_SetJsonType(JFBMDLGBPEN_JsonType.BDHGEFMCJDF_Array);
					for(int j = 0; j < MPCJGPEBCCD[i].AHJNPEAMCCH_rewards.Count; j++)
					{
						if(MPCJGPEBCCD[i].AHJNPEAMCCH_rewards[j].PPFNGGCBJKC_id != 0 || MPCJGPEBCCD[i].AHJNPEAMCCH_rewards[j].MIKCFEHGNJB_dt != 0)
						{
							EDOHBJAPLPF_JsonData data6 = new EDOHBJAPLPF_JsonData();
							data6[AFEHLCGHAEE_Strings.PPFNGGCBJKC_id] = MPCJGPEBCCD[i].AHJNPEAMCCH_rewards[j].PPFNGGCBJKC_id;
							data6[AFEHLCGHAEE_Strings.MIKCFEHGNJB_dt] = MPCJGPEBCCD[i].AHJNPEAMCCH_rewards[j].MIKCFEHGNJB_dt;
							data5.Add(data6);
						}
					}
					data2[AFEHLCGHAEE_Strings.JGOHPDKCJKB_rw] = data5;
				}
				{
					EDOHBJAPLPF_JsonData data5 = new EDOHBJAPLPF_JsonData();
					data5.LAJDIPCJCPO_SetJsonType(JFBMDLGBPEN_JsonType.BDHGEFMCJDF_Array);
					for (int j = 0; j < MPCJGPEBCCD[i].MIOBPGFAABN.Count; j++)
					{
						data5.Add(MPCJGPEBCCD[i].MILJGLKJACG(j));
					}
					data2[AFEHLCGHAEE_Strings.MIKCFEHGNJB_dt] = data5;
				}
				data[POFDDFCGEGP_Underscore + (i + 1)] = data2;
			}
		}
		if(!EMBGIDLFKGM)
		{
			EDOHBJAPLPF_JsonData data2 = new EDOHBJAPLPF_JsonData();
			data2[AFEHLCGHAEE_Strings.KAKFEGGEKLB_save_id] = _MCKEOKFMLAH_SaveId;
			data2[JIKKNHIAEKG_BlockName] = data;
			data2[AFEHLCGHAEE_Strings.AGPKGMFOJHC_rev] = ECFEMKGFDCE_CurrentVersion;
			data = data2;
		}
		else
		{
			OILEIIEIBHP = OILEIIEIBHP[AFEHLCGHAEE_Strings.JCIBKDHKNFH_alldata];
		}
		OILEIIEIBHP[JIKKNHIAEKG_BlockName] = data;
	}

	// // RVA: 0x1AECB9C Offset: 0x1AECB9C VA: 0x1AECB9C Slot: 6
	public override bool IIEMACPEEBJ_Deserialize(EDOHBJAPLPF_JsonData OILEIIEIBHP)
	{
		bool blockMissing = false;
		bool isInvalid = false;
		ReadVersion = -1;
		EDOHBJAPLPF_JsonData block = LGPBAKLCFHI_FindAndCheckBlock(OILEIIEIBHP, ref blockMissing, ref isInvalid, ECFEMKGFDCE_CurrentVersion);
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
					string str = POFDDFCGEGP_Underscore + (i + 1).ToString();
					if(block.BBAJPINMOEP_Contains(str))
					{
						EDOHBJAPLPF_JsonData b = block[str];
						CCGKCGJKADC data = MPCJGPEBCCD[i];
						data.PPFNGGCBJKC_id = i + 1;
						data.KOOEOKEDJDO_expr = DKMPHAPBDLH_ReadLong(b, AFEHLCGHAEE_Strings.KOOEOKEDJDO_expr, 0, ref isInvalid);
						data.EBDKHCLCOFL_Ul = DKMPHAPBDLH_ReadLong(b, AFEHLCGHAEE_Strings.FGKGELOJBJK_ul, 0, ref isInvalid);
						data.JNLKJCDFFMM_clear = CJAENOMGPDA_ReadInt(b, AFEHLCGHAEE_Strings.JNLKJCDFFMM_clear, 0, ref isInvalid);
						data.BJOHOIAKKFM_Bst = CJAENOMGPDA_ReadInt(b, "bst", 0, ref isInvalid);
						if(b.BBAJPINMOEP_Contains(AFEHLCGHAEE_Strings.FNEIADJMHHO_st))
						{
							EDOHBJAPLPF_JsonData b2 = b[AFEHLCGHAEE_Strings.FNEIADJMHHO_st];
							data.AHCFGOGCJKI_St.PPFNGGCBJKC_id = CJAENOMGPDA_ReadInt(b2, AFEHLCGHAEE_Strings.PPFNGGCBJKC_id, 0, ref isInvalid);
							data.AHCFGOGCJKI_St.EIHOBHDKCDB_RewardId = CJAENOMGPDA_ReadInt(b2, AFEHLCGHAEE_Strings.INJIPPBFMIG_r_id, 0, ref isInvalid);
							data.AHCFGOGCJKI_St.AHHJLDLAPAN_DivaId = CJAENOMGPDA_ReadInt(b2, AFEHLCGHAEE_Strings.OCAMDLMPBGA_dv, 0, ref isInvalid);
							data.AHCFGOGCJKI_St.DAJGPBLEEOB_ModelId = CJAENOMGPDA_ReadInt(b2, AFEHLCGHAEE_Strings.FLNJLKKAFPB_mdl, 0, ref isInvalid);
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
								IBCGPBOGOGP_ReadIntArray(b3, "vopc", 0, data.AHCFGOGCJKI_St.JJKBBFEJFGO_Cnt.DENIHAKEBCA_VOpC.Length, (int _OIPCCBHIKIA_index, int _JBGEEPFKIGG_val) =>
								{
									//0x1AF0908
									data.AHCFGOGCJKI_St.JJKBBFEJFGO_Cnt.NMKOFGHHAEA_SetArrayValue(ref data.AHCFGOGCJKI_St.JJKBBFEJFGO_Cnt.DENIHAKEBCA_VOpC, _OIPCCBHIKIA_index, _JBGEEPFKIGG_val);
								}, ref isInvalid);
								IBCGPBOGOGP_ReadIntArray(b3, "dopc", 0, data.AHCFGOGCJKI_St.JJKBBFEJFGO_Cnt.IKJLNHDBGHI_DOpC.Length, (int _OIPCCBHIKIA_index, int _JBGEEPFKIGG_val) =>
								{
									//0x1AF0970
									data.AHCFGOGCJKI_St.JJKBBFEJFGO_Cnt.NMKOFGHHAEA_SetArrayValue(ref data.AHCFGOGCJKI_St.JJKBBFEJFGO_Cnt.IKJLNHDBGHI_DOpC, _OIPCCBHIKIA_index, _JBGEEPFKIGG_val);
								}, ref isInvalid);
								IBCGPBOGOGP_ReadIntArray(b3, "dooc", 0, data.AHCFGOGCJKI_St.JJKBBFEJFGO_Cnt.NPBIKIMOKME_DOoC.Length, (int _OIPCCBHIKIA_index, int _JBGEEPFKIGG_val) =>
								{
									//0x1AF09D8
									data.AHCFGOGCJKI_St.JJKBBFEJFGO_Cnt.NMKOFGHHAEA_SetArrayValue(ref data.AHCFGOGCJKI_St.JJKBBFEJFGO_Cnt.NPBIKIMOKME_DOoC, _OIPCCBHIKIA_index, _JBGEEPFKIGG_val);
								}, ref isInvalid);
								IBCGPBOGOGP_ReadIntArray(b3, "dopu", 0, data.AHCFGOGCJKI_St.JJKBBFEJFGO_Cnt.MENIJIHIBDC_Dopu.Length, (int _OIPCCBHIKIA_index, int _JBGEEPFKIGG_val) =>
								{
									//0x1AF0A40
									data.AHCFGOGCJKI_St.JJKBBFEJFGO_Cnt.NMKOFGHHAEA_SetArrayValue(ref data.AHCFGOGCJKI_St.JJKBBFEJFGO_Cnt.MENIJIHIBDC_Dopu, _OIPCCBHIKIA_index, _JBGEEPFKIGG_val);
								}, ref isInvalid);
								IBCGPBOGOGP_ReadIntArray(b3, "chgc", 0, data.AHCFGOGCJKI_St.JJKBBFEJFGO_Cnt.FCAHJGHCHAL_Chgc.Length, (int _OIPCCBHIKIA_index, int _JBGEEPFKIGG_val) =>
								{
									//0x1AF0AA8
									data.AHCFGOGCJKI_St.JJKBBFEJFGO_Cnt.NMKOFGHHAEA_SetArrayValue(ref data.AHCFGOGCJKI_St.JJKBBFEJFGO_Cnt.FCAHJGHCHAL_Chgc, _OIPCCBHIKIA_index, _JBGEEPFKIGG_val);
								}, ref isInvalid);
								IBCGPBOGOGP_ReadIntArray(b3, "gift", 0, data.AHCFGOGCJKI_St.JJKBBFEJFGO_Cnt.EFEJCLLLEJJ_Gift.Length, (int _OIPCCBHIKIA_index, int _JBGEEPFKIGG_val) =>
								{
									//0x1AF0B10
									data.AHCFGOGCJKI_St.JJKBBFEJFGO_Cnt.NMKOFGHHAEA_SetArrayValue(ref data.AHCFGOGCJKI_St.JJKBBFEJFGO_Cnt.EFEJCLLLEJJ_Gift, _OIPCCBHIKIA_index, _JBGEEPFKIGG_val);
								}, ref isInvalid);
								IBCGPBOGOGP_ReadIntArray(b3, "medel_shop", 0, data.AHCFGOGCJKI_St.JJKBBFEJFGO_Cnt.LGHCJFCCGFI_MedelShop.Length, (int _OIPCCBHIKIA_index, int _JBGEEPFKIGG_val) =>
								{
									//0x1AF0B78
									data.AHCFGOGCJKI_St.JJKBBFEJFGO_Cnt.NMKOFGHHAEA_SetArrayValue(ref data.AHCFGOGCJKI_St.JJKBBFEJFGO_Cnt.LGHCJFCCGFI_MedelShop, _OIPCCBHIKIA_index, _JBGEEPFKIGG_val);
								}, ref isInvalid);

								if(ReadVersion == 2)
								{
									System.Func<int, int> fixFunc = (int v) =>
									{
										if(v < 0)
											v = 0;
										if(v > 1000)
											v = 0;
										if(v > 100)
											v = 100;
										return v;
									};
									for(int idx = 0; idx < data.AHCFGOGCJKI_St.JJKBBFEJFGO_Cnt.DENIHAKEBCA_VOpC.Length; idx++)
									{
										data.AHCFGOGCJKI_St.JJKBBFEJFGO_Cnt.NADMCFKICOE_SetVOpCValue(idx, fixFunc(data.AHCFGOGCJKI_St.JJKBBFEJFGO_Cnt.GNHALIDFACE_GetVOpCValue(idx)));
									}
									for(int idx = 0; idx < data.AHCFGOGCJKI_St.JJKBBFEJFGO_Cnt.IKJLNHDBGHI_DOpC.Length; idx++)
									{
										data.AHCFGOGCJKI_St.JJKBBFEJFGO_Cnt.MPEEACOJILJ_SetDOpCValue(idx, fixFunc(data.AHCFGOGCJKI_St.JJKBBFEJFGO_Cnt.EJNFMAAKCMH_GetDOpCValue(idx)));
									}
									for(int idx = 0; idx < data.AHCFGOGCJKI_St.JJKBBFEJFGO_Cnt.NPBIKIMOKME_DOoC.Length; idx++)
									{
										data.AHCFGOGCJKI_St.JJKBBFEJFGO_Cnt.NDMPJNBKHPM_SetDOocValue(idx, fixFunc(data.AHCFGOGCJKI_St.JJKBBFEJFGO_Cnt.MLBJKMLMLEG_GetDOocValue(idx)));
									}
									for(int idx = 0; idx < data.AHCFGOGCJKI_St.JJKBBFEJFGO_Cnt.MENIJIHIBDC_Dopu.Length; idx++)
									{
										data.AHCFGOGCJKI_St.JJKBBFEJFGO_Cnt.FBJIMCNJPOB_SetDopuValue(idx, fixFunc(data.AHCFGOGCJKI_St.JJKBBFEJFGO_Cnt.FGGFDPFMKAF_GetDopuValue(idx)));
									}
									for(int idx = 0; idx < data.AHCFGOGCJKI_St.JJKBBFEJFGO_Cnt.FCAHJGHCHAL_Chgc.Length; idx++)
									{
										data.AHCFGOGCJKI_St.JJKBBFEJFGO_Cnt.PODJFPCEDLM_SetChgcValue(idx, fixFunc(data.AHCFGOGCJKI_St.JJKBBFEJFGO_Cnt.KGFLHCHAIGO_GetChgcValue(idx)));
									}
									for(int idx = 0; idx < data.AHCFGOGCJKI_St.JJKBBFEJFGO_Cnt.EFEJCLLLEJJ_Gift.Length; idx++)
									{
										data.AHCFGOGCJKI_St.JJKBBFEJFGO_Cnt.PBEDBGMNGHB_SetGiftValue(idx, fixFunc(data.AHCFGOGCJKI_St.JJKBBFEJFGO_Cnt.IKKOANOJHLB_GetGiftValue(idx)));
									}
									for(int idx = 0; idx < data.AHCFGOGCJKI_St.JJKBBFEJFGO_Cnt.LGHCJFCCGFI_MedelShop.Length; idx++)
									{
										data.AHCFGOGCJKI_St.JJKBBFEJFGO_Cnt.CLOMILDLINH_SetMedalShopValue(idx, fixFunc(data.AHCFGOGCJKI_St.JJKBBFEJFGO_Cnt.CDNJPNFGHOG_GetMedalShopValue(idx)));
									}
								}
							}
							if (b2.BBAJPINMOEP_Contains(AFEHLCGHAEE_Strings.COGJONKKALB_ms))
							{
								EDOHBJAPLPF_JsonData b3 = b2[AFEHLCGHAEE_Strings.COGJONKKALB_ms];
								int cnt = b3.HNBFOAJIIAL_Count;
								if (data.AHCFGOGCJKI_St.HDMADAHNLDN_Missions.Count < cnt)
								{
									cnt = data.AHCFGOGCJKI_St.HDMADAHNLDN_Missions.Count;
								}
								for(int j = 0; j < cnt; j++)
								{
									HKMBGGGMEKA data2 = data.AHCFGOGCJKI_St.HDMADAHNLDN_Missions[j];
									EDOHBJAPLPF_JsonData b4 = b3[j];
									data2.PPFNGGCBJKC_id = CJAENOMGPDA_ReadInt(b4, AFEHLCGHAEE_Strings.PPFNGGCBJKC_id, 0, ref isInvalid);
									data2.JOMGCCBFKEF_MissionId = CJAENOMGPDA_ReadInt(b4, AFEHLCGHAEE_Strings.KLMIFEKNBLL_m_id, 0, ref isInvalid);
									data2.CMCKNKKCNDK_status = CJAENOMGPDA_ReadInt(b4, AFEHLCGHAEE_Strings.EALOBDHOCHP_stat, 0, ref isInvalid);
									data2.HMFFHLPNMPH_count = CJAENOMGPDA_ReadInt(b4, AFEHLCGHAEE_Strings.BFINGCJHOHI_cnt, 0, ref isInvalid);
									data2.OPGPHAEMIDO_Dt = DKMPHAPBDLH_ReadLong(b4, AFEHLCGHAEE_Strings.MIKCFEHGNJB_dt, 0, ref isInvalid);
									data2.CCKELABMHIO_Ac = CJAENOMGPDA_ReadInt(b4, AFEHLCGHAEE_Strings.ONOPACPKFPK_ac, 0, ref isInvalid);
								}
							}
							if(b2.BBAJPINMOEP_Contains(AFEHLCGHAEE_Strings.NMHGCOLMPJA_ln))
							{
								IBCGPBOGOGP_ReadIntArray(b2, AFEHLCGHAEE_Strings.NMHGCOLMPJA_ln, 0, 8, (int _OIPCCBHIKIA_index, int _JBGEEPFKIGG_val) =>
								{
									//0x1AF07D8
									data.AHCFGOGCJKI_St.BMJGIEJPDLM(_OIPCCBHIKIA_index, _JBGEEPFKIGG_val);
								}, ref isInvalid);
							}
						}
						if(b.BBAJPINMOEP_Contains(AFEHLCGHAEE_Strings.JGOHPDKCJKB_rw))
						{
							EDOHBJAPLPF_JsonData b2 = b[AFEHLCGHAEE_Strings.JGOHPDKCJKB_rw];
							int cnt = b2.HNBFOAJIIAL_Count;
							if(data.AHJNPEAMCCH_rewards.Count < cnt)
							{
								cnt = data.AHJNPEAMCCH_rewards.Count;
							}
							for(int j = 0; j < cnt; j++)
							{
								OCLGCNPBNHE data2 = data.AHJNPEAMCCH_rewards[j];
								EDOHBJAPLPF_JsonData b3 = b2[j];
								data2.PPFNGGCBJKC_id = CJAENOMGPDA_ReadInt(b3, AFEHLCGHAEE_Strings.PPFNGGCBJKC_id, 0, ref isInvalid);
								data2.MIKCFEHGNJB_dt = DKMPHAPBDLH_ReadLong(b3, AFEHLCGHAEE_Strings.MIKCFEHGNJB_dt, 0, ref isInvalid);
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
	public override void BMGGKONLFIC_Copy(KLFDBFMNLBL_ServerSaveBlock GPBJHKLFCEP)
	{
		NFMHCLHEMHB_Bingo b = GPBJHKLFCEP as NFMHCLHEMHB_Bingo;
		for(int i = 0; i < MPCJGPEBCCD.Count; i++)
		{
			MPCJGPEBCCD[i].ODDIHGPONFL_Copy(b.MPCJGPEBCCD[i]);
		}
	}

	// // RVA: 0x1AEEAE0 Offset: 0x1AEEAE0 VA: 0x1AEEAE0 Slot: 8
	public override bool AGBOGBEOFME(KLFDBFMNLBL_ServerSaveBlock GPBJHKLFCEP)
	{
		NFMHCLHEMHB_Bingo other = GPBJHKLFCEP as NFMHCLHEMHB_Bingo;
		if(MPCJGPEBCCD.Count != other.MPCJGPEBCCD.Count)
			return false;
		for(int i = 0; i < MPCJGPEBCCD.Count; i++)
		{
			if(!MPCJGPEBCCD[i].AGBOGBEOFME(other.MPCJGPEBCCD[i]))
				return false;
		}
		return true;
	}

	// // RVA: 0x1AEEE2C Offset: 0x1AEEE2C VA: 0x1AEEE2C Slot: 10
	//public override void AGHKODFKOJI(BHBONAHFKHD JBBHNIACMFJ, KLFDBFMNLBL_ServerSaveBlock _GJLFANGDGCL_Target, long _MCKEOKFMLAH_SaveId);

	protected override bool TryUpdateVersion(EDOHBJAPLPF_JsonData block, int readVersion)
	{
		if(readVersion == 2)
		{
			ReadVersion = 2;
			return true;
		}
		return false;
	}
}
