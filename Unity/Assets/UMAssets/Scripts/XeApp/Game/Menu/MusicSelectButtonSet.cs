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

		private static readonly MusicSelectOptionButton.OptionType[] s_emptyOptionButtons = null; // 0x0
		private static readonly MusicSelectOptionButton.OptionType[] s_basicOptionButtons = new MusicSelectOptionButton.OptionType[4] {
			MusicSelectOptionButton.OptionType.Ranking, 
			MusicSelectOptionButton.OptionType.Reward,
			MusicSelectOptionButton.OptionType.MusicDetail, 
			MusicSelectOptionButton.OptionType.EnemyInfo
		}; // 0x4
		private static readonly MusicSelectOptionButton.OptionType[] s_questEventOptionButtons = new MusicSelectOptionButton.OptionType[4] {
			MusicSelectOptionButton.OptionType.EvRanking,
			MusicSelectOptionButton.OptionType.EvReward,
			MusicSelectOptionButton.OptionType.EvStory,
			MusicSelectOptionButton.OptionType.EvMission
		}; // 0x8
		private static readonly MusicSelectOptionButton.OptionType[] s_questEventInfoOptionButtons = new MusicSelectOptionButton.OptionType[6] {
			MusicSelectOptionButton.OptionType.EvRanking,
			MusicSelectOptionButton.OptionType.EvReward,
			MusicSelectOptionButton.OptionType.Ranking,
			MusicSelectOptionButton.OptionType.Reward,
			MusicSelectOptionButton.OptionType.MusicDetail,
			MusicSelectOptionButton.OptionType.EnemyInfo
		}; // 0xC
		private static readonly MusicSelectOptionButton.OptionType[] s_collectEventOptionButtons = new MusicSelectOptionButton.OptionType[7] {
			MusicSelectOptionButton.OptionType.EvRanking,
			MusicSelectOptionButton.OptionType.EvReward,
			MusicSelectOptionButton.OptionType.EvStory,
			MusicSelectOptionButton.OptionType.EvMission,
			MusicSelectOptionButton.OptionType.Ranking,
			MusicSelectOptionButton.OptionType.MusicDetail,
			MusicSelectOptionButton.OptionType.EnemyInfo
		}; // 0x10
		private static readonly MusicSelectOptionButton.OptionType[] s_scoreEventOptionButtons = new MusicSelectOptionButton.OptionType[5] {
			MusicSelectOptionButton.OptionType.EvRanking,
			MusicSelectOptionButton.OptionType.EvReward,
			MusicSelectOptionButton.OptionType.Reward,
			MusicSelectOptionButton.OptionType.MusicDetail,
			MusicSelectOptionButton.OptionType.EnemyInfo
		}; // 0x14
		private static readonly MusicSelectOptionButton.OptionType[] s_battleEventOptionButtons = new MusicSelectOptionButton.OptionType[6] {
			MusicSelectOptionButton.OptionType.EvRanking,
			MusicSelectOptionButton.OptionType.EvReward,
			MusicSelectOptionButton.OptionType.EvStory,
			MusicSelectOptionButton.OptionType.EvMission, 
			MusicSelectOptionButton.OptionType.MusicDetail,
			MusicSelectOptionButton.OptionType.EnemyInfo
		}; // 0x18
		private static readonly MusicSelectOptionButton.OptionType[] s_simulationLiveOptionButtons = new MusicSelectOptionButton.OptionType[1]
		{ 
			MusicSelectOptionButton.OptionType.MusicDetail
		}; // 0x1C
		private static readonly MusicSelectOptionButton.OptionType[] s_endEventHomeOptionButtons = new MusicSelectOptionButton.OptionType[4] {
			MusicSelectOptionButton.OptionType.EvRanking, 
			MusicSelectOptionButton.OptionType.EvReward,
			MusicSelectOptionButton.OptionType.EvStory,
			MusicSelectOptionButton.OptionType.EvMission
		}; // 0x20
		private static readonly MusicSelectOptionButton.OptionType[] s_goDivaEventOptionButtons = new MusicSelectOptionButton.OptionType[4] {
			MusicSelectOptionButton.OptionType.EvRanking,
			MusicSelectOptionButton.OptionType.EvReward,
			MusicSelectOptionButton.OptionType.EvStory,
			MusicSelectOptionButton.OptionType.EvMission
		}; // 0x24
		private static readonly MusicSelectOptionButton.OptionType[] s_goDivaEventEndOptionButtons = new MusicSelectOptionButton.OptionType[4] {
			
			MusicSelectOptionButton.OptionType.EvRanking,
			MusicSelectOptionButton.OptionType.EvReward,
			MusicSelectOptionButton.OptionType.EvStory,
			MusicSelectOptionButton.OptionType.EvMission
		}; // 0x28
		[SerializeField]
		private List<MusicSelectOptionButton> m_optionButtons; // 0x18
		private LayoutSymbolData m_symbolMain; // 0x1C
		private List<LayoutSymbolData> m_symbolButtonStyles; // 0x20
		private List<MusicSelectOptionButton.OptionType> m_optionTypes = new List<MusicSelectOptionButton.OptionType>(5); // 0x24
		private bool m_isShow; // 0x48

		public Action onClickRankingButton { private get; set; } // 0x28
		public Action onClickRewardButton { private get; set; } // 0x2C
		public Action onClickDetailButton { private get; set; } // 0x30
		public Action onClickEventRankingButton { private get; set; } // 0x34
		public Action onClickEventRewardButton { private get; set; } // 0x38
		public Action onClickEnemyInfoButton { private get; set; } // 0x3C
		public Action onClickStoryButton { private get; set; } // 0x40
		public Action onClickMissionButton { private get; set; } // 0x44

		// // RVA: 0x166A09C Offset: 0x166A09C VA: 0x166A09C
		public void TryEnter()
		{
			if(!m_isShow)
				Enter();
		}

		// // RVA: 0x166A130 Offset: 0x166A130 VA: 0x166A130
		public void TryLeave()
		{
			if(m_isShow)
				Leave();
		}

		// // RVA: 0x166A0AC Offset: 0x166A0AC VA: 0x166A0AC
		public void Enter()
		{
			m_isShow = true;
			m_symbolMain.StartAnim("enter");
		}

		// // RVA: 0x166A140 Offset: 0x166A140 VA: 0x166A140
		public void Leave()
		{
			m_isShow = false;
			m_symbolMain.StartAnim("leave");
		}

		// // RVA: 0x166A1C4 Offset: 0x166A1C4 VA: 0x166A1C4
		// public void Show() { }

		// // RVA: 0x166A248 Offset: 0x166A248 VA: 0x166A248
		public void Hide()
		{
			m_isShow = false;
			m_symbolMain.StartAnim("wait");
		}

		// // RVA: 0x166A2CC Offset: 0x166A2CC VA: 0x166A2CC
		public bool IsPlaying()
		{
			return m_symbolMain.IsPlaying();
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
			base.InitializeFromLayout(layout, uvMan);
			m_symbolMain = CreateSymbol("main", layout);
			m_symbolButtonStyles = new List<LayoutSymbolData>(m_optionButtons.Count);
			for(int i = 0; i < m_optionButtons.Count; i++)
			{
				m_symbolButtonStyles.Add(CreateSymbol(string.Format("btn{0:D2}_style", i + 1), layout));
			}
			IsLoaded();
			return true;
		}
	}
}
