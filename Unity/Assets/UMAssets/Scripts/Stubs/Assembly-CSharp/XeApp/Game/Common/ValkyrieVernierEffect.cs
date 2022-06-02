using UnityEngine;
using System.Collections.Generic;

namespace XeApp.Game.Common
{
	public class ValkyrieVernierEffect : MonoBehaviour
	{
		[SerializeField]
		private List<MeshRenderer> m_meshes;
		[SerializeField]
		private List<ParticleSystem> m_particles;
	}
}
