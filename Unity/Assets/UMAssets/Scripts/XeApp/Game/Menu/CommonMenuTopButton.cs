using XeApp.Game.Common;
using XeSys.Gfx;

namespace XeApp.Game.Menu
{
	public class CommonMenuTopButton : ActionButton
	{
		// RVA: 0x1B4F2F4 Offset: 0x1B4F2F4 VA: 0x1B4F2F4
		private new void Start()
		{
			base.Start();
		}

		// RVA: 0x1B4F2FC Offset: 0x1B4F2FC VA: 0x1B4F2FC
		private void Update()
		{
			return;
		}

		// RVA: 0x1B4F300 Offset: 0x1B4F300 VA: 0x1B4F300 Slot: 5
		public override bool InitializeFromLayout(Layout layout, TexUVListManager uvMan)
		{
			return base.InitializeFromLayout(layout, uvMan);
		}
	}
}
