using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using XeSys.Gfx;

namespace XeApp.Game.Menu
{
	public class FlexibleItemScrollView
	{
		// [CompilerGeneratedAttribute] // RVA: 0x67AB3C Offset: 0x67AB3C VA: 0x67AB3C
		public Action<IFlexibleListItem> UpdateItemListener; // 0x8
		private const float EscapePositionX = 1200;
		private List<IFlexibleListItem> m_listItem; // 0xC
		private ScrollRect m_scroll; // 0x10
		private bool m_scrollVertical; // 0x14
		private RectTransform m_scrollRectTransform; // 0x18
		private int m_dispBeginIndex; // 0x1C
		private int m_dispEndIndex; // 0x20
		private Dictionary<int, List<FlexibleListItemLayout>> m_partsChache = new Dictionary<int, List<FlexibleListItemLayout>>(); // 0x24

		// public Dictionary<int, List<FlexibleListItemLayout>> PartsChache { get; } 0xB9DFA4
		// public int DispBeginIndex { get; } 0xB9DFAC
		// public int DispEndIndex { get; } 0xB9DFB4

		// [CompilerGeneratedAttribute] // RVA: 0x70D644 Offset: 0x70D644 VA: 0x70D644
		// // RVA: 0xB9DD8C Offset: 0xB9DD8C VA: 0xB9DD8C
		// public void add_UpdateItemListener(Action<IFlexibleListItem> value) { }

		// [CompilerGeneratedAttribute] // RVA: 0x70D654 Offset: 0x70D654 VA: 0x70D654
		// // RVA: 0xB9DE98 Offset: 0xB9DE98 VA: 0xB9DE98
		// public void remove_UpdateItemListener(Action<IFlexibleListItem> value) { }

		// // RVA: 0xB9DFBC Offset: 0xB9DFBC VA: 0xB9DFBC
		public void Initialize(ScrollRect scroll)
		{
			scroll.onValueChanged.RemoveListener(this.OnUpdateScroll);
			scroll.onValueChanged.AddListener(this.OnUpdateScroll);
			m_scrollRectTransform = scroll.GetComponent<RectTransform>();
			m_scroll = scroll;
			m_scrollVertical = scroll.vertical;
		}

		// // RVA: 0xB9E19C Offset: 0xB9E19C VA: 0xB9E19C
		// public void Release() { }

		// // RVA: 0xB9E2AC Offset: 0xB9E2AC VA: 0xB9E2AC
		// public void ReleaseCache() { }

		// // RVA: 0xB9E5C8 Offset: 0xB9E5C8 VA: 0xB9E5C8
		public void SetupListItem(List<IFlexibleListItem> list)
		{
			if(m_listItem != null)
			{
				for(int i = 0; i < m_listItem.Count; i++)
				{
					Free(m_listItem[i]);
				}
			}
			m_listItem = list;
			float f = 0.0f;
			if(list.Count > 0)
			{
				f = Math.Abs(m_listItem[m_listItem.Count - 1].Top.y - m_listItem[m_listItem.Count - 1].Height);
			}
			m_scroll.content.sizeDelta = new Vector2(0, f);
			m_scroll.vertical = m_scrollRectTransform.sizeDelta.y <= f;
		}

		// // RVA: 0xB9EE28 Offset: 0xB9EE28 VA: 0xB9EE28
		public void SetlistTop(int index)
		{
			AllFree();
			m_scroll.content.anchoredPosition = new Vector2(0, GetScrollPosition(index));
			CalcIndex(out m_dispBeginIndex, out m_dispEndIndex);
			AllocRange(m_dispBeginIndex, m_dispEndIndex);
			for(int i = 0; i < m_listItem.Count; i++)
			{
				if(m_listItem[i].Layout != null)
				{
					OnUpdateItem(m_listItem[i]);
				}
			}
		}

		// // RVA: 0xB9FAAC Offset: 0xB9FAAC VA: 0xB9FAAC
		// public void SetlistBottom(int index) { }

		// // RVA: 0xBA00B4 Offset: 0xBA00B4 VA: 0xBA00B4
		// public void SetlistUpdateOnly() { }

