using UnityEngine;
using System.Collections.Generic;
using XeSys;

namespace XeApp.Game.RhythmGame
{
	public class RhythmGameInputPerformer : RhythmGamePerformer
	{
		public delegate void DelegateCheckInput(InputSaver a_inputsaver);


		private class FingerInfo
		{
			public class Info
			{
				public bool m_hit; // 0x8
				public int m_time; // 0xC
			}

			public Info[] info { get; set; }

			// RVA: 0x9A3258 Offset: 0x9A3258 VA: 0x9A3258
			public FingerInfo()
			{
				TodoLogger.Log(0, "FingerInfo()");
			}

			//// RVA: 0x9A6098 Offset: 0x9A6098 VA: 0x9A6098
			//public void ResetJudgeLineInfo() { }

			//// RVA: 0x9A5A24 Offset: 0x9A5A24 VA: 0x9A5A24
			//public void SetJudgeLineInfo(int lineNo, int noteTime) { }

			//// RVA: 0x9A5AE0 Offset: 0x9A5AE0 VA: 0x9A5AE0
			//public int JudgeLineCandidate(int a_note_msec, Vector2 a_touch_pos, List<Vector2> a_touch_rect_pos, int a_touch_priority_check) { }
		}
		
		public class InputSaver
		{
			private float m_limitSec; // 0x8
			private List<bool> m_saveForLine; // 0xC
			private List<FingerData> m_finger; // 0x10

			public BeganTouchLineCallback onBeganTouch { private get; set; } // 0x14
			public EndedTouchLineCallback onEndedTouch { private get; set; } // 0x18
			public ReleaseLineCallback onReleaseLine { private get; set; } // 0x1C
			public NextLineCallback onNextLine { private get; set; } // 0x20
			public SwipedTouchLineCallback onSwipedTouch { private get; set; } // 0x24
			public NeutralTouchLineCallback onNeutralTouch { private get; set; } // 0x28

			// RVA: 0x9A2FC0 Offset: 0x9A2FC0 VA: 0x9A2FC0
			public InputSaver(float limitSec)
			{
				m_limitSec = limitSec;
				m_saveForLine = new List<bool>(6);
				for(int i = 0; i < 6; i++)
				{
					m_saveForLine.Add(false);
				}
				m_finger = new List<FingerData>(InputManager.fingerCount);
				for(int i = 0; i < InputManager.fingerCount; i++)
				{
					m_finger.Add(new FingerData());
				}
			}

			//// RVA: 0x9A5DE8 Offset: 0x9A5DE8 VA: 0x9A5DE8
			//public void OnTouched(int fingerId, int lineNo) { }

			//// RVA: 0x9A6194 Offset: 0x9A6194 VA: 0x9A6194
			//public void OnMoved(int fingerId, bool isContain) { }

			//// RVA: 0x9A6170 Offset: 0x9A6170 VA: 0x9A6170
			//public void OnReleased(int fingerId) { }

			//// RVA: 0x9A6268 Offset: 0x9A6268 VA: 0x9A6268
			//public void OnSwiped(int lineNo, int fingerId, bool isRight, bool isDown, bool isLeft, bool isUp) { }

			//// RVA: 0x9A62DC Offset: 0x9A62DC VA: 0x9A62DC
			//public void OnNeutral(int lineNo, int fingerId) { }

			//// RVA: 0x9A7F48 Offset: 0x9A7F48 VA: 0x9A7F48
			//public int GetFingerId(int fingerId) { }

			//// RVA: 0x9A7F64 Offset: 0x9A7F64 VA: 0x9A7F64
			//public int GetLineNo(int fingerId) { }

			//// RVA: 0x9A601C Offset: 0x9A601C VA: 0x9A601C
			//public bool UpdateLineNo(int fingerId, int lineNo) { }

			//// RVA: 0x9A8400 Offset: 0x9A8400 VA: 0x9A8400
			//public bool IsActive(int fingerId) { }

			//// RVA: 0x9A70B0 Offset: 0x9A70B0 VA: 0x9A70B0
			//private bool IsSave(int fingerId) { }

			//// RVA: 0x9A842C Offset: 0x9A842C VA: 0x9A842C
			//private void SaveFinish(int fingerId) { }

			//// RVA: 0x9A7094 Offset: 0x9A7094 VA: 0x9A7094
			//private void TimerReset(int fingerId) { }

			//// RVA: 0x9A4B2C Offset: 0x9A4B2C VA: 0x9A4B2C
			//public void TimerUpdate() { }

			//// RVA: 0x9A2AEC Offset: 0x9A2AEC VA: 0x9A2AEC
			//public void ChangeLimitSec(float limitSec) { }

