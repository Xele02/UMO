using UnityEngine;
using XeApp.Game.Common;

namespace XeApp.Game.Menu
{
	public class PopupValkyrieStatus : MonoBehaviour, IPopupContent
	{
		private ValkyrieStatusParam m_param; // 0x10

		public Transform Parent { get; private set; } // 0xC

		// RVA: 0x11622CC Offset: 0x11622CC VA: 0x11622CC Slot: 4
		public void Initialize(PopupSetting setting, Vector2 size, PopupWindowControl control)
		{
			PopupValkyrieStatusSetting s = setting as PopupValkyrieStatusSetting;
			m_param = GetComponent<ValkyrieStatusParam>();
			Parent = setting.m_parent;
			m_param.UpdateContent(s.ViewValkyrieData, s.ViewValkyrieAbilityData);
		}

		// RVA: 0x116245C Offset: 0x116245C VA: 0x116245C Slot: 5
		public bool IsScrollable()
		{
			return false;
		}

		// RVA: 0x1162464 Offset: 0x1162464 VA: 0x1162464 Slot: 6
		public void Show()
		{
			gameObject.SetActive(true);
		}

		// RVA: 0x116249C Offset: 0x116249C VA: 0x116249C Slot: 7
		public void Hide()
		{
			gameObject.SetActive(false);
		}

		// RVA: 0x11624D4 Offset: 0x11624D4 VA: 0x11624D4 Slot: 8
		public bool IsReady()
		{
			if (m_param != null)
				return m_param.IsReady();
			return false;
		}

		// RVA: 0x116258C Offset: 0x116258C VA: 0x116258C Slot: 9
		public void CallOpenEnd()
		{
			return;
		}
	}
}
