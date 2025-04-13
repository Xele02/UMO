
using XeApp.Game.Common;
using System.Collections.Generic;
using UnityEngine;
using System;
using XeApp.Game.RhythmGame;

public static class CMMKCEPBIHI
{
    public enum NOJENDEDECD_ScoreType
    {
        HNGJDMNPMNP_BaseScore = 0,
        KBHGPMNGALJ = 1,
        AJIDOFDBIDL = 2,
        NLAGKLDCBAG_Combo = 3,
        GJDKJOHIEFF_PlateScore = 4,
        BMMPEPDFICC_CenterSkillScore = 5,
        CPJOGHCLENG_LiveSkillScore = 6,
        NKPLJNILBFP_ASkillScore = 7,
        GGOOOIKELDH_NotesScore = 8,
        OPCNHIMPGCE_LeafScore = 9,
        AEFCOHJBLPO = 10,
    }

	private const int IMNILJDBFDL = 30;
	private const int NPMLACIOKJE = 1;
	private static StatusData GCECPDEOIIN = new StatusData(); // 0x0
	private static Comparison<GCIJNCFDNON_SceneInfo>[] MOGECDOLPPL = new Comparison<GCIJNCFDNON_SceneInfo>[3] {
        (GCIJNCFDNON_SceneInfo HKICMNAACDA, GCIJNCFDNON_SceneInfo BNKHBCBJBKI) => {
            //0x175A31C
			return BNKHBCBJBKI.CMCKNKKCNDK_Status.soul - HKICMNAACDA.CMCKNKKCNDK_Status.soul;
        },
        (GCIJNCFDNON_SceneInfo HKICMNAACDA, GCIJNCFDNON_SceneInfo BNKHBCBJBKI) => {
            //0x175A39C
			return BNKHBCBJBKI.CMCKNKKCNDK_Status.vocal - HKICMNAACDA.CMCKNKKCNDK_Status.vocal;
        },
        (GCIJNCFDNON_SceneInfo HKICMNAACDA, GCIJNCFDNON_SceneInfo BNKHBCBJBKI) => {
            //0x175A41C
			return BNKHBCBJBKI.CMCKNKKCNDK_Status.charm - HKICMNAACDA.CMCKNKKCNDK_Status.charm;
        }
    }; // 0x4
	private static Func<StatusData, int>[] HDLKMMHKOKE = new Func<StatusData, int>[3] {
        (StatusData IBDJFHFIIHN) => {
            //0x175A49C
			return IBDJFHFIIHN.soul;
        },
        (StatusData IBDJFHFIIHN) => {
            //0x175A4C0
			return IBDJFHFIIHN.vocal;
        },
        (StatusData IBDJFHFIIHN) => {
            //0x175A4E4
			return IBDJFHFIIHN.charm;
        }
    }; // 0x8
	private static Action<StatusData, int>[] HOBOLJEFDFF = new Action<StatusData, int>[3] {
        (StatusData IBDJFHFIIHN, int OHDPMGMGJBI) => {
            //0x175A508
			IBDJFHFIIHN.soul += OHDPMGMGJBI;
        },
        (StatusData IBDJFHFIIHN, int OHDPMGMGJBI) => {
            //0x175A54C
			IBDJFHFIIHN.vocal += OHDPMGMGJBI;
        },
        (StatusData IBDJFHFIIHN, int OHDPMGMGJBI) => {
            //0x175A590
			IBDJFHFIIHN.charm += OHDPMGMGJBI;
        }
    }; // 0xC
	private static int[] OOPMCKOCEFM_Scores = new int[10]; // 0x10
	private static float[] LKBGHCIKIOA_RankScore = new float[5]; // 0x14
	private static int[] HCEPBDBHILM_ScoreAdjust = new int[10] { 100, 100, 100, 90, 100, 100, 90, 90, 90, 90 }; // 0x18
	private static string[] DALGMKEOFLN_ScoreRatioNameByDiff = new string[8] {"score_gauge_e", "score_gauge_n", "score_gauge_h", "score_gauge_vh", 
        "score_gauge_ex", "score_gauge_h+", "score_gauge_vh+", "score_gauge_ex+"}; // 0x1C
	private static StatusData FLOHCPIIHEH_WorkStatus = new StatusData(); // 0x20
	private static AEKDNMPPOJN OMPNCHBNEPF = new AEKDNMPPOJN(); // 0x24
	private static LimitOverStatusData MEMCOJHNEIP = new LimitOverStatusData(); // 0x28
	private static List<int> AONMBIEIBCD = new List<int>(); // 0x2C
	private static List<int> FOMKBDKKODO = new List<int>(); // 0x30
	private static int AFBHKBGLMHG = 245; // 0x34
	private static List<int> DNJCAKPKNDP_ScoreRatioByDifficulty = new List<int>(); // 0x38

	public static ResultScoreRank.Type KHCOOPDAGOE_ScoreRank { get; private set; } // 0x3C MHJDBFONNKN CKNLMMGELDF GEENHBHNFIC
	public static float FDLECNKJCGG_GaugeRatio { get; private set; } // 0x40 DCBOMKOHHEP IGEHABMEOHD FOLIPOFKIJA

	// // RVA: 0x1085914 Offset: 0x1085914 VA: 0x1085914
	public static void DIDENKKDJKI(ref AEGLGBOGDHH HBODCMLFDOB, JLKEOGLJNOD_TeamInfo MLAFAACKKBG, DFKGGBMFFGB_PlayerInfo AHEFHIMGIBI, EEDKAACNBBG_MusicData KKHIDFKKFJE, EAJCBFGKKFA_FriendInfo PCEGKKLKFNO, EJKBKMBJMGL_EnemyData KDOLMBEAGCI)
	{
		for(int i = 0; i < MLAFAACKKBG.BCJEAJPLGMB_MainDivas.Count; i++)
		{
			FFHPBEPOMAK_DivaInfo divaInfo = MLAFAACKKBG.BCJEAJPLGMB_MainDivas[i];
			if(divaInfo != null)
			{
				AECDJDIJJKD_ApplySkills(ref HBODCMLFDOB.GJLJJDIDODK[i], divaInfo, MLAFAACKKBG, AHEFHIMGIBI, KKHIDFKKFJE, PCEGKKLKFNO, KDOLMBEAGCI);
			}
		}
		NJNBELLEGCN(ref HBODCMLFDOB.CLCIOEHGFNI, MLAFAACKKBG, AHEFHIMGIBI, KKHIDFKKFJE, PCEGKKLKFNO, KDOLMBEAGCI);
		NIPJMNDBCNF(ref HBODCMLFDOB.JPMGNPAHGIB, MLAFAACKKBG, PCEGKKLKFNO, AHEFHIMGIBI, KKHIDFKKFJE, KDOLMBEAGCI);
	}

	// // RVA: 0x1085B98 Offset: 0x1085B98 VA: 0x1085B98
	public static void AECDJDIJJKD_ApplySkills(ref EDMIONMCICN HBODCMLFDOB, FFHPBEPOMAK_DivaInfo DGCJCAHIAPP_DivaInfo, JLKEOGLJNOD_TeamInfo MLAFAACKKBG_Team, DFKGGBMFFGB_PlayerInfo AHEFHIMGIBI_PlayerData, EEDKAACNBBG_MusicData KKHIDFKKFJE_MusicData, EAJCBFGKKFA_FriendInfo PCEGKKLKFNO_FriendData, EJKBKMBJMGL_EnemyData KDOLMBEAGCI_EnemyData)
	{
		HBODCMLFDOB.JCHLONCMPAJ_Reset();
		HPODBOHGGDH_SkillInfo skillInfo = new HPODBOHGGDH_SkillInfo();
		skillInfo.JCHLONCMPAJ_Reset();
		int divaIdx = -1;
		if(MLAFAACKKBG_Team != null)
		{
			divaIdx = MLAFAACKKBG_Team.BCJEAJPLGMB_MainDivas.FindIndex((FFHPBEPOMAK_DivaInfo FDBOPFEOENF) => {
				//0x175A5DC
				if(FDBOPFEOENF == null)
					return false;
				return FDBOPFEOENF.AHHJLDLAPAN_DivaId == DGCJCAHIAPP_DivaInfo.AHHJLDLAPAN_DivaId;
			});
		}
		int skillId = DGCJCAHIAPP_DivaInfo.FFKMJNHFFFL_Costume.ENMAEBJGEKL_SkillId;
		if(skillId != 0)
		{
			skillInfo.EDEDFDDIOKO_Set(skillId, DGCJCAHIAPP_DivaInfo.FFKMJNHFFFL_Costume.DEOBDFOPLHG_SkillLevel, (SeriesAttr.Type)DGCJCAHIAPP_DivaInfo.AIHCEGFANAM_Serie);
			AECDJDIJJKD_ApplySkillForDiva(ref HBODCMLFDOB, DGCJCAHIAPP_DivaInfo, AHEFHIMGIBI_PlayerData.OPIBAPEGCLA_Scenes, KKHIDFKKFJE_MusicData, JNKEEAOKNCI_Skill.MKGJHBAKMBD_SkillType.KBHGPMNGALJ_CostumeSkill, ref skillInfo, divaIdx, MLAFAACKKBG_Team);
		}
		if(MLAFAACKKBG_Team != null)
		{
			if(MLAFAACKKBG_Team.BCJEAJPLGMB_MainDivas[0] != null && 
				MLAFAACKKBG_Team.BCJEAJPLGMB_MainDivas[0].FGFIBOBAPIA_SceneId != 0)
			{
				GCIJNCFDNON_SceneInfo sceneInfo = AHEFHIMGIBI_PlayerData.OPIBAPEGCLA_Scenes[MLAFAACKKBG_Team.BCJEAJPLGMB_MainDivas[0].FGFIBOBAPIA_SceneId - 1];
				int skillSceneId = 0;
				if(KKHIDFKKFJE_MusicData == null)
				{
					skillSceneId = sceneInfo.MEOOLHNNMHL_GetCenterSkillId(false, 0, 0);
				}
				else
				{
					skillSceneId = sceneInfo.MEOOLHNNMHL_GetCenterSkillId(false, KKHIDFKKFJE_MusicData.FKDCCLPGKDK_JacketAttr, KKHIDFKKFJE_MusicData.AIHCEGFANAM_Serie);
				}
				if(skillSceneId != 0)
				{
					skillInfo.EDEDFDDIOKO_Set(skillSceneId, sceneInfo.DDEDANKHHPN_SkillLevel, sceneInfo.AIHCEGFANAM_SceneSeries);
					AECDJDIJJKD_ApplySkillForDiva(ref HBODCMLFDOB, DGCJCAHIAPP_DivaInfo, AHEFHIMGIBI_PlayerData.OPIBAPEGCLA_Scenes, KKHIDFKKFJE_MusicData, JNKEEAOKNCI_Skill.MKGJHBAKMBD_SkillType.MHKFDBLMOGF_SceneSkill, ref skillInfo, divaIdx, MLAFAACKKBG_Team);
				}
			}
		}
		if(PCEGKKLKFNO_FriendData != null && PCEGKKLKFNO_FriendData.KHGKPKDBMOH_GetAssistScene() != null)
		{
			skillId = 0;
			GCIJNCFDNON_SceneInfo sceneInfo = PCEGKKLKFNO_FriendData.KHGKPKDBMOH_GetAssistScene();
			int skillSceneId = 0;
			if(KKHIDFKKFJE_MusicData == null)
			{
				skillSceneId = sceneInfo.MEOOLHNNMHL_GetCenterSkillId(false, 0, 0);
			}
			else
			{
				skillSceneId = sceneInfo.MEOOLHNNMHL_GetCenterSkillId(false, KKHIDFKKFJE_MusicData.FKDCCLPGKDK_JacketAttr, KKHIDFKKFJE_MusicData.AIHCEGFANAM_Serie);
			}
			if(skillSceneId != 0)
			{
				skillInfo.EDEDFDDIOKO_Set(skillSceneId, sceneInfo.DDEDANKHHPN_SkillLevel, sceneInfo.AIHCEGFANAM_SceneSeries);
				AECDJDIJJKD_ApplySkillForDiva(ref HBODCMLFDOB, DGCJCAHIAPP_DivaInfo, AHEFHIMGIBI_PlayerData.OPIBAPEGCLA_Scenes, KKHIDFKKFJE_MusicData, JNKEEAOKNCI_Skill.MKGJHBAKMBD_SkillType.MHKFDBLMOGF_SceneSkill, ref skillInfo, divaIdx, MLAFAACKKBG_Team);
			}
		}
		if(KKHIDFKKFJE_MusicData != null)
		{
			for(int i = 0; i < DGCJCAHIAPP_DivaInfo.DJICAKGOGFO_SubSceneIds.Count + 1; i++)
			{
				GCIJNCFDNON_SceneInfo sceneInfo = null;
				StatusData st = null;
				if(i == 0)
				{
					if(DGCJCAHIAPP_DivaInfo.FGFIBOBAPIA_SceneId != 0)
					{
						sceneInfo = AHEFHIMGIBI_PlayerData.OPIBAPEGCLA_Scenes[DGCJCAHIAPP_DivaInfo.FGFIBOBAPIA_SceneId - 1];
						st = HBODCMLFDOB.BJABFKMIJHB_StatusMainScene;
					}
				}
				else
				{
					if(DGCJCAHIAPP_DivaInfo.DJICAKGOGFO_SubSceneIds[i - 1] != 0)
					{
						sceneInfo = AHEFHIMGIBI_PlayerData.OPIBAPEGCLA_Scenes[DGCJCAHIAPP_DivaInfo.DJICAKGOGFO_SubSceneIds[i - 1] - 1];
						st = HBODCMLFDOB.OBCPFDNKLMM_StatusSubScenes[i - 1];
					}
				}
				if(sceneInfo != null)
				{
					bool comp = KKHIDFKKFJE_MusicData.FKDCCLPGKDK_JacketAttr == 4 || KKHIDFKKFJE_MusicData.FKDCCLPGKDK_JacketAttr == sceneInfo.JGJFIJOCPAG_SceneAttr;
					if(comp && st != null)
					{
						st.soul += sceneInfo.CMCKNKKCNDK_Status.soul;
						st.vocal += sceneInfo.CMCKNKKCNDK_Status.vocal;
						st.charm += sceneInfo.CMCKNKKCNDK_Status.charm;
						HBODCMLFDOB.MCBLDOECHEK_MatchMusicAttrStatus[i].LDLHPACIIAB_Soul = sceneInfo.CMCKNKKCNDK_Status.soul * 30 / 100;
						HBODCMLFDOB.MCBLDOECHEK_MatchMusicAttrStatus[i].MKMIEGPOKGG_Vocal = sceneInfo.CMCKNKKCNDK_Status.vocal * 30 / 100;
						HBODCMLFDOB.MCBLDOECHEK_MatchMusicAttrStatus[i].EACDINDLGLF_Charm = sceneInfo.CMCKNKKCNDK_Status.charm * 30 / 100;
						HBODCMLFDOB.LGGLFAECCBK_BonusTypeFlag |= MKHCIKICBOI.MKADAMIGMPO_SoulVocalCharm/*7*/;
					}
				}
			}
		}
		if(KDOLMBEAGCI_EnemyData != null && KDOLMBEAGCI_EnemyData.PDHCABLLJPB_CenterSkillId != 0)
		{
			skillInfo.EDEDFDDIOKO_Set(KDOLMBEAGCI_EnemyData.PDHCABLLJPB_CenterSkillId, 1, 0);
			AECDJDIJJKD_ApplySkillForDiva(ref HBODCMLFDOB, DGCJCAHIAPP_DivaInfo, AHEFHIMGIBI_PlayerData.OPIBAPEGCLA_Scenes, KKHIDFKKFJE_MusicData, JNKEEAOKNCI_Skill.MKGJHBAKMBD_SkillType.AIFGINAKBMA_EnemySkill, ref skillInfo, divaIdx, MLAFAACKKBG_Team);
		}
		HBODCMLFDOB.ELFAIDEBLJB.Div(100);
		HBODCMLFDOB.IMLGBMGIACC.Div(100);
		HBODCMLFDOB.BJABFKMIJHB_StatusMainScene.Div(100);
		HBODCMLFDOB.AJINBLGCBMM_StatusCostumeMainScene.Div(100);
		for(int i = 0; i < HBODCMLFDOB.OBCPFDNKLMM_StatusSubScenes.Length; i++)
		{
			HBODCMLFDOB.OBCPFDNKLMM_StatusSubScenes[i].Div(100);
			HBODCMLFDOB.FEGNMIGJMDM_CostumeSubScene[i].Div(100);
		}
	}

