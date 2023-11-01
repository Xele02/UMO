using System;
using mcrs;
using UnityEngine;
using XeApp.Game.Gacha;

namespace XeApp.Game.Common
{
	public class GachaDirectionStartSet : GachaDirectionAnimSetBase
	{
		private static readonly int State_Enter = Animator.StringToHash("Start_Enter"); // 0x0
		private static readonly int State_Idle = Animator.StringToHash("Start_Idle"); // 0x4
		private static readonly int State_Leave = Animator.StringToHash("Start_Leave"); // 0x8
		private static readonly int State_Result = Animator.StringToHash("Start_Result"); // 0xC
		private static readonly int State_Retry = Animator.StringToHash("Start_Retry"); // 0x10
		private static readonly int Param_ToLeave = Animator.StringToHash("toLeave"); // 0x14
		[SerializeField]
		private Transform m_valkyrieRoot; // 0x18
		private GachaDirectionOrb m_orb; // 0x1C

		public Action onEndEnterAnim { private get; set; } // 0x20
		public Action onEndLeaveAnim { private get; set; } // 0x24
		public Transform valkyrieRoot { get { return m_valkyrieRoot; } } //0x1C1C460

		// // RVA: 0x1C22D80 Offset: 0x1C22D80 VA: 0x1C22D80 Slot: 5
		protected override void OnSetup(DirectionInfo directionInfo)
		{
			gameObject.SetActive(false);
			m_orb = GetComponentInChildren<GachaDirectionOrb>(true);
			m_orb.Setup(directionInfo.auraColor != AuraColorType.Blue ? GachaDirectionOrb.ColorType.Gold : GachaDirectionOrb.ColorType.Blue);
		}

		// // RVA: 0x1C1C078 Offset: 0x1C1C078 VA: 0x1C1C078
		public void Begin(bool isRetry = false)
		{
			SoundManager.Instance.sePlayerGacha.Play((int)cs_se_gacha.SE_GACHA_000);
			gameObject.SetActive(true);
			if(isRetry)
			{
				animator.Play(State_Retry, 0, 0);
			}
			else
			{
				animator.Play(State_Enter, 0, 0);
			}
			effectFactory.EmitStart("Gacha_orb");
			m_orb.Begin(isRetry);
			WaitForAnimationEnd(() =>
			{
				//0x1C22F94
				if(onEndEnterAnim != null)
					onEndEnterAnim();
				animator.Play(State_Idle, 0, 0);
			});
		}

		// // RVA: 0x1C1C31C Offset: 0x1C1C31C VA: 0x1C1C31C
		public void Leave()
		{
			SoundManager.Instance.sePlayerGacha.Play((int)cs_se_gacha.SE_GACHA_002);
			animator.SetTrigger(Param_ToLeave);
			WaitForAnimationEnd(() =>
			{
				//0x1C23070
				if(onEndLeaveAnim != null)
					onEndLeaveAnim();
			});
		}

		// // RVA: 0x1C1CA70 Offset: 0x1C1CA70 VA: 0x1C1CA70
		public void End()
		{
			gameObject.SetActive(false);
		}

		// // RVA: 0x1C1D308 Offset: 0x1C1D308 VA: 0x1C1D308
		public void Result()
		{
			gameObject.SetActive(true);
			animator.Play(State_Result, 0, 0);
			effectFactory.Disable("Gacha_orb");
		}

		// // RVA: 0x1C1C468 Offset: 0x1C1C468 VA: 0x1C1C468
		public void NotifyOrbFlash()
		{
			m_orb.NotifyFlash();
		}

		// // RVA: 0x1C1C490 Offset: 0x1C1C490 VA: 0x1C1C490
		public void NotifyOrbChange()
		{
			m_orb.NotifyChange();
		}
	}
}
