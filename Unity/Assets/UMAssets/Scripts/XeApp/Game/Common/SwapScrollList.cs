using XeSys.Gfx;
using UnityEngine.UI;
using UnityEngine;
using System.Collections.Generic;
using UnityEngine.Events;

namespace XeApp.Game.Common
{
	public class SwapScrollList : LayoutUGUIScriptBase
	{
		public class SwapScrollUpdateItem : UnityEvent<int, SwapScrollListContent>
		{
		}

		[SerializeField]
		private ScrollRect m_scrollRect; // 0x14
		[SerializeField]
		private Vector2 m_contentRect = new Vector2(32, 32); // 0x18
		[SerializeField]
		private Vector2 m_leftTopPosition; // 0x20
		[SerializeField]
		private List<SwapScrollListContent> m_scrollObjects; // 0x28
		[SerializeField]
		private int m_rowCount = 5; // 0x2C
		[SerializeField]
		private int m_columnCount = 1; // 0x30
		[SerializeField]
		private bool m_isVertical; // 0x34
		private SwapScrollList.SwapScrollUpdateItem m_scrollUpdateItem = new SwapScrollList.SwapScrollUpdateItem(); // 0x38
		private int m_itemCount; // 0x3C
		private int m_listTopPosition; // 0x40
		private float m_diffPrePosition; // 0x44
		private bool m_isContentEscapeMode; // 0x48
		private RectTransform m_contentEscapeRoot; // 0x4C
		private RectTransform m_scrollRectTransfom; // 0x50
		private RawImageEx m_verticalScrollBarImage; // 0x54
		private RawImageEx m_horizontalScrollBarImage; // 0x58

		public List<SwapScrollListContent> ScrollObjects { get { return m_scrollObjects; } } //0x1CCB004
		//public int ListTopPosition { get; } 0x1CCB00C
		public SwapScrollList.SwapScrollUpdateItem OnUpdateItem { get { return m_scrollUpdateItem; } } //0x1CCB014
		public RectTransform ScrollContent { get { return m_scrollRect.content; } } //0x1CCB01C
		public int ScrollObjectCount { get { return m_rowCount * m_columnCount; } } //0x1CCB048
		//public bool IsEnableScroll { get; } 0x1CCB058
		//public Vector2 LeftTopPosition { get; } 0x1CCB0B4
		//public Vector2 ContentSize { get; } 0x1CCB0C8
		public int RowCount { get { return m_rowCount; } } //0x1CCB0DC
		public int ColumnCount { get { return m_columnCount; } } //0x1CCB0E4
		//public ScrollRect ScrollRect { get; } 0x1CCB0EC
		//public float RelativePositon { get; } 0x1CCB0F4
		//public bool Vertical { set; } 0x1CCB198
		private RectTransform ScrollRectTransfom { get {
				if(m_scrollRectTransfom == null)
				{
					m_scrollRectTransfom = m_scrollRect.GetComponent<RectTransform>();
				}
				return m_scrollRectTransfom;
			} } //0x1CCB1A0
		private float AnchoredPosition { get { return m_isVertical ? -m_scrollRect.content.anchoredPosition.y : m_scrollRect.content.anchoredPosition.x; } } //0x1CCB11C
		private float ItemSize { get { return m_isVertical ? m_contentRect.y : m_contentRect.x; } } //0x1CCB56C
		private float ScrollMergin { get { return m_isVertical ? m_leftTopPosition.y : m_leftTopPosition.x; } } //0x1CCB584
		//public ScrollRect.MovementType ScrollMovementType { get; set; } 0x1CCB59C 0x1CCB5C8

		//// RVA: 0x1CCB268 Offset: 0x1CCB268 VA: 0x1CCB268
		private void Awake()
		{
			m_isVertical = m_scrollRect.vertical;
			m_scrollRect.onValueChanged.AddListener(this.UpdateScrollCb);
			for(int i = 0; i < m_scrollObjects.Count; i++)
			{
				m_scrollObjects[i].Index = i;
			}
			if(m_scrollRect.horizontalScrollbar != null)
			{
				m_horizontalScrollBarImage = m_scrollRect.horizontalScrollbar.GetComponent<RawImageEx>();
			}
			if(m_scrollRect.verticalScrollbar != null)
			{
				m_verticalScrollBarImage = m_scrollRect.verticalScrollbar.GetComponent<RawImageEx>();
			}
		}

		//// RVA: 0x1CCB5FC Offset: 0x1CCB5FC VA: 0x1CCB5FC
		public void AddScrollObject(SwapScrollListContent obj)
		{
			m_scrollObjects.Add(obj);
		}