	// // RVA: 0x1087134 Offset: 0x1087134 VA: 0x1087134
	public static void NIPJMNDBCNF(ref EDMIONMCICN HBODCMLFDOB, JLKEOGLJNOD_TeamInfo MLAFAACKKBG_Team, EAJCBFGKKFA_FriendInfo PCEGKKLKFNO_FriendData, DFKGGBMFFGB_PlayerInfo AHEFHIMGIBI_PlayerData, EEDKAACNBBG_MusicData KKHIDFKKFJE_MusicData, EJKBKMBJMGL_EnemyData KDOLMBEAGCI_EnemyData)
	{
		HPODBOHGGDH_SkillInfo data = new HPODBOHGGDH_SkillInfo();
		HBODCMLFDOB.JCHLONCMPAJ_Reset();
		if(PCEGKKLKFNO_FriendData != null)
		{
			PCEGKKLKFNO_FriendData.KHGKPKDBMOH_GetAssistScene();
			data.JCHLONCMPAJ_Reset();
			if(MLAFAACKKBG_Team != null)
			{
				FFHPBEPOMAK_DivaInfo divaInfo = MLAFAACKKBG_Team.BCJEAJPLGMB_MainDivas[0];
				if(divaInfo != null && divaInfo.FGFIBOBAPIA_SceneId > 0)
				{
					GCIJNCFDNON_SceneInfo sceneInfo = AHEFHIMGIBI_PlayerData.OPIBAPEGCLA_Scenes[divaInfo.FGFIBOBAPIA_SceneId - 1];
					int a = 0;
					if(KKHIDFKKFJE_MusicData == null)
					{
						a = sceneInfo.MEOOLHNNMHL_GetCenterSkillId(false, 0, 0);
					}
					else
					{
						a = sceneInfo.MEOOLHNNMHL_GetCenterSkillId(false, KKHIDFKKFJE_MusicData.FKDCCLPGKDK_JacketAttr, KKHIDFKKFJE_MusicData.AIHCEGFANAM_Serie);
					}
					if(a != 0)
					{
						data.EDEDFDDIOKO_Set(a, sceneInfo.DDEDANKHHPN_SkillLevel, sceneInfo.AIHCEGFANAM_SceneSeries);
						AECDJDIJJKD_ApplySkillForDivaAndScenes(ref HBODCMLFDOB, PCEGKKLKFNO_FriendData.JIGONEMPPNP_Diva, PCEGKKLKFNO_FriendData.KHGKPKDBMOH_GetAssistScene(), PCEGKKLKFNO_FriendData.HDJOHAJPGBA_SubScene[0], PCEGKKLKFNO_FriendData.HDJOHAJPGBA_SubScene[1], KKHIDFKKFJE_MusicData, 0, ref data, -1, MLAFAACKKBG_Team);
					}
				}
			}
			if(PCEGKKLKFNO_FriendData.KHGKPKDBMOH_GetAssistScene() != null)
			{
				int a = PCEGKKLKFNO_FriendData.KHGKPKDBMOH_GetAssistScene().MEOOLHNNMHL_GetCenterSkillId(false, KKHIDFKKFJE_MusicData == null ? 0 : KKHIDFKKFJE_MusicData.FKDCCLPGKDK_JacketAttr, KKHIDFKKFJE_MusicData == null ? 0 : KKHIDFKKFJE_MusicData.AIHCEGFANAM_Serie);
				if(a != 0)
				{
					data.EDEDFDDIOKO_Set(a, PCEGKKLKFNO_FriendData.KHGKPKDBMOH_GetAssistScene().DDEDANKHHPN_SkillLevel, PCEGKKLKFNO_FriendData.KHGKPKDBMOH_GetAssistScene().AIHCEGFANAM_SceneSeries);
					AECDJDIJJKD_ApplySkillForDivaAndScenes(ref HBODCMLFDOB, PCEGKKLKFNO_FriendData.JIGONEMPPNP_Diva, PCEGKKLKFNO_FriendData.KHGKPKDBMOH_GetAssistScene(), PCEGKKLKFNO_FriendData.HDJOHAJPGBA_SubScene[0], PCEGKKLKFNO_FriendData.HDJOHAJPGBA_SubScene[1], KKHIDFKKFJE_MusicData, 0, ref data, -1, MLAFAACKKBG_Team);
				}
			}
			if(KKHIDFKKFJE_MusicData != null)
			{
				for(int i = 0; i < PCEGKKLKFNO_FriendData.JIGONEMPPNP_Diva.DJICAKGOGFO_SubSceneIds.Count + 1; i++)
				{
					bool isAttrValid = false;
					StatusData st = null;
					StatusData st2 = null;
					if (i == 0)
					{
						if (PCEGKKLKFNO_FriendData.KHGKPKDBMOH_GetAssistScene() != null)
						{
							st2 = PCEGKKLKFNO_FriendData.KHGKPKDBMOH_GetAssistScene().CMCKNKKCNDK_Status;
							isAttrValid = KKHIDFKKFJE_MusicData.FKDCCLPGKDK_JacketAttr == 4 || KKHIDFKKFJE_MusicData.FKDCCLPGKDK_JacketAttr == PCEGKKLKFNO_FriendData.KHGKPKDBMOH_GetAssistScene().JGJFIJOCPAG_SceneAttr;
							st = HBODCMLFDOB.BJABFKMIJHB_StatusMainScene;
						}
					}
					else
					{
						GCIJNCFDNON_SceneInfo sceneInfo = PCEGKKLKFNO_FriendData.HDJOHAJPGBA_SubScene[i - 1];
						if (sceneInfo != null)
						{
							st2 = sceneInfo.CMCKNKKCNDK_Status;
							isAttrValid = KKHIDFKKFJE_MusicData.FKDCCLPGKDK_JacketAttr == 4 || KKHIDFKKFJE_MusicData.FKDCCLPGKDK_JacketAttr == sceneInfo.JGJFIJOCPAG_SceneAttr;
							st = HBODCMLFDOB.OBCPFDNKLMM_StatusSubScenes[i - 1];
						}
					}
					if(isAttrValid &&  st != null)
					{
						st.soul += st2.soul * 30;
						st.vocal += st2.vocal * 30;
						st.charm += st2.charm * 30;
						HBODCMLFDOB.MCBLDOECHEK_MatchMusicAttrStatus[i].MKMIEGPOKGG_Vocal = (st2.soul * 30) / 100;
						HBODCMLFDOB.MCBLDOECHEK_MatchMusicAttrStatus[i].EACDINDLGLF_Charm = (st2.vocal * 30) / 100;
						HBODCMLFDOB.MCBLDOECHEK_MatchMusicAttrStatus[i].LDLHPACIIAB_Soul = (st2.charm * 30) / 100;
						if(i == 0)
						{
							HBODCMLFDOB.LGGLFAECCBK_BonusTypeFlag |= MKHCIKICBOI.MKADAMIGMPO_SoulVocalCharm/*7*/;
						}
					}
				}
			}
			if(KDOLMBEAGCI_EnemyData != null && KDOLMBEAGCI_EnemyData.PDHCABLLJPB_CenterSkillId != 0)
			{
				data.EDEDFDDIOKO_Set(KDOLMBEAGCI_EnemyData.PDHCABLLJPB_CenterSkillId, 1, 0);
				AECDJDIJJKD_ApplySkillForDivaAndScenes(ref HBODCMLFDOB, PCEGKKLKFNO_FriendData.JIGONEMPPNP_Diva, PCEGKKLKFNO_FriendData.KHGKPKDBMOH_GetAssistScene(), PCEGKKLKFNO_FriendData.HDJOHAJPGBA_SubScene[0], PCEGKKLKFNO_FriendData.HDJOHAJPGBA_SubScene[1], KKHIDFKKFJE_MusicData, JNKEEAOKNCI_Skill.MKGJHBAKMBD_SkillType.AIFGINAKBMA_EnemySkill, ref data, -1, MLAFAACKKBG_Team);
			}
			HBODCMLFDOB.ELFAIDEBLJB.Div(100);
			HBODCMLFDOB.BJABFKMIJHB_StatusMainScene.Div(100);
			for(int i = 0; i < HBODCMLFDOB.OBCPFDNKLMM_StatusSubScenes.Length; i++)
			{
				HBODCMLFDOB.OBCPFDNKLMM_StatusSubScenes[i].Div(100);
			}
		}
	}

	// // RVA: 0x1087C58 Offset: 0x1087C58 VA: 0x1087C58
	private static void AECDJDIJJKD_ApplySkillForDiva(ref EDMIONMCICN HBODCMLFDOB, FFHPBEPOMAK_DivaInfo DGCJCAHIAPP_DivaInfo, List<GCIJNCFDNON_SceneInfo> OPIBAPEGCLA_Scenes, EEDKAACNBBG_MusicData KKHIDFKKFJE_MusicData, JNKEEAOKNCI_Skill.MKGJHBAKMBD_SkillType GJLFANGDGCL_SkillType, ref HPODBOHGGDH_SkillInfo CHMOEPNAJOO_SkillInfo, int ABBDKBOIBCG_DivaIdx, JLKEOGLJNOD_TeamInfo MLAFAACKKBG_TeamInfo)
	{
		GCIJNCFDNON_SceneInfo sceneInfo = null;
		if(DGCJCAHIAPP_DivaInfo.FGFIBOBAPIA_SceneId != 0)
		{
			sceneInfo = OPIBAPEGCLA_Scenes[DGCJCAHIAPP_DivaInfo.FGFIBOBAPIA_SceneId - 1];
		}
		GCIJNCFDNON_SceneInfo sub1Info = null;
		int sId = DGCJCAHIAPP_DivaInfo.DJICAKGOGFO_SubSceneIds[0];
		if(sId != 0)
		{
			sub1Info = OPIBAPEGCLA_Scenes[sId - 1];
		}
		GCIJNCFDNON_SceneInfo sub2Info = null;
		sId = DGCJCAHIAPP_DivaInfo.DJICAKGOGFO_SubSceneIds[1];
		if(sId != 0)
		{
			sub2Info = OPIBAPEGCLA_Scenes[sId - 1];
		}
		AECDJDIJJKD_ApplySkillForDivaAndScenes(ref HBODCMLFDOB, DGCJCAHIAPP_DivaInfo, sceneInfo, sub1Info, sub2Info, KKHIDFKKFJE_MusicData, GJLFANGDGCL_SkillType, ref CHMOEPNAJOO_SkillInfo, ABBDKBOIBCG_DivaIdx, MLAFAACKKBG_TeamInfo);
	}

	// // RVA: 0x1087F7C Offset: 0x1087F7C VA: 0x1087F7C
	private static void AECDJDIJJKD_ApplySkillForDivaAndScenes(ref EDMIONMCICN HBODCMLFDOB, FFHPBEPOMAK_DivaInfo DGCJCAHIAPP_DivaInfo, GCIJNCFDNON_SceneInfo AFBMEMCHJCL_MainScene, GCIJNCFDNON_SceneInfo HAPFNHPFBGD_SubScene1, GCIJNCFDNON_SceneInfo JEBHFJEJAKJ_SubScene2, EEDKAACNBBG_MusicData KKHIDFKKFJE_MusicInfo, JNKEEAOKNCI_Skill.MKGJHBAKMBD_SkillType GJLFANGDGCL_SkillType, ref HPODBOHGGDH_SkillInfo CHMOEPNAJOO_SkillInfo, int ABBDKBOIBCG_DivaIdx, JLKEOGLJNOD_TeamInfo MLAFAACKKBG_TeamInfo)
	{
		List<HBDCPGLAPHH> skillsList;
		if(GJLFANGDGCL_SkillType == JNKEEAOKNCI_Skill.MKGJHBAKMBD_SkillType.KBHGPMNGALJ_CostumeSkill)
		{
			skillsList = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.FOFADHAENKC_Skill.BIOEJKBCIKD_CenterSkillCostume;
		}
		else if (GJLFANGDGCL_SkillType == JNKEEAOKNCI_Skill.MKGJHBAKMBD_SkillType.AIFGINAKBMA_EnemySkill)
		{
			skillsList = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.FOFADHAENKC_Skill.FFCFHFOIKGB_CenterSkillEnemy;
		}
		else
		{
			skillsList = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.FOFADHAENKC_Skill.COLCPGFABLP_CenterSkills;
		}
		HBDCPGLAPHH skill = skillsList[CHMOEPNAJOO_SkillInfo.ENMAEBJGEKL_Id - 1];
		for(int i = 0; i < 2; i++)
		{
			KFCIIMBBNCD effectInfo = null;
			int skillId = 0;
			if (i == 1)
			{
				if (skill.AKGNPLBDKLN_P2 == 0)
					return;
				skillId = skill.AKGNPLBDKLN_P2;
				effectInfo = KDDDDMMMBHE_GetEffectInfo(IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.FOFADHAENKC_Skill, skill.AKGNPLBDKLN_P2, GJLFANGDGCL_SkillType);
			}
			else if(i == 0)
			{
				if(skill.HEKHODDJHAO_P1 != 0)
				{
					skillId = skill.HEKHODDJHAO_P1;
					effectInfo = KDDDDMMMBHE_GetEffectInfo(IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.FOFADHAENKC_Skill, skill.HEKHODDJHAO_P1, GJLFANGDGCL_SkillType);
				}
				else
					continue;
			}
			if (effectInfo != null)
			{
				SeriesAttr.Type serie = 0;
				if (AFBMEMCHJCL_MainScene != null && KKHIDFKKFJE_MusicInfo != null)
				{
					serie = (SeriesAttr.Type)KKHIDFKKFJE_MusicInfo.AIHCEGFANAM_Serie;
					if (serie != CHMOEPNAJOO_SkillInfo.AIHCEGFANAM_Serie)
						serie = 0;
				}
				if (FNIEADNMMIA_CenterSkillCondMatchMusic((CenterSkillCondition.Type)effectInfo.OAFPGJLCNFM_CenterSkillCondition, KKHIDFKKFJE_MusicInfo, serie))
				{
					if (FLPKCFDANMK_DivaMatchTarget(DGCJCAHIAPP_DivaInfo, (CenterSkillTarget.Type)effectInfo.GJLFANGDGCL_CenterSkillTarget, ABBDKBOIBCG_DivaIdx))
					{
						StatusData st = HBODCMLFDOB.ELFAIDEBLJB;
						if (GJLFANGDGCL_SkillType == JNKEEAOKNCI_Skill.MKGJHBAKMBD_SkillType.KBHGPMNGALJ_CostumeSkill)
							st = HBODCMLFDOB.IMLGBMGIACC;
						KDOFDLIMHJG_ApplySkill(ref st, DGCJCAHIAPP_DivaInfo.JLJGCBOHJID_Status, GJLFANGDGCL_SkillType, skillId, CHMOEPNAJOO_SkillInfo.CNLIAMIIJID_Level, MLAFAACKKBG_TeamInfo);
						if (GJLFANGDGCL_SkillType != JNKEEAOKNCI_Skill.MKGJHBAKMBD_SkillType.KBHGPMNGALJ_CostumeSkill)
						{
							LBBNJAGGCBB_SetBonusFlag(ref HBODCMLFDOB, st);
							if (GJLFANGDGCL_SkillType == JNKEEAOKNCI_Skill.MKGJHBAKMBD_SkillType.AIFGINAKBMA_EnemySkill)
							{
								GCECPDEOIIN.Clear();
								KDOFDLIMHJG_ApplySkill(ref st, DGCJCAHIAPP_DivaInfo.JLJGCBOHJID_Status, JNKEEAOKNCI_Skill.MKGJHBAKMBD_SkillType.AIFGINAKBMA_EnemySkill, skillId, CHMOEPNAJOO_SkillInfo.CNLIAMIIJID_Level, MLAFAACKKBG_TeamInfo);
								MEICPKJFJOA_SetMalusFlag(ref HBODCMLFDOB, st);
							}
						}
					}
					for (int j = 0; j < DGCJCAHIAPP_DivaInfo.DJICAKGOGFO_SubSceneIds.Count + 1; j++)
					{
						GCIJNCFDNON_SceneInfo sceneInfo = null;
						if (j == 0)
						{
							sceneInfo = AFBMEMCHJCL_MainScene;
						}
						else if (j == 1)
						{
							sceneInfo = HAPFNHPFBGD_SubScene1;
						}
						else if (j == 2)
						{
							sceneInfo = JEBHFJEJAKJ_SubScene2;
						}
						if (sceneInfo != null)
						{
							if (FJHLLHFGICG_SceneMatchTarget(sceneInfo, (CenterSkillTarget.Type)effectInfo.GJLFANGDGCL_CenterSkillTarget, ABBDKBOIBCG_DivaIdx, j))
							{
								StatusData st = null;
								if (j == 0)
								{
									st = HBODCMLFDOB.BJABFKMIJHB_StatusMainScene;
									if (GJLFANGDGCL_SkillType == JNKEEAOKNCI_Skill.MKGJHBAKMBD_SkillType.KBHGPMNGALJ_CostumeSkill)
										st = HBODCMLFDOB.AJINBLGCBMM_StatusCostumeMainScene;
									KDOFDLIMHJG_ApplySkill(ref st, sceneInfo.CMCKNKKCNDK_Status, GJLFANGDGCL_SkillType, skillId, CHMOEPNAJOO_SkillInfo.CNLIAMIIJID_Level, MLAFAACKKBG_TeamInfo);
								}
								else
								{
									st = HBODCMLFDOB.OBCPFDNKLMM_StatusSubScenes[j - 1];
									if (GJLFANGDGCL_SkillType == JNKEEAOKNCI_Skill.MKGJHBAKMBD_SkillType.KBHGPMNGALJ_CostumeSkill)
										st = HBODCMLFDOB.FEGNMIGJMDM_CostumeSubScene[j - 1];
									KDOFDLIMHJG_ApplySkill(ref st, sceneInfo.CMCKNKKCNDK_Status, GJLFANGDGCL_SkillType, skillId, CHMOEPNAJOO_SkillInfo.CNLIAMIIJID_Level, MLAFAACKKBG_TeamInfo);
								}
								if (GJLFANGDGCL_SkillType != JNKEEAOKNCI_Skill.MKGJHBAKMBD_SkillType.KBHGPMNGALJ_CostumeSkill)
								{
									LBBNJAGGCBB_SetBonusFlag(ref HBODCMLFDOB, st);
									if (GJLFANGDGCL_SkillType == JNKEEAOKNCI_Skill.MKGJHBAKMBD_SkillType.AIFGINAKBMA_EnemySkill)
									{
										FLOHCPIIHEH_WorkStatus.Clear();
										KDOFDLIMHJG_ApplySkill(ref FLOHCPIIHEH_WorkStatus, DGCJCAHIAPP_DivaInfo.JLJGCBOHJID_Status, JNKEEAOKNCI_Skill.MKGJHBAKMBD_SkillType.AIFGINAKBMA_EnemySkill, skillId, CHMOEPNAJOO_SkillInfo.CNLIAMIIJID_Level, MLAFAACKKBG_TeamInfo);
										MEICPKJFJOA_SetMalusFlag(ref HBODCMLFDOB, FLOHCPIIHEH_WorkStatus);
									}
								}
							}
						}
					}
				}
			}
		}
	}

	// // RVA: 0x1087F6C Offset: 0x1087F6C VA: 0x1087F6C
	// private static void DALDDNMEMJE(ref EDMIONMCICN HBODCMLFDOB) { }

	// // RVA: 0x10890F4 Offset: 0x10890F4 VA: 0x10890F4
	private static void LBBNJAGGCBB_SetBonusFlag(ref EDMIONMCICN HBODCMLFDOB, StatusData BALBKJFMDFN)
	{
		if (BALBKJFMDFN.soul > 0)
			HBODCMLFDOB.LGGLFAECCBK_BonusTypeFlag |= MKHCIKICBOI.BICPBLMPBPH_Soul;
		if (BALBKJFMDFN.vocal > 0)
			HBODCMLFDOB.LGGLFAECCBK_BonusTypeFlag |= MKHCIKICBOI.GPCMMGOCPHC_Vocal;
		if (BALBKJFMDFN.charm > 0)
			HBODCMLFDOB.LGGLFAECCBK_BonusTypeFlag |= MKHCIKICBOI.LGOHMPBLPKA_Charm;
		if (BALBKJFMDFN.life > 0)
			HBODCMLFDOB.LGGLFAECCBK_BonusTypeFlag |= MKHCIKICBOI.ECHJOKLBHEJ_Life;
		if (BALBKJFMDFN.support > 0)
			HBODCMLFDOB.LGGLFAECCBK_BonusTypeFlag |= MKHCIKICBOI.AHJNCHAONGN_Support;
		if (BALBKJFMDFN.fold > 0)
			HBODCMLFDOB.LGGLFAECCBK_BonusTypeFlag |= MKHCIKICBOI.ONBNGGDFAJK_Fold;
	}

	// // RVA: 0x1089190 Offset: 0x1089190 VA: 0x1089190
	private static void MEICPKJFJOA_SetMalusFlag(ref EDMIONMCICN HBODCMLFDOB, StatusData BALBKJFMDFN)
	{
		if (BALBKJFMDFN.soul < 0)
			HBODCMLFDOB.NOEFMBAIAMP_MalusTypeFlag |= MKHCIKICBOI.BICPBLMPBPH_Soul;
		if (BALBKJFMDFN.vocal < 0)
			HBODCMLFDOB.NOEFMBAIAMP_MalusTypeFlag |= MKHCIKICBOI.GPCMMGOCPHC_Vocal;
		if (BALBKJFMDFN.charm < 0)
			HBODCMLFDOB.NOEFMBAIAMP_MalusTypeFlag |= MKHCIKICBOI.LGOHMPBLPKA_Charm;
		if (BALBKJFMDFN.life < 0)
			HBODCMLFDOB.NOEFMBAIAMP_MalusTypeFlag |= MKHCIKICBOI.ECHJOKLBHEJ_Life;
		if (BALBKJFMDFN.support < 0)
			HBODCMLFDOB.NOEFMBAIAMP_MalusTypeFlag |= MKHCIKICBOI.AHJNCHAONGN_Support;
		if (BALBKJFMDFN.fold < 0)
			HBODCMLFDOB.NOEFMBAIAMP_MalusTypeFlag |= MKHCIKICBOI.ONBNGGDFAJK_Fold;
	}

