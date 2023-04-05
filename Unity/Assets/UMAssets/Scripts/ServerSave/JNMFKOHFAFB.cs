using System.Collections.Generic;
using XeSys;

[System.Obsolete("Use JNMFKOHFAFB_PublicStatus", true)]
public class JNMFKOHFAFB { }
public class JNMFKOHFAFB_PublicStatus : KLFDBFMNLBL_ServerSaveBlock
{
	public class KNHIPBADANI
	{
		public static int FBGGEFFJJHB = 0x46bd435; // 0x0
		private int ELMLPFGPIIM_LeafCrypted; // 0x8
		private int EHOIENNDEDH_IdCrypted; // 0xC
		private int MBCPMFPKNBA_LevelCrypted; // 0x10
		private int MDIGCJGJBBA_LeafCheck; // 0x14
		private int NKCNFBCEEOI_LuckCrypted; // 0x18
		private int FEIKCJFNEGC_LuckCheck; // 0x1C
		private int OPLKJKAIFPF_MltCrypted; // 0x20
		public byte[] PDNIFBEGMHC_Mb = new byte[15]; // 0x24
		public byte[] EMOJHJGHJLN_Sb = new byte[50]; // 0x28

		public int PPFNGGCBJKC_Id { get { return EHOIENNDEDH_IdCrypted ^ FBGGEFFJJHB; } set { EHOIENNDEDH_IdCrypted = FBGGEFFJJHB ^ value; } } //0x1B9AEE8 DEMEPMAEJOO 0x1B9AE4C HIGKAIDMOKN
		public int ANAJIAENLNB_Level { get { return MBCPMFPKNBA_LevelCrypted ^ FBGGEFFJJHB; } set { MBCPMFPKNBA_LevelCrypted = FBGGEFFJJHB ^ value; } } //0x1BA163C MMOMNMBKHJF 0x1B9AF80 FEHNFGPFINK
		public int MJBODMOLOBC_Luck { get { 
			int val = NKCNFBCEEOI_LuckCrypted ^ FBGGEFFJJHB;
			if(val != FEIKCJFNEGC_LuckCheck)
				return 0;
			return val;
		 } set
		 {
			NKCNFBCEEOI_LuckCrypted = FBGGEFFJJHB ^ value;
			FEIKCJFNEGC_LuckCheck = value;
		 } } //0x1B9B1F8 JDPBFBEBJOK 0x1B9B01C PNKGEPNKKBM
		public int JPIPENJGGDD_Mlt { get { return OPLKJKAIFPF_MltCrypted ^ FBGGEFFJJHB; } set { OPLKJKAIFPF_MltCrypted = FBGGEFFJJHB ^ value; } } //0x1BA16D4 FBLKAMOKPPP 0x1B9B0BC BEEPHNBJGLI
		public int DMNIMMGGJJJ_Leaf { get { int val = ELMLPFGPIIM_LeafCrypted ^ FBGGEFFJJHB; return (val != MDIGCJGJBBA_LeafCheck ? 0 : val); } set { MDIGCJGJBBA_LeafCheck = value; ELMLPFGPIIM_LeafCrypted = value ^ FBGGEFFJJHB; } } //0x1BA176C CJCDKIKDBNP 0x1B9B158 CCGHKFJEFCB

