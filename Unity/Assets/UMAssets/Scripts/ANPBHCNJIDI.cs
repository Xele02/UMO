
using System.Collections.Generic;
using XeApp.Game.Common;
using XeSys;

public class ANPBHCNJIDI
{
	public enum NOJONDLAMOC
	{
		HJNNKCMLGFL_0 = 0,
		CCAPCGPIIPF_1_Chat = 1,
		DDPLFFAOAEB_2_Stamp = 2,
		CGEPNIOPFHF_3_DefeatBoss = 3,
		JDGLJOFPHLK_4_MaccrossCannon = 4,
		JPOGBMJKPIJ_5_FullCombo = 5,
	}

	public class NNPGLGHDBKN
	{
		public NOJONDLAMOC INDDJNMPONH_Type; // 0x8
		public string OPFGFINHFCE_PlayerName; // 0xC
		public int OIPCCBHIKIA_Idx; // 0x10
		public int MLPEHNBNOGD_WritterId; // 0x14
		public long EKEGHNPNCEH_UpdateAt; // 0x18
		public int AHHJLDLAPAN_DivaId; // 0x20
		public int NNOHKLNKGAD_CostumeId; // 0x24
		public int DJHMGDKKKFO_ColorId; // 0x28
		public int MDPKLNFFDBO_EmblemId; // 0x2C
		public int KDHCKDHIHIP_EmblemCount; // 0x30
		public int AILEOFKIELL_UtaRateRank; // 0x34
		public int KIFEGLJLEDC_TotalUtaRate; // 0x38

		public bool JOIOJMONLFL_IsWritterSelf { get { return MLPEHNBNOGD_WritterId == NKGJPJPHLIF.HHCJCDFCLOB.MDAMJIGBOLD_PlayerId; } } //0xD57020 OBJPIBFEIFM

		// RVA: 0xD553C8 Offset: 0xD553C8 VA: 0xD553C8
		public NNPGLGHDBKN()
		{
			KDHCKDHIHIP_EmblemCount = 0;
			AILEOFKIELL_UtaRateRank = 0;
			KIFEGLJLEDC_TotalUtaRate = 0;
			AHHJLDLAPAN_DivaId = 1;
			NNOHKLNKGAD_CostumeId = 1;
			DJHMGDKKKFO_ColorId = 0;
			MDPKLNFFDBO_EmblemId = 1;
		}

		//// RVA: 0xD554CC Offset: 0xD554CC VA: 0xD554CC Slot: 4
		internal virtual bool KLAOLMDCLHO(BNAAJMBJFPG LBJACBOOLEL, EDOHBJAPLPF_JsonData DLENPPIJNPA)
		{
			OPFGFINHFCE_PlayerName = LBJACBOOLEL.MNKCOFJKJJM_Nickname;
			MLPEHNBNOGD_WritterId = LBJACBOOLEL.PNDINAAEGBE_WriterId;
			EKEGHNPNCEH_UpdateAt = LBJACBOOLEL.IFNLEKOILPM_UpdatedAt;
			OIPCCBHIKIA_Idx = LBJACBOOLEL.NPAHGHOHMHN_Idx;
			AHHJLDLAPAN_DivaId = JsonUtil.GetInt(DLENPPIJNPA, "dv", 1);
			NNOHKLNKGAD_CostumeId = JsonUtil.GetInt(DLENPPIJNPA, "dvc", 1);
			DJHMGDKKKFO_ColorId = JsonUtil.GetInt(DLENPPIJNPA, "dvcc", 0);
			MDPKLNFFDBO_EmblemId = JsonUtil.GetInt(DLENPPIJNPA, "em", 1);
			KDHCKDHIHIP_EmblemCount = JsonUtil.GetInt(DLENPPIJNPA, "emc", 0);
			AILEOFKIELL_UtaRateRank = JsonUtil.GetInt(DLENPPIJNPA, "utarr", 0);
			KIFEGLJLEDC_TotalUtaRate = JsonUtil.GetInt(DLENPPIJNPA, "utar", 0);
			if(NNOHKLNKGAD_CostumeId == 0)
			{
				NNOHKLNKGAD_CostumeId = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.MFPNGNMFEAL_Costume.LBDOLHGDIEB_GetUnlockedCostumeOrDefault(AHHJLDLAPAN_DivaId, 0).JPIDIENBGKH_CostumeId;
			}
			if(IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.MGFMPKLLGHE_Diva.BEEGJHCDHJB_IsDivaAvaiable(AHHJLDLAPAN_DivaId))
			{
				if(IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.MFPNGNMFEAL_Costume.OEMKAFGPOCE_IsCostumeAvaiable(NNOHKLNKGAD_CostumeId, AHHJLDLAPAN_DivaId))
				{
					if(DJHMGDKKKFO_ColorId != 0)
					{
						if(!IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.MFPNGNMFEAL_Costume.KPHOIIKOEOG_IsColorAvaiable(DJHMGDKKKFO_ColorId, NNOHKLNKGAD_CostumeId, AHHJLDLAPAN_DivaId))
							return false;
					}
					if(MDPKLNFFDBO_EmblemId == 1)
						return true;
					else
					{
						if(IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.LBNBNAFGMDE_Emblem.MNFCLPNLFIJ_IsEmblemAvaiable(MDPKLNFFDBO_EmblemId))
							return true;
					}
				}
			}
			return false;
		}

