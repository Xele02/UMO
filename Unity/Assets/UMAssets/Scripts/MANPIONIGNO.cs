
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.Localization.SmartFormat.Utilities;
using XeApp.Game;
using XeApp.Game.Common;
using XeApp.Game.Menu;
using XeSys;

[System.Obsolete("Use MANPIONIGNO_EventGoDiva", true)]
public class MANPIONIGNO { }
public class MANPIONIGNO_EventGoDiva : IKDICBBFBMI_EventBase
{
	public class OCGMIDIINLL
	{
		public class BDLIMMGHANM
		{
			private int FBGGEFFJJHB_xor; // 0x8
			private int AADPAJOLEEF_PointCrypted; // 0xC
			private int PEBHLFLDIGC_Crypted; // 0x10
			private int LAPPOAFOPND_Crypted; // 0x14
			private int OJLAFKPHLJD_Crypted; // 0x18
			private int NFCALENBIBL_LevelCrypted; // 0x1C
			private int OEPBLDJHGBB_Crypted; // 0x20
			private int OAOEKMKPEMI_Crypted; // 0x24
			private int KIFFCIMABMI_Crypted; // 0x28
			private int PBKHPPHHFDN_Crypted; // 0x2C
			private int PAAEHHEKEHC_Crypted; // 0x34
			private int NLBLLLLBHOP_StatusCrypted; // 0x38

			public int DNBFMLBNAEE_point { get { return AADPAJOLEEF_PointCrypted ^ FBGGEFFJJHB_xor; } set { AADPAJOLEEF_PointCrypted = value ^ FBGGEFFJJHB_xor; } } //0xA278B4 JKHIIAEMMDE_bgs 0xA27864 PFFKLBLEPKB_bgs
			public int DJJGNDCMNHF_BonusValue { get { return PEBHLFLDIGC_Crypted ^ FBGGEFFJJHB_xor; } set { PEBHLFLDIGC_Crypted = value ^ FBGGEFFJJHB_xor; } } //0xA27854 GEPCOAPEAJM_get_BonusValue 0xA26AE0 MIFJBBAJAJP_set_BonusValue
			public int JDCFEBMOOMN_GetExp { get { return LAPPOAFOPND_Crypted ^ FBGGEFFJJHB_xor; } set { LAPPOAFOPND_Crypted = value ^ FBGGEFFJJHB_xor; } } //0xA278D4 EAHBOFPLEJF_bgs 0xA278C4 NKOONIDGLGF_bgs
			public int KFEMFDFPCGO_Level0 { get { return OJLAFKPHLJD_Crypted ^ FBGGEFFJJHB_xor; } set { OJLAFKPHLJD_Crypted = value ^ FBGGEFFJJHB_xor; } } //0xA27DA0 BJAONJMLNCL_bgs 0xA27894 EIBGPAIINPH_bgs
			public int CIEOBFIIPLD_Level { get { return NFCALENBIBL_LevelCrypted ^ FBGGEFFJJHB_xor; } set { NFCALENBIBL_LevelCrypted = value ^ FBGGEFFJJHB_xor; } } //0xA27D90 OGKGFGMKPKB_bgs 0xA27D70 JOOMBHHPHBD_bgs
			public int AKPPMDMNOHL_StartLevel { get { return OEPBLDJHGBB_Crypted ^ FBGGEFFJJHB_xor; } set { OEPBLDJHGBB_Crypted = value ^ FBGGEFFJJHB_xor; } } //0xA2C8E4 INIGINPNMIE_bgs 0xA27884 BCFPCPDJABC_bgs
			public int GLFIELJJDCI_Level { get { return OAOEKMKPEMI_Crypted ^ FBGGEFFJJHB_xor; } set { OAOEKMKPEMI_Crypted = value ^ FBGGEFFJJHB_xor; } } //0xA2C8F4 GIOFIJGKHFK_bgs 0xA27D60 ACNICMCBEIF_bgs
			public int EJOHDINLOAJ_PrevExp { get { return KIFFCIMABMI_Crypted ^ FBGGEFFJJHB_xor; } set { KIFFCIMABMI_Crypted = value ^ FBGGEFFJJHB_xor; } } //0xA2C904 PFOJDKMDLCA_bgs 0xA27874 CJMCKEKMKGM_bgs
			public int LKIFDCEKDCK_exp { get { return PBKHPPHHFDN_Crypted ^ FBGGEFFJJHB_xor; } set { PBKHPPHHFDN_Crypted = value ^ FBGGEFFJJHB_xor; } } //0xA2C914 GOKMANFHFPC_get_exp 0xA27D50 ICJKOKGFNLI_set_exp
			public List<int> FKAOJEMHAKN_LevelExp { get; set; } // 0x30 PKLHMHKAHNJ_bgs EMPBECLMHKJ_bgs DBPCENDADCJ_bgs
			public int NMJIKIJLAMP_BeforeValue { get { return PAAEHHEKEHC_Crypted ^ FBGGEFFJJHB_xor; } set { PAAEHHEKEHC_Crypted = value ^ FBGGEFFJJHB_xor; } } //0xA2C92C MGHMNJCGPBA_bgs 0xA278A4 MFHANNLGJBB_bgs
			public int CMCKNKKCNDK_status { get { return NLBLLLLBHOP_StatusCrypted ^ FBGGEFFJJHB_xor; } set { NLBLLLLBHOP_StatusCrypted = value ^ FBGGEFFJJHB_xor; } } //0xA2C93C CNKGOPKANGF_bgs 0xA27D80 CHJGGLFGALP_set_status

			// // RVA: 0xA2C8B4 Offset: 0xA2C8B4 VA: 0xA2C8B4
			public void KHEKNNFCAOI_Init(int KNEFBLHBDBG)
			{
				FBGGEFFJJHB_xor = KNEFBLHBDBG;
				EJOHDINLOAJ_PrevExp = 0;
				LKIFDCEKDCK_exp = 0;
				NMJIKIJLAMP_BeforeValue = 0;
				CMCKNKKCNDK_status = 0;
				KFEMFDFPCGO_Level0 = 0;
				CIEOBFIIPLD_Level = 0;
				AKPPMDMNOHL_StartLevel = 0;
				GLFIELJJDCI_Level = 0;
				DNBFMLBNAEE_point = 0;
				DJJGNDCMNHF_BonusValue = 0;
				JDCFEBMOOMN_GetExp = 0;
			}
		}

		private int FBGGEFFJJHB_xor; // 0x8
		private int GKLNGLHPNMK_Crypted; // 0xC
		private int DGLKNBPHFJA_Crypted; // 0x10
		private int NBOLDNMPJFG_scoreCrypted; // 0x14
		private int IJHLNEJFMNB_Crypted; // 0x18
		private int DHPBINLHAMJ_Crypted; // 0x1C
		private int KLEBOEEDMNL_Crypted; // 0x20
		private int HFGCAKNNLCH_Crypted; // 0x24
		private int HJOJJCKDPPJ_Crypted; // 0x28
		private int CGPODGLAFCL_Crypted; // 0x2C
		private int PKLPABPJOLB_Crypted; // 0x30
		private int GPPIKDNLBGI_Crypted; // 0x34
		private sbyte FJDEHCNKKBF_Crypted; // 0x38
		private sbyte GINIAGEHMOO_Crypted; // 0x39
		private sbyte IGKFNPJDOLM_Crypted; // 0x3A
		private int PJDFBHDLEJN_Crypted; // 0x3C
		private int FEHNEAACGNC_Crypted; // 0x40
		private sbyte EJPAGBKMOOG_Crypted; // 0x44
		private int KIHLOJGPFII_Crypted; // 0x48
		public bool LFGNLKKFOCD_IsLine6; // 0x4C
		public BDLIMMGHANM MKMIEGPOKGG_Soul = new BDLIMMGHANM(); // 0x50
		public BDLIMMGHANM EACDINDLGLF_Voice = new BDLIMMGHANM(); // 0x54
		public BDLIMMGHANM LDLHPACIIAB_Charm = new BDLIMMGHANM(); // 0x58

		public int OENBOLPDBAB_FreeMusicId { get { return GKLNGLHPNMK_Crypted ^ FBGGEFFJJHB_xor; } set { GKLNGLHPNMK_Crypted = value ^ FBGGEFFJJHB_xor; } } //0xA26A40 IMKAINEGNOH_bgs 0xA269E0 KHLDCDEGIEG_bgs
		public int EJDJIBPKKNO_BasePoint { get { return DGLKNBPHFJA_Crypted ^ FBGGEFFJJHB_xor; } set { DGLKNBPHFJA_Crypted = value ^ FBGGEFFJJHB_xor; } } //0xA26980 HDENOKICDAI_bgs 0xA26960 IOMAGMBLBOE_bgs
		public int KNIFCANOHOC_score { get { return NBOLDNMPJFG_scoreCrypted ^ FBGGEFFJJHB_xor; } set { NBOLDNMPJFG_scoreCrypted = value ^ FBGGEFFJJHB_xor; } } //0xA2C6F0 EOJEPLIPOMJ_get_score 0xA265C8 AEEMBPAEAAI_set_score
		// ScoreBonus
		public int JBJJFDIHKMB_ScorePoint { get { return IJHLNEJFMNB_Crypted ^ FBGGEFFJJHB_xor; } set { IJHLNEJFMNB_Crypted = value ^ FBGGEFFJJHB_xor; } } //0xA26990 OJAKCDKDJOP_bgs 0xA265D8 AKCBKALINGO_bgs
		public int LIPIAPOGHIP_EpisodeNum { get { return DHPBINLHAMJ_Crypted ^ FBGGEFFJJHB_xor; } set { DHPBINLHAMJ_Crypted = value ^ FBGGEFFJJHB_xor; } } //0xA2C700 BFBKHCJDJCE_bgs0xA265E8 CNIOHNEEAEO_bgs
		public int PFJMBKBEFMA_EpisodeRate { get { return KLEBOEEDMNL_Crypted ^ FBGGEFFJJHB_xor; } set { KLEBOEEDMNL_Crypted = value ^ FBGGEFFJJHB_xor; } } //0xA26608 HOHDIJAFKJK_bgs 0xA265F8 IKLBIGHPPKP_bgs
		public int JKFCHNEININ_GetPoint { get { return HFGCAKNNLCH_Crypted ^ FBGGEFFJJHB_xor; } set { HFGCAKNNLCH_Crypted = value ^ FBGGEFFJJHB_xor; } } //0xA269B0 FMNLKIKCBNO_bgs 0xA269A0 NNIFEOOBCCP_bgs
		public int AHOKAPCGJMA_TotalPoint { get { return HJOJJCKDPPJ_Crypted ^ FBGGEFFJJHB_xor; } set { HJOJJCKDPPJ_Crypted = value ^ FBGGEFFJJHB_xor; } } //0xA2C710 GKLPFHEELGM_bgs 0xA269D0 EJPEPBGDDJM_bgs
		public int AONOCELOCLL_BonusMusicProbaBefore { get { return CGPODGLAFCL_Crypted ^ FBGGEFFJJHB_xor; } set { CGPODGLAFCL_Crypted = value ^ FBGGEFFJJHB_xor; } } //0xA2C720 OALCPMNOHHE_bgs 0xA26A70 CNJIFLKBCJG_bgs
		public int KBBOPKDLHHJ_BonusMusicProbaAfter { get { return PKLPABPJOLB_Crypted ^ FBGGEFFJJHB_xor; } set { PKLPABPJOLB_Crypted = value ^ FBGGEFFJJHB_xor; } } //0xA274AC KKODCEEMDKL_bgs 0xA26E38 KPBBACHPAHM_bgs
		public int KPEKOOCPKID_BonusId { get { return GPPIKDNLBGI_Crypted ^ FBGGEFFJJHB_xor; } set { GPPIKDNLBGI_Crypted = value ^ FBGGEFFJJHB_xor; } } //0xA2381C ECDMMNLDNKN_bgs 0xA23558 DDDEIFADLOK_bgs
		public bool DEFAOMCNGAJ_IsBonusDaily { get { return FJDEHCNKKBF_Crypted == 117; } set { FJDEHCNKKBF_Crypted = (sbyte)(value ? 117 : 56); } } //0xA274D0 NNHFPCPPPGI_bgs 0xA23568 MAMJOCOLGHG_bgs
		public bool JGBIFJLPCHM_IsBonusStart { get { return GINIAGEHMOO_Crypted == 66; } set { GINIAGEHMOO_Crypted = (sbyte)(value ? 66 : 22); } } //0xA274BC PCINHAPINOB_bgs 0xA26A80 KNIMMDOLLFE_bgs
		public bool IMDPOICJKLF_IsBonusEnd { get { return IGKFNPJDOLM_Crypted == 66; } set { IGKFNPJDOLM_Crypted = (sbyte)(value ? 66 : 22); } } //0xA2C730 HMMMAABCFOK_bgs 0xA26AB0 FIKAOOKFJBP_bgs
		public int LMBFJMBIIGN { get { return PJDFBHDLEJN_Crypted ^ FBGGEFFJJHB_xor; } set { PJDFBHDLEJN_Crypted = value ^ FBGGEFFJJHB_xor; } } //0xA26A50 ICIPPPBGIDF_bgs 0xA269F0 LLMBFMNCOBK_bgs
		public int JLIKEOKBBAM_HighScore { get { return FEHNEAACGNC_Crypted ^ FBGGEFFJJHB_xor; } set { FEHNEAACGNC_Crypted = value ^ FBGGEFFJJHB_xor; } } //0xA26A60 LMFAPBIPBHF_bgs 0xA26A00 AJMECFJJFJI_bgs
		public bool FFHMPNGJCLK_NewRecord { get { return EJPAGBKMOOG_Crypted == 119; } set { EJPAGBKMOOG_Crypted = (sbyte)(value ? 119 : 105); } } //0xA2C744 CMHNAFLEENF_bgs 0xA26A10 OEPHKBJBDPO_bgs
		public int FCLGIPFPIPH_DashBonus { get { return KIHLOJGPFII_Crypted ^ FBGGEFFJJHB_xor; } set { KIHLOJGPFII_Crypted = value ^ FBGGEFFJJHB_xor; } } //0xA269C0 GHFOOLBCDBM_bgs 0xA26970 EFACKLMPIOD_bgs

		// // RVA: 0xA2C758 Offset: 0xA2C758 VA: 0xA2C758
		public void KHEKNNFCAOI_Init(int KNEFBLHBDBG)
		{
			FBGGEFFJJHB_xor = KNEFBLHBDBG;
			AHOKAPCGJMA_TotalPoint = 0;
			KBBOPKDLHHJ_BonusMusicProbaAfter = 0;
			KPEKOOCPKID_BonusId = 0;
			JBJJFDIHKMB_ScorePoint = 0;
			LIPIAPOGHIP_EpisodeNum = 0;
			PFJMBKBEFMA_EpisodeRate = 0;
			JKFCHNEININ_GetPoint = 0;
			OENBOLPDBAB_FreeMusicId = 0;
			EJDJIBPKKNO_BasePoint = 0;
			KNIFCANOHOC_score = 0;
			IMDPOICJKLF_IsBonusEnd = false;
			DEFAOMCNGAJ_IsBonusDaily = false;
			JGBIFJLPCHM_IsBonusStart = false;
			JLIKEOKBBAM_HighScore = 0;
			FCLGIPFPIPH_DashBonus = 0;
			FFHMPNGJCLK_NewRecord = false;
			LFGNLKKFOCD_IsLine6 = false;
			MKMIEGPOKGG_Soul.KHEKNNFCAOI_Init(KNEFBLHBDBG);
			EACDINDLGLF_Voice.KHEKNNFCAOI_Init(KNEFBLHBDBG);
			LDLHPACIIAB_Charm.KHEKNNFCAOI_Init(KNEFBLHBDBG);
		}

		// RVA: 0xA16A40 Offset: 0xA16A40 VA: 0xA16A40
		public OCGMIDIINLL()
		{
			KHEKNNFCAOI_Init((int)Utility.GetCurrentUnixTime() ^ 0x6785126);
		}
	}

	public class IBNAEKMCIEO
	{
		private int FBGGEFFJJHB_xor; // 0x8
		private int EHOIENNDEDH_IdCrypted; // 0xC
		private int AMDBHBCFJEM_Crypted; // 0x10
		private int MCNAMIDDKIC_Crypted; // 0x14
		private int LNCNCKAHBLN_Crypted; // 0x18
		private sbyte KGNLNEMBLGF_Crypted; // 0x1C

		public int PPFNGGCBJKC_id { get { return EHOIENNDEDH_IdCrypted ^ FBGGEFFJJHB_xor; } set { EHOIENNDEDH_IdCrypted = value ^ FBGGEFFJJHB_xor; } } //0xA23734 DEMEPMAEJOO_get_id 0xA28CB4 HIGKAIDMOKN_set_id
		public int NOEFINFEMBM { get { return AMDBHBCFJEM_Crypted ^ FBGGEFFJJHB_xor; } set { AMDBHBCFJEM_Crypted = value ^ FBGGEFFJJHB_xor; } } //0xA27824 DBPGDHLPECI_bgs 0xA28CC4 HMKBICIJGHP_bgs
		public int PKDAEFIGMLI { get { return MCNAMIDDKIC_Crypted ^ FBGGEFFJJHB_xor; } set { MCNAMIDDKIC_Crypted = value ^ FBGGEFFJJHB_xor; } } //0xA27834 IJNEJAPCHKO_bgs 0xA28CD4 NEJLFMGNPKL_bgs
		public int DGAELGEJPNA { get { return LNCNCKAHBLN_Crypted ^ FBGGEFFJJHB_xor; } set { LNCNCKAHBLN_Crypted = value ^ FBGGEFFJJHB_xor; } } //0xA27844 PFHFFFDPPJD_bgs 0xA28CE4 GNCIPLCPHON_bgs
		public bool CGHNCPEKOCK_IsDaily { get { return KGNLNEMBLGF_Crypted == 42; } set { KGNLNEMBLGF_Crypted = (sbyte)(value ? 42 : 193); } } //0xA23744 OFIKFHIBLLP_bgs 0xA28CF4 NGIBLJJHMFE_bgs

		// // RVA: 0xA2C6B8 Offset: 0xA2C6B8 VA: 0xA2C6B8
		// public void KHEKNNFCAOI_Init(int KNEFBLHBDBG) { }

		// RVA: 0xA28BF4 Offset: 0xA28BF4 VA: 0xA28BF4
		public IBNAEKMCIEO()
		{
			FBGGEFFJJHB_xor = (int)Utility.GetCurrentUnixTime() ^ 0xa82d501;
			PPFNGGCBJKC_id = 0;
			NOEFINFEMBM = 0;
			PKDAEFIGMLI = 0;
			DGAELGEJPNA = 0;
			CGHNCPEKOCK_IsDaily = false;
		}
	}

	private const int GHJHJDIDCFA = 3;
	private List<LNELCMNJPIC_EventGoDiva.HGLNJDGOPMM> NFMDLCBJOIB_SongCacheList = new List<LNELCMNJPIC_EventGoDiva.HGLNJDGOPMM>(); // 0xE8
	private EECOJKDJIFG[] KBACNOCOANM_Ranking = new EECOJKDJIFG[10]; // 0xEC
	public bool KIBBLLADDPO; // 0xF0
	public OCGMIDIINLL CMCEGEKGEEP = new OCGMIDIINLL(); // 0xF4

	public override OHCAABOMEOF.KGOGMKMBCPP_EventType HIDHLFCBIDE_EventType { get { return OHCAABOMEOF.KGOGMKMBCPP_EventType.BNECMLPHAGJ_EventGoDiva; } } //0xA168C0 DKHCGLCNKCD_bgs Slot: 4

	// // RVA: 0xA168C8 Offset: 0xA168C8 VA: 0xA168C8 Slot: 32
	public override EECOJKDJIFG DAKMIKNKHMF_GetRankingInfoForIndex(int LHJCOPMMIGO)
	{
		if(LHJCOPMMIGO >= NGIHFKHOJOK_GetRankingMax(true))
			return null;
		return KBACNOCOANM_Ranking[LHJCOPMMIGO];
	}

	// RVA: 0xA1693C Offset: 0xA1693C VA: 0xA1693C
	public MANPIONIGNO_EventGoDiva(string _OPFGFINHFCE_name) : base(_OPFGFINHFCE_name)
    {
        CMEOKJMCEBH_IsGoDiva = true;
    }

