using XeSys.Gfx;
using XeApp.Game.Common;
using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using UnityEngine.Events;
using mcrs;
using System;

namespace XeApp.Game.Menu
{
	public enum SquareType
	{
		None = 0,
		Panel = 1,
		Start = 2,
		Road = 3,
		Lock = 4,
	}

	public struct BoardSquare
	{
		public short saveIndex; // 0x0
		public SquareType type; // 0x4
		public int id; // 0x8
		public int value; // 0xC
		public bool isOpen; // 0x10
		public bool isPossible; // 0x11
		public SceneGrowthPanelBase panelObject; // 0x14
	}

	public abstract class SceneGrowthBoard : LayoutUGUIScriptBase
	{
		public enum BoardDispPosition
		{
			Top = 0,
			Current = 1,
			End = 2,
		}

		public enum BoardType
		{
			None = 0,
			Main = 1,
			Sub = 2,
		}

		protected List<BoardSquare[]> m_boardSquareList = new List<BoardSquare[]>(); // 0x14
		protected const int BoardRowCount = 5;
		protected GCIJNCFDNON_SceneInfo m_sceneData; // 0x18
		private MNDAMOGGJBJ m_tempItemData = new MNDAMOGGJBJ(); // 0x1C
		private SceneGrowthScene m_growthScene; // 0x20
		[SerializeField]
		protected ActionButton m_boardChangeButton; // 0x24
		[SerializeField]
		protected ScrollRect m_scrollRect; // 0x28
		[SerializeField]
		protected LayoutElement m_rangeObject; // 0x2C
		[SerializeField]
		protected NumberBase m_nultNumber; // 0x30
		[SerializeField]
		protected string m_layoutExId; // 0x34
		protected UnityAction m_boardChangeAction; // 0x38
		//[CompilerGeneratedAttribute] // RVA: 0x67D5CC Offset: 0x67D5CC VA: 0x67D5CC
		public UnityAction<SceneGrowthBoard, int, int> OnUnlockAction; // 0x3C
		protected RectTransform m_parentObject; // 0x40
		private int m_lastRewardItemId; // 0x44
		protected int m_topPosition; // 0x48
		protected int m_lastPosition; // 0x4C
		protected const int WidthRange = 8;
		protected const float ExpandBoardNormalPosition = 0.2f;
		protected float m_scrollWidth; // 0x50
		private bool m_isShowBoard; // 0x54
		protected AbsoluteLayout m_windowLayout; // 0x58
		private AbsoluteLayout m_multiChangeLayout; // 0x5C
		public const int IconWidth = 120;
		public const int InfPanelWidth = 170;
		public const int IconHeight = 100;
		public const int IconTopOffset = 16;
		private const int MultiDispMax = 10000;
		private const float XOffset = -12;
		protected float m_scrollDiff; // 0x60
		protected const int RowCount = 5;
		protected const float MinScrollWidth = 580;
		protected const float MaxScrollWidth = 744;
		protected const float ScrollWidthDiff = 164;
		[SerializeField]
		protected ActionButton m_limitOverButton; // 0x64
		[SerializeField]
		protected ActionButton m_subBoardReleaseButton; // 0x68
		protected AbsoluteLayout m_limitOverLayout; // 0x6C
		protected AbsoluteLayout m_limitOverBgLayout; // 0x70
		protected AbsoluteLayout m_limitOverInfoLayout; // 0x74
		protected AbsoluteLayout[] m_limitOverSlotLayout; // 0x78
		protected UnityAction m_limitOverAction; // 0x7C
		protected UnityAction m_subBoardReleaseAction; // 0x80
		protected const int LimitOverMaxCount = 5;

		//public ScrollRect ScrollRect { get; } 0x15A6898
		public UnityAction BoardChangeAction { get { return m_boardChangeAction; } set { m_boardChangeAction = value; } } //0x15A6AB8 0x15A6AC0
		public UnityAction LimitOverAction { get { return m_limitOverAction; } set { m_limitOverAction = value; } } //0x15A6AD4 0x15A6ADC
		public UnityAction SubBoardReleaseAction { get { return m_subBoardReleaseAction; } set { m_subBoardReleaseAction = value; } } //0x15A6AE4 0x15A6AEC

