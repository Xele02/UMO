
using System.Collections.Generic;
using UnityEngine;

[System.Obsolete("Use MMPBPOIFDAF_Scene", true)]
public class MMPBPOIFDAF { }
public class MMPBPOIFDAF_Scene : KLFDBFMNLBL_ServerSaveBlock
{
	public class PMKOFEIONEG
	{
		public static int FBGGEFFJJHB_xor = 0x3438a712; // 0x0
		public static int FCEJCHGLFGN = 0x7123348a; // 0x4
		private long JMFGGKLPKOM; // 0x8
		private long OJKBLADGDBM; // 0x10
		public byte[] PDNIFBEGMHC_Mb = new byte[15]; // 0x18
		public byte[] EMOJHJGHJLN_Sb = new byte[50]; // 0x1C
		private uint NHJDFCIMPEB; // 0x20
		private uint KNABHOOKLOH; // 0x24
		private int EHOIENNDEDH_IdCrypted; // 0x28
		private int DGOIBJDJHFH; // 0x2C
		private int OPLKJKAIFPF_NumBoardCrypted; // 0x30
		private int FEIKCJFNEGC_LuckCrypted2; // 0x34
		private int AOGCPFFLHHN; // 0x38
		public int ANAJIAENLNB_lv; // 0x3C
		public bool LHMOAJAIJCO_is_new; // 0x40
		private int IBFKAGCMCFA; // 0x44
		private int NKCNFBCEEOI_LuckCrypted; // 0x48
		private int KALBBDLPCDJ; // 0x4C
		private int NPHDJGPDJGK; // 0x50
		private int ELMLPFGPIIM_LeafCrypted; // 0x54
		private int MDIGCJGJBBA_LeafCheck; // 0x58
		public int DOAAOOHGODJ_PstNew; // 0x5C

		public int PPFNGGCBJKC_id { get { return EHOIENNDEDH_IdCrypted ^ FBGGEFFJJHB_xor; } set { EHOIENNDEDH_IdCrypted = value ^ FBGGEFFJJHB_xor; } } //0x196B428 DEMEPMAEJOO 0x196BF80 HIGKAIDMOKN
		public long BEBJKJKBOGH_date { get { return OJKBLADGDBM ^ FBGGEFFJJHB_xor; } set { OJKBLADGDBM = value ^ FBGGEFFJJHB_xor; JMFGGKLPKOM = value ^ FCEJCHGLFGN; } } //0x1969A80 DIAPHCJBPFD_get_date 0x196D63C IHAIKPNEEJE
		public bool IHIAFIHAAPO_Unlocked { get { return BEBJKJKBOGH_date != 0; } } //0x196A33C IIPKLJJIDNG
		public int MJBODMOLOBC_luck { get { return NKCNFBCEEOI_LuckCrypted ^ FBGGEFFJJHB_xor; } set { NKCNFBCEEOI_LuckCrypted = value ^ FBGGEFFJJHB_xor; FEIKCJFNEGC_LuckCrypted2 = value ^ FCEJCHGLFGN; } } //0x196CA5C JDPBFBEBJOK 0x196D6F4 PNKGEPNKKBM
		// Mlt
		public int JPIPENJGGDD_NumBoard { get { return OPLKJKAIFPF_NumBoardCrypted ^ FBGGEFFJJHB_xor; } set { OPLKJKAIFPF_NumBoardCrypted = value ^ FBGGEFFJJHB_xor; DGOIBJDJHFH = value ^ FCEJCHGLFGN; } } //0x196A418 FBLKAMOKPPP 0x196D7A0 BEEPHNBJGLI
		public int IELENGDJPHF_Ulk { get { return AOGCPFFLHHN ^ FBGGEFFJJHB_xor; } set { AOGCPFFLHHN = value ^ FBGGEFFJJHB_xor; IBFKAGCMCFA = value ^ FCEJCHGLFGN; } } //0x196CAF4 OPNNJFMBCKC 0x196D84C CGAEHPNGCAK
		public int CDOBCKMHAOK_inf { get { return KALBBDLPCDJ ^ FBGGEFFJJHB_xor; } set { KALBBDLPCDJ = value ^ FBGGEFFJJHB_xor; NPHDJGPDJGK = value ^ FCEJCHGLFGN; } } //0x196CB8C BKKAHGMBICD 0x196D8F8 LIIPKILBICO
		public int DMNIMMGGJJJ_Leaf { get { return ELMLPFGPIIM_LeafCrypted ^ FBGGEFFJJHB_xor; } set { ELMLPFGPIIM_LeafCrypted = value ^ FBGGEFFJJHB_xor; MDIGCJGJBBA_LeafCheck = value ^ FCEJCHGLFGN; } } //0x196B0E4 CJCDKIKDBNP 0x196D9A4 CCGHKFJEFCB

		// // RVA: 0x196ADCC Offset: 0x196ADCC VA: 0x196ADCC
		public void CHDJAACPMJK_SetBit(ref byte[] MNHKNPDFMJL, int _OIPCCBHIKIA_index)
		{
			MNHKNPDFMJL[_OIPCCBHIKIA_index >> 3] |= (byte)(1 << (_OIPCCBHIKIA_index & 0x7));
		}

		// // RVA: 0x1971BE8 Offset: 0x1971BE8 VA: 0x1971BE8
		// public void JPJDCAKKAOB(ref byte[] MNHKNPDFMJL, int _OIPCCBHIKIA_index) { }

