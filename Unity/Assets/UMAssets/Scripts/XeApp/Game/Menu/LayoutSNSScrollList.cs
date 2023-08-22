using XeSys.Gfx;
using UnityEngine;
using System.Collections.Generic;
using System.Collections;
using System;
using XeSys;

namespace XeApp.Game.Menu
{
	public class LayoutSNSScrollList : LayoutUGUIScriptBase
	{
		private const float TOP_SPACE_ENTRANCE = 45;
		private const float BOTTOM_SPACE_ENTRANCE = 15;
		private const float SPACE_ENTRANCE = 30;
		private const float ITEM_ENTRANCE_H = 105;
		private const float ITEM_ENTRANCE_W = 708;
		private const float TOP_SPACE_ROOM = 40;
		private const float ITEM_TALK_L_H = 128;
		private const float ITEM_TALK_S_H = 108;
		private const float ITEM_HEADERLINE_H = 106;
		private const float ITEM_NEXTBUTTON_H = 106;
		private const float ITEM_ROOM_W = 708;
		private const float SPACE_ROOM = 45;
		private const float BOTTOM_SPACE_ROOM = 0;
		private const float FOCUS_TIME = 5;
		private const float NEAR_VALUE = 10;
		[SerializeField]
		private LayoutUGUIScrollSupport m_scrollSupport; // 0x14
		private List<LayoutSNSTalkLeft> m_freeWindowL = new List<LayoutSNSTalkLeft>(); // 0x18
		private List<LayoutSNSTalkRight> m_freeWindowR = new List<LayoutSNSTalkRight>(); // 0x1C
		private List<LayoutSNSHeadline> m_freeHeadline = new List<LayoutSNSHeadline>(); // 0x20
		private List<LayoutSNSRoomItem> m_freeEntranceItem = new List<LayoutSNSRoomItem>(); // 0x24
		private LayoutSNSNextButton m_freeNextButton; // 0x28
		private LayoutSNSUnopened m_freeUnopened; // 0x2C
		private RectTransform m_scrollRt; // 0x30
		private List<SnsItemObject> m_viewList = new List<SnsItemObject>(128); // 0x34
		private bool m_isScrollUpdateOneSkip; // 0x38
		private bool m_isScrollSetup; // 0x39
		private List<IEnumerator> m_update = new List<IEnumerator>(8); // 0x3C
		private List<IEnumerator> m_animList = new List<IEnumerator>(8); // 0x40
		private AbsoluteLayout m_root; // 0x44
		private CompatibleLayoutAnimeParam m_syncNewIconAnimParam; // 0x48
		private IEnumerator m_onePlaySeScroll; // 0x58
		private List<IEnumerator> m_requestSeList = new List<IEnumerator>(); // 0x5C
		private const int SCROLLRECT_VISIBLE_POS_Y = -80;
		public const int SCROLLRECT_VISIBLE_OFFSET = -80;
		private const int SCROLLBAR_VISIBLE_OFFSET = 65;

		public bool IsOpen { get; private set; } // 0x54
		//public LayoutUGUIScrollSupport ScrollSupport { get; } 0x19345E8

		//[IteratorStateMachineAttribute] // RVA: 0x727E9C Offset: 0x727E9C VA: 0x727E9C
		//// RVA: 0x19345F0 Offset: 0x19345F0 VA: 0x19345F0
		public IEnumerator SetStatusEntrance(FDDIIKBJNNA viewDataSns, Action<int> pressCallback)
		{
			//0x1939980
			m_isScrollSetup = true;
			m_viewList.Clear();
			ResetScrollPosition(m_scrollSupport);
			if(viewDataSns != null)
			{
				for(int i = 0; i < viewDataSns.NPKPBDIDBBG.Count; i++)
				{
					SnsItemObject item = new SnsItemObject();
					item.type = SnsItemObject.eLayoutType.EntranceItem;
					item.animType = SnsItemObject.eAnimType.In;
					item.viewDataRoom = viewDataSns.NPKPBDIDBBG[i];
					Action<int> closeControllerCallback = pressCallback;
					item.entranceCallback = (int roomId) =>
					{
						//0x19393DC
						if (closeControllerCallback != null)
							closeControllerCallback(roomId);
					};
					m_viewList.Add(item);
				}
				Vector3 v = new Vector3(592, 45, 0);
				int height = 45;
				for(int i = 0; i < m_viewList.Count; i++)
				{
					m_viewList[i].pos = v;
					m_viewList[i].size = new Vector3(708, 105, 0);
					v.y += 135;
					height += 135;
				}
				AdjustmentScrollRect();
				if (m_viewList.Count > 0)
					height += 15;
				Vector2 v2 = new Vector2(708, height);
				m_scrollSupport.ContentSize = v2;
				AdjustmentScrollBarHeight();
				SetPositionYInner(0);
				for (int i = 0; i < m_viewList.Count; i++)
				{
					m_viewList[i].animType = SnsItemObject.eAnimType.Wait;
					if (IsCheckRange(i, true))
					{
						m_viewList[i].animType = SnsItemObject.eAnimType.In;
					}
				}
				SetVertical();
			}
			yield break;
		}

