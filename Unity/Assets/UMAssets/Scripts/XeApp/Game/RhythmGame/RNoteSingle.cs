using XeApp.Core;
using UnityEngine;
using System.Collections.Generic;
using XeApp.Game.Common;

namespace XeApp.Game.RhythmGame
{
	public class RNoteSingle : PoolObject
	{
		private static string[] baseNotesName = new string[11] { "SingleNote", "LongNote", "FlickNoteL", "FlickNoteU", "FlickNoteR", "SlideNote", "SlideNoteLink", "WingOpenNoteR",
				"WingOpenNoteL", "WingCloseNoteR", "WingCloseNoteL"}; // 0x0
		private static List<Vector2>[,] specialNoteUVOffsetList = new List<Vector2>[12, 9]; // 0x4
		private GameObject[] noteObjects; // 0x14
		private MeshFilter[] noteMeshFilters; // 0x18
		private Renderer[] renderer; // 0x1C
		private int baseNoteObjectType = -1; // 0x20
		private int specialNoteObjectType; // 0x24
		[SerializeField]
		private int touchFingerId_; // 0x2C

		public RNoteObject noteObject { get; private set; } // 0x28
		// public RNote rNote { get; private set; } 0xDBAE38 0xDBDDA4
		public int touchFingerId { get { return touchFingerId_; } set { touchFingerId_ = value; } } //0xDB6E5C 0xDB6E64
		// public bool isBeganTouched { get; protected set; } 0xDB9A88 0xDBDDA8
		public RhythmGameConsts.NoteResult flickStartResult { get; protected set; } // 0x30

		// // RVA: 0xDB4320 Offset: 0xDB4320 VA: 0xDB4320
		public void CreateSpecialNotesUVOffsetList()
		{
			Vector2[] v = new Vector2[9];
			v[0] = new Vector2(0, 0);
			v[1] = new Vector2(0.25f, 0);
			v[2] = new Vector2(0.5f, 0);
			v[3] = new Vector2(0.75f, 0);
			v[4] = new Vector2(0.5f, -0.25f);
			v[5] = new Vector2(0, -0.25f);
			v[6] = new Vector2(0.25f, -0.25f);
			v[7] = new Vector2(0.75f, -0.25f);
			v[8] = new Vector2(0, -0.5f);
			for(int i = 0; i < baseNotesName.Length; i++)
			{
				Transform t = transform.Find(baseNotesName[i]);
				if(t != null)
				{
					MeshFilter ms = t.GetComponent<MeshFilter>();
					for (int j = 0; j < 9; j++)
					{
						List<Vector2> l = new List<Vector2>();
						specialNoteUVOffsetList[i, j] = l;
						for(int k = 0; k < ms.mesh.uv.Length; k++)
						{
							l.Add(v[j]);
						}
					}
				}
			}
		}

		// // RVA: 0xDBDDBC Offset: 0xDBDDBC VA: 0xDBDDBC Slot: 12
		public override void Create()
		{
			noteObjects = new GameObject[11];
			noteMeshFilters = new MeshFilter[11];
			renderer = new Renderer[11];

			for(int i = 0; i < 11; i++)
			{
				Transform t = transform.Find(baseNotesName[i]);
				if(t != null)
				{
					noteObjects[i] = t.gameObject;
					noteMeshFilters[i] = noteObjects[i].GetComponent<MeshFilter>();
					renderer[i] = t.GetComponentInChildren<Renderer>();
				}
			}
		}

		// // RVA: 0xDBD19C Offset: 0xDBD19C VA: 0xDBD19C
		public void CheckFree()
		{
			if(!noteObject.IsJudged())
				return;
			noteObject.Free();
		}

		// // RVA: 0xDBE174 Offset: 0xDBE174 VA: 0xDBE174 Slot: 11
		public override void Free()
		{
			base.Free();
			gameObject.SetActive(false);
		}

		// // RVA: 0xDB8688 Offset: 0xDB8688 VA: 0xDB8688
		public void Initialize(RNoteObject obj, RhythmGameMode gameMode)
		{
			noteObject = obj;
			touchFingerId_ = -1;
			flickStartResult = RhythmGameConsts.NoteResult.None;
			InitializeBasicType();
			SetupSpecialType(gameMode);
			obj.AddJudgedEvent(this.JudgedDelegate);
			obj.AddBeyondEvent(this.BeyondDelegate);
			obj.AddPassedEvent(this.PassedDelegate);
		}

		// RVA: 0xDBE5F4 Offset: 0xDBE5F4 VA: 0xDBE5F4
		private void LateUpdate()
		{
			if(noteObject != null)
			{
				transform.localPosition = noteObject.transform.localPosition;
				transform.localRotation = noteObject.transform.localRotation;
				transform.localScale = noteObject.transform.localScale;
			}
		}

		// // RVA: 0xDB9A74 Offset: 0xDB9A74 VA: 0xDB9A74
		public void BeginTouch(int fingerId, RhythmGameConsts.NoteResult result)
		{
			touchFingerId = fingerId;
			flickStartResult = result;
		}

