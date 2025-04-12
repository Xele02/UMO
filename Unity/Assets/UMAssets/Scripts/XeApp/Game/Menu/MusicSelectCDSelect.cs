using XeSys.Gfx;
using XeApp.Game.Common;
using UnityEngine;
using System.Collections.Generic;
using System;
using System.Collections;
using XeApp.Game.Menu.EventGoDiva;

namespace XeApp.Game.Menu
{
	public class MusicSelectCDSelect : LayoutLabelScriptBase
	{
		public enum StyleType
		{
			Multi = 0,
			Single = 1,
			None = 2,
		}
 
		public enum EventStyle
		{
			Weekly = 0,
			Disable = 1,
			None = 2,
			ExTicket = 3,
			ExEvent = 4,
			ScoreEvent = 5,
			SimulationLive = 6,
		}

		public enum DropType
		{
			None = 0,
			Ticket = 1,
			FoldRadar = 2,
		}

		public enum EventType
		{
			Weekly = 0,
			Score = 1,
			Special = 2,
			Birthday = 3,
			None = 4,
			Raid = 5,
		}

		public enum PlayButtonType
		{
			PlayEn = 0,
			Play = 1,
			Event = 2,
			Download = 3,
			Live = 4,
			Ok = 5,
		}

		public delegate void SelectionChangedCallback(int offset);
		public delegate void ScrollRepeatedCallback(int repeatDelta, int beginIndex, int endIndex);

		private static readonly int[] s_orderdJacketIndex = new int[6] { 6, 4, 2, 1, 3, 5 }; // 0x0
		public static readonly int OrderdJacketNum = s_orderdJacketIndex.Length; // 0x4
		[SerializeField]
		private ActionButton m_eventDetailButton; // 0x18
		[SerializeField]
		private List<MusicSelectCDButton> m_cdSelectButtons; // 0x1C
		[SerializeField]
		private List<MusicSelectCDJacket> m_jacketImages; // 0x20
		[SerializeField]
		private List<MusicSelectCDJacket> m_singleJacketImages; // 0x24
		[SerializeField]
		private MusicSelectCDScroller m_scroller; // 0x28
		[SerializeField]
		private MusicSelectCDCursor m_cdCursor; // 0x2C
		[SerializeField]
		private MusicSelectPlayButton m_playButton; // 0x30
		[SerializeField]
		private MusicSelectUnitButton m_unitButton; // 0x34
		private LayoutSymbolData m_symbolMain; // 0x38
		private LayoutSymbolData m_symbolStyle; // 0x3C
		private LayoutSymbolData m_symbolPlayButtonType; // 0x40
		private LayoutSymbolData m_symbolPlayButtonMain; // 0x44
		private LayoutSymbolData m_symbolCurMain; // 0x48
		private LayoutSymbolData m_symbolCurTag; // 0x4C
		private LayoutSymbolData m_symbolCurStyle; // 0x50
		private LayoutSymbolData m_symbolCurItemNum; // 0x54
		private LayoutSymbolData m_symbolCurCountExt; // 0x58
		private LayoutSymbolData m_symbolCurCountExtAnim; // 0x5C
		private LayoutSymbolData m_symbolCurItemDrop; // 0x60
		private LayoutSymbolData m_symbolCurTimeLimited; // 0x64
		private LayoutSymbolData m_symbolUnitLiveStyle; // 0x68
		private LayoutSymbolData m_symbolCurWeekRecovery; // 0x6C
		private LayoutSymbolData m_symbolCurStep; // 0x70
		private LayoutSymbolData m_symbolScroll; // 0x74
		private StyleType m_styleType; // 0x78
		private LayoutSymbolData symbolCurMain; // 0x7C
		private LayoutSymbolData symbolCurTag; // 0x80
		private LayoutSymbolData symbolCurStyle; // 0x84
		private LayoutSymbolData symbolCurItemNum; // 0x88
		private LayoutSymbolData symbolCurCountExt; // 0x8C
		private LayoutSymbolData symbolCurCountExtAnim; // 0x90
		private LayoutSymbolData symbolCurItemDrop; // 0x94
		private LayoutSymbolData symbolCurTimeLimited; // 0x98
		private LayoutSymbolData symbolUnitLiveStyle; // 0x9C
		private LayoutSymbolData symbolCurWeekRecovery; // 0xA0
		private LayoutSymbolData symbolCurStep; // 0xA4
		private MusicSelectCDCursor usingCursor; // 0xA8
		private AbsoluteLayout m_eventRankingLayout; // 0xAC
		private AbsoluteLayout m_eventGoDivaExpBonusLayout; // 0xB0
		private AbsoluteLayout m_eventGoDivaRankingLayout; // 0xB4
		private AbsoluteLayout m_eventGoDivaExpLayout; // 0xB8
		private List<int> m_eventItemId = new List<int>(); // 0xBC
		private bool m_isShow; // 0xE4

