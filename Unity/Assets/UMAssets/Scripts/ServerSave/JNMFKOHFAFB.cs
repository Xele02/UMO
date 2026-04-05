using System.Collections.Generic;
using XeSys;

[System.Obsolete("Use JNMFKOHFAFB_PublicStatus", true)]
public class JNMFKOHFAFB { }
public class JNMFKOHFAFB_PublicStatus : KLFDBFMNLBL_ServerSaveBlock
{
	public class KNHIPBADANI
	{
		public static int FBGGEFFJJHB_xor = 0x46bd435; // 0x0
		private int ELMLPFGPIIM_LeafCrypted; // 0x8
		private int EHOIENNDEDH_IdCrypted; // 0xC
		private int MBCPMFPKNBA_LevelCrypted; // 0x10
		private int MDIGCJGJBBA_LeafCheck; // 0x14
		private int NKCNFBCEEOI_LuckCrypted; // 0x18
		private int FEIKCJFNEGC_LuckCrypted2; // 0x1C
		private int OPLKJKAIFPF_NumBoardCrypted; // 0x20
		public byte[] PDNIFBEGMHC_Mb = new byte[15]; // 0x24
		public byte[] EMOJHJGHJLN_Sb = new byte[50]; // 0x28

		public int PPFNGGCBJKC_id { get { return EHOIENNDEDH_IdCrypted ^ FBGGEFFJJHB_xor; } set { EHOIENNDEDH_IdCrypted = FBGGEFFJJHB_xor ^ value; } } //0x1B9AEE8 DEMEPMAEJOO_get_id 0x1B9AE4C HIGKAIDMOKN_set_id
		public int ANAJIAENLNB_lv { get { return MBCPMFPKNBA_LevelCrypted ^ FBGGEFFJJHB_xor; } set { MBCPMFPKNBA_LevelCrypted = FBGGEFFJJHB_xor ^ value; } } //0x1BA163C MMOMNMBKHJF_get_lv 0x1B9AF80 FEHNFGPFINK_set_lv
		public int MJBODMOLOBC_luck { get { 
			int val = NKCNFBCEEOI_LuckCrypted ^ FBGGEFFJJHB_xor;
			if(val != FEIKCJFNEGC_LuckCrypted2)
				return 0;
			return val;
		 } set
		 {
			NKCNFBCEEOI_LuckCrypted = FBGGEFFJJHB_xor ^ value;
			FEIKCJFNEGC_LuckCrypted2 = value;
		 } } //0x1B9B1F8 JDPBFBEBJOK_bgs 0x1B9B01C PNKGEPNKKBM_bgs
		 // Mlt
		public int JPIPENJGGDD_NumBoard { get { return OPLKJKAIFPF_NumBoardCrypted ^ FBGGEFFJJHB_xor; } set { OPLKJKAIFPF_NumBoardCrypted = FBGGEFFJJHB_xor ^ value; } } //0x1BA16D4 FBLKAMOKPPP_bgs 0x1B9B0BC BEEPHNBJGLI_bgs
		public int DMNIMMGGJJJ_Leaf { get { int val = ELMLPFGPIIM_LeafCrypted ^ FBGGEFFJJHB_xor; return (val != MDIGCJGJBBA_LeafCheck ? 0 : val); } set { MDIGCJGJBBA_LeafCheck = value; ELMLPFGPIIM_LeafCrypted = value ^ FBGGEFFJJHB_xor; } } //0x1BA176C CJCDKIKDBNP_bgs 0x1B9B158 CCGHKFJEFCB_bgs

		// // RVA: 0x1B98808 Offset: 0x1B98808 VA: 0x1B98808
		public void KMBPACJNEOF_Reset()
		{
			PPFNGGCBJKC_id = 0;
			ANAJIAENLNB_lv = 0;
			MJBODMOLOBC_luck = 0;
			JPIPENJGGDD_NumBoard = 0;
			for(int i = 0; i < PDNIFBEGMHC_Mb.Length; i++)
			{
				PDNIFBEGMHC_Mb[i] = 0;
			}
			for(int i = 0; i < EMOJHJGHJLN_Sb.Length; i++)
			{
				EMOJHJGHJLN_Sb[i] = 0;
			}
		}

		// // RVA: 0x1B9DB80 Offset: 0x1B9DB80 VA: 0x1B9DB80
		public void ODDIHGPONFL_Copy(KNHIPBADANI GPBJHKLFCEP)
		{
			PPFNGGCBJKC_id = GPBJHKLFCEP.PPFNGGCBJKC_id;
			ANAJIAENLNB_lv = GPBJHKLFCEP.ANAJIAENLNB_lv;
			MJBODMOLOBC_luck = GPBJHKLFCEP.MJBODMOLOBC_luck;
			JPIPENJGGDD_NumBoard = GPBJHKLFCEP.JPIPENJGGDD_NumBoard;
			DMNIMMGGJJJ_Leaf = GPBJHKLFCEP.DMNIMMGGJJJ_Leaf;
			for(int i = 0; i < PDNIFBEGMHC_Mb.Length; i++)
			{
				PDNIFBEGMHC_Mb[i] = GPBJHKLFCEP.PDNIFBEGMHC_Mb[i];
			}
			for(int i = 0; i < EMOJHJGHJLN_Sb.Length; i++)
			{
				EMOJHJGHJLN_Sb[i] = GPBJHKLFCEP.EMOJHJGHJLN_Sb[i];
			}
		}

		// // RVA: 0x1B9E86C Offset: 0x1B9E86C VA: 0x1B9E86C
		public bool AGBOGBEOFME(KNHIPBADANI GPBJHKLFCEP)
		{
			if(PPFNGGCBJKC_id != GPBJHKLFCEP.PPFNGGCBJKC_id ||
				ANAJIAENLNB_lv != GPBJHKLFCEP.ANAJIAENLNB_lv ||
				MJBODMOLOBC_luck != GPBJHKLFCEP.MJBODMOLOBC_luck ||
				DMNIMMGGJJJ_Leaf != GPBJHKLFCEP.DMNIMMGGJJJ_Leaf)
				return false;
			for(int i = 0; i < GPBJHKLFCEP.PDNIFBEGMHC_Mb.Length; i++)
			{
				if(GPBJHKLFCEP.PDNIFBEGMHC_Mb[i] != PDNIFBEGMHC_Mb[i])
					return false;
			}
			for(int i = 0; i < GPBJHKLFCEP.EMOJHJGHJLN_Sb.Length; i++)
			{
				if(GPBJHKLFCEP.EMOJHJGHJLN_Sb[i] != EMOJHJGHJLN_Sb[i])
					return false;
			}
			return true;
		}

		// // RVA: 0x1BA1810 Offset: 0x1BA1810 VA: 0x1BA1810
		public void DOMFHDPMCCO_Init(int _BCCHOBPJJKE_SceneId, byte[] _KBOLNIBLIND_unlock, byte[] _ODKMKEHJOCK_Sb, int _MJBODMOLOBC_luck, int _JPIPENJGGDD_NumBoard, int _DMNIMMGGJJJ_Leaf)
		{
			PPFNGGCBJKC_id = _BCCHOBPJJKE_SceneId;
			ANAJIAENLNB_lv = 1;
			if (_MJBODMOLOBC_luck < 1)
				_MJBODMOLOBC_luck = 0;
			if (_MJBODMOLOBC_luck > 24)
				_MJBODMOLOBC_luck = 25;
			MJBODMOLOBC_luck = _MJBODMOLOBC_luck;
			JPIPENJGGDD_NumBoard = _JPIPENJGGDD_NumBoard;
			DMNIMMGGJJJ_Leaf = _DMNIMMGGJJJ_Leaf;
			if(_KBOLNIBLIND_unlock == null)
			{
				for(int i = 0; i < PDNIFBEGMHC_Mb.Length; i++)
				{
					PDNIFBEGMHC_Mb[i] = 0;
				}
			}
			else
			{
				for (int i = 0; i < PDNIFBEGMHC_Mb.Length; i++)
				{
					PDNIFBEGMHC_Mb[i] = _KBOLNIBLIND_unlock[i];
				}
			}
			if(_ODKMKEHJOCK_Sb == null)
			{
				for(int i = 0; i < EMOJHJGHJLN_Sb.Length; i++)
				{
					EMOJHJGHJLN_Sb[i] = 0;
				}
			}
			else
			{
				for (int i = 0; i < EMOJHJGHJLN_Sb.Length; i++)
				{
					EMOJHJGHJLN_Sb[i] = _ODKMKEHJOCK_Sb[i];
				}
			}
		}
	}

	public class ONCMONJIPCD
	{
		private const string OPEJBCMIAJH = "アシスト{0}";
		public JNMFKOHFAFB_PublicStatus.KNHIPBADANI[] JOHLGBDOLNO_AssistScenes = new JNMFKOHFAFB_PublicStatus.KNHIPBADANI[4]; // 0x8
		public string JCJNKBKMJFK_Name; // 0xC

		// // RVA: 0x1B98914 Offset: 0x1B98914 VA: 0x1B98914
		public void KMBPACJNEOF_Reset(int _OIPCCBHIKIA_index)
		{
			for(int i = 0; i < JOHLGBDOLNO_AssistScenes.Length; i++)
			{
				JOHLGBDOLNO_AssistScenes[i] = new JNMFKOHFAFB_PublicStatus.KNHIPBADANI();
				JOHLGBDOLNO_AssistScenes[i].KMBPACJNEOF_Reset();
			}
			JCJNKBKMJFK_Name = string.Format(OPEJBCMIAJH, _OIPCCBHIKIA_index + 1);
		}

