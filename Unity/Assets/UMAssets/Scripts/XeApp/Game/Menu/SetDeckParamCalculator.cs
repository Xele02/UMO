using System.Collections.Generic;
using XeApp.Game.Common;

namespace XeApp.Game.Menu
{
	public class SetDeckParamCalculator
	{
		private JLKEOGLJNOD_TeamInfo m_viewUnitData; // 0x8
		private EJKBKMBJMGL_EnemyData m_viewEnemyData; // 0xC
		private NHDJHOPLMDE m_viewValkyrieAbilityData; // 0x10
		private GCIJNCFDNON_SceneInfo m_mainScene; // 0x14
		private AEGLGBOGDHH m_unitSkillCalcResult; // 0x18
		private StatusData m_baseStatus = new StatusData(); // 0x48
		private StatusData m_addStatus = new StatusData(); // 0x4C
		private static StatusData m_tmpStatus = new StatusData(); // 0x0
		private int m_baseLuck; // 0x50
		private int m_addLuck; // 0x54
		private LimitOverStatusData m_limitOverStatus = new LimitOverStatusData(); // 0x58
		private static LimitOverStatusData m_tmpLimitOverStatus = new LimitOverStatusData(); // 0x4
		private bool m_isEnableEpisodeBonus; // 0x5C
		private int m_episodeBonusPoint; // 0x60
		private CFHDKAFLNEP m_subPlate; // 0x64
		private JGEOBNENMAH.NEDILFPPCJF m_logParams = new JGEOBNENMAH.NEDILFPPCJF(); // 0x6C

		public bool IsEmptyUnit { get { return m_viewUnitData != null && m_viewUnitData.EIGKIHENKNC_HasNoDivaSet; } } //0xA6FF7C
		public AEGLGBOGDHH SkillCalcResult { get {
				return m_unitSkillCalcResult;
			} } //0xA6FF94
		public StatusData BaseStatus { get { return m_baseStatus; } } //0xA6FFB4
		public StatusData AddStatus { get { return m_addStatus; } } //0xA6FFBC
		public LimitOverStatusData LimitOverStatus { get { return m_limitOverStatus; } } //0xA6FFC4
		public NHDJHOPLMDE ValkyrieAbilityData { get { return m_viewValkyrieAbilityData; } } //0xA6FFCC
		public JGEOBNENMAH.NEDILFPPCJF LogParams { get { return m_logParams; } } //0xA6FFD4
		public CFHDKAFLNEP SubPlateResult { get { return m_subPlate; } } //0xA6FFDC
		//public bool IsEnableEnemySkill { get; } 0xA6FFF0
		public bool IsEnableEpisodeBonus { get { return m_isEnableEpisodeBonus; } } //0xA7002C
		public int EpisodeBonusPoint { get { return m_episodeBonusPoint; } } //0xA70034

		// RVA: 0xA7003C Offset: 0xA7003C VA: 0xA7003C
		public SetDeckParamCalculator()
		{
			m_baseLuck = 0;
			m_addLuck = 0;
			m_isEnableEpisodeBonus = false;
			m_episodeBonusPoint = 0;
			m_viewUnitData = null;
			m_viewEnemyData = null;
			m_viewValkyrieAbilityData = null;
			m_mainScene = null;
		}

		//// RVA: 0xA70138 Offset: 0xA70138 VA: 0xA70138
		//public void Reset() { }

