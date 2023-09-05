
namespace XeApp.Game.Menu
{
	public class EventRankingSceneArgs : TransitionArgs
	{
		public IKDICBBFBMI_EventBase eventCtrl { get; private set; } // 0x8
		public bool isPast { get; private set; } // 0xC
		public int CurrentRankingIndex { get; private set; } // 0x10
		public int selectDiva { get; private set; } // 0x14

		// RVA: 0xB8F398 Offset: 0xB8F398 VA: 0xB8F398
		public EventRankingSceneArgs(IKDICBBFBMI_EventBase eventCtrl, bool isPast = false, int currentRankinIndex = 0, int selectDiva = 0)
		{
			this.isPast = isPast;
			this.eventCtrl = eventCtrl;
			CurrentRankingIndex = currentRankinIndex;
			this.selectDiva = selectDiva;
		}
	}
}
