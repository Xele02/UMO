using XeApp.Core;
using UnityEngine;
using System.Collections.Generic;

namespace XeApp.Game.RhythmGame
{
	public class RNoteSync : PoolObject
	{
		// protected static readonly float width; // 0x0
		// protected static readonly float offset_z; // 0x4
		// protected static readonly int quad_count; // 0x8
		// protected static readonly int vertex_count; // 0xC
		private List<Vector2> uvListU; // 0x14
		private List<Vector2> uvListV; // 0x18
		private Renderer renderer; // 0x1C
		private Mesh mesh; // 0x20
		public Transform firstTransform; // 0x24
		public Transform lastTransform; // 0x28
		protected RNoteObject[] noteObjects; // 0x2C
		public RNoteObject firstRNoteObject; // 0x30
		public RNoteObject lastRNoteObject; // 0x34
		private Vector3[] v; // 0x38
		private Vector2[] uv; // 0x3C
		// private static int[] s_tri; // 0x10

		// // RVA: 0xDC06E4 Offset: 0xDC06E4 VA: 0xDC06E4 Slot: 12
		// public override void Create() { }

		// // RVA: 0xDBD1E4 Offset: 0xDBD1E4 VA: 0xDBD1E4
		// public void CheckFree() { }

		// // RVA: 0xDC0BB0 Offset: 0xDC0BB0 VA: 0xDC0BB0 Slot: 11
		// public override void Free() { }

		// // RVA: 0xDB8800 Offset: 0xDB8800 VA: 0xDB8800
		// public void Initialize(RNoteObject[] objects) { }

		// RVA: 0xDC0C18 Offset: 0xDC0C18 VA: 0xDC0C18
		private void LateUpdate()
		{
			TodoLogger.Log(0, "TODO");
		}

		// // RVA: 0xDC130C Offset: 0xDC130C VA: 0xDC130C
		// private void JudgedDelegate(RNoteObject noteObject, RhythmGameConsts.NoteResultEx a_result_ex, RhythmGameConsts.NoteJudgeType a_judge_type) { }

		// // RVA: 0xDC131C Offset: 0xDC131C VA: 0xDC131C
		// private void BeyondDelegate(RNoteObject noteObject) { }

		// // RVA: 0xDC1320 Offset: 0xDC1320 VA: 0xDC1320
		// private void PassedDelegate(RNoteObject noteObject) { }

		// RVA: 0xDC1330 Offset: 0xDC1330 VA: 0xDC1330 Slot: 5
		protected override void PausableAwake()
		{
			TodoLogger.Log(0, "TODO");
		}

		// RVA: 0xDC1334 Offset: 0xDC1334 VA: 0xDC1334 Slot: 6
		protected override void PausableStart()
		{
			TodoLogger.Log(0, "TODO");
		}

		// RVA: 0xDC1338 Offset: 0xDC1338 VA: 0xDC1338 Slot: 7
		protected override void PausableUpdate()
		{
			TodoLogger.Log(0, "TODO");
		}

		// RVA: 0xDC133C Offset: 0xDC133C VA: 0xDC133C Slot: 8
		protected override void PausableInPause()
		{
			TodoLogger.Log(0, "TODO");
		}

		// RVA: 0xDB514C Offset: 0xDB514C VA: 0xDB514C
		// public void SetEnableRenerer(bool a_enable) { }

		// RVA: 0xDC1340 Offset: 0xDC1340 VA: 0xDC1340
		public RNoteSync()
		{
			TodoLogger.Log(0, "RNoteSync()");
		}

		// RVA: 0xDC17AC Offset: 0xDC17AC VA: 0xDC17AC
		static RNoteSync()
		{
			TodoLogger.Log(0, "static RNoteSync()");
		}
	}
}