		// // RVA: 0x1BA1B3C Offset: 0x1BA1B3C VA: 0x1BA1B3C
		public void DOMFHDPMCCO_Init(KNHIPBADANI[] NNDGIAEFMOG, string _OPFGFINHFCE_name)
		{
			for(int i = 0; i < JOHLGBDOLNO_AssistScenes.Length; i++)
			{
				if(JOHLGBDOLNO_AssistScenes[i] == null)
				{
					JOHLGBDOLNO_AssistScenes[i] = new KNHIPBADANI();
				}
				JOHLGBDOLNO_AssistScenes[i].ODDIHGPONFL_Copy(NNDGIAEFMOG[i]);
			}
			JCJNKBKMJFK_Name = _OPFGFINHFCE_name;
		}

		// // RVA: 0x1B9DDA8 Offset: 0x1B9DDA8 VA: 0x1B9DDA8
		public void ODDIHGPONFL_Copy(ONCMONJIPCD GPBJHKLFCEP)
		{
			JCJNKBKMJFK_Name = GPBJHKLFCEP.JCJNKBKMJFK_Name;
			for(int i = 0; i < JOHLGBDOLNO_AssistScenes.Length; i++)
			{
				JOHLGBDOLNO_AssistScenes[i].ODDIHGPONFL_Copy(GPBJHKLFCEP.JOHLGBDOLNO_AssistScenes[i]);
			}
		}

		// // RVA: 0x1B9EAA0 Offset: 0x1B9EAA0 VA: 0x1B9EAA0
		public bool AGBOGBEOFME(ONCMONJIPCD GPBJHKLFCEP)
		{
			if(JCJNKBKMJFK_Name != GPBJHKLFCEP.JCJNKBKMJFK_Name)
				return false;
			for(int i = 0; i < JOHLGBDOLNO_AssistScenes.Length; i++)
			{
				if(!JOHLGBDOLNO_AssistScenes[i].AGBOGBEOFME(GPBJHKLFCEP.JOHLGBDOLNO_AssistScenes[i]))
					return false;
			}
			return true;
		}
	}

	public class LBGEDDJKOKF
	{
		public static int FBGGEFFJJHB_xor = 0x9610ff; // 0x0
		private int[] EHOIENNDEDH_IdCrypted = new int[10]; // 0x8 FreeMusicIds
		private int[] EHLGHDIACCG_MusicDifficultyCrypted = new int[10]; // 0xC
		private int[] PCFFCAAIPNB_ScoreCrypted = new int[10]; // 0x10
		private int[] JALJMLNOLII_L6 = new int[10]; // 0x14

		// // RVA: 0x1B9B84C Offset: 0x1B9B84C VA: 0x1B9B84C
		public void GMLHMKAMOEN_SetFreeMusicId(int _IKPIDCFOFEA_no, int _PPFNGGCBJKC_id)
		{
			if(_PPFNGGCBJKC_id <= 2000 && _IKPIDCFOFEA_no <= 9)
			{
				EHOIENNDEDH_IdCrypted[_IKPIDCFOFEA_no] = _PPFNGGCBJKC_id ^ FBGGEFFJJHB_xor;
			}
		}

		// // RVA: 0x1B99224 Offset: 0x1B99224 VA: 0x1B99224
		public int MLKHJPBAFCO_GetFreeMusicId(int _IKPIDCFOFEA_no)
		{
			int val = 0;
			if(_IKPIDCFOFEA_no < 10)
			{
				val = EHOIENNDEDH_IdCrypted[_IKPIDCFOFEA_no] ^ FBGGEFFJJHB_xor;
				if (val < 0 || val > 2000)
					val = 0;
			}
			return val;
		}

		// // RVA: 0x1B9B92C Offset: 0x1B9B92C VA: 0x1B9B92C
		public void HJHBGHMNGKL_SetDifficulty(int _IKPIDCFOFEA_no, int _GOKJLBDJOLA_df)
		{
			if (_GOKJLBDJOLA_df <= 4 && _IKPIDCFOFEA_no <= 9)
			{
				EHLGHDIACCG_MusicDifficultyCrypted[_IKPIDCFOFEA_no] = _GOKJLBDJOLA_df ^ FBGGEFFJJHB_xor;
			}
		}

		// // RVA: 0x1B99314 Offset: 0x1B99314 VA: 0x1B99314
		public int FFACBDAJJJP_GetDifficulty(int _IKPIDCFOFEA_no)
		{
			int val = 0;
			if (_IKPIDCFOFEA_no < 10)
			{
				val = EHLGHDIACCG_MusicDifficultyCrypted[_IKPIDCFOFEA_no] ^ FBGGEFFJJHB_xor;
				if (val < 0 || val > 4)
					val = 0;
			}
			return val;
		}

		// // RVA: 0x1B9BA0C Offset: 0x1B9BA0C VA: 0x1B9BA0C
		public void ECKFCIHPHGJ_SetScore(int _IKPIDCFOFEA_no, int _AFKHNFBOMKI_sc)
		{
			if (_AFKHNFBOMKI_sc >= 0 && _IKPIDCFOFEA_no <= 9)
			{
				PCFFCAAIPNB_ScoreCrypted[_IKPIDCFOFEA_no] = _AFKHNFBOMKI_sc ^ FBGGEFFJJHB_xor;
			}
		}

		// // RVA: 0x1B99404 Offset: 0x1B99404 VA: 0x1B99404
		public int BDCAICINCKK_GetScore(int _IKPIDCFOFEA_no)
		{
			if (_IKPIDCFOFEA_no > 9)
				return 0;
			if (PCFFCAAIPNB_ScoreCrypted[_IKPIDCFOFEA_no] > 0)
				return PCFFCAAIPNB_ScoreCrypted[_IKPIDCFOFEA_no] ^ FBGGEFFJJHB_xor;
			return 0;
		}

		// // RVA: 0x1B9BAF0 Offset: 0x1B9BAF0 VA: 0x1B9BAF0
		public void HPDBEKAGKOD_SetIsLine6(int _IKPIDCFOFEA_no, int _MIKICCLPDJA_L6)
		{
			if (_MIKICCLPDJA_L6 >= 0 && _IKPIDCFOFEA_no <= 9)
			{
				JALJMLNOLII_L6[_IKPIDCFOFEA_no] = _MIKICCLPDJA_L6 ^ FBGGEFFJJHB_xor;
			}
		}

		// // RVA: 0x1B994E8 Offset: 0x1B994E8 VA: 0x1B994E8
		public int MJKFDJIPMMB_GetL6(int _IKPIDCFOFEA_no)
		{
			if (_IKPIDCFOFEA_no > 9)
				return 0;
			if (JALJMLNOLII_L6[_IKPIDCFOFEA_no] > 0)
				return JALJMLNOLII_L6[_IKPIDCFOFEA_no] ^ FBGGEFFJJHB_xor;
			return 0;
		}

		// // RVA: 0x1B98B4C Offset: 0x1B98B4C VA: 0x1B98B4C
		public void KMBPACJNEOF_Reset()
		{
			for(int i = 0; i < 10; i++)
			{
				EHOIENNDEDH_IdCrypted[i] = FBGGEFFJJHB_xor;
				EHLGHDIACCG_MusicDifficultyCrypted[i] = FBGGEFFJJHB_xor;
				PCFFCAAIPNB_ScoreCrypted[i] = FBGGEFFJJHB_xor;
				JALJMLNOLII_L6[i] = FBGGEFFJJHB_xor;
			}
		}

		// // RVA: 0x1B9DE88 Offset: 0x1B9DE88 VA: 0x1B9DE88
		public void ODDIHGPONFL_Copy(LBGEDDJKOKF GPBJHKLFCEP)
		{
			for(int i = 0; i < 10; i++)
			{
				GMLHMKAMOEN_SetFreeMusicId(i, GPBJHKLFCEP.MLKHJPBAFCO_GetFreeMusicId(i));
				HJHBGHMNGKL_SetDifficulty(i, GPBJHKLFCEP.FFACBDAJJJP_GetDifficulty(i));
				ECKFCIHPHGJ_SetScore(i, GPBJHKLFCEP.BDCAICINCKK_GetScore(i));
				HPDBEKAGKOD_SetIsLine6(i, GPBJHKLFCEP.MJKFDJIPMMB_GetL6(i));
			}
		}

		// // RVA: 0x1B9EBAC Offset: 0x1B9EBAC VA: 0x1B9EBAC
		public bool AGBOGBEOFME(LBGEDDJKOKF GPBJHKLFCEP)
		{
			for(int i = 0; i < 10; i++)
			{
				if(MLKHJPBAFCO_GetFreeMusicId(i) != GPBJHKLFCEP.MLKHJPBAFCO_GetFreeMusicId(i) ||
					FFACBDAJJJP_GetDifficulty(i) != GPBJHKLFCEP.FFACBDAJJJP_GetDifficulty(i) ||
					BDCAICINCKK_GetScore(i) != GPBJHKLFCEP.BDCAICINCKK_GetScore(i) ||
					MJKFDJIPMMB_GetL6(i) != GPBJHKLFCEP.MJKFDJIPMMB_GetL6(i)
				)
				return false;
			}
			return true;
		}

