using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

namespace XeApp.Game.Common
{
	public class MusicCameraCutinObject : MonoBehaviour
	{
		private Animator animator; // 0xC
		private AnimatorOverrideController overrideController; // 0x10
		private MusicCameraCutinResource resource; // 0x14
		private MusicCameraObject cameraObject; // 0x18
		private Dictionary<int, float> changeCutinFireTimes = new Dictionary<int, float>(4); // 0x1C
		private int resourceId; // 0x20

		// RVA: 0x1119694 Offset: 0x1119694 VA: 0x1119694
		//public void ResetAnimationPreview() { }

		// RVA: 0x1119698 Offset: 0x1119698 VA: 0x1119698
		public void Initialize(MusicCameraCutinResource resource, MusicCameraObject cameraObject, int resourceId = 0)
		{
			this.cameraObject = cameraObject;
			this.resource = resource;
			this.resourceId = resourceId;
			if(resource == null)
			{
				overrideController = null;
				if(animator != null)
				{
					animator.runtimeAnimatorController = null;
				}
				animator = null;
			}
			else
			{
				animator = GetComponent<Animator>();
				animator.runtimeAnimatorController = resource.animatorController;
				overrideController = new AnimatorOverrideController();
				overrideController.name = "dr_cc_override_controller";
				overrideController.runtimeAnimatorController = animator.runtimeAnimatorController;
				SetupEventFireTime(resource.clip.events);
				overrideController["dr_cc_cmn_animation"] = resource.clip;
				animator.runtimeAnimatorController = overrideController;
				cameraObject.OverrideCutinClip(resource, resourceId);
				animator.playableGraph.SetTimeUpdateMode(DirectorUpdateMode.Manual);
			}
		}

		// RVA: 0x11199A4 Offset: 0x11199A4 VA: 0x11199A4
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

		//// RVA: 0x1119B60 Offset: 0x1119B60 VA: 0x1119B60
		public void ChangeCutin(int id)
		{
			if(id > 0)
			{
				if(id <= resource.cutinClips.Length)
				{
					if(cameraObject != null)
					{
						if(resource != null)
						{
							if(resource.cutinClips[id - 1] != null)
							{
								cameraObject.PlayCutinAnimation(id, changeCutinFireTimes[id], resourceId);
							}
						}
					}
				}
			}
		}

		//// RVA: 0x1119D80 Offset: 0x1119D80 VA: 0x1119D80
		public void PlayMusicAnimation()
		{
			if (animator != null)
			{
				ChangeAnimationTime(0);
				animator.Play("Music", 0);
			}
		}

		//// RVA: 0x111A014 Offset: 0x111A014 VA: 0x111A014
		//public void Stop() { }

		//// RVA: 0x111A0C0 Offset: 0x111A0C0 VA: 0x111A0C0
		//public void Pause() { }

		//// RVA: 0x111A178 Offset: 0x111A178 VA: 0x111A178
		//public void Resume() { }

		//// RVA: 0x1119E64 Offset: 0x1119E64 VA: 0x1119E64
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
