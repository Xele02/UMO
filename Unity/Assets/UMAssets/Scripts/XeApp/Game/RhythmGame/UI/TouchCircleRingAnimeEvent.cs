using UnityEngine;

namespace XeApp.Game.RhythmGame.UI
{
	public class TouchCircleRingAnimeEvent : UvChangeAnimeEventBase
	{
		[SerializeField]
		private Vector2 m_offset = new Vector2(0.125f, 0); // 0x18

		// RVA: 0x1564458 Offset: 0x1564458 VA: 0x1564458
		public void OnChangeGaugeUv(int value)
		{
			UpdateUv(m_offset * value);
		}
	}
}
