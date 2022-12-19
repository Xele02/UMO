using UnityEngine;
using TMPro;
using XeApp.Game.Common;
using System.Collections.Generic;
using System.Collections;
using System;

namespace XeApp.Game.RhythmGame.UI
{
	public class SkillCutin : MonoBehaviour
	{
		public struct CutinInfo
		{
			public struct DescMaterial
			{
				public Material effectTypeMtl; // 0x0
				public SkillBuffEffect.Type effectType; // 0x4
				public int bufEffectValue; // 0x8
			}

			public int liveSkillId; // 0x0
			public int divaIndex; // 0x4
			public int slotIndex; // 0x8
			public Material material; // 0xC
			public List<DescMaterial> effectTypeMtl; // 0x10
		}

		[SerializeField]
		private MeshRenderer m_renderer; // 0xC
		[SerializeField]
		private Animator m_animator; // 0x10
		[SerializeField]
		private Renderer m_skillDescriptionRenderer; // 0x14
		[SerializeField]
		private TextMeshPro m_text_scoreup; // 0x18
		private IEnumerator m_coroutine; // 0x1C
		private const float OpenEndFrame = 15;
		private const float CloseStartFrame = 45;
		private const float EndFrame = 55;
		private const float NormalizedOpenEndFrame = 0.2727273f;
		private const float NormalizedCloseFrame = 0.8181818f;
		private static readonly int InAnimeStateName = Animator.StringToHash("IN"); // 0x0
		private int m_shaderMainTexST; // 0x20
		private MaterialPropertyBlock m_materialPropertyBlock; // 0x24
		private bool m_isPlaying; // 0x28
		private char[] m_scoreup_char = new char[5]; // 0x2C
		private const int QueueSize = 10;
		private List<CutinInfo> m_skillQueue = new List<CutinInfo>(); // 0x30

		// // RVA: 0x1562DD8 Offset: 0x1562DD8 VA: 0x1562DD8
		public void Initialize()
		{
			m_materialPropertyBlock = new MaterialPropertyBlock();
			m_shaderMainTexST = Shader.PropertyToID("_MainTex_ST");
			m_animator.Play(InAnimeStateName, 0, 1);
		}

		// // RVA: 0x1562EE0 Offset: 0x1562EE0 VA: 0x1562EE0
		// public void Show(LiveSkill liveSkill, Material material, Material effectTypeMtl) { }

		// // RVA: 0x1563354 Offset: 0x1563354 VA: 0x1563354
		// public void Show() { }

		// // RVA: 0x1563438 Offset: 0x1563438 VA: 0x1563438
		public void Close(Action endCallback)
		{
			if (m_coroutine != null)
				StopCoroutine(m_coroutine);
			m_animator.enabled = true;
			m_isPlaying = false;
			m_skillQueue.Clear();
			m_coroutine = CloseAnimeCoroutine(endCallback);
			StartCoroutine(m_coroutine);
		}

		// [IteratorStateMachineAttribute] // RVA: 0x7473C4 Offset: 0x7473C4 VA: 0x7473C4
		// // RVA: 0x1563390 Offset: 0x1563390 VA: 0x1563390
		// private IEnumerator ShowAnimeCoroutine(Action endCallback) { }

		// // RVA: 0x15635E0 Offset: 0x15635E0 VA: 0x15635E0
		// private void SetBuffEffectValue(SkillBuffEffect.Type a_type, int a_num) { }

		// // RVA: 0x15636F4 Offset: 0x15636F4 VA: 0x15636F4
		// private static void ConvertCharArray(ref char[] a_array, int a_num) { }

		// [IteratorStateMachineAttribute] // RVA: 0x74743C Offset: 0x74743C VA: 0x74743C
		// // RVA: 0x1563518 Offset: 0x1563518 VA: 0x1563518
		private IEnumerator CloseAnimeCoroutine(Action endCallback)
		{
			//0x1563B18
			while (m_animator.GetCurrentAnimatorStateInfo(0).normalizedTime < NormalizedCloseFrame)
				yield return null;
			float f = NormalizedCloseFrame;
			if(m_animator.GetCurrentAnimatorStateInfo(0).normalizedTime < NormalizedOpenEndFrame &&
				m_animator.GetCurrentAnimatorStateInfo(0).normalizedTime / 0.1818182f < 1.0f)
			{
				f += m_animator.GetCurrentAnimatorStateInfo(0).normalizedTime / 0.1818182f * 0.1818182f;
			}
			m_animator.Play(InAnimeStateName, 0, f);
			yield return null;
			while (m_animator.GetCurrentAnimatorStateInfo(0).normalizedTime < 1)
				yield return null;
			if (endCallback != null)
				endCallback();
		}
	}
}