		// // RVA: 0x1B9B6EC Offset: 0x1B9B6EC VA: 0x1B9B6EC
		public bool GEJEDJNKBOF_Validate(int _IKPIDCFOFEA_no)
		{
			return IMMAOANGPNK_NetMasterDataManager.HHCJCDFCLOB_Instance.NKEBMCIMJND_Database.IBPAFKKEKNK_Music.BHJKMPBACAC_IsFreeMusicAvaiable(MLKHJPBAFCO_GetFreeMusicId(_IKPIDCFOFEA_no)) && FFACBDAJJJP_GetDifficulty(_IKPIDCFOFEA_no) < 5 && BDCAICINCKK_GetScore(_IKPIDCFOFEA_no) < 1000000 && BDCAICINCKK_GetScore(_IKPIDCFOFEA_no) >= 0 && MJKFDJIPMMB_GetL6(_IKPIDCFOFEA_no) < 2;
		}
	}

	// public const int ECFEMKGFDCE_CurrentVersion = 2;
	private int FBGGEFFJJHB_xor; // 0x24
	private int AOFGNAJLLPD_DivaIdCrypted; // 0x28
	private int MBCPMFPKNBA_LevelCrypted; // 0x2C
	private int BJHHOBEMBJG_CostumeIdCrypted; // 0x30
	private int LEHJBFPLJPL_CostumeColorIdCrypted; // 0x34
	private int HMJBBNEACOA_PLevelCrypted; // 0x38
	private int HEJIMPBBFEP_EmIdCrypted; // 0x3C
	private int GJOCKDBHEIM_EmCntCrypted; // 0x40
	private int BBOLHCKJFCA_VfIdCrypted; // 0x44
	private int GMDHEAHLJGM_ScnCntCrypted; // 0x48
	private int NPNCNBIBPGN_CosCntCrypted; // 0x4C
	private int NGMIJHODDDK_VfCntCrypted; // 0x50
	private int PLIJDLMMMDI_QCntCrypted; // 0x54
	private int KNKEKPPDDCL_LvMaxCntCrypted; // 0x58
	private long GBFJLFBBDLL_PfTapCrypted; // 0x60
	private long DOOLJJCBNON_TClrCrypted; // 0x68
	private long GKCNAJDCODL_DcTmCrypted; // 0x70
	private int BFKKFMILHMO_MaxScCrypted; // 0x78
	private int FCFIANFLKCF_MaxIdCrypted; // 0x7C
	private int OBJIGFALAGG_MaxDfCrypted; // 0x80
	private int KGNOMMHMJEB_MaxL6Crypted; // 0x84
	private int[] DEMGKPDLMJO_DfClr = new int[5]; // 0x88
	private int[] EJAHPKHLMHA_DfFcb = new int[5]; // 0x8C
	private int[] AOJJNNFNDHM_DfClr16 = new int[5]; // 0x90
	private int[] CNOEKAHJJLE_DfFcb16 = new int[5]; // 0x94
	private int MLAHLKGEEBB_McPowerCrypted; // 0x98
	private int EFJBEJGNPEA_PshCrypted; // 0x9C
	private string IJCPFDPNDHE_DcNm; // 0xA0
	private int KNLODMNFFII_UtaRankCrypted; // 0xA4

	public int DIPKCALNIII_diva_id { get { return AOFGNAJLLPD_DivaIdCrypted ^ FBGGEFFJJHB_xor; } set { AOFGNAJLLPD_DivaIdCrypted = value ^ FBGGEFFJJHB_xor; } } //EOGPBFIDAPF_get_diva_id 0x1B97BD8  JDNCGPBAFMB_set_diva_id 0x1B97BE8
	public int ANAJIAENLNB_lv { get { return MBCPMFPKNBA_LevelCrypted ^ FBGGEFFJJHB_xor; } set { MBCPMFPKNBA_LevelCrypted = value ^ FBGGEFFJJHB_xor; } } //MMOMNMBKHJF_get_lv 0x1B97BF8 FEHNFGPFINK_set_lv 0x1B97C08
	public KNHIPBADANI AFBMEMCHJCL_MainScene { get; private set; } // 0xA8 KNFCIOAPINN_bgs GJBNHLMONNG_bgs NNFIJKIAFEN_bgs
	public ONCMONJIPCD MGMFOJPNDGA_AssistData { get; private set; } // 0xAC IOIMBAECIKN_bgs HFCCFNMJALI_bgs OMADOLIKBOL_bgs
	public List<KNHIPBADANI> HDJOHAJPGBA_SubScene { get; private set; } // 0xB0 APOCOCHGFGM_bgs NKKJDGBFHOH_bgs ENDCIPBGGPI_bgs
	public int BEEAIAAJOHD_CostumeId { get { return BJHHOBEMBJG_CostumeIdCrypted ^ FBGGEFFJJHB_xor; } set { BJHHOBEMBJG_CostumeIdCrypted = value ^ FBGGEFFJJHB_xor; } } //DIIBIOEMHAI_get_CostumeId 0x1B97C48   JIHEDMEFKAF_set_CostumeId 0x1B97C58
	public int AFNIOJHODAG_CostumeColorId { get { return LEHJBFPLJPL_CostumeColorIdCrypted ^ FBGGEFFJJHB_xor; } set { LEHJBFPLJPL_CostumeColorIdCrypted = value ^ FBGGEFFJJHB_xor; } } //OCABHAPHAMH_bgs 0x1B97C68 DIAIECJEGDG_bgs 0x1B97C78
	public int KIECDDFNCAN_Level { get { return HMJBBNEACOA_PLevelCrypted ^ FBGGEFFJJHB_xor; } set { HMJBBNEACOA_PLevelCrypted = value ^ FBGGEFFJJHB_xor; } } //LNOBPNDNEAK_bgs 0x1B97C88  BNGHHNPKLNB_bgs 0x1B97C98
	public int ABLOIBMGLFD_em_id { get { return HEJIMPBBFEP_EmIdCrypted ^ FBGGEFFJJHB_xor; } set { HEJIMPBBFEP_EmIdCrypted = value ^ FBGGEFFJJHB_xor; } } //PEFEEOLHFGE_bgs 0x1B97CA8 LBMNIKJOIIF_bgs 0x1B97CB8
	public int FHCAFLCLGAA_em_cnt { get { return GJOCKDBHEIM_EmCntCrypted ^ FBGGEFFJJHB_xor; } set { GJOCKDBHEIM_EmCntCrypted = value ^ FBGGEFFJJHB_xor; } } //EMLMAIJNCKP_bgs 0x1B97CC8 OKLACIGBMAM_bgs 0x1B97CD8
	public int FODKKJIDDKN_vf_Id { get { return BBOLHCKJFCA_VfIdCrypted ^ FBGGEFFJJHB_xor; } set { BBOLHCKJFCA_VfIdCrypted = value ^ FBGGEFFJJHB_xor; } } //LCHMMCPCFDD_get_vf_Id 0x1B97CE8 DHMLIEPNLCG_set_vf_Id 0x1B97CF8
	public int BKIFLJAMJGG_scn_cnt { get { return GMDHEAHLJGM_ScnCntCrypted ^ FBGGEFFJJHB_xor; } set { GMDHEAHLJGM_ScnCntCrypted = value ^ FBGGEFFJJHB_xor; } } //AEDPPCEHDGJ_bgs 0x1B97D08 JEMHMMBDMPH_bgs 0x1B97D18
	public int FOFGELKGMAH_cos_cnt { get { return NPNCNBIBPGN_CosCntCrypted ^ FBGGEFFJJHB_xor; } set { NPNCNBIBPGN_CosCntCrypted = value ^ FBGGEFFJJHB_xor; } } //NHLLEINLGLG_bgs 0x1B97D28 EEKAJAEKFGM_bgs 0x1B97D38
	public int MIFLBHBPBNF_vf_cnt { get { return NGMIJHODDDK_VfCntCrypted ^ FBGGEFFJJHB_xor; } set { NGMIJHODDDK_VfCntCrypted = value ^ FBGGEFFJJHB_xor; } } //BLDNGDDPPME_bgs 0x1B97D48  MKONLHNIHKL_bgs 0x1B97D58
	public int APFOBLMCLAO_q_cnt { get { return PLIJDLMMMDI_QCntCrypted ^ FBGGEFFJJHB_xor; } set { PLIJDLMMMDI_QCntCrypted = value ^ FBGGEFFJJHB_xor; } } //LMCDIHAGOHH_bgs 0x1B97D68 JBKMEAEAFOL_bgs 0x1B97D78
	public int JGDNCEANEBB_lv_max_cnt { get { return KNKEKPPDDCL_LvMaxCntCrypted ^ FBGGEFFJJHB_xor; } set { KNKEKPPDDCL_LvMaxCntCrypted = value ^ FBGGEFFJJHB_xor; } } //GBFDJKKKEIM_bgs 0x1B97D88 IOOJAGNAKKN_bgs 0x1B97D98
	public long LDKEOMCNLBE_pf_tap { get { return GBFJLFBBDLL_PfTapCrypted ^ FBGGEFFJJHB_xor; } set { GBFJLFBBDLL_PfTapCrypted = value ^ FBGGEFFJJHB_xor; } } //MNNJCAENCHJ_bgs 0x1B97DA8 JMPKDHKCMON_bgs 0x1B97DC0
	public long PCBJHBCNNGD_t_clr { get { return DOOLJJCBNON_TClrCrypted ^ FBGGEFFJJHB_xor; } set { DOOLJJCBNON_TClrCrypted = value ^ FBGGEFFJJHB_xor; } } //BHLKKHJLGGE_bgs 0x1B97DD4 FJFFPLKGNDF_bgs 0x1B97DEC
	// Max Score
	public int AEBENOJEGOJ_max_sc { get { return FBGGEFFJJHB_xor ^ BFKKFMILHMO_MaxScCrypted; } set { BFKKFMILHMO_MaxScCrypted = FBGGEFFJJHB_xor ^ value; } } //DEBHLAOOOBN_bgs 0x1B97E00 AKKKJMMFOKH_bgs 0x1B97E10
	public int JHOIMONJKLG_max_id { get { return FCFIANFLKCF_MaxIdCrypted ^ FBGGEFFJJHB_xor; } set { FCFIANFLKCF_MaxIdCrypted = value ^ FBGGEFFJJHB_xor; } } //DJPLEMJPOIH_bgs 0x1B97E20 JINGNHOHDKD_bgs 0x1B97E30
	public int JEENEHPOCFN_max_df { get { return OBJIGFALAGG_MaxDfCrypted ^ FBGGEFFJJHB_xor; } set { OBJIGFALAGG_MaxDfCrypted = value ^ FBGGEFFJJHB_xor; } } //ODBOEKIHJDB_bgs 0x1B97E40 KOJIBFLIAAK_bgs 0x1B97E50
	public int NADEAGFJDLL_MaxL6 { get { return KGNOMMHMJEB_MaxL6Crypted ^ FBGGEFFJJHB_xor; } set { KGNOMMHMJEB_MaxL6Crypted = value ^ FBGGEFFJJHB_xor; } } //EICGJGODOPK_bgs 0x1B97E60 INFBHCPEBIG_bgs 0x1B97E70
	public long DALCINDEJLC_DcTm { get { return GKCNAJDCODL_DcTmCrypted ^ FBGGEFFJJHB_xor; } set { GKCNAJDCODL_DcTmCrypted = value ^ FBGGEFFJJHB_xor; } } //APCILEIAHAJ_bgs 0x1B97E80 GEJPIMFNKLJ_bgs 0x1B97E98
	public string NAKJJBEIION_DcNm { get { return IJCPFDPNDHE_DcNm; } set { IJCPFDPNDHE_DcNm = value; } } //NEFKGAAMLEG_bgs 0x1B97EAC ACAJCPPKAKN_bgs 0x1B97EB4
	public int OENMBJEKJII_McPower { get { return MLAHLKGEEBB_McPowerCrypted ^ FBGGEFFJJHB_xor; } set { MLAHLKGEEBB_McPowerCrypted = value ^ FBGGEFFJJHB_xor; } }  //FKJNEPMOEIM_bgs 0x1B9815C DBJEDFGBDFB_bgs 0x1B9816C
	public List<LBGEDDJKOKF> AEIADFODLMC_HsRating { get; private set; } // 0xB4 FJDIIFNMHGO_bgs JJIKNMLEHMO_bgs IGJDNMJPJPN_bgs
	public int IPJPAAFNAOF_Psh { get { return EFJBEJGNPEA_PshCrypted ^ FBGGEFFJJHB_xor; } set { EFJBEJGNPEA_PshCrypted = value ^ FBGGEFFJJHB_xor; } }// JICJJOECOCM_bgs 0x1B9818C EFHHBDALMFN_bgs 0x1B9819C
	public int AILEOFKIELL_UtaRateRank { get { return KNLODMNFFII_UtaRankCrypted ^ FBGGEFFJJHB_xor; } set { KNLODMNFFII_UtaRankCrypted = value ^ FBGGEFFJJHB_xor; } } //JJDFJGJPJNP_bgs 0x1B981AC ACFHJBLJPEK_bgs 0x1B981BC
	public override bool DMICHEJIAJL { get { return true; } } // 0x1BA1544 NFKFOODCJJB_bgs