		//// RVA: 0xA7015C Offset: 0xA7015C VA: 0xA7015C
		public void Calc(GameSetupData.MusicInfo musicInfo, DFKGGBMFFGB_PlayerInfo viewPlayerData, JLKEOGLJNOD_TeamInfo viewUnitData, EEDKAACNBBG_MusicData viewMusicData, EAJCBFGKKFA_FriendInfo viewFriendData, EJKBKMBJMGL_EnemyData viewEnemyData, List<IKDICBBFBMI_EventBase.GNPOABJANKO> bonusList, bool isRaid = false)
		{
			m_addLuck = 0;
			m_baseLuck = 0;
			m_isEnableEpisodeBonus = false;
			m_viewUnitData = viewUnitData;
			m_viewEnemyData = viewEnemyData;
			m_viewValkyrieAbilityData = null;
			m_mainScene = null;
			m_episodeBonusPoint = 0;
			PNGOLKLFFLH p = viewUnitData.JOKFNBLEILN_Valkyrie;
			if(p != null)
			{
				NHDJHOPLMDE n = new NHDJHOPLMDE(p.GPPEFLKGGGJ_ValkyrieId, 0);
				if(n != null)
				{
					if(n.LAKLFHGMCLI((SeriesAttr.Type)viewMusicData.AIHCEGFANAM_Serie))
					{
						m_viewValkyrieAbilityData = n;
					}
				}
			}
			m_mainScene = null;
			FFHPBEPOMAK_DivaInfo f = viewUnitData.BCJEAJPLGMB_MainDivas[0];
			if(f != null && f.FGFIBOBAPIA_SceneId > 0)
			{
				m_mainScene = viewPlayerData.OPIBAPEGCLA_Scenes[f.FGFIBOBAPIA_SceneId - 1];
			}
			m_baseLuck = 0;
			m_addLuck = 0;
			for(int i = 0; i < viewUnitData.BCJEAJPLGMB_MainDivas.Count; i++)
			{
				m_baseLuck += DivaIconDecoration.GetEquipmentLuck(viewUnitData.BCJEAJPLGMB_MainDivas[i], viewPlayerData);
			}
			CalcStatusForUnitCheck(ref m_baseStatus, ref m_addStatus, out m_addLuck, m_baseLuck, musicInfo, viewPlayerData, viewMusicData, viewFriendData, viewEnemyData, out m_unitSkillCalcResult, out m_subPlate, viewUnitData, ref m_logParams);
			m_addStatus.Add(m_baseStatus);
			m_addLuck += m_baseLuck;
			CalcLimitBrakeForUnitCheck(ref m_limitOverStatus, viewUnitData, viewPlayerData, viewMusicData, viewFriendData);
			m_episodeBonusPoint = 0;
			m_isEnableEpisodeBonus = false;
			if (isRaid)
			{
				TodoLogger.LogError(0, "event");
			}
			else
			{
				m_isEnableEpisodeBonus = CanBonusEpisode(bonusList, out m_episodeBonusPoint);
			}
		}

		//// RVA: 0xA7214C Offset: 0xA7214C VA: 0xA7214C
		public void Calc(DFKGGBMFFGB_PlayerInfo viewPlayerData, JLKEOGLJNOD_TeamInfo viewUnitData, EEDKAACNBBG_MusicData viewMusicData, EAJCBFGKKFA_FriendInfo viewFriendData)
		{
			m_addLuck = 0;
			m_baseLuck = 0;
			m_isEnableEpisodeBonus = false;
			m_episodeBonusPoint = 0;
			m_viewUnitData = viewUnitData;
			m_viewEnemyData = null;
			m_viewValkyrieAbilityData = null;
			m_mainScene = null;
			if(viewMusicData != null && viewUnitData.JOKFNBLEILN_Valkyrie != null)
			{
				NHDJHOPLMDE n = new NHDJHOPLMDE(viewUnitData.JOKFNBLEILN_Valkyrie.GPPEFLKGGGJ_ValkyrieId, 0);
				if(n != null)
				{
					if(n.LAKLFHGMCLI((SeriesAttr.Type)viewMusicData.AIHCEGFANAM_Serie))
					{
						m_viewValkyrieAbilityData = n;
					}
				}
			}
			m_mainScene = null;
			if(viewUnitData.BCJEAJPLGMB_MainDivas[0] != null && viewUnitData.BCJEAJPLGMB_MainDivas[0].FGFIBOBAPIA_SceneId > 0)
			{
				m_mainScene = viewPlayerData.OPIBAPEGCLA_Scenes[viewUnitData.BCJEAJPLGMB_MainDivas[0].FGFIBOBAPIA_SceneId - 1];
			}
			m_baseLuck = 0;
			m_addLuck = 0;
			for(int i = 0; i < viewUnitData.BCJEAJPLGMB_MainDivas.Count; i++)
			{
				m_baseLuck += DivaIconDecoration.GetEquipmentLuck(viewUnitData.BCJEAJPLGMB_MainDivas[i], viewPlayerData);
			}
			CalcStatusForUnitEdit(ref m_baseStatus, ref m_addStatus, out m_addLuck, viewPlayerData, viewMusicData, viewFriendData, out m_unitSkillCalcResult, out m_subPlate, viewUnitData);
			m_addStatus.Add(m_baseStatus);
			m_addLuck += m_baseLuck;
			CalcLimitBrakeForUnitEdit(ref m_limitOverStatus, viewUnitData, viewPlayerData);
		}

