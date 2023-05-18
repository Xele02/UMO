using UnityEngine;
using UnityEngine.EventSystems;
using XeApp.Game.Common;

namespace XeApp.Game.Menu
{
	public class PopupSubPlateContent : UIBehaviour, IPopupContent
	{
		private SubPlatePanel m_panel; // 0xC

		public Transform Parent { get; private set; } // 0x10
		public CFHDKAFLNEP subPlateResult { get; set; } // 0x14

		// RVA: 0x11527E8 Offset: 0x11527E8 VA: 0x11527E8
		private void Awake()
		{
			return;
		}

		// RVA: 0x11527EC Offset: 0x11527EC VA: 0x11527EC Slot: 17
		public void Initialize(PopupSetting setting, Vector2 size, PopupWindowControl control)
		{
			PopupSubPlateContentSetting s = setting as PopupSubPlateContentSetting;
			GetComponent<RectTransform>().anchoredPosition = Vector2.zero;
			GetComponent<RectTransform>().sizeDelta = size;
			Parent = setting.m_parent;
			subPlateResult = s.SubPlateResult;
			m_panel = GetComponentInChildren<SubPlatePanel>();
			m_panel.InitializeFromContent(s.OperationMode);
			if (!s.IsReShowSceneDetail)
				m_panel.DisableTryShowSceneDetail();
		}

		// RVA: 0x1152A60 Offset: 0x1152A60 VA: 0x1152A60 Slot: 18
		public bool IsScrollable()
		{
			return false;
		}

		// RVA: 0x1152A68 Offset: 0x1152A68 VA: 0x1152A68 Slot: 19
		public void Show()
		{
			gameObject.SetActive(true);
		}

		// RVA: 0x1152AA0 Offset: 0x1152AA0 VA: 0x1152AA0 Slot: 20
		public void Hide()
		{
			gameObject.SetActive(false);
		}

		// RVA: 0x1152AD8 Offset: 0x1152AD8 VA: 0x1152AD8 Slot: 21
		public bool IsReady()
		{
			return true;
		}

		// RVA: 0x1152AE0 Offset: 0x1152AE0 VA: 0x1152AE0 Slot: 22
		public void CallOpenEnd()
		{
			m_panel.TryShowSceneDetail();
		}
	}
}
