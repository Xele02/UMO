using XeSys.Gfx;
using UnityEngine;
using UnityEngine.UI;
using XeApp.Game.Common;
using System.Collections.Generic;
using System;
using XeSys;
using System.Collections;

namespace XeApp.Game.Menu
{
	public class OfferSelectList : LayoutUGUIScriptBase
	{
		public enum OfferSelectTab
		{
			DivaTab = 0,
			WeeklyTab = 1,
			DaylyTab = 2,
			DebutTab = 3,
			MAX = 4,
		}

		public enum OfferSelectTabLimitText
		{
			Weekly_ON = 0,
			Weekly_OFF = 1,
			Dayly_ON = 2,
			Dayly_OFF = 3,
		}

		private const float LIST_SLIDE_LEAVE_TIME = 0.2f;
		private const float LIST_SLIDE_ENTER_TIME = 1;
		[SerializeField]
		private LayoutUGUIScrollSupport m_scrollSupport; // 0x14
		[SerializeField]
		private Text[] m_times; // 0x18
		[SerializeField]
		private Text nonListItemtext; // 0x1C
		[SerializeField]
		private ActionButton[] operationTabList = new ActionButton[4]; // 0x20
		[SerializeField]
		private SwapScrollList m_scrollList; // 0x24
		[SerializeField]
		private Transform ListContent; // 0x28
		[SerializeField]
		private NumberBase m_MaxDebutNum; // 0x2C
		[SerializeField]
		private NumberBase m_ClearDebutNum; // 0x30
		[SerializeField]
		private GameObject m_scrollBar; // 0x34
		private AbsoluteLayout m_layoutRoot; // 0x38
		private AbsoluteLayout m_probabilityIcon; // 0x3C
		private AbsoluteLayout[] m_tab = new AbsoluteLayout[4]; // 0x40
		private AbsoluteLayout LateUpIcon; // 0x44
		private AbsoluteLayout NonListItemTextLayout; // 0x48
		private AbsoluteLayout m_debutTab; // 0x4C
		private AbsoluteLayout m_layoutGauge; // 0x50
		private AbsoluteLayout m_debutClearIcon; // 0x54
		private AbsoluteLayout m_tabState; // 0x58
		private AbsoluteLayout m_kadoMaru_on; // 0x5C
		private AbsoluteLayout m_kadoMaru_off; // 0x60
		private AbsoluteLayout[] m_buttonLayouts; // 0x64
		private AbsoluteLayout m_buttonParentLayout; // 0x68
		private AbsoluteLayout[] m_badgeParentLayouts; // 0x6C
		private GameObject[] m_badgeParentObject; // 0x70
		private BadgeIcon[] m_badgeIcons; // 0x74
		private List<HEFCLPGPMLK.AAOPGOGGMID> viewList; // 0x78
		private HEFCLPGPMLK m_view; // 0x7C
		private OfferSelectContent content; // 0x80
		private LimitTimeWatcher m_timeWatcherDayly = new LimitTimeWatcher(); // 0x84
		private LimitTimeWatcher m_timeWatcherWeekly = new LimitTimeWatcher(); // 0x88
		private Action<int> OrderAction; // 0x8C
		private Action<int> ProgressAction; // 0x90
		private Action<int> DoneAction; // 0x94
		private Action ItemDetailOpen; // 0x98
		private Action ItemDetailClose; // 0x9C
		private Action startListUpdateAct; // 0xA0
		private bool IsBeginner; // 0xA4
		private bool IsGetNewValkyrie; // 0xA5
		private bool IsUnlockDivaOffer; // 0xA6
		public OfferSelectTab SelectTab = OfferSelectTab.DaylyTab; // 0xA8
		private int m_frameCount; // 0xAC
		private bool isStartListUpdate; // 0xB0
		public bool IsExitBefore; // 0xB1

		public SwapScrollList List { get { return m_scrollList; } } //0x16FEC38

		// RVA: 0x1705D54 Offset: 0x1705D54 VA: 0x1705D54
		private void Start()
		{
			return;
		}