		// // RVA: 0xBA02D0 Offset: 0xBA02D0 VA: 0xBA02D0
		public void VisibleRangeUpdate()
		{
			for(int i = 0; i < m_listItem.Count; i++)
			{
				if(m_listItem[i].Layout != null)
				{
					OnUpdateItem(m_listItem[i]);
				}
			}
		}

		// // RVA: 0xBA04C4 Offset: 0xBA04C4 VA: 0xBA04C4
		public void LockScroll()
		{
			m_scroll.vertical = false;
		}

		// // RVA: 0xBA04F4 Offset: 0xBA04F4 VA: 0xBA04F4
		public void SetZeroVelocity()
		{
			m_scroll.velocity = new Vector2(0, 0);
		}

		// // RVA: 0xBA054C Offset: 0xBA054C VA: 0xBA054C
		public void UnLockScroll()
		{
			m_scroll.vertical = m_scrollRectTransform.sizeDelta.y <= m_scroll.content.sizeDelta.y;
		}

		// // RVA: 0xB9F18C Offset: 0xB9F18C VA: 0xB9F18C
		private float GetScrollPosition(int index)
		{
			if(index >= 0 && index < m_listItem.Count)
			{
				if(m_listItem[index].Top.y >= 0)
					return m_listItem[index].Top.y;
			}
			float val = m_scroll.content.sizeDelta.y - m_scrollRectTransform.sizeDelta.y;
			if(val >= 0)
			{
				val = m_scroll.content.sizeDelta.y - m_scrollRectTransform.sizeDelta.y;
			}
			return val;
		}

		// // RVA: 0xB9FD3C Offset: 0xB9FD3C VA: 0xB9FD3C
		// private float GetScrollPositionBottom(int index) { }

		// // RVA: 0xBA0608 Offset: 0xBA0608 VA: 0xBA0608
		public void AddLayoutCache(int type, LayoutUGUIRuntime runtime, int count)
		{
			List<FlexibleListItemLayout> list = null;
			if(!m_partsChache.TryGetValue(type, out list))
			{
				list = new List<FlexibleListItemLayout>();
				m_partsChache[type] = list;
			}
			for(int i = 0; i < count; i++)
			{
				LayoutUGUIRuntime instance = UnityEngine.Object.Instantiate<LayoutUGUIRuntime>(runtime);
				instance.IsLayoutAutoLoad = false;
				instance.UvMan = runtime.UvMan;
				instance.Layout = runtime.Layout.DeepClone();
				instance.LoadLayout();
				FlexibleListItemLayout flexible = instance.GetComponent<FlexibleListItemLayout>();
				list.Add(flexible);
				instance.transform.SetParent(m_scroll.content, false);
				flexible.RectTransform.sizeDelta = new Vector2(0, 0);
				flexible.RectTransform.pivot = new Vector2(0, 1);
				flexible.RectTransform.anchorMin = new Vector2(0, 1);
				flexible.RectTransform.anchorMax = new Vector2(0, 1);
				flexible.RectTransform.anchoredPosition = new Vector2(1200, 0);
			}
		}

		// // RVA: 0xBA0BC8 Offset: 0xBA0BC8 VA: 0xBA0BC8
		private void OnUpdateScroll(Vector2 position)
		{
			if(m_listItem == null)
				return;
			int start, end;
			CalcIndex(out start, out end);
			if(start < m_dispEndIndex && end > m_dispBeginIndex)
			{
				if(m_dispBeginIndex < start)
					FreeRange(m_dispBeginIndex, start - 1);
				if(m_dispEndIndex > end)
					FreeRange(end + 1, m_dispEndIndex);
				if(start < m_dispBeginIndex)
					AllocRange(start, m_dispBeginIndex - 1);
				if(end > m_dispEndIndex)
					AllocRange(m_dispEndIndex + 1, end);
			}
			else
			{
				FreeRange(m_dispBeginIndex, m_dispEndIndex);
				AllocRange(start, end);
			}
			m_dispBeginIndex = start;
			m_dispEndIndex = end;
		}

