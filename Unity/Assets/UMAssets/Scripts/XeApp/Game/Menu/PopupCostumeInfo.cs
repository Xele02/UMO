using UnityEngine;
using UnityEngine.EventSystems;
using XeApp.Game.Common;

namespace XeApp.Game.Menu
{
	public class PopupCostumeInfo : UIBehaviour, IPopupContent
	{
		public Transform Parent { get; private set; } // 0xC

		// RVA: 0x1342BE4 Offset: 0x1342BE4 VA: 0x1342BE4 Slot: 17
		public void Initialize(PopupSetting setting, Vector2 size, PopupWindowControl control)
		{
			CostumeInfoPopupSetting csetting = setting as CostumeInfoPopupSetting;
			Parent = setting.m_parent;
			transform.GetComponent<RectTransform>().sizeDelta = size;
			transform.localPosition = new Vector3(0, 0, 0);
			CostumeInfoWindow w = transform.GetComponent<CostumeInfoWindow>();
			w.SetCheckButton();
			w.SetCostumeData(csetting.beforeData,csetting.afterData);
		}

		// RVA: 0x1342E3C Offset: 0x1342E3C VA: 0x1342E3C Slot: 18
		public bool IsScrollable()
		{
			return false;
		}

		// RVA: 0x1342E44 Offset: 0x1342E44 VA: 0x1342E44 Slot: 19
		public void Show()
		{
			gameObject.SetActive(true);
		}

		// RVA: 0x1342E7C Offset: 0x1342E7C VA: 0x1342E7C Slot: 20
		public void Hide()
		{
			gameObject.SetActive(false);
		}

		// RVA: 0x1342EB4 Offset: 0x1342EB4 VA: 0x1342EB4 Slot: 21
		public bool IsReady()
		{
			return transform.GetComponent<CostumeInfoWindow>().IsLoaded();
		}

		// RVA: 0x1342F58 Offset: 0x1342F58 VA: 0x1342F58 Slot: 22
		public void CallOpenEnd()
		{
			return;
		}
	}
}