		// RVA: 0x1705D58 Offset: 0x1705D58 VA: 0x1705D58
		public void settingTab()
		{
			SelectTab = OfferSelectTab.DebutTab;
			if (KDHGBOOECKC.HHCJCDFCLOB.NPIJHJNCBGM() != BOPFPIHGJMD.MLBMHDCCGHI.GENEIBGNMPH_4_Debut && !IsBeginner)
			{
				BOPFPIHGJMD.MLBMHDCCGHI a = KDHGBOOECKC.HHCJCDFCLOB.NPIJHJNCBGM();
				SelectTab = (OfferSelectTab)(a - 1);
				if (a != BOPFPIHGJMD.MLBMHDCCGHI.FDOOAJLGFAE_2_Week)
				{
					SelectTab = OfferSelectTab.DivaTab;
					if(a != BOPFPIHGJMD.MLBMHDCCGHI.FMLPIOFBCMA_3_Diva)
					{
						SelectTab = (OfferSelectTab)(a - 1);
						if (a != BOPFPIHGJMD.MLBMHDCCGHI.GENEIBGNMPH_4_Debut)
							SelectTab = OfferSelectTab.DaylyTab;
					}
				}
			}
		}

		// RVA: 0x1705E24 Offset: 0x1705E24 VA: 0x1705E24
		public void Initialize()
		{
			InitializeBadge();
			IsExitBefore = false;
			IsGetNewValkyrie = !KDHGBOOECKC.HHCJCDFCLOB.AHKAIKMNKJL();
			IsBeginner = m_view.OHILPCDFKCH();
			if (!IsBeginner)
				IsBeginner = IsGetNewValkyrie;
			IsUnlockDivaOffer = KDHGBOOECKC.HHCJCDFCLOB.MGHPDFMDFCJ();
			InitializeList();
			initializeTime();
			initializeTab();
			probailtyAnimEnable(KDHGBOOECKC.HHCJCDFCLOB.JAMKJBMGAGI());
		}

		//// RVA: 0x170607C Offset: 0x170607C VA: 0x170607C
		public void initializeTime()
		{
			if (KDHGBOOECKC.HHCJCDFCLOB != null)
			{
				SetDaylyTime(KDHGBOOECKC.HHCJCDFCLOB.IILNIBNFOLG(BOPFPIHGJMD.MLBMHDCCGHI.HEFPAOLDHCK_1_Day));
				SetWeeklyTime(KDHGBOOECKC.HHCJCDFCLOB.IILNIBNFOLG(BOPFPIHGJMD.MLBMHDCCGHI.FDOOAJLGFAE_2_Week));
			}
		}

		//// RVA: 0x17060E8 Offset: 0x17060E8 VA: 0x17060E8
		public void initializeTab()
		{
			ChengeTabState();
			if (IsBeginner)
				return;
			settingTab((int)SelectTab);
		}

		//// RVA: 0x170655C Offset: 0x170655C VA: 0x170655C
		private void settingTab(int selectTab)
		{
			for(int i = 0; i < 4; i++)
			{
				m_tab[i].StartChildrenAnimGoStop(selectTab == i ? "02" : "01");
			}
		}

		//// RVA: 0x1706424 Offset: 0x1706424 VA: 0x1706424
		private void ChengeTabState()
		{
			if(!IsBeginner)
			{
				if(IsUnlockDivaOffer)
				{
					m_tabState.StartChildrenAnimGoStop("01");
					WeeklyTabKadomaru(false);
				}
				else
				{
					m_tabState.StartChildrenAnimGoStop("03");
					WeeklyTabKadomaru(true);
				}
			}
			else
			{
				m_tabState.StartChildrenAnimGoStop("02");
				m_debutTab.StartChildrenAnimGoStop("02");
				BeginnerOfferProgress();
			}
		}

