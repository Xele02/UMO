using UnityEngine;

namespace XeApp.Game.Menu
{
	public class RankingSceneBase : TransitionRoot
	{
		public class WaitForFrame : CustomYieldInstruction
		{
			private int waitFrame; // 0x8
			private int startFrame; // 0xC

			public override bool keepWaiting { get { return Time.frameCount <= waitFrame + startFrame; } } // 0xCF7CD8

			// RVA: 0xCF4614 Offset: 0xCF4614 VA: 0xCF4614
			public WaitForFrame(int waitFrame)
			{
				this.waitFrame = waitFrame;
				this.startFrame = Time.frameCount;
			}

			//// RVA: 0xCF7C1C Offset: 0xCF7C1C VA: 0xCF7C1C
			//public void Reset(int waitFrame) { }
		}

		private void Awake()
		{
			TodoLogger.Log(0, "Implement monobehaviour");
		}
	}
}
