using UnityEngine;

namespace XeApp.Game.RhythmGame.UI
{
	public class TouchCircleRingAnimeEvent : UvChangeAnimeEventBase
	{
		private void Awake()
		{
			UnityEngine.Debug.LogError("Implement monobehaviour");
		}
		[SerializeField]
		private Vector2 m_offset;
	}
}
