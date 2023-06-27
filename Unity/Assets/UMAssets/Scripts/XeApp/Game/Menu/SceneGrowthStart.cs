using XeSys.Gfx;

namespace XeApp.Game.Menu
{
	public class SceneGrowthStart : SceneGrowthPanelBase
	{
		// RVA: 0x10F9620 Offset: 0x10F9620 VA: 0x10F9620 Slot: 5
		public override bool InitializeFromLayout(Layout layout, TexUVListManager uvMan)
		{
			SetEnableRaycaster(false);
			return base.InitializeFromLayout(layout, uvMan);
		}
	}
}