		public Action onClickEventDetailButton { private get; set; } // 0xC0
		public Action<int> onClickFlowButton { private get; set; } // 0xC4
		private Action<int> onClickUnitButton { get; set; } // 0xC8
		public SelectionChangedCallback onSelectionChanged { private get; set; } // 0xCC
		public ScrollRepeatedCallback onScrollRepeated { private get; set; } // 0xD0
		public Action<bool> onScrollStarted { private get; set; } // 0xD4
		public Action<bool> onScrollUpdated { private get; set; } // 0xD8
		public Action<bool> onScrollEnded { private get; set; } // 0xDC
		public Action onClickPlayButton { private get; set; } // 0xE0

		// // RVA: 0x167015C Offset: 0x167015C VA: 0x167015C
		public void TryEnter()
		{
			if(!m_isShow)
				Enter();
		}

		// // RVA: 0x1670208 Offset: 0x1670208 VA: 0x1670208
		public void TryLeave()
		{
			if(m_isShow)
				Leave();
		}

		// // RVA: 0x167016C Offset: 0x167016C VA: 0x167016C
		public void Enter()
		{
			m_isShow = true;
			m_scroller.InputEnable();
			m_symbolMain.StartAnim("enter");
		}

		// // RVA: 0x1670218 Offset: 0x1670218 VA: 0x1670218
		public void Leave()
		{
			m_isShow = false;
			m_scroller.InputDisable();
			m_symbolMain.StartAnim("leave");
		}

		// // RVA: 0x1670314 Offset: 0x1670314 VA: 0x1670314
		// public void Show() { }

		// // RVA: 0x16703B0 Offset: 0x16703B0 VA: 0x16703B0
		public void Hide()
		{
			m_isShow = false;
			m_scroller.InputDisable();
			m_symbolMain.StartAnim("wait");
		}

		// // RVA: 0x167044C Offset: 0x167044C VA: 0x167044C
		public bool IsPlaying()
		{
			return m_symbolMain.IsPlaying();
		}

		// // RVA: 0x1670478 Offset: 0x1670478 VA: 0x1670478
		public void MakeCache()
		{
			m_cdCursor.MakeCache();
		}

		// // RVA: 0x16704A0 Offset: 0x16704A0 VA: 0x16704A0
		public void ReleaseCache()
		{
			m_cdCursor.ReleaseCache();
		}

		// // RVA: 0x16702B4 Offset: 0x16702B4 VA: 0x16702B4
		public void ScrollEnable()
		{
			if(m_isShow)
			{
				m_scroller.InputEnable();
			}
		}

		// // RVA: 0x16702EC Offset: 0x16702EC VA: 0x16702EC
		public void ScrollDisable()
		{
			m_scroller.InputDisable();
		}

		// // RVA: 0x16704C8 Offset: 0x16704C8 VA: 0x16704C8
		public void SetupUnitLive(IBJAKJJICBC musicData, MMOLNAHHDOM saveData)
		{
			m_unitButton.Setup(musicData, saveData, (MusicSelectUnitButton.Style style) =>
			{
				//0x1673DE0
				if(m_unitButton.Hidden)
				{
					m_symbolUnitLiveStyle.StartAnim("none");
				}
				else
				{
					m_symbolUnitLiveStyle.StartAnim(style == MusicSelectUnitButton.Style.Unit ? "unit" : "solo");
				}
			});
		}

