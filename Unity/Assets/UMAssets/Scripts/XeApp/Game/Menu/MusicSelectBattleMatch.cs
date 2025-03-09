using XeSys.Gfx;

namespace XeApp.Game.Menu
{
	public class MusicSelectBattleMatch : LayoutLabelScriptBase
	{
		private LayoutSymbolData m_symbolMain; // 0x18

		// // RVA: 0x1669160 Offset: 0x1669160 VA: 0x1669160
		public void Hide()
		{
			m_symbolMain.StartAnim("wait");
		}

		// RVA: 0x16691DC Offset: 0x16691DC VA: 0x16691DC
		public void Enter()
		{
			m_symbolMain.StartAnim("enter");
		}

		// RVA: 0x1669258 Offset: 0x1669258 VA: 0x1669258
		public void Active()
		{
			m_symbolMain.StartAnim("active");
		}

		// RVA: 0x16692D4 Offset: 0x16692D4 VA: 0x16692D4
		public void Leave()
		{
			m_symbolMain.StartAnim("leave");
		}

		// RVA: 0x1669350 Offset: 0x1669350 VA: 0x1669350
		public bool IsPlaying()
		{
			return m_symbolMain.IsPlaying();
		}

		// RVA: 0x166937C Offset: 0x166937C VA: 0x166937C Slot: 5
		public override bool InitializeFromLayout(Layout layout, TexUVListManager uvMan)
		{
			base.InitializeFromLayout(layout, uvMan);
			m_symbolMain = CreateSymbol("main", layout);
			Loaded();
			return true;
		}
	}
}
