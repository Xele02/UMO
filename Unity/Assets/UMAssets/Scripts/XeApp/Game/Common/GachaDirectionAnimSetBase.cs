using System;
using System.Collections;
using UnityEngine;
using XeApp.Game.Gacha;

namespace XeApp.Game.Common
{
	public class GachaDirectionAnimSetBase : MonoBehaviour
	{
		[SerializeField]
		private Animator m_animator; // 0xC
		private Coroutine m_coWaitForAnimationEnd; // 0x14

		protected Animator animator { get { return m_animator; } } //0x1C14B5C
		protected GachaDirectionEffectFactory effectFactory { get; private set; } // 0x10

		// RVA: 0x1C14B74 Offset: 0x1C14B74 VA: 0x1C14B74
		private void Awake()
		{
			effectFactory = GetComponent<GachaDirectionEffectFactory>();
			if(effectFactory != null)
			{
				effectFactory.Instantiate();
			}
			OnAwake();
		}

		// // RVA: 0x1C14C54 Offset: 0x1C14C54 VA: 0x1C14C54 Slot: 4
		protected virtual void OnAwake()
		{
			return;
		}

		// // RVA: 0x1C14C58 Offset: 0x1C14C58 VA: 0x1C14C58
		public void Setup(DirectionInfo directionInfo)
		{
			if(effectFactory != null)
			{
				effectFactory.Setup();
			}
			OnSetup(directionInfo);
		}

		// // RVA: 0x1C14D24 Offset: 0x1C14D24 VA: 0x1C14D24 Slot: 5
		protected virtual void OnSetup(DirectionInfo directionInfo)
		{
			return;
		}

		// // RVA: 0x1C14D28 Offset: 0x1C14D28 VA: 0x1C14D28
		protected void WaitForAnimationEnd(Action onEndAnimation)
		{
			if(m_coWaitForAnimationEnd != null)
			{
				this.StopCoroutine(m_coWaitForAnimationEnd);
			}
			m_coWaitForAnimationEnd = this.StartCoroutineWatched(Co_WaitForAnimationEnd(onEndAnimation));
		}

		// [IteratorStateMachineAttribute] // RVA: 0x7383D0 Offset: 0x7383D0 VA: 0x7383D0
		// // RVA: 0x1C14D74 Offset: 0x1C14D74 VA: 0x1C14D74
		private IEnumerator Co_WaitForAnimationEnd(Action onEndAnimation)
		{
			//0x1C14E48
			yield return null;
			while(m_animator.IsInTransition(0))
				yield return null;
			while(m_animator.GetCurrentAnimatorStateInfo(0).normalizedTime < 1)
				yield return null;
			if(onEndAnimation != null)
				onEndAnimation();
			m_coWaitForAnimationEnd = null;
		}
	}
}