		//// RVA: 0xD55A40 Offset: 0xD55A40 VA: 0xD55A40 Slot: 5
		internal virtual void EFOOHDOMCAI(SakashoBbsCommentInfo KOGBMDOONFA, EDOHBJAPLPF_JsonData DLENPPIJNPA)
		{
			KOGBMDOONFA.Nickname = OPFGFINHFCE_PlayerName;
			KOGBMDOONFA.Content = "dummy";
			DLENPPIJNPA["dv"] = AHHJLDLAPAN_DivaId;
			DLENPPIJNPA["dvc"] = NNOHKLNKGAD_CostumeId;
			DLENPPIJNPA["dvcc"] = DJHMGDKKKFO_ColorId;
			DLENPPIJNPA["em"] = MDPKLNFFDBO_EmblemId;
			DLENPPIJNPA["emc"] = KDHCKDHIHIP_EmblemCount;
			DLENPPIJNPA["utarr"] = AILEOFKIELL_UtaRateRank;
			DLENPPIJNPA["utar"] = KIFEGLJLEDC_TotalUtaRate;
		}

		//// RVA: 0xD570D4 Offset: 0xD570D4 VA: 0xD570D4
		public void PCEHLFNFIDA(BBHNACPENDM_ServerSaveData AHEFHIMGIBI)
		{
			AHHJLDLAPAN_DivaId = AHEFHIMGIBI.MHEAEGMIKIE_PublicStatus.DIPKCALNIII_DivaId;
			NNOHKLNKGAD_CostumeId = AHEFHIMGIBI.MHEAEGMIKIE_PublicStatus.BEEAIAAJOHD_CostumeId;
			DJHMGDKKKFO_ColorId = AHEFHIMGIBI.MHEAEGMIKIE_PublicStatus.AFNIOJHODAG_CostumeColorId;
			MDPKLNFFDBO_EmblemId = AHEFHIMGIBI.MHEAEGMIKIE_PublicStatus.ABLOIBMGLFD_EmId;
			KDHCKDHIHIP_EmblemCount = AHEFHIMGIBI.MHEAEGMIKIE_PublicStatus.FHCAFLCLGAA_EmCnt;
			AILEOFKIELL_UtaRateRank = OEGIPPCADNA.BFKAHKBKBJE(AHEFHIMGIBI.MHEAEGMIKIE_PublicStatus.AILEOFKIELL_UtaRateRank, 0);
			KIFEGLJLEDC_TotalUtaRate = AHEFHIMGIBI.KCCLEHLLOFG_Common.EAHPKPADCPL_TotalUtaRate;
			if(NNOHKLNKGAD_CostumeId == 0)
			{
				NNOHKLNKGAD_CostumeId = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.MFPNGNMFEAL_Costume.LBDOLHGDIEB_GetUnlockedCostumeOrDefault(AHHJLDLAPAN_DivaId, 0).JPIDIENBGKH_CostumeId;
			}
		}
	}
 