	// // RVA: 0xA16B34 Offset: 0xA16B34 VA: 0xA16B34 Slot: 5
	public override string IFKKBHPMALH()
	{
		LNELCMNJPIC_EventGoDiva ev = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.LBDOLHGDIEB_Find(JOPOPMLFINI_QuestName) as LNELCMNJPIC_EventGoDiva;
		if(ev != null)
		{
			return ev.NGHKJOEDLIP_Settings.OCDMGOGMHGE_KeyPrefix;
		}
		return null;
	}

	// // RVA: 0xA16CBC Offset: 0xA16CBC VA: 0xA16CBC
	private List<LNELCMNJPIC_EventGoDiva.HGLNJDGOPMM> LEAGIGKFMPE_GenerateMusicList()
	{
		LNELCMNJPIC_EventGoDiva ev = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.LBDOLHGDIEB_Find(JOPOPMLFINI_QuestName) as LNELCMNJPIC_EventGoDiva;
		if(ev != null)
		{
			long t = NKGJPJPHLIF.HHCJCDFCLOB.IBLPICFDGOF_ServerRequester.FJDBNGEPKHL_Time.KMEFBNBFJHI_GetServerTime();
			NFMDLCBJOIB_SongCacheList.Clear();
			for(int i = 0; i < ev.IJJHFGOIDOK_EventMusic.Count; i++)
			{
				if(ev.IJJHFGOIDOK_EventMusic[i].PLALNIIBLOF_en == 2)
				{
					if((ev.IJJHFGOIDOK_EventMusic[i].PDBPFJJCADD_open_at == 0 && ev.IJJHFGOIDOK_EventMusic[i].FDBNFFNFOND_close_at == 0) || 
						(ev.IJJHFGOIDOK_EventMusic[i].PDBPFJJCADD_open_at <= t && ev.IJJHFGOIDOK_EventMusic[i].FDBNFFNFOND_close_at >= t))
					{
						NFMDLCBJOIB_SongCacheList.Add(ev.IJJHFGOIDOK_EventMusic[i]);
					}
				}
			}
			return NFMDLCBJOIB_SongCacheList;
		}
		return null;
	}

	// // RVA: 0xA17070 Offset: 0xA17070 VA: 0xA17070
	public List<LNELCMNJPIC_EventGoDiva.HGLNJDGOPMM> KOBMFPACBMB_GetCachedSongList()
	{
		if(NFMDLCBJOIB_SongCacheList.Count < 1)
		{
			return LEAGIGKFMPE_GenerateMusicList();
		}
		return NFMDLCBJOIB_SongCacheList;
	}

	// // RVA: 0xA170FC Offset: 0xA170FC VA: 0xA170FC
	public void BEFJOAGGAJD_ResetSongListCache()
	{
		NFMDLCBJOIB_SongCacheList.Clear();
	}

	// // RVA: 0xA17174 Offset: 0xA17174 VA: 0xA17174 Slot: 7
	public override List<int> HEACCHAKMFG_GetMusicsList()
	{
		List<int> res = new List<int>();
		res.Clear();
		BEFJOAGGAJD_ResetSongListCache();
		List<LNELCMNJPIC_EventGoDiva.HGLNJDGOPMM> l = KOBMFPACBMB_GetCachedSongList();
		if(l != null)
		{
			for(int i = 0; i < l.Count; i++)
			{
				res.Add(l[i].MPLGPBNJDJB_FreeMusicId);
			}
		}
		return res;
	}

	// // RVA: 0xA172F4 Offset: 0xA172F4 VA: 0xA172F4 Slot: 9
	public override long HOOBCIIOCJD_GetSongEndTime(int _GHBPLHBNMBK_FreeMusicId)
	{
		List<LNELCMNJPIC_EventGoDiva.HGLNJDGOPMM> l = KOBMFPACBMB_GetCachedSongList();
		if(l != null)
		{
			long t = NKGJPJPHLIF.HHCJCDFCLOB.IBLPICFDGOF_ServerRequester.FJDBNGEPKHL_Time.KMEFBNBFJHI_GetServerTime();
			for(int i = 0; i < l.Count; i++)
			{
				if(l[i].PDBPFJJCADD_open_at != 0 && l[i].FDBNFFNFOND_close_at != 0 && t >= l[i].PDBPFJJCADD_open_at && l[i].FDBNFFNFOND_close_at >= t && 
					_GHBPLHBNMBK_FreeMusicId == l[i].MPLGPBNJDJB_FreeMusicId)
				{
					return l[i].FDBNFFNFOND_close_at;
				}
			}
		}
		return base.HOOBCIIOCJD_GetSongEndTime(_GHBPLHBNMBK_FreeMusicId);
	}

	// // RVA: 0xA17624 Offset: 0xA17624 VA: 0xA17624 Slot: 10
	public override bool GIDDKGMPIOK_IsLimited(int _GHBPLHBNMBK_FreeMusicId)
	{
		List<LNELCMNJPIC_EventGoDiva.HGLNJDGOPMM> l = KOBMFPACBMB_GetCachedSongList();
		if(l != null)
		{
			long t = NKGJPJPHLIF.HHCJCDFCLOB.IBLPICFDGOF_ServerRequester.FJDBNGEPKHL_Time.KMEFBNBFJHI_GetServerTime();
			for(int i = 0; i < l.Count; i++)
			{
				if(l[i].PDBPFJJCADD_open_at != 0 && l[i].FDBNFFNFOND_close_at != 0 && l[i].FDBNFFNFOND_close_at < DPJCPDKALGI_RankingEnd && t >= l[i].PDBPFJJCADD_open_at && l[i].FDBNFFNFOND_close_at >= t && 
					_GHBPLHBNMBK_FreeMusicId == l[i].MPLGPBNJDJB_FreeMusicId)
				{
					return true;
				}
			}
		}
		return false;
	}

	// // RVA: 0xA17974 Offset: 0xA17974 VA: 0xA17974 // not virtual & not called directly
	/*public int OMJHBJPCFFC_GetEventBonusPercent(int _EHDDADDKMFI_f_id)
	{
		TodoLogger.LogError(TodoLogger.EventGoDiva_14, "OMJHBJPCFFC_GetEventBonusPercent");
		return 0;
	}*/

	// // RVA: 0xA17C88 Offset: 0xA17C88 VA: 0xA17C88 Slot: 27
	public override int HLOGNJNGDJO_GetHelpId(int _OIPCCBHIKIA_index/* = 0*/)
	{
		LNELCMNJPIC_EventGoDiva ev = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.LBDOLHGDIEB_Find(JOPOPMLFINI_QuestName) as LNELCMNJPIC_EventGoDiva;
		if(ev != null)
		{
			return ev.NGHKJOEDLIP_Settings.EJBGHLOOLBC_HelpIds[_OIPCCBHIKIA_index];
		}
		return 0;
	}

	// // RVA: 0xA17E44 Offset: 0xA17E44 VA: 0xA17E44 Slot: 67
	// public override int LBNKDKDMMOK() { }

	// // RVA: 0xA17FC8 Offset: 0xA17FC8 VA: 0xA17FC8 Slot: 28
	public override long FBGDBGKNKOD_GetCurrentPoint()
	{
		LNELCMNJPIC_EventGoDiva ev = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.LBDOLHGDIEB_Find(JOPOPMLFINI_QuestName) as LNELCMNJPIC_EventGoDiva;
		if(ev != null)
		{
			CCBMJNPFPBB_EventGoDiva.KIJJHJHLBAK saveEv = CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_PlayerData.JMPNGBGNCFO_EventGoDiva.FBCJICEPLED[ev.NGHKJOEDLIP_Settings.MOEKELIIDEO_SaveIdx];
			return saveEv.DNBFMLBNAEE_point;
		}
		return 0;
	}

	// // RVA: 0xA18234 Offset: 0xA18234 VA: 0xA18234
	public long AFCIIKDOMHN_GetCurrentScore(int _AHHJLDLAPAN_DivaId)
	{
		LNELCMNJPIC_EventGoDiva ev = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.LBDOLHGDIEB_Find(JOPOPMLFINI_QuestName) as LNELCMNJPIC_EventGoDiva;
		if(ev != null)
		{
			CCBMJNPFPBB_EventGoDiva.KIJJHJHLBAK saveEv = CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_PlayerData.JMPNGBGNCFO_EventGoDiva.FBCJICEPLED[ev.NGHKJOEDLIP_Settings.MOEKELIIDEO_SaveIdx];
			return saveEv.LGFFMGDBIAH_ranking[_AHHJLDLAPAN_DivaId - 1].NANNGLGOFKH_value;
		}
		return 0;
	}

	// // RVA: 0xA184E8 Offset: 0xA184E8 VA: 0xA184E8 Slot: 29
	public override void MJFKJHJJLMN_GetRanks(int LHJCOPMMIGO/* = 0*/, bool _FBBNPFFEJBN_Force/* = false*/)
	{
		PLOOEECNHFB_IsDone = false;
		NPNNPNAIONN_IsError = false;
		EECOJKDJIFG info = DAKMIKNKHMF_GetRankingInfoForIndex(LHJCOPMMIGO);
		if(info != null)
		{
			LNELCMNJPIC_EventGoDiva ev = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.LBDOLHGDIEB_Find(JOPOPMLFINI_QuestName) as LNELCMNJPIC_EventGoDiva;
			if(ev != null)
			{
				if(GPHEKCNDDIK)
				{
					bool doRequest = false;
					if(_FBBNPFFEJBN_Force || CDINKAANIAA_Rank[LHJCOPMMIGO] < 1)
					{
						doRequest = true;
					}
					else
					{
						long t = NKGJPJPHLIF.HHCJCDFCLOB.IBLPICFDGOF_ServerRequester.FJDBNGEPKHL_Time.KMEFBNBFJHI_GetServerTime();
						int get_rank_cooling_time = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.GDEKCOOBLMA_System.LPJLEHAJADA_GetIntParam("get_rank_cooling_time", 60);
						if(t - KPOMHFLKMKI_LastRankUpdateTime[LHJCOPMMIGO] >= get_rank_cooling_time)
						{
							doRequest = true;
						}
						else
						{
							PLOOEECNHFB_IsDone = true;
							return;
						}
					}
					if(doRequest)
					{
						//LAB_00a188e8
						KKLGENJKEBN.HHCJCDFCLOB.HEOKADCEAGL_GetRanks(info.OCGFKMHNEOF_name_for_api, () =>
						{
							//0xA28D9C
							CDINKAANIAA_Rank[LHJCOPMMIGO] = (int)KKLGENJKEBN.HHCJCDFCLOB.LPPCNCMEDFA_Rank;
							KPOMHFLKMKI_LastRankUpdateTime[LHJCOPMMIGO] = NKGJPJPHLIF.HHCJCDFCLOB.IBLPICFDGOF_ServerRequester.FJDBNGEPKHL_Time.KMEFBNBFJHI_GetServerTime();
							PLOOEECNHFB_IsDone = true;
						}, () =>
						{
							//0xA28F60
							KPOMHFLKMKI_LastRankUpdateTime[LHJCOPMMIGO] = NKGJPJPHLIF.HHCJCDFCLOB.IBLPICFDGOF_ServerRequester.FJDBNGEPKHL_Time.KMEFBNBFJHI_GetServerTime();
							CDINKAANIAA_Rank[LHJCOPMMIGO] = 0;
							PLOOEECNHFB_IsDone = true;
						}, () =>
						{
							CDINKAANIAA_Rank[LHJCOPMMIGO] = 0;
							PLOOEECNHFB_IsDone = true;
							NPNNPNAIONN_IsError = true;
							//0xA29108
						}, () =>
						{
							CDINKAANIAA_Rank[LHJCOPMMIGO] = 0;
							PLOOEECNHFB_IsDone = true;
							NPNNPNAIONN_IsError = true;
							//0xA291A0
						});
						return;
					}
				}
			}
		}
		CDINKAANIAA_Rank[LHJCOPMMIGO] = 0;
		PLOOEECNHFB_IsDone = true;
	}

	// // RVA: 0xA18A44 Offset: 0xA18A44 VA: 0xA18A44 Slot: 30
	protected override bool JIHMLILFOPG_IsEventActive(long _JHNMKKNEENE_Time)
	{
		LNELCMNJPIC_EventGoDiva ev = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.LBDOLHGDIEB_Find(JOPOPMLFINI_QuestName) as LNELCMNJPIC_EventGoDiva;
		if(ev != null)
		{
			GDIPLANPCEI g = IMMAOANGPNK.HHCJCDFCLOB.ACEFBFLFKFD_GetScheduleEventData(ev.JIKKNHIAEKG_BlockName, _JHNMKKNEENE_Time);
			if(g != null)
			{
				if(_JHNMKKNEENE_Time >= ev.NGHKJOEDLIP_Settings.BONDDBOFBND_RankingStart && ev.NGHKJOEDLIP_Settings.KNLGKBBIBOH_RewardEnd2 >= _JHNMKKNEENE_Time)
				{
					if(ev.NGHKJOEDLIP_Settings.HKKNEAGCIEB_RankingSupport != 0)
					{
						List<string> PDDFOEDNFBN = new List<string>();
						PDDFOEDNFBN.Clear();
						if(ev.NGHKJOEDLIP_Settings.MPCAGEPEJJJ_Key.Count > 0)
						{
							PDDFOEDNFBN.AddRange(ev.NGHKJOEDLIP_Settings.MPCAGEPEJJJ_Key);
						}
						for(int i = 0; i < PDDFOEDNFBN.Count; i++)
						{
							if(KKLGENJKEBN.HHCJCDFCLOB.JPDPFGFMKHK_rankings.Find((EECOJKDJIFG PKLPKMLGFGK) =>
							{
								//0xA29238
								return PKLPKMLGFGK.OCGFKMHNEOF_name_for_api == PDDFOEDNFBN[i];
							}) == null)
							{
								UnityEngine.Debug.LogError("Mising diva rankings "+PDDFOEDNFBN[i]);
								return false;
							}
						}
					}
					return true;
				}
			}
		}
		return false;
	}

	// // RVA: 0xA18F10 Offset: 0xA18F10 VA: 0xA18F10 Slot: 31
	protected override bool IMCMNOPNGHO(long _JHNMKKNEENE_Time)
	{
		LNELCMNJPIC_EventGoDiva ev = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.LBDOLHGDIEB_Find(JOPOPMLFINI_QuestName) as LNELCMNJPIC_EventGoDiva;
		if(ev != null)
		{
			CCBMJNPFPBB_EventGoDiva.KIJJHJHLBAK saveEv = CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_PlayerData.JMPNGBGNCFO_EventGoDiva.FBCJICEPLED[ev.NGHKJOEDLIP_Settings.MOEKELIIDEO_SaveIdx];
			AGLILDLEFDK_Missions = ev.NNMPGOAGEOL_quests;
			OLDFFDMPEBM_Quests = saveEv.NNMPGOAGEOL_quests;
			if(saveEv.MPCAGEPEJJJ_Key != ev.NGHKJOEDLIP_Settings.OCGFKMHNEOF_name_for_api || 
				(!RuntimeSettings.CurrentSettings.UnlimitedEvent && saveEv.EGBOHDFBAPB_closed_at < ev.NGHKJOEDLIP_Settings.BONDDBOFBND_RankingStart)
			)
			{
				saveEv.LHPDDGIJKNB_Reset();
				saveEv.MPCAGEPEJJJ_Key = ev.NGHKJOEDLIP_Settings.OCGFKMHNEOF_name_for_api;
				saveEv.EGBOHDFBAPB_closed_at = ev.NGHKJOEDLIP_Settings.IDDBFFBPNGI_RewardEnd;
				OCPAJHKFGDI();
				KOMAHOAEMEK(true);
			}
			KOMAHOAEMEK(false);
			return true;
		}
		return false;
	}

	// // RVA: 0xA19258 Offset: 0xA19258 VA: 0xA19258
	private void OCPAJHKFGDI()
	{
		CCBMJNPFPBB_EventGoDiva.KIJJHJHLBAK saveData = CLELOGKMNCE_GetEventSaveData();
		if(saveData != null)
		{
			for(int i = 0; i < saveData.FDBOPFEOENF_diva.Count; i++)
			{
				saveData.FDBOPFEOENF_diva[i].JDHJEINPJLL_so_mexp = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.OAINIGNLJKC_Diva2.OAJOMHOOCJJ(NNFJAIGDBAO(0) + 1);
				saveData.FDBOPFEOENF_diva[i].OIMLBHPAMGD_vo_mexp = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.OAINIGNLJKC_Diva2.OAJOMHOOCJJ(NNFJAIGDBAO(1) + 1);
				saveData.FDBOPFEOENF_diva[i].PFDDNKEOKBF_ch_mexp = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.OAINIGNLJKC_Diva2.OAJOMHOOCJJ(NNFJAIGDBAO(2) + 1);
			}
		}
	}

	// // RVA: 0xA19950 Offset: 0xA19950 VA: 0xA19950 Slot: 40
	protected override void KKFLDCBHFJA(long _JHNMKKNEENE_Time)
	{
		LNELCMNJPIC_EventGoDiva ev = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.LBDOLHGDIEB_Find(JOPOPMLFINI_QuestName) as LNELCMNJPIC_EventGoDiva;
		if(ev != null)
		{
			IBNKPMPFLGI_IsRankReward = ev.NGHKJOEDLIP_Settings.HKKNEAGCIEB_RankingSupport != 0;
			if(IBNKPMPFLGI_IsRankReward)
			{
				for(int i = 0; i < ev.NGHKJOEDLIP_Settings.MPCAGEPEJJJ_Key.Count; i++)
				{
					string OCGFKMHNEOF_name_for_api = ev.NGHKJOEDLIP_Settings.MPCAGEPEJJJ_Key[i];
					KBACNOCOANM_Ranking[i] = KKLGENJKEBN.HHCJCDFCLOB.JPDPFGFMKHK_rankings.Find((EECOJKDJIFG PKLPKMLGFGK) =>
					{
						//0xA29350
						return PKLPKMLGFGK.OCGFKMHNEOF_name_for_api == OCGFKMHNEOF_name_for_api;
					});
				}
				GPHEKCNDDIK = true;
			}
			DGCOMDILAKM_EventName = ev.NGHKJOEDLIP_Settings.OPFGFINHFCE_name;
			DOLJEDAAKNN_RankingName = ev.NGHKJOEDLIP_Settings.HEDAGCNPHGD_RankingName;
			GLIMIGNNGGB_RankingStart = ev.NGHKJOEDLIP_Settings.BONDDBOFBND_RankingStart;
			DPJCPDKALGI_RankingEnd = ev.NGHKJOEDLIP_Settings.HPNOGLIFJOP_RankingEnd;
			LOLAANGCGDO_RankingEnd2 = ev.NGHKJOEDLIP_Settings.LNFKGHNHJKE_RankingEnd2;
			JDDFILGNGFH_RewardStart = ev.NGHKJOEDLIP_Settings.JGMDAOACOJF_RewardStart;
			LJOHLEGGGMC_RewardEnd = ev.NGHKJOEDLIP_Settings.IDDBFFBPNGI_RewardEnd;
			EMEKFFHCHMH_RewardEnd2 = ev.NGHKJOEDLIP_Settings.KNLGKBBIBOH_RewardEnd2;
			PGIIDPEGGPI_EventId = ev.NGHKJOEDLIP_Settings.OBGBAOLONDD_UniqueId;
			NHGPCLGPEHH_TicketType = ev.NGHKJOEDLIP_Settings.MJBKGOJBPAD_item_type;
			FBHONHONKGD_MusicSelectDesc = ev.NGHKJOEDLIP_Settings.FEMMDNIELFC_Desc;
			HGLAFGHHFKP = ev.NGHKJOEDLIP_Settings.JHPCPNJJHLI_RankingThreshold;
			GFIBLLLHMPD_StartAdventureId = ev.NGHKJOEDLIP_Settings.HIOOGLEJBKM_StartAdventureId;
			CAKEOPLJDAF_EndAdventureId = ev.NGHKJOEDLIP_Settings.FJCADCDNPMP_EndAdventureId;
			LHAKGDAGEMM_EpBonusInfos.Clear();
			for(int i = 0; i < ev.LHAKGDAGEMM_EpBonusInfos.Count; i++)
			{
				CEGDBNNIDIG d = new CEGDBNNIDIG();
				d.KELFCMEOPPM_EpisodeId = ev.LHAKGDAGEMM_EpBonusInfos[i].KHPHAAMGMJP_EpId;
				d.MIHNKIHNBBL_BaseBonus = ev.LHAKGDAGEMM_EpBonusInfos[i].OFIAENKCJME_BaseBonus / 100.0f;
				d.MLLPMJFOKEC_GachaIds.AddRange(ev.LHAKGDAGEMM_EpBonusInfos[i].KDNMBOBEGJM_GachaIds);
				LHAKGDAGEMM_EpBonusInfos.Add(d);
			}
			PGDAMNENGDA_EpBonusBySceneRarity.Clear();
			for(int i = 0; i < ev.OGMHMAGDNAM_EpBonusBySceneRarity.Count; i++)
			{
				NJJDBBCHBNP d = new NJJDBBCHBNP();
				d.GJEADBKFAPA = ev.OGMHMAGDNAM_EpBonusBySceneRarity[i].PPFNGGCBJKC_id;
				d.IJKFFIKGLJM_BonusBefore = ev.OGMHMAGDNAM_EpBonusBySceneRarity[i].GNFBMCGMCFO_BonusBefore;
				d.DCBMFNOIENM_BonusAfter = ev.OGMHMAGDNAM_EpBonusBySceneRarity[i].BFFGFAMJAIG_BonusAfter;
				PGDAMNENGDA_EpBonusBySceneRarity.Add(d);
			}
			DHOMAEOEFMJ_EpBonuByScene.Clear();
			for(int i = 0; i < ev.GEGAEDDGNMA_Bonuses.Count; i++)
			{
				MEBJJBHPMEO d = new MEBJJBHPMEO();
				d.PPFNGGCBJKC_id = ev.GEGAEDDGNMA_Bonuses[i].PPFNGGCBJKC_id;
				d.GNFBMCGMCFO_BonusBefore = ev.GEGAEDDGNMA_Bonuses[i].GNFBMCGMCFO_BonusBefore;
				d.BFFGFAMJAIG_BonusAfter = ev.GEGAEDDGNMA_Bonuses[i].BFFGFAMJAIG_BonusAfter;
				d.CNKFPJCGNFE_SceneId = ev.GEGAEDDGNMA_Bonuses[i].CNKFPJCGNFE_SceneId;
				DHOMAEOEFMJ_EpBonuByScene.Add(d);
			}
			MBHDIJJEOFL = ev.MBHDIJJEOFL;
			for(int i = 0; i < KPOMHFLKMKI_LastRankUpdateTime.Length; i++)
			{
				KPOMHFLKMKI_LastRankUpdateTime[i] = 0;
			}
			if(!string.IsNullOrEmpty(ev.NGHKJOEDLIP_Settings.OMCAOJJGOGG_Lb))
			{
				string[] strs = ev.NGHKJOEDLIP_Settings.OMCAOJJGOGG_Lb.Split(new char[]{ ',' });
				BHABCGJCGNO = new MFDJIFIIPJD();
				BHABCGJCGNO.KHEKNNFCAOI_Init(int.Parse(strs[0]), int.Parse(strs[1]));
			}
			MNDFBBMNJGN_IsUsingTicket = false;
			PJLNJJIBFBN_HasExtremeDiff = ev.NGHKJOEDLIP_Settings.AHKPNPNOAMO_ExtreamOpen != 0;
			ABBOEIPOBLJ_EventTicket.CBDACMFFHJC c = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.KHPOJKHKLEM_EventTicket.CDENCMNHNGA_table.Find((ABBOEIPOBLJ_EventTicket.CBDACMFFHJC _GHPLINIACBB_x) =>
			{
				//0xA292F4
				return _GHPLINIACBB_x.INDDJNMPONH_type == ev.NGHKJOEDLIP_Settings.MJBKGOJBPAD_item_type;
			});
			if(c == null)
				return;
			JKIADEKHGLC_TicketItemId = EKLNMHFCAOI.GJEEGMCBGGM_GetItemFullId(EKLNMHFCAOI.FKGCBLHOOCL_Category.CLMIJKACELE_EventTicket, c.PPFNGGCBJKC_id);
			LEPALMDKEOK_IsPointReward = true;
		}
	}

