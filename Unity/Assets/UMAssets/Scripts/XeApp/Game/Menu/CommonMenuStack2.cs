using XeSys.Gfx;
using XeApp.Game.Common;
using UnityEngine;
using System;
using mcrs;

namespace XeApp.Game.Menu
{
	public class CommonMenuStack2 : LayoutLabelScriptBase
	{
		[SerializeField]
		private ActionButton m_backButton; // 0x18
		[SerializeField]
		private CommonMenuStackLabel2 m_label; // 0x1C
		private LayoutSymbolData m_symbolLabel; // 0x20
		private LayoutSymbolData m_symbolButton; // 0x24
		private bool m_buttonVisible; // 0x28
		private bool m_labelVisible; // 0x29
		public Action OnClickBackButton; // 0x2C

		//// RVA: 0x1B4ABD0 Offset: 0x1B4ABD0 VA: 0x1B4ABD0
		public void EnterBackButton(bool forceAnim = false)
		{
			m_backButton.SetOff();
			if (m_buttonVisible && !forceAnim)
				return;
			m_buttonVisible = true;
			m_symbolButton.StartAnim("enter");
		}

		//// RVA: 0x1B4AC90 Offset: 0x1B4AC90 VA: 0x1B4AC90
		public void LeaveBackButton(bool forceAnim = false)
		{
			if (!m_buttonVisible && !forceAnim)
				return;
			m_buttonVisible = false;
			m_symbolButton.StartAnim("leave");
		}

		//// RVA: 0x1B4AD2C Offset: 0x1B4AD2C VA: 0x1B4AD2C
		//public void HideBackButton() { }

		//// RVA: 0x1B4ADB0 Offset: 0x1B4ADB0 VA: 0x1B4ADB0
		public void EnterLabel(CommonMenuStackLabel2.LabelType labelType, int descId, bool forceAnim = false)
		{
			m_label.SetLabel(labelType);
			m_label.SetDescription(labelType, descId);
			if (m_labelVisible && !forceAnim)
				return;
			m_labelVisible = true;
			m_symbolLabel.StartAnim("enter");
		}

		//// RVA: 0x1B4B1F0 Offset: 0x1B4B1F0 VA: 0x1B4B1F0
		public void LeaveLabel(bool forceAnim = false)
		{
			if (!m_labelVisible && !forceAnim)
				return;
			m_labelVisible = false;
			m_symbolLabel.StartAnim("leave");
		}

		//// RVA: 0x1B4B28C Offset: 0x1B4B28C VA: 0x1B4B28C
		//public void HideLabel() { }

		//// RVA: 0x1B4B310 Offset: 0x1B4B310 VA: 0x1B4B310
		//public void EnterLabel() { }

		// RVA: 0x1B4B394 Offset: 0x1B4B394 VA: 0x1B4B394 Slot: 5
		public override bool InitializeFromLayout(Layout layout, TexUVListManager uvMan)
		{
			base.InitializeFromLayout(layout, uvMan);
			m_symbolLabel = CreateSymbol("label_name", layout);
			m_symbolButton = CreateSymbol("back_button", layout);
			m_backButton.ClearOnClickCallback();
			m_backButton.AddOnClickCallback(() =>
			{
				//0x1B4B5DC
				SoundManager.Instance.sePlayerBoot.Play((int)cs_se_boot.SE_BTN_000);
				if (OnClickBackButton != null)
					OnClickBackButton();
			});
			m_symbolLabel.StartAnim("inactive");
			m_symbolButton.StartAnim("inactive");
			m_buttonVisible = false;
			m_labelVisible = false;
			Loaded();
			return true;
		}

		//// RVA: 0x1B4B538 Offset: 0x1B4B538 VA: 0x1B4B538
		//public bool TryPerformBackButton() { }
	}
}
