using System.Collections.Generic;
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

			AbsoluteLayout abs = rootLayout.FindViewByExId(defData.exid) as AbsoluteLayout;
			//UMO
			if(abs == null)
			{
				string str = "";
				List<ViewBase> l = new List<ViewBase>();
				l.Add(rootLayout);
				while(l.Count > 0)
				{
					ViewBase absL = l[0];
					l.RemoveAt(0);
					str += absL.EXID + " " + absL.ID + " " + absL.GetType() + " - ";
					if (absL is AbsoluteLayout)
					{
						AbsoluteLayout absL2 = absL as AbsoluteLayout;
						for (int i = 0; i < absL2.viewCount; i++)
						{
							l.Add(absL2[i]);
						}
					}
				}
				TodoLogger.LogError(TodoLogger.Layout, "Can't find abs layout with id " + defData.exid+", vals are "+str);
			}
			//UMO end
			return new LayoutSymbolData(defData, abs, this);
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
					TodoLogger.LogError(TodoLogger.Layout, "undefined PresetType : "+preset.type.ToString());
				break;	
			}
		}

		// // RVA: 0x1EF92D0 Offset: 0x1EF92D0 VA: 0x1EF92D0
		public void GoToFrame(LabelPreset preset, AbsoluteLayout layout, int frame)
		{
			switch (preset.type)
			{
				case LabelPreset.Type.Table:
				case LabelPreset.Type.Frame:
					layout.StartSiblingAnimGoStop(frame, frame);
					break;
				case LabelPreset.Type.FrameAll:
					layout.StartAllAnimGoStop(frame, frame);
					layout.StartSiblingAnimGoStop(frame, frame);
					break;
				case LabelPreset.Type.TableChildren:
				case LabelPreset.Type.FrameChildren:
					layout.StartChildrenAnimGoStop(frame, frame);
					break;
				default:
					TodoLogger.LogError(TodoLogger.Layout, "undefined PresetType : " + preset.type);
					break;
			}
		}

		// // RVA: 0x1EF9500 Offset: 0x1EF9500 VA: 0x1EF9500
		public void GoToLabelFrame(LabelPreset preset, AbsoluteLayout layout, int frame)
		{
			if(preset.type < LabelPreset.Type.Table)
			{
				int a = Mathf.RoundToInt(layout.FrameAnimation.SearchLabelFrame(preset.first));
				layout.StartSiblingAnimGoStop(a + frame, a + frame);
			}
			else if(preset.type >= LabelPreset.Type.SingleChildren && preset.type < LabelPreset.Type.TableChildren)
			{
				int a = Mathf.RoundToInt(layout[0].FrameAnimation.SearchLabelFrame(preset.first));
				layout.StartChildrenAnimGoStop(a + frame, a + frame);
			}
			else
			{
				TodoLogger.LogError(TodoLogger.Layout, "undefined PresetType : " + preset.type);
			}
		}

		// [ConditionalAttribute] // RVA: 0x6926EC Offset: 0x6926EC VA: 0x6926EC
		// // RVA: 0x1EF982C Offset: 0x1EF982C VA: 0x1EF982C
		// private static void Debug_Assert(bool condition, string format, object[] args) { }
	}
}