	// // RVA: 0xA1AB8C Offset: 0xA1AB8C VA: 0xA1AB8C Slot: 41
	public override int DBOLCELMBJG_GetMainRankingIndex()
	{
		return BAEPGOAMBDK("main_ranking_index", 0);
	}

	// // RVA: 0xA1AC00 Offset: 0xA1AC00 VA: 0xA1AC00 Slot: 42
	public override int DEECKJADNMJ(int _LAJNCHHNLBI_n)
	{
		if(BAEPGOAMBDK("main_ranking_index", 0) != 0)
			return _LAJNCHHNLBI_n == 0 ? 1 : 0;
		return _LAJNCHHNLBI_n;
	}

	// // RVA: 0xA1AC98 Offset: 0xA1AC98 VA: 0xA1AC98 Slot: 43
	protected override void FCHGHAAPIBH()
	{
		LNELCMNJPIC_EventGoDiva NDFIEMPPMLF_master = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.LBDOLHGDIEB_Find(JOPOPMLFINI_QuestName) as LNELCMNJPIC_EventGoDiva;
		if(NDFIEMPPMLF_master != null)
		{
			Dictionary<string,int> DBEKEBNDMBH_SaveIdx = new Dictionary<string,int>();
			List<string> ls = new List<string>();
			string str0 = NDFIEMPPMLF_master.NGHKJOEDLIP_Settings.OCDMGOGMHGE_KeyPrefix;
			for(int i = 0; i < NDFIEMPPMLF_master.FCIPEDFHFEM_TotalRewards.Count; i++)
			{
				for(int j = 0; j < NDFIEMPPMLF_master.FCIPEDFHFEM_TotalRewards[i].AHJNPEAMCCH_rewards.Count; j++)
				{
					if(NDFIEMPPMLF_master.FCIPEDFHFEM_TotalRewards[i].AHJNPEAMCCH_rewards[j].NMKEOMCMIPP_RewardId > 0)
					{
						string s = str0 + NDFIEMPPMLF_master.FCIPEDFHFEM_TotalRewards[i].AHJNPEAMCCH_rewards[j].NMKEOMCMIPP_RewardId.ToString();
						ls.Add(s);
						DBEKEBNDMBH_SaveIdx.Add(s, i);
					}
				}
			}
			if(ls.Count == 0)
			{
				PIMFJALCIGK();
				PLOOEECNHFB_IsDone = true;
			}
			else
			{
				JGMEFHJCNHP_GetAchievementRecords req = NKGJPJPHLIF.HHCJCDFCLOB.IBLPICFDGOF_ServerRequester.IFFNCAFNEAG_AddRequest(new JGMEFHJCNHP_GetAchievementRecords());
				req.KMOBDLBKAAA_Repeatable = true;
				req.MIDAMHNABAJ_Keys = ls;
				req.BHFHGFKBOHH_OnSuccess = (CACGCMBKHDI_Request NHECPMNKEFK) =>
				{
					//0xA29384
					JGMEFHJCNHP_GetAchievementRecords r = NHECPMNKEFK as JGMEFHJCNHP_GetAchievementRecords;
					CCBMJNPFPBB_EventGoDiva.KIJJHJHLBAK saveEv = CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_PlayerData.JMPNGBGNCFO_EventGoDiva.FBCJICEPLED[NDFIEMPPMLF_master.NGHKJOEDLIP_Settings.MOEKELIIDEO_SaveIdx];
					for(int i = 0; i < r.NFEAMMJIMPG_Result.CEDLLCCONJP_achievement_prizes.Count; i++)
					{
						if(DBEKEBNDMBH_SaveIdx.ContainsKey(r.NFEAMMJIMPG_Result.CEDLLCCONJP_achievement_prizes[i].LJNAKDMILMC_key))
						{
							if(r.NFEAMMJIMPG_Result.CEDLLCCONJP_achievement_prizes[i].OOIJCMLEAJP_is_received)
							{
								saveEv.LCDIGDMGPGO_TRcv[DBEKEBNDMBH_SaveIdx[r.NFEAMMJIMPG_Result.CEDLLCCONJP_achievement_prizes[i].LJNAKDMILMC_key]] = 1;
							}
						}
					}
					PIMFJALCIGK();
					PLOOEECNHFB_IsDone = true;
				};
				req.MOBEEPPKFLG_OnFail = (CACGCMBKHDI_Request NHECPMNKEFK) =>
				{
					//0xA2983C
					PLOOEECNHFB_IsDone = true;
					NPNNPNAIONN_IsError = true;
				};
			}
		}
		else
		{
			PLOOEECNHFB_IsDone = true;
		}
	}

	// [IteratorStateMachineAttribute] // RVA: 0x6BC734 Offset: 0x6BC734 VA: 0x6BC734
	// // RVA: 0xA1B354 Offset: 0xA1B354 VA: 0xA1B354 Slot: 44
	protected override IEnumerator JEIJKLPOAHP_ReceivePrologueRepeatedAchievement(DJBHIFLHJLK _AOCANKOMKFG_OnError)
	{
		//0xA2BEC8
		KGBCKPKLKHM_RewardItems.Clear();
		LNELCMNJPIC_EventGoDiva ev = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.LBDOLHGDIEB_Find(JOPOPMLFINI_QuestName) as LNELCMNJPIC_EventGoDiva;
		if(ev != null)
		{
			string event_prologue_achv_key = ev.EFEGBHACJAL_GetStringParam("event_prologue_achv_key", "");
			if(!string.IsNullOrEmpty(event_prologue_achv_key))
			{
				List<string> ls = new List<string>();
				ls.Add(event_prologue_achv_key);
				yield return Co.R(AOGIMHOLIFB_ReceiveLoguinRepetedAchivement(ls, _AOCANKOMKFG_OnError));
			}
		}
	}

	// [IteratorStateMachineAttribute] // RVA: 0x6BC7AC Offset: 0x6BC7AC VA: 0x6BC7AC
	// // RVA: 0xA1B41C Offset: 0xA1B41C VA: 0xA1B41C Slot: 45
	protected override IEnumerator KPBNMAEHHDF_ReceiveEpilogueRepeatedAchivement(DJBHIFLHJLK _AOCANKOMKFG_OnError)
	{
		//0xA2BB98
		KGBCKPKLKHM_RewardItems.Clear();
		LNELCMNJPIC_EventGoDiva ev = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.LBDOLHGDIEB_Find(JOPOPMLFINI_QuestName) as LNELCMNJPIC_EventGoDiva;
		if(ev != null)
		{
			string event_epilogue_achv_key = ev.EFEGBHACJAL_GetStringParam("event_epilogue_achv_key", "");
			if(!string.IsNullOrEmpty(event_epilogue_achv_key))
			{
				List<string> ls = new List<string>();
				ls.Add(event_epilogue_achv_key);
				yield return Co.R(AOGIMHOLIFB_ReceiveLoguinRepetedAchivement(ls, _AOCANKOMKFG_OnError));
			}
		}
	}

	// // RVA: 0xA1B4E4 Offset: 0xA1B4E4 VA: 0xA1B4E4 Slot: 46
	protected override void PJDGDNJNCNM_UpdateStatusImpl(long _JHNMKKNEENE_Time)
	{
		KIBBLLADDPO = false;
		NGOFCFJHOMI_Status = KGCNCBOKCBA.GNENJEHKMHD_EventStatus.HJNNKCMLGFL_0_None;
		LNELCMNJPIC_EventGoDiva ev = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.LBDOLHGDIEB_Find(JOPOPMLFINI_QuestName) as LNELCMNJPIC_EventGoDiva;
		if(ev != null)
		{
			CCBMJNPFPBB_EventGoDiva.KIJJHJHLBAK saveEv = CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_PlayerData.JMPNGBGNCFO_EventGoDiva.FBCJICEPLED[ev.NGHKJOEDLIP_Settings.MOEKELIIDEO_SaveIdx];
			IBLPKJJNNIG = false;
			BELBNINIOIE = false;
			if(_JHNMKKNEENE_Time >= GLIMIGNNGGB_RankingStart)
			{
				if(DPJCPDKALGI_RankingEnd >= _JHNMKKNEENE_Time)
				{
					if(MBHDIJJEOFL != null)
					{
						for(int i = 0; i < MBHDIJJEOFL.Count; i++)
						{
							if(MBHDIJJEOFL[i].MAFAIIHJAFG_spurt == 0)
							{
								IBLPKJJNNIG = true;
								break;
							}
						}
					}
					//LAB_00a1b848
					if(!saveEv.IMFBCJOIJKJ_Entry)
					{
						NGOFCFJHOMI_Status = KGCNCBOKCBA.GNENJEHKMHD_EventStatus.NCJFJLPJMLI_2;
						if(_JHNMKKNEENE_Time < ev.NGHKJOEDLIP_Settings.EHHFFKAFOMC)
						{
							return;
						}
						KIBBLLADDPO = true;
						if(MBHDIJJEOFL != null)
						{
							for(int i = 0; i < MBHDIJJEOFL.Count; i++)
							{
								if(MBHDIJJEOFL[i].MAFAIIHJAFG_spurt == 1)
								{
									BELBNINIOIE = true;
									break;
								}
							}
						}
						return;
					}
					if(saveEv.ABBJBPLHFHA_Spurt)
					{
						NGOFCFJHOMI_Status = KGCNCBOKCBA.GNENJEHKMHD_EventStatus.MEAJLPAHINL_ChallengePeriod_5;
						if(MBHDIJJEOFL != null)
						{
							for(int i = 0; i < MBHDIJJEOFL.Count; i++)
							{
								if(MBHDIJJEOFL[i].MAFAIIHJAFG_spurt == 1)
								{
									BELBNINIOIE = true;
									break;
								}
							}
						}
						return;
					}
					if(_JHNMKKNEENE_Time >= ev.NGHKJOEDLIP_Settings.EHHFFKAFOMC)
					{
						NGOFCFJHOMI_Status = KGCNCBOKCBA.GNENJEHKMHD_EventStatus.GDOPLACICFE_4;
						KIBBLLADDPO = true;
						if(MBHDIJJEOFL != null)
						{
							for(int i = 0; i < MBHDIJJEOFL.Count; i++)
							{
								if(MBHDIJJEOFL[i].MAFAIIHJAFG_spurt == 1)
								{
									BELBNINIOIE = true;
									break;
								}
							}
						}
						return;
					}
					NGOFCFJHOMI_Status = KGCNCBOKCBA.GNENJEHKMHD_EventStatus.MINDIGBAJFG_3;
				}
				else if(_JHNMKKNEENE_Time < ev.NGHKJOEDLIP_Settings.JGMDAOACOJF_RewardStart)
				{
					NGOFCFJHOMI_Status = KGCNCBOKCBA.GNENJEHKMHD_EventStatus.EMAMLLFAOJI_6_Counting;
				}
				else if(_JHNMKKNEENE_Time < ev.NGHKJOEDLIP_Settings.IDDBFFBPNGI_RewardEnd)
				{
					bool b = false;
					for(int i = 0; i < 10; i++)
					{
						b |= !saveEv.DGOAGKOKCIJ_IsRewardReceived(i);
					}
					if(!b)
						NGOFCFJHOMI_Status = KGCNCBOKCBA.GNENJEHKMHD_EventStatus.BCKENOKGLIJ_9_ResultRewardreceived;
					else
						NGOFCFJHOMI_Status = KGCNCBOKCBA.GNENJEHKMHD_EventStatus.DDEODFNANDO_8_ResultRewardToReceive;
				}
				else if(_JHNMKKNEENE_Time < ev.NGHKJOEDLIP_Settings.KNLGKBBIBOH_RewardEnd2)
				{
					NGOFCFJHOMI_Status = KGCNCBOKCBA.GNENJEHKMHD_EventStatus.HINPDNKNAHO_10;
				}
				else
				{
					NGOFCFJHOMI_Status = KGCNCBOKCBA.GNENJEHKMHD_EventStatus.DOAENCHBAEO_11;
				}
			}
			else
			{
				NGOFCFJHOMI_Status = KGCNCBOKCBA.GNENJEHKMHD_EventStatus.FFLKPBPBPEP_1;
			}
		}
	}

	// // RVA: 0xA1BB4C Offset: 0xA1BB4C VA: 0xA1BB4C Slot: 48
	public override void AMKJFGLEJGE_RequestUpdateEventPoint(int LHJCOPMMIGO)
	{
		EECOJKDJIFG e = DAKMIKNKHMF_GetRankingInfoForIndex(LHJCOPMMIGO);
		if(e != null)
		{
			LNELCMNJPIC_EventGoDiva ev = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.LBDOLHGDIEB_Find(JOPOPMLFINI_QuestName) as LNELCMNJPIC_EventGoDiva;
			if(ev != null)
			{
				CCBMJNPFPBB_EventGoDiva.KIJJHJHLBAK saveEv = CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_PlayerData.JMPNGBGNCFO_EventGoDiva.FBCJICEPLED[ev.NGHKJOEDLIP_Settings.MOEKELIIDEO_SaveIdx];
				MIDMMFMJFPJ l = saveEv.LGFFMGDBIAH_ranking[LHJCOPMMIGO];
				PJDGDNJNCNM_UpdateStatusImpl(NKGJPJPHLIF.HHCJCDFCLOB.IBLPICFDGOF_ServerRequester.FJDBNGEPKHL_Time.KMEFBNBFJHI_GetServerTime());
				if(NGOFCFJHOMI_Status == KGCNCBOKCBA.GNENJEHKMHD_EventStatus.NCJFJLPJMLI_2 ||
					NGOFCFJHOMI_Status == KGCNCBOKCBA.GNENJEHKMHD_EventStatus.MINDIGBAJFG_3 ||
					NGOFCFJHOMI_Status == KGCNCBOKCBA.GNENJEHKMHD_EventStatus.MEAJLPAHINL_ChallengePeriod_5 ||
					NGOFCFJHOMI_Status == KGCNCBOKCBA.GNENJEHKMHD_EventStatus.EMAMLLFAOJI_6_Counting) //0x6cU
				{
					if(l.NANNGLGOFKH_value < 1)
						PLOOEECNHFB_IsDone = true;
					else
					{
						EECOJKDJIFG e2 = KKLGENJKEBN.HHCJCDFCLOB.JPDPFGFMKHK_rankings.Find((EECOJKDJIFG _GHPLINIACBB_x) =>
						{
							//0xA29880
							return _GHPLINIACBB_x.OCGFKMHNEOF_name_for_api == e.OCGFKMHNEOF_name_for_api;
						});
						if(e2 != null)
						{
							PKECIDPBEFL.DDBKLMKKCDL p = new PKECIDPBEFL.DDBKLMKKCDL();
							p.OACABIDEMGG_Score = BOAGCEOHJEO.GOAOBNBGDBJ(GLIMIGNNGGB_RankingStart, LOLAANGCGDO_RankingEnd2, saveEv.NFIOKIBPJCJ_uptime, l.NANNGLGOFKH_value);
							p.BLJIJENHBPM_Id = e2.PPFNGGCBJKC_id;
							p.OBGBAOLONDD_UniqueId = PGIIDPEGGPI_EventId;
							p.NOBCHBHEPNC_Idx = LHJCOPMMIGO;
							JGEOBNENMAH.HHCJCDFCLOB.CBGMOGIBALL.Add(p);
						}
					}
				}
			}
		}
	}

