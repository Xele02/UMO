
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
			private int FBGGEFFJJHB; // 0x8
			private int AADPAJOLEEF_Crypted; // 0xC
			private int PEBHLFLDIGC_Crypted; // 0x10
			private int LAPPOAFOPND_Crypted; // 0x14
			private int OJLAFKPHLJD_Crypted; // 0x18
			private int NFCALENBIBL_Crypted; // 0x1C
			private int OEPBLDJHGBB_Crypted; // 0x20
			private int OAOEKMKPEMI_Crypted; // 0x24
			private int KIFFCIMABMI_Crypted; // 0x28
			private int PBKHPPHHFDN_Crypted; // 0x2C
			private int PAAEHHEKEHC_Crypted; // 0x34
			private int NLBLLLLBHOP_Crypted; // 0x38

			public int DNBFMLBNAEE { get { return AADPAJOLEEF_Crypted ^ FBGGEFFJJHB; } set { AADPAJOLEEF_Crypted = value ^ FBGGEFFJJHB; } } //0xA278B4 JKHIIAEMMDE 0xA27864 PFFKLBLEPKB
			public int DJJGNDCMNHF_BonusExp { get { return PEBHLFLDIGC_Crypted ^ FBGGEFFJJHB; } set { PEBHLFLDIGC_Crypted = value ^ FBGGEFFJJHB; } } //0xA27854 GEPCOAPEAJM 0xA26AE0 MIFJBBAJAJP
			public int JDCFEBMOOMN_GetExp { get { return LAPPOAFOPND_Crypted ^ FBGGEFFJJHB; } set { LAPPOAFOPND_Crypted = value ^ FBGGEFFJJHB; } } //0xA278D4 EAHBOFPLEJF 0xA278C4 NKOONIDGLGF
			public int KFEMFDFPCGO_BeforeLevel { get { return OJLAFKPHLJD_Crypted ^ FBGGEFFJJHB; } set { OJLAFKPHLJD_Crypted = value ^ FBGGEFFJJHB; } } //0xA27DA0 BJAONJMLNCL 0xA27894 EIBGPAIINPH
			public int CIEOBFIIPLD_AfterLevel { get { return NFCALENBIBL_Crypted ^ FBGGEFFJJHB; } set { NFCALENBIBL_Crypted = value ^ FBGGEFFJJHB; } } //0xA27D90 OGKGFGMKPKB 0xA27D70 JOOMBHHPHBD
			public int AKPPMDMNOHL_StartLevel { get { return OEPBLDJHGBB_Crypted ^ FBGGEFFJJHB; } set { OEPBLDJHGBB_Crypted = value ^ FBGGEFFJJHB; } } //0xA2C8E4 INIGINPNMIE 0xA27884 BCFPCPDJABC
			public int GLFIELJJDCI_Level { get { return OAOEKMKPEMI_Crypted ^ FBGGEFFJJHB; } set { OAOEKMKPEMI_Crypted = value ^ FBGGEFFJJHB; } } //0xA2C8F4 GIOFIJGKHFK 0xA27D60 ACNICMCBEIF
			public int EJOHDINLOAJ_PrevExp { get { return KIFFCIMABMI_Crypted ^ FBGGEFFJJHB; } set { KIFFCIMABMI_Crypted = value ^ FBGGEFFJJHB; } } //0xA2C904 PFOJDKMDLCA 0xA27874 CJMCKEKMKGM
			public int LKIFDCEKDCK_NextExp { get { return PBKHPPHHFDN_Crypted ^ FBGGEFFJJHB; } set { PBKHPPHHFDN_Crypted = value ^ FBGGEFFJJHB; } } //0xA2C914 GOKMANFHFPC 0xA27D50 ICJKOKGFNLI
			public List<int> FKAOJEMHAKN_LevelExp { get; set; } // 0x30 PKLHMHKAHNJ EMPBECLMHKJ DBPCENDADCJ
			public int NMJIKIJLAMP_BeforeValue { get { return PAAEHHEKEHC_Crypted ^ FBGGEFFJJHB; } set { PAAEHHEKEHC_Crypted = value ^ FBGGEFFJJHB; } } //0xA2C92C MGHMNJCGPBA 0xA278A4 MFHANNLGJBB
			public int CMCKNKKCNDK_AfterValue { get { return NLBLLLLBHOP_Crypted ^ FBGGEFFJJHB; } set { NLBLLLLBHOP_Crypted = value ^ FBGGEFFJJHB; } } //0xA2C93C CNKGOPKANGF 0xA27D80 CHJGGLFGALP

			// // RVA: 0xA2C8B4 Offset: 0xA2C8B4 VA: 0xA2C8B4
			public void KHEKNNFCAOI(int KNEFBLHBDBG)
			{
				FBGGEFFJJHB = KNEFBLHBDBG;
				EJOHDINLOAJ_PrevExp = 0;
				LKIFDCEKDCK_NextExp = 0;
				NMJIKIJLAMP_BeforeValue = 0;
				CMCKNKKCNDK_AfterValue = 0;
				KFEMFDFPCGO_BeforeLevel = 0;
				CIEOBFIIPLD_AfterLevel = 0;
				AKPPMDMNOHL_StartLevel = 0;
				GLFIELJJDCI_Level = 0;
				DNBFMLBNAEE = 0;
				DJJGNDCMNHF_BonusExp = 0;
				JDCFEBMOOMN_GetExp = 0;
			}
		}

		private int FBGGEFFJJHB; // 0x8
		private int GKLNGLHPNMK_Crypted; // 0xC
		private int DGLKNBPHFJA_Crypted; // 0x10
		private int NBOLDNMPJFG_Crypted; // 0x14
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

		public int OENBOLPDBAB_FreeMusicId { get { return GKLNGLHPNMK_Crypted ^ FBGGEFFJJHB; } set { GKLNGLHPNMK_Crypted = value ^ FBGGEFFJJHB; } } //0xA26A40 IMKAINEGNOH 0xA269E0 KHLDCDEGIEG
		public int EJDJIBPKKNO_BasePoint { get { return DGLKNBPHFJA_Crypted ^ FBGGEFFJJHB; } set { DGLKNBPHFJA_Crypted = value ^ FBGGEFFJJHB; } } //0xA26980 HDENOKICDAI 0xA26960 IOMAGMBLBOE
		public int KNIFCANOHOC_Score { get { return NBOLDNMPJFG_Crypted ^ FBGGEFFJJHB; } set { NBOLDNMPJFG_Crypted = value ^ FBGGEFFJJHB; } } //0xA2C6F0 EOJEPLIPOMJ 0xA265C8 AEEMBPAEAAI
		public int JBJJFDIHKMB_ScoreBonus { get { return IJHLNEJFMNB_Crypted ^ FBGGEFFJJHB; } set { IJHLNEJFMNB_Crypted = value ^ FBGGEFFJJHB; } } //0xA26990 OJAKCDKDJOP 0xA265D8 AKCBKALINGO
		public int LIPIAPOGHIP_EpBonus { get { return DHPBINLHAMJ_Crypted ^ FBGGEFFJJHB; } set { DHPBINLHAMJ_Crypted = value ^ FBGGEFFJJHB; } } //0xA2C700 BFBKHCJDJCE 0xA265E8 CNIOHNEEAEO
		public int PFJMBKBEFMA_EpRate { get { return KLEBOEEDMNL_Crypted ^ FBGGEFFJJHB; } set { KLEBOEEDMNL_Crypted = value ^ FBGGEFFJJHB; } } //0xA26608 HOHDIJAFKJK 0xA265F8 IKLBIGHPPKP
		public int JKFCHNEININ_GetPoint { get { return HFGCAKNNLCH_Crypted ^ FBGGEFFJJHB; } set { HFGCAKNNLCH_Crypted = value ^ FBGGEFFJJHB; } } //0xA269B0 FMNLKIKCBNO 0xA269A0 NNIFEOOBCCP
		public int AHOKAPCGJMA_EndPoint { get { return HJOJJCKDPPJ_Crypted ^ FBGGEFFJJHB; } set { HJOJJCKDPPJ_Crypted = value ^ FBGGEFFJJHB; } } //0xA2C710 GKLPFHEELGM 0xA269D0 EJPEPBGDDJM
		public int AONOCELOCLL_BonusMusicProbaBefore { get { return CGPODGLAFCL_Crypted ^ FBGGEFFJJHB; } set { CGPODGLAFCL_Crypted = value ^ FBGGEFFJJHB; } } //0xA2C720 OALCPMNOHHE 0xA26A70 CNJIFLKBCJG
		public int KBBOPKDLHHJ_BonusMusicProbaAfter { get { return PKLPABPJOLB_Crypted ^ FBGGEFFJJHB; } set { PKLPABPJOLB_Crypted = value ^ FBGGEFFJJHB; } } //0xA274AC KKODCEEMDKL 0xA26E38 KPBBACHPAHM
		public int KPEKOOCPKID_BonusId { get { return GPPIKDNLBGI_Crypted ^ FBGGEFFJJHB; } set { GPPIKDNLBGI_Crypted = value ^ FBGGEFFJJHB; } } //0xA2381C ECDMMNLDNKN 0xA23558 DDDEIFADLOK
		public bool DEFAOMCNGAJ_IsBonusDaily { get { return FJDEHCNKKBF_Crypted == 117; } set { FJDEHCNKKBF_Crypted = (sbyte)(value ? 117 : 56); } } //0xA274D0 NNHFPCPPPGI 0xA23568 MAMJOCOLGHG
		public bool JGBIFJLPCHM_IsBonusStart { get { return GINIAGEHMOO_Crypted == 66; } set { GINIAGEHMOO_Crypted = (sbyte)(value ? 66 : 22); } } //0xA274BC PCINHAPINOB 0xA26A80 KNIMMDOLLFE
		public bool IMDPOICJKLF_IsBonusEnd { get { return IGKFNPJDOLM_Crypted == 66; } set { IGKFNPJDOLM_Crypted = (sbyte)(value ? 66 : 22); } } //0xA2C730 HMMMAABCFOK 0xA26AB0 FIKAOOKFJBP
		public int LMBFJMBIIGN { get { return PJDFBHDLEJN_Crypted ^ FBGGEFFJJHB; } set { PJDFBHDLEJN_Crypted = value ^ FBGGEFFJJHB; } } //0xA26A50 ICIPPPBGIDF 0xA269F0 LLMBFMNCOBK
		public int JLIKEOKBBAM_HighScore { get { return FEHNEAACGNC_Crypted ^ FBGGEFFJJHB; } set { FEHNEAACGNC_Crypted = value ^ FBGGEFFJJHB; } } //0xA26A60 LMFAPBIPBHF 0xA26A00 AJMECFJJFJI
		public bool FFHMPNGJCLK_NewRecode { get { return EJPAGBKMOOG_Crypted == 119; } set { EJPAGBKMOOG_Crypted = (sbyte)(value ? 119 : 105); } } //0xA2C744 CMHNAFLEENF 0xA26A10 OEPHKBJBDPO
		public int FCLGIPFPIPH { get { return KIHLOJGPFII_Crypted ^ FBGGEFFJJHB; } set { KIHLOJGPFII_Crypted = value ^ FBGGEFFJJHB; } } //0xA269C0 GHFOOLBCDBM 0xA26970 EFACKLMPIOD

		// // RVA: 0xA2C758 Offset: 0xA2C758 VA: 0xA2C758
		public void KHEKNNFCAOI(int KNEFBLHBDBG)
		{
			FBGGEFFJJHB = KNEFBLHBDBG;
			AHOKAPCGJMA_EndPoint = 0;
			KBBOPKDLHHJ_BonusMusicProbaAfter = 0;
			KPEKOOCPKID_BonusId = 0;
			JBJJFDIHKMB_ScoreBonus = 0;
			LIPIAPOGHIP_EpBonus = 0;
			PFJMBKBEFMA_EpRate = 0;
			JKFCHNEININ_GetPoint = 0;
			OENBOLPDBAB_FreeMusicId = 0;
			EJDJIBPKKNO_BasePoint = 0;
			KNIFCANOHOC_Score = 0;
			IMDPOICJKLF_IsBonusEnd = false;
			DEFAOMCNGAJ_IsBonusDaily = false;
			JGBIFJLPCHM_IsBonusStart = false;
			JLIKEOKBBAM_HighScore = 0;
			FCLGIPFPIPH = 0;
			FFHMPNGJCLK_NewRecode = false;
			LFGNLKKFOCD_IsLine6 = false;
			MKMIEGPOKGG_Soul.KHEKNNFCAOI(KNEFBLHBDBG);
			EACDINDLGLF_Voice.KHEKNNFCAOI(KNEFBLHBDBG);
			LDLHPACIIAB_Charm.KHEKNNFCAOI(KNEFBLHBDBG);
		}

		// RVA: 0xA16A40 Offset: 0xA16A40 VA: 0xA16A40
		public OCGMIDIINLL()
		{
			KHEKNNFCAOI((int)Utility.GetCurrentUnixTime() ^ 0x6785126);
		}
	}

	public class IBNAEKMCIEO
	{
		private int FBGGEFFJJHB; // 0x8
		private int EHOIENNDEDH_Crypted; // 0xC
		private int AMDBHBCFJEM_Crypted; // 0x10
		private int MCNAMIDDKIC_Crypted; // 0x14
		private int LNCNCKAHBLN_Crypted; // 0x18
		private sbyte KGNLNEMBLGF_Crypted; // 0x1C

		public int PPFNGGCBJKC { get { return EHOIENNDEDH_Crypted ^ FBGGEFFJJHB; } set { EHOIENNDEDH_Crypted = value ^ FBGGEFFJJHB; } } //0xA23734 DEMEPMAEJOO 0xA28CB4 HIGKAIDMOKN
		public int NOEFINFEMBM { get { return AMDBHBCFJEM_Crypted ^ FBGGEFFJJHB; } set { AMDBHBCFJEM_Crypted = value ^ FBGGEFFJJHB; } } //0xA27824 DBPGDHLPECI 0xA28CC4 HMKBICIJGHP
		public int PKDAEFIGMLI { get { return MCNAMIDDKIC_Crypted ^ FBGGEFFJJHB; } set { MCNAMIDDKIC_Crypted = value ^ FBGGEFFJJHB; } } //0xA27834 IJNEJAPCHKO 0xA28CD4 NEJLFMGNPKL
		public int DGAELGEJPNA { get { return LNCNCKAHBLN_Crypted ^ FBGGEFFJJHB; } set { LNCNCKAHBLN_Crypted = value ^ FBGGEFFJJHB; } } //0xA27844 PFHFFFDPPJD 0xA28CE4 GNCIPLCPHON
		public bool CGHNCPEKOCK { get { return KGNLNEMBLGF_Crypted == 42; } set { KGNLNEMBLGF_Crypted = (sbyte)(value ? 42 : 193); } } //0xA23744 OFIKFHIBLLP 0xA28CF4 NGIBLJJHMFE

		// // RVA: 0xA2C6B8 Offset: 0xA2C6B8 VA: 0xA2C6B8
		// public void KHEKNNFCAOI(int KNEFBLHBDBG) { }

		// RVA: 0xA28BF4 Offset: 0xA28BF4 VA: 0xA28BF4
		public IBNAEKMCIEO()
		{
			FBGGEFFJJHB = (int)Utility.GetCurrentUnixTime() ^ 0xa82d501;
			PPFNGGCBJKC = 0;
			NOEFINFEMBM = 0;
			PKDAEFIGMLI = 0;
			DGAELGEJPNA = 0;
			CGHNCPEKOCK = false;
		}
	}

	private const int GHJHJDIDCFA = 3;
	private List<LNELCMNJPIC_EventGoDiva.HGLNJDGOPMM> NFMDLCBJOIB_SongCacheList = new List<LNELCMNJPIC_EventGoDiva.HGLNJDGOPMM>(); // 0xE8
	private EECOJKDJIFG[] KBACNOCOANM = new EECOJKDJIFG[10]; // 0xEC
	public bool KIBBLLADDPO; // 0xF0
	public OCGMIDIINLL CMCEGEKGEEP = new OCGMIDIINLL(); // 0xF4

	public override OHCAABOMEOF.KGOGMKMBCPP_EventType HIDHLFCBIDE_EventType { get { return OHCAABOMEOF.KGOGMKMBCPP_EventType.BNECMLPHAGJ_EventGoDiva; } } //0xA168C0 DKHCGLCNKCD Slot: 4

	// // RVA: 0xA168C8 Offset: 0xA168C8 VA: 0xA168C8 Slot: 32
	public override EECOJKDJIFG DAKMIKNKHMF_GetRankingInfoForIndex(int LHJCOPMMIGO)
	{
		if(LHJCOPMMIGO >= NGIHFKHOJOK_GetRankingMax(true))
			return null;
		return KBACNOCOANM[LHJCOPMMIGO];
	}

	// RVA: 0xA1693C Offset: 0xA1693C VA: 0xA1693C
	public MANPIONIGNO_EventGoDiva(string OPFGFINHFCE) : base(OPFGFINHFCE)
    {
        CMEOKJMCEBH = true;
    }

	// // RVA: 0xA16B34 Offset: 0xA16B34 VA: 0xA16B34 Slot: 5
	public override string IFKKBHPMALH()
	{
		LNELCMNJPIC_EventGoDiva ev = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.LBDOLHGDIEB_GetDbSection(JOPOPMLFINI_QuestId) as LNELCMNJPIC_EventGoDiva;
		if(ev != null)
		{
			return ev.NGHKJOEDLIP.OCDMGOGMHGE_AchievementIdPrefix;
		}
		return null;
	}

	// // RVA: 0xA16CBC Offset: 0xA16CBC VA: 0xA16CBC
	private List<LNELCMNJPIC_EventGoDiva.HGLNJDGOPMM> LEAGIGKFMPE_GetSongList()
	{
		LNELCMNJPIC_EventGoDiva ev = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.LBDOLHGDIEB_GetDbSection(JOPOPMLFINI_QuestId) as LNELCMNJPIC_EventGoDiva;
		if(ev != null)
		{
			long t = NKGJPJPHLIF.HHCJCDFCLOB.IBLPICFDGOF_ServerRequester.FJDBNGEPKHL.KMEFBNBFJHI_GetServerTime();
			NFMDLCBJOIB_SongCacheList.Clear();
			for(int i = 0; i < ev.IJJHFGOIDOK_Songs.Count; i++)
			{
				if(ev.IJJHFGOIDOK_Songs[i].PLALNIIBLOF_En == 2)
				{
					if((ev.IJJHFGOIDOK_Songs[i].PDBPFJJCADD_OpenAt == 0 && ev.IJJHFGOIDOK_Songs[i].FDBNFFNFOND_CloseAt == 0) || 
						(ev.IJJHFGOIDOK_Songs[i].PDBPFJJCADD_OpenAt <= t && ev.IJJHFGOIDOK_Songs[i].FDBNFFNFOND_CloseAt >= t))
					{
						NFMDLCBJOIB_SongCacheList.Add(ev.IJJHFGOIDOK_Songs[i]);
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
			return LEAGIGKFMPE_GetSongList();
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
				res.Add(l[i].MPLGPBNJDJB_FMusicId);
			}
		}
		return res;
	}

	// // RVA: 0xA172F4 Offset: 0xA172F4 VA: 0xA172F4 Slot: 9
	public override long HOOBCIIOCJD_GetSongEndTime(int GHBPLHBNMBK)
	{
		List<LNELCMNJPIC_EventGoDiva.HGLNJDGOPMM> l = KOBMFPACBMB_GetCachedSongList();
		if(l != null)
		{
			long t = NKGJPJPHLIF.HHCJCDFCLOB.IBLPICFDGOF_ServerRequester.FJDBNGEPKHL.KMEFBNBFJHI_GetServerTime();
			for(int i = 0; i < l.Count; i++)
			{
				if(l[i].PDBPFJJCADD_OpenAt != 0 && l[i].FDBNFFNFOND_CloseAt != 0 && t >= l[i].PDBPFJJCADD_OpenAt && l[i].FDBNFFNFOND_CloseAt >= t && 
					GHBPLHBNMBK == l[i].MPLGPBNJDJB_FMusicId)
				{
					return l[i].FDBNFFNFOND_CloseAt;
				}
			}
		}
		return base.HOOBCIIOCJD_GetSongEndTime(GHBPLHBNMBK);
	}

	// // RVA: 0xA17624 Offset: 0xA17624 VA: 0xA17624 Slot: 10
	public override bool GIDDKGMPIOK_IsLimited(int GHBPLHBNMBK)
	{
		List<LNELCMNJPIC_EventGoDiva.HGLNJDGOPMM> l = KOBMFPACBMB_GetCachedSongList();
		if(l != null)
		{
			long t = NKGJPJPHLIF.HHCJCDFCLOB.IBLPICFDGOF_ServerRequester.FJDBNGEPKHL.KMEFBNBFJHI_GetServerTime();
			for(int i = 0; i < l.Count; i++)
			{
				if(l[i].PDBPFJJCADD_OpenAt != 0 && l[i].FDBNFFNFOND_CloseAt != 0 && l[i].FDBNFFNFOND_CloseAt < DPJCPDKALGI_End1 && t >= l[i].PDBPFJJCADD_OpenAt && l[i].FDBNFFNFOND_CloseAt >= t && 
					GHBPLHBNMBK == l[i].MPLGPBNJDJB_FMusicId)
				{
					return true;
				}
			}
		}
		return false;
	}

	// // RVA: 0xA17974 Offset: 0xA17974 VA: 0xA17974 // not virtual & not called directly
	/*public int OMJHBJPCFFC(int EHDDADDKMFI)
	{
		TodoLogger.LogError(TodoLogger.EventGoDiva_14, "OMJHBJPCFFC");
		return 0;
	}*/

	// // RVA: 0xA17C88 Offset: 0xA17C88 VA: 0xA17C88 Slot: 27
	public override int HLOGNJNGDJO_GetHelpId(int OIPCCBHIKIA = 0)
	{
		LNELCMNJPIC_EventGoDiva ev = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.LBDOLHGDIEB_GetDbSection(JOPOPMLFINI_QuestId) as LNELCMNJPIC_EventGoDiva;
		if(ev != null)
		{
			return ev.NGHKJOEDLIP.EJBGHLOOLBC_HelpIds[OIPCCBHIKIA];
		}
		return 0;
	}

	// // RVA: 0xA17E44 Offset: 0xA17E44 VA: 0xA17E44 Slot: 67
	// public override int LBNKDKDMMOK() { }

	// // RVA: 0xA17FC8 Offset: 0xA17FC8 VA: 0xA17FC8 Slot: 28
	public override long FBGDBGKNKOD_GetCurrentPoint()
	{
		LNELCMNJPIC_EventGoDiva ev = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.LBDOLHGDIEB_GetDbSection(JOPOPMLFINI_QuestId) as LNELCMNJPIC_EventGoDiva;
		if(ev != null)
		{
			CCBMJNPFPBB_EventGoDiva.KIJJHJHLBAK saveEv = CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave.JMPNGBGNCFO_EventGoDiva.FBCJICEPLED[ev.NGHKJOEDLIP.MOEKELIIDEO_SaveIdx];
			return saveEv.DNBFMLBNAEE_Point;
		}
		return 0;
	}

	// // RVA: 0xA18234 Offset: 0xA18234 VA: 0xA18234
	public long AFCIIKDOMHN_GetCurrentScore(int AHHJLDLAPAN)
	{
		LNELCMNJPIC_EventGoDiva ev = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.LBDOLHGDIEB_GetDbSection(JOPOPMLFINI_QuestId) as LNELCMNJPIC_EventGoDiva;
		if(ev != null)
		{
			CCBMJNPFPBB_EventGoDiva.KIJJHJHLBAK saveEv = CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave.JMPNGBGNCFO_EventGoDiva.FBCJICEPLED[ev.NGHKJOEDLIP.MOEKELIIDEO_SaveIdx];
			return saveEv.LGFFMGDBIAH_Rankings[AHHJLDLAPAN - 1].NANNGLGOFKH_Val;
		}
		return 0;
	}

	// // RVA: 0xA184E8 Offset: 0xA184E8 VA: 0xA184E8 Slot: 29
	public override void MJFKJHJJLMN_GetRanks(int LHJCOPMMIGO = 0, bool FBBNPFFEJBN = false)
	{
		PLOOEECNHFB = false;
		NPNNPNAIONN = false;
		EECOJKDJIFG info = DAKMIKNKHMF_GetRankingInfoForIndex(LHJCOPMMIGO);
		if(info != null)
		{
			LNELCMNJPIC_EventGoDiva ev = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.LBDOLHGDIEB_GetDbSection(JOPOPMLFINI_QuestId) as LNELCMNJPIC_EventGoDiva;
			if(ev != null)
			{
				if(GPHEKCNDDIK)
				{
					bool doRequest = false;
					if(FBBNPFFEJBN || CDINKAANIAA_Rank[LHJCOPMMIGO] < 1)
					{
						doRequest = true;
					}
					else
					{
						long t = NKGJPJPHLIF.HHCJCDFCLOB.IBLPICFDGOF_ServerRequester.FJDBNGEPKHL.KMEFBNBFJHI_GetServerTime();
						int get_rank_cooling_time = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.GDEKCOOBLMA_System.LPJLEHAJADA("get_rank_cooling_time", 60);
						if(t - KPOMHFLKMKI_LastRankUpdateTime[LHJCOPMMIGO] >= get_rank_cooling_time)
						{
							doRequest = true;
						}
						else
						{
							PLOOEECNHFB = true;
							return;
						}
					}
					if(doRequest)
					{
						//LAB_00a188e8
						KKLGENJKEBN.HHCJCDFCLOB.HEOKADCEAGL_GetRanks(info.OCGFKMHNEOF_NameForApi, () =>
						{
							//0xA28D9C
							CDINKAANIAA_Rank[LHJCOPMMIGO] = (int)KKLGENJKEBN.HHCJCDFCLOB.LPPCNCMEDFA_Rank;
							KPOMHFLKMKI_LastRankUpdateTime[LHJCOPMMIGO] = NKGJPJPHLIF.HHCJCDFCLOB.IBLPICFDGOF_ServerRequester.FJDBNGEPKHL.KMEFBNBFJHI_GetServerTime();
							PLOOEECNHFB = true;
						}, () =>
						{
							//0xA28F60
							KPOMHFLKMKI_LastRankUpdateTime[LHJCOPMMIGO] = NKGJPJPHLIF.HHCJCDFCLOB.IBLPICFDGOF_ServerRequester.FJDBNGEPKHL.KMEFBNBFJHI_GetServerTime();
							CDINKAANIAA_Rank[LHJCOPMMIGO] = 0;
							PLOOEECNHFB = true;
						}, () =>
						{
							CDINKAANIAA_Rank[LHJCOPMMIGO] = 0;
							PLOOEECNHFB = true;
							NPNNPNAIONN = true;
							//0xA29108
						}, () =>
						{
							CDINKAANIAA_Rank[LHJCOPMMIGO] = 0;
							PLOOEECNHFB = true;
							NPNNPNAIONN = true;
							//0xA291A0
						});
						return;
					}
				}
			}
		}
		CDINKAANIAA_Rank[LHJCOPMMIGO] = 0;
		PLOOEECNHFB = true;
	}

	// // RVA: 0xA18A44 Offset: 0xA18A44 VA: 0xA18A44 Slot: 30
	protected override bool JIHMLILFOPG_IsEventActive(long JHNMKKNEENE)
	{
		LNELCMNJPIC_EventGoDiva ev = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.LBDOLHGDIEB_GetDbSection(JOPOPMLFINI_QuestId) as LNELCMNJPIC_EventGoDiva;
		if(ev != null)
		{
			GDIPLANPCEI g = IMMAOANGPNK.HHCJCDFCLOB.ACEFBFLFKFD_GetScheduleEventData(ev.JIKKNHIAEKG_BlockName, JHNMKKNEENE);
			if(g != null)
			{
				if(JHNMKKNEENE >= ev.NGHKJOEDLIP.BONDDBOFBND_Start && ev.NGHKJOEDLIP.KNLGKBBIBOH_End >= JHNMKKNEENE)
				{
					if(ev.NGHKJOEDLIP.HKKNEAGCIEB != 0)
					{
						List<string> PDDFOEDNFBN = new List<string>();
						PDDFOEDNFBN.Clear();
						if(ev.NGHKJOEDLIP.MPCAGEPEJJJ_ApiName.Count > 0)
						{
							PDDFOEDNFBN.AddRange(ev.NGHKJOEDLIP.MPCAGEPEJJJ_ApiName);
						}
						for(int i = 0; i < PDDFOEDNFBN.Count; i++)
						{
							if(KKLGENJKEBN.HHCJCDFCLOB.JPDPFGFMKHK.Find((EECOJKDJIFG PKLPKMLGFGK) =>
							{
								//0xA29238
								return PKLPKMLGFGK.OCGFKMHNEOF_NameForApi == PDDFOEDNFBN[i];
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
	protected override bool IMCMNOPNGHO(long JHNMKKNEENE)
	{
		LNELCMNJPIC_EventGoDiva ev = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.LBDOLHGDIEB_GetDbSection(JOPOPMLFINI_QuestId) as LNELCMNJPIC_EventGoDiva;
		if(ev != null)
		{
			CCBMJNPFPBB_EventGoDiva.KIJJHJHLBAK saveEv = CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave.JMPNGBGNCFO_EventGoDiva.FBCJICEPLED[ev.NGHKJOEDLIP.MOEKELIIDEO_SaveIdx];
			AGLILDLEFDK_Missions = ev.NNMPGOAGEOL_Missions;
			OLDFFDMPEBM_Quests = saveEv.NNMPGOAGEOL_Quests;
			if(saveEv.MPCAGEPEJJJ_Key != ev.NGHKJOEDLIP.OCGFKMHNEOF || 
				(!RuntimeSettings.CurrentSettings.UnlimitedEvent && saveEv.EGBOHDFBAPB_End < ev.NGHKJOEDLIP.BONDDBOFBND_Start)
			)
			{
				saveEv.LHPDDGIJKNB();
				saveEv.MPCAGEPEJJJ_Key = ev.NGHKJOEDLIP.OCGFKMHNEOF;
				saveEv.EGBOHDFBAPB_End = ev.NGHKJOEDLIP.IDDBFFBPNGI;
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
			for(int i = 0; i < saveData.FDBOPFEOENF_Divas.Count; i++)
			{
				saveData.FDBOPFEOENF_Divas[i].JDHJEINPJLL_SoMExp = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.OAINIGNLJKC_Diva2.OAJOMHOOCJJ(NNFJAIGDBAO(0) + 1);
				saveData.FDBOPFEOENF_Divas[i].OIMLBHPAMGD_VoMExp = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.OAINIGNLJKC_Diva2.OAJOMHOOCJJ(NNFJAIGDBAO(1) + 1);
				saveData.FDBOPFEOENF_Divas[i].PFDDNKEOKBF_ChMExp = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.OAINIGNLJKC_Diva2.OAJOMHOOCJJ(NNFJAIGDBAO(2) + 1);
			}
		}
	}

	// // RVA: 0xA19950 Offset: 0xA19950 VA: 0xA19950 Slot: 40
	protected override void KKFLDCBHFJA(long JHNMKKNEENE)
	{
		LNELCMNJPIC_EventGoDiva ev = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.LBDOLHGDIEB_GetDbSection(JOPOPMLFINI_QuestId) as LNELCMNJPIC_EventGoDiva;
		if(ev != null)
		{
			IBNKPMPFLGI_IsRankReward = ev.NGHKJOEDLIP.HKKNEAGCIEB != 0;
			if(IBNKPMPFLGI_IsRankReward)
			{
				for(int i = 0; i < ev.NGHKJOEDLIP.MPCAGEPEJJJ_ApiName.Count; i++)
				{
					string OCGFKMHNEOF = ev.NGHKJOEDLIP.MPCAGEPEJJJ_ApiName[i];
					KBACNOCOANM[i] = KKLGENJKEBN.HHCJCDFCLOB.JPDPFGFMKHK.Find((EECOJKDJIFG PKLPKMLGFGK) =>
					{
						//0xA29350
						return PKLPKMLGFGK.OCGFKMHNEOF_NameForApi == OCGFKMHNEOF;
					});
				}
				GPHEKCNDDIK = true;
			}
			DGCOMDILAKM_EventName = ev.NGHKJOEDLIP.OPFGFINHFCE_EventName;
			DOLJEDAAKNN = ev.NGHKJOEDLIP.HEDAGCNPHGD;
			GLIMIGNNGGB_Start = ev.NGHKJOEDLIP.BONDDBOFBND_Start;
			DPJCPDKALGI_End1 = ev.NGHKJOEDLIP.HPNOGLIFJOP_End1;
			LOLAANGCGDO = ev.NGHKJOEDLIP.LNFKGHNHJKE;
			JDDFILGNGFH = ev.NGHKJOEDLIP.JGMDAOACOJF;
			LJOHLEGGGMC = ev.NGHKJOEDLIP.IDDBFFBPNGI;
			EMEKFFHCHMH_End = ev.NGHKJOEDLIP.KNLGKBBIBOH_End;
			PGIIDPEGGPI_EventId = ev.NGHKJOEDLIP.OBGBAOLONDD_EventId;
			NHGPCLGPEHH_TicketType = ev.NGHKJOEDLIP.MJBKGOJBPAD_TicketType;
			FBHONHONKGD_MusicSelectDesc = ev.NGHKJOEDLIP.FEMMDNIELFC_MusicSelectDesc;
			HGLAFGHHFKP = ev.NGHKJOEDLIP.JHPCPNJJHLI;
			GFIBLLLHMPD_StartAdventureId = ev.NGHKJOEDLIP.HIOOGLEJBKM_StartAdvId;
			CAKEOPLJDAF_EndAdventureId = ev.NGHKJOEDLIP.FJCADCDNPMP_EndAdvId;
			LHAKGDAGEMM.Clear();
			for(int i = 0; i < ev.LHAKGDAGEMM.Count; i++)
			{
				CEGDBNNIDIG d = new CEGDBNNIDIG();
				d.KELFCMEOPPM_EpId = ev.LHAKGDAGEMM[i].KHPHAAMGMJP;
				d.MIHNKIHNBBL = ev.LHAKGDAGEMM[i].OFIAENKCJME / 100.0f;
				d.MLLPMJFOKEC.AddRange(ev.LHAKGDAGEMM[i].KDNMBOBEGJM);
				LHAKGDAGEMM.Add(d);
			}
			PGDAMNENGDA.Clear();
			for(int i = 0; i < ev.OGMHMAGDNAM.Count; i++)
			{
				NJJDBBCHBNP d = new NJJDBBCHBNP();
				d.GJEADBKFAPA = ev.OGMHMAGDNAM[i].PPFNGGCBJKC;
				d.IJKFFIKGLJM = ev.OGMHMAGDNAM[i].GNFBMCGMCFO;
				d.DCBMFNOIENM = ev.OGMHMAGDNAM[i].BFFGFAMJAIG;
				PGDAMNENGDA.Add(d);
			}
			DHOMAEOEFMJ.Clear();
			for(int i = 0; i < ev.GEGAEDDGNMA.Count; i++)
			{
				MEBJJBHPMEO d = new MEBJJBHPMEO();
				d.PPFNGGCBJKC = ev.GEGAEDDGNMA[i].PPFNGGCBJKC;
				d.GNFBMCGMCFO = ev.GEGAEDDGNMA[i].GNFBMCGMCFO;
				d.BFFGFAMJAIG = ev.GEGAEDDGNMA[i].BFFGFAMJAIG;
				d.CNKFPJCGNFE = ev.GEGAEDDGNMA[i].CNKFPJCGNFE;
				DHOMAEOEFMJ.Add(d);
			}
			MBHDIJJEOFL = ev.MBHDIJJEOFL;
			for(int i = 0; i < KPOMHFLKMKI_LastRankUpdateTime.Length; i++)
			{
				KPOMHFLKMKI_LastRankUpdateTime[i] = 0;
			}
			if(!string.IsNullOrEmpty(ev.NGHKJOEDLIP.OMCAOJJGOGG))
			{
				string[] strs = ev.NGHKJOEDLIP.OMCAOJJGOGG.Split(new char[]{ ',' });
				BHABCGJCGNO = new MFDJIFIIPJD();
				BHABCGJCGNO.KHEKNNFCAOI(int.Parse(strs[0]), int.Parse(strs[1]));
			}
			MNDFBBMNJGN_IsUsingTicket = false;
			PJLNJJIBFBN = ev.NGHKJOEDLIP.AHKPNPNOAMO != 0;
			ABBOEIPOBLJ_EventTicket.CBDACMFFHJC c = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.KHPOJKHKLEM_EventTicket.CDENCMNHNGA.Find((ABBOEIPOBLJ_EventTicket.CBDACMFFHJC GHPLINIACBB) =>
			{
				//0xA292F4
				return GHPLINIACBB.INDDJNMPONH_Typ == ev.NGHKJOEDLIP.MJBKGOJBPAD_TicketType;
			});
			if(c == null)
				return;
			JKIADEKHGLC_TicketItemId = EKLNMHFCAOI.GJEEGMCBGGM_GetItemFullId(EKLNMHFCAOI.FKGCBLHOOCL_Category.CLMIJKACELE_EventTicket, c.PPFNGGCBJKC_Id);
			LEPALMDKEOK_IsPointReward = true;
		}
	}

	// // RVA: 0xA1AB8C Offset: 0xA1AB8C VA: 0xA1AB8C Slot: 41
	public override int DBOLCELMBJG_GetMainRankingIndex()
	{
		return BAEPGOAMBDK("main_ranking_index", 0);
	}

	// // RVA: 0xA1AC00 Offset: 0xA1AC00 VA: 0xA1AC00 Slot: 42
	public override int DEECKJADNMJ(int LAJNCHHNLBI)
	{
		if(BAEPGOAMBDK("main_ranking_index", 0) != 0)
			return LAJNCHHNLBI == 0 ? 1 : 0;
		return LAJNCHHNLBI;
	}

	// // RVA: 0xA1AC98 Offset: 0xA1AC98 VA: 0xA1AC98 Slot: 43
	protected override void FCHGHAAPIBH()
	{
		LNELCMNJPIC_EventGoDiva NDFIEMPPMLF = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.LBDOLHGDIEB_GetDbSection(JOPOPMLFINI_QuestId) as LNELCMNJPIC_EventGoDiva;
		if(NDFIEMPPMLF != null)
		{
			Dictionary<string,int> DBEKEBNDMBH = new Dictionary<string,int>();
			List<string> ls = new List<string>();
			string str0 = NDFIEMPPMLF.NGHKJOEDLIP.OCDMGOGMHGE_AchievementIdPrefix;
			for(int i = 0; i < NDFIEMPPMLF.FCIPEDFHFEM_Rewards.Count; i++)
			{
				for(int j = 0; j < NDFIEMPPMLF.FCIPEDFHFEM_Rewards[i].AHJNPEAMCCH_Items.Count; j++)
				{
					if(NDFIEMPPMLF.FCIPEDFHFEM_Rewards[i].AHJNPEAMCCH_Items[j].NMKEOMCMIPP_RewardId > 0)
					{
						string s = str0 + NDFIEMPPMLF.FCIPEDFHFEM_Rewards[i].AHJNPEAMCCH_Items[j].NMKEOMCMIPP_RewardId.ToString();
						ls.Add(s);
						DBEKEBNDMBH.Add(s, i);
					}
				}
			}
			if(ls.Count == 0)
			{
				PIMFJALCIGK();
				PLOOEECNHFB = true;
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
					CCBMJNPFPBB_EventGoDiva.KIJJHJHLBAK saveEv = CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave.JMPNGBGNCFO_EventGoDiva.FBCJICEPLED[NDFIEMPPMLF.NGHKJOEDLIP.MOEKELIIDEO_SaveIdx];
					for(int i = 0; i < r.NFEAMMJIMPG.CEDLLCCONJP.Count; i++)
					{
						if(DBEKEBNDMBH.ContainsKey(r.NFEAMMJIMPG.CEDLLCCONJP[i].LJNAKDMILMC_Key))
						{
							if(r.NFEAMMJIMPG.CEDLLCCONJP[i].OOIJCMLEAJP_IsReceived)
							{
								saveEv.LCDIGDMGPGO_TRcv[DBEKEBNDMBH[r.NFEAMMJIMPG.CEDLLCCONJP[i].LJNAKDMILMC_Key]] = 1;
							}
						}
					}
					PIMFJALCIGK();
					PLOOEECNHFB = true;
				};
				req.MOBEEPPKFLG_OnFail = (CACGCMBKHDI_Request NHECPMNKEFK) =>
				{
					//0xA2983C
					PLOOEECNHFB = true;
					NPNNPNAIONN = true;
				};
			}
		}
		else
		{
			PLOOEECNHFB = true;
		}
	}

	// [IteratorStateMachineAttribute] // RVA: 0x6BC734 Offset: 0x6BC734 VA: 0x6BC734
	// // RVA: 0xA1B354 Offset: 0xA1B354 VA: 0xA1B354 Slot: 44
	protected override IEnumerator JEIJKLPOAHP_ReceivePrologueRepeatedAchievement(DJBHIFLHJLK AOCANKOMKFG)
	{
		//0xA2BEC8
		KGBCKPKLKHM_RewardItems.Clear();
		LNELCMNJPIC_EventGoDiva ev = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.LBDOLHGDIEB_GetDbSection(JOPOPMLFINI_QuestId) as LNELCMNJPIC_EventGoDiva;
		if(ev != null)
		{
			string event_prologue_achv_key = ev.EFEGBHACJAL("event_prologue_achv_key", "");
			if(!string.IsNullOrEmpty(event_prologue_achv_key))
			{
				List<string> ls = new List<string>();
				ls.Add(event_prologue_achv_key);
				yield return Co.R(AOGIMHOLIFB_ReceiveLoguinRepetedAchivement(ls, AOCANKOMKFG));
			}
		}
	}

	// [IteratorStateMachineAttribute] // RVA: 0x6BC7AC Offset: 0x6BC7AC VA: 0x6BC7AC
	// // RVA: 0xA1B41C Offset: 0xA1B41C VA: 0xA1B41C Slot: 45
	protected override IEnumerator KPBNMAEHHDF_ReceiveEpilogueRepeatedAchivement(DJBHIFLHJLK AOCANKOMKFG)
	{
		//0xA2BB98
		KGBCKPKLKHM_RewardItems.Clear();
		LNELCMNJPIC_EventGoDiva ev = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.LBDOLHGDIEB_GetDbSection(JOPOPMLFINI_QuestId) as LNELCMNJPIC_EventGoDiva;
		if(ev != null)
		{
			string event_epilogue_achv_key = ev.EFEGBHACJAL("event_epilogue_achv_key", "");
			if(!string.IsNullOrEmpty(event_epilogue_achv_key))
			{
				List<string> ls = new List<string>();
				ls.Add(event_epilogue_achv_key);
				yield return Co.R(AOGIMHOLIFB_ReceiveLoguinRepetedAchivement(ls, AOCANKOMKFG));
			}
		}
	}

	// // RVA: 0xA1B4E4 Offset: 0xA1B4E4 VA: 0xA1B4E4 Slot: 46
	protected override void PJDGDNJNCNM_UpdateStatusImpl(long JHNMKKNEENE)
	{
		KIBBLLADDPO = false;
		NGOFCFJHOMI_Status = KGCNCBOKCBA.GNENJEHKMHD_EventStatus.HJNNKCMLGFL_0;
		LNELCMNJPIC_EventGoDiva ev = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.LBDOLHGDIEB_GetDbSection(JOPOPMLFINI_QuestId) as LNELCMNJPIC_EventGoDiva;
		if(ev != null)
		{
			CCBMJNPFPBB_EventGoDiva.KIJJHJHLBAK saveEv = CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave.JMPNGBGNCFO_EventGoDiva.FBCJICEPLED[ev.NGHKJOEDLIP.MOEKELIIDEO_SaveIdx];
			IBLPKJJNNIG = false;
			BELBNINIOIE = false;
			if(JHNMKKNEENE >= GLIMIGNNGGB_Start)
			{
				if(DPJCPDKALGI_End1 >= JHNMKKNEENE)
				{
					if(MBHDIJJEOFL != null)
					{
						for(int i = 0; i < MBHDIJJEOFL.Count; i++)
						{
							if(MBHDIJJEOFL[i].MAFAIIHJAFG == 0)
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
						if(JHNMKKNEENE < ev.NGHKJOEDLIP.EHHFFKAFOMC)
						{
							return;
						}
						KIBBLLADDPO = true;
						if(MBHDIJJEOFL != null)
						{
							for(int i = 0; i < MBHDIJJEOFL.Count; i++)
							{
								if(MBHDIJJEOFL[i].MAFAIIHJAFG == 1)
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
								if(MBHDIJJEOFL[i].MAFAIIHJAFG == 1)
								{
									BELBNINIOIE = true;
									break;
								}
							}
						}
						return;
					}
					if(JHNMKKNEENE >= ev.NGHKJOEDLIP.EHHFFKAFOMC)
					{
						NGOFCFJHOMI_Status = KGCNCBOKCBA.GNENJEHKMHD_EventStatus.GDOPLACICFE_4;
						KIBBLLADDPO = true;
						if(MBHDIJJEOFL != null)
						{
							for(int i = 0; i < MBHDIJJEOFL.Count; i++)
							{
								if(MBHDIJJEOFL[i].MAFAIIHJAFG == 1)
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
				else if(JHNMKKNEENE < ev.NGHKJOEDLIP.JGMDAOACOJF)
				{
					NGOFCFJHOMI_Status = KGCNCBOKCBA.GNENJEHKMHD_EventStatus.EMAMLLFAOJI_Counting_6;
				}
				else if(JHNMKKNEENE < ev.NGHKJOEDLIP.IDDBFFBPNGI)
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
				else if(JHNMKKNEENE < ev.NGHKJOEDLIP.KNLGKBBIBOH_End)
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
	// public override void AMKJFGLEJGE(int LHJCOPMMIGO) { }

	// // RVA: 0xA1C144 Offset: 0xA1C144 VA: 0xA1C144 Slot: 49
	// protected override void ODPJGHOJIOH(int LHJCOPMMIGO) { }

	// // RVA: 0xA1C778 Offset: 0xA1C778 VA: 0xA1C778 Slot: 50
	protected override void MFJFBNPLFBE_OnReceieveTotalReward(bool GIPBIDFJFLL)
	{
		LNELCMNJPIC_EventGoDiva ev = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.LBDOLHGDIEB_GetDbSection(JOPOPMLFINI_QuestId) as LNELCMNJPIC_EventGoDiva;
		if(ev != null)
		{
			if(CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave.JMPNGBGNCFO_EventGoDiva.PFAKPFKJJKA() == null)
			{
				CCBMJNPFPBB_EventGoDiva.KIJJHJHLBAK saveEv = CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave.JMPNGBGNCFO_EventGoDiva.FBCJICEPLED[ev.NGHKJOEDLIP.MOEKELIIDEO_SaveIdx];
				JANMJPOKLFL.JCHLONCMPAJ();
				JOFBHHHLBBN.Clear();
				List<string> ls = new List<string>(3);
				List<int> li = new List<int>();
				StringBuilder str = new StringBuilder();
				long curPoint = FBGDBGKNKOD_GetCurrentPoint();
				long date = ev.NGHKJOEDLIP.JBFDHOIKAIK_InventoryEndDate;
				for(int i = 0; i < ev.FCIPEDFHFEM_Rewards.Count; i++)
				{
					if(curPoint >= ev.FCIPEDFHFEM_Rewards[i].DNBFMLBNAEE_Point)
					{
						if(!saveEv.BHIAKGKHKGD_IsRewardReceived(i))
						{
							str.Length = 0;
							str.Append(PGIIDPEGGPI_EventId);
							str.Append(':');
							str.Append(i);
							str.Append(':');
							str.Append(ev.FCIPEDFHFEM_Rewards[i].DNBFMLBNAEE_Point);
							JANMJPOKLFL.FEGDNPIEKJC(OAGBCBBHMPF.COIIJOEKBDH.MGEFPKOJKBL_9, str.ToString());
							for(int j = 0; j < ev.FCIPEDFHFEM_Rewards[i].AHJNPEAMCCH_Items.Count; j++)
							{
								if(ev.FCIPEDFHFEM_Rewards[i].AHJNPEAMCCH_Items[j].NMKEOMCMIPP_RewardId > 0)
								{
									ls.Add(ev.NGHKJOEDLIP.OCDMGOGMHGE_AchievementIdPrefix + ev.FCIPEDFHFEM_Rewards[i].AHJNPEAMCCH_Items[j].NMKEOMCMIPP_RewardId.ToString());
									li.Add(ev.FCIPEDFHFEM_Rewards[i].AHJNPEAMCCH_Items[j].PJPDOCNJNGJ_TimeLimited ? (int)date : -1);
								}
								JANMJPOKLFL.CPIICACGNBH_AddItem(CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave, ev.FCIPEDFHFEM_Rewards[i].AHJNPEAMCCH_Items[j].GLCLFMGPMAN_ItemId, ev.FCIPEDFHFEM_Rewards[i].AHJNPEAMCCH_Items[j].HMFFHLPNMPH_ItemCnt, null, 0);
								saveEv.IPNLHCLFIDB_SetRewardReceived(i, true);
							}
							JOFBHHHLBBN.Add(i);
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
							PLOOEECNHFB = true;
							DENHAAGACPD(0);
						};
						req.MOBEEPPKFLG_OnFail = (CACGCMBKHDI_Request NHECPMNKEFK) =>
						{
							//0xA28D3C
							if(NHECPMNKEFK.CJMFJOMECKI_ErrorId == SakashoErrorId.ACHIEVEMENT_PRIZE_ALREADY_RECEIVED)
							{
								DENHAAGACPD(0);
								PLOOEECNHFB = true;
							}
							else
							{
								PLOOEECNHFB = true;
								NPNNPNAIONN = true;
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
				NPNNPNAIONN = true;
			}
		}
		PLOOEECNHFB = true;
	}

	// // RVA: 0xA1D720 Offset: 0xA1D720 VA: 0xA1D720 Slot: 52
	public override void FAMFKPBPIAA_GetRankingPlayerList(bool PFFJNEFNAMI, int CJHEHIMLGGL, int LHJCOPMMIGO, LIOLBKLMMIK KLMFJJCNBIP, DJBHIFLHJLK IDAEHNGOKAE, DJBHIFLHJLK JGKOLBLPMPG)
	{
		NPNNPNAIONN = false;
		PLOOEECNHFB = false;
		LNELCMNJPIC_EventGoDiva ev = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.LBDOLHGDIEB_GetDbSection(JOPOPMLFINI_QuestId) as LNELCMNJPIC_EventGoDiva;
		if(ev != null)
		{
			EECOJKDJIFG info = DAKMIKNKHMF_GetRankingInfoForIndex(LHJCOPMMIGO);
			if(info != null)
			{
				KKLGENJKEBN.HHCJCDFCLOB.FAMFKPBPIAA_GetRankingPlayerList(info.OCGFKMHNEOF_NameForApi, PFFJNEFNAMI, CJHEHIMLGGL, LHJCOPMMIGO, (int NEFEFHBHFFF, List<IBIGBMDANNM> MAGKKPOFJIM) =>
				{
					//0xA29BB4
					PLOOEECNHFB = true;
					KLMFJJCNBIP(NEFEFHBHFFF, MAGKKPOFJIM);
				}, () =>
				{
					//0xA29C10
					PLOOEECNHFB = true;
					IDAEHNGOKAE();
				}, () =>
				{
					//0xA29C5C
					PLOOEECNHFB = true;
					NPNNPNAIONN = true;
					JGKOLBLPMPG();
				}, false);
				return;
			}
		}
		IDAEHNGOKAE();
		PLOOEECNHFB = true;
	}

	// // RVA: 0xA1DA58 Offset: 0xA1DA58 VA: 0xA1DA58 Slot: 53
	public override void JPNACOLKHLB_AddRankingPlayerListSecond(int CJHEHIMLGGL, int NEFEFHBHFFF, LIOLBKLMMIK KLMFJJCNBIP, DJBHIFLHJLK IDAEHNGOKAE, DJBHIFLHJLK JGKOLBLPMPG)
	{
		KKLGENJKEBN.HHCJCDFCLOB.JPNACOLKHLB_AddRankingPlayerListSecond(CJHEHIMLGGL, NEFEFHBHFFF, (int JGNBPFCJLKI, List<IBIGBMDANNM> MAGKKPOFJIM) =>
		{
			//0xA29CC0
			PLOOEECNHFB = true;
			KLMFJJCNBIP(JGNBPFCJLKI, MAGKKPOFJIM);
		}, () =>
		{
			//0xA29D1C
			PLOOEECNHFB = true;
			IDAEHNGOKAE();
		}, () =>
		{
			//0xA29D68
			PLOOEECNHFB = true;
			NPNNPNAIONN = true;
			JGKOLBLPMPG();
		}, false);
	}

	// // RVA: 0xA1DC14 Offset: 0xA1DC14 VA: 0xA1DC14
	// private int APJDIPINLLK(List<int> HNLFPKNBOHE, int PPFNGGCBJKC) { }

	// // RVA: 0xA1B304 Offset: 0xA1B304 VA: 0xA1B304
	private void PIMFJALCIGK()
	{
		int m = NGIHFKHOJOK_GetRankingMax();
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
			LNELCMNJPIC_EventGoDiva ev = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.LBDOLHGDIEB_GetDbSection(JOPOPMLFINI_QuestId) as LNELCMNJPIC_EventGoDiva;
			if(ev != null)
			{
				CCBMJNPFPBB_EventGoDiva.KIJJHJHLBAK saveEv = CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave.JMPNGBGNCFO_EventGoDiva.FBCJICEPLED[ev.NGHKJOEDLIP.MOEKELIIDEO_SaveIdx];
				PFPJHJJAGAG_Rewards.Clear();
				EGIPGHCDMII_RankData[LHJCOPMMIGO].Clear();
				for(int i = 0; i < e.AHJNPEAMCCH_Rewards.Count; i++)
				{
					MAOCCKFAOPC m = new MAOCCKFAOPC();
					m.JBDGBPAAAEF_HighRank = e.AHJNPEAMCCH_Rewards[i].JPHDGGNAKMO_HighRank;
					m.GHANKNIBALB_LowRank = e.AHJNPEAMCCH_Rewards[i].FGCAJEAIABA_LowRank;
					m.MJGAMDBOMHD_InventoryMessage = e.AHJNPEAMCCH_Rewards[i].IPFEKNMBEBI_InventoryMessage;
					m.HBHMAKNGKFK_Items = e.AHJNPEAMCCH_Rewards[i].HBHMAKNGKFK_Items;
					EGIPGHCDMII_RankData[LHJCOPMMIGO].Add(m);
				}
				for(int i = 0; i < ev.FCIPEDFHFEM_Rewards.Count; i++)
				{
					IHAEIOAKEMG d = new IHAEIOAKEMG();
					for(int j = 0; j < ev.FCIPEDFHFEM_Rewards[i].AHJNPEAMCCH_Items.Count; j++)
					{
						MFDJIFIIPJD m = new MFDJIFIIPJD();
						m.KHEKNNFCAOI(ev.FCIPEDFHFEM_Rewards[i].AHJNPEAMCCH_Items[j].GLCLFMGPMAN_ItemId, ev.FCIPEDFHFEM_Rewards[i].AHJNPEAMCCH_Items[j].HMFFHLPNMPH_ItemCnt);
						m.JOPPFEHKNFO_IsGold = ev.FCIPEDFHFEM_Rewards[i].JOPPFEHKNFO_IsGold;
						d.HBHMAKNGKFK_Items.Add(m);
					}
					d.HMEOAKCLKJE_IsReceived = saveEv.BHIAKGKHKGD_IsRewardReceived(i);
					d.FIOIKMOIJGK_Point = ev.FCIPEDFHFEM_Rewards[i].DNBFMLBNAEE_Point;
					d.OJELCGDDAOM_MissingPoint = Mathf.Max(d.FIOIKMOIJGK_Point - saveEv.DNBFMLBNAEE_Point, 0);
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
			LNELCMNJPIC_EventGoDiva ev = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.LBDOLHGDIEB_GetDbSection(JOPOPMLFINI_QuestId) as LNELCMNJPIC_EventGoDiva;
			if(ev != null)
			{
				CCBMJNPFPBB_EventGoDiva.KIJJHJHLBAK saveEv = CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave.JMPNGBGNCFO_EventGoDiva.FBCJICEPLED[ev.NGHKJOEDLIP.MOEKELIIDEO_SaveIdx];
				for(int i = 0; i < PFPJHJJAGAG_Rewards.Count; i++)
				{
					PFPJHJJAGAG_Rewards[i].HMEOAKCLKJE_IsReceived = saveEv.BHIAKGKHKGD_IsRewardReceived(i);
					PFPJHJJAGAG_Rewards[i].OJELCGDDAOM_MissingPoint = Mathf.Max(PFPJHJJAGAG_Rewards[i].FIOIKMOIJGK_Point - saveEv.DNBFMLBNAEE_Point, 0);
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
		LNELCMNJPIC_EventGoDiva ev = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.LBDOLHGDIEB_GetDbSection(JOPOPMLFINI_QuestId) as LNELCMNJPIC_EventGoDiva;
		if(ev != null)
		{
			return ev.LPJLEHAJADA("diva_exp_bonus_rate", 100);
		}
		return 100;
	}

	// // RVA: 0xA1E894 Offset: 0xA1E894 VA: 0xA1E894
	public long KBKGHDFBHAP_GetBonusEndTime(long JHNMKKNEENE)
	{
		LNELCMNJPIC_EventGoDiva ev = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.LBDOLHGDIEB_GetDbSection(JOPOPMLFINI_QuestId) as LNELCMNJPIC_EventGoDiva;
		if(ev != null)
		{
			CCBMJNPFPBB_EventGoDiva.KIJJHJHLBAK saveEv = CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave.JMPNGBGNCFO_EventGoDiva.FBCJICEPLED[ev.NGHKJOEDLIP.MOEKELIIDEO_SaveIdx];
			int fever_ticket_time = ev.LPJLEHAJADA("fever_ticket_time", 60);
			if(JHNMKKNEENE < saveEv.CNJCFCNLAMO_UseTime + fever_ticket_time * 60)
			{
				return saveEv.CNJCFCNLAMO_UseTime + fever_ticket_time * 60;
			}
			for(int i = 0; i < ev.BGHBALGJNFF.Count; i++)
			{
				if(ev.BGHBALGJNFF[i].PLALNIIBLOF_Enabled == 2)
				{
					if(ev.BGHBALGJNFF[i].BEBJKJKBOGH_FixedDayDate < 1)
					{
                        DateTime dt = Utility.GetLocalDateTime(JHNMKKNEENE);
						TimeSpan ts = new TimeSpan(dt.Hour, dt.Minute, dt.Second);
						if((long)ts.TotalSeconds >= ev.BGHBALGJNFF[i].FNEIADJMHHO_DaySecondsStart)
						{
							if((long)ts.TotalSeconds < ev.BGHBALGJNFF[i].EICJBAEDMNM_DaySecondsEnd)
							{
								return JHNMKKNEENE - (long)ts.TotalSeconds + ev.BGHBALGJNFF[i].EICJBAEDMNM_DaySecondsEnd;
							}
						}
                    }
				}
				else
				{
					if(JHNMKKNEENE >= ev.BGHBALGJNFF[i].FNEIADJMHHO_DaySecondsStart + ev.BGHBALGJNFF[i].BEBJKJKBOGH_FixedDayDate)
					{
						if(JHNMKKNEENE < ev.BGHBALGJNFF[i].EICJBAEDMNM_DaySecondsEnd + ev.BGHBALGJNFF[i].BEBJKJKBOGH_FixedDayDate)
						{
							return ev.BGHBALGJNFF[i].EICJBAEDMNM_DaySecondsEnd + ev.BGHBALGJNFF[i].BEBJKJKBOGH_FixedDayDate;
						}
					}
				}
			}
		}
		return 0;
	}

	// // RVA: 0xA1EE70 Offset: 0xA1EE70 VA: 0xA1EE70
	public int GNDOGPBIGIL_GetCurrentBonusRate(long JHNMKKNEENE)
	{
		LNELCMNJPIC_EventGoDiva ev = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.LBDOLHGDIEB_GetDbSection(JOPOPMLFINI_QuestId) as LNELCMNJPIC_EventGoDiva;
		if(ev != null)
		{
			CCBMJNPFPBB_EventGoDiva.KIJJHJHLBAK saveEv = CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave.JMPNGBGNCFO_EventGoDiva.FBCJICEPLED[ev.NGHKJOEDLIP.MOEKELIIDEO_SaveIdx];
			int fever_ticket_time = ev.LPJLEHAJADA("fever_ticket_time", 60);
			if(JHNMKKNEENE >= saveEv.CNJCFCNLAMO_UseTime + fever_ticket_time * 60)
			{
				for(int i = 0; i < ev.BGHBALGJNFF.Count; i++)
				{
					if(ev.BGHBALGJNFF[i].PLALNIIBLOF_Enabled == 2)
					{
						if(ev.BGHBALGJNFF[i].BEBJKJKBOGH_FixedDayDate < 1)
						{
							DateTime dt = Utility.GetLocalDateTime(JHNMKKNEENE);
							TimeSpan ts = new TimeSpan(dt.Hour, dt.Minute, dt.Second);
							if((long)ts.TotalSeconds >= ev.BGHBALGJNFF[i].FNEIADJMHHO_DaySecondsStart)
							{
								if((long)ts.TotalSeconds < ev.BGHBALGJNFF[i].EICJBAEDMNM_DaySecondsEnd)
								{
									return ev.BGHBALGJNFF[i].JBGEEPFKIGG_BonusRate;
								}
							}
						}
					}
					else
					{
						if(JHNMKKNEENE >= ev.BGHBALGJNFF[i].FNEIADJMHHO_DaySecondsStart + ev.BGHBALGJNFF[i].BEBJKJKBOGH_FixedDayDate)
						{
							if(JHNMKKNEENE < ev.BGHBALGJNFF[i].EICJBAEDMNM_DaySecondsEnd + ev.BGHBALGJNFF[i].BEBJKJKBOGH_FixedDayDate)
							{
								return ev.BGHBALGJNFF[i].JBGEEPFKIGG_BonusRate;
							}
						}
					}
				}
				return 0;
			}
			return ev.LPJLEHAJADA("fever_ticket_rate", 100);
		}
		return 0;
	}

	// // RVA: 0xA1F43C Offset: 0xA1F43C VA: 0xA1F43C
	public bool HHAGNMOIENH_UseFeverTicket(out long PCCFAKEOBIC)
	{
		PCCFAKEOBIC = 0;
		LNELCMNJPIC_EventGoDiva ev = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.LBDOLHGDIEB_GetDbSection(JOPOPMLFINI_QuestId) as LNELCMNJPIC_EventGoDiva;
		if(ev != null)
		{
			ABBOEIPOBLJ_EventTicket.CBDACMFFHJC evTkt = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.KHPOJKHKLEM_EventTicket.CDENCMNHNGA.Find((ABBOEIPOBLJ_EventTicket.CBDACMFFHJC GHPLINIACBB) =>
			{
				//0xA29DCC
				return ev.NGHKJOEDLIP.MJBKGOJBPAD_TicketType == GHPLINIACBB.INDDJNMPONH_Typ;
			});
			if(evTkt != null)
			{
				long t = NKGJPJPHLIF.HHCJCDFCLOB.IBLPICFDGOF_ServerRequester.FJDBNGEPKHL.KMEFBNBFJHI_GetServerTime();
				CCBMJNPFPBB_EventGoDiva.KIJJHJHLBAK saveEv = CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave.JMPNGBGNCFO_EventGoDiva.FBCJICEPLED[ev.NGHKJOEDLIP.MOEKELIIDEO_SaveIdx];
				if(saveEv.HHAGNMOIENH(1, t))
				{
					int fever_ticket_time = ev.LPJLEHAJADA("fever_ticket_time", 60);
					PCCFAKEOBIC = t + fever_ticket_time * 60;
					ILCCJNDFFOB.HHCJCDFCLOB.HJGEAHELBPE(this, EKLNMHFCAOI.GJEEGMCBGGM_GetItemFullId(EKLNMHFCAOI.FKGCBLHOOCL_Category.CLMIJKACELE_EventTicket, evTkt.PPFNGGCBJKC_Id), 1, saveEv.GJPHOIBCEFL_ItemTicketCnt);
					return true;
				}
			}
		}
		return false;
	}

	// // RVA: 0xA1FB70 Offset: 0xA1FB70 VA: 0xA1FB70
	public int CACFIGAPLDH_GetDailyUse()
	{
		LNELCMNJPIC_EventGoDiva ev = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.LBDOLHGDIEB_GetDbSection(JOPOPMLFINI_QuestId) as LNELCMNJPIC_EventGoDiva;
		if(ev != null)
		{
			CCBMJNPFPBB_EventGoDiva.KIJJHJHLBAK saveEv = CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave.JMPNGBGNCFO_EventGoDiva.FBCJICEPLED[ev.NGHKJOEDLIP.MOEKELIIDEO_SaveIdx];
			return saveEv.NNCFCPEOODE_UseCnt;
		}
		return 0;
	}

	// // RVA: 0xA1FDCC Offset: 0xA1FDCC VA: 0xA1FDCC Slot: 14
	public override void HPENJEOAMBK_SetTicket(int JKIADEKHGLC, int HMFFHLPNMPH, BBHNACPENDM_ServerSaveData AHEFHIMGIBI)
	{
		LNELCMNJPIC_EventGoDiva ev = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.LBDOLHGDIEB_GetDbSection(JOPOPMLFINI_QuestId) as LNELCMNJPIC_EventGoDiva;
		if(ev != null)
		{
			if(AHEFHIMGIBI == null)
				AHEFHIMGIBI = CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave;
			ABBOEIPOBLJ_EventTicket.CBDACMFFHJC tkt = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.KHPOJKHKLEM_EventTicket.CDENCMNHNGA.Find((ABBOEIPOBLJ_EventTicket.CBDACMFFHJC GHPLINIACBB) =>
			{
				//0xA29E28
				return GHPLINIACBB.INDDJNMPONH_Typ == ev.NGHKJOEDLIP.MJBKGOJBPAD_TicketType;
			});
			if(tkt != null && JKIADEKHGLC_TicketItemId == JKIADEKHGLC)
			{
				for(int i = 0; i < HMFFHLPNMPH; i++)
				{
					AHEFHIMGIBI.JMPNGBGNCFO_EventGoDiva.FBCJICEPLED[ev.NGHKJOEDLIP.MOEKELIIDEO_SaveIdx].GJPHOIBCEFL_ItemTicketCnt += tkt.JBGEEPFKIGG_Val;
				}
			}
		}
	}

	// // RVA: 0xA201D8 Offset: 0xA201D8 VA: 0xA201D8 Slot: 11
	public override int AELBIEDNPGB_GetTicketCount(BBHNACPENDM_ServerSaveData AHEFHIMGIBI)
	{
		LNELCMNJPIC_EventGoDiva ev = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.LBDOLHGDIEB_GetDbSection(JOPOPMLFINI_QuestId) as LNELCMNJPIC_EventGoDiva;
		if(ev != null)
		{
			if(AHEFHIMGIBI == null)
				AHEFHIMGIBI = CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave;
			ABBOEIPOBLJ_EventTicket.CBDACMFFHJC tkt = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.KHPOJKHKLEM_EventTicket.CDENCMNHNGA.Find((ABBOEIPOBLJ_EventTicket.CBDACMFFHJC GHPLINIACBB) =>
			{
				//0xA29E84
				return GHPLINIACBB.INDDJNMPONH_Typ == ev.NGHKJOEDLIP.MJBKGOJBPAD_TicketType;
			});
			if(tkt != null)
			{
				return AHEFHIMGIBI.JMPNGBGNCFO_EventGoDiva.FBCJICEPLED[ev.NGHKJOEDLIP.MOEKELIIDEO_SaveIdx].GJPHOIBCEFL_ItemTicketCnt;
			}
		}
		return 0;
	}

	// // RVA: 0xA20584 Offset: 0xA20584 VA: 0xA20584 Slot: 54
	public override int NGIHFKHOJOK_GetRankingMax(bool DJHLDMOPCOL = true)
	{
		if(!IBNKPMPFLGI_IsRankReward)
			return 0;
		else if(!DJHLDMOPCOL)
		{
			int res = 0;
			for(int i = 0; i < KBACNOCOANM.Length; i++)
			{
				if(KBACNOCOANM[i] != null)
					res++;
			}
			return res;
		}
		else
		{
			return KBACNOCOANM.Length;
		}
	}

	// // RVA: 0xA20640 Offset: 0xA20640 VA: 0xA20640 Slot: 55
	public override bool PIDEAJOJKKC(int LHJCOPMMIGO = 0)
	{
		if(AFCIIKDOMHN_GetCurrentScore(LHJCOPMMIGO + 1) != 0)
			return GPGPLIAHGJH(LHJCOPMMIGO + 1);
		return false;
	}

	// // RVA: 0xA20814 Offset: 0xA20814 VA: 0xA20814 Slot: 56
	public override bool DGOAGKOKCIJ_IsRewardReceived(int LHJCOPMMIGO)
	{
		LNELCMNJPIC_EventGoDiva ev = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.LBDOLHGDIEB_GetDbSection(JOPOPMLFINI_QuestId) as LNELCMNJPIC_EventGoDiva;
		if(ev != null)
		{
			CCBMJNPFPBB_EventGoDiva.KIJJHJHLBAK saveEv = CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave.JMPNGBGNCFO_EventGoDiva.FBCJICEPLED[ev.NGHKJOEDLIP.MOEKELIIDEO_SaveIdx];
			return saveEv.DGOAGKOKCIJ_IsRewardReceived(LHJCOPMMIGO);
		}
		return false;
	}

	// // RVA: 0xA20A78 Offset: 0xA20A78 VA: 0xA20A78 Slot: 57
	public override void LHAEPPFACOB_SetRewardReceived(int LHJCOPMMIGO, bool OAFPGJLCNFM)
	{
		LNELCMNJPIC_EventGoDiva ev = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.LBDOLHGDIEB_GetDbSection(JOPOPMLFINI_QuestId) as LNELCMNJPIC_EventGoDiva;
		if(ev != null)
		{
			CCBMJNPFPBB_EventGoDiva.KIJJHJHLBAK saveEv = CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave.JMPNGBGNCFO_EventGoDiva.FBCJICEPLED[ev.NGHKJOEDLIP.MOEKELIIDEO_SaveIdx];
			saveEv.LHAEPPFACOB_SetRawardReceived(LHJCOPMMIGO, OAFPGJLCNFM);
		}
	}

	// // RVA: 0xA20CE0 Offset: 0xA20CE0 VA: 0xA20CE0 Slot: 58
	protected override void LMGMELPOGMH(int LHJCOPMMIGO)
	{
		HLFHJIDHJMP = null;
		LNELCMNJPIC_EventGoDiva ev = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.LBDOLHGDIEB_GetDbSection(JOPOPMLFINI_QuestId) as LNELCMNJPIC_EventGoDiva;
		if(ev != null)
		{
			EECOJKDJIFG info = DAKMIKNKHMF_GetRankingInfoForIndex(LHJCOPMMIGO);
			if(info != null && !DGOAGKOKCIJ_IsRewardReceived(LHJCOPMMIGO))
			{
				OKPEFAPPFDH_GetRanksAroundSelf req = NKGJPJPHLIF.HHCJCDFCLOB.IBLPICFDGOF_ServerRequester.IFFNCAFNEAG_AddRequest(new OKPEFAPPFDH_GetRanksAroundSelf());
				req.EMPNJPMAKBF_Id = info.PPFNGGCBJKC_Id;
				req.MJGOBEGONON_Type = 0;
				req.NHPCKCOPKAM_From = 0;
				req.PJFKNNNDMIA_To = 0;
				req.MOBEEPPKFLG_OnFail = (CACGCMBKHDI_Request KCFBGMKDIMI) =>
				{
					//0xA29EE0
					if(JGJFFKPFMDB.BDGBCCGLLAJ_IsRankingError(KCFBGMKDIMI.CJMFJOMECKI_ErrorId))
					{
						if(KCFBGMKDIMI.CJMFJOMECKI_ErrorId == SakashoErrorId.RANKING_DROPPED_PLAYER)
							FKKDIDMGLMI = true;
						LHAEPPFACOB_SetRewardReceived(LHJCOPMMIGO, true);
						PJDGDNJNCNM_UpdateStatusImpl(NKGJPJPHLIF.HHCJCDFCLOB.IBLPICFDGOF_ServerRequester.FJDBNGEPKHL.KMEFBNBFJHI_GetServerTime());
						PLOOEECNHFB = true;
					}
					else
					{
						PLOOEECNHFB = true;
						NPNNPNAIONN = true;
					}
				};
				req.BHFHGFKBOHH_OnSuccess = (CACGCMBKHDI_Request KCFBGMKDIMI) =>
				{
					//0xA2A138
					OKPEFAPPFDH_GetRanksAroundSelf r = KCFBGMKDIMI as OKPEFAPPFDH_GetRanksAroundSelf;
					if(r.NFEAMMJIMPG.EJDEDOJFOOK.Count == 0)
					{
						LHAEPPFACOB_SetRewardReceived(LHJCOPMMIGO, true);
						PJDGDNJNCNM_UpdateStatusImpl(NKGJPJPHLIF.HHCJCDFCLOB.IBLPICFDGOF_ServerRequester.FJDBNGEPKHL.KMEFBNBFJHI_GetServerTime());
						PLOOEECNHFB = true;
					}
					else
					{
						HLFHJIDHJMP = new NHGEHCMPDAI();
						HLFHJIDHJMP.DNBFMLBNAEE_CurrentPoint = r.NFEAMMJIMPG.EJDEDOJFOOK[0].KNIFCANOHOC_Score;
						HLFHJIDHJMP.FJOLNJLLJEJ_Rank = r.NFEAMMJIMPG.EJDEDOJFOOK[0].FJOLNJLLJEJ_Rank;
						KKLGENJKEBN.HHCJCDFCLOB.DNJKPPCBINA(info.OCGFKMHNEOF_NameForApi, () =>
						{
							//0xA2A71C
							for(int i = 0; i < KKLGENJKEBN.HHCJCDFCLOB.PHOPJDPEHJA.Count; i++)
							{
								MFDJIFIIPJD m = new MFDJIFIIPJD();
								m.KHEKNNFCAOI(KKLGENJKEBN.HHCJCDFCLOB.PHOPJDPEHJA[i].JJBGOIMEIPF_ItemFullId, KKLGENJKEBN.HHCJCDFCLOB.PHOPJDPEHJA[i].MBJIFDBEDAC_ItemCount);
								HLFHJIDHJMP.HBHMAKNGKFK.Add(m);
							}
							ILCCJNDFFOB.HHCJCDFCLOB.GIBLHFKIMDA(this);
							LHAEPPFACOB_SetRewardReceived(LHJCOPMMIGO, true);
							PLOOEECNHFB = true;
						}, () =>
						{
							//0xA2A9C0
							HLFHJIDHJMP = null;
							ILCCJNDFFOB.HHCJCDFCLOB.GIBLHFKIMDA(this);
							LHAEPPFACOB_SetRewardReceived(LHJCOPMMIGO, true);
							PLOOEECNHFB = true;
						}, () =>
						{
							//0xA2AAD4
							LHAEPPFACOB_SetRewardReceived(LHJCOPMMIGO, true);
							PLOOEECNHFB = true;
							HLFHJIDHJMP = null;
						}, () =>
						{
							//0xA2AB50
							PLOOEECNHFB = true;
							HLFHJIDHJMP = null;
						}, () =>
						{
							//0xA2AB98
							PLOOEECNHFB = true;
							NPNNPNAIONN = true;
						}, 0, -1);
					}
				};
				return;
			}
		}
		PLOOEECNHFB = true;
	}

	// // RVA: 0xA210C4 Offset: 0xA210C4 VA: 0xA210C4 Slot: 59
	public override List<int> AEGDKBNNDBC_GetDrops()
	{
		LNELCMNJPIC_EventGoDiva ev = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.LBDOLHGDIEB_GetDbSection(JOPOPMLFINI_QuestId) as LNELCMNJPIC_EventGoDiva;
		if(ev != null)
		{
			return ev.NGHKJOEDLIP.EEOGPJJCKHH_Drops;
		}
		return null;
	}

	// // RVA: 0xA21248 Offset: 0xA21248 VA: 0xA21248 Slot: 33
	public override bool MPMKJNJGFEF_IsEntry()
	{
		LNELCMNJPIC_EventGoDiva ev = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.LBDOLHGDIEB_GetDbSection(JOPOPMLFINI_QuestId) as LNELCMNJPIC_EventGoDiva;
		if(ev != null)
		{
			CCBMJNPFPBB_EventGoDiva.KIJJHJHLBAK saveEv = CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave.JMPNGBGNCFO_EventGoDiva.FBCJICEPLED[ev.NGHKJOEDLIP.MOEKELIIDEO_SaveIdx];
			return saveEv.IMFBCJOIJKJ_Entry;
		}
		return false;
	}

	// // RVA: 0xA214A8 Offset: 0xA214A8 VA: 0xA214A8 Slot: 65
	protected override bool JLPDECMHLIM_CanShowStartAdventureInternal()
	{
		LNELCMNJPIC_EventGoDiva ev = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.LBDOLHGDIEB_GetDbSection(JOPOPMLFINI_QuestId) as LNELCMNJPIC_EventGoDiva;
		if(ev != null)
		{
			CCBMJNPFPBB_EventGoDiva.KIJJHJHLBAK saveEv = CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave.JMPNGBGNCFO_EventGoDiva.FBCJICEPLED[ev.NGHKJOEDLIP.MOEKELIIDEO_SaveIdx];
			long t = NKGJPJPHLIF.HHCJCDFCLOB.IBLPICFDGOF_ServerRequester.FJDBNGEPKHL.KMEFBNBFJHI_GetServerTime();
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
	public override void FGDDBFHGCGP_SetStartAdventureShown(bool JKDJCFEBDHC, long JHNMKKNEENE = 0)
	{
		if(JKDJCFEBDHC)
		{
			LNELCMNJPIC_EventGoDiva ev = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.LBDOLHGDIEB_GetDbSection(JOPOPMLFINI_QuestId) as LNELCMNJPIC_EventGoDiva;
			if(ev != null)
			{
				CCBMJNPFPBB_EventGoDiva.KIJJHJHLBAK saveEv = CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave.JMPNGBGNCFO_EventGoDiva.FBCJICEPLED[ev.NGHKJOEDLIP.MOEKELIIDEO_SaveIdx];
				saveEv.INLNJOGHLJE_Show |= 1;
			}
		}
	}

	// // RVA: 0xA21A64 Offset: 0xA21A64 VA: 0xA21A64 Slot: 70
	public override void ADACMHAHHKC_PreSetupEventHome(IMCBBOAFION BHFHGFKBOHH, DJBHIFLHJLK AOCANKOMKFG)
	{
		N.a.StartCoroutineWatched(NJIEIJJMAHK_Corotuine_PreSetupEventHome(BHFHGFKBOHH, AOCANKOMKFG));
	}

	// [IteratorStateMachineAttribute] // RVA: 0x6BC824 Offset: 0x6BC824 VA: 0x6BC824
	// // RVA: 0xA21ABC Offset: 0xA21ABC VA: 0xA21ABC
	private IEnumerator NJIEIJJMAHK_Corotuine_PreSetupEventHome(IMCBBOAFION BHFHGFKBOHH, DJBHIFLHJLK AOCANKOMKFG)
	{
		long IBCGNDADAEE; // 0x28
		LNELCMNJPIC_EventGoDiva KEHCNBNPJHB; // 0x30
		BBHNACPENDM_ServerSaveData PNFNCKGAFBK; // 0x34
		CCBMJNPFPBB_EventGoDiva.KIJJHJHLBAK FDAENOPKLKP; // 0x38
		ILDKBCLAFPB GDJIOGLCKNH; // 0x3C

		//0xA2ACD4
		while(CIOECGOMILE.HHCJCDFCLOB.KONHMOLMOCI_IsSaving)
			yield return null;
		IBCGNDADAEE = NKGJPJPHLIF.HHCJCDFCLOB.IBLPICFDGOF_ServerRequester.FJDBNGEPKHL.KMEFBNBFJHI_GetServerTime();
		KEHCNBNPJHB = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.LBDOLHGDIEB_GetDbSection(JOPOPMLFINI_QuestId) as LNELCMNJPIC_EventGoDiva;
		if(KEHCNBNPJHB != null)
		{
			PJDGDNJNCNM_UpdateStatusImpl(IBCGNDADAEE);
			PNFNCKGAFBK = CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave;
			FDAENOPKLKP = PNFNCKGAFBK.JMPNGBGNCFO_EventGoDiva.FBCJICEPLED[KEHCNBNPJHB.NGHKJOEDLIP.MOEKELIIDEO_SaveIdx];
			GDJIOGLCKNH = GameManager.Instance.localSave;
			if(FDAENOPKLKP.DNBFMLBNAEE_Point > 0)
			{
				MJFKJHJJLMN_GetRanks(0, false);
				//LAB_00a2ae58
				while(!PLOOEECNHFB)
					yield return null;
				if(NPNNPNAIONN)
				{
					AOCANKOMKFG();
					yield break;
				}
				if(FKKDIDMGLMI)
				{
					JHHBAFKMBDL.HHCJCDFCLOB.PEIONAKEPCN_ShowRankingBanPopup(AOCANKOMKFG);
					yield break;
				}
			}
			//break;
			if(NGOFCFJHOMI_Status == KGCNCBOKCBA.GNENJEHKMHD_EventStatus.GDOPLACICFE_4)
			{
				FDAENOPKLKP.ABBJBPLHFHA_Spurt = true;
				LPFJADHHLHG = true;
				PJDGDNJNCNM_UpdateStatusImpl(IBCGNDADAEE);
			}
			if(!FDAENOPKLKP.IMFBCJOIJKJ_Entry)
			{
				if(NGOFCFJHOMI_Status == KGCNCBOKCBA.GNENJEHKMHD_EventStatus.NCJFJLPJMLI_2)
				{
					CMPEJEHCOEI = true;
					FGDDBFHGCGP_SetStartAdventureShown(true, 0);
					GameManager.Instance.localSave.EPJOACOONAC_GetSave().PPCGEFGJJIC_SortProprty.IMEBBACHPAN_EventGoDiva.LHPDDGIJKNB();
					FDAENOPKLKP.IMFBCJOIJKJ_Entry = true;
				}
				if(KIBBLLADDPO)
				{
					FDAENOPKLKP.ABBJBPLHFHA_Spurt = true;
					LPFJADHHLHG = true;
				}
			}
			if(NGOFCFJHOMI_Status < KGCNCBOKCBA.GNENJEHKMHD_EventStatus.EMAMLLFAOJI_Counting_6)
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
								BHFHGFKBOHH();
								PLOOEECNHFB = true;
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
								AOCANKOMKFG();
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
								AOCANKOMKFG();
								PLOOEECNHFB = true;
								NPNNPNAIONN = true;
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
								AOCANKOMKFG();
								yield break;
							}
						}
					}
				}
			}
			//LAB_00a2b690
			OIMGJLOLPHK = false; // Not sure, 0xe3!
			if(NGOFCFJHOMI_Status < KGCNCBOKCBA.GNENJEHKMHD_EventStatus.EMAMLLFAOJI_Counting_6)
			{
				CEBFFLDKAEC_SecureInt v;
				if(KEHCNBNPJHB.OHJFBLFELNK.TryGetValue(HOEKCEJINNA, out v))
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
						if(KEHCNBNPJHB.OHJFBLFELNK.TryGetValue(FOKNMOMNHHD, out v) && DLHEEOIELBA(v.DNJEJEANJGL_Value))
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
			GDJIOGLCKNH.HJMKBCFJOOH_TrySave();
			ILCCJNDFFOB.HHCJCDFCLOB.DADNPOJNIBL(this);
			BHFHGFKBOHH();
		}
		else
		{
			PLOOEECNHFB = true;
			NPNNPNAIONN = true;
			AOCANKOMKFG();
		}
	}

	// [IteratorStateMachineAttribute] // RVA: 0x6BC89C Offset: 0x6BC89C VA: 0x6BC89C
	// // RVA: 0xA21B9C Offset: 0xA21B9C VA: 0xA21B9C
	// public IEnumerator INOILCGFHIC(int LHJCOPMMIGO, IMCBBOAFION BHFHGFKBOHH, DJBHIFLHJLK AOCANKOMKFG) { }

	// // RVA: 0xA21C94 Offset: 0xA21C94 VA: 0xA21C94 Slot: 69
	// public override void HAAEJDGMICH(LBNLAENLPNK.JEKODBEDOMM INDDJNMPONH, IMCBBOAFION BHFHGFKBOHH, DJBHIFLHJLK AOCANKOMKFG) { }

	// // RVA: 0xA2205C Offset: 0xA2205C VA: 0xA2205C Slot: 71
	public override int BAEPGOAMBDK(string LJNAKDMILMC, int MNCOAGOKNAO)
	{
		LNELCMNJPIC_EventGoDiva ev = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.LBDOLHGDIEB_GetDbSection(JOPOPMLFINI_QuestId) as LNELCMNJPIC_EventGoDiva;
		if(ev != null)
		{
			return ev.LPJLEHAJADA(LJNAKDMILMC, MNCOAGOKNAO);
		}
		return MNCOAGOKNAO;
	}

	// // RVA: 0xA221DC Offset: 0xA221DC VA: 0xA221DC Slot: 72
	public override string MAICAKMIBEM(string LJNAKDMILMC, string MNCOAGOKNAO)
	{
		LNELCMNJPIC_EventGoDiva ev = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.LBDOLHGDIEB_GetDbSection(JOPOPMLFINI_QuestId) as LNELCMNJPIC_EventGoDiva;
		if(ev != null)
		{
			return ev.EFEGBHACJAL(LJNAKDMILMC, MNCOAGOKNAO);
		}
		return MNCOAGOKNAO;
	}

	// // RVA: 0xA2235C Offset: 0xA2235C VA: 0xA2235C Slot: 68
	public override bool GJMGKBDGMOP(long LPEKHFOMCAH)
	{
		LNELCMNJPIC_EventGoDiva ev = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.LBDOLHGDIEB_GetDbSection(JOPOPMLFINI_QuestId) as LNELCMNJPIC_EventGoDiva;
		if(ev != null)
		{
			if(LPEKHFOMCAH > DPJCPDKALGI_End1)
				return false;
            CCBMJNPFPBB_EventGoDiva.KIJJHJHLBAK saveEv = CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave.JMPNGBGNCFO_EventGoDiva.FBCJICEPLED[ev.NGHKJOEDLIP.MOEKELIIDEO_SaveIdx];
			bool b17 = false;
			if(NKGJPJPHLIF.HHCJCDFCLOB.DHMLDAGGKCD != saveEv.OMCAOJJGOGG_Lb)
			{
				int daily_bonus_cnt = ev.LPJLEHAJADA("daily_bonus_cnt", 1);
				saveEv.PFPGHILKGIG_BnsCnt = daily_bonus_cnt;
				saveEv.JHKKAKJCJOF_Bns2 = 0;
				saveEv.NNCFCPEOODE_UseCnt = ev.LPJLEHAJADA("fever_ticket_use_cnt", 3);
				if(BHABCGJCGNO != null)
				{
					if(EKLNMHFCAOI.BKHFLDMOGBD_GetItemCategory(BHABCGJCGNO.JJBGOIMEIPF_ItemId) == EKLNMHFCAOI.FKGCBLHOOCL_Category.DMMIIBCMCFG_EnergyItem)
					{
						EGOLBAPFHHD_Common.FKLHGOGJOHH en = CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave.KCCLEHLLOFG_Common.KFEBOFKAHAJ_EngItem[EKLNMHFCAOI.DEACAHNLMNI_getItemId(BHABCGJCGNO.JJBGOIMEIPF_ItemId) - 1];
						en.BFINGCJHOHI_Cnt += BHABCGJCGNO.MBJIFDBEDAC_Cnt;
						en.BEBJKJKBOGH_Date = NKGJPJPHLIF.HHCJCDFCLOB.IBLPICFDGOF_ServerRequester.FJDBNGEPKHL.KMEFBNBFJHI_GetServerTime();
						ILCCJNDFFOB.HHCJCDFCLOB.JAHALBMOANH(BHABCGJCGNO.JJBGOIMEIPF_ItemId, OAGBCBBHMPF.COIIJOEKBDH.IGAJCMKNLDL_14, PGIIDPEGGPI_EventId.ToString(), BHABCGJCGNO.MBJIFDBEDAC_Cnt, en.BFINGCJHOHI_Cnt, 1);
					}
					else if(EKLNMHFCAOI.BKHFLDMOGBD_GetItemCategory(BHABCGJCGNO.JJBGOIMEIPF_ItemId) == EKLNMHFCAOI.FKGCBLHOOCL_Category.CLMIJKACELE_EventTicket)
					{
						HPENJEOAMBK_SetTicket(BHABCGJCGNO.JJBGOIMEIPF_ItemId, BHABCGJCGNO.MBJIFDBEDAC_Cnt, CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave);
						ILCCJNDFFOB.HHCJCDFCLOB.JAHALBMOANH(BHABCGJCGNO.JJBGOIMEIPF_ItemId, OAGBCBBHMPF.COIIJOEKBDH.IGAJCMKNLDL_14, PGIIDPEGGPI_EventId.ToString(), BHABCGJCGNO.MBJIFDBEDAC_Cnt, saveEv.GJPHOIBCEFL_ItemTicketCnt, 1);
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
			CMCEGEKGEEP.KPEKOOCPKID_BonusId = l[0].PPFNGGCBJKC;
			CMCEGEKGEEP.DEFAOMCNGAJ_IsBonusDaily = l[0].CGHNCPEKOCK;
			List<int> l2 = HEACCHAKMFG_GetMusicsList();
			int mId = l2.Count > 0 ? l2[0] : 0;
			if(OMNOFMEBLAD.GHBPLHBNMBK_FreeMusicId == mId)
			{
				CCBMJNPFPBB_EventGoDiva.KIJJHJHLBAK saveEv = CLELOGKMNCE_GetEventSaveData();
				if(saveEv != null)
				{
					if(l[0].CGHNCPEKOCK)
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
	public void FCLGOCBGPJF(JGEOBNENMAH.HAJIFNABIFF OMNOFMEBLAD, int FCLGIPFPIPH, int LCCGDFGGIHI, int BMMPAHHEOJC, int MHADLGMJKGK, bool IKGLAFOHGDO)
	{
		LNELCMNJPIC_EventGoDiva ev = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.LBDOLHGDIEB_GetDbSection(JOPOPMLFINI_QuestId) as LNELCMNJPIC_EventGoDiva;
		if(ev != null)
		{
			CCBMJNPFPBB_EventGoDiva.KIJJHJHLBAK saveEv = CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave.JMPNGBGNCFO_EventGoDiva.FBCJICEPLED[ev.NGHKJOEDLIP.MOEKELIIDEO_SaveIdx];
			if(IKGLAFOHGDO)
			{
				CCBMJNPFPBB_EventGoDiva.KIJJHJHLBAK newSave = new CCBMJNPFPBB_EventGoDiva.KIJJHJHLBAK();
				newSave.LHPDDGIJKNB();
				newSave.ODDIHGPONFL(saveEv);
				saveEv = newSave;
			}
			int score_point_coef = ev.LPJLEHAJADA("score_point_coef", 10000);
			CMCEGEKGEEP.KNIFCANOHOC_Score = OMNOFMEBLAD.KNIFCANOHOC_Score;
			CMCEGEKGEEP.JBJJFDIHKMB_ScoreBonus = OMNOFMEBLAD.KNIFCANOHOC_Score / score_point_coef;
			CMCEGEKGEEP.LIPIAPOGHIP_EpBonus = LEPNPBIMHGM(BMMPAHHEOJC).Count;
			CMCEGEKGEEP.PFJMBKBEFMA_EpRate = CEICDKGEONG(BMMPAHHEOJC, MHADLGMJKGK);
			CMCEGEKGEEP.PFJMBKBEFMA_EpRate += 100;
			CMCEGEKGEEP.EJDJIBPKKNO_BasePoint = BDIJPOGEGNB(OMNOFMEBLAD.GHBPLHBNMBK_FreeMusicId, OMNOFMEBLAD.AKNELONELJK_Difficulty);
			CMCEGEKGEEP.FCLGIPFPIPH = FCLGIPFPIPH;
			CMCEGEKGEEP.JKFCHNEININ_GetPoint = CMCEGEKGEEP.PFJMBKBEFMA_EpRate * ( CMCEGEKGEEP.JBJJFDIHKMB_ScoreBonus + CMCEGEKGEEP.EJDJIBPKKNO_BasePoint) / 100;
			CMCEGEKGEEP.JKFCHNEININ_GetPoint *= CMCEGEKGEEP.FCLGIPFPIPH;
			CMCEGEKGEEP.JKFCHNEININ_GetPoint *= LCCGDFGGIHI;
			saveEv.DNBFMLBNAEE_Point += CMCEGEKGEEP.JKFCHNEININ_GetPoint;
			long t = NKGJPJPHLIF.HHCJCDFCLOB.IBLPICFDGOF_ServerRequester.FJDBNGEPKHL.KMEFBNBFJHI_GetServerTime();
			saveEv.NFIOKIBPJCJ_Uptime = t;
			CMCEGEKGEEP.AHOKAPCGJMA_EndPoint = saveEv.DNBFMLBNAEE_Point;
			CMCEGEKGEEP.LFGNLKKFOCD_IsLine6 = OMNOFMEBLAD.LFGNLKKFOCD_IsLine6;
            List<int> l = HEACCHAKMFG_GetMusicsList();
			CMCEGEKGEEP.OENBOLPDBAB_FreeMusicId = l.Count > 0 ? l[0] : 0;
			CMCEGEKGEEP.LMBFJMBIIGN = CMCEGEKGEEP.PFJMBKBEFMA_EpRate * OMNOFMEBLAD.KNIFCANOHOC_Score / 100;
			CMCEGEKGEEP.JLIKEOKBBAM_HighScore = saveEv.LGFFMGDBIAH_Rankings[OMNOFMEBLAD.HNHCIGMKPDC_DivaIds[0] - 1].NANNGLGOFKH_Val;
			CMCEGEKGEEP.FFHMPNGJCLK_NewRecode = false;
			if(!OMNOFMEBLAD.PMCGHPOGLGM_IsSkip)
			{
				EECOJKDJIFG e = DAKMIKNKHMF_GetRankingInfoForIndex(OMNOFMEBLAD.HNHCIGMKPDC_DivaIds[0] - 1);
				if(e != null)
				{
					if(OMNOFMEBLAD.GHBPLHBNMBK_FreeMusicId == CMCEGEKGEEP.OENBOLPDBAB_FreeMusicId)
					{
						if(CMCEGEKGEEP.JLIKEOKBBAM_HighScore < CMCEGEKGEEP.LMBFJMBIIGN)
						{
							saveEv.LGFFMGDBIAH_Rankings[OMNOFMEBLAD.HNHCIGMKPDC_DivaIds[0] - 1].NANNGLGOFKH_Val = CMCEGEKGEEP.LMBFJMBIIGN;
							CMCEGEKGEEP.JLIKEOKBBAM_HighScore = CMCEGEKGEEP.LMBFJMBIIGN;
							CMCEGEKGEEP.FFHMPNGJCLK_NewRecode = true;
						}
					}
				}
			}
			int r = GNDOGPBIGIL_GetCurrentBonusRate(Database.Instance.gameSetup.musicInfo.setupTime);
			CMCEGEKGEEP.AONOCELOCLL_BonusMusicProbaBefore = Mathf.Clamp(saveEv.ADKDHKMPMHP_Rate + r, 0, 100);
			CMCEGEKGEEP.JGBIFJLPCHM_IsBonusStart = false;
			CMCEGEKGEEP.IMDPOICJKLF_IsBonusEnd = false;
			CMCEGEKGEEP.MKMIEGPOKGG_Soul.DJJGNDCMNHF_BonusExp = 0;
			CMCEGEKGEEP.EACDINDLGLF_Voice.DJJGNDCMNHF_BonusExp = 0;
			CMCEGEKGEEP.LDLHPACIIAB_Charm.DJJGNDCMNHF_BonusExp = 0;
			if(CMCEGEKGEEP.KPEKOOCPKID_BonusId == 0)
			{
				saveEv.ADKDHKMPMHP_Rate = Mathf.Clamp(HODCLEPALGP(OMNOFMEBLAD.GHBPLHBNMBK_FreeMusicId, OMNOFMEBLAD.AKNELONELJK_Difficulty) * LCCGDFGGIHI + saveEv.ADKDHKMPMHP_Rate, 0, 100);
				CMCEGEKGEEP.KBBOPKDLHHJ_BonusMusicProbaAfter = Mathf.Clamp(saveEv.ADKDHKMPMHP_Rate + r, 0, 100);
				LNELCMNJPIC_EventGoDiva.DPKGKNJBFBJ d = NJGBKGKFOED(OMNOFMEBLAD.GHBPLHBNMBK_FreeMusicId, Database.Instance.gameSetup.musicInfo.setupTime);
				int stBonus = FDMOAACBEGJ(CMCEGEKGEEP.KBBOPKDLHHJ_BonusMusicProbaAfter, false, d.MBAMIOJNGBD > 0 ? 2 : (d.KNEDJFLCCLN > 0 ? 1 : (d.LJELGFAFGAB > 0 ? 0 : -1)));
				CMCEGEKGEEP.JGBIFJLPCHM_IsBonusStart = stBonus > 0;
				if(CMCEGEKGEEP.JGBIFJLPCHM_IsBonusStart)
				{
					saveEv.KAPGPAMOKDD_Bns1 = stBonus;
					saveEv.ADKDHKMPMHP_Rate = ev.LPJLEHAJADA("reset_rate", 0);
				}
			}
			else
			{
				if(CMCEGEKGEEP.OENBOLPDBAB_FreeMusicId == OMNOFMEBLAD.GHBPLHBNMBK_FreeMusicId)
				{
					IBNAEKMCIEO ib = NLPCPFCIDLM(CMCEGEKGEEP.KPEKOOCPKID_BonusId, CMCEGEKGEEP.DEFAOMCNGAJ_IsBonusDaily);
					CMCEGEKGEEP.MKMIEGPOKGG_Soul.DJJGNDCMNHF_BonusExp = ib.NOEFINFEMBM;
					CMCEGEKGEEP.EACDINDLGLF_Voice.DJJGNDCMNHF_BonusExp = ib.PKDAEFIGMLI;
					CMCEGEKGEEP.LDLHPACIIAB_Charm.DJJGNDCMNHF_BonusExp = ib.DGAELGEJPNA;
					if(saveEv.PFPGHILKGIG_BnsCnt < 1)
					{
						CMCEGEKGEEP.IMDPOICJKLF_IsBonusEnd = true;
					}
				}
				CMCEGEKGEEP.KBBOPKDLHHJ_BonusMusicProbaAfter = Mathf.Clamp(saveEv.ADKDHKMPMHP_Rate + r, 0, 100);
			}
			LNELCMNJPIC_EventGoDiva.DPKGKNJBFBJ d2 = NJGBKGKFOED(OMNOFMEBLAD.GHBPLHBNMBK_FreeMusicId, OMNOFMEBLAD.NFFDIGEJHGL_ServerTime);
			int v1 = d2.LJELGFAFGAB;
			int v2 = d2.KNEDJFLCCLN;
			int v3 = d2.MBAMIOJNGBD;
			if(CMCEGEKGEEP.MKMIEGPOKGG_Soul.DJJGNDCMNHF_BonusExp + 
				CMCEGEKGEEP.EACDINDLGLF_Voice.DJJGNDCMNHF_BonusExp + 
				CMCEGEKGEEP.LDLHPACIIAB_Charm.DJJGNDCMNHF_BonusExp > 0)
			{
				v1 = 0;
				if(CMCEGEKGEEP.MKMIEGPOKGG_Soul.DJJGNDCMNHF_BonusExp > 0)
					v1 = 100;
				v2 = 0;
				if(CMCEGEKGEEP.EACDINDLGLF_Voice.DJJGNDCMNHF_BonusExp > 0)
					v2 = 100;
				v3 = 0;
				if(CMCEGEKGEEP.LDLHPACIIAB_Charm.DJJGNDCMNHF_BonusExp > 0)
					v3 = 100;
			}
			CMCEGEKGEEP.MKMIEGPOKGG_Soul.DNBFMLBNAEE = CMCEGEKGEEP.JKFCHNEININ_GetPoint * v1 / 100;
			CMCEGEKGEEP.EACDINDLGLF_Voice.DNBFMLBNAEE = CMCEGEKGEEP.JKFCHNEININ_GetPoint * v2 / 100;
			CMCEGEKGEEP.LDLHPACIIAB_Charm.DNBFMLBNAEE = CMCEGEKGEEP.JKFCHNEININ_GetPoint * v3 / 100;
			DEKKMGAFJCG_Diva.MNNLOBDPCCH_DivaInfo sDiva = CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave.DGCJCAHIAPP_Diva.NBIGLBMHEDC_DivaList[OMNOFMEBLAD.HNHCIGMKPDC_DivaIds[0] - 1];
			if(IKGLAFOHGDO)
			{
				DEKKMGAFJCG_Diva.MNNLOBDPCCH_DivaInfo nDiva = new DEKKMGAFJCG_Diva.MNNLOBDPCCH_DivaInfo();
				nDiva.ODDIHGPONFL(sDiva);
				sDiva = nDiva;
			}
			FFHPBEPOMAK_DivaInfo dInfo = new FFHPBEPOMAK_DivaInfo();
			dInfo.KHEKNNFCAOI(OMNOFMEBLAD.HNHCIGMKPDC_DivaIds[0], CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave, false);
			CMCEGEKGEEP.MKMIEGPOKGG_Soul.EJOHDINLOAJ_PrevExp = saveEv.FDBOPFEOENF_Divas[OMNOFMEBLAD.HNHCIGMKPDC_DivaIds[0] - 1].DMDLAIOJKPM_SoExp;
			CMCEGEKGEEP.MKMIEGPOKGG_Soul.AKPPMDMNOHL_StartLevel = saveEv.FDBOPFEOENF_Divas[OMNOFMEBLAD.HNHCIGMKPDC_DivaIds[0] - 1].KKGPPDLFDKA_SoLv;
			CMCEGEKGEEP.MKMIEGPOKGG_Soul.KFEMFDFPCGO_BeforeLevel = sDiva.MMCEMJILMJI_EvSoLevel;
			CMCEGEKGEEP.MKMIEGPOKGG_Soul.NMJIKIJLAMP_BeforeValue = dInfo.JLJGCBOHJID_Status.soul;
			CMCEGEKGEEP.EACDINDLGLF_Voice.EJOHDINLOAJ_PrevExp = saveEv.FDBOPFEOENF_Divas[OMNOFMEBLAD.HNHCIGMKPDC_DivaIds[0] - 1].GNBEKAELDMM_VoExp;
			CMCEGEKGEEP.EACDINDLGLF_Voice.AKPPMDMNOHL_StartLevel = saveEv.FDBOPFEOENF_Divas[OMNOFMEBLAD.HNHCIGMKPDC_DivaIds[0] - 1].IDIDIJGPPIO_VoLv;
			CMCEGEKGEEP.EACDINDLGLF_Voice.KFEMFDFPCGO_BeforeLevel = sDiva.HDPANGMKKCP_EvVoLevel;
			CMCEGEKGEEP.EACDINDLGLF_Voice.NMJIKIJLAMP_BeforeValue = dInfo.JLJGCBOHJID_Status.vocal;
			CMCEGEKGEEP.LDLHPACIIAB_Charm.EJOHDINLOAJ_PrevExp = saveEv.FDBOPFEOENF_Divas[OMNOFMEBLAD.HNHCIGMKPDC_DivaIds[0] - 1].BCANABIAIIP_ChExp;
			CMCEGEKGEEP.LDLHPACIIAB_Charm.AKPPMDMNOHL_StartLevel = saveEv.FDBOPFEOENF_Divas[OMNOFMEBLAD.HNHCIGMKPDC_DivaIds[0] - 1].OMOIGFMNFJB_ChLv;
			CMCEGEKGEEP.LDLHPACIIAB_Charm.KFEMFDFPCGO_BeforeLevel = sDiva.FFMLBEEBHDD_EvChLevel;
			CMCEGEKGEEP.LDLHPACIIAB_Charm.NMJIKIJLAMP_BeforeValue = dInfo.JLJGCBOHJID_Status.charm;
			CMCEGEKGEEP.MKMIEGPOKGG_Soul.JDCFEBMOOMN_GetExp = Mathf.Max(100, CMCEGEKGEEP.MKMIEGPOKGG_Soul.DJJGNDCMNHF_BonusExp) * CMCEGEKGEEP.MKMIEGPOKGG_Soul.DNBFMLBNAEE / 100;
			CMCEGEKGEEP.EACDINDLGLF_Voice.JDCFEBMOOMN_GetExp = Mathf.Max(100, CMCEGEKGEEP.EACDINDLGLF_Voice.DJJGNDCMNHF_BonusExp) * CMCEGEKGEEP.EACDINDLGLF_Voice.DNBFMLBNAEE / 100;
			CMCEGEKGEEP.LDLHPACIIAB_Charm.JDCFEBMOOMN_GetExp = Mathf.Max(100, CMCEGEKGEEP.LDLHPACIIAB_Charm.DJJGNDCMNHF_BonusExp) * CMCEGEKGEEP.LDLHPACIIAB_Charm.DNBFMLBNAEE / 100;
			int soulV1;
			int soulV2;
			List<int> soulV3;
			int soulV4;
			FELAPFAOHDG(0, sDiva.MMCEMJILMJI_EvSoLevel, saveEv.FDBOPFEOENF_Divas[OMNOFMEBLAD.HNHCIGMKPDC_DivaIds[0] - 1].DMDLAIOJKPM_SoExp, 
				saveEv.FDBOPFEOENF_Divas[OMNOFMEBLAD.HNHCIGMKPDC_DivaIds[0] - 1].JDHJEINPJLL_SoMExp, CMCEGEKGEEP.MKMIEGPOKGG_Soul.JDCFEBMOOMN_GetExp, 
				out soulV1, out soulV2, out soulV3, out soulV4);
			int voiceV1;
			int voiceV2;
			List<int> voiceV3;
			int voiceV4;
			FELAPFAOHDG(1, sDiva.HDPANGMKKCP_EvVoLevel, saveEv.FDBOPFEOENF_Divas[OMNOFMEBLAD.HNHCIGMKPDC_DivaIds[0] - 1].GNBEKAELDMM_VoExp, 
				saveEv.FDBOPFEOENF_Divas[OMNOFMEBLAD.HNHCIGMKPDC_DivaIds[0] - 1].OIMLBHPAMGD_VoMExp, CMCEGEKGEEP.EACDINDLGLF_Voice.JDCFEBMOOMN_GetExp, 
				out voiceV1, out voiceV2, out voiceV3, out voiceV4);
			int charmV1;
			int charmV2;
			List<int> charmV3;
			int charmV4;
			FELAPFAOHDG(2, sDiva.FFMLBEEBHDD_EvChLevel, saveEv.FDBOPFEOENF_Divas[OMNOFMEBLAD.HNHCIGMKPDC_DivaIds[0] - 1].BCANABIAIIP_ChExp, 
				saveEv.FDBOPFEOENF_Divas[OMNOFMEBLAD.HNHCIGMKPDC_DivaIds[0] - 1].PFDDNKEOKBF_ChMExp, CMCEGEKGEEP.LDLHPACIIAB_Charm.JDCFEBMOOMN_GetExp, 
				out charmV1, out charmV2, out charmV3, out charmV4);
			int godiva_max_level = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.GDEKCOOBLMA_System.LPJLEHAJADA("godiva_max_level", IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.OAINIGNLJKC_Diva2.NBJKHMLGNPA());
			sDiva.MMCEMJILMJI_EvSoLevel = soulV1;
			sDiva.HDPANGMKKCP_EvVoLevel = voiceV1;
			sDiva.FFMLBEEBHDD_EvChLevel = charmV1;
			saveEv.FDBOPFEOENF_Divas[OMNOFMEBLAD.HNHCIGMKPDC_DivaIds[0] - 1].KKGPPDLFDKA_SoLv += soulV4;
			saveEv.FDBOPFEOENF_Divas[OMNOFMEBLAD.HNHCIGMKPDC_DivaIds[0] - 1].DMDLAIOJKPM_SoExp = soulV2;
			saveEv.FDBOPFEOENF_Divas[OMNOFMEBLAD.HNHCIGMKPDC_DivaIds[0] - 1].JDHJEINPJLL_SoMExp = soulV3[soulV3.Count - 1];
			saveEv.FDBOPFEOENF_Divas[OMNOFMEBLAD.HNHCIGMKPDC_DivaIds[0] - 1].IDIDIJGPPIO_VoLv += voiceV4;
			saveEv.FDBOPFEOENF_Divas[OMNOFMEBLAD.HNHCIGMKPDC_DivaIds[0] - 1].GNBEKAELDMM_VoExp = voiceV2;
			saveEv.FDBOPFEOENF_Divas[OMNOFMEBLAD.HNHCIGMKPDC_DivaIds[0] - 1].OIMLBHPAMGD_VoMExp = voiceV3[voiceV3.Count - 1];
			saveEv.FDBOPFEOENF_Divas[OMNOFMEBLAD.HNHCIGMKPDC_DivaIds[0] - 1].OMOIGFMNFJB_ChLv += charmV4;
			saveEv.FDBOPFEOENF_Divas[OMNOFMEBLAD.HNHCIGMKPDC_DivaIds[0] - 1].BCANABIAIIP_ChExp = charmV2;
			saveEv.FDBOPFEOENF_Divas[OMNOFMEBLAD.HNHCIGMKPDC_DivaIds[0] - 1].PFDDNKEOKBF_ChMExp = charmV3[charmV3.Count - 1];
			dInfo.KHEKNNFCAOI(OMNOFMEBLAD.HNHCIGMKPDC_DivaIds[0], CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave, false);
			soulV3[soulV3.Count - 1] = saveEv.FDBOPFEOENF_Divas[OMNOFMEBLAD.HNHCIGMKPDC_DivaIds[0] - 1].JDHJEINPJLL_SoMExp;
			voiceV3[voiceV3.Count - 1] = saveEv.FDBOPFEOENF_Divas[OMNOFMEBLAD.HNHCIGMKPDC_DivaIds[0] - 1].OIMLBHPAMGD_VoMExp;
			charmV3[charmV3.Count - 1] = saveEv.FDBOPFEOENF_Divas[OMNOFMEBLAD.HNHCIGMKPDC_DivaIds[0] - 1].PFDDNKEOKBF_ChMExp;
			CMCEGEKGEEP.MKMIEGPOKGG_Soul.FKAOJEMHAKN_LevelExp = soulV3;
			CMCEGEKGEEP.MKMIEGPOKGG_Soul.LKIFDCEKDCK_NextExp = saveEv.FDBOPFEOENF_Divas[OMNOFMEBLAD.HNHCIGMKPDC_DivaIds[0] - 1].DMDLAIOJKPM_SoExp;
			CMCEGEKGEEP.MKMIEGPOKGG_Soul.GLFIELJJDCI_Level = saveEv.FDBOPFEOENF_Divas[OMNOFMEBLAD.HNHCIGMKPDC_DivaIds[0] - 1].KKGPPDLFDKA_SoLv;
			CMCEGEKGEEP.MKMIEGPOKGG_Soul.CIEOBFIIPLD_AfterLevel = sDiva.MMCEMJILMJI_EvSoLevel;
			CMCEGEKGEEP.MKMIEGPOKGG_Soul.CMCKNKKCNDK_AfterValue = dInfo.JLJGCBOHJID_Status.soul;
			CMCEGEKGEEP.EACDINDLGLF_Voice.FKAOJEMHAKN_LevelExp = voiceV3;
			CMCEGEKGEEP.EACDINDLGLF_Voice.LKIFDCEKDCK_NextExp = saveEv.FDBOPFEOENF_Divas[OMNOFMEBLAD.HNHCIGMKPDC_DivaIds[0] - 1].GNBEKAELDMM_VoExp;
			CMCEGEKGEEP.EACDINDLGLF_Voice.GLFIELJJDCI_Level = saveEv.FDBOPFEOENF_Divas[OMNOFMEBLAD.HNHCIGMKPDC_DivaIds[0] - 1].IDIDIJGPPIO_VoLv;
			CMCEGEKGEEP.EACDINDLGLF_Voice.CIEOBFIIPLD_AfterLevel = sDiva.HDPANGMKKCP_EvVoLevel;
			CMCEGEKGEEP.EACDINDLGLF_Voice.CMCKNKKCNDK_AfterValue = dInfo.JLJGCBOHJID_Status.vocal;
			CMCEGEKGEEP.LDLHPACIIAB_Charm.FKAOJEMHAKN_LevelExp = charmV3;
			CMCEGEKGEEP.LDLHPACIIAB_Charm.LKIFDCEKDCK_NextExp = saveEv.FDBOPFEOENF_Divas[OMNOFMEBLAD.HNHCIGMKPDC_DivaIds[0] - 1].BCANABIAIIP_ChExp;
			CMCEGEKGEEP.LDLHPACIIAB_Charm.GLFIELJJDCI_Level = saveEv.FDBOPFEOENF_Divas[OMNOFMEBLAD.HNHCIGMKPDC_DivaIds[0] - 1].OMOIGFMNFJB_ChLv;
			CMCEGEKGEEP.LDLHPACIIAB_Charm.CIEOBFIIPLD_AfterLevel = sDiva.FFMLBEEBHDD_EvChLevel;
			CMCEGEKGEEP.LDLHPACIIAB_Charm.CMCKNKKCNDK_AfterValue = dInfo.JLJGCBOHJID_Status.charm;
			if(!IKGLAFOHGDO)
			{
				int diff = CMCEGEKGEEP.MKMIEGPOKGG_Soul.CIEOBFIIPLD_AfterLevel - CMCEGEKGEEP.MKMIEGPOKGG_Soul.KFEMFDFPCGO_BeforeLevel;
				if(diff > 0)
				{
					do
					{
						HEFIKPAHCIA(GBNDFCEDNMG.CJDGJFINBFH.EKBKFCOCKPJ_41);
						diff--;
					} while(diff != 0);
				}
				diff = CMCEGEKGEEP.EACDINDLGLF_Voice.CIEOBFIIPLD_AfterLevel - CMCEGEKGEEP.EACDINDLGLF_Voice.KFEMFDFPCGO_BeforeLevel;
				if(diff > 0)
				{
					do
					{
						HEFIKPAHCIA(GBNDFCEDNMG.CJDGJFINBFH.NCABFNABDFI_42);
						diff--;
					} while(diff != 0);
				}
				diff = CMCEGEKGEEP.LDLHPACIIAB_Charm.CIEOBFIIPLD_AfterLevel - CMCEGEKGEEP.LDLHPACIIAB_Charm.KFEMFDFPCGO_BeforeLevel;
				if(diff > 0)
				{
					do
					{
						HEFIKPAHCIA(GBNDFCEDNMG.CJDGJFINBFH.DIMCIJDJLGK_43);
						diff--;
					} while(diff != 0);
				}
			}
        }
	}

	// // RVA: 0xA278E4 Offset: 0xA278E4 VA: 0xA278E4
	public void FELAPFAOHDG(int EAIMHLDOBAK_Type, int COGNNFOLJOJ_Lvl, int EHGAGLFLMKG_Exp, int DAOGJPAJMCC_MExp, int JDCFEBMOOMN_GetExp, out int HOOALEIBHEH_EvLv, out int FPECEECJJGO_Exp, out List<int> JDDNDGGIIGJ_Exps, out int MOGHGDGGFLO_Lv)
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
			int godiva_max_level = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.GDEKCOOBLMA_System.LPJLEHAJADA("godiva_max_level", IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.OAINIGNLJKC_Diva2.NBJKHMLGNPA());
			int max = Mathf.Max(IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.OAINIGNLJKC_Diva2.NBJKHMLGNPA(), godiva_max_level);
			for(; DAOGJPAJMCC_MExp <= FPECEECJJGO_Exp; )
			{
				COGNNFOLJOJ_Lvl++;
				MOGHGDGGFLO_Lv++;
				HOOALEIBHEH_EvLv = Mathf.Clamp(COGNNFOLJOJ_Lvl, 0, max);
				FPECEECJJGO_Exp -= DAOGJPAJMCC_MExp;
				DAOGJPAJMCC_MExp = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.OAINIGNLJKC_Diva2.OAJOMHOOCJJ(MOGHGDGGFLO_Lv + NNFJAIGDBAO(EAIMHLDOBAK_Type) + 1);
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
	public int NNFJAIGDBAO(int EAIMHLDOBAK)
	{
		CCBMJNPFPBB_EventGoDiva.KIJJHJHLBAK saveEv = CLELOGKMNCE_GetEventSaveData();
		if(saveEv != null)
		{
			int res = 0;
			for(int i = 0; i < saveEv.FDBOPFEOENF_Divas.Count; i++)
			{
				if(EAIMHLDOBAK == 2)
				{
					res += saveEv.FDBOPFEOENF_Divas[i].OMOIGFMNFJB_ChLv;
				}
				else if(EAIMHLDOBAK == 1)
				{
					res += saveEv.FDBOPFEOENF_Divas[i].IDIDIJGPPIO_VoLv;
				}
				else if(EAIMHLDOBAK == 0)
				{
					res += saveEv.FDBOPFEOENF_Divas[i].KKGPPDLFDKA_SoLv;
				}
			}
			return res;
		}
		return 0;
	}

	// // RVA: 0xA19528 Offset: 0xA19528 VA: 0xA19528
	public CCBMJNPFPBB_EventGoDiva.KIJJHJHLBAK CLELOGKMNCE_GetEventSaveData()
	{
		LNELCMNJPIC_EventGoDiva dbSection = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.LBDOLHGDIEB_GetDbSection(JOPOPMLFINI_QuestId) as LNELCMNJPIC_EventGoDiva;
		if(dbSection != null)
		{
			return CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave.JMPNGBGNCFO_EventGoDiva.FBCJICEPLED[dbSection.NGHKJOEDLIP.MOEKELIIDEO_SaveIdx];
		}
		return null;
	}

	// // RVA: 0xA2067C Offset: 0xA2067C VA: 0xA2067C
	public bool GPGPLIAHGJH(int AHHJLDLAPAN)
	{
		CCBMJNPFPBB_EventGoDiva.KIJJHJHLBAK saveData = CLELOGKMNCE_GetEventSaveData();
		if(saveData != null)
		{
			if(saveData.FDBOPFEOENF_Divas[AHHJLDLAPAN - 1].KKGPPDLFDKA_SoLv > 0 || saveData.FDBOPFEOENF_Divas[AHHJLDLAPAN - 1].DMDLAIOJKPM_SoExp > 0)
			{
				return true;
			}
			if(saveData.FDBOPFEOENF_Divas[AHHJLDLAPAN - 1].IDIDIJGPPIO_VoLv > 0 || saveData.FDBOPFEOENF_Divas[AHHJLDLAPAN - 1].GNBEKAELDMM_VoExp > 0)
			{
				return true;
			}
			if(saveData.FDBOPFEOENF_Divas[AHHJLDLAPAN - 1].OMOIGFMNFJB_ChLv > 0 || saveData.FDBOPFEOENF_Divas[AHHJLDLAPAN - 1].BCANABIAIIP_ChExp > 0)
			{
				return true;
			}
		}
		return false;
	}

	// // RVA: 0xA27DB0 Offset: 0xA27DB0 VA: 0xA27DB0 Slot: 73
	public override List<string> IJCPBPFEGDM_GetResourcesFilePathList(long JHNMKKNEENE)
	{
		if(!MNNNLDFNNCD(JHNMKKNEENE))
			return null;
		List<int> l = HEACCHAKMFG_GetMusicsList();
		if(l.Count > 0)
		{
			int mId = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.IBPAFKKEKNK_Music.NOBCLJIAMLC_GetFreeMusicData(l[0]).DLAEJOBELBH_MusicId;
			List<string> res = SoundResource.CreateBgmFilePathList(IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.IBPAFKKEKNK_Music.IAJLOELFHKC_GetMusicInfo(mId).KKPAHLMJKIH_WavId);
			if(JKIADEKHGLC_TicketItemId != 0)
			{
				res.Add(ItemTextureCache.MakeItemIconTexturePath(0));
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
	public override void EMEPJNLHJHJ(int GJEADBKFAPA, int AKNELONELJK, bool GIKLNODJKFK, ref int APMGOLOPLFP, ref int FBBDNLAMPMH)
	{
		LNELCMNJPIC_EventGoDiva ev = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.LBDOLHGDIEB_GetDbSection(JOPOPMLFINI_QuestId) as LNELCMNJPIC_EventGoDiva;
		if(ev != null)
		{
			APMGOLOPLFP = GIKLNODJKFK ? ev.GKCBPNPEJJF[GJEADBKFAPA + AKNELONELJK - 1].KFCIJBLDHOK : ev.ADPFKHEMNBL[GJEADBKFAPA + AKNELONELJK - 1].KFCIJBLDHOK;
			FBBDNLAMPMH = GIKLNODJKFK ? ev.GKCBPNPEJJF[GJEADBKFAPA + AKNELONELJK - 1].JLEIHOEGMOP : ev.ADPFKHEMNBL[GJEADBKFAPA + AKNELONELJK - 1].JLEIHOEGMOP;
		}
	}

	// // RVA: 0xA283F4 Offset: 0xA283F4 VA: 0xA283F4 Slot: 76
	public override void MMIMJPNLKBK()
	{
		if(GFHKFKHBIGM)
		{
			LNELCMNJPIC_EventGoDiva ev = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.LBDOLHGDIEB_GetDbSection(JOPOPMLFINI_QuestId) as LNELCMNJPIC_EventGoDiva;
			if(ev != null)
			{
				CCBMJNPFPBB_EventGoDiva.KIJJHJHLBAK saveEv = CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave.JMPNGBGNCFO_EventGoDiva.FBCJICEPLED[ev.NGHKJOEDLIP.MOEKELIIDEO_SaveIdx];
				saveEv.INLNJOGHLJE_Show = (int)(saveEv.INLNJOGHLJE_Show & 0xfffffffb);
				GFHKFKHBIGM = false;
			}
		}
	}

	// // RVA: 0xA28670 Offset: 0xA28670 VA: 0xA28670 Slot: 77
	public override string DBEMCLMPCFA_GetBannerText()
	{
		long t = NKGJPJPHLIF.HHCJCDFCLOB.IBLPICFDGOF_ServerRequester.FJDBNGEPKHL.KMEFBNBFJHI_GetServerTime();
		int v = GNDOGPBIGIL_GetCurrentBonusRate(t);
		if(v > 0)
		{
			return MessageManager.Instance.GetMessage("menu", "banner_godiva_fevertime");
		}
		LNELCMNJPIC_EventGoDiva ev = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.LBDOLHGDIEB_GetDbSection(JOPOPMLFINI_QuestId) as LNELCMNJPIC_EventGoDiva;
		if(ev != null)
		{
			for(int i = 0; i < ev.LLCLJBEJOPM_BannerInfo.Count; i++)
			{
				if(t >= ev.LLCLJBEJOPM_BannerInfo[i].PDBPFJJCADD_OpenAt && t < ev.LLCLJBEJOPM_BannerInfo[i].FDBNFFNFOND_CloseAt)
				{
					return ev.LLCLJBEJOPM_BannerInfo[i].KLMPFGOCBHC_BannerText;
				}
			}
		}
		return "";
	}

	// // RVA: 0xA28A60 Offset: 0xA28A60 VA: 0xA28A60 Slot: 78
	public override long OEGAJJANHGL()
	{
		LNELCMNJPIC_EventGoDiva ev = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.LBDOLHGDIEB_GetDbSection(JOPOPMLFINI_QuestId) as LNELCMNJPIC_EventGoDiva;
		if(ev != null)
		{
			return ev.NGHKJOEDLIP.JBFDHOIKAIK_InventoryEndDate;
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
	public IBNAEKMCIEO NLPCPFCIDLM(int KPEKOOCPKID, bool CGHNCPEKOCK)
	{
		LNELCMNJPIC_EventGoDiva ev = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.LBDOLHGDIEB_GetDbSection(JOPOPMLFINI_QuestId) as LNELCMNJPIC_EventGoDiva;
		if(ev != null)
		{
			LNELCMNJPIC_EventGoDiva.BGDLJMBDNOL d = ev.DLEFGPMFCMA.Find((LNELCMNJPIC_EventGoDiva.BGDLJMBDNOL GHPLINIACBB) =>
			{
				//0xA2AC04
				return KPEKOOCPKID == GHPLINIACBB.PPFNGGCBJKC;
			});
			if(d != null)
			{
				IBNAEKMCIEO d2 = new IBNAEKMCIEO();
				d2.PPFNGGCBJKC = KPEKOOCPKID;
				d2.NOEFINFEMBM = d.LJELGFAFGAB;
				d2.PKDAEFIGMLI = d.KNEDJFLCCLN;
				d2.CGHNCPEKOCK = CGHNCPEKOCK;
				d2.DGAELGEJPNA = d.MBAMIOJNGBD;
				return d2;
			}
		}
		return null;
	}

	// // RVA: 0xA26E48 Offset: 0xA26E48 VA: 0xA26E48
	public LNELCMNJPIC_EventGoDiva.DPKGKNJBFBJ NJGBKGKFOED(int GHBPLHBNMBK, long JHNMKKNEENE)
	{
		LNELCMNJPIC_EventGoDiva ev = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.LBDOLHGDIEB_GetDbSection(JOPOPMLFINI_QuestId) as LNELCMNJPIC_EventGoDiva;
		int mId = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.IBPAFKKEKNK_Music.GEAANLPDJBP_FreeMusicDatas[GHBPLHBNMBK - 1].DLAEJOBELBH_MusicId;
		int GBPDIFGKKIP = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.IBPAFKKEKNK_Music.EPMMNEFADAP_Musics[mId - 1].ACPKFNNONMH_Exp;
		int MFGBLBMHIKD = 0;
        List<LNELCMNJPIC_EventGoDiva.POLLFBLLAHL> l = ev.EAPOKGEIFKA.FindAll((LNELCMNJPIC_EventGoDiva.POLLFBLLAHL GHPLINIACBB) =>
		{
			//0xA2AC48
			return GHPLINIACBB.PPFNGGCBJKC == GBPDIFGKKIP;
		});
		for(int i = 0; i < l.Count; i++)
		{
			//LAB_00a27250
			if((l[i].PDBPFJJCADD_StartDate == 0 && l[i].FDBNFFNFOND_EndDate == 0) || (JHNMKKNEENE >= l[i].PDBPFJJCADD_StartDate && l[i].FDBNFFNFOND_EndDate >= JHNMKKNEENE))
			{
				//LAB_00a27358
				MFGBLBMHIKD = l[i].JBGEEPFKIGG;
				break;
			}
		}
		//LAB_00a273a4
		return ev.AEHKHFCKHJH.Find((LNELCMNJPIC_EventGoDiva.DPKGKNJBFBJ GHPLINIACBB) =>
		{
			//0xA2AC8C
			return GHPLINIACBB.PPFNGGCBJKC == MFGBLBMHIKD;
		});
    }

	// // RVA: 0xA26618 Offset: 0xA26618 VA: 0xA26618
	public int BDIJPOGEGNB(int GHBPLHBNMBK, int AKNELONELJK)
	{
		IBJAKJJICBC ib = new IBJAKJJICBC();
		ib.KHEKNNFCAOI(GHBPLHBNMBK, false, 0, 0, 0, PJLNJJIBFBN, false, false);
		int score = ib.MGJKEJHEBPO_DiffInfos[AKNELONELJK].CIEOBFIIPLD;
		LNELCMNJPIC_EventGoDiva ev = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.LBDOLHGDIEB_GetDbSection(JOPOPMLFINI_QuestId) as LNELCMNJPIC_EventGoDiva;
		return ev.CDMAJPFOLKK[score - 1].LKIFDCEKDCK;
	}

	// // RVA: 0xA26AF0 Offset: 0xA26AF0 VA: 0xA26AF0
	public int HODCLEPALGP(int GHBPLHBNMBK, int AKNELONELJK)
	{
		IBJAKJJICBC ib = new IBJAKJJICBC();
		ib.KHEKNNFCAOI(GHBPLHBNMBK, false, 0, 0, 0, PJLNJJIBFBN, false, false);
		LNELCMNJPIC_EventGoDiva ev = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.LBDOLHGDIEB_GetDbSection(JOPOPMLFINI_QuestId) as LNELCMNJPIC_EventGoDiva;
		return ev.CDMAJPFOLKK[ib.MGJKEJHEBPO_DiffInfos[AKNELONELJK].CIEOBFIIPLD - 1].DKHIHHMOIKM;
	}

	// // RVA: 0xA22E44 Offset: 0xA22E44 VA: 0xA22E44
	private int FDMOAACBEGJ(int KBBOPKDLHHJ, bool CGHNCPEKOCK, int EAIMHLDOBAK/* = -1*/)
	{
		LNELCMNJPIC_EventGoDiva ev = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.LBDOLHGDIEB_GetDbSection(JOPOPMLFINI_QuestId) as LNELCMNJPIC_EventGoDiva;
		if(ev != null)
		{
			if(ev.NGHKJOEDLIP != null)
			{
				int v = UnityEngine.Random.Range(0, 100);
				if(v < KBBOPKDLHHJ)
				{
					List<LNELCMNJPIC_EventGoDiva.BGDLJMBDNOL> l = new List<LNELCMNJPIC_EventGoDiva.BGDLJMBDNOL>();
					int i30 = 0;
					for(int i = 0; i < ev.DLEFGPMFCMA.Count; i++)
					{
						if(ev.DLEFGPMFCMA[i].EJFAEKPGKNJ == CGHNCPEKOCK)
						{
							if(EAIMHLDOBAK == 2)
							{
								if(ev.DLEFGPMFCMA[i].MBAMIOJNGBD < 1)
									continue;
							}
							else if(EAIMHLDOBAK == 1)
							{
								if(ev.DLEFGPMFCMA[i].KNEDJFLCCLN < 1)
									continue;
							}
							else if(EAIMHLDOBAK == 0)
							{
								if(ev.DLEFGPMFCMA[i].LJELGFAFGAB < 1)
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
							return l[i].PPFNGGCBJKC;
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
