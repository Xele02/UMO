using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using XeApp.Game.Common;
using XeSys.Gfx;

namespace XeApp.Game.Menu
{
	public class PopupDecoSpItemList : UIBehaviour, IPopupContent
	{
		public class ScrollListItem : IFlexibleListItem
		{
			public Vector2 Top { get; set; } // 0x8
			public float Height { get; set; } // 0x10
			public int ResourceType { get; set; } // 0x14
			public FlexibleListItemLayout Layout { get; set; } // 0x18
			public bool IsSet { get; set; } // 0x1C
			public int ListIndex { get; set; } // 0x20
		}

		public class ReceiveScrollListItem : ScrollListItem
		{
			public int itemId { get; private set; } // 0x24
			public int count { get; private set; } // 0x28

			// RVA: 0xF79BFC Offset: 0xF79BFC VA: 0xF79BFC
			public ReceiveScrollListItem(int id, int count)
			{
				itemId = id;
				this.count = count;
			}
		}

		private LayoutDecorationSpItemListPopup m_layoutDecorationSpItemListPopup; // 0x10
		public const int RowCount = 5;
		public const int ColumnCount = 1;
		private static readonly Vector2 StartPos = new Vector2(10, 15); // 0x0
		private static readonly Vector2 Space = new Vector2(16, 22); // 0x8
		private static readonly Vector2 IconSize = new Vector2(458, 118); // 0x10
		private FlexibleItemScrollView m_scrollView = new FlexibleItemScrollView(); // 0x14
		private ScrollRect m_scrollRect; // 0x18
		private PopupWindowControl m_control; // 0x1C
		private List<IFlexibleListItem> m_scrollItem = new List<IFlexibleListItem>(); // 0x20
		public Transform Parent { get; private set; } // 0xC

		// RVA: 0xF7962C Offset: 0xF7962C VA: 0xF7962C
		private void Awake()
		{
			m_scrollRect = GetComponent<ScrollRect>();
			m_scrollView.Initialize(m_scrollRect);
		}

		// RVA: 0xF796BC Offset: 0xF796BC VA: 0xF796BC Slot: 17
		public void Initialize(PopupSetting setting, Vector2 size, PopupWindowControl control)
		{
			m_control = control;
			PopupDecoSpItemListSetting s = setting as PopupDecoSpItemListSetting;
			Parent = s.m_parent;
			RectTransform rt = transform.GetComponent<RectTransform>();
			rt.sizeDelta = size;
			rt.anchoredPosition = new Vector2(0, 0);
			m_scrollRect.content.anchoredPosition = new Vector2(0, 0);
			m_scrollItem.Clear();
			int y = 0;
			for(int i = 0; i < s.Count(); i++)
			{
				ReceiveScrollListItem item = new ReceiveScrollListItem(s[i].id, s[i].count);
				item.Top = new Vector2(0, y);
				item.Height = 110;
				m_scrollItem.Add(item);
				KDLPEDBKMID.HHCJCDFCLOB.BDOFDNICMLC_StartInstallIfNeeded(ItemTextureCache.MakeItemIconTexturePath(item.itemId, 0));
				y -= 110;
			}
			Parent = s.m_parent;
			m_scrollView.UpdateItemListener += UpdateItemListener;
			m_scrollView.SetupListItem(m_scrollItem);
			m_scrollView.SetlistTop(0);
			m_scrollView.SetZeroVelocity();
			m_scrollView.VisibleRangeUpdate();
		}

		// RVA: 0xF79CB8 Offset: 0xF79CB8 VA: 0xF79CB8
		private void UpdateItemListener(IFlexibleListItem obj)
		{
			LayoutDecorationSpItemListPopup p = obj.Layout.GetComponent<LayoutDecorationSpItemListPopup>();
			ReceiveScrollListItem r = obj as ReceiveScrollListItem;
			if(p != null && r != null)
			{
				p.Setting(r.itemId, r.count);
			}
		}

		// RVA: 0xF79E84 Offset: 0xF79E84 VA: 0xF79E84 Slot: 18
		public bool IsScrollable()
		{
			return false;
		}

		// RVA: 0xF79E8C Offset: 0xF79E8C VA: 0xF79E8C Slot: 19
		public void Show()
		{
			gameObject.SetActive(true);
			m_scrollView.LockScroll();
			m_control.ShowGradation();
			m_scrollRect.enabled = true;
		}

		// RVA: 0xF79F2C Offset: 0xF79F2C VA: 0xF79F2C Slot: 20
		public void Hide()
		{
			gameObject.SetActive(false);
			m_scrollView.AllFree();
			m_scrollView.UpdateItemListener -= UpdateItemListener;
		}

		// RVA: 0xF7A030 Offset: 0xF7A030 VA: 0xF7A030 Slot: 21
		public bool IsReady()
		{
			return !KDLPEDBKMID.HHCJCDFCLOB.LNHFLJBGGJB_IsRunning;
		}

		// RVA: 0xF7A0D0 Offset: 0xF7A0D0 VA: 0xF7A0D0 Slot: 22
		public void CallOpenEnd()
		{
			m_scrollView.UnLockScroll();
		}

		// RVA: 0xF7A0FC Offset: 0xF7A0FC VA: 0xF7A0FC
		public void InitializeObject(LayoutUGUIRuntime obj, int count)
		{
			m_scrollView.AddLayoutCache(0, obj, count);
		}
	}
}
