using System.Collections.Generic;
using UnityEngine;
using XeApp.Game.RhythmGame;

namespace XeApp.Game.RhythmGame.UI
{
	public class ActiveSkillButton : MonoBehaviour
	{
		[SerializeField]
		private EffectBundleController m_effectController; // 0xC
		[SerializeField]
		private Animator m_skillButtonAnimator; // 0x10
		private static readonly int UI_Active_on_Loop = "UI_Active_on_Loop".GetHashCode(); // 0x0
		private static readonly int UI_Active_skill_IN = "UI_Active_skill_IN".GetHashCode(); // 0x4
		private static readonly int UI_Active_skill_Loop = "UI_Active_skill_Loop".GetHashCode(); // 0x8
		private static readonly int UI_Active_skill_OUT = "UI_Active_skill_OUT".GetHashCode(); // 0xC
		private static readonly int UI_Active_skill_OFF = "UI_Active_skill_OFF".GetHashCode(); // 0x10
		private static readonly int UI_Active_on_IN = "UI_Active_on_IN".GetHashCode(); // 0x14
		private static readonly int AnimatorStateAcOff = Animator.StringToHash("ac_off"); // 0x18
		private static readonly int AnimatorStateAcEnd = Animator.StringToHash("Base Layer.ac_IN_End"); // 0x1C
		private static readonly int AnimatorStateAcOn = Animator.StringToHash("Base Layer.ac_on"); // 0x20
		private static readonly int AnimatorParamButtonShow = Animator.StringToHash("ButtonShow"); // 0x24
		private static readonly int AnimatorParamEnd = Animator.StringToHash("End"); // 0x28
		private static readonly int AnimatorParamSkillOn = Animator.StringToHash("SkillOn"); // 0x2C
		private static readonly int AnimatorParamButtonOn = Animator.StringToHash("ButtonOn"); // 0x30
		private MeshFilter activeSkillIconMeshFilter; // 0x14
		private static List<Vector2>[] iconUVOffsetList = new List<Vector2>[21]; // 0x34
		private bool m_isDurationTime; // 0x18

		public bool IsEnable { get; private set; } // 0x19

		// RVA: 0x1555944 Offset: 0x1555944 VA: 0x1555944
		private void Start()
		{
			Disable();
			activeSkillIconMeshFilter = transform.Find("main_gage_root/active_on/ac_on").GetComponent<MeshFilter>();
			Vector2[] vs = new Vector2[21];
			vs[0] = new Vector2(0, 0);
			vs[1] = new Vector2(0.25f, 0);
			vs[2] = new Vector2(0, 0);
			vs[3] = new Vector2(0.125f, 0);
			vs[4] = new Vector2(0.375f, -0.125f);
			vs[5] = new Vector2(0.375f, 0);
			vs[6] = new Vector2(0, 0);
			vs[7] = new Vector2(0, 0);
			vs[8] = new Vector2(0, 0);
			vs[9] = new Vector2(0.25f, 0);
			vs[10] = new Vector2(0, 0);
			vs[11] = new Vector2(0.375f, 0);
			vs[12] = new Vector2(0, -0.125f);
			vs[13] = new Vector2(0.25f, 0);
			vs[14] = new Vector2(0, 0);
			vs[15] = new Vector2(0.125f, 0);
			vs[16] = new Vector2(0, 0);
			vs[17] = new Vector2(0, 0);
			vs[18] = new Vector2(0.125f, -0.125f);
			vs[19] = new Vector2(0.25f, 0);
			vs[20] = new Vector2(0.25f, 0);
			for(int i = 0; i < 21; i++)
			{
				iconUVOffsetList[i] = new List<Vector2>();
				for(int j = 0; j < activeSkillIconMeshFilter.mesh.uv.Length; j++)
				{
					iconUVOffsetList[i].Add(activeSkillIconMeshFilter.mesh.uv[j] + vs[j]);
				}
			}
		}

		// // RVA: 0x1556558 Offset: 0x1556558 VA: 0x1556558
		public void ApplySkillUv(int buffEffectType)
		{
			activeSkillIconMeshFilter.mesh.uv = iconUVOffsetList[buffEffectType].ToArray();
		}

		// // RVA: 0x1556690 Offset: 0x1556690 VA: 0x1556690
		public void Enable()
		{
			m_skillButtonAnimator.SetTrigger(AnimatorParamButtonShow);
			IsEnable = true;
		}

		// [IteratorStateMachineAttribute] // RVA: 0x746C9C Offset: 0x746C9C VA: 0x746C9C
		// // RVA: 0x155674C Offset: 0x155674C VA: 0x155674C
		// private IEnumerator ChangeToEnable() { }

		// // RVA: 0x15567F8 Offset: 0x15567F8 VA: 0x15567F8
		// public void SetDecide(SkillDuration.Type duration) { }

		// [IteratorStateMachineAttribute] // RVA: 0x746D14 Offset: 0x746D14 VA: 0x746D14
		// // RVA: 0x1556944 Offset: 0x1556944 VA: 0x1556944
		// private IEnumerator ChangeToLoopAnimation() { }

		// [IteratorStateMachineAttribute] // RVA: 0x746D8C Offset: 0x746D8C VA: 0x746D8C
		// // RVA: 0x15569F0 Offset: 0x15569F0 VA: 0x15569F0
		// private IEnumerator WaitLoopAnimation() { }

		// // RVA: 0x1556A9C Offset: 0x1556A9C VA: 0x1556A9C
		// public void End() { }

		// // RVA: 0x1556488 Offset: 0x1556488 VA: 0x1556488
		public void Disable()
		{
			IsEnable = false;
			m_skillButtonAnimator.Play(AnimatorStateAcOff, 0, 0);
		}

		// // RVA: 0x1556B58 Offset: 0x1556B58 VA: 0x1556B58
		// public void SetOn() { }

		// // RVA: 0x1556C0C Offset: 0x1556C0C VA: 0x1556C0C
		// public void Restart() { }

		// // RVA: 0x1556CC8 Offset: 0x1556CC8 VA: 0x1556CC8
		public bool IsStateAcEnd()
		{
			return m_skillButtonAnimator.GetCurrentAnimatorStateInfo(0).shortNameHash == AnimatorStateAcEnd;
		}

		// // RVA: 0x1556DDC Offset: 0x1556DDC VA: 0x1556DDC
		// public bool IsStateAcOn() { }
	}
}
