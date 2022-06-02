using System;

namespace XeSys.Gfx
{
	[Serializable]
	public struct LabelData
	{
		public string Id;
		public int FrameIdx;
		public float Time;
		public bool IsKey;
	}
}
