using UnityEngine;

namespace XeApp.Game.RhythmGame.UI
{
	public class FoldWaveGaugeCircleUvChanger : UvChangeAnimeEventBase
	{
		public enum UvType
		{
			Blue = 0,
			Rainbow = 1,
			Purple = 2,
		}

		private readonly Vector2[] circleUvTbl = new Vector2[3] {
			new Vector2(0, 0), new Vector2(0.0337f, 0), new Vector2(0.0674f, 0)
		}; // 0x18

		// RVA: 0x15600D8 Offset: 0x15600D8 VA: 0x15600D8
		public void UpdateUv(UvType type)
		{
			UpdateUv(circleUvTbl[(int)type]);
		}
	}
}
