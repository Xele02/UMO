using XeApp.Core;
using UnityEngine;
using System.Collections.Generic;
using XeApp.Game.Common;

namespace XeApp.Game.RhythmGame
{
	public class RNoteLong : PoolObject
	{
		protected struct ControlPoint
		{
			public Vector3 pos; // 0x0
			public float scale; // 0xC
		}

		protected static readonly float width = 35; // 0x0
		protected static readonly float offset_z = 20; // 0x4
		protected static readonly int divid_min = 2; // 0x8
		protected static readonly int divid_max = 12; // 0xC
		protected static readonly float divid_length = 80; // 0x10
		private static readonly int square_vertex_count = 4; // 0x14
		private List<Vector2> uvListU = new List<Vector2>() { new Vector2(0, 0.5f), new Vector2(0, 0.5f), new Vector2(0, 0.5f), 
			new Vector2(0, 0.5f), new Vector2(0, 0.5f), new Vector2(0, 0.5f) }; // 0x14
		private List<Vector2> uvListV = new List<Vector2>() { new Vector2(0, 0.005859375f), new Vector2(0, 0.005859375f), new Vector2(0, 0.005859375f), 
			new Vector2(0, 0.005859375f), new Vector2(0, 0.005859375f), new Vector2(0, 0.005859375f)}; // 0x18
		[SerializeField]
		protected int divid = 12; // 0x1C
		protected float uv_u_start; // 0x20
		protected float uv_u_end; // 0x24
		protected float uv_v_start; // 0x28
		protected float uv_v_length; // 0x2C
		protected RNoteObject[] noteObjects; // 0x30
		public RNoteObject firstRNoteObject; // 0x34
		public RNoteObject lastRNoteObject; // 0x38
		private Mesh mesh; // 0x3C
		private Renderer renderer; // 0x40
		protected ControlPoint[] controlPoints = new ControlPoint[divid_max]; // 0x44
		protected Vector3[] leftSidePoints = new Vector3[divid_max]; // 0x48
		protected Vector3[] rightSidePoints = new Vector3[divid_max]; // 0x4C
		protected bool isAdsorbedFirstObject; // 0x50
		protected bool isAdsorbedLastObject; // 0x51
		private static readonly int OnStateHash = Animator.StringToHash("Line_ON"); // 0x18
		private static readonly int OffStateHash = Animator.StringToHash("Line_OFF"); // 0x1C
		private Animator animator; // 0x54
		[SerializeField]
		private int touchFingerId_; // 0x58
		private Vector3[] v; // 0x5C
		private Vector2[] uv; // 0x60
		private static int[][] s_tri = null; // 0x20

		public int touchFingerId { get { return touchFingerId_; } } //0xDAAA50
		// public bool isBeganTouched { get; protected set; } 0xDAAA58 0xDAAA6C

		// RVA: 0xDAAA70 Offset: 0xDAAA70 VA: 0xDAAA70
		static RNoteLong()
		{
			s_tri = new int[divid_max - divid_min + 1][];
			for(int i = 0; i < s_tri.Length; i++)
			{
				s_tri[i] = new int[square_vertex_count * (i + divid_min - 1)];
				for(int j = 0; j < s_tri[i].Length; j+= square_vertex_count)
				{
					int a = j / square_vertex_count;
					s_tri[i][j] = a * 2;
					s_tri[i][j + 1] = (a * 2) + 2;
					s_tri[i][j + 2] = (a * 2) + 3;
					s_tri[i][j + 3] = (a * 2) | 1;
				}
			}
		}

		// // RVA: 0xDAADB0 Offset: 0xDAADB0 VA: 0xDAADB0 Slot: 12
		public override void Create()
		{
			mesh = new Mesh();
			mesh.name = "LongNotesDinamicMesh";
			GetComponent<MeshFilter>().mesh = mesh;
			renderer = GetComponent<Renderer>();
			renderer.enabled = true;
			v = new Vector3[controlPoints.Length * 2];
			uv = new Vector2[controlPoints.Length * 2];
			animator = GetComponent<Animator>();
		}

