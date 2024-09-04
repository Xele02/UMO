using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

namespace XeApp.Game.Common
{
	public class StageLightingAddObject : MonoBehaviour
	{
		private enum ControlType
		{
			DivaColor = 0,
			DivaRimColor = 1,
			DivaRimPower = 2,
			ShadowColor = 3,
			Num = 4,
		}

		private Animator animator; // 0xC
		private AnimatorOverrideController overrideController; // 0x10
		private StageLightingResource resource; // 0x14
		private GameDivaObject divaObject; // 0x18
		private List<DivaExtensionObject> divaExtensionObjectList = new List<DivaExtensionObject>(); // 0x1C
		private int index; // 0x20
		private Transform[] colorControlTransforms = new Transform[4]; // 0x24
		public static string[] colorControlObjectName = new string[4] { "diva_color", "diva_rim_color", "diva_rim_power", "shadow_color" }; // 0x0

		// RVA: 0x13A696C Offset: 0x13A696C VA: 0x13A696C
		//public void ResetAnimationPreview(float time) { }

		// RVA: 0x13A6AD8 Offset: 0x13A6AD8 VA: 0x13A6AD8
		private void LateUpdate()
		{
			if(resource != null)
			{
				divaObject.UpdateColorByStageLighting(TransformToColor(colorControlTransforms[0]),
													TransformToColor(colorControlTransforms[1]),
													TransformToColor(colorControlTransforms[2]).a,
													TransformToColor(colorControlTransforms[3]));
				for(int i = 0; i < divaExtensionObjectList.Count; i++)
				{
					divaExtensionObjectList[i].UpdateColorByStageLighting(TransformToColor(colorControlTransforms[0]),
													TransformToColor(colorControlTransforms[1]),
													TransformToColor(colorControlTransforms[2]).a);
				}
			}
		}

		// RVA: 0x13A6EDC Offset: 0x13A6EDC VA: 0x13A6EDC
		public void Initialize(int index, StageLightingResource resource, GameDivaObject divaObject, List<DivaExtensionObject> divaExtensionObjectList)
		{
			this.index = index;
			this.resource = resource;
			this.divaObject = divaObject;
			foreach(var deo in divaExtensionObjectList)
			{
				if(deo.divaId == divaObject.divaId)
				{
					this.divaExtensionObjectList.Add(deo);
				}
			}
			if(resource != null)
			{
				for(int i = 0; i < colorControlObjectName.Length; i++)
				{
					Transform t = transform.Find(colorControlObjectName[i]);
					if(t != null)
					{
						colorControlTransforms[i] = t;
					}
				}
				animator = GetComponent<Animator>();
				animator.runtimeAnimatorController = resource.animatorController;
				overrideController = new AnimatorOverrideController();
				overrideController.name = "dr_li_override_controller";
				overrideController.runtimeAnimatorController = animator.runtimeAnimatorController;
				overrideController["dr_li_cmn_animation"] = resource.clip_add[index];
				animator.runtimeAnimatorController = overrideController;
				animator.playableGraph.SetTimeUpdateMode(DirectorUpdateMode.Manual);
			}
		}

		// RVA: 0x13A6E00 Offset: 0x13A6E00 VA: 0x13A6E00
		private Color TransformToColor(Transform t)
		{
			return new Color(t.localPosition.x, t.localPosition.y, t.localPosition.z, t.localEulerAngles.x);
		}

		//// RVA: 0x13A7470 Offset: 0x13A7470 VA: 0x13A7470
		public void PlayMusicAnimation()
		{
			if(animator != null)
			{
				ChangeAnimationTime(0);
				animator.Play("Music", 0);
			}
		}

		//// RVA: 0x13A7704 Offset: 0x13A7704 VA: 0x13A7704
		//public void Stop() { }

		//// RVA: 0x13A77B0 Offset: 0x13A77B0 VA: 0x13A77B0
		public void Pause()
		{
			if (animator != null)
				animator.speed = 0;
		}

		//// RVA: 0x13A7868 Offset: 0x13A7868 VA: 0x13A7868
		public void Resume()
		{
			if (animator != null)
				animator.speed = 1;
		}

		//// RVA: 0x13A7554 Offset: 0x13A7554 VA: 0x13A7554
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