		// // RVA: 0x1670598 Offset: 0x1670598 VA: 0x1670598
		public int GetDanceDivaCount()
		{
			return m_unitButton.GetDivaCount();
		}

		// // RVA: 0x16705C4 Offset: 0x16705C4 VA: 0x16705C4
		public void RefreshJackets()
		{
			if(m_styleType == StyleType.Multi)
			{
				if(onScrollRepeated != null)
					onScrollRepeated(0, -3, 2);
			}
			else if(m_styleType == StyleType.Single)
			{
				if(onScrollRepeated != null)
					onScrollRepeated(0, 0, 0);
			}
		}

		// // RVA: 0x1670A84 Offset: 0x1670A84 VA: 0x1670A84
		public void SetStyleType(StyleType type)
		{
			if(type == StyleType.None)
			{
				m_scroller.enabled = false;
				m_symbolStyle.StartAnim("none");
				symbolCurTimeLimited = null;
				symbolUnitLiveStyle = null;
				symbolCurWeekRecovery = null;
				symbolCurStep = null;
				symbolCurCountExt = null;
				symbolCurCountExtAnim = null;
				symbolCurItemDrop = null;
				symbolCurTimeLimited = null;
				symbolCurMain = null;
				symbolCurTag = null;
				symbolCurStyle = null;
				symbolCurItemNum = null;
			}
			else
			{
				if(type == StyleType.Single)
				{
					m_scroller.enabled = false;
					m_symbolStyle.StartAnim("single");
				}
				else if(type == StyleType.Multi)
				{
					m_scroller.enabled = true;
					m_symbolStyle.StartAnim("multi");
				}
				symbolUnitLiveStyle = m_symbolUnitLiveStyle;
				symbolCurWeekRecovery = m_symbolCurWeekRecovery;
				symbolCurStep = m_symbolCurStep;
				symbolCurCountExt = m_symbolCurCountExt;
				symbolCurCountExtAnim = m_symbolCurCountExtAnim;
				symbolCurItemDrop = m_symbolCurItemDrop;
				symbolCurTimeLimited = m_symbolCurTimeLimited;
				symbolCurMain = m_symbolCurMain;
				symbolCurTag = m_symbolCurTag;
				symbolCurStyle = m_symbolCurStyle;
				symbolCurItemNum = m_symbolCurItemNum;
			}
			usingCursor = m_cdCursor;
			m_styleType = type;
		}

		// // RVA: 0x1670C44 Offset: 0x1670C44 VA: 0x1670C44
		public void ApplyCursorAttr(GameAttribute.Type attr)
		{
			if(usingCursor != null)
				usingCursor.SetAttribute(attr);
		}

		// // RVA: 0x1670CFC Offset: 0x1670CFC VA: 0x1670CFC
		public void ApplyCursorSLiveFrame()
		{
			if(usingCursor != null)
				usingCursor.SetSimulationLiveFrame();
		}

		// // RVA: 0x1670DAC Offset: 0x1670DAC VA: 0x1670DAC
		public void ShowCursorRewardMark(bool forScore, bool forCombo, bool forClearCount)
		{
			if(usingCursor != null)
				usingCursor.ShowRewardMark(forScore, forCombo, forClearCount);
		}

		// // RVA: 0x1670E7C Offset: 0x1670E7C VA: 0x1670E7C
		public void HideCursorRewardMark()
		{
			if(usingCursor != null)
			{
				usingCursor.HideRewardMark();
			}
		}

		// // RVA: 0x1670F2C Offset: 0x1670F2C VA: 0x1670F2C
		public void ApplyCursorEventType(EventType type, bool simulation/* = False*/)
		{
			if(symbolCurTag != null)
			{
				switch(type)
				{
					case EventType.Weekly:
						symbolCurTag.StartAnim("weekly");
						break;
					case EventType.Score:
						symbolCurTag.StartAnim("score");
						break;
					case EventType.Special:
						symbolCurTag.StartAnim("special");
						break;
					case EventType.Birthday:
						symbolCurTag.StartAnim("birthday");
						break;
					case EventType.None:
						symbolCurTag.StartAnim("none");
						break;
					case EventType.Raid:
						symbolCurTag.StartAnim("raid");
						break;
					default:
						break;
				}
				m_eventDetailButton.Hidden = simulation || type > EventType.Score;
			}
		}