		// // RVA: 0xDAAF50 Offset: 0xDAAF50 VA: 0xDAAF50
		public void CheckFree()
		{
			for(int i = 0; i < noteObjects.Length; i++)
			{
				if(!noteObjects[i].IsJudged())
					return;
			}
			Free();
		}

		// // RVA: 0xDAAFF8 Offset: 0xDAAFF8 VA: 0xDAAFF8 Slot: 11
		public override void Free()
		{
			base.Free();
			mesh.Clear();
			gameObject.SetActive(false);
		}

		// // RVA: 0xDAB060 Offset: 0xDAB060 VA: 0xDAB060 Slot: 14
		public virtual void Initialize(RNoteObject[] objects)
		{
			noteObjects = objects;
			firstRNoteObject = objects[0];
			lastRNoteObject = objects[1];
			isAdsorbedFirstObject = false;
			isAdsorbedLastObject = false;
			touchFingerId_ = -1;
			gameObject.SetActive(true);
			for(int i =0; i < objects.Length; i++)
			{
				objects[i].AddJudgedEvent(this.JudgedDelegate);
				objects[i].AddBeyondEvent(this.BeyondDelegate);
				objects[i].AddPassedEvent(this.PassedDelegate);
			}
			uv_u_start = uvListU[GameManager.Instance.localSave.EPJOACOONAC_GetSave().CNLJNGLMMHB_Options.KDNKCOAJGCM_NotesType].x;
			uv_u_end = uvListU[GameManager.Instance.localSave.EPJOACOONAC_GetSave().CNLJNGLMMHB_Options.KDNKCOAJGCM_NotesType].y;
			uv_v_start = uvListV[GameManager.Instance.localSave.EPJOACOONAC_GetSave().CNLJNGLMMHB_Options.KDNKCOAJGCM_NotesType].x;
			uv_v_length = uvListV[GameManager.Instance.localSave.EPJOACOONAC_GetSave().CNLJNGLMMHB_Options.KDNKCOAJGCM_NotesType].y;
			if(animator != null)
			{
				animator.Play(OffStateHash, -1, 1);
			}
		}

		// // RVA: 0xDAB6C0 Offset: 0xDAB6C0 VA: 0xDAB6C0
		private void LateUpdate()
		{
			if(!firstRNoteObject.gameObject.activeSelf && !lastRNoteObject.gameObject.activeSelf)
				return;
			if(firstRNoteObject.transform.localScale.x >= 0.001f && !isAdsorbedLastObject)
			{
				if(firstRNoteObject.rNote.noteInfo.isSlide)
				{
					if(firstRNoteObject.rNote.result == Common.RhythmGameConsts.NoteResult.Miss)
						return;
					if(lastRNoteObject.rNote.result == Common.RhythmGameConsts.NoteResult.None)
					{
						if(lastRNoteObject.rNote.resultReset)
							return;
					}
				}
				UpdateVerticesPosition();
				UpdateMesh();
			}
		}

		// // RVA: 0xDABF40 Offset: 0xDABF40 VA: 0xDABF40
		public void BeginTouch(int fingerId)
		{
			touchFingerId_ = fingerId;
			if(animator != null)
			{
				if(OnStateHash == animator.GetCurrentAnimatorStateInfo(0).shortNameHash || animator.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1)
				{
					animator.Play(OnStateHash, -1, 0);
				}
			}
		}

