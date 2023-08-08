
namespace XeApp.Game.Menu
{
	public class EpisodeSelectSceneArgs : TransitionArgs
	{
		public bool IsFromBeginner { get; private set; } // 0x8

		// RVA: 0xF08228 Offset: 0xF08228 VA: 0xF08228
		public EpisodeSelectSceneArgs(bool isBeginer)
		{
			IsFromBeginner = isBeginer;
		}
	}
}
