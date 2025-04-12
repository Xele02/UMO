using XeSys.Gfx;
using XeApp.Game.Common;
using UnityEngine;
using System;

namespace XeApp.Game.Menu
{
	public class MusicSelectLineButton : LayoutUGUIScriptBase
	{
		private enum Layer
		{
			Back = 0,
			Center = 1,
			Front = 2,
			Num = 3,
		}

		public enum Style
		{
			BasicLine = 0,
			SixLine = 1,
			Num = 2,
		}

		[SerializeField]
		private ActionButton[] m_buttons; // 0x14
		[SerializeField]
		private RawImageEx[] m_frameImages; // 0x18
		[SerializeField]
		private RawImageEx[] m_textImages; // 0x1C
		[SerializeField]
		private RawImageEx[] m_bgImages; // 0x20
		[SerializeField]
		private NumberBase m_unlockNumber; // 0x24
		private Style m_style; // 0x28
		private AbsoluteLayout m_rootAnim; // 0x2C
		private AbsoluteLayout m_changeAnim; // 0x30
		private AbsoluteLayout m_unlockAnim; // 0x34
		private bool m_isEntered; // 0x38
		private bool m_isUnlock; // 0x39

		public Action<int> onClickButton { private get; set; } // 0x3C

		// // RVA: 0x16780A0 Offset: 0x16780A0 VA: 0x16780A0
		public void TryEnter(bool line6Mode)
		{
			if(!m_isEntered)
				Enter(line6Mode);
		}

		// // RVA: 0x1678154 Offset: 0x1678154 VA: 0x1678154
		public void TryLeave()
		{
			if(m_isEntered)
				Leave();
		}

		// // RVA: 0x16780B0 Offset: 0x16780B0 VA: 0x16780B0
		public void Enter(bool line6Mode)
		{
			m_isEntered = true;
			m_rootAnim.StartChildrenAnimGoStop("go_in", "st_in");
			SetStyleAnim(line6Mode ? Style.SixLine : Style.BasicLine);
		}

		// // RVA: 0x1678164 Offset: 0x1678164 VA: 0x1678164
		public void Leave()
		{
			m_isEntered = false;
			m_rootAnim.StartChildrenAnimGoStop("go_out", "st_out");
		}

		// // RVA: 0x16782B8 Offset: 0x16782B8 VA: 0x16782B8
		// public void Show() { }

		// // RVA: 0x167833C Offset: 0x167833C VA: 0x167833C
		public void Hide()
		{
			m_isEntered = false;
			m_rootAnim.StartChildrenAnimGoStop("st_wait");
		}

		// // RVA: 0x16783C0 Offset: 0x16783C0 VA: 0x16783C0
		public bool IsPlaying()
		{
			return m_rootAnim.IsPlayingChildren() || m_changeAnim.IsPlayingChildren();
		}

		// // RVA: 0x167841C Offset: 0x167841C VA: 0x167841C
		public void SetUnlockNumber(int number)
		{
			m_unlockNumber.SetNumber(number, 0);
		}

		// // RVA: 0x167845C Offset: 0x167845C VA: 0x167845C
		public void SetUnlock(bool isUnlock)
		{
			m_unlockAnim.StartChildrenAnimGoStop(isUnlock ? "02" : "01");
			m_isUnlock = isUnlock;
			SetOptionStyle(m_style);
		}

		// // RVA: 0x1678504 Offset: 0x1678504 VA: 0x1678504
		private void SetOptionStyle(Style style)
		{
			m_style = style;
			if(!m_isUnlock)
			{
				for(int i = 0; i < m_buttons.Length; i++)
				{
					m_buttons[i].Disable = true;
					m_buttons[i].Dark = true;
				}
			}
			else
			{
				for(int i = 0; i < m_buttons.Length; i++)
				{
					m_buttons[i].Dark = false;
				}
				if(style == Style.SixLine)
				{
					m_buttons[0].Disable = true;
					m_buttons[1].Disable = false;
					m_buttons[2].Disable = true;
				}
				else if(style == Style.BasicLine)
				{
					m_buttons[0].Disable = true;
					m_buttons[1].Disable = true;
					m_buttons[2].Disable = false;
				}
			}
		}

		// // RVA: 0x16781F8 Offset: 0x16781F8 VA: 0x16781F8
		private void SetStyleAnim(Style style)
		{
			SetOptionStyle(style);
			if(style == Style.SixLine)
			{
				m_changeAnim.StartChildrenAnimGoStop("st_act_01");
			}
			else if(style == Style.BasicLine)
			{
				m_changeAnim.StartChildrenAnimGoStop("st_act_02");
			}
		}

		// // RVA: 0x167888C Offset: 0x167888C VA: 0x167888C
		private void OnClickButton()
		{
			SoundManager.Instance.sePlayerMenu.Play((int)mcrs.cs_se_menu.SE_BTN_006);
			if(m_style == Style.SixLine)
			{
				m_changeAnim.StartChildrenAnimGoStop("go_act_02", "st_act_02");
				SetOptionStyle(Style.BasicLine);
			}
			else if(m_style == Style.BasicLine)
			{
				m_changeAnim.StartChildrenAnimGoStop("go_act_01", "st_act_01");
				SetOptionStyle(Style.SixLine);
			}
			if(onClickButton != null)
				onClickButton((int)m_style);
		}

		// // RVA: 0x16789F4 Offset: 0x16789F4 VA: 0x16789F4 Slot: 5
		public override bool InitializeFromLayout(Layout layout, TexUVListManager uvMan)
		{
			base.InitializeFromLayout(layout, uvMan);
			m_rootAnim = layout.FindViewByExId("root_sel_music_btn_line_sw_btn_line_inout_anim") as AbsoluteLayout;
			m_changeAnim = layout.FindViewByExId("sw_btn_line_inout_anim_sw_btn_line_transition_anim") as AbsoluteLayout;
			m_unlockAnim = layout.FindViewByExId("sw_btn_line_transition_anim_swtbl_m_late_off") as AbsoluteLayout;
			for(int i = 0; i < m_buttons.Length; i++)
			{
				m_buttons[i].AddOnClickCallback(OnClickButton);
			}
			for(int i = 0; i < 3; i++)
			{
				m_frameImages[i].uvRect = LayoutUGUIUtility.MakeUnityUVRect(uvMan.GetUVData(string.Format("s_m_btn_line_{0:D2}", i != 1 ? 1 : 2)));
				m_textImages[i].uvRect = LayoutUGUIUtility.MakeUnityUVRect(uvMan.GetUVData(string.Format("s_m_btn_line_fnt_{0:D2}", i != 1 ? 1 : 2)));
				m_bgImages[i].uvRect = LayoutUGUIUtility.MakeUnityUVRect(uvMan.GetUVData(string.Format("s_m_btn_line_{0:D2}_bg", i != 1 ? 1 : 2)));
			}
			SetOptionStyle(Style.BasicLine);
			Loaded();
			return true;
		}
	}
}
