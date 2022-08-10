using XeSys.Gfx;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace XeApp.Game.Menu
{
	public class MusicSelectButtonSet : LayoutLabelScriptBase
	{
		public enum OptionStyle
		{
			None = 0,
			Basic = 1,
			QuestEvent = 2,
			QuestEventInfo = 3,
			QuestEventSelect = 4,
			CollectEvent = 5,
			ScoreEvent = 6,
			BattleEvent = 7,
			SimulationLive = 8,
			EndEventHome = 9,
			GoDivaEvent = 10,
			GoDivaEventEnd = 11,
		}

		// private static readonly MusicSelectOptionButton.OptionType[] s_emptyOptionButtons = null; // 0x0
		// private static readonly MusicSelectOptionButton.OptionType[] s_basicOptionButtons = new MusicSelectOptionButton.OptionType[4] {
		// 	0, 1, 2, 5
		// }; // 0x4
		// private static readonly MusicSelectOptionButton.OptionType[] s_questEventOptionButtons = new MusicSelectOptionButton.OptionType[4] {
		// 	3, 4, 6, 7
		// }; // 0x8
		// private static readonly MusicSelectOptionButton.OptionType[] s_questEventInfoOptionButtons = new MusicSelectOptionButton.OptionType[6] {
		// 	3, 4, 0, 1, 2, 5
		// }; // 0xC
		// private static readonly MusicSelectOptionButton.OptionType[] s_collectEventOptionButtons = new MusicSelectOptionButton.OptionType[7] {
		// 	3, 4, 6, 7, 0, 2, 5
		// }; // 0x10
		// private static readonly MusicSelectOptionButton.OptionType[] s_scoreEventOptionButtons = new MusicSelectOptionButton.OptionType[5] {
		// 	3, 4, 1, 2, 5
		// }; // 0x14
		// private static readonly MusicSelectOptionButton.OptionType[] s_battleEventOptionButtons = new MusicSelectOptionButton.OptionType[6] {
		// 	3, 4, 6, 7, 2, 5
		// }; // 0x18
		// private static readonly MusicSelectOptionButton.OptionType[] s_simulationLiveOptionButtons = new MusicSelectOptionButton.OptionType[1] { 2 }; // 0x1C
		// private static readonly MusicSelectOptionButton.OptionType[] s_endEventHomeOptionButtons = new MusicSelectOptionButton.OptionType[4] {
		// 	3, 4, 6, 7
		// }; // 0x20
		// private static readonly MusicSelectOptionButton.OptionType[] s_goDivaEventOptionButtons = new MusicSelectOptionButton.OptionType[4] {
		// 	3, 4, 6, 7
		// }; // 0x24
		// private static readonly MusicSelectOptionButton.OptionType[] s_goDivaEventEndOptionButtons = new MusicSelectOptionButton.OptionType[4] {
		// 	3, 4, 6, 7
		// }; // 0x28
		[SerializeField]
		private List<MusicSelectOptionButton> m_optionButtons; // 0x18
		// private LayoutSymbolData m_symbolMain; // 0x1C
		// private List<LayoutSymbolData> m_symbolButtonStyles; // 0x20
		// private List<MusicSelectOptionButton.OptionType> m_optionTypes = new List<MusicSelectOptionButton.OptionType>(5); // 0x24
		// private bool m_isShow; // 0x48

		public Action onClickRankingButton { private get; set; } // 0x28
		public Action onClickRewardButton { private get; set; } // 0x2C
		public Action onClickDetailButton { private get; set; } // 0x30
		public Action onClickEventRankingButton { private get; set; } // 0x34
		public Action onClickEventRewardButton { private get; set; } // 0x38
		public Action onClickEnemyInfoButton { private get; set; } // 0x3C
		// public Action onClickStoryButton { private get; set; } // 0x40
		// public Action onClickMissionButton { private get; set; } // 0x44

		// // RVA: 0x166A09C Offset: 0x166A09C VA: 0x166A09C
		// public void TryEnter() { }

		// // RVA: 0x166A130 Offset: 0x166A130 VA: 0x166A130
		public void TryLeave()
		{
			TodoLogger.Log(0, "MusicSelectButtonSet TryLeave");
		}

		// // RVA: 0x166A0AC Offset: 0x166A0AC VA: 0x166A0AC
		public void Enter()
		{
			TodoLogger.Log(0, "MusicSelectButtonSet Enter");
		}

		// // RVA: 0x166A140 Offset: 0x166A140 VA: 0x166A140
		// public void Leave() { }

		// // RVA: 0x166A1C4 Offset: 0x166A1C4 VA: 0x166A1C4
		// public void Show() { }

		// // RVA: 0x166A248 Offset: 0x166A248 VA: 0x166A248
		public void Hide()
		{
			TodoLogger.Log(0, "MusicSelectButtonSet Hide");
		}

		// // RVA: 0x166A2CC Offset: 0x166A2CC VA: 0x166A2CC
		public bool IsPlaying()
		{
			TodoLogger.Log(0, "MusicSelectButtonSet IsPlaying");
			return false;
		}

		// // RVA: 0x166A2F8 Offset: 0x166A2F8 VA: 0x166A2F8
		// public void SetOptionStyle(MusicSelectButtonSet.OptionStyle style, bool withoutRanking = False, bool withoutReward = False, bool withoutEvRanking = False, bool withoutMission = False) { }

		// // RVA: 0x166AE50 Offset: 0x166AE50 VA: 0x166AE50
		// public void SetEnemyHasSkill(bool hasSkill) { }

		// // RVA: 0x166B028 Offset: 0x166B028 VA: 0x166B028
		// public void SetBadge(MusicSelectOptionButton.OptionType optionType, bool isOn) { }

		// // RVA: 0x166B1C4 Offset: 0x166B1C4 VA: 0x166B1C4
		// public void SetEventRankingCountin(bool isCounting) { }

		// // RVA: 0x166A8F0 Offset: 0x166A8F0 VA: 0x166A8F0
		// private void ApplyOptionButtons(List<MusicSelectOptionButton.OptionType> types, MusicSelectButtonSet.OptionStyle style) { }

		// // RVA: 0x166B388 Offset: 0x166B388 VA: 0x166B388
		// private void ApplyOptionButton(MusicSelectOptionButton button, MusicSelectOptionButton.OptionType optionType, LayoutSymbolData symbolStyle) { }

		// // RVA: 0x166B7B8 Offset: 0x166B7B8 VA: 0x166B7B8
		// private void OnClickRanking() { }

		// // RVA: 0x166B7CC Offset: 0x166B7CC VA: 0x166B7CC
		// private void OnClickReward() { }

		// // RVA: 0x166B7E0 Offset: 0x166B7E0 VA: 0x166B7E0
		// private void OnClickMusicDetail() { }

		// // RVA: 0x166B7F4 Offset: 0x166B7F4 VA: 0x166B7F4
		// private void OnClickEventRanking() { }

		// // RVA: 0x166B808 Offset: 0x166B808 VA: 0x166B808
		// private void OnClickEventReward() { }

		// // RVA: 0x166B81C Offset: 0x166B81C VA: 0x166B81C
		// private void OnClickEnemyInfo() { }

		// // RVA: 0x166B830 Offset: 0x166B830 VA: 0x166B830
		// private void OnClickStory() { }

		// // RVA: 0x166B844 Offset: 0x166B844 VA: 0x166B844
		// private void OnClickMission() { }

		// RVA: 0x166B858 Offset: 0x166B858 VA: 0x166B858 Slot: 5
		public override bool InitializeFromLayout(Layout layout, TexUVListManager uvMan)
		{
			TodoLogger.Log(0, "InitializeFromLayout MusicSelectButtonSet");
			return true;
		}
	}
}
