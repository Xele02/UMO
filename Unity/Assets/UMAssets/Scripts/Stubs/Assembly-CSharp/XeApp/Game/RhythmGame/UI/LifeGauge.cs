using UnityEngine;

namespace XeApp.Game.RhythmGame.UI
{
	public class LifeGauge : MonoBehaviour
	{
		[SerializeField]
		private GameObject m_gaugeMeshPrefab;
		[SerializeField]
		private GameObject m_parentObject;
		[SerializeField]
		private GameObject m_heartMarkObject;
		[SerializeField]
		private GameObject m_normalHeartMark;
	}
}