		//// RVA: 0x1CCB67C Offset: 0x1CCB67C VA: 0x1CCB67C
		//public void RemoveScrollObject() { }

		//// RVA: 0x1CCB6F4 Offset: 0x1CCB6F4 VA: 0x1CCB6F4
		//public void Apply(int rowCount, int columnCount, Vector2 contentSize, Vector2 leftTopPosition) { }

		//// RVA: 0x1CCB724 Offset: 0x1CCB724 VA: 0x1CCB724
		public void Apply()
		{
			for(int i = 0; i < m_rowCount; i++)
			{
				for(int j = 0; j < m_columnCount; j++)
				{
					int idx = i * m_columnCount + j;
					SwapScrollListContent item = m_scrollObjects[idx];
					item.AnchorMin = new Vector2(0.0f, 1.0f);
					item.AnchorMax = new Vector2(0.0f, 1.0f);
					item.Pivot = new Vector2(0.0f, 1.0f);
					item.Size = m_contentRect;
					item.Index = idx;
					item.AnchoredPosition = new Vector2(m_contentRect.x * j + m_leftTopPosition.x, -(m_contentRect.y * i + m_leftTopPosition.y));
					item.transform.SetParent(m_scrollRect.content, false);
				}
				for(int j = 0; j < m_columnCount; j++)
				{
					int idx = i * m_columnCount + j;
					SwapScrollListContent item = m_scrollObjects[idx];
					item.RectTransform.SetSiblingIndex((i+1) * m_columnCount - j);
				}
			}
		}

		//// RVA: 0x1CCBCF8 Offset: 0x1CCBCF8 VA: 0x1CCBCF8
		public void SetContentEscapeMode(bool isEnable)
		{
			if(m_isContentEscapeMode != isEnable)
			{
				if(!isEnable)
				{
					for(int i = 0; i < m_scrollObjects.Count; i++)
					{
						if(m_scrollObjects[i].transform.parent == m_contentEscapeRoot)
						{
							m_scrollObjects[i].transform.SetParent(ScrollContent);
						}
					}
				}
				else
				{
					if(m_contentEscapeRoot == null)
					{
						m_contentEscapeRoot = new GameObject("Escaped").AddComponent<RectTransform>();
						m_contentEscapeRoot.SetParent(ScrollContent.parent, false);
						m_contentEscapeRoot.anchorMin = ScrollContent.anchorMin;
						m_contentEscapeRoot.anchorMax = ScrollContent.anchorMax;
						m_contentEscapeRoot.pivot = ScrollContent.pivot;
						m_contentEscapeRoot.sizeDelta = ScrollContent.sizeDelta;
						if (m_isVertical)
						{
							m_contentEscapeRoot.anchoredPosition = new Vector2(1184 + ScrollContent.anchoredPosition.x, ScrollContent.anchoredPosition.y);
						}
						else
						{
							m_contentEscapeRoot.anchoredPosition = new Vector2(ScrollContent.anchoredPosition.x, 792 + ScrollContent.anchoredPosition.y);
						}
					}
					for (int i = 0; i < m_scrollObjects.Count; i++)
					{
						if (!m_scrollObjects[i].gameObject.activeSelf)
						{
							m_scrollObjects[i].gameObject.SetActive(true);
						}
					}
				}
				m_isContentEscapeMode = isEnable;
			}
		}

		//// RVA: 0x1CCC29C Offset: 0x1CCC29C VA: 0x1CCC29C
		public void SetItemCount(int count)
		{
			RectTransform r = m_scrollRect.GetComponent<RectTransform>();
			m_itemCount = count;
			Vector2 s = m_scrollRect.content.sizeDelta;
			if(!m_isVertical)
			{
				int a = m_itemCount % m_rowCount;
				int b = m_itemCount / m_rowCount;
				float f = m_contentRect.x;
				f = (f * b) + (a == 0 ? 0 : f);
				f += Mathf.Abs(2 * m_leftTopPosition.x);
				m_scrollRect.content.sizeDelta = new Vector2(f, s.y);
				m_scrollRect.horizontal = s.x < f;
				if(m_scrollRect.horizontalScrollbar != null)
				{
					m_scrollRect.horizontalScrollbar.interactable = m_scrollRect.horizontal;
				}
				if(m_horizontalScrollBarImage != null)
				{
					m_horizontalScrollBarImage.enabled = m_scrollRect.horizontal;
				}
			}
			else
			{
				int a = m_itemCount % m_columnCount;
				int b = m_itemCount / m_columnCount;
				float f = m_contentRect.y;
				f = (f * b) + (a == 0 ? 0 : f);
				f += Mathf.Abs(2 * m_leftTopPosition.y);
				m_scrollRect.content.sizeDelta = new Vector2(s.x, f);
				m_scrollRect.vertical = s.y < f;
				if (m_scrollRect.verticalScrollbar != null)
				{
					m_scrollRect.verticalScrollbar.interactable = m_scrollRect.horizontal;
				}
				if (m_verticalScrollBarImage != null)
				{
					m_verticalScrollBarImage.enabled = m_scrollRect.horizontal;
				}
			}
			if(m_isContentEscapeMode)
			{
				m_contentEscapeRoot.sizeDelta = m_scrollRect.content.sizeDelta;
			}
		}