	// // RVA: 0xA1C144 Offset: 0xA1C144 VA: 0xA1C144 Slot: 49
	protected override void ODPJGHOJIOH(int LHJCOPMMIGO)
	{
        EECOJKDJIFG e = DAKMIKNKHMF_GetRankingInfoForIndex(LHJCOPMMIGO);
        PLOOEECNHFB_IsDone = false;
        if(e != null)
		{
			LNELCMNJPIC_EventGoDiva LKOLAGLKIDA = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.LBDOLHGDIEB_Find(JOPOPMLFINI_QuestName) as LNELCMNJPIC_EventGoDiva;
            if (LKOLAGLKIDA != null)
            {
				if(LKOLAGLKIDA.NGHKJOEDLIP_Settings != null)
				{
					CCBMJNPFPBB_EventGoDiva.KIJJHJHLBAK saveEv = CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_PlayerData.JMPNGBGNCFO_EventGoDiva.FBCJICEPLED[LKOLAGLKIDA.NGHKJOEDLIP_Settings.MOEKELIIDEO_SaveIdx];
                    PJDGDNJNCNM_UpdateStatusImpl(NKGJPJPHLIF.HHCJCDFCLOB.IBLPICFDGOF_ServerRequester.FJDBNGEPKHL_Time.KMEFBNBFJHI_GetServerTime());
                    if(NGOFCFJHOMI_Status > KGCNCBOKCBA.GNENJEHKMHD_EventStatus.EMAMLLFAOJI_6_Counting || (
						NGOFCFJHOMI_Status != KGCNCBOKCBA.GNENJEHKMHD_EventStatus.NCJFJLPJMLI_2 && 
						NGOFCFJHOMI_Status != KGCNCBOKCBA.GNENJEHKMHD_EventStatus.MINDIGBAJFG_3 && 
						NGOFCFJHOMI_Status != KGCNCBOKCBA.GNENJEHKMHD_EventStatus.MEAJLPAHINL_ChallengePeriod_5 && 
						NGOFCFJHOMI_Status != KGCNCBOKCBA.GNENJEHKMHD_EventStatus.EMAMLLFAOJI_6_Counting
					))
					{
						PLOOEECNHFB_IsDone = true;
						return;
					}
                    int DNBFMLBNAEE_point = saveEv.LGFFMGDBIAH_ranking[LHJCOPMMIGO].NANNGLGOFKH_value;
                    KKLGENJKEBN.HHCJCDFCLOB.LDOBHAAIDEJ_UpdateRankingScore(e.OCGFKMHNEOF_name_for_api, LHJCOPMMIGO, BOAGCEOHJEO.GOAOBNBGDBJ(GLIMIGNNGGB_RankingStart, LOLAANGCGDO_RankingEnd2, saveEv.NFIOKIBPJCJ_uptime, DNBFMLBNAEE_point), () =>
					{
                        //0xA29938
                        CDINKAANIAA_Rank[LHJCOPMMIGO] = (int)KKLGENJKEBN.HHCJCDFCLOB.LPPCNCMEDFA_Rank;
                        PLOOEECNHFB_IsDone = true;
                        ILCCJNDFFOB.HHCJCDFCLOB.NNFGBBCHLPC(PGIIDPEGGPI_EventId, "StringLiteral_10992", EJDJIBPKKNO_BasePoint, DNBFMLBNAEE_point, LKOLAGLKIDA.LPJLEHAJADA_GetIntParam("ranking_point_max", 1000000), KKLGENJKEBN.HHCJCDFCLOB.DFBALJAPHMC_DroppedPlayer);
                    }, () =>
					{
                        //0xA298CC
                        PLOOEECNHFB_IsDone = true;
                    }, () =>
					{
						//0xA298F4
						PLOOEECNHFB_IsDone = true;
                        NPNNPNAIONN_IsError = true;
                    });
                    return;
                }
            }
        }
        PLOOEECNHFB_IsDone = true;
    }

	// // RVA: 0xA1C778 Offset: 0xA1C778 VA: 0xA1C778 Slot: 50
	protected override void MFJFBNPLFBE_OnReceieveTotalReward(bool GIPBIDFJFLL)
	{
		LNELCMNJPIC_EventGoDiva ev = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.LBDOLHGDIEB_Find(JOPOPMLFINI_QuestName) as LNELCMNJPIC_EventGoDiva;
		if(ev != null)
		{
			if(CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_PlayerData.JMPNGBGNCFO_EventGoDiva.PFAKPFKJJKA() == null)
			{
				CCBMJNPFPBB_EventGoDiva.KIJJHJHLBAK saveEv = CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_PlayerData.JMPNGBGNCFO_EventGoDiva.FBCJICEPLED[ev.NGHKJOEDLIP_Settings.MOEKELIIDEO_SaveIdx];
				JANMJPOKLFL_InventoryUtil.JCHLONCMPAJ_Clear();
				JOFBHHHLBBN_Rewards.Clear();
				List<string> ls = new List<string>(3);
				List<int> li = new List<int>();
				StringBuilder str = new StringBuilder();
				long curPoint = FBGDBGKNKOD_GetCurrentPoint();
				long date = ev.NGHKJOEDLIP_Settings.JBFDHOIKAIK_InventoryEndDate;
				for(int i = 0; i < ev.FCIPEDFHFEM_TotalRewards.Count; i++)
				{
					if(curPoint >= ev.FCIPEDFHFEM_TotalRewards[i].DNBFMLBNAEE_point)
					{
						if(!saveEv.BHIAKGKHKGD_IsReceived(i))
						{
							str.Length = 0;
							str.Append(PGIIDPEGGPI_EventId);
							str.Append(':');
							str.Append(i);
							str.Append(':');
							str.Append(ev.FCIPEDFHFEM_TotalRewards[i].DNBFMLBNAEE_point);
							JANMJPOKLFL_InventoryUtil.FEGDNPIEKJC(OAGBCBBHMPF.COIIJOEKBDH.MGEFPKOJKBL_9, str.ToString());
							for(int j = 0; j < ev.FCIPEDFHFEM_TotalRewards[i].AHJNPEAMCCH_rewards.Count; j++)
							{
								if(ev.FCIPEDFHFEM_TotalRewards[i].AHJNPEAMCCH_rewards[j].NMKEOMCMIPP_RewardId > 0)
								{
									ls.Add(ev.NGHKJOEDLIP_Settings.OCDMGOGMHGE_KeyPrefix + ev.FCIPEDFHFEM_TotalRewards[i].AHJNPEAMCCH_rewards[j].NMKEOMCMIPP_RewardId.ToString());
									li.Add(ev.FCIPEDFHFEM_TotalRewards[i].AHJNPEAMCCH_rewards[j].PJPDOCNJNGJ_IsLimited ? (int)date : -1);
								}
								JANMJPOKLFL_InventoryUtil.CPIICACGNBH_AddItem(CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_PlayerData, ev.FCIPEDFHFEM_TotalRewards[i].AHJNPEAMCCH_rewards[j].GLCLFMGPMAN_ItemId, ev.FCIPEDFHFEM_TotalRewards[i].AHJNPEAMCCH_rewards[j].HMFFHLPNMPH_count, null, 0);
								saveEv.IPNLHCLFIDB_SetRewardReceived(i, true);
							}
							JOFBHHHLBBN_Rewards.Add(i);
						}
					}
				}
				if(ls.Count > 0)
				{
					if(!GIPBIDFJFLL)
					{
						FLONELKGABJ_ClaimAchievementPrizes req = NKGJPJPHLIF.HHCJCDFCLOB.IBLPICFDGOF_ServerRequester.IFFNCAFNEAG_AddRequest(new FLONELKGABJ_ClaimAchievementPrizes());
						req.KMOBDLBKAAA_Repeatable = true;
						req.MIDAMHNABAJ_Keys = ls;
						req.NBFDEFGFLPJ = OHJOJKNLHOK;
						req.MEGNAIJPBFF_InventoryClosedAt = li;
						req.BHFHGFKBOHH_OnSuccess = (CACGCMBKHDI_Request NHECPMNKEFK) =>
						{
							//0xA28D2C
							PLOOEECNHFB_IsDone = true;
							DENHAAGACPD(0);
						};
						req.MOBEEPPKFLG_OnFail = (CACGCMBKHDI_Request NHECPMNKEFK) =>
						{
							//0xA28D3C
							if(NHECPMNKEFK.CJMFJOMECKI_ErrorId == SakashoErrorId.ACHIEVEMENT_PRIZE_ALREADY_RECEIVED)
							{
								DENHAAGACPD(0);
								PLOOEECNHFB_IsDone = true;
							}
							else
							{
								PLOOEECNHFB_IsDone = true;
								NPNNPNAIONN_IsError = true;
							}
						};
						return;
					}
					PMHLJAIGBGK = ls;
					FMEDFGOMNBK = li;
				}
				DENHAAGACPD(0);
			}
			else
			{
				NPNNPNAIONN_IsError = true;
			}
		}
		PLOOEECNHFB_IsDone = true;
	}

	// // RVA: 0xA1D720 Offset: 0xA1D720 VA: 0xA1D720 Slot: 52
	public override void FAMFKPBPIAA_GetRankingPlayerList(bool PFFJNEFNAMI, int _CJHEHIMLGGL_Position, int LHJCOPMMIGO, LIOLBKLMMIK _KLMFJJCNBIP_OnSuccess, DJBHIFLHJLK _IDAEHNGOKAE_OnRankingError, DJBHIFLHJLK _JGKOLBLPMPG_OnFail)
	{
		NPNNPNAIONN_IsError = false;
		PLOOEECNHFB_IsDone = false;
		LNELCMNJPIC_EventGoDiva ev = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.LBDOLHGDIEB_Find(JOPOPMLFINI_QuestName) as LNELCMNJPIC_EventGoDiva;
		if(ev != null)
		{
			EECOJKDJIFG info = DAKMIKNKHMF_GetRankingInfoForIndex(LHJCOPMMIGO);
			if(info != null)
			{
				KKLGENJKEBN.HHCJCDFCLOB.FAMFKPBPIAA_GetRankingPlayerList(info.OCGFKMHNEOF_name_for_api, PFFJNEFNAMI, _CJHEHIMLGGL_Position, LHJCOPMMIGO, (int NEFEFHBHFFF, List<IBIGBMDANNM> MAGKKPOFJIM) =>
				{
					//0xA29BB4
					PLOOEECNHFB_IsDone = true;
					_KLMFJJCNBIP_OnSuccess(NEFEFHBHFFF, MAGKKPOFJIM);
				}, () =>
				{
					//0xA29C10
					PLOOEECNHFB_IsDone = true;
					_IDAEHNGOKAE_OnRankingError();
				}, () =>
				{
					//0xA29C5C
					PLOOEECNHFB_IsDone = true;
					NPNNPNAIONN_IsError = true;
					_JGKOLBLPMPG_OnFail();
				}, false);
				return;
			}
		}
		_IDAEHNGOKAE_OnRankingError();
		PLOOEECNHFB_IsDone = true;
	}

	// // RVA: 0xA1DA58 Offset: 0xA1DA58 VA: 0xA1DA58 Slot: 53
	public override void JPNACOLKHLB_AddRankingPlayerListSecond(int _CJHEHIMLGGL_Position, int NEFEFHBHFFF, LIOLBKLMMIK _KLMFJJCNBIP_OnSuccess, DJBHIFLHJLK _IDAEHNGOKAE_OnRankingError, DJBHIFLHJLK _JGKOLBLPMPG_OnFail)
	{
		KKLGENJKEBN.HHCJCDFCLOB.JPNACOLKHLB_AddRankingPlayerListSecond(_CJHEHIMLGGL_Position, NEFEFHBHFFF, (int _JGNBPFCJLKI_d, List<IBIGBMDANNM> MAGKKPOFJIM) =>
		{
			//0xA29CC0
			PLOOEECNHFB_IsDone = true;
			_KLMFJJCNBIP_OnSuccess(_JGNBPFCJLKI_d, MAGKKPOFJIM);
		}, () =>
		{
			//0xA29D1C
			PLOOEECNHFB_IsDone = true;
			_IDAEHNGOKAE_OnRankingError();
		}, () =>
		{
			//0xA29D68
			PLOOEECNHFB_IsDone = true;
			NPNNPNAIONN_IsError = true;
			_JGKOLBLPMPG_OnFail();
		}, false);
	}

	// // RVA: 0xA1DC14 Offset: 0xA1DC14 VA: 0xA1DC14
	// private int APJDIPINLLK(List<int> HNLFPKNBOHE, int _PPFNGGCBJKC_id) { }

	// // RVA: 0xA1B304 Offset: 0xA1B304 VA: 0xA1B304
	private void PIMFJALCIGK()
	{
		int m = NGIHFKHOJOK_GetRankingMax(true);
		if(m < 1)
			return;
		for(int i = 0; i < m; i++)
		{
			BJEOAOACMGG(i);
		}
	}

	// // RVA: 0xA1DD0C Offset: 0xA1DD0C VA: 0xA1DD0C
	private void BJEOAOACMGG(int LHJCOPMMIGO)
	{
		EECOJKDJIFG e = DAKMIKNKHMF_GetRankingInfoForIndex(LHJCOPMMIGO);
		if(e != null)
		{
			LNELCMNJPIC_EventGoDiva ev = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.LBDOLHGDIEB_Find(JOPOPMLFINI_QuestName) as LNELCMNJPIC_EventGoDiva;
			if(ev != null)
			{
				CCBMJNPFPBB_EventGoDiva.KIJJHJHLBAK saveEv = CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_PlayerData.JMPNGBGNCFO_EventGoDiva.FBCJICEPLED[ev.NGHKJOEDLIP_Settings.MOEKELIIDEO_SaveIdx];
				PFPJHJJAGAG_Rewards.Clear();
				EGIPGHCDMII_RankData[LHJCOPMMIGO].Clear();
				for(int i = 0; i < e.AHJNPEAMCCH_rewards.Count; i++)
				{
					MAOCCKFAOPC m = new MAOCCKFAOPC();
					m.JBDGBPAAAEF_HighRank = e.AHJNPEAMCCH_rewards[i].JPHDGGNAKMO_high_rank;
					m.GHANKNIBALB_LowRank = e.AHJNPEAMCCH_rewards[i].FGCAJEAIABA_low_rank;
					m.MJGAMDBOMHD_InventoryMessage = e.AHJNPEAMCCH_rewards[i].IPFEKNMBEBI_inventory_message;
					m.HBHMAKNGKFK_items = e.AHJNPEAMCCH_rewards[i].HBHMAKNGKFK_items;
					EGIPGHCDMII_RankData[LHJCOPMMIGO].Add(m);
				}
				for(int i = 0; i < ev.FCIPEDFHFEM_TotalRewards.Count; i++)
				{
					IHAEIOAKEMG d = new IHAEIOAKEMG();
					for(int j = 0; j < ev.FCIPEDFHFEM_TotalRewards[i].AHJNPEAMCCH_rewards.Count; j++)
					{
						MFDJIFIIPJD m = new MFDJIFIIPJD();
						m.KHEKNNFCAOI_Init(ev.FCIPEDFHFEM_TotalRewards[i].AHJNPEAMCCH_rewards[j].GLCLFMGPMAN_ItemId, ev.FCIPEDFHFEM_TotalRewards[i].AHJNPEAMCCH_rewards[j].HMFFHLPNMPH_count);
						m.JOPPFEHKNFO_Pickup = ev.FCIPEDFHFEM_TotalRewards[i].JOPPFEHKNFO_Pickup;
						d.HBHMAKNGKFK_items.Add(m);
					}
					d.HMEOAKCLKJE_IsReceived = saveEv.BHIAKGKHKGD_IsReceived(i);
					d.FIOIKMOIJGK_Point = ev.FCIPEDFHFEM_TotalRewards[i].DNBFMLBNAEE_point;
					d.OJELCGDDAOM_MissingPoint = Mathf.Max(d.FIOIKMOIJGK_Point - saveEv.DNBFMLBNAEE_point, 0);
					PFPJHJJAGAG_Rewards.Add(d);
				}
			}
		}
	}

	// // RVA: 0xA1D3D0 Offset: 0xA1D3D0 VA: 0xA1D3D0
	private void DENHAAGACPD(int LHJCOPMMIGO)
	{
		EECOJKDJIFG e = DAKMIKNKHMF_GetRankingInfoForIndex(LHJCOPMMIGO);
		if(e != null)
		{
			LNELCMNJPIC_EventGoDiva ev = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.LBDOLHGDIEB_Find(JOPOPMLFINI_QuestName) as LNELCMNJPIC_EventGoDiva;
			if(ev != null)
			{
				CCBMJNPFPBB_EventGoDiva.KIJJHJHLBAK saveEv = CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_PlayerData.JMPNGBGNCFO_EventGoDiva.FBCJICEPLED[ev.NGHKJOEDLIP_Settings.MOEKELIIDEO_SaveIdx];
				for(int i = 0; i < PFPJHJJAGAG_Rewards.Count; i++)
				{
					PFPJHJJAGAG_Rewards[i].HMEOAKCLKJE_IsReceived = saveEv.BHIAKGKHKGD_IsReceived(i);
					PFPJHJJAGAG_Rewards[i].OJELCGDDAOM_MissingPoint = Mathf.Max(PFPJHJJAGAG_Rewards[i].FIOIKMOIJGK_Point - saveEv.DNBFMLBNAEE_point, 0);
				}
			}
		}
	}

	// // RVA: 0xA1E5FC Offset: 0xA1E5FC VA: 0xA1E5FC Slot: 51
	public override IHAEIOAKEMG ILICNKILFKJ_GetNextReward()
	{
		for(int i = 0; i < PFPJHJJAGAG_Rewards.Count; i++)
		{
			if(!PFPJHJJAGAG_Rewards[i].HMEOAKCLKJE_IsReceived)
			{
				return PFPJHJJAGAG_Rewards[i];
			}
		}
		return null;
	}

	// // RVA: 0xA1E710 Offset: 0xA1E710 VA: 0xA1E710
	public int ALNBFHJBGIG_GetDivaExpBonusRate()
	{
		LNELCMNJPIC_EventGoDiva ev = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.LBDOLHGDIEB_Find(JOPOPMLFINI_QuestName) as LNELCMNJPIC_EventGoDiva;
		if(ev != null)
		{
			return ev.LPJLEHAJADA_GetIntParam("diva_exp_bonus_rate", 100);
		}
		return 100;
	}

	// // RVA: 0xA1E894 Offset: 0xA1E894 VA: 0xA1E894
	public long KBKGHDFBHAP_GetBonusEndTime(long _JHNMKKNEENE_Time)
	{
		LNELCMNJPIC_EventGoDiva ev = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.LBDOLHGDIEB_Find(JOPOPMLFINI_QuestName) as LNELCMNJPIC_EventGoDiva;
		if(ev != null)
		{
			CCBMJNPFPBB_EventGoDiva.KIJJHJHLBAK saveEv = CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_PlayerData.JMPNGBGNCFO_EventGoDiva.FBCJICEPLED[ev.NGHKJOEDLIP_Settings.MOEKELIIDEO_SaveIdx];
			int fever_ticket_time = ev.LPJLEHAJADA_GetIntParam("fever_ticket_time", 60);
			if(_JHNMKKNEENE_Time < saveEv.CNJCFCNLAMO_usetime + fever_ticket_time * 60)
			{
				return saveEv.CNJCFCNLAMO_usetime + fever_ticket_time * 60;
			}
			for(int i = 0; i < ev.BGHBALGJNFF.Count; i++)
			{
				if(ev.BGHBALGJNFF[i].PLALNIIBLOF_en == 2)
				{
					if(ev.BGHBALGJNFF[i].BEBJKJKBOGH_date < 1)
					{
                        DateTime dt = Utility.GetLocalDateTime(_JHNMKKNEENE_Time);
						TimeSpan ts = new TimeSpan(dt.Hour, dt.Minute, dt.Second);
						if((long)ts.TotalSeconds >= ev.BGHBALGJNFF[i].FNEIADJMHHO_st)
						{
							if((long)ts.TotalSeconds < ev.BGHBALGJNFF[i].EICJBAEDMNM_end)
							{
								return _JHNMKKNEENE_Time - (long)ts.TotalSeconds + ev.BGHBALGJNFF[i].EICJBAEDMNM_end;
							}
						}
                    }
				}
				else
				{
					if(_JHNMKKNEENE_Time >= ev.BGHBALGJNFF[i].FNEIADJMHHO_st + ev.BGHBALGJNFF[i].BEBJKJKBOGH_date)
					{
						if(_JHNMKKNEENE_Time < ev.BGHBALGJNFF[i].EICJBAEDMNM_end + ev.BGHBALGJNFF[i].BEBJKJKBOGH_date)
						{
							return ev.BGHBALGJNFF[i].EICJBAEDMNM_end + ev.BGHBALGJNFF[i].BEBJKJKBOGH_date;
						}
					}
				}
			}
		}
		return 0;
	}

	// // RVA: 0xA1EE70 Offset: 0xA1EE70 VA: 0xA1EE70
	public int GNDOGPBIGIL_GetCurrentBonusRate(long _JHNMKKNEENE_Time)
	{
		LNELCMNJPIC_EventGoDiva ev = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.LBDOLHGDIEB_Find(JOPOPMLFINI_QuestName) as LNELCMNJPIC_EventGoDiva;
		if(ev != null)
		{
			CCBMJNPFPBB_EventGoDiva.KIJJHJHLBAK saveEv = CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_PlayerData.JMPNGBGNCFO_EventGoDiva.FBCJICEPLED[ev.NGHKJOEDLIP_Settings.MOEKELIIDEO_SaveIdx];
			int fever_ticket_time = ev.LPJLEHAJADA_GetIntParam("fever_ticket_time", 60);
			if(_JHNMKKNEENE_Time >= saveEv.CNJCFCNLAMO_usetime + fever_ticket_time * 60)
			{
				for(int i = 0; i < ev.BGHBALGJNFF.Count; i++)
				{
					if(ev.BGHBALGJNFF[i].PLALNIIBLOF_en == 2)
					{
						if(ev.BGHBALGJNFF[i].BEBJKJKBOGH_date < 1)
						{
							DateTime dt = Utility.GetLocalDateTime(_JHNMKKNEENE_Time);
							TimeSpan ts = new TimeSpan(dt.Hour, dt.Minute, dt.Second);
							if((long)ts.TotalSeconds >= ev.BGHBALGJNFF[i].FNEIADJMHHO_st)
							{
								if((long)ts.TotalSeconds < ev.BGHBALGJNFF[i].EICJBAEDMNM_end)
								{
									return ev.BGHBALGJNFF[i].JBGEEPFKIGG_val;
								}
							}
						}
					}
					else
					{
						if(_JHNMKKNEENE_Time >= ev.BGHBALGJNFF[i].FNEIADJMHHO_st + ev.BGHBALGJNFF[i].BEBJKJKBOGH_date)
						{
							if(_JHNMKKNEENE_Time < ev.BGHBALGJNFF[i].EICJBAEDMNM_end + ev.BGHBALGJNFF[i].BEBJKJKBOGH_date)
							{
								return ev.BGHBALGJNFF[i].JBGEEPFKIGG_val;
							}
						}
					}
				}
				return 0;
			}
			return ev.LPJLEHAJADA_GetIntParam("fever_ticket_rate", 100);
		}
		return 0;
	}