		// RVA: 0x1706804 Offset: 0x1706804 VA: 0x1706804
		public void SetOperationTabClickCallback(Action<int> tab)
		{
			operationTabList[0].ClearOnClickCallback();
			operationTabList[0].AddOnClickCallback(() =>
			{
				//0x1709284
				tab(0);
				settingTab(0);
				SelectTab = OfferSelectTab.DivaTab;
			});
			operationTabList[1].ClearOnClickCallback();
			operationTabList[1].AddOnClickCallback(() =>
			{
				//0x170933C
				tab(1);
				settingTab(1);
				SelectTab = OfferSelectTab.WeeklyTab;
			});
			operationTabList[2].ClearOnClickCallback();
			operationTabList[2].AddOnClickCallback(() =>
			{
				//0x17093F4
				tab(2);
				settingTab(2);
				SelectTab = OfferSelectTab.DaylyTab;
			});
		}

		//// RVA: 0x1706640 Offset: 0x1706640 VA: 0x1706640
		public void BeginnerOfferProgress()
		{
			int a1 = KDHGBOOECKC.HHCJCDFCLOB.ECBHIIOABCK();
			int a2 = KDHGBOOECKC.HHCJCDFCLOB.PDGOLEJBNMM(BOPFPIHGJMD.IGHPDAGKIKO.CADDNFIKDLG_4_Complete, true);
			m_MaxDebutNum.SetNumber(a1, 0);
			m_ClearDebutNum.SetNumber(a2);
			debutClearIconChenge(a1 == a2);
			UpdateGaugePosition(a2 * 1.0f / a1);
		}

		//// RVA: 0x1705F18 Offset: 0x1705F18 VA: 0x1705F18
		private void InitializeList()
		{
			m_scrollList.OnUpdateItem.RemoveAllListeners();
			m_scrollList.OnUpdateItem.AddListener(OnUpdateListItem);
			m_scrollList.SetItemCount(0);
			m_scrollList.VisibleRegionUpdate();
		}

		// RVA: 0x1706C98 Offset: 0x1706C98 VA: 0x1706C98
		public void DestroyScene()
		{
			for(int i = 0; i < m_scrollList.ScrollObjects.Count; i++)
			{
				if(m_scrollList.ScrollObjects[i] != null)
				{
					(m_scrollList.ScrollObjects[i] as OfferSelectContent).StopTimer();
				}
			}
		}

		//// RVA: 0x1706EF8 Offset: 0x1706EF8 VA: 0x1706EF8
		private void OnSelectListItem(int index, SwapScrollListContent content)
		{
			OfferSelectContent c = content as OfferSelectContent;
			if(c != null)
			{
				if(index < viewList.Count)
				{
					c.Setup(viewList[index], () =>
					{
						//0x1709210
						this.StartCoroutineWatched(Co_StartListUpdate());
					});
					c.SetStatus();
				}
			}
		}

		//// RVA: 0x17070CC Offset: 0x17070CC VA: 0x17070CC
		//public void AddScrollLsit(SwapScrollListContent _content) { }

		// RVA: 0x1707100 Offset: 0x1707100 VA: 0x1707100
		public void SetupList(int count, bool resetScroll = true)
		{
			m_scrollList.SetItemCount(count);
			m_scrollList.OnUpdateItem.RemoveAllListeners();
			m_scrollList.OnUpdateItem.AddListener(OnUpdateListItem);
			m_scrollList.ResetScrollVelocity();
			if (resetScroll)
				m_scrollList.SetPosition(0, 0, 0, false);
			m_scrollList.VisibleRegionUpdate();
			for(int i = 0; i < m_scrollList.ScrollObjects.Count; i++)
			{
				m_scrollList.ScrollObjects[i].ClickButton.RemoveAllListeners();
				m_scrollList.ScrollObjects[i].ClickButton.AddListener(OnSelectListItem);
			}
		}

		//// RVA: 0x17074A8 Offset: 0x17074A8 VA: 0x17074A8
		private void OnUpdateListItem(int index, SwapScrollListContent content)
		{
			OfferSelectContent c = content as OfferSelectContent;
			if(c != null)
			{
				if (index < viewList.Count)
				{
					c.Setup(viewList[index], () =>
					{
						//0x17094AC
						this.StartCoroutineWatched(Co_StartListUpdate());
					});
					c.SetStatus();
					c.SetButtonCallback(() =>
					{
						//0x17094E4
						OrderAction(index);
					}, () =>
					{
						//0x1709578
						ProgressAction(index);
					}, () =>
					{
						//0x170960C
						DoneAction(index);
					}, () =>
					{
						//0x17096A0
						ItemDetailOpen();
					}, () =>
					{
						//0x17096E0
						ItemDetailClose();
					});
				}
			}
		}