	// // RVA: 0x108897C Offset: 0x108897C VA: 0x108897C
	private static KFCIIMBBNCD KDDDDMMMBHE_GetEffectInfo(JNKEEAOKNCI_Skill FOFADHAENKC_SkillDb, int BFGNMDGOEID_SkillId, JNKEEAOKNCI_Skill.MKGJHBAKMBD_SkillType GJLFANGDGCL_SkillType)
	{
		List<KFCIIMBBNCD> infoList;
		if(BFGNMDGOEID_SkillId > 0)
		{
			if (GJLFANGDGCL_SkillType == JNKEEAOKNCI_Skill.MKGJHBAKMBD_SkillType.KBHGPMNGALJ_CostumeSkill)
			{
				infoList = FOFADHAENKC_SkillDb.EBKAAEDMIBI_CostumeEffectInfo;
			}
			else if (GJLFANGDGCL_SkillType == JNKEEAOKNCI_Skill.MKGJHBAKMBD_SkillType.AIFGINAKBMA_EnemySkill)
			{
				infoList = FOFADHAENKC_SkillDb.PHPGICHCBPM_EnemyEffectInfo;
			}
			else if (GJLFANGDGCL_SkillType == JNKEEAOKNCI_Skill.MKGJHBAKMBD_SkillType.MHKFDBLMOGF_SceneSkill)
			{
				infoList = FOFADHAENKC_SkillDb.PEPLECGHBFA_SceneEffectInfo;
			}
			else return null;
			return infoList[BFGNMDGOEID_SkillId - 1];
		}
		return null;
	}

	// // RVA: 0x1088AC0 Offset: 0x1088AC0 VA: 0x1088AC0
	private static bool FNIEADNMMIA_CenterSkillCondMatchMusic(CenterSkillCondition.Type FKDOMKHHOCD_CenterSkillCondition, EEDKAACNBBG_MusicData KKHIDFKKFJE_MusicInfo, SeriesAttr.Type AIHCEGFANAM_Serie = 0)
	{
		if (FKDOMKHHOCD_CenterSkillCondition == 0)
			return true;
		if (KKHIDFKKFJE_MusicInfo == null)
			return false;
		bool res = false;
		switch(FKDOMKHHOCD_CenterSkillCondition)
		{
			case CenterSkillCondition.Type.MusicAttr_01:
				return KKHIDFKKFJE_MusicInfo.FKDCCLPGKDK_JacketAttr == 1;
			case CenterSkillCondition.Type.MusicAttr_02:
				return KKHIDFKKFJE_MusicInfo.FKDCCLPGKDK_JacketAttr == 2;
			case CenterSkillCondition.Type.MusicAttr_03:
				return KKHIDFKKFJE_MusicInfo.FKDCCLPGKDK_JacketAttr == 3;
			case CenterSkillCondition.Type.MusicAttr_04:
				return KKHIDFKKFJE_MusicInfo.FKDCCLPGKDK_JacketAttr == 4;
			case CenterSkillCondition.Type.MusicAttr_05:
				return false;
			case CenterSkillCondition.Type.SeriesAttr_01:
				return KKHIDFKKFJE_MusicInfo.AIHCEGFANAM_Serie == 1;
			case CenterSkillCondition.Type.SeriesAttr_02:
				return KKHIDFKKFJE_MusicInfo.AIHCEGFANAM_Serie == 2;
			case CenterSkillCondition.Type.SeriesAttr_03:
				return KKHIDFKKFJE_MusicInfo.AIHCEGFANAM_Serie == 3;
			case CenterSkillCondition.Type.SeriesAttr_04:
				return KKHIDFKKFJE_MusicInfo.AIHCEGFANAM_Serie == 4;
			case CenterSkillCondition.Type.SeriesAttr_05:
				return KKHIDFKKFJE_MusicInfo.AIHCEGFANAM_Serie == 5;
			case CenterSkillCondition.Type.SeriesAttr_Scn:
				return KKHIDFKKFJE_MusicInfo.AIHCEGFANAM_Serie == (int)AIHCEGFANAM_Serie;
		}
		return res;
	}

	// // RVA: 0x1088C18 Offset: 0x1088C18 VA: 0x1088C18
	private static bool FLPKCFDANMK_DivaMatchTarget(FFHPBEPOMAK_DivaInfo FDBOPFEOENF_DivaInfo, CenterSkillTarget.Type GJLFANGDGCL_SkillTargetType, int ABBDKBOIBCG_DivaIdx)
	{
		bool res = false;
		switch(GJLFANGDGCL_SkillTargetType)
		{
			case CenterSkillTarget.Type.AllTeam:
			case CenterSkillTarget.Type.AllDiva:
				return true;
			default:
				return false;
			case CenterSkillTarget.Type.CenterDiva:
				return ABBDKBOIBCG_DivaIdx == 0;
			case CenterSkillTarget.Type.SeriresAttr1:
				return FDBOPFEOENF_DivaInfo.AIHCEGFANAM_Serie == 1;
			case CenterSkillTarget.Type.SeriresAttr2:
				return FDBOPFEOENF_DivaInfo.AIHCEGFANAM_Serie == 2;
			case CenterSkillTarget.Type.SeriresAttr3:
				return FDBOPFEOENF_DivaInfo.AIHCEGFANAM_Serie == 3;
			case CenterSkillTarget.Type.SeriresAttr4:
				return FDBOPFEOENF_DivaInfo.AIHCEGFANAM_Serie == 4;
		}
		return res;
	}

	// // RVA: 0x108922C Offset: 0x108922C VA: 0x108922C
	private static bool FJHLLHFGICG_SceneMatchTarget(GCIJNCFDNON_SceneInfo COIODGJDJEJ_SceneInfo, CenterSkillTarget.Type GJLFANGDGCL_SkillTargetType, int ABBDKBOIBCG_DivaIdx, int HBMFKPPOPMK_SceneIdx)
	{
		bool res = false;
		switch(GJLFANGDGCL_SkillTargetType)
		{
			case CenterSkillTarget.Type.AllTeam:
			case CenterSkillTarget.Type.AllScene:
				return true;
			default:
				return false;
			case CenterSkillTarget.Type.MainSlotScene:
				return HBMFKPPOPMK_SceneIdx == 0;
			case CenterSkillTarget.Type.CenterDiva:
				return ABBDKBOIBCG_DivaIdx == 0;
			case CenterSkillTarget.Type.GameAttrYellow:
				return COIODGJDJEJ_SceneInfo.JGJFIJOCPAG_SceneAttr == 1;
			case CenterSkillTarget.Type.GameAttrRed:
				return COIODGJDJEJ_SceneInfo.JGJFIJOCPAG_SceneAttr == 2;
			case CenterSkillTarget.Type.GameAttrBlue:
				return COIODGJDJEJ_SceneInfo.JGJFIJOCPAG_SceneAttr == 3;
			case CenterSkillTarget.Type.SeriresAttr1:
				return (int)COIODGJDJEJ_SceneInfo.AIHCEGFANAM_SceneSeries == 1;
			case CenterSkillTarget.Type.SeriresAttr2:
				return (int)COIODGJDJEJ_SceneInfo.AIHCEGFANAM_SceneSeries == 2;
			case CenterSkillTarget.Type.SeriresAttr3:
				return (int)COIODGJDJEJ_SceneInfo.AIHCEGFANAM_SceneSeries == 3;
			case CenterSkillTarget.Type.SeriresAttr4:
				return (int)COIODGJDJEJ_SceneInfo.AIHCEGFANAM_SceneSeries == 4;
		}
		return res;
	}

	// // RVA: 0x1088D0C Offset: 0x1088D0C VA: 0x1088D0C
	private static void KDOFDLIMHJG_ApplySkill(ref StatusData BALBKJFMDFN_StatusRes, StatusData JLJGCBOHJID_BaseStatus, JNKEEAOKNCI_Skill.MKGJHBAKMBD_SkillType GJLFANGDGCL_SkillType, int PGLJHBODOHN_SkillId, int CIEOBFIIPLD_Level, JLKEOGLJNOD_TeamInfo MLAFAACKKBG_TeamInfo)
	{
		List<KFCIIMBBNCD> skillsInfoList = null;
		if(GJLFANGDGCL_SkillType == JNKEEAOKNCI_Skill.MKGJHBAKMBD_SkillType.KBHGPMNGALJ_CostumeSkill)
		{
			skillsInfoList = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.FOFADHAENKC_Skill.EBKAAEDMIBI_CostumeEffectInfo;
		}
		else if (GJLFANGDGCL_SkillType == JNKEEAOKNCI_Skill.MKGJHBAKMBD_SkillType.AIFGINAKBMA_EnemySkill)
		{
			skillsInfoList = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.FOFADHAENKC_Skill.PHPGICHCBPM_EnemyEffectInfo;
		}
		else if (GJLFANGDGCL_SkillType == JNKEEAOKNCI_Skill.MKGJHBAKMBD_SkillType.MHKFDBLMOGF_SceneSkill)
		{
			skillsInfoList = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.FOFADHAENKC_Skill.PEPLECGHBFA_SceneEffectInfo;
		}
		KFCIIMBBNCD sk = skillsInfoList[PGLJHBODOHN_SkillId - 1];
		if(sk != null)
		{
			float modifierValue = sk.KCOHMHFBDKF_ValueByLevel[CIEOBFIIPLD_Level - 1];
			if (sk.BBFKKANELFP_EffectType == 1)
			{
				FOKHDKJJOFB_EffectByNumDiva fo = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.FOFADHAENKC_Skill.EFJFIIPIMOO_GetEffectValue(sk.KCOHMHFBDKF_ValueByLevel[CIEOBFIIPLD_Level - 1]);
				modifierValue = fo.NANNGLGOFKH_Value[CIEOBFIIPLD_Level - 1] * FPJIKEFIJOL_GetNumValidSceneForDivas(fo.FDBOPFEOENF_DivaFlag, MLAFAACKKBG_TeamInfo) + fo.NNDBJGDFEEM_Min;
			}
			CHJHPJHNCEB_ApplyModifiers(ref BALBKJFMDFN_StatusRes, JLJGCBOHJID_BaseStatus, sk.INDDJNMPONH_ModifierType, modifierValue);
		}
	}

	// // RVA: 0x10896DC Offset: 0x10896DC VA: 0x10896DC
	private static void CHJHPJHNCEB_ApplyModifiers(ref StatusData BALBKJFMDFN_StatusRes, StatusData JLJGCBOHJID_BaseStatus, byte INDDJNMPONH_EffectType, float NANNGLGOFKH_Value)
	{
		switch(INDDJNMPONH_EffectType)
		{
			case 1:
				BALBKJFMDFN_StatusRes.life += (int)(JLJGCBOHJID_BaseStatus.life * NANNGLGOFKH_Value);
				BALBKJFMDFN_StatusRes.soul += (int)(JLJGCBOHJID_BaseStatus.soul * NANNGLGOFKH_Value);
				BALBKJFMDFN_StatusRes.vocal += (int)(JLJGCBOHJID_BaseStatus.vocal * NANNGLGOFKH_Value);
				BALBKJFMDFN_StatusRes.charm += (int)(JLJGCBOHJID_BaseStatus.charm * NANNGLGOFKH_Value);
				BALBKJFMDFN_StatusRes.support += (int)(JLJGCBOHJID_BaseStatus.support * NANNGLGOFKH_Value);
				BALBKJFMDFN_StatusRes.fold += (int)(JLJGCBOHJID_BaseStatus.fold * NANNGLGOFKH_Value);
				break;
			case 2:
				BALBKJFMDFN_StatusRes.life += (int)(JLJGCBOHJID_BaseStatus.life * NANNGLGOFKH_Value);
				break;
			case 3:
				BALBKJFMDFN_StatusRes.soul += (int)(JLJGCBOHJID_BaseStatus.soul * NANNGLGOFKH_Value);
				BALBKJFMDFN_StatusRes.vocal += (int)(JLJGCBOHJID_BaseStatus.vocal * NANNGLGOFKH_Value);
				BALBKJFMDFN_StatusRes.charm += (int)(JLJGCBOHJID_BaseStatus.charm * NANNGLGOFKH_Value);
				break;
			case 4:
				BALBKJFMDFN_StatusRes.soul += (int)(JLJGCBOHJID_BaseStatus.soul * NANNGLGOFKH_Value);
				break;
			case 5:
				BALBKJFMDFN_StatusRes.vocal += (int)(JLJGCBOHJID_BaseStatus.vocal * NANNGLGOFKH_Value);
				break;
			case 6:
				BALBKJFMDFN_StatusRes.charm += (int)(JLJGCBOHJID_BaseStatus.charm * NANNGLGOFKH_Value);
				break;
			case 7:
				BALBKJFMDFN_StatusRes.soul -= (int)(JLJGCBOHJID_BaseStatus.soul * NANNGLGOFKH_Value);
				break;
			case 8:
				BALBKJFMDFN_StatusRes.vocal -= (int)(JLJGCBOHJID_BaseStatus.vocal * NANNGLGOFKH_Value);
				break;
			case 9:
				BALBKJFMDFN_StatusRes.charm -= (int)(JLJGCBOHJID_BaseStatus.charm * NANNGLGOFKH_Value);
				break;
			case 10:
				BALBKJFMDFN_StatusRes.soul -= (int)(JLJGCBOHJID_BaseStatus.soul * NANNGLGOFKH_Value);
				BALBKJFMDFN_StatusRes.vocal -= (int)(JLJGCBOHJID_BaseStatus.vocal * NANNGLGOFKH_Value);
				break;
			case 11:
				BALBKJFMDFN_StatusRes.soul -= (int)(JLJGCBOHJID_BaseStatus.soul * NANNGLGOFKH_Value);
				BALBKJFMDFN_StatusRes.charm -= (int)(JLJGCBOHJID_BaseStatus.charm * NANNGLGOFKH_Value);
				break;
			case 12:
				BALBKJFMDFN_StatusRes.vocal -= (int)(JLJGCBOHJID_BaseStatus.vocal * NANNGLGOFKH_Value);
				BALBKJFMDFN_StatusRes.charm -= (int)(JLJGCBOHJID_BaseStatus.charm * NANNGLGOFKH_Value);
				break;
			case 13:
				BALBKJFMDFN_StatusRes.fold -= (int)(JLJGCBOHJID_BaseStatus.fold * NANNGLGOFKH_Value);
				break;
			case 14:
				BALBKJFMDFN_StatusRes.support += (int)(JLJGCBOHJID_BaseStatus.support * NANNGLGOFKH_Value);
				break;
			case 15:
				BALBKJFMDFN_StatusRes.fold += (int)(JLJGCBOHJID_BaseStatus.fold * NANNGLGOFKH_Value);
				break;
		}
	}

	// // RVA: 0x1087F4C Offset: 0x1087F4C VA: 0x1087F4C
	public static bool OJNOJNEKBKH(int LNGOBGPDBAG, int GMPOGAFIAEF)
    {
        return GMPOGAFIAEF == 4 || GMPOGAFIAEF == LNGOBGPDBAG;
    }

	// // RVA: 0x10868E8 Offset: 0x10868E8 VA: 0x10868E8
	private static void NJNBELLEGCN(ref CFHDKAFLNEP HBODCMLFDOB, JLKEOGLJNOD_TeamInfo MLAFAACKKBG, DFKGGBMFFGB_PlayerInfo AHEFHIMGIBI, EEDKAACNBBG_MusicData KKHIDFKKFJE, EAJCBFGKKFA_FriendInfo PCEGKKLKFNO, EJKBKMBJMGL_EnemyData KDOLMBEAGCI)
	{
		HBODCMLFDOB.JCHLONCMPAJ();
		int[,] data = CIOECGOMILE.HHCJCDFCLOB.AHEFHIMGIBI_ServerSave.BEKHNNCGIEL_Costume.GODGHFDMAHF_GetRateBySupportPlate();
		if(data != null)
		{
			List<List<GCIJNCFDNON_SceneInfo>> ll = new List<List<GCIJNCFDNON_SceneInfo>>();
			for(int i = 0; i < LCLCCHLDNHJ_Costume.GFIKOEEBIJP; i++)
			{
				ll.Add(new List<GCIJNCFDNON_SceneInfo>(AHEFHIMGIBI.OPIBAPEGCLA_Scenes.Count));
			}
			bool b = false;
			for(int i = 0; i < AHEFHIMGIBI.OPIBAPEGCLA_Scenes.Count; i++)
			{
				GCIJNCFDNON_SceneInfo sceneInfo = AHEFHIMGIBI.OPIBAPEGCLA_Scenes[i];
				int enabled = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.ECNHDEHADGL_Scene.CDENCMNHNGA_SceneList[sceneInfo.BCCHOBPJJKE_SceneId - 1].PPEGAKEIEGM_En;
				if(enabled == 2)
				{
					if(sceneInfo.CGKAEMGLHNK_IsUnlocked(true) && !sceneInfo.MCCIFLKCNKO_Feed)
					{
						bool isSub = false;
						for(int j = 0; j < MLAFAACKKBG.BCJEAJPLGMB_MainDivas.Count; j++)
						{
							FFHPBEPOMAK_DivaInfo divaInfo = MLAFAACKKBG.BCJEAJPLGMB_MainDivas[j];
							if(divaInfo != null)
							{
								if(i == divaInfo.FGFIBOBAPIA_SceneId - 1)
								{
									break;
								}
								for(int k = 0; k < divaInfo.DJICAKGOGFO_SubSceneIds.Count; k++)
								{
									if(divaInfo.DJICAKGOGFO_SubSceneIds[k] - 1 == i)
									{
										isSub = true;
										break;
									}
								}
							}
						}
						if(!isSub)
						{
							ll[sceneInfo.JGJFIJOCPAG_SceneAttr - 1].Add(sceneInfo);
							b = true;
						}
					}
				}
			}
			if(b)
			{
				NJNBELLEGCN(ref HBODCMLFDOB, data, ll, AHEFHIMGIBI, MLAFAACKKBG, KKHIDFKKFJE, PCEGKKLKFNO, KDOLMBEAGCI);
			}
			else
			{
				for(int i = 0; i < data.GetLength(0); i++)
				{
					for(int j = 0; j < data.GetLength(1); j++)
					{
						HBODCMLFDOB.KOGBMDOONFA[i, j].ADKDHKMPMHP_Rate = data[i, j];
					}					
				}
			}
		}
	}

