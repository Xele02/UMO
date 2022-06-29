using XeApp.Core;
using UnityEngine;
using System.Collections.Generic;

namespace XeApp.Game.RhythmGame
{
	public class RNoteSingle : PoolObject
	{
		// private static string[] baseNotesName; // 0x0
		// private static List<Vector2>[,] specialNoteUVOffsetList; // 0x4
		private GameObject[] noteObjects; // 0x14
		private MeshFilter[] noteMeshFilters; // 0x18
		private Renderer[] renderer; // 0x1C
		private int baseNoteObjectType = -1; // 0x20
		private int specialNoteObjectType; // 0x24
		[SerializeField]
		private int touchFingerId_; // 0x2C

		public RNoteObject noteObject { get; private set; } // 0x28
		// public RNote rNote { get; private set; } 0xDBAE38 0xDBDDA4
		// public int touchFingerId { get; set; } 0xDB6E5C 0xDB6E64
		// public bool isBeganTouched { get; protected set; } 0xDB9A88 0xDBDDA8
		// public RhythmGameConsts.NoteResult flickStartResult { get; protected set; } // 0x30

		// // RVA: 0xDB4320 Offset: 0xDB4320 VA: 0xDB4320
		// public void CreateSpecialNotesUVOffsetList() { }

		// // RVA: 0xDBDDBC Offset: 0xDBDDBC VA: 0xDBDDBC Slot: 12
		// public override void Create() { }

		// // RVA: 0xDBD19C Offset: 0xDBD19C VA: 0xDBD19C
		// public void CheckFree() { }

		// // RVA: 0xDBE174 Offset: 0xDBE174 VA: 0xDBE174 Slot: 11
		// public override void Free() { }

		// // RVA: 0xDB8688 Offset: 0xDB8688 VA: 0xDB8688
		// public void Initialize(RNoteObject obj, RhythmGameMode gameMode) { }

		// RVA: 0xDBE5F4 Offset: 0xDBE5F4 VA: 0xDBE5F4
		private void LateUpdate()
		{
			UnityEngine.Debug.LogError("TODO");
		}

		// // RVA: 0xDB9A74 Offset: 0xDB9A74 VA: 0xDB9A74
		// public void BeginTouch(int fingerId, RhythmGameConsts.NoteResult result) { }

		// // RVA: 0xDBE808 Offset: 0xDBE808 VA: 0xDBE808
		// private void SetBaseType(RhythmGameConsts.BaseNoteType type) { }

		// // RVA: 0xDBE8E4 Offset: 0xDBE8E4 VA: 0xDBE8E4
		// private void SetSpecialType(RhythmGameConsts.SpecialNoteType spType) { }

		// // RVA: 0xDBE1BC Offset: 0xDBE1BC VA: 0xDBE1BC
		// private void InitializeBasicType() { }

		// // RVA: 0xDBBC7C Offset: 0xDBBC7C VA: 0xDBBC7C
		// public void SetupSpecialType(RhythmGameMode gameMode) { }

		// // RVA: 0xDBEA88 Offset: 0xDBEA88 VA: 0xDBEA88
		// private void JudgedDelegate(RNoteObject noteObject, RhythmGameConsts.NoteResultEx a_result_ex, RhythmGameConsts.NoteJudgeType a_judge_type) { }

		// // RVA: 0xDBEB70 Offset: 0xDBEB70 VA: 0xDBEB70
		// private void BeyondDelegate(RNoteObject noteObject) { }

		// // RVA: 0xDBEB74 Offset: 0xDBEB74 VA: 0xDBEB74
		// private void PassedDelegate(RNoteObject noteObject) { }

		// RVA: 0xDBEB78 Offset: 0xDBEB78 VA: 0xDBEB78 Slot: 5
		protected override void PausableAwake()
		{
			UnityEngine.Debug.LogError("TODO");
		}

		// RVA: 0xDBEB7C Offset: 0xDBEB7C VA: 0xDBEB7C Slot: 6
		protected override void PausableStart()
		{
			UnityEngine.Debug.LogError("TODO");
		}

		// RVA: 0xDBEB80 Offset: 0xDBEB80 VA: 0xDBEB80 Slot: 7
		protected override void PausableUpdate()
		{
			UnityEngine.Debug.LogError("TODO");
		}

		// RVA: 0xDBEB84 Offset: 0xDBEB84 VA: 0xDBEB84 Slot: 8
		protected override void PausableInPause()
		{
			UnityEngine.Debug.LogError("TODO");
		}

		// RVA: 0xDB5020 Offset: 0xDB5020 VA: 0xDB5020
		// public void SetEnableRenderer(bool a_enable) { }

		// RVA: 0xDBEB98 Offset: 0xDBEB98 VA: 0xDBEB98
		static RNoteSingle()
		{
			UnityEngine.Debug.LogError("TODO static RNoteSingle");
		}
	}
}