		// RVA: 0x17077F4 Offset: 0x17077F4 VA: 0x17077F4
		public void SetContentButtonCallback(Action<int> _OrderAction, Action<int> _ProgressAction, Action<int> _DoneAction, Action _itemDetailOpen, Action _itemDetailClose)
		{
			OrderAction = _OrderAction;
			ProgressAction = _ProgressAction;
			DoneAction = _DoneAction;
			ItemDetailOpen = _itemDetailOpen;
			ItemDetailClose = _itemDetailClose;
		}

		// RVA: 0x170781C Offset: 0x170781C VA: 0x170781C
		private void Update()
		{
			m_timeWatcherDayly.Update();
			m_timeWatcherWeekly.Update();
			for(int i = 0; i < m_scrollList.ScrollObjects.Count; i++)
			{
				(m_scrollList.ScrollObjects[i] as OfferSelectContent).NewIconSetting(m_frameCount);
			}
			m_frameCount++;
		}

		//// RVA: 0x17061F4 Offset: 0x17061F4 VA: 0x17061F4
		public void SetDaylyTime(long remainTime)
		{
			if(remainTime != 0)
			{
				m_timeWatcherDayly.onElapsedCallback = (long current, long limit, long remain) =>
				{
					//0x1709234
					ApplyRemainTime(limit, OfferSelectTab.DaylyTab);
				};
				m_timeWatcherDayly.onEndCallback = null;
				m_timeWatcherDayly.WatchStart(remainTime, true);
			}
		}

		//// RVA: 0x170630C Offset: 0x170630C VA: 0x170630C
		public void SetWeeklyTime(long remainTime)
		{
			if(remainTime != 0)
			{
				m_timeWatcherWeekly.onElapsedCallback = (long current, long limit, long remain) =>
				{
					//0x170925C
					ApplyRemainTime(limit, OfferSelectTab.WeeklyTab);
				};
				m_timeWatcherWeekly.onEndCallback = null;
				m_timeWatcherWeekly.WatchStart(remainTime, true);
			}
		}

		//// RVA: 0x1707A30 Offset: 0x1707A30 VA: 0x1707A30
		private void ApplyRemainTime(long remainSec, OfferSelectTab tabCategory)
		{
			int d, h, m, s;
			MusicSelectSceneBase.ExtractRemainTime((int)remainSec, out d, out h, out m, out s);
			SetTextTimer(MessageManager.Instance.GetMessage("menu", "music_event_remain_prefix") + MusicSelectSceneBase.MakeRemainTime(d, h, m, s), tabCategory);
		}

		//// RVA: 0x1707B68 Offset: 0x1707B68 VA: 0x1707B68
		public void SetTextTimer(string text, OfferSelectTab tabCategory)
		{
			if (m_times == null)
				return;
			if(tabCategory == OfferSelectTab.WeeklyTab)
			{
				m_times[0].text = text;
				m_times[1].text = text;
			}
			else if(tabCategory == OfferSelectTab.DaylyTab)
			{
				m_times[2].text = text;
				m_times[3].text = text;
			}
		}

		// RVA: 0x1707CC0 Offset: 0x1707CC0 VA: 0x1707CC0
		public void SetStartListUpdateAct(Action act)
		{
			startListUpdateAct = act;
		}

		// RVA: 0x1701990 Offset: 0x1701990 VA: 0x1701990
		public void StartListUpdate()
		{
			this.StartCoroutineWatched(Co_StartListUpdate());
		}