		//// RVA: 0x15A6AC8 Offset: 0x15A6AC8 VA: 0x15A6AC8
		public void ClearUnlockAction()
		{
			OnUnlockAction = null;
		}

		// RVA: 0x15A6AF4 Offset: 0x15A6AF4 VA: 0x15A6AF4 Slot: 5
		public override bool InitializeFromLayout(Layout layout, TexUVListManager uvMan)
		{
			m_windowLayout = layout.FindViewByExId(m_layoutExId) as AbsoluteLayout;
			m_multiChangeLayout = layout.FindViewByExId("sw_boards_set_swnum_star") as AbsoluteLayout;
			m_scrollRect.onValueChanged.AddListener(OnChangeScroll);
			m_boardChangeButton.AddOnClickCallback(() =>
			{
				//0x15AC270
				SoundManager.Instance.sePlayerBoot.Play((int)cs_se_boot.SE_BTN_003);
				if (m_boardChangeAction != null)
					m_boardChangeAction();
			});
			m_parentObject = m_rangeObject.GetComponent<RectTransform>();
			m_scrollWidth = m_scrollRect.GetComponent<RectTransform>().sizeDelta.x;
			m_tempItemData.KHEKNNFCAOI(null);
			if(m_scrollRect.verticalScrollbar != null)
			{
				m_scrollRect.verticalScrollbar.gameObject.SetActive(false);
				m_scrollRect.verticalScrollbar = null;
			}
			m_limitOverLayout = layout.FindViewById("swtbl_btn_luc") as AbsoluteLayout;
			m_limitOverBgLayout = layout.FindViewById("swtbl_btn_luc_bg") as AbsoluteLayout;
			m_limitOverInfoLayout = layout.FindViewById("luc_frm_bg2") as AbsoluteLayout;
			m_limitOverButton.AddOnClickCallback(() =>
			{
				//0x15AC2E0
				SoundManager.Instance.sePlayerBoot.Play((int)cs_se_boot.SE_BTN_003);
				if (m_limitOverAction != null)
					m_limitOverAction();
			});
			m_subBoardReleaseButton.AddOnClickCallback(() =>
			{
				//0x15AC350
				SoundManager.Instance.sePlayerBoot.Play((int)cs_se_boot.SE_BTN_003);
				if (m_subBoardReleaseAction != null)
					m_subBoardReleaseAction();
			});
			m_limitOverSlotLayout = new AbsoluteLayout[5];
			for(int i = 0; i < 5; i++)
			{
				m_limitOverSlotLayout[i] = layout.FindViewById("swtbl_leaf_onoff_" + (i + 1).ToString("D2")) as AbsoluteLayout;
			}
			ClearLoadedCallback();
			return true;
		}

		//// RVA: -1 Offset: -1 Slot: 6
		public abstract float GetDefaultScrollPosition();

		//// RVA: -1 Offset: -1 Slot: 7
		protected abstract float GetScrollRange();

		//// RVA: -1 Offset: -1 Slot: 8
		public abstract void SetBoardLayout(GCIJNCFDNON_SceneInfo sceneData);

		//// RVA: -1 Offset: -1 Slot: 9
		public abstract void UpdateBoardLayout();

		//// RVA: -1 Offset: -1 Slot: 10
		public abstract AFIFDLOAKGI GetPanelItem(int index);

		//// RVA: -1 Offset: -1 Slot: 11
		public abstract void InitializeExpandDirection(ref List<LayoutUGUIScriptBase> directionList);

		//// RVA: -1 Offset: -1 Slot: 12
		public abstract float GetScrollHeight();

