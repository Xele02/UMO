using XeSys;

namespace XeApp.Game.RhythmGame
{
	public class CheatFunction : SingletonBehaviour<CheatFunction>
	{
		// RVA: 0xF6B558 Offset: 0xF6B558 VA: 0xF6B558
		public void Disable()
		{
			gameObject.SetActive(false);
		}
	}
}