	// // RVA: 0x1089E00 Offset: 0x1089E00 VA: 0x1089E00
	public static void NJNBELLEGCN(ref CFHDKAFLNEP HBODCMLFDOB, int[,] EDAJDLJHBKP, List<List<GCIJNCFDNON_SceneInfo>> OPIBAPEGCLA, DFKGGBMFFGB_PlayerInfo AHEFHIMGIBI, JLKEOGLJNOD_TeamInfo MLAFAACKKBG, EEDKAACNBBG_MusicData KKHIDFKKFJE, EAJCBFGKKFA_FriendInfo PCEGKKLKFNO, EJKBKMBJMGL_EnemyData KDOLMBEAGCI)
	{
		GCIJNCFDNON_SceneInfo sceneInfo = null;
		if(MLAFAACKKBG != null)
		{
			FFHPBEPOMAK_DivaInfo divaInfo = MLAFAACKKBG.BCJEAJPLGMB_MainDivas[0];
			if(divaInfo != null)
			{
				if(divaInfo.FGFIBOBAPIA_SceneId != 0)
				{
					sceneInfo = AHEFHIMGIBI.OPIBAPEGCLA_Scenes[divaInfo.FGFIBOBAPIA_SceneId - 1];
					if(KKHIDFKKFJE == null)
					{
						if(sceneInfo.MEOOLHNNMHL_GetCenterSkillId(false, 0, 0) == 0)
							sceneInfo = null;
					}
					else
					{
						if(sceneInfo.MEOOLHNNMHL_GetCenterSkillId(false, KKHIDFKKFJE.FKDCCLPGKDK_JacketAttr, KKHIDFKKFJE.AIHCEGFANAM_Serie) == 0)
							sceneInfo = null;
					}
				}
			}
		}
		GCIJNCFDNON_SceneInfo sceneInfo2 = null;
		if(PCEGKKLKFNO != null)
		{
			sceneInfo2 = PCEGKKLKFNO.KHGKPKDBMOH_GetAssistScene();
			if(sceneInfo2 != null)
			{
				if(KKHIDFKKFJE == null)
				{
					if(sceneInfo2.MEOOLHNNMHL_GetCenterSkillId(false, 0, 0) == 0)
						sceneInfo2 = null;
				}
				else
				{
					if(sceneInfo2.MEOOLHNNMHL_GetCenterSkillId(false, KKHIDFKKFJE.FKDCCLPGKDK_JacketAttr, KKHIDFKKFJE.AIHCEGFANAM_Serie) == 0)
						sceneInfo2 = null;
				}
			}
		}
		CFHDKAFLNEP.OCNHGDCPJDG[,] data = new CFHDKAFLNEP.OCNHGDCPJDG[3, 3];
		StatusData st = new StatusData();
		StatusData st2 = new StatusData();
		for(int i = 0; i < LCLCCHLDNHJ_Costume.GFIKOEEBIJP; i++)
		{
			if(OPIBAPEGCLA[i].Count < 1)
			{
				for(int j = 0; j < EDAJDLJHBKP.GetLength(1); j++)
				{
					HBODCMLFDOB.KOGBMDOONFA[i, j].ADKDHKMPMHP_Rate = EDAJDLJHBKP[i, j];
				}
			}
			else
			{
				bool attrMatch = false;
				if(KKHIDFKKFJE != null)
				{
					attrMatch = (KKHIDFKKFJE.FKDCCLPGKDK_JacketAttr == 4 || KKHIDFKKFJE.FKDCCLPGKDK_JacketAttr == i + 1);
				}
				for(int j = 0; j < 3; j++)
				{
					OPIBAPEGCLA[i].Sort(MOGECDOLPPL[j]);
					int val = Mathf.Min(3, OPIBAPEGCLA[i].Count);
					int val2 = EDAJDLJHBKP[i, j];
					if(val  < 1)
					{
						val = 0;
						val--;
						for(int k = val + 1; k < 3; k++)
						{
							data[j, k].PBPOLELIPJI_Id = 0;
							data[j, k].IFFKEMEOFAE_EvolveId = 0;
							data[j, k].ADKDHKMPMHP_Rate = val2;
							data[j, k].OEOIHIIIMCK_Add = 0;
							data[j, k].ALJGIPAGDJI = 0;
							data[j, k].HIPODBKKJFL = 0;
							data[j, k].KHDDPKHPJID = 0;
							data[j, k].LHFPLDHBAAN = false;
							data[j, k].KPNDMALAOKC = false;
							data[j, k].OGHIOHAACIB_IsKira = false;
						}
					}
					else
					{
						int k = 0;
						for(; k < val; k++)
						{
							GCIJNCFDNON_SceneInfo sceneInfo3 = OPIBAPEGCLA[i][k];
							data[j, k].PBPOLELIPJI_Id = sceneInfo3.BCCHOBPJJKE_SceneId;
							data[j, k].IFFKEMEOFAE_EvolveId = sceneInfo3.CGIELKDLHGE_GetEvolveId();
							data[j, k].ADKDHKMPMHP_Rate = val2;
							data[j, k].OGHIOHAACIB_IsKira = sceneInfo3.MBMFJILMOBP_IsKira();
							st.Copy(sceneInfo3.CMCKNKKCNDK_Status);
							bool c = attrMatch;
							int e = 0;
							if(sceneInfo != null)
							{
								int a = sceneInfo.MEOOLHNNMHL_GetCenterSkillId(false, KKHIDFKKFJE != null ? KKHIDFKKFJE.FKDCCLPGKDK_JacketAttr : 0, KKHIDFKKFJE != null ? KKHIDFKKFJE.AIHCEGFANAM_Serie : 0);
								st2.Clear();
								MHPBLAEDJOC(ref st2, sceneInfo3, KKHIDFKKFJE, a, sceneInfo.DDEDANKHHPN_SkillLevel, MLAFAACKKBG);
								e = HDLKMMHKOKE[j].Invoke(st2);
								c |= e > 0;
							}
							if(sceneInfo2 != null)
							{
								int a = sceneInfo2.MEOOLHNNMHL_GetCenterSkillId(false, KKHIDFKKFJE != null ? KKHIDFKKFJE.FKDCCLPGKDK_JacketAttr : 0, KKHIDFKKFJE != null ? KKHIDFKKFJE.AIHCEGFANAM_Serie : 0);
								st2.Clear();
								MHPBLAEDJOC(ref st2, sceneInfo3, KKHIDFKKFJE, a, sceneInfo2.DDEDANKHHPN_SkillLevel, MLAFAACKKBG);
								int d = HDLKMMHKOKE[j].Invoke(st2);
								e += d;
								c |= d > 0;
							}
							bool g = false;
							if(KDOLMBEAGCI != null && KDOLMBEAGCI.PDHCABLLJPB_CenterSkillId != 0)
							{
								HBDCPGLAPHH h = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.FOFADHAENKC_Skill.FFCFHFOIKGB_CenterSkillEnemy[KDOLMBEAGCI.PDHCABLLJPB_CenterSkillId - 1];
								int aa = 0;
								for(int l = 0; l < 2; l++)
								{
									if(l == 1)
									{
										if(h.AKGNPLBDKLN_P2 != 0)
											aa = h.AKGNPLBDKLN_P2;
									}
									else if(l == 0)
									{
										if(h.HEKHODDJHAO_P1 != 0)
											aa = h.HEKHODDJHAO_P1;
									}
									st2.Clear();
									KDOFDLIMHJG_ApplySkill(ref st2, sceneInfo3.CMCKNKKCNDK_Status, JNKEEAOKNCI_Skill.MKGJHBAKMBD_SkillType.AIFGINAKBMA_EnemySkill, aa, 1, MLAFAACKKBG);
									int d = HDLKMMHKOKE[j].Invoke(st2);
									e += d;
									c |= d > 0;
									TodoLogger.LogError(TodoLogger.ToCheck, "Check val");
									g |= d < 0; // ??
								}
							}
							int d_ = HDLKMMHKOKE[j].Invoke(sceneInfo3.CMCKNKKCNDK_Status);
							int bb = attrMatch ? 1 : 0;
							if(attrMatch)
								bb = d_ * 30;
							data[j, k].OEOIHIIIMCK_Add = (((bb + e) / 100 + d_) * val2) / 100;
							data[j, k].KHDDPKHPJID = (d_ * val2) / 100;
							data[j, k].ALJGIPAGDJI = (attrMatch ? ((bb / 100) * val2) / 100 : 0);
							bool cc = false;
							if(c)
							{
								if(data[j, k].OEOIHIIIMCK_Add > 0)
									cc = true;
							}
							data[j, k].LHFPLDHBAAN = cc;
							data[j, k].HIPODBKKJFL = e < 1 ? 0 : ((e / 100) * val2) / 100;
							data[j, k].KPNDMALAOKC = g;
							
						}
						for(; k < 3; k++)
						{
							data[j, k].PBPOLELIPJI_Id = 0;
							data[j, k].IFFKEMEOFAE_EvolveId = 0;
							data[j, k].ADKDHKMPMHP_Rate = val2;
							data[j, k].OEOIHIIIMCK_Add = 0;
							data[j, k].ALJGIPAGDJI = 0;
							data[j, k].HIPODBKKJFL = 0;
							data[j, k].KHDDPKHPJID = 0;
							data[j, k].LHFPLDHBAAN = false;
							data[j, k].KPNDMALAOKC = false;
							data[j, k].OGHIOHAACIB_IsKira = false;
						}
					}
				}
				int maxAdd = 0;
				for(int j = 0; j < 3; j++)
				{
					int id_j = data[0, j].PBPOLELIPJI_Id;
					for(int k = 0; k < 3; k++)
					{
						int id_k = data[1, k].PBPOLELIPJI_Id;
						for(int l = 0; l < 3; l++)
						{
							int id_l = data[2, l].PBPOLELIPJI_Id;

							if((id_l == 0 || id_l != id_j) && 
								(id_j == 0 || id_j != id_k) && 
								(id_k == 0 || id_k != id_l))
							{
								int v = data[0, j].OEOIHIIIMCK_Add + data[1, j].OEOIHIIIMCK_Add + data[2, j].OEOIHIIIMCK_Add;
								if(maxAdd < v)
								{
									HBODCMLFDOB.KOGBMDOONFA[i, 0] = data[0, j];
									HBODCMLFDOB.KOGBMDOONFA[i, 1] = data[1, k];
									HBODCMLFDOB.KOGBMDOONFA[i, 2] = data[2, l];
									maxAdd = v;
								}
							}
						}
					}
				}
				for(int j = 0; j < 3; j++)
				{
					HOBOLJEFDFF[j].Invoke(HBODCMLFDOB.CMCKNKKCNDK, HBODCMLFDOB.KOGBMDOONFA[i, j].OEOIHIIIMCK_Add);
				}
			}
		}
	}

	// // RVA: 0x108BAF0 Offset: 0x108BAF0 VA: 0x108BAF0
	private static void MHPBLAEDJOC(ref StatusData BALBKJFMDFN, GCIJNCFDNON_SceneInfo COIODGJDJEJ, EEDKAACNBBG_MusicData KKHIDFKKFJE, int ENMAEBJGEKL, int CNLIAMIIJID, JLKEOGLJNOD_TeamInfo MLAFAACKKBG)
	{
		HBDCPGLAPHH skill = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.FOFADHAENKC_Skill.COLCPGFABLP_CenterSkills[ENMAEBJGEKL - 1];
		for(int i = 0; i < 2; i++)
		{
			int skillId = 0;
			KFCIIMBBNCD a = null;
			if (i == 1)
			{
				if (skill.AKGNPLBDKLN_P2 == 0)
					return;
				a = KDDDDMMMBHE_GetEffectInfo(IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.FOFADHAENKC_Skill, skill.AKGNPLBDKLN_P2, JNKEEAOKNCI_Skill.MKGJHBAKMBD_SkillType.MHKFDBLMOGF_SceneSkill);
				skillId = skill.AKGNPLBDKLN_P2;
			}
			else if(i == 0)
			{
				if(skill.HEKHODDJHAO_P1 != 0)
				{
					a = KDDDDMMMBHE_GetEffectInfo(IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.FOFADHAENKC_Skill, skill.HEKHODDJHAO_P1, JNKEEAOKNCI_Skill.MKGJHBAKMBD_SkillType.MHKFDBLMOGF_SceneSkill);
					skillId = skill.HEKHODDJHAO_P1;
				}
			}
			if(a != null)
			{
				if(FNIEADNMMIA_CenterSkillCondMatchMusic((CenterSkillCondition.Type)a.OAFPGJLCNFM_CenterSkillCondition, KKHIDFKKFJE, COIODGJDJEJ.AIHCEGFANAM_SceneSeries))
				{
					if(FJHLLHFGICG_SceneMatchTarget(COIODGJDJEJ, (CenterSkillTarget.Type)a.GJLFANGDGCL_CenterSkillTarget, -1, -1))
					{
						KDOFDLIMHJG_ApplySkill(ref BALBKJFMDFN, COIODGJDJEJ.CMCKNKKCNDK_Status, JNKEEAOKNCI_Skill.MKGJHBAKMBD_SkillType.MHKFDBLMOGF_SceneSkill, skillId, CNLIAMIIJID, MLAFAACKKBG);
					}
				}
			}
		}
	}

	// // RVA: 0x1089374 Offset: 0x1089374 VA: 0x1089374
	public static int FPJIKEFIJOL_GetNumValidSceneForDivas(int NCNFMHDKAPN_DivaFlag, JLKEOGLJNOD_TeamInfo CDCKLJAJBDO_TeamInfo)
	{
		int total = 0;
		for(int i = 0; i < CDCKLJAJBDO_TeamInfo.BCJEAJPLGMB_MainDivas.Count; i++)
		{
			FFHPBEPOMAK_DivaInfo infoDiva = CDCKLJAJBDO_TeamInfo.BCJEAJPLGMB_MainDivas[i];
			if(infoDiva != null)
			{
				if(infoDiva.FGFIBOBAPIA_SceneId > 0)
				{
					if((IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.ECNHDEHADGL_Scene.CDENCMNHNGA_SceneList[infoDiva.FGFIBOBAPIA_SceneId - 1].AOLIJKMIJJE_Dv & NCNFMHDKAPN_DivaFlag) != 0)
						total++;
				}
				for(int j = 0; j < infoDiva.DJICAKGOGFO_SubSceneIds.Count; i++)
				{
					if(infoDiva.DJICAKGOGFO_SubSceneIds[j] > 0)
					{
						if((IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.ECNHDEHADGL_Scene.CDENCMNHNGA_SceneList[infoDiva.DJICAKGOGFO_SubSceneIds[j] - 1].AOLIJKMIJJE_Dv & NCNFMHDKAPN_DivaFlag) != 0)
							total++;
					}
				}
			}
		}
		return total;
	}

	// // RVA: 0x108C0FC Offset: 0x108C0FC VA: 0x108C0FC
	public static int NDNOLJACLLC_GetScore(NOJENDEDECD_ScoreType HLANCDFJFIA)
	{
		return OOPMCKOCEFM_Scores[(int)HLANCDFJFIA];
	}

	// // RVA: 0x108C1C0 Offset: 0x108C1C0 VA: 0x108C1C0
	public static int EPNPGMCGJKB(Difficulty.Type AKNELONELJK_Difficulty, bool NGKGFBLFEGH_IsLine6)
	{
		if(NGKGFBLFEGH_IsLine6)
		{
			return DNJCAKPKNDP_ScoreRatioByDifficulty[(int)AKNELONELJK_Difficulty + 3];
		}
		else
		{
			return DNJCAKPKNDP_ScoreRatioByDifficulty[(int)AKNELONELJK_Difficulty];
		}
	}

	// // RVA: 0x108C2EC Offset: 0x108C2EC VA: 0x108C2EC
	public static float GPCKPNJGANO_GetRank(ResultScoreRank.Type FJOLNJLLJEJ)
	{
		return LKBGHCIKIOA_RankScore[(int)FJOLNJLLJEJ];
	}

	// // RVA: 0x108C3B0 Offset: 0x108C3B0 VA: 0x108C3B0
	public static void EFCNOOFFMIL(DFKGGBMFFGB_PlayerInfo DJLNOAMJECI_PlayerData, EAJCBFGKKFA_FriendInfo ALOBLKOHIKD_FriendData, EEDKAACNBBG_MusicData GMFMMDAKENC_MusicData, EJKBKMBJMGL_EnemyData BGJGFPPDNEP_EnemyData, Difficulty.Type AKNELONELJK_Difficulty, bool PDLCNDBOMAN_IsLine6, bool CMEOKJMCEBH_IsGoDivaEvent)
	{
		EFCNOOFFMIL(DJLNOAMJECI_PlayerData, DJLNOAMJECI_PlayerData.DPLBHAIKPGL_GetTeam(CMEOKJMCEBH_IsGoDivaEvent), ALOBLKOHIKD_FriendData, GMFMMDAKENC_MusicData, BGJGFPPDNEP_EnemyData, AKNELONELJK_Difficulty, PDLCNDBOMAN_IsLine6);
	}

