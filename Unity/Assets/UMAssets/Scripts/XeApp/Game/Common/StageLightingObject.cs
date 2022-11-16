using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

namespace XeApp.Game.Common
{
	public class StageLightingObject : MonoBehaviour
	{
		private enum ControlType
		{
			DivaColor = 0,
			DivaRimColor = 1,
			DivaRimPower = 2,
			ShadowColor = 3,
			StageColor = 4,
			LightA = 5,
			LightB = 6,
			LightC = 7,
			Num = 8,
		}

		private Animator animator; // 0xC
		private AnimatorOverrideController overrideController; // 0x10
		private StageLightingResource resource; // 0x14
		private StageObject stageObject; // 0x18
		private GameDivaObject divaObject; // 0x1C
		private List<StageExtensionObject> stageExtensionObjectList = new List<StageExtensionObject>(); // 0x20
		private List<DivaExtensionObject> divaExtensionObjectList = new List<DivaExtensionObject>(); // 0x24
		private GameDivaObject[] subDivaObject; // 0x28
		private int subDivaNum; // 0x2C
		private Transform[] colorControlTransforms = new Transform[8]; // 0x30
		public static string[] colorControlObjectName = new string[8] { "diva_color", "diva_rim_color", "diva_rim_power", "shadow_color", "stage_color",
							"light_a", "light_b", "light_c"}; // 0x0

		//// RVA: 0x13A7C04 Offset: 0x13A7C04 VA: 0x13A7C04
		//public void ResetAnimationPreview(float time) { }

		//// RVA: 0x13A7D70 Offset: 0x13A7D70 VA: 0x13A7D70
		private void LateUpdate()
		{
			if (resource != null)
			{
				Color diva_color = TransformToColor(colorControlTransforms[0]);
				Color diva_rim_color = TransformToColor(colorControlTransforms[1]);
				Color diva_rim_power = TransformToColor(colorControlTransforms[2]);
				Color shadow_color = TransformToColor(colorControlTransforms[3]);
				Color stage_color = TransformToColor(colorControlTransforms[4]);
				Color light_a = TransformToColor(colorControlTransforms[5]);
				Color light_b = TransformToColor(colorControlTransforms[6]);
				Color light_c = TransformToColor(colorControlTransforms[7]);
				divaObject.UpdateColorByStageLighting(diva_color, diva_rim_color, diva_rim_power.r, shadow_color);
				for(int i = 0; i < divaExtensionObjectList.Count; i++)
				{
					divaExtensionObjectList[i].UpdateColorByStageLighting(diva_color, diva_rim_color, diva_rim_power.a);
				}
				for(int i = 0; i < subDivaNum; i++)
				{
					if(subDivaObject[i] != null)
					{
						subDivaObject[i].UpdateColorByStageLighting(diva_color, diva_rim_color, diva_rim_power.r, shadow_color);
					}
				}
				if(stageObject.colorChanger != null)
				{
					stageObject.colorChanger.UpdateColorByStageLighting(stage_color, light_a, light_b, light_c);
				}
				for(int i = 0; i < stageExtensionObjectList.Count; i++)
				{
					stageExtensionObjectList[i].UpdateColorByStageLighting(stage_color, light_a, light_b, light_c);
				}
			}
		}

		//// RVA: 0x13A8680 Offset: 0x13A8680 VA: 0x13A8680
		public void Initialize(StageLightingResource resource, StageObject stageObject, GameDivaObject divaObject, List<StageExtensionObject> stageExtensionObjectList, List<DivaExtensionObject> divaExtensionObjectList, GameDivaObject[] subDivaObject, int subDivaNum)
		{
			this.stageObject = stageObject;
			this.resource = resource;
			this.divaObject = divaObject;
			this.stageExtensionObjectList = stageExtensionObjectList;
			this.divaExtensionObjectList = divaExtensionObjectList;
			this.subDivaObject = subDivaObject;
			this.subDivaNum = subDivaNum;
			if(resource != null)
			{
				for(int i = 0; i < colorControlObjectName.Length; i++)
				{
					colorControlTransforms[i] = transform.Find(colorControlObjectName[i]);
				}
				animator = GetComponent<Animator>();
				animator.runtimeAnimatorController = resource.animatorController;
				overrideController = new AnimatorOverrideController();
				overrideController.name = "dr_li_override_controller";
				overrideController.runtimeAnimatorController = animator.runtimeAnimatorController;
				overrideController["dr_li_cmn_animation"] = resource.clip;
				animator.runtimeAnimatorController = overrideController;
				animator.playableGraph.SetTimeUpdateMode(DirectorUpdateMode.Manual);
			}
		}

		//// RVA: 0x13A85A4 Offset: 0x13A85A4 VA: 0x13A85A4
		private Color TransformToColor(Transform t)
		{
			return new Color(t.localPosition.x, t.localPosition.y, t.localPosition.z, t.localEulerAngles.x);
		}

		//// RVA: 0x13A8A88 Offset: 0x13A8A88 VA: 0x13A8A88
		public void PlayMusicAnimation()
		{
			if(animator != null)
			{
				ChangeAnimationTime(0.0f);
				animator.Play("Music", 0);
			}
		}

		//// RVA: 0x13A8D1C Offset: 0x13A8D1C VA: 0x13A8D1C
		//public void Stop() { }

		//// RVA: 0x13A8DC8 Offset: 0x13A8DC8 VA: 0x13A8DC8
		public void Pause()
		{
			if (animator != null)
				animator.speed = 0;
		}

		//// RVA: 0x13A8E80 Offset: 0x13A8E80 VA: 0x13A8E80
		public void Resume()
		{
			if (animator != null)
				animator.speed = 1;
		}

		//// RVA: 0x13A8B6C Offset: 0x13A8B6C VA: 0x13A8B6C
		public void ChangeAnimationTime(double time)
		{
			if(animator != null)
			{
				animator.speed = 1;
				if(PlayableExtensions.IsValid<Playable>(animator.playableGraph.GetRootPlayable(0)))
				{
					animator.playableGraph.Evaluate((float)(time - PlayableExtensions.GetTime<Playable>(animator.playableGraph.GetRootPlayable(0))));
				}
			}
		}
	}
}