		// // RVA: 0x1971C48 Offset: 0x1971C48 VA: 0x1971C48
		public bool FAGMBGKOIFI_HasBit(byte[] MNHKNPDFMJL, int _OIPCCBHIKIA_index)
		{
			return ((1 << (_OIPCCBHIKIA_index & 0x7)) & MNHKNPDFMJL[_OIPCCBHIKIA_index >> 3]) != 0;
		}

		// // RVA: 0x1971CA8 Offset: 0x1971CA8 VA: 0x1971CA8
		// public void HPNIPCKNHLL(int _OIPCCBHIKIA_index) { }

		// // RVA: 0x1971CB4 Offset: 0x1971CB4 VA: 0x1971CB4
		// public void MMGLOEGODKD(int _OIPCCBHIKIA_index) { }

		// // RVA: 0x1971CC0 Offset: 0x1971CC0 VA: 0x1971CC0
		public bool IEPGLOIICLJ(int _OIPCCBHIKIA_index)
		{
			return FAGMBGKOIFI_HasBit(PDNIFBEGMHC_Mb, _OIPCCBHIKIA_index);
		}

		// // RVA: 0x1971CCC Offset: 0x1971CCC VA: 0x1971CCC
		// public void BNHNLIEOGBA(int _OIPCCBHIKIA_index) { }

		// // RVA: 0x1971CD8 Offset: 0x1971CD8 VA: 0x1971CD8
		// public void EOPDKOCOLPI(int _OIPCCBHIKIA_index) { }

		// // RVA: 0x196ADC0 Offset: 0x196ADC0 VA: 0x196ADC0
		public bool PJLNENPKEDD(int _OIPCCBHIKIA_index)
		{
			return FAGMBGKOIFI_HasBit(EMOJHJGHJLN_Sb, _OIPCCBHIKIA_index);
		}

		// // RVA: 0x196BEF4 Offset: 0x196BEF4 VA: 0x196BEF4
		public PMKOFEIONEG()
		{
			LHPDDGIJKNB_Reset();
		}

		// // RVA: 0x1971CE4 Offset: 0x1971CE4 VA: 0x1971CE4
		public void LHPDDGIJKNB_Reset()
		{
			PPFNGGCBJKC_id = 0;
			BEBJKJKBOGH_date = 0;
			MJBODMOLOBC_luck = 0;
			JPIPENJGGDD_NumBoard = 0;
			IELENGDJPHF_Ulk = 0;
			ANAJIAENLNB_lv = 0;
			LHMOAJAIJCO_is_new = false;
			CDOBCKMHAOK_inf = 0;
			DMNIMMGGJJJ_Leaf = 0;
			DOAAOOHGODJ_PstNew = 0;
			for(int i = 0; i < PDNIFBEGMHC_Mb.Length; i++)
			{
				PDNIFBEGMHC_Mb[i] = 0;
			}
			for(int i = 0; i < EMOJHJGHJLN_Sb.Length; i++)
			{
				EMOJHJGHJLN_Sb[i] = 0;
			}
			IDBDAPPJOND();
		}

		// // RVA: 0x196E140 Offset: 0x196E140 VA: 0x196E140
		public bool AGBOGBEOFME(PMKOFEIONEG OIKJFMGEICL)
		{
			if(PPFNGGCBJKC_id != OIKJFMGEICL.PPFNGGCBJKC_id ||
				BEBJKJKBOGH_date != OIKJFMGEICL.BEBJKJKBOGH_date ||
				MJBODMOLOBC_luck != OIKJFMGEICL.MJBODMOLOBC_luck ||
				JPIPENJGGDD_NumBoard != OIKJFMGEICL.JPIPENJGGDD_NumBoard ||
				IELENGDJPHF_Ulk != OIKJFMGEICL.IELENGDJPHF_Ulk ||
				LHMOAJAIJCO_is_new != OIKJFMGEICL.LHMOAJAIJCO_is_new ||
				ANAJIAENLNB_lv != OIKJFMGEICL.ANAJIAENLNB_lv ||
				CDOBCKMHAOK_inf != OIKJFMGEICL.CDOBCKMHAOK_inf ||
				DMNIMMGGJJJ_Leaf != OIKJFMGEICL.DMNIMMGGJJJ_Leaf ||
				DOAAOOHGODJ_PstNew != OIKJFMGEICL.DOAAOOHGODJ_PstNew)
				return false;
			for(int i = 0; i < PDNIFBEGMHC_Mb.Length; i++)
			{
				if(PDNIFBEGMHC_Mb[i] != OIKJFMGEICL.PDNIFBEGMHC_Mb[i])
					return false;
			}
			for(int i = 0; i < EMOJHJGHJLN_Sb.Length; i++)
			{
				if(EMOJHJGHJLN_Sb[i] != OIKJFMGEICL.EMOJHJGHJLN_Sb[i])
					return false;
			}
			return true;
		}