		//// RVA: 0x15A729C Offset: 0x15A729C VA: 0x15A729C
		public void SetLimitOverLayout(AEKDNMPPOJN limitOverData)
		{
			if(limitOverData.LJHOOPJACPI_LeafMax > 0)
			{
				m_limitOverButton.Hidden = false;
				string a = limitOverData.LJHOOPJACPI_LeafMax.ToString("D2");
				m_limitOverLayout.StartChildrenAnimGoStop(a, a);
				m_limitOverBgLayout.StartChildrenAnimGoStop(a, a);
				a = limitOverData.DJEHLEJCPEL_LeafNum < 5 ? "01" : "02";
				m_limitOverInfoLayout.StartChildrenAnimGoStop(a);
				for(int i = 0; i < 5; i++)
				{
					a = limitOverData.DJEHLEJCPEL_LeafNum > i ? "02" : "01";
					m_limitOverSlotLayout[i].StartChildrenAnimGoStop(a, a);
				}
			}
			else
			{
				m_limitOverButton.Hidden = true;
			}
		}

		//// RVA: 0x15A7494 Offset: 0x15A7494 VA: 0x15A7494
		public void InitializeBoard(int lastRewardItemId)
		{
			RectTransform scrollRt = m_scrollRect.GetComponent<RectTransform>();
			scrollRt.anchoredPosition = new Vector2(0, 0);
			m_growthScene = GetComponentInParent<SceneGrowthScene>();
			m_lastRewardItemId = lastRewardItemId;
			m_topPosition = 0;
			m_lastPosition = m_boardSquareList.Count - 1;
			m_scrollDiff = 0;
			for(int i = 0; i < 8; i++)
			{
				for(int j = 0; j < 5; j++)
				{
					AddPanel(i, j);
				}
			}
			Vector2 s = GetComponentInParent<Canvas>().transform.GetChild(0).GetComponent<RectTransform>().sizeDelta;
			float f = 744;
			if(s.x < 1184)
			{
				f = 744 - (1184 - s.x);
			}
			scrollRt.sizeDelta = new Vector2(f, GetScrollHeight());
			RectTransform hBarRt = m_scrollRect.horizontalScrollbar.GetComponent<RectTransform>();
			hBarRt.sizeDelta = new Vector2(f, hBarRt.sizeDelta.y);
			m_rangeObject.minHeight = hBarRt.sizeDelta.y;
			m_rangeObject.minWidth = hBarRt.sizeDelta.x;
			m_rangeObject.minWidth = GetScrollRange();
			m_rangeObject.minHeight -= 12;
			m_scrollRect.content.GetComponent<RectTransform>().sizeDelta = new Vector2(m_rangeObject.minWidth, m_scrollRect.content.GetComponent<RectTransform>().sizeDelta.y);
			m_scrollRect.content.anchoredPosition = new Vector2(-GetDefaultScrollPosition(), 0);
			m_scrollDiff = 0;
			OnChangeScroll(new Vector2(0, 0));
		}

		//// RVA: 0x15A8DA0 Offset: 0x15A8DA0 VA: 0x15A8DA0
		public int GetPanelValue(int index)
		{
			for(int i = 0; i < m_boardSquareList.Count; i++)
			{
				for(int j = 0; j < m_boardSquareList[i].Length; j++)
				{
					if(m_boardSquareList[i][j].type == SquareType.Panel)
					{
						if (m_boardSquareList[i][j].saveIndex == index)
						{
							return m_boardSquareList[i][j].value;
						}
					}
				}
			}
			return 0;
		}

		//// RVA: 0x15A9000 Offset: 0x15A9000 VA: 0x15A9000
		public bool IsPanelRock(int sqrX, int sqrY)
		{
			return m_boardSquareList[sqrX][sqrY].type == SquareType.Lock;
		}

		//// RVA: 0x15A90CC Offset: 0x15A90CC VA: 0x15A90CC
		private void OnPushPanel(int sqrX, int sqrY)
		{
			if (OnUnlockAction != null)
				OnUnlockAction(this, sqrX, sqrY);
		}

		//// RVA: 0x15A9158 Offset: 0x15A9158 VA: 0x15A9158
		public void PreConnectGameObject(List<SceneGrowthPanelBase> panelList)
		{
			for(int i = 0; i < panelList.Count; i++)
			{
				LayoutUGUIUtility.AddView(m_parentObject.gameObject, m_windowLayout, panelList[i].gameObject);
			}
		}

