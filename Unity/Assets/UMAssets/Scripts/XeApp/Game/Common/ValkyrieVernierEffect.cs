using UnityEngine;
using System.Collections.Generic;

namespace XeApp.Game.Common
{
	public class ValkyrieVernierEffect : MonoBehaviour
	{
		//[HeaderAttribute] // RVA: 0x68813C Offset: 0x68813C VA: 0x68813C
		[SerializeField]
		private List<MeshRenderer> m_meshes; // 0xC
		[SerializeField]
		//[HeaderAttribute] // RVA: 0x688184 Offset: 0x688184 VA: 0x688184
		private List<ParticleSystem> m_particles; // 0x10
		private Material m_meshMaterial; // 0x14

		//// RVA: 0xD2FA78 Offset: 0xD2FA78 VA: 0xD2FA78
		//private void Reset() { }

		//// RVA: 0xD2FB78 Offset: 0xD2FB78 VA: 0xD2FB78
		private void Start()
		{
			TouchMaterial();
		}

		//// RVA: 0xD2FCFC Offset: 0xD2FCFC VA: 0xD2FCFC
		public void ApplyColor(Color meshColor, Gradient particleColor)
		{
			TouchMaterial();
			m_meshMaterial.SetColor("_VernierColor", meshColor);
			for(int i = 0; i < m_particles.Count; i++)
			{
				ParticleSystem.ColorOverLifetimeModule col = m_particles[i].colorOverLifetime;
				col.color = new ParticleSystem.MinMaxGradient(particleColor);
			}
		}

		//// RVA: 0xD2FB7C Offset: 0xD2FB7C VA: 0xD2FB7C
		private void TouchMaterial()
		{
			if (m_meshMaterial != null)
				return;
			m_meshMaterial = m_meshes[0].material;
			for(int i = 0; i < m_meshes.Count; i++)
			{
				m_meshes[i].sharedMaterial = m_meshMaterial;
			}
		}

		//// RVA: 0xD2FECC Offset: 0xD2FECC VA: 0xD2FECC
		//public void Pause() { }

		//// RVA: 0xD30028 Offset: 0xD30028 VA: 0xD30028
		//public void Resume() { }
	}
}
