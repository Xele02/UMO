using System.Collections;
using UnityEngine;
using UnityEngine.Events;

namespace XeApp.Game.Menu
{
	public class PopupFilterSortWindowControl
	{
		private PopupFilterSortSetting m_setting; // 0x8
		private PopupFilterSortUGUISetting m_settingUGUI; // 0xC

		// [IteratorStateMachineAttribute] // RVA: 0x7080FC Offset: 0x7080FC VA: 0x7080FC
		// RVA: 0x179E21C Offset: 0x179E21C VA: 0x179E21C
		public IEnumerator Initialize(GameObject parent, UnityAction action)
		{
			//0x179EC20
			m_setting = new PopupFilterSortSetting();
			m_setting.SetParent(parent.transform);
			m_settingUGUI = new PopupFilterSortUGUISetting();
			m_settingUGUI.SetParent(parent.transform);
			yield return null;
			if (action != null)
				action();
		}

		// RVA: 0x179E2FC Offset: 0x179E2FC VA: 0x179E2FC
		// public void Show(PopupFilterSort.Scene a_type, UnityAction<PopupFilterSort> okCallBack, Action endCallBack, bool a_is_save = True) { }

		// // RVA: 0x179E3E0 Offset: 0x179E3E0 VA: 0x179E3E0
		// public void Show(PopupFilterSortInitParam a_init_param, UnityAction<PopupFilterSort> okCallBack, Action endCallBack) { }

		// // RVA: 0x179E570 Offset: 0x179E570 VA: 0x179E570
		// public void Show(PopupFilterSortUGUI.Scene a_type, UnityAction<PopupFilterSortUGUI> okCallBack, Action endCallBack, bool a_is_save = True) { }

		// // RVA: 0x179E654 Offset: 0x179E654 VA: 0x179E654
		// public void Show(PopupFilterSortUGUIInitParam a_init_param, UnityAction<PopupFilterSortUGUI> okCallBack, Action endCallBack) { }
	}
}
