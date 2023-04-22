using UnityEngine;
using System.Collections;
using System;

namespace XeApp.Game.RhythmGame.UI
{
	public class ActiveSkillCutin : MonoBehaviour
	{
		[SerializeField]
		private MeshRenderer m_renderer; // 0xC
		[SerializeField]
		private Animator m_animator; // 0x10
		[SerializeField]
		private GameObject m_textParentObject; // 0x14
		[SerializeField]
		private Renderer m_skillDescriptionRenderer; // 0x18
		[SerializeField]
		private TextMesh m_skillNameText; // 0x1C
		private IEnumerator m_coroutine; // 0x20
		private const float OpenEndFrame = 30;
		private const float CloseStartFrame = 40;
		private const float EndFrame = 62;
		private const float NormalizedOpenEndFrame = 0.483871f;
		private const float NormalizedCloseFrame = 0.6451613f;
		private static readonly int InAnimeStateName = Animator.StringToHash("IN"); // 0x0
		private int m_shaderMainTexST; // 0x24
		private Material descriptMaterial; // 0x28

		// RVA: 0x1557960 Offset: 0x1557960 VA: 0x1557960
		public void Initialize()
		{
			m_shaderMainTexST = Shader.PropertyToID("_MainTex_ST");
			m_skillNameText = m_textParentObject.GetComponentInChildren<TextMesh>(true);
			m_animator.Play(InAnimeStateName, 0, 1);
			if(descriptMaterial == null)
			{
				descriptMaterial = new Material(m_skillDescriptionRenderer.sharedMaterial);
				m_skillDescriptionRenderer.sharedMaterial = descriptMaterial;
			}
			m_skillNameText.font = GameManager.Instance.GetSystemFont();
			m_skillNameText.GetComponent<MeshRenderer>().materials = new Material[1]
			{
				m_skillNameText.font.material
			};
		}

		// // RVA: 0x1557CBC Offset: 0x1557CBC VA: 0x1557CBC
		public void Show(string name, RhythmGameResource.UITextureResource textureResource, Action endCallback)
		{
			m_skillNameText.text = name;
			m_renderer.material = textureResource.activeSkillIconMaterial;
			descriptMaterial.SetTexture("_MainTex", textureResource.activeSkillEffectMaterial.GetTexture("_MainTex"));
			descriptMaterial.SetTexture("_MaskTex", textureResource.activeSkillEffectMaterial.GetTexture("_MaskTex"));
			m_animator.Play(InAnimeStateName, 0, 0);
		}

		// // RVA: 0x1557EB8 Offset: 0x1557EB8 VA: 0x1557EB8
		public void Close(Action endCallback)
		{
			if(m_animator.GetCurrentAnimatorStateInfo(0).normalizedTime < 1)
			{
				float f = NormalizedCloseFrame;
				if(m_animator.GetCurrentAnimatorStateInfo(0).normalizedTime < NormalizedOpenEndFrame &&
					m_animator.GetCurrentAnimatorStateInfo(0).normalizedTime / 0.3548387f < 1)
				{
					f += m_animator.GetCurrentAnimatorStateInfo(0).normalizedTime / 0.3548387f * 0.3548387f;
					m_animator.Play(InAnimeStateName, 0, f);
				}
				if(endCallback != null)
					endCallback();
			}
		}
	}
}
