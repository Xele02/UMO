using UnityEngine;
using UnityEngine.EventSystems;

namespace XeApp.Game.Common
{
	public class PopupLiveSkillRegulationContent : UIBehaviour, IPopupContent
	{
		private LayoutSkillRegulationWindow m_layoutSkillRegulationWindow; // 0xC
		private PopupLiveSkillRegulationSetting m_setting; // 0x10
		private Transform parent; // 0x14

		public Transform Parent { get { return parent; } } //0x1BAE68C

		// RVA: 0x1BAE39C Offset: 0x1BAE39C VA: 0x1BAE39C Slot: 17
		public void Initialize(PopupSetting setting, Vector2 size, PopupWindowControl control)
		{
			PopupLiveSkillRegulationSetting s = setting as PopupLiveSkillRegulationSetting;
			parent = setting.m_parent;
			m_layoutSkillRegulationWindow = s.LayoutSkillRegulationWindow;
			GetComponent<RectTransform>().sizeDelta = PopupWindowControl.GetContentSize2(setting.WindowSize, true);
			m_layoutSkillRegulationWindow.Setup(s.ViewSceneData, s.SkillType);
			gameObject.SetActive(true);
		}

		// RVA: 0x1BAE5A4 Offset: 0x1BAE5A4 VA: 0x1BAE5A4 Slot: 18
		public bool IsScrollable()
		{
			return false;
		}

		// RVA: 0x1BAE5AC Offset: 0x1BAE5AC VA: 0x1BAE5AC Slot: 19
		public void Show()
		{
			return;
		}

		// RVA: 0x1BAE5B0 Offset: 0x1BAE5B0 VA: 0x1BAE5B0 Slot: 20
		public void Hide()
		{
			gameObject.SetActive(false);
		}

		// RVA: 0x1BAE5E8 Offset: 0x1BAE5E8 VA: 0x1BAE5E8 Slot: 21
		public bool IsReady()
		{
			return !KDLPEDBKMID.HHCJCDFCLOB.LNHFLJBGGJB_IsRunning;
		}

		// RVA: 0x1BAE688 Offset: 0x1BAE688 VA: 0x1BAE688 Slot: 22
		public void CallOpenEnd()
		{
			return;
		}
	}
}
