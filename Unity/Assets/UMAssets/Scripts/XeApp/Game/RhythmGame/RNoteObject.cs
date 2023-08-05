using XeApp.Core;
using UnityEngine;
using XeApp.Game.Common;
using System;
using System.Collections.Generic;

namespace XeApp.Game.RhythmGame
{
	[RequireComponent(typeof(Animator))] // RVA: 0x650CB8 Offset: 0x650CB8 VA: 0x650CB8
	public class RNoteObject : PoolObject
	{
		public delegate void DelegateOverrideNoteJudged(RNoteObject noteObject, ref RhythmGameConsts.NoteResultEx result);
		public delegate void NoteJudgedDelegate(RNoteObject noteObject, RhythmGameConsts.NoteResultEx result, RhythmGameConsts.NoteJudgeType type);
		public delegate void NoteBeyondDelegate(RNoteObject noteObject);
		public delegate void NotePassedDelegate(RNoteObject noteObject);

		[SerializeField]
		private RNote rnote; // 0x14
		private RhythmGameConsts.NoteResultEx m_note_result_ex = new RhythmGameConsts.NoteResultEx(); // 0x24
		private DelegateOverrideNoteJudged delegateOverrideNoteJudgeList; // 0x28
		private List<NoteJudgedDelegate> judgedEventList = new List<NoteJudgedDelegate>(); // 0x2C
		private List<NoteBeyondDelegate> beyondEventList = new List<NoteBeyondDelegate>(); // 0x30
		private List<NotePassedDelegate> passedEventList = new List<NotePassedDelegate>(); // 0x34
		public Func<RhythmGameConsts.NoteResult> funcForceOverwriteNoteResult; // 0x38

		public RNote rNote { get { return rnote; } private set { rnote = value;  } } //0xDAB8FC 0xDADE54
		public RNotePositionAnimator positionAnimator { get; private set; } // 0x18
		public Transform judgePointTransform { get; private set; } // 0x1C
		public bool isInScreen { get; private set; } // 0x20

		// RVA: 0xDADE84 Offset: 0xDADE84 VA: 0xDADE84
		public void Awake()
		{
			positionAnimator = new RNotePositionAnimator(GetComponent<Animator>());
		}

		// RVA: 0xDADF34 Offset: 0xDADF34 VA: 0xDADF34
		public void Initialize(RNote rNote, Transform judgePointTransform, bool isInScreen)
		{
			gameObject.SetActive(true);
			this.judgePointTransform = judgePointTransform;
			rnote = rNote;
			this.isInScreen = isInScreen;
			positionAnimator.Initialize(rNote);
			delegateOverrideNoteJudgeList = null;
			judgedEventList.Clear();
			beyondEventList.Clear();
			passedEventList.Clear();
		}

		// RVA: 0xDAE07C Offset: 0xDAE07C VA: 0xDAE07C
		public void Update()
		{
			positionAnimator.UpdateTransform();
			if(positionAnimator.IsBeyondJudgePoint())
			{
				Beyond();
				if(funcForceOverwriteNoteResult != null)
					Judged(funcForceOverwriteNoteResult(), RhythmGameConsts.NoteJudgeType.Normal);
			}
			if(isInScreen)
			{
				if(rnote.passingStatus != RNote.PassingStatus.Before && rnote.passingStatus != RNote.PassingStatus.After)
				{
					return;
				}
				Judged(RhythmGameConsts.NoteResult.Miss, RhythmGameConsts.NoteJudgeType.Normal);
			}
		}

		// // RVA: 0xDAE498 Offset: 0xDAE498 VA: 0xDAE498
		public void SetDelegateOverrideNoteJudge(RNoteObject.DelegateOverrideNoteJudged a_delegate)
		{
			delegateOverrideNoteJudgeList = a_delegate;
		}

