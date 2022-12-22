using UnityEngine;
using TMPro;
using XeApp.Game.Common;
using System.Collections.Generic;
using System.Collections;
using System;
using mcrs;

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
		public void Show(LiveSkill liveSkill, Material material, Material effectTypeMtl)
		{
			int idx = m_skillQueue.FindIndex((CutinInfo x) =>
			{
				//0x1563A78
				if (x.liveSkillId == liveSkill.skillId && x.divaIndex == liveSkill.ownerDivaPlaceIndex && x.slotIndex == liveSkill.ownerSlotPlaceIndex)
					return true;
				return false;
			});
			if(idx < 0)
			{
				m_skillQueue.Add(new CutinInfo()
				{
					liveSkillId = liveSkill.skillId,
					divaIndex = liveSkill.ownerDivaPlaceIndex,
					slotIndex = liveSkill.ownerSlotPlaceIndex,
					material = material,
					effectTypeMtl = new List<CutinInfo.DescMaterial>()
					{
						new CutinInfo.DescMaterial()
						{
							effectTypeMtl = effectTypeMtl,
							effectType = liveSkill.buffEffectType,
							bufEffectValue = liveSkill.buffEffectValue_SkillCutin
						}
					}
				});
			}
			else
			{
				CutinInfo info = m_skillQueue[idx];
				if (liveSkill.buffEffectType < info.effectTypeMtl[0].effectType)
				{
					info.effectTypeMtl.Insert(0, new CutinInfo.DescMaterial()
					{
						effectTypeMtl = effectTypeMtl,
						effectType = liveSkill.buffEffectType,
						bufEffectValue = liveSkill.buffEffectValue_SkillCutin
					});
				}
				else
				{
					info.effectTypeMtl.Add(new CutinInfo.DescMaterial()
					{
						effectTypeMtl = effectTypeMtl,
						effectType = liveSkill.buffEffectType,
						bufEffectValue = liveSkill.buffEffectValue_SkillCutin
					});
				}
				m_skillQueue[idx] = info;
			}
		}

		// // RVA: 0x1563354 Offset: 0x1563354 VA: 0x1563354
		public void Show()
		{
			if (m_isPlaying)
				return;
			m_coroutine = ShowAnimeCoroutine(null);
			StartCoroutine(m_coroutine);
		}

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
		private IEnumerator ShowAnimeCoroutine(Action endCallback)
		{
			SkillCutin.CutinInfo stackValue;
			bool isMulti;
			bool isChanged;

			//0x1563E44
			m_isPlaying = true;
			for(int i = 0; m_skillQueue.Count > 1;)
			{
				stackValue = m_skillQueue[0];
				isChanged = false;
				isMulti = stackValue.effectTypeMtl.Count > 1;
				m_skillQueue.RemoveAt(0);
				m_renderer.material = stackValue.material;
				m_skillDescriptionRenderer.material = stackValue.effectTypeMtl[0].effectTypeMtl;
				SetBuffEffectValue(stackValue.effectTypeMtl[0].effectType, stackValue.effectTypeMtl[0].bufEffectValue);
				SoundManager.Instance.sePlayerGame.Play((int)cs_se_game.SE_VALKYRIE_000);
				m_animator.Play(InAnimeStateName, 0, 0);
				yield return null;

				while (m_animator.GetCurrentAnimatorStateInfo(0).normalizedTime < 1)
				{
					if (isMulti && !isChanged && m_animator.GetCurrentAnimatorStateInfo(0).normalizedTime >= 0.5f)
					{
						m_skillDescriptionRenderer.material = stackValue.effectTypeMtl[1].effectTypeMtl;
						SetBuffEffectValue(stackValue.effectTypeMtl[1].effectType, stackValue.effectTypeMtl[1].bufEffectValue);
						isChanged = true;
					}
					yield return null;
				}
				if (endCallback != null)
					endCallback();
			}
			m_isPlaying = false;
		}

		// // RVA: 0x15635E0 Offset: 0x15635E0 VA: 0x15635E0
		private void SetBuffEffectValue(SkillBuffEffect.Type a_type, int a_num)
		{
			if(a_type == SkillBuffEffect.Type.ScoreUpPercentage_FoldWave)
			{
				m_text_scoreup.gameObject.SetActive(true);
				ConvertCharArray(ref m_scoreup_char, a_num);
				m_text_scoreup.SetCharArray(m_scoreup_char);
			}
			else
			{
				m_text_scoreup.gameObject.SetActive(false);
			}
		}

		// // RVA: 0x15636F4 Offset: 0x15636F4 VA: 0x15636F4
		private static void ConvertCharArray(ref char[] a_array, int a_num)
		{
			System.Array.Clear(a_array, 0, a_array.Length);
			a_array[0] = '+';
			int val = Math.Max(a_num, 0);
			int num = val;
			if (num == 0)
				num = 1;
			else
			{
				num = (int)Mathf.Log10(val) + 1;
			}
			int num2 = num;
			if (num2 > 3)
				num2 = 3;
			if((num2 - 1) > -1)
			{
				if (num > 3)
					val = 999;
				for(int i = num2; i > -1; i--)
				{
					a_array[1 + i] = (char)(val - (val / 10) * 10 + '0');
					val /= 10;
				}
			}
			a_array[num2 + 1] = '%';
		}

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