		//// RVA: 0xA706B8 Offset: 0xA706B8 VA: 0xA706B8
		private static void CalcStatusForUnitCheck(ref StatusData baseStatus, ref StatusData addStatus, out int luck, int baseLuck, GameSetupData.MusicInfo musicInfo, DFKGGBMFFGB_PlayerInfo viewPlayerData, EEDKAACNBBG_MusicData viewMusicData, EAJCBFGKKFA_FriendInfo viewFriendPlayerData, EJKBKMBJMGL_EnemyData viewEnemyData, out AEGLGBOGDHH result, out CFHDKAFLNEP subPlate, JLKEOGLJNOD_TeamInfo viewUnitData, ref JGEOBNENMAH.NEDILFPPCJF logParams)
		{
			FFHPBEPOMAK_DivaInfo f = viewUnitData.BCJEAJPLGMB_MainDivas[0];
			baseStatus.Clear();
			addStatus.Clear();
			luck = 0;
			//viewUnitData.CMCKNKKCNDK ??
			baseStatus.Copy(viewUnitData.JLJGCBOHJID_Status);
			result = new AEGLGBOGDHH();
			result.OBKGEDCKHHE();
			result.JCHLONCMPAJ();
			CMMKCEPBIHI.DIDENKKDJKI(ref result, viewUnitData, viewPlayerData, viewMusicData, viewFriendPlayerData, viewEnemyData);
			result.DDPJACNMPEJ(ref addStatus);
			baseStatus.Add(addStatus);
			result.GEEDEOHGMOM(ref addStatus);
			subPlate = result.CLCIOEHGFNI;
			m_tmpStatus.Clear();
			if(viewUnitData.EIGKIHENKNC_HasNoDivaSet)
			{
				CMMKCEPBIHI.BKBMHJBFDOG_Reset();
			}
			else
			{
				CMMKCEPBIHI.EFCNOOFFMIL(viewPlayerData, viewUnitData, viewFriendPlayerData, viewMusicData, viewEnemyData, musicInfo.difficultyType, musicInfo.IsLine6Mode);
			}
			int friendLuck = 0;
			if(viewFriendPlayerData != null && viewFriendPlayerData.KHGKPKDBMOH_GetAssistScene() != null)
			{
				m_tmpStatus.Copy(viewFriendPlayerData.KHGKPKDBMOH_GetAssistScene().CMCKNKKCNDK_Status);
				for(int i = 0; i < m_tmpStatus.spNoteExpected.Length; i++)
				{
					m_tmpStatus.spNoteExpected[i] = 0;
				}
				friendLuck = viewFriendPlayerData.KHGKPKDBMOH_GetAssistScene().MJBODMOLOBC_Luck;
				luck += viewFriendPlayerData.KHGKPKDBMOH_GetAssistScene().MJBODMOLOBC_Luck;
				baseStatus.Add(m_tmpStatus);
			}
			result.DIJOPLHIMBO(logParams, viewUnitData.JLJGCBOHJID_Status, m_tmpStatus, baseLuck, friendLuck);
			if(f == null || f.FGFIBOBAPIA_SceneId < 1)
			{
				logParams.IFHMFONMGPE_CenterSkillLvl = 0;
				logParams.AKNKIOKELEP_ActiveSkillLvl = 0;
			}
			else
			{
				logParams.IFHMFONMGPE_CenterSkillLvl = viewPlayerData.OPIBAPEGCLA_Scenes[f.FGFIBOBAPIA_SceneId - 1].DDEDANKHHPN_SkillLevel;
				logParams.AKNKIOKELEP_ActiveSkillLvl = viewPlayerData.OPIBAPEGCLA_Scenes[f.FGFIBOBAPIA_SceneId - 1].PNHJPCPFNFI_ActiveSkillLevel;
			}
			int totalScore = 0;
			for(int i = 0; i < 10; i++)
			{
				totalScore += CMMKCEPBIHI.NDNOLJACLLC_GetScore((CMMKCEPBIHI.NOJENDEDECD_ScoreType)i);
			}
			logParams.NDKKNEIDCFF_TotalScoreExpected = totalScore;
			logParams.LPKBGBLIDCE = 0;
			logParams.OIKJEAEJOME = 0;
			logParams.LCFAJIELMMF = 0;
			logParams.JJDKFJACLMD = 0;
			for(int i = 0; i < result.GJLJJDIDODK.Length; i++)
			{
				logParams.LPKBGBLIDCE += result.GJLJJDIDODK[i].BJABFKMIJHB_StatusMainScene.soul + result.GJLJJDIDODK[i].AJINBLGCBMM_StatusCostumeMainScene.soul;
				logParams.LCFAJIELMMF += result.GJLJJDIDODK[i].BJABFKMIJHB_StatusMainScene.charm + result.GJLJJDIDODK[i].AJINBLGCBMM_StatusCostumeMainScene.charm;
				logParams.OIKJEAEJOME += result.GJLJJDIDODK[i].BJABFKMIJHB_StatusMainScene.vocal + result.GJLJJDIDODK[i].AJINBLGCBMM_StatusCostumeMainScene.vocal;
				logParams.JJDKFJACLMD += result.GJLJJDIDODK[i].BJABFKMIJHB_StatusMainScene.life + result.GJLJJDIDODK[i].AJINBLGCBMM_StatusCostumeMainScene.life;
				for(int j = 0; j < result.GJLJJDIDODK[i].OBCPFDNKLMM_StatusSubScenes.Length; j++)
				{
					logParams.LPKBGBLIDCE += result.GJLJJDIDODK[i].OBCPFDNKLMM_StatusSubScenes[j].soul;
					logParams.LCFAJIELMMF += result.GJLJJDIDODK[i].OBCPFDNKLMM_StatusSubScenes[j].charm;
					logParams.OIKJEAEJOME += result.GJLJJDIDODK[i].OBCPFDNKLMM_StatusSubScenes[j].vocal;
					logParams.JJDKFJACLMD += result.GJLJJDIDODK[i].OBCPFDNKLMM_StatusSubScenes[j].life;
				}
				for (int j = 0; j < result.GJLJJDIDODK[i].FEGNMIGJMDM_CostumeSubScene.Length; j++)
				{
					logParams.LPKBGBLIDCE += result.GJLJJDIDODK[i].FEGNMIGJMDM_CostumeSubScene[j].soul;
					logParams.LCFAJIELMMF += result.GJLJJDIDODK[i].FEGNMIGJMDM_CostumeSubScene[j].charm;
					logParams.OIKJEAEJOME += result.GJLJJDIDODK[i].FEGNMIGJMDM_CostumeSubScene[j].vocal;
					logParams.JJDKFJACLMD += result.GJLJJDIDODK[i].FEGNMIGJMDM_CostumeSubScene[j].life;
				}
				logParams.IPPIIBLLDDG[i] = result.GJLJJDIDODK[i].IMLGBMGIACC.soul;
				logParams.HHNPILDOHKP[i] = result.GJLJJDIDODK[i].IMLGBMGIACC.charm;
				logParams.MHPLFJHDIEP[i] = result.GJLJJDIDODK[i].IMLGBMGIACC.vocal;
			}
			for(int i = 0; i < viewUnitData.BCJEAJPLGMB_MainDivas.Count; i++)
			{
				f = viewUnitData.BCJEAJPLGMB_MainDivas[i];
				if (f == null)
				{
					logParams.EEKANKOEJIL[i] = 0;
					logParams.HNINPGMPGMJ[i] = 0;
					logParams.DNGJJFFKOBG[i] = 0;
					logParams.NBCMAGJGHLC[i] = 0;
					logParams.LBGNJCODPEJ[i] = 0;
					logParams.EGEKLGIEKLL[i] = 0;
				}
				else
				{
					logParams.EEKANKOEJIL[i] = f.JLJGCBOHJID_Status.soul - f.IHANGGCHPAL.PNOKIEEILJN();
					logParams.HNINPGMPGMJ[i] = f.JLJGCBOHJID_Status.charm - f.IHANGGCHPAL.KDKCMCBLEMG();
					logParams.DNGJJFFKOBG[i] = f.JLJGCBOHJID_Status.vocal - f.IHANGGCHPAL.LCDIGPJJJGI();
					logParams.NBCMAGJGHLC[i] = f.IHANGGCHPAL.PNOKIEEILJN();
					logParams.LBGNJCODPEJ[i] = f.IHANGGCHPAL.KDKCMCBLEMG();
					logParams.EGEKLGIEKLL[i] = f.IHANGGCHPAL.LCDIGPJJJGI();
				}
			}
		}

