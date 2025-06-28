using UnityEngine;
using System;
using System.Collections;
using XeApp.Game.Common;
using XeSys;
using XeApp.Core;

namespace XeApp.Game.Menu
{
	public class ModelGachaBox : MonoBehaviour
	{
		[Serializable]
		private class BoxTexture
		{
			[Serializable]
			public class TextureSet
			{
				public Texture main; // 0x8
				public Texture add; // 0xC
				public Texture effect; // 0x10
			}

			public TextureSet[] box; // 0x8
		}

		[SerializeField]
		private Animator m_animObject; // 0xC
		[SerializeField]
		private Animator m_animCamera; // 0x10
		[SerializeField]
		private Animator m_animBgFade; // 0x14
		[SerializeField]
		private Animator m_animBgEffect; // 0x18
		[SerializeField]
		private Camera m_camera; // 0x1C
		[SerializeField]
		private MeshRenderer[] m_meshes; // 0x20
		[SerializeField]
		private MeshRenderer m_addMeshes; // 0x24
		[SerializeField]
		private Material m_effect; // 0x28
		[SerializeField]
		private BoxTexture[] m_textures; // 0x2C

		// RVA: 0x1045784 Offset: 0x1045784 VA: 0x1045784
		public void Setup(HGFPAFPGIKG.KAFHMMOGLKO type, int halfTimeId)
		{
			for(int i = 0; i < m_meshes.Length; i++)
			{
				m_meshes[i].material.mainTexture = m_textures[(int)type].box[halfTimeId - 1].main;
			}
			m_addMeshes.material.mainTexture = m_textures[(int)type].box[halfTimeId - 1].add;
			m_effect.mainTexture = m_textures[(int)type].box[halfTimeId - 1].effect;
		}

		// RVA: 0x10459D8 Offset: 0x10459D8 VA: 0x10459D8
		public void AdjustCamera()
		{
			if(SystemManager.isLongScreenDevice)
			{
				FlexibleLayoutCamera fl = m_camera.GetComponent<FlexibleLayoutCamera>();
				if(fl != null)
				{
					fl.IsEnableFov = false;
					m_camera.fieldOfView = Mathf.CeilToInt(fl.GetDefaultFov(0) * MenuScene.GetLongScreenScale());
				}
			}
		}

		// [IteratorStateMachineAttribute] // RVA: 0x6DEC4C Offset: 0x6DEC4C VA: 0x6DEC4C
		// RVA: 0x1045BF4 Offset: 0x1045BF4 VA: 0x1045BF4
		public IEnumerator Enter()
		{
			//0x10462A8
			m_camera.depth = 120;
			m_animObject.gameObject.SetActive(false);
			m_animObject.gameObject.SetActive(true);
			m_animObject.speed = 1;
			m_animCamera.gameObject.SetActive(false);
			m_animCamera.gameObject.SetActive(true);
			m_animCamera.speed = 1;
			m_animBgFade.enabled = false;
			m_animBgFade.enabled = true;
			m_animBgFade.Play("nyan_kuji_back_inout", 0, 0);
			m_animBgFade.speed = 1;
			SoundManager.Instance.sePlayerMenu.Play((int)mcrs.cs_se_menu.SE_KUJI_000);
			yield return null;
			while(m_animObject.GetCurrentAnimatorStateInfo(0).normalizedTime < 1)
				yield return null;
			while(m_animCamera.GetCurrentAnimatorStateInfo(0).normalizedTime < 1)
				yield return null;
			while(m_animBgFade.GetCurrentAnimatorStateInfo(0).normalizedTime < 1)
				yield return null;
		}

		// RVA: 0x1045CA0 Offset: 0x1045CA0 VA: 0x1045CA0
		public void Reset()
		{
			m_animObject.gameObject.SetActive(false);
			m_animObject.gameObject.SetActive(true);
			m_animObject.speed = 0;
			m_animCamera.gameObject.SetActive(false);
			m_animCamera.gameObject.SetActive(true);
			m_animCamera.speed = 0;
			m_animBgFade.gameObject.SetActive(true);
			m_animBgFade.enabled = false;
			m_animBgFade.speed = 0;
			m_camera.depth = 80;
		}

		// // RVA: 0x1045EBC Offset: 0x1045EBC VA: 0x1045EBC
		// public void Show() { }

		// RVA: 0x10460AC Offset: 0x10460AC VA: 0x10460AC
		public void Hide()
		{
			if(m_animObject != null)
			{
				m_animObject.gameObject.SetActive(false);
			}
			if(m_animCamera != null)
			{
				m_animCamera.gameObject.SetActive(false);
			}
			if(m_animBgFade != null)
			{
				m_animBgFade.gameObject.SetActive(false);
			}
		}
	}
}
