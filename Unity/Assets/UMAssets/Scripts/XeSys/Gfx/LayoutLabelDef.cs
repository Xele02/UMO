using UnityEngine;
using System.Collections.Generic;

namespace XeSys.Gfx
{
	public class LayoutLabelDef : ScriptableObject
	{
		private static readonly string ASSET_NAME_FORMAT = "{0}_LabelDef.asset"; // 0x0
		[SerializeField]
		private List<LabelDefData> m_dataList; // 0xC

		public List<LabelDefData> DataList { get { return m_dataList; } } //0x1EF8980

		// // RVA: 0x1EF8914 Offset: 0x1EF8914 VA: 0x1EF8914
		// public static bool TryMakeAssetPath(string lytName, LayoutUGUIRuntime runtime, out string assetPath) { }

		// // RVA: 0x1EF8988 Offset: 0x1EF8988 VA: 0x1EF8988
		public LabelDefData SearchData(string symbolName)
		{
			for(int i = 0; i < m_dataList.Count; i++)
			{
				if(m_dataList[i].symbolName == symbolName)
					return m_dataList[i];
			}
			return null;
		}
	}
}