		// // RVA: 0x196DBEC Offset: 0x196DBEC VA: 0x196DBEC
		public void ODDIHGPONFL_Copy(PMKOFEIONEG GPBJHKLFCEP)
		{
			PPFNGGCBJKC_id = GPBJHKLFCEP.PPFNGGCBJKC_id;
			BEBJKJKBOGH_date = GPBJHKLFCEP.BEBJKJKBOGH_date;
			ANAJIAENLNB_lv = GPBJHKLFCEP.ANAJIAENLNB_lv;
			MJBODMOLOBC_luck = GPBJHKLFCEP.MJBODMOLOBC_luck;
			JPIPENJGGDD_NumBoard = GPBJHKLFCEP.JPIPENJGGDD_NumBoard;
			IELENGDJPHF_Ulk = GPBJHKLFCEP.IELENGDJPHF_Ulk;
			LHMOAJAIJCO_is_new = GPBJHKLFCEP.LHMOAJAIJCO_is_new;
			NHJDFCIMPEB = GPBJHKLFCEP.NHJDFCIMPEB;
			KNABHOOKLOH = GPBJHKLFCEP.KNABHOOKLOH;
			CDOBCKMHAOK_inf = GPBJHKLFCEP.CDOBCKMHAOK_inf;
			DMNIMMGGJJJ_Leaf = GPBJHKLFCEP.DMNIMMGGJJJ_Leaf;
			DOAAOOHGODJ_PstNew = GPBJHKLFCEP.DOAAOOHGODJ_PstNew;
			for(int i = 0; i < PDNIFBEGMHC_Mb.Length; i++)
			{
				PDNIFBEGMHC_Mb[i] = GPBJHKLFCEP.PDNIFBEGMHC_Mb[i];
			}
			for(int i = 0; i < EMOJHJGHJLN_Sb.Length; i++)
			{
				EMOJHJGHJLN_Sb[i] = GPBJHKLFCEP.EMOJHJGHJLN_Sb[i];
			}
		}

		// // RVA: 0x196E8D8 Offset: 0x196E8D8 VA: 0x196E8D8
		// public void AGHKODFKOJI(BHBONAHFKHD JBBHNIACMFJ, string _JIKKNHIAEKG_BlockName, string MJBACHKCIHA, int _OIPCCBHIKIA_index, MMPBPOIFDAF_Scene.PMKOFEIONEG _OHMCIEMIKCE_t, bool KFCGIKHEEMB) { }

		// // RVA: 0x196AE2C Offset: 0x196AE2C VA: 0x196AE2C
		public void IDBDAPPJOND()
		{
			NHJDFCIMPEB = CEDHHAGBIBA.CAOGDCBPBAN(PDNIFBEGMHC_Mb);
			KNABHOOKLOH = CEDHHAGBIBA.CAOGDCBPBAN(EMOJHJGHJLN_Sb);
			ANAJIAENLNB_lv = CEDHHAGBIBA.OGPFNHOKONH_GetNumBitActive(PDNIFBEGMHC_Mb) + 1;
		}

		// // RVA: 0x1971698 Offset: 0x1971698 VA: 0x1971698
		// public FENCAJJBLBH PFAKPFKJJKA() { }

		// // RVA: 0x1971E34 Offset: 0x1971E34 VA: 0x1971E34
		public bool OFNNNEMCJNN()
		{
			TodoLogger.LogError(TodoLogger.DbIntegrityCheck, "OFNNNEMCJNN");
			return false;
		}

		// // RVA: 0x196A4B0 Offset: 0x196A4B0 VA: 0x196A4B0
		public void OEBOPKCCEEO(int _JPIPENJGGDD_NumBoard)
		{
			if(_JPIPENJGGDD_NumBoard == 0)
				DOAAOOHGODJ_PstNew = 1;
			else if(_JPIPENJGGDD_NumBoard == 1)
				DOAAOOHGODJ_PstNew = DOAAOOHGODJ_PstNew | 2;
			else
				DOAAOOHGODJ_PstNew = 3;
		}

		// // RVA: 0x197210C Offset: 0x197210C VA: 0x197210C
		public bool JECJALJEDPP(int _INDDJNMPONH_type)
		{
			return (((_INDDJNMPONH_type + 1) & DOAAOOHGODJ_PstNew) & 3) != 0;
		}

		// // RVA: 0x1972124 Offset: 0x1972124 VA: 0x1972124
		public void BILHHMGCPFC(int _INDDJNMPONH_type)
		{
			DOAAOOHGODJ_PstNew &= _INDDJNMPONH_type == 0 ? 2 : 1;
		}

		// // RVA: 0x1972140 Offset: 0x1972140 VA: 0x1972140
		public void DDLEICINOHK_Unlock(long _BEBJKJKBOGH_date, int _JKONPJKILCH_inventory_id)
		{
			BEBJKJKBOGH_date = _BEBJKJKBOGH_date;
			JPIPENJGGDD_NumBoard = 0;
			IELENGDJPHF_Ulk = 0;
			MJBODMOLOBC_luck = 0;
			LHMOAJAIJCO_is_new = true;
			CDOBCKMHAOK_inf = 0;
			DMNIMMGGJJJ_Leaf = 0;
			for(int i = 0; i < PDNIFBEGMHC_Mb.Length; i++)
			{
				PDNIFBEGMHC_Mb[i] = 0;
			}
			for(int i = 0; i < EMOJHJGHJLN_Sb.Length; i++)
			{
				EMOJHJGHJLN_Sb[i] = 0;
			}
		}

		// // RVA: 0x1972278 Offset: 0x1972278 VA: 0x1972278
		public void DJNPIJPHKKJ(long _BEBJKJKBOGH_date, int _JKONPJKILCH_inventory_id)
		{
			BEBJKJKBOGH_date = _BEBJKJKBOGH_date;
			JPIPENJGGDD_NumBoard = 1;
			IELENGDJPHF_Ulk = 1;
			MJBODMOLOBC_luck = 0;
			LHMOAJAIJCO_is_new = true;
			CDOBCKMHAOK_inf = 0;
			DMNIMMGGJJJ_Leaf = 0;
			for(int i = 0; i < PDNIFBEGMHC_Mb.Length; i++)
			{
				PDNIFBEGMHC_Mb[i] = 0;
			}
			for(int i = 0; i < EMOJHJGHJLN_Sb.Length; i++)
			{
				EMOJHJGHJLN_Sb[i] = 0;
			}
		}