		//// RVA: 0x15A92B4 Offset: 0x15A92B4 VA: 0x15A92B4
		public void DisConnectGameObject(List<SceneGrowthPanelBase> panelList, Transform parent)
		{
			for(int i = 0; i < panelList.Count; i++)
			{
				LayoutUGUIUtility.RemoveView(m_parentObject.gameObject, m_windowLayout, panelList[i].gameObject);
				panelList[i].transform.SetParent(parent, false);
			}
		}

		//// RVA: 0x15A7B1C Offset: 0x15A7B1C VA: 0x15A7B1C
		private void AddPanel(int sqrX, int sqrY)
		{
			if (sqrX < 0)
				return;
			if (m_boardSquareList.Count <= sqrX)
				return;
			if (m_boardSquareList[sqrX][sqrY].type == 0)
				return;
			SceneGrowthPanelBase panel = m_growthScene.StorePanelResource(ref m_boardSquareList[sqrX][sqrY], this);
			panel.SetActive(true);
			panel.RectTransform.anchoredPosition = new Vector2(sqrX * 120 - 12, sqrY * -100 - 16);
			m_boardSquareList[sqrX][sqrY].panelObject = panel;
			if (panel == null)
				return;
			if(panel is SceneGrowthStart)
			{
				//LAB_015a8a34
				panel.RectTransform.SetAsLastSibling();
			}
			else if(panel is SceneGrowthPanel)
			{
				SceneGrowthPanel p = panel as SceneGrowthPanel;
				p.Wait();
				p.SetLabel(m_boardSquareList[sqrX][sqrY].id, m_boardSquareList[sqrX][sqrY].type == SquareType.Lock);
				p.SetEpisodeIcon(m_lastRewardItemId);
				p.SetGet(m_boardSquareList[sqrX][sqrY].isOpen, m_boardSquareList[sqrX][sqrY].type == SquareType.Lock);
				p.SetValue(m_boardSquareList[sqrX][sqrY].value);
				p.SetIndex(m_boardSquareList[sqrX][sqrY].saveIndex);
				p.SetPanelPuashAction(() =>
				{
					//0x15AC4D8
					OnPushPanel(sqrX, sqrY);
				});
				panel.RectTransform.SetAsLastSibling();
				if(m_boardSquareList[sqrX][sqrY].type == SquareType.Lock)
				{
					m_growthScene.OnEnablePassButton(p);
				}
				if (m_boardSquareList[sqrX][sqrY].isPossible)
				{
					p.IsPossible = !m_boardSquareList[sqrX][sqrY].isOpen;
				}
				else
				{
					p.IsPossible = false;
				}
				p.ShowLoopEffect();
			}
			else if(panel is SceneGrowthInfinityPanel)
			{
				SceneGrowthInfinityPanel p = panel as SceneGrowthInfinityPanel;
				p.Wait();
				p.SetValue((short)m_boardSquareList[sqrX][sqrY].value);
				p.SetStock(m_sceneData.KPCLNEADGEM(m_boardSquareList[sqrX][sqrY].saveIndex));
				p.SetPanelPuashAction(() =>
				{
					//0x15AC50C
					OnPushPanel(sqrX, sqrY);
				});
				if (!m_boardSquareList[sqrX][sqrY].isPossible)
				{
					p.IsPossible = false;
				}
				else
				{
					p.IsPossible = p.Stock > 0;
				}
				p.ShowLoopEffect();
				panel.RectTransform.SetAsLastSibling();
			}
			else if(panel is SceneGrowthRoad)
			{
				SceneGrowthRoad p = panel as SceneGrowthRoad;
				p.Wait();
				p.SetPossible(m_boardSquareList[sqrX][sqrY].isPossible);
				bool isSubboard = this is SceneGrowthSubBoard;
				if (!m_boardSquareList[sqrX][sqrY].isOpen)
					p.SetClose(isSubboard, sqrY == 2);
				else
					p.SetOpen(isSubboard, sqrY == 2);
				p.SetIndex(m_boardSquareList[sqrX][sqrY].saveIndex);
				panel.RectTransform.SetAsFirstSibling();
			}
		}