		// // RVA: 0xDAB518 Offset: 0xDAB518 VA: 0xDAB518
		public void AddJudgedEvent(RNoteObject.NoteJudgedDelegate noteDelegate)
		{
			judgedEventList.Add(noteDelegate);
		}

		// // RVA: 0xDAB5AC Offset: 0xDAB5AC VA: 0xDAB5AC
		public void AddBeyondEvent(RNoteObject.NoteBeyondDelegate noteDelegate)
		{
			beyondEventList.Add(noteDelegate);
		}

		// // RVA: 0xDAB640 Offset: 0xDAB640 VA: 0xDAB640
		public void AddPassedEvent(RNoteObject.NotePassedDelegate noteDelegate)
		{
			passedEventList.Add(noteDelegate);
		}

		// // RVA: 0xDAE4A0 Offset: 0xDAE4A0 VA: 0xDAE4A0
		public void InScreen()
		{
			isInScreen = true;
		}

		// // RVA: 0xDA93DC Offset: 0xDA93DC VA: 0xDA93DC
		public bool IsJudged()
		{
			return rnote.result != RhythmGameConsts.NoteResult.None;
		}

		// // RVA: 0xDAC4EC Offset: 0xDAC4EC VA: 0xDAC4EC
		public bool Judged(RhythmGameConsts.NoteResult result, RhythmGameConsts.NoteJudgeType judgetype = 0)
		{
			if(!IsJudged())
			{
				m_note_result_ex.Init(result);
				if (delegateOverrideNoteJudgeList != null)
					delegateOverrideNoteJudgeList(this, ref m_note_result_ex);
				rNote.Judged(m_note_result_ex);
				for(int i = 0; i < judgedEventList.Count; i++)
				{
					if(judgedEventList[i] != null)
					{
						judgedEventList[i](this, m_note_result_ex, judgetype);
					}
				}
				if(rNote.noteInfo.isSlide)
				{
					if(result == RhythmGameConsts.NoteResult.Miss && rnote.noteInfo.longTouch == MusicScoreData.TouchState.Continue)
					{
						if(rnote.passingStatus == RNote.PassingStatus.Alive)
							return true;
					}
				}
				judgedEventList.Clear();
				gameObject.SetActive(false);
				return true;
			}
			return false;
		}

		// // RVA: 0xDAE358 Offset: 0xDAE358 VA: 0xDAE358
		private void Beyond()
		{
			for(int i = 0; i < beyondEventList.Count; i++)
			{
				if(beyondEventList[i] != null)
					beyondEventList[i](this);
			}
			beyondEventList.Clear();
		}

		// // RVA: 0xDAFD58 Offset: 0xDAFD58 VA: 0xDAFD58
		public void Passed()
		{
			for(int i = 0; i < passedEventList.Count; i++)
			{
				if(passedEventList[i] != null)
					passedEventList[i](this);
			}
			passedEventList.Clear();
		}

		// // RVA: 0xDB06B8 Offset: 0xDB06B8 VA: 0xDB06B8 Slot: 11
		public override void Free()
		{
			base.Free();
			gameObject.SetActive(false);
		}

		// // RVA: 0xDAE490 Offset: 0xDAE490 VA: 0xDAE490
		// public RhythmGameConsts.NoteResult OverwriteCheatNoteResult(RhythmGameConsts.NoteResult result) { }

		// RVA: 0xDB0700 Offset: 0xDB0700 VA: 0xDB0700 Slot: 5
		protected override void PausableAwake()
		{
			return;
		}

		// RVA: 0xDB0704 Offset: 0xDB0704 VA: 0xDB0704 Slot: 6
		protected override void PausableStart()
		{
			return;
		}

		// RVA: 0xDB0708 Offset: 0xDB0708 VA: 0xDB0708 Slot: 7
		protected override void PausableUpdate()
		{
			return;
		}

		// RVA: 0xDB070C Offset: 0xDB070C VA: 0xDB070C Slot: 8
		protected override void PausableInPause()
		{
			return;
		}
	}
}
