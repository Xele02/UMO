using UnityEngine;
using UnityEngine.EventSystems;
using XeApp.Game.Common;

namespace XeApp.Game.Menu
{
	public class PopupValkyrieSkillCheck : UIBehaviour, IPopupContent
	{
		public Transform Parent { get; private set; } // 0xC

		// RVA: 0x1161118 Offset: 0x1161118 VA: 0x1161118 Slot: 17
		public void Initialize(PopupSetting setting, Vector2 size, PopupWindowControl control)
		{
			ValkyrieSkillCheckPopupSetting s = setting as ValkyrieSkillCheckPopupSetting;
			transform.GetComponent<RectTransform>().sizeDelta = size;
			ValkyrieSkillCheckWindow w = transform.GetComponent<ValkyrieSkillCheckWindow>();
			w.SetSkillData(s.data);
			Parent = setting.m_parent;
			gameObject.SetActive(true);
			transform.localPosition = Vector3.zero;
		}

		// RVA: 0x1161394 Offset: 0x1161394 VA: 0x1161394 Slot: 18
		public bool IsScrollable()
		{
			return false;
		}

		// RVA: 0x116139C Offset: 0x116139C VA: 0x116139C Slot: 19
		public void Show()
		{
			gameObject.SetActive(true);
		}

		// RVA: 0x11613D4 Offset: 0x11613D4 VA: 0x11613D4 Slot: 20
		public void Hide()
		{
			gameObject.SetActive(false);
		}

		// RVA: 0x116140C Offset: 0x116140C VA: 0x116140C Slot: 21
		public bool IsReady()
		{
			return transform.GetComponent<ValkyrieSkillCheckWindow>().IsLoaded();
		}

		// RVA: 0x11614B0 Offset: 0x11614B0 VA: 0x11614B0 Slot: 22
		public void CallOpenEnd()
		{
			return;
		}
	}
}
