using System;
using UnityEngine;
using System.Collections.Generic;

namespace XeApp.Game.Common
{
	public class ValkyrieModeMotionRef : MotionRefBase
	{
		[Serializable]
		public class AnimationData : BaseData
		{
			[SerializeField]
			private bool m_hasEnter; // 0xC
			[SerializeField]
			private bool m_hasMain; // 0xD
			[SerializeField]
			private bool m_hasLeave; // 0xE
			[SerializeField]
			private bool m_hasFailed; // 0xF

			//public bool hasEnter { get; } 0x1CE31A8
			//public bool hasMain { get; } 0x1CE31B0
			//public bool hasLeave { get; } 0x1CE31B8
			//public bool hasFailed { get; } 0x1CE31C0

			// RVA: 0x1CE3008 Offset: 0x1CE3008 VA: 0x1CE3008
			public AnimationData(Animator animator, bool hasEnter, bool hasMain, bool hasLeave, bool hasFailed) : base(animator)
			{
				m_hasMain = hasMain;
				m_hasEnter = hasEnter;
				m_hasLeave = hasLeave;
				m_hasFailed = hasFailed;
			}
		}

		public static readonly string EnterStateName = "Begin"; // 0x0
		public static readonly string MainStateName = "Main"; // 0x4
		public static readonly string LeaveStateName = "End"; // 0x8
		public static readonly string FailedStateName = "Failed"; // 0xC
		public static readonly int EnterStateHash = Animator.StringToHash(EnterStateName); // 0x10
		public static readonly int MainStateHash = Animator.StringToHash(MainStateName); // 0x14
		public static readonly int LeaveStateHash = Animator.StringToHash(LeaveStateName); // 0x18
		public static readonly int FailedStateHash = Animator.StringToHash(FailedStateName); // 0x1C
		public static readonly string ExEnterStateName = "ExBegin"; // 0x20
		public static readonly int ExEnterStateHash = Animator.StringToHash(ExEnterStateName); // 0x24
		[SerializeField]
		private Transform m_cameraRoot; // 0xC
		[SerializeField]
		//[TooltipAttribute] // RVA: 0x688240 Offset: 0x688240 VA: 0x688240
		private Transform m_lockOnTarget; // 0x10
		[SerializeField]
		//[TooltipAttribute] // RVA: 0x6882A4 Offset: 0x6882A4 VA: 0x6882A4
		private Transform m_shootToTarget; // 0x14
		[SerializeField]
		private List<AnimationData> m_animationDatas; // 0x18

		public Transform cameraRoot { get { return m_cameraRoot; } } //0x1CE2B18
		public Transform lockOnTarget { get { return m_lockOnTarget; } } //0x1CE2B20
		public Transform shootToTarget { get { return m_shootToTarget; } } //0x1CE2B28
		public override int animationDataNum { get { return m_animationDatas.Count; } } //0x1CE2B30

		//// RVA: 0x1CE2BA8 Offset: 0x1CE2BA8 VA: 0x1CE2BA8
		public AnimationData GetAnimationData(int index)
		{
			return m_animationDatas[index];
		}

		//// RVA: 0x1CE2C28 Offset: 0x1CE2C28 VA: 0x1CE2C28 Slot: 5
		protected override Animator GetAnimator(int index)
		{
			return m_animationDatas[index].animator;
		}

		//// RVA: 0x1CE2CC8 Offset: 0x1CE2CC8 VA: 0x1CE2CC8 Slot: 6
		//protected override void ResetAnimationData(Func<Animator, int, int, bool> hasStateMachine) { }
	}
}