		// // RVA: 0x19723B0 Offset: 0x19723B0 VA: 0x19723B0
		// public int HNNOJNHDNLF(int _JPJNKNOJBMM_Mlt) { }

		// // RVA: 0x19723F4 Offset: 0x19723F4 VA: 0x19723F4
		public bool LMLDPHIAOPH(int _JPJNKNOJBMM_Mlt, int BMIKDIOLMCF)
		{
			if(_JPJNKNOJBMM_Mlt < JPIPENJGGDD_NumBoard)
			{
				if(BMIKDIOLMCF <= JPIPENJGGDD_NumBoard - _JPJNKNOJBMM_Mlt - CDOBCKMHAOK_inf)
				{
					CDOBCKMHAOK_inf += BMIKDIOLMCF;
					return true;
				}
			}
			return false;
		}
	}
	private const int ECFEMKGFDCE_CurrentVersion = 3;
	private const int MJCBKPFKLIN = 3;
	public static string POFDDFCGEGP_Underscore = "_"; // 0x0
	private const int CPDDEFMBHOM = 6000;
	private const int JBCJOLMDAOD = 100;

	public List<PMKOFEIONEG> OPIBAPEGCLA_Scenes { get; private set; } // 0x24 OAKOEGLENEJ KHGLIMIOIEJ HELEKCPEPLE
	public override bool DMICHEJIAJL { get { return true; } } // 0x1971B6C NFKFOODCJJB

	// // RVA: 0x1969998 Offset: 0x1969998 VA: 0x1969998
	public int IGJAAIEAJPB_GetNumUnlockedScene()
	{
		int res = 0;
		for(int i = 0; i < OPIBAPEGCLA_Scenes.Count; i++)
		{
			if (OPIBAPEGCLA_Scenes[i].BEBJKJKBOGH_date != 0)
				res++;
		}
		return res;
	}

	// // RVA: 0x1969B1C Offset: 0x1969B1C VA: 0x1969B1C
	public int MPFLFKBNFEI_GetNumSceneAtLevelOrMore(LDDDBPNGGIN_Game _HNMMJINNHII_Game, MLIBEPGADJH_Scene _ECNHDEHADGL_Scene, int _FCDKJAKLGMB_TargetValue)
	{
		int res = 0;
		for(int i = 0; i < _ECNHDEHADGL_Scene.CDENCMNHNGA_table.Count; i++)
		{
			if(_ECNHDEHADGL_Scene.CDENCMNHNGA_table[i].PPEGAKEIEGM_Enabled == 2)
			{
				if(OPIBAPEGCLA_Scenes[i].BEBJKJKBOGH_date != 0)
				{
					if (_FCDKJAKLGMB_TargetValue <= OPIBAPEGCLA_Scenes[i].ANAJIAENLNB_lv)
						res++;
				}
			}
		}
		return res;
	}

	// // RVA: 0x1969CD8 Offset: 0x1969CD8 VA: 0x1969CD8
	public int NEAGFIEMLIL_GetSceneLevel(LDDDBPNGGIN_Game _HNMMJINNHII_Game, MLIBEPGADJH_Scene _ECNHDEHADGL_Scene, int _PPFNGGCBJKC_id)
	{
		if(_ECNHDEHADGL_Scene.CDENCMNHNGA_table[_PPFNGGCBJKC_id - 1].PPEGAKEIEGM_Enabled == 2)
		{
			if(OPIBAPEGCLA_Scenes[_PPFNGGCBJKC_id - 1].BEBJKJKBOGH_date != 0)
			{
				return OPIBAPEGCLA_Scenes[_PPFNGGCBJKC_id - 1].ANAJIAENLNB_lv;
			}
		}
		return 0;
	}

	// // RVA: 0x1969E34 Offset: 0x1969E34 VA: 0x1969E34
	public int BNNPJLPMLLK(LDDDBPNGGIN_Game _HNMMJINNHII_Game, MLIBEPGADJH_Scene _ECNHDEHADGL_Scene)
	{
		int res = 0;
		for(int i = 0; i < OPIBAPEGCLA_Scenes.Count; i++)
		{
            MLIBEPGADJH_Scene.KKLDOOJBJMN dbScene = _ECNHDEHADGL_Scene.CDENCMNHNGA_table[i];
			if(dbScene.PPEGAKEIEGM_Enabled == 2)
			{
				if(OPIBAPEGCLA_Scenes[i].BEBJKJKBOGH_date != 0)
				{
					int a = _HNMMJINNHII_Game.LAGGGIEIPEG(dbScene.EKLIPGELKCL_Rarity, true, dbScene.MCCIFLKCNKO_Feed);
					if(a <= OPIBAPEGCLA_Scenes[i].ANAJIAENLNB_lv)
						i++;
				}
			}
        }
		return res;
	}