	// // RVA: 0x108C488 Offset: 0x108C488 VA: 0x108C488
	public static void EFCNOOFFMIL(DFKGGBMFFGB_PlayerInfo DJLNOAMJECI_Playerdata, JLKEOGLJNOD_TeamInfo HJJNDDPGIML_Team, EAJCBFGKKFA_FriendInfo ALOBLKOHIKD_FriendData, EEDKAACNBBG_MusicData GMFMMDAKENC_MusicData, EJKBKMBJMGL_EnemyData BGJGFPPDNEP_EnemyData, Difficulty.Type AKNELONELJK_Difficulty, bool PDLCNDBOMAN_IsLine6)
	{
		for (int i = 0; i < OOPMCKOCEFM_Scores.Length; i++)
		{
			OOPMCKOCEFM_Scores[i] = 0;
		}
		CFHDKAFLNEP calcData = new CFHDKAFLNEP();
		ADDHLABEFKH resultTarget = null;
		if (GMFMMDAKENC_MusicData is IBJAKJJICBC)
		{
			resultTarget = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.IBPAFKKEKNK_Music.GEAANLPDJBP_FreeMusicDatas[(GMFMMDAKENC_MusicData as IBJAKJJICBC).GHBPLHBNMBK_FreeMusicId].EMJCHPDJHEI(PDLCNDBOMAN_IsLine6, (int)AKNELONELJK_Difficulty);
		}
		else if (GMFMMDAKENC_MusicData is LIEJFHMGNIA)
		{
			resultTarget = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.IBPAFKKEKNK_Music.FLMLJIKBIMJ_GetStoryMusicData((GMFMMDAKENC_MusicData as LIEJFHMGNIA).KLCIIHKFPPO_StoryMusicId).COGKJBAFBKN_ByDiff[(int)AKNELONELJK_Difficulty];
		}
		int musicId = GMFMMDAKENC_MusicData.DLAEJOBELBH_MusicId;
		EONOEHOKBEB_Music musicInfo = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.IBPAFKKEKNK_Music.IAJLOELFHKC_GetMusicInfo(musicId);
		KLBKPANJCPL_Score score = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.IBPAFKKEKNK_Music.ALJFMLEJEHH_GetMusicScore(musicInfo.KKPAHLMJKIH_WavId, musicInfo.BKJGCEOEPFB_VariationId, (int)AKNELONELJK_Difficulty, PDLCNDBOMAN_IsLine6, true);
		int progress = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.HNMMJINNHII_Game.ADBELGIDIEN_GetProgress(score.ANAJIAENLNB_MusicLevel, PDLCNDBOMAN_IsLine6);
		int baseScore = CBILJEAECKP_GetBaseScore(DJLNOAMJECI_Playerdata, ALOBLKOHIKD_FriendData, BGJGFPPDNEP_EnemyData, GMFMMDAKENC_MusicData, AKNELONELJK_Difficulty, PDLCNDBOMAN_IsLine6, score.ANAJIAENLNB_MusicLevel, progress, HJJNDDPGIML_Team);
		//gauge_01_base
		OOPMCKOCEFM_Scores[(int)NOJENDEDECD_ScoreType.HNGJDMNPMNP_BaseScore] = baseScore;
		//gauge_05_shien / plate
		OOPMCKOCEFM_Scores[(int)NOJENDEDECD_ScoreType.GJDKJOHIEFF_PlateScore] = MHIKPDIJKJO(DJLNOAMJECI_Playerdata, ALOBLKOHIKD_FriendData, GMFMMDAKENC_MusicData, BGJGFPPDNEP_EnemyData, ref calcData, progress, HJJNDDPGIML_Team);
		//gauge_02_isyou
		OOPMCKOCEFM_Scores[(int)NOJENDEDECD_ScoreType.KBHGPMNGALJ] = CHCGGEPAAOE(DJLNOAMJECI_Playerdata, GMFMMDAKENC_MusicData, ALOBLKOHIKD_FriendData, BGJGFPPDNEP_EnemyData, progress, HJJNDDPGIML_Team);
		//gauge_03_zokusei / ?? bonus
		OOPMCKOCEFM_Scores[(int)NOJENDEDECD_ScoreType.AJIDOFDBIDL] = DONJDICAMJB(DJLNOAMJECI_Playerdata, ALOBLKOHIKD_FriendData, GMFMMDAKENC_MusicData, BGJGFPPDNEP_EnemyData, ref calcData, progress, HJJNDDPGIML_Team);
		EDMIONMCICN d = new EDMIONMCICN();
		//gauge_04_cskill
		OOPMCKOCEFM_Scores[(int)NOJENDEDECD_ScoreType.BMMPEPDFICC_CenterSkillScore] = DBHEBCCLIJG(ref d, DJLNOAMJECI_Playerdata, ALOBLKOHIKD_FriendData, GMFMMDAKENC_MusicData, null, ref calcData, progress, false, HJJNDDPGIML_Team);
		bool e = false;
		bool g = false;
		bool f = MODGPFEPLIP(ref d, DJLNOAMJECI_Playerdata, ALOBLKOHIKD_FriendData, GMFMMDAKENC_MusicData, score, AKNELONELJK_Difficulty, PDLCNDBOMAN_IsLine6, out e, out g, HJJNDDPGIML_Team);
		//gauge_06_lskill
		OOPMCKOCEFM_Scores[(int)NOJENDEDECD_ScoreType.CPJOGHCLENG_LiveSkillScore] = LKGBAIANMLE(baseScore, DJLNOAMJECI_Playerdata, GMFMMDAKENC_MusicData, score, e, f, g, HJJNDDPGIML_Team);
		//gauge_07_askill
		OOPMCKOCEFM_Scores[(int)NOJENDEDECD_ScoreType.NKPLJNILBFP_ASkillScore] = BPPIFIAGLBI(baseScore, DJLNOAMJECI_Playerdata, GMFMMDAKENC_MusicData, score, HJJNDDPGIML_Team);
		//gauge_08_combo
		OOPMCKOCEFM_Scores[(int)NOJENDEDECD_ScoreType.NLAGKLDCBAG_Combo] = AFBHKBGLMHG * baseScore / 1000;
		if (f)
		{
			//gauge_09_notes
			OOPMCKOCEFM_Scores[(int)NOJENDEDECD_ScoreType.GGOOOIKELDH_NotesScore] = CBIIKLGPILB(baseScore, GMFMMDAKENC_MusicData, DJLNOAMJECI_Playerdata, AKNELONELJK_Difficulty, score, PDLCNDBOMAN_IsLine6, g ? 1 : 0, HJJNDDPGIML_Team);
		}
		//gauge_10_leaf
		OOPMCKOCEFM_Scores[(int)NOJENDEDECD_ScoreType.OPCNHIMPGCE_LeafScore] = OPKNHONFIOG(baseScore, DJLNOAMJECI_Playerdata, ALOBLKOHIKD_FriendData, GMFMMDAKENC_MusicData, score, e, f, g, HJJNDDPGIML_Team);
		int total = 0;
		for (int i = 0; i < OOPMCKOCEFM_Scores.Length; i++)
		{
			total += OOPMCKOCEFM_Scores[i];
		}
		OOPMCKOCEFM_Scores[(int)NOJENDEDECD_ScoreType.CPJOGHCLENG_LiveSkillScore] += NGCOIOANNPA(total, baseScore, DJLNOAMJECI_Playerdata, GMFMMDAKENC_MusicData, score, HJJNDDPGIML_Team);
		int finalScore = 0;
		for (int i = 0; i < OOPMCKOCEFM_Scores.Length; i++)
		{
			OOPMCKOCEFM_Scores[i] = OOPMCKOCEFM_Scores[i] * HCEPBDBHILM_ScoreAdjust[i] / 100;
			finalScore += OOPMCKOCEFM_Scores[i];
		}
		KHCOOPDAGOE_ScoreRank = (ResultScoreRank.Type)resultTarget.DLPBHJALHCK_GetScoreRank(finalScore);
		if(DNJCAKPKNDP_ScoreRatioByDifficulty.Count == 0)
		{
			for(int i = 0; i < DALGMKEOFLN_ScoreRatioNameByDiff.Length; i++)
			{
				DNJCAKPKNDP_ScoreRatioByDifficulty.Add(IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.HNMMJINNHII_Game.LPJLEHAJADA(DALGMKEOFLN_ScoreRatioNameByDiff[i], 200000));
			}
		}
		for(int i = 0; i < 4; i++)
		{
			LKBGHCIKIOA_RankScore[i + 1] = resultTarget.KNIFCANOHOC_RankScore[i] * 1.0f / DNJCAKPKNDP_ScoreRatioByDifficulty[(int)AKNELONELJK_Difficulty];
		}
		int h = EPNPGMCGJKB(AKNELONELJK_Difficulty, PDLCNDBOMAN_IsLine6);
		FDLECNKJCGG_GaugeRatio = finalScore * 1.0f / h;
	}

	// // RVA: 0x1092B60 Offset: 0x1092B60 VA: 0x1092B60
	public static void BKBMHJBFDOG_Reset()
	{
		for(int i = 0; i < OOPMCKOCEFM_Scores.Length; i++)
		{
			OOPMCKOCEFM_Scores[i] = 0;
		}
		KHCOOPDAGOE_ScoreRank = 0;
		if(DNJCAKPKNDP_ScoreRatioByDifficulty.Count == 0)
		{
			for(int i = 0; i < DALGMKEOFLN_ScoreRatioNameByDiff.Length; i++)
			{
				DNJCAKPKNDP_ScoreRatioByDifficulty.Add(IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.HNMMJINNHII_Game.LPJLEHAJADA(DALGMKEOFLN_ScoreRatioNameByDiff[i], 200000));
			}
		}
		for(int i = 0; i < LKBGHCIKIOA_RankScore.Length; i++)
		{
			LKBGHCIKIOA_RankScore[i] = 10;
		}
		FDLECNKJCGG_GaugeRatio = 1;
	}

	// // RVA: 0x108D788 Offset: 0x108D788 VA: 0x108D788
	private static int CBILJEAECKP_GetBaseScore(DFKGGBMFFGB_PlayerInfo DJLNOAMJECI_PlayerData, EAJCBFGKKFA_FriendInfo ALOBLKOHIKD_FriendData, EJKBKMBJMGL_EnemyData BGJGFPPDNEP_EnemyData, EEDKAACNBBG_MusicData GMFMMDAKENC_MusicData, Difficulty.Type AKNELONELJK_Difficulty, bool GBNOALJPOBM_IsLine6, int BAKLKJLPLOJ_FPt, int DHIPGHBJLIL_Progress, JLKEOGLJNOD_TeamInfo HEDKFICAPIJ_Team)
	{
		EDMIONMCICN data = new EDMIONMCICN();
		data.OBKGEDCKHHE_Init();
		CFHDKAFLNEP data2 = new CFHDKAFLNEP();
		data2.OBKGEDCKHHE();
		int scoreWithEnemy = DBHEBCCLIJG(ref data, DJLNOAMJECI_PlayerData, ALOBLKOHIKD_FriendData, GMFMMDAKENC_MusicData, BGJGFPPDNEP_EnemyData, ref data2, DHIPGHBJLIL_Progress, true, HEDKFICAPIJ_Team);
		int scoreWithoutEnemy = DBHEBCCLIJG(ref data, DJLNOAMJECI_PlayerData, ALOBLKOHIKD_FriendData, GMFMMDAKENC_MusicData, null, ref data2, DHIPGHBJLIL_Progress, true, HEDKFICAPIJ_Team);
		int total = 0;
		for (int i = 0; i < HEDKFICAPIJ_Team.BCJEAJPLGMB_MainDivas.Count; i++)
		{
			FFHPBEPOMAK_DivaInfo divaInfo = HEDKFICAPIJ_Team.BCJEAJPLGMB_MainDivas[i];
			if (divaInfo != null)
			{
				StatusData sdata = divaInfo.CMCKNKKCNDK_EquippedStatus;
				total += sdata.soul + sdata.vocal + sdata.charm;
				if(divaInfo.FGFIBOBAPIA_SceneId > 0)
				{
					GCIJNCFDNON_SceneInfo sceneInfo = DJLNOAMJECI_PlayerData.OPIBAPEGCLA_Scenes[divaInfo.FGFIBOBAPIA_SceneId - 1];
					StatusData sdata2 = sceneInfo.CMCKNKKCNDK_Status;
					total += sdata2.soul + sdata2.vocal + sdata2.charm;
				}
				for(int j = 0; j < divaInfo.DJICAKGOGFO_SubSceneIds.Count; j++)
				{
					if (divaInfo.DJICAKGOGFO_SubSceneIds[j] > 0)
					{
						GCIJNCFDNON_SceneInfo sceneInfo = DJLNOAMJECI_PlayerData.OPIBAPEGCLA_Scenes[divaInfo.DJICAKGOGFO_SubSceneIds[j] - 1];
						StatusData sdata2 = sceneInfo.CMCKNKKCNDK_Status;
						total += sdata2.soul + sdata2.vocal + sdata2.charm;
					}
				}
			}
		}
		if (ALOBLKOHIKD_FriendData != null)
		{
			GCIJNCFDNON_SceneInfo data3 = ALOBLKOHIKD_FriendData.KHGKPKDBMOH_GetAssistScene();
			if (data3 != null)
			{
				StatusData sdata = data3.CMCKNKKCNDK_Status;
				total += sdata.soul + sdata.vocal + sdata.charm;
			}
		}
		int c = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.HNMMJINNHII_Game.ADBELGIDIEN_GetProgress(BAKLKJLPLOJ_FPt, GBNOALJPOBM_IsLine6);
		return (scoreWithEnemy - scoreWithoutEnemy) + (int)(c * total / 1000.0f);
	}

	// // RVA: 0x108E2F8 Offset: 0x108E2F8 VA: 0x108E2F8
	private static int CHCGGEPAAOE(DFKGGBMFFGB_PlayerInfo AHEFHIMGIBI_PlayerData, EEDKAACNBBG_MusicData KKHIDFKKFJE_MusicData, EAJCBFGKKFA_FriendInfo PCEGKKLKFNO_FriendData, EJKBKMBJMGL_EnemyData KDOLMBEAGCI_EnemyData, int DHIPGHBJLIL, JLKEOGLJNOD_TeamInfo HEDKFICAPIJ_Team)
	{
		EDMIONMCICN data = new EDMIONMCICN();
		data.OBKGEDCKHHE_Init();
		int total = 0;
		for(int i = 0; i < HEDKFICAPIJ_Team.BCJEAJPLGMB_MainDivas.Count; i++)
		{
			FFHPBEPOMAK_DivaInfo divaInfo = HEDKFICAPIJ_Team.BCJEAJPLGMB_MainDivas[i];
			if(divaInfo != null)
			{
				AECDJDIJJKD_ApplySkills(ref data, divaInfo, HEDKFICAPIJ_Team, AHEFHIMGIBI_PlayerData, KKHIDFKKFJE_MusicData, PCEGKKLKFNO_FriendData, KDOLMBEAGCI_EnemyData);
				data.IMLOCECFHGK(ref FLOHCPIIHEH_WorkStatus);
				total += FLOHCPIIHEH_WorkStatus.soul + FLOHCPIIHEH_WorkStatus.vocal + FLOHCPIIHEH_WorkStatus.charm;
			}
		}
		return (total * DHIPGHBJLIL) / 1000;
	}

	// // RVA: 0x108E584 Offset: 0x108E584 VA: 0x108E584
	private static int DONJDICAMJB(DFKGGBMFFGB_PlayerInfo DJLNOAMJECI_PlayerData, EAJCBFGKKFA_FriendInfo ALOBLKOHIKD_FriendData, EEDKAACNBBG_MusicData GMFMMDAKENC_MusicData, EJKBKMBJMGL_EnemyData BGJGFPPDNEP_EnemyData, ref CFHDKAFLNEP LNMECJDKFDN, int DHIPGHBJLIL, JLKEOGLJNOD_TeamInfo HEDKFICAPIJ_Team)
	{
		EDMIONMCICN data = new EDMIONMCICN();
		data.OBKGEDCKHHE_Init();
		int total = 0;
		for (int i = 0; i < HEDKFICAPIJ_Team.BCJEAJPLGMB_MainDivas.Count; i++)
		{
			FFHPBEPOMAK_DivaInfo divaInfo = HEDKFICAPIJ_Team.BCJEAJPLGMB_MainDivas[i];
			if (divaInfo != null)
			{
				AECDJDIJJKD_ApplySkills(ref data, divaInfo, HEDKFICAPIJ_Team, DJLNOAMJECI_PlayerData, GMFMMDAKENC_MusicData, ALOBLKOHIKD_FriendData, BGJGFPPDNEP_EnemyData);
				for(int j = 0; j < data.MCBLDOECHEK_MatchMusicAttrStatus.Length; j++)
				{
					total += data.MCBLDOECHEK_MatchMusicAttrStatus[i].PJCKMKEJCEL_Total();
				}
			}
		}
		if(ALOBLKOHIKD_FriendData != null)
		{
			NIPJMNDBCNF(ref data, HEDKFICAPIJ_Team, ALOBLKOHIKD_FriendData, DJLNOAMJECI_PlayerData, GMFMMDAKENC_MusicData, BGJGFPPDNEP_EnemyData);
			for (int j = 0; j < data.MCBLDOECHEK_MatchMusicAttrStatus.Length; j++)
			{
				total += data.MCBLDOECHEK_MatchMusicAttrStatus[0].PJCKMKEJCEL_Total();
			}
		}
		for(int i = 0; i < LCLCCHLDNHJ_Costume.GFIKOEEBIJP; i++)
		{
			for(int j = 0; j < 3; j++)
			{
				total += LNMECJDKFDN.KOGBMDOONFA[i, j].ALJGIPAGDJI;
			}
		}
		return (total * DHIPGHBJLIL) / 1000;
	}

	// // RVA: 0x108E93C Offset: 0x108E93C VA: 0x108E93C
	private static int DBHEBCCLIJG(ref EDMIONMCICN HBODCMLFDOB, DFKGGBMFFGB_PlayerInfo DJLNOAMJECI_PlayerData, EAJCBFGKKFA_FriendInfo ALOBLKOHIKD_FriendData, EEDKAACNBBG_MusicData GMFMMDAKENC_MusicData, EJKBKMBJMGL_EnemyData BGJGFPPDNEP_EnemyData, ref CFHDKAFLNEP LNMECJDKFDN, int DHIPGHBJLIL, bool CCPIGKONMMH, JLKEOGLJNOD_TeamInfo HEDKFICAPIJ_Team)
	{
		HBODCMLFDOB.OBKGEDCKHHE_Init();
		int val = 0;
		for(int i = 0; i < HEDKFICAPIJ_Team.BCJEAJPLGMB_MainDivas.Count; i++)
		{
			FFHPBEPOMAK_DivaInfo divaInfo = HEDKFICAPIJ_Team.BCJEAJPLGMB_MainDivas[i];
			if(divaInfo != null)
			{
				AECDJDIJJKD_ApplySkills(ref HBODCMLFDOB, divaInfo, HEDKFICAPIJ_Team, DJLNOAMJECI_PlayerData, GMFMMDAKENC_MusicData, ALOBLKOHIKD_FriendData, BGJGFPPDNEP_EnemyData);
				HBODCMLFDOB.BEDINMCPENB_SetupStatus(ref FLOHCPIIHEH_WorkStatus);
				int s = 0;
				for(int j = 0; j < HBODCMLFDOB.MCBLDOECHEK_MatchMusicAttrStatus.Length; j++)
				{
					s += HBODCMLFDOB.MCBLDOECHEK_MatchMusicAttrStatus[j].PJCKMKEJCEL_Total();
				}
				val = (val - s) + FLOHCPIIHEH_WorkStatus.Total;
			}
		}
		if(ALOBLKOHIKD_FriendData != null)
		{
			NIPJMNDBCNF(ref HBODCMLFDOB, HEDKFICAPIJ_Team, ALOBLKOHIKD_FriendData, DJLNOAMJECI_PlayerData, GMFMMDAKENC_MusicData, BGJGFPPDNEP_EnemyData);
			StatusData st = HBODCMLFDOB.BJABFKMIJHB_StatusMainScene;
			val = (st.soul + val + st.vocal + st.charm) - HBODCMLFDOB.MCBLDOECHEK_MatchMusicAttrStatus[0].PJCKMKEJCEL_Total();
		}
		if(!CCPIGKONMMH)
		{
			for(int i = 0; i < LCLCCHLDNHJ_Costume.GFIKOEEBIJP; i++)
			{
				for(int j = 0; j < 3; j++)
				{
					val += LNMECJDKFDN.KOGBMDOONFA[i,j].HIPODBKKJFL;
				}
			}
		}
		return (val * DHIPGHBJLIL) / 1000;
	}

	// // RVA: 0x108DEA8 Offset: 0x108DEA8 VA: 0x108DEA8
	private static int MHIKPDIJKJO(DFKGGBMFFGB_PlayerInfo DJLNOAMJECI_PlayerData, EAJCBFGKKFA_FriendInfo ALOBLKOHIKD_FriendData, EEDKAACNBBG_MusicData GMFMMDAKENC_MusicData, EJKBKMBJMGL_EnemyData BGJGFPPDNEP_EnemyData, ref CFHDKAFLNEP HBODCMLFDOB, int DHIPGHBJLIL, JLKEOGLJNOD_TeamInfo HEDKFICAPIJ_Team)
	{
		HBODCMLFDOB.OBKGEDCKHHE();
		NJNBELLEGCN(ref HBODCMLFDOB, HEDKFICAPIJ_Team, DJLNOAMJECI_PlayerData, GMFMMDAKENC_MusicData, ALOBLKOHIKD_FriendData, BGJGFPPDNEP_EnemyData);
		int val = 0;
		for(int i = 0; i < LCLCCHLDNHJ_Costume.GFIKOEEBIJP; i++)
		{
			for(int j = 0; j < 3; j++)
			{
				val += HBODCMLFDOB.KOGBMDOONFA[i, j].KHDDPKHPJID;
			}
		}
		CFHDKAFLNEP data = new CFHDKAFLNEP();
		data.OBKGEDCKHHE();
		NJNBELLEGCN(ref data, HEDKFICAPIJ_Team, DJLNOAMJECI_PlayerData, GMFMMDAKENC_MusicData, ALOBLKOHIKD_FriendData, BGJGFPPDNEP_EnemyData);
		int val2 = 0;
		for(int i = 0; i < LCLCCHLDNHJ_Costume.GFIKOEEBIJP; i++)
		{
			for(int j = 0; j < 3; j++)
			{
				val2 += HBODCMLFDOB.KOGBMDOONFA[i, j].HIPODBKKJFL;
			}
		}
		NJNBELLEGCN(ref data, HEDKFICAPIJ_Team, DJLNOAMJECI_PlayerData, GMFMMDAKENC_MusicData, ALOBLKOHIKD_FriendData, null);
		int val3 = 0;
		for(int i = 0; i < LCLCCHLDNHJ_Costume.GFIKOEEBIJP; i++)
		{
			for(int j = 0; j < 3; j++)
			{
				val3 += HBODCMLFDOB.KOGBMDOONFA[i, j].HIPODBKKJFL;
			}
		}
		val3 *= DHIPGHBJLIL;
		return (val2 * DHIPGHBJLIL) / 1000 + (val * DHIPGHBJLIL) / 1000 - val3 / 1000;
	}