	public class AIFBLOAGFOP : NNPGLGHDBKN
	{
		public string EBBJPBGHJOL_Content; // 0x3C
		public bool LBODBHCBAMD; // 0x40

		// RVA: 0xD547F8 Offset: 0xD547F8 VA: 0xD547F8
		public AIFBLOAGFOP()
		{
			INDDJNMPONH_Type = NOJONDLAMOC.CCAPCGPIIPF_1_Chat;
		}

		//// RVA: 0xD55410 Offset: 0xD55410 VA: 0xD55410 Slot: 4
		internal override bool KLAOLMDCLHO(BNAAJMBJFPG LBJACBOOLEL, EDOHBJAPLPF_JsonData DLENPPIJNPA)
		{
			if(!base.KLAOLMDCLHO(LBJACBOOLEL, DLENPPIJNPA))
				return false;
			EBBJPBGHJOL_Content = LBJACBOOLEL.NLBNJIFGPJL_Content;
			LBODBHCBAMD = JsonUtil.GetInt(DLENPPIJNPA, "vwt", 0) == 1;
			return true;
		}

		//// RVA: 0xD55940 Offset: 0xD55940 VA: 0xD55940 Slot: 5
		internal override void EFOOHDOMCAI(SakashoBbsCommentInfo KOGBMDOONFA, EDOHBJAPLPF_JsonData DLENPPIJNPA)
		{
			base.EFOOHDOMCAI(KOGBMDOONFA, DLENPPIJNPA);
			KOGBMDOONFA.Content = EBBJPBGHJOL_Content;
			if (!LBODBHCBAMD)
				return;
			DLENPPIJNPA["vwt"] = 1;
		}
	}
 
	public class BNEIDPGIAFM : NNPGLGHDBKN
	{
		public int LIBPMIHHEJD_StampDiva; // 0x3C
		public int HEKIEDEBAEO_StampId; // 0x40
		public int EKAMPLIAENM_SerifId; // 0x44
		public int GKEKNMJMMPK_CannonLogId; // 0x48

		// RVA: 0xD54848 Offset: 0xD54848 VA: 0xD54848
		public BNEIDPGIAFM()
		{
			INDDJNMPONH_Type = NOJONDLAMOC.DDPLFFAOAEB_2_Stamp;
		}

		//// RVA: 0xD55CE0 Offset: 0xD55CE0 VA: 0xD55CE0 Slot: 4
		internal override bool KLAOLMDCLHO(BNAAJMBJFPG LBJACBOOLEL, EDOHBJAPLPF_JsonData DLENPPIJNPA)
		{
			if(base.KLAOLMDCLHO(LBJACBOOLEL, DLENPPIJNPA))
			{
				LIBPMIHHEJD_StampDiva = JsonUtil.GetInt(DLENPPIJNPA, "sdv", 1);
				HEKIEDEBAEO_StampId = JsonUtil.GetInt(DLENPPIJNPA, "smn", 1);
				EKAMPLIAENM_SerifId = JsonUtil.GetInt(DLENPPIJNPA, "scm", 1);
				GKEKNMJMMPK_CannonLogId = JsonUtil.GetInt(DLENPPIJNPA, "mcid", 0);
				if(IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.MGFMPKLLGHE_Diva.BEEGJHCDHJB_IsDivaAvaiable(LIBPMIHHEJD_StampDiva))
				{
					if(CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave.FJPOELGFPBP_DecoStamp.DDKEJHIGBGK_IsStampEnabled(IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.GAPONCJOKAC_DecoStamp, HEKIEDEBAEO_StampId))
					{
						if(CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave.FJPOELGFPBP_DecoStamp.HOAKPBBIGPK_IsSerifEnabled(IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.GAPONCJOKAC_DecoStamp, EKAMPLIAENM_SerifId))
							return true;
					}
				}
			}
			return false;
		}

