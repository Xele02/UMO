using UnityEngine;

namespace XeSys.Gfx
{
	public class LayoutLabelScriptBase : LayoutUGUIScriptBase
	{
		[SerializeField]
		private LayoutLabelDef m_labelDef; // 0x14

		// protected List<LabelDefData> LabelDefs { get; } 0x1EF8C78

		// // RVA: 0x1EF8C9C Offset: 0x1EF8C9C VA: 0x1EF8C9C
		protected LayoutSymbolData CreateSymbol(string symbolName, Layout layout)
		{
			LabelDefData defData = m_labelDef.SearchData(symbolName);
			if(defData == null)
				return null;
			AbsoluteLayout rootLayout = layout.Root;
			if(defData.parentExid.Length != 0)
				rootLayout = layout.FindViewByExId(defData.parentExid) as AbsoluteLayout;

			return new LayoutSymbolData(defData, rootLayout.FindViewByExId(defData.exid) as AbsoluteLayout, this);
		}

		// // RVA: 0x1EF8EDC Offset: 0x1EF8EDC VA: 0x1EF8EDC
		public void StartAnim(LabelPreset preset, AbsoluteLayout layout)
		{
			switch(preset.type)
			{
				case LabelPreset.Type.Single:
					layout.StartSiblingAnimGoStop(preset.first);
				break;
				case LabelPreset.Type.GoStop:
					layout.StartSiblingAnimGoStop(preset.first, preset.second);
				break;
				case LabelPreset.Type.Loop:
					layout.StartSiblingAnimLoop(preset.first, preset.second);
				break;
				case LabelPreset.Type.SingleChildren:
					layout.StartChildrenAnimGoStop(preset.first);
				break;
				case LabelPreset.Type.GoStopChildren:
					layout.StartChildrenAnimGoStop(preset.first, preset.second);
				break;
				case LabelPreset.Type.LoopChildren:
					layout.StartChildrenAnimLoop(preset.first, preset.second);
				break;
				default:
					UnityEngine.Debug.LogError("undefined PresetType : "+preset.type.ToString());
				break;	
			}
		}

		// // RVA: 0x1EF92D0 Offset: 0x1EF92D0 VA: 0x1EF92D0
		// public void GoToFrame(LabelPreset preset, AbsoluteLayout layout, int frame) { }

		// // RVA: 0x1EF9500 Offset: 0x1EF9500 VA: 0x1EF9500
		// public void GoToLabelFrame(LabelPreset preset, AbsoluteLayout layout, int frame) { }

		// [ConditionalAttribute] // RVA: 0x6926EC Offset: 0x6926EC VA: 0x6926EC
		// // RVA: 0x1EF982C Offset: 0x1EF982C VA: 0x1EF982C
		// private static void Debug_Assert(bool condition, string format, object[] args) { }
	}
}