	// // RVA: 0x1092FB8 Offset: 0x1092FB8 VA: 0x1092FB8
	private static int FILPDDHMKEJ(GCIJNCFDNON_SceneInfo LAPAEBEIAFK, EEDKAACNBBG_MusicData GMFMMDAKENC, FFHPBEPOMAK_DivaInfo JCFNFJJKPAM)
	{
		if(LAPAEBEIAFK != null)
		{
			int skillId = LAPAEBEIAFK.FILPDDHMKEJ_GetLiveSkillId(false, GMFMMDAKENC != null ? GMFMMDAKENC.FKDCCLPGKDK_JacketAttr : 0, GMFMMDAKENC != null ? GMFMMDAKENC.AIHCEGFANAM_Serie : 0);
			if(skillId > 0)
			{
				if(LAPAEBEIAFK.DCLLIDMKNGO_IsDivaCompatible(JCFNFJJKPAM.AHHJLDLAPAN_DivaId))
				{
					PPGHMBNIAEC skillInfo = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.FOFADHAENKC_Skill.PNJMFKFGIML_LiveSkills[skillId - 1];
					if(skillInfo.AANDPLGPDEI() && !skillInfo.HDPIEILADDH(GMFMMDAKENC.DLAEJOBELBH_MusicId))
					{
						return 0;
					}
					if(skillInfo.HCGDJAFINMH() && !skillInfo.OEJNKFONOGJ(GMFMMDAKENC.FKDCCLPGKDK_JacketAttr))
					{
						return 0;
					}
					return skillId;
				}
			}
		}
		return 0;
	}

	// // RVA: 0x1093268 Offset: 0x1093268 VA: 0x1093268
	private static int OPGMFCHDEDF(int KPIIIEGGPIB, GCIJNCFDNON_SceneInfo COIODGJDJEJ, int FLKGCONIFEE, int KHDDPKHPJID, DFKGGBMFFGB_PlayerInfo DJLNOAMJECI, EEDKAACNBBG_MusicData GMFMMDAKENC, KLBKPANJCPL_Score POMOLHBFAPM, bool KIFJKGDBDBH, JLKEOGLJNOD_TeamInfo HEDKFICAPIJ, FFHPBEPOMAK_DivaInfo NENDFGDMJDN)
	{
		if (KPIIIEGGPIB < 1)
			return 0;
		PPGHMBNIAEC skillInfo = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.FOFADHAENKC_Skill.PNJMFKFGIML_LiveSkills[KPIIIEGGPIB - 1];
		int res = 0;
		for(int i = 0; i < skillInfo.EGLDFPILJLG_SkillBuffEffect.Length; i++)
		{
			int a = CKNDJNOFFGP_GetSkillValue(skillInfo, i, COIODGJDJEJ.AADFFCIDJCB_LiveSkillLevel, NENDFGDMJDN);
			int b = IGDGGMIMLDN(a, DJLNOAMJECI, GMFMMDAKENC, (SkillBuffEffect.Type)skillInfo.EGLDFPILJLG_SkillBuffEffect[i], skillInfo.FLJHGGKIOJH_SkillType, POMOLHBFAPM, HEDKFICAPIJ);
			int c = MEAHJKCBGFE(FLKGCONIFEE, KHDDPKHPJID, DJLNOAMJECI, GMFMMDAKENC, (SkillBuffEffect.Type)skillInfo.EGLDFPILJLG_SkillBuffEffect[i], a + b, (SkillDuration.Type)skillInfo.FPMFEKIPFPI_DurationType[i], skillInfo.PHAGNOHBMCM_DurationByIndexAndLevel[COIODGJDJEJ.AADFFCIDJCB_LiveSkillLevel - 1, i], (SkillTrigger.Type)skillInfo.CPNAGMFCIJK_TriggerType, skillInfo.LFGFBMJNBKN_ConfigValue[COIODGJDJEJ.AADFFCIDJCB_LiveSkillLevel - 1], skillInfo.ELEPHBOKIGK_LimitCount[0], POMOLHBFAPM, KIFJKGDBDBH);
			res += c;
		}
		return res;
	}

	// // RVA: 0x108F96C Offset: 0x108F96C VA: 0x108F96C
	private static int LKGBAIANMLE(int KHDDPKHPJID, DFKGGBMFFGB_PlayerInfo DJLNOAMJECI_PlayerData, EEDKAACNBBG_MusicData GMFMMDAKENC_MusicData, KLBKPANJCPL_Score POMOLHBFAPM_Score, bool HGEKDNNJAAC, bool OOOGNIPJMDE, bool OHLCKPIMMFH, JLKEOGLJNOD_TeamInfo HEDKFICAPIJ_Team)
	{
		int res = 0;
		for (int i = 0; i < HEDKFICAPIJ_Team.BCJEAJPLGMB_MainDivas.Count; i++)
		{
			FFHPBEPOMAK_DivaInfo divaInfo = HEDKFICAPIJ_Team.BCJEAJPLGMB_MainDivas[i];
			if(divaInfo != null)
			{
				if (i != 0 && divaInfo.FGFIBOBAPIA_SceneId > 0)
				{
					GCIJNCFDNON_SceneInfo sceneInfo = DJLNOAMJECI_PlayerData.OPIBAPEGCLA_Scenes[divaInfo.FGFIBOBAPIA_SceneId - 1];
					if (sceneInfo != null)
					{
						int skillId = sceneInfo.FILPDDHMKEJ_GetLiveSkillId(false, GMFMMDAKENC_MusicData != null ? GMFMMDAKENC_MusicData.FKDCCLPGKDK_JacketAttr : 0, GMFMMDAKENC_MusicData != null ? GMFMMDAKENC_MusicData.AIHCEGFANAM_Serie : 0);
						if (skillId > 0 && sceneInfo.DCLLIDMKNGO_IsDivaCompatible(divaInfo.AHHJLDLAPAN_DivaId))
						{
							PPGHMBNIAEC info = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.FOFADHAENKC_Skill.PNJMFKFGIML_LiveSkills[skillId - 1];
							if (!info.AANDPLGPDEI() || info.HDPIEILADDH(GMFMMDAKENC_MusicData.DLAEJOBELBH_MusicId))
							{
								if (!info.HCGDJAFINMH() || info.OEJNKFONOGJ(GMFMMDAKENC_MusicData.FKDCCLPGKDK_JacketAttr))
								{
									for (int j = 0; j < info.EGLDFPILJLG_SkillBuffEffect.Length; j++)
									{
										int a = CKNDJNOFFGP_GetSkillValue(info, j, sceneInfo.AADFFCIDJCB_LiveSkillLevel, divaInfo);
										int b = IGDGGMIMLDN(a, DJLNOAMJECI_PlayerData, GMFMMDAKENC_MusicData, (SkillBuffEffect.Type)info.EGLDFPILJLG_SkillBuffEffect[j], info.FLJHGGKIOJH_SkillType, POMOLHBFAPM_Score, HEDKFICAPIJ_Team);
										int c = CPPANAJNEDJ(KHDDPKHPJID, DJLNOAMJECI_PlayerData, GMFMMDAKENC_MusicData, (SkillBuffEffect.Type)info.EGLDFPILJLG_SkillBuffEffect[j], b + sceneInfo.AADFFCIDJCB_LiveSkillLevel, (SkillDuration.Type)info.FPMFEKIPFPI_DurationType[j], info.PHAGNOHBMCM_DurationByIndexAndLevel[sceneInfo.AADFFCIDJCB_LiveSkillLevel - 1, j], (SkillTrigger.Type)info.CPNAGMFCIJK_TriggerType, info.LFGFBMJNBKN_ConfigValue[sceneInfo.AADFFCIDJCB_LiveSkillLevel - 1], POMOLHBFAPM_Score, HGEKDNNJAAC, OOOGNIPJMDE, OHLCKPIMMFH);
										int d = MCKHJBNJFJH(KHDDPKHPJID, DJLNOAMJECI_PlayerData, GMFMMDAKENC_MusicData, (SkillBuffEffect.Type)info.EGLDFPILJLG_SkillBuffEffect[j], b + sceneInfo.AADFFCIDJCB_LiveSkillLevel, (SkillDuration.Type)info.FPMFEKIPFPI_DurationType[j], info.PHAGNOHBMCM_DurationByIndexAndLevel[sceneInfo.AADFFCIDJCB_LiveSkillLevel - 1, j], (SkillTrigger.Type)info.CPNAGMFCIJK_TriggerType, sceneInfo.AADFFCIDJCB_LiveSkillLevel, POMOLHBFAPM_Score, HGEKDNNJAAC, false);
										res += d + c;
									}
								}
							}
						}
					}
				}
				for(int k = 0; k < divaInfo.DJICAKGOGFO_SubSceneIds.Count; k++)
				{
					if(divaInfo.DJICAKGOGFO_SubSceneIds[k] > 0)
					{
						GCIJNCFDNON_SceneInfo sceneInfo = DJLNOAMJECI_PlayerData.OPIBAPEGCLA_Scenes[divaInfo.DJICAKGOGFO_SubSceneIds[k] - 1];
						if (sceneInfo != null)
						{
							int skillId = sceneInfo.FILPDDHMKEJ_GetLiveSkillId(false, GMFMMDAKENC_MusicData != null ? GMFMMDAKENC_MusicData.FKDCCLPGKDK_JacketAttr : 0, GMFMMDAKENC_MusicData != null ? GMFMMDAKENC_MusicData.AIHCEGFANAM_Serie : 0);
							if (skillId > 0 && sceneInfo.DCLLIDMKNGO_IsDivaCompatible(divaInfo.AHHJLDLAPAN_DivaId))
							{
								PPGHMBNIAEC info = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.FOFADHAENKC_Skill.PNJMFKFGIML_LiveSkills[skillId - 1];
								if (!info.AANDPLGPDEI() || info.HDPIEILADDH(GMFMMDAKENC_MusicData.DLAEJOBELBH_MusicId))
								{
									if (!info.HCGDJAFINMH() || info.OEJNKFONOGJ(GMFMMDAKENC_MusicData.FKDCCLPGKDK_JacketAttr))
									{
										for (int j = 0; j < info.EGLDFPILJLG_SkillBuffEffect.Length; j++)
										{
											int a = CKNDJNOFFGP_GetSkillValue(info, j, sceneInfo.AADFFCIDJCB_LiveSkillLevel, divaInfo);
											int b = IGDGGMIMLDN(a, DJLNOAMJECI_PlayerData, GMFMMDAKENC_MusicData, (SkillBuffEffect.Type)info.EGLDFPILJLG_SkillBuffEffect[j], info.FLJHGGKIOJH_SkillType, POMOLHBFAPM_Score, HEDKFICAPIJ_Team);
											int c = CPPANAJNEDJ(KHDDPKHPJID, DJLNOAMJECI_PlayerData, GMFMMDAKENC_MusicData, (SkillBuffEffect.Type)info.EGLDFPILJLG_SkillBuffEffect[j], b + sceneInfo.AADFFCIDJCB_LiveSkillLevel, (SkillDuration.Type)info.FPMFEKIPFPI_DurationType[j], info.PHAGNOHBMCM_DurationByIndexAndLevel[sceneInfo.AADFFCIDJCB_LiveSkillLevel - 1, j], (SkillTrigger.Type)info.CPNAGMFCIJK_TriggerType, info.LFGFBMJNBKN_ConfigValue[sceneInfo.AADFFCIDJCB_LiveSkillLevel - 1], POMOLHBFAPM_Score, HGEKDNNJAAC, OOOGNIPJMDE, OHLCKPIMMFH);
											int d = MCKHJBNJFJH(KHDDPKHPJID, DJLNOAMJECI_PlayerData, GMFMMDAKENC_MusicData, (SkillBuffEffect.Type)info.EGLDFPILJLG_SkillBuffEffect[j], b + sceneInfo.AADFFCIDJCB_LiveSkillLevel, (SkillDuration.Type)info.FPMFEKIPFPI_DurationType[j], info.PHAGNOHBMCM_DurationByIndexAndLevel[sceneInfo.AADFFCIDJCB_LiveSkillLevel - 1, j], (SkillTrigger.Type)info.CPNAGMFCIJK_TriggerType, sceneInfo.AADFFCIDJCB_LiveSkillLevel, POMOLHBFAPM_Score, HGEKDNNJAAC, false);
											res += d + c;
										}
									}
								}
							}
						}
					}
				}
			}
		}
		return res;
	}

	// // RVA: 0x1092720 Offset: 0x1092720 VA: 0x1092720
	private static int NGCOIOANNPA(int FLKGCONIFEE, int KHDDPKHPJID, DFKGGBMFFGB_PlayerInfo DJLNOAMJECI_PlayerData, EEDKAACNBBG_MusicData GMFMMDAKENC_MusicData, KLBKPANJCPL_Score POMOLHBFAPM_Score, JLKEOGLJNOD_TeamInfo HEDKFICAPIJ_Team)
	{
		int res = 0;
		for(int i = 0; i < HEDKFICAPIJ_Team.BCJEAJPLGMB_MainDivas.Count; i++)
		{
			FFHPBEPOMAK_DivaInfo divaInfo = HEDKFICAPIJ_Team.BCJEAJPLGMB_MainDivas[i];
			if(divaInfo != null)
			{
				if(i != 0 && divaInfo.FGFIBOBAPIA_SceneId > 0)
				{
					GCIJNCFDNON_SceneInfo sceneInfo = DJLNOAMJECI_PlayerData.OPIBAPEGCLA_Scenes[divaInfo.FGFIBOBAPIA_SceneId - 1];
					res += OPGMFCHDEDF(FILPDDHMKEJ(sceneInfo, GMFMMDAKENC_MusicData, divaInfo), sceneInfo, FLKGCONIFEE, KHDDPKHPJID, DJLNOAMJECI_PlayerData, GMFMMDAKENC_MusicData, POMOLHBFAPM_Score, false, HEDKFICAPIJ_Team, divaInfo);
				}
				for(int j = 0; j < divaInfo.DJICAKGOGFO_SubSceneIds.Count; j++)
				{
					if (divaInfo.DJICAKGOGFO_SubSceneIds[j] > 0)
					{
						GCIJNCFDNON_SceneInfo sceneInfo = DJLNOAMJECI_PlayerData.OPIBAPEGCLA_Scenes[divaInfo.DJICAKGOGFO_SubSceneIds[j] - 1];
						res += OPGMFCHDEDF(FILPDDHMKEJ(sceneInfo, GMFMMDAKENC_MusicData, divaInfo), sceneInfo, FLKGCONIFEE, KHDDPKHPJID, DJLNOAMJECI_PlayerData, GMFMMDAKENC_MusicData, POMOLHBFAPM_Score, false, HEDKFICAPIJ_Team, divaInfo);
					}
				}
			}
		}
		return res;
	}

	// // RVA: 0x10908A8 Offset: 0x10908A8 VA: 0x10908A8
	private static int BPPIFIAGLBI(int KHDDPKHPJID, DFKGGBMFFGB_PlayerInfo DJLNOAMJECI_PlayerData, EEDKAACNBBG_MusicData GMFMMDAKENC_MusicData, KLBKPANJCPL_Score POMOLHBFAPM_Score, JLKEOGLJNOD_TeamInfo HEDKFICAPIJ_Team)
	{
		int res = 0;
		FFHPBEPOMAK_DivaInfo divaInfo = HEDKFICAPIJ_Team.BCJEAJPLGMB_MainDivas[0];
		if(divaInfo != null)
		{
			if(divaInfo.FGFIBOBAPIA_SceneId > 0)
			{
				GCIJNCFDNON_SceneInfo sceneInfo = DJLNOAMJECI_PlayerData.OPIBAPEGCLA_Scenes[divaInfo.FGFIBOBAPIA_SceneId - 1];
				if (sceneInfo.HGONFBDIBPM_ActiveSkillId < 1)
					return 0;
				CDNKOFIELMK skillInfo = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.FOFADHAENKC_Skill.PABCHCAAEAA_ActiveSkills[sceneInfo.HGONFBDIBPM_ActiveSkillId - 1];
				for(int i = 0; i < skillInfo.EGLDFPILJLG_BuffEffectType.Length; i++)
				{
					int a = CPPANAJNEDJ(KHDDPKHPJID, DJLNOAMJECI_PlayerData, GMFMMDAKENC_MusicData, (SkillBuffEffect.Type)skillInfo.EGLDFPILJLG_BuffEffectType[i], skillInfo.NKGHBKFMFCI_BuffValueByIndexAndLevel[sceneInfo.AADFFCIDJCB_LiveSkillLevel - 1, i], (SkillDuration.Type)skillInfo.FPMFEKIPFPI_DurationType[i], skillInfo.PHAGNOHBMCM_DurationByIndexAndLevel[sceneInfo.AADFFCIDJCB_LiveSkillLevel - 1, i], SkillTrigger.Type.None, 0, POMOLHBFAPM_Score, false, false, false);
					int b = MCKHJBNJFJH(KHDDPKHPJID, DJLNOAMJECI_PlayerData, GMFMMDAKENC_MusicData, (SkillBuffEffect.Type)skillInfo.EGLDFPILJLG_BuffEffectType[i], skillInfo.NKGHBKFMFCI_BuffValueByIndexAndLevel[sceneInfo.AADFFCIDJCB_LiveSkillLevel - 1, i], (SkillDuration.Type)skillInfo.FPMFEKIPFPI_DurationType[i], skillInfo.PHAGNOHBMCM_DurationByIndexAndLevel[sceneInfo.AADFFCIDJCB_LiveSkillLevel - 1, i], SkillTrigger.Type.None, 0, POMOLHBFAPM_Score, true, false);
					res += b + a;
				}
			}
		}
		return res;
	}

