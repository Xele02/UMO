using UnityEngine;
using System.Collections.Generic;
using XeApp.Game.Common;

namespace XeApp.Game.RhythmGame
{
	public class RNoteOwner : MonoBehaviour
	{
		private struct PausingInputData
		{
			public int fingerId; // 0x0
			public bool release; // 0x4

			//// RVA: 0x7FB49C Offset: 0x7FB49C VA: 0x7FB49C
			//public void Reset() { }
		}

		private MusicData musicData; // 0xC
		private MusicScoreData musicScoreData; // 0x10
		[SerializeField]
		private List<RNote> rNoteList; // 0x14
		private RNoteSpawner rNoteSpawner; // 0x18
		private RNoteRemover rNoteRemover; // 0x1C
		private RNoteLaneManager rNoteLaneManager; // 0x20
		[SerializeField]
		private GameObject judgePointObject; // 0x24
		[SerializeField]
		private GameObject judgePointObjectWide; // 0x28
		[SerializeField]
		private Transform[] judgePointTransforms; // 0x2C
		[SerializeField]
		private float[] neutralCounter; // 0x30
		private int[] lineTouchFingerIds; // 0x34
		public bool isPause; // 0x4C
		private RNoteOwner.PausingInputData[] pausingInputData; // 0x50
		private List<RNoteSingle> activeSingleList = new List<RNoteSingle>(30); // 0x58
		private List<RNoteLong> activeLongList = new List<RNoteLong>(15); // 0x5C
		private List<RNoteSlide> activeSlideList = new List<RNoteSlide>(15); // 0x60
		private RNoteObject.DelegateOverrideNoteJudged delegateOverrideNoteJudgeList; // 0x64
		private RNoteObject.NoteJudgedDelegate judgedDelegate; // 0x68
		private RNoteObject.NoteBeyondDelegate beyondDelegate; // 0x6C
		private RNoteObject.NotePassedDelegate passedDelegate; // 0x70
		private RhythmGameSpecialNotesAssigner specialNotesAssigner = new RhythmGameSpecialNotesAssigner(); // 0x74
		private RhythmGameMode gameMode; // 0x78
		private BuffEffectOwner buffOwner; // 0x7C
		private int[] evaluationOffsetMillisec; // 0x80
		public int checkStartNotesIndex = 1; // 0x84
		public int checkEndNotesIndex = 1; // 0x88
		public bool assignedCenterLiveSkillNote; // 0x8C
		private int limitNoteJudgeScaleUp; // 0x90
		private int limitNoteJudgeScaleDown; // 0x94

		public RNoteObjectPool objectPool { get; private set; } // 0x38
		public RNoteSinglePool singlePool { get; private set; } // 0x3C
		public RNoteLongPool longPool { get; private set; } // 0x40
		public RNoteSyncPool syncPool { get; private set; } // 0x44
		public RNoteSlidePool slidePool { get; private set; } // 0x48
		public LinkedList<RNoteObject> spawnRNoteObjects { get; private set; } // 0x54

		//// RVA: 0xDB12E4 Offset: 0xDB12E4 VA: 0xDB12E4
		//private int LimitNoteJudgeValue(int a_limit, int a_value) { }

		//// RVA: 0xDB1384 Offset: 0xDB1384 VA: 0xDB1384
		//public void Initialize(MusicData muiscData, RhythmGameMode gameMode, BuffEffectOwner buffOwner, RhythmGameSpecialNotesAssigner.AssignInfo a_assing_info, bool a_setting_mv, bool a_notes_seeting_mv, bool a_setting_skip = False) { }

		//// RVA: 0xDB2F30 Offset: 0xDB2F30 VA: 0xDB2F30
		//private void SetJudgePointTransform() { }

		//// RVA: 0xDB4FF8 Offset: 0xDB4FF8 VA: 0xDB4FF8
		//public void SetLineAlphaCallback(RNoteLaneManager.LineAlphaCallback callback) { }

