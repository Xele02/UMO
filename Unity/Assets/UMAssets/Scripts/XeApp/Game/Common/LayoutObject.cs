
using XeSys.Gfx;

namespace XeApp.Game.Common
{
	public class LayoutObject
	{
		// Properties
		public LayoutUGUIRuntime Runtime { get; private set; } // 0x8
		public AbsoluteLayout ParentLayout { get; set; } // 0xC

		// RVA: 0x11059DC Offset: 0x11059DC VA: 0x11059DC
		public LayoutObject(LayoutUGUIRuntime runtime)
		{
			Runtime = runtime;
		}

		// RVA: 0x11059FC Offset: 0x11059FC VA: 0x11059FC
		//public void SetParent(Transform positionParent, Transform hierarchyParent, AbsoluteLayout parentLayout) { }
	}
}
