using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Events;
using XeApp.Game.Common;

namespace XeApp.Game.Menu
{
	public class SortWindowControl
	{
		private PopupSortMenuSetting m_sortMenuSetting; // 0x8

		// [IteratorStateMachineAttribute] // RVA: 0x7353EC Offset: 0x7353EC VA: 0x7353EC
		// RVA: 0x12DCC40 Offset: 0x12DCC40 VA: 0x12DCC40
		public IEnumerator Initialize(GameObject parent, UnityAction action)
		{
			//0x12DD1E0
			m_sortMenuSetting = new PopupSortMenuSetting();
			m_sortMenuSetting.SetParent(parent.transform);
			yield return null;
			if (action != null)
				action();
		}

		// RVA: 0x12DCD20 Offset: 0x12DCD20 VA: 0x12DCD20
		public void Show(PopupSortMenu.SortPlace place, int divaId, int attrId, UnityAction<PopupSortMenu> okCallBack, Action endCallBack, SortItem sortItem = SortItem.None)
		{
			m_sortMenuSetting.Initialize();
			m_sortMenuSetting.SetDefault(GameManager.Instance.localSave.EPJOACOONAC_GetSave().PPCGEFGJJIC_SortProprty, place, sortItem);
			m_sortMenuSetting.SelectedDivaId = divaId;
			m_sortMenuSetting.SelectedAttrId = attrId;
			PopupWindowManager.Show(m_sortMenuSetting, (PopupWindowControl control, PopupButton.ButtonType type, PopupButton.ButtonLabel label) =>
			{
				//0x12DCFAC
				if(type == PopupButton.ButtonType.Positive)
				{
					PopupSortMenu s = control.Content as PopupSortMenu;
					s.ApplyLocalSaveData(ref GameManager.Instance.localSave.EPJOACOONAC_GetSave().PPCGEFGJJIC_SortProprty);
					GameManager.Instance.localSave.HJMKBCFJOOH_TrySave();
					if(okCallBack != null)
						okCallBack(s);
				}
			}, null, null, null, true, true, false, null, endCallBack);
		}
	}
}
