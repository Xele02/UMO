using XeSys.Gfx;

namespace XeApp.Game.Menu
{
	public class LayoutDecorationSelectObject : LayoutDecorationSelectItemBase
	{
		public static readonly string AssetName = "root_deco_item_01_layout_root"; // 0x0

		// RVA: 0x18B7B0C Offset: 0x18B7B0C VA: 0x18B7B0C Slot: 5
		public override bool InitializeFromLayout(Layout layout, TexUVListManager uvMan)
		{
			return base.InitializeFromLayout(layout, uvMan);
		}

		// RVA: 0x18B7B20 Offset: 0x18B7B20 VA: 0x18B7B20 Slot: 12
		public override void LayoutAllUpdate()
		{
			base.LayoutAllUpdate();
		}
	}
}
