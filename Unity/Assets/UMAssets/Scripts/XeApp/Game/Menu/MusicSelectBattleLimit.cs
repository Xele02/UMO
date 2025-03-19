using XeSys.Gfx;
using UnityEngine.UI;
using UnityEngine;

namespace XeApp.Game.Menu
{
	public class MusicSelectBattleLimit : LayoutLabelScriptBase
	{
		[SerializeField]
		private Text m_limitText; // 0x18
		private LayoutSymbolData m_symbolMain; // 0x1C
		private bool m_isShow; // 0x20

		// // RVA: 0x1668E24 Offset: 0x1668E24 VA: 0x1668E24
		public void SetLimitText(string text)
		{
			m_limitText.text = text;
		}

		// // RVA: 0x1668E60 Offset: 0x1668E60 VA: 0x1668E60
		// public void TryEnter() { }

		// // RVA: 0x1668EF4 Offset: 0x1668EF4 VA: 0x1668EF4
		public void TryLeave()
		{
			if(m_isShow)
				Leave();
		}

		// // RVA: 0x1668E70 Offset: 0x1668E70 VA: 0x1668E70
		public void Enter()
		{
			m_isShow = true;
			m_symbolMain.StartAnim("enter");
		}

		// // RVA: 0x1668F04 Offset: 0x1668F04 VA: 0x1668F04
		public void Leave()
		{
			m_isShow = false;
			m_symbolMain.StartAnim("leave");
		}

		// // RVA: 0x1668F88 Offset: 0x1668F88 VA: 0x1668F88
		// public void Show() { }

		// // RVA: 0x166900C Offset: 0x166900C VA: 0x166900C
		public void Hide()
		{
			m_isShow = false;
			m_symbolMain.StartAnim("wait");
		}

		// RVA: 0x1669090 Offset: 0x1669090 VA: 0x1669090
		public bool IsPlaying()
		{
			return m_symbolMain.IsPlaying();
		}

		// RVA: 0x16690BC Offset: 0x16690BC VA: 0x16690BC Slot: 5
		public override bool InitializeFromLayout(Layout layout, TexUVListManager uvMan)
		{
			base.InitializeFromLayout(layout, uvMan);
			m_symbolMain = CreateSymbol("main", layout);
			Loaded();
			return true;
		}
	}
}
