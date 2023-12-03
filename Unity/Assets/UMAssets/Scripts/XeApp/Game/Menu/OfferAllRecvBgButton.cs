using XeSys.Gfx;

namespace XeApp.Game.Menu
{
	public class OfferAllRecvBgButton : LayoutUGUIScriptBase
	{

		// RVA: 0x151B174 Offset: 0x151B174 VA: 0x151B174 Slot: 5
		public override bool InitializeFromLayout(Layout layout, TexUVListManager uvMan)
		{
			(layout.Root[0] as AbsoluteLayout).StartAllAnimGoStop("st_non");
			Loaded();
			return base.InitializeFromLayout(layout, uvMan);
		}
	}
}