	// // RVA: 0x1B97EBC Offset: 0x1B97EBC VA: 0x1B97EBC
	public int PFHIOGBJDHM(int _AKNELONELJK_difficulty)
	{
		return DEMGKPDLMJO_DfClr[_AKNELONELJK_difficulty] ^ FBGGEFFJJHB_xor;
	}

	// // RVA: 0x1B97F10 Offset: 0x1B97F10 VA: 0x1B97F10
	public int KIBCDACEFIC(int _AKNELONELJK_difficulty)
	{
		return EJAHPKHLMHA_DfFcb[_AKNELONELJK_difficulty] ^ FBGGEFFJJHB_xor;
	}

	// // RVA: 0x1B97F64 Offset: 0x1B97F64 VA: 0x1B97F64
	public void BAHLFHCOEHO(int _AKNELONELJK_difficulty, int _BFINGCJHOHI_cnt)
	{
		DEMGKPDLMJO_DfClr[_AKNELONELJK_difficulty] = FBGGEFFJJHB_xor ^ _BFINGCJHOHI_cnt;
	}

	// // RVA: 0x1B97FB8 Offset: 0x1B97FB8 VA: 0x1B97FB8
	public void CECEAOLLLNG(int _AKNELONELJK_difficulty, int _BFINGCJHOHI_cnt)
	{
		EJAHPKHLMHA_DfFcb[_AKNELONELJK_difficulty] = FBGGEFFJJHB_xor ^ _BFINGCJHOHI_cnt;
	}

	// // RVA: 0x1B9800C Offset: 0x1B9800C VA: 0x1B9800C
	public int EJNGDOJAIDP(int _AKNELONELJK_difficulty)
	{
		return AOJJNNFNDHM_DfClr16[_AKNELONELJK_difficulty] ^ FBGGEFFJJHB_xor;
	}

	// // RVA: 0x1B98060 Offset: 0x1B98060 VA: 0x1B98060
	public int JFBMBPPHDLB(int _AKNELONELJK_difficulty)
	{
		return CNOEKAHJJLE_DfFcb16[_AKNELONELJK_difficulty] ^ FBGGEFFJJHB_xor;
	}

	// // RVA: 0x1B980B4 Offset: 0x1B980B4 VA: 0x1B980B4
	public void PCBEBNAHCDH(int _AKNELONELJK_difficulty, int _BFINGCJHOHI_cnt)
	{
		AOJJNNFNDHM_DfClr16[_AKNELONELJK_difficulty] = FBGGEFFJJHB_xor ^ _BFINGCJHOHI_cnt;
	}

	// // RVA: 0x1B98108 Offset: 0x1B98108 VA: 0x1B98108
	public void KLAALDBEAJM(int _AKNELONELJK_difficulty, int _BFINGCJHOHI_cnt)
	{
		CNOEKAHJJLE_DfFcb16[_AKNELONELJK_difficulty] = FBGGEFFJJHB_xor ^ _BFINGCJHOHI_cnt;
	}

	// // RVA: 0x1B981CC Offset: 0x1B981CC VA: 0x1B981CC
	public bool LJLLNLKBEJE(int ICDJHNPILBC)
	{
		return IMMAOANGPNK_NetMasterDataManager.HHCJCDFCLOB_Instance.NKEBMCIMJND_Database.GDEKCOOBLMA_System.GNEGCHEGECN_RaidPushEnable && 
			(IPJPAAFNAOF_Psh & 0x100) == 0 && ((IPJPAAFNAOF_Psh & (1 << (ICDJHNPILBC & 0x1f))) == 0);
	}

	// // RVA: 0x1B982E0 Offset: 0x1B982E0 VA: 0x1B982E0
	public JNMFKOHFAFB_PublicStatus()
	{
		AFBMEMCHJCL_MainScene = new KNHIPBADANI();
		HDJOHAJPGBA_SubScene = new List<KNHIPBADANI>();
		AEIADFODLMC_HsRating = new List<LBGEDDJKOKF>();
		MGMFOJPNDGA_AssistData = new ONCMONJIPCD();
		KMBPACJNEOF_Reset();
	}

