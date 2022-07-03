using System;
using System.Collections.Generic;
using UnityEngine;

namespace XeSys.Gfx
{
	[Serializable]
	public class LabelDefData
	{
		[SerializeField]
		private string m_symbolName; // 0x8
		[SerializeField]
		private string m_exid; // 0xC
		[SerializeField]
		private string m_parentExid; // 0x10
		[SerializeField]
		private List<string> m_labels; // 0x14
		[SerializeField]
		private List<LabelPreset> m_presets; // 0x18

		public string symbolName { get { return m_symbolName; } private set { m_symbolName = value; } } //0x20496C0 0x20496C8
		public string exid { get { return m_exid; } private set { m_exid = value; } } //0x20496D0 0x20496D8
		public string parentExid { get { return m_parentExid; } private set { m_parentExid = value; } } //0x20496E0 0x20496E8
		// public List<string> labels { get; private set; } 0x20496F0 0x20496F8
		public List<LabelPreset> presets { get { return m_presets; } private set { m_presets = value; } }

		// // RVA: 0x2049710 Offset: 0x2049710 VA: 0x2049710
		// public void .ctor(string name, string exid, string parentExid, List<string> labels, List<LabelPreset> presets) { }
	}
}