		//// RVA: 0x15A97AC Offset: 0x15A97AC VA: 0x15A97AC
		private void RemovePanel(int sqrX, int sqrY)
		{
			if(sqrX > -1)
			{
				if(sqrX < m_boardSquareList.Count)
				{
					if (m_boardSquareList[sqrX][sqrY].panelObject == null)
						return;
					if(m_boardSquareList[sqrX][sqrY].type == SquareType.Lock)
					{
						m_growthScene.OnDisablePassButton(m_boardSquareList[sqrX][sqrY].panelObject as SceneGrowthPanel);
					}
					m_growthScene.RestorePanelResource(m_boardSquareList[sqrX][sqrY].panelObject, this);
					m_boardSquareList[sqrX][sqrY].panelObject = null;
				}
			}
		}

		//// RVA: 0x15A9B2C Offset: 0x15A9B2C VA: 0x15A9B2C
		//public void SetShowBoardColumnIndex(int col) { }

		//// RVA: 0x15A9BB8 Offset: 0x15A9BB8 VA: 0x15A9BB8
		public void SetEnableBoardChangeButton(bool isEnable)
		{
			m_boardChangeButton.Disable = !isEnable;
		}

		//// RVA: 0x15A9BEC Offset: 0x15A9BEC VA: 0x15A9BEC
		public void SetEnableSubBoardReleaseButton(bool isVisible, bool isEnable)
		{
			m_subBoardReleaseButton.Hidden = !isVisible;
			if (!isVisible)
				return;
			m_subBoardReleaseButton.Disable = !isEnable;
		}

		//// RVA: 0x15A9C58 Offset: 0x15A9C58 VA: 0x15A9C58
		public void SetMultCount(int count)
		{
			if(m_nultNumber != null)
			{
				m_nultNumber.SetNumber(count, 0);
			}
			if(m_multiChangeLayout != null)
			{
				m_multiChangeLayout.StartChildrenAnimGoStop(count < 10000 ? "nomal" : "max");
			}
		}

		//// RVA: 0x15A9D58 Offset: 0x15A9D58 VA: 0x15A9D58
		public void RemovePanel()
		{
			for(int i = 0; i < m_boardSquareList.Count; i++)
			{
				for(int j = 0; j < m_boardSquareList[i].Length; j++)
				{
					RemovePanel(i, j);
				}
			}
		}

		//// RVA: 0x15A9E50 Offset: 0x15A9E50 VA: 0x15A9E50
		public void ClearCallBack()
		{
			return;
		}

		//// RVA: 0x15A9E54 Offset: 0x15A9E54 VA: 0x15A9E54
		public void UpdateBoard()
		{
			for(int i = 0; i < m_boardSquareList.Count; i++)
			{
				for(int j = 0; j <  m_boardSquareList[i].Length; j++)
				{
					if(m_boardSquareList[i][j].panelObject != null)
					{
						bool isOpen = m_boardSquareList[i][j].isOpen;
						bool isPossible = m_boardSquareList[i][j].isPossible;
						if(m_boardSquareList[i][j].panelObject is SceneGrowthRoad)
						{
							if(!isOpen)
							{
								(m_boardSquareList[i][j].panelObject as SceneGrowthRoad).SetPossible(isPossible);
								(m_boardSquareList[i][j].panelObject as SceneGrowthRoad).SetClose();
							}
						}
						else if(m_boardSquareList[i][j].panelObject is SceneGrowthPanel)
						{
							if(isOpen || !isPossible)
							{
								(m_boardSquareList[i][j].panelObject as SceneGrowthPanel).StopLoopEffect();
							}
						}
						else if(m_boardSquareList[i][j].panelObject is SceneGrowthInfinityPanel)
						{
							if(!isPossible || (m_boardSquareList[i][j].panelObject as SceneGrowthInfinityPanel).Stock == 0)
								(m_boardSquareList[i][j].panelObject as SceneGrowthInfinityPanel).StopLoopEffect();
						}
					}
				}
			}
		}