	// // RVA: 0x1B98538 Offset: 0x1B98538 VA: 0x1B98538 Slot: 4
	public override void KMBPACJNEOF_Reset()
	{
		long time = Utility.GetCurrentUnixTime();
		FBGGEFFJJHB_xor = (int)(time ^ 0x2b50b);
		AEBENOJEGOJ_max_sc = 0;
		JHOIMONJKLG_max_id = 0;
		JEENEHPOCFN_max_df = 0;
		NADEAGFJDLL_MaxL6 = 0;
		APFOBLMCLAO_q_cnt = 0;
		JGDNCEANEBB_lv_max_cnt = 0;
		DALCINDEJLC_DcTm = 0;
		DIPKCALNIII_diva_id = 1;
		ANAJIAENLNB_lv = 0;
		BEEAIAAJOHD_CostumeId = 0;
		AFNIOJHODAG_CostumeColorId = 0;
		KIECDDFNCAN_Level = 1;
		ABLOIBMGLFD_em_id = 1;
		FHCAFLCLGAA_em_cnt = 0;
		FODKKJIDDKN_vf_Id = 1;
		BKIFLJAMJGG_scn_cnt = 0;
		FOFGELKGMAH_cos_cnt = 0;
		MIFLBHBPBNF_vf_cnt = 0;
		LDKEOMCNLBE_pf_tap = 0;
		PCBJHBCNNGD_t_clr = 0;
		IJCPFDPNDHE_DcNm = "";

		for (int i = 0; i < 5; i++)
		{
			BAHLFHCOEHO(i, 0);
			CECEAOLLLNG(i, 0);
			PCBEBNAHCDH(i, 0);
			KLAALDBEAJM(i, 0);
		}
		OENMBJEKJII_McPower = 0;
		AFBMEMCHJCL_MainScene.KMBPACJNEOF_Reset();
		MGMFOJPNDGA_AssistData.KMBPACJNEOF_Reset(0);
		HDJOHAJPGBA_SubScene.Clear();
		AEIADFODLMC_HsRating.Clear();
		for(int i = 0; i < 2; i++)
		{
			KNHIPBADANI data = new KNHIPBADANI();
			data.KMBPACJNEOF_Reset();
			HDJOHAJPGBA_SubScene.Add(data);
		}
		LBGEDDJKOKF data2 = new LBGEDDJKOKF();
		data2.KMBPACJNEOF_Reset();
		AEIADFODLMC_HsRating.Add(data2);
		IPJPAAFNAOF_Psh = 0;
		AILEOFKIELL_UtaRateRank = 0;
	}

	// // RVA: 0x1B98D3C Offset: 0x1B98D3C VA: 0x1B98D3C
	private EDOHBJAPLPF_JsonData BJIJBKEABPO(LBGEDDJKOKF IDJJCEGLONI)
	{
		EDOHBJAPLPF_JsonData data = new EDOHBJAPLPF_JsonData();
		data[AFEHLCGHAEE_Strings.PPFNGGCBJKC_id] = new EDOHBJAPLPF_JsonData();
		data[AFEHLCGHAEE_Strings.GOKJLBDJOLA_df] = new EDOHBJAPLPF_JsonData();
		data[AFEHLCGHAEE_Strings.AFKHNFBOMKI_sc] = new EDOHBJAPLPF_JsonData();
		data["l6"] = new EDOHBJAPLPF_JsonData();
		for(int i = 0; i < 10; i++)
		{
			data[AFEHLCGHAEE_Strings.PPFNGGCBJKC_id].Add(IDJJCEGLONI.MLKHJPBAFCO_GetFreeMusicId(i));
			data[AFEHLCGHAEE_Strings.GOKJLBDJOLA_df].Add(IDJJCEGLONI.FFACBDAJJJP_GetDifficulty(i));
			data[AFEHLCGHAEE_Strings.AFKHNFBOMKI_sc].Add(IDJJCEGLONI.BDCAICINCKK_GetScore(i));
			data["l6"].Add(IDJJCEGLONI.MJKFDJIPMMB_GetL6(i));
		}
		return data;
	}

	// // RVA: 0x1B995CC Offset: 0x1B995CC VA: 0x1B995CC Slot: 5
	public override void OKJPIBHMKMJ(EDOHBJAPLPF_JsonData OILEIIEIBHP, long _MCKEOKFMLAH_SaveId)
	{
		EDOHBJAPLPF_JsonData data = new EDOHBJAPLPF_JsonData();
		data[AFEHLCGHAEE_Strings.DIPKCALNIII_diva_id] = DIPKCALNIII_diva_id;
		data[AFEHLCGHAEE_Strings.ANAJIAENLNB_lv] = ANAJIAENLNB_lv;
		data[AFEHLCGHAEE_Strings.PIJNJBJMFHL_plv] = KIECDDFNCAN_Level;
		data[AFEHLCGHAEE_Strings.ODNOJKHHEOP_c_id] = BEEAIAAJOHD_CostumeId;
		data[AFEHLCGHAEE_Strings.FODKKJIDDKN_vf_Id] = FODKKJIDDKN_vf_Id;
		data[AFEHLCGHAEE_Strings.BKIFLJAMJGG_scn_cnt] = BKIFLJAMJGG_scn_cnt;
		data[AFEHLCGHAEE_Strings.ABLOIBMGLFD_em_id] = ABLOIBMGLFD_em_id;
		data[AFEHLCGHAEE_Strings.FHCAFLCLGAA_em_cnt] = FHCAFLCLGAA_em_cnt;
		data["c_col"] = AFNIOJHODAG_CostumeColorId;
		data[AFEHLCGHAEE_Strings.FOFGELKGMAH_cos_cnt] = FOFGELKGMAH_cos_cnt;
		data[AFEHLCGHAEE_Strings.MIFLBHBPBNF_vf_cnt] = MIFLBHBPBNF_vf_cnt;
		data[AFEHLCGHAEE_Strings.APFOBLMCLAO_q_cnt] = APFOBLMCLAO_q_cnt;
		data[AFEHLCGHAEE_Strings.JGDNCEANEBB_lv_max_cnt] = JGDNCEANEBB_lv_max_cnt;
		data[AFEHLCGHAEE_Strings.LDKEOMCNLBE_pf_tap] = LDKEOMCNLBE_pf_tap;
		data[AFEHLCGHAEE_Strings.PCBJHBCNNGD_t_clr] = PCBJHBCNNGD_t_clr;
		data[AFEHLCGHAEE_Strings.AEBENOJEGOJ_max_sc] = AEBENOJEGOJ_max_sc;
		data[AFEHLCGHAEE_Strings.JHOIMONJKLG_max_id] = JHOIMONJKLG_max_id;
		data[AFEHLCGHAEE_Strings.JEENEHPOCFN_max_df] = JEENEHPOCFN_max_df;
		data["max_l6"] = NADEAGFJDLL_MaxL6;
		{
			EDOHBJAPLPF_JsonData data2 = new EDOHBJAPLPF_JsonData();
			EDOHBJAPLPF_JsonData data3 = new EDOHBJAPLPF_JsonData();
			EDOHBJAPLPF_JsonData data4 = new EDOHBJAPLPF_JsonData();
			EDOHBJAPLPF_JsonData data5 = new EDOHBJAPLPF_JsonData();
			for (int i = 0; i < 5; i++)
			{
				data2.Add(PFHIOGBJDHM(i));
				data3.Add(KIBCDACEFIC(i));
				data4.Add(EJNGDOJAIDP(i));
				data5.Add(JFBMBPPHDLB(i));
			}
			data[AFEHLCGHAEE_Strings.MIODKKINJBD_df_clr] = data2;
			data[AFEHLCGHAEE_Strings.AGONOGEEGDL_df_fcb] = data3;
			data["df_clr_l6"] = data4;
			data["df_fcb_l6"] = data5;
		}
		data["mc_power"] = OENMBJEKJII_McPower;
		OAILDDLJFEE o = new OAILDDLJFEE();
		data[AFEHLCGHAEE_Strings.HHOCBLMEGGM_m_scene] = o.AEFEIKGDBMD(AFBMEMCHJCL_MainScene);
		data[AFEHLCGHAEE_Strings.CBIKELHFHCA_assist_data] = o.LPGBJBHFINB(MGMFOJPNDGA_AssistData);
		{
			EDOHBJAPLPF_JsonData data2 = new EDOHBJAPLPF_JsonData();
			data[AFEHLCGHAEE_Strings.EPMALNDIDJM_s_scene] = data2;
			data2.LAJDIPCJCPO_SetJsonType(JFBMDLGBPEN_JsonType.BDHGEFMCJDF_Array);
			for(int i = 0; i < HDJOHAJPGBA_SubScene.Count; i++)
			{
				data2.Add(o.AEFEIKGDBMD(HDJOHAJPGBA_SubScene[i]));
			}
		}
		{
			EDOHBJAPLPF_JsonData data2 = new EDOHBJAPLPF_JsonData();
			data[AFEHLCGHAEE_Strings.BIAPEOAOJNG_hs_rating] = data2;
			data2.LAJDIPCJCPO_SetJsonType(JFBMDLGBPEN_JsonType.BDHGEFMCJDF_Array);
			data2.Add(BJIJBKEABPO(AEIADFODLMC_HsRating[0]));
		}
		data["psh"] = IPJPAAFNAOF_Psh;
		data["dc_nm"] = IJCPFDPNDHE_DcNm;
		data["dc_tm"] = DALCINDEJLC_DcTm;
		data["utarate_rank"] = AILEOFKIELL_UtaRateRank;
		data[AFEHLCGHAEE_Strings.KAKFEGGEKLB_save_id] = _MCKEOKFMLAH_SaveId;
		data[AFEHLCGHAEE_Strings.AGPKGMFOJHC_rev] = 2;
		OILEIIEIBHP[JIKKNHIAEKG_BlockName] = data;
	}

