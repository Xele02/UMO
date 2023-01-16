
namespace XeApp.Game.Menu
{
	public class TeamSelectDivaListArgs : TransitionArgs
	{
		public int slot; // 0x8
		public DFKGGBMFFGB_PlayerInfo viewPlayerData; // 0xC
		public EEDKAACNBBG_MusicData viewMusicBaseData; // 0x10
		public bool isFromBeginner; // 0x14
		public int beginnerMissionId; // 0x18
	}
}
