using System;
using System.Collections.Generic;
using CriWare;
using UnityEngine;

namespace XeApp.Game.Common
{
	public class ValkyrieModeObject : MonoBehaviour
	{
		//private static readonly int EnterStateHash; // 0x0
		//private static readonly int MainStateHash; // 0x4
		//private static readonly int LeaveStateHash; // 0x8
		//private static readonly int FailedStateHash; // 0xC
		//private static readonly int ExEnterStateHash; // 0x10
		[SerializeField] // RVA: 0x688350 Offset: 0x688350 VA: 0x688350
		private Camera m_musicCamera; // 0xC
		[SerializeField] // RVA: 0x688360 Offset: 0x688360 VA: 0x688360
		private Camera m_modeCamera; // 0x10
		[SerializeField] // RVA: 0x688370 Offset: 0x688370 VA: 0x688370
		private GameValkyrieObject m_valkyrie; // 0x14
		private GameObject m_mainObj; // 0x18
		private ValkyrieModeMotionRef m_refData; // 0x1C
		private ValkyrieModeEventListener m_eventListener; // 0x20
		private EffectFactoryBase m_effectFactory; // 0x24
		private ValkyrieModeLockOnTarget m_lockOnTarget; // 0x28
		private List<Renderer> m_renderers = new List<Renderer>(16); // 0x2C
		private List<Animator> m_animators = new List<Animator>(3); // 0x30
		private double m_animationBaseTime = -1; // 0x38
		private bool m_resetAnimationBaseTime; // 0x40
		private bool m_isFailed; // 0x41
		private Coroutine m_coWaitForEnterEnd; // 0x44
		private Coroutine m_coWaitForAnimationEnd; // 0x48
		private CriAtomExPlayback m_flightSePlayback; // 0x4C
		private List<ParticleSystem> m_list_particle = new List<ParticleSystem>(); // 0x50
		private bool isInitialized; // 0x54
		private bool isHitEffect; // 0x55

		public Action onBeginShooting { private get; set; } // 0x58
		public Action onEndAnimationCallback { private get; set; } // 0x5C
		public Action onPlayerCutInStart { set { 
			UnityEngine.Debug.LogError("TODO onPlayerCutInStart set");
			//m_eventListener.onPlayerCutInStart = value;
		} } //0x1CE31EC
		public Action onEnemyCutInStart { set { 
			UnityEngine.Debug.LogError("TODO onEnemyCutInStart set");
			//m_eventListener.onEnemyCutInStart = value; 
		} } //0x1CE3214
		public Action onEnemyLockOnStart { set { 
			UnityEngine.Debug.LogError("TODO onEnemyLockOnStart set");
			//m_eventListener.onEnemyLockOnStart = value;
		} } //0x1CE323C
		public bool isRunning { get; private set; } // 0x60
		public bool isShootingPhase { get; private set; } // 0x61
		public bool isPause { get; private set; } // 0x62

		// RVA: 0x1CE31C8 Offset: 0x1CE31C8 VA: 0x1CE31C8
		//public void ResetAnimationPreview() { }

		// RVA: 0x1CE3294 Offset: 0x1CE3294 VA: 0x1CE3294
		private void Awake()
		{
			return;
		}

		// RVA: 0x1CE3298 Offset: 0x1CE3298 VA: 0x1CE3298
		private void OnDestroy()
		{
			UnityEngine.Debug.LogError("TODO OnDestroy");
		}

		// RVA: 0x1CE32A8 Offset: 0x1CE32A8 VA: 0x1CE32A8
		public void Initialize(ValkyrieModeResource resource, bool isDebug = false)
		{
			UnityEngine.Debug.LogError("TODO ValkyrieModeObject Initialize");
		}

		//[IteratorStateMachineAttribute] // RVA: 0x73C828 Offset: 0x73C828 VA: 0x73C828
		//// RVA: 0x1CE3C64 Offset: 0x1CE3C64 VA: 0x1CE3C64
		//private IEnumerator Co_DelayInit() { }

		//// RVA: 0x1CE3CEC Offset: 0x1CE3CEC VA: 0x1CE3CEC
		//public void Begin(bool isDebug = False) { }

		//// RVA: 0x1CE42B4 Offset: 0x1CE42B4 VA: 0x1CE42B4
		//public void SetFailed(bool failed) { }

		//// RVA: 0x1CE42BC Offset: 0x1CE42BC VA: 0x1CE42BC
		//public void SetShootLock(bool isLock) { }

		//// RVA: 0x1CE42F0 Offset: 0x1CE42F0 VA: 0x1CE42F0
		//public void Leave() { }

		//// RVA: 0x1CE4704 Offset: 0x1CE4704 VA: 0x1CE4704
		//public void End() { }

		//// RVA: 0x1CE47E4 Offset: 0x1CE47E4 VA: 0x1CE47E4
		//public void Pause() { }

		//// RVA: 0x1CE4A4C Offset: 0x1CE4A4C VA: 0x1CE4A4C
		//public void Resume() { }

		//// RVA: 0x1CE4CE0 Offset: 0x1CE4CE0 VA: 0x1CE4CE0
		//public void GetLockOnTargetPos(out Vector2 result) { }

		//// RVA: 0x1CE4DA4 Offset: 0x1CE4DA4 VA: 0x1CE4DA4
		//public void GetLockOnTargetPos(out Vector3 result) { }

		//// RVA: 0x1CE4EC0 Offset: 0x1CE4EC0 VA: 0x1CE4EC0
		//public void NotifyHit() { }

		//// RVA: 0x1CE4F64 Offset: 0x1CE4F64 VA: 0x1CE4F64
		//public void NotifyDamage() { }

		//// RVA: 0x1CE4220 Offset: 0x1CE4220 VA: 0x1CE4220
		//private void ResetAnimationBaseTime() { }

		//// RVA: 0x1CE4F9C Offset: 0x1CE4F9C VA: 0x1CE4F9C
		public void ChangeAnimationTime(double time)
		{
			UnityEngine.Debug.LogWarning("TODO ValkyrieMode ChangeAnimationTime");
		}

		//// RVA: 0x1CE401C Offset: 0x1CE401C VA: 0x1CE401C
		//private void SetAllActive(bool active) { }

		//// RVA: 0x1CE3660 Offset: 0x1CE3660 VA: 0x1CE3660
		//private void InstantiatePrefab(ValkyrieModeResource resource) { }

		//// RVA: 0x1CE3B58 Offset: 0x1CE3B58 VA: 0x1CE3B58
		//private void MakeCameraParent() { }

		//[IteratorStateMachineAttribute] // RVA: 0x73C8A0 Offset: 0x73C8A0 VA: 0x73C8A0
		//// RVA: 0x1CE422C Offset: 0x1CE422C VA: 0x1CE422C
		//private IEnumerator Co_WaitForEnterEnd() { }

		//[IteratorStateMachineAttribute] // RVA: 0x73C918 Offset: 0x73C918 VA: 0x73C918
		//// RVA: 0x1CE467C Offset: 0x1CE467C VA: 0x1CE467C
		//private IEnumerator Co_WaitForAnimationEnd() { }

		// RVA: 0x1CE53A8 Offset: 0x1CE53A8 VA: 0x1CE53A8
		static ValkyrieModeObject()
		{
			UnityEngine.Debug.LogError("TODO static ValkyrieModeObject");
		}
	}
}
