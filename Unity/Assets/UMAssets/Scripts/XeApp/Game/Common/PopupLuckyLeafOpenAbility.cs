using UnityEngine;
using UnityEngine.EventSystems;

namespace XeApp.Game.Common
{
	public class PopupLuckyLeafOpenAbility : UIBehaviour, IPopupContent
	{
		private Transform parent; // 0xC
		private LuckyLeafOpenAbility luckyLeafOpenAbilityLayout; // 0x10

		public Transform Parent { get; } // 0x1BAEEDC

		// RVA: 0x1BAEC4C Offset: 0x1BAEC4C VA: 0x1BAEC4C Slot: 17
		public void Initialize(PopupSetting setting, Vector2 size, PopupWindowControl control)
		{
			luckyLeafOpenAbilityLayout = GetComponent<LuckyLeafOpenAbility>();
			PopupLuckyLeafSetting s = setting as PopupLuckyLeafSetting;
			parent = setting.m_parent;
			luckyLeafOpenAbilityLayout.OnClickHelpButton = HelpButtonEvent;
			luckyLeafOpenAbilityLayout.Setup(s.SceneData);
			GetComponent<RectTransform>().sizeDelta = PopupWindowControl.GetContentSize2(s.WindowSize);
		}

		// RVA: 0x1BAEE58 Offset: 0x1BAEE58 VA: 0x1BAEE58 Slot: 18
		public bool IsScrollable()
		{
			return false;
		}

		// RVA: 0x1BAEE60 Offset: 0x1BAEE60 VA: 0x1BAEE60 Slot: 19
		public void Show()
		{
			gameObject.SetActive(true);
		}

		// RVA: 0x1BAEE98 Offset: 0x1BAEE98 VA: 0x1BAEE98 Slot: 20
		public void Hide()
		{
			gameObject.SetActive(false);
		}

		// RVA: 0x1BAEED0 Offset: 0x1BAEED0 VA: 0x1BAEED0 Slot: 21
		public bool IsReady()
		{
			return true;
		}

		// RVA: 0x1BAEED8 Offset: 0x1BAEED8 VA: 0x1BAEED8 Slot: 22
		public void CallOpenEnd()
		{
			return;
		}
		
		//// RVA: 0x1BAEEE4 Offset: 0x1BAEEE4 VA: 0x1BAEEE4
		private void HelpButtonEvent()
		{
			TodoLogger.LogNotImplemented("HelpButtonEvent");
		}
	}
}