		//// RVA: 0xDB4A58 Offset: 0xDB4A58 VA: 0xDB4A58
		//public void SetEnableRenderer(bool a_renderer) { }

		//// RVA: 0xDB5204 Offset: 0xDB5204 VA: 0xDB5204
		//public void Free() { }

		//// RVA: 0xDB53E8 Offset: 0xDB53E8 VA: 0xDB53E8
		//public void Pause() { }

		//// RVA: 0xDB565C Offset: 0xDB565C VA: 0xDB565C
		//public void Resume() { }

		//// RVA: 0xDB6E6C Offset: 0xDB6E6C VA: 0xDB6E6C
		//public void RemoveAllDelegate() { }

		//// RVA: 0xDB6E7C Offset: 0xDB6E7C VA: 0xDB6E7C
		//public void SetDelegateOverrideNoteJudge(RNoteObject.DelegateOverrideNoteJudged a_delegate) { }

		//// RVA: 0xDB6E84 Offset: 0xDB6E84 VA: 0xDB6E84
		//public void AddJudgeDelegate(RNoteObject.NoteJudgedDelegate judgedDelegate) { }

		//// RVA: 0xDB6E90 Offset: 0xDB6E90 VA: 0xDB6E90
		//public void AddBeyondDelegate(RNoteObject.NoteBeyondDelegate beyondDelegate) { }

		//// RVA: 0xDB6E9C Offset: 0xDB6E9C VA: 0xDB6E9C
		//public void AddPassedDelegate(RNoteObject.NotePassedDelegate passedDelegate) { }

		//// RVA: 0xDB6EA8 Offset: 0xDB6EA8 VA: 0xDB6EA8
		//public void OnUpdate(int musicMilliSec) { }

		//// RVA: 0xDB7AA4 Offset: 0xDB7AA4 VA: 0xDB7AA4
		//public void AllocNote(RNote rNote) { }

		//// RVA: 0xDB8288 Offset: 0xDB8288 VA: 0xDB8288
		//private bool AllocNoteObject(RNote rNote, bool isInScreen, out RNoteObject outputObject) { }

		//// RVA: 0xDB8AC8 Offset: 0xDB8AC8 VA: 0xDB8AC8
		//public void FreeNote(RNoteObject obj) { }

		//// RVA: 0xDB8BEC Offset: 0xDB8BEC VA: 0xDB8BEC
		//public bool BeganTouch(int lineNo, int fingerId) { }

		//// RVA: 0xDB5FF8 Offset: 0xDB5FF8 VA: 0xDB5FF8
		//public void EndedTouch(int lineNo, int lineNo_Begin, int fingerId, bool forceMiss, bool checkLine = False) { }

		//// RVA: 0xDB9A9C Offset: 0xDB9A9C VA: 0xDB9A9C
		//public void ReleaseLine(int lineNo, int lineNo_Begin, int fingerId, bool forceMiss, bool checkLine = False) { }

		//// RVA: 0xDB9BDC Offset: 0xDB9BDC VA: 0xDB9BDC
		//public void NextLine(int lineNo0, int lineNo1, int fingerId, bool forceMiss, bool checkLine = False) { }

		//// RVA: 0xDB9BE0 Offset: 0xDB9BE0 VA: 0xDB9BE0
		//public void SwipedTouch(int lineNo, int fingerId, bool isRight, bool isDown, bool isLeft, bool isUp) { }

		//// RVA: 0xDBA644 Offset: 0xDBA644 VA: 0xDBA644
		//private bool IsSuccessFlick(MusicScoreData.InputNoteInfo info, bool[] flag) { }

		//// RVA: 0xDBA7A4 Offset: 0xDBA7A4 VA: 0xDBA7A4
		//public void NeutralTouch(int lineNo, int fingerId) { }

		//// RVA: 0xDBAC34 Offset: 0xDBAC34 VA: 0xDBAC34
		//public void CheckInputCallback(RhythmGameInputPerformer.InputSaver inputSaver) { }