	// // RVA: 0x1090E60 Offset: 0x1090E60 VA: 0x1090E60
	private static int CBIIKLGPILB(int KHDDPKHPJID, EEDKAACNBBG_MusicData GMFMMDAKENC_MusicData, DFKGGBMFFGB_PlayerInfo DJLNOAMJECI_PlayerData, Difficulty.Type AKNELONELJK_Difficulty, KLBKPANJCPL_Score POMOLHBFAPM_Score, bool GBNOALJPOBM_IsLine6, int BAKLKJLPLOJ, JLKEOGLJNOD_TeamInfo HEDKFICAPIJ_Team)
	{
		int res = 0;
		if (GMFMMDAKENC_MusicData != null)
		{
			if(GMFMMDAKENC_MusicData is IBJAKJJICBC)
			{
				KEODKEGFDLD_FreeMusicInfo musicInfo = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.IBPAFKKEKNK_Music.NOBCLJIAMLC_GetFreeMusicData((GMFMMDAKENC_MusicData as IBJAKJJICBC).GHBPLHBNMBK_FreeMusicId);
				short[] vals = GBNOALJPOBM_IsLine6 ? musicInfo.DPJDHKIIJIJ_SpNotesByDiff6Line : musicInfo.OCOGIADDNDN_SpNoteByDiff;
				if (vals[(int)AKNELONELJK_Difficulty] < 1)
					res = 0;
				else
				{
					KLJCBKMHKNK k = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.HNMMJINNHII_Game.BBFNPHGDCOF(vals[(int)AKNELONELJK_Difficulty]);
					EGLJKICMCPG e = k.GCINIJEMHFK(KLJCBKMHKNK.HHMPIIILOLD.CBHCEDGAGHL_AwakenDiva/*3*/);
					int a = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.HNMMJINNHII_Game.GAHIBKLEDBF((int)AKNELONELJK_Difficulty, GBNOALJPOBM_IsLine6);
					int b = (int)Mathf.Clamp(e.PHGLKBPLFDH_RMax / 100.0f * POMOLHBFAPM_Score.JJBOEMOJPEC_DivaNote, e.MPPANPOOIIB_NMin, e.GKPPCFMBANO_NMax);
					res = 0;
					int c = POMOLHBFAPM_Score.JJBOEMOJPEC_DivaNote;
					if (c < b)
						b = c;
					if(e.JNNKKPNGPAA(SpecialNoteAttribute.Type.HighScore) != 0)
					{
						int numSpNoteExpected = 0;
						for(int i = 0; i < HEDKFICAPIJ_Team.BCJEAJPLGMB_MainDivas.Count; i++)
						{
							FFHPBEPOMAK_DivaInfo divaInfo = HEDKFICAPIJ_Team.BCJEAJPLGMB_MainDivas[i];
							if(divaInfo != null)
							{
								if(divaInfo.FGFIBOBAPIA_SceneId > 0)
								{
									GCIJNCFDNON_SceneInfo sceneInfo = DJLNOAMJECI_PlayerData.OPIBAPEGCLA_Scenes[divaInfo.FGFIBOBAPIA_SceneId - 1];
									numSpNoteExpected += sceneInfo.CMCKNKKCNDK_Status.spNoteExpected[2];
								}
								for(int j = 0; j < divaInfo.DJICAKGOGFO_SubSceneIds.Count; j++)
								{
									if (divaInfo.DJICAKGOGFO_SubSceneIds[j] > 0)
									{
										GCIJNCFDNON_SceneInfo sceneInfo = DJLNOAMJECI_PlayerData.OPIBAPEGCLA_Scenes[divaInfo.DJICAKGOGFO_SubSceneIds[j] - 1];
										numSpNoteExpected += sceneInfo.CMCKNKKCNDK_Status.spNoteExpected[2];
									}
								}
							}
						}
						b = Mathf.RoundToInt((numSpNoteExpected / 10 + e.JNNKKPNGPAA(SpecialNoteAttribute.Type.HighScore)) * b);
						res = KHDDPKHPJID / a * b;
					}
				}
			}
		}
		return res;
	}

	// // RVA: 0x10915F0 Offset: 0x10915F0 VA: 0x10915F0
	private static int OPKNHONFIOG(int KHDDPKHPJID, DFKGGBMFFGB_PlayerInfo DJLNOAMJECI_PlayerData, EAJCBFGKKFA_FriendInfo ALOBLKOHIKD_FriendData, EEDKAACNBBG_MusicData GMFMMDAKENC_MusicData, KLBKPANJCPL_Score POMOLHBFAPM_Score, bool HGEKDNNJAAC, bool OOOGNIPJMDE, bool OHLCKPIMMFH, JLKEOGLJNOD_TeamInfo HEDKFICAPIJ_Team)
	{
		MEMCOJHNEIP.Clear();
		GCIJNCFDNON_SceneInfo s = null;
		for(int i = 0; i < HEDKFICAPIJ_Team.BCJEAJPLGMB_MainDivas.Count; i++)
		{
			FFHPBEPOMAK_DivaInfo divaInfo = HEDKFICAPIJ_Team.BCJEAJPLGMB_MainDivas[i];
			if(divaInfo != null)
			{
				if(divaInfo.FGFIBOBAPIA_SceneId > 0)
				{
					GCIJNCFDNON_SceneInfo sceneInfo = DJLNOAMJECI_PlayerData.OPIBAPEGCLA_Scenes[divaInfo.FGFIBOBAPIA_SceneId - 1];
					if(sceneInfo.MKHFCGPJPFI_LimitOverCount > 0)
					{
						OMPNCHBNEPF.KHEKNNFCAOI(sceneInfo.JKGFBFPIMGA_Rarity, sceneInfo.MKHFCGPJPFI_LimitOverCount, sceneInfo.MJBODMOLOBC_Luck);
						HHOKCLBEOHI(OMPNCHBNEPF.CMCKNKKCNDK, sceneInfo, GMFMMDAKENC_MusicData);
						MEMCOJHNEIP.Add(OMPNCHBNEPF.CMCKNKKCNDK);
					}
					if (i == 0)
						s = sceneInfo;
				}
				for(int j = 0; j < divaInfo.DJICAKGOGFO_SubSceneIds.Count; j++)
				{
					if (divaInfo.DJICAKGOGFO_SubSceneIds[j] > 0)
					{
						GCIJNCFDNON_SceneInfo sceneInfo = DJLNOAMJECI_PlayerData.OPIBAPEGCLA_Scenes[divaInfo.DJICAKGOGFO_SubSceneIds[j] - 1];
						if (sceneInfo.MKHFCGPJPFI_LimitOverCount > 0)
						{
							OMPNCHBNEPF.KHEKNNFCAOI(sceneInfo.JKGFBFPIMGA_Rarity, sceneInfo.MKHFCGPJPFI_LimitOverCount, sceneInfo.MJBODMOLOBC_Luck);
							HHOKCLBEOHI(OMPNCHBNEPF.CMCKNKKCNDK, sceneInfo, GMFMMDAKENC_MusicData);
							MEMCOJHNEIP.Add(OMPNCHBNEPF.CMCKNKKCNDK);
						}
					}
				}
			}
		}
		if(ALOBLKOHIKD_FriendData != null && ALOBLKOHIKD_FriendData.KHGKPKDBMOH_GetAssistScene() != null && ALOBLKOHIKD_FriendData.KHGKPKDBMOH_GetAssistScene().MKHFCGPJPFI_LimitOverCount > 0)
		{
			GCIJNCFDNON_SceneInfo sceneInfo = ALOBLKOHIKD_FriendData.KHGKPKDBMOH_GetAssistScene();
			OMPNCHBNEPF.KHEKNNFCAOI(sceneInfo.JKGFBFPIMGA_Rarity, sceneInfo.MKHFCGPJPFI_LimitOverCount, sceneInfo.MJBODMOLOBC_Luck);
			HHOKCLBEOHI(OMPNCHBNEPF.CMCKNKKCNDK, sceneInfo, GMFMMDAKENC_MusicData);
			MEMCOJHNEIP.Add(OMPNCHBNEPF.CMCKNKKCNDK);
		}
		int e = 0;
		if (s != null)
		{
			int skillId = s.FILPDDHMKEJ_GetLiveSkillId(false, GMFMMDAKENC_MusicData != null ? GMFMMDAKENC_MusicData.FKDCCLPGKDK_JacketAttr : 0, GMFMMDAKENC_MusicData != null ? GMFMMDAKENC_MusicData.AIHCEGFANAM_Serie : 0);
			if(skillId > 0)
			{
				PPGHMBNIAEC skillInfo = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.FOFADHAENKC_Skill.PNJMFKFGIML_LiveSkills[skillId - 1];
				int rate = (MEMCOJHNEIP.centerLiveSkillRate + MEMCOJHNEIP.centerLiveSkillRate_SameMusicAttr + MEMCOJHNEIP.centerLiveSkillRate_SameSeriesAttr);
				for (int i = 0; i < skillInfo.EGLDFPILJLG_SkillBuffEffect.Length; i++)
				{
					int a = CKNDJNOFFGP_GetSkillValue(skillInfo, i, s.AADFFCIDJCB_LiveSkillLevel, HEDKFICAPIJ_Team.BCJEAJPLGMB_MainDivas[0]);
					int b = IGDGGMIMLDN(a, DJLNOAMJECI_PlayerData, GMFMMDAKENC_MusicData, (SkillBuffEffect.Type)skillInfo.EGLDFPILJLG_SkillBuffEffect[i], skillInfo.FLJHGGKIOJH_SkillType, POMOLHBFAPM_Score, HEDKFICAPIJ_Team);
					int c = CPPANAJNEDJ(KHDDPKHPJID, DJLNOAMJECI_PlayerData, GMFMMDAKENC_MusicData, (SkillBuffEffect.Type) skillInfo.EGLDFPILJLG_SkillBuffEffect[i], a + b, (SkillDuration.Type) skillInfo.FPMFEKIPFPI_DurationType[i], skillInfo.PHAGNOHBMCM_DurationByIndexAndLevel[s.AADFFCIDJCB_LiveSkillLevel - 1, i], (SkillTrigger.Type) skillInfo.CPNAGMFCIJK_TriggerType, skillInfo.LFGFBMJNBKN_ConfigValue[s.AADFFCIDJCB_LiveSkillLevel - 1], POMOLHBFAPM_Score, HGEKDNNJAAC, OOOGNIPJMDE, OHLCKPIMMFH);
					int g = MCKHJBNJFJH(KHDDPKHPJID, DJLNOAMJECI_PlayerData, GMFMMDAKENC_MusicData, (SkillBuffEffect.Type)skillInfo.EGLDFPILJLG_SkillBuffEffect[i], a + b, (SkillDuration.Type)skillInfo.FPMFEKIPFPI_DurationType[i], skillInfo.PHAGNOHBMCM_DurationByIndexAndLevel[s.AADFFCIDJCB_LiveSkillLevel - 1, i], (SkillTrigger.Type)skillInfo.CPNAGMFCIJK_TriggerType, skillInfo.LFGFBMJNBKN_ConfigValue[s.AADFFCIDJCB_LiveSkillLevel - 1], POMOLHBFAPM_Score, HGEKDNNJAAC, false);
					int d = MEAHJKCBGFE(0, KHDDPKHPJID, DJLNOAMJECI_PlayerData, GMFMMDAKENC_MusicData, (SkillBuffEffect.Type)skillInfo.EGLDFPILJLG_SkillBuffEffect[i], a + b, (SkillDuration.Type)skillInfo.FPMFEKIPFPI_DurationType[i], skillInfo.PHAGNOHBMCM_DurationByIndexAndLevel[s.AADFFCIDJCB_LiveSkillLevel - 1, i], (SkillTrigger.Type)skillInfo.CPNAGMFCIJK_TriggerType, skillInfo.LFGFBMJNBKN_ConfigValue[s.AADFFCIDJCB_LiveSkillLevel - 1], skillInfo.ELEPHBOKIGK_LimitCount[0], POMOLHBFAPM_Score, true);
					e += c * rate / 100 + g * rate / 100 + d * rate / 100;
				}
			}
		}
		return ((KHDDPKHPJID / POMOLHBFAPM_Score.NLKEBAOBJCM_Cb) * ((POMOLHBFAPM_Score.NLKEBAOBJCM_Cb * 90 / 100) * (MEMCOJHNEIP.excellentRate + MEMCOJHNEIP.excellentRate_SameMusicAttr + MEMCOJHNEIP.excellentRate_SameSeriesAttr)) / 100 * 90) / 100 + e;
	}

	// // RVA: 0x1094624 Offset: 0x1094624 VA: 0x1094624
	private static void HHOKCLBEOHI(LimitOverStatusData CMCKNKKCNDK, GCIJNCFDNON_SceneInfo PNLOINMCCKH, EEDKAACNBBG_MusicData KKHIDFKKFJE)
	{
		if((int)PNLOINMCCKH.AIHCEGFANAM_SceneSeries != KKHIDFKKFJE.AIHCEGFANAM_Serie)
		{
			CMCKNKKCNDK.excellentRate_SameSeriesAttr = 0;
			CMCKNKKCNDK.centerLiveSkillRate_SameSeriesAttr = 0;
		}
		if(KKHIDFKKFJE.FKDCCLPGKDK_JacketAttr != 4 && KKHIDFKKFJE.FKDCCLPGKDK_JacketAttr != PNLOINMCCKH.JGJFIJOCPAG_SceneAttr)
		{
			CMCKNKKCNDK.excellentRate_SameMusicAttr = 0;
			CMCKNKKCNDK.centerLiveSkillRate_SameMusicAttr = 0;
		}
	}

	// // RVA: 0x10939D4 Offset: 0x10939D4 VA: 0x10939D4
	private static int IGDGGMIMLDN(int NKGHBKFMFCI, DFKGGBMFFGB_PlayerInfo DJLNOAMJECI, EEDKAACNBBG_MusicData GMFMMDAKENC, SkillBuffEffect.Type MCJEIDPDMLF, int NEJBNCHLMNJ, KLBKPANJCPL_Score POMOLHBFAPM, JLKEOGLJNOD_TeamInfo HEDKFICAPIJ)
	{
		int IILKAJBHLMJ = 0;
		OKGLGHCBCJP_Database LKMHPJKIFDN = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database;
		Func<GCIJNCFDNON_SceneInfo, FFHPBEPOMAK_DivaInfo, int> f = (GCIJNCFDNON_SceneInfo PNLOINMCCKH, FFHPBEPOMAK_DivaInfo FDBOPFEOENF) =>
		{
			//0x175A624
			if (PNLOINMCCKH != null)
			{
				int skillId = PNLOINMCCKH.FILPDDHMKEJ_GetLiveSkillId(false, GMFMMDAKENC != null ? GMFMMDAKENC.FKDCCLPGKDK_JacketAttr : 0, GMFMMDAKENC != null ? GMFMMDAKENC.AIHCEGFANAM_Serie : 0);
				if(skillId > 0)
				{
					if(PNLOINMCCKH.DCLLIDMKNGO_IsDivaCompatible(FDBOPFEOENF.AHHJLDLAPAN_DivaId))
					{
						PPGHMBNIAEC skillInfo = LKMHPJKIFDN.FOFADHAENKC_Skill.PNJMFKFGIML_LiveSkills[skillId - 1];
						if(skillInfo.AANDPLGPDEI())
						{
							if (!skillInfo.HDPIEILADDH(GMFMMDAKENC.DLAEJOBELBH_MusicId))
								return 0;
						}
						if(skillInfo.HCGDJAFINMH())
						{
							if (!skillInfo.OEJNKFONOGJ(GMFMMDAKENC.FKDCCLPGKDK_JacketAttr))
								return 0;
						}
						for(int i = 0; i < skillInfo.EGLDFPILJLG_SkillBuffEffect.Length; i++)
						{
							if(skillInfo.EGLDFPILJLG_SkillBuffEffect[i] == (int)SkillBuffEffect.Type.EffectValueUp &&
								NEJBNCHLMNJ != 0 && NEJBNCHLMNJ == skillInfo.DPGDCJFBFGK_TargetSkillType)
							{
								if(LKMHPJKIFDN.FOFADHAENKC_Skill.JBGPIPLAAIA(skillInfo.POMLAENHCHA_TargetSkillEffectId, (int)MCJEIDPDMLF))
								{
									IILKAJBHLMJ += NKGHBKFMFCI * skillInfo.NKGHBKFMFCI_BuffValueByIndexAndLevel[PNLOINMCCKH.AADFFCIDJCB_LiveSkillLevel - 1, i];
								}
							}
						}
					}
				}
			}
			return IILKAJBHLMJ;
		};
		for (int i = 0; i < HEDKFICAPIJ.BCJEAJPLGMB_MainDivas.Count; i++)
		{
			FFHPBEPOMAK_DivaInfo divaInfo = HEDKFICAPIJ.BCJEAJPLGMB_MainDivas[i];
			if(divaInfo != null)
			{
				if(i != 0 && divaInfo.FGFIBOBAPIA_SceneId > 0)
				{
					GCIJNCFDNON_SceneInfo sceneInfo = DJLNOAMJECI.OPIBAPEGCLA_Scenes[divaInfo.FGFIBOBAPIA_SceneId - 1];
					f(sceneInfo, divaInfo);
				}
				for(int j = 0; j < divaInfo.DJICAKGOGFO_SubSceneIds.Count; j++)
				{
					if (divaInfo.DJICAKGOGFO_SubSceneIds[j] > 0)
					{
						GCIJNCFDNON_SceneInfo sceneInfo = DJLNOAMJECI.OPIBAPEGCLA_Scenes[divaInfo.DJICAKGOGFO_SubSceneIds[j] - 1];
						f(sceneInfo, divaInfo);
					}
				}
			}
		}
		return IILKAJBHLMJ;
	}

	// // RVA: 0x1093FD0 Offset: 0x1093FD0 VA: 0x1093FD0
	private static int CPPANAJNEDJ(int KHDDPKHPJID, DFKGGBMFFGB_PlayerInfo DJLNOAMJECI, EEDKAACNBBG_MusicData GMFMMDAKENC, SkillBuffEffect.Type MCJEIDPDMLF, int NKGHBKFMFCI, SkillDuration.Type FPMFEKIPFPI, int PHAGNOHBMCM, SkillTrigger.Type BAAFOOKFDLL, int LFGFBMJNBKN, KLBKPANJCPL_Score POMOLHBFAPM, bool HGEKDNNJAAC, bool OOOGNIPJMDE, bool OHLCKPIMMFH)
	{
		int res = 0;
		if (MCJEIDPDMLF > SkillBuffEffect.Type.ScoreUpPercentage_Intimacy)
			return 0;
		if (((1 << ((int)MCJEIDPDMLF & 0xff)) & 0x180202) == 0)
			return 0;
		int v = 0;
		if(FPMFEKIPFPI >= SkillDuration.Type.ValkyrieModeAndNoteResult && FPMFEKIPFPI <= SkillDuration.Type.AwakenDivaModeAndNoteResult)
		{
			if(BAAFOOKFDLL == SkillTrigger.Type.AwakenDivaMode)
			{
				v = POMOLHBFAPM.JJBOEMOJPEC_DivaNote;
				if (!HGEKDNNJAAC)
					return 0;
			}
			else if(BAAFOOKFDLL == SkillTrigger.Type.DivaMode)
			{
				v = POMOLHBFAPM.JJBOEMOJPEC_DivaNote;
				OHLCKPIMMFH = OOOGNIPJMDE;
				if (!OHLCKPIMMFH)
					return 0;
			}
			else if(BAAFOOKFDLL == SkillTrigger.Type.ValkyrieMode)
			{
				v = POMOLHBFAPM.GEIDIHCKDNO;
				if (!OHLCKPIMMFH)
					return 0;
			}
			res = NKGHBKFMFCI * KHDDPKHPJID / 100 * v / POMOLHBFAPM.NLKEBAOBJCM_Cb;
		}
		else
		{
			if (FPMFEKIPFPI != SkillDuration.Type.Time)
				return 0;
			switch(BAAFOOKFDLL)
			{
				case SkillTrigger.Type.Timebomb:
					v = POMOLHBFAPM.MCMIPODICAN_length;
					if (LFGFBMJNBKN * 1000 - v != 0 && v <= LFGFBMJNBKN * 1000)
						return 0;
					res = ((KHDDPKHPJID * NKGHBKFMFCI) / 100) * (PHAGNOHBMCM * 1000 / v);
					break;
				case SkillTrigger.Type.Combo:
					v = POMOLHBFAPM.NLKEBAOBJCM_Cb;
					if (v < LFGFBMJNBKN)
						return 0;
					v = POMOLHBFAPM.MCMIPODICAN_length;
					res = ((KHDDPKHPJID * NKGHBKFMFCI) / 100) * (PHAGNOHBMCM * 1000 / v);
					break;
				case SkillTrigger.Type.EveryTime:
					v = POMOLHBFAPM.MCMIPODICAN_length;
					int b = LFGFBMJNBKN * 1000;
					if (b - v != 0 && v <= b)
						return 0;
					res = ((KHDDPKHPJID * NKGHBKFMFCI) / 100) * (PHAGNOHBMCM * 1000 / v) * v / b;
					break;
				case SkillTrigger.Type.EveryScore:
					break;
			}
		}
		return res;
	}