		//// RVA: 0x15AA258 Offset: 0x15AA258 VA: 0x15AA258
		public void Show()
		{
			m_windowLayout.StartSiblingAnimGoStop("go_in", "st_in");
			m_isShowBoard = true;
		}

		//// RVA: 0x15AA2EC Offset: 0x15AA2EC VA: 0x15AA2EC
		public void Hide()
		{
			if(m_isShowBoard)
			{
				m_windowLayout.StartSiblingAnimGoStop("go_out", "st_out");
			}
			m_isShowBoard = false;
		}

		//// RVA: 0x15AA38C Offset: 0x15AA38C VA: 0x15AA38C
		public void InitialAnime()
		{
			m_windowLayout.StartSiblingAnimGoStop("st_out");
		}

		//// RVA: 0x15AA408 Offset: 0x15AA408 VA: 0x15AA408
		public bool IsAnimePlaying()
		{
			return m_windowLayout.IsPlayingChildren() || m_windowLayout.IsPlaying();
		}

		//// RVA: 0x15AA464 Offset: 0x15AA464 VA: 0x15AA464
		public float GetScrollViewNormalizePosition()
		{
			return m_scrollRect.horizontalNormalizedPosition;
		}

		//// RVA: 0x15AA490 Offset: 0x15AA490 VA: 0x15AA490
		public float GetBoardNormalizePosition(BoardDispPosition position, float panelPositionX)
		{
			if (position == BoardDispPosition.Top)
				return 0;
			else if(position != BoardDispPosition.End)
			{
				Vector2 s = (m_scrollRect.content.transform as RectTransform).sizeDelta;
				if (panelPositionX <= s.x - (m_scrollRect.transform as RectTransform).sizeDelta.x)
				{
					return Mathf.Clamp01(panelPositionX / s.x);
				}
			}
			return 1;
		}

		//// RVA: 0x15AA694 Offset: 0x15AA694 VA: 0x15AA694
		public void SetScrollNormalizePosition(float normalPosition)
		{
			m_scrollRect.content.anchoredPosition = new Vector2(-((m_scrollRect.content.sizeDelta.x - (m_scrollRect.transform as RectTransform).sizeDelta.x) * normalPosition), m_scrollRect.content.anchoredPosition.y);
			OnChangeScroll(new Vector2(normalPosition, 0));
		}

		//// RVA: 0x15AA878 Offset: 0x15AA878 VA: 0x15AA878
		public void SetScrollPosition(float position)
		{
			do
			{
				float f = position - Mathf.Abs(m_scrollRect.content.anchoredPosition.x);
				float f2 = Mathf.Min(Mathf.Abs(f), 120);
				if(f >= 0)
				{
					if(f >= 0)
					{
						m_scrollRect.content.anchoredPosition = m_scrollRect.content.anchoredPosition - new Vector2(f2, 0);
					}
				}
				else
				{
					m_scrollRect.content.anchoredPosition = m_scrollRect.content.anchoredPosition + new Vector2(f2, 0);
				}
				if(f != 0)
				{
					OnChangeScroll(new Vector2(0, 0));
				}
				if (f < 1)
					return;
			} while (true);
		}

		//// RVA: 0x15AAB50 Offset: 0x15AAB50 VA: 0x15AAB50
		public float GetScrollAreaInPosition(float position, float t)
		{
			return Mathf.Clamp(position - (m_scrollRect.transform as RectTransform).sizeDelta.x * t, 0, m_scrollRect.content.sizeDelta.x);
		}

		//// RVA: 0x15AACBC Offset: 0x15AACBC VA: 0x15AACBC
		public void UnlockAllPanelListup(List<byte> panelList, List<byte> roadList)
		{
			for(int i = 1; i < m_boardSquareList.Count; i++)
			{
				for (int j = 0; j < m_boardSquareList[i].Length; j++)
				{
					if(!m_boardSquareList[i][j].isOpen)
					{
						if(m_boardSquareList[i][j].type == SquareType.Panel)
						{
							panelList.Add((byte)m_boardSquareList[i][j].saveIndex);
						}
						else if(m_boardSquareList[i][j].type == SquareType.Road)
						{
							roadList.Add((byte)m_boardSquareList[i][j].saveIndex);
						}
					}
				}
			}
		}

