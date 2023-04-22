using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace XeApp.Game.RhythmGame.UI
{
	public class TouchSkillEffect : MonoBehaviour
	{
		private class Controller
		{
			public MaterialPropertyBlock m_materialPropertyBlock; // 0x8
			public Renderer m_renderer; // 0xC
			public Animator m_animator; // 0x10
			public WaitForAnimation m_animationWait; // 0x14
			public int m_showSkillTypeId; // 0x18
			public uint m_skillEffectiveIdBit; // 0x1C
			public uint m_topPrioritySkillEffectiveIdBit; // 0x20
			public Coroutine updateSkillAnimeCoroutine; // 0x24
		}

		public class WaitForAnimation : CustomYieldInstruction
		{
			private Animator m_animator; // 0x8
			private int m_lastStateHash; // 0xC
			private int m_layerNo; // 0x10

			public override bool keepWaiting { get { return m_animator.GetCurrentAnimatorStateInfo(m_layerNo).normalizedTime < 1; } }

			// RVA: 0x1565644 Offset: 0x1565644 VA: 0x1565644
			public WaitForAnimation(Animator animator, int layerNo) : base()
			{
				m_animator = animator;
				m_lastStateHash = animator.GetCurrentAnimatorStateInfo(layerNo).fullPathHash;
				m_layerNo = layerNo;
			}

			// RVA: 0x1566E38 Offset: 0x1566E38 VA: 0x1566E38
			//private void Init(Animator animator, int layerNo, int hash) { }
		}

		[SerializeField] // RVA: 0x68F074 Offset: 0x68F074 VA: 0x68F074
		private Animator m_insideAnimator; // 0xC
		[SerializeField] // RVA: 0x68F084 Offset: 0x68F084 VA: 0x68F084
		private Animator m_outsideAnimator; // 0x10
		[SerializeField] // RVA: 0x68F094 Offset: 0x68F094 VA: 0x68F094
		private Renderer m_insideRenderer; // 0x14
		[SerializeField] // RVA: 0x68F0A4 Offset: 0x68F0A4 VA: 0x68F0A4
		private Renderer m_outsideRenderer; // 0x18
		private static readonly int BTN_INSIDE = 0; // 0x0
		private static readonly int BTN_OUTSIDE = 1; // 0x4
		private static readonly int InStateHash = Animator.StringToHash("IN"); // 0x8
		private static readonly int OutStateHash = Animator.StringToHash("OUT"); // 0xC
		private static readonly int LoopFlagsId = Animator.StringToHash("Loop"); // 0x10
		private MaterialPropertyBlock m_insideMaterialProperty; // 0x1C
		private MaterialPropertyBlock m_outsideMaterialProperty; // 0x20
		private int m_shaderMainTexST; // 0x24
		private const int OutSideEffectId = 4;
		private static readonly Dictionary<int, int> effectTypeIdEffectIdMap = new Dictionary<int, int>()
		{
			{ 1, 1 }, { 2, 2}, { 3, 3}, { 5, 4}, { 9, 1}, { 10, 2 }, { 11, 4}, { 12, 5}, { 13, 1}, { 15, 3}, { 8, 7}, { 4, 8}, { 7, 9}, { 18, 10 }, { 19, 11}, { 20, 12}
		}; // 0x14
		private static readonly Vector2[] uvOffsetTbl = new Vector2[12] {
			new Vector2(0.25f ,0),
			new Vector2(0 ,0),
			new Vector2(0.125f,0),
			new Vector2(0.375f,0),
			new Vector2(0,-0.125f),
			new Vector2(0,-0.125f),
			new Vector2(0.125f,-0.25f),
			new Vector2(0,0),
			new Vector2(-0.375f,-0.125f),
			new Vector2(0.125f,-0.125f),
			new Vector2(0.25f,0),
			new Vector2(0.25f,0),
		}; // 0x18
		private Controller[] m_controller = new Controller[2]; // 0x28

		//// RVA: 0x1564D34 Offset: 0x1564D34 VA: 0x1564D34
		public void Initialize()
		{
			m_shaderMainTexST = Shader.PropertyToID("_MainTex_ST");
			m_insideAnimator.Play(OutStateHash, 0, 1.0f);
			m_controller[0] = new Controller();
			m_controller[0].m_animator = m_insideAnimator;
			m_controller[0].m_animationWait = new WaitForAnimation(m_insideAnimator, 0);
			m_controller[0].m_showSkillTypeId = 0;
			m_controller[0].m_skillEffectiveIdBit = 0;
			m_controller[0].m_topPrioritySkillEffectiveIdBit = 0;
			m_controller[0].updateSkillAnimeCoroutine = StartCoroutine(UpdateSkillAnimeCoroutine(0));
			m_controller[0].m_materialPropertyBlock = new MaterialPropertyBlock();
			m_controller[0].m_renderer = m_insideRenderer;
			m_controller[0].m_renderer.SetPropertyBlock(m_controller[0].m_materialPropertyBlock);

			m_controller[1] = new Controller();
			m_controller[1].m_animator = m_outsideAnimator;
			m_controller[1].m_animationWait = new WaitForAnimation(m_outsideAnimator, 0);
			m_controller[1].m_showSkillTypeId = 0;
			m_controller[1].m_skillEffectiveIdBit = 0;
			m_controller[1].m_topPrioritySkillEffectiveIdBit = 0;
			m_controller[1].updateSkillAnimeCoroutine = StartCoroutine(UpdateSkillAnimeCoroutine(1));
			m_controller[1].m_materialPropertyBlock = new MaterialPropertyBlock();
			m_controller[1].m_renderer = m_outsideRenderer;
			m_controller[1].m_renderer.SetPropertyBlock(m_controller[1].m_materialPropertyBlock);
		}

		//// RVA: 0x1565788 Offset: 0x1565788 VA: 0x1565788
		public void OnSkillBit(int id, bool isTopPriority)
		{
			int val = 0;
			if(effectTypeIdEffectIdMap.TryGetValue(id, out val))
			{
				int idx = GetControllerIndex(id);
				m_controller[idx].m_skillEffectiveIdBit |= (byte)(1 << val);
				if(isTopPriority)
				{
					m_controller[idx].m_topPrioritySkillEffectiveIdBit |= (byte)(1 << val);
					m_controller[idx].updateSkillAnimeCoroutine = StartCoroutine(UpdateSkillAnimeCoroutine(idx));
				}
			}
		}

		//// RVA: 0x1565A78 Offset: 0x1565A78 VA: 0x1565A78
		public void OffSkillBit(int id)
		{
			int val = 0;
			if (effectTypeIdEffectIdMap.TryGetValue(id, out val))
			{
				int idx = GetControllerIndex(id);
				m_controller[idx].m_skillEffectiveIdBit &= (byte)~(1 << val);
			}
		}

		//// RVA: 0x1565BD8 Offset: 0x1565BD8 VA: 0x1565BD8
		public void OffTopPrioritySkillBit(int id)
		{
			int val = 0;
			if (effectTypeIdEffectIdMap.TryGetValue(id, out val))
			{
				int idx = GetControllerIndex(id);
				m_controller[idx].m_topPrioritySkillEffectiveIdBit &= (byte)~(1 << val);
			}
		}

		//// RVA: 0x1565D38 Offset: 0x1565D38 VA: 0x1565D38
		//public void DrawEnable(bool flag) { }

		//[IteratorStateMachineAttribute] // RVA: 0x747554 Offset: 0x747554 VA: 0x747554
		//								// RVA: 0x15656E0 Offset: 0x15656E0 VA: 0x15656E0
		private IEnumerator UpdateSkillAnimeCoroutine(int a_controller_index)
		{
			Controller t_ctrl; // 0x18
			int count; // 0x1C
			uint effectiveIdBit = 0; // 0x20

			//0x1566830
			t_ctrl = m_controller[a_controller_index];
			count = 0;
			while (true)
			{
				do
				{
					if (t_ctrl.m_skillEffectiveIdBit == 0)
					{
						t_ctrl.m_animator.Play(OutStateHash, 0, 1.0f);
						t_ctrl.m_showSkillTypeId = 0;
						yield return null;
					}
					else
					{
						effectiveIdBit = t_ctrl.m_skillEffectiveIdBit;
						if (t_ctrl.m_topPrioritySkillEffectiveIdBit != 0)
						{
							effectiveIdBit = t_ctrl.m_topPrioritySkillEffectiveIdBit;
						}
						if (count < 28)
						{
							for (int i = count - 1; i < 27; i++)
							{
								if ((effectiveIdBit & (1 << (count & 0x1f))) != 0)
									break;
								count++;
								if (count > 13)
									count = 0;
							}
						}
					}
				} while (effectiveIdBit == 0);
				if (t_ctrl.m_showSkillTypeId == count)
				{
					count++;
					yield return null;
				}
				else
				{
					yield return t_ctrl.m_animationWait;
					if(t_ctrl.m_animator.GetCurrentAnimatorStateInfo(0).fullPathHash == InStateHash)
					{
						t_ctrl.m_animator.Play(OutStateHash, 0, 0.0f);
						yield return null;
						yield return t_ctrl.m_animationWait;
					}
					if((effectiveIdBit & (1 << (count & 0x1f))) != 0)
					{
						t_ctrl.m_showSkillTypeId = count;
						SetMaterial(t_ctrl);
						count++;
						t_ctrl.m_animator.Play(InStateHash, 0, 0.0f);
						yield return null;
					}
				}
			}
		}

		//// RVA: 0x1565E3C Offset: 0x1565E3C VA: 0x1565E3C
		private void SetMaterial(TouchSkillEffect.Controller a_controller)
		{
			a_controller.m_materialPropertyBlock.SetVector(m_shaderMainTexST, new Vector4(1, 1, uvOffsetTbl[a_controller.m_showSkillTypeId - 1].x, uvOffsetTbl[a_controller.m_showSkillTypeId - 1].y));
			a_controller.m_renderer.SetPropertyBlock(a_controller.m_materialPropertyBlock);
		}

		//// RVA: 0x1565994 Offset: 0x1565994 VA: 0x1565994
		private int GetControllerIndex(int effectId)
		{
			if (effectId == 7 || effectId == 4)
				return BTN_OUTSIDE;
			else
				return BTN_INSIDE;
		}
	}
}