		//// RVA: 0x1CCC864 Offset: 0x1CCC864 VA: 0x1CCC864
		public void SetPosition(int position, float xoffset = 0, float yoffset = 0, bool diffUpdate = false)
		{
			Vector2 v = new Vector2(0, 0);
			if(!m_isVertical)
			{
				if(ScrollRectTransfom.sizeDelta.x <= m_scrollRect.content.sizeDelta.x)
				{
					v.x = xoffset - m_contentRect.x * position;
					if (v.x <= (ScrollRectTransfom.sizeDelta.x - m_scrollRect.content.sizeDelta.x))
						v.x = ScrollRectTransfom.sizeDelta.x - m_scrollRect.content.sizeDelta.x;
				}
			}
			else
			{
				if(ScrollRectTransfom.sizeDelta.y <= m_scrollRect.content.sizeDelta.y)
				{
					v.y = yoffset + m_contentRect.y * position;
					if (m_scrollRect.content.sizeDelta.y - ScrollRectTransfom.sizeDelta.y < v.y)
						v.y = m_scrollRect.content.sizeDelta.y - ScrollRectTransfom.sizeDelta.y;
				}
			}
			m_scrollRect.content.anchoredPosition = v;
			m_listTopPosition = 0;
			m_diffPrePosition = 0;
			int cnt = m_isVertical ? m_rowCount : m_columnCount;
			int otherCnt = m_isVertical ? m_columnCount : m_rowCount;
			if (diffUpdate)
			{
				float scrollMergin = ScrollMergin;
				float anchorPos = AnchoredPosition;
				float contentsize = ItemSize;
				while (-(contentsize + contentsize * cnt) <= scrollMergin + anchorPos - m_diffPrePosition)
				{
					m_listTopPosition++;
					m_diffPrePosition -= contentsize;
				}
				while(-(contentsize * cnt) <= scrollMergin + anchorPos - m_diffPrePosition)
				{
					m_listTopPosition--;
					m_diffPrePosition += contentsize;
				}
			}
			for(int i = 0; i < cnt; i++)
			{
				for(int j = otherCnt, k = 0; j > 0; j--, k++)
				{
					m_scrollObjects[i * otherCnt + k].Index = i * otherCnt + k;
					m_scrollObjects[i * otherCnt + k].AnchoredPosition = new Vector2(m_contentRect.x * (m_isVertical ? k : i) + m_leftTopPosition.x, -(m_contentRect.y * (m_isVertical ? i : k) + m_leftTopPosition.y));
					m_scrollObjects[i * otherCnt + k].RectTransform.SetSiblingIndex(i * otherCnt + j);
				}
			}
			UpdateScrollCb(m_scrollRect.normalizedPosition);
		}

		//// RVA: 0x1CCD6CC Offset: 0x1CCD6CC VA: 0x1CCD6CC
		//public void ApplyContentCenterAlign() { }

		//// RVA: 0x1CCD864 Offset: 0x1CCD864 VA: 0x1CCD864
		//public void ResetScrollVelocity() { }

