using UnityEngine;

namespace XeApp.Game.Common
{
	public class MikeStandObject : MonoBehaviour
	{
		public float[] HightScaleFactor = new float[10] { 4AADE0310D792417BC7771A2BC1EE19CB55362D0 }; // 0xC
		public float[] AdjustScaleFactor = new float[10] { C906995C247542613F4C4D48C8343F3CFD6470A4 }; // 0x10
		public float[] AdjustRotationFactor = new float[10] { 90F7E05841CE4019124B0D0DBC487D36F62E006D }; // 0x14
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
			scaleAsjustPoint.gameObject.GetComponent<ObjectPositionAdjuster>().Initialize(AdjustScaleFactor[divaId - 1], true, true, true);
			scaleAsjustPoint.gameObject.GetComponent<ObjectRotationAdjuster>().Initialize(AdjustRotationFactor[divaId - 1], true, true, true);
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
		//public void OverrideCutinClip(DivaCutinResource a_resource) { }

		//// RVA: 0x1118404 Offset: 0x1118404 VA: 0x1118404
		//public void AdjustHight(float offset) { }

		//// RVA: 0x1118490 Offset: 0x1118490 VA: 0x1118490
		//public void AttachMike(GameObject obj) { }

		//// RVA: 0x11184EC Offset: 0x11184EC VA: 0x11184EC
		//public void SetTime(double time) { }
	}
}
