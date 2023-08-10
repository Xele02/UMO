using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using XeApp.Game.Menu;
using XeSys.Gfx;

namespace XeApp.Game.Common
{
	public class PopupItemList : LayoutUGUIScriptBase, IPopupContent
	{
		public enum ItemType
		{
			Growth = 0,
			Other = 1,
			LimitOver = 2,
		}
		
		public struct ItemInfo
		{
			public int id; // 0x0
			public int count; // 0x4
			public EKLNMHFCAOI.FKGCBLHOOCL_Category type; // 0x8

			// RVA: 0x7FAA7C Offset: 0x7FAA7C VA: 0x7FAA7C
			public ItemInfo(int id, int count, EKLNMHFCAOI.FKGCBLHOOCL_Category type)
			{
				this.id = id;
				this.count = count;
				this.type = type;
			}
		}

		private struct ItemOrder
		{
			public EKLNMHFCAOI.FKGCBLHOOCL_Category type; // 0x0
			public int id; // 0x4
			public int order; // 0x8
		}

		public class PopupItemIconItem : IFlexibleListItem
		{
			public Vector2 Top { get; set; } // 0x8
			public float Height { get; set; } // 0x10
			public int ResourceType { get; set; } // 0x14
			public FlexibleListItemLayout Layout { get; set; } // 0x18
			public int Id { get; set; } // 0x1C
			public int Count { get; set; } // 0x20
		}

		public class PopupGrowItemIconItem : IFlexibleListItem
		{
			private List<int> itemIds = new List<int>(); // 0x1C
			private List<int> count = new List<int>(); // 0x20

			// Properties
			public Vector2 Top { get; set; } // 0x8
			public float Height { get; set; } // 0x10
			public int ResourceType { get; set; } // 0x14
			public FlexibleListItemLayout Layout { get; set; } // 0x18
			//public List<int> ItemIds { get; } 0xAFFE84
			//public List<int> Count { get; } 0xAFFE8C
		}

		public class PopupItemListSetting : PopupSetting
		{
			private const int MinGrowItemIcon = 11;
			private const int ItemIcon = 45;
			private const int LimitOverItemIcon = 1;

			public ItemType ItemType { get; set; } // 0x34
			public override bool IsPreload { get { return true; } } //0xB0087C
			public override string PrefabPath { get { return ""; } } //0xB00884
			public override bool IsAssetBundle { get { return true; } } //0xB008E0

			//[IteratorStateMachineAttribute] // RVA: 0x73E01C Offset: 0x73E01C VA: 0x73E01C
			// RVA: 0xB008E8 Offset: 0xB008E8 VA: 0xB008E8 Slot: 4
			public override IEnumerator LoadAssetBundlePrefab(Transform parent)
			{
				TodoLogger.LogError(0, "LoadAssetBundlePrefab");
				yield return null;
			}

			//[CompilerGeneratedAttribute] // RVA: 0x73E094 Offset: 0x73E094 VA: 0x73E094
			//// RVA: 0xB0099C Offset: 0xB0099C VA: 0xB0099C
			//private void <LoadAssetBundlePrefab>b__13_0(GameObject instance) { }
		}

		private const int GachaTicketId = 1;
		private MNDAMOGGJBJ m_growItemData; // 0x14
		private FlexibleItemScrollView m_flexibleScrollView = new FlexibleItemScrollView(); // 0x18
		private List<IFlexibleListItem> m_growthList = new List<IFlexibleListItem>(); // 0x1C
		private List<IFlexibleListItem> m_otherList = new List<IFlexibleListItem>(); // 0x20
		private List<ItemInfo> m_itemList = new List<ItemInfo>(); // 0x24
		private ItemType m_dispItemType; // 0x28
		private const int GrowthItemRow = 4;
		private const int GrowthItemColumn = 3;
		private const int OtherItemRow = 5;
		private const int OtherItemColumn = 9;
		private const int OtherItemCountDispMax = 9999;
		private static readonly Vector2 LeftTopOffset = new Vector2(3, 5); // 0x0

		public Transform Parent { get { return MenuScene.Instance.transform; } } //0xAFCDA0

		// RVA: 0xAFCE3C Offset: 0xAFCE3C VA: 0xAFCE3C
		private void Awake()
		{
			m_flexibleScrollView.Initialize(GetComponentInChildren<ScrollRect>());
		}

		// RVA: 0xAFCEC8 Offset: 0xAFCEC8 VA: 0xAFCEC8 Slot: 6
		public void Initialize(PopupSetting setting, Vector2 size, PopupWindowControl control)
		{
			m_growItemData = new MNDAMOGGJBJ();
			m_growItemData.KHEKNNFCAOI(null);
			ListupItem();
			m_flexibleScrollView.UpdateItemListener += OnUpdateGrowItemScrollList;
			if (setting.DefaultTab == PopupTabButton.ButtonLabel.GrowItem)
				ShowGrowthItemList();
			else
				ShowOtherItemList();
		}

		// RVA: 0xAFFC80 Offset: 0xAFFC80 VA: 0xAFFC80 Slot: 7
		public bool IsScrollable()
		{
			return false;
		}

		// RVA: 0xAFFC88 Offset: 0xAFFC88 VA: 0xAFFC88 Slot: 8
		public void Show()
		{
			gameObject.SetActive(true);
		}

		// RVA: 0xAFFCC0 Offset: 0xAFFCC0 VA: 0xAFFCC0 Slot: 9
		public void Hide()
		{
			gameObject.SetActive(false);
			m_flexibleScrollView.AllFree();
			m_flexibleScrollView.UpdateItemListener -= OnUpdateGrowItemScrollList;
		}

		// RVA: 0xAFFDC4 Offset: 0xAFFDC4 VA: 0xAFFDC4 Slot: 10
		public bool IsReady()
		{
			return true;
		}

		// RVA: 0xAFFDCC Offset: 0xAFFDCC VA: 0xAFFDCC Slot: 11
		public void CallOpenEnd()
		{
			return;
		}

		//// RVA: 0xAFFDD0 Offset: 0xAFFDD0 VA: 0xAFFDD0
		public void ChangeList(PopupTabButton.ButtonLabel label)
		{
			TodoLogger.LogError(0, "ChangeList");
		}

		//// RVA: 0xAFF00C Offset: 0xAFF00C VA: 0xAFF00C
		private void ShowGrowthItemList()
		{
			TodoLogger.LogError(0, "ShowGrowthItemList");
		}

		//// RVA: 0xAFF93C Offset: 0xAFF93C VA: 0xAFF93C
		private void ShowOtherItemList()
		{
			TodoLogger.LogError(0, "ShowOtherItemList");
		}

		//// RVA: 0xAFFEE4 Offset: 0xAFFEE4 VA: 0xAFFEE4
		private void OnUpdateGrowItemScrollList(IFlexibleListItem item)
		{
			TodoLogger.LogError(0, "OnUpdateGrowItemScrollList");
		}

		//// RVA: 0xAFD004 Offset: 0xAFD004 VA: 0xAFD004
		private void ListupItem()
		{
			TodoLogger.LogError(0, "ListupItem");
		}
	}
}