		//// RVA: 0x15AAEB4 Offset: 0x15AAEB4 VA: 0x15AAEB4
		public void UnlockEpisodePanelListup(List<byte> panelList, List<byte> roadList)
		{
			List<int[]> l = new List<int[]>();
			for(int i = 0; i < m_boardSquareList.Count; i++)
			{
				for(int j = 0; j < m_boardSquareList[i].Length; j++)
				{
					if(!m_boardSquareList[i][j].isOpen && m_boardSquareList[i][j].type == SquareType.Panel)
					{
						AFIFDLOAKGI a = GetPanelItem(m_boardSquareList[i][j].saveIndex);
						if(a.INDDJNMPONH_StatType == 18)
						{
							int[] intVal = new int[2];
							intVal[0] = i;
							intVal[1] = j;
							l.Add(intVal);
						}
					}
				}
			}
			for (int i = 0; i < l.Count; i++)
			{
				OpenPanelSearch(l[i][0], l[i][1], (BoardSquare board, int bx, int by) =>
				{
					//0x15AC540
					if (board.type == SquareType.Road)
					{
						if (roadList.Contains((byte)board.saveIndex))
							return;
						roadList.Add((byte)board.saveIndex);
					}
					else
					{
						if (panelList.Contains((byte)board.saveIndex))
							return;
						panelList.Add((byte)board.saveIndex);
					}
				});
			}
		}

		//// RVA: 0x15AB6E0 Offset: 0x15AB6E0 VA: 0x15AB6E0
		public void UnlockStatusPanelListup(List<byte> panelList, List<byte> roadList)
		{
			List<int[]> l = new List<int[]>();
			for(int i = 0; i < m_boardSquareList.Count; i++)
			{
				for(int j = 0; j < m_boardSquareList[i].Length; j++)
				{
					if(!m_boardSquareList[i][j].isOpen && m_boardSquareList[i][j].type == SquareType.Panel)
					{
						AFIFDLOAKGI a = GetPanelItem(m_boardSquareList[i][j].saveIndex);
						if(a.INDDJNMPONH_StatType != 0)
						{
							if (a.INDDJNMPONH_StatType != 17)
							{
								if(a.INDDJNMPONH_StatType != 18)
								{
									if (a.INDDJNMPONH_StatType != 19)
									{
										if (a.INDDJNMPONH_StatType != 21)
										{
											if (a.INDDJNMPONH_StatType != 20)
											{
												int[] intVal = new int[2];
												intVal[0] = i;
												intVal[1] = j;
												l.Add(intVal);
											}
										}
									}
								}
							}
						}
					}
				}
			}
			for(int i = 0; i < l.Count; i++)
			{
				OpenPanelSearch(l[i][0], l[i][1], (BoardSquare board, int bx, int by) =>
				{
					//0x15AC66C
					if(board.type == SquareType.Road)
					{
						if (roadList.Contains((byte)board.saveIndex))
							return;
						roadList.Add((byte)board.saveIndex);
					}
					else
					{
						if (panelList.Contains((byte)board.saveIndex))
							return;
						panelList.Add((byte)board.saveIndex);
					}
				});
			}
		}

		//// RVA: 0x15ABC4C Offset: 0x15ABC4C VA: 0x15ABC4C
		public void UnlockPanelListup(int x, int y, List<byte> panelList, List<byte> roadList)
		{
			panelList.Add((byte)m_boardSquareList[x][y].saveIndex);
			OpenPanelSearch(x - 1, y, (BoardSquare board, int bx, int by) =>
			{
				//0x15AC798
				if (board.type == SquareType.Road)
				{
					roadList.Add((byte)board.saveIndex);
				}
				else
				{
					panelList.Add((byte)board.saveIndex);
				}
			});
		}

