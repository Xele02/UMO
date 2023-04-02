using UnityEngine.UI;
using UnityEngine;
using System.Collections.Generic;
using XeSys.Gfx;
using System;
using UnityEngine.EventSystems;

namespace XeApp.Game.Common
{
	public class UGUILoopScrollList : ScrollRect
	{
		//[HeaderAttribute] // RVA: 0x68C684 Offset: 0x68C684 VA: 0x68C684
		[SerializeField]
		private Vector2 m_contentSize = new Vector2(32, 32); // 0xF0
		[SerializeField]
		//[HeaderAttribute] // RVA: 0x68C6CC Offset: 0x68C6CC VA: 0x68C6CC
		private Vector2 m_spacing; // 0xF8
		//[HeaderAttribute] // RVA: 0x68C714 Offset: 0x68C714 VA: 0x68C714
		[SerializeField]
		private List<UGUILoopScrollContent> m_scrollObjects; // 0x100
		//[HeaderAttribute] // RVA: 0x68C790 Offset: 0x68C790 VA: 0x68C790
		[SerializeField]
		private int m_rowCount = 5; // 0x104
		//[HeaderAttribute] // RVA: 0x68C7F0 Offset: 0x68C7F0 VA: 0x68C7F0
		[SerializeField]
		private int m_columnCount = 1; // 0x108
		[SerializeField]
		//[HeaderAttribute] // RVA: 0x68C850 Offset: 0x68C850 VA: 0x68C850
		private AnimationCurve m_animCurve = AnimationCurve.EaseInOut(0, 0, 1, 1); // 0x10C
		private int m_itemCount; // 0x120
		private int m_listTopPosition; // 0x124
		private float m_diffPrePosition; // 0x128
		private bool m_isContentEscapeMode; // 0x12C
		private bool m_isLoop; // 0x12D
		private int m_loopCount; // 0x130
		private RectTransform m_rectTransform; // 0x134
		private RectTransform m_contentEscapeRoot; // 0x138
		private RawImageEx m_verticalScrollBarImage; // 0x13C
		private RawImageEx m_horizontalScrollBarImage; // 0x140
		private Vector2 m_dragTotalDelta = Vector2.zero; // 0x144
		private float m_animTime; // 0x14C
		private float m_animEndTime; // 0x150
		private Vector2 m_animStartPos = Vector2.zero; // 0x154
		private Vector2 m_animEndPos = Vector2.zero; // 0x15C

		public Vector2 ContentSize { get { return m_contentSize; } } //0x1CD3CF0
		public Vector2 Spacing { get { return m_spacing; } } //0x1CD3D04
		public List<UGUILoopScrollContent> ScrollObjects { get { return m_scrollObjects; } } //0x1CD3D18
		//public int RowCount { get; } 0x1CD3D20
		//public int ColumnCount { get; } 0x1CD3D28
		public int ObjectPoolSize { get { return m_columnCount * m_rowCount; } } //0x1CD3D30
		//public bool IsEnableScroll { get; } 0x1CD3D40
		public bool IsDrag { get; private set; } // 0x110
		public Action<int, UGUILoopScrollContent> OnUpdateItem { get; set; } // 0x114
		public Action OnDragBegin { get; set; } // 0x118
		public Action<Vector2> OnDragEnd { get; set; } // 0x11C

		//public MovementType ScrollMovementType { get; set; } 0x1CD3DB0 0x1CD3DB8
		//public int PosIndex { get; } 0x1CD3DC0
		//public bool IsPlaying { get; } 0x1CD3F58
		//private float AnchoredPosition { get; } 0x1CD3EA8
		//private float ItemSize { get; } 0x1CD3F1C