		//// RVA: 0x19346D0 Offset: 0x19346D0 VA: 0x19346D0
		public void SetStatusTalk(List<SNSTalkCreater.ViewTalk> talkList, int homeDivaId, int unReadIndex, Action setEndCallback, bool isVisibleNextButton = true)
		{
			GameManager.Instance.StartCoroutineWatched(SetupTalk(talkList, homeDivaId, unReadIndex, setEndCallback, isVisibleNextButton));
		}

		//[IteratorStateMachineAttribute] // RVA: 0x727F14 Offset: 0x727F14 VA: 0x727F14
		//// RVA: 0x19347A8 Offset: 0x19347A8 VA: 0x19347A8
		private IEnumerator SetupTalk(List<SNSTalkCreater.ViewTalk> talkList, int homeDivaId, int unReadIndex, Action setEndCallback, bool isVisibleNextButton)
		{
			//0x193A04C
			m_isScrollSetup = false;
			ResetListObject();
			m_viewList.Clear();
			m_scrollSupport.scrollRect.StopMovement();
			m_requestSeList.Clear();
			for(int i = 0; i < talkList.Count; i++)
			{
				SnsItemObject data = new SnsItemObject();
				data.viewTalk = talkList[i];
				data.type = GetLayoutType(talkList[i], homeDivaId);
				data.isPlaySeItemIn = true;
				m_viewList.Add(data);
			}
			if(talkList.Count == 1 && talkList[0].talk.EDCBHGECEBE)
			{
				m_viewList[0].type = SnsItemObject.eLayoutType.Unopened;
			}
			else
			{
				if(talkList.Count < 1 && isVisibleNextButton)
				{
					SnsItemObject data = new SnsItemObject();
					data.type = SnsItemObject.eLayoutType.NextButton;
					data.viewTalk = null;
					m_viewList.Add(data);
				}
			}
			//LAB_0193a5a8
			Vector3 v = new Vector3(0, 40, 0);
			for(int i = 0; i < m_viewList.Count; i++)
			{
				m_viewList[i].pos = v;
				m_viewList[i].size = new Vector3(708, GetLayoutHeight(m_viewList[i]));
				v.y += 45 + m_viewList[i].size.y;
			}
			AdjustmentScrollRect();
			m_scrollSupport.ContentSize = new Vector2(708, v.y);
			AdjustmentScrollBarHeight();
			yield return null;
			SetPositionYInner(0);
			for(int i = 0; i < m_viewList.Count; i++)
			{
				if(IsCheckRange(i, false))
				{
					m_viewList[i].isPlaySeItemIn = false;
					m_viewList[i].animType = SnsItemObject.eAnimType.In;
				}
			}
			m_isScrollSetup = true;
			m_onePlaySeScroll = PlaySeScroll();
			SetVertical();
			if (setEndCallback != null)
				setEndCallback();
		}

		//// RVA: 0x19348C0 Offset: 0x19348C0 VA: 0x19348C0
		//public SnsItemObject SetStatusTalk(SNSTalkCreater.ViewTalk talk, int homeDivaId, int messageCount) { }

		//// RVA: 0x1935250 Offset: 0x1935250 VA: 0x1935250
		//public SnsItemObject SetNextPageButton() { }