		//// RVA: 0xD55FB8 Offset: 0xD55FB8 VA: 0xD55FB8 Slot: 5
		internal override void EFOOHDOMCAI(SakashoBbsCommentInfo KOGBMDOONFA, EDOHBJAPLPF_JsonData DLENPPIJNPA)
		{
			base.EFOOHDOMCAI(KOGBMDOONFA, DLENPPIJNPA);
			DLENPPIJNPA["sdv"] = LIBPMIHHEJD_StampDiva;
			DLENPPIJNPA["smn"] = HEKIEDEBAEO_StampId;
			DLENPPIJNPA["scm"] = EKAMPLIAENM_SerifId;
			if (GKEKNMJMMPK_CannonLogId == 0)
				return;
			DLENPPIJNPA["mcid"] = GKEKNMJMMPK_CannonLogId;
		}
	}

	public class PHICILDLHJP : NNPGLGHDBKN
	{
		public string EBBJPBGHJOL_Content; // 0x3C
		public int ICFCJOEMIIJ_Id; // 0x40
		public string PHGNPFJIBLF_Name; // 0x44
		public bool CKIIGKKHDMP_Auto; // 0x48

		//public bool MCINBHIPLML { get; } 0xD573D0 EGCEBDCDLDM

		// RVA: 0xD566B0 Offset: 0xD566B0 VA: 0xD566B0
		public PHICILDLHJP()
		{
			//
		}

		//// RVA: 0xD566F8 Offset: 0xD566F8 VA: 0xD566F8 Slot: 4
		internal override bool KLAOLMDCLHO(BNAAJMBJFPG LBJACBOOLEL, EDOHBJAPLPF_JsonData DLENPPIJNPA)
		{
			if(base.KLAOLMDCLHO(LBJACBOOLEL, DLENPPIJNPA))
			{
				ICFCJOEMIIJ_Id = JsonUtil.GetInt(DLENPPIJNPA, "orid", 0);
				PHGNPFJIBLF_Name = JsonUtil.GetString(DLENPPIJNPA, "ornm", "");
				CKIIGKKHDMP_Auto = JsonUtil.GetInt(DLENPPIJNPA, "auto", 0) == 1;
				if(ICFCJOEMIIJ_Id != 0)
				{
					MLPEHNBNOGD_WritterId = ICFCJOEMIIJ_Id;
					OPFGFINHFCE_PlayerName = PHGNPFJIBLF_Name;
				}
				EBBJPBGHJOL_Content = LBJACBOOLEL.NLBNJIFGPJL_Content;
				return true;
			}
			return false;
		}

		//// RVA: 0xD5681C Offset: 0xD5681C VA: 0xD5681C Slot: 5
		internal override void EFOOHDOMCAI(SakashoBbsCommentInfo KOGBMDOONFA, EDOHBJAPLPF_JsonData DLENPPIJNPA)
		{
			base.EFOOHDOMCAI(KOGBMDOONFA, DLENPPIJNPA);
			if(!string.IsNullOrEmpty(PHGNPFJIBLF_Name))
			{
				DLENPPIJNPA["orid"] = ICFCJOEMIIJ_Id;
				DLENPPIJNPA["ornm"] = PHGNPFJIBLF_Name;
				DLENPPIJNPA["auto"] = CKIIGKKHDMP_Auto ? 1 : 0;
			}
			KOGBMDOONFA.Content = EBBJPBGHJOL_Content;
		}
	}

	public class KNGOGLLMKDL : PHICILDLHJP
	{
		public int HALIDDHLNEG_Damage; // 0x4C
		public int MFMPCHIJINJ_BossType; // 0x50

		// RVA: 0xD54898 Offset: 0xD54898 VA: 0xD54898
		public KNGOGLLMKDL()
		{
			INDDJNMPONH_Type = NOJONDLAMOC.CGEPNIOPFHF_3_DefeatBoss;
		}