		// RVA: 0x1CD3F70 Offset: 0x1CD3F70 VA: 0x1CD3F70 Slot: 4
		protected override void Awake()
		{
			base.Awake();
			onValueChanged.AddListener(UpdateScrollCb);
			if (m_rectTransform == null)
				m_rectTransform = transform as RectTransform;
			if(horizontalScrollbar != null)
			{
				m_horizontalScrollBarImage = horizontalScrollbar.GetComponent<RawImageEx>();
			}
			if(verticalScrollbar != null)
			{
				m_verticalScrollBarImage = verticalScrollbar.GetComponent<RawImageEx>();
			}
		}

		// RVA: 0x1CD41EC Offset: 0x1CD41EC VA: 0x1CD41EC Slot: 48
		protected override void LateUpdate()
		{
			if(m_animEndTime >= 0)
			{
				if(m_animEndTime < m_animTime)
				{
					m_animTime = 0;
					m_animEndTime = 0;
					UpdatePosition(m_animEndPos.x, m_animEndPos.y);
				}
				else
				{
					m_animTime += Time.deltaTime;
					Vector2 diff = m_animEndPos - m_animStartPos;
					float d = m_animCurve.Evaluate(1.0f / m_animEndTime * m_animTime);
					Vector2 pos = d * diff + m_animStartPos;
					UpdatePosition(pos.x, pos.y);
				}
				VisibleRegionUpdate();
			}
			if(m_isLoop)
			{
				Vector2 s = GetContentSize(m_itemCount);
				Vector2 p = content.anchoredPosition;
				if(vertical)
				{
					if(p.y < s.y)
					{
						if(p.y >= 0)
						{
							base.LateUpdate();
							return;
						}
						else
						{
							p.y += s.y;
						}
					}
					else
					{
						p.y -= s.y;
					}
				}
				else
				{
					if(-s.x <= p.x)
					{
						if(p.x < 0)
						{
							base.LateUpdate();
							return;
						}
						else
						{
							p.x -= s.x;
						}
					}
					else
					{
						p.x += s.x;
					}
				}
				content.anchoredPosition = p;
				UpdatePrevData();
				UpdateScrollCb(normalizedPosition);
				VisibleRegionUpdate();
			}
			base.LateUpdate();
		}

		// RVA: 0x1CD55AC Offset: 0x1CD55AC VA: 0x1CD55AC Slot: 42
		public override void OnScroll(PointerEventData eventData)
		{
			TodoLogger.Log(0, "OnScroll");
		}

		// RVA: 0x1CD55B4 Offset: 0x1CD55B4 VA: 0x1CD55B4 Slot: 44
		public override void OnBeginDrag(PointerEventData eventData)
		{
			TodoLogger.Log(0, "OnBeginDrag");
		}

		// RVA: 0x1CD567C Offset: 0x1CD567C VA: 0x1CD567C Slot: 46
		public override void OnDrag(PointerEventData eventData)
		{
			TodoLogger.Log(0, "OnDrag");
		}

		// RVA: 0x1CD5768 Offset: 0x1CD5768 VA: 0x1CD5768 Slot: 45
		public override void OnEndDrag(PointerEventData eventData)
		{
			TodoLogger.Log(0, "OnEndDrag");
		}

		//// RVA: 0x1CD5844 Offset: 0x1CD5844 VA: 0x1CD5844
		//public bool IsEnableTouchId(PointerEventData eventData) { }

		//// RVA: 0x1CD5880 Offset: 0x1CD5880 VA: 0x1CD5880
		public void AddScrollObject(UGUILoopScrollContent obj)
		{
			m_scrollObjects.Add(obj);
		}

		//// RVA: 0x1CD5900 Offset: 0x1CD5900 VA: 0x1CD5900
		//public void RemoveScrollObject(UGUILoopScrollContent obj) { }

		//// RVA: 0x1CD5980 Offset: 0x1CD5980 VA: 0x1CD5980
		public void ClearScrollObject()
		{
			m_scrollObjects.Clear();
		}