		//// RVA: 0xA72520 Offset: 0xA72520 VA: 0xA72520
		private static void CalcStatusForUnitEdit(ref StatusData baseStatus, ref StatusData addStatus, out int luck, DFKGGBMFFGB_PlayerInfo viewPlayerData, EEDKAACNBBG_MusicData viewMusicData, EAJCBFGKKFA_FriendInfo viewFriendPlayerData, out AEGLGBOGDHH result, out CFHDKAFLNEP subPlate, JLKEOGLJNOD_TeamInfo viewUnitData)
		{
			baseStatus.Clear();
			addStatus.Clear();
			luck = 0;
			baseStatus.Copy(viewUnitData.JLJGCBOHJID_Status);
			result = new AEGLGBOGDHH();
			result.OBKGEDCKHHE();
			result.JCHLONCMPAJ();
			CMMKCEPBIHI.DIDENKKDJKI(ref result, viewUnitData, viewPlayerData, viewMusicData, viewFriendPlayerData, null);
			result.DDPJACNMPEJ(ref addStatus);
			baseStatus.Add(addStatus);
			result.GEEDEOHGMOM(ref addStatus);
			subPlate = result.CLCIOEHGFNI;
			m_tmpStatus.Clear();
			if (viewFriendPlayerData == null || viewFriendPlayerData.KHGKPKDBMOH_GetAssistScene() == null)
				return;
			m_tmpStatus.Copy(viewFriendPlayerData.KHGKPKDBMOH_GetAssistScene().CMCKNKKCNDK_Status);
			luck += viewFriendPlayerData.KHGKPKDBMOH_GetAssistScene().MJBODMOLOBC_Luck;
			baseStatus.Add(m_tmpStatus);
		}