		//// RVA: 0xD56350 Offset: 0xD56350 VA: 0xD56350 Slot: 4
		internal override bool KLAOLMDCLHO(BNAAJMBJFPG LBJACBOOLEL, EDOHBJAPLPF_JsonData DLENPPIJNPA)
		{
			if(base.KLAOLMDCLHO(LBJACBOOLEL, DLENPPIJNPA))
			{
				HALIDDHLNEG_Damage = JsonUtil.GetInt(DLENPPIJNPA, "dme", 0);
				MFMPCHIJINJ_BossType = JsonUtil.GetInt(DLENPPIJNPA, "btp", 1);
				return true;
			}
			return false;
		}

		//// RVA: 0xD56598 Offset: 0xD56598 VA: 0xD56598 Slot: 5
		internal override void EFOOHDOMCAI(SakashoBbsCommentInfo KOGBMDOONFA, EDOHBJAPLPF_JsonData DLENPPIJNPA)
		{
			base.EFOOHDOMCAI(KOGBMDOONFA, DLENPPIJNPA);
			DLENPPIJNPA["dme"] = HALIDDHLNEG_Damage;
			DLENPPIJNPA["btp"] = MFMPCHIJINJ_BossType;
		}
	}

	public class NBHIMCACDHM : PHICILDLHJP
	{
		public string GJAOLNLFEBD_BossName; // 0x4C
		public int EJGDHAENIDC_BossRank; // 0x50
		public int PCPODOMOFDH_BossSeriesAttr; // 0x54
		public int JNBDLNBKDCO_BossImage; // 0x58
		public int HALIDDHLNEG_Damage; // 0x5C
		public int KKPAHLMJKIH_WavId; // 0x60
		public bool IGNJCGMLBDA_Defeat; // 0x64
		public bool IKICLMGFFPB; // 0x65
		public int CNOHJPEHHCH_LogId; // 0x68

		// RVA: 0xD548E8 Offset: 0xD548E8 VA: 0xD548E8
		public NBHIMCACDHM()
		{
			INDDJNMPONH_Type = NOJONDLAMOC.JDGLJOFPHLK_4_MaccrossCannon;
		}

		//// RVA: 0xD569DC Offset: 0xD569DC VA: 0xD569DC Slot: 4
		internal override bool KLAOLMDCLHO(BNAAJMBJFPG LBJACBOOLEL, EDOHBJAPLPF_JsonData DLENPPIJNPA)
		{
			if(base.KLAOLMDCLHO(LBJACBOOLEL, DLENPPIJNPA))
			{
				HALIDDHLNEG_Damage = JsonUtil.GetInt(DLENPPIJNPA, "dme", 0);
				int def = JsonUtil.GetInt(DLENPPIJNPA, "def", 0);
				GJAOLNLFEBD_BossName = JsonUtil.GetString(DLENPPIJNPA, "bnm", JpStringLiterals.StringLiteral_9477);
				EJGDHAENIDC_BossRank = JsonUtil.GetInt(DLENPPIJNPA, "brk", 0);
				PCPODOMOFDH_BossSeriesAttr = JsonUtil.GetInt(DLENPPIJNPA, "bsr", 1);
				JNBDLNBKDCO_BossImage = JsonUtil.GetInt(DLENPPIJNPA, "bim", 1);
				KKPAHLMJKIH_WavId = JsonUtil.GetInt(DLENPPIJNPA, "wav", 1);
				int bsp = JsonUtil.GetInt(DLENPPIJNPA, "bsp", 0);
				CNOHJPEHHCH_LogId = JsonUtil.GetInt(DLENPPIJNPA, "sid", 0);
				if(SeriesAttr.ValidateSeriesAttr((SeriesAttr.Type)PCPODOMOFDH_BossSeriesAttr))
				{
					if(JNBDLNBKDCO_BossImage < 1)
					{
						if(IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.HNMMJINNHII_Game.LPJLEHAJADA("raid_boss_image_max", 16) < JNBDLNBKDCO_BossImage)
							return false;
					}
					if(KKPAHLMJKIH_WavId > 0)
					{
						if((def | bsp) < 2)
						{
							IKICLMGFFPB = bsp == 1;
							IGNJCGMLBDA_Defeat = def == 1;
							return true;
						}
					}
				}
			}
			return false;
		}

