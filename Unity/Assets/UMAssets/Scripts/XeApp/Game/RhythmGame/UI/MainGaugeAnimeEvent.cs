using UnityEngine;

namespace XeApp.Game.RhythmGame.UI
{
	public class MainGaugeAnimeEvent : UvChangeAnimeEventBase
	{
		// RVA: 0x1562464 Offset: 0x1562464 VA: 0x1562464
		public void OnChangeGaugeUv(int value)
		{
			UpdateUv(new Vector2(value * 0.11035f, 0));
		}
	}
}
