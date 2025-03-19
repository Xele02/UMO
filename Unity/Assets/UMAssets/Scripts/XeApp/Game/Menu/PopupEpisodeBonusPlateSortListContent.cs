using UnityEngine;
using UnityEngine.EventSystems;
using XeApp.Game.Common;

namespace XeApp.Game.Menu
{
	public class PopupEpisodeBonusPlateSortListContent : UIBehaviour, IPopupContent
	{
		private LayoutEpisodeBonusSortWindow m_episodeLayout; // 0xC
		private PopupEpisodeBonusPlateSortListSetting m_setting; // 0x10
		private Transform parent; // 0x14

		public Transform Parent { get { return parent; } } //0xF88EC8

		// RVA: 0xF88B5C Offset: 0xF88B5C VA: 0xF88B5C Slot: 17
		public void Initialize(PopupSetting setting, Vector2 size, PopupWindowControl control)
		{
			m_setting = setting as PopupEpisodeBonusPlateSortListSetting;
			m_episodeLayout = setting.Content.GetComponent<LayoutEpisodeBonusSortWindow>();
			m_episodeLayout.ScrollItemCount = m_setting.ScrollItemCount;
			m_episodeLayout.UpdateList = m_setting.UpdateList;
			parent = setting.m_parent;
			GetComponent<RectTransform>().sizeDelta = PopupWindowControl.GetContentSize2(setting.WindowSize);
			m_episodeLayout.Setup();
			gameObject.SetActive(true);
		}

		// RVA: 0xF88DE0 Offset: 0xF88DE0 VA: 0xF88DE0 Slot: 18
		public bool IsScrollable()
		{
			return false;
		}

		// RVA: 0xF88DE8 Offset: 0xF88DE8 VA: 0xF88DE8 Slot: 19
		public void Show()
		{
			return;
		}

		// RVA: 0xF88DEC Offset: 0xF88DEC VA: 0xF88DEC Slot: 20
		public void Hide()
		{
			gameObject.SetActive(false);
		}

		// RVA: 0xF88E24 Offset: 0xF88E24 VA: 0xF88E24 Slot: 21
		public bool IsReady()
		{
			return !KDLPEDBKMID.HHCJCDFCLOB.LNHFLJBGGJB_IsRunning;
		}

		// RVA: 0xF88EC4 Offset: 0xF88EC4 VA: 0xF88EC4 Slot: 22
		public void CallOpenEnd()
		{
			return;
		}
	}
}
