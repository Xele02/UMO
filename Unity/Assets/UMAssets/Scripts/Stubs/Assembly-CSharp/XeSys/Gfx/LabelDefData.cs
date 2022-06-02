using System;
using System.Collections.Generic;
using UnityEngine;

namespace XeSys.Gfx
{
	[Serializable]
	public class LabelDefData
	{
		public LabelDefData(string name, string exid, string parentExid, List<string> labels, List<LabelPreset> presets)
		{
		}

		[SerializeField]
		private string m_symbolName;
		[SerializeField]
		private string m_exid;
		[SerializeField]
		private string m_parentExid;
		[SerializeField]
		private List<string> m_labels;
		[SerializeField]
		private List<LabelPreset> m_presets;
	}
}