		//// RVA: 0x1934CBC Offset: 0x1934CBC VA: 0x1934CBC
		private SnsItemObject.eLayoutType GetLayoutType(SNSTalkCreater.ViewTalk talk, int homeDivaId)
		{
			if (talk.talk.EDCBHGECEBE)
				return SnsItemObject.eLayoutType.HeaderLine;
			if (talk.talk.IDELKEKDIFD_CharaId != homeDivaId)
				return SnsItemObject.eLayoutType.TalkL;
			return SnsItemObject.eLayoutType.TalkR;
		}

		//// RVA: 0x1934D28 Offset: 0x1934D28 VA: 0x1934D28
		private float GetLayoutHeight(SnsItemObject obj)
		{
			int res = 106;
			if(obj.type != SnsItemObject.eLayoutType.NextButton)
			{
				res = 128;
				if(obj.viewTalk != null && obj.viewTalk.talk != null)
				{
					res = 106;
					if(!obj.viewTalk.talk.EDCBHGECEBE)
					{
						res = 128;
						if (obj.viewTalk.talk.HMKFHLLAKCI_WindowSizeId != 1)
						{
							res = 128;
							if (obj.viewTalk.talk.HMKFHLLAKCI_WindowSizeId == 2)
								res = 108;
						}
					}
				}
			}
			return res;
		}

		//// RVA: 0x19355E0 Offset: 0x19355E0 VA: 0x19355E0
		private void SetVertical()
		{
			m_scrollSupport.scrollRect.vertical = m_scrollSupport.RangeSize.y < m_scrollSupport.ContentSize.y;
		}

		//// RVA: 0x19356A0 Offset: 0x19356A0 VA: 0x19356A0
		//public void TalkIn(Action focusEndCallback) { }

		//// RVA: 0x1935804 Offset: 0x1935804 VA: 0x1935804
		public void TalkOut()
		{
			m_update.Clear();
		}

		//[IteratorStateMachineAttribute] // RVA: 0x727F8C Offset: 0x727F8C VA: 0x727F8C
		//// RVA: 0x193575C Offset: 0x193575C VA: 0x193575C
		//private IEnumerator NewTalkFocus(Action focusEndCallback) { }

		//// RVA: 0x193589C Offset: 0x193589C VA: 0x193589C
		//public bool IsPlayingTalkIn() { }

		//// RVA: 0x1935A18 Offset: 0x1935A18 VA: 0x1935A18
		//public void SetPositionRoom() { }

		//// RVA: 0x1935D04 Offset: 0x1935D04 VA: 0x1935D04
		//public void SetPositionLastRoom() { }

		//// RVA: 0x1935B70 Offset: 0x1935B70 VA: 0x1935B70
		//public float GetPositionLastRoom() { }

		//// RVA: 0x1935DBC Offset: 0x1935DBC VA: 0x1935DBC
		public bool IsCheckRange(int index, bool forceTop = false)
		{
			bool res = false;
			if(index > -1)
			{
				if (index < m_viewList.Count)
				{
					float top, bottom;
					CalcScrollVisibleRange(m_scrollSupport, out top, out bottom, forceTop);
					res = m_viewList[index].pos.y <= bottom && top <= m_viewList[index].pos.y + m_viewList[index].size.y;
				}
			}
			return res;
		}

		//// RVA: 0x1936080 Offset: 0x1936080 VA: 0x1936080
		//public int GetListCount() { }

		//// RVA: 0x1935C14 Offset: 0x1935C14 VA: 0x1935C14
		private void SetPositionYInner(float value)
		{
			if(m_scrollRt != null)
			{
				m_scrollRt.anchoredPosition = new Vector2(m_scrollRt.anchoredPosition.x, value);
			}
		}

		//// RVA: 0x19360F8 Offset: 0x19360F8 VA: 0x19360F8
		//public float CalcSpace(int spaceCount, float layoutSpace, float topSpace, float bottomSpace) { }

		//// RVA: 0x1935D34 Offset: 0x1935D34 VA: 0x1935D34
		//private float CalcPositionLast(int count, float layoutSpace = 0, float topSpace = 0, float bottomSpace = 0) { }

		//// RVA: 0x1935A90 Offset: 0x1935A90 VA: 0x1935A90
		//private float CalcLayoutHeight() { }