	// // RVA: 0xA1F43C Offset: 0xA1F43C VA: 0xA1F43C
	public bool HHAGNMOIENH_UseFeverTicket(out long _PCCFAKEOBIC_EndTime)
	{
		_PCCFAKEOBIC_EndTime = 0;
		LNELCMNJPIC_EventGoDiva ev = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.LBDOLHGDIEB_Find(JOPOPMLFINI_QuestName) as LNELCMNJPIC_EventGoDiva;
		if(ev != null)
		{
			ABBOEIPOBLJ_EventTicket.CBDACMFFHJC evTkt = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.KHPOJKHKLEM_EventTicket.CDENCMNHNGA_table.Find((ABBOEIPOBLJ_EventTicket.CBDACMFFHJC _GHPLINIACBB_x) =>
			{
				//0xA29DCC
				return ev.NGHKJOEDLIP_Settings.MJBKGOJBPAD_item_type == _GHPLINIACBB_x.INDDJNMPONH_type;
			});
			if(evTkt != null)
			{
				long t = NKGJPJPHLIF.HHCJCDFCLOB.IBLPICFDGOF_ServerRequester.FJDBNGEPKHL_Time.KMEFBNBFJHI_GetServerTime();
				CCBMJNPFPBB_EventGoDiva.KIJJHJHLBAK saveEv = CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_PlayerData.JMPNGBGNCFO_EventGoDiva.FBCJICEPLED[ev.NGHKJOEDLIP_Settings.MOEKELIIDEO_SaveIdx];
				if(saveEv.HHAGNMOIENH_UseFeverTicket(1, t))
				{
					int fever_ticket_time = ev.LPJLEHAJADA_GetIntParam("fever_ticket_time", 60);
					_PCCFAKEOBIC_EndTime = t + fever_ticket_time * 60;
					ILCCJNDFFOB.HHCJCDFCLOB.HJGEAHELBPE(this, EKLNMHFCAOI.GJEEGMCBGGM_GetItemFullId(EKLNMHFCAOI.FKGCBLHOOCL_Category.CLMIJKACELE_EventTicket, evTkt.PPFNGGCBJKC_id), 1, saveEv.GJPHOIBCEFL_ItemTicketCnt);
					return true;
				}
			}
		}
		return false;
	}

	// // RVA: 0xA1FB70 Offset: 0xA1FB70 VA: 0xA1FB70
	public int CACFIGAPLDH_GetDailyUse()
	{
		LNELCMNJPIC_EventGoDiva ev = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.LBDOLHGDIEB_Find(JOPOPMLFINI_QuestName) as LNELCMNJPIC_EventGoDiva;
		if(ev != null)
		{
			CCBMJNPFPBB_EventGoDiva.KIJJHJHLBAK saveEv = CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_PlayerData.JMPNGBGNCFO_EventGoDiva.FBCJICEPLED[ev.NGHKJOEDLIP_Settings.MOEKELIIDEO_SaveIdx];
			return saveEv.NNCFCPEOODE_usecnt;
		}
		return 0;
	}

	// // RVA: 0xA1FDCC Offset: 0xA1FDCC VA: 0xA1FDCC Slot: 14
	public override void HPENJEOAMBK_SetTicket(int _JKIADEKHGLC_TicketItemId, int _HMFFHLPNMPH_count, BBHNACPENDM_ServerSaveData _AHEFHIMGIBI_PlayerData)
	{
		LNELCMNJPIC_EventGoDiva ev = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.LBDOLHGDIEB_Find(JOPOPMLFINI_QuestName) as LNELCMNJPIC_EventGoDiva;
		if(ev != null)
		{
			if(_AHEFHIMGIBI_PlayerData == null)
				_AHEFHIMGIBI_PlayerData = CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_PlayerData;
			ABBOEIPOBLJ_EventTicket.CBDACMFFHJC tkt = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.KHPOJKHKLEM_EventTicket.CDENCMNHNGA_table.Find((ABBOEIPOBLJ_EventTicket.CBDACMFFHJC _GHPLINIACBB_x) =>
			{
				//0xA29E28
				return _GHPLINIACBB_x.INDDJNMPONH_type == ev.NGHKJOEDLIP_Settings.MJBKGOJBPAD_item_type;
			});
			if(tkt != null && JKIADEKHGLC_TicketItemId == _JKIADEKHGLC_TicketItemId)
			{
				for(int i = 0; i < _HMFFHLPNMPH_count; i++)
				{
					_AHEFHIMGIBI_PlayerData.JMPNGBGNCFO_EventGoDiva.FBCJICEPLED[ev.NGHKJOEDLIP_Settings.MOEKELIIDEO_SaveIdx].GJPHOIBCEFL_ItemTicketCnt += tkt.JBGEEPFKIGG_val;
				}
			}
		}
	}

	// // RVA: 0xA201D8 Offset: 0xA201D8 VA: 0xA201D8 Slot: 11
	public override int AELBIEDNPGB_GetTicketCount(BBHNACPENDM_ServerSaveData _AHEFHIMGIBI_PlayerData)
	{
		LNELCMNJPIC_EventGoDiva ev = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.LBDOLHGDIEB_Find(JOPOPMLFINI_QuestName) as LNELCMNJPIC_EventGoDiva;
		if(ev != null)
		{
			if(_AHEFHIMGIBI_PlayerData == null)
				_AHEFHIMGIBI_PlayerData = CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_PlayerData;
			ABBOEIPOBLJ_EventTicket.CBDACMFFHJC tkt = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.KHPOJKHKLEM_EventTicket.CDENCMNHNGA_table.Find((ABBOEIPOBLJ_EventTicket.CBDACMFFHJC _GHPLINIACBB_x) =>
			{
				//0xA29E84
				return _GHPLINIACBB_x.INDDJNMPONH_type == ev.NGHKJOEDLIP_Settings.MJBKGOJBPAD_item_type;
			});
			if(tkt != null)
			{
				return _AHEFHIMGIBI_PlayerData.JMPNGBGNCFO_EventGoDiva.FBCJICEPLED[ev.NGHKJOEDLIP_Settings.MOEKELIIDEO_SaveIdx].GJPHOIBCEFL_ItemTicketCnt;
			}
		}
		return 0;
	}

	// // RVA: 0xA20584 Offset: 0xA20584 VA: 0xA20584 Slot: 54
	public override int NGIHFKHOJOK_GetRankingMax(bool DJHLDMOPCOL/* = true*/)
	{
		if(!IBNKPMPFLGI_IsRankReward)
			return 0;
		else if(!DJHLDMOPCOL)
		{
			int res = 0;
			for(int i = 0; i < KBACNOCOANM_Ranking.Length; i++)
			{
				if(KBACNOCOANM_Ranking[i] != null)
					res++;
			}
			return res;
		}
		else
		{
			return KBACNOCOANM_Ranking.Length;
		}
	}

	// // RVA: 0xA20640 Offset: 0xA20640 VA: 0xA20640 Slot: 55
	public override bool PIDEAJOJKKC(int LHJCOPMMIGO/* = 0*/)
	{
		if(AFCIIKDOMHN_GetCurrentScore(LHJCOPMMIGO + 1) != 0)
			return GPGPLIAHGJH(LHJCOPMMIGO + 1);
		return false;
	}

	// // RVA: 0xA20814 Offset: 0xA20814 VA: 0xA20814 Slot: 56
	public override bool DGOAGKOKCIJ_IsRewardReceived(int LHJCOPMMIGO)
	{
		LNELCMNJPIC_EventGoDiva ev = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.LBDOLHGDIEB_Find(JOPOPMLFINI_QuestName) as LNELCMNJPIC_EventGoDiva;
		if(ev != null)
		{
			CCBMJNPFPBB_EventGoDiva.KIJJHJHLBAK saveEv = CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_PlayerData.JMPNGBGNCFO_EventGoDiva.FBCJICEPLED[ev.NGHKJOEDLIP_Settings.MOEKELIIDEO_SaveIdx];
			return saveEv.DGOAGKOKCIJ_IsRewardReceived(LHJCOPMMIGO);
		}
		return false;
	}

	// // RVA: 0xA20A78 Offset: 0xA20A78 VA: 0xA20A78 Slot: 57
	public override void LHAEPPFACOB_SetRewardReceived(int LHJCOPMMIGO, bool _OAFPGJLCNFM_cond)
	{
		LNELCMNJPIC_EventGoDiva ev = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.LBDOLHGDIEB_Find(JOPOPMLFINI_QuestName) as LNELCMNJPIC_EventGoDiva;
		if(ev != null)
		{
			CCBMJNPFPBB_EventGoDiva.KIJJHJHLBAK saveEv = CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_PlayerData.JMPNGBGNCFO_EventGoDiva.FBCJICEPLED[ev.NGHKJOEDLIP_Settings.MOEKELIIDEO_SaveIdx];
			saveEv.LHAEPPFACOB_SetRewardReceived(LHJCOPMMIGO, _OAFPGJLCNFM_cond);
		}
	}

	// // RVA: 0xA20CE0 Offset: 0xA20CE0 VA: 0xA20CE0 Slot: 58
	protected override void LMGMELPOGMH(int LHJCOPMMIGO)
	{
		HLFHJIDHJMP = null;
		LNELCMNJPIC_EventGoDiva ev = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.LBDOLHGDIEB_Find(JOPOPMLFINI_QuestName) as LNELCMNJPIC_EventGoDiva;
		if(ev != null)
		{
			EECOJKDJIFG info = DAKMIKNKHMF_GetRankingInfoForIndex(LHJCOPMMIGO);
			if(info != null && !DGOAGKOKCIJ_IsRewardReceived(LHJCOPMMIGO))
			{
				OKPEFAPPFDH_GetRanksAroundSelf req = NKGJPJPHLIF.HHCJCDFCLOB.IBLPICFDGOF_ServerRequester.IFFNCAFNEAG_AddRequest(new OKPEFAPPFDH_GetRanksAroundSelf(false));
				req.EMPNJPMAKBF_Id = info.PPFNGGCBJKC_id;
				req.MJGOBEGONON_Type = 0;
				req.NHPCKCOPKAM_from = 0;
				req.PJFKNNNDMIA_to = 0;
				req.MOBEEPPKFLG_OnFail = (CACGCMBKHDI_Request KCFBGMKDIMI) =>
				{
					//0xA29EE0
					if(JGJFFKPFMDB.BDGBCCGLLAJ_IsRankingError(KCFBGMKDIMI.CJMFJOMECKI_ErrorId))
					{
						if(KCFBGMKDIMI.CJMFJOMECKI_ErrorId == SakashoErrorId.RANKING_DROPPED_PLAYER)
							FKKDIDMGLMI_IsDroppedPlayer = true;
						LHAEPPFACOB_SetRewardReceived(LHJCOPMMIGO, true);
						PJDGDNJNCNM_UpdateStatusImpl(NKGJPJPHLIF.HHCJCDFCLOB.IBLPICFDGOF_ServerRequester.FJDBNGEPKHL_Time.KMEFBNBFJHI_GetServerTime());
						PLOOEECNHFB_IsDone = true;
					}
					else
					{
						PLOOEECNHFB_IsDone = true;
						NPNNPNAIONN_IsError = true;
					}
				};
				req.BHFHGFKBOHH_OnSuccess = (CACGCMBKHDI_Request KCFBGMKDIMI) =>
				{
					//0xA2A138
					OKPEFAPPFDH_GetRanksAroundSelf r = KCFBGMKDIMI as OKPEFAPPFDH_GetRanksAroundSelf;
					if(r.NFEAMMJIMPG_Result.EJDEDOJFOOK_Ranks.Count == 0)
					{
						LHAEPPFACOB_SetRewardReceived(LHJCOPMMIGO, true);
						PJDGDNJNCNM_UpdateStatusImpl(NKGJPJPHLIF.HHCJCDFCLOB.IBLPICFDGOF_ServerRequester.FJDBNGEPKHL_Time.KMEFBNBFJHI_GetServerTime());
						PLOOEECNHFB_IsDone = true;
					}
					else
					{
						HLFHJIDHJMP = new NHGEHCMPDAI();
						HLFHJIDHJMP.DNBFMLBNAEE_point = r.NFEAMMJIMPG_Result.EJDEDOJFOOK_Ranks[0].KNIFCANOHOC_score;
						HLFHJIDHJMP.FJOLNJLLJEJ_rank = r.NFEAMMJIMPG_Result.EJDEDOJFOOK_Ranks[0].FJOLNJLLJEJ_rank;
						KKLGENJKEBN.HHCJCDFCLOB.DNJKPPCBINA(info.OCGFKMHNEOF_name_for_api, () =>
						{
							//0xA2A71C
							for(int i = 0; i < KKLGENJKEBN.HHCJCDFCLOB.PHOPJDPEHJA.Count; i++)
							{
								MFDJIFIIPJD m = new MFDJIFIIPJD();
								m.KHEKNNFCAOI_Init(KKLGENJKEBN.HHCJCDFCLOB.PHOPJDPEHJA[i].JJBGOIMEIPF_ItemId, KKLGENJKEBN.HHCJCDFCLOB.PHOPJDPEHJA[i].MBJIFDBEDAC_item_count);
								HLFHJIDHJMP.HBHMAKNGKFK_items.Add(m);
							}
							ILCCJNDFFOB.HHCJCDFCLOB.GIBLHFKIMDA(this);
							LHAEPPFACOB_SetRewardReceived(LHJCOPMMIGO, true);
							PLOOEECNHFB_IsDone = true;
						}, () =>
						{
							//0xA2A9C0
							HLFHJIDHJMP = null;
							ILCCJNDFFOB.HHCJCDFCLOB.GIBLHFKIMDA(this);
							LHAEPPFACOB_SetRewardReceived(LHJCOPMMIGO, true);
							PLOOEECNHFB_IsDone = true;
						}, () =>
						{
							//0xA2AAD4
							LHAEPPFACOB_SetRewardReceived(LHJCOPMMIGO, true);
							PLOOEECNHFB_IsDone = true;
							HLFHJIDHJMP = null;
						}, () =>
						{
							//0xA2AB50
							PLOOEECNHFB_IsDone = true;
							HLFHJIDHJMP = null;
						}, () =>
						{
							//0xA2AB98
							PLOOEECNHFB_IsDone = true;
							NPNNPNAIONN_IsError = true;
						}, 0, -1);
					}
				};
				return;
			}
		}
		PLOOEECNHFB_IsDone = true;
	}

	// // RVA: 0xA210C4 Offset: 0xA210C4 VA: 0xA210C4 Slot: 59
	public override List<int> AEGDKBNNDBC_GetDrops()
	{
		LNELCMNJPIC_EventGoDiva ev = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.LBDOLHGDIEB_Find(JOPOPMLFINI_QuestName) as LNELCMNJPIC_EventGoDiva;
		if(ev != null)
		{
			return ev.NGHKJOEDLIP_Settings.EEOGPJJCKHH_Drops;
		}
		return null;
	}

	// // RVA: 0xA21248 Offset: 0xA21248 VA: 0xA21248 Slot: 33
	public override bool MPMKJNJGFEF_IsEntry()
	{
		LNELCMNJPIC_EventGoDiva ev = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.LBDOLHGDIEB_Find(JOPOPMLFINI_QuestName) as LNELCMNJPIC_EventGoDiva;
		if(ev != null)
		{
			CCBMJNPFPBB_EventGoDiva.KIJJHJHLBAK saveEv = CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_PlayerData.JMPNGBGNCFO_EventGoDiva.FBCJICEPLED[ev.NGHKJOEDLIP_Settings.MOEKELIIDEO_SaveIdx];
			return saveEv.IMFBCJOIJKJ_Entry;
		}
		return false;
	}

	// // RVA: 0xA214A8 Offset: 0xA214A8 VA: 0xA214A8 Slot: 65
	protected override bool JLPDECMHLIM_CanShowStartAdventureInternal()
	{
		LNELCMNJPIC_EventGoDiva ev = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.LBDOLHGDIEB_Find(JOPOPMLFINI_QuestName) as LNELCMNJPIC_EventGoDiva;
		if(ev != null)
		{
			CCBMJNPFPBB_EventGoDiva.KIJJHJHLBAK saveEv = CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_PlayerData.JMPNGBGNCFO_EventGoDiva.FBCJICEPLED[ev.NGHKJOEDLIP_Settings.MOEKELIIDEO_SaveIdx];
			long t = NKGJPJPHLIF.HHCJCDFCLOB.IBLPICFDGOF_ServerRequester.FJDBNGEPKHL_Time.KMEFBNBFJHI_GetServerTime();
			PJDGDNJNCNM_UpdateStatusImpl(t);
			if(GFIBLLLHMPD_StartAdventureId != 0)
			{
				if(NGOFCFJHOMI_Status == KGCNCBOKCBA.GNENJEHKMHD_EventStatus.NCJFJLPJMLI_2)
				{
					return (saveEv.INLNJOGHLJE_Show & 1) == 0;
				}
			}
		}
		return false;
	}

	// // RVA: 0xA217E4 Offset: 0xA217E4 VA: 0xA217E4 Slot: 66
	public override void FGDDBFHGCGP_SetStartAdventureShown(bool _JKDJCFEBDHC_Enabled, long _JHNMKKNEENE_Time/* = 0*/)
	{
		if(_JKDJCFEBDHC_Enabled)
		{
			LNELCMNJPIC_EventGoDiva ev = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.LBDOLHGDIEB_Find(JOPOPMLFINI_QuestName) as LNELCMNJPIC_EventGoDiva;
			if(ev != null)
			{
				CCBMJNPFPBB_EventGoDiva.KIJJHJHLBAK saveEv = CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_PlayerData.JMPNGBGNCFO_EventGoDiva.FBCJICEPLED[ev.NGHKJOEDLIP_Settings.MOEKELIIDEO_SaveIdx];
				saveEv.INLNJOGHLJE_Show |= 1;
			}
		}
	}

	// // RVA: 0xA21A64 Offset: 0xA21A64 VA: 0xA21A64 Slot: 70
	public override void ADACMHAHHKC_PreSetupEventHome(IMCBBOAFION _BHFHGFKBOHH_OnSuccess, DJBHIFLHJLK _AOCANKOMKFG_OnError)
	{
		N.a.StartCoroutineWatched(NJIEIJJMAHK_Corotuine_PreSetupEventHome(_BHFHGFKBOHH_OnSuccess, _AOCANKOMKFG_OnError));
	}

