using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

namespace XeApp.Game.Common
{
	public class DivaCutinObject : MonoBehaviour
	{
		private Animator animator; // 0xC
		private AnimatorOverrideController overrideController; // 0x10
		private DivaCutinResource resource; // 0x14
		private GameDivaObject divaObject; // 0x18
		private Dictionary<int, float> changeCutinFireTimes = new Dictionary<int, float>(4); // 0x1C

		// RVA: 0xE6E2F4 Offset: 0xE6E2F4 VA: 0xE6E2F4
		//public void ResetAnimationPreview() { }

		// RVA: 0xE6E2F8 Offset: 0xE6E2F8 VA: 0xE6E2F8
		public void Initialize(DivaCutinResource resource, GameDivaObject divaObject)
		{
			UnityEngine.Debug.LogError("TODO DivaCutinObject Initialize");
		}

		// RVA: 0xE6E59C Offset: 0xE6E59C VA: 0xE6E59C
		//private void SetupEventFireTime(AnimationEvent[] events) { }

		//// RVA: 0xE6E758 Offset: 0xE6E758 VA: 0xE6E758
		//public void Reset() { }

		//// RVA: 0xE6E82C Offset: 0xE6E82C VA: 0xE6E82C
		//public void ChangeCutin(int id) { }

		//// RVA: 0xE6EB88 Offset: 0xE6EB88 VA: 0xE6EB88
		public void PlayMusicAnimation()
		{
			if (animator != null)
			{
				ChangeAnimationTime(0);
				animator.Play("Music", 0);
			}
		}

		//// RVA: 0xE6EE1C Offset: 0xE6EE1C VA: 0xE6EE1C
		//public void Stop() { }

		//// RVA: 0xE6EEC8 Offset: 0xE6EEC8 VA: 0xE6EEC8
		//public void Pause() { }

		//// RVA: 0xE6EF80 Offset: 0xE6EF80 VA: 0xE6EF80
		//public void Resume() { }

		//// RVA: 0xE6EC6C Offset: 0xE6EC6C VA: 0xE6EC6C
		public void ChangeAnimationTime(double time)
		{
			if (animator != null)
			{
				animator.speed = 1;
				if (animator.playableGraph.IsValid())
				{
					animator.playableGraph.Evaluate((float)(time - PlayableExtensions.GetTime<Playable>(animator.playableGraph.GetRootPlayable(0))));
				}
			}
		}
	}
}
