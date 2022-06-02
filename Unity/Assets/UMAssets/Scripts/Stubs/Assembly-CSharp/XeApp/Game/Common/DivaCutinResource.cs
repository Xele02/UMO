using UnityEngine;

namespace XeApp.Game.Common
{
	public class DivaCutinResource : MonoBehaviour
	{
		public bool isUnused;
		public AnimationClip clip;
		public AnimationClip clipBoneSpring;
		public RuntimeAnimatorController animatorController;
		public AnimationClip[] cutinBodyClips;
		public AnimationClip[] cutinFaceClips;
		public AnimationClip[] cutinMouthClips;
		public AnimationClip[] cutinMikeClips;
		public AnimationClip[] cutinBoneSpringClips;
		public int divaId;
	}
}
