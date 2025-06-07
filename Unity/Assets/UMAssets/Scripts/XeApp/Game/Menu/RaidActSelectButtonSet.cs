using XeSys.Gfx;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace XeApp.Game.Menu
{
	public class RaidActSelectButtonSet : LayoutLabelScriptBase
	{
		public enum OptionStyle
		{
			None = 0,
			Basic = 1,
			QuestEvent = 2,
			QuestEventInfo = 3,
			CollectEvent = 4,
			ScoreEvent = 5,
			BattleEvent = 6,
			SimulationLive = 7,
			EndEventHome = 8,
			RaidEvent = 9,
		}

		private static readonly RaidActSelectOptionButton.OptionType[] s_emptyOptionButtons = null; // 0x0
		private static readonly RaidActSelectOptionButton.OptionType[] s_basicOptionButtons = new RaidActSelectOptionButton.OptionType[4]
		{
			RaidActSelectOptionButton.OptionType.Ranking,
			RaidActSelectOptionButton.OptionType.Reward,
			RaidActSelectOptionButton.OptionType.MusicDetail,
			RaidActSelectOptionButton.OptionType.EnemyInfo
		}; // 0x4
		private static readonly RaidActSelectOptionButton.OptionType[] s_questEventOptionButtons = new RaidActSelectOptionButton.OptionType[4]
		{
			RaidActSelectOptionButton.OptionType.EvRanking,
			RaidActSelectOptionButton.OptionType.EvReward,
			RaidActSelectOptionButton.OptionType.EvStory,
			RaidActSelectOptionButton.OptionType.EvMission
		}; // 0x8
		private static readonly RaidActSelectOptionButton.OptionType[] s_questEventInfoOptionButtons = new RaidActSelectOptionButton.OptionType[6]
		{
			RaidActSelectOptionButton.OptionType.EvRanking,
			RaidActSelectOptionButton.OptionType.EvReward,
			RaidActSelectOptionButton.OptionType.Ranking,
			RaidActSelectOptionButton.OptionType.Reward,
			RaidActSelectOptionButton.OptionType.MusicDetail,
			RaidActSelectOptionButton.OptionType.EnemyInfo
		}; // 0xC
		private static readonly RaidActSelectOptionButton.OptionType[] s_collectEventOptionButtons = new RaidActSelectOptionButton.OptionType[7]
		{
			RaidActSelectOptionButton.OptionType.EvRanking,
			RaidActSelectOptionButton.OptionType.EvReward,
			RaidActSelectOptionButton.OptionType.EvStory,
			RaidActSelectOptionButton.OptionType.EvMission,
			RaidActSelectOptionButton.OptionType.Ranking,
			RaidActSelectOptionButton.OptionType.MusicDetail,
			RaidActSelectOptionButton.OptionType.EnemyInfo
		}; // 0x10
		private static readonly RaidActSelectOptionButton.OptionType[] s_scoreEventOptionButtons = new RaidActSelectOptionButton.OptionType[5]
		{
			RaidActSelectOptionButton.OptionType.EvRanking,
			RaidActSelectOptionButton.OptionType.EvReward,
			RaidActSelectOptionButton.OptionType.Reward,
			RaidActSelectOptionButton.OptionType.MusicDetail,
			RaidActSelectOptionButton.OptionType.EnemyInfo
		}; // 0x14
		private static readonly RaidActSelectOptionButton.OptionType[] s_battleEventOptionButtons = new RaidActSelectOptionButton.OptionType[6]
		{
			RaidActSelectOptionButton.OptionType.EvRanking,
			RaidActSelectOptionButton.OptionType.EvReward,
			RaidActSelectOptionButton.OptionType.EvStory,
			RaidActSelectOptionButton.OptionType.EvMission,
			RaidActSelectOptionButton.OptionType.MusicDetail,
			RaidActSelectOptionButton.OptionType.EnemyInfo
		}; // 0x18
		private static readonly RaidActSelectOptionButton.OptionType[] s_simulationLiveOptionButtons = new RaidActSelectOptionButton.OptionType[1]
		{
			RaidActSelectOptionButton.OptionType.MusicDetail
		}; // 0x1C
		private static readonly RaidActSelectOptionButton.OptionType[] s_endEventHomeOptionButtons = new RaidActSelectOptionButton.OptionType[4]
		{
			RaidActSelectOptionButton.OptionType.EvRanking,
			RaidActSelectOptionButton.OptionType.EvReward,
			RaidActSelectOptionButton.OptionType.EvStory,
			RaidActSelectOptionButton.OptionType.EvMission
		}; // 0x20
		private static readonly RaidActSelectOptionButton.OptionType[] s_raidEventOptionButtons = new RaidActSelectOptionButton.OptionType[4]
		{
			RaidActSelectOptionButton.OptionType.EvMvp,
			RaidActSelectOptionButton.OptionType.EvRewardList,
			RaidActSelectOptionButton.OptionType.EvMission,
			RaidActSelectOptionButton.OptionType.MusicDetail
		}; // 0x24
		[SerializeField]
		private List<RaidActSelectOptionButton> m_optionButtons; // 0x18
		private LayoutSymbolData m_symbolMain; // 0x1C
		private List<LayoutSymbolData> m_symbolButtonStyles; // 0x20
		private List<RaidActSelectOptionButton.OptionType> m_optionTypes = new List<RaidActSelectOptionButton.OptionType>(); // 0x24
		private bool m_isShow; // 0x4C

		public Action onClickRankingButton { private get; set; }  // 0x28
		public Action onClickRewardButton { private get; set; } // 0x2C
		public Action onClickDetailButton { private get; set; } // 0x30
		public Action onClickEventRankingButton { private get; set; } // 0x34
		public Action onClickEventRewardButton { private get; set; } // 0x38
		public Action onClickEnemyInfoButton { private get; set; } // 0x3C
		public Action onClickStoryButton { private get; set; } // 0x40
		public Action onClickMissionButton { private get; set; } // 0x44
		public Action onClickMvpButton { private get; set; } // 0x48

		// // RVA: 0x144BCBC Offset: 0x144BCBC VA: 0x144BCBC
		// public void TryEnter() { }

		// // RVA: 0x144BD50 Offset: 0x144BD50 VA: 0x144BD50
		// public void TryLeave() { }

		// RVA: 0x144BCCC Offset: 0x144BCCC VA: 0x144BCCC
		public void Enter()
		{
			m_isShow = true;
			m_symbolMain.StartAnim("enter");
		}

		// RVA: 0x144BD60 Offset: 0x144BD60 VA: 0x144BD60
		public void Leave()
		{
			m_isShow = false;
			m_symbolMain.StartAnim("leave");
		}

		// // RVA: 0x144BDE4 Offset: 0x144BDE4 VA: 0x144BDE4
		// public void Show() { }

		// // RVA: 0x144BE68 Offset: 0x144BE68 VA: 0x144BE68
		// public void Hide() { }

		// RVA: 0x144BEEC Offset: 0x144BEEC VA: 0x144BEEC
		public bool IsPlaying()
		{
			return m_symbolMain.IsPlaying();			
		}

		// RVA: 0x144BF18 Offset: 0x144BF18 VA: 0x144BF18
		public void SetOptionStyle(OptionStyle style, bool withoutRanking/* = False*/, bool withoutReward/* = False*/, bool withoutEvRanking/* = False*/, bool withoutMission/* = False*/)
		{
			switch(style)
			{
				case OptionStyle.Basic:
					m_optionTypes.AddRange(s_basicOptionButtons);
					break;
				case OptionStyle.QuestEvent:
					m_optionTypes.AddRange(s_questEventOptionButtons);
					break;
				case OptionStyle.QuestEventInfo:
					m_optionTypes.AddRange(s_questEventInfoOptionButtons);
					break;
				case OptionStyle.CollectEvent:
					m_optionTypes.AddRange(s_collectEventOptionButtons);
					break;
				case OptionStyle.ScoreEvent:
					m_optionTypes.AddRange(s_scoreEventOptionButtons);
					break;
				case OptionStyle.BattleEvent:
					m_optionTypes.AddRange(s_battleEventOptionButtons);
					break;
				case OptionStyle.SimulationLive:
					m_optionTypes.AddRange(s_simulationLiveOptionButtons);
					break;
				case OptionStyle.EndEventHome:
					m_optionTypes.AddRange(s_endEventHomeOptionButtons);
					break;
				case OptionStyle.RaidEvent:
					m_optionTypes.AddRange(s_raidEventOptionButtons);
					break;
			}
			if(withoutRanking)
			{
				m_optionTypes.Remove(RaidActSelectOptionButton.OptionType.Ranking);
			}
			if(withoutReward)
			{
				m_optionTypes.Remove(RaidActSelectOptionButton.OptionType.Reward);
			}
			if(withoutEvRanking)
			{
				m_optionTypes.Remove(RaidActSelectOptionButton.OptionType.EvRanking);
			}
			if(withoutMission)
			{
				m_optionTypes.Remove(RaidActSelectOptionButton.OptionType.EvMission);
			}
			ApplyOptionButtons(m_optionTypes, style);
			m_optionTypes.Clear();
		}

		// RVA: 0x144C9F8 Offset: 0x144C9F8 VA: 0x144C9F8
		public void SetEnemyHasSkill(bool hasSkill)
		{
			for(int i = 0; i < m_optionButtons.Count; i++)
			{
				m_optionButtons[i].ApplyEnemyDanger(hasSkill);
			}
		}

		// RVA: 0x144CBD0 Offset: 0x144CBD0 VA: 0x144CBD0
		public void SetBadge(RaidActSelectOptionButton.OptionType optionType, bool isOn)
		{
			RaidActSelectOptionButton btn = m_optionButtons.Find((RaidActSelectOptionButton x) =>
			{
				//0x144DA04
				return x.GetOptionType() == optionType;
			});
			if(btn != null)
			{
				btn.SetBadge(isOn);
			}
		}

		// // RVA: 0x144CD6C Offset: 0x144CD6C VA: 0x144CD6C
		// public void SetEventRankingCountin(bool isCounting) { }

		// // RVA: 0x144C498 Offset: 0x144C498 VA: 0x144C498
		private void ApplyOptionButtons(List<RaidActSelectOptionButton.OptionType> types, OptionStyle style)
		{
			int a = 0;
			if(types != null)
			{
				a = types.Count;
			}
			if(style == OptionStyle.QuestEvent)
			{
				int v = (m_optionButtons.Count / types.Count) - 1;
				for(int i = 0; i < m_optionButtons.Count; i++)
				{
					m_optionButtons[i].ClearOnClickCallback();
					m_optionButtons[i].Hidden = true;
				}
				if(v < 0)
					v = 0;
				for(int i = 0; i < types.Count; i++)
				{
					if(i < a)
					{
						m_optionButtons[v + i].Hidden = false;
						m_optionButtons[v + i].Disable = false;
						m_optionButtons[v + i].ApplyEnemyDanger(false);
						m_optionButtons[v + i].SetBadge(false);
						ApplyOptionButton(m_optionButtons[v + i], types[i], m_symbolButtonStyles[v + i]);
					}
				}
			}
			else
			{
				for(int i = 0; i < m_optionButtons.Count; i++)
				{
					m_optionButtons[i].ClearOnClickCallback();
					if(i < a)
					{
						m_optionButtons[i].Hidden = false;
						m_optionButtons[i].Disable = false;
						m_optionButtons[i].ApplyEnemyDanger(false);
						m_optionButtons[i].SetBadge(false);
						ApplyOptionButton(m_optionButtons[i], types[i], m_symbolButtonStyles[i]);
					}
					else
					{
						m_optionButtons[i].Hidden = true;
					}
				}
			}
		}

		// // RVA: 0x144CF30 Offset: 0x144CF30 VA: 0x144CF30
		private void ApplyOptionButton(RaidActSelectOptionButton button, RaidActSelectOptionButton.OptionType optionType, LayoutSymbolData symbolStyle)
		{
			button.ApplyOptionType(optionType);
			symbolStyle.StartAnim(button.IsEventType() ? "event" : "basic");
			switch(optionType)
			{
				case RaidActSelectOptionButton.OptionType.Ranking:
					button.AddOnClickCallback(OnClickRanking);
					break;
				case RaidActSelectOptionButton.OptionType.Reward:
					button.AddOnClickCallback(OnClickReward);
					break;
				case RaidActSelectOptionButton.OptionType.MusicDetail:
					button.AddOnClickCallback(OnClickMusicDetail);
					break;
				case RaidActSelectOptionButton.OptionType.EvRanking:
					button.AddOnClickCallback(OnClickEventRanking);
					break;
				case RaidActSelectOptionButton.OptionType.EvReward:
					button.AddOnClickCallback(OnClickEventReward);
					break;
				case RaidActSelectOptionButton.OptionType.EnemyInfo:
					button.AddOnClickCallback(OnClickEnemyInfo);
					break;
				case RaidActSelectOptionButton.OptionType.EvStory:
					button.AddOnClickCallback(OnClickStory);
					break;
				case RaidActSelectOptionButton.OptionType.EvMission:
					button.AddOnClickCallback(OnClickMission);
					break;
				case RaidActSelectOptionButton.OptionType.EvMvp:
					button.AddOnClickCallback(OnClickMvp);
					break;
				case RaidActSelectOptionButton.OptionType.EvRewardList:
					button.AddOnClickCallback(OnClickEventReward);
					break;
			}
		}

		// // RVA: 0x144D3B8 Offset: 0x144D3B8 VA: 0x144D3B8
		private void OnClickRanking()
		{
			if(onClickRankingButton != null)
				onClickRankingButton();
		}

		// // RVA: 0x144D3CC Offset: 0x144D3CC VA: 0x144D3CC
		private void OnClickReward()
		{
			if(onClickRewardButton != null)
				onClickRewardButton();
		}

		// // RVA: 0x144D3E0 Offset: 0x144D3E0 VA: 0x144D3E0
		private void OnClickMusicDetail()
		{
			if(onClickDetailButton != null)
				onClickDetailButton();
		}

		// // RVA: 0x144D3F4 Offset: 0x144D3F4 VA: 0x144D3F4
		private void OnClickEventRanking()
		{
			if(onClickEventRankingButton != null)
				onClickEventRankingButton();
		}

		// // RVA: 0x144D408 Offset: 0x144D408 VA: 0x144D408
		private void OnClickEventReward()
		{
			if(onClickEventRewardButton != null)
				onClickEventRewardButton();
		}

		// // RVA: 0x144D41C Offset: 0x144D41C VA: 0x144D41C
		private void OnClickEnemyInfo()
		{
			if(onClickEnemyInfoButton != null)
				onClickEnemyInfoButton();
		}

		// // RVA: 0x144D430 Offset: 0x144D430 VA: 0x144D430
		private void OnClickStory()
		{
			if(onClickStoryButton != null)
				onClickStoryButton();
		}

		// // RVA: 0x144D444 Offset: 0x144D444 VA: 0x144D444
		private void OnClickMission()
		{
			if(onClickMissionButton != null)
				onClickMissionButton();
		}

		// // RVA: 0x144D458 Offset: 0x144D458 VA: 0x144D458
		private void OnClickMvp()
		{
			if(onClickMvpButton != null)
				onClickMvpButton();
		}

		// RVA: 0x144D46C Offset: 0x144D46C VA: 0x144D46C Slot: 5
		public override bool InitializeFromLayout(Layout layout, TexUVListManager uvMan)
		{
			base.InitializeFromLayout(layout, uvMan);
			m_symbolMain = CreateSymbol("main", layout);
			m_symbolButtonStyles = new List<LayoutSymbolData>(m_optionButtons.Count);
			for(int i = 0; i < m_optionButtons.Count; i++)
			{
				m_symbolButtonStyles.Add(CreateSymbol(string.Format("btn{0:D2}_style", i + 1), layout));
			}
			Loaded();
			return true;
		}
	}
}
