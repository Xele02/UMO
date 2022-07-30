using UnityEngine;
using System.Collections.Generic;

namespace XeApp.Game.Common
{
	public class DivaExtensionChangeAnimationForPositionId : MonoBehaviour
	{
		// [HeaderAttribute] // RVA: 0x686888 Offset: 0x686888 VA: 0x686888
		[SerializeField]
		private string m_state_name = ""; // 0xC
		[SerializeField]
		private List<AnimationClip> m_list_anim_clip = new List<AnimationClip>(); // 0x10

		// RVA: 0x1BEBC8C Offset: 0x1BEBC8C VA: 0x1BEBC8C
		public void Initialize(DivaObject a_diva_obj)
		{
			Animator animator = GetComponent<Animator>();
			AnimatorOverrideController overrideController = new AnimatorOverrideController();
			overrideController.runtimeAnimatorController = animator.runtimeAnimatorController;
			animator.runtimeAnimatorController = overrideController;
			if(string.IsNullOrEmpty(m_state_name))
				return;
			overrideController["name"] = m_list_anim_clip[a_diva_obj.positionId - 1];
		}
	}
}
