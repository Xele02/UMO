using XeSys;

namespace XeApp.Game.Common
{
	public class Database : SingletonBehaviour<Database>
	{
		public GameSetupData gameSetup; // 0xC
		public GameResultData gameResult; // 0x10
		public FacialNameDatabase facialNameDatabase; // 0x14
		public MusicTextDatabase musicText; // 0x18
		public SNSRoomTextDatabase roomText; // 0x1C
		public SelectedMusicData selectedMusic; // 0x20
		public BonusData bonusData; // 0x24
		public AdvSetupData advSetup; // 0x28
		public AdvResultData advResult; // 0x2C
		public byte tutorialPaidVC; // 0x30
		public int selectedEventStoryEventId; // 0x34

		// // RVA: 0xE6CD84 Offset: 0xE6CD84 VA: 0xE6CD84 Slot: 4
		protected override void Awake()
		{
			base.Awake();
		}

		// // RVA: 0xE6CDE8 Offset: 0xE6CDE8 VA: 0xE6CDE8
		public Database()
		{
			gameSetup = new GameSetupData();
			gameResult = new GameResultData();
			facialNameDatabase = new FacialNameDatabase();
			musicText = new MusicTextDatabase();
			roomText = new SNSRoomTextDatabase();
			selectedMusic = new SelectedMusicData();
			bonusData = new BonusData();
			advSetup = new AdvSetupData();
			advResult = new AdvResultData();
		}
	}
}