		//// RVA: 0x1936130 Offset: 0x1936130 VA: 0x1936130
		public void AddViewEntrance(List<LayoutSNSRoomItem> itemList)
		{
			m_scrollSupport.BeginAddView();
			for(int i = 0; i < itemList.Count; i++)
			{
				m_scrollSupport.AddView(itemList[i].gameObject, 0, 0);
				m_freeEntranceItem.Add(itemList[i]);
				itemList[i].Hide();
			}
			m_scrollSupport.EndAddView();
		}

		//// RVA: 0x1936390 Offset: 0x1936390 VA: 0x1936390
		public void AddViewRoom(List<LayoutSNSHeadline> headlineList, List<LayoutSNSTalkLeft> windowLList, List<LayoutSNSTalkRight> windowRList, LayoutSNSNextButton nextButton, LayoutSNSUnopened unopened)
		{
			m_scrollSupport.BeginAddView();
			m_freeNextButton = nextButton;
			m_freeUnopened = unopened;
			m_scrollSupport.AddView(nextButton.gameObject, 0, 0);
			for(int i = 0; i < headlineList.Count; i++)
			{
				m_scrollSupport.AddView(headlineList[i].gameObject, 0, 0);
				m_freeHeadline.Add(headlineList[i]);
				headlineList[i].Hide();
			}
			for(int i = 0; i < windowLList.Count; i++)
			{
				m_scrollSupport.AddView(windowLList[i].gameObject, 0, 0);
				m_freeWindowL.Add(windowLList[i]);
				windowLList[i].Hide();
			}
			for(int i = 0; i < windowRList.Count; i++)
			{
				m_scrollSupport.AddView(windowRList[i].gameObject, 0, 0);
				m_freeWindowR.Add(windowRList[i]);
				windowRList[i].Hide();
			}
			m_scrollSupport.EndAddView();
		}

		//// RVA: 0x19369A0 Offset: 0x19369A0 VA: 0x19369A0
		private RectTransform GetRectTransformRoot()
		{
			if(MenuScene.Instance != null)
			{
				TransitionRoot tr = MenuScene.Instance.GetCurrentTransitionRoot();
				if(tr != null)
				{
					if(tr.transform.parent != null)
					{
						return tr.transform.parent.GetComponent<RectTransform>(); ;
					}
				}
			}
			return transform.parent.GetComponent<RectTransform>(); ;
		}

		//// RVA: 0x1934DD0 Offset: 0x1934DD0 VA: 0x1934DD0
		public void AdjustmentScrollRect()
		{
			RectTransform rt = GetRectTransformRoot();
			if(rt != null)
			{
				RectTransform rtScroll = m_scrollSupport.scrollRect.GetComponent<RectTransform>();
				rtScroll.anchoredPosition = new Vector2(rtScroll.anchoredPosition.x, -80);
				rtScroll.sizeDelta = new Vector2(rtScroll.sizeDelta.x, rt.sizeDelta.y - 80);
				m_scrollSupport.RangeHeight = rt.sizeDelta.y - 80;
			}
		}

		//// RVA: 0x1934FFC Offset: 0x1934FFC VA: 0x1934FFC
		public void AdjustmentScrollBarHeight()
		{
			if(m_scrollSupport != null)
			{
				if(m_scrollSupport.scrollRect != null)
				{
					if(m_scrollSupport.scrollRect.verticalScrollbar != null)
					{
						RectTransform rt = m_scrollSupport.scrollRect.verticalScrollbar.GetComponent<RectTransform>();
						rt.sizeDelta = new Vector2(rt.sizeDelta.x, rt.sizeDelta.y - 65);
					}
				}
			}
		}

		// RVA: 0x1936C9C Offset: 0x1936C9C VA: 0x1936C9C
		public void Update()
		{
			if(m_update.Count > 0)
			{
				if (m_update[0].MoveNext() == false)
					m_update.RemoveAt(0);
			}
			for(int i = 0; i < m_animList.Count; i++)
			{
				if(m_animList[i] != null)
				{
					if (!m_animList[i].MoveNext())
						m_animList[i] = null;
				}
			}
			UpdateScroll();
		}