		// // RVA: 0x1671064 Offset: 0x1671064 VA: 0x1671064
		public void ApplyCursorEventStyle(EventStyle style, bool isEventEntrance/* = False*/)
		{
			if(symbolCurStyle != null)
			{
				bool isDisable = false;
				if(usingCursor != null)
				{
					switch(style)
					{
						case EventStyle.Weekly:
							symbolCurStyle.StartAnim("weekly");
							break;
						case EventStyle.Disable:
							isDisable = true;
							symbolCurStyle.StartAnim("none");
							break;
						case EventStyle.None:
							symbolCurStyle.StartAnim("none");
							break;
						case EventStyle.ExTicket:
							symbolCurStyle.StartAnim("event_tc");
							break;
						case EventStyle.ExEvent:
							symbolCurStyle.StartAnim("event");
							break;
						case EventStyle.ScoreEvent:
							symbolCurStyle.StartAnim("event_rk");
							break;
						case EventStyle.SimulationLive:
							symbolCurStyle.StartAnim("simulation");
							break;
						default:
							symbolCurStyle.StartAnim("");
							break;
					}
					usingCursor.SetDisable(isDisable, isEventEntrance);
				}
			}
		}

		// // RVA: 0x167121C Offset: 0x167121C VA: 0x167121C
		public void ApplyDropItemType(DropType type)
		{
			if(symbolCurStyle != null && usingCursor != null)
			{
				symbolCurItemDrop.StartAnim(type == DropType.Ticket ? "show" : (type == DropType.FoldRadar ? "raid" : "hide"));
			}
		}

		// // RVA: 0x1671318 Offset: 0x1671318 VA: 0x1671318
		public void ApplyCursorEventRemainCount(int remainCount, bool isExtented/* = False*/)
		{
			if(usingCursor != null)
			{
				if(remainCount < 0)
				{
					symbolCurCountExt.StartAnim("hide");
				}
				else
				{
					usingCursor.SetRemainPlayCount(remainCount);
					if(remainCount < 1 || !isExtented)
					{
						symbolCurCountExt.StartAnim("hide");
						symbolCurCountExtAnim.StartAnim("hide");
					}
					else
					{
						symbolCurCountExt.StartAnim("show");
						symbolCurCountExtAnim.StartAnim("loop");
					}
				}
			}
		}

		// // RVA: 0x16714E4 Offset: 0x16714E4 VA: 0x16714E4
		public void ApplyCursorNew(bool isNew)
		{
			if(usingCursor != null)
				usingCursor.SetNew(isNew);
		}

		// // RVA: 0x167159C Offset: 0x167159C VA: 0x167159C
		public void ApplyCursorWeekRecoveryIcon(bool isShow)
		{
			symbolCurWeekRecovery.StartAnim(isShow ? "show" : "hide");
		}

		// // RVA: 0x1671634 Offset: 0x1671634 VA: 0x1671634
		public void ApplyCursorStepCount(int count)
		{
			if(count < 1)
			{
				symbolCurStep.StartAnim("hide");
			}
			else
			{
				symbolCurStep.StartAnim("show");
				usingCursor.SetStepCount(count);
			}
		}

		// // RVA: 0x16716FC Offset: 0x16716FC VA: 0x16716FC
		public void ApplyEventItems(List<int> itemIdList)
		{
			if(usingCursor != null)
			{
				symbolCurItemNum.GoToFrame("num", itemIdList.Count - 1);
				if(gameObject.activeInHierarchy)
				{
					this.StartCoroutineWatched(Co_LoadItemImages(itemIdList));
				}
			}
		}

		// // RVA: 0x16718F0 Offset: 0x16718F0 VA: 0x16718F0
		public void ApplyEventEndMessage(string message)
		{
			m_cdCursor.SetEndMessage(message);
		}

		// // RVA: 0x1671940 Offset: 0x1671940 VA: 0x1671940
		public void ApplyEventCounting(bool isCounting)
		{
			m_cdCursor.EnableCoutingMark(isCounting);
		}

