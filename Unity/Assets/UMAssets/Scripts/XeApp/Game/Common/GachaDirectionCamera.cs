using UnityEngine;

namespace XeApp.Game.Common
{
	public class GachaDirectionCamera : GachaDirectionAnimSetBase
	{
		private static readonly int State_Enter = Animator.StringToHash("Start_Enter"); // 0x0
		private static readonly int State_Idle = Animator.StringToHash("Start_Idle"); // 0x4
		private static readonly int State_Leave = Animator.StringToHash("Start_Leave"); // 0x8
		private static readonly int State_Result = Animator.StringToHash("Start_Result"); // 0xC
		private static readonly int State_Retry = Animator.StringToHash("Start_Retry"); // 0x10
		private static readonly int State_Quartz = Animator.StringToHash("Quartz_Main"); // 0x14
		private static readonly int Param_ToLeave = Animator.StringToHash("toLeave"); // 0x18
		[SerializeField]
		private Camera m_camera; // 0x18

		// RVA: 0x1C15054 Offset: 0x1C15054 VA: 0x1C15054
		public void Initialize(GachaDirectionResource resource)
		{
			animator.runtimeAnimatorController = resource.cameraAnimator;
		}

		// RVA: 0x1C150A4 Offset: 0x1C150A4 VA: 0x1C150A4
		public void Start_Enter(bool isRetry, bool isPaid)
		{
			animator.SetBool("isPaid", isPaid);
			if(isRetry)
			{
				animator.Play(State_Retry, 0, 0);
			}
			else
			{
				animator.Play(State_Enter, 0, 0);
			}
			WaitForAnimationEnd(() =>
			{
				//0x1C15690
				animator.Play(State_Idle, 0, 0);
			});
		}

		// RVA: 0x1C1522C Offset: 0x1C1522C VA: 0x1C1522C
		public void Start_Leave()
		{
			animator.SetTrigger(Param_ToLeave);
		}

		// RVA: 0x1C152E0 Offset: 0x1C152E0 VA: 0x1C152E0
		public void Quartz_Begin()
		{
			animator.Play(State_Quartz, 0, 0);
		}

		// RVA: 0x1C153A8 Offset: 0x1C153A8 VA: 0x1C153A8
		public void Card_Begin()
		{
			animator.Play(State_Quartz, 0, 1);
		}

		// RVA: 0x1C15470 Offset: 0x1C15470 VA: 0x1C15470
		public void Start_Result()
		{
			animator.Play(State_Result, 0, 0);
		}
	}
}
