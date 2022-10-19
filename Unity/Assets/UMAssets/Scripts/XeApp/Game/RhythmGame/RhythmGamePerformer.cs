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

		//[CompilerGeneratedAttribute] // RVA: 0x743FDC Offset: 0x743FDC VA: 0x743FDC
		//							 // RVA: 0x9ACC58 Offset: 0x9ACC58 VA: 0x9ACC58
		//private void add_beganTouchEvent(RhythmGamePerformer.BeganTouchLineCallback value) { }

		//[CompilerGeneratedAttribute] // RVA: 0x743FEC Offset: 0x743FEC VA: 0x743FEC
		//							 // RVA: 0x9ACD64 Offset: 0x9ACD64 VA: 0x9ACD64
		//private void remove_beganTouchEvent(RhythmGamePerformer.BeganTouchLineCallback value) { }

		//[CompilerGeneratedAttribute] // RVA: 0x743FFC Offset: 0x743FFC VA: 0x743FFC
		//							 // RVA: 0x9ACE70 Offset: 0x9ACE70 VA: 0x9ACE70
		//private void add_endedTouchEvent(RhythmGamePerformer.EndedTouchLineCallback value) { }

		//[CompilerGeneratedAttribute] // RVA: 0x74400C Offset: 0x74400C VA: 0x74400C
		//							 // RVA: 0x9ACF7C Offset: 0x9ACF7C VA: 0x9ACF7C
		//private void remove_endedTouchEvent(RhythmGamePerformer.EndedTouchLineCallback value) { }

		//[CompilerGeneratedAttribute] // RVA: 0x74401C Offset: 0x74401C VA: 0x74401C
		//							 // RVA: 0x9AD088 Offset: 0x9AD088 VA: 0x9AD088
		//private void add_releaseLineEvent(RhythmGamePerformer.ReleaseLineCallback value) { }

		//[CompilerGeneratedAttribute] // RVA: 0x74402C Offset: 0x74402C VA: 0x74402C
		//							 // RVA: 0x9AD194 Offset: 0x9AD194 VA: 0x9AD194
		//private void remove_releaseLineEvent(RhythmGamePerformer.ReleaseLineCallback value) { }

		//[CompilerGeneratedAttribute] // RVA: 0x74403C Offset: 0x74403C VA: 0x74403C
		//							 // RVA: 0x9AD2A0 Offset: 0x9AD2A0 VA: 0x9AD2A0
		//private void add_nextLineEvent(RhythmGamePerformer.NextLineCallback value) { }

		//[CompilerGeneratedAttribute] // RVA: 0x74404C Offset: 0x74404C VA: 0x74404C
		//							 // RVA: 0x9AD3AC Offset: 0x9AD3AC VA: 0x9AD3AC
		//private void remove_nextLineEvent(RhythmGamePerformer.NextLineCallback value) { }

		//[CompilerGeneratedAttribute] // RVA: 0x74405C Offset: 0x74405C VA: 0x74405C
		//							 // RVA: 0x9AD4B8 Offset: 0x9AD4B8 VA: 0x9AD4B8
		//private void add_swipedTouchEvent(RhythmGamePerformer.SwipedTouchLineCallback value) { }

		//[CompilerGeneratedAttribute] // RVA: 0x74406C Offset: 0x74406C VA: 0x74406C
		//							 // RVA: 0x9AD5C4 Offset: 0x9AD5C4 VA: 0x9AD5C4
		//private void remove_swipedTouchEvent(RhythmGamePerformer.SwipedTouchLineCallback value) { }

		//[CompilerGeneratedAttribute] // RVA: 0x74407C Offset: 0x74407C VA: 0x74407C
		//							 // RVA: 0x9AD6D0 Offset: 0x9AD6D0 VA: 0x9AD6D0
		//private void add_neutralTouchEvent(RhythmGamePerformer.NeutralTouchLineCallback value) { }

		//[CompilerGeneratedAttribute] // RVA: 0x74408C Offset: 0x74408C VA: 0x74408C
		//							 // RVA: 0x9AD7DC Offset: 0x9AD7DC VA: 0x9AD7DC
		//private void remove_neutralTouchEvent(RhythmGamePerformer.NeutralTouchLineCallback value) { }

		//[CompilerGeneratedAttribute] // RVA: 0x74409C Offset: 0x74409C VA: 0x74409C
		//							 // RVA: 0x9AD8E8 Offset: 0x9AD8E8 VA: 0x9AD8E8
		//private void add_skillTouchEvent(RhythmGamePerformer.BeganTouchSkillCallback value) { }

		//[CompilerGeneratedAttribute] // RVA: 0x7440AC Offset: 0x7440AC VA: 0x7440AC
		//							 // RVA: 0x9AD9F4 Offset: 0x9AD9F4 VA: 0x9AD9F4
		//private void remove_skillTouchEvent(RhythmGamePerformer.BeganTouchSkillCallback value) { }

		//// RVA: 0x9ADB00 Offset: 0x9ADB00 VA: 0x9ADB00
		public void AddTouchEvents(RhythmGamePerformer.BeganTouchLineCallback beganTouchEvent, RhythmGamePerformer.EndedTouchLineCallback endedTouchEvent, RhythmGamePerformer.ReleaseLineCallback releaseLineEvent, RhythmGamePerformer.NextLineCallback nextLineEvent, RhythmGamePerformer.SwipedTouchLineCallback swipedTouchEvent, RhythmGamePerformer.NeutralTouchLineCallback neutralTouchEvent, RhythmGamePerformer.BeganTouchSkillCallback skillTouchEvent)
		{
			TodoLogger.Log(0, "GamePerformer AddTouchEvents");
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
			TodoLogger.Log(0, "GamePerformer SetActiveLineCallback");
		}

		//// RVA: 0x9AE1BC Offset: 0x9AE1BC VA: 0x9AE1BC Slot: 4
		public virtual void BeginTouchSave(int lineNo)
		{
			TodoLogger.Log(0, "GamePerformer BeginTouchSave");
		}

		//// RVA: 0x9AE1C0 Offset: 0x9AE1C0 VA: 0x9AE1C0 Slot: 5
		public virtual void EndTouchSave(int lineNo, bool isCheckEndTouch = true)
		{
			TodoLogger.Log(0, "GamePerformer EndTouchSave");
		}

		//// RVA: 0x9AE1C4 Offset: 0x9AE1C4 VA: 0x9AE1C4 Slot: 6
		//protected virtual void BeganTouch(int lineNo, int fingerId) { }

		//// RVA: 0x9AE1FC Offset: 0x9AE1FC VA: 0x9AE1FC Slot: 7
		//protected virtual void EndedTouch(int lineNo, int lineNo_Begin, int fingerId, bool forceMiss) { }

		//// RVA: 0x9AE24C Offset: 0x9AE24C VA: 0x9AE24C Slot: 8
		//protected virtual void ReleaseLine(int lineNo, int lineNo_Begin, int fingerId, bool forceMiss) { }

		//// RVA: 0x9AE29C Offset: 0x9AE29C VA: 0x9AE29C Slot: 9
		//protected virtual void NextLine(int lineNo0, int lineNo1, int fingerId, bool forceMiss) { }

		//// RVA: 0x9AE2EC Offset: 0x9AE2EC VA: 0x9AE2EC Slot: 10
		//protected virtual void SwipedTouch(int lineNo, int fingerId, bool isRight, bool isDown, bool isLeft, bool isUp) { }

		//// RVA: 0x9AE34C Offset: 0x9AE34C VA: 0x9AE34C Slot: 11
		//protected virtual void NeutralTouch(int lineNo, int fingerId) { }

		//// RVA: 0x9AE384 Offset: 0x9AE384 VA: 0x9AE384 Slot: 12
		//protected virtual void BeganSkillTouch(TouchSwipeDirection swipeDir) { }

		//// RVA: 0x9AE818 Offset: 0x9AE818 VA: 0x9AE818 Slot: 13
		public virtual void InitializeTouch()
		{
			TodoLogger.Log(0, "GamePerformer InitializeTouch");
		}
	}
}