		//// RVA: 0xD56CE4 Offset: 0xD56CE4 VA: 0xD56CE4 Slot: 5
		internal override void EFOOHDOMCAI(SakashoBbsCommentInfo KOGBMDOONFA, EDOHBJAPLPF_JsonData DLENPPIJNPA)
		{
			base.EFOOHDOMCAI(KOGBMDOONFA, DLENPPIJNPA);
			DLENPPIJNPA["bnm"] = GJAOLNLFEBD_BossName;
			DLENPPIJNPA["brk"] = EJGDHAENIDC_BossRank;
			DLENPPIJNPA["bsr"] = PCPODOMOFDH_BossSeriesAttr;
			DLENPPIJNPA["bim"] = JNBDLNBKDCO_BossImage;
			DLENPPIJNPA["dme"] = HALIDDHLNEG_Damage;
			DLENPPIJNPA["wav"] = KKPAHLMJKIH_WavId;
			DLENPPIJNPA["def"] = IGNJCGMLBDA_Defeat ? 1 : 0;
			DLENPPIJNPA["bsp"] = IKICLMGFFPB ? 1 : 0;
			DLENPPIJNPA["sid"] = CNOHJPEHHCH_LogId;
		}
	}

	public class JLHGKKIEALB : KNGOGLLMKDL
	{
		public int ADHMMMEOJMK_FreeSongId; // 0x54
		public int AKNELONELJK_Difficulty; // 0x58
		public bool GIKLNODJKFK_Line6; // 0x5C

		//public bool IGNJCGMLBDA { get; } 0xD56184

		// RVA: 0xD54938 Offset: 0xD54938 VA: 0xD54938
		public JLHGKKIEALB()
		{
			INDDJNMPONH_Type = NOJONDLAMOC.JPOGBMJKPIJ_5_FullCombo;
		}

		//// RVA: 0xD56198 Offset: 0xD56198 VA: 0xD56198 Slot: 4
		internal override bool KLAOLMDCLHO(BNAAJMBJFPG LBJACBOOLEL, EDOHBJAPLPF_JsonData DLENPPIJNPA)
		{
			if(base.KLAOLMDCLHO(LBJACBOOLEL, DLENPPIJNPA))
			{
				ADHMMMEOJMK_FreeSongId = JsonUtil.GetInt(DLENPPIJNPA, "fid", 1);
				AKNELONELJK_Difficulty = JsonUtil.GetInt(DLENPPIJNPA, "dif", 0);
				int ln6 = JsonUtil.GetInt(DLENPPIJNPA, "ln6", 0);
				if(IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.IBPAFKKEKNK_Music.BHJKMPBACAC_IsFreeMusicAvaiable(ADHMMMEOJMK_FreeSongId))
				{
					if(ln6 < 2 && OECGFGINKLK.NKBNHCECIPH(AKNELONELJK_Difficulty))
					{
						GIKLNODJKFK_Line6 = ln6 == 1;
						return true;
					}
				}
			}
			return false;
		}

		//// RVA: 0xD56410 Offset: 0xD56410 VA: 0xD56410 Slot: 5
		internal override void EFOOHDOMCAI(SakashoBbsCommentInfo KOGBMDOONFA, EDOHBJAPLPF_JsonData DLENPPIJNPA)
		{
			base.EFOOHDOMCAI(KOGBMDOONFA, DLENPPIJNPA);
			DLENPPIJNPA["fid"] = ADHMMMEOJMK_FreeSongId;
			DLENPPIJNPA["dif"] = AKNELONELJK_Difficulty;
			DLENPPIJNPA["ln6"] = GIKLNODJKFK_Line6 ? 1 : 0;
		}
	}

	private KEPNMGHABPI AMDPJLBPLIG; // 0x8
	private SakashoBbsCommentCriteria OLOHJCBNIFI = new SakashoBbsCommentCriteria() { ExcludeDeleted = true }; // 0xC
	public List<NNPGLGHDBKN> HDMKAIKOMCB = new List<NNPGLGHDBKN>(); // 0x10

