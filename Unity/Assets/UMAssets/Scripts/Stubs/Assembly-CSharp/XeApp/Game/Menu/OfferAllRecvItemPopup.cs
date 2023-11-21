using XeApp.Game.Common;
using UnityEngine.UI;
using UnityEngine;
using System.Collections.Generic;
using XeSys.Gfx;

namespace XeApp.Game.Menu
{
	public class OfferAllRecvItemPopup : SwapScrollListContent
	{
		private static List<ViewOfferCompensation> lastCompensationList; // 0x0
		[SerializeField]
		private Text m_cautionText; // 0x20
		[SerializeField]
		private Text m_itemOverText; // 0x24
		[SerializeField]
		private Text m_ucText; // 0x28
		[SerializeField]
		private NumberBase m_ucNumber; // 0x2C
		[SerializeField]
		private SwapScrollList m_scrollList; // 0x30
		private List<ViewOfferGetItem> m_getItemList = new List<ViewOfferGetItem>(); // 0x34

		public static List<ViewOfferCompensation> LastCompensationList { get { return lastCompensationList; } } //0x1520920
		public SwapScrollList List { get { return m_scrollList; } } //0x15209E8

		// RVA: 0x1520984 Offset: 0x1520984 VA: 0x1520984
		public static void SetLastCompensationList(List<ViewOfferCompensation> compensationList)
		{
			lastCompensationList = compensationList;
		}

		//// RVA: 0x15209F0 Offset: 0x15209F0 VA: 0x15209F0
		//public void Setup(bool isLimit) { }

		//// RVA: 0x1522108 Offset: 0x1522108 VA: 0x1522108
		//public void Show() { }

		//// RVA: 0x1522218 Offset: 0x1522218 VA: 0x1522218
		//public void Hide() { }

		//[IteratorStateMachineAttribute] // RVA: 0x6F8374 Offset: 0x6F8374 VA: 0x6F8374
		//// RVA: 0x15221A4 Offset: 0x15221A4 VA: 0x15221A4
		//private IEnumerator Co_MainFlow() { }

		//// RVA: 0x1522270 Offset: 0x1522270 VA: 0x1522270
		//private void OnUpdateListItem(int index, SwapScrollListContent content) { }

		// RVA: 0x1522340 Offset: 0x1522340 VA: 0x1522340 Slot: 5
		public override bool InitializeFromLayout(Layout layout, TexUVListManager uvMan)
		{
			m_ucText.text = JpStringLiterals.StringLiteral_18787;
			Loaded();
			return base.InitializeFromLayout(layout, uvMan);
		}
	}
}
