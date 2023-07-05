using UnityEngine;
using XeApp.Game.Common;

namespace XeApp.Game.Menu
{
	public class PopupDetailCostume : MonoBehaviour, IPopupContent
	{
		private CostumeStatusParam m_param; // 0x10

		public Transform Parent { get; private set; } // 0xC

		// RVA: 0xF808EC Offset: 0xF808EC VA: 0xF808EC Slot: 4
		public void Initialize(PopupSetting setting, Vector2 size, PopupWindowControl control)
		{
			PopupDetailCostumeSetting s = setting as PopupDetailCostumeSetting;
			m_param = GetComponent<CostumeStatusParam>();
			Parent = setting.m_parent;
			m_param.UpdateContent(s.ViewCostumeData, s.ColorId);
		}

		// RVA: 0xF80A7C Offset: 0xF80A7C VA: 0xF80A7C Slot: 5
		public bool IsScrollable()
		{
			return false;
		}

		// RVA: 0xF80A84 Offset: 0xF80A84 VA: 0xF80A84 Slot: 6
		public void Show()
		{
			gameObject.SetActive(true);
		}

		// RVA: 0xF80ABC Offset: 0xF80ABC VA: 0xF80ABC Slot: 7
		public void Hide()
		{
			gameObject.SetActive(false);
		}

		// RVA: 0xF80AF4 Offset: 0xF80AF4 VA: 0xF80AF4 Slot: 8
		public bool IsReady()
		{
			if (m_param != null)
				return m_param.IsReady();
			return false;
		}

		// RVA: 0xF80BAC Offset: 0xF80BAC VA: 0xF80BAC Slot: 9
		public void CallOpenEnd()
		{
			return;
		}
	}
}
