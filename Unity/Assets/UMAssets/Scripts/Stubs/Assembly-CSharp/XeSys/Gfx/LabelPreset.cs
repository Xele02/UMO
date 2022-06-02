using System;
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

		public LabelPreset(string name, LabelPreset.Type type, string first, string second)
		{
		}

		[SerializeField]
		private string m_name;
		[SerializeField]
		private Type m_type;
		[SerializeField]
		private string m_first;
		[SerializeField]
		private string m_second;
	}
}
