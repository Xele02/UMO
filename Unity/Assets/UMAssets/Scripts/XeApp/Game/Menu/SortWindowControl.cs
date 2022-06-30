using System.Collections;
using UnityEngine;
using UnityEngine.Events;

namespace XeApp.Game.Menu
{
	public class SortWindowControl
	{
		// private PopupSortMenuSetting m_sortMenuSetting; // 0x8

		// [IteratorStateMachineAttribute] // RVA: 0x7353EC Offset: 0x7353EC VA: 0x7353EC
		// RVA: 0x12DCC40 Offset: 0x12DCC40 VA: 0x12DCC40
		public IEnumerator Initialize(GameObject parent, UnityAction action)
		{
			UnityEngine.Debug.LogError("TODO SortWindowControl Initialize");
			action();
			yield break;
		}

		// RVA: 0x12DCD20 Offset: 0x12DCD20 VA: 0x12DCD20
		// public void Show(PopupSortMenu.SortPlace place, int divaId, int attrId, UnityAction<PopupSortMenu> okCallBack, Action endCallBack, SortItem sortItem = -1) { }
	}
}