		//[IteratorStateMachineAttribute] // RVA: 0x6FBB74 Offset: 0x6FBB74 VA: 0x6FBB74
		//// RVA: 0x1707CC8 Offset: 0x1707CC8 VA: 0x1707CC8
		private IEnumerator Co_StartListUpdate()
		{
			float tweenTime; // 0x14
			Vector3 m_from; // 0x18
			Vector3 m_to; // 0x24

			//0x1709724
			if (IsExitBefore)
				yield break;
			startListUpdateAct();
			if (isStartListUpdate)
				yield break;
			isStartListUpdate = true;
			MenuScene.Instance.RaycastDisable();
			tweenTime = 0;
			m_from = ListContent.localPosition;
			m_from.x = 0;
			m_to = m_from;
			m_to.x += Screen.width;
			while(tweenTime <= 0.2f)
			{
				tweenTime += Time.deltaTime;
				Vector3 p = XeSys.Math.Tween.Evaluate(XeSys.Math.Tween.EasingFunc.InOutCubic, m_from, m_to, tweenTime / 0.2f);
				ListContent.localPosition = p;
				yield return null;
			}
			ListContent.localPosition = m_to;
			SetupList(viewList.Count, false);
			tweenTime = 0;
			while (tweenTime < 1)
			{
				tweenTime += Time.deltaTime;
				ListContent.localPosition = XeSys.Math.Tween.Evaluate(XeSys.Math.Tween.EasingFunc.InOutCubic, m_to, m_from, tweenTime);
				ListContent.localPosition = ListContent.localPosition;
				yield return null;
			}
			ListContent.localPosition = m_from;
			MenuScene.Instance.RaycastEnable();
			isStartListUpdate = false;
		}

		//// RVA: 0x1706114 Offset: 0x1706114 VA: 0x1706114
		private void probailtyAnimEnable(BOPFPIHGJMD.JFHCHOILMEL type)
		{
			if (type == BOPFPIHGJMD.JFHCHOILMEL.HJNNKCMLGFL_0)
				m_probabilityIcon.StartChildrenAnimGoStop("03");
			else if(type == BOPFPIHGJMD.JFHCHOILMEL.GNHENCIPDFK_2)
				m_probabilityIcon.StartChildrenAnimGoStop("02");
			else if (type == BOPFPIHGJMD.JFHCHOILMEL.MLFOEICOGAP_1)
				m_probabilityIcon.StartChildrenAnimGoStop("01");
		}

		// RVA: 0x1707D74 Offset: 0x1707D74 VA: 0x1707D74
		public void NonListTextSetting(bool IsListNon)
		{
			if(!IsListNon)
			{
				NonListItemTextLayout.StartChildrenAnimGoStop("02");
				nonListItemtext.text = "";
			}
			else
			{
				MessageBank bk = MessageManager.Instance.GetBank("menu");
				NonListItemTextLayout.StartChildrenAnimGoStop("01");
				nonListItemtext.text = bk.GetMessageByLabel("offer_non_offer_text");
			}
		}

		//// RVA: 0x1706BD4 Offset: 0x1706BD4 VA: 0x1706BD4
		private void UpdateGaugePosition(float normalizePos)
		{
			int s = (int)((m_layoutGauge.GetView(0).FrameAnimation.FrameNum + 1) * normalizePos);
		}

		//// RVA: 0x1706B3C Offset: 0x1706B3C VA: 0x1706B3C
		private void debutClearIconChenge(bool IsDebutComplete)
		{
			m_debutClearIcon.StartChildrenAnimGoStop(IsDebutComplete ? "02" : "01");
		}

		//// RVA: 0x1707F0C Offset: 0x1707F0C VA: 0x1707F0C
		//public void Enter() { }

		// RVA: 0x1707F98 Offset: 0x1707F98 VA: 0x1707F98
		public void Leave()
		{
			m_layoutRoot.StartChildrenAnimGoStop("go_out", "st_out");
		}

		//// RVA: 0x1708024 Offset: 0x1708024 VA: 0x1708024
		//public void Hide() { }

		//// RVA: 0x17080A0 Offset: 0x17080A0 VA: 0x17080A0
		//public void Show() { }