		// // RVA: 0x1671970 Offset: 0x1671970 VA: 0x1671970
		public void ApplyEventRemainTimePrefix(string prefix)
		{
			m_cdCursor.SetRemainTimePrefix(prefix);
		}

		// // RVA: 0x16719C0 Offset: 0x16719C0 VA: 0x16719C0
		public void ApplyEventRemainTime(string time)
		{
			if(usingCursor != null)
				usingCursor.SetRemainTimeValue(time);
		}

		// // RVA: 0x1671A98 Offset: 0x1671A98 VA: 0x1671A98
		public void ApplyEventBonus(int percent)
		{
			if(usingCursor != null)
			{
				usingCursor.SetEventBonusValue(percent);
			}
		}

		// // RVA: 0x1671B50 Offset: 0x1671B50 VA: 0x1671B50
		public void ApplyMusicRatio(int ratio, bool isVisible)
		{
			if(usingCursor != null)
			{
				usingCursor.SetMusicRatio(ratio);
				usingCursor.SetMusicRatioVisibility(isVisible);
			}
		}

		// // RVA: 0x1671C2C Offset: 0x1671C2C VA: 0x1671C2C
		public void SetEventTicketIcon(IiconTexture image)
		{
			if(usingCursor != null)
				usingCursor.SetEventTicket(image);
		}

		// // RVA: 0x1671CE4 Offset: 0x1671CE4 VA: 0x1671CE4
		public void EventTicketEnable(bool _enable)
		{
			usingCursor.EventTicketEnable(_enable);
		}

		// // RVA: 0x1671D14 Offset: 0x1671D14 VA: 0x1671D14
		public void SetEventItemIcon(IiconTexture image)
		{
			if(usingCursor != null)
				usingCursor.SetEventItem(image);
		}

		// // RVA: 0x1671DCC Offset: 0x1671DCC VA: 0x1671DCC
		public void ApplyEventTicketCount(int count)
		{
			if(usingCursor != null)
				usingCursor.SetTicketCount(count);
		}

		// // RVA: 0x1671EA8 Offset: 0x1671EA8 VA: 0x1671EA8
		public void ApplyEventRank(int rank)
		{
			if(usingCursor != null)
				usingCursor.SetRankValue(rank);
		}

		// // RVA: 0x1671F60 Offset: 0x1671F60 VA: 0x1671F60
		public void ApplyCursorLimited(bool isLimited)
		{
			if(usingCursor != null)
			{
				symbolCurTimeLimited.StartAnim(isLimited ? "limited" : "none");
			}
		}

		// // RVA: 0x1672040 Offset: 0x1672040 VA: 0x1672040
		public void EnableEventMusicRank(bool isEnable)
		{
			m_eventRankingLayout.StartChildrenAnimGoStop(isEnable ? "01" : "02");
		}

		// // RVA: 0x16720D4 Offset: 0x16720D4 VA: 0x16720D4
		public void ApplyEventMusicRank(int rank)
		{
			if(usingCursor != null)
				usingCursor.SetEventMusicRank(rank);
		}

		// // RVA: 0x167218C Offset: 0x167218C VA: 0x167218C
		public void EnableEventGoDivaExpBonus(bool isEnable)
		{
			m_eventGoDivaExpBonusLayout.StartChildrenAnimGoStop(isEnable ? "01" : "02");
		}

		// // RVA: 0x1672220 Offset: 0x1672220 VA: 0x1672220
		public void ApplyEventGoDivaExpBonus(float bonus)
		{
			if(usingCursor != null)
				usingCursor.SetEventGoDivaExpBonus(bonus);
		}

		// // RVA: 0x16722D8 Offset: 0x16722D8 VA: 0x16722D8
		public void EnableEventGoDivaRanking(bool isEnable)
		{
			m_eventGoDivaRankingLayout.StartChildrenAnimGoStop(isEnable ? "01" : "02");
		}

		// // RVA: 0x167236C Offset: 0x167236C VA: 0x167236C
		public void ApplyEventGoDivaRank(int rank)
		{
			if(usingCursor != null)
				usingCursor.SetEventGoDivaRank(rank);
		}