		//// RVA: 0xA718A8 Offset: 0xA718A8 VA: 0xA718A8
		private static void CalcLimitBrakeForUnitCheck(ref LimitOverStatusData limitOverStatus, JLKEOGLJNOD_TeamInfo viewUnitData, DFKGGBMFFGB_PlayerInfo viewPlayerData, EEDKAACNBBG_MusicData musicData, EAJCBFGKKFA_FriendInfo friendData)
		{
			limitOverStatus.Clear();
			for(int i = 0; i < viewUnitData.BCJEAJPLGMB_MainDivas.Count; i++)
			{
				m_tmpLimitOverStatus.Clear();
				if(viewUnitData.BCJEAJPLGMB_MainDivas[i] != null)
				{
					if(viewUnitData.BCJEAJPLGMB_MainDivas[i].FGFIBOBAPIA_SceneId != 0)
					{
						GCIJNCFDNON_SceneInfo g = viewPlayerData.OPIBAPEGCLA_Scenes[viewUnitData.BCJEAJPLGMB_MainDivas[i].FGFIBOBAPIA_SceneId - 1];
						IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.HDGOHBFKKDM_LimitOver.MNHPPJFNPCG(ref m_tmpLimitOverStatus, g.JKGFBFPIMGA_Rarity, g.MJBODMOLOBC_Luck, g.MKHFCGPJPFI_LimitOverCount);
						AdjustOverLimit(m_tmpLimitOverStatus, g, musicData);
						limitOverStatus.Add(m_tmpLimitOverStatus);
					}
					for(int j = 0; j < viewUnitData.BCJEAJPLGMB_MainDivas[i].DJICAKGOGFO_SubSceneIds.Count; j++)
					{
						if (viewUnitData.BCJEAJPLGMB_MainDivas[i].DJICAKGOGFO_SubSceneIds[j] > 0)
						{
							GCIJNCFDNON_SceneInfo g = viewPlayerData.OPIBAPEGCLA_Scenes[viewUnitData.BCJEAJPLGMB_MainDivas[i].DJICAKGOGFO_SubSceneIds[j] - 1];
							IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.HDGOHBFKKDM_LimitOver.MNHPPJFNPCG(ref m_tmpLimitOverStatus, g.JKGFBFPIMGA_Rarity, g.MJBODMOLOBC_Luck, g.MKHFCGPJPFI_LimitOverCount);
							AdjustOverLimit(m_tmpLimitOverStatus, g, musicData);
							limitOverStatus.Add(m_tmpLimitOverStatus);
						}
					}
				}
			}
			if (friendData == null || friendData.KHGKPKDBMOH_GetAssistScene() == null)
				return;
			IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.HDGOHBFKKDM_LimitOver.MNHPPJFNPCG(ref m_tmpLimitOverStatus, friendData.KHGKPKDBMOH_GetAssistScene().JKGFBFPIMGA_Rarity, friendData.KHGKPKDBMOH_GetAssistScene().MJBODMOLOBC_Luck, friendData.KHGKPKDBMOH_GetAssistScene().MKHFCGPJPFI_LimitOverCount);
			AdjustOverLimit(m_tmpLimitOverStatus, friendData.KHGKPKDBMOH_GetAssistScene(), musicData);
			limitOverStatus.Add(m_tmpLimitOverStatus);
		}

