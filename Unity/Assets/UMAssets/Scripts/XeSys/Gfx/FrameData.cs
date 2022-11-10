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

		public int FrameIdx; // 0x0
		public float Time; // 0x4
		public string TexName; // 0x8
		public string Label; // 0xC
		public AnimViewTransformData TransFormData; // 0x10
		public FrameData.FrameAction Action; // 0x64
		public float JumpFrame; // 0x68
	}
}
