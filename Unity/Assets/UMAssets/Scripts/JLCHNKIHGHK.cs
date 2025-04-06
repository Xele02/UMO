
using UnityEngine;
using XeApp.Game.Common;

public class JLCHNKIHGHK
{
    public enum GDJKDOMAAPG
    {
        BICPBLMPBPH_0 = 0,
        GPCMMGOCPHC_1 = 1,
        LGOHMPBLPKA_2 = 2,
        CKPGGPDJCAL_3 = 3,
    }

	public int LIPIAPOGHIP_EpisodeBonus; // 0x8
	public int PFJMBKBEFMA_EpisodeRate; // 0xC
	public int EJDJIBPKKNO_BasePoint; // 0x10
	public int BEOKMNIPFBA_MedalItemId; // 0x14
	public int ODOOKDGCKMF_MedalNum; // 0x18
	public int KNIFCANOHOC_ScorePoint; // 0x1C
	public int LMBFJMBIIGN; // 0x20
	public int JLIKEOKBBAM_HighScore; // 0x24
	public int OPILAHLPJGH_ScoreBonus; // 0x28
	public bool FFHMPNGJCLK_NewRecode; // 0x2C
	public bool FPKGGEIMAFD_HasRanking; // 0x2D
	public int HGHEENFMKGH_ScoreRanking; // 0x30
	public int JKFCHNEININ_GetPoint; // 0x34
	public int IJCLEDCNFAC_PrevPoint; // 0x38
	public int AHOKAPCGJMA_NextPoint; // 0x3C
	public int OENBOLPDBAB_FreeMusicId; // 0x40
	public int FGKABPEBFCO_BonusMusicProbaGet; // 0x44
	public int AIODBKOOCMM_BonusMusicProbaBefore; // 0x48
	public int GKFLMGHLJAB_BonusMusicProbaAfter; // 0x4C
	public bool HPPBOKAGECM_IsBonusPop; // 0x50
	public bool GNNKKJDKGJO; // 0x51
	public bool CGHNCPEKOCK_IsDaily; // 0x52
	public bool LFGNLKKFOCD_IsLine6; // 0x53
	public int AKNELONELJK_Difficulty; // 0x54
	public int JNCPEGJGHOG_JacketId; // 0x58
	public int DAJGPBLEEOB_CostumeId; // 0x5C
	public int HEHKNMCDBJJ_ColorId; // 0x60
	public int AHHJLDLAPAN_DivaId; // 0x64
	public int OMOLFAKIDIC_LevelCap; // 0x68
	public int[][] HKKJBILCDLA_ExpByLevel; // 0x6C
	public int[] CAIDKLILLNO = new int[3]; // 0x70
	public int[] GMHOPMFPBJG_GetExp = new int[3]; // 0x74
	public int[] OGOJCIIINBG_BonusExp = new int[3]; // 0x78
	public int[] IADKEFDENEG_PrevExp = new int[3]; // 0x7C
	public int[] MKPAIJGMHOJ_NextExp = new int[3]; // 0x80
	public int[] FMMNAEJEIFF_BeforeLevel = new int[3]; // 0x84
	public int[] HGMAAIJFPOI_AfterLevel = new int[3]; // 0x88
	public int[] MKOIJCGNGGI_StartLevel = new int[3]; // 0x8C
	public int[] CLDDEGBGJGK = new int[3]; // 0x90
	public int[] DFNNLEMDIPI_BeforeValue = new int[3]; // 0x94
	public int[] AECCBECCINI_AfterValue = new int[3]; // 0x98

