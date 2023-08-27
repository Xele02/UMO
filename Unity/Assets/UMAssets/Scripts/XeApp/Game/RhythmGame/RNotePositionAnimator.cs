using UnityEngine;
using XeApp.Game.Common;

namespace XeApp.Game.RhythmGame
{
	public class RNotePositionAnimator
	{
		public struct AnimData
		{
			public Vector3 localPosition; // 0x0
			public float localScale; // 0xC
		}

		private static readonly int stepDivid = 50; // 0x0
		private static readonly float stepRate = 1.0f / stepDivid; // 0x4
		private static readonly string[] animNameList = new string[10] { "line_animation_0", "line_animation_1", "line_animation_2", "line_animation_3", "line_animation_4",
					"line_animation_5", "line_animation_6", "line_animation_7", "line_animation_8", "line_animation_9" }; // 0x8
		private static readonly string[] animNameListAdjust = new string[1] { "line_animation_adjust" }; // 0xC
		private static AnimData[,] animData = null; // 0x10
		private static AnimData[] animDataJustTime = null; // 0x14
		private static readonly float justNormalizeTime_ = 1.0f/1.2f; // 0x18
		private static int[] animHashCode; // 0x1C
		private RNote rNote; // 0x8
		private Animator animator; // 0xC
		private AnimData animDataWork; // 0x10

		public float justNormalizeTime { get { return justNormalizeTime_; } private set { return;} } //0xDAD380 0xDBC674

		// RVA: 0xDB38BC Offset: 0xDB38BC VA: 0xDB38BC
		public static void InitializeAnim()
		{
			animHashCode = new int[RhythmGameConsts.LineNum];
			for(int i = 0; i < RhythmGameConsts.LineNum; i++)
			{
				animHashCode[i] = Animator.StringToHash(animNameList[i]);
			}
		}

		// RVA: 0xDADF14 Offset: 0xDADF14 VA: 0xDADF14
		public RNotePositionAnimator(Animator animator)
		{
			this.animator = animator;
		}

		//// RVA: 0xDB3AA0 Offset: 0xDB3AA0 VA: 0xDB3AA0
		public void SetRuntimeAnimatorController(RuntimeAnimatorController rac)
		{
			animator.runtimeAnimatorController = rac;
		}

		//// RVA: 0xDB3AD4 Offset: 0xDB3AD4 VA: 0xDB3AD4
		public void PrecalculationSampleAnim(GameObject samplingObject, bool isAdjust)
		{
			int step = stepDivid;
			int numLines = 0;
			string[] anims = null;
			if (isAdjust)
			{
				anims = animNameListAdjust;
				numLines = 1;
			}
			else
			{
				numLines = RhythmGameConsts.LineNum;
				anims = animNameList;
			}
			AnimationClip[] clips = new AnimationClip[numLines];
			for(int i = 0; i < numLines; i++)
			{
				for(int j = 0; j < animator.runtimeAnimatorController.animationClips.Length; j++)
				{
					if(animator.runtimeAnimatorController.animationClips[j].name == anims[i])
					{
						clips[i] = animator.runtimeAnimatorController.animationClips[j];
						break;
					}
				}
			}
			animData = new AnimData[numLines, stepDivid + 1];
			for(int i = 0; i < numLines; i++)
			{
				for (int j = 0; j <= stepDivid; j++)
				{
					clips[i].SampleAnimation(samplingObject, 1.0f / stepDivid * clips[i].length * j);
					animData[i, j].localPosition = samplingObject.transform.localPosition;
					animData[i, j].localScale = samplingObject.transform.localScale.x;
				}
			}
			animDataJustTime = new AnimData[numLines];
			for(int i = 0; i < numLines; i++)
			{
				CalcAnimationData(i, justNormalizeTime, out animDataJustTime[i]);
			}
		}

		//// RVA: 0xDAE074 Offset: 0xDAE074 VA: 0xDAE074
		public void Initialize(RNote rNote)
		{
			this.rNote = rNote;
			UpdateTransform();
		}

		//// RVA: 0xDAE310 Offset: 0xDAE310 VA: 0xDAE310
		public bool IsBeyondJudgePoint()
		{
			return rNote.positionRate >= 1.0f;
		}

		//// RVA: 0xDAE1AC Offset: 0xDAE1AC VA: 0xDAE1AC
		public void UpdateTransform()
		{
			animator.enabled = false;
			CalcAnimationData(CalcNormalizeAnimationTime(), out animDataWork);
			animator.transform.localPosition = animDataWork.localPosition;
			animator.transform.localScale = Vector3.one * animDataWork.localScale;
		}

		//// RVA: 0xDAD40C Offset: 0xDAD40C VA: 0xDAD40C
		public float CalcNormalizeAnimationTime()
		{
			return Mathf.Max(0, rNote.positionRate * justNormalizeTime);
		}

		//// RVA: 0xDAD4D4 Offset: 0xDAD4D4 VA: 0xDAD4D4
		public void CalcAnimationData(float normalize_time, out RNotePositionAnimator.AnimData ad)
		{
			CalcAnimationData(rNote.GetLineNo(), normalize_time, out ad);
		}

		//// RVA: 0xDBC678 Offset: 0xDBC678 VA: 0xDBC678
		private static void CalcAnimationData(int lineNo, float normalize_time, out AnimData ad)
		{
			float f = normalize_time * stepDivid;
			if(normalize_time >= 1)
			{
				ad.localPosition = animData[lineNo, stepDivid - 1].localPosition;
				ad.localScale = animData[lineNo, stepDivid - 1].localScale;
			}
			else
			{
				ad.localPosition = Vector3.Lerp(animData[lineNo, (int)f].localPosition, animData[lineNo, (int)f + 1].localPosition, (normalize_time - stepRate * (int)f) * stepDivid);
				ad.localScale = Mathf.Lerp(animData[lineNo, (int)f].localScale, animData[lineNo, (int)f + 1].localScale, (normalize_time - stepRate * (int)f) * stepDivid);
			}
		}

		//// RVA: 0xDBCAE8 Offset: 0xDBCAE8 VA: 0xDBCAE8
		public static RNotePositionAnimator.AnimData GetJustAnimationData(int lineNo)
		{
			return animDataJustTime[lineNo];
		}
	}
}