	//// RVA: 0xD54160 Offset: 0xD54160 VA: 0xD54160
	public static bool JCGBEAHDNEI_IsBattleLogMessage(NOJONDLAMOC INDDJNMPONH)
	{
		return INDDJNMPONH >= NOJONDLAMOC.CGEPNIOPFHF_3_DefeatBoss && INDDJNMPONH <= NOJONDLAMOC.JPOGBMJKPIJ_5_FullCombo;
	}

	//// RVA: 0xD54174 Offset: 0xD54174 VA: 0xD54174
	public void OBKGEDCKHHE(string JIHGLOIIGON, int EMGJJFKONHK, bool LAGDKBMDHLD = false)
	{
		BNJJHPEGNAI.HCAJEKFFNBM data = new BNJJHPEGNAI.HCAJEKFFNBM();
		data.KGICDMIJGDF = JIHGLOIIGON;
		data.EMGJJFKONHK_ExpireDays = EMGJJFKONHK;
		data.BDNDHFBNBLL_ExcludeBlockedThread = LAGDKBMDHLD;
		AMDPJLBPLIG = KEPNMGHABPI.OGIFFNLIDIO.GOAMILGNJIE(data);
	}

	//// RVA: 0xD54290 Offset: 0xD54290 VA: 0xD54290
	public void HGBINHBILCP()
	{
		AMDPJLBPLIG.IPBDPLOKLLP();
		HDMKAIKOMCB.Clear();
	}

	//// RVA: 0xD54328 Offset: 0xD54328 VA: 0xD54328
	//public void HDGIBKFJDOG(int KPNKPGLPDHI, int MKLHCKJEKKC, IMCBBOAFION BHFHGFKBOHH, DJBHIFLHJLK MOBEEPPKFLG) { }

	//// RVA: 0xD5436C Offset: 0xD5436C VA: 0xD5436C
	public void GBLHONFLPPD(int KPNKPGLPDHI, int MKLHCKJEKKC, IMCBBOAFION BHFHGFKBOHH, DJBHIFLHJLK MOBEEPPKFLG)
	{
		AMDPJLBPLIG.EMHMAJDNEJB(KPNKPGLPDHI, (List<KEPNMGHABPI.CAIPMAMHNJP> CEGPFLLDBGM) =>
		{
			//0xD550F8
			for(int i = 0; i < CEGPFLLDBGM.Count; i++)
			{
				GCONPMCMEGA(CEGPFLLDBGM[i].CCBEKGNDDBE);
			}
			BHFHGFKBOHH();
		}, MOBEEPPKFLG, MKLHCKJEKKC, OLOHJCBNIFI);
	}

	//// RVA: 0xD544A8 Offset: 0xD544A8 VA: 0xD544A8
	private void GCONPMCMEGA(BNAAJMBJFPG LBJACBOOLEL)
	{
		if(LBJACBOOLEL.ILGKMOJFEDK)
			return;
		EDOHBJAPLPF_JsonData json = IKPIMINCOPI_JsonMapper.PFAMKCGJKKL_ToObject(LBJACBOOLEL.KACECFNECON_Extra);
		int type = (int)json["type"];
		NNPGLGHDBKN data = null;
		switch(type)
		{
			case 1:
				data = new AIFBLOAGFOP();
				data.INDDJNMPONH_Type = NOJONDLAMOC.CCAPCGPIIPF_1_Chat;
				break;
			case 2:
				data = new BNEIDPGIAFM();
				data.INDDJNMPONH_Type = NOJONDLAMOC.DDPLFFAOAEB_2_Stamp;
				break;
			case 3:
				data = new KNGOGLLMKDL();
				data.INDDJNMPONH_Type = NOJONDLAMOC.CGEPNIOPFHF_3_DefeatBoss;
				break;
			case 4:
				data = new NBHIMCACDHM();
				data.INDDJNMPONH_Type = NOJONDLAMOC.JDGLJOFPHLK_4_MaccrossCannon;
				break;
			case 5:
				data = new JLHGKKIEALB();
				data.INDDJNMPONH_Type = NOJONDLAMOC.JPOGBMJKPIJ_5_FullCombo;
				break;
			default:
				return;
		}
		data.KDHCKDHIHIP_EmblemCount = 0;
		data.AILEOFKIELL_UtaRateRank = 0;
		data.KIFEGLJLEDC_TotalUtaRate = 0;
		data.AHHJLDLAPAN_DivaId = 1;
		data.NNOHKLNKGAD_CostumeId = 1;
		data.DJHMGDKKKFO_ColorId = 0;
		data.MDPKLNFFDBO_EmblemId = 1;
		if(data.KLAOLMDCLHO(LBJACBOOLEL, json))
		{
			HDMKAIKOMCB.Add(data);
		}
	}