		//// RVA: 0xDBAD54 Offset: 0xDBAD54 VA: 0xDBAD54
		//private int SinglePoolSortTimeFunc(RNoteSingle a, RNoteSingle b) { }

		//// RVA: 0xDBAE5C Offset: 0xDBAE5C VA: 0xDBAE5C
		//private int LongPoolSortFirstTimeFunc(RNoteLong a, RNoteLong b) { }

		//// RVA: 0xDBAF40 Offset: 0xDBAF40 VA: 0xDBAF40
		//private int LongPoolSortLastTimeFunc(RNoteLong a, RNoteLong b) { }

		//// RVA: 0xDBB024 Offset: 0xDBB024 VA: 0xDBB024
		//public bool IsLongBeganTouched(int lineNo) { }

		//// RVA: 0xDB9AF4 Offset: 0xDB9AF4 VA: 0xDB9AF4
		//public bool IsSlideBeganTouched(int fingerId) { }

		//// RVA: 0xDBB150 Offset: 0xDBB150 VA: 0xDBB150
		//public RNoteSlide GetRNoteSlide(RNoteObject startNote) { }

		//// RVA: 0xDBB2AC Offset: 0xDBB2AC VA: 0xDBB2AC
		//public bool IsLongLastEvaluation(int lineNo) { }

		//// RVA: 0xDBB458 Offset: 0xDBB458 VA: 0xDBB458
		//public bool IsSlideLastEvaluation(int fingerId) { }

		//// RVA: 0xDBB66C Offset: 0xDBB66C VA: 0xDBB66C
		//public void SetupNoteResultData(ref int[] countArray, RhythmGamePlayLogger logger) { }

		//// RVA: 0xDBB848 Offset: 0xDBB848 VA: 0xDBB848
		//public int GetExcellentResultNoteCount() { }

		//// RVA: 0xDBB948 Offset: 0xDBB948 VA: 0xDBB948
		//public float CalcSuccessNotesRate() { }

		//// RVA: 0xDBBA70 Offset: 0xDBBA70 VA: 0xDBBA70
		//public bool IsAllPerfectResult() { }

		//// RVA: 0xDBBB60 Offset: 0xDBBB60 VA: 0xDBBB60
		public void OnChangeGameMode()
		{
			TodoLogger.Log(0, "OnChangeGameMode");
		}

		//// RVA: 0xDBBD00 Offset: 0xDBBD00 VA: 0xDBBD00
		//private void OnModeAttrAssign(int noteIndex, KLJCBKMHKNK.HHMPIIILOLD mode, RhythmGameConsts.SpecialNoteType noteType) { }

		//// RVA: 0xDBBDBC Offset: 0xDBBDBC VA: 0xDBBDBC
		//private void OnModeItemInfoAssign(int noteIndex, KLJCBKMHKNK.HHMPIIILOLD mode, int itemId, int itemIndex) { }

		//// RVA: 0xDBBE80 Offset: 0xDBBE80 VA: 0xDBBE80
		//public int GetRareItemRandomSeed() { }

		//// RVA: 0xDB9A80 Offset: 0xDB9A80 VA: 0xDB9A80
		//public RhythmGameConsts.NoteResult OverwriteCheatNoteResult(RhythmGameConsts.NoteResult result, int lineNo) { }

		//// RVA: 0xDBBEAC Offset: 0xDBBEAC VA: 0xDBBEAC
		//public bool CheckAllNotesEnd() { }

		//// RVA: 0xDBC000 Offset: 0xDBC000 VA: 0xDBC000
		//public string SerializeForNotesLog() { }

		//// RVA: 0xDBC188 Offset: 0xDBC188 VA: 0xDBC188
		//public RNote GetNote(int index) { }

		//// RVA: 0xDBC208 Offset: 0xDBC208 VA: 0xDBC208
		//public int GetNoteListNum() { }

		//// RVA: 0xDBC280 Offset: 0xDBC280 VA: 0xDBC280
		//public void UpdateObjectPool() { }
	}
}
