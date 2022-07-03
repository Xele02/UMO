using System;
using System.Collections.Generic;
using UnityEngine;

namespace XeSys.Gfx
{
	[Serializable]
	public class LabelPreset
	{
		public enum Type
		{
			Single = 0,
			GoStop = 1,
			Loop = 2,
			Table = 3,
			Frame = 4,
			FrameAll = 5,
			SingleChildren = 6,
			GoStopChildren = 7,
			LoopChildren = 8,
			TableChildren = 9,
			FrameChildren = 10,
			Other = 11,
		}

		[SerializeField]
		private string m_name; // 0x8
		[SerializeField]
		private LabelPreset.Type m_type; // 0xC
		[SerializeField]
		private string m_first; // 0x10
		[SerializeField]
		private string m_second; // 0x14
		private static readonly Dictionary<string, LabelPreset.Type> typeDict = new Dictionary<string, Type>() {
			{"s", Type.Single},
			{"g", Type.GoStop},
			{"l", Type.Loop},
			{"t", Type.Table},
			{"f", Type.Frame},
			{"sc", Type.SingleChildren},
			{"gc", Type.GoStopChildren},
			{"lc", Type.LoopChildren},
			{"tc", Type.TableChildren},
			{"fc", Type.FrameChildren}
		}; // 0x0

		public string name { get { return m_name; } private set { m_name = value; } } //0x2049750 0x2049758
		public LabelPreset.Type type { get { return m_type; } private set { m_type = value; } } //0x2049760 0x2049768
		public string first { get { return m_first;} private set { m_first = value; } } //0x2049770 0x2049778
		public string second { get { return m_second; } set { m_second = value; } } //0x2049780 0x2049788

		// // RVA: 0x2049790 Offset: 0x2049790 VA: 0x2049790
		// public void .ctor(string name, LabelPreset.Type type, string first, string second) { }

		// // RVA: 0x20497C8 Offset: 0x20497C8 VA: 0x20497C8
		// public static LabelPreset TryCreate(string str) { }

		// // RVA: 0x2049A90 Offset: 0x2049A90 VA: 0x2049A90
		// public static LabelPreset.Type LookupType(string str) { }
	}
}