	// // RVA: 0x1B9A6FC Offset: 0x1B9A6FC VA: 0x1B9A6FC
	private void LFNFJHGDKAA(ONCMONJIPCD _IDLHJIOMJBK_data, EDOHBJAPLPF_JsonData OBHAFLMHAKG, ref bool _NGJDHLGMHMH_IsInvalid)
	{
		for(int i = 0; i < 4; i++)
		{
			EDOHBJAPLPF_JsonData data = OBHAFLMHAKG[AFEHLCGHAEE_Strings.GGLICPAANFE_assist_data_list][i];
			EHEMJOHCJOG(_IDLHJIOMJBK_data.JOHLGBDOLNO_AssistScenes[i], data, ref _NGJDHLGMHMH_IsInvalid);
		}
		_IDLHJIOMJBK_data.JCJNKBKMJFK_Name = FGCNMLBACGO_GetString(OBHAFLMHAKG, AFEHLCGHAEE_Strings.COEBIDJMMCH_assist_name, "", ref _NGJDHLGMHMH_IsInvalid);
	}

	// // RVA: 0x1B9A8CC Offset: 0x1B9A8CC VA: 0x1B9A8CC
	private void EHEMJOHCJOG(KNHIPBADANI KDIFMECGNIC, EDOHBJAPLPF_JsonData OBHAFLMHAKG, ref bool _NGJDHLGMHMH_IsInvalid)
	{
		KDIFMECGNIC.KMBPACJNEOF_Reset();
		KDIFMECGNIC.PPFNGGCBJKC_id = CJAENOMGPDA_GetInt(OBHAFLMHAKG, AFEHLCGHAEE_Strings.PPFNGGCBJKC_id, 0, ref _NGJDHLGMHMH_IsInvalid);
		bool hasDb = false;
		if(IMMAOANGPNK_NetMasterDataManager.HHCJCDFCLOB_Instance.LNAHEIEIBOI_Initialized)
		{
			if(IMMAOANGPNK_NetMasterDataManager.HHCJCDFCLOB_Instance.NKEBMCIMJND_Database != null)
			{
				hasDb = true;
				if (!IMMAOANGPNK_NetMasterDataManager.HHCJCDFCLOB_Instance.NKEBMCIMJND_Database.ECNHDEHADGL_Scene.FGNJBMPDBLO_IsSceneValid(KDIFMECGNIC.PPFNGGCBJKC_id))
					KDIFMECGNIC.PPFNGGCBJKC_id = 0;
			}
		}
		KDIFMECGNIC.ANAJIAENLNB_lv = CJAENOMGPDA_GetInt(OBHAFLMHAKG, AFEHLCGHAEE_Strings.ANAJIAENLNB_lv, 0, ref _NGJDHLGMHMH_IsInvalid);
		KDIFMECGNIC.MJBODMOLOBC_luck = CJAENOMGPDA_GetInt(OBHAFLMHAKG, AFEHLCGHAEE_Strings.MJBODMOLOBC_luck, 0, ref _NGJDHLGMHMH_IsInvalid);
		KDIFMECGNIC.JPIPENJGGDD_NumBoard = CJAENOMGPDA_GetInt(OBHAFLMHAKG, AFEHLCGHAEE_Strings.ALMNMBDELDB_mlt, 0, ref _NGJDHLGMHMH_IsInvalid);
		KDIFMECGNIC.DMNIMMGGJJJ_Leaf = CJAENOMGPDA_GetInt(OBHAFLMHAKG, "leaf", 0, ref _NGJDHLGMHMH_IsInvalid);
		if(hasDb && IMMAOANGPNK_NetMasterDataManager.HHCJCDFCLOB_Instance.NKEBMCIMJND_Database.HDGOHBFKKDM_LimitOver.AJHBAOCLNDF_MasterSw != 2)
		{
			KDIFMECGNIC.DMNIMMGGJJJ_Leaf = 0;
		}
		CEDHHAGBIBA.IFOLECIIDPO_StringToByteArray(KDIFMECGNIC.PDNIFBEGMHC_Mb, FGCNMLBACGO_GetString(OBHAFLMHAKG, AFEHLCGHAEE_Strings.DANMJLOBLIE_mb, "", ref _NGJDHLGMHMH_IsInvalid));
		CEDHHAGBIBA.IFOLECIIDPO_StringToByteArray(KDIFMECGNIC.EMOJHJGHJLN_Sb, FGCNMLBACGO_GetString(OBHAFLMHAKG, AFEHLCGHAEE_Strings.KOHNLDKIKPC_sb, "", ref _NGJDHLGMHMH_IsInvalid));
		KDIFMECGNIC.ANAJIAENLNB_lv = CEDHHAGBIBA.OGPFNHOKONH_GetNumBitActive(KDIFMECGNIC.PDNIFBEGMHC_Mb) + 1;
		if(KDIFMECGNIC.MJBODMOLOBC_luck < 0)
			KDIFMECGNIC.MJBODMOLOBC_luck = 0;
		if (KDIFMECGNIC.MJBODMOLOBC_luck > 25)
			KDIFMECGNIC.MJBODMOLOBC_luck = 25;

	}

	// // RVA: 0x1B9B29C Offset: 0x1B9B29C VA: 0x1B9B29C
	private void PLLNFEBKLBH(LBGEDDJKOKF IDJJCEGLONI, EDOHBJAPLPF_JsonData OBHAFLMHAKG, ref bool _NGJDHLGMHMH_IsInvalid)
	{
		IDJJCEGLONI.KMBPACJNEOF_Reset();
		IBCGPBOGOGP_ReadIntArray(OBHAFLMHAKG, AFEHLCGHAEE_Strings.PPFNGGCBJKC_id, 0, 10, (int _OIPCCBHIKIA_index, int _JBGEEPFKIGG_val) =>
		{
			//0x1BA155C
			IDJJCEGLONI.GMLHMKAMOEN_SetFreeMusicId(_OIPCCBHIKIA_index, _JBGEEPFKIGG_val);
		}, ref _NGJDHLGMHMH_IsInvalid);
		IBCGPBOGOGP_ReadIntArray(OBHAFLMHAKG, AFEHLCGHAEE_Strings.GOKJLBDJOLA_df, 0, 10, (int _OIPCCBHIKIA_index, int _JBGEEPFKIGG_val) =>
		{
			//0x1BA1594
			IDJJCEGLONI.HJHBGHMNGKL_SetDifficulty(_OIPCCBHIKIA_index, _JBGEEPFKIGG_val);
		}, ref _NGJDHLGMHMH_IsInvalid);
		IBCGPBOGOGP_ReadIntArray(OBHAFLMHAKG, AFEHLCGHAEE_Strings.AFKHNFBOMKI_sc, 0, 10, (int _OIPCCBHIKIA_index, int _JBGEEPFKIGG_val) =>
		{
			//0x1BA15CC
			IDJJCEGLONI.ECKFCIHPHGJ_SetScore(_OIPCCBHIKIA_index, _JBGEEPFKIGG_val);
		}, ref _NGJDHLGMHMH_IsInvalid);
		IBCGPBOGOGP_ReadIntArray(OBHAFLMHAKG, "l6", 0, 10, (int _OIPCCBHIKIA_index, int _JBGEEPFKIGG_val) =>
		{
			//0x1BA1604
			IDJJCEGLONI.HPDBEKAGKOD_SetIsLine6(_OIPCCBHIKIA_index, _JBGEEPFKIGG_val);
		}, ref _NGJDHLGMHMH_IsInvalid);
		for(int i = 0; i <10; i++)
		{
			if(!IDJJCEGLONI.GEJEDJNKBOF_Validate(i))
			{
				IDJJCEGLONI.GMLHMKAMOEN_SetFreeMusicId(i, 0);
				IDJJCEGLONI.HJHBGHMNGKL_SetDifficulty(i, 0);
				IDJJCEGLONI.ECKFCIHPHGJ_SetScore(i, 0);
				IDJJCEGLONI.HPDBEKAGKOD_SetIsLine6(i, 0);
			}
		}
	}

