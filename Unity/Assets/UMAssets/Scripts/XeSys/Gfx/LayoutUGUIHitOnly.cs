using UnityEngine.UI;

namespace XeSys.Gfx
{
	public class LayoutUGUIHitOnly : Graphic
	{
		// RVA: 0x1EFF99C Offset: 0x1EFF99C VA: 0x1EFF99C Slot: 44
		protected override void OnPopulateMesh(VertexHelper vh)
		{
			base.OnPopulateMesh(vh);
			vh.Clear();
		}
	}
}
