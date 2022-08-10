using XeApp.Core;
using UnityEngine;

namespace XeApp.Game.RhythmGame
{
	public class RNoteCluster : PoolObject
	{
		protected RNoteObject[] noteObjects; // 0x14
		[SerializeField]
		private bool isBeganTouched_; // 0x1C
		[SerializeField]
		private int touchFingerId_; // 0x20

		// public RNoteClusterRenderer renderer { get; protected set; } // 0x18
		// public bool isBeganTouched { get; protected set; } 0xDA9224 0xDA922C
		// public int touchFingerId { get; protected set; } 0xDA9234 0xDA923C

		// // RVA: 0xDA9244 Offset: 0xDA9244 VA: 0xDA9244
		// public RNoteObject GetRNoteObject(int index) { }

		// // RVA: 0xDA928C Offset: 0xDA928C VA: 0xDA928C
		// public RNoteObject GetFirstRNoteObject() { }

		// // RVA: 0xDA92CC Offset: 0xDA92CC VA: 0xDA92CC
		// public RNoteObject GetLastRNoteObject() { }

		// // RVA: -1 Offset: -1
		// public bool MatchRendererType<T>() { }
		// /* GenericInstMethod :
		// |
		// |-RVA: 0x1A0DDF0 Offset: 0x1A0DDF0 VA: 0x1A0DDF0
		// |-RNoteCluster.MatchRendererType<object>
		// */

		// // RVA: -1 Offset: -1
		// public void Initialize<T>(RNoteObject[] objects) { }
		// /* GenericInstMethod :
		// |
		// |-RVA: 0x1AB49B8 Offset: 0x1AB49B8 VA: 0x1AB49B8
		// |-RNoteCluster.Initialize<object>
		// */

		// // RVA: 0xDA931C Offset: 0xDA931C VA: 0xDA931C
		// public void BeginTouch(int fingerId) { }

		// // RVA: 0xDA932C Offset: 0xDA932C VA: 0xDA932C
		// public bool CheckFree() { }

		// // RVA: 0xDA9418 Offset: 0xDA9418 VA: 0xDA9418 Slot: 11
		// public override void Free() { }

		// // RVA: 0xDA9460 Offset: 0xDA9460 VA: 0xDA9460
		// private void ProcessEventResult(RNoteClusterRenderer.EventResult result) { }

		// // RVA: 0xDA9478 Offset: 0xDA9478 VA: 0xDA9478
		// private void JudgedDelegate(RNoteObject noteObject, RhythmGameConsts.NoteResultEx a_result_ex, RhythmGameConsts.NoteJudgeType a_judge_type) { }

		// // RVA: 0xDA94F0 Offset: 0xDA94F0 VA: 0xDA94F0
		// private void BeyondDelegate(RNoteObject noteObject) { }

		// // RVA: 0xDA954C Offset: 0xDA954C VA: 0xDA954C
		// private void PassedDelegate(RNoteObject noteObject) { }

		// RVA: 0xDA95A8 Offset: 0xDA95A8 VA: 0xDA95A8 Slot: 5
		protected override void PausableAwake()
		{
			TodoLogger.Log(0, "TODO");
		}

		// RVA: 0xDA95AC Offset: 0xDA95AC VA: 0xDA95AC Slot: 6
		protected override void PausableStart()
		{
			TodoLogger.Log(0, "TODO");
		}

		// RVA: 0xDA95B0 Offset: 0xDA95B0 VA: 0xDA95B0 Slot: 7
		protected override void PausableUpdate()
		{
			TodoLogger.Log(0, "TODO");
		}

		// RVA: 0xDA95B4 Offset: 0xDA95B4 VA: 0xDA95B4 Slot: 8
		protected override void PausableInPause()
		{
			TodoLogger.Log(0, "TODO");
		}
	}
}
