using XeSys.Gfx;
using XeApp.Game.Common;
using UnityEngine;
using System;

namespace XeApp.Game.Menu
{
	public class LayoutDecorationLeftEditButton : LayoutUGUIScriptBase
	{
		public static readonly string AssetName = "root_deco_edit_L_layout_root"; // 0x0
		private AbsoluteLayout m_base; // 0x14
		public Action OnClickLeftButton; // 0x18
		public Action OnClickRightButton; // 0x1C
		[SerializeField]
		private ActionButton m_leftButton; // 0x20
		[SerializeField]
		private RawImageEx m_leftButtonFontImage; // 0x24
		[SerializeField]
		private ActionButton m_rightButton; // 0x28
		[SerializeField]
		private RawImageEx m_rightButtonFontImage; // 0x2C
		private bool m_isEnter; // 0x30

		// RVA: 0x18AFE44 Offset: 0x18AFE44 VA: 0x18AFE44 Slot: 5
		public override bool InitializeFromLayout(Layout layout, TexUVListManager uvMan)
		{
			m_base = layout.FindViewById("sw_deco_edit_L_btn_all") as AbsoluteLayout;
			SettingTexture(uvMan);
			m_leftButton.AddOnClickCallback(() =>
			{
				//0x18B04B0
				OnClickLeftButton();
			});
			m_rightButton.AddOnClickCallback(() =>
			{
				//0x18B04DC
				OnClickRightButton();
			});
			m_isEnter = false;
			return true;
		}

		// // RVA: 0x18B0190 Offset: 0x18B0190 VA: 0x18B0190
		public void Enter()
		{
			m_isEnter = true;
			m_base.StartChildrenAnimGoStop("go_in", "st_in");
		}

		// // RVA: 0x18B0224 Offset: 0x18B0224 VA: 0x18B0224
		public void Leave()
		{
			if(!m_isEnter)
				return;
			m_isEnter = false;
			m_base.StartChildrenAnimGoStop("go_out", "st_out");
		}

		// // RVA: 0x18B02C4 Offset: 0x18B02C4 VA: 0x18B02C4
		public void Hide()
		{
			m_base.StartChildrenAnimGoStop("st_wait", "st_wait");
		}

		// RVA: 0x18B0344 Offset: 0x18B0344 VA: 0x18B0344
		public bool IsPlayingEnd()
		{
			return !m_base.IsPlaying();
		}

		// // RVA: 0x18B0374 Offset: 0x18B0374 VA: 0x18B0374
		public void EnableLeftButton()
		{
			m_leftButton.Disable = false;
		}

		// // RVA: 0x18B03A4 Offset: 0x18B03A4 VA: 0x18B03A4
		public void DisableLeftButton()
		{
			m_leftButton.Disable = true;
		}

		// // RVA: 0x18B03D4 Offset: 0x18B03D4 VA: 0x18B03D4
		public void EnableRightButton()
		{
			m_rightButton.Disable = false;
		}

		// // RVA: 0x18B0404 Offset: 0x18B0404 VA: 0x18B0404
		public void DisableRightButton()
		{
			m_rightButton.Disable = true;
		}

		// // RVA: 0x18AFFE0 Offset: 0x18AFFE0 VA: 0x18AFFE0
		private void SettingTexture(TexUVListManager uvMan)
		{
			m_leftButtonFontImage.uvRect = LayoutUGUIUtility.MakeUnityUVRect(uvMan.GetUVData(string.Format("deco_fnt_14", Array.Empty<object>())));
			m_rightButtonFontImage.uvRect = LayoutUGUIUtility.MakeUnityUVRect(uvMan.GetUVData(string.Format("deco_fnt_03", Array.Empty<object>())));
		}
	}
}
