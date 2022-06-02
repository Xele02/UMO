using UnityEngine;
using XeApp.Game.UI;

namespace XeApp.Game.RhythmGame.UI
{
	public class EnemyStatus : MonoBehaviour
	{
		[SerializeField]
		private NumericMesh m_limitTimeMesh;
		[SerializeField]
		private Animator m_rootAnimator;
		[SerializeField]
		private Animator m_fadeInAnimator;
		[SerializeField]
		private GameObject m_enemyGaugePrefab;
		[SerializeField]
		private GameObject[] m_explosionEffectPrefab;
		[SerializeField]
		private ParticleSystem[] m_explosionLoopEffect;
		[SerializeField]
		private Renderer[] m_mvHideObjects;
	}
}