			//// RVA: 0x9A3E6C Offset: 0x9A3E6C VA: 0x9A3E6C
			public void SetLineSave(int lineNo, bool isSave, bool isCheckEndTouch = true)
			{
				bool prevVal = m_saveForLine[lineNo];
				m_saveForLine[lineNo] = isSave;
				if(prevVal && isCheckEndTouch && !isSave)
				{
					for(int i = 0; i < m_finger.Count; i++)
					{
						if(m_finger[i].lineNo == lineNo && lineNo > -1 && m_finger[i].fingerId < 0)
						{
							onEndedTouch(lineNo, m_finger[i].lineNo_Begin, m_finger[i].index, true);
							m_finger[i].Reset();
						}
					}
				}
			}

			//// RVA: 0x9A40F8 Offset: 0x9A40F8 VA: 0x9A40F8
			//public RhythmGameInputPerformer.FingerData SearchFinger(int fingerId) { }
		}

		public class FingerData
		{
			public int index { get; private set; } // 0x8
			public int fingerId { get; private set; } // 0xC
			public int lineNo { get; private set; } // 0x10
			public int lineNo_Begin { get; private set; } // 0x14
			public float timer { get; private set; } // 0x18
			public bool requestedTimerReset { get; private set; } // 0x1C

			// RVA: 0x9A6AA8 Offset: 0x9A6AA8 VA: 0x9A6AA8
			public FingerData()
			{
				Reset();
			}

			//// RVA: 0x9A6B14 Offset: 0x9A6B14 VA: 0x9A6B14
			//public void Setup(int index, int fingerId, int lineNo) { }

			//// RVA: 0x9A6AE8 Offset: 0x9A6AE8 VA: 0x9A6AE8
			public void Reset()
			{
				requestedTimerReset = false;
				index = -1;
				fingerId = -1;
				lineNo = -1;
				lineNo_Begin = -1;
				timer = -1;
			}

			//// RVA: 0x9A4210 Offset: 0x9A4210 VA: 0x9A4210
			//public bool IsActive() { }

			//// RVA: 0x9A6B34 Offset: 0x9A6B34 VA: 0x9A6B34
			//public bool IsReleased() { }

			//// RVA: 0x9A6B4C Offset: 0x9A6B4C VA: 0x9A6B4C
			//public void OnReleased() { }

			//// RVA: 0x9A6B58 Offset: 0x9A6B58 VA: 0x9A6B58
			//public bool IsInSave(float limitSec) { }

			//// RVA: 0x9A6B74 Offset: 0x9A6B74 VA: 0x9A6B74
			//public void RequestTimerReset() { }

			//// RVA: 0x9A6B80 Offset: 0x9A6B80 VA: 0x9A6B80
			//public void TimerElapse(float deltaTime) { }

			//// RVA: 0x9A6BAC Offset: 0x9A6BAC VA: 0x9A6BAC
			//public bool UpdateLineNo(int lineNo) { }
		}


		private const int LongNoteSaveFrameDefault = 2;
		private int _longNoteSaveFrame = 2; // 0x30
		private float longNoteSaveSec = 0.03333334f; // 0x34
		private float swipeDistanceRate; // 0x38
		private List<int> touchLineNo; // 0x3C
		private InputSaver inputSaver; // 0x40
		private FingerInfo[] fingerInfoList; // 0x4C
		private int touchPriorityThreshold; // 0x50
		[SerializeField] // RVA: 0x68DCA8 Offset: 0x68DCA8 VA: 0x68DCA8
		private GameObject rectParent; // 0x54
		[SerializeField] // RVA: 0x68DCB8 Offset: 0x68DCB8 VA: 0x68DCB8
		private GameObject rectParentW; // 0x58
		private RectTransform[] touchPushRects; // 0x5C
		private RectTransform[] touchReleaseRects; // 0x60
		public RectTransform touchSkillRect; // 0x64
		[SerializeField] // RVA: 0x68DCC8 Offset: 0x68DCC8 VA: 0x68DCC8
		private List<Vector2> touchRectScreenPos; // 0x68

		public int longNoteSaveFrame { get; set; }
		[HideInInspector]
		public RNoteOwner refRNoteOwner { get; set; } // 0x44
		[HideInInspector]
		public RhythmGamePlayer refRhytmGamePlayer { get; set; } // 0x48
		public DelegateCheckInput delegateCheckInput { get; set; } // 0x6C

		//// RVA: 0x9A2A9C Offset: 0x9A2A9C VA: 0x9A2A9C
		//public int get_longNoteSaveFrame() { }

		//// RVA: 0x9A2AA4 Offset: 0x9A2AA4 VA: 0x9A2AA4
		//public void set_longNoteSaveFrame(int value) { }

		//[CompilerGeneratedAttribute] // RVA: 0x743DDC Offset: 0x743DDC VA: 0x743DDC
		//							 // RVA: 0x9A2AF4 Offset: 0x9A2AF4 VA: 0x9A2AF4
		//public RNoteOwner get_refRNoteOwner() { }

