using XeSys.Gfx;
using UnityEngine.UI;
using UnityEngine;

namespace XeApp.Game.Menu
{
	public class LayoutEventGoDivaFeverLimit : LayoutUGUIScriptBase
	{
		[SerializeField]
		private Text m_textRemainTime; // 0x14
		private bool m_isShown; // 0x18
		private AbsoluteLayout m_layoutMain; // 0x1C
		private AbsoluteLayout m_layoutOnOff; // 0x20

		// // RVA: 0x1990978 Offset: 0x1990978 VA: 0x1990978
		public void Enter()
		{
			m_isShown = true;
			m_layoutMain.StartChildrenAnimGoStop("go_in", "st_in");
		}

		// // RVA: 0x1990A0C Offset: 0x1990A0C VA: 0x1990A0C
		public void Leave()
		{
			m_isShown = false;
			m_layoutMain.StartChildrenAnimGoStop("go_out", "st_out");
		}

		// // RVA: 0x1990AA0 Offset: 0x1990AA0 VA: 0x1990AA0
		public void TryEnter()
		{
			if(m_isShown)
				return;
			Enter();
		}

		// // RVA: 0x1990AB0 Offset: 0x1990AB0 VA: 0x1990AB0
		public void TryLeave()
		{
			if(!m_isShown)
				return;
			Leave();
		}

		// // RVA: 0x1990AC0 Offset: 0x1990AC0 VA: 0x1990AC0
		// public void Show() { }

		// // RVA: 0x1990B44 Offset: 0x1990B44 VA: 0x1990B44
		public void Hide()
		{
			m_isShown = false;
			m_layoutMain.StartChildrenAnimGoStop("st_wait");
		}

		// // RVA: 0x1990BC8 Offset: 0x1990BC8 VA: 0x1990BC8
		public bool IsPlaying()
		{
			return m_layoutMain.IsPlayingChildren();
		}

		// // RVA: 0x1990BF4 Offset: 0x1990BF4 VA: 0x1990BF4
		public void SetOnOff(bool bOn)
		{
			m_layoutOnOff.StartChildrenAnimGoStop(bOn ? "01" : "02");
		}

		// // RVA: 0x1990C88 Offset: 0x1990C88 VA: 0x1990C88
		public void SetLimitText(string text)
		{
			m_textRemainTime.text = text;
		}

		// // RVA: 0x1990CC4 Offset: 0x1990CC4 VA: 0x1990CC4 Slot: 5
		public override bool InitializeFromLayout(Layout layout, TexUVListManager uvMan)
		{
			base.InitializeFromLayout(layout, uvMan);
			m_layoutMain = layout.FindViewById("sw_fever_limit_inout_anim") as AbsoluteLayout;
			m_layoutOnOff = layout.FindViewById("sw_fever_limit_onoff_anim") as AbsoluteLayout;
			Loaded();
			return true;
		}
	}
}