	// [IteratorStateMachineAttribute] // RVA: 0x6BC824 Offset: 0x6BC824 VA: 0x6BC824
	// // RVA: 0xA21ABC Offset: 0xA21ABC VA: 0xA21ABC
	private IEnumerator NJIEIJJMAHK_Corotuine_PreSetupEventHome(IMCBBOAFION _BHFHGFKBOHH_OnSuccess, DJBHIFLHJLK _AOCANKOMKFG_OnError)
	{
		long IBCGNDADAEE_Time; // 0x28
		LNELCMNJPIC_EventGoDiva KEHCNBNPJHB; // 0x30
		BBHNACPENDM_ServerSaveData PNFNCKGAFBK; // 0x34
		CCBMJNPFPBB_EventGoDiva.KIJJHJHLBAK FDAENOPKLKP; // 0x38
		ILDKBCLAFPB GDJIOGLCKNH; // 0x3C

		//0xA2ACD4
		while(CIOECGOMILE.HHCJCDFCLOB.KONHMOLMOCI_IsSaving)
			yield return null;
		IBCGNDADAEE_Time = NKGJPJPHLIF.HHCJCDFCLOB.IBLPICFDGOF_ServerRequester.FJDBNGEPKHL_Time.KMEFBNBFJHI_GetServerTime();
		KEHCNBNPJHB = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.LBDOLHGDIEB_Find(JOPOPMLFINI_QuestName) as LNELCMNJPIC_EventGoDiva;
		if(KEHCNBNPJHB != null)
		{
			PJDGDNJNCNM_UpdateStatusImpl(IBCGNDADAEE_Time);
			PNFNCKGAFBK = CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_PlayerData;
			FDAENOPKLKP = PNFNCKGAFBK.JMPNGBGNCFO_EventGoDiva.FBCJICEPLED[KEHCNBNPJHB.NGHKJOEDLIP_Settings.MOEKELIIDEO_SaveIdx];
			GDJIOGLCKNH = GameManager.Instance.localSave;
			if(FDAENOPKLKP.DNBFMLBNAEE_point > 0)
			{
				MJFKJHJJLMN_GetRanks(0, false);
				//LAB_00a2ae58
				while(!PLOOEECNHFB_IsDone)
					yield return null;
				if(NPNNPNAIONN_IsError)
				{
					_AOCANKOMKFG_OnError();
					yield break;
				}
				if(FKKDIDMGLMI_IsDroppedPlayer)
				{
					JHHBAFKMBDL.HHCJCDFCLOB.PEIONAKEPCN_ShowRankingBanPopup(_AOCANKOMKFG_OnError);
					yield break;
				}
			}
			//break;
			if(NGOFCFJHOMI_Status == KGCNCBOKCBA.GNENJEHKMHD_EventStatus.GDOPLACICFE_4)
			{
				FDAENOPKLKP.ABBJBPLHFHA_Spurt = true;
				LPFJADHHLHG = true;
				PJDGDNJNCNM_UpdateStatusImpl(IBCGNDADAEE_Time);
			}
			if(!FDAENOPKLKP.IMFBCJOIJKJ_Entry)
			{
				if(NGOFCFJHOMI_Status == KGCNCBOKCBA.GNENJEHKMHD_EventStatus.NCJFJLPJMLI_2)
				{
					CMPEJEHCOEI = true;
					FGDDBFHGCGP_SetStartAdventureShown(true, 0);
					GameManager.Instance.localSave.EPJOACOONAC_GetSave().PPCGEFGJJIC_SortProprty.IMEBBACHPAN_EventGoDiva.LHPDDGIJKNB_Reset();
					FDAENOPKLKP.IMFBCJOIJKJ_Entry = true;
				}
				if(KIBBLLADDPO)
				{
					FDAENOPKLKP.ABBJBPLHFHA_Spurt = true;
					LPFJADHHLHG = true;
				}
			}
			if(NGOFCFJHOMI_Status < KGCNCBOKCBA.GNENJEHKMHD_EventStatus.EMAMLLFAOJI_6_Counting)
			{
				if(GFIBLLLHMPD_StartAdventureId > 0)
				{
					if(PNFNCKGAFBK.HBPPNFHOMNB_Adventure.FABEJIHKFGN_IsReleased(GFIBLLLHMPD_StartAdventureId))
					{
						if(!FDAENOPKLKP.OKEJGGCMAAI_PlaRcv)
						{
							bool KPIGMCJMFAN = false;
							yield return Co.R(JEIJKLPOAHP_ReceivePrologueRepeatedAchievement(() =>
							{
								_BHFHGFKBOHH_OnSuccess();
								PLOOEECNHFB_IsDone = true;
								//0x13291B8
							}));
							if(!KPIGMCJMFAN)
							{
								if(JBPPMMMFGCA_HasRewardItems())
								{
									FDAENOPKLKP.OKEJGGCMAAI_PlaRcv = true;
								}
								//LAB_00a2b148
								//LAB_00a2b690
							}
							else
							{
								//LAB_00a2af0c
								_AOCANKOMKFG_OnError();
								yield break;
							}
						}
					}
				}
			}
			else
			{
				if(NGOFCFJHOMI_Status >= KGCNCBOKCBA.GNENJEHKMHD_EventStatus.DDEODFNANDO_8_ResultRewardToReceive && CAKEOPLJDAF_EndAdventureId >= 1)
				{
					if(PNFNCKGAFBK.HBPPNFHOMNB_Adventure.FABEJIHKFGN_IsReleased(CAKEOPLJDAF_EndAdventureId))
					{
						if(!FDAENOPKLKP.CGMMMJCIDFE_EpaRcv)
						{
							bool KPIGMCJMFAN = false;
							yield return Co.R(KPBNMAEHHDF_ReceiveEpilogueRepeatedAchivement(() =>
							{
								//0x13291F8
								_AOCANKOMKFG_OnError();
								PLOOEECNHFB_IsDone = true;
								NPNNPNAIONN_IsError = true;
							}));
							if(!KPIGMCJMFAN)
							{
								if(JBPPMMMFGCA_HasRewardItems())
								{
									FDAENOPKLKP.CGMMMJCIDFE_EpaRcv = true;
								}
								//LAB_00a2b148
								//LAB_00a2b690
							}
							else
							{
								//LAB_00a2af0c
								_AOCANKOMKFG_OnError();
								yield break;
							}
						}
					}
				}
			}
			//LAB_00a2b690
			OIMGJLOLPHK = false; // Not sure, 0xe3!
			if(NGOFCFJHOMI_Status < KGCNCBOKCBA.GNENJEHKMHD_EventStatus.EMAMLLFAOJI_6_Counting)
			{
				CEBFFLDKAEC_SecureInt v;
				if(KEHCNBNPJHB.OHJFBLFELNK_m_intParam.TryGetValue(HOEKCEJINNA_new_episode_mver, out v))
				{
					if(NGOFCFJHOMI_Status == KGCNCBOKCBA.GNENJEHKMHD_EventStatus.NCJFJLPJMLI_2)
					{
						OIMGJLOLPHK = true;
						if(!DLHEEOIELBA(v.DNJEJEANJGL_Value))
						{
							FDAENOPKLKP.INLNJOGHLJE_Show |= 4;
							OIMGJLOLPHK = false;
						}
					}
					else
					{
						if(KEHCNBNPJHB.OHJFBLFELNK_m_intParam.TryGetValue(FOKNMOMNHHD_new_episode_help_pict_id, out v) && DLHEEOIELBA(v.DNJEJEANJGL_Value))
						{
							OIMGJLOLPHK = true;
							if((FDAENOPKLKP.INLNJOGHLJE_Show & 4) != 0)
							{
								GFHKFKHBIGM = true;
								OGPMLMDPGJA = v.DNJEJEANJGL_Value;
							}
						}
					}
				}
			}
			GDJIOGLCKNH.HJMKBCFJOOH_Save();
			ILCCJNDFFOB.HHCJCDFCLOB.DADNPOJNIBL(this);
			_BHFHGFKBOHH_OnSuccess();
		}
		else
		{
			PLOOEECNHFB_IsDone = true;
			NPNNPNAIONN_IsError = true;
			_AOCANKOMKFG_OnError();
		}
	}

	// [IteratorStateMachineAttribute] // RVA: 0x6BC89C Offset: 0x6BC89C VA: 0x6BC89C
	// // RVA: 0xA21B9C Offset: 0xA21B9C VA: 0xA21B9C
	// public IEnumerator INOILCGFHIC_RequestGetScoreRank(int LHJCOPMMIGO, IMCBBOAFION _BHFHGFKBOHH_OnSuccess, DJBHIFLHJLK _AOCANKOMKFG_OnError) { }

	// // RVA: 0xA21C94 Offset: 0xA21C94 VA: 0xA21C94 Slot: 69
	public override void HAAEJDGMICH(LBNLAENLPNK.JEKODBEDOMM _INDDJNMPONH_type, IMCBBOAFION _BHFHGFKBOHH_OnSuccess, DJBHIFLHJLK _AOCANKOMKFG_OnError)
	{
		string s = null;
		if(_INDDJNMPONH_type == 0)
		{
			s = JOPOPMLFINI_QuestName + "_rule";
		}
		if(string.IsNullOrEmpty(s))
		{
			_BHFHGFKBOHH_OnSuccess();
		}
		else
		{
			MBCPNPNMFHB.HHCJCDFCLOB.FLLLPBIECCP(s, _BHFHGFKBOHH_OnSuccess, _AOCANKOMKFG_OnError);
		}
	}

	// // RVA: 0xA2205C Offset: 0xA2205C VA: 0xA2205C Slot: 71
	public override int BAEPGOAMBDK(string _LJNAKDMILMC_key, int MNCOAGOKNAO)
	{
		LNELCMNJPIC_EventGoDiva ev = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.LBDOLHGDIEB_Find(JOPOPMLFINI_QuestName) as LNELCMNJPIC_EventGoDiva;
		if(ev != null)
		{
			return ev.LPJLEHAJADA_GetIntParam(_LJNAKDMILMC_key, MNCOAGOKNAO);
		}
		return MNCOAGOKNAO;
	}

	// // RVA: 0xA221DC Offset: 0xA221DC VA: 0xA221DC Slot: 72
	public override string MAICAKMIBEM(string _LJNAKDMILMC_key, string MNCOAGOKNAO)
	{
		LNELCMNJPIC_EventGoDiva ev = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.LBDOLHGDIEB_Find(JOPOPMLFINI_QuestName) as LNELCMNJPIC_EventGoDiva;
		if(ev != null)
		{
			return ev.EFEGBHACJAL_GetStringParam(_LJNAKDMILMC_key, MNCOAGOKNAO);
		}
		return MNCOAGOKNAO;
	}

	// // RVA: 0xA2235C Offset: 0xA2235C VA: 0xA2235C Slot: 68
	public override bool GJMGKBDGMOP(long LPEKHFOMCAH)
	{
		LNELCMNJPIC_EventGoDiva ev = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.LBDOLHGDIEB_Find(JOPOPMLFINI_QuestName) as LNELCMNJPIC_EventGoDiva;
		if(ev != null)
		{
			if(LPEKHFOMCAH > DPJCPDKALGI_RankingEnd)
				return false;
            CCBMJNPFPBB_EventGoDiva.KIJJHJHLBAK saveEv = CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_PlayerData.JMPNGBGNCFO_EventGoDiva.FBCJICEPLED[ev.NGHKJOEDLIP_Settings.MOEKELIIDEO_SaveIdx];
			bool b17 = false;
			if(NKGJPJPHLIF.HHCJCDFCLOB.DHMLDAGGKCD != saveEv.OMCAOJJGOGG_Lb)
			{
				int daily_bonus_cnt = ev.LPJLEHAJADA_GetIntParam("daily_bonus_cnt", 1);
				saveEv.PFPGHILKGIG_BnsCnt = daily_bonus_cnt;
				saveEv.JHKKAKJCJOF_Bns2 = 0;
				saveEv.NNCFCPEOODE_usecnt = ev.LPJLEHAJADA_GetIntParam("fever_ticket_use_cnt", 3);
				if(BHABCGJCGNO != null)
				{
					if(EKLNMHFCAOI.BKHFLDMOGBD_GetItemCategory(BHABCGJCGNO.JJBGOIMEIPF_ItemId) == EKLNMHFCAOI.FKGCBLHOOCL_Category.DMMIIBCMCFG_EnergyItem)
					{
						EGOLBAPFHHD_Common.FKLHGOGJOHH en = CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_PlayerData.KCCLEHLLOFG_Common.KFEBOFKAHAJ_EngItem[EKLNMHFCAOI.DEACAHNLMNI_getItemId(BHABCGJCGNO.JJBGOIMEIPF_ItemId) - 1];
						en.BFINGCJHOHI_cnt += BHABCGJCGNO.MBJIFDBEDAC_item_count;
						en.BEBJKJKBOGH_date = NKGJPJPHLIF.HHCJCDFCLOB.IBLPICFDGOF_ServerRequester.FJDBNGEPKHL_Time.KMEFBNBFJHI_GetServerTime();
						ILCCJNDFFOB.HHCJCDFCLOB.JAHALBMOANH(BHABCGJCGNO.JJBGOIMEIPF_ItemId, OAGBCBBHMPF.COIIJOEKBDH.IGAJCMKNLDL_14, PGIIDPEGGPI_EventId.ToString(), BHABCGJCGNO.MBJIFDBEDAC_item_count, en.BFINGCJHOHI_cnt, 1);
					}
					else if(EKLNMHFCAOI.BKHFLDMOGBD_GetItemCategory(BHABCGJCGNO.JJBGOIMEIPF_ItemId) == EKLNMHFCAOI.FKGCBLHOOCL_Category.CLMIJKACELE_EventTicket)
					{
						HPENJEOAMBK_SetTicket(BHABCGJCGNO.JJBGOIMEIPF_ItemId, BHABCGJCGNO.MBJIFDBEDAC_item_count, CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_PlayerData);
						ILCCJNDFFOB.HHCJCDFCLOB.JAHALBMOANH(BHABCGJCGNO.JJBGOIMEIPF_ItemId, OAGBCBBHMPF.COIIJOEKBDH.IGAJCMKNLDL_14, PGIIDPEGGPI_EventId.ToString(), BHABCGJCGNO.MBJIFDBEDAC_item_count, saveEv.GJPHOIBCEFL_ItemTicketCnt, 1);
					}
				}
				//LAB_00a22c7c
				saveEv.OMCAOJJGOGG_Lb = NKGJPJPHLIF.HHCJCDFCLOB.DHMLDAGGKCD;
				b17 = true;
			}
			//LAB_00a22ce8
			if(saveEv.PFPGHILKGIG_BnsCnt > 0)
			{
				if(saveEv.JHKKAKJCJOF_Bns2 < 1)
				{
					saveEv.JHKKAKJCJOF_Bns2 = FDMOAACBEGJ(100, true, -1);
					saveEv.PFPGHILKGIG_BnsCnt--;
				}
			}
			return b17;
        }
		return false;
	}

	// // RVA: 0xA23278 Offset: 0xA23278 VA: 0xA23278
	public void LFMPOBILOOH(JGEOBNENMAH.EDHCNKBMLGI OMNOFMEBLAD)
	{
		CMCEGEKGEEP.KPEKOOCPKID_BonusId = 0;
		CMCEGEKGEEP.DEFAOMCNGAJ_IsBonusDaily = false;
		List<IBNAEKMCIEO> l = IHELCODOPJF();
		if(l.Count > 0)
		{
			CMCEGEKGEEP.KPEKOOCPKID_BonusId = l[0].PPFNGGCBJKC_id;
			CMCEGEKGEEP.DEFAOMCNGAJ_IsBonusDaily = l[0].CGHNCPEKOCK_IsDaily;
			List<int> l2 = HEACCHAKMFG_GetMusicsList();
			int mId = l2.Count > 0 ? l2[0] : 0;
			if(OMNOFMEBLAD.GHBPLHBNMBK_FreeMusicId == mId)
			{
				CCBMJNPFPBB_EventGoDiva.KIJJHJHLBAK saveEv = CLELOGKMNCE_GetEventSaveData();
				if(saveEv != null)
				{
					if(l[0].CGHNCPEKOCK_IsDaily)
					{
						saveEv.JHKKAKJCJOF_Bns2 = 0;
						if(OMNOFMEBLAD.PMCGHPOGLGM_IsSkip)
							PCBIJCAIPAG(OMNOFMEBLAD.KAIPAEILJHO_TicketCount);
					}
					else
					{
						saveEv.KAPGPAMOKDD_Bns1 = 0;
					}
					if(CMCEGEKGEEP.KPEKOOCPKID_BonusId != 0)
					{
						if(saveEv.PFPGHILKGIG_BnsCnt > 0)
							return;
						EventGoDivaScene.IsViewedBonusOpenPopup = false;
					}
				}
			}
		}
	}

