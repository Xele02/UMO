using XeSys.Gfx;
using XeApp.Game.Common;
using UnityEngine;
using System.Collections.Generic;
using System;

namespace XeApp.Game.Menu
{
	public class LayoutBingoRewardWindow : LayoutUGUIScriptBase
	{
		[SerializeField]
		private SwapScrollList m_scrollList; // 0x14
		private bool m_isItemIconLoad; // 0x18
		private List<bool> ItemIconLoadedList = new List<bool>(); // 0x1C
		private Action<int> OnClickIcon; // 0x20
		private JJPEIELNEJB.JLHHGLANHGE[] ItemList; // 0x24
		private int m_receivedBingoCount; // 0x28

		public SwapScrollList List { get { return m_scrollList; } } //0x14CB64C

		// RVA: 0x14CB654 Offset: 0x14CB654 VA: 0x14CB654
		private void Start()
		{
			return;
		}

		// RVA: 0x14CB658 Offset: 0x14CB658 VA: 0x14CB658
		private void Update()
		{
			return;
		}

		//// RVA: 0x14CB65C Offset: 0x14CB65C VA: 0x14CB65C
		//public bool ILayoutLoaded() { }

		//// RVA: 0x14CB664 Offset: 0x14CB664 VA: 0x14CB664
		//public void SetUp(int _receivedCount) { }

		//// RVA: 0x14CBA14 Offset: 0x14CBA14 VA: 0x14CBA14
		//public void SettingButton(Action<int> act) { }

		//// RVA: 0x14CBAE8 Offset: 0x14CBAE8 VA: 0x14CBAE8
		//public void SettingItemList(JJPEIELNEJB.JLHHGLANHGE[] _itemlist) { }

		//// RVA: 0x14CB754 Offset: 0x14CB754 VA: 0x14CB754
		//private void InitializeList() { }

		//// RVA: 0x14CB844 Offset: 0x14CB844 VA: 0x14CB844
		//private void SetupList(int count, bool resetScroll) { }

		//// RVA: 0x14CBAF0 Offset: 0x14CBAF0 VA: 0x14CBAF0
		//private void OnUpdateListItem(int index, SwapScrollListContent content) { }

		//// RVA: 0x14CBD3C Offset: 0x14CBD3C VA: 0x14CBD3C
		//public bool IsLoaded() { }

		// RVA: 0x14CBE04 Offset: 0x14CBE04 VA: 0x14CBE04 Slot: 5
		public override bool InitializeFromLayout(Layout layout, TexUVListManager uvMan)
		{
			Loaded();
			return base.InitializeFromLayout(layout, uvMan);
		}
	}
}
