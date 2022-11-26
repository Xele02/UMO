using XeApp.Core;
using UnityEngine;
using System.Collections.Generic;
using XeApp.Game.Common;

namespace XeApp.Game.RhythmGame
{
	public class RNoteSync : PoolObject
	{
		protected static readonly float width = 14; // 0x0
		protected static readonly float offset_z = 20; // 0x4
		protected static readonly int quad_count = 1; // 0x8
		protected static readonly int vertex_count = quad_count * 4; // 0xC
		private List<Vector2> uvListU = new List<Vector2>() { new Vector2(0, 0.5f), new Vector2(0, 0.5f), new Vector2(0, 0.5f),
			new Vector2(0, 0.5f), new Vector2(0, 0.5f), new Vector2(0, 0.5f)  };// 0x14
		private List<Vector2> uvListV = new List<Vector2>() { new Vector2(0, 0.015625f), new Vector2(0, 0.015625f), new Vector2(0, 0.015625f), 
			new Vector2(0, 0.015625f), new Vector2(0, 0.015625f), new Vector2(0, 0.015625f)}; // 0x18
		private Renderer renderer; // 0x1C
		private Mesh mesh; // 0x20
		public Transform firstTransform; // 0x24
		public Transform lastTransform; // 0x28
		protected RNoteObject[] noteObjects; // 0x2C
		public RNoteObject firstRNoteObject; // 0x30
		public RNoteObject lastRNoteObject; // 0x34
		private Vector3[] v; // 0x38
		private Vector2[] uv; // 0x3C
		private static int[] s_tri = new int[4] { 0, 2, 3, 1 }; // 0x10

		// // RVA: 0xDC06E4 Offset: 0xDC06E4 VA: 0xDC06E4 Slot: 12
		public override void Create()
		{
			mesh = new Mesh();
			mesh.name = "SyncNotesDinamicMesh";
			GetComponent<MeshFilter>().mesh = mesh;
			renderer = GetComponent<Renderer>();
			renderer.enabled = true;
			v = new Vector3[vertex_count];
			uv = new Vector2[vertex_count];
			uv[0] = new Vector2(uvListU[GameManager.Instance.localSave.EPJOACOONAC_GetSave().CNLJNGLMMHB_Options.KDNKCOAJGCM_NotesType].x,
								uvListV[GameManager.Instance.localSave.EPJOACOONAC_GetSave().CNLJNGLMMHB_Options.KDNKCOAJGCM_NotesType].x);
			uv[1] = new Vector2(uvListU[GameManager.Instance.localSave.EPJOACOONAC_GetSave().CNLJNGLMMHB_Options.KDNKCOAJGCM_NotesType].x,
								uvListV[GameManager.Instance.localSave.EPJOACOONAC_GetSave().CNLJNGLMMHB_Options.KDNKCOAJGCM_NotesType].y);
			uv[2] = new Vector2(uvListU[GameManager.Instance.localSave.EPJOACOONAC_GetSave().CNLJNGLMMHB_Options.KDNKCOAJGCM_NotesType].y,
								uvListV[GameManager.Instance.localSave.EPJOACOONAC_GetSave().CNLJNGLMMHB_Options.KDNKCOAJGCM_NotesType].x);
			uv[3] = new Vector2(uvListU[GameManager.Instance.localSave.EPJOACOONAC_GetSave().CNLJNGLMMHB_Options.KDNKCOAJGCM_NotesType].y,
								uvListV[GameManager.Instance.localSave.EPJOACOONAC_GetSave().CNLJNGLMMHB_Options.KDNKCOAJGCM_NotesType].y);
		}

		// // RVA: 0xDBD1E4 Offset: 0xDBD1E4 VA: 0xDBD1E4
		public void CheckFree()
		{
			for(int i = 0; i < noteObjects.Length; i++)
			{
				if(!noteObjects[i].IsJudged())
					return;
			}
			Free();
		}

