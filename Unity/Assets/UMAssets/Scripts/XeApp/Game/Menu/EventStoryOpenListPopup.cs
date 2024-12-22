using mcrs;
using UnityEngine;
using UnityEngine.EventSystems;
using XeApp.Game.Common;

namespace XeApp.Game.Menu
{
	public class EventStoryOpenListPopup : UIBehaviour, IPopupContent
	{
		private EventStoryOpenList m_list; // 0x10

		public Transform Parent { get; private set; } // 0xC

		// RVA: 0xB941AC Offset: 0xB941AC VA: 0xB941AC Slot: 17
		public void Initialize(PopupSetting setting, Vector2 size, PopupWindowControl control)
		{
			EventStoryOpenListPopupSetting s = setting as EventStoryOpenListPopupSetting;
			Parent = setting.m_parent;
			transform.localPosition = Vector3.zero;
			GetComponent<RectTransform>().sizeDelta = size;
			m_list = GetComponentInChildren<EventStoryOpenList>();
			m_list.SetViewData(s.StoryData, s.UnlockStoryCount, s.IsShowStoryIcon);
		}

		// RVA: 0xB9436C Offset: 0xB9436C VA: 0xB9436C Slot: 21
		public bool IsReady()
		{
			return !KDLPEDBKMID.HHCJCDFCLOB.LNHFLJBGGJB_IsRunning;
		}

		// RVA: 0xB9440C Offset: 0xB9440C VA: 0xB9440C Slot: 18
		public bool IsScrollable()
		{
			return false;
		}

		// RVA: 0xB94414 Offset: 0xB94414 VA: 0xB94414 Slot: 19
		public void Show()
		{
			gameObject.SetActive(true);
			m_list.ShowTitle();
			SoundManager.Instance.sePlayerBoot.Play((int)cs_se_boot.SE_WND_004);
		}

		// RVA: 0xB944B8 Offset: 0xB944B8 VA: 0xB944B8 Slot: 20
		public void Hide()
		{
			gameObject.SetActive(false);
		}

		// RVA: 0xB944F0 Offset: 0xB944F0 VA: 0xB944F0 Slot: 22
		public void CallOpenEnd()
		{
			return;
		}
	}
}