		// // RVA: 0xDBE808 Offset: 0xDBE808 VA: 0xDBE808
		private void SetBaseType(RhythmGameConsts.BaseNoteType type)
		{
			if (baseNoteObjectType == (int)type)
				return;
			if(baseNoteObjectType > -1)
			{
				noteObjects[baseNoteObjectType].SetActive(false);
			}
			noteObjects[(int)type].SetActive(true);
			baseNoteObjectType = (int)type;
		}

		// // RVA: 0xDBE8E4 Offset: 0xDBE8E4 VA: 0xDBE8E4
		private void SetSpecialType(RhythmGameConsts.SpecialNoteType spType)
		{
			specialNoteObjectType = (int)spType;
			noteMeshFilters[baseNoteObjectType].mesh.uv3 = specialNoteUVOffsetList[baseNoteObjectType, specialNoteObjectType].ToArray();
		}

		// // RVA: 0xDBE1BC Offset: 0xDBE1BC VA: 0xDBE1BC
		private void InitializeBasicType()
		{
			RhythmGameConsts.BaseNoteType type = RhythmGameConsts.BaseNoteType.Single;
			if(noteObject.rNote.noteInfo.flick == MusicScoreData.FlickType.None)
			{
				if(noteObject.rNote.noteInfo.longTouch != MusicScoreData.TouchState.None)
				{
					type = RhythmGameConsts.BaseNoteType.Long;
					if(noteObject.rNote.noteInfo.isSlide)
					{
						type = RhythmGameConsts.BaseNoteType.Slide;
						if (noteObject.rNote.noteInfo.longTouch == MusicScoreData.TouchState.Continue)
							type = RhythmGameConsts.BaseNoteType.SlideLink;
					}
				}
			}
			else
			{
				if(noteObject.rNote.noteInfo.isWing)
				{
					if (!RhythmGameConsts.IsWingLine(noteObject.rNote.noteInfo.trackID))
					{
						type = RhythmGameConsts.BaseNoteType.WingOpenNoteR;
						if (RhythmGameConsts.IsLeftLine(noteObject.rNote.noteInfo.trackID))
							type = RhythmGameConsts.BaseNoteType.WingOpenNoteL;
					}
					else
					{
						type = RhythmGameConsts.BaseNoteType.WingCloseNoteR;
						if (RhythmGameConsts.IsLeftLine(noteObject.rNote.noteInfo.trackID))
							type = RhythmGameConsts.BaseNoteType.WingCloseNoteL;
					}
				}
				else
				{
					type = RhythmGameConsts.BaseNoteType.FlickL;
					if(noteObject.rNote.noteInfo.flick != MusicScoreData.FlickType.Left)
					{
						type = RhythmGameConsts.BaseNoteType.FlickU;
						if (noteObject.rNote.noteInfo.flick != MusicScoreData.FlickType.Up)
						{
							type = RhythmGameConsts.BaseNoteType.Single;
							if (noteObject.rNote.noteInfo.flick == MusicScoreData.FlickType.Right)
								type = RhythmGameConsts.BaseNoteType.FlickR;
						}
					}
				}
			}
			SetBaseType(type);
		}

		// // RVA: 0xDBBC7C Offset: 0xDBBC7C VA: 0xDBBC7C
		public void SetupSpecialType(RhythmGameMode gameMode)
		{
			SetSpecialType(noteObject.rNote.CurrentModeInfo(gameMode).specialNoteType);
		}

		// // RVA: 0xDBEA88 Offset: 0xDBEA88 VA: 0xDBEA88
		private void JudgedDelegate(RNoteObject noteObject, RhythmGameConsts.NoteResultEx a_result_ex, RhythmGameConsts.NoteJudgeType a_judge_type)
		{
			if(noteObject.rNote.noteInfo.isSlide)
			{
				if(noteObject.rNote.noteInfo.longTouch == MusicScoreData.TouchState.Continue)
				{
					if(a_result_ex.m_result < RhythmGameConsts.NoteResult.Great)
						return;
				}
			}
			Free();
		}

		// // RVA: 0xDBEB70 Offset: 0xDBEB70 VA: 0xDBEB70
		private void BeyondDelegate(RNoteObject noteObject)
		{
			return;
		}

		// // RVA: 0xDBEB74 Offset: 0xDBEB74 VA: 0xDBEB74
		private void PassedDelegate(RNoteObject noteObject)
		{
			return;
		}

		// RVA: 0xDBEB78 Offset: 0xDBEB78 VA: 0xDBEB78 Slot: 5
		protected override void PausableAwake()
		{
			return;
		}

		// RVA: 0xDBEB7C Offset: 0xDBEB7C VA: 0xDBEB7C Slot: 6
		protected override void PausableStart()
		{
			return;
		}

		// RVA: 0xDBEB80 Offset: 0xDBEB80 VA: 0xDBEB80 Slot: 7
		protected override void PausableUpdate()
		{
			return;
		}

		// RVA: 0xDBEB84 Offset: 0xDBEB84 VA: 0xDBEB84 Slot: 8
		protected override void PausableInPause()
		{
			return;
		}

		// RVA: 0xDB5020 Offset: 0xDB5020 VA: 0xDB5020
		public void SetEnableRenderer(bool a_enable)
		{
			for(int i = 0; i < renderer.Length; i++)
			{
				if (renderer[i] != null)
					renderer[i].enabled = a_enable;
			}
		}
	}
}