		// RVA: 0x170811C Offset: 0x170811C VA: 0x170811C
		public bool IsPlaying()
		{
			return m_layoutRoot.IsPlayingChildren();
		}

		//// RVA: 0x1706748 Offset: 0x1706748 VA: 0x1706748
		public void WeeklyTabKadomaru(bool IsKadomaru)
		{
			m_kadoMaru_on.StartChildrenAnimGoStop(IsKadomaru ? "02" : "01");
			m_kadoMaru_off.StartChildrenAnimGoStop(IsKadomaru ? "02" : "01");
		}

		// RVA: 0x1708148 Offset: 0x1708148 VA: 0x1708148
		public void SetSelectTab()
		{
			BOPFPIHGJMD.MLBMHDCCGHI a = BOPFPIHGJMD.MLBMHDCCGHI.HJNNKCMLGFL_0;
			if (SelectTab < OfferSelectTab.MAX)
				a = new BOPFPIHGJMD.MLBMHDCCGHI[4] { BOPFPIHGJMD.MLBMHDCCGHI.FMLPIOFBCMA_3_Diva, BOPFPIHGJMD.MLBMHDCCGHI.FDOOAJLGFAE_2_Week, BOPFPIHGJMD.MLBMHDCCGHI.HEFPAOLDHCK_1_Day, BOPFPIHGJMD.MLBMHDCCGHI.GENEIBGNMPH_4_Debut }[(int)SelectTab];
			KDHGBOOECKC.HHCJCDFCLOB.HJOLFCDAIGE(a);
		}

		// RVA: 0x1701884 Offset: 0x1701884 VA: 0x1701884
		public void InitializeBadge()
		{
			for(int i = 0; i < m_badgeIcons.Length; i++)
			{
				m_badgeIcons[i].Initialize(m_badgeParentObject[i], m_badgeParentLayouts[i]);
				SwitchEmphasisIcon(i);
			}
		}

		// RVA: 0x1708440 Offset: 0x1708440 VA: 0x1708440
		public void ReleaseBadge()
		{
			for (int i = 0; i < m_badgeIcons.Length; i++)
			{
				m_badgeIcons[i].Release();
			}
		}

		//// RVA: 0x17081B8 Offset: 0x17081B8 VA: 0x17081B8
		public void SwitchEmphasisIcon(int index)
		{
			if(!KDHGBOOECKC.HHCJCDFCLOB.OHILPCDFKCH())
			{
				BOPFPIHGJMD.MLBMHDCCGHI a = BOPFPIHGJMD.MLBMHDCCGHI.HEFPAOLDHCK_1_Day;
				if (index < 4)
					a = new BOPFPIHGJMD.MLBMHDCCGHI[4] { BOPFPIHGJMD.MLBMHDCCGHI.FMLPIOFBCMA_3_Diva, BOPFPIHGJMD.MLBMHDCCGHI.FDOOAJLGFAE_2_Week, BOPFPIHGJMD.MLBMHDCCGHI.HEFPAOLDHCK_1_Day, BOPFPIHGJMD.MLBMHDCCGHI.GENEIBGNMPH_4_Debut }[index];
				MessageBank bk = MessageManager.Instance.GetBank("menu");
				int a2 = KDHGBOOECKC.HHCJCDFCLOB.LJMOMAGLEGL(a, BOPFPIHGJMD.IGHPDAGKIKO.FJGFAPKLLCL_3_Achieved, false);
				string str = string.Format(bk.GetMessageByLabel("offer_operation_badge_text"), a2);
				m_badgeIcons[index].Set(a2 > 0 ? BadgeConstant.ID.Label : BadgeConstant.ID.None, str);
				if(index == 0 && a2 < 1)
				{
					if(KDHGBOOECKC.HHCJCDFCLOB.NLDDHJGHHOD())
					{
						m_badgeIcons[0].Set(BadgeConstant.ID.New, str);
					}
				}
			}
		}

		//// RVA: 0x170819C Offset: 0x170819C VA: 0x170819C
		//private BOPFPIHGJMD.MLBMHDCCGHI TabConverter(OfferSelectList.OfferSelectTab tab) { }

