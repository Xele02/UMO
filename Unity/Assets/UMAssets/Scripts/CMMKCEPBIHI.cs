
using XeApp.Game.Common;
using System.Collections.Generic;
using UnityEngine;
using System;
using XeApp.Game.RhythmGame;

public static class CMMKCEPBIHI
{
    public enum NOJENDEDECD_ScoreType
    {
        HNGJDMNPMNP_0_BaseScore = 0,
        KBHGPMNGALJ_1_Costume = 1,
        AJIDOFDBIDL_2_MatchMusicScore = 2,
        NLAGKLDCBAG_3_Combo = 3,
        GJDKJOHIEFF_4_PlateScore = 4,
        BMMPEPDFICC_5_CenterSkillScore = 5,
        CPJOGHCLENG_6_LiveSkillScore = 6,
        NKPLJNILBFP_7_ASkillScore = 7,
        GGOOOIKELDH_8_NotesScore = 8,
        OPCNHIMPGCE_9_LeafScore = 9,
        AEFCOHJBLPO_10_Num = 10,
    }

	private const int IMNILJDBFDL = 30;
	private const int NPMLACIOKJE = 1;
	private static StatusData GCECPDEOIIN = new StatusData(); // 0x0
	private static Comparison<GCIJNCFDNON_SceneInfo>[] MOGECDOLPPL = new Comparison<GCIJNCFDNON_SceneInfo>[3] {
        (GCIJNCFDNON_SceneInfo _HKICMNAACDA_a, GCIJNCFDNON_SceneInfo _BNKHBCBJBKI_b) => {
            //0x175A31C
			return _BNKHBCBJBKI_b.CMCKNKKCNDK_status.soul - _HKICMNAACDA_a.CMCKNKKCNDK_status.soul;
        },
        (GCIJNCFDNON_SceneInfo _HKICMNAACDA_a, GCIJNCFDNON_SceneInfo _BNKHBCBJBKI_b) => {
            //0x175A39C
			return _BNKHBCBJBKI_b.CMCKNKKCNDK_status.vocal - _HKICMNAACDA_a.CMCKNKKCNDK_status.vocal;
        },
        (GCIJNCFDNON_SceneInfo _HKICMNAACDA_a, GCIJNCFDNON_SceneInfo _BNKHBCBJBKI_b) => {
            //0x175A41C
			return _BNKHBCBJBKI_b.CMCKNKKCNDK_status.charm - _HKICMNAACDA_a.CMCKNKKCNDK_status.charm;
        }
    }; // 0x4
	private static Func<StatusData, int>[] HDLKMMHKOKE = new Func<StatusData, int>[3] {
        (StatusData _IBDJFHFIIHN_s) => {
            //0x175A49C
			return _IBDJFHFIIHN_s.soul;
        },
        (StatusData _IBDJFHFIIHN_s) => {
            //0x175A4C0
			return _IBDJFHFIIHN_s.vocal;
        },
        (StatusData _IBDJFHFIIHN_s) => {
            //0x175A4E4
			return _IBDJFHFIIHN_s.charm;
        }
    }; // 0x8
	private static Action<StatusData, int>[] HOBOLJEFDFF = new Action<StatusData, int>[3] {
        (StatusData _IBDJFHFIIHN_s, int OHDPMGMGJBI) => {
            //0x175A508
			_IBDJFHFIIHN_s.soul += OHDPMGMGJBI;
        },
        (StatusData _IBDJFHFIIHN_s, int OHDPMGMGJBI) => {
            //0x175A54C
			_IBDJFHFIIHN_s.vocal += OHDPMGMGJBI;
        },
        (StatusData _IBDJFHFIIHN_s, int OHDPMGMGJBI) => {
            //0x175A590
			_IBDJFHFIIHN_s.charm += OHDPMGMGJBI;
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

	public static ResultScoreRank.Type KHCOOPDAGOE_ScoreRank { get; private set; } // 0x3C MHJDBFONNKN_bgs CKNLMMGELDF_bgs GEENHBHNFIC_bgs
	public static float FDLECNKJCGG_GaugeRatio { get; private set; } // 0x40 DCBOMKOHHEP_bgs IGEHABMEOHD_bgs FOLIPOFKIJA_bgs

	// // RVA: 0x1085914 Offset: 0x1085914 VA: 0x1085914
	public static void DIDENKKDJKI(ref AEGLGBOGDHH _HBODCMLFDOB_result, JLKEOGLJNOD_TeamInfo _MLAFAACKKBG_Unit, DFKGGBMFFGB_PlayerInfo _AHEFHIMGIBI_PlayerData, EEDKAACNBBG_MusicData _KKHIDFKKFJE_MusicData, EAJCBFGKKFA_FriendInfo _PCEGKKLKFNO_FriendData, EJKBKMBJMGL_EnemyData KDOLMBEAGCI)
	{
		for(int i = 0; i < _MLAFAACKKBG_Unit.BCJEAJPLGMB_MainDivas.Count; i++)
		{
			FFHPBEPOMAK_DivaInfo divaInfo = _MLAFAACKKBG_Unit.BCJEAJPLGMB_MainDivas[i];
			if(divaInfo != null)
			{
				AECDJDIJJKD_ApplySkills(ref _HBODCMLFDOB_result.GJLJJDIDODK[i], divaInfo, _MLAFAACKKBG_Unit, _AHEFHIMGIBI_PlayerData, _KKHIDFKKFJE_MusicData, _PCEGKKLKFNO_FriendData, KDOLMBEAGCI);
			}
		}
		NJNBELLEGCN(ref _HBODCMLFDOB_result.CLCIOEHGFNI, _MLAFAACKKBG_Unit, _AHEFHIMGIBI_PlayerData, _KKHIDFKKFJE_MusicData, _PCEGKKLKFNO_FriendData, KDOLMBEAGCI);
		NIPJMNDBCNF(ref _HBODCMLFDOB_result.JPMGNPAHGIB, _MLAFAACKKBG_Unit, _PCEGKKLKFNO_FriendData, _AHEFHIMGIBI_PlayerData, _KKHIDFKKFJE_MusicData, KDOLMBEAGCI);
	}

	// // RVA: 0x1085B98 Offset: 0x1085B98 VA: 0x1085B98
	public static void AECDJDIJJKD_ApplySkills(ref EDMIONMCICN _HBODCMLFDOB_result, FFHPBEPOMAK_DivaInfo _DGCJCAHIAPP_Diva, JLKEOGLJNOD_TeamInfo _MLAFAACKKBG_Unit, DFKGGBMFFGB_PlayerInfo AHEFHIMGIBI_PlayerData, EEDKAACNBBG_MusicData _KKHIDFKKFJE_MusicData, EAJCBFGKKFA_FriendInfo _PCEGKKLKFNO_FriendData, EJKBKMBJMGL_EnemyData KDOLMBEAGCI_EnemyData)
	{
		_HBODCMLFDOB_result.JCHLONCMPAJ_Clear();
		HPODBOHGGDH_SkillInfo skillInfo = new HPODBOHGGDH_SkillInfo();
		skillInfo.JCHLONCMPAJ_Clear();
		int divaIdx = -1;
		if(_MLAFAACKKBG_Unit != null)
		{
			divaIdx = _MLAFAACKKBG_Unit.BCJEAJPLGMB_MainDivas.FindIndex((FFHPBEPOMAK_DivaInfo _FDBOPFEOENF_diva) => {
				//0x175A5DC
				if(_FDBOPFEOENF_diva == null)
					return false;
				return _FDBOPFEOENF_diva.AHHJLDLAPAN_DivaId == _DGCJCAHIAPP_Diva.AHHJLDLAPAN_DivaId;
			});
		}
		int skillId = _DGCJCAHIAPP_Diva.FFKMJNHFFFL_costume.ENMAEBJGEKL_SkillId;
		if(skillId != 0)
		{
			skillInfo.EDEDFDDIOKO_Set(skillId, _DGCJCAHIAPP_Diva.FFKMJNHFFFL_costume.DEOBDFOPLHG_SkillLevel, (SeriesAttr.Type)_DGCJCAHIAPP_Diva.AIHCEGFANAM_SerieAttr);
			AECDJDIJJKD_ApplySkills(ref _HBODCMLFDOB_result, _DGCJCAHIAPP_Diva, AHEFHIMGIBI_PlayerData.OPIBAPEGCLA_Scenes, _KKHIDFKKFJE_MusicData, JNKEEAOKNCI_Skill.MKGJHBAKMBD_SkillType.KBHGPMNGALJ_2_Costume, ref skillInfo, divaIdx, _MLAFAACKKBG_Unit);
		}
		if(_MLAFAACKKBG_Unit != null)
		{
			if(_MLAFAACKKBG_Unit.BCJEAJPLGMB_MainDivas[0] != null && 
				_MLAFAACKKBG_Unit.BCJEAJPLGMB_MainDivas[0].FGFIBOBAPIA_SceneId != 0)
			{
				GCIJNCFDNON_SceneInfo sceneInfo = AHEFHIMGIBI_PlayerData.OPIBAPEGCLA_Scenes[_MLAFAACKKBG_Unit.BCJEAJPLGMB_MainDivas[0].FGFIBOBAPIA_SceneId - 1];
				int skillSceneId = 0;
				if(_KKHIDFKKFJE_MusicData == null)
				{
					skillSceneId = sceneInfo.MEOOLHNNMHL_GetCenterSkillId(false, 0, 0);
				}
				else
				{
					skillSceneId = sceneInfo.MEOOLHNNMHL_GetCenterSkillId(false, _KKHIDFKKFJE_MusicData.FKDCCLPGKDK_JacketAttr, _KKHIDFKKFJE_MusicData.AIHCEGFANAM_SerieAttr);
				}
				if(skillSceneId != 0)
				{
					skillInfo.EDEDFDDIOKO_Set(skillSceneId, sceneInfo.DDEDANKHHPN_SkillLevel, sceneInfo.AIHCEGFANAM_SerieAttr);
					AECDJDIJJKD_ApplySkills(ref _HBODCMLFDOB_result, _DGCJCAHIAPP_Diva, AHEFHIMGIBI_PlayerData.OPIBAPEGCLA_Scenes, _KKHIDFKKFJE_MusicData, JNKEEAOKNCI_Skill.MKGJHBAKMBD_SkillType.MHKFDBLMOGF_0_Scene, ref skillInfo, divaIdx, _MLAFAACKKBG_Unit);
				}
			}
		}
		if(_PCEGKKLKFNO_FriendData != null && _PCEGKKLKFNO_FriendData.KHGKPKDBMOH_GetAssistScene() != null)
		{
			skillId = 0;
			GCIJNCFDNON_SceneInfo sceneInfo = _PCEGKKLKFNO_FriendData.KHGKPKDBMOH_GetAssistScene();
			int skillSceneId = 0;
			if(_KKHIDFKKFJE_MusicData == null)
			{
				skillSceneId = sceneInfo.MEOOLHNNMHL_GetCenterSkillId(false, 0, 0);
			}
			else
			{
				skillSceneId = sceneInfo.MEOOLHNNMHL_GetCenterSkillId(false, _KKHIDFKKFJE_MusicData.FKDCCLPGKDK_JacketAttr, _KKHIDFKKFJE_MusicData.AIHCEGFANAM_SerieAttr);
			}
			if(skillSceneId != 0)
			{
				skillInfo.EDEDFDDIOKO_Set(skillSceneId, sceneInfo.DDEDANKHHPN_SkillLevel, sceneInfo.AIHCEGFANAM_SerieAttr);
				AECDJDIJJKD_ApplySkills(ref _HBODCMLFDOB_result, _DGCJCAHIAPP_Diva, AHEFHIMGIBI_PlayerData.OPIBAPEGCLA_Scenes, _KKHIDFKKFJE_MusicData, JNKEEAOKNCI_Skill.MKGJHBAKMBD_SkillType.MHKFDBLMOGF_0_Scene, ref skillInfo, divaIdx, _MLAFAACKKBG_Unit);
			}
		}
		if(_KKHIDFKKFJE_MusicData != null)
		{
			for(int i = 0; i < _DGCJCAHIAPP_Diva.DJICAKGOGFO_SubSceneIds.Count + 1; i++)
			{
				GCIJNCFDNON_SceneInfo sceneInfo = null;
				StatusData st = null;
				if(i == 0)
				{
					if(_DGCJCAHIAPP_Diva.FGFIBOBAPIA_SceneId != 0)
					{
						sceneInfo = AHEFHIMGIBI_PlayerData.OPIBAPEGCLA_Scenes[_DGCJCAHIAPP_Diva.FGFIBOBAPIA_SceneId - 1];
						st = _HBODCMLFDOB_result.BJABFKMIJHB_StatusMainScene;
					}
				}
				else
				{
					if(_DGCJCAHIAPP_Diva.DJICAKGOGFO_SubSceneIds[i - 1] != 0)
					{
						sceneInfo = AHEFHIMGIBI_PlayerData.OPIBAPEGCLA_Scenes[_DGCJCAHIAPP_Diva.DJICAKGOGFO_SubSceneIds[i - 1] - 1];
						st = _HBODCMLFDOB_result.OBCPFDNKLMM_StatusSubScenes[i - 1];
					}
				}
				if(sceneInfo != null)
				{
					bool comp = _KKHIDFKKFJE_MusicData.FKDCCLPGKDK_JacketAttr == 4 || _KKHIDFKKFJE_MusicData.FKDCCLPGKDK_JacketAttr == sceneInfo.JGJFIJOCPAG_SceneAttr;
					if(comp && st != null)
					{
						st.soul += sceneInfo.CMCKNKKCNDK_status.soul;
						st.vocal += sceneInfo.CMCKNKKCNDK_status.vocal;
						st.charm += sceneInfo.CMCKNKKCNDK_status.charm;
						_HBODCMLFDOB_result.MCBLDOECHEK_MatchMusicAttrStatus[i].MKMIEGPOKGG_Soul = sceneInfo.CMCKNKKCNDK_status.soul * 30 / 100;
						_HBODCMLFDOB_result.MCBLDOECHEK_MatchMusicAttrStatus[i].EACDINDLGLF_Voice = sceneInfo.CMCKNKKCNDK_status.vocal * 30 / 100;
						_HBODCMLFDOB_result.MCBLDOECHEK_MatchMusicAttrStatus[i].LDLHPACIIAB_Charm = sceneInfo.CMCKNKKCNDK_status.charm * 30 / 100;
						_HBODCMLFDOB_result.LGGLFAECCBK_BonusTypeFlag |= MKHCIKICBOI_ParamFlag.MKADAMIGMPO_7_Total/*7*/;
					}
				}
			}
		}
		if(KDOLMBEAGCI_EnemyData != null && KDOLMBEAGCI_EnemyData.PDHCABLLJPB_CenterSkillId != 0)
		{
			skillInfo.EDEDFDDIOKO_Set(KDOLMBEAGCI_EnemyData.PDHCABLLJPB_CenterSkillId, 1, 0);
			AECDJDIJJKD_ApplySkills(ref _HBODCMLFDOB_result, _DGCJCAHIAPP_Diva, AHEFHIMGIBI_PlayerData.OPIBAPEGCLA_Scenes, _KKHIDFKKFJE_MusicData, JNKEEAOKNCI_Skill.MKGJHBAKMBD_SkillType.AIFGINAKBMA_1_EnemySkill, ref skillInfo, divaIdx, _MLAFAACKKBG_Unit);
		}
		_HBODCMLFDOB_result.ELFAIDEBLJB.Div(100);
		_HBODCMLFDOB_result.IMLGBMGIACC.Div(100);
		_HBODCMLFDOB_result.BJABFKMIJHB_StatusMainScene.Div(100);
		_HBODCMLFDOB_result.AJINBLGCBMM_StatusCostumeMainScene.Div(100);
		for(int i = 0; i < _HBODCMLFDOB_result.OBCPFDNKLMM_StatusSubScenes.Length; i++)
		{
			_HBODCMLFDOB_result.OBCPFDNKLMM_StatusSubScenes[i].Div(100);
			_HBODCMLFDOB_result.FEGNMIGJMDM_CostumeSubScene[i].Div(100);
		}
	}

	// // RVA: 0x1087134 Offset: 0x1087134 VA: 0x1087134
	public static void NIPJMNDBCNF(ref EDMIONMCICN _HBODCMLFDOB_result, JLKEOGLJNOD_TeamInfo _MLAFAACKKBG_Unit, EAJCBFGKKFA_FriendInfo _PCEGKKLKFNO_FriendData, DFKGGBMFFGB_PlayerInfo AHEFHIMGIBI_PlayerData, EEDKAACNBBG_MusicData _KKHIDFKKFJE_MusicData, EJKBKMBJMGL_EnemyData KDOLMBEAGCI_EnemyData)
	{
		HPODBOHGGDH_SkillInfo data = new HPODBOHGGDH_SkillInfo();
		_HBODCMLFDOB_result.JCHLONCMPAJ_Clear();
		if(_PCEGKKLKFNO_FriendData != null)
		{
			_PCEGKKLKFNO_FriendData.KHGKPKDBMOH_GetAssistScene();
			data.JCHLONCMPAJ_Clear();
			if(_MLAFAACKKBG_Unit != null)
			{
				FFHPBEPOMAK_DivaInfo divaInfo = _MLAFAACKKBG_Unit.BCJEAJPLGMB_MainDivas[0];
				if(divaInfo != null && divaInfo.FGFIBOBAPIA_SceneId > 0)
				{
					GCIJNCFDNON_SceneInfo sceneInfo = AHEFHIMGIBI_PlayerData.OPIBAPEGCLA_Scenes[divaInfo.FGFIBOBAPIA_SceneId - 1];
					int a = 0;
					if(_KKHIDFKKFJE_MusicData == null)
					{
						a = sceneInfo.MEOOLHNNMHL_GetCenterSkillId(false, 0, 0);
					}
					else
					{
						a = sceneInfo.MEOOLHNNMHL_GetCenterSkillId(false, _KKHIDFKKFJE_MusicData.FKDCCLPGKDK_JacketAttr, _KKHIDFKKFJE_MusicData.AIHCEGFANAM_SerieAttr);
					}
					if(a != 0)
					{
						data.EDEDFDDIOKO_Set(a, sceneInfo.DDEDANKHHPN_SkillLevel, sceneInfo.AIHCEGFANAM_SerieAttr);
						AECDJDIJJKD_ApplySkills(ref _HBODCMLFDOB_result, _PCEGKKLKFNO_FriendData.JIGONEMPPNP_Diva, _PCEGKKLKFNO_FriendData.KHGKPKDBMOH_GetAssistScene(), _PCEGKKLKFNO_FriendData.HDJOHAJPGBA_SubScene[0], _PCEGKKLKFNO_FriendData.HDJOHAJPGBA_SubScene[1], _KKHIDFKKFJE_MusicData, 0, ref data, -1, _MLAFAACKKBG_Unit);
					}
				}
			}
			if(_PCEGKKLKFNO_FriendData.KHGKPKDBMOH_GetAssistScene() != null)
			{
				int a = _PCEGKKLKFNO_FriendData.KHGKPKDBMOH_GetAssistScene().MEOOLHNNMHL_GetCenterSkillId(false, _KKHIDFKKFJE_MusicData == null ? 0 : _KKHIDFKKFJE_MusicData.FKDCCLPGKDK_JacketAttr, _KKHIDFKKFJE_MusicData == null ? 0 : _KKHIDFKKFJE_MusicData.AIHCEGFANAM_SerieAttr);
				if(a != 0)
				{
					data.EDEDFDDIOKO_Set(a, _PCEGKKLKFNO_FriendData.KHGKPKDBMOH_GetAssistScene().DDEDANKHHPN_SkillLevel, _PCEGKKLKFNO_FriendData.KHGKPKDBMOH_GetAssistScene().AIHCEGFANAM_SerieAttr);
					AECDJDIJJKD_ApplySkills(ref _HBODCMLFDOB_result, _PCEGKKLKFNO_FriendData.JIGONEMPPNP_Diva, _PCEGKKLKFNO_FriendData.KHGKPKDBMOH_GetAssistScene(), _PCEGKKLKFNO_FriendData.HDJOHAJPGBA_SubScene[0], _PCEGKKLKFNO_FriendData.HDJOHAJPGBA_SubScene[1], _KKHIDFKKFJE_MusicData, 0, ref data, -1, _MLAFAACKKBG_Unit);
				}
			}
			if(_KKHIDFKKFJE_MusicData != null)
			{
				for(int i = 0; i < _PCEGKKLKFNO_FriendData.JIGONEMPPNP_Diva.DJICAKGOGFO_SubSceneIds.Count + 1; i++)
				{
					bool isAttrValid = false;
					StatusData st = null;
					StatusData st2 = null;
					if (i == 0)
					{
						if (_PCEGKKLKFNO_FriendData.KHGKPKDBMOH_GetAssistScene() != null)
						{
							st2 = _PCEGKKLKFNO_FriendData.KHGKPKDBMOH_GetAssistScene().CMCKNKKCNDK_status;
							isAttrValid = _KKHIDFKKFJE_MusicData.FKDCCLPGKDK_JacketAttr == 4 || _KKHIDFKKFJE_MusicData.FKDCCLPGKDK_JacketAttr == _PCEGKKLKFNO_FriendData.KHGKPKDBMOH_GetAssistScene().JGJFIJOCPAG_SceneAttr;
							st = _HBODCMLFDOB_result.BJABFKMIJHB_StatusMainScene;
						}
					}
					else
					{
						GCIJNCFDNON_SceneInfo sceneInfo = _PCEGKKLKFNO_FriendData.HDJOHAJPGBA_SubScene[i - 1];
						if (sceneInfo != null)
						{
							st2 = sceneInfo.CMCKNKKCNDK_status;
							isAttrValid = _KKHIDFKKFJE_MusicData.FKDCCLPGKDK_JacketAttr == 4 || _KKHIDFKKFJE_MusicData.FKDCCLPGKDK_JacketAttr == sceneInfo.JGJFIJOCPAG_SceneAttr;
							st = _HBODCMLFDOB_result.OBCPFDNKLMM_StatusSubScenes[i - 1];
						}
					}
					if(isAttrValid &&  st != null)
					{
						st.soul += st2.soul * 30;
						st.vocal += st2.vocal * 30;
						st.charm += st2.charm * 30;
						_HBODCMLFDOB_result.MCBLDOECHEK_MatchMusicAttrStatus[i].MKMIEGPOKGG_Soul = (st2.soul * 30) / 100;
						_HBODCMLFDOB_result.MCBLDOECHEK_MatchMusicAttrStatus[i].EACDINDLGLF_Voice = (st2.vocal * 30) / 100;
						_HBODCMLFDOB_result.MCBLDOECHEK_MatchMusicAttrStatus[i].LDLHPACIIAB_Charm = (st2.charm * 30) / 100;
						if(i == 0)
						{
							_HBODCMLFDOB_result.LGGLFAECCBK_BonusTypeFlag |= MKHCIKICBOI_ParamFlag.MKADAMIGMPO_7_Total/*7*/;
						}
					}
				}
			}
			if(KDOLMBEAGCI_EnemyData != null && KDOLMBEAGCI_EnemyData.PDHCABLLJPB_CenterSkillId != 0)
			{
				data.EDEDFDDIOKO_Set(KDOLMBEAGCI_EnemyData.PDHCABLLJPB_CenterSkillId, 1, 0);
				AECDJDIJJKD_ApplySkills(ref _HBODCMLFDOB_result, _PCEGKKLKFNO_FriendData.JIGONEMPPNP_Diva, _PCEGKKLKFNO_FriendData.KHGKPKDBMOH_GetAssistScene(), _PCEGKKLKFNO_FriendData.HDJOHAJPGBA_SubScene[0], _PCEGKKLKFNO_FriendData.HDJOHAJPGBA_SubScene[1], _KKHIDFKKFJE_MusicData, JNKEEAOKNCI_Skill.MKGJHBAKMBD_SkillType.AIFGINAKBMA_1_EnemySkill, ref data, -1, _MLAFAACKKBG_Unit);
			}
			_HBODCMLFDOB_result.ELFAIDEBLJB.Div(100);
			_HBODCMLFDOB_result.BJABFKMIJHB_StatusMainScene.Div(100);
			for(int i = 0; i < _HBODCMLFDOB_result.OBCPFDNKLMM_StatusSubScenes.Length; i++)
			{
				_HBODCMLFDOB_result.OBCPFDNKLMM_StatusSubScenes[i].Div(100);
			}
		}
	}

	// // RVA: 0x1087C58 Offset: 0x1087C58 VA: 0x1087C58
	private static void AECDJDIJJKD_ApplySkills(ref EDMIONMCICN _HBODCMLFDOB_result, FFHPBEPOMAK_DivaInfo _DGCJCAHIAPP_Diva, List<GCIJNCFDNON_SceneInfo> OPIBAPEGCLA_Scenes, EEDKAACNBBG_MusicData _KKHIDFKKFJE_MusicData, JNKEEAOKNCI_Skill.MKGJHBAKMBD_SkillType _GJLFANGDGCL_Target, ref HPODBOHGGDH_SkillInfo CHMOEPNAJOO_SkillInfo, int ABBDKBOIBCG_DivaIdx, JLKEOGLJNOD_TeamInfo _MLAFAACKKBG_Unit)
	{
		GCIJNCFDNON_SceneInfo sceneInfo = null;
		if(_DGCJCAHIAPP_Diva.FGFIBOBAPIA_SceneId != 0)
		{
			sceneInfo = OPIBAPEGCLA_Scenes[_DGCJCAHIAPP_Diva.FGFIBOBAPIA_SceneId - 1];
		}
		GCIJNCFDNON_SceneInfo sub1Info = null;
		int sId = _DGCJCAHIAPP_Diva.DJICAKGOGFO_SubSceneIds[0];
		if(sId != 0)
		{
			sub1Info = OPIBAPEGCLA_Scenes[sId - 1];
		}
		GCIJNCFDNON_SceneInfo sub2Info = null;
		sId = _DGCJCAHIAPP_Diva.DJICAKGOGFO_SubSceneIds[1];
		if(sId != 0)
		{
			sub2Info = OPIBAPEGCLA_Scenes[sId - 1];
		}
		AECDJDIJJKD_ApplySkills(ref _HBODCMLFDOB_result, _DGCJCAHIAPP_Diva, sceneInfo, sub1Info, sub2Info, _KKHIDFKKFJE_MusicData, _GJLFANGDGCL_Target, ref CHMOEPNAJOO_SkillInfo, ABBDKBOIBCG_DivaIdx, _MLAFAACKKBG_Unit);
	}

	// // RVA: 0x1087F7C Offset: 0x1087F7C VA: 0x1087F7C
	private static void AECDJDIJJKD_ApplySkills(ref EDMIONMCICN _HBODCMLFDOB_result, FFHPBEPOMAK_DivaInfo _DGCJCAHIAPP_Diva, GCIJNCFDNON_SceneInfo AFBMEMCHJCL_MainScene, GCIJNCFDNON_SceneInfo _HAPFNHPFBGD_SubScene1, GCIJNCFDNON_SceneInfo JEBHFJEJAKJ_SubScene2, EEDKAACNBBG_MusicData _KKHIDFKKFJE_MusicData, JNKEEAOKNCI_Skill.MKGJHBAKMBD_SkillType _GJLFANGDGCL_Target, ref HPODBOHGGDH_SkillInfo CHMOEPNAJOO_SkillInfo, int ABBDKBOIBCG_DivaIdx, JLKEOGLJNOD_TeamInfo _MLAFAACKKBG_Unit)
	{
		List<HBDCPGLAPHH> skillsList;
		if(_GJLFANGDGCL_Target == JNKEEAOKNCI_Skill.MKGJHBAKMBD_SkillType.KBHGPMNGALJ_2_Costume)
		{
			skillsList = IMMAOANGPNK_NetMasterDataManager.HHCJCDFCLOB_Instance.NKEBMCIMJND_Database.FOFADHAENKC_Skill.BIOEJKBCIKD_CenterSkillCostume;
		}
		else if (_GJLFANGDGCL_Target == JNKEEAOKNCI_Skill.MKGJHBAKMBD_SkillType.AIFGINAKBMA_1_EnemySkill)
		{
			skillsList = IMMAOANGPNK_NetMasterDataManager.HHCJCDFCLOB_Instance.NKEBMCIMJND_Database.FOFADHAENKC_Skill.FFCFHFOIKGB_CenterSkillEnemy;
		}
		else
		{
			skillsList = IMMAOANGPNK_NetMasterDataManager.HHCJCDFCLOB_Instance.NKEBMCIMJND_Database.FOFADHAENKC_Skill.COLCPGFABLP_CenterSkills;
		}
		HBDCPGLAPHH skill = skillsList[CHMOEPNAJOO_SkillInfo.ENMAEBJGEKL_SkillId - 1];
		for(int i = 0; i < 2; i++)
		{
			KFCIIMBBNCD effectInfo = null;
			int skillId = 0;
			if (i == 1)
			{
				if (skill.AKGNPLBDKLN_P2 == 0)
					return;
				skillId = skill.AKGNPLBDKLN_P2;
				effectInfo = KDDDDMMMBHE_GetEffectInfo(IMMAOANGPNK_NetMasterDataManager.HHCJCDFCLOB_Instance.NKEBMCIMJND_Database.FOFADHAENKC_Skill, skill.AKGNPLBDKLN_P2, _GJLFANGDGCL_Target);
			}
			else if(i == 0)
			{
				if(skill.HEKHODDJHAO_P1 != 0)
				{
					skillId = skill.HEKHODDJHAO_P1;
					effectInfo = KDDDDMMMBHE_GetEffectInfo(IMMAOANGPNK_NetMasterDataManager.HHCJCDFCLOB_Instance.NKEBMCIMJND_Database.FOFADHAENKC_Skill, skill.HEKHODDJHAO_P1, _GJLFANGDGCL_Target);
				}
				else
					continue;
			}
			if (effectInfo != null)
			{
				SeriesAttr.Type serie = 0;
				if (AFBMEMCHJCL_MainScene != null && _KKHIDFKKFJE_MusicData != null)
				{
					serie = (SeriesAttr.Type)_KKHIDFKKFJE_MusicData.AIHCEGFANAM_SerieAttr;
					if (serie != CHMOEPNAJOO_SkillInfo.AIHCEGFANAM_SerieAttr)
						serie = 0;
				}
				if (FNIEADNMMIA_CenterSkillCondMatchMusic((CenterSkillCondition.Type)effectInfo.OAFPGJLCNFM_cond, _KKHIDFKKFJE_MusicData, serie))
				{
					if (FLPKCFDANMK_DivaMatchTarget(_DGCJCAHIAPP_Diva, (CenterSkillTarget.Type)effectInfo.GJLFANGDGCL_Target, ABBDKBOIBCG_DivaIdx))
					{
						StatusData st = _HBODCMLFDOB_result.ELFAIDEBLJB;
						if (_GJLFANGDGCL_Target == JNKEEAOKNCI_Skill.MKGJHBAKMBD_SkillType.KBHGPMNGALJ_2_Costume)
							st = _HBODCMLFDOB_result.IMLGBMGIACC;
						KDOFDLIMHJG_ApplySkill(ref st, _DGCJCAHIAPP_Diva.JLJGCBOHJID_Status, _GJLFANGDGCL_Target, skillId, CHMOEPNAJOO_SkillInfo.CNLIAMIIJID_AbilityLevel, _MLAFAACKKBG_Unit);
						if (_GJLFANGDGCL_Target != JNKEEAOKNCI_Skill.MKGJHBAKMBD_SkillType.KBHGPMNGALJ_2_Costume)
						{
							LBBNJAGGCBB_SetBonusFlag(ref _HBODCMLFDOB_result, st);
							if (_GJLFANGDGCL_Target == JNKEEAOKNCI_Skill.MKGJHBAKMBD_SkillType.AIFGINAKBMA_1_EnemySkill)
							{
								GCECPDEOIIN.Clear();
								KDOFDLIMHJG_ApplySkill(ref st, _DGCJCAHIAPP_Diva.JLJGCBOHJID_Status, JNKEEAOKNCI_Skill.MKGJHBAKMBD_SkillType.AIFGINAKBMA_1_EnemySkill, skillId, CHMOEPNAJOO_SkillInfo.CNLIAMIIJID_AbilityLevel, _MLAFAACKKBG_Unit);
								MEICPKJFJOA_SetMalusFlag(ref _HBODCMLFDOB_result, st);
							}
						}
					}
					for (int j = 0; j < _DGCJCAHIAPP_Diva.DJICAKGOGFO_SubSceneIds.Count + 1; j++)
					{
						GCIJNCFDNON_SceneInfo sceneInfo = null;
						if (j == 0)
						{
							sceneInfo = AFBMEMCHJCL_MainScene;
						}
						else if (j == 1)
						{
							sceneInfo = _HAPFNHPFBGD_SubScene1;
						}
						else if (j == 2)
						{
							sceneInfo = JEBHFJEJAKJ_SubScene2;
						}
						if (sceneInfo != null)
						{
							if (FJHLLHFGICG_SceneMatchTarget(sceneInfo, (CenterSkillTarget.Type)effectInfo.GJLFANGDGCL_Target, ABBDKBOIBCG_DivaIdx, j))
							{
								StatusData st = null;
								if (j == 0)
								{
									st = _HBODCMLFDOB_result.BJABFKMIJHB_StatusMainScene;
									if (_GJLFANGDGCL_Target == JNKEEAOKNCI_Skill.MKGJHBAKMBD_SkillType.KBHGPMNGALJ_2_Costume)
										st = _HBODCMLFDOB_result.AJINBLGCBMM_StatusCostumeMainScene;
									KDOFDLIMHJG_ApplySkill(ref st, sceneInfo.CMCKNKKCNDK_status, _GJLFANGDGCL_Target, skillId, CHMOEPNAJOO_SkillInfo.CNLIAMIIJID_AbilityLevel, _MLAFAACKKBG_Unit);
								}
								else
								{
									st = _HBODCMLFDOB_result.OBCPFDNKLMM_StatusSubScenes[j - 1];
									if (_GJLFANGDGCL_Target == JNKEEAOKNCI_Skill.MKGJHBAKMBD_SkillType.KBHGPMNGALJ_2_Costume)
										st = _HBODCMLFDOB_result.FEGNMIGJMDM_CostumeSubScene[j - 1];
									KDOFDLIMHJG_ApplySkill(ref st, sceneInfo.CMCKNKKCNDK_status, _GJLFANGDGCL_Target, skillId, CHMOEPNAJOO_SkillInfo.CNLIAMIIJID_AbilityLevel, _MLAFAACKKBG_Unit);
								}
								if (_GJLFANGDGCL_Target != JNKEEAOKNCI_Skill.MKGJHBAKMBD_SkillType.KBHGPMNGALJ_2_Costume)
								{
									LBBNJAGGCBB_SetBonusFlag(ref _HBODCMLFDOB_result, st);
									if (_GJLFANGDGCL_Target == JNKEEAOKNCI_Skill.MKGJHBAKMBD_SkillType.AIFGINAKBMA_1_EnemySkill)
									{
										FLOHCPIIHEH_WorkStatus.Clear();
										KDOFDLIMHJG_ApplySkill(ref FLOHCPIIHEH_WorkStatus, _DGCJCAHIAPP_Diva.JLJGCBOHJID_Status, JNKEEAOKNCI_Skill.MKGJHBAKMBD_SkillType.AIFGINAKBMA_1_EnemySkill, skillId, CHMOEPNAJOO_SkillInfo.CNLIAMIIJID_AbilityLevel, _MLAFAACKKBG_Unit);
										MEICPKJFJOA_SetMalusFlag(ref _HBODCMLFDOB_result, FLOHCPIIHEH_WorkStatus);
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
	// private static void DALDDNMEMJE(ref EDMIONMCICN _HBODCMLFDOB_result) { }

	// // RVA: 0x10890F4 Offset: 0x10890F4 VA: 0x10890F4
	private static void LBBNJAGGCBB_SetBonusFlag(ref EDMIONMCICN _HBODCMLFDOB_result, StatusData _BALBKJFMDFN_StatusRes)
	{
		if (_BALBKJFMDFN_StatusRes.soul > 0)
			_HBODCMLFDOB_result.LGGLFAECCBK_BonusTypeFlag |= MKHCIKICBOI_ParamFlag.BICPBLMPBPH_1_Soul;
		if (_BALBKJFMDFN_StatusRes.vocal > 0)
			_HBODCMLFDOB_result.LGGLFAECCBK_BonusTypeFlag |= MKHCIKICBOI_ParamFlag.GPCMMGOCPHC_2_Vocal;
		if (_BALBKJFMDFN_StatusRes.charm > 0)
			_HBODCMLFDOB_result.LGGLFAECCBK_BonusTypeFlag |= MKHCIKICBOI_ParamFlag.LGOHMPBLPKA_4_Charm;
		if (_BALBKJFMDFN_StatusRes.life > 0)
			_HBODCMLFDOB_result.LGGLFAECCBK_BonusTypeFlag |= MKHCIKICBOI_ParamFlag.ECHJOKLBHEJ_8_Life;
		if (_BALBKJFMDFN_StatusRes.support > 0)
			_HBODCMLFDOB_result.LGGLFAECCBK_BonusTypeFlag |= MKHCIKICBOI_ParamFlag.AHJNCHAONGN_16_Support;
		if (_BALBKJFMDFN_StatusRes.fold > 0)
			_HBODCMLFDOB_result.LGGLFAECCBK_BonusTypeFlag |= MKHCIKICBOI_ParamFlag.ONBNGGDFAJK_32_Fold;
	}

	// // RVA: 0x1089190 Offset: 0x1089190 VA: 0x1089190
	private static void MEICPKJFJOA_SetMalusFlag(ref EDMIONMCICN _HBODCMLFDOB_result, StatusData _BALBKJFMDFN_StatusRes)
	{
		if (_BALBKJFMDFN_StatusRes.soul < 0)
			_HBODCMLFDOB_result.NOEFMBAIAMP_MalusTypeFlag |= MKHCIKICBOI_ParamFlag.BICPBLMPBPH_1_Soul;
		if (_BALBKJFMDFN_StatusRes.vocal < 0)
			_HBODCMLFDOB_result.NOEFMBAIAMP_MalusTypeFlag |= MKHCIKICBOI_ParamFlag.GPCMMGOCPHC_2_Vocal;
		if (_BALBKJFMDFN_StatusRes.charm < 0)
			_HBODCMLFDOB_result.NOEFMBAIAMP_MalusTypeFlag |= MKHCIKICBOI_ParamFlag.LGOHMPBLPKA_4_Charm;
		if (_BALBKJFMDFN_StatusRes.life < 0)
			_HBODCMLFDOB_result.NOEFMBAIAMP_MalusTypeFlag |= MKHCIKICBOI_ParamFlag.ECHJOKLBHEJ_8_Life;
		if (_BALBKJFMDFN_StatusRes.support < 0)
			_HBODCMLFDOB_result.NOEFMBAIAMP_MalusTypeFlag |= MKHCIKICBOI_ParamFlag.AHJNCHAONGN_16_Support;
		if (_BALBKJFMDFN_StatusRes.fold < 0)
			_HBODCMLFDOB_result.NOEFMBAIAMP_MalusTypeFlag |= MKHCIKICBOI_ParamFlag.ONBNGGDFAJK_32_Fold;
	}

	// // RVA: 0x108897C Offset: 0x108897C VA: 0x108897C
	private static KFCIIMBBNCD KDDDDMMMBHE_GetEffectInfo(JNKEEAOKNCI_Skill FOFADHAENKC_SkillDb, int _BFGNMDGOEID_Pattern/*SkillId*/, JNKEEAOKNCI_Skill.MKGJHBAKMBD_SkillType _GJLFANGDGCL_Target)
	{
		List<KFCIIMBBNCD> infoList;
		if(_BFGNMDGOEID_Pattern/*SkillId*/ > 0)
		{
			if (_GJLFANGDGCL_Target == JNKEEAOKNCI_Skill.MKGJHBAKMBD_SkillType.KBHGPMNGALJ_2_Costume)
			{
				infoList = FOFADHAENKC_SkillDb.EBKAAEDMIBI_CostumeEffectInfo;
			}
			else if (_GJLFANGDGCL_Target == JNKEEAOKNCI_Skill.MKGJHBAKMBD_SkillType.AIFGINAKBMA_1_EnemySkill)
			{
				infoList = FOFADHAENKC_SkillDb.PHPGICHCBPM_EnemyEffectInfo;
			}
			else if (_GJLFANGDGCL_Target == JNKEEAOKNCI_Skill.MKGJHBAKMBD_SkillType.MHKFDBLMOGF_0_Scene)
			{
				infoList = FOFADHAENKC_SkillDb.PEPLECGHBFA_SceneEffectInfo;
			}
			else return null;
			return infoList[_BFGNMDGOEID_Pattern/*SkillId*/ - 1];
		}
		return null;
	}

	// // RVA: 0x1088AC0 Offset: 0x1088AC0 VA: 0x1088AC0
	private static bool FNIEADNMMIA_CenterSkillCondMatchMusic(CenterSkillCondition.Type _FKDOMKHHOCD_Condition, EEDKAACNBBG_MusicData _KKHIDFKKFJE_MusicData, SeriesAttr.Type _AIHCEGFANAM_SerieAttr/* = 0*/)
	{
		if (_FKDOMKHHOCD_Condition == 0)
			return true;
		if (_KKHIDFKKFJE_MusicData == null)
			return false;
		bool res = false;
		switch(_FKDOMKHHOCD_Condition)
		{
			case CenterSkillCondition.Type.MusicAttr_01:
				return _KKHIDFKKFJE_MusicData.FKDCCLPGKDK_JacketAttr == 1;
			case CenterSkillCondition.Type.MusicAttr_02:
				return _KKHIDFKKFJE_MusicData.FKDCCLPGKDK_JacketAttr == 2;
			case CenterSkillCondition.Type.MusicAttr_03:
				return _KKHIDFKKFJE_MusicData.FKDCCLPGKDK_JacketAttr == 3;
			case CenterSkillCondition.Type.MusicAttr_04:
				return _KKHIDFKKFJE_MusicData.FKDCCLPGKDK_JacketAttr == 4;
			case CenterSkillCondition.Type.MusicAttr_05:
				return false;
			case CenterSkillCondition.Type.SeriesAttr_01:
				return _KKHIDFKKFJE_MusicData.AIHCEGFANAM_SerieAttr == 1;
			case CenterSkillCondition.Type.SeriesAttr_02:
				return _KKHIDFKKFJE_MusicData.AIHCEGFANAM_SerieAttr == 2;
			case CenterSkillCondition.Type.SeriesAttr_03:
				return _KKHIDFKKFJE_MusicData.AIHCEGFANAM_SerieAttr == 3;
			case CenterSkillCondition.Type.SeriesAttr_04:
				return _KKHIDFKKFJE_MusicData.AIHCEGFANAM_SerieAttr == 4;
			case CenterSkillCondition.Type.SeriesAttr_05:
				return _KKHIDFKKFJE_MusicData.AIHCEGFANAM_SerieAttr == 5;
			case CenterSkillCondition.Type.SeriesAttr_Scn:
				return _KKHIDFKKFJE_MusicData.AIHCEGFANAM_SerieAttr == (int)_AIHCEGFANAM_SerieAttr;
		}
		return res;
	}

	// // RVA: 0x1088C18 Offset: 0x1088C18 VA: 0x1088C18
	private static bool FLPKCFDANMK_DivaMatchTarget(FFHPBEPOMAK_DivaInfo _FDBOPFEOENF_diva, CenterSkillTarget.Type _GJLFANGDGCL_Target, int ABBDKBOIBCG_DivaIdx)
	{
		switch(_GJLFANGDGCL_Target)
		{
			case CenterSkillTarget.Type.AllTeam:
			case CenterSkillTarget.Type.AllDiva:
				return true;
			default:
				return false;
			case CenterSkillTarget.Type.CenterDiva:
				return ABBDKBOIBCG_DivaIdx == 0;
			case CenterSkillTarget.Type.SeriresAttr1:
				return _FDBOPFEOENF_diva.AIHCEGFANAM_SerieAttr == 1;
			case CenterSkillTarget.Type.SeriresAttr2:
				return _FDBOPFEOENF_diva.AIHCEGFANAM_SerieAttr == 2;
			case CenterSkillTarget.Type.SeriresAttr3:
				return _FDBOPFEOENF_diva.AIHCEGFANAM_SerieAttr == 3;
			case CenterSkillTarget.Type.SeriresAttr4:
				return _FDBOPFEOENF_diva.AIHCEGFANAM_SerieAttr == 4;
		}
	}

	// // RVA: 0x108922C Offset: 0x108922C VA: 0x108922C
	private static bool FJHLLHFGICG_SceneMatchTarget(GCIJNCFDNON_SceneInfo _COIODGJDJEJ_scene, CenterSkillTarget.Type _GJLFANGDGCL_Target, int ABBDKBOIBCG_DivaIdx, int HBMFKPPOPMK_SceneIdx)
	{
		switch(_GJLFANGDGCL_Target)
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
				return _COIODGJDJEJ_scene.JGJFIJOCPAG_SceneAttr == 1;
			case CenterSkillTarget.Type.GameAttrRed:
				return _COIODGJDJEJ_scene.JGJFIJOCPAG_SceneAttr == 2;
			case CenterSkillTarget.Type.GameAttrBlue:
				return _COIODGJDJEJ_scene.JGJFIJOCPAG_SceneAttr == 3;
			case CenterSkillTarget.Type.SeriresAttr1:
				return (int)_COIODGJDJEJ_scene.AIHCEGFANAM_SerieAttr == 1;
			case CenterSkillTarget.Type.SeriresAttr2:
				return (int)_COIODGJDJEJ_scene.AIHCEGFANAM_SerieAttr == 2;
			case CenterSkillTarget.Type.SeriresAttr3:
				return (int)_COIODGJDJEJ_scene.AIHCEGFANAM_SerieAttr == 3;
			case CenterSkillTarget.Type.SeriresAttr4:
				return (int)_COIODGJDJEJ_scene.AIHCEGFANAM_SerieAttr == 4;
		}
	}

	// // RVA: 0x1088D0C Offset: 0x1088D0C VA: 0x1088D0C
	private static void KDOFDLIMHJG_ApplySkill(ref StatusData _BALBKJFMDFN_StatusRes, StatusData _JLJGCBOHJID_Status, JNKEEAOKNCI_Skill.MKGJHBAKMBD_SkillType _GJLFANGDGCL_Target, int PGLJHBODOHN_SkillId, int CIEOBFIIPLD_Level, JLKEOGLJNOD_TeamInfo _MLAFAACKKBG_Unit)
	{
		List<KFCIIMBBNCD> skillsInfoList = null;
		if(_GJLFANGDGCL_Target == JNKEEAOKNCI_Skill.MKGJHBAKMBD_SkillType.KBHGPMNGALJ_2_Costume)
		{
			skillsInfoList = IMMAOANGPNK_NetMasterDataManager.HHCJCDFCLOB_Instance.NKEBMCIMJND_Database.FOFADHAENKC_Skill.EBKAAEDMIBI_CostumeEffectInfo;
		}
		else if (_GJLFANGDGCL_Target == JNKEEAOKNCI_Skill.MKGJHBAKMBD_SkillType.AIFGINAKBMA_1_EnemySkill)
		{
			skillsInfoList = IMMAOANGPNK_NetMasterDataManager.HHCJCDFCLOB_Instance.NKEBMCIMJND_Database.FOFADHAENKC_Skill.PHPGICHCBPM_EnemyEffectInfo;
		}
		else if (_GJLFANGDGCL_Target == JNKEEAOKNCI_Skill.MKGJHBAKMBD_SkillType.MHKFDBLMOGF_0_Scene)
		{
			skillsInfoList = IMMAOANGPNK_NetMasterDataManager.HHCJCDFCLOB_Instance.NKEBMCIMJND_Database.FOFADHAENKC_Skill.PEPLECGHBFA_SceneEffectInfo;
		}
		KFCIIMBBNCD sk = skillsInfoList[PGLJHBODOHN_SkillId - 1];
		if(sk != null)
		{
			float modifierValue = sk.KCOHMHFBDKF_Value1[CIEOBFIIPLD_Level - 1];
			if (sk.BBFKKANELFP_EffectType == 1)
			{
				FOKHDKJJOFB_EffectByNumDiva fo = IMMAOANGPNK_NetMasterDataManager.HHCJCDFCLOB_Instance.NKEBMCIMJND_Database.FOFADHAENKC_Skill.EFJFIIPIMOO_GetEffectValue(sk.KCOHMHFBDKF_Value1[CIEOBFIIPLD_Level - 1]);
				modifierValue = fo.NANNGLGOFKH_value[CIEOBFIIPLD_Level - 1] * FPJIKEFIJOL_GetNumValidSceneForDivas(fo.FDBOPFEOENF_diva, _MLAFAACKKBG_Unit) + fo.NNDBJGDFEEM_Min;
			}
			CHJHPJHNCEB_ApplyModifiers(ref _BALBKJFMDFN_StatusRes, _JLJGCBOHJID_Status, sk.INDDJNMPONH_type, modifierValue);
		}
	}

	// // RVA: 0x10896DC Offset: 0x10896DC VA: 0x10896DC
	private static void CHJHPJHNCEB_ApplyModifiers(ref StatusData _BALBKJFMDFN_StatusRes, StatusData _JLJGCBOHJID_Status, byte _INDDJNMPONH_type, float _NANNGLGOFKH_value)
	{
		switch(_INDDJNMPONH_type)
		{
			case 1:
				_BALBKJFMDFN_StatusRes.life += (int)(_JLJGCBOHJID_Status.life * _NANNGLGOFKH_value);
				_BALBKJFMDFN_StatusRes.soul += (int)(_JLJGCBOHJID_Status.soul * _NANNGLGOFKH_value);
				_BALBKJFMDFN_StatusRes.vocal += (int)(_JLJGCBOHJID_Status.vocal * _NANNGLGOFKH_value);
				_BALBKJFMDFN_StatusRes.charm += (int)(_JLJGCBOHJID_Status.charm * _NANNGLGOFKH_value);
				_BALBKJFMDFN_StatusRes.support += (int)(_JLJGCBOHJID_Status.support * _NANNGLGOFKH_value);
				_BALBKJFMDFN_StatusRes.fold += (int)(_JLJGCBOHJID_Status.fold * _NANNGLGOFKH_value);
				break;
			case 2:
				_BALBKJFMDFN_StatusRes.life += (int)(_JLJGCBOHJID_Status.life * _NANNGLGOFKH_value);
				break;
			case 3:
				_BALBKJFMDFN_StatusRes.soul += (int)(_JLJGCBOHJID_Status.soul * _NANNGLGOFKH_value);
				_BALBKJFMDFN_StatusRes.vocal += (int)(_JLJGCBOHJID_Status.vocal * _NANNGLGOFKH_value);
				_BALBKJFMDFN_StatusRes.charm += (int)(_JLJGCBOHJID_Status.charm * _NANNGLGOFKH_value);
				break;
			case 4:
				_BALBKJFMDFN_StatusRes.soul += (int)(_JLJGCBOHJID_Status.soul * _NANNGLGOFKH_value);
				break;
			case 5:
				_BALBKJFMDFN_StatusRes.vocal += (int)(_JLJGCBOHJID_Status.vocal * _NANNGLGOFKH_value);
				break;
			case 6:
				_BALBKJFMDFN_StatusRes.charm += (int)(_JLJGCBOHJID_Status.charm * _NANNGLGOFKH_value);
				break;
			case 7:
				_BALBKJFMDFN_StatusRes.soul -= (int)(_JLJGCBOHJID_Status.soul * _NANNGLGOFKH_value);
				break;
			case 8:
				_BALBKJFMDFN_StatusRes.vocal -= (int)(_JLJGCBOHJID_Status.vocal * _NANNGLGOFKH_value);
				break;
			case 9:
				_BALBKJFMDFN_StatusRes.charm -= (int)(_JLJGCBOHJID_Status.charm * _NANNGLGOFKH_value);
				break;
			case 10:
				_BALBKJFMDFN_StatusRes.soul -= (int)(_JLJGCBOHJID_Status.soul * _NANNGLGOFKH_value);
				_BALBKJFMDFN_StatusRes.vocal -= (int)(_JLJGCBOHJID_Status.vocal * _NANNGLGOFKH_value);
				break;
			case 11:
				_BALBKJFMDFN_StatusRes.soul -= (int)(_JLJGCBOHJID_Status.soul * _NANNGLGOFKH_value);
				_BALBKJFMDFN_StatusRes.charm -= (int)(_JLJGCBOHJID_Status.charm * _NANNGLGOFKH_value);
				break;
			case 12:
				_BALBKJFMDFN_StatusRes.vocal -= (int)(_JLJGCBOHJID_Status.vocal * _NANNGLGOFKH_value);
				_BALBKJFMDFN_StatusRes.charm -= (int)(_JLJGCBOHJID_Status.charm * _NANNGLGOFKH_value);
				break;
			case 13:
				_BALBKJFMDFN_StatusRes.fold -= (int)(_JLJGCBOHJID_Status.fold * _NANNGLGOFKH_value);
				break;
			case 14:
				_BALBKJFMDFN_StatusRes.support += (int)(_JLJGCBOHJID_Status.support * _NANNGLGOFKH_value);
				break;
			case 15:
				_BALBKJFMDFN_StatusRes.fold += (int)(_JLJGCBOHJID_Status.fold * _NANNGLGOFKH_value);
				break;
		}
	}

	// // RVA: 0x1087F4C Offset: 0x1087F4C VA: 0x1087F4C
	public static bool OJNOJNEKBKH(int LNGOBGPDBAG, int GMPOGAFIAEF)
    {
        return GMPOGAFIAEF == 4 || GMPOGAFIAEF == LNGOBGPDBAG;
    }

	// // RVA: 0x10868E8 Offset: 0x10868E8 VA: 0x10868E8
	private static void NJNBELLEGCN(ref CFHDKAFLNEP _HBODCMLFDOB_result, JLKEOGLJNOD_TeamInfo _MLAFAACKKBG_Unit, DFKGGBMFFGB_PlayerInfo _AHEFHIMGIBI_PlayerData, EEDKAACNBBG_MusicData _KKHIDFKKFJE_MusicData, EAJCBFGKKFA_FriendInfo _PCEGKKLKFNO_FriendData, EJKBKMBJMGL_EnemyData KDOLMBEAGCI)
	{
		_HBODCMLFDOB_result.JCHLONCMPAJ_Clear();
		int[,] data = CIOECGOMILE_NetPlayerDataManager.HHCJCDFCLOB_Instance.AHEFHIMGIBI_PlayerData.BEKHNNCGIEL_Costume.GODGHFDMAHF_GetRateBySupportPlate();
		if(data != null)
		{
			List<List<GCIJNCFDNON_SceneInfo>> ll = new List<List<GCIJNCFDNON_SceneInfo>>();
			for(int i = 0; i < LCLCCHLDNHJ_Costume.GFIKOEEBIJP; i++)
			{
				ll.Add(new List<GCIJNCFDNON_SceneInfo>(_AHEFHIMGIBI_PlayerData.OPIBAPEGCLA_Scenes.Count));
			}
			bool b = false;
			for(int i = 0; i < _AHEFHIMGIBI_PlayerData.OPIBAPEGCLA_Scenes.Count; i++)
			{
				GCIJNCFDNON_SceneInfo sceneInfo = _AHEFHIMGIBI_PlayerData.OPIBAPEGCLA_Scenes[i];
				int enabled = IMMAOANGPNK_NetMasterDataManager.HHCJCDFCLOB_Instance.NKEBMCIMJND_Database.ECNHDEHADGL_Scene.CDENCMNHNGA_table[sceneInfo.BCCHOBPJJKE_SceneId - 1].PPEGAKEIEGM_Enabled;
				if(enabled == 2)
				{
					if(sceneInfo.FJODMPGPDDD_Unlocked && !sceneInfo.MCCIFLKCNKO_Feed)
					{
						bool isSub = false;
						for(int j = 0; j < _MLAFAACKKBG_Unit.BCJEAJPLGMB_MainDivas.Count; j++)
						{
							FFHPBEPOMAK_DivaInfo divaInfo = _MLAFAACKKBG_Unit.BCJEAJPLGMB_MainDivas[j];
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
				NJNBELLEGCN(ref _HBODCMLFDOB_result, data, ll, _AHEFHIMGIBI_PlayerData, _MLAFAACKKBG_Unit, _KKHIDFKKFJE_MusicData, _PCEGKKLKFNO_FriendData, KDOLMBEAGCI);
			}
			else
			{
				for(int i = 0; i < data.GetLength(0); i++)
				{
					for(int j = 0; j < data.GetLength(1); j++)
					{
						_HBODCMLFDOB_result.KOGBMDOONFA_Info[i, j].ADKDHKMPMHP_rate = data[i, j];
					}					
				}
			}
		}
	}

	// // RVA: 0x1089E00 Offset: 0x1089E00 VA: 0x1089E00
	public static void NJNBELLEGCN(ref CFHDKAFLNEP _HBODCMLFDOB_result, int[,] EDAJDLJHBKP, List<List<GCIJNCFDNON_SceneInfo>> _OPIBAPEGCLA_Scenes, DFKGGBMFFGB_PlayerInfo _AHEFHIMGIBI_PlayerData, JLKEOGLJNOD_TeamInfo _MLAFAACKKBG_Unit, EEDKAACNBBG_MusicData _KKHIDFKKFJE_MusicData, EAJCBFGKKFA_FriendInfo _PCEGKKLKFNO_FriendData, EJKBKMBJMGL_EnemyData KDOLMBEAGCI)
	{
		GCIJNCFDNON_SceneInfo sceneInfo = null;
		if(_MLAFAACKKBG_Unit != null)
		{
			FFHPBEPOMAK_DivaInfo divaInfo = _MLAFAACKKBG_Unit.BCJEAJPLGMB_MainDivas[0];
			if(divaInfo != null)
			{
				if(divaInfo.FGFIBOBAPIA_SceneId != 0)
				{
					sceneInfo = _AHEFHIMGIBI_PlayerData.OPIBAPEGCLA_Scenes[divaInfo.FGFIBOBAPIA_SceneId - 1];
					if(_KKHIDFKKFJE_MusicData == null)
					{
						if(sceneInfo.MEOOLHNNMHL_GetCenterSkillId(false, 0, 0) == 0)
							sceneInfo = null;
					}
					else
					{
						if(sceneInfo.MEOOLHNNMHL_GetCenterSkillId(false, _KKHIDFKKFJE_MusicData.FKDCCLPGKDK_JacketAttr, _KKHIDFKKFJE_MusicData.AIHCEGFANAM_SerieAttr) == 0)
							sceneInfo = null;
					}
				}
			}
		}
		GCIJNCFDNON_SceneInfo sceneInfo2 = null;
		if(_PCEGKKLKFNO_FriendData != null)
		{
			sceneInfo2 = _PCEGKKLKFNO_FriendData.KHGKPKDBMOH_GetAssistScene();
			if(sceneInfo2 != null)
			{
				if(_KKHIDFKKFJE_MusicData == null)
				{
					if(sceneInfo2.MEOOLHNNMHL_GetCenterSkillId(false, 0, 0) == 0)
						sceneInfo2 = null;
				}
				else
				{
					if(sceneInfo2.MEOOLHNNMHL_GetCenterSkillId(false, _KKHIDFKKFJE_MusicData.FKDCCLPGKDK_JacketAttr, _KKHIDFKKFJE_MusicData.AIHCEGFANAM_SerieAttr) == 0)
						sceneInfo2 = null;
				}
			}
		}
		CFHDKAFLNEP.OCNHGDCPJDG[,] data = new CFHDKAFLNEP.OCNHGDCPJDG[3, 3];
		StatusData st = new StatusData();
		StatusData st2 = new StatusData();
		for(int i = 0; i < LCLCCHLDNHJ_Costume.GFIKOEEBIJP; i++)
		{
			if(_OPIBAPEGCLA_Scenes[i].Count < 1)
			{
				for(int j = 0; j < EDAJDLJHBKP.GetLength(1); j++)
				{
					_HBODCMLFDOB_result.KOGBMDOONFA_Info[i, j].ADKDHKMPMHP_rate = EDAJDLJHBKP[i, j];
				}
			}
			else
			{
				bool attrMatch = false;
				if(_KKHIDFKKFJE_MusicData != null)
				{
					attrMatch = (_KKHIDFKKFJE_MusicData.FKDCCLPGKDK_JacketAttr == 4 || _KKHIDFKKFJE_MusicData.FKDCCLPGKDK_JacketAttr == i + 1);
				}
				for(int j = 0; j < 3; j++)
				{
					_OPIBAPEGCLA_Scenes[i].Sort(MOGECDOLPPL[j]);
					int val = Mathf.Min(3, _OPIBAPEGCLA_Scenes[i].Count);
					int val2 = EDAJDLJHBKP[i, j];
					if(val  < 1)
					{
						val = 0;
						val--;
						for(int k = val + 1; k < 3; k++)
						{
							data[j, k].PBPOLELIPJI_Id = 0;
							data[j, k].IFFKEMEOFAE_EvolveId = 0;
							data[j, k].ADKDHKMPMHP_rate = val2;
							data[j, k].OEOIHIIIMCK_add = 0;
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
							GCIJNCFDNON_SceneInfo sceneInfo3 = _OPIBAPEGCLA_Scenes[i][k];
							data[j, k].PBPOLELIPJI_Id = sceneInfo3.BCCHOBPJJKE_SceneId;
							data[j, k].IFFKEMEOFAE_EvolveId = sceneInfo3.CGIELKDLHGE_GetEvolveId();
							data[j, k].ADKDHKMPMHP_rate = val2;
							data[j, k].OGHIOHAACIB_IsKira = sceneInfo3.MBMFJILMOBP_IsKira();
							st.Copy(sceneInfo3.CMCKNKKCNDK_status);
							bool c = attrMatch;
							int e = 0;
							if(sceneInfo != null)
							{
								int a = sceneInfo.MEOOLHNNMHL_GetCenterSkillId(false, _KKHIDFKKFJE_MusicData != null ? _KKHIDFKKFJE_MusicData.FKDCCLPGKDK_JacketAttr : 0, _KKHIDFKKFJE_MusicData != null ? _KKHIDFKKFJE_MusicData.AIHCEGFANAM_SerieAttr : 0);
								st2.Clear();
								MHPBLAEDJOC(ref st2, sceneInfo3, _KKHIDFKKFJE_MusicData, a, sceneInfo.DDEDANKHHPN_SkillLevel, _MLAFAACKKBG_Unit);
								e = HDLKMMHKOKE[j].Invoke(st2);
								c |= e > 0;
							}
							if(sceneInfo2 != null)
							{
								int a = sceneInfo2.MEOOLHNNMHL_GetCenterSkillId(false, _KKHIDFKKFJE_MusicData != null ? _KKHIDFKKFJE_MusicData.FKDCCLPGKDK_JacketAttr : 0, _KKHIDFKKFJE_MusicData != null ? _KKHIDFKKFJE_MusicData.AIHCEGFANAM_SerieAttr : 0);
								st2.Clear();
								MHPBLAEDJOC(ref st2, sceneInfo3, _KKHIDFKKFJE_MusicData, a, sceneInfo2.DDEDANKHHPN_SkillLevel, _MLAFAACKKBG_Unit);
								int d = HDLKMMHKOKE[j].Invoke(st2);
								e += d;
								c |= d > 0;
							}
							bool g = false;
							if(KDOLMBEAGCI != null && KDOLMBEAGCI.PDHCABLLJPB_CenterSkillId != 0)
							{
								HBDCPGLAPHH h = IMMAOANGPNK_NetMasterDataManager.HHCJCDFCLOB_Instance.NKEBMCIMJND_Database.FOFADHAENKC_Skill.FFCFHFOIKGB_CenterSkillEnemy[KDOLMBEAGCI.PDHCABLLJPB_CenterSkillId - 1];
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
									KDOFDLIMHJG_ApplySkill(ref st2, sceneInfo3.CMCKNKKCNDK_status, JNKEEAOKNCI_Skill.MKGJHBAKMBD_SkillType.AIFGINAKBMA_1_EnemySkill, aa, 1, _MLAFAACKKBG_Unit);
									int d = HDLKMMHKOKE[j].Invoke(st2);
									e += d;
									c |= d > 0;
									TodoLogger.LogError(TodoLogger.ToCheck, "Check val");
									g |= d < 0; // ??
								}
							}
							int d_ = HDLKMMHKOKE[j].Invoke(sceneInfo3.CMCKNKKCNDK_status);
							int bb = attrMatch ? 1 : 0;
							if(attrMatch)
								bb = d_ * 30;
							data[j, k].OEOIHIIIMCK_add = (((bb + e) / 100 + d_) * val2) / 100;
							data[j, k].KHDDPKHPJID = (d_ * val2) / 100;
							data[j, k].ALJGIPAGDJI = (attrMatch ? ((bb / 100) * val2) / 100 : 0);
							bool cc = false;
							if(c)
							{
								if(data[j, k].OEOIHIIIMCK_add > 0)
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
							data[j, k].ADKDHKMPMHP_rate = val2;
							data[j, k].OEOIHIIIMCK_add = 0;
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
								int v = data[0, j].OEOIHIIIMCK_add + data[1, j].OEOIHIIIMCK_add + data[2, j].OEOIHIIIMCK_add;
								if(maxAdd < v)
								{
									_HBODCMLFDOB_result.KOGBMDOONFA_Info[i, 0] = data[0, j];
									_HBODCMLFDOB_result.KOGBMDOONFA_Info[i, 1] = data[1, k];
									_HBODCMLFDOB_result.KOGBMDOONFA_Info[i, 2] = data[2, l];
									maxAdd = v;
								}
							}
						}
					}
				}
				for(int j = 0; j < 3; j++)
				{
					HOBOLJEFDFF[j].Invoke(_HBODCMLFDOB_result.CMCKNKKCNDK_status, _HBODCMLFDOB_result.KOGBMDOONFA_Info[i, j].OEOIHIIIMCK_add);
				}
			}
		}
	}

	// // RVA: 0x108BAF0 Offset: 0x108BAF0 VA: 0x108BAF0
	private static void MHPBLAEDJOC(ref StatusData _BALBKJFMDFN_StatusRes, GCIJNCFDNON_SceneInfo _COIODGJDJEJ_scene, EEDKAACNBBG_MusicData _KKHIDFKKFJE_MusicData, int _ENMAEBJGEKL_SkillId, int _CNLIAMIIJID_AbilityLevel, JLKEOGLJNOD_TeamInfo _MLAFAACKKBG_Unit)
	{
		HBDCPGLAPHH skill = IMMAOANGPNK_NetMasterDataManager.HHCJCDFCLOB_Instance.NKEBMCIMJND_Database.FOFADHAENKC_Skill.COLCPGFABLP_CenterSkills[_ENMAEBJGEKL_SkillId - 1];
		for(int i = 0; i < 2; i++)
		{
			int skillId = 0;
			KFCIIMBBNCD a = null;
			if (i == 1)
			{
				if (skill.AKGNPLBDKLN_P2 == 0)
					return;
				a = KDDDDMMMBHE_GetEffectInfo(IMMAOANGPNK_NetMasterDataManager.HHCJCDFCLOB_Instance.NKEBMCIMJND_Database.FOFADHAENKC_Skill, skill.AKGNPLBDKLN_P2, JNKEEAOKNCI_Skill.MKGJHBAKMBD_SkillType.MHKFDBLMOGF_0_Scene);
				skillId = skill.AKGNPLBDKLN_P2;
			}
			else if(i == 0)
			{
				if(skill.HEKHODDJHAO_P1 != 0)
				{
					a = KDDDDMMMBHE_GetEffectInfo(IMMAOANGPNK_NetMasterDataManager.HHCJCDFCLOB_Instance.NKEBMCIMJND_Database.FOFADHAENKC_Skill, skill.HEKHODDJHAO_P1, JNKEEAOKNCI_Skill.MKGJHBAKMBD_SkillType.MHKFDBLMOGF_0_Scene);
					skillId = skill.HEKHODDJHAO_P1;
				}
			}
			if(a != null)
			{
				if(FNIEADNMMIA_CenterSkillCondMatchMusic((CenterSkillCondition.Type)a.OAFPGJLCNFM_cond, _KKHIDFKKFJE_MusicData, _COIODGJDJEJ_scene.AIHCEGFANAM_SerieAttr))
				{
					if(FJHLLHFGICG_SceneMatchTarget(_COIODGJDJEJ_scene, (CenterSkillTarget.Type)a.GJLFANGDGCL_Target, -1, -1))
					{
						KDOFDLIMHJG_ApplySkill(ref _BALBKJFMDFN_StatusRes, _COIODGJDJEJ_scene.CMCKNKKCNDK_status, JNKEEAOKNCI_Skill.MKGJHBAKMBD_SkillType.MHKFDBLMOGF_0_Scene, skillId, _CNLIAMIIJID_AbilityLevel, _MLAFAACKKBG_Unit);
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
					if((IMMAOANGPNK_NetMasterDataManager.HHCJCDFCLOB_Instance.NKEBMCIMJND_Database.ECNHDEHADGL_Scene.CDENCMNHNGA_table[infoDiva.FGFIBOBAPIA_SceneId - 1].AOLIJKMIJJE_Diva & NCNFMHDKAPN_DivaFlag) != 0)
						total++;
				}
				for(int j = 0; j < infoDiva.DJICAKGOGFO_SubSceneIds.Count; i++)
				{
					if(infoDiva.DJICAKGOGFO_SubSceneIds[j] > 0)
					{
						if((IMMAOANGPNK_NetMasterDataManager.HHCJCDFCLOB_Instance.NKEBMCIMJND_Database.ECNHDEHADGL_Scene.CDENCMNHNGA_table[infoDiva.DJICAKGOGFO_SubSceneIds[j] - 1].AOLIJKMIJJE_Diva & NCNFMHDKAPN_DivaFlag) != 0)
							total++;
					}
				}
			}
		}
		return total;
	}

	// // RVA: 0x108C0FC Offset: 0x108C0FC VA: 0x108C0FC
	public static int NDNOLJACLLC_GetScore(NOJENDEDECD_ScoreType _HLANCDFJFIA_CurrentGauge)
	{
		return OOPMCKOCEFM_Scores[(int)_HLANCDFJFIA_CurrentGauge];
	}

	// // RVA: 0x108C1C0 Offset: 0x108C1C0 VA: 0x108C1C0
	public static int EPNPGMCGJKB(Difficulty.Type AKNELONELJK_difficulty, bool _NGKGFBLFEGH_IsLine6)
	{
		if(_NGKGFBLFEGH_IsLine6)
		{
			return DNJCAKPKNDP_ScoreRatioByDifficulty[(int)AKNELONELJK_difficulty + 3];
		}
		else
		{
			return DNJCAKPKNDP_ScoreRatioByDifficulty[(int)AKNELONELJK_difficulty];
		}
	}

	// // RVA: 0x108C2EC Offset: 0x108C2EC VA: 0x108C2EC
	public static float GPCKPNJGANO_GetRank(ResultScoreRank.Type _FJOLNJLLJEJ_rank)
	{
		return LKBGHCIKIOA_RankScore[(int)_FJOLNJLLJEJ_rank];
	}

	// // RVA: 0x108C3B0 Offset: 0x108C3B0 VA: 0x108C3B0
	public static void EFCNOOFFMIL(DFKGGBMFFGB_PlayerInfo _DJLNOAMJECI_PlayerData, EAJCBFGKKFA_FriendInfo ALOBLKOHIKD_FriendData, EEDKAACNBBG_MusicData GMFMMDAKENC_MusicData, EJKBKMBJMGL_EnemyData BGJGFPPDNEP_EnemyData, Difficulty.Type AKNELONELJK_difficulty, bool PDLCNDBOMAN_IsLine6, bool _CMEOKJMCEBH_IsGoDiva)
	{
		EFCNOOFFMIL(_DJLNOAMJECI_PlayerData, _DJLNOAMJECI_PlayerData.DPLBHAIKPGL_GetTeam(_CMEOKJMCEBH_IsGoDiva), ALOBLKOHIKD_FriendData, GMFMMDAKENC_MusicData, BGJGFPPDNEP_EnemyData, AKNELONELJK_difficulty, PDLCNDBOMAN_IsLine6);
	}

	// // RVA: 0x108C488 Offset: 0x108C488 VA: 0x108C488
	public static void EFCNOOFFMIL(DFKGGBMFFGB_PlayerInfo _DJLNOAMJECI_PlayerData, JLKEOGLJNOD_TeamInfo HJJNDDPGIML_Team, EAJCBFGKKFA_FriendInfo ALOBLKOHIKD_FriendData, EEDKAACNBBG_MusicData GMFMMDAKENC_MusicData, EJKBKMBJMGL_EnemyData BGJGFPPDNEP_EnemyData, Difficulty.Type AKNELONELJK_difficulty, bool PDLCNDBOMAN_IsLine6)
	{
		for (int i = 0; i < OOPMCKOCEFM_Scores.Length; i++)
		{
			OOPMCKOCEFM_Scores[i] = 0;
		}
		CFHDKAFLNEP calcData = new CFHDKAFLNEP();
		ADDHLABEFKH resultTarget = null;
		if (GMFMMDAKENC_MusicData is IBJAKJJICBC)
		{
			resultTarget = IMMAOANGPNK_NetMasterDataManager.HHCJCDFCLOB_Instance.NKEBMCIMJND_Database.IBPAFKKEKNK_Music.GEAANLPDJBP_FreeMusicData[(GMFMMDAKENC_MusicData as IBJAKJJICBC).GHBPLHBNMBK_FreeMusicId - 1].EMJCHPDJHEI(PDLCNDBOMAN_IsLine6, (int)AKNELONELJK_difficulty);
		}
		else if (GMFMMDAKENC_MusicData is LIEJFHMGNIA)
		{
			resultTarget = IMMAOANGPNK_NetMasterDataManager.HHCJCDFCLOB_Instance.NKEBMCIMJND_Database.IBPAFKKEKNK_Music.FLMLJIKBIMJ_GetStoryMusicData((GMFMMDAKENC_MusicData as LIEJFHMGNIA).KLCIIHKFPPO_StoryMusicId).COGKJBAFBKN_ByDiff[(int)AKNELONELJK_difficulty];
		}
		int musicId = GMFMMDAKENC_MusicData.DLAEJOBELBH_MusicId;
		EONOEHOKBEB_Music musicInfo = IMMAOANGPNK_NetMasterDataManager.HHCJCDFCLOB_Instance.NKEBMCIMJND_Database.IBPAFKKEKNK_Music.IAJLOELFHKC_GetMusicInfo(musicId);
		KLBKPANJCPL_Score score = IMMAOANGPNK_NetMasterDataManager.HHCJCDFCLOB_Instance.NKEBMCIMJND_Database.IBPAFKKEKNK_Music.ALJFMLEJEHH_GetMusicScore(musicInfo.KKPAHLMJKIH_WavId, musicInfo.BKJGCEOEPFB_VariationId, (int)AKNELONELJK_difficulty, PDLCNDBOMAN_IsLine6, true);
		int progress = IMMAOANGPNK_NetMasterDataManager.HHCJCDFCLOB_Instance.NKEBMCIMJND_Database.HNMMJINNHII_Game.ADBELGIDIEN_GetProgress(score.ANAJIAENLNB_lv, PDLCNDBOMAN_IsLine6);
		int baseScore = CBILJEAECKP_GetBaseScore(_DJLNOAMJECI_PlayerData, ALOBLKOHIKD_FriendData, BGJGFPPDNEP_EnemyData, GMFMMDAKENC_MusicData, AKNELONELJK_difficulty, PDLCNDBOMAN_IsLine6, score.ANAJIAENLNB_lv, progress, HJJNDDPGIML_Team);
		//gauge_01_base
		OOPMCKOCEFM_Scores[(int)NOJENDEDECD_ScoreType.HNGJDMNPMNP_0_BaseScore] = baseScore;
		//gauge_05_shien / plate
		OOPMCKOCEFM_Scores[(int)NOJENDEDECD_ScoreType.GJDKJOHIEFF_4_PlateScore] = MHIKPDIJKJO(_DJLNOAMJECI_PlayerData, ALOBLKOHIKD_FriendData, GMFMMDAKENC_MusicData, BGJGFPPDNEP_EnemyData, ref calcData, progress, HJJNDDPGIML_Team);
		//gauge_02_isyou
		OOPMCKOCEFM_Scores[(int)NOJENDEDECD_ScoreType.KBHGPMNGALJ_1_Costume] = CHCGGEPAAOE(_DJLNOAMJECI_PlayerData, GMFMMDAKENC_MusicData, ALOBLKOHIKD_FriendData, BGJGFPPDNEP_EnemyData, progress, HJJNDDPGIML_Team);
		//gauge_03_zokusei / ?? bonus
		OOPMCKOCEFM_Scores[(int)NOJENDEDECD_ScoreType.AJIDOFDBIDL_2_MatchMusicScore] = DONJDICAMJB(_DJLNOAMJECI_PlayerData, ALOBLKOHIKD_FriendData, GMFMMDAKENC_MusicData, BGJGFPPDNEP_EnemyData, ref calcData, progress, HJJNDDPGIML_Team);
		EDMIONMCICN d = new EDMIONMCICN();
		//gauge_04_cskill
		OOPMCKOCEFM_Scores[(int)NOJENDEDECD_ScoreType.BMMPEPDFICC_5_CenterSkillScore] = DBHEBCCLIJG(ref d, _DJLNOAMJECI_PlayerData, ALOBLKOHIKD_FriendData, GMFMMDAKENC_MusicData, null, ref calcData, progress, false, HJJNDDPGIML_Team);
		bool e = false;
		bool g = false;
		bool f = MODGPFEPLIP(ref d, _DJLNOAMJECI_PlayerData, ALOBLKOHIKD_FriendData, GMFMMDAKENC_MusicData, score, AKNELONELJK_difficulty, PDLCNDBOMAN_IsLine6, out e, out g, HJJNDDPGIML_Team);
		//gauge_06_lskill
		OOPMCKOCEFM_Scores[(int)NOJENDEDECD_ScoreType.CPJOGHCLENG_6_LiveSkillScore] = LKGBAIANMLE(baseScore, _DJLNOAMJECI_PlayerData, GMFMMDAKENC_MusicData, score, e, f, g, HJJNDDPGIML_Team);
		//gauge_07_askill
		OOPMCKOCEFM_Scores[(int)NOJENDEDECD_ScoreType.NKPLJNILBFP_7_ASkillScore] = BPPIFIAGLBI(baseScore, _DJLNOAMJECI_PlayerData, GMFMMDAKENC_MusicData, score, HJJNDDPGIML_Team);
		//gauge_08_combo
		OOPMCKOCEFM_Scores[(int)NOJENDEDECD_ScoreType.NLAGKLDCBAG_3_Combo] = AFBHKBGLMHG * baseScore / 1000;
		if (f)
		{
			//gauge_09_notes
			OOPMCKOCEFM_Scores[(int)NOJENDEDECD_ScoreType.GGOOOIKELDH_8_NotesScore] = CBIIKLGPILB(baseScore, GMFMMDAKENC_MusicData, _DJLNOAMJECI_PlayerData, AKNELONELJK_difficulty, score, PDLCNDBOMAN_IsLine6, g ? 1 : 0, HJJNDDPGIML_Team);
		}
		//gauge_10_leaf
		OOPMCKOCEFM_Scores[(int)NOJENDEDECD_ScoreType.OPCNHIMPGCE_9_LeafScore] = OPKNHONFIOG(baseScore, _DJLNOAMJECI_PlayerData, ALOBLKOHIKD_FriendData, GMFMMDAKENC_MusicData, score, e, f, g, HJJNDDPGIML_Team);
		int total = 0;
		for (int i = 0; i < OOPMCKOCEFM_Scores.Length; i++)
		{
			total += OOPMCKOCEFM_Scores[i];
		}
		OOPMCKOCEFM_Scores[(int)NOJENDEDECD_ScoreType.CPJOGHCLENG_6_LiveSkillScore] += NGCOIOANNPA(total, baseScore, _DJLNOAMJECI_PlayerData, GMFMMDAKENC_MusicData, score, HJJNDDPGIML_Team);
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
				DNJCAKPKNDP_ScoreRatioByDifficulty.Add(IMMAOANGPNK_NetMasterDataManager.HHCJCDFCLOB_Instance.NKEBMCIMJND_Database.HNMMJINNHII_Game.LPJLEHAJADA_GetIntParam(DALGMKEOFLN_ScoreRatioNameByDiff[i], 200000));
			}
		}
		for(int i = 0; i < 4; i++)
		{
			LKBGHCIKIOA_RankScore[i + 1] = resultTarget.KNIFCANOHOC_score[i] * 1.0f / DNJCAKPKNDP_ScoreRatioByDifficulty[(int)AKNELONELJK_difficulty];
		}
		int h = EPNPGMCGJKB(AKNELONELJK_difficulty, PDLCNDBOMAN_IsLine6);
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
				DNJCAKPKNDP_ScoreRatioByDifficulty.Add(IMMAOANGPNK_NetMasterDataManager.HHCJCDFCLOB_Instance.NKEBMCIMJND_Database.HNMMJINNHII_Game.LPJLEHAJADA_GetIntParam(DALGMKEOFLN_ScoreRatioNameByDiff[i], 200000));
			}
		}
		for(int i = 0; i < LKBGHCIKIOA_RankScore.Length; i++)
		{
			LKBGHCIKIOA_RankScore[i] = 10;
		}
		FDLECNKJCGG_GaugeRatio = 1;
	}

	// // RVA: 0x108D788 Offset: 0x108D788 VA: 0x108D788
	private static int CBILJEAECKP_GetBaseScore(DFKGGBMFFGB_PlayerInfo _DJLNOAMJECI_PlayerData, EAJCBFGKKFA_FriendInfo ALOBLKOHIKD_FriendData, EJKBKMBJMGL_EnemyData BGJGFPPDNEP_EnemyData, EEDKAACNBBG_MusicData GMFMMDAKENC_MusicData, Difficulty.Type AKNELONELJK_difficulty, bool _GBNOALJPOBM_IsLine6, int _BAKLKJLPLOJ_MusicLevel, int _DHIPGHBJLIL_coef, JLKEOGLJNOD_TeamInfo _HEDKFICAPIJ_Team)
	{
		EDMIONMCICN data = new EDMIONMCICN();
		data.OBKGEDCKHHE_Init();
		CFHDKAFLNEP data2 = new CFHDKAFLNEP();
		data2.OBKGEDCKHHE_Init();
		int scoreWithEnemy = DBHEBCCLIJG(ref data, _DJLNOAMJECI_PlayerData, ALOBLKOHIKD_FriendData, GMFMMDAKENC_MusicData, BGJGFPPDNEP_EnemyData, ref data2, _DHIPGHBJLIL_coef, true, _HEDKFICAPIJ_Team);
		int scoreWithoutEnemy = DBHEBCCLIJG(ref data, _DJLNOAMJECI_PlayerData, ALOBLKOHIKD_FriendData, GMFMMDAKENC_MusicData, null, ref data2, _DHIPGHBJLIL_coef, true, _HEDKFICAPIJ_Team);
		int total = 0;
		for (int i = 0; i < _HEDKFICAPIJ_Team.BCJEAJPLGMB_MainDivas.Count; i++)
		{
			FFHPBEPOMAK_DivaInfo divaInfo = _HEDKFICAPIJ_Team.BCJEAJPLGMB_MainDivas[i];
			if (divaInfo != null)
			{
				StatusData sdata = divaInfo.CMCKNKKCNDK_status;
				total += sdata.soul + sdata.vocal + sdata.charm;
				if(divaInfo.FGFIBOBAPIA_SceneId > 0)
				{
					GCIJNCFDNON_SceneInfo sceneInfo = _DJLNOAMJECI_PlayerData.OPIBAPEGCLA_Scenes[divaInfo.FGFIBOBAPIA_SceneId - 1];
					StatusData sdata2 = sceneInfo.CMCKNKKCNDK_status;
					total += sdata2.soul + sdata2.vocal + sdata2.charm;
				}
				for(int j = 0; j < divaInfo.DJICAKGOGFO_SubSceneIds.Count; j++)
				{
					if (divaInfo.DJICAKGOGFO_SubSceneIds[j] > 0)
					{
						GCIJNCFDNON_SceneInfo sceneInfo = _DJLNOAMJECI_PlayerData.OPIBAPEGCLA_Scenes[divaInfo.DJICAKGOGFO_SubSceneIds[j] - 1];
						StatusData sdata2 = sceneInfo.CMCKNKKCNDK_status;
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
				StatusData sdata = data3.CMCKNKKCNDK_status;
				total += sdata.soul + sdata.vocal + sdata.charm;
			}
		}
		int c = IMMAOANGPNK_NetMasterDataManager.HHCJCDFCLOB_Instance.NKEBMCIMJND_Database.HNMMJINNHII_Game.ADBELGIDIEN_GetProgress(_BAKLKJLPLOJ_MusicLevel, _GBNOALJPOBM_IsLine6);
		return (scoreWithEnemy - scoreWithoutEnemy) + (int)(c * total / 1000.0f);
	}

	// // RVA: 0x108E2F8 Offset: 0x108E2F8 VA: 0x108E2F8
	private static int CHCGGEPAAOE(DFKGGBMFFGB_PlayerInfo AHEFHIMGIBI_PlayerData, EEDKAACNBBG_MusicData _KKHIDFKKFJE_MusicData, EAJCBFGKKFA_FriendInfo _PCEGKKLKFNO_FriendData, EJKBKMBJMGL_EnemyData KDOLMBEAGCI_EnemyData, int _DHIPGHBJLIL_coef, JLKEOGLJNOD_TeamInfo _HEDKFICAPIJ_Team)
	{
		EDMIONMCICN data = new EDMIONMCICN();
		data.OBKGEDCKHHE_Init();
		int total = 0;
		for(int i = 0; i < _HEDKFICAPIJ_Team.BCJEAJPLGMB_MainDivas.Count; i++)
		{
			FFHPBEPOMAK_DivaInfo divaInfo = _HEDKFICAPIJ_Team.BCJEAJPLGMB_MainDivas[i];
			if(divaInfo != null)
			{
				AECDJDIJJKD_ApplySkills(ref data, divaInfo, _HEDKFICAPIJ_Team, AHEFHIMGIBI_PlayerData, _KKHIDFKKFJE_MusicData, _PCEGKKLKFNO_FriendData, KDOLMBEAGCI_EnemyData);
				data.IMLOCECFHGK(ref FLOHCPIIHEH_WorkStatus);
				total += FLOHCPIIHEH_WorkStatus.soul + FLOHCPIIHEH_WorkStatus.vocal + FLOHCPIIHEH_WorkStatus.charm;
			}
		}
		return (total * _DHIPGHBJLIL_coef) / 1000;
	}

	// // RVA: 0x108E584 Offset: 0x108E584 VA: 0x108E584
	private static int DONJDICAMJB(DFKGGBMFFGB_PlayerInfo _DJLNOAMJECI_PlayerData, EAJCBFGKKFA_FriendInfo ALOBLKOHIKD_FriendData, EEDKAACNBBG_MusicData GMFMMDAKENC_MusicData, EJKBKMBJMGL_EnemyData BGJGFPPDNEP_EnemyData, ref CFHDKAFLNEP LNMECJDKFDN, int _DHIPGHBJLIL_coef, JLKEOGLJNOD_TeamInfo _HEDKFICAPIJ_Team)
	{
		EDMIONMCICN data = new EDMIONMCICN();
		data.OBKGEDCKHHE_Init();
		int total = 0;
		for (int i = 0; i < _HEDKFICAPIJ_Team.BCJEAJPLGMB_MainDivas.Count; i++)
		{
			FFHPBEPOMAK_DivaInfo divaInfo = _HEDKFICAPIJ_Team.BCJEAJPLGMB_MainDivas[i];
			if (divaInfo != null)
			{
				AECDJDIJJKD_ApplySkills(ref data, divaInfo, _HEDKFICAPIJ_Team, _DJLNOAMJECI_PlayerData, GMFMMDAKENC_MusicData, ALOBLKOHIKD_FriendData, BGJGFPPDNEP_EnemyData);
				for(int j = 0; j < data.MCBLDOECHEK_MatchMusicAttrStatus.Length; j++)
				{
					total += data.MCBLDOECHEK_MatchMusicAttrStatus[i].PJCKMKEJCEL_Total();
				}
			}
		}
		if(ALOBLKOHIKD_FriendData != null)
		{
			NIPJMNDBCNF(ref data, _HEDKFICAPIJ_Team, ALOBLKOHIKD_FriendData, _DJLNOAMJECI_PlayerData, GMFMMDAKENC_MusicData, BGJGFPPDNEP_EnemyData);
			for (int j = 0; j < data.MCBLDOECHEK_MatchMusicAttrStatus.Length; j++)
			{
				total += data.MCBLDOECHEK_MatchMusicAttrStatus[0].PJCKMKEJCEL_Total();
			}
		}
		for(int i = 0; i < LCLCCHLDNHJ_Costume.GFIKOEEBIJP; i++)
		{
			for(int j = 0; j < 3; j++)
			{
				total += LNMECJDKFDN.KOGBMDOONFA_Info[i, j].ALJGIPAGDJI;
			}
		}
		return (total * _DHIPGHBJLIL_coef) / 1000;
	}

	// // RVA: 0x108E93C Offset: 0x108E93C VA: 0x108E93C
	private static int DBHEBCCLIJG(ref EDMIONMCICN _HBODCMLFDOB_result, DFKGGBMFFGB_PlayerInfo _DJLNOAMJECI_PlayerData, EAJCBFGKKFA_FriendInfo ALOBLKOHIKD_FriendData, EEDKAACNBBG_MusicData GMFMMDAKENC_MusicData, EJKBKMBJMGL_EnemyData BGJGFPPDNEP_EnemyData, ref CFHDKAFLNEP LNMECJDKFDN, int _DHIPGHBJLIL_coef, bool CCPIGKONMMH, JLKEOGLJNOD_TeamInfo _HEDKFICAPIJ_Team)
	{
		_HBODCMLFDOB_result.OBKGEDCKHHE_Init();
		int val = 0;
		for(int i = 0; i < _HEDKFICAPIJ_Team.BCJEAJPLGMB_MainDivas.Count; i++)
		{
			FFHPBEPOMAK_DivaInfo divaInfo = _HEDKFICAPIJ_Team.BCJEAJPLGMB_MainDivas[i];
			if(divaInfo != null)
			{
				AECDJDIJJKD_ApplySkills(ref _HBODCMLFDOB_result, divaInfo, _HEDKFICAPIJ_Team, _DJLNOAMJECI_PlayerData, GMFMMDAKENC_MusicData, ALOBLKOHIKD_FriendData, BGJGFPPDNEP_EnemyData);
				_HBODCMLFDOB_result.BEDINMCPENB_SetupStatus(ref FLOHCPIIHEH_WorkStatus);
				int s = 0;
				for(int j = 0; j < _HBODCMLFDOB_result.MCBLDOECHEK_MatchMusicAttrStatus.Length; j++)
				{
					s += _HBODCMLFDOB_result.MCBLDOECHEK_MatchMusicAttrStatus[j].PJCKMKEJCEL_Total();
				}
				val = (val - s) + FLOHCPIIHEH_WorkStatus.Total;
			}
		}
		if(ALOBLKOHIKD_FriendData != null)
		{
			NIPJMNDBCNF(ref _HBODCMLFDOB_result, _HEDKFICAPIJ_Team, ALOBLKOHIKD_FriendData, _DJLNOAMJECI_PlayerData, GMFMMDAKENC_MusicData, BGJGFPPDNEP_EnemyData);
			StatusData st = _HBODCMLFDOB_result.BJABFKMIJHB_StatusMainScene;
			val = (st.soul + val + st.vocal + st.charm) - _HBODCMLFDOB_result.MCBLDOECHEK_MatchMusicAttrStatus[0].PJCKMKEJCEL_Total();
		}
		if(!CCPIGKONMMH)
		{
			for(int i = 0; i < LCLCCHLDNHJ_Costume.GFIKOEEBIJP; i++)
			{
				for(int j = 0; j < 3; j++)
				{
					val += LNMECJDKFDN.KOGBMDOONFA_Info[i,j].HIPODBKKJFL;
				}
			}
		}
		return (val * _DHIPGHBJLIL_coef) / 1000;
	}

	// // RVA: 0x108DEA8 Offset: 0x108DEA8 VA: 0x108DEA8
	private static int MHIKPDIJKJO(DFKGGBMFFGB_PlayerInfo _DJLNOAMJECI_PlayerData, EAJCBFGKKFA_FriendInfo ALOBLKOHIKD_FriendData, EEDKAACNBBG_MusicData GMFMMDAKENC_MusicData, EJKBKMBJMGL_EnemyData BGJGFPPDNEP_EnemyData, ref CFHDKAFLNEP _HBODCMLFDOB_result, int _DHIPGHBJLIL_coef, JLKEOGLJNOD_TeamInfo _HEDKFICAPIJ_Team)
	{
		_HBODCMLFDOB_result.OBKGEDCKHHE_Init();
		NJNBELLEGCN(ref _HBODCMLFDOB_result, _HEDKFICAPIJ_Team, _DJLNOAMJECI_PlayerData, GMFMMDAKENC_MusicData, ALOBLKOHIKD_FriendData, BGJGFPPDNEP_EnemyData);
		int val = 0;
		for(int i = 0; i < LCLCCHLDNHJ_Costume.GFIKOEEBIJP; i++)
		{
			for(int j = 0; j < 3; j++)
			{
				val += _HBODCMLFDOB_result.KOGBMDOONFA_Info[i, j].KHDDPKHPJID;
			}
		}
		CFHDKAFLNEP data = new CFHDKAFLNEP();
		data.OBKGEDCKHHE_Init();
		NJNBELLEGCN(ref data, _HEDKFICAPIJ_Team, _DJLNOAMJECI_PlayerData, GMFMMDAKENC_MusicData, ALOBLKOHIKD_FriendData, BGJGFPPDNEP_EnemyData);
		int val2 = 0;
		for(int i = 0; i < LCLCCHLDNHJ_Costume.GFIKOEEBIJP; i++)
		{
			for(int j = 0; j < 3; j++)
			{
				val2 += _HBODCMLFDOB_result.KOGBMDOONFA_Info[i, j].HIPODBKKJFL;
			}
		}
		NJNBELLEGCN(ref data, _HEDKFICAPIJ_Team, _DJLNOAMJECI_PlayerData, GMFMMDAKENC_MusicData, ALOBLKOHIKD_FriendData, null);
		int val3 = 0;
		for(int i = 0; i < LCLCCHLDNHJ_Costume.GFIKOEEBIJP; i++)
		{
			for(int j = 0; j < 3; j++)
			{
				val3 += _HBODCMLFDOB_result.KOGBMDOONFA_Info[i, j].HIPODBKKJFL;
			}
		}
		val3 *= _DHIPGHBJLIL_coef;
		return (val2 * _DHIPGHBJLIL_coef) / 1000 + (val * _DHIPGHBJLIL_coef) / 1000 - val3 / 1000;
	}

	// // RVA: 0x1092FB8 Offset: 0x1092FB8 VA: 0x1092FB8
	private static int FILPDDHMKEJ_GetLiveSkillId(GCIJNCFDNON_SceneInfo LAPAEBEIAFK, EEDKAACNBBG_MusicData _GMFMMDAKENC_MusicData, FFHPBEPOMAK_DivaInfo JCFNFJJKPAM)
	{
		if(LAPAEBEIAFK != null)
		{
			int skillId = LAPAEBEIAFK.FILPDDHMKEJ_GetLiveSkillId(false, _GMFMMDAKENC_MusicData != null ? _GMFMMDAKENC_MusicData.FKDCCLPGKDK_JacketAttr : 0, _GMFMMDAKENC_MusicData != null ? _GMFMMDAKENC_MusicData.AIHCEGFANAM_SerieAttr : 0);
			if(skillId > 0)
			{
				if(LAPAEBEIAFK.DCLLIDMKNGO_IsDivaCompatible(JCFNFJJKPAM.AHHJLDLAPAN_DivaId))
				{
					PPGHMBNIAEC skillInfo = IMMAOANGPNK_NetMasterDataManager.HHCJCDFCLOB_Instance.NKEBMCIMJND_Database.FOFADHAENKC_Skill.PNJMFKFGIML_LiveSkills[skillId - 1];
					if(skillInfo.AANDPLGPDEI() && !skillInfo.HDPIEILADDH(_GMFMMDAKENC_MusicData.DLAEJOBELBH_MusicId))
					{
						return 0;
					}
					if(skillInfo.HCGDJAFINMH() && !skillInfo.OEJNKFONOGJ(_GMFMMDAKENC_MusicData.FKDCCLPGKDK_JacketAttr))
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
	private static int OPGMFCHDEDF(int _KPIIIEGGPIB_LS, GCIJNCFDNON_SceneInfo _COIODGJDJEJ_scene, int FLKGCONIFEE, int KHDDPKHPJID, DFKGGBMFFGB_PlayerInfo _DJLNOAMJECI_PlayerData, EEDKAACNBBG_MusicData _GMFMMDAKENC_MusicData, KLBKPANJCPL_Score POMOLHBFAPM, bool _KIFJKGDBDBH_lucky, JLKEOGLJNOD_TeamInfo _HEDKFICAPIJ_Team, FFHPBEPOMAK_DivaInfo NENDFGDMJDN)
	{
		if (_KPIIIEGGPIB_LS < 1)
			return 0;
		PPGHMBNIAEC skillInfo = IMMAOANGPNK_NetMasterDataManager.HHCJCDFCLOB_Instance.NKEBMCIMJND_Database.FOFADHAENKC_Skill.PNJMFKFGIML_LiveSkills[_KPIIIEGGPIB_LS - 1];
		int res = 0;
		for(int i = 0; i < skillInfo.EGLDFPILJLG_SkillBuffEffect.Length; i++)
		{
			int a = CKNDJNOFFGP_GetSkillValue(skillInfo, i, _COIODGJDJEJ_scene.AADFFCIDJCB_LiveSkillLevel, NENDFGDMJDN);
			int b = IGDGGMIMLDN(a, _DJLNOAMJECI_PlayerData, _GMFMMDAKENC_MusicData, (SkillBuffEffect.Type)skillInfo.EGLDFPILJLG_SkillBuffEffect[i], skillInfo.FLJHGGKIOJH_SkillType, POMOLHBFAPM, _HEDKFICAPIJ_Team);
			int c = MEAHJKCBGFE(FLKGCONIFEE, KHDDPKHPJID, _DJLNOAMJECI_PlayerData, _GMFMMDAKENC_MusicData, (SkillBuffEffect.Type)skillInfo.EGLDFPILJLG_SkillBuffEffect[i], a + b, (SkillDuration.Type)skillInfo.FPMFEKIPFPI_DurationType[i], skillInfo.PHAGNOHBMCM_DurationByIndexAndLevel[_COIODGJDJEJ_scene.AADFFCIDJCB_LiveSkillLevel - 1, i], (SkillTrigger.Type)skillInfo.CPNAGMFCIJK_TriggerType, skillInfo.LFGFBMJNBKN_ConfigValue[_COIODGJDJEJ_scene.AADFFCIDJCB_LiveSkillLevel - 1], skillInfo.ELEPHBOKIGK_Limit[0], POMOLHBFAPM, _KIFJKGDBDBH_lucky);
			res += c;
		}
		return res;
	}

	// // RVA: 0x108F96C Offset: 0x108F96C VA: 0x108F96C
	private static int LKGBAIANMLE(int KHDDPKHPJID, DFKGGBMFFGB_PlayerInfo _DJLNOAMJECI_PlayerData, EEDKAACNBBG_MusicData GMFMMDAKENC_MusicData, KLBKPANJCPL_Score POMOLHBFAPM_Score, bool _HGEKDNNJAAC_AwakenDivaMode, bool _OOOGNIPJMDE_HadDivaMode, bool _OHLCKPIMMFH_ValkyrieMode, JLKEOGLJNOD_TeamInfo _HEDKFICAPIJ_Team)
	{
		int res = 0;
		for (int i = 0; i < _HEDKFICAPIJ_Team.BCJEAJPLGMB_MainDivas.Count; i++)
		{
			FFHPBEPOMAK_DivaInfo divaInfo = _HEDKFICAPIJ_Team.BCJEAJPLGMB_MainDivas[i];
			if(divaInfo != null)
			{
				if (i != 0 && divaInfo.FGFIBOBAPIA_SceneId > 0)
				{
					GCIJNCFDNON_SceneInfo sceneInfo = _DJLNOAMJECI_PlayerData.OPIBAPEGCLA_Scenes[divaInfo.FGFIBOBAPIA_SceneId - 1];
					if (sceneInfo != null)
					{
						int skillId = sceneInfo.FILPDDHMKEJ_GetLiveSkillId(false, GMFMMDAKENC_MusicData != null ? GMFMMDAKENC_MusicData.FKDCCLPGKDK_JacketAttr : 0, GMFMMDAKENC_MusicData != null ? GMFMMDAKENC_MusicData.AIHCEGFANAM_SerieAttr : 0);
						if (skillId > 0 && sceneInfo.DCLLIDMKNGO_IsDivaCompatible(divaInfo.AHHJLDLAPAN_DivaId))
						{
							PPGHMBNIAEC info = IMMAOANGPNK_NetMasterDataManager.HHCJCDFCLOB_Instance.NKEBMCIMJND_Database.FOFADHAENKC_Skill.PNJMFKFGIML_LiveSkills[skillId - 1];
							if (!info.AANDPLGPDEI() || info.HDPIEILADDH(GMFMMDAKENC_MusicData.DLAEJOBELBH_MusicId))
							{
								if (!info.HCGDJAFINMH() || info.OEJNKFONOGJ(GMFMMDAKENC_MusicData.FKDCCLPGKDK_JacketAttr))
								{
									for (int j = 0; j < info.EGLDFPILJLG_SkillBuffEffect.Length; j++)
									{
										int a = CKNDJNOFFGP_GetSkillValue(info, j, sceneInfo.AADFFCIDJCB_LiveSkillLevel, divaInfo);
										int b = IGDGGMIMLDN(a, _DJLNOAMJECI_PlayerData, GMFMMDAKENC_MusicData, (SkillBuffEffect.Type)info.EGLDFPILJLG_SkillBuffEffect[j], info.FLJHGGKIOJH_SkillType, POMOLHBFAPM_Score, _HEDKFICAPIJ_Team);
										int c = CPPANAJNEDJ(KHDDPKHPJID, _DJLNOAMJECI_PlayerData, GMFMMDAKENC_MusicData, (SkillBuffEffect.Type)info.EGLDFPILJLG_SkillBuffEffect[j], b + sceneInfo.AADFFCIDJCB_LiveSkillLevel, (SkillDuration.Type)info.FPMFEKIPFPI_DurationType[j], info.PHAGNOHBMCM_DurationByIndexAndLevel[sceneInfo.AADFFCIDJCB_LiveSkillLevel - 1, j], (SkillTrigger.Type)info.CPNAGMFCIJK_TriggerType, info.LFGFBMJNBKN_ConfigValue[sceneInfo.AADFFCIDJCB_LiveSkillLevel - 1], POMOLHBFAPM_Score, _HGEKDNNJAAC_AwakenDivaMode, _OOOGNIPJMDE_HadDivaMode, _OHLCKPIMMFH_ValkyrieMode);
										int d = MCKHJBNJFJH(KHDDPKHPJID, _DJLNOAMJECI_PlayerData, GMFMMDAKENC_MusicData, (SkillBuffEffect.Type)info.EGLDFPILJLG_SkillBuffEffect[j], b + sceneInfo.AADFFCIDJCB_LiveSkillLevel, (SkillDuration.Type)info.FPMFEKIPFPI_DurationType[j], info.PHAGNOHBMCM_DurationByIndexAndLevel[sceneInfo.AADFFCIDJCB_LiveSkillLevel - 1, j], (SkillTrigger.Type)info.CPNAGMFCIJK_TriggerType, sceneInfo.AADFFCIDJCB_LiveSkillLevel, POMOLHBFAPM_Score, _HGEKDNNJAAC_AwakenDivaMode, false);
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
						GCIJNCFDNON_SceneInfo sceneInfo = _DJLNOAMJECI_PlayerData.OPIBAPEGCLA_Scenes[divaInfo.DJICAKGOGFO_SubSceneIds[k] - 1];
						if (sceneInfo != null)
						{
							int skillId = sceneInfo.FILPDDHMKEJ_GetLiveSkillId(false, GMFMMDAKENC_MusicData != null ? GMFMMDAKENC_MusicData.FKDCCLPGKDK_JacketAttr : 0, GMFMMDAKENC_MusicData != null ? GMFMMDAKENC_MusicData.AIHCEGFANAM_SerieAttr : 0);
							if (skillId > 0 && sceneInfo.DCLLIDMKNGO_IsDivaCompatible(divaInfo.AHHJLDLAPAN_DivaId))
							{
								PPGHMBNIAEC info = IMMAOANGPNK_NetMasterDataManager.HHCJCDFCLOB_Instance.NKEBMCIMJND_Database.FOFADHAENKC_Skill.PNJMFKFGIML_LiveSkills[skillId - 1];
								if (!info.AANDPLGPDEI() || info.HDPIEILADDH(GMFMMDAKENC_MusicData.DLAEJOBELBH_MusicId))
								{
									if (!info.HCGDJAFINMH() || info.OEJNKFONOGJ(GMFMMDAKENC_MusicData.FKDCCLPGKDK_JacketAttr))
									{
										for (int j = 0; j < info.EGLDFPILJLG_SkillBuffEffect.Length; j++)
										{
											int a = CKNDJNOFFGP_GetSkillValue(info, j, sceneInfo.AADFFCIDJCB_LiveSkillLevel, divaInfo);
											int b = IGDGGMIMLDN(a, _DJLNOAMJECI_PlayerData, GMFMMDAKENC_MusicData, (SkillBuffEffect.Type)info.EGLDFPILJLG_SkillBuffEffect[j], info.FLJHGGKIOJH_SkillType, POMOLHBFAPM_Score, _HEDKFICAPIJ_Team);
											int c = CPPANAJNEDJ(KHDDPKHPJID, _DJLNOAMJECI_PlayerData, GMFMMDAKENC_MusicData, (SkillBuffEffect.Type)info.EGLDFPILJLG_SkillBuffEffect[j], b + sceneInfo.AADFFCIDJCB_LiveSkillLevel, (SkillDuration.Type)info.FPMFEKIPFPI_DurationType[j], info.PHAGNOHBMCM_DurationByIndexAndLevel[sceneInfo.AADFFCIDJCB_LiveSkillLevel - 1, j], (SkillTrigger.Type)info.CPNAGMFCIJK_TriggerType, info.LFGFBMJNBKN_ConfigValue[sceneInfo.AADFFCIDJCB_LiveSkillLevel - 1], POMOLHBFAPM_Score, _HGEKDNNJAAC_AwakenDivaMode, _OOOGNIPJMDE_HadDivaMode, _OHLCKPIMMFH_ValkyrieMode);
											int d = MCKHJBNJFJH(KHDDPKHPJID, _DJLNOAMJECI_PlayerData, GMFMMDAKENC_MusicData, (SkillBuffEffect.Type)info.EGLDFPILJLG_SkillBuffEffect[j], b + sceneInfo.AADFFCIDJCB_LiveSkillLevel, (SkillDuration.Type)info.FPMFEKIPFPI_DurationType[j], info.PHAGNOHBMCM_DurationByIndexAndLevel[sceneInfo.AADFFCIDJCB_LiveSkillLevel - 1, j], (SkillTrigger.Type)info.CPNAGMFCIJK_TriggerType, sceneInfo.AADFFCIDJCB_LiveSkillLevel, POMOLHBFAPM_Score, _HGEKDNNJAAC_AwakenDivaMode, false);
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
	private static int NGCOIOANNPA(int FLKGCONIFEE, int KHDDPKHPJID, DFKGGBMFFGB_PlayerInfo _DJLNOAMJECI_PlayerData, EEDKAACNBBG_MusicData GMFMMDAKENC_MusicData, KLBKPANJCPL_Score POMOLHBFAPM_Score, JLKEOGLJNOD_TeamInfo _HEDKFICAPIJ_Team)
	{
		int res = 0;
		for(int i = 0; i < _HEDKFICAPIJ_Team.BCJEAJPLGMB_MainDivas.Count; i++)
		{
			FFHPBEPOMAK_DivaInfo divaInfo = _HEDKFICAPIJ_Team.BCJEAJPLGMB_MainDivas[i];
			if(divaInfo != null)
			{
				if(i != 0 && divaInfo.FGFIBOBAPIA_SceneId > 0)
				{
					GCIJNCFDNON_SceneInfo sceneInfo = _DJLNOAMJECI_PlayerData.OPIBAPEGCLA_Scenes[divaInfo.FGFIBOBAPIA_SceneId - 1];
					res += OPGMFCHDEDF(FILPDDHMKEJ_GetLiveSkillId(sceneInfo, GMFMMDAKENC_MusicData, divaInfo), sceneInfo, FLKGCONIFEE, KHDDPKHPJID, _DJLNOAMJECI_PlayerData, GMFMMDAKENC_MusicData, POMOLHBFAPM_Score, false, _HEDKFICAPIJ_Team, divaInfo);
				}
				for(int j = 0; j < divaInfo.DJICAKGOGFO_SubSceneIds.Count; j++)
				{
					if (divaInfo.DJICAKGOGFO_SubSceneIds[j] > 0)
					{
						GCIJNCFDNON_SceneInfo sceneInfo = _DJLNOAMJECI_PlayerData.OPIBAPEGCLA_Scenes[divaInfo.DJICAKGOGFO_SubSceneIds[j] - 1];
						res += OPGMFCHDEDF(FILPDDHMKEJ_GetLiveSkillId(sceneInfo, GMFMMDAKENC_MusicData, divaInfo), sceneInfo, FLKGCONIFEE, KHDDPKHPJID, _DJLNOAMJECI_PlayerData, GMFMMDAKENC_MusicData, POMOLHBFAPM_Score, false, _HEDKFICAPIJ_Team, divaInfo);
					}
				}
			}
		}
		return res;
	}

	// // RVA: 0x10908A8 Offset: 0x10908A8 VA: 0x10908A8
	private static int BPPIFIAGLBI(int KHDDPKHPJID, DFKGGBMFFGB_PlayerInfo _DJLNOAMJECI_PlayerData, EEDKAACNBBG_MusicData GMFMMDAKENC_MusicData, KLBKPANJCPL_Score POMOLHBFAPM_Score, JLKEOGLJNOD_TeamInfo _HEDKFICAPIJ_Team)
	{
		int res = 0;
		FFHPBEPOMAK_DivaInfo divaInfo = _HEDKFICAPIJ_Team.BCJEAJPLGMB_MainDivas[0];
		if(divaInfo != null)
		{
			if(divaInfo.FGFIBOBAPIA_SceneId > 0)
			{
				GCIJNCFDNON_SceneInfo sceneInfo = _DJLNOAMJECI_PlayerData.OPIBAPEGCLA_Scenes[divaInfo.FGFIBOBAPIA_SceneId - 1];
				if (sceneInfo.HGONFBDIBPM_ActiveSkillId < 1)
					return 0;
				CDNKOFIELMK skillInfo = IMMAOANGPNK_NetMasterDataManager.HHCJCDFCLOB_Instance.NKEBMCIMJND_Database.FOFADHAENKC_Skill.PABCHCAAEAA_ActiveSkills[sceneInfo.HGONFBDIBPM_ActiveSkillId - 1];
				for(int i = 0; i < skillInfo.EGLDFPILJLG_SkillBuffEffect.Length; i++)
				{
					int a = CPPANAJNEDJ(KHDDPKHPJID, _DJLNOAMJECI_PlayerData, GMFMMDAKENC_MusicData, (SkillBuffEffect.Type)skillInfo.EGLDFPILJLG_SkillBuffEffect[i], skillInfo.NKGHBKFMFCI_BuffValue[sceneInfo.AADFFCIDJCB_LiveSkillLevel - 1, i], (SkillDuration.Type)skillInfo.FPMFEKIPFPI_DurationType[i], skillInfo.PHAGNOHBMCM_DurationByIndexAndLevel[sceneInfo.AADFFCIDJCB_LiveSkillLevel - 1, i], SkillTrigger.Type.None, 0, POMOLHBFAPM_Score, false, false, false);
					int b = MCKHJBNJFJH(KHDDPKHPJID, _DJLNOAMJECI_PlayerData, GMFMMDAKENC_MusicData, (SkillBuffEffect.Type)skillInfo.EGLDFPILJLG_SkillBuffEffect[i], skillInfo.NKGHBKFMFCI_BuffValue[sceneInfo.AADFFCIDJCB_LiveSkillLevel - 1, i], (SkillDuration.Type)skillInfo.FPMFEKIPFPI_DurationType[i], skillInfo.PHAGNOHBMCM_DurationByIndexAndLevel[sceneInfo.AADFFCIDJCB_LiveSkillLevel - 1, i], SkillTrigger.Type.None, 0, POMOLHBFAPM_Score, true, false);
					res += b + a;
				}
			}
		}
		return res;
	}

	// // RVA: 0x1090E60 Offset: 0x1090E60 VA: 0x1090E60
	private static int CBIIKLGPILB(int KHDDPKHPJID, EEDKAACNBBG_MusicData GMFMMDAKENC_MusicData, DFKGGBMFFGB_PlayerInfo _DJLNOAMJECI_PlayerData, Difficulty.Type AKNELONELJK_difficulty, KLBKPANJCPL_Score POMOLHBFAPM_Score, bool GBNOALJPOBM_IsLine6, int _BAKLKJLPLOJ_MusicLevel, JLKEOGLJNOD_TeamInfo _HEDKFICAPIJ_Team)
	{
		int res = 0;
		if (GMFMMDAKENC_MusicData != null)
		{
			if(GMFMMDAKENC_MusicData is IBJAKJJICBC)
			{
				KEODKEGFDLD_FreeMusicInfo musicInfo = IMMAOANGPNK_NetMasterDataManager.HHCJCDFCLOB_Instance.NKEBMCIMJND_Database.IBPAFKKEKNK_Music.NOBCLJIAMLC_GetFreeMusicData((GMFMMDAKENC_MusicData as IBJAKJJICBC).GHBPLHBNMBK_FreeMusicId);
				short[] vals = GBNOALJPOBM_IsLine6 ? musicInfo.DPJDHKIIJIJ_SpNotesByDiff6Line : musicInfo.OCOGIADDNDN_SpNotes;
				if (vals[(int)AKNELONELJK_difficulty] < 1)
					res = 0;
				else
				{
					KLJCBKMHKNK k = IMMAOANGPNK_NetMasterDataManager.HHCJCDFCLOB_Instance.NKEBMCIMJND_Database.HNMMJINNHII_Game.BBFNPHGDCOF(vals[(int)AKNELONELJK_difficulty]);
					EGLJKICMCPG e = k.GCINIJEMHFK_Get(KLJCBKMHKNK.HHMPIIILOLD_ModeType.CBHCEDGAGHL_3_AwakenDiva/*3*/);
					int a = IMMAOANGPNK_NetMasterDataManager.HHCJCDFCLOB_Instance.NKEBMCIMJND_Database.HNMMJINNHII_Game.GAHIBKLEDBF((int)AKNELONELJK_difficulty, GBNOALJPOBM_IsLine6);
					int b = (int)Mathf.Clamp(e.PHGLKBPLFDH_rmax / 100.0f * POMOLHBFAPM_Score.JJBOEMOJPEC_DivaNote, e.MPPANPOOIIB_NMin, e.GKPPCFMBANO_NMax);
					res = 0;
					int c = POMOLHBFAPM_Score.JJBOEMOJPEC_DivaNote;
					if (c < b)
						b = c;
					if(e.JNNKKPNGPAA(SpecialNoteAttribute.Type.HighScore) != 0)
					{
						int numSpNoteExpected = 0;
						for(int i = 0; i < _HEDKFICAPIJ_Team.BCJEAJPLGMB_MainDivas.Count; i++)
						{
							FFHPBEPOMAK_DivaInfo divaInfo = _HEDKFICAPIJ_Team.BCJEAJPLGMB_MainDivas[i];
							if(divaInfo != null)
							{
								if(divaInfo.FGFIBOBAPIA_SceneId > 0)
								{
									GCIJNCFDNON_SceneInfo sceneInfo = _DJLNOAMJECI_PlayerData.OPIBAPEGCLA_Scenes[divaInfo.FGFIBOBAPIA_SceneId - 1];
									numSpNoteExpected += sceneInfo.CMCKNKKCNDK_status.spNoteExpected[2];
								}
								for(int j = 0; j < divaInfo.DJICAKGOGFO_SubSceneIds.Count; j++)
								{
									if (divaInfo.DJICAKGOGFO_SubSceneIds[j] > 0)
									{
										GCIJNCFDNON_SceneInfo sceneInfo = _DJLNOAMJECI_PlayerData.OPIBAPEGCLA_Scenes[divaInfo.DJICAKGOGFO_SubSceneIds[j] - 1];
										numSpNoteExpected += sceneInfo.CMCKNKKCNDK_status.spNoteExpected[2];
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
	private static int OPKNHONFIOG(int KHDDPKHPJID, DFKGGBMFFGB_PlayerInfo _DJLNOAMJECI_PlayerData, EAJCBFGKKFA_FriendInfo ALOBLKOHIKD_FriendData, EEDKAACNBBG_MusicData GMFMMDAKENC_MusicData, KLBKPANJCPL_Score POMOLHBFAPM_Score, bool _HGEKDNNJAAC_AwakenDivaMode, bool _OOOGNIPJMDE_HadDivaMode, bool _OHLCKPIMMFH_ValkyrieMode, JLKEOGLJNOD_TeamInfo _HEDKFICAPIJ_Team)
	{
		MEMCOJHNEIP.Clear();
		GCIJNCFDNON_SceneInfo s = null;
		for(int i = 0; i < _HEDKFICAPIJ_Team.BCJEAJPLGMB_MainDivas.Count; i++)
		{
			FFHPBEPOMAK_DivaInfo divaInfo = _HEDKFICAPIJ_Team.BCJEAJPLGMB_MainDivas[i];
			if(divaInfo != null)
			{
				if(divaInfo.FGFIBOBAPIA_SceneId > 0)
				{
					GCIJNCFDNON_SceneInfo sceneInfo = _DJLNOAMJECI_PlayerData.OPIBAPEGCLA_Scenes[divaInfo.FGFIBOBAPIA_SceneId - 1];
					if(sceneInfo.MKHFCGPJPFI_LimitOverCount > 0)
					{
						OMPNCHBNEPF.KHEKNNFCAOI_Init(sceneInfo.JKGFBFPIMGA_Rarity, sceneInfo.MKHFCGPJPFI_LimitOverCount, sceneInfo.MJBODMOLOBC_luck);
						HHOKCLBEOHI(OMPNCHBNEPF.CMCKNKKCNDK_status, sceneInfo, GMFMMDAKENC_MusicData);
						MEMCOJHNEIP.Add(OMPNCHBNEPF.CMCKNKKCNDK_status);
					}
					if (i == 0)
						s = sceneInfo;
				}
				for(int j = 0; j < divaInfo.DJICAKGOGFO_SubSceneIds.Count; j++)
				{
					if (divaInfo.DJICAKGOGFO_SubSceneIds[j] > 0)
					{
						GCIJNCFDNON_SceneInfo sceneInfo = _DJLNOAMJECI_PlayerData.OPIBAPEGCLA_Scenes[divaInfo.DJICAKGOGFO_SubSceneIds[j] - 1];
						if (sceneInfo.MKHFCGPJPFI_LimitOverCount > 0)
						{
							OMPNCHBNEPF.KHEKNNFCAOI_Init(sceneInfo.JKGFBFPIMGA_Rarity, sceneInfo.MKHFCGPJPFI_LimitOverCount, sceneInfo.MJBODMOLOBC_luck);
							HHOKCLBEOHI(OMPNCHBNEPF.CMCKNKKCNDK_status, sceneInfo, GMFMMDAKENC_MusicData);
							MEMCOJHNEIP.Add(OMPNCHBNEPF.CMCKNKKCNDK_status);
						}
					}
				}
			}
		}
		if(ALOBLKOHIKD_FriendData != null && ALOBLKOHIKD_FriendData.KHGKPKDBMOH_GetAssistScene() != null && ALOBLKOHIKD_FriendData.KHGKPKDBMOH_GetAssistScene().MKHFCGPJPFI_LimitOverCount > 0)
		{
			GCIJNCFDNON_SceneInfo sceneInfo = ALOBLKOHIKD_FriendData.KHGKPKDBMOH_GetAssistScene();
			OMPNCHBNEPF.KHEKNNFCAOI_Init(sceneInfo.JKGFBFPIMGA_Rarity, sceneInfo.MKHFCGPJPFI_LimitOverCount, sceneInfo.MJBODMOLOBC_luck);
			HHOKCLBEOHI(OMPNCHBNEPF.CMCKNKKCNDK_status, sceneInfo, GMFMMDAKENC_MusicData);
			MEMCOJHNEIP.Add(OMPNCHBNEPF.CMCKNKKCNDK_status);
		}
		int e = 0;
		if (s != null)
		{
			int skillId = s.FILPDDHMKEJ_GetLiveSkillId(false, GMFMMDAKENC_MusicData != null ? GMFMMDAKENC_MusicData.FKDCCLPGKDK_JacketAttr : 0, GMFMMDAKENC_MusicData != null ? GMFMMDAKENC_MusicData.AIHCEGFANAM_SerieAttr : 0);
			if(skillId > 0)
			{
				PPGHMBNIAEC skillInfo = IMMAOANGPNK_NetMasterDataManager.HHCJCDFCLOB_Instance.NKEBMCIMJND_Database.FOFADHAENKC_Skill.PNJMFKFGIML_LiveSkills[skillId - 1];
				int rate = (MEMCOJHNEIP.centerLiveSkillRate + MEMCOJHNEIP.centerLiveSkillRate_SameMusicAttr + MEMCOJHNEIP.centerLiveSkillRate_SameSeriesAttr);
				for (int i = 0; i < skillInfo.EGLDFPILJLG_SkillBuffEffect.Length; i++)
				{
					int a = CKNDJNOFFGP_GetSkillValue(skillInfo, i, s.AADFFCIDJCB_LiveSkillLevel, _HEDKFICAPIJ_Team.BCJEAJPLGMB_MainDivas[0]);
					int b = IGDGGMIMLDN(a, _DJLNOAMJECI_PlayerData, GMFMMDAKENC_MusicData, (SkillBuffEffect.Type)skillInfo.EGLDFPILJLG_SkillBuffEffect[i], skillInfo.FLJHGGKIOJH_SkillType, POMOLHBFAPM_Score, _HEDKFICAPIJ_Team);
					int c = CPPANAJNEDJ(KHDDPKHPJID, _DJLNOAMJECI_PlayerData, GMFMMDAKENC_MusicData, (SkillBuffEffect.Type) skillInfo.EGLDFPILJLG_SkillBuffEffect[i], a + b, (SkillDuration.Type) skillInfo.FPMFEKIPFPI_DurationType[i], skillInfo.PHAGNOHBMCM_DurationByIndexAndLevel[s.AADFFCIDJCB_LiveSkillLevel - 1, i], (SkillTrigger.Type) skillInfo.CPNAGMFCIJK_TriggerType, skillInfo.LFGFBMJNBKN_ConfigValue[s.AADFFCIDJCB_LiveSkillLevel - 1], POMOLHBFAPM_Score, _HGEKDNNJAAC_AwakenDivaMode, _OOOGNIPJMDE_HadDivaMode, _OHLCKPIMMFH_ValkyrieMode);
					int g = MCKHJBNJFJH(KHDDPKHPJID, _DJLNOAMJECI_PlayerData, GMFMMDAKENC_MusicData, (SkillBuffEffect.Type)skillInfo.EGLDFPILJLG_SkillBuffEffect[i], a + b, (SkillDuration.Type)skillInfo.FPMFEKIPFPI_DurationType[i], skillInfo.PHAGNOHBMCM_DurationByIndexAndLevel[s.AADFFCIDJCB_LiveSkillLevel - 1, i], (SkillTrigger.Type)skillInfo.CPNAGMFCIJK_TriggerType, skillInfo.LFGFBMJNBKN_ConfigValue[s.AADFFCIDJCB_LiveSkillLevel - 1], POMOLHBFAPM_Score, _HGEKDNNJAAC_AwakenDivaMode, false);
					int d = MEAHJKCBGFE(0, KHDDPKHPJID, _DJLNOAMJECI_PlayerData, GMFMMDAKENC_MusicData, (SkillBuffEffect.Type)skillInfo.EGLDFPILJLG_SkillBuffEffect[i], a + b, (SkillDuration.Type)skillInfo.FPMFEKIPFPI_DurationType[i], skillInfo.PHAGNOHBMCM_DurationByIndexAndLevel[s.AADFFCIDJCB_LiveSkillLevel - 1, i], (SkillTrigger.Type)skillInfo.CPNAGMFCIJK_TriggerType, skillInfo.LFGFBMJNBKN_ConfigValue[s.AADFFCIDJCB_LiveSkillLevel - 1], skillInfo.ELEPHBOKIGK_Limit[0], POMOLHBFAPM_Score, true);
					e += c * rate / 100 + g * rate / 100 + d * rate / 100;
				}
			}
		}
		return ((KHDDPKHPJID / POMOLHBFAPM_Score.NLKEBAOBJCM_combo) * ((POMOLHBFAPM_Score.NLKEBAOBJCM_combo * 90 / 100) * (MEMCOJHNEIP.excellentRate + MEMCOJHNEIP.excellentRate_SameMusicAttr + MEMCOJHNEIP.excellentRate_SameSeriesAttr)) / 100 * 90) / 100 + e;
	}

	// // RVA: 0x1094624 Offset: 0x1094624 VA: 0x1094624
	private static void HHOKCLBEOHI(LimitOverStatusData _CMCKNKKCNDK_status, GCIJNCFDNON_SceneInfo _PNLOINMCCKH_Scene, EEDKAACNBBG_MusicData _KKHIDFKKFJE_MusicData)
	{
		if((int)_PNLOINMCCKH_Scene.AIHCEGFANAM_SerieAttr != _KKHIDFKKFJE_MusicData.AIHCEGFANAM_SerieAttr)
		{
			_CMCKNKKCNDK_status.excellentRate_SameSeriesAttr = 0;
			_CMCKNKKCNDK_status.centerLiveSkillRate_SameSeriesAttr = 0;
		}
		if(_KKHIDFKKFJE_MusicData.FKDCCLPGKDK_JacketAttr != 4 && _KKHIDFKKFJE_MusicData.FKDCCLPGKDK_JacketAttr != _PNLOINMCCKH_Scene.JGJFIJOCPAG_SceneAttr)
		{
			_CMCKNKKCNDK_status.excellentRate_SameMusicAttr = 0;
			_CMCKNKKCNDK_status.centerLiveSkillRate_SameMusicAttr = 0;
		}
	}

	// // RVA: 0x10939D4 Offset: 0x10939D4 VA: 0x10939D4
	private static int IGDGGMIMLDN(int _NKGHBKFMFCI_BuffValue, DFKGGBMFFGB_PlayerInfo _DJLNOAMJECI_PlayerData, EEDKAACNBBG_MusicData _GMFMMDAKENC_MusicData, SkillBuffEffect.Type _MCJEIDPDMLF_EffectId, int _NEJBNCHLMNJ_Type, KLBKPANJCPL_Score POMOLHBFAPM, JLKEOGLJNOD_TeamInfo _HEDKFICAPIJ_Team)
	{
		int IILKAJBHLMJ_Value = 0;
		OKGLGHCBCJP_Database LKMHPJKIFDN_md = IMMAOANGPNK_NetMasterDataManager.HHCJCDFCLOB_Instance.NKEBMCIMJND_Database;
		Func<GCIJNCFDNON_SceneInfo, FFHPBEPOMAK_DivaInfo, int> f = (GCIJNCFDNON_SceneInfo _PNLOINMCCKH_Scene, FFHPBEPOMAK_DivaInfo _FDBOPFEOENF_diva) =>
		{
			//0x175A624
			if (_PNLOINMCCKH_Scene != null)
			{
				int skillId = _PNLOINMCCKH_Scene.FILPDDHMKEJ_GetLiveSkillId(false, _GMFMMDAKENC_MusicData != null ? _GMFMMDAKENC_MusicData.FKDCCLPGKDK_JacketAttr : 0, _GMFMMDAKENC_MusicData != null ? _GMFMMDAKENC_MusicData.AIHCEGFANAM_SerieAttr : 0);
				if(skillId > 0)
				{
					if(_PNLOINMCCKH_Scene.DCLLIDMKNGO_IsDivaCompatible(_FDBOPFEOENF_diva.AHHJLDLAPAN_DivaId))
					{
						PPGHMBNIAEC skillInfo = LKMHPJKIFDN_md.FOFADHAENKC_Skill.PNJMFKFGIML_LiveSkills[skillId - 1];
						if(skillInfo.AANDPLGPDEI())
						{
							if (!skillInfo.HDPIEILADDH(_GMFMMDAKENC_MusicData.DLAEJOBELBH_MusicId))
								return 0;
						}
						if(skillInfo.HCGDJAFINMH())
						{
							if (!skillInfo.OEJNKFONOGJ(_GMFMMDAKENC_MusicData.FKDCCLPGKDK_JacketAttr))
								return 0;
						}
						for(int i = 0; i < skillInfo.EGLDFPILJLG_SkillBuffEffect.Length; i++)
						{
							if(skillInfo.EGLDFPILJLG_SkillBuffEffect[i] == (int)SkillBuffEffect.Type.EffectValueUp &&
								_NEJBNCHLMNJ_Type != 0 && _NEJBNCHLMNJ_Type == skillInfo.DPGDCJFBFGK_TargetSkillType)
							{
								if(LKMHPJKIFDN_md.FOFADHAENKC_Skill.JBGPIPLAAIA(skillInfo.POMLAENHCHA_TargetSkillEffectId, (int)_MCJEIDPDMLF_EffectId))
								{
									IILKAJBHLMJ_Value += _NKGHBKFMFCI_BuffValue * skillInfo.NKGHBKFMFCI_BuffValue[_PNLOINMCCKH_Scene.AADFFCIDJCB_LiveSkillLevel - 1, i];
								}
							}
						}
					}
				}
			}
			return IILKAJBHLMJ_Value;
		};
		for (int i = 0; i < _HEDKFICAPIJ_Team.BCJEAJPLGMB_MainDivas.Count; i++)
		{
			FFHPBEPOMAK_DivaInfo divaInfo = _HEDKFICAPIJ_Team.BCJEAJPLGMB_MainDivas[i];
			if(divaInfo != null)
			{
				if(i != 0 && divaInfo.FGFIBOBAPIA_SceneId > 0)
				{
					GCIJNCFDNON_SceneInfo sceneInfo = _DJLNOAMJECI_PlayerData.OPIBAPEGCLA_Scenes[divaInfo.FGFIBOBAPIA_SceneId - 1];
					f(sceneInfo, divaInfo);
				}
				for(int j = 0; j < divaInfo.DJICAKGOGFO_SubSceneIds.Count; j++)
				{
					if (divaInfo.DJICAKGOGFO_SubSceneIds[j] > 0)
					{
						GCIJNCFDNON_SceneInfo sceneInfo = _DJLNOAMJECI_PlayerData.OPIBAPEGCLA_Scenes[divaInfo.DJICAKGOGFO_SubSceneIds[j] - 1];
						f(sceneInfo, divaInfo);
					}
				}
			}
		}
		return IILKAJBHLMJ_Value;
	}

	// // RVA: 0x1093FD0 Offset: 0x1093FD0 VA: 0x1093FD0
	private static int CPPANAJNEDJ(int KHDDPKHPJID, DFKGGBMFFGB_PlayerInfo _DJLNOAMJECI_PlayerData, EEDKAACNBBG_MusicData _GMFMMDAKENC_MusicData, SkillBuffEffect.Type _MCJEIDPDMLF_EffectId, int _NKGHBKFMFCI_BuffValue, SkillDuration.Type _FPMFEKIPFPI_DurationType, int _PHAGNOHBMCM_DurationByIndexAndLevel, SkillTrigger.Type BAAFOOKFDLL, int _LFGFBMJNBKN_ConfigValue, KLBKPANJCPL_Score POMOLHBFAPM, bool _HGEKDNNJAAC_AwakenDivaMode, bool _OOOGNIPJMDE_HadDivaMode, bool _OHLCKPIMMFH_ValkyrieMode)
	{
		int res = 0;
		if (_MCJEIDPDMLF_EffectId > SkillBuffEffect.Type.ScoreUpPercentage_Intimacy)
			return 0;
		if (((1 << ((int)_MCJEIDPDMLF_EffectId & 0xff)) & 0x180202) == 0)
			return 0;
		int v = 0;
		if(_FPMFEKIPFPI_DurationType >= SkillDuration.Type.ValkyrieModeAndNoteResult && _FPMFEKIPFPI_DurationType <= SkillDuration.Type.AwakenDivaModeAndNoteResult)
		{
			if(BAAFOOKFDLL == SkillTrigger.Type.AwakenDivaMode)
			{
				v = POMOLHBFAPM.JJBOEMOJPEC_DivaNote;
				if (!_HGEKDNNJAAC_AwakenDivaMode)
					return 0;
			}
			else if(BAAFOOKFDLL == SkillTrigger.Type.DivaMode)
			{
				v = POMOLHBFAPM.JJBOEMOJPEC_DivaNote;
				_OHLCKPIMMFH_ValkyrieMode = _OOOGNIPJMDE_HadDivaMode;
				if (!_OHLCKPIMMFH_ValkyrieMode)
					return 0;
			}
			else if(BAAFOOKFDLL == SkillTrigger.Type.ValkyrieMode)
			{
				v = POMOLHBFAPM.GEIDIHCKDNO;
				if (!_OHLCKPIMMFH_ValkyrieMode)
					return 0;
			}
			res = _NKGHBKFMFCI_BuffValue * KHDDPKHPJID / 100 * v / POMOLHBFAPM.NLKEBAOBJCM_combo;
		}
		else
		{
			if (_FPMFEKIPFPI_DurationType != SkillDuration.Type.Time)
				return 0;
			switch(BAAFOOKFDLL)
			{
				case SkillTrigger.Type.Timebomb:
					v = POMOLHBFAPM.MCMIPODICAN_length;
					if (_LFGFBMJNBKN_ConfigValue * 1000 - v != 0 && v <= _LFGFBMJNBKN_ConfigValue * 1000)
						return 0;
					res = ((KHDDPKHPJID * _NKGHBKFMFCI_BuffValue) / 100) * (_PHAGNOHBMCM_DurationByIndexAndLevel * 1000 / v);
					break;
				case SkillTrigger.Type.Combo:
					v = POMOLHBFAPM.NLKEBAOBJCM_combo;
					if (v < _LFGFBMJNBKN_ConfigValue)
						return 0;
					v = POMOLHBFAPM.MCMIPODICAN_length;
					res = ((KHDDPKHPJID * _NKGHBKFMFCI_BuffValue) / 100) * (_PHAGNOHBMCM_DurationByIndexAndLevel * 1000 / v);
					break;
				case SkillTrigger.Type.EveryTime:
					v = POMOLHBFAPM.MCMIPODICAN_length;
					int b = _LFGFBMJNBKN_ConfigValue * 1000;
					if (b - v != 0 && v <= b)
						return 0;
					res = ((KHDDPKHPJID * _NKGHBKFMFCI_BuffValue) / 100) * (_PHAGNOHBMCM_DurationByIndexAndLevel * 1000 / v) * v / b;
					break;
				case SkillTrigger.Type.EveryScore:
					break;
			}
		}
		return res;
	}

	// // RVA: 0x109435C Offset: 0x109435C VA: 0x109435C
	private static int MCKHJBNJFJH(int KHDDPKHPJID, DFKGGBMFFGB_PlayerInfo _DJLNOAMJECI_PlayerData, EEDKAACNBBG_MusicData _GMFMMDAKENC_MusicData, SkillBuffEffect.Type _MCJEIDPDMLF_EffectId, int _NKGHBKFMFCI_BuffValue, SkillDuration.Type _FPMFEKIPFPI_DurationType, int _PHAGNOHBMCM_DurationByIndexAndLevel, SkillTrigger.Type BAAFOOKFDLL, int _LFGFBMJNBKN_ConfigValue, KLBKPANJCPL_Score POMOLHBFAPM, bool _HGEKDNNJAAC_AwakenDivaMode, bool _OHLCKPIMMFH_ValkyrieMode)
	{
		int skill_combo_bonus_value0 = IMMAOANGPNK_NetMasterDataManager.HHCJCDFCLOB_Instance.NKEBMCIMJND_Database.HNMMJINNHII_Game.LPJLEHAJADA_GetIntParam("skill_combo_bonus_value0", 0);
		if (_FPMFEKIPFPI_DurationType != SkillDuration.Type.Time || _MCJEIDPDMLF_EffectId != SkillBuffEffect.Type.ComboBonus)
			return 0;
		if (BAAFOOKFDLL == SkillTrigger.Type.EveryTime)
			return 0;
		int cb = POMOLHBFAPM.NLKEBAOBJCM_combo;
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
				_HGEKDNNJAAC_AwakenDivaMode = true;
			}
			b = _HGEKDNNJAAC_AwakenDivaMode;
			a = cb - POMOLHBFAPM.JJBOEMOJPEC_DivaNote;
		}
		int res = 0;
		if(b && skill_combo_bonus_value0 <= cb)
		{
			res = (_PHAGNOHBMCM_DurationByIndexAndLevel * 1000 / len) * (Mathf.Max(a / cb, 1) * _NKGHBKFMFCI_BuffValue) / 100 * KHDDPKHPJID;
		}
		return res;
	}

	// // RVA: 0x1093E5C Offset: 0x1093E5C VA: 0x1093E5C
	private static int MEAHJKCBGFE(int FLKGCONIFEE, int KHDDPKHPJID, DFKGGBMFFGB_PlayerInfo _DJLNOAMJECI_PlayerData, EEDKAACNBBG_MusicData _GMFMMDAKENC_MusicData, SkillBuffEffect.Type _MCJEIDPDMLF_EffectId, int _NKGHBKFMFCI_BuffValue, SkillDuration.Type _FPMFEKIPFPI_DurationType, int _PHAGNOHBMCM_DurationByIndexAndLevel, SkillTrigger.Type BAAFOOKFDLL, int _LFGFBMJNBKN_ConfigValue, int JLDDHNFKGHL, KLBKPANJCPL_Score POMOLHBFAPM, bool _KIFJKGDBDBH_lucky/* = false*/)
	{
		int res = 0;
		if (_MCJEIDPDMLF_EffectId < SkillBuffEffect.Type.Num && ((1 << ((int)_MCJEIDPDMLF_EffectId & 0xff)) & 0x180202) != 0 && BAAFOOKFDLL == SkillTrigger.Type.EveryScore)
		{
			int i = FLKGCONIFEE / _LFGFBMJNBKN_ConfigValue * 10000;
			if (_KIFJKGDBDBH_lucky)
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
				res = -(a * _NKGHBKFMFCI_BuffValue / 100 * KHDDPKHPJID * _PHAGNOHBMCM_DurationByIndexAndLevel * 1000 / POMOLHBFAPM.MCMIPODICAN_length);
			}
		}
		return res;
	}

	// // RVA: 0x108EE08 Offset: 0x108EE08 VA: 0x108EE08
	private static bool MODGPFEPLIP(ref EDMIONMCICN _HBODCMLFDOB_result, DFKGGBMFFGB_PlayerInfo _DJLNOAMJECI_PlayerData, EAJCBFGKKFA_FriendInfo ALOBLKOHIKD_FriendData, EEDKAACNBBG_MusicData GMFMMDAKENC_MusicData, KLBKPANJCPL_Score POMOLHBFAPM_Score, Difficulty.Type AKNELONELJK_difficulty, bool _GIKLNODJKFK_IsLine6, out bool _HGEKDNNJAAC_AwakenDivaMode, out bool _OHLCKPIMMFH_ValkyrieMode, JLKEOGLJNOD_TeamInfo _HEDKFICAPIJ_Team)
	{
		bool res = false;
		_HGEKDNNJAAC_AwakenDivaMode = false;
		_OHLCKPIMMFH_ValkyrieMode = false;
		int sup = 0;
		int fold = 0;
		for(int i = 0; i < _HEDKFICAPIJ_Team.BCJEAJPLGMB_MainDivas.Count; i++)
		{
			FFHPBEPOMAK_DivaInfo divaInfo = _HEDKFICAPIJ_Team.BCJEAJPLGMB_MainDivas[i];
			if(divaInfo != null)
			{
				fold += divaInfo.JLJGCBOHJID_Status.fold;
				sup += divaInfo.JLJGCBOHJID_Status.support;
				if(divaInfo.FGFIBOBAPIA_SceneId > 0)
				{
					GCIJNCFDNON_SceneInfo sceneInfo = _DJLNOAMJECI_PlayerData.OPIBAPEGCLA_Scenes[divaInfo.FGFIBOBAPIA_SceneId - 1];
					fold += sceneInfo.CMCKNKKCNDK_status.fold;
					sup += sceneInfo.CMCKNKKCNDK_status.support;
				}
				for(int j = 0; j < divaInfo.DJICAKGOGFO_SubSceneIds.Count; j++)
				{
					if (divaInfo.DJICAKGOGFO_SubSceneIds[j] > 0)
					{
						GCIJNCFDNON_SceneInfo sceneInfo = _DJLNOAMJECI_PlayerData.OPIBAPEGCLA_Scenes[divaInfo.DJICAKGOGFO_SubSceneIds[j] - 1];
						fold += sceneInfo.CMCKNKKCNDK_status.fold;
						sup += sceneInfo.CMCKNKKCNDK_status.support;
					}
				}
			}
		}
		if(ALOBLKOHIKD_FriendData != null && ALOBLKOHIKD_FriendData.KHGKPKDBMOH_GetAssistScene() != null)
		{
			fold += ALOBLKOHIKD_FriendData.KHGKPKDBMOH_GetAssistScene().CMCKNKKCNDK_status.fold;
			sup += ALOBLKOHIKD_FriendData.KHGKPKDBMOH_GetAssistScene().CMCKNKKCNDK_status.support;
		}
		_HBODCMLFDOB_result.BEDINMCPENB_SetupStatus(ref FLOHCPIIHEH_WorkStatus);
		int subGoal;
		int goal;
		int max;
		if(GMFMMDAKENC_MusicData is LIEJFHMGNIA)
		{
			DJNPIGEFPMF_StoryMusicInfo g = IMMAOANGPNK_NetMasterDataManager.HHCJCDFCLOB_Instance.NKEBMCIMJND_Database.IBPAFKKEKNK_Music.FLMLJIKBIMJ_GetStoryMusicData((GMFMMDAKENC_MusicData as LIEJFHMGNIA).KLCIIHKFPPO_StoryMusicId);
			subGoal = g.HLKHOFPAOMK_SubGoalByDiff[(int)AKNELONELJK_difficulty];
			goal = g.HLLJIICKNIP_GoalByDiff[(int)AKNELONELJK_difficulty];
			max = g.FENOHOEIJOE_MaxValue[(int)AKNELONELJK_difficulty];
		}
		else
		{
			KEODKEGFDLD_FreeMusicInfo m = IMMAOANGPNK_NetMasterDataManager.HHCJCDFCLOB_Instance.NKEBMCIMJND_Database.IBPAFKKEKNK_Music.NOBCLJIAMLC_GetFreeMusicData((GMFMMDAKENC_MusicData as IBJAKJJICBC).GHBPLHBNMBK_FreeMusicId);
			if(!_GIKLNODJKFK_IsLine6)
			{
				subGoal = m.HLKHOFPAOMK_SubGoalByDiff[(int)AKNELONELJK_difficulty];
				goal = m.HLLJIICKNIP_GoalByDiff[(int)AKNELONELJK_difficulty];
				max = m.FENOHOEIJOE_MaxValue[(int)AKNELONELJK_difficulty];
			}
			else
			{
				subGoal = m.MAGILDGLOKD_SubGoalFreeModeL6ByDiff[(int)AKNELONELJK_difficulty];
				goal = m.JEANDFEBLIG_GoalFreeModeL6ByDiff[(int)AKNELONELJK_difficulty];
				max = m.KFIDHFOGDPJ_MaxValueFreeModeL6ByDiff[(int)AKNELONELJK_difficulty];
			}
		}
		int val = 0;
		for(int i = POMOLHBFAPM_Score.KIEHDJFCCNM; i > 0; i--)
		{
			val += Mathf.RoundToInt(
				BEFDPKNGHPO(fold + sup, val, max, 
					IMMAOANGPNK_NetMasterDataManager.HHCJCDFCLOB_Instance.NKEBMCIMJND_Database.HNMMJINNHII_Game.CIFKMCKFMOA_FCoeff4 / 10000.0f, 
					IMMAOANGPNK_NetMasterDataManager.HHCJCDFCLOB_Instance.NKEBMCIMJND_Database.HNMMJINNHII_Game.IHIONKFAAED_FCoeff1 / 100.0f,
					IMMAOANGPNK_NetMasterDataManager.HHCJCDFCLOB_Instance.NKEBMCIMJND_Database.HNMMJINNHII_Game.HHPJIALEPEE_FCoeff2 / 100.0f,
					subGoal, max, POMOLHBFAPM_Score.KIEHDJFCCNM
				) * (fold + sup));
		}
		if (val < subGoal)
			res = false;
		else
		{
			_OHLCKPIMMFH_ValkyrieMode = true;
			res = PKLPIDIBHMN(_DJLNOAMJECI_PlayerData, GMFMMDAKENC_MusicData, AKNELONELJK_difficulty, _GIKLNODJKFK_IsLine6, POMOLHBFAPM_Score.GEIDIHCKDNO, (sup + FLOHCPIIHEH_WorkStatus.support) / IMMAOANGPNK_NetMasterDataManager.HHCJCDFCLOB_Instance.NKEBMCIMJND_Database.HNMMJINNHII_Game.MPAMBMKFCKK_BCoeff2 + 1, out _HGEKDNNJAAC_AwakenDivaMode, _HEDKFICAPIJ_Team);
		}

		return res;
	}

	// // RVA: 0x10947B0 Offset: 0x10947B0 VA: 0x10947B0
	private static float BEFDPKNGHPO(float EGIGDODCJOG, int LKCCMBEOLLA, int _DCBENCMNOGO_MaxCount, float GKHEOELGCAP, float IHEACEHPHKP, float JDIKNJEJCNN, int NNFBAIJKCCP, float GLDFMGNCOGM, int EDGIJNGLBDE)
	{
		float f;
		if(EGIGDODCJOG >= 0)
		{
			if(LKCCMBEOLLA < NNFBAIJKCCP)
			{
				f = Mathf.Max((_DCBENCMNOGO_MaxCount - LKCCMBEOLLA) / _DCBENCMNOGO_MaxCount, GKHEOELGCAP);
			}
			else
			{
				f = Mathf.Max((_DCBENCMNOGO_MaxCount - LKCCMBEOLLA) / _DCBENCMNOGO_MaxCount, GKHEOELGCAP) * IHEACEHPHKP;
			}
		}
		else
		{
			f = LKCCMBEOLLA / _DCBENCMNOGO_MaxCount * JDIKNJEJCNN;
			if (LKCCMBEOLLA < NNFBAIJKCCP)
				f = LKCCMBEOLLA / _DCBENCMNOGO_MaxCount;
		}
		return GLDFMGNCOGM / EDGIJNGLBDE * f;
	}

	// // RVA: 0x1094918 Offset: 0x1094918 VA: 0x1094918
	private static bool PKLPIDIBHMN(DFKGGBMFFGB_PlayerInfo _DJLNOAMJECI_PlayerData, EEDKAACNBBG_MusicData _GMFMMDAKENC_MusicData, Difficulty.Type _AKNELONELJK_difficulty, bool _GIKLNODJKFK_IsLine6, int EDGIJNGLBDE, float PGEDGKMCFLB, out bool _HGEKDNNJAAC_AwakenDivaMode, JLKEOGLJNOD_TeamInfo _HEDKFICAPIJ_Team)
	{
		DJNPIGEFPMF_StoryMusicInfo smd = null;
		int goal;
		int subGoal;
		int enemyId;
		if (_GMFMMDAKENC_MusicData is LIEJFHMGNIA)
		{
			DJNPIGEFPMF_StoryMusicInfo g = IMMAOANGPNK_NetMasterDataManager.HHCJCDFCLOB_Instance.NKEBMCIMJND_Database.IBPAFKKEKNK_Music.FLMLJIKBIMJ_GetStoryMusicData((_GMFMMDAKENC_MusicData as LIEJFHMGNIA).KLCIIHKFPPO_StoryMusicId);
			subGoal = g.HLKHOFPAOMK_SubGoalByDiff[(int)_AKNELONELJK_difficulty];
			goal = g.HLLJIICKNIP_GoalByDiff[(int)_AKNELONELJK_difficulty];
			enemyId = g.LHICAKGHIGF_EnemyIdByDiff[(int)_AKNELONELJK_difficulty];
			smd = IMMAOANGPNK_NetMasterDataManager.HHCJCDFCLOB_Instance.NKEBMCIMJND_Database.IBPAFKKEKNK_Music.FLMLJIKBIMJ_GetStoryMusicData(g.KLCIIHKFPPO_StoryMusicId);
		}
		else
		{
			KEODKEGFDLD_FreeMusicInfo m = IMMAOANGPNK_NetMasterDataManager.HHCJCDFCLOB_Instance.NKEBMCIMJND_Database.IBPAFKKEKNK_Music.NOBCLJIAMLC_GetFreeMusicData((_GMFMMDAKENC_MusicData as IBJAKJJICBC).GHBPLHBNMBK_FreeMusicId);
			if (!_GIKLNODJKFK_IsLine6)
			{
				subGoal = m.LJPKLMJPLAC_DIn[(int)_AKNELONELJK_difficulty];
				goal = m.MALHPBKPIDE_SdIn[(int)_AKNELONELJK_difficulty];
				enemyId = m.LHICAKGHIGF_EnemyIdByDiff[(int)_AKNELONELJK_difficulty];
			}
			else
			{
				subGoal = m.ILCJOOPIILK_DInLine6[(int)_AKNELONELJK_difficulty];
				goal = m.BGILEHEJHHA_SdInLine6[(int)_AKNELONELJK_difficulty];
				enemyId = m.PJNFOCDANCE_EnemyIdByDiffL6[(int)_AKNELONELJK_difficulty];
			}
		}
		AONMBIEIBCD.Clear();
		AONMBIEIBCD.Add(IMMAOANGPNK_NetMasterDataManager.HHCJCDFCLOB_Instance.NKEBMCIMJND_Database.HNMMJINNHII_Game.IJDBNKCLGIC_BCoeff3);
		AONMBIEIBCD.Add(IMMAOANGPNK_NetMasterDataManager.HHCJCDFCLOB_Instance.NKEBMCIMJND_Database.HNMMJINNHII_Game.GLMKBFEHPLA_BCoeff4);
		AONMBIEIBCD.Add(IMMAOANGPNK_NetMasterDataManager.HHCJCDFCLOB_Instance.NKEBMCIMJND_Database.HNMMJINNHII_Game.GLMKBFEHPLA_BCoeff4);
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
		JPIANKEOOMB_Valkyrie.KJPIDJOMODA_ValkyrieInfo valk = IMMAOANGPNK_NetMasterDataManager.HHCJCDFCLOB_Instance.NKEBMCIMJND_Database.PEOALFEGNDH_Valkyrie.CDENCMNHNGA_table[_HEDKFICAPIJ_Team.JOKFNBLEILN_Valkyrie.GPPEFLKGGGJ_ValkyrieId - 1];
		int dd = 0;
		int p = 0;
		for(int i = 0; i < v; i++)
		{
			dd += OEEDGPGEPFH(valk.OJHINEMKMOP(0) * PGEDGKMCFLB, valk.PAELLCKLEJP(0) * PGEDGKMCFLB, 
				IMMAOANGPNK_NetMasterDataManager.HHCJCDFCLOB_Instance.NKEBMCIMJND_Database.OPFBEAJJMJB_Enemy.INONDJKKOKG(enemyId).ADMMEMNGKEN_Avo, i, i + RhythmGameEnemyStatus.AttackComboCount, 1, 1, v, out p);
		}
		_HGEKDNNJAAC_AwakenDivaMode = goal <= dd;
		return subGoal <= dd;
	}

	// // RVA: 0x1095364 Offset: 0x1095364 VA: 0x1095364
	private static int OEEDGPGEPFH(float ALOGOPNMLJI, float EDGBEFKOGMN, float IFMEDLKMHIG, int LGGLNFIKCKF, int _CKFNNECHOGG_ComboCount, float PBIFADDFADF, float KOMJMBBPMML, int EDGIJNGLBDE, out int GBMNIAOLBEB)
	{
		int i = 0;
		for (; i < FOMKBDKKODO.Count; i++)
		{
			if(LGGLNFIKCKF + 1 - RhythmGameEnemyStatus.AttackComboCount < FOMKBDKKODO[i])
				break;
		}
		return (int)(FDIIFOOLDGM(EDGBEFKOGMN, IFMEDLKMHIG, KOMJMBBPMML, out GBMNIAOLBEB) * 
				(IMMAOANGPNK_NetMasterDataManager.HHCJCDFCLOB_Instance.NKEBMCIMJND_Database.HNMMJINNHII_Game.FHHPNFAECCJ(_CKFNNECHOGG_ComboCount) / 100.0f) * 
				(AONMBIEIBCD[i] * 1.0f / EDGIJNGLBDE) * ALOGOPNMLJI * PBIFADDFADF);
	}

	// // RVA: 0x10956D0 Offset: 0x10956D0 VA: 0x10956D0
	private static float FDIIFOOLDGM(float EDGBEFKOGMN, float IFMEDLKMHIG, float KOMJMBBPMML, out int GBMNIAOLBEB)
	{
		int a = (int)((EDGBEFKOGMN * 1.2f - IFMEDLKMHIG) * KOMJMBBPMML);
		GBMNIAOLBEB = IMMAOANGPNK_NetMasterDataManager.HHCJCDFCLOB_Instance.NKEBMCIMJND_Database.HNMMJINNHII_Game.FHFLCJHEEPK(a);
		return IMMAOANGPNK_NetMasterDataManager.HHCJCDFCLOB_Instance.NKEBMCIMJND_Database.HNMMJINNHII_Game.IKIGFABDFMB(a) / 100.0f;
	}

	// // RVA: 0x1093648 Offset: 0x1093648 VA: 0x1093648
	private static int CKNDJNOFFGP_GetSkillValue(PPGHMBNIAEC KMHPOGKCHHK, int _AOGDKBPNGCI_EffectIdx, int GBMHFDKCFGB, FFHPBEPOMAK_DivaInfo HIDAJBOHJKH)
	{
		int v = KMHPOGKCHHK.NKGHBKFMFCI_BuffValue[GBMHFDKCFGB - 1, _AOGDKBPNGCI_EffectIdx];
		if (KMHPOGKCHHK.EGLDFPILJLG_SkillBuffEffect[_AOGDKBPNGCI_EffectIdx] != (int)SkillBuffEffect.Type.ScoreUpPercentage_Intimacy)
		{
			if(KMHPOGKCHHK.EGLDFPILJLG_SkillBuffEffect[_AOGDKBPNGCI_EffectIdx] == (int)SkillBuffEffect.Type.ScoreUpPercentage_FoldWave)
			{
				v = IMMAOANGPNK_NetMasterDataManager.HHCJCDFCLOB_Instance.NKEBMCIMJND_Database.FOFADHAENKC_Skill.HJGDBBPDHON(v).DOOGFEGEKLG_max;
			}
			return v;
		}
		JJOELIOGMKK_DivaIntimacyInfo j = new JJOELIOGMKK_DivaIntimacyInfo();
		j.KHEKNNFCAOI_Init(HIDAJBOHJKH.AHHJLDLAPAN_DivaId);
		j.HCDGELDHFHB_UpdateStatus(false);
		EHGAHMIBPIB s = IMMAOANGPNK_NetMasterDataManager.HHCJCDFCLOB_Instance.NKEBMCIMJND_Database.FOFADHAENKC_Skill.HJGDBBPDHON(v);
		return Mathf.Min(j.HEKJGCMNJAB_CurrentLevel / s.KCOHMHFBDKF_Value1[GBMHFDKCFGB - 1] * s.HLMMBNCIIAC_Value2[GBMHFDKCFGB - 1], s.DOOGFEGEKLG_max);
	}

	// // RVA: 0x109477C Offset: 0x109477C VA: 0x109477C
	// private static bool BBIBJKIKBPO(SkillBuffEffect.Type LFAFFMFOFEG) { }
}