	// // RVA: 0x196A0C8 Offset: 0x196A0C8 VA: 0x196A0C8
	public int FLPPOODHKAB(MLIBEPGADJH_Scene _ECNHDEHADGL_Scene, int _NDKJCDGHPLD_MasterVersion, int _LFPEIEOHABE_Pstv, bool DHOFGFAEJFM/* = false*/)
	{
		int res = 0;
		for(int i = 0; i < OPIBAPEGCLA_Scenes.Count; i++)
		{
			MLIBEPGADJH_Scene.KKLDOOJBJMN dbScene = _ECNHDEHADGL_Scene.CDENCMNHNGA_table[i];
			if(dbScene.PPEGAKEIEGM_Enabled == 2)
			{
				PMKOFEIONEG saveScene = OPIBAPEGCLA_Scenes[i];
				if(saveScene.IHIAFIHAAPO_Unlocked)
				{
					if(dbScene.LFPEIEOHABE_Pstv <= _NDKJCDGHPLD_MasterVersion && _LFPEIEOHABE_Pstv < dbScene.LFPEIEOHABE_Pstv)
					{
						if (res < dbScene.LFPEIEOHABE_Pstv)
							res = dbScene.LFPEIEOHABE_Pstv;
						if(DHOFGFAEJFM)
						{
							if(saveScene.JPIPENJGGDD_NumBoard == 1)
							{
								saveScene.DOAAOOHGODJ_PstNew = 3;
							}
							else if(saveScene.JPIPENJGGDD_NumBoard == 0)
							{
								saveScene.DOAAOOHGODJ_PstNew = 1;
							}
							else
							{
								saveScene.DOAAOOHGODJ_PstNew = 3;
							}
						}
					}
				}
			}
		}
		return res;
	}

	// // RVA: 0x196A4D8 Offset: 0x196A4D8 VA: 0x196A4D8
	public int HOLEDOLMJCB(int _PPFNGGCBJKC_id, MLIBEPGADJH_Scene _ECNHDEHADGL_Scene, int _INDDJNMPONH_type)
	{
		if (_PPFNGGCBJKC_id == 0)
			return 0;
		if (_PPFNGGCBJKC_id > OPIBAPEGCLA_Scenes.Count)
			return 0;
		if(_ECNHDEHADGL_Scene.FDIOFBGJKNO(_PPFNGGCBJKC_id))
		{
			int maxPoster = 50;
			if(IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database != null &&
				IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.EPAHOAKPAJJ_DecoItem != null)
			{
				maxPoster = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.EPAHOAKPAJJ_DecoItem.LPJLEHAJADA_GetIntParam("poster_have_max", 50);
			}
			PMKOFEIONEG saveData = OPIBAPEGCLA_Scenes[_PPFNGGCBJKC_id - 1];
			MLIBEPGADJH_Scene.KKLDOOJBJMN dbData = _ECNHDEHADGL_Scene.CDENCMNHNGA_table[_PPFNGGCBJKC_id - 1];
			if(saveData.IHIAFIHAAPO_Unlocked)
			{
				if(!dbData.FBJDHLGODPP_Sngl)
				{
					if (saveData.JPIPENJGGDD_NumBoard == 1)
						return 1;
					if (saveData.JPIPENJGGDD_NumBoard == 0)
						return _INDDJNMPONH_type == 0 ? 1 : 0;
				}
				else
				{
					if (_INDDJNMPONH_type == 0)
						return 0;
				}
				if (maxPoster < saveData.JPIPENJGGDD_NumBoard)
					return maxPoster;
				return saveData.JPIPENJGGDD_NumBoard;
			}
		}
		return 0;
	}

	// // RVA: 0x196A78C Offset: 0x196A78C VA: 0x196A78C
	private bool AHKLHIBIDHF(MLIBEPGADJH_Scene _ECNHDEHADGL_Scene, KOGHKIODHPA_Board _JEMMMJEJLNL_Board)
	{
		byte[] b = new byte[50];
		bool res = false;
		for(int i = 0; i < OPIBAPEGCLA_Scenes.Count; i++)
		{
			MLIBEPGADJH_Scene.KKLDOOJBJMN dbScene = _ECNHDEHADGL_Scene.CDENCMNHNGA_table[i];
			if(_JEMMMJEJLNL_Board.AKKIBDEENJH(dbScene.ILABPFOMEAG_Va) && OPIBAPEGCLA_Scenes[i].IHIAFIHAAPO_Unlocked)
			{
				int val = 99;
				if(OPIBAPEGCLA_Scenes[i].JPIPENJGGDD_NumBoard < 101)
				{
					val = OPIBAPEGCLA_Scenes[i].JPIPENJGGDD_NumBoard - 1;
					if(val < 1)
						continue;
				}
				if(OPIBAPEGCLA_Scenes[i].FAGMBGKOIFI_HasBit(OPIBAPEGCLA_Scenes[i].EMOJHJGHJLN_Sb, 0))
				{
					DMPDJFAGCPN_BoardLayout a = _JEMMMJEJLNL_Board.GPKFGCFHDHH(dbScene.AOPBAOJIOGO_Sb, false);
					if(a != null)
					{
						if(a.PDKGMFHIFML_Panels.Count > 1)
						{
							for(int j = 0; j < 50; j++)
							{
								b[i] = 0;
							}
							int l = 0;
							int m = 0;
							int f = -1;
							int n = 0;
							for(int j = 0; j < val; j++)
							{
								for(int k = a.PDKGMFHIFML_Panels.Count - 2; k > -1; k--)
								{
									if(OPIBAPEGCLA_Scenes[i].FAGMBGKOIFI_HasBit(OPIBAPEGCLA_Scenes[i].EMOJHJGHJLN_Sb, k + l))
									{
										if(f < 0)
											f = k;
										if(!(_JEMMMJEJLNL_Board.GJLBMELKHEM[dbScene.ILABPFOMEAG_Va - 1].JPJNKNOJBMM_Mlt <= j || m != 0))
										{
											m = 0;
											if(_JEMMMJEJLNL_Board.DDGNLCJGFJF_Object(a.PDKGMFHIFML_Panels[k].JBGEEPFKIGG_val).INDDJNMPONH_type == 19)
											{
												m = 1;
											}
										}
									}
								}
								if(l != 0)
								{
									n++;
									OPIBAPEGCLA_Scenes[i].CHDJAACPMJK_SetBit(ref b, n + f);
								}
								n += a.PDKGMFHIFML_Panels.Count - 1;
								l += a.PDKGMFHIFML_Panels.Count - 1;
							}
							if(n != a.PDKGMFHIFML_Panels.Count * val)
							{
								for(int j = 0; j < 50; j++)
								{
									OPIBAPEGCLA_Scenes[i].EMOJHJGHJLN_Sb[j] = b[j];
								}
								OPIBAPEGCLA_Scenes[i].IDBDAPPJOND();
								res = true;
							}
						}
					}
				}
			}
		}
		return res;
	}

