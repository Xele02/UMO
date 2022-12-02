using System.Collections.Generic;
using XeApp.Game.Common;

namespace XeApp.Game.Menu
{
	public class SetDeckParamCalculator
	{
		private JLKEOGLJNOD m_viewUnitData; // 0x8
		private EJKBKMBJMGL m_viewEnemyData; // 0xC
		private NHDJHOPLMDE m_viewValkyrieAbilityData; // 0x10
		private GCIJNCFDNON m_mainScene; // 0x14
		//private AEGLGBOGDHH m_unitSkillCalcResult; // 0x18
		private StatusData m_baseStatus = new StatusData(); // 0x48
		private StatusData m_addStatus = new StatusData(); // 0x4C
		private static StatusData m_tmpStatus; // 0x0
		private int m_baseLuck; // 0x50
		private int m_addLuck; // 0x54
		private LimitOverStatusData m_limitOverStatus = new LimitOverStatusData(); // 0x58
		private static LimitOverStatusData m_tmpLimitOverStatus; // 0x4
		private bool m_isEnableEpisodeBonus; // 0x5C
		private int m_episodeBonusPoint; // 0x60
		//private CFHDKAFLNEP m_subPlate; // 0x64
		private JGEOBNENMAH.NEDILFPPCJF m_logParams = new JGEOBNENMAH.NEDILFPPCJF(); // 0x6C

		//public bool IsEmptyUnit { get; } 0xA6FF7C
		//public AEGLGBOGDHH SkillCalcResult { get; } 0xA6FF94
		//public StatusData BaseStatus { get; } 0xA6FFB4
		//public StatusData AddStatus { get; } 0xA6FFBC
		//public LimitOverStatusData LimitOverStatus { get; } 0xA6FFC4
		//public NHDJHOPLMDE ValkyrieAbilityData { get; } 0xA6FFCC
		//public JGEOBNENMAH.NEDILFPPCJF LogParams { get; } 0xA6FFD4
		//public CFHDKAFLNEP SubPlateResult { get; } 0xA6FFDC
		//public bool IsEnableEnemySkill { get; } 0xA6FFF0
		//public bool IsEnableEpisodeBonus { get; } 0xA7002C
		//public int EpisodeBonusPoint { get; } 0xA70034

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
		public void Calc(GameSetupData.MusicInfo musicInfo, DFKGGBMFFGB viewPlayerData, JLKEOGLJNOD viewUnitData, EEDKAACNBBG viewMusicData, EAJCBFGKKFA viewFriendData, EJKBKMBJMGL_EnemyData viewEnemyData, List<IKDICBBFBMI_EventBase.GNPOABJANKO> bonusList, bool isRaid = false)
		{
			TodoLogger.Log(0, "Calc Param");
		}

		//// RVA: 0xA7214C Offset: 0xA7214C VA: 0xA7214C
		//public void Calc(DFKGGBMFFGB viewPlayerData, JLKEOGLJNOD viewUnitData, EEDKAACNBBG viewMusicData, EAJCBFGKKFA viewFriendData) { }

		//// RVA: 0xA706B8 Offset: 0xA706B8 VA: 0xA706B8
		//private static void CalcStatusForUnitCheck(ref StatusData baseStatus, ref StatusData addStatus, out int luck, int baseLuck, GameSetupData.MusicInfo musicInfo, DFKGGBMFFGB viewPlayerData, EEDKAACNBBG viewMusicData, EAJCBFGKKFA viewFriendPlayerData, EJKBKMBJMGL viewEnemyData, out AEGLGBOGDHH result, out CFHDKAFLNEP subPlate, JLKEOGLJNOD viewUnitData, ref JGEOBNENMAH.NEDILFPPCJF logParams) { }

		//// RVA: 0xA72520 Offset: 0xA72520 VA: 0xA72520
		//private static void CalcStatusForUnitEdit(ref StatusData baseStatus, ref StatusData addStatus, out int luck, DFKGGBMFFGB viewPlayerData, EEDKAACNBBG viewMusicData, EAJCBFGKKFA viewFriendPlayerData, out AEGLGBOGDHH result, out CFHDKAFLNEP subPlate, JLKEOGLJNOD viewUnitData) { }

		//// RVA: 0xA718A8 Offset: 0xA718A8 VA: 0xA718A8
		//private static void CalcLimitBrakeForUnitCheck(ref LimitOverStatusData limitOverStatus, JLKEOGLJNOD viewUnitData, DFKGGBMFFGB viewPlayerData, EEDKAACNBBG musicData, EAJCBFGKKFA friendData) { }

		//// RVA: 0xA728D4 Offset: 0xA728D4 VA: 0xA728D4
		//private static void CalcLimitBrakeForUnitEdit(ref LimitOverStatusData limitOverStatus, JLKEOGLJNOD viewUnitData, DFKGGBMFFGB viewPlayerData) { }

		//// RVA: 0xA72EB0 Offset: 0xA72EB0 VA: 0xA72EB0
		//private static void AdjustOverLimit(LimitOverStatusData status, GCIJNCFDNON sceneData, EEDKAACNBBG musicData) { }

		//// RVA: 0xA71FAC Offset: 0xA71FAC VA: 0xA71FAC
		//private static bool CanBonusEpisode(List<IKDICBBFBMI.GNPOABJANKO> list, out int bonusPoint) { }

		// RVA: 0xA73014 Offset: 0xA73014 VA: 0xA73014
		private static void .cctor() { }
	}
}