	// // RVA: 0xA2382C Offset: 0xA2382C VA: 0xA2382C
	public void FCLGOCBGPJF(JGEOBNENMAH.HAJIFNABIFF OMNOFMEBLAD, int _FCLGIPFPIPH_DashBonus, int _LCCGDFGGIHI_PlayCount, int BMMPAHHEOJC, int MHADLGMJKGK, bool _IKGLAFOHGDO_TestOnly)
	{
		LNELCMNJPIC_EventGoDiva ev = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.LBDOLHGDIEB_Find(JOPOPMLFINI_QuestName) as LNELCMNJPIC_EventGoDiva;
		if(ev != null)
		{
			CCBMJNPFPBB_EventGoDiva.KIJJHJHLBAK saveEv = CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_PlayerData.JMPNGBGNCFO_EventGoDiva.FBCJICEPLED[ev.NGHKJOEDLIP_Settings.MOEKELIIDEO_SaveIdx];
			if(_IKGLAFOHGDO_TestOnly)
			{
				CCBMJNPFPBB_EventGoDiva.KIJJHJHLBAK newSave = new CCBMJNPFPBB_EventGoDiva.KIJJHJHLBAK();
				newSave.LHPDDGIJKNB_Reset();
				newSave.ODDIHGPONFL_Copy(saveEv);
				saveEv = newSave;
			}
			int score_point_coef = ev.LPJLEHAJADA_GetIntParam("score_point_coef", 10000);
			CMCEGEKGEEP.KNIFCANOHOC_score = OMNOFMEBLAD.KNIFCANOHOC_score;
			CMCEGEKGEEP.JBJJFDIHKMB_ScorePoint = OMNOFMEBLAD.KNIFCANOHOC_score / score_point_coef;
			CMCEGEKGEEP.LIPIAPOGHIP_EpisodeNum = LEPNPBIMHGM_GetEquippedEpisodesWithBonus(BMMPAHHEOJC).Count;
			CMCEGEKGEEP.PFJMBKBEFMA_EpisodeRate = CEICDKGEONG_GetEquippedEpisodesBonusValue(BMMPAHHEOJC, MHADLGMJKGK);
			CMCEGEKGEEP.PFJMBKBEFMA_EpisodeRate += 100;
			CMCEGEKGEEP.EJDJIBPKKNO_BasePoint = BDIJPOGEGNB(OMNOFMEBLAD.GHBPLHBNMBK_FreeMusicId, OMNOFMEBLAD.AKNELONELJK_difficulty);
			CMCEGEKGEEP.FCLGIPFPIPH_DashBonus = _FCLGIPFPIPH_DashBonus;
			CMCEGEKGEEP.JKFCHNEININ_GetPoint = CMCEGEKGEEP.PFJMBKBEFMA_EpisodeRate * ( CMCEGEKGEEP.JBJJFDIHKMB_ScorePoint + CMCEGEKGEEP.EJDJIBPKKNO_BasePoint) / 100;
			CMCEGEKGEEP.JKFCHNEININ_GetPoint *= CMCEGEKGEEP.FCLGIPFPIPH_DashBonus;
			CMCEGEKGEEP.JKFCHNEININ_GetPoint *= _LCCGDFGGIHI_PlayCount;
			saveEv.DNBFMLBNAEE_point += CMCEGEKGEEP.JKFCHNEININ_GetPoint;
			long t = NKGJPJPHLIF.HHCJCDFCLOB.IBLPICFDGOF_ServerRequester.FJDBNGEPKHL_Time.KMEFBNBFJHI_GetServerTime();
			saveEv.NFIOKIBPJCJ_uptime = t;
			CMCEGEKGEEP.AHOKAPCGJMA_TotalPoint = saveEv.DNBFMLBNAEE_point;
			CMCEGEKGEEP.LFGNLKKFOCD_IsLine6 = OMNOFMEBLAD.LFGNLKKFOCD_IsLine6;
            List<int> l = HEACCHAKMFG_GetMusicsList();
			CMCEGEKGEEP.OENBOLPDBAB_FreeMusicId = l.Count > 0 ? l[0] : 0;
			CMCEGEKGEEP.LMBFJMBIIGN = CMCEGEKGEEP.PFJMBKBEFMA_EpisodeRate * OMNOFMEBLAD.KNIFCANOHOC_score / 100;
			CMCEGEKGEEP.JLIKEOKBBAM_HighScore = saveEv.LGFFMGDBIAH_ranking[OMNOFMEBLAD.HNHCIGMKPDC_DivaIds[0] - 1].NANNGLGOFKH_value;
			CMCEGEKGEEP.FFHMPNGJCLK_NewRecord = false;
			if(!OMNOFMEBLAD.PMCGHPOGLGM_IsSkip)
			{
				EECOJKDJIFG e = DAKMIKNKHMF_GetRankingInfoForIndex(OMNOFMEBLAD.HNHCIGMKPDC_DivaIds[0] - 1);
				if(e != null)
				{
					if(OMNOFMEBLAD.GHBPLHBNMBK_FreeMusicId == CMCEGEKGEEP.OENBOLPDBAB_FreeMusicId)
					{
						if(CMCEGEKGEEP.JLIKEOKBBAM_HighScore < CMCEGEKGEEP.LMBFJMBIIGN)
						{
							saveEv.LGFFMGDBIAH_ranking[OMNOFMEBLAD.HNHCIGMKPDC_DivaIds[0] - 1].NANNGLGOFKH_value = CMCEGEKGEEP.LMBFJMBIIGN;
							CMCEGEKGEEP.JLIKEOKBBAM_HighScore = CMCEGEKGEEP.LMBFJMBIIGN;
							CMCEGEKGEEP.FFHMPNGJCLK_NewRecord = true;
						}
					}
				}
			}
			int r = GNDOGPBIGIL_GetCurrentBonusRate(Database.Instance.gameSetup.musicInfo.setupTime);
			CMCEGEKGEEP.AONOCELOCLL_BonusMusicProbaBefore = Mathf.Clamp(saveEv.ADKDHKMPMHP_rate + r, 0, 100);
			CMCEGEKGEEP.JGBIFJLPCHM_IsBonusStart = false;
			CMCEGEKGEEP.IMDPOICJKLF_IsBonusEnd = false;
			CMCEGEKGEEP.MKMIEGPOKGG_Soul.DJJGNDCMNHF_BonusValue = 0;
			CMCEGEKGEEP.EACDINDLGLF_Voice.DJJGNDCMNHF_BonusValue = 0;
			CMCEGEKGEEP.LDLHPACIIAB_Charm.DJJGNDCMNHF_BonusValue = 0;
			if(CMCEGEKGEEP.KPEKOOCPKID_BonusId == 0)
			{
				saveEv.ADKDHKMPMHP_rate = Mathf.Clamp(HODCLEPALGP(OMNOFMEBLAD.GHBPLHBNMBK_FreeMusicId, OMNOFMEBLAD.AKNELONELJK_difficulty) * _LCCGDFGGIHI_PlayCount + saveEv.ADKDHKMPMHP_rate, 0, 100);
				CMCEGEKGEEP.KBBOPKDLHHJ_BonusMusicProbaAfter = Mathf.Clamp(saveEv.ADKDHKMPMHP_rate + r, 0, 100);
				LNELCMNJPIC_EventGoDiva.DPKGKNJBFBJ d = NJGBKGKFOED(OMNOFMEBLAD.GHBPLHBNMBK_FreeMusicId, Database.Instance.gameSetup.musicInfo.setupTime);
				int stBonus = FDMOAACBEGJ(CMCEGEKGEEP.KBBOPKDLHHJ_BonusMusicProbaAfter, false, d.MBAMIOJNGBD_ch > 0 ? 2 : (d.KNEDJFLCCLN_vo > 0 ? 1 : (d.LJELGFAFGAB_so > 0 ? 0 : -1)));
				CMCEGEKGEEP.JGBIFJLPCHM_IsBonusStart = stBonus > 0;
				if(CMCEGEKGEEP.JGBIFJLPCHM_IsBonusStart)
				{
					saveEv.KAPGPAMOKDD_Bns1 = stBonus;
					saveEv.ADKDHKMPMHP_rate = ev.LPJLEHAJADA_GetIntParam("reset_rate", 0);
				}
			}
			else
			{
				if(CMCEGEKGEEP.OENBOLPDBAB_FreeMusicId == OMNOFMEBLAD.GHBPLHBNMBK_FreeMusicId)
				{
					IBNAEKMCIEO ib = NLPCPFCIDLM(CMCEGEKGEEP.KPEKOOCPKID_BonusId, CMCEGEKGEEP.DEFAOMCNGAJ_IsBonusDaily);
					CMCEGEKGEEP.MKMIEGPOKGG_Soul.DJJGNDCMNHF_BonusValue = ib.NOEFINFEMBM;
					CMCEGEKGEEP.EACDINDLGLF_Voice.DJJGNDCMNHF_BonusValue = ib.PKDAEFIGMLI;
					CMCEGEKGEEP.LDLHPACIIAB_Charm.DJJGNDCMNHF_BonusValue = ib.DGAELGEJPNA;
					if(saveEv.PFPGHILKGIG_BnsCnt < 1)
					{
						CMCEGEKGEEP.IMDPOICJKLF_IsBonusEnd = true;
					}
				}
				CMCEGEKGEEP.KBBOPKDLHHJ_BonusMusicProbaAfter = Mathf.Clamp(saveEv.ADKDHKMPMHP_rate + r, 0, 100);
			}
			LNELCMNJPIC_EventGoDiva.DPKGKNJBFBJ d2 = NJGBKGKFOED(OMNOFMEBLAD.GHBPLHBNMBK_FreeMusicId, OMNOFMEBLAD.NFFDIGEJHGL_ServerTime);
			int v1 = d2.LJELGFAFGAB_so;
			int v2 = d2.KNEDJFLCCLN_vo;
			int v3 = d2.MBAMIOJNGBD_ch;
			if(CMCEGEKGEEP.MKMIEGPOKGG_Soul.DJJGNDCMNHF_BonusValue + 
				CMCEGEKGEEP.EACDINDLGLF_Voice.DJJGNDCMNHF_BonusValue + 
				CMCEGEKGEEP.LDLHPACIIAB_Charm.DJJGNDCMNHF_BonusValue > 0)
			{
				v1 = 0;
				if(CMCEGEKGEEP.MKMIEGPOKGG_Soul.DJJGNDCMNHF_BonusValue > 0)
					v1 = 100;
				v2 = 0;
				if(CMCEGEKGEEP.EACDINDLGLF_Voice.DJJGNDCMNHF_BonusValue > 0)
					v2 = 100;
				v3 = 0;
				if(CMCEGEKGEEP.LDLHPACIIAB_Charm.DJJGNDCMNHF_BonusValue > 0)
					v3 = 100;
			}
			CMCEGEKGEEP.MKMIEGPOKGG_Soul.DNBFMLBNAEE_point = CMCEGEKGEEP.JKFCHNEININ_GetPoint * v1 / 100;
			CMCEGEKGEEP.EACDINDLGLF_Voice.DNBFMLBNAEE_point = CMCEGEKGEEP.JKFCHNEININ_GetPoint * v2 / 100;
			CMCEGEKGEEP.LDLHPACIIAB_Charm.DNBFMLBNAEE_point = CMCEGEKGEEP.JKFCHNEININ_GetPoint * v3 / 100;
			DEKKMGAFJCG_Diva.MNNLOBDPCCH_DivaInfo sDiva = CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_PlayerData.DGCJCAHIAPP_Diva.NBIGLBMHEDC_DivaList[OMNOFMEBLAD.HNHCIGMKPDC_DivaIds[0] - 1];
			if(_IKGLAFOHGDO_TestOnly)
			{
				DEKKMGAFJCG_Diva.MNNLOBDPCCH_DivaInfo nDiva = new DEKKMGAFJCG_Diva.MNNLOBDPCCH_DivaInfo();
				nDiva.ODDIHGPONFL_Copy(sDiva);
				sDiva = nDiva;
			}
			FFHPBEPOMAK_DivaInfo dInfo = new FFHPBEPOMAK_DivaInfo();
			dInfo.KHEKNNFCAOI_Init(OMNOFMEBLAD.HNHCIGMKPDC_DivaIds[0], CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_PlayerData, false);
			CMCEGEKGEEP.MKMIEGPOKGG_Soul.EJOHDINLOAJ_PrevExp = saveEv.FDBOPFEOENF_diva[OMNOFMEBLAD.HNHCIGMKPDC_DivaIds[0] - 1].DMDLAIOJKPM_so_exp;
			CMCEGEKGEEP.MKMIEGPOKGG_Soul.AKPPMDMNOHL_StartLevel = saveEv.FDBOPFEOENF_diva[OMNOFMEBLAD.HNHCIGMKPDC_DivaIds[0] - 1].KKGPPDLFDKA_so_lv;
			CMCEGEKGEEP.MKMIEGPOKGG_Soul.KFEMFDFPCGO_Level0 = sDiva.MMCEMJILMJI_EvSoLevel;
			CMCEGEKGEEP.MKMIEGPOKGG_Soul.NMJIKIJLAMP_BeforeValue = dInfo.JLJGCBOHJID_Status.soul;
			CMCEGEKGEEP.EACDINDLGLF_Voice.EJOHDINLOAJ_PrevExp = saveEv.FDBOPFEOENF_diva[OMNOFMEBLAD.HNHCIGMKPDC_DivaIds[0] - 1].GNBEKAELDMM_vo_exp;
			CMCEGEKGEEP.EACDINDLGLF_Voice.AKPPMDMNOHL_StartLevel = saveEv.FDBOPFEOENF_diva[OMNOFMEBLAD.HNHCIGMKPDC_DivaIds[0] - 1].IDIDIJGPPIO_vo_lv;
			CMCEGEKGEEP.EACDINDLGLF_Voice.KFEMFDFPCGO_Level0 = sDiva.HDPANGMKKCP_EvVoLevel;
			CMCEGEKGEEP.EACDINDLGLF_Voice.NMJIKIJLAMP_BeforeValue = dInfo.JLJGCBOHJID_Status.vocal;
			CMCEGEKGEEP.LDLHPACIIAB_Charm.EJOHDINLOAJ_PrevExp = saveEv.FDBOPFEOENF_diva[OMNOFMEBLAD.HNHCIGMKPDC_DivaIds[0] - 1].BCANABIAIIP_ch_exp;
			CMCEGEKGEEP.LDLHPACIIAB_Charm.AKPPMDMNOHL_StartLevel = saveEv.FDBOPFEOENF_diva[OMNOFMEBLAD.HNHCIGMKPDC_DivaIds[0] - 1].OMOIGFMNFJB_ch_lv;
			CMCEGEKGEEP.LDLHPACIIAB_Charm.KFEMFDFPCGO_Level0 = sDiva.FFMLBEEBHDD_EvChLevel;
			CMCEGEKGEEP.LDLHPACIIAB_Charm.NMJIKIJLAMP_BeforeValue = dInfo.JLJGCBOHJID_Status.charm;
			CMCEGEKGEEP.MKMIEGPOKGG_Soul.JDCFEBMOOMN_GetExp = Mathf.Max(100, CMCEGEKGEEP.MKMIEGPOKGG_Soul.DJJGNDCMNHF_BonusValue) * CMCEGEKGEEP.MKMIEGPOKGG_Soul.DNBFMLBNAEE_point / 100;
			CMCEGEKGEEP.EACDINDLGLF_Voice.JDCFEBMOOMN_GetExp = Mathf.Max(100, CMCEGEKGEEP.EACDINDLGLF_Voice.DJJGNDCMNHF_BonusValue) * CMCEGEKGEEP.EACDINDLGLF_Voice.DNBFMLBNAEE_point / 100;
			CMCEGEKGEEP.LDLHPACIIAB_Charm.JDCFEBMOOMN_GetExp = Mathf.Max(100, CMCEGEKGEEP.LDLHPACIIAB_Charm.DJJGNDCMNHF_BonusValue) * CMCEGEKGEEP.LDLHPACIIAB_Charm.DNBFMLBNAEE_point / 100;
			int soulV1;
			int soulV2;
			List<int> soulV3;
			int soulV4;
			FELAPFAOHDG(0, sDiva.MMCEMJILMJI_EvSoLevel, saveEv.FDBOPFEOENF_diva[OMNOFMEBLAD.HNHCIGMKPDC_DivaIds[0] - 1].DMDLAIOJKPM_so_exp, 
				saveEv.FDBOPFEOENF_diva[OMNOFMEBLAD.HNHCIGMKPDC_DivaIds[0] - 1].JDHJEINPJLL_so_mexp, CMCEGEKGEEP.MKMIEGPOKGG_Soul.JDCFEBMOOMN_GetExp, 
				out soulV1, out soulV2, out soulV3, out soulV4);
			int voiceV1;
			int voiceV2;
			List<int> voiceV3;
			int voiceV4;
			FELAPFAOHDG(1, sDiva.HDPANGMKKCP_EvVoLevel, saveEv.FDBOPFEOENF_diva[OMNOFMEBLAD.HNHCIGMKPDC_DivaIds[0] - 1].GNBEKAELDMM_vo_exp, 
				saveEv.FDBOPFEOENF_diva[OMNOFMEBLAD.HNHCIGMKPDC_DivaIds[0] - 1].OIMLBHPAMGD_vo_mexp, CMCEGEKGEEP.EACDINDLGLF_Voice.JDCFEBMOOMN_GetExp, 
				out voiceV1, out voiceV2, out voiceV3, out voiceV4);
			int charmV1;
			int charmV2;
			List<int> charmV3;
			int charmV4;
			FELAPFAOHDG(2, sDiva.FFMLBEEBHDD_EvChLevel, saveEv.FDBOPFEOENF_diva[OMNOFMEBLAD.HNHCIGMKPDC_DivaIds[0] - 1].BCANABIAIIP_ch_exp, 
				saveEv.FDBOPFEOENF_diva[OMNOFMEBLAD.HNHCIGMKPDC_DivaIds[0] - 1].PFDDNKEOKBF_ch_mexp, CMCEGEKGEEP.LDLHPACIIAB_Charm.JDCFEBMOOMN_GetExp, 
				out charmV1, out charmV2, out charmV3, out charmV4);
			int godiva_max_level = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.GDEKCOOBLMA_System.LPJLEHAJADA_GetIntParam("godiva_max_level", IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.OAINIGNLJKC_Diva2.NBJKHMLGNPA());
			sDiva.MMCEMJILMJI_EvSoLevel = soulV1;
			sDiva.HDPANGMKKCP_EvVoLevel = voiceV1;
			sDiva.FFMLBEEBHDD_EvChLevel = charmV1;
			saveEv.FDBOPFEOENF_diva[OMNOFMEBLAD.HNHCIGMKPDC_DivaIds[0] - 1].KKGPPDLFDKA_so_lv += soulV4;
			saveEv.FDBOPFEOENF_diva[OMNOFMEBLAD.HNHCIGMKPDC_DivaIds[0] - 1].DMDLAIOJKPM_so_exp = soulV2;
			saveEv.FDBOPFEOENF_diva[OMNOFMEBLAD.HNHCIGMKPDC_DivaIds[0] - 1].JDHJEINPJLL_so_mexp = soulV3[soulV3.Count - 1];
			saveEv.FDBOPFEOENF_diva[OMNOFMEBLAD.HNHCIGMKPDC_DivaIds[0] - 1].IDIDIJGPPIO_vo_lv += voiceV4;
			saveEv.FDBOPFEOENF_diva[OMNOFMEBLAD.HNHCIGMKPDC_DivaIds[0] - 1].GNBEKAELDMM_vo_exp = voiceV2;
			saveEv.FDBOPFEOENF_diva[OMNOFMEBLAD.HNHCIGMKPDC_DivaIds[0] - 1].OIMLBHPAMGD_vo_mexp = voiceV3[voiceV3.Count - 1];
			saveEv.FDBOPFEOENF_diva[OMNOFMEBLAD.HNHCIGMKPDC_DivaIds[0] - 1].OMOIGFMNFJB_ch_lv += charmV4;
			saveEv.FDBOPFEOENF_diva[OMNOFMEBLAD.HNHCIGMKPDC_DivaIds[0] - 1].BCANABIAIIP_ch_exp = charmV2;
			saveEv.FDBOPFEOENF_diva[OMNOFMEBLAD.HNHCIGMKPDC_DivaIds[0] - 1].PFDDNKEOKBF_ch_mexp = charmV3[charmV3.Count - 1];
			dInfo.KHEKNNFCAOI_Init(OMNOFMEBLAD.HNHCIGMKPDC_DivaIds[0], CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_PlayerData, false);
			soulV3[soulV3.Count - 1] = saveEv.FDBOPFEOENF_diva[OMNOFMEBLAD.HNHCIGMKPDC_DivaIds[0] - 1].JDHJEINPJLL_so_mexp;
			voiceV3[voiceV3.Count - 1] = saveEv.FDBOPFEOENF_diva[OMNOFMEBLAD.HNHCIGMKPDC_DivaIds[0] - 1].OIMLBHPAMGD_vo_mexp;
			charmV3[charmV3.Count - 1] = saveEv.FDBOPFEOENF_diva[OMNOFMEBLAD.HNHCIGMKPDC_DivaIds[0] - 1].PFDDNKEOKBF_ch_mexp;
			CMCEGEKGEEP.MKMIEGPOKGG_Soul.FKAOJEMHAKN_LevelExp = soulV3;
			CMCEGEKGEEP.MKMIEGPOKGG_Soul.LKIFDCEKDCK_exp = saveEv.FDBOPFEOENF_diva[OMNOFMEBLAD.HNHCIGMKPDC_DivaIds[0] - 1].DMDLAIOJKPM_so_exp;
			CMCEGEKGEEP.MKMIEGPOKGG_Soul.GLFIELJJDCI_Level = saveEv.FDBOPFEOENF_diva[OMNOFMEBLAD.HNHCIGMKPDC_DivaIds[0] - 1].KKGPPDLFDKA_so_lv;
			CMCEGEKGEEP.MKMIEGPOKGG_Soul.CIEOBFIIPLD_Level = sDiva.MMCEMJILMJI_EvSoLevel;
			CMCEGEKGEEP.MKMIEGPOKGG_Soul.CMCKNKKCNDK_status = dInfo.JLJGCBOHJID_Status.soul;
			CMCEGEKGEEP.EACDINDLGLF_Voice.FKAOJEMHAKN_LevelExp = voiceV3;
			CMCEGEKGEEP.EACDINDLGLF_Voice.LKIFDCEKDCK_exp = saveEv.FDBOPFEOENF_diva[OMNOFMEBLAD.HNHCIGMKPDC_DivaIds[0] - 1].GNBEKAELDMM_vo_exp;
			CMCEGEKGEEP.EACDINDLGLF_Voice.GLFIELJJDCI_Level = saveEv.FDBOPFEOENF_diva[OMNOFMEBLAD.HNHCIGMKPDC_DivaIds[0] - 1].IDIDIJGPPIO_vo_lv;
			CMCEGEKGEEP.EACDINDLGLF_Voice.CIEOBFIIPLD_Level = sDiva.HDPANGMKKCP_EvVoLevel;
			CMCEGEKGEEP.EACDINDLGLF_Voice.CMCKNKKCNDK_status = dInfo.JLJGCBOHJID_Status.vocal;
			CMCEGEKGEEP.LDLHPACIIAB_Charm.FKAOJEMHAKN_LevelExp = charmV3;
			CMCEGEKGEEP.LDLHPACIIAB_Charm.LKIFDCEKDCK_exp = saveEv.FDBOPFEOENF_diva[OMNOFMEBLAD.HNHCIGMKPDC_DivaIds[0] - 1].BCANABIAIIP_ch_exp;
			CMCEGEKGEEP.LDLHPACIIAB_Charm.GLFIELJJDCI_Level = saveEv.FDBOPFEOENF_diva[OMNOFMEBLAD.HNHCIGMKPDC_DivaIds[0] - 1].OMOIGFMNFJB_ch_lv;
			CMCEGEKGEEP.LDLHPACIIAB_Charm.CIEOBFIIPLD_Level = sDiva.FFMLBEEBHDD_EvChLevel;
			CMCEGEKGEEP.LDLHPACIIAB_Charm.CMCKNKKCNDK_status = dInfo.JLJGCBOHJID_Status.charm;
			if(!_IKGLAFOHGDO_TestOnly)
			{
				int diff = CMCEGEKGEEP.MKMIEGPOKGG_Soul.CIEOBFIIPLD_Level - CMCEGEKGEEP.MKMIEGPOKGG_Soul.KFEMFDFPCGO_Level0;
				if(diff > 0)
				{
					do
					{
						HEFIKPAHCIA_UpdateMission(GBNDFCEDNMG.CJDGJFINBFH.EKBKFCOCKPJ_41);
						diff--;
					} while(diff != 0);
				}
				diff = CMCEGEKGEEP.EACDINDLGLF_Voice.CIEOBFIIPLD_Level - CMCEGEKGEEP.EACDINDLGLF_Voice.KFEMFDFPCGO_Level0;
				if(diff > 0)
				{
					do
					{
						HEFIKPAHCIA_UpdateMission(GBNDFCEDNMG.CJDGJFINBFH.NCABFNABDFI_42);
						diff--;
					} while(diff != 0);
				}
				diff = CMCEGEKGEEP.LDLHPACIIAB_Charm.CIEOBFIIPLD_Level - CMCEGEKGEEP.LDLHPACIIAB_Charm.KFEMFDFPCGO_Level0;
				if(diff > 0)
				{
					do
					{
						HEFIKPAHCIA_UpdateMission(GBNDFCEDNMG.CJDGJFINBFH.DIMCIJDJLGK_43);
						diff--;
					} while(diff != 0);
				}
			}
        }
	}

