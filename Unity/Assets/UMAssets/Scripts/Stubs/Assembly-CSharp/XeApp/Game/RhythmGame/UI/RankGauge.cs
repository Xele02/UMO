using UnityEngine;

namespace XeApp.Game.RhythmGame.UI
{
	public class RankGauge : MonoBehaviour
	{
		[SerializeField]
		private GameObject m_gaugeMeshPrefab;
		[SerializeField]
		private GameObject m_parentObject;
		[SerializeField]
		private GameObject m_effectObject;
		[SerializeField]
		private Animator m_rankAnime;
	}
}