	// // RVA: 0x109435C Offset: 0x109435C VA: 0x109435C
	private static int MCKHJBNJFJH(int KHDDPKHPJID, DFKGGBMFFGB_PlayerInfo DJLNOAMJECI, EEDKAACNBBG_MusicData GMFMMDAKENC, SkillBuffEffect.Type MCJEIDPDMLF, int NKGHBKFMFCI, SkillDuration.Type FPMFEKIPFPI, int PHAGNOHBMCM, SkillTrigger.Type BAAFOOKFDLL, int LFGFBMJNBKN, KLBKPANJCPL_Score POMOLHBFAPM, bool HGEKDNNJAAC, bool OHLCKPIMMFH)
	{
		int skill_combo_bonus_value0 = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.HNMMJINNHII_Game.LPJLEHAJADA("skill_combo_bonus_value0", 0);
		if (FPMFEKIPFPI != SkillDuration.Type.Time || MCJEIDPDMLF != SkillBuffEffect.Type.ComboBonus)
			return 0;
		if (BAAFOOKFDLL == SkillTrigger.Type.EveryTime)
			return 0;
		int cb = POMOLHBFAPM.NLKEBAOBJCM_Cb;
		int len = POMOLHBFAPM.MCMIPODICAN_length;
		int a = 0;
		bool b = false;
		if (BAAFOOKFDLL != SkillTrigger.Type.AwakenDivaMode && BAAFOOKFDLL != SkillTrigger.Type.None)
		{
			a = cb / 2;
		}
		else
		{
			if (BAAFOOKFDLL != SkillTrigger.Type.AwakenDivaMode)
			{
				HGEKDNNJAAC = true;
			}
			b = HGEKDNNJAAC;
			a = cb - POMOLHBFAPM.JJBOEMOJPEC_DivaNote;
		}
		int res = 0;
		if(b && skill_combo_bonus_value0 <= cb)
		{
			res = (PHAGNOHBMCM * 1000 / len) * (Mathf.Max(a / cb, 1) * NKGHBKFMFCI) / 100 * KHDDPKHPJID;
		}
		return res;
	}

	// // RVA: 0x1093E5C Offset: 0x1093E5C VA: 0x1093E5C
	private static int MEAHJKCBGFE(int FLKGCONIFEE, int KHDDPKHPJID, DFKGGBMFFGB_PlayerInfo DJLNOAMJECI, EEDKAACNBBG_MusicData GMFMMDAKENC, SkillBuffEffect.Type MCJEIDPDMLF, int NKGHBKFMFCI, SkillDuration.Type FPMFEKIPFPI, int PHAGNOHBMCM, SkillTrigger.Type BAAFOOKFDLL, int LFGFBMJNBKN, int JLDDHNFKGHL, KLBKPANJCPL_Score POMOLHBFAPM, bool KIFJKGDBDBH = false)
	{
		int res = 0;
		if (MCJEIDPDMLF < SkillBuffEffect.Type.Num && ((1 << ((int)MCJEIDPDMLF & 0xff)) & 0x180202) != 0 && BAAFOOKFDLL == SkillTrigger.Type.EveryScore)
		{
			int i = FLKGCONIFEE / LFGFBMJNBKN * 10000;
			if (KIFJKGDBDBH)
				i = 1;
			res = 0;
			int a = i;
			if (i > 0)
				a = JLDDHNFKGHL;
			if(a > 0)
			{
				a = -a;
				if (-a <= -i && a != i)
					a = -i;
				res = -(a * NKGHBKFMFCI / 100 * KHDDPKHPJID * PHAGNOHBMCM * 1000 / POMOLHBFAPM.MCMIPODICAN_length);
			}
		}
		return res;
	}

	// // RVA: 0x108EE08 Offset: 0x108EE08 VA: 0x108EE08
	private static bool MODGPFEPLIP(ref EDMIONMCICN HBODCMLFDOB, DFKGGBMFFGB_PlayerInfo DJLNOAMJECI_PlayerData, EAJCBFGKKFA_FriendInfo ALOBLKOHIKD_FriendData, EEDKAACNBBG_MusicData GMFMMDAKENC_MusicData, KLBKPANJCPL_Score POMOLHBFAPM_Score, Difficulty.Type AKNELONELJK_Difficulty, bool GIKLNODJKFK_IsLine6, out bool HGEKDNNJAAC, out bool OHLCKPIMMFH, JLKEOGLJNOD_TeamInfo HEDKFICAPIJ_Team)
	{
		bool res = false;
		HGEKDNNJAAC = false;
		OHLCKPIMMFH = false;
		int sup = 0;
		int fold = 0;
		for(int i = 0; i < HEDKFICAPIJ_Team.BCJEAJPLGMB_MainDivas.Count; i++)
		{
			FFHPBEPOMAK_DivaInfo divaInfo = HEDKFICAPIJ_Team.BCJEAJPLGMB_MainDivas[i];
			if(divaInfo != null)
			{
				fold += divaInfo.JLJGCBOHJID_Status.fold;
				sup += divaInfo.JLJGCBOHJID_Status.support;
				if(divaInfo.FGFIBOBAPIA_SceneId > 0)
				{
					GCIJNCFDNON_SceneInfo sceneInfo = DJLNOAMJECI_PlayerData.OPIBAPEGCLA_Scenes[divaInfo.FGFIBOBAPIA_SceneId - 1];
					fold += sceneInfo.CMCKNKKCNDK_Status.fold;
					sup += sceneInfo.CMCKNKKCNDK_Status.support;
				}
				for(int j = 0; j < divaInfo.DJICAKGOGFO_SubSceneIds.Count; j++)
				{
					if (divaInfo.DJICAKGOGFO_SubSceneIds[j] > 0)
					{
						GCIJNCFDNON_SceneInfo sceneInfo = DJLNOAMJECI_PlayerData.OPIBAPEGCLA_Scenes[divaInfo.DJICAKGOGFO_SubSceneIds[j] - 1];
						fold += sceneInfo.CMCKNKKCNDK_Status.fold;
						sup += sceneInfo.CMCKNKKCNDK_Status.support;
					}
				}
			}
		}
		if(ALOBLKOHIKD_FriendData != null && ALOBLKOHIKD_FriendData.KHGKPKDBMOH_GetAssistScene() != null)
		{
			fold += ALOBLKOHIKD_FriendData.KHGKPKDBMOH_GetAssistScene().CMCKNKKCNDK_Status.fold;
			sup += ALOBLKOHIKD_FriendData.KHGKPKDBMOH_GetAssistScene().CMCKNKKCNDK_Status.support;
		}
		HBODCMLFDOB.BEDINMCPENB_SetupStatus(ref FLOHCPIIHEH_WorkStatus);
		int subGoal;
		int goal;
		int max;
		if(GMFMMDAKENC_MusicData is LIEJFHMGNIA)
		{
			DJNPIGEFPMF_StoryMusicInfo g = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.IBPAFKKEKNK_Music.FLMLJIKBIMJ_GetStoryMusicData((GMFMMDAKENC_MusicData as LIEJFHMGNIA).KLCIIHKFPPO_StoryMusicId);
			subGoal = g.HLKHOFPAOMK_SubGoalByDiff[(int)AKNELONELJK_Difficulty];
			goal = g.HLLJIICKNIP_GoalByDiff[(int)AKNELONELJK_Difficulty];
			max = g.FENOHOEIJOE_MaxValueByDiff[(int)AKNELONELJK_Difficulty];
		}
		else
		{
			KEODKEGFDLD_FreeMusicInfo m = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.IBPAFKKEKNK_Music.NOBCLJIAMLC_GetFreeMusicData((GMFMMDAKENC_MusicData as IBJAKJJICBC).GHBPLHBNMBK_FreeMusicId);
			if(!GIKLNODJKFK_IsLine6)
			{
				subGoal = m.HLKHOFPAOMK_SubGoalFreeModeByDiff[(int)AKNELONELJK_Difficulty];
				goal = m.HLLJIICKNIP_GoalFreeModeByDiff[(int)AKNELONELJK_Difficulty];
				max = m.FENOHOEIJOE_MaxValueFreeModeByDiff[(int)AKNELONELJK_Difficulty];
			}
			else
			{
				subGoal = m.MAGILDGLOKD_SubGoalFreeModeL6ByDiff[(int)AKNELONELJK_Difficulty];
				goal = m.JEANDFEBLIG_GoalFreeModeL6ByDiff[(int)AKNELONELJK_Difficulty];
				max = m.KFIDHFOGDPJ_MaxValueFreeModeL6ByDiff[(int)AKNELONELJK_Difficulty];
			}
		}
		int val = 0;
		for(int i = POMOLHBFAPM_Score.KIEHDJFCCNM; i > 0; i--)
		{
			val += Mathf.RoundToInt(
				BEFDPKNGHPO(fold + sup, val, max, 
					IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.HNMMJINNHII_Game.CIFKMCKFMOA_FCoeff4 / 10000.0f, 
					IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.HNMMJINNHII_Game.IHIONKFAAED_FCoeff1 / 100.0f,
					IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.HNMMJINNHII_Game.HHPJIALEPEE_FCoeff2 / 100.0f,
					subGoal, max, POMOLHBFAPM_Score.KIEHDJFCCNM
				) * (fold + sup));
		}
		if (val < subGoal)
			res = false;
		else
		{
			OHLCKPIMMFH = true;
			res = PKLPIDIBHMN(DJLNOAMJECI_PlayerData, GMFMMDAKENC_MusicData, AKNELONELJK_Difficulty, GIKLNODJKFK_IsLine6, POMOLHBFAPM_Score.GEIDIHCKDNO, (sup + FLOHCPIIHEH_WorkStatus.support) / IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.HNMMJINNHII_Game.MPAMBMKFCKK_BCoeff2 + 1, out HGEKDNNJAAC, HEDKFICAPIJ_Team);
		}

		return res;
	}

	// // RVA: 0x10947B0 Offset: 0x10947B0 VA: 0x10947B0
	private static float BEFDPKNGHPO(float EGIGDODCJOG, int LKCCMBEOLLA, int DCBENCMNOGO, float GKHEOELGCAP, float IHEACEHPHKP, float JDIKNJEJCNN, int NNFBAIJKCCP, float GLDFMGNCOGM, int EDGIJNGLBDE)
	{
		float f;
		if(EGIGDODCJOG >= 0)
		{
			if(LKCCMBEOLLA < NNFBAIJKCCP)
			{
				f = Mathf.Max((DCBENCMNOGO - LKCCMBEOLLA) / DCBENCMNOGO, GKHEOELGCAP);
			}
			else
			{
				f = Mathf.Max((DCBENCMNOGO - LKCCMBEOLLA) / DCBENCMNOGO, GKHEOELGCAP) * IHEACEHPHKP;
			}
		}
		else
		{
			f = LKCCMBEOLLA / DCBENCMNOGO * JDIKNJEJCNN;
			if (LKCCMBEOLLA < NNFBAIJKCCP)
				f = LKCCMBEOLLA / DCBENCMNOGO;
		}
		return GLDFMGNCOGM / EDGIJNGLBDE * f;
	}

	// // RVA: 0x1094918 Offset: 0x1094918 VA: 0x1094918
	private static bool PKLPIDIBHMN(DFKGGBMFFGB_PlayerInfo DJLNOAMJECI, EEDKAACNBBG_MusicData GMFMMDAKENC, Difficulty.Type AKNELONELJK, bool GIKLNODJKFK, int EDGIJNGLBDE, float PGEDGKMCFLB, out bool HGEKDNNJAAC, JLKEOGLJNOD_TeamInfo HEDKFICAPIJ)
	{
		DJNPIGEFPMF_StoryMusicInfo smd = null;
		int goal;
		int subGoal;
		int enemyId;
		if (GMFMMDAKENC is LIEJFHMGNIA)
		{
			DJNPIGEFPMF_StoryMusicInfo g = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.IBPAFKKEKNK_Music.FLMLJIKBIMJ_GetStoryMusicData((GMFMMDAKENC as LIEJFHMGNIA).KLCIIHKFPPO_StoryMusicId);
			subGoal = g.HLKHOFPAOMK_SubGoalByDiff[(int)AKNELONELJK];
			goal = g.HLLJIICKNIP_GoalByDiff[(int)AKNELONELJK];
			enemyId = g.LHICAKGHIGF[(int)AKNELONELJK];
			smd = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.IBPAFKKEKNK_Music.FLMLJIKBIMJ_GetStoryMusicData(g.KLCIIHKFPPO);
		}
		else
		{
			KEODKEGFDLD_FreeMusicInfo m = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.IBPAFKKEKNK_Music.NOBCLJIAMLC_GetFreeMusicData((GMFMMDAKENC as IBJAKJJICBC).GHBPLHBNMBK_FreeMusicId);
			if (!GIKLNODJKFK)
			{
				subGoal = m.LJPKLMJPLAC[(int)AKNELONELJK];
				goal = m.MALHPBKPIDE[(int)AKNELONELJK];
				enemyId = m.LHICAKGHIGF_EnemyIdByDiff[(int)AKNELONELJK];
			}
			else
			{
				subGoal = m.ILCJOOPIILK[(int)AKNELONELJK];
				goal = m.BGILEHEJHHA[(int)AKNELONELJK];
				enemyId = m.PJNFOCDANCE_EnemyIdByDiffL6[(int)AKNELONELJK];
			}
		}
		AONMBIEIBCD.Clear();
		AONMBIEIBCD.Add(IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.HNMMJINNHII_Game.IJDBNKCLGIC_BCoeff3);
		AONMBIEIBCD.Add(IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.HNMMJINNHII_Game.GLMKBFEHPLA_BCoeff4);
		AONMBIEIBCD.Add(IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.HNMMJINNHII_Game.GLMKBFEHPLA_BCoeff4);
		int v = EDGIJNGLBDE + 1 - RhythmGameEnemyStatus.AttackComboCount;
		FOMKBDKKODO.Clear();
		int b = 0;
		for (int i = 0; i < AONMBIEIBCD.Count; i++)
		{
			int a = v / AONMBIEIBCD.Count;
			b += a;
			if (i == 1)
			{
				b = v % AONMBIEIBCD.Count + b;
			}
			FOMKBDKKODO.Add(b);
		}
		JPIANKEOOMB_Valkyrie.KJPIDJOMODA_ValkyrieInfo valk = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.PEOALFEGNDH_Valkyrie.CDENCMNHNGA_ValkyrieList[HEDKFICAPIJ.JOKFNBLEILN_Valkyrie.GPPEFLKGGGJ_ValkyrieId - 1];
		int dd = 0;
		int p = 0;
		for(int i = 0; i < v; i++)
		{
			dd += OEEDGPGEPFH(valk.OJHINEMKMOP(0) * PGEDGKMCFLB, valk.PAELLCKLEJP(0) * PGEDGKMCFLB, 
				IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.OPFBEAJJMJB_Enemy.INONDJKKOKG(enemyId).ADMMEMNGKEN_Avo, i, i + RhythmGameEnemyStatus.AttackComboCount, 1, 1, v, out p);
		}
		HGEKDNNJAAC = goal <= dd;
		return subGoal <= dd;
	}

	// // RVA: 0x1095364 Offset: 0x1095364 VA: 0x1095364
	private static int OEEDGPGEPFH(float ALOGOPNMLJI, float EDGBEFKOGMN, float IFMEDLKMHIG, int LGGLNFIKCKF, int CKFNNECHOGG, float PBIFADDFADF, float KOMJMBBPMML, int EDGIJNGLBDE, out int GBMNIAOLBEB)
	{
		int i = 0;
		for (; i < FOMKBDKKODO.Count; i++)
		{
			if(LGGLNFIKCKF + 1 - RhythmGameEnemyStatus.AttackComboCount < FOMKBDKKODO[i])
				break;
		}
		return (int)(FDIIFOOLDGM(EDGBEFKOGMN, IFMEDLKMHIG, KOMJMBBPMML, out GBMNIAOLBEB) * 
				(IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.HNMMJINNHII_Game.FHHPNFAECCJ(CKFNNECHOGG) / 100.0f) * 
				(AONMBIEIBCD[i] * 1.0f / EDGIJNGLBDE) * ALOGOPNMLJI * PBIFADDFADF);
	}

	// // RVA: 0x10956D0 Offset: 0x10956D0 VA: 0x10956D0
	private static float FDIIFOOLDGM(float EDGBEFKOGMN, float IFMEDLKMHIG, float KOMJMBBPMML, out int GBMNIAOLBEB)
	{
		int a = (int)((EDGBEFKOGMN * 1.2f - IFMEDLKMHIG) * KOMJMBBPMML);
		GBMNIAOLBEB = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.HNMMJINNHII_Game.FHFLCJHEEPK(a);
		return IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.HNMMJINNHII_Game.IKIGFABDFMB(a) / 100.0f;
	}

	// // RVA: 0x1093648 Offset: 0x1093648 VA: 0x1093648
	private static int CKNDJNOFFGP_GetSkillValue(PPGHMBNIAEC KMHPOGKCHHK, int AOGDKBPNGCI, int GBMHFDKCFGB, FFHPBEPOMAK_DivaInfo HIDAJBOHJKH)
	{
		int v = KMHPOGKCHHK.NKGHBKFMFCI_BuffValueByIndexAndLevel[GBMHFDKCFGB - 1, AOGDKBPNGCI];
		if (KMHPOGKCHHK.EGLDFPILJLG_SkillBuffEffect[AOGDKBPNGCI] != (int)SkillBuffEffect.Type.ScoreUpPercentage_Intimacy)
		{
			if(KMHPOGKCHHK.EGLDFPILJLG_SkillBuffEffect[AOGDKBPNGCI] == (int)SkillBuffEffect.Type.ScoreUpPercentage_FoldWave)
			{
				v = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.FOFADHAENKC_Skill.HJGDBBPDHON(v).DOOGFEGEKLG_ValueMax;
			}
			return v;
		}
		JJOELIOGMKK_DivaIntimacyInfo j = new JJOELIOGMKK_DivaIntimacyInfo();
		j.KHEKNNFCAOI(HIDAJBOHJKH.AHHJLDLAPAN_DivaId);
		j.HCDGELDHFHB(false);
		EHGAHMIBPIB s = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.FOFADHAENKC_Skill.HJGDBBPDHON(v);
		return Mathf.Min(j.HEKJGCMNJAB_CurrentLevel / s.KCOHMHFBDKF_Value1[GBMHFDKCFGB - 1] * s.HLMMBNCIIAC_Value2[GBMHFDKCFGB - 1], s.DOOGFEGEKLG_ValueMax);
	}

	// // RVA: 0x109477C Offset: 0x109477C VA: 0x109477C
	// private static bool BBIBJKIKBPO(SkillBuffEffect.Type LFAFFMFOFEG) { }
}