	// // RVA: 0x1473038 Offset: 0x1473038 VA: 0x1473038
	public void KHEKNNFCAOI()
	{
        IKDICBBFBMI_EventBase ev = JEPBIIJDGEF_EventInfo.HHCJCDFCLOB.OIKOHACJPCB_GetEventById(JGEOBNENMAH.HHCJCDFCLOB.JKEPHFPCKMD_EventId);
		if(ev != null && ev.HIDHLFCBIDE_EventType == OHCAABOMEOF.KGOGMKMBCPP_EventType.BNECMLPHAGJ_EventGoDiva)
		{
			MANPIONIGNO_EventGoDiva goEv = ev as MANPIONIGNO_EventGoDiva;
			LIPIAPOGHIP_EpisodeBonus = goEv.CMCEGEKGEEP.LIPIAPOGHIP_EpBonus;
			PFJMBKBEFMA_EpisodeRate = goEv.CMCEGEKGEEP.PFJMBKBEFMA_EpRate;
			EJDJIBPKKNO_BasePoint = goEv.CMCEGEKGEEP.EJDJIBPKKNO_BasePoint;
			BEOKMNIPFBA_MedalItemId = JGEOBNENMAH.HHCJCDFCLOB.BEOKMNIPFBA_MedalItemId;
			ODOOKDGCKMF_MedalNum = JGEOBNENMAH.HHCJCDFCLOB.ODOOKDGCKMF_MedalNum;
			KNIFCANOHOC_ScorePoint = JGEOBNENMAH.HHCJCDFCLOB.GCAPLLEIAAI_LastScore;
			LMBFJMBIIGN = goEv.CMCEGEKGEEP.LMBFJMBIIGN;
			JLIKEOKBBAM_HighScore = goEv.CMCEGEKGEEP.JLIKEOKBBAM_HighScore;
			OPILAHLPJGH_ScoreBonus = goEv.CMCEGEKGEEP.JBJJFDIHKMB_ScoreBonus;
			FFHMPNGJCLK_NewRecode = goEv.CMCEGEKGEEP.FFHMPNGJCLK_NewRecode;
			FPKGGEIMAFD_HasRanking = goEv.CMCEGEKGEEP.OENBOLPDBAB_FreeMusicId == JGEOBNENMAH.HHCJCDFCLOB.PFHMFKKDMBM_FreeMusicId;
			HGHEENFMKGH_ScoreRanking = Mathf.Min(JGEOBNENMAH.HHCJCDFCLOB.NEFFKLNAAJI_ScoreRankByDiva[JGEOBNENMAH.HHCJCDFCLOB.AMJFOGHBFKJ_DivaIds[0] - 1], 99999999);
			IJCLEDCNFAC_PrevPoint = Mathf.Min(JGEOBNENMAH.HHCJCDFCLOB.FFDBCEDKMGN_PrevPoint, 99999999);
			AHOKAPCGJMA_NextPoint = Mathf.Min(JGEOBNENMAH.HHCJCDFCLOB.MMLPAMGJEOD_NewPoint, 99999999);
			JKFCHNEININ_GetPoint = AHOKAPCGJMA_NextPoint - IJCLEDCNFAC_PrevPoint;
			OENBOLPDBAB_FreeMusicId = goEv.CMCEGEKGEEP.OENBOLPDBAB_FreeMusicId;
			AIODBKOOCMM_BonusMusicProbaBefore = goEv.CMCEGEKGEEP.AONOCELOCLL_BonusMusicProbaBefore;
			GKFLMGHLJAB_BonusMusicProbaAfter = goEv.CMCEGEKGEEP.KBBOPKDLHHJ_BonusMusicProbaAfter;
			FGKABPEBFCO_BonusMusicProbaGet = GKFLMGHLJAB_BonusMusicProbaAfter - AIODBKOOCMM_BonusMusicProbaBefore;
			HPPBOKAGECM_IsBonusPop = goEv.CMCEGEKGEEP.JGBIFJLPCHM_IsBonusStart;
			GNNKKJDKGJO = goEv.CMCEGEKGEEP.IMDPOICJKLF_IsBonusEnd;
			CGHNCPEKOCK_IsDaily = goEv.CMCEGEKGEEP.DEFAOMCNGAJ_IsBonusDaily;
			IBJAKJJICBC ib = new IBJAKJJICBC();
			ib.KHEKNNFCAOI(JGEOBNENMAH.HHCJCDFCLOB.PFHMFKKDMBM_FreeMusicId, false, 0, 0, 0, false, false, false);
			LFGNLKKFOCD_IsLine6 = goEv.CMCEGEKGEEP.LFGNLKKFOCD_IsLine6;
			AKNELONELJK_Difficulty = JGEOBNENMAH.HHCJCDFCLOB.LBLOIOMNEIH_Difficulty;
			JNCPEGJGHOG_JacketId = ib.JNCPEGJGHOG_JacketId;
			DAJGPBLEEOB_CostumeId = Database.Instance.gameSetup.teamInfo.divaList[0].costumeModelId;
			HEHKNMCDBJJ_ColorId = Database.Instance.gameSetup.teamInfo.divaList[0].costumeColorId;
			AHHJLDLAPAN_DivaId = Database.Instance.gameSetup.teamInfo.divaList[0].divaId;
			CAIDKLILLNO[0] = goEv.CMCEGEKGEEP.MKMIEGPOKGG_Soul.DNBFMLBNAEE;
			CAIDKLILLNO[1] = goEv.CMCEGEKGEEP.EACDINDLGLF_Voice.DNBFMLBNAEE;
			CAIDKLILLNO[2] = goEv.CMCEGEKGEEP.LDLHPACIIAB_Charm.DNBFMLBNAEE;
			GMHOPMFPBJG_GetExp[0] = goEv.CMCEGEKGEEP.MKMIEGPOKGG_Soul.JDCFEBMOOMN_GetExp;
			GMHOPMFPBJG_GetExp[1] = goEv.CMCEGEKGEEP.EACDINDLGLF_Voice.JDCFEBMOOMN_GetExp;
			GMHOPMFPBJG_GetExp[2] = goEv.CMCEGEKGEEP.LDLHPACIIAB_Charm.JDCFEBMOOMN_GetExp;
			OGOJCIIINBG_BonusExp[0] = goEv.CMCEGEKGEEP.MKMIEGPOKGG_Soul.DJJGNDCMNHF_BonusExp;
			OGOJCIIINBG_BonusExp[1] = goEv.CMCEGEKGEEP.EACDINDLGLF_Voice.DJJGNDCMNHF_BonusExp;
			OGOJCIIINBG_BonusExp[2] = goEv.CMCEGEKGEEP.LDLHPACIIAB_Charm.DJJGNDCMNHF_BonusExp;
			IADKEFDENEG_PrevExp[0] = goEv.CMCEGEKGEEP.MKMIEGPOKGG_Soul.EJOHDINLOAJ_PrevExp;
			IADKEFDENEG_PrevExp[1] = goEv.CMCEGEKGEEP.EACDINDLGLF_Voice.EJOHDINLOAJ_PrevExp;
			IADKEFDENEG_PrevExp[2] = goEv.CMCEGEKGEEP.LDLHPACIIAB_Charm.EJOHDINLOAJ_PrevExp;
			MKPAIJGMHOJ_NextExp[0] = goEv.CMCEGEKGEEP.MKMIEGPOKGG_Soul.LKIFDCEKDCK_NextExp;
			MKPAIJGMHOJ_NextExp[1] = goEv.CMCEGEKGEEP.EACDINDLGLF_Voice.LKIFDCEKDCK_NextExp;
			MKPAIJGMHOJ_NextExp[2] = goEv.CMCEGEKGEEP.LDLHPACIIAB_Charm.LKIFDCEKDCK_NextExp;
			FMMNAEJEIFF_BeforeLevel[0] = goEv.CMCEGEKGEEP.MKMIEGPOKGG_Soul.KFEMFDFPCGO_BeforeLevel;
			FMMNAEJEIFF_BeforeLevel[1] = goEv.CMCEGEKGEEP.EACDINDLGLF_Voice.KFEMFDFPCGO_BeforeLevel;
			FMMNAEJEIFF_BeforeLevel[2] = goEv.CMCEGEKGEEP.LDLHPACIIAB_Charm.KFEMFDFPCGO_BeforeLevel;
			HGMAAIJFPOI_AfterLevel[0] = goEv.CMCEGEKGEEP.MKMIEGPOKGG_Soul.CIEOBFIIPLD_AfterLevel;
			HGMAAIJFPOI_AfterLevel[1] = goEv.CMCEGEKGEEP.EACDINDLGLF_Voice.CIEOBFIIPLD_AfterLevel;
			HGMAAIJFPOI_AfterLevel[2] = goEv.CMCEGEKGEEP.LDLHPACIIAB_Charm.CIEOBFIIPLD_AfterLevel;
			MKOIJCGNGGI_StartLevel[0] = goEv.CMCEGEKGEEP.MKMIEGPOKGG_Soul.AKPPMDMNOHL_StartLevel;
			MKOIJCGNGGI_StartLevel[1] = goEv.CMCEGEKGEEP.EACDINDLGLF_Voice.AKPPMDMNOHL_StartLevel;
			MKOIJCGNGGI_StartLevel[2] = goEv.CMCEGEKGEEP.LDLHPACIIAB_Charm.AKPPMDMNOHL_StartLevel;
			CLDDEGBGJGK[0] = goEv.CMCEGEKGEEP.MKMIEGPOKGG_Soul.GLFIELJJDCI_Level;
			CLDDEGBGJGK[1] = goEv.CMCEGEKGEEP.EACDINDLGLF_Voice.GLFIELJJDCI_Level;
			CLDDEGBGJGK[2] = goEv.CMCEGEKGEEP.LDLHPACIIAB_Charm.GLFIELJJDCI_Level;
			DFNNLEMDIPI_BeforeValue[0] = goEv.CMCEGEKGEEP.MKMIEGPOKGG_Soul.NMJIKIJLAMP_BeforeValue;
			DFNNLEMDIPI_BeforeValue[1] = goEv.CMCEGEKGEEP.EACDINDLGLF_Voice.NMJIKIJLAMP_BeforeValue;
			DFNNLEMDIPI_BeforeValue[2] = goEv.CMCEGEKGEEP.LDLHPACIIAB_Charm.NMJIKIJLAMP_BeforeValue;
			AECCBECCINI_AfterValue[0] = goEv.CMCEGEKGEEP.MKMIEGPOKGG_Soul.CMCKNKKCNDK_AfterValue;
			AECCBECCINI_AfterValue[1] = goEv.CMCEGEKGEEP.EACDINDLGLF_Voice.CMCKNKKCNDK_AfterValue;
			AECCBECCINI_AfterValue[2] = goEv.CMCEGEKGEEP.LDLHPACIIAB_Charm.CMCKNKKCNDK_AfterValue;
			OMOLFAKIDIC_LevelCap = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.OAINIGNLJKC_Diva2.NBJKHMLGNPA();
			OMOLFAKIDIC_LevelCap = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.GDEKCOOBLMA_System.LPJLEHAJADA("godiva_max_level", OMOLFAKIDIC_LevelCap);
			OMOLFAKIDIC_LevelCap = Mathf.Min(OMOLFAKIDIC_LevelCap, IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.OAINIGNLJKC_Diva2.NBJKHMLGNPA());
			HKKJBILCDLA_ExpByLevel = new int[3][];
			for(int i = 0; i < 3; i++)
			{
				HKKJBILCDLA_ExpByLevel[i] = new int[OMOLFAKIDIC_LevelCap + 1];
				int j2 = 0;
				for(int j = 0; j + 1 < HKKJBILCDLA_ExpByLevel[i].Length; j++)
				{
					if(MKOIJCGNGGI_StartLevel[i] <= j && j <= CLDDEGBGJGK[i])
					{
						if(i == 2)
						{
							HKKJBILCDLA_ExpByLevel[2][j + 1] = goEv.CMCEGEKGEEP.LDLHPACIIAB_Charm.FKAOJEMHAKN_LevelExp[j2];
						}
						else if(i == 1)
						{
							HKKJBILCDLA_ExpByLevel[1][j + 1] = goEv.CMCEGEKGEEP.EACDINDLGLF_Voice.FKAOJEMHAKN_LevelExp[j2];
						}
						else if(i == 0)
						{
							HKKJBILCDLA_ExpByLevel[0][j + 1] = goEv.CMCEGEKGEEP.MKMIEGPOKGG_Soul.FKAOJEMHAKN_LevelExp[j2];
						}
						j2++;
					}
				}
			}
		}
    }

	// // RVA: 0x14747C8 Offset: 0x14747C8 VA: 0x14747C8
	// public void BDBIJBBKGMC() { }
}