		// // RVA: 0x1672424 Offset: 0x1672424 VA: 0x1672424
		public void SetEventGoDivaExpType(ExpType expType)
		{
			m_eventGoDivaExpLayout.StartChildrenAnimGoStop(expType < ExpType.Num ? new string[4]{"01", "02", "03", "04"}[(int)expType] : "05");
		}

		// // RVA: 0x16724C4 Offset: 0x16724C4 VA: 0x16724C4
		public void HideEventFoDivaExp()
		{
			SetEventGoDivaExpType(ExpType.None);
		}

		// // RVA: 0x16724CC Offset: 0x16724CC VA: 0x16724CC
		public void ApplyEventGoDivaExp(int exp)
		{
			if(usingCursor != null)
				usingCursor.SetEventGoDivaExp(exp);
		}

		// // RVA: 0x1672584 Offset: 0x1672584 VA: 0x1672584
		public void ChangeJacket(int order, int jacketId, GameAttribute.Type attr, bool forEvent/* = False*/)
		{
			if(m_styleType == StyleType.Multi)
			{
				for(int i = 0; i < m_jacketImages.Count; i++)
				{
					if(m_jacketImages[i].jacketIndex == s_orderdJacketIndex[order])
					{
						m_jacketImages[i].Show();
						m_jacketImages[i].ChangeJacket(jacketId, attr, forEvent);
					}
				}
			}
			else
			{
				if(m_styleType == StyleType.Single)
				{
					for(int i = 0; i < m_singleJacketImages.Count; i++)
					{
						m_singleJacketImages[i].Show();
						m_singleJacketImages[i].ChangeJacket(jacketId, attr, forEvent);
					}
				}
			}
		}

		// // RVA: 0x16727D8 Offset: 0x16727D8 VA: 0x16727D8
		public void HideJacket(int order)
		{
			if(m_styleType == StyleType.Multi)
			{
				for(int i = 0; i < m_jacketImages.Count; i++)
				{
					if(m_jacketImages[i].jacketIndex == s_orderdJacketIndex[order])
					{
						m_jacketImages[i].Hide();	
					}
				}
			}
			else
			{
				if(m_styleType == StyleType.Single)
				{
					for(int i = 0; i < m_singleJacketImages.Count; i++)
					{
						m_singleJacketImages[i].Hide();
					}
				}
			}
		}

		// // RVA: 0x16729DC Offset: 0x16729DC VA: 0x16729DC
		public void RequestLeftFlow(int pageOffset, float flowSec, Action onEnd)
		{
			m_scroller.RequestFlow(-pageOffset, flowSec, onEnd);
		}

		// // RVA: 0x1672A24 Offset: 0x1672A24 VA: 0x1672A24
		public void RequestRightFlow(int pageOffset, float flowSec, Action onEnd)
		{
			m_scroller.RequestFlow(pageOffset, flowSec, onEnd);
		}

		// // RVA: 0x1672A6C Offset: 0x1672A6C VA: 0x1672A6C
		public void SetScrollLimit(int leftLimitPage, int rightLimitPage)
		{
			m_scroller.SetLimit(leftLimitPage, rightLimitPage);
		}

		// // RVA: 0x1672AD0 Offset: 0x1672AD0 VA: 0x1672AD0
		public void ClearScrollLimit()
		{
			m_scroller.ClearLimit();
		}

		// // RVA: 0x1672B04 Offset: 0x1672B04 VA: 0x1672B04
		public bool CheckLeftLimitPage()
		{
			return m_scroller.CheckOnLeftLimitPage();
		}

		// // RVA: 0x1672B5C Offset: 0x1672B5C VA: 0x1672B5C
		public bool CheckRightLimitPage()
		{
			return m_scroller.CheckOnRightLimitPage();
		}