		//// RVA: 0x1936FE0 Offset: 0x1936FE0 VA: 0x1936FE0
		private void UpdateScrollInner()
		{
			float top, bottom;
			CalcScrollVisibleRange(m_scrollSupport, out top, out bottom, false);
			for(int i = 0; i < m_viewList.Count; i++)
			{
				if(bottom < m_viewList[i].pos.y || m_viewList[i].pos.y + m_viewList[i].size.y < top)
				{
					if(IsObject(m_viewList[i]))
					{
						m_viewList[i].Hide();
						ReleaseObject(m_viewList[i]);
					}
				}
				else if(!IsObject(m_viewList[i]) && GetFreeObject(m_viewList[i]))
				{
					m_viewList[i].SetStatus(m_viewList[i]);
					m_viewList[i].Show();
					m_requestSeList.Add(m_viewList[i].PlayInItemSe());
				}
			}
			UpdateNewIcon();
			if(m_onePlaySeScroll != null)
			{
				if (!m_onePlaySeScroll.MoveNext())
					m_onePlaySeScroll = null;
			}
			UpdateSeList();
		}

		//// RVA: 0x1936FB0 Offset: 0x1936FB0 VA: 0x1936FB0
		public void UpdateScroll()
		{
			if(IsOpen && m_isScrollSetup)
			{
				if (!m_isScrollUpdateOneSkip)
					UpdateScrollInner();
				else
					m_isScrollUpdateOneSkip = false;
			}
		}

		//// RVA: 0x1937AE4 Offset: 0x1937AE4 VA: 0x1937AE4
		private void UpdateSeList()
		{
			if (m_requestSeList.Count < 1)
				return;
			if(m_requestSeList.Count < 2)
			{
				for(int i = 0; i < m_requestSeList.Count; i++)
				{
					m_requestSeList[i].MoveNext();
				}
			}
			m_requestSeList.Clear();
		}

		//// RVA: 0x1937CE4 Offset: 0x1937CE4 VA: 0x1937CE4
		public void ResetListObject()
		{
			for(int i = 0; i < m_viewList.Count; i++)
			{
				if(m_viewList[i] != null)
				{
					m_viewList[i].Hide();
					ReleaseObject(m_viewList[i]);
					m_viewList[i].Clear();
				}
			}
		}

		//// RVA: 0x1937E94 Offset: 0x1937E94 VA: 0x1937E94
		//public void ResetList() { }

		//// RVA: 0x19380F4 Offset: 0x19380F4 VA: 0x19380F4
		public bool IsPlaying()
		{
			List<SnsItemObject> l = m_viewList.FindAll((SnsItemObject _) =>
			{
				//0x193929C
				return _.layoutBase != null;
			});
			for(int i = 0; i < l.Count; i++)
			{
				if (l[i].layoutBase.IsPlaying())
					return true;
			}
			return false;
		}

		//// RVA: 0x1938308 Offset: 0x1938308 VA: 0x1938308
		public void In()
		{
			if(m_root != null)
			{
				Show();
			}
		}

		//// RVA: 0x19383D4 Offset: 0x19383D4 VA: 0x19383D4
		public void Out()
		{
			if (m_root == null || !IsOpen)
				return;
			IsOpen = false;
			TalkOut();
			ListInnerOut();
			m_animList.Clear();
			m_animList.Add(WaitAnimOut());
		}

		//[IteratorStateMachineAttribute] // RVA: 0x728004 Offset: 0x728004 VA: 0x728004
		//// RVA: 0x19386B8 Offset: 0x19386B8 VA: 0x19386B8
		private IEnumerator WaitAnimOut()
		{
			//0x193A9A4
			while (IsPlayingListInner())
				yield return null;
			ResetListObject();
			m_scrollSupport.ContentSize = Vector2.zero;
			ResetScrollPosition(m_scrollSupport);
			gameObject.SetActive(false);
		}

		//// RVA: 0x19380F8 Offset: 0x19380F8 VA: 0x19380F8
		private bool IsPlayingListInner()
		{
			List<SnsItemObject> l = m_viewList.FindAll((SnsItemObject _) =>
			{
				//0x193929C
				return _.layoutBase != null;
			});
			for(int i = 0; i < l.Count; i++)
			{
				if (l[i].layoutBase.IsPlaying())
					return true;
			}
			return false;
		}

		//// RVA: 0x19384B8 Offset: 0x19384B8 VA: 0x19384B8
		private void ListInnerOut()
		{
			List<SnsItemObject> l = m_viewList.FindAll((SnsItemObject _) =>
			{
				//0x1939338
				return _.layoutBase != null;
			});
			for(int i = 0; i < l.Count; i++)
			{
				l[i].layoutBase.Out();
			}
		}

