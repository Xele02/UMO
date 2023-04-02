using XeSys.Gfx;
using XeApp.Game.Common;
using UnityEngine;
using UnityEngine.UI;
using System;

namespace XeApp.Game.Menu
{
	public class HomePickup : LayoutLabelScriptBase
	{
		public enum JumpType
		{
			None = 0,
			ExternalSite = 1,
			Detail = 2,
		}

		[SerializeField]
		private ActionButton m_closeButton; // 0x18
		[SerializeField]
		private ActionButton m_jumpButton; // 0x1C
		[SerializeField]
		private CheckboxButton m_rejectCheckbox; // 0x20
		[SerializeField]
		private Text m_checkboxLabelText; // 0x24
		[SerializeField]
		private RawImageEx m_pickupImage; // 0x28
		[SerializeField]
		private RawImageEx m_jumpButtonImage; // 0x2C
		[SerializeField]
		private LayoutUGUIHitOnly m_touchBlocker; // 0x30
		[SerializeField]
		private Text m_pickDayText; // 0x34
		private Rect m_externalSiteUvRect; // 0x38
		private Rect m_detailUvRect; // 0x48
		private LayoutSymbolData m_symbolMain; // 0x58
		private AbsoluteLayout m_layoutTextWindow; // 0x5C

		public bool isReject { get; private set; } // 0x60
		public Action onClickCloseButton { private get; set; } // 0x64
		public Action onClickJumpButton { private get; set; } // 0x68
		public Action onClickRejectCheckbox { private get; set; } // 0x6C

		// // RVA: 0x96C7B0 Offset: 0x96C7B0 VA: 0x96C7B0
		// public void Enter(bool checkReject = False, bool checkBoxHidden = False) { }

		// // RVA: 0x96C8A0 Offset: 0x96C8A0 VA: 0x96C8A0
		// public void Leave() { }

		// // RVA: 0x96C91C Offset: 0x96C91C VA: 0x96C91C
		public void Hide()
		{
			m_symbolMain.StartAnim("wait");
		}

		// // RVA: 0x96C998 Offset: 0x96C998 VA: 0x96C998
		// public bool IsPlaying() { }

		// // RVA: 0x96C9C4 Offset: 0x96C9C4 VA: 0x96C9C4
		public void SetCheckboxLabel(string label)
		{
			m_checkboxLabelText.text = label;
		}

		// // RVA: 0x96CA00 Offset: 0x96CA00 VA: 0x96CA00
		// public void SetPickupImage(IiconTexture image) { }

		// // RVA: 0x96CAE0 Offset: 0x96CAE0 VA: 0x96CAE0
		// public void SetDurationText(string text) { }

		// // RVA: 0x96CBC4 Offset: 0x96CBC4 VA: 0x96CBC4
		// public void SetJumpType(HomePickup.JumpType type) { }

		// RVA: 0x96CCBC Offset: 0x96CCBC VA: 0x96CCBC Slot: 5
		public override bool InitializeFromLayout(Layout layout, TexUVListManager uvMan)
		{
			base.InitializeFromLayout(layout, uvMan);
			m_layoutTextWindow = layout.FindViewByExId("sw_pickup_win_all_swtbl_home_bnr_pickup") as AbsoluteLayout;
			m_layoutTextWindow.StartAllAnimGoStop("02");
			m_symbolMain = CreateSymbol("main", layout);
			m_closeButton.ClearOnClickCallback();
			m_closeButton.AddOnClickCallback(() => {
				//0x96D04C
				if(onClickCloseButton != null)
					onClickCloseButton();
			});
			m_jumpButton.ClearOnClickCallback();
			m_jumpButton.AddOnClickCallback(() => {
				//0x96D060
				if(onClickJumpButton != null)
					onClickJumpButton();
			});
			m_rejectCheckbox.ClearOnClickCallback();
			m_rejectCheckbox.AddOnClickCallback(() => {
				//0x96D074
				isReject = m_rejectCheckbox.IsChecked;
				if(onClickRejectCheckbox != null)
					onClickRejectCheckbox();
			});
			m_externalSiteUvRect = LayoutUGUIUtility.MakeUnityUVRect(uvMan.GetUVData("home_pickup_fnt_01"));
			m_detailUvRect = LayoutUGUIUtility.MakeUnityUVRect(uvMan.GetUVData("home_pickup_fnt_02"));
			Loaded();
			return true;
		}
	}
}
