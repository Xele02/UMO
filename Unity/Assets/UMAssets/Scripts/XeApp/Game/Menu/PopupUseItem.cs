using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;
using XeApp.Game.Common;

namespace XeApp.Game.Menu
{
	public class PopupUseItem : UIBehaviour, IPopupContent
	{
		private UseItemList m_usetItemList; // 0x10

		public Transform Parent { get; private set; } // 0xC
		public int ItemCount { get { return m_usetItemList.ItemCount; } } //0x115FA00

		// RVA: 0x115FA2C Offset: 0x115FA2C VA: 0x115FA2C
		private void Awake()
		{
			m_usetItemList = GetComponent<UseItemList>();
		}

		// RVA: 0x115FA94 Offset: 0x115FA94 VA: 0x115FA94 Slot: 17
		public void Initialize(PopupSetting setting, Vector2 size, PopupWindowControl control)
		{
			PopupUseItemSetting s = setting as PopupUseItemSetting;
			if(!s.IsValidate)
			{
				m_usetItemList.SetInvalidHeader(s.Reason, s.Unlock);
			}
			else
			{
				m_usetItemList.SetConsumeHeader(s.Unlock);
			}
			int cnt = 0;
			for(int i = 0; i < s.ViewGrowItemData.INLBMFMOHCI.Count; i++)
			{
				if(s.ViewGrowItemData.INLBMFMOHCI[i].HMFFHLPNMPH > 0)
				{
					m_usetItemList.SetItem(cnt, s.ViewGrowItemData.INLBMFMOHCI[i].PPFNGGCBJKC_Id, s.ViewGrowItemData.INLBMFMOHCI[i].HMFFHLPNMPH, s.ViewGrowItemData.JPLMJPGDPAN(i + 1));
					cnt++;
				}
			}
			for(int i = cnt; i < m_usetItemList.GetScrollObjectCount(); i++)
			{
				m_usetItemList.SetItemOff(i);
			}
			m_usetItemList.ResetScrollItem(cnt);
			m_usetItemList.GetComponent<RectTransform>().sizeDelta = PopupWindowControl.GetContentSize2(s.WindowSize, s.IsCaption);
			m_usetItemList.SetScrollTopPosition();
			m_usetItemList.SetNeedCredit(s.ViewGrowItemData.CMBGGPOFBOO);
			m_usetItemList.SetHaveCredit(s.ViewGrowItemData.ANFHCKKFIEA(), s.ViewGrowItemData.CMBGGPOFBOO);
			gameObject.SetActive(true);
		}

		// RVA: 0x11600AC Offset: 0x11600AC VA: 0x11600AC Slot: 18
		public bool IsScrollable()
		{
			return false;
		}

		// RVA: 0x11600B4 Offset: 0x11600B4 VA: 0x11600B4 Slot: 19
		public void Show()
		{
			gameObject.SetActive(true);
		}

		// RVA: 0x11600EC Offset: 0x11600EC VA: 0x11600EC Slot: 20
		public void Hide()
		{
			gameObject.SetActive(false);
		}

		// RVA: 0x1160124 Offset: 0x1160124 VA: 0x1160124 Slot: 21
		public bool IsReady()
		{
			return true;
		}

		// RVA: 0x116012C Offset: 0x116012C VA: 0x116012C Slot: 22
		public void CallOpenEnd()
		{
			return;
		}

		//[IteratorStateMachineAttribute] // RVA: 0x7333F4 Offset: 0x7333F4 VA: 0x7333F4
		// RVA: 0x1160130 Offset: 0x1160130 VA: 0x1160130
		public IEnumerator LoadAppendLayoutCoroutine()
		{
			//0x11601E8
			yield return Co.R(m_usetItemList.LoadObjectCoroutine(28));
		}
	}
}