		// // RVA: 0xDC0BB0 Offset: 0xDC0BB0 VA: 0xDC0BB0 Slot: 11
		public override void Free()
		{
			base.Free();
			mesh.Clear();
			gameObject.SetActive(false);
		}

		// // RVA: 0xDB8800 Offset: 0xDB8800 VA: 0xDB8800
		public void Initialize(RNoteObject[] objects)
		{
			noteObjects = objects;
			firstRNoteObject = objects[0];
			lastRNoteObject = objects[1];
			firstTransform = objects[0].transform;
			lastTransform = objects[1].transform;
			gameObject.SetActive(true);
			for(int i = 0; i < objects.Length; i++)
			{
				objects[i].AddJudgedEvent(this.JudgedDelegate);
				objects[i].AddBeyondEvent(this.BeyondDelegate);
				objects[i].AddPassedEvent(this.PassedDelegate);
			}
		}

		// RVA: 0xDC0C18 Offset: 0xDC0C18 VA: 0xDC0C18
		private void LateUpdate()
		{
			Vector3 pos1 = firstTransform.localPosition;
			Vector3 pos2 = lastTransform.localPosition;
			if(pos2.x <= pos1.x)
			{
				pos1 = lastTransform.localPosition;
				pos2 = firstTransform.localPosition;
			} 
			int track1 = firstRNoteObject.rNote.noteInfo.trackID;
			int track2 = lastRNoteObject.rNote.noteInfo.trackID;
			float off1 = 0.5f;
			float off2 = -0.5f;
			if(track1 < track2)
			{
				off1 = -0.5f;
				off2 = 0.5f;
			}
			v[0] = new Vector3(pos1.x + off2, pos1.y, pos1.z);
			v[0].y += width * firstTransform.localScale.x * 0.5f;
			v[0].z += offset_z;

			v[1] = new Vector3(pos1.x + off2, pos1.y, pos1.z);
			v[1].y -= width * firstTransform.localScale.x * 0.5f;
			v[1].z += offset_z;

			v[2] = new Vector3(pos2.x + off1, pos2.y, pos2.z);
			v[2].y += width * lastTransform.localScale.x * 0.5f;
			v[2].z += offset_z;

			v[3] = new Vector3(pos2.x + off2, pos2.y, pos2.z);
			v[3].y -= width * lastTransform.localScale.x * 0.5f;
			v[3].z += offset_z;

			mesh.Clear();
			mesh.vertices = v;
			mesh.uv = uv;
			mesh.SetIndices(s_tri, MeshTopology.Quads, 0);
		}

		// // RVA: 0xDC130C Offset: 0xDC130C VA: 0xDC130C
		private void JudgedDelegate(RNoteObject noteObject, RhythmGameConsts.NoteResultEx a_result_ex, RhythmGameConsts.NoteJudgeType a_judge_type)
		{
			Free();
		}

		// // RVA: 0xDC131C Offset: 0xDC131C VA: 0xDC131C
		private void BeyondDelegate(RNoteObject noteObject)
		{
			return;
		}

		// // RVA: 0xDC1320 Offset: 0xDC1320 VA: 0xDC1320
		private void PassedDelegate(RNoteObject noteObject)
		{
			Free();
		}

		// RVA: 0xDC1330 Offset: 0xDC1330 VA: 0xDC1330 Slot: 5
		protected override void PausableAwake()
		{
			return;
		}

		// RVA: 0xDC1334 Offset: 0xDC1334 VA: 0xDC1334 Slot: 6
		protected override void PausableStart()
		{
			return;
		}

		// RVA: 0xDC1338 Offset: 0xDC1338 VA: 0xDC1338 Slot: 7
		protected override void PausableUpdate()
		{
			return;
		}

		// RVA: 0xDC133C Offset: 0xDC133C VA: 0xDC133C Slot: 8
		protected override void PausableInPause()
		{
			return;
		}

		// RVA: 0xDB514C Offset: 0xDB514C VA: 0xDB514C
		public void SetEnableRenerer(bool a_enable)
		{
			if (renderer != null)
				renderer.enabled = a_enable;
		}
	}
}
