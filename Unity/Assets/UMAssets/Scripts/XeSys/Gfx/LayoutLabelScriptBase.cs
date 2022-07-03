using UnityEngine;

namespace XeSys.Gfx
{
	public class LayoutLabelScriptBase : LayoutUGUIScriptBase
	{
		[SerializeField]
		private LayoutLabelDef m_labelDef; // 0x14

		// protected List<LabelDefData> LabelDefs { get; } 0x1EF8C78

		// // RVA: 0x1EF8C9C Offset: 0x1EF8C9C VA: 0x1EF8C9C
		// protected LayoutSymbolData CreateSymbol(string symbolName, Layout layout) { }

		// // RVA: 0x1EF8EDC Offset: 0x1EF8EDC VA: 0x1EF8EDC
		// public void StartAnim(LabelPreset preset, AbsoluteLayout layout) { }

		// // RVA: 0x1EF92D0 Offset: 0x1EF92D0 VA: 0x1EF92D0
		// public void GoToFrame(LabelPreset preset, AbsoluteLayout layout, int frame) { }

		// // RVA: 0x1EF9500 Offset: 0x1EF9500 VA: 0x1EF9500
		// public void GoToLabelFrame(LabelPreset preset, AbsoluteLayout layout, int frame) { }

		// [ConditionalAttribute] // RVA: 0x6926EC Offset: 0x6926EC VA: 0x6926EC
		// // RVA: 0x1EF982C Offset: 0x1EF982C VA: 0x1EF982C
		// private static void Debug_Assert(bool condition, string format, object[] args) { }
	}
}