		// // RVA: 0x1672BB4 Offset: 0x1672BB4 VA: 0x1672BB4
		public void SetPlayButtonType(PlayButtonType type)
		{
			switch(type)
			{
				case PlayButtonType.PlayEn:
					m_symbolPlayButtonType.StartAnim("play_en");
					m_playButton.SetDLMessage(false);
					break;
				case PlayButtonType.Play:
					m_symbolPlayButtonType.StartAnim("play");
					m_playButton.SetDLMessage(false);
					break;
				case PlayButtonType.Event:
					m_symbolPlayButtonType.StartAnim("event");
					m_playButton.SetDLMessage(false);
					break;
				case PlayButtonType.Download:
					m_symbolPlayButtonType.StartAnim("dl");
					m_playButton.SetDLMessage(true);
					break;
				case PlayButtonType.Live:
					m_symbolPlayButtonType.StartAnim("live");
					m_playButton.SetDLMessage(false);
					break;
				case PlayButtonType.Ok:
					m_symbolPlayButtonType.StartAnim("ok");
					m_playButton.SetDLMessage(false);
					break;
				default:
					m_symbolPlayButtonType.StartAnim(string.Empty);
					m_playButton.SetDLMessage(false);
					break;
			}
		}

		// // RVA: 0x1672CF8 Offset: 0x1672CF8 VA: 0x1672CF8
		public void SetPlayButtonDisable(bool isDisable)
		{
			m_playButton.Disable = isDisable;
		}

		// // RVA: 0x1672D2C Offset: 0x1672D2C VA: 0x1672D2C
		public void EnterPlayButton(bool immediate/* = False*/)
		{
			m_symbolPlayButtonMain.StartAnim(immediate ? "active" : "enter");
		}

		// // RVA: 0x1672DC4 Offset: 0x1672DC4 VA: 0x1672DC4
		public void LeavePlayButton(bool immediate/* = False*/)
		{
			m_symbolPlayButtonMain.StartAnim(immediate ? "wait" : "leave");
		}

		// // RVA: 0x1672E5C Offset: 0x1672E5C VA: 0x1672E5C
		public void SetNeedEnergy(int energy)
		{
			m_playButton.SetNeedEnergy(energy);
		}

		// // RVA: 0x1672E8C Offset: 0x1672E8C VA: 0x1672E8C
		private void OnSelectionChanged(int offset)
		{
			if(onSelectionChanged != null)
				onSelectionChanged(offset);
		}

		// // RVA: 0x1673300 Offset: 0x1673300 VA: 0x1673300
		public void OnScrollRepeated(int repeatDelta, bool isSelectionFlipped)
		{
			if(onScrollRepeated != null)
				onScrollRepeated(repeatDelta, isSelectionFlipped ? -2 : -3, isSelectionFlipped ? 3 : 2);
		}

		// // RVA: 0x167333C Offset: 0x167333C VA: 0x167333C
		public void OnScrollStarted(bool isAuto)
		{
			if(symbolCurMain != null)
				symbolCurMain.StartAnim("hide");
			if(onScrollStarted != null)
				onScrollStarted(isAuto);
		}

		// // RVA: 0x16733D4 Offset: 0x16733D4 VA: 0x16733D4
		public void OnScrollUpdated(bool isAuto)
		{
			if(onScrollUpdated != null)
				onScrollUpdated(isAuto);
		}

		// // RVA: 0x1673448 Offset: 0x1673448 VA: 0x1673448
		public void OnScrollEnded(bool isAuto)
		{
			symbolCurMain.StartAnim("show");
			if(onScrollEnded != null)
				onScrollEnded(isAuto);
		}

		// [IteratorStateMachineAttribute] // RVA: 0x6F344C Offset: 0x6F344C VA: 0x6F344C
		// // RVA: 0x16734E0 Offset: 0x16734E0 VA: 0x16734E0
		private IEnumerator Co_Initialize()
		{
			//0x16741A0
			while(!m_eventDetailButton.IsLoaded())
				yield return null;

			for(int i = 0; i < m_cdSelectButtons.Count; i++)
			{
				while(!m_cdSelectButtons[i].IsLoaded())
					yield return null;
			}
			for(int i = 0; i < m_jacketImages.Count; i++)
			{
				while(!m_jacketImages[i].IsLoaded())
					yield return null;
			}
			for(int i = 0; i < m_singleJacketImages.Count; i++)
			{
				while(!m_singleJacketImages[i].IsLoaded())
					yield return null;
			}

			m_eventDetailButton.AddOnClickCallback(() => {
				//0x1673ECC
				if(onClickEventDetailButton != null)
					onClickEventDetailButton();
			});
			for(int i = 0; i < m_cdSelectButtons.Count; i++)
			{
				m_cdSelectButtons[i].onSelectButton = (int offset) => {
					//0x1673EE0
					if(onClickFlowButton != null)
						onClickFlowButton(offset);
				};

			}
			while(!m_scroller.IsLoaded())
				yield return null;
			while(!m_cdCursor.IsLoaded())
				yield return null;
			SetPlayButtonType(PlayButtonType.Play);
			Loaded();
		}

