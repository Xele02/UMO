using System;
using UnityEngine;
using System.Collections.Generic;

namespace XeApp.Game.Common
{
	public class MusicIntroMotionRef : MotionRefBase
	{
		[Serializable]
		public class AnimationData : MotionRefBase.BaseData
		{
			[SerializeField]
			private bool m_hasIdle; // 0xC
			[SerializeField]
			private bool m_hasTakeoff; // 0xD

			public bool hasIdle { get { return m_hasIdle; } } //0xAE9000
			public bool hasTakeoff { get { return m_hasTakeoff; } } //0xAE9008

			// RVA: 0xAE8F0C Offset: 0xAE8F0C VA: 0xAE8F0C
			public AnimationData(Animator animator, bool hasIdle, bool hasTakeoff) : base(default(Animator))
			{
				m_hasTakeoff = hasTakeoff;
				m_hasIdle = hasIdle;
			}

		}

		public static readonly string IdleStateName = "Idle"; // 0x0
		public static readonly string TakeoffStateName = "Takeoff"; // 0x4
		public static readonly int IdleStateHash = Animator.StringToHash(IdleStateName); // 0x8
		public static readonly int TakeoffStateHash = Animator.StringToHash(TakeoffStateName); // 0xC
		[SerializeField]
		private Transform m_cameraRoot; // 0xC
		[SerializeField]
		private Transform m_enviromentRoot; // 0x10
		[SerializeField]
		private Transform m_valkyrieRoot; // 0x14
		[SerializeField]
		private List<MusicIntroMotionRef.AnimationData> m_animationDatas; // 0x18

		public Transform cameraRoot { get { return m_cameraRoot; } } //0xAE8AF8
		public Transform enviromentRoot { get { return m_enviromentRoot; } } //0xAE8B00
		public Transform valkyrieRoot { get { return m_valkyrieRoot; } } //0xAE8B08
		public override int animationDataNum { get { return m_animationDatas.Count; } } //0xAE8B10

		// // RVA: 0xAE8B88 Offset: 0xAE8B88 VA: 0xAE8B88
		public AnimationData GetAnimationData(int index)
		{
			return m_animationDatas[index];
		}

		// // RVA: 0xAE8C08 Offset: 0xAE8C08 VA: 0xAE8C08 Slot: 5
		protected override Animator GetAnimator(int index)
		{
			return GetAnimationData(index).animator;
		}

		// // RVA: 0xAE8CA8 Offset: 0xAE8CA8 VA: 0xAE8CA8 Slot: 6
		// protected override void ResetAnimationData(Func<Animator, int, int, bool> hasStateMachine) { }
	}
}
