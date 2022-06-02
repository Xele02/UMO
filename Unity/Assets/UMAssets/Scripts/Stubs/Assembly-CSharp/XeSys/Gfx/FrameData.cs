using System;

namespace XeSys.Gfx
{
	[Serializable]
	public struct FrameData
	{
		public enum FrameAction
		{
			none = 0,
			stop = 1,
			loop = 2,
			jump = 3,
		}

		public int FrameIdx;
		public float Time;
		public string TexName;
		public string Label;
		public AnimViewTransformData TransFormData;
		public FrameAction Action;
		public float JumpFrame;
	}
}
