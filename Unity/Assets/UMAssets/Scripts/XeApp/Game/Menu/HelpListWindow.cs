using UnityEngine;
using XeApp.Game.Common;
using XeSys.Gfx;

namespace XeApp.Game.Menu
{
	public class HelpListWindow : LayoutLabelScriptBase
	{
		private LayoutSymbolData m_symbolMain; // 0x18

		// RVA: 0x953638 Offset: 0x953638 VA: 0x953638
		public void ApplyForCategoryList(SwapScrollList scrollList)
		{
			scrollList.Apply(5, 2, new Vector2(470, 120), new Vector2(11, 33));
		}

		//// RVA: 0x953B7C Offset: 0x953B7C VA: 0x953B7C
		//public void ApplyForInvokeList(SwapScrollList scrollList) { }

		// RVA: 0x953C14 Offset: 0x953C14 VA: 0x953C14
		public void Enter()
		{
			m_symbolMain.StartAnim("enter");
		}

		// RVA: 0x953C90 Offset: 0x953C90 VA: 0x953C90
		public void Leave()
		{
			m_symbolMain.StartAnim("leave");
		}

		//// RVA: 0x953D0C Offset: 0x953D0C VA: 0x953D0C
		//public void Show() { }

		// RVA: 0x953D88 Offset: 0x953D88 VA: 0x953D88
		public void Hide()
		{
			m_symbolMain.StartAnim("wait");
		}

		// RVA: 0x953E04 Offset: 0x953E04 VA: 0x953E04
		public bool IsPlaying()
		{
			return m_symbolMain.IsPlaying();
		}

		// RVA: 0x953E30 Offset: 0x953E30 VA: 0x953E30 Slot: 5
		public override bool InitializeFromLayout(Layout layout, TexUVListManager uvMan)
		{
			base.InitializeFromLayout(layout, uvMan);
			m_symbolMain = CreateSymbol("main", layout);
			Loaded();
			return true;
		}
	}
}
