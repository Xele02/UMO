using UnityEngine;

namespace XeApp.Game.RhythmGame.UI
{
	public class BattleCenterRingUvChanger : UvChangeAnimeEventBase
	{
		public enum UvType
		{
			Normal = 0,
			Max = 1,
		}

		private readonly Vector2[] ringUvTbl = new Vector2[2] {
			new Vector2(0, 0),
			new Vector2(0, -0.078f)
		}; // 0x18

		// RVA: 0x15580F4 Offset: 0x15580F4 VA: 0x15580F4
		public void UpdateUv(UvType type)
		{
			UpdateUv(ringUvTbl[(int)type]);
		}
	}
}