	// // RVA: 0x196AEE4 Offset: 0x196AEE4 VA: 0x196AEE4
	public bool MBGEHFKKOEN_HasRarePlate(MLIBEPGADJH_Scene _ECNHDEHADGL_Scene)
	{
		int cnt = Mathf.Min(OPIBAPEGCLA_Scenes.Count, _ECNHDEHADGL_Scene.CDENCMNHNGA_table.Count);
		for(int i = 0; i < cnt; i++)
		{
			MLIBEPGADJH_Scene.KKLDOOJBJMN dbScene = _ECNHDEHADGL_Scene.CDENCMNHNGA_table[i];
			PMKOFEIONEG saveScene = OPIBAPEGCLA_Scenes[i];
			if(saveScene.IHIAFIHAAPO_Unlocked)
			{
				if (dbScene.EKLIPGELKCL_Rarity > 4)
					return true;
			}
		}
		return false;
	}

	// // RVA: 0x196B17C Offset: 0x196B17C VA: 0x196B17C
	public List<MLIBEPGADJH_Scene.KKLDOOJBJMN> NFFGMOFIBDH_GetAllUnlockedRareScenes(MLIBEPGADJH_Scene _ECNHDEHADGL_Scene)
	{
		List<MLIBEPGADJH_Scene.KKLDOOJBJMN> res = new List<MLIBEPGADJH_Scene.KKLDOOJBJMN>();
		for(int i = 0; i < OPIBAPEGCLA_Scenes.Count; i++)
		{
			MLIBEPGADJH_Scene.KKLDOOJBJMN dbScene = _ECNHDEHADGL_Scene.CDENCMNHNGA_table[OPIBAPEGCLA_Scenes[i].PPFNGGCBJKC_id - 1];
			if(dbScene.PPEGAKEIEGM_Enabled > 1)
			{
				if(dbScene.EKLIPGELKCL_Rarity > 5)
				{
					if(OPIBAPEGCLA_Scenes[i].IHIAFIHAAPO_Unlocked)
					{
						res.Add(dbScene);
					}
				}
			}
		}
		return res;
	}

	// // RVA: 0x196B4C0 Offset: 0x196B4C0 VA: 0x196B4C0
	public bool GOFAPKBNNCL_HasRareSceneWithCostumeForDivaUnlocked(int DPKCMAHGHNI)
    {
		OKGLGHCBCJP_Database db = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database;
		if (db != null)
		{
			MLIBEPGADJH_Scene dbScenes = db.ECNHDEHADGL_Scene;
			KMOGDEOKHPG_Episode dbEps = db.MOLEPBNJAGE_Episode;
			LCLCCHLDNHJ_Costume dbCos = db.MFPNGNMFEAL_Costume;
			List<MLIBEPGADJH_Scene.KKLDOOJBJMN> l = NFFGMOFIBDH_GetAllUnlockedRareScenes(dbScenes);
			for(int i = 0; i < l.Count; i++)
			{
				if(l[i].KELFCMEOPPM_EpisodeId > 0)
				{
					HMGPODKEFBA_EpisodeInfo ep = dbEps.BBAJKJPKOHD_EpisodeList[l[i].KELFCMEOPPM_EpisodeId - 1];
					for(int j = 0; j < ep.HHJGBJCIFON_Rewards.Count; j++)
					{
						JNIKPOIKFAC_Reward reward = dbEps.LFAAEPAAEMB_Rewards[ep.HHJGBJCIFON_Rewards[j]];
						if(EKLNMHFCAOI.BKHFLDMOGBD_GetItemCategory(reward.KIJAPOFAGPN_ItemId) == EKLNMHFCAOI.FKGCBLHOOCL_Category.KBHGPMNGALJ_5_Costume)
						{
							int itemId = EKLNMHFCAOI.DEACAHNLMNI_getItemId(reward.KIJAPOFAGPN_ItemId);
							if(itemId > 0)
							{
								LCLCCHLDNHJ_Costume.ILODJKFJJDO_CostumeInfo cos = dbCos.CDENCMNHNGA_table[itemId - 1];
								if (cos.AHHJLDLAPAN_DivaId == DPKCMAHGHNI)
									return true;
							}
						}
					}
				}
			}
		}
        return false;
    }

	// // RVA: 0x196B8D8 Offset: 0x196B8D8 VA: 0x196B8D8
	// public int JKMOIKPIGBA() { }

	// // RVA: 0x196BAA8 Offset: 0x196BAA8 VA: 0x196BAA8
	// public int JPFAAHCMCEO() { }

	// // RVA: 0x196BD54 Offset: 0x196BD54 VA: 0x196BD54
	public MMPBPOIFDAF_Scene()
	{
		OPIBAPEGCLA_Scenes = new List<PMKOFEIONEG>(6000);
		KMBPACJNEOF_Reset();
	}

