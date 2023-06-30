using XeSys.Gfx;

namespace XeApp.Game.Menu
{
	public class PopupRankRangeRuntime : LayoutUGUIScriptBase
	{
		// RVA: 0x1619D70 Offset: 0x1619D70 VA: 0x1619D70 Slot: 5
		public override bool InitializeFromLayout(Layout layout, TexUVListManager uvMan)
		{
			base.InitializeFromLayout(layout, uvMan);
			Loaded();
			return true;
		}
	}
}