		//[CompilerGeneratedAttribute] // RVA: 0x743DEC Offset: 0x743DEC VA: 0x743DEC
		//							 // RVA: 0x9A2AFC Offset: 0x9A2AFC VA: 0x9A2AFC
		//public void set_refRNoteOwner(RNoteOwner value) { }

		//[CompilerGeneratedAttribute] // RVA: 0x743DFC Offset: 0x743DFC VA: 0x743DFC
		//							 // RVA: 0x9A2B04 Offset: 0x9A2B04 VA: 0x9A2B04
		//public RhythmGamePlayer get_refRhytmGamePlayer() { }

		//[CompilerGeneratedAttribute] // RVA: 0x743E0C Offset: 0x743E0C VA: 0x743E0C
		//							 // RVA: 0x9A2B0C Offset: 0x9A2B0C VA: 0x9A2B0C
		//public void set_refRhytmGamePlayer(RhythmGamePlayer value) { }

		//[CompilerGeneratedAttribute] // RVA: 0x743E1C Offset: 0x743E1C VA: 0x743E1C
		//							 // RVA: 0x9A2B14 Offset: 0x9A2B14 VA: 0x9A2B14
		//public RhythmGameInputPerformer.DelegateCheckInput get_delegateCheckInput() { }

		//[CompilerGeneratedAttribute] // RVA: 0x743E2C Offset: 0x743E2C VA: 0x743E2C
		//							 // RVA: 0x9A2B1C Offset: 0x9A2B1C VA: 0x9A2B1C
		//public void set_delegateCheckInput(RhythmGameInputPerformer.DelegateCheckInput value) { }

		//// RVA: 0x9A2B24 Offset: 0x9A2B24 VA: 0x9A2B24
		private void Start()
		{
			touchLineNo = new List<int>(InputManager.fingerCount);
			touchLineNo.Add(-1);
			touchLineNo.Add(-1);
			touchLineNo.Add(-1);
			touchLineNo.Add(-1);
			inputSaver = new InputSaver(longNoteSaveSec);
			inputSaver.onBeganTouch = BeganTouch;
			inputSaver.onEndedTouch = EndedTouch;
			inputSaver.onReleaseLine = ReleaseLine;
			inputSaver.onNextLine = NextLine;
			inputSaver.onSwipedTouch = SwipedTouch;
			inputSaver.onNeutralTouch = NeutralTouch;
			if(fingerInfoList == null)
			{
				fingerInfoList = new FingerInfo[InputManager.fingerCount];
				for(int i = 0; i < fingerInfoList.Length; i++)
				{
					fingerInfoList[i] = new FingerInfo();
				}
			}
			touchPushRects = new RectTransform[0];
			touchReleaseRects = new RectTransform[0];
		}

		//// RVA: 0x9A3398 Offset: 0x9A3398 VA: 0x9A3398
		//private void UpdateTouchRect(GameObject parent) { }

		//// RVA: 0x9A3754 Offset: 0x9A3754 VA: 0x9A3754 Slot: 13
		//public override void InitializeTouch() { }

		//// RVA: 0x9A38A4 Offset: 0x9A38A4 VA: 0x9A38A4
		public void InitializeGame(RhythmGamePlayer a_player, RNoteOwner a_rnote_owner, IRhythmGameHUD a_hud, Camera a_ui_camera)
		{
			refRNoteOwner = a_rnote_owner;
			refRhytmGamePlayer = a_player;
			RhythmGameHUD hud = a_hud as RhythmGameHUD;
			if(hud != null)
			{
				TodoLogger.Log(0, "RhythmGameInputPerformer InitializeGame");
			}
		}

		//// RVA: 0x9A3CAC Offset: 0x9A3CAC VA: 0x9A3CAC
		private void Update()
		{
			if (!isEnableTouch)
				return;
			TodoLogger.Log(0, "RhythmGameInputPerformer Update");
		}

		//// RVA: 0x9A3E2C Offset: 0x9A3E2C VA: 0x9A3E2C Slot: 4
		public override void BeginTouchSave(int lineNo)
		{
			TodoLogger.Log(0, "RhythmGameInputPerformer BeginTouchSave");
		}

		//// RVA: 0x9A4060 Offset: 0x9A4060 VA: 0x9A4060 Slot: 5
		public override void EndTouchSave(int lineNo, bool isCheckEndTouch = true)
		{
			inputSaver.SetLineSave(lineNo, false, isCheckEndTouch);
		}

		//// RVA: 0x9A40A4 Offset: 0x9A40A4 VA: 0x9A40A4
		//public bool CheckTouchFingerId(int finger, int lineNo) { }

		//// RVA: 0x9A3CBC Offset: 0x9A3CBC VA: 0x9A3CBC
		//private void CheckInput() { }

		//// RVA: 0x9A422C Offset: 0x9A422C VA: 0x9A422C
		//private void CheckInputFromTouchInfo(TouchInfoRecord tir, int fingerId) { }
	}
}