		// // RVA: 0xDAC130 Offset: 0xDAC130 VA: 0xDAC130
		private void JudgedDelegate(RNoteObject noteObject, RhythmGameConsts.NoteResultEx a_result_ex, RhythmGameConsts.NoteJudgeType a_type)
		{
			if(noteObject.rNote.noteInfo.isSlide)
			{
				if(a_result_ex.m_result != RhythmGameConsts.NoteResult.Miss)
				{
					;
				}
				else
				{
					if(lastRNoteObject != noteObject)
					{
						if(firstRNoteObject != noteObject || a_type == RhythmGameConsts.NoteJudgeType.EndedTouch)
						{
							;
						}
						else
						{
							if(lastRNoteObject.rNote.noteInfo.longTouch == MusicScoreData.TouchState.End)
							{
								lastRNoteObject.Judged(RhythmGameConsts.NoteResult.Miss, RhythmGameConsts.NoteJudgeType.Normal);
								Free();
							}
							else
							{
								if(touchFingerId_ != -1)
								{
									mesh.Clear();
								}
							}
						}
					}
					else
					{
						Free();
					}
				}
			}
			else
			{
				if(noteObject.rNote.noteInfo.longTouch == MusicScoreData.TouchState.Start)
				{
					if(a_result_ex.m_result != RhythmGameConsts.NoteResult.Miss)
					{
						;
					}
					else
					{
						if(!noteObject.rNote.noteInfo.isSlide)
						{
							lastRNoteObject.Judged(RhythmGameConsts.NoteResult.Miss, RhythmGameConsts.NoteJudgeType.Normal);
							Free();
						}
						else
						{
							if(lastRNoteObject.rNote.noteInfo.longTouch == MusicScoreData.TouchState.End)
							{
								lastRNoteObject.Judged(RhythmGameConsts.NoteResult.Miss, RhythmGameConsts.NoteJudgeType.Normal);
							}
						}
					}
				}
				else if(a_result_ex.m_result == RhythmGameConsts.NoteResult.None)
				{
					;
				}
				else
				{
					mesh.Clear();
				}
			}
			if(firstRNoteObject == noteObject && firstRNoteObject.rNote.result != RhythmGameConsts.NoteResult.None)
			{
				isAdsorbedFirstObject = true;
			}
		}

		// // RVA: 0xDAC7CC Offset: 0xDAC7CC VA: 0xDAC7CC
		private void BeyondDelegate(RNoteObject noteObject)
		{
			if(firstRNoteObject == noteObject)
				return;
			if(lastRNoteObject != noteObject)
				return;
			isAdsorbedLastObject = true;
			mesh.Clear();
		}

		// // RVA: 0xDAC8D8 Offset: 0xDAC8D8 VA: 0xDAC8D8
		private void PassedDelegate(RNoteObject noteObject)
		{
			if(firstRNoteObject.rNote.noteInfo.longTouch == MusicScoreData.TouchState.Continue)
			{
				if(firstRNoteObject.rNote.result == RhythmGameConsts.NoteResult.Miss)
				{
					if(lastRNoteObject.rNote.noteInfo.longTouch != MusicScoreData.TouchState.End)
					{
						return;
					}
					lastRNoteObject.Judged(lastRNoteObject.rNote.result, RhythmGameConsts.NoteJudgeType.Normal);
					Free();
				}
			}
		}

		// // RVA: 0xDACA50 Offset: 0xDACA50 VA: 0xDACA50
		// protected int GetDivideCount(ref Vector3 pos0, ref Vector3 pos1) { }

