using XeSys.Gfx;
using XeApp.Game.Common;
using UnityEngine;

namespace XeApp.Game.Menu
{
	public class CommonMenuStack : LayoutLabelScriptBase
	{
		[SerializeField]
		private ActionButton m_backButton; // 0x18
		[SerializeField]
		private CommonMenuStackLabel m_label; // 0x1C
		private LayoutSymbolData m_symbolLabel; // 0x20
		private LayoutSymbolData m_symbolButton; // 0x24
		private bool m_buttonVisible; // 0x28
		private bool m_labelVisible; // 0x29

		//// RVA: 0x1B4A0CC Offset: 0x1B4A0CC VA: 0x1B4A0CC
		public void EnterBackButton(bool forceAnim = false)
		{
			m_backButton.SetOff();
			if (m_buttonVisible && !forceAnim)
				return;
			m_buttonVisible = true;
			m_symbolButton.StartAnim("enter");
		}

		//// RVA: 0x1B4A18C Offset: 0x1B4A18C VA: 0x1B4A18C
		public void LeaveBackButton(bool forceAnim = false)
		{
			if (!m_buttonVisible && !forceAnim)
				return;
			m_buttonVisible = false;
			m_symbolButton.StartAnim("leave");
		}

		//// RVA: 0x1B4A228 Offset: 0x1B4A228 VA: 0x1B4A228
		public void HideBackButton()
		{
			m_buttonVisible = false;
			m_symbolButton.StartAnim("inactive");
		}

		//// RVA: 0x1B4A2AC Offset: 0x1B4A2AC VA: 0x1B4A2AC
		public void EnterLabel(CommonMenuStackLabel.LabelType labelType, SceneGroupCategory group, int descId, bool forceAnim = false)
		{
			m_label.SetLabel(labelType);
			m_label.SetDescription(group, descId);
			if (m_labelVisible && !forceAnim)
				return;
			m_labelVisible = true;
			m_symbolLabel.StartAnim("enter");
		}

		//// RVA: 0x1B4A6F0 Offset: 0x1B4A6F0 VA: 0x1B4A6F0
		//public void LeaveLabel(bool forceAnim = False) { }

		//// RVA: 0x1B4A78C Offset: 0x1B4A78C VA: 0x1B4A78C
		public void HideLabel()
		{
			m_labelVisible = false;
			m_symbolLabel.StartAnim("inactive");
		}

		//// RVA: 0x1B4A810 Offset: 0x1B4A810 VA: 0x1B4A810
		//public void EnterLabel() { }

		// RVA: 0x1B4A894 Offset: 0x1B4A894 VA: 0x1B4A894 Slot: 5
		public override bool InitializeFromLayout(Layout layout, TexUVListManager uvMan)
		{
			base.InitializeFromLayout(layout, uvMan);
			m_symbolLabel = CreateSymbol("label_name", layout);
			m_symbolButton = CreateSymbol("back_button", layout);
			m_backButton.ClearOnClickCallback();
			m_backButton.AddOnClickCallback(this.OnClickBackButton);
			m_symbolLabel.StartAnim("inactive");
			m_symbolButton.StartAnim("inactive");
			m_buttonVisible = false;
			m_labelVisible = false;
			Loaded();
			return true;
		}

		//// RVA: 0x1B4AA38 Offset: 0x1B4AA38 VA: 0x1B4AA38
		private void OnClickBackButton()
		{
			SoundManager.Instance.sePlayerBoot.Play(0);
			MenuScene.SaveRequest();
			MenuScene.Instance.Return(true);
		}

		//// RVA: 0x1B4AB2C Offset: 0x1B4AB2C VA: 0x1B4AB2C
		//public bool TryPerformBackButton() { }
	}
}
