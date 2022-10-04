using UnityEngine;
using System.Collections.Generic;

namespace XeApp.Game.Common
{
	public class ValkyrieSetting : MonoBehaviour
	{
		public enum HitEffectType
		{
			EF_Hit = 0,
			EF_Hit_seven = 1,
		}
		
		[SerializeField]
		private Color m_vernierMeshColor; // 0xC
		[SerializeField]
		private Gradient m_vernierParticleColor; // 0x1C
		[SerializeField]
		private List<MeshRenderer> m_vernierMeshes; // 0x20
		[SerializeField]
		private HitEffectType m_hitEffect; // 0x24
		[SerializeField]
		private bool m_shootOnlyOnce; // 0x28

		public Color vernierMeshColor { get { return m_vernierMeshColor; } } //0xD2F088
		public Gradient vernierParticleColor { get { return m_vernierParticleColor; } } //0xD2F098
		public bool shootOnlyOnce { get { return m_shootOnlyOnce; } } //0xD2F0A0

		// RVA: 0xD28BE4 Offset: 0xD28BE4 VA: 0xD28BE4
		public void ResetVernierMeshesColor()
		{
			if(m_vernierMeshes.Count > 0)
			{
				Material m = m_vernierMeshes[0].material;
				for(int i = 0; i < m_vernierMeshes.Count; i++)
				{
					m_vernierMeshes[i].sharedMaterial = m;
				}
				m.SetColor("_AddColor", m_vernierMeshColor);
			}
		}

		//// RVA: 0xD2F0A8 Offset: 0xD2F0A8 VA: 0xD2F0A8
		public string GetHitEffectName()
		{
			return m_hitEffect == HitEffectType.EF_Hit_seven ? "EF_Hit_seven" : "EF_Hit";
		}
	}
}
