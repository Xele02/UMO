using UnityEngine;
using System;

namespace XeApp.Game.Common
{
	public class MotionRefBase : MonoBehaviour
	{
		[Serializable]
		public class BaseData
		{
			[SerializeField]
			private Animator m_animator; // 0x8

			public Animator animator { get { return m_animator; } } // 0x1118764

			// RVA: 0x111876C Offset: 0x111876C VA: 0x111876C
			public BaseData(Animator animator)
			{
				m_animator = animator;
			}
		}

		public virtual int animationDataNum { get { return 0; } } //0x1118748

		//// RVA: 0x1118750 Offset: 0x1118750 VA: 0x1118750 Slot: 5
		protected virtual Animator GetAnimator(int index)
		{
			return null;
		}

		//// RVA: 0x1118758 Offset: 0x1118758 VA: 0x1118758 Slot: 6
		//protected virtual void ResetAnimationData(Func<Animator, int, int, bool> hasStateMachine) { }
	}
}
