using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using XeApp.Game.Common;

namespace XeApp.Game
{
	public class MusicScoreData
	{
		public enum TouchState
		{
			None = 0,
			Start = 1,
			End = 2,
			Continue = 3,
			SwipeStart = 4,
			SwipeEnd = 5,
		}

		public enum FlickType
		{
			None = 0,
			Left = 1,
			Right = 2,
			Up = 3,
			Down = 4,
			Wing = 10,
		}

		public class InputNoteInfo
		{
			public int time { get; internal set; } // 0x8
			public sbyte trackID { get; internal set; } // 0xC
			public MusicScoreData.TouchState sync { get; internal set; } // 0xD
			public MusicScoreData.TouchState longTouch { get; internal set; } // 0xE
			public MusicScoreData.TouchState swipe { get; internal set; } // 0xF
			public MusicScoreData.FlickType flick { get; internal set; } // 0x10
			public int syncIndex { get; internal set; } // 0x14
			public int nextIndex { get; internal set; } // 0x18
			public int prevIndex { get; internal set; } // 0x1C
			public int value { get; internal set; } // 0x20
			public int thisIndex { get; internal set; } // 0x24
			public int wingTrackID { get; internal set; } // 0x28
			public bool isSlide { get; internal set; } // 0x2C
			//public bool isWing { get; } 0xC9AF2C
		}

		public struct EventNoteInfo
		{
			public int time; // 0x0
			public int value; // 0x4
		}

		public struct TenpoInfo
		{
			public int time; // 0x0
			public float bpm; // 0x4
			public float offset; // 0x8
			public byte tacet; // 0xC
			public byte meter; // 0xD
			public int length; // 0x10
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
		public List<MusicScoreData.TenpoInfo> tenpoTrack; // 0xC
		public List<MusicScoreData.InputNoteInfo> inputNoteTrack; // 0x10
		public List<MusicScoreData.EventNoteInfo> eventTrack10; // 0x14
		public List<MusicScoreData.EventNoteInfo> eventTrack11; // 0x18
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
			MemoryStream ms = new MemoryStream(dataBytes, offset, size);
			StreamReader reader = new StreamReader(ms, Encoding.UTF8);

			EDOHBJAPLPF_JsonData json = IKPIMINCOPI_JsonMapper.PFAMKCGJKKL_ToObject(reader);
			List<MusicScoreData.TenpoInfo> tempo = new List<MusicScoreData.TenpoInfo>();
			List<MusicScoreData.InputNoteInfo> inputNote = new List<MusicScoreData.InputNoteInfo>();
			EDOHBJAPLPF_JsonData tenpoTrack = json["TenpoTrack"];
			if (tenpoTrack.EPNGJLOKGIF_IsArray)
			{
				for (int i = 0; i < tenpoTrack.HNBFOAJIIAL_Count; i++)
				{
					TenpoInfo tenpoData = new TenpoInfo();
					tenpoData.time = (int)tenpoTrack[i]["time"];
					tenpoData.bpm = (float)(double)tenpoTrack[i]["bpm"];
					tenpoData.offset = (float)(double)tenpoTrack[i]["offset"];
					tenpoData.tacet = (byte)(int)tenpoTrack[i]["tacet"];
					tenpoData.meter = (byte)(int)tenpoTrack[i]["meter"];
					tenpoData.length = (int)tenpoTrack[i]["length"];
					tempo.Add(tenpoData);
				}
			}
			EDOHBJAPLPF_JsonData inputTrack = json["InputTrack"];
			bool isWide = false;
			if (inputTrack.EPNGJLOKGIF_IsArray)
			{
				inputNote.Capacity = inputTrack.HNBFOAJIIAL_Count;
				int localIndex = 0;
				for (int i = 0; i < inputTrack.HNBFOAJIIAL_Count; i++)
				{
					InputNoteInfo noteInfo = new InputNoteInfo();
					noteInfo.time = (int)inputTrack[i]["time"];
					noteInfo.trackID = (sbyte)inputTrack[i]["trackID"];
					noteInfo.sync = (TouchState)(int)inputTrack[i]["sync"];
					noteInfo.syncIndex = (int)inputTrack[i]["syncIndex"];
					noteInfo.longTouch = (TouchState)(int)inputTrack[i]["longTouch"];
					noteInfo.swipe = (TouchState)(int)inputTrack[i]["swipe"];
					noteInfo.flick = (FlickType)(int)inputTrack[i]["flick"];
					noteInfo.prevIndex = (int)inputTrack[i]["prev"];
					noteInfo.nextIndex = (int)inputTrack[i]["next"];
					noteInfo.value = (int)inputTrack[i]["value"];
					noteInfo.thisIndex = localIndex >> 0x10;
					ProcessInputNoteInfo(ref noteInfo, inputNote);
					inputNote.Add(noteInfo);
					localIndex += 0x10000;
					isWide |= RhythmGameConsts.IsWideLine(noteInfo.trackID);
				}
			}
			EDOHBJAPLPF_JsonData eventTracks = json["EventTracks"];
			List<MusicScoreData.EventNoteInfo> track10 = null;
			List<MusicScoreData.EventNoteInfo> track11 = null;
			if (eventTracks.EPNGJLOKGIF_IsArray)
			{
				for (int i = 0; i < eventTracks.HNBFOAJIIAL_Count; i++)
				{
					List<MusicScoreData.EventNoteInfo> eventInfo = new List<EventNoteInfo>();
					EDOHBJAPLPF_JsonData trackID = eventTracks[i]["trackID"];
					EDOHBJAPLPF_JsonData keys = eventTracks[i]["keys"];
					eventInfo.Capacity = keys.HNBFOAJIIAL_Count;
					for(int j = 0; j < keys.HNBFOAJIIAL_Count; j++)
					{
						eventInfo.Add(new EventNoteInfo() { time = (int)keys[j]["time"], value = (int)keys[j]["value"] });
					}
					if ((int)trackID == 10)
						track10 = eventInfo;
					if ((int)trackID == 11)
						track11 = eventInfo;
				}
			}
			MusicScoreData data = new MusicScoreData();
			data.inputNoteTrack = inputNote;
			data.eventTrack10 = track10;
			data.eventTrack11 = track11;
			data.tenpoTrack = tempo;
			data.isWideTrack = isWide;

			reader.Dispose();
			ms.Dispose();

			return data;
		}

		// // RVA: 0xC99F04 Offset: 0xC99F04 VA: 0xC99F04
		private static void ProcessInputNoteInfo(ref MusicScoreData.InputNoteInfo info, List<MusicScoreData.InputNoteInfo> infoList)
		{
			info.wingTrackID = -1;
			if((int)info.flick < 9)
			{
				info.wingTrackID = (int)info.flick - 10;
				//if(!RhythmGameConsts.IsWingLine(info.trackID)) //??
				{
					if (RhythmGameConsts.IsLeftLine(info.trackID))
						info.flick = FlickType.Left;
					else
						info.flick = FlickType.Right;
				}
			}
			if(info.longTouch == TouchState.End)
			{
				info.isSlide = true;
				if(infoList[info.prevIndex].trackID == info.trackID)
				{
					info.isSlide = false;
					if (infoList[info.prevIndex].longTouch == TouchState.Continue)
						info.isSlide = true;
					infoList[info.prevIndex].isSlide = info.isSlide;
				}
			}
			else
			{
				if(info.longTouch == TouchState.Continue)
				{
					info.isSlide = true;
					infoList[info.prevIndex].isSlide = true;
				}
			}
		}

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
	}
}