		//// RVA: 0x1CCCD6C Offset: 0x1CCCD6C VA: 0x1CCCD6C
		private void UpdateScrollCb(Vector2 position)
		{
			if(ItemSize > 0)
			{
				if(m_scrollObjects.Count > 0)
				{
					int cnt = 0;
					if (ScrollMergin + AnchoredPosition - m_diffPrePosition < -ItemSize)
					{
						float diff = m_diffPrePosition;
						do
						{
							diff -= ItemSize;
							cnt++;
						} while (ScrollMergin + AnchoredPosition - diff < -ItemSize);
					}
					int itemCount = m_isVertical ? m_rowCount : m_columnCount;
					int otherCnt = m_isVertical ? m_columnCount : m_rowCount;
					if (cnt > itemCount)
					{
						m_diffPrePosition += ItemSize * itemCount;
						m_listTopPosition += cnt;
					}
					while(-ItemSize > (ScrollMergin + AnchoredPosition - m_diffPrePosition))
					{
						m_diffPrePosition -= ItemSize;
						for(int i = 0; i < otherCnt; i++)
						{
							SwapScrollListContent item = m_scrollObjects[0];
							m_scrollObjects.RemoveAt(0);
							m_scrollObjects.Add(item);
							Vector2 v;
							if(!m_isVertical)
							{
								v.x = ItemSize + ScrollMergin;
								v.y = item.AnchoredPosition.y;
							}
							else
							{
								v.y = -(ItemSize + ScrollMergin);
								v.x = item.AnchoredPosition.x;
							}
							item.AnchoredPosition = v;
							item.Index = (m_listTopPosition + cnt) * otherCnt + i;
							if(item.Index < m_itemCount)
							{
								ShowItem(item);
								m_scrollUpdateItem.Invoke(item.Index, item);
							}
							else
							{
								HideItem(item);
							}
							int idx = item.transform.GetSiblingIndex();
							item.transform.SetSiblingIndex(idx - otherCnt + m_scrollObjects.Count);
						}
						m_listTopPosition++;
					}
					if(0 <= (ScrollMergin + AnchoredPosition - m_diffPrePosition))
					{
						float diff = m_diffPrePosition;
						cnt = 0;
						do
						{
							diff += ItemSize;
							cnt++;
						} while (0 <= (ScrollMergin + AnchoredPosition - diff));
					}
					if(itemCount < cnt)
					{
						m_listTopPosition -= cnt;
						m_listTopPosition += itemCount;
						m_diffPrePosition -= ItemSize * itemCount;
					}
					while (0 <= (ScrollMergin + AnchoredPosition - m_diffPrePosition))
					{
						m_listTopPosition--;
						m_diffPrePosition += ItemSize;
						for (int i = otherCnt - 1; i >= 0; i--)
						{
							SwapScrollListContent item = m_scrollObjects[m_scrollObjects.Count - 1];
							m_scrollObjects.RemoveAt(m_scrollObjects.Count - 1);
							m_scrollObjects.Insert(0, item);
							Vector2 v;
							if (!m_isVertical)
							{
								v.x = ItemSize * m_listTopPosition + ScrollMergin;
								v.y = item.AnchoredPosition.y;
							}
							else
							{
								v.y = -(ItemSize * m_listTopPosition + ScrollMergin);
								v.x = item.AnchoredPosition.x;
							}
							item.AnchoredPosition = v;
							item.Index = (m_listTopPosition * otherCnt) + i;
							if (m_listTopPosition < 0)
							{
								HideItem(item);
							}
							else
							{
								ShowItem(item);
								m_scrollUpdateItem.Invoke(item.Index, item);
							}
							int idx = item.transform.GetSiblingIndex();
							item.transform.SetSiblingIndex(idx + otherCnt - m_scrollObjects.Count);
						}
					}
				}
			}
		}

		//// RVA: 0x1CCDA80 Offset: 0x1CCDA80 VA: 0x1CCDA80
		public void VisibleRegionUpdate()
		{
			for(int i = 0; i < m_scrollObjects.Count; i++)
			{
				int idx = m_listTopPosition * (m_isVertical ? m_columnCount : m_rowCount) + i;
				if(idx < 0 || m_itemCount <= idx)
				{
					HideItem(m_scrollObjects[i]);
				}
				else
				{
					ShowItem(m_scrollObjects[i]);
					m_scrollUpdateItem.Invoke(idx, m_scrollObjects[i]);
				}
			}
		}

		//// RVA: 0x1CCD950 Offset: 0x1CCD950 VA: 0x1CCD950
		private void ShowItem(SwapScrollListContent item)
		{
			if(m_isContentEscapeMode)
			{
				item.transform.SetParent(ScrollContent, false);
			}
			else
			{
				item.gameObject.SetActive(true);
			}
		}

		//// RVA: 0x1CCD9EC Offset: 0x1CCD9EC VA: 0x1CCD9EC
		private void HideItem(SwapScrollListContent item)
		{
			if(m_isContentEscapeMode)
			{
				item.transform.SetParent(m_contentEscapeRoot, false);
			}
			else
			{
				item.gameObject.SetActive(false);
			}
		}

		//// RVA: 0x1CCDBE8 Offset: 0x1CCDBE8 VA: 0x1CCDBE8
		//public void SetEnableScrollBar(bool isEnable) { }
	}
}