		// // RVA: 0xDACBF0 Offset: 0xDACBF0 VA: 0xDACBF0 Slot: 15
		protected virtual void UpdateVerticesPosition()
		{
			float f;
			if(!isAdsorbedFirstObject)
			{
				f = firstRNoteObject.positionAnimator.CalcNormalizeAnimationTime();
			}
			else
			{
				f = firstRNoteObject.positionAnimator.justNormalizeTime;
			}
			float f2;
			if(!isAdsorbedLastObject)
			{
				f2 = lastRNoteObject.positionAnimator.CalcNormalizeAnimationTime();
			}
			else
			{
				f2 = lastRNoteObject.positionAnimator.justNormalizeTime;
			}
			RNoteObject obj1;
			if(firstRNoteObject.gameObject.activeSelf)
			{
				obj1 = firstRNoteObject;
			}
			else
			{
				obj1 = lastRNoteObject;
			}
            RNotePositionAnimator.AnimData data;
			obj1.positionAnimator.CalcAnimationData(f, out data);
			controlPoints[0].pos = data.localPosition;
			controlPoints[0].scale = data.localScale;
			obj1.positionAnimator.CalcAnimationData(f2, out data);
			controlPoints[divid_max - 1].pos = data.localPosition;
			controlPoints[divid_max - 1].scale = data.localScale;
			if((divid - 1) > 1)
			{
				float f3 = f2 - f;
				for(int i = 0; i < divid - 1; i++)
				{
					f = f3 / (divid - 1) + f;
					obj1.positionAnimator.CalcAnimationData(f, out data);
					controlPoints[i + 1].pos = data.localPosition;
					controlPoints[i + 1].scale = data.localScale;
				}
			}
			for(int i = 0; i < divid; i++)
			{
				leftSidePoints[i] = controlPoints[i].pos - Vector3.right * width * controlPoints[i].scale;
				rightSidePoints[i] = controlPoints[i].pos + Vector3.right * width * controlPoints[i].scale;
				leftSidePoints[i].z += offset_z;
				rightSidePoints[i].z += offset_z;
			}
		}

		// // RVA: 0xDAB904 Offset: 0xDAB904 VA: 0xDAB904
		private void UpdateMesh()
		{
			float length = 0;
			for(int i = 0; i < divid-1; i++)
			{
				length += (controlPoints[i].pos - controlPoints[i + 1].pos).magnitude;
			}
			if(length > 0)
			{
				float v = uv_v_start;
				for(int i = 0, j = 0; i < divid * 2; i+=2, j++)
				{
					uv[i] = new Vector2(uv_u_start, v);
					uv[i+1] = new Vector2(uv_u_end, v);
					if(j != divid - 1)
					{
						v += ((controlPoints[j].pos - controlPoints[j + 1].pos).magnitude / length) * uv_v_length;
					}
				}
				for(int i = 0; i < divid; i++)
				{
					this.v[i * 2] = leftSidePoints[i];
					this.v[i * 2 + 1] = rightSidePoints[i];
				}
				mesh.Clear();
				mesh.vertices = this.v;
				mesh.uv = uv;
				mesh.SetIndices(s_tri[divid - divid_min], MeshTopology.Quads, 0);
			}
		}

		// RVA: 0xDAD588 Offset: 0xDAD588 VA: 0xDAD588 Slot: 5
		protected override void PausableAwake()
		{
			return;
		}

		// RVA: 0xDAD58C Offset: 0xDAD58C VA: 0xDAD58C Slot: 6
		protected override void PausableStart()
		{
			return;
		}

		// RVA: 0xDAD590 Offset: 0xDAD590 VA: 0xDAD590 Slot: 7
		protected override void PausableUpdate()
		{
			return;
		}

		// RVA: 0xDAD594 Offset: 0xDAD594 VA: 0xDAD594 Slot: 8
		protected override void PausableInPause()
		{
			return;
		}

		// // RVA: 0xDAD598 Offset: 0xDAD598 VA: 0xDAD598
		public void SetEnableRenerer(bool a_enable)
		{
			if (renderer != null)
				renderer.enabled = a_enable;
		}

		// // RVA: 0xDAD650 Offset: 0xDAD650 VA: 0xDAD650
		public void StopAnimation()
		{
			if(animator != null)
			{
				animator.Play(OffStateHash, -1, 1);
			}
			touchFingerId_ = -1;
		}

		// // RVA: 0xDAD768 Offset: 0xDAD768 VA: 0xDAD768 Slot: 16
		public virtual void Pause()
		{
			if(animator != null)
			{
				animator.speed = 0;
			}
		}

		// // RVA: 0xDAD820 Offset: 0xDAD820 VA: 0xDAD820 Slot: 17
		public virtual void Resume()
		{
			if(animator != null)
			{
				animator.speed = 1;
			}
		}
	}
}
