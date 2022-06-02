using UnityEngine;
using XeApp.Game.UI;

namespace XeApp.Game.RhythmGame.UI
{
	public class BattleTimeCounter : MonoBehaviour
	{
		[SerializeField]
		private Animator m_timerBaseAnimator;
		[SerializeField]
		private Animator m_timerNumAnimator;
		[SerializeField]
		private NumericMesh m_numericMesh;
		[SerializeField]
		private GameObject m_dangerTimeModel;
		[SerializeField]
		private GameObject m_normalTimeModel;
		[SerializeField]
		private MeshFilter m_colonMesh;
	}
}