		//// RVA: 0x1705E00 Offset: 0x1705E00 VA: 0x1705E00
		//private OfferSelectList.OfferSelectTab TabConverter(BOPFPIHGJMD.MLBMHDCCGHI tab) { }

		//// RVA: 0x17084EC Offset: 0x17084EC VA: 0x17084EC
		//private OfferSelectList.OfferSelectTab TypeConverter(BOPFPIHGJMD.MLBMHDCCGHI _type) { }

		//// RVA: 0x17084D0 Offset: 0x17084D0 VA: 0x17084D0
		//private BOPFPIHGJMD.MLBMHDCCGHI TypeConverter(OfferSelectList.OfferSelectTab _type) { }

		// RVA: 0x1708510 Offset: 0x1708510 VA: 0x1708510 Slot: 5
		public override bool InitializeFromLayout(Layout layout, TexUVListManager uvMan)
		{
			m_layoutRoot = layout.FindViewByExId("root_sel_vfo_window_sw_s_v_win_03_anim") as AbsoluteLayout;
			m_tabState = layout.FindViewByExId("sw_s_v_win_03_anim_sw_s_v_win_03") as AbsoluteLayout;
			m_probabilityIcon = layout.FindViewByExId("sw_s_v_win_03_swtbl_s_v_icon_up") as AbsoluteLayout;
			NonListItemTextLayout = layout.FindViewByExId("sw_s_v_win_03_swtbl_s_v_non_txt") as AbsoluteLayout;
			m_debutTab = layout.FindViewByExId("sw_s_v_win_03_swtbl_s_v_tab_04") as AbsoluteLayout;
			m_layoutGauge = layout.FindViewByExId("sw_s_v_tab_on_04_swfrm_s_v_progress_anim") as AbsoluteLayout;
			m_debutClearIcon = layout.FindViewByExId("sw_s_v_tab_on_04_swtbl_s_v_num_03") as AbsoluteLayout;
			m_kadoMaru_on = layout.FindViewByExId("swtbl_s_v_tab_02_swtbl_s_v_tab_on") as AbsoluteLayout;
			m_kadoMaru_off = layout.FindViewByExId("swtbl_s_v_tab_02_swtbl_s_v_tab_off") as AbsoluteLayout;
			for(int i = 0; i < 4; i++)
			{
				m_tab[i] = layout.FindViewByExId(string.Format("sw_s_v_win_03_swtbl_s_v_tab_0{0:D1}", (i + 1))) as AbsoluteLayout;
			}
			m_buttonLayouts = new AbsoluteLayout[operationTabList.Length];
			m_badgeParentLayouts = new AbsoluteLayout[operationTabList.Length];
			m_badgeParentObject = new GameObject[operationTabList.Length];
			m_badgeIcons = new BadgeIcon[operationTabList.Length];
			LayoutUGUIRuntime r = GetComponentInParent<LayoutUGUIRuntime>();
			for(int i = 0; i < operationTabList.Length; i++)
			{
				m_buttonLayouts[i] = layout.FindViewByExId(string.Format("sw_s_v_win_03_swtbl_s_v_tab_{0:D2}", i + 1)) as AbsoluteLayout;
				m_badgeParentLayouts[i] = m_buttonLayouts[i].FindViewByExId(string.Format("swtbl_s_v_tab_{0:D2}_badge", i + 1)) as AbsoluteLayout;
				m_badgeParentObject[i] = r.FindRectTransform(m_badgeParentLayouts[i]).gameObject;
				m_badgeIcons[i] = new BadgeIcon();
			}
			m_buttonParentLayout = m_buttonLayouts[0].Parent as AbsoluteLayout;
			Loaded();
			return base.InitializeFromLayout(layout, uvMan);
		}

		// RVA: 0x1709130 Offset: 0x1709130 VA: 0x1709130
		public void SetView(List<HEFCLPGPMLK.AAOPGOGGMID> list, HEFCLPGPMLK _view)
		{
			viewList = list;
			m_view = _view;
		}
	}
}