		//// RVA: 0x1938318 Offset: 0x1938318 VA: 0x1938318
		public void Show()
		{
			if (IsOpen)
				return;
			IsOpen = true;
			m_animList.Clear();
			gameObject.SetActive(true);
		}

		//// RVA: 0x1938764 Offset: 0x1938764 VA: 0x1938764
		//public void Hide() { }

		//// RVA: 0x1937288 Offset: 0x1937288 VA: 0x1937288
		private bool IsObject(SnsItemObject param)
		{
			if (param == null)
				return false;
			switch(param.type)
			{
				case SnsItemObject.eLayoutType.EntranceItem:
					return param.entranceItem != null;
				case SnsItemObject.eLayoutType.HeaderLine:
					return param.headLine != null;
				case SnsItemObject.eLayoutType.TalkR:
					return param.talkWindowR != null;
				case SnsItemObject.eLayoutType.TalkL:
					return param.talkWindowL != null;
				case SnsItemObject.eLayoutType.NextButton:
					return param.nextButton != null;
				case SnsItemObject.eLayoutType.Unopened:
					return param.Unopened != null;
				default:
					return false;
			}
		}

		//// RVA: 0x19373C0 Offset: 0x19373C0 VA: 0x19373C0
		private bool GetFreeObject(SnsItemObject param)
		{
			if (param == null)
				return false;
			switch(param.type)
			{
				case SnsItemObject.eLayoutType.EntranceItem:
					param.entranceItem = GetFreeEntranceItem(param);
					param.layoutBase = param.entranceItem;
					break;
				case SnsItemObject.eLayoutType.HeaderLine:
					param.headLine = GetFreeObjectHeadLine(param);
					param.layoutBase = param.headLine;
					break;
				case SnsItemObject.eLayoutType.TalkR:
					param.talkWindowR = GetFreeObjectTalkR(param);
					param.layoutBase = param.talkWindowR;
					break;
				case SnsItemObject.eLayoutType.TalkL:
					param.talkWindowL = GetFreeObjectTalkL(param);
					param.layoutBase = param.talkWindowL;
					break;
				case SnsItemObject.eLayoutType.NextButton:
					param.nextButton = GetFreeObjectNextButton(param);
					param.layoutBase = param.nextButton;
					break;
				case SnsItemObject.eLayoutType.Unopened:
					param.Unopened = GetFreeObjectUnopened(param);
					param.layoutBase = param.Unopened;
					break;
				default:
					return true;
			}
			return param.layoutBase != null;
		}

		//// RVA: 0x193889C Offset: 0x193889C VA: 0x193889C
		private LayoutSNSRoomItem GetFreeEntranceItem(SnsItemObject param)
		{
			if (m_freeEntranceItem.Count < 1)
				return null;
			param.entranceItem = m_freeEntranceItem[0];
			m_freeEntranceItem.RemoveAt(0);
			return param.entranceItem;
		}

		//// RVA: 0x1938AAC Offset: 0x1938AAC VA: 0x1938AAC
		private LayoutSNSTalkLeft GetFreeObjectTalkL(SnsItemObject param)
		{
			if (m_freeWindowL.Count < 1)
				return null;
			param.talkWindowL = m_freeWindowL[0];
			m_freeWindowL.RemoveAt(0);
			return param.talkWindowL;
		}

		//// RVA: 0x1938BB4 Offset: 0x1938BB4 VA: 0x1938BB4
		private LayoutSNSTalkRight GetFreeObjectTalkR(SnsItemObject param)
		{
			if (m_freeWindowR.Count < 1)
				return null;
			param.talkWindowR = m_freeWindowR[0];
			m_freeWindowR.RemoveAt(0);
			return param.talkWindowR;
		}

		//// RVA: 0x19389A4 Offset: 0x19389A4 VA: 0x19389A4
		private LayoutSNSHeadline GetFreeObjectHeadLine(SnsItemObject param)
		{
			if (m_freeHeadline.Count < 1)
				return null;
			param.headLine = m_freeHeadline[0];
			m_freeHeadline.RemoveAt(0);
			return param.headLine;
		}

		//// RVA: 0x1938CBC Offset: 0x1938CBC VA: 0x1938CBC
		private LayoutSNSNextButton GetFreeObjectNextButton(SnsItemObject param)
		{
			if(m_freeNextButton != null)
			{
				param.nextButton = m_freeNextButton;
				m_freeNextButton = null;
				return param.nextButton;
			}
			return null;
		}

