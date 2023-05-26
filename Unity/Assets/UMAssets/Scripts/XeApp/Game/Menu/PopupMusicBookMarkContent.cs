using UnityEngine;
using UnityEngine.EventSystems;
using XeApp.Game.Common;

namespace XeApp.Game.Menu
{
	public class PopupMusicBookMarkContent : UIBehaviour, IPopupContent
	{
		private PopupMusicBookMarkSetting m_setting; // 0xC
		private Transform parent; // 0x10

		public Transform Parent { get { return parent; } } //0x1690740

		// RVA: 0x1690104 Offset: 0x1690104 VA: 0x1690104 Slot: 17
		public void Initialize(PopupSetting setting, Vector2 size, PopupWindowControl control)
		{
			m_setting = setting as PopupMusicBookMarkSetting;
			parent = setting.m_parent;
			GetComponent<RectTransform>().sizeDelta = PopupWindowControl.GetContentSize2(setting.WindowSize, true);
			m_setting.Layout.SelectMusicData = m_setting.SelectMusicData;
			m_setting.Layout.m_bookMarkMusicList.VerticalMusicDataList = m_setting.VerticalMusicDataList;
			m_setting.Layout.Initialize(m_setting.Initialize);
			gameObject.SetActive(true);
		}

		// RVA: 0x1690658 Offset: 0x1690658 VA: 0x1690658 Slot: 18
		public bool IsScrollable()
		{
			return false;
		}

		// RVA: 0x1690660 Offset: 0x1690660 VA: 0x1690660 Slot: 19
		public void Show()
		{
			return;
		}

		// RVA: 0x1690664 Offset: 0x1690664 VA: 0x1690664 Slot: 20
		public void Hide()
		{
			gameObject.SetActive(false);
		}

		// RVA: 0x169069C Offset: 0x169069C VA: 0x169069C Slot: 21
		public bool IsReady()
		{
			return !KDLPEDBKMID.HHCJCDFCLOB.LNHFLJBGGJB_IsRunning;
		}

		// RVA: 0x169073C Offset: 0x169073C VA: 0x169073C Slot: 22
		public void CallOpenEnd()
		{
			return;
		}
	}
}