		// // RVA: 0x1B98808 Offset: 0x1B98808 VA: 0x1B98808
		public void KMBPACJNEOF()
		{
			PPFNGGCBJKC_Id = 0;
			ANAJIAENLNB_Level = 0;
			MJBODMOLOBC_Luck = 0;
			JPIPENJGGDD_Mlt = 0;
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
		public void ODDIHGPONFL(KNHIPBADANI GPBJHKLFCEP)
		{
			PPFNGGCBJKC_Id = GPBJHKLFCEP.PPFNGGCBJKC_Id;
			ANAJIAENLNB_Level = GPBJHKLFCEP.ANAJIAENLNB_Level;
			MJBODMOLOBC_Luck = GPBJHKLFCEP.MJBODMOLOBC_Luck;
			JPIPENJGGDD_Mlt = GPBJHKLFCEP.JPIPENJGGDD_Mlt;
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
		// public bool AGBOGBEOFME(JNMFKOHFAFB.KNHIPBADANI GPBJHKLFCEP) { }

		// // RVA: 0x1BA1810 Offset: 0x1BA1810 VA: 0x1BA1810
		public void DOMFHDPMCCO(int BCCHOBPJJKE, byte[] KBOLNIBLIND, byte[] ODKMKEHJOCK, int MJBODMOLOBC, int JPIPENJGGDD, int DMNIMMGGJJJ)
		{
			PPFNGGCBJKC_Id = BCCHOBPJJKE;
			ANAJIAENLNB_Level = 1;
			if (MJBODMOLOBC < 1)
				MJBODMOLOBC = 0;
			if (MJBODMOLOBC > 24)
				MJBODMOLOBC = 25;
			MJBODMOLOBC_Luck = MJBODMOLOBC;
			JPIPENJGGDD_Mlt = JPIPENJGGDD;
			DMNIMMGGJJJ_Leaf = DMNIMMGGJJJ;
			if(KBOLNIBLIND == null)
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
					PDNIFBEGMHC_Mb[i] = KBOLNIBLIND[i];
				}
			}
			if(ODKMKEHJOCK == null)
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
					EMOJHJGHJLN_Sb[i] = ODKMKEHJOCK[i];
				}
			}
		}
	}

	public class ONCMONJIPCD
	{
		private const string OPEJBCMIAJH = "アシスト{0}";
		public JNMFKOHFAFB_PublicStatus.KNHIPBADANI[] JOHLGBDOLNO_DataList = new JNMFKOHFAFB_PublicStatus.KNHIPBADANI[4]; // 0x8
		public string JCJNKBKMJFK_Name; // 0xC

		// // RVA: 0x1B98914 Offset: 0x1B98914 VA: 0x1B98914
		public void KMBPACJNEOF(int OIPCCBHIKIA)
		{
			for(int i = 0; i < JOHLGBDOLNO_DataList.Length; i++)
			{
				JOHLGBDOLNO_DataList[i] = new JNMFKOHFAFB_PublicStatus.KNHIPBADANI();
				JOHLGBDOLNO_DataList[i].KMBPACJNEOF();
			}
			JCJNKBKMJFK_Name = string.Format(OPEJBCMIAJH, OIPCCBHIKIA + 1);
		}

		// // RVA: 0x1BA1B3C Offset: 0x1BA1B3C VA: 0x1BA1B3C
		public void DOMFHDPMCCO(KNHIPBADANI[] NNDGIAEFMOG, string OPFGFINHFCE)
		{
			for(int i = 0; i < JOHLGBDOLNO_DataList.Length; i++)
			{
				if(JOHLGBDOLNO_DataList[i] == null)
				{
					JOHLGBDOLNO_DataList[i] = new KNHIPBADANI();
				}
				JOHLGBDOLNO_DataList[i].ODDIHGPONFL(NNDGIAEFMOG[i]);
			}
			JCJNKBKMJFK_Name = OPFGFINHFCE;
		}

		// // RVA: 0x1B9DDA8 Offset: 0x1B9DDA8 VA: 0x1B9DDA8
		public void ODDIHGPONFL(ONCMONJIPCD GPBJHKLFCEP)
		{
			JCJNKBKMJFK_Name = GPBJHKLFCEP.JCJNKBKMJFK_Name;
			for(int i = 0; i < JOHLGBDOLNO_DataList.Length; i++)
			{
				JOHLGBDOLNO_DataList[i].ODDIHGPONFL(GPBJHKLFCEP.JOHLGBDOLNO_DataList[i]);
			}
		}

		// // RVA: 0x1B9EAA0 Offset: 0x1B9EAA0 VA: 0x1B9EAA0
		// public bool AGBOGBEOFME(JNMFKOHFAFB.ONCMONJIPCD GPBJHKLFCEP) { }
	}

	public class LBGEDDJKOKF
	{
		public static int FBGGEFFJJHB = 0x9610ff; // 0x0
		private int[] EHOIENNDEDH_FreeMusicIds = new int[10]; // 0x8
		private int[] EHLGHDIACCG_Difficulty = new int[10]; // 0xC
		private int[] PCFFCAAIPNB_Score = new int[10]; // 0x10
		private int[] JALJMLNOLII_L6 = new int[10]; // 0x14

		// // RVA: 0x1B9B84C Offset: 0x1B9B84C VA: 0x1B9B84C
		public void GMLHMKAMOEN_SetFreeMusicId(int IKPIDCFOFEA, int PPFNGGCBJKC)
		{
			if(PPFNGGCBJKC <= 2000 && IKPIDCFOFEA <= 9)
			{
				EHOIENNDEDH_FreeMusicIds[IKPIDCFOFEA] = PPFNGGCBJKC ^ FBGGEFFJJHB;
			}
		}

		// // RVA: 0x1B99224 Offset: 0x1B99224 VA: 0x1B99224
		public int MLKHJPBAFCO_GetFreeMusicId(int IKPIDCFOFEA)
		{
			int val = 0;
			if(IKPIDCFOFEA < 10)
			{
				val = EHOIENNDEDH_FreeMusicIds[IKPIDCFOFEA];
				if (val < 0 || val > 2000)
					val = 0;
			}
			return val;
		}

		// // RVA: 0x1B9B92C Offset: 0x1B9B92C VA: 0x1B9B92C
		public void HJHBGHMNGKL_SetDifficulty(int IKPIDCFOFEA, int GOKJLBDJOLA)
		{
			if (GOKJLBDJOLA <= 4 && IKPIDCFOFEA <= 9)
			{
				EHLGHDIACCG_Difficulty[IKPIDCFOFEA] = GOKJLBDJOLA ^ FBGGEFFJJHB;
			}
		}

		// // RVA: 0x1B99314 Offset: 0x1B99314 VA: 0x1B99314
		public int FFACBDAJJJP_GetDifficulty(int IKPIDCFOFEA)
		{
			int val = 0;
			if (IKPIDCFOFEA < 10)
			{
				val = EHLGHDIACCG_Difficulty[IKPIDCFOFEA];
				if (val < 0 || val > 4)
					val = 0;
			}
			return val;
		}

		// // RVA: 0x1B9BA0C Offset: 0x1B9BA0C VA: 0x1B9BA0C
		public void ECKFCIHPHGJ_SetScore(int IKPIDCFOFEA, int AFKHNFBOMKI)
		{
			if (AFKHNFBOMKI >= 0 && IKPIDCFOFEA <= 9)
			{
				PCFFCAAIPNB_Score[IKPIDCFOFEA] = AFKHNFBOMKI ^ FBGGEFFJJHB;
			}
		}

		// // RVA: 0x1B99404 Offset: 0x1B99404 VA: 0x1B99404
		public int BDCAICINCKK_GetScore(int IKPIDCFOFEA)
		{
			if (IKPIDCFOFEA > 9)
				return 0;
			if (PCFFCAAIPNB_Score[IKPIDCFOFEA] > 0)
				return PCFFCAAIPNB_Score[IKPIDCFOFEA];
			return 0;
		}

		// // RVA: 0x1B9BAF0 Offset: 0x1B9BAF0 VA: 0x1B9BAF0
		public void HPDBEKAGKOD_SetL6(int IKPIDCFOFEA, int MIKICCLPDJA)
		{
			if (MIKICCLPDJA >= 0 && IKPIDCFOFEA <= 9)
			{
				JALJMLNOLII_L6[IKPIDCFOFEA] = MIKICCLPDJA ^ FBGGEFFJJHB;
			}
		}

		// // RVA: 0x1B994E8 Offset: 0x1B994E8 VA: 0x1B994E8
		public int MJKFDJIPMMB_GetL6(int IKPIDCFOFEA)
		{
			if (IKPIDCFOFEA > 9)
				return 0;
			if (JALJMLNOLII_L6[IKPIDCFOFEA] > 0)
				return JALJMLNOLII_L6[IKPIDCFOFEA];
			return 0;
		}

		// // RVA: 0x1B98B4C Offset: 0x1B98B4C VA: 0x1B98B4C
		public void KMBPACJNEOF_Reset()
		{
			for(int i = 0; i < 10; i++)
			{
				EHOIENNDEDH_FreeMusicIds[i] = FBGGEFFJJHB;
				EHLGHDIACCG_Difficulty[i] = FBGGEFFJJHB;
				PCFFCAAIPNB_Score[i] = FBGGEFFJJHB;
				JALJMLNOLII_L6[i] = FBGGEFFJJHB;
			}
		}

		// // RVA: 0x1B9DE88 Offset: 0x1B9DE88 VA: 0x1B9DE88
		public void ODDIHGPONFL(LBGEDDJKOKF GPBJHKLFCEP)
		{
			for(int i = 0; i < 10; i++)
			{
				GMLHMKAMOEN_SetFreeMusicId(i, GPBJHKLFCEP.MLKHJPBAFCO_GetFreeMusicId(i));
				HJHBGHMNGKL_SetDifficulty(i, GPBJHKLFCEP.FFACBDAJJJP_GetDifficulty(i));
				ECKFCIHPHGJ_SetScore(i, GPBJHKLFCEP.BDCAICINCKK_GetScore(i));
				HPDBEKAGKOD_SetL6(i, GPBJHKLFCEP.MJKFDJIPMMB_GetL6(i));
			}
		}

		// // RVA: 0x1B9EBAC Offset: 0x1B9EBAC VA: 0x1B9EBAC
		// public bool AGBOGBEOFME(JNMFKOHFAFB.LBGEDDJKOKF GPBJHKLFCEP) { }

		// // RVA: 0x1B9B6EC Offset: 0x1B9B6EC VA: 0x1B9B6EC
		public bool GEJEDJNKBOF_IsValid(int IKPIDCFOFEA)
		{
			return IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.IBPAFKKEKNK_Music.BHJKMPBACAC_IsFreeMusicAvaiable(MLKHJPBAFCO_GetFreeMusicId(IKPIDCFOFEA)) && FFACBDAJJJP_GetDifficulty(IKPIDCFOFEA) < 5 && BDCAICINCKK_GetScore(IKPIDCFOFEA) < 1000000 && BDCAICINCKK_GetScore(IKPIDCFOFEA) >= 0 && MJKFDJIPMMB_GetL6(IKPIDCFOFEA) < 2;
		}
	}

	// public const int ECFEMKGFDCE = 2;
	private int FBGGEFFJJHB; // 0x24
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
	private int OBJIGFALAGG_MaxDgCrypted; // 0x80
	private int KGNOMMHMJEB_MaxL6Crypted; // 0x84
	private int[] DEMGKPDLMJO_DfClr = new int[5]; // 0x88
	private int[] EJAHPKHLMHA_DfFcb = new int[5]; // 0x8C
	private int[] AOJJNNFNDHM_DfClr16 = new int[5]; // 0x90
	private int[] CNOEKAHJJLE_DfFcb16 = new int[5]; // 0x94
	private int MLAHLKGEEBB_McPowerCrypted; // 0x98
	private int EFJBEJGNPEA_PshCrypted; // 0x9C
	private string IJCPFDPNDHE_DcNm; // 0xA0
	private int KNLODMNFFII_UtaRankCrypted; // 0xA4

	public int DIPKCALNIII_DivaId { get { return AOFGNAJLLPD_DivaIdCrypted ^ FBGGEFFJJHB; } set { AOFGNAJLLPD_DivaIdCrypted = value ^ FBGGEFFJJHB; } } //EOGPBFIDAPF 0x1B97BD8  JDNCGPBAFMB 0x1B97BE8
	public int ANAJIAENLNB_Level { get { return MBCPMFPKNBA_LevelCrypted ^ FBGGEFFJJHB; } set { MBCPMFPKNBA_LevelCrypted = value ^ FBGGEFFJJHB; } } //MMOMNMBKHJF 0x1B97BF8 FEHNFGPFINK 0x1B97C08
	public KNHIPBADANI AFBMEMCHJCL_MScene { get; private set; } // 0xA8 KNFCIOAPINN GJBNHLMONNG NNFIJKIAFEN
	public ONCMONJIPCD MGMFOJPNDGA_AssistData { get; private set; } // 0xAC IOIMBAECIKN HFCCFNMJALI OMADOLIKBOL
	public List<KNHIPBADANI> HDJOHAJPGBA_SScene { get; private set; } // 0xB0 APOCOCHGFGM NKKJDGBFHOH ENDCIPBGGPI
	public int BEEAIAAJOHD_CostumeId { get { return BJHHOBEMBJG_CostumeIdCrypted ^ FBGGEFFJJHB; } set { BJHHOBEMBJG_CostumeIdCrypted = value ^ FBGGEFFJJHB; } } //DIIBIOEMHAI 0x1B97C48   JIHEDMEFKAF 0x1B97C58
	public int AFNIOJHODAG_CostumeColorId { get { return LEHJBFPLJPL_CostumeColorIdCrypted ^ FBGGEFFJJHB; } set { LEHJBFPLJPL_CostumeColorIdCrypted = value ^ FBGGEFFJJHB; } } //OCABHAPHAMH 0x1B97C68 DIAIECJEGDG 0x1B97C78
	public int KIECDDFNCAN_PLevel { get { return HMJBBNEACOA_PLevelCrypted ^ FBGGEFFJJHB; } set { HMJBBNEACOA_PLevelCrypted = value ^ FBGGEFFJJHB; } } //LNOBPNDNEAK 0x1B97C88  BNGHHNPKLNB 0x1B97C98
	public int ABLOIBMGLFD_EmId { get { return HEJIMPBBFEP_EmIdCrypted ^ FBGGEFFJJHB; } set { HEJIMPBBFEP_EmIdCrypted = value ^ FBGGEFFJJHB; } } //PEFEEOLHFGE 0x1B97CA8 LBMNIKJOIIF 0x1B97CB8
	public int FHCAFLCLGAA_EmCnt { get { return GJOCKDBHEIM_EmCntCrypted ^ FBGGEFFJJHB; } set { GJOCKDBHEIM_EmCntCrypted = value ^ FBGGEFFJJHB; } } //EMLMAIJNCKP 0x1B97CC8 OKLACIGBMAM 0x1B97CD8
	public int FODKKJIDDKN_VfId { get { return BBOLHCKJFCA_VfIdCrypted ^ FBGGEFFJJHB; } set { BBOLHCKJFCA_VfIdCrypted = value ^ FBGGEFFJJHB; } } //LCHMMCPCFDD 0x1B97CE8 DHMLIEPNLCG 0x1B97CF8
	public int BKIFLJAMJGG_ScnCnt { get { return GMDHEAHLJGM_ScnCntCrypted ^ FBGGEFFJJHB; } set { GMDHEAHLJGM_ScnCntCrypted = value ^ FBGGEFFJJHB; } } //AEDPPCEHDGJ 0x1B97D08 JEMHMMBDMPH 0x1B97D18
	public int FOFGELKGMAH_CosCnt { get { return NPNCNBIBPGN_CosCntCrypted ^ FBGGEFFJJHB; } set { NPNCNBIBPGN_CosCntCrypted = value ^ FBGGEFFJJHB; } } //NHLLEINLGLG 0x1B97D28 EEKAJAEKFGM 0x1B97D38
	public int MIFLBHBPBNF_VfCnt { get { return NGMIJHODDDK_VfCntCrypted ^ FBGGEFFJJHB; } set { NGMIJHODDDK_VfCntCrypted = value ^ FBGGEFFJJHB; } } //BLDNGDDPPME 0x1B97D48  MKONLHNIHKL 0x1B97D58
	public int APFOBLMCLAO_QCnt { get { return PLIJDLMMMDI_QCntCrypted ^ FBGGEFFJJHB; } set { PLIJDLMMMDI_QCntCrypted = value ^ FBGGEFFJJHB; } } //LMCDIHAGOHH 0x1B97D68 JBKMEAEAFOL 0x1B97D78
	public int JGDNCEANEBB_LvMaxCnt { get { return KNKEKPPDDCL_LvMaxCntCrypted ^ FBGGEFFJJHB; } set { KNKEKPPDDCL_LvMaxCntCrypted = value ^ FBGGEFFJJHB; } } //GBFDJKKKEIM 0x1B97D88 IOOJAGNAKKN 0x1B97D98
	public long LDKEOMCNLBE_PfTap { get { return GBFJLFBBDLL_PfTapCrypted ^ FBGGEFFJJHB; } set { GBFJLFBBDLL_PfTapCrypted = value ^ FBGGEFFJJHB; } } //MNNJCAENCHJ 0x1B97DA8 JMPKDHKCMON 0x1B97DC0
	public long PCBJHBCNNGD_TClr { get { return DOOLJJCBNON_TClrCrypted ^ FBGGEFFJJHB; } set { DOOLJJCBNON_TClrCrypted = value ^ FBGGEFFJJHB; } } //BHLKKHJGGE 0x1B97DD4 FJFFPLKGNDF 0x1B97DEC
	public int AEBENOJEGOJ_MaxSc { get { return FBGGEFFJJHB ^ BFKKFMILHMO_MaxScCrypted; } set { BFKKFMILHMO_MaxScCrypted = FBGGEFFJJHB ^ value; } } //DEBHLAOOOBN 0x1B97E00 AKKKJMMFOKH 0x1B97E10
	public int JHOIMONJKLG_MaxId { get { return FCFIANFLKCF_MaxIdCrypted ^ FBGGEFFJJHB; } set { FCFIANFLKCF_MaxIdCrypted = value ^ FBGGEFFJJHB; } } //DJPLEMJPOIH 0x1B97E20 JINGNHOHDKD 0x1B97E30
	public int JEENEHPOCFN_MaxDf { get { return OBJIGFALAGG_MaxDgCrypted ^ FBGGEFFJJHB; } set { OBJIGFALAGG_MaxDgCrypted = value ^ FBGGEFFJJHB; } } //ODBOEKIHJDB 0x1B97E40 KOJIBFLIAAK 0x1B97E50
	public int NADEAGFJDLL_MaxL6 { get { return KGNOMMHMJEB_MaxL6Crypted ^ FBGGEFFJJHB; } set { KGNOMMHMJEB_MaxL6Crypted = value ^ FBGGEFFJJHB; } } //EICGJGODOPK 0x1B97E60 INFBHCPEBIG 0x1B97E70
	public long DALCINDEJLC_DcTm { get { return GKCNAJDCODL_DcTmCrypted ^ FBGGEFFJJHB; } set { GKCNAJDCODL_DcTmCrypted = value ^ FBGGEFFJJHB; } } //APCILEIAHAJ 0x1B97E80 GEJPIMFNKLJ 0x1B97E98
	public string NAKJJBEIION_DcNm { get { return IJCPFDPNDHE_DcNm; } set { IJCPFDPNDHE_DcNm = value; } } //NEFKGAAMLEG 0x1B97EAC ACAJCPPKAKN 0x1B97EB4
	public int OENMBJEKJII_McPower { get { return MLAHLKGEEBB_McPowerCrypted ^ FBGGEFFJJHB; } set { MLAHLKGEEBB_McPowerCrypted = value ^ FBGGEFFJJHB; } }  //FKJNEPMOEIM 0x1B9815C DBJEDFGBDFB 0x1B9816C
	public List<JNMFKOHFAFB_PublicStatus.LBGEDDJKOKF> AEIADFODLMC_HsRating { get; private set; } // 0xB4 FJDIIFNMHGO JJIKNMLEHMO IGJDNMJPJPN
	public int IPJPAAFNAOF_Psh { get { return EFJBEJGNPEA_PshCrypted ^ FBGGEFFJJHB; } set { EFJBEJGNPEA_PshCrypted = value ^ FBGGEFFJJHB; } }// JICJJOECOCM 0x1B9818C EFHHBDALMFN 0x1B9819C
	public int AILEOFKIELL_UtaRateRank { get { return KNLODMNFFII_UtaRankCrypted ^ FBGGEFFJJHB; } set { KNLODMNFFII_UtaRankCrypted = value ^ FBGGEFFJJHB; } } //JJDFJGJPJNP 0x1B981AC ACFHJBLJPEK 0x1B981BC
	// public override bool DMICHEJIAJL { get; }

	// // RVA: 0x1B97EBC Offset: 0x1B97EBC VA: 0x1B97EBC
	public int PFHIOGBJDHM(int AKNELONELJK)
	{
		return DEMGKPDLMJO_DfClr[AKNELONELJK] ^ FBGGEFFJJHB;
	}

	// // RVA: 0x1B97F10 Offset: 0x1B97F10 VA: 0x1B97F10
	public int KIBCDACEFIC(int AKNELONELJK)
	{
		return EJAHPKHLMHA_DfFcb[AKNELONELJK] ^ FBGGEFFJJHB;
	}

	// // RVA: 0x1B97F64 Offset: 0x1B97F64 VA: 0x1B97F64
	public void BAHLFHCOEHO(int AKNELONELJK, int BFINGCJHOHI)
	{
		DEMGKPDLMJO_DfClr[AKNELONELJK] = FBGGEFFJJHB ^ BFINGCJHOHI;
	}

	// // RVA: 0x1B97FB8 Offset: 0x1B97FB8 VA: 0x1B97FB8
	public void CECEAOLLLNG(int AKNELONELJK, int BFINGCJHOHI)
	{
		EJAHPKHLMHA_DfFcb[AKNELONELJK] = FBGGEFFJJHB ^ BFINGCJHOHI;
	}

	// // RVA: 0x1B9800C Offset: 0x1B9800C VA: 0x1B9800C
	public int EJNGDOJAIDP(int AKNELONELJK)
	{
		return AOJJNNFNDHM_DfClr16[AKNELONELJK] ^ FBGGEFFJJHB;
	}

	// // RVA: 0x1B98060 Offset: 0x1B98060 VA: 0x1B98060
	public int JFBMBPPHDLB(int AKNELONELJK)
	{
		return CNOEKAHJJLE_DfFcb16[AKNELONELJK] ^ FBGGEFFJJHB;
	}

	// // RVA: 0x1B980B4 Offset: 0x1B980B4 VA: 0x1B980B4
	public void PCBEBNAHCDH(int AKNELONELJK, int BFINGCJHOHI)
	{
		AOJJNNFNDHM_DfClr16[AKNELONELJK] = FBGGEFFJJHB ^ BFINGCJHOHI;
	}

	// // RVA: 0x1B98108 Offset: 0x1B98108 VA: 0x1B98108
	public void KLAALDBEAJM(int AKNELONELJK, int BFINGCJHOHI)
	{
		CNOEKAHJJLE_DfFcb16[AKNELONELJK] = FBGGEFFJJHB ^ BFINGCJHOHI;
	}

	// // RVA: 0x1B981CC Offset: 0x1B981CC VA: 0x1B981CC
	// public bool LJLLNLKBEJE(int ICDJHNPILBC) { }

	// // RVA: 0x1B982E0 Offset: 0x1B982E0 VA: 0x1B982E0
	public JNMFKOHFAFB_PublicStatus()
	{
		AFBMEMCHJCL_MScene = new JNMFKOHFAFB_PublicStatus.KNHIPBADANI();
		HDJOHAJPGBA_SScene = new List<JNMFKOHFAFB_PublicStatus.KNHIPBADANI>();
		AEIADFODLMC_HsRating = new List<JNMFKOHFAFB_PublicStatus.LBGEDDJKOKF>();
		MGMFOJPNDGA_AssistData = new JNMFKOHFAFB_PublicStatus.ONCMONJIPCD();
		KMBPACJNEOF();
	}

	// // RVA: 0x1B98538 Offset: 0x1B98538 VA: 0x1B98538 Slot: 4
	public override void KMBPACJNEOF()
	{
		long time = Utility.GetCurrentUnixTime();
		FBGGEFFJJHB = (int)(time ^ 0x2b50b);
		AEBENOJEGOJ_MaxSc = 0;
		JHOIMONJKLG_MaxId = 0;
		JEENEHPOCFN_MaxDf = 0;
		NADEAGFJDLL_MaxL6 = 0;
		APFOBLMCLAO_QCnt = 0;
		JGDNCEANEBB_LvMaxCnt = 0;
		DALCINDEJLC_DcTm = 0;
		DIPKCALNIII_DivaId = 1;
		ANAJIAENLNB_Level = 0;
		BEEAIAAJOHD_CostumeId = 0;
		AFNIOJHODAG_CostumeColorId = 0;
		KIECDDFNCAN_PLevel = 1;
		ABLOIBMGLFD_EmId = 1;
		FHCAFLCLGAA_EmCnt = 0;
		BBOLHCKJFCA_VfIdCrypted = 0;
		GMDHEAHLJGM_ScnCntCrypted = 0;
		NPNCNBIBPGN_CosCntCrypted = 0;
		NGMIJHODDDK_VfCntCrypted = 0;
		GBFJLFBBDLL_PfTapCrypted = 0;
		DOOLJJCBNON_TClrCrypted = 0;
		IJCPFDPNDHE_DcNm = "";

		for (int i = 0; i < 5; i++)
		{
			BAHLFHCOEHO(i, 0);
			CECEAOLLLNG(i, 0);
			PCBEBNAHCDH(i, 0);
			KLAALDBEAJM(i, 0);
		}
		OENMBJEKJII_McPower = 0;
		AFBMEMCHJCL_MScene.KMBPACJNEOF();
		MGMFOJPNDGA_AssistData.KMBPACJNEOF(0);
		HDJOHAJPGBA_SScene.Clear();
		AEIADFODLMC_HsRating.Clear();
		for(int i = 0; i < 2; i++)
		{
			JNMFKOHFAFB_PublicStatus.KNHIPBADANI data = new JNMFKOHFAFB_PublicStatus.KNHIPBADANI();
			data.KMBPACJNEOF();
			HDJOHAJPGBA_SScene.Add(data);
		}
		JNMFKOHFAFB_PublicStatus.LBGEDDJKOKF data2 = new JNMFKOHFAFB_PublicStatus.LBGEDDJKOKF();
		data2.KMBPACJNEOF_Reset();
		AEIADFODLMC_HsRating.Add(data2);
		IPJPAAFNAOF_Psh = 0;
		AILEOFKIELL_UtaRateRank = 0;
	}

	// // RVA: 0x1B98D3C Offset: 0x1B98D3C VA: 0x1B98D3C
	// private EDOHBJAPLPF_JsonData BJIJBKEABPO(JNMFKOHFAFB.LBGEDDJKOKF IDJJCEGLONI) { }

	// // RVA: 0x1B995CC Offset: 0x1B995CC VA: 0x1B995CC Slot: 5
	// public override void OKJPIBHMKMJ(EDOHBJAPLPF_JsonData OILEIIEIBHP, long MCKEOKFMLAH) { }

	// // RVA: 0x1B9A6FC Offset: 0x1B9A6FC VA: 0x1B9A6FC
	private void LFNFJHGDKAA(ONCMONJIPCD IDLHJIOMJBK, EDOHBJAPLPF_JsonData OBHAFLMHAKG, ref bool NGJDHLGMHMH)
	{
		for(int i = 0; i < 4; i++)
		{
			EDOHBJAPLPF_JsonData data = OBHAFLMHAKG[AFEHLCGHAEE_Strings.GGLICPAANFE_assist_data_list][i];
			EHEMJOHCJOG(IDLHJIOMJBK.JOHLGBDOLNO_DataList[i], data, ref NGJDHLGMHMH);
		}
		IDLHJIOMJBK.JCJNKBKMJFK_Name = FGCNMLBACGO_ReadString(OBHAFLMHAKG, AFEHLCGHAEE_Strings.COEBIDJMMCH_assist_name, "", ref NGJDHLGMHMH);
	}

	// // RVA: 0x1B9A8CC Offset: 0x1B9A8CC VA: 0x1B9A8CC
	private void EHEMJOHCJOG(KNHIPBADANI KDIFMECGNIC, EDOHBJAPLPF_JsonData OBHAFLMHAKG, ref bool NGJDHLGMHMH)
	{
		KDIFMECGNIC.KMBPACJNEOF();
		KDIFMECGNIC.PPFNGGCBJKC_Id = CJAENOMGPDA_ReadInt(OBHAFLMHAKG, AFEHLCGHAEE_Strings.PPFNGGCBJKC_Id, 0, ref NGJDHLGMHMH);
		bool hasDb = false;
		if(IMMAOANGPNK.HHCJCDFCLOB.LNAHEIEIBOI_Initialized)
		{
			if(IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database != null)
			{
				hasDb = true;
				if (!IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.ECNHDEHADGL_Scene.FGNJBMPDBLO_IsSceneValid(KDIFMECGNIC.PPFNGGCBJKC_Id))
					KDIFMECGNIC.PPFNGGCBJKC_Id = 0;
			}
		}
		KDIFMECGNIC.ANAJIAENLNB_Level = CJAENOMGPDA_ReadInt(OBHAFLMHAKG, AFEHLCGHAEE_Strings.ANAJIAENLNB_lv, 0, ref NGJDHLGMHMH);
		KDIFMECGNIC.MJBODMOLOBC_Luck = CJAENOMGPDA_ReadInt(OBHAFLMHAKG, AFEHLCGHAEE_Strings.MJBODMOLOBC_luck, 0, ref NGJDHLGMHMH);
		KDIFMECGNIC.JPIPENJGGDD_Mlt = CJAENOMGPDA_ReadInt(OBHAFLMHAKG, AFEHLCGHAEE_Strings.ALMNMBDELDB_mlt, 0, ref NGJDHLGMHMH);
		KDIFMECGNIC.DMNIMMGGJJJ_Leaf = CJAENOMGPDA_ReadInt(OBHAFLMHAKG, "leaf", 0, ref NGJDHLGMHMH);
		if(hasDb && IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.HDGOHBFKKDM_LimitOver.AJHBAOCLNDF_Enabled != 2)
		{
			KDIFMECGNIC.DMNIMMGGJJJ_Leaf = 0;
		}
		CEDHHAGBIBA.IFOLECIIDPO_StringToByteArray(KDIFMECGNIC.PDNIFBEGMHC_Mb, FGCNMLBACGO_ReadString(OBHAFLMHAKG, AFEHLCGHAEE_Strings.DANMJLOBLIE_mb, "", ref NGJDHLGMHMH));
		CEDHHAGBIBA.IFOLECIIDPO_StringToByteArray(KDIFMECGNIC.EMOJHJGHJLN_Sb, FGCNMLBACGO_ReadString(OBHAFLMHAKG, AFEHLCGHAEE_Strings.KOHNLDKIKPC_sb, "", ref NGJDHLGMHMH));
		KDIFMECGNIC.ANAJIAENLNB_Level = CEDHHAGBIBA.OGPFNHOKONH(KDIFMECGNIC.PDNIFBEGMHC_Mb) + 1;
		if(KDIFMECGNIC.MJBODMOLOBC_Luck < 0)
			KDIFMECGNIC.MJBODMOLOBC_Luck = 0;
		if (KDIFMECGNIC.MJBODMOLOBC_Luck > 25)
			KDIFMECGNIC.MJBODMOLOBC_Luck = 25;

	}

	// // RVA: 0x1B9B29C Offset: 0x1B9B29C VA: 0x1B9B29C
	private void PLLNFEBKLBH(LBGEDDJKOKF IDJJCEGLONI, EDOHBJAPLPF_JsonData OBHAFLMHAKG, ref bool NGJDHLGMHMH)
	{
		IDJJCEGLONI.KMBPACJNEOF_Reset();
		IBCGPBOGOGP_ReadIntArray(OBHAFLMHAKG, AFEHLCGHAEE_Strings.PPFNGGCBJKC_Id, 0, 10, (int OIPCCBHIKIA, int JBGEEPFKIGG) =>
		{
			//0x1BA155C
			IDJJCEGLONI.GMLHMKAMOEN_SetFreeMusicId(OIPCCBHIKIA, JBGEEPFKIGG);
		}, ref NGJDHLGMHMH);
		IBCGPBOGOGP_ReadIntArray(OBHAFLMHAKG, AFEHLCGHAEE_Strings.GOKJLBDJOLA_df, 0, 10, (int OIPCCBHIKIA, int JBGEEPFKIGG) =>
		{
			//0x1BA1594
			IDJJCEGLONI.HJHBGHMNGKL_SetDifficulty(OIPCCBHIKIA, JBGEEPFKIGG);
		}, ref NGJDHLGMHMH);
		IBCGPBOGOGP_ReadIntArray(OBHAFLMHAKG, AFEHLCGHAEE_Strings.AFKHNFBOMKI_sc, 0, 10, (int OIPCCBHIKIA, int JBGEEPFKIGG) =>
		{
			//0x1BA15CC
			IDJJCEGLONI.ECKFCIHPHGJ_SetScore(OIPCCBHIKIA, JBGEEPFKIGG);
		}, ref NGJDHLGMHMH);
		IBCGPBOGOGP_ReadIntArray(OBHAFLMHAKG, "l6", 0, 10, (int OIPCCBHIKIA, int JBGEEPFKIGG) =>
		{
			//0x1BA1604
			IDJJCEGLONI.HPDBEKAGKOD_SetL6(OIPCCBHIKIA, JBGEEPFKIGG);
		}, ref NGJDHLGMHMH);
		for(int i = 0; i <10; i++)
		{
			if(!IDJJCEGLONI.GEJEDJNKBOF_IsValid(i))
			{
				IDJJCEGLONI.GMLHMKAMOEN_SetFreeMusicId(i, 0);
				IDJJCEGLONI.HJHBGHMNGKL_SetDifficulty(i, 0);
				IDJJCEGLONI.ECKFCIHPHGJ_SetScore(i, 0);
				IDJJCEGLONI.HPDBEKAGKOD_SetL6(i, 0);
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
		if(IMMAOANGPNK.HHCJCDFCLOB.LNAHEIEIBOI_Initialized)
		{
			db = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database;
		}
		DIPKCALNIII_DivaId = CJAENOMGPDA_ReadInt(data, AFEHLCGHAEE_Strings.DIPKCALNIII_diva_id, 1, ref isInvalid);
		BEEAIAAJOHD_CostumeId = CJAENOMGPDA_ReadInt(data, AFEHLCGHAEE_Strings.ODNOJKHHEOP_c_id, 0, ref isInvalid);
		AFNIOJHODAG_CostumeColorId = CJAENOMGPDA_ReadInt(data, "c_col", 0, ref isInvalid);
		if(db != null)
		{
			if (!db.MGFMPKLLGHE_Diva.BEEGJHCDHJB_IsDivaAvaiable(DIPKCALNIII_DivaId))
				DIPKCALNIII_DivaId = 1;
			if (!db.MFPNGNMFEAL_Costume.OEMKAFGPOCE_IsCostumeAvaiable(BEEAIAAJOHD_CostumeId, DIPKCALNIII_DivaId))
				BEEAIAAJOHD_CostumeId = 0;
			if (!db.MFPNGNMFEAL_Costume.KPHOIIKOEOG_IsColorAvaiable(AFNIOJHODAG_CostumeColorId, BEEAIAAJOHD_CostumeId, DIPKCALNIII_DivaId))
				AFNIOJHODAG_CostumeColorId = 0;
		}
		ANAJIAENLNB_Level = CJAENOMGPDA_ReadInt(data, AFEHLCGHAEE_Strings.ANAJIAENLNB_lv, 1, ref isInvalid);
		if(db != null)
		{
			if(!db.MFPNGNMFEAL_Costume.OEMKAFGPOCE_IsCostumeAvaiable(BEEAIAAJOHD_CostumeId, DIPKCALNIII_DivaId))
			{
				BEEAIAAJOHD_CostumeId = 0;
				AFNIOJHODAG_CostumeColorId = 0;
			}
		}
		KIECDDFNCAN_PLevel = CJAENOMGPDA_ReadInt(data, AFEHLCGHAEE_Strings.PIJNJBJMFHL_plv, 1, ref isInvalid);
		ABLOIBMGLFD_EmId = CJAENOMGPDA_ReadInt(data, AFEHLCGHAEE_Strings.ABLOIBMGLFD_em_id, 1, ref isInvalid);
		if (ABLOIBMGLFD_EmId == 0)
			ABLOIBMGLFD_EmId = 1;
		FHCAFLCLGAA_EmCnt = CJAENOMGPDA_ReadInt(data, AFEHLCGHAEE_Strings.FHCAFLCLGAA_em_cnt, 0, ref isInvalid);
		if(db != null)
		{
			if(!db.LBNBNAFGMDE_Emblem.MNFCLPNLFIJ_IsEmblemAvaiable(ABLOIBMGLFD_EmId))
			{
				ABLOIBMGLFD_EmId = 1;
				FHCAFLCLGAA_EmCnt = 0;
			}
		}
		BKIFLJAMJGG_ScnCnt = CJAENOMGPDA_ReadInt(data, AFEHLCGHAEE_Strings.BKIFLJAMJGG_scn_cnt, 1, ref isInvalid);
		FODKKJIDDKN_VfId = CJAENOMGPDA_ReadInt(data, AFEHLCGHAEE_Strings.FODKKJIDDKN_vf_id, 1, ref isInvalid);
		if(db != null)
		{
			if (!db.PEOALFEGNDH_Valkyrie.PILGJJCABME_IsValkyrieAvaiable(FODKKJIDDKN_VfId))
				FODKKJIDDKN_VfId = 1;
		}
		BKIFLJAMJGG_ScnCnt = CJAENOMGPDA_ReadInt(data, AFEHLCGHAEE_Strings.BKIFLJAMJGG_scn_cnt, 1, ref isInvalid);
		FOFGELKGMAH_CosCnt = CJAENOMGPDA_ReadInt(data, AFEHLCGHAEE_Strings.FOFGELKGMAH_cos_cnt, 1, ref isInvalid);
		MIFLBHBPBNF_VfCnt = CJAENOMGPDA_ReadInt(data, AFEHLCGHAEE_Strings.MIFLBHBPBNF_vf_cnt, 1, ref isInvalid);
		APFOBLMCLAO_QCnt = CJAENOMGPDA_ReadInt(data, AFEHLCGHAEE_Strings.APFOBLMCLAO_q_cnt, 0, ref isInvalid);
		JGDNCEANEBB_LvMaxCnt = CJAENOMGPDA_ReadInt(data, AFEHLCGHAEE_Strings.JGDNCEANEBB_lv_max_cnt, 0, ref isInvalid);
		LDKEOMCNLBE_PfTap = CJAENOMGPDA_ReadInt(data, AFEHLCGHAEE_Strings.LDKEOMCNLBE_pf_tap, 0, ref isInvalid);
		PCBJHBCNNGD_TClr = CJAENOMGPDA_ReadInt(data, AFEHLCGHAEE_Strings.PCBJHBCNNGD_t_clr, 0, ref isInvalid);
		AEBENOJEGOJ_MaxSc = CJAENOMGPDA_ReadInt(data, AFEHLCGHAEE_Strings.AEBENOJEGOJ_max_sc, 0, ref isInvalid);
		JHOIMONJKLG_MaxId = CJAENOMGPDA_ReadInt(data, AFEHLCGHAEE_Strings.JHOIMONJKLG_max_id, 0, ref isInvalid);
		JEENEHPOCFN_MaxDf = CJAENOMGPDA_ReadInt(data, AFEHLCGHAEE_Strings.JEENEHPOCFN_max_df, 0, ref isInvalid);
		NADEAGFJDLL_MaxL6 = CJAENOMGPDA_ReadInt(data, "max_l6", 0, ref isInvalid);
		IBCGPBOGOGP_ReadIntArray(data, AFEHLCGHAEE_Strings.MIODKKINJBD_df_clr, 0, 5, (int OIPCCBHIKIA, int JBGEEPFKIGG) =>
		{
			//0x1BA154C
			BAHLFHCOEHO(OIPCCBHIKIA, JBGEEPFKIGG);
		}, ref isInvalid);
		IBCGPBOGOGP_ReadIntArray(data, AFEHLCGHAEE_Strings.AGONOGEEGDL_df_fcb, 0, 5, (int OIPCCBHIKIA, int JBGEEPFKIGG) =>
		{
			//0x1BA1550
			CECEAOLLLNG(OIPCCBHIKIA, JBGEEPFKIGG);
		}, ref isInvalid);
		IBCGPBOGOGP_ReadIntArray(data, "df_clr_l6", 0, 5, (int OIPCCBHIKIA, int JBGEEPFKIGG) =>
		{
			//0x1BA1554
			PCBEBNAHCDH(OIPCCBHIKIA, JBGEEPFKIGG);
		}, ref isInvalid);
		IBCGPBOGOGP_ReadIntArray(data, "df_fcb_l6", 0, 5, (int OIPCCBHIKIA, int JBGEEPFKIGG) =>
		{
			//0x1BA1558
			KLAALDBEAJM(OIPCCBHIKIA, JBGEEPFKIGG);
		}, ref isInvalid);
		OENMBJEKJII_McPower = CJAENOMGPDA_ReadInt(data, "mc_power", 0, ref isInvalid);
		IPJPAAFNAOF_Psh = CJAENOMGPDA_ReadInt(data, "psh", 0, ref isInvalid);
		AILEOFKIELL_UtaRateRank = CJAENOMGPDA_ReadInt(data, "utarate_rank", 0, ref isInvalid);
		if (KIECDDFNCAN_PLevel < 1)
			KIECDDFNCAN_PLevel = 1;
		if(data.BBAJPINMOEP_Contains(AFEHLCGHAEE_Strings.HHOCBLMEGGM_m_scene) && data[AFEHLCGHAEE_Strings.HHOCBLMEGGM_m_scene].LLHIGGPIILM_IsObject)
			EHEMJOHCJOG(AFBMEMCHJCL_MScene, data[AFEHLCGHAEE_Strings.HHOCBLMEGGM_m_scene], ref isInvalid);
		else
			KFKDMBPNLJK_BlockInvalid = true;
		if (data.BBAJPINMOEP_Contains(AFEHLCGHAEE_Strings.CBIKELHFHCA_assist_data) && data[AFEHLCGHAEE_Strings.CBIKELHFHCA_assist_data].LLHIGGPIILM_IsObject)
			LFNFJHGDKAA(MGMFOJPNDGA_AssistData, data[AFEHLCGHAEE_Strings.CBIKELHFHCA_assist_data], ref isInvalid);
		else
			KFKDMBPNLJK_BlockInvalid = true;
		if(data.BBAJPINMOEP_Contains(AFEHLCGHAEE_Strings.EPMALNDIDJM_s_scene) && data[AFEHLCGHAEE_Strings.EPMALNDIDJM_s_scene].EPNGJLOKGIF_IsArray)
		{
			int num = data[AFEHLCGHAEE_Strings.EPMALNDIDJM_s_scene].HNBFOAJIIAL_Count;
			if(HDJOHAJPGBA_SScene.Count < num)
			{
				num = HDJOHAJPGBA_SScene.Count;
			}
			for(int i = 0; i < num; i++)
			{
				EHEMJOHCJOG(HDJOHAJPGBA_SScene[i], data[AFEHLCGHAEE_Strings.EPMALNDIDJM_s_scene][i], ref isInvalid);
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
		NAKJJBEIION_DcNm = FGCNMLBACGO_ReadString(data, "dc_nm", "", ref isInvalid);
		DALCINDEJLC_DcTm = DKMPHAPBDLH_ReadLong(data, "dc_tm", 0, ref isInvalid);
		KFKDMBPNLJK_BlockInvalid = isInvalid;
		return true;
	}

	// // RVA: 0x1B9D350 Offset: 0x1B9D350 VA: 0x1B9D350 Slot: 7
	public override void BMGGKONLFIC(KLFDBFMNLBL_ServerSaveBlock GPBJHKLFCEP)
	{
		JNMFKOHFAFB_PublicStatus p = GPBJHKLFCEP as JNMFKOHFAFB_PublicStatus;
		DIPKCALNIII_DivaId = p.DIPKCALNIII_DivaId;
		ANAJIAENLNB_Level = p.ANAJIAENLNB_Level;
		BEEAIAAJOHD_CostumeId = p.BEEAIAAJOHD_CostumeId;
		AFNIOJHODAG_CostumeColorId = p.AFNIOJHODAG_CostumeColorId;
		KIECDDFNCAN_PLevel = p.KIECDDFNCAN_PLevel;
		ABLOIBMGLFD_EmId = p.ABLOIBMGLFD_EmId;
		FHCAFLCLGAA_EmCnt = p.FHCAFLCLGAA_EmCnt;
		BKIFLJAMJGG_ScnCnt = p.BKIFLJAMJGG_ScnCnt;
		FODKKJIDDKN_VfId = p.FODKKJIDDKN_VfId;
		FOFGELKGMAH_CosCnt = p.FOFGELKGMAH_CosCnt;
		MIFLBHBPBNF_VfCnt = p.MIFLBHBPBNF_VfCnt;
		APFOBLMCLAO_QCnt = p.APFOBLMCLAO_QCnt;
		JGDNCEANEBB_LvMaxCnt = p.JGDNCEANEBB_LvMaxCnt;
		LDKEOMCNLBE_PfTap = p.LDKEOMCNLBE_PfTap;
		PCBJHBCNNGD_TClr = p.PCBJHBCNNGD_TClr;
		AEBENOJEGOJ_MaxSc = p.AEBENOJEGOJ_MaxSc;
		JHOIMONJKLG_MaxId = p.JHOIMONJKLG_MaxId;
		JEENEHPOCFN_MaxDf = p.JEENEHPOCFN_MaxDf;
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
		AFBMEMCHJCL_MScene.ODDIHGPONFL(p.AFBMEMCHJCL_MScene);
		MGMFOJPNDGA_AssistData.ODDIHGPONFL(p.MGMFOJPNDGA_AssistData);
		for(int i = 0; i < p.HDJOHAJPGBA_SScene.Count; i++)
		{
			HDJOHAJPGBA_SScene[i].ODDIHGPONFL(p.HDJOHAJPGBA_SScene[i]);
		}
		for(int i = 0; i < p.AEIADFODLMC_HsRating.Count; i++)
		{
			AEIADFODLMC_HsRating[i].ODDIHGPONFL(p.AEIADFODLMC_HsRating[i]);
		}
		IJCPFDPNDHE_DcNm = string.Copy(p.IJCPFDPNDHE_DcNm);
		DALCINDEJLC_DcTm = p.DALCINDEJLC_DcTm;
	}

	// // RVA: 0x1B9DF8C Offset: 0x1B9DF8C VA: 0x1B9DF8C Slot: 8
	// public override bool AGBOGBEOFME(KLFDBFMNLBL GPBJHKLFCEP) { }

	// // RVA: 0x1B9ECAC Offset: 0x1B9ECAC VA: 0x1B9ECAC Slot: 10
	// public override void AGHKODFKOJI(BHBONAHFKHD JBBHNIACMFJ, KLFDBFMNLBL GJLFANGDGCL, long MCKEOKFMLAH) { }

	// // RVA: 0x1BA1544 Offset: 0x1BA1544 VA: 0x1BA1544 Slot: 9
	// public override bool NFKFOODCJJB() { }
}