		//// RVA: 0x1CD59F8 Offset: 0x1CD59F8 VA: 0x1CD59F8
		public void Apply(int rowCount, int columnCount, Vector2 contentSize)
		{
			m_rowCount = rowCount;
			m_columnCount = columnCount;
			m_contentSize = contentSize;
			Apply();
		}

		//// RVA: 0x1CD5A10 Offset: 0x1CD5A10 VA: 0x1CD5A10
		public void Apply()
		{
			TodoLogger.Log(TodoLogger.UI, "Apply");
		}

		//// RVA: 0x1CD5DB0 Offset: 0x1CD5DB0 VA: 0x1CD5DB0
		//public void SetContentEscapeMode(bool isEnable) { }

		//// RVA: 0x1CD63A4 Offset: 0x1CD63A4 VA: 0x1CD63A4
		public void SetItemCount(int count, bool isLoop = false)
		{
			TodoLogger.Log(TodoLogger.UI, "SetItemCount");
		}

		//// RVA: 0x1CD493C Offset: 0x1CD493C VA: 0x1CD493C
		private Vector2 GetContentSize(int count)
		{
			TodoLogger.Log(0, "GetContentSize");
			return Vector2.zero;
		}

		//// RVA: 0x1CD66C0 Offset: 0x1CD66C0 VA: 0x1CD66C0
		public void SetPosition(int index, float animTime = 0)
		{
			TodoLogger.Log(TodoLogger.UI, "SetPosition");
		}

		//// RVA: 0x1CD6964 Offset: 0x1CD6964 VA: 0x1CD6964
		//public void SetPosition(float xpos, float ypos, float animTime = 0) { }

		//// RVA: 0x1CD44F4 Offset: 0x1CD44F4 VA: 0x1CD44F4
		private void UpdatePosition(float xpos, float ypos)
		{
			content.anchoredPosition = new Vector2(xpos, ypos);
			m_listTopPosition = 0;
			m_diffPrePosition = 0;
			int mCount = m_columnCount;
			int nCount = m_rowCount;
			if(vertical)
			{
				mCount = m_rowCount;
				nCount = m_columnCount;
			}
			for(int i = 0; i < mCount; i++)
			{
				for(int j = nCount, k = 0; j > 0; j--, k++)
				{
					if(m_scrollObjects.Count > (i * nCount + k))
					{
						m_scrollObjects[(i * nCount + k)].AnchoredPosition = new Vector2(
								vertical ? (m_contentSize.x + m_spacing.x) * k : (m_contentSize.x + m_spacing.x) * i,
								vertical ? i : k
							);
						m_scrollObjects[(i * nCount + k)].RectTransform.SetSiblingIndex(i * nCount + j);
					}
				}
			}
			UpdateScrollCb(normalizedPosition);
		}

		//// RVA: 0x1CD6A28 Offset: 0x1CD6A28 VA: 0x1CD6A28
		//public void ResetScrollVelocity() { }

		//// RVA: 0x1CD4AB8 Offset: 0x1CD4AB8 VA: 0x1CD4AB8
		private void UpdateScrollCb(Vector2 position)
		{
			TodoLogger.Log(TodoLogger.UI, "UpdateScrollCb");
		}

		//// RVA: 0x1CD47C4 Offset: 0x1CD47C4 VA: 0x1CD47C4
		public void VisibleRegionUpdate()
		{
			TodoLogger.Log(TodoLogger.UI, "VisibleRegionUpdate");
		}

		//// RVA: 0x1CD6AC4 Offset: 0x1CD6AC4 VA: 0x1CD6AC4
		//private void ShowItem(UGUILoopScrollContent item) { }

		//// RVA: 0x1CD6B64 Offset: 0x1CD6B64 VA: 0x1CD6B64
		//private void HideItem(UGUILoopScrollContent item) { }

		//// RVA: 0x1CD6BF8 Offset: 0x1CD6BF8 VA: 0x1CD6BF8
		//public void SetEnableScrollBar(bool isEnable) { }
	}
}
