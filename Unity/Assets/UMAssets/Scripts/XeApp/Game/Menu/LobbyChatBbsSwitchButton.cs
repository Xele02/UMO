using XeSys.Gfx;
using XeApp.Game.Common;
using UnityEngine;
using System;

namespace XeApp.Game.Menu
{
	public class LobbyChatBbsSwitchButton : LayoutUGUIScriptBase
	{
		public enum ButtonType
		{
			CHAT_BUTTON = 0,
			BATTOLE_BUTTON = 1,
			CAPTER_BUTTON = 2,
		}

		//[HeaderAttribute] // RVA: 0x670EE4 Offset: 0x670EE4 VA: 0x670EE4
		[SerializeField]
		private ToggleButton m_chatButton; // 0x14
		//[HeaderAttribute] // RVA: 0x670F2C Offset: 0x670F2C VA: 0x670F2C
		[SerializeField]
		private ToggleButton m_battleLogButton; // 0x18
		[SerializeField]
		//[HeaderAttribute] // RVA: 0x670F74 Offset: 0x670F74 VA: 0x670F74
		private ToggleButton m_captureButton; // 0x1C
		[SerializeField]
		//[HeaderAttribute] // RVA: 0x670FC4 Offset: 0x670FC4 VA: 0x670FC4
		private RawImageEx m_stateChangeTex; // 0x20
		//[HeaderAttribute] // RVA: 0x67101C Offset: 0x67101C VA: 0x67101C
		[SerializeField]
		private ActionButton m_stateChangeButton; // 0x24
		private AbsoluteLayout m_buttonMainAnim; // 0x28
		private TexUVList m_packTex02; // 0x2C
		private bool buttonState = true; // 0x40

		public Action OnChatClickButton { get; set; } // 0x30
		public Action OnBattleLogClickButton { get; set; } // 0x34
		public Action OnCaptureClickButton { get; set; } // 0x38
		public Action OnClickLogDisableButton { get; set; } // 0x3C

		// RVA: 0x154C714 Offset: 0x154C714 VA: 0x154C714 Slot: 5
		public override bool InitializeFromLayout(Layout layout, TexUVListManager uvMan)
		{
			m_packTex02 = uvMan.GetTexUVList("sel_lobby_02_pack");
			m_buttonMainAnim = layout.FindViewById("sw_lb_btn_chat_anim") as AbsoluteLayout;
			m_chatButton.ClearOnClickCallback();
			m_chatButton.AddOnClickCallback(() =>
			{
				//0x154CE28
				if(m_chatButton != null)
				{
					SetButton(ButtonType.CHAT_BUTTON);
					OnChatClickButton();
				}
			});
			m_battleLogButton.ClearOnClickCallback();
			m_battleLogButton.AddOnClickCallback(() =>
			{
				//0x154CEE8
				if(m_battleLogButton != null)
				{
					SetButton(ButtonType.BATTOLE_BUTTON);
					OnBattleLogClickButton();
				}
			});
			m_captureButton.ClearOnClickCallback();
			m_captureButton.AddOnClickCallback(() =>
			{
				//0x154CFA8
				if(m_captureButton != null)
				{
					SetButton(ButtonType.CAPTER_BUTTON);
					OnCaptureClickButton();
				}
			});
			m_stateChangeButton.ClearOnClickCallback();
			m_stateChangeButton.AddOnClickCallback(() =>
			{
				//0x154D068
				if(OnClickLogDisableButton != null)
					OnClickLogDisableButton();
			});
			return true;
		}

		// // RVA: 0x154CA04 Offset: 0x154CA04 VA: 0x154CA04
		private void SetOff()
		{
			m_chatButton.SetOff();
			m_captureButton.SetOff();
			m_battleLogButton.SetOff();
		}

		// // RVA: 0x154CA8C Offset: 0x154CA8C VA: 0x154CA8C
		public void SetButton(ButtonType type)
		{
			SetOff();
			if(type == ButtonType.CAPTER_BUTTON)
				m_captureButton.SetOn();
			else if(type == ButtonType.BATTOLE_BUTTON)
				m_battleLogButton.SetOn();
			else if(type == ButtonType.CHAT_BUTTON)
				m_chatButton.SetOn();
		}

		// // RVA: 0x154CAF4 Offset: 0x154CAF4 VA: 0x154CAF4
		public void SetLogDisableButtonTex(bool _buttonState)
		{
			m_stateChangeTex.uvRect = LayoutUGUIUtility.MakeUnityUVRect(m_packTex02.GetUVData(_buttonState ? "lb_btn_fnt_log_01" : "lb_btn_fnt_log_02"));
		}

		// // RVA: 0x154CC28 Offset: 0x154CC28 VA: 0x154CC28
		public void Enter()
		{
			m_buttonMainAnim.StartAllAnimGoStop("go_in", "st_in");
		}

		// // RVA: 0x154CCB4 Offset: 0x154CCB4 VA: 0x154CCB4
		// public void Hide() { }

		// // RVA: 0x154CD34 Offset: 0x154CD34 VA: 0x154CD34
		public void Leave()
		{
			m_buttonMainAnim.StartAllAnimGoStop("go_out", "st_out");
		}

		// // RVA: 0x154CDC0 Offset: 0x154CDC0 VA: 0x154CDC0
		// public bool IsPlayingAll() { }

		// // RVA: 0x154CDEC Offset: 0x154CDEC VA: 0x154CDEC
		public bool IsPlayingChild()
		{
			return m_buttonMainAnim.IsPlayingChildren();
		}
	}
}