	// // RVA: 0xA278E4 Offset: 0xA278E4 VA: 0xA278E4
	public void FELAPFAOHDG(int _EAIMHLDOBAK_Type, int COGNNFOLJOJ_Lvl, int EHGAGLFLMKG_Exp, int DAOGJPAJMCC_MExp, int JDCFEBMOOMN_GetExp, out int HOOALEIBHEH_EvLv, out int FPECEECJJGO_Exp, out List<int> JDDNDGGIIGJ_Exps, out int MOGHGDGGFLO_Lv)
	{
		FPECEECJJGO_Exp = JDCFEBMOOMN_GetExp + EHGAGLFLMKG_Exp;
		HOOALEIBHEH_EvLv = COGNNFOLJOJ_Lvl;
		MOGHGDGGFLO_Lv = 0;
		JDDNDGGIIGJ_Exps = new List<int>();
		JDDNDGGIIGJ_Exps.Add(DAOGJPAJMCC_MExp);
		if(DAOGJPAJMCC_MExp < 1)
		{
			FPECEECJJGO_Exp = 0;
		}
		else
		{
			int godiva_max_level = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.GDEKCOOBLMA_System.LPJLEHAJADA_GetIntParam("godiva_max_level", IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.OAINIGNLJKC_Diva2.NBJKHMLGNPA());
			int max = Mathf.Max(IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.OAINIGNLJKC_Diva2.NBJKHMLGNPA(), godiva_max_level);
			for(; DAOGJPAJMCC_MExp <= FPECEECJJGO_Exp; )
			{
				COGNNFOLJOJ_Lvl++;
				MOGHGDGGFLO_Lv++;
				HOOALEIBHEH_EvLv = Mathf.Clamp(COGNNFOLJOJ_Lvl, 0, max);
				FPECEECJJGO_Exp -= DAOGJPAJMCC_MExp;
				DAOGJPAJMCC_MExp = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.OAINIGNLJKC_Diva2.OAJOMHOOCJJ(MOGHGDGGFLO_Lv + NNFJAIGDBAO(_EAIMHLDOBAK_Type) + 1);
				if(DAOGJPAJMCC_MExp < 1)
				{
					MOGHGDGGFLO_Lv--;
					FPECEECJJGO_Exp = 0;
					JDDNDGGIIGJ_Exps.Add(DAOGJPAJMCC_MExp);
					return;
				}
				if(max <= HOOALEIBHEH_EvLv)
				{
					MOGHGDGGFLO_Lv--;
					FPECEECJJGO_Exp = 0;
					DAOGJPAJMCC_MExp = 0;
					JDDNDGGIIGJ_Exps.Add(DAOGJPAJMCC_MExp);
					return;
				}
				JDDNDGGIIGJ_Exps.Add(DAOGJPAJMCC_MExp);
			}
		}
	}

	// // RVA: 0xA1976C Offset: 0xA1976C VA: 0xA1976C
	public int NNFJAIGDBAO(int _EAIMHLDOBAK_Type)
	{
		CCBMJNPFPBB_EventGoDiva.KIJJHJHLBAK saveEv = CLELOGKMNCE_GetEventSaveData();
		if(saveEv != null)
		{
			int res = 0;
			for(int i = 0; i < saveEv.FDBOPFEOENF_diva.Count; i++)
			{
				if(_EAIMHLDOBAK_Type == 2)
				{
					res += saveEv.FDBOPFEOENF_diva[i].OMOIGFMNFJB_ch_lv;
				}
				else if(_EAIMHLDOBAK_Type == 1)
				{
					res += saveEv.FDBOPFEOENF_diva[i].IDIDIJGPPIO_vo_lv;
				}
				else if(_EAIMHLDOBAK_Type == 0)
				{
					res += saveEv.FDBOPFEOENF_diva[i].KKGPPDLFDKA_so_lv;
				}
			}
			return res;
		}
		return 0;
	}

	// // RVA: 0xA19528 Offset: 0xA19528 VA: 0xA19528
	public CCBMJNPFPBB_EventGoDiva.KIJJHJHLBAK CLELOGKMNCE_GetEventSaveData()
	{
		LNELCMNJPIC_EventGoDiva dbSection = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.LBDOLHGDIEB_Find(JOPOPMLFINI_QuestName) as LNELCMNJPIC_EventGoDiva;
		if(dbSection != null)
		{
			return CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_PlayerData.JMPNGBGNCFO_EventGoDiva.FBCJICEPLED[dbSection.NGHKJOEDLIP_Settings.MOEKELIIDEO_SaveIdx];
		}
		return null;
	}

	// // RVA: 0xA2067C Offset: 0xA2067C VA: 0xA2067C
	public bool GPGPLIAHGJH(int _AHHJLDLAPAN_DivaId)
	{
		CCBMJNPFPBB_EventGoDiva.KIJJHJHLBAK saveData = CLELOGKMNCE_GetEventSaveData();
		if(saveData != null)
		{
			if(saveData.FDBOPFEOENF_diva[_AHHJLDLAPAN_DivaId - 1].KKGPPDLFDKA_so_lv > 0 || saveData.FDBOPFEOENF_diva[_AHHJLDLAPAN_DivaId - 1].DMDLAIOJKPM_so_exp > 0)
			{
				return true;
			}
			if(saveData.FDBOPFEOENF_diva[_AHHJLDLAPAN_DivaId - 1].IDIDIJGPPIO_vo_lv > 0 || saveData.FDBOPFEOENF_diva[_AHHJLDLAPAN_DivaId - 1].GNBEKAELDMM_vo_exp > 0)
			{
				return true;
			}
			if(saveData.FDBOPFEOENF_diva[_AHHJLDLAPAN_DivaId - 1].OMOIGFMNFJB_ch_lv > 0 || saveData.FDBOPFEOENF_diva[_AHHJLDLAPAN_DivaId - 1].BCANABIAIIP_ch_exp > 0)
			{
				return true;
			}
		}
		return false;
	}

	// // RVA: 0xA27DB0 Offset: 0xA27DB0 VA: 0xA27DB0 Slot: 73
	public override List<string> IJCPBPFEGDM_GetResourcesFilePathList(long _JHNMKKNEENE_Time)
	{
		if(!MNNNLDFNNCD(_JHNMKKNEENE_Time))
			return null;
		List<int> l = HEACCHAKMFG_GetMusicsList();
		if(l.Count > 0)
		{
			int mId = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.IBPAFKKEKNK_Music.NOBCLJIAMLC_GetFreeMusicData(l[0]).DLAEJOBELBH_MusicId;
			List<string> res = SoundResource.CreateBgmFilePathList(IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.IBPAFKKEKNK_Music.IAJLOELFHKC_GetMusicInfo(mId).KKPAHLMJKIH_WavId);
			if(JKIADEKHGLC_TicketItemId != 0)
			{
				res.Add(ItemTextureCache.MakeItemIconTexturePath(JKIADEKHGLC_TicketItemId, 0));
			}
			return res;
		}
		return null;
	}

	// // RVA: 0xA2802C Offset: 0xA2802C VA: 0xA2802C Slot: 74
	public override int EDNMFMBLCGF_GetWavId()
	{
		List<int> l = HEACCHAKMFG_GetMusicsList();
		if(l.Count > 0)
		{
			int mId = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.IBPAFKKEKNK_Music.NOBCLJIAMLC_GetFreeMusicData(l[0]).DLAEJOBELBH_MusicId;
			return IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.IBPAFKKEKNK_Music.IAJLOELFHKC_GetMusicInfo(mId).KKPAHLMJKIH_WavId;
		}
		return 0;
	}

	// // RVA: 0xA281F4 Offset: 0xA281F4 VA: 0xA281F4 Slot: 38
	public override void EMEPJNLHJHJ(int GJEADBKFAPA, int _AKNELONELJK_difficulty, bool _GIKLNODJKFK_IsLine6, ref int APMGOLOPLFP, ref int FBBDNLAMPMH)
	{
		LNELCMNJPIC_EventGoDiva ev = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.LBDOLHGDIEB_Find(JOPOPMLFINI_QuestName) as LNELCMNJPIC_EventGoDiva;
		if(ev != null)
		{
			APMGOLOPLFP = _GIKLNODJKFK_IsLine6 ? ev.GKCBPNPEJJF[GJEADBKFAPA + _AKNELONELJK_difficulty - 1].KFCIJBLDHOK_v1 : ev.ADPFKHEMNBL[GJEADBKFAPA + _AKNELONELJK_difficulty - 1].KFCIJBLDHOK_v1;
			FBBDNLAMPMH = _GIKLNODJKFK_IsLine6 ? ev.GKCBPNPEJJF[GJEADBKFAPA + _AKNELONELJK_difficulty - 1].JLEIHOEGMOP_v2 : ev.ADPFKHEMNBL[GJEADBKFAPA + _AKNELONELJK_difficulty - 1].JLEIHOEGMOP_v2;
		}
	}

	// // RVA: 0xA283F4 Offset: 0xA283F4 VA: 0xA283F4 Slot: 76
	public override void MMIMJPNLKBK()
	{
		if(GFHKFKHBIGM)
		{
			LNELCMNJPIC_EventGoDiva ev = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.LBDOLHGDIEB_Find(JOPOPMLFINI_QuestName) as LNELCMNJPIC_EventGoDiva;
			if(ev != null)
			{
				CCBMJNPFPBB_EventGoDiva.KIJJHJHLBAK saveEv = CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_PlayerData.JMPNGBGNCFO_EventGoDiva.FBCJICEPLED[ev.NGHKJOEDLIP_Settings.MOEKELIIDEO_SaveIdx];
				saveEv.INLNJOGHLJE_Show = (int)(saveEv.INLNJOGHLJE_Show & 0xfffffffb);
				GFHKFKHBIGM = false;
			}
		}
	}

	// // RVA: 0xA28670 Offset: 0xA28670 VA: 0xA28670 Slot: 77
	public override string DBEMCLMPCFA_GetBannerText()
	{
		long t = NKGJPJPHLIF.HHCJCDFCLOB.IBLPICFDGOF_ServerRequester.FJDBNGEPKHL_Time.KMEFBNBFJHI_GetServerTime();
		int v = GNDOGPBIGIL_GetCurrentBonusRate(t);
		if(v > 0)
		{
			return MessageManager.Instance.GetMessage("menu", "banner_godiva_fevertime");
		}
		LNELCMNJPIC_EventGoDiva ev = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.LBDOLHGDIEB_Find(JOPOPMLFINI_QuestName) as LNELCMNJPIC_EventGoDiva;
		if(ev != null)
		{
			for(int i = 0; i < ev.LLCLJBEJOPM_BannerInfo.Count; i++)
			{
				if(t >= ev.LLCLJBEJOPM_BannerInfo[i].PDBPFJJCADD_open_at && t < ev.LLCLJBEJOPM_BannerInfo[i].FDBNFFNFOND_close_at)
				{
					return ev.LLCLJBEJOPM_BannerInfo[i].KLMPFGOCBHC_description;
				}
			}
		}
		return "";
	}

	// // RVA: 0xA28A60 Offset: 0xA28A60 VA: 0xA28A60 Slot: 78
	public override long OEGAJJANHGL()
	{
		LNELCMNJPIC_EventGoDiva ev = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.LBDOLHGDIEB_Find(JOPOPMLFINI_QuestName) as LNELCMNJPIC_EventGoDiva;
		if(ev != null)
		{
			return ev.NGHKJOEDLIP_Settings.JBFDHOIKAIK_InventoryEndDate;
		}
		return 0;
	}

	// // RVA: 0xA23598 Offset: 0xA23598 VA: 0xA23598
	public List<IBNAEKMCIEO> IHELCODOPJF()
	{
		List<IBNAEKMCIEO> res = new List<IBNAEKMCIEO>();
        CCBMJNPFPBB_EventGoDiva.KIJJHJHLBAK data = CLELOGKMNCE_GetEventSaveData();
		if(data.JHKKAKJCJOF_Bns2 > 0)
		{
			IBNAEKMCIEO ib = NLPCPFCIDLM(data.JHKKAKJCJOF_Bns2, true);
			if(ib != null)
				res.Add(ib);
		}
		if(data.KAPGPAMOKDD_Bns1 > 0)
		{
			IBNAEKMCIEO ib = NLPCPFCIDLM(data.KAPGPAMOKDD_Bns1, false);
			if(ib != null)
				res.Add(ib);
		}
		return res;
    }

	// // RVA: 0xA274E4 Offset: 0xA274E4 VA: 0xA274E4
	public IBNAEKMCIEO NLPCPFCIDLM(int _KPEKOOCPKID_BonusId, bool _CGHNCPEKOCK_IsDaily)
	{
		LNELCMNJPIC_EventGoDiva ev = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.LBDOLHGDIEB_Find(JOPOPMLFINI_QuestName) as LNELCMNJPIC_EventGoDiva;
		if(ev != null)
		{
			LNELCMNJPIC_EventGoDiva.BGDLJMBDNOL d = ev.DLEFGPMFCMA.Find((LNELCMNJPIC_EventGoDiva.BGDLJMBDNOL _GHPLINIACBB_x) =>
			{
				//0xA2AC04
				return _KPEKOOCPKID_BonusId == _GHPLINIACBB_x.PPFNGGCBJKC_id;
			});
			if(d != null)
			{
				IBNAEKMCIEO d2 = new IBNAEKMCIEO();
				d2.PPFNGGCBJKC_id = _KPEKOOCPKID_BonusId;
				d2.NOEFINFEMBM = d.LJELGFAFGAB_so;
				d2.PKDAEFIGMLI = d.KNEDJFLCCLN_vo;
				d2.CGHNCPEKOCK_IsDaily = _CGHNCPEKOCK_IsDaily;
				d2.DGAELGEJPNA = d.MBAMIOJNGBD_ch;
				return d2;
			}
		}
		return null;
	}

	// // RVA: 0xA26E48 Offset: 0xA26E48 VA: 0xA26E48
	public LNELCMNJPIC_EventGoDiva.DPKGKNJBFBJ NJGBKGKFOED(int _GHBPLHBNMBK_FreeMusicId, long _JHNMKKNEENE_Time)
	{
		LNELCMNJPIC_EventGoDiva ev = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.LBDOLHGDIEB_Find(JOPOPMLFINI_QuestName) as LNELCMNJPIC_EventGoDiva;
		int mId = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.IBPAFKKEKNK_Music.GEAANLPDJBP_FreeMusicData[_GHBPLHBNMBK_FreeMusicId - 1].DLAEJOBELBH_MusicId;
		int GBPDIFGKKIP = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.IBPAFKKEKNK_Music.EPMMNEFADAP_Music[mId - 1].ACPKFNNONMH_Exp;
		int MFGBLBMHIKD = 0;
        List<LNELCMNJPIC_EventGoDiva.POLLFBLLAHL> l = ev.EAPOKGEIFKA.FindAll((LNELCMNJPIC_EventGoDiva.POLLFBLLAHL _GHPLINIACBB_x) =>
		{
			//0xA2AC48
			return _GHPLINIACBB_x.PPFNGGCBJKC_id == GBPDIFGKKIP;
		});
		for(int i = 0; i < l.Count; i++)
		{
			//LAB_00a27250
			if((l[i].PDBPFJJCADD_open_at == 0 && l[i].FDBNFFNFOND_close_at == 0) || (_JHNMKKNEENE_Time >= l[i].PDBPFJJCADD_open_at && l[i].FDBNFFNFOND_close_at >= _JHNMKKNEENE_Time))
			{
				//LAB_00a27358
				MFGBLBMHIKD = l[i].JBGEEPFKIGG_val;
				break;
			}
		}
		//LAB_00a273a4
		return ev.AEHKHFCKHJH.Find((LNELCMNJPIC_EventGoDiva.DPKGKNJBFBJ _GHPLINIACBB_x) =>
		{
			//0xA2AC8C
			return _GHPLINIACBB_x.PPFNGGCBJKC_id == MFGBLBMHIKD;
		});
    }

	// // RVA: 0xA26618 Offset: 0xA26618 VA: 0xA26618
	public int BDIJPOGEGNB(int _GHBPLHBNMBK_FreeMusicId, int _AKNELONELJK_difficulty)
	{
		IBJAKJJICBC ib = new IBJAKJJICBC();
		ib.KHEKNNFCAOI_Init(_GHBPLHBNMBK_FreeMusicId, false, 0, 0, 0, PJLNJJIBFBN_HasExtremeDiff, false, false);
		int score = ib.MGJKEJHEBPO_Blocks[_AKNELONELJK_difficulty].CIEOBFIIPLD_Level;
		LNELCMNJPIC_EventGoDiva ev = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.LBDOLHGDIEB_Find(JOPOPMLFINI_QuestName) as LNELCMNJPIC_EventGoDiva;
		return ev.CDMAJPFOLKK[score - 1].LKIFDCEKDCK_exp;
	}

	// // RVA: 0xA26AF0 Offset: 0xA26AF0 VA: 0xA26AF0
	public int HODCLEPALGP(int _GHBPLHBNMBK_FreeMusicId, int _AKNELONELJK_difficulty)
	{
		IBJAKJJICBC ib = new IBJAKJJICBC();
		ib.KHEKNNFCAOI_Init(_GHBPLHBNMBK_FreeMusicId, false, 0, 0, 0, PJLNJJIBFBN_HasExtremeDiff, false, false);
		LNELCMNJPIC_EventGoDiva ev = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.LBDOLHGDIEB_Find(JOPOPMLFINI_QuestName) as LNELCMNJPIC_EventGoDiva;
		return ev.CDMAJPFOLKK[ib.MGJKEJHEBPO_Blocks[_AKNELONELJK_difficulty].CIEOBFIIPLD_Level - 1].DKHIHHMOIKM_bns;
	}

	// // RVA: 0xA22E44 Offset: 0xA22E44 VA: 0xA22E44
	private int FDMOAACBEGJ(int _KBBOPKDLHHJ_BonusMusicProbaAfter, bool _CGHNCPEKOCK_IsDaily, int _EAIMHLDOBAK_Type/* = -1*/)
	{
		LNELCMNJPIC_EventGoDiva ev = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.LBDOLHGDIEB_Find(JOPOPMLFINI_QuestName) as LNELCMNJPIC_EventGoDiva;
		if(ev != null)
		{
			if(ev.NGHKJOEDLIP_Settings != null)
			{
				int v = UnityEngine.Random.Range(0, 100);
				if(v < _KBBOPKDLHHJ_BonusMusicProbaAfter)
				{
					List<LNELCMNJPIC_EventGoDiva.BGDLJMBDNOL> l = new List<LNELCMNJPIC_EventGoDiva.BGDLJMBDNOL>();
					int i30 = 0;
					for(int i = 0; i < ev.DLEFGPMFCMA.Count; i++)
					{
						if(ev.DLEFGPMFCMA[i].EJFAEKPGKNJ_daily == _CGHNCPEKOCK_IsDaily)
						{
							if(_EAIMHLDOBAK_Type == 2)
							{
								if(ev.DLEFGPMFCMA[i].MBAMIOJNGBD_ch < 1)
									continue;
							}
							else if(_EAIMHLDOBAK_Type == 1)
							{
								if(ev.DLEFGPMFCMA[i].KNEDJFLCCLN_vo < 1)
									continue;
							}
							else if(_EAIMHLDOBAK_Type == 0)
							{
								if(ev.DLEFGPMFCMA[i].LJELGFAFGAB_so < 1)
									continue;
							}
							i30 += ev.DLEFGPMFCMA[i].OMCOIBDHOCF;
							l.Add(ev.DLEFGPMFCMA[i]);
						}
					}
					int v2 = UnityEngine.Random.Range(0, i30);
					int i10 = 0;
					for(int i = 0; i < l.Count; i++)
					{
						if(i10 <= v2 && v2 < i10 + l[i].OMCOIBDHOCF)
						{
							return l[i].PPFNGGCBJKC_id;
						}
						i10 += l[i].OMCOIBDHOCF;
					}
				}
			}
		}
		return 0;
	}

	// // RVA: 0xA23758 Offset: 0xA23758 VA: 0xA23758
	private void PCBIJCAIPAG(int PHALIBJGDNK)
	{
		CCBMJNPFPBB_EventGoDiva.KIJJHJHLBAK saveData = CLELOGKMNCE_GetEventSaveData();
		if(saveData != null)
		{
			saveData.PFPGHILKGIG_BnsCnt = Mathf.Max(1 - PHALIBJGDNK + saveData.PFPGHILKGIG_BnsCnt, 0);
		}
	}
}
