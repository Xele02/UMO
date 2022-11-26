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
			this.resource = resource;
			this.divaObject = divaObject;
			if(resource != null)
			{
				animator = GetComponent<Animator>();
				animator.runtimeAnimatorController = resource.animatorController;
				overrideController = new AnimatorOverrideController();
				overrideController.name = "dr_dc_override_controller";
				overrideController.runtimeAnimatorController = animator.runtimeAnimatorController;
				SetupEventFireTime(resource.clip.events);
				overrideController["dr_dc_cmn_animation"] = resource.clip;
				animator.runtimeAnimatorController = overrideController;
				divaObject.OverrideCutinClip(resource);
				animator.playableGraph.SetTimeUpdateMode(DirectorUpdateMode.Manual);
				animator.Rebind();
			}
		}

		// RVA: 0xE6E59C Offset: 0xE6E59C VA: 0xE6E59C
		private void SetupEventFireTime(AnimationEvent[] events)
		{
			changeCutinFireTimes.Clear();
			for(int i = 0; i < events.Length; i++)
			{
				if(events[i].functionName == "ChangeCutin")
				{
					changeCutinFireTimes.Add(events[i].intParameter, events[i].time);
				}
			}
		}

		//// RVA: 0xE6E758 Offset: 0xE6E758 VA: 0xE6E758
		//public void Reset() { }

		//// RVA: 0xE6E82C Offset: 0xE6E82C VA: 0xE6E82C
		public void ChangeCutin(int id)
		{
			if(id > 0)
			{
				if(id <= resource.cutinBodyClips.Length)
				{
					if(divaObject != null)
					{
						if (resource != null)
						{
							bool hasBody = resource.cutinBodyClips[id - 1] != null;
							bool hasFace = resource.cutinFaceClips[id - 1] != null;
							bool hasMouth = resource.cutinMouthClips[id - 1] != null;
							bool hasMike = resource.cutinMikeClips[id - 1] != null;
							if (hasBody || hasFace || hasMouth || hasMike)
							{
								divaObject.PlayCutinAnimation(id, hasBody, hasFace, hasMouth, hasMike, changeCutinFireTimes[id]);
							}
						}
					}
				}
			}
		}

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
		public void Pause()
		{
			if (animator != null)
				animator.speed = 0;
		}

		//// RVA: 0xE6EF80 Offset: 0xE6EF80 VA: 0xE6EF80
		public void Resume()
		{
			if (animator != null)
				animator.speed = 1;
		}

		//// RVA: 0xE6EC6C Offset: 0xE6EC6C VA: 0xE6EC6C
		public void ChangeAnimationTime(double time)
		{
			if (animator != null)
			{
				animator.speed = 1;
				if (PlayableExtensions.IsValid<Playable>(animator.playableGraph.GetRootPlayable(0)))
				{
					animator.playableGraph.Evaluate((float)(time - PlayableExtensions.GetTime<Playable>(animator.playableGraph.GetRootPlayable(0))));
				}
			}
		}
	}
}
