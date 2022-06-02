using XeApp.Core;
using UnityEngine;

namespace XeApp.Game.Common
{
	public class TouchParticleObject : PoolObject
	{
		[SerializeField]
		private ParticleSystem m_particle_touch;
		[SerializeField]
		private Transform m_transform_sub;
		[SerializeField]
		private Animator m_touch_circle;
	}
}
