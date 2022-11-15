using UnityEngine;
using XeSys.uGUI;
using System.Collections;
using System.Collections.Generic;
using System;
using XeApp.Core;
using UnityEngine.Playables;

namespace XeApp.Game.Common
{
	public class MusicIntroObject : MonoBehaviour
	{
		private class ReleaseData
		{
			public Transform valkyrieParent; // 0x8
		}

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
		private MusicIntroMotionRef m_refData; // 0x24
		private MusicIntroEventListener m_eventListener; // 0x28
		private ReleaseData m_releaseData; // 0x2C
		private List<Animator> m_animators = new List<Animator>(4); // 0x30
		private Coroutine m_coWaitForAnimationEnd; // 0x34
		private bool isInitialized; // 0x3F

		public Action onEndAnimationCallback { private get;  set; } // 0x38
		public Action onPlayerCutInStart { set { 
			m_eventListener.onPlayerCutInStart = value;
		} } // 0xAE9020
		public bool isRunning { get; private set; } // 0x3C
		public bool isTakeoff { get; private set; } // 0x3D
		public bool isPause { get; private set; } // 0x3E

		// // RVA: 0xAE9078 Offset: 0xAE9078 VA: 0xAE9078
		public void Initialize(MusicIntroResource resource)
		{
			InstantiatePrefab(resource);
			m_animators.Clear();
			for(int i = 0; i < m_refData.animationDataNum; i++)
			{
				m_animators.Add(m_refData.GetAnimationData(i).animator);
			}
			gameObject.SetActive(false);
			m_demoCamera.enabled = false;
			for(int i = 0; i < m_animators.Count; i++)
			{
				m_animators[i].enabled = false;
			}
			m_demoCamera.transform.SetParent(m_refData.cameraRoot, false);
			m_refData.cameraRoot.gameObject.AddComponent<MayaCameraConverter>();
			m_enviroment.transform.SetParent(m_refData.enviromentRoot, false);
			m_releaseData = new ReleaseData();
			m_releaseData.valkyrieParent = m_valkyrie.transform.parent;
			MusicCameraFollower[] cf = m_runway.GetComponentsInChildren<MusicCameraFollower>(true);
			for(int i = 0; i < cf.Length; i++)
			{
				cf[i].Initialize(m_demoCamera);
			}
			isInitialized = true;
		}

		// // RVA: 0xAE970C Offset: 0xAE970C VA: 0xAE970C
		public void Begin()
		{
			if(m_coWaitForAnimationEnd != null)
			{
				StopCoroutine(m_coWaitForAnimationEnd);
			}
			MakeParent();
			gameObject.SetActive(true);
			SetAllActive(true);
			isRunning = true;
			m_valkyrie.animator.playableGraph.SetTimeUpdateMode(UnityEngine.Playables.DirectorUpdateMode.GameTime);
			if (PlayableExtensions.IsValid<Playable>(m_valkyrie.animator.playableGraph.GetRootPlayable(0)))
			{
				PlayableExtensions.SetTime<Playable>(m_valkyrie.animator.playableGraph.GetRootPlayable(0), 0);
			}
			m_valkyrie.animator.Play(IdleStateHash, 0);
			for(int i = 0; i < m_animators.Count; i++)
			{
				if(m_refData.GetAnimationData(i).hasIdle)
				{
					m_animators[i].Play(IdleStateHash, 0);
				}
			}
		}

		// // RVA: 0xAE9D34 Offset: 0xAE9D34 VA: 0xAE9D34
		public void Takeoff()
		{
			m_valkyrie.animator.CrossFadeInFixedTime(TakeoffStateHash, TakeoffFadeDuration, 0, 0);
			for(int i = 0; i < m_animators.Count; i++)
			{
				if(m_refData.GetAnimationData(i).hasTakeoff)
				{
					m_animators[i].CrossFadeInFixedTime(TakeoffStateHash, TakeoffFadeDuration, 0, 0);
				}
			}
			m_coWaitForAnimationEnd = StartCoroutine(Co_WaitForAnimationEnd());
			isTakeoff = true;
		}

		// // RVA: 0xAEA018 Offset: 0xAEA018 VA: 0xAEA018
		public void End()
		{
			if(m_coWaitForAnimationEnd != null)
			{
				StopCoroutine(m_coWaitForAnimationEnd);
			}
			gameObject.SetActive(false);
			SetAllActive(false);
			ReleaseParent();
			isRunning = false;
			isTakeoff = false;
		}

		// // RVA: 0xAEA108 Offset: 0xAEA108 VA: 0xAEA108
		public void Pause()
		{
			if(isInitialized)
			{
				for(int i = 0; i < m_animators.Count; i++)
				{
					m_animators[i].speed = 0;
				}
				isPause = true;
			}
		}

		// // RVA: 0xAEA1FC Offset: 0xAEA1FC VA: 0xAEA1FC
		// public void Resume() { }

		// // RVA: 0xAEA2F0 Offset: 0xAEA2F0 VA: 0xAEA2F0
		public void ChangeAnimationTime(double time)
		{
			return;
		}

		// // RVA: 0xAE9B14 Offset: 0xAE9B14 VA: 0xAE9B14
		private void SetAllActive(bool active)
		{
			if(isInitialized)
			{
				if(m_musicCamera != null)
				{
					m_musicCamera.enabled = !active;
				}
				m_valkyrie.Activate(active);
				m_demoCamera.enabled = active;
				for(int i = 0; i < m_animators.Count; i++)
				{
					m_animators[i].gameObject.SetActive(active);
					m_animators[i].enabled = active;
				}
			}
		}

		// // RVA: 0xAE94DC Offset: 0xAE94DC VA: 0xAE94DC
		private void InstantiatePrefab(MusicIntroResource resource)
		{
			Destroy(m_runway);
			Destroy(m_enviroment);
			m_refData = null;
			m_runway = Instantiate(resource.runwayPrefab);
			m_enviroment = Instantiate(resource.enviromentPrefab);
			m_runway.transform.SetParent(transform, false);
			m_enviroment.transform.SetParent(transform, false);
			m_refData = m_runway.GetComponent<MusicIntroMotionRef>();
			m_eventListener = m_runway.GetComponentInChildren<MusicIntroEventListener>(true);
		}

		// // RVA: 0xAE9AA4 Offset: 0xAE9AA4 VA: 0xAE9AA4
		private void MakeParent()
		{
			m_valkyrie.transform.SetParent(m_refData.valkyrieRoot, false);
		}

		// // RVA: 0xAEA08C Offset: 0xAEA08C VA: 0xAEA08C
		private void ReleaseParent()
		{
			if (m_releaseData == null)
				return;
			m_valkyrie.transform.SetParent(m_releaseData.valkyrieParent, false);
		}

		// [IteratorStateMachineAttribute] // RVA: 0x73940C Offset: 0x73940C VA: 0x73940C
		// // RVA: 0xAE9F8C Offset: 0xAE9F8C VA: 0xAE9F8C
		private IEnumerator Co_WaitForAnimationEnd()
		{
			//0xAEA490
			yield return null;

			for (int i = 0; i < m_animators.Count; i++)
			{
				while (m_animators[i].IsInTransition(0))
					yield return null;
			}

			for (int i = 0; i < m_animators.Count; i++)
			{
				AnimatorStateInfo a = m_animators[i].GetCurrentAnimatorStateInfo(0);
				while (a.normalizedTime < 1)
					yield return null;
			}
			if (onEndAnimationCallback != null)
				onEndAnimationCallback();
		}
	}
}
