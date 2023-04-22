using UnityEngine;

namespace XeApp.Game.RhythmGame.UI
{
	public class RunkIconAnimeEvent : UvChangeAnimeEventBase
	{

		// RVA: 0x1562D34 Offset: 0x1562D34 VA: 0x1562D34
		public void OnChangeRunkIcon(int value)
		{
			UpdateUv(new Vector2(value * 0.04395f, 0));
		}
	}
}
