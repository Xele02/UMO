using UnityEngine;
using XeSys;

namespace XeApp.Game.RhythmGame
{
	public class RhythmGamePerformer : MonoBehaviour
	{
		public delegate bool IsActiveLineCallback(int lineNo);
		public delegate void BeganTouchLineCallback(int lineNo, int fingerId);
		public delegate void EndedTouchLineCallback(int lineNo, int lineNo_Begin, int fingerId, bool forceMiss);
		public delegate void ReleaseLineCallback(int lineNo, int lineNo_Begin, int fingerId, bool forceMiss);
		public delegate void NextLineCallback(int lineNo0, int lineNo1, int fingerId, bool forceMiss);
		public delegate void SwipedTouchLineCallback(int lineNo, int fingerId, bool isRight, bool isDown, bool isLeft, bool isUp);
		public delegate void NeutralTouchLineCallback(int lineNo, int fingerId);
		public delegate void BeganTouchSkillCallback(TouchSwipeDirection swipeDir);

		public bool isEnableTouch = true; // 0xC
		protected IsActiveLineCallback isActiveLineCallback = (int lineNo) => { return true; }; // 0x10
		private BeganTouchLineCallback beganTouchEvent = (int lineNo, int fingerId) => { return; }; // 0x14
		private EndedTouchLineCallback endedTouchEvent = (int lineNo, int lineNo_Begin, int fingerId, bool forceMiss) => { return; }; // 0x18
		private ReleaseLineCallback releaseLineEvent = (int lineNo, int lineNo_Begin, int fingerId, bool forceMiss) => { return; }; // 0x1C
		private NextLineCallback nextLineEvent = (int lineNo0, int lineNo1, int fingerId, bool forceMiss) => { return; }; // 0x20
		private SwipedTouchLineCallback swipedTouchEvent = (int lineNo, int fingerId, bool isRight, bool isDown, bool isLeft, bool isUp) => { return; }; // 0x24
		private NeutralTouchLineCallback neutralTouchEvent = (int lineNo, int fingerId) => { return; }; // 0x28
		private BeganTouchSkillCallback skillTouchEvent = (TouchSwipeDirection swipeDir) => { return; }; // 0x2C

		//// RVA: 0x9ADB00 Offset: 0x9ADB00 VA: 0x9ADB00
		public void AddTouchEvents(RhythmGamePerformer.BeganTouchLineCallback beganTouchEvent, RhythmGamePerformer.EndedTouchLineCallback endedTouchEvent, RhythmGamePerformer.ReleaseLineCallback releaseLineEvent, RhythmGamePerformer.NextLineCallback nextLineEvent, RhythmGamePerformer.SwipedTouchLineCallback swipedTouchEvent, RhythmGamePerformer.NeutralTouchLineCallback neutralTouchEvent, RhythmGamePerformer.BeganTouchSkillCallback skillTouchEvent)
		{
			this.beganTouchEvent += beganTouchEvent;
			this.endedTouchEvent += endedTouchEvent;
			this.releaseLineEvent += releaseLineEvent;
			this.nextLineEvent += nextLineEvent;
			this.swipedTouchEvent += swipedTouchEvent;
			this.neutralTouchEvent += neutralTouchEvent;
			this.skillTouchEvent += skillTouchEvent;
		}

		//// RVA: 0x9ADB64 Offset: 0x9ADB64 VA: 0x9ADB64
		//public void RemoveTouchEvents(RhythmGamePerformer.BeganTouchLineCallback beganTouchEvent, RhythmGamePerformer.EndedTouchLineCallback endedTouchEvent, RhythmGamePerformer.ReleaseLineCallback releaseLineEvent, RhythmGamePerformer.NextLineCallback nextLineEvent, RhythmGamePerformer.SwipedTouchLineCallback swipedTouchEvent, RhythmGamePerformer.NeutralTouchLineCallback neutralTouchEvent, RhythmGamePerformer.BeganTouchSkillCallback skillTouchEvent) { }

		//// RVA: 0x9ADBC8 Offset: 0x9ADBC8 VA: 0x9ADBC8
		public void RemoveAllTouchEvents()
		{
			TodoLogger.Log(0, "GamePerformer RemoveAllTouchEvents");
		}

		//// RVA: 0x9AE1B4 Offset: 0x9AE1B4 VA: 0x9AE1B4
		public void SetActiveLineCallback(RhythmGamePerformer.IsActiveLineCallback callback)
		{
			isActiveLineCallback = callback;
		}

		//// RVA: 0x9AE1BC Offset: 0x9AE1BC VA: 0x9AE1BC Slot: 4
		public virtual void BeginTouchSave(int lineNo)
		{
			return;
		}

		//// RVA: 0x9AE1C0 Offset: 0x9AE1C0 VA: 0x9AE1C0 Slot: 5
		public virtual void EndTouchSave(int lineNo, bool isCheckEndTouch = true)
		{
			return;
		}

		//// RVA: 0x9AE1C4 Offset: 0x9AE1C4 VA: 0x9AE1C4 Slot: 6
		protected virtual void BeganTouch(int lineNo, int fingerId)
		{
			beganTouchEvent(lineNo, fingerId);
		}

		//// RVA: 0x9AE1FC Offset: 0x9AE1FC VA: 0x9AE1FC Slot: 7
		protected virtual void EndedTouch(int lineNo, int lineNo_Begin, int fingerId, bool forceMiss)
		{
			endedTouchEvent(lineNo, lineNo_Begin, fingerId, forceMiss);
		}

		//// RVA: 0x9AE24C Offset: 0x9AE24C VA: 0x9AE24C Slot: 8
		protected virtual void ReleaseLine(int lineNo, int lineNo_Begin, int fingerId, bool forceMiss)
		{
			releaseLineEvent(lineNo, lineNo_Begin, fingerId, forceMiss);
		}

		//// RVA: 0x9AE29C Offset: 0x9AE29C VA: 0x9AE29C Slot: 9
		protected virtual void NextLine(int lineNo0, int lineNo1, int fingerId, bool forceMiss)
		{
			nextLineEvent(lineNo0, lineNo1, fingerId, forceMiss);
		}

		//// RVA: 0x9AE2EC Offset: 0x9AE2EC VA: 0x9AE2EC Slot: 10
		protected virtual void SwipedTouch(int lineNo, int fingerId, bool isRight, bool isDown, bool isLeft, bool isUp)
		{
			swipedTouchEvent(lineNo, fingerId, isRight, isDown, isLeft, isUp);
		}

		//// RVA: 0x9AE34C Offset: 0x9AE34C VA: 0x9AE34C Slot: 11
		protected virtual void NeutralTouch(int lineNo, int fingerId)
		{
			neutralTouchEvent(lineNo, fingerId);
		}

		//// RVA: 0x9AE384 Offset: 0x9AE384 VA: 0x9AE384 Slot: 12
		protected virtual void BeganSkillTouch(TouchSwipeDirection swipeDir)
		{
			skillTouchEvent(swipeDir);
		}

		//// RVA: 0x9AE818 Offset: 0x9AE818 VA: 0x9AE818 Slot: 13
		public virtual void InitializeTouch()
		{
			return;
		}
	}
}