		// [IteratorStateMachineAttribute] // RVA: 0x6F34C4 Offset: 0x6F34C4 VA: 0x6F34C4
		// // RVA: 0x1671848 Offset: 0x1671848 VA: 0x1671848
		private IEnumerator Co_LoadItemImages(List<int> itemIdList)
		{
			//0x16747E0
			if(usingCursor != null)
				usingCursor.ResetEventItem();
			m_eventItemId.Clear();
			m_eventItemId.AddRange(itemIdList);
			for(int i = 0; i < itemIdList.Count; i++)
			{
				int idx = i;
				GameManager.Instance.ItemTextureCache.Load(itemIdList[i], (IiconTexture image) =>
				{
					//0x1673F78
					if(usingCursor != null && idx < m_eventItemId.Count && m_eventItemId[idx] == itemIdList[idx])
						usingCursor.ApplyEventItem(i, image);
				});
				while(GameManager.Instance.ItemTextureCache.IsLoading())
					yield return null;
			}
		}

		// // RVA: 0x16735AC Offset: 0x16735AC VA: 0x16735AC Slot: 5
		public override bool InitializeFromLayout(Layout layout, TexUVListManager uvMan)
		{
			base.InitializeFromLayout(layout, uvMan);
			m_symbolMain = CreateSymbol("main", layout);
			m_symbolStyle = CreateSymbol("style", layout);
			m_symbolCurMain = CreateSymbol("cur_main", layout);
			m_symbolCurTag = CreateSymbol("cur_tag", layout);
			m_symbolCurStyle = CreateSymbol("cur_style", layout);
			m_symbolCurItemNum = CreateSymbol("cur_item_num", layout);
			m_symbolCurCountExt = CreateSymbol("cur_count_ext", layout);
			m_symbolCurCountExtAnim = CreateSymbol("cur_count_ext_anim", layout);
			m_symbolCurItemDrop = CreateSymbol("cur_item_drop", layout);
			m_symbolCurTimeLimited = CreateSymbol("cur_time_limited", layout);
			m_symbolUnitLiveStyle = CreateSymbol("unitlive_style", layout);
			m_symbolCurWeekRecovery = CreateSymbol("cur_week_recovery", layout);
			m_symbolCurStep = CreateSymbol("cur_step", layout);
			m_symbolScroll = CreateSymbol("m_scroll", layout);
			m_symbolPlayButtonType = CreateSymbol("btn_play_type", layout);
			m_symbolPlayButtonMain = CreateSymbol("btn_play_main", layout);
			
			m_scroller.onSelectionChanged = this.OnSelectionChanged;
			m_scroller.onScrollRepeated = this.OnScrollRepeated;
			m_scroller.onScrollStarted = this.OnScrollStarted;
			m_scroller.onScrollUpdated = this.OnScrollUpdated;
			m_scroller.onScrollEnded = this.OnScrollEnded;

			m_eventRankingLayout = layout.FindViewByExId("swtbl_sel_music_eve_week_swtbl_sel_music_eve_rank") as AbsoluteLayout;
			m_eventGoDivaExpBonusLayout = layout.FindViewById("sw_exp_fnt_onoff_anim") as AbsoluteLayout;
			m_eventGoDivaRankingLayout = layout.FindViewById("sw_s_m_eve_rank_diva_onoff_anim") as AbsoluteLayout;
			m_eventGoDivaExpLayout = layout.FindViewById("swtbl_sel_me3_icon") as AbsoluteLayout;

			m_playButton.AddOnClickCallback(() => {
				//0x1673F54
				if(onClickPlayButton != null)
					onClickPlayButton();
			});
			this.StartCoroutineWatched(Co_Initialize());
			return true;
		}
	}
}