		// // RVA: 0xB9F414 Offset: 0xB9F414 VA: 0xB9F414
		private void CalcIndex(out int beginIndex, out int endIndex)
		{
			beginIndex = m_listItem.Count;
			endIndex = -1;
			float f = -m_scroll.content.anchoredPosition.y;
			for(int i = 0; i < m_listItem.Count; i++)
			{
				if(m_listItem[i].Top.y - m_listItem[i].Height <= f)
				{
					beginIndex = i;
					break;
				}
			}
			for(int i = beginIndex; i < m_listItem.Count; i++)
			{
				if(m_listItem[i].Top.y < f - m_scrollRectTransform.sizeDelta.y)
				{
					return;
				}
				endIndex = i;
			}
		}

		// // RVA: 0xB9F824 Offset: 0xB9F824 VA: 0xB9F824
		private void AllocRange(int begin, int end)
		{
			for(int i = begin; i <= end; i++)
			{
				if(m_listItem[i].Layout != null)
				{
					Free(m_listItem[i]);
				}
				Alloc(m_listItem[i]);
			}
		}

		// // RVA: 0xBA0D88 Offset: 0xBA0D88 VA: 0xBA0D88
		private void Alloc(IFlexibleListItem item)
		{
			List<FlexibleListItemLayout> list = null;
			if(m_partsChache.TryGetValue(item.ResourceType, out list))
			{
				if(list.Count > 0)
				{
					FlexibleListItemLayout layout = list[0];
					list.RemoveAt(0);
					layout.RectTransform.anchoredPosition = item.Top;
					item.Layout = layout;
					OnUpdateItem(item);
				}
			}
		}

		// // RVA: 0xBA0CA8 Offset: 0xBA0CA8 VA: 0xBA0CA8
		private void FreeRange(int begin, int end)
		{
			for(int i = begin; i <= end; i++)
			{
				if(i >= 0 && i < m_listItem.Count)
					Free(m_listItem[i]);
			}
		}

		// // RVA: 0xB9F0B8 Offset: 0xB9F0B8 VA: 0xB9F0B8
		public void AllFree()
		{
			for(int i = 0; i < m_listItem.Count; i++)
			{
				Free(m_listItem[i]);
			}
		}

		// // RVA: 0xB9E9FC Offset: 0xB9E9FC VA: 0xB9E9FC
		private void Free(IFlexibleListItem item)
		{
			List<FlexibleListItemLayout> list = null;
			if(m_partsChache.TryGetValue(item.ResourceType, out list))
			{
				if(item.Layout != null)
				{
					list.Add(item.Layout);
					item.Layout.RectTransform.anchoredPosition = new Vector2(1200, 0);
					item.Layout = null;
				}
			}
		}

		// // RVA: 0xB9FA38 Offset: 0xB9FA38 VA: 0xB9FA38
		private void OnUpdateItem(IFlexibleListItem item)
		{
			if(UpdateItemListener != null)
				UpdateItemListener(item);
		}

		// // RVA: 0xBA10A8 Offset: 0xBA10A8 VA: 0xBA10A8
		// public bool IsCacheLoaded() { }

		// // RVA: 0xBA1320 Offset: 0xBA1320 VA: 0xBA1320
		// public void StopScrollMove() { }

		// // RVA: 0xBA1354 Offset: 0xBA1354 VA: 0xBA1354
		// public float GetVerticalScrollSizeRatio() { }

		// // RVA: 0xBA13EC Offset: 0xBA13EC VA: 0xBA13EC
		// public float CurrentVerticalScrollPositon() { }

		// // RVA: 0xBA1418 Offset: 0xBA1418 VA: 0xBA1418
		// public float CurrentHorizontalScrollPositon() { }

		// // RVA: 0xBA1444 Offset: 0xBA1444 VA: 0xBA1444
		// public Vector2 CurrentContentAnchorTopPos() { }

		// // RVA: 0xBA1498 Offset: 0xBA1498 VA: 0xBA1498
		// public Vector2 CurrentContentAnchorBottomPos() { }

		// // RVA: 0xBA1648 Offset: 0xBA1648 VA: 0xBA1648
		// public void SetVerticalScrollPositon(float pos) { }

		// // RVA: 0xBA167C Offset: 0xBA167C VA: 0xBA167C
		// public void SetHorizontalScrollPositon(float pos) { }

		// // RVA: 0xBA16B0 Offset: 0xBA16B0 VA: 0xBA16B0
		// public void SetEnableScrollBar(bool isEnable) { }
	}
}