		//// RVA: 0xA728D4 Offset: 0xA728D4 VA: 0xA728D4
		private static void CalcLimitBrakeForUnitEdit(ref LimitOverStatusData limitOverStatus, JLKEOGLJNOD_TeamInfo viewUnitData, DFKGGBMFFGB_PlayerInfo viewPlayerData)
		{
			LLKLAKGKNLD_LimitOver l = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.HDGOHBFKKDM_LimitOver;
			limitOverStatus.Clear();
			for(int i = 0; i < viewUnitData.BCJEAJPLGMB_MainDivas.Count; i++)
			{
				m_tmpLimitOverStatus.Clear();
				if(viewUnitData.BCJEAJPLGMB_MainDivas[i] != null)
				{
					if(viewUnitData.BCJEAJPLGMB_MainDivas[i].FGFIBOBAPIA_SceneId != 0)
					{
						GCIJNCFDNON_SceneInfo scene = viewPlayerData.OPIBAPEGCLA_Scenes[viewUnitData.BCJEAJPLGMB_MainDivas[i].FGFIBOBAPIA_SceneId - 1];
						l.MNHPPJFNPCG(ref m_tmpLimitOverStatus, scene.JKGFBFPIMGA_Rarity, scene.MJBODMOLOBC_Luck, scene.MKHFCGPJPFI_LimitOverCount);
						limitOverStatus.Add(m_tmpLimitOverStatus);
					}
					for (int j = 0; j < viewUnitData.BCJEAJPLGMB_MainDivas[i].DJICAKGOGFO_SubSceneIds.Count; j++)
					{
						if(viewUnitData.BCJEAJPLGMB_MainDivas[i].DJICAKGOGFO_SubSceneIds[j] > 0)
						{
							GCIJNCFDNON_SceneInfo scene = viewPlayerData.OPIBAPEGCLA_Scenes[viewUnitData.BCJEAJPLGMB_MainDivas[i].DJICAKGOGFO_SubSceneIds[j] - 1];
							l.MNHPPJFNPCG(ref m_tmpLimitOverStatus, scene.JKGFBFPIMGA_Rarity, scene.MJBODMOLOBC_Luck, scene.MKHFCGPJPFI_LimitOverCount);
							limitOverStatus.Add(m_tmpLimitOverStatus);
						}
					}
				}
			}
		}

		//// RVA: 0xA72EB0 Offset: 0xA72EB0 VA: 0xA72EB0
		private static void AdjustOverLimit(LimitOverStatusData status, GCIJNCFDNON_SceneInfo sceneData, EEDKAACNBBG_MusicData musicData)
		{
			if((int)sceneData.AIHCEGFANAM_SceneSeries != musicData.AIHCEGFANAM_Serie)
			{
				status.excellentRate_SameSeriesAttr = 0;
				status.centerLiveSkillRate_SameSeriesAttr = 0;
			}
			if(!CMMKCEPBIHI.OJNOJNEKBKH(sceneData.JGJFIJOCPAG_SceneAttr, musicData.FKDCCLPGKDK_JacketAttr))
			{
				status.excellentRate_SameMusicAttr = 0;
				status.centerLiveSkillRate_SameMusicAttr = 0;
			}
		}

		//// RVA: 0xA71FAC Offset: 0xA71FAC VA: 0xA71FAC
		private static bool CanBonusEpisode(List<IKDICBBFBMI_EventBase.GNPOABJANKO> list, out int bonusPoint)
		{
			bonusPoint = 0;
			if (list != null && list.Count > 0)
			{
				TodoLogger.LogError(0, "CanBonusEpisode Event");
			}
			return false;
		}
	}
}