		//// RVA: 0x15AB364 Offset: 0x15AB364 VA: 0x15AB364
		protected void OpenPanelSearch(int x, int y, Action<BoardSquare, int, int> func)
		{
			for (; x > 0; x--)
			{
				if (m_boardSquareList[x][y].type == SquareType.Road)
				{
					if (func != null)
					{
						func(m_boardSquareList[x][y], x, y);
					}
					if (m_boardSquareList[x][y].id == 2)
					{
						x++;
						y++;
					}
					else if (m_boardSquareList[x][y].id == 1)
					{
						x++;
						y--;
					}
				}
				else if (m_boardSquareList[x][y].type == SquareType.Panel)
				{
					if(m_boardSquareList[x][y].isOpen)
						return;
					if (func != null)
					{
						func(m_boardSquareList[x][y], x, y);
					}
				}
			}
		}

		//// RVA: 0x15ABE08 Offset: 0x15ABE08 VA: 0x15ABE08
		public void GetUnlockParts(List<ISceneGrowthPanel> panelList, List<SceneGrowthRoad> roadList, List<byte> unlockPanelIndexList, List<byte> unlockRoadIndexList)
		{
			panelList.Clear();
			roadList.Clear();
			m_boardSquareList.ForEach((BoardSquare[] col) =>
			{
				//0x15AC848
				for(int j = 0; j < col.Length; j++)
				{
					if(col[j].type == SquareType.Lock || col[j].type == SquareType.Panel)
					{
						if(col[j].panelObject != null)
						{
							int idx = unlockPanelIndexList.FindIndex((byte _) =>
							{
								//0x15ACDDC
								return col[j].saveIndex == _;
							});
							if(idx > -1)
							{
								panelList.Add(col[j].panelObject as ISceneGrowthPanel);
							}
						}
					}
					else if(col[j].type == SquareType.Road)
					{
						if(col[j].panelObject != null)
						{
							int idx = unlockRoadIndexList.FindIndex((byte _) =>
							{
								//0x15ACE50
								return col[j].saveIndex == _;
							});
							if(idx > -1)
							{
								roadList.Add(col[j].panelObject as SceneGrowthRoad);
							}
						}
					}
				}
			});
		}

		//// RVA: 0x15A8BD0 Offset: 0x15A8BD0 VA: 0x15A8BD0
		public void OnChangeScroll(Vector2 position)
		{
			while(-120 > m_scrollRect.content.anchoredPosition.x - m_scrollDiff)
			{
				position.x = m_topPosition;
				m_scrollDiff -= 120;
				if((-1 < position.x) && position.x <= m_lastPosition)
				{
					for (int i = 0; i < 5; i++)
					{
						RemovePanel((int)position.x, i);
						AddPanel((int)position.x + 8, i);
						position.x = m_topPosition;
					}
				}
				m_topPosition = (int)(position.x + 1);
			}
			while(m_scrollRect.content.anchoredPosition.x - m_scrollDiff >= 0)
			{
				m_topPosition--;
				m_scrollDiff += 120;
				if(-1 < m_topPosition && m_topPosition <= m_lastPosition)
				{
					RemovePanel(m_topPosition + 8, 0);
					AddPanel(m_topPosition, 0);
					for(int i = 1; i < 5; i++)
					{
						RemovePanel(m_topPosition + 8, i);
						AddPanel(m_topPosition, i);
					}
				}
			}
		}

		//// RVA: 0x15ABFD0 Offset: 0x15ABFD0 VA: 0x15ABFD0
		protected bool IsPossiblePanel(int x, int y)
		{
			if(m_boardSquareList[x][y].type == SquareType.Panel)
			{
				m_tempItemData.MDHKGJJBLNL();
				OpenPanelSearch(x, y, (BoardSquare board, int bx, int by) =>
				{
					//0x15AC3C0
					if (board.type != SquareType.Panel)
						return;
					AFIFDLOAKGI a = GetPanelItem(board.saveIndex);
					if(a.INDDJNMPONH_StatType == 20)
					{
						if (m_sceneData.KPCLNEADGEM(board.saveIndex) == 0)
							return;
					}
					PCKLFFNPPLF p = new PCKLFFNPPLF();
					p.NCMOCCDGKBP(a, m_tempItemData);
				});
				return m_tempItemData.EFFBJDMGIGO_GetBuyPossible() > 0;
			}
			return false;
		}
	}
}
