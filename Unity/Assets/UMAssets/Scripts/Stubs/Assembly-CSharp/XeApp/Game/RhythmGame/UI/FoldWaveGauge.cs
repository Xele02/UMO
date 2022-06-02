using UnityEngine;
using XeApp.Game.UI;

namespace XeApp.Game.RhythmGame.UI
{
	public class FoldWaveGauge : MonoBehaviour
	{
		[SerializeField]
		private NumericMeshMultiPolygon m_numericMesh;
		[SerializeField]
		private GameObject m_gaugePrefab;
		[SerializeField]
		private GameObject m_meshParent;
		[SerializeField]
		private Animator m_circleAnime;
		[SerializeField]
		private GameObject m_circleEffectPrefab;
		[SerializeField]
		private FoldWaveGaugeCircleUvChanger m_circleUvChange;
	}
}
