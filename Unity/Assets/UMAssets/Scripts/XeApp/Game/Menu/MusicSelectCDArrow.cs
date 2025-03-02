using XeSys.Gfx;
using UnityEngine;

namespace XeApp.Game.Menu
{
	public class MusicSelectCDArrow : LayoutLabelScriptBase
	{
		[SerializeField]
		private RawImageEx m_leftArrowImage; // 0x18
		[SerializeField]
		private RawImageEx m_rightArrowImage; // 0x1C
		private LayoutSymbolData m_symbolMain; // 0x20
		private LayoutSymbolData m_symbolStyle; // 0x24
		private bool m_isShow; // 0x28

		// // RVA: 0x166BE40 Offset: 0x166BE40 VA: 0x166BE40
		// public void SetStyle(MusicSelectCDArrow.Style style) { }

		// // RVA: 0x166BEF4 Offset: 0x166BEF4 VA: 0x166BEF4
		public void TryEnter()
		{
			if(!m_isShow)
				Enter();
		}

		// // RVA: 0x166BF88 Offset: 0x166BF88 VA: 0x166BF88
		public void TryLeave()
		{
			if(m_isShow)
				Leave();
		}

		// // RVA: 0x166BF04 Offset: 0x166BF04 VA: 0x166BF04
		public void Enter()
		{
			m_isShow = true;
			m_symbolMain.StartAnim("enter");
		}

		// // RVA: 0x166BF98 Offset: 0x166BF98 VA: 0x166BF98
		public void Leave()
		{
			m_isShow = false;
			m_symbolMain.StartAnim("leave");
		}

		// // RVA: 0x166C01C Offset: 0x166C01C VA: 0x166C01C
		// public void Show() { }

		// // RVA: 0x166C0A0 Offset: 0x166C0A0 VA: 0x166C0A0
		public void Hide()
		{
			m_isShow = false;
			m_symbolMain.StartAnim("wait");
		}

		// // RVA: 0x166C124 Offset: 0x166C124 VA: 0x166C124
		public bool IsPlaying()
		{
			return m_symbolMain.IsPlaying();
		}

		// // RVA: 0x166C150 Offset: 0x166C150 VA: 0x166C150
		// public void SetLeftArrowVisible(bool isVisible) { }

		// // RVA: 0x166C184 Offset: 0x166C184 VA: 0x166C184
		// public void SetRightArrowVisible(bool isVisible) { }

		// RVA: 0x166C1B8 Offset: 0x166C1B8 VA: 0x166C1B8 Slot: 5
		public override bool InitializeFromLayout(Layout layout, TexUVListManager uvMan)
		{
			base.InitializeFromLayout(layout, uvMan);
			m_symbolMain = CreateSymbol("main", layout);
			m_symbolStyle = CreateSymbol("style", layout);
			Loaded();
			return true;
		}
	}
}
