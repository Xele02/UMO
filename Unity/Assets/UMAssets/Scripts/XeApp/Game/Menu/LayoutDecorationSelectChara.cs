using XeSys.Gfx;

namespace XeApp.Game.Menu
{
	public class LayoutDecorationSelectChara : LayoutDecorationSelectItemBase
	{
		public static readonly string AssetName = "root_deco_item_00_layout_root"; // 0x0

		// RVA: 0x18B3298 Offset: 0x18B3298 VA: 0x18B3298 Slot: 5
		public override bool InitializeFromLayout(Layout layout, TexUVListManager uvMan)
		{
			return base.InitializeFromLayout(layout, uvMan);
		}

		// RVA: 0x18B371C Offset: 0x18B371C VA: 0x18B371C Slot: 12
		public override void LayoutAllUpdate()
		{
			base.LayoutAllUpdate();
		}
	}
}
