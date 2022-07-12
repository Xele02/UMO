using System;

namespace XeApp.Game
{
	public class MusicScoreData
	{
		public class InputNoteInfo
		{
		}

		public const int CURRENT_VERSION = 1;
		public static readonly int INTRO_FADE = 100; // 0x0
		public static readonly int START_VALKYRIE_MODE = 1000; // 0x4
		public static readonly int LEAVE_VALKYRIE_MODE = 1001; // 0x8
		public static readonly int START_DIVA_MODE = 2000; // 0xC
		public static readonly int START_COMBO_RESULT = 9000; // 0x10
		public static readonly int TUTORIAL_ONE_END_GAME = 10000; // 0x14
		public static readonly int TUTORIAL_TWO_FORCE_FWAVE_MAX = 10001; // 0x18
		public static readonly int TUTORIAL_TWO_FORCE_DEFEAT_ENEMY = 10002; // 0x1C
		public static readonly int TUTORIAL_TWO_ACTIVE_SKILL_DESCRIPTION = 10003; // 0x20
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
		private static string[] tbl = new string[4] { "MusicScoreData : dataByte is null", "MusicScoreData : dataBytes offset size over dataByte.Length",
			"MusicScoreData : dataBytes is too little", "MusicScoreData : Unkown Header"}; // 0x24
		private static string[] tbl2 = new string[7] { "MusicScoreData : Invalid Header", "MusicScoreData : Invalid Data Version", "MusicScoreData : SCRE Chunk Error.",
			"MusicScoreData : BPM Chunk Error.", "MusicScoreData : INPT Chunk Error.", "MusicScoreData : EVNT Chunk Error.", "MusicScoreData : StringLiteral_21091 Error"}; // 0x28

		// // RVA: 0xC978C0 Offset: 0xC978C0 VA: 0xC978C0
		// public static bool IsWingNote(MusicScoreData.FlickType flick) { }

		// // RVA: 0xC978D4 Offset: 0xC978D4 VA: 0xC978D4
		// public static int GetWingTargetTrackID(MusicScoreData.FlickType flick) { }

		// // RVA: 0xC978DC Offset: 0xC978DC VA: 0xC978DC
		public static MusicScoreData Instantiate(byte[] dataBytes)
		{
			return Instantiate(dataBytes, 0, dataBytes.Length);
		}

		// // RVA: 0xC97974 Offset: 0xC97974 VA: 0xC97974
		public static MusicScoreData Instantiate(byte[] dataBytes, int offset, int size)
		{
			if(dataBytes == null)
			{
				UnityEngine.Debug.LogError(tbl[0]);
				return null;
			}
			else if(dataBytes.Length < size + offset)
			{
				UnityEngine.Debug.LogError(tbl[1]);
				return null;
			}
			else if(size < 8)
			{
				UnityEngine.Debug.LogError(tbl[2]);
				return null;
			}
			else
			{
				UInt32 header = BitConverter.ToUInt32(dataBytes, offset);
				if(header == 0x46464952)
				{
					return InstantiateFromRIFF(dataBytes, offset, 0);
				}
				if(dataBytes[0] == 0x7b)
				{
					return InstantiateFromJson(dataBytes, offset, size);
				}
				UnityEngine.Debug.LogError(tbl[3]);
			}
			return null;
		}

		// // RVA: 0xC989D4 Offset: 0xC989D4 VA: 0xC989D4
		private static MusicScoreData InstantiateFromJson(byte[] dataBytes, int offset, int size)
		{
			UnityEngine.Debug.LogError("TODO InstantiateFromJson");
			return null;
		}

		// // RVA: 0xC99F04 Offset: 0xC99F04 VA: 0xC99F04
		// private static void ProcessInputNoteInfo(ref MusicScoreData.InputNoteInfo info, List<MusicScoreData.InputNoteInfo> infoList) { }

		// // RVA: 0xC97D08 Offset: 0xC97D08 VA: 0xC97D08
		private static MusicScoreData InstantiateFromRIFF(byte[] dataBytes, int offset, int size)
		{
			UnityEngine.Debug.LogError("TODO InstantiateFromRIFF");
			return null;
		}

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
