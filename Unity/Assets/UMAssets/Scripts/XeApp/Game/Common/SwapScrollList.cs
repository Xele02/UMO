using XeSys.Gfx;
using UnityEngine.UI;
using UnityEngine;
using System.Collections.Generic;

namespace XeApp.Game.Common
{
	public class SwapScrollList : LayoutUGUIScriptBase
	{
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
		//private SwapScrollList.SwapScrollUpdateItem m_scrollUpdateItem = new SwapScrollList.SwapScrollUpdateItem(); // 0x38
		//private int m_itemCount; // 0x3C
		//private int m_listTopPosition; // 0x40
		//private float m_diffPrePosition; // 0x44
		//private bool m_isContentEscapeMode; // 0x48
		//private RectTransform m_contentEscapeRoot; // 0x4C
		//private RectTransform m_scrollRectTransfom; // 0x50
		private RawImageEx m_verticalScrollBarImage; // 0x54
		private RawImageEx m_horizontalScrollBarImage; // 0x58

		//public List<SwapScrollListContent> ScrollObjects { get; } 0x1CCB004
		//public int ListTopPosition { get; } 0x1CCB00C
		//public SwapScrollList.SwapScrollUpdateItem OnUpdateItem { get; } 0x1CCB014
		//public RectTransform ScrollContent { get; } 0x1CCB01C
		public int ScrollObjectCount { get { return m_rowCount * m_columnCount; } } //0x1CCB048
		//public bool IsEnableScroll { get; } 0x1CCB058
		//public Vector2 LeftTopPosition { get; } 0x1CCB0B4
		//public Vector2 ContentSize { get; } 0x1CCB0C8
		//public int RowCount { get; } 0x1CCB0DC
		//public int ColumnCount { get; } 0x1CCB0E4
		//public ScrollRect ScrollRect { get; } 0x1CCB0EC
		//public float RelativePositon { get; } 0x1CCB0F4
		//public bool Vertical { set; } 0x1CCB198
		//private RectTransform ScrollRectTransfom { get; } 0x1CCB1A0
		//private float AnchoredPosition { get; } 0x1CCB11C
		//private float ItemSize { get; } 0x1CCB56C
		//private float ScrollMergin { get; } 0x1CCB584
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
					item.AnchoredPosition = new Vector2(m_contentRect.x * j + m_leftTopPosition.x, m_contentRect.y * i + m_leftTopPosition.y);
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
			UnityEngine.Debug.LogError("TODO !!!");
		}

		//// RVA: 0x1CCC29C Offset: 0x1CCC29C VA: 0x1CCC29C
		//public void SetItemCount(int count) { }

		//// RVA: 0x1CCC864 Offset: 0x1CCC864 VA: 0x1CCC864
		//public void SetPosition(int position, float xoffset = 0, float yoffset = 0, bool diffUpdate = False) { }

		//// RVA: 0x1CCD6CC Offset: 0x1CCD6CC VA: 0x1CCD6CC
		//public void ApplyContentCenterAlign() { }

		//// RVA: 0x1CCD864 Offset: 0x1CCD864 VA: 0x1CCD864
		//public void ResetScrollVelocity() { }

		//// RVA: 0x1CCCD6C Offset: 0x1CCCD6C VA: 0x1CCCD6C
		private void UpdateScrollCb(Vector2 position)
		{
			UnityEngine.Debug.LogError("TODO UpdateScrollCb");
		}

		//// RVA: 0x1CCDA80 Offset: 0x1CCDA80 VA: 0x1CCDA80
		//public void VisibleRegionUpdate() { }

		//// RVA: 0x1CCD950 Offset: 0x1CCD950 VA: 0x1CCD950
		//private void ShowItem(SwapScrollListContent item) { }

		//// RVA: 0x1CCD9EC Offset: 0x1CCD9EC VA: 0x1CCD9EC
		//private void HideItem(SwapScrollListContent item) { }

		//// RVA: 0x1CCDBE8 Offset: 0x1CCDBE8 VA: 0x1CCDBE8
		//public void SetEnableScrollBar(bool isEnable) { }

		//// RVA: 0x1CCDD90 Offset: 0x1CCDD90 VA: 0x1CCDD90
		//public void .ctor() { }
	}
}