		//// RVA: 0x1938D7C Offset: 0x1938D7C VA: 0x1938D7C
		private LayoutSNSUnopened GetFreeObjectUnopened(SnsItemObject param)
		{
			if (m_freeUnopened == null)
				return null;
			param.Unopened = m_freeUnopened;
			m_freeUnopened = null;
			return param.Unopened;
		}

		//// RVA: 0x1937568 Offset: 0x1937568 VA: 0x1937568
		private void ReleaseObject(SnsItemObject param)
		{
			param.layoutBase = null;
			switch(param.type)
			{
				case SnsItemObject.eLayoutType.EntranceItem:
					if(param.entranceItem != null)
					{
						m_freeEntranceItem.Add(param.entranceItem);
					}
					param.entranceItem = null;
					break;
				case SnsItemObject.eLayoutType.HeaderLine:
					if(param.headLine != null)
					{
						m_freeHeadline.Add(param.headLine);
					}
					param.headLine = null;
					break;
				case SnsItemObject.eLayoutType.TalkR:
					if(param.talkWindowR != null)
					{
						m_freeWindowR.Add(param.talkWindowR);
					}
					param.talkWindowR = null;
					break;
				case SnsItemObject.eLayoutType.TalkL:
					if(param.talkWindowL != null)
					{
						m_freeWindowL.Add(param.talkWindowL);
					}
					param.talkWindowL = null;
					break;
				case SnsItemObject.eLayoutType.NextButton:
					if(param.nextButton != null)
					{
						m_freeNextButton = param.nextButton;
					}
					param.nextButton = null;
					break;
				case SnsItemObject.eLayoutType.Unopened:
					if(param.Unopened != null)
					{
						m_freeUnopened = param.Unopened;
					}
					param.Unopened = null;
					break;
				default:
					return;
			}
		}

		//// RVA: 0x19378EC Offset: 0x19378EC VA: 0x19378EC
		private void UpdateNewIcon()
		{
			int start = m_syncNewIconAnimParam.UpdateFrame(TimeWrapper.deltaTime);
			for(int i = 0; i < m_viewList.Count; i++)
			{
				if(m_viewList[i] != null)
				{
					if(m_viewList[i].entranceItem != null)
					{
						m_viewList[i].entranceItem.SetNewIconFrame(start);
					}
				}
			}
		}

		//[IteratorStateMachineAttribute] // RVA: 0x72807C Offset: 0x72807C VA: 0x72807C
		//// RVA: 0x1938E3C Offset: 0x1938E3C VA: 0x1938E3C
		private IEnumerator PlaySeScroll()
		{
			//0x19398CC
			yield break;
		}

		//// RVA: 0x1935F34 Offset: 0x1935F34 VA: 0x1935F34
		private void CalcScrollVisibleRange(LayoutUGUIScrollSupport support, out float yTop, out float yBottom, bool forceTop = false)
		{
			float f = 1;
			if(!forceTop)
			{
				f = support.scrollRect.verticalNormalizedPosition;
			}
			yTop = (1 - f) * (support.ContentHeight - support.RangeSize.y);
			yBottom = yTop + support.RangeSize.y;
		}

		//// RVA: 0x1936040 Offset: 0x1936040 VA: 0x1936040
		//private bool InScrollView(float x, float y, int w, int h, float yTop, float yBottom) { }

		//// RVA: 0x1937F80 Offset: 0x1937F80 VA: 0x1937F80
		private void ResetScrollPosition(LayoutUGUIScrollSupport support)
		{
			if(support != null)
			{
				support.scrollRect.content.anchoredPosition = Vector2.zero;
				support.scrollRect.StopMovement();
			}
		}

		// RVA: 0x1938ED0 Offset: 0x1938ED0 VA: 0x1938ED0 Slot: 5
		public override bool InitializeFromLayout(Layout layout, TexUVListManager uvMan)
		{
			m_scrollRt = m_scrollSupport.scrollRect.content.GetComponent<RectTransform>();
			m_root = layout.Root[0] as AbsoluteLayout;
			m_syncNewIconAnimParam.Initialize(1, 60);
			Loaded();
			return true;
		}
	}
}
