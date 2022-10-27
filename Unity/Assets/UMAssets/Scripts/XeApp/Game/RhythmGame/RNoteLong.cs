using XeApp.Core;
using UnityEngine;
using System.Collections.Generic;

namespace XeApp.Game.RhythmGame
{
	public class RNoteLong : PoolObject
	{
		protected static readonly float width; // 0x0
		protected static readonly float offset_z; // 0x4
		protected static readonly int divid_min; // 0x8
		protected static readonly int divid_max; // 0xC
		protected static readonly float divid_length; // 0x10
		private static readonly int square_vertex_count; // 0x14
		private List<Vector2> uvListU; // 0x14
		private List<Vector2> uvListV; // 0x18
		[SerializeField]
		protected int divid; // 0x1C
		protected float uv_u_start; // 0x20
		protected float uv_u_end; // 0x24
		protected float uv_v_start; // 0x28
		protected float uv_v_length; // 0x2C
		protected RNoteObject[] noteObjects; // 0x30
		public RNoteObject firstRNoteObject; // 0x34
		public RNoteObject lastRNoteObject; // 0x38
		private Mesh mesh; // 0x3C
		private Renderer renderer; // 0x40
		// protected RNoteLong.ControlPoint[] controlPoints; // 0x44
		protected Vector3[] leftSidePoints; // 0x48
		protected Vector3[] rightSidePoints; // 0x4C
		protected bool isAdsorbedFirstObject; // 0x50
		protected bool isAdsorbedLastObject; // 0x51
		private static readonly int OnStateHash; // 0x18
		private static readonly int OffStateHash; // 0x1C
		private Animator animator; // 0x54
		[SerializeField]
		private int touchFingerId_; // 0x58
		private Vector3[] v; // 0x5C
		private Vector2[] uv; // 0x60
		private static int[][] s_tri; // 0x20

		// public int touchFingerId { get; } 0xDAAA50
		// public bool isBeganTouched { get; protected set; } 0xDAAA58 0xDAAA6C

		// RVA: 0xDAAA70 Offset: 0xDAAA70 VA: 0xDAAA70
		static RNoteLong()
		{
			TodoLogger.Log(0, "static RNoteLong");
		}

		// // RVA: 0xDAADB0 Offset: 0xDAADB0 VA: 0xDAADB0 Slot: 12
		public override void Create()
		{
			TodoLogger.Log(0, "RNoteLong Create");
		}

		// // RVA: 0xDAAF50 Offset: 0xDAAF50 VA: 0xDAAF50
		// public void CheckFree() { }

		// // RVA: 0xDAAFF8 Offset: 0xDAAFF8 VA: 0xDAAFF8 Slot: 11
		// public override void Free() { }

		// // RVA: 0xDAB060 Offset: 0xDAB060 VA: 0xDAB060 Slot: 14
		// public virtual void Initialize(RNoteObject[] objects) { }

		// // RVA: 0xDAB6C0 Offset: 0xDAB6C0 VA: 0xDAB6C0
		// private void LateUpdate() { }

		// // RVA: 0xDABF40 Offset: 0xDABF40 VA: 0xDABF40
		// public void BeginTouch(int fingerId) { }

		// // RVA: 0xDAC130 Offset: 0xDAC130 VA: 0xDAC130
		// private void JudgedDelegate(RNoteObject noteObject, RhythmGameConsts.NoteResultEx a_result_ex, RhythmGameConsts.NoteJudgeType a_type) { }

		// // RVA: 0xDAC7CC Offset: 0xDAC7CC VA: 0xDAC7CC
		// private void BeyondDelegate(RNoteObject noteObject) { }

		// // RVA: 0xDAC8D8 Offset: 0xDAC8D8 VA: 0xDAC8D8
		// private void PassedDelegate(RNoteObject noteObject) { }

		// // RVA: 0xDACA50 Offset: 0xDACA50 VA: 0xDACA50
		// protected int GetDivideCount(ref Vector3 pos0, ref Vector3 pos1) { }

		// // RVA: 0xDACBF0 Offset: 0xDACBF0 VA: 0xDACBF0 Slot: 15
		// protected virtual void UpdateVerticesPosition() { }

		// // RVA: 0xDAB904 Offset: 0xDAB904 VA: 0xDAB904
		// private void UpdateMesh() { }

		// RVA: 0xDAD588 Offset: 0xDAD588 VA: 0xDAD588 Slot: 5
		protected override void PausableAwake()
		{
			TodoLogger.Log(0, "TODO");
		}

		// RVA: 0xDAD58C Offset: 0xDAD58C VA: 0xDAD58C Slot: 6
		protected override void PausableStart()
		{
			TodoLogger.Log(0, "TODO");
		}

		// RVA: 0xDAD590 Offset: 0xDAD590 VA: 0xDAD590 Slot: 7
		protected override void PausableUpdate()
		{
			TodoLogger.Log(0, "TODO");
		}

		// RVA: 0xDAD594 Offset: 0xDAD594 VA: 0xDAD594 Slot: 8
		protected override void PausableInPause()
		{
			TodoLogger.Log(0, "TODO");
		}

		// // RVA: 0xDAD598 Offset: 0xDAD598 VA: 0xDAD598
		public void SetEnableRenerer(bool a_enable)
		{
			if (renderer != null)
				renderer.enabled = a_enable;
		}

		// // RVA: 0xDAD650 Offset: 0xDAD650 VA: 0xDAD650
		// public void StopAnimation() { }

		// // RVA: 0xDAD768 Offset: 0xDAD768 VA: 0xDAD768 Slot: 16
		// public virtual void Pause() { }

		// // RVA: 0xDAD820 Offset: 0xDAD820 VA: 0xDAD820 Slot: 17
		// public virtual void Resume() { }

		// RVA: 0xDAD8D8 Offset: 0xDAD8D8 VA: 0xDAD8D8
		public RNoteLong()
		{
			TodoLogger.Log(0, "RNoteLong()");
		}
	}
}
