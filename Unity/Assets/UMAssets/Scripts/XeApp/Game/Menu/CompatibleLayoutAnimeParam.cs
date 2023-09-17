
using UnityEngine;

namespace XeApp.Game.Menu
{
	public struct CompatibleLayoutAnimeParam // TypeDefIndex: 16500
	{
		public float nowMs; // 0x0
		public float endMs; // 0x4
		public float startFrame; // 0x8
		public const float FrameRate = 60;
		public const float FrameSec = 1.0f/60;

		// RVA: 0x7FEE24 Offset: 0x7FEE24 VA: 0x7FEE24
		public void Initialize(float startFrame, float endFrame)
		{
			this.startFrame = startFrame;
			nowMs = 0;
			endMs = (endFrame - startFrame) * FrameSec;
		}

		// RVA: 0x7FEE50 Offset: 0x7FEE50 VA: 0x7FEE50
		public int UpdateFrame(float dt)
		{
			nowMs += dt;
			if (nowMs > endMs)
				nowMs = 0;
			return (int)(startFrame + nowMs * 60);
		}
	}
}