	// // RVA: 0x196BDF8 Offset: 0x196BDF8 VA: 0x196BDF8 Slot: 4
	public override void KMBPACJNEOF_Reset()
	{
		OPIBAPEGCLA_Scenes.Clear();
		for(int i = 0; i < 6000; i++)
		{
			PMKOFEIONEG data = new PMKOFEIONEG();
			data.PPFNGGCBJKC_id = i + 1;
			OPIBAPEGCLA_Scenes.Add(data);
		}
	}

	// // RVA: 0x196C01C Offset: 0x196C01C VA: 0x196C01C Slot: 5
	public override void OKJPIBHMKMJ(EDOHBJAPLPF_JsonData OILEIIEIBHP, long _MCKEOKFMLAH_SaveId)
	{
		EDOHBJAPLPF_JsonData data = new EDOHBJAPLPF_JsonData();
		data[POFDDFCGEGP_Underscore] = "";
		for(int i = 0; i < OPIBAPEGCLA_Scenes.Count; i++)
		{
			if(OPIBAPEGCLA_Scenes[i].BEBJKJKBOGH_date != 0)
			{
				EDOHBJAPLPF_JsonData data2 = new EDOHBJAPLPF_JsonData();
				data2[AFEHLCGHAEE_Strings.PPFNGGCBJKC_id] = OPIBAPEGCLA_Scenes[i].PPFNGGCBJKC_id;
				data2[AFEHLCGHAEE_Strings.BEBJKJKBOGH_date] = OPIBAPEGCLA_Scenes[i].BEBJKJKBOGH_date;
				data2[AFEHLCGHAEE_Strings.ANAJIAENLNB_lv] = OPIBAPEGCLA_Scenes[i].ANAJIAENLNB_lv;
				data2[AFEHLCGHAEE_Strings.MJBODMOLOBC_luck] = OPIBAPEGCLA_Scenes[i].MJBODMOLOBC_luck;
				data2[AFEHLCGHAEE_Strings.KLJGEHBKMMG_new] = OPIBAPEGCLA_Scenes[i].LHMOAJAIJCO_is_new ? 1 : 0;
				data2[AFEHLCGHAEE_Strings.ALMNMBDELDB_mlt] = OPIBAPEGCLA_Scenes[i].JPIPENJGGDD_NumBoard;
				data2[AFEHLCGHAEE_Strings.PMANOMLMICI_ulk] = OPIBAPEGCLA_Scenes[i].IELENGDJPHF_Ulk;
				data2[AFEHLCGHAEE_Strings.CDOBCKMHAOK_inf] = OPIBAPEGCLA_Scenes[i].CDOBCKMHAOK_inf;
				data2["leaf"] = OPIBAPEGCLA_Scenes[i].DMNIMMGGJJJ_Leaf;
				data2[AFEHLCGHAEE_Strings.EGPELMDJDCC_pst_new] = OPIBAPEGCLA_Scenes[i].DOAAOOHGODJ_PstNew;
				data2[AFEHLCGHAEE_Strings.DANMJLOBLIE_mb] = CEDHHAGBIBA.EHNMFLADJKG_ByteArrayToString(OPIBAPEGCLA_Scenes[i].PDNIFBEGMHC_Mb);
				data2[AFEHLCGHAEE_Strings.KOHNLDKIKPC_sb] = CEDHHAGBIBA.EHNMFLADJKG_ByteArrayToString(OPIBAPEGCLA_Scenes[i].EMOJHJGHJLN_Sb);
				data[POFDDFCGEGP_Underscore + (i + 1)] = data2;
			}
		}
		if(!EMBGIDLFKGM)
		{
			EDOHBJAPLPF_JsonData data2 = new EDOHBJAPLPF_JsonData();
			data2[AFEHLCGHAEE_Strings.KAKFEGGEKLB_save_id] = _MCKEOKFMLAH_SaveId;
			data2[AFEHLCGHAEE_Strings.COIODGJDJEJ_scene] = data;
			data2[AFEHLCGHAEE_Strings.AGPKGMFOJHC_rev] = 3;
			data = data2;
		}
		else
		{
			OILEIIEIBHP = OILEIIEIBHP[AFEHLCGHAEE_Strings.JCIBKDHKNFH_alldata];
		}
		OILEIIEIBHP[JIKKNHIAEKG_BlockName] = data;
	}

