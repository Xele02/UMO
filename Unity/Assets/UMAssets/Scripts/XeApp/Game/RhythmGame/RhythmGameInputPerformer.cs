using UnityEngine;
using System.Collections.Generic;
using XeSys;
using XeApp.Game.Common;

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
				if(info == null)
				{
					info = new Info[6];
					for(int i = 0; i < info.Length; i++)
					{
						info[i] = new Info();
					}
				}
				ResetJudgeLineInfo();
			}


			//// RVA: 0x9A6098 Offset: 0x9A6098 VA: 0x9A6098
			public void ResetJudgeLineInfo()
			{
				for(int i = 0; i < info.Length; i++)
				{
					info[i].m_time = System.Int32.MaxValue;
					info[i].m_hit = false;
				}
			}

			//// RVA: 0x9A5A24 Offset: 0x9A5A24 VA: 0x9A5A24
			public void SetJudgeLineInfo(int lineNo, int noteTime)
			{
				info[lineNo].m_hit = true;
				info[lineNo].m_time = noteTime;
			}

			//// RVA: 0x9A5AE0 Offset: 0x9A5AE0 VA: 0x9A5AE0
			public int JudgeLineCandidate(int a_note_msec, Vector2 a_touch_pos, List<Vector2> a_touch_rect_pos, int a_touch_priority_check)
			{
				int t = System.Int32.MaxValue;
				int found = -1;
				for(int i = 0; i < info.Length; i++)
				{
					if(info[i].m_time < t)
					{
						t = info[i].m_time;
						found = i;
					}
				}
				t = Mathf.Abs(a_note_msec - t);
				if (found != -1 && t <= a_touch_priority_check)
					return found;
				float dist = float.MaxValue;
				for(int i = 0; i < a_touch_rect_pos.Count; i++)
				{
					if(info[i].m_hit)
					{
						float d = (a_touch_pos - a_touch_rect_pos[i]).sqrMagnitude;
						if (d < dist)
						{
							dist = d;
							found = i;
						}
					}
				}
				return found;
			}
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
			public void OnTouched(int fingerId, int lineNo)
			{
				int i = 0;
				for (; i < m_finger.Count; i++)
				{
					if (m_finger[i].lineNo < 0)
						break;
					if(m_finger[i].lineNo > -1 && m_finger[i].fingerId < 0)
					{
						if(m_finger[i].lineNo == lineNo)
						{
							break;
						}
					}
				}
				if (i == m_finger.Count)
					return;
				if (m_finger[i] == null)
					return;
				m_finger[i].Setup(i, lineNo, fingerId);
				onBeganTouch(lineNo, i);

			}

			//// RVA: 0x9A6194 Offset: 0x9A6194 VA: 0x9A6194
			public void OnMoved(int fingerId, bool isContain)
			{
				if(isContain)
				{
					FingerData data = SearchFinger(fingerId);
					if (data != null)
						data.RequestTimerReset();
				}
				else
				{
					if(!IsSave(fingerId))
					{
						FingerData data = SearchFinger(fingerId);
						onReleaseLine(data.lineNo, data.lineNo_Begin, data.index, false);
					}
				}
			}

			//// RVA: 0x9A6170 Offset: 0x9A6170 VA: 0x9A6170
			public void OnReleased(int fingerId)
			{
				FingerData info = SearchFinger(fingerId);
				if (info != null)
				{
					info.OnReleased();
				}
			}

			//// RVA: 0x9A6268 Offset: 0x9A6268 VA: 0x9A6268
			public void OnSwiped(int lineNo, int fingerId, bool isRight, bool isDown, bool isLeft, bool isUp)
			{
				FingerData info = SearchFinger(fingerId);
				if(info != null)
				{
					onSwipedTouch(lineNo, info.index, isRight, isDown, isLeft, isUp);
				}
			}

			//// RVA: 0x9A62DC Offset: 0x9A62DC VA: 0x9A62DC
			public void OnNeutral(int lineNo, int fingerId)
			{
				FingerData info = SearchFinger(fingerId);
				if (info == null)
					return;
				onNeutralTouch(lineNo, info.index);
			}

			//// RVA: 0x9A7F48 Offset: 0x9A7F48 VA: 0x9A7F48
			//public int GetFingerId(int fingerId) { }

			//// RVA: 0x9A7F64 Offset: 0x9A7F64 VA: 0x9A7F64
			//public int GetLineNo(int fingerId) { }

			//// RVA: 0x9A601C Offset: 0x9A601C VA: 0x9A601C
			//public bool UpdateLineNo(int fingerId, int lineNo) { }

			//// RVA: 0x9A8400 Offset: 0x9A8400 VA: 0x9A8400
			public bool IsActive(int fingerId)
			{
				FingerData data = SearchFinger(fingerId);
				if (data != null)
				{
					return data.lineNo > -1;
				}
				return false;
			}

			//// RVA: 0x9A70B0 Offset: 0x9A70B0 VA: 0x9A70B0
			private bool IsSave(int fingerId)
			{
				FingerData data = SearchFinger(fingerId);
				if(data != null)
				{
					if (data.timer < m_limitSec)
						return m_saveForLine[data.lineNo];
				}
				return false;
			}

			//// RVA: 0x9A842C Offset: 0x9A842C VA: 0x9A842C
			//private void SaveFinish(int fingerId) { }

			//// RVA: 0x9A7094 Offset: 0x9A7094 VA: 0x9A7094
			//private void TimerReset(int fingerId) { }

			//// RVA: 0x9A4B2C Offset: 0x9A4B2C VA: 0x9A4B2C
			public void TimerUpdate()
			{
				for(int i = 0; i < m_finger.Count; i++)
				{
					if(m_finger[i].lineNo > -1)
					{
						if(m_finger[i].fingerId < 0)
						{
							if(m_finger[i].timer < m_limitSec)
							{
								if(m_saveForLine[m_finger[i].lineNo])
								{
									onNeutralTouch(m_finger[i].lineNo, m_finger[i].index);
									m_finger[i].TimerElapse(TimeWrapper.deltaTime);
									continue;
								}
							}
							onEndedTouch(m_finger[i].lineNo, m_finger[i].lineNo_Begin, m_finger[i].index, false);
							m_finger[i].Reset();
						}
						else
						{
							m_finger[i].TimerElapse(TimeWrapper.deltaTime);
						}
					}
				}
			}

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
			public FingerData SearchFinger(int fingerId)
			{
				for(int i = 0; i < m_finger.Count; i++)
				{
					if (m_finger[i].fingerId == fingerId)
						return m_finger[i];
				}
				return null;
			}
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
			public void Setup(int index, int fingerId, int lineNo)
			{
				this.index = index;
				this.fingerId = fingerId;
				this.lineNo = lineNo;
				lineNo_Begin = lineNo;
				timer = 0;
				requestedTimerReset = false;
			}

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
			public void OnReleased()
			{
				fingerId = -1;
			}

			//// RVA: 0x9A6B58 Offset: 0x9A6B58 VA: 0x9A6B58
			//public bool IsInSave(float limitSec) { }

			//// RVA: 0x9A6B74 Offset: 0x9A6B74 VA: 0x9A6B74
			public void RequestTimerReset()
			{
				requestedTimerReset = true;
			}

			//// RVA: 0x9A6B80 Offset: 0x9A6B80 VA: 0x9A6B80
			public void TimerElapse(float deltaTime)
			{
				if (!requestedTimerReset)
					timer += deltaTime;
				else
				{
					timer = 0;
					requestedTimerReset = false;
				}
			}

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

		//public int longNoteSaveFrame { get; set; } 0x9A2A9C 0x9A2AA4
		[HideInInspector]
		public RNoteOwner refRNoteOwner { get; set; } // 0x44
		[HideInInspector]
		public RhythmGamePlayer refRhytmGamePlayer { get; set; } // 0x48
		public DelegateCheckInput delegateCheckInput { get; set; } // 0x6C

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
		private void UpdateTouchRect(GameObject parent)
		{
			Transform t = parent.transform.Find("PushRect");
			Transform t2 = parent.transform.Find("ReleaseRect");
			touchPushRects = new RectTransform[t.childCount];
			touchReleaseRects = new RectTransform[t2.childCount];
			for (int i = 0; i < t.childCount; i++)
			{
				touchPushRects[i] = t.Find("HitRect" + (i + 1)).GetComponent<RectTransform>();
				touchReleaseRects[i] = t2.Find("HitRect" + (i + 1)).GetComponent<RectTransform>();
			}
			#region UMO
			InputManager.Instance.InitializeLineCoords(touchPushRects);
			#endregion
		}

		//// RVA: 0x9A3754 Offset: 0x9A3754 VA: 0x9A3754 Slot: 13
		public override void InitializeTouch()
		{
			UpdateTouchRect(RhythmGameConsts.IsWideLine() ? rectParentW : rectParent);
			swipeDistanceRate = 0.003f;
			touchPriorityThreshold = IMMAOANGPNK.HHCJCDFCLOB.NKEBMCIMJND_Database.HNMMJINNHII_Game.LPJLEHAJADA("note_touch_priority_change_offset", 180);
		}

		//// RVA: 0x9A38A4 Offset: 0x9A38A4 VA: 0x9A38A4
		public void InitializeGame(RhythmGamePlayer a_player, RNoteOwner a_rnote_owner, IRhythmGameHUD a_hud, Camera a_ui_camera)
		{
			refRNoteOwner = a_rnote_owner;
			refRhytmGamePlayer = a_player;
			RhythmGameHUD hud = a_hud as RhythmGameHUD;
			if(hud != null)
			{
				string t_str_note_line = RhythmGameConsts.IsWideLine() ? "GameNoteLinesW" : "GameNoteLines";
				Transform t = System.Array.Find(hud.transform.parent.GetComponentsInChildren<Transform>(), (Transform _) =>
				{
					//0x9A69D0
					return _.name == t_str_note_line;
				});
				touchRectScreenPos = new List<Vector2>();
				for(int i = 0; i < t.childCount; i++)
				{
					touchRectScreenPos.Add(a_ui_camera.WorldToScreenPoint(t.GetChild(i).transform.position));
				}
			}
		}

		//// RVA: 0x9A3CAC Offset: 0x9A3CAC VA: 0x9A3CAC
		private void Update()
		{
			if (!isEnableTouch)
				return;
			CheckInput();
		}

		//// RVA: 0x9A3E2C Offset: 0x9A3E2C VA: 0x9A3E2C Slot: 4
		public override void BeginTouchSave(int lineNo)
		{
			inputSaver.SetLineSave(lineNo, true, true);
		}

		//// RVA: 0x9A4060 Offset: 0x9A4060 VA: 0x9A4060 Slot: 5
		public override void EndTouchSave(int lineNo, bool isCheckEndTouch = true)
		{
			inputSaver.SetLineSave(lineNo, false, isCheckEndTouch);
		}

		//// RVA: 0x9A40A4 Offset: 0x9A40A4 VA: 0x9A40A4
		//public bool CheckTouchFingerId(int finger, int lineNo) { }

		//// RVA: 0x9A3CBC Offset: 0x9A3CBC VA: 0x9A3CBC
		private void CheckInput()
		{
			for(int i = 0; i < InputManager.fingerCount; i++)
			{
				TouchInfoRecord record = InputManager.Instance.GetTouchInfoRecord(i);
				if(record != null)
				{
					if(!record.currentInfo.isIllegal)
					{
						CheckInputFromTouchInfo(record, i);
					}
				}
			}
			inputSaver.TimerUpdate();
			if (delegateCheckInput != null)
				delegateCheckInput(inputSaver);
		}

		//// RVA: 0x9A422C Offset: 0x9A422C VA: 0x9A422C
		private void CheckInputFromTouchInfo(TouchInfoRecord tir, int fingerId)
		{
			bool b = false;
			int line = -1;
			TouchInfo info = tir.currentInfo;
			for(int i = 0; i < touchPushRects.Length; i++)
			{
				if(isActiveLineCallback(i))
				{
					if(RectTransformUtility.RectangleContainsScreenPoint(touchPushRects[i], info.nativePosition))
					{
						if(info.isBegan || info.isMoved)
						{
							int noteTime = System.Int32.MaxValue;
							for(int idx = refRNoteOwner.checkStartNotesIndex; idx < refRNoteOwner.GetNoteListNum(); idx++)
							{
								if(refRNoteOwner.GetNote(idx).GetLineNo() == i)
								{
									if(refRNoteOwner.GetNote(idx).result == RhythmGameConsts.NoteResult.None)
									{
										noteTime = refRNoteOwner.GetNote(idx).noteInfo.time;
										break;
									}
								}
							}
							fingerInfoList[fingerId].SetJudgeLineInfo(i, noteTime);
						}
						b = true;
						if (line < 0)
							line = i;
					}
				}
			}
			if(b)
			{
				int a = fingerInfoList[fingerId].JudgeLineCandidate(refRhytmGamePlayer.notesMillisec, info.nativePosition, touchRectScreenPos, touchPriorityThreshold);
				if(info.isBegan)
				{
					if (a > 0)
						line = a;
					inputSaver.OnTouched(fingerId, line);
				}
			}
			fingerInfoList[fingerId].ResetJudgeLineInfo();
			FingerData fingerData = inputSaver.SearchFinger(fingerId);
			if(info.isEnded)
			{
				if (fingerData != null)
					fingerData.OnReleased();
			}
			else
			{
				if(info.isMoved && fingerData != null)
				{
					if(fingerData.lineNo_Begin > -1)
					{
						if(isActiveLineCallback.Invoke(fingerData.lineNo_Begin))
						{
							inputSaver.OnMoved(fingerId, RectTransformUtility.RectangleContainsScreenPoint(touchReleaseRects[fingerData.lineNo_Begin], info.nativePosition));
						}
					}
					if(fingerData.lineNo > -1)
					{
						int flick = tir.GetFlickAngleType(12, 1, swipeDistanceRate, false);
						if (flick < 0)
						{
							inputSaver.OnNeutral(fingerData.lineNo, fingerId);
						}
						else
						{
							inputSaver.OnSwiped(fingerData.lineNo, fingerId, flick <= 1 || flick >= 10, flick >= 1 && flick <= 4, flick >= 4 && flick <= 7, flick >= 7 && flick <= 10);
						}
					}
				}
				if(RectTransformUtility.RectangleContainsScreenPoint(touchSkillRect, info.nativePosition) && info.isBegan)
				{
					BeganSkillTouch(TouchSwipeDirection.None);
				}
			}
		}
	}
}
