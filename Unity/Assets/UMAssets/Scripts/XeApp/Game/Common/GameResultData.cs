using XeApp.Game.RhythmGame;

namespace XeApp.Game.Common
{
	public class GameResultData
	{
		public enum TutorialOneResult
		{
			NONE = 0,
			RETRY = 1,
			GACHA = 2,
		}

		private bool isClear; // 0x8
		private bool isGameOver; // 0x9
		private int[] noteResultCount = new int[5]; // 0xC
		private int noteResultCount_Excellent; // 0x10

		public RhythmGamePlayLog gameLog { get; private set; } // 0x14
		public GameResultData.TutorialOneResult tutorialOneResult { get; private set; } // 0x18

		// RVA: 0xE9C898 Offset: 0xE9C898 VA: 0xE9C898
		public void Setup(bool isClear, bool isGameOver, int[] noteResultCount, RhythmGamePlayLog gameLog, int a_noteResultCount_Excellent = 0)
		{
			this.isGameOver = isGameOver;
			this.isClear = isClear;
			if (noteResultCount != null)
				this.noteResultCount = noteResultCount;
			this.noteResultCount_Excellent = a_noteResultCount_Excellent;
			this.gameLog = gameLog;
		}

		//// RVA: 0xE9C8C4 Offset: 0xE9C8C4 VA: 0xE9C8C4
		//public void SetupForTutorialOne(GameResultData.TutorialOneResult result) { }

		//// RVA: 0xE9C8CC Offset: 0xE9C8CC VA: 0xE9C8CC
		//public void SetupForTutorialTow() { }

		//// RVA: 0xE9C8D8 Offset: 0xE9C8D8 VA: 0xE9C8D8
		//public void Reset() { }

		//// RVA: 0xE9C918 Offset: 0xE9C918 VA: 0xE9C918
		public bool IsClear()
		{
			return isClear;
		}

		//// RVA: 0xE9C920 Offset: 0xE9C920 VA: 0xE9C920
		//public bool IsGameOver() { }

		//// RVA: 0xE9C928 Offset: 0xE9C928 VA: 0xE9C928
		//public int GetNoteTypeCount(RhythmGameConsts.NoteResult noteResultType) { }

		//// RVA: 0xE9C970 Offset: 0xE9C970 VA: 0xE9C970
		//public int GetNoteExcellentCount() { }
	}
}
