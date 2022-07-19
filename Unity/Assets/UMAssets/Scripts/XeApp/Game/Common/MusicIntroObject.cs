using UnityEngine;
using XeSys.uGUI;
using System.Collections;
using System.Collections.Generic;
using System;

namespace XeApp.Game.Common
{
	public class MusicIntroObject : MonoBehaviour
	{
		private static readonly int IdleStateHash = MusicIntroMotionRef.IdleStateHash; // 0x0
		private static readonly int TakeoffStateHash = MusicIntroMotionRef.TakeoffStateHash; // 0x4
		private static readonly float TakeoffFadeDuration = 0.0833333f; // 0x8
		[SerializeField] // RVA: 0x6877F0 Offset: 0x6877F0 VA: 0x6877F0
		private Camera m_musicCamera; // 0xC
		[SerializeField] // RVA: 0x687800 Offset: 0x687800 VA: 0x687800
		private Camera m_demoCamera; // 0x10
		[SerializeField] // RVA: 0x687810 Offset: 0x687810 VA: 0x687810
		private GameValkyrieObject m_valkyrie; // 0x14
		[SerializeField] // RVA: 0x687820 Offset: 0x687820 VA: 0x687820
		private UGUIFader fader; // 0x18
		private GameObject m_runway; // 0x1C
		private GameObject m_enviroment; // 0x20
		// private MusicIntroMotionRef m_refData; // 0x24
		private MusicIntroEventListener m_eventListener; // 0x28
		// private ReleaseData m_releaseData; // 0x2C
		private List<Animator> m_animators = new List<Animator>(4); // 0x30
		private Coroutine m_coWaitForAnimationEnd; // 0x34
		private bool isInitialized; // 0x3F

		public Action onEndAnimationCallback { private get;  set; } // 0x38
		public Action onPlayerCutInStart { set { m_eventListener.onPlayerCutInStart = value; } } // 0xAE9020
		public bool isRunning { get; private set; } // 0x3C
		public bool isTakeoff { get; private set; } // 0x3D
		public bool isPause { get; private set; } // 0x3E

		// // RVA: 0xAE9078 Offset: 0xAE9078 VA: 0xAE9078
		public void Initialize(MusicIntroResource resource)
		{
			UnityEngine.Debug.LogError("TODO MusicIntroObject Initialize");
		}

		// // RVA: 0xAE970C Offset: 0xAE970C VA: 0xAE970C
		public void Begin()
		{
			UnityEngine.Debug.LogError("TODO MusicIntroObject Begin");
		}

		// // RVA: 0xAE9D34 Offset: 0xAE9D34 VA: 0xAE9D34
		public void Takeoff()
		{
			UnityEngine.Debug.LogError("TODO MusicIntroObject Takeoff");
		}

		// // RVA: 0xAEA018 Offset: 0xAEA018 VA: 0xAEA018
		// public void End() { }

		// // RVA: 0xAEA108 Offset: 0xAEA108 VA: 0xAEA108
		// public void Pause() { }

		// // RVA: 0xAEA1FC Offset: 0xAEA1FC VA: 0xAEA1FC
		// public void Resume() { }

		// // RVA: 0xAEA2F0 Offset: 0xAEA2F0 VA: 0xAEA2F0
		// public void ChangeAnimationTime(double time) { }

		// // RVA: 0xAE9B14 Offset: 0xAE9B14 VA: 0xAE9B14
		// private void SetAllActive(bool active) { }

		// // RVA: 0xAE94DC Offset: 0xAE94DC VA: 0xAE94DC
		// private void InstantiatePrefab(MusicIntroResource resource) { }

		// // RVA: 0xAE9AA4 Offset: 0xAE9AA4 VA: 0xAE9AA4
		// private void MakeParent() { }

		// // RVA: 0xAEA08C Offset: 0xAEA08C VA: 0xAEA08C
		// private void ReleaseParent() { }

		// [IteratorStateMachineAttribute] // RVA: 0x73940C Offset: 0x73940C VA: 0x73940C
		// // RVA: 0xAE9F8C Offset: 0xAE9F8C VA: 0xAE9F8C
		// private IEnumerator Co_WaitForAnimationEnd() { }
	}
}