	//// RVA: 0xD54988 Offset: 0xD54988 VA: 0xD54988
	public bool GMNAECEEHHJ()
	{
		return AMDPJLBPLIG.JGGFDPHHKJD();
	}

	//// RVA: 0xD549B4 Offset: 0xD549B4 VA: 0xD549B4
	private SakashoBbsCommentInfo EEGECGEGPHM(NNPGLGHDBKN HCAHCFGPJIF)
	{
		SakashoBbsCommentInfo res = new SakashoBbsCommentInfo();
		EDOHBJAPLPF_JsonData json = new EDOHBJAPLPF_JsonData();
		json["type"] = (int)HCAHCFGPJIF.INDDJNMPONH_Type;
		HCAHCFGPJIF.OPFGFINHFCE_PlayerName = CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave.JHFIPCIHJNL_Base.OPFGFINHFCE_PlayerName;
		HCAHCFGPJIF.EFOOHDOMCAI(res, json);
		res.Extra = json.EJCOJCGIBNG_ToJson(); //IKPIMINCOPI_JsonMapper.EJCOJCGIBNG_ToJson(json);
		return res;
	}

	//// RVA: 0xD54BD4 Offset: 0xD54BD4 VA: 0xD54BD4
	public void NPIBJOGODKG(int KPNKPGLPDHI, NNPGLGHDBKN HCAHCFGPJIF, IMCBBOAFION BHFHGFKBOHH, DJBHIFLHJLK MOBEEPPKFLG, DJBHIFLHJLK NKGHADCBGJO)
	{
		AMDPJLBPLIG.IFFGEIMIKHH(KPNKPGLPDHI, EEGECGEGPHM(HCAHCFGPJIF), () =>
		{
			//0xD5521C
			BHFHGFKBOHH();
		}, MOBEEPPKFLG, NKGHADCBGJO);
	}

	//// RVA: 0xD54CF0 Offset: 0xD54CF0 VA: 0xD54CF0
	public void HCMMMCFFGCA_UpdateThreadComment(int KPNKPGLPDHI, NNPGLGHDBKN HCAHCFGPJIF, IMCBBOAFION BHFHGFKBOHH, DJBHIFLHJLK MOBEEPPKFLG)
	{
		AMDPJLBPLIG.OMEFFONNMBC(KPNKPGLPDHI, (KEPNMGHABPI.LNCLNAOPNKF PMDLBHLNIDP) =>
		{
			//0xD55248
			AMDPJLBPLIG.HCMMMCFFGCA_UpdateThreadComment(KPNKPGLPDHI, PMDLBHLNIDP.BOINIEAKFPL_Id, HCAHCFGPJIF.OIPCCBHIKIA_Idx, EEGECGEGPHM(HCAHCFGPJIF), BHFHGFKBOHH, MOBEEPPKFLG);
		}, MOBEEPPKFLG, null);
	}

	//// RVA: 0xD54E88 Offset: 0xD54E88 VA: 0xD54E88
	//public void NCLDLJLAEBK(int KPNKPGLPDHI, ANPBHCNJIDI.NNPGLGHDBKN HCAHCFGPJIF, IMCBBOAFION BHFHGFKBOHH, DJBHIFLHJLK MOBEEPPKFLG) { }
}
