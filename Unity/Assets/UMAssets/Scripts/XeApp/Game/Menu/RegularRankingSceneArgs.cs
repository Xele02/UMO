
namespace XeApp.Game.Menu
{ 
	public class RegularRankingSceneArgs : TransitionArgs
	{
		public IBJAKJJICBC musicData { get; private set; } // 0x8

		// RVA: 0xCFAA00 Offset: 0xCFAA00 VA: 0xCFAA00
		public RegularRankingSceneArgs(IBJAKJJICBC musicData)
		{
			this.musicData = musicData;
		}
	}
}
