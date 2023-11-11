using System;
using System.Collections.Generic;
using UnityEngine;
using XeApp.Game.Gacha;

namespace XeApp.Game.Common
{
	public class GachaDirectionCardFrame : GachaDirectionAnimSetBase
	{
		private static readonly int[] State_Enter = new int[6]
		{
			Animator.StringToHash("Frame_EnterS1"),
			Animator.StringToHash("Frame_EnterS2"),
			Animator.StringToHash("Frame_EnterS3"),
			Animator.StringToHash("Frame_EnterS4"),
			Animator.StringToHash("Frame_EnterS5"),
			Animator.StringToHash("Frame_EnterS6"),
		}; // 0x0
		private static readonly int[] State_Idle = new int[6]
		{
			Animator.StringToHash("Frame_IdleS1"),
			Animator.StringToHash("Frame_IdleS2"),
			Animator.StringToHash("Frame_IdleS3"),
			Animator.StringToHash("Frame_IdleS4"),
			Animator.StringToHash("Frame_IdleS5"),
			Animator.StringToHash("Frame_IdleS6"),
		}; // 0x4
		[SerializeField]
		//[TooltipAttribute] // RVA: 0x686C44 Offset: 0x686C44 VA: 0x686C44
		private List<Texture> m_colorTextureAssets; // 0x18
		[SerializeField]
		//[TooltipAttribute] // RVA: 0x686C8C Offset: 0x686C8C VA: 0x686C8C
		private List<Texture> m_maskTextureAssets; // 0x1C
		[SerializeField]
		//[TooltipAttribute] // RVA: 0x686CD4 Offset: 0x686CD4 VA: 0x686CD4
		private List<Renderer> m_renderers; // 0x20
		[SerializeField]
		private GameObject m_lowerFrame; // 0x24
		[SerializeField]
		private GameObject m_higherFrame; // 0x28
		private List<Material> m_materials; // 0x2C
		private int m_uIndex; // 0x30
		private int m_vIndex; // 0x34
		private bool m_uvDirty; // 0x38
		private int m_stateEnter; // 0x3C
		private int m_stateIdle; // 0x40
		private Transform m_animationNode; // 0x44

		public Action onEndEnterAnim { private get; set; } // 0x48
		public Action onEndWaitAnim { private get; set; } // 0x4C
		public Transform animationNode { get { return m_animationNode; } } //0x1C15C24

		// RVA: 0x1C15758 Offset: 0x1C15758 VA: 0x1C15758
		private void Reset()
		{
			m_colorTextureAssets = new List<Texture>();
			m_maskTextureAssets = new List<Texture>();
			m_renderers = new List<Renderer>();
			m_renderers.AddRange(GetComponentsInChildren<Renderer>(true));
		}

		// RVA: 0x1C15870 Offset: 0x1C15870 VA: 0x1C15870 Slot: 4
		protected override void OnAwake()
		{
			m_materials = new List<Material>(m_renderers.Count);
			for(int i = 0; i < m_renderers.Count; i++)
			{
				m_materials.Add(m_renderers[i].material);
				m_renderers[i].material = m_renderers[i].material;
			}
			GameObject g = new GameObject("CardFrame AnimParent");
			m_animationNode = g.transform;
			m_animationNode.SetParent(transform, false);
		}

		// RVA: 0x1C15AD8 Offset: 0x1C15AD8 VA: 0x1C15AD8
		private void LateUpdate()
		{
			transform.rotation = m_animationNode.rotation;
			transform.position = m_animationNode.position;
			transform.localScale = m_animationNode.lossyScale;
		}

		// // RVA: 0x1C15C2C Offset: 0x1C15C2C VA: 0x1C15C2C
		public void SetAttribute(int attrId)
		{
			switch(attrId - 1)
			{
				case 0:
					m_vIndex = 1;
					break;
				case 1:
					m_vIndex = 0;
					break;
				case 2:
				case 3:
					m_vIndex = attrId - 1;
					break;
				default:
					break;
			}
			m_uvDirty = true;
		}

		// RVA: 0x1C15C78 Offset: 0x1C15C78 VA: 0x1C15C78
		public void SetStarNum(int starNum)
		{
			m_stateEnter = State_Enter[starNum - 1];
			m_stateIdle = State_Idle[starNum - 1];
			for(int i = 0; i < m_materials.Count; i++)
			{
				m_materials[i].SetTexture("_MainTex", m_colorTextureAssets[starNum - 1]);
				m_materials[i].SetTexture("_MaskTex", m_maskTextureAssets[starNum - 1]);
			}
			m_uIndex = starNum == 2 ? 1 : 0;
			if(starNum < 6)
			{
				m_lowerFrame.SetActive(starNum < 3);
				m_higherFrame.SetActive(starNum > 2);
			}
			else
			{
				m_lowerFrame.SetActive(false);
				m_higherFrame.SetActive(false);
			}
			m_uvDirty = true;
		}

		// RVA: 0x1C15FFC Offset: 0x1C15FFC VA: 0x1C15FFC
		public void Begin()
		{
			UpdateUvOffset();
			gameObject.SetActive(true);
			animator.Play(m_stateEnter, 0, 0);
			WaitForAnimationEnd(() =>
			{
				//0x1C1672C
				if(onEndEnterAnim != null)
					onEndEnterAnim();
			});
		}

		// RVA: 0x1C16248 Offset: 0x1C16248 VA: 0x1C16248
		public void Wait()
		{
			animator.Play(m_stateIdle, 0, 0);
			WaitForAnimationEnd(() =>
			{
				//0x1C16740
				if(onEndWaitAnim != null)
					onEndWaitAnim();
			});
		}

		// RVA: 0x1C16314 Offset: 0x1C16314 VA: 0x1C16314
		public void End()
		{
			gameObject.SetActive(false);
		}

		// RVA: 0x1C1634C Offset: 0x1C1634C VA: 0x1C1634C Slot: 5
		protected override void OnSetup(DirectionInfo directionInfo)
		{
			gameObject.SetActive(false);
		}

		// // RVA: 0x1C16100 Offset: 0x1C16100 VA: 0x1C16100
		private void UpdateUvOffset()
		{
			if(m_uvDirty)
			{
				m_uvDirty = false;
				Vector2 v = new Vector2(m_uIndex * 0.5f, -m_vIndex * 0.25f);
				for(int i = 0; i < m_materials.Count; i++)
				{
					m_materials[i].mainTextureOffset = v;
				}
			}
		}
	}
}
