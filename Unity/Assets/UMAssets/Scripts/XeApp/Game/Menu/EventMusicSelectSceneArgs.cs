
namespace XeApp.Game.Menu
{
	public class EventMusicSelectSceneArgs : MusicSelectArgs
	{
		public int EventUniqueId { get; private set; } // 0x10
		public bool isFromRhythmGame { get; private set; } // 0x14

		// RVA: 0x13B8B58 Offset: 0x13B8B58 VA: 0x13B8B58
		public EventMusicSelectSceneArgs(int eventUniqueId, bool line6Mode = false, bool fromRhythmGame = false)
		{
			EventUniqueId = eventUniqueId;
			isFromRhythmGame = fromRhythmGame;
		}
	}
}
