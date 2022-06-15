namespace XeApp.Game
{
	public class MusicScoreData
	{
		public class InputNoteInfo
		{
		}

		public const int CURRENT_VERSION = 1;
		public static readonly int INTRO_FADE; // 0x0
		public static readonly int START_VALKYRIE_MODE; // 0x4
		public static readonly int LEAVE_VALKYRIE_MODE; // 0x8
		public static readonly int START_DIVA_MODE; // 0xC
		public static readonly int START_COMBO_RESULT; // 0x10
		public static readonly int TUTORIAL_ONE_END_GAME; // 0x14
		public static readonly int TUTORIAL_TWO_FORCE_FWAVE_MAX; // 0x18
		public static readonly int TUTORIAL_TWO_FORCE_DEFEAT_ENEMY; // 0x1C
		public static readonly int TUTORIAL_TWO_ACTIVE_SKILL_DESCRIPTION; // 0x20
		public int version; // 0x8
		// public List<MusicScoreData.TenpoInfo> tenpoTrack; // 0xC
		// public List<MusicScoreData.InputNoteInfo> inputNoteTrack; // 0x10
		// public List<MusicScoreData.EventNoteInfo> eventTrack10; // 0x14
		// public List<MusicScoreData.EventNoteInfo> eventTrack11; // 0x18
		public bool isWideTrack; // 0x1C
		private int displayMilliSec; // 0x20
		private int outDisplayMilliSec; // 0x24
		private const uint CHUNK_ID_RIFF = 1179011410;
		private const uint CHUNK_ID_SCRE = 1163019091;
		private const uint CHUNK_ID_BPM_ = 541937730;
		private const uint CHUNK_ID_INPT = 1414549065;
		private const uint CHUNK_ID_EVNT = 1414420037;
		private static string[] tbl; // 0x24
		private static string[] tbl2; // 0x28

		// // RVA: 0xC978C0 Offset: 0xC978C0 VA: 0xC978C0
		// public static bool IsWingNote(MusicScoreData.FlickType flick) { }

		// // RVA: 0xC978D4 Offset: 0xC978D4 VA: 0xC978D4
		// public static int GetWingTargetTrackID(MusicScoreData.FlickType flick) { }

		// // RVA: 0xC978DC Offset: 0xC978DC VA: 0xC978DC
		// public static MusicScoreData Instantiate(byte[] dataBytes) { }

		// // RVA: 0xC97974 Offset: 0xC97974 VA: 0xC97974
		// public static MusicScoreData Instantiate(byte[] dataBytes, int offset, int size) { }

		// // RVA: 0xC989D4 Offset: 0xC989D4 VA: 0xC989D4
		// private static MusicScoreData InstantiateFromJson(byte[] dataBytes, int offset, int size) { }

		// // RVA: 0xC99F04 Offset: 0xC99F04 VA: 0xC99F04
		// private static void ProcessInputNoteInfo(ref MusicScoreData.InputNoteInfo info, List<MusicScoreData.InputNoteInfo> infoList) { }

		// // RVA: 0xC97D08 Offset: 0xC97D08 VA: 0xC97D08
		// private static MusicScoreData InstantiateFromRIFF(byte[] dataBytes, int offset, int size) { }

		// // RVA: 0xC9A2CC Offset: 0xC9A2CC VA: 0xC9A2CC
		// private static List<MusicScoreData.EventNoteInfo> SetupEventTrack(byte[] dataBytes, int offset, int count) { }

		// // RVA: 0xC9A42C Offset: 0xC9A42C VA: 0xC9A42C
		// private int GetSyncNeighborIndex(int index) { }

		// // RVA: 0xC9A528 Offset: 0xC9A528 VA: 0xC9A528
		// private int GetLongTouchNextIndex(int index) { }

		// // RVA: 0xC9A66C Offset: 0xC9A66C VA: 0xC9A66C
		// private int GetSwipeNextIndex(int index) { }

		// // RVA: 0xC9A7B0 Offset: 0xC9A7B0 VA: 0xC9A7B0
		public int CalcComboLimit()
		{
			UnityEngine.Debug.LogError("TODO");
			return 0;
		}

		// // RVA: 0xC9A894 Offset: 0xC9A894 VA: 0xC9A894
		// private string ILSpyTrap(int n) { }

		// // RVA: 0xC9A910 Offset: 0xC9A910 VA: 0xC9A910
		static MusicScoreData()
		{
			UnityEngine.Debug.LogError("TODO");
		}
	}
}
