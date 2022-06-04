using UnityEngine;
using XeSys.uGUI;
using System.Collections;
using System.Collections.Generic;
using System;

namespace XeApp.Game.Common
{
	public class MusicIntroObject : MonoBehaviour
	{
		private static readonly int IdleStateHash; // 0x0
		private static readonly int TakeoffStateHash; // 0x4
		private static readonly float TakeoffFadeDuration; // 0x8
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
		// private MusicIntroEventListener m_eventListener; // 0x28
		// private ReleaseData m_releaseData; // 0x2C
		private List<Animator> m_animators; // 0x30
		private Coroutine m_coWaitForAnimationEnd; // 0x34
		// [CompilerGeneratedAttribute] // RVA: 0x687830 Offset: 0x687830 VA: 0x687830
		// private Action <onEndAnimationCallback>k__BackingField; // 0x38
		// [CompilerGeneratedAttribute] // RVA: 0x687840 Offset: 0x687840 VA: 0x687840
		// private bool <isRunning>k__BackingField; // 0x3C
		// [CompilerGeneratedAttribute] // RVA: 0x687850 Offset: 0x687850 VA: 0x687850
		// private bool <isTakeoff>k__BackingField; // 0x3D
		// [CompilerGeneratedAttribute] // RVA: 0x687860 Offset: 0x687860 VA: 0x687860
		// private bool <isPause>k__BackingField; // 0x3E
		private bool isInitialized; // 0x3F

		// Properties
		private Action onEndAnimationCallback { get; set; }
		public Action onPlayerCutInStart { set {} }
		public bool isRunning { get; set; }
		public bool isTakeoff { get; set; }
		public bool isPause { get; set; }

		// Methods

		// [CompilerGeneratedAttribute] // RVA: 0x73938C Offset: 0x73938C VA: 0x73938C
		// // RVA: 0xAE9010 Offset: 0xAE9010 VA: 0xAE9010
		// private Action get_onEndAnimationCallback() { }

		// [CompilerGeneratedAttribute] // RVA: 0x73939C Offset: 0x73939C VA: 0x73939C
		// // RVA: 0xAE9018 Offset: 0xAE9018 VA: 0xAE9018
		// public void set_onEndAnimationCallback(Action value) { }

		// // RVA: 0xAE9020 Offset: 0xAE9020 VA: 0xAE9020
		// public void set_onPlayerCutInStart(Action value) { }

		// [CompilerGeneratedAttribute] // RVA: 0x7393AC Offset: 0x7393AC VA: 0x7393AC
		// // RVA: 0xAE9048 Offset: 0xAE9048 VA: 0xAE9048
		// public bool get_isRunning() { }

		// [CompilerGeneratedAttribute] // RVA: 0x7393BC Offset: 0x7393BC VA: 0x7393BC
		// // RVA: 0xAE9050 Offset: 0xAE9050 VA: 0xAE9050
		// private void set_isRunning(bool value) { }

		// [CompilerGeneratedAttribute] // RVA: 0x7393CC Offset: 0x7393CC VA: 0x7393CC
		// // RVA: 0xAE9058 Offset: 0xAE9058 VA: 0xAE9058
		// public bool get_isTakeoff() { }

		// [CompilerGeneratedAttribute] // RVA: 0x7393DC Offset: 0x7393DC VA: 0x7393DC
		// // RVA: 0xAE9060 Offset: 0xAE9060 VA: 0xAE9060
		// private void set_isTakeoff(bool value) { }

		// [CompilerGeneratedAttribute] // RVA: 0x7393EC Offset: 0x7393EC VA: 0x7393EC
		// // RVA: 0xAE9068 Offset: 0xAE9068 VA: 0xAE9068
		// public bool get_isPause() { }

		// [CompilerGeneratedAttribute] // RVA: 0x7393FC Offset: 0x7393FC VA: 0x7393FC
		// // RVA: 0xAE9070 Offset: 0xAE9070 VA: 0xAE9070
		// private void set_isPause(bool value) { }

		// // RVA: 0xAE9078 Offset: 0xAE9078 VA: 0xAE9078
		// public void Initialize(MusicIntroResource resource) { }

		// // RVA: 0xAE970C Offset: 0xAE970C VA: 0xAE970C
		public void Begin()
		{
			UnityEngine.Debug.LogError("TODO");
		}

		// // RVA: 0xAE9D34 Offset: 0xAE9D34 VA: 0xAE9D34
		public void Takeoff()
		{
			UnityEngine.Debug.LogError("TODO");
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

		// // RVA: 0xAEA324 Offset: 0xAEA324 VA: 0xAEA324
		// public void .ctor() { }

		// // RVA: 0xAEA3B4 Offset: 0xAEA3B4 VA: 0xAEA3B4
		// private static void .cctor() { }
	}
}
