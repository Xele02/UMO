using XeSys.Gfx;
using XeApp.Game.Common;
using UnityEngine;
using System;

namespace XeApp.Game.Menu
{
	public class LayoutDecorationRightEditButton : LayoutUGUIScriptBase
	{
		public static readonly string AssetName = "root_deco_edit_R_layout_root"; // 0x0
		private AbsoluteLayout m_base; // 0x14
		public Action OnClickLeftButton; // 0x18
		public Action OnClickRightButton; // 0x1C
		[SerializeField]
		private ActionButton m_leftButton; // 0x20
		[SerializeField]
		private ActionButton m_rightButton; // 0x24
		[SerializeField]
		private RawImageEx m_leftButtonFontImage; // 0x28
		[SerializeField]
		private RawImageEx m_rightButtonFontImage; // 0x2C
		private bool m_isEnter; // 0x30
		private AbsoluteLayout m_rightButtonAnim; // 0x34

		// RVA: 0x18B2B2C Offset: 0x18B2B2C VA: 0x18B2B2C Slot: 5
		public override bool InitializeFromLayout(Layout layout, TexUVListManager uvMan)
		{
			m_base = layout.FindViewById("sw_deco_edit_R_btn_all") as AbsoluteLayout;
			m_rightButtonAnim = layout.FindViewById("swtbl_deco_btn_01") as AbsoluteLayout;
			SettingTexture(uvMan);
			m_leftButton.AddOnClickCallback(() =>
			{
				//0x18B3240
				OnClickLeftButton();
			});
			m_rightButton.AddOnClickCallback(() =>
			{
				//0x18B326C
				OnClickRightButton();
			});
			m_isEnter = false;
			return true;
		}

		// // RVA: 0x18B2F20 Offset: 0x18B2F20 VA: 0x18B2F20
		// public void Enter() { }

		// // RVA: 0x18B2FB4 Offset: 0x18B2FB4 VA: 0x18B2FB4
		// public void Leave() { }

		// // RVA: 0x18B3054 Offset: 0x18B3054 VA: 0x18B3054
		public void Hide()
		{
			m_base.StartChildrenAnimGoStop("st_wait", "st_wait");
		}

		// RVA: 0x18B30D4 Offset: 0x18B30D4 VA: 0x18B30D4
		public bool IsPlayingEnd()
		{
			return !m_base.IsPlaying();
		}

		// // RVA: 0x18B2D40 Offset: 0x18B2D40 VA: 0x18B2D40
		private void SettingTexture(TexUVListManager uvMan)
		{
			m_leftButtonFontImage.uvRect = LayoutUGUIUtility.MakeUnityUVRect(uvMan.GetUVData(string.Format("deco_fnt_08", Array.Empty<object>())));
			m_rightButtonFontImage.uvRect = LayoutUGUIUtility.MakeUnityUVRect(uvMan.GetUVData(string.Format("deco_fnt_17", Array.Empty<object>())));
			m_rightButtonAnim.StartChildrenAnimGoStop("03");
		}

		// // RVA: 0x18B3104 Offset: 0x18B3104 VA: 0x18B3104
		// public void DisableLeftButton() { }

		// // RVA: 0x18B3134 Offset: 0x18B3134 VA: 0x18B3134
		public void EnableLeftButton()
		{
			m_leftButton.Disable = false;
		}

		// // RVA: 0x18B3164 Offset: 0x18B3164 VA: 0x18B3164
		// public void DisableRightButton() { }

		// // RVA: 0x18B3194 Offset: 0x18B3194 VA: 0x18B3194
		// public void EnableRightButton() { }
	}
}