	// // RVA: 0x1B9BBD4 Offset: 0x1B9BBD4 VA: 0x1B9BBD4 Slot: 6
	public override bool IIEMACPEEBJ_Deserialize(EDOHBJAPLPF_JsonData OILEIIEIBHP)
	{
		bool isInvalid = false;
		if(!OILEIIEIBHP.BBAJPINMOEP_Contains(JIKKNHIAEKG_BlockName))
		{
			return false;
		}
		EDOHBJAPLPF_JsonData data = OILEIIEIBHP[JIKKNHIAEKG_BlockName];
		if(!data.BBAJPINMOEP_Contains(AFEHLCGHAEE_Strings.AGPKGMFOJHC_rev))
		{
			isInvalid = true;
		}
		else
		{
			if((int)data[AFEHLCGHAEE_Strings.AGPKGMFOJHC_rev] != 2)
				isInvalid = true;
		}
		OKGLGHCBCJP_Database db = null;
		if(IMMAOANGPNK_NetMasterDataManager.HHCJCDFCLOB_Instance.LNAHEIEIBOI_Initialized)
		{
			db = IMMAOANGPNK_NetMasterDataManager.HHCJCDFCLOB_Instance.NKEBMCIMJND_Database;
		}
		DIPKCALNIII_diva_id = CJAENOMGPDA_GetInt(data, AFEHLCGHAEE_Strings.DIPKCALNIII_diva_id, 1, ref isInvalid);
		BEEAIAAJOHD_CostumeId = CJAENOMGPDA_GetInt(data, AFEHLCGHAEE_Strings.ODNOJKHHEOP_c_id, 0, ref isInvalid);
		AFNIOJHODAG_CostumeColorId = CJAENOMGPDA_GetInt(data, "c_col", 0, ref isInvalid);
		if(db != null)
		{
			if (!db.MGFMPKLLGHE_Diva.BEEGJHCDHJB_IsDivaAvaiable(DIPKCALNIII_diva_id))
				DIPKCALNIII_diva_id = 1;
			if (!db.MFPNGNMFEAL_Costume.OEMKAFGPOCE_IsCostumeAvaiable(BEEAIAAJOHD_CostumeId, DIPKCALNIII_diva_id))
				BEEAIAAJOHD_CostumeId = 0;
			if (!db.MFPNGNMFEAL_Costume.KPHOIIKOEOG_IsColorAvaiable(AFNIOJHODAG_CostumeColorId, BEEAIAAJOHD_CostumeId, DIPKCALNIII_diva_id))
				AFNIOJHODAG_CostumeColorId = 0;
		}
		ANAJIAENLNB_lv = CJAENOMGPDA_GetInt(data, AFEHLCGHAEE_Strings.ANAJIAENLNB_lv, 1, ref isInvalid);
		if(db != null)
		{
			if(!db.MFPNGNMFEAL_Costume.OEMKAFGPOCE_IsCostumeAvaiable(BEEAIAAJOHD_CostumeId, DIPKCALNIII_diva_id))
			{
				BEEAIAAJOHD_CostumeId = 0;
				AFNIOJHODAG_CostumeColorId = 0;
			}
		}
		KIECDDFNCAN_Level = CJAENOMGPDA_GetInt(data, AFEHLCGHAEE_Strings.PIJNJBJMFHL_plv, 1, ref isInvalid);
		ABLOIBMGLFD_em_id = CJAENOMGPDA_GetInt(data, AFEHLCGHAEE_Strings.ABLOIBMGLFD_em_id, 1, ref isInvalid);
		if (ABLOIBMGLFD_em_id == 0)
			ABLOIBMGLFD_em_id = 1;
		FHCAFLCLGAA_em_cnt = CJAENOMGPDA_GetInt(data, AFEHLCGHAEE_Strings.FHCAFLCLGAA_em_cnt, 0, ref isInvalid);
		if(db != null)
		{
			if(!db.LBNBNAFGMDE_Emblem.MNFCLPNLFIJ_IsEmblemAvaiable(ABLOIBMGLFD_em_id))
			{
				ABLOIBMGLFD_em_id = 1;
				FHCAFLCLGAA_em_cnt = 0;
			}
		}
		BKIFLJAMJGG_scn_cnt = CJAENOMGPDA_GetInt(data, AFEHLCGHAEE_Strings.BKIFLJAMJGG_scn_cnt, 1, ref isInvalid);
		FODKKJIDDKN_vf_Id = CJAENOMGPDA_GetInt(data, AFEHLCGHAEE_Strings.FODKKJIDDKN_vf_Id, 1, ref isInvalid);
		if(db != null)
		{
			if (!db.PEOALFEGNDH_Valkyrie.PILGJJCABME_IsValkyrieAvaiable(FODKKJIDDKN_vf_Id))
				FODKKJIDDKN_vf_Id = 1;
		}
		BKIFLJAMJGG_scn_cnt = CJAENOMGPDA_GetInt(data, AFEHLCGHAEE_Strings.BKIFLJAMJGG_scn_cnt, 1, ref isInvalid);
		FOFGELKGMAH_cos_cnt = CJAENOMGPDA_GetInt(data, AFEHLCGHAEE_Strings.FOFGELKGMAH_cos_cnt, 1, ref isInvalid);
		MIFLBHBPBNF_vf_cnt = CJAENOMGPDA_GetInt(data, AFEHLCGHAEE_Strings.MIFLBHBPBNF_vf_cnt, 1, ref isInvalid);
		APFOBLMCLAO_q_cnt = CJAENOMGPDA_GetInt(data, AFEHLCGHAEE_Strings.APFOBLMCLAO_q_cnt, 0, ref isInvalid);
		JGDNCEANEBB_lv_max_cnt = CJAENOMGPDA_GetInt(data, AFEHLCGHAEE_Strings.JGDNCEANEBB_lv_max_cnt, 0, ref isInvalid);
		LDKEOMCNLBE_pf_tap = CJAENOMGPDA_GetInt(data, AFEHLCGHAEE_Strings.LDKEOMCNLBE_pf_tap, 0, ref isInvalid);
		PCBJHBCNNGD_t_clr = CJAENOMGPDA_GetInt(data, AFEHLCGHAEE_Strings.PCBJHBCNNGD_t_clr, 0, ref isInvalid);
		AEBENOJEGOJ_max_sc = CJAENOMGPDA_GetInt(data, AFEHLCGHAEE_Strings.AEBENOJEGOJ_max_sc, 0, ref isInvalid);
		JHOIMONJKLG_max_id = CJAENOMGPDA_GetInt(data, AFEHLCGHAEE_Strings.JHOIMONJKLG_max_id, 0, ref isInvalid);
		JEENEHPOCFN_max_df = CJAENOMGPDA_GetInt(data, AFEHLCGHAEE_Strings.JEENEHPOCFN_max_df, 0, ref isInvalid);
		NADEAGFJDLL_MaxL6 = CJAENOMGPDA_GetInt(data, "max_l6", 0, ref isInvalid);
		IBCGPBOGOGP_ReadIntArray(data, AFEHLCGHAEE_Strings.MIODKKINJBD_df_clr, 0, 5, (int _OIPCCBHIKIA_index, int _JBGEEPFKIGG_val) =>
		{
			//0x1BA154C
			BAHLFHCOEHO(_OIPCCBHIKIA_index, _JBGEEPFKIGG_val);
		}, ref isInvalid);
		IBCGPBOGOGP_ReadIntArray(data, AFEHLCGHAEE_Strings.AGONOGEEGDL_df_fcb, 0, 5, (int _OIPCCBHIKIA_index, int _JBGEEPFKIGG_val) =>
		{
			//0x1BA1550
			CECEAOLLLNG(_OIPCCBHIKIA_index, _JBGEEPFKIGG_val);
		}, ref isInvalid);
		IBCGPBOGOGP_ReadIntArray(data, "df_clr_l6", 0, 5, (int _OIPCCBHIKIA_index, int _JBGEEPFKIGG_val) =>
		{
			//0x1BA1554
			PCBEBNAHCDH(_OIPCCBHIKIA_index, _JBGEEPFKIGG_val);
		}, ref isInvalid);
		IBCGPBOGOGP_ReadIntArray(data, "df_fcb_l6", 0, 5, (int _OIPCCBHIKIA_index, int _JBGEEPFKIGG_val) =>
		{
			//0x1BA1558
			KLAALDBEAJM(_OIPCCBHIKIA_index, _JBGEEPFKIGG_val);
		}, ref isInvalid);
		OENMBJEKJII_McPower = CJAENOMGPDA_GetInt(data, "mc_power", 0, ref isInvalid);
		IPJPAAFNAOF_Psh = CJAENOMGPDA_GetInt(data, "psh", 0, ref isInvalid);
		AILEOFKIELL_UtaRateRank = CJAENOMGPDA_GetInt(data, "utarate_rank", 0, ref isInvalid);
		if (KIECDDFNCAN_Level < 1)
			KIECDDFNCAN_Level = 1;
		if(data.BBAJPINMOEP_Contains(AFEHLCGHAEE_Strings.HHOCBLMEGGM_m_scene) && data[AFEHLCGHAEE_Strings.HHOCBLMEGGM_m_scene].LLHIGGPIILM_IsObject)
			EHEMJOHCJOG(AFBMEMCHJCL_MainScene, data[AFEHLCGHAEE_Strings.HHOCBLMEGGM_m_scene], ref isInvalid);
		else
			KFKDMBPNLJK_BlockInvalid = true;
		if (data.BBAJPINMOEP_Contains(AFEHLCGHAEE_Strings.CBIKELHFHCA_assist_data) && data[AFEHLCGHAEE_Strings.CBIKELHFHCA_assist_data].LLHIGGPIILM_IsObject)
			LFNFJHGDKAA(MGMFOJPNDGA_AssistData, data[AFEHLCGHAEE_Strings.CBIKELHFHCA_assist_data], ref isInvalid);
		else
			KFKDMBPNLJK_BlockInvalid = true;
		if(data.BBAJPINMOEP_Contains(AFEHLCGHAEE_Strings.EPMALNDIDJM_s_scene) && data[AFEHLCGHAEE_Strings.EPMALNDIDJM_s_scene].EPNGJLOKGIF_IsArray)
		{
			int num = data[AFEHLCGHAEE_Strings.EPMALNDIDJM_s_scene].HNBFOAJIIAL_Count;
			if(HDJOHAJPGBA_SubScene.Count < num)
			{
				num = HDJOHAJPGBA_SubScene.Count;
			}
			for(int i = 0; i < num; i++)
			{
				EHEMJOHCJOG(HDJOHAJPGBA_SubScene[i], data[AFEHLCGHAEE_Strings.EPMALNDIDJM_s_scene][i], ref isInvalid);
			}
		}
		else
			KFKDMBPNLJK_BlockInvalid = true;
		if(data.BBAJPINMOEP_Contains(AFEHLCGHAEE_Strings.BIAPEOAOJNG_hs_rating) && data[AFEHLCGHAEE_Strings.BIAPEOAOJNG_hs_rating].EPNGJLOKGIF_IsArray)
		{
			int num = data[AFEHLCGHAEE_Strings.BIAPEOAOJNG_hs_rating].HNBFOAJIIAL_Count;
			if (AEIADFODLMC_HsRating.Count < num)
			{
				num = AEIADFODLMC_HsRating.Count;
			}
			for (int i = 0; i < num; i++)
			{
				PLLNFEBKLBH(AEIADFODLMC_HsRating[i], data[AFEHLCGHAEE_Strings.BIAPEOAOJNG_hs_rating][i], ref isInvalid);
			}
		}
		else
			KFKDMBPNLJK_BlockInvalid = true;
		NAKJJBEIION_DcNm = FGCNMLBACGO_GetString(data, "dc_nm", "", ref isInvalid);
		DALCINDEJLC_DcTm = DKMPHAPBDLH_GetLong(data, "dc_tm", 0, ref isInvalid);
		KFKDMBPNLJK_BlockInvalid = isInvalid;
		return true;
	}

