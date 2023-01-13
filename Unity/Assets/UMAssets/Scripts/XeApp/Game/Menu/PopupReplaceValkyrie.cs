using UnityEngine;
using UnityEngine.EventSystems;
using XeApp.Game.Common;

namespace XeApp.Game.Menu
{
	public class PopupReplaceValkyrie : UIBehaviour, IPopupContent
	{
		public Transform Parent { get; private set; } // 0xC

		// RVA: 0x161CC80 Offset: 0x161CC80 VA: 0x161CC80 Slot: 17
		public void Initialize(PopupSetting setting, Vector2 size, PopupWindowControl control)
		{
			ReplaceValkyriePopupSetting rsetting = setting as ReplaceValkyriePopupSetting;
			transform.GetComponent<RectTransform>().sizeDelta = size;
			ReplaceValkyrieWindow w = transform.GetComponent<ReplaceValkyrieWindow>();
			w.SetValkyrieData(rsetting.before_data, rsetting.after_data, rsetting.before_data_ab, rsetting.after_data_ab);
			Parent = setting.m_parent;
			gameObject.SetActive(true);
			transform.localPosition = new Vector3(20, 0, 0);
		}

		// RVA: 0x161CF90 Offset: 0x161CF90 VA: 0x161CF90 Slot: 18
		public bool IsScrollable()
		{
			return false;
		}

		// RVA: 0x161CF98 Offset: 0x161CF98 VA: 0x161CF98 Slot: 19
		public void Show()
		{
			gameObject.SetActive(true);
		}

		// RVA: 0x161CFD0 Offset: 0x161CFD0 VA: 0x161CFD0 Slot: 20
		public void Hide()
		{
			gameObject.SetActive(false);
		}

		// RVA: 0x161D008 Offset: 0x161D008 VA: 0x161D008 Slot: 21
		public bool IsReady()
		{
			return transform.GetComponent<ReplaceValkyrieWindow>().IsLoaded();
		}

		// RVA: 0x161D0AC Offset: 0x161D0AC VA: 0x161D0AC Slot: 22
		public void CallOpenEnd()
		{
			return;
		}
	}
}
