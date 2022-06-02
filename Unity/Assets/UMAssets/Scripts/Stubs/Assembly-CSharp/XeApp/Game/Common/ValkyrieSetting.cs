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
		private Color m_vernierMeshColor;
		[SerializeField]
		private Gradient m_vernierParticleColor;
		[SerializeField]
		private List<MeshRenderer> m_vernierMeshes;
		[SerializeField]
		private HitEffectType m_hitEffect;
		[SerializeField]
		private bool m_shootOnlyOnce;
	}
}