	// // RVA: 0x196CC24 Offset: 0x196CC24 VA: 0x196CC24 Slot: 6
	public override bool IIEMACPEEBJ_Deserialize(EDOHBJAPLPF_JsonData OILEIIEIBHP)
	{
		bool blockMissing = false;
		bool isInvalid = false;
		EDOHBJAPLPF_JsonData block = LGPBAKLCFHI_FindAndCheckBlock(OILEIIEIBHP, ref blockMissing, ref isInvalid, 3);
		if(blockMissing)
			return false;
		OKGLGHCBCJP_Database db = null;
		if(IMMAOANGPNK.HHCJCDFCLOB.LNAHEIEIBOI_Initialized)
		{
			db = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database;
		}
		if(block != null)
		{
			for(int i = 0; i < OPIBAPEGCLA_Scenes.Count; i++)
			{
				PMKOFEIONEG data = OPIBAPEGCLA_Scenes[i];
				string k = POFDDFCGEGP_Underscore + (i + 1);
				if(block.BBAJPINMOEP_Contains(k))
				{
					EDOHBJAPLPF_JsonData json = block[k];
					data.BEBJKJKBOGH_date = DKMPHAPBDLH_GetLong(json, AFEHLCGHAEE_Strings.BEBJKJKBOGH_date, 0, ref isInvalid);
					data.ANAJIAENLNB_lv = CJAENOMGPDA_GetInt(json, AFEHLCGHAEE_Strings.ANAJIAENLNB_lv, 0, ref isInvalid);
					data.MJBODMOLOBC_luck = CJAENOMGPDA_GetInt(json, AFEHLCGHAEE_Strings.MJBODMOLOBC_luck, 0, ref isInvalid);
					data.JPIPENJGGDD_NumBoard = CJAENOMGPDA_GetInt(json, AFEHLCGHAEE_Strings.ALMNMBDELDB_mlt, 0, ref isInvalid);
					data.IELENGDJPHF_Ulk = CJAENOMGPDA_GetInt(json, AFEHLCGHAEE_Strings.PMANOMLMICI_ulk, 0, ref isInvalid);
					data.LHMOAJAIJCO_is_new = CJAENOMGPDA_GetInt(json, AFEHLCGHAEE_Strings.KLJGEHBKMMG_new, 0, ref isInvalid) != 0;
					data.CDOBCKMHAOK_inf = CJAENOMGPDA_GetInt(json, AFEHLCGHAEE_Strings.CDOBCKMHAOK_inf, 0, ref isInvalid);
					data.DMNIMMGGJJJ_Leaf = CJAENOMGPDA_GetInt(json, "leaf", 0, ref isInvalid);
					data.DOAAOOHGODJ_PstNew = CJAENOMGPDA_GetInt(json, AFEHLCGHAEE_Strings.EGPELMDJDCC_pst_new, 0, ref isInvalid);
					CEDHHAGBIBA.IFOLECIIDPO_StringToByteArray(data.PDNIFBEGMHC_Mb, FGCNMLBACGO_GetString(json, AFEHLCGHAEE_Strings.DANMJLOBLIE_mb, "", ref isInvalid));
					CEDHHAGBIBA.IFOLECIIDPO_StringToByteArray(data.EMOJHJGHJLN_Sb, FGCNMLBACGO_GetString(json, AFEHLCGHAEE_Strings.KOHNLDKIKPC_sb, "", ref isInvalid));
					if(db != null)
					{
						if(data.PPFNGGCBJKC_id != 0)
						{
							if(db.ECNHDEHADGL_Scene.CDENCMNHNGA_table[i].PPEGAKEIEGM_Enabled == 2)
							{
								data.MJBODMOLOBC_luck = db.ECNHDEHADGL_Scene.CDENCMNHNGA_table[i].AGOEDLNOHND(db.JEMMMJEJLNL_Board, data.EMOJHJGHJLN_Sb, data.JPIPENJGGDD_NumBoard, db.HNMMJINNHII_Game.GENHLFPKOEE(db.ECNHDEHADGL_Scene.CDENCMNHNGA_table[i].EKLIPGELKCL_Rarity, db.ECNHDEHADGL_Scene.CDENCMNHNGA_table[i].MCCIFLKCNKO_Feed));
							}
						}
					}
					data.IDBDAPPJOND();
				}
			}
			if(db != null)
			{
				if(block.BBAJPINMOEP_Contains(AFEHLCGHAEE_Strings.AGPKGMFOJHC_rev) && (int)block[AFEHLCGHAEE_Strings.AGPKGMFOJHC_rev] <= 2 && AHKLHIBIDHF(db.ECNHDEHADGL_Scene, db.JEMMMJEJLNL_Board))
				{
					isInvalid = true;
				}
			}
			KFKDMBPNLJK_BlockInvalid = isInvalid;
		}
		else
		{
			KFKDMBPNLJK_BlockInvalid = true;
		}
		return true;
	}

	// // RVA: 0x196DA50 Offset: 0x196DA50 VA: 0x196DA50 Slot: 7
	public override void BMGGKONLFIC_Copy(KLFDBFMNLBL_ServerSaveBlock GPBJHKLFCEP)
	{
		MMPBPOIFDAF_Scene s = GPBJHKLFCEP as MMPBPOIFDAF_Scene;
		for(int i = 0; i < 6000; i++)
		{
			OPIBAPEGCLA_Scenes[i].ODDIHGPONFL_Copy(s.OPIBAPEGCLA_Scenes[i]);
		}
	}

	// // RVA: 0x196DEF8 Offset: 0x196DEF8 VA: 0x196DEF8 Slot: 8
	public override bool AGBOGBEOFME(KLFDBFMNLBL_ServerSaveBlock GPBJHKLFCEP)
	{
		MMPBPOIFDAF_Scene other = GPBJHKLFCEP as MMPBPOIFDAF_Scene;
		if(OPIBAPEGCLA_Scenes.Count != other.OPIBAPEGCLA_Scenes.Count)
			return false;
		for(int i = 0; i < OPIBAPEGCLA_Scenes.Count; i++)
		{
			if(!OPIBAPEGCLA_Scenes[i].AGBOGBEOFME(other.OPIBAPEGCLA_Scenes[i]))
				return false;
		}
		return true;
	}

	// // RVA: 0x196E4CC Offset: 0x196E4CC VA: 0x196E4CC Slot: 10
	//public override void AGHKODFKOJI(BHBONAHFKHD JBBHNIACMFJ, KLFDBFMNLBL_ServerSaveBlock _GJLFANGDGCL_Target, long _MCKEOKFMLAH_SaveId);

	// // RVA: 0x19715B4 Offset: 0x19715B4 VA: 0x19715B4 Slot: 11
	public override FENCAJJBLBH PFAKPFKJJKA()
	{
		TodoLogger.LogError(TodoLogger.DbIntegrityCheck, "TODO");
		return null;
	}
}
