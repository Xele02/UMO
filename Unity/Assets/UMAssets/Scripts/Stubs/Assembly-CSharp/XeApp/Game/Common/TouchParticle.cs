using UnityEngine;

namespace XeApp.Game.Common
{
	public class TouchParticle : MonoBehaviour
	{
		[SerializeField]
		private ParticleSystem m_particle_press;
		[SerializeField]
		private TouchParticleObject m_particle_object;
		[SerializeField]
		private Transform m_pool;
		[SerializeField]
		private float MAGNITUDE_MIN;
	}
}
