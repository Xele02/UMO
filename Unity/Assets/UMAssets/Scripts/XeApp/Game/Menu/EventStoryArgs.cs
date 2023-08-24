
namespace XeApp.Game.Menu
{
	public class EventStoryArgs : TransitionArgs
	{
		public CCAAJNJGNDO EventStoryData { get; private set; } // 0x8

		// RVA: 0xB8F3E0 Offset: 0xB8F3E0 VA: 0xB8F3E0
		public EventStoryArgs(CCAAJNJGNDO storyData)
		{
			EventStoryData = storyData;
		}
	}
}