	// // RVA: 0x1B9D350 Offset: 0x1B9D350 VA: 0x1B9D350 Slot: 7
	public override void BMGGKONLFIC_Copy(KLFDBFMNLBL_ServerSaveBlock GPBJHKLFCEP)
	{
		JNMFKOHFAFB_PublicStatus p = GPBJHKLFCEP as JNMFKOHFAFB_PublicStatus;
		DIPKCALNIII_diva_id = p.DIPKCALNIII_diva_id;
		ANAJIAENLNB_lv = p.ANAJIAENLNB_lv;
		BEEAIAAJOHD_CostumeId = p.BEEAIAAJOHD_CostumeId;
		AFNIOJHODAG_CostumeColorId = p.AFNIOJHODAG_CostumeColorId;
		KIECDDFNCAN_Level = p.KIECDDFNCAN_Level;
		ABLOIBMGLFD_em_id = p.ABLOIBMGLFD_em_id;
		FHCAFLCLGAA_em_cnt = p.FHCAFLCLGAA_em_cnt;
		BKIFLJAMJGG_scn_cnt = p.BKIFLJAMJGG_scn_cnt;
		FODKKJIDDKN_vf_Id = p.FODKKJIDDKN_vf_Id;
		FOFGELKGMAH_cos_cnt = p.FOFGELKGMAH_cos_cnt;
		MIFLBHBPBNF_vf_cnt = p.MIFLBHBPBNF_vf_cnt;
		APFOBLMCLAO_q_cnt = p.APFOBLMCLAO_q_cnt;
		JGDNCEANEBB_lv_max_cnt = p.JGDNCEANEBB_lv_max_cnt;
		LDKEOMCNLBE_pf_tap = p.LDKEOMCNLBE_pf_tap;
		PCBJHBCNNGD_t_clr = p.PCBJHBCNNGD_t_clr;
		AEBENOJEGOJ_max_sc = p.AEBENOJEGOJ_max_sc;
		JHOIMONJKLG_max_id = p.JHOIMONJKLG_max_id;
		JEENEHPOCFN_max_df = p.JEENEHPOCFN_max_df;
		NADEAGFJDLL_MaxL6 = p.NADEAGFJDLL_MaxL6;
		for(int i = 0; i < 5; i++)
		{
			BAHLFHCOEHO(i, p.PFHIOGBJDHM(i));
			CECEAOLLLNG(i, p.KIBCDACEFIC(i));
			PCBEBNAHCDH(i, p.EJNGDOJAIDP(i));
			KLAALDBEAJM(i, p.JFBMBPPHDLB(i));
		}
		OENMBJEKJII_McPower = p.OENMBJEKJII_McPower;
		IPJPAAFNAOF_Psh = p.IPJPAAFNAOF_Psh;
		AILEOFKIELL_UtaRateRank = p.AILEOFKIELL_UtaRateRank;
		AFBMEMCHJCL_MainScene.ODDIHGPONFL_Copy(p.AFBMEMCHJCL_MainScene);
		MGMFOJPNDGA_AssistData.ODDIHGPONFL_Copy(p.MGMFOJPNDGA_AssistData);
		for(int i = 0; i < p.HDJOHAJPGBA_SubScene.Count; i++)
		{
			HDJOHAJPGBA_SubScene[i].ODDIHGPONFL_Copy(p.HDJOHAJPGBA_SubScene[i]);
		}
		for(int i = 0; i < p.AEIADFODLMC_HsRating.Count; i++)
		{
			AEIADFODLMC_HsRating[i].ODDIHGPONFL_Copy(p.AEIADFODLMC_HsRating[i]);
		}
		IJCPFDPNDHE_DcNm = string.Copy(p.IJCPFDPNDHE_DcNm);
		DALCINDEJLC_DcTm = p.DALCINDEJLC_DcTm;
	}

	// // RVA: 0x1B9DF8C Offset: 0x1B9DF8C VA: 0x1B9DF8C Slot: 8
	public override bool AGBOGBEOFME(KLFDBFMNLBL_ServerSaveBlock GPBJHKLFCEP)
	{
		JNMFKOHFAFB_PublicStatus other = GPBJHKLFCEP as JNMFKOHFAFB_PublicStatus;
		if(BEEAIAAJOHD_CostumeId != other.BEEAIAAJOHD_CostumeId ||
			DIPKCALNIII_diva_id != other.DIPKCALNIII_diva_id ||
			ANAJIAENLNB_lv != other.ANAJIAENLNB_lv ||
			AFNIOJHODAG_CostumeColorId != other.AFNIOJHODAG_CostumeColorId ||
			KIECDDFNCAN_Level != other.KIECDDFNCAN_Level ||
			HDJOHAJPGBA_SubScene.Count != other.HDJOHAJPGBA_SubScene.Count ||
			ABLOIBMGLFD_em_id != other.ABLOIBMGLFD_em_id ||
			FHCAFLCLGAA_em_cnt != other.FHCAFLCLGAA_em_cnt ||
			FODKKJIDDKN_vf_Id != other.FODKKJIDDKN_vf_Id ||
			BKIFLJAMJGG_scn_cnt != other.BKIFLJAMJGG_scn_cnt ||
			FOFGELKGMAH_cos_cnt != other.FOFGELKGMAH_cos_cnt ||
			MIFLBHBPBNF_vf_cnt != other.MIFLBHBPBNF_vf_cnt ||
			APFOBLMCLAO_q_cnt != other.APFOBLMCLAO_q_cnt ||
			JGDNCEANEBB_lv_max_cnt != other.JGDNCEANEBB_lv_max_cnt ||
			LDKEOMCNLBE_pf_tap != other.LDKEOMCNLBE_pf_tap ||
			PCBJHBCNNGD_t_clr != other.PCBJHBCNNGD_t_clr ||
			DALCINDEJLC_DcTm != other.DALCINDEJLC_DcTm ||
			AEBENOJEGOJ_max_sc != other.AEBENOJEGOJ_max_sc ||
			JHOIMONJKLG_max_id != other.JHOIMONJKLG_max_id ||
			JEENEHPOCFN_max_df != other.JEENEHPOCFN_max_df ||
			NADEAGFJDLL_MaxL6 != other.NADEAGFJDLL_MaxL6 ||
			OENMBJEKJII_McPower != other.OENMBJEKJII_McPower ||
			IPJPAAFNAOF_Psh != other.IPJPAAFNAOF_Psh ||
			IJCPFDPNDHE_DcNm != other.IJCPFDPNDHE_DcNm ||
			AILEOFKIELL_UtaRateRank != other.AILEOFKIELL_UtaRateRank)
			return false;
		for(int i = 0; i < 5; i++)
		{
			if(PFHIOGBJDHM(i) != other.PFHIOGBJDHM(i) ||
				KIBCDACEFIC(i) != other.KIBCDACEFIC(i) ||
				EJNGDOJAIDP(i) != other.EJNGDOJAIDP(i) ||
				JFBMBPPHDLB(i) != other.JFBMBPPHDLB(i))
			return false;
		}
		if(!AFBMEMCHJCL_MainScene.AGBOGBEOFME(other.AFBMEMCHJCL_MainScene) ||
			!MGMFOJPNDGA_AssistData.AGBOGBEOFME(other.MGMFOJPNDGA_AssistData))
			return false;
		for(int i = 0; i < other.HDJOHAJPGBA_SubScene.Count; i++)
		{
			if(!HDJOHAJPGBA_SubScene[i].AGBOGBEOFME(other.HDJOHAJPGBA_SubScene[i]))
				return false;
		}
		for(int i = 0; i < other.AEIADFODLMC_HsRating.Count; i++)
		{
			if(!AEIADFODLMC_HsRating[i].AGBOGBEOFME(other.AEIADFODLMC_HsRating[i]))
				return false;
		}
		return true;
	}

	// // RVA: 0x1B9ECAC Offset: 0x1B9ECAC VA: 0x1B9ECAC Slot: 10
	//public override void AGHKODFKOJI(BHBONAHFKHD JBBHNIACMFJ, KLFDBFMNLBL_ServerSaveBlock _GJLFANGDGCL_Target, long _MCKEOKFMLAH_SaveId);
}
