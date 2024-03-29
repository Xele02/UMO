using System.Text;
using UnityEngine;
using UnityEngine.Playables;
using XeSys;

namespace XeApp.Game.Common
{
	public class MikeStandObject : MonoBehaviour
	{
		public float[] HightScaleFactor = new float[10] { 0.9628f, 1.0391f, 1.0495f, 0.9912f, 0.9109f, 0.98f, 1.06f, 0.964f, 1, 1}; // 0xC
		public float[] AdjustScaleFactor = new float[10] { 0.9506f, 1.0216f, 1.0237f, 0.9696f, 0.8915f, 0.98f, 1.0642f, 0.964f, 1, 1}; // 0x10
		public float[] AdjustRotationFactor = new float[10] { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 }; // 0x14
		public Animator animator; // 0x18
		private AnimatorOverrideController overrideController; // 0x1C
		[SerializeField]
		private Transform scaleAsjustPoint; // 0x20
		[SerializeField]
		private Transform hightAsjustPoint; // 0x24
		[SerializeField]
		private Transform mikeAttachPoint; // 0x28

		//// RVA: 0x1117D80 Offset: 0x1117D80 VA: 0x1117D80
		//public void ResetAnimationPreview() { }

		//// RVA: 0x1117D84 Offset: 0x1117D84 VA: 0x1117D84
		public void Initialize(int divaId, RuntimeAnimatorController animController, AnimationClip overrideClip)
		{
			hightAsjustPoint.localPosition = new Vector3(hightAsjustPoint.localPosition.x, hightAsjustPoint.localPosition.y * HightScaleFactor[divaId - 1], hightAsjustPoint.localPosition.z);
			scaleAsjustPoint.gameObject.AddComponent<ObjectPositionAdjuster>().Initialize(AdjustScaleFactor[divaId - 1], true, true, true);
			scaleAsjustPoint.gameObject.AddComponent<ObjectRotationAdjuster>().Initialize(AdjustRotationFactor[divaId - 1], true, true, true);
			animator = gameObject.GetComponent<Animator>();
			animator.runtimeAnimatorController = animController;
			overrideController = new AnimatorOverrideController();
			overrideController.name = "mikestand_override_controller";
			overrideController.runtimeAnimatorController = animator.runtimeAnimatorController;
			overrideController["mikestand_music_anim"] = overrideClip;
			animator.runtimeAnimatorController = overrideController;
			animator.playableGraph.SetTimeUpdateMode(UnityEngine.Playables.DirectorUpdateMode.Manual);
		}

		//// RVA: 0x11181A8 Offset: 0x11181A8 VA: 0x11181A8
		public void OverrideCutinClip(DivaCutinResource a_resource)
		{
			if(a_resource != null)
			{
				StringBuilder str = new StringBuilder();
				for(int i = 0; i < a_resource.cutinMikeClips.Length; i++)
				{
					if(a_resource.cutinMikeClips[i] != null)
					{
						str.SetFormat("mikestand_cut_{0:D2}_anim", i + 1);
						overrideController[str.ToString()] = a_resource.cutinMikeClips[i];
					}
				}
			}
		}

		//// RVA: 0x1118404 Offset: 0x1118404 VA: 0x1118404
		public void AdjustHight(float offset)
		{
			hightAsjustPoint.localPosition = new Vector3(hightAsjustPoint.localPosition.x, hightAsjustPoint.localPosition.y * offset, hightAsjustPoint.localPosition.z);
		}

		//// RVA: 0x1118490 Offset: 0x1118490 VA: 0x1118490
		public void AttachMike(GameObject obj)
		{
			obj.transform.SetParent(mikeAttachPoint, false);
		}

		//// RVA: 0x11184EC Offset: 0x11184EC VA: 0x11184EC
		public void SetTime(double time)
		{
			animator.speed = 1;
			if (PlayableExtensions.IsValid<Playable>(animator.playableGraph.GetRootPlayable(0)))
			{
				animator.playableGraph.Evaluate((float)(time - PlayableExtensions.GetTime<Playable>(animator.playableGraph.GetRootPlayable(0))));
			}
		}
	}
}
