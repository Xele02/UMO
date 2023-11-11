using XeSys.Gfx;

namespace XeApp.Game.Menu
{
	public class GachaRateSeparator : GachaRateElemBase
	{
		// RVA: 0xEE6598 Offset: 0xEE6598 VA: 0xEE6598 Slot: 5
		public override bool InitializeFromLayout(Layout layout, TexUVListManager uvMan)
		{
			base.InitializeFromLayout(layout, uvMan);
			Loaded();
			return true;
		}
	}
}
